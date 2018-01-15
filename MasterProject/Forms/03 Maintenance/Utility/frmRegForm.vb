Public Class frmRegForm
    Public _blNewAccess As Boolean
    Public _blReleaseAccess As Boolean
    Public _blCancelAccess As Boolean
    Public _blReOpen As Boolean

    Dim strToDo As String

    Const strToDoView As String = "VIEW"
    Const strToDoNew As String = "NEW"
    Const strTodoRelease As String = "RELEASE"
    Const strTodoCancel As String = "CANCEL"
    Const strToDoReOpen As String = "RE-OPEN"

    'Const strStatus1 As String = "OPEN"
    'Const strStatus2 As String = "RELEASED"
    'Const strStatus3 As String = "CANCELLED"

    Private Function CheckRequiredEntries() As Boolean
        If strToDo <> strTodoCancel Then
            If Me.cboFormType.SelectedIndex = -1 Then
                MsgBox("Please select Form Type!", MsgBoxStyle.Exclamation)
                CheckRequiredEntries = False
                Exit Function
            End If

            If Not (IsNumeric(Me.txtSeriesFrom.Text) And IsNumeric(Me.txtSeriesTo.Text)) Then
                MsgBox("Please enter nemeric values for Series From and To!", MsgBoxStyle.Exclamation)
                CheckRequiredEntries = False
                Exit Function
            End If

            If CDbl(Me.txtSeriesFrom.Text) > CDbl(Me.txtSeriesTo.Text) Then
                MsgBox("Series From must be less than Series To!", MsgBoxStyle.Exclamation)
                CheckRequiredEntries = False
                Exit Function
            End If

            If strToDo = strTodoRelease Then
                If Me.cboModule.SelectedIndex = -1 Then
                    MsgBox("Please select Module!", MsgBoxStyle.Exclamation)
                    CheckRequiredEntries = False
                    Exit Function
                End If
            End If
        End If

        CheckRequiredEntries = True
    End Function

    Private Sub PopNewSeries(ByVal intBeg As Integer, ByVal intEnd As Integer)
        Me.dtgFormList.Rows.Clear()
        For intctr As Integer = intBeg To intEnd
            Me.dtgFormList.Rows.Add()
            With Me.dtgFormList.Rows(Me.dtgFormList.Rows.Count - 1)
                .Cells(colSelected.Name).Value = True
                .Cells(colFormTypeID.Name).Value = Me.cboFormType.SelectedValue
                .Cells(colFormType.Name).Value = Me.cboFormType.Text
                .Cells(colModID.Name).Value = Me.cboModule.SelectedValue
                .Cells(colModName.Name).Value = Me.cboModule.Text
                .Cells(colFormNo.Name).Value = intctr
            End With
        Next
    End Sub

    Private Function SaveDetail() As Boolean
        SaveDetail = False
        If MsgBox("Save selected records? Dupplicate entries will be skipped.", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
            Dim reader As MySql.Data.MySqlClient.MySqlDataReader
            Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction
            Dim dtCurrent As Date = GetServerDate()
            Dim dtgRow As New DataGridViewRow
            Dim intTempCount As Integer = 0

            cmdSQL.Connection = cnnDBMaster
            trnSQL = cnnDBMaster.BeginTransaction
            cmdSQL.Transaction = trnSQL

            Try
                For intctr As Integer = 0 To Me.dtgFormList.Rows.Count - 1
                    dtgRow = Me.dtgFormList.Rows(intctr)
                    If dtgRow.Cells(colSelected.Name).Value = True Then
                        cmdSQL.CommandText = "SELECT COUNT(*) AS RecCount FROM reg_trn_main " &
                                            "WHERE reg_no = @reg_no AND reg_group = @reg_group"

                        With cmdSQL.Parameters
                            .AddWithValue("@reg_no", dtgRow.Cells(colFormNo.Name).Value)
                            .AddWithValue("@reg_group", Me.cboFormType.SelectedValue)
                        End With
                        reader = cmdSQL.ExecuteReader

                        intTempCount = 0
                        While reader.Read
                            intTempCount = reader.Item("RecCount")
                        End While
                        reader.Close()
                        cmdSQL.Parameters.Clear()

                        If intTempCount = 0 Then
                            cmdSQL.CommandText = "INSERT INTO reg_trn_main (`reg_no`,`reg_group`,`related_ref`," &
                                        "`reg_by`,`reg_date`,`reg_modby`,`reg_moddate`,`reg_status`,`reg_statusby`," &
                                        "`reg_statusdate`) " &
                                    "VALUES (@reg_no,@reg_group,@related_ref," &
                                        "@reg_by,@reg_date,@reg_modby,@reg_moddate,@reg_status,@reg_statusby," &
                                        "@reg_statusdate)"

                            With cmdSQL.Parameters
                                .AddWithValue("@reg_no", dtgRow.Cells(colFormNo.Name).Value)
                                .AddWithValue("@reg_group", Me.cboFormType.SelectedValue)
                                .AddWithValue("@related_ref", "")
                                .AddWithValue("@reg_by", CurrentUser)
                                .AddWithValue("@reg_date", dtCurrent)
                                .AddWithValue("@reg_modby", CurrentUser)
                                .AddWithValue("@reg_moddate", dtCurrent)
                                .AddWithValue("@reg_status", 1)
                                .AddWithValue("@reg_statusby", CurrentUser)
                                .AddWithValue("@reg_statusdate", dtCurrent)
                            End With

                            cmdSQL.ExecuteNonQuery()
                            cmdSQL.Parameters.Clear()
                        End If
                    End If
                Next

                trnSQL.Commit()
                cmdSQL.Dispose()
                SaveDetail = True
            Catch ex As Exception
                SaveDetail = False
                Try
                    MsgBox(ex.Message)
                    trnSQL.Rollback()
                Catch ex1 As Exception
                    If Not trnSQL.Connection Is Nothing Then
                        MsgBox("An exception of type " & ex1.GetType().ToString() &
                          " was encountered while attempting to roll back the transaction.")
                    End If
                End Try
            End Try
        End If
    End Function

    Private Function ChangeStatus(ByVal intNewStatus As Integer) As Boolean
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction
        Dim dtCurrent As Date = GetServerDate()
        Dim dtgRow As New DataGridViewRow

        cmdSQL.Connection = cnnDBMaster
        trnSQL = cnnDBMaster.BeginTransaction
        cmdSQL.Transaction = trnSQL

        Try
            For intctr As Integer = 0 To Me.dtgFormList.Rows.Count - 1
                dtgRow = Me.dtgFormList.Rows(intctr)
                If dtgRow.Cells(colSelected.Name).Value = True Then
                    cmdSQL.CommandText = "UPDATE reg_trn_main SET " &
                                            "reg_module = @reg_module, " &
                                            "reg_status = @reg_status, " &
                                            "reg_statusby = @reg_statusby, " &
                                            "reg_statusdate = @reg_statusdate " &
                                        "WHERE reg_no = @reg_no AND reg_group = @reg_group"

                    With cmdSQL.Parameters
                        Select Case intNewStatus
                            Case 2
                                .AddWithValue("@reg_module", Me.cboModule.SelectedValue)
                            Case Else
                                .AddWithValue("@reg_module", DBNull.Value)
                        End Select
                        .AddWithValue("@reg_status", intNewStatus)
                        .AddWithValue("@reg_statusby", CurrentUser)
                        .AddWithValue("@reg_statusdate", dtCurrent)
                        .AddWithValue("@reg_no", dtgRow.Cells(colFormNo.Name).Value)
                        .AddWithValue("@reg_group", Me.cboFormType.SelectedValue)
                    End With

                    cmdSQL.ExecuteNonQuery()
                    cmdSQL.Parameters.Clear()
                End If
            Next

            trnSQL.Commit()
            cmdSQL.Dispose()
            ChangeStatus = True
        Catch ex As Exception
            ChangeStatus = False
            Try
                MsgBox(ex.Message)
                trnSQL.Rollback()
            Catch ex1 As Exception
                If Not trnSQL.Connection Is Nothing Then
                    MsgBox("An exception of type " & ex1.GetType().ToString() &
                      " was encountered while attempting to roll back the transaction.")
                End If
            End Try
        End Try
    End Function

    Public Sub PopFormList()
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            If Not (IsNumeric(Me.txtSearchFrom.Text) And IsNumeric(Me.txtSearchTo.Text)) Then
                cmdSQL.CommandText = "SELECT * " &
                                        "FROM reg_trn_main INNER JOIN reg_lib_group " &
                                            "ON reg_trn_main.reg_group = reg_lib_group.grp_id " &
                                        "LEFT JOIN reg_lib_module " &
                                            "ON reg_trn_main.reg_module = reg_lib_module.mod_id " &
                                        "LEFT JOIN reg_lib_status " &
                                            "ON reg_trn_main.reg_status = reg_lib_status.stat_id " &
                                        "ORDER BY reg_status, reg_group, reg_no"
            Else
                cmdSQL.CommandText = "SELECT * " &
                                        "FROM reg_trn_main INNER JOIN reg_lib_group " &
                                            "ON reg_trn_main.reg_group = reg_lib_group.grp_id " &
                                        "LEFT JOIN reg_lib_module " &
                                            "ON reg_trn_main.reg_module = reg_lib_module.mod_id " &
                                        "LEFT JOIN reg_lib_status " &
                                            "ON reg_trn_main.reg_status = reg_lib_status.stat_id " &
                                        "WHERE reg_no >= @From AND reg_no <= @To " &
                                        "ORDER BY reg_status, reg_group, reg_no"

                cmdSQL.Parameters.AddWithValue("@From", Me.txtSearchFrom.Text)
                cmdSQL.Parameters.AddWithValue("@To", Me.txtSearchTo.Text)
            End If

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            Me.dtgFormList.Rows.Clear()
            While reader.Read
                Me.dtgFormList.Rows.Add()
                With Me.dtgFormList.Rows(Me.dtgFormList.Rows.Count - 1)
                    .Cells(colFormTypeID.Name).Value = CStr(reader.Item("reg_group"))
                    .Cells(colFormType.Name).Value = CStr(reader.Item("grp_name"))
                    .Cells(colModID.Name).Value = CStr(reader.Item("reg_module"))
                    .Cells(colModName.Name).Value = CStr(reader.Item("mod_name"))
                    .Cells(colFormNo.Name).Value = CStr(reader.Item("reg_no"))
                    .Cells(colRefNo.Name).Value = CStr(reader.Item("related_ref"))
                    .Cells(colPrepBy.Name).Value = CStr(reader.Item("reg_by"))
                    .Cells(colPrepDate.Name).Value = CStr(reader.Item("reg_date"))
                    .Cells(colStatusCode.Name).Value = CStr(reader.Item("reg_status"))
                    .Cells(colStatusName.Name).Value = CStr(reader.Item("stat_name"))
                    .Cells(colStatusBy.Name).Value = CStr(reader.Item("reg_statusby"))
                    .Cells(colStatusDate.Name).Value = CStr(reader.Item("reg_statusdate"))
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PopOpenRecords(ByVal intBeg As Integer, ByVal intEnd As Integer, ByVal intFormType As Integer)
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster

            cmdSQL.CommandText = "SELECT * " &
                                    "FROM reg_trn_main INNER JOIN reg_lib_group " &
                                        "ON reg_trn_main.reg_group = reg_lib_group.grp_id " &
                                    "LEFT JOIN reg_lib_module " &
                                        "ON reg_trn_main.reg_module = reg_lib_module.mod_id " &
                                    "LEFT JOIN reg_lib_status " &
                                        "ON reg_trn_main.reg_status = reg_lib_status.stat_id " &
                                    "WHERE reg_no >= @reg_no_from AND reg_no <= @reg_no_to " &
                                        "AND reg_group = @reg_group AND reg_status = 1 " &
                                    "ORDER BY reg_status, reg_group, reg_no"

            cmdSQL.Parameters.AddWithValue("@reg_no_from", intBeg)
            cmdSQL.Parameters.AddWithValue("@reg_no_to", intEnd)
            cmdSQL.Parameters.AddWithValue("@reg_group", intFormType)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            Me.dtgFormList.Rows.Clear()
            While reader.Read
                Me.dtgFormList.Rows.Add()
                With Me.dtgFormList.Rows(Me.dtgFormList.Rows.Count - 1)
                    .Cells(colSelected.Name).Value = True
                    .Cells(colFormTypeID.Name).Value = CStr(reader.Item("reg_group"))
                    .Cells(colFormType.Name).Value = CStr(reader.Item("grp_name"))
                    .Cells(colModID.Name).Value = CStr(reader.Item("reg_module"))
                    .Cells(colModName.Name).Value = CStr(reader.Item("mod_name"))
                    .Cells(colFormNo.Name).Value = CStr(reader.Item("reg_no"))
                    .Cells(colRefNo.Name).Value = CStr(reader.Item("related_ref"))
                    .Cells(colPrepBy.Name).Value = CStr(reader.Item("reg_by"))
                    .Cells(colPrepDate.Name).Value = CStr(reader.Item("reg_date"))
                    .Cells(colStatusCode.Name).Value = CStr(reader.Item("reg_status"))
                    .Cells(colStatusName.Name).Value = CStr(reader.Item("stat_name"))
                    .Cells(colStatusBy.Name).Value = CStr(reader.Item("reg_statusby"))
                    .Cells(colStatusDate.Name).Value = CStr(reader.Item("reg_statusdate"))
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PopNotOpen(ByVal intBeg As Integer, ByVal intEnd As Integer, ByVal intFormType As Integer)
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster

            cmdSQL.CommandText = "SELECT * " &
                                    "FROM reg_trn_main INNER JOIN reg_lib_group " &
                                        "ON reg_trn_main.reg_group = reg_lib_group.grp_id " &
                                    "LEFT JOIN reg_lib_module " &
                                        "ON reg_trn_main.reg_module = reg_lib_module.mod_id " &
                                    "LEFT JOIN reg_lib_status " &
                                        "ON reg_trn_main.reg_status = reg_lib_status.stat_id " &
                                    "WHERE reg_no >= @reg_no_from AND reg_no <= @reg_no_to " &
                                        "AND reg_group = @reg_group AND reg_status <> 1 " &
                                    "ORDER BY reg_status, reg_group, reg_no"

            cmdSQL.Parameters.AddWithValue("@reg_no_from", intBeg)
            cmdSQL.Parameters.AddWithValue("@reg_no_to", intEnd)
            cmdSQL.Parameters.AddWithValue("@reg_group", intFormType)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            Me.dtgFormList.Rows.Clear()
            While reader.Read
                Me.dtgFormList.Rows.Add()
                With Me.dtgFormList.Rows(Me.dtgFormList.Rows.Count - 1)
                    .Cells(colSelected.Name).Value = True
                    .Cells(colFormTypeID.Name).Value = CStr(reader.Item("reg_group"))
                    .Cells(colFormType.Name).Value = CStr(reader.Item("grp_name"))
                    .Cells(colModID.Name).Value = CStr(reader.Item("reg_module"))
                    .Cells(colModName.Name).Value = CStr(reader.Item("mod_name"))
                    .Cells(colFormNo.Name).Value = CStr(reader.Item("reg_no"))
                    .Cells(colRefNo.Name).Value = CStr(reader.Item("related_ref"))
                    .Cells(colPrepBy.Name).Value = CStr(reader.Item("reg_by"))
                    .Cells(colPrepDate.Name).Value = CStr(reader.Item("reg_date"))
                    .Cells(colStatusCode.Name).Value = CStr(reader.Item("reg_status"))
                    .Cells(colStatusName.Name).Value = CStr(reader.Item("stat_name"))
                    .Cells(colStatusBy.Name).Value = CStr(reader.Item("reg_statusby"))
                    .Cells(colStatusDate.Name).Value = CStr(reader.Item("reg_statusdate"))
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearEntries()
        Me.cboFormType.SelectedIndex = -1
        Me.cboModule.SelectedIndex = -1
        Me.txtSeriesFrom.Text = ""
        Me.txtSeriesTo.Text = ""
        Me.txtSearchFrom.Text = ""
        Me.txtSearchTo.Text = ""
        strToDo = strToDoView
    End Sub

    Private Sub EnableObjects(ByVal blNew As Boolean, ByVal blSave As Boolean, ByVal blStatusChange As Boolean, ByVal blUserInput As Boolean)
        Me.tscmdNew.Enabled = blNew
        Me.tscmdSave.Enabled = blSave
        Me.tscmdRelease.Enabled = blStatusChange
        Me.tscmdCancel.Enabled = blStatusChange
        Me.tscmdReOpen.Enabled = blStatusChange

        Me.cboFormType.Enabled = blUserInput
        Me.cboModule.Enabled = blUserInput
        Me.txtSeriesFrom.ReadOnly = Not blUserInput
        Me.txtSeriesTo.ReadOnly = Not blUserInput
        Me.colSelected.Visible = blUserInput

        Me.pnlUserInput.Visible = blUserInput
        Me.pnlViewing.Visible = Not blUserInput

        Me.cboModule.Enabled = False
    End Sub

    Private Sub PopFormType()
        Try
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            Dim strsql As String = "SELECT * FROM reg_lib_group ORDER BY grp_name"

            Dim daChargeTo As MySql.Data.MySqlClient.MySqlDataAdapter

            'Charge To
            Dim dtChargeTo As New DataSet
            daChargeTo = New MySql.Data.MySqlClient.MySqlDataAdapter(strsql, cnnDBMaster)

            daChargeTo.Fill(dtChargeTo)
            With Me.cboFormType
                .DataSource = dtChargeTo.Tables(0).DefaultView
                .DisplayMember = "grp_name"
                .ValueMember = "grp_id"
                .Text = ""
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PopModule()
        Try
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            Dim strsql As String = "SELECT * FROM reg_lib_module ORDER BY mod_id"

            Dim daChargeTo As MySql.Data.MySqlClient.MySqlDataAdapter

            'Charge To
            Dim dtChargeTo As New DataSet
            daChargeTo = New MySql.Data.MySqlClient.MySqlDataAdapter(strsql, cnnDBMaster)

            daChargeTo.Fill(dtChargeTo)
            With Me.cboModule
                .DataSource = dtChargeTo.Tables(0).DefaultView
                .DisplayMember = "mod_name"
                .ValueMember = "mod_id"
                .Text = ""
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmRegForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tscmdReset_Click(sender, e)
    End Sub

    Private Sub tscmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmdNew.Click
        If _blNewAccess = False Then
            MsgBox("You are not allowed to create new record.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ClearEntries()
        Me.dtgFormList.Rows.Clear()
        strToDo = strToDoNew
        EnableObjects(False, True, False, True)
    End Sub

    Private Sub tscmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmdSave.Click
        If CheckRequiredEntries() = False Then
            Exit Sub
        End If

        Select Case strToDo
            Case strToDoNew
                If SaveDetail() = True Then
                    PopFormList()
                    EnableObjects(True, False, True, False)
                    MsgBox("Record saved!", MsgBoxStyle.Exclamation)
                End If
            Case strTodoRelease
                If ChangeStatus(2) = True Then
                    PopFormList()
                    EnableObjects(True, False, True, False)
                    MsgBox("Forms released!", MsgBoxStyle.Exclamation)
                End If
            Case strTodoCancel
                If ChangeStatus(3) = True Then
                    PopFormList()
                    EnableObjects(True, False, True, False)
                    MsgBox("Forms cancelled!", MsgBoxStyle.Exclamation)
                End If
            Case strToDoReOpen
                If ChangeStatus(1) = True Then
                    PopFormList()
                    EnableObjects(True, False, True, False)
                    MsgBox("Forms opened!", MsgBoxStyle.Exclamation)
                End If
        End Select
    End Sub

    Private Sub tscmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmdReset.Click
        ClearEntries()
        PopFormType()
        PopModule()
        PopFormList()
        EnableObjects(True, False, True, False)
    End Sub

    Private Sub tscmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmdCancel.Click
        If _blCancelAccess = False Then
            MsgBox("You are not allowed to cancel forms.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ClearEntries()
        Me.dtgFormList.Rows.Clear()
        strToDo = strTodoCancel
        EnableObjects(False, True, False, True)

        Me.cboModule.Enabled = True
    End Sub

    Private Sub dtgFormList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgFormList.CellContentClick

    End Sub

    Private Sub tscmdReOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmdReOpen.Click
        If _blReOpen = False Then
            MsgBox("You are not allowed to re-open forms.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ClearEntries()
        Me.dtgFormList.Rows.Clear()
        strToDo = strToDoReOpen
        EnableObjects(False, True, False, True)

        Me.cboModule.Enabled = True
    End Sub

    Private Sub txtSeriesFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSeriesFrom.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSeriesFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSeriesFrom.TextChanged
        If Me.chkSingleRecord.Checked = True Then
            Me.txtSeriesTo.Text = Me.txtSeriesFrom.Text
        End If
    End Sub

    Private Sub txtSeriesTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSeriesTo.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSeriesTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSeriesTo.TextChanged

    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        If IsNumeric(Me.txtSeriesFrom.Text) And IsNumeric(Me.txtSeriesTo.Text) Then
            Select Case strToDo
                Case strToDoNew
                    PopNewSeries(Me.txtSeriesFrom.Text, Me.txtSeriesTo.Text)
                Case strTodoRelease
                    PopOpenRecords(Me.txtSeriesFrom.Text, Me.txtSeriesTo.Text, Me.cboFormType.SelectedValue)
                Case strTodoCancel
                    PopOpenRecords(Me.txtSeriesFrom.Text, Me.txtSeriesTo.Text, Me.cboFormType.SelectedValue)
                Case strToDoReOpen
                    PopNotOpen(Me.txtSeriesFrom.Text, Me.txtSeriesTo.Text, Me.cboFormType.SelectedValue)
            End Select
        Else
            MsgBox("Please enter numeric value for Series.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub tscmdRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscmdRelease.Click
        If _blReleaseAccess = False Then
            MsgBox("You are not allowed to release forms.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ClearEntries()
        Me.dtgFormList.Rows.Clear()
        strToDo = strTodoRelease
        EnableObjects(False, True, False, True)

        Me.cboModule.Enabled = True
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        PopFormList()
    End Sub

    Private Sub chkSingleRecord_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSingleRecord.CheckedChanged
        If Me.chkSingleRecord.Checked = True Then
            Me.txtSeriesTo.Enabled = False
            Me.txtSeriesTo.Text = Me.txtSeriesFrom.Text
        Else
            Me.txtSeriesTo.Enabled = True
        End If
    End Sub
End Class