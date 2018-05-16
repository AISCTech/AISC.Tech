Public Class frmCreateVoucher
    Private Sub optReqNo_CheckedChanged(sender As Object, e As EventArgs) Handles optReqNo.CheckedChanged

    End Sub

    Private Sub optReqNo_Click(sender As Object, e As EventArgs) Handles optReqNo.Click
        'GeneratePrefix()

        If Me.optReqNo.Checked = True Then
            Me.optFull.Checked = True
            Me.optPartial.Enabled = False
            Me.txtVoucherAmt.Enabled = False
        Else
            Me.optPartial.Enabled = True
            Me.txtVoucherAmt.Enabled = True
        End If

        If Len(Me.lblPrefix.Text) > 0 Then
            Me.txtRefNo.Focus()
        End If
    End Sub

    Private Sub optAPVNo_CheckedChanged(sender As Object, e As EventArgs) Handles optAPVNo.CheckedChanged

    End Sub

    Private Sub optAPVNo_Click(sender As Object, e As EventArgs) Handles optAPVNo.Click
        If Len(Me.lblPrefix.Text) > 0 Then
            Me.txtRefNo.Focus()
        End If
    End Sub

    Private Sub txtRefNo_TextChanged(sender As Object, e As EventArgs) Handles txtRefNo.TextChanged

    End Sub

    Private Sub txtRefNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRefNo.KeyPress
        If Me.cmdSelect.Enabled = True Then
            If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
                'cmdSelect_Click(sender, e)
            End If
        End If
    End Sub

    Private Function CheckIfRefNoAlreadyAdded(ByVal strRefNo As String) As Boolean
        CheckIfRefNoAlreadyAdded = False
        For ctrRow As Integer = 0 To Me.dtgRefNo.Rows.Count - 1
            With Me.dtgRefNo.Rows(ctrRow)
                If strRefNo = .Cells("colRefNo").Value Then
                    MsgBox("Reference No. " & strRefNo & " already included!", MsgBoxStyle.Information, "System Message")
                    CheckIfRefNoAlreadyAdded = True
                    Exit Function
                Else
                    CheckIfRefNoAlreadyAdded = False
                End If
            End With
        Next

        For ctrRow = 0 To frmCV.dtgParticulars.Rows.Count - 1
            With frmCV.dtgParticulars.Rows(ctrRow)
                If strRefNo = .Cells("colReqNo").Value Then
                    MsgBox("Reference No. " & strRefNo & " already included!", MsgBoxStyle.Information, "System Message")
                    CheckIfRefNoAlreadyAdded = True
                    Exit Function
                Else
                    CheckIfRefNoAlreadyAdded = False
                End If
            End With
        Next
        'End If
    End Function

    'Private Sub cmdSelect_Click(sender As Object, e As EventArgs) Handles cmdSelect.Click
    '    If CheckIfRefNoAlreadyAdded(Me.txtRefNo.Text) = True Then Exit Sub

    '    If Me.optPartial.Checked = True And Len(Me.txtVoucherAmt.Text) = 0 Then
    '        MsgBox("Please enter Voucher Amount!", MsgBoxStyle.Exclamation, "System Message")
    '        Me.txtVoucherAmt.Focus()
    '        Exit Sub
    '    End If

    '    Select Case Me.Tag
    '        Case "CV"
    '            If Me.optReqNo.Checked = True Then
    '                If CheckRequestStatus(Me.txtRefNo.Text) = False Then Exit Sub
    '                'If CheckChkBookingStatus(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
    '                If CheckIfRequestHasAP(Me.lblPrefix.Text & Me.txtRefNo.Text) = True Then Exit Sub
    '                'If CheckCRIfAccrual(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
    '                If SelectCRNo(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
    '            Else
    '                If Me.optAPVNo.Checked = True Then
    '                    If SelectAPVNo(Me.txtRefNo.Text) = False Then Exit Sub
    '                Else
    '                    MsgBox("Select if by Request No. or APV No.", MsgBoxStyle.Exclamation, "System Message")
    '                    Exit Sub
    '                End If
    '            End If
    '    End Select

    '    Me.txtRefNo.Text = ""
    '    Me.txtVoucherAmt.Text = ""
    'End Sub

    Private Function SelectAPVNo(ByVal strRefNo As String) As Boolean
        SelectAPVNo = True
        Dim blFull As Boolean, strReqNo As String = "", acctcode As String = ""

        If Me.optPartial.Checked = True Then
            blFull = False
        ElseIf Me.optFull.Checked = True Then
            blFull = True
        End If

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim strsql As String = "SELECT tbl_apv.APV_Nbr, tbl_apv.APV_Cancel, tbl_apvgl.APVGL_CR, tbl_apvgl.APVGL_Account_Code, " &
                                "tbl_request.REQ_Nbr, tbl_request.REQ_PayeeID, tbl_request.REQ_DtNeed, tbl_vendor.VendorName, tbl_request.REQ_CompanyCode " &
                                "FROM (((tbl_apv INNER JOIN tbl_apvgl ON tbl_apv.APV_Nbr = tbl_apvgl.APVGL_APVNbr) " &
                                "INNER JOIN tbl_request ON tbl_apv.APV_ReqNo = tbl_request.REQ_Nbr) " &
                                "INNER JOIN tbl_vendor ON tbl_request.REQ_PayeeID = tbl_vendor.VendorID) " &
                                "WHERE tbl_apv.APV_Nbr = '" & strRefNo & "' " &
                                "AND (tbl_apvgl.APVGL_Account_Code = '2010' OR tbl_apvgl.APVGL_Account_Code = '6250') " &
                                "AND tbl_apvgl.APVGL_CR > 0"

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        If reader.HasRows = False Then
            MsgBox("APV No. not found!", MsgBoxStyle.Information, "System message")
            SelectAPVNo = False
        Else
            While reader.Read
                strReqNo = reader.Item("REQ_Nbr")
            End While
            reader.Close()

            If CheckRequestStatus(strReqNo) = False Then Exit Function
            'If CheckChkBookingStatus(strReqNo) = False Then Exit Function

            'Dim dblBal As Double = GetBalance(strReqNo, "SELECT CRAP_CR FROM ap_crap WHERE CRAP_APVNbr = '" & strRefNo & "' AND (ap_crap.CRAP_Account_Code = '2010' OR ap_crap.CRAP_Account_Code = '6250') AND ap_crap.CRAP_CR > 0", "CRAP_CR")

            reader = cmdSQL.ExecuteReader

            While reader.Read
                acctcode = reader.Item("APVGL_Account_Code")
                Dim dblBal As Double = GetBalance(strReqNo, "SELECT APVGL_CR FROM tbl_apvgl INNER JOIN tbl_apv ON tbl_apvgl.APVGL_APVNbr = tbl_apv.APV_Nbr WHERE tbl_apvgl.APVGL_APVNbr = '" & strRefNo & "' AND tbl_apvgl.APVGL_Account_Code like '" & acctcode & "'  AND tbl_apvgl.APVGL_CR > 0 AND tbl_apv.APV_Cancel = 0", "APVGL_CR")

                If reader.Item("APV_Cancel") = True Then
                    MsgBox("Reference No. " & strRefNo & " is Cancelled!", MsgBoxStyle.Information, "System message")
                    SelectAPVNo = False
                    reader.Close()
                    cmdSQL.Dispose()
                    Exit Function
                End If

                If Len(Me.txtPayeeID.Text) > 0 Then
                    If Me.txtPayeeID.Text <> reader.Item("REQ_PayeeID") Then
                        MsgBox("Reference No. " & strRefNo & " has a different Payee!", MsgBoxStyle.Information, "System message")
                        SelectAPVNo = False
                        reader.Close()
                        cmdSQL.Dispose()
                        Exit Function
                    End If
                End If

                If Len(Me.txtDateNeeded.Text) > 0 Then
                    If Me.txtDateNeeded.Text <> CDate(reader.Item("REQ_DtNeed")).Date Then
                        MsgBox("Reference No. " & strRefNo & " has a date needed!", MsgBoxStyle.Information, "System message")
                        reader.Close()
                        cmdSQL.Dispose()
                        SelectAPVNo = False
                        Exit Function
                    End If
                End If

                Me.txtDateNeeded.Text = CDate(reader.Item("REQ_DtNeed")).Date
                Me.txtPayeeID.Text = reader.Item("REQ_PayeeID")
                Me.txtPayeeName.Text = reader.Item("VendorName")
                If blFull = True Then
                    If dblBal = 0 Then
                        MsgBox("AP Voucher No. " & reader.Item("APV_Nbr") & " remaining amount is " & Format(CDbl(dblBal), "n2") & "!", MsgBoxStyle.Exclamation, "System Message")
                        SelectAPVNo = False
                    Else
                        Me.dtgRefNo.Rows.Add(reader.Item("APV_Nbr"), reader.Item("VendorName"), reader.Item("REQ_DtNeed"), Format(reader.Item("APVGL_CR"), "n2"), Format(dblBal, "n2"), True, IIf(reader.Item("APVGL_CR") = dblBal, blFull, False), reader.Item("REQ_CompanyCode"))
                    End If
                Else
                    If CDbl(Me.txtVoucherAmt.Text) > dblBal Then
                        MsgBox("AP Voucher No. " & reader.Item("APV_Nbr") & " remaining amount is " & Format(CDbl(dblBal), "n2") & "!", MsgBoxStyle.Exclamation, "System Message")
                        SelectAPVNo = False
                    Else
                        Me.dtgRefNo.Rows.Add(reader.Item("APV_Nbr"), reader.Item("VendorName"), reader.Item("REQ_DtNeed"), Format(reader.Item("APVGL_CR"), "n2"), Format(CDbl(Me.txtVoucherAmt.Text), "n2"), True, blFull, reader.Item("REQ_CompanyCode"))
                    End If
                End If
            End While
        End If

        reader.Close()
        cmdSQL.Dispose()
    End Function

    Private Function GetBalance(ByVal strReqNo As String, ByVal strSQL As String, ByVal strField As String) As Double
        Dim dblReqAmt As Double = 0, dblCVAmt As Double = 0, strSQL2 As String
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            dblReqAmt = reader.Item(strField)
        End While

        reader.Close()
        cmdSQL.Dispose()



        strSQL2 = "SELECT tbl_cvp.CVAmt FROM tbl_cvp INNER JOIN tbl_cv ON tbl_cvp.CVNo = tbl_cv.CVNo WHERE ReqNo = '" & strReqNo & "' AND tbl_cv.Cancelled = FALSE"

        cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL2, cnn)

        reader = cmdSQL.ExecuteReader

        While reader.Read
            dblCVAmt += reader.Item("CVAmt")
        End While

        reader.Close()
        cmdSQL.Dispose()

        GetBalance = dblReqAmt - dblCVAmt
    End Function
    'Private Function SelectCRNo(ByVal strRefNo As String) As Boolean
    '    SelectCRNo = True
    '    Dim dblBal As Double = GetBalance(strRefNo, "SELECT CRP_TotalAmt FROM ap_crp WHERE CRP_Nbr = '" & strRefNo & "'", "CRP_TotalAmt")

    '    Dim blFull As Boolean

    '    If Me.optPartial.Checked = True Then
    '        blFull = False
    '    ElseIf Me.optFull.Checked = True Then
    '        blFull = True
    '    End If

    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

    '    Dim strsql As String = "SELECT ap_crp.CRP_Nbr, ap_crp.CRP_TotalAmt, ap_crp.CRP_PayeeID, ap_crp.CRP_Cancel, ap_crp.CRP_DtNeed, lib_vendor.VendorName " &
    '                            "FROM ap_crp INNER JOIN lib_vendor ON ap_crp.CRP_PayeeID = lib_vendor.VendorID " &
    '                            "WHERE ap_crp.CRP_Nbr = '" & strRefNo & "'"

    '    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

    '    If reader.HasRows = False Then
    '        MsgBox("Check Request No. not found!", MsgBoxStyle.Information, "System message")
    '        SelectCRNo = False
    '    Else
    '        While reader.Read
    '            If Len(Me.txtPayeeID.Text) > 0 Then
    '                If Me.txtPayeeID.Text <> reader.Item("CRP_PayeeID") Then
    '                    MsgBox("Reference No. " & strRefNo & " has a different Payee!", MsgBoxStyle.Information, "System message")
    '                    reader.Close()
    '                    cmdSQL.Dispose()
    '                    SelectCRNo = False
    '                    Exit Function
    '                End If
    '            End If

    '            If Len(Me.txtDateNeeded.Text) > 0 Then
    '                If Me.txtDateNeeded.Text <> CDate(reader.Item("CRP_DtNeed")).Date Then
    '                    MsgBox("Reference No. " & strRefNo & " has a date needed!", MsgBoxStyle.Information, "System message")
    '                    reader.Close()
    '                    cmdSQL.Dispose()
    '                    SelectCRNo = False
    '                    Exit Function
    '                End If
    '            End If

    '            Me.txtDateNeeded.Text = CDate(reader.Item("CRP_DtNeed")).Date
    '            Me.txtPayeeID.Text = reader.Item("CRP_PayeeID")
    '            Me.txtPayeeName.Text = reader.Item("VendorName")

    '            If blFull = True Then
    '                If dblBal = 0 Then
    '                    MsgBox("Check Request No. " & reader.Item("CRP_Nbr") & " remaining amount is " & Format(CDbl(dblBal), "n2") & "!", MsgBoxStyle.Exclamation, "System Message")
    '                    SelectCRNo = False
    '                Else
    '                    Me.dtgRefNo.Rows.Add(reader.Item("CRP_Nbr"), reader.Item("VendorName"), reader.Item("CRP_DtNeed"), Format(reader.Item("CRP_TotalAmt"), "n2"), Format(dblBal, "n2"), False, IIf(reader.Item("CRP_TotalAmt") = dblBal, blFull, False))
    '                End If
    '            Else
    '                If CDbl(Me.txtVoucherAmt.Text) > dblBal Then
    '                    MsgBox("Check Request No. " & reader.Item("CRP_Nbr") & " remaining amount is " & Format(CDbl(dblBal), "n2") & "!", MsgBoxStyle.Exclamation, "System Message")
    '                    SelectCRNo = False
    '                Else
    '                    Me.dtgRefNo.Rows.Add(reader.Item("CRP_Nbr"), reader.Item("VendorName"), reader.Item("CRP_DtNeed"), Format(reader.Item("CRP_TotalAmt"), "n2"), Format(CDbl(Me.txtVoucherAmt.Text), "n2"), False, blFull)
    '                End If
    '            End If
    '        End While
    '    End If

    '    reader.Close()
    '    cmdSQL.Dispose()
    'End Function
    'Private Function CheckCRIfAccrual(ByVal strReqNo As String) As Boolean
    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
    '    CheckCRIfAccrual = True
    '    Dim strSQL As String = "SELECT ap_crp.CRP_FTRequest, ap_crp.CRP_PCRequest " &
    '             "FROM ap_crp " &
    '             "WHERE ap_crp.CRP_Nbr = '" & strReqNo & "'"

    '    Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)
    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()

    '    While reader.Read()
    '        If Me.dtgRefNo.Rows.Count = 0 Then
    '            If reader.Item("CRP_FTRequest") = True Then
    '                Me.lblNonAccrualType.Text = "Fund Transfer"
    '                Me.gpInclude.Enabled = False
    '            ElseIf reader.Item("CRP_PCRequest") = True Then
    '                Me.lblNonAccrualType.Text = "Petty Cash"
    '                Me.optAPVNo.Enabled = False
    '            Else
    '                'Me.lblNonAccrualType.Text = "Accrual"
    '                'Me.optReqNo.Enabled = False
    '                MsgBox("Cannot include request no. " & strReqNo & " it is an accrual check request! APV No. required.", MsgBoxStyle.Exclamation, "System Message")
    '                CheckCRIfAccrual = False
    '            End If
    '        Else
    '            If Me.lblNonAccrualType.Text = "Petty Cash" Then
    '                If reader.Item("CRP_PCRequest") = False Then
    '                    MsgBox("Cannot include " & strReqNo & " because it is not a Petty Cash Check Request!", MsgBoxStyle.Exclamation, "System Message")
    '                    CheckCRIfAccrual = False
    '                End If
    '            End If
    '        End If
    '    End While

    '    reader.Close()
    '    cmd.Dispose()
    'End Function
    Private Function CheckIfRequestHasAP(ByVal strRefNo As String) As Boolean
        Dim strsql As String = "SELECT APV_ReqNo FROM ap_apv WHERE APV_ReqNo = '" & strRefNo & "'"

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        If reader.HasRows = True Then
            MsgBox("Request " & strRefNo & " has AP Voucher already!", MsgBoxStyle.Information, "System Message")
            CheckIfRequestHasAP = True
        Else
            CheckIfRequestHasAP = False
        End If

        reader.Close()
        cmdSQL.Dispose()
    End Function
    'Private Function CheckChkBookingStatus(ByVal strReqNo As String) As Boolean
    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
    '    CheckChkBookingStatus = True
    '    Dim strsql As String

    '    strsql = "SELECT ap_crd.CRD_BookNbr, ap_crd.CRD_Key " & _
    '             "FROM ap_crd " & _
    '             "WHERE ap_crd.CRD_CPRNbr = '" & strReqNo & "'"

    '    Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()

    '    While reader.Read()
    '        If IsDBNull(reader.Item("CRD_BookNbr")) = False Or IsDBNull(reader.Item("CRD_Key")) = False Then
    '            CheckChkBookingStatus = CheckPerBooking(reader.Item("CRD_BookNbr"), reader.Item("CRD_Key"))
    '        Else
    '            CheckChkBookingStatus = True
    '        End If
    '    End While

    '    reader.Close()
    '    cmd.Dispose()

    '    If CheckChkBookingStatus = False Then
    '        MsgBox("Theres a cancelled booking in request no. " & strReqNo & "!", MsgBoxStyle.Exclamation, "System Message")
    '    End If
    'End Function
    Private Function CheckRequestStatus(ByVal strReqNo As String) As Boolean
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        CheckRequestStatus = True
        Dim strSQL As String = "SELECT tbl_request.REQ_Nbr,  tbl_request.REQ_Cancel " &
                 "FROM tbl_request " &
                 "WHERE tbl_request.REQ_Nbr = '" & strReqNo & "'"

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()

        Dim dtCurrent As Date = GetServerDate()

        While reader.Read()
            If reader.Item("REQ_Cancel") = True Then
                MsgBox("Request " & reader.Item("REQ_Nbr") & " already cancelled!", MsgBoxStyle.Information, "System Message")
                CheckRequestStatus = False
            Else
                CheckRequestStatus = True
            End If
        End While

        reader.Close()
        cmd.Dispose()
    End Function

    Private Sub optFull_CheckedChanged(sender As Object, e As EventArgs) Handles optFull.CheckedChanged

    End Sub

    Private Sub optFull_Click(sender As Object, e As EventArgs) Handles optFull.Click
        SelectFullPartial()
    End Sub

    Private Sub optPartial_CheckedChanged(sender As Object, e As EventArgs) Handles optPartial.CheckedChanged

    End Sub

    Private Sub optPartial_Click(sender As Object, e As EventArgs) Handles optPartial.Click
        SelectFullPartial()
    End Sub

    Private Sub SelectFullPartial()
        If Me.optFull.Checked = True Then
            Me.txtVoucherAmt.Enabled = False
        End If

        If Me.optPartial.Checked = True Then
            Me.txtVoucherAmt.Enabled = True
            Me.txtVoucherAmt.Focus()
        End If
    End Sub
    Private Sub AcceptRefNos()
        For ctrRow As Integer = 0 To Me.dtgRefNo.Rows.Count - 1
            With Me.dtgRefNo.Rows(ctrRow)
                If .Cells("colAPV").Value = True Then
                    Dim strsql As String = "SELECT APV_ReqNo FROM tbl_apv WHERE APV_Nbr = '" & .Cells(0).Value & "'"

                    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

                    While reader.Read
                        frmCV.dtgParticulars.Rows.Add(reader.Item("APV_ReqNo"), .Cells("colRefNo").Value, Format(CDbl(.Cells("colAmt").Value), "n2"), .Cells("colFull").Value, Format(CDbl(.Cells("colCVAmt").Value), "n2"), strCompanyCode)
                    End While

                    reader.Close()
                    cmdSQL.Dispose()
                Else
                    frmCV.dtgParticulars.Rows.Add(.Cells("colRefNo").Value, "", Format(CDbl(.Cells("colAmt").Value), "n2"), .Cells("colFull").Value, Format(CDbl(.Cells("colCVAmt").Value), "n2"), strCompanyCode)
                End If
            End With
        Next
    End Sub

    Private Sub GetAPEntry(ByVal strAPNo As String, ByVal CVAmt As Double)
        Dim blDuplicateEntry As Boolean
        Dim strsql As String = "SELECT * FROM tbl_apvgl WHERE APVGL_APVNbr = '" & strAPNo & "' AND (tbl_apvgl.APVGL_Account_Code = '2010' OR tbl_apvgl.APVGL_Account_Code = '6250') AND tbl_apvgl.APVGL_CR > 0"

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            If frmCV.dtgCheckEntry.Rows.Count = 0 Then
                frmCV.dtgCheckEntry.Rows.Add("", reader.Item("APVGL_Account_Code"), reader.Item("APVGL_Account_Title"),
                            Format(CVAmt, "n2"), "0.00", reader.Item("APVGL_SubAccount_Code"),
                            reader.Item("APVGL_SubAccount_Title"), reader.Item("APVGL_SubAccount_Dept"),
                            reader.Item("APVGL_SubAccount_DeptName"), reader.Item("APVGL_SubAccount_List"),
                            reader.Item("APVGL_SubAccount_ListItem"), reader.Item("APVGL_SubAccount_ListItemName"))
            Else
                For ctrrow As Integer = 0 To frmCV.dtgCheckEntry.Rows.Count - 1
                    blDuplicateEntry = False
                    With frmCV.dtgCheckEntry.Rows(ctrrow)
                        If .Cells(1).Value = reader.Item("APVGL_Account_Code") And .Cells(2).Value = reader.Item("APVGL_Account_Title") _
                            And .Cells(5).Value = reader.Item("APVGL_SubAccount_Code") And .Cells(6).Value = reader.Item("APVGL_SubAccount_Title") _
                            And .Cells(7).Value = reader.Item("APVGL_SubAccount_Dept") And .Cells(8).Value = reader.Item("APVGL_SubAccount_DeptName") _
                            And .Cells(9).Value = reader.Item("APVGL_SubAccount_List") And .Cells(10).Value = reader.Item("APVGL_SubAccount_ListItem") _
                            And .Cells(11).Value = reader.Item("APVGL_SubAccount_ListItemName") Then

                            .Cells("colDR").Value = Format((CDbl(.Cells("colDR").Value) + CVAmt), "n2")
                            blDuplicateEntry = True
                            Exit For
                        End If
                    End With
                Next
                If blDuplicateEntry = False Then
                    frmCV.dtgCheckEntry.Rows.Add("", reader.Item("APVGL_Account_Code"), reader.Item("APVGL_Account_Title"),
                                Format(CVAmt, "n2"), "0.00", reader.Item("APVGL_SubAccount_Code"),
                                reader.Item("APVGL_SubAccount_Title"), reader.Item("APVGL_SubAccount_Dept"),
                                reader.Item("APVGL_SubAccount_DeptName"), reader.Item("APVGL_SubAccount_List"),
                                reader.Item("APVGL_SubAccount_ListItem"), reader.Item("APVGL_SubAccount_ListItemName"))
                End If
            End If
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub cmdGo_Click(sender As Object, e As EventArgs) Handles cmdGo.Click
        If Me.dtgRefNo.Rows.Count = 0 Then
            MsgBox("Select Request No. or APV No. first!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        AcceptRefNos()

        'Get AP Entry
        For ctrRow As Integer = 0 To Me.dtgRefNo.Rows.Count - 1
            With Me.dtgRefNo.Rows(ctrRow)
                If .Cells("colAPV").Value = True Then
                    GetAPEntry(.Cells("colRefNo").Value, CDbl(.Cells("colCVAmt").Value))
                End If
            End With
        Next

        With frmCV
            .txtPayeeCode.Text = Me.txtPayeeID.Text
            .txtPayeeName.Text = Me.txtPayeeName.Text
            .txtDateNeeded.Text = Me.txtDateNeeded.Text
            .lblNonAccrualType.Text = Me.lblNonAccrualType.Text

            If Me.lblNonAccrualType.Text = "Fund Transfer" Then
                .cmdAddPaymentDetails.Enabled = False
            Else
                .cmdAddPaymentDetails.Enabled = True
            End If

            ''Set Petty Cash Entry
            'If Me.lblNonAccrualType.Text = "Petty Cash" Then
            '    For ctrRow As Integer = 0 To Me.dtgRefNo.Rows.Count - 1
            '        PopPettyCashEntry(Me.dtgRefNo.Rows(ctrRow).Cells("colRefNo").Value)
            '    Next
            'End If

            .TabControl2.SelectedTab = .tpPaymentDetails
            '.EnableObjects(False, False, True, True, False, False, False, False, True)
            .ComputeTotalPayment()
            .ComputeTotalDRCR()
        End With
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdRemoveEntry_Click(sender As Object, e As EventArgs) Handles cmdRemoveEntry.Click
        With Me.dtgRefNo
            If .Rows.Count > 0 Then
                If .CurrentRow.Index >= 0 Then
                    .Rows.Remove(.CurrentRow)
                    If .Rows.Count = 0 Then
                        ResetAll()
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub cmdClearAllEntry_Click(sender As Object, e As EventArgs) Handles cmdClearAllEntry.Click
        Me.dtgRefNo.Rows.Clear()
        ResetAll()
    End Sub

    'Private Sub PopPettyCashEntry(ByVal strReqNo As String)
    '    Dim dblTotalDR As Double, strFundKey As String = "", strSubCode As String, strDeptName = "All Departments Departments"

    '    Dim strsql As String = "SELECT ap_pcr.PCR_Fund, ap_pca.* FROM (ap_crp INNER JOIN ap_pca ON ap_crp.CRP_PONbr = ap_pca.PCA_RepNumber) " & _
    '                            "INNER JOIN ap_pcr ON ap_pca.PCA_Nbr = ap_pcr.PCR_Nbr " & _
    '                            "WHERE ap_crp.CRP_Nbr = '" & strReqNo & "' AND ap_crp.CRP_PCRequest = TRUE and ap_crp.CRP_Cancel = FALSE"

    '    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

    '    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

    '    While reader.Read
    '        If reader.Item("PCA_Account_Code") <> "1010" And reader.Item("PCA_DR") > 0 Then
    '            dblTotalDR += reader.Item("PCA_DR")
    '            strFundKey = reader.Item("PCR_Fund")
    '            'frmCV.dtgCheckEntry.Rows.Add("", reader.Item("PCA_Account_Code"), reader.Item("PCA_Account_Title"), reader.Item("PCA_DR"), reader.Item("PCA_CR"), reader.Item("PCA_SubAccount_Code"), reader.Item("PCA_SubAccount_Title"), reader.Item("PCA_SubAccount_Dept"), reader.Item("PCA_SubAccount_DeptName"), reader.Item("PCA_SubAccount_List"), reader.Item("PCA_SubAccount_ListItem"), reader.Item("PCA_SubAccount_ListItemName"))
    '        End If
    '    End While

    '    reader.Close()

    '    Select Case strFundKey
    '        Case "AISMNL"
    '            strSubCode = "1"
    '        Case "MNLOPR"
    '            strSubCode = "16"
    '        Case "TRKMNL"
    '            strSubCode = "4"
    '        Case "AISCAV"
    '            strSubCode = "5"
    '        Case "CAVOPR"
    '            strSubCode = "17"
    '        Case "AISLAG"
    '            strSubCode = "6"
    '        Case "LAGOPR"
    '            strSubCode = "18"
    '        Case "AISCBU"
    '            strSubCode = "7"
    '        Case "CBUOPR"
    '            strSubCode = "19"
    '        Case "AISSBC"
    '            strSubCode = "12"
    '        Case "SBCOPR"
    '            strSubCode = "20"
    '        Case "AISDVO"
    '            strSubCode = "13"
    '        Case "DVOOPR"
    '            strSubCode = "21"
    '        Case "AISBTN"
    '            strSubCode = "14"
    '        Case "BTNOPR"
    '            strSubCode = "22"
    '        Case Else

    '            strSubCode = ""
    '    End Select

    '    strsql = "SELECT * FROM lib_acctcode INNER JOIN lib_subacctcode ON lib_acctcode.Account_Code = lib_subacctcode.Account_Code " & _
    '             "WHERE lib_acctcode.Account_Code = '1010' AND lib_subacctcode.SubAccount_Code = '" & strSubCode & "'"

    '    cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

    '    reader = cmdSQL.ExecuteReader

    '    While reader.Read
    '        With frmCV
    '            If .dtgCheckEntry.Rows.Count > 0 Then
    '                For ctrRow As Integer = 0 To .dtgCheckEntry.Rows.Count - 1
    '                    If .dtgCheckEntry.Rows(ctrRow).Cells("colAcctCode").Value = reader.Item("Account_Code") _
    '                    And .dtgCheckEntry.Rows(ctrRow).Cells("colAcctTitle").Value = reader.Item("Account_Title") _
    '                    And .dtgCheckEntry.Rows(ctrRow).Cells("colSubCode").Value = reader.Item("SubAccount_Code") _
    '                    And .dtgCheckEntry.Rows(ctrRow).Cells("colSubAcctTitle").Value = reader.Item("SubAccount_Title") _
    '                    And .dtgCheckEntry.Rows(ctrRow).Cells("colchkDept").Value = reader.Item("SubAccount_Dept") _
    '                    And .dtgCheckEntry.Rows(ctrRow).Cells("colDeptName").Value = strDeptName _
    '                    And .dtgCheckEntry.Rows(ctrRow).Cells("colchkList").Value = reader.Item("SubAccount_List") _
    '                    And .dtgCheckEntry.Rows(ctrRow).Cells("colListItem").Value = reader.Item("SubAccount_ListItem") _
    '                    Then
    '                        .dtgCheckEntry.Rows(ctrRow).Cells("colDR").Value = Format(CDbl(.dtgCheckEntry.Rows(ctrRow).Cells("colDR").Value) + dblTotalDR, "n2")
    '                        .dtgCheckEntry.Rows(ctrRow).Cells("colCR").Value = "0.00"
    '                    Else
    '                        .dtgCheckEntry.Rows.Add("", reader.Item("Account_Code"), reader.Item("Account_Title"), Format(dblTotalDR, "n2"), "0.00", reader.Item("SubAccount_Code"), reader.Item("SubAccount_Title"), reader.Item("SubAccount_Dept"), strDeptName, reader.Item("SubAccount_List"), reader.Item("SubAccount_ListItem"), "")
    '                    End If
    '                Next
    '            Else
    '                .dtgCheckEntry.Rows.Add("", reader.Item("Account_Code"), reader.Item("Account_Title"), Format(dblTotalDR, "n2"), "0.00", reader.Item("SubAccount_Code"), reader.Item("SubAccount_Title"), reader.Item("SubAccount_Dept"), strDeptName, reader.Item("SubAccount_List"), reader.Item("SubAccount_ListItem"), "")
    '            End If
    '        End With
    '    End While

    '    reader.Close()
    '    cmdSQL.Dispose()
    'End Sub

    Private Sub ResetAll()
        Me.gpInclude.Enabled = True
        Me.optReqNo.Enabled = True
        Me.optReqNo.Checked = True
        Me.optAPVNo.Enabled = True
        Me.optFull.Enabled = True
        Me.lblNonAccrualType.Text = ""
        Me.txtPayeeID.Text = ""
        Me.txtPayeeName.Text = ""
        Me.txtDateNeeded.Text = ""
    End Sub

    Private Sub frmCreateVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dtgRefNo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgRefNo.CellContentClick

    End Sub

    Private Sub cmdSelect_Click(sender As Object, e As EventArgs) Handles cmdSelect.Click
        If CheckIfRefNoAlreadyAdded(Me.lblPrefix.Text & Me.txtRefNo.Text) = True Then Exit Sub

        If Me.optPartial.Checked = True And Len(Me.txtVoucherAmt.Text) = 0 Then
            MsgBox("Please enter Voucher Amount!", MsgBoxStyle.Exclamation, "System Message")
            Me.txtVoucherAmt.Focus()
            Exit Sub
        End If

        'Select Case Me.Tag
        '    Case "CV"
        '        If Me.optReqNo.Checked = True Then
        '            If CheckCRStatus(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
        '            If CheckChkBookingStatus(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
        '            If CheckIfRequestHasAP(Me.lblPrefix.Text & Me.txtRefNo.Text) = True Then Exit Sub
        '            If CheckCRIfAccrual(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
        '            If SelectCRNo(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
        '        ElseIf Me.optAPVNo.Checked = True Then
        '            If SelectAPVCNo(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
        '        Else
        '            MsgBox("Select if by Request No. or APV No.", MsgBoxStyle.Exclamation, "System Message")
        '            Exit Sub
        '        End If

        '    Case "MCV"
        '        If Me.optReqNo.Checked = True Then
        '            If CheckMCRStatus(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
        '            If CheckMCBookingStatus(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
        '            If CheckIfRequestHasAP(Me.lblPrefix.Text & Me.txtRefNo.Text) = True Then Exit Sub
        '            If CheckMCRIfAccrual(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
        '            If SelectMCRNo(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
        '        ElseIf Me.optAPVNo.Checked = True Then
        '            If SelectAPVMNo(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then Exit Sub
        '        Else
        '            MsgBox("Select if by Request No. or APV No.", MsgBoxStyle.Exclamation, "System Message")
        '            Exit Sub
        '        End If
        'End Select

        Me.txtRefNo.Text = ""
        Me.txtVoucherAmt.Text = ""
    End Sub
End Class