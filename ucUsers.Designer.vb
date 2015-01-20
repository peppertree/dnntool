<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucUsers
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
        Me.Label14 = New System.Windows.Forms.Label()
        Me.drpSiteForUserCreation = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCreateResult = New System.Windows.Forms.Label()
        Me.btnCreateAccountCancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ctlPortalId = New System.Windows.Forms.NumericUpDown()
        Me.ctlAccountsProgress = New System.Windows.Forms.ProgressBar()
        Me.chkCleanFirst = New System.Windows.Forms.CheckBox()
        Me.ctlNumberofAcounts = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCreateAccountStart = New System.Windows.Forms.Button()
        Me.UserCreateProcess = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ctlPortalId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ctlNumberofAcounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(657, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This form allwos you to bulk create user accounts in an existing dnn installation" & _
    ". Start by selecting the site you want to create accounts for."
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
        Me.GroupBox2.Location = New System.Drawing.Point(528, 106)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(453, 311)
        Me.GroupBox2.TabIndex = 17
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
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(32, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Select a site:"
        '
        'drpSiteForUserCreation
        '
        Me.drpSiteForUserCreation.DisplayMember = "SiteName"
        Me.drpSiteForUserCreation.FormattingEnabled = True
        Me.drpSiteForUserCreation.Location = New System.Drawing.Point(32, 106)
        Me.drpSiteForUserCreation.Name = "drpSiteForUserCreation"
        Me.drpSiteForUserCreation.Size = New System.Drawing.Size(397, 21)
        Me.drpSiteForUserCreation.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCreateResult)
        Me.GroupBox1.Controls.Add(Me.btnCreateAccountCancel)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ctlPortalId)
        Me.GroupBox1.Controls.Add(Me.ctlAccountsProgress)
        Me.GroupBox1.Controls.Add(Me.chkCleanFirst)
        Me.GroupBox1.Controls.Add(Me.ctlNumberofAcounts)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnCreateAccountStart)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 153)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 215)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create User Accounts"
        '
        'lblCreateResult
        '
        Me.lblCreateResult.AutoSize = True
        Me.lblCreateResult.Location = New System.Drawing.Point(23, 178)
        Me.lblCreateResult.Name = "lblCreateResult"
        Me.lblCreateResult.Size = New System.Drawing.Size(93, 13)
        Me.lblCreateResult.TabIndex = 9
        Me.lblCreateResult.Text = "Select a site first..."
        '
        'btnCreateAccountCancel
        '
        Me.btnCreateAccountCancel.Enabled = False
        Me.btnCreateAccountCancel.Location = New System.Drawing.Point(295, 144)
        Me.btnCreateAccountCancel.Name = "btnCreateAccountCancel"
        Me.btnCreateAccountCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCreateAccountCancel.TabIndex = 8
        Me.btnCreateAccountCancel.Text = "Cancel"
        Me.btnCreateAccountCancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PortalId:"
        '
        'ctlPortalId
        '
        Me.ctlPortalId.Location = New System.Drawing.Point(195, 56)
        Me.ctlPortalId.Name = "ctlPortalId"
        Me.ctlPortalId.Size = New System.Drawing.Size(37, 20)
        Me.ctlPortalId.TabIndex = 6
        '
        'ctlAccountsProgress
        '
        Me.ctlAccountsProgress.Location = New System.Drawing.Point(23, 95)
        Me.ctlAccountsProgress.Name = "ctlAccountsProgress"
        Me.ctlAccountsProgress.Size = New System.Drawing.Size(347, 23)
        Me.ctlAccountsProgress.TabIndex = 7
        '
        'chkCleanFirst
        '
        Me.chkCleanFirst.AutoSize = True
        Me.chkCleanFirst.Location = New System.Drawing.Point(238, 57)
        Me.chkCleanFirst.Name = "chkCleanFirst"
        Me.chkCleanFirst.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkCleanFirst.Size = New System.Drawing.Size(132, 17)
        Me.chkCleanFirst.TabIndex = 5
        Me.chkCleanFirst.Text = "cleanup user base first"
        Me.chkCleanFirst.UseVisualStyleBackColor = True
        '
        'ctlNumberofAcounts
        '
        Me.ctlNumberofAcounts.Location = New System.Drawing.Point(23, 56)
        Me.ctlNumberofAcounts.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.ctlNumberofAcounts.Name = "ctlNumberofAcounts"
        Me.ctlNumberofAcounts.Size = New System.Drawing.Size(120, 20)
        Me.ctlNumberofAcounts.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "How many accounts?"
        '
        'btnCreateAccountStart
        '
        Me.btnCreateAccountStart.Enabled = False
        Me.btnCreateAccountStart.Location = New System.Drawing.Point(195, 144)
        Me.btnCreateAccountStart.Name = "btnCreateAccountStart"
        Me.btnCreateAccountStart.Size = New System.Drawing.Size(75, 23)
        Me.btnCreateAccountStart.TabIndex = 0
        Me.btnCreateAccountStart.Text = "Create"
        Me.btnCreateAccountStart.UseVisualStyleBackColor = True
        '
        'UserCreateProcess
        '
        Me.UserCreateProcess.WorkerReportsProgress = True
        Me.UserCreateProcess.WorkerSupportsCancellation = True
        '
        'ucUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.drpSiteForUserCreation)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucUsers"
        Me.Size = New System.Drawing.Size(1198, 744)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ctlPortalId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ctlNumberofAcounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents drpSiteForUserCreation As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCreateResult As System.Windows.Forms.Label
    Friend WithEvents btnCreateAccountCancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ctlPortalId As System.Windows.Forms.NumericUpDown
    Friend WithEvents ctlAccountsProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents chkCleanFirst As System.Windows.Forms.CheckBox
    Friend WithEvents ctlNumberofAcounts As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCreateAccountStart As System.Windows.Forms.Button
    Friend WithEvents UserCreateProcess As System.ComponentModel.BackgroundWorker

End Class
