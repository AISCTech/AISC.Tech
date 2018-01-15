Imports MySql.Data.MySqlClient
Public Class frmPettyCashRelease
    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub frmPettyCashRelease_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBox(Me.cboPayee, "Select Description from tbl_vendor where Description is not null", "Description")
    End Sub

    Public Sub RetrieveFund(ByVal str As String)
        Dim cmd As MySql.Data.MySqlClient.MySqlCommand
        Dim strSQL As String

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        strSQL = "SELECT lib_pcv_fund.FundCode, lib_pcv_fund.FundName " &
            "FROM lib_pcv_fund " &
           "WHERE lib_pcv_fund.FundCode = '" & str & "'"

        cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            Me.txtFundKey.Text = reader.Item("FundCode")
            Me.txtFundName.Text = reader.Item("FundName")
        End While

        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub

    Private Sub SaveEntry(ByVal strPCRNo As String)
        Dim strsql As String = "DELETE FROM tbl_pcar WHERE PCAR_Nbr = '" & strPCRNo & "'", dtgEntryRow As DataGridViewRow

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdSQL.ExecuteNonQuery()

        For ctrRow As Integer = 0 To Me.dtgPCReleaseEntry.Rows.Count - 1
            strsql = "INSERT INTO tbl_pcar (PCAR_Nbr, PCAR_FundName, PCAR_Account_Code, PCAR_Account_Title, " &
                        "PCAR_DR, PCAR_CR,  PCAR_SubAccount_Code, PCAR_SubAccount_Title, " &
                        "PCAR_SubAccount_Dept, PCAR_SubAccount_DeptName, PCAR_SubAccount_List, " &
                        "PCAR_SubAccount_ListItem, PCAR_SubAccount_ListItemName) " &
                     "VALUES (@PCAR_Nbr, @PCAR_FundName, @PCAR_Account_Code, @PCAR_Account_Title, " &
                        "@PCAR_DR, @PCAR_CR, @PCAR_SubAccount_Code, @PCAR_SubAccount_Title, " &
                        "@PCAR_SubAccount_Dept, @PCAR_SubAccount_DeptName, @PCAR_SubAccount_List, " &
                        "@PCAR_SubAccount_ListItem, @PCAR_SubAccount_ListItemName)"

            dtgEntryRow = Me.dtgPCReleaseEntry.Rows(ctrRow)

            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

            With cmdSQL.Parameters
                .AddWithValue("@PCAR_Nbr", strPCRNo)
                .AddWithValue("@PCAR_FundName", Me.txtFundKey.Text)
                .AddWithValue("@PCAR_Account_Code", dtgEntryRow.Cells("colAcctCode").Value)
                .AddWithValue("@PCAR_Account_Title", dtgEntryRow.Cells("colAcctTitle").Value)
                .AddWithValue("@PCAR_DR", CDbl(dtgEntryRow.Cells("colDR").Value))
                .AddWithValue("@PCAR_CR", CDbl(dtgEntryRow.Cells("colCR").Value))
                .AddWithValue("@PCAR_SubAccount_Code", dtgEntryRow.Cells("colSubCode").Value)
                .AddWithValue("@PCAR_SubAccount_Title", dtgEntryRow.Cells("colSubAcctTitle").Value)
                .AddWithValue("@PCAR_SubAccount_Dept", dtgEntryRow.Cells("colchkDept").Value)
                .AddWithValue("@PCAR_SubAccount_DeptName", dtgEntryRow.Cells("colDeptName").Value)
                .AddWithValue("@PCAR_SubAccount_List", dtgEntryRow.Cells("colchkList").Value)
                .AddWithValue("@PCAR_SubAccount_ListItem", dtgEntryRow.Cells("colListItem").Value)
                .AddWithValue("@PCAR_SubAccount_ListItemName", dtgEntryRow.Cells("colListItemName").Value)
            End With

            cmdSQL.ExecuteNonQuery()
        Next
    End Sub

    Private Sub SetPettyCashEntry(ByVal strAcctCode As String, ByVal dblCR As Double)
        Dim strSQL As String, strDept As String = "", strSubAcctCode As String

        Select Case Me.txtFundKey.Text
            Case "AISMNL"
                strSubAcctCode = "1"
            Case "MNLOPR"
                strSubAcctCode = "16"
            Case "TRKMNL"
                strSubAcctCode = "4"
            Case "AISCAV"
                strSubAcctCode = "5"
            Case "CAVOPR"
                strSubAcctCode = "17"
            Case "AISLAG"
                strSubAcctCode = "6"
            Case "LAGOPR"
                strSubAcctCode = "18"
            Case "AISCBU"
                strSubAcctCode = "7"
            Case "CBUOPR"
                strSubAcctCode = "19"
            Case "AISSBC"
                strSubAcctCode = "12"
            Case "SBCOPR"
                strSubAcctCode = "20"
            Case "AISDVO"
                strSubAcctCode = "13"
            Case "DVOOPR"
                strSubAcctCode = "21"
            Case "AISBTN"
                strSubAcctCode = "14"
            Case "BTNOPR"
                strSubAcctCode = "22"
            Case "AISBRI"
                strSubAcctCode = "26"
            Case "AISBRE"
                strSubAcctCode = "27"
            Case "AISSFR"
                strSubAcctCode = "28"
            Case Else

                strSubAcctCode = ""
        End Select

        strSQL = "SELECT lib_acctcode.*, lib_subacctcode.* " &
                "FROM lib_acctcode INNER JOIN lib_subacctcode ON lib_acctcode.Account_Code = lib_subacctcode.Account_Code " &
               "WHERE(((lib_acctcode.Account_Code) = '" & strAcctCode & "' and lib_subacctcode.SubAccount_Code = '" & strSubAcctCode & "')) "


        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmd2.ExecuteReader()

        If reader2.HasRows = False Then
            cmd2.Dispose()
            reader2.Close()
            cnnDBMaster.Close()
            Exit Sub
        End If

        While reader2.Read
            If reader2.Item("SubAccount_Dept") = True Then
                'strDept = frmPCV.cboCostCenter.Text
            Else
                strDept = ""
            End If

            Me.dtgPCReleaseEntry.Rows.Add("", reader2.Item("Account_Code"), reader2.Item("Account_Title"), "0.00", Format(dblCR, "n2"), reader2.Item("SubAccount_Code"), reader2.Item("SubAccount_Title"), reader2.Item("SubAccount_Dept"), strDept, False, "", "")
        End While

        cmd2.Dispose()
        reader2.Close()
        cnnDBMaster.Close()
    End Sub

    Private Sub Release(ByVal str As String)
        Dim cmdSQL As New MySqlCommand
        Dim dtCurrent As Date

        If cboPayee.SelectedIndex = -1 Then
            MsgBox("Please Select Received By", vbInformation, "System Message")
            Exit Sub
        End If

        If Len(txtFundKey.Text) = 0 Then
            MsgBox("Please Select Type", vbInformation, "System Message")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to release?", vbYesNo, "Confirm Release") = vbNo Then

            Exit Sub
            Me.Close()
            Me.Dispose()
        Else

            dtCurrent = GetServerDate()
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim sSQL As String = "UPDATE tbl_request SET "
            sSQL += " REQ_Release=@REQ_Release, "
            sSQL += " REQ_ReleaseBy=@REQ_ReleaseBy, "
            sSQL += " REQ_ReleaseDate=@REQ_ReleaseDate, "
            sSQL += " REQ_PCVRepFund=@REQ_PCVRepFund, "
            sSQL += " REQ_PCVRepSave=@REQ_PCVRepSave, "
            sSQL += " REQ_PCVReceivedBy=@REQ_PCVReceivedBy "

            sSQL += " WHERE REQ_Nbr= '" & str & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters

                .AddWithValue("@REQ_Release", 1)
                .AddWithValue("@REQ_ReleaseBy", strCurrentUser)
                .AddWithValue("@REQ_ReleaseDate", dtCurrent)
                .AddWithValue("@REQ_PCVRepFund", Me.txtFundKey.Text)
                .AddWithValue("@REQ_PCVReceivedBy", Me.cboPayee.Text)
                .AddWithValue("@REQ_PCVRepSave", 0)

            End With

            frmPCV.txtReleaseDate.Text = dtCurrent
            frmPCV.txtReceiveBy.Text = Me.cboPayee.Text
            frmPCV.txtReleaseBy.Text = strCurrentUser
            frmPCV.txtStatus.Text = "Released"

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            Me.Refresh()

        End If
    End Sub

    Private Sub btRelease_Click(sender As Object, e As EventArgs) Handles btRelease.Click
        Release(frmPCV.lblReqNbr.Text)
        SaveEntry(frmPCV.lblReqNbr.Text)

        MsgBox("Released", vbInformation, "System Message")

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dtgPCReleaseEntry_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgPCReleaseEntry.CellContentClick
        If Me.dtgPCReleaseEntry.Columns(e.ColumnIndex).Name.Equals("colSelectEntry") And Me.colDR.ReadOnly = False Then
            frmSelectGLEntry.Tag = "PCRelease"
            frmSelectGLEntry.txtLineNbr.Text = e.RowIndex
            frmSelectGLEntry.ShowDialog()
        End If
    End Sub

    Private Sub cmdAddEntry_Click(sender As Object, e As EventArgs) Handles cmdAddEntry.Click
        Me.dtgPCReleaseEntry.Rows.Add()
    End Sub

    Private Sub cmdRemoveEntry_Click(sender As Object, e As EventArgs) Handles cmdRemoveEntry.Click
        With Me.dtgPCReleaseEntry
            If .CurrentRow.Index >= 0 Then
                .Rows.Remove(.CurrentRow)
            End If
        End With
    End Sub

    Private Sub cmdClearAllEntry_Click(sender As Object, e As EventArgs) Handles cmdClearAllEntry.Click
        Me.dtgPCReleaseEntry.Rows.Clear()

        Me.cmdAddEntry.Enabled = True
        Me.cmdRemoveEntry.Enabled = True
        Me.cmdPettyCash.Enabled = True
        Me.btRelease.Enabled = False
    End Sub

    Private Sub cmdPettyCash_Click(sender As Object, e As EventArgs) Handles cmdPettyCash.Click
        Dim dblTotalDR As Double = 0, dblTotalCR As Double = 0

        For ctrRow As Integer = 0 To Me.dtgPCReleaseEntry.Rows.Count - 1
            With Me.dtgPCReleaseEntry.Rows(ctrRow)
                dblTotalDR += CDbl(.Cells("colDR").Value)
                dblTotalCR += CDbl(.Cells("colCR").Value)
            End With
        Next

        If dblTotalDR <> CDbl(frmPCV.txtGrandTotal.Text) Then
            MsgBox("Total Debit is not equal to requested amount: " & frmPCV.txtGrandTotal.Text & "!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If dblTotalDR <= dblTotalCR Then
            MsgBox("Total Debit and Total Credit will not be balance!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        SetPettyCashEntry("1010", (dblTotalDR - dblTotalCR))

        Me.cmdAddEntry.Enabled = False
        Me.cmdRemoveEntry.Enabled = False
        Me.cmdPettyCash.Enabled = False
        Me.btRelease.Enabled = True
    End Sub

    Private Sub dtgPCReleaseEntry_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgPCReleaseEntry.CellEndEdit
        For ctrRow As Integer = 0 To Me.dtgPCReleaseEntry.Rows.Count - 1
            With Me.dtgPCReleaseEntry.Rows(ctrRow)
                .Cells("colDR").Value = Format(CDbl(.Cells("colDR").Value), "n2")
                .Cells("colCR").Value = Format(CDbl(.Cells("colCR").Value), "n2")
            End With
        Next
    End Sub

    Private Sub dtgPCReleaseEntry_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dtgPCReleaseEntry.EditingControlShowing
        Dim tb As TextBox

        tb = CType(e.Control, TextBox)
        '---add an event handler to the TextBox control---
        AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
    End Sub
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Me.dtgPCReleaseEntry.CurrentCell.ColumnIndex = 3 Or Me.dtgPCReleaseEntry.CurrentCell.ColumnIndex = 4 Then
            SetCharacter(MyOption.Numeric, e)
        Else
            SetCharacter(MyOption.AlphaNumeric, e)
        End If
    End Sub
End Class