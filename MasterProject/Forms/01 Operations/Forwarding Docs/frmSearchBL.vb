Public Class frmSearchBL
    Public strCaller As String

    Private Sub frmSearchBL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim clsCombo As New clsPopulateComboBox(cboPreviewType, "SELECT ID, PreviewTypeName FROM lib_frwdg_docs_preview_type ORDER BY ID", "PreviewTypeName", "ID")
        clsCombo.PopComboBox()
    End Sub

    Private Sub cmdBooking_Click(sender As Object, e As EventArgs) Handles cmdBooking.Click
        If cboPreviewType.SelectedIndex = -1 Then
            MsgBox("Please select Preview Type.", MsgBoxStyle.Information, "System Message")
            Exit Sub
        End If

        Dim clsDB As New clsDBTrans
        Dim clsTempHBL As New clsFrwdgDocsHBL
        With frmExportFrwdgDocs
            clsTempHBL = clsDB.ForwardingDocsHBLSearchByBookingNo(txtBooking.Text, CurrentUser._Company_Code, cboPreviewType.SelectedValue)
            If clsTempHBL._ID > 0 Then
                .clsCurrentHBL = clsTempHBL
                .clsCurrentMBL = clsDB.ForwardingDocsMBLSearchByID(.clsCurrentHBL._MBL._ID)
                .LoadCurrentRecord()
                Me.Close()
            Else
                MsgBox("Booking no. does not have " & cboPreviewType.Text & " BL yet.", MsgBoxStyle.Information, "System Message")
            End If
        End With
    End Sub

    Private Sub txtBooking_TextChanged(sender As Object, e As EventArgs) Handles txtBooking.TextChanged

    End Sub

    Private Sub txtBooking_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBooking.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdBooking_Click(sender, e)
        End If
    End Sub

    Private Sub frmSearchBL_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub cmdMBL_Click(sender As Object, e As EventArgs) Handles cmdMBL.Click
        If cboPreviewType.SelectedIndex = -1 Then
            MsgBox("Please select Preview Type.", MsgBoxStyle.Information, "System Message")
            Exit Sub
        End If

        Dim clsDB As New clsDBTrans
        Dim clsTempMBL As clsFrwdgDocsMBL = clsDB.ForwardingDocsMBLSearchByMBLNo(txtMBL.Text, CurrentUser._Company_Code, cboPreviewType.SelectedValue)
        With frmExportFrwdgDocs
            If clsTempMBL._ID > 0 Then
                .clsCurrentMBL = clsTempMBL
                .clsCurrentHBL = New clsFrwdgDocsHBL
                .LoadCurrentRecord()
                Me.Close()
            Else
                MsgBox(cboPreviewType.Text & " MBL no. does not exist.", MsgBoxStyle.Information, "System Message")
            End If
        End With
    End Sub

    Private Sub txtMBL_TextChanged(sender As Object, e As EventArgs) Handles txtMBL.TextChanged

    End Sub

    Private Sub txtMBL_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMBL.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdMBL_Click(sender, e)
        End If
    End Sub

    Private Sub cmdHBL_Click(sender As Object, e As EventArgs) Handles cmdHBL.Click
        If cboPreviewType.SelectedIndex = -1 Then
            MsgBox("Please select Preview Type.", MsgBoxStyle.Information, "System Message")
            Exit Sub
        End If

        Dim clsDB As New clsDBTrans
        Dim clsTempHBL As clsFrwdgDocsHBL = clsDB.ForwardingDocsHBLSearchByHBLNo(txtHBL.Text, CurrentUser._Company_Code, cboPreviewType.SelectedValue)
        With frmExportFrwdgDocs
            If clsTempHBL._ID > 0 Then
                .clsCurrentHBL = clsTempHBL
                .clsCurrentMBL = clsDB.ForwardingDocsMBLSearchByID(.clsCurrentHBL._MBL._ID)
                .LoadCurrentRecord()
                Me.Close()
            Else
                MsgBox(cboPreviewType.Text & " HBL no. does not exist.", MsgBoxStyle.Information, "System Message")
            End If
        End With
    End Sub

    Private Sub txtHBL_TextChanged(sender As Object, e As EventArgs) Handles txtHBL.TextChanged

    End Sub

    Private Sub txtHBL_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHBL.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdHBL_Click(sender, e)
        End If
    End Sub
End Class