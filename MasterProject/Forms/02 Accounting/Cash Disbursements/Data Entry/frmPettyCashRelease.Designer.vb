<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPettyCashRelease
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPettyCashRelease))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtRequestedAmt = New System.Windows.Forms.TextBox()
        Me.txtFundKey = New System.Windows.Forms.TextBox()
        Me.txtFundName = New System.Windows.Forms.TextBox()
        Me.cboPayee = New System.Windows.Forms.ComboBox()
        Me.dtgPCReleaseEntry = New System.Windows.Forms.DataGridView()
        Me.colSelectEntry = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colAcctCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAcctTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubAcctTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colchkDept = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colDeptName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colchkList = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colListItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colListItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdPettyCash = New System.Windows.Forms.Button()
        Me.btRelease = New System.Windows.Forms.Button()
        Me.cmdAddEntry = New System.Windows.Forms.Button()
        Me.cmdRemoveEntry = New System.Windows.Forms.Button()
        Me.cmdClearAllEntry = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgCharges = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGPAType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        CType(Me.dtgPCReleaseEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRequestedAmt
        '
        Me.txtRequestedAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtRequestedAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestedAmt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtRequestedAmt.Location = New System.Drawing.Point(326, 61)
        Me.txtRequestedAmt.Name = "txtRequestedAmt"
        Me.txtRequestedAmt.ReadOnly = True
        Me.txtRequestedAmt.Size = New System.Drawing.Size(118, 20)
        Me.txtRequestedAmt.TabIndex = 337
        Me.txtRequestedAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFundKey
        '
        Me.txtFundKey.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtFundKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFundKey.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFundKey.Location = New System.Drawing.Point(109, 42)
        Me.txtFundKey.Name = "txtFundKey"
        Me.txtFundKey.ReadOnly = True
        Me.txtFundKey.Size = New System.Drawing.Size(72, 20)
        Me.txtFundKey.TabIndex = 332
        '
        'txtFundName
        '
        Me.txtFundName.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtFundName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFundName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFundName.Location = New System.Drawing.Point(180, 42)
        Me.txtFundName.Name = "txtFundName"
        Me.txtFundName.ReadOnly = True
        Me.txtFundName.Size = New System.Drawing.Size(264, 20)
        Me.txtFundName.TabIndex = 336
        '
        'cboPayee
        '
        Me.cboPayee.FormattingEnabled = True
        Me.cboPayee.Location = New System.Drawing.Point(109, 22)
        Me.cboPayee.Name = "cboPayee"
        Me.cboPayee.Size = New System.Drawing.Size(335, 21)
        Me.cboPayee.TabIndex = 335
        '
        'dtgPCReleaseEntry
        '
        Me.dtgPCReleaseEntry.AllowUserToAddRows = False
        Me.dtgPCReleaseEntry.AllowUserToDeleteRows = False
        Me.dtgPCReleaseEntry.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dtgPCReleaseEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPCReleaseEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelectEntry, Me.colAcctCode, Me.colAcctTitle, Me.colDR, Me.colCR, Me.colSubCode, Me.colSubAcctTitle, Me.colchkDept, Me.colDeptName, Me.colchkList, Me.colListItem, Me.colListItemName})
        Me.dtgPCReleaseEntry.Location = New System.Drawing.Point(4, 122)
        Me.dtgPCReleaseEntry.Name = "dtgPCReleaseEntry"
        Me.dtgPCReleaseEntry.Size = New System.Drawing.Size(654, 218)
        Me.dtgPCReleaseEntry.TabIndex = 479
        '
        'colSelectEntry
        '
        Me.colSelectEntry.Frozen = True
        Me.colSelectEntry.HeaderText = ""
        Me.colSelectEntry.Name = "colSelectEntry"
        Me.colSelectEntry.ReadOnly = True
        Me.colSelectEntry.Width = 25
        '
        'colAcctCode
        '
        Me.colAcctCode.Frozen = True
        Me.colAcctCode.HeaderText = "Account Code"
        Me.colAcctCode.Name = "colAcctCode"
        Me.colAcctCode.ReadOnly = True
        '
        'colAcctTitle
        '
        Me.colAcctTitle.Frozen = True
        Me.colAcctTitle.HeaderText = "Account Title"
        Me.colAcctTitle.Name = "colAcctTitle"
        Me.colAcctTitle.ReadOnly = True
        Me.colAcctTitle.Width = 150
        '
        'colDR
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.colDR.DefaultCellStyle = DataGridViewCellStyle1
        Me.colDR.HeaderText = "DR"
        Me.colDR.Name = "colDR"
        Me.colDR.Width = 75
        '
        'colCR
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colCR.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCR.HeaderText = "CR"
        Me.colCR.Name = "colCR"
        Me.colCR.Width = 75
        '
        'colSubCode
        '
        Me.colSubCode.HeaderText = ""
        Me.colSubCode.Name = "colSubCode"
        Me.colSubCode.ReadOnly = True
        Me.colSubCode.Width = 25
        '
        'colSubAcctTitle
        '
        Me.colSubAcctTitle.HeaderText = "Sub Account Title"
        Me.colSubAcctTitle.Name = "colSubAcctTitle"
        Me.colSubAcctTitle.ReadOnly = True
        Me.colSubAcctTitle.Width = 150
        '
        'colchkDept
        '
        Me.colchkDept.HeaderText = ""
        Me.colchkDept.Name = "colchkDept"
        Me.colchkDept.ReadOnly = True
        Me.colchkDept.Width = 25
        '
        'colDeptName
        '
        Me.colDeptName.HeaderText = "Dept."
        Me.colDeptName.Name = "colDeptName"
        Me.colDeptName.ReadOnly = True
        Me.colDeptName.Width = 50
        '
        'colchkList
        '
        Me.colchkList.HeaderText = ""
        Me.colchkList.Name = "colchkList"
        Me.colchkList.ReadOnly = True
        Me.colchkList.Width = 25
        '
        'colListItem
        '
        Me.colListItem.HeaderText = "List Item"
        Me.colListItem.Name = "colListItem"
        Me.colListItem.ReadOnly = True
        Me.colListItem.Width = 75
        '
        'colListItemName
        '
        Me.colListItemName.HeaderText = "List Item Name"
        Me.colListItemName.Name = "colListItemName"
        Me.colListItemName.ReadOnly = True
        Me.colListItemName.Width = 150
        '
        'cmdPettyCash
        '
        Me.cmdPettyCash.AccessibleDescription = ""
        Me.cmdPettyCash.AccessibleName = ""
        Me.cmdPettyCash.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPettyCash.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdPettyCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPettyCash.Location = New System.Drawing.Point(97, 92)
        Me.cmdPettyCash.Name = "cmdPettyCash"
        Me.cmdPettyCash.Size = New System.Drawing.Size(126, 24)
        Me.cmdPettyCash.TabIndex = 478
        Me.cmdPettyCash.Text = "Petty Cash"
        Me.cmdPettyCash.UseVisualStyleBackColor = True
        '
        'btRelease
        '
        Me.btRelease.Enabled = False
        Me.btRelease.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRelease.ForeColor = System.Drawing.Color.DarkBlue
        Me.btRelease.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btRelease.Location = New System.Drawing.Point(493, 346)
        Me.btRelease.Name = "btRelease"
        Me.btRelease.Size = New System.Drawing.Size(80, 24)
        Me.btRelease.TabIndex = 473
        Me.btRelease.Text = "Release"
        Me.btRelease.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btRelease.UseVisualStyleBackColor = True
        '
        'cmdAddEntry
        '
        Me.cmdAddEntry.AccessibleDescription = ""
        Me.cmdAddEntry.AccessibleName = ""
        Me.cmdAddEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAddEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAddEntry.Image = CType(resources.GetObject("cmdAddEntry.Image"), System.Drawing.Image)
        Me.cmdAddEntry.Location = New System.Drawing.Point(4, 92)
        Me.cmdAddEntry.Name = "cmdAddEntry"
        Me.cmdAddEntry.Size = New System.Drawing.Size(32, 24)
        Me.cmdAddEntry.TabIndex = 475
        Me.cmdAddEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAddEntry.UseVisualStyleBackColor = True
        '
        'cmdRemoveEntry
        '
        Me.cmdRemoveEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRemoveEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRemoveEntry.Image = CType(resources.GetObject("cmdRemoveEntry.Image"), System.Drawing.Image)
        Me.cmdRemoveEntry.Location = New System.Drawing.Point(35, 92)
        Me.cmdRemoveEntry.Name = "cmdRemoveEntry"
        Me.cmdRemoveEntry.Size = New System.Drawing.Size(32, 24)
        Me.cmdRemoveEntry.TabIndex = 476
        Me.cmdRemoveEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdRemoveEntry.UseVisualStyleBackColor = True
        '
        'cmdClearAllEntry
        '
        Me.cmdClearAllEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdClearAllEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdClearAllEntry.Image = CType(resources.GetObject("cmdClearAllEntry.Image"), System.Drawing.Image)
        Me.cmdClearAllEntry.Location = New System.Drawing.Point(66, 92)
        Me.cmdClearAllEntry.Name = "cmdClearAllEntry"
        Me.cmdClearAllEntry.Size = New System.Drawing.Size(32, 24)
        Me.cmdClearAllEntry.TabIndex = 477
        Me.cmdClearAllEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdClearAllEntry.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClose.ForeColor = System.Drawing.Color.DarkBlue
        Me.btClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btClose.Location = New System.Drawing.Point(579, 346)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(80, 24)
        Me.btClose.TabIndex = 474
        Me.btClose.Text = "Close"
        Me.btClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 482
        Me.Label1.Text = "Received By"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(92, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 13)
        Me.Label15.TabIndex = 483
        Me.Label15.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 484
        Me.Label2.Text = "Fund Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(92, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 485
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(186, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 13)
        Me.Label4.TabIndex = 486
        Me.Label4.Text = "Total Requested Amount"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(313, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 487
        Me.Label6.Text = ":"
        '
        'dgCharges
        '
        Me.dgCharges.AllowUserToAddRows = False
        Me.dgCharges.AllowUserToDeleteRows = False
        Me.dgCharges.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCharges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.Column1, Me.colGPAType})
        Me.dgCharges.Location = New System.Drawing.Point(4, 376)
        Me.dgCharges.Name = "dgCharges"
        Me.dgCharges.Size = New System.Drawing.Size(654, 218)
        Me.dgCharges.TabIndex = 488
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "PK"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 50
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "Request No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "Charge Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "Book No"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 75
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.HeaderText = "BL No."
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 75
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Container No."
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 75
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn6.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "GPA Type Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'colGPAType
        '
        Me.colGPAType.HeaderText = "GPA Type"
        Me.colGPAType.Name = "colGPAType"
        Me.colGPAType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colGPAType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colGPAType.Width = 150
        '
        'frmPettyCashRelease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 609)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgCharges)
        Me.Controls.Add(Me.txtRequestedAmt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFundKey)
        Me.Controls.Add(Me.txtFundName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboPayee)
        Me.Controls.Add(Me.dtgPCReleaseEntry)
        Me.Controls.Add(Me.cmdPettyCash)
        Me.Controls.Add(Me.cmdAddEntry)
        Me.Controls.Add(Me.cmdRemoveEntry)
        Me.Controls.Add(Me.cmdClearAllEntry)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btRelease)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPettyCashRelease"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Petty Cash Release"
        CType(Me.dtgPCReleaseEntry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRequestedAmt As TextBox
    Friend WithEvents txtFundKey As TextBox
    Friend WithEvents txtFundName As TextBox
    Friend WithEvents cboPayee As ComboBox
    Friend WithEvents dtgPCReleaseEntry As DataGridView
    Friend WithEvents colSelectEntry As DataGridViewButtonColumn
    Friend WithEvents colAcctCode As DataGridViewTextBoxColumn
    Friend WithEvents colAcctTitle As DataGridViewTextBoxColumn
    Friend WithEvents colDR As DataGridViewTextBoxColumn
    Friend WithEvents colCR As DataGridViewTextBoxColumn
    Friend WithEvents colSubCode As DataGridViewTextBoxColumn
    Friend WithEvents colSubAcctTitle As DataGridViewTextBoxColumn
    Friend WithEvents colchkDept As DataGridViewCheckBoxColumn
    Friend WithEvents colDeptName As DataGridViewTextBoxColumn
    Friend WithEvents colchkList As DataGridViewCheckBoxColumn
    Friend WithEvents colListItem As DataGridViewTextBoxColumn
    Friend WithEvents colListItemName As DataGridViewTextBoxColumn
    Friend WithEvents cmdPettyCash As Button
    Friend WithEvents cmdAddEntry As Button
    Friend WithEvents cmdRemoveEntry As Button
    Friend WithEvents cmdClearAllEntry As Button
    Friend WithEvents btClose As Button
    Friend WithEvents btRelease As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dgCharges As DataGridView
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents colGPAType As DataGridViewComboBoxColumn
End Class
