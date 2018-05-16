Imports MySql.Data.MySqlClient
Public Class frmManageBank
    Private Sub frmManageBank_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadBankName()
    End Sub

    Private Sub loadBankName()
        Dim strsql As String
        Dim exist As Boolean
        Dim code As String = ""
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("colCode", "Code")
        DataGridView1.Columns.Add("colBank", "Bank Name")
        DataGridView1.Columns.Add("colCCode", "Company Code")
        DataGridView1.Columns.Add("colBankAcctNbr", "Account No.")
        DataGridView1.Columns("colBank").Width = 300
        DataGridView1.Columns("colBankAcctNbr").Width = 200
        DataGridView1.Rows.Clear()
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(2).Visible = False
        'DataGridView1.ColumnHeadersVisible = False
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        strsql = "SELECT * from lib_bank WHERE Name like '" & txtBank.Text & "%' ORDER by Name"
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            code = ""
            exist = False
            'If reader.Item("Active") = True Then
selectcode:
            Dim cnn As New MySqlConnection(strDBMaster)
            If cnn.State <> ConnectionState.Open Then cnn.Open()
            strsql = "SELECT * from tbl_vendor WHERE Description like '" & reader.Item("Name") & "'"
            Dim pysql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
            Dim pyrd As MySql.Data.MySqlClient.MySqlDataReader = pysql.ExecuteReader
            While pyrd.Read
                code = pyrd.Item("Code")
                exist = True
            End While
            pysql.Dispose()
            pyrd.Close()
            cnn.Close()
            If exist = False Then
                If cnn.State <> ConnectionState.Open Then cnn.Open()
                strsql = "INSERT INTO tbl_vendor (Code, Description) VALUES (@Code, @vendorname)"
                pysql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
                With pysql.Parameters
                    .AddWithValue("@Code", "V" & GetCtrlNbr(strCompanyCode, strSiteCode, "Vendor"))
                    .AddWithValue("@vendorname", reader.Item("Name"))
                End With
                pysql.ExecuteNonQuery()
                pysql.Dispose()
                cnn.Close()
                UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "Vendor")
                GoTo selectcode

            End If
            'End If
            If Me.Text = "Fund Transfer" Then
                If (BankCode(frmFundTransfer.txtFromBankAcct.Text) = reader.Item("Acronym") And frmFundTransfer.txtToBankAcct.Text = "") Or
                   (BankCode(frmFundTransfer.txtToBankAcct.Text) = reader.Item("Acronym") And frmFundTransfer.txtFromBankAcct.Text = "") Or
                   (frmFundTransfer.txtFromBankAcct.Text = "" And frmFundTransfer.txtToBankAcct.Text = "") Or
                   (BankCode(frmFundTransfer.txtFromBankAcct.Text) = reader.Item("Acronym") And BankCode(frmFundTransfer.txtToBankAcct.Text) = reader.Item("Acronym")) Then
                    If frmFundTransfer.rdSavings.Checked = True Then
                        If reader.Item("Company") = "AISC" Then
                            DataGridView1.Rows.Add(code, reader.Item("Name"), reader.Item("Company"), reader.Item("BankAcctNbr"))
                        End If
                    ElseIf frmFundTransfer.rdAffiliates.Checked = True Then
                        If reader.Item("Company") <> "" Then
                            If Me.Tag = "From" Then
                                If frmFundTransfer.ToCCode.Text = "" And reader.Item("Active") = True Then
                                    DataGridView1.Rows.Add(code, reader.Item("Name"), reader.Item("Company"), reader.Item("BankAcctNbr"))
                                ElseIf frmFundTransfer.ToCCode.Text <> reader.Item("Company") Then
                                    DataGridView1.Rows.Add(code, reader.Item("Name"), reader.Item("Company"), reader.Item("BankAcctNbr"))
                                End If
                            ElseIf Me.Tag = "To" Then
                                If frmFundTransfer.fromCCode.Text = "" And reader.Item("Active") = True Then
                                    DataGridView1.Rows.Add(code, reader.Item("Name"), reader.Item("Company"), reader.Item("BankAcctNbr"))
                                ElseIf frmFundTransfer.fromCCode.Text <> reader.Item("Company") Then
                                    DataGridView1.Rows.Add(code, reader.Item("Name"), reader.Item("Company"), reader.Item("BankAcctNbr"))
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                DataGridView1.Rows.Add(code, reader.Item("Name"), reader.Item("Company"), reader.Item("BankAcctNbr"))
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub
    Private Function BankCode(ByVal Bankname As String) As String
        BankCode = ""
        Dim strsql As String = "SELECT * from lib_bank WHERE Name like @BankName"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdBank = New MySqlCommand(strsql, cnn)
        cmdBank.Parameters.AddWithValue("@BankName", Bankname)
        Dim rdBank As MySqlDataReader = cmdBank.ExecuteReader
        While rdBank.Read
            BankCode = rdBank.Item("Acronym")
        End While
        cmdBank.Dispose()
        rdBank.Close()
        cnn.Close()
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If Me.Tag = "From" Then
            frmFundTransfer.txtFromBankCode.Text = Me.DataGridView1.SelectedCells(0).Value
            frmFundTransfer.txtFromBankAcct.Text = Me.DataGridView1.SelectedCells(1).Value
            frmFundTransfer.fromCCode.Text = Me.DataGridView1.SelectedCells(2).Value
            Me.Dispose()
        ElseIf Me.Tag = "To" Then
            frmFundTransfer.txtToBankCode.Text = Me.DataGridView1.SelectedCells(0).Value
        frmFundTransfer.txtToBankAcct.Text = Me.DataGridView1.SelectedCells(1).Value
        frmFundTransfer.ToCCode.Text = Me.DataGridView1.SelectedCells(2).Value
        Me.Dispose()
        End If
    End Sub
End Class