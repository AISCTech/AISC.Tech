<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectGLEntry
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.cboAgents = New System.Windows.Forms.ComboBox()
        Me.btSelect = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboBank = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgGLMain = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cboLGA = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboAffiliates = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboEmployee = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboClient = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboVendor = New System.Windows.Forms.ComboBox()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.txtLineNbr = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgGLSub = New System.Windows.Forms.DataGridView()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgGLMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgGLSub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFilter)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(992, 52)
        Me.GroupBox1.TabIndex = 448
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type any character to filter below GL Entry List"
        '
        'txtFilter
        '
        Me.txtFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFilter.Location = New System.Drawing.Point(8, 19)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(944, 20)
        Me.txtFilter.TabIndex = 3
        '
        'cboAgents
        '
        Me.cboAgents.Enabled = False
        Me.cboAgents.FormattingEnabled = True
        Me.cboAgents.Location = New System.Drawing.Point(652, 438)
        Me.cboAgents.Name = "cboAgents"
        Me.cboAgents.Size = New System.Drawing.Size(352, 21)
        Me.cboAgents.TabIndex = 465
        '
        'btSelect
        '
        Me.btSelect.Location = New System.Drawing.Point(20, 382)
        Me.btSelect.Name = "btSelect"
        Me.btSelect.Size = New System.Drawing.Size(200, 55)
        Me.btSelect.TabIndex = 464
        Me.btSelect.Text = "Select"
        Me.btSelect.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(580, 414)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 463
        Me.Label8.Text = "Banks:"
        '
        'cboBank
        '
        Me.cboBank.Enabled = False
        Me.cboBank.FormattingEnabled = True
        Me.cboBank.Location = New System.Drawing.Point(652, 414)
        Me.cboBank.Name = "cboBank"
        Me.cboBank.Size = New System.Drawing.Size(352, 21)
        Me.cboBank.TabIndex = 462
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(492, 390)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(154, 13)
        Me.Label7.TabIndex = 461
        Me.Label7.Text = "Local and Government Agency"
        '
        'dgGLMain
        '
        Me.dgGLMain.AllowUserToAddRows = False
        Me.dgGLMain.AllowUserToDeleteRows = False
        Me.dgGLMain.AllowUserToResizeColumns = False
        Me.dgGLMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgGLMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgGLMain.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgGLMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgGLMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dgGLMain.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgGLMain.Location = New System.Drawing.Point(12, 19)
        Me.dgGLMain.MultiSelect = False
        Me.dgGLMain.Name = "dgGLMain"
        Me.dgGLMain.ReadOnly = True
        Me.dgGLMain.RowHeadersVisible = False
        Me.dgGLMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgGLMain.Size = New System.Drawing.Size(488, 157)
        Me.dgGLMain.TabIndex = 255
        '
        'Column1
        '
        Me.Column1.HeaderText = "Account Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Account Title"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "Account Type"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Report Type"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Line Item"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Sub"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 25
        '
        'cboLGA
        '
        Me.cboLGA.Enabled = False
        Me.cboLGA.FormattingEnabled = True
        Me.cboLGA.Location = New System.Drawing.Point(652, 390)
        Me.cboLGA.Name = "cboLGA"
        Me.cboLGA.Size = New System.Drawing.Size(352, 21)
        Me.cboLGA.TabIndex = 460
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(580, 366)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 459
        Me.Label6.Text = "Affiliates:"
        '
        'cboAffiliates
        '
        Me.cboAffiliates.Enabled = False
        Me.cboAffiliates.FormattingEnabled = True
        Me.cboAffiliates.Location = New System.Drawing.Point(652, 366)
        Me.cboAffiliates.Name = "cboAffiliates"
        Me.cboAffiliates.Size = New System.Drawing.Size(352, 21)
        Me.cboAffiliates.TabIndex = 458
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(580, 342)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 457
        Me.Label5.Text = "Employees:"
        '
        'cboEmployee
        '
        Me.cboEmployee.Enabled = False
        Me.cboEmployee.FormattingEnabled = True
        Me.cboEmployee.Location = New System.Drawing.Point(652, 342)
        Me.cboEmployee.Name = "cboEmployee"
        Me.cboEmployee.Size = New System.Drawing.Size(352, 21)
        Me.cboEmployee.TabIndex = 456
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(580, 318)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 455
        Me.Label4.Text = "Client:"
        '
        'cboClient
        '
        Me.cboClient.Enabled = False
        Me.cboClient.FormattingEnabled = True
        Me.cboClient.Location = New System.Drawing.Point(652, 318)
        Me.cboClient.Name = "cboClient"
        Me.cboClient.Size = New System.Drawing.Size(352, 21)
        Me.cboClient.TabIndex = 454
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(580, 294)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 453
        Me.Label3.Text = "Vendor:"
        '
        'cboVendor
        '
        Me.cboVendor.Enabled = False
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(652, 294)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(352, 21)
        Me.cboVendor.TabIndex = 452
        '
        'cboDept
        '
        Me.cboDept.Enabled = False
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New System.Drawing.Point(107, 291)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(272, 21)
        Me.cboDept.TabIndex = 450
        '
        'txtLineNbr
        '
        Me.txtLineNbr.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtLineNbr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtLineNbr.Location = New System.Drawing.Point(403, 39)
        Me.txtLineNbr.Name = "txtLineNbr"
        Me.txtLineNbr.Size = New System.Drawing.Size(69, 20)
        Me.txtLineNbr.TabIndex = 3
        Me.txtLineNbr.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(580, 438)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 466
        Me.Label9.Text = "Agents:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgGLSub)
        Me.GroupBox3.Location = New System.Drawing.Point(518, 81)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(486, 191)
        Me.GroupBox3.TabIndex = 467
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sub Account"
        '
        'dgGLSub
        '
        Me.dgGLSub.AllowUserToAddRows = False
        Me.dgGLSub.AllowUserToDeleteRows = False
        Me.dgGLSub.AllowUserToResizeColumns = False
        Me.dgGLSub.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgGLSub.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgGLSub.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgGLSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgGLSub.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12})
        Me.dgGLSub.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgGLSub.Location = New System.Drawing.Point(6, 24)
        Me.dgGLSub.MultiSelect = False
        Me.dgGLSub.Name = "dgGLSub"
        Me.dgGLSub.ReadOnly = True
        Me.dgGLSub.RowHeadersVisible = False
        Me.dgGLSub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgGLSub.Size = New System.Drawing.Size(474, 152)
        Me.dgGLSub.TabIndex = 255
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 294)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 451
        Me.Label1.Text = "Department:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgGLMain)
        Me.GroupBox2.Controls.Add(Me.txtLineNbr)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(500, 191)
        Me.GroupBox2.TabIndex = 449
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Main Account"
        '
        'frmSelectGLEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 501)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboAgents)
        Me.Controls.Add(Me.btSelect)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboBank)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboLGA)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboAffiliates)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboEmployee)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboClient)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboVendor)
        Me.Controls.Add(Me.cboDept)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSelectGLEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select GL Entry"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgGLMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgGLSub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents cboAgents As ComboBox
    Friend WithEvents btSelect As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents cboBank As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dgGLMain As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewCheckBoxColumn
    Friend WithEvents cboLGA As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cboAffiliates As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboEmployee As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboClient As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboVendor As ComboBox
    Friend WithEvents cboDept As ComboBox
    Friend WithEvents txtLineNbr As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgGLSub As DataGridView
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewCheckBoxColumn
    Friend WithEvents Column11 As DataGridViewCheckBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
End Class
