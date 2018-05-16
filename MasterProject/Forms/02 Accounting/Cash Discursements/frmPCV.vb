Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmPCV

    Private Sub frmPCV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cboReports.Items.Clear()
        Me.cboReports.Items.Add("Petty Cash Replenishment")
        Me.cboReports.Items.Add("Petty Cash Daily Cash Count")
        Me.txtRequestNo.SetWaterMark("Enter Request No. here")
    End Sub

    Public Sub CancelRequest(ByVal str As String)

    End Sub

    Private Sub ClearEntries()
        Me.lblReqNbr.Text = ""
        'Me.txtRequestNo.Text = ""
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


        strSQL = "SELECT tbl_request.REQ_Nbr,  tbl_request.REQ_ReqType, tbl_request.REQ_PayeeID, tbl_vendor.Description,  lib_requestparams.ParamName, lib_requestparams_1.ParamName AS ChargeName, tbl_request.REQ_DtNeed, tbl_request.REQ_Type,   tbl_request.REQ_PlateNbr, tbl_request.REQ_ChargeID, tbl_request.REQ_ChargeTo, tbl_request.REQ_Remarks, tbl_request.REQ_TotalAmt, tbl_request.REQ_PrepDate, tbl_request.REQ_PrepBy, tbl_request.REQ_Cancel,  tbl_request.REQ_Invoice, tbl_request.REQ_ModDate, tbl_request.REQ_ModBy, tbl_request.REQ_Liquidated, tbl_request.REQ_Release, tbl_request.REQ_BranchCode, tbl_request.REQ_ReleaseBy, tbl_request.REQ_ReleaseDate, tbl_request.REQ_PCVReceivedBy, tbl_request.REQ_LiquidatedBy, tbl_request.REQ_LiquidatedDate, tbl_request.REQ_LiquidatedAmount, tbl_request.REQ_LiquidationDate " &
                 "FROM ((tbl_request INNER JOIN lib_requestparams ON tbl_request.REQ_Type = lib_requestparams.ParamCode) INNER JOIN lib_requestparams AS lib_requestparams_1 ON tbl_request.REQ_ChargeID = lib_requestparams_1.ParamCode) INNER JOIN tbl_vendor ON tbl_request.REQ_PayeeID = tbl_vendor.Code " &
                 "WHERE tbl_request.REQ_Nbr = '" & str & " '"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            If IsDBNull(reader.Item("REQ_Nbr")) = False Then
                SearchRequest = True
            End If

            Select Case reader.Item("REQ_ReqType")
                Case 2
                    MsgBox("Request type is Cheque!" & vbNewLine & "Request should be Petty Cash to proceed.", vbInformation, "System Message")
                    cmd.Dispose()
                    reader.Close()
                    cnnDBMaster.Close()
                    ClearEntries()
                    Exit Function
                Case 3
                    MsgBox("Request type is MC!" & vbNewLine & "Request should be Petty Cash to proceed.", vbInformation, "System Message")
                    cmd.Dispose()
                    reader.Close()
                    cnnDBMaster.Close()
                    ClearEntries()
                    Exit Function
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

            Me.txtBranchCode.Text = reader.Item("REQ_BranchCode")

            If Not IsDBNull(reader.Item("REQ_Invoice")) Then
                Me.txtInvoice.Text = reader.Item("REQ_Invoice")
            Else
                txtInvoice.Text = ""
            End If

            'get request status

            If reader.Item("REQ_Cancel") = True Then
                Me.txtStatus.Text = "Cancelled"
            End If

            If reader.Item("REQ_Liquidated") = True Then
                Me.txtStatus.Text = "Posted"
            End If

            If reader.Item("REQ_Cancel") = False And reader.Item("REQ_Release") = True And reader.Item("REQ_Liquidated") = False Then
                Me.txtStatus.Text = "Released"

            End If

            If reader.Item("REQ_Release") = False And reader.Item("REQ_Cancel") = False Then
                Me.txtStatus.Text = "Open"
            End If

            If reader.Item("REQ_Release") = True Then
                Me.txtReleaseBy.Text = reader.Item("REQ_ReleaseBy")
                Me.txtReleaseDate.Text = reader.Item("REQ_ReleaseDate")
                Me.txtReceiveBy.Text = reader.Item("REQ_PCVReceivedBy")
            Else
                Me.txtReleaseBy.Text = ""
                Me.txtReleaseDate.Text = ""
                Me.txtReceiveBy.Text = ""
            End If

            If reader.Item("REQ_Liquidated") = True Then
                Me.txtPostBy.Text = reader.Item("REQ_LiquidatedBy")
                Me.txtPostDate.Text = reader.Item("REQ_LiquidatedDate")
                Me.txtReturnRefund.Text = Format(reader.Item("REQ_LiquidatedAmount"), "n2")
                Me.txtLiquidationDate.Text = reader.Item("REQ_LiquidationDate")
            Else
                Me.txtPostBy.Text = ""
                Me.txtPostDate.Text = ""
                Me.txtReturnRefund.Text = ""
                Me.txtLiquidationDate.Text = ""
            End If






            PopReleaseEntry(Me.lblReqNbr.Text)
            PopPostEntry(Me.lblReqNbr.Text)
        End While

        cmd.Dispose()
        reader.Close()

        PopulateItems(Me.dgDetails, Me.lblReqNbr.Text)

        cnnDBMaster.Close()

        Me.txtGrandTotal.Text = Format(SumAmount, "N2")

        'ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
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
                    dg.Rows.Add("", reader.Item("REQD_Particulars"), Format(reader.Item("REQD_Qty"), "n2"), reader.Item("REQD_Unit"), Format(reader.Item("REQD_UnitCost"), "n2"), Format(reader.Item("REQD_Amount"), "n2"), reader.Item("REQD_CostCenter"))
                Case "OPR"
                    dg.Rows.Add("", reader.Item("REQD_Particulars"), Format(reader.Item("REQD_Amount"), "n2"), reader.Item("REQD_BookNbr"), reader.Item("REQD_Shipper"), reader.Item("REQD_Consignee"), reader.Item("REQD_ContainerNo"), reader.Item("REQD_HBL"), reader.Item("REQD_Key"), IIf(IsDBNull(reader.Item("REQD_CHCode")), "", reader.Item("REQD_CHCode")), reader.Item("REQD_CostCenter"))
            End Select

        End While

        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub

    Public Sub PopPostEntry(ByVal strVal As String)
        Dim strsql As String = "SELECT * FROM tbl_pca WHERE PCA_Nbr = '" & strVal & "'"
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgPCPostEntry.Rows.Clear()
        While reader.Read
            Me.dtgPCPostEntry.Rows.Add(reader.Item("PCA_Account_Code"), reader.Item("PCA_Account_Title"), Format(reader.Item("PCA_DR"), "n2"), Format(reader.Item("PCA_CR"), "n2"),
                                          reader.Item("PCA_SubAccount_Code"), reader.Item("PCA_SubAccount_Title"), reader.Item("PCA_SubAccount_Dept"),
                                          reader.Item("PCA_SubAccount_DeptName"), reader.Item("PCA_SubAccount_List"), reader.Item("PCA_SubAccount_ListItem"),
                                          reader.Item("PCA_SubAccount_ListItemName"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Public Sub PopReleaseEntry(ByVal strVal As String)
        Dim strsql As String = "SELECT * FROM tbl_pcar WHERE PCAR_Nbr = '" & strVal & "'"
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgPCReleaseEntry.Rows.Clear()
        While reader.Read
            Me.dtgPCReleaseEntry.Rows.Add(reader.Item("PCAR_Account_Code"), reader.Item("PCAR_Account_Title"), Format(reader.Item("PCAR_DR"), "n2"), Format(reader.Item("PCAR_CR"), "n2"),
                                          reader.Item("PCAR_SubAccount_Code"), reader.Item("PCAR_SubAccount_Title"), reader.Item("PCAR_SubAccount_Dept"),
                                          reader.Item("PCAR_SubAccount_DeptName"), reader.Item("PCAR_SubAccount_List"), reader.Item("PCAR_SubAccount_ListItem"),
                                          reader.Item("PCAR_SubAccount_ListItemName"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub
    Private Sub SetColumnProp()
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
            End Select
        End With

        Me.Refresh()
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

    Private Sub txtGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles txtGrandTotal.TextChanged
        If Not Len(Me.txtGrandTotal.Text) = 0 Then
            Me.txtAmtInWords.Text = English(Me.txtGrandTotal.Text)
        End If
    End Sub

    Private Sub btRelease_Click(sender As Object, e As EventArgs) Handles btRelease.Click
        If Len(Me.lblReqNbr.Text) = 0 Then
            MsgBox("Nothing to Release!", vbInformation, "System Message")
            Exit Sub
        End If

        Select Case Me.txtStatus.Text
            Case "Released"
                MsgBox("Request already released!", vbInformation, "System Message")
                Exit Sub
            Case "Posted"
                MsgBox("Request already posted!", vbInformation, "System Message")
                Exit Sub
            Case "Open"
                ReleasePettyCash()
            Case "Cancelled"
                MsgBox("Request already cancelled!", vbInformation, "System Message")
                Exit Sub
        End Select
    End Sub

    Public Sub PostPettyCash()
        Dim cmdSQL As New MySqlCommand
        Dim strPCVFund As String = ""
        'For j As Integer = 0 To Me.DataGridView2.Rows.Count - 1
        '    If Me.DataGridView2.Rows(j).Cells(2).Value = "Cancelled" Then
        '        MsgBox("There's a Cancelled Booking in this request", vbInformation, "Invalid Request")
        '        Exit Sub
        '    End If

        'Next

        If Me.txtBranchCode.Text = "MNL" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then
                'Select Case Me.cboCostCenter.Text

                '    Case "Brokerage Import"
                '        PCVFund = "AISBRI"
                '    Case "Brokerage Export"
                '        PCVFund = "AISBRE"
                '    Case "Sea Freight Import/Export"
                '        PCVFund = "AISSFR"
                '    Case "Trucking Operations"
                '        PCVFund = "TRKMNL"
                '    Case Else
                '        PCVFund = "MNLOPR"
                'End Select
            Else
                strPCVFund = "AISMNL"
            End If
        ElseIf txtBranchCode.Text = "TMNL" Then
            strPCVFund = "TRKMNL"
        ElseIf txtBranchCode.Text = "CAV" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then
                strPCVFund = "CAVOPR"
            Else
                strPCVFund = "AISCAV"
            End If
        ElseIf txtBranchCode.Text = "LAG" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then
                strPCVFund = "LAGOPR"
            Else
                strPCVFund = "AISLAG"
            End If
        ElseIf txtBranchCode.Text = "CBU" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then
                strPCVFund = "CBUOPR"
            Else
                strPCVFund = "AISCBU"
            End If
        ElseIf txtBranchCode.Text = "SBC" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then
                strPCVFund = "SBCOPR"
            Else
                strPCVFund = "AISSBC"
            End If
        End If
        frmPettyCashPost.dgDetails.ReadOnly = False
        frmPettyCashPost.strFundKey = strPCVFund
        frmPettyCashPost.PopulateItems(frmPettyCashPost.dgDetails, Me.lblReqNbr.Text)
        frmPettyCashPost.ShowDialog()
    End Sub


    Public Sub ReleasePettyCash()
        Dim dtCurrent As Date = GetServerDate()
        Dim strPCVFund As String = ""
        If CDate(Me.txtDateNeeded.Text).Date > dtCurrent.Date Then
            MsgBox("Cannot release petty cash request. Petty cash request date needed is on " & Me.txtDateNeeded.Text & "!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If Me.txtBranchCode.Text = "MNL" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then

                'insert condition new policy of PCF here

                'Select Case Me.cboCostCenter.Text

                '    Case "Brokerage Import"
                '        strPCVFund = "AISBRI"
                '    Case "Brokerage Export"
                '        strPCVFund = "AISBRE"
                '    Case "Sea Freight Import/Export"
                '        strPCVFund = "AISSFR"
                '    Case "Trucking Operations"
                '        strPCVFund = "TRKMNL"
                'End Select

            Else
                strPCVFund = "AISMNL"
            End If
        ElseIf txtBranchCode.Text = "TMNL" Then
            strPCVFund = "TRKMNL"
        ElseIf txtBranchCode.Text = "CAV" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then
                strPCVFund = "CAVOPR"
            Else
                strPCVFund = "AISCAV"
            End If
        ElseIf txtBranchCode.Text = "LAG" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then
                strPCVFund = "LAGOPR"
            Else
                strPCVFund = "AISLAG"
            End If
        ElseIf txtBranchCode.Text = "CBU" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then
                strPCVFund = "CBUOPR"
            Else
                strPCVFund = "AISCBU"
            End If
        ElseIf txtBranchCode.Text = "SBC" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then
                strPCVFund = "SBCOPR"
            Else
                strPCVFund = "AISSBC"
            End If
        ElseIf txtBranchCode.Text = "BTN" Then
            If GetRequestType(Me.lblReqNbr.Text) = "OPR" Then
                strPCVFund = "BTNOPR"
            Else
                strPCVFund = "AISBTN"
            End If
        End If
        frmPettyCashRelease.RetrieveFund(strPCVFund)

        frmPettyCashRelease.txtRequestedAmt.Text = Format(CDbl(Me.txtGrandTotal.Text), "n2")
        frmPettyCashRelease.ShowDialog()
    End Sub
    Public Function GetRequestType(ByVal str As String) As String
        GetRequestType = ""
        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM tbl_request " &
                 "WHERE REQ_Nbr = '" & str & "'"


        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read
            GetRequestType = reader.Item("REQ_Type")
        End While

        cmd.Dispose()
        reader.Close()
    End Function
    Private Sub btPost_Click(sender As Object, e As EventArgs) Handles btPost.Click
        If Len(Me.lblReqNbr.Text) = 0 Then
            MsgBox("Nothing to Post!", vbInformation, "System Message")
            Exit Sub
        End If

        Select Case Me.txtStatus.Text
            Case "Released"
                PostPettyCash()
            Case "Posted"
                MsgBox("Request already posted!", vbInformation, "System Message")
                Exit Sub
            Case "Open"
                MsgBox("Request not yet released!", vbInformation, "System Message")
                Exit Sub
            Case "Cancelled"
                MsgBox("Request already cancelled!", vbInformation, "System Message")
                Exit Sub
        End Select
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboReports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReports.SelectedIndexChanged
        If Me.cboReports.SelectedIndex = -1 Then Exit Sub
        Select Case Me.cboReports.Text
            Case "Petty Cash Replenishment"
                frmPettyCashReplenishment.ShowDialog()
            Case "Petty Cash Daily Cash Count"

        End Select
    End Sub

End Class