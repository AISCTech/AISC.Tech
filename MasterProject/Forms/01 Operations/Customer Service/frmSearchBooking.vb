Public Class frmSearchBooking
    Public strCaller As String

    Private Sub frmSearchBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBookingNo.Text = ""
    End Sub

    Private Sub txtBookingNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBookingNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim clsDBTemp As New clsDBTrans

            Select Case strCaller
                Case "Import"
                    Dim clsImpTemp As clsImportBookingHeader = clsDBTemp.CustomerServiceImportSearch(txtBookingNo.Text, CurrentUser._Company_Code)

                    If Not IsNothing(clsImpTemp) Then
                        frmImportBookingMenu.PopulateBooking(clsImpTemp)
                        Me.Close()
                    End If
                Case "Export"
                    Dim clsExpTemp As clsExportBookingHeader = clsDBTemp.CustomerServiceExportBookingSearch(txtBookingNo.Text, CurrentUser._Company_Code)

                    With frmExportBookingMenu
                        .clsExportRecord = clsExpTemp
                    End With
                    Me.Close()
                Case "Domestic"

            End Select
        End If
    End Sub

    Private Sub txtBookingNo_TextChanged(sender As Object, e As EventArgs) Handles txtBookingNo.TextChanged

    End Sub
End Class