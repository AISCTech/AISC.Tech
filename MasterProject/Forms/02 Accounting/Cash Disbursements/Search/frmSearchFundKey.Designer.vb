<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchFundKey
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
        Me.dgFundKey = New System.Windows.Forms.DataGridView()
        Me.btClose = New System.Windows.Forms.Button()
        CType(Me.dgFundKey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgFundKey
        '
        Me.dgFundKey.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgFundKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFundKey.Location = New System.Drawing.Point(12, 12)
        Me.dgFundKey.Name = "dgFundKey"
        Me.dgFundKey.ReadOnly = True
        Me.dgFundKey.Size = New System.Drawing.Size(496, 312)
        Me.dgFundKey.TabIndex = 451
        '
        'btClose
        '
        Me.btClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClose.ForeColor = System.Drawing.Color.DarkBlue
        Me.btClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btClose.Location = New System.Drawing.Point(428, 330)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(80, 23)
        Me.btClose.TabIndex = 452
        Me.btClose.Text = "Close"
        Me.btClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btClose.UseVisualStyleBackColor = True
        '
        'frmSearchFundKey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 357)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.dgFundKey)
        Me.Name = "frmSearchFundKey"
        Me.Text = "frmSearchFundKey"
        CType(Me.dgFundKey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btClose As Button
    Friend WithEvents dgFundKey As DataGridView
End Class
