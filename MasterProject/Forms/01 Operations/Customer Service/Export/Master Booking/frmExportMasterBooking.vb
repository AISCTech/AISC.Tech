Imports MasterProject

Public Class frmExportMasterBooking
    Implements ICommonFunction

    Public clsExportMasterRecord As New clsExportMasterBooking
    Dim dvDataView As DataView

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord

    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True, False)
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
        ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True, False)
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord

    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord

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
            clsExportMasterRecord = clsDB.SearchExportMasterRecord(clsExportMasterRecord._RefNo, clsExportMasterRecord._CompanyDetails._Company_Code)
            PopulateUserInput(clsExportMasterRecord)
            ChangeEnabledButtons(True, True, False, True, True, True, True, True, True, False, True)
        Else
            ClearUserInput()
            ChangeEnabledButtons(True, False, False, True, False, True, False, False, False, False, False)
        End If
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckRequiredEntries() = True Then
            Try
                Dim clsDB As New clsDBTrans

                clsExportMasterRecord = UserInputToClass()
                clsExportMasterRecord = clsDB.SaveExportMasterRecord(clsExportMasterRecord)
                clsExportMasterRecord = clsDB.SearchExportMasterRecord(clsExportMasterRecord._RefNo, clsExportMasterRecord._CompanyDetails._Company_Code)
                PopulateUserInput(clsExportMasterRecord)
                ChangeEnabledButtons(True, True, False, True, True, True, True, True, True, False, True)
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

    Private Sub PopGrid()
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT ID, " & '0
                                    "CompanyCode, " & '1
                                    "BookingNo, " & '2
                                    "CONCAT(BookingPrefix, '-', BookingNo) AS `Booking No.`, " & '3
                                    "ConsignorCode, " & '4
                                    "ConsignorName AS `Consignor / Debtor`, " & '5
                                    "ShipperCode, " & '6
                                    "ShipperName AS `Shipper`, " & '7
                                    "ConsigneeCode, " & '8
                                    "ConsigneeName AS `Consignee`, " & '9
                                    "FinalDestinationID, " & '10
                                    "FinalDestinationName AS `Final Destination`, " & '11
                                    "Volume AS `Measurement`, " & '12
                                    "NoOfPackage AS `Quantity`, " & '13
                                    "PackageUnitDesc AS `Unit`, " & '14
                                    "ActualVolume AS `Actual Measurement`, " & '15
                                    "StatusID, " & '16
                                    "Status_Name AS `Status` " & '17
                                "FROM " &
                                    "v_exportbookingheader " &
                                "WHERE " &
                                    "MasterBookingID = @MasterBookingID " &
                                "ORDER BY " &
                                    "PrepDate"
            With cmdSQL.Parameters
                .AddWithValue("@MasterBookingID", clsExportMasterRecord._ID)
            End With

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView

            With dtgBookingDetails
                .DataSource = dvDataView

                .Columns(0).Frozen = True
                .Columns(1).Frozen = True
                .Columns(2).Frozen = True
                .Columns(3).Frozen = True

                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Width = 125
                .Columns(4).Visible = False
                .Columns(5).Width = 300
                .Columns(6).Visible = False
                .Columns(7).Width = 300
                .Columns(8).Visible = False
                .Columns(9).Width = 300
                .Columns(10).Visible = False
                .Columns(11).Width = 125
                .Columns(12).Width = 100
                .Columns(13).Width = 100
                .Columns(14).Width = 125
                .Columns(15).Width = 100
                .Columns(16).Visible = False
                .Columns(17).Width = 100
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function UserInputToClass() As clsExportMasterBooking
        Dim clsTemp As New clsExportMasterBooking

        With clsTemp
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
        End With

        Return clsTemp
    End Function

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
            txtStatus.Tag = ._StatusDetails._Status_ID
            txtStatus.Text = ._StatusDetails._Status_Name
            tslblPrepBy.Text = ._PrepByDetails._First_Name & " " & ._PrepByDetails._Last_Name
            tslblPrepDate.Text = ._PrepDate
            tslblModBy.Text = ._ModByDetails._First_Name & " " & ._ModByDetails._Last_Name
            tslblModDate.Text = ._ModDate
        End With

        PopGrid()
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

        dtgBookingDetails.DataSource = Nothing
    End Sub

    Private EnableButtons As New clsEnableToolstripObjects()
    Public Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
                                     ByVal blPrintPreview As Boolean, ByVal blSearch As Boolean, ByVal blPost As Boolean,
                                     ByVal blCancel As Boolean, ByVal blReOpen As Boolean, ByVal blUserInput As Boolean,
                                    ByVal blAddBooking As Boolean)
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

        tscmdAdd.Enabled = blAddBooking
        tscmdRemove.Enabled = blAddBooking
    End Sub

    Private Sub frmExportMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetRecord()
    End Sub

    Private Sub frmExportMaster_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmExportMaster_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False, False)
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
            .clsTempMasterRecord = clsExportMasterRecord
            .ShowDialog()
        End With
    End Sub

    Private Sub tscmdRemove_Click(sender As Object, e As EventArgs) Handles tscmdRemove.Click
        If Me.dtgBookingDetails.Rows.Count > 0 Then
            If MsgBox("Remove booking no. " & dtgBookingDetails.CurrentRow.Cells(3).Value, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim clsDB As New clsDBTrans
                Dim clsExpBook As New clsExportBookingHeader

                With dtgBookingDetails.CurrentRow
                    clsExpBook = clsDB.SearchExportBookingRecord(.Cells(2).Value, .Cells(1).Value)
                    clsExpBook._MasterBookingDetails._ID = 0
                    clsExpBook = clsDB.SaveExportBookingRecord(clsExpBook)
                End With

                ResetRecord()
            End If
        End If
    End Sub
End Class