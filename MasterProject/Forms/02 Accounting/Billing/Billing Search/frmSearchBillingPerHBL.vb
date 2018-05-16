Imports MySql.Data.MySqlClient
Public Class frmSearchBillingPerHBL
    Private Sub PopdtgRefNo(ByVal strHBL As String)
        Dim strsql As String = "SELECT RefNo FROM bill_impfinv_main WHERE HouseBL = '" & strHBL & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgRefNo.Rows.Clear()
        While reader.Read
            Me.dtgRefNo.Rows.Add(reader.Item("RefNo"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub frmSearchBillingPerHBL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        PopdtgRefNo(frmInvoiceImpF.cboHBL.Text)
    End Sub

    Private Sub dtgRefNo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgRefNo.CellDoubleClick
        frmInvoiceImpF.RetrieveBillingMain("RefNo", Me.dtgRefNo.CurrentCell.Value)
        Me.Close()
    End Sub
End Class