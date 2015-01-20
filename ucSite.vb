Imports System.ComponentModel
Imports DNNTool.Services
Imports System.Data.SqlClient
Imports DNNTool.Services.Args

Public Class ucSite

#Region "Private Members"

    Private _Connection As SqlConnection
    Private _CloneArchive As String
    Private _InstallArchive As String
    Private _Databasename As String
    Private _targetDirectory As String
    Private _mode As String = "create"
    Private _mdfFile As String = ""
    Private _ldfFile As String = ""
    Private _ConnectionString As String = ""
    Private _targetConnectionString As String = ""

#End Region

#Region "Event Handlers"

    Private Sub ucSite_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtConnection.Text = My.Settings.LocalConnectionString
        txtHostpassword.Text = My.Settings.HostPassword
        txtHostusername.Text = My.Settings.HostUsername
    End Sub

    Private Sub btnSelectClone_Click(sender As Object, e As EventArgs) Handles btnSelectClone.Click

        Dim result As DialogResult = ctlSelectArchive.ShowDialog
        If result = DialogResult.OK Then
            Dim file As String = ctlSelectArchive.FileName
            If file.ToLower.EndsWith(".zip") Then
                _CloneArchive = file
                _InstallArchive = ""
                btnTargetDir.Enabled = True
                _mode = "clone"
                lblMode.Text = "create from clone"
                lblArchive.Text = file
            End If
        End If

    End Sub

    Private Sub btnSelectInstallation_Click(sender As Object, e As EventArgs) Handles btnSelectInstallation.Click

        Dim result As DialogResult = ctlSelectInstallation.ShowDialog
        If result = DialogResult.OK Then
            Dim file As String = ctlSelectInstallation.FileName
            If file.ToLower.EndsWith(".zip") Then
                _CloneArchive = ""
                _InstallArchive = file
                btnTargetDir.Enabled = True
                _mode = "create"
                lblMode.Text = "new site"
                lblArchive.Text = file
            End If
        End If

    End Sub

    Private Sub btnTargetDir_Click(sender As Object, e As EventArgs) Handles btnTargetDir.Click

        Dim result As DialogResult = ctlSelectTargetDir.ShowDialog
        If result = DialogResult.OK Then
            _targetDirectory = ctlSelectTargetDir.SelectedPath
            lblTargetDir.Text = _targetDirectory
        End If

        If Not String.IsNullOrEmpty(_targetDirectory) Then
            btnProcessArchive.Enabled = True
        End If

    End Sub

    Private Sub btnProcessArchive_Click(sender As Object, e As EventArgs) Handles btnProcessArchive.Click

        If _mode = "clone" Then
            ProcessCloneArchive()
        End If

        If _mode = "create" Then
            ProcessInstallArchive()
        End If

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        CreateSite()
    End Sub

    Private Sub CloneArchiveProcessor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles CloneArchiveProcessor.DoWork

        e.Result = Services.CloneProcessor.Work(CType(sender, BackgroundWorker), e)

    End Sub

    Private Sub CloneArchiveProcessor_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles CloneArchiveProcessor.ProgressChanged

        ctlCloneProgress.Value = e.ProgressPercentage

        If e.ProgressPercentage = 5 Then
            lblResult.Text = "extracting archive..."
        End If
        If e.ProgressPercentage = 50 Then
            lblResult.Text = "validating DNN..."
        End If
        If e.ProgressPercentage = 100 Then
            lblResult.Text = "done"
        End If

    End Sub

    Private Sub CloneArchiveProcessor_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles CloneArchiveProcessor.RunWorkerCompleted

        Dim result As CloneInfo = Nothing
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
            lblResult.Text = "Canceled"
        Else
            If Not e.Result Is Nothing Then

                result = CType(e.Result, CloneInfo)
                ' Finally, handle the case where the operation succeeded.
                lblResult.Text = result.ResultString
                lblVersion.Text = result.DNNVersion
                txtTargetDatabaseName.Text = result.DatabaseName
                txtTargetSiteName.Text = result.SiteName
                txtTargetSiteAlias.Text = result.SiteName
                ctlTargetSitePort.Value = CDec(80)
                lblSiteConnString.Text = result.ConnectionString
                _targetConnectionString = result.ConnectionString
                _mdfFile = result.MDFPath
                _ldfFile = result.LDFPath

                ' Enable the Start button.
                btnCreate.Enabled = result.IsValidDNN

            End If

        End If

        ctlCloneProgress.Value = 0

    End Sub

    Private Sub InstallFileProcessor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles InstallFileProcessor.DoWork
        e.Result = Services.DNNProcessor.Work(CType(sender, BackgroundWorker), e)
    End Sub

    Private Sub InstallFileProcessor_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles InstallFileProcessor.ProgressChanged

        ctlCloneProgress.Value = e.ProgressPercentage

        If e.ProgressPercentage = 5 Then
            lblResult.Text = "extracting archive..."
        End If
        If e.ProgressPercentage = 50 Then
            lblResult.Text = "validating DNN..."
        End If
        If e.ProgressPercentage = 75 Then
            lblResult.Text = "setting host account..."
        End If
        If e.ProgressPercentage = 100 Then
            lblResult.Text = "done"
        End If

    End Sub

    Private Sub InstallFileProcessor_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles InstallFileProcessor.RunWorkerCompleted

        Dim result As DNNInfo = Nothing
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
            lblResult.Text = "Canceled"
        Else
            If Not e.Result Is Nothing Then

                result = CType(e.Result, DNNInfo)
                ' Finally, handle the case where the operation succeeded.
                lblResult.Text = result.ResultString
                lblVersion.Text = result.DNNVersion
                txtTargetDatabaseName.Text = result.SiteName
                txtTargetSiteName.Text = result.SiteName
                txtTargetSiteAlias.Text = result.SiteName
                ctlTargetSitePort.Value = CDec(80)
                lblSiteConnString.Text = "n/a"
                _targetConnectionString = GenerateConnectionString()

                ' Enable the Start button.
                btnCreate.Enabled = result.IsValidDNN

            End If

        End If

        ctlCloneProgress.Value = 0

    End Sub

    Private Sub CreateSiteProcessor_DoWork(sender As Object, e As DoWorkEventArgs) Handles CreateSiteProcessor.DoWork
        e.Result = Services.SiteCreator.Work(CType(sender, BackgroundWorker), e)
    End Sub

    Private Sub CreateSiteProcessor_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles CreateSiteProcessor.ProgressChanged
        ctlCloneProgress.Value = e.ProgressPercentage

        If e.ProgressPercentage = 5 Then
            lblResult.Text = "creating site..."
        End If
        If e.ProgressPercentage = 25 Then
            lblResult.Text = "creating database..."
        End If
        If e.ProgressPercentage = 75 Then
            lblResult.Text = "setting config"
        End If
    End Sub

    Private Sub CreateSiteProcessor_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CreateSiteProcessor.RunWorkerCompleted
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
            lblResult.Text = "Canceled"
        Else
            lblResult.Text = "Site created"
            btnCreate.Enabled = False
            btnProcessArchive.Enabled = False
            hypSite.Enabled = True
        End If

        ctlCloneProgress.Value = 0
    End Sub

    Private Sub txtTargetDatabaseName_TextChanged(sender As Object, e As EventArgs) Handles txtTargetDatabaseName.TextChanged
        _targetConnectionString = GenerateConnectionString()
        lblSiteConnString.Text = _targetConnectionString
    End Sub

#End Region

#Region "Private Methods"

    Private Sub ProcessCloneArchive()

        Dim args As New ProcessCloneArgs
        args.TargetPath = _targetDirectory
        args.ArchivePath = _CloneArchive
        CloneArchiveProcessor.RunWorkerAsync(args)

    End Sub

    Private Sub ProcessInstallArchive()

        Dim args As New ProcessDNNArgs
        args.TargetPath = _targetDirectory
        args.ArchivePath = _InstallArchive
        args.HostUsername = txtHostusername.Text
        args.HostPassword = txtHostpassword.Text

        InstallFileProcessor.RunWorkerAsync(args)

    End Sub

    Private Sub CreateSite()

        _Connection = Common.Utilities.GetDatabaseConnection(txtConnection.Text)

        Dim args As New SiteCreateArgs
        args.ConnectionString = _targetConnectionString
        args.Connection = _Connection
        args.DatabaseName = txtTargetDatabaseName.Text
        args.FromClone = (_mode = "clone")
        args.LDFPath = _ldfFile
        args.MDFPath = _mdfFile
        args.SiteAlias = txtTargetSiteAlias.Text
        args.SiteName = txtTargetSiteName.Text
        args.SitePath = _targetDirectory
        args.SitePort = Convert.ToInt32(ctlTargetSitePort.Value)

        CreateSiteProcessor.RunWorkerAsync(args)

    End Sub

    Private Function GenerateConnectionString() As String

        Return String.Format(My.Settings.ConnectionStringTemplate, txtTargetDatabaseName.Text)

    End Function

#End Region

    Private Sub btnDownload_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BindRSS()

        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc.Load("http://dotnetnuke.codeplex.com/project/feeds/rss?ProjectRSSFeed=codeplex%3a%2f%2frelease%2fdotnetnuke")
        Dim ndChannel As Xml.XmlNode = xmlDoc.Item("rss").Item("channel")
        ' Enumerating through the items
        ' and populating the collection
        Dim ndItem As Xml.XmlNode
        For i As Integer = 0 To ndChannel.ChildNodes.Count - 1
            ndItem = ndChannel.ChildNodes(i)
            If (ndItem.Name = "item") Then

                Dim item As New RSSItem(ndItem.Item("title").ChildNodes(0).InnerText, ndItem.Item("link").ChildNodes(0).InnerText)
                'drpDNNVersions.Items.Add(item)

            End If
        Next

    End Sub

    Private Sub hypSite_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles hypSite.LinkClicked

        Dim strAlias As String = txtTargetSiteAlias.Text
        Dim url As String = ""
        If _mode = "create" Then
            url = String.Format("http://{0}/install/install.aspx?mode=install", strAlias)
        Else
            url = String.Format("http://{0}", strAlias)
        End If

        Process.Start(url)

    End Sub
End Class
