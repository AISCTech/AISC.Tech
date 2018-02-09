Public Class frmExportAddBookingToMaster
    Dim dvDataView As DataView
    Public clsTempMasterRecord As New clsExportMasterBooking

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
                                    "MasterBookingNo AS `Master Booking` " & '12
                                "FROM " &
                                    "v_exportbookingheader " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "ModeOfTransportID = @ModeOfTransportID AND " &
                                    "OriginID = @OriginID AND " &
                                    "LoadTypeID = @LoadTypeID AND " &
                                    "LENGTH(ColoadToID) = 0 AND " &
                                    "MasterBookingID <> @MasterBookingID AND " &
                                    "StatusID = 1 " &
                                "ORDER BY " &
                                    "PrepDate"
            With cmdSQL.Parameters
                .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                .AddWithValue("@ModeOfTransportID", clsTempMasterRecord._ModeOfTransportDetails._PK)
                .AddWithValue("@OriginID", clsTempMasterRecord._OriginDetails._PK)
                .AddWithValue("@LoadTypeID", clsTempMasterRecord._LoadTypeDetails._PK)
                .AddWithValue("@MasterBookingID", clsTempMasterRecord._ID)
            End With

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView

            With dtgExportBooking
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
                .Columns(12).Width = 125
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FilterGrid()
        Try
            Dim strTemp As String = ""
            Dim objSelectedValue As IConvertible

            If chkBookingNoAll.Checked = False Then
                strTemp = "`BookingNo` LIKE '%" & Replace(txtBookingNo.Text, "'", "''") & "%'"
            End If

            If chkConsignorAll.Checked = False Then
                objSelectedValue = TryCast(cboConsignor.SelectedValue, IConvertible)
                If Len(strTemp) > 0 Then
                    strTemp = strTemp & " AND "
                End If
                strTemp = strTemp & "`ConsignorCode` = '" & CStr(objSelectedValue) & "'"
            End If

            If chkShipperAll.Checked = False Then
                objSelectedValue = TryCast(cboShipper.SelectedValue, IConvertible)
                If Len(strTemp) > 0 Then
                    strTemp = strTemp & " AND "
                End If
                strTemp = strTemp & "`ShipperCode` = '" & CStr(objSelectedValue) & "'"
            End If

            If chkConsigneeAll.Checked = False Then
                objSelectedValue = TryCast(cboConsignee.SelectedValue, IConvertible)
                If Len(strTemp) > 0 Then
                    strTemp = strTemp & " AND "
                End If

                strTemp = strTemp & "`ConsigneeCode` = '" & CStr(objSelectedValue) & "'"
            End If

            dvDataView.RowFilter = Trim(strTemp)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "System Message")
        End Try
    End Sub

    Private Sub frmExportAddBookingToMaster_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmExportAddBookingToMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopGrid()
        Me.Text = "Select Export Booking [" & clsTempMasterRecord._ModeOfTransportDetails._Param_Desc & " | " &
                    clsTempMasterRecord._LoadTypeDetails._Param_Desc & " | " &
                    clsTempMasterRecord._OriginDetails._Description & "]"

        Dim clsMasterList As New clsPopulateComboBox(cboConsignor, "SELECT * FROM v_client ORDER BY `Description`", "Description", "Code")
        clsMasterList.PopComboBox()

        clsMasterList = New clsPopulateComboBox(cboShipper, "SELECT * FROM v_shipper ORDER BY `Description`", "Description", "Code")
        clsMasterList.PopComboBox()

        clsMasterList = New clsPopulateComboBox(cboConsignee, "SELECT * FROM v_consignee ORDER BY `Description`", "Description", "Code")
        clsMasterList.PopComboBox()

        chkBookingNoAll.Checked = True
        chkConsignorAll.Checked = True
        chkShipperAll.Checked = True
        chkConsigneeAll.Checked = True
    End Sub

    Private Sub chkBookingNoAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkBookingNoAll.CheckedChanged
        If chkBookingNoAll.Checked = True Then
            txtBookingNo.Text = ""
        End If
        txtBookingNo.Enabled = Not chkBookingNoAll.Checked
        FilterGrid()
    End Sub

    Private Sub txtBookingNo_TextChanged(sender As Object, e As EventArgs) Handles txtBookingNo.TextChanged
        FilterGrid()
    End Sub

    Private Sub chkConsignorAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkConsignorAll.CheckedChanged
        If chkConsignorAll.Checked = True Then
            cboConsignor.SelectedIndex = -1
        End If
        cboConsignor.Enabled = Not chkConsignorAll.Checked
        FilterGrid()
    End Sub

    Private Sub cboConsignor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConsignor.SelectedIndexChanged
        FilterGrid()
    End Sub

    Private Sub chkShipperAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkShipperAll.CheckedChanged
        If chkShipperAll.Checked = True Then
            cboShipper.SelectedIndex = -1
        End If
        cboShipper.Enabled = Not chkShipperAll.Checked
        FilterGrid()
    End Sub

    Private Sub cboShipper_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShipper.SelectedIndexChanged
        FilterGrid()
    End Sub

    Private Sub chkConsigneeAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkConsigneeAll.CheckedChanged
        If chkConsigneeAll.Checked = True Then
            cboConsignee.SelectedIndex = -1
        End If
        cboConsignee.Enabled = Not chkConsigneeAll.Checked
        FilterGrid()
    End Sub

    Private Sub cboConsignee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConsignee.SelectedIndexChanged
        FilterGrid()
    End Sub

    Private Sub dtgExportBooking_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgExportBooking.CellContentClick

    End Sub

    Private Sub dtgExportBooking_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgExportBooking.CellDoubleClick
        Try
            Dim clsDB As New clsDBTrans
            Dim clsExpBook As New clsExportBookingHeader

            With dtgExportBooking.Rows(e.RowIndex)
                clsExpBook = clsDB.SearchExportBookingRecord(.Cells(2).Value, .Cells(1).Value)
                clsExpBook._MasterBookingDetails._ID = clsTempMasterRecord._ID
                clsExpBook = clsDB.SaveExportBookingRecord(clsExpBook)
            End With

            With frmExportMasterBooking
                .ResetRecord()
            End With
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "System Message")
        End Try
    End Sub
End Class