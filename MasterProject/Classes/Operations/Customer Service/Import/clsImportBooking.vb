Public Class clsImportBookingHeader

    Private lngID As Long
    Property _ID As Integer
        Get
            Return lngID
        End Get
        Set(value As Integer)
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

    Private strHouseBL As String
    Property _HouseBL As String
        Get
            Return strHouseBL
        End Get
        Set(value As String)
            strHouseBL = value
        End Set
    End Property

    Private strCompanyCode As String
    Property _CompanyCode As String
        Get
            Return strCompanyCode
        End Get
        Set(value As String)
            strCompanyCode = value
        End Set
    End Property

    Private strCompanyName As String
    Property _CompanyName As String
        Get
            Return strCompanyName
        End Get
        Set(value As String)
            strCompanyName = value
        End Set
    End Property

    Private strSiteCode As String
    Property _SiteCode As String
        Get
            Return strSiteCode
        End Get
        Set(value As String)
            strSiteCode = value
        End Set
    End Property

    Private strSiteName As String
    Property _SiteName As String
        Get
            Return strSiteName
        End Get
        Set(value As String)
            strSiteName = value
        End Set
    End Property

    Private strShipperCode As String
    Property _ShipperCode As String
        Get
            Return strShipperCode
        End Get
        Set(value As String)
            strShipperCode = value
        End Set
    End Property

    Private strShipperName As String
    Property _ShipperName As String
        Get
            Return strShipperName
        End Get
        Set(value As String)
            strShipperName = value
        End Set
    End Property

    Private strShipperAddress As String
    Property _ShipperAddress As String
        Get
            Return strShipperAddress
        End Get
        Set(value As String)
            strShipperAddress = value
        End Set
    End Property

    Private strConsigneeCode As String
    Property _ConsigneeCode As String
        Get
            Return strConsigneeCode
        End Get
        Set(value As String)
            strConsigneeCode = value
        End Set
    End Property

    Private strConsigneeName As String
    Property _ConsigneeName As String
        Get
            Return strConsigneeName
        End Get
        Set(value As String)
            strConsigneeName = value
        End Set
    End Property

    Private strConsigneeAddress As String
    Property _ConsigneeAddress As String
        Get
            Return strConsigneeAddress
        End Get
        Set(value As String)
            strConsigneeAddress = value
        End Set
    End Property

    Private strConsignorCode As String
    Property _ConsignorCode As String
        Get
            Return strConsignorCode
        End Get
        Set(value As String)
            strConsignorCode = value
        End Set
    End Property

    Private strConsignorName As String
    Property _ConsignorName As String
        Get
            Return strConsignorName
        End Get
        Set(value As String)
            strConsignorName = value
        End Set
    End Property

    Private strConsignorAddress As String
    Property _ConsignorAddress As String
        Get
            Return strConsignorAddress
        End Get
        Set(value As String)
            strConsignorAddress = value
        End Set
    End Property

    Private strForwarderCode As String
    Property _ForwarderCode As String
        Get
            Return strForwarderCode
        End Get
        Set(value As String)
            strForwarderCode = value
        End Set
    End Property

    Private strForwarderName As String
    Property _ForwarderName As String
        Get
            Return strForwarderName
        End Get
        Set(value As String)
            strForwarderName = value
        End Set
    End Property

    Private strForwarderAddress As String
    Property _ForwarderAddress As String
        Get
            Return strForwarderAddress
        End Get
        Set(value As String)
            strForwarderAddress = value
        End Set
    End Property

    Private strShippingLineCode As String
    Property _ShippingLineCode As String
        Get
            Return strShippingLineCode
        End Get
        Set(value As String)
            strShippingLineCode = value
        End Set
    End Property

    Private strShippingLineName As String
    Property _ShippingLineName As String
        Get
            Return strShippingLineName
        End Get
        Set(value As String)
            strShippingLineName = value
        End Set
    End Property

    Private strShippingLineAddress As String
    Property _ShippingLineAddress As String
        Get
            Return strShippingLineAddress
        End Get
        Set(value As String)
            strShippingLineAddress = value
        End Set
    End Property

    Private strDescriptionOfGoods As String
    Property _DescriptionOfGoods As String
        Get
            Return strDescriptionOfGoods
        End Get
        Set(value As String)
            strDescriptionOfGoods = value
        End Set
    End Property

    Private dblWeight As Double
    Property _Weight As Double
        Get
            Return dblWeight
        End Get
        Set(value As Double)
            dblWeight = value
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

    Private dblNoOfPackage As Double
    Property _NoOfPackage As Double
        Get
            Return dblNoOfPackage
        End Get
        Set(value As Double)
            dblNoOfPackage = value
        End Set
    End Property

    Private intPackageUnitID As Integer
    Property _PackageUnitID As Integer
        Get
            Return intPackageUnitID
        End Get
        Set(value As Integer)
            intPackageUnitID = value
        End Set
    End Property

    Private strPackageUnitName As String
    Property _PackageUnitName As String
        Get
            Return strPackageUnitName
        End Get
        Set(value As String)
            strPackageUnitName = value
        End Set
    End Property

    Private intOriginPortID As Integer
    Property _OriginPortID As Integer
        Get
            Return intOriginPortID
        End Get
        Set(value As Integer)
            intOriginPortID = value
        End Set
    End Property

    Private strOriginPortName As String
    Property _OriginPortName As String
        Get
            Return strOriginPortName
        End Get
        Set(value As String)
            strOriginPortName = value
        End Set
    End Property

    Private strOriginCountryName As String
    Property _OriginCountryName As String
        Get
            Return strOriginCountryName
        End Get
        Set(value As String)
            strOriginCountryName = value
        End Set
    End Property

    Private intDestinationPortID As Integer
    Property _DestinationPortID As Integer
        Get
            Return intDestinationPortID
        End Get
        Set(value As Integer)
            intDestinationPortID = value
        End Set
    End Property

    Private strDestinationPortName As String
    Property _DestinationPortName As String
        Get
            Return strDestinationPortName
        End Get
        Set(value As String)
            strDestinationPortName = value
        End Set
    End Property

    Private strDestinationCountryName As String
    Property _DestinationCountryName As String
        Get
            Return strDestinationCountryName
        End Get
        Set(value As String)
            strDestinationCountryName = value
        End Set
    End Property

    Private dtETA As Date
    Property _ETA As Date
        Get
            Return dtETA
        End Get
        Set(value As Date)
            dtETA = value
        End Set
    End Property

    Private dtATA As Date
    Property _ATA As Date
        Get
            Return dtATA
        End Get
        Set(value As Date)
            dtATA = value
        End Set
    End Property

    Private lngVesselID As Long
    Property _VesselID As Long
        Get
            Return lngVesselID
        End Get
        Set(value As Long)
            lngVesselID = value
        End Set
    End Property

    Private strVesselName As String
    Property _VesselName As String
        Get
            Return strVesselName
        End Get
        Set(value As String)
            strVesselName = value
        End Set
    End Property

    Private strVoyage As String
    Property _Voyage As String
        Get
            Return strVoyage
        End Get
        Set(value As String)
            strVoyage = value
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

    Private dtDocsCompletedDate As Date
    Property _DocsCompletedDate As Date
        Get
            Return dtDocsCompletedDate
        End Get
        Set(value As Date)
            dtDocsCompletedDate = value
        End Set
    End Property

    Private strImportPermitNo As String
    Property _ImportPermitNo As String
        Get
            Return strImportPermitNo
        End Get
        Set(value As String)
            strImportPermitNo = value
        End Set
    End Property

    Private strInvoiceNo As String
    Property _InvoiceNo As String
        Get
            Return strInvoiceNo
        End Get
        Set(value As String)
            strInvoiceNo = value
        End Set
    End Property

    Private strRegistryNo As String
    Property _RegistryNo As String
        Get
            Return strRegistryNo
        End Get
        Set(value As String)
            strRegistryNo = value
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

    Private intModeOfTransportID As Integer
    Property _ModeOfTransportID As Integer
        Get
            Return intModeOfTransportID
        End Get
        Set(value As Integer)
            intModeOfTransportID = value
        End Set
    End Property

    Private strModeOfTransportName As String
    Property _ModeOfTransportName As String
        Get
            Return strModeOfTransportName
        End Get
        Set(value As String)
            strModeOfTransportName = value
        End Set
    End Property

    Private intLoadTypeID As Integer
    Property _LoadTypeID As Integer
        Get
            Return intLoadTypeID
        End Get
        Set(value As Integer)
            intLoadTypeID = value
        End Set
    End Property

    Private strLoadTypeName As String
    Property _LoadTypeName As String
        Get
            Return strLoadTypeName
        End Get
        Set(value As String)
            strLoadTypeName = value
        End Set
    End Property

    Private intEntryTypeID As Integer
    Property _EntryTypeID As Integer
        Get
            Return intEntryTypeID
        End Get
        Set(value As Integer)
            intEntryTypeID = value
        End Set
    End Property

    Private strEntryTypeName As String
    Property _EntryTypeName As String
        Get
            Return strEntryTypeName
        End Get
        Set(value As String)
            strEntryTypeName = value
        End Set
    End Property

    Private intFreightTermsID As Integer
    Property _FreightTermsID As Integer
        Get
            Return intFreightTermsID
        End Get
        Set(value As Integer)
            intFreightTermsID = value
        End Set
    End Property

    Private strFreightTermsName As String
    Property _FreightTermsName As String
        Get
            Return strFreightTermsName
        End Get
        Set(value As String)
            strFreightTermsName = value
        End Set
    End Property

    Private lngWarehouseID As Long
    Property _WarehouseID As Long
        Get
            Return lngWarehouseID
        End Get
        Set(value As Long)
            lngWarehouseID = value
        End Set
    End Property

    Private strWarehouseName As String
    Property _WarehouseName As String
        Get
            Return strWarehouseName
        End Get
        Set(value As String)
            strWarehouseName = value
        End Set
    End Property

    Private lngAccountTypeID As Long
    Property _AccountTypeID As Long
        Get
            Return lngAccountTypeID
        End Get
        Set(value As Long)
            lngAccountTypeID = value
        End Set
    End Property

    Private strAccountTypePrefix As String
    Property _AccountTypePrefix As String
        Get
            Return strAccountTypePrefix
        End Get
        Set(value As String)
            strAccountTypePrefix = value
        End Set
    End Property

    Private strAccountTypeDesc As String
    Property _AccountTypeDesc As String
        Get
            Return strAccountTypeDesc
        End Get
        Set(value As String)
            strAccountTypeDesc = value
        End Set
    End Property

    Private strAccountHolderID As String
    Property _AccountHolderID As String
        Get
            Return strAccountHolderID
        End Get
        Set(value As String)
            strAccountHolderID = value
        End Set
    End Property

    Private strAccountHolderName As String
    Property _AccountHolderFullName As String
        Get
            Return strAccountHolderName
        End Get
        Set(value As String)
            strAccountHolderName = value
        End Set
    End Property

    Private intStatusID As Integer
    Property _StatusID As Integer
        Get
            Return intStatusID
        End Get
        Set(value As Integer)
            intStatusID = value
        End Set
    End Property

    Private strStatusName As String
    Property _StatusName As String
        Get
            Return strStatusName
        End Get
        Set(value As String)
            strStatusName = value
        End Set
    End Property

    Private strPrepByID As String
    Property _PrepByID As String
        Get
            Return strPrepByID
        End Get
        Set(value As String)
            strPrepByID = value
        End Set
    End Property

    Private strPrepByFullName As String
    Property _PrepByFullName As String
        Get
            Return strPrepByFullName
        End Get
        Set(value As String)
            strPrepByFullName = value
        End Set
    End Property

    Private dtPrepDate As Date
    Property _PrepDate As String
        Get
            Return dtPrepDate
        End Get
        Set(value As String)
            dtPrepDate = value
        End Set
    End Property

    Private strModByID As String
    Property _ModByID As String
        Get
            Return strModByID
        End Get
        Set(value As String)
            strModByID = value
        End Set
    End Property

    Private strModByFullName As String
    Property _ModByFullName As String
        Get
            Return strModByFullName
        End Get
        Set(value As String)
            strModByFullName = value
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

    Private strStatusByID As String
    Property _StatusByID As String
        Get
            Return strStatusByID
        End Get
        Set(value As String)
            strStatusByID = value
        End Set
    End Property

    Private strStatusByFullName As String
    Property _StatusByFullName As String
        Get
            Return strStatusByFullName
        End Get
        Set(value As String)
            strStatusByFullName = value
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

    Private lstclsServices As New List(Of clsImportBookingServices)
    Property _ServiceDetails As List(Of clsImportBookingServices)
        Get
            Return lstclsServices
        End Get
        Set(value As List(Of clsImportBookingServices))
            lstclsServices = value
        End Set
    End Property

    Private lstclsContainers As New List(Of clsImportBookingContainers)
    Property _ContainerDetails As List(Of clsImportBookingContainers)
        Get
            Return lstclsContainers
        End Get
        Set(value As List(Of clsImportBookingContainers))
            lstclsContainers = value
        End Set
    End Property

    Private lstclsDocuments As New List(Of clsImportBookingDocuments)
    Property _DocumentDetails As List(Of clsImportBookingDocuments)
        Get
            Return lstclsDocuments
        End Get
        Set(value As List(Of clsImportBookingDocuments))
            lstclsDocuments = value
        End Set
    End Property
End Class

Public Class clsImportBookingServices

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

    Private intServicesID As Integer
    Property _ServiceID As Integer
        Get
            Return intServicesID
        End Get
        Set(value As Integer)
            intServicesID = value
        End Set
    End Property

    Private strServiceDesc As String
    Property _ServiceDescription As String
        Get
            Return strServiceDesc
        End Get
        Set(value As String)
            strServiceDesc = value
        End Set
    End Property
End Class

Public Class clsImportBookingContainers

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

    Private lngContainerID As Long
    Property _ContainerID As Long
        Get
            Return lngContainerID
        End Get
        Set(value As Long)
            lngContainerID = value
        End Set
    End Property

    Private strContainerNo As String
    Property _ContainerNo As String
        Get
            Return strContainerNo
        End Get
        Set(value As String)
            strContainerNo = value
        End Set
    End Property

    Private intContainerSizeID As Integer
    Property _ContainerSizeID As Integer
        Get
            Return intContainerSizeID
        End Get
        Set(value As Integer)
            intContainerSizeID = value
        End Set
    End Property

    Private strContainerSizeName As String
    Property _ContainerSizeName As String
        Get
            Return strContainerSizeName
        End Get
        Set(value As String)
            strContainerSizeName = value
        End Set
    End Property

    Private dtPickupDate As Date
    Property _PickupDate As Date
        Get
            Return dtPickupDate
        End Get
        Set(value As Date)
            dtPickupDate = value
        End Set
    End Property

    Private dtDeliveryDate As Date
    Property _DeliveryDate As Date
        Get
            Return dtDeliveryDate
        End Get
        Set(value As Date)
            dtDeliveryDate = value
        End Set
    End Property
End Class

Public Class clsImportBookingDocuments

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

    Private lngDocumentID As Long
    Property _DocumentID As Long
        Get
            Return lngDocumentID
        End Get
        Set(value As Long)
            lngDocumentID = value
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
End Class
