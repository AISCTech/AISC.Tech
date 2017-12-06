Imports MySql.Data.MySqlClient
Public Class frmSearchFundKey
    Private Sub frmSearchFundKey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetColumnProp()
        Populate()
    End Sub

    Private Sub SetColumnProp()
        With Me.dgFundKey
            With Me.dgFundKey

                .Columns.Add("", "FundKey")
                .Columns.Add("", "Prepared Date")
                .Columns.Add("", "Amount")
                .Columns.Add("", "Replenish")
                .Columns.Add("", "Check Request Number")

                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = True
                .MultiSelect = False

            End With
            .Columns(0).Width = 100
            .Columns(1).Width = 100
            .Columns(2).Width = 100
            .Columns(3).Width = 100

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With

        Me.Refresh()
    End Sub
    Private Sub Populate()
        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM tbl_pcv_replenish " &
         "ORDER BY PrepDate DESC"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView
        dgFundKey.Rows.Clear()
        While reader2.Read
            gridBook = Me.dgFundKey
            'gridBook.Rows.Clear()
            gridBook.Rows.Add(reader2.Item("RepNumber"), reader2.Item("PrepDate"), reader2.Item("Amount"), reader2.Item("Replenish"), reader2.Item("CRNbr"))
            i = i + 1
        End While

        cmd2.Dispose()
        reader2.Close()
    End Sub

    Private Sub dgFundKey_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFundKey.CellContentClick

    End Sub

    Private Sub dgFundKey_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFundKey.CellDoubleClick
        frmPettyCashReplenishment.SearchFundKey(Me.dgFundKey.CurrentRow.Cells(0).Value)
        frmPettyCashReplenishment.btSave.Enabled = False
        frmPettyCashReplenishment.btReport.Enabled = True
        Me.Dispose()
        Me.Close()
    End Sub
End Class