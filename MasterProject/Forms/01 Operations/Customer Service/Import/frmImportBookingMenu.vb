Public Class frmImportBookingMenu

    Implements ICommonFunction

    Private EnableButtons As New clsEnableToolstripObjects()
    Public clsImportBooking As New clsImportBookingHeader
    'Public lngBookingID As Long
    'Public strCompanyName As String

    Private strStatusByID As String
    Private strStatusByName As String
    Private dtStatusDate As String

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If MsgBox("Create new record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
            ClearUserInput()
            txtSite.Tag = CurrentUser._Site_Code
            txtSite.Text = CurrentUser._Site_Name
            ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
        End If
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        If txtStatus.Tag = 1 Then
            ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
        Else
            MsgBox("Cannot edit record that is NOT OPEN.", MsgBoxStyle.Information, "System Message")
        End If
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckRequiredEntries() = True Then
            clsImportBooking = New clsImportBookingHeader
            Dim clsTempService As New clsImportBookingServices
            Dim clsTempContainer As New clsImportBookingContainers
            Dim clsTempDocument As New clsImportBookingDocuments
            Dim clsImportDBTrans As New clsDBTrans

            With clsImportBooking
                '._ID = lngBookingID
                ._BookingNo = txtBookingNo.Text
                ._BookingPrefix = GenerateBookingPrefix()
                ._HouseBL = txtHouseBL.Text
                ._CompanyCode = CurrentUser._Company_Code
                ._SiteCode = txtSite.Tag
                ._ShipperCode = txtShipper.Tag
                ._ConsigneeCode = txtConsignee.Tag
                ._ConsignorCode = txtConsignor.Tag
                ._ForwarderCode = txtForwarder.Tag
                ._ShippingLineCode = cboShippingLine.SelectedValue
                ._DescriptionOfGoods = txtDescriptionOfGoods.Text
                ._Weight = txtWeight.Text
                ._Volume = txtVolume.Text
                ._NoOfPackage = txtNoOfPackage.Text
                ._PackageUnitID = cboUnitOfMeasure.SelectedValue
                ._OriginPortID = cboOrigin.SelectedValue
                ._DestinationPortID = cboDestination.SelectedValue
                If IsDate(txtETA.Text) Then
                    ._ETA = CDate(txtETA.Text)
                Else
                    ._ETA = Nothing
                End If
                If IsDate(txtATA.Text) Then
                    ._ATA = CDate(txtATA.Text)
                Else
                    ._ATA = Nothing
                End If
                ._VesselID = cboVessel.SelectedValue
                ._Voyage = txtVoyage.Text
                ._DocsCompleted = CheckIfDocsComplete()
                ._ImportPermitNo = txtImportPermitNo.Text
                ._InvoiceNo = txtInvoiceNo.Text
                ._RegistryNo = txtRegistryNo.Text
                ._Remarks = txtRemarks.Text
                ._ModeOfTransportID = cboModeOfTransport.SelectedValue
                ._LoadTypeID = cboLoadType.SelectedValue
                ._EntryTypeID = cboEntryType.SelectedValue
                ._FreightTermsID = cboFreightType.SelectedValue
                ._AccountHolderID = 1
                ._PrepByID = CurrentUser._User_ID
                ._ModByID = CurrentUser._User_ID
                ._StatusByID = CurrentUser._User_ID
            End With

            For Each dtgRow As DataGridViewRow In dtgServices.Rows
                If dtgRow.Cells(colSSelected.Name).Value = True Then
                    clsTempService = New clsImportBookingServices
                    With clsTempService
                        ._ServiceID = dtgRow.Cells(colSPK.Name).Value
                    End With

                    clsImportBooking._ServiceDetails.Add(clsTempService)
                End If
            Next

            For Each dtgRow As DataGridViewRow In dtgContainer.Rows
                clsTempContainer = New clsImportBookingContainers
                With clsTempContainer
                    ._ContainerID = dtgRow.Cells(colCContainerID.Name).Value
                    If IsDate(dtgRow.Cells(colCPickUpDate.Name).Value) Then
                        ._PickupDate = dtgRow.Cells(colCPickUpDate.Name).Value
                    Else
                        ._PickupDate = Nothing
                    End If
                    If IsDate(dtgRow.Cells(colCDeliveryDate.Name).Value) Then
                        ._DeliveryDate = dtgRow.Cells(colCDeliveryDate.Name).Value
                    Else
                        ._DeliveryDate = Nothing
                    End If
                End With
                clsImportBooking._ContainerDetails.Add(clsTempContainer)
            Next

            For Each dtgRow As DataGridViewRow In dtgDocuments.Rows
                If dtgRow.Cells(colDSelected.Name).Value = True Then
                    clsTempDocument = New clsImportBookingDocuments
                    clsTempDocument._DocumentID = dtgRow.Cells(colDDocID.Name).Value
                    clsImportBooking._DocumentDetails.Add(clsTempDocument)
                End If
            Next

            clsImportBooking = clsImportDBTrans.SaveImportBookingRecord(clsImportBooking)
            PopulateBooking(clsImportBooking)
        End If
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord


        Dim clsComboBox As New clsPopulateComboBox(cboShippingLine, "SELECT * FROM v_vendortype WHERE Params_Code = 2 ORDER BY `Description`", "Description", "Code")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboModeOfTransport, "SELECT * FROM lib_params WHERE Param_Type = 4 ORDER BY `PK`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboLoadType, "SELECT * FROM lib_params WHERE Param_Type = 2 ORDER BY `PK`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboUnitOfMeasure, "SELECT * FROM lib_params WHERE Param_Type = 5 ORDER BY `Param_Desc`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboOrigin, "SELECT * FROM lib_port ORDER BY `Description`", "Description", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboDestination, "SELECT * FROM lib_port ORDER BY `Description`", "Description", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboVessel, "SELECT * FROM lib_vessel ORDER BY `VesselName`", "VesselName", "ID")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboEntryType, "SELECT * FROM lib_params WHERE Param_Type = 13 ORDER BY `PK`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboFreightType, "SELECT * FROM lib_params WHERE Param_Type = 3 ORDER BY `PK`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        PopulateServices()
        PopulateRequiredDocuments()

        If clsImportBooking._ID < 1 Then
            ClearUserInput()
            ChangeEnabledButtons(True, False, False, True, False, True, False, False, False, False)
        Else
            Dim clsDBTemp As New clsDBTrans
            PopulateBooking(clsDBTemp.SearchImportBookingRecord(txtBookingNo.Text, CurrentUser._Company_Code))
        End If
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        frmSelectImportBookingPrintPrev.ShowDialog()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        frmSearchImportBooking.ShowDialog()
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        If txtStatus.Tag = 1 Then
            If MsgBox("Are you sure you want to POST record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

                Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
                Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

                trnSQL = cnnDBMaster.BeginTransaction

                Try
                    cmdSQL.Connection = cnnDBMaster
                    cmdSQL.Transaction = trnSQL
                    cmdSQL.CommandText = "sp_importbookingchangestatus"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_StatusID", 2)
                    cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusByID", CurrentUser._User_ID)
                    cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsImportBooking._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()

                    trnSQL.Commit()
                    cmdSQL.Dispose()

                    Dim clsDBTemp As New clsDBTrans
                    PopulateBooking(clsDBTemp.SearchImportBookingRecord(txtBookingNo.Text, CurrentUser._Company_Code))
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
            End If
        Else
            MsgBox("Cannot post record. Record is already " & txtStatus.Text.ToUpper & ".", MsgBoxStyle.Information, "System Message")
        End If
    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        If txtStatus.Tag = 1 Then
            If MsgBox("Are you sure you want to CANCEL record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

                Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
                Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

                trnSQL = cnnDBMaster.BeginTransaction

                Try
                    cmdSQL.Connection = cnnDBMaster
                    cmdSQL.Transaction = trnSQL
                    cmdSQL.CommandText = "sp_importbookingchangestatus"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_StatusID", 3)
                    cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusByID", CurrentUser._User_ID)
                    cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsImportBooking._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()

                    trnSQL.Commit()
                    cmdSQL.Dispose()

                    Dim clsDBTemp As New clsDBTrans
                    PopulateBooking(clsDBTemp.SearchImportBookingRecord(txtBookingNo.Text, CurrentUser._Company_Code))
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
            End If
        Else
            MsgBox("Cannot cancel record. Record is already " & txtStatus.Text.ToUpper & ".", MsgBoxStyle.Information, "System Message")
        End If
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        If txtStatus.Tag <> 1 Then
            If MsgBox("Are you sure you want to RE-OPEN record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

                Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
                Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

                trnSQL = cnnDBMaster.BeginTransaction

                Try
                    cmdSQL.Connection = cnnDBMaster
                    cmdSQL.Transaction = trnSQL
                    cmdSQL.CommandText = "sp_importbookingchangestatus"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_StatusID", 1)
                    cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusByID", CurrentUser._User_ID)
                    cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsImportBooking._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()

                    trnSQL.Commit()
                    cmdSQL.Dispose()

                    Dim clsDBTemp As New clsDBTrans
                    PopulateBooking(clsDBTemp.SearchImportBookingRecord(txtBookingNo.Text, CurrentUser._Company_Code))
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
            End If
        Else
            MsgBox("Record is still OPEN.", MsgBoxStyle.Information, "System Message")
        End If
    End Sub

    Private Function CheckIfDocsComplete() As Boolean
        CheckIfDocsComplete = True
        For Each dtgRow As DataGridViewRow In dtgDocuments.Rows
            If dtgRow.Cells(colDRequired.Name).Value = True And dtgRow.Cells(colDSelected.Name).Value = False Then
                CheckIfDocsComplete = False
            End If
        Next
    End Function

    Private Sub PopulateRequiredDocuments()
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM lib_booking_documents WHERE FreightType = 1 AND Active = TRUE"

            dtgDocuments.Rows.Clear()
            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            While reader.Read
                dtgDocuments.Rows.Add()
                With dtgDocuments.Rows(dtgDocuments.Rows.Count - 1)
                    .Cells(colDDocID.Name).Value = reader.Item("ID")
                    .Cells(colDDocName.Name).Value = reader.Item("DocumentName")
                    .Cells(colDRequired.Name).Value = reader.Item("Required")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function CheckRequiredEntries() As Boolean
        CheckRequiredEntries = True

        dtgServices.EndEdit()
        dtgContainer.EndEdit()
        dtgDocuments.EndEdit()

        If Len(txtConsignor.Tag) = 0 Then
            MsgBox("Please select Consignor/Debtor!", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            Exit Function
        End If
    End Function

    Public Sub PopulateBooking(ByVal clsImpBook As clsImportBookingHeader)
        ClearUserInput()
        clsImportBooking = clsImpBook
        clsImportBooking._ID = clsImpBook._ID
        txtBookingPrefix.Text = clsImpBook._BookingPrefix
        txtBookingNo.Text = clsImpBook._BookingNo
        txtHouseBL.Text = clsImpBook._HouseBL
        txtSite.Tag = clsImpBook._SiteCode
        txtSite.Text = clsImpBook._SiteName
        txtShipper.Tag = clsImpBook._ShipperCode
        txtShipper.Text = clsImpBook._ShipperName
        txtShipperAddress.Text = clsImpBook._ShipperAddress
        txtConsignee.Tag = clsImpBook._ConsigneeCode
        txtConsignee.Text = clsImpBook._ConsigneeName
        txtConsigneeAddress.Text = clsImpBook._ConsigneeAddress
        txtConsignor.Tag = clsImpBook._ConsignorCode
        txtConsignor.Text = clsImpBook._ConsignorName
        txtConsignorAddress.Text = clsImpBook._ConsignorAddress
        txtForwarder.Tag = clsImpBook._ForwarderCode
        txtForwarder.Text = clsImpBook._ForwarderName
        txtForwarderAddress.Text = clsImpBook._ForwarderAddress
        cboShippingLine.SelectedValue = clsImpBook._ShippingLineCode
        txtDescriptionOfGoods.Text = clsImpBook._DescriptionOfGoods
        txtWeight.Text = clsImpBook._Weight
        txtVolume.Text = clsImpBook._Volume
        txtNoOfPackage.Text = clsImpBook._NoOfPackage
        cboUnitOfMeasure.SelectedValue = clsImpBook._PackageUnitID
        cboOrigin.SelectedValue = clsImpBook._OriginPortID
        txtOriginCountry.Text = clsImpBook._OriginCountryName
        cboDestination.SelectedValue = clsImpBook._DestinationPortID
        txtDestinationCountry.Text = clsImpBook._DestinationCountryName
        If clsImpBook._ETA = Nothing Then
            txtETA.Text = ""
        Else
            txtETA.Text = clsImpBook._ETA
        End If
        If clsImpBook._ATA = Nothing Then
            txtATA.Text = ""
        Else
            txtATA.Text = clsImpBook._ATA
        End If
        cboVessel.SelectedValue = clsImpBook._VesselID
        txtVoyage.Text = clsImpBook._Voyage
        chkDocsCompleted.Checked = clsImpBook._DocsCompleted
        If clsImpBook._DocsCompletedDate = Nothing Then
            txtDocsCompletedDate.Text = ""
        Else
            txtDocsCompletedDate.Text = clsImpBook._DocsCompletedDate
        End If
        txtImportPermitNo.Text = clsImpBook._ImportPermitNo
        txtInvoiceNo.Text = clsImpBook._InvoiceNo
        txtRegistryNo.Text = clsImpBook._RegistryNo
        txtRemarks.Text = clsImpBook._Remarks
        'account holder
        txtStatus.Tag = clsImpBook._StatusID
        txtStatus.Text = clsImpBook._StatusName
        strStatusByID = clsImpBook._StatusByID
        strStatusByName = clsImpBook._StatusByFullName
        dtStatusDate = clsImpBook._StatusDate
        cboModeOfTransport.SelectedValue = clsImpBook._ModeOfTransportID
        cboLoadType.SelectedValue = clsImpBook._LoadTypeID
        cboEntryType.SelectedValue = clsImpBook._EntryTypeID
        cboFreightType.SelectedValue = clsImpBook._FreightTermsID
        tslblPrepBy.Text = clsImpBook._PrepByFullName
        tslblPrepBy.ToolTipText = tslblPrepBy.Text
        tslblPrepDate.Text = clsImpBook._PrepDate
        tslblPrepDate.ToolTipText = tslblPrepDate.Text
        tslblModBy.Text = clsImpBook._ModByFullName
        tslblModBy.ToolTipText = tslblModBy.Text
        tslblModDate.Text = clsImpBook._ModDate
        tslblModDate.ToolTipText = tslblModDate.Text

        For Each clsTemp As clsImportBookingServices In clsImpBook._ServiceDetails
            For Each dtgTemp As DataGridViewRow In dtgServices.Rows
                If clsTemp._ServiceID = dtgTemp.Cells(colSPK.Name).Value Then
                    dtgTemp.Cells(colSSelected.Name).Value = True
                    Exit For
                End If
            Next
        Next

        For Each clsTemp As clsImportBookingContainers In clsImpBook._ContainerDetails
            dtgContainer.Rows.Add()
            With dtgContainer.Rows(dtgContainer.Rows.Count - 1)
                .Cells(colCPK.Name).Value = clsTemp._ID
                .Cells(colCContainerID.Name).Value = clsTemp._ContainerID
                .Cells(colCContainerNo.Name).Value = clsTemp._ContainerNo
                .Cells(colCContainerSizeID.Name).Value = clsTemp._ContainerSizeID
                .Cells(colCContainerSizeName.Name).Value = clsTemp._ContainerSizeName
                If clsTemp._PickupDate = Nothing Then
                    .Cells(colCPickUpDate.Name).Value = "TBA"
                Else
                    .Cells(colCPickUpDate.Name).Value = clsTemp._PickupDate
                End If
                If clsTemp._DeliveryDate = Nothing Then
                    .Cells(colCDeliveryDate.Name).Value = "TBA"
                Else
                    .Cells(colCDeliveryDate.Name).Value = clsTemp._DeliveryDate
                End If
            End With
        Next

        For Each clsTemp As clsImportBookingDocuments In clsImpBook._DocumentDetails
            For Each dtgTemp As DataGridViewRow In dtgDocuments.Rows
                If clsTemp._DocumentID = dtgTemp.Cells(colDDocID.Name).Value Then
                    dtgTemp.Cells(colDSelected.Name).Value = True
                    Exit For
                End If
            Next
        Next

        ChangeEnabledButtons(True, True, False, True, True, True, True, True, True, False)
    End Sub

    Private Function GenerateBookingPrefix() As String
        Dim strTemp As String = ""
        GenerateBookingPrefix = ""
        Try
            'Site/Location
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT BookPrefix From tbl_dbsitename WHERE Site_Code = @Site_Code"
            cmdSQL.Parameters.AddWithValue("@Site_Code", txtSite.Tag)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                strTemp = reader.Item("BookPrefix")
            End While

            reader.Close()
            cmdSQL.Dispose()

            'Service Type
            For Each dtgRow As DataGridViewRow In dtgServices.Rows
                If dtgRow.Cells(colSParam_Code.Name).Value = "SFRGT" And dtgRow.Cells(colSSelected.Name).Value = True Then
                    Select Case cboModeOfTransport.Text
                        Case "Air"
                            strTemp = strTemp & "AI"
                        Case "Sea"
                            strTemp = strTemp & "SI"
                    End Select
                    GoTo lnAccountType
                ElseIf dtgRow.Cells(colSSelected.Name).Value = True Then
                    strTemp = strTemp & dtgRow.Cells(colSPrefix.Name).Value
                    GoTo lnAccountType
                End If
            Next

lnAccountType:
            'Account Type

            GenerateBookingPrefix = strTemp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function GetContainerSizes() As String
        GetContainerSizes = ""
        Dim strTemp As String = ""


    End Function

    Public Sub ClearUserInput()
        clsImportBooking = New clsImportBookingHeader
        txtBookingPrefix.Text = ""
        txtBookingNo.Text = ""
        txtHouseBL.Text = ""
        txtShipper.Tag = ""
        txtShipper.Text = ""
        txtShipperAddress.Text = ""
        txtConsignee.Tag = ""
        txtConsignee.Text = ""
        txtConsigneeAddress.Text = ""
        txtConsignor.Tag = ""
        txtConsignor.Text = ""
        txtConsignorAddress.Text = ""
        txtForwarder.Tag = ""
        txtForwarder.Text = ""
        txtForwarderAddress.Text = ""
        cboShippingLine.SelectedIndex = -1
        cboModeOfTransport.SelectedIndex = -1
        cboLoadType.SelectedIndex = -1
        txtDescriptionOfGoods.Text = ""
        txtWeight.Text = ""
        txtVolume.Text = ""
        txtAccountHolder.Text = ""
        For Each dtgRow As DataGridViewRow In dtgServices.Rows
            dtgRow.Cells(colSSelected.Name).Value = False
        Next
        txtSite.Tag = ""
        txtSite.Text = ""

        txtNoOfPackage.Text = ""
        cboUnitOfMeasure.SelectedIndex = -1
        cboOrigin.SelectedIndex = -1
        txtOriginCountry.Text = ""
        cboDestination.SelectedIndex = -1
        txtDestinationCountry.Text = ""
        dtETA.Value = Now
        txtETA.Text = ""
        dtATA.Value = Now
        txtATA.Text = ""
        cboVessel.SelectedIndex = -1
        txtVoyage.Text = ""
        txtImportPermitNo.Text = ""
        txtInvoiceNo.Text = ""
        txtRegistryNo.Text = ""
        cboEntryType.SelectedIndex = -1
        cboFreightType.SelectedIndex = -1
        txtRemarks.Text = ""
        txtStatus.Tag = ""
        txtStatus.Text = ""
        lblStatusDetails.Visible = False
        strStatusByID = ""
        strStatusByName = ""
        dtStatusDate = Nothing
        dtgContainer.Rows.Clear()
        tslblContainerSizes.Text = ""
        For Each dtgRow As DataGridViewRow In dtgDocuments.Rows
            dtgRow.Cells(colDSelected.Name).Value = False
        Next
        chkDocsCompleted.Checked = False
        txtDocsCompletedDate.Text = ""
    End Sub

    Public Sub PopulateServices()
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT PK, Param_Type, Param_Code, Param_Value, Param_Desc " &
                        "FROM lib_params " &
                        "WHERE Param_Type = 10 " &
                        "ORDER BY PK"

            dtgServices.Rows.Clear()

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            While reader.Read
                dtgServices.Rows.Add()
                With dtgServices.Rows(dtgServices.Rows.Count - 1)
                    .Cells(colSPK.Name).Value = reader.Item("PK")
                    .Cells(colSParam_Type.Name).Value = reader.Item("Param_Type")
                    .Cells(colSParam_Code.Name).Value = reader.Item("Param_Code")
                    .Cells(colSPrefix.Name).Value = reader.Item("Param_Value")
                    .Cells(colSParam_Desc.Name).Value = reader.Item("Param_Desc")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetClientAddress(ByVal strClientCode As String) As String
        GetClientAddress = ""

        Try
            Dim strTemp As String
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT Addr1, CityDesc, CountryDesc FROM v_client WHERE Code = @Code"
            cmdSQL.Parameters.AddWithValue("@Code", strClientCode)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            While reader.Read
                strTemp = Trim(CStr(reader.Item("Addr1") & " " & reader.Item("CityDesc") & " " & reader.Item("CountryDesc")).ToUpper)
                GetClientAddress = System.Text.RegularExpressions.Regex.Replace(strTemp, "\s{2,}", " ")
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function GetPortCountry(ByVal lngPortCode As Long) As String
        GetPortCountry = ""

        Try
            Dim strTemp As String
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT CountryDesc FROM v_origdestport WHERE PK = @PK"
            cmdSQL.Parameters.AddWithValue("@PK", lngPortCode)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            While reader.Read
                strTemp = Trim(CStr(reader.Item("CountryDesc")).ToUpper)
                GetPortCountry = System.Text.RegularExpressions.Regex.Replace(strTemp, "\s{2,}", " ")
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
                                     ByVal blPrintPreview As Boolean, ByVal blSearch As Boolean, ByVal blPost As Boolean,
                                     ByVal blCancel As Boolean, ByVal blReOpen As Boolean, ByVal blUserInput As Boolean)
        With EnableButtons
            .NewEnabled = blNew
            .EditEnabled = blEdit
            .SaveEnabled = blSave
            .ResetEnabled = blReset
            .PrintPreviewEnabled = blPrintPreview
            .SearchEnabled = blSearch
            .PostEnabled = blPost
            .CancelEnabled = blCancel
            .ReOpen = blReOpen

            .UpdateEnabledButtons()
        End With

        txtHouseBL.ReadOnly = Not blUserInput
        cmdSelectShipper.Enabled = blUserInput
        cmdSelectConsignee.Enabled = blUserInput
        cmdSelectConsignor.Enabled = blUserInput
        cmdSelectForwader.Enabled = blUserInput
        colSSelected.ReadOnly = Not blUserInput
        txtDescriptionOfGoods.ReadOnly = Not blUserInput
        txtRemarks.ReadOnly = Not blUserInput
        cboShippingLine.Enabled = blUserInput
        cboModeOfTransport.Enabled = blUserInput
        cboLoadType.Enabled = blUserInput
        cboLoadType.Enabled = blUserInput
        txtWeight.ReadOnly = Not blUserInput
        txtVolume.ReadOnly = Not blUserInput
        txtNoOfPackage.ReadOnly = Not blUserInput
        cboUnitOfMeasure.Enabled = blUserInput
        cboOrigin.Enabled = blUserInput
        cboDestination.Enabled = blUserInput
        txtETA.ReadOnly = Not blUserInput
        dtETA.Enabled = blUserInput
        txtATA.ReadOnly = Not blUserInput
        dtATA.Enabled = blUserInput
        cboVessel.Enabled = blUserInput
        txtVoyage.ReadOnly = Not blUserInput
        txtImportPermitNo.ReadOnly = Not blUserInput
        txtInvoiceNo.ReadOnly = Not blUserInput
        txtRegistryNo.ReadOnly = Not blUserInput
        cboEntryType.Enabled = blUserInput
        cboFreightType.Enabled = blUserInput
        tscmdContainerAdd.Enabled = blUserInput
        tscmdContainerRemove.Enabled = blUserInput
        colDSelected.ReadOnly = Not blUserInput
    End Sub

    Private Sub frmImportBookingMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetRecord()
    End Sub

    Private Sub frmImportBookingMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub frmImportBookingMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub dtETA_ValueChanged(sender As Object, e As EventArgs) Handles dtETA.ValueChanged
        txtETA.Text = dtETA.Value.ToShortDateString
    End Sub

    Private Sub dtATA_ValueChanged(sender As Object, e As EventArgs) Handles dtATA.ValueChanged
        txtATA.Text = dtATA.Value.ToShortDateString
    End Sub

    Private Sub tscmdContainerAdd_Click(sender As Object, e As EventArgs) Handles tscmdContainerAdd.Click
        frmAddBookingContainer.strCaller = "ImpBook"
        frmAddBookingContainer.ShowDialog()
        tslblContainerSizes.Text = GetContainerSizes()
    End Sub

    Private Sub tscmdContainerRemove_Click(sender As Object, e As EventArgs) Handles tscmdContainerRemove.Click
        If Me.dtgContainer.Rows.Count > 0 Then
            dtgContainer.Rows.Remove(dtgContainer.CurrentRow)
        End If

        tslblContainerSizes.Text = GetContainerSizes()
    End Sub

    Private Sub cboOrigin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrigin.SelectedIndexChanged

    End Sub

    Private Sub cboDestination_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDestination.SelectedIndexChanged

    End Sub

    Private Sub cboOrigin_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboOrigin.SelectionChangeCommitted
        txtOriginCountry.Text = GetPortCountry(cboOrigin.SelectedValue)
    End Sub

    Private Sub cboDestination_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDestination.SelectionChangeCommitted
        txtDestinationCountry.Text = GetPortCountry(Me.cboDestination.SelectedValue)
    End Sub

    Private Sub cmdSelectShipper_Click(sender As Object, e As EventArgs) Handles cmdSelectShipper.Click
        With frmSelection
            .Text = "Select Shipper"
            .PopulateGrid("SELECT Code, Description as `Shipper Name` FROM v_shipper ORDER BY `Shipper Name`", "`Shipper Name`", txtShipper)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        txtShipperAddress.Text = GetClientAddress(txtShipper.Tag)
    End Sub

    Private Sub cmdSelectConsignee_Click(sender As Object, e As EventArgs) Handles cmdSelectConsignee.Click
        With frmSelection
            .Text = "Select Consignee"
            .PopulateGrid("SELECT Code, Description as `Consignee Name` FROM v_consignee ORDER BY `Consignee Name`", "`Consignee Name`", txtConsignee)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        txtConsigneeAddress.Text = GetClientAddress(txtConsignee.Tag)
    End Sub

    Private Sub cmdSelectConsignor_Click(sender As Object, e As EventArgs) Handles cmdSelectConsignor.Click
        With frmSelection
            .Text = "Select Consignor/Debtor"
            .PopulateGrid("SELECT Code, Description as `Consignor Name` FROM tbl_client ORDER BY `Consignor Name`", "`Consignor Name`", txtConsignor)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        txtConsignorAddress.Text = GetClientAddress(txtConsignor.Tag)
    End Sub

    Private Sub cmdSelectForwader_Click(sender As Object, e As EventArgs) Handles cmdSelectForwader.Click
        With frmSelection
            .Text = "Select Forwarder"
            .PopulateGrid("SELECT Code, Description as `Forwarder Name` FROM v_forwarder ORDER BY `Forwarder Name`", "`Forwarder Name`", txtForwarder)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        txtForwarderAddress.Text = GetClientAddress(txtForwarder.Tag)
    End Sub

    Private Sub txtShipper_TextChanged(sender As Object, e As EventArgs) Handles txtShipper.TextChanged
        ToolTip1.SetToolTip(txtShipper, txtShipper.Text)
    End Sub

    Private Sub txtConsignee_TextChanged(sender As Object, e As EventArgs) Handles txtConsignee.TextChanged
        ToolTip1.SetToolTip(txtConsignee, txtConsignee.Text)
    End Sub

    Private Sub txtConsignor_TextChanged(sender As Object, e As EventArgs) Handles txtConsignor.TextChanged
        ToolTip1.SetToolTip(txtConsignor, txtConsignor.Text)
    End Sub

    Private Sub txtForwarder_TextChanged(sender As Object, e As EventArgs) Handles txtForwarder.TextChanged
        ToolTip1.SetToolTip(txtForwarder, txtForwarder.Text)
    End Sub

    Private Sub dtgServices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgServices.CellContentClick

    End Sub

    Private Sub dtgServices_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dtgServices.CellValidated

    End Sub

    Private Sub lblStatusDetails_Click(sender As Object, e As EventArgs) Handles lblStatusDetails.Click
        If clsImportBooking._ID > 0 Then
            MsgBox("Status: " & txtStatus.Text.ToUpper & vbNewLine &
               "Status Update By: " & strStatusByName & vbNewLine &
               "Status Date: " & dtStatusDate, MsgBoxStyle.Information, "Status Details")
        End If
    End Sub

    Private Sub txtStatus_TextChanged(sender As Object, e As EventArgs) Handles txtStatus.TextChanged
        If IsNumeric(txtStatus.Tag) Then
            If CInt(txtStatus.Tag) > 1 Then
                lblStatusDetails.Visible = True
            Else
                lblStatusDetails.Visible = False
            End If
        Else
            lblStatusDetails.Visible = False
        End If
    End Sub

    Private Sub lblStatusDetails_MouseHover(sender As Object, e As EventArgs) Handles lblStatusDetails.MouseHover
        lblStatusDetails.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lblStatusDetails_MouseLeave(sender As Object, e As EventArgs) Handles lblStatusDetails.MouseLeave
        lblStatusDetails.BorderStyle = BorderStyle.None
    End Sub

    Private Sub dtgDocuments_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDocuments.CellContentClick
        dtgDocuments.EndEdit()
        chkDocsCompleted.Checked = CheckIfDocsComplete()
    End Sub
End Class