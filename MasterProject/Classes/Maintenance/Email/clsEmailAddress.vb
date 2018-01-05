Public Class clsEmailAddress

    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strEmailAddress As String
    Property _EmailAddress As String
        Get
            Return strEmailAddress
        End Get
        Set(value As String)
            strEmailAddress = value
        End Set
    End Property

    Private strSMTP_Host As String
    Property _SMTP_Host As String
        Get
            Return strSMTP_Host
        End Get
        Set(value As String)
            strSMTP_Host = value
        End Set
    End Property

    Private strSMTP_Port As String
    Property _SMTP_Port As String
        Get
            Return strSMTP_Port
        End Get
        Set(value As String)
            strSMTP_Port = value
        End Set
    End Property

    Private strSMTP_Username As String
    Property _SMTP_Username As String
        Get
            Return strSMTP_Username
        End Get
        Set(value As String)
            strSMTP_Username = value
        End Set
    End Property

    Private strSMTP_Password As String
    Property _SMTP_Password As String
        Get
            Return strSMTP_Password
        End Get
        Set(value As String)
            strSMTP_Password = value
        End Set
    End Property

    Private strSMTP_EnableSSL As Boolean
    Property _SMTP_EnableSSL As Boolean
        Get
            Return strSMTP_EnableSSL
        End Get
        Set(value As Boolean)
            strSMTP_EnableSSL = value
        End Set
    End Property

    Private clsPrepBy As New clsUserAccount
    Property _PrepBy As clsUserAccount
        Get
            Return clsPrepBy
        End Get
        Set(value As clsUserAccount)
            clsPrepBy = value
        End Set
    End Property

    Private dtPrepDate As Date
    Property _PrepDate As Date
        Get
            Return dtPrepDate
        End Get
        Set(value As Date)
            dtPrepDate = value
        End Set
    End Property

    Private clsModBy As New clsUserAccount
    Property _ModBy As clsUserAccount
        Get
            Return clsModBy
        End Get
        Set(value As clsUserAccount)
            clsModBy = value
        End Set
    End Property

    Private dtModDate As Date
    Property _ModDate As Date
        Get
            Return dtModDate
        End Get
        Set(value As Date)
            dtModDate = value
        End Set
    End Property
End Class
