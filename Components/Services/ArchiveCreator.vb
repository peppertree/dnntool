Imports System.ComponentModel
Imports Microsoft.ApplicationBlocks.Data
Imports DNNTool.Entities
Imports System.IO
Imports System.Security.AccessControl
Imports DNNTool.Common
Imports System.Data.SqlClient
Imports DNNTool.Services.Args


Namespace Services
    Public Class ArchiverCreator

        Private Shared _connection As SqlClient.SqlConnection

        Public Shared Function Work(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As String

            Dim args As CreateArchiveArgs = CType(e.Argument, CreateArchiveArgs)

            _connection = args.Connection

            Dim percentage As Integer = 5
            worker.ReportProgress(percentage)

            If CloneFilesystem(args.SrcPath, args.TargetPath) Then
                percentage = 50
                worker.ReportProgress(percentage)
            Else
                e.Cancel = True
                Return String.Format("Error copying filesystem")
            End If

            If CopyDatabase(args.TargetPath) Then
                percentage = 75
                worker.ReportProgress(percentage)
            Else
                e.Cancel = True
                Return String.Format("Error copying database")
            End If

            If CreateArchive(args.TargetPath, args.SiteName) Then
                percentage = 100
                worker.ReportProgress(percentage)
            Else
                e.Cancel = True
                Return String.Format("Error creating archive")
            End If

            Return String.Format("Archive created")

        End Function


#Region "Internals"

        Private Shared Function CloneFilesystem(srcPath As String, targetPath As String) As Boolean

            Dim destPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\website")
            Try
                Utilities.DirectoryDelete(destPath)
                Utilities.DirectoryCopy(srcPath, destPath, True)
            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function

        Private Shared Function CopyDatabase(targetPath As String) As Boolean

            Dim destPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\database")
            Utilities.DirectoryDelete(destPath)
            Utilities.DirectoryCreate(destPath)

            Dim logialName As String = ""
            Dim physicalName As String = ""
            Dim sql As String = ""
            Dim db As DatabaseInfo = Utilities.GetDatabaseInfo(_connection)

            If Not db Is Nothing Then

                Utilities.DetachDatabase(_connection, db.Database)

                System.IO.File.Copy(db.PathMdf, destPath & "\" & db.FileNameMdf)
                System.IO.File.Copy(db.PathLdf, destPath & "\" & db.FileNameLdf)

                Utilities.AttachDatabase(_connection, db)

            End If

            Return True

        End Function

        Private Shared Function CreateArchive(targetPath As String, archiveName As String) As Boolean

            Dim zippath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp")

            Dim archiveFileName As String = Path.Combine(targetPath, archiveName & "_clone.zip")
            If System.IO.File.Exists(archiveFileName) Then
                File.Delete(archiveFileName)
            End If
            Try
                System.IO.Compression.ZipFile.CreateFromDirectory(zippath, archiveFileName)
                Directory.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\website"), True)
                Directory.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\database"), True)
            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function

#End Region



    End Class
End Namespace

