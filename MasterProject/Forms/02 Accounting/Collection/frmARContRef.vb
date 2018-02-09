Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmARContRef
    Implements ICommonFunction
    Private EnableButtons As New clsEnableToolstripObjects()
    Dim blPosted As Boolean
    Private Sub frmARContRef_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        PopBank()

        Me.gpDetention.Visible = True
        Me.colDetentionAmt.Visible = True
        Me.colOtherCharge.Visible = True

        Me.lblStatus.Text = ""
        Me.tstxtSearch.Focus()

        Me.sslblCurrentUser.Text = "Current User : " & strCurrentUser & " "
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

        If Len(Me.tstxtSearch.Text) > 0 Then
            Me.tscmdSearch_Click(sender, e)
        End If
    End Sub

    Private Function CheckIfWithDetention(ByVal strRefNo As String) As Boolean
        CheckIfWithDetention = False

        Dim strsql As String = "SELECT WithDetention FROM ar_contref_arnumbers WHERE RefNo = '" & strRefNo & "'"
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnn)

        Dim reader As MySqlDataReader = cmdsql.ExecuteReader

        While reader.Read
            If reader.Item("WithDetention") = True Then
                CheckIfWithDetention = True
                Exit While
            End If
        End While

        reader.Close()
        cmdsql.Dispose()
    End Function


    Private Sub CloseBillingContRef(ByVal strRefNo As String)
        Dim strsql As String, strPosted As String, strPostedDate As String, strPostedBy As String, strBalance As String, strOutstanding As String
        Dim dtcurrent As Date = GetServerDate()

        If CDbl(Me.txtNewBal.Text) = 0 Then
            'strDBtable = "bill_impf"
            strBalance = "BCR_Balance"
            strOutstanding = "BCR_Outstanding"
            strPosted = "BCR_Paid"
            strPostedBy = "BCR_PaidBy"
            strPostedDate = "BCR_PaidDate"

            strsql = "UPDATE bcr_main SET" &
                                    " " & strPosted & "= @Posted, " &
                                    " " & strOutstanding & "= @Outstanding, " &
                                    " " & strPostedBy & "= @PostedBy, " &
                                    " " & strBalance & "= @Balance, " &
                                    " " & strPostedDate & "= @PostedDate " &
                                    " WHERE BCR_nbr = '" & strRefNo & "' AND BCR_Cancel = FALSE"

            Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
            If cnn.State <> ConnectionState.Open Then cnn.Open()

            Dim cmdSQL = New MySqlCommand(strsql, cnn)

            With cmdSQL.Parameters
                .AddWithValue("@Outstanding", False)
                .AddWithValue("@Balance", False)
                .AddWithValue("@Posted", True)
                .AddWithValue("@PostedBy", strCurrentUser)
                .AddWithValue("@PostedDate", dtcurrent)
            End With

            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()
        Else
            'strDBtable = "bill_impf"
            strBalance = "BCR_Balance"
            strPosted = "BCR_Paid"

            Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
            If cnn.State <> ConnectionState.Open Then cnn.Open()

            strOutstanding = "BCR_Outstanding"
            strsql = "UPDATE bcr_main SET" &
                                    " " & strPosted & "= @Posted, " &
                                    " " & strOutstanding & "= @Outstanding, " &
                                    " " & strBalance & "= @Balance " &
                                    " WHERE BCR_nbr = '" & strRefNo & "' AND BCR_Cancel = FALSE"

            Dim cmdSQL = New MySqlCommand(strsql, cnn)

            With cmdSQL.Parameters
                .AddWithValue("@Outstanding", False)
                .AddWithValue("@Balance", True)
                .AddWithValue("@Posted", False)

            End With

            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()
        End If
    End Sub


    Private Function CheckIfARNoExist(ByVal strARNo As String, ByVal strDBtable As String) As Boolean
        CheckIfARNoExist = False

        Dim strsql As String = "SELECT ARNo FROM ar_contref_arnumbers WHERE ARNo = '" & strARNo & "'"
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySqlCommand(strsql, cnn)

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            If IsDBNull(reader.Item("ARNo")) = False Then
                CheckIfARNoExist = True
            End If
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Function

    Private Function CheckRequiredEntries() As Boolean
        If Len(Trim$(Me.txtARNo.Text)) = 0 Then
            MsgBox("Please Input A.R. Number!", MsgBoxStyle.Exclamation, "System Message")
            Me.txtARNo.Focus()
            CheckRequiredEntries = False
            Exit Function
        End If

        If Me.dtgPayments.Rows.Count = 0 Then
            MsgBox("Please Input Payment Details!", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            Exit Function
        End If

        If Me.cboChargeTo.Text = "" And chkDetention.Checked = True Then
            MsgBox("Please choose from Charge To!", MsgBoxStyle.Exclamation, "System Message")
            CheckRequiredEntries = False
            Exit Function
        End If

        If Me.cboChargeTo.Text = "Employee" Then
            If txtChargeTo.Text = "" Then
                MsgBox("Please type Employee Name!", MsgBoxStyle.Exclamation, "System Message")
                CheckRequiredEntries = False
                Exit Function
            End If
        End If

        Dim intRow As Integer

        For intRow = 0 To Me.dtgPayments.Rows.Count - 1
            With Me.dtgPayments.Rows(intRow)
                If Len(.Cells(0).Value) > 0 Then
                    If Len(.Cells(1).Value) = 0 Then
                        MsgBox("Select Payment Type in Row " & intRow + 1 & ".", MsgBoxStyle.Exclamation, "System message")
                        CheckRequiredEntries = False
                        Exit Function
                    End If

                    If .Cells(1).Value = "Check" And (Len(.Cells(2).Value) = 0 Or Len(.Cells(3).Value) = 0) Then
                        MsgBox("Complete Check Details in Row " & intRow + 1 & ".", MsgBoxStyle.Exclamation, "System message")
                        CheckRequiredEntries = False
                        Exit Function
                    End If
                End If
            End With
        Next

        CheckRequiredEntries = True
    End Function

    Private Sub ClearAll()
        Dim obj As List(Of Object)

        Me.tstxtSearch.Text = ""

        'CLEAR BILLING ENTRIES
        obj = (From x In gpBilling.Controls Where
              x.GetType Is GetType(TextBox) Select x).ToList

        For Each item As TextBox In obj
            item.Text = ""
        Next

        Me.dtgCharges.Rows.Clear()

        obj = (From x In gpAllARDetails.Controls Where
              x.GetType Is GetType(TextBox) Select x).ToList

        For Each item As TextBox In obj
            item.Text = ""
        Next

        'CLEAR AR
        obj = (From x In gpAR.Controls Where
              x.GetType Is GetType(TextBox) Select x).ToList

        For Each item As TextBox In obj
            item.Text = ""
        Next

        Me.dtgPayments.Rows.Clear()
        Me.dtgCharges.Rows.Clear()

        Me.chkDetention.Checked = False
        Me.txtDetentionAmt.Text = "0.00"

        'CLEAR ALLAR
        Me.dtgAllAR.Rows.Clear()

        'CLEAR ACCTG ENTRY
        Me.dtgAcctgTitle.Rows.Clear()
        Me.txtDRTotal.Text = ""
        Me.txtCRTotal.Text = ""

        Me.sslblDateSaved.Text = ""
        Me.sslblPrepBy.Text = ""
        Me.sslblStatus.Text = ""
        Me.lblStatus.Text = ""

        Me.loadChargeTo()
        Me.txtEmpID.Text = ""
        txtChargeTo.Text = ""
    End Sub

    Private Sub ComputeDRCR()
        Dim dblDR As Double = 0
        Dim dblCR As Double = 0

        For intRow = 0 To Me.dtgAcctgTitle.Rows.Count - 1
            With Me.dtgAcctgTitle.Rows(intRow)
                dblDR = dblDR + CDbl(.Cells(9).Value)
                dblCR = dblCR + CDbl(.Cells(10).Value)
            End With
        Next

        Me.txtDRTotal.Text = Format$(dblDR, "n2")
        Me.txtCRTotal.Text = Format$(dblCR, "n2")
    End Sub

    Private Sub ComputePayment()
        Dim dblAmt As Double = 0

        Dim introw As Integer

        '>AR DETENTION
        If Me.chkDetention.Checked = True And IsNumeric(Me.txtDetentionAmt.Text) = True Then
            'Me.txtDetentionAmt.Text = Format$(CDbl(Me.txtDetentionAmt.Text), "n2")
        Else
            Me.txtDetentionAmt.Text = "0.00"
        End If

        '>AR DETENTION
        If Me.chkOtherCharge.Checked = True And IsNumeric(Me.txtDetentionAmt.Text) = True Then
        Else
            Me.txtOtherCharge.Text = "0.00"
        End If

        '>AR PAYMENT
        dblAmt = 0
        Dim dblCash As Double = 0
        Dim dblCheck As Double = 0

        For introw = 0 To Me.dtgPayments.Rows.Count - 1
            With Me.dtgPayments.Rows(introw)
                dblAmt = dblAmt + (.Cells(0).Value)
                If .Cells(1).Value = "Cash" Then
                    dblCash = dblCash + CDbl(.Cells(0).Value)
                ElseIf .Cells(1).Value = "Check" Then
                    dblCheck = dblCheck + CDbl(.Cells(0).Value)
                End If
            End With
        Next
        '>END AR PAYMENT

        Me.txtARTotalAmt.Text = Format$(dblAmt, "n2")
        Me.txtARCshAmt.Text = Format$(dblCash, "n2")
        Me.txtARChkAmt.Text = Format$(dblCheck, "n2")

        '>NEW BALANCE
        Dim intARRow As Integer = GetARNoRow()

        If IsNumeric(Me.txtBalance.Text) = True And IsNumeric(Me.txtARTotalAmt.Text) = True Then
            If Me.txtARNo.Enabled = True Then
                Me.txtNewBal.Text = Format$(CDbl(Me.txtBalance.Text) - (CDbl(Me.txtARTotalAmt.Text) + CDbl(Me.txtDetentionAmt.Text) + CDbl(Me.txtOtherCharge.Text)), "n2")
            Else
                Me.txtNewBal.Text = Format$(((CDbl(Me.txtBalance.Text) + CDbl(Me.dtgAllAR.Rows(intARRow).Cells(colARAmt.Name).Value) + CDbl(Me.dtgAllAR.Rows(intARRow).Cells(colDetentionAmt.Name).Value) + CDbl(Me.dtgAllAR.Rows(intARRow).Cells(colOtherCharge.Name).Value)) - CDbl(Me.txtOverPay.Text)) - (CDbl(Me.txtARTotalAmt.Text) + CDbl(Me.txtDetentionAmt.Text)), "n2")
            End If
        End If
        '>END NEW BALANCE
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

        End With

    End Sub
    Private Function GetARNoRow() As Integer
        GetARNoRow = 0
        Dim introw As Integer

        For introw = 0 To Me.dtgAllAR.Rows.Count - 1
            If Me.dtgAllAR.Rows(introw).Cells(0).Value = Me.txtARNo.Text Then
                GetARNoRow = introw
                Exit Function
            End If
        Next
    End Function

    Private Sub LoadAllAR(ByVal strRefNo As String)
        Dim strDBtable As String = "", strDetention As String, strOtherCharge As String

        Dim strsql As String = "SELECT * FROM ar_contref_arnumbers WHERE RefNo = '" & strRefNo & "' AND Cancel = FALSE ORDER BY PrepDate"

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySqlCommand(strsql, cnn)

        Me.dtgAllAR.Rows.Clear()

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read

            strDetention = Format$(CDbl(reader.Item("DetentionAmt")), "n2")
            strOtherCharge = Format$(CDbl(reader.Item("OtherChargeAmt")), "n2")

            Me.dtgAllAR.Rows.Add(reader.Item("ARNo"), Format$(reader.Item("ARAmt"), "n2"), Format$(reader.Item("ARCshAmt"), "n2"), Format$(reader.Item("ARChkAmt"), "n2"), strDetention, strOtherCharge, reader.Item("PrepBy"), Format$(CDate(reader.Item("PrepDate")), "MM/dd/yyyy"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub PopBank()
        Dim strSQL As String = "SELECT Code, Name FROM lib_bank"

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySqlCommand(strSQL, cnn)

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        Me.colBank.Items.Clear()

        While reader.Read
            Me.colBank.Items.Add(reader.Item("Name"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub PopdtgAcctgEntry()
        'If Me.dtgPayments.Rows.Count = 0 Then Exit Sub

        Dim dblCash As Double = 0
        Dim dblCheck As Double = 0

        Me.dtgAcctgTitle.Rows.Clear()

        If IsNumeric(Me.txtARCshAmt.Text) = True Then
            If CDbl(Me.txtARCshAmt.Text) > 0 Then
                PopdtgAcctgEntryRow("1010", "2", CDbl(Me.txtARCshAmt.Text), "0.00")
            End If
        End If

        If IsNumeric(Me.txtARChkAmt.Text) = True Then
            If CDbl(Me.txtARChkAmt.Text) > 0 Then
                PopdtgAcctgEntryRow("1120", "1", CDbl(Me.txtARChkAmt.Text), "0.00")
            End If
        End If
        Dim OtherCharges As Double = 0

        OtherCharges = CDbl(Me.txtDetentionAmt.Text) + CDbl(Me.txtOtherCharge.Text)

        If IsNumeric(Me.txtDetentionAmt.Text) = True Then
            If OtherCharges > 0 Then
                If Mid$(Trim$(Me.txtHBL.Text), 1, 2) = "IM" Then
                    If cboChargeTo.Text = "Client" Then
                        PopdtgAcctgEntryRow("2020", "1", OtherCharges, "0.00")
                    ElseIf cboChargeTo.Text = "" Then
                        PopdtgAcctgEntryRow("5100", "5", OtherCharges, "0.00")
                    ElseIf cboChargeTo.Text = "Employee" Then
                        PopdtgAcctgEntryRow("1160", "2", OtherCharges, "0.00")
                    End If
                ElseIf Mid$(Trim$(Me.txtHBL.Text), 1, 3) = "EX" Then
                    If cboChargeTo.Text = "Client" Then
                        PopdtgAcctgEntryRow("2020", "2", OtherCharges, "0.00")
                    ElseIf cboChargeTo.Text = "" Then
                        PopdtgAcctgEntryRow("5200", "5", OtherCharges, "0.00")
                    ElseIf cboChargeTo.Text = "Employee" Then
                        PopdtgAcctgEntryRow("1160", "2", OtherCharges, "0.00")
                    End If
                End If
            End If

            If IsNumeric(Me.txtTotalBilling.Text) = True Then
                If CDbl(Me.txtTotalBilling.Text) > 0 Then
                    If Mid$(Trim$(Me.txtHBL.Text), 1, 2) = "IM" Then
                        PopdtgAcctgEntryRow("1140", "1", "0.00", CDbl(Me.txtARTotalAmt.Text) + OtherCharges)
                    ElseIf Mid$(Trim$(Me.txtHBL.Text), 1, 2) = "EX" Then
                        PopdtgAcctgEntryRow("1140", "2", "0.00", CDbl(Me.txtARTotalAmt.Text) + OtherCharges)
                    End If
                End If
            End If
        End If


        ComputeDRCR()
    End Sub

    Private Sub PopdtgAcctgEntryRow(ByVal strCode As String, ByVal strSubCode As String, ByVal dblDR As Double, ByVal dblCR As Double)
        Dim strsql As String = "SELECT lib_acctcode.*, lib_subacctcode.* FROM lib_acctcode LEFT JOIN lib_subacctcode ON lib_acctcode.Account_Code = lib_subacctcode.Account_Code" &
                                " WHERE lib_acctcode.Account_Code = '" & strCode & "' AND lib_subacctcode.SubAccount_Code = '" & strSubCode & "'"

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnn)

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
                    strShip = Me.txtClientName.Text
                ElseIf strList = "Local and Government Agency" Then
                    strShip = "Bureau of Internal Revenue"
                End If
            End If

            Me.dtgAcctgTitle.Rows.Add(reader.Item("Account_Code"), reader.Item("Account_Title"), reader.Item("SubAccount_Code"), reader.Item("SubAccount_Title"), CBool(reader.Item("SubAccount_Dept")), strDept, CBool(reader.Item("SubAccount_List")), strList, strShip, Format$(CDbl(dblDR), "n2"), Format$(CDbl(dblCR), "n2"), strSubCode)
        End While

        reader.Close()
        cmdsql.Dispose()
        cnn.Close()
    End Sub

    Private Sub RetrieveAcctgEntry(ByVal strARNo As String)

        Dim strsql As String = "SELECT * FROM ar_contref_acctg_entry WHERE ARNo = '" & strARNo & "' ORDER BY PKey"

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnn)

        Dim reader As MySqlDataReader = cmdsql.ExecuteReader

        Me.dtgAcctgTitle.Rows.Clear()
        While reader.Read
            Me.dtgAcctgTitle.Rows.Add(reader.Item("AcctCode"), reader.Item("AcctTitle"), reader.Item("SubAcctCode"), reader.Item("SubAcctTitle"), CBool(reader.Item("SubAcctDept")), reader.Item("SubAcctDeptName"), CBool(reader.Item("SubAcctList")), reader.Item("SubAcctListItem"), reader.Item("SubAcctListItemName"), Format$(reader.Item("DR"), "n2"), Format$(reader.Item("CR"), "n2"))
        End While

        reader.Close()
        cmdsql.Dispose()

        ComputeDRCR()
    End Sub

    Private Sub RetrieveAR(ByVal strRefNo As String)

        Dim strsql As String = "SELECT * FROM ar_contref_bill WHERE RefNo = '" & strRefNo & "'"

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySqlCommand(strsql, cnn)

        Me.dtgPayments.Rows.Clear()

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        Me.txtAmtPaid.Text = "0.00"
        While reader.Read
            Me.txtAmtPaid.Text = Format$(reader.Item("AmtPaid"), "n2")
            If reader.Item("Posted") = True Then
                Me.sslblStatus.Text = "Status : Posted "
            Else
                Me.sslblStatus.Text = "Status : Open "
            End If
        End While

        reader.Close()
        cmdSQL.Dispose()

        Me.gpAR.Enabled = False
        Me.gpAllARDetails.Enabled = False
        Me.dtgAllAR.Enabled = True
    End Sub

    Public Sub RetrieveARNo(ByVal strORNo As String)


        Dim strsql As String = "SELECT ar_contref_arnumbers.*, ar_contref_payments.*" &
                                " FROM ar_contref_arnumbers LEFT JOIN ar_contref_payments" &
                                " ON ar_contref_arnumbers.ARNo = ar_contref_payments.ARNo" &
                                " WHERE ar_contref_arnumbers.ARNo = '" & strORNo & "'"

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySqlCommand(strsql, cnn)

        Me.dtgPayments.Rows.Clear()

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            Me.chkDetention.Checked = CBool(reader.Item("WithDetention"))
            Me.chkOtherCharge.Checked = CBool(reader.Item("WithOtherCharge"))
            Me.txtDetentionAmt.Text = Format$(CDbl(reader.Item("DetentionAmt")), "n2")
            Me.txtOtherCharge.Text = Format$(CDbl(reader.Item("OtherChargeAmt")), "n2")
            Me.txtOtherChargeDesc.Text = reader.Item("OtherChargeDesc")
            Me.loadChargeTo()
            If IsDBNull(reader.Item("chargeTo")) = False Then
                Me.cboChargeTo.Text = reader.Item("chargeTo")
            End If
            If Me.cboChargeTo.Text = "Employee" Then
                txtEmpID.Text = reader.Item("chargedTo")
                txtChargeTo.Text = ""
            End If

            Me.txtARNo.Text = reader.Item("ARNo")
            Me.sslblPrepBy.Text = "Prepared By : " & reader.Item("PrepBy") & " "
            Me.sslblDateSaved.Text = "Date Saved : " & reader.Item("PrepDate") & " "
            Me.txtARTotalAmt.Text = Format$(CDbl(reader.Item("ARAmt")), "n2")
            Me.txtARCshAmt.Text = Format$(CDbl(reader.Item("ARCshAmt")), "n2")
            Me.txtARChkAmt.Text = Format$(CDbl(reader.Item("ARChkAmt")), "n2")
            Me.txtNewBal.Text = ""
            Me.dtgPayments.Rows.Add(Format$(reader.Item("PaymentAmt"), "n2"), reader.Item("PaymentType"), reader.Item("ChkNo"), reader.Item("Bank"))
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub SaveAcctgEntry()

        Dim strsql As String = "DELETE FROM ar_contref_acctg_entry WHERE ARNo = '" & Me.txtARNo.Text & "'"

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnn)

        cmdsql.ExecuteNonQuery()

        Dim ctrRow As Integer

        For ctrRow = 0 To Me.dtgAcctgTitle.Rows.Count - 1
            With Me.dtgAcctgTitle.Rows(ctrRow)
                strsql = "INSERT INTO ar_contref_acctg_entry (ARNo, AcctCode, AcctTitle, SubAcctCode," &
                            " SubAcctTitle, SubAcctDept, SubAcctDeptName," &
                            " SubAcctList, SubAcctListItem, SubAcctListItemName, DR, CR)" &
                            " VALUES ('" & Me.txtARNo.Text & "', '" & .Cells(0).Value & "', '" & .Cells(1).Value & "'," &
                            " '" & Replace(.Cells(2).Value, "'", "''") & "', '" & Replace(.Cells(3).Value, "'", "''") & "', " & Replace(.Cells(4).Value, "'", "''") & ", '" & Replace(.Cells(5).Value, "'", "''") & "'," &
                            " " & Replace(.Cells(6).Value, "'", "''") & ", '" & Replace(.Cells(7).Value, "'", "''") & "', '" & Replace(.Cells(8).Value, "'", "''") & "'," &
                            " " & CDbl(.Cells(9).Value) & ", " & CDbl(.Cells(10).Value) & ")"

                cmdsql = New MySqlCommand(strsql, cnn)

                cmdsql.ExecuteNonQuery()
            End With
        Next

        cmdsql.Dispose()
    End Sub

    Private Sub SaveAR(ByVal RefNo As String)
        Dim strsql As String, blPost As Boolean
        Dim dtCurrent As Date = GetServerDate()

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        If Me.dtgAllAR.Rows.Count = 0 Then
            'NEW
            If CDbl(Me.txtNewBal.Text) = 0 Then
                blPost = True
                strsql = "INSERT INTO ar_contref_bill (RefNo, Client, ARTotalBilling, AmtPaid, Posted, PostedBy, PostedDate)" &
                            " VALUES (@RefNo, @Client, @ARTotalBilling, @AmtPaid, @Posted, @PostedBy, @PostedDate)"
            Else
                blPost = False
                strsql = "INSERT INTO ar_contref_bill (RefNo, Client, ARTotalBilling, AmtPaid, Posted)" &
                            " VALUES (@RefNo, @Client, @ARTotalBilling, @AmtPaid, @Posted)"

            End If

            Dim cmdSQL = New MySqlCommand(strsql, cnn)

            With cmdSQL.Parameters
                .AddWithValue("@RefNo", Me.txtBillNo.Text)
                .AddWithValue("@Client", Me.txtClientName.Text)
                .AddWithValue("@ARTotalBilling", CDbl(Me.txtTotalBilling.Text))
                .AddWithValue("@AmtPaid", CDbl(Me.txtARTotalAmt.Text))
                .AddWithValue("@Posted", blPost)
                If blPost = True Then
                    .AddWithValue("@PostedBy", strCurrentUser)
                    .AddWithValue("@PostedDate", dtCurrent)
                End If
            End With

            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            'save translogs
            SaveTransLogs("Create new Container Refund Collection", Me.Name, "Cont.Ref. Ctrl No.", Me.txtBillNo.Text, strCurrentUser)
        Else
            'EDIT
            If CDbl(Me.txtNewBal.Text) <= 0 Then
                blPost = True
                strsql = "UPDATE ar_contref_bill SET" &
                            " AmtPaid = @AmtPaid," &
                            " Posted = @Posted," &
                            " PostedBy = @PostedBy," &
                            " PostedDate = @PostedDate" &
                            " WHERE RefNo = '" & Me.txtBillNo.Text & "'"
            Else
                blPost = False
                strsql = "UPDATE ar_contref_bill SET" &
                            " AmtPaid = @AmtPaid," &
                            " Posted = @Posted" &
                            " WHERE RefNo = '" & Me.txtBillNo.Text & "'"

            End If

            Dim cmdSQL = New MySqlCommand(strsql, cnn)

            With cmdSQL.Parameters
                If Me.txtARNo.Enabled = True Then
                    .AddWithValue("@AmtPaid", CDbl(Me.txtAmtPaid.Text) + CDbl(Me.txtARTotalAmt.Text))
                Else
                    .AddWithValue("@AmtPaid", (CDbl(Me.txtAmtPaid.Text) - CDbl(Me.dtgAllAR.Rows(GetARNoRow).Cells(1).Value)) + CDbl(Me.txtARTotalAmt.Text))
                End If
                .AddWithValue("@Posted", blPost)
                If blPost = True Then
                    .AddWithValue("@PostedBy", strCurrentUser)
                    .AddWithValue("@PostedDate", dtCurrent)
                End If
            End With

            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            'save translogs
            SaveTransLogs("Edit Container Refund Collection", Me.Name, "Cont.Ref. Ctrl No.", Me.txtBillNo.Text, strCurrentUser)
        End If

        CloseBillingContRef(Me.txtBillNo.Text)
    End Sub

    Private Sub SaveARNumbers(ByVal strRefNo As String, ByVal strARNo As String)
        Dim strsql As String
        Dim dtCurrent As Date = GetServerDate()

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        strsql = "DELETE FROM ar_contref_arnumbers WHERE RefNo = '" & strRefNo & "' AND ARNo = '" & strARNo & "'"

        Dim cmdSQL = New MySqlCommand(strsql, cnn)

        cmdSQL.ExecuteNonQuery()

        strsql = "INSERT INTO ar_contref_arnumbers (RefNo, ARNo, PrepBy, PrepDate, ARCshAmt, ARChkAmt, ARAmt, Cancel, WithDetention, DetentionAmt, WithOtherCharge, OtherChargeAmt, OtherChargeDesc, chargeTo, chargedTo)" &
                    "VALUES (@RefNo, @ARNo, @PrepBy, @PrepDate, @ARCshAmt, @ARChkAmt, @ARAmt, @Cancel, @WithDetention, @DetentionAmt, @WithOtherCharge, @OtherChargeAmt, @OtherChargeDesc, @chargeTo, @chargedTo)"

        cmdSQL = New MySqlCommand(strsql, cnn)

        With cmdSQL.Parameters
            .AddWithValue("@RefNo", Me.txtBillNo.Text)
            .AddWithValue("@ARNo", Me.txtARNo.Text)
            .AddWithValue("@PrepBy", strCurrentUser)
            .AddWithValue("@PrepDate", dtCurrent)
            .AddWithValue("@ARCshAmt", CDbl(Me.txtARCshAmt.Text))
            .AddWithValue("@ARChkAmt", CDbl(Me.txtARChkAmt.Text))
            .AddWithValue("@ARAmt", CDbl(Me.txtARTotalAmt.Text))
            .AddWithValue("@Cancel", False)
            .AddWithValue("@WithDetention", Me.chkDetention.Checked)
            .AddWithValue("@DetentionAmt", CDbl(Me.txtDetentionAmt.Text))
            .AddWithValue("@WithOtherCharge", Me.chkOtherCharge.Checked)
            .AddWithValue("@OtherChargeAmt", CDbl(Me.txtOtherCharge.Text))
            .AddWithValue("@OtherChargeDesc", Me.txtOtherChargeDesc.Text)
            If cboChargeTo.Text <> "" Then
                .AddWithValue("@chargeTo", Me.cboChargeTo.Text)
                If cboChargeTo.Text = "Employee" Then
                    .AddWithValue("@chargedTo", Me.txtEmpID.Text)
                ElseIf cboChargeTo.Text = "Client" Then
                    .AddWithValue("@chargedTo", Me.txtClientName.Text)
                End If
            Else
                .AddWithValue("@chargeTo", "n/a")
                .AddWithValue("@chargedTo", "n/a")
            End If
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
    End Sub

    Private Sub SaveARPayments(ByVal strRefNo As String, ByVal strARNo As String)
        Dim strsql As String

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        strsql = "DELETE FROM ar_contref_payments WHERE RefNo = '" & strRefNo & "' AND ARNo = '" & strARNo & "'"

        Dim cmdSQL = New MySqlCommand(strsql, cnn)

        cmdSQL.ExecuteNonQuery()

        Dim intRow As Integer

        For intRow = 0 To Me.dtgPayments.Rows.Count - 1
            strsql = "INSERT INTO ar_contref_payments (RefNo, ARNo, PaymentAmt, PaymentType, ChkNo, Bank)" &
                        " VALUES (@RefNo, @ARNo, @PaymentAmt, @PaymentType, @ChkNo, @Bank)"

            cmdSQL = New MySqlCommand(strsql, cnn)

            With cmdSQL.Parameters
                .AddWithValue("@RefNo", Me.txtBillNo.Text)
                .AddWithValue("@ARNo", Me.txtARNo.Text)
                .AddWithValue("@PaymentAmt", CDbl(Me.dtgPayments.Rows(intRow).Cells(0).Value))
                .AddWithValue("@PaymentType", Me.dtgPayments.Rows(intRow).Cells(1).Value)
                .AddWithValue("@ChkNo", Me.dtgPayments.Rows(intRow).Cells(2).Value.ToString)
                .AddWithValue("@Bank", Me.dtgPayments.Rows(intRow).Cells(3).Value.ToString)
            End With

            cmdSQL.ExecuteNonQuery()
        Next

        cmdSQL.Dispose()
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Me.dtgPayments.CurrentCell.ColumnIndex = 0 Then
            SetCharacter(MyOption.Numeric, e)
        Else
            SetCharacter(MyOption.AlphaNumeric, e)
        End If
    End Sub

    Private Sub loadChargeTo()
        cboChargeTo.Items.Clear()
        cboChargeTo.Items.Add("")
        cboChargeTo.Items.Add("Client")
        cboChargeTo.Items.Add("Employee")
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If blPosted = False Then
            MsgBox("Billing No. " & Me.txtBillNo.Text & " is not Posted yet! Cannot create A.R. unless Billing is Posted!", MsgBoxStyle.Information, "System Message")
            Exit Sub
        End If

        If Me.sslblStatus.Text = "Status : Posted " Then
            'MsgBox("Already Posted. Cannot Create Additional O.R.", MsgBoxStyle.Exclamation, "System Message")
            'Exit Sub
        End If

        'If GetBooleanValue("Select Allow_AR_New from tbl_users where Username = '" & strCurrentUser & "'", "Allow_AR_New") = False Then
        '    MsgBox("You are not allowed to add new record", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If CheckIfWithDetention(Me.txtBillNo.Text) = True Then
            Me.chkDetention.Enabled = False
        Else
            Me.chkDetention.Enabled = True
        End If

        Me.gpAR.Enabled = True
        Me.gpAllARDetails.Enabled = True
        Me.dtgAllAR.Enabled = False
        Me.txtARNo.Enabled = True

        If Me.dtgAllAR.Rows.Count = 0 Then
            Me.txtAmtPaid.Text = "0.00"
        End If

        Me.txtARTotalAmt.Text = "0.00"
        Me.txtARCshAmt.Text = "0.00"
        Me.txtARChkAmt.Text = "0.00"

        Me.txtARNo.Text = ""
        Me.txtARNo.Enabled = True
        loadChargeTo()
        Me.dtgPayments.Rows.Clear()

        Me.chkDetention.Checked = False
        Me.txtDetentionAmt.Text = "0.00"
        Me.txtOtherCharge.Text = "0.00"

        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)

        Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        If Me.sslblStatus.Text = "Status : Posted " Then
            MsgBox("Already Posted. Cannot Edit O.R.", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If
        'If GetBooleanValue("Select Allow_AR_Edit from tbl_users where Username = '" & strCurrentUser & "'", "Allow_AR_Edit") = False Then
        '    MsgBox("You are not allowed to edit record", vbInformation, "System Message")
        '    Exit Sub
        'End If
        Me.gpAR.Enabled = True
        Me.gpAllARDetails.Enabled = True
        Me.dtgAllAR.Enabled = False
        Me.txtARNo.Enabled = False

        If Me.chkDetention.Checked = False Then

            If CheckIfWithDetention(Me.txtBillNo.Text) = True Then
                Me.chkDetention.Enabled = False
            Else
                Me.chkDetention.Enabled = False
            End If

        Else
            Me.gpDetention.Enabled = True
        End If

        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        Me.dtgPayments.EndEdit()

        If CheckRequiredEntries() = False Then Exit Sub

        ComputePayment()
        PopdtgAcctgEntry()

        If Len(Me.sslblDateSaved.Text) = 0 Then
            If CheckIfARNoExist(Me.txtARNo.Text, "impf") = True Or CheckIfARNoExist(Me.txtARNo.Text, "impb") = True Or CheckIfARNoExist(Me.txtARNo.Text, "exp") = True Or CheckIfARNoExist(Me.txtARNo.Text, "contref") = True Then
                MsgBox("A.R. No. " & Me.txtARNo.Text & " Already Exists!", MsgBoxStyle.Exclamation, "System Message")
                Exit Sub
            End If
        End If

        If CDbl(Me.txtNewBal.Text) <= 0 Then
            If MsgBox("A.R. has no more remaining balance. A.R. will be posted. Continue saving?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
                Exit Sub
            End If
        Else
            If MsgBox("A.R. still has " & Me.txtNewBal.Text & " remaining balance. A.R. will NOT be posted. Continue saving?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        SaveAR(Me.txtBillNo.Text)
        SaveARNumbers(Me.txtBillNo.Text, Me.txtARNo.Text)
        SaveARPayments(Me.txtBillNo.Text, Me.txtARNo.Text)
        SaveAcctgEntry()

        'If Me.dtgAllAR.Rows.Count = 0 Then
        'If Me.tslblPrefix.Text <> "BCRMNL" Then
        'CloseBilling(Me.txtBillNo.Text)
        'End If
        'End If

        LoadAllAR(Me.txtBillNo.Text)
        RetrieveAR(Me.txtBillNo.Text)
        RetrieveARNo(Me.txtARNo.Text)
        RetrieveAcctgEntry(Me.txtARNo.Text)

        Me.gpAR.Enabled = False
        Me.gpAllARDetails.Enabled = False
        Me.dtgAllAR.Enabled = True
        MsgBox("A.R. No. " & Me.txtARNo.Text & " Saved", MsgBoxStyle.Information, "System Message")

        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        ClearAll()
        Me.gpAllARDetails.Enabled = False
        Me.gpAR.Enabled = False

        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        Throw New NotImplementedException()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        If Me.sslblStatus.Text = "Status : Posted " Then
            MsgBox("Cannot Cancel Posted A.R.", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If
        'If GetBooleanValue("Select Allow_AR_Cancel from tbl_users where Username = '" & strCurrentUser & "'", "Allow_AR_Cancel") = False Then
        '    MsgBox("You are not allowed to cancel record", vbInformation, "System Message")
        '    Exit Sub
        'End If
        If MsgBox("Are You Sure You Want to CANCEL Record!" & vbNewLine & "Billing Ref. No. : " &
                Me.txtBillNo.Text & vbNewLine & "A.R. No. : " & Me.txtARNo.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim strsql = "UPDATE ar_contref_arnumbers SET" &
                        " Cancel = @Cancel," &
                        " CancelBy = @CancelBy," &
                        " CancelDate = @CancelDate" &
                        " WHERE ARNo = '" & Me.txtARNo.Text & "' AND Cancel = False"

        Dim dtCurrent As Date = GetServerDate()
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySqlCommand(strsql, cnn)

        With cmdSQL.Parameters
            .AddWithValue("@Cancel", True)
            .AddWithValue("@CancelBy", strCurrentUser)
            .AddWithValue("@CancelDate", dtCurrent)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()

        'save trans logs
        SaveTransLogs("Cancel Container Refund Collection", Me.Name, "Cont. Refund Ctrl No.", Me.txtBillNo.Text, strCurrentUser)
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        Throw New NotImplementedException()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub tstxtSearch_Click(sender As Object, e As EventArgs) Handles tstxtSearch.Click

    End Sub

    Private Sub tstxtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtSearch.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            Me.tscmdSearch_Click(sender, e)
        End If
    End Sub

    Private Sub picRefresh_Click(sender As Object, e As EventArgs) Handles picRefresh.Click
        If Len(Me.txtBillNo.Text) > 0 Then
            SearchContBilling(Me.txtBillNo.Text)

            If Len(Me.txtBillNo.Text) > 0 Then
                If blPosted = True Then
                    Me.lblStatus.Text = "Posted"
                Else
                    Me.lblStatus.Text = "Open"
                End If
            Else
                Me.lblStatus.Text = ""
            End If

            LoadAllAR(Me.txtBillNo.Text)
            RetrieveAR(Me.txtBillNo.Text)
            RetrieveAcctgEntry(Me.txtARNo.Text)
            If Len(Me.txtBillNo.Text) > 0 Then
                ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
            End If
        End If
    End Sub

    Private Sub txtAmtPaid_TextChanged(sender As Object, e As EventArgs) Handles txtAmtPaid.TextChanged
        Dim dblAmt As Double, dblDetention As Double, dblOtherCharge As Double

        dblDetention = 0
        dblOtherCharge = 0

        For intRow = 0 To Me.dtgAllAR.Rows.Count - 1
            dblDetention = dblDetention + CDbl(Me.dtgAllAR.Rows(intRow).Cells(colDetentionAmt.Name).Value)
            dblOtherCharge = dblOtherCharge + CDbl(Me.dtgAllAR.Rows(intRow).Cells(colOtherCharge.Name).Value)
        Next


        If IsNumeric(Me.txtTotalBilling.Text) = True And IsNumeric(txtAmtPaid.Text) = True Then
            dblAmt = CDbl(Me.txtTotalBilling.Text) - (CDbl(txtAmtPaid.Text) + dblDetention + dblOtherCharge)
            If dblAmt >= 0 Then
                Me.txtBalance.Text = Format$(dblAmt, "n2")
                Me.txtOverPay.Text = "0.00"
            Else
                Me.txtOverPay.Text = Format$(Math.Abs(dblAmt), "n2")
                Me.txtBalance.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub dtgPayments_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgPayments.CellContentClick

    End Sub

    Private Sub dtgPayments_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgPayments.CellEndEdit
        Dim intRow As Integer

        For intRow = 0 To Me.dtgPayments.Rows.Count - 1
            With Me.dtgPayments.Rows(intRow)
                .Cells(0).Value = Format$(CDbl(.Cells(0).Value), "n2")

                If .Cells(1).Value = "Check" Then
                    .Cells(2).ReadOnly = False
                Else
                    .Cells(2).ReadOnly = True
                    .Cells(3).Value = ""
                End If
            End With
        Next

        ComputePayment()
        PopdtgAcctgEntry()
    End Sub

    Private Sub cmdAddRow_Click(sender As Object, e As EventArgs) Handles cmdAddRow.Click
        Dim dtCurrent As Date = GetServerDate()

        With Me.dtgPayments
            .Rows.Add("0.00", "", "", "")
            .BeginEdit(True)
        End With
    End Sub

    Private Sub cmdRemoveRow_Click(sender As Object, e As EventArgs) Handles cmdRemoveRow.Click
        If Me.dtgPayments.RowCount > 0 Then
            Me.dtgPayments.Rows.Remove(Me.dtgPayments.CurrentRow)
        End If

        Me.dtgPayments.EndEdit()
        ComputePayment()
        PopdtgAcctgEntry()
    End Sub

    Private Sub cmdClearRows_Click(sender As Object, e As EventArgs) Handles cmdClearRows.Click
        Me.dtgPayments.Rows.Clear()
        Me.dtgAcctgTitle.Rows.Clear()
    End Sub

    Private Sub txtARTotalAmt_TextChanged(sender As Object, e As EventArgs) Handles txtARTotalAmt.TextChanged
        If IsNumeric(Me.txtARTotalAmt.Text) = True Then
            Me.txtAmtInWords.Text = English(CDec(Me.txtARTotalAmt.Text), "Pesos")
        End If
    End Sub

    Private Sub dtgAllAR_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAllAR.CellContentClick

    End Sub

    Private Sub dtgAllAR_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAllAR.CellDoubleClick
        RetrieveARNo(Me.dtgAllAR.CurrentRow.Cells(0).Value)
        RetrieveAcctgEntry(Me.txtARNo.Text)

        Me.TabControl1.SelectedTab = Me.TabPage1

        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Private Sub dtgPayments_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dtgPayments.EditingControlShowing
        Dim tb As TextBox
        If Me.dtgPayments.CurrentCell.ColumnIndex = 0 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub

    Private Sub txtBalance_TextChanged(sender As Object, e As EventArgs) Handles txtBalance.TextChanged
        If IsNumeric(Me.txtBalance.Text) > 0 Then
            If CDbl(Me.txtBalance.Text) > 0 Then
                Me.txtBalance.ForeColor = Color.DarkRed
            Else
                Me.txtBalance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub tscmdSearch_Click(sender As Object, e As EventArgs) Handles tscmdSearch.Click
        SearchContBilling(Me.tslblPrefix.Text & Me.tstxtSearch.Text)

        If Len(Me.txtBillNo.Text) > 0 Then
            If blPosted = True Then
                Me.lblStatus.Text = "Posted"
            Else
                Me.lblStatus.Text = "Open"
            End If
        Else
            Me.lblStatus.Text = ""
        End If

        LoadAllAR(Me.txtBillNo.Text)
        RetrieveAR(Me.txtBillNo.Text)
        RetrieveAcctgEntry(Me.txtARNo.Text)

        If Len(Me.txtBillNo.Text) > 0 Then
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        End If
    End Sub

    Private Sub SearchContBilling(ByVal strval As String)
        ClearAll()

        Dim strSQL As String = "SELECT bcr_main.*, bcr_details.* FROM bcr_main INNER JOIN bcr_details on bcr_main.BCR_Nbr = bcr_details.BCD_BCRNbr WHERE BCR_Nbr = '" & strval & "'"

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySqlCommand(strSQL, cnn)

        Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            Me.txtBillNo.Text = reader.Item("BCR_Nbr")
            Me.txtHBL.Text = " " & reader.Item("BCD_BookNbr") & "-" & reader.Item("BCD_ContHBL") & ""
            Me.txtClientName.Text = reader.Item("BCR_ShippingName")
            Me.txtTotalBilling.Text = Format$(reader.Item("BCR_Amt"), "n2")
            'blPosted = reader.Item("BCR_Paid")
            blPosted = True
        End While

        reader.Close()

        If Len(Me.txtBillNo.Text) = 0 Then
            MsgBox("Billing Reference Number " & strval & " is either Cancelled or does not exist!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        strSQL = "SELECT * FROM bcr_details WHERE BCD_BCRNbr = '" & strval & "'"

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        cmdSQL = New MySqlCommand(strSQL, cnn)

        reader = cmdSQL.ExecuteReader

        While reader.Read
            Me.dtgCharges.Rows.Add(reader.Item("BCD_Particulars"), Format$(reader.Item("BCD_Amount"), "n2"))
        End While

        reader.Close()

        cmdSQL.Dispose()

        Me.TabControl1.SelectedTab = Me.TabPage2
    End Sub

    Private Sub chkDetention_CheckedChanged(sender As Object, e As EventArgs) Handles chkDetention.CheckedChanged

    End Sub

    Private Sub chkDetention_Click(sender As Object, e As EventArgs) Handles chkDetention.Click
        If Me.chkDetention.Checked = True Then
            Me.txtDetentionAmt.Enabled = True
        Else
            Me.txtDetentionAmt.Enabled = False
            Me.txtDetentionAmt.Text = "0.00"
        End If

        Me.txtDetentionAmt.Focus()
    End Sub

    Private Sub txtDetentionAmt_TextChanged(sender As Object, e As EventArgs) Handles txtDetentionAmt.TextChanged
        If Me.gpAR.Enabled = False Then Exit Sub
        ComputePayment()
        PopdtgAcctgEntry()
    End Sub

    Private Sub txtDetentionAmt_GotFocus(sender As Object, e As EventArgs) Handles txtDetentionAmt.GotFocus
        Me.txtDetentionAmt.SelectionStart = 0
        Me.txtDetentionAmt.SelectionLength = Len(Me.txtDetentionAmt.Text)
    End Sub

    Private Sub txtDetentionAmt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDetentionAmt.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub txtDetentionAmt_LostFocus(sender As Object, e As EventArgs) Handles txtDetentionAmt.LostFocus
        ComputePayment()
        PopdtgAcctgEntry()
    End Sub

    Private Sub txtOtherCharge_TextChanged(sender As Object, e As EventArgs) Handles txtOtherCharge.TextChanged
        'compute payment only
        If Me.gpAR.Enabled = False Then Exit Sub
        ComputePayment()
        PopdtgAcctgEntry()
    End Sub

    Private Sub txtOtherCharge_GotFocus(sender As Object, e As EventArgs) Handles txtOtherCharge.GotFocus
        Me.txtOtherCharge.SelectionStart = 0
        Me.txtOtherCharge.SelectionLength = Len(Me.txtDetentionAmt.Text)
    End Sub

    Private Sub txtOtherCharge_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOtherCharge.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub txtOtherCharge_LostFocus(sender As Object, e As EventArgs) Handles txtOtherCharge.LostFocus
        ComputePayment()
        PopdtgAcctgEntry()
    End Sub

    Private Sub chkOtherCharge_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtherCharge.CheckedChanged

    End Sub

    Private Sub chkOtherCharge_Click(sender As Object, e As EventArgs) Handles chkOtherCharge.Click
        If Me.chkOtherCharge.Checked = True Then
            Me.txtOtherCharge.Enabled = True
            Me.txtOtherChargeDesc.Enabled = True
        Else
            Me.txtOtherCharge.Enabled = False
            Me.txtOtherCharge.Text = "0.00"
            Me.txtOtherChargeDesc.Enabled = False
            Me.txtOtherChargeDesc.Text = ""
        End If

        Me.txtOtherCharge.Focus()
    End Sub

    Private Sub cboChargeTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChargeTo.SelectedIndexChanged
        If cboChargeTo.Text = "Client" Or cboChargeTo.Text = "" Then
            txtChargeTo.Text = ""
            txtEmpID.Text = ""
        ElseIf cboChargeTo.Text = "Employee" Then
            txtChargeTo.Text = ""
            'loadEmployees()
        End If
        If EnableButtons.NewEnabled = False Then
            PopdtgAcctgEntry()
        End If
    End Sub

    Private Sub tscmdClose_Click(sender As Object, e As EventArgs) Handles tscmdClose.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class