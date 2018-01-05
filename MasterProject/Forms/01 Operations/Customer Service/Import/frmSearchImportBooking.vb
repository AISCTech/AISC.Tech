Public Class frmSearchImportBooking

    Private Sub frmSearchImportBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBookingNo.Text = ""
    End Sub

    Private Sub txtBookingNoL_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBookingNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim clsDBTemp As New clsDBTrans
            Dim clsImpTemp As clsImportBookingHeader = clsDBTemp.SearchImportBookingRecord(txtBookingNo.Text, CurrentUser._Company_Code)

            If Not IsNothing(clsImpTemp) Then
                frmImportBookingMenu.PopulateBooking(clsImpTemp)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtBookingNo_TextChanged(sender As Object, e As EventArgs) Handles txtBookingNo.TextChanged

    End Sub
End Class