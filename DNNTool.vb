Imports System.DirectoryServices
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web
Imports Microsoft.ApplicationBlocks.Data
Imports DNNTool.Entities
Imports DNNTool.Services
Imports System.ComponentModel

Public Class DNNTool

    Private _srcConnectionString As String = ""
    Private _srcSiteName As String = ""
    Private _srcSiteAlias As String = ""
    Private _srcSitePath As String = ""
    Private _srcDatabaseName As String = ""
    Private _srcSitePort As Integer = 80

    Private _connection As SqlConnection = Nothing

#Region "Event Handlers"

    Private Sub DNNTools_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim loadControl As New ucLoad
            Me.ctlContainer.Panel2.Controls.Clear()
            Me.ctlContainer.Panel2.Controls.Add(loadControl)
        Catch ex As System.Runtime.InteropServices.COMException
            MsgBox("This application must be run in an administrative context. Right click on the application and select ""run as administrator""")
        End Try
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Try
            Dim homeControl As New ucLoad
            Me.ctlContainer.Panel2.Controls.Clear()
            Me.ctlContainer.Panel2.Controls.Add(homeControl)
        Catch ex As System.Runtime.InteropServices.COMException
            MsgBox("This application must be run in an administrative context. Right click on the application and select ""run as administrator""")
        End Try
    End Sub

    Private Sub btnCloneWebsite_Click(sender As Object, e As EventArgs) Handles btnCloneWebsite.Click
        Try
            Dim cloneControl As New ucClone
            Me.ctlContainer.Panel2.Controls.Clear()
            Me.ctlContainer.Panel2.Controls.Add(cloneControl)
        Catch ex As System.Runtime.InteropServices.COMException
            MsgBox("This application must be run in an administrative context. Right click on the application and select ""run as administrator""")
        End Try
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        Try
            Dim usersControl As New ucUsers
            Me.ctlContainer.Panel2.Controls.Clear()
            Me.ctlContainer.Panel2.Controls.Add(usersControl)
        Catch ex As System.Runtime.InteropServices.COMException
            MsgBox("This application must be run in an administrative context. Right click on the application and select ""run as administrator""")
        End Try
    End Sub

    Private Sub btnSite_Click(sender As Object, e As EventArgs) Handles btnSite.Click
        Try
            Dim siteControl As New ucSite
            Me.ctlContainer.Panel2.Controls.Clear()
            Me.ctlContainer.Panel2.Controls.Add(siteControl)
        Catch ex As System.Runtime.InteropServices.COMException
            MsgBox("This application must be run in an administrative context. Right click on the application and select ""run as administrator""")
        End Try
    End Sub

#End Region

#Region "Private Methods"


#End Region


End Class
