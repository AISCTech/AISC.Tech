<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSearchBL
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchBL))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBooking = New System.Windows.Forms.TextBox()
        Me.cmdBooking = New System.Windows.Forms.Button()
        Me.cmdMBL = New System.Windows.Forms.Button()
        Me.txtMBL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdHBL = New System.Windows.Forms.Button()
        Me.txtHBL = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPreviewType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Booking No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(110, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = ":"
        '
        'txtBooking
        '
        Me.txtBooking.Location = New System.Drawing.Point(126, 39)
        Me.txtBooking.Name = "txtBooking"
        Me.txtBooking.Size = New System.Drawing.Size(222, 20)
        Me.txtBooking.TabIndex = 5
        '
        'cmdBooking
        '
        Me.cmdBooking.Image = CType(resources.GetObject("cmdBooking.Image"), System.Drawing.Image)
        Me.cmdBooking.Location = New System.Drawing.Point(354, 36)
        Me.cmdBooking.Name = "cmdBooking"
        Me.cmdBooking.Size = New System.Drawing.Size(27, 24)
        Me.cmdBooking.TabIndex = 12
        Me.cmdBooking.UseVisualStyleBackColor = True
        '
        'cmdMBL
        '
        Me.cmdMBL.Image = CType(resources.GetObject("cmdMBL.Image"), System.Drawing.Image)
        Me.cmdMBL.Location = New System.Drawing.Point(354, 66)
        Me.cmdMBL.Name = "cmdMBL"
        Me.cmdMBL.Size = New System.Drawing.Size(27, 24)
        Me.cmdMBL.TabIndex = 13
        Me.cmdMBL.UseVisualStyleBackColor = True
        '
        'txtMBL
        '
        Me.txtMBL.Location = New System.Drawing.Point(126, 69)
        Me.txtMBL.Name = "txtMBL"
        Me.txtMBL.Size = New System.Drawing.Size(222, 20)
        Me.txtMBL.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(110, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Master BL"
        '
        'cmdHBL
        '
        Me.cmdHBL.Image = CType(resources.GetObject("cmdHBL.Image"), System.Drawing.Image)
        Me.cmdHBL.Location = New System.Drawing.Point(354, 96)
        Me.cmdHBL.Name = "cmdHBL"
        Me.cmdHBL.Size = New System.Drawing.Size(27, 24)
        Me.cmdHBL.TabIndex = 14
        Me.cmdHBL.UseVisualStyleBackColor = True
        '
        'txtHBL
        '
        Me.txtHBL.Location = New System.Drawing.Point(126, 99)
        Me.txtHBL.Name = "txtHBL"
        Me.txtHBL.Size = New System.Drawing.Size(222, 20)
        Me.txtHBL.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(110, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "House BL"
        '
        'cboPreviewType
        '
        Me.cboPreviewType.FormattingEnabled = True
        Me.cboPreviewType.Location = New System.Drawing.Point(126, 12)
        Me.cboPreviewType.Name = "cboPreviewType"
        Me.cboPreviewType.Size = New System.Drawing.Size(255, 21)
        Me.cboPreviewType.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(110, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Preview Type"
        '
        'frmSearchBL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 134)
        Me.Controls.Add(Me.cboPreviewType)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdHBL)
        Me.Controls.Add(Me.txtHBL)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdMBL)
        Me.Controls.Add(Me.txtMBL)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdBooking)
        Me.Controls.Add(Me.txtBooking)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSearchBL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search BL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBooking As TextBox
    Friend WithEvents cmdBooking As Button
    Friend WithEvents cmdMBL As Button
    Friend WithEvents txtMBL As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmdHBL As Button
    Friend WithEvents txtHBL As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cboPreviewType As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
