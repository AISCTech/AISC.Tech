Public Class frmSelectADMRequestItem
    Public intIndex As Integer
    Private Sub frmSelectADMRequestItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBox(Me.cboCostCenter, "Select Dept_Name from tbl_dept where Dept_Name is not null", "Dept_Name")
        FillGridComboBox(Me.colUnit, "Select Unit from lib_uom where Unit is not null", "Unit")
    End Sub

    Private Sub ComputeTotals()
        Dim dblTotalValue As Double = 0, dblTotalQty As Double = 0

        For Each dtgRow As DataGridViewRow In Me.dtgDesc.Rows
            With dtgRow
                .Cells(3).Value = Format(CDbl(.Cells(3).Value), "n2")
                .Cells(4).Value = Format(CDbl(.Cells(1).Value) * CDbl(.Cells(3).Value), "n2")

                dblTotalQty += CDbl(.Cells(1).Value)
                dblTotalValue += CDbl(.Cells(4).Value)
            End With
        Next

        'Me.txtTotalQty.Text = Format(dblTotalQty, "n2")
        'Me.txtTotalValue.Text = Format(dblTotalValue, "n2")
        'Me.txtNoOfDesc.Text = Me.dtgDesc.Rows.Count
    End Sub

    Private Sub dtgDesc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDesc.CellContentClick

    End Sub

    Private Sub dtgDesc_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDesc.CellEndEdit
        ComputeTotals()
    End Sub

    Private Sub btEnter_Click(sender As Object, e As EventArgs) Handles btEnter.Click
        Dim i As Integer = 0
        Dim h As DataGridViewRow

        If Me.cboCostCenter.SelectedIndex = -1 Then
            MsgBox("Please select Cost Center first!", vbInformation, "System Message")
            Exit Sub
        End If

        For i = 0 To Me.dtgDesc.Rows.Count - 1
            h = Me.dtgDesc.Rows(i)

            If Len(h.Cells(0).Value) <> 0 Then
                frmRequest.dgDetails.Rows(intIndex).Cells(1).Value = h.Cells(0).Value
                frmRequest.dgDetails.Rows(intIndex).Cells(2).Value = h.Cells(1).Value
                frmRequest.dgDetails.Rows(intIndex).Cells(3).Value = h.Cells(2).Value
                frmRequest.dgDetails.Rows(intIndex).Cells(4).Value = h.Cells(3).Value
                frmRequest.dgDetails.Rows(intIndex).Cells(5).Value = h.Cells(4).Value
                frmRequest.dgDetails.Rows(intIndex).Cells(6).Value = Me.txtCostCenter.Text
                'frmRequest.dgDetails.Rows.Add("", h.Cells(0).Value, h.Cells(1).Value, h.Cells(2).Value, h.Cells(3).Value, h.Cells(4).Value)
            End If
        Next
        frmRequest.txtGrandTotal.Text = Format(frmRequest.SumAmount, "n2")
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboCostCenter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCostCenter.SelectedIndexChanged
        If Me.cboCostCenter.SelectedIndex = -1 Then Exit Sub

        Me.txtCostCenter.Text = GetStringValue("Select Dept_Code from tbl_dept where Dept_Name = '" & Me.cboCostCenter.Text & "'", "Dept_Code")
    End Sub

    Private Sub dtgDesc_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dtgDesc.EditingControlShowing
        Dim tb As TextBox
        If dtgDesc.CurrentCell.ColumnIndex = 1 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dtgDesc.CurrentCell.ColumnIndex = 3 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If dtgDesc.CurrentCell.ColumnIndex = 1 Then
            SetCharacter(MyOption.Numeric, e)
        End If

        If dtgDesc.CurrentCell.ColumnIndex = 3 Then
            SetCharacter(MyOption.Numeric, e)
        End If
    End Sub
End Class