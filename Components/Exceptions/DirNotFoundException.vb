
Imports System.Collections.Generic
Imports System.Text

Namespace Exceptions
    ''' <summary>
    ''' Directory not found or illegal.
    ''' </summary>
    Public Class DirNotFoundException
        Inherits Exception
        Private _dir As String = ""

        Public Sub New(dir As String)
            Me._dir = dir
        End Sub

        Public Overrides ReadOnly Property Message() As String
            Get
                Return Convert.ToString("Directory not found:") & _dir
            End Get
        End Property
    End Class
End Namespace

