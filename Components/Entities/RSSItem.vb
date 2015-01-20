Public Class RSSItem

    Public Property DNNVersion As String
    Public Property DownloadUrl As String

    Public Sub New(version As String, url As String)
        DownloadUrl = url
        DNNVersion = version
    End Sub

End Class
