<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateVoucher
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreateVoucher))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.optCheck = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optMC = New System.Windows.Forms.RadioButton()
        Me.dtgRefNo = New System.Windows.Forms.DataGridView()
        Me.txtDateNeeded = New System.Windows.Forms.TextBox()
        Me.cmdSelect = New System.Windows.Forms.Button()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboBranch = New System.Windows.Forms.ComboBox()
        Me.optAPVNo = New System.Windows.Forms.RadioButton()
        Me.optReqNo = New System.Windows.Forms.RadioButton()
        Me.gpType = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVoucherAmt = New System.Windows.Forms.TextBox()
        Me.optFull = New System.Windows.Forms.RadioButton()
        Me.optPartial = New System.Windows.Forms.RadioButton()
        Me.txtPayeeID = New System.Windows.Forms.TextBox()
        Me.txtPayeeName = New System.Windows.Forms.TextBox()
        Me.lblNonAccrualType = New System.Windows.Forms.Label()
        Me.gpInclude = New System.Windows.Forms.GroupBox()
        Me.cmdGo = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdClearAllEntry = New System.Windows.Forms.Button()
        Me.cmdRemoveEntry = New System.Windows.Forms.Button()
        Me.colRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDTNeeded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCVAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAPV = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colFull = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgRefNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpType.SuspendLayout()
        Me.gpInclude.SuspendLayout()
        Me.SuspendLayout()
        '
        'optCheck
        '
        Me.optCheck.AutoSize = True
        Me.optCheck.Checked = True
        Me.optCheck.Location = New System.Drawing.Point(17, 19)
        Me.optCheck.Name = "optCheck"
        Me.optCheck.Size = New System.Drawing.Size(56, 17)
        Me.optCheck.TabIndex = 440
        Me.optCheck.TabStop = True
        Me.optCheck.Text = "Check"
        Me.optCheck.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optMC)
        Me.GroupBox1.Controls.Add(Me.optCheck)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 46)
        Me.GroupBox1.TabIndex = 449
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Voucher Type"
        '
        'optMC
        '
        Me.optMC.AutoSize = True
        Me.optMC.Location = New System.Drawing.Point(106, 19)
        Me.optMC.Name = "optMC"
        Me.optMC.Size = New System.Drawing.Size(41, 17)
        Me.optMC.TabIndex = 441
        Me.optMC.Text = "MC"
        Me.optMC.UseVisualStyleBackColor = True
        '
        'dtgRefNo
        '
        Me.dtgRefNo.AllowUserToAddRows = False
        Me.dtgRefNo.AllowUserToDeleteRows = False
        Me.dtgRefNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgRefNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRefNo, Me.colPayee, Me.colDTNeeded, Me.colAmt, Me.colCVAmt, Me.colAPV, Me.colFull, Me.Column1, Me.Column2})
        Me.dtgRefNo.Location = New System.Drawing.Point(12, 190)
        Me.dtgRefNo.Name = "dtgRefNo"
        Me.dtgRefNo.ReadOnly = True
        Me.dtgRefNo.Size = New System.Drawing.Size(745, 165)
        Me.dtgRefNo.TabIndex = 441
        '
        'txtDateNeeded
        '
        Me.txtDateNeeded.Location = New System.Drawing.Point(12, 387)
        Me.txtDateNeeded.Name = "txtDateNeeded"
        Me.txtDateNeeded.Size = New System.Drawing.Size(193, 20)
        Me.txtDateNeeded.TabIndex = 448
        Me.txtDateNeeded.Visible = False
        '
        'cmdSelect
        '
        Me.cmdSelect.Location = New System.Drawing.Point(658, 60)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelect.TabIndex = 425
        Me.cmdSelect.Text = "Select"
        Me.cmdSelect.UseVisualStyleBackColor = True
        '
        'txtRefNo
        '
        Me.txtRefNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNo.Location = New System.Drawing.Point(122, 61)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(293, 22)
        Me.txtRefNo.TabIndex = 424
        '
        'lblPrefix
        '
        Me.lblPrefix.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPrefix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrefix.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrefix.ForeColor = System.Drawing.Color.Black
        Me.lblPrefix.Location = New System.Drawing.Point(17, 61)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(105, 22)
        Me.lblPrefix.TabIndex = 423
        Me.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(291, 19)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(47, 13)
        Me.Label24.TabIndex = 422
        Me.Label24.Text = "Branch :"
        '
        'cboBranch
        '
        Me.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranch.ForeColor = System.Drawing.Color.SteelBlue
        Me.cboBranch.FormattingEnabled = True
        Me.cboBranch.Location = New System.Drawing.Point(294, 35)
        Me.cboBranch.Name = "cboBranch"
        Me.cboBranch.Size = New System.Drawing.Size(121, 21)
        Me.cboBranch.TabIndex = 2
        '
        'optAPVNo
        '
        Me.optAPVNo.AutoSize = True
        Me.optAPVNo.Checked = True
        Me.optAPVNo.Location = New System.Drawing.Point(176, 19)
        Me.optAPVNo.Name = "optAPVNo"
        Me.optAPVNo.Size = New System.Drawing.Size(102, 30)
        Me.optAPVNo.TabIndex = 1
        Me.optAPVNo.TabStop = True
        Me.optAPVNo.Text = "AP Voucher No." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Accrual)"
        Me.optAPVNo.UseVisualStyleBackColor = True
        '
        'optReqNo
        '
        Me.optReqNo.AutoSize = True
        Me.optReqNo.Location = New System.Drawing.Point(17, 19)
        Me.optReqNo.Name = "optReqNo"
        Me.optReqNo.Size = New System.Drawing.Size(153, 30)
        Me.optReqNo.TabIndex = 0
        Me.optReqNo.Text = "Request no." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Petty Cash/Fund Transfer)"
        Me.optReqNo.UseVisualStyleBackColor = True
        Me.optReqNo.Visible = False
        '
        'gpType
        '
        Me.gpType.Controls.Add(Me.Label1)
        Me.gpType.Controls.Add(Me.txtVoucherAmt)
        Me.gpType.Controls.Add(Me.optFull)
        Me.gpType.Controls.Add(Me.optPartial)
        Me.gpType.Location = New System.Drawing.Point(421, 9)
        Me.gpType.Name = "gpType"
        Me.gpType.Size = New System.Drawing.Size(231, 74)
        Me.gpType.TabIndex = 426
        Me.gpType.TabStop = False
        Me.gpType.Text = "Payment Mode"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(79, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Voucher Amt :"
        '
        'txtVoucherAmt
        '
        Me.txtVoucherAmt.Enabled = False
        Me.txtVoucherAmt.Location = New System.Drawing.Point(82, 41)
        Me.txtVoucherAmt.Name = "txtVoucherAmt"
        Me.txtVoucherAmt.Size = New System.Drawing.Size(133, 20)
        Me.txtVoucherAmt.TabIndex = 2
        Me.txtVoucherAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'optFull
        '
        Me.optFull.AutoSize = True
        Me.optFull.Checked = True
        Me.optFull.Location = New System.Drawing.Point(22, 23)
        Me.optFull.Name = "optFull"
        Me.optFull.Size = New System.Drawing.Size(41, 17)
        Me.optFull.TabIndex = 1
        Me.optFull.TabStop = True
        Me.optFull.Text = "Full"
        Me.optFull.UseVisualStyleBackColor = True
        '
        'optPartial
        '
        Me.optPartial.AutoSize = True
        Me.optPartial.Location = New System.Drawing.Point(22, 42)
        Me.optPartial.Name = "optPartial"
        Me.optPartial.Size = New System.Drawing.Size(54, 17)
        Me.optPartial.TabIndex = 0
        Me.optPartial.Text = "Partial"
        Me.optPartial.UseVisualStyleBackColor = True
        '
        'txtPayeeID
        '
        Me.txtPayeeID.Location = New System.Drawing.Point(12, 361)
        Me.txtPayeeID.Name = "txtPayeeID"
        Me.txtPayeeID.Size = New System.Drawing.Size(100, 20)
        Me.txtPayeeID.TabIndex = 444
        Me.txtPayeeID.Visible = False
        '
        'txtPayeeName
        '
        Me.txtPayeeName.Location = New System.Drawing.Point(118, 361)
        Me.txtPayeeName.Name = "txtPayeeName"
        Me.txtPayeeName.Size = New System.Drawing.Size(337, 20)
        Me.txtPayeeName.TabIndex = 445
        Me.txtPayeeName.Visible = False
        '
        'lblNonAccrualType
        '
        Me.lblNonAccrualType.AutoSize = True
        Me.lblNonAccrualType.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblNonAccrualType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNonAccrualType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNonAccrualType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblNonAccrualType.Location = New System.Drawing.Point(12, 169)
        Me.lblNonAccrualType.Name = "lblNonAccrualType"
        Me.lblNonAccrualType.Size = New System.Drawing.Size(2, 18)
        Me.lblNonAccrualType.TabIndex = 446
        '
        'gpInclude
        '
        Me.gpInclude.Controls.Add(Me.gpType)
        Me.gpInclude.Controls.Add(Me.cmdSelect)
        Me.gpInclude.Controls.Add(Me.txtRefNo)
        Me.gpInclude.Controls.Add(Me.lblPrefix)
        Me.gpInclude.Controls.Add(Me.Label24)
        Me.gpInclude.Controls.Add(Me.cboBranch)
        Me.gpInclude.Controls.Add(Me.optAPVNo)
        Me.gpInclude.Controls.Add(Me.optReqNo)
        Me.gpInclude.Location = New System.Drawing.Point(12, 64)
        Me.gpInclude.Name = "gpInclude"
        Me.gpInclude.Size = New System.Drawing.Size(745, 96)
        Me.gpInclude.TabIndex = 440
        Me.gpInclude.TabStop = False
        Me.gpInclude.Text = "Include to Voucher"
        '
        'cmdGo
        '
        Me.cmdGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGo.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdGo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdGo.Location = New System.Drawing.Point(661, 361)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.Size = New System.Drawing.Size(80, 56)
        Me.cmdGo.TabIndex = 442
        Me.cmdGo.Text = "Go"
        Me.cmdGo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdGo.UseVisualStyleBackColor = True
        '
        'cmdClearAllEntry
        '
        Me.cmdClearAllEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdClearAllEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdClearAllEntry.Image = CType(resources.GetObject("cmdClearAllEntry.Image"), System.Drawing.Image)
        Me.cmdClearAllEntry.Location = New System.Drawing.Point(725, 166)
        Me.cmdClearAllEntry.Name = "cmdClearAllEntry"
        Me.cmdClearAllEntry.Size = New System.Drawing.Size(32, 24)
        Me.cmdClearAllEntry.TabIndex = 447
        Me.cmdClearAllEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.cmdClearAllEntry, "Reset Entries")
        Me.cmdClearAllEntry.UseVisualStyleBackColor = True
        '
        'cmdRemoveEntry
        '
        Me.cmdRemoveEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRemoveEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRemoveEntry.Image = CType(resources.GetObject("cmdRemoveEntry.Image"), System.Drawing.Image)
        Me.cmdRemoveEntry.Location = New System.Drawing.Point(694, 166)
        Me.cmdRemoveEntry.Name = "cmdRemoveEntry"
        Me.cmdRemoveEntry.Size = New System.Drawing.Size(32, 24)
        Me.cmdRemoveEntry.TabIndex = 443
        Me.cmdRemoveEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.cmdRemoveEntry, "Remove Selected Row")
        Me.cmdRemoveEntry.UseVisualStyleBackColor = True
        '
        'colRefNo
        '
        Me.colRefNo.Frozen = True
        Me.colRefNo.HeaderText = "Ref. No."
        Me.colRefNo.Name = "colRefNo"
        Me.colRefNo.ReadOnly = True
        Me.colRefNo.Width = 125
        '
        'colPayee
        '
        Me.colPayee.HeaderText = "Payee Name"
        Me.colPayee.Name = "colPayee"
        Me.colPayee.ReadOnly = True
        Me.colPayee.Width = 250
        '
        'colDTNeeded
        '
        Me.colDTNeeded.HeaderText = "Date/Time Needed"
        Me.colDTNeeded.Name = "colDTNeeded"
        Me.colDTNeeded.ReadOnly = True
        Me.colDTNeeded.Width = 125
        '
        'colAmt
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAmt.DefaultCellStyle = DataGridViewCellStyle1
        Me.colAmt.HeaderText = "Requested Amt"
        Me.colAmt.Name = "colAmt"
        Me.colAmt.ReadOnly = True
        Me.colAmt.Width = 125
        '
        'colCVAmt
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        Me.colCVAmt.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCVAmt.HeaderText = "CV Amt"
        Me.colCVAmt.Name = "colCVAmt"
        Me.colCVAmt.ReadOnly = True
        Me.colCVAmt.Width = 125
        '
        'colAPV
        '
        Me.colAPV.HeaderText = "APV"
        Me.colAPV.Name = "colAPV"
        Me.colAPV.ReadOnly = True
        Me.colAPV.Width = 50
        '
        'colFull
        '
        Me.colFull.HeaderText = "Full"
        Me.colFull.Name = "colFull"
        Me.colFull.ReadOnly = True
        Me.colFull.Width = 50
        '
        'Column1
        '
        Me.Column1.HeaderText = "Company Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "colReqType"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'frmCreateVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 429)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgRefNo)
        Me.Controls.Add(Me.txtDateNeeded)
        Me.Controls.Add(Me.txtPayeeID)
        Me.Controls.Add(Me.txtPayeeName)
        Me.Controls.Add(Me.lblNonAccrualType)
        Me.Controls.Add(Me.gpInclude)
        Me.Controls.Add(Me.cmdGo)
        Me.Controls.Add(Me.cmdClearAllEntry)
        Me.Controls.Add(Me.cmdRemoveEntry)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCreateVoucher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Voucher"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgRefNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpType.ResumeLayout(False)
        Me.gpType.PerformLayout()
        Me.gpInclude.ResumeLayout(False)
        Me.gpInclude.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents optCheck As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents optMC As RadioButton
    Friend WithEvents dtgRefNo As DataGridView
    Friend WithEvents txtDateNeeded As TextBox
    Friend WithEvents cmdSelect As Button
    Friend WithEvents txtRefNo As TextBox
    Friend WithEvents lblPrefix As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents cboBranch As ComboBox
    Friend WithEvents optAPVNo As RadioButton
    Friend WithEvents optReqNo As RadioButton
    Friend WithEvents gpType As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtVoucherAmt As TextBox
    Friend WithEvents optFull As RadioButton
    Friend WithEvents optPartial As RadioButton
    Friend WithEvents txtPayeeID As TextBox
    Friend WithEvents txtPayeeName As TextBox
    Friend WithEvents lblNonAccrualType As Label
    Friend WithEvents gpInclude As GroupBox
    Friend WithEvents cmdGo As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cmdClearAllEntry As Button
    Friend WithEvents cmdRemoveEntry As Button
    Friend WithEvents colRefNo As DataGridViewTextBoxColumn
    Friend WithEvents colPayee As DataGridViewTextBoxColumn
    Friend WithEvents colDTNeeded As DataGridViewTextBoxColumn
    Friend WithEvents colAmt As DataGridViewTextBoxColumn
    Friend WithEvents colCVAmt As DataGridViewTextBoxColumn
    Friend WithEvents colAPV As DataGridViewCheckBoxColumn
    Friend WithEvents colFull As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
End Class
