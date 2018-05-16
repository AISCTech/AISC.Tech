Imports MasterProject

Public Class frmBillingAdvances
    '    Implements ICommonFunction
    '    Dim trans As String
    '    Dim useamt As Double
    '    Private EnableButtons As New clsEnableToolstripObjects()
    '    Private Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
    '                                     ByVal blPrintPreview As Boolean, ByVal blSearch As Boolean, ByVal blPost As Boolean,
    '                                     ByVal blCancel As Boolean, ByVal blReOpen As Boolean, ByVal blUserInput As Boolean)
    '        With EnableButtons
    '            .NewEnabled = blNew
    '            .EditEnabled = blEdit
    '            .SaveEnabled = blSave
    '            .ResetEnabled = blReset
    '            .PrintPreviewEnabled = blPrintPreview
    '            .SearchEnabled = blSearch
    '            .PostEnabled = blPost
    '            .CancelEnabled = blCancel
    '            .ReOpen = blReOpen

    '            gbServiceType.Enabled = blUserInput
    '            cboClient.Enabled = blUserInput
    '            'tstxtSearch.Enabled = Not blUserInput
    '            'tscmdSearchOR.Enabled = Not blUserInput

    '            .UpdateEnabledButtons()
    '        End With
    '    End Sub
    '    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
    '        If tslblStatus.Text = "Cancelled" Then
    '            MsgBox("Transaction is already cancelled!", MsgBoxStyle.Exclamation, "System Message")
    '            Exit Sub
    '        End If
    '        If MsgBox("Do you want to cancel this?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.No Then
    '            Exit Sub
    '        End If
    '        Dim strsql As String = "UPDATE ar_adv_vs_billing SET Cancel = @cancel, CancelBy = @cancelby, CancelDate = @canceldate WHERE RefNo like @refno"
    '        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
    '        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
    '        With cmdsql.Parameters
    '            .AddWithValue("@cancel", True)
    '            .AddWithValue("@cancelby", CurrentUser)
    '            .AddWithValue("@canceldate", GetServerDate)
    '            .AddWithValue("@refno", Me.lblRefNo.Text)
    '        End With
    '        cmdsql.ExecuteNonQuery()
    '        cmdsql.Dispose()
    '        cnnDBMaster.Close()

    '        Dim bal As Double = 0, add As Double = 0
    '        For i As Integer = 0 To Me.dgAdvances.Rows.Count - 1
    '            With Me.dgAdvances.Rows(i)
    '                add = 0
    '                bal = .Cells("colUse").Value
    '                strsql = "SELECT * from ar_adv_main WHERE Client like '" & .Cells("colCompany").Value & "' AND ARNo like '" & .Cells("colARNo").Value & "' AND TotalAmt <> Balance ORDER by ARNo"
    '                If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '                cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '                Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
    '                While reader.Read
    '                    If bal >= reader.Item("TotalAmt") - reader.Item("Balance") Then
    '                        add = reader.Item("TotalAmt")
    '                        bal = bal - add - reader.Item("Balance")
    '                    ElseIf bal < reader.Item("TotalAmt") - reader.Item("Balance") Then
    '                        add = bal + reader.Item("Balance")
    '                        bal = 0
    '                    End If
    '                    strsql = "UPDATE ar_adv_main SET Balance = @balance WHERE ARNo like @arno"
    '                    If connAcctg2.State <> ConnectionState.Open Then connAcctg2.Open()
    '                    Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg2)
    '                    With cmdsql1.Parameters
    '                        .AddWithValue("@balance", add)
    '                        .AddWithValue("@arno", reader.Item("ARNo"))
    '                    End With
    '                    cmdsql1.ExecuteNonQuery()
    '                    cmdsql1.Dispose()
    '                    connAcctg2.Close()
    '                End While
    '                cmdsql.Dispose()
    '                reader.Close()
    '                connAcctg.Close()
    '            End With
    '        Next
    '        MsgBox("Transaction cancelled!", MsgBoxStyle.Information, "System Message")
    '        EnableObjects(True, False, True, False, False, False)
    '        tslblStatus.Text = "Cancelled"
    '    End Sub

    '    Public Sub EditRecord() Implements ICommonFunction.EditRecord
    '        If tslblStatus.Text = "Cancelled" Then
    '            MsgBox("Cannot edit. Transaction is cancelled!", MsgBoxStyle.Exclamation, "System Message")
    '            Exit Sub
    '        End If
    '        enablefields(False)
    '        EnableObjects(False, False, True, True, False, False)
    '    End Sub

    '    Public Sub NewRecord() Implements ICommonFunction.NewRecord
    '        If MsgBox("Do you want to create new transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.No Then
    '            Exit Sub
    '        End If
    '        clr()
    '        enablefields(True)
    '        EnableObjects(False, False, True, True, False, False)
    '    End Sub

    '    Public Sub PostRecord() Implements ICommonFunction.PostRecord
    '        Throw New NotImplementedException()
    '    End Sub

    '    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
    '        Throw New NotImplementedException()
    '    End Sub

    '    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
    '        Throw New NotImplementedException()
    '    End Sub

    '    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
    '        clr()
    '        enablefields(False)
    '        EnableObjects(True, False, True, False, False, False)
    '    End Sub

    '    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
    '        SaveEntry()
    '    End Sub

    '    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
    '        Throw New NotImplementedException()
    '    End Sub

    '    Private Sub frmBillingAdvances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '        lblAllowed.BackColor = OpenColorCode
    '        lblNotAllowed.BackColor = CancelledColorCode
    '        EnableObjects(True, False, True, False, False, False)
    '    End Sub

    '    Private Sub frmBillingAdvances_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    '        EnableButtons.UpdateEnabledButtons()
    '    End Sub

    '    Private Sub clr()
    '        Me.cboClient.SelectedIndex = -1
    '        lblRefNo.Text = ""
    '        dgBilling.Rows.Clear()
    '        dgAdvances.Rows.Clear()
    '        tslblPrepBy.Text = ""
    '        tslblPrepDate.Text = ""
    '        tslblStatus.Text = ""
    '        totalAdvUsed()
    '        totalSOAAmt()
    '    End Sub


    '    Private Sub loadAdvances(ByVal client As String)
    '        dgAdvances.Rows.Clear()
    '        Dim strsql As String = ""
    '        Dim groupno As Integer = 0
    '        Dim bal As Double = 0
    '        Dim shipper As String = ""
    '        If trans = "Impf" Then

    '        Else
    '            If connExport.State <> ConnectionState.Open Then connExport.Open()
    '            strsql = "SELECT * from SHP WHERE SHP_ClientName like '" & client & "'"
    '            Dim cmdsql = New OleDb.OleDbCommand(strsql, connExport)
    '            Dim reader As OleDb.OleDbDataReader = cmdsql.ExecuteReader
    '            While reader.Read
    '                If reader.Item("SHP_Group") = True Then
    '                    groupno = reader.Item("SHP_GroupNo")
    '                End If
    '            End While
    '            cmdsql.Dispose()
    '            reader.Close()
    '            'connExport.Close()
    '            shipper = "SHP_ClientName"
    '        End If
    '        If groupno <> 0 Then
    '            If connExport.State <> ConnectionState.Open Then connExport.Open()
    '            strsql = "SELECT * from SHP WHERE SHP_GroupNo like '" & groupno & "'"
    '            Dim cmdsql = New OleDb.OleDbCommand(strsql, connExport)
    '            Dim reader As OleDb.OleDbDataReader = cmdsql.ExecuteReader
    '            While reader.Read
    '                strsql = "SELECT * FROM (ap_apv INNER JOIN ap_crp ON ap_apv.APV_ReqNo = ap_crp.CRP_Nbr) INNER JOIN lib_vendor ON ap_crp.CRP_PayeeID = lib_vendor.VendorID WHERE ap_crp.CRP_PONbr like 'ADVANCES' AND ap_apv.APV_Cancel = False AND lib_vendor.VendorName like '" & reader.Item(shipper) & "'"
    '                If connAcctg2.State <> ConnectionState.Open Then connAcctg2.Open()
    '                Dim cmdsql3 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg2)
    '                Dim reader3 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql3.ExecuteReader
    '                While reader3.Read
    '                    'MsgBox(reader3.Item("APV_Nbr"))
    '                    bal = reader3.Item("CRP_TotalAmt") + bal
    '                    strsql = "SELECT * from ap_cvp INNER JOIN ap_cv ON ap_cvp.CVNo = ap_cv.CVNo WHERE ap_cvp.APVNo like '" & reader3.Item("APV_Nbr") & "' AND ap_cv.Released = True"
    '                    If connAcctg4.State <> ConnectionState.Open Then connAcctg4.Open()
    '                    Dim cmdsql4 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg4)
    '                    Dim reader4 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql4.ExecuteReader
    '                    While reader4.Read
    '                        bal = bal - reader4.Item("CashInBank")
    '                    End While
    '                    cmdsql4.Dispose()
    '                    reader4.Close()
    '                    connAcctg4.Close()
    '                End While
    '                cmdsql3.Dispose()
    '                reader3.Close()
    '                connAcctg2.Close()

    '                If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '                strsql = "SELECT Client, Balance, BkgNbr, ARNo from ar_adv_main WHERE Client like '" & reader.Item(shipper) & "' And Balance > 0 AND Module like '" & trans & "' ORDER BY ARNo"
    '                Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '                Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql2.ExecuteReader
    '                While reader2.Read
    '                    If IsDBNull(reader2.Item("Balance")) = False Then
    '                        If bal < reader2.Item("Balance") Then
    '                            dgAdvances.Rows.Add("", reader2.Item("Client"), Format$(reader2.Item("Balance") - bal, "n2"), "0.00", reader2.Item("BkgNbr"), reader2.Item("ARNo"))
    '                            If client = reader.Item("SHP_ClientName") Then
    '                                dgAdvances.Rows(dgAdvances.Rows.Count - 1).DefaultCellStyle.BackColor = OpenColorCode
    '                            Else
    '                                dgAdvances.Rows(dgAdvances.Rows.Count - 1).DefaultCellStyle.BackColor = CancelledColorCode
    '                            End If
    '                            bal = 0
    '                        ElseIf bal >= reader2.Item("Balance") Then
    '                            bal = bal - reader2.Item("Balance")
    '                        End If
    '                    End If
    '                End While
    '                cmdsql2.Dispose()
    '                reader2.Close()
    '                connAcctg.Close()
    '            End While
    '            cmdsql.Dispose()
    '            reader.Close()
    '            connExport.Close()
    '        ElseIf groupno = 0 Then
    '            bal = 0
    '            strsql = "SELECT * FROM (ap_apv INNER JOIN ap_crp ON ap_apv.APV_ReqNo = ap_crp.CRP_Nbr) INNER JOIN lib_vendor ON ap_crp.CRP_PayeeID = lib_vendor.VendorID WHERE ap_crp.CRP_PONbr like 'ADVANCES' AND ap_apv.APV_Cancel = False AND lib_vendor.VendorName like '" & client & "'"
    '            If connAcctg2.State <> ConnectionState.Open Then connAcctg2.Open()
    '            Dim cmdsql3 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg2)
    '            Dim reader3 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql3.ExecuteReader
    '            While reader3.Read
    '                bal = reader3.Item("CRP_TotalAmt") + bal
    '                strsql = "SELECT * from ap_cvp INNER JOIN ap_cv ON ap_cvp.CVNo = ap_cv.CVNo WHERE ap_cvp.APVNo like '" & reader3.Item("APV_Nbr") & "' AND ap_cv.Released = True"
    '                If connAcctg4.State <> ConnectionState.Open Then connAcctg4.Open()
    '                Dim cmdsql4 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg4)
    '                Dim reader4 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql4.ExecuteReader
    '                While reader4.Read
    '                    bal = bal - reader4.Item("CashInBank")
    '                End While
    '                cmdsql4.Dispose()
    '                reader4.Close()
    '                connAcctg4.Close()
    '            End While
    '            cmdsql3.Dispose()
    '            reader3.Close()
    '            connAcctg2.Close()

    '            If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '            strsql = "SELECT Client, Balance, BkgNbr, ARNo from ar_adv_main WHERE Client like '" & client & "' And Balance > 0 AND Module like '" & trans & "' ORDER BY ARNo"
    '            Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '            Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql2.ExecuteReader
    '            While reader2.Read
    '                If IsDBNull(reader2.Item("Balance")) = False Then
    '                    If bal < reader2.Item("Balance") Then
    '                        dgAdvances.Rows.Add("", reader2.Item("Client"), Format$(reader2.Item("Balance") - bal, "n2"), "0.00", reader2.Item("BkgNbr"), reader2.Item("ARNo"))
    '                        dgAdvances.Rows(dgAdvances.Rows.Count - 1).DefaultCellStyle.BackColor = OpenColorCode
    '                        bal = 0
    '                    ElseIf bal >= reader2.Item("Balance") Then
    '                        bal = bal - reader2.Item("Balance")
    '                    End If
    '                End If
    '            End While
    '            cmdsql2.Dispose()
    '            reader2.Close()
    '            connAcctg.Close()
    '        End If
    '    End Sub

    '    Private Sub loadBilling(ByVal client As String)
    '        dgBilling.Rows.Clear()
    '        Dim strsql As String = "", used As Boolean
    '        Dim soa As String = "", total As String = "", totalPHP As String = "", currency As String = "", bkg As String = ""
    '        Dim advances As Double = 0
    '        If trans = "Exp" Then
    '            strsql = "SELECT ar2_invoice.AmtPaid ,bill_exp_main.RefNo, bill_exp_main.BookingNo, bill_exp_main.TotalSOA, bill_exp_main.TotalPayment, bill_exp_main.Currency, bill_exp_main.TotalPaymentPHP, ar_adv_vs_billing.Cancel, SUM(ar_adv_billing.Advances) As TotalAdvances from ((bill_exp_main LEFT JOIN ar2_invoice ON bill_exp_main.RefNo = ar2_invoice.RefNo) LEFT JOIN ar_adv_billing ON bill_exp_main.RefNo = ar_adv_billing.Billing_RefNo) LEFT JOIN ar_adv_vs_billing ON ar_adv_billing.RefNo = ar_adv_vs_billing.RefNo WHERE bill_exp_main.BilledTo like '" & client & "' AND bill_exp_main.Posted = True AND bill_exp_main.Cancel = False AND (ISNULL(ar_adv_vs_billing.Cancel) = True OR ar_adv_vs_billing.Cancel = False) GROUP BY bill_exp_main.RefNo"
    '            soa = "TotalSOA"
    '            total = "TotalPayment"
    '            currency = "Currency"
    '            totalPHP = "TotalPaymentPHP"
    '            bkg = "BookingNo"
    '        ElseIf trans = "ImpB" Then
    '            strsql = "SELECT ar2_invoice.AmtPaid ,bill_impb_main.RefNo, bill_impb_main.BookingNos, bill_impb_main.TotalSOA, bill_impb_main.TotalAmt, bill_impb_main.TotalAmtCurrency, bill_impb_main.TotalAmtPHP, ar_adv_vs_billing.Cancel, SUM(ar_adv_billing.Advances) As TotalAdvances from ((bill_impb_main LEFT JOIN ar2_invoice ON bill_impb_main.RefNo = ar2_invoice.RefNo) LEFT JOIN ar_adv_billing ON bill_impb_main.RefNo = ar_adv_billing.Billing_RefNo) LEFT JOIN ar_adv_vs_billing ON ar_adv_billing.RefNo = ar_adv_vs_billing.RefNo WHERE bill_impb_main.BilledTo like '" & client & "' AND bill_impb_main.Posted = True AND bill_impb_main.Cancel = False AND (ISNULL(ar_adv_vs_billing.Cancel) = True OR ar_adv_vs_billing.Cancel = False) GROUP BY bill_impb_main.RefNo"
    '            soa = "TotalSOA"
    '            total = "TotalAmt"
    '            currency = "TotalAmtCurrency"
    '            totalPHP = "TotalAmtPHP"
    '            bkg = "BookingNos"
    '        ElseIf trans = "ImpF" Then
    '            strsql = "SELECT * from bill_impf_main WHERE Client like '" & client & "'"
    '        End If
    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
    '        While reader.Read
    '            If IsDBNull(reader.Item("AmtPaid")) = False Then
    '                If reader.Item("AmtPaid") = reader.Item(soa) Then
    '                    GoTo skip
    '                End If
    '            End If
    '            If IsDBNull(reader.Item("TotalAdvances")) = True Then
    '                advances = 0
    '            Else
    '                advances = reader.Item("TotalAdvances")
    '            End If
    '            If reader.Item(soa) = advances Then
    '                GoTo skip
    '            End If
    '            dgBilling.Rows.Add(used, reader.Item("RefNo"), Format$(reader.Item(soa) - advances, "n2"), Format$(reader.Item(soa) - advances, "n2"), Format$(0, "n2"), reader.Item(bkg))
    'skip:
    '        End While
    '        cmdsql.Dispose()
    '        reader.Close()
    '        connAcctg.Close()
    '    End Sub

    '    Private Sub optExp_CheckedChanged(sender As Object, e As EventArgs) Handles optExp.CheckedChanged
    '        If optExp.Checked = True Then
    '            trans = "Exp"
    '            PopComboAccess(cboClient, "SELECT SHP_ClientName from SHP ORDER by SHP_ClientName", "SHP_ClientName", connExport)
    '        End If
    '    End Sub

    '    Private Sub optImpB_CheckedChanged(sender As Object, e As EventArgs) Handles optImpB.CheckedChanged
    '        If optImpB.Checked = True Then
    '            trans = "ImpB"
    '            PopComboAccess(cboClient, "SELECT SHP_ClientName from SHP ORDER by SHP_ClientName", "SHP_ClientName", connExport)
    '        End If
    '    End Sub

    '    Private Sub optImpF_CheckedChanged(sender As Object, e As EventArgs) Handles optImpF.CheckedChanged
    '        If optImpF.Checked = True Then
    '            trans = "ImpF"
    '            PopComboAccess(cboClient, "SELECT ConsigneeName from ImpConsignee ORDER by ConsigneeName", "ConsigneeName", connImport)
    '        End If
    '    End Sub

    '    Private Sub cboClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClient.SelectedIndexChanged
    '        loadBilling(Me.cboClient.Text)
    '        loadAdvances(Me.cboClient.Text)
    '        totalAdvUsed()
    '        totalSOAAmt()
    '    End Sub
    '    Private Sub totalSOAAmt()
    '        Dim totalSOA As Double = 0
    '        For i As Integer = 0 To dgBilling.Rows.Count - 1
    '            With dgBilling.Rows(i)
    '                If .Cells("colChk").Value = True Then
    '                    totalSOA = totalSOA + CDbl(.Cells("colAdvances").Value)
    '                End If
    '            End With
    '        Next
    '        Me.txtSOATotal.Text = Format$(totalSOA, "n2")
    '    End Sub

    '    Private Sub dgBilling_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBilling.CellContentClick

    '    End Sub

    '    Private Sub dgBilling_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgBilling.CellBeginEdit
    '        If tscmdNew.Enabled = True Then
    '            dgBilling.ReadOnly = True
    '        Else
    '            dgBilling.ReadOnly = False
    '            If lblRefNo.Text.Length > 0 Then
    '                dgBilling.CurrentRow.Cells("colChk").ReadOnly = True
    '            Else
    '                dgBilling.CurrentRow.Cells("colChk").ReadOnly = False
    '            End If
    '        End If
    '        useamt = CDbl(dgBilling.CurrentRow.Cells("colAdvances").Value)
    '    End Sub

    '    Private Sub dgBilling_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgBilling.CellEndEdit
    '        If dgBilling.CurrentRow.Cells("colChk").Value = True Then
    '            dgBilling.CurrentRow.Cells("colAdvances").ReadOnly = False
    '        Else
    '            dgBilling.CurrentRow.Cells("colAdvances").ReadOnly = True
    '        End If
    '        With dgBilling.CurrentRow
    '            If Me.lblRefNo.Text.Length > 0 Then
    '                Dim soaadv As Double = 0
    '                If useamt <= CDbl(.Cells("colAdvances").Value) Then
    '                    If CDbl(.Cells("colSOA").Value) - (CDbl(.Cells("colAdvances").Value) - useamt) < 0 Then
    '                        .Cells("colAdvances").Value = Format$(useamt, "n2")
    '                    Else
    '                        .Cells("colBalance").Value = Format$(CDbl(.Cells("colSOA").Value) - (CDbl(.Cells("colAdvances").Value) - useamt), "n2")
    '                        soaadv = .Cells("colBalance").Value
    '                    End If
    '                ElseIf useamt > CDbl(.Cells("colAdvances").Value) Then
    '                    .Cells("colBalance").Value = Format$(CDbl(.Cells("colSOA").Value) + (useamt - CDbl(.Cells("colAdvances").Value)), "n2")
    '                    soaadv = .Cells("colBalance").Value
    '                End If
    '                .Cells("colAdvances").Value = Format$(CDbl(.Cells("colAdvances").Value), "n2")

    '                Dim totalAdvances As Double = 0
    '                For i As Integer = 0 To dgBilling.Rows.Count - 1
    '                    With dgBilling.Rows(i)
    '                        If .Cells("colChk").Value = True Then
    '                            totalAdvances = totalAdvances + CDbl(.Cells("colAdvances").Value)
    '                        End If
    '                    End With
    '                Next
    '                If totalAdvances > CDbl(Me.txtAdvUsed.Text) Then
    '                    .Cells("colBalance").Value = Format$(CDbl(soaadv), "n2")
    '                    .Cells("colAdvances").Value = Format$(useamt, "n2")
    '                End If
    '            Else
    '                If CDbl(.Cells("colAdvances").Value) > CDbl(.Cells("colSOA").Value) Then
    '                    .Cells("colAdvances").Value = Format$(CDbl(.Cells("colSOA").Value) - CDbl(.Cells("colBalance").Value), "n2")
    '                ElseIf CDbl(.Cells("colAdvances").Value) < 0 Then
    '                    .Cells("colAdvances").Value = Format$(CDbl(.Cells("colSOA").Value) - CDbl(.Cells("colBalance").Value), "n2")
    '                Else
    '                    .Cells("colBalance").Value = Format$(CDbl(.Cells("colSOA").Value) - CDbl(.Cells("colAdvances").Value), "n2")
    '                End If
    '                .Cells("colAdvances").Value = Format$(CDbl(.Cells("colAdvances").Value), "n2")

    '                Dim totalAdvances As Double = 0
    '                For i As Integer = 0 To dgBilling.Rows.Count - 1
    '                    With dgBilling.Rows(i)
    '                        If .Cells("colChk").Value = True Then
    '                            totalAdvances = totalAdvances + CDbl(.Cells("colAdvances").Value)
    '                        End If
    '                    End With
    '                Next
    '                If totalAdvances > CDbl(Me.txtAdvUsed.Text) Then
    '                    .Cells("colAdvances").Value = Format$(useamt, "n2")
    '                    .Cells("colBalance").Value = Format$(CDbl(.Cells("colSOA").Value) - CDbl(.Cells("colAdvances").Value), "n2")
    '                End If
    '            End If
    '        End With
    '        totalSOAAmt()
    '    End Sub

    '    Private Sub dgAdvances_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAdvances.CellContentClick
    '        If dgAdvances.Rows.Count > 0 Then
    '            If lblRefNo.Text.Length > 0 Then
    '                dgAdvances.ReadOnly = False
    '                dgAdvances.CurrentRow.Cells("colUse").ReadOnly = True
    '            Else
    '                dgAdvances.CurrentRow.Cells("colUse").ReadOnly = False
    '            End If
    '        End If
    '        If dgAdvances.Columns(e.ColumnIndex).CellType.Equals(GetType(DataGridViewButtonCell)) Then
    '            If dgAdvances.CurrentRow.DefaultCellStyle.BackColor <> CancelledColorCode Then
    '                Exit Sub
    '            End If
    '            If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_Advances") = False Then
    '                MsgBox("You are not allowed to approve use of this advances!", MsgBoxStyle.Exclamation, "System Message")
    '                Exit Sub
    '            End If
    '            frmAllow.ShowDialog()
    '        End If
    '    End Sub

    '    Private Sub dgAdvances_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgAdvances.CellBeginEdit
    '        If tscmdNew.Enabled = True Then
    '            dgAdvances.ReadOnly = True
    '        Else
    '            dgAdvances.ReadOnly = False
    '        End If
    '        If dgAdvances.Rows.Count > 0 Then
    '            useamt = dgAdvances.CurrentRow.Cells("colUse").Value
    '        End If
    '    End Sub

    '    Private Sub totalAdvUsed()
    '        Dim totaladvuse As Double = 0
    '        For i As Integer = 0 To dgAdvances.Rows.Count - 1
    '            totaladvuse = totaladvuse + CDbl(dgAdvances.Rows(i).Cells("colUse").Value)
    '        Next
    '        Me.txtAdvUsed.Text = Format$(totaladvuse, "n2")
    '    End Sub

    '    Private Sub dgAdvances_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgAdvances.CellEndEdit
    '        If dgAdvances.Rows.Count > 0 Then
    '            With dgAdvances.CurrentRow
    '                If .DefaultCellStyle.BackColor = CancelledColorCode Then
    '                    MsgBox("You are not allowed to use this client's advances for " & Me.cboClient.Text & "!", MsgBoxStyle.Exclamation, "System Message")
    '                    .Cells("colUse").Value = "0.00"
    '                ElseIf IsNumeric(.Cells("colUse").Value) = False Then
    '                    .Cells("colUse").Value = "0.00"
    '                Else
    '                    Dim x As Double = 0, y As Integer = 0
    '                    Dim z As Double = 0
    '                    For i As Integer = 0 To dgAdvances.Rows.Count - 1
    '                        With dgAdvances.Rows(i)
    '                            x = x + .Cells("colUse").Value
    '                            If CDbl(.Cells("colUse").Value) > 0 Then
    '                                y = y + 1
    '                            End If
    '                        End With
    '                    Next
    '                    For i As Integer = 0 To dgBilling.Rows.Count - 1
    '                        With dgBilling.Rows(i)
    '                            If .Cells("colChk").Value = True Then
    '                                z = z + .Cells("colSOA").Value
    '                            End If
    '                        End With
    '                    Next
    '                    If useamt < CDbl(.Cells("colUse").Value) Then
    '                        If (useamt + CDbl(.Cells("colRemaining").Value)) < CDbl(.Cells("colUse").Value) Then
    '                            .Cells("colUse").Value = Format$(useamt, "n2")
    '                        Else
    '                            .Cells("colRemaining").Value = Format$(CDbl(.Cells("colRemaining").Value) - CDbl(.Cells("colUse").Value - useamt), "n2")
    '                        End If
    '                    ElseIf useamt > .Cells("colUse").Value Then
    '                        If .Cells("colUse").Value < 0 Then
    '                            .Cells("colUse").Value = Format$(useamt, "n2")
    '                        Else
    '                            .Cells("colRemaining").Value = Format$(CDbl(.Cells("colRemaining").Value) + CDbl(useamt - .Cells("colUse").Value), "n2")
    '                        End If
    '                    End If
    '                    .Cells("colUse").Value = Format$(CDbl(.Cells("colUse").Value), "n2")
    '                End If
    '                totalAdvUsed()
    '            End With
    '        End If
    '    End Sub

    '    Private Function GetRefNo(ByVal id As String) As String
    '        GetRefNo = ""
    '        Dim no As Integer = 0
    '        Dim strsql As String = "SELECT * from ap_sysparams WHERE CompanyID like '" & id & "'"
    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
    '        While reader.Read
    '            no = reader.Item("crp_Counter")
    '            GetRefNo = reader.Item("BranchCode").ToString & "ADV" & Format$(no, "00000").ToString & Format$(GetServerDate, "yy").ToString
    '        End While
    '        cmdsql.Dispose()
    '        reader.Close()
    '        connAcctg.Close()

    '        no = no + 1

    '        strsql = "UPDATE ap_sysparams SET crp_Counter = '" & no & "' WHERE CompanyID like '" & id & "'"
    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '        cmdsql.ExecuteNonQuery()
    '        cmdsql.Dispose()
    '        connAcctg.Close()
    '    End Function

    '    Private Function blankOrInsufficientEntry() As Boolean
    '        Dim totaluse As Double = 0
    '        blankOrInsufficientEntry = False
    '        If Me.cboClient.Text = "" Then
    '            blankOrInsufficientEntry = True
    '            MsgBox("Please choose a client from the list!", MsgBoxStyle.Exclamation, "System Message")
    '        Else
    '            blankOrInsufficientEntry = True
    '            For i As Integer = 0 To Me.dgBilling.Rows.Count - 1
    '                With Me.dgBilling.Rows(i)
    '                    If .Cells("colChk").Value = True Then
    '                        blankOrInsufficientEntry = False
    '                        totaluse = totaluse + .Cells("colAdvances").Value
    '                    End If
    '                End With
    '            Next
    '            If blankOrInsufficientEntry = True Then
    '                MsgBox("No selected billing!", MsgBoxStyle.Exclamation, "System Message")
    '            ElseIf totaluse <> CDbl(Me.txtAdvUsed.Text) Then
    '                blankOrInsufficientEntry = True
    '                MsgBox("All declared advances must be used for payment of billing!", MsgBoxStyle.Exclamation, "System Message")
    '            End If
    '        End If
    '    End Function

    '    Private Sub SaveEntry()
    '        If blankOrInsufficientEntry() = True Then
    '            Exit Sub
    '        End If
    '        If MsgBox("Do you want to save?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.No Then
    '            Exit Sub
    '        End If
    '        'Try
    '        If Me.lblRefNo.Text.Length = 0 Then
    '            If trans = "Exp" Then
    '                Me.lblRefNo.Text = GetRefNo(trans)
    '            ElseIf trans = "ImpB" Then
    '                Me.lblRefNo.Text = GetRefNo(trans)
    '            Else
    '                Me.lblRefNo.Text = GetRefNo(trans)
    '            End If
    '            Dim strsql As String = "INSERT INTO ar_adv_vs_billing (RefNo, Module, Client, TotalSOA, TotalAdvUsed, PrepBy, PrepDate) " &
    '                               "VALUES (@refno, @mod, @client, @soa, @advused, @prepby, @prepdate)"
    '            If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '            Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '            With cmdsql.Parameters
    '                .AddWithValue("@refno", CStr(Me.lblRefNo.Text))
    '                .AddWithValue("@mod", trans)
    '                .AddWithValue("@client", CStr(Me.cboClient.Text))
    '                .AddWithValue("@soa", CDbl(Me.txtSOATotal.Text))
    '                .AddWithValue("@advused", CDbl(Me.txtAdvUsed.Text))
    '                .AddWithValue("@prepby", CurrentUser)
    '                .AddWithValue("@prepdate", GetServerDate)
    '            End With
    '            cmdsql.ExecuteNonQuery()
    '            cmdsql.Dispose()
    '            connAcctg.Close()

    '            tslblPrepBy.Text = CurrentUser
    '            tslblPrepDate.Text = GetServerDate()
    '            tslblStatus.Text = "Open"

    '        Else
    '            Dim strsql As String = "UPDATE ar_adv_vs_billing SET TotalSOA = @soa, TotalAdvUsed = @advused, UpdatedBy = @updatedby, UpdatedDate = @updateddate WHERE RefNo like '" & Me.lblRefNo.Text & "'"
    '            If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '            Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '            With cmdsql.Parameters
    '                .AddWithValue("@soa", CDbl(Me.txtSOATotal.Text))
    '                .AddWithValue("@advused", CDbl(Me.txtAdvUsed.Text))
    '                .AddWithValue("@updatedby", CurrentUser)
    '                .AddWithValue("@updateddate", GetServerDate)
    '            End With
    '            cmdsql.ExecuteNonQuery()
    '            cmdsql.Dispose()
    '            connAcctg.Close()
    '        End If

    '        SaveSub()

    '        EnableObjects(True, True, True, False, True, True)
    '        MsgBox("Saved!", MsgBoxStyle.Information, "System Message")

    '        Dim advamt As Double = 0

    '        For i As Integer = 0 To dgAdvances.Rows.Count - 1
    '            With dgAdvances.Rows(i)
    '                If .Cells("colCompany").Value = Me.cboClient.Text Then
    '                    advamt = advamt + .Cells("colRemaining").Value
    '                End If
    '            End With
    '        Next

    '        If advamt > 0 Then
    '            If MsgBox("There is an excess advances, do you wish to create an APV for returning advances to clients?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.No Then
    '                Exit Sub
    '            End If
    '            CreateRequest(Me.cboClient.Text, advamt)
    '        End If
    '        'Catch ex As Exception

    '        'End Try
    '    End Sub

    '    Private Sub CreateAPV(ByVal client As String, ByVal reqno As String, ByVal advamt As Double)
    '        With frmAPCheck
    '            .Show()
    '            .toolBranch2.Text = Mid$(reqno, 1, 5)
    '            .tStriptxtCKNbr.Text = Mid$(reqno, 6, 7)
    '            .ValidateSearch(reqno)
    '            .DataGridView3.Rows.Add("", "1150", "Advances on Behalf of Clients", "2", "Export", False, "", True, "Client", client, advamt, 0)
    '            .DataGridView3.Rows.Add("", "2010", "Accounts Payables", "1", "Trade", False, "", True, "Client", client, 0, advamt)
    '            .lblDebit.Text = .SumAmount3()
    '            .lblCredit.Text = .SumAmount2()
    '            .save()
    '            Dim strAPVNo As String = .lblAPVNbr.Text
    '            .ValidateSearch(.lblCRNbr.Text)
    '            .PopulateAPVAccount(strAPVNo)
    '        End With
    '    End Sub

    '    Private Sub CreateRequest(ByVal client As String, ByVal advamt As Double)
    '        Dim vendorexist As Boolean = False
    '        Dim vendorid As String = ""
    '        Dim reqno As String = ""
    'searchagain:
    '        Dim strsql As String = "SELECT * from lib_vendor WHERE VendorName like '" & client & "'"
    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
    '        While reader.Read
    '            vendorexist = True
    '            vendorid = reader.Item("VendorID")
    '        End While
    '        cmdsql.Dispose()
    '        reader.Close()
    '        connAcctg.Close()
    '        If vendorexist = False Then
    '            strsql = "INSERT INTO lib_vendor (VendorName) VALUES (@vendor)"
    '            If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '            cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '            With cmdsql.Parameters
    '                .AddWithValue("@vendor", client)
    '            End With
    '            cmdsql.ExecuteNonQuery()
    '            cmdsql.Dispose()
    '            connAcctg.Close()
    '            GoTo searchagain
    '        End If
    '        With frmRequest
    '            .Text = "Check Request for Payment"
    '            .lblHeader.Text = "Check Request for Payment"
    '            .Tag = "CHK"
    '            .picCHK.Visible = True
    '            .picMC.Visible = False
    '            .picPCR.Visible = False
    '            .Show()

    '            .txtPayeeName.Text = client
    '            .txtPayeeCode.Text = vendorid
    '            .txtRemarks.Text = "Returning of Advances of Client " & client & ", amounting of Php " & Format$(advamt, "n2") & "."
    '            .txtDateNeeded.Text = Format(DateAdd(DateInterval.Hour, 1, GetServerDate), "General Date")
    '            .cboCostCenter.Text = "Accounting"
    '            .cboType.Text = "ADM"
    '            .strType = "ADM"
    '            .strDept = "ACC"
    '            .strChargeID = "AIS"
    '            .txtChargeToName.Text = "Acestar"
    '            .cboChargeTo.Text = "Acestar"
    '            .txtPONbr.Text = "ADVANCES"
    '            .DataGridView1.Rows.Add("", "Export Advances from Client", Format$(advamt, "n2"))
    '            Dim amount As Double
    '            Dim i As Integer
    '            Dim h As DataGridViewRow
    '            For i = 0 To .DataGridView1.Rows.Count - 1
    '                h = .DataGridView1.Rows(i)
    '                amount = h.Cells(2).Value
    '                h.Cells(2).Value = Format(amount, "N2")
    '                .ComputeGrandTotal()
    '            Next
    '            .SaveRequestCHK()
    '            reqno = .lblCRNbr.Text
    '            .Dispose()
    '        End With
    '        CreateAPV(client, reqno, advamt)
    '    End Sub

    '    Private Sub SaveSub()
    '        Dim strsql As String = ""

    '        strsql = "DELETE FROM ar_adv_billing WHERE RefNo like '" & Me.lblRefNo.Text & "'"
    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '        cmdsql.ExecuteNonQuery()
    '        cmdsql.Dispose()
    '        connAcctg.Close()

    '        strsql = "DELETE FROM ar_adv_used WHERE RefNo like '" & Me.lblRefNo.Text & "'"
    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '        cmdsql.ExecuteNonQuery()
    '        cmdsql.Dispose()
    '        connAcctg.Close()

    '        For i As Integer = 0 To Me.dgBilling.Rows.Count - 1
    '            With dgBilling.Rows(i)
    '                If .Cells("colChk").Value = True Then
    '                    strsql = "INSERT INTO ar_adv_billing (RefNo, Billing_RefNo, Advances, BkgNbr) " &
    '                             "VALUES (@refno, @billrefno, @advances, @bkgnbr)"
    '                    If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '                    cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '                    With cmdsql.Parameters
    '                        .AddWithValue("@refno", CStr(Me.lblRefNo.Text))
    '                        .AddWithValue("@billrefno", CStr(dgBilling.Rows(i).Cells("colRefNo").Value))
    '                        .AddWithValue("@advances", CDbl(dgBilling.Rows(i).Cells("colAdvances").Value))
    '                        .AddWithValue("@bkgnbr", CStr(dgBilling.Rows(i).Cells("colBooking").Value))
    '                    End With
    '                    cmdsql.ExecuteNonQuery()
    '                    cmdsql.Dispose()
    '                    connAcctg.Close()
    '                End If
    '            End With
    '        Next

    '        Dim color As Boolean
    '        Dim useamt As Double = 0
    '        Dim balances As Double = 0
    '        For i As Integer = 0 To Me.dgAdvances.Rows.Count - 1
    '            With dgAdvances.Rows(i)
    '                If .DefaultCellStyle.BackColor = OpenColorCode Then
    '                    color = True
    '                Else
    '                    color = False
    '                End If
    '                strsql = "INSERT INTO ar_adv_used (RefNo, Company, UsedAmount, Allowed, BkgNbr, ARNo) " &
    '                             "VALUES (@refno, @company, @usedamt, @allowed, @bkgnbr, @arno)"
    '                If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '                cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '                With cmdsql.Parameters
    '                    .AddWithValue("@refno", CStr(Me.lblRefNo.Text))
    '                    .AddWithValue("@company", CStr(dgAdvances.Rows(i).Cells("colCompany").Value))
    '                    .AddWithValue("@usedamt", CDbl(dgAdvances.Rows(i).Cells("colUse").Value))
    '                    .AddWithValue("@allowed", CBool(color))
    '                    .AddWithValue("@bkgnbr", CStr(dgAdvances.Rows(i).Cells("colBookingAdv").Value))
    '                    .AddWithValue("@arno", CStr(dgAdvances.Rows(i).Cells("colARNo").Value))
    '                End With
    '                cmdsql.ExecuteNonQuery()
    '                cmdsql.Dispose()
    '                connAcctg.Close()

    '                useamt = .Cells("colUse").Value

    '                strsql = "SELECT * from ar_adv_main WHERE Client like '" & Me.cboClient.Text & "' AND ARNo like '" & .Cells("colARNo").Value & "' AND Balance > 0 ORDER by PK"
    '                If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '                cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '                Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
    '                While reader.Read
    '                    If useamt > 0 Then
    '                        If useamt > reader.Item("Balance") Then
    '                            balances = 0
    '                            useamt = useamt - reader.Item("Balance")
    '                        ElseIf useamt <= reader.Item("Balance") Then
    '                            balances = reader.Item("Balance") - useamt
    '                            useamt = 0
    '                        End If
    '                        strsql = "UPDATE ar_adv_main SET Balance = '" & balances & "' WHERE ARNo like '" & reader.Item("ARNo") & "'"
    '                        If connAcctg2.State <> ConnectionState.Open Then connAcctg2.Open()
    '                        Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg2)
    '                        cmdsql1.ExecuteNonQuery()
    '                        cmdsql1.Dispose()
    '                        connAcctg2.Close()
    '                    End If
    '                End While
    '                cmdsql.Dispose()
    '                reader.Close()
    '                connAcctg.Close()
    '            End With
    '        Next
    '    End Sub

    '    Private Function SearchAdvances(ByVal refno As String) As Boolean
    '        SearchAdvances = False
    '        Dim totaladv As Double = 0
    '        Dim totalsoa As Double = 0
    '        Dim strsql As String = "SELECT * from ar_adv_vs_billing WHERE RefNo like '" & refno & "'"
    '        If connAcctg3.State <> ConnectionState.Open Then connAcctg3.Open()
    '        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg3)
    '        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
    '        While reader.Read
    '            clr()
    '            SearchAdvances = True
    '            If reader.Item("Module") = "Exp" Then
    '                optExp.Checked = True
    '            End If
    '            If reader.Item("Cancel") = True Then
    '                tslblStatus.Text = "Cancelled"
    '            Else
    '                tslblStatus.Text = "Open"
    '            End If
    '            Me.tslblPrepBy.Text = reader.Item("PrepBy")
    '            Me.tslblPrepDate.Text = Format$(reader.Item("PrepDate"), "General Date")
    '            Me.lblRefNo.Text = reader.Item("RefNo")
    '            Me.cboClient.Text = reader.Item("Client")
    '            Me.dgBilling.Rows.Clear()
    '            Me.dgAdvances.Rows.Clear()
    '            strsql = "SELECT * from ar_adv_billing WHERE RefNo like '" & refno & "'"
    '            If connAcctg2.State <> ConnectionState.Open Then connAcctg2.Open()
    '            Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg2)
    '            Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql2.ExecuteReader
    '            While reader2.Read
    '                Me.dgBilling.Rows.Add(True, reader2.Item("Billing_RefNo"), "0.00", "0.00", Format$(reader2.Item("Advances"), "n2"), reader2.Item("BkgNbr"))
    '            End While
    '            cmdsql2.Dispose()
    '            reader2.Close()
    '            connAcctg2.Close()

    '            For i As Integer = 0 To Me.dgBilling.Rows.Count - 1
    '                With dgBilling.Rows(i)
    '                    strsql = "SELECT * from ar_adv_billing WHERE Billing_RefNo like '" & .Cells("colRefNo").Value & "'"
    '                    If connAcctg2.State <> ConnectionState.Open Then connAcctg2.Open()
    '                    cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg2)
    '                    reader2 = cmdsql2.ExecuteReader
    '                    While reader2.Read
    '                        totaladv = totaladv + reader2.Item("Advances")
    '                    End While
    '                    cmdsql2.Dispose()
    '                    reader2.Close()
    '                    connAcctg2.Close()

    '                    If reader.Item("Module") = "Exp" Then
    '                        strsql = "SELECT * from bill_exp_main WHERE RefNo like '" & .Cells("colRefNo").Value & "'"
    '                        If connAcctg2.State <> ConnectionState.Open Then connAcctg2.Open()
    '                        cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg2)
    '                        reader2 = cmdsql2.ExecuteReader
    '                        While reader2.Read
    '                            totalsoa = totalsoa + reader2.Item("TotalSOA")
    '                        End While
    '                        cmdsql2.Dispose()
    '                        reader2.Close()
    '                        connAcctg2.Close()
    '                        .Cells("colSOA").Value = Format$(totalsoa - totaladv, "n2")
    '                        .Cells("colBalance").Value = Format$(totalsoa - totaladv, "n2")
    '                    End If
    '                End With
    '            Next
    '        End While
    '        cmdsql.Dispose()
    '        reader.Close()
    '        connAcctg3.Close()

    '        strsql = "SELECT * from ar_adv_used WHERE RefNo like '" & refno & "'"
    '        If connAcctg3.State <> ConnectionState.Open Then connAcctg3.Open()
    '        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg3)
    '        reader = cmdsql.ExecuteReader
    '        While reader.Read
    '            Me.dgAdvances.Rows.Add("", reader.Item("Company"), "0.00", Format$(reader.Item("UsedAmount"), "n2"), reader.Item("BkgNbr"), reader.Item("ARNo"))
    '            If reader.Item("Allowed") = True Then
    '                Me.dgAdvances.Rows(dgAdvances.Rows.Count - 1).DefaultCellStyle.BackColor = OpenColorCode
    '            Else
    '                Me.dgAdvances.Rows(dgAdvances.Rows.Count - 1).DefaultCellStyle.BackColor = CancelledColorCode
    '            End If
    '            strsql = "SELECT SUM(Balance) As TotalBalance from ar_adv_main WHERE Client like '" & Me.cboClient.Text & "' AND ARNo like '" & reader.Item("ARNo") & "'"
    '            If connAcctg2.State <> ConnectionState.Open Then connAcctg2.Open()
    '            Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg2)
    '            Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql2.ExecuteReader
    '            While reader2.Read
    '                Me.dgAdvances.Rows(Me.dgAdvances.Rows.Count - 1).Cells("colRemaining").Value = Format$(reader2.Item("TotalBalance"), "n2")
    '            End While
    '            cmdsql2.Dispose()
    '            reader2.Close()
    '            connAcctg2.Close()
    '        End While
    '        cmdsql.Dispose()
    '        reader.Close()
    '        connAcctg3.Close()

    '        totalAdvUsed()
    '        totalSOAAmt()
    '        EnableObjects(True, True, True, False, True, True)
    '    End Function
End Class