Public Class frmBrkgItineraryAddBooking

    Dim dvDataView As DataView

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
                                    "FreightTypeName AS `Type`, " & '1
                                    "BookNo AS `Booking No.`, " & '2
                                    "ConsignorName AS `Client`, " & '3                                     
                                    "IF(StatusID > 0, StatTypeName, '-No Status-') AS `Status Type`, " & '4
                                    "IF(StatusID > 0, StatusName, '-No Status-') AS `Status`, " & '5
                                    "StatTypeID, " & '6
                                    "StatusID " & '7
                                "FROM " &
                                    "v_brkg_jo " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode " &
                                "ORDER BY " &
                                    "PrepDate"

            With cmdSQL.Parameters
                .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
            End With

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView

            With dtgBrkjJO
                .DataSource = dvDataView

                .Columns(0).Frozen = True
                .Columns(1).Frozen = True
                .Columns(2).Frozen = True

                .Columns(0).Visible = False
                .Columns(1).Width = 100
                .Columns(2).Width = 125
                .Columns(3).Width = 375
                .Columns(4).Width = 200
                .Columns(5).Width = 200
                .Columns(6).Visible = False
                .Columns(7).Visible = False
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmBrkgItineraryAddBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopGrid()
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        dvDataView.RowFilter = "`Booking No.` LIKE '%" & Replace(txtFilter.Text, "'", "''") & "%'"
    End Sub

    Private Sub dtgBrkjJO_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBrkjJO.CellContentClick

    End Sub

    Private Sub dtgBrkjJO_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBrkjJO.CellDoubleClick
        With frmBrkgSelectStatus
            .lngJOID = dtgBrkjJO.Rows(e.RowIndex).Cells(0).Value
            .txtType.Text = dtgBrkjJO.Rows(e.RowIndex).Cells(1).Value
            .txtBookingNo.Text = dtgBrkjJO.Rows(e.RowIndex).Cells(2).Value
            If dtgBrkjJO.Rows(e.RowIndex).Cells(7).Value > 0 Then
                .cboStatusType.SelectedValue = dtgBrkjJO.Rows(e.RowIndex).Cells(6).Value
                .cboStatusList.SelectedValue = dtgBrkjJO.Rows(e.RowIndex).Cells(7).Value
            End If
            .ShowDialog()
        End With
    End Sub
End Class