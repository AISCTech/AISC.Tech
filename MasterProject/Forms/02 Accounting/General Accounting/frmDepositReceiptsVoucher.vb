Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmDepositReceiptsVoucher
    Implements ICommonFunction
    Private EnableButtons As New clsEnableToolstripObjects()

    Dim NewStatusStrip As New StatusStrip

    Dim UserStripLabel As New ToolStripLabel("Current User:")
    Dim UserStripTextBox As New ToolStripTextBox

    Dim PrepByStripLabel As New ToolStripLabel("Prep. By:")
    Dim PrepByStripTextBox As New ToolStripTextBox

    Dim PrepDateStripLabel As New ToolStripLabel("Prep. Date:")
    Dim PrepDateStripTextBox As New ToolStripTextBox

    Dim StatusStripLabel As New ToolStripLabel("Status:")
    Dim StatusStripTextBox As New ToolStripTextBox

    Dim StatByStripLabel As New ToolStripLabel '("Status:")
    Dim StatByStripTextBox As New ToolStripTextBox

    Dim StatDateStripLabel As New ToolStripLabel '("Date:")
    Dim StatDateStripTextBox As New ToolStripTextBox

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

            Me.dtReceipt.Enabled = blUserInput
            Me.txtDateNeeded.ReadOnly = Not blUserInput
            Me.txtRemarks.ReadOnly = Not blUserInput
            Me.btAddBook.Enabled = blUserInput
            Me.btRemove.Enabled = blUserInput
            Me.dgDetails.ReadOnly = Not blUserInput
            Me.btnAR.Enabled = blUserInput
            Me.btnOR.Enabled = blUserInput
        End With
    End Sub

    Private Sub frmDepositReceiptsVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ColumnProp()
        MakeTheStatusStrip()
        UserStripTextBox.Text = strCurrentUser

        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub UpdateOrArRecord(ByVal str As String, ByVal strTable As String, ByVal strDRVNo As String)
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim sSQL As String = "UPDATE " & strTable & " SET "

        sSQL += " DRVNbr=@DRVNbr "

        sSQL += " WHERE ORNo = '" & str & "'"
        cmdSQL.CommandText = sSQL

        With cmdSQL.Parameters

            .AddWithValue("@DRVNbr", strDRVNo)

        End With

        cmdSQL.Connection = cnn
        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
    End Sub

    Public Sub GetORAR(ByVal dg As DataGridView, ByVal strModule As String)
        Select Case strModule
            Case "OR"
                Dim strsql As String = "SELECT ORNo, AmtPaid, CWT, OthChrg FROM or_invoice " &
                             "INNER JOIN or_main ON or_invoice.ORNo = or_main.ORNo " &
                             "WHERE or_invoice.DRVNbr is not null AND or_main.Cancel = FALSE"
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

                Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
                Dim dblORAmt As Double = 0
                While reader.Read

                    If IsDBNull(reader.Item("ORNo")) = False Then
                        dblORAmt = 0

                        dblORAmt = reader.Item("AmtPaid") + reader.Item("CWT") + reader.Item("OthChrg")

                        dg.Rows.Add(reader.Item("ORNo"), dblORAmt)
                    End If

                End While

                reader.Close()
                cmdSQL.Dispose()
            Case "AR"
                Dim strsql As String = "SELECT ORNo, AmtPaid, CWT, OthChrg FROM ar_invoice " &
                         "INNER JOIN ar_main ON ar_invoice.ORNo = ar_main.ORNo " &
                         "WHERE ar_invoice.DRVNbr is not null AND ar_main.Cancel = FALSE"
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

                Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

                Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
                Dim dblORAmt As Double = 0
                While reader.Read

                    If IsDBNull(reader.Item("ORNo")) = False Then
                        dblORAmt = 0

                        dblORAmt = reader.Item("AmtPaid") + reader.Item("CWT") + reader.Item("OthChrg")

                        dg.Rows.Add(reader.Item("ORNo"), dblORAmt)
                    End If

                End While

                reader.Close()
                cmdSQL.Dispose()
        End Select


    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If MsgBox("Are you sure you want to create new transaction?", vbYesNo, "Create New?") = vbNo Then Exit Sub

        ClearEntries()
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)

        GetORAR(Me.dtgOR, "OR")
        GetORAR(Me.dtgAR, "AR")
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        If Len(lblDRVNbr.Text) = 0 Then
            MsgBox("Nothing to Edit", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.StatusStripTextBox.Text <> "OPEN" Then
            MsgBox("Record already " & Me.StatDateStripTextBox.Text & "!", vbInformation, "Cannot Edit")
            Exit Sub
        End If

        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        'Check if other required entries has been properly filled up
        If CheckForRequiredEntries() = False Then
            Exit Sub
        End If

        Me.lblCredit.Text = SumAmount(11)
        Me.lblDebit.Text = SumAmount(10)
        'check debit credit column
        If Format(SumAmount(11), "N2") <> Format(SumAmount(10), "N2") Then
            MsgBox("Debit / Credit Column not equal", vbInformation, "System Message")
            Exit Sub
        End If

        If MsgBox("Save this record?", vbYesNo, "Confirm Save") = vbNo Then
            Exit Sub
        Else
            SaveDRV()
        End If
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        ClearEntries()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        Throw New NotImplementedException()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        If tStriptxtCKNbr.Text = "" Then
            MsgBox("Please Type Deposit Receipt Voucher Number", vbInformation, "System Message")

            Exit Sub
        End If
        SearchDRV(Me.tStriptxtCKNbr.Text)
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_PostDRV") = False Then
        '    MsgBox("You are not allowed to Post", vbInformation, "System Message")
        '    Exit Sub
        'End If
        If Len(lblDRVNbr.Text) = 0 Then
            MsgBox("Nothing to Post", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.StatusStripTextBox.Text <> "OPEN" Then
            MsgBox("Record already " & Me.StatDateStripTextBox.Text & "!", vbInformation, "Cannot Post")
            Exit Sub
        End If

        PostRecord()
    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_CancelDRV") = False Then
        '    MsgBox("You are not allowed to Cancel", vbInformation, "System Message")
        '    Exit Sub
        'End If
        If Len(lblDRVNbr.Text) = 0 Then
            MsgBox("Nothing to Canel", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.StatusStripTextBox.Text <> "OPEN" Then
            MsgBox("Record already " & Me.StatDateStripTextBox.Text & "!", vbInformation, "Cannot Cancel")
            Exit Sub
        End If

        CancelRecord()
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        If Len(lblDRVNbr.Text) = 0 Then
            MsgBox("Nothing to Re-Open", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.StatusStripTextBox.Text = "OPEN" Then
            MsgBox("Record already " & Me.StatDateStripTextBox.Text & "!", vbInformation, "Cannot Re-Open")
            Exit Sub
        End If
    End Sub

    Private Sub dtReceipt_ValueChanged(sender As Object, e As EventArgs) Handles dtReceipt.ValueChanged
        Me.txtDateNeeded.Text = Me.dtReceipt.Value.Date
    End Sub

    Private Sub ColumnProp()
        Dim colBut As New DataGridViewButtonColumn
        Dim chkDept As New DataGridViewCheckBoxColumn
        Dim chkList As New DataGridViewCheckBoxColumn


        With Me.dgDetails
            With Me.dgDetails

                .Columns.Add(colBut)
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

            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With

    End Sub
    Private Sub SaveDRV()
        Dim cmdSQL As New MySqlCommand
        Dim dtCurrent As Date
        dtCurrent = GetServerDate()
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        If Len(Me.lblDRVNbr.Text) = 0 Then

            Try

                Dim drvNumber As String

                cmdSQL.CommandText = ("INSERT INTO tbl_drv (`DRV_Nbr`, `DRV_DtTrans`, `DRV_CompanyCode`, `DRV_PrepBy`, `DRV_PrepDate`, `DRV_Cancel`, `DRV_Remarks`, `DRV_Posted`)  VALUES " &
                                     "               (@DRV_Nbr, @DRV_DtTrans, @DRV_CompanyCode, @DRV_PrepBy, @DRV_PrepDate, @DRV_Cancel, @DRV_Remarks, @DRV_Posted)")

                With cmdSQL.Parameters


                    drvNumber = "DRV" & GetCtrlNbr(strCompanyCode, strSiteCode, "")

                    If Len(drvNumber) = 0 Then
                        MsgBox("Error getting Deposit Receipt Voucher Number.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    .AddWithValue("@DRV_Nbr", drvNumber)
                    .AddWithValue("@DRV_DtTrans", Me.dtReceipt.Value.Date)
                    .AddWithValue("@DRV_Branch", "")
                    .AddWithValue("@DRV_PrepBy", CurrentUser)
                    .AddWithValue("@DRV_PrepDate", dtCurrent)
                    .AddWithValue("@DRV_Cancel", 0)
                    .AddWithValue("@DRV_Posted", 0)
                    .AddWithValue("@DRV_Remarks", Me.txtRemarks.Text)

                    Me.lblDRVNbr.Text = drvNumber
                    Me.txtPrepBy.Text = strCurrentUser
                    Me.txtPrepDate.Text = dtCurrent

                End With

                cmdSQL.Connection = cnnDBMaster
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Dispose()

            Catch ex As Exception
                MsgBox("There was an error trying to save the record - " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            SaveTransLogs("Create new Deposit Receipts Voucher", Me.Name, "DRV No.", Me.lblDRVNbr.Text, strCurrentUser)

        Else
            'update record

            Dim sSQL As String = "UPDATE tbl_drv SET "
            sSQL += " DRV_DtTrans=@DRV_DtTrans, "
            sSQL += " DRV_UpdatedBy=@DRV_UpdatedBy, "
            sSQL += " DRV_UpdatedDate=@DRV_UpdatedDate, "
            sSQL += " DRV_Remarks = @DRV_Remarks "

            sSQL += " WHERE DRV_Nbr= '" & Me.lblDRVNbr.Text & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters

                .AddWithValue("@DRV_DtTrans", Me.dtReceipt.Value.Date)
                .AddWithValue("@DRV_Remarks", Me.txtRemarks.Text)
                .AddWithValue("@DRV_UpdatedBy", CurrentUser)
                .AddWithValue("@DRV_UpdatedDate", dtCurrent)

                Me.txtUpdateBy.Text = strCurrentUser
                Me.txtUpdateDate.Text = dtCurrent

            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            SaveTransLogs("Edit Deposit Receipts Voucher", Me.Name, "DRV No.", Me.lblDRVNbr.Text, strCurrentUser)

            'Delete record in dra 
            Dim cmdSysParam As MySqlCommand
            Dim sqlString1 As String = "DELETE FROM tbl_dra WHERE DRA_Nbr = '" & Me.lblDRVNbr.Text & "'"

            cmdSysParam = New MySqlCommand(sqlString1, cnnDBMaster)
            cmdSysParam.ExecuteNonQuery()
            cmdSysParam.Dispose()

            'delete to tbl_generalledger
            DeleteToGLTable(Me.lblDRVNbr.Text, 14)

        End If

        'save details
        Dim h As DataGridViewRow
        For i = 0 To Me.dgDetails.Rows.Count - 1
            Dim cmdSQLPart1 As New MySqlCommand

            cmdSQLPart1.Connection = cnnDBMaster

            h = Me.dgDetails.Rows(i)

            If Not Len(h.Cells(1).Value) = 0 Then
                cmdSQLPart1.CommandText = ("INSERT INTO tbl_dra (DRA_Nbr, DRA_Account_Code, DRA_Account_Title, DRA_DR, DRA_CR, DRA_SubAccount_Code, DRA_SubAccount_Title, DRA_SubAccount_Dept, DRA_SubAccount_DeptName, DRA_SubAccount_List, DRA_SubAccount_ListItem, DRA_SubAccount_ListItemName)  VALUES " &
                                           "                   (@DRA_Nbr, @DRA_Account_Code, @DRA_Account_Title, @DRA_DR, @DRA_CR, @DRA_SubAccount_Code, @DRA_SubAccount_Title, @DRA_SubAccount_Dept, @DRA_SubAccount_DeptName, @DRA_SubAccount_List, @DRA_SubAccount_ListItem, @DRA_SubAccount_ListItemName)")

                With cmdSQLPart1.Parameters
                    .AddWithValue("@DRA_Nbr", Me.lblDRVNbr.Text)
                    .AddWithValue("@DRA_Account_Code", h.Cells(1).Value)
                    .AddWithValue("@DRA_Account_Title", h.Cells(2).Value)
                    .AddWithValue("@DRA_SubAccount_Code", h.Cells(3).Value)
                    .AddWithValue("@DRA_SubAccount_Title", h.Cells(4).Value)
                    .AddWithValue("@DRA_SubAccount_Dept", h.Cells(5).Value)
                    .AddWithValue("@DRA_SubAccount_DeptName", h.Cells(6).Value)
                    .AddWithValue("@DRA_SubAccount_List", h.Cells(7).Value)
                    .AddWithValue("@DRA_SubAccount_ListItem", h.Cells(8).Value)
                    .AddWithValue("@DRA_SubAccount_ListItemName", h.Cells(9).Value)
                    .AddWithValue("@DRA_DR", CDbl(h.Cells(10).Value))
                    .AddWithValue("@DRA_CR", CDbl(h.Cells(11).Value))
                End With

                cmdSQLPart1.ExecuteNonQuery()

                InsertToGLTable(14, GetGeneralLedgerModuleName(4), Me.lblDRVNbr.Text, h.Cells(1).Value, h.Cells(2).Value, h.Cells(3).Value, h.Cells(4).Value, CDbl(h.Cells(10).Value), CDbl(h.Cells(11).Value), h.Cells(5).Value, h.Cells(6).Value, h.Cells(7).Value, h.Cells(8).Value, h.Cells(9).Value)

            End If
            cmdSQLPart1.Dispose()
        Next
        '*******

        cnnDBMaster.Close()
        cnnDBMaster.Dispose()

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim strsql As String = "DELETE from drorar WHERE DRV_Nbr like '" & Me.lblDRVNbr.Text & "'"
        cmdSQL = New MySqlCommand(strsql, cnnDBMaster)
        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
        cnnDBMaster.Close()

        For i As Integer = 0 To Me.dtgAR.Rows.Count - 1
            With Me.dtgAR.Rows(i)
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                strsql = "INSERT INTO tbl_drorar (DRV_Nbr, ORNo, ORAmt, ARNo, ARAmt) VALUES (@DRV_Nbr, @ORNo, @ORAmt, @ARNo, @ARAmt)"
                cmdSQL = New MySqlCommand(strsql, cnnDBMaster)
                cmdSQL.Parameters.AddWithValue("@DRV_Nbr", Me.lblDRVNbr.Text)
                cmdSQL.Parameters.AddWithValue("@ORNo", "")
                cmdSQL.Parameters.AddWithValue("@ORAmt", 0)
                cmdSQL.Parameters.AddWithValue("@ARNo", .Cells("colARNo").Value)
                cmdSQL.Parameters.AddWithValue("@ARAmt", CDbl(.Cells("colAmtAR").Value))
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Dispose()
                cnnDBMaster.Close()
            End With
        Next

        For i As Integer = 0 To Me.dtgOR.Rows.Count - 1
            With Me.dtgOR.Rows(i)
                If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                strsql = "INSERT INTO tbl_drorar (DRV_Nbr, ORNo, ORAmt, ARNo, ARAmt) VALUES (@DRV_Nbr, @ORNo, @ORAmt, @ARNo, @ARAmt)"
                cmdSQL = New MySqlCommand(strsql, cnnDBMaster)
                cmdSQL.Parameters.AddWithValue("@DRV_Nbr", Me.lblDRVNbr.Text)
                cmdSQL.Parameters.AddWithValue("@ORNo", .Cells("colORNo").Value)
                cmdSQL.Parameters.AddWithValue("@ORAmt", CDbl(.Cells("colAmtOR").Value))
                cmdSQL.Parameters.AddWithValue("@ARNo", "")
                cmdSQL.Parameters.AddWithValue("@ARAmt", 0)
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Dispose()
                cnnDBMaster.Close()
            End With
        Next


        Dim iAR As Integer = 0
        Dim hAR As DataGridViewRow

        For iAR = 0 To Me.dtgAR.Rows.Count - 1

            hAR = Me.dtgAR.Rows(iAR)

            If Len(hAR.Cells(0).Value) <> 0 Then
                UpdateOrArRecord(hAR.Cells(0).Value, "ar_invoice", Me.lblDRVNbr.Text)
            End If

        Next

        Dim iOR As Integer = 0
        Dim hOR As DataGridViewRow

        For iOR = 0 To Me.dtgOR.Rows.Count - 1

            hOR = Me.dtgOR.Rows(iOR)

            If Len(hOR.Cells(0).Value) <> 0 Then
                UpdateOrArRecord(hOR.Cells(0).Value, "or_invoice", Me.lblDRVNbr.Text)
            End If

        Next

        MsgBox("Done Saving.", MsgBoxStyle.Information, "System Message")

        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Private Sub btAddBook_Click(sender As Object, e As EventArgs) Handles btAddBook.Click
        dgDetails.Rows.Add()
    End Sub

    Private Sub btRemove_Click(sender As Object, e As EventArgs) Handles btRemove.Click
        If Not dgDetails.CurrentRow.IsNewRow Then
            dgDetails.Rows.Remove(dgDetails.CurrentRow)
            Me.lblCredit.Text = SumAmount(11)
            Me.lblDebit.Text = SumAmount(10)
        End If
    End Sub

    Private Function CheckForRequiredEntries() As Boolean
        'check remarks 
        If Len(txtRemarks.Text) = 0 Then
            MsgBox("Please enter Remarks.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        'check Transaction Date 
        If Len(txtDateNeeded.Text) = 0 Then
            MsgBox("Please select Date of Transaction.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        'check if particulars with corresponding amount is present.
        If Not Me.dgDetails.Rows.Count = 0 Then
            For Each row As DataGridViewRow In dgDetails.Rows
                If row.Cells(1).Value = String.Empty Then
                    MsgBox("Please select an Account Title.", MsgBoxStyle.Critical, "Missing Information")
                    CheckForRequiredEntries = False
                    Exit For
                End If
                If row.Cells(3).Value = String.Empty Then
                    MsgBox("Please enter Charge To.", MsgBoxStyle.Critical, "Missing Information")
                    CheckForRequiredEntries = False
                    Exit For
                End If
                If Len(row.Cells(4).Value) = 0 And row.Cells(5).Value <= 0 Then
                    MsgBox("Please enter an amount.", MsgBoxStyle.Critical, "Missing Information")
                    CheckForRequiredEntries = False
                    Exit Function
                End If

            Next row
        ElseIf Me.dtgAR.Rows.Count = 0 Or Me.dtgOR.Rows.Count = 0 Then

        Else
            MsgBox("Please input details.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        CheckForRequiredEntries = True
    End Function

    Private Sub dgDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        frmSelectGLEntry.Tag = "DRV"
        frmSelectGLEntry.txtLineNbr.Text = e.RowIndex
        frmSelectGLEntry.ShowDialog()
    End Sub

    Public Function SumAmount(ByVal intIndex As Integer) As Double
        Dim i As Integer
        Dim h As DataGridViewRow

        For i = 0 To Me.dgDetails.Rows.Count - 1
            h = Me.dgDetails.Rows(i)
            If Not Len(h.Cells(intIndex).Value) = 0 Then
                SumAmount = SumAmount + h.Cells(intIndex).Value
            End If
        Next

        Return SumAmount

    End Function

    Private Sub dgDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetails.CellEndEdit
        Me.lblCredit.Text = SumAmount(11)
        Me.lblDebit.Text = SumAmount(10)
    End Sub

    Private Sub dgDetails_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgDetails.EditingControlShowing
        Dim tb As TextBox
        If dgDetails.CurrentCell.ColumnIndex = 2 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
            'ElseIf DataGridView1.CurrentCell.ColumnIndex = 1 Then
            '   tb = CType(e.Control, TextBox)
            '  '---add an event handler to the TextBox control---
            ' AddHandler tb.KeyPress, AddressOf TextBox2_KeyPress

        End If
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If dgDetails.CurrentCell.ColumnIndex = 4 Or dgDetails.CurrentCell.ColumnIndex = 5 Then
            SetCharacter(MyOption.Numeric, e)
        Else
            SetCharacter(MyOption.AlphaNumeric, e)
        End If
    End Sub

    Private Sub ClearEntries()

        Me.dtReceipt.Value = Now
        Me.txtDateNeeded.Text = ""
        Me.txtRemarks.Text = ""
        Me.dgDetails.Rows.Clear()
        Me.PrepByStripTextBox.Text = ""
        Me.PrepDateStripTextBox.Text = ""
        Me.StatByStripTextBox.Text = ""
        Me.StatByStripLabel.Text = ""
        Me.StatDateStripLabel.Text = ""
        Me.StatDateStripTextBox.Text = ""
        Me.StatusStripTextBox.Text = ""
        Me.lblCredit.Text = "0.00"
        Me.lblDebit.Text = "0.00"
        Me.lblDRVNbr.Text = ""
        Me.txtPrepDate.Text = ""
        Me.txtPrepBy.Text = ""
        Me.txtUpdateDate.Text = ""
        Me.txtUpdateBy.Text = ""
        Me.dtgAR.Rows.Clear()
        Me.dtgOR.Rows.Clear()
        'With frmORAR
        '    .dgCtr.Rows.Clear()
        '    .dgCtr2.Rows.Clear()
        'End With
    End Sub

    Private Sub SearchDRV(ByVal str As String)
        Dim strSQL As String

        If Len(Me.tStriptxtCKNbr.Text) = 0 Then
            MsgBox("Please Type Deposit Receipt Voucher Number", vbInformation, "System Message")
            Exit Sub
        End If

        strSQL = "SELECT * " &
                 "FROM  tbl_drv " &
                 "WHERE tbl_drv.DRV_Nbr ='" & str & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()

            If reader.HasRows = False Then
                MsgBox("No Record Found", MsgBoxStyle.Critical, "System Message")
                cmd.Dispose()
                reader.Close()
                ClearEntries()
                Exit Sub
            End If

            'If reader.Item("DRV_Branch") <> BranchCode Then
            '    If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_All_Branch") = "False" Then
            '        MsgBox("You have no permission to view this record", vbInformation, "System Message")
            '        cmd.Dispose()
            '        reader.Close()
            '        Exit Sub
            '    Else

            '    End If

            'End If

            Me.txtDateNeeded.Text = reader.Item("DRV_DtTrans")
            Me.txtRemarks.Text = reader.Item("DRV_Remarks")
            Me.txtPrepBy.Text = reader.Item("DRV_PrepBy")
            Me.txtPrepDate.Text = reader.Item("DRV_PrepDate")
            Me.dtReceipt.Value = reader.Item("DRV_DtTrans")
            Me.lblDRVNbr.Text = reader.Item("DRV_Nbr")

            If Not IsDBNull(reader.Item("DRV_UpdatedBy")) Then
                Me.txtUpdateBy.Text = reader.Item("DRV_UpdatedBy")
                Me.txtUpdateDate.Text = reader.Item("DRV_UpdatedDate")
            Else
                Me.txtUpdateBy.Text = ""
                Me.txtUpdateDate.Text = ""
            End If

            If reader.Item("DRV_Cancel") = True Then
                StatusStripTextBox.Text = "Cancelled"
                Me.StatByStripLabel.Text = "Cancelled By:"
                Me.StatByStripTextBox.Text = reader.Item("DRV_CancelBy")
                Me.StatDateStripLabel.Text = "Cancel Date:"
                Me.StatDateStripTextBox.Text = reader.Item("DRV_CancelDate")
            ElseIf reader.Item("DRV_Posted") = True Then
                StatusStripTextBox.Text = "Posted"
                Me.StatByStripLabel.Text = "Posted By"
                Me.StatByStripTextBox.Text = reader.Item("DRV_PostedBy")
                Me.StatDateStripLabel.Text = "Post Date"
                Me.StatDateStripTextBox.Text = reader.Item("DRV_PostDate")
            ElseIf reader.Item("DRV_Posted") = False And reader.Item("DRV_Cancel") = False Then
                StatusStripTextBox.Text = "OPEN"
                Me.StatByStripLabel.Text = ""
                Me.StatByStripTextBox.Text = ""
                Me.StatDateStripLabel.Text = ""
                Me.StatDateStripTextBox.Text = ""
            End If

        End While

        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()

        PopulateDetails(str)
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

        Me.lblCredit.Text = SumAmount(11)
        Me.lblDebit.Text = SumAmount(10)
    End Sub

    Private Sub PopulateDetails(ByVal str As String)
        Dim strSQL As String
        Dim DRVNbr As String
        DRVNbr = tstripBranch.Text
        strSQL = "SELECT * " &
                 "FROM tbl_dra " &
                 "WHERE tbl_dra.DRA_Nbr = '" & str & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView = Me.dgDetails

        gridBook.Rows.Clear()
        While reader2.Read
            gridBook.Rows.Add("", reader2.Item("DRA_Account_Code"), reader2.Item("DRA_Account_Title"), reader2.Item("DRA_SubAccount_Code"), reader2.Item("DRA_SubAccount_Title"), reader2.Item("DRA_SubAccount_Dept"), reader2.Item("DRA_SubAccount_DeptName"), reader2.Item("DRA_SubAccount_List"), reader2.Item("DRA_SubAccount_ListItem"), reader2.Item("DRA_SubAccount_ListItemName"), reader2.Item("DRA_DR"), reader2.Item("DRA_CR"))
            i = i + 1
        End While

        cmd2.Dispose()
        reader2.Close()

        Me.dtgAR.Rows.Clear()
        Me.dtgOR.Rows.Clear()

        strSQL = "SELECT * from tbl_drorar WHERE DRV_Nbr = '" & str & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        cmd2 = New MySqlCommand(strSQL, cnnDBMaster)

        reader2 = cmd2.ExecuteReader

        While reader2.Read
            If reader2.Item("ARNo") <> "" Then
                Me.dtgAR.Rows.Add(reader2.Item("ARNo"), reader2.Item("ARAmt"))
            End If
            If reader2.Item("ORNo") <> "" Then
                Me.dtgOR.Rows.Add(reader2.Item("ORNo"), reader2.Item("ORAmt"))
            End If
        End While

        cmd2.Dispose()
        reader2.Close()
    End Sub
    Private Sub PostDRV(ByVal str As String)
        Dim dtCurrent As Date
        Dim cmdSQL As New MySqlCommand
        dtCurrent = GetServerDate()
        If MsgBox("Are you sure you want to post?", vbYesNo, "Confirm Post") = vbNo Then

            Exit Sub
        Else
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim sSQL As String = "UPDATE tbl_drv SET "
            sSQL += " DRV_Posted=@DRV_Posted, "
            sSQL += " DRV_PostedBy=@DRV_PostedBy, "
            sSQL += " DRV_PostDate=@DRV_PostDate "

            sSQL += " WHERE DRV_Nbr= '" & str & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters
                .AddWithValue("@DRV_Posted", 1)
                .AddWithValue("@DRV_PostedBy", CurrentUser)
                .AddWithValue("@DRV_PostDate", dtCurrent)
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            MsgBox("Record Posted", vbInformation, "System Message")
            StatusStripTextBox.Text = "Posted"
            Me.StatByStripLabel.Text = "Posted By:"
            Me.StatByStripTextBox.Text = strCurrentUser
            Me.StatDateStripLabel.Text = "Post Date:"
            Me.StatDateStripTextBox.Text = dtCurrent
        End If
    End Sub
    Private Sub CancelDRV(ByVal str As String)
        Dim dtCurrent As Date
        Dim cmdSQL As New MySqlCommand
        dtCurrent = GetServerDate()
        If MsgBox("Are you sure you want to cancel?", vbYesNo, "Confirm Cancel") = vbNo Then

            Exit Sub
        Else
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim sSQL As String = "UPDATE tbl_drv SET "
            sSQL += " DRV_Cancel=@DRV_Cancel, "
            sSQL += " DRV_CancelBy=@DRV_CancelBy, "
            sSQL += " DRV_CancelDate=@DRV_CancelDate "

            sSQL += " WHERE DRV_Nbr= '" & str & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters
                .AddWithValue("@DRV_Cancel", 1)
                .AddWithValue("@DRV_CancelBy", CurrentUser)
                .AddWithValue("@DRV_CancelDate", dtCurrent)
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            MsgBox("Cancelled", vbInformation, "System Message")
            StatusStripTextBox.Text = "Cancelled"
            Me.StatByStripLabel.Text = "Cancelled By:"
            Me.StatByStripTextBox.Text = strCurrentUser
            Me.StatDateStripLabel.Text = "Cancel Date:"
            Me.StatDateStripTextBox.Text = dtCurrent

        End If
    End Sub
    Private Sub MakeTheStatusStrip()
        'Add controls
        Me.Controls.Add(NewStatusStrip)

        'IMPORTANT:
        'To be able to set textbox forecolor properties in readonly, Set backcolor properties to SystemColors.Control 

        'User
        NewStatusStrip.Items.Add(UserStripLabel)
        NewStatusStrip.Items.Add(UserStripTextBox)
        NewStatusStrip.BackColor = SystemColors.Control
        With UserStripTextBox
            .ReadOnly = True
            .ForeColor = Drawing.Color.Firebrick
            .BorderStyle = BorderStyle.None
            .BackColor = SystemColors.Control
            .TextBox.Width = 150
        End With

        'Status
        NewStatusStrip.Items.Add(StatusStripLabel)
        NewStatusStrip.Items.Add(StatusStripTextBox)
        With StatusStripTextBox
            .ReadOnly = True
            .ForeColor = Drawing.Color.Firebrick
            .BorderStyle = BorderStyle.None
            .BackColor = SystemColors.Control
        End With

        'Cancel/Posted By
        NewStatusStrip.Items.Add(StatByStripLabel)
        NewStatusStrip.Items.Add(StatByStripTextBox)
        With StatByStripTextBox
            .ReadOnly = True
            .ForeColor = Drawing.Color.Firebrick
            .BorderStyle = BorderStyle.None
            .BackColor = SystemColors.Control
        End With

        'Cancel/Posted Date
        NewStatusStrip.Items.Add(StatDateStripLabel)
        NewStatusStrip.Items.Add(StatDateStripTextBox)
        With StatDateStripTextBox
            .ReadOnly = True
            .ForeColor = Drawing.Color.Firebrick
            .BorderStyle = BorderStyle.None
            .BackColor = SystemColors.Control
        End With

    End Sub

    Private Sub tStriptxtCKNbr_Click(sender As Object, e As EventArgs) Handles tStriptxtCKNbr.Click

    End Sub

    Private Sub tStriptxtCKNbr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tStriptxtCKNbr.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            If tStriptxtCKNbr.Text = "" Then
                MsgBox("Please Type Deposit Receipt Voucher Number", vbInformation, "System Message")

                Exit Sub
            End If
            SearchDRV(Me.tStriptxtCKNbr.Text)
        End If
    End Sub

    Private Sub tStripClose_Click(sender As Object, e As EventArgs) Handles tStripClose.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class