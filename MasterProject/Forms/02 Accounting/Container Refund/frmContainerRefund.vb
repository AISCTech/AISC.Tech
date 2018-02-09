Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmContainerRefund
    Implements ICommonFunction

    Dim BookNbr As String
    Dim BookNbrStatus As String
    Dim NewStatusStrip As New StatusStrip
    Dim BranchCode As String

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
    Private Sub frmContainerRefund_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableButtons(True, False, False, True, True, True, True)
        SetColumnProp()
        LockControls(True)
        UserStripLabel.Text = "Current User: " & strCurrentUser & ""
        MakeTheStatusStrip()
    End Sub


    Public Sub LockControls(ByVal blLock As Boolean)
        Me.txtRemarks.ReadOnly = blLock
    End Sub

    Public Function CheckIfRequestExistOnContRef(ByVal strReqNo As String) As Boolean
        CheckIfRequestExistOnContRef = False
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        Dim strsql As String = "SELECT BCR_RequestNbr FROM bcr_main WHERE BCR_RequestNbr = '" & strReqNo & "'"

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd2 = New MySqlCommand(strsql, cnn)
        Dim reader As MySqlDataReader = cmd2.ExecuteReader()

        While reader.Read
            If IsDBNull(reader.Item("BCR_RequestNbr")) = False Then
                CheckIfRequestExistOnContRef = True
            End If
        End While

        reader.Close()
        cnn.Close()
    End Function

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        'If GetBooleanValue("Select Allow_ContainerRefundLetter_New from tbl_users where Username = '" & strCurrentUser & "'", "Allow_ContainerRefundLetter_New") = False Then
        '    MsgBox("You are not allowed to add new record", vbInformation, "System Message")
        '    Exit Sub
        'End If

        If MsgBox("Are you sure you want to create new transaction?", vbYesNo, "Create New?") = vbNo Then Exit Sub
        LockControls(False)
        EnableButtons(False, True, True, False, False, False, False)
        'Me.txtRemarks.ReadOnly = False
        'txtShipAddress.ReadOnly = False
        frmRetrieveContainerDepositRequest.ShowDialog()
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If Len(txtRemarks.Text) = 0 Then
            MsgBox("Please Input Remarks", vbInformation, "System Message")
            Exit Sub
        End If
        'If Len(txtShipAddress.Text) = 0 Then
        '    MsgBox("Please Input Shipping Name Address", vbInformation, "System Message")
        '    Exit Sub
        'End If
        If MsgBox("Save this record?", vbYesNo, "Confirm Save") = vbNo Then
            Exit Sub
        Else
            SaveContainerRefund()
        End If
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        ResetForm()
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        Throw New NotImplementedException()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        If Len(Me.txtContRefCtrlNo.Text) = 0 Then
            MsgBox("Nothing to Post!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If
        'If GetBooleanValue("Select Allow_ContainerRefundLetter_Post from tbl_users where Username = '" & strCurrentUser & "'", "Allow_ContainerRefundLetter_Post") = False Then
        '    MsgBox("You are not allowed to post record", vbInformation, "System Message")
        '    Exit Sub
        'End If
        If MsgBox("Please make sure that all entries are correct before Posting!" & vbNewLine & "Post this reference no. " & Me.txtContRefCtrlNo.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim dtcurrent As Date = GetServerDate()
        Dim dtSLDate As Date = Format$(CDate(Me.PrepDateStripTextBox.Text), "yyyy-MM-dd hh:mm:ss")

        Dim strsql As String = "UPDATE bcr_main SET" &
                                " Posted = @Posted, " &
                                " PostedBy = @PostedBy, " &
                                " PostedDate = @PostedDate " &
                                " WHERE BCR_Nbr = '" & Me.txtContRefCtrlNo.Text & "' AND BCR_Cancel = FALSE"

        Dim cmdSQL = New MySqlCommand(strsql, cnnDBMaster)

        With cmdSQL.Parameters
            .AddWithValue("@Posted", True)
            .AddWithValue("@PostedBy", strCurrentUser)
            .AddWithValue("@PostedDate", dtcurrent)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()

        'save trans logs
        SaveTransLogs("Post Container Refund Billing", Me.Name, "Container Refund Ctrl No.", Me.txtContRefCtrlNo.Text, strCurrentUser)

        MsgBox("Record Posted!", vbInformation, "System Message")
    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        If Len(Me.txtContRefCtrlNo.Text) = 0 Then
            MsgBox("Nothing to Cancel!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If
        'If GetBooleanValue("Select Allow_ContainerRefundLetter_Cancel from tbl_users where Username = '" & strCurrentUser & "'", "Allow_ContainerRefundLetter_Cancel") = False Then
        '    MsgBox("You are not allowed to cancel record", vbInformation, "System Message")
        '    Exit Sub
        'End If
        Dim dtCurrent As Date
        Dim cmdSQL As New MySqlCommand
        dtCurrent = GetServerDate()
        If MsgBox("Are you sure you want to cancel?", vbYesNo, "Confirm Cancel") = vbNo Then
            Exit Sub
        Else
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim sSQL As String = "UPDATE  bcr_main SET "
            sSQL += " BCR_Cancel=@BCR_Cancel, "
            sSQL += " BCR_CancelBy=@BCR_CancelBy, "
            sSQL += " BCR_CancelDate=@BCR_CancelDate "

            sSQL += " WHERE BCR_Nbr= '" & Me.txtContRefCtrlNo.Text & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters

                .AddWithValue("@BCR_Cancel", 1)
                .AddWithValue("@BCR_CancelBy", strCurrentUser)
                .AddWithValue("@BCR_CancelDate", dtCurrent)

            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            'save trans logs
            SaveTransLogs("Cancel Container Refund Billing", Me.Name, "Container Refund Ctrl No.", Me.txtContRefCtrlNo.Text, strCurrentUser)

            MsgBox("Record Cancelled", vbInformation, "System Message")

        End If
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        Throw New NotImplementedException()
    End Sub
    Public Sub ResetForm()
        ClearEntries()
        EnableButtons(True, False, False, True, True, True, True)
        LockControls(True)
    End Sub
    Public Sub EnableButtons(ByVal blNew As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean, ByVal blPrintPreview As Boolean, ByVal blPost As Boolean, ByVal blCancel As Boolean, ByVal blClose As Boolean)
        Me.tStripNew.Enabled = blNew
        Me.tStripSave.Enabled = blSave
        Me.tstripReset.Enabled = blReset
        Me.tStripPreview.Enabled = blPrintPreview
        Me.tStripPost.Enabled = blPost
        Me.tStripCancel.Enabled = blCancel
        Me.tStripClose.Enabled = blClose
    End Sub

    Public Sub PopulateItems(ByVal strRequest As String)
        Dim strSQL As String
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        strSQL = "SELECT tbl_requestd.REQD_REQNbr, tbl_requestd.REQD_Particulars, tbl_requestd.REQD_Amount, tbl_requestd.REQD_Index " &
                 "FROM tbl_requestd " &
                 "WHERE tbl_requestd.REQD_REQNbr = '" & strRequest & "' " &
                 "ORDER BY REQD_Index"

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnn)

        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView

        While reader2.Read
            gridBook = Me.DataGridView1

            gridBook.Rows.Add("", reader2.Item("REQD_Particulars"), reader2.Item("REQD_Amount"))
            i = i + 1
        End While

        cmd2.Dispose()
        reader2.Close()



    End Sub

    Public Sub PopulateBooking(ByVal str As String)
        Dim strSQL As String

        Dim cnn1 As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        strSQL = "SELECT * " &
                 "FROM tbl_requestd " &
                 "WHERE tbl_requestd.REQD_REQNbr ='" & str & "'"

        If cnn1.State <> ConnectionState.Open Then cnn1.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnn1)
        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView


        While reader2.Read
            gridBook = Me.DataGridView2

            BookNbr = reader2.Item("REQD_BookNbr")
            Dim strShipCons As String = ""
            Select Case reader2.Item("REQD_Key")
                Case "IMPB"
                    strShipCons = "REQD_Consignee"
                    Dim cnn2 As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
                    Dim strSQLFORW As String = "SELECT CtrlNbr, Status FROM tbl_importbook WHERE CtrlNbr = '" & BookNbr & "'"
                    If cnn2.State <> ConnectionState.Open Then cnn2.Open()
                    Dim cmdMDB = New MySql.Data.MySqlClient.MySqlCommand(strSQLFORW, cnn2)

                    Dim dbReader As MySql.Data.MySqlClient.MySqlDataReader = cmdMDB.ExecuteReader()
                    With dbReader.Read
                        If dbReader.Item("Status") = 3 Then
                            BookNbrStatus = "Cancelled"
                        ElseIf dbReader.Item("Status") = 1 Then
                            BookNbrStatus = "Open"
                        ElseIf dbReader.Item("Status") = 2 Then
                            BookNbrStatus = "Posted"
                            'ElseIf dbReader.Item("Status") = 4 Then
                            '    BookNbrStatus = "Posted"
                            'ElseIf dbReader.Item("Status") = 5 Then
                            '    BookNbrStatus = "Re-book"
                            'ElseIf dbReader.Item("Status") = 6 Then
                            '    BookNbrStatus = "Foul"
                        End If

                    End With
                    dbReader.Close()
                    cmdMDB.Dispose()
                Case "EXP"
                    strShipCons = "REQD_Shipper"
                    Dim cnn2 As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
                    'Dim strSQLEXP As String = "SELECT BKS.BKS_Nbr, BKS.BKS_Status " & _
                    '  "FROM BKS " & _
                    '  "WHERE (((BKS.BKS_Nbr)='" & BookNbr & "'))"

                    'cmdMDB = New OleDb.OleDbCommand(strSQLEXP, connExport)

                    'If connExport.State <> ConnectionState.Open Then connExport.Open()

                    'Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()
                    'With dbReader.Read
                    '    If dbReader.Item("BKS_Status") = 3 Then
                    '        BookNbrStatus = "Cancelled"
                    '    ElseIf dbReader.Item("BKS_Status") = 1 Then
                    '        BookNbrStatus = "Open"
                    '    ElseIf dbReader.Item("BKS_Status") = 2 Then
                    '        BookNbrStatus = "Loaded"
                    '    ElseIf dbReader.Item("BKS_Status") = 4 Then
                    '        BookNbrStatus = "Posted"
                    '    ElseIf dbReader.Item("BKS_Status") = 5 Then
                    '        BookNbrStatus = "Re-book"
                    '    ElseIf dbReader.Item("BKS_Status") = 6 Then
                    '        BookNbrStatus = "Foul"
                    '    End If
                    '    'BookNbrStatus = dbReader.Item("BKS_Status")
                    'End With

                    'dbReader.Close()
                    'cmdMDB.Dispose()
            End Select





            gridBook.Rows.Add(BookNbr, reader2.Item("REQD_BookNbr"), BookNbrStatus, reader2.Item(strShipCons), reader2.Item("REQD_ContainerNo"), reader2.Item("REQD_Amount"), reader2.Item("REQD_Key"), reader2.Item("REQD_Index"), reader2.Item("REQD_Particulars"))
            i = i + 1
        End While

        cmd2.Dispose()
        reader2.Close()
    End Sub

    Private Sub SetColumnProp()
        Dim colBut As New DataGridViewButtonColumn

        With Me.DataGridView1
            With Me.DataGridView1
                .Columns.Clear()
                .Columns.Add(colBut)
                .Columns.Add("", "Particulars")
                .Columns.Add("", "Amount")

                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .MultiSelect = False

            End With

            .Columns(0).Width = 25
            .Columns(1).Width = 300
            .Columns(2).Width = 100

            '.Columns(2).DefaultCellStyle.Format = "n2"
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With


        With Me.DataGridView2
            .Columns.Clear()
            .Columns.Add("", "Booking")
            .Columns.Add("", "Booking #")
            .Columns.Add("", "Status")

            .Columns.Add("", "Shipper/Consignee")
            .Columns.Add("", "Container/BL #")
            .Columns.Add("", "Amount")
            .Columns.Add("", "Key")
            .Columns.Add("", "Index")
            .Columns.Add("", "Particulars")

            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .MultiSelect = True

            .Columns(0).Width = 0
            .Columns(1).Width = 120

            .Columns(3).Width = 220
            .Columns(4).Width = 150
            .Columns(5).Width = 100
            .Columns(6).Width = 50
            .Columns(7).Width = 50
            .Columns(8).Width = 150

            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True

            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = True
            .Columns(7).ReadOnly = True
            .Columns(8).ReadOnly = True

            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.Format = "n2"
        End With

        Me.Refresh()
    End Sub

    Private Sub SaveContainerRefund()
        Dim cmdSQL As New MySqlCommand
        Dim blNewEdit As String = ""
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        If Len(Me.txtContRefCtrlNo.Text) = 0 Then
            blNewEdit = "New"
            Try
                Dim dtCurrent As Date
                Dim bcrNumber As String

                dtCurrent = GetServerDate()

                cmdSQL.CommandText = ("INSERT INTO bcr_main (`BCR_Nbr`, `BCR_ShippingName`, BCR_RequestNbr, BCR_Amt, BCR_Remarks, BCR_Cancel, BCR_Outstanding, BCR_Balance, BCR_Paid, BCR_PreparedBy, BCR_PreparedDate, BCR_ORNbr, BCR_ShippingAddress)  VALUES " &
                                     "               (@BCR_Nbr, @BCR_ShippingName, @BCR_RequestNbr, @BCR_Amt, @BCR_Remarks, @BCR_Cancel, @BCR_Outstanding, @BCR_Balance, @BCR_Paid, @BCR_PreparedBy, @BCR_PreparedDate, @BCR_ORNbr, @BCR_ShippingAddress)")

                With cmdSQL.Parameters

                    bcrNumber = GetCtrlNbr(strCompanyCode, strSiteCode, "Container_Refund")

                    If Len(bcrNumber) = 0 Then
                        MsgBox("Error getting reference number.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    .AddWithValue("@BCR_Nbr", bcrNumber)
                    .AddWithValue("@BCR_ShippingName", Me.txtPayeeName.Text)
                    .AddWithValue("@BCR_RequestNbr", Me.txtRequestNbr.Text)
                    .AddWithValue("@BCR_Amt", CDbl(txtBillAmt.Text))
                    .AddWithValue("@BCR_Remarks", Me.txtRemarks.Text)

                    .AddWithValue("@BCR_Cancel", 0)
                    .AddWithValue("@BCR_Outstanding", 1)
                    .AddWithValue("@BCR_Balance", 0)
                    .AddWithValue("@BCR_Paid", 0)
                    .AddWithValue("@BCR_PreparedBy", strCurrentUser)
                    .AddWithValue("@BCR_PreparedDate", dtCurrent)
                    .AddWithValue("@BCR_ORNbr", Me.txtORNbr.Text)
                    .AddWithValue("@BCR_ShippingAddress", Me.txtShipAddress.Text)

                    Me.txtContRefCtrlNo.Text = bcrNumber

                End With

                cmdSQL.Connection = cnnDBMaster
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Dispose()

            Catch ex As Exception
                MsgBox("There was an error trying to save the record - " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "Container_Refund")

            'save trans logs
            SaveTransLogs("Create New Container Refund Billing", Me.Name, "Container Refund Ctrl No.", Me.txtContRefCtrlNo.Text, strCurrentUser)

        Else
            blNewEdit = "Edit"
            'update record

            Dim sSQL As String = "UPDATE bcr_main SET "

            sSQL += " BCR_Remarks=@BCR_Remarks,"


            sSQL += " WHERE BCR_Nbr= '" & Me.txtContRefCtrlNo.Text & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters

                .AddWithValue("@BCR_Remarks", Me.txtRemarks.Text)

            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()


            'save trans logs
            SaveTransLogs("Edit Container Refund Billing", Me.Name, "Container Refund Ctrl No.", Me.txtContRefCtrlNo.Text, strCurrentUser)

            'Delete record in tbl_contrefdetails 
            Dim cmdSysParam As MySqlCommand
            Dim sqlString1 As String = "DELETE FROM bcr_details WHERE BCD_BCRNbr = '" & Me.txtContRefCtrlNo.Text & "'"

            cmdSysParam = New MySqlCommand(sqlString1, cnnDBMaster)
            cmdSysParam.ExecuteNonQuery()
            cmdSysParam.Dispose()

        End If

        'save details
        Dim h As DataGridViewRow
        For i = 0 To Me.DataGridView2.Rows.Count - 1
            Dim cmdSQLPart1 As New MySqlCommand
            Dim refund As String = "-Refund"
            cmdSQLPart1.Connection = cnnDBMaster

            h = Me.DataGridView2.Rows(i)

            If Not Len(h.Cells(1).Value) = 0 Then
                cmdSQLPart1.CommandText = ("INSERT INTO bcr_details (BCD_BCRNbr, BCD_BookNbr, BCD_Consignee, BCD_ContHBL, BCD_Particulars, BCD_Amount, BCD_Key)  VALUES " &
                                           "                   (@BCD_BCRNbr, @BCD_BookNbr, @BCD_Consignee, @BCD_ContHBL, @BCD_Particulars, @BCD_Amount, @BCD_Key)")

                With cmdSQLPart1.Parameters
                    .AddWithValue("@BCD_BCRNbr", Me.txtContRefCtrlNo.Text)
                    .AddWithValue("@BCD_BookNbr", h.Cells(1).Value)
                    .AddWithValue("@BCD_Consignee", h.Cells(3).Value)
                    .AddWithValue("@BCD_ContHBL", h.Cells(4).Value)
                    .AddWithValue("@BCD_Particulars", "" & h.Cells(8).Value & "" & refund & "")
                    .AddWithValue("@BCD_Amount", CDbl(h.Cells(5).Value))
                    .AddWithValue("@BCD_Key", h.Cells(6).Value)

                End With

                cmdSQLPart1.ExecuteNonQuery()
            End If
            cmdSQLPart1.Dispose()
        Next
        '*******

        cnnDBMaster.Close()
        cnnDBMaster.Dispose()

        Select Case blNewEdit
            Case "New"
                SaveTransLogs("Create New Container Refund", Me.Name, "Container Refund Control No.", Me.txtContRefCtrlNo.Text, strCurrentUser)
            Case "Edit"
                SaveTransLogs("Edit Container Refund", Me.Name, "Container Refund Control No.", Me.txtContRefCtrlNo.Text, strCurrentUser)
        End Select

        MsgBox("Done Saving.", MsgBoxStyle.Information, "System Message")

        EnableButtons(True, False, False, True, True, True, True)
        LockControls(True)
    End Sub
    Public Sub ComputeGrandTotal()
        Me.txtGrandTotal.Text = Format(SumAmount, "N2")
        Me.txtBillAmt.Text = Format(SumAmount, "N2")
    End Sub

    'Grand Total Amount value
    Public Function SumAmount() As Double
        Dim i As Integer
        Dim h As DataGridViewRow

        For i = 0 To Me.DataGridView2.Rows.Count - 1
            h = Me.DataGridView2.Rows(i)
            If Not Len(h.Cells(5).Value) = 0 Then
                SumAmount = SumAmount + h.Cells(5).Value
            End If
        Next

        Return SumAmount

    End Function

    Private Sub txtGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles txtGrandTotal.TextChanged
        If Not Len(Me.txtGrandTotal.Text) = 0 Then
            Me.txtAmtInWords.Text = English(Me.txtGrandTotal.Text)
        End If
    End Sub

    Private Sub txtBillAmt_TextChanged(sender As Object, e As EventArgs) Handles txtBillAmt.TextChanged
        If Not Len(Me.txtBillAmt.Text) = 0 Then
            Me.txtBillAmtInWords.Text = English(Me.txtBillAmt.Text)
        End If
    End Sub

    Private Sub tStripSearch_Click(sender As Object, e As EventArgs) Handles tStripSearch.Click
        If tStriptxtCKNbr.Text = "" Then
            MsgBox("Please Type Reference Number", vbInformation, "System Message")

            Exit Sub
        End If
        SearchRecord(Me.tStriptxtCKNbr.Text)
    End Sub

    Private Sub ClearEntries()
        Me.PrepByStripLabel.Text = ""
        Me.PrepByStripTextBox.Text = ""
        Me.PrepDateStripLabel.Text = ""
        Me.PrepDateStripTextBox.Text = ""
        StatusStripTextBox.Text = ""
        Me.StatByStripLabel.Text = ""
        Me.StatByStripLabel.Text = ""
        Me.StatByStripTextBox.Text = ""
        Me.StatDateStripLabel.Text = ""
        Me.StatusStripTextBox.Text = ""

        Me.txtContRefCtrlNo.Text = ""

        Me.txtPayeeCode.Text = "'"
        Me.txtPayeeName.Text = ""
        Me.txtShipAddress.Text = ""
        Me.txtRequestNbr.Text = ""
        Me.txtORNbr.Text = ""
        Me.txtBillAmt.Text = ""
        Me.txtBillAmtInWords.Text = ""
        Me.txtRemarks.Text = ""

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView2.Rows.Clear()
        Me.dtgAllAR.Rows.Clear()
    End Sub
    Private Sub SearchRecord(ByVal str As String)
        If Len(Me.tStriptxtCKNbr.Text) = 0 Then
            Exit Sub
        End If

        Dim strSQL As String

        strSQL = "SELECT bcr_main.*, bcr_details.* " &
                 "FROM  bcr_main INNER JOIN bcr_details ON bcr_main.BCR_Nbr = bcr_details.BCD_BCRNbr " &
                 "WHERE bcr_main.BCR_Nbr ='" & str & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        Me.DataGridView2.Rows.Clear()
        While reader.Read()
            Me.txtContRefCtrlNo.Text = reader.Item("BCR_Nbr")
            Me.txtORNbr.Text = reader.Item("BCR_ORNbr")
            Me.txtRemarks.Text = reader.Item("BCR_Remarks")
            Me.txtPayeeName.Text = reader.Item("BCR_ShippingName")
            Me.txtShipAddress.Text = reader.Item("BCR_ShippingAddress")
            Me.txtRequestNbr.Text = reader.Item("BCR_RequestNbr")
            Me.PrepByStripLabel.Text = "Prepared By:"
            Me.PrepByStripTextBox.Text = reader.Item("BCR_PreparedBy")
            Me.PrepDateStripLabel.Text = "Prepared Date:"
            Me.PrepDateStripTextBox.Text = reader.Item("BCR_PreparedDate")

            If reader.Item("BCR_Cancel") = True Then
                StatusStripTextBox.Text = "Cancelled"
                Me.StatByStripLabel.Text = "Cancelled"
                Me.StatByStripLabel.Text = "Cancelled By:"
                Me.StatByStripTextBox.Text = reader.Item("BCR_CancelBy")
                Me.StatDateStripLabel.Text = "Cancel Date:"
                Me.StatusStripTextBox.Text = reader.Item("BCR_CancelDate")

                Me.tStripSave.Enabled = False

                Me.tStripNew.Enabled = True
            Else
                StatusStripTextBox.Text = ""
                Me.StatByStripLabel.Text = ""
                Me.StatByStripLabel.Text = ""
                Me.StatByStripTextBox.Text = ""
                Me.StatDateStripLabel.Text = ""
                Me.StatusStripTextBox.Text = ""

                Me.tStripSave.Enabled = False

                Me.tStripNew.Enabled = True
            End If

            If reader.Item("BCR_Outstanding") = True Then
                lblStatus.Text = "OUTSTANDING"

            End If
            If reader.Item("BCR_Balance") = True Then
                lblStatus.Text = "WITH BALANCE"

            End If
            If reader.Item("BCR_Paid") = True Then
                lblStatus.Text = "PAID"

            End If

            Me.DataGridView2.Rows.Add("", reader.Item("BCD_BookNbr"), BookNbrStatus, reader.Item("BCD_Consignee"), reader.Item("BCD_ContHBL"), reader.Item("BCD_Amount"), reader.Item("BCD_Key"), "", reader.Item("BCD_Particulars"))
        End While
        With reader.Read

            If reader.HasRows = False Then
                MsgBox("No Record Found", MsgBoxStyle.Critical, "System Message")

                reader.Close()
                Exit Sub

            End If
        End With
        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()

        Me.DataGridView1.Rows.Clear()
        PopulateItems(Me.txtRequestNbr.Text)

        tStripSave.Enabled = False

        ComputeGrandTotal()

        'GetDetentionCharges()

        GetCollectionInfo(Me.txtContRefCtrlNo.Text)
    End Sub

    Public Sub GetCollectionInfo(ByVal str As String)
        Dim strDBtable As String = "", strDetention As String, strOtherCharge As String

        Dim strsql As String = "SELECT * FROM ar_contref_arnumbers WHERE RefNo = '" & str & "' AND Cancel = FALSE ORDER BY PrepDate"

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
            .ForeColor = Color.Firebrick
            .BorderStyle = BorderStyle.None
            .BackColor = SystemColors.Control
            .TextBox.Width = 150
        End With
        'Prepared by
        NewStatusStrip.Items.Add(PrepByStripLabel)
        NewStatusStrip.Items.Add(PrepByStripTextBox)
        With PrepByStripTextBox
            .ReadOnly = True
            .ForeColor = Color.Firebrick
            .BorderStyle = BorderStyle.None
            .BackColor = SystemColors.Control
            .TextBox.Width = 150
        End With

        'Prepared date
        NewStatusStrip.Items.Add(PrepDateStripLabel)
        NewStatusStrip.Items.Add(PrepDateStripTextBox)
        With PrepDateStripTextBox
            .ReadOnly = True
            .ForeColor = Color.Firebrick
            .BorderStyle = BorderStyle.None
            .BackColor = SystemColors.Control
            .TextBox.Width = 190
        End With
        'Status
        NewStatusStrip.Items.Add(StatusStripLabel)
        NewStatusStrip.Items.Add(StatusStripTextBox)
        With StatusStripTextBox
            .ReadOnly = True
            .ForeColor = Color.Firebrick
            .BorderStyle = BorderStyle.None
            .BackColor = SystemColors.Control
        End With

        'Cancel/Posted By
        NewStatusStrip.Items.Add(StatByStripLabel)
        NewStatusStrip.Items.Add(StatByStripTextBox)
        With StatByStripTextBox
            .ReadOnly = True
            .ForeColor = Color.Firebrick
            .BorderStyle = BorderStyle.None
            .BackColor = SystemColors.Control
        End With

        'Cancel/Posted Date
        NewStatusStrip.Items.Add(StatDateStripLabel)
        NewStatusStrip.Items.Add(StatDateStripTextBox)
        With StatDateStripTextBox
            .ReadOnly = True
            .ForeColor = Color.Firebrick
            .BorderStyle = BorderStyle.None
            .BackColor = SystemColors.Control
        End With



    End Sub

    Private Sub tStriptxtCKNbr_Click(sender As Object, e As EventArgs) Handles tStriptxtCKNbr.Click

    End Sub

    Private Sub tStriptxtCKNbr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tStriptxtCKNbr.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            If tStriptxtCKNbr.Text = "" Then
                MsgBox("Please Type Reference Number", vbInformation, "System Message")

                Exit Sub
            End If
            SearchRecord(Me.tStriptxtCKNbr.Text)
        End If
    End Sub

    Private Sub ContainerRefundSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContainerRefundSummaryToolStripMenuItem.Click
        frmContainerRefundMonitoring.PopContRefMonitoring()
        frmContainerRefundMonitoring.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        'frmPrintPreview.LoadContainerRefund(Me.txtContRefCtrlNo.Text)
        frmPrintPreview.ShowDialog()
    End Sub
End Class