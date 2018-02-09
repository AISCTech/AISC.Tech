Public Class frmSearchExportMasterBooking
    Dim dvDataView As DataView
    Public strCaller As String

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
                                    "RefNo AS `Reference No.`, " & '2
                                    "DestinationID AS `DestinationID`, " & '3
                                    "DestinationName AS `Port Of Destination`, " & '4
                                    "CarrierCode AS `CarrierCode`, " & '5
                                    "CarrierName AS `Carrier`, " & '6
                                    "ModeOfTransportID AS `ModeOfTransportID`, " & '7
                                    "ModeOfTransportDesc AS `Mode Of Transport`, " & '8
                                    "PrepDate AS `Prepared Date`, " & '9
                                    "LoadTypeID, " & '10
                                    "LoadTypeDesc AS `Load Type`, " & '11
                                    "Status_Name AS `Status`, " & '12
                                    "Status_ColorR, " & '13
                                    "Status_ColorG, " & '14
                                    "Status_ColorB " & '15
                                "FROM " &
                                    "v_exportmaster " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "PrepDate BETWEEN @DateFrom AND @DateTo " &
                                "ORDER BY " &
                                    "PrepDate DESC"
            With cmdSQL.Parameters
                .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                .AddWithValue("@DateFrom", dtFrom.Value)
                .AddWithValue("@DateTo", dtTo.Value)
            End With

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView

            With dtgMasterBooking
                .DataSource = dvDataView

                .Columns(0).Frozen = True
                .Columns(1).Frozen = True
                .Columns(2).Frozen = True

                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Width = 125
                .Columns(3).Visible = False
                .Columns(4).Width = 150
                .Columns(5).Visible = False
                .Columns(6).Width = 125
                .Columns(7).Visible = False
                .Columns(8).Width = 100
                .Columns(9).Width = 125
                .Columns(10).Visible = False
                .Columns(11).Width = 100
                .Columns(12).Width = 100
                .Columns(13).Visible = False
                .Columns(14).Visible = False
                .Columns(15).Visible = False
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FilterGrid()
        Try
            Dim strTemp As String = ""
            Dim objSelectedValue As IConvertible

            If chkRefNoAll.Checked = False Then
                strTemp = "`Reference No.` LIKE '%" & Replace(txtRefNo.Text, "'", "''") & "%'"
            End If

            If chkDestinationAll.Checked = False Then
                objSelectedValue = TryCast(cboDestination.SelectedValue, IConvertible)
                If Len(strTemp) > 0 Then
                    strTemp = strTemp & " AND "
                End If
                strTemp = strTemp & "`DestinationID` = " & CInt(objSelectedValue)
            End If

            If chkModeOfTransportAll.Checked = False Then
                objSelectedValue = TryCast(cboModeOfTransport.SelectedValue, IConvertible)
                If Len(strTemp) > 0 Then
                    strTemp = strTemp & " AND "
                End If
                strTemp = strTemp & "`ModeOfTransportID` = " & CInt(objSelectedValue)
            End If

            If chkLoadTypeAll.Checked = False Then
                objSelectedValue = TryCast(cboLoadType.SelectedValue, IConvertible)
                If Len(strTemp) > 0 Then
                    strTemp = strTemp & " AND "
                End If

                strTemp = strTemp & "`LoadTypeID` = " & CInt(objSelectedValue)
            End If

            dvDataView.RowFilter = Trim(strTemp)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "System Message")
        End Try
    End Sub

    Private Sub chkRefNoAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkRefNoAll.CheckedChanged
        If chkRefNoAll.Checked = True Then
            txtRefNo.Text = ""
        End If
        txtRefNo.Enabled = Not chkRefNoAll.Checked
        FilterGrid()
    End Sub

    Private Sub chkDestinationAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkDestinationAll.CheckedChanged
        If chkDestinationAll.Checked = True Then
            cboDestination.SelectedIndex = -1
        End If
        cboDestination.Enabled = Not chkDestinationAll.Checked

        FilterGrid()
    End Sub

    Private Sub chkModeOfTransportAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkModeOfTransportAll.CheckedChanged
        If chkModeOfTransportAll.Checked = True Then
            cboModeOfTransport.SelectedIndex = -1
        End If
        cboModeOfTransport.Enabled = Not chkModeOfTransportAll.Checked

        FilterGrid()
    End Sub

    Private Sub frmSearchExportMasterBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtServerDate As Date = GetServerDate()
        Dim dtToday As Date = New Date(dtServerDate.Year, dtServerDate.Month, dtServerDate.Day, 0, 0, 0)

        dtFrom.Value = GetFirstDayOfWeek(dtToday)
        dtTo.Value = GetLastDayOfWeek(dtToday)

        Dim clsMasterList As New clsPopulateComboBox(cboDestination, "SELECT * FROM lib_port ORDER BY `Description`", "Description", "PK")
        clsMasterList.PopComboBox()

        clsMasterList = New clsPopulateComboBox(cboModeOfTransport, "SELECT * FROM lib_params WHERE Param_Type = 4 ORDER BY `PK`", "Param_Desc", "PK")
        clsMasterList.PopComboBox()

        clsMasterList = New clsPopulateComboBox(cboLoadType, "SELECT * FROM lib_params WHERE Param_Type = 2 ORDER BY `PK`", "Param_Desc", "PK")
        clsMasterList.PopComboBox()

        chkRefNoAll.Checked = True
        chkDestinationAll.Checked = True
        chkModeOfTransportAll.Checked = True
        chkLoadTypeAll.Checked = True
    End Sub

    Private Sub dtFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtFrom.ValueChanged
        PopGrid()
    End Sub

    Private Sub dtTo_ValueChanged(sender As Object, e As EventArgs) Handles dtTo.ValueChanged
        PopGrid()
    End Sub

    Private Sub txtRefNo_TextChanged(sender As Object, e As EventArgs) Handles txtRefNo.TextChanged
        FilterGrid()
    End Sub

    Private Sub cboDestination_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDestination.SelectedIndexChanged
        FilterGrid()
    End Sub

    Private Sub cboModeOfTransport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboModeOfTransport.SelectedIndexChanged
        FilterGrid()
    End Sub

    Private Sub chkConsol_CheckedChanged(sender As Object, e As EventArgs)
        FilterGrid()
    End Sub

    Private Sub dtgMasterBooking_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgMasterBooking.CellContentClick

    End Sub

    Private Sub dtgMasterBooking_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgMasterBooking.CellDoubleClick
        Select Case strCaller
            Case "Master"
                Dim clsDB As New clsDBTrans
                With frmExportMasterBooking
                    .clsExportMasterRecord = clsDB.SearchExportMasterRecord(dtgMasterBooking.Rows(e.RowIndex).Cells(2).Value, dtgMasterBooking.Rows(e.RowIndex).Cells(1).Value)
                    .PopulateUserInput(.clsExportMasterRecord)
                    .ChangeEnabledButtons(True, True, False, True, True, True, True, True, True, False, True)
                End With
            Case "Booking"
                Dim clsDB As New clsDBTrans
                With frmExportBookingMenu
                    .clsExportRecord._MasterBookingDetails = clsDB.SearchExportMasterRecord(dtgMasterBooking.Rows(e.RowIndex).Cells(2).Value, dtgMasterBooking.Rows(e.RowIndex).Cells(1).Value)
                    .PopulateMasterBooking(.clsExportRecord._MasterBookingDetails)
                End With
            Case Else
                MsgBox("Wrong Caller!", MsgBoxStyle.OkOnly, "System Message")
        End Select
        Me.Close()
    End Sub

    Private Sub frmSearchExportMasterBooking_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub chkLoadTypeAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkLoadTypeAll.CheckedChanged
        If chkLoadTypeAll.Checked = True Then
            cboLoadType.SelectedIndex = -1
        End If
        cboLoadType.Enabled = Not chkLoadTypeAll.Checked
        FilterGrid()
    End Sub

    Private Sub cboLoadType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLoadType.SelectedIndexChanged
        FilterGrid()
    End Sub
End Class