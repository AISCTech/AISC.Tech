Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmFundTransfer
    Implements ICommonFunction
    Private EnableButtons As New clsEnableToolstripObjects()
    Private Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
                                     ByVal blPrintPreview As Boolean, ByVal blSearch As Boolean, ByVal blPost As Boolean,
                                     ByVal blCancel As Boolean, ByVal blReOpen As Boolean, ByVal blUserInput As Boolean)
        With EnableButtons
            .NewEnabled = blNew
            .EditEnabled = blEdit
            .SaveEnabled = blSave
            .ResetEnabled = blReset
            .PrintPreviewEnabled = blPrintPreview
            .SearchEnabled = blSearch
            .PostEnabled = blPost
            .CancelEnabled = blCancel
            .ReOpen = blReOpen

            cmdFund.Enabled = blPost
            btAdvanceSearch.Enabled = blSearch

            gpType.Enabled = blUserInput
            btnFrom.Enabled = blUserInput
            btnTo.Enabled = blUserInput
            txtAmt.ReadOnly = Not blUserInput
            txtExRate.ReadOnly = Not blUserInput
            txtRemarks.ReadOnly = Not blUserInput

            .UpdateEnabledButtons()
        End With
    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        'If GetUserAccess(CurrentUsername, CurrentPassword, "AllowCancel") = False Then
        '    MsgBox("You are not allowed to Cancel", vbInformation, "System Message")
        '    Exit Sub
        'End If
        CancelFT()
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        'If GetUserAccess(CurrentUsername, CurrentPassword, "AllowEdit") = False Then
        '    MsgBox("You are not allowed to Edit Fund Transfer", vbInformation, "System Message")
        '    Exit Sub
        'End If
        'EnableButtons(False, False, True, True, False, False, False, False, False, True)
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
        gpType.Enabled = False
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_CreateCV") = False Then
        '    MsgBox("You are not allowed to Create Fund Transfer", vbInformation, "System Message")
        '    Exit Sub
        'End If
        If MsgBox("Create new transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If
        clr()
        'EnableButtons(False, False, True, True, False, False, False, False, False, True)
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        'If GetUserAccess(CurrentUsername, CurrentPassword, "AllowPost") = False Then
        '    MsgBox("You are not allowed to Post", vbInformation, "System Message")
        '    Exit Sub
        'End If
        PostFT()
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        Throw New NotImplementedException()
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        If MsgBox("Clear all details?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If
        clr()
        'EnableButtons(True, False, False, False, False, False, False, False, True, False)
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        SaveFT()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        Throw New NotImplementedException()
    End Sub

    Private Sub frmFundTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeEnabledButtons(True, True, True, True, True, True, True, True, True, True)
        Me.cboReport.Items.Add("Online")
        Me.cboReport.Items.Add("Offline")
    End Sub

    Private Sub frmFundTransfer_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmFundTransfer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Function GetAcctNbr(ByVal bankname As String) As String
        GetAcctNbr = ""
        Dim strsql As String = "SELECT * from lib_bank WHERE Name like '" & bankname & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader1 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql1.ExecuteReader
        While reader1.Read
            GetAcctNbr = reader1.Item("BankAcctNbr")
        End While
        cmdsql1.Dispose()
        reader1.Close()
        cnn.Close()
    End Function

    Private Function GetCompanyCode(ByVal bankname As String) As String
        GetCompanyCode = ""
        Dim strsql As String = "SELECT * from lib_bank WHERE Name like '" & bankname & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader1 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql1.ExecuteReader
        While reader1.Read
            GetCompanyCode = reader1.Item("Company")
        End While
        cmdsql1.Dispose()
        reader1.Close()
        cnn.Close()
    End Function

    Public Function LoadFT(ByVal refno As String) As Boolean
        LoadFT = False
        Dim strsql As String = "SELECT * from ft_main where RefNo like '" & refno & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            clr()
            LoadFT = True
            Me.lblCVNbr.Text = reader.Item("RefNo")
            If reader.Item("TypeOfTransaction") = "ftaffiliates" Then
                rdAffiliates.Checked = True
            Else
                rdSavings.Checked = True
            End If
            Me.txtFromBankCode.Text = reader.Item("FromBankCode")
            Me.txtToBankCode.Text = reader.Item("ToBankCode")
            Me.txtAmt.Text = Format$(reader.Item("Amount"), "n2")
            Me.txtExRate.Text = Format$(reader.Item("ExRate"), "n2")
            Me.txtPrepBy.Text = reader.Item("PrepBy")
            Me.txtPrepDate.Text = Format$(reader.Item("PrepDate"), "Short Date")
            Me.txtRemarks.Text = reader.Item("Remarks")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
            'EnableButtons(True, True, False, False, True, False, True, True, True, False)
            If reader.Item("Fund") = True Then
                Me.chkFunded.Checked = reader.Item("Fund")
                Me.txtFundedBy.Text = reader.Item("FundBy")
                Me.txtFundedDate.Text = Format$(reader.Item("FundDate"), "Short Date")
                ChangeEnabledButtons(True, False, False, False, True, True, True, True, True, False)
                'EnableButtons(True, False, False, False, False, True, False, True, True, False)
            End If
            If reader.Item("Posted") = True Then
                Me.chkPosted.Checked = reader.Item("Posted")
                Me.txtPostedBy.Text = reader.Item("PostedBy")
                Me.txtPostedDate.Text = Format$(reader.Item("PostedDate"), "Short Date")
                Me.txtRefNo.Text = reader.Item("CheckNo")
                Me.txtDate.Text = Format$(reader.Item("dtPost"), "Short Date")
                'EnableButtons(True, False, False, False, False, False, False, True, True, False)
                ChangeEnabledButtons(True, False, False, False, True, True, False, True, True, False)
            End If
            If reader.Item("Cancelled") = True Then
                Me.chkCancelled.Checked = reader.Item("Cancelled")
                Me.txtCancelledBy.Text = reader.Item("CancelledBy")
                Me.txtCancelledDate.Text = Format$(reader.Item("CancelledDate"), "Short Date")
                ChangeEnabledButtons(True, False, False, False, False, True, False, False, True, False)
                'EnableButtons(True, False, False, False, False, False, False, False, True, False)
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn.Close()

        dtgBankEntry.Rows.Clear()

        strsql = "SELECT * from ft_acctg_entry where RefNo like '" & refno & "'"
        Dim cnn2 As New MySqlConnection(strDBMaster)
        If cnn2.State <> ConnectionState.Open Then cnn2.Open()
        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn2)
        reader = cmdsql.ExecuteReader
        While reader.Read
            Me.dtgBankEntry.Rows.Add("", reader.Item("AcctCode"), GetAcctTitle(reader.Item("AcctCode")), Format$(reader.Item("DR"), "n2"), Format$(reader.Item("CR"), "n2"), reader.Item("SubAcctCode"), GetSubAcctTitle(reader.Item("AcctCode"), reader.Item("SubAcctCode")), reader.Item("Dept"), reader.Item("DeptName"), reader.Item("List"), reader.Item("ListItem"), reader.Item("ListItemName"))
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn2.Close()
        Me.fromCCode.Text = GetCompanyCode(txtFromBankAcct.Text)
        Me.ToCCode.Text = GetCompanyCode(txtToBankAcct.Text)
        Me.txtFromAcct.Text = GetAcctNbr(txtFromBankAcct.Text)
        Me.txtToAcct.Text = GetAcctNbr(txtToBankAcct.Text)
    End Function

    Private Function GetAcctTitle(ByVal code As String) As String
        GetAcctTitle = ""
        Dim strsql As String = "SELECT * from lib_acctcode WHERE Account_Code like '" & code & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            GetAcctTitle = reader.Item("Account_Title")
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn.Close()
    End Function

    Private Function GetSubAcctTitle(ByVal code As String, ByVal subcode As String) As String
        GetSubAcctTitle = ""
        Dim strsql As String = "SELECT * from lib_subacctcode WHERE Account_Code like '" & code & "' AND SubAccount_Code like '" & subcode & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            GetSubAcctTitle = reader.Item("SubAccount_Title")
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn.Close()
    End Function

    Private Sub CancelFT()
        If MsgBox("Do you want to cancel Fund Transfer?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim strsql As String = "UPDATE ft_main SET Cancelled = @cancelled, CancelledBy = @cancelledby, CancelledDate = @cancelleddate WHERE RefNo like '" & Me.lblCVNbr.Text & "'"
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        With cmdsql.Parameters
            .AddWithValue("@cancelled", 1)
            .AddWithValue("@cancelledby", CurrentUser)
            .AddWithValue("@cancelleddate", GetServerDate)
        End With
        cmdsql.ExecuteNonQuery()
        cmdsql.Dispose()
        cnn.Close()

        chkCancelled.Checked = True
        txtCancelledBy.Text = strCurrentUser
        txtCancelledDate.Text = Format$(GetServerDate, "Short Date")
        MsgBox("Fund Transfer Cancelled.", MsgBoxStyle.Information, "System Message")
        ChangeEnabledButtons(True, False, False, False, False, True, False, False, True, False)
        'EnableButtons(True, False, False, False, False, False, False, False, True, False)
    End Sub

    Private Sub PostFT()
        If MsgBox("Do you want to post Fund Transfer?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim strsql As String = "UPDATE ft_main SET Posted = @posted, PostedBy = @postedby, PostedDate = @posteddate, CheckNo = @checkno, dtPost = @dtpost WHERE RefNo like '" & Me.lblCVNbr.Text & "'"
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        With cmdsql.Parameters
            .AddWithValue("@posted", 1)
            .AddWithValue("@postedby", CurrentUser)
            .AddWithValue("@posteddate", GetServerDate)
            .AddWithValue("@checkno", Me.txtRefNo.Text)
            .AddWithValue("@dtpost", CDate(Me.txtDate.Text))
        End With
        cmdsql.ExecuteNonQuery()
        cmdsql.Dispose()
        cnn.Close()

        'If rdAffiliates.Checked = True Then
        ' Dim dr As Double = 0, cr As Double = 0
        ' Dim z As Integer = Me.dtgBankEntry.Rows.Count - 1
        ' For a As Integer = 0 To z
        ' dr = 0
        ' cr = 0
        ' With Me.dtgBankEntry.Rows(a)
        ' dr = Format$(CDbl(.Cells(4).Value), "n2")
        ' cr = Format$(CDbl(.Cells(3).Value), "n2")
        ' Me.dtgBankEntry.Rows.Add("", .Cells(1).Value, .Cells(2).Value, Format$(dr, "n2"), Format$(cr, "n2"), .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value)
        ' End With
        ' Next
        ' End If

        strsql = "DELETE from ft_acctg_entry WHERE RefNo like '" & Me.lblCVNbr.Text & "'"
        Dim cnn2 As New MySqlConnection(strDBMaster)
        If cnn2.State <> ConnectionState.Open Then cnn2.Open()
        Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn2)
        cmdsql1.ExecuteNonQuery()
        cmdsql1.Dispose()
        cnn2.Close()

        For z As Integer = 0 To dtgBankEntry.Rows.Count - 1
            If cnn2.State <> ConnectionState.Open Then cnn2.Open()
            strsql = "INSERT INTO ft_acctg_entry (RefNo, AcctCode, SubAcctCode, DR, CR, Dept, DeptName, List, ListItem, ListItemName) " &
                 "VALUES (@RefNo, @AcctCode, @SubAcctCode, @DR, @CR, @Dept, @DeptName, @List, @ListItem, @ListItemName)"
            cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn2)
            With cmdsql1.Parameters
                .AddWithValue("@RefNo", CStr(Me.lblCVNbr.Text))
                .AddWithValue("@AcctCode", CStr(dtgBankEntry.Rows(z).Cells(1).Value))
                .AddWithValue("@DR", CDbl(dtgBankEntry.Rows(z).Cells(3).Value))
                .AddWithValue("@CR", CDbl(dtgBankEntry.Rows(z).Cells(4).Value))
                .AddWithValue("@SubAcctCode", CStr(dtgBankEntry.Rows(z).Cells(5).Value))
                .AddWithValue("@Dept", CBool(dtgBankEntry.Rows(z).Cells(7).Value))
                .AddWithValue("@DeptName", CStr(dtgBankEntry.Rows(z).Cells(8).Value))
                .AddWithValue("@List", CBool(dtgBankEntry.Rows(z).Cells(9).Value))
                .AddWithValue("@ListItem", CStr(dtgBankEntry.Rows(z).Cells(10).Value))
                .AddWithValue("@ListItemName", CStr(dtgBankEntry.Rows(z).Cells(11).Value))
            End With
            cmdsql1.ExecuteNonQuery()
            cmdsql1.Dispose()
            cnn2.Close()
        Next

        chkPosted.Checked = True
        txtPostedBy.Text = strCurrentUser
        txtPostedDate.Text = Format$(GetServerDate, "Short Date")
        MsgBox("Fund Transfer Posted.", MsgBoxStyle.Information, "System Message")
        ChangeEnabledButtons(True, False, False, False, False, True, False, True, True, False)
        'EnableButtons(True, False, False, False, False, False, False, True, True, False)
    End Sub

    Private Sub GetAffiliatesEntry()
        Me.dtgBankEntry.Rows.Clear()
        If Me.txtFromBankAcct.Text = "" And Me.txtToBankAcct.Text = "" Then
            Exit Sub
        End If
        Dim totalamt As Double = 0
        If Me.txtAmt.Text <> "" And Me.txtExRate.Text <> "" Then
            totalamt = CDbl(Me.txtAmt.Text) * CDbl(Me.txtExRate.Text)
        End If
        Dim dracct As String = "", drsubacct As String = ""
        Dim cracct As String = "", crsubacct As String = ""
        Dim strsql As String = "SELECT * from lib_bank WHERE Name like '" & Me.txtFromBankAcct.Text & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            If Me.txtFromBankAcct.Text <> "" Then
                cracct = reader.Item("Account_Code")
                crsubacct = reader.Item("SubAccount_Code")
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn.Close()

        Dim cnn2 As New MySqlConnection(strDBMaster)
        strsql = "SELECT * from lib_bank WHERE Name like '" & Me.txtToBankAcct.Text & "'"
        If cnn2.State <> ConnectionState.Open Then cnn2.Open()
        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn2)
        reader = cmdsql.ExecuteReader
        While reader.Read
            If Me.txtFromBankAcct.Text <> "" Then
                dracct = reader.Item("Account_Code")
                drsubacct = reader.Item("SubAccount_Code")
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn2.Close()

        If dracct = "" And Me.txtAmt.Text <> "" Then
            Me.dtgBankEntry.Rows.Add("", 1320, "Advances to Affiliates", Format$(CDbl(totalamt), "n2"), "0.00", 1, "Fund Transfer", 0, "", 1, "Affiliates", Me.txtToBankAcct.Text & " " & Me.txtToAcct.Text)
        End If
        strsql = "SELECT * from lib_acctcode WHERE Account_Code like '" & dracct & "'"
        Dim cnn3 As New MySqlConnection(strDBMaster)
        If cnn3.State <> ConnectionState.Open Then cnn3.Open()
        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn3)
        reader = cmdsql.ExecuteReader
        While reader.Read
            If Me.txtAmt.Text <> "" Then
                Dim cnn4 As New MySqlConnection(strDBMaster)
                If cnn4.State <> ConnectionState.Open Then cnn4.Open()
                strsql = "SELECT * from lib_subacctcode WHERE Account_Code like '" & dracct & "' AND SubAccount_Code like '" & drsubacct & "'"
                Dim cmdsqlsub = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn4)
                Dim readersub As MySql.Data.MySqlClient.MySqlDataReader = cmdsqlsub.ExecuteReader
                While readersub.Read
                    If Me.ToCCode.Text = "AISC" Then
                        Me.dtgBankEntry.Rows.Add("", reader.Item("Account_Code"), reader.Item("Account_Title"), Format$(CDbl(totalamt), "n2"), "0.00", readersub.Item("SubAccount_Code"), readersub.Item("SubAccount_Title"), False, "", False, "", "")
                    Else
                        Me.dtgBankEntry.Rows.Add("", 1320, "Advances to Affiliates", Format$(CDbl(totalamt), "n2"), "0.00", 1, "Fund Transfer", 0, "", 1, "Affiliates", Me.txtToBankAcct.Text & " " & Me.txtToAcct.Text)
                    End If
                End While
                cmdsqlsub.Dispose()
                readersub.Close()
                cnn4.Close()
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn3.Close()

        If cracct = "" And Me.txtAmt.Text <> "" Then
            Me.dtgBankEntry.Rows.Add("", 2310, "Advances from Affiliates", "0.00", Format$(CDbl(totalamt), "n2"), 1, "Fund Transfer", 0, "", 1, "Affiliates", Me.txtFromBankAcct.Text & " " & Me.txtFromAcct.Text)
        End If
        strsql = "SELECT * from lib_acctcode WHERE Account_Code like '" & cracct & "'"
        Dim cnn5 As New MySqlConnection(strDBMaster)
        If cnn5.State <> ConnectionState.Open Then cnn5.Open()
        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn5)
        reader = cmdsql.ExecuteReader
        While reader.Read
            If Me.txtAmt.Text <> "" Then
                Dim cnn6 As New MySqlConnection(strDBMaster)
                If cnn6.State <> ConnectionState.Open Then cnn6.Open()
                strsql = "SELECT * from lib_subacctcode WHERE Account_Code like '" & cracct & "' AND SubAccount_Code like '" & crsubacct & "'"
                Dim cmdsqlsub = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn6)
                Dim readersub As MySql.Data.MySqlClient.MySqlDataReader = cmdsqlsub.ExecuteReader
                While readersub.Read
                    If Me.fromCCode.Text = "AISC" Then
                        Me.dtgBankEntry.Rows.Add("", reader.Item("Account_Code"), reader.Item("Account_Title"), "0.00", Format$(CDbl(totalamt), "n2"), readersub.Item("SubAccount_Code"), readersub.Item("SubAccount_Title"), False, "", False, "", "")
                    Else
                        Me.dtgBankEntry.Rows.Add("", 2310, "Advances from Affiliates", "0.00", Format$(CDbl(totalamt), "n2"), 1, "Fund Transfer", 0, "", 1, "Affiliates", Me.txtFromBankAcct.Text & " " & Me.txtFromAcct.Text)
                    End If
                End While
                cmdsqlsub.Dispose()
                readersub.Close()
                cnn6.Close()
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn5.Close()
    End Sub

    Private Sub GetSavingsEntry()
        Me.dtgBankEntry.Rows.Clear()
        If Me.txtFromBankAcct.Text = "" And Me.txtToBankAcct.Text = "" Then
            Exit Sub
        End If
        Dim totalamt As Double = 0
        If Me.txtAmt.Text <> "" And Me.txtExRate.Text <> "" Then
            totalamt = CDbl(Me.txtAmt.Text) * CDbl(Me.txtExRate.Text)
        End If
        Dim dracct As String = "", drsubacct As String = ""
        Dim cracct As String = "", crsubacct As String = ""
        Dim strsql As String = "SELECT * from lib_bank WHERE Name like '" & Me.txtFromBankAcct.Text & "' AND Active = True"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            If Me.txtFromBankAcct.Text <> "" Then
                dracct = reader.Item("Account_Code")
                drsubacct = reader.Item("SubAccount_Code")
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn.Close()

        strsql = "SELECT * from lib_bank WHERE Name like '" & Me.txtToBankAcct.Text & "' AND Active = True"
        Dim cnn2 As New MySqlConnection(strDBMaster)
        If cnn2.State <> ConnectionState.Open Then cnn2.Open()
        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn2)
        reader = cmdsql.ExecuteReader
        While reader.Read
            If Me.txtFromBankAcct.Text <> "" Then
                cracct = reader.Item("Account_Code")
                crsubacct = reader.Item("SubAccount_Code")
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn2.Close()


        strsql = "SELECT * from lib_acctcode WHERE Account_Code like '" & cracct & "'"
        Dim cnn3 As New MySqlConnection(strDBMaster)
        If cnn3.State <> ConnectionState.Open Then cnn3.Open()
        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn3)
        reader = cmdsql.ExecuteReader
        While reader.Read
            If Me.txtAmt.Text <> "" Then
                Dim cnn4 As New MySqlConnection(strDBMaster)
                If cnn4.State <> ConnectionState.Open Then cnn4.Open()
                strsql = "SELECT * from lib_subacctcode WHERE Account_Code like '" & cracct & "' AND SubAccount_Code like '" & crsubacct & "'"
                Dim cmdsqlsub = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn4)
                Dim readersub As MySql.Data.MySqlClient.MySqlDataReader = cmdsqlsub.ExecuteReader
                While readersub.Read
                    Me.dtgBankEntry.Rows.Add("", reader.Item("Account_Code"), reader.Item("Account_Title"), Format$(CDbl(totalamt), "n2"), "0.00", readersub.Item("SubAccount_Code"), readersub.Item("SubAccount_Title"), False, "", False, "", "")
                End While
                cmdsqlsub.Dispose()
                readersub.Close()
                cnn4.Close()
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn3.Close()

        strsql = "SELECT * from lib_acctcode WHERE Account_Code like '" & dracct & "'"
        Dim cnn5 As New MySqlConnection(strDBMaster)
        If cnn5.State <> ConnectionState.Open Then cnn5.Open()
        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn5)
        reader = cmdsql.ExecuteReader
        While reader.Read
            If Me.txtAmt.Text <> "" Then
                Dim cnn6 As New MySqlConnection(strDBMaster)
                If cnn6.State <> ConnectionState.Open Then cnn6.Open()
                strsql = "SELECT * from lib_subacctcode WHERE Account_Code like '" & dracct & "' AND SubAccount_Code like '" & drsubacct & "'"
                Dim cmdsqlsub = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn6)
                Dim readersub As MySql.Data.MySqlClient.MySqlDataReader = cmdsqlsub.ExecuteReader
                While readersub.Read
                    Me.dtgBankEntry.Rows.Add("", reader.Item("Account_Code"), reader.Item("Account_Title"), "0.00", Format$(CDbl(totalamt), "n2"), readersub.Item("SubAccount_Code"), readersub.Item("SubAccount_Title"), False, "", False, "", "")
                End While
                cmdsqlsub.Dispose()
                readersub.Close()
                cnn6.Close()
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn5.Close()
    End Sub

    Private Function fundNo() As String
        fundNo = ""
        Dim strsql As String, FundCode As Integer = 0

        strsql = "SELECT `Counter` from tbl_counter WHERE Description ='CheckMC_Fund' AND CompanyCode ='" & strCompanyCode & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            FundCode = reader.Item("Counter")
            fundNo = "AISFUND" & Format$(FundCode, "000000").ToString & Format$(GetServerDate, "yy").ToString
        End While
        cmdsql.Dispose()
        reader.Close()

        strsql = "UPDATE tbl_counter SET Counter = '" & (Val(FundCode) + 1) & "' WHERE Description ='CheckMC_Fund' AND CompanyCode ='" & strCompanyCode & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql1.ExecuteNonQuery()
        cmdsql1.Dispose()
    End Function

    Private Sub CVFunding(ByVal cvno As String)
        Dim strsql As String
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        strsql = "UPDATE ft_main SET Fund = @fund, FundBy = @fundby, FundName = @fundname, FundDate = @funddate WHERE RefNo like '" & cvno & "'"
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        With cmdsql.Parameters
            .AddWithValue("@fund", 1)
            .AddWithValue("@fundby", CurrentUser)
            .AddWithValue("@fundname", fundNo)
            .AddWithValue("@funddate", GetServerDate)
        End With
        cmdsql.ExecuteNonQuery()
        cmdsql.Dispose()
        cnn.Close()
    End Sub

    Private Sub FundFT()
        Me.ErrorProvider1.Clear()
        If Me.txtRefNo.Text = "" Then
            Me.TabControl1.SelectedTab = Me.tbOthers
            Me.ErrorProvider1.SetError(Me.txtRefNo, "Please input ref. no.")
            MsgBox("Please input ref. no.", MsgBoxStyle.Critical, "System Message")
            Me.txtRefNo.ReadOnly = False
            Me.dtFT.Enabled = True
            Exit Sub
        ElseIf Me.txtDate.Text = "" Then
            Me.TabControl1.SelectedTab = Me.tbOthers
            Me.ErrorProvider1.SetError(Me.dtFT, "Please input date")
            MsgBox("Please input date", MsgBoxStyle.Critical, "System Message")
            Exit Sub
        End If
        Me.txtRefNo.ReadOnly = True
        Me.dtFT.Enabled = False
        Me.ErrorProvider1.Clear()
        If MsgBox("Do you want to fund " & Me.lblCVNbr.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Funding...") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim cvnum As String = Me.lblCVNbr.Text
        CVFunding(cvnum)
        Me.txtFundedBy.Text = strCurrentUser
        Me.txtFundedDate.Text = Format$(GetServerDate, "Short Date")
        Me.chkFunded.Checked = True
        MsgBox("Funded!", MsgBoxStyle.Information, "Funded...")
        ChangeEnabledButtons(True, False, False, False, True, True, True, True, True, False)
        'EnableButtons(True, False, False, False, False, True, False, True, True, False)
    End Sub

    Private Sub SaveFT()
        Me.ErrorProvider1.Clear()
        If BlankField() = True Then
            Exit Sub
        End If
        If MsgBox("Do you want to save Fund Transfer?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim strsql As String
        If lblCVNbr.Text = "" Then
            'Dim refno As String = "FT" & GetFundTransferNbr() & GetYear()
            Dim refno As String = "FT" & GetCtrlNbr(strCompanyCode, strSiteCode, "FundTransfer")
            Dim cnn2 As New MySqlConnection(strDBMaster)
            If cnn2.State <> ConnectionState.Open Then cnn2.Open()
            strsql = "INSERT INTO ft_main (RefNo, TypeOfTransaction, FromBankCode, ToBankCode, Amount, PrepBy, PrepDate, Remarks, ExRate) " &
                     "VALUES (@refno, @type, @from, @to, @amt, @prepby, @prepdate, @remarks, @exrate)"
            Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn2)
            With cmdsql.Parameters
                .AddWithValue("@refno", CStr(refno))
                .AddWithValue("@type", CStr(IIf(Me.rdSavings.Checked = True, "ftsavings", "ftaffiliates")))
                .AddWithValue("@from", CStr(Me.txtFromBankCode.Text))
                .AddWithValue("@to", CStr(Me.txtToBankCode.Text))
                .AddWithValue("@amt", CDbl(Me.txtAmt.Text))
                .AddWithValue("@prepby", CStr(strCurrentUser))
                .AddWithValue("@prepdate", CDate(GetServerDate()))
                .AddWithValue("@remarks", CStr(Me.txtRemarks.Text))
                .AddWithValue("@exrate", CDbl(Me.txtExRate.Text))
            End With
            cmdsql.ExecuteNonQuery()
            cmdsql.Dispose()
            cnn2.Close()
            Me.lblCVNbr.Text = refno
        ElseIf lblCVNbr.Text <> "" Then
            Dim cnn2 As New MySqlConnection(strDBMaster)
            If cnn2.State <> ConnectionState.Open Then cnn2.Open()
            strsql = "UPDATE ft_main SET TypeOfTransaction = @type, FromBankCode = @from, ToBankCode = @To, Amount = @amt, Remarks = @remarks, ExRate = @exrate " &
                     "WHERE RefNo like @refno"
            Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn2)
            With cmdsql.Parameters
                .AddWithValue("@refno", CStr(Me.lblCVNbr.Text))
                .AddWithValue("@type", CStr(IIf(Me.rdSavings.Checked = True, "ftsavings", "ftaffiliates")))
                .AddWithValue("@from", CStr(Me.txtFromBankCode.Text))
                .AddWithValue("@to", CStr(Me.txtToBankCode.Text))
                .AddWithValue("@amt", CDbl(Me.txtAmt.Text))
                .AddWithValue("@remarks", CStr(Me.txtRemarks.Text))
                .AddWithValue("@exrate", CDbl(Me.txtExRate.Text))
            End With
            cmdsql.ExecuteNonQuery()
            cmdsql.Dispose()
            cnn2.Close()
        End If

        strsql = "DELETE from ft_acctg_entry WHERE RefNo like '" & Me.lblCVNbr.Text & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        cmdsql1.ExecuteNonQuery()
        cmdsql1.Dispose()
        cnn.Close()

        For z As Integer = 0 To dtgBankEntry.Rows.Count - 1
            Dim cnn2 As New MySqlConnection(strDBMaster)
            If cnn2.State <> ConnectionState.Open Then cnn2.Open()
            strsql = "INSERT INTO ft_acctg_entry (RefNo, AcctCode, SubAcctCode, DR, CR, Dept, DeptName, List, ListItem, ListItemName) " &
                 "VALUES (@RefNo, @AcctCode, @SubAcctCode, @DR, @CR, @Dept, @DeptName, @List, @ListItem, @ListItemName)"
            cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn2)
            With cmdsql1.Parameters
                .AddWithValue("@RefNo", CStr(Me.lblCVNbr.Text))
                .AddWithValue("@AcctCode", CStr(dtgBankEntry.Rows(z).Cells(1).Value))
                .AddWithValue("@DR", CDbl(dtgBankEntry.Rows(z).Cells(3).Value))
                .AddWithValue("@CR", CDbl(dtgBankEntry.Rows(z).Cells(4).Value))
                .AddWithValue("@SubAcctCode", CStr(dtgBankEntry.Rows(z).Cells(5).Value))
                .AddWithValue("@Dept", CBool(dtgBankEntry.Rows(z).Cells(7).Value))
                .AddWithValue("@DeptName", CStr(dtgBankEntry.Rows(z).Cells(8).Value))
                .AddWithValue("@List", CBool(dtgBankEntry.Rows(z).Cells(9).Value))
                .AddWithValue("@ListItem", CStr(dtgBankEntry.Rows(z).Cells(10).Value))
                .AddWithValue("@ListItemName", CStr(dtgBankEntry.Rows(z).Cells(11).Value))
            End With
            cmdsql1.ExecuteNonQuery()
            cmdsql1.Dispose()
            cnn.Close()
        Next

        Me.txtPrepBy.Text = strCurrentUser
        Me.txtPrepDate.Text = Format$(GetServerDate, "Short Date")
        MsgBox("Saved!", MsgBoxStyle.Information, "System Message")
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        'EnableButtons(True, True, False, False, True, False, True, True, True, False)
    End Sub

    Private Function SelectBankName(ByVal bankcode As String) As String
        SelectBankName = ""
        Dim strsql As String = "SELECT * from tbl_vendor WHERE Code like '" & bankcode & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            SelectBankName = reader.Item("Description")
        End While
        cnn.Close()
        reader.Close()
        cmdsql.Dispose()
    End Function

    Private Function BlankField() As Boolean
        BlankField = False
        If Me.txtFromBankCode.Text = "" Then
            MsgBox("Please choose a bank from which the amount will be coming.", MsgBoxStyle.Critical, "System Message")
            BlankField = True
        ElseIf Me.txtToBankCode.Text = "" Then
            MsgBox("Please choose a bank to which the amount will be transferred.", MsgBoxStyle.Critical, "System Message")
            BlankField = True
        ElseIf CStr(Me.txtAmt.Text) = "" Then
            MsgBox("Please enter your desired amount.", MsgBoxStyle.Critical, "System Message")
            BlankField = True
        ElseIf CDbl(Me.txtAmt.Text) = 0 Then
            MsgBox("Please enter your desired amount.", MsgBoxStyle.Critical, "System Message")
            BlankField = True
        ElseIf Me.txtRemarks.Text = "" Then
            MsgBox("Please indicate the details on the OTHERS tab.", MsgBoxStyle.Critical, "System Message")
            BlankField = True
        End If
    End Function

    Private Sub clr()
        'rdSavings.Checked = False
        'rdAffiliates.Checked = False
        lblCVNbr.Text = ""
        fromCCode.Text = ""
        ToCCode.Text = ""
        txtFromAcct.Text = ""
        txtToAcct.Text = ""
        txtFromBankCode.Text = ""
        txtFromBankAcct.Text = ""
        txtToBankCode.Text = ""
        txtToBankAcct.Text = ""
        txtAmt.Text = 0
        txtAmtInWords.Text = ""
        txtPrepBy.Text = ""
        txtPrepDate.Text = ""
        txtPostedBy.Text = ""
        txtPostedDate.Text = ""
        chkPosted.Checked = False
        txtFundedBy.Text = ""
        txtFundedDate.Text = ""
        chkFunded.Checked = False
        txtCancelledBy.Text = ""
        txtCancelledDate.Text = ""
        chkCancelled.Checked = False
        txtRemarks.Text = ""
        txtRefNo.Text = ""
        txtDate.Text = ""
        txtExRate.Text = 1
        dtgBankEntry.Rows.Clear()
    End Sub

    Private Sub txtAmt_TextChanged(sender As Object, e As EventArgs) Handles txtAmt.TextChanged
        Dim j As Integer
        Dim C As String
        Dim x As Integer

        If Me.txtAmt.Text = "" Then
            Me.txtAmt.Text = 0
            Exit Sub
        End If

        x = 0
        For j = 1 To Len(txtAmt.Text)
            C = Mid$(txtAmt.Text, j, 1)
            If Not IsNumeric(C) Then
                If C = "." Then
                    Exit For
                End If
                txtAmt.Text = Replace$(txtAmt.Text, C, "")
                txtAmt.SelectionStart = Len(txtAmt.Text)
            End If
        Next

        If Me.txtExRate.Text <> "" And Me.txtAmt.Text <> "" Then
            Me.txtAmtInWords.Text = English(CDbl(Me.txtExRate.Text) * CDbl(Me.txtAmt.Text))
            Me.txtTotalAmt.Text = CDbl(Me.txtExRate.Text) * CDbl(Me.txtAmt.Text)
        End If

        If rdSavings.Checked = True Then
            GetSavingsEntry()
        ElseIf rdAffiliates.Checked = True Then
            GetAffiliatesEntry()
        End If
    End Sub

    Private Sub cmdFund_Click(sender As Object, e As EventArgs) Handles cmdFund.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_Funding") = False Then
        '    MsgBox("You are not allowed to Release", vbInformation, "System Message")
        '    Exit Sub
        'End If
        If lblCVNbr.Text = "" Then
            MsgBox("Nothing to fund.", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If
        FundFT()
    End Sub

    Private Sub btnFrom_Click(sender As Object, e As EventArgs) Handles btnFrom.Click
        frmManageBank.Text = "Fund Transfer"
        frmManageBank.Tag = "From"
        frmManageBank.ShowDialog()

        If rdSavings.Checked = True Then
            GetSavingsEntry()
        ElseIf rdAffiliates.Checked = True Then
            GetAffiliatesEntry()
        End If
        Me.fromCCode.Text = GetCompanyCode(txtFromBankAcct.Text)
        Me.txtFromAcct.Text = GetAcctNbr(txtFromBankAcct.Text)
    End Sub

    Private Sub btnTo_Click(sender As Object, e As EventArgs) Handles btnTo.Click
        frmManageBank.Text = "Fund Transfer"
        frmManageBank.Tag = "To"
        frmManageBank.ShowDialog()
        If rdSavings.Checked = True Then
            GetSavingsEntry()
        ElseIf rdAffiliates.Checked = True Then
            GetAffiliatesEntry()
        End If
        Me.ToCCode.Text = GetCompanyCode(txtToBankAcct.Text)
        Me.txtToAcct.Text = GetAcctNbr(txtToBankAcct.Text)
    End Sub

    Private Sub txtFromBankCode_TextChanged(sender As Object, e As EventArgs) Handles txtFromBankCode.TextChanged
        txtFromBankAcct.Text = SelectBankName(txtFromBankCode.Text)
    End Sub

    Private Sub txtToBankCode_TextChanged(sender As Object, e As EventArgs) Handles txtToBankCode.TextChanged
        txtToBankAcct.Text = SelectBankName(txtToBankCode.Text)
    End Sub

    Private Sub rdSavings_CheckedChanged(sender As Object, e As EventArgs) Handles rdSavings.CheckedChanged

    End Sub

    Private Sub rdSavings_Click(sender As Object, e As EventArgs) Handles rdSavings.Click
        If rdSavings.Checked = True Then
            GetSavingsEntry()
            clr()
        ElseIf rdAffiliates.Checked = True Then
            GetAffiliatesEntry()
        End If
    End Sub

    Private Sub rdAffiliates_CheckedChanged(sender As Object, e As EventArgs) Handles rdAffiliates.CheckedChanged

    End Sub

    Private Sub rdAffiliates_Click(sender As Object, e As EventArgs) Handles rdAffiliates.Click
        If rdSavings.Checked = True Then
            GetSavingsEntry()
        ElseIf rdAffiliates.Checked = True Then
            GetAffiliatesEntry()
            clr()
        End If
    End Sub

    Private Sub btAdvanceSearch_Click(sender As Object, e As EventArgs) Handles btAdvanceSearch.Click
        frmSearchFT.ShowDialog()
    End Sub

    Private Sub dtFT_ValueChanged(sender As Object, e As EventArgs) Handles dtFT.ValueChanged
        Me.txtDate.Text = Format$(dtFT.Value, "Short Date")
    End Sub

    Private Sub txtExRate_TextChanged(sender As Object, e As EventArgs) Handles txtExRate.TextChanged
        Dim j As Integer
        Dim C As String
        Dim x As Integer

        If Me.txtExRate.Text = "" Then
            Me.txtExRate.Text = 1
            Exit Sub
        End If

        x = 0
        For j = 1 To Len(txtExRate.Text)
            C = Mid$(txtExRate.Text, j, 1)
            If Not IsNumeric(C) Then
                If C = "." Then
                    Exit For
                End If
                txtExRate.Text = Replace$(txtExRate.Text, C, "")
                txtExRate.SelectionStart = Len(txtExRate.Text)
            End If
        Next

        If Me.txtExRate.Text <> "" And Me.txtAmt.Text <> "" Then
            Me.txtAmtInWords.Text = English(CDbl(Me.txtExRate.Text) * CDbl(Me.txtAmt.Text))
            Me.txtTotalAmt.Text = CDbl(Me.txtExRate.Text) * CDbl(Me.txtAmt.Text)
        End If

        If rdSavings.Checked = True Then
            GetSavingsEntry()
        ElseIf rdAffiliates.Checked = True Then
            GetAffiliatesEntry()
        End If
    End Sub

    Private Sub cboReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReport.SelectedIndexChanged
        If Me.cboReport.SelectedIndex = -1 Then Exit Sub
        Select Case Me.cboReport.Text
            Case "Online"
                'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_PrintVoucher") = False Then
                '    MsgBox("You are not allowed to Print Fund Transfer", vbInformation, "System Message")
                '    Exit Sub
                'End If
                frmPrintPreview.FundTransferOnline()
                frmPrintPreview.ShowDialog()
            Case "Offline"
                'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_PrintVoucher") = False Then
                '    MsgBox("You are not allowed to Print Fund Transfer", vbInformation, "System Message")
                '    Exit Sub
                'End If
                frmPrintPreview.FundTransferOffline()
                frmPrintPreview.ShowDialog()
        End Select
    End Sub


    'Private Sub OnlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnlineToolStripMenuItem.Click
    'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_PrintVoucher") = False Then
    '    MsgBox("You are not allowed to Print Fund Transfer", vbInformation, "System Message")
    '    Exit Sub
    'End If
    'frmPrintReport.Text = Me.Text
    'frmPrintReport.Tag = "Fund Transfer Online"
    'frmPrintReport.ShowDialog()
    'End Sub

    'Private Sub OfflineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OfflineToolStripMenuItem.Click
    'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_PrintVoucher") = False Then
    '    MsgBox("You are not allowed to Print Fund Transfer", vbInformation, "System Message")
    '    Exit Sub
    'End If
    'frmPrintReport.Text = Me.Text
    'frmPrintReport.Tag = "Fund Transfer Offline"
    'frmPri
    'End Sub
End Class