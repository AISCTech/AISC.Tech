Public Class frmSelectCompany

    Dim intTemp As Integer

    Private Sub PopulateCompany()
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_useraccesscompanydept WHERE User_ID = @User_ID"
            cmdSQL.Parameters.AddWithValue("@User_ID", CurrentUser._User_ID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            dtgCompany.Rows.Clear()

            While reader.Read
                dtgCompany.Rows.Add()
                With dtgCompany.Rows(dtgCompany.Rows.Count - 1)
                    .Cells(colCompanyCode.Name).Value = reader.Item("Company_Code")
                    .Cells(colCompanyName.Name).Value = reader.Item("Company_Name")
                    .Cells(colSiteCode.Name).Value = reader.Item("Site_Code")
                    .Cells(colSiteName.Name).Value = reader.Item("Site_Name")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmSelectCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateCompany()
    End Sub

    Private Sub dtgCompany_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCompany.CellContentClick

    End Sub

    Private Sub dtgCompany_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCompany.CellDoubleClick
        With dtgCompany.Rows(e.RowIndex)
            CurrentUser._Company_Code = .Cells(colCompanyCode.Name).Value
            CurrentUser._Company_Name = .Cells(colCompanyName.Name).Value
            CurrentUser._Site_Code = .Cells(colSiteCode.Name).Value
            CurrentUser._Site_Name = .Cells(colSiteName.Name).Value
        End With

        mdiMain.Show()
        frmLogIn.Close()
        Me.Close()
    End Sub
End Class