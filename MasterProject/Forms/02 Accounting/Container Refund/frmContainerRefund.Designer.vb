<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContainerRefund
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.colPrepBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tStripPost = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tStripNew = New System.Windows.Forms.ToolStripButton()
        Me.tstripReset = New System.Windows.Forms.ToolStripButton()
        Me.tStripSave = New System.Windows.Forms.ToolStripButton()
        Me.tStripPreview = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContainerRefundSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tStripCancel = New System.Windows.Forms.ToolStripButton()
        Me.tStripClose = New System.Windows.Forms.ToolStripButton()
        Me.tStripSearch = New System.Windows.Forms.ToolStripButton()
        Me.tStriptxtCKNbr = New System.Windows.Forms.ToolStripTextBox()
        Me.tstripBranchCode = New System.Windows.Forms.ToolStripLabel()
        Me.tstripBranch = New System.Windows.Forms.ToolStripLabel()
        Me.tscmdReport = New System.Windows.Forms.ToolStripButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtContRefCtrlNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPayeeName = New System.Windows.Forms.TextBox()
        Me.txtPayeeCode = New System.Windows.Forms.TextBox()
        Me.colARDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.colOtherCharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtAmtInWords = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtORNbr = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtShipAddress = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtBillAmt = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBillAmtInWords = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dtgAllAR = New System.Windows.Forms.DataGridView()
        Me.colARNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colARAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colORCsh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colORChkAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetentionAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtRequestNbr = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dtgAllAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colPrepBy
        '
        Me.colPrepBy.HeaderText = "Prepared By"
        Me.colPrepBy.Name = "colPrepBy"
        Me.colPrepBy.ReadOnly = True
        Me.colPrepBy.Width = 150
        '
        'tStripPost
        '
        Me.tStripPost.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tStripPost.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tStripPost.Name = "tStripPost"
        Me.tStripPost.Size = New System.Drawing.Size(34, 22)
        Me.tStripPost.Text = "Post"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tStripNew, Me.tstripReset, Me.tStripSave, Me.tStripPreview, Me.ToolStripSeparator3, Me.tStripPost, Me.tStripCancel, Me.ToolStripSeparator4, Me.tStripClose, Me.tStripSearch, Me.tStriptxtCKNbr, Me.tstripBranchCode, Me.tstripBranch, Me.tscmdReport})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(863, 25)
        Me.ToolStrip1.TabIndex = 446
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tStripNew
        '
        Me.tStripNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tStripNew.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tStripNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tStripNew.Name = "tStripNew"
        Me.tStripNew.Size = New System.Drawing.Size(35, 22)
        Me.tStripNew.Text = "New"
        Me.tStripNew.ToolTipText = "New Check Request"
        '
        'tstripReset
        '
        Me.tstripReset.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstripReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tstripReset.Name = "tstripReset"
        Me.tstripReset.Size = New System.Drawing.Size(39, 22)
        Me.tstripReset.Text = "Reset"
        '
        'tStripSave
        '
        Me.tStripSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tStripSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tStripSave.Name = "tStripSave"
        Me.tStripSave.Size = New System.Drawing.Size(35, 22)
        Me.tStripSave.Text = "Save"
        '
        'tStripPreview
        '
        Me.tStripPreview.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4, Me.ContainerRefundSummaryToolStripMenuItem})
        Me.tStripPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tStripPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tStripPreview.Name = "tStripPreview"
        Me.tStripPreview.Size = New System.Drawing.Size(63, 22)
        Me.tStripPreview.Text = "Reports"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem4.Text = "Preview Letter for Refund"
        '
        'ContainerRefundSummaryToolStripMenuItem
        '
        Me.ContainerRefundSummaryToolStripMenuItem.Name = "ContainerRefundSummaryToolStripMenuItem"
        Me.ContainerRefundSummaryToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ContainerRefundSummaryToolStripMenuItem.Text = "Container Refund Summary"
        '
        'tStripCancel
        '
        Me.tStripCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tStripCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tStripCancel.Name = "tStripCancel"
        Me.tStripCancel.Size = New System.Drawing.Size(47, 22)
        Me.tStripCancel.Text = "Cancel"
        '
        'tStripClose
        '
        Me.tStripClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tStripClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tStripClose.Name = "tStripClose"
        Me.tStripClose.Size = New System.Drawing.Size(40, 22)
        Me.tStripClose.Text = "Close"
        '
        'tStripSearch
        '
        Me.tStripSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tStripSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
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
        'tstripBranchCode
        '
        Me.tstripBranchCode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tstripBranchCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstripBranchCode.Name = "tstripBranchCode"
        Me.tstripBranchCode.Size = New System.Drawing.Size(0, 22)
        '
        'tstripBranch
        '
        Me.tstripBranch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tstripBranch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstripBranch.Name = "tstripBranch"
        Me.tstripBranch.Size = New System.Drawing.Size(0, 22)
        '
        'tscmdReport
        '
        Me.tscmdReport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tscmdReport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscmdReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdReport.Name = "tscmdReport"
        Me.tscmdReport.Size = New System.Drawing.Size(46, 22)
        Me.tscmdReport.Text = "Report"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(602, 99)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 471
        Me.Label16.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(602, 76)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 13)
        Me.Label15.TabIndex = 470
        Me.Label15.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(602, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 469
        Me.Label11.Text = ":"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(471, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 13)
        Me.Label12.TabIndex = 467
        Me.Label12.Text = "Container Refund Ctrl. No."
        '
        'txtContRefCtrlNo
        '
        Me.txtContRefCtrlNo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtContRefCtrlNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContRefCtrlNo.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtContRefCtrlNo.Location = New System.Drawing.Point(613, 52)
        Me.txtContRefCtrlNo.Name = "txtContRefCtrlNo"
        Me.txtContRefCtrlNo.ReadOnly = True
        Me.txtContRefCtrlNo.Size = New System.Drawing.Size(236, 21)
        Me.txtContRefCtrlNo.TabIndex = 468
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(79, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 466
        Me.Label6.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(79, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 465
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 448
        Me.Label1.Text = "Shipping Line"
        '
        'txtPayeeName
        '
        Me.txtPayeeName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPayeeName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayeeName.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtPayeeName.Location = New System.Drawing.Point(91, 52)
        Me.txtPayeeName.Name = "txtPayeeName"
        Me.txtPayeeName.ReadOnly = True
        Me.txtPayeeName.Size = New System.Drawing.Size(369, 21)
        Me.txtPayeeName.TabIndex = 449
        '
        'txtPayeeCode
        '
        Me.txtPayeeCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPayeeCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayeeCode.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtPayeeCode.Location = New System.Drawing.Point(94, 52)
        Me.txtPayeeCode.Name = "txtPayeeCode"
        Me.txtPayeeCode.ReadOnly = True
        Me.txtPayeeCode.Size = New System.Drawing.Size(62, 21)
        Me.txtPayeeCode.TabIndex = 447
        '
        'colARDate
        '
        Me.colARDate.HeaderText = "A.R. Date"
        Me.colARDate.Name = "colARDate"
        Me.colARDate.ReadOnly = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(677, 132)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 472
        Me.Label18.Text = "Status"
        '
        'colOtherCharge
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colOtherCharge.DefaultCellStyle = DataGridViewCellStyle7
        Me.colOtherCharge.HeaderText = "Other Charge"
        Me.colOtherCharge.Name = "colOtherCharge"
        Me.colOtherCharge.ReadOnly = True
        '
        'txtAmtInWords
        '
        Me.txtAmtInWords.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAmtInWords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmtInWords.Location = New System.Drawing.Point(596, 138)
        Me.txtAmtInWords.Multiline = True
        Me.txtAmtInWords.Name = "txtAmtInWords"
        Me.txtAmtInWords.ReadOnly = True
        Me.txtAmtInWords.Size = New System.Drawing.Size(224, 40)
        Me.txtAmtInWords.TabIndex = 392
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(742, 127)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(19, 20)
        Me.lblStatus.TabIndex = 462
        Me.lblStatus.Text = ".."
        '
        'txtORNbr
        '
        Me.txtORNbr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtORNbr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORNbr.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtORNbr.Location = New System.Drawing.Point(613, 94)
        Me.txtORNbr.Name = "txtORNbr"
        Me.txtORNbr.ReadOnly = True
        Me.txtORNbr.Size = New System.Drawing.Size(236, 21)
        Me.txtORNbr.TabIndex = 461
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(557, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 460
        Me.Label9.Text = "O.R No."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(496, 144)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(95, 15)
        Me.Label14.TabIndex = 391
        Me.Label14.Text = "Amount in Words:"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(813, 160)
        Me.DataGridView1.TabIndex = 2
        '
        'txtShipAddress
        '
        Me.txtShipAddress.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtShipAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipAddress.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtShipAddress.Location = New System.Drawing.Point(91, 73)
        Me.txtShipAddress.Multiline = True
        Me.txtShipAddress.Name = "txtShipAddress"
        Me.txtShipAddress.ReadOnly = True
        Me.txtShipAddress.Size = New System.Drawing.Size(369, 69)
        Me.txtShipAddress.TabIndex = 464
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(31, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 463
        Me.Label10.Text = "Address:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(496, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 15)
        Me.Label13.TabIndex = 389
        Me.Label13.Text = "Total Amount:"
        '
        'txtBillAmt
        '
        Me.txtBillAmt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtBillAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillAmt.Location = New System.Drawing.Point(112, 366)
        Me.txtBillAmt.Name = "txtBillAmt"
        Me.txtBillAmt.ReadOnly = True
        Me.txtBillAmt.Size = New System.Drawing.Size(223, 20)
        Me.txtBillAmt.TabIndex = 457
        Me.txtBillAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridView2
        '
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(11, 16)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(805, 88)
        Me.DataGridView2.TabIndex = 204
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.Location = New System.Drawing.Point(596, 114)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(223, 20)
        Me.txtGrandTotal.TabIndex = 390
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(721, 132)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 13)
        Me.Label17.TabIndex = 473
        Me.Label17.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(13, 367)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 456
        Me.Label7.Text = "For Collection :"
        '
        'txtBillAmtInWords
        '
        Me.txtBillAmtInWords.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtBillAmtInWords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillAmtInWords.Location = New System.Drawing.Point(112, 386)
        Me.txtBillAmtInWords.Multiline = True
        Me.txtBillAmtInWords.Name = "txtBillAmtInWords"
        Me.txtBillAmtInWords.ReadOnly = True
        Me.txtBillAmtInWords.Size = New System.Drawing.Size(224, 70)
        Me.txtBillAmtInWords.TabIndex = 459
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(13, 389)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 458
        Me.Label8.Text = "Amount in Words:"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(832, 190)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Particulars "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(540, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 454
        Me.Label4.Text = "Request No."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 471)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(863, 22)
        Me.StatusStrip1.TabIndex = 453
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.ForeColor = System.Drawing.Color.Firebrick
        Me.txtRemarks.Location = New System.Drawing.Point(447, 367)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(400, 89)
        Me.txtRemarks.TabIndex = 452
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(380, 367)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 451
        Me.Label3.Text = "Remarks:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 148)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(840, 216)
        Me.TabControl1.TabIndex = 450
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Controls.Add(Me.txtGrandTotal)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.txtAmtInWords)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(832, 190)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Bookings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dtgAllAR)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(832, 190)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Collection Info"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dtgAllAR
        '
        Me.dtgAllAR.AllowUserToAddRows = False
        Me.dtgAllAR.AllowUserToDeleteRows = False
        Me.dtgAllAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAllAR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colARNo, Me.colARAmt, Me.colORCsh, Me.colORChkAmt, Me.colDetentionAmt, Me.colOtherCharge, Me.colPrepBy, Me.colARDate})
        Me.dtgAllAR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgAllAR.Location = New System.Drawing.Point(0, 0)
        Me.dtgAllAR.Name = "dtgAllAR"
        Me.dtgAllAR.ReadOnly = True
        Me.dtgAllAR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAllAR.Size = New System.Drawing.Size(832, 190)
        Me.dtgAllAR.TabIndex = 1
        '
        'colARNo
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colARNo.DefaultCellStyle = DataGridViewCellStyle8
        Me.colARNo.Frozen = True
        Me.colARNo.HeaderText = "A.R. No."
        Me.colARNo.Name = "colARNo"
        Me.colARNo.ReadOnly = True
        '
        'colARAmt
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colARAmt.DefaultCellStyle = DataGridViewCellStyle9
        Me.colARAmt.HeaderText = "A.R. Amt"
        Me.colARAmt.Name = "colARAmt"
        Me.colARAmt.ReadOnly = True
        '
        'colORCsh
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colORCsh.DefaultCellStyle = DataGridViewCellStyle10
        Me.colORCsh.HeaderText = "Cash Amt"
        Me.colORCsh.Name = "colORCsh"
        Me.colORCsh.ReadOnly = True
        '
        'colORChkAmt
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colORChkAmt.DefaultCellStyle = DataGridViewCellStyle11
        Me.colORChkAmt.HeaderText = "Check Amt"
        Me.colORChkAmt.Name = "colORChkAmt"
        Me.colORChkAmt.ReadOnly = True
        '
        'colDetentionAmt
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colDetentionAmt.DefaultCellStyle = DataGridViewCellStyle12
        Me.colDetentionAmt.HeaderText = "Detention Amt"
        Me.colDetentionAmt.Name = "colDetentionAmt"
        Me.colDetentionAmt.ReadOnly = True
        '
        'txtRequestNbr
        '
        Me.txtRequestNbr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRequestNbr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestNbr.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtRequestNbr.Location = New System.Drawing.Point(613, 73)
        Me.txtRequestNbr.Name = "txtRequestNbr"
        Me.txtRequestNbr.ReadOnly = True
        Me.txtRequestNbr.Size = New System.Drawing.Size(236, 21)
        Me.txtRequestNbr.TabIndex = 455
        '
        'frmContainerRefund
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 493)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtContRefCtrlNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPayeeName)
        Me.Controls.Add(Me.txtPayeeCode)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtORNbr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtShipAddress)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtBillAmt)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtBillAmtInWords)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtRequestNbr)
        Me.Name = "frmContainerRefund"
        Me.Text = "frmContainerRefund"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dtgAllAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents colPrepBy As DataGridViewTextBoxColumn
    Friend WithEvents tStripPost As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tStripNew As ToolStripButton
    Friend WithEvents tstripReset As ToolStripButton
    Friend WithEvents tStripSave As ToolStripButton
    Friend WithEvents tStripPreview As ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ContainerRefundSummaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tStripCancel As ToolStripButton
    Friend WithEvents tStripClose As ToolStripButton
    Friend WithEvents tStripSearch As ToolStripButton
    Friend WithEvents tStriptxtCKNbr As ToolStripTextBox
    Friend WithEvents tstripBranchCode As ToolStripLabel
    Friend WithEvents tstripBranch As ToolStripLabel
    Friend WithEvents tscmdReport As ToolStripButton
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtContRefCtrlNo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPayeeName As TextBox
    Friend WithEvents txtPayeeCode As TextBox
    Friend WithEvents colARDate As DataGridViewTextBoxColumn
    Friend WithEvents Label18 As Label
    Friend WithEvents colOtherCharge As DataGridViewTextBoxColumn
    Friend WithEvents txtAmtInWords As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtORNbr As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtShipAddress As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtBillAmt As TextBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents txtGrandTotal As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtBillAmtInWords As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dtgAllAR As DataGridView
    Friend WithEvents colARNo As DataGridViewTextBoxColumn
    Friend WithEvents colARAmt As DataGridViewTextBoxColumn
    Friend WithEvents colORCsh As DataGridViewTextBoxColumn
    Friend WithEvents colORChkAmt As DataGridViewTextBoxColumn
    Friend WithEvents colDetentionAmt As DataGridViewTextBoxColumn
    Friend WithEvents txtRequestNbr As TextBox
End Class
