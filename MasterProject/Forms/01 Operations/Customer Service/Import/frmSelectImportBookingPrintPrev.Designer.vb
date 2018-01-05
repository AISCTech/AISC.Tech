<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectImportBookingPrintPrev
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
        Me.cmdBAC = New System.Windows.Forms.Button()
        Me.cmdBADV = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdBAC
        '
        Me.cmdBAC.Location = New System.Drawing.Point(12, 12)
        Me.cmdBAC.Name = "cmdBAC"
        Me.cmdBAC.Size = New System.Drawing.Size(311, 23)
        Me.cmdBAC.TabIndex = 0
        Me.cmdBAC.Text = "Booking Acknowledgement Confirmation"
        Me.cmdBAC.UseVisualStyleBackColor = True
        '
        'cmdBADV
        '
        Me.cmdBADV.Location = New System.Drawing.Point(12, 41)
        Me.cmdBADV.Name = "cmdBADV"
        Me.cmdBADV.Size = New System.Drawing.Size(311, 23)
        Me.cmdBADV.TabIndex = 1
        Me.cmdBADV.Text = "Booking Advisory"
        Me.cmdBADV.UseVisualStyleBackColor = True
        '
        'frmSelectImportBookingPrintPrev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 75)
        Me.Controls.Add(Me.cmdBADV)
        Me.Controls.Add(Me.cmdBAC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSelectImportBookingPrintPrev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Preview"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdBAC As Button
    Friend WithEvents cmdBADV As Button
End Class
