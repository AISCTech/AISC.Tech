Imports System.IO
Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmAcknowledgementReceipt
    Implements ICommonFunction
    Private EnableButtons As New clsEnableToolstripObjects()
    Private Sub frmAcknowledgementReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        PopComboSQL(cboBank, "SELECT Name FROM lib_bank ORDER BY Name", "Name")

        Select Case Me.Tag
            Case "Exp"
                PopComboSQL(Me.cboClient, "SELECT DISTINCT BilledTo FROM bill_expsoa_main " &
                            "WHERE SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                            " ORDER BY BilledTo", "BilledTo")

                Me.optExp.Checked = True
            Case "ImpB"
                PopComboSQL(Me.cboClient, "SELECT DISTINCT BilledTo FROM bill_impsoa_main " &
                            "WHERE SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                            " ORDER BY BilledTo", "BilledTo")

                Me.optImpB.Checked = True
            Case "ImpF"
                PopComboSQL(Me.cboClient, "SELECT DISTINCT Client FROM bill_impf_main " &
                            "WHERE SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                            " ORDER BY Client", "Client")

                Me.optImpF.Checked = True
            Case "ImpDCAF"
                PopComboSQL(Me.cboClient, "SELECT DISTINCT Client FROM bill_impf_main INNER JOIN bill_impd_main ON bill_impf_main.RefNo = bill_impd_main.BillRefNo " &
                            "WHERE bill_impd_main.DRCRNo IS NOT NULL AND LENGTH(bill_impd_main.DRCRNo) > 0 AND bill_impd_main.Posted = TRUE AND bill_impd_main.Cancel = FALSE " &
                            " ORDER BY Client", "Client")

                Me.optImpDCAF.Checked = True
        End Select

        Me.tslblPrepBy.Text = ""
        Me.tslblPrepDate.Text = ""
        Me.tslblStatus.Text = ""
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub
    Public ClientTin As String = ""
    Public ClientAddress As String = ""
    Public ClientBStyle As String = ""
    Public HBL As String = ""
    Private Sub ClearAll()
        'Me.txtORNo.Text = ""
        Me.dtgORInv.Rows.Clear()
        Me.txtTotalBilling.Text = ""
        Me.txtPaymentTotal.Text = ""
        Me.txtCWTTotal.Text = ""
        Me.txtOthChargesTotal.Text = ""
        Me.txtBalanceTotal.Text = ""
        Me.txtOverPayment.Text = ""
        Me.txtAmtInWords.Text = ""
        Me.txtCashAmt.Text = ""
        Me.txtChkAmt.Text = ""
        Me.txtChkNo.Text = ""
        Me.cboBank.SelectedIndex = -1
        Me.dtgAcctgTitle.Rows.Clear()
        Me.tslblPrepBy.Text = ""
        Me.tslblPrepDate.Text = ""
        Me.tslblStatus.Text = ""
        Me.dtgBkgNbr.Rows.Clear()

    End Sub

    Private Function GetAllPaidAmtPerBillNo(ByVal strRefNo As String) As Double
        GetAllPaidAmtPerBillNo = 0
        Dim strsql As String = "SELECT SUM(AmtPaid), SUM(CWT), SUM(OthChrg) FROM ar_invoice " &
                               "INNER JOIN ar_main ON ar_invoice.ORNo = ar_main.ORNo " &
                               "WHERE ar_invoice.RefNo = '" & strRefNo & "' AND ar_main.Cancel = FALSE"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            If Not IsDBNull(reader.Item("SUM(AmtPaid)")) Or Not IsDBNull(reader.Item("SUM(CWT)")) Or Not IsDBNull(reader.Item("SUM(OthChrg)")) Then
                GetAllPaidAmtPerBillNo = reader.Item("SUM(AmtPaid)") + reader.Item("SUM(CWT)") + reader.Item("SUM(OthChrg)")
            End If
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Function
    Private Sub PopdtgAcctgEntry()
        'If Me.dtgPayments.Rows.Count = 0 Then Exit Sub

        Dim dblCash As Double = 0
        Dim dblCheck As Double = 0

        Me.dtgAcctgTitle.Rows.Clear()

        If (IsNumeric(Me.txtCashAmt.Text) = True Or IsNumeric(Me.txtChkAmt.Text) = True) And Me.chkBank.Checked = True Then
            If CDbl(Me.txtCashAmt.Text) > 0 Or CDbl(Me.txtChkAmt.Text) > 0 Then
                Dim strsql As String = "SELECT * from lib_bank WHERE Name like '" & cboBank.Text & "' AND Active = 1"
                Dim cnn As New MySqlConnection(strDBMaster)
                If cnn.State <> ConnectionState.Open Then cnn.Open()
                Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
                Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql2.ExecuteReader
                While reader2.Read
                    PopdtgAcctgEntryRow(reader2.Item("Account_Code"), reader2.Item("SubAccount_Code"), CDbl(Me.txtChkAmt.Text) + CDbl(Me.txtCashAmt.Text), "0.00")
                End While
                cmdsql2.Dispose()
                reader2.Close()
                cnn.Close()
            End If
        Else
            If IsNumeric(Me.txtCashAmt.Text) = True Then
                If CDbl(Me.txtCashAmt.Text) > 0 Then
                    PopdtgAcctgEntryRow("1010", "2", CDbl(Me.txtCashAmt.Text), "0.00")
                End If
            End If
            If IsNumeric(Me.txtChkAmt.Text) = True Then
                If CDbl(Me.txtChkAmt.Text) > 0 Then
                    PopdtgAcctgEntryRow("1120", "1", CDbl(Me.txtChkAmt.Text), "0.00")
                End If
            End If
        End If

        If Me.tslblPrefix.Text = "BCRMNL" Then
            If IsNumeric(Me.txtCWTTotal.Text) = True Then
                If CDbl(Me.txtCWTTotal.Text) > 0 Then
                    'If Mid$(Trim$(Me.txtHBL.Text), 1, 3) = "IMP" Then
                    If Me.Tag = "ImpF" And Me.Tag = "ImpB" Then
                        PopdtgAcctgEntryRow("2020", "1", CDbl(Me.txtCWTTotal.Text) + CDbl(Me.txtOthChargesTotal.Text), "0.00")
                    ElseIf Me.Tag = "Exp" Then
                        PopdtgAcctgEntryRow("2020", "2", CDbl(Me.txtCWTTotal.Text) + CDbl(Me.txtOthChargesTotal.Text), "0.00")
                    End If
                End If

                If IsNumeric(Me.txtTotalBilling.Text) = True Then
                    If CDbl(Me.txtTotalBilling.Text) > 0 Then
                        If Me.Tag = "ImpF" And Me.Tag = "ImpB" Then
                            PopdtgAcctgEntryRow("1140", "1", "0.00", CDbl(Me.txtPaymentTotal.Text) + CDbl(txtCWTTotal.Text) + CDbl(Me.txtOthChargesTotal.Text))
                        ElseIf Me.Tag = "Exp" Then
                            PopdtgAcctgEntryRow("1140", "2", "0.00", CDbl(Me.txtPaymentTotal.Text) + CDbl(txtCWTTotal.Text) + CDbl(Me.txtOthChargesTotal.Text))
                        End If
                    End If
                End If
            End If
        Else
            If Mid$(lblPrefix.Text, 1, 3) = "BEX" Then
                If IsNumeric(Me.txtTotalBilling.Text) = True Then
                    If CDbl(Me.txtTotalBilling.Text) > 0 Then
                        PopdtgAcctgEntryRow("1150", "2", "0.00", CDbl(Me.txtPaymentTotal.Text) + CDbl(Me.txtCWTTotal.Text))
                    End If
                End If
                If IsNumeric(Me.txtCWTTotal.Text) = True Then
                    If CDbl(Me.txtCWTTotal.Text) > 0 Then
                        PopdtgAcctgEntryRow("1240", "2", CDbl(Me.txtCWTTotal.Text), "0.00")
                    End If
                End If
            Else
                If IsNumeric(Me.txtTotalBilling.Text) = True Then
                    If CDbl(Me.txtTotalBilling.Text) > 0 Then
                        PopdtgAcctgEntryRow("1150", "1", "0.00", CDbl(Me.txtPaymentTotal.Text) + CDbl(Me.txtCWTTotal.Text))
                    End If
                End If
                If IsNumeric(Me.txtCWTTotal.Text) = True Then
                    If CDbl(Me.txtCWTTotal.Text) > 0 Then
                        PopdtgAcctgEntryRow("1240", "1", CDbl(Me.txtCWTTotal.Text), "0.00")
                    End If
                End If
            End If
        End If

        ComputeDRCR()
    End Sub

    Private Sub PopdtgAcctgEntryRow(ByVal strCode As String, ByVal strSubCode As String, ByVal dblDR As Double, ByVal dblCR As Double)
        Dim strsql As String = "SELECT lib_acctcode.*, lib_subacctcode.* FROM lib_acctcode LEFT JOIN lib_subacctcode ON lib_acctcode.Account_Code = lib_subacctcode.Account_Code" &
                                " WHERE lib_acctcode.Account_Code = '" & strCode & "' AND lib_subacctcode.SubAccount_Code = '" & strSubCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySqlDataReader = cmdsql.ExecuteReader
        Dim strDept As String, strList As String, strShip As String

        strShip = ""
        strList = ""
        strDept = ""

        While reader.Read
            If reader.Item("SubAccount_Dept") = True Then
                strDept = "Import Forwarding"
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
        cnnDBMaster.Close()
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



    Private Sub SummaryReportAR(ByVal i As Integer, ByVal ARORNo As String, ByVal ARAmt As Double, ByVal cash As Double,
                                ByVal check As Double, ByVal total As Double, ByVal dtPrep As Date)
        Dim oBook As Object
        'Dim appFileName As String = ""
        Dim j As Integer = 2
        Dim dtCurrent As Date = GetServerDate()
        Dim xlFileName As String

        Dim oExcel = CreateObject("Excel.Application")
        oBook = oExcel.WorkBooks.Open(Application.StartupPath & "\Excel File\SummaryReport.xls")
        xlFileName = "SummaryReport" & Format(dtCurrent, "yyyy") & Format(dtCurrent, "MM") & Format(dtCurrent, "dd") & Format(dtCurrent, "hh") & Format(dtCurrent, "mm")

        oExcel.Cells(i, 1) = "AR No."
        oExcel.Cells(i, 2) = "A.R. Amount"
        oExcel.Cells(i, 3) = "Paid Cash"
        oExcel.Cells(i, 4) = "Paid Check"
        oExcel.Cells(i, 5) = "Total Paid"
        oExcel.Cells(i, 6) = "Date Prepared"

        oExcel.Cells(i + 3, 1) = ARORNo
        oExcel.Cells(i + 3, 2) = ARAmt
        oExcel.Cells(i + 3, 3) = cash
        oExcel.Cells(i + 3, 4) = check
        oExcel.Cells(i + 3, 5) = total
        oExcel.Cells(i + 3, 6) = dtPrep

        oExcel.Cells(3, 6).EntireColumn.NumberFormat = "dd/mm/yyyy"
        '.numberformat = "mmm dd, yyyy"
        'xlWorkSheet.Cells(3, 2).NumberFormat = "Text"
        oExcel.Columns.AutoFit()
        'xlWorkSheet.Columns
        ''xlWorkSheet.Range(3, 6).ColumnWidth = 300
        If Not Directory.Exists("C:\Summary Report") Then
            Directory.CreateDirectory("C:\Summary Report")
        End If

        MsgBox("Finished Loading...", MsgBoxStyle.Information, "System Message")

        MsgBox("You can find the file C:\Summary Report\" & xlFileName & ".xlsx")

        oBook.SaveAs("C:\Summary Report\" & xlFileName & ".xlsx")

        oExcel.Visible = True
    End Sub

    Private Function RetrieveOR(ByVal strOR As String) As Boolean
        RetrieveOR = False
        Me.lblPrefix.Text = ""
        Dim strsql As String = "SELECT ar_main.*, ar_invoice.* FROM (ar_main " &
                               "INNER JOIN ar_invoice ON ar_main.ORNo = ar_invoice.ORNo) " &
                               "WHERE ar_main.ORNo = '" & strOR & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        ClearAll()

        While reader.Read
            If reader.Item("ORNo") = strOR Then
                RetrieveOR = True
            Else
                reader.Close()
                Exit Function
            End If

            Me.Tag = reader.Item("Module")

            Select Case Me.Tag
                Case "Exp"
                    Me.optExp.Checked = True
                Case "ImpB"
                    Me.optImpB.Checked = True
                Case "ImpF"
                    Me.optImpF.Checked = True
                Case "ImpDCAF"
                    Me.optImpDCAF.Checked = True
            End Select

            Me.txtORNo.Text = reader.Item("ORNo")
            Me.cboClient.Text = reader.Item("Client")
            Me.txtCashAmt.Text = Format(reader.Item("CashAmt"), "n2")
            Me.txtChkAmt.Text = Format(reader.Item("CheckAmt"), "n2")
            Me.txtChkNo.Text = reader.Item("CheckNo")
            Me.chkBank.Checked = reader.Item("BankDeposit")
            Me.cboBank.Text = reader.Item("BankName")

            Me.dtgORInv.Rows.Add(reader.Item("RefNo"), "", "", reader.Item("CWT"), reader.Item("OthChrg"), reader.Item("AmtPaid"))

            Me.tslblPrepBy.Text = reader.Item("PrepBy")
            Me.tslblPrepDate.Text = reader.Item("PrepDate")

            If reader.Item("Cancel") = True Then
                Me.tslblStatus.Text = "Cancel"
            Else
                If reader.Item("Posted") = True Then
                    Me.tslblStatus.Text = "Posted"
                Else
                    Me.tslblStatus.Text = "Open"
                End If
            End If
        End While

        If Me.tslblStatus.Text = "Cancel" Then
            Me.tslblStatus.ForeColor = Color.Red
        Else
            Me.tslblStatus.ForeColor = Color.Blue
        End If
        reader.Close()
        cnn.Close()


        'Retrive Acctg Entry
        strsql = "SELECT ar_acctg_entry.AcctCode, lib_acctcode.Account_Title, ar_acctg_entry.SubAcctCode, " &
                 "lib_subacctcode.SubAccount_Title, ar_acctg_entry.SubAcctDept, ar_acctg_entry.SubAcctDeptName, " &
                 "ar_acctg_entry.SubAcctList, ar_acctg_entry.SubAcctListItem, ar_acctg_entry.SubAcctListItemName, " &
                 "ar_acctg_entry.DR, ar_acctg_entry.CR " &
                 "FROM ((ar_main INNER JOIN ar_acctg_entry ON ar_main.ORNo = ar_acctg_entry.ORNo) " &
                 "INNER JOIN lib_acctcode ON ar_acctg_entry.AcctCode = lib_acctcode.Account_Code) " &
                 "INNER JOIN lib_subacctcode ON ar_acctg_entry.AcctCode = lib_subacctcode.Account_Code AND ar_acctg_entry.SubAcctCode = lib_subacctcode.SubAccount_Code " &
                 "WHERE ar_acctg_entry.ORNo = '" & strOR & "'"

        Dim cnn2 As New MySqlConnection(strDBMaster)
        If cnn2.State <> ConnectionState.Open Then cnn2.Open()

        cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn2)

        reader = cmdSQL.ExecuteReader

        Me.dtgAcctgTitle.Rows.Clear()

        While reader.Read
            Me.dtgAcctgTitle.Rows.Add(reader.Item("AcctCode"), reader.Item("Account_Title"), reader.Item("SubAcctCode"),
                                      reader.Item("SubAccount_Title"), reader.Item("SubAcctDept"), reader.Item("SubAcctDeptName"),
                                      reader.Item("SubAcctList"), reader.Item("SubAcctListItem"), reader.Item("SubAcctListItemName"),
                                      reader.Item("DR"), reader.Item("CR"))
        End While

        reader.Close()
        cnn2.Close()

        ComputeDRCR()



        Dim ctrRow As Integer, dblAmtPaid As Double

        For ctrRow = 0 To Me.dtgORInv.Rows.Count - 1
            With Me.dtgORInv.Rows(ctrRow)
                dblAmtPaid = GetAllPaidAmtPerBillNo(.Cells(colORBillNo.Name).Value)
                Select Case Me.Tag
                    Case "Exp"
                        strsql = "SELECT SOANo, TotalSOA FROM bill_expsoa_main WHERE RefNo = '" & .Cells(colORBillNo.Name).Value & "' " &
                                    "AND SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE"
                    Case "ImpB"
                        strsql = "SELECT SOANo, TotalSOA FROM bill_impsoa_main WHERE RefNo = '" & .Cells(colORBillNo.Name).Value & "' " &
                                    "AND SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE"
                    Case "ImpF"
                        strsql = "SELECT SOANo AS SOANo, SOAAmt AS TotalSOA FROM bill_impf_main WHERE RefNo = '" & .Cells(colORBillNo.Name).Value & "' " &
                                    "AND SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE"
                    Case "ImpDCAF"
                        strsql = "SELECT DRCRNo AS SOANo, TotalDRPhp, TotalCRPhp FROM bill_impd_main INNER JOIN bill_impf_main ON bill_impd_main.BillRefNo = bill_impf_main.RefNo WHERE bill_impd_main.RefNo = '" & .Cells(colORBillNo.Name).Value & "' " &
                                    "AND DRCRNo IS NOT NULL AND LENGTH(DRCRNo) > 0 AND bill_impd_main.Posted = TRUE AND bill_impd_main.Cancel = FALSE"
                End Select

                cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                reader = cmdSQL.ExecuteReader

                While reader.Read
                    .Cells(colORInv.Name).Value = reader.Item("SOANo")
                    If Me.Tag = "ImpDCAF" Then
                        .Cells(colORBillAmt.Name).Value = Format(CDbl(reader.Item("TotalDRPhp") - reader.Item("TotalCRPhp")), "n2")
                    Else
                        .Cells(colORBillAmt.Name).Value = Format(CDbl(reader.Item("TotalSOA")), "n2")
                    End If

                    .Cells(colORBal.Name).Value = Format(CDbl(.Cells(colORBillAmt.Name).Value) - dblAmtPaid, "n2")
                End While

                reader.Close()
            End With
        Next
        cmdSQL.Dispose()

        dtgBkgNbr.Rows.Clear()

        strsql = "SELECT * from ar_booking WHERE ORNo like '" & strOR & "'"
        Dim cnn3 As New MySqlConnection(strDBMaster)
        If cnn3.State <> ConnectionState.Open Then cnn3.Open()
        cmdSQL = New MySqlCommand(strsql, cnn3)
        reader = cmdSQL.ExecuteReader
        While reader.Read
            dtgBkgNbr.Rows.Add(reader.Item("BookingNo"))
        End While
        cmdSQL.Dispose()
        reader.Close()
        cnn3.Close()

        If Me.dtgBkgNbr.Rows.Count = 0 Then
            For i As Integer = 0 To Me.dtgORInv.Rows.Count - 1
                LoadBooking(Me.dtgORInv.Rows(i).Cells("colORBillNo").Value)
            Next
        End If

        ComputeTotals()
    End Function

    Private Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blReset As Boolean, ByVal blSave As Boolean,
ByVal blPrintPreview As Boolean, ByVal blSearch As Boolean, ByVal blPost As Boolean, ByVal blCancel As Boolean,
ByVal blReOpen As Boolean, ByVal blUserInput As Boolean)
        With EnableButtons
            .NewEnabled = blNew
            .EditEnabled = blEdit
            .SaveEnabled = blSave
            .ResetEnabled = blReset
            .PrintPreviewEnabled = blPrintPreview
            .PostEnabled = blPost
            .CancelEnabled = blCancel
            .SearchEnabled = blSearch
            .ReOpen = blReOpen

            Me.gpBilling.Enabled = blUserInput
            Me.txtORNo.Enabled = blUserInput
            Me.cmdRemoveSRow.Enabled = blUserInput
            Me.gpORPayment.Enabled = blUserInput

            .UpdateEnabledButtons()

        End With


    End Sub

    Private Sub SaveOR()
        Try
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim dtCurrent As Date = GetServerDate()

            Dim strsql As String
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If Me.txtORNo.Enabled = True Then 'New
                strsql = "INSERT INTO ar_main (ORNo, Module, Client, CashAmt, CheckAmt, CheckNo, BankDeposit, BankName, PrepBy, PrepDate, Posted, PostBy, PostDate) " &
                     "VALUES (@ORNo, @Module, @Client, @CashAmt, @CheckAmt, @CheckNo, @BankDeposit, @BankName, @PrepBy, @PrepDate, @Posted, @PostBy, @PostDate)"

                cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@ORNo", Me.txtORNo.Text)
                    .AddWithValue("@Module", Me.Tag)
                    .AddWithValue("@Client", Me.cboClient.Text)
                    .AddWithValue("@CashAmt", CDbl(Me.txtCashAmt.Text))
                    .AddWithValue("@CheckAmt", CDbl(Me.txtChkAmt.Text))
                    .AddWithValue("@CheckNo", Me.txtChkNo.Text)
                    .AddWithValue("@BankDeposit", Me.chkBank.Checked)
                    .AddWithValue("@BankName", Me.cboBank.Text)
                    .AddWithValue("@PrepBy", CurrentUser)
                    .AddWithValue("@PrepDate", dtCurrent)
                    .AddWithValue("@Posted", True)
                    .AddWithValue("@PostBy", CurrentUser)
                    .AddWithValue("@PostDate", dtCurrent)
                End With

                cmdSQL.ExecuteNonQuery()
            Else 'Edit
                strsql = "UPDATE ar_main SET " &
                            "Client = @Client, " &
                            "CashAmt = @CashAmt, " &
                            "CheckAmt = @CheckAmt, " &
                            "CheckNo = @CheckNo, " &
                            "BankDeposit = @BankDeposit, " &
                            "BankName = @BankName, " &
                            "Posted = @Posted " &
                         "WHERE " &
                            "ORNo = '" & Me.txtORNo.Text & "'"

                cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@Client", Me.cboClient.Text)
                    .AddWithValue("@CashAmt", CDbl(Me.txtCashAmt.Text))
                    .AddWithValue("@CheckAmt", CDbl(Me.txtChkAmt.Text))
                    .AddWithValue("@CheckNo", Me.txtChkNo.Text)
                    .AddWithValue("@BankDeposit", Me.chkBank.Checked)
                    .AddWithValue("@BankName", Me.cboBank.Text)
                    .AddWithValue("@Posted", True)
                End With

                cmdSQL.ExecuteNonQuery()
            End If

            strsql = "DELETE FROM ar_invoice WHERE ORNo = '" & Me.txtORNo.Text & "'"

            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

            cmdSQL.ExecuteNonQuery()


            Dim ctrRow As Integer

            For ctrRow = 0 To Me.dtgORInv.Rows.Count - 1
                strsql = "INSERT INTO ar_invoice (ORNo, RefNo, AmtPaid, CWT, OthChrg) " &
                         "VALUES (@ORNo, @RefNo, @AmtPaid, @CWT, @OthChrg)"

                cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@ORNo", Me.txtORNo.Text)
                    .AddWithValue("@RefNo", Me.dtgORInv.Rows(ctrRow).Cells(colORBillNo.Name).Value)
                    .AddWithValue("@AmtPaid", CDbl(Me.dtgORInv.Rows(ctrRow).Cells(colORAmt.Name).Value))
                    .AddWithValue("@CWT", CDbl(Me.dtgORInv.Rows(ctrRow).Cells(colORCWT.Name).Value))
                    .AddWithValue("@OthChrg", CDbl(Me.dtgORInv.Rows(ctrRow).Cells(colOROthChrg.Name).Value))
                End With

                cmdSQL.ExecuteNonQuery()
            Next


            strsql = "DELETE FROM ar_acctg_entry WHERE ORNo = '" & Me.txtORNo.Text & "'"

            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

            cmdSQL.ExecuteNonQuery()

            'delete to tbl_generalledger
            DeleteToGLTable(Me.txtORNo.Text, 2)


            For ctrRow = 0 To Me.dtgAcctgTitle.Rows.Count - 1
                strsql = "INSERT INTO ar_acctg_entry (ORNo, AcctCode, SubAcctCode, SubAcctDept, SubAcctDeptName, " &
                                                    "SubAcctList, SubAcctListItem, SubAcctListItemName, DR, CR, GLClose) " &
                         "VALUES (@ORNo, @AcctCode, @SubAcctCode, @SubAcctDept, @SubAcctDeptName, " &
                                                    "@SubAcctList, @SubAcctListItem, @SubAcctListItemName, @DR, @CR, @GLClose)"

                cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@ORNo", Me.txtORNo.Text)
                    .AddWithValue("@AcctCode", Me.dtgAcctgTitle.Rows(ctrRow).Cells(colAcctCode.Name).Value)
                    .AddWithValue("@SubAcctCode", Me.dtgAcctgTitle.Rows(ctrRow).Cells(colSubAcctCode.Name).Value)
                    .AddWithValue("@SubAcctDept", Me.dtgAcctgTitle.Rows(ctrRow).Cells(colDept.Name).Value)
                    .AddWithValue("@SubAcctDeptName", Me.dtgAcctgTitle.Rows(ctrRow).Cells(colDeptName.Name).Value)
                    .AddWithValue("@SubAcctList", Me.dtgAcctgTitle.Rows(ctrRow).Cells(colList.Name).Value)
                    .AddWithValue("@SubAcctListItem", Me.dtgAcctgTitle.Rows(ctrRow).Cells(colListItem.Name).Value)
                    .AddWithValue("@SubAcctListItemName", Me.dtgAcctgTitle.Rows(ctrRow).Cells(colListItemName.Name).Value)
                    .AddWithValue("@DR", CDbl(Me.dtgAcctgTitle.Rows(ctrRow).Cells(colDR.Name).Value))
                    .AddWithValue("@CR", CDbl(Me.dtgAcctgTitle.Rows(ctrRow).Cells(colCR.Name).Value))
                    .AddWithValue("@GLClose", False)
                End With

                cmdSQL.ExecuteNonQuery()

                InsertToGLTable(2, GetGeneralLedgerModuleName(2), Me.txtORNo.Text, Me.dtgAcctgTitle.Rows(ctrRow).Cells(colAcctCode.Name).Value, GetAccountTitle(Me.dtgAcctgTitle.Rows(ctrRow).Cells(colAcctCode.Name).Value), Me.dtgAcctgTitle.Rows(ctrRow).Cells(colSubAcctCode.Name).Value, GetSubAccountTitle(Me.dtgAcctgTitle.Rows(ctrRow).Cells(colAcctCode.Name).Value, Me.dtgAcctgTitle.Rows(ctrRow).Cells(colSubAcctCode.Name).Value), CDbl(Me.dtgAcctgTitle.Rows(ctrRow).Cells(colDR.Name).Value), CDbl(Me.dtgAcctgTitle.Rows(ctrRow).Cells(colCR.Name).Value), Me.dtgAcctgTitle.Rows(ctrRow).Cells(colDept.Name).Value, Me.dtgAcctgTitle.Rows(ctrRow).Cells(colDeptName.Name).Value, Me.dtgAcctgTitle.Rows(ctrRow).Cells(colList.Name).Value, Me.dtgAcctgTitle.Rows(ctrRow).Cells(colListItem.Name).Value, Me.dtgAcctgTitle.Rows(ctrRow).Cells(colListItemName.Name).Value)

            Next

            cmdSQL.Dispose()


            strsql = "DELETE FROM ar_booking WHERE ORNo = '" & Me.txtORNo.Text & "'"

            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

            cmdSQL.ExecuteNonQuery()

            For i As Integer = 0 To dtgBkgNbr.Rows.Count - 1
                strsql = "INSERT INTO ar_booking (ORNo, BookingNo) " &
                         "VALUES (@ORNo, @bkgnbr)"

                cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@ORNo", Me.txtORNo.Text)
                    .AddWithValue("@bkgnbr", Me.dtgBkgNbr.Rows(i).Cells("colBookingNo").Value)
                End With

                cmdSQL.ExecuteNonQuery()
            Next

            cmdSQL.Dispose()

            'MsgBox("O.R. Saved", MsgBoxStyle.Information, "System Message")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "System Message")
        End Try
    End Sub

    Private Function CheckRequiredEntries() As Boolean
        CheckRequiredEntries = False

        If Len(Trim(Me.txtORNo.Text)) = 0 Then
            CheckRequiredEntries = True
            MsgBox("A.R. No. Required!", MsgBoxStyle.Exclamation, "System Message")
            Me.txtORNo.Focus()
            Exit Function
        End If

        Dim strsql As String = "SELECT * from ar2_main where ORNo like '" & Me.txtORNo.Text & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            CheckRequiredEntries = True
            MsgBox("A.R. No. already exists!", MsgBoxStyle.Exclamation, "System Message")
            Me.txtORNo.Focus()
            cmdsql.Dispose()
            reader.Close()
            cnnDBMaster.Close()
            Exit Function
        End While
        cmdsql.Dispose()
        reader.Close()
        cnnDBMaster.Close()

        strsql = "SELECT * from ar_adv_main where ARNo like '" & Me.txtORNo.Text & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        reader = cmdsql.ExecuteReader
        While reader.Read
            CheckRequiredEntries = True
            MsgBox("A.R. No. already exists!", MsgBoxStyle.Exclamation, "System Message")
            Me.txtORNo.Focus()
            cmdsql.Dispose()
            reader.Close()
            cnnDBMaster.Close()
            Exit Function
        End While
        cmdsql.Dispose()
        reader.Close()
        cnnDBMaster.Close()

        If Me.dtgORInv.Rows.Count = 0 Then
            CheckRequiredEntries = True
            MsgBox("Invoice No/s. Required!", MsgBoxStyle.Exclamation, "System Message")
            Exit Function
        End If

        If Not IsNumeric(Me.txtCashAmt.Text) Then
            CheckRequiredEntries = True
            MsgBox("Cash Amount must be a numeric value!", MsgBoxStyle.Exclamation, "System Message")
            Me.txtCashAmt.Focus()
            Exit Function
        End If

        If Not IsNumeric(Me.txtChkAmt.Text) Then
            CheckRequiredEntries = True
            MsgBox("Check Amount must be a numeric value!", MsgBoxStyle.Exclamation, "System Message")
            Me.txtChkAmt.Focus()
            Exit Function
        End If

        If CDbl(Me.txtCashAmt.Text) + CDbl(Me.txtChkAmt.Text) > CDbl(Me.txtPaymentTotal.Text) Then
            CheckRequiredEntries = True
            MsgBox("Paid amount is greater than payment in total!", MsgBoxStyle.Exclamation, "System Message")
            Me.txtChkAmt.Focus()
            Exit Function
        ElseIf CDbl(Me.txtCashAmt.Text) + CDbl(Me.txtChkAmt.Text) < CDbl(Me.txtPaymentTotal.Text) Then
            CheckRequiredEntries = True
            MsgBox("Paid amount is less than payment in total!", MsgBoxStyle.Exclamation, "System Message")
            Me.txtChkAmt.Focus()
            Exit Function
        End If

        If CDbl(Me.txtDRTotal.Text) <> CDbl(Me.txtCRTotal.Text) Then
            CheckRequiredEntries = True
            MsgBox("Debit amount not equal to credit amount!", MsgBoxStyle.Exclamation, "System Message")
            Me.txtChkAmt.Focus()
            Exit Function
        End If

        If CDbl(Me.txtChkAmt.Text) > 0 Then
            If Len(Trim(Me.txtChkNo.Text)) = 0 Then
                CheckRequiredEntries = True
                MsgBox("Check No. Required!", MsgBoxStyle.Exclamation, "System Message")
                Me.txtChkNo.Focus()
                Exit Function
            End If

            If Me.cboBank.SelectedIndex = -1 Then
                CheckRequiredEntries = True
                MsgBox("Please select Bank!", MsgBoxStyle.Exclamation, "System Message")
                Me.cboBank.Focus()
                Exit Function
            End If
        End If

        If Me.chkBank.Checked = True Then
            If Me.cboBank.SelectedIndex = -1 Then
                CheckRequiredEntries = True
                MsgBox("Please select Bank!", MsgBoxStyle.Exclamation, "System Message")
                Me.cboBank.Focus()
                Exit Function
            End If
        End If
    End Function

    Private Function CheckIfORAlreadyExist(ByVal strORNo As String) As Boolean
        CheckIfORAlreadyExist = False
        Dim strsql = "SELECT * FROM ar_main WHERE ar_main.ORNo = '" & strORNo & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader


        While reader.Read
            If reader.Item("ORNo") = strORNo Then
                CheckIfORAlreadyExist = True
            End If
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Function

    Public Sub ComputeTotals()
        Dim ctrRow As Integer
        Dim dblORAmt As Double = 0, dblCWT As Double = 0, dblOth As Double = 0, dblBal As Double = 0, dblBill As Double = 0

        For ctrRow = 0 To Me.dtgORInv.Rows.Count - 1
            With Me.dtgORInv.Rows(ctrRow)
                dblORAmt += CDbl(.Cells(colORAmt.Name).Value)
                dblCWT += CDbl(.Cells(colORCWT.Name).Value)
                dblOth += CDbl(.Cells(colOROthChrg.Name).Value)
                dblBal += CDbl(.Cells(colORBal.Name).Value)
                dblBill += CDbl(.Cells(colORBillAmt.Name).Value)
            End With
        Next

        Me.txtTotalBilling.Text = Format(dblBill, "n2")
        Me.txtPaymentTotal.Text = Format(dblORAmt, "n2")
        Me.txtCWTTotal.Text = Format(dblCWT, "n2")
        Me.txtOthChargesTotal.Text = Format(dblOth, "n2")
        If dblBal > 0 Then
            Me.txtBalanceTotal.Text = Format(dblBal, "n2")
            Me.txtOverPayment.Text = "0.00"
        ElseIf dblBal < 0 Then
            Me.txtBalanceTotal.Text = "0.00"
            Me.txtOverPayment.Text = Format(Math.Abs(dblBal), "n2")
        Else
            Me.txtBalanceTotal.Text = "0.00"
            Me.txtOverPayment.Text = "0.00"
        End If
    End Sub
    Private Sub LoadImpDCAFClientInvoice()
        Dim strsql As String = "SELECT * FROM bill_impd_main INNER JOIN bill_impf_main ON bill_impd_main.BillRefNo = bill_impf_main.RefNo WHERE Client = '" & Me.cboClient.Text & "' " &
                               "AND DRCRNo IS NOT NULL AND LENGTH(DRCRNo) > 0 AND bill_impd_main.Posted = TRUE AND bill_impd_main.Cancel = FALSE"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgBilling.Rows.Clear()

        While reader.Read
            Me.dtgBilling.Rows.Add(reader.Item("RefNo"), reader.Item("DRCRNo"), Format(reader.Item("TotalDRPhp") - reader.Item("TotalCRPhp"), "n2"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub
    Private Sub LoadImpFClientInvoice()
        Dim strsql As String = "SELECT * FROM bill_impf_main WHERE Client = '" & Me.cboClient.Text & "' " &
                               "AND SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgBilling.Rows.Clear()

        While reader.Read
            Me.dtgBilling.Rows.Add(reader.Item("RefNo"), reader.Item("SOANo"), Format(reader.Item("SOAAmt"), "n2"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub LoadImpBClientInvoice()
        Dim strsql As String = ""

        If Len(Me.txtRefNo.Text) = 0 Then
            strsql = "SELECT * FROM bill_impsoa_main WHERE BilledTo = '" & Me.cboClient.Text & "' " &
                     "AND SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE"
        Else
            If Me.optBillNo.Checked = True Then
                strsql = "SELECT * FROM bill_impsoa_main WHERE BilledTo = '" & Me.cboClient.Text & "' " &
                         "AND SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                         "AND RefNo LIKE '" & Me.lblPrefix.Text & Me.txtRefNo.Text & "%'"
            ElseIf Me.optInvNo.Checked = True Then
                strsql = "SELECT * FROM bill_impsoa_main WHERE BilledTo = '" & Me.cboClient.Text & "' " &
                         "AND SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                         "AND SOANo LIKE '" & Me.txtRefNo.Text & "%'"
            End If
        End If





        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgBilling.Rows.Clear()

        While reader.Read
            ' If reader.Item("TotalAmt") < 0 Then
            ' Me.dtgBilling.Rows.Add(reader.Item("RefNo"), reader.Item("SOANo"), Format(reader.Item("TotalSOA") + reader.Item("TotalAmt"), "n2"))
            ' Else
            Me.dtgBilling.Rows.Add(reader.Item("RefNo"), reader.Item("SOANo"), Format(reader.Item("TotalSOA"), "n2"))
            ' End If

        End While

        reader.Close()
        cmdSQL.Dispose()

        If Me.dtgBilling.Rows.Count = 0 Then Exit Sub

        ' MsgBox(Me.dtgBilling.Rows.Count)

        Dim iAdv As Integer = 0
        Dim hAdv As DataGridViewRow

        For iAdv = 0 To Me.dtgBilling.Rows.Count - 1
            hAdv = Me.dtgBilling.Rows(iAdv)

            Dim strSQLAdv As String = "SELECT * FROM bill_impb_advances WHERE RefNo = '" & hAdv.Cells(0).Value & "' " &
                              "AND MainAdvances = 1"

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim cmdSQLAdv = New MySql.Data.MySqlClient.MySqlCommand(strSQLAdv, cnnDBMaster)

            Dim readerAdv As MySql.Data.MySqlClient.MySqlDataReader = cmdSQLAdv.ExecuteReader

            ' Me.dtgBilling.Rows.Clear()

            While readerAdv.Read
                hAdv.Cells(2).Value = hAdv.Cells(2).Value - readerAdv.Item("AppliedAmount")
            End While

            readerAdv.Close()
            cmdSQLAdv.Dispose()

        Next
    End Sub

    Private Sub LoadExpClientInvoice()
        Dim ctrRow As Integer = 0
        Dim strsql As String = ""

        If Len(Me.txtRefNo.Text) = 0 Then
            strsql = "SELECT * FROM bill_expsoa_main WHERE BilledTo = @billedto " &
                               "AND SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE"
        Else
            If Me.optBillNo.Checked = True Then
                strsql = "SELECT * FROM bill_expsoa_main WHERE BilledTo = @billedto " &
                         "AND SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                         "AND RefNo LIKE '" & Me.lblPrefix.Text & Me.txtRefNo.Text & "%'"
            ElseIf Me.optInvNo.Checked = True Then
                strsql = "SELECT * FROM bill_expsoa_main WHERE BilledTo = @billedto " &
                         "AND SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                         "AND SOANo LIKE '" & Me.txtRefNo.Text & "%'"
            End If
        End If

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@billedto", Me.cboClient.Text)
        End With

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgBilling.Rows.Clear()

        While reader.Read
            For ctrRow = 0 To Me.dtgORInv.Rows.Count - 1
                If reader.Item("RefNo") = Me.dtgORInv.Rows(ctrRow).Cells(colORBillNo.Name).Value Then
                    GoTo SkipAddRow
                End If
            Next
            Me.dtgBilling.Rows.Add(reader.Item("RefNo"), reader.Item("SOANo"), Format(reader.Item("TotalSOA"), "n2"))
SkipAddRow:
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub PopComboSQL(ByVal cbo As ComboBox, ByVal strsql As String, ByVal strField As String)
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL3 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)

        Dim reader3 As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL3.ExecuteReader

        cbo.SelectedIndex = -1
        cbo.Items.Clear()

        While reader3.Read
            cbo.Items.Add(reader3.Item(strField))
        End While

        reader3.Close()
        cmdSQL3.Dispose()
    End Sub

    Private Sub tscmdClose_Click(sender As Object, e As EventArgs) Handles tscmdClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        Select Case Me.Tag
            Case "Exp"
                LoadExpClientInvoice()
            Case "ImpB"
                LoadImpBClientInvoice()
            Case "ImpF"
                LoadImpFClientInvoice()
            Case "ImpDCAF"
                LoadImpDCAFClientInvoice()
        End Select

        Dim ctrRow As Integer, ctrCol As Integer, dblBal As Double

        For ctrRow = 0 To Me.dtgBilling.Rows.Count - 1

            dblBal = CDbl(Me.dtgBilling.Rows(ctrRow).Cells(colBillAmt.Name).Value) - GetAllPaidAmtPerBillNo(Me.dtgBilling.Rows(ctrRow).Cells(colBillRefNo.Name).Value)
            Me.dtgBilling.Rows(ctrRow).Cells(colBillBalance.Name).Value = Format(dblBal, "n2")

            If dblBal < CDbl(Me.dtgBilling.Rows(ctrRow).Cells(colBillAmt.Name).Value) Then
                For ctrCol = 0 To Me.dtgBilling.Columns.Count - 1
                    Me.dtgBilling.Rows(ctrRow).Cells(ctrCol).Style.BackColor = Color.LightGreen
                    Me.dtgBilling.Rows(ctrRow).Cells(ctrCol).Style.SelectionBackColor = Color.Green
                Next
            ElseIf dblBal = CDbl(Me.dtgBilling.Rows(ctrRow).Cells(colBillAmt.Name).Value) Then
                For ctrCol = 0 To Me.dtgBilling.Columns.Count - 1
                    Me.dtgBilling.Rows(ctrRow).Cells(ctrCol).Style.BackColor = Color.SkyBlue
                    Me.dtgBilling.Rows(ctrRow).Cells(ctrCol).Style.SelectionBackColor = Color.Blue
                Next
            End If

        Next
    End Sub

    Private Sub cboClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClient.SelectedIndexChanged
        Me.dtgORInv.Rows.Clear()
        Me.dtgBilling.Rows.Clear()
    End Sub

    Private Sub cboClient_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboClient.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            cmdLoad_Click(sender, e)
        End If
    End Sub

    Private Sub dtgBilling_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBilling.CellContentClick

    End Sub

    Private Sub dtgBilling_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBilling.CellDoubleClick


        With dtgBilling.Rows(e.RowIndex)
            If CDbl(.Cells(colBillBalance.Name).Value) > 0 Then
                frmIncludeToAR.txtBillNo.Text = .Cells(colBillRefNo.Name).Value
                frmIncludeToAR.txtInvNo.Text = .Cells(colBillInv.Name).Value
                frmIncludeToAR.txtAmtBill.Text = Format(CDbl(.Cells(colBillBalance.Name).Value))
                LoadBooking(.Cells(colBillRefNo.Name).Value)
            Else
                MsgBox("Billing Reference No. " & .Cells(colBillRefNo.Name).Value & " has no remaining balance!", MsgBoxStyle.Information, "System Message")
                Exit Sub
            End If
        End With

        frmIncludeToAR.ShowDialog()
    End Sub

    Private Sub LoadBooking(ByVal refno As String)
        'dtgBkgNbr.Rows.Clear()
        Dim strsql As String = "SELECT * from bill_impsoa_booking WHERE RefNo like '" & refno & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)
        Dim reader As MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            dtgBkgNbr.Rows.Add(reader.Item("BookingNo"))
        End While
        cmdsql.Dispose()
        reader.Close()
        cnnDBMaster.Close()

        strsql = "SELECT * from bill_expsoa_booking WHERE RefNo like '" & refno & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        cmdsql = New MySqlCommand(strsql, cnnDBMaster)
        reader = cmdsql.ExecuteReader
        While reader.Read
            dtgBkgNbr.Rows.Add(reader.Item("BookingNo"))
        End While
        cmdsql.Dispose()
        reader.Close()
        cnnDBMaster.Close()

        strsql = "SELECT * from bill_impf_main WHERE RefNo like '" & refno & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        cmdsql = New MySqlCommand(strsql, cnnDBMaster)
        reader = cmdsql.ExecuteReader
        While reader.Read
            dtgBkgNbr.Rows.Add(reader.Item("HouseBL"))
        End While
        cmdsql.Dispose()
        reader.Close()
        cnnDBMaster.Close()

        strsql = "SELECT * from bill_impf_main INNER JOIN bill_impd_main ON bill_impf_main.RefNo = bill_impd_main.BillRefNo WHERE bill_impd_main.RefNo like '" & refno & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        cmdsql = New MySqlCommand(strsql, cnnDBMaster)
        reader = cmdsql.ExecuteReader
        While reader.Read
            dtgBkgNbr.Rows.Add(reader.Item("HouseBL"))
        End While
        cmdsql.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub

    Private Sub cmdRemoveSRow_Click(sender As Object, e As EventArgs) Handles cmdRemoveSRow.Click
        If Me.dtgORInv.Rows.Count > 0 Then
            If Me.dtgORInv.CurrentRow.Index >= 0 Then
                If Not dtgORInv.CurrentRow.IsNewRow Then
                    dtgORInv.Rows.Remove(dtgORInv.CurrentRow)
                    cmdLoad_Click(sender, e)
                End If
            End If
        End If

        ComputeTotals()
        PopdtgAcctgEntry()
    End Sub

    Private Sub txtPaymentTotal_TextChanged(sender As Object, e As EventArgs) Handles txtPaymentTotal.TextChanged
        If IsNumeric(Me.txtPaymentTotal.Text) = True Then
            Me.txtAmtInWords.Text = English(CDec(Me.txtPaymentTotal.Text), "Pesos")
        End If
    End Sub

    Private Sub tscmdSearchOR_Click(sender As Object, e As EventArgs) Handles tscmdSearchOR.Click
        If RetrieveOR(Me.tstxtSearch.Text) = False Then
            MsgBox("O.R. No. not found!", MsgBoxStyle.Information, "System Message")
            ClearAll()
            Exit Sub
        End If

        cmdLoad_Click(sender, e)
        txtCashAmt_TextChanged(sender, e)
        txtChkAmt_TextChanged(sender, e)
        'PopdtgAcctgEntry()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Private Sub txtCashAmt_TextChanged(sender As Object, e As EventArgs) Handles txtCashAmt.TextChanged
        If IsNumeric(Me.txtChkAmt.Text) And IsNumeric(Me.txtCashAmt.Text) And IsNumeric(Me.txtPaymentTotal.Text) Then
            If (CDbl(Me.txtCashAmt.Text) + CDbl(Me.txtChkAmt.Text)) = CDbl(Me.txtPaymentTotal.Text) Then
                Me.txtCashAmt.ForeColor = Color.Blue
                Me.txtChkAmt.ForeColor = Color.Blue
            Else
                Me.txtCashAmt.ForeColor = Color.Red
                Me.txtChkAmt.ForeColor = Color.Red
            End If
        Else
            Me.txtCashAmt.ForeColor = Color.Red
            Me.txtChkAmt.ForeColor = Color.Red
        End If
    End Sub

    Private Sub txtChkAmt_TextChanged(sender As Object, e As EventArgs) Handles txtChkAmt.TextChanged
        If IsNumeric(Me.txtChkAmt.Text) And IsNumeric(Me.txtCashAmt.Text) And IsNumeric(Me.txtPaymentTotal.Text) Then
            If (CDbl(Me.txtCashAmt.Text) + CDbl(Me.txtChkAmt.Text)) = CDbl(Me.txtPaymentTotal.Text) Then
                Me.txtCashAmt.ForeColor = Color.Blue
                Me.txtChkAmt.ForeColor = Color.Blue
            Else
                Me.txtCashAmt.ForeColor = Color.Red
                Me.txtChkAmt.ForeColor = Color.Red
            End If
        Else
            Me.txtCashAmt.ForeColor = Color.Red
            Me.txtChkAmt.ForeColor = Color.Red
        End If
    End Sub

    Private Sub lblPrefix_Click(sender As Object, e As EventArgs) Handles lblPrefix.Click

    End Sub

    Private Sub lblPrefix_TextChanged(sender As Object, e As EventArgs) Handles lblPrefix.TextChanged
        Select Case Me.Tag
            Case "Exp"
                PopComboSQL(Me.cboClient, "SELECT DISTINCT BilledTo FROM bill_expsoa_main " &
                            "WHERE SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                            " ORDER BY BilledTo", "BilledTo")
            Case "ImpB"
                PopComboSQL(Me.cboClient, "SELECT DISTINCT BilledTo FROM bill_impsoa_main " &
                            "WHERE SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                            " ORDER BY BilledTo", "BilledTo")
            Case "ImpF"
                PopComboSQL(Me.cboClient, "SELECT DISTINCT Client FROM bill_impf_main " &
                            "WHERE SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                            " ORDER BY Client", "Client")
            Case "ImpDCAF"
                PopComboSQL(Me.cboClient, "SELECT DISTINCT Client FROM bill_impf_main INNER JOIN bill_impd_main ON bill_impf_main.RefNo = bill_impd_main.BillRefNo " &
                                "WHERE bill_impd_main.DRCRNo IS NOT NULL AND LENGTH(bill_impd_main.DRCRNo) > 0 AND bill_impd_main.Posted = TRUE AND bill_impd_main.Cancel = FALSE " &
                                " ORDER BY Client", "Client")
        End Select
    End Sub

    Private Sub cmdCompCash_Click(sender As Object, e As EventArgs) Handles cmdCompCash.Click
        If Not IsNumeric(Me.txtChkAmt.Text) Then
            Me.txtChkAmt.Text = "0.00"
        End If

        If Not IsNumeric(Me.txtCashAmt.Text) Then
            Me.txtCashAmt.Text = "0.00"
        End If

        Me.txtCashAmt.Text = Format(CDbl(Me.txtPaymentTotal.Text) - CDbl(Me.txtChkAmt.Text), "n2")
        Me.txtChkAmt.Text = Format(CDbl(Me.txtChkAmt.Text), "n2")

        PopdtgAcctgEntry()
    End Sub

    Private Sub cmdCompCheck_Click(sender As Object, e As EventArgs) Handles cmdCompCheck.Click
        If Not IsNumeric(Me.txtChkAmt.Text) Then
            Me.txtChkAmt.Text = "0.00"
        End If

        If Not IsNumeric(Me.txtCashAmt.Text) Then
            Me.txtCashAmt.Text = "0.00"
        End If

        Me.txtChkAmt.Text = Format(CDbl(Me.txtPaymentTotal.Text) - CDbl(Me.txtCashAmt.Text), "n2")
        Me.txtCashAmt.Text = Format(CDbl(Me.txtCashAmt.Text), "n2")

        PopdtgAcctgEntry()
    End Sub

    Private Sub tstxtSearch_Click(sender As Object, e As EventArgs) Handles tstxtSearch.Click

    End Sub

    Private Sub tstxtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtSearch.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            Me.tscmdSearchOR_Click(sender, e)
        End If
    End Sub

    Private Sub optExp_CheckedChanged(sender As Object, e As EventArgs) Handles optExp.CheckedChanged

    End Sub

    Private Sub optExp_Click(sender As Object, e As EventArgs) Handles optExp.Click
        If Me.optExp.Checked = True Then
            Me.Tag = "Exp"
            PopComboSQL(Me.cboClient, "SELECT DISTINCT BilledTo FROM bill_expsoa_main " &
                            "WHERE SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                            " ORDER BY BilledTo", "BilledTo")
            Me.lblPrefix.Text = "BEXMNL"

            Me.cboClient.SelectedIndex = -1
            ClearAll()
        End If
    End Sub

    Private Sub optImpB_CheckedChanged(sender As Object, e As EventArgs) Handles optImpB.CheckedChanged

    End Sub

    Private Sub optImpB_Click(sender As Object, e As EventArgs) Handles optImpB.Click
        If Me.optImpB.Checked = True Then
            Me.Tag = "ImpB"
            PopComboSQL(Me.cboClient, "SELECT DISTINCT BilledTo FROM bill_impsoa_main " &
                            "WHERE SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                            " ORDER BY BilledTo", "BilledTo")
            Me.lblPrefix.Text = "BIBMNL"

            Me.cboClient.SelectedIndex = -1
            ClearAll()
        End If
    End Sub

    Private Sub optImpF_CheckedChanged(sender As Object, e As EventArgs) Handles optImpF.CheckedChanged

    End Sub

    Private Sub optImpF_Click(sender As Object, e As EventArgs) Handles optImpF.Click
        If Me.optImpF.Checked = True Then
            Me.Tag = "ImpF"
            PopComboSQL(Me.cboClient, "SELECT DISTINCT Client FROM bill_impf_main " &
                            "WHERE SOANo IS NOT NULL AND LENGTH(SOANo) > 0 AND Posted = TRUE AND Cancel = FALSE " &
                            " ORDER BY Client", "Client")
            Me.lblPrefix.Text = "BIFMNL"

            Me.cboClient.SelectedIndex = -1
            ClearAll()
        End If
    End Sub

    Private Sub txtCashAmt_Validated(sender As Object, e As EventArgs) Handles txtCashAmt.Validated
        PopdtgAcctgEntry()
    End Sub

    Private Sub txtChkAmt_Validated(sender As Object, e As EventArgs) Handles txtChkAmt.Validated
        PopdtgAcctgEntry()
    End Sub

    Private Sub txtRefNo_TextChanged(sender As Object, e As EventArgs) Handles txtRefNo.TextChanged
        cmdLoad_Click(sender, e)
    End Sub

    Private Sub optBillNo_CheckedChanged(sender As Object, e As EventArgs) Handles optBillNo.CheckedChanged

    End Sub

    Private Sub optBillNo_Click(sender As Object, e As EventArgs) Handles optBillNo.Click
        If Me.optBillNo.Checked = True Then
            Me.lblPrefix.Visible = True
        End If
    End Sub

    Private Sub optInvNo_CheckedChanged(sender As Object, e As EventArgs) Handles optInvNo.CheckedChanged

    End Sub

    Private Sub optInvNo_Click(sender As Object, e As EventArgs) Handles optInvNo.Click
        If Me.optInvNo.Checked = True Then
            Me.lblPrefix.Visible = False
        End If
    End Sub

    Private Sub chkBank_CheckedChanged(sender As Object, e As EventArgs) Handles chkBank.CheckedChanged

    End Sub

    Private Sub chkBank_Click(sender As Object, e As EventArgs) Handles chkBank.Click
        PopdtgAcctgEntry()
        If Me.chkBank.Checked = True Then
            PopComboSQL(cboBank, "SELECT * from lib_bank WHERE Active = True", "Name")
        Else
            PopComboSQL(cboBank, "SELECT * from lib_bank", "Name")
        End If
    End Sub

    Private Sub cboBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBank.SelectedIndexChanged
        PopdtgAcctgEntry()
    End Sub

    Public Sub FindClient(ByVal str As String, ByVal str2 As String)
        Dim ClientName As String = ""

        Dim strsql As String = "SELECT Description, Tin, Client_Address, Addr1, CityDesc, CountryDesc, AddrZipCode, BusStyle from v_client WHERE Client_Name = '" & str & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)
        Dim reader As MySqlDataReader = cmdsql.ExecuteReader

        While reader.Read
            ClientName = reader.Item("Description")
            ClientTin = reader.Item("Tin")
            ClientAddress = reader.Item("Addr1") & " " & reader.Item("CityDesc") & " " & reader.Item("CountryDesc") & " " & reader.Item("AddrZipCode")
            ClientBStyle = reader.Item("BusStyle")
        End While

        cmdsql.Dispose()
        reader.Close()
        cnnDBMaster.Close()

        HBL = ""
        'InvoiceNum = ""
        'Vat = ""


        Dim i As Integer = 0
        Dim strFreight As String = ""

        If Me.optExp.Checked = True Then
            strFreight = "EXP"
        ElseIf Me.optImpB.Checked = True Then
            strFreight = "IMPB"
        ElseIf Me.optImpF.Checked = True Then
            strFreight = "IMPF"
        End If

        For i = 0 To Me.dtgORInv.Rows.Count - 1
            Dim h As DataGridViewRow
            h = Me.dtgORInv.Rows(i)

            GetHBL(strFreight, h.Cells(0).Value)

        Next

        'MsgBox(HBL)

        If Len(ClientName) = 0 Then
            'frmEnterClientTin.strClientName = str
            'frmEnterClientTin.strTag = str2
            'frmEnterClientTin.strType = "OR"
            'frmEnterClientTin.ShowDialog()
        Else
            PrintRec(str, str2, ClientTin, ClientAddress)
        End If

    End Sub

    Public Sub PrintRec(ByVal strClientName As String, ByVal strClientTag As String, ByVal strClientTin As String, ByVal strClientAddr As String)
        ' MsgBox("Print Transaction")
        'frmPrintORAR.strNewOld = "old"
        'frmPrintORAR.strTag = "AR"
        'frmPrintORAR.ShowDialog()
    End Sub
    Public Sub GetHBL(ByVal strTag As String, ByVal strRefNo As String)

        Select Case strTag

            Case "EXP"
                Dim strsql As String = "SELECT HBL from bill_expsoa_main WHERE bill_exp_main.RefNo = '" & strRefNo & "' "
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)
                Dim reader As MySqlDataReader = cmdsql.ExecuteReader

                While reader.Read
                    HBL = HBL & " , " & reader.Item("HBL")
                End While

                cmdsql.Dispose()
                reader.Close()
                cnnDBMaster.Close()
            Case "IMPB"
                'no current field in bill_impb_main
                HBL = ""
            Case "IMPF"
                Dim strsql As String = "SELECT HouseBL from bill_impf_main WHERE bill_impf_main.RefNo = '" & strRefNo & "' "
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)
                Dim reader As MySqlDataReader = cmdsql.ExecuteReader

                While reader.Read
                    HBL = HBL & " , " & reader.Item("HouseBL")
                End While

                cmdsql.Dispose()
                reader.Close()
                cnnDBMaster.Close()
            Case "IMPDCAF"
                Dim strsql As String = "SELECT HouseBL from bill_impf_main INNER JOIN bill_impd_main ON bill_impf_main.RefNo = bill_impd_main.BillRefNo  WHERE bill_impd_main.RefNo = '" & strRefNo & "' "
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)
                Dim reader As MySqlDataReader = cmdsql.ExecuteReader

                While reader.Read
                    HBL = HBL & " , " & reader.Item("HouseBL")
                End While

                cmdsql.Dispose()
                reader.Close()
                cnnDBMaster.Close()
        End Select
    End Sub

    Private Sub optImpDCAF_CheckedChanged(sender As Object, e As EventArgs) Handles optImpDCAF.CheckedChanged

    End Sub

    Private Sub optImpDCAF_Click(sender As Object, e As EventArgs) Handles optImpDCAF.Click
        If Me.optImpDCAF.Checked = True Then
            Me.Tag = "ImpDCAF"
            PopComboSQL(Me.cboClient, "SELECT DISTINCT Client FROM bill_impf_main INNER JOIN bill_impd_main ON bill_impf_main.RefNo = bill_impd_main.BillRefNo " &
                       "WHERE bill_impd_main.DRCRNo IS NOT NULL AND LENGTH(bill_impd_main.DRCRNo) > 0 AND bill_impd_main.Posted = TRUE AND bill_impd_main.Cancel = FALSE " &
                       " ORDER BY Client", "Client")
            Me.lblPrefix.Text = "BIDMNL"

            Me.cboClient.SelectedIndex = -1
            ClearAll()
        End If
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
        Me.txtORNo.Enabled = True
        Me.txtORNo.Text = ""
        ClearAll()
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        If Me.tslblStatus.Text = "Posted" Then
            MsgBox("Already Posted. Cannot Edit O.R.", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
        Me.txtORNo.Enabled = False
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckRequiredEntries() = True Then
            Exit Sub
        End If

        If Me.txtORNo.Enabled = True Then
            If CheckIfORAlreadyExist(Me.txtORNo.Text) = True Then
                MsgBox("A.R. already exists!", MsgBoxStyle.Exclamation, "System Message")
                Exit Sub
            End If
        End If

        PopdtgAcctgEntry()
        SaveOR()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        RetrieveOR(Me.txtORNo.Text)
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        Me.txtORNo.Text = ""
        ClearAll()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        Throw New NotImplementedException()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        If Me.tslblStatus.Text = "Posted" Then
            MsgBox("Cannot Cancel Posted O.R.", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If MsgBox("Are You Sure You Want to CANCEL Record!" & vbNewLine &
                  "O.R. No. : " & Me.txtORNo.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim strsql As String
        strsql = "UPDATE ar_main SET" &
                    " Cancel = @Cancel," &
                    " CancelBy = @CancelBy," &
                    " CancelDate = @CancelDate" &
                    " WHERE ORNo = '" & Me.txtORNo.Text & "' AND Cancel = False"

        Dim dtCurrent As Date = GetServerDate()

        If cnnDBMaster.State <> ConnectionState.Open Then Exit Sub

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@Cancel", True)
            .AddWithValue("@CancelBy", CurrentUser)
            .AddWithValue("@CancelDate", dtCurrent)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()

        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

        RetrieveOR(Me.txtORNo.Text)
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        Throw New NotImplementedException()
    End Sub


End Class