Imports System.Data.SqlClient
Imports System.DirectoryServices
Imports DNNTool.Entities
Imports System.ComponentModel
Imports DNNTool.Services


Public Class ucUsers

#Region "Private Members"

    Private _srcConnectionString As String = ""
    Private _srcSiteName As String = ""
    Private _srcSiteAlias As String = ""
    Private _srcSitePath As String = ""
    Private _srcDatabaseName As String = ""
    Private _srcSitePort As Integer = 80

    Private _connection As SqlConnection = Nothing

#End Region

#Region "Event Handlers"

    Private Sub drpSiteForUserCreation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpSiteForUserCreation.SelectedIndexChanged
        BindSite()
    End Sub

    Private Sub btnCreateAccountStart_Click(sender As Object, e As EventArgs) Handles btnCreateAccountStart.Click

        If Not _connection Is Nothing Then

            If UserCreateProcess.IsBusy <> True Then

                Dim args As New UserCreateArgs
                args.Accounts = Convert.ToInt32(ctlNumberofAcounts.Value)
                args.CleanUpFirst = chkCleanFirst.Checked
                args.PortalId = Convert.ToInt32(ctlPortalId.Value)
                args.Connection = _connection

                btnCreateAccountCancel.Enabled = True
                btnCreateAccountStart.Enabled = False
                lblCreateResult.Text = "Processing request..."

                UserCreateProcess.RunWorkerAsync(args)

            Else

                MsgBox("Another process is still busy. Please wait...")

            End If

        Else

            MsgBox("Could not connect to database!")

        End If

    End Sub

    Private Sub btnCreateAccountCancel_Click(sender As Object, e As EventArgs) Handles btnCreateAccountCancel.Click

        If UserCreateProcess.WorkerSupportsCancellation Then
            UserCreateProcess.CancelAsync()
            btnCreateAccountCancel.Enabled = False
            ctlAccountsProgress.Value = 0
        End If

    End Sub

    Private Sub UserCreateProcess_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles UserCreateProcess.DoWork
        e.Result = Services.UserCreator.Work(CType(sender, BackgroundWorker), e)
    End Sub

    Private Sub UserCreateProcess_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles UserCreateProcess.ProgressChanged
        ctlAccountsProgress.Value = e.ProgressPercentage
        lblCreateResult.Text = e.ProgressPercentage.ToString
    End Sub

    Private Sub UserCreateProcess_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles UserCreateProcess.RunWorkerCompleted

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
            lblCreateResult.Text = "Canceled"
        Else
            ' Finally, handle the case where the operation succeeded.
            lblCreateResult.Text = e.Result.ToString()
        End If

        ' Enable the Start button.
        btnCreateAccountStart.Enabled = True

        ' Disable the Cancel button.
        btnCreateAccountCancel.Enabled = False

        ctlAccountsProgress.Value = 0

    End Sub

    Private Sub ucUsers_Load(sender As Object, e As EventArgs) Handles Me.Load
        BindSites()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub BindSites()

        drpSiteForUserCreation.Items.Clear()

        Dim IISServer As New DirectoryEntry("IIS://localhost/W3SVC")

        For Each e As DirectoryEntry In IISServer.Children

            If e.SchemaClassName.ToLower = "iiswebserver" Then

                Dim siteName As String = e.Properties("ServerComment")(0).ToString
                Dim siteId As String = e.Name

                If Common.Utilities.IsDNN(siteId) Then
                    drpSiteForUserCreation.Items.Add(New SiteItem(siteId, siteName))
                End If

            End If

        Next

    End Sub

    Private Sub BindSite()

        _srcSiteName = CType(drpSiteForUserCreation.SelectedItem, SiteItem).SiteName
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
                    End If

                    lblDNNVersion.Text = String.Format("DNN {0}.{1}.{2}", dnnVersionInfo.FileMajorPart.ToString, dnnVersionInfo.FileMinorPart.ToString, dnnVersionInfo.FileBuildPart.ToString)
                    lblAlias.Text = _srcSiteAlias
                    lblConnectionString.Text = _srcConnectionString
                    lblDatabasename.Text = _srcDatabaseName
                    lblPort.Text = _srcSitePort.ToString
                    lblSitePath.Text = _srcSitePath

                    btnCreateAccountStart.Enabled = True

                End If
            End If

        End If

    End Sub

#End Region


End Class
