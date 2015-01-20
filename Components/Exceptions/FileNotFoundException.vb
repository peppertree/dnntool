
Imports System.Collections.Generic
Imports System.Text

Namespace Exceptions
    Public Class FileNotFoundException
        Inherits Exception
        Private _file As String = ""

        Public Sub New(file As String)
            Me._file = file
        End Sub

        Public Overrides ReadOnly Property Message() As String
            Get
                Dim msg As String = Convert.ToString("File not found:") & Me._file
                Return msg
            End Get
        End Property
    End Class
End Namespace
