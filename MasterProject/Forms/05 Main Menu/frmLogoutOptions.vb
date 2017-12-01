Public Class frmLogoutOptions
    Private Sub cmdLogoutUser_Click(sender As Object, e As EventArgs) Handles cmdLogoutUser.Click
        CurrentUser = New clsUserAccount
        frmLogIn.Show()
        mdiMain.Close()
        Me.Close()
    End Sub

    Private Sub cmdChangeCompany_Click(sender As Object, e As EventArgs) Handles cmdChangeCompany.Click
        frmSelectCompany.Show()
        mdiMain.Close()
        Me.Close()
    End Sub

    Private Sub cmdExitSystem_Click(sender As Object, e As EventArgs) Handles cmdExitSystem.Click
        Application.Exit()
    End Sub
End Class