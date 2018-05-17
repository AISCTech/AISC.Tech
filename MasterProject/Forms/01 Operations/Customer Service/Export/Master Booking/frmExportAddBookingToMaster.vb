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
                .AddWithValue("@ModeOfTransportID", frmExportMasterBooking.cboModeOfTransport.SelectedValue)
                .AddWithValue("@OriginID", frmExportMasterBooking.cboOriginPort.SelectedValue)
                .AddWithValue("@LoadTypeID", frmExportMasterBooking.cboLoadType.SelectedValue)
                .AddWithValue("@MasterBookingID", IIf(frmExportMasterBooking.clsExportMasterRecord._ID > 0, frmExportMasterBooking.clsExportMasterRecord._ID, -1))
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

            With frmExportMasterBooking
                For Each row As DataGridViewRow In .dtgBookingDetails.Rows
                    If Len(strTemp) > 0 Then
                        strTemp = strTemp & " AND "
                    End If

                    strTemp = strTemp & "`BookingNo` <> '" & row.Cells(.colBookingNo.Name).Value & "'"
                Next
            End With

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
        FilterGrid()

        Me.Text = "Select Export Booking [" & frmExportMasterBooking.cboModeOfTransport.Text & " | " &
                    frmExportMasterBooking.cboLoadType.Text & " | " &
                    frmExportMasterBooking.cboOriginPort.Text & "]"

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
            Dim clsExp As New clsExportBookingHeader

            With dtgExportBooking.Rows(e.RowIndex)
                clsExp = clsDB.CustomerServiceExportBookingSearch(.Cells(2).Value, .Cells(1).Value)
            End With

            Dim row As New DataGridViewRow

            With frmExportMasterBooking
                .dtgBookingDetails.Rows.Add()
                row = .dtgBookingDetails.Rows(.dtgBookingDetails.Rows.Count - 1)

                row.Cells(.colID.Name).Value = clsExp._ID
                row.Cells(.colCompanyCode.Name).Value = clsExp._CompanyDetails._Company_Code
                row.Cells(.colBookingNo.Name).Value = clsExp._BookingNo
                row.Cells(.colBookingNoComplete.Name).Value = clsExp._BookingPrefix & "-" & clsExp._BookingNo
                row.Cells(.colConsignorCode.Name).Value = clsExp._ConsignorDetails._Code
                row.Cells(.colConsignorName.Name).Value = clsExp._ConsignorDetails._Description
                row.Cells(.colShipperCode.Name).Value = clsExp._ShipperDetails._Code
                row.Cells(.colShipperName.Name).Value = clsExp._ShipperDetails._Description
                row.Cells(.colConsigneeCode.Name).Value = clsExp._ConsigneeDetails._Code
                row.Cells(.colConsigneeName.Name).Value = clsExp._ConsigneeDetails._Description
                row.Cells(.colFinalDestinationID.Name).Value = clsExp._FinalDestinationDetails._PK
                row.Cells(.colFinalDestinationName.Name).Value = clsExp._FinalDestinationDetails._Description
                row.Cells(.colMeasurement.Name).Value = clsExp._Volume
                row.Cells(.colNoOfPack.Name).Value = clsExp._NoOfPackage
                row.Cells(.colUnit.Name).Value = clsExp._PackageUnitDetails._Param_Desc
                row.Cells(.colActMeasurement.Name).Value = clsExp._ActualVolume
                row.Cells(.colStatusID.Name).Value = clsExp._StatusDetails._Status_ID
                row.Cells(.colStatusName.Name).Value = clsExp._StatusDetails._Status_Name
                row.Cells(.colColorR.Name).Value = clsExp._StatusDetails._Status_ColorR
                row.Cells(.colColorG.Name).Value = clsExp._StatusDetails._Status_ColorG
                row.Cells(.colColorB.Name).Value = clsExp._StatusDetails._Status_ColorB
            End With

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "System Message")
        End Try
    End Sub
End Class