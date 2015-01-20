<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DNNTool
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.ctlContainer = New System.Windows.Forms.SplitContainer()
        Me.btnSite = New System.Windows.Forms.Button()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.btnCloneWebsite = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        CType(Me.ctlContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctlContainer.Panel1.SuspendLayout()
        Me.ctlContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(578, 298)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(0, 13)
        Me.lblProcess.TabIndex = 8
        '
        'ctlContainer
        '
        Me.ctlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctlContainer.Location = New System.Drawing.Point(0, 0)
        Me.ctlContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.ctlContainer.MinimumSize = New System.Drawing.Size(100, 0)
        Me.ctlContainer.Name = "ctlContainer"
        '
        'ctlContainer.Panel1
        '
        Me.ctlContainer.Panel1.BackColor = System.Drawing.Color.Wheat
        Me.ctlContainer.Panel1.Controls.Add(Me.btnHome)
        Me.ctlContainer.Panel1.Controls.Add(Me.btnSite)
        Me.ctlContainer.Panel1.Controls.Add(Me.btnUsers)
        Me.ctlContainer.Panel1.Controls.Add(Me.btnCloneWebsite)
        '
        'ctlContainer.Panel2
        '
        Me.ctlContainer.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ctlContainer.Size = New System.Drawing.Size(1581, 804)
        Me.ctlContainer.SplitterDistance = 252
        Me.ctlContainer.TabIndex = 11
        '
        'btnSite
        '
        Me.btnSite.Location = New System.Drawing.Point(36, 287)
        Me.btnSite.Name = "btnSite"
        Me.btnSite.Size = New System.Drawing.Size(135, 34)
        Me.btnSite.TabIndex = 2
        Me.btnSite.Text = "Create New DNN"
        Me.btnSite.UseCompatibleTextRendering = True
        Me.btnSite.UseVisualStyleBackColor = True
        '
        'btnUsers
        '
        Me.btnUsers.Location = New System.Drawing.Point(36, 219)
        Me.btnUsers.Name = "btnUsers"
        Me.btnUsers.Size = New System.Drawing.Size(135, 34)
        Me.btnUsers.TabIndex = 1
        Me.btnUsers.Text = "Create Users"
        Me.btnUsers.UseVisualStyleBackColor = True
        '
        'btnCloneWebsite
        '
        Me.btnCloneWebsite.Location = New System.Drawing.Point(36, 150)
        Me.btnCloneWebsite.Name = "btnCloneWebsite"
        Me.btnCloneWebsite.Size = New System.Drawing.Size(135, 34)
        Me.btnCloneWebsite.TabIndex = 0
        Me.btnCloneWebsite.Text = "Clone Website"
        Me.btnCloneWebsite.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(36, 79)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(135, 34)
        Me.btnHome.TabIndex = 3
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'DNNTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(1581, 804)
        Me.Controls.Add(Me.ctlContainer)
        Me.Controls.Add(Me.lblProcess)
        Me.Name = "DNNTool"
        Me.Text = "DNN:tool"
        Me.ctlContainer.Panel1.ResumeLayout(False)
        CType(Me.ctlContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctlContainer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents ctlContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents btnCloneWebsite As System.Windows.Forms.Button
    Friend WithEvents btnUsers As System.Windows.Forms.Button
    Friend WithEvents btnSite As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button

End Class
