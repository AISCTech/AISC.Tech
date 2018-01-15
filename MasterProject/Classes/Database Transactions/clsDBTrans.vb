Public Class clsDBTrans

    'Save Record
    Public Function SaveImportBookingRecord(ByVal clsTempImpBook As clsImportBookingHeader) As clsImportBookingHeader
        SaveImportBookingRecord = New clsImportBookingHeader
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

            clsTempImpBook = SearchImportBookingRecord(clsTempImpBook._BookingNo, clsTempImpBook._CompanyCode)
            SaveImportBookingRecord = clsTempImpBook
            MsgBox("Record saved!", MsgBoxStyle.Information, "System Message")
        Catch ex As Exception
            SaveImportBookingRecord = Nothing
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
                    ._SitePK = reader.Item("SitePK")
                    ._Site_Name = reader.Item("Site_Name")
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

    Public Function SearchImportBookingRecord(ByVal strTempBookingNo As String, ByVal strTempCompanyCode As String) As clsImportBookingHeader
        SearchImportBookingRecord = New clsImportBookingHeader
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
                SearchImportBookingRecord = Nothing
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
                    ._VesselName = reader.Item("VesselName")
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
                    ._ModeOfTransportName = reader.Item("ModeOfTransportName")
                    ._LoadTypeID = reader.Item("LoadTypeID")
                    ._LoadTypeName = reader.Item("LoadTypeName")
                    ._EntryTypeID = reader.Item("EntryTypeID")
                    ._EntryTypeName = reader.Item("EntryTypeName")
                    ._FreightTermsID = reader.Item("FreightTermsID")
                    ._FreightTermsName = reader.Item("FreightTermsName")
                    ._WarehouseID = reader.Item("WarehouseID")
                    ._WarehouseName = reader.Item("WarehouseName")
                    ._AccountTypeID = reader.Item("AccountTypeID")
                    ._AccountTypePrefix = reader.Item("AccountTypePrefix")
                    ._AccountTypeDesc = reader.Item("AccountTypeDescription")
                    ._AccountHolderID = reader.Item("AccountHolderID")
                    ._AccountHolderFullName = reader.Item("AccountHolderFirstName") & " " & reader.Item("AccountHolderLastName")
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

            SearchImportBookingRecord = clsTempHead
        Catch ex As Exception
            MsgBox(ex.Message)
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
End Class
