﻿Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmInvoiceExport
    Implements ICommonFunction
    Private EnableButtons As New clsEnableToolstripObjects()
    Private Sub frmInvoiceExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearEntries(False)
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, True)
        EnableButtons2(True, True)
        FillComboBox(Me.cboCurrency, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillGridComboBox(Me.colSBillCurrency, "Select Acronym from lib_currency where Acronym is not null", "Acronym")

        FillComboBox(Me.cboTermsofPayment, "Select Description from lib_terms where Description is not null", "Description")
        FillGridComboBox(Me.colSCharges, "Select ChargeName from tbl_charges where CRAcctCode = '4110' is not null", "ChargeName")
    End Sub

    Public Function CheckForRequiredEntries() As Boolean
        CheckForRequiredEntries = True
    End Function

    Public Sub SaveBilling()
        Dim strsql As String

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL As New MySqlCommand

        'SAVE bill_impinv_main
        If Len(Me.lblRefNo.Text) = 0 Then
            'NEW BILLING
            Dim strRefNo As String = "BEX" & GetCtrlNbr(strCompanyCode, strSiteCode, "Billing_Export")
            Me.lblRefNo.Text = strRefNo
            Dim dtCurrent As Date = GetServerDate()
            strsql = "INSERT INTO bill_expinv_main(RefNo, TransactionType,  InvNo, BookingNos, Shipper, BilledTo, BilledToAddress, Attention, Remarks " &
                        " ExRate, TotalVat, TotalInv, TotalAmtCurrency," &
                        " TotalAmtPHP, TermsOfPayment, PrepBy, PrepDate, Posted, Cancel) VALUES(@RefNo, @TransactionType," &
                        " @InvNo, @BookingNos, @Shipper, @BilledTo, @BilledToAddress, @Attention, @Remarks, @ExRate, @TotalVat, " &
                        " @TotalInv, @TotalAmtCurrency, @TotalAmtPHP, @TermsOfPayment, @PrepBy, @PrepDate," &
                        " @Posted, @Cancel)"

            cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

            With cmdSQL.Parameters
                .AddWithValue("@RefNo", strRefNo)
                .AddWithValue("@Transactiontype", Me.txtTransMode.Text)
                .AddWithValue("@InvNo", Me.txtCISOANo.Text)
                .AddWithValue("@BookingNos", Me.txtBookingNo.Text)
                .AddWithValue("@Shipper", Me.txtShipper.Text)
                .AddWithValue("@BilledTo", Me.txtBilledTo.Text)
                .AddWithValue("@BilledToAddress", Me.txtShprAddr.Text)
                .AddWithValue("@Attention", Me.txtAttention.Text)
                .AddWithValue("@Remarks", Me.txtRemarks.Text)
                .AddWithValue("@ExRate", CDbl(Me.txtExrateDollar.Text))
                .AddWithValue("@TotalVat", CDbl(Me.txtTotalVat.Text))
                .AddWithValue("@TotalInv", CDbl(Me.txtTotalInvoice.Text))
                .AddWithValue("@TotalAmtCurrency", Me.cboCurrency.Text)
                .AddWithValue("@totalAmtPHP", CDbl(Me.txtTotalAmtPHP.Text))
                .AddWithValue("@TermsOfPayment", Me.cboTermsofPayment.Text)
                .AddWithValue("@PrepBy", strCurrentUser)
                .AddWithValue("@PrepDate", dtCurrent)
                .AddWithValue("@Posted", False)
                .AddWithValue("@Cancel", False)
                Me.lblRefNo.Text = strRefNo
            End With

            cmdSQL.ExecuteNonQuery()

            UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "Billing_Export")

            'save to transaction logs
            SaveTransLogs("Create New Export Billing Invoice", Me.Name, "Billing No.", Me.lblRefNo.Text, strCurrentUser)
        Else
            'EDIT BILLING
            strsql = "UPDATE bill_expinv_main SET" &
                        " TransactionType=@TransactionType," &
                        " InvNo=@InvNo," &
                        " BookingNos=@BookingNos," &
                        " Shipper=@Shipper," &
                        " BilledTo=@BilledTo," &
                        " Attention=@Attention," &
                        " Remarks=@Remarks," &
                        " ExRate=@ExRate," &
                        " TotalVat=@TotalVat, " &
                        " TotalInv=@TotalInv," &
                        " TotalAmtCurrency=@TotalAmtCurrency," &
                        " TotalAmtPHP=@TotalAmtPHP," &
                        " TermsOfPayment=@TermsOfPayment " &
                     " WHERE" &
                        " RefNo = '" & Me.lblRefNo.Text & "'" &
                     " AND" &
                        " Cancel = FALSE"

            cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

            With cmdSQL.Parameters
                .AddWithValue("@TransactionType", Me.txtTransMode.Text)
                .AddWithValue("@InvNo", Me.txtCISOANo.Text)
                .AddWithValue("@BookingNos", Me.txtBookingNo.Text)
                .AddWithValue("@Shipper", Me.txtShipper.Text)
                .AddWithValue("@BilledTo", Me.txtBilledTo.Text)
                .AddWithValue("@Attention", Me.txtAttention.Text)
                .AddWithValue("@Remarks", Me.txtRemarks.Text)
                .AddWithValue("@ExRate", CDbl(Me.txtExrateDollar.Text))
                .AddWithValue("@TotalVat", CDbl(Me.txtTotalVat.Text))
                .AddWithValue("@TotalInv", CDbl(Me.txtTotalInvoice.Text))
                .AddWithValue("@TotalAmtCurrency", Me.cboCurrency.Text)
                .AddWithValue("@TotalAmtPHP", CDbl(Me.txtTotalAmtPHP.Text))
                .AddWithValue("@TermsOfPayment", Me.cboTermsofPayment.Text)
            End With

            cmdSQL.ExecuteNonQuery()

            'save to transaction logs
            SaveTransLogs("Edit Export Billing Invoice", Me.Name, "Billing No.", Me.lblRefNo.Text, strCurrentUser)
        End If

        'SAVE bill_impinv_charges
        strsql = "DELETE FROM bill_exppinv_charges WHERE RefNo = '" & Me.lblRefNo.Text & "'"

        cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        cmdSQL.ExecuteNonQuery()

        For intRow = 0 To Me.dtgServiceCharge.RowCount - 1
            If Len(Me.dtgServiceCharge.Rows(intRow).Cells("colSCharges").Value) > 0 Then
                strsql = "INSERT INTO bill_expinv_charges(RefNo, Charges, Terms," &
                            " BillingAmt, BillingCurrency, BillingAmtPHP, BillingVAT, BillingVATAmt, Remarks, ORNbr, CHCode)" &
                            " VALUES(@RefNo, @Charges, @Terms," &
                            " @BillingAmt, @BillingCurrency, @BillingAmtPHP, @BillingVAT, @BillingVATAmt, @Remarks, @ORNbr, @CHCode)"

                cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@RefNo", Me.lblRefNo.Text)
                    .AddWithValue("@Charges", Me.dtgServiceCharge.Rows(intRow).Cells("colSCharges").Value)
                    .AddWithValue("@Terms", Me.dtgServiceCharge.Rows(intRow).Cells("colSTerms").Value)
                    .AddWithValue("@BillingAmt", CDbl(Me.dtgServiceCharge.Rows(intRow).Cells("colSBillAmt").Value))
                    .AddWithValue("@BillingCurrency", Me.dtgServiceCharge.Rows(intRow).Cells("colSBillCurrency").Value)
                    .AddWithValue("@BillingAmtPHP", CDbl(Me.dtgServiceCharge.Rows(intRow).Cells("colSBillPHP").Value))
                    .AddWithValue("@BillingVAT", Me.dtgServiceCharge.Rows(intRow).Cells("colSBillingVAT").Value)
                    .AddWithValue("@BillingVATAmt", CDbl(Me.dtgServiceCharge.Rows(intRow).Cells("colSBillingVATAmt").Value))
                    .AddWithValue("@Remarks", Me.dtgServiceCharge.Rows(intRow).Cells("colSRemarks").Value)
                    .AddWithValue("@ORNbr", Me.dtgServiceCharge.Rows(intRow).Cells("colORNbr").Value)
                    .AddWithValue("@CHCode", Me.dtgServiceCharge.Rows(intRow).Cells(14).Value)
                End With

                cmdSQL.ExecuteNonQuery()
            End If
        Next

        ''SAVE bill_impsoa_booking
        'strsql = "DELETE FROM bill_impsoa_booking WHERE RefNo = '" & Me.lblRefNo.Text & "'"

        'cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        'cmdSQL.ExecuteNonQuery()

        'For intRow = 0 To Me.dtgBookings.RowCount - 1
        '    If Len(Me.dtgBookings.Rows(intRow).Cells(0).Value) > 0 Then
        '        strsql = "INSERT INTO bill_impsoa_booking(RefNo, BookingNo, ContNo, HouseBL)" & _
        '                    " VALUES(@RefNo, @BookingNo, @ContNo, @HouseBL)"

        '        cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        '        With cmdSQL.Parameters
        '            .AddWithValue("@RefNo", Me.lblRefNo.Text)
        '            .AddWithValue("@BookingNo", Me.dtgBookings.Rows(intRow).Cells("colBookingNo").Value)
        '            .AddWithValue("@ContNo", Me.dtgBookings.Rows(intRow).Cells("colContNo").Value)
        '            .AddWithValue("@HouseBL", Me.dtgBookings.Rows(intRow).Cells("colHBL").Value)
        '        End With

        '        cmdSQL.ExecuteNonQuery()
        '    End If
        'Next

        'SAVE bill_impinv_acctg_entry
        strsql = "DELETE FROM bill_expinv_acctg_entry WHERE RefNo = '" & Me.lblRefNo.Text & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        cmdSQL.ExecuteNonQuery()

        Dim ctrRow As Integer

        For ctrRow = 0 To Me.dtgAcctgTitle.Rows.Count - 1
            With Me.dtgAcctgTitle.Rows(ctrRow)
                strsql = "INSERT INTO bill_expinv_acctg_entry (RefNo, Branch, AcctCode, AcctTitle, SubAcctCode," &
                            " SubAcctTitle, SubAcctDept, SubAcctDeptName," &
                            " SubAcctList, SubAcctListItem, SubAcctListItemName, DR, CR)" &
                            " VALUES ('" & Me.lblRefNo.Text & "', '" & Mid$(Me.lblRefNo.Text, 4, 3) & "', '" & .Cells(0).Value & "', '" & .Cells(1).Value & "'," &
                            " '" & .Cells(2).Value & "', '" & .Cells(3).Value & "', " & .Cells(4).Value & ", '" & .Cells(5).Value & "'," &
                            " " & .Cells(6).Value & ", '" & .Cells(7).Value & "', '" & .Cells(8).Value & "'," &
                            " " & CDbl(.Cells(9).Value) & ", " & CDbl(.Cells(10).Value) & ")"

                cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

                cmdSQL.ExecuteNonQuery()
            End With
        Next

        cmdSQL.Dispose()


        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, True)
        EnableButtons2(True, True)
        MsgBox("Billing Saved!" & vbNewLine & "Reference No. : " & Me.lblRefNo.Text, MsgBoxStyle.Information, "System Message")

    End Sub
    Public Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blReset As Boolean, ByVal blSave As Boolean,
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

            .UpdateEnabledButtons()

            Me.txtCISOANo.ReadOnly = blUserInput
            Me.cboTermsofPayment.Enabled = Not blUserInput
            Me.txtExrateDollar.ReadOnly = blUserInput
            Me.cmdAddSRow.Enabled = Not blUserInput
            Me.cmdRemoveSRow.Enabled = Not blUserInput
            Me.cmdClearSRows.Enabled = Not blUserInput
            Me.cboCurrency.Enabled = Not blUserInput
        End With
    End Sub
    Public Sub EnableButtons2(ByVal blPrint As Boolean, ByVal blClose As Boolean)
        Me.tscmdPrint.Enabled = blPrint
        Me.tscmdClose.Enabled = blClose
    End Sub

    Public Sub ClearEntries(ByVal blNew As Boolean)
        Me.tstxtSearch.Text = ""
        Me.lblRefNo.Text = ""
        Me.txtExrateDollar.Text = 0
        Me.txtTotalInvoice.Text = 0
        Me.txtTotalAmtPHP.Text = 0
        Me.cboTermsofPayment.SelectedIndex = -1
        Me.cboCurrency.SelectedIndex = -1
        Me.dtgServiceCharge.Rows.Clear()
        'Me.dtgBookings.Rows.Clear()
        Me.dtgAcctgTitle.Rows.Clear()
        Me.dtgOR.Rows.Clear()
        Me.dgUnpostHistory.Rows.Clear()
        Me.txtExrateDollar.Text = Format(GetDoubleValue("Select Rate from lib_currency WHERE Acronym = 'USD'", "Rate"), "n2")
        If blNew = False Then
            Me.txtCISOANo.Text = ""

            Me.txtShipper.Text = ""

            Me.txtDescOfGoods.Text = ""
            Me.txtBookingNo.Text = ""
            Me.txtWgtMeas.Text = ""

            Me.txtOriginDest.Text = ""

            Me.txtFreightTerms.Text = ""
            Me.txtCargoLoad.Text = ""
            Me.txtTransMode.Text = ""
            Me.txtShprAddr.Text = ""
            Me.txtDate.Text = ""
            Me.txtAttention.Text = ""
            Me.txtRemarks.Text = ""
        End If
    End Sub


    Public Function SearchBooking(ByVal str As String) As Boolean
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        Dim strsql As String = "SELECT * FROM v_exportbookingheader WHERE v_exportbookingheader.BookingNo = '" & str & "'"

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader

        If reader.HasRows = False Then
            MsgBox("No record found!", vbInformation, "System Message")
            SearchBooking = False
            reader.Close()
            cmdsql.Dispose()
            Exit Function
        End If

        While reader.Read
            Me.txtShipper.Text = reader.Item("ShipperName")
            Me.txtDescOfGoods.Text = reader.Item("Commodity")
            Me.txtWgtMeas.Text = "(WGT. " & reader.Item("GrossWeight") & "" & " VOL. " & reader.Item("RevisedMeasurement") & ") " & reader.Item("NoOfPackage") & " " & reader.Item("PackageUnitDesc")
            Me.txtOriginDest.Text = reader.Item("FinalDestinationName")
            Me.txtCargoLoad.Text = reader.Item("LoadTypeDesc")
            ' Me.txtFreightTerms.Text = reader.Item("FreightTermsName")
            Me.txtFreightTerms.Text = ""
            Me.txtTransMode.Text = reader.Item("ModeOfTransportDesc")
            Me.txtBookingNo.Text = reader.Item("BookingNo")
            'Me.dtgBookings.Rows.Add(reader.Item("CtrlNbr"), reader.Item("ContainerNo"), reader.Item("HouseBL"))
        End While

        reader.Close()
        cmdsql.Dispose()

        SearchBooking = True
    End Function
    Private Function CheckdtgAcctTitleRow(ByVal strAcctCode As String, ByVal strSubCode As String) As Integer
        CheckdtgAcctTitleRow = -1
        Dim intRow As Integer

        For intRow = 0 To Me.dtgAcctgTitle.Rows.Count - 1
            With Me.dtgAcctgTitle.Rows(intRow)
                If strAcctCode = .Cells("colAcctCode").Value And strSubCode = .Cells("colSubAcctCode").Value Then
                    CheckdtgAcctTitleRow = intRow
                    Exit Function
                End If
            End With
        Next
    End Function

    Public Sub PopdtgAcctgTitleRows(ByVal strCode As String, ByVal strSubCode As String, ByVal dblDR As Double, ByVal dblCR As Double)
        Dim strsql As String = "SELECT tbl_glmain.*, tbl_glsub.* FROM tbl_glmain LEFT JOIN tbl_glsub ON tbl_glmain.Account_Code = tbl_glsub.Account_Code" &
                                " WHERE tbl_glmain.Account_Code = '" & strCode & "' AND tbl_glsub.SubAccount_Code = '" & strSubCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

        Dim rdrAcctgTitle As MySqlDataReader = cmdsql.ExecuteReader
        Dim strDept As String, strList As String, strShip As String

        strShip = ""
        strList = ""
        strDept = ""

        While rdrAcctgTitle.Read
            If rdrAcctgTitle.Item("SubAccount_Dept") = True Then
                strDept = "Export"
            End If

            If rdrAcctgTitle.Item("SubAccount_List") = True Then
                strList = rdrAcctgTitle.Item("SubAccount_ListItem")
                If strList = "Client" Then
                    strShip = Me.txtShipper.Text
                ElseIf strList = "Local and Government Agency" Then
                    strShip = "Bureau of Internal Revenue"
                End If
            End If

            Me.dtgAcctgTitle.Rows.Add(rdrAcctgTitle.Item("Account_Code"), rdrAcctgTitle.Item("Account_Title"), rdrAcctgTitle.Item("SubAccount_Code"), rdrAcctgTitle.Item("SubAccount_Title"), CBool(rdrAcctgTitle.Item("SubAccount_Dept")), strDept, CBool(rdrAcctgTitle.Item("SubAccount_List")), strList, strShip, Format$(CDbl(dblDR), "n2"), Format$(CDbl(dblCR), "n2"), strSubCode)
        End While

        rdrAcctgTitle.Close()
        cmdsql.Dispose()
    End Sub

    Private Sub PopdtgAcctgTitle()
        Me.dtgAcctgTitle.Rows.Clear()

        Dim intRow As Integer, intAcctRow As Integer

        'POPULATE DEBIT ENTRY
        For intRow = 0 To Me.dtgServiceCharge.Rows.Count - 1
            With Me.dtgServiceCharge.Rows(intRow)
                'MsgBox(intRow & " / " & .Cells("colSDRAcctCode").Value & " / " & .Cells("colSDRSub").Value)
                intAcctRow = CheckdtgAcctTitleRow(.Cells("colSDRAcctCode").Value, .Cells("colSDRSub").Value)
                If intAcctRow = -1 Then
                    PopdtgAcctgTitleRows(.Cells("colSDRAcctCode").Value, .Cells("colSDRSub").Value, CDbl(.Cells("colSBillPHP").Value) + CDbl(.Cells("colSBillingVATAmt").Value), 0)
                Else
                    Me.dtgAcctgTitle.Rows(intAcctRow).Cells("colDR").Value = Format$(CDbl(Me.dtgAcctgTitle.Rows(intAcctRow).Cells("colDR").Value) + (CDbl(.Cells("colSBillPHP").Value) + CDbl(.Cells("colSBillingVATAmt").Value)), "n2")
                End If
            End With
        Next

        'POPULATE CREDIT ENTRY
        For intRow = 0 To Me.dtgServiceCharge.Rows.Count - 1
            With Me.dtgServiceCharge.Rows(intRow)
                intAcctRow = CheckdtgAcctTitleRow(.Cells("colSCRAcctCode").Value, .Cells("colSCRSub").Value)
                If intAcctRow = -1 Then
                    PopdtgAcctgTitleRows(.Cells("colSCRAcctCode").Value, .Cells("colSCRSub").Value, 0, .Cells("colSBillPHP").Value)
                Else
                    Me.dtgAcctgTitle.Rows(intAcctRow).Cells("colCR").Value = Format$(CDbl(Me.dtgAcctgTitle.Rows(intAcctRow).Cells("colCR").Value) + CDbl(.Cells("colSBillPHP").Value), "n2")
                End If
            End With
        Next

        'COMPUTE DR/CR TOTAL
        ComputeDRCRTotal()
    End Sub
    Private Sub ComputeDRCRTotal()
        With Me.dtgAcctgTitle
            Dim ctrRow As Integer
            Dim dblDR As Double = 0
            Dim dblCR As Double = 0

            For ctrRow = 0 To .Rows.Count - 1
                dblDR = dblDR + CDbl(.Rows(ctrRow).Cells(9).Value)
                dblCR = dblCR + CDbl(.Rows(ctrRow).Cells(10).Value)
            Next

            Me.txtDRTotal.Text = Format$(dblDR, "n2")
            Me.txtCRTotal.Text = Format$(dblCR, "n2")
        End With
    End Sub
    Public Sub ComputeTotals()
        Dim intRow As Integer
        Dim dblInv As Double = 0
        Dim dblSOA As Double = 0
        Dim dblVAT As Double = 0
        Dim dblBill As Double = 0

        For intRow = 0 To Me.dtgServiceCharge.Rows.Count - 1
            With Me.dtgServiceCharge.Rows(intRow)
                If .Cells("colSBillCurrency").Value = "PHP" Then
                    .Cells("colSBillPHP").Value = Format$(CDbl(.Cells("colSBillAmt").Value), "n2")
                ElseIf .Cells("colSBillCurrency").Value = "USD" Then
                    .Cells("colSBillPHP").Value = Format$(CDbl(.Cells("colSBillAmt").Value) * CDbl(Me.txtExrateDollar.Text), "n2")
                Else
                    .Cells("colSBillPHP").Value = "0.00"
                End If

                If .Cells("colSBillingVAT").Value = True Then
                    .Cells("colSBillingVATAmt").Value = Format$(CDbl(.Cells("colSBillPHP").Value) * 0.12, "n3")
                Else
                    .Cells("colSBillingVATAmt").Value = "0.00"
                End If

                If .Cells("colSTerms").Value = "Invoice" Then
                    dblInv = dblInv + CDbl(.Cells("colSBillPHP").Value)
                    .Cells("colSBillingVAT").ReadOnly = False
                ElseIf .Cells("colSTerms").Value = "S.O.A." Then
                    dblSOA = dblSOA + CDbl(.Cells("colSBillPHP").Value)
                    .Cells("colSBillingVAT").ReadOnly = True
                    .Cells("colSBillingVAT").Value = False
                End If

                dblBill = dblBill + CDbl(.Cells("colSBillPHP").Value)
                dblVAT = dblVAT + CDbl(.Cells("colSBillingVATAmt").Value)
            End With
        Next
        Me.txtTotalVat.Text = Format$(dblVAT, "n2")
        Me.txtTotalInvoice.Text = Format$(dblInv, "n2")
        Me.txtTotalAmtPHP.Text = Format$((dblBill + dblVAT), "n2")
    End Sub

    Private Sub RetrieveTerms(ByVal grid As DataGridViewRow, ByVal strDesc As String, ByVal strTermsCol As String, ByVal strDRCol As String, ByVal strDRSubCol As String, ByVal strCRCol As String, ByVal strCRSubCol As String)
        Dim strsql As String = "SELECT Terms, DRAcctCode, DRSubAcctCode, CRAcctCode, CRSubAcctCode, ChargeCode FROM tbl_charges WHERE ChargeName = '" & strDesc & "' AND Terms IS NOT NULL"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySqlDataReader = cmdsql.ExecuteReader

        While reader.Read
            grid.Cells(strTermsCol).Value = reader.Item("Terms")
            grid.Cells(strDRCol).Value = reader.Item("DRAcctCode")
            grid.Cells(strDRSubCol).Value = reader.Item("DRSubAcctCode")
            grid.Cells(strCRCol).Value = reader.Item("CRAcctCode")
            grid.Cells(strCRSubCol).Value = reader.Item("CRSubAcctCode")
            grid.Cells(14).Value = reader.Item("ChargeCode")
        End While

        reader.Close()
        cmdsql.Dispose()
    End Sub
    Public Sub SearchBilling(ByVal strRefNo As String, ByVal strField As String)
        Dim blIfExist As Boolean = False
        Dim strBooking As String = ""
        Dim strsql As String = ""
        '= "SELECT * FROM bill_impsoa_main " & _
        '                        " WHERE bill_impsoa_main." & strField & " = '" & strRefNo & "'"

        'If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        'Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

        'Dim reader As MySqlDataReader = cmdsql.ExecuteReader

        ''While reader.Read
        ''    blIfExist = True
        ''    strBooking = reader.Item("BookingNo")
        ''    Me.lblRefNo.Text = reader.Item("RefNo")
        ''    Exit While
        ''End While

        ''reader.Close()

        ''If blIfExist = False Then
        ''    MsgBox("Reference Number Not Found!", MsgBoxStyle.Exclamation, "System Message")
        ''    Exit Sub
        ''End If

        'If reader.HasRows = False Then
        '    MsgBox("Reference Number Not Found!", MsgBoxStyle.Exclamation, "System Message")
        '    reader.Close()
        '    Exit Sub
        'End If



        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        'bill_impsoa_main
        strsql = "SELECT * " &
                    "FROM bill_expinv_main " &
                    "WHERE bill_expinv_main.RefNo = '" & strRefNo & "'"

        Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySqlDataReader = cmdsql.ExecuteReader

        If reader.HasRows = False Then
            MsgBox("Reference Number Not Found!", MsgBoxStyle.Exclamation, "System Message")
            reader.Close()
            Exit Sub
        End If

        While reader.Read
            Me.lblRefNo.Text = reader.Item("RefNo")
            Me.txtTransMode.Text = reader.Item("TransactionType")
            Me.txtCISOANo.Text = IIf(IsDBNull(reader.Item("InvNo")) = False, reader.Item("InvNo"), "")
            Me.txtBookingNo.Text = reader.Item("BookingNos")
            Me.txtShipper.Text = reader.Item("Shipper")
            Me.txtBilledTo.Text = reader.Item("BilledTo")
            Me.txtShprAddr.Text = reader.Item("BilledToAddress")
            Me.cboTermsofPayment.Text = reader.Item("TermsOfPayment")
            Me.txtAttention.Text = reader.Item("Attention")
            Me.txtRemarks.Text = reader.Item("Remarks")

            Me.txtExrateDollar.Text = Format$(reader.Item("ExRate"), "n2")
            Me.txtTotalVat.Text = Format$(reader.Item("TotalVat"), "n2")
            Me.txtTotalInvoice.Text = Format$(reader.Item("TotalInv"), "n2")
            Me.txtTotalAmtPHP.Text = Format$(reader.Item("TotalAmtPHP"), "n2")
            Me.cboCurrency.Text = reader.Item("TotalAmtCurrency")

            Me.tslblPrepBy.Text = "| Prepared By : " & reader.Item("PrepBy") & " |"
            Me.tslblPrepDate.Text = "Prepared Date : " & reader.Item("PrepDate") & " |"
            Me.dtPrepDate.Value = reader.Item("PrepDate")

            Me.txtDate.Text = IIf(IsDBNull(reader.Item("DateReceived")) = True, "", reader.Item("DateReceived"))
            If reader.Item("Cancel") = True Then
                Me.tslblStatus1.Text = "Status : "
                Me.tslblStatus2.Text = "Canceled"
                Me.tslblStatus2.ForeColor = Color.Red
                Me.tslblStatus3.Text = "|Canceled By : " & reader.Item("CancelBy") & " | Cancel Date : " & Format$(reader.Item("CancelDate"), "MM/dd/yyyy")
            Else
                If reader.Item("Posted") = True Then
                    Me.tslblStatus1.Text = "Status : "
                    Me.tslblStatus2.Text = "Posted"
                    Me.tslblStatus2.ForeColor = Color.Blue
                    Me.tslblStatus3.Text = "Date Closed : " & reader.Item("PostedDate")
                Else
                    Me.tslblStatus1.Text = "Status : "
                    Me.tslblStatus2.Text = "Open"
                    Me.tslblStatus2.ForeColor = Color.Black
                    Me.tslblStatus3.Text = ""
                End If
            End If
        End While

        reader.Close()

        SearchBooking(txtBookingNo.Text)

        'bill_expinv_charges
        strsql = "SELECT * FROM bill_expinv_charges WHERE RefNo = '" & strRefNo & "'"

        cmdsql = New MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        Me.dtgServiceCharge.Rows.Clear()
        While reader.Read
            Me.dtgServiceCharge.Rows.Add("", reader.Item("Charges"), reader.Item("Terms"), reader.Item("ORNbr"), reader.Item("BillingAmt"), reader.Item("BillingCurrency"), reader.Item("BillingAmtPHP"), reader.Item("BillingVAT"), reader.Item("BillingVATAmt"), reader.Item("Remarks"), "", "", "", "", reader.Item("CHCode"))
        End While

        reader.Close()

        'bill_expinv_acctg_entry
        strsql = "SELECT * FROM bill_expinv_acctg_entry WHERE RefNo = '" & strRefNo & "'"

        cmdsql = New MySqlCommand(strsql, cnnDBMaster)

        reader = cmdsql.ExecuteReader

        Me.dtgAcctgTitle.Rows.Clear()
        While reader.Read
            Me.dtgAcctgTitle.Rows.Add(reader.Item("AcctCode"), reader.Item("AcctTitle"), reader.Item("SubAcctCode"), reader.Item("SubAcctTitle"), CBool(reader.Item("SubAcctDept")), reader.Item("SubAcctDeptName"), CBool(reader.Item("SubAcctList")), reader.Item("SubAcctListItem"), reader.Item("SubAcctListItemName"), Format$(reader.Item("DR"), "n2"), Format$(reader.Item("CR"), "n2"))
        End While

        reader.Close()
        cmdsql.Dispose()

        For introw = 0 To Me.dtgServiceCharge.Rows.Count - 1
            With Me.dtgServiceCharge
                RetrieveTerms(.Rows(introw), .Rows(introw).Cells("colSCharges").Value, "colSTerms", "colSDRAcctCode", "colSDRSub", "colSCRAcctCode", "colSCRSub")
            End With
        Next



        ComputeTotals()
        ComputeDRCRTotal()
        'PopulateAR(lblRefNo.Text)

        ''unpost history
        'PopUnpostHistory(Me.dgUnpostHistory, "IMPB", Me.lblRefNo.Text)
    End Sub

    Private Sub txtTotalAmtPHP_TextChanged(sender As Object, e As EventArgs) Handles txtTotalAmtPHP.TextChanged
        If Not Len(Me.txtTotalAmtPHP.Text) = 0 Then
            Me.txtAmtInWords.Text = English(Me.txtTotalAmtPHP.Text)
        End If
    End Sub

    Private Sub ChargeInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChargeInvoiceToolStripMenuItem.Click
        If Len(Me.lblRefNo.Text) = 0 Then
            MsgBox("Nothing to Print!", vbInformation, "System Message")
            Exit Sub
        End If
    End Sub

    Private Sub DraftChargeInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftChargeInvoiceToolStripMenuItem.Click
        If Len(Me.lblRefNo.Text) = 0 Then
            MsgBox("Nothing to Print!", vbInformation, "System Message")
            Exit Sub
        End If
    End Sub

    Private Sub cmdAddSRow_Click(sender As Object, e As EventArgs) Handles cmdAddSRow.Click
        Me.dtgServiceCharge.Rows.Add("", "", "", "", "0.00", "PHP", "0.00", False, "0.00", "")
    End Sub

    Private Sub cmdRemoveSRow_Click(sender As Object, e As EventArgs) Handles cmdRemoveSRow.Click
        If Me.dtgServiceCharge.RowCount > 0 Then
            Me.dtgServiceCharge.Rows.Remove(Me.dtgServiceCharge.CurrentRow)
        End If

        Me.dtgServiceCharge.EndEdit()

        ComputeTotals()
        PopdtgAcctgTitle()
    End Sub

    Private Sub dtgServiceCharge_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgServiceCharge.CellContentClick

    End Sub

    Private Sub dtgServiceCharge_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgServiceCharge.CellEndEdit
        With Me.dtgServiceCharge
            RetrieveTerms(.CurrentRow, .CurrentRow.Cells("colSCharges").Value, "colSTerms", "colSDRAcctCode", "colSDRSub", "colSCRAcctCode", "colSCRSub")
        End With
        ComputeTotals()
        PopdtgAcctgTitle()
    End Sub

    Private Sub txtExrateDollar_TextChanged(sender As Object, e As EventArgs) Handles txtExrateDollar.TextChanged

    End Sub

    Private Sub txtExrateDollar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExrateDollar.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub tstxtSearch_Click(sender As Object, e As EventArgs) Handles tstxtSearch.Click

    End Sub

    Private Sub tstxtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtSearch.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            SearchBilling(Me.tstxtSearch.Text, "RefNo")
        End If
    End Sub

    Private Sub tscmdClose_Click(sender As Object, e As EventArgs) Handles tscmdClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If MsgBox("Are you sure you want to create new transaction?", vbYesNo, "Create New?") = vbNo Then Exit Sub
        frmEnterBookNo.Tag = "EXP INV"
        frmEnterBookNo.ShowDialog()
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        If Len(Me.lblRefNo.Text) = 0 Then
            MsgBox("Nothing to Edit!", vbInformation, "System Message")
            Exit Sub
        End If

        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, False)
        EnableButtons2(False, False)
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckForRequiredEntries() = False Then Exit Sub

        If MsgBox("Are you sure you want to save this transaction?", vbYesNo, "Confirm Save") = vbNo Then Exit Sub

        SaveBilling()
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, True)
        EnableButtons2(True, True)
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        'Throw New NotImplementedException()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        SearchBilling(Me.tstxtSearch.Text, "RefNo")
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        If Len(Me.lblRefNo.Text) = 0 Then
            MsgBox("Nothing to Post!", vbInformation, "System Message")
            Exit Sub
        End If


        Dim dtCurrent As Date = GetServerDate()
        Dim strCI As String = ""

        If CDbl(Me.txtTotalInvoice.Text) > 0 Then
            strCI = GetRegisteredFormNo(1, 1)
            If strCI = -1 Then
                MsgBox("No released invoice form yet.", MsgBoxStyle.Information)
                Exit Sub
            End If
        Else
            strCI = ""
        End If


        Dim strsql As String = "UPDATE bill_expinv_main SET" &
                                " CINo = @CINo, " &
                                " Posted = @Posted, " &
                                " PostedBy = @PostedBy, " &
                                " PostedDate = @PostedDate, " &
                                " WHERE RefNo = '" & Me.lblRefNo.Text & "' AND Cancel = FALSE"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL

            cmdSQL.CommandText = strsql

            With cmdSQL.Parameters
                .AddWithValue("@CINo", strCI)
                .AddWithValue("@Posted", True)
                .AddWithValue("@PostedBy", CurrentUser)
                .AddWithValue("@PostedDate", dtCurrent)
            End With

            cmdSQL.ExecuteNonQuery()

            cmdSQL.CommandText = "UPDATE reg_trn_main SET " &
                                    "reg_status = 4, " &
                                    "reg_statusby = @reg_statusby, " &
                                    "reg_statusdate = @reg_statusdate, " &
                                    "related_ref = @related_ref " &
                                "WHERE reg_group = 1 AND reg_module = 1 " &
                                    "AND reg_no = @reg_no"

            cmdSQL.Parameters.Clear()
            With cmdSQL.Parameters
                .AddWithValue("@reg_statusby", CurrentUser)
                .AddWithValue("@reg_statusdate", dtCurrent)
                .AddWithValue("@related_ref", Me.lblRefNo.Text)
                .AddWithValue("@reg_no", strCI)
            End With

            cmdSQL.ExecuteNonQuery()

            trnSQL.Commit()
            cmdSQL.Dispose()

            Me.dtReceived.Enabled = False
            MsgBox("Billing Reference No. " & Me.lblRefNo.Text & " is Posted!" & vbCrLf &
                    "C.I.#: " & strCI, MsgBoxStyle.Information, "System Message")
        Catch ex As Exception
            Try
                trnSQL.Rollback()
                MsgBox(ex.Message)
            Catch ex1 As Exception
                If Not trnSQL.Connection Is Nothing Then
                    MsgBox("An exception of type " & ex1.GetType().ToString() &
                      " was encountered while attempting to roll back the transaction.")
                End If
            End Try
        End Try

        SearchBilling("RefNo", Me.lblRefNo.Text)
    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        If Len(Me.lblRefNo.Text) = 0 Then
            MsgBox("Nothing to Cance!", vbInformation, "System Message")
            Exit Sub
        End If

        Dim strsql As String
        Dim dtCurrent As Date = GetServerDate()

        If MsgBox("Are you sure you want cancel billing : " & Me.lblRefNo.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If
        strsql = "UPDATE bill_expinv_main SET Cancel=TRUE, CancelDate=@CancelDate, CancelBy='" & strCurrentUser & "' WHERE RefNo = '" & Me.lblRefNo.Text & "' AND Cancel = FALSE"

        Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@CancelDate", dtCurrent)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
        SearchBilling(Me.lblRefNo.Text, "RefNo")
        MsgBox("Billing " & Me.lblRefNo.Text & " canceled!", MsgBoxStyle.Information, "Canceled")
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        If Len(Me.lblRefNo.Text) = 0 Then
            MsgBox("Nothing to Re-Open!", vbInformation, "System Message")
            Exit Sub
        End If

        Dim strsql As String
        Dim dtCurrent As Date = GetServerDate()

        If MsgBox("Are you sure you want to re-open billing : " & Me.lblRefNo.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If
        strsql = "UPDATE bill_expinv_main SET Cancel=FALSE, CancelDate=null, CancelBy=null, Posted=FALSE, PostedlDate=null, PostedBy=null WHERE RefNo = '" & Me.lblRefNo.Text & "'"

        Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
        SearchBilling(Me.lblRefNo.Text, "RefNo")
        MsgBox("Billing " & Me.lblRefNo.Text & " re-opened!", MsgBoxStyle.Information, "Re-Opened")
    End Sub

End Class