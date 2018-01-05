Public Class clsModules
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strModule_Name As String
    Property _Module_Name As String
        Get
            Return strModule_Name
        End Get
        Set(value As String)
            strModule_Name = value
        End Set
    End Property

    Private blEmailSending As Boolean
    Property _EmailSending As Boolean
        Get
            Return blEmailSending
        End Get
        Set(value As Boolean)
            blEmailSending = value
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
