<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnterBookNo
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
        Me.btCancel = New System.Windows.Forms.Button()
        Me.btEnter = New System.Windows.Forms.Button()
        Me.txtBookNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btCancel
        '
        Me.btCancel.Location = New System.Drawing.Point(244, 51)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 23)
        Me.btCancel.TabIndex = 7
        Me.btCancel.Text = "Cancel"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'btEnter
        '
        Me.btEnter.Location = New System.Drawing.Point(12, 51)
        Me.btEnter.Name = "btEnter"
        Me.btEnter.Size = New System.Drawing.Size(75, 23)
        Me.btEnter.TabIndex = 6
        Me.btEnter.Text = "Enter"
        Me.btEnter.UseVisualStyleBackColor = True
        '
        'txtBookNo
        '
        Me.txtBookNo.Location = New System.Drawing.Point(12, 25)
        Me.txtBookNo.Name = "txtBookNo"
        Me.txtBookNo.Size = New System.Drawing.Size(307, 20)
        Me.txtBookNo.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Please Enter Booking Number"
        '
        'frmEnterBookNo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 92)
        Me.ControlBox = False
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btEnter)
        Me.Controls.Add(Me.txtBookNo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEnterBookNo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enter Booking No."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btCancel As Button
    Friend WithEvents btEnter As Button
    Friend WithEvents txtBookNo As TextBox
    Friend WithEvents Label1 As Label
End Class
