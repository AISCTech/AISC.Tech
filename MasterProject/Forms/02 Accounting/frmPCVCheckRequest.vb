Imports MySql.Data.MySqlClient
Public Class frmPCVCheckRequest
    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub txtGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles txtGrandTotal.TextChanged
        If Not Len(Me.txtGrandTotal.Text) = 0 Then
            Me.txtAmtInWords.Text = English(Me.txtGrandTotal.Text)
        End If
    End Sub

    Private Sub dtReceipt_ValueChanged(sender As Object, e As EventArgs) Handles dtReceipt.ValueChanged
        Me.txtDateNeeded.Text = Format(Me.dtReceipt.Value, "yyyy-MM-dd")
    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If CheckForRequiredEntries() = False Then
            Exit Sub
        End If

        If MsgBox("Save this record?", vbYesNo, "Confirm Save") = vbNo Then

            Exit Sub
        Else

            SaveRequest()
            frmReportReplenish.ShowDialog()
        End If
    End Sub
    Private Sub SaveRequest()
        Dim cmdSQL As New MySqlCommand
        Dim ChargeID As String
        Dim ChargeTo As String
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Try
            Dim dtCurrent As Date = GetServerDate()


            ChargeID = "AIS"
            ChargeTo = "Acestar"

            cmdSQL.CommandText = ("INSERT INTO tbl_request (`REQ_Nbr`, `REQ_ReqType`, `REQ_PayeeID`, `REQ_DtNeed`, `REQ_Type`, `REQ_ChargeID`, `REQ_ChargeTo`, `REQ_Remarks`, `REQ_TotalAmt`, `REQ_PrepDate`, `REQ_PrepBy`, `REQ_Cancel`, `REQ_Invoice`, `REQ_BranchCode`, `REQ_PCRequest`, `REQ_ModBy`, `REQ_ModDate`)  VALUES " &
                                 "               (@REQ_Nbr, @REQ_ReqType, @REQ_PayeeID, @REQ_DtNeed, @REQ_Type, @REQ_ChargeID, @REQ_ChargeTo, @REQ_Remarks, @REQ_TotalAmt, @REQ_PrepDate, @REQ_PrepBy, @REQ_Cancel, @REQ_Invoice, @REQ_BranchCode, @REQ_PCRequest, @REQ_ModBy, @REQ_ModDate)")

            With cmdSQL.Parameters
                Dim strReqNbr As String = "R" & GetCtrlNbr(strCompanyCode, strSiteCode, "Request_for_Payment")

                If Len(strReqNbr) = 0 Then
                    MsgBox("Error getting request number.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                .AddWithValue("@REQ_Nbr", strReqNbr)
                .AddWithValue("@REQ_ReqType", 2)
                .AddWithValue("@REQ_PayeeID", Me.txtPayeeCode.Text)
                .AddWithValue("@REQ_DtNeed", Me.dtReceipt.Value)
                .AddWithValue("@REQ_Type", "ADM")
                .AddWithValue("@REQ_ChargeID", ChargeID)
                .AddWithValue("@REQ_ChargeTo", ChargeTo)
                .AddWithValue("@REQ_Remarks", Me.txtRemarks.Text)
                .AddWithValue("@REQ_TotalAmt", CDbl(Me.txtGrandTotal.Text))
                .AddWithValue("@REQ_PrepDate", dtCurrent)
                .AddWithValue("@REQ_PrepBy", strCurrentUser)
                .AddWithValue("@REQ_Cancel", 0)
                .AddWithValue("@REQ_Invoice", Me.txtInvoice.Text)
                .AddWithValue("@REQ_BranchCode", frmPettyCashReplenishment.txtBranchCode.Text)
                .AddWithValue("@REQ_PCRequest", 1)
                .AddWithValue("@REQ_ModBy", strCurrentUser)
                .AddWithValue("@REQ_ModDate", dtCurrent)

                Me.lblReqNbr.Text = strReqNbr
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

        Catch ex As Exception
            MsgBox("There was an error trying to save the record - " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        'Delete record in tbl_requestd
        Dim cmdSysParam As MySqlCommand
        Dim sqlString2 As String = "DELETE FROM tbl_requestd WHERE REQD_REQNbr = '" & Me.lblReqNbr.Text & "'"

        cmdSysParam = New MySqlCommand(sqlString2, cnnDBMaster)
        cmdSysParam.ExecuteNonQuery()

        cmdSysParam.Dispose()

        'save detail of payments

        Dim cmdSQLPart1 As New MySqlCommand
        Dim Particulars As String
        cmdSQLPart1.Connection = cnnDBMaster
        Particulars = "PCF Replenishment " & Me.txtInvoice.Text & ""

        cmdSQLPart1.CommandText = ("INSERT INTO tbl_requestd (REQD_REQNbr, REQD_Particulars, REQD_Amount, REQD_Index, REQD_CostCenter)  VALUES " &
                                   "                   (@REQD_REQNbr, @REQD_Particulars, @REQD_Amount, @REQD_Index, @REQD_CostCenter)")

        With cmdSQLPart1.Parameters
            .AddWithValue("@REQD_REQNbr", Me.lblReqNbr.Text)
            .AddWithValue("@REQD_Particulars", Particulars)
            .AddWithValue("@REQD_Amount", CDbl(txtGrandTotal.Text))
            .AddWithValue("@REQD_Index", "0")
            .AddWithValue("@REQD_CostCenter", "ADM")
        End With

        cmdSQLPart1.ExecuteNonQuery()
        cmdSQLPart1.Dispose()

        cnnDBMaster.Close()
        cnnDBMaster.Dispose()


        UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "Request_for_Payment")

        MsgBox("Done Saving.", MsgBoxStyle.Information, "System Message")

        frmPettyCashReplenishment.txtCRNbr.Text = lblReqNbr.Text
        UpdateReplenishment()
        btSave.Enabled = False
        dtReceipt.Visible = False
        frmPrintPreview.LoadRequestADM(Me.lblReqNbr.Text, "Check")
        frmPrintPreview.ShowDialog()
    End Sub

    Private Sub UpdateReplenishment()
        Dim cmdSql As New MySqlCommand
        Dim dtCurrent As Date = GetServerDate()

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim sSQL As String = "UPDATE  tbl_pcv_replenish SET "

        sSQL += " CRNbr=@CRNbr "

        sSQL += " WHERE RepNumber= '" & Me.txtInvoice.Text & "'"
        cmdSql.CommandText = sSQL

        With cmdSql.Parameters
            .AddWithValue("@CRNbr", Me.lblReqNbr.Text)
        End With

        cmdSql.Connection = cnnDBMaster
        cmdSql.ExecuteNonQuery()
        cmdSql.Dispose()
        cnnDBMaster.Dispose()
        cnnDBMaster.Close()
    End Sub
    Private Function CheckForRequiredEntries() As Boolean
        'check if payee 
        If Len(txtPayeeCode.Text) = 0 Then
            MsgBox("Please select payee.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Not IsDate(Me.txtDateNeeded.Text) Then
            MsgBox("Please select Date Needed. ", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(txtRemarks.Text) = 0 Then
            MsgBox("Please type remarks.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If


        CheckForRequiredEntries = True

    End Function

    Private Sub btPayee_Click(sender As Object, e As EventArgs) Handles btPayee.Click
        frmManageVendor.Tag = "PCV Check Request"
        frmManageVendor.ShowDialog()
    End Sub

    Private Sub btPrintPreview_Click(sender As Object, e As EventArgs)


    End Sub
End Class