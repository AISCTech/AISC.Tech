<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectAP
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboClient = New System.Windows.Forms.ComboBox()
        Me.dgGLSub = New System.Windows.Forms.DataGridView()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btClose = New System.Windows.Forms.Button()
        Me.txtLineNbr = New System.Windows.Forms.TextBox()
        Me.btSelect = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboAgents = New System.Windows.Forms.ComboBox()
        Me.optAP = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.optSalary = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtAcctCode = New System.Windows.Forms.TextBox()
        Me.txtAcctName = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgGLSub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboClient
        '
        Me.cboClient.Enabled = False
        Me.cboClient.FormattingEnabled = True
        Me.cboClient.Location = New System.Drawing.Point(58, 257)
        Me.cboClient.Name = "cboClient"
        Me.cboClient.Size = New System.Drawing.Size(352, 21)
        Me.cboClient.TabIndex = 494
        '
        'dgGLSub
        '
        Me.dgGLSub.AllowUserToAddRows = False
        Me.dgGLSub.AllowUserToDeleteRows = False
        Me.dgGLSub.AllowUserToResizeColumns = False
        Me.dgGLSub.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgGLSub.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgGLSub.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgGLSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgGLSub.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12})
        Me.dgGLSub.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgGLSub.Location = New System.Drawing.Point(6, 101)
        Me.dgGLSub.MultiSelect = False
        Me.dgGLSub.Name = "dgGLSub"
        Me.dgGLSub.ReadOnly = True
        Me.dgGLSub.RowHeadersVisible = False
        Me.dgGLSub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgGLSub.Size = New System.Drawing.Size(376, 128)
        Me.dgGLSub.TabIndex = 485
        '
        'Column7
        '
        Me.Column7.HeaderText = "Account Code"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Sub Account Code"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Sub Account Title"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "By Dept"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column11
        '
        Me.Column11.HeaderText = "By List"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column12
        '
        Me.Column12.HeaderText = "List Item"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(314, 353)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(96, 31)
        Me.btClose.TabIndex = 500
        Me.btClose.Text = "Close"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'txtLineNbr
        '
        Me.txtLineNbr.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtLineNbr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtLineNbr.Location = New System.Drawing.Point(226, 329)
        Me.txtLineNbr.Name = "txtLineNbr"
        Me.txtLineNbr.Size = New System.Drawing.Size(184, 20)
        Me.txtLineNbr.TabIndex = 499
        '
        'btSelect
        '
        Me.btSelect.Location = New System.Drawing.Point(10, 329)
        Me.btSelect.Name = "btSelect"
        Me.btSelect.Size = New System.Drawing.Size(200, 55)
        Me.btSelect.TabIndex = 498
        Me.btSelect.Text = "Select"
        Me.btSelect.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 297)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 497
        Me.Label9.Text = "Agents:"
        '
        'cboAgents
        '
        Me.cboAgents.Enabled = False
        Me.cboAgents.FormattingEnabled = True
        Me.cboAgents.Location = New System.Drawing.Point(58, 289)
        Me.cboAgents.Name = "cboAgents"
        Me.cboAgents.Size = New System.Drawing.Size(352, 21)
        Me.cboAgents.TabIndex = 496
        '
        'optAP
        '
        Me.optAP.AutoSize = True
        Me.optAP.Checked = True
        Me.optAP.Location = New System.Drawing.Point(3, 3)
        Me.optAP.Name = "optAP"
        Me.optAP.Size = New System.Drawing.Size(116, 17)
        Me.optAP.TabIndex = 0
        Me.optAP.TabStop = True
        Me.optAP.Text = "Accounts Payables"
        Me.optAP.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 483
        Me.Label5.Text = "Main Account:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 436
        Me.Label3.Text = "Sub Account:"
        '
        'optSalary
        '
        Me.optSalary.AutoSize = True
        Me.optSalary.Location = New System.Drawing.Point(162, 3)
        Me.optSalary.Name = "optSalary"
        Me.optSalary.Size = New System.Drawing.Size(120, 17)
        Me.optSalary.TabIndex = 1
        Me.optSalary.Text = "Salaries and Wages"
        Me.optSalary.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optSalary)
        Me.Panel1.Controls.Add(Me.optAP)
        Me.Panel1.Location = New System.Drawing.Point(6, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(376, 24)
        Me.Panel1.TabIndex = 484
        '
        'txtAcctCode
        '
        Me.txtAcctCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtAcctCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcctCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtAcctCode.Location = New System.Drawing.Point(6, 62)
        Me.txtAcctCode.Name = "txtAcctCode"
        Me.txtAcctCode.ReadOnly = True
        Me.txtAcctCode.Size = New System.Drawing.Size(56, 21)
        Me.txtAcctCode.TabIndex = 481
        Me.txtAcctCode.Text = "2010"
        Me.txtAcctCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAcctName
        '
        Me.txtAcctName.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtAcctName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcctName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtAcctName.Location = New System.Drawing.Point(62, 62)
        Me.txtAcctName.Name = "txtAcctName"
        Me.txtAcctName.ReadOnly = True
        Me.txtAcctName.Size = New System.Drawing.Size(320, 21)
        Me.txtAcctName.TabIndex = 482
        Me.txtAcctName.Text = "Accounts Payables"
        Me.txtAcctName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgGLSub)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.txtAcctCode)
        Me.GroupBox1.Controls.Add(Me.txtAcctName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 235)
        Me.GroupBox1.TabIndex = 501
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 260)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 495
        Me.Label4.Text = "Vendor:"
        '
        'frmSelectAP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 392)
        Me.ControlBox = False
        Me.Controls.Add(Me.cboClient)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.txtLineNbr)
        Me.Controls.Add(Me.btSelect)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboAgents)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSelectAP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select AP"
        CType(Me.dgGLSub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboClient As ComboBox
    Friend WithEvents dgGLSub As DataGridView
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewCheckBoxColumn
    Friend WithEvents Column11 As DataGridViewCheckBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents btClose As Button
    Friend WithEvents txtLineNbr As TextBox
    Friend WithEvents btSelect As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents cboAgents As ComboBox
    Friend WithEvents optAP As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents optSalary As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtAcctCode As TextBox
    Friend WithEvents txtAcctName As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
End Class
