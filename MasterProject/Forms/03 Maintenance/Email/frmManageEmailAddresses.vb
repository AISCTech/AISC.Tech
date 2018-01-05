Imports MasterProject

Public Class frmManageEmailAddresses
    Implements ICommonFunction

    Public clsEmailRecord As New clsEmailAddress
    Private dvDataView As DataView

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord

    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        ChangeEnabledButtons(True, False, True, True, False, False, False, False, False, True)
        txtEmailAddress.Focus()
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        ClearUserInput()
        ChangeEnabledButtons(True, False, True, True, False, False, False, False, False, True)
        txtEmailAddress.Focus()
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord

    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord

    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        If clsEmailRecord._ID > 0 Then
            PopulateEmailRecord(clsEmailRecord._ID)
        Else
            ClearUserInput()
            ChangeEnabledButtons(True, False, False, True, False, False, False, False, False, False)
        End If

        PopulateEmailRecordList()
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If Len(txtEmailAddress.Text) = 0 Then
            MsgBox("Please enter Email Address.", MsgBoxStyle.Exclamation, "System Message")
            txtEmailAddress.Focus()
            Exit Sub
        End If

        If Len(txtHost.Text) = 0 Then
            MsgBox("Please enter SMTP Host.", MsgBoxStyle.Exclamation, "System Message")
            txtHost.Focus()
            Exit Sub
        End If

        If Len(txtPort.Text) = 0 Then
            MsgBox("Please enter SMTP Host.", MsgBoxStyle.Exclamation, "System Message")
            txtPort.Focus()
            Exit Sub
        End If

        If Len(txtUsername.Text) = 0 Then
            MsgBox("Please enter SMTP Username.", MsgBoxStyle.Exclamation, "System Message")
            txtUsername.Focus()
            Exit Sub
        End If

        If Len(txtPassword.Text) = 0 Then
            MsgBox("Please enter SMTP Password.", MsgBoxStyle.Exclamation, "System Message")
            txtPassword.Focus()
            Exit Sub
        End If

        If MsgBox("Save record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
            Dim clsTempDB As New clsDBTrans

            With clsEmailRecord
                ._EmailAddress = txtEmailAddress.Text
                ._SMTP_Host = txtHost.Text
                ._SMTP_Port = txtPort.Text
                ._SMTP_Username = txtUsername.Text
                ._SMTP_Password = txtPassword.Text
                ._SMTP_EnableSSL = chkSSL.Checked
                ._PrepBy._User_ID = CurrentUser._User_ID
                ._ModBy._User_ID = CurrentUser._User_ID
            End With

            clsEmailRecord = clsTempDB.SaveEmailAddress(clsEmailRecord)
            PopulateEmailRecord(clsEmailRecord._ID)
            PopulateEmailRecordList()
        End If
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord

    End Sub

    Private Sub PopulateEmailRecord(ByVal lngID As Long)
        Dim clsTempDB As New clsDBTrans
        clsEmailRecord = clsTempDB.SearchEmailAddress(lngID)

        If clsEmailRecord._ID <= 0 Then
            MsgBox("Record not found.", MsgBoxStyle.Exclamation, "System Message")
        Else
            With clsEmailRecord
                txtEmailAddress.Text = ._EmailAddress
                txtHost.Text = ._SMTP_Host
                txtPort.Text = ._SMTP_Port
                txtUsername.Text = ._SMTP_Username
                txtPassword.Text = ._SMTP_Password
                chkSSL.Checked = ._SMTP_EnableSSL
                txtPrepBy.Text = ._PrepBy._First_Name & " " & ._PrepBy._Last_Name
                txtPrepDate.Text = ._PrepDate
                txtModBy.Text = ._ModBy._First_Name & " " & ._ModBy._Last_Name
                txtModDate.Text = ._ModDate
            End With

            lblShowPass.Text = "Show"
            txtPassword.PasswordChar = "*"
        End If

        ChangeEnabledButtons(True, True, False, True, False, False, False, False, False, False)
    End Sub

    Private Sub PopulateEmailRecordList()
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT ID, " &
                                    "EmailAddress AS `Email Address`, " &
                                    "SMTP_Host AS `SMTP Host`, " &
                                    "SMTP_Port AS `SMTP Port`, " &
                                    "IF(SMTP_EnableSSL=1, 'True', 'False') AS `Enable SSL` " &
                                "FROM " &
                                    "v_email"

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView
            dtgEmailList.Columns.Clear()
            dtgEmailList.DataSource = dvDataView

            dtgEmailList.Columns(0).Frozen = True
            dtgEmailList.Columns(1).Frozen = True

            dtgEmailList.Columns(0).Visible = False

            dtgEmailList.Columns(1).Width = 300
            dtgEmailList.Columns(2).Width = 250
            dtgEmailList.Columns(3).Width = 100
            dtgEmailList.Columns(4).Width = 100
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearUserInput()
        clsEmailRecord = New clsEmailAddress
        txtEmailAddress.Text = ""
        txtHost.Text = ""
        txtPort.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        chkSSL.Checked = False
        txtPrepBy.Text = ""
        txtPrepDate.Text = ""
        txtModBy.Text = ""
        txtModDate.Text = ""
    End Sub

    Private EnableButtons As New clsEnableToolstripObjects()
    Private Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
                                     ByVal blPrintPreview As Boolean, ByVal blSearch As Boolean, ByVal blPost As Boolean,
                                     ByVal blCancel As Boolean, ByVal blReOpen As Boolean, ByVal blUserInput As Boolean)
        With EnableButtons
            .NewEnabled = blNew
            .EditEnabled = blEdit
            .SaveEnabled = blSave
            .ResetEnabled = blReset
            .PrintPreviewEnabled = blPrintPreview
            .SearchEnabled = blSearch
            .PostEnabled = blPost
            .CancelEnabled = blCancel
            .ReOpen = blReOpen

            .UpdateEnabledButtons()
        End With

        txtEmailAddress.ReadOnly = Not blUserInput
        txtHost.ReadOnly = Not blUserInput
        txtPort.ReadOnly = Not blUserInput
        txtUsername.ReadOnly = Not blUserInput
        txtPassword.ReadOnly = Not blUserInput
        chkSSL.AutoCheck = blUserInput
        dtgEmailList.Enabled = Not blUserInput
        txtFilter.Enabled = Not blUserInput
    End Sub

    Private Sub frmManageEmailAddresses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetRecord()
    End Sub

    Private Sub frmManageEmailAddresses_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmManageEmailAddresses_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub dtgEmailList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgEmailList.CellContentClick

    End Sub

    Private Sub dtgEmailList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgEmailList.CellClick
        If e.RowIndex >= 0 Then
            PopulateEmailRecord(dtgEmailList.Rows(e.RowIndex).Cells(0).Value)
        End If
    End Sub

    Private Sub lblShowPass_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblShowPass.LinkClicked
        If lblShowPass.Text = "Show" Then
            txtPassword.PasswordChar = ""
            lblShowPass.Text = "Hide"
        Else
            txtPassword.PasswordChar = "*"
            lblShowPass.Text = "Show"
        End If
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        dvDataView.RowFilter = "`Email Address` LIKE '%" & Replace(txtFilter.Text, "'", "''") & "%'"
    End Sub
End Class