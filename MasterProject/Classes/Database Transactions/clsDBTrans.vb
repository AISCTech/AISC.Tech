Public Class clsDBTrans

#Region "Customer Service Import"
    Public Function CustomerServiceImportSave(ByVal clsTempImpBook As clsImportBookingHeader) As clsImportBookingHeader
        CustomerServiceImportSave = New clsImportBookingHeader
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

                cmdSQL.Parameters.AddWithValue("@p_ImportPermitNo", ._ImportPermitNo)
                cmdSQL.Parameters("@p_ImportPermitNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_InvoiceNo", ._InvoiceNo)
                cmdSQL.Parameters("@p_InvoiceNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_RegistryNo", ._RegistryNo)
                cmdSQL.Parameters("@p_RegistryNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Remarks", ._Remarks)
                cmdSQL.Parameters("@p_Remarks").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModeOfTransportID", ._ModeOfTransportID)
                cmdSQL.Parameters("@p_ModeOfTransportID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_LoadTypeID", ._LoadTypeID)
                cmdSQL.Parameters("@p_LoadTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_EntryTypeID", ._EntryTypeID)
                cmdSQL.Parameters("@p_EntryTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_FreightTermsID", ._FreightTermsID)
                cmdSQL.Parameters("@p_FreightTermsID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_WarehouseID", ._WarehouseID)
                cmdSQL.Parameters("@p_WarehouseID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_AccountTypeID", ._AccountTypeID)
                cmdSQL.Parameters("@p_AccountTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_AccountHolderID", ._AccountHolderID)
                cmdSQL.Parameters("@p_AccountHolderID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_IfBrkg", ._IfBrkg)
                cmdSQL.Parameters("@p_IfBrkg").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_BrkgID", ._BrkgDetails._ID)
                cmdSQL.Parameters("@p_BrkgID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", ._PrepByID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModByID)
                cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_StatusByID", ._StatusByID)
                cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

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

                    cmdSQL.Parameters.AddWithValue("@p_Selected", ._Selected)
                    cmdSQL.Parameters("@p_Selected").Direction = ParameterDirection.Input
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
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            cmdSQL.CommandText = "DELETE FROM tbl_import_booking_documents WHERE BookingID = @BookingID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@BookingID", clsTempImpBook._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsImportBookingDocuments In clsTempImpBook._DocumentDetails
                cmdSQL.CommandText = "sp_importbookingdocumentsave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_BookingID", clsTempImpBook._ID)
                    cmdSQL.Parameters("@p_BookingID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_DocumentID", ._DocumentID)
                    cmdSQL.Parameters("@p_DocumentID").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            trnSQL.Commit()
            cmdSQL.Dispose()

            clsTempImpBook = CustomerServiceImportSearch(clsTempImpBook._BookingNo, clsTempImpBook._CompanyCode)
            CustomerServiceImportSave = clsTempImpBook
            MsgBox("Record saved!", MsgBoxStyle.Information, "System Message")
        Catch ex As Exception
            CustomerServiceImportSave = Nothing
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
    End Function

    Public Function CustomerServiceImportSearch(ByVal strTempBookingNo As String, ByVal strTempCompanyCode As String) As clsImportBookingHeader
        CustomerServiceImportSearch = New clsImportBookingHeader
        Try
            Dim clsTempHead As New clsImportBookingHeader
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
                CustomerServiceImportSearch = Nothing
                reader.Close()
                Exit Function
            End If

            While reader.Read
                With clsTempHead
                    ._ID = reader.Item("ID")
                    ._BookingNo = reader.Item("BookingNo")
                    ._BookingPrefix = reader.Item("BookingPrefix")
                    ._HouseBL = reader.Item("HouseBL")
                    ._CompanyCode = reader.Item("CompanyCode")
                    ._CompanyName = reader.Item("Company_Name")
                    ._SiteCode = reader.Item("SiteCode")
                    ._SiteName = reader.Item("Site_Name")
                    ._ShipperCode = reader.Item("ShipperCode")
                    ._ShipperName = reader.Item("ShipperName")
                    ._ShipperAddress = reader.Item("ShipperAddr1") & " " & reader.Item("ShipperAddrCity") & " " & reader.Item("ShipperAddrCountry")
                    ._ShipperAddress = System.Text.RegularExpressions.Regex.Replace(._ShipperAddress, "\s{2,}", " ").ToUpper
                    ._ConsigneeCode = reader.Item("ConsigneeCode")
                    ._ConsigneeName = reader.Item("ConsigneeName")
                    ._ConsigneeAddress = reader.Item("ConsigneeAddr1") & " " & reader.Item("ConsigneeAddrCity") & " " & reader.Item("ConsigneeAddrCountry")
                    ._ConsigneeAddress = System.Text.RegularExpressions.Regex.Replace(._ConsigneeAddress, "\s{2,}", " ").ToUpper
                    ._ConsignorCode = reader.Item("ConsignorCode")
                    ._ConsignorName = reader.Item("ConsignorName")
                    ._ConsignorAddress = reader.Item("ConsignorAddr1") & " " & reader.Item("ConsignorAddrCity") & " " & reader.Item("ConsignorAddrCountry")
                    ._ConsignorAddress = System.Text.RegularExpressions.Regex.Replace(._ConsignorAddress, "\s{2,}", " ").ToUpper
                    ._ForwarderCode = reader.Item("ForwarderCode")
                    ._ForwarderName = reader.Item("ForwarderName")
                    ._ForwarderAddress = reader.Item("ForwarderAddr1") & " " & reader.Item("ForwarderAddrCity") & " " & reader.Item("ForwarderAddrCountry")
                    ._ForwarderAddress = System.Text.RegularExpressions.Regex.Replace(._ForwarderAddress, "\s{2,}", " ").ToUpper
                    ._ShippingLineCode = _NotNull(reader.Item("ShippingLineCode"), "")
                    ._ShippingLineName = _NotNull(reader.Item("ShippingLineName"), "")
                    ._DescriptionOfGoods = reader.Item("DescriptionOfGoods")
                    ._Weight = reader.Item("Weight")
                    ._Volume = reader.Item("Volume")
                    ._NoOfPackage = reader.Item("NoOfPackage")
                    ._PackageUnitID = reader.Item("PackageUnitID")
                    ._PackageUnitName = reader.Item("PackageUnitName")
                    ._OriginPortID = reader.Item("OriginPortID")
                    ._OriginPortName = reader.Item("OriginPortName")
                    ._OriginCountryName = CStr(reader.Item("OriginPortCountry")).ToUpper
                    ._DestinationPortID = reader.Item("DestinationPortID")
                    ._DestinationPortName = reader.Item("DestinationPortName")
                    ._DestinationCountryName = CStr(reader.Item("DestinationPortCountry")).ToUpper
                    If IsDBNull(reader.Item("ETA")) Then
                        ._ETA = Nothing
                    Else
                        ._ETA = reader.Item("ETA")
                    End If
                    If IsDBNull(reader.Item("ATA")) Then
                        ._ATA = Nothing
                    Else
                        ._ATA = reader.Item("ATA")
                    End If
                    ._VesselID = reader.Item("VesselID")
                    ._VesselName = _NotNull(reader.Item("VesselName"), "")
                    ._Voyage = reader.Item("Voyage")
                    ._DocsCompleted = reader.Item("DocsCompleted")
                    If IsDBNull(reader.Item("DocsCompletedDate")) Then
                        ._DocsCompletedDate = Nothing
                    Else
                        ._DocsCompletedDate = reader.Item("DocsCompletedDate")
                    End If
                    ._ImportPermitNo = reader.Item("ImportPermitNo")
                    ._InvoiceNo = reader.Item("InvoiceNo")
                    ._RegistryNo = reader.Item("RegistryNo")
                    ._Remarks = reader.Item("Remarks")
                    ._ModeOfTransportID = reader.Item("ModeOfTransportID")
                    ._ModeOfTransportName = _NotNull(reader.Item("ModeOfTransportName"), "")
                    ._LoadTypeID = reader.Item("LoadTypeID")
                    ._LoadTypeName = _NotNull(reader.Item("LoadTypeName"), "")
                    ._EntryTypeID = reader.Item("EntryTypeID")
                    ._EntryTypeName = _NotNull(reader.Item("EntryTypeName"), "")
                    ._FreightTermsID = reader.Item("FreightTermsID")
                    ._FreightTermsName = _NotNull(reader.Item("FreightTermsName"), "")
                    ._WarehouseID = reader.Item("WarehouseID")
                    ._WarehouseName = _NotNull(reader.Item("WarehouseName"), "")
                    ._AccountTypeID = reader.Item("AccountTypeID")
                    ._AccountTypePrefix = reader.Item("AccountTypePrefix")
                    ._AccountTypeDesc = reader.Item("AccountTypeDescription")
                    ._AccountHolderID = reader.Item("AccountHolderID")
                    ._AccountHolderFullName = reader.Item("AccountHolderFirstName") & " " & reader.Item("AccountHolderLastName")
                    ._BrkgDetails._ID = _NotNull(reader.Item("BrkgID"), 0)
                    ._StatusID = reader.Item("StatusID")
                    ._StatusName = reader.Item("Status_Name")
                    ._PrepByID = reader.Item("PrepByID")
                    ._PrepByFullName = reader.Item("PrepFirstName") & " " & reader.Item("PrepLastName")
                    ._PrepDate = reader.Item("PrepDate")
                    ._ModByID = reader.Item("ModByID")
                    ._ModByFullName = reader.Item("ModFirstName") & " " & reader.Item("ModLastName")
                    ._ModDate = reader.Item("ModDate")
                    ._StatusByID = reader.Item("StatusByID")
                    ._StatusByFullName = reader.Item("StatusFirstName") & " " & reader.Item("StatusLastName")
                    ._StatusDate = reader.Item("StatusDate")
                End With
            End While

            reader.Close()
            cmdSQL.Parameters.Clear()

            Dim clsTempServ As New clsImportBookingServices
            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_importbookingservices WHERE BookingID = @BookingID"
            cmdSQL.Parameters.AddWithValue("@BookingID", clsTempHead._ID)

            reader = cmdSQL.ExecuteReader

            While reader.Read
                clsTempServ = New clsImportBookingServices
                With clsTempServ
                    ._ID = reader.Item("ID")
                    ._BookingID = reader.Item("BookingID")
                    ._ServiceID = reader.Item("ServiceID")
                    ._ServiceDescription = reader.Item("ServiceName")
                    ._Selected = reader.Item("Selected")
                End With

                clsTempHead._ServiceDetails.Add(clsTempServ)
            End While

            reader.Close()
            cmdSQL.Parameters.Clear()

            Dim clsTempCont As New clsImportBookingContainers
            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_importbookingcontainers WHERE BookingID = @BookingID"
            cmdSQL.Parameters.AddWithValue("@BookingID", clsTempHead._ID)

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
                End With

                clsTempHead._ContainerDetails.Add(clsTempCont)
            End While

            reader.Close()
            cmdSQL.Parameters.Clear()

            Dim clsTempDocs As New clsImportBookingDocuments
            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_importbookingdocuments WHERE BookingID = @BookingID"
            cmdSQL.Parameters.AddWithValue("@BookingID", clsTempHead._ID)

            reader = cmdSQL.ExecuteReader

            While reader.Read
                clsTempDocs = New clsImportBookingDocuments
                With clsTempDocs
                    ._ID = reader.Item("ID")
                    ._BookingID = reader.Item("BookingID")
                    ._DocumentID = reader.Item("DocumentID")
                    ._DocumentName = reader.Item("DocumentName")
                End With

                clsTempHead._DocumentDetails.Add(clsTempDocs)
            End While

            reader.Close()
            cmdSQL.Dispose()

            If clsTempHead._BrkgDetails._ID > 0 Then
                clsTempHead._BrkgDetails = BrokerageJOSearch(clsTempHead._BrkgDetails._ID)
            End If

            CustomerServiceImportSearch = clsTempHead
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
#End Region

#Region "Customer Service Export"
    Public Function CustomerServiceExportMasterSave(ByVal clsTempExpMaster As clsExportMasterBooking) As clsExportMasterBooking
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_exportmasterheadersave"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsTempExpMaster
                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_RefNo", ._RefNo)
                cmdSQL.Parameters("@p_RefNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Company_Code", ._CompanyDetails._Company_Code)
                cmdSQL.Parameters("@p_Company_Code").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CarrierCode", ._CarrierDetails._Code)
                cmdSQL.Parameters("@p_CarrierCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_OriginID", ._OriginDetails._PK)
                cmdSQL.Parameters("@p_OriginID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_DestinationID", ._DestinationDetails._PK)
                cmdSQL.Parameters("@p_DestinationID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModeOfTransportID", ._ModeOfTransportDetails._PK)
                cmdSQL.Parameters("@p_ModeOfTransportID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_LoadedPullOut", ._LoadedPullOut)
                cmdSQL.Parameters("@p_LoadedPullOut").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ContainerYard", ._ContainerYard)
                cmdSQL.Parameters("@p_ContainerYard").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_WarehouseID", ._WarehouseDetails._ID)
                cmdSQL.Parameters("@p_WarehouseID").Direction = ParameterDirection.Input

                If ._ETD._DateValue = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_ETD", DBNull.Value)
                    cmdSQL.Parameters("@p_ETD").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_ETD", ._ETD._DateValue)
                    cmdSQL.Parameters("@p_ETD").Direction = ParameterDirection.Input
                End If

                If ._ATD._DateValue = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_ATD", DBNull.Value)
                    cmdSQL.Parameters("@p_ATD").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_ATD", ._ATD._DateValue)
                    cmdSQL.Parameters("@p_ATD").Direction = ParameterDirection.Input
                End If

                cmdSQL.Parameters.AddWithValue("@p_SealNo", ._SealNo)
                cmdSQL.Parameters("@p_SealNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_EmptyPositioning", ._EmptyPositioning)
                cmdSQL.Parameters("@p_EmptyPositioning").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ChassisDepot", ._ChassisDepot)
                cmdSQL.Parameters("@p_ChassisDepot").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_VesselID", ._VesselDetails._ID)
                cmdSQL.Parameters("@p_VesselID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_AirLineCode", ._AirlineDetails._Code)
                cmdSQL.Parameters("@p_AirLineCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_LCT", ._LCT)
                cmdSQL.Parameters("@p_LCT").Direction = ParameterDirection.Input

                If ._ETA._DateValue = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_ETA", DBNull.Value)
                    cmdSQL.Parameters("@p_ETA").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_ETA", ._ETA._DateValue)
                    cmdSQL.Parameters("@p_ETA").Direction = ParameterDirection.Input
                End If

                If ._ATA._DateValue = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_ATA", DBNull.Value)
                    cmdSQL.Parameters("@p_ATA").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_ATA", ._ATA._DateValue)
                    cmdSQL.Parameters("@p_ATA").Direction = ParameterDirection.Input
                End If

                cmdSQL.Parameters.AddWithValue("@p_LoadTypeID", ._LoadTypeDetails._PK)
                cmdSQL.Parameters("@p_LoadTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", ._PrepByDetails._User_ID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModByDetails._User_ID)
                cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.Parameters.AddWithValue("@p_RefNo_Out", ._RefNo)
                cmdSQL.Parameters("@p_RefNo_Out").Direction = ParameterDirection.Output

                cmdSQL.ExecuteNonQuery()
                ._ID = cmdSQL.Parameters("@p_ID_Out").Value
                ._RefNo = cmdSQL.Parameters("@p_RefNo_Out").Value

                cmdSQL.Parameters.Clear()

                cmdSQL.CommandText = "UPDATE tbl_export_booking_header SET MasterBookingID = 0 WHERE MasterBookingID = @MasterBookingID"
                cmdSQL.CommandType = CommandType.TableDirect
                cmdSQL.Parameters.AddWithValue("@MasterBookingID", ._ID)
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()

                For Each clsExp As clsExportBookingHeader In ._ListOfBookingDetails
                    cmdSQL.Connection = cnnDBMaster
                    cmdSQL.Transaction = trnSQL
                    cmdSQL.CommandText = "sp_exportmasterdetailssave"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_MasterBookingID", ._ID)
                    cmdSQL.Parameters("@p_MasterBookingID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModByDetails._User_ID)
                    cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsExp._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()
                    cmdSQL.Parameters.Clear()
                Next

                cmdSQL.CommandText = "DELETE FROM tbl_export_master_containers WHERE MasterID = @MasterID"
                cmdSQL.CommandType = CommandType.TableDirect
                cmdSQL.Parameters.AddWithValue("@MasterID", ._ID)
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()

                For Each clsTemp As clsExportMasterContainers In ._ListOfContainers
                    cmdSQL.CommandText = "sp_exportmastercontainersave"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_MasterID", ._ID)
                    cmdSQL.Parameters("@p_MasterID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ContainerID", clsTemp._ContainerID)
                    cmdSQL.Parameters("@p_ContainerID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()
                    cmdSQL.Parameters.Clear()
                Next
            End With

            trnSQL.Commit()
            cmdSQL.Dispose()
            Return clsTempExpMaster
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
            Return Nothing
        End Try
    End Function

    Public Function CustomerServiceExportMasterSearch(ByVal strRefNo As String, ByVal strCompanyCode As String) As clsExportMasterBooking
        Try
            Dim clsTemp As New clsExportMasterBooking
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_exportmaster WHERE `RefNo` = @RefNo AND `CompanyCode` = @CompanyCode"
            cmdSQL.Parameters.AddWithValue("@RefNo", strRefNo)
            cmdSQL.Parameters.AddWithValue("@CompanyCode", strCompanyCode)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTemp
                    ._ID = reader.Item("ID")
                    ._RefNo = reader.Item("RefNo")
                    With ._CompanyDetails
                        ._Company_Code = reader.Item("CompanyCode")
                        ._Company_Name = reader.Item("Company_Name")
                        ._Company_FullName = reader.Item("Company_FullName")
                    End With
                    With ._CarrierDetails
                        ._Code = _NotNull(reader.Item("CarrierCode"), "")
                        ._Description = _NotNull(reader.Item("CarrierName"), "")
                    End With
                    With ._OriginDetails
                        ._PK = _NotNull(reader.Item("OriginID"), -1)
                        ._CountryDetails._PK = _NotNull(reader.Item("OriginCountry_PK"), -1)
                        ._Description = _NotNull(reader.Item("OriginName"), "")
                    End With
                    With ._DestinationDetails
                        ._PK = _NotNull(reader.Item("DestinationID"), -1)
                        ._CountryDetails._PK = _NotNull(reader.Item("DestinationCountry_PK"), -1)
                        ._Description = _NotNull(reader.Item("DestinationName"), "")
                    End With
                    With ._ModeOfTransportDetails
                        ._PK = reader.Item("ModeOfTransportID")
                        ._Param_Desc = reader.Item("ModeOfTransportDesc")
                    End With
                    ._LoadedPullOut = _NotNull(reader.Item("LoadedPullOut"), "")
                    ._ContainerYard = _NotNull(reader.Item("ContainerYard"), "")
                    With ._WarehouseDetails
                        ._ID = _NotNull(reader.Item("WarehouseID"), -1)
                        ._WarehouseName = _NotNull(reader.Item("WarehouseName"), "")
                    End With
                    ._ETD._DateValue = _NotNull(reader.Item("ETD"), Nothing)
                    ._ATD._DateValue = _NotNull(reader.Item("ATD"), Nothing)
                    ._SealNo = _NotNull(reader.Item("SealNo"), "")
                    ._EmptyPositioning = _NotNull(reader.Item("EmptyPositioning"), "")
                    ._ChassisDepot = _NotNull(reader.Item("ChassisDepot"), "")
                    With ._VesselDetails
                        ._ID = _NotNull(reader.Item("VesselID"), -1)
                        ._VesselCode = _NotNull(reader.Item("VesselCode"), "")
                        ._VesselName = _NotNull(reader.Item("VesselName"), "")
                        ._NACCSUserCode = _NotNull(reader.Item("NACCSUserCode"), "")
                    End With
                    With ._AirlineDetails
                        ._Code = _NotNull(reader.Item("AirLineCode"), "")
                        ._Prefix = _NotNull(reader.Item("AirLinePrefix"), "")
                        ._Description = _NotNull(reader.Item("AirLineName"), "")
                    End With
                    ._LCT = _NotNull(reader.Item("LCT"), "")
                    ._ETA._DateValue = _NotNull(reader.Item("ETA"), Nothing)
                    ._ATA._DateValue = _NotNull(reader.Item("ATA"), Nothing)
                    With ._LoadTypeDetails
                        ._PK = _NotNull(reader.Item("LoadTypeID"), -1)
                        ._Param_Desc = _NotNull(reader.Item("LoadTypeDesc"), "")
                    End With
                    With ._StatusDetails
                        ._Status_ID = _NotNull(reader.Item("StatusID"), -1)
                        ._Status_Name = _NotNull(reader.Item("Status_Name"), "")
                        ._Status_ColorR = _NotNull(reader.Item("Status_ColorR"), -1)
                        ._Status_ColorG = _NotNull(reader.Item("Status_ColorG"), -1)
                        ._Status_ColorB = _NotNull(reader.Item("Status_ColorB"), -1)
                    End With
                    With ._StatusByDetails
                        ._User_ID = _NotNull(reader.Item("StatusByID"), "")
                        ._Last_Name = _NotNull(reader.Item("StatusByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("StatusByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("StatusByMiddle_Name"), "")
                    End With
                    ._StatusDate = _NotNull(reader.Item("StatusDate"), Nothing)
                    With ._PrepByDetails
                        ._User_ID = reader.Item("PrepByID")
                        ._Last_Name = reader.Item("PrepByLast_Name")
                        ._First_Name = reader.Item("PrepByFirst_Name")
                        ._Middle_Name = reader.Item("PrepByMiddle_Name")
                    End With
                    ._PrepDate = reader.Item("PrepDate")
                    With ._ModByDetails
                        ._User_ID = reader.Item("ModByID")
                        ._Last_Name = reader.Item("ModByLast_Name")
                        ._First_Name = reader.Item("ModByFirst_Name")
                        ._Middle_Name = reader.Item("ModByMiddle_Name")
                    End With
                    ._ModDate = reader.Item("ModDate")
                End With
            End While

            reader.Close()
            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "SELECT * FROM v_exportbookingheader WHERE `MasterBookingID` = @MasterBookingID"
            cmdSQL.Parameters.AddWithValue("@MasterBookingID", clsTemp._ID)
            reader = cmdSQL.ExecuteReader

            Dim clsExp As New clsExportBookingHeader
            While reader.Read
                With clsExp
                    ._ID = reader.Item("ID")
                    ._BookingNo = reader.Item("BookingNo")
                    ._BookingPrefix = reader.Item("BookingPrefix")
                    With ._CompanyDetails
                        ._Company_Code = reader.Item("CompanyCode")
                        ._Company_FullName = reader.Item("Company_FullName")
                    End With
                    With ._ConsignorDetails
                        ._Code = reader.Item("ConsignorCode")
                        ._Description = reader.Item("ConsignorName")
                        ._Addr1 = reader.Item("ConsignorAddr1")
                        ._AddrCity = reader.Item("ConsignorAddrCity")
                        ._AddrCountry = reader.Item("ConsignorAddrCountry")
                    End With
                    With ._SiteDetails
                        ._Site_Code = reader.Item("SiteCode")
                        ._Site_Name = reader.Item("Site_Name")
                    End With
                    With ._AccountTypeDetails
                        ._ID = reader.Item("AccountTypeID")
                        ._Prefix = reader.Item("AccountTypePrefix")
                        ._Description = reader.Item("AccountTypeDescription")
                    End With
                    With ._AccountHolderDetails
                        ._User_ID = reader.Item("AccountHolderID")
                        ._Last_Name = reader.Item("AccountHolderLast_Name")
                        ._First_Name = reader.Item("AccountHolderFirst_Name")
                        ._Middle_Name = reader.Item("AccountHolderMiddle_Name")
                    End With
                    With ._ShipperDetails
                        ._Code = reader.Item("ShipperCode")
                        ._Description = reader.Item("ShipperName")
                        ._Addr1 = reader.Item("ShipperAddr1")
                        ._AddrCity = reader.Item("ShipperAddrCity")
                        ._AddrCountry = reader.Item("ShipperAddrCountry")
                    End With
                    With ._ConsigneeDetails
                        ._Code = reader.Item("ConsigneeCode")
                        ._Description = reader.Item("ConsigneeName")
                        ._Addr1 = reader.Item("ConsigneeAddr1")
                        ._AddrCity = reader.Item("ConsigneeAddrCity")
                        ._AddrCountry = reader.Item("ConsigneeAddrCountry")
                    End With
                    With ._ModeOfTransportDetails
                        ._PK = reader.Item("ModeOfTransportID")
                        ._Param_Desc = reader.Item("ModeOfTransportDesc")
                    End With
                    With ._OriginDetails
                        ._PK = reader.Item("OriginID")
                        ._CountryDetails._PK = reader.Item("OriginCountry_PK")
                        ._Description = reader.Item("OriginName")
                    End With
                    With ._FinalDestinationDetails
                        ._PK = reader.Item("FinalDestinationID")
                        ._CountryDetails._PK = reader.Item("FinalDestinationCountry_PK")
                        ._Description = reader.Item("FinalDestinationName")
                    End With
                    ._Commodity = reader.Item("Commodity")
                    ._DangerousCargo = reader.Item("DangerousCargo")
                    ._GrossWeight = reader.Item("GrossWeight")
                    ._Volume = reader.Item("Volume")
                    With ._LoadTypeDetails
                        ._PK = reader.Item("LoadTypeID")
                        ._Param_Desc = reader.Item("LoadTypeDesc")
                    End With
                    ._NoOfPackage = reader.Item("NoOfPackage")
                    With ._PackageUnitDetails
                        ._PK = reader.Item("PackageUnitID")
                        ._Param_Desc = reader.Item("PackageUnitDesc")
                    End With
                    With ._ColoadToDetails
                        ._Code = _NotNull(reader.Item("CoLoadToID"), "")
                        ._Description = _NotNull(reader.Item("CoLoadToName"), "")
                    End With
                    ._ActualVolume = reader.Item("ActualVolume")
                    ._ActualGrossWeight = reader.Item("ActualGrossWeight")
                    ._RevisedMeasurement = reader.Item("RevisedMeasurement")
                    With ._RevisedMeasurementTypeDetails
                        ._PK = _NotNull(reader.Item("RevisedMeasurementTypeID"), "")
                        ._Param_Desc = _NotNull(reader.Item("RevisedMeasurementTypeDesc"), "")
                    End With
                    ._ApprovedPosting = reader.Item("ApprovedPosting")
                    ._KPIDate = _NotNull(reader.Item("KPIDate"), Nothing)
                    ._DocsCompleted = reader.Item("DocsCompleted")
                    ._DocsCompletedDate = _NotNull(reader.Item("DocsCompletedDate"), Nothing)
                    With ._MasterBookingDetails
                        ._ID = reader.Item("MasterBookingID")
                        ._RefNo = _NotNull(reader.Item("MasterBookingNo"), "")
                    End With
                    With ._StatusDetails
                        ._Status_ID = _NotNull(reader.Item("StatusID"), 0)
                        ._Status_Name = _NotNull(reader.Item("Status_Name"), "")
                        ._Status_ColorR = _NotNull(reader.Item("Status_ColorR"), 0)
                        ._Status_ColorG = _NotNull(reader.Item("Status_ColorG"), 0)
                        ._Status_ColorB = _NotNull(reader.Item("Status_ColorB"), 0)
                    End With
                    With ._StatusByDetails
                        ._User_ID = _NotNull(reader.Item("StatusByID"), "")
                        ._Last_Name = _NotNull(reader.Item("StatusByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("StatusByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("StatusByMiddle_Name"), "")
                    End With
                    ._StatusDate = _NotNull(reader.Item("StatusDate"), Nothing)
                    With ._PrepByDetails
                        ._User_ID = reader.Item("PrepByID")
                        ._Last_Name = reader.Item("PrepByLast_Name")
                        ._First_Name = reader.Item("PrepByFirst_Name")
                        ._Middle_Name = reader.Item("PrepByMiddle_Name")
                    End With
                    ._PrepDate = reader.Item("PrepDate")
                    With ._ModByDetails
                        ._User_ID = reader.Item("ModByID")
                        ._Last_Name = reader.Item("ModByLast_Name")
                        ._First_Name = reader.Item("ModByFirst_Name")
                        ._Middle_Name = reader.Item("ModByMiddle_Name")
                    End With
                    ._ModDate = reader.Item("ModDate")
                End With

                clsTemp._ListOfBookingDetails.Add(clsExp)
                clsExp = New clsExportBookingHeader
            End While

            reader.Close()
            cmdSQL.Parameters.Clear()

            Dim clsTempCont As New clsExportMasterContainers
            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_exportmastercontainers WHERE MasterID = @MasterID"
            cmdSQL.Parameters.AddWithValue("@MasterID", clsTemp._ID)

            reader = cmdSQL.ExecuteReader

            While reader.Read
                clsTempCont = New clsExportMasterContainers
                With clsTempCont
                    ._ID = reader.Item("ID")
                    ._MasterID = reader.Item("MasterID")
                    ._ContainerID = reader.Item("ContainerID")
                    ._ContainerNo = reader.Item("ContainerNo")
                    ._ContainerSizeID = reader.Item("ContainerSizeID")
                    ._ContainerSizeName = reader.Item("ContainerSizeName")
                End With

                clsTemp._ListOfContainers.Add(clsTempCont)
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clsTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CustomerServiceExportBookingSave(ByVal clsTempExpBook As clsExportBookingHeader) As clsExportBookingHeader
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_exportbookingheadersave"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsTempExpBook
                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_BookingNo", ._BookingNo)
                cmdSQL.Parameters("@p_BookingNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_BookingPrefix", ._BookingPrefix)
                cmdSQL.Parameters("@p_BookingPrefix").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CompanyCode", ._CompanyDetails._Company_Code)
                cmdSQL.Parameters("@p_CompanyCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsignorCode", ._ConsignorDetails._Code)
                cmdSQL.Parameters("@p_ConsignorCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SiteCode", ._SiteDetails._Site_Code)
                cmdSQL.Parameters("@p_SiteCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_AccountTypeID", ._AccountTypeDetails._ID)
                cmdSQL.Parameters("@p_AccountTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_AccountHolderID", ._AccountHolderDetails._User_ID)
                cmdSQL.Parameters("@p_AccountHolderID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperCode", ._ShipperDetails._Code)
                cmdSQL.Parameters("@p_ShipperCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeCode", ._ConsigneeDetails._Code)
                cmdSQL.Parameters("@p_ConsigneeCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModeOftransportID", ._ModeOfTransportDetails._PK)
                cmdSQL.Parameters("@p_ModeOftransportID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_OriginID", ._OriginDetails._PK)
                cmdSQL.Parameters("@p_OriginID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_FinalDestinationID", ._FinalDestinationDetails._PK)
                cmdSQL.Parameters("@p_FinalDestinationID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Commodity", ._Commodity)
                cmdSQL.Parameters("@p_Commodity").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_DangerousCargo", ._DangerousCargo)
                cmdSQL.Parameters("@p_DangerousCargo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_GrossWeight", ._GrossWeight)
                cmdSQL.Parameters("@p_GrossWeight").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Volume", ._Volume)
                cmdSQL.Parameters("@p_Volume").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_LoadTypeID", ._LoadTypeDetails._PK)
                cmdSQL.Parameters("@p_LoadTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NoOfPackage", ._NoOfPackage)
                cmdSQL.Parameters("@p_NoOfPackage").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PackageUnitID", ._PackageUnitDetails._PK)
                cmdSQL.Parameters("@p_PackageUnitID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CoLoadToID", ._ColoadToDetails._Code)
                cmdSQL.Parameters("@p_CoLoadToID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ActualVolume", ._ActualVolume)
                cmdSQL.Parameters("@p_ActualVolume").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ActualGrossWeight", ._ActualGrossWeight)
                cmdSQL.Parameters("@p_ActualGrossWeight").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_RevisedMeasurement", ._RevisedMeasurement)
                cmdSQL.Parameters("@p_RevisedMeasurement").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_RevisedMeasurementTypeID", ._RevisedMeasurementTypeDetails._PK)
                cmdSQL.Parameters("@p_RevisedMeasurementTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ApprovedPosting", ._ApprovedPosting)
                cmdSQL.Parameters("@p_ApprovedPosting").Direction = ParameterDirection.Input

                If ._KPIDate = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_KPIDate", DBNull.Value)
                    cmdSQL.Parameters("@p_KPIDate").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_KPIDate", ._KPIDate)
                    cmdSQL.Parameters("@p_KPIDate").Direction = ParameterDirection.Input
                End If

                cmdSQL.Parameters.AddWithValue("@p_DocsCompleted", ._DocsCompleted)
                cmdSQL.Parameters("@p_DocsCompleted").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_MasterBookingID", ._MasterBookingDetails._ID)
                cmdSQL.Parameters("@p_MasterBookingID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ColoadSequenceID", 0)
                cmdSQL.Parameters("@p_ColoadSequenceID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_IfBrkg", ._IfBrkg)
                cmdSQL.Parameters("@p_IfBrkg").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_BrkgID", ._BrkgDetails._ID)
                cmdSQL.Parameters("@p_BrkgID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", ._PrepByDetails._User_ID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModByDetails._User_ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.Parameters.AddWithValue("@p_BookingNo_Out", ._BookingNo)
                cmdSQL.Parameters("@p_BookingNo_Out").Direction = ParameterDirection.Output

                cmdSQL.ExecuteNonQuery()
                ._ID = cmdSQL.Parameters("@p_ID_Out").Value
                ._BookingNo = cmdSQL.Parameters("@p_BookingNo_Out").Value
            End With

            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "DELETE FROM tbl_export_booking_services WHERE BookingID = @BookingID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@BookingID", clsTempExpBook._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsExportBookingServices In clsTempExpBook._ServiceDetails
                cmdSQL.CommandText = "sp_exportbookingservicessave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_BookingID", clsTempExpBook._ID)
                    cmdSQL.Parameters("@p_BookingID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ServiceID", ._ServiceNameDetails._PK)
                    cmdSQL.Parameters("@p_ServiceID").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            cmdSQL.CommandText = "DELETE FROM tbl_export_booking_documents WHERE BookingID = @BookingID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@BookingID", clsTempExpBook._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsExportBookingDocuments In clsTempExpBook._DocumentDetails
                cmdSQL.CommandText = "sp_exportbookingdocumentsave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_BookingID", clsTempExpBook._ID)
                    cmdSQL.Parameters("@p_BookingID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_DocumentID", ._DocumentDetails._ID)
                    cmdSQL.Parameters("@p_DocumentID").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            trnSQL.Commit()
            cmdSQL.Dispose()

            Return clsTempExpBook
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

            Return Nothing
        End Try
    End Function

    Public Function CustomerServiceExportBookingSearch(ByVal strBookingNo As String, ByVal strCompanyCode As String) As clsExportBookingHeader
        Try
            Dim clsTempExport As New clsExportBookingHeader
            Dim clsTempServices As New clsExportBookingServices
            Dim clsTempDocuments As New clsExportBookingDocuments

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_exportbookingheader WHERE BookingNo = @BookingNo AND CompanyCode = @CompanyCode"
            With cmdSQL.Parameters
                .AddWithValue("@BookingNo", strBookingNo)
                .AddWithValue("@CompanyCode", strCompanyCode)
            End With

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTempExport
                    ._ID = reader.Item("ID")
                    ._BookingNo = reader.Item("BookingNo")
                    ._BookingPrefix = reader.Item("BookingPrefix")
                    With ._CompanyDetails
                        ._Company_Code = reader.Item("CompanyCode")
                        ._Company_FullName = reader.Item("Company_FullName")
                    End With
                    With ._ConsignorDetails
                        ._Code = reader.Item("ConsignorCode")
                        ._Description = reader.Item("ConsignorName")
                        ._Addr1 = reader.Item("ConsignorAddr1")
                        ._AddrCity = reader.Item("ConsignorAddrCity")
                        ._AddrCountry = reader.Item("ConsignorAddrCountry")
                    End With
                    With ._SiteDetails
                        ._Site_Code = reader.Item("SiteCode")
                        ._Site_Name = reader.Item("Site_Name")
                    End With
                    With ._AccountTypeDetails
                        ._ID = reader.Item("AccountTypeID")
                        ._Prefix = reader.Item("AccountTypePrefix")
                        ._Description = reader.Item("AccountTypeDescription")
                    End With
                    With ._AccountHolderDetails
                        ._User_ID = reader.Item("AccountHolderID")
                        ._Last_Name = reader.Item("AccountHolderLast_Name")
                        ._First_Name = reader.Item("AccountHolderFirst_Name")
                        ._Middle_Name = reader.Item("AccountHolderMiddle_Name")
                    End With
                    With ._ShipperDetails
                        ._Code = reader.Item("ShipperCode")
                        ._Description = reader.Item("ShipperName")
                        ._Addr1 = reader.Item("ShipperAddr1")
                        ._AddrCity = reader.Item("ShipperAddrCity")
                        ._AddrCountry = reader.Item("ShipperAddrCountry")
                    End With
                    With ._ConsigneeDetails
                        ._Code = reader.Item("ConsigneeCode")
                        ._Description = reader.Item("ConsigneeName")
                        ._Addr1 = reader.Item("ConsigneeAddr1")
                        ._AddrCity = reader.Item("ConsigneeAddrCity")
                        ._AddrCountry = reader.Item("ConsigneeAddrCountry")
                    End With
                    With ._ModeOfTransportDetails
                        ._PK = reader.Item("ModeOfTransportID")
                        ._Param_Desc = reader.Item("ModeOfTransportDesc")
                    End With
                    With ._OriginDetails
                        ._PK = reader.Item("OriginID")
                        ._CountryDetails._PK = reader.Item("OriginCountry_PK")
                        ._Description = reader.Item("OriginName")
                    End With
                    With ._FinalDestinationDetails
                        ._PK = reader.Item("FinalDestinationID")
                        ._CountryDetails._PK = reader.Item("FinalDestinationCountry_PK")
                        ._Description = reader.Item("FinalDestinationName")
                    End With
                    ._Commodity = reader.Item("Commodity")
                    ._DangerousCargo = reader.Item("DangerousCargo")
                    ._GrossWeight = reader.Item("GrossWeight")
                    ._Volume = reader.Item("Volume")
                    With ._LoadTypeDetails
                        ._PK = reader.Item("LoadTypeID")
                        ._Param_Desc = reader.Item("LoadTypeDesc")
                    End With
                    ._NoOfPackage = reader.Item("NoOfPackage")
                    With ._PackageUnitDetails
                        ._PK = reader.Item("PackageUnitID")
                        ._Param_Desc = reader.Item("PackageUnitDesc")
                    End With
                    With ._ColoadToDetails
                        ._Code = _NotNull(reader.Item("CoLoadToID"), "")
                        ._Description = _NotNull(reader.Item("CoLoadToName"), "")
                    End With
                    ._ActualVolume = reader.Item("ActualVolume")
                    ._ActualGrossWeight = reader.Item("ActualGrossWeight")
                    ._RevisedMeasurement = reader.Item("RevisedMeasurement")
                    With ._RevisedMeasurementTypeDetails
                        ._PK = _NotNull(reader.Item("RevisedMeasurementTypeID"), "")
                        ._Param_Desc = _NotNull(reader.Item("RevisedMeasurementTypeDesc"), "")
                    End With
                    ._ApprovedPosting = reader.Item("ApprovedPosting")
                    ._KPIDate = _NotNull(reader.Item("KPIDate"), Nothing)
                    ._DocsCompleted = reader.Item("DocsCompleted")
                    ._DocsCompletedDate = _NotNull(reader.Item("DocsCompletedDate"), Nothing)
                    With ._MasterBookingDetails
                        ._ID = reader.Item("MasterBookingID")
                        ._RefNo = _NotNull(reader.Item("MasterBookingNo"), "")
                    End With
                    ._BrkgDetails._ID = _NotNull(reader.Item("BrkgID"), 0)
                    With ._StatusDetails
                        ._Status_ID = _NotNull(reader.Item("StatusID"), 0)
                        ._Status_Name = _NotNull(reader.Item("Status_Name"), "")
                        ._Status_ColorR = _NotNull(reader.Item("Status_ColorR"), 0)
                        ._Status_ColorG = _NotNull(reader.Item("Status_ColorG"), 0)
                        ._Status_ColorB = _NotNull(reader.Item("Status_ColorB"), 0)
                    End With
                    With ._StatusByDetails
                        ._User_ID = _NotNull(reader.Item("StatusByID"), "")
                        ._Last_Name = _NotNull(reader.Item("StatusByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("StatusByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("StatusByMiddle_Name"), "")
                    End With
                    ._StatusDate = _NotNull(reader.Item("StatusDate"), Nothing)
                    With ._PrepByDetails
                        ._User_ID = reader.Item("PrepByID")
                        ._Last_Name = reader.Item("PrepByLast_Name")
                        ._First_Name = reader.Item("PrepByFirst_Name")
                        ._Middle_Name = reader.Item("PrepByMiddle_Name")
                    End With
                    ._PrepDate = reader.Item("PrepDate")
                    With ._ModByDetails
                        ._User_ID = reader.Item("ModByID")
                        ._Last_Name = reader.Item("ModByLast_Name")
                        ._First_Name = reader.Item("ModByFirst_Name")
                        ._Middle_Name = reader.Item("ModByMiddle_Name")
                    End With
                    ._ModDate = reader.Item("ModDate")
                End With
            End While
            reader.Close()

            If clsTempExport._MasterBookingDetails._ID > 0 Then
                clsTempExport._MasterBookingDetails = CustomerServiceExportMasterSearch(clsTempExport._MasterBookingDetails._RefNo, clsTempExport._CompanyDetails._Company_Code)
            End If

            cmdSQL.Parameters.Clear()
            cmdSQL.CommandText = "SELECT * FROM v_exportbookingservices WHERE BookingID = @BookingID"
            With cmdSQL.Parameters
                .AddWithValue("@BookingID", clsTempExport._ID)
            End With

            clsTempExport._ServiceDetails.Clear()

            reader = cmdSQL.ExecuteReader
            While reader.Read
                clsTempServices = New clsExportBookingServices
                With clsTempServices
                    ._ID = reader.Item("ID")
                    ._BookingID = reader.Item("BookingID")
                    With ._ServiceNameDetails
                        ._PK = reader.Item("ServiceID")
                        ._Param_Desc = reader.Item("ServiceName")
                        ._ParameterType._PK = reader.Item("Param_TypeID")
                        ._ParameterType._Description = reader.Item("Param_TypeName")
                        ._Param_Code = reader.Item("Param_Code")
                        ._Param_Value = reader.Item("Param_Value")
                    End With
                End With
                clsTempExport._ServiceDetails.Add(clsTempServices)
            End While
            reader.Close()

            cmdSQL.Parameters.Clear()
            cmdSQL.CommandText = "SELECT * FROM v_exportbookingdocuments WHERE BookingID = @BookingID"
            With cmdSQL.Parameters
                .AddWithValue("@BookingID", clsTempExport._ID)
            End With

            clsTempExport._DocumentDetails.Clear()

            reader = cmdSQL.ExecuteReader
            While reader.Read
                clsTempDocuments = New clsExportBookingDocuments
                With clsTempDocuments
                    ._ID = reader.Item("ID")
                    ._BookingID = reader.Item("BookingID")
                    With ._DocumentDetails
                        ._ID = reader.Item("DocumentID")
                        ._DocumentName = reader.Item("DocumentName")
                        ._Required = reader.Item("Required")
                        ._Active = reader.Item("Active")
                    End With
                End With
                clsTempExport._DocumentDetails.Add(clsTempDocuments)
            End While
            reader.Close()

            If clsTempExport._BrkgDetails._ID > 0 Then
                clsTempExport._BrkgDetails = BrokerageJOSearch(clsTempExport._BrkgDetails._ID)
            End If

            cmdSQL.Dispose()
            Return clsTempExport
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


#End Region

#Region "Customer Service Domestic"
    Public Function CustomerServiceDomesticMasterSave(ByVal clsTempDomMaster As clsDomesticMasterBooking) As clsDomesticMasterBooking
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_domesticmasterheadersave"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsTempDomMaster
                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_RefNo", ._RefNo)
                cmdSQL.Parameters("@p_RefNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Company_Code", ._CompanyDetails._Company_Code)
                cmdSQL.Parameters("@p_Company_Code").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CarrierCode", ._CarrierDetails._Code)
                cmdSQL.Parameters("@p_CarrierCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_OriginID", ._OriginDetails._PK)
                cmdSQL.Parameters("@p_OriginID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_DestinationID", ._DestinationDetails._PK)
                cmdSQL.Parameters("@p_DestinationID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModeOfTransportID", ._ModeOfTransportDetails._PK)
                cmdSQL.Parameters("@p_ModeOfTransportID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_LoadedPullOut", ._LoadedPullOut)
                cmdSQL.Parameters("@p_LoadedPullOut").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ContainerYard", ._ContainerYard)
                cmdSQL.Parameters("@p_ContainerYard").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_WarehouseID", ._WarehouseDetails._ID)
                cmdSQL.Parameters("@p_WarehouseID").Direction = ParameterDirection.Input

                If ._ETD._DateValue = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_ETD", DBNull.Value)
                    cmdSQL.Parameters("@p_ETD").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_ETD", ._ETD._DateValue)
                    cmdSQL.Parameters("@p_ETD").Direction = ParameterDirection.Input
                End If

                If ._ATD._DateValue = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_ATD", DBNull.Value)
                    cmdSQL.Parameters("@p_ATD").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_ATD", ._ATD._DateValue)
                    cmdSQL.Parameters("@p_ATD").Direction = ParameterDirection.Input
                End If

                cmdSQL.Parameters.AddWithValue("@p_SealNo", ._SealNo)
                cmdSQL.Parameters("@p_SealNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_EmptyPositioning", ._EmptyPositioning)
                cmdSQL.Parameters("@p_EmptyPositioning").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ChassisDepot", ._ChassisDepot)
                cmdSQL.Parameters("@p_ChassisDepot").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_VesselID", ._VesselDetails._ID)
                cmdSQL.Parameters("@p_VesselID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_AirLineCode", ._AirlineDetails._Code)
                cmdSQL.Parameters("@p_AirLineCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_LCT", ._LCT)
                cmdSQL.Parameters("@p_LCT").Direction = ParameterDirection.Input

                If ._ETA._DateValue = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_ETA", DBNull.Value)
                    cmdSQL.Parameters("@p_ETA").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_ETA", ._ETA._DateValue)
                    cmdSQL.Parameters("@p_ETA").Direction = ParameterDirection.Input
                End If

                If ._ATA._DateValue = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_ATA", DBNull.Value)
                    cmdSQL.Parameters("@p_ATA").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_ATA", ._ATA._DateValue)
                    cmdSQL.Parameters("@p_ATA").Direction = ParameterDirection.Input
                End If

                cmdSQL.Parameters.AddWithValue("@p_LoadTypeID", ._LoadTypeDetails._PK)
                cmdSQL.Parameters("@p_LoadTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", ._PrepByDetails._User_ID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModByDetails._User_ID)
                cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.Parameters.AddWithValue("@p_RefNo_Out", ._RefNo)
                cmdSQL.Parameters("@p_RefNo_Out").Direction = ParameterDirection.Output

                cmdSQL.ExecuteNonQuery()
                ._ID = cmdSQL.Parameters("@p_ID_Out").Value
                ._RefNo = cmdSQL.Parameters("@p_RefNo_Out").Value

                cmdSQL.Parameters.Clear()

                cmdSQL.CommandText = "UPDATE tbl_domestic_booking_header SET MasterBookingID = 0 WHERE MasterBookingID = @MasterBookingID"
                cmdSQL.CommandType = CommandType.TableDirect
                cmdSQL.Parameters.AddWithValue("@MasterBookingID", ._ID)
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()

                For Each clsExp As clsExportBookingHeader In ._ListOfBookingDetails
                    cmdSQL.Connection = cnnDBMaster
                    cmdSQL.Transaction = trnSQL
                    cmdSQL.CommandText = "sp_domesticmasterdetailssave"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_MasterBookingID", ._ID)
                    cmdSQL.Parameters("@p_MasterBookingID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModByDetails._User_ID)
                    cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsExp._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()
                    cmdSQL.Parameters.Clear()
                Next
            End With

            trnSQL.Commit()
            cmdSQL.Dispose()
            Return clsTempDomMaster
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
            Return Nothing
        End Try
    End Function

    Public Function CustomerServiceDomesticMasterSearch(ByVal strRefNo As String, ByVal strCompanyCode As String) As clsDomesticMasterBooking
        Try
            Dim clsTemp As New clsDomesticMasterBooking
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_exportmaster WHERE `RefNo` = @RefNo AND `CompanyCode` = @CompanyCode"
            cmdSQL.Parameters.AddWithValue("@RefNo", strRefNo)
            cmdSQL.Parameters.AddWithValue("@CompanyCode", strCompanyCode)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTemp
                    ._ID = reader.Item("ID")
                    ._RefNo = reader.Item("RefNo")
                    With ._CompanyDetails
                        ._Company_Code = reader.Item("CompanyCode")
                        ._Company_Name = reader.Item("Company_Name")
                        ._Company_FullName = reader.Item("Company_FullName")
                    End With
                    With ._CarrierDetails
                        ._Code = _NotNull(reader.Item("CarrierCode"), "")
                        ._Description = _NotNull(reader.Item("CarrierName"), "")
                    End With
                    With ._OriginDetails
                        ._PK = _NotNull(reader.Item("OriginID"), -1)
                        ._CountryDetails._PK = _NotNull(reader.Item("OriginCountry_PK"), -1)
                        ._Description = _NotNull(reader.Item("OriginName"), "")
                    End With
                    With ._DestinationDetails
                        ._PK = _NotNull(reader.Item("DestinationID"), -1)
                        ._CountryDetails._PK = _NotNull(reader.Item("DestinationCountry_PK"), -1)
                        ._Description = _NotNull(reader.Item("DestinationName"), "")
                    End With
                    With ._ModeOfTransportDetails
                        ._PK = reader.Item("ModeOfTransportID")
                        ._Param_Desc = reader.Item("ModeOfTransportDesc")
                    End With
                    ._LoadedPullOut = _NotNull(reader.Item("LoadedPullOut"), "")
                    ._ContainerYard = _NotNull(reader.Item("ContainerYard"), "")
                    With ._WarehouseDetails
                        ._ID = _NotNull(reader.Item("WarehouseID"), -1)
                        ._WarehouseName = _NotNull(reader.Item("WarehouseName"), "")
                    End With
                    ._ETD._DateValue = _NotNull(reader.Item("ETD"), Nothing)
                    ._ATD._DateValue = _NotNull(reader.Item("ATD"), Nothing)
                    ._SealNo = _NotNull(reader.Item("SealNo"), "")
                    ._EmptyPositioning = _NotNull(reader.Item("EmptyPositioning"), "")
                    ._ChassisDepot = _NotNull(reader.Item("ChassisDepot"), "")
                    With ._VesselDetails
                        ._ID = _NotNull(reader.Item("VesselID"), -1)
                        ._VesselCode = _NotNull(reader.Item("VesselCode"), "")
                        ._VesselName = _NotNull(reader.Item("VesselName"), "")
                        ._NACCSUserCode = _NotNull(reader.Item("NACCSUserCode"), "")
                    End With
                    With ._AirlineDetails
                        ._Code = _NotNull(reader.Item("AirLineCode"), "")
                        ._Prefix = _NotNull(reader.Item("AirLinePrefix"), "")
                        ._Description = _NotNull(reader.Item("AirLineName"), "")
                    End With
                    ._LCT = _NotNull(reader.Item("LCT"), "")
                    ._ETA._DateValue = _NotNull(reader.Item("ETA"), Nothing)
                    ._ATA._DateValue = _NotNull(reader.Item("ATA"), Nothing)
                    With ._LoadTypeDetails
                        ._PK = _NotNull(reader.Item("LoadTypeID"), -1)
                        ._Param_Desc = _NotNull(reader.Item("LoadTypeDesc"), "")
                    End With
                    With ._StatusDetails
                        ._Status_ID = _NotNull(reader.Item("StatusID"), -1)
                        ._Status_Name = _NotNull(reader.Item("Status_Name"), "")
                        ._Status_ColorR = _NotNull(reader.Item("Status_ColorR"), -1)
                        ._Status_ColorG = _NotNull(reader.Item("Status_ColorG"), -1)
                        ._Status_ColorB = _NotNull(reader.Item("Status_ColorB"), -1)
                    End With
                    With ._StatusByDetails
                        ._User_ID = _NotNull(reader.Item("StatusByID"), "")
                        ._Last_Name = _NotNull(reader.Item("StatusByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("StatusByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("StatusByMiddle_Name"), "")
                    End With
                    ._StatusDate = _NotNull(reader.Item("StatusDate"), Nothing)
                    With ._PrepByDetails
                        ._User_ID = reader.Item("PrepByID")
                        ._Last_Name = reader.Item("PrepByLast_Name")
                        ._First_Name = reader.Item("PrepByFirst_Name")
                        ._Middle_Name = reader.Item("PrepByMiddle_Name")
                    End With
                    ._PrepDate = reader.Item("PrepDate")
                    With ._ModByDetails
                        ._User_ID = reader.Item("ModByID")
                        ._Last_Name = reader.Item("ModByLast_Name")
                        ._First_Name = reader.Item("ModByFirst_Name")
                        ._Middle_Name = reader.Item("ModByMiddle_Name")
                    End With
                    ._ModDate = reader.Item("ModDate")
                End With
            End While

            reader.Close()
            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "SELECT * FROM v_exportbookingheader WHERE `MasterBookingID` = @MasterBookingID"
            cmdSQL.Parameters.AddWithValue("@MasterBookingID", clsTemp._ID)
            reader = cmdSQL.ExecuteReader

            Dim clsExp As New clsExportBookingHeader
            While reader.Read
                With clsExp
                    ._ID = reader.Item("ID")
                    ._BookingNo = reader.Item("BookingNo")
                    ._BookingPrefix = reader.Item("BookingPrefix")
                    With ._CompanyDetails
                        ._Company_Code = reader.Item("CompanyCode")
                        ._Company_FullName = reader.Item("Company_FullName")
                    End With
                    With ._ConsignorDetails
                        ._Code = reader.Item("ConsignorCode")
                        ._Description = reader.Item("ConsignorName")
                        ._Addr1 = reader.Item("ConsignorAddr1")
                        ._AddrCity = reader.Item("ConsignorAddrCity")
                        ._AddrCountry = reader.Item("ConsignorAddrCountry")
                    End With
                    With ._SiteDetails
                        ._Site_Code = reader.Item("SiteCode")
                        ._Site_Name = reader.Item("Site_Name")
                    End With
                    With ._AccountTypeDetails
                        ._ID = reader.Item("AccountTypeID")
                        ._Prefix = reader.Item("AccountTypePrefix")
                        ._Description = reader.Item("AccountTypeDescription")
                    End With
                    With ._AccountHolderDetails
                        ._User_ID = reader.Item("AccountHolderID")
                        ._Last_Name = reader.Item("AccountHolderLast_Name")
                        ._First_Name = reader.Item("AccountHolderFirst_Name")
                        ._Middle_Name = reader.Item("AccountHolderMiddle_Name")
                    End With
                    With ._ShipperDetails
                        ._Code = reader.Item("ShipperCode")
                        ._Description = reader.Item("ShipperName")
                        ._Addr1 = reader.Item("ShipperAddr1")
                        ._AddrCity = reader.Item("ShipperAddrCity")
                        ._AddrCountry = reader.Item("ShipperAddrCountry")
                    End With
                    With ._ConsigneeDetails
                        ._Code = reader.Item("ConsigneeCode")
                        ._Description = reader.Item("ConsigneeName")
                        ._Addr1 = reader.Item("ConsigneeAddr1")
                        ._AddrCity = reader.Item("ConsigneeAddrCity")
                        ._AddrCountry = reader.Item("ConsigneeAddrCountry")
                    End With
                    With ._ModeOfTransportDetails
                        ._PK = reader.Item("ModeOfTransportID")
                        ._Param_Desc = reader.Item("ModeOfTransportDesc")
                    End With
                    With ._OriginDetails
                        ._PK = reader.Item("OriginID")
                        ._CountryDetails._PK = reader.Item("OriginCountry_PK")
                        ._Description = reader.Item("OriginName")
                    End With
                    With ._FinalDestinationDetails
                        ._PK = reader.Item("FinalDestinationID")
                        ._CountryDetails._PK = reader.Item("FinalDestinationCountry_PK")
                        ._Description = reader.Item("FinalDestinationName")
                    End With
                    ._Commodity = reader.Item("Commodity")
                    ._DangerousCargo = reader.Item("DangerousCargo")
                    ._GrossWeight = reader.Item("GrossWeight")
                    ._Volume = reader.Item("Volume")
                    With ._LoadTypeDetails
                        ._PK = reader.Item("LoadTypeID")
                        ._Param_Desc = reader.Item("LoadTypeDesc")
                    End With
                    ._NoOfPackage = reader.Item("NoOfPackage")
                    With ._PackageUnitDetails
                        ._PK = reader.Item("PackageUnitID")
                        ._Param_Desc = reader.Item("PackageUnitDesc")
                    End With
                    With ._ColoadToDetails
                        ._Code = _NotNull(reader.Item("CoLoadToID"), "")
                        ._Description = _NotNull(reader.Item("CoLoadToName"), "")
                    End With
                    ._ActualVolume = reader.Item("ActualVolume")
                    ._ActualGrossWeight = reader.Item("ActualGrossWeight")
                    ._RevisedMeasurement = reader.Item("RevisedMeasurement")
                    With ._RevisedMeasurementTypeDetails
                        ._PK = _NotNull(reader.Item("RevisedMeasurementTypeID"), "")
                        ._Param_Desc = _NotNull(reader.Item("RevisedMeasurementTypeDesc"), "")
                    End With
                    ._ApprovedPosting = reader.Item("ApprovedPosting")
                    ._KPIDate = _NotNull(reader.Item("KPIDate"), Nothing)
                    ._DocsCompleted = reader.Item("DocsCompleted")
                    ._DocsCompletedDate = _NotNull(reader.Item("DocsCompletedDate"), Nothing)
                    With ._MasterBookingDetails
                        ._ID = reader.Item("MasterBookingID")
                        ._RefNo = _NotNull(reader.Item("MasterBookingNo"), "")
                    End With
                    With ._StatusDetails
                        ._Status_ID = _NotNull(reader.Item("StatusID"), 0)
                        ._Status_Name = _NotNull(reader.Item("Status_Name"), "")
                        ._Status_ColorR = _NotNull(reader.Item("Status_ColorR"), 0)
                        ._Status_ColorG = _NotNull(reader.Item("Status_ColorG"), 0)
                        ._Status_ColorB = _NotNull(reader.Item("Status_ColorB"), 0)
                    End With
                    With ._StatusByDetails
                        ._User_ID = _NotNull(reader.Item("StatusByID"), "")
                        ._Last_Name = _NotNull(reader.Item("StatusByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("StatusByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("StatusByMiddle_Name"), "")
                    End With
                    ._StatusDate = _NotNull(reader.Item("StatusDate"), Nothing)
                    With ._PrepByDetails
                        ._User_ID = reader.Item("PrepByID")
                        ._Last_Name = reader.Item("PrepByLast_Name")
                        ._First_Name = reader.Item("PrepByFirst_Name")
                        ._Middle_Name = reader.Item("PrepByMiddle_Name")
                    End With
                    ._PrepDate = reader.Item("PrepDate")
                    With ._ModByDetails
                        ._User_ID = reader.Item("ModByID")
                        ._Last_Name = reader.Item("ModByLast_Name")
                        ._First_Name = reader.Item("ModByFirst_Name")
                        ._Middle_Name = reader.Item("ModByMiddle_Name")
                    End With
                    ._ModDate = reader.Item("ModDate")
                End With

                clsTemp._ListOfBookingDetails.Add(clsExp)
                clsExp = New clsExportBookingHeader
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clsTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CustomerServiceDomesticBookingSave(ByVal clsTempDomBook As clsDomesticBookingHeader) As clsDomesticBookingHeader
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_domesticbookingheadersave"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsTempDomBook
                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_BookingNo", ._BookingNo)
                cmdSQL.Parameters("@p_BookingNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_BookingPrefix", ._BookingPrefix)
                cmdSQL.Parameters("@p_BookingPrefix").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CompanyCode", ._CompanyDetails._Company_Code)
                cmdSQL.Parameters("@p_CompanyCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsignorCode", ._ConsignorDetails._Code)
                cmdSQL.Parameters("@p_ConsignorCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SiteCode", ._SiteDetails._Site_Code)
                cmdSQL.Parameters("@p_SiteCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_AccountTypeID", ._AccountTypeDetails._ID)
                cmdSQL.Parameters("@p_AccountTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_AccountHolderID", ._AccountHolderDetails._User_ID)
                cmdSQL.Parameters("@p_AccountHolderID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperCode", ._ShipperDetails._Code)
                cmdSQL.Parameters("@p_ShipperCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeCode", ._ConsigneeDetails._Code)
                cmdSQL.Parameters("@p_ConsigneeCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModeOftransportID", ._ModeOfTransportDetails._PK)
                cmdSQL.Parameters("@p_ModeOftransportID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_OriginID", ._OriginDetails._PK)
                cmdSQL.Parameters("@p_OriginID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_FinalDestinationID", ._FinalDestinationDetails._PK)
                cmdSQL.Parameters("@p_FinalDestinationID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Commodity", ._Commodity)
                cmdSQL.Parameters("@p_Commodity").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_DangerousCargo", ._DangerousCargo)
                cmdSQL.Parameters("@p_DangerousCargo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_GrossWeight", ._GrossWeight)
                cmdSQL.Parameters("@p_GrossWeight").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Volume", ._Volume)
                cmdSQL.Parameters("@p_Volume").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_LoadTypeID", ._LoadTypeDetails._PK)
                cmdSQL.Parameters("@p_LoadTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NoOfPackage", ._NoOfPackage)
                cmdSQL.Parameters("@p_NoOfPackage").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PackageUnitID", ._PackageUnitDetails._PK)
                cmdSQL.Parameters("@p_PackageUnitID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CoLoadToID", ._ColoadToDetails._Code)
                cmdSQL.Parameters("@p_CoLoadToID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ActualVolume", ._ActualVolume)
                cmdSQL.Parameters("@p_ActualVolume").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ActualGrossWeight", ._ActualGrossWeight)
                cmdSQL.Parameters("@p_ActualGrossWeight").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_RevisedMeasurement", ._RevisedMeasurement)
                cmdSQL.Parameters("@p_RevisedMeasurement").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_RevisedMeasurementTypeID", ._RevisedMeasurementTypeDetails._PK)
                cmdSQL.Parameters("@p_RevisedMeasurementTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ApprovedPosting", ._ApprovedPosting)
                cmdSQL.Parameters("@p_ApprovedPosting").Direction = ParameterDirection.Input

                If ._KPIDate = Nothing Then
                    cmdSQL.Parameters.AddWithValue("@p_KPIDate", DBNull.Value)
                    cmdSQL.Parameters("@p_KPIDate").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_KPIDate", ._KPIDate)
                    cmdSQL.Parameters("@p_KPIDate").Direction = ParameterDirection.Input
                End If

                cmdSQL.Parameters.AddWithValue("@p_DocsCompleted", ._DocsCompleted)
                cmdSQL.Parameters("@p_DocsCompleted").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_MasterBookingID", ._MasterBookingDetails._ID)
                cmdSQL.Parameters("@p_MasterBookingID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ColoadSequenceID", 0)
                cmdSQL.Parameters("@p_ColoadSequenceID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", ._PrepByDetails._User_ID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModByDetails._User_ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.Parameters.AddWithValue("@p_BookingNo_Out", ._BookingNo)
                cmdSQL.Parameters("@p_BookingNo_Out").Direction = ParameterDirection.Output

                cmdSQL.ExecuteNonQuery()
                ._ID = cmdSQL.Parameters("@p_ID_Out").Value
                ._BookingNo = cmdSQL.Parameters("@p_BookingNo_Out").Value
            End With

            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "DELETE FROM tbl_domestic_booking_services WHERE BookingID = @BookingID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@BookingID", clsTempDomBook._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsDomesticBookingServices In clsTempDomBook._ServiceDetails
                cmdSQL.CommandText = "sp_domesticservicessave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_BookingID", clsTempDomBook._ID)
                    cmdSQL.Parameters("@p_BookingID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ServiceID", ._ServiceNameDetails._PK)
                    cmdSQL.Parameters("@p_ServiceID").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            cmdSQL.CommandText = "DELETE FROM tbl_domestic_booking_documents WHERE BookingID = @BookingID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@BookingID", clsTempDomBook._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsDomesticBookingDocuments In clsTempDomBook._DocumentDetails
                cmdSQL.CommandText = "sp_domesticbookingdocumentsave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_BookingID", clsTempDomBook._ID)
                    cmdSQL.Parameters("@p_BookingID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_DocumentID", ._DocumentDetails._ID)
                    cmdSQL.Parameters("@p_DocumentID").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            trnSQL.Commit()
            cmdSQL.Dispose()

            Return clsTempDomBook
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

            Return Nothing
        End Try
    End Function

    Public Function CustomerServiceDomesticBookingSearch(ByVal strBookingNo As String, ByVal strCompanyCode As String) As clsDomesticBookingHeader
        Try
            Dim clsTempDom As New clsDomesticBookingHeader
            Dim clsTempServices As New clsDomesticBookingServices
            Dim clsTempDocuments As New clsDomesticBookingDocuments

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_exportbookingheader WHERE BookingNo = @BookingNo AND CompanyCode = @CompanyCode"
            With cmdSQL.Parameters
                .AddWithValue("@BookingNo", strBookingNo)
                .AddWithValue("@CompanyCode", strCompanyCode)
            End With

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTempDom
                    ._ID = reader.Item("ID")
                    ._BookingNo = reader.Item("BookingNo")
                    ._BookingPrefix = reader.Item("BookingPrefix")
                    With ._CompanyDetails
                        ._Company_Code = reader.Item("CompanyCode")
                        ._Company_FullName = reader.Item("Company_FullName")
                    End With
                    With ._ConsignorDetails
                        ._Code = reader.Item("ConsignorCode")
                        ._Description = reader.Item("ConsignorName")
                        ._Addr1 = reader.Item("ConsignorAddr1")
                        ._AddrCity = reader.Item("ConsignorAddrCity")
                        ._AddrCountry = reader.Item("ConsignorAddrCountry")
                    End With
                    With ._SiteDetails
                        ._Site_Code = reader.Item("SiteCode")
                        ._Site_Name = reader.Item("Site_Name")
                    End With
                    With ._AccountTypeDetails
                        ._ID = reader.Item("AccountTypeID")
                        ._Prefix = reader.Item("AccountTypePrefix")
                        ._Description = reader.Item("AccountTypeDescription")
                    End With
                    With ._AccountHolderDetails
                        ._User_ID = reader.Item("AccountHolderID")
                        ._Last_Name = reader.Item("AccountHolderLast_Name")
                        ._First_Name = reader.Item("AccountHolderFirst_Name")
                        ._Middle_Name = reader.Item("AccountHolderMiddle_Name")
                    End With
                    With ._ShipperDetails
                        ._Code = reader.Item("ShipperCode")
                        ._Description = reader.Item("ShipperName")
                        ._Addr1 = reader.Item("ShipperAddr1")
                        ._AddrCity = reader.Item("ShipperAddrCity")
                        ._AddrCountry = reader.Item("ShipperAddrCountry")
                    End With
                    With ._ConsigneeDetails
                        ._Code = reader.Item("ConsigneeCode")
                        ._Description = reader.Item("ConsigneeName")
                        ._Addr1 = reader.Item("ConsigneeAddr1")
                        ._AddrCity = reader.Item("ConsigneeAddrCity")
                        ._AddrCountry = reader.Item("ConsigneeAddrCountry")
                    End With
                    With ._ModeOfTransportDetails
                        ._PK = reader.Item("ModeOfTransportID")
                        ._Param_Desc = reader.Item("ModeOfTransportDesc")
                    End With
                    With ._OriginDetails
                        ._PK = reader.Item("OriginID")
                        ._CountryDetails._PK = reader.Item("OriginCountry_PK")
                        ._Description = reader.Item("OriginName")
                    End With
                    With ._FinalDestinationDetails
                        ._PK = reader.Item("FinalDestinationID")
                        ._CountryDetails._PK = reader.Item("FinalDestinationCountry_PK")
                        ._Description = reader.Item("FinalDestinationName")
                    End With
                    ._Commodity = reader.Item("Commodity")
                    ._DangerousCargo = reader.Item("DangerousCargo")
                    ._GrossWeight = reader.Item("GrossWeight")
                    ._Volume = reader.Item("Volume")
                    With ._LoadTypeDetails
                        ._PK = reader.Item("LoadTypeID")
                        ._Param_Desc = reader.Item("LoadTypeDesc")
                    End With
                    ._NoOfPackage = reader.Item("NoOfPackage")
                    With ._PackageUnitDetails
                        ._PK = reader.Item("PackageUnitID")
                        ._Param_Desc = reader.Item("PackageUnitDesc")
                    End With
                    With ._ColoadToDetails
                        ._Code = _NotNull(reader.Item("CoLoadToID"), "")
                        ._Description = _NotNull(reader.Item("CoLoadToName"), "")
                    End With
                    ._ActualVolume = reader.Item("ActualVolume")
                    ._ActualGrossWeight = reader.Item("ActualGrossWeight")
                    ._RevisedMeasurement = reader.Item("RevisedMeasurement")
                    With ._RevisedMeasurementTypeDetails
                        ._PK = _NotNull(reader.Item("RevisedMeasurementTypeID"), "")
                        ._Param_Desc = _NotNull(reader.Item("RevisedMeasurementTypeDesc"), "")
                    End With
                    ._ApprovedPosting = reader.Item("ApprovedPosting")
                    ._KPIDate = _NotNull(reader.Item("KPIDate"), Nothing)
                    ._DocsCompleted = reader.Item("DocsCompleted")
                    ._DocsCompletedDate = _NotNull(reader.Item("DocsCompletedDate"), Nothing)
                    With ._MasterBookingDetails
                        ._ID = reader.Item("MasterBookingID")
                        ._RefNo = _NotNull(reader.Item("MasterBookingNo"), "")
                    End With
                    With ._StatusDetails
                        ._Status_ID = _NotNull(reader.Item("StatusID"), 0)
                        ._Status_Name = _NotNull(reader.Item("Status_Name"), "")
                        ._Status_ColorR = _NotNull(reader.Item("Status_ColorR"), 0)
                        ._Status_ColorG = _NotNull(reader.Item("Status_ColorG"), 0)
                        ._Status_ColorB = _NotNull(reader.Item("Status_ColorB"), 0)
                    End With
                    With ._StatusByDetails
                        ._User_ID = _NotNull(reader.Item("StatusByID"), "")
                        ._Last_Name = _NotNull(reader.Item("StatusByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("StatusByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("StatusByMiddle_Name"), "")
                    End With
                    ._StatusDate = _NotNull(reader.Item("StatusDate"), Nothing)
                    With ._PrepByDetails
                        ._User_ID = reader.Item("PrepByID")
                        ._Last_Name = reader.Item("PrepByLast_Name")
                        ._First_Name = reader.Item("PrepByFirst_Name")
                        ._Middle_Name = reader.Item("PrepByMiddle_Name")
                    End With
                    ._PrepDate = reader.Item("PrepDate")
                    With ._ModByDetails
                        ._User_ID = reader.Item("ModByID")
                        ._Last_Name = reader.Item("ModByLast_Name")
                        ._First_Name = reader.Item("ModByFirst_Name")
                        ._Middle_Name = reader.Item("ModByMiddle_Name")
                    End With
                    ._ModDate = reader.Item("ModDate")
                End With
            End While
            reader.Close()

            If clsTempDom._MasterBookingDetails._ID > 0 Then
                clsTempDom._MasterBookingDetails = CustomerServiceDomesticMasterSearch(clsTempDom._MasterBookingDetails._RefNo, clsTempDom._CompanyDetails._Company_Code)
            End If

            cmdSQL.Parameters.Clear()
            cmdSQL.CommandText = "SELECT * FROM v_exportbookingservices WHERE BookingID = @BookingID"
            With cmdSQL.Parameters
                .AddWithValue("@BookingID", clsTempDom._ID)
            End With

            clsTempDom._ServiceDetails.Clear()

            reader = cmdSQL.ExecuteReader
            While reader.Read
                clsTempServices = New clsDomesticBookingServices
                With clsTempServices
                    ._ID = reader.Item("ID")
                    ._BookingID = reader.Item("BookingID")
                    With ._ServiceNameDetails
                        ._PK = reader.Item("ServiceID")
                        ._Param_Desc = reader.Item("ServiceName")
                        ._ParameterType._PK = reader.Item("Param_TypeID")
                        ._ParameterType._Description = reader.Item("Param_TypeName")
                        ._Param_Code = reader.Item("Param_Code")
                        ._Param_Value = reader.Item("Param_Value")
                    End With
                End With
                clsTempDom._ServiceDetails.Add(clsTempServices)
            End While
            reader.Close()

            cmdSQL.Parameters.Clear()
            cmdSQL.CommandText = "SELECT * FROM v_exportbookingdocuments WHERE BookingID = @BookingID"
            With cmdSQL.Parameters
                .AddWithValue("@BookingID", clsTempDom._ID)
            End With

            clsTempDom._DocumentDetails.Clear()

            reader = cmdSQL.ExecuteReader
            While reader.Read
                clsTempDocuments = New clsDomesticBookingDocuments
                With clsTempDocuments
                    ._ID = reader.Item("ID")
                    ._BookingID = reader.Item("BookingID")
                    With ._DocumentDetails
                        ._ID = reader.Item("DocumentID")
                        ._DocumentName = reader.Item("DocumentName")
                        ._Required = reader.Item("Required")
                        ._Active = reader.Item("Active")
                    End With
                End With
                clsTempDom._DocumentDetails.Add(clsTempDocuments)
            End While
            reader.Close()

            cmdSQL.Dispose()
            Return clsTempDom
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
#End Region

#Region "Forwarding Docs"
    Public Function ForwardingDocsMBLSave(ByVal clsMBL As clsFrwdgDocsMBL) As clsFrwdgDocsMBL
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_frwdgdocsmblsave"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsMBL
                If ._ID <= 0 Then
                    cmdSQL.Parameters.AddWithValue("@p_SaveType", 1)
                    cmdSQL.Parameters("@p_SaveType").Direction = ParameterDirection.Input
                Else
                    cmdSQL.Parameters.AddWithValue("@p_SaveType", 2)
                    cmdSQL.Parameters("@p_SaveType").Direction = ParameterDirection.Input
                End If

                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_MBLNo", ._MBLNo)
                cmdSQL.Parameters("@p_MBLNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_RegistryNo", ._RegistryNo)
                cmdSQL.Parameters("@p_RegistryNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_RegYear", ._RegYear)
                cmdSQL.Parameters("@p_RegYear").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CompanyCode", ._CompanyCode)
                cmdSQL.Parameters("@p_CompanyCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModeOfTransportID", ._ModeOfTransport._PK)
                cmdSQL.Parameters("@p_ModeOfTransportID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_FreightTypeID", ._FreightTypeDetails._PK)
                cmdSQL.Parameters("@p_FreightTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PreviewTypeID", ._PreviewTypeDetails._ID)
                cmdSQL.Parameters("@p_PreviewTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ArrivalDate", ._ArrivalDate)
                cmdSQL.Parameters("@p_ArrivalDate").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CargoType", ._CargoType)
                cmdSQL.Parameters("@p_CargoType").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PlaceOfReceiptCode", ._PlaceOfReceiptCode)
                cmdSQL.Parameters("@p_PlaceOfReceiptCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PlaceOfReceiptName", ._PlaceOfReceiptName)
                cmdSQL.Parameters("@p_PlaceOfReceiptName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_VesselCode", ._VesselCode)
                cmdSQL.Parameters("@p_VesselCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_VesselName", ._VesselName)
                cmdSQL.Parameters("@p_VesselName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_VOY", ._VOY)
                cmdSQL.Parameters("@p_VOY").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PortOfLoadingCode", ._PortOfLoadingCode)
                cmdSQL.Parameters("@p_PortOfLoadingCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PortOfLoadingName", ._PortOfLoadingName)
                cmdSQL.Parameters("@p_PortOfLoadingName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PortOfDischargeCode", ._PortOfDischargeCode)
                cmdSQL.Parameters("@p_PortOfDischargeCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PortOfDischargeName", ._PortOfDischargeName)
                cmdSQL.Parameters("@p_PortOfDischargeName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_DevanDate", ._DevanDate)
                cmdSQL.Parameters("@p_DevanDate").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CargoLocation", ._CargoLocation)
                cmdSQL.Parameters("@p_CargoLocation").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ExchangeRate", ._ExchangeRate)
                cmdSQL.Parameters("@p_ExchangeRate").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsolCoload", ._ConsolCoload)
                cmdSQL.Parameters("@p_ConsolCoload").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_StatusID", ._StatusDetails._Status_ID)
                cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_StatusByID", CurrentUser._User_ID)
                cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", CurrentUser._User_ID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", CurrentUser._User_ID)
                cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.ExecuteNonQuery()
                ._ID = cmdSQL.Parameters("@p_ID_Out").Value
            End With

            trnSQL.Commit()
            cmdSQL.Dispose()

            Return clsMBL
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

            Return Nothing
        End Try
    End Function

    Public Function ForwardingDocsHBLSave(ByVal clsHBL As clsFrwdgDocsHBL) As clsFrwdgDocsHBL
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_frwdgdocshblsave"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsHBL
                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_MBLID", ._MBL._ID)
                cmdSQL.Parameters("@p_MBLID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_HBLNo", ._HBLNo)
                cmdSQL.Parameters("@p_HBLNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_DataDiv", ._DataDiv)
                cmdSQL.Parameters("@p_DataDiv").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SenderCode", ._SenderCode)
                cmdSQL.Parameters("@p_SenderCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ReceiverCode", ._ReceiverCode)
                cmdSQL.Parameters("@p_ReceiverCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SendDate", ._SendDate)
                cmdSQL.Parameters("@p_SendDate").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SendDiv", ._SendDiv)
                cmdSQL.Parameters("@p_SendDiv").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ThroughBLNo", ._ThroughBLNo)
                cmdSQL.Parameters("@p_ThroughBLNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperCode", ._ShipperCode)
                cmdSQL.Parameters("@p_ShipperCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperName1", ._ShipperName1)
                cmdSQL.Parameters("@p_ShipperName1").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperName2", ._ShipperName2)
                cmdSQL.Parameters("@p_ShipperName2").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperName3", ._ShipperName3)
                cmdSQL.Parameters("@p_ShipperName3").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperName4", ._ShipperName4)
                cmdSQL.Parameters("@p_ShipperName4").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperName5", ._ShipperName5)
                cmdSQL.Parameters("@p_ShipperName5").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperName6", ._ShipperName6)
                cmdSQL.Parameters("@p_ShipperName6").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeCode", ._ConsigneeCode)
                cmdSQL.Parameters("@p_ConsigneeCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeName1", ._ConsigneeName1)
                cmdSQL.Parameters("@p_ConsigneeName1").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeName2", ._ConsigneeName2)
                cmdSQL.Parameters("@p_ConsigneeName2").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeName3", ._ConsigneeName3)
                cmdSQL.Parameters("@p_ConsigneeName3").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeName4", ._ConsigneeName4)
                cmdSQL.Parameters("@p_ConsigneeName4").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeName5", ._ConsigneeName5)
                cmdSQL.Parameters("@p_ConsigneeName5").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeName6", ._ConsigneeName6)
                cmdSQL.Parameters("@p_ConsigneeName6").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NotifyPartyCode", ._NotifyPartyCode)
                cmdSQL.Parameters("@p_NotifyPartyCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NotifyPartyName1", ._NotifyPartyName1)
                cmdSQL.Parameters("@p_NotifyPartyName1").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NotifyPartyName2", ._NotifyPartyName2)
                cmdSQL.Parameters("@p_NotifyPartyName2").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NotifyPartyName3", ._NotifyPartyName3)
                cmdSQL.Parameters("@p_NotifyPartyName3").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NotifyPartyName4", ._NotifyPartyName4)
                cmdSQL.Parameters("@p_NotifyPartyName4").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NotifyPartyName5", ._NotifyPartyName5)
                cmdSQL.Parameters("@p_NotifyPartyName5").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NotifyPartyName6", ._NotifyPartyName6)
                cmdSQL.Parameters("@p_NotifyPartyName6").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ForwarderCode", ._ForwarderCode)
                cmdSQL.Parameters("@p_ForwarderCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ForwarderName1", ._ForwarderName1)
                cmdSQL.Parameters("@p_ForwarderName1").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ForwarderName2", ._ForwarderName2)
                cmdSQL.Parameters("@p_ForwarderName2").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ForwarderName3", ._ForwarderName3)
                cmdSQL.Parameters("@p_ForwarderName3").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ForwarderName4", ._ForwarderName4)
                cmdSQL.Parameters("@p_ForwarderName4").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ForwarderName5", ._ForwarderName5)
                cmdSQL.Parameters("@p_ForwarderName5").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ForwarderName6", ._ForwarderName6)
                cmdSQL.Parameters("@p_ForwarderName6").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PreCarrierCode", ._PreCarrierCode)
                cmdSQL.Parameters("@p_PreCarrierCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PreCarrierName", ._PreCarrierName)
                cmdSQL.Parameters("@p_PreCarrierName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PlaceOfDeliveryCode", ._PlaceOfDeliveryCode)
                cmdSQL.Parameters("@p_PlaceOfDeliveryCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PlaceOfDeliveryName", ._PlaceOfDeliveryName)
                cmdSQL.Parameters("@p_PlaceOfDeliveryName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PartyToContactCode", ._PartyToContactCode)
                cmdSQL.Parameters("@p_PartyToContactCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PartyToContactName1", ._PartyToContactName1)
                cmdSQL.Parameters("@p_PartyToContactName1").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PartyToContactName2", ._PartyToContactName2)
                cmdSQL.Parameters("@p_PartyToContactName2").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PartyToContactName3", ._PartyToContactName3)
                cmdSQL.Parameters("@p_PartyToContactName3").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PartyToContactName4", ._PartyToContactName4)
                cmdSQL.Parameters("@p_PartyToContactName4").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PartyToContactName5", ._PartyToContactName5)
                cmdSQL.Parameters("@p_PartyToContactName5").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PartyToContactName6", ._PartyToContactName6)
                cmdSQL.Parameters("@p_PartyToContactName6").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_FinalDestinationCode", ._FinalDestinationCode)
                cmdSQL.Parameters("@p_FinalDestinationCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_FinalDestinationName", ._FinalDestinationName)
                cmdSQL.Parameters("@p_FinalDestinationName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Freight", ._Freight)
                cmdSQL.Parameters("@p_Freight").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SurrenderWaybillDiv", ._SurrenderWaybillDiv)
                cmdSQL.Parameters("@p_SurrenderWaybillDiv").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_GrossWeightKGMInteger", ._GrossWeightKGMInteger)
                cmdSQL.Parameters("@p_GrossWeightKGMInteger").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_GrossWeightKGMFraction", ._GrossWeightKGMFraction)
                cmdSQL.Parameters("@p_GrossWeightKGMFraction").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_MeasurementInteger", ._MeasurementInteger)
                cmdSQL.Parameters("@p_MeasurementInteger").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_MeasurementFraction", ._MeasurementFraction)
                cmdSQL.Parameters("@p_MeasurementFraction").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_TotalQuantity", ._TotalQuantity)
                cmdSQL.Parameters("@p_TotalQuantity").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_TotalQuantityUnitCode", ._TotalQuantityUnitCode)
                cmdSQL.Parameters("@p_TotalQuantityUnitCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_TotalQuantityUnitName", ._TotalQuantityUnitName)
                cmdSQL.Parameters("@p_TotalQuantityUnitName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_TotalInWords", ._TotalInWords)
                cmdSQL.Parameters("@p_TotalInWords").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_MerchantsDeclared", ._MerchantsDeclared)
                cmdSQL.Parameters("@p_MerchantsDeclared").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Currency", ._Currency)
                cmdSQL.Parameters("@p_Currency").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepaidAtCode", ._PrepaidAtCode)
                cmdSQL.Parameters("@p_PrepaidAtCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepaidAtName", ._PrepaidAtName)
                cmdSQL.Parameters("@p_PrepaidAtName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PayableAtCode", ._PayableAtCode)
                cmdSQL.Parameters("@p_PayableAtCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PayableAtName", ._PayableAtName)
                cmdSQL.Parameters("@p_PayableAtName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PlaceAndDateOfCode", ._PlaceAndDateOfCode)
                cmdSQL.Parameters("@p_PlaceAndDateOfCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PlaceAndDateOfName", ._PlaceAndDateOfName)
                cmdSQL.Parameters("@p_PlaceAndDateOfName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_TotalPrepaidInCode", ._TotalPrepaidInCode)
                cmdSQL.Parameters("@p_TotalPrepaidInCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_TotalPrepaidInName", ._TotalPrepaidInName)
                cmdSQL.Parameters("@p_TotalPrepaidInName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_NoOfOriginalBSLN", ._NoOfOriginalBSLN)
                cmdSQL.Parameters("@p_NoOfOriginalBSLN").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_BLDiv", ._BLDiv)
                cmdSQL.Parameters("@p_BLDiv").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ETAPortOfLoading", Format(._ETAPortOfLoading, "yyyyMMdd"))
                cmdSQL.Parameters("@p_ETAPortOfLoading").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ETDPortOfLoading", Format(._ETDPortOfLoading, "yyyyMMdd"))
                cmdSQL.Parameters("@p_ETDPortOfLoading").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ETAPortOfDischarge", Format(._ETAPortOfDischarge, "yyyyMMdd"))
                cmdSQL.Parameters("@p_ETAPortOfDischarge").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ETDPortOfDischarge", Format(._ETDPortOfDischarge, "yyyyMMdd"))
                cmdSQL.Parameters("@p_ETDPortOfDischarge").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PortOfTransitCode", ._PortOfTransitCode)
                cmdSQL.Parameters("@p_PortOfTransitCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PortOfTransitName", ._PortOfTransitName)
                cmdSQL.Parameters("@p_PortOfTransitName").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ETATransit", ._ETATransit)
                cmdSQL.Parameters("@p_ETATransit").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ETDTransit", ._ETDTransit)
                cmdSQL.Parameters("@p_ETDTransit").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ATAPortOfDischarge", ._ATAPortOfDischarge)
                cmdSQL.Parameters("@p_ATAPortOfDischarge").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", CurrentUser._User_ID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", CurrentUser._User_ID)
                cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.ExecuteNonQuery()
                ._ID = cmdSQL.Parameters("@p_ID_Out").Value
            End With

            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "DELETE FROM tbl_frwdg_docs_bookings WHERE FrwdgDocsID = @FrwdgDocsID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@FrwdgDocsID", clsHBL._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsFrwdgDocsBooking In clsHBL._BookingDetails
                cmdSQL.CommandText = "sp_frwdgdocsbookingsave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_FrwdgDocsID", clsHBL._ID)
                    cmdSQL.Parameters("@p_FrwdgDocsID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_BookingID", ._BookingID)
                    cmdSQL.Parameters("@p_BookingID").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            cmdSQL.CommandText = "DELETE FROM tbl_frwdg_docs_container WHERE HeaderID = @HeaderID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@HeaderID", clsHBL._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsFrwdgDocsContainer In clsHBL._ContainerDetails
                cmdSQL.CommandText = "sp_frwdgdocscontainersave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_HeaderID", clsHBL._ID)
                    cmdSQL.Parameters("@p_HeaderID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_DataDiv", ._DataDiv)
                    cmdSQL.Parameters("@p_DataDiv").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ItemLines", ._ItemLines)
                    cmdSQL.Parameters("@p_ItemLines").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ContainerSize", ._ContainerSize)
                    cmdSQL.Parameters("@p_ContainerSize").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ContainerType", ._ContainerType)
                    cmdSQL.Parameters("@p_ContainerType").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ContainerNumber", ._ContainerNumber)
                    cmdSQL.Parameters("@p_ContainerNumber").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_SealNumber", ._SealNumber)
                    cmdSQL.Parameters("@p_SealNumber").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_GrossWeightKGMInteger", ._GrossWeightKGMInteger)
                    cmdSQL.Parameters("@p_GrossWeightKGMInteger").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_GrossWeightKGMFraction", ._GrossWeightKGMFraction)
                    cmdSQL.Parameters("@p_GrossWeightKGMFraction").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_MeasurementInteger", ._MeasurementInteger)
                    cmdSQL.Parameters("@p_MeasurementInteger").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_MeasurementFraction", ._MeasurementFraction)
                    cmdSQL.Parameters("@p_MeasurementFraction").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_Quantity", ._Quantity)
                    cmdSQL.Parameters("@p_Quantity").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            cmdSQL.CommandText = "DELETE FROM tbl_frwdg_docs_marks_nos WHERE HeaderID = @HeaderID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@HeaderID", clsHBL._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsFrwdgDocsMarksAndNumbers In clsHBL._MarksAndNumbersDetails
                cmdSQL.CommandText = "sp_frwdgdocsmarksnos"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_HeaderID", clsHBL._ID)
                    cmdSQL.Parameters("@p_HeaderID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_DataDiv", ._DataDiv)
                    cmdSQL.Parameters("@p_DataDiv").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ItemLines", ._ItemLines)
                    cmdSQL.Parameters("@p_ItemLines").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_MarksAndNumbers", ._MarksAndNumbers)
                    cmdSQL.Parameters("@p_MarksAndNumbers").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            cmdSQL.CommandText = "DELETE FROM tbl_frwdg_docs_description WHERE HeaderID = @HeaderID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@HeaderID", clsHBL._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsFrwdgDocsDescription In clsHBL._DescriptionDetails
                cmdSQL.CommandText = "sp_frwdgdocsdescriptionsave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_HeaderID", clsHBL._ID)
                    cmdSQL.Parameters("@p_HeaderID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_DataDiv", ._DataDiv)
                    cmdSQL.Parameters("@p_DataDiv").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ItemLines", ._ItemLines)
                    cmdSQL.Parameters("@p_ItemLines").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_DescriptionOfGoods", ._DescriptionOfGoods)
                    cmdSQL.Parameters("@p_DescriptionOfGoods").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            cmdSQL.CommandText = "DELETE FROM tbl_frwdg_docs_freight_charge WHERE HeaderID = @HeaderID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@HeaderID", clsHBL._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsFrwdgDocsFreightAndCharge In clsHBL._FreightChargeDetails
                cmdSQL.CommandText = "sp_frwdgdocsfreightcharge"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_HeaderID", clsHBL._ID)
                    cmdSQL.Parameters("@p_HeaderID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_DataDiv", ._DataDiv)
                    cmdSQL.Parameters("@p_DataDiv").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ItemLines", ._ItemLines)
                    cmdSQL.Parameters("@p_ItemLines").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ChargeName", ._ChargeName)
                    cmdSQL.Parameters("@p_ChargeName").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_Currency", ._Currency)
                    cmdSQL.Parameters("@p_Currency").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_UnitPrice", ._UnitPrice)
                    cmdSQL.Parameters("@p_UnitPrice").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_Quantity", ._Quantity)
                    cmdSQL.Parameters("@p_Quantity").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            cmdSQL.CommandText = "DELETE FROM tbl_frwdg_docs_body WHERE HeaderID = @HeaderID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@HeaderID", clsHBL._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            For Each clsTemp As clsFrwdgDocsBody In clsHBL._BodyDetails
                cmdSQL.CommandText = "sp_frwdgdocsbodysave"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsTemp
                    cmdSQL.Parameters.AddWithValue("@p_HeaderID", clsHBL._ID)
                    cmdSQL.Parameters("@p_HeaderID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_DataDiv", ._DataDiv)
                    cmdSQL.Parameters("@p_DataDiv").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ItemLines", ._ItemLines)
                    cmdSQL.Parameters("@p_ItemLines").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_MarksAndNumbers", ._MarksAndNumbers)
                    cmdSQL.Parameters("@p_MarksAndNumbers").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_PKGS", ._PKGS)
                    cmdSQL.Parameters("@p_PKGS").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_DescriptionOfGoods", ._DescriptionOfGoods)
                    cmdSQL.Parameters("@p_DescriptionOfGoods").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_Free", ._Free)
                    cmdSQL.Parameters("@p_Free").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_GrossWeight", ._GrossWeight)
                    cmdSQL.Parameters("@p_GrossWeight").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_Measurement", ._Measurement)
                    cmdSQL.Parameters("@p_Measurement").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            trnSQL.Commit()
            cmdSQL.Dispose()

            Return clsHBL
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

            Return Nothing
        End Try
    End Function

    Public Function ForwardingDocsMBLSearchByMBLNo(ByVal _MBLNo As String, ByVal _CompanyCode As String, ByVal _PreviewTypeID As Integer) As clsFrwdgDocsMBL
        Dim clsMBL As New clsFrwdgDocsMBL
        Try
            Dim lngID As Long = 0
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT ID FROM v_frwdg_docs_mbl WHERE MBLNo = @MBLNo AND CompanyCode = @CompanyCode AND PreviewTypeID = @PreviewTypeID"
            cmdSQL.Parameters.AddWithValue("@MBLNo", _MBLNo)
            cmdSQL.Parameters.AddWithValue("@CompanyCode", _CompanyCode)
            cmdSQL.Parameters.AddWithValue("@PreviewTypeID", _PreviewTypeID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                lngID = reader.Item("ID")
            End While

            reader.Close()
            cmdSQL.Dispose()

            If lngID > 0 Then
                clsMBL = ForwardingDocsMBLSearchByID(lngID)
            Else
                clsMBL = New clsFrwdgDocsMBL
            End If
            Return clsMBL
        Catch ex As Exception
            MsgBox(ex.Message)
            clsMBL = New clsFrwdgDocsMBL
            Return clsMBL
        End Try
    End Function

    Public Function ForwardingDocsMBLSearchByID(ByVal _ID As Long) As clsFrwdgDocsMBL
        Dim clsMBL As New clsFrwdgDocsMBL

        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_frwdg_docs_mbl WHERE ID = @ID"
            cmdSQL.Parameters.AddWithValue("@ID", _ID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsMBL
                    ._ID = _NotNull(reader.Item("ID"), 0)
                    ._MBLNo = _NotNull(reader.Item("MBLNo"), "")
                    With ._FreightTypeDetails
                        ._PK = _NotNull(reader.Item("FreightTypeID"), 0)
                        ._Param_Desc = _NotNull(reader.Item("FreightTypeName"), "")
                    End With
                    With ._PreviewTypeDetails
                        ._ID = _NotNull(reader.Item("PreviewTypeID"), 0)
                        ._PreviewTypeName = _NotNull(reader.Item("PreviewTypeName"), "")
                    End With
                    ._CargoType = _NotNull(reader.Item("CargoType"), "")
                    ._PlaceOfReceiptCode = _NotNull(reader.Item("PlaceOfReceiptCode"), "")
                    ._PlaceOfReceiptName = _NotNull(reader.Item("PlaceOfReceiptName"), "")
                    ._VesselCode = _NotNull(reader.Item("VesselCode"), "")
                    ._VesselName = _NotNull(reader.Item("VesselName"), "")
                    ._VOY = _NotNull(reader.Item("VOY"), "")
                    ._PortOfLoadingCode = _NotNull(reader.Item("PortOfLoadingCode"), "")
                    ._PortOfLoadingName = _NotNull(reader.Item("PortOfLoadingName"), "")
                    ._PortOfDischargeCode = _NotNull(reader.Item("PortOfDischargeCode"), "")
                    ._PortOfDischargeName = _NotNull(reader.Item("PortOfDischargeName"), "")
                    ._DevanDate = _NotNull(reader.Item("DevanDate"), "")
                    With ._PrepByDetails
                        ._User_ID = _NotNull(reader.Item("PrepByID"), "")
                        ._Last_Name = _NotNull(reader.Item("PrepByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("PrepByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("PrepByMiddle_Name"), "")
                    End With
                    ._PrepDate = _NotNull(reader.Item("PrepDate"), Nothing)
                    With ._ModByDetails
                        ._User_ID = _NotNull(reader.Item("ModByID"), "")
                        ._Last_Name = _NotNull(reader.Item("ModByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("ModByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("ModByMiddle_Name"), "")
                    End With
                    ._ModDate = _NotNull(reader.Item("ModDate"), Nothing)
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clsMBL
        Catch ex As Exception
            MsgBox(ex.Message)
            clsMBL = New clsFrwdgDocsMBL
            Return clsMBL
        End Try
    End Function

    Public Function ForwardingDocsHBLSearchByBookingNo(ByVal _BookingNo As String, ByVal _CompanyCode As String, ByVal _PreviewTypeID As Integer) As clsFrwdgDocsHBL
        Dim clsHBL As New clsFrwdgDocsHBL
        Try
            Dim lngID As Long = 0
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT FrwdgDocsID FROM v_frwdg_docs_export_booking WHERE BookingNo = @BookingNo AND CompanyCode = @CompanyCode AND PreviewTypeID = @PreviewTypeID"
            cmdSQL.Parameters.AddWithValue("@BookingNo", _BookingNo)
            cmdSQL.Parameters.AddWithValue("@CompanyCode", _CompanyCode)
            cmdSQL.Parameters.AddWithValue("@PreviewTypeID", _PreviewTypeID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            If reader.HasRows = False Then
                lngID = 0
            End If

            While reader.Read
                lngID = reader.Item("FrwdgDocsID")
            End While

            reader.Close()
            cmdSQL.Parameters.Clear()
            cmdSQL.Dispose()

            If lngID > 0 Then
                clsHBL = ForwardingDocsHBLSearchByID(lngID)
            Else
                clsHBL = New clsFrwdgDocsHBL
            End If

            Return clsHBL
        Catch ex As Exception
            MsgBox(ex.Message)
            clsHBL = New clsFrwdgDocsHBL
            Return clsHBL
        End Try
    End Function

    Public Function ForwardingDocsHBLSearchByHBLNo(ByVal _HBLNo As String, ByVal _CompanyCode As String, ByVal _PreviewTypeID As Integer) As clsFrwdgDocsHBL
        Dim clsHBL As New clsFrwdgDocsHBL
        Try
            Dim lngID As Long = 0
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT ID FROM v_frwdg_docs_hbl WHERE HBLNo = @HBLNo AND CompanyCode = @CompanyCode AND PreviewTypeID = @PreviewTypeID"
            cmdSQL.Parameters.AddWithValue("@HBLNo", _HBLNo)
            cmdSQL.Parameters.AddWithValue("@CompanyCode", _CompanyCode)
            cmdSQL.Parameters.AddWithValue("@PreviewTypeID", _PreviewTypeID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                lngID = reader.Item("ID")
            End While

            reader.Close()
            cmdSQL.Dispose()

            If lngID > 0 Then
                clsHBL = ForwardingDocsHBLSearchByID(lngID)
            Else
                clsHBL = New clsFrwdgDocsHBL
            End If

            Return clsHBL
        Catch ex As Exception
            MsgBox(ex.Message)
            clsHBL = New clsFrwdgDocsHBL
            Return clsHBL
        End Try
    End Function

    Public Function ForwardingDocsHBLSearchByID(ByVal _ID As Long) As clsFrwdgDocsHBL
        Dim clsHBL As New clsFrwdgDocsHBL

        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_frwdg_docs_hbl WHERE ID = @ID"
            cmdSQL.Parameters.AddWithValue("@ID", _ID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsHBL
                    ._ID = _NotNull(reader.Item("ID"), 0)
                    With ._MBL
                        ._ID = _NotNull(reader.Item("MBLID"), 0)
                        ._MBLNo = _NotNull(reader.Item("MBLNo"), "")
                    End With
                    ._HBLNo = _NotNull(reader.Item("HBLNo"), "")
                    ._DataDiv = _NotNull(reader.Item("DataDiv"), "")
                    ._SenderCode = _NotNull(reader.Item("SenderCode"), "")
                    ._ReceiverCode = _NotNull(reader.Item("ReceiverCode"), "")
                    ._SendDate = _NotNull(reader.Item("SendDate"), "")
                    ._SendDiv = _NotNull(reader.Item("SendDiv"), "")
                    ._ThroughBLNo = _NotNull(reader.Item("ThroughBLNo"), "")
                    ._ShipperCode = _NotNull(reader.Item("ShipperCode"), "")
                    ._ShipperName1 = _NotNull(reader.Item("ShipperName1"), "")
                    ._ShipperName2 = _NotNull(reader.Item("ShipperName2"), "")
                    ._ShipperName3 = _NotNull(reader.Item("ShipperName3"), "")
                    ._ShipperName4 = _NotNull(reader.Item("ShipperName4"), "")
                    ._ShipperName5 = _NotNull(reader.Item("ShipperName5"), "")
                    ._ShipperName6 = _NotNull(reader.Item("ShipperName6"), "")
                    ._ConsigneeCode = _NotNull(reader.Item("ConsigneeCode"), "")
                    ._ConsigneeName1 = _NotNull(reader.Item("ConsigneeName1"), "")
                    ._ConsigneeName2 = _NotNull(reader.Item("ConsigneeName2"), "")
                    ._ConsigneeName3 = _NotNull(reader.Item("ConsigneeName3"), "")
                    ._ConsigneeName4 = _NotNull(reader.Item("ConsigneeName4"), "")
                    ._ConsigneeName5 = _NotNull(reader.Item("ConsigneeName5"), "")
                    ._ConsigneeName6 = _NotNull(reader.Item("ConsigneeName6"), "")
                    ._NotifyPartyCode = _NotNull(reader.Item("NotifyPartyCode"), "")
                    ._NotifyPartyName1 = _NotNull(reader.Item("NotifyPartyName1"), "")
                    ._NotifyPartyName2 = _NotNull(reader.Item("NotifyPartyName2"), "")
                    ._NotifyPartyName3 = _NotNull(reader.Item("NotifyPartyName3"), "")
                    ._NotifyPartyName4 = _NotNull(reader.Item("NotifyPartyName4"), "")
                    ._NotifyPartyName5 = _NotNull(reader.Item("NotifyPartyName5"), "")
                    ._NotifyPartyName6 = _NotNull(reader.Item("NotifyPartyName6"), "")
                    ._ForwarderCode = _NotNull(reader.Item("ForwarderCode"), "")
                    ._ForwarderName1 = _NotNull(reader.Item("ForwarderName1"), "")
                    ._ForwarderName2 = _NotNull(reader.Item("ForwarderName2"), "")
                    ._ForwarderName3 = _NotNull(reader.Item("ForwarderName3"), "")
                    ._ForwarderName4 = _NotNull(reader.Item("ForwarderName4"), "")
                    ._ForwarderName5 = _NotNull(reader.Item("ForwarderName5"), "")
                    ._ForwarderName6 = _NotNull(reader.Item("ForwarderName6"), "")
                    ._PreCarrierCode = _NotNull(reader.Item("PreCarrierCode"), "")
                    ._PreCarrierName = _NotNull(reader.Item("PreCarrierName"), "")
                    ._PlaceOfDeliveryCode = _NotNull(reader.Item("PlaceOfDeliveryCode"), "")
                    ._PlaceOfDeliveryName = _NotNull(reader.Item("PlaceOfDeliveryName"), "")
                    ._PartyToContactCode = _NotNull(reader.Item("PartyToContactCode"), "")
                    ._PartyToContactName1 = _NotNull(reader.Item("PartyToContactName1"), "")
                    ._PartyToContactName2 = _NotNull(reader.Item("PartyToContactName2"), "")
                    ._PartyToContactName3 = _NotNull(reader.Item("PartyToContactName3"), "")
                    ._PartyToContactName4 = _NotNull(reader.Item("PartyToContactName4"), "")
                    ._PartyToContactName5 = _NotNull(reader.Item("PartyToContactName5"), "")
                    ._PartyToContactName6 = _NotNull(reader.Item("PartyToContactName6"), "")
                    ._FinalDestinationCode = _NotNull(reader.Item("FinalDestinationCode"), "")
                    ._FinalDestinationName = _NotNull(reader.Item("FinalDestinationName"), "")
                    ._Freight = _NotNull(reader.Item("Freight"), "")
                    ._SurrenderWaybillDiv = _NotNull(reader.Item("SurrenderWaybillDiv"), "")
                    ._GrossWeightKGMInteger = _NotNull(reader.Item("GrossWeightKGMInteger"), "")
                    ._GrossWeightKGMFraction = _NotNull(reader.Item("GrossWeightKGMFraction"), "")
                    ._MeasurementInteger = _NotNull(reader.Item("MeasurementInteger"), "")
                    ._MeasurementFraction = _NotNull(reader.Item("MeasurementFraction"), "")
                    ._TotalQuantity = _NotNull(reader.Item("TotalQuantity"), "")
                    ._TotalQuantityUnitCode = _NotNull(reader.Item("TotalQuantityUnitCode"), "")
                    ._TotalQuantityUnitName = _NotNull(reader.Item("TotalQuantityUnitName"), "")
                    ._TotalInWords = _NotNull(reader.Item("TotalInWords"), "")
                    ._MerchantsDeclared = _NotNull(reader.Item("MerchantsDeclared"), "")
                    ._Currency = _NotNull(reader.Item("Currency"), "")
                    ._PrepaidAtCode = _NotNull(reader.Item("PrepaidAtCode"), "")
                    ._PrepaidAtName = _NotNull(reader.Item("PrepaidAtName"), "")
                    ._PayableAtCode = _NotNull(reader.Item("PayableAtCode"), "")
                    ._PayableAtName = _NotNull(reader.Item("PayableAtName"), "")
                    ._PlaceAndDateOfCode = _NotNull(reader.Item("PlaceAndDateOfCode"), "")
                    ._PlaceAndDateOfName = _NotNull(reader.Item("PlaceAndDateOfName"), "")
                    ._TotalPrepaidInCode = _NotNull(reader.Item("TotalPrepaidInCode"), "")
                    ._TotalPrepaidInName = _NotNull(reader.Item("TotalPrepaidInName"), "")
                    ._NoOfOriginalBSLN = _NotNull(reader.Item("NoOfOriginalBSLN"), "")
                    ._BLDiv = _NotNull(reader.Item("BLDiv"), "")
                    ._ETAPortOfLoading = _NotNull(reader.Item("ETAPortOfLoading"), "")
                    ._ETDPortOfLoading = _NotNull(reader.Item("ETDPortOfLoading"), "")
                    ._ETAPortOfDischarge = _NotNull(reader.Item("ETAPortOfDischarge"), "")
                    ._ETDPortOfDischarge = _NotNull(reader.Item("ETDPortOfDischarge"), "")
                    ._PortOfTransitCode = _NotNull(reader.Item("PortOfTransitCode"), "")
                    ._PortOfTransitName = _NotNull(reader.Item("PortOfTransitName"), "")
                    ._ETATransit = _NotNull(reader.Item("ETATransit"), "")
                    ._ETDTransit = _NotNull(reader.Item("ETDTransit"), "")
                    ._ATAPortOfDischarge = _NotNull(reader.Item("ATAPortOfDischarge"), "")
                    With ._PrepByDetails
                        ._User_ID = _NotNull(reader.Item("PrepByID"), "")
                        ._Last_Name = _NotNull(reader.Item("PrepByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("PrepByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("PrepByMiddle_Name"), "")
                    End With
                    ._PrepDate = _NotNull(reader.Item("PrepDate"), Nothing)
                    With ._ModByDetails
                        ._User_ID = _NotNull(reader.Item("ModByID"), "")
                        ._Last_Name = _NotNull(reader.Item("ModByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("ModByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("ModByMiddle_Name"), "")
                    End With
                    ._ModDate = _NotNull(reader.Item("ModDate"), Nothing)
                End With
            End While
            reader.Close()
            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "SELECT * FROM tbl_frwdg_docs_container WHERE HeaderID = @HeaderID ORDER BY ItemLines"
            cmdSQL.Parameters.AddWithValue("@HeaderID", _ID)
            reader = cmdSQL.ExecuteReader

            Dim clsCont As New clsFrwdgDocsContainer
            While reader.Read
                clsCont = New clsFrwdgDocsContainer
                With clsCont
                    ._ID = _NotNull(reader.Item("ID"), "")
                    ._HeaderID = _NotNull(reader.Item("HeaderID"), "")
                    ._DataDiv = _NotNull(reader.Item("DataDiv"), "")
                    ._ItemLines = _NotNull(reader.Item("ItemLines"), "")
                    ._ContainerSize = _NotNull(reader.Item("ContainerSize"), "")
                    ._ContainerType = _NotNull(reader.Item("ContainerType"), "")
                    ._ContainerNumber = _NotNull(reader.Item("ContainerNumber"), "")
                    ._SealNumber = _NotNull(reader.Item("SealNumber"), "")
                    ._GrossWeightKGMInteger = _NotNull(reader.Item("GrossWeightKGMInteger"), "")
                    ._GrossWeightKGMFraction = _NotNull(reader.Item("GrossWeightKGMFraction"), "")
                    ._MeasurementInteger = _NotNull(reader.Item("MeasurementInteger"), "")
                    ._MeasurementFraction = _NotNull(reader.Item("MeasurementFraction"), "")
                    ._Quantity = _NotNull(reader.Item("Quantity"), "")
                End With
                clsHBL._ContainerDetails.Add(clsCont)
            End While
            reader.Close()
            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "SELECT * FROM tbl_frwdg_docs_marks_nos WHERE HeaderID = @HeaderID ORDER BY ItemLines"
            cmdSQL.Parameters.AddWithValue("@HeaderID", _ID)
            reader = cmdSQL.ExecuteReader

            Dim clsMarks As New clsFrwdgDocsMarksAndNumbers
            While reader.Read
                clsMarks = New clsFrwdgDocsMarksAndNumbers
                With clsMarks
                    ._ID = _NotNull(reader.Item("ID"), "")
                    ._HeaderID = _NotNull(reader.Item("HeaderID"), "")
                    ._DataDiv = _NotNull(reader.Item("DataDiv"), "")
                    ._ItemLines = _NotNull(reader.Item("ItemLines"), "")
                    ._MarksAndNumbers = _NotNull(reader.Item("MarksAndNumbers"), "")
                End With
                clsHBL._MarksAndNumbersDetails.Add(clsMarks)
            End While
            reader.Close()
            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "SELECT * FROM tbl_frwdg_docs_description WHERE HeaderID = @HeaderID ORDER BY ItemLines"
            cmdSQL.Parameters.AddWithValue("@HeaderID", _ID)
            reader = cmdSQL.ExecuteReader

            Dim clsDesc As New clsFrwdgDocsDescription
            While reader.Read
                clsDesc = New clsFrwdgDocsDescription
                With clsDesc
                    ._ID = _NotNull(reader.Item("ID"), "")
                    ._HeaderID = _NotNull(reader.Item("HeaderID"), "")
                    ._DataDiv = _NotNull(reader.Item("DataDiv"), "")
                    ._ItemLines = _NotNull(reader.Item("ItemLines"), "")
                    ._DescriptionOfGoods = _NotNull(reader.Item("DescriptionOfGoods"), "")
                End With
                clsHBL._DescriptionDetails.Add(clsDesc)
            End While
            reader.Close()
            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "SELECT * FROM tbl_frwdg_docs_freight_charge WHERE HeaderID = @HeaderID ORDER BY ItemLines"
            cmdSQL.Parameters.AddWithValue("@HeaderID", _ID)
            reader = cmdSQL.ExecuteReader

            Dim clsFCharge As New clsFrwdgDocsFreightAndCharge
            While reader.Read
                clsFCharge = New clsFrwdgDocsFreightAndCharge
                With clsFCharge
                    ._ID = _NotNull(reader.Item("ID"), "")
                    ._HeaderID = _NotNull(reader.Item("HeaderID"), "")
                    ._DataDiv = _NotNull(reader.Item("DataDiv"), "")
                    ._ItemLines = _NotNull(reader.Item("ItemLines"), "")
                    ._ChargeName = _NotNull(reader.Item("ChargeName"), "")
                    ._Currency = _NotNull(reader.Item("Currency"), "")
                    ._UnitPrice = _NotNull(reader.Item("UnitPrice"), "")
                    ._Quantity = _NotNull(reader.Item("Quantity"), "")
                End With
                clsHBL._FreightChargeDetails.Add(clsFCharge)
            End While
            reader.Close()
            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "SELECT * FROM tbl_frwdg_docs_body WHERE HeaderID = @HeaderID ORDER BY ItemLines"
            cmdSQL.Parameters.AddWithValue("@HeaderID", _ID)
            reader = cmdSQL.ExecuteReader

            Dim clsBody As New clsFrwdgDocsBody
            While reader.Read
                clsBody = New clsFrwdgDocsBody
                With clsBody
                    ._ID = _NotNull(reader.Item("ID"), "")
                    ._HeaderID = _NotNull(reader.Item("HeaderID"), "")
                    ._DataDiv = _NotNull(reader.Item("DataDiv"), "")
                    ._ItemLines = _NotNull(reader.Item("ItemLines"), "")
                    ._MarksAndNumbers = _NotNull(reader.Item("MarksAndNumbers"), "")
                    ._PKGS = _NotNull(reader.Item("PKGS"), "")
                    ._DescriptionOfGoods = _NotNull(reader.Item("DescriptionOfGoods"), "")
                    ._Free = _NotNull(reader.Item("Free"), "")
                    ._GrossWeight = _NotNull(reader.Item("GrossWeight"), "")
                    ._Measurement = _NotNull(reader.Item("Measurement"), "")
                End With
                clsHBL._BodyDetails.Add(clsBody)
            End While
            reader.Close()
            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "SELECT * FROM v_frwdg_docs_export_booking WHERE FrwdgDocsID = @FrwdgDocsID"
            cmdSQL.Parameters.AddWithValue("@FrwdgDocsID", _ID)
            reader = cmdSQL.ExecuteReader

            Dim clsBookings As New clsFrwdgDocsBooking
            While reader.Read
                clsBookings = New clsFrwdgDocsBooking
                With clsBookings
                    ._ID = _NotNull(reader.Item("ID"), "")
                    ._FrwdgDocsID = _NotNull(reader.Item("FrwdgDocsID"), "")
                    ._BookingID = _NotNull(reader.Item("BookingID"), "")
                    ._BookingPrefix = _NotNull(reader.Item("BookingPrefix"), "")
                    ._BookingNo = _NotNull(reader.Item("BookingNo"), "")
                End With
                clsHBL._BookingDetails.Add(clsBookings)
            End While
            reader.Close()
            cmdSQL.Parameters.Clear()
            cmdSQL.Dispose()

            Return clsHBL
        Catch ex As Exception
            MsgBox(ex.Message)
            clsHBL = New clsFrwdgDocsHBL
            Return clsHBL
        End Try
    End Function
#End Region

#Region "Brokerage"
    Public Function BrokerageJOSave(ByVal clsJO As clsBrkgJO, ByVal intSaveType As Integer) As clsBrkgJO
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_brkg_jo_save"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsJO
                cmdSQL.Parameters.AddWithValue("@p_SaveType", intSaveType)
                cmdSQL.Parameters("@p_SaveType").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_BookNo", ._BookNo)
                cmdSQL.Parameters("@p_BookNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_CompanyCode", ._CompanyDetails._Company_Code)
                cmdSQL.Parameters("@p_CompanyCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_FreightTypeID", ._FreightTypeDetails._PK)
                cmdSQL.Parameters("@p_FreightTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModeOfTransportID", ._ModeOfTransportDetails._PK)
                cmdSQL.Parameters("@p_ModeOfTransportID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_LoadTypeID", ._LoadType._PK)
                cmdSQL.Parameters("@p_LoadTypeID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_HBLNo", ._HBLNo)
                cmdSQL.Parameters("@p_HBLNo").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsignorCode", ._ConsignorDetails._Code)
                cmdSQL.Parameters("@p_ConsignorCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ShipperCode", ._ShipperDetails._Code)
                cmdSQL.Parameters("@p_ShipperCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ConsigneeCode", ._ConsigneeDetails._Code)
                cmdSQL.Parameters("@p_ConsigneeCode").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_OriginID", ._OriginDetails._PK)
                cmdSQL.Parameters("@p_OriginID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_FinalDestinationID", ._FinalDestDetails._PK)
                cmdSQL.Parameters("@p_FinalDestinationID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Commodity", ._Commodity)
                cmdSQL.Parameters("@p_Commodity").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Volume", ._Volume)
                cmdSQL.Parameters("@p_Volume").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_GrossWeight", ._GrossWeight)
                cmdSQL.Parameters("@p_GrossWeight").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ActualVolume", ._ActualVolume)
                cmdSQL.Parameters("@p_ActualVolume").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ActualGrossWeight", ._ActualGrossWeight)
                cmdSQL.Parameters("@p_ActualGrossWeight").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Completed", ._Completed)
                cmdSQL.Parameters("@p_Completed").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Cancelled", ._Cancelled)
                cmdSQL.Parameters("@p_Cancelled").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", ._PrepByDetails._User_ID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModByDetails._User_ID)
                cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_StatusID", ._StatusDetails._ID)
                cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_StatusByID", ._StatusByDetails._User_ID)
                cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.ExecuteNonQuery()
                ._ID = cmdSQL.Parameters("@p_ID_Out").Value
            End With

            trnSQL.Commit()
            cmdSQL.Dispose()
            Return clsJO
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
            clsJO = New clsBrkgJO
            Return clsJO
        End Try
    End Function

    Public Function BrokerageJOSearchByBookingNo(ByVal strBookNo As String) As clsBrkgJO
        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        cmdSQL.Connection = cnnDBMaster
        cmdSQL.CommandText = "SELECT * FROM v_brkg_jo WHERE BookNo = @BookNo"
        cmdSQL.Parameters.AddWithValue("@BookNo", strBookNo)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        If reader.HasRows = False Then
            MsgBox("Booking No. not found.", MsgBoxStyle.Information, "System Message")
            reader.Close()
            Return New clsBrkgJO
        End If

        Dim lngID As Long
        While reader.Read
            lngID = reader.Item("ID")
        End While

        reader.Close()
        cmdSQL.Dispose()

        Return BrokerageJOSearch(lngID)
    End Function

    Public Function BrokerageJOSearch(ByVal lngID As Long) As clsBrkgJO
        Dim clsJO As New clsBrkgJO

        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_brkg_jo WHERE ID = @ID"
            cmdSQL.Parameters.AddWithValue("@ID", lngID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsJO
                    ._ID = reader.Item("ID")
                    ._BookNo = _NotNull(reader.Item("BookNo"), "")
                    With ._CompanyDetails
                        ._Company_Code = _NotNull(reader.Item("CompanyCode"), "")
                        ._Company_Name = _NotNull(reader.Item("Company_Name"), "")
                        ._Company_FullName = _NotNull(reader.Item("Company_FullName"), "")
                    End With
                    With ._FreightTypeDetails
                        ._PK = _NotNull(reader.Item("FreightTypeID"), 0)
                        ._Param_Desc = _NotNull(reader.Item("FreightTypeName"), "")
                    End With
                    With ._ModeOfTransportDetails
                        ._PK = _NotNull(reader.Item("ModeOfTransportID"), 0)
                        ._Param_Desc = _NotNull(reader.Item("ModeOfTransportName"), "")
                    End With
                    With ._LoadType
                        ._PK = _NotNull(reader.Item("LoadTypeID"), 0)
                        ._Param_Desc = _NotNull(reader.Item("LoadTypeName"), "")
                    End With
                    ._HBLNo = _NotNull(reader.Item("HBLNo"), "")
                    With ._ConsignorDetails
                        ._Code = _NotNull(reader.Item("ConsignorCode"), "")
                        ._Description = _NotNull(reader.Item("ConsignorName"), "")
                    End With
                    With ._ShipperDetails
                        ._Code = _NotNull(reader.Item("ShipperCode"), "")
                        ._Description = _NotNull(reader.Item("ShipperName"), "")
                    End With
                    With ._ConsigneeDetails
                        ._Code = _NotNull(reader.Item("ConsigneeCode"), "")
                        ._Description = _NotNull(reader.Item("ConsigneeName"), "")
                    End With
                    With ._OriginDetails
                        ._PK = _NotNull(reader.Item("OriginID"), "")
                        ._Description = _NotNull(reader.Item("OriginName"), "")
                    End With
                    With ._FinalDestDetails
                        ._PK = _NotNull(reader.Item("FinalDestinationID"), "")
                        ._Description = _NotNull(reader.Item("FinalDestinationName"), "")
                    End With
                    ._Commodity = _NotNull(reader.Item("Commodity"), "")
                    ._Volume = _NotNull(reader.Item("Volume"), "")
                    ._GrossWeight = _NotNull(reader.Item("GrossWeight"), "")
                    ._ActualVolume = _NotNull(reader.Item("ActualVolume"), "")
                    ._ActualGrossWeight = _NotNull(reader.Item("ActualGrossWeight"), "")
                    With ._PrepByDetails
                        ._User_ID = _NotNull(reader.Item("PrepByID"), "")
                        ._Last_Name = _NotNull(reader.Item("PrepByLName"), "")
                        ._First_Name = _NotNull(reader.Item("PrepByFName"), "")
                        ._Middle_Name = _NotNull(reader.Item("PrepByMName"), "")
                    End With
                    ._PrepDate = _NotNull(reader.Item("PrepDate"), Nothing)
                    With ._ModByDetails
                        ._User_ID = _NotNull(reader.Item("ModByID"), "")
                        ._Last_Name = _NotNull(reader.Item("ModByLName"), "")
                        ._First_Name = _NotNull(reader.Item("ModByFName"), "")
                        ._Middle_Name = _NotNull(reader.Item("ModByMName"), "")
                    End With
                    ._ModDate = _NotNull(reader.Item("ModDate"), Nothing)
                    With ._StatusDetails
                        ._ID = _NotNull(reader.Item("StatusID"), "")
                        ._StatName = _NotNull(reader.Item("StatusName"), "")
                        ._StatOrder = _NotNull(reader.Item("StatOrder"), 0)
                        With ._StatusTypeDetails
                            ._ID = _NotNull(reader.Item("StatTypeID"), 0)
                            ._Description = _NotNull(reader.Item("StatTypeName"), "")
                        End With
                    End With
                    With ._StatusByDetails
                        ._User_ID = _NotNull(reader.Item("StatusByID"), "")
                        ._Last_Name = _NotNull(reader.Item("StatByLName"), "")
                        ._First_Name = _NotNull(reader.Item("StatByFName"), "")
                        ._Middle_Name = _NotNull(reader.Item("StatByMName"), "")
                    End With
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()
            Return clsJO
        Catch ex As Exception
            MsgBox(ex.Message)
            clsJO = New clsBrkgJO
            Return clsJO
        End Try
    End Function

    Public Function BrokerageItinerarySave(ByVal clsItinerary As clsBrkgItineraryHeader, ByVal intSaveType As Integer) As clsBrkgItineraryHeader
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_brkg_itinerary_header_save"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsItinerary
                cmdSQL.Parameters.AddWithValue("@p_SaveType", intSaveType)
                cmdSQL.Parameters("@p_SaveType").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PersonelListID", ._PersonelDetails._ID)
                cmdSQL.Parameters("@p_PersonelListID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Location", ._Location)
                cmdSQL.Parameters("@p_Location").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Remarks", ._Remarks)
                cmdSQL.Parameters("@p_Remarks").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", ._PrepByDetails._User_ID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModByDetails._User_ID)
                cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_StatusID", ._StatusDetails._ID)
                cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_StatusByID", ._StatusByDetails._User_ID)
                cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.ExecuteNonQuery()
                ._ID = cmdSQL.Parameters("@p_ID_Out").Value
            End With
            cmdSQL.Parameters.Clear()

            cmdSQL.CommandText = "DELETE FROM `tbl_brkg_itinerary_details` WHERE HeaderID = @HeaderID"
            cmdSQL.CommandType = CommandType.TableDirect
            cmdSQL.Parameters.AddWithValue("@HeaderID", clsItinerary._ID)
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Parameters.Clear()

            Dim clsDetails As New clsBrkgItineraryDetails
            For Each clsDetails In clsItinerary._ListOfItineraryDetails
                cmdSQL.CommandText = "sp_brkg_itinerary_details_save"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsDetails
                    cmdSQL.Parameters.AddWithValue("@p_HeaderID", clsItinerary._ID)
                    cmdSQL.Parameters("@p_HeaderID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_JOID", ._JODetails._ID)
                    cmdSQL.Parameters("@p_JOID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_Remarks", ._Remarks)
                    cmdSQL.Parameters("@p_Remarks").Direction = ParameterDirection.Input
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()

                cmdSQL.CommandText = "sp_brkg_jo_changestatus"
                cmdSQL.CommandType = CommandType.StoredProcedure

                With clsDetails._JODetails
                    cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusID", ._StatusDetails._ID)
                    cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusByID", ._StatusByDetails._User_ID)
                    cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                    cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output
                End With

                cmdSQL.ExecuteNonQuery()
                cmdSQL.Parameters.Clear()
            Next

            trnSQL.Commit()
            cmdSQL.Dispose()
            Return clsItinerary
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
            clsItinerary = New clsBrkgItineraryHeader
            Return clsItinerary
        End Try
    End Function

    Public Function BrokerageItinerarySearch(ByVal lngID As Long) As clsBrkgItineraryHeader
        Dim clsTemp As New clsBrkgItineraryHeader
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_brkg_itinerary_header WHERE ID = @ID"
            cmdSQL.Parameters.AddWithValue("@ID", lngID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTemp
                    ._ID = reader.Item("ID")
                    With ._PersonelDetails
                        ._ID = _NotNull(reader.Item("PersonelListID"), "")
                        ._TypeDetails._ID = _NotNull(reader.Item("PersonelTypeID"), 0)
                        ._TypeDetails._Description = _NotNull(reader.Item("PersonelTypeName"), "")
                        With ._PersonelDetails
                            ._Last_Name = _NotNull(reader.Item("PersonelLName"), "")
                            ._First_Name = _NotNull(reader.Item("PersonelFName"), "")
                            ._Middle_Name = _NotNull(reader.Item("PersonelMName"), "")
                        End With
                    End With
                    ._Location = _NotNull(reader.Item("Location"), "")
                    ._Remarks = _NotNull(reader.Item("Remarks"), "")
                    With ._PrepByDetails
                        ._User_ID = _NotNull(reader.Item("PrepByID"), "")
                        ._Last_Name = _NotNull(reader.Item("PrepByLName"), "")
                        ._First_Name = _NotNull(reader.Item("PrepByFName"), "")
                        ._Middle_Name = _NotNull(reader.Item("PrepByMName"), "")
                    End With
                    ._PrepDate = _NotNull(reader.Item("PrepDate"), Nothing)
                    With ._ModByDetails
                        ._User_ID = _NotNull(reader.Item("PrepByID"), "")
                        ._Last_Name = _NotNull(reader.Item("PrepByLName"), "")
                        ._First_Name = _NotNull(reader.Item("PrepByFName"), "")
                        ._Middle_Name = _NotNull(reader.Item("PrepByMName"), "")
                    End With
                    ._ModDate = _NotNull(reader.Item("ModDate"), Nothing)
                    With ._StatusDetails
                        With ._StatusTypeDetails
                            ._ID = _NotNull(reader.Item("StatTypeID"), 0)
                            ._Description = _NotNull(reader.Item("StatTypeName"), "")
                        End With
                        ._ID = _NotNull(reader.Item("ID"), 0)
                        ._StatName = _NotNull(reader.Item("StatusName"), "")
                        ._StatOrder = _NotNull(reader.Item("StatOrder"), 0)
                    End With
                    With ._StatusByDetails
                        ._User_ID = _NotNull(reader.Item("StatusByID"), "")
                        ._Last_Name = _NotNull(reader.Item("StatusByLName"), "")
                        ._First_Name = _NotNull(reader.Item("StatusByFName"), "")
                        ._Middle_Name = _NotNull(reader.Item("StatusByMName"), "")
                    End With
                    ._StatusDate = _NotNull(reader.Item("StatusDate"), Nothing)
                End With
            End While
            reader.Close()

            cmdSQL.Parameters.Clear()
            cmdSQL.CommandText = "SELECT * FROM v_brkg_itinerary_details WHERE HeaderID = @HeaderID"
            cmdSQL.Parameters.AddWithValue("@HeaderID", lngID)

            Dim clsTempDetails As New clsBrkgItineraryDetails
            reader = cmdSQL.ExecuteReader
            While reader.Read
                clsTempDetails = New clsBrkgItineraryDetails
                With clsTempDetails
                    ._ID = _NotNull(reader.Item("ID"), 0)
                    ._HeaderID = _NotNull(reader.Item("HeaderID"), 0)
                    With ._JODetails
                        ._ID = _NotNull(reader.Item("JOID"), 0)
                        ._BookNo = _NotNull(reader.Item("BookNo"), "")
                        With ._FreightTypeDetails
                            ._PK = _NotNull(reader.Item("FreightTypeID"), 0)
                            ._Param_Desc = _NotNull(reader.Item("FreightTypeName"), "")
                        End With
                        With ._ModeOfTransportDetails
                            ._PK = _NotNull(reader.Item("ModeOfTransportID"), 0)
                            ._Param_Desc = _NotNull(reader.Item("ModeOfTransportName"), "")
                        End With
                        With ._LoadType
                            ._PK = _NotNull(reader.Item("LoadTypeID"), 0)
                            ._Param_Desc = _NotNull(reader.Item("LoadTypeName"), "")
                        End With
                        ._HBLNo = _NotNull(reader.Item("HBLNo"), "")
                        With ._StatusDetails
                            With ._StatusTypeDetails
                                ._ID = _NotNull(reader.Item("StatTypeID"), 0)
                                ._Description = _NotNull(reader.Item("StatTypeName"), "")
                            End With
                            ._ID = _NotNull(reader.Item("StatusID"), 0)
                            ._StatName = _NotNull(reader.Item("StatusName"), "")
                        End With
                    End With
                    ._Remarks = _NotNull(reader.Item("Remarks"), "")
                End With

                clsTemp._ListOfItineraryDetails.Add(clsTempDetails)
            End While

            reader.Close()
            cmdSQL.Dispose()
            Return clsTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            clsTemp = New clsBrkgItineraryHeader
            Return clsTemp
        End Try
    End Function
#End Region

#Region "Trucking"

#End Region



    Public Function SaveEmailAddress(ByVal clsTempEmailAddress As clsEmailAddress) As clsEmailAddress
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_email_save"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsTempEmailAddress
                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_EmailAddress", ._EmailAddress)
                cmdSQL.Parameters("@p_EmailAddress").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SMTP_Host", ._SMTP_Host)
                cmdSQL.Parameters("@p_SMTP_Host").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SMTP_Port", ._SMTP_Port)
                cmdSQL.Parameters("@p_SMTP_Port").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SMTP_Username", ._SMTP_Username)
                cmdSQL.Parameters("@p_SMTP_Username").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SMTP_Password", EncryptString(._SMTP_Password, 1))
                cmdSQL.Parameters("@p_SMTP_Password").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_SMTP_EnableSSL", ._SMTP_EnableSSL)
                cmdSQL.Parameters("@p_SMTP_EnableSSL").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", ._PrepBy._User_ID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModBy._User_ID)
                cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.ExecuteNonQuery()
                ._ID = cmdSQL.Parameters("@p_ID_Out").Value
            End With

            trnSQL.Commit()
            cmdSQL.Dispose()
            SaveEmailAddress = clsTempEmailAddress
        Catch ex As Exception
            SaveEmailAddress = Nothing
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
    End Function

    Public Function SaveCompanyServiceOffered(ByVal clsTempCompanyServiceOffered As clsCompanyServiceOffered) As clsCompanyServiceOffered
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_companyserviceofferedsave"
            cmdSQL.CommandType = CommandType.StoredProcedure

            With clsTempCompanyServiceOffered
                cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
                cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Company_Code", ._Company._Company_Code)
                cmdSQL.Parameters("@p_Company_Code").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_Service_Code", ._ServiceOffered._PK)
                cmdSQL.Parameters("@p_Service_Code").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_PrepByID", ._PrepBy._User_ID)
                cmdSQL.Parameters("@p_PrepByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ModByID", ._ModBy._User_ID)
                cmdSQL.Parameters("@p_ModByID").Direction = ParameterDirection.Input

                cmdSQL.Parameters.AddWithValue("@p_ID_Out", ._ID)
                cmdSQL.Parameters("@p_ID_Out").Direction = ParameterDirection.Output

                cmdSQL.ExecuteNonQuery()
                ._ID = cmdSQL.Parameters("@p_ID_Out").Value
            End With

            trnSQL.Commit()
            cmdSQL.Dispose()
            SaveCompanyServiceOffered = clsTempCompanyServiceOffered
        Catch ex As Exception
            SaveCompanyServiceOffered = Nothing
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
    End Function

    'Search Record
    Public Function SearchCompanyRecord(ByVal strCompanyCode As String) As clsCompanyHeader
        Try
            Dim clsTemp As New clsCompanyHeader
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM tbl_company WHERE `Company_Code` = @Company_Code"
            cmdSQL.Parameters.AddWithValue("@Company_Code", strCompanyCode)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTemp
                    ._Company_Code = reader.Item("Company_Code")
                    ._Company_Main = reader.Item("Company_Main")
                    ._Company_Name = reader.Item("Company_Name")
                    ._Company_FullName = reader.Item("Company_FullName")
                    ._Active = reader.Item("Active")
                    ._Address = reader.Item("Address")
                    ._ContactNo = reader.Item("ContactNo")
                    ._Tin = reader.Item("Tin")
                    ._AsClient._Code = reader.Item("ClientCode")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clsTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function SearchClientRecord(ByVal strCode As String) As clsClientHeader
        Try
            Dim clsTemp As New clsClientHeader
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_client WHERE `Code` = @Code"
            cmdSQL.Parameters.AddWithValue("@Code", strCode)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTemp
                    ._Code = reader.Item("Code")
                    ._Description = reader.Item("Description")
                    ._Prefix = reader.Item("Prefix")
                    ._Addr1 = reader.Item("Addr1")
                    ._AddrCity = reader.Item("AddrCity")
                    ._CityDesc = reader.Item("CityDesc")
                    ._AddrCountry = reader.Item("AddrCountry")
                    ._CountryDesc = reader.Item("CountryDesc")
                    ._AddrZipCode = reader.Item("AddrZipCode")
                    ._BusStyle = reader.Item("BusStyle")
                    ._ContactMobileNo = reader.Item("ContactMobileNo")
                    ._ContactFax = reader.Item("ContactFax")
                    ._ContactLandline = reader.Item("ContactLandline")
                    ._ContactPerson = reader.Item("ContactPerson")
                    ._Email = reader.Item("Email")
                    ._Tin = reader.Item("Tin")
                    ._SalesTax = reader.Item("SalesTax")
                    ._SalesTaxDesc = reader.Item("SalesTaxDesc")
                    ._Terms = reader.Item("Terms")
                    ._TermsDesc = reader.Item("TermsDesc")
                    ._CreditLimitAmt = reader.Item("CreditLimitAmt")
                    ._CreditLimitCurrency = reader.Item("CreditLimitCurrency")
                    ._CurrencyDesc = reader.Item("CurrencyDesc")
                    ._SiteDetails._PK = reader.Item("SitePK")
                    ._SiteDetails._Site_Code = reader.Item("Site_Code")
                    ._SiteDetails._Site_Name = reader.Item("Site_Name")
                    ._Account_TypeID = reader.Item("Account_TypeID")
                    ._Account_TypePrefix = reader.Item("Account_TypePrefix")
                    ._Account_TypeDesc = reader.Item("Account_TypeDesc")
                    ._Account_HandlerID = reader.Item("Account_HandlerID")
                    ._Account_HandlerName = reader.Item("Account_HandlerName")
                    ._ModifiedBy = reader.Item("ModifiedBy")
                    ._ModifiedByName = reader.Item("Employee_Name")
                    ._ModifiedDate = reader.Item("ModifiedDate")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clsTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function SearchPort(ByVal intPK As Integer) As clsPort
        Try
            Dim clsTemp As New clsPort

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM `v_port` WHERE PK = @PK"
            cmdSQL.Parameters.AddWithValue("@PK", intPK)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTemp
                    ._PK = reader.Item("PK")
                    With ._CountryDetails
                        ._PK = reader.Item("Country_PK")
                        ._Description = reader.Item("Country_Desc")
                    End With
                    ._Description = reader.Item("Description")
                    ._UNLOCODE = _NotNull(reader.Item("UNLOCODE"), "")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clsTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function SearchFileLocation(ByVal strLocationCode As String) As clsFileLocation
        SearchFileLocation = New clsFileLocation
        Try
            Dim clsTemp As New clsFileLocation
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM lib_filelocation WHERE `Code` = @Code"
            With cmdSQL.Parameters
                .AddWithValue("@Code", strLocationCode)
            End With

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            If reader.HasRows = False Then
                MsgBox("File Location Code does not exist!", MsgBoxStyle.Information, "System Message")
                SearchFileLocation = Nothing
                reader.Close()
                Exit Function
            End If

            While reader.Read
                With clsTemp
                    ._ID = reader.Item("ID")
                    ._Code = reader.Item("Code")
                    ._Location = reader.Item("Location")
                    ._Active = reader.Item("Active")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()

            SearchFileLocation = clsTemp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function SearchEmailAddress(ByVal lngID As Long) As clsEmailAddress
        Try
            Dim clsTemp As New clsEmailAddress
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_email WHERE `ID` = @ID"
            cmdSQL.Parameters.AddWithValue("@ID", lngID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTemp
                    ._ID = reader.Item("ID")
                    ._EmailAddress = reader.Item("EmailAddress")
                    ._SMTP_Host = reader.Item("SMTP_Host")
                    ._SMTP_Port = reader.Item("SMTP_Port")
                    ._SMTP_Username = reader.Item("SMTP_Username")
                    ._SMTP_Password = DecryptString(reader.Item("SMTP_Password"), 1)
                    ._SMTP_EnableSSL = reader.Item("SMTP_EnableSSL")
                    ._PrepBy._User_ID = reader.Item("PrepByID")
                    ._PrepBy._Last_Name = reader.Item("PrepLastName")
                    ._PrepBy._First_Name = reader.Item("PrepFirstName")
                    ._PrepBy._Middle_Name = reader.Item("PrepMiddleName")
                    ._PrepDate = reader.Item("PrepDate")
                    ._ModBy._User_ID = reader.Item("ModByID")
                    ._ModBy._Last_Name = reader.Item("ModLastName")
                    ._ModBy._First_Name = reader.Item("ModFirstName")
                    ._ModBy._Middle_Name = reader.Item("ModMiddleName")
                    ._ModDate = reader.Item("ModDate")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clsTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function SearchEmailPerModule(ByVal strCompany_Code As String, ByVal lngModule_ID As Long) As clsEmailPerModule
        Try
            Dim clsTemp As New clsEmailPerModule
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_emailpermodule WHERE `Company_Code` = @Company_Code AND `Module_ID` = @Module_ID"
            cmdSQL.Parameters.AddWithValue("@Company_Code", strCompanyCode)
            cmdSQL.Parameters.AddWithValue("@Module_ID", lngModule_ID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTemp
                    ._ID = reader.Item("ID")
                    ._Company_Code = reader.Item("Company_Code")
                    ._Company_FullName = reader.Item("Company_FullName")
                    ._Module_ID = reader.Item("Module_ID")
                    ._Module_Name = reader.Item("Module_Name")
                    ._EmailFrom._ID = reader.Item("Email_From_ID")
                    ._EmailFrom._EmailAddress = reader.Item("From_EmailAddress")
                    ._EmailFrom._SMTP_Host = reader.Item("From_SMTP_Host")
                    ._EmailFrom._SMTP_Port = reader.Item("From_SMTP_Port")
                    ._EmailFrom._SMTP_Username = reader.Item("From_SMTP_Username")
                    ._EmailFrom._SMTP_Password = DecryptString(reader.Item("From_SMTP_Password"), 1)
                    ._EmailFrom._SMTP_EnableSSL = reader.Item("From_SMTP_EnableSSL")
                    ._EmailReplyTo._ID = reader.Item("Email_ReplyTo_ID")
                    ._EmailReplyTo._EmailAddress = reader.Item("ReplyTo_EmailAddress")
                    ._EmailReplyTo._SMTP_Host = reader.Item("ReplyTo_SMTP_Host")
                    ._EmailReplyTo._SMTP_Port = reader.Item("ReplyTo_SMTP_Port")
                    ._EmailReplyTo._SMTP_Username = reader.Item("ReplyTo_SMTP_Username")
                    ._EmailReplyTo._SMTP_Password = DecryptString(reader.Item("ReplyTo_SMTP_Password"), 1)
                    ._EmailReplyTo._SMTP_EnableSSL = reader.Item("ReplyTo_SMTP_EnableSSL")
                    ._PrepBy._User_ID = reader.Item("PrepByID")
                    ._PrepBy._Last_Name = reader.Item("PrepLastName")
                    ._PrepBy._First_Name = reader.Item("PrepFirstName")
                    ._PrepBy._Middle_Name = reader.Item("PrepMiddleName")
                    ._PrepDate = reader.Item("PrepDate")
                    ._ModBy._User_ID = reader.Item("ModByID")
                    ._ModBy._Last_Name = reader.Item("ModLastName")
                    ._ModBy._First_Name = reader.Item("ModFirstName")
                    ._ModBy._Middle_Name = reader.Item("ModMiddleName")
                    ._ModDate = reader.Item("ModDate")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clsTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function SearchCompanyServiceOffered(ByVal lngID As Long) As clsCompanyServiceOffered
        Try
            Dim clsTemp As New clsCompanyServiceOffered
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_companyserviceoffered WHERE `ID` = @ID"
            cmdSQL.Parameters.AddWithValue("@ID", lngID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                With clsTemp
                    ._ID = reader.Item("ID")
                    With ._Company
                        ._Company_Code = reader.Item("Company_Code")
                        ._Company_FullName = reader.Item("Company_FullName")
                    End With
                    With ._ServiceOffered
                        ._PK = reader.Item("Service_Code")
                        ._ParameterType._PK = reader.Item("Param_Type")
                        ._Param_Code = reader.Item("Param_Code")
                        ._Param_Desc = reader.Item("Param_Desc")
                        ._Param_Value = _NotNull(reader.Item("Param_Value"), "")
                    End With
                    ._PrepBy._User_ID = reader.Item("PrepByID")
                    ._PrepBy._Last_Name = reader.Item("PrepLastName")
                    ._PrepBy._First_Name = reader.Item("PrepFirstName")
                    ._PrepBy._Middle_Name = reader.Item("PrepMiddleName")
                    ._PrepDate = reader.Item("PrepDate")
                    ._ModBy._User_ID = reader.Item("ModByID")
                    ._ModBy._Last_Name = reader.Item("ModLastName")
                    ._ModBy._First_Name = reader.Item("ModFirstName")
                    ._ModBy._Middle_Name = reader.Item("ModMiddleName")
                    ._ModDate = reader.Item("ModDate")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clsTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    'Populate List of Record
    Public Function PopulateListOfParameters(ByVal strParam_Type As String) As List(Of clsParameters)
        Try
            Dim clsTemp As New clsParameters
            Dim clslstTemp As New List(Of clsParameters)

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM `v_params` WHERE `Param_Type` = @Param_Code"
            cmdSQL.Parameters.AddWithValue("@Param_Code", strParam_Type)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                clsTemp = New clsParameters
                With clsTemp
                    ._PK = reader.Item("PK")
                    With ._ParameterType
                        ._PK = reader.Item("Param_Type")
                        ._Description = reader.Item("Param_Type_Desc")
                    End With
                    ._Param_Code = reader.Item("Param_Code")
                    ._Param_Desc = reader.Item("Param_Desc")
                    ._Param_Value = _NotNull(reader.Item("Param_Value"), "")
                End With
                clslstTemp.Add(clsTemp)
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clslstTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function PopulateListOfPorts() As List(Of clsPort)
        Try
            Dim clsTemp As New clsPort
            Dim clslstTemp As New List(Of clsPort)

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM `v_port`"

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                clsTemp = New clsPort
                With clsTemp
                    ._PK = reader.Item("PK")
                    With ._CountryDetails
                        ._PK = reader.Item("Country_PK")
                        ._Description = reader.Item("Country_Desc")
                    End With
                    ._Description = reader.Item("Description")
                    ._UNLOCODE = reader.Item("UNLOCODE")
                End With
                clslstTemp.Add(clsTemp)
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clslstTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function PopulateListOfReportParameter(ByVal strCompany_Code As String, ByVal strReport_Name As String) As List(Of clsReportParameters)
        Try
            Dim clsTemp As New clsReportParameters
            Dim clslstTemp As New List(Of clsReportParameters)

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_reportparameters WHERE `Company_Code` = @Company_Code AND `Report_Name` = @Report_Name"
            cmdSQL.Parameters.AddWithValue("@Company_Code", strCompanyCode)
            cmdSQL.Parameters.AddWithValue("@Report_Name", strReport_Name)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                clsTemp = New clsReportParameters
                With clsTemp
                    ._ID = reader.Item("ID")
                    ._Company_Code = reader.Item("Company_Code")
                    ._Company_FullName = reader.Item("Company_FullName")
                    ._Report_Name = reader.Item("Report_Name")
                    ._Parameter_Name = reader.Item("Parameter_Name")
                    ._Parameter_Value = reader.Item("Parameter_Value")
                    ._PrepBy._User_ID = reader.Item("PrepByID")
                    ._PrepBy._Last_Name = reader.Item("PrepLastName")
                    ._PrepBy._First_Name = reader.Item("PrepFirstName")
                    ._PrepBy._Middle_Name = reader.Item("PrepMiddleName")
                    ._PrepDate = reader.Item("PrepDate")
                    ._ModBy._User_ID = reader.Item("ModByID")
                    ._ModBy._Last_Name = reader.Item("ModLastName")
                    ._ModBy._First_Name = reader.Item("ModFirstName")
                    ._ModBy._Middle_Name = reader.Item("ModMiddleName")
                    ._ModDate = reader.Item("ModDate")
                End With

                clslstTemp.Add(clsTemp)
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clslstTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function PopulateListOfStatus() As List(Of clsStatus)
        Try
            Dim clsTemp As New clsStatus
            Dim clslstTemp As New List(Of clsStatus)

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM `tbl_status`"

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                clsTemp = New clsStatus
                With clsTemp
                    ._Status_ID = reader.Item("Status_ID")
                    ._Status_Name = reader.Item("Status_Name")
                    ._Status_ColorR = _NotNull(reader.Item("Status_ColorR"), 0)
                    ._Status_ColorG = _NotNull(reader.Item("Status_ColorG"), 0)
                    ._Status_ColorB = _NotNull(reader.Item("Status_ColorB"), 0)
                End With
                clslstTemp.Add(clsTemp)
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clslstTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function PopulateListOfExportMasterBookingOpenRecords(ByVal strCompanyCode As String) As List(Of clsExportMasterBooking)
        Try
            Dim clsTemp As New clsExportMasterBooking
            Dim clslstTemp As New List(Of clsExportMasterBooking)

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM `v_exportmaster` WHERE `StatusID` = 1 ORDER BY PrepDate"

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                clsTemp = New clsExportMasterBooking
                With clsTemp
                    ._ID = reader.Item("ID")
                    ._RefNo = reader.Item("RefNo")
                    With ._CompanyDetails
                        ._Company_Code = reader.Item("CompanyCode")
                        ._Company_Name = reader.Item("Company_Name")
                        ._Company_FullName = reader.Item("Company_FullName")
                    End With
                    With ._CarrierDetails
                        ._Code = _NotNull(reader.Item("CarrierCode"), "")
                        ._Description = _NotNull(reader.Item("CarrierName"), "")
                    End With
                    With ._OriginDetails
                        ._PK = _NotNull(reader.Item("OriginID"), 0)
                        ._CountryDetails._PK = _NotNull(reader.Item("OriginCountry_PK"), 0)
                        ._Description = _NotNull(reader.Item("OriginName"), "")
                    End With
                    With ._DestinationDetails
                        ._PK = _NotNull(reader.Item("DestinationID"), 0)
                        ._CountryDetails._PK = _NotNull(reader.Item("DestinationCountry_PK"), 0)
                        ._Description = _NotNull(reader.Item("DestinationName"), "")
                    End With
                    With ._ModeOfTransportDetails
                        ._PK = reader.Item("ModeOfTransportID")
                        ._Param_Desc = reader.Item("ModeOfTransportDesc")
                    End With
                    ._LoadedPullOut = _NotNull(reader.Item("LoadedPullOut"), "")
                    ._ContainerYard = _NotNull(reader.Item("ContainerYard"), "")
                    With ._WarehouseDetails
                        ._ID = _NotNull(reader.Item("WarehouseID"), 0)
                        ._WarehouseName = _NotNull(reader.Item("WarehouseName"), "")
                    End With
                    ._ETD._DateValue = _NotNull(reader.Item("ETD"), Nothing)
                    ._ATD._DateValue = _NotNull(reader.Item("ATD"), Nothing)
                    ._SealNo = _NotNull(reader.Item("SealNo"), "")
                    ._EmptyPositioning = _NotNull(reader.Item("EmptyPositioning"), "")
                    ._ChassisDepot = _NotNull(reader.Item("ChassisDepot"), "")
                    With ._VesselDetails
                        ._ID = _NotNull(reader.Item("VesselID"), 0)
                        ._VesselCode = _NotNull(reader.Item("VesselCode"), "")
                        ._VesselName = _NotNull(reader.Item("VesselName"), "")
                        ._NACCSUserCode = _NotNull(reader.Item("NACCSUserCode"), "")
                    End With
                    With ._AirlineDetails
                        ._Code = _NotNull(reader.Item("AirLineCode"), "")
                        ._Prefix = _NotNull(reader.Item("AirLinePrefix"), "")
                        ._Description = _NotNull(reader.Item("AirLineName"), "")
                    End With
                    ._LCT = _NotNull(reader.Item("LCT"), "")
                    ._ETA._DateValue = _NotNull(reader.Item("ETA"), Nothing)
                    ._ATA._DateValue = _NotNull(reader.Item("ATA"), Nothing)
                    With ._LoadTypeDetails
                        ._PK = _NotNull(reader.Item("LoadTypeID"), 0)
                        ._Param_Desc = _NotNull(reader.Item("LoadTypeDesc"), "")
                    End With
                    With ._StatusDetails
                        ._Status_ID = _NotNull(reader.Item("StatusID"), 0)
                        ._Status_Name = _NotNull(reader.Item("Status_Name"), "")
                        ._Status_ColorR = _NotNull(reader.Item("Status_ColorR"), 0)
                        ._Status_ColorG = _NotNull(reader.Item("Status_ColorG"), 0)
                        ._Status_ColorB = _NotNull(reader.Item("Status_ColorB"), 0)
                    End With
                    With ._StatusByDetails
                        ._User_ID = _NotNull(reader.Item("StatusByID"), "")
                        ._Last_Name = _NotNull(reader.Item("StatusByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("StatusByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("StatusByMiddle_Name"), "")
                    End With
                    ._StatusDate = _NotNull(reader.Item("StatusDate"), Nothing)
                    With ._PrepByDetails
                        ._User_ID = reader.Item("PrepByID")
                        ._Last_Name = reader.Item("PrepByLast_Name")
                        ._First_Name = reader.Item("PrepByFirst_Name")
                        ._Middle_Name = reader.Item("PrepByMiddle_Name")
                    End With
                    ._PrepDate = reader.Item("PrepDate")
                    With ._ModByDetails
                        ._User_ID = reader.Item("ModByID")
                        ._Last_Name = reader.Item("ModByLast_Name")
                        ._First_Name = reader.Item("ModByFirst_Name")
                        ._Middle_Name = reader.Item("ModByMiddle_Name")
                    End With
                    ._ModDate = reader.Item("ModDate")
                End With
                clslstTemp.Add(clsTemp)
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clslstTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function PopulateListOfExportMasterBookingDateFromTo(ByVal strCompanyCode As String, ByVal dtFrom As Date, ByVal dtTo As Date) As List(Of clsExportMasterBooking)
        Try
            Dim clsTemp As New clsExportMasterBooking
            Dim clslstTemp As New List(Of clsExportMasterBooking)

            dtFrom = New Date(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0)
            dtTo = New Date(dtTo.Year, dtTo.Month, dtTo.Day, 0, 0, 0).AddDays(1)

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM `v_exportmaster` WHERE `PrepDate` BETWEEN @From AND @To ORDER BY PrepDate"
            With cmdSQL.Parameters
                .AddWithValue("@From", dtFrom)
                .AddWithValue("@To", dtTo)
            End With

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                clsTemp = New clsExportMasterBooking
                With clsTemp
                    ._ID = reader.Item("ID")
                    ._RefNo = reader.Item("RefNo")
                    With ._CompanyDetails
                        ._Company_Code = reader.Item("CompanyCode")
                        ._Company_Name = reader.Item("Company_Name")
                        ._Company_FullName = reader.Item("Company_FullName")
                    End With
                    With ._CarrierDetails
                        ._Code = _NotNull(reader.Item("CarrierCode"), "")
                        ._Description = _NotNull(reader.Item("CarrierName"), "")
                    End With
                    With ._OriginDetails
                        ._PK = _NotNull(reader.Item("OriginID"), 0)
                        ._CountryDetails._PK = _NotNull(reader.Item("OriginCountry_PK"), 0)
                        ._Description = _NotNull(reader.Item("OriginName"), "")
                    End With
                    With ._DestinationDetails
                        ._PK = _NotNull(reader.Item("DestinationID"), 0)
                        ._CountryDetails._PK = _NotNull(reader.Item("DestinationCountry_PK"), 0)
                        ._Description = _NotNull(reader.Item("DestinationName"), "")
                    End With
                    With ._ModeOfTransportDetails
                        ._PK = reader.Item("ModeOfTransportID")
                        ._Param_Desc = reader.Item("ModeOfTransportDesc")
                    End With
                    ._LoadedPullOut = _NotNull(reader.Item("LoadedPullOut"), "")
                    ._ContainerYard = _NotNull(reader.Item("ContainerYard"), "")
                    With ._WarehouseDetails
                        ._ID = _NotNull(reader.Item("WarehouseID"), 0)
                        ._WarehouseName = _NotNull(reader.Item("WarehouseName"), "")
                    End With
                    ._ETD._DateValue = _NotNull(reader.Item("ETD"), Nothing)
                    ._ATD._DateValue = _NotNull(reader.Item("ATD"), Nothing)
                    ._SealNo = _NotNull(reader.Item("SealNo"), "")
                    ._EmptyPositioning = _NotNull(reader.Item("EmptyPositioning"), "")
                    ._ChassisDepot = _NotNull(reader.Item("ChassisDepot"), "")
                    With ._VesselDetails
                        ._ID = _NotNull(reader.Item("VesselID"), 0)
                        ._VesselCode = _NotNull(reader.Item("VesselCode"), "")
                        ._VesselName = _NotNull(reader.Item("VesselName"), "")
                        ._NACCSUserCode = _NotNull(reader.Item("NACCSUserCode"), "")
                    End With
                    With ._AirlineDetails
                        ._Code = _NotNull(reader.Item("AirLineCode"), "")
                        ._Prefix = _NotNull(reader.Item("AirLinePrefix"), "")
                        ._Description = _NotNull(reader.Item("AirLineName"), "")
                    End With
                    ._LCT = _NotNull(reader.Item("LCT"), "")
                    ._ETA._DateValue = _NotNull(reader.Item("ETA"), Nothing)
                    ._ATA._DateValue = _NotNull(reader.Item("ATA"), Nothing)
                    With ._LoadTypeDetails
                        ._PK = _NotNull(reader.Item("LoadTypeID"), 0)
                        ._Param_Desc = _NotNull(reader.Item("LoadTypeDesc"), "")
                    End With
                    With ._StatusDetails
                        ._Status_ID = _NotNull(reader.Item("StatusID"), 0)
                        ._Status_Name = _NotNull(reader.Item("Status_Name"), "")
                        ._Status_ColorR = _NotNull(reader.Item("Status_ColorR"), 0)
                        ._Status_ColorG = _NotNull(reader.Item("Status_ColorG"), 0)
                        ._Status_ColorB = _NotNull(reader.Item("Status_ColorB"), 0)
                    End With
                    With ._StatusByDetails
                        ._User_ID = _NotNull(reader.Item("StatusByID"), "")
                        ._Last_Name = _NotNull(reader.Item("StatusByLast_Name"), "")
                        ._First_Name = _NotNull(reader.Item("StatusByFirst_Name"), "")
                        ._Middle_Name = _NotNull(reader.Item("StatusByMiddle_Name"), "")
                    End With
                    ._StatusDate = _NotNull(reader.Item("StatusDate"), Nothing)
                    With ._PrepByDetails
                        ._User_ID = reader.Item("PrepByID")
                        ._Last_Name = reader.Item("PrepByLast_Name")
                        ._First_Name = reader.Item("PrepByFirst_Name")
                        ._Middle_Name = reader.Item("PrepByMiddle_Name")
                    End With
                    ._PrepDate = reader.Item("PrepDate")
                    With ._ModByDetails
                        ._User_ID = reader.Item("ModByID")
                        ._Last_Name = reader.Item("ModByLast_Name")
                        ._First_Name = reader.Item("ModByFirst_Name")
                        ._Middle_Name = reader.Item("ModByMiddle_Name")
                    End With
                    ._ModDate = reader.Item("ModDate")
                End With
                clslstTemp.Add(clsTemp)
            End While

            reader.Close()
            cmdSQL.Dispose()

            Return clslstTemp
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
