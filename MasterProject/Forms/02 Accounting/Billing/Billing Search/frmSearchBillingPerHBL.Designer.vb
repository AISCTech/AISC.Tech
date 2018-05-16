<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchBillingPerHBL
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
        Me.colRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgRefNo = New System.Windows.Forms.DataGridView()
        CType(Me.dtgRefNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colRefNo
        '
        Me.colRefNo.HeaderText = "Billing Reference No."
        Me.colRefNo.Name = "colRefNo"
        Me.colRefNo.ReadOnly = True
        Me.colRefNo.Width = 200
        '
        'dtgRefNo
        '
        Me.dtgRefNo.AllowUserToAddRows = False
        Me.dtgRefNo.AllowUserToDeleteRows = False
        Me.dtgRefNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgRefNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRefNo})
        Me.dtgRefNo.Location = New System.Drawing.Point(12, 12)
        Me.dtgRefNo.Name = "dtgRefNo"
        Me.dtgRefNo.ReadOnly = True
        Me.dtgRefNo.Size = New System.Drawing.Size(268, 242)
        Me.dtgRefNo.TabIndex = 1
        '
        'frmSearchBillingPerHBL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 265)
        Me.Controls.Add(Me.dtgRefNo)
        Me.Name = "frmSearchBillingPerHBL"
        Me.Text = "frmSearchBillingPerHBL"
        CType(Me.dtgRefNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents colRefNo As DataGridViewTextBoxColumn
    Friend WithEvents dtgRefNo As DataGridView
End Class
