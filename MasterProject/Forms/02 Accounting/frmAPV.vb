Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmAPV

    Implements ICommonFunction
    Private EnableButtons As New clsEnableToolstripObjects()
    Dim CVNo As String = ""
    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        Dim cmdSQL As New MySqlCommand
        Dim cmdSQL2 As New MySqlCommand

        If Len(Me.lblAPVNbr.Text) = 0 Then
            MsgBox("No AP Voucher selected!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_Cancel") = False Then
        '    MsgBox("You are not allowed to Cancel APV!", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If Len(Me.lblCancel.Text) > 0 Then
            MsgBox("Already Cancelled!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        'If checkFiscal(Me.lblAPVNbr.Text) = True Then
        ' MsgBox("Already closed! Cannot cancel APV!", MsgBoxStyle.Exclamation, "System Message")
        ' Exit Sub
        'End If

        If MsgBox("Are you sure you want to cancel AP Voucher " & Me.lblAPVNbr.Text, vbYesNo, "Confirm Cancel") = vbNo Then
            Exit Sub
        Else
            Dim dtCurrent As Date

            'script to get the current date of MYSQL Server
            dtCurrent = GetServerDate()

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim sSQL As String = "UPDATE  tbl_apv SET "
            sSQL += "APV_Cancel = @APV_Cancel, "
            sSQL += "APV_CancelDate = @APV_CancelDate, "
            sSQL += "APV_CancelBy = @APV_CancelBy "
            sSQL += "WHERE APV_Nbr = '" & Me.lblAPVNbr.Text & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters
                .AddWithValue("@APV_Cancel", True)
                .AddWithValue("@APV_CancelDate", dtCurrent)
                .AddWithValue("@APV_CancelBy", strCurrentUser)
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            Me.lblCancel.Text = "CANCELLED " & dtCurrent
            'save to transaction logs
            'SaveTransLogs("Cancel APV", Me.Name, "APV No.", Me.lblAPVNbr.Text, strCurrentUser)
            MsgBox("AP Voucher No. " & Me.lblAPVNbr.Text & " Cancelled", vbInformation, "System Message")
        End If
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord

    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If Len(Me.lblReqNbr.Text) = 0 Then
            MsgBox("Select Request No. first!", vbInformation, "System Message")
            Exit Sub
        End If

        If Len(lblAPVNbr.Text) > 0 Then
            MsgBox("This Check Request have AP Voucher already!", vbInformation, "System Message")
            Exit Sub
        End If

        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
        EditAcctgEntryButtonControl(True, True, True, False, False, False)
        Me.dgGLEntry.Rows.Clear()
        Me.dgEditHistory.Rows.Clear()
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
        ClearEntries()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If Format(SumAmount(10), "N2") <> Format(SumAmount(11), "N2") Then
            MsgBox("Debit / Credit Column not equal", vbInformation, "System Message")
            Exit Sub
        End If

        If MsgBox("Save this record?", vbYesNo, "Confirm Save") = vbNo Then

            Exit Sub
        Else
            SaveAPV()

            Dim strAPVNo As String = Me.lblAPVNbr.Text
            'ValidateSearch(Me.lblCRNbr.Text)
            PopulateAPVAccount(strAPVNo)
            Me.btAP.Enabled = False
        End If
    End Sub

    Public Sub SaveAPV()
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim dtCurrent As Date = GetServerDate()
        Dim strReqType As String = ""
        Dim cmdSQL As New MySqlCommand
        Dim apvNumber As String = "APV" & GetCtrlNbr(strCompanyCode, strSiteCode, "APV")

        If Me.optCheck.Checked = True Then
            strReqType = "Check"
        End If
        If Me.optMC.Checked = True Then
            strReqType = "MC"
        End If

        Dim sSQL As String

        sSQL = "INSERT INTO tbl_apv (APV_ReqNo, APV_Nbr, APV_PostBy, APV_PostDate, APV_Cancel, APV_Type) " &
                " VALUES (@APV_ReqNo, @APV_Nbr, @APV_PostBy, @APV_PostDate, @APV_Cancel, @APV_Type)"

        cmdSQL.CommandText = sSQL

        With cmdSQL.Parameters

            .AddWithValue("@APV_ReqNo", Me.lblReqNbr.Text)
            .AddWithValue("@APV_Nbr", apvNumber)
            .AddWithValue("@APV_PostBy", strCurrentUser)
            .AddWithValue("@APV_PostDate", dtCurrent)
            .AddWithValue("@APV_Cancel", False)
            .AddWithValue("@APV_Type", strReqType)

            Me.lblAPVNbr.Text = apvNumber
        End With

        cmdSQL.Connection = cnnDBMaster
        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()


        'Delete record in tbl_apvgl
        Dim cmdSysParam As MySqlCommand
        Dim sqlString1 As String = "DELETE FROM tbl_apvgl WHERE APVGL_APVNbr = '" & Me.lblAPVNbr.Text & "'"

        cmdSysParam = New MySqlCommand(sqlString1, cnnDBMaster)
        cmdSysParam.ExecuteNonQuery()
        cmdSysParam.Dispose()

        'save detail of apv account title
        Dim i As Integer
        Dim h As DataGridViewRow
        For i = 0 To Me.dgGLEntry.Rows.Count - 1
            Dim cmdSQLPart1 As New MySqlCommand

            cmdSQLPart1.Connection = cnnDBMaster

            h = Me.dgGLEntry.Rows(i)

            If Not Len(h.Cells(1).Value) = 0 Then
                cmdSQLPart1.CommandText = ("INSERT INTO tbl_apvgl (APVGL_Nbr, APVGL_Account_Code, APVGL_Account_Title, APVGL_DR, APVGL_CR, APVGL_APVNbr, APVGL_SubAccount_Code, APVGL_SubAccount_Title, APVGL_SubAccount_Dept, APVGL_SubAccount_DeptName, APVGL_SubAccount_List, APVGL_SubAccount_ListItem, APVGL_SubAccount_ListItemName)  VALUES " &
                                          "                   (@APVGL_Nbr, @APVGL_Account_Code, @APVGL_Account_Title, @APVGL_DR, @APVGL_CR, @APVGL_APVNbr, @APVGL_SubAccount_Code, @APVGL_SubAccount_Title, @APVGL_SubAccount_Dept, @APVGL_SubAccount_DeptName, @APVGL_SubAccount_List, @APVGL_SubAccount_ListItem, @APVGL_SubAccount_ListItemName)")

                With cmdSQLPart1.Parameters
                    .AddWithValue("@APVGL_Nbr", Me.lblReqNbr.Text)
                    .AddWithValue("@APVGL_Account_Code", h.Cells(1).Value)
                    .AddWithValue("@APVGL_Account_Title", h.Cells(2).Value)
                    .AddWithValue("@APVGL_SubAccount_Code", h.Cells(3).Value)
                    .AddWithValue("@APVGL_SubAccount_Title", h.Cells(4).Value)
                    .AddWithValue("@APVGL_SubAccount_Dept", h.Cells(5).Value)
                    .AddWithValue("@APVGL_SubAccount_DeptName", h.Cells(6).Value)
                    .AddWithValue("@APVGL_SubAccount_List", h.Cells(7).Value)
                    .AddWithValue("@APVGL_SubAccount_ListItem", h.Cells(8).Value)
                    .AddWithValue("@APVGL_SubAccount_ListItemName", h.Cells(9).Value)

                    If CStr(h.Cells(10).Value) <> "" Then
                        .AddWithValue("@APVGL_DR", CDbl(h.Cells(10).Value))
                    Else
                        .AddWithValue("@APVGL_DR", 0)
                    End If
                    If CStr(h.Cells(11).Value) <> "" Then
                        .AddWithValue("@APVGL_CR", CDbl(h.Cells(11).Value))
                    Else
                        .AddWithValue("@APVGL_CR", 0)
                    End If

                    .AddWithValue("@APVGL_APVNbr", apvNumber)

                End With

                cmdSQLPart1.ExecuteNonQuery()
            End If
            cmdSQLPart1.Dispose()
        Next
        cnnDBMaster.Close()
        cnnDBMaster.Dispose()
        UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "APV")
        'save to transaction logs
        'SaveTransLogs("Create APV", Me.Name, "APV No", Me.lblAPVNbr.Text, strCurrentUser)
        MsgBox("Done Saving. Record Posted", MsgBoxStyle.Information)
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord

    End Sub

    Private Sub frmAPV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtRequestNo.SetWaterMark("Enter Request No. here")
        EditAcctgEntryButtonControl(False, False, False, True, False, False)
        Me.cboReports.Items.Clear()

        Me.cboReports.Items.Add("Preview AP Voucher")
    End Sub

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

            'Me.btAddGLEntry.Enabled = blUserInput
            'Me.btRemoveGLEntry.Enabled = blUserInput
            'Me.btAP.Enabled = blUserInput
        End With
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
    Private Sub ClearEntries()
        Me.lblReqNbr.Text = ""
        Me.txtRequestNo.Text = ""
        Me.txtPayeeCode.Text = ""
        Me.txtPayeeName.Text = ""
        Me.txtInvoice.Text = ""
        Me.txtRemarks.Text = ""
        Me.txtDateNeeded.Text = ""
        Me.txtType.Text = ""
        'Me.txtType.Text = ""
        'Me.txtPONbr.Text = ""
        Me.txtChargeTo.Text = ""
        Me.txtChargeToName.Text = ""
        Me.dgDetails.Rows.Clear()
        Me.dgGLEntry.Rows.Clear()
        'Me.dtgEditReason.Rows.Clear()
        Me.txtGrandTotal.Text = "0"
        'Me.btnSelectPO.Enabled = False
        Me.txtEncodedBy.Text = ""
        Me.txtDateEncoded.Text = ""
        Me.txtModifiedBy.Text = ""
        Me.txtDateModified.Text = ""
    End Sub
    Public Function SearchRequest(ByVal str As String) As Boolean
        ClearEntries()
        SearchRequest = False
        Dim strSQL As String


        strSQL = "SELECT tbl_request.REQ_Nbr,  tbl_request.REQ_ReqType, tbl_request.REQ_PayeeID, tbl_vendor.Description,  lib_requestparams.ParamName, lib_requestparams_1.ParamName AS ChargeName, tbl_request.REQ_DtNeed, tbl_request.REQ_Type,   tbl_request.REQ_PlateNbr, tbl_request.REQ_ChargeID, tbl_request.REQ_ChargeTo, tbl_request.REQ_Remarks, tbl_request.REQ_TotalAmt, tbl_request.REQ_PrepDate, tbl_request.REQ_PrepBy, tbl_request.REQ_Cancel,  tbl_request.REQ_Invoice, tbl_request.REQ_ModDate, tbl_request.REQ_ModBy " &
                 "FROM ((tbl_request INNER JOIN lib_requestparams ON tbl_request.REQ_Type = lib_requestparams.ParamCode) INNER JOIN lib_requestparams AS lib_requestparams_1 ON tbl_request.REQ_ChargeID = lib_requestparams_1.ParamCode) INNER JOIN tbl_vendor ON tbl_request.REQ_PayeeID = tbl_vendor.Code " &
                 "WHERE tbl_request.REQ_Nbr = '" & str & " '"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            If IsDBNull(reader.Item("REQ_Nbr")) = False Then
                SearchRequest = True
            End If

            If reader.Item("REQ_Cancel") = True Then
                MsgBox("Request already Cancelled!", vbInformation, "Cannot continue")
                cmd.Dispose()
                reader.Close()
                cnnDBMaster.Close()
                ClearEntries()
                Exit Function
            End If

            Select Case reader.Item("REQ_ReqType")
                Case 1
                    MsgBox("Request type is Petty Cash!" & vbNewLine & "Request should be either Check or MC to proceed creation of APV", vbInformation, "System Message")
                    cmd.Dispose()
                    reader.Close()
                    cnnDBMaster.Close()
                    ClearEntries()
                    Exit Function
                Case 2
                    Me.optCheck.Checked = True
                    Me.optMC.Checked = False
                Case 3
                    Me.optCheck.Checked = False
                    Me.optMC.Checked = True
            End Select

            Me.lblReqNbr.Text = reader.Item("REQ_Nbr")
            Me.txtPayeeCode.Text = reader.Item("REQ_PayeeID")
            Me.txtPayeeName.Text = reader.Item("Description")
            Me.txtDateNeeded.Text = Format(reader.Item("REQ_DtNeed"), "yyyy-MM-dd hh:mm:ss")
            Me.txtType.Text = reader.Item("REQ_Type")
            Me.txtPlateNbr.Text = reader.Item("REQ_PlateNbr")
            Me.txtChargeToName.Text = reader.Item("REQ_ChargeTo")
            Me.txtChargeTo.Text = reader.Item("REQ_ChargeID")
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

        End While

        cmd.Dispose()
        reader.Close()

        PopulateItems(Me.dgDetails, Me.lblReqNbr.Text)

        cnnDBMaster.Close()

        Me.txtGrandTotal.Text = Format(SumAmount, "N2")

        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        PopulateAPVNo(Me.lblReqNbr.Text)
    End Function

    Private Sub PopulateAPVNo(ByVal strReqNo As String)
        Dim strSQL As String

        'Me.chkAllowEditAcctgEntry.Checked = False

        strSQL = "SELECT * " &
                 "FROM tbl_apv " &
                 "WHERE tbl_apv.APV_ReqNo = '" & strReqNo & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView
        dgGLEntry.Rows.Clear()
        DataGridView5.Rows.Clear()
        dgEditHistory.Rows.Clear()
        If reader2.HasRows = False Then
            cmd2.Dispose()
            reader2.Close()
            cnnDBMaster.Close()
            dgGLEntry.Rows.Clear()
            DataGridView5.Rows.Clear()
            dgEditHistory.Rows.Clear()
            Exit Sub
        End If
        While reader2.Read
            gridBook = Me.dtgAPVNo
            gridBook.Rows.Add(reader2.Item("APV_Nbr"), reader2.Item("APV_PostBy"), reader2.Item("APV_PostDate"), reader2.Item("APV_Cancel"))
            Me.chkAllowEditAcctgEntry.Checked = reader2.Item("APV_AllowEditAcctgEntry")
            Me.lblEdited.Text = reader2.Item("APV_NoEdited")
            i = i + 1
        End While

        cmd2.Dispose()
        reader2.Close()

        'editAcctgEntryButtonControl(False, False, False, True, False, False)


        For ctrRow As Integer = 0 To Me.dtgAPVNo.Rows.Count - 1
            With Me.dtgAPVNo.Rows(ctrRow)
                If .Cells("colCancel").Value = False Then
                    PopulateAPVAccount(.Cells(0).Value)
                    Exit For
                End If
            End With
        Next
    End Sub

    Public Sub PopulateAPVAccount(ByVal strAPVNo As String)
        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM tbl_apv INNER JOIN tbl_apvgl ON tbl_apv.APV_Nbr = tbl_apvgl.APVGL_APVNbr " &
                 "WHERE tbl_apv.APV_Nbr = '" & strAPVNo & "'"


        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView
        Dim gridBook2 As DataGridView
        dgGLEntry.Rows.Clear()
        DataGridView5.Rows.Clear()
        dgEditHistory.Rows.Clear()

        If reader2.HasRows = False Then
            cmd2.Dispose()
            reader2.Close()
            cnnDBMaster.Close()
            dgGLEntry.Rows.Clear()
            DataGridView5.Rows.Clear()
            dgEditHistory.Rows.Clear()
            Exit Sub
        End If
        While reader2.Read
            gridBook = Me.dgGLEntry
            gridBook2 = Me.DataGridView5
            Me.lblAPVNbr.Text = reader2.Item("APVGL_APVNbr")

            Me.txtStatPostBy.Text = reader2.Item("APV_PostBy")
            Me.txtStatPostDate.Text = Format(reader2.Item("APV_PostDate"), "yyyy-MM-dd hh:mm:ss")


            If reader2.Item("APV_Cancel") = True Then
                Me.lblCancel.Text = "CANCELLED " & reader2.Item("APV_CancelDate")
                Me.txtCancelBy.Text = reader2.Item("APV_CancelBy")
                Me.txtCancelDate.Text = Format(reader2.Item("APV_CancelDate"), "yyyy-MM-dd hh:mm:ss")
            Else
                Me.lblCancel.Text = ""
                Me.txtCancelBy.Text = ""
                Me.txtCancelDate.Text = ""
            End If

            gridBook.Rows.Add("", reader2.Item("APVGL_Account_Code"), reader2.Item("APVGL_Account_Title"), reader2.Item("APVGL_SubAccount_Code"), reader2.Item("APVGL_SubAccount_Title"), reader2.Item("APVGL_SubAccount_Dept"), reader2.Item("APVGL_SubAccount_DeptName"), reader2.Item("APVGL_SubAccount_List"), reader2.Item("APVGL_SubAccount_ListItem"), reader2.Item("APVGL_SubAccount_ListItemName"), reader2.Item("APVGL_DR"), reader2.Item("APVGL_CR"))
            gridBook2.Rows.Add("", reader2.Item("APVGL_Account_Code"), reader2.Item("APVGL_Account_Title"), reader2.Item("APVGL_SubAccount_Code"), reader2.Item("APVGL_SubAccount_Title"), reader2.Item("APVGL_SubAccount_Dept"), reader2.Item("APVGL_SubAccount_DeptName"), reader2.Item("APVGL_SubAccount_List"), reader2.Item("APVGL_SubAccount_ListItem"), reader2.Item("APVGL_SubAccount_ListItemName"), reader2.Item("APVGL_DR"), reader2.Item("APVGL_CR"))

            i = i + 1
        End While

        cmd2.Dispose()
        reader2.Close()


        'Populate Account Entry edit history
        Dim strSQL2 As String

        strSQL2 = "SELECT * " &
                 "FROM tbl_apv_acctgentryedithistoryd " &
                 "WHERE tbl_apv_acctgentryedithistoryd.CRAP_APVNbr = '" & strAPVNo & "'"


        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL2, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        Dim gridBook3 As DataGridView

        Me.dgEditHistory.Rows.Clear()

        While reader.Read
            gridBook3 = Me.dgEditHistory

            gridBook3.Rows.Add("", reader.Item("CRAP_Account_Code"), reader.Item("CRAP_Account_Title"), reader.Item("CRAP_SubAccount_Code"), reader.Item("CRAP_SubAccount_Title"), reader.Item("CRAP_SubAccount_Dept"), reader.Item("CRAP_SubAccount_DeptName"), reader.Item("CRAP_SubAccount_List"), reader.Item("CRAP_SubAccount_ListItem"), reader.Item("CRAP_SubAccount_ListItemName"), reader.Item("CRAP_DR"), reader.Item("CRAP_CR"), reader.Item("ModifiedBy"), reader.Item("DateModified"))

        End While

        cmd.Dispose()
        reader.Close()
        Me.lblDebit.Text = SumAmount(10)
        Me.lblCredit.Text = SumAmount(11)
    End Sub

    Public Function SumAmount(ByVal intIndex As Integer) As Double
        Dim i As Integer
        Dim h As DataGridViewRow

        For i = 0 To Me.dgGLEntry.Rows.Count - 1
            h = Me.dgGLEntry.Rows(i)
            If Not Len(h.Cells(intIndex).Value) = 0 Then
                SumAmount = SumAmount + h.Cells(intIndex).Value
            End If
        Next

        Return SumAmount
    End Function
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
                    dg.Rows.Add("", reader.Item("REQD_Particulars"), Format(reader.Item("REQD_Amount"), "n2"), reader.Item("REQD_BookNbr"), reader.Item("REQD_Shipper"), reader.Item("REQD_Consignee"), reader.Item("REQD_ContainerNo"), reader.Item("REQD_HBL"), reader.Item("REQD_Key"), IIf(IsDBNull(reader.Item("REQD_CHCode")), "", reader.Item("REQD_CHCode")), reader.Item("REQD_CostCenter"), Format(reader.Item("REQD_ReturnAmt"), "n2"), Format(reader.Item("REQD_RefundAmt"), "n2"), Format(reader.Item("REQD_LiquidatedAmt"), "n2"))
            End Select

        End While

        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub

    Private Sub SetColumnProp()
        Me.dgDetails.Columns.Clear()
        Me.dgDetails.Rows.Clear()
        Me.dgGLEntry.Columns.Clear()
        Me.dgGLEntry.Rows.Clear()
        Me.dgEditHistory.Columns.Clear()
        Me.dgEditHistory.Rows.Clear()
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

        Dim colBut2 As New DataGridViewButtonColumn
        Dim chkDept As New DataGridViewCheckBoxColumn
        Dim chkList As New DataGridViewCheckBoxColumn
        With Me.dgGLEntry
            With Me.dgGLEntry

                .Columns.Add(colBut2)
                .Columns.Add("", "Account Code")
                .Columns.Add("", "Account Title")
                .Columns.Add("", "Sub Code")
                .Columns.Add("", "Sub Account Title")
                .Columns.Add(chkDept)
                .Columns.Add("", "Department Name")
                .Columns.Add(chkList)
                .Columns.Add("", "List Item")
                .Columns.Add("", "List Item Name")
                .Columns.Add("", "DR")
                .Columns.Add("", "CR")
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = True
                .MultiSelect = False

            End With
            .Columns(0).Width = 25
            .Columns(1).Width = 75
            .Columns(2).Width = 250
            .Columns(3).Width = 25
            .Columns(4).Width = 250
            .Columns(5).Width = 25
            .Columns(6).Width = 75
            .Columns(7).Width = 25
            .Columns(8).Width = 75
            .Columns(9).Width = 250
            .Columns(10).Width = 100
            .Columns(11).Width = 100
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = True
            .Columns(7).ReadOnly = True
            .Columns(8).ReadOnly = True
            .Columns(9).ReadOnly = True
            .Columns(1).Frozen = True
            .Columns(2).Frozen = True
            .Columns(3).Frozen = True
            .Columns(4).Frozen = True
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        Dim colBut3 As New DataGridViewButtonColumn
        Dim chkDept3 As New DataGridViewCheckBoxColumn
        Dim chkList3 As New DataGridViewCheckBoxColumn
        With Me.DataGridView5
            With Me.DataGridView5

                .Columns.Add(colBut3)
                .Columns.Add("", "Account Code")
                .Columns.Add("", "Account Title")
                .Columns.Add("", "Sub Code")
                .Columns.Add("", "Sub Account Title")
                .Columns.Add(chkDept3)
                .Columns.Add("", "Department Name")
                .Columns.Add(chkList3)
                .Columns.Add("", "List Item")
                .Columns.Add("", "List Item Name")
                .Columns.Add("", "DR")
                .Columns.Add("", "CR")
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = True
                .MultiSelect = False

            End With
            .Columns(0).Width = 25
            .Columns(1).Width = 75
            .Columns(2).Width = 250
            .Columns(3).Width = 25
            .Columns(4).Width = 250
            .Columns(5).Width = 25
            .Columns(6).Width = 75
            .Columns(7).Width = 25
            .Columns(8).Width = 75
            .Columns(9).Width = 250
            .Columns(10).Width = 100
            .Columns(11).Width = 100
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = True
            .Columns(7).ReadOnly = True
            .Columns(8).ReadOnly = True
            .Columns(9).ReadOnly = True
            .Columns(1).Frozen = True
            .Columns(2).Frozen = True
            .Columns(3).Frozen = True
            .Columns(4).Frozen = True
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        Dim colButEditAcctEntry2 As New DataGridViewButtonColumn
        Dim chkDeptEditAcctEntry2 As New DataGridViewCheckBoxColumn
        Dim chkListEditAcctEntry2 As New DataGridViewCheckBoxColumn
        With Me.dgEditHistory
            With Me.dgEditHistory

                .Columns.Add(colButEditAcctEntry2)
                .Columns.Add("", "Account Code")
                .Columns.Add("", "Account Title")
                .Columns.Add("", "Sub Code")
                .Columns.Add("", "Sub Account Title")
                .Columns.Add(chkDeptEditAcctEntry2)
                .Columns.Add("", "Department Name")
                .Columns.Add(chkListEditAcctEntry2)
                .Columns.Add("", "List Item")
                .Columns.Add("", "List Item Name")
                .Columns.Add("", "DR")
                .Columns.Add("", "CR")
                .Columns.Add("", "ModifiedBy")
                .Columns.Add("", "DateModified")
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = True
                .MultiSelect = False

            End With
            .Columns(0).Width = 25
            .Columns(1).Width = 75
            .Columns(2).Width = 250
            .Columns(3).Width = 25
            .Columns(4).Width = 250
            .Columns(5).Width = 25
            .Columns(6).Width = 75
            .Columns(7).Width = 25
            .Columns(8).Width = 75
            .Columns(9).Width = 250
            .Columns(10).Width = 100
            .Columns(11).Width = 100
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = True
            .Columns(7).ReadOnly = True
            .Columns(8).ReadOnly = True
            .Columns(9).ReadOnly = True
            .Columns(1).Frozen = True
            .Columns(2).Frozen = True
            .Columns(3).Frozen = True
            .Columns(4).Frozen = True
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        Me.Refresh()
    End Sub

    Private Sub dtgAPVNo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAPVNo.CellContentClick

    End Sub

    Private Sub dtgAPVNo_Click(sender As Object, e As EventArgs) Handles dtgAPVNo.Click
        PopulateAPVAccount(Me.dtgAPVNo.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub btAddGLEntry_Click(sender As Object, e As EventArgs) Handles btAddGLEntry.Click
        Me.dgGLEntry.Rows.Add()
    End Sub

    Private Sub btRemoveGLEntry_Click(sender As Object, e As EventArgs) Handles btRemoveGLEntry.Click
        If Me.dgGLEntry.Rows.Count > 0 Then
            If Not dgGLEntry.CurrentRow.IsNewRow Then
                dgGLEntry.Rows.Remove(dgGLEntry.CurrentRow)
            End If
        End If
    End Sub

    Private Sub btAP_Click(sender As Object, e As EventArgs) Handles btAP.Click
        Me.dgGLEntry.Rows.Add()
        frmSelectAP.Tag = "APV"
        frmSelectAP.txtLineNbr.Text = Me.dgGLEntry.RowCount - 1
        frmSelectAP.ShowDialog()
        btAP.Enabled = False
    End Sub

    Private Sub txtAmtInWords_TextChanged(sender As Object, e As EventArgs) Handles txtAmtInWords.TextChanged

    End Sub

    Private Sub txtGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles txtGrandTotal.TextChanged
        If Not Len(Me.txtGrandTotal.Text) = 0 Then
            Me.txtAmtInWords.Text = English(Me.txtGrandTotal.Text)
        End If
    End Sub

    Private Sub dgGLEntry_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgGLEntry.CellContentClick
        If dgGLEntry.Columns(e.ColumnIndex).CellType.Equals(GetType(DataGridViewButtonCell)) Then
            frmSelectGLEntry.Tag = "APV"
            frmSelectGLEntry.txtLineNbr.Text = e.RowIndex
            frmSelectGLEntry.ShowDialog()
        End If
    End Sub

    Private Sub btEditAcctgEntry_Click(sender As Object, e As EventArgs) Handles btEditAcctgEntry.Click
        If Me.chkAllowEditAcctgEntry.Checked = False Then
            MsgBox("Not allowed to edit account entry! Pls. seek approval first to Authorized Accounting Personnel.", vbInformation, "System Message")
            Exit Sub
        End If
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_Edit_APVAcctgEntry") = False Then
        '    MsgBox("You are not allowed to edit APV Accounting Entry!", vbInformation, "System Message")
        '    Exit Sub
        'End If

        Me.dgGLEntry.Rows.Clear()
        lblDebit.Text = SumAmount(10)
        lblCredit.Text = SumAmount(11)
        EditAcctgEntryButtonControl(True, True, True, False, True, True)
    End Sub

    Public Sub EditAcctgEntryButtonControl(ByVal btAdd As Boolean, ByVal btRemove As Boolean, ByVal btAP As Boolean, ByVal EditAcctgEntry As Boolean, ByVal UpdateAcctgEntry As Boolean, ByVal ResetAcctgEntry As Boolean)
        Me.btAddGLEntry.Enabled = btAdd
        Me.btRemoveGLEntry.Enabled = btRemove
        Me.btAP.Enabled = btAP
        Me.btEditAcctgEntry.Enabled = EditAcctgEntry
        Me.btResetAcctgEntry.Enabled = ResetAcctgEntry
        Me.btUpdateAcctgEntry.Enabled = UpdateAcctgEntry
    End Sub

    Private Sub btUpdateAcctgEntry_Click(sender As Object, e As EventArgs) Handles btUpdateAcctgEntry.Click

        If Format(SumAmount(10), "N2") <> Format(SumAmount(11), "N2") Then
            MsgBox("Debit / Credit Column not equal", vbInformation, "System Message")
            Exit Sub
        End If

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        'Delete record in ap_crap 
        Dim cmdSysParam As MySqlCommand
        Dim sqlString1 As String = "DELETE FROM tbl_apvgl WHERE APVGL_APVNbr = '" & Me.lblAPVNbr.Text & "'"

        cmdSysParam = New MySqlCommand(sqlString1, cnnDBMaster)
        cmdSysParam.ExecuteNonQuery()
        cmdSysParam.Dispose()

        'save detail of apv account title
        Dim i As Integer
        Dim h As DataGridViewRow
        For i = 0 To Me.dgGLEntry.Rows.Count - 1
            Dim cmdSQLPart1 As New MySqlCommand

            cmdSQLPart1.Connection = cnnDBMaster

            h = Me.dgGLEntry.Rows(i)

            If Not Len(h.Cells(1).Value) = 0 Then
                cmdSQLPart1.CommandText = ("INSERT INTO tbl_apvgl (APVGL_Nbr, APVGL_Account_Code, APVGL_Account_Title, APVGL_DR, APVGL_CR, APVGL_APVNbr, APVGL_SubAccount_Code, APVGL_SubAccount_Title, APVGL_SubAccount_Dept, APVGL_SubAccount_DeptName, APVGL_SubAccount_List, APVGL_SubAccount_ListItem, APVGL_SubAccount_ListItemName)  VALUES " &
                                          "                   (@APVGL_Nbr, @APVGL_Account_Code, @APVGL_Account_Title, @APVGL_DR, @APVGL_CR, @APVGL_APVNbr, @APVGL_SubAccount_Code, @APVGL_SubAccount_Title, @APVGL_SubAccount_Dept, @APVGL_SubAccount_DeptName, @APVGL_SubAccount_List, @APVGL_SubAccount_ListItem, @APVGL_SubAccount_ListItemName)")

                With cmdSQLPart1.Parameters
                    .AddWithValue("@APVGL_Nbr", lblReqNbr.Text)
                    .AddWithValue("@APVGL_Account_Code", h.Cells(1).Value)
                    .AddWithValue("@APVGL_Account_Title", h.Cells(2).Value)
                    .AddWithValue("@APVGL_SubAccount_Code", h.Cells(3).Value)
                    .AddWithValue("@APVGL_SubAccount_Title", h.Cells(4).Value)
                    .AddWithValue("@APVGL_SubAccount_Dept", h.Cells(5).Value)
                    .AddWithValue("@APVGL_SubAccount_DeptName", h.Cells(6).Value)
                    .AddWithValue("@APVGL_SubAccount_List", h.Cells(7).Value)
                    .AddWithValue("@APVGL_SubAccount_ListItem", h.Cells(8).Value)
                    .AddWithValue("@APVGL_SubAccount_ListItemName", h.Cells(9).Value)

                    If CStr(h.Cells(10).Value) <> "" Then
                        .AddWithValue("@APVGL_DR", CDbl(h.Cells(10).Value))
                    Else
                        .AddWithValue("@APVGL_DR", 0)
                    End If
                    If CStr(h.Cells(11).Value) <> "" Then
                        .AddWithValue("@APVGL_CR", CDbl(h.Cells(11).Value))
                    Else
                        .AddWithValue("@APVGL_CR", 0)
                    End If

                    .AddWithValue("@APVGL_APVNbr", Me.lblAPVNbr.Text)

                End With

                cmdSQLPart1.ExecuteNonQuery()
            End If
            cmdSQLPart1.Dispose()
        Next


        cnnDBMaster.Dispose()
        cnnDBMaster.Close()

        SaveAcctgEntryHistory(Me.DataGridView5)
        SaveNoOfTimesEdited(Me.lblAPVNbr.Text, Me.lblEdited.Text)

        PopulateAPVNo(Me.lblReqNbr.Text)
        PopulateAPVAccount(Me.lblAPVNbr.Text)
        MsgBox("Record Updated", MsgBoxStyle.Information, "System Message")
    End Sub

    Public Sub SaveNoOfTimesEdited(ByVal str As String, ByVal intEdited As Integer)
        Dim strsql As String
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        strsql = "UPDATE tbl_apv SET " &
                    "APV_AllowEditAcctgEntry = @APV_AllowEditAcctgEntry, " &
                    "APV_NoEdited = @APV_NoEdited " &
                "WHERE APV_Nbr = '" & Me.lblAPVNbr.Text & "'"

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@APV_AllowEditAcctgEntry", 0)
            .AddWithValue("@APV_NoEdited", intEdited + 1)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
        cnnDBMaster.Close()
    End Sub

    Public Sub SaveAcctgEntryHistory(ByVal dg As DataGridView)
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        'save history of apv account title
        Dim i As Integer
        Dim h As DataGridViewRow
        Dim dtCurrent As Date = GetServerDate()
        For i = 0 To dg.Rows.Count - 1
            Dim cmdSQLPart1 As New MySqlCommand

            cmdSQLPart1.Connection = cnnDBMaster

            h = dg.Rows(i)

            If Not Len(h.Cells(1).Value) = 0 Then
                cmdSQLPart1.CommandText = ("INSERT INTO tbl_apv_acctgentryedithistoryd (CRAP_Nbr, CRAP_Account_Code, CRAP_Account_Title, CRAP_DR, CRAP_CR, CRAP_APVNbr, CRAP_SubAccount_Code, CRAP_SubAccount_Title, CRAP_SubAccount_Dept, CRAP_SubAccount_DeptName, CRAP_SubAccount_List, CRAP_SubAccount_ListItem, CRAP_SubAccount_ListItemName, DateModified, ModifiedBy)  VALUES " &
                                          "                   (@CRAP_Nbr, @CRAP_Account_Code, @CRAP_Account_Title, @CRAP_DR, @CRAP_CR, @CRAP_APVNbr, @CRAP_SubAccount_Code, @CRAP_SubAccount_Title, @CRAP_SubAccount_Dept, @CRAP_SubAccount_DeptName, @CRAP_SubAccount_List, @CRAP_SubAccount_ListItem, @CRAP_SubAccount_ListItemName, @DateModified, @ModifiedBy)")

                With cmdSQLPart1.Parameters
                    .AddWithValue("@CRAP_Nbr", lblReqNbr.Text)
                    .AddWithValue("@CRAP_Account_Code", h.Cells(1).Value)
                    .AddWithValue("@CRAP_Account_Title", h.Cells(2).Value)
                    .AddWithValue("@CRAP_SubAccount_Code", h.Cells(3).Value)
                    .AddWithValue("@CRAP_SubAccount_Title", h.Cells(4).Value)
                    .AddWithValue("@CRAP_SubAccount_Dept", h.Cells(5).Value)
                    .AddWithValue("@CRAP_SubAccount_DeptName", h.Cells(6).Value)
                    .AddWithValue("@CRAP_SubAccount_List", h.Cells(7).Value)
                    .AddWithValue("@CRAP_SubAccount_ListItem", h.Cells(8).Value)
                    .AddWithValue("@CRAP_SubAccount_ListItemName", h.Cells(9).Value)

                    If CStr(h.Cells(10).Value) <> "" Then
                        .AddWithValue("@CRAP_DR", CDbl(h.Cells(10).Value))
                    Else
                        .AddWithValue("@CRAP_DR", 0)
                    End If
                    If CStr(h.Cells(11).Value) <> "" Then
                        .AddWithValue("@CRAP_CR", CDbl(h.Cells(11).Value))
                    Else
                        .AddWithValue("@CRAP_CR", 0)
                    End If

                    .AddWithValue("@CRAP_APVNbr", Me.lblAPVNbr.Text)
                    .AddWithValue("@DateModified", dtCurrent)
                    .AddWithValue("@ModifiedBy", CurrentUser)
                End With

                cmdSQLPart1.ExecuteNonQuery()
            End If
            cmdSQLPart1.Dispose()
        Next


        cnnDBMaster.Dispose()
        cnnDBMaster.Close()
    End Sub

    Private Sub btResetAcctgEntry_Click(sender As Object, e As EventArgs) Handles btResetAcctgEntry.Click
        PopulateAPVAccount(Me.lblAPVNbr.Text)
        lblDebit.Text = SumAmount(10)
        lblCredit.Text = SumAmount(11)
        EditAcctgEntryButtonControl(False, False, False, True, False, False)
    End Sub
    Public Function CheckIfCVCreated(ByVal strAPV As String) As Boolean
        Dim strSQL As String
        CVNo = ""

        strSQL = "SELECT * " &
                 "FROM tbl_cvp INNER JOIN tbl_cv ON tbl_cvp.CVNo = tbl_cv.CVNo " &
                 "WHERE tbl_cvp.APVNo = '" & strAPV & "' and tbl_cv.Cancelled = false "


        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        If reader2.HasRows = True Then

            While reader2.Read
                CVNo = reader2.Item("CVNo")
            End While

            CheckIfCVCreated = True
            cmd2.Dispose()
            reader2.Close()
            cnnDBMaster.Close()
            Exit Function
        End If

        cmd2.Dispose()
        reader2.Close()
        cnnDBMaster.Close()


        CheckIfCVCreated = False
    End Function
    Private Sub btAllowEditAcctgEntry_Click(sender As Object, e As EventArgs) Handles btAllowEditAcctgEntry.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_ApproveEdit_APVAcctgEntry") = False Then
        '    MsgBox("You are not allowed to Approve editing of APV Accounting Entry!", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If Len(Me.lblAPVNbr.Text) = 0 Then
            MsgBox("Nothing to Edit!", vbInformation, "System Message")
            Exit Sub
        End If

        Dim strEdit As String = ""
        Dim boolEdit As Boolean

        If Me.chkAllowEditAcctgEntry.Checked = True Then
            strEdit = "disallow"
            boolEdit = False
        Else
            If CheckIfCVCreated(Me.lblAPVNbr.Text) = True Then
                MsgBox("Cannot continue! APV already has CV which must be cancelled first to proceed editing. CV No.: " & CVNo & "", vbInformation, "System Message")
                Exit Sub
            End If
            strEdit = "allow"
            boolEdit = True
        End If

        If MsgBox("Are you sure you want to " & strEdit & " edit account entry?", vbYesNo, "Confirm") = vbNo Then
            Exit Sub
        Else
            Dim dtCurrent As Date = GetServerDate()
            Dim strsql As String
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            strsql = "UPDATE tbl_apv SET " &
                    "APV_AllowEditAcctgEntry = @APV_AllowEditAcctgEntry " &
                    "WHERE APV_Nbr = '" & Me.lblAPVNbr.Text & "'"

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

            With cmdSQL.Parameters
                .AddWithValue("@APV_AllowEditAcctgEntry", boolEdit)
            End With

            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            SaveApproveEditAPVAccountEntry(Me.lblAPVNbr.Text, boolEdit)

            MsgBox("APV Number " & Me.lblAPVNbr.Text & " Account Entry " & strEdit & " to edit!", MsgBoxStyle.Information, "System Message")
            PopulateAPVNo(Me.lblReqNbr.Text)
            PopulateAPVAccount(Me.lblAPVNbr.Text)
            EditAcctgEntryButtonControl(False, False, False, True, False, False)
        End If
    End Sub
    Public Sub SaveApproveEditAPVAccountEntry(ByVal str As String, ByVal boolEdit As Boolean)
        Dim dtCurrent As Date = GetServerDate()
        Dim cmdSQLPart1 As New MySqlCommand

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        cmdSQLPart1.Connection = cnnDBMaster

        cmdSQLPart1.CommandText = ("INSERT INTO tbl_apv_acctgentryeditapproval (APV_Nbr, ApprovedBy, ApprovedDate, Allow)  VALUES " &
                                  "                   (@APV_Nbr, @ApprovedBy, @ApprovedDate, @Allow)")

        With cmdSQLPart1.Parameters
            .AddWithValue("@APV_Nbr", str)
            .AddWithValue("@ApprovedBy", strCurrentUser)
            .AddWithValue("@ApprovedDate", dtCurrent)
            .AddWithValue("@Allow", boolEdit)
        End With

        cmdSQLPart1.ExecuteNonQuery()

        cmdSQLPart1.Dispose()
        cnnDBMaster.Close()
        cnnDBMaster.Dispose()
    End Sub

    Private Sub dgGLEntry_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgGLEntry.CellEndEdit
        lblDebit.Text = SumAmount(10)
        lblCredit.Text = SumAmount(11)
    End Sub

    Private Sub cboReports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReports.SelectedIndexChanged
        If Me.cboReports.SelectedIndex = -1 Then Exit Sub

        Select Case Me.cboReports.Text
            Case "Preview AP Voucher"
                'save to transaction logs
                SaveTransLogs("Print AP Voucher", Me.Name, "APV No.", Me.lblAPVNbr.Text, strCurrentUser)
                frmPrintPreview.LoadAPV()
                frmPrintPreview.ShowDialog()
        End Select
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub
End Class