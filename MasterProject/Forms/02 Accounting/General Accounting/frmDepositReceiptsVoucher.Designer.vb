<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepositReceiptsVoucher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepositReceiptsVoucher))
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.btnAR = New System.Windows.Forms.Button()
        Me.dtgAR = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colARNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmtAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgOR = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colORNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmtOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtUpdateDate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUpdateBy = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrepDate = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPrepBy = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDebit = New System.Windows.Forms.Label()
        Me.lblCredit = New System.Windows.Forms.Label()
        Me.dtReceipt = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDateNeeded = New System.Windows.Forms.TextBox()
        Me.btAddBook = New System.Windows.Forms.Button()
        Me.btRemove = New System.Windows.Forms.Button()
        Me.lblDRVNbr = New System.Windows.Forms.Label()
        Me.tstripPreview = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tStripClose = New System.Windows.Forms.ToolStripButton()
        Me.tStripSearch = New System.Windows.Forms.ToolStripButton()
        Me.tStriptxtCKNbr = New System.Windows.Forms.ToolStripTextBox()
        Me.tstripBranch = New System.Windows.Forms.ToolStripLabel()
        Me.dgDetails = New System.Windows.Forms.DataGridView()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnOR = New System.Windows.Forms.Button()
        CType(Me.dtgAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgOR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel1.Text = "Search"
        '
        'btnAR
        '
        Me.btnAR.Enabled = False
        Me.btnAR.Location = New System.Drawing.Point(18, 98)
        Me.btnAR.Name = "btnAR"
        Me.btnAR.Size = New System.Drawing.Size(42, 22)
        Me.btnAR.TabIndex = 480
        Me.btnAR.Text = "..."
        Me.btnAR.UseVisualStyleBackColor = True
        '
        'dtgAR
        '
        Me.dtgAR.AllowUserToAddRows = False
        Me.dtgAR.AllowUserToDeleteRows = False
        Me.dtgAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.colARNo, Me.colAmtAR})
        Me.dtgAR.Location = New System.Drawing.Point(18, 126)
        Me.dtgAR.Name = "dtgAR"
        Me.dtgAR.ReadOnly = True
        Me.dtgAR.Size = New System.Drawing.Size(329, 71)
        Me.dtgAR.TabIndex = 479
        '
        'Column2
        '
        Me.Column2.HeaderText = "..."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 25
        '
        'colARNo
        '
        Me.colARNo.HeaderText = "AR No"
        Me.colARNo.Name = "colARNo"
        Me.colARNo.ReadOnly = True
        Me.colARNo.Width = 150
        '
        'colAmtAR
        '
        Me.colAmtAR.HeaderText = "Amount"
        Me.colAmtAR.Name = "colAmtAR"
        Me.colAmtAR.ReadOnly = True
        '
        'dtgOR
        '
        Me.dtgOR.AllowUserToAddRows = False
        Me.dtgOR.AllowUserToDeleteRows = False
        Me.dtgOR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgOR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.colORNo, Me.colAmtOR})
        Me.dtgOR.Location = New System.Drawing.Point(379, 126)
        Me.dtgOR.Name = "dtgOR"
        Me.dtgOR.ReadOnly = True
        Me.dtgOR.Size = New System.Drawing.Size(330, 71)
        Me.dtgOR.TabIndex = 478
        '
        'Column1
        '
        Me.Column1.HeaderText = "..."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 25
        '
        'colORNo
        '
        Me.colORNo.HeaderText = "OR No."
        Me.colORNo.Name = "colORNo"
        Me.colORNo.ReadOnly = True
        Me.colORNo.Width = 150
        '
        'colAmtOR
        '
        Me.colAmtOR.HeaderText = "Amount"
        Me.colAmtOR.Name = "colAmtOR"
        Me.colAmtOR.ReadOnly = True
        '
        'txtUpdateDate
        '
        Me.txtUpdateDate.BackColor = System.Drawing.Color.White
        Me.txtUpdateDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdateDate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtUpdateDate.Location = New System.Drawing.Point(106, 612)
        Me.txtUpdateDate.Name = "txtUpdateDate"
        Me.txtUpdateDate.ReadOnly = True
        Me.txtUpdateDate.Size = New System.Drawing.Size(232, 21)
        Me.txtUpdateDate.TabIndex = 477
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(18, 612)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 15)
        Me.Label7.TabIndex = 476
        Me.Label7.Text = "Updated Date:"
        '
        'txtUpdateBy
        '
        Me.txtUpdateBy.BackColor = System.Drawing.Color.White
        Me.txtUpdateBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdateBy.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtUpdateBy.Location = New System.Drawing.Point(106, 588)
        Me.txtUpdateBy.Name = "txtUpdateBy"
        Me.txtUpdateBy.ReadOnly = True
        Me.txtUpdateBy.Size = New System.Drawing.Size(232, 21)
        Me.txtUpdateBy.TabIndex = 475
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(18, 588)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 15)
        Me.Label8.TabIndex = 474
        Me.Label8.Text = "Updated By:"
        '
        'txtPrepDate
        '
        Me.txtPrepDate.BackColor = System.Drawing.Color.White
        Me.txtPrepDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrepDate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtPrepDate.Location = New System.Drawing.Point(106, 556)
        Me.txtPrepDate.Name = "txtPrepDate"
        Me.txtPrepDate.ReadOnly = True
        Me.txtPrepDate.Size = New System.Drawing.Size(232, 21)
        Me.txtPrepDate.TabIndex = 473
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(18, 556)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 472
        Me.Label6.Text = "Prepared Date:"
        '
        'txtPrepBy
        '
        Me.txtPrepBy.BackColor = System.Drawing.Color.White
        Me.txtPrepBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrepBy.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtPrepBy.Location = New System.Drawing.Point(106, 532)
        Me.txtPrepBy.Name = "txtPrepBy"
        Me.txtPrepBy.ReadOnly = True
        Me.txtPrepBy.Size = New System.Drawing.Size(232, 21)
        Me.txtPrepBy.TabIndex = 471
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(18, 532)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 470
        Me.Label4.Text = "Prepared By:"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.ForeColor = System.Drawing.Color.Firebrick
        Me.txtRemarks.Location = New System.Drawing.Point(106, 67)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(464, 40)
        Me.txtRemarks.TabIndex = 469
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(10, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 15)
        Me.Label12.TabIndex = 468
        Me.Label12.Text = "Remarks:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(695, 564)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 467
        Me.Label3.Text = "Total Credit:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(695, 540)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 18)
        Me.Label1.TabIndex = 466
        Me.Label1.Text = "Total Debit:"
        '
        'lblDebit
        '
        Me.lblDebit.AutoSize = True
        Me.lblDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebit.Location = New System.Drawing.Point(871, 540)
        Me.lblDebit.Name = "lblDebit"
        Me.lblDebit.Size = New System.Drawing.Size(36, 16)
        Me.lblDebit.TabIndex = 464
        Me.lblDebit.Text = "0.00"
        '
        'lblCredit
        '
        Me.lblCredit.AutoSize = True
        Me.lblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredit.Location = New System.Drawing.Point(871, 564)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Size = New System.Drawing.Size(36, 16)
        Me.lblCredit.TabIndex = 465
        Me.lblCredit.Text = "0.00"
        '
        'dtReceipt
        '
        Me.dtReceipt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtReceipt.Location = New System.Drawing.Point(257, 40)
        Me.dtReceipt.Name = "dtReceipt"
        Me.dtReceipt.Size = New System.Drawing.Size(20, 21)
        Me.dtReceipt.TabIndex = 461
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 15)
        Me.Label5.TabIndex = 463
        Me.Label5.Text = "Transaction Date"
        '
        'txtDateNeeded
        '
        Me.txtDateNeeded.BackColor = System.Drawing.Color.White
        Me.txtDateNeeded.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateNeeded.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtDateNeeded.Location = New System.Drawing.Point(106, 40)
        Me.txtDateNeeded.Name = "txtDateNeeded"
        Me.txtDateNeeded.Size = New System.Drawing.Size(152, 21)
        Me.txtDateNeeded.TabIndex = 462
        '
        'btAddBook
        '
        Me.btAddBook.AccessibleDescription = ""
        Me.btAddBook.AccessibleName = ""
        Me.btAddBook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btAddBook.Image = CType(resources.GetObject("btAddBook.Image"), System.Drawing.Image)
        Me.btAddBook.Location = New System.Drawing.Point(946, 236)
        Me.btAddBook.Name = "btAddBook"
        Me.btAddBook.Size = New System.Drawing.Size(32, 24)
        Me.btAddBook.TabIndex = 457
        Me.btAddBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btAddBook.UseVisualStyleBackColor = True
        '
        'btRemove
        '
        Me.btRemove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btRemove.Image = CType(resources.GetObject("btRemove.Image"), System.Drawing.Image)
        Me.btRemove.Location = New System.Drawing.Point(978, 236)
        Me.btRemove.Name = "btRemove"
        Me.btRemove.Size = New System.Drawing.Size(32, 24)
        Me.btRemove.TabIndex = 458
        Me.btRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btRemove.UseVisualStyleBackColor = True
        '
        'lblDRVNbr
        '
        Me.lblDRVNbr.BackColor = System.Drawing.Color.White
        Me.lblDRVNbr.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDRVNbr.ForeColor = System.Drawing.Color.Chocolate
        Me.lblDRVNbr.Location = New System.Drawing.Point(394, 38)
        Me.lblDRVNbr.Name = "lblDRVNbr"
        Me.lblDRVNbr.Size = New System.Drawing.Size(176, 23)
        Me.lblDRVNbr.TabIndex = 455
        '
        'tstripPreview
        '
        Me.tstripPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tstripPreview.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SummaryToolStripMenuItem, Me.VoucherToolStripMenuItem})
        Me.tstripPreview.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstripPreview.Image = CType(resources.GetObject("tstripPreview.Image"), System.Drawing.Image)
        Me.tstripPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tstripPreview.Name = "tstripPreview"
        Me.tstripPreview.Size = New System.Drawing.Size(69, 22)
        Me.tstripPreview.Text = "Reports"
        '
        'SummaryToolStripMenuItem
        '
        Me.SummaryToolStripMenuItem.Name = "SummaryToolStripMenuItem"
        Me.SummaryToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.SummaryToolStripMenuItem.Text = "Summary"
        '
        'VoucherToolStripMenuItem
        '
        Me.VoucherToolStripMenuItem.Name = "VoucherToolStripMenuItem"
        Me.VoucherToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.VoucherToolStripMenuItem.Text = "Voucher"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 683)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1043, 22)
        Me.StatusStrip1.TabIndex = 460
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstripPreview, Me.ToolStripSeparator4, Me.tStripClose, Me.tStripSearch, Me.tStriptxtCKNbr, Me.tstripBranch, Me.ToolStripSeparator5, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1043, 25)
        Me.ToolStrip1.TabIndex = 459
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tStripClose
        '
        Me.tStripClose.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tStripClose.Image = CType(resources.GetObject("tStripClose.Image"), System.Drawing.Image)
        Me.tStripClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tStripClose.Name = "tStripClose"
        Me.tStripClose.Size = New System.Drawing.Size(62, 22)
        Me.tStripClose.Text = "Close"
        '
        'tStripSearch
        '
        Me.tStripSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tStripSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tStripSearch.Image = CType(resources.GetObject("tStripSearch.Image"), System.Drawing.Image)
        Me.tStripSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tStripSearch.Name = "tStripSearch"
        Me.tStripSearch.Size = New System.Drawing.Size(23, 22)
        Me.tStripSearch.Text = "Begin Search"
        '
        'tStriptxtCKNbr
        '
        Me.tStriptxtCKNbr.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tStriptxtCKNbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tStriptxtCKNbr.Name = "tStriptxtCKNbr"
        Me.tStriptxtCKNbr.Size = New System.Drawing.Size(100, 25)
        '
        'tstripBranch
        '
        Me.tstripBranch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tstripBranch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstripBranch.Name = "tstripBranch"
        Me.tstripBranch.Size = New System.Drawing.Size(0, 22)
        '
        'dgDetails
        '
        Me.dgDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetails.Location = New System.Drawing.Point(18, 222)
        Me.dgDetails.Name = "dgDetails"
        Me.dgDetails.Size = New System.Drawing.Size(992, 278)
        Me.dgDetails.TabIndex = 456
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(330, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 23)
        Me.Label15.TabIndex = 454
        Me.Label15.Text = "DRV#:"
        '
        'btnOR
        '
        Me.btnOR.Enabled = False
        Me.btnOR.Location = New System.Drawing.Point(667, 98)
        Me.btnOR.Name = "btnOR"
        Me.btnOR.Size = New System.Drawing.Size(42, 22)
        Me.btnOR.TabIndex = 481
        Me.btnOR.Text = "..."
        Me.btnOR.UseVisualStyleBackColor = True
        '
        'frmDepositReceiptsVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 705)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAR)
        Me.Controls.Add(Me.dtgAR)
        Me.Controls.Add(Me.txtUpdateDate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtUpdateBy)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPrepDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPrepBy)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDebit)
        Me.Controls.Add(Me.lblCredit)
        Me.Controls.Add(Me.dtReceipt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDateNeeded)
        Me.Controls.Add(Me.btAddBook)
        Me.Controls.Add(Me.btRemove)
        Me.Controls.Add(Me.lblDRVNbr)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgDetails)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnOR)
        Me.Controls.Add(Me.dtgOR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDepositReceiptsVoucher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deposit Receipts Voucher"
        CType(Me.dtgAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgOR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents btnAR As Button
    Friend WithEvents dtgAR As DataGridView
    Friend WithEvents dtgOR As DataGridView
    Friend WithEvents txtUpdateDate As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtUpdateBy As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPrepDate As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPrepBy As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDebit As Label
    Friend WithEvents lblCredit As Label
    Friend WithEvents dtReceipt As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDateNeeded As TextBox
    Friend WithEvents btAddBook As Button
    Friend WithEvents btRemove As Button
    Public WithEvents lblDRVNbr As Label
    Friend WithEvents tstripPreview As ToolStripDropDownButton
    Friend WithEvents SummaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VoucherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tStripClose As ToolStripButton
    Friend WithEvents tStripSearch As ToolStripButton
    Friend WithEvents tStriptxtCKNbr As ToolStripTextBox
    Friend WithEvents tstripBranch As ToolStripLabel
    Friend WithEvents dgDetails As DataGridView
    Public WithEvents Label15 As Label
    Friend WithEvents btnOR As Button
    Friend WithEvents Column2 As DataGridViewCheckBoxColumn
    Friend WithEvents colARNo As DataGridViewTextBoxColumn
    Friend WithEvents colAmtAR As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewCheckBoxColumn
    Friend WithEvents colORNo As DataGridViewTextBoxColumn
    Friend WithEvents colAmtOR As DataGridViewTextBoxColumn
End Class
