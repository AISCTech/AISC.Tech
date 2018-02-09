Public Class clsBookingRequiredDocuments

    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strDocumentName As String
    Property _DocumentName As String
        Get
            Return strDocumentName
        End Get
        Set(value As String)
            strDocumentName = value
        End Set
    End Property

    Private clsFreightType As New clsParameters
    Property _FreightType As clsParameters
        Get
            Return clsFreightType
        End Get
        Set(value As clsParameters)
            clsFreightType = value
        End Set
    End Property

    Private blRequired As Boolean
    Property _Required As Boolean
        Get
            Return blRequired
        End Get
        Set(value As Boolean)
            blRequired = value
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
