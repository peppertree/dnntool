Imports System.ComponentModel
Imports Microsoft.ApplicationBlocks.Data
Imports DNNTool.Entities
Imports System.IO
Imports System.Security.AccessControl
Imports DNNTool.Common
Imports DNNTool.Services.Args


Namespace Services
    Public Class SiteCloner

        Private Shared _connection As SqlClient.SqlConnection

        Public Shared Function Work(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As String

            Dim args As SiteCopyArgs = CType(e.Argument, SiteCopyArgs)
            args.TargetSitePath = getTargetPath(args.SrcSitePath, args.TargetSiteName)

            _connection = args.Connection

            Dim percentage As Integer = 5
            worker.ReportProgress(percentage)

            If CloneFilesystem(args.SrcSitePath, args.TargetSitePath, args.TargetSiteName) Then
                percentage = 25
                worker.ReportProgress(percentage)
            Else
                e.Cancel = True
                Return String.Format("Error copying filesystem")
            End If


            If Utilities.CreateSite(args.TargetSiteName, args.TargetSitePath, args.TargetSitePort, args.TargetSiteAlias) Then
                percentage = 50
                worker.ReportProgress(percentage)
            Else
                e.Cancel = True
                Return String.Format("Error creating site")
            End If

            If CloneDatabase(args.SrcDatabaseName, args.TargetDatabaseName, args.TargetSiteName) Then
                percentage = 75
                worker.ReportProgress(percentage)
            Else
                e.Cancel = True
                Return String.Format("Error copying database")
            End If

            If UpdateReferences(args.SrcDatabaseName, args.TargetDatabaseName, args.TargetSiteAlias, args.SrcSiteAlias, args.TargetSitePath) Then
                percentage = 100
                worker.ReportProgress(percentage)
            Else
                e.Cancel = True
                Return String.Format("Error setting database content")
            End If

            Return String.Format("Site cloned")

        End Function


#Region "Inernals"

        Private Shared Function getTargetPath(srcPath As String, targetSitename As String) As String

            If srcPath.EndsWith("\") Then
                srcPath = srcPath.Substring(0, srcPath.Length - 2)
            End If
            'remove last level, i.e. move one level up
            srcPath = srcPath.Substring(0, srcPath.LastIndexOf("\"))
            If Not srcPath.EndsWith("\") Then
                srcPath += "\"
            End If
            srcPath += targetSitename

            Return srcPath

        End Function

        Private Shared Function CloneFilesystem(srcSitePath As String, targetSitePath As String, targetSiteName As String) As Boolean

            Utilities.DirectoryDelete(targetSitePath)
            Utilities.DirectoryCopy(srcSitePath, targetSitePath, True)

            Return True

        End Function

        Private Shared Function CloneDatabase(srcDBName As String, targetDBName As String, targetSiteName As String) As Boolean

            Dim CurrentDB As DatabaseInfo = Utilities.GetDatabaseInfo(_connection)
            Dim TargetDB As DatabaseInfo = Nothing

            If Not CurrentDB Is Nothing Then

                '1.: Make sure clone db does not exist yet
                Try
                    Utilities.DropDatabase(_connection, targetDBName)
                Catch
                End Try


                '2.: Detach current database
                Utilities.DetachDatabase(_connection, CurrentDB.Database)

                '3.: Create database clone

                Dim targetMDFPath As String = CurrentDB.PathMdf.Replace(".mdf", "_clone.mdf")
                Dim targetLDFPath As String = CurrentDB.PathLdf.Replace(".ldf", "_clone.ldf")

                TargetDB = New DatabaseInfo
                TargetDB.Database = CurrentDB.Database & "_Clone"
                TargetDB.LogicalNameLdf = CurrentDB.LogicalNameLdf
                TargetDB.PathLdf = targetLDFPath
                TargetDB.FileNameLdf = targetLDFPath.Substring(targetLDFPath.LastIndexOf("\") + 1)
                TargetDB.LogicalNameMdf = CurrentDB.LogicalNameMdf
                TargetDB.PathMdf = targetMDFPath
                TargetDB.FileNameMdf = targetMDFPath.Substring(targetMDFPath.LastIndexOf("\") + 1)

                '3.: Copy files into new db files
                Try
                    If File.Exists(targetMDFPath) Then
                        File.Delete(targetMDFPath)
                    End If
                    If File.Exists(targetLDFPath) Then
                        File.Delete(targetLDFPath)
                    End If
                Catch
                End Try
                System.IO.File.Copy(CurrentDB.PathMdf, targetMDFPath)
                System.IO.File.Copy(CurrentDB.PathLdf, targetLDFPath)

                '4.: Attach new database
                Utilities.AttachDatabase(_connection, TargetDB)

                '5.: Attach original database
                Utilities.AttachDatabase(_connection, CurrentDB)

                '6.: apply new db permissions
                Utilities.ApplyDatabasePermissions(_connection, TargetDB, targetSiteName)

            End If

            Return True

        End Function

        Private Shared Function UpdateReferences(srcDBName As String, targetDBName As String, targetSiteAlias As String, srcSiteAlias As String, targetSrcPath As String) As Boolean

            '1. change connection string in web.config

            Dim path As String = (targetSrcPath & "\web.config").Replace("\\", "\")
            If System.IO.File.Exists(path) Then
                Dim sr As New StreamReader(path)
                Dim strConfig As String = sr.ReadToEnd
                sr.Close()
                sr.Dispose()

                strConfig = strConfig.Replace(srcDBName, targetDBName)

                Dim sw As New StreamWriter(path, False)
                sw.Write(strConfig)
                sw.Close()
                sw.Dispose()

            End If


            '2. change alias in table
            Dim sql As String = ""
            sql = "USE [" & targetDBName & "];" & vbNewLine
            sql += "Update [PortalAlias] set HTTPAlias = '" & targetSiteAlias & "' Where HTTPAlias = '" & srcSiteAlias & "';" & vbNewLine
            sql += "Update [PortalSettings] set SettingValue = '" & targetSiteAlias & "' Where SettingName = 'DefaultPortalAlias';" & vbNewLine
            Try
                SqlHelper.ExecuteNonQuery(_connection, System.Data.CommandType.Text, sql)
            Catch
            End Try

            Return True
        End Function

#End Region



    End Class
End Namespace

