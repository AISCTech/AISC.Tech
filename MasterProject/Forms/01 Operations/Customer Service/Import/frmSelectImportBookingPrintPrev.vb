Public Class frmSelectImportBookingPrintPrev
    Private Sub cmdBAC_Click(sender As Object, e As EventArgs) Handles cmdBAC.Click
        With frmSendEmail
            .strAttnTo = InputBox("Attention To:", "Booking Acknowledgement Confirmation")
            .Tag = "ImpBAC"
            .ShowDialog()
        End With
        Me.Close()
    End Sub
End Class