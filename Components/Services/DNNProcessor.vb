Imports System.ComponentModel
Imports Microsoft.ApplicationBlocks.Data
Imports DNNTool.Entities
Imports System.IO
Imports System.Security.AccessControl
Imports DNNTool.Common
Imports System.Data.SqlClient
Imports DNNTool.Services.Args



Namespace Services
    Public Class DNNProcessor

        Private Shared _result As DNNInfo

        Public Shared Function Work(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As DNNInfo

            Dim args As ProcessDNNArgs = CType(e.Argument, ProcessDNNArgs)
            _result = New DNNInfo

            Dim percentage As Integer = 5
            worker.ReportProgress(percentage)

            If ExtractArchive(args.ArchivePath, args.TargetPath) Then
                percentage = 50
                worker.ReportProgress(percentage)
            Else
                _result.ResultString = "Error copying filesystem"
                Return _result
            End If

            If ValidateDNN(args.TargetPath) Then
                percentage = 75
                worker.ReportProgress(percentage)
            Else
                _result.ResultString = "Archive is not a valid DNN installation"
                Return _result
            End If

            If SetHostAccount(args.TargetPath, args.HostUsername, args.HostPassword) Then
                percentage = 100
                worker.ReportProgress(percentage)
            Else
                _result.ResultString = "Could not set host account"
                Return _result
            End If

            _result.ResultString = "Archive processed"
            Return _result

        End Function

#Region "Internals"

        Private Shared Function ExtractArchive(filename As String, targetDirectory As String) As Boolean

            Try

                Utilities.DirectoryDelete(targetDirectory)
                Utilities.DirectoryCreate(targetDirectory)

                System.IO.Compression.ZipFile.ExtractToDirectory(filename, targetDirectory)
                _result.SiteName = filename.ToLower.Substring(filename.LastIndexOf("\") + 1).Replace(".zip", "").Replace("_install", "")

            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function

        Private Shared Function ValidateDNN(targetDirectory As String) As Boolean

            Dim pathDLL As String = Path.Combine(targetDirectory, "bin\dotnetnuke.dll")
            Dim pathConfig As String = Path.Combine(targetDirectory, "web.config")

            If System.IO.File.Exists(pathDLL) AndAlso File.Exists(pathConfig) Then

                Dim dnnVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(pathDLL)
                If Not dnnVersionInfo Is Nothing Then
                    _result.DNNVersion = String.Format("DNN {0}.{1}.{2}", dnnVersionInfo.FileMajorPart.ToString, dnnVersionInfo.FileMinorPart.ToString, dnnVersionInfo.FileBuildPart.ToString)
                    _result.IsValidDNN = True
                End If

                System.Threading.Thread.Sleep(1000)
                Return True

            End If


            _result.IsValidDNN = False
            System.Threading.Thread.Sleep(1000)

            Return False

        End Function

        Private Shared Function SetHostAccount(targetDirectory As String, username As String, password As String) As Boolean

            Dim pathConfig As String = Path.Combine(targetDirectory, "install\DotNetNuke.install.config.resources")
            If System.IO.File.Exists(pathConfig) Then
                Dim sr As New StreamReader(pathConfig)
                If Not sr Is Nothing Then
                    Dim config As String = sr.ReadToEnd
                    sr.Close()
                    sr.Dispose()

                    config = config.Replace("<username>host</username>", "<username>" & username & "</username>")
                    config = config.Replace("<password>dnnhost</password>", "<password>" & password & "</password>")

                    Dim sw As New StreamWriter(pathConfig, False)
                    sw.Write(config)
                    sw.Close()
                    sw.Dispose()

                End If
            End If

            System.Threading.Thread.Sleep(1000)
            Return True

        End Function

#End Region



    End Class
End Namespace

