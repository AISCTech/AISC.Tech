Imports MasterProject

Public Class frmOprReq

    Private Sub ResetForm()
        Dim clsCombo As New clsPopulateComboBox(cboType, "Select ParamName, ParamCode from lib_requestparams where ParamType = 'TYP'", "ParamName", "ParamCode")
        clsCombo.PopComboBox()

        clsCombo = New clsPopulateComboBox(cboChargeTo, "Select ParamName, ParamCode from lib_requestparams where ParamType = 'CRG'", "ParamName", "ParamCode")
        clsCombo.PopComboBox()

        clsCombo = New clsPopulateComboBox(cboPlateNo, "Select ID, PlateNo from lib_vehicles where Active = 1", "PlateNo", "ID")
        clsCombo.PopComboBox()

        If Len(txtRequestNo.Text) = 0 Then
            ClearUserInput()
            ChangeEnabledButtons(True, False, False, True, False, True, False, False, False, False)
        Else

        End If
    End Sub

    Private Sub ClearUserInput()
        txtRequestNo.Text = ""
        txtPayeeCode.Text = ""
        txtPayeeName.Text = ""
        txtRemarks.Text = ""
        txtDateNeeded.Text = ""
        txtType.Text = ""
        cboType.SelectedIndex = -1
        cboPlateNo.SelectedIndex = -1
        txtChargeTo.Text = ""
        cboChargeTo.SelectedIndex = -1
        txtChargeToName.Text = ""
        txtInvoice.Text = ""
        dtgDetails.Rows.Clear()
        dtgEditReason.Rows.Clear()
        dtgAPV.Rows.Clear()
        dtgCV.Rows.Clear()
        txtEncodedBy.Text = ""
        txtDateEncoded.Text = ""
        txtModifiedBy.Text = ""
        txtDateModified.Text = ""
        txtStatus.Text = ""
        txtGrandTotal.Text = ""
        txtAmtInWords.Text = ""
    End Sub

    Private Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
                                     ByVal blPrintPreview As Boolean, ByVal blSearch As Boolean, ByVal blPost As Boolean,
                                     ByVal blCancel As Boolean, ByVal blReOpen As Boolean, ByVal blUserInput As Boolean)
        NewToolStripButton.Enabled = blNew
        EditToolStripButton.Enabled = blEdit
        SaveToolStripButton.Enabled = blSave
        ResetToolStripButton.Enabled = blReset
        PrintPreviewToolStripButton.Enabled = blPrintPreview
        SearchToolStripButton.Enabled = blSearch
        PostToolStripButton.Enabled = blPost
        CancelToolStripButton.Enabled = blCancel
        ReOpenToolStripButton.Enabled = blReOpen

        optCheck.Enabled = blUserInput
        optMC.Enabled = blUserInput
        optPettyCash.Enabled = blUserInput
        btPayee.Enabled = blUserInput
        txtRemarks.ReadOnly = Not blUserInput
        dtReceipt.Enabled = blUserInput
        dtReceipt.Visible = blUserInput
        cboType.Enabled = blUserInput
        cboPlateNo.Enabled = blUserInput
        cboChargeTo.Enabled = blUserInput
        txtChargeToName.ReadOnly = Not blUserInput
        txtInvoice.ReadOnly = Not blUserInput
        btAddDetails.Enabled = blUserInput
        btRemoveDetails.Enabled = blUserInput
    End Sub

    Private Sub frmOprReq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetForm()
    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        If MsgBox("Create new record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
            ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
        End If
    End Sub

    Private Sub btPayee_Click(sender As Object, e As EventArgs) Handles btPayee.Click
        frmManageVendor.Tag = "OPRReq"
        frmManageVendor.ShowDialog()
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged

    End Sub

    Private Sub cboType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboType.SelectedValueChanged
        Dim objSelectedValue As IConvertible = TryCast(cboType.SelectedValue, IConvertible)
        txtType.Text = objSelectedValue
    End Sub

    Private Sub cboChargeTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChargeTo.SelectedIndexChanged

    End Sub

    Private Sub cboChargeTo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboChargeTo.SelectedValueChanged
        Dim objSelectedValue As IConvertible = TryCast(cboChargeTo.SelectedValue, IConvertible)
        txtChargeTo.Text = objSelectedValue
    End Sub

    Private Sub dtReceipt_ValueChanged(sender As Object, e As EventArgs) Handles dtReceipt.ValueChanged
        Me.txtDateNeeded.Text = Format(Me.dtReceipt.Value, "yyyy-MM-dd")
    End Sub

    Private Sub btAddDetails_Click(sender As Object, e As EventArgs) Handles btAddDetails.Click
        With frmAddOprParticulars
            .blBrkg = True
            .ShowDialog()
        End With
    End Sub
End Class