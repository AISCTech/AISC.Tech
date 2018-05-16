<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUnposted
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
        Me.optImpDCAF = New System.Windows.Forms.RadioButton()
        Me.optImpF = New System.Windows.Forms.RadioButton()
        Me.optImpB = New System.Windows.Forms.RadioButton()
        Me.optExp = New System.Windows.Forms.RadioButton()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.cmdPost = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.colRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colchkSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrepBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkAllDate = New System.Windows.Forms.CheckBox()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtgUnposted = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        CType(Me.dtgUnposted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'optImpDCAF
        '
        Me.optImpDCAF.AutoSize = True
        Me.optImpDCAF.Location = New System.Drawing.Point(214, 49)
        Me.optImpDCAF.Name = "optImpDCAF"
        Me.optImpDCAF.Size = New System.Drawing.Size(114, 17)
        Me.optImpDCAF.TabIndex = 3
        Me.optImpDCAF.Text = "Import DC Note AF"
        Me.optImpDCAF.UseVisualStyleBackColor = True
        '
        'optImpF
        '
        Me.optImpF.AutoSize = True
        Me.optImpF.Location = New System.Drawing.Point(214, 23)
        Me.optImpF.Name = "optImpF"
        Me.optImpF.Size = New System.Drawing.Size(109, 17)
        Me.optImpF.TabIndex = 2
        Me.optImpF.Text = "Import Forwarding"
        Me.optImpF.UseVisualStyleBackColor = True
        '
        'optImpB
        '
        Me.optImpB.AutoSize = True
        Me.optImpB.Location = New System.Drawing.Point(102, 32)
        Me.optImpB.Name = "optImpB"
        Me.optImpB.Size = New System.Drawing.Size(106, 17)
        Me.optImpB.TabIndex = 1
        Me.optImpB.Text = "Import Brokerage"
        Me.optImpB.UseVisualStyleBackColor = True
        '
        'optExp
        '
        Me.optExp.AutoSize = True
        Me.optExp.Checked = True
        Me.optExp.Location = New System.Drawing.Point(11, 32)
        Me.optExp.Name = "optExp"
        Me.optExp.Size = New System.Drawing.Size(85, 17)
        Me.optExp.TabIndex = 0
        Me.optExp.TabStop = True
        Me.optExp.Text = "Export Billing"
        Me.optExp.UseVisualStyleBackColor = True
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSelectAll.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkSelectAll.Location = New System.Drawing.Point(12, 91)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(80, 17)
        Me.chkSelectAll.TabIndex = 441
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'cmdPost
        '
        Me.cmdPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPost.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdPost.Location = New System.Drawing.Point(12, 371)
        Me.cmdPost.Name = "cmdPost"
        Me.cmdPost.Size = New System.Drawing.Size(75, 52)
        Me.cmdPost.TabIndex = 440
        Me.cmdPost.Text = "Post"
        Me.cmdPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdPost.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optImpDCAF)
        Me.GroupBox1.Controls.Add(Me.optImpF)
        Me.GroupBox1.Controls.Add(Me.optImpB)
        Me.GroupBox1.Controls.Add(Me.optExp)
        Me.GroupBox1.Location = New System.Drawing.Point(326, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(332, 73)
        Me.GroupBox1.TabIndex = 439
        Me.GroupBox1.TabStop = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Prep. By"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 175
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Prep. Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 175
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Ref. No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'dtFrom
        '
        Me.dtFrom.Location = New System.Drawing.Point(56, 19)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtFrom.TabIndex = 0
        '
        'dtTo
        '
        Me.dtTo.Location = New System.Drawing.Point(56, 45)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(200, 20)
        Me.dtTo.TabIndex = 1
        '
        'colRefNo
        '
        Me.colRefNo.HeaderText = "Ref. No."
        Me.colRefNo.Name = "colRefNo"
        Me.colRefNo.ReadOnly = True
        Me.colRefNo.Width = 150
        '
        'colchkSelect
        '
        Me.colchkSelect.HeaderText = ""
        Me.colchkSelect.Name = "colchkSelect"
        Me.colchkSelect.Width = 25
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Date Received"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 130
        '
        'colPrepBy
        '
        Me.colPrepBy.HeaderText = "Prep. By"
        Me.colPrepBy.Name = "colPrepBy"
        Me.colPrepBy.ReadOnly = True
        Me.colPrepBy.Width = 175
        '
        'chkAllDate
        '
        Me.chkAllDate.AutoSize = True
        Me.chkAllDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAllDate.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkAllDate.Location = New System.Drawing.Point(262, 48)
        Me.chkAllDate.Name = "chkAllDate"
        Me.chkAllDate.Size = New System.Drawing.Size(40, 17)
        Me.chkAllDate.TabIndex = 434
        Me.chkAllDate.Text = "All"
        Me.chkAllDate.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.chkAllDate)
        Me.GroupBox14.Controls.Add(Me.Label13)
        Me.GroupBox14.Controls.Add(Me.Label14)
        Me.GroupBox14.Controls.Add(Me.dtTo)
        Me.GroupBox14.Controls.Add(Me.dtFrom)
        Me.GroupBox14.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(308, 73)
        Me.GroupBox14.TabIndex = 438
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Covered Prep. Date"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Location = New System.Drawing.Point(16, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "To : "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.Location = New System.Drawing.Point(4, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "From : "
        '
        'dtgUnposted
        '
        Me.dtgUnposted.AllowUserToAddRows = False
        Me.dtgUnposted.AllowUserToDeleteRows = False
        Me.dtgUnposted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgUnposted.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colchkSelect, Me.colRefNo, Me.colPrepBy})
        Me.dtgUnposted.Location = New System.Drawing.Point(12, 108)
        Me.dtgUnposted.Name = "dtgUnposted"
        Me.dtgUnposted.Size = New System.Drawing.Size(646, 257)
        Me.dtgUnposted.TabIndex = 434
        '
        'frmUnposted
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 428)
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.cmdPost)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox14)
        Me.Controls.Add(Me.dtgUnposted)
        Me.Name = "frmUnposted"
        Me.Text = "frmUnposted"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        CType(Me.dtgUnposted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents optImpDCAF As RadioButton
    Friend WithEvents optImpF As RadioButton
    Friend WithEvents optImpB As RadioButton
    Friend WithEvents optExp As RadioButton
    Friend WithEvents chkSelectAll As CheckBox
    Friend WithEvents cmdPost As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents colRefNo As DataGridViewTextBoxColumn
    Friend WithEvents colchkSelect As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents colPrepBy As DataGridViewTextBoxColumn
    Friend WithEvents chkAllDate As CheckBox
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents dtgUnposted As DataGridView
End Class
