Public Class frmOtherCompanyRecord
    Dim dvDataView As DataView
    Public strCaller As String

    Private Sub PopImport()
        Dim objSelectedValue As IConvertible = TryCast(Me.cboCompany.SelectedValue, IConvertible)
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT ID, " &
                                    "BookingNo AS `Book`, " &
                                    "`CompanyCode` AS `CompanyCode`, " &
                                    "CONCAT(BookingPrefix, '-', BookingNo) AS `Booking No.`, " &
                                    "PrepDate AS `Prepared Date`, " &
                                    "HouseBL AS `House BL`, " &
                                    "ConsignorName AS `Consignor/Debtor`, " &
                                    "ShipperName AS `Shipper`, " &
                                    "ConsigneeName AS `Consignee`, " &
                                    "ForwarderName AS `Forwarder`, " &
                                    "OriginPortName AS `Origin`, " &
                                    "DestinationPortName AS `Destination`, " &
                                    "Status_Name AS `Status` " &
                                "FROM " &
                                    "v_importbookingheader " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "StatusID = 1 " &
                                "ORDER BY " &
                                    "PrepDate"
            With cmdSQL.Parameters
                .AddWithValue("@CompanyCode", CStr(objSelectedValue))
            End With

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView
            dtgBooking.DataSource = dvDataView

            dtgBooking.Columns(0).Frozen = True
            dtgBooking.Columns(1).Frozen = True
            dtgBooking.Columns(2).Frozen = True

            dtgBooking.Columns(0).Visible = False
            dtgBooking.Columns(1).Visible = False
            dtgBooking.Columns(2).Visible = False
            dtgBooking.Columns(3).Width = 125
            dtgBooking.Columns(4).Width = 125
            dtgBooking.Columns(5).Width = 150
            dtgBooking.Columns(6).Width = 200
            dtgBooking.Columns(7).Width = 200
            dtgBooking.Columns(8).Width = 200
            dtgBooking.Columns(9).Width = 200
            dtgBooking.Columns(10).Width = 125
            dtgBooking.Columns(11).Width = 125
            dtgBooking.Columns(12).Width = 100
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PopExport()
        Dim objSelectedValue As IConvertible = TryCast(Me.cboCompany.SelectedValue, IConvertible)
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT ID, " &
                                    "BookingNo AS `Book`, " &
                                    "`CompanyCode` AS `CompanyCode`, " &
                                    "CONCAT(BookingPrefix, '-', BookingNo) AS `Booking No.`, " &
                                    "PrepDate AS `Prepared Date`, " &
                                    "ConsignorName AS `Consignor/Debtor`, " &
                                    "ShipperName AS `Shipper`, " &
                                    "ConsigneeName AS `Consignee`, " &
                                    "OriginName AS `Origin`, " &
                                    "FinalDestinationName AS `Final Destination`, " &
                                    "Status_Name AS `Status` " &
                                "FROM " &
                                    "v_exportbookingheader " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "StatusID = 1 " &
                                "ORDER BY " &
                                    "PrepDate"
            With cmdSQL.Parameters
                .AddWithValue("@CompanyCode", CStr(objSelectedValue))
            End With

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView
            dtgBooking.DataSource = dvDataView

            dtgBooking.Columns(0).Frozen = True
            dtgBooking.Columns(1).Frozen = True
            dtgBooking.Columns(2).Frozen = True

            dtgBooking.Columns(0).Visible = False
            dtgBooking.Columns(1).Visible = False
            dtgBooking.Columns(2).Visible = False
            dtgBooking.Columns(3).Width = 125
            dtgBooking.Columns(4).Width = 125
            dtgBooking.Columns(5).Width = 200
            dtgBooking.Columns(6).Width = 200
            dtgBooking.Columns(7).Width = 200
            dtgBooking.Columns(8).Width = 125
            dtgBooking.Columns(9).Width = 125
            dtgBooking.Columns(10).Width = 100
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmImportRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case strCaller
            Case "Import"
                Me.Text = "Get Record from other Business Unit [Import Booking]"
            Case "Export"
                Me.Text = "Get Record from other Business Unit [Export Booking]"
            Case Else
                Me.Close()
        End Select

        Dim clsComboBox As New clsPopulateComboBox(cboCompany, "SELECT `Company_Code`, `Company_FullName` " &
                                                   "FROM tbl_company WHERE `Active` = 1 AND `Company_Code` <> '" & CurrentUser._Company_Code & "' " &
                                                   "ORDER BY `Company_FullName`", "Company_FullName", "Company_Code")
        clsComboBox.PopComboBox()
    End Sub

    Private Sub cboCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCompany.SelectedIndexChanged
        If cboCompany.SelectedIndex > -1 Then
            Select Case strCaller
                Case "Import"
                    PopImport()
                Case "Export"
                    PopExport()
            End Select
        Else
            dtgBooking.DataSource = Nothing
        End If
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        dvDataView.RowFilter = "`Booking No.` LIKE '%" & Replace(txtFilter.Text, "'", "''") & "%'"
    End Sub

    Private Sub dtgImportBooking_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBooking.CellContentClick

    End Sub

    Private Sub dtgImportBooking_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBooking.CellDoubleClick
        Select Case strCaller
            Case "Import"
                Dim clsImpBook As New clsImportBookingHeader
                Dim clsConsignor As New clsClientHeader
                Dim clsDB As New clsDBTrans
                With dtgBooking.Rows(e.RowIndex)
                    clsImpBook = clsDB.CustomerServiceImportSearch(.Cells(1).Value, .Cells(2).Value)
                End With

                With frmImportBookingMenu
                    .ImportRecord(clsImpBook)
                    Me.Close()
                End With
            Case "Export"
                Dim clsExpBook As New clsExportBookingHeader
                Dim clsConsignor As New clsClientHeader
                Dim clsDB As New clsDBTrans
                With dtgBooking.Rows(e.RowIndex)
                    clsExpBook = clsDB.CustomerServiceExportBookingSearch(.Cells(1).Value, .Cells(2).Value)
                End With

                With frmExportBookingMenu
                    .ImportRecord(clsExpBook)
                End With
        End Select
    End Sub
End Class