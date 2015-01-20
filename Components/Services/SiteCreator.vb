Imports System.ComponentModel
Imports Microsoft.ApplicationBlocks.Data
Imports DNNTool.Entities
Imports System.IO
Imports System.Security.AccessControl
Imports DNNTool.Common
Imports DNNTool.Services.Args


Namespace Services
    Public Class SiteCreator

        Private Shared _connection As SqlClient.SqlConnection
        Private Shared _fromClone As Boolean = False

        Public Shared Function Work(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As String

            Dim args As SiteCreateArgs = CType(e.Argument, SiteCreateArgs)

            _fromClone = args.FromClone
            _connection = args.Connection
            args.SitePath = GetTargetPath(args.SitePath)

            Dim percentage As Integer = 5
            worker.ReportProgress(percentage)

            If Utilities.CreateSite(args.SiteName, args.SitePath, args.SitePort, args.SiteAlias) Then
                percentage = 25
                worker.ReportProgress(percentage)
            Else
                e.Cancel = True
                Return "Error creating site"
            End If

            If _fromClone Then

                If AttachDatabase(args.DatabaseName, args.MDFPath, args.LDFPath, args.SiteName) Then
                    percentage = 50
                    worker.ReportProgress(percentage)
                Else
                    e.Cancel = True
                    Return "Error attaching database"
                End If

                If UpdateAliasInDatabase(args.DatabaseName, args.SiteAlias) Then
                    percentage = 75
                    worker.ReportProgress(percentage)
                Else
                    e.Cancel = True
                    Return "Error updating database"
                End If

            Else

                If CreateDatabase(args.DatabaseName, args.SiteName) Then
                    percentage = 75
                    worker.ReportProgress(percentage)
                Else
                    e.Cancel = True
                    Return "Error updating database"
                End If

            End If

            If SetConfig(args.ConnectionString, args.SitePath) Then
                percentage = 100
                worker.ReportProgress(percentage)
            Else
                e.Cancel = True
                Return "Error setting config."
            End If

            If _fromClone Then
                Return "Clone created"
            Else
                Return "Site created"
            End If

        End Function

#Region "Internals"

        Private Shared Function GetTargetPath(srcPath As String) As String

            If _fromClone Then
                Return Path.Combine(srcPath, "website")
            End If

            Return srcPath

        End Function

        Private Shared Function AttachDatabase(databaseName As String, mdfPath As String, ldfPath As String, siteName As String) As Boolean

            Dim db As New DatabaseInfo
            db.Database = databaseName
            db.PathMdf = mdfPath
            db.PathLdf = ldfPath

            Utilities.DropDatabase(_connection, databaseName)
            Utilities.AttachDatabase(_connection, db)
            Utilities.ApplyDatabasePermissions(_connection, db, siteName)

            Return True

        End Function

        Private Shared Function SetConfig(ConnectionString As String, ConfigPath As String) As Boolean

            Utilities.SetConnectionString(ConfigPath, ConnectionString)

            Return True
        End Function

        Private Shared Function UpdateAliasInDatabase(databaseName As String, siteAlias As String) As Boolean

            If _fromClone Then

                '2. change alias in table
                Dim sql As String = ""
                sql = "USE [" & databaseName & "];" & vbNewLine
                sql += "Update [PortalAlias] set HTTPAlias = '" & siteAlias & "';" & vbNewLine
                sql += "Update [PortalSettings] set SettingValue = '" & siteAlias & "' Where SettingName = 'DefaultPortalAlias';" & vbNewLine
                Try
                    SqlHelper.ExecuteNonQuery(_connection, System.Data.CommandType.Text, sql)
                Catch
                End Try

            End If

            Return True

        End Function

        Private Shared Function CreateDatabase(databaseName As String, siteName As String) As Boolean

            Dim db As New DatabaseInfo
            db.Database = databaseName

            Utilities.DropDatabase(_connection, databaseName)
            Utilities.CreateDatabase(_connection, db)
            Utilities.ApplyDatabasePermissions(_connection, db, siteName)

            Return True
        End Function

#End Region



    End Class
End Namespace

