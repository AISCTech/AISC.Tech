Public Class clsBrkgItineraryHeader
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private clsPersonel As New clsBrkgPersonelList
    Property _PersonelDetails As clsBrkgPersonelList
        Get
            Return clsPersonel
        End Get
        Set(value As clsBrkgPersonelList)
            clsPersonel = value
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

    Private strRemarks As String
    Property _Remarks As String
        Get
            Return strRemarks
        End Get
        Set(value As String)
            strRemarks = value
        End Set
    End Property

    Private clsPrepBy As New clsUserAccount
    Property _PrepByDetails As clsUserAccount
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
    Property _ModByDetails As clsUserAccount
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

    Private clsStatus As New clsBrkgStatusList
    Property _StatusDetails As clsBrkgStatusList
        Get
            Return clsStatus
        End Get
        Set(value As clsBrkgStatusList)
            clsStatus = value
        End Set
    End Property

    Private clsStatusBy As New clsUserAccount
    Property _StatusByDetails As clsUserAccount
        Get
            Return clsStatusBy
        End Get
        Set(value As clsUserAccount)
            clsStatusBy = value
        End Set
    End Property

    Private dtStatusDate As Date
    Property _StatusDate As Date
        Get
            Return dtStatusDate
        End Get
        Set(value As Date)
            dtStatusDate = value
        End Set
    End Property

    Private lstDetails As New List(Of clsBrkgItineraryDetails)
    Property _ListOfItineraryDetails As List(Of clsBrkgItineraryDetails)
        Get
            Return lstDetails
        End Get
        Set(value As List(Of clsBrkgItineraryDetails))
            lstDetails = value
        End Set
    End Property
End Class

Public Class clsBrkgItineraryDetails
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private lngHeaderID As Long
    Property _HeaderID As Long
        Get
            Return lngHeaderID
        End Get
        Set(value As Long)
            lngHeaderID = value
        End Set
    End Property

    Private clsJO As New clsBrkgJO
    Property _JODetails As clsBrkgJO
        Get
            Return clsJO
        End Get
        Set(value As clsBrkgJO)
            clsJO = value
        End Set
    End Property

    Private strRemarks As String '
    Property _Remarks As String
        Get
            Return strRemarks
        End Get
        Set(value As String)
            strRemarks = value
        End Set
    End Property
End Class

Public Class clsBrkgStatusHistory
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private clsJO As New clsBrkgJO
    Property _JODetails As clsBrkgJO
        Get
            Return clsJO
        End Get
        Set(value As clsBrkgJO)
            clsJO = value
        End Set
    End Property

    Private clsStatus As New clsBrkgStatusList
    Property _StatusDetails As clsBrkgStatusList
        Get
            Return clsStatus
        End Get
        Set(value As clsBrkgStatusList)
            clsStatus = value
        End Set
    End Property

    Private clsStatusBy As New clsUserAccount
    Property _StatusByDetails As clsUserAccount
        Get
            Return clsStatusBy
        End Get
        Set(value As clsUserAccount)
            clsStatusBy = value
        End Set
    End Property

    Property dtStatusDate As Date
    Property _StatusDate As Date
        Get
            Return dtStatusDate
        End Get
        Set(value As Date)
            dtStatusDate = value
        End Set
    End Property
End Class
