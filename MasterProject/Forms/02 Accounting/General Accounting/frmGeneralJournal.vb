Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmGeneralJournal
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

    Private Sub SaveGJV()
        Dim cmdSQL As New MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        trnSQL = cnnDBMaster.BeginTransaction
        cmdSQL.Connection = cnnDBMaster
        cmdSQL.Transaction = trnSQL

        Try
            If Len(Me.lblGJVNbr.Text) = 0 Then
                Dim dtCurrent As Date = GetServerDate()
                Dim gjvNumber As String

                cmdSQL.CommandText = ("INSERT INTO tbl_gjv (`GJV_Nbr`, `GJV_DtNeed`, `GJV_PayeeID`, `GJV_ChargeID`, `GJV_ChargeTo`, `GJV_Remarks`, `GJV_PrepDate`, `GJV_PrepBy`, `GJV_Cancel`, `GJV_Posted`, `GJV_CompanyCode`, `GJV_CompanyName`, `GJV_Particulars`)  VALUES " &
                                     "               (@GJV_Nbr, @GJV_DtNeed, @GJV_PayeeID, @GJV_ChargeID, @GJV_ChargeTo, @GJV_Remarks, @GJV_PrepDate, @GJV_PrepBy, @GJV_Cancel, @GJV_Posted, @GJV_CompanyCode, @GJV_CompanyName, @GJV_Particulars)")

                Dim objChargeID As IConvertible = TryCast(Me.cboChargeTo.SelectedValue, IConvertible)
                With cmdSQL.Parameters
                    gjvNumber = "GJV" & GetCtrlNbr(strCompanyCode, strSiteCode, "General_Journal_Voucher") & ""

                    If Len(gjvNumber) = 0 Then
                        MsgBox("Error getting General Journal Voucher number.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    .AddWithValue("@GJV_Nbr", gjvNumber)
                    .AddWithValue("@GJV_DtNeed", Me.dtReceipt.Value)
                    .AddWithValue("@GJV_PayeeID", Me.txtPayeeID.Text)
                    .AddWithValue("@GJV_ChargeID", objChargeID)
                    .AddWithValue("@GJV_ChargeTo", Me.txtChargeToName.Text)
                    .AddWithValue("@GJV_Remarks", Me.txtRemarks.Text)
                    .AddWithValue("@GJV_PrepDate", dtCurrent)
                    .AddWithValue("@GJV_PrepBy", CurrentUser)
                    .AddWithValue("@GJV_Posted", 0)
                    .AddWithValue("@GJV_Cancel", 0)
                    .AddWithValue("@GJV_Particulars", Me.txtParticulars.Text)
                    .AddWithValue("@GJV_CompanyCode", Me.txtCompanyCode.Text)
                    .AddWithValue("@GJV_CompanyName", Me.cboCompany.Text)

                    Me.lblGJVNbr.Text = gjvNumber
                End With

                cmdSQL.ExecuteNonQuery()

                UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "General_Journal_Voucher")

                SaveTransLogs("Create new General Journal Voucher", Me.Name, "GJV No.", Me.lblGJVNbr.Text, strCurrentUser)
            Else
                'update record

                Dim objChargeID As IConvertible = TryCast(Me.cboChargeTo.SelectedValue, IConvertible)

                Dim sSQL As String = "UPDATE tbl_gjv SET "
                sSQL += " GJV_DtNeed=@GJV_DtNeed, "
                sSQL += " GJV_PayeeID = @GJV_PayeeID, "
                sSQL += " GJV_ChargeID=@GJV_ChargeID, "
                sSQL += " GJV_ChargeTo=@GJV_ChargeTo, "
                sSQL += " GJV_Remarks=@GJV_Remarks,"
                sSQL += " GJV_CompanyCode=@GJV_CompanyCode,"
                sSQL += " GJV_CompanyName=@GJV_CompanyName,"
                sSQL += " GJV_Particulars=@GJV_Particulars "

                sSQL += " WHERE GJV_Nbr= '" & Me.lblGJVNbr.Text & "'"
                cmdSQL.CommandText = sSQL

                With cmdSQL.Parameters

                    .AddWithValue("@GJV_DtNeed", Me.dtReceipt.Value)
                    .AddWithValue("@GJV_PayeeID", Me.txtPayeeID.Text)
                    .AddWithValue("@GJV_ChargeID", objChargeID)
                    .AddWithValue("@GJV_ChargeTo", Me.txtChargeToName.Text)
                    .AddWithValue("@GJV_Remarks", Me.txtRemarks.Text)
                    .AddWithValue("@GJV_CompanyCode", Me.txtCompanyCode.Text)
                    .AddWithValue("@GJV_CompanyName", Me.cboCompany.Text)
                    .AddWithValue("@GJV_Particulars", Me.txtParticulars.Text)

                End With

                cmdSQL.ExecuteNonQuery()

                'Delete record in gja 
                cmdSQL.CommandText = "DELETE FROM tbl_gja WHERE GJA_GJVNbr = '" & Me.lblGJVNbr.Text & "'"
                cmdSQL.ExecuteNonQuery()

                SaveTransLogs("Edit General Journal Voucher", Me.Name, "GJV No.", Me.lblGJVNbr.Text, strCurrentUser)
            End If

            'delete to tbl_generalledger
            DeleteToGLTable(Me.lblGJVNbr.Text, 13)

            'save details
            Dim h As DataGridViewRow
            For i = 0 To Me.dgDetails.Rows.Count - 1
                h = Me.dgDetails.Rows(i)

                If Not Len(h.Cells(1).Value) = 0 Then
                    cmdSQL.CommandText = ("INSERT INTO tbl_gja (GJA_GJVNbr, GJA_Account_Code, GJA_Account_Title, GJA_DR, GJA_CR, GJA_SubAccount_Code, GJA_SubAccount_Title, GJA_SubAccount_Dept, GJA_SubAccount_DeptName, GJA_SubAccount_List, GJA_SubAccount_ListItem, GJA_SubAccount_ListItemName)  VALUES " &
                                               "                   (@GJA_GJVNbr, @GJA_Account_Code, @GJA_Account_Title, @GJA_DR, @GJA_CR, @GJA_SubAccount_Code, @GJA_SubAccount_Title, @GJA_SubAccount_Dept, @GJA_SubAccount_DeptName, @GJA_SubAccount_List, @GJA_SubAccount_ListItem, @GJA_SubAccount_ListItemName)")

                    cmdSQL.Parameters.Clear()
                    With cmdSQL.Parameters
                        .AddWithValue("@GJA_GJVNbr", Me.lblGJVNbr.Text)
                        .AddWithValue("@GJA_Account_Code", h.Cells(1).Value)
                        .AddWithValue("@GJA_Account_Title", h.Cells(2).Value)
                        .AddWithValue("@GJA_SubAccount_Code", h.Cells(3).Value)
                        .AddWithValue("@GJA_SubAccount_Title", h.Cells(4).Value)
                        .AddWithValue("@GJA_SubAccount_Dept", h.Cells(5).Value)
                        .AddWithValue("@GJA_SubAccount_DeptName", h.Cells(6).Value)
                        .AddWithValue("@GJA_SubAccount_List", h.Cells(7).Value)
                        .AddWithValue("@GJA_SubAccount_ListItem", h.Cells(8).Value)
                        .AddWithValue("@GJA_SubAccount_ListItemName", h.Cells(9).Value)
                        .AddWithValue("@GJA_DR", CDbl(h.Cells(10).Value))
                        .AddWithValue("@GJA_CR", CDbl(h.Cells(11).Value))
                    End With

                    cmdSQL.ExecuteNonQuery()

                    InsertToGLTable(13, GetGeneralLedgerModuleName(13), Me.lblGJVNbr.Text, h.Cells(1).Value, h.Cells(2).Value, h.Cells(3).Value, h.Cells(4).Value, CDbl(h.Cells(10).Value), CDbl(h.Cells(11).Value), h.Cells(5).Value, h.Cells(6).Value, h.Cells(7).Value, h.Cells(8).Value, h.Cells(9).Value)
                End If
            Next
            '*******

            trnSQL.Commit()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            MsgBox("Done Saving.", MsgBoxStyle.Information, "System Message")

        Catch ex As Exception
            Try
                trnSQL.Rollback()
                MsgBox(ex.Message)
            Catch ex1 As Exception
                If Not trnSQL.Connection Is Nothing Then
                    MsgBox("An exception of type " & ex1.GetType().ToString() &
                      " was encountered while attempting to roll back the transaction.")
                End If
            End Try
        End Try

        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        ComputeDebitCreditTotal()
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

            Me.cboChargeTo.Enabled = blUserInput
            Me.cboPayee.Enabled = blUserInput
            Me.txtChargeToName.ReadOnly = Not blUserInput
            Me.dtReceipt.Enabled = blUserInput
            Me.txtParticulars.ReadOnly = Not blUserInput
            Me.txtRemarks.ReadOnly = Not blUserInput
            Me.txtCompanyCode.ReadOnly = Not blUserInput
            Me.cboCompany.Enabled = blUserInput
            Me.dgDetails.ReadOnly = Not blUserInput
            Me.tStriptxtCKNbr.ReadOnly = Not blUserInput
        End With
    End Sub

    Private Sub SearchGJV(ByVal str As String)
        If Len(Me.tStriptxtCKNbr.Text) = 0 Then
            Exit Sub
        End If

        Dim strSQL As String

        If tStriptxtCKNbr.Text = "" Then
            MsgBox("Please Type General Journal Voucher Ref. Number", vbInformation, "System Message")
            Exit Sub
        End If

        strSQL = "SELECT tbl_gjv.GJV_Nbr, tbl_gjv.GJV_DtNeed, tbl_gjv.GJV_PayeeID, tbl_gjv.GJV_ChargeID, tbl_gjv.GJV_ChargeTo, tbl_gjv.GJV_Remarks, tbl_gjv.GJV_PrepDate, tbl_gjv.GJV_PrepBy, tbl_gjv.GJV_Cancel, tbl_gjv.GJV_CancelDate, tbl_gjv.GJV_CancelBy, tbl_gjv.GJV_Posted, tbl_gjv.GJV_PostBy, tbl_gjv.GJV_PostDate, tbl_gjv.GJV_Branch, tbl_gjv.GJV_Particulars, lib_requestparams.ParamCode, lib_requestparams.ParamName,  tbl_vendor.Description " &
                 "FROM  (tbl_gjv INNER JOIN lib_requestparams ON tbl_gjv.GJV_ChargeID = lib_requestparams.ParamCode) INNER JOIN tbl_vendor ON tbl_gjv.GJV_PayeeID = tbl_vendor.Code " &
                 "WHERE tbl_gjv.GJV_Nbr = '" & str & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        While reader.Read()

            If reader.HasRows = False Then
                MsgBox("No Record Found", MsgBoxStyle.Critical, "System Message")
                reader.Close()
                ClearEntries()
                Exit Sub
            End If

            Me.lblGJVNbr.Text = reader.Item("GJV_Nbr")
            Me.dtReceipt.Value = reader.Item("GJV_DtNeed")
            Me.cboChargeTo.Text = reader.Item("ParamName")
            Me.txtChargeToName.Text = reader.Item("GJV_ChargeTo")
            Me.txtRemarks.Text = reader.Item("GJV_Remarks")
            Me.PrepByStripTextBox.Text = reader.Item("GJV_PrepBy")
            Me.PrepDateStripTextBox.Text = reader.Item("GJV_PrepDate")
            Me.txtCompanyCode.Text = reader.Item("GJV_Branch")
            Me.txtParticulars.Text = reader.Item("GJV_Particulars")
            Me.txtCompanyCode.Text = reader.Item("GJV_CompanyCode")
            Me.cboCompany.Text = reader.Item("GJV_CompanyName")
            Me.cboPayee.Text = reader.Item("Description")
            Me.txtPayeeID.Text = reader.Item("GJV_PayeeID")

            If reader.Item("GJV_Posted") = True Then
                StatusStripTextBox.Text = "Posted"
                Me.optStatus.Text = "Posted"
                Me.lblStatusBy.Text = "Posted By:"
                Me.txtStatusBy.Text = reader.Item("GJV_PostBy")
                Me.lblStatusDate.Text = "Post Date:"
                Me.txtStatusDate.Text = reader.Item("GJV_PostDate")
            ElseIf reader.Item("GJV_Cancel") = True Then
                StatusStripTextBox.Text = "Cancelled"
                Me.optStatus.Text = "Cancelled"
                Me.lblStatusBy.Text = "Cancelled By:"
                Me.txtStatusBy.Text = reader.Item("GJV_CancelBy")
                Me.lblStatusDate.Text = "Cancel Date:"
                Me.txtStatusDate.Text = reader.Item("GJV_CancelDate")
            ElseIf reader.Item("GJV_Cancel") = False And reader.Item("GJV_Posted") = False Then
                StatusStripTextBox.Text = "Open"
                Me.optStatus.Text = "Open"
                StatByStripLabel.Text = ""
                Me.StatByStripTextBox.Text = ""
                StatDateStripLabel.Text = ""
                Me.StatDateStripTextBox.Text = ""
            End If

        End While
        With reader.Read

        End With
        cmd.Dispose()
        reader.Close()

        PopulateDetails(Me.lblGJVNbr.Text)
        cnnDBMaster.Close()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

        ComputeDebitCreditTotal()
    End Sub


    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        If Len(Me.lblGJVNbr.Text) = 0 Then
            MsgBox("Nothing to Cancel!", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.optStatus.Text = "Open" Then
            MsgBox("Record already " & Me.optStatus.Text & "!", vbInformation, "Cannot Cancel")
            Exit Sub
        End If

        CancelRecord()
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        If Len(Me.lblGJVNbr.Text) = 0 Then
            MsgBox("Nothing to Edit!", vbInformation, "System Message")
            Exit Sub
        End If

        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If MsgBox("Are you sure you want to create new transaction?", vbYesNo, "Create New?") = vbNo Then Exit Sub

        ClearEntries()
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        If Len(Me.lblGJVNbr.Text) = 0 Then
            MsgBox("Nothing to Post!", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.optStatus.Text = "Open" Then
            MsgBox("Record already " & Me.optStatus.Text & "!", vbInformation, "Cannot Cancel")
            Exit Sub
        End If
        PostRecord()
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        If Len(lblGJVNbr.Text) = 0 Then
            MsgBox("Nothing to Preview", vbInformation, "System Message")
            Exit Sub
        Else
            'frmGeneralJournalPreview.ShowDialog()
        End If
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        If Len(Me.lblGJVNbr.Text) = 0 Then
            MsgBox("Nothing to Re-Open!", vbInformation, "System Message")
            Exit Sub
        End If
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        ClearEntries()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        'Check if other required entries has been properly filled up
        If CheckForRequiredEntries() = False Then
            Exit Sub
        End If

        'check debit credit column
        If Format(SumAmount(10), "N2") <> Format(SumAmount(11), "N2") Then
            MsgBox("Debit / Credit Column not equal", vbInformation, "System Message")
            Exit Sub
        End If

        If MsgBox("Save this record?", vbYesNo, "Confirm Save") = vbNo Then
            Exit Sub
        Else
            SaveGJV()
        End If
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        If tStriptxtCKNbr.Text = "" Then
            MsgBox("Please Type General Journal Voucher Ref. Number", vbInformation, "System Message")
            Exit Sub
        End If
        SearchGJV(Me.tStriptxtCKNbr.Text)
    End Sub

    Private Sub frmGeneralJournal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ColumnProp()
        FillComboBox(Me.cboPayee, "Select Description from tbl_vendor where Code is not null", "Description")
        FillComboBox(Me.cboCompany, "Select Company_Name from tbl_company where Company_Code is not null", "Company_Name")
        FillComboBox(Me.cboChargeTo, "Select ParamName from lib_requestparams where ParamType = 'CRG'", "ParamName")
        UserStripLabel.Text = "Current User: " & strCurrentUser & ""
        MakeTheStatusStrip()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        ClearEntries()
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
            .Columns(10).ReadOnly = False
            .Columns(11).ReadOnly = False

            .Columns(0).Frozen = True
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

    End Sub
    Private Sub CancelGJV(ByVal str As String)
        Dim dtCurrent As Date
        Dim cmdSQL As New MySqlCommand
        dtCurrent = GetServerDate()
        If MsgBox("Are you sure you want to cancel?", vbYesNo, "Confirm Cancel") = vbNo Then
            Exit Sub
        Else
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            Dim sSQL As String = "UPDATE tbl_gjv SET "
            sSQL += " GJV_Cancel=@GJV_Cancel, "
            sSQL += " GJV_CancelBy=@GJV_CancelBy, "
            sSQL += " GJV_CancelDate=@GJV_CancelDate "

            sSQL += " WHERE GJV_Nbr= '" & str & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters
                .AddWithValue("@GJV_Posted", 0)
                .AddWithValue("@GJV_Cancel", 1)
                .AddWithValue("@GJV_CancelBy", CurrentUser)
                .AddWithValue("@GJV_CancelDate", dtCurrent)
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()


            MsgBox("Record Cancelled", vbInformation, "System Message")
            StatusStripTextBox.Text = "Cancelled"
            Me.optStatus.Text = "Cancelled"
            Me.lblStatusBy.Text = "Cancelled By:"
            Me.txtStatusBy.Text = strCurrentUser
            Me.lblStatusDate.Text = "Cancel Date:"
            Me.txtStatusDate.Text = dtCurrent

            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

        End If
    End Sub
    Private Sub PostGJV(ByVal str As String)
        Dim dtCurrent As Date
        Dim cmdSQL As New MySqlCommand
        dtCurrent = GetServerDate()
        If MsgBox("Are you sure you want to post?", vbYesNo, "Confirm Post") = vbNo Then
            Exit Sub
        Else
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim sSQL As String = "UPDATE tbl_gjv SET "
            sSQL += " GJV_Posted=@GJV_Posted, "
            sSQL += " GJV_PostBy=@GJV_PostBy, "
            sSQL += " GJV_PostDate=@GJV_PostDate "

            sSQL += " WHERE GJV_Nbr= '" & str & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters

                .AddWithValue("@GJV_Cancel", 0)
                .AddWithValue("@GJV_Posted", 1)
                .AddWithValue("@GJV_PostBy", CurrentUser)
                .AddWithValue("@GJV_PostDate", dtCurrent)


            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            MsgBox("Record Posted", vbInformation, "System Message")
            StatusStripTextBox.Text = "Posted"
            Me.optStatus.Text = "Posted"
            Me.lblStatusBy.Text = "Posted By:"
            Me.txtStatusBy.Text = strCurrentUser
            Me.lblStatusDate.Text = "Post Date:"
            Me.txtStatusDate.Text = dtCurrent

            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        End If
    End Sub
    Private Sub ReOpenGJV(ByVal str As String)
        Dim dtCurrent As Date
        Dim cmdSQL As New MySqlCommand
        dtCurrent = GetServerDate()
        If MsgBox("Are you sure you want to re-open?", vbYesNo, "Confirm Re-Open") = vbNo Then
            Exit Sub
        Else
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim sSQL As String = "UPDATE tbl_gjv SET "

            sSQL += " GJV_Posted=0, "
            sSQL += " GJV_PostBy=null, "
            sSQL += " GJV_PostDate=@null "
            sSQL += " GJV_Cancel=0, "
            sSQL += " GJV_CancelBy=null, "
            sSQL += " GJV_CancelDate=null "

            sSQL += " WHERE GJV_Nbr= '" & str & "'"
            cmdSQL.CommandText = sSQL

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            MsgBox("Record Re-Opened", vbInformation, "System Message")
            StatusStripTextBox.Text = "Open"
            Me.optStatus.Text = "Open"
            Me.lblStatusBy.Text = ""
            Me.txtStatusBy.Text = ""
            Me.lblStatusDate.Text = ""
            Me.txtStatusDate.Text = ""

            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        End If
    End Sub

    Private Sub PopulateDetails(ByVal str As String)
        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM tbl_gja " &
                 "WHERE GJA_GJVNbr = '" & str & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView = Me.dgDetails

        gridBook.Rows.Clear()
        While reader.Read
            gridBook.Rows.Add("", reader.Item("GJA_Account_Code"), reader.Item("GJA_Account_Title"), reader.Item("GJA_SubAccount_Code"), reader.Item("GJA_SubAccount_Title"), reader.Item("GJA_SubAccount_Dept"), reader.Item("GJA_SubAccount_DeptName"), reader.Item("GJA_SubAccount_List"), reader.Item("GJA_SubAccount_ListItem"), reader.Item("GJA_SubAccount_ListItemName"), reader.Item("GJA_DR"), reader.Item("GJA_CR"))
            i = i + 1
        End While

        cmd.Dispose()
        reader.Close()
    End Sub

    'Debit Credit Total Amount value
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

    Private Sub ComputeDebitCreditTotal()
        txtDebit.Text = SumAmount(10)
        txtCredit.Text = SumAmount(11)
    End Sub

    Private Sub btAddBook_Click(sender As Object, e As EventArgs) Handles btAddBook.Click
        dgDetails.Rows.Add()
    End Sub

    Private Sub btRemove_Click(sender As Object, e As EventArgs) Handles btRemove.Click
        If Not dgDetails.CurrentRow.IsNewRow Then
            dgDetails.Rows.Remove(dgDetails.CurrentRow)
        End If
    End Sub

    Private Sub dgDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetails.CellContentClick
        frmSelectGLEntry.Tag = "GJV"
        frmSelectGLEntry.txtLineNbr.Text = e.RowIndex
        frmSelectGLEntry.ShowDialog()
    End Sub

    Private Sub tStriptxtCKNbr_Click(sender As Object, e As EventArgs) Handles tStriptxtCKNbr.Click

    End Sub

    Private Sub tStriptxtCKNbr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tStriptxtCKNbr.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            If tStriptxtCKNbr.Text = "" Then
                MsgBox("Please Type General Journal Voucher Number", vbInformation, "System Message")

                Exit Sub
            End If
            SearchGJV(Me.tStriptxtCKNbr.Text)
        End If
    End Sub

    Private Function CheckForRequiredEntries() As Boolean
        'check payee
        If Len(txtPayeeID.Text) = 0 Then
            MsgBox("Please select Payee.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        'check particulars 
        If Len(txtParticulars.Text) = 0 Then
            MsgBox("Please enter Particulars.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        'check remarks 
        If Len(txtRemarks.Text) = 0 Then
            MsgBox("Please enter Remarks.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        'check branch 
        If Len(txtCompanyCode.Text) = 0 Then
            MsgBox("Please select Company.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        'check if particulars with corresponding amount is present.
        If Not Me.dgDetails.Rows.Count = 0 Then
            For Each row As DataGridViewRow In dgDetails.Rows
                If row.Cells(3).Value = String.Empty Then
                    MsgBox("Please enter department.", MsgBoxStyle.Critical, "Missing Information")
                    CheckForRequiredEntries = False
                    Exit For
                End If
                If Len(row.Cells(4).Value) = 0 And row.Cells(5).Value <= 0 Then
                    MsgBox("Please enter an amount.", MsgBoxStyle.Critical, "Missing Information")
                    CheckForRequiredEntries = False
                    Exit Function
                End If

            Next row
        Else
            MsgBox("Please input details.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        'Charge To
        If Me.cboChargeTo.SelectedIndex = -1 Then
            MsgBox("Please Select Charge to.", MsgBoxStyle.Critical, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If cboChargeTo.Text = "Acestar" Then
            txtChargeToName.Text = "Acestar"
        Else
            If Len(txtChargeToName.Text) = 0 Then
                MsgBox("Please type Charge to", MsgBoxStyle.Critical, "System Message")
                txtChargeToName.Focus()
                CheckForRequiredEntries = False
                Exit Function
            End If
        End If

        CheckForRequiredEntries = True
    End Function

    Private Sub cboChargeTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChargeTo.SelectedIndexChanged
        If Me.cboChargeTo.Text = "Acestar" Then
            txtChargeToName.Text = "Acestar"
            txtChargeToName.ReadOnly = True
        Else
            txtChargeToName.Text = ""
            txtChargeToName.ReadOnly = False
        End If
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
        If dgDetails.CurrentCell.ColumnIndex = 10 Or dgDetails.CurrentCell.ColumnIndex = 11 Then
            SetCharacter(MyOption.Numeric, e)
        Else
            SetCharacter(MyOption.AlphaNumeric, e)
        End If
    End Sub

    Private Sub cboPayee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayee.SelectedIndexChanged
        If Me.cboPayee.SelectedIndex = -1 Then Exit Sub

        Me.txtPayeeID.Text = GetStringValue("Select Code from tbl_vendor WHERE Description = '" & Me.cboPayee.Text & "'", "Description")
    End Sub

    Private Sub ClearEntries()
        Me.cboPayee.Text = ""
        Me.cboPayee.SelectedIndex = -1
        Me.txtPayeeID.Text = ""
        Me.cboCompany.Text = ""
        Me.cboCompany.SelectedIndex = -1
        Me.txtCompanyCode.Text = ""
        Me.cboChargeTo.Text = ""
        Me.cboChargeTo.SelectedIndex = -1
        Me.dtReceipt.Value = Now
        Me.txtRemarks.Text = ""
        Me.txtParticulars.Text = ""
        Me.optStatus.Text = ""
        Me.txtStatusBy.Text = ""
        Me.txtStatusDate.Text = ""
        Me.dgDetails.Rows.Clear()
        Me.tStriptxtCKNbr.Text = ""
        Me.lblGJVNbr.Text = ""
    End Sub

    Private Sub cboCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCompany.SelectedIndexChanged
        If Me.cboCompany.SelectedIndex = -1 Then Exit Sub

        Me.txtCompanyCode.Text = GetStringValue("Select Company_Code from tbl_company WHERE Company_Name = '" & Me.cboCompany.Text & "'", "Company_Code")
    End Sub

    Private Sub tStripClose_Click(sender As Object, e As EventArgs) Handles tStripClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

End Class