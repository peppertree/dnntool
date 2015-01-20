Namespace Services

    Public Class SiteCopyArgs

        Public Property SrcConnectionString As String
        Public Property SrcDatabaseName As String
        Public Property SrcSitePath As String
        Public Property SrcSiteName As String
        Public Property SrcSiteAlias As String
        Public Property SrcSitePort As Integer

        Public Property TargetDatabaseName As String
        Public Property TargetSitePath As String
        Public Property TargetSiteName As String
        Public Property TargetSiteAlias As String
        Public Property TargetSitePort As Integer

        Public Property Connection As SqlClient.SqlConnection

    End Class

End Namespace

