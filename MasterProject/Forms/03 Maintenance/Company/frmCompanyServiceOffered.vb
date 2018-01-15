Imports MasterProject

Public Class frmCompanyServiceOffered
    Implements ICommonFunction

    Public clsCurrentRecord As New clsCompanyServiceOffered
    Dim dvDataView As DataView

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord

    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        ChangeEnabledButtons(True, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If MsgBox("Create new record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.Yes Then
            clsCurrentRecord = New clsCompanyServiceOffered
            ClearUserInput()
            ChangeEnabledButtons(True, False, True, True, False, False, False, False, False, True)
        End If
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord

    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord

    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        RefreshLists()

        If clsCurrentRecord._ID > 0 Then
            Dim clsDB As New clsDBTrans
            clsCurrentRecord = clsDB.SearchCompanyServiceOffered(clsCurrentRecord._ID)
            PopulateRecord(clsCurrentRecord)
        Else
            ChangeEnabledButtons(True, False, False, True, False, False, False, False, False, False)
            ClearUserInput()
        End If
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If cboCompany.SelectedIndex = -1 Then
            MsgBox("Please select company.", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If cboServices.SelectedIndex = -1 Then
            MsgBox("Please select service offered.", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        If MsgBox("Save record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.Yes Then
            With clsCurrentRecord
                ._Company._Company_Code = cboCompany.SelectedValue
                ._ServiceOffered._PK = cboServices.SelectedValue
                ._PrepBy._User_ID = CurrentUser._User_ID
                ._ModBy._User_ID = CurrentUser._User_ID
            End With

            Dim clsDB As New clsDBTrans
            clsCurrentRecord = clsDB.SaveCompanyServiceOffered(clsCurrentRecord)
            clsCurrentRecord = clsDB.SearchCompanyServiceOffered(clsCurrentRecord._ID)
            PopulateRecord(clsCurrentRecord)
            PopGrid()
            MsgBox("Record Saved.", MsgBoxStyle.Information, "System Message")
        End If
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord

    End Sub

    Private Sub FilterList()
        Dim strFilter As String = "Company_Code = ''"

        For Each li As ListViewItem In lstCompany.CheckedItems
            strFilter = strFilter & " OR Company_Code = '" & li.SubItems(1).Text & "'"
        Next

        dvDataView.RowFilter = strFilter
    End Sub

    Private Sub PopGrid()
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT `ID`, " &
                                    "`Company_Code`, " &
                                    "`Company_FullName` AS `Company`, " &
                                    "`Param_Desc` AS `Services` " &
                                 "FROM " &
                                    "`v_companyserviceoffered`"

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView
            dtgCompanyServices.DataSource = dvDataView

            dtgCompanyServices.Columns(0).Frozen = True
            dtgCompanyServices.Columns(1).Frozen = True
            dtgCompanyServices.Columns(2).Frozen = True

            dtgCompanyServices.Columns(0).Visible = False
            dtgCompanyServices.Columns(1).Visible = False
            dtgCompanyServices.Columns(2).Width = 450
            dtgCompanyServices.Columns(3).Width = 250
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PopulateRecord(ByVal clsTemp As clsCompanyServiceOffered)
        ClearUserInput()
        With clsTemp
            cboCompany.SelectedValue = ._Company._Company_Code
            cboServices.SelectedValue = ._ServiceOffered._PK
            txtPrepBy.Text = UpperFirstLetter(._PrepBy._First_Name & " " & ._PrepBy._Last_Name)
            txtPrepDate.Text = ._PrepDate
            txtModBy.Text = UpperFirstLetter(._ModBy._First_Name & " " & ._ModBy._Last_Name)
            txtModDate.Text = ._ModDate
        End With

        ChangeEnabledButtons(True, True, False, True, False, False, False, True, False, False)
    End Sub

    Private Sub ClearUserInput()
        cboCompany.SelectedIndex = -1
        cboServices.SelectedIndex = -1
        txtPrepBy.Text = ""
        txtPrepDate.Text = ""
        txtModBy.Text = ""
        txtModDate.Text = ""
    End Sub

    Private Sub RefreshLists()
        PopGrid()

        Dim clsCombo As New clsPopulateComboBox(cboCompany, "SELECT `Company_Code`, `Company_FullName` FROM tbl_company WHERE `Active` = 1", "Company_FullName", "Company_Code")
        clsCombo.PopComboBox()
        clsCombo = New clsPopulateComboBox(cboServices, "SELECT PK, Param_Desc FROM lib_params WHERE Param_Type = 10", "Param_Desc", "PK")
        clsCombo.PopComboBox()
        Dim clsList As New clsPopListView(lstCompany, "SELECT `Company_FullName`, `Company_Code` FROM tbl_company WHERE `Active` = 1")
        clsList.PopulateListview("Company_FullName")

        For Each li As ListViewItem In lstCompany.Items
            li.Checked = True
        Next
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

        cboCompany.Enabled = blUserInput
        cboServices.Enabled = blUserInput
        Panel2.Enabled = Not blUserInput
        dtgCompanyServices.Enabled = Not blUserInput
    End Sub

    Private Sub frmCompanyServiceOffered_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeEnabledButtons(True, False, False, True, False, False, False, False, False, False)
        RefreshLists()
    End Sub

    Private Sub frmCompanyServiceOffered_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmCompanyServiceOffered_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub dtgCompanyServices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCompanyServices.CellContentClick

    End Sub

    Private Sub dtgCompanyServices_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCompanyServices.CellClick
        If e.RowIndex >= 0 Then
            Dim clsDB As New clsDBTrans
            clsCurrentRecord = clsDB.SearchCompanyServiceOffered(dtgCompanyServices.Rows(e.RowIndex).Cells(0).Value)
            PopulateRecord(clsCurrentRecord)
        End If
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged

    End Sub

    Private Sub lstCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCompany.SelectedIndexChanged

    End Sub

    Private Sub chkSelectAll_Click(sender As Object, e As EventArgs) Handles chkSelectAll.Click
        Dim blTemp As Boolean = chkSelectAll.Checked
        For Each li As ListViewItem In lstCompany.Items
            li.Checked = blTemp
        Next
    End Sub

    Private Sub lstCompany_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lstCompany.ItemChecked
        If lstCompany.Items.Count = lstCompany.CheckedItems.Count Then
            chkSelectAll.Checked = True
        Else
            chkSelectAll.Checked = False
        End If

        FilterList()
    End Sub
End Class