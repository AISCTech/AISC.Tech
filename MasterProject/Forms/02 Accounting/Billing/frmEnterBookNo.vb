Public Class frmEnterBookNo
    Private Sub frmEnterBookNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtBookNo.SetWaterMark("Enter Booking Number here.")
    End Sub

    Private Sub btEnter_Click(sender As Object, e As EventArgs) Handles btEnter.Click
        If Len(Me.txtBookNo.Text) = 0 Then
            MsgBox("Please enter booking number!", vbInformation, "System Message")
            Exit Sub
        End If

        Select Case Me.Tag
            Case "IMP SOA"
                'If frmSOA.SearchBooking(Me.txtBookNo.Text) = True Then
                '    frmSOA.EnableButtons(False, False, True, True, False, False, False, False, False)
                '    frmSOA.ClearEntries(True)
                '    frmSOA.LockControls(False)
                '    Me.Dispose()
                '    Me.Close()
                'Else
                '    Exit Sub
                'End If
            Case "IMP INV"
                If frmInvoice.SearchBooking(Me.txtBookNo.Text) = True Then
                    frmInvoice.ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, False)
                    frmInvoice.EnableButtons2(True, True)
                    frmInvoice.ClearEntries(True)
                    'frmInvoice.LockControls(False)
                    Me.Dispose()
                    Me.Close()
                Else
                    Exit Sub
                End If
        End Select
    End Sub

    Private Sub txtBookNo_TextChanged(sender As Object, e As EventArgs) Handles txtBookNo.TextChanged

    End Sub

    Private Sub txtBookNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBookNo.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            If Len(Me.txtBookNo.Text) = 0 Then
                MsgBox("Please enter booking number!", vbInformation, "System Message")
                Exit Sub
            End If

            Select Case Me.Tag
                Case "IMP SOA"
                    'If frmSOA.SearchBooking(Me.txtBookNo.Text) = True Then
                    '    frmSOA.EnableButtons(False, False, True, True, False, False, False, False, False)
                    '    frmSOA.ClearEntries(True)
                    '    frmSOA.LockControls(False)
                    '    Me.Dispose()
                    '    Me.Close()
                    'Else
                    '    Exit Sub
                    'End If
                Case "IMP INV"
                    If frmInvoice.SearchBooking(Me.txtBookNo.Text) = True Then
                        frmInvoice.ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, False)
                        frmInvoice.EnableButtons2(True, True)
                        frmInvoice.ClearEntries(True)
                        Me.Dispose()
                        Me.Close()
                    Else
                        Exit Sub
                    End If
            End Select
        End If
    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class