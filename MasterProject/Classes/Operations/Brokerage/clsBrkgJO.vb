Public Class clsBrkgJO
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strBookNo As String
    Property _BookNo As String
        Get
            Return strBookNo
        End Get
        Set(value As String)
            strBookNo = value
        End Set
    End Property

    Private clsCompany As New clsCompanyHeader
    Property _CompanyDetails As clsCompanyHeader
        Get
            Return clsCompany
        End Get
        Set(value As clsCompanyHeader)
            clsCompany = value
        End Set
    End Property

    Private clsFreightType As New clsParameters
    Property _FreightTypeDetails As clsParameters
        Get
            Return clsFreightType
        End Get
        Set(value As clsParameters)
            clsFreightType = value
        End Set
    End Property

    Private clsModeOfTransportDetails As New clsParameters
    Property _ModeOfTransportDetails As clsParameters
        Get
            Return clsModeOfTransportDetails
        End Get
        Set(value As clsParameters)
            clsModeOfTransportDetails = value
        End Set
    End Property

    Private clsLoadType As New clsParameters
    Property _LoadType As clsParameters
        Get
            Return clsLoadType
        End Get
        Set(value As clsParameters)
            clsLoadType = value
        End Set
    End Property

    Private strHBLNo As String
    Property _HBLNo As String
        Get
            Return strHBLNo
        End Get
        Set(value As String)
            strHBLNo = value
        End Set
    End Property

    Private clsConsignor As New clsClientHeader
    Property _ConsignorDetails As clsClientHeader
        Get
            Return clsConsignor
        End Get
        Set(value As clsClientHeader)
            clsConsignor = value
        End Set
    End Property

    Private clsShipper As New clsClientHeader
    Property _ShipperDetails As clsClientHeader
        Get
            Return clsShipper
        End Get
        Set(value As clsClientHeader)
            clsShipper = value
        End Set
    End Property

    Private clsConsignee As New clsClientHeader
    Property _ConsigneeDetails As clsClientHeader
        Get
            Return clsConsignee
        End Get
        Set(value As clsClientHeader)
            clsConsignee = value
        End Set
    End Property

    Private clsOrigin As New clsPort
    Property _OriginDetails As clsPort
        Get
            Return clsOrigin
        End Get
        Set(value As clsPort)
            clsOrigin = value
        End Set
    End Property

    Private clsFinalDest As New clsPort
    Property _FinalDestDetails As clsPort
        Get
            Return clsFinalDest
        End Get
        Set(value As clsPort)
            clsFinalDest = value
        End Set
    End Property

    Private strCommodity As String
    Property _Commodity As String
        Get
            Return strCommodity
        End Get
        Set(value As String)
            strCommodity = value
        End Set
    End Property

    Private dblVolume As Double
    Property _Volume As Double
        Get
            Return dblVolume
        End Get
        Set(value As Double)
            dblVolume = value
        End Set
    End Property

    Private dblGrossWeight As Double
    Property _GrossWeight As Double
        Get
            Return dblGrossWeight
        End Get
        Set(value As Double)
            dblGrossWeight = value
        End Set
    End Property

    Private dblActualVolume As Double
    Property _ActualVolume As Double
        Get
            Return dblGrossWeight
        End Get
        Set(value As Double)
            dblGrossWeight = value
        End Set
    End Property

    Private dblActualGrossWeight As Double
    Property _ActualGrossWeight As Double
        Get
            Return dblActualGrossWeight
        End Get
        Set(value As Double)
            dblActualGrossWeight = value
        End Set
    End Property

    Private blCompleted As Boolean
    Property _Completed As Boolean
        Get
            Return blCompleted
        End Get
        Set(value As Boolean)
            blCompleted = value
        End Set
    End Property

    Private blCancelled As Boolean
    Property _Cancelled As Boolean
        Get
            Return blCancelled
        End Get
        Set(value As Boolean)
            blCancelled = value
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
End Class
