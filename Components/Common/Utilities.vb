Imports System.DirectoryServices
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.AccessControl
Imports DNNTool.Entities
Imports Microsoft.ApplicationBlocks.Data

Namespace Common
    Public Class Utilities

        Public Shared Sub DirectoryDelete(folderPath As String)

            If System.IO.Directory.Exists(folderPath) Then
                System.IO.Directory.Delete(folderPath, True)
            End If

        End Sub

        Public Shared Sub DirectoryCreate(folderPath As String)

            If Not System.IO.Directory.Exists(folderPath) Then
                System.IO.Directory.CreateDirectory(folderPath)
            End If

        End Sub

        Public Shared Sub DirectoryCopy(ByVal sourceDirName As String, ByVal destDirName As String, ByVal copySubDirs As Boolean)

            ' Get the subdirectories for the specified directory. 
            Dim targetDir As DirectoryInfo = Nothing
            Dim srcDir As DirectoryInfo = New DirectoryInfo(sourceDirName)
            Dim srcDirs As DirectoryInfo() = srcDir.GetDirectories()

            If Not srcDir.Exists Then
                Throw New DirectoryNotFoundException( _
                    "Source directory does not exist or could not be found: " _
                    + sourceDirName)
            End If

            ' If the destination directory doesn't exist, create it. 
            If Not Directory.Exists(destDirName) Then
                targetDir = Directory.CreateDirectory(destDirName)
            End If
            ' Get the files in the directory and copy them to the new location. 
            Dim srcFiles As FileInfo() = srcDir.GetFiles()
            For Each srcFile In srcFiles
                If Not srcFile.Name.ToLower.EndsWith("thumbs.db") Then
                    Dim temppath As String = Path.Combine(destDirName, srcFile.Name)
                    srcFile.CopyTo(temppath, False)
                End If
            Next srcFile

            ' If copying subdirectories, copy them and their contents to new location. 
            If copySubDirs Then
                For Each subdir In srcDirs
                    Dim temppath As String = Path.Combine(destDirName, subdir.Name)
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs)
                Next
            End If

        End Sub

        Public Shared Sub DirectorySetAppPoolPermission(appPoolName, folderPath)

            Dim UserAccount As String = "IIS APPPOOL\" & appPoolName 'Specify the user here

            Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(folderPath)
            Dim FolderAcl As New DirectorySecurity
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            'FolderAcl.SetAccessRuleProtection(True, False) 'uncomment to remove existing permissions
            FolderInfo.SetAccessControl(FolderAcl)

        End Sub

        Public Shared Function GetConnectionStringFromConfig(ByVal ConfigPath As String) As String

            Dim mapping As New ExeConfigurationFileMap()
            If ConfigPath.ToLower.EndsWith("web.config") Then
                mapping.ExeConfigFilename = ConfigPath
            Else
                mapping.ExeConfigFilename = ConfigPath & "\web.config"
            End If

            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(mapping, ConfigurationUserLevel.None)

            If Not config Is Nothing Then
                If Not config.ConnectionStrings Is Nothing Then
                    If config.ConnectionStrings.ConnectionStrings.Count > 0 Then
                        If Not config.ConnectionStrings.ConnectionStrings("SiteSqlServer") Is Nothing Then
                            Return config.ConnectionStrings.ConnectionStrings("SiteSqlServer").ConnectionString
                        End If
                    End If
                End If
            End If

            Return Nothing

        End Function

        Public Shared Function SetConnectionString(ByVal ConfigPath As String, ConnectionString As String) As Boolean

            Dim mapping As New ExeConfigurationFileMap()
            If ConfigPath.ToLower.EndsWith("web.config") Then
                mapping.ExeConfigFilename = ConfigPath
            Else
                mapping.ExeConfigFilename = ConfigPath & "\web.config"
            End If

            Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(mapping, ConfigurationUserLevel.None)

            If Not config Is Nothing Then
                If Not config.ConnectionStrings Is Nothing Then
                    If config.ConnectionStrings.ConnectionStrings.Count > 0 Then
                        If Not config.ConnectionStrings.ConnectionStrings("SiteSqlServer") Is Nothing Then
                            config.ConnectionStrings.ConnectionStrings("SiteSqlServer").ConnectionString = ConnectionString
                            config.Save()
                        End If
                    End If
                End If
            End If

            Return True

        End Function

        Public Shared Function GetDatabaseConnection(ByVal ConnectionString As String)

            Try
                Return New SqlConnection(ConnectionString)
            Catch
            End Try

            Return Nothing

        End Function

        Public Shared Function IsDNN(siteId As String) As Boolean

            Dim site As New DirectoryEntry(String.Format("IIS://localhost/W3SVC/{0}", siteId))
            For Each entry As DirectoryEntry In site.Children
                If entry.SchemaClassName = "IIsWebVirtualDir" Then

                    Dim path As String = entry.Properties("path")(0).ToString()
                    If System.IO.Directory.Exists(path) Then
                        path += ("\bin\dotnetnuke.dll").Replace("\\", "\")

                        If System.IO.File.Exists(path) Then

                            Return True

                        End If

                    End If
                End If
            Next

            Return False

        End Function

        Public Shared Function GetDatabaseInfo(Connection As SqlConnection) As DatabaseInfo

            Dim item As New DatabaseInfo
            item.Database = Connection.Database

            Dim sql As String = "SELECT * FROM sys.database_files"
            Dim dr As IDataReader = SqlHelper.ExecuteReader(Connection, CommandType.Text, sql)
            While dr.Read
                Dim physicalName As String = Convert.ToString(dr("physical_name"))

                If physicalName.ToLower.EndsWith(".mdf") Then
                    item.LogicalNameLdf = Convert.ToString(dr("name"))
                    item.PathMdf = Convert.ToString(dr("physical_name"))
                End If

                If physicalName.ToLower.EndsWith(".ldf") Then
                    item.LogicalNameLdf = Convert.ToString(dr("name"))
                    item.PathLdf = Convert.ToString(dr("physical_name"))
                End If

            End While
            dr.Close()
            dr.Dispose()

            item.FileNameMdf = item.PathMdf.Substring(item.PathMdf.LastIndexOf("\") + 1)
            item.FileNameLdf = item.PathLdf.Substring(item.PathLdf.LastIndexOf("\") + 1)

            Return item

        End Function

        Public Shared Sub DropDatabase(Connection As SqlConnection, DatabaseName As String)

            Dim sql As String = ""
            sql = "USE [master];" & vbNewLine
            sql += "ALTER DATABASE [" & DatabaseName & "] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE;" & vbNewLine
            sql += "USE [master];" & vbNewLine
            sql += "DROP DATABASE [" & DatabaseName & "];"
            Try
                SqlHelper.ExecuteNonQuery(Connection, System.Data.CommandType.Text, sql)
            Catch
            End Try

        End Sub

        Public Shared Sub DetachDatabase(Connection As SqlConnection, DatabaseName As String)

            Dim sql As String = ""
            sql = "USE [master];" & vbNewLine
            sql += "ALTER DATABASE [" & DatabaseName & "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" & vbNewLine
            sql += "USE [master];" & vbNewLine
            sql += "EXEC sp_detach_db @dbname = '" & DatabaseName & "', @skipchecks = 'true';" & vbNewLine
            SqlHelper.ExecuteNonQuery(Connection, System.Data.CommandType.Text, sql)

        End Sub

        Public Shared Sub AttachDatabase(Connection As SqlConnection, DB As DatabaseInfo)

            Dim sql As String = ""
            sql = "USE [master];" & vbNewLine
            sql += "EXEC sp_attach_db @dbname = N'" & DB.Database & "', @filename1 = '" & DB.PathMdf & "', @filename2 = '" & DB.PathLdf & "';"
            SqlHelper.ExecuteNonQuery(Connection, System.Data.CommandType.Text, sql)

        End Sub

        Public Shared Sub CreateDatabase(Connection As SqlConnection, DB As DatabaseInfo)

            Dim sql As String = ""
            sql = "USE [master];" & vbNewLine
            sql += "CREATE DATABASE [" & DB.Database & "];"
            SqlHelper.ExecuteNonQuery(Connection, System.Data.CommandType.Text, sql)

        End Sub

        Public Shared Sub ApplyDatabasePermissions(Connection As SqlConnection, DB As DatabaseInfo, AppPoolName As String)

            Dim sql As String = ""

            sql = "USE [" & DB.Database & "];" & vbNewLine
            sql += "Create User [IIS APPPOOL\" & AppPoolName & "] WITH DEFAULT_SCHEMA = dbo;" & vbNewLine
            Try
                SqlHelper.ExecuteNonQuery(Connection, System.Data.CommandType.Text, sql)
            Catch
            End Try

            sql = "USE [" & DB.Database & "];" & vbNewLine
            sql += "ALTER AUTHORIZATION ON SCHEMA::[db_owner] TO [IIS APPPOOL\" & AppPoolName & "];" & vbNewLine
            Try
                SqlHelper.ExecuteNonQuery(Connection, System.Data.CommandType.Text, sql)
            Catch
            End Try

            sql = "USE [" & DB.Database & "];" & vbNewLine
            sql += "ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\" & AppPoolName & "];" & vbNewLine
            Try
                SqlHelper.ExecuteNonQuery(Connection, System.Data.CommandType.Text, sql)
            Catch
            End Try

        End Sub

        Public Shared Function CreateSite(siteName As String, sitePath As String, sitePort As String, hostHeader As String) As Boolean

            If Not IISAppPool.Exists(siteName) Then
                Try
                    IISAppPool.CreateAppPool(siteName)
                Catch
                End Try
            End If

            If Not IISWebsite.Exists(siteName) Then
                Try
                    IISWebsite.CreateWebsite(siteName, 80, sitePath, siteName, hostHeader)
                Catch
                End Try
            End If

            'set hostheader in hosts file
            Dim path As String = "C:\windows\system32\drivers\etc\hosts"
            If System.IO.File.Exists(path) Then

                Dim sr As New StreamReader(path)
                Dim content As String = sr.ReadToEnd
                sr.Close()
                sr.Dispose()

                Dim entry As String = "127.0.0.1       " & hostHeader
                If Not content.Contains(entry) Then
                    Dim sw As New StreamWriter(path, True)
                    sw.WriteLine("127.0.0.1       " & hostHeader)
                    sw.Close()
                    sw.Dispose()
                End If

            End If

            Utilities.DirectorySetAppPoolPermission(siteName, sitePath)

            Return True
        End Function

    End Class
End Namespace

