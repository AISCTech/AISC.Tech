Public Class clsAccountType
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strPrefix As String
    Property _Prefix As String
        Get
            Return strPrefix
        End Get
        Set(value As String)
            strPrefix = value
        End Set
    End Property

    Private strDescription As String
    Property _Description As String
        Get
            Return strDescription
        End Get
        Set(value As String)
            strDescription = value
        End Set
    End Property
End Class
