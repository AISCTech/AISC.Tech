Public Class clsDBImportBooking

    Private clsImpBook As New clsImportBookingHeader
    Property _ImportBookingRecord As clsImportBookingHeader
        Get
            Return clsImpBook
        End Get
        Set(value As clsImportBookingHeader)
            clsImpBook = value
        End Set
    End Property

    Public Sub SaveRecord(ByVal clsTempImpBook As clsImportBookingHeader)

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_importbookingheadersave"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsTempImpBook
                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_BookingNo", ._BookingNo)
                cmdSQL.Parameters("@p_BookingNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_BookingPrefix", ._BookingPrefix)
                cmdSQL.Parameters("@p_BookingPrefix").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_HouseBL", ._HouseBL)
                cmdSQL.Parameters("@p_HouseBL").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CompanyCode", ._CompanyCode)
                cmdSQL.Parameters("@p_CompanyCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SiteCode", ._SiteCode)
                cmdSQL.Parameters("@p_SiteCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperCode", ._ShipperCode)
                cmdSQL.Parameters("@p_ShipperCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeCode", ._ConsigneeCode)
                cmdSQL.Parameters("@p_ConsigneeCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsignorCode", ._ConsignorCode)
                cmdSQL.Parameters("@p_ConsignorCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ForwarderCode", ._ForwarderCode)
                cmdSQL.Parameters("@p_ForwarderCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShippingLineCode", ._ShippingLineCode)
                cmdSQL.Parameters("@p_ShippingLineCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_DescriptionOfGoods", ._DescriptionOfGoods)
                cmdSQL.Parameters("@p_DescriptionOfGoods").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Weight", ._Weight)
                cmdSQL.Parameters("@p_Weight").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Volume", ._Volume)
                cmdSQL.Parameters("@p_Volume").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NoOfPackage", ._NoOfPackage)
                cmdSQL.Parameters("@p_NoOfPackage").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PackageUnitID", ._PackageUnitID)
                cmdSQL.Parameters("@p_PackageUnitID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_OriginPortID", ._OriginPortID)
                cmdSQL.Parameters("@p_OriginPortID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_DestinationPortID", ._DestinationPortID)
                cmdSQL.Parameters("@p_DestinationPortID").Direction = ParameterDirection.Input

                If ._ETA = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_ETA", DBNull.Value)
                    cmdSQL.Parameters("@p_ETA").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_ETA", ._ETA)
                    cmdSQL.Parameters("@p_ETA").Direction = ParameterDirection.Input
                End If

                If ._ATA = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_ATA", DBNull.Value)
                    cmdSQL.Parameters("@p_ATA").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_ATA", ._ATA)
                    cmdSQL.Parameters("@p_ATA").Direction = ParameterDirection.Input
                End If

                cmdSQL.Parameters.AddWithValue("@p_VesselID", ._VesselID)
                cmdSQL.Parameters("@p_VesselID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Voyage", ._Voyage)
                cmdSQL.Parameters("@p_Voyage").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_DocsCompleted", ._DocsCompleted)
                cmdSQL.Parameters("@p_DocsCompleted").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_DocsCompletedDate", ._DocsCompletedDate)
                cmdSQL.Parameters("@p_DocsCompletedDate").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ImportPermitNo", ._ImportPermitNo)
                cmdSQL.Parameters("@p_ImportPermitNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_InvoiceNo", ._InvoiceNo)
                cmdSQL.Parameters("@p_InvoiceNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_RegistryNo", ._RegistryNo)
                cmdSQL.Parameters("@p_RegistryNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Remarks", ._Remarks)
                cmdSQL.Parameters("@p_Remarks").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModeOfTransportID", ._ModeOfTrasnsportID)
                cmdSQL.Parameters("@p_ModeOfTransportID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_LoadTypeID", ._LoadTypeID)
                cmdSQL.Parameters("@p_LoadTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_EntryTypeID", ._EntryTypeID)
                cmdSQL.Parameters("@p_EntryTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_FreightTermsID", ._FreightTermsID)
                cmdSQL.Parameters("@p_FreightTermsID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_AccountHolderID", ._AccountHolderID)
                cmdSQL.Parameters("@p_AccountHolderID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", ._PrepByID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModByID)
                cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.Parameters.AddWithValue("@p_BookingNo_Out", ._BookingPrefix)
                cmdSQL.Parameters("@p_BookingNo_Out").Direction = ParameterDirection.Output
            End With

            cmdSQL.ExecuteNonQuery()
            clsTempImpBook._ID = cmdSQL.Parameters("@p_ID_Out").Value
            clsTempImpBook._BookingNo = cmdSQL.Parameters("@p_BookingNo_Out").Value

            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "DELETE FROM tbl_import_booking_services WHERE BookingID = @BookingID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@BookingID", clsTempImpBook._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsImportBookingServices In clsTempImpBook._ServiceDetails
                cmdSQL.CommandText = "sp_importbookingservicessave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_BookingID", clsTempImpBook._ID)
                    cmdSQL.Parameters("@p_BookingID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ServiceID", ._ServiceID)
                    cmdSQL.Parameters("@p_ServiceID").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            cmdSQL.CommandText = "DELETE FROM tbl_import_booking_containers WHERE BookingID = @BookingID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@BookingID", clsTempImpBook._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsImportBookingContainers In clsTempImpBook._ContainerDetails
                cmdSQL.CommandText = "sp_importbookingcontainersave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_BookingID", clsTempImpBook._ID)
                    cmdSQL.Parameters("@p_BookingID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ContainerID", ._ContainerID)
                    cmdSQL.Parameters("@p_ContainerID").Direction = ParameterDirection.Input

                    If ._PickupDate = Nothing Then
                        cmdSQL.Parameters.AddWithValue("@p_PickUpDate", DBNull.Value)
                        cmdSQL.Parameters("@p_PickUpDate").Direction = ParameterDirection.Input
                    Else
                        cmdSQL.Parameters.AddWithValue("@p_PickUpDate", ._PickupDate)
                        cmdSQL.Parameters("@p_PickUpDate").Direction = ParameterDirection.Input
                    End If


                    If ._DeliveryDate = Nothing Then
                        cmdSQL.Parameters.AddWithValue("@p_DeliveryDate", DBNull.Value)
                        cmdSQL.Parameters("@p_DeliveryDate").Direction = ParameterDirection.Input
                    Else
                        cmdSQL.Parameters.AddWithValue("@p_DeliveryDate", ._DeliveryDate)
                        cmdSQL.Parameters("@p_DeliveryDate").Direction = ParameterDirection.Input
                    End If
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            trnSQL.Commit()
            cmdSQL.Dispose()

            clsImpBook.SearchRecord(clsTempImpBook._BookingNo, CurrentUser._Company_Code)
            MsgBox("Record saved!", MsgBoxStyle.Information, "System Message")
        Catch ex As Exception
            Try
                trnSQL.Rollback()
                MsgBox(ex.Message)
            Catch ex1 As Exception
                If Not trnSQL.Connection Is Nothing Then
                    MsgBox("An exception of type " & ex1.GetType().ToString() &
                      " was encountered while attempting to roll back the transaction.")
                End If
            End Try
        End Try
    End Sub
End Class


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
    ReadOnly Property _CompanyName As String
        Get
            Return strCompanyName
        End Get
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
    ReadOnly Property _SiteName As String
        Get
            Return strSiteName
        End Get
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
    ReadOnly Property _ShipperName As String
        Get
            Return strShipperName
        End Get
    End Property

    Private strShipperAddress As String
    ReadOnly Property _ShipperAddress As String
        Get
            Return strShipperAddress
        End Get
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
    ReadOnly Property _ConsigneeName As String
        Get
            Return strConsigneeName
        End Get
    End Property

    Private strConsigneeAddress As String
    ReadOnly Property _ConsigneeAddress As String
        Get
            Return strConsigneeAddress
        End Get
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
    ReadOnly Property _ConsignorName As String
        Get
            Return strConsignorName
        End Get
    End Property

    Private strConsignorAddress As String
    ReadOnly Property _ConsignorAddress As String
        Get
            Return strConsignorAddress
        End Get
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
    ReadOnly Property _ForwarderName As String
        Get
            Return strForwarderName
        End Get
    End Property

    Private strForwarderAddress As String
    ReadOnly Property _ForwarderAddress As String
        Get
            Return strForwarderAddress
        End Get
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
    ReadOnly Property _ShippingLineName As String
        Get
            Return strShippingLineName
        End Get
    End Property

    Private strShippingLineAddress As String
    ReadOnly Property _ShippingLineAddress As String
        Get
            Return strShippingLineAddress
        End Get
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
    ReadOnly Property _PackageUnitName As String
        Get
            Return strPackageUnitName
        End Get
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
    ReadOnly Property _OriginPortName As String
        Get
            Return strOriginPortName
        End Get
    End Property

    Private strOriginCountryName As String
    ReadOnly Property _OriginCountryName As String
        Get
            Return strOriginCountryName
        End Get
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
    ReadOnly Property _DestinationPortName As String
        Get
            Return strDestinationPortName
        End Get
    End Property

    Private strDestinationCountryName As String
    ReadOnly Property _DestinationCountryName As String
        Get
            Return strDestinationCountryName
        End Get
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
    ReadOnly Property _VesselName As String
        Get
            Return strVesselName
        End Get
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
    Property _ModeOfTrasnsportID As Integer
        Get
            Return intModeOfTransportID
        End Get
        Set(value As Integer)
            intModeOfTransportID = value
        End Set
    End Property

    Private strModeOfTransportName As String
    ReadOnly Property _ModeOfTransportName As String
        Get
            Return intModeOfTransportID
        End Get
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
    ReadOnly Property _LoadTypeName As String
        Get
            Return strLoadTypeName
        End Get
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
    ReadOnly Property _EntryTypeName As String
        Get
            Return strEntryTypeName
        End Get
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
    ReadOnly Property _FreightTermsName As String
        Get
            Return strFreightTermsName
        End Get
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
    ReadOnly Property _AccountHolderFullName As String
        Get
            Return strAccountHolderName
        End Get
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
    ReadOnly Property _StatusName As String
        Get
            Return strStatusName
        End Get
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
    ReadOnly Property _PrepByFullName As String
        Get
            Return strPrepByFullName
        End Get
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
    ReadOnly Property _ModByFullName As String
        Get
            Return strModByFullName
        End Get
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
    ReadOnly Property _StatusByFullName As String
        Get
            Return strStatusByFullName
        End Get
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

    Public Function SearchRecord(ByVal strTempBookingNo As String, ByVal strTempCompanyCode As String) As Boolean
        SearchRecord = False
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_importbookingheader WHERE BookingNo = @BookingNo AND CompanyCode = @CompanyCode"
            With cmdSQL.Parameters
                .AddWithValue("@BookingNo", strTempBookingNo)
                .AddWithValue("@CompanyCode", strTempCompanyCode)
            End With

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            If reader.HasRows = False Then
                MsgBox("Booking no. does not exist!", MsgBoxStyle.Information, "System Message")
                reader.Close()
                Exit Function
            Else
                SearchRecord = True
            End If

            While reader.Read
                lngID = reader.Item("ID")
                strBookingNo = reader.Item("BookingNo")
                strBookingPrefix = reader.Item("BookingPrefix")
                strHouseBL = reader.Item("HouseBL")
                strCompanyCode = reader.Item("CompanyCode")
                strCompanyName = reader.Item("Company_Name")
                strSiteCode = reader.Item("SiteCode")
                strSiteName = reader.Item("Site_Name")
                strShipperCode = reader.Item("ShipperCode")
                strShipperName = reader.Item("ShipperName")
                strShipperAddress = reader.Item("ShipperAddr1") & " " & reader.Item("ShipperAddrCity") & " " & reader.Item("ShipperAddrCountry")
                strShipperAddress = System.Text.RegularExpressions.Regex.Replace(strShipperAddress, "\s{2,}", " ").ToUpper
                strConsigneeCode = reader.Item("ConsigneeCode")
                strConsigneeName = reader.Item("ConsigneeName")
                strConsigneeAddress = reader.Item("ConsigneeAddr1") & " " & reader.Item("ConsigneeAddrCity") & " " & reader.Item("ConsigneeAddrCountry")
                strConsigneeAddress = System.Text.RegularExpressions.Regex.Replace(strConsigneeAddress, "\s{2,}", " ").ToUpper
                strConsignorCode = reader.Item("ConsignorCode")
                strConsignorName = reader.Item("ConsignorName")
                strConsignorAddress = reader.Item("ConsignorAddr1") & " " & reader.Item("ConsignorAddrCity") & " " & reader.Item("ConsignorAddrCountry")
                strConsignorAddress = System.Text.RegularExpressions.Regex.Replace(strConsignorAddress, "\s{2,}", " ").ToUpper
                strForwarderCode = reader.Item("ForwarderCode")
                strForwarderName = reader.Item("ForwarderName")
                strForwarderAddress = reader.Item("ForwarderAddr1") & " " & reader.Item("ForwarderAddrCity") & " " & reader.Item("ForwarderAddrCountry")
                strForwarderAddress = System.Text.RegularExpressions.Regex.Replace(strForwarderAddress, "\s{2,}", " ").ToUpper
                strShippingLineCode = reader.Item("ShippingLineCode")
                strShippingLineName = reader.Item("ShippingLineName")
                strDescriptionOfGoods = reader.Item("DescriptionOfGoods")
                dblWeight = reader.Item("Weight")
                dblVolume = reader.Item("Volume")
                dblNoOfPackage = reader.Item("NoOfPackage")
                intPackageUnitID = reader.Item("PackageUnitID")
                strPackageUnitName = reader.Item("PackageUnitName")
                intOriginPortID = reader.Item("OriginPortID")
                strOriginPortName = reader.Item("OriginPortName")
                strOriginCountryName = CStr(reader.Item("OriginPortCountry")).ToUpper
                intDestinationPortID = reader.Item("DestinationPortID")
                strDestinationPortName = reader.Item("DestinationPortName")
                strDestinationCountryName = CStr(reader.Item("DestinationPortCountry")).ToUpper
                If IsDBNull(reader.Item("ETA")) Then
                    dtETA = Nothing
                Else
                    dtETA = reader.Item("ETA")
                End If
                If IsDBNull(reader.Item("ATA")) Then
                    dtATA = Nothing
                Else
                    dtATA = reader.Item("ATA")
                End If
                lngVesselID = reader.Item("VesselID")
                strVesselName = reader.Item("VesselName")
                strVoyage = reader.Item("Voyage")
                blDocsCompleted = reader.Item("DocsCompleted")
                dtDocsCompletedDate = reader.Item("DocsCompletedDate")
                strImportPermitNo = reader.Item("ImportPermitNo")
                strInvoiceNo = reader.Item("InvoiceNo")
                strRegistryNo = reader.Item("RegistryNo")
                strRemarks = reader.Item("Remarks")
                intModeOfTransportID = reader.Item("ModeOfTransportID")
                strModeOfTransportName = reader.Item("ModeOfTransportName")
                intLoadTypeID = reader.Item("LoadTypeID")
                strLoadTypeName = reader.Item("LoadTypeName")
                intEntryTypeID = reader.Item("EntryTypeID")
                strEntryTypeName = reader.Item("EntryTypeName")
                intFreightTermsID = reader.Item("FreightTermsID")
                strFreightTermsName = reader.Item("FreightTermsName")
                'strAccountHolderID = reader.Item("AccountHolderID")
                'strAccountHolderName = reader.Item("AccountHolderName")
                intStatusID = reader.Item("StatusID")
                strStatusName = reader.Item("Status_Name")
                strPrepByID = reader.Item("PrepByID")
                strPrepByFullName = reader.Item("PrepFirstName") & " " & reader.Item("PrepLastName")
                dtPrepDate = reader.Item("PrepDate")
                strModByID = reader.Item("ModByID")
                strModByFullName = reader.Item("ModFirstName") & " " & reader.Item("ModLastName")
                dtModDate = reader.Item("ModDate")
                strStatusByID = reader.Item("StatusByID")
                strStatusByFullName = reader.Item("StatusFirstName") & " " & reader.Item("StatusLastName")
                dtStatusDate = reader.Item("StatusDate")
            End While

            reader.Close()
            cmdSQL.Parameters.Clear()

            Dim clsTempServ As New clsImportBookingServices
            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_importbookingservices WHERE BookingID = @BookingID"
            cmdSQL.Parameters.AddWithValue("@BookingID", lngID)

            reader = cmdSQL.ExecuteReader

            While reader.Read
                clsTempServ = New clsImportBookingServices
                With clsTempServ
                    ._ID = reader.Item("ID")
                    ._BookingID = reader.Item("BookingID")
                    ._ServiceID = reader.Item("ServiceID")
                    ._ServiceDescription = reader.Item("ServiceName")
                End With

                lstclsServices.Add(clsTempServ)
            End While

            reader.Close()
            cmdSQL.Parameters.Clear()

            Dim clsTempCont As New clsImportBookingContainers
            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_importbookingcontainers WHERE BookingID = @BookingID"
            cmdSQL.Parameters.AddWithValue("@BookingID", lngID)

            reader = cmdSQL.ExecuteReader

            While reader.Read
                clsTempCont = New clsImportBookingContainers
                With clsTempCont
                    ._ID = reader.Item("ID")
                    ._BookingID = reader.Item("BookingID")
                    ._ContainerID = reader.Item("ContainerID")
                    ._ContainerNo = reader.Item("ContainerNo")
                    ._ContainerSizeID = reader.Item("ContainerSizeID")
                    ._ContainerSizeName = reader.Item("ContainerSizeName")
                    If IsDBNull(reader.Item("PickUpDate")) Then
                        ._PickupDate = Nothing
                    Else
                        ._PickupDate = reader.Item("PickUpDate")
                    End If
                    If IsDBNull(reader.Item("DeliveryDate")) Then
                        ._DeliveryDate = Nothing
                    Else
                        ._DeliveryDate = reader.Item("DeliveryDate")
                    End If
                End With

                lstclsContainers.Add(clsTempCont)
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
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

Public Class ImportBookingDocuments

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
End Class
