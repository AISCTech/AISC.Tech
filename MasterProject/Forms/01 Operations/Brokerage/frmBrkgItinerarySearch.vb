Public Class frmBrkgItinerarySearch
    Private Sub txtRefNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRefNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            With frmBrkgItinerary
                Dim clsDB As New clsDBTrans
                If IsNumeric(txtRefNo.Text) Then
                    .clsRecord = clsDB.BrokerageItinerarySearch(txtRefNo.Text)
                    If .clsRecord._ID > 0 Then
                        .LoadRecord(.clsRecord)
                        Me.Close()
                        Me.Dispose()
                    Else
                        MsgBox("Record not found.", MsgBoxStyle.Information, "System Message")
                    End If
                Else
                    MsgBox("Please enter a numeric value.", MsgBoxStyle.Information, "System Message")
                End If
            End With
        End If
    End Sub

    Private Sub txtRefNo_TextChanged(sender As Object, e As EventArgs) Handles txtRefNo.TextChanged

    End Sub
End Class