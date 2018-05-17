Public Class clsFrwdgDocsMBL
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strMBLNo As String
    Property _MBLNo As String
        Get
            Return strMBLNo
        End Get
        Set(value As String)
            strMBLNo = value
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

    Private strRegYear As String
    Property _RegYear As String
        Get
            Return strRegYear
        End Get
        Set(value As String)
            strRegYear = value
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

    Private clsModeOfTransport As New clsParameters
    Property _ModeOfTransport As clsParameters
        Get
            Return clsModeOfTransport
        End Get
        Set(value As clsParameters)
            clsModeOfTransport = value
        End Set
    End Property

    Private clsFreightTypeDetails As New clsParameters
    Property _FreightTypeDetails As clsParameters
        Get
            Return clsFreightTypeDetails
        End Get
        Set(value As clsParameters)
            clsFreightTypeDetails = value
        End Set
    End Property

    Private clsPreviewTypeDetails As New clsForwardingDocsPreviewType
    Property _PreviewTypeDetails As clsForwardingDocsPreviewType
        Get
            Return clsPreviewTypeDetails
        End Get
        Set(value As clsForwardingDocsPreviewType)
            clsPreviewTypeDetails = value
        End Set
    End Property

    Private dtArrivalDate As Date
    Property _ArrivalDate As Date
        Get
            Return dtArrivalDate
        End Get
        Set(value As Date)
            dtArrivalDate = value
        End Set
    End Property

    Private strCargoType As String
    Property _CargoType As String
        Get
            Return strCargoType
        End Get
        Set(value As String)
            strCargoType = value
        End Set
    End Property

    Private strPlaceOfReceiptCode As String
    Property _PlaceOfReceiptCode As String
        Get
            Return strPlaceOfReceiptCode
        End Get
        Set(value As String)
            strPlaceOfReceiptCode = value
        End Set
    End Property

    Private strPlaceOfReceiptName As String
    Property _PlaceOfReceiptName As String
        Get
            Return strPlaceOfReceiptName
        End Get
        Set(value As String)
            strPlaceOfReceiptName = value
        End Set
    End Property

    Private strVesselCode As String
    Property _VesselCode As String
        Get
            Return strVesselCode
        End Get
        Set(value As String)
            strVesselCode = value
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

    Private strVOY As String
    Property _VOY As String
        Get
            Return strVOY
        End Get
        Set(value As String)
            strVOY = value
        End Set
    End Property

    Private strPortOfLoadingCode As String
    Property _PortOfLoadingCode As String
        Get
            Return strPortOfLoadingCode
        End Get
        Set(value As String)
            strPortOfLoadingCode = value
        End Set
    End Property

    Private strPortOfLoadingName As String
    Property _PortOfLoadingName As String
        Get
            Return strPortOfLoadingName
        End Get
        Set(value As String)
            strPortOfLoadingName = value
        End Set
    End Property

    Private strPortOfDischargeCode As String
    Property _PortOfDischargeCode As String
        Get
            Return strPortOfDischargeCode
        End Get
        Set(value As String)
            strPortOfDischargeCode = value
        End Set
    End Property

    Private strPortOfDischargeName As String
    Property _PortOfDischargeName As String
        Get
            Return strPortOfDischargeName
        End Get
        Set(value As String)
            strPortOfDischargeName = value
        End Set
    End Property

    Private strDevanDate As String
    Property _DevanDate As String
        Get
            Return strDevanDate
        End Get
        Set(value As String)
            strDevanDate = value
        End Set
    End Property

    Private strCargoLocation As String
    Property _CargoLocation As String
        Get
            Return strCargoLocation
        End Get
        Set(value As String)
            strCargoLocation = value
        End Set
    End Property

    Private dblExchangeRate As Double
    Property _ExchangeRate As Double
        Get
            Return dblExchangeRate
        End Get
        Set(value As Double)
            dblExchangeRate = value
        End Set
    End Property

    Private strConsolCoload As String
    Property _ConsolCoload As String
        Get
            Return strConsolCoload
        End Get
        Set(value As String)
            strConsolCoload = value
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

    Private lstHBLs As New List(Of clsFrwdgDocsHBL)
    Property _ListOfHBL As List(Of clsFrwdgDocsHBL)
        Get
            Return lstHBLs
        End Get
        Set(value As List(Of clsFrwdgDocsHBL))
            lstHBLs = value
        End Set
    End Property
End Class

Public Class clsFrwdgDocsHBL
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private clsMBL As New clsFrwdgDocsMBL
    Property _MBL As clsFrwdgDocsMBL
        Get
            Return clsMBL
        End Get
        Set(value As clsFrwdgDocsMBL)
            clsMBL = value
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

    Private strDataDiv As String
    Property _DataDiv As String
        Get
            Return strDataDiv
        End Get
        Set(value As String)
            strDataDiv = value
        End Set
    End Property

    Private strSenderCode As String
    Property _SenderCode As String
        Get
            Return strSenderCode
        End Get
        Set(value As String)
            strSenderCode = value
        End Set
    End Property

    Private strReceiverCode As String
    Property _ReceiverCode As String
        Get
            Return strReceiverCode
        End Get
        Set(value As String)
            strReceiverCode = value
        End Set
    End Property

    Private strSendDate As String
    Property _SendDate As String
        Get
            Return strSendDate
        End Get
        Set(value As String)
            strSendDate = value
        End Set
    End Property

    Private strSendDiv As String
    Property _SendDiv As String
        Get
            Return strSendDiv
        End Get
        Set(value As String)
            strSendDiv = value
        End Set
    End Property

    Private strThroughBLNo As String
    Property _ThroughBLNo As String
        Get
            Return strThroughBLNo
        End Get
        Set(value As String)
            strThroughBLNo = value
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

    Private strShipperName1 As String
    Property _ShipperName1 As String
        Get
            Return strShipperName1
        End Get
        Set(value As String)
            strShipperName1 = value
        End Set
    End Property

    Private strShipperName2 As String
    Property _ShipperName2 As String
        Get
            Return strShipperName2
        End Get
        Set(value As String)
            strShipperName2 = value
        End Set
    End Property

    Private strShipperName3 As String
    Property _ShipperName3 As String
        Get
            Return strShipperName3
        End Get
        Set(value As String)
            strShipperName3 = value
        End Set
    End Property

    Private strShipperName4 As String
    Property _ShipperName4 As String
        Get
            Return strShipperName4
        End Get
        Set(value As String)
            strShipperName4 = value
        End Set
    End Property

    Private strShipperName5 As String
    Property _ShipperName5 As String
        Get
            Return strShipperName5
        End Get
        Set(value As String)
            strShipperName5 = value
        End Set
    End Property

    Private strShipperName6 As String
    Property _ShipperName6 As String
        Get
            Return strShipperName6
        End Get
        Set(value As String)
            strShipperName6 = value
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

    Private strConsigneeName1 As String
    Property _ConsigneeName1 As String
        Get
            Return strConsigneeName1
        End Get
        Set(value As String)
            strConsigneeName1 = value
        End Set
    End Property

    Private strConsigneeName2 As String
    Property _ConsigneeName2 As String
        Get
            Return strConsigneeName2
        End Get
        Set(value As String)
            strConsigneeName2 = value
        End Set
    End Property

    Private strConsigneeName3 As String
    Property _ConsigneeName3 As String
        Get
            Return strConsigneeName3
        End Get
        Set(value As String)
            strConsigneeName3 = value
        End Set
    End Property

    Private strConsigneeName4 As String
    Property _ConsigneeName4 As String
        Get
            Return strConsigneeName4
        End Get
        Set(value As String)
            strConsigneeName4 = value
        End Set
    End Property

    Private strConsigneeName5 As String
    Property _ConsigneeName5 As String
        Get
            Return strConsigneeName5
        End Get
        Set(value As String)
            strConsigneeName5 = value
        End Set
    End Property

    Private strConsigneeName6 As String
    Property _ConsigneeName6 As String
        Get
            Return strConsigneeName6
        End Get
        Set(value As String)
            strConsigneeName6 = value
        End Set
    End Property

    Private strNotifyPartyCode As String
    Property _NotifyPartyCode As String
        Get
            Return strNotifyPartyCode
        End Get
        Set(value As String)
            strNotifyPartyCode = value
        End Set
    End Property

    Private strNotifyPartyName1 As String
    Property _NotifyPartyName1 As String
        Get
            Return strNotifyPartyName1
        End Get
        Set(value As String)
            strNotifyPartyName1 = value
        End Set
    End Property

    Private strNotifyPartyName2 As String
    Property _NotifyPartyName2 As String
        Get
            Return strNotifyPartyName2
        End Get
        Set(value As String)
            strNotifyPartyName2 = value
        End Set
    End Property

    Private strNotifyPartyName3 As String
    Property _NotifyPartyName3 As String
        Get
            Return strNotifyPartyName3
        End Get
        Set(value As String)
            strNotifyPartyName3 = value
        End Set
    End Property

    Private strNotifyPartyName4 As String
    Property _NotifyPartyName4 As String
        Get
            Return strNotifyPartyName4
        End Get
        Set(value As String)
            strNotifyPartyName4 = value
        End Set
    End Property

    Private strNotifyPartyName5 As String
    Property _NotifyPartyName5 As String
        Get
            Return strNotifyPartyName5
        End Get
        Set(value As String)
            strNotifyPartyName5 = value
        End Set
    End Property

    Private strNotifyPartyName6 As String
    Property _NotifyPartyName6 As String
        Get
            Return strNotifyPartyName6
        End Get
        Set(value As String)
            strNotifyPartyName6 = value
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

    Private strForwarderName1 As String
    Property _ForwarderName1 As String
        Get
            Return strForwarderName1
        End Get
        Set(value As String)
            strForwarderName1 = value
        End Set
    End Property

    Private strForwarderName2 As String
    Property _ForwarderName2 As String
        Get
            Return strForwarderName2
        End Get
        Set(value As String)
            strForwarderName2 = value
        End Set
    End Property

    Private strForwarderName3 As String
    Property _ForwarderName3 As String
        Get
            Return strForwarderName3
        End Get
        Set(value As String)
            strForwarderName3 = value
        End Set
    End Property

    Private strForwarderName4 As String
    Property _ForwarderName4 As String
        Get
            Return strForwarderName4
        End Get
        Set(value As String)
            strForwarderName4 = value
        End Set
    End Property

    Private strForwarderName5 As String
    Property _ForwarderName5 As String
        Get
            Return strForwarderName5
        End Get
        Set(value As String)
            strForwarderName5 = value
        End Set
    End Property

    Private strForwarderName6 As String
    Property _ForwarderName6 As String
        Get
            Return strForwarderName6
        End Get
        Set(value As String)
            strForwarderName6 = value
        End Set
    End Property

    Private strPreCarrierCode As String
    Property _PreCarrierCode As String
        Get
            Return strPreCarrierCode
        End Get
        Set(value As String)
            strPreCarrierCode = value
        End Set
    End Property

    Private strPreCarrierName As String
    Property _PreCarrierName As String
        Get
            Return strPreCarrierName
        End Get
        Set(value As String)
            strPreCarrierName = value
        End Set
    End Property

    Private strPlaceOfDeliveryCode As String
    Property _PlaceOfDeliveryCode As String
        Get
            Return strPlaceOfDeliveryCode
        End Get
        Set(value As String)
            strPlaceOfDeliveryCode = value
        End Set
    End Property

    Private strPlaceOfDeliveryName As String
    Property _PlaceOfDeliveryName As String
        Get
            Return strPlaceOfDeliveryName
        End Get
        Set(value As String)
            strPlaceOfDeliveryName = value
        End Set
    End Property

    Private strPartyToContactCode As String
    Property _PartyToContactCode As String
        Get
            Return strPartyToContactCode
        End Get
        Set(value As String)
            strPartyToContactCode = value
        End Set
    End Property

    Private strPartyToContactName1 As String
    Property _PartyToContactName1 As String
        Get
            Return strPartyToContactName1
        End Get
        Set(value As String)
            strPartyToContactName1 = value
        End Set
    End Property

    Private strPartyToContactName2 As String
    Property _PartyToContactName2 As String
        Get
            Return strPartyToContactName2
        End Get
        Set(value As String)
            strPartyToContactName2 = value
        End Set
    End Property

    Private strPartyToContactName3 As String
    Property _PartyToContactName3 As String
        Get
            Return strPartyToContactName3
        End Get
        Set(value As String)
            strPartyToContactName3 = value
        End Set
    End Property

    Private strPartyToContactName4 As String
    Property _PartyToContactName4 As String
        Get
            Return strPartyToContactName4
        End Get
        Set(value As String)
            strPartyToContactName4 = value
        End Set
    End Property

    Private strPartyToContactName5 As String
    Property _PartyToContactName5 As String
        Get
            Return strPartyToContactName5
        End Get
        Set(value As String)
            strPartyToContactName5 = value
        End Set
    End Property

    Private strPartyToContactName6 As String
    Property _PartyToContactName6 As String
        Get
            Return strPartyToContactName6
        End Get
        Set(value As String)
            strPartyToContactName6 = value
        End Set
    End Property

    Private strFinalDestinationCode As String
    Property _FinalDestinationCode As String
        Get
            Return strFinalDestinationCode
        End Get
        Set(value As String)
            strFinalDestinationCode = value
        End Set
    End Property

    Private strFinalDestinationName As String
    Property _FinalDestinationName As String
        Get
            Return strFinalDestinationName
        End Get
        Set(value As String)
            strFinalDestinationName = value
        End Set
    End Property

    Private strFreight As String
    Property _Freight As String
        Get
            Return strFreight
        End Get
        Set(value As String)
            strFreight = value
        End Set
    End Property

    Private strSurrenderWaybillDiv As String
    Property _SurrenderWaybillDiv As String
        Get
            Return strSurrenderWaybillDiv
        End Get
        Set(value As String)
            strSurrenderWaybillDiv = value
        End Set
    End Property

    Private strGrossWeightKGMInteger As String
    Property _GrossWeightKGMInteger As String
        Get
            Return strGrossWeightKGMInteger
        End Get
        Set(value As String)
            strGrossWeightKGMInteger = value
        End Set
    End Property

    Private strGrossWeightKGMFraction As String
    Property _GrossWeightKGMFraction As String
        Get
            Return strGrossWeightKGMFraction
        End Get
        Set(value As String)
            strGrossWeightKGMFraction = value
        End Set
    End Property

    Private strMeasurementInteger As String
    Property _MeasurementInteger As String
        Get
            Return strMeasurementInteger
        End Get
        Set(value As String)
            strMeasurementInteger = value
        End Set
    End Property

    Private strMeasurementFraction As String
    Property _MeasurementFraction As String
        Get
            Return strMeasurementFraction
        End Get
        Set(value As String)
            strMeasurementFraction = value
        End Set
    End Property

    Private strTotalQuantity As String
    Property _TotalQuantity As String
        Get
            Return strTotalQuantity
        End Get
        Set(value As String)
            strTotalQuantity = value
        End Set
    End Property

    Private strTotalQuantityUnitCode As String
    Property _TotalQuantityUnitCode As String
        Get
            Return strTotalQuantityUnitCode
        End Get
        Set(value As String)
            strTotalQuantityUnitCode = value
        End Set
    End Property

    Private strTotalQuantityUnitName As String
    Property _TotalQuantityUnitName As String
        Get
            Return strTotalQuantityUnitName
        End Get
        Set(value As String)
            strTotalQuantityUnitName = value
        End Set
    End Property

    Private strTotalInWords As String
    Property _TotalInWords As String
        Get
            Return strTotalInWords
        End Get
        Set(value As String)
            strTotalInWords = value
        End Set
    End Property

    Private strMerchantsDeclared As String
    Property _MerchantsDeclared As String
        Get
            Return strMerchantsDeclared
        End Get
        Set(value As String)
            strMerchantsDeclared = value
        End Set
    End Property

    Private strCurrency As String
    Property _Currency As String
        Get
            Return strCurrency
        End Get
        Set(value As String)
            strCurrency = value
        End Set
    End Property

    Private strPrepaidAtCode As String
    Property _PrepaidAtCode As String
        Get
            Return strPrepaidAtCode
        End Get
        Set(value As String)
            strPrepaidAtCode = value
        End Set
    End Property

    Private strPrepaidAtName As String
    Property _PrepaidAtName As String
        Get
            Return strPrepaidAtName
        End Get
        Set(value As String)
            strPrepaidAtName = value
        End Set
    End Property

    Private strPayableAtCode As String
    Property _PayableAtCode As String
        Get
            Return strPayableAtCode
        End Get
        Set(value As String)
            strPayableAtCode = value
        End Set
    End Property

    Private strPayableAtName As String
    Property _PayableAtName As String
        Get
            Return strPayableAtName
        End Get
        Set(value As String)
            strPayableAtName = value
        End Set
    End Property

    Private strPlaceAndDateOfCode As String
    Property _PlaceAndDateOfCode As String
        Get
            Return strPlaceAndDateOfCode
        End Get
        Set(value As String)
            strPlaceAndDateOfCode = value
        End Set
    End Property

    Private strPlaceAndDateOfName As String
    Property _PlaceAndDateOfName As String
        Get
            Return strPlaceAndDateOfName
        End Get
        Set(value As String)
            strPlaceAndDateOfName = value
        End Set
    End Property

    Private strTotalPrepaidInCode As String
    Property _TotalPrepaidInCode As String
        Get
            Return strTotalPrepaidInCode
        End Get
        Set(value As String)
            strTotalPrepaidInCode = value
        End Set
    End Property

    Private strTotalPrepaidInName As String
    Property _TotalPrepaidInName As String
        Get
            Return strTotalPrepaidInName
        End Get
        Set(value As String)
            strTotalPrepaidInName = value
        End Set
    End Property

    Private strNoOfOriginalBSLN As String
    Property _NoOfOriginalBSLN As String
        Get
            Return strNoOfOriginalBSLN
        End Get
        Set(value As String)
            strNoOfOriginalBSLN = value
        End Set
    End Property

    Private strBLDiv As String
    Property _BLDiv As String
        Get
            Return strBLDiv
        End Get
        Set(value As String)
            strBLDiv = value
        End Set
    End Property

    Private strETAPortOfLoading As Date
    Property _ETAPortOfLoading As Date
        Get
            Return strETAPortOfLoading
        End Get
        Set(value As Date)
            strETAPortOfLoading = value
        End Set
    End Property

    Private strETDPortOfLoading As Date
    Property _ETDPortOfLoading As Date
        Get
            Return strETDPortOfLoading
        End Get
        Set(value As Date)
            strETDPortOfLoading = value
        End Set
    End Property

    Private strETAPortOfDischarge As Date
    Property _ETAPortOfDischarge As Date
        Get
            Return strETAPortOfDischarge
        End Get
        Set(value As Date)
            strETAPortOfDischarge = value
        End Set
    End Property

    Private strETDPortOfDischarge As Date
    Property _ETDPortOfDischarge As Date
        Get
            Return strETDPortOfDischarge
        End Get
        Set(value As Date)
            strETDPortOfDischarge = value
        End Set
    End Property

    Private strPortOfTransitCode As String
    Property _PortOfTransitCode As String
        Get
            Return strPortOfTransitCode
        End Get
        Set(value As String)
            strPortOfTransitCode = value
        End Set
    End Property

    Private strPortOfTransitName As String
    Property _PortOfTransitName As String
        Get
            Return strPortOfTransitName
        End Get
        Set(value As String)
            strPortOfTransitName = value
        End Set
    End Property

    Private strETATransit As String
    Property _ETATransit As String
        Get
            Return strETATransit
        End Get
        Set(value As String)
            strETATransit = value
        End Set
    End Property

    Private strETDTransit As String
    Property _ETDTransit As String
        Get
            Return strETDTransit
        End Get
        Set(value As String)
            strETDTransit = value
        End Set
    End Property

    Private strATAPortOfDischarge As String
    Property _ATAPortOfDischarge As String
        Get
            Return strATAPortOfDischarge
        End Get
        Set(value As String)
            strATAPortOfDischarge = value
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

    Private lstBookingDetails As New List(Of clsFrwdgDocsBooking)
    Property _BookingDetails As List(Of clsFrwdgDocsBooking)
        Get
            Return lstBookingDetails
        End Get
        Set(value As List(Of clsFrwdgDocsBooking))
            lstBookingDetails = value
        End Set
    End Property

    Private lstContainerDetails As New List(Of clsFrwdgDocsContainer)
    Property _ContainerDetails As List(Of clsFrwdgDocsContainer)
        Get
            Return lstContainerDetails
        End Get
        Set(value As List(Of clsFrwdgDocsContainer))
            lstContainerDetails = value
        End Set
    End Property

    Private lstMarksAndNumbersDetails As New List(Of clsFrwdgDocsMarksAndNumbers)
    Property _MarksAndNumbersDetails As List(Of clsFrwdgDocsMarksAndNumbers)
        Get
            Return lstMarksAndNumbersDetails
        End Get
        Set(value As List(Of clsFrwdgDocsMarksAndNumbers))
            lstMarksAndNumbersDetails = value
        End Set
    End Property

    Private lstDescriptionDetails As New List(Of clsFrwdgDocsDescription)
    Property _DescriptionDetails As List(Of clsFrwdgDocsDescription)
        Get
            Return lstDescriptionDetails
        End Get
        Set(value As List(Of clsFrwdgDocsDescription))
            lstDescriptionDetails = value
        End Set
    End Property

    Private lstFreightChargeDetails As New List(Of clsFrwdgDocsFreightAndCharge)
    Property _FreightChargeDetails As List(Of clsFrwdgDocsFreightAndCharge)
        Get
            Return lstFreightChargeDetails
        End Get
        Set(value As List(Of clsFrwdgDocsFreightAndCharge))
            lstFreightChargeDetails = value
        End Set
    End Property

    Private lstBodyDetails As New List(Of clsFrwdgDocsBody)
    Property _BodyDetails As List(Of clsFrwdgDocsBody)
        Get
            Return lstBodyDetails
        End Get
        Set(value As List(Of clsFrwdgDocsBody))
            lstBodyDetails = value
        End Set
    End Property
End Class

Public Class clsFrwdgDocsBooking
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private lngFrwdgDocsID As Long
    Property _FrwdgDocsID As Long
        Get
            Return lngFrwdgDocsID
        End Get
        Set(value As Long)
            lngFrwdgDocsID = value
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

    Private strBookingPrefix As String
    Property _BookingPrefix As String
        Get
            Return strBookingPrefix
        End Get
        Set(value As String)
            strBookingPrefix = value
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
End Class

Public Class clsFrwdgDocsContainer
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

    Private strDataDiv As String
    Property _DataDiv As String
        Get
            Return strDataDiv
        End Get
        Set(value As String)
            strDataDiv = value
        End Set
    End Property

    Private strItemLines As String
    Property _ItemLines As String
        Get
            Return strItemLines
        End Get
        Set(value As String)
            strItemLines = value
        End Set
    End Property

    Private strContainerSize As String
    Property _ContainerSize As String
        Get
            Return strContainerSize
        End Get
        Set(value As String)
            strContainerSize = value
        End Set
    End Property

    Private strContainerType As String
    Property _ContainerType As String
        Get
            Return strContainerType
        End Get
        Set(value As String)
            strContainerType = value
        End Set
    End Property

    Private strContainerNumber As String
    Property _ContainerNumber As String
        Get
            Return strContainerNumber
        End Get
        Set(value As String)
            strContainerNumber = value
        End Set
    End Property

    Private strSealNumber As String
    Property _SealNumber As String
        Get
            Return strSealNumber
        End Get
        Set(value As String)
            strSealNumber = value
        End Set
    End Property

    Private strGrossWeightKGMInteger As String
    Property _GrossWeightKGMInteger As String
        Get
            Return strGrossWeightKGMInteger
        End Get
        Set(value As String)
            strGrossWeightKGMInteger = value
        End Set
    End Property

    Private strGrossWeightKGMFraction As String
    Property _GrossWeightKGMFraction As String
        Get
            Return strGrossWeightKGMFraction
        End Get
        Set(value As String)
            strGrossWeightKGMFraction = value
        End Set
    End Property

    Private strMeasurementInteger As String
    Property _MeasurementInteger As String
        Get
            Return strMeasurementInteger
        End Get
        Set(value As String)
            strMeasurementInteger = value
        End Set
    End Property

    Private strMeasurementFraction As String
    Property _MeasurementFraction As String
        Get
            Return strMeasurementFraction
        End Get
        Set(value As String)
            strMeasurementFraction = value
        End Set
    End Property

    Private strQuantity As String
    Property _Quantity As String
        Get
            Return strQuantity
        End Get
        Set(value As String)
            strQuantity = value
        End Set
    End Property
End Class

Public Class clsFrwdgDocsMarksAndNumbers
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

    Private strDataDiv As String
    Property _DataDiv As String
        Get
            Return strDataDiv
        End Get
        Set(value As String)
            strDataDiv = value
        End Set
    End Property

    Private strItemLines As String
    Property _ItemLines As String
        Get
            Return strItemLines
        End Get
        Set(value As String)
            strItemLines = value
        End Set
    End Property

    Private strMarksAndNumbers As String
    Property _MarksAndNumbers As String
        Get
            Return strMarksAndNumbers
        End Get
        Set(value As String)
            strMarksAndNumbers = value
        End Set
    End Property
End Class

Public Class clsFrwdgDocsDescription
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

    Private strDataDiv As String
    Property _DataDiv As String
        Get
            Return strDataDiv
        End Get
        Set(value As String)
            strDataDiv = value
        End Set
    End Property

    Private strItemLines As String
    Property _ItemLines As String
        Get
            Return strItemLines
        End Get
        Set(value As String)
            strItemLines = value
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
End Class

Public Class clsFrwdgDocsFreightAndCharge
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

    Private strDataDiv As String
    Property _DataDiv As String
        Get
            Return strDataDiv
        End Get
        Set(value As String)
            strDataDiv = value
        End Set
    End Property

    Private strItemLines As String
    Property _ItemLines As String
        Get
            Return strItemLines
        End Get
        Set(value As String)
            strItemLines = value
        End Set
    End Property

    Private strChargeName As String
    Property _ChargeName As String
        Get
            Return strChargeName
        End Get
        Set(value As String)
            strChargeName = value
        End Set
    End Property

    Private strCurrency As String
    Property _Currency As String
        Get
            Return strCurrency
        End Get
        Set(value As String)
            strCurrency = value
        End Set
    End Property

    Private strUnitPrice As String
    Property _UnitPrice As String
        Get
            Return strUnitPrice
        End Get
        Set(value As String)
            strUnitPrice = value
        End Set
    End Property

    Private strQuantity As String
    Property _Quantity As String
        Get
            Return strQuantity
        End Get
        Set(value As String)
            strQuantity = value
        End Set
    End Property
End Class

Public Class clsFrwdgDocsBody
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

    Private strDataDiv As String
    Property _DataDiv As String
        Get
            Return strDataDiv
        End Get
        Set(value As String)
            strDataDiv = value
        End Set
    End Property

    Private strItemLines As String
    Property _ItemLines As String
        Get
            Return strItemLines
        End Get
        Set(value As String)
            strItemLines = value
        End Set
    End Property

    Private strMarksAndNumbers As String
    Property _MarksAndNumbers As String
        Get
            Return strMarksAndNumbers
        End Get
        Set(value As String)
            strMarksAndNumbers = value
        End Set
    End Property

    Private strPKGS As String
    Property _PKGS As String
        Get
            Return strPKGS
        End Get
        Set(value As String)
            strPKGS = value
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

    Private strFree As String
    Property _Free As String
        Get
            Return strFree
        End Get
        Set(value As String)
            strFree = value
        End Set
    End Property

    Private strGrossWeight As String
    Property _GrossWeight As String
        Get
            Return strGrossWeight
        End Get
        Set(value As String)
            strGrossWeight = value
        End Set
    End Property

    Private strMeasurement As String
    Property _Measurement As String
        Get
            Return strMeasurement
        End Get
        Set(value As String)
            strMeasurement = value
        End Set
    End Property
End Class
