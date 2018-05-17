Public Class clsDomesticMasterBooking
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strRefNo As String
    Property _RefNo As String
        Get
            Return strRefNo
        End Get
        Set(value As String)
            strRefNo = value
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

    Private clsCarrierDetails As New clsVendorHeader
    Property _CarrierDetails As clsVendorHeader
        Get
            Return clsCarrierDetails
        End Get
        Set(value As clsVendorHeader)
            clsCarrierDetails = value
        End Set
    End Property

    Private clsOriginDetails As New clsPort
    Property _OriginDetails As clsPort
        Get
            Return clsOriginDetails
        End Get
        Set(value As clsPort)
            clsOriginDetails = value
        End Set
    End Property

    Private clsDestinationDetails As New clsPort
    Property _DestinationDetails As clsPort
        Get
            Return clsDestinationDetails
        End Get
        Set(value As clsPort)
            clsDestinationDetails = value
        End Set
    End Property

    Private clsModeOfTransport As New clsParameters
    Property _ModeOfTransportDetails As clsParameters
        Get
            Return clsModeOfTransport
        End Get
        Set(value As clsParameters)
            clsModeOfTransport = value
        End Set
    End Property

    Private strLoadedPullOut As String
    Property _LoadedPullOut As String
        Get
            Return strLoadedPullOut
        End Get
        Set(value As String)
            strLoadedPullOut = value
        End Set
    End Property

    Private strContainerYard As String
    Property _ContainerYard As String
        Get
            Return strContainerYard
        End Get
        Set(value As String)
            strContainerYard = value
        End Set
    End Property

    Private clsWarehouseDetails As New clsWarehouse
    Property _WarehouseDetails As clsWarehouse
        Get
            Return clsWarehouseDetails
        End Get
        Set(value As clsWarehouse)
            clsWarehouseDetails = value
        End Set
    End Property

    Private clsETD As New clsDateValue
    Property _ETD As clsDateValue
        Get
            Return clsETD
        End Get
        Set(value As clsDateValue)
            clsETD = value
        End Set
    End Property

    Private clsATD As New clsDateValue
    Property _ATD As clsDateValue
        Get
            Return clsATD
        End Get
        Set(value As clsDateValue)
            clsATD = value
        End Set
    End Property

    Private strSealNo As String
    Property _SealNo As String
        Get
            Return strSealNo
        End Get
        Set(value As String)
            strSealNo = value
        End Set
    End Property

    Private strEmptyPositioning As String
    Property _EmptyPositioning As String
        Get
            Return strEmptyPositioning
        End Get
        Set(value As String)
            strEmptyPositioning = value
        End Set
    End Property

    Private strChassisDepot As String
    Property _ChassisDepot As String
        Get
            Return strChassisDepot
        End Get
        Set(value As String)
            strChassisDepot = value
        End Set
    End Property

    Private clsVesselDetails As New clsVessel
    Property _VesselDetails As clsVessel
        Get
            Return clsVesselDetails
        End Get
        Set(value As clsVessel)
            clsVesselDetails = value
        End Set
    End Property

    Private clsAirlineDetails As New clsVendorHeader
    Property _AirlineDetails As clsVendorHeader
        Get
            Return clsAirlineDetails
        End Get
        Set(value As clsVendorHeader)
            clsAirlineDetails = value
        End Set
    End Property

    Private strLCT As String
    Property _LCT As String
        Get
            Return strLCT
        End Get
        Set(value As String)
            strLCT = value
        End Set
    End Property

    Private clsETA As New clsDateValue
    Property _ETA As clsDateValue
        Get
            Return clsETA
        End Get
        Set(value As clsDateValue)
            clsETA = value
        End Set
    End Property

    Private clsATA As New clsDateValue
    Property _ATA As clsDateValue
        Get
            Return clsATA
        End Get
        Set(value As clsDateValue)
            clsATA = value
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

    Private lstBookingDetails As New List(Of clsExportBookingHeader)
    Property _ListOfBookingDetails As List(Of clsExportBookingHeader)
        Get
            Return lstBookingDetails
        End Get
        Set(value As List(Of clsExportBookingHeader))
            lstBookingDetails = value
        End Set
    End Property
End Class
