Imports MasterProject

Public Class frmDomesticBookingMenu
    Implements ICommonFunction

    Public clsDomesticRecord As New clsDomesticBookingHeader

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
                    cmdSQL.CommandText = "sp_domesticbookingchangestatus"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_StatusID", 3)
                    cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusByID", CurrentUser._User_ID)
                    cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsDomesticRecord._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()

                    trnSQL.Commit()
                    cmdSQL.Dispose()

                    Dim clsDB As New clsDBTrans
                    clsDomesticRecord = clsDB.CustomerServiceDomesticBookingSearch(clsDomesticRecord._BookingNo, clsDomesticRecord._CompanyDetails._Company_Code)
                    PopulateUserInput(clsDomesticRecord)
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

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        If txtStatus.Tag = 1 Then
            ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
            cmdSelectConsignor.Focus()
        Else
            MsgBox("Cannot edit record. Transaction is not open.", MsgBoxStyle.Exclamation, "System Message")
        End If
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If MsgBox("Create new record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.Yes Then
            clsDomesticRecord = New clsDomesticBookingHeader
            ClearUserInput()
            txtOriginCountry.Text = "Philippines"
            txtDestinationCountry.Text = "Philippines"
            ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
            cmdSelectConsignor.Focus()
        End If
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        With txtActualGrossWeight
            If Not IsNumeric(.Text) And .Text <= 0 Then
                MsgBox("Actual Gross Weight is not yet encoded.", MsgBoxStyle.Information, "System Message")
                Exit Sub
            End If
        End With

        With txtActualVolume
            If Not IsNumeric(.Text) And .Text <= 0 Then
                MsgBox("Actual Volume is not yet encoded.", MsgBoxStyle.Information, "System Message")
                Exit Sub
            End If
        End With

        With txtRevisedMeasurement
            If Not IsNumeric(.Text) And .Text <= 0 Then
                MsgBox("Revised Measurement is not yet encoded.", MsgBoxStyle.Information, "System Message")
                Exit Sub
            End If
        End With

        If clsDomesticRecord._MasterBookingDetails._ID <= 0 Then
            MsgBox("Please select Master Booking.", MsgBoxStyle.Information, "System Message")
            Exit Sub
        End If

        If chkDocsCompleted.Checked = False Then
            MsgBox("Please check if required documents are completed.", MsgBoxStyle.Information, "System Message")
            Exit Sub
        End If

        If txtStatus.Tag = 1 Then
            If MsgBox("Are you sure you want to POST record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

                Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
                Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

                trnSQL = cnnDBMaster.BeginTransaction

                Try
                    cmdSQL.Connection = cnnDBMaster
                    cmdSQL.Transaction = trnSQL
                    cmdSQL.CommandText = "sp_domesticbookingchangestatus"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_StatusID", 2)
                    cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusByID", CurrentUser._User_ID)
                    cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsDomesticRecord._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()

                    trnSQL.Commit()
                    cmdSQL.Dispose()

                    Dim clsDB As New clsDBTrans
                    clsDomesticRecord = clsDB.CustomerServiceDomesticBookingSearch(clsDomesticRecord._BookingNo, clsDomesticRecord._CompanyDetails._Company_Code)
                    PopulateUserInput(clsDomesticRecord)
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

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

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
                    cmdSQL.CommandText = "sp_domesticbookingchangestatus"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_StatusID", 1)
                    cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusByID", CurrentUser._User_ID)
                    cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsDomesticRecord._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()

                    trnSQL.Commit()
                    cmdSQL.Dispose()

                    Dim clsDB As New clsDBTrans
                    clsDomesticRecord = clsDB.CustomerServiceDomesticBookingSearch(clsDomesticRecord._BookingNo, clsDomesticRecord._CompanyDetails._Company_Code)
                    PopulateUserInput(clsDomesticRecord)
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

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        Dim clsComboBox As New clsPopulateComboBox(cboModeOfTransport, "SELECT * FROM lib_params WHERE Param_Type = 4 ORDER BY `PK`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboOriginPort, "SELECT * FROM lib_port WHERE Country_PK = 135 ORDER BY `Description`", "Description", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboFinalDestPort, "SELECT * FROM lib_port WHERE Country_PK = 135 ORDER BY `Description`", "Description", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboLoadType, "SELECT * FROM lib_params WHERE Param_Type = 2 ORDER BY `PK`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboUnit, "SELECT * FROM lib_uom ORDER BY `Unit`", "Unit", "PK")
        clsComboBox.PopComboBox()

        PopulateServices()
        PopulateRequiredDocuments()

        tscmdReqDocsShow.Visible = True
        tscmdReqDocsHide.Visible = False
        pnlReqDocs.Height = 275
        pnlReqDocs.Hide()
        tscmdMasterShow.Visible = True
        tscmdMasterHide.Visible = False
        pnlMasterBooking.Height = 350
        pnlMasterBooking.Hide()
        tscmdColoadToShow.Visible = True
        tscmdColoadToHide.Visible = False
        pnlColoadTo.Height = 135
        pnlColoadTo.Hide()

        If clsDomesticRecord._ID > 0 Then
            Dim clsDB As New clsDBTrans
            clsDomesticRecord = clsDB.CustomerServiceDomesticBookingSearch(clsDomesticRecord._BookingNo, clsDomesticRecord._CompanyDetails._Company_Code)
            PopulateUserInput(clsDomesticRecord)
        Else
            ClearUserInput()
            ChangeEnabledButtons(True, False, False, True, False, True, False, False, False, False)
        End If

        Me.Refresh()
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckRequiredEntries() = True Then
            If MsgBox("Save Record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.Yes Then
                Try
                    Dim clsDocs As New clsDomesticBookingDocuments
                    Dim clsServices As New clsDomesticBookingServices

                    With clsDomesticRecord
                        ._ID = ._ID
                        ._BookingPrefix = GenerateBookingPrefix()
                        ._BookingNo = txtBookingNo.Text
                        ._CompanyDetails._Company_Code = CurrentUser._Company_Code
                        ._ConsignorDetails._Code = txtConsignor.Tag
                        ._SiteDetails._Site_Code = txtSite.Tag
                        ._AccountTypeDetails._ID = txtAccountType.Tag
                        ._AccountHolderDetails._User_ID = txtAccountHolder.Tag
                        ._ShipperDetails._Code = txtShipper.Tag
                        ._ConsigneeDetails._Code = txtConsignee.Tag
                        ._ModeOfTransportDetails._PK = cboModeOfTransport.SelectedValue
                        ._OriginDetails._PK = cboOriginPort.SelectedValue
                        ._FinalDestinationDetails._PK = cboFinalDestPort.SelectedValue
                        ._Commodity = txtCommodity.Text
                        ._DangerousCargo = chkDangerousCargo.Checked
                        ._GrossWeight = txtGrossWeight.Text
                        ._Volume = txtVolume.Text
                        ._LoadTypeDetails._PK = cboLoadType.SelectedValue
                        ._NoOfPackage = txtNoOfPackage.Text
                        ._PackageUnitDetails._PK = cboUnit.SelectedValue
                        ._DocsCompleted = chkDocsCompleted.Checked
                        ._ColoadToDetails._Code = txtColoadTo.Tag
                        ._KPIDate = Nothing
                        ._PrepByDetails._User_ID = CurrentUser._User_ID
                        ._ModByDetails._User_ID = CurrentUser._User_ID

                        ._ServiceDetails.Clear()
                        For Each dtgRow As DataGridViewRow In dtgServices.Rows
                            If dtgRow.Cells(colSSelected.Name).Value = True Then
                                clsServices = New clsDomesticBookingServices
                                clsServices._ServiceNameDetails._PK = dtgRow.Cells(colSPK.Name).Value
                                ._ServiceDetails.Add(clsServices)
                            End If
                        Next

                        ._DocumentDetails.Clear()
                        For Each dtgRow As DataGridViewRow In dtgDocuments.Rows
                            If dtgRow.Cells(colDSelected.Name).Value = True Then
                                clsDocs = New clsDomesticBookingDocuments
                                clsDocs._DocumentDetails._ID = dtgRow.Cells(colDDocID.Name).Value
                                ._DocumentDetails.Add(clsDocs)
                            End If
                        Next
                    End With

                    Dim clsDB As New clsDBTrans
                    clsDomesticRecord = clsDB.CustomerServiceDomesticBookingSave(clsDomesticRecord)
                    clsDomesticRecord = clsDB.CustomerServiceDomesticBookingSearch(clsDomesticRecord._BookingNo, CurrentUser._Company_Code)
                    PopulateUserInput(clsDomesticRecord)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "System Message")
                End Try
            End If
        End If
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
                            strTemp = strTemp & "AD"
                        Case "Sea"
                            strTemp = strTemp & "SD"
                    End Select
                    GoTo lnAccountType
                ElseIf dtgRow.Cells(colSSelected.Name).Value = True Then
                    strTemp = strTemp & dtgRow.Cells(colSPrefix.Name).Value
                    GoTo lnAccountType
                End If
            Next

lnAccountType:
            'Account Type
            strTemp = strTemp & clsDomesticRecord._AccountTypeDetails._Prefix

            GenerateBookingPrefix = strTemp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        With frmSearchBooking
            .strCaller = "Domestic"
            .ShowDialog()
        End With
        PopulateUserInput(clsDomesticRecord)
    End Sub

    Public Sub PopulateUserInput(ByVal clsTempDomesticRecord As clsDomesticBookingHeader)
        If Not IsNothing(clsTempDomesticRecord) And clsTempDomesticRecord._ID > 0 Then
            ClearUserInput()
            With clsTempDomesticRecord
                txtBookingPrefix.Text = ._BookingPrefix
                txtBookingNo.Text = ._BookingNo
                txtConsignor.Tag = ._ConsignorDetails._Code
                txtConsignor.Text = ._ConsignorDetails._Description
                txtConsignorAddress.Text = GetClientAddress(txtConsignor.Tag)
                txtAccountType.Tag = ._AccountTypeDetails._ID
                txtAccountType.Text = ._AccountTypeDetails._Description
                txtAccountHolder.Tag = ._AccountHolderDetails._User_ID
                txtAccountHolder.Text = ._AccountHolderDetails._First_Name & " " & ._AccountHolderDetails._Last_Name
                txtSite.Tag = ._SiteDetails._Site_Code
                txtSite.Text = ._SiteDetails._Site_Name
                txtShipper.Tag = ._ShipperDetails._Code
                txtShipper.Text = ._ShipperDetails._Description
                txtShipperAddress.Text = GetClientAddress(txtShipper.Tag)
                txtConsignee.Tag = ._ConsigneeDetails._Code
                txtConsignee.Text = ._ConsigneeDetails._Description
                txtConsigneeAddress.Text = GetClientAddress(txtConsignee.Tag)
                cboModeOfTransport.SelectedValue = ._ModeOfTransportDetails._PK
                txtCommodity.Text = ._Commodity
                chkDangerousCargo.Checked = ._DangerousCargo
                For Each clsService As clsDomesticBookingServices In ._ServiceDetails
                    For Each row As DataGridViewRow In dtgServices.Rows
                        If clsService._ServiceNameDetails._PK = row.Cells(colSPK.Name).Value Then
                            row.Cells(colSSelected.Name).Value = True
                        End If
                    Next
                Next
                txtOriginCountry.Text = "Philippines"
                cboOriginPort.SelectedValue = ._OriginDetails._PK
                txtDestinationCountry.Text = "Philippines"
                cboFinalDestPort.SelectedValue = ._FinalDestinationDetails._PK
                cboLoadType.SelectedValue = ._LoadTypeDetails._PK
                txtGrossWeight.Text = ._GrossWeight
                txtVolume.Text = ._Volume
                txtNoOfPackage.Text = ._NoOfPackage
                cboUnit.SelectedValue = ._PackageUnitDetails._PK
                txtActualGrossWeight.Text = ._ActualGrossWeight
                txtActualVolume.Text = ._ActualVolume
                txtRevisedMeasurement.Text = ._RevisedMeasurement
                txtMeasurementType.Tag = ._RevisedMeasurementTypeDetails._PK
                txtMeasurementType.Text = ._RevisedMeasurementTypeDetails._Param_Desc
                With ._StatusDetails
                    txtStatus.Tag = ._Status_ID
                    txtStatus.Text = ._Status_Name
                    txtStatus.BackColor = Color.FromArgb(._Status_ColorR, ._Status_ColorG, ._Status_ColorB)
                End With
                For Each row As DataGridViewRow In dtgDocuments.Rows
                    For Each clsTemp As clsDomesticBookingDocuments In ._DocumentDetails
                        If row.Cells(colDDocID.Name).Value = clsTemp._ID Then
                            row.Cells(colDSelected.Name).Value = True
                        End If
                    Next
                Next
                chkDocsCompleted.Checked = ._DocsCompleted
                If ._DocsCompletedDate <> Nothing Then
                    txtDocsCompletedDate.Text = ._DocsCompletedDate
                Else
                    txtDocsCompletedDate.Text = ""
                End If
                txtColoadTo.Tag = ._ColoadToDetails._Code
                txtColoadTo.Text = ._ColoadToDetails._Description
                txtColoadToAddress.Text = GetClientAddress(._ColoadToDetails._Code)

                For Each clsService As clsDomesticBookingServices In ._ServiceDetails
                    For Each row As DataGridViewRow In dtgServices.Rows
                        If clsService._ServiceNameDetails._PK = row.Cells(colSPK.Name).Value Then
                            row.Cells(colSSelected.Name).Value = True
                        End If
                    Next
                Next

                For Each clsDocs As clsDomesticBookingDocuments In ._DocumentDetails
                    For Each row As DataGridViewRow In dtgDocuments.Rows
                        If clsDocs._DocumentDetails._ID = row.Cells(colDDocID.Name).Value Then
                            row.Cells(colDSelected.Name).Value = True
                        End If
                    Next
                Next

                PopulateMasterBooking(._MasterBookingDetails)

                With ._PrepByDetails
                    tslblPrepBy.Text = ._First_Name & " " & ._Last_Name
                End With
                tslblPrepDate.Text = ._PrepDate

                With ._ModByDetails
                    tslblModBy.Text = ._First_Name & " " & ._Last_Name
                End With
                tslblModDate.Text = ._ModDate
            End With
            ChangeEnabledButtons(True, True, False, True, True, True, True, True, True, False)
        Else
            MsgBox("Booking No. not found.", MsgBoxStyle.Information, "System Message")
        End If
    End Sub

    Public Sub PopulateMasterBooking(ByVal clsTemp As clsDomesticMasterBooking)
        ClearMasterBooking()

        With clsTemp
            txtMRefNo.Text = ._RefNo
            txtMCarrier.Text = ._CarrierDetails._Description
            txtMOrigin.Text = ._OriginDetails._Description
            txtMDestination.Text = ._DestinationDetails._Description
            txtMLoadedPullOut.Text = ._LoadedPullOut
            txtMContainerYard.Text = ._ContainerYard
            txtMWarehouse.Text = ._WarehouseDetails._WarehouseName
            txtMETD.Text = ._ETD._StringValue
            txtMATD.Text = ._ATD._StringValue
            txtMETA.Text = ._ETA._StringValue
            txtMATA.Text = ._ATA._StringValue
            txtMSealNo.Text = ._SealNo
            txtMEmptyPositioning.Text = ._EmptyPositioning
            txtMChassisDepot.Text = ._ChassisDepot
            txtMVessel.Text = ._VesselDetails._VesselName
            txtMAirline.Text = ._AirlineDetails._Description
            txtMLCT.Text = ._LCT
        End With
    End Sub

    Public Sub ImportRecord(ByVal clsTempExportRecord As clsExportBookingHeader)
        If Not IsNothing(clsTempExportRecord) Then
            ClearUserInput()
            With clsTempExportRecord
                txtConsignor.Tag = ._ConsignorDetails._Code
                txtConsignor.Text = ._ConsignorDetails._Description
                txtConsignorAddress.Text = GetClientAddress(txtConsignor.Tag)
                txtAccountType.Tag = ._AccountTypeDetails._ID
                txtAccountType.Text = ._AccountTypeDetails._Description
                txtAccountHolder.Tag = ._AccountHolderDetails._User_ID
                txtAccountHolder.Text = ._AccountHolderDetails._First_Name & " " & ._AccountHolderDetails._Last_Name
                txtSite.Tag = ._SiteDetails._Site_Code
                txtSite.Text = ._SiteDetails._Site_Name
                txtShipper.Tag = ._ShipperDetails._Code
                txtShipper.Text = ._ShipperDetails._Description
                txtShipperAddress.Text = GetClientAddress(txtShipper.Tag)
                txtConsignee.Tag = ._ConsigneeDetails._Code
                txtConsignee.Text = ._ConsigneeDetails._Description
                txtConsigneeAddress.Text = GetClientAddress(txtConsignee.Tag)
                cboModeOfTransport.SelectedValue = ._ModeOfTransportDetails._PK
                txtCommodity.Text = ._Commodity
                chkDangerousCargo.Checked = ._DangerousCargo
                For Each clsService As clsExportBookingServices In ._ServiceDetails
                    For Each row As DataGridViewRow In dtgServices.Rows
                        If clsService._ServiceNameDetails._PK = row.Cells(colSPK.Name).Value Then
                            row.Cells(colSSelected.Name).Value = True
                        End If
                    Next
                Next
                txtOriginCountry.Text = "Philippines"
                cboOriginPort.SelectedValue = ._OriginDetails._PK
                txtDestinationCountry.Text = "Philippines"
                cboFinalDestPort.SelectedValue = ._FinalDestinationDetails._PK
                cboLoadType.SelectedValue = ._LoadTypeDetails._PK
                txtGrossWeight.Text = ._GrossWeight
                txtVolume.Text = ._Volume
                txtNoOfPackage.Text = ._NoOfPackage
                cboUnit.SelectedValue = ._PackageUnitDetails._PK
                txtActualGrossWeight.Text = ._ActualGrossWeight
                txtActualVolume.Text = ._ActualVolume
                txtRevisedMeasurement.Text = ._RevisedMeasurement
                txtMeasurementType.Tag = ._RevisedMeasurementTypeDetails._PK
                txtMeasurementType.Text = ._RevisedMeasurementTypeDetails._Param_Desc
                txtStatus.Tag = ._StatusDetails._Status_ID
                txtStatus.Text = ._StatusDetails._Status_Name
                For Each row As DataGridViewRow In dtgDocuments.Rows
                    For Each clsTemp As clsExportBookingDocuments In ._DocumentDetails
                        If row.Cells(colDDocID.Name).Value = clsTemp._ID Then
                            row.Cells(colDSelected.Name).Value = True
                        End If
                    Next
                Next
                chkDocsCompleted.Checked = ._DocsCompleted
                If ._DocsCompletedDate <> Nothing Then
                    txtDocsCompletedDate.Text = ._DocsCompletedDate
                Else
                    txtDocsCompletedDate.Text = ""
                End If
                txtColoadTo.Tag = ._ColoadToDetails._Code
                txtColoadTo.Text = ._ColoadToDetails._Description
                txtColoadToAddress.Text = GetClientAddress(._ColoadToDetails._Code)

                For Each clsService As clsExportBookingServices In ._ServiceDetails
                    For Each row As DataGridViewRow In dtgServices.Rows
                        If clsService._ServiceNameDetails._PK = row.Cells(colSPK.Name).Value Then
                            row.Cells(colSSelected.Name).Value = True
                        End If
                    Next
                Next

                For Each clsDocs As clsExportBookingDocuments In ._DocumentDetails
                    For Each row As DataGridViewRow In dtgDocuments.Rows
                        If clsDocs._DocumentDetails._ID = row.Cells(colDDocID.Name).Value Then
                            row.Cells(colDSelected.Name).Value = True
                        End If
                    Next
                Next

                With ._PrepByDetails
                    tslblPrepBy.Text = ._First_Name & " " & ._Last_Name
                End With
                tslblPrepDate.Text = ._PrepDate

                With ._ModByDetails
                    tslblModBy.Text = ._First_Name & " " & ._Last_Name
                End With
                tslblModDate.Text = ._ModDate
            End With
            ChangeEnabledButtons(True, True, False, True, True, True, True, True, True, False)
        End If
    End Sub

    Private Sub PopulateRequiredDocuments()
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM lib_booking_documents WHERE FreightType = 3 AND Active = TRUE"

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

    Public Sub PopulateServices()
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT Service_Code, Param_Type, Param_Code, Param_Value, Param_Desc " &
                        "FROM v_companyserviceoffered " &
                        "WHERE Company_Code = @Company_Code " &
                        "ORDER BY Service_Code"
            cmdSQL.Parameters.AddWithValue("@Company_Code", CurrentUser._Company_Code)
            dtgServices.Rows.Clear()

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            While reader.Read
                dtgServices.Rows.Add()
                With dtgServices.Rows(dtgServices.Rows.Count - 1)
                    .Cells(colSPK.Name).Value = reader.Item("Service_Code")
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

    Private Function CheckIfDocsComplete() As Boolean
        CheckIfDocsComplete = True
        For Each dtgRow As DataGridViewRow In dtgDocuments.Rows
            If dtgRow.Cells(colDRequired.Name).Value = True And dtgRow.Cells(colDSelected.Name).Value = False Then
                CheckIfDocsComplete = False
            End If
        Next
    End Function

    Private Function CheckRequiredEntries() As Boolean
        CheckRequiredEntries = True

        dtgServices.EndEdit()
        dtgDocuments.EndEdit()

        If Len(txtConsignor.Tag) = 0 Then
            MsgBox("Please select Consignor/Debtor.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            cmdSelectConsignor.Focus()
            Exit Function
        End If

        If Len(txtShipper.Tag) = 0 Then
            MsgBox("Please select Shipper.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            cmdSelectShipper.Focus()
            Exit Function
        End If

        If Len(txtConsignee.Tag) = 0 Then
            MsgBox("Please select Consignee.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            cmdSelectConsignee.Focus()
            Exit Function
        End If

        Dim blTemp As Boolean = False
        For Each row As DataGridViewRow In dtgServices.Rows
            If row.Cells(colSSelected.Name).Value = True Then
                blTemp = True
            End If
        Next

        If blTemp = False Then
            MsgBox("Please select Service/s.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            dtgServices.Focus()
            Exit Function
        End If

        If cboModeOfTransport.SelectedIndex = -1 Then
            MsgBox("Please select Mode of Transport.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            cboModeOfTransport.Focus()
            Exit Function
        End If

        If Len(txtCommodity.Text) = 0 Then
            MsgBox("Please enter Commodity.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            txtCommodity.Focus()
            Exit Function
        End If

        If cboLoadType.SelectedIndex = -1 Then
            MsgBox("Please select Load Type.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            cboLoadType.Focus()
            Exit Function
        End If

        If Not IsNumeric(txtGrossWeight.Text) Then
            MsgBox("Please enter a numeric value for Gross Weight.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            txtGrossWeight.Focus()
            Exit Function
        End If

        If Not IsNumeric(txtVolume.Text) Then
            MsgBox("Please enter a numeric value for Volume.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            txtVolume.Focus()
            Exit Function
        End If

        If Not IsNumeric(txtNoOfPackage.Text) Then
            MsgBox("Please enter a numeric value for No. of Package.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            txtNoOfPackage.Focus()
            Exit Function
        End If

        If cboUnit.SelectedIndex = -1 Then
            MsgBox("Please select Unit of Package.", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            cboUnit.Focus()
            Exit Function
        End If

        If clsDomesticRecord._MasterBookingDetails._ID > 0 Then
            With clsDomesticRecord._MasterBookingDetails
                If cboModeOfTransport.SelectedValue <> ._ModeOfTransportDetails._PK Then
                    MsgBox("Mode of Transport of Booking and Master Booking doesn't match.", MsgBoxStyle.Exclamation, "System Message")
                    CheckRequiredEntries = False
                    cboModeOfTransport.Focus()
                    Exit Function
                End If

                If cboLoadType.SelectedValue <> ._LoadTypeDetails._PK Then
                    MsgBox("Load Type of Booking and Master Booking doesn't match.", MsgBoxStyle.Exclamation, "System Message")
                    CheckRequiredEntries = False
                    cboLoadType.Focus()
                    Exit Function
                End If

                If cboOriginPort.SelectedValue <> ._OriginDetails._PK Then
                    MsgBox("Origin Port of Booking and Master Booking doesn't match.", MsgBoxStyle.Exclamation, "System Message")
                    CheckRequiredEntries = False
                    cboOriginPort.Focus()
                    Exit Function
                End If
            End With
        End If
    End Function

    Private Sub ClearUserInput()
        txtBookingPrefix.Text = ""
        txtBookingNo.Text = ""
        txtConsignor.Tag = ""
        txtConsignor.Text = ""
        txtConsignorAddress.Text = ""
        txtAccountType.Tag = ""
        txtAccountType.Text = ""
        txtAccountHolder.Tag = ""
        txtAccountHolder.Text = ""
        txtSite.Tag = ""
        txtSite.Text = ""
        txtShipper.Tag = ""
        txtShipper.Text = ""
        txtShipperAddress.Text = ""
        txtConsignee.Tag = ""
        txtConsignee.Text = ""
        txtConsigneeAddress.Text = ""
        cboModeOfTransport.SelectedIndex = -1
        txtCommodity.Text = ""
        chkDangerousCargo.Checked = False
        For Each row As DataGridViewRow In dtgServices.Rows
            row.Cells(colSSelected.Name).Value = False
        Next
        txtOriginCountry.Text = ""
        cboOriginPort.SelectedIndex = -1
        txtDestinationCountry.Text = ""
        cboFinalDestPort.SelectedIndex = -1
        cboLoadType.SelectedIndex = -1
        txtGrossWeight.Text = ""
        txtVolume.Text = ""
        txtNoOfPackage.Text = ""
        cboUnit.SelectedIndex = -1
        txtActualGrossWeight.Text = ""
        txtActualVolume.Text = ""
        txtRevisedMeasurement.Text = ""
        txtMeasurementType.Tag = ""
        txtMeasurementType.Text = ""
        txtStatus.Tag = ""
        txtStatus.Text = ""
        lblStatusDetails.Visible = False

        For Each row As DataGridViewRow In dtgDocuments.Rows
            row.Cells(colDSelected.Name).Value = False
        Next
        chkDocsCompleted.Checked = False
        txtDocsCompletedDate.Text = ""

        txtColoadTo.Tag = ""
        txtColoadTo.Text = ""
        txtColoadToAddress.Text = ""

        tslblPrepBy.Text = ""
        tslblPrepDate.Text = ""
        tslblModBy.Text = ""
        tslblModDate.Text = ""

        ClearMasterBooking()
    End Sub

    Private Sub ClearMasterBooking()
        For Each c1 As Control In pnlMasterBooking.Controls
            If c1.GetType Is GetType(TextBox) Then
                c1.Text = ""
            End If

            If c1.GetType Is GetType(GroupBox) Then
                For Each c2 As Control In c1.Controls
                    If c2.GetType Is GetType(TextBox) Then
                        c2.Text = ""
                    End If
                Next
            End If
        Next
    End Sub

    Private EnableButtons As New clsEnableToolstripObjects()
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

        cmdImportRecord.Enabled = blUserInput
        cmdSelectConsignor.Enabled = blUserInput
        cmdSelectShipper.Enabled = blUserInput
        cmdSelectConsignee.Enabled = blUserInput
        cboModeOfTransport.Enabled = blUserInput
        txtCommodity.ReadOnly = Not blUserInput
        chkDangerousCargo.AutoCheck = blUserInput
        dtgServices.ReadOnly = Not blUserInput
        cboOriginPort.Enabled = blUserInput
        cboFinalDestPort.Enabled = blUserInput
        cboLoadType.Enabled = blUserInput
        txtGrossWeight.ReadOnly = Not blUserInput
        txtVolume.ReadOnly = Not blUserInput
        txtNoOfPackage.ReadOnly = Not blUserInput
        cboUnit.Enabled = blUserInput
        dtgDocuments.ReadOnly = Not blUserInput
        cmdSelectColoadTo.Enabled = blUserInput
        lblRemoveColoadTo.Enabled = blUserInput

        lblRemoveMaster.Enabled = blUserInput
        cmdSelectMaster.Enabled = blUserInput
    End Sub

    Private Sub frmDomesticBookingMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetRecord()
    End Sub

    Private Sub frmDomesticBookingMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmDomesticBookingMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub lblStatusDetails_Click(sender As Object, e As EventArgs) Handles lblStatusDetails.Click
        If clsDomesticRecord._ID > 0 Then
            MsgBox("Status: " & txtStatus.Text.ToUpper & vbNewLine &
               "Status Update By: " & clsDomesticRecord._StatusByDetails._First_Name & " " & clsDomesticRecord._StatusByDetails._Last_Name & vbNewLine &
               "Status Date: " & clsDomesticRecord._StatusDate, MsgBoxStyle.Information, "Status Details")
        End If
    End Sub

    Private Sub lblStatusDetails_MouseHover(sender As Object, e As EventArgs) Handles lblStatusDetails.MouseHover
        lblStatusDetails.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lblStatusDetails_MouseLeave(sender As Object, e As EventArgs) Handles lblStatusDetails.MouseLeave
        lblStatusDetails.BorderStyle = BorderStyle.None
    End Sub

    Private Sub cmdSelectConsignor_Click(sender As Object, e As EventArgs) Handles cmdSelectConsignor.Click
        With frmSelectClient
            .ShowDialog()

            txtConsignor.Tag = .clsSelectedClient._Code
            txtConsignor.Text = .clsSelectedClient._Description
            txtConsignorAddress.Text = FormalText(.clsSelectedClient._Addr1 & " " & .clsSelectedClient._CityDesc & " " & .clsSelectedClient._CountryDesc).ToUpper
            clsDomesticRecord._AccountTypeDetails._Prefix = .clsSelectedClient._Account_TypePrefix

            txtSite.Tag = .clsSelectedClient._SiteDetails._Site_Code
            txtSite.Text = .clsSelectedClient._SiteDetails._Site_Name
            txtAccountType.Tag = .clsSelectedClient._Account_TypeID
            txtAccountType.Text = .clsSelectedClient._Account_TypeDesc
            txtAccountHolder.Tag = .clsSelectedClient._Account_HandlerID
            txtAccountHolder.Text = .clsSelectedClient._Account_HandlerName

            .Dispose()
        End With
    End Sub

    Private Sub cmdSelectShipper_Click(sender As Object, e As EventArgs) Handles cmdSelectShipper.Click
        txtShipper.Tag = ""
        txtShipper.Text = ""
        txtShipperAddress.Text = ""

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
        txtConsignee.Tag = ""
        txtConsignee.Text = ""
        txtConsigneeAddress.Text = ""

        With frmSelection
            .Text = "Select Consignee"
            .PopulateGrid("SELECT Code, Description as `Consignee Name` FROM v_consignee ORDER BY `Consignee Name`", "`Consignee Name`", txtConsignee)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        txtConsigneeAddress.Text = GetClientAddress(txtConsignee.Tag)
    End Sub

    Private Sub dtgDocuments_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDocuments.CellContentClick
        dtgDocuments.EndEdit()
        chkDocsCompleted.Checked = CheckIfDocsComplete()
    End Sub

    Private Sub cmdSelectColoadTo_Click(sender As Object, e As EventArgs) Handles cmdSelectColoadTo.Click
        txtColoadTo.Tag = ""
        txtColoadTo.Text = ""
        txtColoadToAddress.Text = ""

        With frmSelection
            .Text = "Select Forwarder for Coload To"
            .PopulateGrid("SELECT Code, Description as `Forwarder Name` FROM v_forwarder ORDER BY `Forwarder Name`", "`Consignee Name`", txtColoadTo)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        txtColoadToAddress.Text = GetClientAddress(txtColoadTo.Tag)
    End Sub
    Private Sub lblRemoveColoadTo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRemoveColoadTo.LinkClicked
        txtColoadTo.Tag = ""
        txtColoadTo.Text = ""
        txtColoadToAddress.Text = ""
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

    Private Sub cmdImportRecord_Click(sender As Object, e As EventArgs) Handles cmdImportRecord.Click
        With frmOtherCompanyRecord
            .strCaller = "Domestic"
            .ShowDialog()
        End With
    End Sub

    Private Sub tscmdMasterShow_Click(sender As Object, e As EventArgs) Handles tscmdMasterShow.Click
        pnlMasterBooking.Show()
        tscmdMasterShow.Visible = False
        tscmdMasterHide.Visible = True
        Me.Refresh()
    End Sub

    Private Sub tscmdMasterHide_Click(sender As Object, e As EventArgs) Handles tscmdMasterHide.Click
        pnlMasterBooking.Hide()
        tscmdMasterShow.Visible = True
        tscmdMasterHide.Visible = False
        Me.Refresh()
    End Sub

    Private Sub tscmdReqDocsShow_Click(sender As Object, e As EventArgs) Handles tscmdReqDocsShow.Click
        pnlReqDocs.Show()
        tscmdReqDocsShow.Visible = False
        tscmdReqDocsHide.Visible = True
        Me.Refresh()
    End Sub

    Private Sub tscmdReqDocsHide_Click(sender As Object, e As EventArgs) Handles tscmdReqDocsHide.Click
        pnlReqDocs.Hide()
        tscmdReqDocsShow.Visible = True
        tscmdReqDocsHide.Visible = False
        Me.Refresh()
    End Sub

    Private Sub tscmdColoadToShow_Click(sender As Object, e As EventArgs) Handles tscmdColoadToShow.Click
        pnlColoadTo.Show()
        tscmdColoadToShow.Visible = False
        tscmdColoadToHide.Visible = True
        Me.Refresh()
    End Sub

    Private Sub tscmdColoadToHide_Click(sender As Object, e As EventArgs) Handles tscmdColoadToHide.Click
        pnlColoadTo.Hide()
        tscmdColoadToShow.Visible = True
        tscmdColoadToHide.Visible = False
        Me.Refresh()
    End Sub

    Private Sub cmdSelectMaster_Click(sender As Object, e As EventArgs) Handles cmdSelectMaster.Click
        If cboModeOfTransport.SelectedIndex = -1 Or cboLoadType.SelectedIndex = -1 Or cboOriginPort.SelectedIndex = -1 Then
            MsgBox("Please select the following first:" & vbNewLine &
                   "1. Mode of Transport" & vbNewLine &
                   "2. Load Type" & vbNewLine &
                   "3. Origin Port", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        With frmSearchExportMasterBooking
            .strCaller = "Booking"
            .ShowDialog()
        End With
    End Sub

    Private Sub lblRemoveMaster_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRemoveMaster.LinkClicked
        If MsgBox("Clear Master Booking details?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
            clsDomesticRecord._MasterBookingDetails = New clsDomesticMasterBooking
            ClearMasterBooking()
        End If
    End Sub
End Class