<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogoutOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdLogoutUser = New System.Windows.Forms.Button()
        Me.cmdChangeCompany = New System.Windows.Forms.Button()
        Me.cmdExitSystem = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdLogoutUser
        '
        Me.cmdLogoutUser.Location = New System.Drawing.Point(12, 12)
        Me.cmdLogoutUser.Name = "cmdLogoutUser"
        Me.cmdLogoutUser.Size = New System.Drawing.Size(181, 25)
        Me.cmdLogoutUser.TabIndex = 0
        Me.cmdLogoutUser.Text = "Logout User"
        Me.cmdLogoutUser.UseVisualStyleBackColor = True
        '
        'cmdChangeCompany
        '
        Me.cmdChangeCompany.Location = New System.Drawing.Point(12, 43)
        Me.cmdChangeCompany.Name = "cmdChangeCompany"
        Me.cmdChangeCompany.Size = New System.Drawing.Size(181, 25)
        Me.cmdChangeCompany.TabIndex = 1
        Me.cmdChangeCompany.Text = "Change Company"
        Me.cmdChangeCompany.UseVisualStyleBackColor = True
        '
        'cmdExitSystem
        '
        Me.cmdExitSystem.Location = New System.Drawing.Point(12, 74)
        Me.cmdExitSystem.Name = "cmdExitSystem"
        Me.cmdExitSystem.Size = New System.Drawing.Size(181, 25)
        Me.cmdExitSystem.TabIndex = 2
        Me.cmdExitSystem.Text = "Exit System"
        Me.cmdExitSystem.UseVisualStyleBackColor = True
        '
        'frmLogoutOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(203, 113)
        Me.Controls.Add(Me.cmdExitSystem)
        Me.Controls.Add(Me.cmdChangeCompany)
        Me.Controls.Add(Me.cmdLogoutUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmLogoutOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Logout Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdLogoutUser As Button
    Friend WithEvents cmdChangeCompany As Button
    Friend WithEvents cmdExitSystem As Button
End Class
