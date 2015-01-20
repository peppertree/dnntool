
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.DirectoryServices
Imports DNNTool.Exceptions

Namespace Entities
    Public Enum IISWebsiteStatus As Integer
        Starting = 1
        Started = 2
        Stopping = 3
        Stopped = 4
        Pausing = 5
        Paused = 6
        Continuign = 7
    End Enum

    ''' <summary>
    ''' IISWebsite is a class to manage websites on a IIS server. You can not create
    ''' a IISWebsite instance directly with a IISWebsite constructor.
    ''' 
    ''' To get a IISWebsite instance, call IISWebsite.OpenWebsite to open an existing website or
    ''' IISWebsite.CreateWebsite to create a new website. 
    ''' 
    ''' Both of these two methods would return a instance of IISWebsite so that you can use
    ''' this instance to handle your website.
    ''' 
    ''' Author: luckzj
    ''' Time  : 27/June. 2010
    ''' contact: luckzj12@163.com
    ''' website: http://www.soft-bin.com
    ''' copy right (c) luckzj. All rights reserved
    ''' </summary>
    Public Class IISWebsite
        ' website entry
        Private websiteEntry As DirectoryEntry = Nothing
        Friend Const IIsWebServer As String = "IIsWebServer"

        ''' <summary>
        ''' Protect this constructor so that user can not create a IISWebsite instance directly.
        ''' To get IISWebsite instance, please use IISWebsite.OpenWebsite or IISWebsite.CreateWebsite
        ''' </summary>
        ''' <param name="Server"></param>
        Protected Sub New(Server As DirectoryEntry)
            websiteEntry = Server
        End Sub


#Region "Properties"

        ''' <summary>
        ''' get or set name of this website
        ''' </summary>
        Public Property Name() As String
            Get
                Return Me.websiteEntry.Properties("ServerComment")(0).ToString()
            End Get
            Set(value As String)
                Me.websiteEntry.Properties("ServerComment")(0) = value
                Me.websiteEntry.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' get or set website port
        ''' </summary>
        Public Property Port() As Integer
            Get
                Dim binding As String = Me.websiteEntry.Properties("Serverbindings")(0).ToString()
                binding = binding.Substring(1)
                binding = binding.Substring(0, binding.IndexOf(":"))
                Return Convert.ToInt32(binding)
            End Get
            Set(value As Integer)
                Me.websiteEntry.Properties("Serverbindings")(0) = ":" & value.ToString & ":" & Hostheader
                Me.websiteEntry.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' get or set website port
        ''' </summary>
        Public Property Hostheader() As String
            Get
                Dim binding As String = Me.websiteEntry.Properties("Serverbindings")(0).ToString()
                binding = binding.Substring(1)
                binding = binding.Substring(binding.IndexOf(":") + 1)
                Return binding
            End Get
            Set(value As String)
                Me.websiteEntry.Properties("Serverbindings")(0) = ":" & Port.ToString & ":" & value
                Me.websiteEntry.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Root path
        ''' </summary>
        Public ReadOnly Property Root() As IISWebVirturalDir
            Get
                For Each entry As DirectoryEntry In websiteEntry.Children
                    If entry.SchemaClassName = IISWebVirturalDir.IIsVirtualDir Then
                        Return New IISWebVirturalDir(entry)
                    End If
                Next

                Throw New WebsiteWithoutRootException(Me.Name)
            End Get
        End Property

        ''' <summary>
        ''' Get iis website Status
        ''' </summary>
        Public ReadOnly Property Status() As IISWebsiteStatus
            Get
                Return CType(Me.websiteEntry.InvokeGet("Status"), IISWebsiteStatus)
            End Get
        End Property

#End Region

#Region "Operations"

        ''' <summary>
        ''' Start this website
        ''' </summary>
        Public Sub Start()
            Me.websiteEntry.Invoke("Start")
        End Sub

        ''' <summary>
        ''' Stop this website
        ''' </summary>
        Public Sub [Stop]()
            Me.websiteEntry.Invoke("Stop")
        End Sub

        ''' <summary>
        ''' Parse this website
        ''' </summary>
        Public Sub Parse()
            Me.websiteEntry.Invoke("Pause")
        End Sub

        ''' <summary>
        ''' Continue to run this website.
        ''' </summary>
        Public Sub [Continue]()
            Me.websiteEntry.Invoke("Continue")
        End Sub

#End Region

#Region "Static Methods"

        ''' <summary>
        ''' create a new website
        ''' </summary>
        ''' <param name="name">website name</param>
        ''' <param name="port">website port</param>
        ''' <param name="rootPath">root path</param>
        ''' <returns></returns>
        Public Shared Function CreateWebsite(name As String, port As Integer, rootPath As String) As IISWebsite
            Return IISWebsite.CreateWebsite(name, port, rootPath, Nothing, Nothing)
        End Function

        Public Shared Function CreateWebsite(name As String, port As Integer, rootPath As String, appPool As String, hostHeader As String) As IISWebsite
            ' validate root path
            If System.IO.Directory.Exists(rootPath) = False Then
                Throw New DirNotFoundException(rootPath)
            End If

            ' get directory service
            Dim Services As New DirectoryEntry("IIS://localhost/W3SVC")

            ' get server name (index)
            Dim index As Integer = 0
            For Each server As DirectoryEntry In Services.Children
                If server.SchemaClassName = "IIsWebServer" Then
                    If server.Properties("ServerComment")(0).ToString() = name Then
                        Throw New Exception((Convert.ToString("website:") & name) & " already exsit.")
                    End If

                    If Convert.ToInt32(server.Name) > index Then
                        index = Convert.ToInt32(server.Name)
                    End If
                End If
            Next
            index &= 1
            ' new index created
            ' create website
            Dim objServer As DirectoryEntry = Services.Children.Add(index.ToString(), IIsWebServer)
            objServer.Properties("ServerComment").Clear()
            objServer.Properties("ServerComment").Add(name)
            objServer.Properties("Serverbindings").Clear()
            If Not String.IsNullOrEmpty(hostHeader) Then
                objServer.Properties("Serverbindings").Add(":" & port & ":" & hostHeader)
            Else
                objServer.Properties("Serverbindings").Add(":" & port & ":")
            End If


            ' create ROOT for website
            Dim root As DirectoryEntry = objServer.Children.Add("ROOT", IISWebVirturalDir.IIsVirtualDir)
            root.Properties("path").Clear()
            root.Properties("path").Add(rootPath)

            ' create application
            If String.IsNullOrEmpty(appPool) Then
                root.Invoke("appCreate", 0)
            Else
                ' use application pool
                root.Invoke("appCreate3", 0, appPool, True)
            End If

            root.Properties("AppFriendlyName").Clear()
            root.Properties("AppIsolated").Clear()
            root.Properties("AccessFlags").Clear()
            root.Properties("FrontPageWeb").Clear()
            root.Properties("AppFriendlyName").Add(root.Name)
            root.Properties("AppIsolated").Add(2)
            root.Properties("AccessFlags").Add(513)
            root.Properties("FrontPageWeb").Add(1)

            ' commit changes
            root.CommitChanges()
            objServer.CommitChanges()

            ' return the newly created website
            Dim website As New IISWebsite(objServer)
            Return website
        End Function

        ''' <summary>
        ''' open a website object
        ''' </summary>
        ''' <param name="name">name of the website to be opened</param>
        ''' <returns>IISWebsite object</returns>
        Public Shared Function OpenWebsite(name As String) As IISWebsite
            ' get directory service
            Dim Services As New DirectoryEntry("IIS://localhost/W3SVC")
            Dim ie As IEnumerator = Services.Children.GetEnumerator()
            Dim Server As DirectoryEntry = Nothing

            ' find iis website
            While ie.MoveNext()
                Server = DirectCast(ie.Current, DirectoryEntry)
                If Server.SchemaClassName = "IIsWebServer" Then
                    ' "ServerComment" means name
                    If Server.Properties("ServerComment")(0).ToString() = name Then
                        Return New IISWebsite(Server)
                        Exit While
                    End If
                End If
            End While

            Return Nothing
        End Function

        ''' <summary>
        ''' Get exsited websites
        ''' </summary>
        Public Shared ReadOnly Property ExistedWebsites() As String()
            Get
                Dim ret As New List(Of String)()

                ' get directory service
                Dim Services As New DirectoryEntry("IIS://localhost/W3SVC")
                Dim ie As IEnumerator = Services.Children.GetEnumerator()
                Dim Server As DirectoryEntry = Nothing

                ' find iis website
                While ie.MoveNext()
                    Server = DirectCast(ie.Current, DirectoryEntry)
                    If Server.SchemaClassName = "IIsWebServer" Then
                        ' "ServerComment" means name

                        ret.Add(Server.Properties("ServerComment")(0).ToString())
                    End If
                End While

                Return ret.ToArray()
            End Get
        End Property

        ''' <summary>
        ''' Delete a website service
        ''' </summary>
        ''' <param name="name">the name of the website</param>
        Public Shared Function DeleteWebsite(name As String) As Boolean
            Dim website As IISWebsite = IISWebsite.OpenWebsite(name)
            If website Is Nothing Then
                Return False
            End If

            website.websiteEntry.DeleteTree()
            Return True
        End Function

        Public Shared Function Exists(name As String) As Boolean
            ' get directory service
            Dim Services As New DirectoryEntry("IIS://localhost/W3SVC")
            Dim ie As IEnumerator = Services.Children.GetEnumerator()
            Dim Server As DirectoryEntry = Nothing

            ' find iis website
            While ie.MoveNext()
                Server = DirectCast(ie.Current, DirectoryEntry)
                If Server.SchemaClassName = "IIsWebServer" Then
                    ' "ServerComment" means name
                    If Server.Properties("ServerComment")(0).ToString() = name Then
                        Return True
                        Exit While
                    End If
                End If
            End While

            Return False
        End Function

#End Region
    End Class

End Namespace



