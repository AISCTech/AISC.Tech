Imports MasterProject

Public Class frmCV
    Implements ICommonFunction
    Private EnableButtons As New clsEnableToolstripObjects()
    Public strAddNew As String
    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        Dim strCVNo As String = Me.lblCVNbr.Text

        Me.ErrorProvider1.Clear()

        If Len(Me.lblCVNbr.Text) = 0 Then
            MsgBox("Nothing to Cancel!", vbInformation, "System Message")
            Exit Sub
        End If

        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_Cancel") = False Then
        '    MsgBox("You are not allowed to Cancel", vbInformation, "System Message")
        '    Exit Sub
        'End If

        Me.ErrorProvider1.SetError(Me.chkCancel, "")
        If Me.chkCancel.Checked = True Then
            MsgBox("Voucher already Cancelled!", vbInformation, "System Message")
            Me.TabControl2.SelectedTab = Me.tpStatus
            Me.ErrorProvider1.SetError(Me.chkCancel, "Voucher already Cancelled!")
            Exit Sub
        End If

        If Me.chkLiquidate.Checked = True Then
            Me.TabControl2.SelectedTab = Me.tpStatus
            Me.txtStatLiquidateBy.Focus()
            If MsgBox("Voucher already Liquidated! Are you sure you want to Cancel this voucher?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
                Exit Sub
            End If
        ElseIf Me.chkRelease.Checked = True Then
            Me.TabControl2.SelectedTab = Me.tpStatus
            Me.txtStatReleaseBy.Focus()
            If MsgBox("Voucher already Released! Are you sure you want to Cancel this voucher?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
                Exit Sub
            End If
        Else
            If MsgBox("Are you sure you want to cancel Voucher?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim dtCurrent As Date = GetServerDate()

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim strsql As String

        strsql = "UPDATE tbl_cv SET " &
                "Cancelled = @Cancelled, " &
                "CancelBy = @CancelBy, " &
                "CancelDate = @CancelDate " &
                "WHERE CVNo = '" & strCVNo & "'"

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@Cancelled", True)
            .AddWithValue("@CancelBy", strCurrentUser)
            .AddWithValue("@CancelDate", dtCurrent)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
        'save to transaction logs
        'SaveTransLogs("Cancel CV", Me.Name, "CV No.", Me.lblCVNbr.Text, strCurrentUser)
        MsgBox("Voucher Cancelled!", MsgBoxStyle.Information, "System Message")
        PopCV(strCVNo)
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        Me.ErrorProvider1.Clear()
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_Edit") = False Then
        '    MsgBox("You are not allowed to Edit Voucher", vbInformation, "System Message")
        '    Exit Sub
        'End If
        If Len(Me.lblCVNbr.Text) = 0 Then
            MsgBox("Nothing to Edit!", vbInformation, "System Message")
            Exit Sub
        End If
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
        cmdCashInBank.Enabled = Not CheckIfGridHaveCashInBank()
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        Me.ErrorProvider1.Clear()
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_CreateCV") = False Then
        '    MsgBox("You are not allowed to Create Voucher", vbInformation, "System Message")
        '    Exit Sub
        'End If

        'If (Me.Tag = "CV" And Len(Me.lblCVNbr.Text) = 0) Or (Me.Tag = "MCV" And Len(Me.lblMCVNbr.Text) = 0) Then
        '    With frmCreateVoucher
        '        .Tag = Me.Tag
        '        .ShowDialog()
        '    End With
        'Else
        If MsgBox("Create new Voucher?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
            ClearEntries()

            Me.cboBank.Enabled = True
            Me.txtCheckNumber.Enabled = True
            Me.dtCheckDate.Enabled = True

            ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
            If Me.dtgParticulars.Rows.Count = 0 Then
                strAddNew = ""
            End If
            With frmCreateVoucher
                '.Tag = Me.Tag
                .Tag = "CV"
                .ShowDialog()
            End With
        End If
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
        If MsgBox("Clear all details?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
            ClearEntries()

            Me.cboBank.Enabled = True
            Me.txtCheckNumber.Enabled = True
            Me.dtCheckDate.Enabled = True

            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        End If
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        Me.ErrorProvider1.Clear()
        If CDbl(Me.lblCredit.Text) <> CDbl(Me.lblDebit.Text) Then
            MsgBox("Total Debit is not equal to total Credit!", MsgBoxStyle.Exclamation, "System Meassage")
            Exit Sub
        End If

        If CDbl(Me.txtTotal.Text) <> CDbl(Me.lblDebit.Text) Then
            MsgBox("Voucher Amount is not equal to total Debit and total Credit!", MsgBoxStyle.Exclamation, "System Meassage")
            Exit Sub
        End If

        If MsgBox("Save Voucher?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
            SaveCV()
            Select Case Me.Tag
                Case "CV"
                    PopCV(Me.lblCVNbr.Text)
            End Select

            'EnableObjects(True, True, False, True, True, True, True, False)
        End If
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        With frmSearchCV
            .Tag = Me.Tag
            .ShowDialog()
        End With
    End Sub

    Private Sub frmCV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Tag = "CV"
        FillComboBox(Me.cboBank, "Select Name from tbl_bank where Active = true", "Name")
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

            gpCVDetails.Enabled = blUserInput
            cmdAddEntry.Enabled = blUserInput
            cmdRemoveEntry.Enabled = blUserInput
            cmdAddPaymentDetails.Enabled = blUserInput
            cmdRemovePaymentDetails.Enabled = blUserInput
            cmdCashInBank.Enabled = blUserInput
            colDR.ReadOnly = Not blUserInput
            colCR.ReadOnly = Not blUserInput
        End With
    End Sub

    Public Sub ComputeTotalPayment()
        Dim dblTotal As Double = 0

        'Compute Total Amount of Payment Details
        For ctrRow As Integer = 0 To Me.dtgParticulars.Rows.Count - 1
            dblTotal += CDbl(Me.dtgParticulars.Rows(ctrRow).Cells("colCVAmt").Value)
        Next

        Me.txtTotal.Text = Format(dblTotal, "n2")
        dblTotal = 0
    End Sub

    Public Sub PopCV(ByVal strCVNo As String)
        Try
            ClearEntries()

            Dim strChkMC As String = ""
            Dim strsql As String = "SELECT tbl_cv.*, tbl_vendor.VendorName " &
                                    "FROM tbl_cv INNER JOIN tbl_vendor ON tbl_cv.PayeeID = tbl_vendor.VendorID " &
                                    "WHERE CVNo = '" & strCVNo & "'"

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

            Dim rdrCV As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            If rdrCV.HasRows = False Then
                rdrCV.Close()
                Exit Sub
            End If


            While rdrCV.Read
                Select Case Me.Tag
                    Case "CV"
                        Me.lblCVNbr.Text = rdrCV.Item("CVNo")
                End Select
                Me.txtPayeeCode.Text = rdrCV.Item("PayeeID")
                Me.txtPayeeName.Text = rdrCV.Item("VendorName")
                Me.cboBank.Text = rdrCV.Item("BankName")
                Me.txtCheckNumber.Text = rdrCV.Item("CheckNo")
                Me.dtCheckDate.Value = rdrCV.Item("CheckDate")
                Me.txtReceivedBy.Text = rdrCV.Item("ReceivedBy")
                'Me.txtStatPrepBy.Text = rdrCV.Item("PrepBy")
                'Me.txtStatPrepDate.Text = rdrCV.Item("PrepDate")

                'Dim dtCurrent As Date = GetServerDate()

                'If dtCurrent.Date >= rdrCV.Item("CheckDate") Then
                Me.chkPosted.Checked = True
                Me.txtStatPostedBy.Text = rdrCV.Item("PrepBy")
                Me.txtStatPostedDate.Text = rdrCV.Item("PrepDate")
                'Else
                'Me.chkPosted.Checked = False
                'End If

                Me.chkRelease.Checked = rdrCV.Item("Released")
                Me.txtCashInBank.Text = Format(rdrCV.Item("CashInBank"), "n2")
                If rdrCV.Item("Released") = True Then
                    Me.txtStatReleaseBy.Text = rdrCV.Item("ReleaseBy")
                    Me.txtStatReleaseDate.Text = rdrCV.Item("ReleaseDate")
                Else
                    Me.txtStatReleaseBy.Text = ""
                    Me.txtStatReleaseDate.Text = ""
                End If
                Me.chkLiquidate.Checked = rdrCV.Item("Liquidated")
                If rdrCV.Item("Liquidated") = True Then
                    Me.txtStatLiquidateBy.Text = rdrCV.Item("LiquidatedBy")
                    Me.txtStatLiquidateDate.Text = rdrCV.Item("LiquidatedDate")
                Else
                    Me.txtStatLiquidateBy.Text = ""
                    Me.txtStatLiquidateDate.Text = ""
                End If
                Me.chkCancel.Checked = rdrCV.Item("Cancelled")
                If rdrCV.Item("Cancelled") = True Then
                    Me.txtCancelledBy.Text = rdrCV.Item("CancelBy")
                    Me.txtCancelledDate.Text = rdrCV.Item("CancelDate")
                    Me.lblCancel.Visible = True
                Else
                    Me.txtCancelledBy.Text = ""
                    Me.txtCancelledDate.Text = ""
                    Me.lblCancel.Visible = False
                End If

                strChkMC = rdrCV.Item("VoucherType")
                Me.lblNonAccrualType.Text = rdrCV.Item("AccrualPCFT")

            End While

            rdrCV.Close()

            'ap_cvd
            strsql = "SELECT * FROM tbl_cvgl WHERE CVNo = '" & strCVNo & "'"

            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
            rdrCV = cmdSQL.ExecuteReader

            While rdrCV.Read
                With rdrCV
                    Me.dtgCheckEntry.Rows.Add("", .Item("CVD_Account_Code"), .Item("CVD_Account_Title"), Format(.Item("CVD_DR"), "n2"), Format(.Item("CVD_CR"), "n2"), .Item("CVD_SubAccount_Code"), .Item("CVD_SubAccount_Title"), .Item("CVD_SubAccount_Dept"), .Item("CVD_SubAccount_Deptname"), .Item("CVD_SubAccount_List"), .Item("CVD_SubAccount_ListItem"), .Item("CVD_SubAccount_ListItemName"))
                End With
            End While

            rdrCV.Close()
            ComputeTotalDRCR()

            'ap_cvp
            strsql = "SELECT * FROM tbl_cvp WHERE CVNo = '" & strCVNo & "'"
            Dim dblAmt As Double

            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
            rdrCV = cmdSQL.ExecuteReader

            While rdrCV.Read
                Me.dtgParticulars.Rows.Add(rdrCV.Item("ReqNo"), rdrCV.Item("APVNo"), "", rdrCV.Item("Fullpayment"), Format(rdrCV.Item("CVAmt"), "n2"), rdrCV.Item("CompanyCode"))
            End While

            rdrCV.Close()
            cmdSQL.Dispose()

            For ctrRow As Integer = 0 To Me.dtgParticulars.Rows.Count - 1
                With Me.dtgParticulars.Rows(ctrRow)
                    If Len(.Cells("colAPVNo").Value) > 0 Then
                        dblAmt = GetAmt("SELECT APVGL_CR FROM tbl_apvgl WHERE APVGL_APVNbr = '" & .Cells("colAPVNo").Value & "' AND APVGL_Account_Code = '2010'", "APVGL_CR")
                    Else
                        If Me.Tag = "CV" Then
                            dblAmt = GetAmt("SELECT REQ_TotalAmt FROM tbl_request WHERE REQ_Nbr = '" & .Cells("colReqNo").Value & "'", "REQ_TotalAmt")
                        End If
                    End If

                    .Cells("colPartAmt").Value = Format(dblAmt, "n2")
                End With
            Next

            Me.txtDateNeeded.Text = GetDtNedded(Me.dtgParticulars.Rows(0).Cells("colReqNo").Value, strChkMC).Date

            ComputeTotalPayment()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "System Message")
        End Try
    End Sub

    Private Function GetDtNedded(ByVal strReqNo As String, ByVal strChkMC As String) As Date
        GetDtNedded = Nothing
        Dim strsql As String = ""

        strsql = "SELECT tbl_request.REQ_DtNeed " &
                "FROM tbl_request " &
                "WHERE REQ_Nbr = '" & strReqNo & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim rdrDT As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While rdrDT.Read

            GetDtNedded = rdrDT.Item("REQ_DtNeed")

        End While

        rdrDT.Close()
        cmdSQL.Dispose()
    End Function

    Private Function GetAmt(ByVal strsql As String, ByVal strField As String) As Double
        GetAmt = 0
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            GetAmt = reader.Item(strField)
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Function

    Public Sub ComputeTotalDRCR()
        Me.lblDebit.Text = Format(0, "n2")
        Me.lblCredit.Text = Format(0, "n2")

        For ctrRow As Integer = 0 To Me.dtgCheckEntry.Rows.Count - 1
            With Me.dtgCheckEntry.Rows(ctrRow)
                If Len(.Cells("colDR").Value) = 0 Then
                    .Cells("colDR").Value = "0.00"
                Else
                    .Cells("colDR").Value = Format(CDbl(.Cells("colDR").Value), "n2")
                End If

                If Len(.Cells("colCR").Value) = 0 Then
                    .Cells("colCR").Value = "0.00"
                Else
                    .Cells("colCR").Value = Format(CDbl(.Cells("colCR").Value), "n2")
                End If

                Me.lblDebit.Text = Format(CDbl(Me.lblDebit.Text) + CDbl(.Cells("colDR").Value), "n2")
                Me.lblCredit.Text = Format(CDbl(Me.lblCredit.Text) + CDbl(.Cells("colCR").Value), "n2")
            End With
        Next
    End Sub
    Private Sub ClearEntries()
        With Me
            .lblCVNbr.Text = ""
            ' .lblMCVNbr.Text = ""
            .txtPayeeCode.Text = ""
            .txtPayeeName.Text = ""
            .cboBank.SelectedIndex = -1
            .txtCheckNumber.Text = ""
            .dtCheckDate.Value = GetServerDate()
            .txtReceivedBy.Text = ""
            .lblDebit.Text = ""
            .lblCredit.Text = ""
            .dtgCheckEntry.Rows.Clear()
            .dtgParticulars.Rows.Clear()
            .txtTotal.Text = ""
            .txtAmtInWords.Text = ""
            .txtStatPostedBy.Text = ""
            .txtStatPostedDate.Text = ""
            .chkPosted.Checked = False
            .txtStatReleaseBy.Text = ""
            .txtStatReleaseDate.Text = ""
            .chkRelease.Checked = False
            .txtStatLiquidateBy.Text = ""
            .txtStatLiquidateDate.Text = ""
            .chkLiquidate.Checked = False
            .txtCancelledBy.Text = ""
            .txtCancelledDate.Text = ""
            .chkCancel.Checked = False
            .txtCashInBank.Text = ""
            .txtCashInBankWords.Text = ""
            .txtDateNeeded.Text = ""
            .txtCompanyCode.Text = strCompanyCode
            .ErrorProvider1.Clear()
        End With
    End Sub

    Private Sub cmdCashInBank_Click(sender As Object, e As EventArgs) Handles cmdCashInBank.Click
        Me.ErrorProvider1.Clear()
        If Me.cboBank.SelectedIndex = -1 Then
            MsgBox("Please select Bank!", MsgBoxStyle.Exclamation, "System Message")
            Me.ErrorProvider1.SetError(Me.cboBank, "Please select Bank!")
            Exit Sub
        End If

        Me.ErrorProvider1.SetError(Me.txtCheckNumber, "")
        If Len(Me.txtCheckNumber.Text) = 0 Then
            MsgBox("Please input Check No.!", MsgBoxStyle.Exclamation, "System Message")
            Me.ErrorProvider1.SetError(Me.txtCheckNumber, "Please input Check No.!")
            Exit Sub
        End If

        'If CheckIfClosedOnFP() = False Then Exit Sub
        Dim dtCurrent As Date = GetServerDate()

        If dtCurrent.Day > 15 Then
            If Me.dtCheckDate.Value <= dtCurrent.AddMonths(-2) Then
                MsgBox("Invalid Check Date. The month of " & MonthName(Me.dtCheckDate.Value.Month) & " " & Me.dtCheckDate.Value.Year & " is already closed in Fiscal Period!", MsgBoxStyle.Exclamation, "System Message")
                Me.ErrorProvider1.SetError(Me.dtCheckDate, "Invalid Check Date. The month of " & MonthName(Me.dtCheckDate.Value.Month) & " " & Me.dtCheckDate.Value.Year & " is already closed in Fiscal Period!")
                Exit Sub
            End If
        Else
            If Me.dtCheckDate.Value <= dtCurrent.AddMonths(-1) Then
                MsgBox("Invalid Check Date. The month of " & MonthName(Me.dtCheckDate.Value.Month) & " " & Me.dtCheckDate.Value.Year & " is already closed in Fiscal Period!", MsgBoxStyle.Exclamation, "System Message")
                Me.ErrorProvider1.SetError(Me.dtCheckDate, "Invalid Check Date. The month of " & MonthName(Me.dtCheckDate.Value.Month) & " " & Me.dtCheckDate.Value.Year & " is already closed in Fiscal Period!")
                Exit Sub
            End If
        End If

        If CDbl(Me.txtTotal.Text) <> CDbl(Me.lblDebit.Text) Then
            MsgBox("Voucher Amount is not equal to Debit Amount!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        'If Len(Me.txtReceivedBy.Text) = 0 Then
        'MsgBox("Please input Received By!", MsgBoxStyle.Exclamation, "System Message")
        'Exit Sub
        'End If

        If SetBankEntry() = False Then Exit Sub

        ComputeTotalDRCR()

        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, False)
    End Sub

    Private Sub cmdRemoveEntry_Click(sender As Object, e As EventArgs) Handles cmdRemoveEntry.Click
        With Me.dtgCheckEntry
            If Me.dtgCheckEntry.Rows.Count > 0 Then
                If .CurrentRow.Index >= 0 Then
                    .Rows.Remove(.CurrentRow)
                    cmdCashInBank.Enabled = Not CheckIfGridHaveCashInBank()
                End If
            End If
        End With
    End Sub

    Private Function ComputeCashInBank()
        Dim dblDR As Double, dblCR As Double

        For ctrRow As Integer = 0 To Me.dtgCheckEntry.Rows.Count - 1
            With Me.dtgCheckEntry.Rows(ctrRow)
                dblDR += CDbl(.Cells("colDR").Value)
                dblCR += CDbl(.Cells("colCR").Value)
            End With
        Next

        ComputeCashInBank = dblDR - dblCR
    End Function
    Private Function SetBankEntry() As Boolean
        SetBankEntry = False
        Dim BankAccountTitle As String = ""
        Dim BankSubAccountTitle As String = ""
        Dim dblCashInBankAmt As Double = ComputeCashInBank()
        Dim strsql2 As String

        strsql2 = "SELECT tbl_bank.Account_Code, tbl_bank.Name, tbl_bank.SubAccount_Code " &
                    "FROM tbl_bank " &
        "WHERE tbl_bank.Name ='" & cboBank.Text & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd3 = New MySql.Data.MySqlClient.MySqlCommand(strsql2, cnnDBMaster)
        Dim reader3 As MySql.Data.MySqlClient.MySqlDataReader = cmd3.ExecuteReader()
        While reader3.Read()
            If IsDBNull(reader3.Item("Account_Code")) = True Or IsDBNull(reader3.Item("SubAccount_Code")) = True Then
                SetBankEntry = False
                MsgBox("Selected bank " & Me.cboBank.Text & " has no assigned account code!", MsgBoxStyle.Exclamation, "System Message")
                reader3.Close()
                cmd3.Dispose()
                Exit Function
            Else
                BankAccountTitle = reader3.Item("Account_Code")
                BankSubAccountTitle = reader3.Item("SubAccount_Code")
                SetBankEntry = True
            End If
        End While
        reader3.Close()
        cmd3.Dispose()

        Dim strSQL As String

        strSQL = "SELECT tbl_glmain.Account_Code, tbl_glmain.Account_Title, tbl_glsub.Account_Code, tbl_glsub.SubAccount_Code, tbl_glsub.SubAccount_Title " &
                "FROM tbl_glmain INNER JOIN tbl_glsub ON tbl_glmain.Account_Code = tbl_glsub.Account_Code " &
               "WHERE tbl_glmain.Account_Code = '" & BankAccountTitle & "' and tbl_glsub.SubAccount_Code = '" & BankSubAccountTitle & "' "


        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmd2.ExecuteReader()

        If reader2.HasRows = False Then
            SetBankEntry = False
            MsgBox("Selected bank " & Me.cboBank.Text & " has no assigned account code!", MsgBoxStyle.Exclamation, "System Message")
            cmd2.Dispose()
            reader2.Close()
            Exit Function
        End If

        While reader2.Read
            Me.dtgCheckEntry.Rows.Add("", reader2.Item("Account_Code"), reader2.Item("Account_Title"), "", dblCashInBankAmt, reader2.Item("SubAccount_Code"), reader2.Item("SubAccount_Title"), False, "", False, "", "")
        End While

        cmd2.Dispose()
        reader2.Close()
        cnnDBMaster.Close()

        Me.txtCashInBank.Text = Format(dblCashInBankAmt, "n2")
    End Function

    Private Sub SaveCV()
        Try
            Dim dtCurrent As Date = GetServerDate()
            Dim strsql As String, strCVNo As String
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            'Select Case Me.Tag
            '    Case "CV"
            strCVNo = Me.lblCVNbr.Text
            '    Case Else
            '        strCVNo = ""
            'End Select

            If Len(strCVNo) = 0 Then
                'Select Case Me.Tag
                ' Case "CV"
                strCVNo = "CV" & GetCtrlNbr(strCompanyCode, strSiteCode, "CV")
                '  Case "MCV"
                '   strCVNo = "MCV" & GetMCheckVoucherNbr() & GetYear()
                '  End Select

                strsql = "INSERT INTO tbl_cv (CVNo, VoucherType, CheckDate, PayeeID, PrepBy, PrepDate, Cancelled, " &
                                    "BankName, CheckNo, CashInBank, Released, Liquidated, ReceivedBy, AccrualPCFT) " &
                                    "VALUES (@CVNo, @VoucherType, @CheckDate, @PayeeID, @PrepBy, @PrepDate, @Cancelled, " &
                                    "@BankName, @CheckNo, @CashInBank, @Released, @Liquidated, @ReceivedBy, @AccrualPCFT)"

                cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@CVNo", strCVNo)
                    Select Case Me.Tag
                        Case "CV"
                            .AddWithValue("@VoucherType", "Check")
                        Case "MCV"
                            .AddWithValue("@VoucherType", "MC")
                    End Select
                    .AddWithValue("@CheckDate", Me.dtCheckDate.Value)
                    .AddWithValue("@PayeeID", Me.txtPayeeCode.Text)
                    .AddWithValue("@PrepBy", strCurrentUser)
                    .AddWithValue("@PrepDate", dtCurrent)
                    .AddWithValue("@Cancelled", False)
                    .AddWithValue("@BankName", Me.cboBank.Text)
                    .AddWithValue("@CheckNo", Me.txtCheckNumber.Text)
                    .AddWithValue("@CashInBank", CDbl(Me.txtCashInBank.Text))
                    .AddWithValue("@Released", False)
                    .AddWithValue("@Liquidated", False)
                    .AddWithValue("@ReceivedBy", Me.txtReceivedBy.Text)
                    .AddWithValue("@AccrualPCFT", Me.lblNonAccrualType.Text)
                End With

                cmdSQL.ExecuteNonQuery()

                UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "CV")
            Else
                strsql = "UPDATE tbl_cv SET " &
                            "Checkdate = @CheckDate, " &
                            "BankName = @BankName, " &
                            "CheckNo = @CheckNo, " &
                            "CashInBank = @CashInBank, " &
                            "ReceivedBy = @ReceivedBy " &
                         "WHERE CVNo = '" & strCVNo & "'"

                cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@CheckDate", Me.dtCheckDate.Value)
                    .AddWithValue("@BankName", Me.cboBank.Text)
                    .AddWithValue("@CheckNo", Me.txtCheckNumber.Text)
                    .AddWithValue("@CashInBank", CDbl(Me.txtCashInBank.Text))
                    .AddWithValue("@ReceivedBy", Me.txtReceivedBy.Text)
                End With

                cmdSQL.ExecuteNonQuery()
            End If

            'ap_cvd
            strsql = "DELETE FROM tbl_cvgl WHERE CVNo = '" & strCVNo & "'"

            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
            cmdSQL.ExecuteNonQuery()


            'delete record in tbl_generalledger
            DeleteToGLTable(strCVNo, 11)


            Dim dtgGridRow As DataGridViewRow

            For ctrRow As Integer = 0 To Me.dtgCheckEntry.Rows.Count - 1
                strsql = "INSERT INTO tbl_cvgl (CVNo, CVD_Account_Code, CVD_Account_Title, CVD_DR, CVD_CR, " &
                            "CVD_SubAccount_Code, CVD_SubAccount_Title, CVD_SubAccount_Dept, CVD_SubAccount_DeptName, " &
                            "CVD_SubAccount_List, CVD_SubAccount_ListItem, CVD_SubAccount_ListItemName, CVD_AdjustedEntry) " &
                         "VALUES (@CVNo, @CVD_Account_Code, @CVD_Account_Title, @CVD_DR, @CVD_CR, " &
                            "@CVD_SubAccount_Code, @CVD_SubAccount_Title, @CVD_SubAccount_Dept, @CVD_SubAccount_DeptName, " &
                            "@CVD_SubAccount_List, @CVD_SubAccount_ListItem, @CVD_SubAccount_ListItemName, @CVD_AdjustedEntry)"

                dtgGridRow = Me.dtgCheckEntry.Rows(ctrRow)

                cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@CVNo", strCVNo)
                    .AddWithValue("@CVD_Account_Code", dtgGridRow.Cells("colAcctCode").Value)
                    .AddWithValue("@CVD_Account_Title", dtgGridRow.Cells("colAcctTitle").Value)
                    .AddWithValue("@CVD_DR", CDbl(dtgGridRow.Cells("colDR").Value))
                    .AddWithValue("@CVD_CR", CDbl(dtgGridRow.Cells("colCR").Value))
                    .AddWithValue("@CVD_SubAccount_Code", dtgGridRow.Cells("colSubCode").Value)
                    .AddWithValue("@CVD_SubAccount_Title", dtgGridRow.Cells("colSubAcctTitle").Value)
                    .AddWithValue("@CVD_SubAccount_Dept", dtgGridRow.Cells("colchkDept").Value)
                    .AddWithValue("@CVD_SubAccount_DeptName", dtgGridRow.Cells("colDeptName").Value)
                    .AddWithValue("@CVD_SubAccount_List", dtgGridRow.Cells("colchkList").Value)
                    .AddWithValue("@CVD_SubAccount_ListItem", dtgGridRow.Cells("colListItem").Value)
                    .AddWithValue("@CVD_SubAccount_ListItemName", dtgGridRow.Cells("colListItemName").Value)
                    .AddWithValue("@CVD_AdjustedEntry", False)
                End With

                cmdSQL.ExecuteNonQuery()

                InsertToGLTable(11, GetGeneralLedgerModuleName(11), strCVNo, dtgGridRow.Cells("colAcctCode").Value, dtgGridRow.Cells("colAcctTitle").Value, dtgGridRow.Cells("colSubCode").Value, dtgGridRow.Cells("colSubAcctTitle").Value, CDbl(dtgGridRow.Cells("colDR").Value), CDbl(dtgGridRow.Cells("colCR").Value), dtgGridRow.Cells("colchkDept").Value, dtgGridRow.Cells("colDeptName").Value, dtgGridRow.Cells("colchkList").Value, dtgGridRow.Cells("colListItem").Value, dtgGridRow.Cells("colListItemName").Value)
            Next

            'tbl_cvp
            strsql = "DELETE FROM tbl_cvp WHERE CVNo = '" & strCVNo & "'"

            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
            cmdSQL.ExecuteNonQuery()

            For ctrRow As Integer = 0 To Me.dtgParticulars.Rows.Count - 1
                strsql = "INSERT INTO tbl_cvp (CVNo, ReqNo, APVNo, FullPayment, CVAmt, CompanyCode) " &
                         "VALUES (@CVNo, @ReqNo, @APVNo, @FullPayment, @CVAmt, @CompanyCode)"

                cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                dtgGridRow = Me.dtgParticulars.Rows(ctrRow)

                With cmdSQL.Parameters
                    .AddWithValue("@CVNo", strCVNo)
                    .AddWithValue("@ReqNo", dtgGridRow.Cells("colReqNo").Value)
                    .AddWithValue("@APVNo", dtgGridRow.Cells("colAPVNo").Value)
                    .AddWithValue("@FullPayment", dtgGridRow.Cells("colFull").Value)
                    .AddWithValue("@CVAmt", CDbl(dtgGridRow.Cells("colCVAmt").Value))
                    .AddWithValue("@CompanyCode", dtgGridRow.Cells("colCompanyCode").Value)
                End With

                cmdSQL.ExecuteNonQuery()
            Next


            ''Save Check Voucher No to Petty Cash Replenishment
            'strsql = "SELECT AccrualPCFT FROM tbl_cv WHERE CVNo = '" & strCVNo & "'"
            'Dim strAccrualPCFT As String = ""

            'cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
            'Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            'While reader.Read
            '    strAccrualPCFT = reader.Item("AccrualPCFT")
            'End While

            'reader.Close()

            'If strAccrualPCFT = "Petty Cash" Then
            '    For ctrRow As Integer = 0 To Me.dtgParticulars.Rows.Count - 1
            '        strsql = "UPDATE ap_pcv_replenish SET " & _
            '                 "CVNbr = @CVNbr " & _
            '                 "WHERE ap_pcv_replenish.CRNbr = '" & Me.dtgParticulars.Rows(ctrRow).Cells("colReqNo").Value & "'"

            '        cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

            '        With cmdSQL.Parameters
            '            .AddWithValue("@CVNbr", strCVNo)
            '        End With

            '        cmdSQL.ExecuteNonQuery()
            '    Next
            'End If
            ''>>>------------<>>

            'cmdSQL.Dispose()

            Select Case Me.Tag
                Case "CV"
                    Me.lblCVNbr.Text = strCVNo
                    MsgBox("Check Voucher " & Me.lblCVNbr.Text & " Saved!", MsgBoxStyle.Information, "System Message")
                Case "MCV"
                    Me.lblCVNbr.Text = strCVNo
                    MsgBox("MC Voucher " & Me.lblCVNbr.Text & " Saved!", MsgBoxStyle.Information, "System Message")
            End Select

            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "System Message")
        End Try
    End Sub

    Private Function CheckIfGridHaveCashInBank()
        CheckIfGridHaveCashInBank = False
        For Each dtgTempRow As DataGridViewRow In Me.dtgCheckEntry.Rows
            If dtgTempRow.Cells(colAcctCode.Name).Value = "1020" Then
                CheckIfGridHaveCashInBank = True
                Exit Function
            End If
        Next
    End Function

    Private Sub btRelease_Click(sender As Object, e As EventArgs) Handles btRelease.Click
        Me.ErrorProvider1.Clear()
        If Len(Me.lblCVNbr.Text) = 0 Then
            MsgBox("Nothing to Release!", vbInformation, "System Message")
            Exit Sub
        End If
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_Release") = False Then
        '    MsgBox("You are not allowed to Release", vbInformation, "System Message")
        '    Exit Sub
        'End If

        Dim strRefNo As String = Me.lblCVNbr.Text


        Me.ErrorProvider1.SetError(Me.chkCancel, "")
        If Me.chkCancel.Checked = True Then
            MsgBox("Voucher already Cancelled!", vbInformation, "System Message")
            Me.TabControl2.SelectedTab = Me.tpStatus
            Me.ErrorProvider1.SetError(Me.chkCancel, "Voucher already Cancelled!")
            Exit Sub
        End If

        Me.ErrorProvider1.SetError(Me.chkLiquidate, "")
        If Me.chkLiquidate.Checked = True Then
            MsgBox("Voucher already Liquidated!", vbInformation, "System Message")
            Me.TabControl2.SelectedTab = Me.tpStatus
            Me.ErrorProvider1.SetError(Me.chkLiquidate, "Voucher already Liquidated!")
            Exit Sub
        End If

        Me.ErrorProvider1.SetError(Me.chkRelease, "")
        If Me.chkRelease.Checked = True Then
            MsgBox("Voucher already Released!", vbInformation, "System Message")
            Me.TabControl2.SelectedTab = Me.tpStatus
            Me.ErrorProvider1.SetError(Me.chkRelease, "Voucher already Released!")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to release Voucher?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If

        If Len(txtReceivedBy.Text) = 0 Then
            MsgBox("Please Input Received By then click Release.", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
            Me.gpCVDetails.Enabled = True
            Me.ErrorProvider1.SetError(Me.txtReceivedBy, "Please Input Received By then click Release.")
            Me.txtReceivedBy.Focus()
            Exit Sub
        End If

        Dim dtCurrent As Date = GetServerDate()

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim strsql As String

        strsql = "UPDATE tbl_cv SET " &
                "Released = @Released, " &
                "ReceivedBy = @ReceivedBy, " &
                "ReleaseBy = @ReleaseBy, " &
                "ReleaseDate = @ReleaseDate " &
                "WHERE CVNo = '" & strRefNo & "'"

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@Released", True)
            .AddWithValue("@ReceivedBy", Me.txtReceivedBy.Text)
            .AddWithValue("@ReleaseBy", strCurrentUser)
            .AddWithValue("@ReleaseDate", dtCurrent)
        End With

        cmdSQL.ExecuteNonQuery()

        ''Replenish Petty Cash Check
        'strsql = "SELECT AccrualPCFT FROM ap_cv WHERE CVNo = '" & Me.lblCVNbr.Text & "'"
        'Dim strAccrualPCFT As String = ""

        'cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        'Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        'While reader.Read
        '    strAccrualPCFT = reader.Item("AccrualPCFT")
        'End While

        'reader.Close()

        'If strAccrualPCFT = "Petty Cash" Then
        '    For ctrRow As Integer = 0 To Me.dtgParticulars.Rows.Count - 1
        '        strsql = "UPDATE ap_pcv_replenish SET " & _
        '                 "Replenish = @Replenish, " & _
        '                 "RepDate = @RepDate, " & _
        '                 "RepBy = @RepBy " & _
        '                 "WHERE ap_pcv_replenish.CRNbr = '" & Me.dtgParticulars.Rows(ctrRow).Cells("colReqNo").Value & "'"

        '        cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        '        With cmdSQL.Parameters
        '            .AddWithValue("@Replenish", True)
        '            .AddWithValue("@RepDate", dtCurrent)
        '            .AddWithValue("@RepBy", CurrentUser)
        '        End With

        '        cmdSQL.ExecuteNonQuery()
        '    Next
        'End If

        'cmdSQL.Dispose()

        'save to transaction logs
        SaveTransLogs("Release CV", Me.Name, "CV No.", Me.lblCVNbr.Text, strCurrentUser)

        MsgBox("Voucher Released!", MsgBoxStyle.Information, "System Message")
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        PopCV(strRefNo)
        'If CheckIfAdvances(strRefNo) = False Then
        '    Exit Sub
        'End If
        'DeductDCNote()
        ''DeductAdvances(Me.txtPayeeName.Text)
    End Sub

    Private Sub btLiquidate_Click(sender As Object, e As EventArgs) Handles btLiquidate.Click
        Me.ErrorProvider1.Clear()
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_Liquidate") = False Then
        '    MsgBox("You are not allowed to Liquidate", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If Len(Me.lblCVNbr.Text) = 0 Then
            MsgBox("Nothing to Liquidate!", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.chkCancel.Checked = True Then
            MsgBox("Voucher already Cancelled!", vbInformation, "System Message")
            Me.TabControl2.SelectedTab = Me.tpStatus
            Me.ErrorProvider1.SetError(Me.chkCancel, "Voucher already Cancelled!")
            Exit Sub
        End If

        If Me.chkLiquidate.Checked = True Then
            MsgBox("Voucher already Liquidated!", vbInformation, "System Message")
            Me.TabControl2.SelectedTab = Me.tpStatus
            Me.ErrorProvider1.SetError(Me.chkLiquidate, "Voucher already Liquidated!")
            Exit Sub
        End If

        If Me.chkRelease.Checked = False Then
            MsgBox("Voucher is not yet Released!", vbInformation, "System Message")
            Me.TabControl2.SelectedTab = Me.tpStatus
            Me.ErrorProvider1.SetError(Me.chkRelease, "Voucher is not yet Released!")
            Exit Sub
        End If

        If MsgBox("Liquidate Voucher?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If

        'frmLiquidateCV.Tag = "CV"
        'frmLiquidateCV.ShowDialog()

        'Select Case Me.Tag
        '    Case "CV"
        '        frmPost.Tag = "Check Voucher"
        '    Case "MCV"
        '        frmPost.Tag = "MC Voucher"
        'End Select
        'frmPost.ShowDialog()
    End Sub

    Private Sub txtCashInBank_TextChanged(sender As Object, e As EventArgs) Handles txtCashInBank.TextChanged
        If Not Len(Me.txtCashInBank.Text) = 0 Then
            Me.txtCashInBankWords.Text = English(Me.txtCashInBank.Text)
        End If
    End Sub

    Private Sub cmdAddEntry_Click(sender As Object, e As EventArgs) Handles cmdAddEntry.Click
        Me.dtgCheckEntry.Rows.Add()
        ComputeTotalDRCR()
    End Sub

    Private Sub dtgCheckEntry_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCheckEntry.CellContentClick
        If Me.dtgCheckEntry.Columns(e.ColumnIndex).Name.Equals("colSelectEntry") And Me.colDR.ReadOnly = False And e.RowIndex >= 0 Then
            frmSelectGLEntry.Tag = "CV"
            frmSelectGLEntry.txtLineNbr.Text = e.RowIndex
            frmSelectGLEntry.ShowDialog()
        End If
    End Sub

    Private Sub dtgCheckEntry_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCheckEntry.CellEndEdit
        ComputeTotalDRCR()
    End Sub

    Private Sub dtgCheckEntry_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dtgCheckEntry.EditingControlShowing
        Dim tb As TextBox

        tb = CType(e.Control, TextBox)
        '---add an event handler to the TextBox control---
        AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Me.dtgCheckEntry.CurrentCell.ColumnIndex = 3 Or Me.dtgCheckEntry.CurrentCell.ColumnIndex = 4 Then
            SetCharacter(MyOption.Numeric, e)
        Else
            SetCharacter(MyOption.AlphaNumeric, e)
        End If
    End Sub

    Private Sub cmdAddPaymentDetails_Click(sender As Object, e As EventArgs) Handles cmdAddPaymentDetails.Click
        With frmCreateVoucher
            .lblNonAccrualType.Text = Me.lblNonAccrualType.Text
            .txtPayeeID.Text = Me.txtPayeeCode.Text
            .txtPayeeName.Text = Me.txtPayeeName.Text
            .txtDateNeeded.Text = Me.txtDateNeeded.Text

            .Tag = Me.Tag
            .ShowDialog()
        End With
    End Sub

    Private Sub cmdRemovePaymentDetails_Click(sender As Object, e As EventArgs) Handles cmdRemovePaymentDetails.Click
        With Me.dtgParticulars
            If .CurrentRow.Index >= 0 Then
                .Rows.Remove(.CurrentRow)
                If .Rows.Count = 0 Then
                    Me.lblNonAccrualType.Text = ""
                    Me.cmdAddPaymentDetails.Enabled = True
                End If
            End If
        End With
    End Sub
End Class