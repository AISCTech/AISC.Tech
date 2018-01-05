Public Class clsFileLocation

    Private intID As Long
    Property _ID As Long
        Get
            Return intID
        End Get
        Set(value As Long)
            intID = value
        End Set
    End Property

    Private strCode As String
    Property _Code As String
        Get
            Return strCode
        End Get
        Set(value As String)
            strCode = value
        End Set
    End Property

    Private strLocation As String
    Property _Location As String
        Get
            Return strLocation
        End Get
        Set(value As String)
            strLocation = value
        End Set
    End Property

    Private blActive As Boolean
    Property _Active As Boolean
        Get
            Return blActive
        End Get
        Set(value As Boolean)
            blActive = value
        End Set
    End Property
End Class
