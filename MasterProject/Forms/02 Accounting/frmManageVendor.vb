Public Class frmManageVendor
    Private Sub frmManageVendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopVendorList()
    End Sub

    Public Sub PopVendorList()
        Me.dgVendorList.Rows.Clear()
        Dim strSQL As String

        strSQL = "SELECT * " &
                     "FROM v_vendor WHERE Description like '%" & Me.txtSearch.Text & "%'"


        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView

        While reader.Read
            gridBook = Me.dgVendorList
            gridBook.Rows.Add(reader.Item("Code"), reader.Item("Description"), reader.Item("Addr1"), reader.Item("AddrCity"), reader.Item("CityDesc"), reader.Item("AddrCountry"), reader.Item("CountryDesc"), reader.Item("AddrZipCode"), reader.Item("BusStyle"), reader.Item("ContactMobileNo"), reader.Item("ContactFax"), reader.Item("ContactLandline"), reader.Item("ContactPerson"), reader.Item("Email"), reader.Item("Tin"), reader.Item("SalesTax"), reader.Item("SalesTaxDesc"), reader.Item("Terms"), reader.Item("TermsDesc"), reader.Item("CreditLimitAmt"), reader.Item("CreditLimitCurrency"), reader.Item("CurrencyDesc"), reader.Item("ModifiedBy"), reader.Item("Employee_Name"), reader.Item("ModifiedDate"), reader.Item("Prefix"))
            i = i + 1
        End While
        cmd.Dispose()
        reader.Close()
    End Sub

    Private Sub dgVendorList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgVendorList.CellContentClick

    End Sub

    Private Sub dgVendorList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgVendorList.CellDoubleClick
        Select Case Me.Tag
            Case "Main"

            Case "Request"
                frmRequest.txtPayeeCode.Text = Me.dgVendorList.CurrentRow.Cells(0).Value
                frmRequest.txtPayeeName.Text = Me.dgVendorList.CurrentRow.Cells(1).Value
                Me.Dispose()
                Me.Close()
            Case "PCV Check Request"
                frmPCVCheckRequest.txtPayeeCode.Text = Me.dgVendorList.CurrentRow.Cells(0).Value
                frmPCVCheckRequest.txtPayeeName.Text = Me.dgVendorList.CurrentRow.Cells(1).Value
                Me.Dispose()
                Me.Close()
        End Select
    End Sub
End Class