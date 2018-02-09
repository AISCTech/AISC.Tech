Imports System.IO
Public Class frmGeneralLedger
    Dim strsql As String, x As Boolean
    Dim strsql2 As String
    'Dim allchecked As Boolean
    'Dim exporttoexcel As Boolean
    Public count As Integer
    Public MainAcctCode As String
    Public SubAcctCode As String
    Public MainAcctTitle As String
    Public SubAcctTitle As String

    Private Sub cmdGenerate_Click(sender As Object, e As EventArgs) Handles cmdGenerate.Click
        Me.lblSubAccount.Text = "SUBSIDIARY"
        trialBalance()
        MainAcctCode = ""
        SubAcctCode = ""
        MainAcctTitle = ""
        SubAcctTitle = ""
    End Sub

    Private Sub frmGeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If strCurrentUser = "admin" Then
            Me.btDiscrepancy.Visible = True
        Else
            Me.btDiscrepancy.Visible = False
        End If
    End Sub

    Public Sub PopBegBalance2013(ByVal dg As DataGridView, ByVal str As String)
        strsql = "SELECT * from gja WHERE " &
                "GJA_GJVNbr = '" & str & "'" ' & _
        ' "GROUP BY AcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader

        While reader.Read
            dg.Rows.Add("", reader.Item("GJA_Account_Code"), reader.Item("GJA_Account_Title"), "0", reader.Item("GJA_DR"), reader.Item("GJA_CR"), "", "0")
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()
    End Sub

    Private Function GetSubAcctTitle(ByVal acctcode As String, ByVal subacctcode As String) As String
        GetSubAcctTitle = ""
        Dim strsql As String = "SELECT * from lib_subacctcode WHERE Account_Code like '" & acctcode & "' and SubAccount_Code like '" & subacctcode & "'"

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
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

    Public Sub trialBalance()
        Dim BegBalFromDate As Date = DateValue("January 1, 2015")
        'Dim BegBalToDate As Date = Me.dtFrom1.Value
        Dim BegBalToDate As Date = Me.dtFrom1.Value.AddDays(-1)
        dtgTBEntry1.Rows.Clear()
        dtgTBEntry2.Rows.Clear()
        dtgBegBal.Rows.Clear()
        dtgJV2013.Rows.Clear()
        dtgSummary.Rows.Clear()
        dtgSubAcct.Rows.Clear()

        Me.GroupBox1.Visible = True

        'load selected date range
        Me.ProgressBar1.Maximum = 0
        Me.ProgressBar1.Maximum = 100

        'LoadTrialBalanceEntry("Selected Period Covered", Me.dtgTBEntry1, Format(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00"), Format(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59"), Me.lblCurrentProgress, Me.ProgressBar1, Me.lblPercentage, 1)
        ''load Beginning Balance
        'LoadTrialBalanceEntry("Beginning Balance", Me.dtgBegBal, Format(BegBalFromDate, "yyyy-MM-dd 00:00:00"), Format(BegBalToDate, "yyyy-MM-dd 23:59:59"), Me.lblCurrentProgress, Me.ProgressBar1, Me.lblPercentage, 1)

        'Compute Beginning Balance=================================================================================
        Dim i As Integer = 0
        Dim h As DataGridViewRow
        Dim x As Integer = 0
        Dim y As DataGridViewRow
        Dim BegBal As Double
        Dim BgBlExist As Boolean = False
        Dim BgBlAcctCode As String = ""
        Dim BgBlAcctTitle As String = ""
        Dim BgBlJV As Double = 0


        For i = 0 To Me.dtgTBEntry1.Rows.Count - 1
            h = Me.dtgTBEntry1.Rows(i)
            ' BgBlExist = False
            For x = 0 To Me.dtgBegBal.Rows.Count - 1
                y = Me.dtgBegBal.Rows(x)
                h.Cells(6).Value = 0

                'BgBlAcctCode = y.Cells(1).Value
                'BgBlAcctTitle = y.Cells(2).Value
                'BgBlJV = CDbl(y.Cells(4).Value) - CDbl(y.Cells(5).Value)

                If h.Cells(1).Value = y.Cells(1).Value Then
                    ' BgBlExist = True
                    BegBal = y.Cells(4).Value - y.Cells(5).Value
                    h.Cells(3).Value = Format(BegBal, "n2")
                    Exit For
                End If
            Next

            'If BgBlExist = False Then
            '    Me.dtgTBEntry2.Rows.Add(False, BgBlAcctCode, BgBlAcctTitle, Format(BgBlJV, "n2"), 0, 0, "", 0, "")
            'End If

        Next

        Dim iC As Integer = 0
        Dim hC As DataGridViewRow
        Dim iY As Integer = 0
        Dim hY As DataGridViewRow

        For iC = 0 To Me.dtgBegBal.Rows.Count - 1
            hC = Me.dtgBegBal.Rows(iC)

            For iY = 0 To Me.dtgTBEntry1.Rows.Count - 1

                hY = Me.dtgTBEntry1.Rows(iY)

                If hC.Cells(1).Value = hY.Cells(1).Value Then
                    BgBlExist = True
                    Exit For
                Else
                    BgBlExist = False
                End If
            Next

            If BgBlExist = False Then
                Me.dtgTBEntry2.Rows.Add(False, hC.Cells(1).Value, hC.Cells(2).Value, CDbl(hC.Cells(4).Value) - CDbl(hC.Cells(5).Value), 0, 0, "", 0, "")
                'Me.dtgTBEntry1.Rows.Add(False, AcctCode, AcctTitle, Format(BegBalJV, "n2"), 0, 0, "", 0, "")
            End If

        Next


        Dim iA As Integer = 0
        Dim hA As DataGridViewRow

        If Me.dtgTBEntry2.Rows.Count <> 0 Then
            For iA = 0 To Me.dtgTBEntry2.Rows.Count - 1
                hA = Me.dtgTBEntry2.Rows(iA)

                Me.dtgTBEntry1.Rows.Add(False, hA.Cells(1).Value, hA.Cells(2).Value, hA.Cells(3).Value, hA.Cells(4).Value, hA.Cells(5).Value, hA.Cells(6).Value, hA.Cells(7).Value, hA.Cells(8).Value)

            Next
        End If


        'load beginning balance up to dec 31, 2013
        PopBegBalance2013(Me.dtgJV2013, "GJVMNL000149")
        Dim i2 As Integer = 0
        Dim h2 As DataGridViewRow
        Dim x2 As Integer = 0
        Dim y2 As DataGridViewRow
        Dim BegBal2013 As Double
        For i2 = 0 To Me.dtgTBEntry1.Rows.Count - 1
            h2 = Me.dtgTBEntry1.Rows(i2)
            For x2 = 0 To Me.dtgJV2013.Rows.Count - 1
                y2 = Me.dtgJV2013.Rows(x2)
                BegBal2013 = 0
                If h2.Cells(1).Value = y2.Cells(1).Value Then
                    BegBal2013 = CDbl(h2.Cells(3).Value) + (CDbl(y2.Cells(4).Value) - CDbl(y2.Cells(5).Value))
                    h2.Cells(3).Value = Format(BegBal2013, "n2")
                    'h2.Cells(7).Value = Format((BegBal2013 + h2.Cells(4).Value) - h2.Cells(5).Value, "n2")
                    Exit For
                End If
            Next
        Next

        Dim ijv As Integer = 0
        Dim hjv As DataGridViewRow
        Dim itb As Integer = 0
        Dim htb As DataGridViewRow
        Dim jvExists As Boolean
        Dim AcctCode As String = ""
        Dim AcctTitle As String = ""
        Dim BegBalJV As Double = 0


        For ijv = 0 To Me.dtgJV2013.Rows.Count - 1
            hjv = Me.dtgJV2013.Rows(ijv)
            jvExists = False
            AcctCode = ""
            AcctTitle = ""
            BegBalJV = 0

            If Me.dtgTBEntry1.Rows.Count = 0 Then
                AcctCode = hjv.Cells(1).Value
                AcctTitle = hjv.Cells(2).Value

                BegBalJV = CDbl(hjv.Cells(4).Value) - CDbl(hjv.Cells(5).Value)
            End If

            For itb = 0 To Me.dtgTBEntry1.Rows.Count - 1
                htb = Me.dtgTBEntry1.Rows(itb)

                AcctCode = hjv.Cells(1).Value
                AcctTitle = hjv.Cells(2).Value

                BegBalJV = CDbl(hjv.Cells(4).Value) - CDbl(hjv.Cells(5).Value)

                ' MsgBox(hjv.Cells(4).Value & " - " & hjv.Cells(5).Value & " = " & BegBalJV)

                If hjv.Cells(1).Value = htb.Cells(1).Value Then
                    jvExists = True
                    Exit For
                End If
            Next

            If jvExists = False Then
                Me.dtgTBEntry1.Rows.Add(False, AcctCode, AcctTitle, Format(BegBalJV, "n2"), 0, 0, "", 0, "")
            End If
        Next

        'Compute Ending Balance====================================================================================
        Dim i3 As Integer = 0
        Dim h3 As DataGridViewRow
        For i3 = 0 To Me.dtgTBEntry1.Rows.Count - 1
            h3 = Me.dtgTBEntry1.Rows(i3)
            h3.Cells(7).Value = Format((CDbl(h3.Cells(3).Value) + h3.Cells(4).Value) - h3.Cells(5).Value, "n2")
        Next

        dtgTBEntry1.Sort(dtgTBEntry1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

        ComputeTotals()
        Application.DoEvents()
        Me.lblCurrentProgress.Text = "Loading" & vbNewLine & "Completed."
        Me.GroupBox1.Visible = False
    End Sub

    Private Sub dtgTBEntry1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgTBEntry1.CellContentClick

    End Sub

    Private Sub ComputeTotals()
        Me.lblDebit1.Text = "0.00"
        Me.lblCredit1.Text = "0.00"

        Me.lblBegBalDR.Text = "0.00"
        Me.lblBegBalCR.Text = "0.00"

        Me.lblBegBalance.Text = "0.00"
        Me.lblEndBalance.Text = "0.00"


        For ctrRow As Integer = 0 To Me.dtgTBEntry1.Rows.Count - 1
            With Me.dtgTBEntry1.Rows(ctrRow)
                Me.lblDebit1.Text = Format(CDbl(Me.lblDebit1.Text) + CDbl(.Cells(4).Value), "n2")
                Me.lblCredit1.Text = Format(CDbl(Me.lblCredit1.Text) + CDbl(.Cells(5).Value), "n2")

                Me.lblBegBalance.Text = Format(CDbl(Me.lblBegBalance.Text) + CDbl(.Cells(3).Value), "n2")
                Me.lblEndBalance.Text = Format(CDbl(Me.lblEndBalance.Text) + CDbl(.Cells(7).Value), "n2")
            End With
        Next

        For ctrRow As Integer = 0 To Me.dtgBegBal.Rows.Count - 1
            With Me.dtgBegBal.Rows(ctrRow)
                Me.lblBegBalDR.Text = Format(CDbl(Me.lblBegBalDR.Text) + CDbl(.Cells(4).Value), "n2")
                Me.lblBegBalCR.Text = Format(CDbl(Me.lblBegBalCR.Text) + CDbl(.Cells(5).Value), "n2")
            End With
        Next



        Dim x As Integer = 1, y As Integer = 2
        '  Dim totalDR As Double, totalCR As Double

        'For i As Integer = 0 To dtgAll.Rows.Count - 1
        '    totalDR = 0
        '    totalCR = 0
        '    With dtgAll.Rows(i)
        '        x = 1
        '        y = 2
        '        Do Until x = 25
        '            totalDR = totalDR + .Cells(x).Value
        '            x = x + 2
        '        Loop

        '        Do Until y = 26
        '            totalCR = totalCR + .Cells(y).Value
        '            y = y + 2
        '        Loop
        '        .Cells(27).Value = Format$(totalDR, "n2")
        '        .Cells(28).Value = Format$(totalCR, "n2")
        '    End With
        'Next
    End Sub

    Private Sub dtgTBEntry1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgTBEntry1.CellDoubleClick
        If e.RowIndex >= 0 Then
            Me.dtgSubAcct.Rows.Clear()
            'Me.dtgDept.Rows.Clear()
            'Me.dtgList1.Rows.Clear()
            'Me.dtgList2.Rows.Clear()
            Me.dtgSummary.Rows.Clear()

            'If Len(Me.lblRefNo.Text) = 0 Then

            MainAcctCode = Me.dtgTBEntry1.CurrentRow.Cells(1).Value
            MainAcctTitle = Me.dtgTBEntry1.CurrentRow.Cells(2).Value

            Me.GroupBox2.Visible = True
            GenerateSubAccount(MainAcctCode)
            Me.GroupBox2.Visible = False
            Application.DoEvents()

            Me.GroupBox3.Visible = True
            GenerateSummary(MainAcctCode)
            Me.GroupBox3.Visible = False
            Application.DoEvents()
            'Me.TextBox1.Text = Me.dtgSummary.Rows.Count

            Me.lblSubDR.Text = Format(SumAmountDR("Sub", Me.dtgSubAcct), "n2")
            Me.lblSubCR.Text = Format(SumAmountCR("Sub", Me.dtgSubAcct), "n2")

            Me.lblSummaryDR.Text = Format(SumAmountDR("Summary", Me.dtgSummary), "n2")
            Me.lblSummaryCR.Text = Format(SumAmountCR("Summary", Me.dtgSummary), "n2")

            Me.lblSubAccount.Text = "SUBSIDIARY OF " & MainAcctTitle


            ' Else
            '     LoadCloseGLSubAccount(Me.lblRefNo.Text, Me.dtgGLEntry.Rows(e.RowIndex).Cells(colAcctCode.Name).Value)
            '     LoadCloseGLSummary(Me.lblRefNo.Text, Me.dtgGLEntry.Rows(e.RowIndex).Cells(colAcctCode.Name).Value)
            ' End If
        End If

        dtgCheckBox()
    End Sub

    Private Sub dtgCheckBox()
        Dim i As Integer = 0
        For i = 0 To dtgSubAcct.RowCount - 1
            dtgSubAcct.Rows(i).Cells(0).Value = True
        Next
    End Sub

    Private Sub GenerateSummary(ByVal strAcctCode As String)
        'Me.dtgSummary.Rows.Add(reader.Item("RefNo"), Format(reader.Item("SLDate"), "MM/dd/yyyy"), reader.Item("BilledTo"), reader.Item("SL_Account_Title"), Format(reader.Item("SL_DR"), "n2"), Format(reader.Item("SL_CR"), "n2"))
        Dim strsql As String
        'Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand
        'Dim reader As MySql.Data.MySqlClient.MySqlDataReader
        '======================================ACKNOWLEDGMENT RECEIPT=======================================
        'Container Refund AR
        strsql = "SELECT * from v_tb_arcontrefsummary " &
                "WHERE PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Container Refund Acknowledgment Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = 0
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("ARNo"), Format(reader.Item("PostedDate"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from Exp AR
        strsql = "SELECT * from v_tb_arexpsummary " &
             "WHERE PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Export Acknowledgment Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("ARNo"), Format(reader.Item("PostedDate"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from ImpB AR
        strsql = "SELECT * from v_tb_arimpbsummary " &
             "WHERE PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Import Brokerage Acknowledgment Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("ARNo"), Format(reader.Item("PostedDate"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from ImpF AR
        strsql = "SELECT * from v_tb_arimpfsummary " &
             "WHERE PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Import Forwarding Acknowledgment Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("ARNo"), Format(reader.Item("PostedDate"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'GENERATE from ar2
        strsql = "SELECT * from v_tb_ar2summary " &
             "WHERE PostDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Acknowledgment Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("ORNo"), Format(reader.Item("PostDate"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), GetAccountTitle(reader.Item("AcctCode")), GetSubAcctTitle(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '======================================OFFICIAL RECEIPT=======================================

        'Generate from Exp OR
        strsql = "SELECT * from v_tb_orexpsummary " &
             "WHERE PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Export Official Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("ORNo"), Format(reader.Item("PostedDate"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from ImpB OR
        strsql = "SELECT * from v_tb_orimpbsummary " &
             "WHERE PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Import Brokerage Official Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("ORNo"), Format(reader.Item("PostedDate"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from ImpF OR
        strsql = "SELECT * from v_tb_orimpfsummary " &
             "WHERE PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Import Forwarding Official Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("ORNo"), Format(reader.Item("PostedDate"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'GENERATE from or2
        strsql = "SELECT * from v_tb_or2summary " &
             "WHERE PostDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Official Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("ORNo"), Format(reader.Item("PostDate"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), GetAccountTitle(reader.Item("AcctCode")), GetSubAcctTitle(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '=====================================BILLING============================================================
        'GENERATE from exp bill
        strsql = "SELECT * from v_tb_billexpsummary " &
             "WHERE PrepDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Export Billing Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("RefNo"), Format(reader.Item("PrepDate"), "MM/dd/yyyy"), reader.Item("BilledTo"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'GENERATE from impb bill
        strsql = "SELECT * from v_tb_billimpbsummary " &
             "WHERE PrepDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Import Brokerage Billing Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("RefNo"), Format(reader.Item("PrepDate"), "MM/dd/yyyy"), reader.Item("BilledTo"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'GENERATE from impf bill
        strsql = "SELECT * from v_tb_billimpfsummary " &
             "WHERE DateSaved BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Import Brokerage Billing Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 2
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("RefNo"), Format(reader.Item("DateSaved"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'GENERATE from impdcaf bill
        strsql = "SELECT * from v_tb_billimpdcafsummary " &
             "WHERE DateSaved BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Import DC Note Billing Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 3
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql.CommandTimeout = 120
        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("RefNo"), Format(reader.Item("DateSaved"), "MM/dd/yyyy"), reader.Item("Client"), reader.Item("Remarks"), reader.Item("AcctTitle"), reader.Item("SubAcctTitle"), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '==========================CASH DISBURSEMENTS===========================================================
        'Generate from  APV
        strsql = "SELECT * from v_tb_apcrapsummary " &
                "WHERE APV_PostDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                "AND CRAP_Account_Code = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Accounts Payables Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        While reader.Read
            Dim vendorname As String = ""

            If cnn.State <> ConnectionState.Open Then cnn.Open()

            If Mid$(reader.Item("APV_ReqNo"), 1, 3) = "CRM" Or Mid$(reader.Item("APV_ReqNo"), 1, 3) = "CRL" Or Mid$(reader.Item("APV_ReqNo"), 1, 3) = "CRS" Or Mid$(reader.Item("APV_ReqNo"), 1, 3) = "CRC" Then
                strsql2 = "SELECT * from ap_crp INNER JOIN lib_vendor ON ap_crp.CRP_PayeeID = lib_vendor.VendorID WHERE ap_crp.CRP_Nbr like '" & reader.Item("APV_ReqNo") & "'"
            ElseIf Mid$(reader.Item("APV_ReqNo"), 1, 3) = "MCR" Then
                strsql2 = "SELECT * from ap_mcp INNER JOIN lib_vendor ON ap_mcp.MCP_PayeeID = lib_vendor.VendorID WHERE ap_mcp.MCP_Nbr like '" & reader.Item("APV_ReqNo") & "'"
            End If

            Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql2, cnn)

            Dim reader1 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql1.ExecuteReader

            While reader1.Read
                vendorname = reader1.Item("VendorName")
            End While
            cmdsql1.Dispose()
            reader1.Close()
            cnn.Close()

            Me.dtgSummary.Rows.Add(reader.Item("APV_Nbr"), Format(reader.Item("APV_PostDate"), "MM/dd/yyyy"), vendorname, "APV for Request No. " & reader.Item("APV_ReqNo"), reader.Item("CRAP_Account_Title"), reader.Item("CRAP_SubAccount_Title"), Format(reader.Item("CRAP_DR"), "n2"), Format(reader.Item("CRAP_CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnn.Close()

        'Generate from SL Check/MC
        strsql = "SELECT *, ap_cvd.CVD_Account_Title, ap_cvd.CVD_DR, ap_cvd.CVD_CR FROM " &
                 "ap_cvd INNER JOIN ap_cv ON ap_cvd.CVNo = ap_cv.CVNo WHERE ap_cv.CheckDate BETWEEN " &
                 "'" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd") & "' " &
                 "AND ap_cvd.CVD_Account_Code = '" & strAcctCode & "' AND ap_cv.Cancelled = '" & 0 & "' " &
                 "AND ap_cvd.CVD_AdjustedEntry = 0"

        strsql = "SELECT * from v_tb_apcvdsummary " &
                "WHERE CheckDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd") & "' " &
                "AND CVD_Account_Code = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Check/MC Voucher Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("CVNo"), Format(reader.Item("CheckDate"), "MM/dd/yyyy"), reader.Item("VendorName"), reader.Item("Remarks"), reader.Item("CVD_Account_Title"), reader.Item("CVD_SubAccount_Title"), Format(reader.Item("CVD_DR"), "n2"), Format(reader.Item("CVD_CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()


        'Generate from LIQUIDATED PCV

        strsql = "SELECT * from v_tb_appcasummary " &
                "WHERE PCR_PostDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                "AND PCA_Account_Code = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Posted PCV Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("PCR_Nbr"), Format(reader.Item("PCR_PostDate"), "MM/dd/yyyy"), reader.Item("VendorName"), reader.Item("PCR_Remarks"), reader.Item("PCA_Account_Title"), reader.Item("PCA_SubAccount_Title"), Format(reader.Item("PCA_DR"), "n2"), Format(reader.Item("PCA_CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from RELEASED PCV
        strsql = "SELECT * from v_tb_appcarsummary " &
                "WHERE PCR_ReleaseDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                "AND PCAR_Account_Code = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Released PCV Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("PCR_Nbr"), Format(reader.Item("PCR_ReleaseDate"), "MM/dd/yyyy"), reader.Item("VendorName"), reader.Item("PCR_Remarks"), reader.Item("PCAR_Account_Title"), reader.Item("PCAR_SubAccount_Title"), Format(reader.Item("PCAR_DR"), "n2"), Format(reader.Item("PCAR_CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()


        strsql = "SELECT * from v_tb_apcvdlsummary " &
                "WHERE LiquidatedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd") & "' " &
                "AND CVD_Account_Code = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Adjusted Check/MC Voucher Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("CVNo"), Format(reader.Item("LiquidatedDate"), "MM/dd/yyyy"), reader.Item("VendorName"), reader.Item("Remarks"), reader.Item("CVD_Account_Title"), reader.Item("CVD_SubAccount_Title"), Format(reader.Item("CVD_DR"), "n2"), Format(reader.Item("CVD_CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '===============================================GENERAL JOURNAL===================================

        'Generate from General Journal
        strsql = "SELECT *, gja.GJA_Account_Title, gja.GJA_DR, gja.GJA_CR, lib_vendor.VendorName FROM " &
                 "(gja INNER JOIN gjv ON gja.GJA_GJVNbr = gjv.GJV_Nbr) INNER JOIN lib_vendor ON gjv.GJV_PayeeID = lib_vendor.VendorID WHERE gjv.GJV_DtNeed BETWEEN " &
                 "'" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                 "AND gja.GJA_Account_Code = '" & strAcctCode & "' AND gjv.GJV_Cancel = '" & 0 & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "General Journal Voucher Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("GJV_Nbr"), Format(reader.Item("GJV_DtNeed"), "MM/dd/yyyy"), reader.Item("VendorName"), reader.Item("GJV_Remarks"), reader.Item("GJA_Account_Title"), reader.Item("GJA_SubAccount_Title"), Format(reader.Item("GJA_DR"), "n2"), Format(reader.Item("GJA_CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '=======================================DEPOSITS RECEIPT====================================================
        'Generate from Deposit Receipt
        strsql = "SELECT *, dra.DRA_Account_Title, dra.DRA_DR, dra.DRA_CR FROM " &
                 "dra INNER JOIN drv ON dra.DRA_Nbr = drv.DRV_Nbr WHERE drv.DRV_PostDate BETWEEN " &
                 "'" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                 "AND dra.DRA_Account_Code = '" & strAcctCode & "' AND drv.DRV_Cancel = '" & 0 & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Deposits Receipt Voucher Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSummary.Rows.Add(reader.Item("DRV_Nbr"), Format(reader.Item("DRV_PostDate"), "MM/dd/yyyy"), "Deposit Receipts Voucher", reader.Item("DRV_Remarks") & "-" & GetPRDepositReceipts(reader.Item("DRV_Nbr")), reader.Item("DRA_Account_Title"), reader.Item("DRA_SubAccount_Title"), Format(reader.Item("DRA_DR"), "n2"), Format(reader.Item("DRA_CR"), "n2"))
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '============================================ADVANCES==================================================

        'Generate from Advances

        strsql = "SELECT * from v_tb_aradvsummary " &
                "WHERE PrepDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                "AND AcctCode = '" & strAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSummary.Text = "Currently Loading " & vbNewLine & "Client Advances Info...."

        Application.DoEvents()
        Me.ProgressBar3.Value = Me.ProgressBar3.Value + 5
        Me.lblPercentageSummary.Text = Format((Me.ProgressBar3.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read

            Me.dtgSummary.Rows.Add(reader.Item("ARNo"), Format(reader.Item("PrepDate"), "MM/dd/yyyy"), reader.Item("Client"), "Client Advances", GetAccountTitle(strAcctCode), GetSubAcctName(strAcctCode, reader.Item("SubAcctCode")), Format(reader.Item("DR"), "n2"), Format(reader.Item("CR"), "n2"))

        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()
    End Sub

    Public Function GetPRDepositReceipts(ByVal str As String) As String
        GetPRDepositReceipts = ""
        Dim strSQL As String

        strSQL = "SELECT ARNo, ORNo " &
                 "FROM drorar " &
                 "WHERE drorar.DRV_Nbr = '" & str & "'"
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmd2 = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmd2.ExecuteReader()

        If reader2.HasRows = False Then
            GetPRDepositReceipts = ""
            cmd2.Dispose()
            reader2.Close()
            cnn.Close()
            Exit Function
        End If
        Dim ARNumber As String = ""
        Dim ORNumber As String = ""

        While reader2.Read

            If Len(reader2.Item("ARNO")) <> 0 Then
                ARNumber = "AR:" & reader2.Item("ARNo") & ","
            Else
                ARNumber = ""
            End If

            If Len(reader2.Item("ORNO")) <> 0 Then
                ORNumber = "OR:" & reader2.Item("ORNo") & ","
            Else
                ORNumber = ""
            End If

            GetPRDepositReceipts = GetPRDepositReceipts & ARNumber & ORNumber & ", "
        End While

        cmd2.Dispose()
        reader2.Close()
        cnn.Close()
    End Function

    Private Sub GenerateSubAccount(ByVal strAcctCode As String)
        Dim strsql As String
        'Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand
        'Dim reader As MySql.Data.MySqlClient.MySqlDataReader
        strsql = "SELECT *, SUM(DR), SUM(CR) from v_tb_arcontref WHERE " &
                 "PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                 "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Container Refund Acknowledgment Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = 0
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader

        While reader.Read
            Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from Exp AR
        strsql = "SELECT *, SUM(DR), SUM(CR) FROM v_tb_arexp " &
             "WHERE " &
             "PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Export Acknowledgment Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from ImpB AR
        strsql = "SELECT *, SUM(DR), SUM(CR) FROM v_tb_arimpb " &
             "WHERE " &
             "PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Import Brokerage Acknowledgment Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from ImpF AR
        strsql = "SELECT *, SUM(DR), SUM(CR) FROM v_tb_arimpf " &
             "WHERE " &
             "PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Import Forwarding Acknowledgment Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate ar2
        strsql = "SELECT *, SUM(DR), SUM(CR) from v_tb_ar2 WHERE " &
             "PostDate BETWEEN @from AND @to " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Acknowledgment Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        With cmdsql.Parameters
            .AddWithValue("@from", Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00"))
            .AddWithValue("@to", Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59"))
        End With

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            Application.DoEvents()
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        ' .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + reader.Item("CWT") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '==================================================OFFICIAL RECEIPT=================================
        'Generate from Exp OR
        strsql = "SELECT *, SUM(DR), SUM(CR) FROM v_tb_orexp " &
             "WHERE " &
             "PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Export Official Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()



        'Generate from ImpB OR
        strsql = "SELECT *, SUM(DR), SUM(CR) FROM v_tb_orimpb " &
             "WHERE " &
             "PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Import Brokergae Official Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()



        'Generate from ImpF OR
        strsql = "SELECT *, SUM(DR), SUM(CR) FROM v_tb_orimpf " &
             "WHERE " &
             "PostedDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Import Forwarding Official Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from or2

        strsql = "SELECT *, SUM(DR), SUM(CR) from v_tb_or2 WHERE " &
             "PostDate BETWEEN @from AND @to " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Official Receipt Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        With cmdsql.Parameters
            .AddWithValue("@from", Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00"))
            .AddWithValue("@to", Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59"))
        End With

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            Application.DoEvents()
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()


        '=======================================BILLING=========================================================

        'Generate from BILLING Export
        strsql = "SELECT *, SUM(DR), SUM(CR) from v_tb_billexp WHERE " &
             "PrepDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Export Billing Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from BILLING Import Brokerage
        strsql = "SELECT *, SUM(DR), SUM(CR) from v_tb_billimpb WHERE " &
             "PrepDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Import Brokerage Billing Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        ''Generate from BILLING Import Forwarding
        strsql = "SELECT *, SUM(DR), SUM(CR) from v_tb_billimpf WHERE " &
             "DateSaved BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Import Forwarding Billing Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '====================================CASH DISBURSEMENTS==================================================

        'Generate from SL APV
        strsql = "SELECT *, SUM(CRAP_DR), SUM(CRAP_CR) FROM v_tb_apcrap " &
                 "WHERE APV_PostDate BETWEEN " &
                 "'" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                 "AND CRAP_Account_Code = '" & strAcctCode & "' GROUP BY CRAP_SubAccount_Code"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Accounts Payables Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("CRAP_SubAccount_Code") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(CRAP_DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CRAP_CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("CRAP_SubAccount_Code"), GetSubAcctName(reader.Item("CRAP_Account_Code"), reader.Item("CRAP_SubAccount_Code")), Format(reader.Item("SUM(CRAP_DR)"), "n2"), Format(reader.Item("SUM(CRAP_CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        'Generate from Check/MC Voucher
        strsql = "SELECT *, SUM(CVD_DR), SUM(CVD_CR) FROM v_tb_apcvd " &
                 "WHERE CheckDate BETWEEN " &
                 "'" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd") & "' " &
                 "AND CVD_Account_Code = '" & strAcctCode & "' GROUP BY CVD_SubAccount_Code"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Check/MC Voucher Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("CVD_SubAccount_Code") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(CVD_DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CVD_CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("CVD_SubAccount_Code"), GetSubAcctName(reader.Item("CVD_Account_Code"), reader.Item("CVD_SubAccount_Code")), Format(reader.Item("SUM(CVD_DR)"), "n2"), Format(reader.Item("SUM(CVD_CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()



        'Generate from SL PCV
        strsql = "SELECT *, SUM(PCA_DR), SUM(PCA_CR) FROM v_tb_appca " &
                "WHERE PCR_PostDate BETWEEN " &
                 "'" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                 "AND PCA_Account_Code = '" & strAcctCode & "' GROUP BY PCA_SubAccount_Code"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Posted PCV Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("PCA_SubAccount_Code") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(PCA_DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(PCA_CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("PCA_SubAccount_Code"), GetSubAcctName(reader.Item("PCA_Account_Code"), reader.Item("PCA_SubAccount_Code")), Format(reader.Item("SUM(PCA_DR)"), "n2"), Format(reader.Item("SUM(PCA_CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()



        'Generate from RELEASED PCV
        strsql = "SELECT *, SUM(PCAR_DR), SUM(PCAR_CR) FROM v_tb_appcar " &
                 "WHERE PCR_ReleaseDate BETWEEN " &
                 "'" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                 "AND PCAR_Account_Code = '" & strAcctCode & "' GROUP BY PCAR_SubAccount_Code"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Released PCV Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("PCAR_SubAccount_Code") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(PCAR_DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(PCAR_CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("PCAR_SubAccount_Code"), GetSubAcctName(reader.Item("PCAR_Account_Code"), reader.Item("PCAR_SubAccount_Code")), Format(reader.Item("SUM(PCAR_DR)"), "n2"), Format(reader.Item("SUM(PCAR_CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        ''=======
        strsql = "SELECT *, SUM(CVD_DR), SUM(CVD_CR) from v_tb_apcvdl WHERE LiquidatedDate BETWEEN " &
                 "'" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd") & "' " &
                 "AND CVD_Account_Code = '" & strAcctCode & "' GROUP BY CVD_SubAccount_Code"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Adjusted Check/MC Voucher Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            Application.DoEvents()
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("CVD_SubAccount_Code") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(CVD_DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CVD_CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("CVD_SubAccount_Code"), GetSubAcctName(reader.Item("CVD_Account_Code"), reader.Item("CVD_SubAccount_Code")), Format(reader.Item("SUM(CVD_DR)"), "n2"), Format(reader.Item("SUM(CVD_CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '===============================================GENERAL JOURNAL VOUCHER=================================
        'Generate from General Journal
        strsql = "SELECT gja.GJA_SubAccount_Code, gja.GJA_SubAccount_Title, SUM(gja.GJA_DR), SUM(gja.GJA_CR) FROM " &
                 "gja INNER JOIN gjv ON gja.GJA_GJVNbr = gjv.GJV_Nbr WHERE gjv.GJV_PostDate BETWEEN " &
                 "'" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                 "AND gja.GJA_Account_Code = '" & strAcctCode & "' AND gjv.GJV_Cancel = '" & 0 & "' GROUP BY gja.GJA_SubAccount_Code"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "General Journal Voucher Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("GJA_SubAccount_Code") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(gja.GJA_DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(gja.GJA_CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("GJA_SubAccount_Code"), reader.Item("GJA_SubAccount_Title"), Format(reader.Item("SUM(gja.GJA_DR)"), "n2"), Format(reader.Item("SUM(gja.GJA_CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '=====================================DEPOSITS RECEIPT===========================================
        'Generate from Deposit Receipt
        strsql = "SELECT dra.DRA_SubAccount_Code, dra.DRA_SubAccount_Title, SUM(dra.DRA_DR), SUM(dra.DRA_CR) FROM " &
                 "dra INNER JOIN drv ON dra.DRA_Nbr = drv.DRV_Nbr WHERE drv.DRV_PostDate BETWEEN " &
                 "'" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
                 "AND (dra.DRA_Account_Code = '" & strAcctCode & "') AND drv.DRV_Cancel = '" & 0 & "' GROUP BY dra.DRA_SubAccount_Code"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Deposits Receipt Voucher Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("DRA_SubAccount_Code") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(dra.DRA_DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(dra.DRA_CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("DRA_SubAccount_Code"), reader.Item("DRA_SubAccount_Title"), Format(reader.Item("SUM(dra.DRA_DR)"), "n2"), Format(reader.Item("SUM(dra.DRA_CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()

        '=====================================================ADAVNCES===========================================
        'Generate from Advances
        strsql = "SELECT *, SUM(DR), SUM(CR) from v_tb_aradv WHERE " &
             "PrepDate BETWEEN '" & Format$(Me.dtFrom1.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo1.Value, "yyyy-MM-dd 23:59:59") & "' " &
             "AND AcctCode = '" & strAcctCode & "' GROUP BY SubAcctCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Application.DoEvents()
        Me.lblCurrentProgressSub.Text = "Currently Loading " & vbNewLine & "Client Advances Info...."

        Application.DoEvents()
        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 5
        Me.lblPercentageSub.Text = Format((Me.ProgressBar2.Value / 100) * 100, "n0") & "%"

        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        While reader.Read
            x = False
            For i = 0 To dtgSubAcct.Rows.Count - 1
                With dtgSubAcct.Rows(i)
                    If .Cells(1).Value = reader.Item("SubAcctCode") Then
                        .Cells(3).Value = Format(Val(reader.Item("SUM(DR)") + .Cells(3).Value), "n2")
                        .Cells(4).Value = Format(Val(reader.Item("SUM(CR)") + .Cells(4).Value), "n2")
                        x = True
                    End If
                End With
            Next
            If x = False Then
                Me.dtgSubAcct.Rows.Add(True, reader.Item("SubAcctCode"), GetSubAcctName(reader.Item("AcctCode"), reader.Item("SubAcctCode")), Format(reader.Item("SUM(DR)"), "n2"), Format(reader.Item("SUM(CR)"), "n2"), "")
            End If
        End While
        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()
    End Sub
    Private Function GetSubAcctName(ByVal acctcode As String, ByVal subacctcode As String) As String
        GetSubAcctName = ""
        Dim strsql As String = "SELECT * from lib_subacctcode WHERE Account_Code like '" & acctcode & "' AND SubAccount_Code like '" & subacctcode & "'"
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            GetSubAcctName = reader.Item("SubAccount_Title")
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn.Close()
    End Function

    Public Function SumAmountDR(ByVal str As String, ByVal dg As DataGridView) As Double
        SumAmountDR = 0
        Dim i As Integer
        Dim h As DataGridViewRow

        Select Case str

            Case "Sub"
                For i = 0 To dg.Rows.Count - 1
                    h = dg.Rows(i)
                    If Not Len(h.Cells(3).Value) = 0 Then
                        If h.Cells(0).Value = True Then
                            SumAmountDR = SumAmountDR + h.Cells(3).Value
                        End If

                    End If
                Next

                Return SumAmountDR


            Case "Summary"
                For i = 0 To dg.Rows.Count - 1
                    h = dg.Rows(i)
                    If Not Len(h.Cells(6).Value) = 0 Then
                        SumAmountDR = SumAmountDR + h.Cells(6).Value
                    End If
                Next

                Return SumAmountDR

        End Select


    End Function

    Private Sub dtgSubAcct_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgSubAcct.CellContentClick

    End Sub

    Public Function SumAmountCR(ByVal str As String, ByVal dg As DataGridView) As Double
        SumAmountCR = 0
        Dim i As Integer
        Dim h As DataGridViewRow

        Select Case str

            Case "Sub"
                For i = 0 To dg.Rows.Count - 1
                    h = dg.Rows(i)
                    If Not Len(h.Cells(4).Value) = 0 Then
                        If h.Cells(0).Value = True Then
                            SumAmountCR = SumAmountCR + h.Cells(4).Value
                        End If

                    End If
                Next

                Return SumAmountCR

            Case "Summary"
                For i = 0 To dg.Rows.Count - 1
                    h = dg.Rows(i)
                    If Not Len(h.Cells(7).Value) = 0 Then
                        SumAmountCR = SumAmountCR + h.Cells(7).Value

                    End If
                Next

                Return SumAmountCR

        End Select


    End Function

    Private Sub btExportToExcel_Click(sender As Object, e As EventArgs) Handles btExportToExcel.Click
        If dtgTBEntry1.Rows.Count > 0 Then
            ExportToExcel(Me.dtgTBEntry1)
        Else
            MsgBox("Nothing to export!", MsgBoxStyle.Exclamation, "System Message")
        End If
    End Sub

    Private Sub dtgSubAcct_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgSubAcct.CellDoubleClick
        SubAcctCode = Me.dtgSubAcct.CurrentRow.Cells(1).Value
        SubAcctTitle = Me.dtgSubAcct.CurrentRow.Cells(2).Value

        'frmGLRevisedListItem.dtgList1.Rows.Clear()
        'frmGLRevisedListItem.dtgList2.Rows.Clear()

        'frmGLRevisedListItem.Text = "Main Account : " & MainAcctTitle & " ; " & "Subsidiary : " & SubAcctTitle
        'frmGLRevisedListItem.GenerateListItem(MainAcctCode, SubAcctCode)
        'frmGLRevisedListItem.ShowDialog()

    End Sub

    Private Sub btExportToExcelSubsidiary_Click(sender As Object, e As EventArgs) Handles btExportToExcelSubsidiary.Click
        If dtgSubAcct.Rows.Count > 0 Then
            ExportToExcelSubsidiary(Me.dtgSubAcct)
        Else
            MsgBox("Nothing to export!", MsgBoxStyle.Exclamation, "System Message")
        End If
    End Sub

    Public Sub ExportToExcel(ByVal dg As DataGridView)

        Dim oBook As Object
        Dim j As Integer = 0
        Dim dtCurrent As Date = GetServerDate()
        Dim xlFileName As String
        Dim BookNo As String = ""
        Dim oExcel = CreateObject("Excel.Application")

        'oBook = oExcel.WorkBooks.Open("C:\Users\jasonconfused\Documents\ACESTAR GL ACCOUNT.xlsx")
        oBook = oExcel.WorkBooks.Open("\\192.168.8.2\it\AISC\aisc\32bit\accounting\render\ACESTAR GL ACCOUNT.xlsx")

        oExcel.Cells(4, 1) = "FROM : " & Format(Me.dtFrom1.Value, "yyyy-MM-dd")
        oExcel.Cells(5, 1) = "TO : " & Format(Me.dtTo1.Value, "yyyy-MM-dd")

        xlFileName = " from " & Format(Me.dtFrom1.Value, "yyyy-MM-dd") & " to " & Format(Me.dtTo1.Value, "yyyy-MM-dd") & Format(dtCurrent, "yyyy") & Format(dtCurrent, "MM") & Format(dtCurrent, "dd") & Format(dtCurrent, "hh") & Format(dtCurrent, "mm")

        oExcel.Cells(7, 1) = "Prepared By: " & strCurrentUser
        oExcel.Cells(8, 1) = "Date Extracted: " & dtCurrent

        oExcel.Cells(4, 3) = Me.lblDebit1.Text
        oExcel.Cells(5, 3) = Me.lblCredit1.Text

        oExcel.Cells(4, 3).HorizontalAlignment = -4152
        oExcel.Cells(5, 3).HorizontalAlignment = -4152

        For i As Integer = 0 To dg.Rows.Count - 1
            With dg.Rows(i)
                If dg(2, i).Value <> Nothing Then
                    j = j + 1

                    oExcel.Cells(j + 10, 1) = "'" & dg(2, i).Value.ToString()
                    oExcel.Cells(j + 10, 2) = "'" & dg(3, i).Value
                    oExcel.Cells(j + 10, 3) = "'" & dg(4, i).Value

                    oExcel.Cells(j + 10, 4) = "'" & dg(5, i).Value
                    oExcel.Cells(j + 10, 5) = "'" & dg(7, i).Value

                    oExcel.Cells(j + 10, 2).HorizontalAlignment = -4152
                    oExcel.Cells(j + 10, 3).HorizontalAlignment = -4152
                    oExcel.Cells(j + 10, 4).HorizontalAlignment = -4152
                    oExcel.Cells(j + 10, 5).HorizontalAlignment = -4152

                    Dim iBorder As Integer = 0
                    For iBorder = 1 To 5
                        oExcel.cells(j + 10, iBorder).Borders.LineStyle = 1
                        ' oExcel.Cells(j + 10, iBorder).Interior.ColorIndex = 16
                    Next
                End If
            End With
        Next

        ' oExcel.Columns.AutoFit()

        If Not Directory.Exists("C:\ACESTAR GL ACCOUNT") Then
            Directory.CreateDirectory("C:\ACESTAR GL ACCOUNT")
        End If

        MsgBox("Finished Loading...", MsgBoxStyle.Information, "System Message")

        MsgBox("You can find the file C:\ACESTAR GL ACCOUNT\" & xlFileName & ".xlsx")

        oBook.SaveAs("C:\ACESTAR GL ACCOUNT\" & xlFileName & ".xlsx")

        oExcel.Visible = True
    End Sub

    Private Sub btExportToExcelSummary_Click(sender As Object, e As EventArgs) Handles btExportToExcelSummary.Click
        If dtgSummary.Rows.Count > 0 Then
            ExportToExcelSummary(Me.dtgSummary)
        Else
            MsgBox("Nothing to export!", MsgBoxStyle.Exclamation, "System Message")
        End If
    End Sub

    Public Sub ExportToExcelSubsidiary(ByVal dg As DataGridView)
        Dim oBook As Object
        Dim j As Integer = 0
        Dim dtCurrent As Date = GetServerDate()
        Dim xlFileName As String
        Dim BookNo As String = ""
        Dim oExcel = CreateObject("Excel.Application")

        'oBook = oExcel.WorkBooks.Open("C:\Users\jasonconfused\Documents\ACESTAR GL SUBSIDIARY.xlsx")
        oBook = oExcel.WorkBooks.Open("\\192.168.8.2\it\AISC\aisc\32bit\accounting\render\ACESTAR GL SUBSIDIARY.xlsx")

        oExcel.Cells(1, 1) = "ACESTAR - SUBSIDIARY LEDGER OF " & MainAcctTitle

        oExcel.Cells(4, 1) = "FROM : " & Format(Me.dtFrom1.Value, "yyyy-MM-dd")
        oExcel.Cells(5, 1) = "TO : " & Format(Me.dtTo1.Value, "yyyy-MM-dd")

        xlFileName = " from " & Format(Me.dtFrom1.Value, "yyyy-MM-dd") & " to " & Format(Me.dtTo1.Value, "yyyy-MM-dd") & Format(dtCurrent, "yyyy") & Format(dtCurrent, "MM") & Format(dtCurrent, "dd") & Format(dtCurrent, "hh") & Format(dtCurrent, "mm")

        oExcel.Cells(7, 1) = "Prepared By: " & strCurrentUser
        oExcel.Cells(8, 1) = "Date Extracted: " & dtCurrent

        oExcel.Cells(4, 3) = Me.lblSubDR.Text
        oExcel.Cells(5, 3) = Me.lblSubCR.Text

        oExcel.Cells(4, 3).HorizontalAlignment = -4152
        oExcel.Cells(5, 3).HorizontalAlignment = -4152

        For i As Integer = 0 To dg.Rows.Count - 1
            With dg.Rows(i)
                If dg(0, i).Value = True Then
                    j = j + 1

                    oExcel.Cells(j + 10, 1) = "'" & dg(2, i).Value.ToString()
                    oExcel.Cells(j + 10, 2) = "'" & dg(3, i).Value
                    oExcel.Cells(j + 10, 3) = "'" & dg(4, i).Value

                    oExcel.Cells(j + 10, 2).HorizontalAlignment = -4152
                    oExcel.Cells(j + 10, 3).HorizontalAlignment = -4152

                    Dim iBorder As Integer = 0
                    For iBorder = 1 To 3
                        oExcel.cells(j + 10, iBorder).Borders.LineStyle = 1
                        ' oExcel.Cells(j + 10, iBorder).Interior.ColorIndex = 16
                    Next
                End If
            End With
        Next

        ' oExcel.Columns.AutoFit()

        If Not Directory.Exists("C:\ACESTAR GL SUBSIDIARY") Then
            Directory.CreateDirectory("C:\ACESTAR GL SUBSIDIARY")
        End If

        MsgBox("Finished Loading...", MsgBoxStyle.Information, "System Message")

        MsgBox("You can find the file C:\ACESTAR GL SUBSIDIARY\" & xlFileName & ".xlsx")

        oBook.SaveAs("C:\ACESTAR GL SUBSIDIARY\" & xlFileName & ".xlsx")

        oExcel.Visible = True
    End Sub

    Public Sub ExportToExcelSummary(ByVal dg As DataGridView)
        Dim oBook As Object
        Dim j As Integer = 0
        Dim dtCurrent As Date = GetServerDate()
        Dim xlFileName As String
        Dim BookNo As String = ""
        Dim oExcel = CreateObject("Excel.Application")

        'oBook = oExcel.WorkBooks.Open("C:\Users\jasonconfused\Documents\ACESTAR GL SUMMARY.xlsx")
        oBook = oExcel.WorkBooks.Open("\\192.168.8.2\it\AISC\aisc\32bit\accounting\render\ACESTAR GL SUMMARY.xlsx")

        oExcel.Cells(4, 1) = "FROM : " & Format(Me.dtFrom1.Value, "yyyy-MM-dd")
        oExcel.Cells(5, 1) = "TO : " & Format(Me.dtTo1.Value, "yyyy-MM-dd")

        xlFileName = " from " & Format(Me.dtFrom1.Value, "yyyy-MM-dd") & " to " & Format(Me.dtTo1.Value, "yyyy-MM-dd") & Format(dtCurrent, "yyyy") & Format(dtCurrent, "MM") & Format(dtCurrent, "dd") & Format(dtCurrent, "hh") & Format(dtCurrent, "mm")

        oExcel.Cells(7, 1) = "Prepared By: " & strCurrentUser
        oExcel.Cells(8, 1) = "Date Extracted: " & dtCurrent

        'oExcel.Cells(4, 3) = Me.lblSummaryDR.Text
        'oExcel.Cells(5, 3) = Me.lblSummaryCR.Text

        'oExcel.Cells(4, 3).HorizontalAlignment = -4152
        'oExcel.Cells(5, 3).HorizontalAlignment = -4152

        For i As Integer = 0 To dg.Rows.Count - 1
            With dg.Rows(i)

                'If Me.dtgSubAcct.CurrentRow.Cells(0).Value = False Then

                '    If oExcel.Cells(4).Value = Me.dtgSubAcct.CurrentRow.Cells(2).Value Then
                '        oExcel.Visible = False
                '    End If

                'ElseIf Me.dtgSubAcct.CurrentRow.Cells(0).Value = True Then

                '    If oExcel.Cells(4).Value = Me.dtgSubAcct.CurrentRow.Cells(2).Value Then
                '        oExcel.Visible = True
                '    End If
                'End If

                If dg(0, i).Visible = True Then
                    j = j + 1

                    oExcel.Cells(j + 10, 1) = "'" & dg(2, i).Value.ToString()
                    oExcel.Cells(j + 10, 2) = "'" & dg(1, i).Value
                    oExcel.Cells(j + 10, 3) = "'" & dg(0, i).Value
                    oExcel.Cells(j + 10, 4) = "'" & dg(3, i).Value
                    oExcel.Cells(j + 10, 5) = "'" & dg(4, i).Value
                    oExcel.Cells(j + 10, 6) = "'" & dg(5, i).Value
                    oExcel.Cells(j + 10, 7) = "'" & dg(6, i).Value
                    oExcel.Cells(j + 10, 8) = "'" & dg(7, i).Value

                    oExcel.Cells(j + 10, 7).HorizontalAlignment = -4152
                    oExcel.Cells(j + 10, 8).HorizontalAlignment = -4152

                    Dim iBorder As Integer = 0
                    For iBorder = 1 To 8
                        oExcel.cells(j + 10, iBorder).Borders.LineStyle = 1
                        ' oExcel.Cells(j + 10, iBorder).Interior.ColorIndex = 16
                    Next
                End If

            End With
        Next

        ' oExcel.Columns.AutoFit()

        If Not Directory.Exists("C:\ACESTAR GL SUMMARY") Then
            Directory.CreateDirectory("C:\ACESTAR GL SUMMARY")
        End If

        MsgBox("Finished Loading...", MsgBoxStyle.Information, "System Message")

        MsgBox("You can find the file C:\ACESTAR GL SUMMARY\" & xlFileName & ".xlsx")

        oBook.SaveAs("C:\ACESTAR GL SUMMARY\" & xlFileName & ".xlsx")

        oExcel.Visible = True
    End Sub

    Private Sub dtgSubAcct_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgSubAcct.CellEndEdit
        'Dim count As Integer
        'Dim oExcel = CreateObject("C:\Users\AISC IT\Documents\ACESTAR GL SUMMARY.xlsx")
        'Dim oBook As Object
        'Dim oExcelSummary As String = ("C:\Users\AISC IT\Documents\ACESTAR GL SUMMARY.xlsx")
        'Dim i As Integer = 0
        'Dim h As DataGridViewRow

        'For i = 0 To Me.dtgSummary.Rows.Count - 1
        '    h = Me.dtgSummary.Rows(i)

        '    If Me.dtgSubAcct.CurrentRow.Cells(0).Value = False Then
        '        If h.Cells(4).Value = Me.dtgSubAcct.CurrentRow.Cells(2).Value Then
        '            h.Visible = False
        '        End If
        '    Else
        '        h.Visible = True
        '    End If

        '    If i = Nothing Then
        '        h.Visible = False
        '        MsgBox("No records in the list", MsgBoxStyle.Exclamation, "Check the list box")
        '    End If

        'Next

        'Dim i As Integer = 0
        'Dim count As Integer

        'Dim i2 As Integer = 0
        'Dim h2 As DataGridViewRow

        'For i2 = 0 To Me.dtgSummary.Rows.Count - 1
        '    h2 = Me.dtgSummary.Rows(i2)

        '    If h2.Visible = True Then
        'count = count + 1
        '    Else
        'count = count - 1
        '    End If
        'Next


        Dim dgv As DataGridViewRow
        For i = 0 To Me.dtgSummary.Rows.Count - 1
            dgv = Me.dtgSummary.Rows(i)

            If Me.dtgSubAcct.CurrentRow.Cells(0).Value = False Then
                'If Me.dtgSubAcct.CurrentRow.Cells(0).Value = -1 Then
                '    MsgBox("Dont should be empty", MsgBoxStyle.Exclamation, "System Message")
                'End If

                If dgv.Cells(5).Value = Me.dtgSubAcct.CurrentRow.Cells(2).Value Then
                    dgv.Visible = False

                    ' Me.lblSubDR.Text = dtgSubAcct.CurrentRow.Cells(3).Value
                    'oExcel.visible = False
                    count = count - 1
                End If

                'If dgv.Cells(4).Value = oExcel.cells(4).value Then
                '    oExcel.visible = False
                'End If

            ElseIf Me.dtgSubAcct.CurrentRow.Cells(0).Value = True Then

                'Me.dtgSubAcct.CurrentRow.Cells(0).Value = 1
                'dgv.Cells(4).Value = Me.dtgSubAcct.CurrentRow.Cells(2).Value
                'dgv.Visible = True
                If dgv.Cells(5).Value = Me.dtgSubAcct.CurrentRow.Cells(2).Value Then
                    'oExcel.visible = True
                    dgv.Visible = True
                    'Me.lblSubDR.Text = dtgSubAcct.CurrentRow.Cells(3).Value
                    count = count + 1
                End If

                'If dgv.Cells(4).Value = oExcel.cells(4).value Then
                '    oExcel.visible = True
                'End If

            End If
        Next

        Me.lblSubDR.Text = Format(SumAmountDR("Sub", Me.dtgSubAcct), "n2")
        Me.lblSubCR.Text = Format(SumAmountCR("Sub", Me.dtgSubAcct), "n2")
        'Me.TextBox1.Text = count

    End Sub
End Class