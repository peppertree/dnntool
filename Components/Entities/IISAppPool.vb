
Imports System.Collections.Generic
Imports System.Text
Imports System.DirectoryServices

Namespace Entities
    Public Class IISAppPool
        Private _entry As DirectoryEntry = Nothing

        ''' <summary>
        ''' Private constructor. Anyone wants to Create an instance of IISAppPool should call
        ''' OpenAppPool
        ''' </summary>
        ''' <param name="dir"></param>
        Protected Sub New(entry As DirectoryEntry)
            Me._entry = entry
        End Sub

        ''' <summary>
        ''' Get name of the App Pool
        ''' </summary>
        Public ReadOnly Property Name() As String
            Get
                Dim name__1 As String = _entry.Name
                Return name__1
            End Get
        End Property

        ''' <summary>
        ''' Start application pool.
        ''' </summary>
        Public Sub Start()
            Me._entry.Invoke("Start")
        End Sub

        ''' <summary>
        ''' Stop application pool.
        ''' </summary>
        Public Sub [Stop]()
            Me._entry.Invoke("Stop")
        End Sub

        ''' <summary>
        ''' Open a application pool and return an IISAppPool instance
        ''' </summary>
        ''' <param name="name">application pool name</param>
        ''' <returns>IISAppPool object</returns>
        Public Shared Function OpenAppPool(name As String) As IISAppPool
            Dim connectStr As String = "IIS://localhost/W3SVC/AppPools/"
            connectStr += name

            If IISAppPool.Exists(name) = False Then
                Return Nothing
            End If


            Dim entry As New DirectoryEntry(connectStr)
            Return New IISAppPool(entry)
        End Function

        ''' <summary>
        ''' create app pool
        ''' </summary>
        ''' <param name="name">the app pool to be created</param>
        ''' <returns>IISAppPool created if success, else null</returns>
        Public Shared Function CreateAppPool(name As String) As IISAppPool
            Dim Service As New DirectoryEntry("IIS://localhost/W3SVC/AppPools")
            For Each entry As DirectoryEntry In Service.Children
                If entry.Name.Trim().ToLower() = name.Trim().ToLower() Then
                    Return IISAppPool.OpenAppPool(name.Trim())
                End If
            Next

            ' create new app pool
            Dim appPool As DirectoryEntry = Service.Children.Add(name, "IIsApplicationPool")
            appPool.InvokeSet("ManagedPipelineMode", New Object() {0})
            appPool.CommitChanges()
            Service.CommitChanges()

            Return New IISAppPool(appPool)
        End Function

        ''' <summary>
        ''' if the app pool specified exsit
        ''' </summary>
        ''' <param name="name">name of app pool</param>
        ''' <returns>true if exsit, otherwise false</returns>
        Public Shared Function Exists(name As String) As Boolean
            Dim Service As New DirectoryEntry("IIS://localhost/W3SVC/AppPools")
            For Each entry As DirectoryEntry In Service.Children

                If entry.Name.Trim().ToLower() = name.Trim().ToLower() Then
                    Return True

                End If
            Next
            Return False

        End Function

        ''' <summary>
        ''' Delete an app pool
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Shared Function DeleteAppPool(name As String) As Boolean
            If IISAppPool.Exists(name) = False Then
                Return False
            End If

            Dim appPool As IISAppPool = IISAppPool.OpenAppPool(name)
            appPool._entry.DeleteTree()
            Return True
        End Function
    End Class
End Namespace


