Imports MySql.Data.MySqlClient
Public Class frmPettyCashPost
    Dim AccountCode As String
    Dim SubAccountCode As String
    Dim COBAcctTitle As String
    Dim COBAcctNbr As String
    Dim COBSubAcctTitle As String
    Dim COBSubAcctNbr As String
    Public strFundKey As String
    Private Sub frmPettyCashPost_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RetrievePCVBank()
    End Sub

    Private Sub RetrievePCVBankCode()
        RetrievePCVBank()
        Dim strsql2 As String

        strsql2 = "SELECT lib_acctcode.Account_Code, lib_acctcode.Account_Title, lib_subacctcode.Account_Code, lib_subacctcode.SubAccount_Code, lib_subacctcode.SubAccount_Title " &
                    "FROM lib_acctcode INNER JOIN lib_subacctcode ON lib_acctcode.Account_Code = lib_subacctcode.SubAccount_Code " &
        "WHERE lib_acctcode.Account_Code ='" & AccountCode & "' and lib_subacctcode.SubAccount_Code ='" & SubAccountCode & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd3 = New MySqlCommand(strsql2, cnnDBMaster)
        Dim reader3 As MySqlDataReader = cmd3.ExecuteReader()
        While reader3.Read()
            COBAcctTitle = reader3.Item("Account_Title")
            COBAcctNbr = reader3.Item("Account_Code")
            COBSubAcctNbr = reader3.Item("SubAccount_Code")
            COBSubAcctTitle = reader3.Item("SubAccount_Title")
        End While
        reader3.Close()
        cmd3.Dispose()
        cnnDBMaster.Dispose()
        cnnDBMaster.Close()
    End Sub
    Private Sub RetrievePCVBank()
        Dim strsql2 As String

        strsql2 = "SELECT lib_bank.Account_Code, lib_bank.Name, lib_bank.PCV_Bank, lib_bank.SubAccount_Code " &
                    "FROM lib_bank " &
        "WHERE lib_bank.PCV_Bank ='1'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd3 = New MySqlCommand(strsql2, cnnDBMaster)
        Dim reader3 As MySqlDataReader = cmd3.ExecuteReader()
        While reader3.Read()
            AccountCode = reader3.Item("Account_Code")
            SubAccountCode = reader3.Item("SubAccount_Code")
        End While
        reader3.Close()
        cmd3.Dispose()
        cnnDBMaster.Dispose()
        cnnDBMaster.Close()

        Dim strSQL As String

        strSQL = "SELECT lib_acctcode.Account_Code, lib_acctcode.Account_Title, lib_subacctcode.Account_Code, lib_subacctcode.SubAccount_Code, lib_subacctcode.SubAccount_Title " &
                "FROM lib_acctcode INNER JOIN lib_subacctcode ON lib_acctcode.Account_Code = lib_subacctcode.Account_Code " &
               "WHERE(((lib_acctcode.Account_Code) = '" & AccountCode & "' and lib_subacctcode.SubAccount_Code = '" & SubAccountCode & "')) "


        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        While reader2.Read()
            COBAcctTitle = reader2.Item("Account_Title")
            COBAcctNbr = reader2.Item("Account_Code")
            COBSubAcctNbr = reader2.Item("SubAccount_Code")
            COBSubAcctTitle = reader2.Item("SubAccount_Title")
        End While
        reader2.Close()
        cmd2.Dispose()
        cnnDBMaster.Dispose()
        cnnDBMaster.Close()
    End Sub
    Public Sub PopulateItems(ByVal dg As DataGridView, ByVal str As String)
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

            Select Case frmPCV.txtType.Text
                Case "ADM"
                    dg.Rows.Add("", reader.Item("REQD_Particulars"), Format(reader.Item("REQD_Qty"), "n2"), reader.Item("REQD_Unit"), Format(reader.Item("REQD_UnitCost"), "n2"), Format(reader.Item("REQD_Amount"), "n2"), reader.Item("REQD_CostCenter"), Format(reader.Item("REQD_ReturnAmt"), "n2"), Format(reader.Item("REQD_RefundAmt"), "n2"), Format(reader.Item("REQD_LiquidatedAmt"), "n2"))
                Case "OPR"
                    dg.Rows.Add("", reader.Item("REQD_Particulars"), Format(reader.Item("REQD_Amount"), "n2"), reader.Item("REQD_BookNbr"), reader.Item("REQD_Shipper"), reader.Item("REQD_Consignee"), reader.Item("REQD_ContainerNo"), reader.Item("REQD_HBL"), reader.Item("REQD_Key"), IIf(IsDBNull(reader.Item("REQD_CHCode")), "", reader.Item("REQD_CHCode")), Format(reader.Item("REQD_ReturnAmt"), "n2"), Format(reader.Item("REQD_RefundAmt"), "n2"), Format(reader.Item("REQD_LiquidatedAmt"), "n2"))
            End Select

        End While

        cmd.Dispose()
        reader.Close()
    End Sub

    Public Sub SetColumnProp()
        Me.dgDetails.Columns.Clear()
        Me.dgDetails.Rows.Clear()
        Dim colBut As New DataGridViewButtonColumn

        With Me.dgDetails
            Select Case frmPCV.txtType.Text

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
                    .Columns(2).Width = 50
                    .Columns(3).Width = 50
                    .Columns(4).Width = 75
                    .Columns(5).Width = 75
                    .Columns(6).Width = 100


                    .Columns(1).DefaultCellStyle.ForeColor = Color.DarkBlue
                    .Columns(2).DefaultCellStyle.ForeColor = Color.Firebrick

                    .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(1).Frozen = True
                    .Columns(5).Frozen = True
                    .Columns(1).ReadOnly = True
                    .Columns(2).ReadOnly = True
                    .Columns(3).ReadOnly = True
                    .Columns(4).ReadOnly = True
                    .Columns(5).ReadOnly = True
                    .Columns(6).ReadOnly = True
                    .Columns(7).ReadOnly = False
                    .Columns(8).ReadOnly = False
                    .Columns(9).ReadOnly = False
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
                    .Columns(12).ReadOnly = False
                    .Columns(13).ReadOnly = False
                    .Columns(14).ReadOnly = False
            End Select

        End With

        Dim colBut2 As New DataGridViewButtonColumn
        Dim chkDept As New DataGridViewCheckBoxColumn
        Dim chkList As New DataGridViewCheckBoxColumn

        colBut2.Name = "colSelectEntry"
        colBut2.HeaderText = ""

        With Me.dgPost
            With Me.dgPost

                .Columns.Add(colBut2)
                .Columns.Add("", "Account Code")
                .Columns.Add("", "Account Title")
                .Columns.Add("", "")
                .Columns.Add("", "Sub Account Title")
                .Columns.Add(chkDept)
                .Columns.Add("", "Dept.")
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
            .Columns(2).Width = 150
            .Columns(3).Width = 25
            .Columns(4).Width = 100
            .Columns(5).Width = 25
            .Columns(6).Width = 75
            .Columns(7).Width = 25
            .Columns(8).Width = 75

            .Columns(9).Width = 250
            .Columns(10).Width = 100
            .Columns(11).Width = 100

            .Columns(4).Frozen = True

            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True

            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = True
            .Columns(7).ReadOnly = True
            .Columns(8).ReadOnly = True
            .Columns(9).ReadOnly = True


            '.Columns(10).Frozen = True
            '.Columns(11).Frozen = True


            '.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            '.Columns(1).DefaultCellStyle.Format = "n2"

        End With

        Me.Refresh()
    End Sub

    Private Sub dgDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetails.CellContentClick

    End Sub

    Private Sub dgDetails_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgDetails.EditingControlShowing
        Select Case frmPCV.txtType.Text
            Case "ADM"
                Dim tb As TextBox
                If dgDetails.CurrentCell.ColumnIndex = 7 Then
                    tb = CType(e.Control, TextBox)
                    '---add an event handler to the TextBox control---
                    AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
                End If

                If dgDetails.CurrentCell.ColumnIndex = 8 Then
                    tb = CType(e.Control, TextBox)
                    '---add an event handler to the TextBox control---
                    AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
                End If
            Case "OPR"
                Dim tb As TextBox
                If dgDetails.CurrentCell.ColumnIndex = 12 Then
                    tb = CType(e.Control, TextBox)
                    '---add an event handler to the TextBox control---
                    AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
                End If

                If dgDetails.CurrentCell.ColumnIndex = 13 Then
                    tb = CType(e.Control, TextBox)
                    '---add an event handler to the TextBox control---
                    AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
                End If
        End Select



    End Sub
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case frmPCV.txtType.Text
            Case "ADM"
                If dgDetails.CurrentCell.ColumnIndex = 7 Then
                    SetCharacter(MyOption.Numeric, e)
                End If

                If dgDetails.CurrentCell.ColumnIndex = 8 Then
                    SetCharacter(MyOption.Numeric, e)
                End If
            Case "OPR"
                If dgDetails.CurrentCell.ColumnIndex = 12 Then
                    SetCharacter(MyOption.Numeric, e)
                End If

                If dgDetails.CurrentCell.ColumnIndex = 13 Then
                    SetCharacter(MyOption.Numeric, e)
                End If

        End Select


    End Sub



    Public Sub GetReturnRefundAmtGLEntry(ByVal dg As DataGridView, ByVal dblReturn As Double, ByVal dblRefund As Double)
        Dim i As Integer = 0
        Dim h As DataGridViewRow

        For i = 0 To dg.Rows.Count - 1
            h = dg.Rows(i)

            If dblReturn <= 0 Then
                SetReturnRefundEntry("1010", 0, dblRefund)
            Else
                SetReturnRefundEntry("1010", dblReturn, 0)
            End If

        Next
    End Sub

    Private Sub dgDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetails.CellEndEdit
        'loop grid and get total return and refudn amount with gl entries

        Select Case frmPCV.txtType.Text
            Case "ADM"
                With Me.dgDetails
                    If CDbl(.CurrentRow.Cells(7).Value) = 0 And CDbl(.CurrentRow.Cells(8).Value) = 0 Then Exit Sub

                    If CDbl(.CurrentRow.Cells(7).Value) = 0 Then
                        Me.dgDetails.CurrentRow.Cells(9).Value = CDbl(Me.dgDetails.CurrentRow.Cells(5).Value) + CDbl(Me.dgDetails.CurrentRow.Cells(8).Value)
                        'SetReturnRefundEntry("1010", 0, Format(CDbl(Me.dgDetails.CurrentRow.Cells(8).Value), "n2"))

                    Else
                        Me.dgDetails.CurrentRow.Cells(9).Value = CDbl(Me.dgDetails.CurrentRow.Cells(5).Value) - CDbl(Me.dgDetails.CurrentRow.Cells(7).Value)
                        'SetReturnRefundEntry("1010", Format(CDbl(Me.dgDetails.CurrentRow.Cells(7).Value), "n2"), 0)
                    End If
                    GetReturnRefundAmtGLEntry(Me.dgDetails, CDbl(.CurrentRow.Cells(7).Value), CDbl(.CurrentRow.Cells(8).Value))
                End With

                Me.txtTotal.Text = Format(SumAmount(Me.dgDetails, 9), "n2")
                Me.lblDebit.Text = Format(SumAmount(Me.dgPost, 10), "n2")
                Me.lblCredit.Text = Format(SumAmount(Me.dgPost, 11), "n2")
            Case "OPR"
                With Me.dgDetails

                    If CDbl(.CurrentRow.Cells(13).Value) = 0 And CDbl(.CurrentRow.Cells(12).Value) = 0 Then Exit Sub

                    If CDbl(.CurrentRow.Cells(12).Value) = 0 Then
                        Me.dgDetails.CurrentRow.Cells(14).Value = CDbl(Me.dgDetails.CurrentRow.Cells(2).Value) + CDbl(Me.dgDetails.CurrentRow.Cells(13).Value)
                        'SetReturnRefundEntry("1010", 0, Format(CDbl(Me.dgDetails.CurrentRow.Cells(13).Value), "n2"))
                    Else
                        Me.dgDetails.CurrentRow.Cells(14).Value = CDbl(Me.dgDetails.CurrentRow.Cells(2).Value) - CDbl(Me.dgDetails.CurrentRow.Cells(12).Value)
                        'SetReturnRefundEntry("1010", Format(CDbl(Me.dgDetails.CurrentRow.Cells(12).Value), "n2"), 0)
                    End If
                    GetReturnRefundAmtGLEntry(Me.dgDetails, CDbl(.CurrentRow.Cells(12).Value), CDbl(.CurrentRow.Cells(13).Value))
                End With

                Me.txtTotal.Text = Format(SumAmount(Me.dgDetails, 14), "n2")
                Me.lblDebit.Text = Format(SumAmount(Me.dgPost, 10), "n2")
                Me.lblCredit.Text = Format(SumAmount(Me.dgPost, 11), "n2")
        End Select
    End Sub



    Private Sub btPost_Click(sender As Object, e As EventArgs) Handles btPost.Click
        If txtDateLiquidation.Text.Length = 0 Then
            MsgBox("Please indicate the liquidation date!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If Format(SumAmount(Me.dgPost, 10), "N2") <> Format(SumAmount(Me.dgPost, 11), "N2") Then
            MsgBox("Debit / Credit Column not equal", vbInformation, "System Message")
            Exit Sub
        End If

        Post(frmPCV.lblReqNbr.Text)
    End Sub



    Private Sub Post(ByVal str As String)

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL As New MySqlCommand
        Dim dtCurrent As Date

        If MsgBox("Are you sure you want to post?", vbYesNo, "Confirm Post") = vbNo Then
            Exit Sub
            Me.Close()
            Me.Dispose()
        Else
            dtCurrent = GetServerDate()

            Dim sSQL As String = "UPDATE tbl_request SET "
            sSQL += " REQ_Liquidated=@REQ_Liquidated, "
            sSQL += " REQ_LiquidatedBy=@REQ_LiquidatedBy, "
            sSQL += " REQ_LiquidatedAmount=@REQ_LiquidatedAmount, "
            sSQL += " REQ_LiquidatedDate=@REQ_LiquidatedDate, "
            sSQL += " REQ_LiquidationDate=@REQ_LiquidationDate "

            sSQL += " WHERE REQ_Nbr like '" & str & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters

                .AddWithValue("@REQ_Liquidated", 1)
                .AddWithValue("@REQ_LiquidatedBy", strCurrentUser)
                .AddWithValue("@REQ_LiquidatedDate", dtCurrent)
                .AddWithValue("@REQ_LiquidatedAmount", CDbl(Me.txtTotal.Text))
                .AddWithValue("@REQ_LiquidationDate", dtReceipt.Value)

            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()

            frmPCV.txtPostDate.Text = dtCurrent
            frmPCV.txtPostBy.Text = strCurrentUser
            frmPCV.txtReturnRefund.Text = Me.txtTotal.Text
            frmPCV.txtLiquidationDate.Text = Me.txtDateLiquidation.Text
            'save detail of liquidation

            'Delete record in tbl_requestd
            Dim cmdSysParamd As MySqlCommand
            Dim sqlStringd As String = "DELETE FROM tbl_requestd WHERE REQD_REQNbr = '" & frmPCV.lblReqNbr.Text & "'"

            cmdSysParamd = New MySqlCommand(sqlStringd, cnnDBMaster)
            cmdSysParamd.ExecuteNonQuery()

            cmdSysParamd.Dispose()

            Dim id As Integer = 0

            For id = 0 To Me.dgDetails.Rows.Count - 1
                Dim cmdSQLPart1d As New MySqlCommand
                Dim hd As DataGridViewRow
                cmdSQLPart1d.Connection = cnnDBMaster
                hd = Me.dgDetails.Rows(id)
                If Not Len(hd.Cells(1).Value) = 0 Then
                    Select Case frmPCV.txtType.Text
                        Case "ADM"
                            cmdSQLPart1d.CommandText = ("INSERT INTO tbl_requestd (REQD_REQNbr, REQD_Particulars, REQD_Qty, REQD_Unit, REQD_UnitCost, REQD_Amount, REQD_Index, REQD_CostCenter, REQD_ReturnAmt, REQD_RefundAmt, REQD_LiquidatedAmt)  VALUES " &
                                              "                   (@REQD_REQNbr, @REQD_Particulars, @REQD_Qty, @REQD_Unit, @REQD_UnitCost, @REQD_Amount, @REQD_Index, @REQD_CostCenter, @REQD_ReturnAmt, @REQD_RefundAmt, @REQD_LiquidatedAmt)")

                            With cmdSQLPart1d.Parameters
                                .AddWithValue("@REQD_REQNbr", frmPCV.lblReqNbr.Text)
                                .AddWithValue("@REQD_Particulars", hd.Cells(1).Value)
                                .AddWithValue("@REQD_Qty", CDbl(hd.Cells(2).Value))
                                .AddWithValue("@REQD_Unit", hd.Cells(3).Value)
                                .AddWithValue("@REQD_UnitCost", CDbl(hd.Cells(4).Value))
                                .AddWithValue("@REQD_Amount", CDbl(hd.Cells(5).Value))
                                .AddWithValue("@REQD_Index", hd.Index)
                                .AddWithValue("@REQD_CostCenter", hd.Cells(6).Value)
                                .AddWithValue("@REQD_ReturnAmt", CDbl(hd.Cells(7).Value))
                                .AddWithValue("@REQD_RefundAmt", CDbl(hd.Cells(8).Value))
                                .AddWithValue("@REQD_LiquidatedAmt", CDbl(hd.Cells(9).Value))
                            End With

                            cmdSQLPart1d.ExecuteNonQuery()
                        Case "OPR"
                            cmdSQLPart1d.CommandText = ("INSERT INTO tbl_requestd (REQD_REQNbr, REQD_Particulars, REQD_Amount, REQD_Index, REQD_BookNbr,  REQD_Shipper, REQD_Consignee, REQD_ContainerNo, REQD_HBL, REQD_Key,  REQD_CHCode, REQD_CostCenter, REQD_ReturnAmt, REQD_RefundAmt, REQD_LiquidatedAmt)  VALUES " &
                                              "                   (@REQD_REQNbr, @REQD_Particulars, @REQD_Amount, @REQD_Index, @REQD_BookNbr, @REQD_Shipper, @REQD_Consignee,  @REQD_ContainerNo, @REQD_HBL, @REQD_Key,  @REQD_CHCode, @REQD_CostCenter, @REQD_ReturnAmt, @REQD_RefundAmt, @REQD_LiquidatedAmt)")

                            With cmdSQLPart1d.Parameters
                                .AddWithValue("@REQD_REQNbr", frmPCV.lblReqNbr.Text)
                                .AddWithValue("@REQD_Particulars", hd.Cells(1).Value)
                                .AddWithValue("@REQD_Amount", CDbl(hd.Cells(2).Value))
                                .AddWithValue("@REQD_Index", hd.Index)
                                .AddWithValue("@REQD_BookNbr", hd.Cells(3).Value)
                                .AddWithValue("@REQD_Shipper", hd.Cells(4).Value)
                                .AddWithValue("@REQD_Consignee", hd.Cells(5).Value)
                                .AddWithValue("@REQD_ContainerNo", hd.Cells(6).Value)
                                .AddWithValue("@REQD_HBL", hd.Cells(7).Value)
                                .AddWithValue("@REQD_Key", hd.Cells(8).Value)
                                .AddWithValue("@REQD_CHCode", hd.Cells(9).Value)
                                .AddWithValue("@REQD_CostCenter", hd.Cells(11).Value)
                                .AddWithValue("@REQD_ReturnAmt", CDbl(hd.Cells(12).Value))
                                .AddWithValue("@REQD_RefundAmt", CDbl(hd.Cells(13).Value))
                                .AddWithValue("@REQD_LiquidatedAmt", CDbl(hd.Cells(14).Value))
                            End With

                            cmdSQLPart1d.ExecuteNonQuery()
                    End Select

                End If
                cmdSQLPart1d.Dispose()
            Next
            '*******
            'Delete record in tbl_pca 
            Dim cmdSysParam As MySqlCommand
            Dim sqlString1 As String = "DELETE FROM tbl_pca WHERE PCA_Nbr = '" & frmPCV.lblReqNbr.Text & "'"

            cmdSysParam = New MySqlCommand(sqlString1, cnnDBMaster)
            cmdSysParam.ExecuteNonQuery()
            cmdSysParam.Dispose()

            'save detail of account title
            Dim i As Integer
            Dim h As DataGridViewRow
            For i = 0 To Me.dgPost.Rows.Count - 1
                Dim cmdSQLPart1 As New MySqlCommand

                cmdSQLPart1.Connection = cnnDBMaster

                h = Me.dgPost.Rows(i)

                If Not Len(h.Cells(1).Value) = 0 Then
                    cmdSQLPart1.CommandText = ("INSERT INTO tbl_pca (PCA_Nbr, PCA_Account_Code, PCA_Account_Title, PCA_DR, PCA_CR, PCA_SubAccount_Code, PCA_SubAccount_Title, PCA_SubAccount_Dept, PCA_SubAccount_DeptName, PCA_SubAccount_List, PCA_SubAccount_ListItem, PCA_SubAccount_ListItemName)  VALUES " &
                                              "                   (@PCA_Nbr, @PCA_Account_Code, @PCA_Account_Title, @PCA_DR, @PCA_CR, @PCA_SubAccount_Code, @PCA_SubAccount_Title, @PCA_SubAccount_Dept, @PCA_SubAccount_DeptName, @PCA_SubAccount_List, @PCA_SubAccount_ListItem, @PCA_SubAccount_ListItemName )")

                    With cmdSQLPart1.Parameters
                        .AddWithValue("@PCA_Nbr", frmPCV.lblReqNbr.Text)
                        .AddWithValue("@PCA_Account_Code", h.Cells(1).Value)
                        .AddWithValue("@PCA_Account_Title", h.Cells(2).Value)
                        .AddWithValue("@PCA_SubAccount_Code", h.Cells(3).Value)
                        .AddWithValue("@PCA_SubAccount_Title", h.Cells(4).Value)
                        .AddWithValue("@PCA_SubAccount_Dept", h.Cells(5).Value)
                        .AddWithValue("@PCA_SubAccount_DeptName", h.Cells(6).Value)
                        .AddWithValue("@PCA_SubAccount_List", h.Cells(7).Value)
                        .AddWithValue("@PCA_SubAccount_ListItem", h.Cells(8).Value)
                        .AddWithValue("@PCA_SubAccount_ListItemName", h.Cells(9).Value)

                        If CStr(h.Cells(10).Value) <> "" Then
                            .AddWithValue("@PCA_DR", CDbl(h.Cells(10).Value))
                        Else
                            .AddWithValue("@PCA_DR", 0)
                        End If
                        If CStr(h.Cells(11).Value) <> "" Then
                            .AddWithValue("@PCA_CR", CDbl(h.Cells(11).Value))
                        Else
                            .AddWithValue("@PCA_CR", 0)
                        End If


                    End With

                    cmdSQLPart1.ExecuteNonQuery()
                End If
                cmdSQLPart1.Dispose()
            Next

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            MsgBox("Posted", vbInformation, "System Message")

            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub dtReceipt_ValueChanged(sender As Object, e As EventArgs) Handles dtReceipt.ValueChanged
        Me.txtDateLiquidation.Text = Format(Me.dtReceipt.Value, "yyyy-MM-dd")
    End Sub
    Private Sub SetReturnRefundEntry(ByVal strAcctCode As String, ByVal dblDR As Double, ByVal dblCR As Double)
        Dim strSQL As String, strDept As String = "", strSubAcctCode As String

        Select Case strFundKey
            Case "AISMNL"
                strSubAcctCode = "1"
            Case "MNLOPR"
                strSubAcctCode = "16"
            Case "TRKMNL"
                strSubAcctCode = "4"
            Case "AISCAV"
                strSubAcctCode = "5"
            Case "CAVOPR"
                strSubAcctCode = "17"
            Case "AISLAG"
                strSubAcctCode = "6"
            Case "LAGOPR"
                strSubAcctCode = "18"
            Case "AISCBU"
                strSubAcctCode = "7"
            Case "CBUOPR"
                strSubAcctCode = "19"
            Case "AISSBC"
                strSubAcctCode = "12"
            Case "SBCOPR"
                strSubAcctCode = "20"
            Case "AISDVO"
                strSubAcctCode = "13"
            Case "DVOOPR"
                strSubAcctCode = "21"
            Case "AISBTN"
                strSubAcctCode = "14"
            Case "BTNOPR"
                strSubAcctCode = "22"
            Case "AISBRI"
                strSubAcctCode = "26"
            Case "AISBRE"
                strSubAcctCode = "27"
            Case "AISSFR"
                strSubAcctCode = "28"
            Case Else

                strSubAcctCode = ""
        End Select

        strSQL = "SELECT lib_acctcode.*, lib_subacctcode.* " &
                "FROM lib_acctcode INNER JOIN lib_subacctcode ON lib_acctcode.Account_Code = lib_subacctcode.Account_Code " &
               "WHERE(((lib_acctcode.Account_Code) = '" & strAcctCode & "' and lib_subacctcode.SubAccount_Code = '" & strSubAcctCode & "')) "

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmd2.ExecuteReader()

        If reader2.HasRows = False Then
            cmd2.Dispose()
            reader2.Close()
            cnnDBMaster.Close()
            Exit Sub
        End If

        While reader2.Read
            If reader2.Item("SubAccount_Dept") = True Then
                'strDept = frmPCV.cboCostCenter.Text
            Else
                strDept = ""
            End If

            Dim i As Integer = 0
            Dim h As DataGridViewRow
            Dim intIndex As Integer = -1
            Dim RetRefExist As Boolean = False
            Dim dblReturn As Double = 0
            Dim dblRefund As Double = 0
            For i = 0 To Me.dgPost.Rows.Count - 1
                h = Me.dgPost.Rows(i)

                If h.Cells(1).Value = "1010" Then
                    RetRefExist = True
                    intIndex = i

                    Dim x As Integer = 0
                    Dim y As DataGridViewRow

                    For x = 0 To Me.dgDetails.Rows.Count - 1
                        y = Me.dgDetails.Rows(x)
                        Select Case frmPCV.txtType.Text
                            Case "ADM"
                                dblReturn = dblReturn + y.Cells(7).Value
                                dblRefund = dblRefund + y.Cells(8).Value
                            Case "OPR"
                                dblReturn = dblReturn + y.Cells(12).Value
                                dblRefund = dblRefund + y.Cells(13).Value
                        End Select
                    Next



                    Exit For
                End If

            Next

            If RetRefExist = True Then
                Me.dgPost.Rows(intIndex).Cells(10).Value = Format(dblReturn, "n2")
                Me.dgPost.Rows(intIndex).Cells(11).Value = Format(dblRefund, "n2")
            Else
                Me.dgPost.Rows.Add("", reader2.Item("Account_Code"), reader2.Item("Account_Title"), reader2.Item("SubAccount_Code"), reader2.Item("SubAccount_Title"), reader2.Item("SubAccount_Dept"), strDept, False, "", "", Format(dblDR, "n2"), Format(dblCR, "n2"))
            End If


        End While

        cmd2.Dispose()
        reader2.Close()
        cnnDBMaster.Close()
    End Sub
    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgPost_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPost.CellContentClick
        If Me.dgPost.Columns(e.ColumnIndex).Name.Equals("colSelectEntry") Then
            frmSelectGLEntry.Tag = "PCV"
            frmSelectGLEntry.txtLineNbr.Text = e.RowIndex
            frmSelectGLEntry.ShowDialog()
        End If
    End Sub

    Private Sub btAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        Me.dgPost.Rows.Add()
    End Sub

    Private Sub btRemove_Click(sender As Object, e As EventArgs) Handles btRemove.Click
        If Me.dgPost.Rows(Me.dgPost.CurrentRow.Index).Cells(1).Value <> "1010" Then
            If Not dgPost.CurrentRow.IsNewRow Then
                dgPost.Rows.Remove(dgPost.CurrentRow)
            End If
        End If
    End Sub

    Private Sub btClear_Click(sender As Object, e As EventArgs) Handles btClear.Click
        Me.dgPost.Rows.Clear()
        Me.btAdd.Enabled = True
        Me.btRemove.Enabled = True
        Me.btClear.Enabled = True
    End Sub

    Private Sub btCredit_Click(sender As Object, e As EventArgs) Handles btCredit.Click
        Dim dblTotalDR As Double

        For ctrRow As Integer = 0 To Me.dgPost.Rows.Count - 1
            With Me.dgPost.Rows(ctrRow)
                If Len(.Cells(10).Value) > 0 Then
                    .Cells(10).Value = Format(CDbl(.Cells(10).Value), "n2")
                    dblTotalDR += Format(CDbl(.Cells(10).Value), "n2")
                Else
                    .Cells(10).Value = "0.00"
                End If

                If Len(.Cells(11).Value) > 0 Then
                    .Cells(11).Value = Format(CDbl(.Cells(11).Value), "n2")
                Else
                    .Cells(11).Value = "0.00"
                End If
            End With
        Next


        SetCredit(frmPCV.lblReqNbr.Text)

        Me.btAdd.Enabled = False
        Me.btRemove.Enabled = False
        Me.btClear.Enabled = False
        Me.dgDetails.ReadOnly = True
        Me.lblDebit.Text = Format(SumAmount(Me.dgPost, 10), "n2")
        Me.lblCredit.Text = Format(SumAmount(Me.dgPost, 11), "n2")
        Me.btPost.Enabled = True
    End Sub

    Private Sub SetCredit(ByVal strVal As String)
        Dim strsql As String = "SELECT * FROM tbl_pcar WHERE PCAR_Nbr = '" & strVal & "' AND PCAR_DR > 0"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            Me.dgPost.Rows.Add("", reader.Item("PCAR_Account_Code"), reader.Item("PCAR_Account_Title"),
                                      reader.Item("PCAR_SubAccount_Code"), reader.Item("PCAR_SubAccount_Title"), reader.Item("PCAR_SubAccount_Dept"),
                                      reader.Item("PCAR_SubAccount_DeptName"), reader.Item("PCAR_SubAccount_List"), reader.Item("PCAR_SubAccount_ListItem"),
                                      reader.Item("PCAR_SubAccount_ListItemName"), "0.00", Format(reader.Item("PCAR_DR"), "n2"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub frmPettyCashPost_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Public Function SumAmount(ByVal dg As DataGridView, ByVal intIndex As Integer) As Double
        Dim i As Integer
        Dim h As DataGridViewRow

        For i = 0 To dg.Rows.Count - 1
            h = dg.Rows(i)
            If Not Len(h.Cells(intIndex).Value) = 0 Then
                SumAmount = SumAmount + h.Cells(intIndex).Value
            End If
        Next

        Return SumAmount
    End Function

    Private Sub dgPost_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgPost.CellEndEdit
        Me.lblDebit.Text = Format(SumAmount(Me.dgPost, 10), "n2")
        Me.lblCredit.Text = Format(SumAmount(Me.dgPost, 11), "n2")
    End Sub
End Class