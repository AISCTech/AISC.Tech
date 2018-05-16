Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmRequest
    Implements ICommonFunction

    Dim strCostType As String
    Private EnableButtons As New clsEnableToolstripObjects()

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        If Len(Me.lblReqNbr.Text) = 0 Then
            MsgBox("Nothing to Cancel!", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.txtStatus.Text <> "Open" Then
            MsgBox("Cannot cancel request. Request already " & Me.txtStatus.Text & "!", vbInformation, "System Message")
            Exit Sub
        End If


        CancelRequest(Me.lblReqNbr.Text)
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        If Len(Me.lblReqNbr.Text) = 0 Then
            MsgBox("Nothing to Edit!", vbInformation, "System Message")
            Exit Sub
        End If
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        'If GetBooleanField("Select New from tbl_useraccessrestrictions WHERE User_ID = '' and Group_ID = '' and Company_Code =''", "New") = False Then
        '    MsgBox("You are not allowed to create new transaction", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If MsgBox("Are you sure you want to create new Request?", vbYesNo, "Create New?") = vbNo Then Exit Sub
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
        ClearEntries()
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        'If Len(Me.lblReqNbr.Text) = 0 Then
        '    MsgBox("Nothing to Post!", vbInformation, "System Message")
        '    Exit Sub
        'End If
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        If Len(Me.lblReqNbr.Text) = 0 Then
            MsgBox("Nothing to Print!", vbInformation, "System Message")
            Exit Sub
        End If
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        If Len(Me.lblReqNbr.Text) = 0 Then
            MsgBox("Nothing to Re-Open!", vbInformation, "System Message")
            Exit Sub
        End If
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckForRequiredEntries() = False Then Exit Sub
        Dim strRequest As String = ""

        If Me.optPettyCash.Checked = True Then
            strRequest = "Petty Cash Request"
        End If

        If Me.optCheck.Checked = True Then
            strRequest = "Cheque Request"
        End If

        If Me.optMC.Checked = True Then
            strRequest = "Manager's Cheque Request"
        End If

        If MsgBox("Are you sure you want to save this transaction as " & strRequest & "?", vbYesNo, "Confirm Save") = vbNo Then Exit Sub

        SaveRequest()
    End Sub

    Public Sub SaveRequest()
        Dim cmdSQL As New MySqlCommand

        Dim dtCurrent As Date
        Dim PONumber As String = ""
        Dim intReqType As Integer = 0
        'script to get the current date of MYSQL Server
        dtCurrent = GetServerDate()

        If Me.optPettyCash.Checked = True Then
            intReqType = 1
        End If

        If Me.optCheck.Checked = True Then
            intReqType = 2
        End If

        If Me.optMC.Checked = True Then
            intReqType = 2
        End If

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        If Len(Me.lblReqNbr.Text) = 0 Then

            Try
                cmdSQL.CommandText = ("INSERT INTO tbl_request (`REQ_Nbr`, `REQ_ReqType`, `REQ_PayeeID`, REQ_DtNeed, REQ_Type, REQ_PlateNbr, REQ_ChargeID, REQ_ChargeTo, REQ_Remarks, REQ_TotalAmt, REQ_PrepDate, REQ_PrepBy, REQ_ModBy, REQ_ModDate, REQ_Cancel, REQ_Release, REQ_Invoice, REQ_Liquidated, REQ_BranchCode, REQ_CompanyCode)  VALUES " &
                                     "               (@REQ_Nbr, @REQ_ReqType, @REQ_PayeeID, @REQ_DtNeed, @REQ_Type, @REQ_PlateNbr, @REQ_ChargeID, @REQ_ChargeTo, @REQ_Remarks, @REQ_TotalAmt, @REQ_PrepDate, @REQ_PrepBy, @REQ_ModBy, @REQ_ModDate, @REQ_Cancel, @REQ_Release, @REQ_Invoice, @REQ_Liquidated, @REQ_BranchCode, @REQ_CompanyCode)")


                With cmdSQL.Parameters
                    Dim crpNumber As String = "R" & GetCtrlNbr(strCompanyCode, strSiteCode, "Request_for_Payment")

                    If Len(crpNumber) = 0 Then
                        MsgBox("Error getting request number.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    .AddWithValue("@REQ_Nbr", crpNumber)
                    .AddWithValue("@REQ_ReqType", intReqType)
                    .AddWithValue("@REQ_PayeeID", Me.txtPayeeCode.Text)
                    .AddWithValue("@REQ_DtNeed", Me.dtReceipt.Value)
                    .AddWithValue("@REQ_Type", Me.txtType.Text)
                    .AddWithValue("@REQ_PlateNbr", Me.cboPlateNo.Text)
                    .AddWithValue("@REQ_ChargeID", Me.txtChargeTo.Text)
                    .AddWithValue("@REQ_ChargeTo", Me.txtChargeToName.Text)
                    .AddWithValue("@REQ_Remarks", Me.txtRemarks.Text)
                    .AddWithValue("@REQ_TotalAmt", CDbl(Me.txtGrandTotal.Text))
                    .AddWithValue("@REQ_PrepDate", dtCurrent)
                    .AddWithValue("@REQ_PrepBy", strCurrentUser)
                    .AddWithValue("@REQ_ModDate", dtCurrent)
                    .AddWithValue("@REQ_ModBy", strCurrentUser)
                    .AddWithValue("@REQ_Cancel", 0)
                    .AddWithValue("@REQ_Release", 0)
                    .AddWithValue("@REQ_Invoice", Me.txtInvoice.Text)
                    .AddWithValue("@REQ_Liquidated", 0)
                    .AddWithValue("@REQ_BranchCode", "MNL")
                    .AddWithValue("@REQ_CompanyCode", Me.txtCompanyCode.Text)
                    Me.lblReqNbr.Text = crpNumber
                    Me.txtEncodedBy.Text = strCurrentUser
                    Me.txtDateEncoded.Text = Format(dtCurrent, "yyyy-MM-dd hhmm : ss")
                    Me.txtModifiedBy.Text = strCurrentUser
                    Me.txtDateModified.Text = Format(dtCurrent, "yyyy-MM-dd hh: mm : ss")
                    Me.txtStatus.Text = "Open"
                End With

                cmdSQL.Connection = cnnDBMaster
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Dispose()

            Catch ex As Exception
                MsgBox("There was an Error trying To save the record - " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "Request_for_Payment")

            MsgBox("Record Successfully Saved!", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            'save transaction log
            SaveTransLogs("Create New", Me.Name, "Request", Me.lblReqNbr.Text, strCurrentUser)

        Else
            'update record

            Dim sSQL As String = "UPDATE  tbl_request Set "
            sSQL += " REQ_ReqType=@REQ_ReqType, "
            sSQL += " REQ_PayeeID=@REQ_PayeeID, "
            sSQL += " REQ_DtNeed=@REQ_DtNeed, "
            sSQL += " REQ_Type=@REQ_Type, "
            sSQL += " REQ_PlateNbr=@REQ_PlateNbr, "
            sSQL += " REQ_ChargeID=@REQ_ChargeID, "
            sSQL += " REQ_ChargeTo=@REQ_ChargeTo, "
            sSQL += " REQ_Remarks=@REQ_Remarks, "
            sSQL += " REQ_TotalAmt=@REQ_TotalAmt, "
            sSQL += " REQ_Invoice=@REQ_Invoice, "
            sSQL += " REQ_ModBy=@REQ_ModBy, "
            sSQL += " REQ_ModDate=@REQ_ModDate "
            sSQL += " WHERE REQ_Nbr= '" & Me.lblReqNbr.Text & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters
                .AddWithValue("@REQ_ReqType", intReqType)
                .AddWithValue("@REQ_PayeeID", Me.txtPayeeCode.Text)
                .AddWithValue("@REQ_DtNeed", Me.dtReceipt.Value)
                .AddWithValue("@REQ_Type", Me.txtType.Text)
                .AddWithValue("@REQ_PlateNbr", Me.cboPlateNo.Text)
                .AddWithValue("@REQ_ChargeID", Me.txtChargeTo.Text)
                .AddWithValue("@REQ_ChargeTo", Me.txtChargeToName.Text)
                .AddWithValue("@REQ_Remarks", Me.txtRemarks.Text)
                .AddWithValue("@REQ_TotalAmt", CDbl(Me.txtGrandTotal.Text))
                .AddWithValue("@REQ_Invoice", Me.txtInvoice.Text)
                .AddWithValue("@REQ_ModBy", strCurrentUser)
                .AddWithValue("@REQ_ModDate", dtCurrent)

            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()


            'Delete record in tbl_requestd
            Dim cmdSysParam As MySqlCommand
            Dim sqlString2 As String = "DELETE FROM tbl_requestd WHERE REQD_REQNbr = '" & Me.lblReqNbr.Text & "'"

            cmdSysParam = New MySqlCommand(sqlString2, cnnDBMaster)
            cmdSysParam.ExecuteNonQuery()

            cmdSysParam.Dispose()

            If Len(lblReqNbr.Text) > 0 Then
                If Len(Me.txtEditReason.Text) > 0 Then
                    'SaveEditHistory()
                End If
            End If

            MsgBox("Record " & Me.lblReqNbr.Text & " Successfully Updated!", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            Me.txtModifiedBy.Text = strCurrentUser
            Me.txtDateModified.Text = Format(dtCurrent, "yyyy-MM-dd hh:mm:ss")
            Me.txtStatus.Text = "Open"
            SaveTransLogs("Edit Record", Me.Name, "Request", Me.lblReqNbr.Text, strCurrentUser)
        End If

        'save detail of payments
        For i = 0 To Me.dgDetails.Rows.Count - 1
            Dim cmdSQLPart1 As New MySqlCommand
            Dim h As DataGridViewRow
            cmdSQLPart1.Connection = cnnDBMaster
            h = Me.dgDetails.Rows(i)
            If Not Len(h.Cells(1).Value) = 0 Then
                Select Case Me.txtType.Text
                    Case "ADM"
                        cmdSQLPart1.CommandText = ("INSERT INTO tbl_requestd (REQD_REQNbr, REQD_Particulars, REQD_Qty, REQD_Unit, REQD_UnitCost, REQD_Amount, REQD_Index, REQD_CostCenter, REQD_ReturnAmt, REQD_RefundAmt, REQD_LiquidatedAmt)  VALUES " &
                                          "                   (@REQD_REQNbr, @REQD_Particulars, @REQD_Qty, @REQD_Unit, @REQD_UnitCost, @REQD_Amount, @REQD_Index, @REQD_CostCenter, @REQD_ReturnAmt, @REQD_RefundAmt, @REQD_LiquidatedAmt)")

                        With cmdSQLPart1.Parameters
                            .AddWithValue("@REQD_REQNbr", Me.lblReqNbr.Text)
                            .AddWithValue("@REQD_Particulars", h.Cells(1).Value)
                            .AddWithValue("@REQD_Qty", CDbl(h.Cells(2).Value))
                            .AddWithValue("@REQD_Unit", h.Cells(3).Value)
                            .AddWithValue("@REQD_UnitCost", CDbl(h.Cells(4).Value))
                            .AddWithValue("@REQD_Amount", CDbl(h.Cells(5).Value))
                            .AddWithValue("@REQD_Index", h.Index)
                            .AddWithValue("@REQD_CostCenter", h.Cells(6).Value)
                            .AddWithValue("@REQD_ReturnAmt", 0)
                            .AddWithValue("@REQD_RefundAmt", 0)
                            .AddWithValue("@REQD_LiquidatedAmt", 0)
                        End With

                        cmdSQLPart1.ExecuteNonQuery()
                    Case "OPR"
                        cmdSQLPart1.CommandText = ("INSERT INTO tbl_requestd (REQD_REQNbr, REQD_Particulars, REQD_Amount, REQD_Index, REQD_BookNbr,  REQD_Shipper, REQD_Consignee, REQD_ContainerNo, REQD_HBL, REQD_Key,  REQD_CHCode, REQD_CostCenter, REQD_ReturnAmt, REQD_RefundAmt, REQD_LiquidatedAmt)  VALUES " &
                                          "                   (@REQD_REQNbr, @REQD_Particulars, @REQD_Amount, @REQD_Index, @REQD_BookNbr, @REQD_Shipper, @REQD_Consignee,  @REQD_ContainerNo, @REQD_HBL, @REQD_Key,  @REQD_CHCode, @REQD_CostCenter, @REQD_ReturnAmt, @REQD_RefundAmt, @REQD_LiquidatedAmt)")

                        With cmdSQLPart1.Parameters
                            .AddWithValue("@REQD_REQNbr", Me.lblReqNbr.Text)
                            .AddWithValue("@REQD_Particulars", h.Cells(1).Value)
                            .AddWithValue("@REQD_Amount", CDbl(h.Cells(2).Value))
                            .AddWithValue("@REQD_Index", h.Index)
                            .AddWithValue("@REQD_BookNbr", h.Cells(3).Value)
                            .AddWithValue("@REQD_Shipper", h.Cells(4).Value)
                            .AddWithValue("@REQD_Consignee", h.Cells(5).Value)
                            .AddWithValue("@REQD_ContainerNo", h.Cells(6).Value)
                            .AddWithValue("@REQD_HBL", h.Cells(7).Value)
                            .AddWithValue("@REQD_Key", h.Cells(8).Value)
                            .AddWithValue("@REQD_CHCode", h.Cells(9).Value)
                            .AddWithValue("@REQD_CostCenter", h.Cells(11).Value)
                            .AddWithValue("@REQD_ReturnAmt", 0)
                            .AddWithValue("@REQD_RefundAmt", 0)
                            .AddWithValue("@REQD_LiquidatedAmt", 0)
                        End With

                        cmdSQLPart1.ExecuteNonQuery()
                End Select

            End If
            cmdSQLPart1.Dispose()
        Next
        '*******

        cnnDBMaster.Close()
        cnnDBMaster.Dispose()

        PopulateItems(Me.dgDetails, Me.lblReqNbr.Text)
    End Sub
    Public Function CheckForRequiredEntries() As Boolean
        Dim dtCurrent As Date = GetServerDate()
        Dim TimeStart As DateTime = #8:30:00 AM#
        Dim TimeEnd As DateTime = #5:45:00 PM#

        Me.txtPayeeName.Focus()
        'check Date Needed
        If strCurrentUser <> "admin" Then
            If CDate(dtReceipt.Value) < CDate(dtCurrent) Then
                MsgBox("Date Needed should be ahead of Present Date and Time", MsgBoxStyle.Critical, "Please select valid Date Needed")
                CheckForRequiredEntries = False
                Exit Function
            Else
                'check Time needed
                'should be from 8:30am - 5:45pm only
                If TimeStart.TimeOfDay > dtReceipt.Value.TimeOfDay Or TimeEnd.TimeOfDay < dtReceipt.Value.TimeOfDay Then
                    MsgBox("Releasing of fund from Accounting Dept. is from 8:30am up to 5:45pm only", MsgBoxStyle.Critical, "Please select valid Date Needed")
                    CheckForRequiredEntries = False
                    Exit Function
                End If
            End If
        End If

        'check if payee 
        If Len(txtPayeeCode.Text) = 0 Then
            MsgBox("Please select payee.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If
        'check if remarks 
        If Len(txtRemarks.Text) = 0 Then
            MsgBox("Please type remarks.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        'check if particulars with corresponding amount is present.
        For i As Integer = 0 To Me.dgDetails.Rows.Count - 1
            Dim h As DataGridViewRow
            h = Me.dgDetails.Rows(i)

            If Len(h.Cells(1).Value) <> 0 And Len(h.Cells(2).Value) <> 0 Then
                If Len(h.Cells(1).Value) = 0 Then
                    MsgBox("Please enter a particular.", MsgBoxStyle.Critical, "Missing Information")
                    CheckForRequiredEntries = False
                    Exit Function
                End If
            End If
        Next

        If Not IsDate(Me.txtDateNeeded.Text) Then
            MsgBox("Please Select Date Needed. ", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If


        'Charge To
        If Me.cboChargeTo.SelectedIndex = -1 Then
            MsgBox("Please Select Charge to.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        Dim objChargeTo As IConvertible = TryCast(cboChargeTo.SelectedValue, IConvertible)

        'If objChargeTo <> "AIS" Then
        If Len(Me.txtChargeToName.Text) = 0 Then
            MsgBox("Please type Charge to name", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        CheckForRequiredEntries = True
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

            .UpdateEnabledButtons()

            Me.txtRequestNo.ReadOnly = blUserInput
            Me.btPayee.Enabled = blUserInput
            Me.txtRemarks.ReadOnly = Not blUserInput
            Me.dtReceipt.Visible = blUserInput
            Me.cboType.Enabled = blUserInput
            Me.cboPlateNo.Enabled = blUserInput
            Me.cboChargeTo.Enabled = blUserInput
            Me.txtChargeToName.ReadOnly = Not blUserInput
            Me.txtInvoice.ReadOnly = Not blUserInput
            Me.btAddDetails.Enabled = blUserInput
            Me.btRemoveDetails.Enabled = blUserInput
        End With
    End Sub

    Private Sub frmRequest_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cboReports.Items.Add("Preview Request")
        Me.cboReports.Items.Add("Preview as PURCHASE ORDER")
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        FillComboBox(Me.cboType, "Select ParamName from lib_requestparams where ParamType = 'TYP'", "ParamName")
        FillComboBox(Me.cboChargeTo, "Select ParamName from lib_requestparams where ParamType = 'CRG'", "ParamName")
        FillComboBox(Me.cboPlateNo, "Select PlateNo from lib_vehicles where Active = 1", "PlateNo")
        Me.txtRequestNo.SetWaterMark("Enter Request No. here")
    End Sub
    Public Sub SetColumnProp()
        Me.dgDetails.Columns.Clear()
        Me.dgDetails.Rows.Clear()
        Dim colBut As New DataGridViewButtonColumn

        With Me.dgDetails
            Select Case Me.txtType.Text

                Case "ADM"
                    With Me.dgDetails
                        .Columns.Add(colBut)
                        .Columns.Add("", "Particulars")
                        .Columns.Add("", "Qty")
                        .Columns.Add("", "Unit")
                        .Columns.Add("", "Unit Cost")
                        .Columns.Add("", "Total")
                        .Columns.Add("", "Cost Center")
                        .Columns.Add("", "Return Amount")
                        .Columns.Add("", "Refund Amount")
                        .Columns.Add("", "Liquidated Amount")

                        .AllowUserToAddRows = False
                        .AllowUserToResizeColumns = True
                        .MultiSelect = False

                    End With

                    .Columns(0).Width = 25
                    .Columns(1).Width = 220
                    .Columns(2).Width = 100
                    .Columns(3).Width = 100
                    .Columns(4).Width = 100
                    .Columns(5).Width = 100
                    .Columns(6).Width = 100


                    .Columns(1).DefaultCellStyle.ForeColor = Color.DarkBlue
                    .Columns(2).DefaultCellStyle.ForeColor = Color.Firebrick

                    .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(1).Frozen = True
                    .Columns(2).Frozen = True
                    .Columns(1).ReadOnly = True
                    .Columns(2).ReadOnly = True
                    .Columns(3).ReadOnly = True
                    .Columns(4).ReadOnly = True
                    .Columns(5).ReadOnly = True
                    .Columns(6).ReadOnly = True
                    .Columns(7).ReadOnly = True
                    .Columns(8).ReadOnly = True
                    .Columns(9).ReadOnly = True
                Case "OPR"
                    With Me.dgDetails
                        .Columns.Add(colBut)
                        .Columns.Add("", "Particulars")
                        .Columns.Add("", "Amount")
                        .Columns.Add("", "Booking #")
                        .Columns.Add("", "Shipper")
                        .Columns.Add("", "Consignee")
                        .Columns.Add("", "Container#")
                        .Columns.Add("", "BL#")
                        .Columns.Add("", "Key")
                        .Columns.Add("", "")
                        .Columns.Add("", "CH Code")
                        .Columns.Add("", "Cost Center")
                        .Columns.Add("", "Return Amount")
                        .Columns.Add("", "Refund Amount")
                        .Columns.Add("", "Liquidated Amount")

                        .AllowUserToAddRows = False
                        .AllowUserToResizeColumns = True
                        .MultiSelect = False

                    End With

                    .Columns(0).Width = 25
                    .Columns(1).Width = 220
                    .Columns(2).Width = 100
                    .Columns(3).Width = 140
                    .Columns(4).Width = 220
                    .Columns(5).Width = 220
                    .Columns(6).Width = 120
                    .Columns(7).Width = 120
                    .Columns(8).Width = 50
                    .Columns(9).Width = 50
                    .Columns(10).Width = 50


                    .Columns(1).DefaultCellStyle.ForeColor = Color.DarkBlue
                    .Columns(2).DefaultCellStyle.ForeColor = Color.Firebrick

                    .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    .Columns(1).Frozen = True
                    .Columns(2).Frozen = True
                    .Columns(1).ReadOnly = True
                    .Columns(2).ReadOnly = True
                    .Columns(3).ReadOnly = True
                    .Columns(4).ReadOnly = True
                    .Columns(5).ReadOnly = True
                    .Columns(6).ReadOnly = True
                    .Columns(7).ReadOnly = True
                    .Columns(8).ReadOnly = True
                    .Columns(9).ReadOnly = True
                    .Columns(10).ReadOnly = True
                    .Columns(11).ReadOnly = True
                    .Columns(12).ReadOnly = True
                    .Columns(13).ReadOnly = True
                    .Columns(14).ReadOnly = True
            End Select

        End With

        Me.Refresh()
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        If Me.cboType.SelectedIndex = -1 Then Exit Sub

        If Me.dgDetails.Rows.Count > 0 Then
            If Me.cboType.Text <> strCostType Then
                If MsgBox("Are you sure you want to change Cost Type?" & vbNewLine & "This will clear all encoded details in the grid", vbYesNo, "Confirm Change") = vbNo Then
                    'Me.cboType.Text = GetStringValue("Select ParamName from lib_requestparams where ParamCode = '" & Me.txtType.Text & "' and ParamType ='TYP'", "ParamName")
                    Me.cboType.Text = strCostType
                    Exit Sub
                Else

                    Me.txtType.Text = GetStringValue("Select ParamCode from lib_requestparams where ParamName = '" & Me.cboType.Text & "' and ParamType ='TYP'", "ParamCode")
                    SetColumnProp()
                    Me.dgDetails.Rows.Clear()
                    strCostType = Me.cboType.Text
                End If
            End If
        Else


            Me.txtType.Text = GetStringValue("Select ParamCode from lib_requestparams where ParamName = '" & Me.cboType.Text & "' and ParamType ='TYP'", "ParamCode")
            SetColumnProp()
            Me.dgDetails.Rows.Clear()
            strCostType = Me.cboType.Text
        End If


    End Sub

    Private Sub cboChargeTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChargeTo.SelectedIndexChanged
        If Me.cboChargeTo.SelectedIndex = -1 Then Exit Sub
        Me.txtChargeTo.Text = GetStringValue("Select ParamCode from lib_requestparams where ParamName = '" & Me.cboChargeTo.Text & "' and ParamType ='CRG'", "ParamCode")
    End Sub

    Private Sub frmRequest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub btAddDetails_Click(sender As Object, e As EventArgs) Handles btAddDetails.Click
        If Me.cboType.SelectedIndex = -1 Then
            MsgBox("Please select Cost Type of Request First!", vbInformation, "System Message")
            Exit Sub
        End If

        Me.dgDetails.Rows.Add()
    End Sub

    Private Sub frmRequest_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
        Me.Dispose()
    End Sub

    Private Sub btRemoveDetails_Click(sender As Object, e As EventArgs) Handles btRemoveDetails.Click
        If Me.dgDetails.Rows.Count > 0 Then
            If Me.dgDetails.CurrentRow.Index >= 0 Then
                If Not dgDetails.CurrentRow.IsNewRow Then
                    dgDetails.Rows.Remove(dgDetails.CurrentRow)
                End If
            End If
        End If
        Me.txtGrandTotal.Text = Format(SumAmount, "n2")
    End Sub
    Public Function SumAmount() As Double
        Dim i As Integer
        Dim h As DataGridViewRow

        For i = 0 To Me.dgDetails.Rows.Count - 1
            h = Me.dgDetails.Rows(i)

            Select Case Me.txtType.Text
                Case "ADM"
                    If Not Len(h.Cells(5).Value) = 0 Then
                        SumAmount = SumAmount + h.Cells(5).Value
                    End If
                Case "OPR"
                    If Not Len(h.Cells(2).Value) = 0 Then
                        SumAmount = SumAmount + h.Cells(2).Value
                    End If
            End Select


        Next

        Return SumAmount

    End Function

    Private Sub txtGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles txtGrandTotal.TextChanged
        If Not Len(Me.txtGrandTotal.Text) = 0 Then
            Me.txtAmtInWords.Text = English(Me.txtGrandTotal.Text)
        End If
    End Sub

    Private Sub dgDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        Select Case Me.txtType.Text
            Case "ADM"
                frmSelectADMRequestItem.intIndex = Me.dgDetails.CurrentRow.Index
                frmSelectADMRequestItem.dtgDesc.Rows.Clear()
                frmSelectADMRequestItem.dtgDesc.Rows.Add(Me.dgDetails.CurrentRow.Cells(1).Value, Me.dgDetails.CurrentRow.Cells(2).Value, Me.dgDetails.CurrentRow.Cells(3).Value, Me.dgDetails.CurrentRow.Cells(4).Value, Me.dgDetails.CurrentRow.Cells(5).Value, Me.dgDetails.CurrentRow.Index)
                frmSelectADMRequestItem.ShowDialog()
            Case "OPR"
        End Select
    End Sub

    Public Sub ClearEntries()
        Me.lblReqNbr.Text = ""
        Me.txtPayeeCode.Text = ""
        Me.txtPayeeName.Text = ""
        Me.txtRemarks.Text = ""
        Me.txtDateNeeded.Text = ""
        Me.txtType.Text = ""
        Me.cboType.SelectedIndex = -1
        Me.cboPlateNo.SelectedIndex = -1
        Me.txtChargeTo.Text = ""
        Me.cboChargeTo.SelectedIndex = -1
        Me.txtChargeToName.Text = ""
        Me.txtInvoice.Text = ""
        Me.dgDetails.Rows.Clear()
        Me.txtGrandTotal.Text = 0
        Me.dtgEditReason.Rows.Clear()
        Me.dtgAPV.Rows.Clear()
        Me.dtgCV.Rows.Clear()
        Me.txtEncodedBy.Text = ""
        Me.txtDateEncoded.Text = ""
        Me.txtModifiedBy.Text = ""
        Me.txtDateModified.Text = ""
        Me.txtCompanyCode.Text = strCompanyCode
    End Sub

    Private Sub PopulateItems(ByVal dg As DataGridView, ByVal str As String)
        SetColumnProp()
        dg.Rows.Clear()

        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM tbl_requestd " &
                 "WHERE REQD_REQNbr = '" & str & "' " &
                 "ORDER BY REQD_Index"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read

            Select Case Me.txtType.Text
                Case "ADM"
                    dg.Rows.Add("", reader.Item("REQD_Particulars"), Format(reader.Item("REQD_Qty"), "n2"), reader.Item("REQD_Unit"), Format(reader.Item("REQD_UnitCost"), "n2"), Format(reader.Item("REQD_Amount"), "n2"), reader.Item("REQD_CostCenter"), Format(reader.Item("REQD_ReturnAmt"), "n2"), Format(reader.Item("REQD_RefundAmt"), "n2"), Format(reader.Item("REQD_LiquidatedAmt"), "n2"))
                Case "OPR"
                    dg.Rows.Add("", reader.Item("REQD_Particulars"), Format(reader.Item("REQD_Amount"), "n2"), reader.Item("REQD_BookNbr"), reader.Item("REQD_Shipper"), reader.Item("REQD_Consignee"), reader.Item("REQD_ContainerNo"), reader.Item("REQD_HBL"), reader.Item("REQD_Key"), IIf(IsDBNull(reader.Item("REQD_CHCode")), "", reader.Item("REQD_CHCode")), Format(reader.Item("REQD_ReturnAmt"), "n2"), Format(reader.Item("REQD_RefundAmt"), "n2"), Format(reader.Item("REQD_LiquidatedAmt"), "n2"))
            End Select

        End While

        cmd.Dispose()
        reader.Close()
    End Sub

    Private Sub dtReceipt_ValueChanged(sender As Object, e As EventArgs) Handles dtReceipt.ValueChanged
        Me.txtDateNeeded.Text = Format(Me.dtReceipt.Value, "yyyy-MM-dd")
    End Sub

    Private Sub cboReports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReports.SelectedIndexChanged
        If Me.cboReports.SelectedIndex = -1 Then Exit Sub

        Select Case Me.cboReports.Text
            Case "Preview Request"
                If Me.txtStatus.Text <> "Open" Then
                    MsgBox("Cannot print request. Request already " & Me.txtStatus.Text & "!", vbInformation, "System Message")
                    Exit Sub
                End If

                Dim strReqType As String = ""
                If Me.optPettyCash.Checked = True Then
                    strReqType = "Petty Cash"
                End If
                If Me.optCheck.Checked = True Then
                    strReqType = "Check"
                End If
                If Me.optPettyCash.Checked = True Then
                    strReqType = "MC"
                End If
                'save to translogs
                SaveTransLogs("Print Request for Payment", Me.Name, "Request No.", Me.lblReqNbr.Text, strCurrentUser)
                frmPrintPreview.LoadRequestADM(Me.lblReqNbr.Text, strReqType)
                frmPrintPreview.ShowDialog()
            Case "Preview As PURCHASE ORDER"
                Select Case Me.txtStatus.Text
                    Case "Open"
                        If Me.txtStatus.Text <> "Open" Then
                            MsgBox("Cannot print request. Request already " & Me.txtStatus.Text & "!", vbInformation, "System Message")
                            Exit Sub
                        End If

                        FillComboBox(frmPurchaseOrderDetails.cboTerms, "Select Description from lib_terms where Description Is Not null", "Description")
                        frmPurchaseOrderDetails.SearchPODetails(Me.lblReqNbr.Text)
                        'save to transactions logs
                        'SaveTransLogs("Print Purchase Order", Me.Name, "Request No.", Me.lblReqNbr.Text, strCurrentUser)
                        'save to translogs
                        SaveTransLogs("Print Purchase Order", Me.Name, "Request No.", Me.lblReqNbr.Text, strCurrentUser)
                        frmPurchaseOrderDetails.ShowDialog()
                    Case "Cancelled"
                        MsgBox("Record already Cancelled", vbInformation, "Cannot Print")
                        Exit Sub
                    Case "Liquidated"
                        MsgBox("Record already Liquidated", vbInformation, "Cannot Print")
                        Exit Sub
                    Case "Released"
                        MsgBox("Record already Released", vbInformation, "Cannot Print")
                        Exit Sub
                End Select
        End Select
    End Sub

    Private Sub btPayee_Click(sender As Object, e As EventArgs) Handles btPayee.Click
        frmManageVendor.Tag = "Request"
        frmManageVendor.ShowDialog()
    End Sub

    Public Function SearchRequest(ByVal str As String) As Boolean
        ClearEntries()
        SearchRequest = False
        Dim strSQL As String


        strSQL = "Select tbl_request.REQ_Nbr, tbl_request.REQ_ReqType, tbl_request.REQ_PayeeID, tbl_vendor.Description, lib_requestparams.ParamName, lib_requestparams_1.ParamName As ChargeName, tbl_request.REQ_DtNeed, tbl_request.REQ_Type, tbl_request.REQ_PlateNbr, tbl_request.REQ_ChargeID, tbl_request.REQ_ChargeTo, tbl_request.REQ_Remarks, tbl_request.REQ_TotalAmt, tbl_request.REQ_PrepDate, tbl_request.REQ_PrepBy, tbl_request.REQ_Cancel, tbl_request.REQ_Invoice, tbl_request.REQ_ModDate, tbl_request.REQ_ModBy, tbl_request.REQ_CompanyCode " &
                 "FROM ((tbl_request INNER JOIN lib_requestparams On tbl_request.REQ_Type = lib_requestparams.ParamCode) INNER JOIN lib_requestparams As lib_requestparams_1 On tbl_request.REQ_ChargeID = lib_requestparams_1.ParamCode) INNER JOIN tbl_vendor ON tbl_request.REQ_PayeeID = tbl_vendor.Code " &
                 "WHERE tbl_request.REQ_Nbr like  '" & str & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            If IsDBNull(reader.Item("REQ_Nbr")) = False Then
                SearchRequest = True
            End If

            Me.lblReqNbr.Text = reader.Item("REQ_Nbr")

            Select Case reader.Item("REQ_ReqType")
                Case 1
                    Me.optPettyCash.Checked = True
                    Me.optCheck.Checked = False
                    Me.optMC.Checked = False
                Case 2
                    Me.optPettyCash.Checked = False
                    Me.optCheck.Checked = True
                    Me.optMC.Checked = False
                Case 3
                    Me.optPettyCash.Checked = False
                    Me.optCheck.Checked = False
                    Me.optMC.Checked = True
            End Select

            Me.txtPayeeCode.Text = reader.Item("REQ_PayeeID")
            Me.txtPayeeName.Text = reader.Item("Description")
            Me.txtDateNeeded.Text = reader.Item("REQ_DtNeed")
            Me.dtReceipt.Value = reader.Item("REQ_DtNeed")
            Me.txtType.Text = reader.Item("REQ_Type")
            Me.cboType.Text = reader.Item("ParamName")
            Me.cboPlateNo.Text = IIf(IsDBNull(reader.Item("REQ_PlateNbr")), "", reader.Item("REQ_PlateNbr"))
            Me.cboChargeTo.Text = reader.Item("ChargeName")
            Me.txtChargeTo.Text = reader.Item("REQ_ChargeID")
            Me.txtChargeToName.Text = reader.Item("REQ_ChargeTo")
            Me.txtRemarks.Text = reader.Item("REQ_Remarks")

            Me.txtEncodedBy.Text = reader.Item("REQ_PrepBy")
            Me.txtDateEncoded.Text = reader.Item("REQ_PrepDate")
            Me.txtModifiedBy.Text = reader.Item("REQ_ModBy")
            Me.txtDateModified.Text = reader.Item("REQ_ModDate")

            If Not IsDBNull(reader.Item("REQ_Invoice")) Then
                Me.txtInvoice.Text = reader.Item("REQ_Invoice")
            Else
                txtInvoice.Text = ""
            End If

            If reader.Item("REQ_Cancel") = True Then
                txtStatus.Text = "Cancelled"
            Else
                txtStatus.Text = "Open"
            End If


            Me.txtCompanyCode.Text = reader.Item("REQ_CompanyCode")
        End While

        cmd.Dispose()
        reader.Close()

        PopulateItems(Me.dgDetails, Me.lblReqNbr.Text)


        'If PopulateAPVCHK(Me.lblCRNbr.Text) = True Or PopulateCVCHK(Me.lblCRNbr.Text) = True Then
        '    StatusStripTextBox.Text = "Posted"
        '    Me.tstripSave.Enabled = False
        '    Me.tStripPreview.Enabled = False
        '    Me.tstripNew.Enabled = True
        'End If

        'PopEditHistory(Me.dtgEditReason, Me.lblReqNbr.Text)

        cnnDBMaster.Close()

        Me.txtGrandTotal.Text = Format(SumAmount, "N2")
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Function

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        If Len(Me.txtRequestNo.Text) = 0 Then
            MsgBox("Nothing to Search!", vbInformation, "System Message")
            Exit Sub
        End If

        If SearchRequest(Me.txtRequestNo.Text) = False Then
            MsgBox("Record not found!", vbInformation, "System Message")
            Exit Sub
        End If
    End Sub

    Private Sub txtRequestNo_TextChanged(sender As Object, e As EventArgs) Handles txtRequestNo.TextChanged

    End Sub

    Private Sub txtRequestNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRequestNo.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            If SearchRequest(Me.txtRequestNo.Text) = False Then
                MsgBox("Record not found.", vbInformation, "Please double check request number")
                ClearEntries()
                Exit Sub
            End If
        End If
    End Sub


    Public Sub CancelRequest(ByVal str As String)
        Dim strsql As String

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        strsql = "UPDATE tbl_request SET REQ_Cancel = 1, REQ_CancelBy = @REQ_CancelBy, REQ_CancelDate = @REQ_CancelDate WHERE REQ_Nbr like '" & str & "'"

        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        With cmdsql.Parameters
            .AddWithValue("@REQ_CancelBy", strCurrentUser)
            .AddWithValue("@REQ_CancelDate", GetServerDate)
        End With

        cmdsql.ExecuteNonQuery()
        cmdsql.Dispose()
        cnnDBMaster.Close()
        'save to Transaction Logs
        SaveTransLogs("Cancel Request", Me.Name, "Request No.", Me.lblReqNbr.Text, strCurrentUser)
        Me.txtStatus.Text = "Cancelled"
        MsgBox("Record Cancelled.", vbInformation, "System Message")
    End Sub
End Class