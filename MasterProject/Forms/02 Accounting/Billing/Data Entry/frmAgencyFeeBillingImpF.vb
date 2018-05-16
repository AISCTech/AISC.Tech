Imports MySql.Data.MySqlClient
Public Class frmAgencyFeeBillingImpF

    Dim strEditReason As String = ""

    Private Sub frmAgencyFeeBillingImpF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.Tag <> "Aging" Then
            Me.dtArrivalDate.Value = GetServerDate()
        End If
        FillComboBox(Me.cboMBL, "SELECT MBLNo FROM v_frwdg_docs_mbl WHERE ArrivalDate = '" & Format$(dtArrivalDate.Value, "yyyy-MM-dd") & "'", "MBLNo")
        FillGridComboBox(Me.colCharges, "Select ChargeName from lib_charges where ChargeName is not null", "ChargeName")
        FillGridComboBox(Me.colDCCharges, "Select ChargeName from lib_charges where ChargeName is not null", "ChargeName")
    End Sub

    Private Sub cboMBL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMBL.SelectedIndexChanged
        RetrieveMBL(Me.cboMBL.Text)
        PopcboHBL(Me.cboMBL.Text)
    End Sub
    Public Sub RetrieveMBL(ByVal pMBL As String)
        ClearAll()
        pMBL = pMBL.Replace("'", "''")
        Dim strSQL As String = "SELECT * " &
             "FROM v_frwdg_docs_mbl " &
             "WHERE MBLNo = '" & pMBL & "'"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

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

    Private Sub RetrieveAcctgEntry()
        'ClearAcctgEntry()
        Dim strSQL As String = "SELECT * FROM bill_impfsoa_acctg_entry WHERE RefNo = '" & Me.txtIMPDCRefNo.Text & "'"

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

    Public Sub RetrieveIMPFBillingMain(ByVal strCol As String, ByVal strVal As String)
        Dim strSQL As String = "SELECT * FROM bill_impfinv_main WHERE " & strCol & " = '" & strVal & "' AND Cancel = FALSE"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        ClearIMPFBilling()

        While reader.Read
            'If Not IsDBNull(reader.Item("SISNo")) Then
            '    'MsgBox("Not yet encoded!", MsgBoxStyle.Critical, "Not yet encoded...")
            '    'reader.Close()
            '    'cmdSQL.Dispose()
            '    'norec = 1
            '    'Exit Sub
            '    Me.cboSISNo.Text = reader.Item("SISNo")
            'End If

            Me.txtIMPFBillRefNo.Text = reader.Item("RefNo")
            Me.txtVat.Text = Format$(reader.Item("Vat"), "n2")
            Me.txtGrandTotal.Text = Format$(reader.Item("GrandTotal"), "n2")
            'Me.txtSOA.Text = Format$(reader.Item("SOAAmt"), "n2")
            Me.txtInvTotal.Text = Format$(reader.Item("InvAmt"), "n2")
            Me.txtInvNo.Text = reader.Item("InvoiceNum")
            'Me.txtSOANo.Text = IIf(IsDBNull(reader.Item("SOANo")) = False, reader.Item("SOANo"), "")
            Me.txtRemarks.Text = reader.Item("Remarks")
            'Me.chkAllowRelease.Checked = reader.Item("AllowRelease")
            'Me.sslblDateSaved.Text = "Date Saved : " & reader.Item("DateSaved") & " "
            'Me.txtPrepDate.Text = reader.Item("DateSaved")
            'Me.sslblPrepBy.Text = "Prepared By : " & reader.Item("PrepBy") & " "
            'Me.txtPrepBy.Text = reader.Item("PrepBy")
            'If reader.Item("Posted") = True Then
            '    Me.sslblStatus.Text = "Status : "
            '    Me.sslblStatus1.Text = "Posted"
            '    Me.sslblStatus1.ForeColor = Color.Blue
            '    Me.sslblStatus2.Text = "Date Closed : " & reader.Item("DatePosted")
            'Else
            '    Me.sslblStatus.Text = "Status : "
            '    Me.sslblStatus1.Text = "Open"
            '    Me.sslblStatus1.ForeColor = Color.Black
            '    Me.sslblStatus2.Text = ""
            'End If
        End While

        reader.Close()
        cmdSQL.Dispose()

        'RetrieveORNo(Me.tslblRefNo.Text)
        RetrieveIMPFBillingCharges()
        'RetrieveAcctgEntry()
    End Sub
    Private Sub RetrieveIMPDCBillingCharges()
        Dim strSQL As String = "SELECT * FROM bill_impd_charges WHERE RefNo = '" & Me.txtIMPDCRefNo.Text & "'"
        'Dim blVat As Boolean

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            Me.dgDCBillingCharges.Rows.Add(reader.Item("Charges"), reader.Item("Terms"), reader.Item("DRBillingAmt"), reader.Item("DRBillingExRate"), reader.Item("DRBillingAmtPHP"), reader.Item("CRBillingAmt"), reader.Item("CRBillingExRate"), reader.Item("CRBillingAmtPHP"), reader.Item("Remarks"), reader.Item("CHCode"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub
    Private Sub RetrieveIMPFBillingCharges()
        Dim strSQL As String = "SELECT * FROM bill_impfinv_charges WHERE RefNo = '" & Me.txtIMPFBillRefNo.Text & "'"
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
            'Select Case reader.Item("Freight") & vbNullString
            '    Case "P"
            '        Me.optPrepaid.Checked = True
            '    Case "C"
            '        Me.optCollect.Checked = True
            'End Select
            'Select Case reader.Item("CargoLoad") & vbNullString
            '    Case "LCL"
            '        Me.optLCL.Checked = True
            '    Case "FCL"
            '        Me.optFCL.Checked = True
            'End Select
            'Me.optLCL.Checked = True

            'Me.txtShprAddr.Text = reader.Item("ShipperName2") & " " & reader.Item("ShipperName3") & " " & reader.Item("ShipperName4") & " " & reader.Item("ShipperName5")
            Me.txtCneeAddr.Text = reader.Item("ConsigneeName2") & " " & reader.Item("ConsigneeName3") & " " & reader.Item("ConsigneeName4") & " " & reader.Item("ConsigneeName5")
            'Me.txtDesc.Text = reader.Item("Desc1") & " " & reader.Item("Desc2") & " " & reader.Item("Desc3") & " " & reader.Item("Desc4") & " " & reader.Item("Desc5")
            'Me.txtDesc.Text = ""
        End While

        reader.Close()
        cmdSQL.Dispose()

        'Me.chkAllowRelease.Checked = CheckIfAllowRelease(pHBL)
        'PopAllowReleaseHistory(pHBL)
    End Sub

    Private Sub txtGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles txtGrandTotal.TextChanged
        If IsNumeric(Me.txtGrandTotal.Text) = True Then
            Me.txtAmtInWords.Text = English(CDec(Me.txtGrandTotal.Text), "Pesos")
        End If
    End Sub

    Private Sub tscmdSearch_Click(sender As Object, e As EventArgs) Handles tscmdSearch.Click
        Me.cboMBL.SelectedIndex = -1
        Me.cboMBL.Text = ""
        ClearAll()
        frmSearchBilling.Tag = "IMPD"
        frmSearchBilling.ShowDialog()
        GridRestriction()
    End Sub

    Private Sub cmdAddRow_Click(sender As Object, e As EventArgs) Handles cmdAddRow.Click
        Me.dgDCBillingCharges.Rows.Add("", "", 0, 1, 0, 0, 1, 0, "")
    End Sub

    Private Sub dgDCBillingCharges_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDCBillingCharges.CellContentClick

    End Sub

    Private Sub dgDCBillingCharges_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgDCBillingCharges.CellEndEdit
        GridRestriction()
        ComputeTotal()
        PopdtgAcctgTitle()
    End Sub
    Private Sub PopdtgAcctgTitle()
        Me.dtgAcctgTitle.Rows.Clear()
        If Len(Me.txtDRTotal.Text) > 0 Or Len(Me.txtCRTotal.Text) > 0 Then

            PopdtgAcctgTitleRows("1150", 1, CDbl(Me.txtDRTotal.Text - Me.txtCRTotal.Text), 0)
            PopdtgAcctgTitleRows("2020", 1, 0, CDbl(Me.txtDRTotal.Text - Me.txtCRTotal.Text))

        End If

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

            Me.txtDRAcctgEntryTotal.Text = Format$(dblDR, "n2")
            Me.txtCRAcctgEntryTotal.Text = Format$(dblCR, "n2")
        End With
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
    Private Sub ComputeTotal()
        Dim intRow As Integer
        With Me.dgDCBillingCharges
            'COMPUTE DR TOTALS PER ROW
            For intRow = 0 To .RowCount - 1
                If Len(Trim$(.Rows(intRow).Cells(0).Value)) > 0 Then
                    If IsNumeric(.Rows(intRow).Cells(2).Value) = True And IsNumeric(.Rows(intRow).Cells(3).Value) = True Then
                        .Rows(intRow).Cells(4).Value = Format$(CDbl(.Rows(intRow).Cells(2).Value) * CDbl(.Rows(intRow).Cells(3).Value), "n2")
                    End If
                End If
            Next

            'COMPUTE CR TOTALS PER ROW
            For intRow = 0 To .RowCount - 1
                If Len(Trim$(.Rows(intRow).Cells(0).Value)) > 0 Then
                    If IsNumeric(.Rows(intRow).Cells(5).Value) = True And IsNumeric(.Rows(intRow).Cells(6).Value) = True Then
                        .Rows(intRow).Cells(7).Value = Format$(CDbl(.Rows(intRow).Cells(5).Value) * CDbl(.Rows(intRow).Cells(6).Value), "n2")
                    End If
                End If
            Next

            Dim dblTemp As Double = 0

            'COMPUTE DR GRAND TOTAL
            dblTemp = 0
            For intRow = 0 To .RowCount - 1
                If Len(Trim$(.Rows(intRow).Cells(0).Value)) > 0 Then
                    dblTemp = dblTemp + CDbl(.Rows(intRow).Cells(4).Value)
                End If
            Next

            Me.txtDRTotal.Text = Format$(CDbl(dblTemp), "n2")

            'COMPUTE CR GRAND TOTAL
            dblTemp = 0
            For intRow = 0 To .RowCount - 1
                If Len(Trim$(.Rows(intRow).Cells(0).Value)) > 0 Then
                    dblTemp = dblTemp + CDbl(.Rows(intRow).Cells(7).Value)
                End If
            Next

            Me.txtCRTotal.Text = Format$(CDbl(dblTemp), "n2")

        End With
    End Sub
    Private Sub GridRestriction()
        Dim intRow As Integer

        For intRow = 0 To Me.dgDCBillingCharges.Rows.Count - 1
            With Me.dgDCBillingCharges.Rows(intRow)
                If Len(.Cells(0).Value) = 0 Then
                    .Cells(2).ReadOnly = True
                    .Cells(3).ReadOnly = True
                    .Cells(5).ReadOnly = True
                Else
                    .Cells(2).ReadOnly = False
                    .Cells(3).ReadOnly = False
                    .Cells(5).ReadOnly = False
                End If

                If dgDCBillingCharges.Columns(dgDCBillingCharges.CurrentCell.ColumnIndex).Name = colDCCharges.Name Then
                    .Cells(1).Value = "S.O.A."
                    .Cells(9).Value = GetStringValue("Select ChargeCode From lib_charges where ChargeName = '" & .Cells(0).Value & "'", "ChargeCode")

                End If

                'If .Cells(1).Value <> "Sales Invoice" Then
                '    .Cells(5).Value = False
                '    .Cells(5).ReadOnly = True
                'End If

                If IsNumeric(.Cells(2).Value) = False Then
                    .Cells(2).Value = "0"
                End If

                If IsNumeric(.Cells(3).Value) = True Then
                    '.Cells(3).Value = Format$(CDbl(.Cells(3).Value), "0.000")
                    .Cells(3).Value = Math.Round(CDbl(.Cells(3).Value), 4)
                Else
                    .Cells(3).Value = "0"
                End If
            End With
        Next
    End Sub

    Private Sub cboHBL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboHBL.SelectedIndexChanged
        RetrieveHBL(Me.cboHBL.Text)
        RetrieveIMPFBillingMain("HouseBL", Me.cboHBL.Text)
        RetrieveIMPDCBillingMain("BillRefNo", Me.txtIMPFBillRefNo.Text)
        RetrieveAcctgEntry()

        If Len(Me.cboHBL.Text) > 0 Then
            Me.tsBilling.Enabled = True

            If Len(txtIMPDCRefNo.Text) = 0 Then
                EnableBillingButtons(True, False, False, False, False, False, False, False)
                Me.tscmdSearchBill.Enabled = False
            Else
                EnableBillingButtons(False, True, False, False, True, True, True, False)
                Me.tscmdSearchBill.Enabled = True
            End If
        End If
    End Sub

    Public Sub RetrieveIMPDCBillingMain(ByVal strCol As String, ByVal strVal As String)
        Dim strSQL As String = "SELECT * FROM bill_impd_main WHERE " & strCol & " = '" & strVal & "' AND Cancel = FALSE"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        ClearImpDCBilling()

        While reader.Read
            'If Not IsDBNull(reader.Item("SISNo")) Then
            '    'MsgBox("Not yet encoded!", MsgBoxStyle.Critical, "Not yet encoded...")
            '    'reader.Close()
            '    'cmdSQL.Dispose()
            '    'norec = 1
            '    'Exit Sub
            '    Me.cboSISNo.Text = reader.Item("SISNo")
            'End If

            Me.txtIMPDCRefNo.Text = reader.Item("RefNo")
            Me.txtDRCRNo.Text = reader.Item("DRCRNo")
            Me.txtDRTotal.Text = reader.Item("TotalDRPhp")
            Me.txtCRTotal.Text = reader.Item("TotalCRPhp")
            Me.txtExRate.Text = reader.Item("ExRate")

            Me.sslblDateSaved.Text = "Date Saved : " & reader.Item("PrepDate") & " "
            'Me.txtPrepDate.Text = reader.Item("DateSaved")
            Me.sslblPrepBy.Text = "Prepared By : " & reader.Item("PrepBy") & " "
            'Me.txtPrepBy.Text = reader.Item("PrepBy")
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

        'RetrieveORNo(Me.tslblRefNo.Text)
        RetrieveIMPDCBillingCharges()
        'RetrieveAcctgEntry()
    End Sub

    Private Sub dtArrivalDate_ValueChanged(sender As Object, e As EventArgs) Handles dtArrivalDate.ValueChanged
        FillComboBox(Me.cboMBL, "SELECT MBLNo FROM v_frwdg_docs_mbl WHERE ArrivalDate = '" & Format$(dtArrivalDate.Value, "yyyy-MM-dd") & "'", "MBLNo")
    End Sub

    Private Sub tscmdReset_Click(sender As Object, e As EventArgs) Handles tscmdReset.Click
        Me.cboMBL.SelectedIndex = -1
        Me.cboMBL.Text = ""
        Me.dtArrivalDate.Value = GetServerDate()
        ClearAll()
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
        ClearIMPFBilling()
        ClearImpDCBilling()
        'CLEAR ACCTG ENTRY
        'ClearAcctgEntry()

        strEditReason = ""
    End Sub
    Private Sub ClearHBL()
        Me.txtHBLCnee.Text = ""
        Me.txtHBLCneeForwarder.Text = ""
        Me.txtHBLNotify.Text = ""
        Me.txtHBLShipper.Text = ""
    End Sub

    Private Sub ClearIMPFBilling()
        Me.dtgBilling.Rows.Clear()
        Me.txtIMPFBillRefNo.Text = ""
        Me.txtVat.Text = ""
        Me.txtSOA.Text = ""
        Me.txtInvTotal.Text = ""
        Me.txtGrandTotal.Text = ""
        Me.txtAmtInWords.Text = ""

        Me.txtInvNo.Text = ""
        Me.txtSOANo.Text = ""

        Me.txtRemarks.Text = ""
    End Sub

    Public Sub ClearImpDCBilling()
        Me.dgDCBillingCharges.Rows.Clear()
        Me.txtDRTotal.Text = 0
        Me.txtCRTotal.Text = 0
        Me.txtDRCRNo.Text = ""
        Me.txtIMPDCRefNo.Text = ""
        Me.txtDCRemarks.Text = ""

        Me.dtgAcctgTitle.Rows.Clear()
        Me.txtDRAcctgEntryTotal.Text = 0
        Me.txtCRAcctgEntryTotal.Text = 0
    End Sub

    Private Sub tscmdClose_Click(sender As Object, e As EventArgs) Handles tscmdClose.Click
        Me.Dispose()
        Me.Close()
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
        'Me.cboSISNo.Enabled = blcontBilling
        Me.txtInvNo.ReadOnly = Not blcontBilling
        Me.txtSOANo.ReadOnly = Not blcontBilling
        Me.txtRemarks.ReadOnly = Not blcontBilling

        Me.colTerms.ReadOnly = True
        Me.colTotal.ReadOnly = True
    End Sub

    Private Sub tscmdNew_Click(sender As Object, e As EventArgs) Handles tscmdNew.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_IMPDCAF_New") = False Then
        '    MsgBox("You are not allowed to create new transaction for this module.", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If Me.cboHBL.SelectedIndex = -1 Then
            MsgBox("Select HBL Number!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        'ClearBilling()
        EnableBillingButtons(False, False, True, True, False, False, False, True)
        Me.txtExRate.Text = GetDoubleValue("Select Rate from lib_currency where Acronym = 'USD'", "Rate")
        Me.txtDRCRNo.ReadOnly = False
        Me.txtDCRemarks.ReadOnly = False
        Me.cmdAddRow.Enabled = True
        Me.cmdRemoveRow.Enabled = True
        Me.cmdClearRows.Enabled = True
        GridRestriction()
    End Sub

    Private Sub tscmdEdit_Click(sender As Object, e As EventArgs) Handles tscmdEdit.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_IMPDCAF_Edit") = False Then
        '    MsgBox("You are not allowed to edit transaction for this module.", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If Me.sslblStatus1.Text <> "Open" Then
            MsgBox("Billing Already " & Me.sslblStatus1.Text, MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If Me.cboHBL.SelectedIndex = -1 Then
            MsgBox("Select HBL Number!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        strEditReason = InputBox("Enter Reason For Editing : ", "Reason")

        If Len(Trim$(strEditReason)) = 0 Then
            Exit Sub
        End If
        Me.txtDRCRNo.ReadOnly = False
        Me.txtDCRemarks.ReadOnly = False
        Me.cmdAddRow.Enabled = True
        Me.cmdRemoveRow.Enabled = True
        Me.cmdClearRows.Enabled = True
        EnableBillingButtons(False, False, True, True, False, False, False, True)
        GridRestriction()
    End Sub

    Private Sub tscmdResetBilling_Click(sender As Object, e As EventArgs) Handles tscmdResetBilling.Click
        ClearIMPFBilling()
        'ClearAcctgEntry()

        RetrieveIMPFBillingMain("HouseBL", cboHBL.Text)

        If Len(Me.txtIMPFBillRefNo.Text) = 0 Then
            If Len(Me.cboHBL.Text) = 0 Then
                EnableBillingButtons(False, False, False, True, False, False, False, False)
            Else
                EnableBillingButtons(True, False, False, True, False, False, False, False)
            End If
        Else
            EnableBillingButtons(False, True, False, True, True, True, True, False)
        End If
        Me.txtDRCRNo.ReadOnly = True
        Me.txtDCRemarks.ReadOnly = True
        Me.cmdAddRow.Enabled = False
        Me.cmdRemoveRow.Enabled = False
        Me.cmdClearRows.Enabled = False
    End Sub

    Private Sub SaveAcctgEntry()
        Dim strsql As String = "DELETE FROM bill_impd_acctg_entry WHERE RefNo = '" & txtIMPDCRefNo.Text & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)

        cmdsql.ExecuteNonQuery()

        Dim ctrRow As Integer

        For ctrRow = 0 To Me.dtgAcctgTitle.Rows.Count - 1
            With Me.dtgAcctgTitle.Rows(ctrRow)
                strsql = "INSERT INTO bill_impd_acctg_entry (RefNo, Branch, AcctCode, AcctTitle, SubAcctCode," &
                            " SubAcctTitle, SubAcctDept, SubAcctDeptName," &
                            " SubAcctList, SubAcctListItem, SubAcctListItemName, DR, CR)" &
                            " VALUES ('" & Me.txtIMPDCRefNo.Text & "', '" & Mid$(Me.txtIMPDCRefNo.Text, 4, 3) & "', '" & .Cells(0).Value & "', '" & .Cells(1).Value & "'," &
                            " '" & .Cells(2).Value & "', '" & .Cells(3).Value & "', " & .Cells(4).Value & ", '" & .Cells(5).Value & "'," &
                            " " & .Cells(6).Value & ", '" & .Cells(7).Value & "', '" & Replace(.Cells(8).Value, "'", "") & "'," &
                            " " & CDbl(.Cells(9).Value) & ", " & CDbl(.Cells(10).Value) & ")"

                cmdsql = New MySqlCommand(strsql, cnnDBMaster)

                cmdsql.ExecuteNonQuery()
            End With
        Next

        cmdsql.Dispose()
    End Sub

    Private Sub tscmdSave_Click(sender As Object, e As EventArgs) Handles tscmdSave.Click
        Me.dtgBilling.EndEdit()
        'PopdtgAcctgTitle()
        ComputeTotal()

        If CheckRequiredEntries() = False Then
            Exit Sub
        End If

        SaveBillingMain()
        SaveBillingCharges()
        SaveAcctgEntry()
        'SaveEditingRecords()
        RetrieveIMPFBillingMain("RefNo", Me.txtIMPFBillRefNo.Text)


        MsgBox("Billing Saved!" & vbNewLine & "Reference No. :  " & Me.txtIMPDCRefNo.Text, MsgBoxStyle.Information, "Save")

        EnableBillingButtons(False, True, False, True, True, True, True, False)
        Me.txtDRCRNo.ReadOnly = True
        Me.txtDCRemarks.ReadOnly = True
        Me.cmdAddRow.Enabled = False
        Me.cmdRemoveRow.Enabled = False
        Me.cmdClearRows.Enabled = False
    End Sub

    Private Function CheckRequiredEntries() As Boolean
        Dim intRow As Integer

        If Me.cboHBL.SelectedIndex = -1 Then
            MsgBox("Select HBL Number!", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txtDRCRNo.Text) = 0 Then
            MsgBox("Please type Debit Credit Note Number!", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            Exit Function
        End If

        If Me.dgDCBillingCharges.Rows.Count = 0 Then
            MsgBox("Cannot continue with blank charges!", MsgBoxStyle.Critical, "System Message")
            CheckRequiredEntries = False
            Exit Function
        Else
            With Me.dgDCBillingCharges
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
        End If



        If MsgBox("Save Billing?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Save?") = MsgBoxResult.No Then
            CheckRequiredEntries = False
            Exit Function
        End If

        CheckRequiredEntries = True
    End Function

    Private Sub SaveBillingMain()
        Dim strsql As String

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        If Len(Me.txtIMPDCRefNo.Text) = 0 Then
            'NEW BILLING
            Dim strRefNo As String = "BID" & GetCtrlNbr(strCompanyCode, strSiteCode, "Billing_Import_Forwarding_AgencyFee")
            Me.txtIMPDCRefNo.Text = strRefNo
            Dim dtCurrent As Date = GetServerDate()
            strsql = "INSERT INTO bill_impd_main (RefNo, DRCRNo, BillRefNo, Remarks, Posted, Cancel, " &
                        " ExRate, TotalDRPhp, TotalCRPhp, PrepBy, PrepDate)" &
                        " VALUES (@RefNo, @DRCRNo, @BillRefNo, @Remarks ,@Posted,  @Cancel, " &
                        " @ExRate, @TotalDRPhp, @TotalCRPhp, @PrepBy, @PrepDate)"

            Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

            With cmdSQL.Parameters
                .AddWithValue("@RefNo", strRefNo)
                .AddWithValue("@DRCRNo", Me.txtDRCRNo.Text)
                .AddWithValue("@BillRefNo", Me.txtIMPFBillRefNo.Text)
                .AddWithValue("@Remarks", Me.txtDCRemarks.Text)
                .AddWithValue("@Posted", 0)
                .AddWithValue("@Cancel", 0)
                .AddWithValue("@ExRate", CDbl(Me.txtExRate.Text))
                .AddWithValue("@TotalDRPhp", CDbl(Me.txtDRTotal.Text))
                .AddWithValue("@TotalCRPhp", CDbl(Me.txtCRTotal.Text))
                .AddWithValue("@PrepBy", CurrentUser)
                .AddWithValue("@PrepDate", dtCurrent)

            End With

            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "Billing_Import_Forwarding_AgencyFee")
        Else
            Dim dtCurrent As Date = GetServerDate()
            strsql = "UPDATE bill_impd_main SET" &
                        " DRCRNo=@DRCRNo," &
                        " ExRate=@ExRate," &
                        " Remarks=@Remarks," &
                        " TotalDRPhp=@TotalDRPhp," &
                        " TotalCRPhp=@TotalCRPhp," &
                        " ModifiedBy=@ModifiedBy," &
                        " DateModified=@DateModified" &
                     " WHERE" &
                        " RefNo = '" & Me.txtIMPDCRefNo.Text & "'" &
                     " AND" &
                        " Cancel = FALSE"

            Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

            With cmdSQL.Parameters

                .AddWithValue("@DRCRNo", Me.txtDRCRNo.Text)
                .AddWithValue("@ExRate", CDbl(Me.txtExRate.Text))
                .AddWithValue("@Remarks", Me.txtDCRemarks.Text)
                .AddWithValue("@TotalDRPhp", CDbl(Me.txtDRTotal.Text))
                .AddWithValue("@TotalCRPhp", CDbl(Me.txtCRTotal.Text))
                .AddWithValue("@ModifiedBy", CurrentUser)
                .AddWithValue("@DateModified", dtCurrent)
            End With

            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()
        End If
    End Sub

    Private Sub SaveBillingCharges()
        Dim strsql As String, intRow As Integer, intDRow As Integer

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        strsql = "DELETE FROM bill_impd_charges WHERE RefNo = '" & Me.txtIMPDCRefNo.Text & "'"

        Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        cmdSQL.ExecuteNonQuery()

        intDRow = 0
        For intRow = 0 To Me.dgDCBillingCharges.RowCount - 1
            If Len(Me.dtgBilling.Rows(intRow).Cells(0).Value) > 0 Then
                strsql = "INSERT INTO bill_impd_charges (RefNo, Charges, Terms, DRBillingAmt, DRBillingExRate, DRBillingAmtPHP, CRBillingAmt, CRBillingExRate, CRBillingAmtPHP, Remarks, CHCode)" &
                        " VALUES (@RefNo, @Charges, @Terms, @DRBillingAmt, @DRBillingExRate, @DRBillingAmtPHP, @CRBillingAmt, @CRBillingExRate, @CRBillingAmtPHP, @Remarks, @CHCode)"

                cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

                With cmdSQL.Parameters
                    .AddWithValue("@RefNo", Me.txtIMPDCRefNo.Text)
                    .AddWithValue("@Charges", Me.dgDCBillingCharges.Rows(intRow).Cells(0).Value)
                    .AddWithValue("@Terms", Me.dgDCBillingCharges.Rows(intRow).Cells(1).Value)
                    .AddWithValue("@DRBillingAmt", CDbl(Me.dgDCBillingCharges.Rows(intRow).Cells(2).Value))
                    .AddWithValue("@DRBillingExRate", CDbl(Me.dgDCBillingCharges.Rows(intRow).Cells(3).Value))
                    .AddWithValue("@DRBillingAmtPHP", CDbl(Me.dgDCBillingCharges.Rows(intRow).Cells(4).Value))
                    .AddWithValue("@CRBillingAmt", CDbl(Me.dgDCBillingCharges.Rows(intRow).Cells(5).Value))
                    .AddWithValue("@CRBillingExRate", CDbl(Me.dgDCBillingCharges.Rows(intRow).Cells(6).Value))
                    .AddWithValue("@CRBillingAmtPHP", CDbl(Me.dgDCBillingCharges.Rows(intRow).Cells(7).Value))

                    .AddWithValue("@Remarks", Me.dgDCBillingCharges.Rows(intRow).Cells(8).Value)
                    .AddWithValue("@CHCode", Me.dgDCBillingCharges.Rows(intRow).Cells(9).Value)
                End With

                cmdSQL.ExecuteNonQuery()
                'intDRow = intDRow + 1
            End If
        Next

        cmdSQL.Dispose()
    End Sub

    Private Sub DebitCreditNoteFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebitCreditNoteFormToolStripMenuItem.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_IMPDCAF_Print") = False Then
        '    MsgBox("You are not allowed to print transaction for this module.", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If Len(Me.txtIMPDCRefNo.Text) = 0 Then
            MsgBox("No record to print!", MsgBoxStyle.Critical, "System Message")
            Exit Sub
        End If

        frmPrintPreview.PrintImpFDCForm()
        frmPrintPreview.ShowDialog()
    End Sub

    Private Sub tscmdPost_Click(sender As Object, e As EventArgs) Handles tscmdPost.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_IMPDCAF_Post") = False Then
        '    MsgBox("You are not allowed to post transation for this module.", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If Len(Me.txtIMPDCRefNo.Text) = 0 Then
            MsgBox("Nothing to Post!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If Me.sslblStatus1.Text <> "Open" Then
            MsgBox("Billing Already " & Me.sslblStatus1.Text, MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If MsgBox("Please make sure that all entries are correct before Posting!" & vbNewLine & "Post this reference no. " & Me.txtIMPDCRefNo.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim dtcurrent As Date = GetServerDate()

        Dim strsql As String = "UPDATE bill_impd_main SET" &
                                " Posted = @Posted, " &
                                " PostedBy = @PostedBy, " &
                                " DatePosted = @PostedDate " &
                                " WHERE RefNo = '" & Me.txtIMPDCRefNo.Text & "' AND Cancel = FALSE"

        Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@Posted", True)
            .AddWithValue("@PostedBy", CurrentUser)
            .AddWithValue("@PostedDate", dtcurrent)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()

        RetrieveIMPDCBillingMain("RefNo", Me.txtIMPDCRefNo.Text)
        MsgBox("Billing Reference No. " & Me.txtIMPDCRefNo.Text & " is Posted!", MsgBoxStyle.Information, "System Message")
    End Sub

    Private Sub tscmdCancel_Click(sender As Object, e As EventArgs) Handles tscmdCancel.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_IMPDCAF_Cancel") = False Then
        '    MsgBox("You are not allowed to cancel transaction for this module.", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If Len(Me.txtIMPDCRefNo.Text) = 0 Then
            MsgBox("Nothing to Cancel!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If Me.sslblStatus1.Text <> "Open" Then
            MsgBox("Billing Already " & Me.sslblStatus1.Text, MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If MsgBox("Please make sure that all entries are correct before Posting!" & vbNewLine & "Post this reference no. " & Me.txtIMPDCRefNo.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim dtcurrent As Date = GetServerDate()

        Dim strsql As String = "UPDATE bill_impd_main SET" &
                                " Cancel = @Cancel, " &
                                " CancelBy = @CancelBy, " &
                                " DateCancel = @DateCancel " &
                                " WHERE RefNo = '" & Me.txtIMPDCRefNo.Text & "' AND Posted = FALSE"

        Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@Cancel", True)
            .AddWithValue("@CancelBy", CurrentUser)
            .AddWithValue("@DateCancel", dtcurrent)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()

        RetrieveIMPDCBillingMain("RefNo", Me.txtIMPDCRefNo.Text)
        MsgBox("Billing Reference No. " & Me.txtIMPDCRefNo.Text & " is Cancelled!", MsgBoxStyle.Information, "System Message")
    End Sub

    Private Sub tscmdPostBatch_Click(sender As Object, e As EventArgs) Handles tscmdPostBatch.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_IMPDCAF_Post") = False Then
        '    MsgBox("You are not allowed to post transation for this module.", vbInformation, "System Message")
        '    Exit Sub
        'End If

        frmUnposted.Tag = "Import DC Note Billing"
        frmUnposted.ShowDialog()
    End Sub

    Private Sub cmdRemoveRow_Click(sender As Object, e As EventArgs) Handles cmdRemoveRow.Click
        If Me.dgDCBillingCharges.RowCount > 0 Then
            Me.dgDCBillingCharges.Rows.Remove(Me.dgDCBillingCharges.CurrentRow)
        End If

        Me.dgDCBillingCharges.EndEdit()
        ComputeTotal()
        PopdtgAcctgTitle()
    End Sub

    Private Sub cmdClearRows_Click(sender As Object, e As EventArgs) Handles cmdClearRows.Click
        Me.dgDCBillingCharges.Rows.Clear()
        Me.txtDRTotal.Text = 0
        Me.txtCRTotal.Text = 0
    End Sub

    Private Sub SoftCopyDebitCreditNoteFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SoftCopyDebitCreditNoteFormToolStripMenuItem.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_IMPDCAF_Print") = False Then
        '    MsgBox("You are not allowed to print transaction for this module.", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If Len(Me.txtIMPDCRefNo.Text) = 0 Then
            MsgBox("No record to print!", MsgBoxStyle.Critical, "System Message")
            Exit Sub
        End If

        frmPrintPreview.PrintImpFDCForm_S()
        frmPrintPreview.ShowDialog()
    End Sub
End Class