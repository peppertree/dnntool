
Imports System.Collections.Generic
Imports System.Text
Imports System.DirectoryServices

Namespace Exceptions
    Public Class VirtualDirAlreadyExistException
        Inherits Exception
        Private _dir As String = ""

        Public Sub New(entry As DirectoryEntry, vDir As String)
            Me._dir = entry.Path
            If Me._dir(Me._dir.Length - 1) <> "/"c Then
                Me._dir = Me._dir & Convert.ToString("/")
            End If

            Me._dir = Me._dir & vDir
        End Sub

        Public Overrides ReadOnly Property Message() As String
            Get
                Dim msg As String = Convert.ToString("Virtual Dir already exist:") & Me._dir
                Return msg
            End Get
        End Property
    End Class
End Namespace

