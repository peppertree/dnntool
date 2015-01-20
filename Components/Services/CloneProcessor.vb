Imports System.ComponentModel
Imports Microsoft.ApplicationBlocks.Data
Imports DNNTool.Entities
Imports System.IO
Imports System.Security.AccessControl
Imports DNNTool.Common
Imports System.Data.SqlClient
Imports DNNTool.Services.Args



Namespace Services
    Public Class CloneProcessor

        Private Shared _result As CloneInfo

        Public Shared Function Work(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As CloneInfo

            Dim args As ProcessCloneArgs = CType(e.Argument, ProcessCloneArgs)
            _result = New CloneInfo

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
                percentage = 100
                worker.ReportProgress(percentage)
            Else
                _result.ResultString = "Archive is not a valid DNN clone"
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
                _result.SiteName = filename.Substring(filename.LastIndexOf("\") + 1).Replace(".zip", "")

            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function

        Private Shared Function ValidateDNN(targetDirectory As String) As Boolean

            Dim pathDLL As String = Path.Combine(targetDirectory, "website\bin\dotnetnuke.dll")
            Dim pathConfig As String = Path.Combine(targetDirectory, "website\web.config")

            If System.IO.File.Exists(pathDLL) AndAlso File.Exists(pathConfig) Then

                For Each File As String In Directory.GetFiles(Path.Combine(targetDirectory, "database"))
                    If File.ToLower.EndsWith(".mdf") Then
                        _result.MDFPath = File
                    End If
                    If File.ToLower.EndsWith(".ldf") Then
                        _result.LDFPath = File
                    End If
                Next

                Dim dnnVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(pathDLL)
                If Not dnnVersionInfo Is Nothing Then
                    _result.DNNVersion = String.Format("DNN {0}.{1}.{2}", dnnVersionInfo.FileMajorPart.ToString, dnnVersionInfo.FileMinorPart.ToString, dnnVersionInfo.FileBuildPart.ToString)
                End If
                _result.ConnectionString = Utilities.GetConnectionStringFromConfig(Path.Combine(targetDirectory, "website"))

                Dim valuePairs As String() = _result.ConnectionString.Split(Char.Parse(";"))
                For Each valuePair As String In valuePairs
                    If valuePair.ToLower.Contains("database=") Or valuePair.ToLower.Contains("catalog=") Then
                        Dim dbConfig As String() = valuePair.Trim.Split(Char.Parse("="))
                        _result.DatabaseName = dbConfig(1)
                        _result.ConnectionString = _result.ConnectionString.Replace(_result.DatabaseName, _result.DatabaseName & "_clone")
                        _result.DatabaseName += "_clone"
                    End If
                Next

                _result.IsValidDNN = True
                System.Threading.Thread.Sleep(1000)

                Return True

            End If

            _result.IsValidDNN = False
            Return False

        End Function

#End Region



    End Class
End Namespace

