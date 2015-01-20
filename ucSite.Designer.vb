<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSite
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ctlTargetSitePort = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTargetDatabaseName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTargetSiteAlias = New System.Windows.Forms.TextBox()
        Me.ctlCloneProgress = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTargetSiteName = New System.Windows.Forms.TextBox()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnSelectClone = New System.Windows.Forms.Button()
        Me.btnSelectInstallation = New System.Windows.Forms.Button()
        Me.txtConnection = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnTargetDir = New System.Windows.Forms.Button()
        Me.ctlSelectArchive = New System.Windows.Forms.OpenFileDialog()
        Me.ctlSelectInstallation = New System.Windows.Forms.OpenFileDialog()
        Me.ctlSelectTargetDir = New System.Windows.Forms.FolderBrowserDialog()
        Me.Information = New System.Windows.Forms.GroupBox()
        Me.lblSiteConnString = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTargetDir = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblArchive = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnProcessArchive = New System.Windows.Forms.Button()
        Me.CloneArchiveProcessor = New System.ComponentModel.BackgroundWorker()
        Me.InstallFileProcessor = New System.ComponentModel.BackgroundWorker()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.CreateSiteProcessor = New System.ComponentModel.BackgroundWorker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtHostusername = New System.Windows.Forms.TextBox()
        Me.txtHostpassword = New System.Windows.Forms.TextBox()
        Me.hypSite = New System.Windows.Forms.LinkLabel()
        CType(Me.ctlTargetSitePort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Information.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(591, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This form allows you to create a DNN site locally. You can either create the site" & _
    " from scratch or from a previously cloned site."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(571, 133)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Port:"
        '
        'ctlTargetSitePort
        '
        Me.ctlTargetSitePort.Location = New System.Drawing.Point(574, 149)
        Me.ctlTargetSitePort.Name = "ctlTargetSitePort"
        Me.ctlTargetSitePort.Size = New System.Drawing.Size(163, 20)
        Me.ctlTargetSitePort.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Database Name:"
        '
        'txtTargetDatabaseName
        '
        Me.txtTargetDatabaseName.Location = New System.Drawing.Point(28, 221)
        Me.txtTargetDatabaseName.Name = "txtTargetDatabaseName"
        Me.txtTargetDatabaseName.Size = New System.Drawing.Size(166, 20)
        Me.txtTargetDatabaseName.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(298, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Site Alias:"
        '
        'txtTargetSiteAlias
        '
        Me.txtTargetSiteAlias.Location = New System.Drawing.Point(301, 149)
        Me.txtTargetSiteAlias.Name = "txtTargetSiteAlias"
        Me.txtTargetSiteAlias.Size = New System.Drawing.Size(163, 20)
        Me.txtTargetSiteAlias.TabIndex = 16
        '
        'ctlCloneProgress
        '
        Me.ctlCloneProgress.Location = New System.Drawing.Point(25, 341)
        Me.ctlCloneProgress.Name = "ctlCloneProgress"
        Me.ctlCloneProgress.Size = New System.Drawing.Size(712, 23)
        Me.ctlCloneProgress.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Name the new site:"
        '
        'txtTargetSiteName
        '
        Me.txtTargetSiteName.Location = New System.Drawing.Point(28, 149)
        Me.txtTargetSiteName.Name = "txtTargetSiteName"
        Me.txtTargetSiteName.Size = New System.Drawing.Size(166, 20)
        Me.txtTargetSiteName.TabIndex = 13
        '
        'btnCreate
        '
        Me.btnCreate.Enabled = False
        Me.btnCreate.Location = New System.Drawing.Point(662, 414)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 22
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnSelectClone
        '
        Me.btnSelectClone.Location = New System.Drawing.Point(28, 81)
        Me.btnSelectClone.Name = "btnSelectClone"
        Me.btnSelectClone.Size = New System.Drawing.Size(163, 23)
        Me.btnSelectClone.TabIndex = 23
        Me.btnSelectClone.Text = "Select cloned Archive"
        Me.btnSelectClone.UseVisualStyleBackColor = True
        '
        'btnSelectInstallation
        '
        Me.btnSelectInstallation.Location = New System.Drawing.Point(301, 82)
        Me.btnSelectInstallation.Name = "btnSelectInstallation"
        Me.btnSelectInstallation.Size = New System.Drawing.Size(163, 23)
        Me.btnSelectInstallation.TabIndex = 24
        Me.btnSelectInstallation.Text = "Select DNN Installation File"
        Me.btnSelectInstallation.UseVisualStyleBackColor = True
        '
        'txtConnection
        '
        Me.txtConnection.Location = New System.Drawing.Point(301, 221)
        Me.txtConnection.Name = "txtConnection"
        Me.txtConnection.Size = New System.Drawing.Size(436, 20)
        Me.txtConnection.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(298, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Connection String:"
        '
        'btnTargetDir
        '
        Me.btnTargetDir.Enabled = False
        Me.btnTargetDir.Location = New System.Drawing.Point(574, 81)
        Me.btnTargetDir.Name = "btnTargetDir"
        Me.btnTargetDir.Size = New System.Drawing.Size(163, 23)
        Me.btnTargetDir.TabIndex = 27
        Me.btnTargetDir.Text = "Select Website Directory"
        Me.btnTargetDir.UseVisualStyleBackColor = True
        '
        'ctlSelectArchive
        '
        Me.ctlSelectArchive.FileName = "OpenFileDialog1"
        '
        'ctlSelectInstallation
        '
        Me.ctlSelectInstallation.FileName = "OpenFileDialog2"
        '
        'Information
        '
        Me.Information.Controls.Add(Me.lblSiteConnString)
        Me.Information.Controls.Add(Me.Label10)
        Me.Information.Controls.Add(Me.lblVersion)
        Me.Information.Controls.Add(Me.Label9)
        Me.Information.Controls.Add(Me.lblMode)
        Me.Information.Controls.Add(Me.Label8)
        Me.Information.Controls.Add(Me.lblTargetDir)
        Me.Information.Controls.Add(Me.Label7)
        Me.Information.Controls.Add(Me.lblArchive)
        Me.Information.Controls.Add(Me.Label3)
        Me.Information.Location = New System.Drawing.Point(28, 484)
        Me.Information.Name = "Information"
        Me.Information.Size = New System.Drawing.Size(709, 208)
        Me.Information.TabIndex = 28
        Me.Information.TabStop = False
        Me.Information.Text = "Information"
        '
        'lblSiteConnString
        '
        Me.lblSiteConnString.AutoSize = True
        Me.lblSiteConnString.Location = New System.Drawing.Point(145, 168)
        Me.lblSiteConnString.Name = "lblSiteConnString"
        Me.lblSiteConnString.Size = New System.Drawing.Size(24, 13)
        Me.lblSiteConnString.TabIndex = 9
        Me.lblSiteConnString.Text = "n/a"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Site ConnectionString:"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(145, 138)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(24, 13)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "n/a"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "DNN Version"
        '
        'lblMode
        '
        Me.lblMode.AutoSize = True
        Me.lblMode.Location = New System.Drawing.Point(145, 108)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(46, 13)
        Me.lblMode.TabIndex = 5
        Me.lblMode.Text = "new site"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Mode:"
        '
        'lblTargetDir
        '
        Me.lblTargetDir.AutoSize = True
        Me.lblTargetDir.Location = New System.Drawing.Point(145, 76)
        Me.lblTargetDir.Name = "lblTargetDir"
        Me.lblTargetDir.Size = New System.Drawing.Size(24, 13)
        Me.lblTargetDir.TabIndex = 3
        Me.lblTargetDir.Text = "n/a"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Target Directory:"
        '
        'lblArchive
        '
        Me.lblArchive.AutoSize = True
        Me.lblArchive.Location = New System.Drawing.Point(145, 43)
        Me.lblArchive.Name = "lblArchive"
        Me.lblArchive.Size = New System.Drawing.Size(24, 13)
        Me.lblArchive.TabIndex = 1
        Me.lblArchive.Text = "n/a"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Archive:"
        '
        'btnProcessArchive
        '
        Me.btnProcessArchive.Enabled = False
        Me.btnProcessArchive.Location = New System.Drawing.Point(529, 414)
        Me.btnProcessArchive.Name = "btnProcessArchive"
        Me.btnProcessArchive.Size = New System.Drawing.Size(97, 23)
        Me.btnProcessArchive.TabIndex = 29
        Me.btnProcessArchive.Text = "Process Archive"
        Me.btnProcessArchive.UseVisualStyleBackColor = True
        '
        'CloneArchiveProcessor
        '
        Me.CloneArchiveProcessor.WorkerReportsProgress = True
        '
        'InstallFileProcessor
        '
        Me.InstallFileProcessor.WorkerReportsProgress = True
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(25, 371)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(103, 13)
        Me.lblResult.TabIndex = 30
        Me.lblResult.Text = "Select archive first..."
        '
        'CreateSiteProcessor
        '
        Me.CreateSiteProcessor.WorkerReportsProgress = True
        Me.CreateSiteProcessor.WorkerSupportsCancellation = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(25, 266)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Host username:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(301, 266)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Host password:"
        '
        'txtHostusername
        '
        Me.txtHostusername.Location = New System.Drawing.Point(28, 291)
        Me.txtHostusername.Name = "txtHostusername"
        Me.txtHostusername.Size = New System.Drawing.Size(163, 20)
        Me.txtHostusername.TabIndex = 33
        '
        'txtHostpassword
        '
        Me.txtHostpassword.Location = New System.Drawing.Point(301, 290)
        Me.txtHostpassword.Name = "txtHostpassword"
        Me.txtHostpassword.Size = New System.Drawing.Size(163, 20)
        Me.txtHostpassword.TabIndex = 34
        '
        'hypSite
        '
        Me.hypSite.AutoSize = True
        Me.hypSite.Enabled = False
        Me.hypSite.Location = New System.Drawing.Point(28, 423)
        Me.hypSite.Name = "hypSite"
        Me.hypSite.Size = New System.Drawing.Size(47, 13)
        Me.hypSite.TabIndex = 35
        Me.hypSite.TabStop = True
        Me.hypSite.Text = "Visit Site"
        '
        'ucSite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.hypSite)
        Me.Controls.Add(Me.txtHostpassword)
        Me.Controls.Add(Me.txtHostusername)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.btnProcessArchive)
        Me.Controls.Add(Me.Information)
        Me.Controls.Add(Me.btnTargetDir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtConnection)
        Me.Controls.Add(Me.btnSelectInstallation)
        Me.Controls.Add(Me.btnSelectClone)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ctlTargetSitePort)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTargetDatabaseName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTargetSiteAlias)
        Me.Controls.Add(Me.ctlCloneProgress)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTargetSiteName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucSite"
        Me.Size = New System.Drawing.Size(1043, 745)
        CType(Me.ctlTargetSitePort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Information.ResumeLayout(False)
        Me.Information.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ctlTargetSitePort As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTargetDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTargetSiteAlias As System.Windows.Forms.TextBox
    Friend WithEvents ctlCloneProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTargetSiteName As System.Windows.Forms.TextBox
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnSelectClone As System.Windows.Forms.Button
    Friend WithEvents btnSelectInstallation As System.Windows.Forms.Button
    Friend WithEvents txtConnection As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnTargetDir As System.Windows.Forms.Button
    Friend WithEvents ctlSelectArchive As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ctlSelectInstallation As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ctlSelectTargetDir As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Information As System.Windows.Forms.GroupBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTargetDir As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblArchive As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnProcessArchive As System.Windows.Forms.Button
    Friend WithEvents CloneArchiveProcessor As System.ComponentModel.BackgroundWorker
    Friend WithEvents InstallFileProcessor As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents lblSiteConnString As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CreateSiteProcessor As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtHostusername As System.Windows.Forms.TextBox
    Friend WithEvents txtHostpassword As System.Windows.Forms.TextBox
    Friend WithEvents hypSite As System.Windows.Forms.LinkLabel

End Class
