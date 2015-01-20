
Imports System.Collections.Generic
Imports System.Text
Imports System.DirectoryServices
Imports DNNTool.Exceptions

Namespace Entities
    Public Class IISWebVirturalDir
        ' Directory entry for this dir
        Private _entry As DirectoryEntry = Nothing
        Friend Const IIsVirtualDir As String = "IIsWebVirtualDir"


        ''' <summary>
        ''' Internal this constructor so that user of this dll can not create a instance of IISWebVirtualDir directly.
        ''' To get a instance of IISWebVirtualDir, please use IISWebVirtualDir.OpenSubVirtualDir or IISWebVirtualDir.CreateSubVirtualDir.
        ''' </summary>
        ''' <param name="entry"></param>
        Friend Sub New(entry As DirectoryEntry)
            Me._entry = entry
        End Sub


#Region "Properties"

        ''' <summary>
        ''' Get or set the path of this virtual directory
        ''' </summary>
        Public Property Path() As String
            Get
                Return Me._entry.Properties("path")(0).ToString()
            End Get
            Set(value As String)
                Me._entry.Properties("path")(0) = value
                Me._entry.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Get name of this virtual path.
        ''' </summary>
        Public ReadOnly Property Name() As String
            Get
                Return Me._entry.Name
            End Get
        End Property


#End Region

#Region "Operations"

        ''' <summary>
        ''' Check whether a virtual directory exists.
        ''' </summary>
        ''' <param name="name">Name of dir checked</param>
        ''' <returns>true if exist. Otherwise false.</returns>
        Public Function ExistVirtualDir(name As String) As Boolean
            If Me.FindSubEntry(name) Is Nothing Then
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Create a sub virtual directory
        ''' </summary>
        ''' <param name="name">Name of the sub virtual directory to be created.</param>
        ''' <param name="path">Path of the sub virtual directory.</param>
        ''' <param name="appPool">
        ''' Application pool. Application pool with this name would be created if not exist. 
        ''' Use string.Empty or null to this parameter if you don't want to use a application pool.
        ''' </param>
        ''' <returns>A IISWebVirtualDir if created. Otherwise  null.</returns>
        Public Function CreateSubVirtualDir(name As String, path As String, appPool As String) As IISWebVirturalDir
            ' already exist
            If Me.ExistVirtualDir(name) Then
                Throw New VirtualDirAlreadyExistException(Me._entry, path)
            End If

            ' validate path
            If System.IO.Directory.Exists(path) = False Then
                Throw New DirNotFoundException(path)
            End If


            Dim entry As DirectoryEntry = Me._entry.Children.Add(name, IIsVirtualDir)
            entry.Properties("path").Clear()
            entry.Properties("path").Add(path)

            ' create application
            If String.IsNullOrEmpty(appPool) Then
                entry.Invoke("appCreate", 0)
            Else
                ' use application pool
                entry.Invoke("appCreate3", 0, appPool, True)
            End If

            entry.Properties("AppFriendlyName").Clear()
            entry.Properties("AppIsolated").Clear()
            entry.Properties("AccessFlags").Clear()
            entry.Properties("FrontPageWeb").Clear()
            entry.Properties("AppFriendlyName").Add(Me._entry.Name)
            entry.Properties("AppIsolated").Add(2)
            entry.Properties("AccessFlags").Add(513)
            entry.Properties("FrontPageWeb").Add(1)

            entry.CommitChanges()
            Return New IISWebVirturalDir(entry)
        End Function

        ''' <summary>
        ''' Create a virtual directory
        ''' </summary>
        ''' <param name="name">Name of the virtual directory</param>
        ''' <param name="path">Path of the virtual directory</param>
        ''' <returns>A IISWebVirtualDir instance if succeed. Otherwise false.</returns>
        Public Function CreateSubVirtualDir(name As String, path As String) As IISWebVirturalDir
            Return CreateSubVirtualDir(name, path, Nothing)
        End Function

        ''' <summary>
        ''' Open a sub virtual directory
        ''' </summary>
        ''' <param name="name">Name of directory to be opened. Case insensitive.</param>
        ''' <returns>A IISWebVirtualDir instance if open successfully done.Otherwise null.</returns>
        Public Function OpenSubVirtualDir(name As String) As IISWebVirturalDir
            Dim entry As DirectoryEntry = Me.FindSubEntry(name)

            If entry Is Nothing Then
                Return Nothing
            End If

            Return New IISWebVirturalDir(entry)
        End Function

        ''' <summary>
        ''' Enumerate sub virtual directorys
        ''' </summary>
        ''' <returns></returns>
        Public Function EnumSubVirtualDirs() As String()
            Dim ret As New List(Of String)()
            For Each entry As DirectoryEntry In Me._entry.Children
                If entry.SchemaClassName = IIsVirtualDir Then
                    ret.Add(entry.Name)
                End If
            Next

            Return ret.ToArray()
        End Function

        ''' <summary>
        ''' Delete a sub virtual directory
        ''' </summary>
        ''' <param name="name">Name of the sub virtual directory to be deleted</param>
        ''' <returns>true if successfully deleted. Otherwise false.</returns>
        Public Function DeleteSubVirtualDir(name As String) As Boolean
            Dim entry As DirectoryEntry = Me.FindSubEntry(name)

            If entry Is Nothing Then
                Return False
            End If

            entry.DeleteTree()

            Return True

        End Function

#Region "Script Map"

        ''' <summary>
        ''' add a script map for application
        ''' </summary>
        ''' <param name="name">".do" or something like this</param>
        ''' <param name="exefile">dll file</param>
        Public Function AddScriptMap(name As String, exefile As String) As Boolean
            Return Me.AddScriptMap(name, exefile, 1, "")
        End Function

        ''' <summary>
        ''' add script map for application
        ''' </summary>
        ''' <param name="name">".do" or something like this</param>
        ''' <param name="exefile">dll to be loaded</param>
        ''' <param name="mask">1 means check "script engine", 4 means check "check file exsit", can be added together</param>
        ''' <param name="limitString">limit string</param>
        ''' <returns></returns>
        Public Function AddScriptMap(name As String, exefile As String, mask As Integer, limitString As String) As Boolean
            ' validate exefile
            If System.IO.File.Exists(exefile) = False Then
                Throw New FileNotFoundException(exefile)
            End If

            ' validate name
            If name.IndexOf(".") <> 0 Then
                name = Convert.ToString(".") & name
            End If
            Dim oldMap As PropertyValueCollection = Me._entry.Properties("ScriptMaps")

            ' check if exsit
            For i As Integer = 0 To oldMap.Count - 1
                Dim mapFile As String = oldMap(i).ToString()
                ' already exsit
                If mapFile.IndexOf(name) = 0 Then
                    Return False
                End If
            Next

            ' add
            Dim newMap As String = Convert.ToString(name & Convert.ToString(",")) & exefile
            newMap += "," + mask + ","
            ' 1 & 4 means the two options
            newMap += limitString
            Me._entry.Properties("ScriptMaps").Add(newMap)
            Me._entry.CommitChanges()
            Return True
        End Function

#End Region

#End Region

#Region "internal utils"

        Protected Function FindSubEntry(name As String) As DirectoryEntry
            Dim ret As DirectoryEntry = Nothing
            For Each entry As DirectoryEntry In Me._entry.Children
                If entry.SchemaClassName = IIsVirtualDir AndAlso entry.Name.ToLower() = name.ToLower() Then
                    ret = entry
                End If
            Next

            Return ret
        End Function

#End Region

    End Class
End Namespace


