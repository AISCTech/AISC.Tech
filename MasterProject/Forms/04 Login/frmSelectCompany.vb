Public Class frmSelectCompany

    Dim intTemp As Integer
    Dim clsLogoServer As New clsFileLocation

    Private Sub DownloadCompanyLogo()
        Dim clsDB As New clsDBTrans
        clsLogoServer = clsDB.SearchFileLocation("CompanyLogo")

        Dim strFile1 As String
        Dim strFile2 As String

        For Each dtgRow As DataGridViewRow In dtgCompany.Rows
            strFile1 = clsLogoServer._Location & "\" & dtgRow.Cells(colCompanyLogoFilename.Name).Value
            strFile2 = LocalFiles._Images._CompanyLogo._FileLocation & "\" & dtgRow.Cells(colCompanyLogoFilename.Name).Value

            If CompareFiles(strFile1, strFile2) = False Then
                If System.IO.File.Exists(strFile1) Then
                    If System.IO.File.Exists(strFile2) Then
                        My.Computer.FileSystem.DeleteFile(strFile2)
                    End If
                    My.Computer.FileSystem.CopyFile(strFile1, strFile2)
                End If
            End If
        Next
    End Sub

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
                    If Not IsDBNull(reader.Item("LogoFileName")) Then
                        .Cells(colCompanyLogoFilename.Name).Value = reader.Item("LogoFileName")
                    Else
                        .Cells(colCompanyLogoFilename.Name).Value = ""
                    End If
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
        DownloadCompanyLogo()
    End Sub

    Private Sub dtgCompany_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCompany.CellContentClick

    End Sub

    Private Sub dtgCompany_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCompany.CellDoubleClick
        Try
            With dtgCompany.Rows(e.RowIndex)
                CurrentUser._Company_Code = .Cells(colCompanyCode.Name).Value
                CurrentUser._Company_Name = .Cells(colCompanyName.Name).Value
                CurrentUser._Company_Logo_Location = LocalFiles._Images._CompanyLogo._FileLocation & "\" & .Cells(colCompanyLogoFilename.Name).Value
                CurrentUser._Company_Logo = System.Drawing.Image.FromFile(CurrentUser._Company_Logo_Location)
                CurrentUser._Site_Code = .Cells(colSiteCode.Name).Value
                CurrentUser._Site_Name = .Cells(colSiteName.Name).Value
            End With

            strCompanyCode = Me.dtgCompany.CurrentRow.Cells(0).Value
            mdiMain.Show()
            frmLogIn.Close()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "System Message")
        End Try
    End Sub
End Class