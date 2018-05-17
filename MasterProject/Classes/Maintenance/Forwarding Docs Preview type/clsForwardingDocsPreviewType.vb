Public Class clsForwardingDocsPreviewType
    Private intID As Integer
    Property _ID As Integer
        Get
            Return intID
        End Get
        Set(value As Integer)
            intID = value
        End Set
    End Property

    Private strPreviewTypeName As String
    Property _PreviewTypeName As String
        Get
            Return strPreviewTypeName
        End Get
        Set(value As String)
            strPreviewTypeName = value
        End Set
    End Property
End Class
