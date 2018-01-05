Public Class frmLogIn

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Function ValidateUserAccess() As Boolean
        ValidateUserAccess = False

        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
            CurrentUser = New clsUserAccount

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_useraccount WHERE Username = @Username"
            cmdSQL.Parameters.AddWithValue("@Username", UsernameTextBox.Text)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            If reader.HasRows = False Then
                MsgBox("Username does not exist!", MsgBoxStyle.Exclamation, "System Mesage")
                reader.Close()
                UsernameTextBox.Focus()
                UsernameTextBox.SelectionStart = 0
                UsernameTextBox.SelectionLength = Len(UsernameTextBox.Text)
                Exit Function
            End If

            While reader.Read
                If reader.Item("User_Active") = False Then
                    MsgBox("User inactive!", MsgBoxStyle.Exclamation, "System Mesage")
                    reader.Close()
                    Exit Function
                End If

                If DecryptString(reader.Item("Password"), "1") <> PasswordTextBox.Text Then
                    MsgBox("Incorrect Password!", MsgBoxStyle.Exclamation, "System Mesage")
                    reader.Close()
                    PasswordTextBox.Focus()
                    PasswordTextBox.SelectionStart = 0
                    PasswordTextBox.SelectionLength = Len(UsernameTextBox.Text)
                    Exit Function
                End If

                With CurrentUser
                    ._User_ID = reader.Item("User_ID")
                    ._Username = reader.Item("Username")
                    ._Password = reader.Item("Password")
                    ._Last_Name = reader.Item("Last_Name")
                    ._First_Name = reader.Item("First_Name")
                    ._Middle_Name = reader.Item("Middle_Name")
                    ._Dept_Code = reader.Item("Dept_Code")
                    ._Dept_Name = reader.Item("Dept_Name")
                    ._Position_Code = reader.Item("Position_Code")
                    ._Position_Name = reader.Item("Position_Name")
                End With

                ValidateUserAccess = True
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If Len(UsernameTextBox.Text) = 0 Then
            MsgBox("Please enter username and password!", MsgBoxStyle.Information, "System Message")
            Exit Sub
        Else
            If Len(PasswordTextBox.Text) = 0 Then
                PasswordTextBox.Focus()
                Exit Sub
            End If
        End If

        If ValidateUserAccess() = True Then
            frmSelectCompany.ShowDialog()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = strSystemName & " v. " & strSystemVersion
    End Sub
End Class
