Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmAdvances

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

            Me.cboClient.Enabled = blUserInput
            Me.gbAR.Enabled = blUserInput
            Me.gbPayment.Enabled = blUserInput

            .UpdateEnabledButtons()
        End With
    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        Throw New NotImplementedException()
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If MsgBox("Do you want to save advances?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If
        If SaveEntry() = False Then
            Exit Sub
        End If
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        Throw New NotImplementedException()
    End Sub

    Private Sub frmAdvances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        strMod = "Exp"
        clr()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        FillComboBox(Me.cboBank, "SELECT Name FROM lib_bank WHERE Active = 1 ORDER BY Name", "Name")
        FillComboBox(Me.cboClient, "Select Description from tbl_client where Description is not null", "Description")
    End Sub

    Private Sub frmAdvances_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Dim strMod As String

    Private Sub clr()
        dtgAcctgTitle.Rows.Clear()
        txtCashAmt.Text = ""
        txtChkAmt.Text = ""
        cboBank.SelectedIndex = -1
        txtChkNo.Text = ""
        tslblPrepBy.Text = ""
        tslblPrepDate.Text = ""
        tslblStatus.Text = ""
    End Sub

    Private Sub ComputeDRCR()
        Dim dblDR As Double = 0
        Dim dblCR As Double = 0

        For intRow = 0 To Me.dtgAcctgTitle.Rows.Count - 1
            With Me.dtgAcctgTitle.Rows(intRow)
                dblDR = dblDR + CDbl(.Cells(9).Value)
                dblCR = dblCR + CDbl(.Cells(10).Value)
            End With
        Next

        Me.txtDRTotal.Text = Format$(dblDR, "n2")
        Me.txtCRTotal.Text = Format$(dblCR, "n2")
    End Sub

    Private Sub PopdtgAcctgEntry()
        'If Me.dtgPayments.Rows.Count = 0 Then Exit Sub
        If txtCashAmt.Text = "" Then txtCashAmt.Text = 0
        If txtChkAmt.Text = "" Then txtChkAmt.Text = 0

        Dim dblCash As Double = 0
        Dim dblCheck As Double = 0

        Me.dtgAcctgTitle.Rows.Clear()

        If IsNumeric(Me.txtCashAmt.Text) = True Or IsNumeric(Me.txtChkAmt.Text) = True Then
            If CDbl(Me.txtCashAmt.Text) > 0 And chkBank.Checked = False Then
                PopdtgAcctgEntryRow("1010", "2", CDbl(Me.txtCashAmt.Text), "0.00")
            ElseIf CDbl(Me.txtChkAmt.Text) > 0 And chkBank.Checked = False Then
                PopdtgAcctgEntryRow("1120", "1", CDbl(Me.txtChkAmt.Text), "0.00")
            ElseIf CDbl(Me.txtChkAmt.Text) > 0 Or (CDbl(Me.txtCashAmt.Text) > 0 And chkBank.Checked = True) Then
                Dim strsql As String = "SELECT * from lib_bank WHERE Name like '" & cboBank.Text & "' AND Active = 1"

                Dim cnn As New MySqlConnection(strDBMaster)
                If cnn.State <> ConnectionState.Open Then cnn.Open()
                Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
                Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
                While reader.Read
                    PopdtgAcctgEntryRow(reader.Item("Account_Code"), reader.Item("SubAccount_Code"), CDbl(Me.txtChkAmt.Text) + CDbl(Me.txtCashAmt.Text), "0.00")
                End While
                cmdsql.Dispose()
                reader.Close()
                cnn.Close()
            End If
        End If

        If Me.txtCashAmt.Text > 0 Or Me.txtChkAmt.Text > 0 Then
            Dim x As Double = 0
            For i As Integer = 0 To dtgAcctgTitle.Rows.Count - 1
                With dtgAcctgTitle.Rows(i)
                    x = x + .Cells(9).Value
                End With
            Next
            If optExp.Checked = True Then
                PopdtgAcctgEntryRow("1150", "2", "0.00", x)
            Else
                PopdtgAcctgEntryRow("1150", "1", "0.00", x)
            End If
        End If

        ComputeDRCR()
    End Sub

    Private Sub PopdtgAcctgEntryRow(ByVal strCode As String, ByVal strSubCode As String, ByVal dblDR As Double, ByVal dblCR As Double)
        Dim strsql As String = "SELECT lib_acctcode.*, lib_subacctcode.* FROM lib_acctcode LEFT JOIN lib_subacctcode ON lib_acctcode.Account_Code = lib_subacctcode.Account_Code" &
                                " WHERE lib_acctcode.Account_Code = '" & strCode & "' AND lib_subacctcode.SubAccount_Code = '" & strSubCode & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnn)

        Dim reader As MySqlDataReader = cmdsql.ExecuteReader
        Dim strDept As String, strList As String, strShip As String

        strShip = ""
        strList = ""
        strDept = ""

        While reader.Read
            If reader.Item("SubAccount_Dept") = True Then
                If Me.optExp.Checked = True Then
                    strDept = "Export"
                ElseIf Me.optImpB.Checked = True Then
                    strDept = "Brokerage"
                Else
                    strDept = "Import Forwarding"
                End If
            End If


            If reader.Item("SubAccount_List") = True Then
                strList = reader.Item("SubAccount_ListItem")
                If strList = "Client" Then
                    strShip = Me.cboClient.Text
                ElseIf strList = "Local and Government Agency" Then
                    strShip = "Bureau of Internal Revenue"
                End If
            End If

            Me.dtgAcctgTitle.Rows.Add(reader.Item("Account_Code"), reader.Item("Account_Title"), reader.Item("SubAccount_Code"), reader.Item("SubAccount_Title"), CBool(reader.Item("SubAccount_Dept")), strDept, CBool(reader.Item("SubAccount_List")), strList, strShip, Format$(CDbl(dblDR), "n2"), Format$(CDbl(dblCR), "n2"), strSubCode)
        End While

        reader.Close()
        cmdsql.Dispose()
    End Sub

    Private Sub txtCashAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCashAmt.TextChanged
        AlphaRestriction(txtCashAmt)
        PopdtgAcctgEntry()
    End Sub

    Private Sub txtChkAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChkAmt.TextChanged
        AlphaRestriction(txtChkAmt)
        PopdtgAcctgEntry()
    End Sub

    Private Sub cboClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClient.SelectedIndexChanged
        PopdtgAcctgEntry()
        loadBookingNos()
    End Sub

    Private Sub cboBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBank.SelectedIndexChanged
        PopdtgAcctgEntry()
    End Sub

    Private Sub optExp_CheckedChanged(sender As Object, e As EventArgs) Handles optExp.CheckedChanged

    End Sub

    Private Sub optExp_Click(sender As Object, e As EventArgs) Handles optExp.Click
        clr()
        strMod = "Exp"
        FillComboBox(Me.cboClient, "Select Description from tbl_client where Description is not null", "Description")

    End Sub

    Private Sub optImpB_CheckedChanged(sender As Object, e As EventArgs) Handles optImpB.CheckedChanged

    End Sub

    Private Sub optImpB_Click(sender As Object, e As EventArgs) Handles optImpB.Click
        clr()
        strMod = "ImpB"
        FillComboBox(Me.cboClient, "Select Description from tbl_client where Description is not null", "Description")

    End Sub

    Private Sub optImpF_CheckedChanged(sender As Object, e As EventArgs) Handles optImpF.CheckedChanged

    End Sub

    Private Sub optImpF_Click(sender As Object, e As EventArgs) Handles optImpF.Click
        clr()
        strMod = "ImpF"
        FillComboBox(Me.cboClient, "Select Description from tbl_client where Description is not null", "Description")
    End Sub

    Private Function BlankEntries() As Boolean
        BlankEntries = False
        If cboClient.Text = "" Then
            BlankEntries = True
            MsgBox("Please choose a client!", MsgBoxStyle.Exclamation, "System Message")
        ElseIf txtARNo.Text = "" Then
            BlankEntries = True
            MsgBox("AR no. needed!", MsgBoxStyle.Exclamation, "System Message")
        ElseIf cboBooking.Text = "" Then
            BlankEntries = True
            MsgBox("Please choose a booking no.!", MsgBoxStyle.Exclamation, "System Message")
        ElseIf txtCashAmt.Text = 0 And txtChkAmt.Text = 0 Then
            BlankEntries = True
            MsgBox("Please enter amount in either cash or check!", MsgBoxStyle.Exclamation, "System Message")
        ElseIf txtChkAmt.Text <> 0 Then
            If txtChkNo.Text = "" Then
                BlankEntries = True
                MsgBox("Please indicate the check no.!", MsgBoxStyle.Exclamation, "System Message")
            ElseIf cboBank.Text = "" Then
                BlankEntries = True
                MsgBox("Please choose a bank!", MsgBoxStyle.Exclamation, "System Message")
            End If
        Else
            Dim strsql As String = "SELECT * from ar_main where ORNo like '" & Me.txtARNo.Text & "'"
            Dim cnn As New MySqlConnection(strDBMaster)

            If cnn.State <> ConnectionState.Open Then cnn.Open()
            Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
            While reader.Read
                BlankEntries = True
            End While
            cmdsql.Dispose()
            reader.Close()
            cnn.Close()

            strsql = "SELECT * from ar_adv_main where ARNo like '" & Me.txtARNo.Text & "'"
            If cnn.State <> ConnectionState.Open Then cnn.Open()
            cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
            reader = cmdsql.ExecuteReader
            While reader.Read
                BlankEntries = True
            End While
            cmdsql.Dispose()
            reader.Close()
            cnn.Close()

            If BlankEntries = True Then
                MsgBox("AR No already used!", MsgBoxStyle.Exclamation, "System Message")
            End If
        End If
    End Function

    Private Function SaveEntry() As Boolean
        SaveEntry = True
        Dim strsql As String = ""
        PopdtgAcctgEntry()
        If BlankEntries() = True Then
            SaveEntry = False
            Exit Function
        End If
        strsql = "INSERT INTO ar_adv_main (ARNo, Module, Client, BkgNbr, CashAmt, CheckAmt, CheckNo, Bankname, TotalAmt, Balance, PrepBy, PrepDate, Posted, PostBy, PostDate) " &
                 "VALUES (@arno, @mod, @client, @bkgnbr, @cashamt, @checkamt, @checkno, @bank, @total, @bal, @prepby, @prepdate, @post, @postby, @postdate)"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        With cmdsql.Parameters
            .AddWithValue("@arno", CStr(Me.txtARNo.Text))
            .AddWithValue("@mod", CStr(strMod))
            .AddWithValue("@client", CStr(Me.cboClient.Text))
            .AddWithValue("@bkgnbr", CStr(Me.cboBooking.Text))
            .AddWithValue("@cashamt", CDbl(Me.txtCashAmt.Text))
            .AddWithValue("@checkamt", CDbl(Me.txtChkAmt.Text))
            .AddWithValue("@checkno", CStr(Me.txtChkNo.Text))
            .AddWithValue("@bank", CStr(Me.cboBank.Text))
            .AddWithValue("@total", CDbl(Me.txtCRTotal.Text))
            .AddWithValue("@bal", CDbl(Me.txtDRTotal.Text))
            .AddWithValue("@prepby", strCurrentUser)
            .AddWithValue("@prepdate", CDate(GetServerDate()))
            .AddWithValue("@post", 1)
            .AddWithValue("@postby", strCurrentUser)
            .AddWithValue("@postdate", CDate(GetServerDate()))
        End With
        cmdsql.ExecuteNonQuery()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        For i As Integer = 0 To dtgAcctgTitle.Rows.Count - 1
            strsql = "INSERT INTO ar_adv_acctg_entry (ARNo, AcctCode, SubAcctCode, SubAcctDept, SubAcctDeptName, SubAcctList, SubAcctListItem, SubAcctListItemName, DR, CR) " &
                     "VALUES (@arno, @acctcode, @subacctcode, @subacctdept, @subacctdeptname, @subacctlist, @subacctlistitem, @subacctlistitemname, @dr, @cr)"
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
            With cmdsql.Parameters
                .AddWithValue("@arno", CStr(Me.txtARNo.Text))
                .AddWithValue("@acctcode", CStr(dtgAcctgTitle.Rows(i).Cells("acctcode").Value))
                .AddWithValue("@subacctcode", CStr(dtgAcctgTitle.Rows(i).Cells("subacctcode").Value))
                .AddWithValue("@subacctdept", CBool(dtgAcctgTitle.Rows(i).Cells("subacctdept").Value))
                .AddWithValue("@subacctdeptname", CStr(dtgAcctgTitle.Rows(i).Cells("subacctdeptname").Value))
                .AddWithValue("@subacctlist", CBool(dtgAcctgTitle.Rows(i).Cells("subacctlist").Value))
                .AddWithValue("@subacctlistitem", CStr(dtgAcctgTitle.Rows(i).Cells("subacctlistitem").Value))
                .AddWithValue("@Subacctlistitemname", CStr(dtgAcctgTitle.Rows(i).Cells("Subacctlistitemname").Value))
                .AddWithValue("@dr", CDbl(dtgAcctgTitle.Rows(i).Cells("dr").Value))
                .AddWithValue("@cr", CDbl(dtgAcctgTitle.Rows(i).Cells("cr").Value))
            End With
            cmdsql.ExecuteNonQuery()
            cmdsql.Dispose()
            cnnDBMaster.Close()
        Next

        tslblPrepBy.Text = strCurrentUser
        tslblPrepDate.Text = CDate(GetServerDate())
        tslblStatus.Text = "Posted"
        MsgBox("AR Saved!", MsgBoxStyle.Information, "System Message")
    End Function
    Public Sub AlphaRestriction(ByVal txt As TextBox)
        Dim i As Integer
        Dim C As String

        For i = 1 To Len(txt.Text)
            C = Mid$(txt.Text, i, 1)
            If Not IsNumeric(C) Then
                If C = "." Then
                    Exit For
                End If
                txt.Text = Replace$(txt.Text, C, "")
                txt.SelectionStart = Len(txt.Text)
            End If
        Next
    End Sub
    Private Sub chkBank_CheckedChanged(sender As Object, e As EventArgs) Handles chkBank.CheckedChanged
        PopdtgAcctgEntry()
    End Sub

    Private Sub loadBookingNos()
        cboBooking.Items.Clear()
        Dim strsql As String = ""
        If strMod = "Exp" Then
            strsql = "SELECT * from v_exportbookingheader  WHERE ConsignorName like @clientname"
            Dim cnn As New MySqlConnection(strDBMaster)
            If cnn.State <> ConnectionState.Open Then cnn.Open()
            Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
            cmdsql.Parameters.AddWithValue("@clientname", Me.cboClient.Text)
            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
            While reader.Read
                Me.cboBooking.Items.Add(reader.Item("BookingNo"))
            End While
            cmdsql.Dispose()
            reader.Close()
            cnn.Close()
        ElseIf strMod = "ImpB" Then
            strsql = "SELECT * from v_importbookingheader WHERE ConsignorName like @clientname"
            Dim cnn As New MySqlConnection(strDBMaster)
            If cnn.State <> ConnectionState.Open Then cnn.Open()
            Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
            cmdsql.Parameters.AddWithValue("@clientname", Me.cboClient.Text)
            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
            While reader.Read
                Me.cboBooking.Items.Add(reader.Item("BookingNo"))
            End While
            cmdsql.Dispose()
            reader.Close()
            cnn.Close()
        Else

        End If
    End Sub

    Private Sub SearchAdvances(ByVal arno As String)
        Dim strsql As String = "SELECT * from ar_adv_main inner join ar_adv_acctg_entry ON ar_adv_main.ARNo = ar_adv_acctg_entry.ARNo WHERE ar_adv_main.ARNo like '" & arno & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader1 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql1.ExecuteReader
        While reader1.Read
            txtARNo.Text = reader1.Item("ARNo")
            Select Case reader1.Item("Module")
                Case "ImpB"
                    optImpB.Checked = True
                Case "ImpF"
                    optImpF.Checked = True
                Case "Exp"
                    optExp.Checked = True
            End Select
            cboClient.Text = reader1.Item("Client")
            loadBookingNos()
            cboBooking.Text = reader1.Item("BkgNbr")
            txtCashAmt.Text = Format$(reader1.Item("CashAmt"), "n2")
            txtChkAmt.Text = Format$(reader1.Item("CheckAmt"), "n2")
            txtChkNo.Text = reader1.Item("CheckNo")
            cboBank.Text = reader1.Item("BankName")

            'AcctgEntry
            'dtgAcctgTitle.Rows.Clear()
            'dtgAcctgTitle.Rows.Add()
        End While
        cmdsql1.Dispose()
        reader1.Close()
        cnn.Close()
    End Sub
End Class