Public Class frmSelectClient
    Dim dvDataView As DataView
    Public clsSelectedClient As New clsClientHeader

    Private Sub PopClientGrid()
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT `Code`, " &
                                    "`Prefix` AS `Client Code`, " &
                                    "`Description` AS `Clent Name`, " &
                                    "`Account_TypeDesc` AS `Account Type`, " &
                                    "`Account_HandlerName` AS `Account Handler` " &
                                "FROM " &
                                    "`v_client` " &
                                "ORDER BY " &
                                    "`Clent Name`"


            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView
            dtgClient.DataSource = dvDataView

            dtgClient.Columns(0).Frozen = True
            dtgClient.Columns(1).Frozen = True
            dtgClient.Columns(2).Frozen = True

            dtgClient.Columns(0).Visible = False
            dtgClient.Columns(1).Width = 100
            dtgClient.Columns(2).Width = 375
            dtgClient.Columns(3).Width = 125
            dtgClient.Columns(4).Width = 175

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmSelectClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopClientGrid()
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        dvDataView.RowFilter = "`Clent Name` LIKE '%" & Replace(txtFilter.Text, "'", "''") & "%'"
    End Sub

    Private Sub dtgClient_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgClient.CellContentClick

    End Sub

    Private Sub dtgClient_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgClient.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim clsDB As New clsDBTrans
            clsSelectedClient = clsDB.SearchClientRecord(dtgClient.Rows(e.RowIndex).Cells(0).Value)
            Me.Close()
        End If
    End Sub
End Class