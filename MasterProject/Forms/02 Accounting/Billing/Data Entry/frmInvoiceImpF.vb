Imports MySql.Data.MySqlClient
Public Class frmInvoiceImpF
    Dim strEditReason As String = ""
    Public PrintCurrency As String
    Public DateSaved As Date

    Public Sub PopAllowReleaseHistory(ByVal strHBL As String)
        Dim strsql As String = "SELECT * FROM bill_impf_allowrelease " &
                                "WHERE HouseBL = '" & strHBL & "' ORDER BY AllowReleaseDate DESC"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgAllowReleaseHistory.Rows.Clear()

        While reader.Read
            Me.dtgAllowReleaseHistory.Rows.Add(reader.Item("AllowReleaseDate"), reader.Item("AllowRelease"), reader.Item("AllowReleaseBy"), reader.Item("RequestedBy"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Public Function CheckIfAllowRelease(ByVal strHBL As String) As Boolean
        CheckIfAllowRelease = False
        Dim strsql As String = "SELECT * FROM bill_impf_allowrelease " &
                                "WHERE AllowReleaseDate = " &
                                "(SELECT MAX(AllowReleaseDate) from bill_impf_allowrelease WHERE HouseBL = '" & strHBL & "' GROUP BY HouseBL) " &
                                "AND HouseBL = '" & strHBL & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            CheckIfAllowRelease = reader.Item("AllowRelease")
            Me.txtAllowReleaseBy.Text = reader.Item("AllowReleaseBy")
            Me.txtAllowReleaseDate.Text = reader.Item("AllowReleaseDate")
            Me.txtAllowReleaseRequestedBy.Text = reader.Item("RequestedBy")
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Function

    Public Function GetExRate(ByVal strCurrency As String) As Double
        GetExRate = 0
        Dim strsql As String = "SELECT Rate FROM lib_currency WHERE Acronym = '" & strCurrency & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            GetExRate = reader.Item("Rate")
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Function

    Private Sub frmInvoiceImpF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If connImport.State <> ConnectionState.Open Then connImport.Open()
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        'If connSales.State <> ConnectionState.Open Then connSales.Open()

        If Me.Tag <> "Aging" Then
            Me.dtArrivalDate.Value = GetServerDate()
        End If
        'PopcboMBL()
        'PopSIS()
        FillComboBox(Me.cboMBL, "SELECT MBLNo FROM v_frwdg_docs_mbl WHERE ArrivalDate = '" & Format$(dtArrivalDate.Value, "yyyy-MM-dd") & "'", "MBLNo")
        'PopGridCharges()

        FillGridComboBox(Me.colCharges, "Select ChargeName from lib_charges where ChargeName is not null", "ChargeName")
        FillComboBox(Me.cboHBL, "Select HBLNo from v_frwdg_docs_hbl where MBLNo = '" & Replace(Me.cboMBL.Text, "'", "''") & "'", "HBLNo")
        FillComboBox(Me.cboCurrency, "Select Acronym from lib_currency where Acronym is not null", "Acronym")

        'PopComboAccess(Me.cboBilledTo, "SELECT ConsigneeName FROM ImpConsignee ORDER BY ConsigneeName", "ConsigneeName")
        'PopComboSQL(Me.cboCurrency, "SELECT CurrencyInWords FROM lib_currency", "CurrencyInWords")

        Me.sslblCurrentUser.Text = "Current User : " & strCurrentUser & " "
    End Sub

    Private Sub cmdAddRow_Click(sender As Object, e As EventArgs) Handles cmdAddRow.Click
        Me.dtgBilling.Rows.Add("", "", "0", "0.00", "0.00", False)

        GridRestriction()
    End Sub

    Private Sub cmdRemoveRow_Click(sender As Object, e As EventArgs) Handles cmdRemoveRow.Click
        If Me.dtgBilling.RowCount > 0 Then
            Me.dtgBilling.Rows.Remove(Me.dtgBilling.CurrentRow)
        End If

        Me.dtgBilling.EndEdit()
        ComputeTotal()
        PopdtgAcctgTitle()
    End Sub

    Private Sub cmdClearRows_Click(sender As Object, e As EventArgs) Handles cmdClearRows.Click
        Me.dtgBilling.Rows.Clear()
        Me.txtVat.Text = ""
        'Me.txtSOA.Text = ""
        Me.txtGrandTotal.Text = ""
        Me.txtAmtInWords.Text = ""
    End Sub

    'Public Sub PopSIS()
    '    Dim strSQL As String = "SELECT sisID FROM SISmain"

    '    If connSales.State <> ConnectionState.Open Then connSales.Open()

    '    Dim cmdSQL = New OleDb.OleDbCommand(strSQL, connSales)

    '    Dim reader As OleDb.OleDbDataReader = cmdSQL.ExecuteReader

    '    Me.cboSISNo.Items.Add("")

    '    While reader.Read
    '        Me.cboSISNo.Items.Add(reader.Item("sisID"))
    '    End While

    '    reader.Close()
    '    cmdSQL.Dispose()
    'End Sub


    'Public Sub PopcboMBL()
    '    Dim strSQL As String = "SELECT MBLNo FROM tbl_frwdg_docs_mbl WHERE ArrivalDate = '" & Format$(dtArrivalDate.Value, "MM,dd,yyyy") & "'"

    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

    '    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

    '    Me.cboMBL.Items.Clear()
    '    Me.cboMBL.Text = ""

    '    While reader.Read
    '        Me.cboMBL.Items.Add(reader.Item("MBLNo"))
    '    End While

    '    reader.Close()
    '    cmdSQL.Dispose()
    'End Sub

    Private Sub PopcboHBL(ByVal pMBL As String)
        pMBL = pMBL.Replace("'", "''")
        Dim strSQL As String = "SELECT HBLNo FROM v_frwdg_docs_hbl WHERE MBLNo = '" & pMBL & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.cboHBL.Items.Clear()

        While reader.Read
            Me.cboHBL.Items.Add(reader.Item("HBLNo"))
        End While

        If Me.cboHBL.SelectedIndex = -1 Then
            Me.cboHBL.Text = ""
        End If

        reader.Close()
        cmdSQL.Dispose()

        EnableBillingButtons(False, False, False, True, False, False, False, False)
    End Sub

    Public Sub RetrieveMBL(ByVal pMBL As String)
        ClearAll()
        pMBL = pMBL.Replace("'", "''")
        Dim strSQL As String = "SELECT * " &
             "FROM v_frwdg_docs_mbl " &
             "WHERE MBLNo = '" & pMBL & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            'If reader.Item("blank") = 3 Then
            '    MsgBox("MBL Already Canceled!", MsgBoxStyle.Exclamation, "System Message")
            '    reader.Close()
            '    Exit Sub
            'End If

            Me.dtArrivalDate.Value = reader.Item("ArrivalDate")
            Me.cboMBL.Text = reader.Item("MBLNo")
            Me.txtVessel.Text = reader.Item("VesselName")
            'Me.txtRegNo.Text = reader.Item("blank")
            'Me.txtExRate.Text = reader.Item("blank")
            'Me.txtContNo.Text = reader.Item("blank")
            Me.txtDevanningDate.Text = reader.Item("DevanDate")
            Me.txtPortofDischarge.Text = reader.Item("PortOfDischargeName")
            Me.txtOrigin.Text = reader.Item("PortOfLoadingName")
            'Me.txtRegYear.Text = reader.Item("blank")
            'Me.txtShipper.Text = reader.Item("blank")
            Me.txtCarrier.Text = reader.Item("VesselName")
            'Me.txtCargoLocation.Text = reader.Item("blank")

            'Select Case reader.Item("ShipmentMode")
            '    Case "SEA"
            '        Me.optBySea.Checked = True
            '    Case "AIR"
            '        Me.optByAir.Checked = True
            'End Select
            Me.optBySea.Checked = True

            'If IsDBNull(reader.Item("ConsolCoload")) <> True Then
            '    Select Case reader.Item("ConsolCoload")
            '        Case "Console"
            '            Me.optConsole.Checked = True
            '        Case "Co-load"
            '            Me.optCoLoad.Checked = True
            '    End Select
            'End If
            Me.optConsole.Checked = True
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Public Sub RetrieveHBL(ByVal pHBL As String)
        ClearHBL()

        Dim strSQL As String = "SELECT * FROM v_frwdg_docs_hbl " &
             "WHERE HBLNo = '" & pHBL & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            Me.txtHBLShipper.Text = reader.Item("ShipperName1")
            Me.txtHBLCneeForwarder.Text = reader.Item("ForwarderName1")
            Me.txtHBLCnee.Text = reader.Item("ConsigneeName1")
            Me.txtHBLNotify.Text = reader.Item("NotifyPartyName1")
            Me.txtWgtMeas.Text = reader.Item("GrossWeightKGMInteger") & "." & reader.Item("GrossWeightKGMFraction") & "/" & reader.Item("MeasurementInteger") & "." & reader.Item("MeasurementFraction")
            'Me.txtCgoDesc.Text = reader.Item("CargoLoad")
            Select Case reader.Item("Freight") & vbNullString
                Case "P"
                    Me.optPrepaid.Checked = True
                Case "C"
                    Me.optCollect.Checked = True
            End Select
            'Select Case reader.Item("CargoLoad") & vbNullString
            '    Case "LCL"
            '        Me.optLCL.Checked = True
            '    Case "FCL"
            '        Me.optFCL.Checked = True
            'End Select
            Me.optLCL.Checked = True

            Me.txtShprAddr.Text = reader.Item("ShipperName2") & " " & reader.Item("ShipperName3") & " " & reader.Item("ShipperName4") & " " & reader.Item("ShipperName5")
            Me.txtCneeAddr.Text = reader.Item("ConsigneeName2") & " " & reader.Item("ConsigneeName3") & " " & reader.Item("ConsigneeName4") & " " & reader.Item("ConsigneeName5")
            'Me.txtDesc.Text = reader.Item("Desc1") & " " & reader.Item("Desc2") & " " & reader.Item("Desc3") & " " & reader.Item("Desc4") & " " & reader.Item("Desc5")
            Me.txtDesc.Text = ""
        End While

        reader.Close()
        cmdSQL.Dispose()

        Me.chkAllowRelease.Checked = CheckIfAllowRelease(pHBL)
        PopAllowReleaseHistory(pHBL)
    End Sub

    Private Sub ClearAll()
        Dim obj As List(Of Object)

        'Clear MBL
        obj = (From x In gpMBL.Controls Where
              x.GetType Is GetType(TextBox) Select x).ToList

        For Each item As TextBox In obj
            item.Text = ""
        Next

        obj = (From x In gpMBL.Controls Where
              x.GetType Is GetType(RadioButton) Select x).ToList

        For Each item As RadioButton In obj
            item.Checked = False
        Next

        'Clear HBL
        Me.cboHBL.Items.Clear()
        Me.cboHBL.Text = ""
        ClearHBL()

        'CLEAR BILLING
        ClearBilling()

        'CLEAR ACCTG ENTRY
        ClearAcctgEntry()

        strEditReason = ""
    End Sub

    Private Sub ClearHBL()
        Me.txtHBLCnee.Text = ""
        Me.txtHBLCneeForwarder.Text = ""
        Me.txtHBLNotify.Text = ""
        Me.txtHBLShipper.Text = ""
    End Sub

    Private Sub ClearBilling()
        Me.dtgBilling.Rows.Clear()
        Me.tslblRefNo.Text = ""
        Me.txtVat.Text = ""
        'Me.txtSOA.Text = ""
        Me.txtInvTotal.Text = ""
        Me.txtGrandTotal.Text = ""
        Me.txtAmtInWords.Text = ""
        Me.cboSISNo.SelectedIndex = -1
        Me.cboSISNo.Text = ""
        Me.txtInvNo.Text = ""
        'Me.txtSOANo.Text = ""
        Me.txtORNo.Text = ""
        Me.txtRemarks.Text = ""
    End Sub

    Private Sub ClearAcctgEntry()
        Me.dtgAcctgTitle.Rows.Clear()
        Me.txtDRTotal.Text = ""
        Me.txtCRTotal.Text = ""
    End Sub

    'Private Function RetrieveTerms(ByVal strChrg As String) As String
    '    'OLD
    '    'Dim strSQL As String = "SELECT Terms FROM Charges WHERE Charges = '" & strChrg & "'"

    '    'RetrieveTerms = ""

    '    'If connImport.State <> ConnectionState.Open Then connImport.Open()

    '    'Dim cmdSQL = New OleDb.OleDbCommand(strSQL, connImport)

    '    'Dim reader As OleDb.OleDbDataReader = cmdSQL.ExecuteReader

    '    'While reader.Read
    '    '    If IsDBNull(reader.Item("Terms")) = False Then
    '    '        RetrieveTerms = reader.Item("Terms")
    '    '    End If
    '    'End While

    '    'reader.Close()
    '    'cmdSQL.Dispose()

    '    'NEW
    '    Dim strSQL As String = "SELECT Terms FROM lib_charges WHERE Billing = true and Charge_Description = '" & strChrg & "' and Service_Type='Import Forwarding' and length(Terms) is not null"

    '    RetrieveTerms = ""

    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

    '    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

    '    While reader.Read
    '        If IsDBNull(reader.Item("Terms")) = False Then
    '            RetrieveTerms = reader.Item("Terms")
    '        End If
    '    End While

    '    reader.Close()
    '    cmdSQL.Dispose()
    'End Function
    'Private Function RetrieveCHCode(ByVal strChrg As String) As String
    '    Dim strSQL As String = "SELECT Charge_Code FROM lib_charges WHERE Billing = true and Charge_Description = '" & strChrg & "' and Service_Type='Import Forwarding' and length(Terms) is not null"

    '    RetrieveCHCode = ""

    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

    '    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

    '    While reader.Read
    '        If IsDBNull(reader.Item("Charge_Code")) = False Then
    '            RetrieveCHCode = reader.Item("Charge_Code")
    '        End If
    '    End While

    '    reader.Close()
    '    cmdSQL.Dispose()
    'End Function
    Public Sub RetrieveBillingMain(ByVal strCol As String, ByVal strVal As String)
        Dim strSQL As String = "SELECT * FROM bill_impfinv_main WHERE " & strCol & " = '" & strVal & "' AND Cancel = FALSE"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        ClearBilling()

        While reader.Read
            If Not IsDBNull(reader.Item("SISNo")) Then
                'MsgBox("Not yet encoded!", MsgBoxStyle.Critical, "Not yet encoded...")
                'reader.Close()
                'cmdSQL.Dispose()
                'norec = 1
                'Exit Sub
                Me.cboSISNo.Text = reader.Item("SISNo")
            End If
            Me.txtBilledTo.Text = reader.Item("BilledTo")
            Me.tslblRefNo.Text = reader.Item("RefNo")
            Me.txtVat.Text = Format$(reader.Item("Vat"), "n2")
            Me.txtGrandTotal.Text = Format$(reader.Item("GrandTotal"), "n2")
            'Me.txtSOA.Text = Format$(reader.Item("SOAAmt"), "n2")
            Me.txtInvTotal.Text = Format$(reader.Item("InvAmt"), "n2")
            Me.txtInvNo.Text = reader.Item("InvoiceNum")
            ' Me.txtSOANo.Text = IIf(IsDBNull(reader.Item("SOANo")) = False, reader.Item("SOANo"), "")
            Me.txtRemarks.Text = reader.Item("Remarks")
            'Me.chkAllowRelease.Checked = reader.Item("AllowRelease")
            Me.sslblDateSaved.Text = "Date Saved : " & reader.Item("PrepDate") & " "
            DateSaved = reader.Item("PrepDate")
            Me.txtPrepDate.Text = reader.Item("PrepDate")
            Me.sslblPrepBy.Text = "Prepared By : " & reader.Item("PrepBy") & " "
            Me.txtPrepBy.Text = reader.Item("PrepBy")
            Me.txtExRate.Text = reader.Item("ExRate")
            If reader.Item("Posted") = True Then
                Me.sslblStatus.Text = "Status : "
                Me.sslblStatus1.Text = "Posted"
                Me.sslblStatus1.ForeColor = Color.Blue
                Me.sslblStatus2.Text = "Date Closed : " & reader.Item("DatePosted")
            Else
                Me.sslblStatus.Text = "Status : "
                Me.sslblStatus1.Text = "Open"
                Me.sslblStatus1.ForeColor = Color.Black
                Me.sslblStatus2.Text = ""
            End If
        End While

        reader.Close()
        cmdSQL.Dispose()

        PopUnpostHistory(Me.dgUnpostHistory, "IMPF", Me.tslblRefNo.Text)
        'RetrieveORNo(Me.tslblRefNo.Text)
        RetrieveBillingCharges()
        RetrieveAcctgEntry()
    End Sub

    Private Sub RetrieveBillingCharges()
        Dim strSQL As String = "SELECT * FROM bill_impfinv_charges WHERE RefNo = '" & Me.tslblRefNo.Text & "'"
        'Dim blVat As Boolean

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            Me.dtgBilling.Rows.Add(reader.Item("Charges"), reader.Item("Terms"), reader.Item("Qty"), reader.Item("Amount"), Format$(reader.Item("Total"), "n2"), CBool(reader.Item("WithVat")), reader.Item("Remarks"), reader.Item("CHCode"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub RetrieveAcctgEntry()
        ClearAcctgEntry()
        Dim strSQL As String = "SELECT * FROM bill_impfinv_acctg_entry WHERE RefNo = '" & Me.tslblRefNo.Text & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            Me.dtgAcctgTitle.Rows.Add(reader.Item("AcctCode"), reader.Item("AcctTitle"), reader.Item("SubAcctCode"), reader.Item("SubAcctTitle"), CBool(reader.Item("SubAcctDept")), reader.Item("SubAcctDeptName"), CBool(reader.Item("SubAcctList")), reader.Item("SubAcctListItem"), reader.Item("SubAcctListItemName"), Format$(reader.Item("DR"), "n2"), Format$(reader.Item("CR"), "n2"))
        End While

        reader.Close()
        cmdSQL.Dispose()

        ComputeDRCRTotal()
    End Sub

    Private Sub SaveEditingRecords()
        Dim strsql As String

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL As New MySqlCommand

        Dim dtCurrent As Date = GetServerDate()
        strsql = "INSERT INTO bill_editing_records (RefNo, TransactionType, UpdatedBy, DateUpdated, EditReason)" &
                    " VALUES (@RefNo, @TransactionType, @UpdatedBy, @DateUpdated, @EditReason)"

        cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@RefNo", Me.tslblRefNo.Text)
            .AddWithValue("@TransactionType", "Import Forwarding")
            .AddWithValue("@UpdatedBy", CurrentUser)
            .AddWithValue("@DateUpdated", dtCurrent)
            .AddWithValue("@EditReason", strEditReason)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
    End Sub

    Private Sub SaveBillingMain()
        Dim strsql As String

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        If Len(Me.tslblRefNo.Text) = 0 Then
            'NEW BILLING
            'Dim strRefNo As String = GetRefNo() & GetYear()
            Dim strRefNo As String = "BIFCI" & GetCtrlNbr(strCompanyCode, strSiteCode, "Billing_Import_Forwarding_Invoice")
            Me.tslblRefNo.Text = strRefNo
            Dim dtCurrent As Date = GetServerDate()
            strsql = "INSERT INTO bill_impfinv_main (RefNo, HouseBL, Client, BilledTo, PrepDate, PrepBy, Vat, GrandTotal,  InvAmt," &
                        " ExRate, InvoiceNum,  Remarks, Posted, Cancel, AllowRelease, SISNo)" &
                        " VALUES (@RefNo, @HouseBL, @Client,  @BilledTo, @PrepDate, @PrepBy, @Vat, @GrandTotal, @InvAmt," &
                        " @ExRate, @InvoiceNum, @Remarks, @Posted, @Cancel, @AllowRelease, @SISNo)"

            Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

            With cmdSQL.Parameters
                .AddWithValue("@RefNo", strRefNo)
                .AddWithValue("@HouseBL", Me.cboHBL.Text)
                .AddWithValue("@Client", Me.txtHBLCnee.Text)
                .AddWithValue("@BilledTo", Me.txtBilledTo.Text)
                .AddWithValue("@PrepDate", dtCurrent)
                .AddWithValue("@PrepBy", strCurrentUser)
                .AddWithValue("@Vat", CDbl(Me.txtVat.Text))
                .AddWithValue("@GrandTotal", CDbl(Me.txtGrandTotal.Text))
                .AddWithValue("@InvAmt", CDbl(Me.txtInvTotal.Text))
                .AddWithValue("@ExRate", CDbl(Me.txtExRate.Text))
                .AddWithValue("@InvoiceNum", Me.txtInvNo.Text)
                .AddWithValue("@Remarks", Me.txtRemarks.Text)
                .AddWithValue("@Posted", False)
                .AddWithValue("@Cancel", False)
                .AddWithValue("@AllowRelease", False)
                .AddWithValue("@SISNo", Me.cboSISNo.Text)
            End With
            DateSaved = dtCurrent
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "Billing_Import_Forwarding_Invoice")
        Else
            strsql = "UPDATE bill_impfinv_main SET" &
                        " Client=@Client," &
                        " BilledTo=@BilledTo," &
                        " Vat=@Vat," &
                        " Grandtotal=@GrandTotal," &
                        " InvAmt=@InvAmt," &
                        " InvoiceNum=@InvoiceNum," &
                        " Remarks=@Remarks," &
                        " SISNo=@SISNo" &
                     " WHERE" &
                        " RefNo = '" & Me.tslblRefNo.Text & "'" &
                     " AND" &
                        " Cancel = FALSE"

            Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

            With cmdSQL.Parameters
                .AddWithValue("@Client", Me.txtHBLCnee.Text)
                .AddWithValue("@BilledTo", Me.txtBilledTo.Text)
                .AddWithValue("@Vat", CDbl(Me.txtVat.Text))
                .AddWithValue("@GrandTotal", CDbl(Me.txtGrandTotal.Text))
                .AddWithValue("@InvAmt", CDbl(Me.txtInvTotal.Text))
                .AddWithValue("@InvoiceNum", Me.txtInvNo.Text)
                .AddWithValue("@Remarks", Me.txtRemarks.Text)
                .AddWithValue("@SISNo", Me.cboSISNo.Text)
            End With

            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()
        End If
    End Sub

    Private Sub SaveBillingCharges()
        Dim strsql As String, intRow As Integer, intDRow As Integer

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        strsql = "DELETE FROM bill_impfinv_charges WHERE RefNo = '" & Me.tslblRefNo.Text & "'"

        Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        cmdSQL.ExecuteNonQuery()

        intDRow = 0
        For intRow = 0 To Me.dtgBilling.RowCount - 1
            If Len(Me.dtgBilling.Rows(intRow).Cells(0).Value) > 0 Then
                strsql = "INSERT INTO bill_impfinv_charges (RefNo, RowNo, Charges, Terms, Qty, Amount, Total, WithVat, Remarks, CHCode)" &
                        " VALUES (@RefNo, @RowNo, @Charges, @Terms, @Qty, @Amount, @Total, @WithVat, @Remarks, @CHCode)"

                cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@RefNo", Me.tslblRefNo.Text)
                    .AddWithValue("@RowNo", intDRow)
                    .AddWithValue("@Charges", Me.dtgBilling.Rows(intRow).Cells(0).Value)
                    .AddWithValue("@Terms", Me.dtgBilling.Rows(intRow).Cells(1).Value)
                    .AddWithValue("@Qty", CDbl(Me.dtgBilling.Rows(intRow).Cells(2).Value))
                    .AddWithValue("@Amount", CDbl(Me.dtgBilling.Rows(intRow).Cells(3).Value))
                    .AddWithValue("@Total", CDbl(Me.dtgBilling.Rows(intRow).Cells(4).Value))
                    .AddWithValue("@WithVat", CBool(Me.dtgBilling.Rows(intRow).Cells(5).Value))
                    .AddWithValue("@Remarks", Me.dtgBilling.Rows(intRow).Cells(6).Value)
                    .AddWithValue("@CHCode", Me.dtgBilling.Rows(intRow).Cells(7).Value)
                End With

                cmdSQL.ExecuteNonQuery()
                intDRow = intDRow + 1
            End If
        Next

        cmdSQL.Dispose()
    End Sub

    Private Sub SaveAcctgEntry()
        Dim strsql As String = "DELETE FROM bill_impfinv_acctg_entry WHERE RefNo = '" & tslblRefNo.Text & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

        cmdsql.ExecuteNonQuery()

        Dim ctrRow As Integer

        For ctrRow = 0 To Me.dtgAcctgTitle.Rows.Count - 1
            With Me.dtgAcctgTitle.Rows(ctrRow)
                strsql = "INSERT INTO bill_impfinv_acctg_entry (RefNo, Branch, AcctCode, AcctTitle, SubAcctCode," &
                            " SubAcctTitle, SubAcctDept, SubAcctDeptName," &
                            " SubAcctList, SubAcctListItem, SubAcctListItemName, DR, CR)" &
                            " VALUES ('" & Me.tslblRefNo.Text & "', '" & Mid$(Me.tslblRefNo.Text, 4, 3) & "', '" & .Cells(0).Value & "', '" & .Cells(1).Value & "'," &
                            " '" & .Cells(2).Value & "', '" & .Cells(3).Value & "', " & .Cells(4).Value & ", '" & .Cells(5).Value & "'," &
                            " " & .Cells(6).Value & ", '" & .Cells(7).Value & "', '" & Replace(.Cells(8).Value, "'", "") & "'," &
                            " " & CDbl(.Cells(9).Value) & ", " & CDbl(.Cells(10).Value) & ")"

                cmdsql = New MySqlCommand(strsql, cnnDBMaster)

                cmdsql.ExecuteNonQuery()
            End With
        Next

        cmdsql.Dispose()
    End Sub

    Private Function GetSubAcctTitle(ByVal strAcctCode As String, ByVal strSubAcctCode As String, ByVal strCol As String) As String
        GetSubAcctTitle = ""
        Dim strsql As String = "SELECT * FROM lib_subacctcode WHERE Account_Code = '" & strAcctCode & "' AND SubAccount_Code = '" & strSubAcctCode & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySqlDataReader = cmdsql.ExecuteReader

        While reader.Read
            GetSubAcctTitle = reader.Item(strCol)
        End While

        reader.Close()
        cmdsql.Dispose()
    End Function

    'Private Function GetRefNo() As String
    '    Dim strsql As String = "SELECT crp_Counter, BranchCode FROM ap_sysparams WHERE CompanyID = 'AIS_BIF' AND BranchCode = '" & BranchCode & "'"
    '    GetRefNo = ""

    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

    '    Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

    '    Dim reader As MySqlDataReader = cmdsql.ExecuteReader

    '    While reader.Read
    '        GetRefNo = "BIF" & reader.Item("BranchCode") & CStr(Format$(CDbl(reader.Item("crp_Counter")), "0000000"))
    '    End While

    '    reader.Close()
    '    cmdsql.Dispose()
    'End Function

    'Private Sub UpdateCtr()
    '    Dim strsql As String = "UPDATE ap_sysparams SET crp_Counter = crp_Counter + 1 WHERE CompanyID = 'AIS_BIF' AND BranchCode = '" & BranchCode & "'"

    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

    '    Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

    '    cmdsql.ExecuteNonQuery()
    '    cmdsql.Dispose()
    'End Sub

    Private Sub ComputeTotal()
        Dim intRow As Integer
        With Me.dtgBilling
            'COMPUTE TOTALS PER ROW
            For intRow = 0 To .RowCount - 1
                If Len(Trim$(.Rows(intRow).Cells(0).Value)) > 0 Then
                    If IsNumeric(.Rows(intRow).Cells(2).Value) = True And IsNumeric(.Rows(intRow).Cells(3).Value) = True Then
                        .Rows(intRow).Cells(4).Value = Format$(CDbl(.Rows(intRow).Cells(2).Value) * CDbl(.Rows(intRow).Cells(3).Value), "n2")
                    End If
                End If
            Next

            'COMPUTE VAT
            Dim dblTemp As Double = 0
            For intRow = 0 To .RowCount - 1
                If Len(Trim$(.Rows(intRow).Cells(0).Value)) > 0 Then
                    If .Rows(intRow).Cells(5).Value = True Then
                        dblTemp = dblTemp + CDbl(.Rows(intRow).Cells(4).Value)
                    End If
                End If
            Next

            Me.txtVat.Text = Format$(dblTemp * 0.12, "n2")

            'COMPUTE GRAND TOTAL
            dblTemp = 0
            For intRow = 0 To .RowCount - 1
                If Len(Trim$(.Rows(intRow).Cells(0).Value)) > 0 Then
                    dblTemp = dblTemp + CDbl(.Rows(intRow).Cells(4).Value)
                End If
            Next

            Me.txtGrandTotal.Text = Format$(CDbl(Me.txtVat.Text) + dblTemp, "n2")

            ''COMPUTE SOA AMOUNT
            'dblTemp = 0
            'For intRow = 0 To .RowCount - 1
            '    If Len(Trim$(.Rows(intRow).Cells(0).Value)) > 0 Then
            '        If .Rows(intRow).Cells(1).Value = "S.O.A." Then
            '            dblTemp = dblTemp + CDbl(.Rows(intRow).Cells(4).Value)
            '        End If
            '    End If
            'Next

            'Me.txtSOA.Text = Format$(dblTemp, "n2")

            'COMPUTE INVOICE AMOUNT
            dblTemp = 0
            For intRow = 0 To .RowCount - 1
                If Len(Trim$(.Rows(intRow).Cells(0).Value)) > 0 Then
                    If .Rows(intRow).Cells(1).Value = "Charge Invoice" Then
                        dblTemp = dblTemp + CDbl(.Rows(intRow).Cells(4).Value)
                    End If
                End If
            Next

            Me.txtInvTotal.Text = Format$(dblTemp, "n2")
        End With
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

    Private Sub PopdtgAcctgTitle()
        Me.dtgAcctgTitle.Rows.Clear()
        'If Len(Me.txtSOA.Text) > 0 Then
        '    If CDbl(Me.txtSOA.Text) > 0 Then
        '        PopdtgAcctgTitleRows("1150", 1, (Me.txtSOA.Text), 0)
        '        PopdtgAcctgTitleRows("2020", 1, 0, CDbl(Me.txtSOA.Text))
        '    End If
        'End If

        If Len(Me.txtInvTotal.Text) > 0 Then
            If CDbl(Me.txtInvTotal.Text) > 0 Then
                PopdtgAcctgTitleRows("1110", "1", (CDbl(Me.txtInvTotal.Text) + CDbl(Me.txtVat.Text)), 0)
                PopdtgAcctgTitleRows("4110", "3", 0, CDbl(Me.txtInvTotal.Text))
                If CDbl(Me.txtVat.Text) > 0 Then
                    PopdtgAcctgTitleRows("2230", "3", 0, CDbl(Me.txtVat.Text))
                End If
            End If
        End If

        'COMPUTE DR/CR TOTAL
        ComputeDRCRTotal()
    End Sub

    Public Sub PopdtgAcctgTitleRows(ByVal strCode As String, ByVal strSubCode As String, ByVal dblDR As Double, ByVal dblCR As Double)
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
                    strShip = Me.txtHBLCnee.Text
                ElseIf strList = "Local and Government Agency" Then
                    strShip = "Bureau of Internal Revenue"
                End If
            End If

            Me.dtgAcctgTitle.Rows.Add(reader.Item("Account_Code"), reader.Item("Account_Title"), reader.Item("SubAccount_Code"), reader.Item("SubAccount_Title"), CBool(reader.Item("SubAccount_Dept")), strDept, CBool(reader.Item("SubAccount_List")), strList, strShip, Format$(CDbl(dblDR), "n2"), Format$(CDbl(dblCR), "n2"), strSubCode)
        End While

        reader.Close()
        cmdsql.Dispose()
    End Sub

    Private Function CheckRequiredEntries() As Boolean
        Dim intRow As Integer

        If Me.cboHBL.SelectedIndex = -1 Then
            MsgBox("Select HBL Number!", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            Exit Function
        End If


        'If Me.txtBilledTo.SelectedIndex = -1 Then
        '    MsgBox("Select Billed To!", MsgBoxStyle.Exclamation, "System Message")
        '    CheckRequiredEntries = False
        '    Exit Function
        'End If

        With Me.dtgBilling
            For intRow = 0 To .Rows.Count - 1
                If Len(.Rows(intRow).Cells(0).Value) = 0 Then
                    If MsgBox("Rows with no charge description will be disregarded. Continue saving?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
                        CheckRequiredEntries = True
                        Exit Function
                    Else
                        CheckRequiredEntries = False
                        Exit Function
                    End If
                End If
            Next
        End With

        If MsgBox("Save Billing?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Save?") = MsgBoxResult.No Then
            CheckRequiredEntries = False
            Exit Function
        End If

        CheckRequiredEntries = True
    End Function

    'Private Sub RetrieveORNo(ByVal strval As String)
    '    Dim strsql As String = "SELECT * FROM or_impf_ornumbers WHERE RefNo = '" & strval & "'"

    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

    '    Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

    '    Dim reader As MySqlDataReader = cmdsql.ExecuteReader

    '    While reader.Read
    '        If Len(Me.txtORNo.Text) = 0 Then
    '            Me.txtORNo.Text = reader.Item("ORNo")
    '        Else
    '            Me.txtORNo.Text = Me.txtORNo.Text & ", " & reader.Item("ORNo")
    '        End If
    '    End While

    '    reader.Close()
    '    cmdsql.Dispose()
    'End Sub

    Private Sub GridRestriction()
        Dim intRow As Integer

        For intRow = 0 To Me.dtgBilling.Rows.Count - 1
            With Me.dtgBilling.Rows(intRow)
                If Len(.Cells(0).Value) = 0 Then
                    .Cells(2).ReadOnly = True
                    .Cells(3).ReadOnly = True
                    .Cells(5).ReadOnly = True
                Else
                    .Cells(2).ReadOnly = False
                    .Cells(3).ReadOnly = False
                    .Cells(5).ReadOnly = False
                End If

                'If dtgBilling.Columns(dtgBilling.CurrentCell.ColumnIndex).Name = colCharges.Name Then
                .Cells(1).Value = "Charge Invoice"
                .Cells(7).Value = GetStringValue("Select ChargeCode From lib_charges where ChargeName = '" & .Cells(0).Value & "'", "ChargeCode")
                'End If

                If .Cells(1).Value <> "Charge Invoice" Then
                    .Cells(5).Value = False
                    .Cells(5).ReadOnly = True
                End If

                If IsNumeric(.Cells(2).Value) = False Then
                    .Cells(2).Value = "0"
                End If

                If IsNumeric(.Cells(3).Value) = True Then
                    .Cells(3).Value = Math.Round(CDbl(.Cells(3).Value), 4)
                Else
                    .Cells(3).Value = "0"
                End If
            End With
        Next
    End Sub

    Private Sub frmInvoiceImpF_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If connImport.State = ConnectionState.Open Then connImport.Close()
        If cnnDBMaster.State = ConnectionState.Open Then cnnDBMaster.Close()
        'If connSales.State = ConnectionState.Open Then connSales.Close()
        Me.Tag = ""
        Me.Dispose()
    End Sub

    Public Sub PopUnpostHistory(ByVal dg As DataGridView, ByVal strTag As String, ByVal strRefNo As String)
        dg.Rows.Clear()
        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM bill_unpost_history " &
                 "WHERE Tag = '" & strTag & "' and RefNo = '" & strRefNo & "' " &
                 "ORDER BY UnpostDate"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        Dim i As Integer
        Dim gridBook As DataGridView

        While reader.Read
            gridBook = dg

            gridBook.Rows.Add(reader.Item("Tag"), reader.Item("RefNo"), reader.Item("Remarks"), reader.Item("RequestedBy"), reader.Item("UnpostDate"))

            i = i + 1
        End While

        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub

    'Private Sub PopComboSQL(ByVal cbo As ComboBox, ByVal strsql As String, ByVal strField As String)

    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

    '    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

    '    cbo.Items.Clear()

    '    While reader.Read
    '        cbo.Items.Add(reader.Item(strField))
    '    End While

    '    reader.Close()
    '    cmdSQL.Dispose()
    'End Sub


    Private Sub dtArrivalDate_ValueChanged(sender As Object, e As EventArgs) Handles dtArrivalDate.ValueChanged
        ClearAll()
        FillComboBox(Me.cboMBL, "SELECT MBLNo FROM v_frwdg_docs_mbl WHERE ArrivalDate = '" & Format$(dtArrivalDate.Value, "yyyy-MM-dd") & "'", "MBLNo")
    End Sub

    Private Sub cboMBL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMBL.SelectedIndexChanged
        RetrieveMBL(Me.cboMBL.Text)
        PopcboHBL(Me.cboMBL.Text)
    End Sub

    Private Sub dtgBilling_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBilling.CellContentClick

    End Sub

    Private Sub dtgBilling_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBilling.CellEndEdit
        GridRestriction()

        ComputeTotal()
        PopdtgAcctgTitle()
    End Sub

    Private Sub cboHBL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboHBL.SelectedIndexChanged
        RetrieveHBL(Me.cboHBL.Text)
        RetrieveBillingMain("HouseBL", Me.cboHBL.Text)

        If Len(Me.cboHBL.Text) > 0 Then
            Me.tsBilling.Enabled = True

            If Len(tslblRefNo.Text) = 0 Then
                EnableBillingButtons(True, False, False, True, False, False, False, False)
                Me.tscmdSearchBill.Enabled = False
            Else
                EnableBillingButtons(True, True, False, True, True, True, True, False)
                Me.tscmdSearchBill.Enabled = True
            End If
        End If
    End Sub

    Public Sub EnableBillingButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean, ByVal blPost As Boolean, ByVal blCancel As Boolean, ByVal blAllowRel As Boolean, ByVal blcontBilling As Boolean)
        Me.tscmdNew.Enabled = blNew
        Me.tscmdEdit.Enabled = blEdit
        Me.tscmdSave.Enabled = blSave
        Me.tscmdResetBilling.Enabled = blReset
        Me.tscmdPost.Enabled = blPost
        Me.tscmdCancel.Enabled = blCancel
        'Me.tscmdAllowRelease.Enabled = blAllowRel

        'Set  ContBilling
        Dim obj As List(Of Object)

        obj = (From x In contBilling.Controls Where
              x.GetType Is GetType(Button) Select x).ToList

        For Each item As Button In obj
            item.Enabled = blcontBilling
        Next

        Me.dtgBilling.ReadOnly = Not blcontBilling
        Me.cboSISNo.Enabled = blcontBilling
        Me.txtRemarks.ReadOnly = Not blcontBilling

        Me.colTerms.ReadOnly = True
        Me.colTotal.ReadOnly = True
    End Sub

    Private Sub tscmdNew_Click(sender As Object, e As EventArgs) Handles tscmdNew.Click
        If Me.cboHBL.SelectedIndex = -1 Then
            MsgBox("Select HBL Number!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        ClearBilling()
        EnableBillingButtons(False, False, True, True, False, False, False, True)
        Me.txtExRate.Text = Format$(GetExRate("Dollars"), "n2")
        GridRestriction()
    End Sub

    Private Sub txtGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles txtGrandTotal.TextChanged
        If IsNumeric(Me.txtGrandTotal.Text) = True Then
            Me.txtAmtInWords.Text = English(CDec(Me.txtGrandTotal.Text), "Pesos")
        End If
    End Sub

    Private Sub tscmdSave_Click(sender As Object, e As EventArgs) Handles tscmdSave.Click
        Me.dtgBilling.EndEdit()
        PopdtgAcctgTitle()
        ComputeTotal()

        If CheckRequiredEntries() = False Then
            Exit Sub
        End If

        SaveBillingMain()
        SaveBillingCharges()
        SaveAcctgEntry()
        SaveEditingRecords()
        RetrieveBillingMain("RefNo", Me.tslblRefNo.Text)
        Me.chkAllowRelease.Checked = CheckIfAllowRelease(Me.cboHBL.Text)

        MsgBox("Billing Saved!" & vbNewLine & "Reference No. :  " & Me.tslblRefNo.Text, MsgBoxStyle.Information, "Save")

        EnableBillingButtons(False, True, False, True, True, True, True, False)
    End Sub

    Private Sub tscmdEdit_Click(sender As Object, e As EventArgs) Handles tscmdEdit.Click
        If Me.sslblStatus1.Text <> "Open" Then
            'MsgBox("Billing Already " & Me.sslblStatus1.Text, MsgBoxStyle.Exclamation, "System Message")
            'Exit Sub
        End If

        If Me.cboHBL.SelectedIndex = -1 Then
            MsgBox("Select HBL Number!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        strEditReason = InputBox("Enter Reason For Editing : ", "Reason")

        If Len(Trim$(strEditReason)) = 0 Then
            Exit Sub
        End If

        EnableBillingButtons(False, False, True, True, False, False, False, True)
        GridRestriction()
    End Sub

    Private Sub tscmdResetBilling_Click(sender As Object, e As EventArgs) Handles tscmdResetBilling.Click
        ClearBilling()
        ClearAcctgEntry()

        RetrieveBillingMain("HouseBL", cboHBL.Text)

        If Len(Me.tslblRefNo.Text) = 0 Then
            If Len(Me.cboHBL.Text) = 0 Then
                EnableBillingButtons(False, False, False, True, False, False, False, False)
            Else
                EnableBillingButtons(True, False, False, True, False, False, False, False)
            End If
        Else
            EnableBillingButtons(False, True, False, True, True, True, True, False)
        End If
    End Sub

    Private Sub dtgBilling_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dtgBilling.EditingControlShowing
        Dim tb As TextBox
        If Me.dtgBilling.CurrentCell.ColumnIndex = 2 Or Me.dtgBilling.CurrentCell.ColumnIndex = 3 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Me.dtgBilling.CurrentCell.ColumnIndex = 2 Or Me.dtgBilling.CurrentCell.ColumnIndex = 3 Then
            SetCharacter(MyOption.Numeric, e)
        End If
    End Sub

    'Private Sub tscmdAllowRelease_Click(sender As Object, e As EventArgs) Handles tscmdAllowRelease.Click
    '    If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_ImpF_AllowRelease") = False Then
    '        MsgBox("You Are Not Allowed To Allow Release", MsgBoxStyle.Exclamation, "System Message")
    '        Exit Sub
    '    End If

    '    If Me.chkAllowRelease.Checked <> True Then
    '        frmAllowRelease.Tag = "Allow"
    '        frmAllowRelease.ShowDialog()
    '    Else
    '        frmAllowRelease.Tag = "Disallow"
    '        frmAllowRelease.ShowDialog()
    '    End If
    'End Sub

    Private Sub tscmdCancel_Click(sender As Object, e As EventArgs) Handles tscmdCancel.Click
        Dim strsql As String
        Dim dtCurrent As Date = GetServerDate()

        If Me.sslblStatus1.Text <> "Open" Then
            MsgBox("Billing Already " & Me.sslblStatus1.Text, MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        'If CheckSL("bill_impf_main", Me.tslblRefNo.Text) = True Then
        '    MsgBox("Billing already included to Subsidiary Ledger!", MsgBoxStyle.Exclamation, "Sytem Message")
        '    Exit Sub
        'End If

        If MsgBox("Are you sure you want cancel billing : " & Me.tslblRefNo.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If
        strsql = "UPDATE bill_impfinv_main SET Cancel=TRUE, DateCancel=@DateCancel, CancelBy= '" & strCurrentUser & "' WHERE RefNo = '" & Me.tslblRefNo.Text & "' AND Cancel = FALSE"

        Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@DateCancel", dtCurrent)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
        RetrieveBillingMain("RefNo", Me.tslblRefNo.Text)
        MsgBox("Billing " & Me.tslblRefNo.Text & " Cancelled!", MsgBoxStyle.Information, "Cancelled")
    End Sub

    Private Sub tscmdReset_Click(sender As Object, e As EventArgs) Handles tscmdReset.Click
        Me.cboMBL.SelectedIndex = -1
        Me.cboMBL.Text = ""
        Me.dtArrivalDate.Value = GetServerDate()
        ClearAll()
    End Sub

    Private Sub tscmdSearch_Click(sender As Object, e As EventArgs) Handles tscmdSearch.Click
        Me.cboMBL.SelectedIndex = -1
        Me.cboMBL.Text = ""
        ClearAll()
        frmSearchBilling.Tag = "IMPFCI"
        frmSearchBilling.ShowDialog()
        GridRestriction()
    End Sub

    Private Sub tscmdClose_Click(sender As Object, e As EventArgs) Handles tscmdClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub tscmdSearchBill_Click(sender As Object, e As EventArgs) Handles tscmdSearchBill.Click
        frmSearchBillingPerHBL.ShowDialog()
    End Sub

    Private Sub BillingSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillingSummaryToolStripMenuItem.Click
        With frmBillingSummaryReports
            .Text = "Import Forwarding Billing Summary"
            .Tag = "ImpFSummary"
            .ShowDialog()
        End With
    End Sub

    Private Sub TallySheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TallySheetToolStripMenuItem.Click
        'With frmBillingReport
        '    .Text = "Import Forwarding Tally Sheet"
        '    .Tag = "ImpFTallySheet"
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub tscmdPost_Click(sender As Object, e As EventArgs) Handles tscmdPost.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_ImpFBillPost") = False Then
        '    MsgBox("You are not allowed to Post Import Forwarding Billing!", MsgBoxStyle.Exclamation, "System Message")
        '    Exit Sub
        'End If

        If Len(Me.tslblRefNo.Text) = 0 Then
            MsgBox("Nothing to Post!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If Me.sslblStatus1.Text <> "Open" Then
            MsgBox("Billing Already " & Me.sslblStatus1.Text, MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        Dim strCI As String
        Dim strSOA As String = ""

        If MsgBox("Please make sure that all entries are correct before Posting!" & vbNewLine & "Post this reference no. " & Me.tslblRefNo.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If

        If CInt(Me.txtInvTotal.Text) > 0 Then
            strCI = GetRegisteredFormNo(1, 3)
            If strCI = -1 Then
                MsgBox("No released invoice form yet.", MsgBoxStyle.Information)
                Exit Sub
            End If
        Else
            strCI = ""
        End If

        'If CInt(Me.txtSOA.Text) > 0 Then
        '    strSOA = GetRegisteredFormNo(2, 3)
        '    If strSOA = -1 Then
        '        MsgBox("No released S.O.A. form yet.", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If
        'Else
        '    strSOA = ""
        'End If

        Dim dtcurrent As Date = GetServerDate()
        Dim dtSLDate As Date = Format$(CDate(Me.txtPrepDate.Text), "yyyy-MM-dd hh:mm:ss")

        If dtcurrent.Day > 15 Then
            While dtSLDate < dtcurrent.AddMonths(-3)
                dtSLDate = Format$(CDate(dtSLDate).AddMonths(1), "yyyy-MM-01 00:00:00")
            End While
        Else
            While dtSLDate < dtcurrent.AddMonths(-2)
                dtSLDate = Format$(CDate(dtSLDate).AddMonths(1), "yyyy-MM-01 00:00:00")
            End While
        End If
        'MsgBox(Format$(CDate(dtSLDate), "yyyy-MM-dd hh:mm:ss"))

        Dim strsql As String = "UPDATE bill_impfinv_main SET" &
                                " InvoiceNum = @InvoiceNum, " &
                                " Posted = @Posted, " &
                                " PostedBy = @PostedBy, " &
                                " DatePosted = @PostedDate " &
                                " WHERE RefNo = '" & Me.tslblRefNo.Text & "' AND Cancel = FALSE"

        'asd
        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL

            cmdSQL.CommandText = strsql

            With cmdSQL.Parameters
                .AddWithValue("@InvoiceNum", strCI)
                .AddWithValue("@Posted", True)
                .AddWithValue("@PostedBy", strCurrentUser)
                .AddWithValue("@PostedDate", dtcurrent)
            End With

            cmdSQL.ExecuteNonQuery()

            cmdSQL.CommandText = "UPDATE reg_trn_main SET " &
                                    "reg_status = 4, " &
                                    "reg_statusby = @reg_statusby, " &
                                    "reg_statusdate = @reg_statusdate, " &
                                    "related_ref = @related_ref " &
                                "WHERE reg_group = 1 AND reg_module = 3 " &
                                    "AND reg_no = @reg_no"

            cmdSQL.Parameters.Clear()
            With cmdSQL.Parameters
                .AddWithValue("@reg_statusby", strCurrentUser)
                .AddWithValue("@reg_statusdate", dtcurrent)
                .AddWithValue("@related_ref", Me.tslblRefNo.Text)
                .AddWithValue("@reg_no", strCI)
            End With

            cmdSQL.ExecuteNonQuery()

            'cmdSQL.CommandText = "UPDATE reg_trn_main SET " &
            '                        "reg_status = 4, " &
            '                        "reg_statusby = @reg_statusby, " &
            '                        "reg_statusdate = @reg_statusdate, " &
            '                        "related_ref = @related_ref " &
            '                    "WHERE reg_group = 2 AND reg_module = 3 " &
            '                        "AND reg_no = @reg_no"

            'cmdSQL.Parameters.Clear()
            'With cmdSQL.Parameters
            '    .AddWithValue("@reg_statusby", CurrentUser)
            '    .AddWithValue("@reg_statusdate", dtcurrent)
            '    .AddWithValue("@related_ref", Me.tslblRefNo.Text)
            '    .AddWithValue("@reg_no", strSOA)
            'End With

            'cmdSQL.ExecuteNonQuery()

            trnSQL.Commit()
            cmdSQL.Dispose()

            MsgBox("Billing Reference No. " & Me.tslblRefNo.Text & " is Posted!" & vbNewLine &
                    "C.I.#: " & strCI, vbInformation, "System Message")
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

        RetrieveBillingMain("RefNo", Me.tslblRefNo.Text)
    End Sub

    Private Sub tscmdPostBatch_Click(sender As Object, e As EventArgs) Handles tscmdPostBatch.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_ImpFBillPost") = False Then
        '    MsgBox("You are not allowed to Post Import Forwarding Billing!", MsgBoxStyle.Exclamation, "System Message")
        '    Exit Sub
        'End If

        frmUnposted.Tag = "Import Forwarding Billing"
        frmUnposted.ShowDialog()
    End Sub

    Private Sub UnbilledToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnbilledToolStripMenuItem.Click
        With frmUnbilledSummary
            .Text = "Unbilled Import Forwarding Transactions"
            '.lblTitle.Text = "Unbilled Import Forwarding Transactions"
            .Tag = "ImpF"
            .ShowDialog()
        End With
    End Sub

    Private Sub chkAllowRelease_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllowRelease.CheckedChanged
        Me.chkAllowReleaseInfo.Checked = Me.chkAllowRelease.Checked
    End Sub

    Private Sub chkAllowRelease_Click(sender As Object, e As EventArgs) Handles chkAllowRelease.Click
        Me.chkAllowRelease.Checked = CheckIfAllowRelease(Me.cboHBL.Text)
    End Sub

    Public Sub PopulateOR(ByVal str As String)
        Me.dtgOR.Rows.Clear()
        Dim strSQL2 As String
        strSQL2 = "SELECT * " &
                 "FROM or_invoice INNER JOIN or_main ON or_invoice.ORNo = or_main.ORNo " &
                 "WHERE or_invoice.RefNo = '" & str & "' and or_main.Cancel = false"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL2, cnnDBMaster)
        Dim reader2 As MySqlDataReader = cmd.ExecuteReader()

        Dim x As Integer
        Dim gridBook2 As DataGridView

        While reader2.Read
            gridBook2 = Me.dtgOR
            gridBook2.Rows.Add(reader2.Item("RefNo"), reader2.Item("ORNo"), reader2.Item("CheckAmt"), IIf(IsDBNull(reader2.Item("CheckNo")) = False, reader2.Item("CheckNo"), ""), reader2.Item("CashAmt"), reader2.Item("CWT"))
            x = x + 1
        End While
        cmd.Dispose()
        reader2.Close()
    End Sub
    Public Sub PopulateAR(ByVal str As String)
        Me.dtgAR.Rows.Clear()

        Dim strSQL2 As String
        strSQL2 = "SELECT * " &
                 "FROM ar_invoice INNER JOIN ar_main ON ar_invoice.ORNo = ar_main.ORNo " &
                 "WHERE ar_invoice.RefNo = '" & str & "' and ar_main.Cancel = false"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL2, cnnDBMaster)
        Dim reader2 As MySqlDataReader = cmd.ExecuteReader()

        Dim x As Integer
        Dim gridBook2 As DataGridView

        While reader2.Read
            gridBook2 = Me.dtgAR
            gridBook2.Rows.Add(reader2.Item("RefNo"), reader2.Item("ORNo"), reader2.Item("CheckAmt"), IIf(IsDBNull(reader2.Item("CheckNo")) = False, reader2.Item("CheckNo"), ""), reader2.Item("CashAmt"))
            x = x + 1
        End While
        cmd.Dispose()
        reader2.Close()
    End Sub

    Private Sub AgingOfReceivablesIMPFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgingOfReceivablesIMPFToolStripMenuItem.Click
        'frmBillingReceivablesExport.Tag = "IMPF"
        'frmBillingReceivablesExport.Text = "Aging of Receivables Summary - [IMPF]"
        'frmBillingReceivablesExport.ShowDialog()
    End Sub

    Private Sub tscmdUnpost_Click(sender As Object, e As EventArgs) Handles tscmdUnpost.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_Bill_Unpost") = False Then
        '    MsgBox("You are not allowed to unpost Billing!", vbCritical, "System Message")
        '    Exit Sub
        'End If

        If Me.sslblStatus1.Text <> "Posted" Then
            MsgBox("Billing is not yet Posted!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        frmBillingUnpost.Tag = "IMPF"
        frmBillingUnpost.txtRefNo.Text = Me.tslblRefNo.Text
        frmBillingUnpost.ShowDialog()
    End Sub

    Private Sub PHPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPToolStripMenuItem.Click
        If Me.sslblStatus1.Text <> "Posted" Then
            MsgBox("Cannot Print Charge Invoice or S.O.A. if Billing is not yet Posted!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        PrintCurrency = "PHP"
        'frmBillingReport.Text = "Import Forwarding Invoice"
        'frmBillingReport.Tag = "ImpFCI"
        'frmBillingReport.ShowDialog()
        frmPrintPreview.PrintImpFCI()
        frmPrintPreview.ShowDialog()
    End Sub

    Private Sub USDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles USDToolStripMenuItem.Click
        If Me.sslblStatus1.Text <> "Posted" Then
            MsgBox("Cannot Print Charge Invoice or S.O.A. if Billing is not yet Posted!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        PrintCurrency = "USD"
        frmPrintPreview.PrintImpFCI()
        frmPrintPreview.ShowDialog()
    End Sub

    Private Sub PHPToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PHPToolStripMenuItem2.Click
        If Me.sslblStatus1.Text <> "Open" Then
            MsgBox("Billing Already " & Me.sslblStatus1.Text, MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If
        PrintCurrency = "PHP"
        frmPrintPreview.PrintIMPFCI_D()
        frmPrintPreview.ShowDialog()
    End Sub

    Private Sub USDToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles USDToolStripMenuItem2.Click
        If Me.sslblStatus1.Text <> "Open" Then
            MsgBox("Billing Already " & Me.sslblStatus1.Text, MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If
        PrintCurrency = "USD"
        frmPrintPreview.PrintIMPFCI_D()
        frmPrintPreview.ShowDialog()
    End Sub

    Private Sub PHPToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles PHPToolStripMenuItem1.Click
        If Me.sslblStatus1.Text <> "Posted" Then
            MsgBox("Cannot Print Charge Invoice or S.O.A. if Billing is not yet Posted!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        PrintCurrency = "PHP"
        frmPrintPreview.PrintImpFCI_S()
        frmPrintPreview.ShowDialog()
    End Sub

    Private Sub UUSDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UUSDToolStripMenuItem.Click
        If Me.sslblStatus1.Text <> "Posted" Then
            MsgBox("Cannot Print Charge Invoice or S.O.A. if Billing is not yet Posted!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        PrintCurrency = "USD"
        frmPrintPreview.PrintImpFCI_S()
        frmPrintPreview.ShowDialog()
    End Sub
End Class