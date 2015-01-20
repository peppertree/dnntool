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

        Dim loadControl As New ucLoad
        Me.ctlContainer.Panel2.Controls.Clear()
        Me.ctlContainer.Panel2.Controls.Add(loadControl)

    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Dim homeControl As New ucLoad
        Me.ctlContainer.Panel2.Controls.Clear()
        Me.ctlContainer.Panel2.Controls.Add(homeControl)
    End Sub

    Private Sub btnCloneWebsite_Click(sender As Object, e As EventArgs) Handles btnCloneWebsite.Click
        Dim cloneControl As New ucClone
        Me.ctlContainer.Panel2.Controls.Clear()
        Me.ctlContainer.Panel2.Controls.Add(cloneControl)
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        Dim usersControl As New ucUsers
        Me.ctlContainer.Panel2.Controls.Clear()
        Me.ctlContainer.Panel2.Controls.Add(usersControl)
    End Sub

    Private Sub btnSite_Click(sender As Object, e As EventArgs) Handles btnSite.Click
        Dim siteControl As New ucSite
        Me.ctlContainer.Panel2.Controls.Clear()
        Me.ctlContainer.Panel2.Controls.Add(siteControl)
    End Sub

#End Region

#Region "Private Methods"


#End Region


End Class
