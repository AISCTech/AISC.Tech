Public Class frmIncludeToAR
    Private Sub frmIncludeToAR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtCWTPercent.Text = 2
        Me.txtPayment.Text = 0
        Me.txtCWT.Text = 0
        Me.txtOthChrg.Text = 0
    End Sub

    Private Sub ComputeTotal()
        If IsNumeric(Me.txtPayment.Text) And IsNumeric(Me.txtCWT.Text) And IsNumeric(Me.txtOthChrg.Text) Then
            Me.txtTotal.Text = Format(CDbl(txtPayment.Text) + CDbl(Me.txtCWT.Text) + CDbl(Me.txtOthChrg.Text), "n2")
            Me.txtBalance.Text = Format(CDbl(Me.txtAmtBill.Text) - CDbl(Me.txtTotal.Text), "n2")
        Else
            Me.txtTotal.Text = "0.00"
            Me.txtBalance.Text = Format(CDbl(Me.txtAmtBill.Text) - CDbl(Me.txtTotal.Text), "n2")
        End If
    End Sub

    Private Function CheckEntries() As Boolean
        If Not IsNumeric(Me.txtPayment.Text) Then
            CheckEntries = False
            MsgBox("Payment should be a numeric value!", MsgBoxStyle.Exclamation, "System Mesaage")
            Exit Function
        End If

        If Not IsNumeric(Me.txtCWT.Text) Then
            CheckEntries = False
            MsgBox("CWT should be a numeric value!", MsgBoxStyle.Exclamation, "System Mesaage")
            Exit Function
        End If

        If Not IsNumeric(Me.txtCWTPercent.Text) Then
            CheckEntries = False
            MsgBox("CWT Percent should be a numeric value!", MsgBoxStyle.Exclamation, "System Mesaage")
            Exit Function
        End If

        If Not IsNumeric(Me.txtOthChrg.Text) Then
            CheckEntries = False
            MsgBox("Other Charge/s should be a numeric value!", MsgBoxStyle.Exclamation, "System Mesaage")
            Exit Function
        End If

        CheckEntries = True
    End Function

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If CheckEntries() = True Then
            frmAcknowledgementReceipt.dtgORInv.Rows.Add(Me.txtBillNo.Text, Me.txtInvNo.Text, Format(CDbl(Me.txtAmtBill.Text), "n2"), Format(CDbl(Me.txtCWT.Text), "n2"), Format(CDbl(Me.txtOthChrg.Text), "n2"), Format(CDbl(Me.txtPayment.Text), "n2"), Format(CDbl(Me.txtBalance.Text), "n2"))

            If frmAcknowledgementReceipt.dtgBilling.Rows.Count > 0 Then
                If frmAcknowledgementReceipt.dtgBilling.CurrentRow.Index >= 0 Then
                    If Not frmAcknowledgementReceipt.dtgBilling.CurrentRow.IsNewRow Then
                        frmAcknowledgementReceipt.dtgBilling.Rows.Remove(frmAcknowledgementReceipt.dtgBilling.CurrentRow)
                    End If
                End If
            End If

            frmAcknowledgementReceipt.ComputeTotals()
            Me.Close()
        End If
    End Sub

    Private Sub txtPayment_TextChanged(sender As Object, e As EventArgs) Handles txtPayment.TextChanged
        If IsNumeric(Me.txtPayment.Text) Then
            Me.txtPayment.ForeColor = Color.Black
        Else
            Me.txtPayment.ForeColor = Color.Red
        End If

        ComputeTotal()
    End Sub

    Private Sub txtCWT_TextChanged(sender As Object, e As EventArgs) Handles txtCWT.TextChanged
        If IsNumeric(Me.txtCWT.Text) Then
            Me.txtCWT.ForeColor = Color.Black
        Else
            Me.txtCWT.ForeColor = Color.Red
        End If

        ComputeTotal()
    End Sub

    Private Sub txtCWTPercent_TextChanged(sender As Object, e As EventArgs) Handles txtCWTPercent.TextChanged
        If IsNumeric(Me.txtCWTPercent.Text) Then
            Me.txtCWTPercent.ForeColor = Color.Black
        Else
            Me.txtCWTPercent.ForeColor = Color.Red
        End If
    End Sub

    Private Sub txtOthChrg_TextChanged(sender As Object, e As EventArgs) Handles txtOthChrg.TextChanged
        If IsNumeric(Me.txtOthChrg.Text) Then
            Me.txtOthChrg.ForeColor = Color.Black
        Else
            Me.txtOthChrg.ForeColor = Color.Red
        End If

        ComputeTotal()
    End Sub

    Private Sub cmdCompute_Click(sender As Object, e As EventArgs) Handles cmdCompute.Click
        If IsNumeric(Me.txtCWTPercent.Text) Then
            Me.txtCWT.Text = Format(CDbl(Me.txtAmtBill.Text) * (CDbl(Me.txtCWTPercent.Text) / 100), "n2")
            ComputeTotal()
        End If
    End Sub

    Private Sub cmdFull_Click(sender As Object, e As EventArgs) Handles cmdFull.Click
        If Not IsNumeric(Me.txtCWT.Text) Then
            Me.txtCWT.Text = "0.00"
        End If

        If Not IsNumeric(Me.txtOthChrg.Text) Then
            Me.txtOthChrg.Text = "0.00"
        End If

        Me.txtPayment.Text = Format(CDbl(Me.txtAmtBill.Text) - (CDbl(Me.txtCWT.Text) + CDbl(txtOthChrg.Text)), "n2")

    End Sub
End Class