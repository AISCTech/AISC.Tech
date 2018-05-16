Imports MasterProject

Public Class frmExportMasterBooking
    Implements ICommonFunction

    Public clsExportMasterRecord As New clsExportMasterBooking
    Dim dvDataView As DataView

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        For Each row As DataGridViewRow In dtgBookingDetails.Rows
            If row.Cells(colStatusID.Name).Value = 2 Then
                MsgBox("Cannot cancel this record. There are posted booking/s under this master booking.", MsgBoxStyle.Information, "System Message")
                Exit Sub
            End If
        Next

        If txtStatus.Tag = 1 Then
            If MsgBox("Are you sure you want to CANCEL record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

                Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
                Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

                trnSQL = cnnDBMaster.BeginTransaction

                Try
                    cmdSQL.Connection = cnnDBMaster
                    cmdSQL.Transaction = trnSQL
                    cmdSQL.CommandText = "sp_exportmasterchangestatus"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_StatusID", 3)
                    cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusByID", CurrentUser._User_ID)
                    cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsExportMasterRecord._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()

                    trnSQL.Commit()
                    cmdSQL.Dispose()

                    Dim clsDB As New clsDBTrans
                    Dim clsExp As New clsExportBookingHeader

                    For Each row As DataGridViewRow In dtgBookingDetails.Rows
                        clsExp = clsDB.CustomerServiceExportBookingSearch(row.Cells(colBookingNo.Name).Value, row.Cells(colCompanyCode.Name).Value)
                        clsExp._MasterBookingDetails._ID = 0
                        clsExp = clsDB.CustomerServiceExportBookingSave(clsExp)
                    Next

                    clsExportMasterRecord = clsDB.CustomerServiceExportMasterSearch(clsExportMasterRecord._RefNo, clsExportMasterRecord._CompanyDetails._Company_Code)
                    PopulateUserInput(clsExportMasterRecord)
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
        If clsExportMasterRecord._StatusDetails._Status_ID = 1 Then
            ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
        Else
            MsgBox("Cannot edit record. Transaction is Not open.", MsgBoxStyle.Exclamation, "System Message")
        End If
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If clsExportMasterRecord._ID > 0 Then
            If MsgBox("Create new record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        ClearUserInput()
        txtOriginCountry.Text = "Philippines"
        clsExportMasterRecord = New clsExportMasterBooking
        ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        With txtATD
            If IsDate(.Text) = False Then
                MsgBox("ATD Required. Please input a date value for ATD!", MsgBoxStyle.Exclamation, "System Message")
                .Focus()
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
                Exit Sub
            End If
        End With

        With txtATA
            If IsDate(.Text) = False Then
                MsgBox("ATA Required. Please input a date value for ATA!", MsgBoxStyle.Exclamation, "System Message")
                .Focus()
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
                Exit Sub
            End If
        End With

        For Each row As DataGridViewRow In dtgBookingDetails.Rows
            If row.Cells(colStatusID.Name).Value <> 2 Then
                MsgBox("All booking no. under this master should be posted first.", MsgBoxStyle.Information, "System Message")
                Exit Sub
            End If
        Next

        If txtStatus.Tag = 1 Then
            If MsgBox("Are you sure you want to POST record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

                Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
                Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

                trnSQL = cnnDBMaster.BeginTransaction

                Try
                    cmdSQL.Connection = cnnDBMaster
                    cmdSQL.Transaction = trnSQL
                    cmdSQL.CommandText = "sp_exportmasterchangestatus"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_StatusID", 2)
                    cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusByID", CurrentUser._User_ID)
                    cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsExportMasterRecord._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()

                    trnSQL.Commit()
                    cmdSQL.Dispose()

                    Dim clsDB As New clsDBTrans
                    clsExportMasterRecord = clsDB.CustomerServiceExportMasterSearch(clsExportMasterRecord._RefNo, clsExportMasterRecord._CompanyDetails._Company_Code)
                    PopulateUserInput(clsExportMasterRecord)
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
            If MsgBox("Are you sure you want to Re-open this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

                Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
                Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

                trnSQL = cnnDBMaster.BeginTransaction

                Try
                    cmdSQL.Connection = cnnDBMaster
                    cmdSQL.Transaction = trnSQL
                    cmdSQL.CommandText = "sp_exportmasterchangestatus"
                    cmdSQL.CommandType = CommandType.StoredProcedure

                    cmdSQL.Parameters.AddWithValue("@p_StatusID", 1)
                    cmdSQL.Parameters("@p_StatusID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_StatusByID", CurrentUser._User_ID)
                    cmdSQL.Parameters("@p_StatusByID").Direction = ParameterDirection.Input

                    cmdSQL.Parameters.AddWithValue("@p_ID", clsExportMasterRecord._ID)
                    cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

                    cmdSQL.ExecuteNonQuery()

                    trnSQL.Commit()
                    cmdSQL.Dispose()

                    Dim clsDB As New clsDBTrans
                    clsExportMasterRecord = clsDB.CustomerServiceExportMasterSearch(clsExportMasterRecord._RefNo, clsExportMasterRecord._CompanyDetails._Company_Code)
                    PopulateUserInput(clsExportMasterRecord)
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
            MsgBox("Record is still open.", MsgBoxStyle.Information, "System Message")
        End If
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        Dim clsMasterLists As New clsPopulateComboBox(cboCarrier, "SELECT * FROM v_vendortype WHERE Params_Code = 2 ORDER BY `Description` ", "Description", "Code")
        clsMasterLists.PopComboBox()

        clsMasterLists = New clsPopulateComboBox(cboOriginPort, "SELECT * FROM lib_port WHERE Country_PK = 135 ORDER BY `Description`", "Description", "PK")
        clsMasterLists.PopComboBox()

        clsMasterLists = New clsPopulateComboBox(cboDestinationCountry, "SELECT * FROM lib_country ORDER BY `Description`", "Description", "PK")
        clsMasterLists.PopComboBox()

        clsMasterLists = New clsPopulateComboBox(cboModeOfTransport, "SELECT * FROM lib_params WHERE Param_Type = 4 ORDER BY `PK`", "Param_Desc", "PK")
        clsMasterLists.PopComboBox()

        clsMasterLists = New clsPopulateComboBox(cboLoadType, "SELECT * FROM lib_params WHERE Param_Type = 2 ORDER BY `PK`", "Param_Desc", "PK")
        clsMasterLists.PopComboBox()

        clsMasterLists = New clsPopulateComboBox(cboWarehouse, "SELECT * FROM lib_warehouse", "WarehouseName", "ID")
        clsMasterLists.PopComboBox()

        clsMasterLists = New clsPopulateComboBox(cboVessel, "SELECT * FROM lib_vessel ORDER BY `VesselName`", "VesselName", "ID")
        clsMasterLists.PopComboBox()

        clsMasterLists = New clsPopulateComboBox(cboAirLine, "SELECT * FROM v_vendortype WHERE Params_Code = 3 ORDER BY `Description`", "Description", "Code")
        clsMasterLists.PopComboBox()

        If clsExportMasterRecord._ID > 0 Then
            Dim clsDB As New clsDBTrans
            clsExportMasterRecord = clsDB.CustomerServiceExportMasterSearch(clsExportMasterRecord._RefNo, clsExportMasterRecord._CompanyDetails._Company_Code)
            PopulateUserInput(clsExportMasterRecord)
            ChangeEnabledButtons(True, True, False, True, True, True, True, True, True, False)
        Else
            ClearUserInput()
            ChangeEnabledButtons(True, False, False, True, False, True, False, False, False, False)
        End If
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckRequiredEntries() = True Then
            Try
                Dim clsDB As New clsDBTrans
                Dim clsCont As New clsExportMasterContainers
                Dim clsExp As New clsExportBookingHeader

                With clsExportMasterRecord
                    ._RefNo = txtRefNo.Text
                    ._CompanyDetails._Company_Code = CurrentUser._Company_Code
                    ._CarrierDetails._Code = cboCarrier.SelectedValue
                    ._OriginDetails._PK = cboOriginPort.SelectedValue
                    ._DestinationDetails._PK = cboDestinationPort.SelectedValue
                    ._ModeOfTransportDetails._PK = cboModeOfTransport.SelectedValue
                    ._LoadedPullOut = txtLoadedPullOut.Text
                    ._ContainerYard = txtContainerYard.Text
                    ._WarehouseDetails._ID = cboWarehouse.SelectedValue
                    ._ETD._StringValue = txtETD.Text
                    ._ATD._StringValue = txtATD.Text
                    ._SealNo = txtSealNo.Text
                    ._EmptyPositioning = txtEmptyPositioning.Text
                    ._ChassisDepot = txtChassisDepot.Text
                    ._VesselDetails._ID = cboVessel.SelectedValue
                    ._AirlineDetails._Code = cboAirLine.SelectedValue
                    ._LCT = txtLCT.Text
                    ._ETA._StringValue = txtETA.Text
                    ._ATA._StringValue = txtATA.Text
                    ._LoadTypeDetails._PK = cboLoadType.SelectedValue
                    ._PrepByDetails._User_ID = CurrentUser._User_ID
                    ._ModByDetails._User_ID = CurrentUser._User_ID

                    ._ListOfContainers.Clear()
                    For Each row As DataGridViewRow In dtgContainer.Rows
                        clsCont = New clsExportMasterContainers
                        clsCont._ContainerID = row.Cells(colCContainerID.Name).Value
                        ._ListOfContainers.Add(clsCont)
                    Next

                    ._ListOfBookingDetails.Clear()
                    For Each row As DataGridViewRow In dtgBookingDetails.Rows
                        clsExp = clsDB.CustomerServiceExportBookingSearch(row.Cells(colBookingNo.Name).Value, row.Cells(colCompanyCode.Name).Value)
                        ._ListOfBookingDetails.Add(clsExp)
                    Next
                End With

                clsExportMasterRecord = clsDB.CustomerServiceExportMasterSave(clsExportMasterRecord)
                clsExportMasterRecord = clsDB.CustomerServiceExportMasterSearch(clsExportMasterRecord._RefNo, clsExportMasterRecord._CompanyDetails._Company_Code)
                PopulateUserInput(clsExportMasterRecord)
                ChangeEnabledButtons(True, True, False, True, True, True, True, True, True, False)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "System Message")
            End Try
        End If
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        With frmSearchExportMasterBooking
            .strCaller = "Master"
            .ShowDialog()
        End With
    End Sub

    Public Sub PopulateUserInput(ByVal clsTemp As clsExportMasterBooking)
        ClearUserInput()

        With clsTemp
            txtRefNo.Text = ._RefNo
            cboCarrier.SelectedValue = ._CarrierDetails._Code
            txtOriginCountry.Text = "Philippines"
            cboOriginPort.SelectedValue = ._OriginDetails._PK
            cboDestinationCountry.SelectedValue = ._DestinationDetails._CountryDetails._PK
            cboDestinationPort.SelectedValue = ._DestinationDetails._PK
            cboModeOfTransport.SelectedValue = ._ModeOfTransportDetails._PK
            txtLoadedPullOut.Text = ._LoadedPullOut
            txtContainerYard.Text = ._ContainerYard
            cboWarehouse.SelectedValue = ._WarehouseDetails._ID
            txtETD.Text = ._ETD._StringValue
            txtATD.Text = ._ATD._StringValue
            txtSealNo.Text = ._SealNo
            txtEmptyPositioning.Text = ._EmptyPositioning
            txtChassisDepot.Text = ._ChassisDepot
            cboVessel.SelectedValue = ._VesselDetails._ID
            cboAirLine.SelectedValue = ._AirlineDetails._Code
            txtLCT.Text = ._LCT
            txtETA.Text = ._ETA._StringValue
            txtATA.Text = ._ATA._StringValue
            cboLoadType.SelectedValue = ._LoadTypeDetails._PK
            With ._StatusDetails
                txtStatus.Tag = ._Status_ID
                txtStatus.Text = ._Status_Name
                txtStatus.BackColor = Color.FromArgb(._Status_ColorR, ._Status_ColorG, ._Status_ColorB)
                If ._Status_ID = 1 Then
                    lblStatusDetails.Visible = False
                Else
                    lblStatusDetails.Visible = True
                End If
            End With
            tslblPrepBy.Text = ._PrepByDetails._First_Name & " " & ._PrepByDetails._Last_Name
            tslblPrepDate.Text = ._PrepDate
            tslblModBy.Text = ._ModByDetails._First_Name & " " & ._ModByDetails._Last_Name
            tslblModDate.Text = ._ModDate

            dtgContainer.Rows.Clear()
            For Each clsCont As clsExportMasterContainers In clsTemp._ListOfContainers
                dtgContainer.Rows.Add()
                With dtgContainer.Rows(dtgContainer.Rows.Count - 1)
                    .Cells(colCPK.Name).Value = clsTemp._ID
                    .Cells(colCContainerID.Name).Value = clsCont._ContainerID
                    .Cells(colCContainerNo.Name).Value = clsCont._ContainerNo
                    .Cells(colCContainerSizeID.Name).Value = clsCont._ContainerSizeID
                    .Cells(colCContainerSizeName.Name).Value = clsCont._ContainerSizeName
                End With
            Next

            dtgBookingDetails.Rows.Clear()

            For Each clsExp As clsExportBookingHeader In ._ListOfBookingDetails
                dtgBookingDetails.Rows.Add()
                With dtgBookingDetails.Rows(dtgBookingDetails.Rows.Count - 1)
                    .Cells(colID.Name).Value = clsExp._ID
                    .Cells(colCompanyCode.Name).Value = clsExp._CompanyDetails._Company_Code
                    .Cells(colBookingNo.Name).Value = clsExp._BookingNo
                    .Cells(colBookingNoComplete.Name).Value = clsExp._BookingPrefix & "-" & clsExp._BookingNo
                    .Cells(colConsignorCode.Name).Value = clsExp._ConsignorDetails._Code
                    .Cells(colConsignorName.Name).Value = clsExp._ConsignorDetails._Description
                    .Cells(colShipperCode.Name).Value = clsExp._ShipperDetails._Code
                    .Cells(colShipperName.Name).Value = clsExp._ShipperDetails._Description
                    .Cells(colConsigneeCode.Name).Value = clsExp._ConsigneeDetails._Code
                    .Cells(colConsigneeName.Name).Value = clsExp._ConsigneeDetails._Description
                    .Cells(colFinalDestinationID.Name).Value = clsExp._FinalDestinationDetails._PK
                    .Cells(colFinalDestinationName.Name).Value = clsExp._FinalDestinationDetails._Description
                    .Cells(colMeasurement.Name).Value = clsExp._Volume
                    .Cells(colNoOfPack.Name).Value = clsExp._NoOfPackage
                    .Cells(colUnit.Name).Value = clsExp._PackageUnitDetails._Param_Desc
                    .Cells(colActMeasurement.Name).Value = clsExp._ActualVolume
                    .Cells(colStatusID.Name).Value = clsExp._StatusDetails._Status_ID
                    .Cells(colStatusName.Name).Value = clsExp._StatusDetails._Status_Name
                    .Cells(colColorR.Name).Value = clsExp._StatusDetails._Status_ColorR
                    .Cells(colColorG.Name).Value = clsExp._StatusDetails._Status_ColorG
                    .Cells(colColorB.Name).Value = clsExp._StatusDetails._Status_ColorB
                End With
            Next
        End With
        SetGridColor()
    End Sub

    Private Sub SetGridColor()
        For Each row As DataGridViewRow In dtgBookingDetails.Rows
            For Each col As DataGridViewColumn In dtgBookingDetails.Columns
                row.Cells(col.Index).Style.BackColor = Color.FromArgb(row.Cells(colColorR.Name).Value, row.Cells(colColorG.Name).Value, row.Cells(colColorB.Name).Value)
            Next
        Next
    End Sub

    Private Function CheckRequiredEntries() As Boolean
        With cboCarrier
            If .SelectedIndex = -1 Then
                MsgBox("Please select Carrier!", MsgBoxStyle.Exclamation, "System Message")
                .Focus()
                Return False
            End If
        End With

        With cboOriginPort
            If .SelectedIndex = -1 Then
                MsgBox("Please select Origin Port!", MsgBoxStyle.Exclamation, "System Message")
                .Focus()
                Return False
            End If
        End With

        With cboDestinationCountry
            If .SelectedIndex = -1 Then
                MsgBox("Please select Destination Country!", MsgBoxStyle.Exclamation, "System Message")
                .Focus()
                Return False
            End If
        End With

        With cboDestinationPort
            If .SelectedIndex = -1 Then
                MsgBox("Please select Destination Port!", MsgBoxStyle.Exclamation, "System Message")
                .Focus()
                Return False
            End If
        End With

        With cboModeOfTransport
            If .SelectedIndex = -1 Then
                MsgBox("Please select Mode Of Transport!", MsgBoxStyle.Exclamation, "System Message")
                .Focus()
                Return False
            End If
        End With

        With cboLoadType
            If .SelectedIndex = -1 Then
                MsgBox("Please select Load Type!", MsgBoxStyle.Exclamation, "System Message")
                .Focus()
                Return False
            End If
        End With

        With txtETD
            If IsDate(.Text) = False Then
                MsgBox("Please input a date value for ETD!", MsgBoxStyle.Exclamation, "System Message")
                .Focus()
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
                Return False
            End If
        End With

        With txtETA
            If IsDate(.Text) = False Then
                MsgBox("Please input a date value for ETA!", MsgBoxStyle.Exclamation, "System Message")
                .Focus()
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
                Return False
            End If
        End With

        With txtATD
            If Len(Trim(.Text)) > 0 Then
                If IsDate(.Text) = False Then
                    MsgBox("Please input a date value for ATD!", MsgBoxStyle.Exclamation, "System Message")
                    .Focus()
                    .SelectionStart = 0
                    .SelectionLength = Len(.Text)
                    Return False
                End If
            End If
        End With

        With txtATA
            If Len(Trim(.Text)) > 0 Then
                If IsDate(.Text) = False Then
                    MsgBox("Please input a date value for ATA!", MsgBoxStyle.Exclamation, "System Message")
                    .Focus()
                    .SelectionStart = 0
                    .SelectionLength = Len(.Text)
                    Return False
                End If
            End If
        End With

        Return True
    End Function

    Private Sub ClearUserInput()
        txtRefNo.Text = ""
        cboCarrier.SelectedIndex = -1
        txtOriginCountry.Text = ""
        cboOriginPort.SelectedIndex = -1
        cboDestinationPort.SelectedIndex = -1
        cboDestinationCountry.SelectedIndex = -1
        cboModeOfTransport.SelectedIndex = -1
        cboLoadType.SelectedIndex = -1
        txtLoadedPullOut.Text = ""
        txtContainerYard.Text = ""
        cboWarehouse.SelectedIndex = -1
        dtETD.Value = Now
        txtETD.Text = ""
        dtATD.Value = Now
        txtATD.Text = ""
        txtSealNo.Text = ""
        txtEmptyPositioning.Text = ""
        txtChassisDepot.Text = ""
        cboVessel.SelectedIndex = -1
        txtLCT.Text = ""
        dtETA.Value = Now
        txtETA.Text = ""
        dtATA.Value = Now
        txtATA.Text = ""
        txtStatus.Tag = ""
        txtStatus.Text = ""
        tslblPrepBy.Text = ""
        tslblPrepDate.Text = ""
        tslblModBy.Text = ""
        tslblModDate.Text = ""
        lblStatusDetails.Visible = False

        dtgBookingDetails.DataSource = Nothing
        dtgContainer.Rows.Clear()
    End Sub

    Private EnableButtons As New clsEnableToolstripObjects()
    Public Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
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

        cboCarrier.Enabled = blUserInput
        cboOriginPort.Enabled = blUserInput
        cboDestinationCountry.Enabled = blUserInput
        cboDestinationPort.Enabled = blUserInput
        cboModeOfTransport.Enabled = blUserInput
        cboLoadType.Enabled = blUserInput
        txtLoadedPullOut.ReadOnly = Not blUserInput
        txtContainerYard.ReadOnly = Not blUserInput
        cboWarehouse.Enabled = blUserInput
        txtETD.ReadOnly = Not blUserInput
        dtETD.Enabled = blUserInput
        txtATD.ReadOnly = Not blUserInput
        dtATD.Enabled = blUserInput
        txtSealNo.ReadOnly = Not blUserInput
        txtEmptyPositioning.ReadOnly = Not blUserInput
        txtChassisDepot.ReadOnly = Not blUserInput
        cboVessel.Enabled = blUserInput
        cboAirLine.Enabled = blUserInput
        txtLCT.ReadOnly = Not blUserInput
        txtETA.ReadOnly = Not blUserInput
        dtETA.Enabled = blUserInput
        txtATA.ReadOnly = Not blUserInput
        dtATA.Enabled = blUserInput
        tscmdAdd.Enabled = blUserInput
        tscmdRemove.Enabled = blUserInput
        tscmdContainerAdd.Enabled = blUserInput
        tscmdContainerRemove.Enabled = blUserInput
        dtgContainer.Enabled = Enabled = blUserInput
    End Sub

    Private Sub frmExportMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetRecord()
    End Sub

    Private Sub frmExportMaster_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmExportMaster_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub cboDestinationCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDestinationCountry.SelectedIndexChanged

    End Sub

    Private Sub cboDestinationCountry_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDestinationCountry.SelectedValueChanged
        Dim objSelectedValue As IConvertible = TryCast(Me.cboDestinationCountry.SelectedValue, IConvertible)

        If Len(CInt(objSelectedValue)) > 0 Then
            Dim clsCombo As New clsPopulateComboBox(cboDestinationPort, "SELECT * FROM lib_port WHERE Country_PK = " & CInt(objSelectedValue) & " ORDER BY `Description`", "Description", "PK")
            clsCombo.PopComboBox()
        Else
            cboDestinationPort.Items.Clear()
        End If
    End Sub

    Private Sub dtETD_ValueChanged(sender As Object, e As EventArgs) Handles dtETD.ValueChanged
        txtETD.Text = dtETD.Value.ToShortDateString
    End Sub

    Private Sub dtATD_ValueChanged(sender As Object, e As EventArgs) Handles dtATD.ValueChanged
        txtATD.Text = dtATD.Value.ToShortDateString
    End Sub

    Private Sub dtETA_ValueChanged(sender As Object, e As EventArgs) Handles dtETA.ValueChanged
        txtETA.Text = dtETA.Value.ToShortDateString
    End Sub

    Private Sub dtATA_ValueChanged(sender As Object, e As EventArgs) Handles dtATA.ValueChanged
        txtATA.Text = dtATA.Value.ToShortDateString
    End Sub

    Private Sub tscmdAdd_Click(sender As Object, e As EventArgs) Handles tscmdAdd.Click
        With frmExportAddBookingToMaster
            .ShowDialog()
            SetGridColor()
        End With
    End Sub

    Private Sub tscmdRemove_Click(sender As Object, e As EventArgs) Handles tscmdRemove.Click
        If Me.dtgBookingDetails.Rows.Count > 0 Then
            If dtgBookingDetails.CurrentRow.Cells(colStatusID.Name).Value = 2 Then
                MsgBox("Cannot remove detail. Booking is already posted.", MsgBoxStyle.Information, "System Message")
                Exit Sub
            End If

            dtgBookingDetails.Rows.Remove(dtgBookingDetails.CurrentRow)
            SetGridColor()
        End If
    End Sub

    Private Sub lblStatusDetails_Click(sender As Object, e As EventArgs) Handles lblStatusDetails.Click
        If clsExportMasterRecord._ID > 0 Then
            MsgBox("Status: " & txtStatus.Text.ToUpper & vbNewLine &
               "Status Update By: " & clsExportMasterRecord._StatusByDetails._First_Name & " " & clsExportMasterRecord._StatusByDetails._Last_Name & vbNewLine &
               "Status Date: " & clsExportMasterRecord._StatusDate, MsgBoxStyle.Information, "Status Details")
        End If
    End Sub

    Private Sub lblStatusDetails_MouseHover(sender As Object, e As EventArgs) Handles lblStatusDetails.MouseHover
        lblStatusDetails.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lblStatusDetails_MouseLeave(sender As Object, e As EventArgs) Handles lblStatusDetails.MouseLeave
        lblStatusDetails.BorderStyle = BorderStyle.None
    End Sub

    Private Sub cboOriginPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOriginPort.SelectedIndexChanged

    End Sub

    Private Sub dtgBookingDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBookingDetails.CellContentClick

    End Sub

    Private Sub dtgBookingDetails_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBookingDetails.CellDoubleClick
        Dim clsDB As New clsDBTrans
        With frmExportBookingMenu
            .clsExportRecord = clsDB.CustomerServiceExportBookingSearch(dtgBookingDetails.Rows(e.RowIndex).Cells(colBookingNo.Name).Value, dtgBookingDetails.Rows(e.RowIndex).Cells(colCompanyCode.Name).Value)
            .PopulateUserInput(.clsExportRecord)
        End With

        ShowChildForm(frmExportBookingMenu)
    End Sub

    Private Sub tscmdContainerAdd_Click(sender As Object, e As EventArgs) Handles tscmdContainerAdd.Click
        frmAddBookingContainer.strCaller = "ExpMaster"
        frmAddBookingContainer.ShowDialog()
    End Sub

    Private Sub tscmdContainerRemove_Click(sender As Object, e As EventArgs) Handles tscmdContainerRemove.Click
        If Me.dtgContainer.Rows.Count > 0 Then
            dtgContainer.Rows.Remove(dtgContainer.CurrentRow)
        End If
    End Sub
End Class