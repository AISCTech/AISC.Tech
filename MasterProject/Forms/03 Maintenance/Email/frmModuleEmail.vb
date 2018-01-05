Public Class frmModuleEmail
    Implements ICommonFunction

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If MsgBox("Create new record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.Yes Then
            ClearUserInput()
            ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
            cboCompany.Focus()
        End If
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord

    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord

    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        Dim clsComboBox As New clsPopulateComboBox(cboCompany, "SELECT Company_Code, Company_FullName FROM tbl_company WHERE Active = TRUE", "Company_FullName", "Company_Code")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboModule, "SELECT ID, Module_Name FROM lib_emailreportmodule", "Module_Name", "ID")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboEmailAddress, "SELECT ID, EmailAddress FROM lib_email", "EmailAddress", "ID")
        clsComboBox.PopComboBox()

        'If clsEmail._ID < 1 Then
        'ChangeEnabledButtons(True, False, False, True, False, True, False, False, False, False)
        'LoadModuleEmailList()
        'Else
        ChangeEnabledButtons(True, True, True, True, False, True, False, False, False, False)
        'End If
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord

    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord

    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord

    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord

    End Sub

    Private Sub ClearUserInput()
        'clsEmail = New clsModuleEmail
        cboCompany.SelectedIndex = -1
        cboModule.SelectedIndex = -1
    End Sub



    Private Sub ChangeGridFontColor(ByVal intRow As Integer)
        For Each colTemp As DataGridViewColumn In dtgModuleEmail.Columns
            dtgModuleEmail.Rows(intRow).Cells(colTemp.Name).Style.ForeColor = Color.Red
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
    End Sub

    Private Sub frmModuleEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetRecord()
    End Sub

    Private Sub frmModuleEmail_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmModuleEmail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub
End Class