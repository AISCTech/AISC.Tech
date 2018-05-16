Public Class clsExportBookingHeader

    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strBookingNo As String
    Property _BookingNo As String
        Get
            Return strBookingNo
        End Get
        Set(value As String)
            strBookingNo = value
        End Set
    End Property

    Private strBookingPrefix As String
    Property _BookingPrefix As String
        Get
            Return strBookingPrefix
        End Get
        Set(value As String)
            strBookingPrefix = value
        End Set
    End Property

    Private clsCompanyDetails As New clsCompanyHeader
    Property _CompanyDetails As clsCompanyHeader
        Get
            Return clsCompanyDetails
        End Get
        Set(value As clsCompanyHeader)
            clsCompanyDetails = value
        End Set
    End Property

    Private clsConsignorDetails As New clsClientHeader
    Property _ConsignorDetails As clsClientHeader
        Get
            Return clsConsignorDetails
        End Get
        Set(value As clsClientHeader)
            clsConsignorDetails = value
        End Set
    End Property

    Private clsSiteDetails As New clsSite
    Property _SiteDetails As clsSite
        Get
            Return clsSiteDetails
        End Get
        Set(value As clsSite)
            clsSiteDetails = value
        End Set
    End Property

    Private clsAccountTypeDetails As New clsAccountType
    Property _AccountTypeDetails As clsAccountType
        Get
            Return clsAccountTypeDetails
        End Get
        Set(value As clsAccountType)
            clsAccountTypeDetails = value
        End Set
    End Property

    Private clsAccountHolderDetails As New clsUserAccount
    Property _AccountHolderDetails As clsUserAccount
        Get
            Return clsAccountHolderDetails
        End Get
        Set(value As clsUserAccount)
            clsAccountHolderDetails = value
        End Set
    End Property

    Private clsShipperDetails As New clsClientHeader
    Property _ShipperDetails As clsClientHeader
        Get
            Return clsShipperDetails
        End Get
        Set(value As clsClientHeader)
            clsShipperDetails = value
        End Set
    End Property

    Private clsConsigneeDetails As New clsClientHeader
    Property _ConsigneeDetails As clsClientHeader
        Get
            Return clsConsigneeDetails
        End Get
        Set(value As clsClientHeader)
            clsConsigneeDetails = value
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

    Private clsOrigin As New clsPort
    Property _OriginDetails As clsPort
        Get
            Return clsOrigin
        End Get
        Set(value As clsPort)
            clsOrigin = value
        End Set
    End Property

    Private clsFinalDestinationDetails As New clsPort
    Property _FinalDestinationDetails As clsPort
        Get
            Return clsFinalDestinationDetails
        End Get
        Set(value As clsPort)
            clsFinalDestinationDetails = value
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

    Private blDangerousCargo As Boolean
    Property _DangerousCargo As Boolean
        Get
            Return blDangerousCargo
        End Get
        Set(value As Boolean)
            blDangerousCargo = value
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

    Private dblVolume As Double
    Property _Volume As Double
        Get
            Return dblVolume
        End Get
        Set(value As Double)
            dblVolume = value
        End Set
    End Property

    Private clsLoadTypeDetails As New clsParameters
    Property _LoadTypeDetails As clsParameters
        Get
            Return clsLoadTypeDetails
        End Get
        Set(value As clsParameters)
            clsLoadTypeDetails = value
        End Set
    End Property

    Private dblNoOfPackage As Double
    Property _NoOfPackage As Double
        Get
            Return dblNoOfPackage
        End Get
        Set(value As Double)
            dblNoOfPackage = value
        End Set
    End Property

    Private clsPackageUnitDetails As New clsParameters
    Property _PackageUnitDetails As clsParameters
        Get
            Return clsPackageUnitDetails
        End Get
        Set(value As clsParameters)
            clsPackageUnitDetails = value
        End Set
    End Property

    Private clsColoadToDetails As New clsClientHeader
    Property _ColoadToDetails As clsClientHeader
        Get
            Return clsColoadToDetails
        End Get
        Set(value As clsClientHeader)
            clsColoadToDetails = value
        End Set
    End Property

    Private dblActualVolume As Double
    Property _ActualVolume As Double
        Get
            Return dblActualVolume
        End Get
        Set(value As Double)
            dblActualVolume = value
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

    Private dblRevisedMeasurement As Double
    Property _RevisedMeasurement As Double
        Get
            Return dblRevisedMeasurement
        End Get
        Set(value As Double)
            dblRevisedMeasurement = value
        End Set
    End Property

    Private clsRevisedMeasurementTypeDetails As New clsParameters
    Property _RevisedMeasurementTypeDetails As clsParameters
        Get
            Return clsRevisedMeasurementTypeDetails
        End Get
        Set(value As clsParameters)
            clsRevisedMeasurementTypeDetails = value
        End Set
    End Property

    Private blApprovedPosting As Boolean
    Property _ApprovedPosting As Boolean
        Get
            Return blApprovedPosting
        End Get
        Set(value As Boolean)
            blApprovedPosting = value
        End Set
    End Property

    Private dtKPIDate As Date
    Property _KPIDate As Date
        Get
            Return dtKPIDate
        End Get
        Set(value As Date)
            dtKPIDate = value
        End Set
    End Property

    Private blDocsCompleted As Boolean
    Property _DocsCompleted As Boolean
        Get
            Return blDocsCompleted
        End Get
        Set(value As Boolean)
            blDocsCompleted = value
        End Set
    End Property

    Private clsMasterBookingDetails As New clsExportMasterBooking
    Property _MasterBookingDetails As clsExportMasterBooking
        Get
            Return clsMasterBookingDetails
        End Get
        Set(value As clsExportMasterBooking)
            clsMasterBookingDetails = value
        End Set
    End Property

    Private dtDocsCompletedDate As Date
    Property _DocsCompletedDate As Date
        Get
            Return dtDocsCompletedDate
        End Get
        Set(value As Date)
            dtDocsCompletedDate = value
        End Set
    End Property

    Private blIfBrkg As Boolean
    Property _IfBrkg As Boolean
        Get
            Return blIfBrkg
        End Get
        Set(value As Boolean)
            blIfBrkg = value
        End Set
    End Property

    Private clsBrkg As New clsBrkgJO
    Property _BrkgDetails As clsBrkgJO
        Get
            Return clsBrkg
        End Get
        Set(value As clsBrkgJO)
            clsBrkg = value
        End Set
    End Property

    Private clsStatusDetails As New clsStatus
    Property _StatusDetails As clsStatus
        Get
            Return clsStatusDetails
        End Get
        Set(value As clsStatus)
            clsStatusDetails = value
        End Set
    End Property

    Private clsStatusByDetails As New clsUserAccount
    Property _StatusByDetails As clsUserAccount
        Get
            Return clsStatusByDetails
        End Get
        Set(value As clsUserAccount)
            clsStatusByDetails = value
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

    Private clsPrepByDetails As New clsUserAccount
    Property _PrepByDetails As clsUserAccount
        Get
            Return clsPrepByDetails
        End Get
        Set(value As clsUserAccount)
            clsPrepByDetails = value
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

    Private clsModByDetails As New clsUserAccount
    Property _ModByDetails As clsUserAccount
        Get
            Return clsModByDetails
        End Get
        Set(value As clsUserAccount)
            clsModByDetails = value
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

    Private clsServiceDetails As New List(Of clsExportBookingServices)
    Property _ServiceDetails As List(Of clsExportBookingServices)
        Get
            Return clsServiceDetails
        End Get
        Set(value As List(Of clsExportBookingServices))
            clsServiceDetails = value
        End Set
    End Property

    Private clsDocumentDetails As New List(Of clsExportBookingDocuments)
    Property _DocumentDetails As List(Of clsExportBookingDocuments)
        Get
            Return clsDocumentDetails
        End Get
        Set(value As List(Of clsExportBookingDocuments))
            clsDocumentDetails = value
        End Set
    End Property

    Public Sub New()
        dblActualVolume = 0
        dblActualGrossWeight = 0
        dblRevisedMeasurement = 0
        blApprovedPosting = False
        dtKPIDate = Nothing
    End Sub
End Class

Public Class clsExportBookingServices
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private lngBookingID As Long
    Property _BookingID As Long
        Get
            Return lngBookingID
        End Get
        Set(value As Long)
            lngBookingID = value
        End Set
    End Property

    Private clsServiceNameDetails As New clsParameters
    Property _ServiceNameDetails As clsParameters
        Get
            Return clsServiceNameDetails
        End Get
        Set(value As clsParameters)
            clsServiceNameDetails = value
        End Set
    End Property
End Class

Public Class clsExportBookingDocuments
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private lngBookingID As Long
    Property _BookingID As Long
        Get
            Return lngBookingID
        End Get
        Set(value As Long)
            lngBookingID = value
        End Set
    End Property

    Private clsDocumentDetails As New clsBookingRequiredDocuments
    Property _DocumentDetails As clsBookingRequiredDocuments
        Get
            Return clsDocumentDetails
        End Get
        Set(value As clsBookingRequiredDocuments)
            clsDocumentDetails = value
        End Set
    End Property
End Class