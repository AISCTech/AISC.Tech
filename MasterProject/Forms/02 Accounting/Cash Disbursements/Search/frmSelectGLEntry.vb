Imports MySql.Data.MySqlClient
Public Class frmSelectGLEntry

    Dim ListName As String
    Private Sub frmSelectGLEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateGLMain(Me.dgGLMain, Me.txtFilter.Text)
    End Sub

    Private Sub PopulateGLMain(ByVal dg As DataGridView, ByVal str As String)
        dg.Rows.Clear()

        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM lib_acctcode " &
                 "WHERE Account_Title like '%" & str & "%' " &
                 "ORDER BY Account_Title"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read
            dg.Rows.Add(reader.Item("Account_Code"), reader.Item("Account_Title"), reader.Item("Account_Type"), reader.Item("Account_Report"), reader.Item("Account_LineItems"), reader.Item("Account_Sub"))
        End While

        cmd.Dispose()
        reader.Close()
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        PopulateGLMain(Me.dgGLMain, Me.txtFilter.Text)
    End Sub

    Private Sub dgGLMain_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgGLMain.CellContentClick

    End Sub

    Private Sub dgGLMain_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgGLMain.CellDoubleClick
        cboAffiliates.Enabled = False
        cboAgents.Enabled = False
        cboBank.Enabled = False
        cboClient.Enabled = False
        cboDept.Enabled = False
        cboEmployee.Enabled = False
        cboLGA.Enabled = False
        cboVendor.Enabled = False

        cboAffiliates.Text = ""
        cboAgents.Text = ""
        cboBank.Text = ""
        cboClient.Text = ""
        cboDept.Text = ""
        cboEmployee.Text = ""
        cboLGA.Text = ""
        cboVendor.Text = ""

        Dim h As DataGridViewRow

        Select Case Me.Tag

            Case "APV"
                If Me.dgGLMain.CurrentRow.Cells(5).Value = True Then
                    PopGLSub(Me.dgGLSub, Me.dgGLMain.CurrentRow.Cells(0).Value)
                Else
                    h = frmAPV.dgGLEntry.Rows(Val(Me.txtLineNbr.Text))
                    h.Cells(1).Value = Me.dgGLMain.SelectedCells(0).Value
                    h.Cells(2).Value = Me.dgGLMain.SelectedCells(1).Value
                    h.Cells(3).Value = ""
                    h.Cells(4).Value = ""
                    h.Cells(5).Value = False
                    h.Cells(6).Value = ""
                    h.Cells(7).Value = False
                    h.Cells(8).Value = ""
                    h.Cells(9).Value = ""

                    Me.Dispose()
                    Me.Close()
                End If
            Case "PCRelease"
                If Me.dgGLMain.CurrentRow.Cells(5).Value = True Then
                    PopGLSub(Me.dgGLSub, Me.dgGLMain.CurrentRow.Cells(0).Value)
                Else
                    h = frmPettyCashRelease.dtgPCReleaseEntry.Rows(Val(Me.txtLineNbr.Text))
                    h.Cells(1).Value = Me.dgGLMain.SelectedCells(0).Value
                    h.Cells(2).Value = Me.dgGLMain.SelectedCells(1).Value
                    h.Cells(3).Value = ""
                    h.Cells(4).Value = ""
                    h.Cells(5).Value = False
                    h.Cells(6).Value = ""
                    h.Cells(7).Value = False
                    h.Cells(8).Value = ""
                    h.Cells(9).Value = ""

                    Me.Dispose()
                    Me.Close()
                End If

            Case "PCV"
                If Me.dgGLMain.CurrentRow.Cells(5).Value = True Then
                    PopGLSub(Me.dgGLSub, Me.dgGLMain.CurrentRow.Cells(0).Value)
                Else
                    h = frmPettyCashPost.dgPost.Rows(Val(Me.txtLineNbr.Text))
                    h.Cells(1).Value = Me.dgGLMain.SelectedCells(0).Value
                    h.Cells(2).Value = Me.dgGLMain.SelectedCells(1).Value
                    h.Cells(3).Value = ""
                    h.Cells(4).Value = ""
                    h.Cells(5).Value = False
                    h.Cells(6).Value = ""
                    h.Cells(7).Value = False
                    h.Cells(8).Value = ""
                    h.Cells(9).Value = ""

                    Me.Dispose()
                    Me.Close()
                End If
        End Select
    End Sub

    Public Sub PopGLSub(ByVal dg As DataGridView, ByVal str As String)
        dg.Rows.Clear()

        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM lib_subacctcode " &
                 "WHERE Account_Code = '" & str & "' " &
                 "ORDER BY SubAccount_Title"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read
            dg.Rows.Add(reader.Item("Account_Code"), reader.Item("SubAccount_Code"), reader.Item("SubAccount_Title"), reader.Item("SubAccount_Dept"), reader.Item("SubAccount_List"), reader.Item("SubAccount_ListItem"))
        End While

        cmd.Dispose()
        reader.Close()
    End Sub

    Private Sub dgGLSub_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgGLSub.CellContentClick

    End Sub

    Private Sub dgGLSub_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgGLSub.CellDoubleClick
        If Me.dgGLSub.SelectedCells(3).Value = True Then
            cboDept.Enabled = True

        Else
            cboDept.Enabled = False
            cboDept.Text = ""
        End If

        If Me.dgGLSub.CurrentRow.Cells(4).Value = True Then
            If Me.dgGLSub.CurrentRow.Cells(5).Value = "Agent" Then
                cboAgents.Enabled = True
            Else
                cboAgents.Enabled = False
            End If

            If Me.dgGLSub.CurrentRow.Cells(5).Value = "Client" Then
                cboClient.Enabled = True
            Else
                cboClient.Enabled = False
            End If

            If Me.dgGLSub.CurrentRow.Cells(5).Value = "Vendor" Then
                cboVendor.Enabled = True
            Else
                cboVendor.Enabled = False
            End If

            If Me.dgGLSub.CurrentRow.Cells(5).Value = "Banks" Then
                cboBank.Enabled = True
            Else
                cboBank.Enabled = False
            End If

            If Me.dgGLSub.CurrentRow.Cells(5).Value = "Affiliates" Then
                cboAffiliates.Enabled = True
            Else
                cboAffiliates.Enabled = False
            End If

            If Me.dgGLSub.CurrentRow.Cells(5).Value = "Local and Government Agency" Then
                cboLGA.Enabled = True
            Else
                cboLGA.Enabled = False
            End If

            If Me.dgGLSub.CurrentRow.Cells(5).Value = "Employees" Then
                cboEmployee.Enabled = True
            Else
                cboEmployee.Enabled = False
            End If
        Else
            cboAffiliates.Enabled = False
            cboBank.Enabled = False
            cboClient.Enabled = False
            'cboDept.Enabled = False
            cboEmployee.Enabled = False
            cboLGA.Enabled = False
            cboVendor.Enabled = False

            Me.cboAffiliates.Text = ""
            Me.cboBank.Text = ""
            Me.cboClient.Text = ""
            'Me.cboDept.Text = ""
            Me.cboEmployee.Text = ""
            Me.cboLGA.Text = ""
            Me.cboVendor.Text = ""
        End If
    End Sub

    Private Sub btSelect_Click(sender As Object, e As EventArgs) Handles btSelect.Click
        Dim h As DataGridViewRow

        ListName = ""

        Select Case Me.Tag

            Case "APV"
                If CheckForRequiredEntries() = False Then
                    Exit Sub
                End If
                'If Me.DataGridView1.CurrentRow.Cells(2).Value = True Then
                'PopulateSubAccount()
                'Else
                h = frmAPV.dgGLEntry.Rows(Val(Me.txtLineNbr.Text))

                h.Cells(1).Value = Me.dgGLMain.SelectedCells(0).Value
                h.Cells(2).Value = Me.dgGLMain.SelectedCells(1).Value
                h.Cells(3).Value = Me.dgGLSub.SelectedCells(1).Value
                h.Cells(4).Value = Me.dgGLSub.SelectedCells(2).Value
                h.Cells(5).Value = Me.dgGLSub.SelectedCells(3).Value
                h.Cells(6).Value = Me.cboDept.Text
                h.Cells(7).Value = Me.dgGLSub.SelectedCells(4).Value
                h.Cells(8).Value = Me.dgGLSub.SelectedCells(5).Value

                If Me.dgGLSub.SelectedCells(5).Value = "Client" Then
                    ListName = cboClient.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Agent" Then
                    ListName = cboAgents.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Vendor" Then
                    ListName = cboVendor.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Affiliates" Then
                    ListName = cboAffiliates.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Banks" Then
                    ListName = cboBank.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Employees" Then
                    ListName = cboEmployee.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Local and Government Agency" Then
                    ListName = cboLGA.Text
                End If

                h.Cells(9).Value = ListName
                Me.Close()
                'DataGridView2.Rows.Clear()
                'End If

            Case "CV"
                'If CheckForRequiredEntries() = False Then
                '    Exit Sub
                'End If

                'h = frmCV.dtgCheckEntry.Rows(Val(Me.txtLineNbr.Text))

                'h.Cells(1).Value = Me.dgGLMain.SelectedCells(0).Value
                'h.Cells(2).Value = Me.dgGLMain.SelectedCells(1).Value
                'h.Cells(3).Value = Me.dgGLSub.SelectedCells(1).Value
                'h.Cells(4).Value = Me.dgGLSub.SelectedCells(2).Value
                'h.Cells(5).Value = Me.dgGLSub.SelectedCells(3).Value
                'h.Cells(6).Value = Me.cboDept.Text
                'h.Cells(7).Value = Me.dgGLSub.SelectedCells(4).Value
                'h.Cells(8).Value = Me.dgGLSub.SelectedCells(5).Value

                'If Me.dgGLSub.SelectedCells(5).Value = "Client" Then
                '    ListName = cboClient.Text
                'ElseIf Me.dgGLSub.SelectedCells(5).Value = "Agent" Then
                '    ListName = cboAgents.Text
                'ElseIf Me.dgGLSub.SelectedCells(5).Value = "Vendor" Then
                '    ListName = cboVendor.Text
                'ElseIf Me.dgGLSub.SelectedCells(5).Value = "Affiliates" Then
                '    ListName = cboAffiliates.Text
                'ElseIf Me.dgGLSub.SelectedCells(5).Value = "Banks" Then
                '    ListName = cboBank.Text
                'ElseIf Me.dgGLSub.SelectedCells(5).Value = "Employees" Then
                '    ListName = cboEmployee.Text
                'ElseIf Me.dgGLSub.SelectedCells(5).Value = "Local and Government Agency" Then
                '    ListName = cboLGA.Text
                'End If

                'h.Cells(9).Value = ListName
                'Me.Close()

            Case "PCRelease"

                If CheckForRequiredEntries() = False Then
                    Exit Sub
                End If
                'If Me.DataGridView1.CurrentRow.Cells(2).Value = True Then
                'PopulateSubAccount()
                'Else
                h = frmPettyCashRelease.dtgPCReleaseEntry.Rows(Val(Me.txtLineNbr.Text))

                h.Cells(1).Value = Me.dgGLMain.SelectedCells(0).Value
                h.Cells(2).Value = Me.dgGLMain.SelectedCells(1).Value
                h.Cells(5).Value = Me.dgGLSub.SelectedCells(1).Value
                h.Cells(6).Value = Me.dgGLSub.SelectedCells(2).Value
                h.Cells(7).Value = Me.dgGLSub.SelectedCells(3).Value
                h.Cells(8).Value = Me.cboDept.Text
                h.Cells(9).Value = Me.dgGLSub.SelectedCells(4).Value
                h.Cells(10).Value = Me.dgGLSub.SelectedCells(5).Value

                If Me.dgGLSub.SelectedCells(5).Value = "Client" Then
                    ListName = cboClient.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Agent" Then
                    ListName = cboAgents.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Vendor" Then
                    ListName = cboVendor.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Affiliates" Then
                    ListName = cboAffiliates.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Banks" Then
                    ListName = cboBank.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Employees" Then
                    ListName = cboEmployee.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Local and Government Agency" Then
                    ListName = cboLGA.Text
                End If

                h.Cells(11).Value = ListName
                Me.Close()

            Case "PCV"

                If CheckForRequiredEntries() = False Then
                    Exit Sub
                End If

                h = frmPettyCashPost.dgPost.Rows(Val(Me.txtLineNbr.Text))

                h.Cells(1).Value = Me.dgGLMain.SelectedCells(0).Value
                h.Cells(2).Value = Me.dgGLMain.SelectedCells(1).Value
                h.Cells(3).Value = Me.dgGLSub.SelectedCells(1).Value
                h.Cells(4).Value = Me.dgGLSub.SelectedCells(2).Value
                h.Cells(5).Value = Me.dgGLSub.SelectedCells(3).Value
                h.Cells(6).Value = Me.cboDept.Text
                h.Cells(7).Value = Me.dgGLSub.SelectedCells(4).Value
                h.Cells(8).Value = Me.dgGLSub.SelectedCells(5).Value

                If Me.dgGLSub.SelectedCells(5).Value = "Client" Then
                    ListName = cboClient.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Agent" Then
                    ListName = cboAgents.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Vendor" Then
                    ListName = cboVendor.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Affiliates" Then
                    ListName = cboAffiliates.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Banks" Then
                    ListName = cboBank.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Employees" Then
                    ListName = cboEmployee.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Local and Government Agency" Then
                    ListName = cboLGA.Text
                End If

                h.Cells(9).Value = ListName
                Me.Close()

            Case "GJV"
                If CheckForRequiredEntries() = False Then
                    Exit Sub
                End If

                h = frmGeneralJournal.dgDetails.Rows(Val(Me.txtLineNbr.Text))

                h.Cells(1).Value = Me.dgGLMain.SelectedCells(0).Value
                h.Cells(2).Value = Me.dgGLMain.SelectedCells(1).Value
                h.Cells(3).Value = Me.dgGLSub.SelectedCells(1).Value
                h.Cells(4).Value = Me.dgGLSub.SelectedCells(2).Value
                h.Cells(5).Value = Me.dgGLSub.SelectedCells(3).Value
                h.Cells(6).Value = Me.cboDept.Text
                h.Cells(7).Value = Me.dgGLSub.SelectedCells(4).Value
                h.Cells(8).Value = Me.dgGLSub.SelectedCells(5).Value

                If Me.dgGLSub.SelectedCells(5).Value = "Client" Then
                    ListName = cboClient.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Agent" Then
                    ListName = cboAgents.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Vendor" Then
                    ListName = cboVendor.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Affiliates" Then
                    ListName = cboAffiliates.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Banks" Then
                    ListName = cboBank.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Employees" Then
                    ListName = cboEmployee.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Local and Government Agency" Then
                    ListName = cboLGA.Text
                End If

                h.Cells(9).Value = ListName
                Me.Close()

            Case "DRV"
                If CheckForRequiredEntries() = False Then
                    Exit Sub
                End If

                h = frmDepositReceiptsVoucher.dgDetails.Rows(Val(Me.txtLineNbr.Text))

                h.Cells(1).Value = Me.dgGLMain.SelectedCells(0).Value
                h.Cells(2).Value = Me.dgGLMain.SelectedCells(1).Value
                h.Cells(3).Value = Me.dgGLSub.SelectedCells(1).Value
                h.Cells(4).Value = Me.dgGLSub.SelectedCells(2).Value
                h.Cells(5).Value = Me.dgGLSub.SelectedCells(3).Value
                h.Cells(6).Value = Me.cboDept.Text
                h.Cells(7).Value = Me.dgGLSub.SelectedCells(4).Value
                h.Cells(8).Value = Me.dgGLSub.SelectedCells(5).Value

                If Me.dgGLSub.SelectedCells(5).Value = "Client" Then
                    ListName = cboClient.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Agent" Then
                    ListName = cboAgents.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Vendor" Then
                    ListName = cboVendor.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Affiliates" Then
                    ListName = cboAffiliates.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Banks" Then
                    ListName = cboBank.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Employees" Then
                    ListName = cboEmployee.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Local and Government Agency" Then
                    ListName = cboLGA.Text
                End If

                h.Cells(9).Value = ListName
                Me.Close()
        End Select
    End Sub

    Private Function CheckForRequiredEntries() As Boolean

        If Me.dgGLMain.SelectedCells(0).Value <> Me.dgGLSub.SelectedCells(0).Value Then
            MsgBox("Account Code and Sub Account does not match", MsgBoxStyle.Critical, "Invalid Information")
            CheckForRequiredEntries = False
            Me.cboAffiliates.Text = ""
            Me.cboBank.Text = ""
            Me.cboClient.Text = ""
            Me.cboDept.Text = ""
            Me.cboEmployee.Text = ""
            Me.cboLGA.Text = ""
            Me.cboVendor.Text = ""
            Exit Function
        End If

        If Me.dgGLSub.SelectedCells(5).Value = "Client" Then
            If cboClient.Text = "" Then
                MsgBox("Please select Client Name.", MsgBoxStyle.Critical, "Missing Information")
                CheckForRequiredEntries = False
                Exit Function
            End If
        ElseIf Me.dgGLSub.SelectedCells(5).Value = "Agent" Then
            If cboAgents.Text = "" Then
                MsgBox("Please select Agent Name.", MsgBoxStyle.Critical, "Missing Information")
                CheckForRequiredEntries = False
                Exit Function
            End If
        ElseIf Me.dgGLSub.SelectedCells(5).Value = "Vendor" Then
            If cboVendor.Text = "" Then
                MsgBox("Please select Vendor/Supplier Name.", MsgBoxStyle.Critical, "Missing Information")
                CheckForRequiredEntries = False
                Exit Function
            End If
        ElseIf Me.dgGLSub.SelectedCells(5).Value = "Affiliates" Then
            If cboAffiliates.Text = "" Then
                MsgBox("Please select Affiliates Name.", MsgBoxStyle.Critical, "Missing Information")
                CheckForRequiredEntries = False
                Exit Function
            End If
        ElseIf Me.dgGLSub.SelectedCells(5).Value = "Banks" Then
            If cboBank.Text = "" Then
                MsgBox("Please select Bank Name.", MsgBoxStyle.Critical, "Missing Information")
                CheckForRequiredEntries = False
                Exit Function
            End If
        ElseIf Me.dgGLSub.SelectedCells(5).Value = "Employees" Then
            If cboEmployee.Text = "" Then
                MsgBox("Please select Employee Name.", MsgBoxStyle.Critical, "Missing Information")
                CheckForRequiredEntries = False
                Exit Function
            End If
        ElseIf Me.dgGLSub.SelectedCells(5).Value = "Local and Government Agency" Then
            If cboLGA.Text = "" Then
                MsgBox("Please select Local and Government Agency Name.", MsgBoxStyle.Critical, "Missing Information")
                CheckForRequiredEntries = False
                Exit Function
            End If

        End If

        If Me.dgGLSub.SelectedCells(3).Value = True Then
            If cboDept.Text = "" Then
                MsgBox("Please select Department Name.", MsgBoxStyle.Critical, "Missing Information")
                CheckForRequiredEntries = False
                Exit Function
            End If
        End If

        CheckForRequiredEntries = True

    End Function
End Class