<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectADMRequestItem
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btEnter = New System.Windows.Forms.Button()
        Me.dtgDesc = New System.Windows.Forms.DataGridView()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnit = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboCostCenter = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCostCenter = New System.Windows.Forms.TextBox()
        CType(Me.dtgDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btEnter
        '
        Me.btEnter.Location = New System.Drawing.Point(492, 88)
        Me.btEnter.Name = "btEnter"
        Me.btEnter.Size = New System.Drawing.Size(94, 37)
        Me.btEnter.TabIndex = 584
        Me.btEnter.Text = "Enter"
        Me.btEnter.UseVisualStyleBackColor = True
        '
        'dtgDesc
        '
        Me.dtgDesc.AllowUserToAddRows = False
        Me.dtgDesc.AllowUserToDeleteRows = False
        Me.dtgDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDesc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDesc, Me.colQty, Me.colUnit, Me.colUnitCost, Me.colValue, Me.Column1})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDesc.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgDesc.Location = New System.Drawing.Point(12, 12)
        Me.dtgDesc.Name = "dtgDesc"
        Me.dtgDesc.Size = New System.Drawing.Size(574, 70)
        Me.dtgDesc.TabIndex = 583
        '
        'colDesc
        '
        Me.colDesc.HeaderText = "Description"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.Width = 150
        '
        'colQty
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.colQty.DefaultCellStyle = DataGridViewCellStyle1
        Me.colQty.HeaderText = "Qty."
        Me.colQty.Name = "colQty"
        Me.colQty.Width = 80
        '
        'colUnit
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.colUnit.DefaultCellStyle = DataGridViewCellStyle2
        Me.colUnit.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colUnit.HeaderText = "Unit"
        Me.colUnit.Name = "colUnit"
        Me.colUnit.Width = 80
        '
        'colUnitCost
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.colUnitCost.DefaultCellStyle = DataGridViewCellStyle3
        Me.colUnitCost.HeaderText = "Unit Cost"
        Me.colUnitCost.Name = "colUnitCost"
        Me.colUnitCost.Width = 80
        '
        'colValue
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.colValue.DefaultCellStyle = DataGridViewCellStyle4
        Me.colValue.HeaderText = "Value"
        Me.colValue.Name = "colValue"
        Me.colValue.ReadOnly = True
        Me.colValue.Width = 80
        '
        'Column1
        '
        Me.Column1.HeaderText = "Index"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'cboCostCenter
        '
        Me.cboCostCenter.FormattingEnabled = True
        Me.cboCostCenter.Location = New System.Drawing.Point(141, 97)
        Me.cboCostCenter.Name = "cboCostCenter"
        Me.cboCostCenter.Size = New System.Drawing.Size(215, 21)
        Me.cboCostCenter.TabIndex = 585
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(78, 101)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 13)
        Me.Label19.TabIndex = 587
        Me.Label19.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 586
        Me.Label1.Text = "Cost Center"
        '
        'txtCostCenter
        '
        Me.txtCostCenter.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostCenter.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtCostCenter.Location = New System.Drawing.Point(95, 97)
        Me.txtCostCenter.Name = "txtCostCenter"
        Me.txtCostCenter.ReadOnly = True
        Me.txtCostCenter.Size = New System.Drawing.Size(50, 21)
        Me.txtCostCenter.TabIndex = 588
        '
        'frmSelectADMRequestItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 133)
        Me.Controls.Add(Me.cboCostCenter)
        Me.Controls.Add(Me.txtCostCenter)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btEnter)
        Me.Controls.Add(Me.dtgDesc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSelectADMRequestItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Item"
        CType(Me.dtgDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btEnter As Button
    Friend WithEvents dtgDesc As DataGridView
    Friend WithEvents colDesc As DataGridViewTextBoxColumn
    Friend WithEvents colQty As DataGridViewTextBoxColumn
    Friend WithEvents colUnit As DataGridViewComboBoxColumn
    Friend WithEvents colUnitCost As DataGridViewTextBoxColumn
    Friend WithEvents colValue As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents cboCostCenter As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCostCenter As TextBox
End Class
