Namespace Services

    Public Class SiteCreateArgs

        Public Property ConnectionString As String
        Public Property DatabaseName As String
        Public Property MDFPath As String
        Public Property LDFPath As String
        Public Property SitePath As String
        Public Property SiteName As String
        Public Property SiteAlias As String
        Public Property SitePort As Integer

        Public Property FromClone As Boolean = False
        Public Property Connection As SqlClient.SqlConnection

    End Class

End Namespace

