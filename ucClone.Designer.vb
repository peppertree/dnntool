<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucClone
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.hypSite = New System.Windows.Forms.LinkLabel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ctlTargetSitePort = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTargetDatabaseName = New System.Windows.Forms.TextBox()
        Me.lblCloneResult = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTargetSiteAlias = New System.Windows.Forms.TextBox()
        Me.btnCloneCancel = New System.Windows.Forms.Button()
        Me.ctlCloneProgress = New System.Windows.Forms.ProgressBar()
        Me.btnCloneStart = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTargetSiteName = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.lblDatabasename = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblAlias = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblConnectionString = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblDNNVersion = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblSitePath = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.drpSiteForCloning = New System.Windows.Forms.ComboBox()
        Me.SiteCopyProcess = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.hypDownload = New System.Windows.Forms.LinkLabel()
        Me.lblArchiveResult = New System.Windows.Forms.Label()
        Me.ctlArchiveProcess = New System.Windows.Forms.ProgressBar()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnSelectDirectory = New System.Windows.Forms.Button()
        Me.CreateArchiveProcess = New System.ComponentModel.BackgroundWorker()
        Me.ctlFolderSelect = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ctlTargetSitePort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.hypSite)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.ctlTargetSitePort)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtTargetDatabaseName)
        Me.GroupBox3.Controls.Add(Me.lblCloneResult)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtTargetSiteAlias)
        Me.GroupBox3.Controls.Add(Me.btnCloneCancel)
        Me.GroupBox3.Controls.Add(Me.ctlCloneProgress)
        Me.GroupBox3.Controls.Add(Me.btnCloneStart)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtTargetSiteName)
        Me.GroupBox3.Location = New System.Drawing.Point(27, 150)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(397, 252)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Clone locally"
        '
        'hypSite
        '
        Me.hypSite.AutoSize = True
        Me.hypSite.Enabled = False
        Me.hypSite.Location = New System.Drawing.Point(317, 216)
        Me.hypSite.Name = "hypSite"
        Me.hypSite.Size = New System.Drawing.Size(53, 13)
        Me.hypSite.TabIndex = 13
        Me.hypSite.TabStop = True
        Me.hypSite.Text = "Visite Site"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(192, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Port:"
        '
        'ctlTargetSitePort
        '
        Me.ctlTargetSitePort.Location = New System.Drawing.Point(195, 99)
        Me.ctlTargetSitePort.Name = "ctlTargetSitePort"
        Me.ctlTargetSitePort.Size = New System.Drawing.Size(120, 20)
        Me.ctlTargetSitePort.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Database Name:"
        '
        'txtTargetDatabaseName
        '
        Me.txtTargetDatabaseName.Location = New System.Drawing.Point(23, 100)
        Me.txtTargetDatabaseName.Name = "txtTargetDatabaseName"
        Me.txtTargetDatabaseName.Size = New System.Drawing.Size(142, 20)
        Me.txtTargetDatabaseName.TabIndex = 9
        '
        'lblCloneResult
        '
        Me.lblCloneResult.AutoSize = True
        Me.lblCloneResult.Location = New System.Drawing.Point(26, 216)
        Me.lblCloneResult.Name = "lblCloneResult"
        Me.lblCloneResult.Size = New System.Drawing.Size(93, 13)
        Me.lblCloneResult.TabIndex = 8
        Me.lblCloneResult.Text = "Select a site first..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(192, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Site Alias:"
        '
        'txtTargetSiteAlias
        '
        Me.txtTargetSiteAlias.Location = New System.Drawing.Point(195, 51)
        Me.txtTargetSiteAlias.Name = "txtTargetSiteAlias"
        Me.txtTargetSiteAlias.Size = New System.Drawing.Size(175, 20)
        Me.txtTargetSiteAlias.TabIndex = 6
        '
        'btnCloneCancel
        '
        Me.btnCloneCancel.Enabled = False
        Me.btnCloneCancel.Location = New System.Drawing.Point(295, 182)
        Me.btnCloneCancel.Name = "btnCloneCancel"
        Me.btnCloneCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCloneCancel.TabIndex = 5
        Me.btnCloneCancel.Text = "Cancel"
        Me.btnCloneCancel.UseVisualStyleBackColor = True
        '
        'ctlCloneProgress
        '
        Me.ctlCloneProgress.Location = New System.Drawing.Point(23, 141)
        Me.ctlCloneProgress.Name = "ctlCloneProgress"
        Me.ctlCloneProgress.Size = New System.Drawing.Size(347, 23)
        Me.ctlCloneProgress.TabIndex = 4
        '
        'btnCloneStart
        '
        Me.btnCloneStart.Enabled = False
        Me.btnCloneStart.Location = New System.Drawing.Point(195, 182)
        Me.btnCloneStart.Name = "btnCloneStart"
        Me.btnCloneStart.Size = New System.Drawing.Size(75, 23)
        Me.btnCloneStart.TabIndex = 2
        Me.btnCloneStart.Text = "Clone"
        Me.btnCloneStart.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Name the new site:"
        '
        'txtTargetSiteName
        '
        Me.txtTargetSiteName.Location = New System.Drawing.Point(23, 51)
        Me.txtTargetSiteName.Name = "txtTargetSiteName"
        Me.txtTargetSiteName.Size = New System.Drawing.Size(142, 20)
        Me.txtTargetSiteName.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblPort)
        Me.GroupBox2.Controls.Add(Me.lblDatabasename)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.lblAlias)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblConnectionString)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblDNNVersion)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblSitePath)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(491, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(453, 311)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Site"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(123, 150)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(24, 13)
        Me.lblPort.TabIndex = 11
        Me.lblPort.Text = "n/a"
        '
        'lblDatabasename
        '
        Me.lblDatabasename.AutoSize = True
        Me.lblDatabasename.Location = New System.Drawing.Point(123, 99)
        Me.lblDatabasename.Name = "lblDatabasename"
        Me.lblDatabasename.Size = New System.Drawing.Size(24, 13)
        Me.lblDatabasename.TabIndex = 10
        Me.lblDatabasename.Text = "n/a"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Database:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(26, 150)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Port:"
        '
        'lblAlias
        '
        Me.lblAlias.AutoSize = True
        Me.lblAlias.Location = New System.Drawing.Point(123, 125)
        Me.lblAlias.Name = "lblAlias"
        Me.lblAlias.Size = New System.Drawing.Size(24, 13)
        Me.lblAlias.TabIndex = 7
        Me.lblAlias.Text = "n/a"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(26, 125)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Alias:"
        '
        'lblConnectionString
        '
        Me.lblConnectionString.AutoSize = True
        Me.lblConnectionString.Location = New System.Drawing.Point(123, 48)
        Me.lblConnectionString.Name = "lblConnectionString"
        Me.lblConnectionString.Size = New System.Drawing.Size(24, 13)
        Me.lblConnectionString.TabIndex = 5
        Me.lblConnectionString.Text = "n/a"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "ConnectionString:"
        '
        'lblDNNVersion
        '
        Me.lblDNNVersion.AutoSize = True
        Me.lblDNNVersion.Location = New System.Drawing.Point(123, 74)
        Me.lblDNNVersion.Name = "lblDNNVersion"
        Me.lblDNNVersion.Size = New System.Drawing.Size(24, 13)
        Me.lblDNNVersion.TabIndex = 3
        Me.lblDNNVersion.Text = "n/a"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "DNN Version:"
        '
        'lblSitePath
        '
        Me.lblSitePath.AutoSize = True
        Me.lblSitePath.Location = New System.Drawing.Point(123, 173)
        Me.lblSitePath.Name = "lblSitePath"
        Me.lblSitePath.Size = New System.Drawing.Size(24, 13)
        Me.lblSitePath.TabIndex = 1
        Me.lblSitePath.Text = "n/a"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "SitePath:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Select Site"
        '
        'drpSiteForCloning
        '
        Me.drpSiteForCloning.DisplayMember = "SiteName"
        Me.drpSiteForCloning.FormattingEnabled = True
        Me.drpSiteForCloning.Location = New System.Drawing.Point(27, 107)
        Me.drpSiteForCloning.Name = "drpSiteForCloning"
        Me.drpSiteForCloning.Size = New System.Drawing.Size(397, 21)
        Me.drpSiteForCloning.TabIndex = 14
        '
        'SiteCopyProcess
        '
        Me.SiteCopyProcess.WorkerReportsProgress = True
        Me.SiteCopyProcess.WorkerSupportsCancellation = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.hypDownload)
        Me.GroupBox1.Controls.Add(Me.lblArchiveResult)
        Me.GroupBox1.Controls.Add(Me.ctlArchiveProcess)
        Me.GroupBox1.Controls.Add(Me.btnStart)
        Me.GroupBox1.Controls.Add(Me.btnSelectDirectory)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 463)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 183)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Clone to Archive"
        '
        'hypDownload
        '
        Me.hypDownload.AutoSize = True
        Me.hypDownload.Enabled = False
        Me.hypDownload.Location = New System.Drawing.Point(315, 149)
        Me.hypDownload.Name = "hypDownload"
        Me.hypDownload.Size = New System.Drawing.Size(55, 13)
        Me.hypDownload.TabIndex = 4
        Me.hypDownload.TabStop = True
        Me.hypDownload.Text = "Download"
        '
        'lblArchiveResult
        '
        Me.lblArchiveResult.AutoSize = True
        Me.lblArchiveResult.Location = New System.Drawing.Point(26, 149)
        Me.lblArchiveResult.Name = "lblArchiveResult"
        Me.lblArchiveResult.Size = New System.Drawing.Size(138, 13)
        Me.lblArchiveResult.TabIndex = 3
        Me.lblArchiveResult.Text = "Select target directory first..."
        '
        'ctlArchiveProcess
        '
        Me.ctlArchiveProcess.Location = New System.Drawing.Point(23, 105)
        Me.ctlArchiveProcess.Name = "ctlArchiveProcess"
        Me.ctlArchiveProcess.Size = New System.Drawing.Size(347, 23)
        Me.ctlArchiveProcess.TabIndex = 2
        '
        'btnStart
        '
        Me.btnStart.Enabled = False
        Me.btnStart.Location = New System.Drawing.Point(195, 59)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(175, 23)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnSelectDirectory
        '
        Me.btnSelectDirectory.Enabled = False
        Me.btnSelectDirectory.Location = New System.Drawing.Point(23, 60)
        Me.btnSelectDirectory.Name = "btnSelectDirectory"
        Me.btnSelectDirectory.Size = New System.Drawing.Size(142, 23)
        Me.btnSelectDirectory.TabIndex = 0
        Me.btnSelectDirectory.Text = "Select Target Directory"
        Me.btnSelectDirectory.UseVisualStyleBackColor = True
        '
        'CreateArchiveProcess
        '
        Me.CreateArchiveProcess.WorkerReportsProgress = True
        Me.CreateArchiveProcess.WorkerSupportsCancellation = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(495, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "You may clone an existing site internally to your local IIS or to a zip archive f" & _
    "or useage on another server"
        '
        'ucClone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.drpSiteForCloning)
        Me.Name = "ucClone"
        Me.Size = New System.Drawing.Size(1416, 756)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ctlTargetSitePort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents hypSite As System.Windows.Forms.LinkLabel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ctlTargetSitePort As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTargetDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents lblCloneResult As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTargetSiteAlias As System.Windows.Forms.TextBox
    Friend WithEvents btnCloneCancel As System.Windows.Forms.Button
    Friend WithEvents ctlCloneProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents btnCloneStart As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTargetSiteName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents lblDatabasename As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblAlias As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblConnectionString As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblDNNVersion As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblSitePath As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents drpSiteForCloning As System.Windows.Forms.ComboBox
    Friend WithEvents SiteCopyProcess As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelectDirectory As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents CreateArchiveProcess As System.ComponentModel.BackgroundWorker
    Friend WithEvents hypDownload As System.Windows.Forms.LinkLabel
    Friend WithEvents lblArchiveResult As System.Windows.Forms.Label
    Friend WithEvents ctlArchiveProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents ctlFolderSelect As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
