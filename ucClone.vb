Imports DNNTool.Entities
Imports System.DirectoryServices
Imports System.ComponentModel
Imports DNNTool.Services
Imports System.Data.SqlClient

Public Class ucClone

#Region "Private Members"

    Private _srcConnectionString As String = ""
    Private _srcSiteName As String = ""
    Private _srcSiteAlias As String = ""
    Private _srcSitePath As String = ""
    Private _srcDatabaseName As String = ""
    Private _srcSitePort As Integer = 80

    Private _connection As SqlConnection = Nothing
    Private _targetDir As String

#End Region

#Region "Event Handlers"

    Private Sub ucClone_Load(sender As Object, e As EventArgs) Handles Me.Load
        BindSites()
    End Sub

    Private Sub drpSiteForCloning_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpSiteForCloning.SelectedIndexChanged

        BindSite()

    End Sub

    Private Sub btnCloneStart_Click(sender As Object, e As EventArgs) Handles btnCloneStart.Click

        Dim blnProceed As Boolean = True

        If _connection Is Nothing Then
            MsgBox("Could not connect to database!")
            blnProceed = False
        End If
        If SiteCopyProcess.IsBusy = True Then
            MsgBox("Another process is still busy. Please wait...")
            blnProceed = False
        End If
        If txtTargetDatabaseName.Text = "" Then
            MsgBox("Enter a name for the new database!")
            blnProceed = False
        End If
        If txtTargetSiteAlias.Text = "" Then
            MsgBox("Enter a hostheader / alias for the new site!")
            blnProceed = False
        End If
        If txtTargetSiteName.Text = "" Then
            MsgBox("Enter a name for the new site!")
            blnProceed = False
        End If

        If blnProceed Then

            Dim args As New SiteCopyArgs

            args.SrcSiteName = _srcSiteName
            args.SrcSiteAlias = _srcSiteAlias
            args.SrcDatabaseName = _srcDatabaseName
            args.SrcSitePath = _srcSitePath
            args.SrcSitePort = _srcSitePort
            args.SrcConnectionString = _srcConnectionString

            args.TargetSiteAlias = txtTargetSiteAlias.Text
            args.TargetDatabaseName = txtTargetDatabaseName.Text
            args.TargetSiteName = txtTargetSiteName.Text
            args.TargetSitePath = ""
            args.TargetSitePort = Convert.ToInt32(ctlTargetSitePort.Value)

            args.Connection = _connection

            btnCloneCancel.Enabled = True
            btnCloneStart.Enabled = False
            lblCloneResult.Text = "Processing request..."

            SiteCopyProcess.RunWorkerAsync(args)
        End If

    End Sub

    Private Sub btnCloneCancel_Click(sender As Object, e As EventArgs) Handles btnCloneCancel.Click

        If SiteCopyProcess.WorkerSupportsCancellation Then
            SiteCopyProcess.CancelAsync()
            btnCloneCancel.Enabled = False
            btnCloneStart.Enabled = True
            ctlCloneProgress.Value = 0
        End If

    End Sub

    Private Sub btnSelectDirectory_Click(sender As Object, e As EventArgs) Handles btnSelectDirectory.Click
        Dim result As DialogResult = ctlFolderSelect.ShowDialog
        If result = DialogResult.OK Then
            _targetDir = ctlFolderSelect.SelectedPath
            lblArchiveResult.Text = "Selected: " & _targetDir
            btnStart.Enabled = _srcSiteName <> String.Empty
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        Dim blnProceed As Boolean = True
        If CreateArchiveProcess.IsBusy = True Then
            MsgBox("Another process is still busy. Please wait...")
            blnProceed = False
        End If

        If blnProceed Then

            Dim args As New CreateArchiveArgs
            args.SrcPath = _srcSitePath
            args.TargetPath = _targetDir
            args.DatabaseName = _srcDatabaseName
            args.Connection = _connection
            args.SiteName = _srcSiteName

            lblArchiveResult.Text = "Processing request..."
            CreateArchiveProcess.RunWorkerAsync(args)

            btnStart.Enabled = False
            btnSelectDirectory.Enabled = False

        End If

    End Sub

    Private Sub SiteCopyProcess_DoWork(sender As Object, e As DoWorkEventArgs) Handles SiteCopyProcess.DoWork

        e.Result = Services.SiteCloner.Work(CType(sender, BackgroundWorker), e)

    End Sub

    Private Sub CreateArchiveProcess_DoWork(sender As Object, e As DoWorkEventArgs) Handles CreateArchiveProcess.DoWork

        e.Result = Services.ArchiverCreator.Work(CType(sender, BackgroundWorker), e)

    End Sub

    Private Sub SiteCopyProcess_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles SiteCopyProcess.ProgressChanged

        ctlCloneProgress.Value = e.ProgressPercentage

        If e.ProgressPercentage = 5 Then
            lblCloneResult.Text = "copying filesystem..."
        End If
        If e.ProgressPercentage = 25 Then
            lblCloneResult.Text = "creating site in IIS..."
        End If
        If e.ProgressPercentage = 50 Then
            lblCloneResult.Text = "creating copy of database..."
        End If
        If e.ProgressPercentage = 75 Then
            lblCloneResult.Text = "updating references..."
        End If

    End Sub

    Private Sub CreateArchiveProcess_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles CreateArchiveProcess.ProgressChanged

        ctlArchiveProcess.Value = e.ProgressPercentage

        If e.ProgressPercentage = 5 Then
            lblArchiveResult.Text = "copying filesystem..."
        End If
        If e.ProgressPercentage = 50 Then
            lblArchiveResult.Text = "copying database..."
        End If
        If e.ProgressPercentage = 75 Then
            lblArchiveResult.Text = "creating archive..."
        End If

    End Sub

    Private Sub SiteCopyProcess_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles SiteCopyProcess.RunWorkerCompleted

        ' First, handle the case where an exception was thrown. 
        If (e.Error IsNot Nothing) Then
            MessageBox.Show(e.Error.Message)
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the  
            ' operation. 
            ' Note that due to a race condition in  
            ' the DoWork event handler, the Cancelled 
            ' flag may not have been set, even though 
            ' CancelAsync was called.
            lblCloneResult.Text = "Canceled"
        Else
            ' Finally, handle the case where the operation succeeded.
            hypSite.Enabled = True
            lblCloneResult.Text = e.Result.ToString()
        End If

        ' Enable the Start button.
        btnCloneStart.Enabled = True

        ' Disable the Cancel button.
        btnCloneCancel.Enabled = False

        ctlCloneProgress.Value = 0

        If Not _connection Is Nothing Then
            _connection.Close()
            _connection.Dispose()
        End If

    End Sub

    Private Sub CreateArchiveProcess_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CreateArchiveProcess.RunWorkerCompleted

        ' First, handle the case where an exception was thrown. 
        If (e.Error IsNot Nothing) Then
            MessageBox.Show(e.Error.Message)
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the  
            ' operation. 
            ' Note that due to a race condition in  
            ' the DoWork event handler, the Cancelled 
            ' flag may not have been set, even though 
            ' CancelAsync was called.
            lblArchiveResult.Text = "unknown error"
        Else
            ' Finally, handle the case where the operation succeeded.
            hypDownload.Enabled = True
            lblArchiveResult.Text = e.Result.ToString()
        End If

        ' Enable the Start button.
        btnStart.Enabled = False
        ' Disable the Cancel button.
        btnSelectDirectory.Enabled = False
        drpSiteForCloning.SelectedItem = Nothing
        drpSiteForCloning.SelectedIndex = -1
        drpSiteForCloning.Items.Clear()
        BindSites()

        ctlArchiveProcess.Value = 0

        If Not _connection Is Nothing Then
            _connection.Close()
            _connection.Dispose()
        End If

    End Sub

    Private Sub hypSite_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles hypSite.Click

        Dim url As String = "http://" & txtTargetSiteAlias.Text
        System.Diagnostics.Process.Start(url)

    End Sub

    Private Sub hypDownload_Click(sender As Object, e As EventArgs) Handles hypDownload.Click
        Process.Start(ctlFolderSelect.SelectedPath)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub BindSites()

        drpSiteForCloning.Items.Clear()

        Dim IISServer As New DirectoryEntry("IIS://localhost/W3SVC")

        For Each e As DirectoryEntry In IISServer.Children

            If e.SchemaClassName.ToLower = "iiswebserver" Then

                Dim siteName As String = e.Properties("ServerComment")(0).ToString
                Dim siteId As String = e.Name

                If Common.Utilities.IsDNN(siteId) Then
                    drpSiteForCloning.Items.Add(New SiteItem(siteId, siteName))
                End If

            End If

        Next

    End Sub

    Private Sub BindSite()

        Try

            _srcSiteName = CType(drpSiteForCloning.SelectedItem, SiteItem).SiteName
            Dim site As IISWebsite = IISWebsite.OpenWebsite(_srcSiteName)
            If Not site Is Nothing Then

                _srcSitePath = site.Root.Path()
                _srcSiteAlias = site.Hostheader
                _srcSitePort = site.Port

                If System.IO.Directory.Exists(_srcSitePath) Then

                    Dim path As String = _srcSitePath
                    path += ("\bin\dotnetnuke.dll").Replace("\\", "\")

                    Dim dnnVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(path)
                    If Not dnnVersionInfo Is Nothing Then

                        _srcConnectionString = Common.Utilities.GetConnectionStringFromConfig(_srcSitePath)
                        If Not String.IsNullOrEmpty(_srcConnectionString) Then
                            _connection = Common.Utilities.GetDatabaseConnection(_srcConnectionString)
                            _srcDatabaseName = _connection.Database
                        End If

                        lblDNNVersion.Text = String.Format("DNN {0}.{1}.{2}", dnnVersionInfo.FileMajorPart.ToString, dnnVersionInfo.FileMinorPart.ToString, dnnVersionInfo.FileBuildPart.ToString)
                        lblAlias.Text = _srcSiteAlias
                        lblConnectionString.Text = _srcConnectionString
                        lblDatabasename.Text = _srcDatabaseName
                        lblPort.Text = _srcSitePort.ToString
                        lblSitePath.Text = _srcSitePath

                        btnCloneStart.Enabled = (Not _connection Is Nothing)
                        btnSelectDirectory.Enabled = (Not _connection Is Nothing)

                        txtTargetSiteName.Text = String.Format("clone.{0}", _srcSiteName)
                        txtTargetSiteAlias.Text = String.Format("clone.{0}", _srcSiteAlias)
                        txtTargetDatabaseName.Text = String.Format("{0}_clone", _srcDatabaseName)
                        ctlTargetSitePort.Value = CDec(80)

                    End If
                End If

            End If

        Catch ex As Exception

            lblDNNVersion.Text = "n/a"
            lblAlias.Text = "n/a"
            lblConnectionString.Text = "n/a"
            lblDatabasename.Text = "n/a"
            lblPort.Text = "n/a"
            lblSitePath.Text = "n/a"
            txtTargetSiteName.Text = ""
            txtTargetSiteAlias.Text = ""
            txtTargetDatabaseName.Text = ""
            ctlTargetSitePort.Value = CDec(80)

        End Try



    End Sub

#End Region

End Class
