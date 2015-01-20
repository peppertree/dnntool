
Imports System.Collections.Generic
Imports System.Text

Namespace Exceptions
    Public Class WebsiteWithoutRootException
        Inherits Exception
        Private _websiteName As String = ""

        Public Sub New(Website As String)
            Me._websiteName = Website
        End Sub

        Public Overrides ReadOnly Property Message() As String
            Get
                Dim msg As String = Convert.ToString("Website has no root. Website:") & _websiteName
                Return msg
            End Get
        End Property
    End Class
End Namespace

