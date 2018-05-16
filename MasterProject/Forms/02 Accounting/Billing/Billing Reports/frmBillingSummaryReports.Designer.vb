<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillingSummaryReports
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdPrevCI = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtgBillingMonitoring = New System.Windows.Forms.DataGridView()
        Me.colBookNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCINo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSOA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrepDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBilledTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHBL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDestination = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTerms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCIAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSOAAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVATAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gpLegend = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.chkCancelled = New System.Windows.Forms.CheckBox()
        Me.chkOpen = New System.Windows.Forms.CheckBox()
        Me.chkPosted = New System.Windows.Forms.CheckBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtToMon = New System.Windows.Forms.DateTimePicker()
        Me.dtFromMon = New System.Windows.Forms.DateTimePicker()
        Me.tbpBillingSummary = New System.Windows.Forms.TabPage()
        Me.crSummary = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.cmdPrevSummary = New System.Windows.Forms.Button()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtToSummary = New System.Windows.Forms.DateTimePicker()
        Me.dtFromSummary = New System.Windows.Forms.DateTimePicker()
        Me.tbpShipper = New System.Windows.Forms.TabPage()
        Me.crShipper = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdPrevShipper = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkShipperNameAll = New System.Windows.Forms.CheckBox()
        Me.cboShipperName = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtToShipper = New System.Windows.Forms.DateTimePicker()
        Me.dtFromShipper = New System.Windows.Forms.DateTimePicker()
        Me.tbpAcctHolder = New System.Windows.Forms.TabPage()
        Me.crAcctHolder = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.PanelAcctHolder = New System.Windows.Forms.Panel()
        Me.cmdPrevAcctHolder = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkAcctHolderNameAll = New System.Windows.Forms.CheckBox()
        Me.cboAcctHolderName = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtToAcctHolder = New System.Windows.Forms.DateTimePicker()
        Me.dtFromAcctHolder = New System.Windows.Forms.DateTimePicker()
        Me.tbpCI = New System.Windows.Forms.TabPage()
        Me.crCI = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkCINoAll = New System.Windows.Forms.CheckBox()
        Me.cboCINo = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtToCI = New System.Windows.Forms.DateTimePicker()
        Me.dtFromCI = New System.Windows.Forms.DateTimePicker()
        Me.tbpSOA = New System.Windows.Forms.TabPage()
        Me.crSOA = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmdPrevSOA = New System.Windows.Forms.Button()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.chkSOANoAll = New System.Windows.Forms.CheckBox()
        Me.cboSOANo = New System.Windows.Forms.ComboBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtToSOA = New System.Windows.Forms.DateTimePicker()
        Me.dtFromSOA = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DateTimePicker5 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker6 = New System.Windows.Forms.DateTimePicker()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtgBillingMonitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.gpLegend.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.tbpBillingSummary.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.tbpShipper.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbpAcctHolder.SuspendLayout()
        Me.PanelAcctHolder.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tbpCI.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.tbpSOA.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPrevCI
        '
        Me.cmdPrevCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevCI.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdPrevCI.Location = New System.Drawing.Point(507, 16)
        Me.cmdPrevCI.Name = "cmdPrevCI"
        Me.cmdPrevCI.Size = New System.Drawing.Size(75, 52)
        Me.cmdPrevCI.TabIndex = 431
        Me.cmdPrevCI.Text = "Preview"
        Me.cmdPrevCI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdPrevCI.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.tbpBillingSummary)
        Me.TabControl1.Controls.Add(Me.tbpShipper)
        Me.TabControl1.Controls.Add(Me.tbpAcctHolder)
        Me.TabControl1.Controls.Add(Me.tbpCI)
        Me.TabControl1.Controls.Add(Me.tbpSOA)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 72)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(915, 455)
        Me.TabControl1.TabIndex = 433
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtgBillingMonitoring)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(907, 429)
        Me.TabPage1.TabIndex = 5
        Me.TabPage1.Text = "Billing Monitoring"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtgBillingMonitoring
        '
        Me.dtgBillingMonitoring.AllowUserToAddRows = False
        Me.dtgBillingMonitoring.AllowUserToDeleteRows = False
        Me.dtgBillingMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgBillingMonitoring.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBookNo, Me.colRefNo, Me.colCINo, Me.colSOA, Me.colPrepDate, Me.colBilledTo, Me.colHBL, Me.colDestination, Me.colTerms, Me.colCIAmt, Me.colSOAAmt, Me.colVATAmt, Me.colTotal, Me.colStatus})
        Me.dtgBillingMonitoring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgBillingMonitoring.Location = New System.Drawing.Point(3, 88)
        Me.dtgBillingMonitoring.Name = "dtgBillingMonitoring"
        Me.dtgBillingMonitoring.ReadOnly = True
        Me.dtgBillingMonitoring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgBillingMonitoring.Size = New System.Drawing.Size(901, 338)
        Me.dtgBillingMonitoring.TabIndex = 5
        '
        'colBookNo
        '
        Me.colBookNo.Frozen = True
        Me.colBookNo.HeaderText = "Booking No."
        Me.colBookNo.Name = "colBookNo"
        Me.colBookNo.ReadOnly = True
        Me.colBookNo.Width = 125
        '
        'colRefNo
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colRefNo.DefaultCellStyle = DataGridViewCellStyle1
        Me.colRefNo.Frozen = True
        Me.colRefNo.HeaderText = "Ref. No."
        Me.colRefNo.Name = "colRefNo"
        Me.colRefNo.ReadOnly = True
        Me.colRefNo.Width = 150
        '
        'colCINo
        '
        Me.colCINo.Frozen = True
        Me.colCINo.HeaderText = "C.I."
        Me.colCINo.Name = "colCINo"
        Me.colCINo.ReadOnly = True
        Me.colCINo.Width = 75
        '
        'colSOA
        '
        Me.colSOA.Frozen = True
        Me.colSOA.HeaderText = "S.O.A."
        Me.colSOA.Name = "colSOA"
        Me.colSOA.ReadOnly = True
        Me.colSOA.Width = 75
        '
        'colPrepDate
        '
        Me.colPrepDate.Frozen = True
        Me.colPrepDate.HeaderText = "Prepared Date"
        Me.colPrepDate.Name = "colPrepDate"
        Me.colPrepDate.ReadOnly = True
        Me.colPrepDate.Width = 150
        '
        'colBilledTo
        '
        Me.colBilledTo.HeaderText = "Billed To/Shipper"
        Me.colBilledTo.Name = "colBilledTo"
        Me.colBilledTo.ReadOnly = True
        Me.colBilledTo.Width = 300
        '
        'colHBL
        '
        Me.colHBL.HeaderText = "HBL"
        Me.colHBL.Name = "colHBL"
        Me.colHBL.ReadOnly = True
        Me.colHBL.Width = 150
        '
        'colDestination
        '
        Me.colDestination.HeaderText = "Destination"
        Me.colDestination.Name = "colDestination"
        Me.colDestination.ReadOnly = True
        Me.colDestination.Width = 150
        '
        'colTerms
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTerms.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTerms.HeaderText = "Terms"
        Me.colTerms.Name = "colTerms"
        Me.colTerms.ReadOnly = True
        Me.colTerms.Width = 75
        '
        'colCIAmt
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCIAmt.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCIAmt.HeaderText = "C.I. Amt."
        Me.colCIAmt.Name = "colCIAmt"
        Me.colCIAmt.ReadOnly = True
        '
        'colSOAAmt
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colSOAAmt.DefaultCellStyle = DataGridViewCellStyle4
        Me.colSOAAmt.HeaderText = "S.O.A. Amt."
        Me.colSOAAmt.Name = "colSOAAmt"
        Me.colSOAAmt.ReadOnly = True
        '
        'colVATAmt
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colVATAmt.DefaultCellStyle = DataGridViewCellStyle5
        Me.colVATAmt.HeaderText = "VAT Amt."
        Me.colVATAmt.Name = "colVATAmt"
        Me.colVATAmt.ReadOnly = True
        '
        'colTotal
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colTotal.DefaultCellStyle = DataGridViewCellStyle6
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        Me.colStatus.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.gpLegend)
        Me.Panel2.Controls.Add(Me.GroupBox16)
        Me.Panel2.Controls.Add(Me.GroupBox15)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(901, 85)
        Me.Panel2.TabIndex = 4
        '
        'gpLegend
        '
        Me.gpLegend.Controls.Add(Me.Label26)
        Me.gpLegend.Controls.Add(Me.Label25)
        Me.gpLegend.Controls.Add(Me.Label23)
        Me.gpLegend.Controls.Add(Me.Label24)
        Me.gpLegend.Controls.Add(Me.Label21)
        Me.gpLegend.Controls.Add(Me.Label22)
        Me.gpLegend.Controls.Add(Me.Label20)
        Me.gpLegend.Controls.Add(Me.Label19)
        Me.gpLegend.Location = New System.Drawing.Point(490, 3)
        Me.gpLegend.Name = "gpLegend"
        Me.gpLegend.Size = New System.Drawing.Size(201, 73)
        Me.gpLegend.TabIndex = 433
        Me.gpLegend.TabStop = False
        Me.gpLegend.Text = "Legend"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(128, 47)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 13)
        Me.Label26.TabIndex = 7
        Me.Label26.Text = "Unbilled"
        Me.Label26.Visible = False
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Yellow
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Location = New System.Drawing.Point(108, 46)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(14, 13)
        Me.Label25.TabIndex = 6
        Me.Label25.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(128, 23)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(63, 13)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Cancelled"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.IndianRed
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.Location = New System.Drawing.Point(108, 23)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(14, 13)
        Me.Label24.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(40, 46)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(37, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Open"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.LightGreen
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Location = New System.Drawing.Point(20, 46)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(14, 13)
        Me.Label22.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(40, 23)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Posted"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Location = New System.Drawing.Point(20, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(14, 13)
        Me.Label19.TabIndex = 0
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.chkAll)
        Me.GroupBox16.Controls.Add(Me.chkCancelled)
        Me.GroupBox16.Controls.Add(Me.chkOpen)
        Me.GroupBox16.Controls.Add(Me.chkPosted)
        Me.GroupBox16.Location = New System.Drawing.Point(279, 3)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(205, 73)
        Me.GroupBox16.TabIndex = 5
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Status"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.ForeColor = System.Drawing.Color.Black
        Me.chkAll.Location = New System.Drawing.Point(15, 19)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(40, 17)
        Me.chkAll.TabIndex = 3
        Me.chkAll.Text = "All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'chkCancelled
        '
        Me.chkCancelled.AutoSize = True
        Me.chkCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCancelled.ForeColor = System.Drawing.Color.Red
        Me.chkCancelled.Location = New System.Drawing.Point(111, 42)
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.Size = New System.Drawing.Size(82, 17)
        Me.chkCancelled.TabIndex = 2
        Me.chkCancelled.Text = "Cancelled"
        Me.chkCancelled.UseVisualStyleBackColor = True
        '
        'chkOpen
        '
        Me.chkOpen.AutoSize = True
        Me.chkOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOpen.ForeColor = System.Drawing.Color.Green
        Me.chkOpen.Location = New System.Drawing.Point(111, 19)
        Me.chkOpen.Name = "chkOpen"
        Me.chkOpen.Size = New System.Drawing.Size(56, 17)
        Me.chkOpen.TabIndex = 1
        Me.chkOpen.Text = "Open"
        Me.chkOpen.UseVisualStyleBackColor = True
        '
        'chkPosted
        '
        Me.chkPosted.AutoSize = True
        Me.chkPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPosted.ForeColor = System.Drawing.Color.Blue
        Me.chkPosted.Location = New System.Drawing.Point(15, 42)
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.Size = New System.Drawing.Size(65, 17)
        Me.chkPosted.TabIndex = 0
        Me.chkPosted.Text = "Posted"
        Me.chkPosted.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.Label17)
        Me.GroupBox15.Controls.Add(Me.Label18)
        Me.GroupBox15.Controls.Add(Me.dtToMon)
        Me.GroupBox15.Controls.Add(Me.dtFromMon)
        Me.GroupBox15.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(268, 73)
        Me.GroupBox15.TabIndex = 428
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Period Covered"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Location = New System.Drawing.Point(16, 49)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 13)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "To : "
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.Location = New System.Drawing.Point(4, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "From : "
        '
        'dtToMon
        '
        Me.dtToMon.Location = New System.Drawing.Point(56, 45)
        Me.dtToMon.Name = "dtToMon"
        Me.dtToMon.Size = New System.Drawing.Size(200, 20)
        Me.dtToMon.TabIndex = 1
        '
        'dtFromMon
        '
        Me.dtFromMon.Location = New System.Drawing.Point(56, 19)
        Me.dtFromMon.Name = "dtFromMon"
        Me.dtFromMon.Size = New System.Drawing.Size(200, 20)
        Me.dtFromMon.TabIndex = 0
        '
        'tbpBillingSummary
        '
        Me.tbpBillingSummary.Controls.Add(Me.crSummary)
        Me.tbpBillingSummary.Controls.Add(Me.Panel5)
        Me.tbpBillingSummary.Location = New System.Drawing.Point(4, 22)
        Me.tbpBillingSummary.Name = "tbpBillingSummary"
        Me.tbpBillingSummary.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpBillingSummary.Size = New System.Drawing.Size(907, 429)
        Me.tbpBillingSummary.TabIndex = 4
        Me.tbpBillingSummary.Text = "Billing Summary"
        Me.tbpBillingSummary.UseVisualStyleBackColor = True
        '
        'crSummary
        '
        Me.crSummary.ActiveViewIndex = -1
        Me.crSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crSummary.Cursor = System.Windows.Forms.Cursors.Default
        Me.crSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crSummary.Location = New System.Drawing.Point(3, 88)
        Me.crSummary.Name = "crSummary"
        Me.crSummary.SelectionFormula = ""
        Me.crSummary.Size = New System.Drawing.Size(901, 338)
        Me.crSummary.TabIndex = 430
        Me.crSummary.ViewTimeSelectionFormula = ""
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.cmdPrevSummary)
        Me.Panel5.Controls.Add(Me.GroupBox14)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(901, 85)
        Me.Panel5.TabIndex = 3
        '
        'cmdPrevSummary
        '
        Me.cmdPrevSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevSummary.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdPrevSummary.Location = New System.Drawing.Point(279, 16)
        Me.cmdPrevSummary.Name = "cmdPrevSummary"
        Me.cmdPrevSummary.Size = New System.Drawing.Size(75, 52)
        Me.cmdPrevSummary.TabIndex = 431
        Me.cmdPrevSummary.Text = "Preview"
        Me.cmdPrevSummary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdPrevSummary.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.Label13)
        Me.GroupBox14.Controls.Add(Me.Label14)
        Me.GroupBox14.Controls.Add(Me.dtToSummary)
        Me.GroupBox14.Controls.Add(Me.dtFromSummary)
        Me.GroupBox14.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(268, 73)
        Me.GroupBox14.TabIndex = 428
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Period Covered"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Location = New System.Drawing.Point(14, 49)
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
        'dtToSummary
        '
        Me.dtToSummary.Location = New System.Drawing.Point(56, 45)
        Me.dtToSummary.Name = "dtToSummary"
        Me.dtToSummary.Size = New System.Drawing.Size(200, 20)
        Me.dtToSummary.TabIndex = 1
        '
        'dtFromSummary
        '
        Me.dtFromSummary.Location = New System.Drawing.Point(56, 19)
        Me.dtFromSummary.Name = "dtFromSummary"
        Me.dtFromSummary.Size = New System.Drawing.Size(200, 20)
        Me.dtFromSummary.TabIndex = 0
        '
        'tbpShipper
        '
        Me.tbpShipper.Controls.Add(Me.crShipper)
        Me.tbpShipper.Controls.Add(Me.Panel1)
        Me.tbpShipper.Location = New System.Drawing.Point(4, 22)
        Me.tbpShipper.Name = "tbpShipper"
        Me.tbpShipper.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpShipper.Size = New System.Drawing.Size(907, 429)
        Me.tbpShipper.TabIndex = 0
        Me.tbpShipper.Text = "By Client/Shipper"
        Me.tbpShipper.UseVisualStyleBackColor = True
        '
        'crShipper
        '
        Me.crShipper.ActiveViewIndex = -1
        Me.crShipper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crShipper.Cursor = System.Windows.Forms.Cursors.Default
        Me.crShipper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crShipper.Location = New System.Drawing.Point(3, 88)
        Me.crShipper.Name = "crShipper"
        Me.crShipper.SelectionFormula = ""
        Me.crShipper.Size = New System.Drawing.Size(901, 338)
        Me.crShipper.TabIndex = 426
        Me.crShipper.ViewTimeSelectionFormula = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdPrevShipper)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(901, 85)
        Me.Panel1.TabIndex = 425
        '
        'cmdPrevShipper
        '
        Me.cmdPrevShipper.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevShipper.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdPrevShipper.Location = New System.Drawing.Point(563, 16)
        Me.cmdPrevShipper.Name = "cmdPrevShipper"
        Me.cmdPrevShipper.Size = New System.Drawing.Size(75, 52)
        Me.cmdPrevShipper.TabIndex = 429
        Me.cmdPrevShipper.Text = "Preview"
        Me.cmdPrevShipper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdPrevShipper.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkShipperNameAll)
        Me.GroupBox2.Controls.Add(Me.cboShipperName)
        Me.GroupBox2.Location = New System.Drawing.Point(279, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 73)
        Me.GroupBox2.TabIndex = 428
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Shipper/Client"
        '
        'chkShipperNameAll
        '
        Me.chkShipperNameAll.AutoSize = True
        Me.chkShipperNameAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShipperNameAll.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkShipperNameAll.Location = New System.Drawing.Point(6, 45)
        Me.chkShipperNameAll.Name = "chkShipperNameAll"
        Me.chkShipperNameAll.Size = New System.Drawing.Size(40, 17)
        Me.chkShipperNameAll.TabIndex = 1
        Me.chkShipperNameAll.Text = "All"
        Me.chkShipperNameAll.UseVisualStyleBackColor = True
        '
        'cboShipperName
        '
        Me.cboShipperName.FormattingEnabled = True
        Me.cboShipperName.Location = New System.Drawing.Point(6, 19)
        Me.cboShipperName.Name = "cboShipperName"
        Me.cboShipperName.Size = New System.Drawing.Size(266, 21)
        Me.cboShipperName.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtToShipper)
        Me.GroupBox1.Controls.Add(Me.dtFromShipper)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 73)
        Me.GroupBox1.TabIndex = 427
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Period Covered"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(14, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(4, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From : "
        '
        'dtToShipper
        '
        Me.dtToShipper.Location = New System.Drawing.Point(56, 45)
        Me.dtToShipper.Name = "dtToShipper"
        Me.dtToShipper.Size = New System.Drawing.Size(200, 20)
        Me.dtToShipper.TabIndex = 1
        '
        'dtFromShipper
        '
        Me.dtFromShipper.Location = New System.Drawing.Point(56, 19)
        Me.dtFromShipper.Name = "dtFromShipper"
        Me.dtFromShipper.Size = New System.Drawing.Size(200, 20)
        Me.dtFromShipper.TabIndex = 0
        '
        'tbpAcctHolder
        '
        Me.tbpAcctHolder.Controls.Add(Me.crAcctHolder)
        Me.tbpAcctHolder.Controls.Add(Me.PanelAcctHolder)
        Me.tbpAcctHolder.Location = New System.Drawing.Point(4, 22)
        Me.tbpAcctHolder.Name = "tbpAcctHolder"
        Me.tbpAcctHolder.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAcctHolder.Size = New System.Drawing.Size(907, 429)
        Me.tbpAcctHolder.TabIndex = 1
        Me.tbpAcctHolder.Text = "By Account Holder"
        Me.tbpAcctHolder.UseVisualStyleBackColor = True
        '
        'crAcctHolder
        '
        Me.crAcctHolder.ActiveViewIndex = -1
        Me.crAcctHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crAcctHolder.Cursor = System.Windows.Forms.Cursors.Default
        Me.crAcctHolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crAcctHolder.Location = New System.Drawing.Point(3, 88)
        Me.crAcctHolder.Name = "crAcctHolder"
        Me.crAcctHolder.SelectionFormula = ""
        Me.crAcctHolder.Size = New System.Drawing.Size(901, 338)
        Me.crAcctHolder.TabIndex = 427
        Me.crAcctHolder.ViewTimeSelectionFormula = ""
        '
        'PanelAcctHolder
        '
        Me.PanelAcctHolder.Controls.Add(Me.cmdPrevAcctHolder)
        Me.PanelAcctHolder.Controls.Add(Me.GroupBox4)
        Me.PanelAcctHolder.Controls.Add(Me.GroupBox3)
        Me.PanelAcctHolder.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelAcctHolder.Location = New System.Drawing.Point(3, 3)
        Me.PanelAcctHolder.Name = "PanelAcctHolder"
        Me.PanelAcctHolder.Size = New System.Drawing.Size(901, 85)
        Me.PanelAcctHolder.TabIndex = 0
        '
        'cmdPrevAcctHolder
        '
        Me.cmdPrevAcctHolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevAcctHolder.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdPrevAcctHolder.Location = New System.Drawing.Point(507, 16)
        Me.cmdPrevAcctHolder.Name = "cmdPrevAcctHolder"
        Me.cmdPrevAcctHolder.Size = New System.Drawing.Size(75, 52)
        Me.cmdPrevAcctHolder.TabIndex = 431
        Me.cmdPrevAcctHolder.Text = "Preview"
        Me.cmdPrevAcctHolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdPrevAcctHolder.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkAcctHolderNameAll)
        Me.GroupBox4.Controls.Add(Me.cboAcctHolderName)
        Me.GroupBox4.Location = New System.Drawing.Point(279, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(222, 73)
        Me.GroupBox4.TabIndex = 429
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Account Holder"
        '
        'chkAcctHolderNameAll
        '
        Me.chkAcctHolderNameAll.AutoSize = True
        Me.chkAcctHolderNameAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAcctHolderNameAll.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkAcctHolderNameAll.Location = New System.Drawing.Point(6, 45)
        Me.chkAcctHolderNameAll.Name = "chkAcctHolderNameAll"
        Me.chkAcctHolderNameAll.Size = New System.Drawing.Size(40, 17)
        Me.chkAcctHolderNameAll.TabIndex = 2
        Me.chkAcctHolderNameAll.Text = "All"
        Me.chkAcctHolderNameAll.UseVisualStyleBackColor = True
        '
        'cboAcctHolderName
        '
        Me.cboAcctHolderName.FormattingEnabled = True
        Me.cboAcctHolderName.Location = New System.Drawing.Point(6, 18)
        Me.cboAcctHolderName.Name = "cboAcctHolderName"
        Me.cboAcctHolderName.Size = New System.Drawing.Size(210, 21)
        Me.cboAcctHolderName.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.dtToAcctHolder)
        Me.GroupBox3.Controls.Add(Me.dtFromAcctHolder)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(268, 73)
        Me.GroupBox3.TabIndex = 428
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Period Covered"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(14, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "To : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(4, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "From : "
        '
        'dtToAcctHolder
        '
        Me.dtToAcctHolder.Location = New System.Drawing.Point(56, 45)
        Me.dtToAcctHolder.Name = "dtToAcctHolder"
        Me.dtToAcctHolder.Size = New System.Drawing.Size(200, 20)
        Me.dtToAcctHolder.TabIndex = 1
        '
        'dtFromAcctHolder
        '
        Me.dtFromAcctHolder.Location = New System.Drawing.Point(56, 19)
        Me.dtFromAcctHolder.Name = "dtFromAcctHolder"
        Me.dtFromAcctHolder.Size = New System.Drawing.Size(200, 20)
        Me.dtFromAcctHolder.TabIndex = 0
        '
        'tbpCI
        '
        Me.tbpCI.Controls.Add(Me.crCI)
        Me.tbpCI.Controls.Add(Me.Panel3)
        Me.tbpCI.Location = New System.Drawing.Point(4, 22)
        Me.tbpCI.Name = "tbpCI"
        Me.tbpCI.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCI.Size = New System.Drawing.Size(907, 429)
        Me.tbpCI.TabIndex = 2
        Me.tbpCI.Text = "By Charge Invoice"
        Me.tbpCI.UseVisualStyleBackColor = True
        '
        'crCI
        '
        Me.crCI.ActiveViewIndex = -1
        Me.crCI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crCI.Cursor = System.Windows.Forms.Cursors.Default
        Me.crCI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crCI.Location = New System.Drawing.Point(3, 88)
        Me.crCI.Name = "crCI"
        Me.crCI.SelectionFormula = ""
        Me.crCI.Size = New System.Drawing.Size(901, 338)
        Me.crCI.TabIndex = 428
        Me.crCI.ViewTimeSelectionFormula = ""
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cmdPrevCI)
        Me.Panel3.Controls.Add(Me.GroupBox5)
        Me.Panel3.Controls.Add(Me.GroupBox6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(901, 85)
        Me.Panel3.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkCINoAll)
        Me.GroupBox5.Controls.Add(Me.cboCINo)
        Me.GroupBox5.Location = New System.Drawing.Point(279, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(222, 73)
        Me.GroupBox5.TabIndex = 429
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Charge Invoice"
        '
        'chkCINoAll
        '
        Me.chkCINoAll.AutoSize = True
        Me.chkCINoAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCINoAll.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkCINoAll.Location = New System.Drawing.Point(6, 45)
        Me.chkCINoAll.Name = "chkCINoAll"
        Me.chkCINoAll.Size = New System.Drawing.Size(40, 17)
        Me.chkCINoAll.TabIndex = 2
        Me.chkCINoAll.Text = "All"
        Me.chkCINoAll.UseVisualStyleBackColor = True
        '
        'cboCINo
        '
        Me.cboCINo.FormattingEnabled = True
        Me.cboCINo.Location = New System.Drawing.Point(6, 18)
        Me.cboCINo.Name = "cboCINo"
        Me.cboCINo.Size = New System.Drawing.Size(210, 21)
        Me.cboCINo.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.dtToCI)
        Me.GroupBox6.Controls.Add(Me.dtFromCI)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(268, 73)
        Me.GroupBox6.TabIndex = 428
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Period Covered"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(14, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "To : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(4, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "From : "
        '
        'dtToCI
        '
        Me.dtToCI.Location = New System.Drawing.Point(56, 45)
        Me.dtToCI.Name = "dtToCI"
        Me.dtToCI.Size = New System.Drawing.Size(200, 20)
        Me.dtToCI.TabIndex = 1
        '
        'dtFromCI
        '
        Me.dtFromCI.Location = New System.Drawing.Point(56, 19)
        Me.dtFromCI.Name = "dtFromCI"
        Me.dtFromCI.Size = New System.Drawing.Size(200, 20)
        Me.dtFromCI.TabIndex = 0
        '
        'tbpSOA
        '
        Me.tbpSOA.Controls.Add(Me.crSOA)
        Me.tbpSOA.Controls.Add(Me.Panel4)
        Me.tbpSOA.Location = New System.Drawing.Point(4, 22)
        Me.tbpSOA.Name = "tbpSOA"
        Me.tbpSOA.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpSOA.Size = New System.Drawing.Size(907, 429)
        Me.tbpSOA.TabIndex = 3
        Me.tbpSOA.Text = "By S.O.A."
        Me.tbpSOA.UseVisualStyleBackColor = True
        '
        'crSOA
        '
        Me.crSOA.ActiveViewIndex = -1
        Me.crSOA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crSOA.Cursor = System.Windows.Forms.Cursors.Default
        Me.crSOA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crSOA.Location = New System.Drawing.Point(3, 88)
        Me.crSOA.Name = "crSOA"
        Me.crSOA.SelectionFormula = ""
        Me.crSOA.Size = New System.Drawing.Size(901, 338)
        Me.crSOA.TabIndex = 429
        Me.crSOA.ViewTimeSelectionFormula = ""
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.cmdPrevSOA)
        Me.Panel4.Controls.Add(Me.GroupBox11)
        Me.Panel4.Controls.Add(Me.GroupBox12)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(901, 85)
        Me.Panel4.TabIndex = 2
        '
        'cmdPrevSOA
        '
        Me.cmdPrevSOA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevSOA.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdPrevSOA.Location = New System.Drawing.Point(507, 16)
        Me.cmdPrevSOA.Name = "cmdPrevSOA"
        Me.cmdPrevSOA.Size = New System.Drawing.Size(75, 52)
        Me.cmdPrevSOA.TabIndex = 431
        Me.cmdPrevSOA.Text = "Preview"
        Me.cmdPrevSOA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdPrevSOA.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.chkSOANoAll)
        Me.GroupBox11.Controls.Add(Me.cboSOANo)
        Me.GroupBox11.Location = New System.Drawing.Point(279, 3)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(222, 73)
        Me.GroupBox11.TabIndex = 429
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "S.O.A."
        '
        'chkSOANoAll
        '
        Me.chkSOANoAll.AutoSize = True
        Me.chkSOANoAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSOANoAll.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkSOANoAll.Location = New System.Drawing.Point(6, 45)
        Me.chkSOANoAll.Name = "chkSOANoAll"
        Me.chkSOANoAll.Size = New System.Drawing.Size(40, 17)
        Me.chkSOANoAll.TabIndex = 2
        Me.chkSOANoAll.Text = "All"
        Me.chkSOANoAll.UseVisualStyleBackColor = True
        '
        'cboSOANo
        '
        Me.cboSOANo.FormattingEnabled = True
        Me.cboSOANo.Location = New System.Drawing.Point(6, 18)
        Me.cboSOANo.Name = "cboSOANo"
        Me.cboSOANo.Size = New System.Drawing.Size(210, 21)
        Me.cboSOANo.TabIndex = 0
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label11)
        Me.GroupBox12.Controls.Add(Me.Label12)
        Me.GroupBox12.Controls.Add(Me.dtToSOA)
        Me.GroupBox12.Controls.Add(Me.dtFromSOA)
        Me.GroupBox12.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(268, 73)
        Me.GroupBox12.TabIndex = 428
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Period Covered"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.Location = New System.Drawing.Point(14, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "To : "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.Location = New System.Drawing.Point(4, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "From : "
        '
        'dtToSOA
        '
        Me.dtToSOA.Location = New System.Drawing.Point(56, 45)
        Me.dtToSOA.Name = "dtToSOA"
        Me.dtToSOA.Size = New System.Drawing.Size(200, 20)
        Me.dtToSOA.TabIndex = 1
        '
        'dtFromSOA
        '
        Me.dtFromSOA.Location = New System.Drawing.Point(56, 19)
        Me.dtFromSOA.Name = "dtFromSOA"
        Me.dtFromSOA.Size = New System.Drawing.Size(200, 20)
        Me.dtFromSOA.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(501, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 445
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdClose.Location = New System.Drawing.Point(846, 12)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 52)
        Me.cmdClose.TabIndex = 446
        Me.cmdClose.Text = "Exit"
        Me.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.Location = New System.Drawing.Point(4, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "From : "
        '
        'lblFormTitle
        '
        Me.lblFormTitle.AutoSize = True
        Me.lblFormTitle.BackColor = System.Drawing.Color.White
        Me.lblFormTitle.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormTitle.ForeColor = System.Drawing.Color.Black
        Me.lblFormTitle.Location = New System.Drawing.Point(46, 20)
        Me.lblFormTitle.Name = "lblFormTitle"
        Me.lblFormTitle.Size = New System.Drawing.Size(132, 21)
        Me.lblFormTitle.TabIndex = 435
        Me.lblFormTitle.Text = "Billing Summary"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.DarkBlue
        Me.CheckBox2.Location = New System.Drawing.Point(6, 45)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(40, 17)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Text = "All"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Location = New System.Drawing.Point(56, 45)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker3.TabIndex = 1
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Location = New System.Drawing.Point(56, 19)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker4.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.Location = New System.Drawing.Point(14, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "To : "
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Label15)
        Me.GroupBox13.Controls.Add(Me.Label16)
        Me.GroupBox13.Controls.Add(Me.DateTimePicker5)
        Me.GroupBox13.Controls.Add(Me.DateTimePicker6)
        Me.GroupBox13.Location = New System.Drawing.Point(-1, 3)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(268, 73)
        Me.GroupBox13.TabIndex = 437
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Period Covered"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.Location = New System.Drawing.Point(4, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "From : "
        '
        'DateTimePicker5
        '
        Me.DateTimePicker5.Location = New System.Drawing.Point(56, 45)
        Me.DateTimePicker5.Name = "DateTimePicker5"
        Me.DateTimePicker5.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker5.TabIndex = 1
        '
        'DateTimePicker6
        '
        Me.DateTimePicker6.Location = New System.Drawing.Point(56, 19)
        Me.DateTimePicker6.Name = "DateTimePicker6"
        Me.DateTimePicker6.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker6.TabIndex = 0
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Button5.Location = New System.Drawing.Point(273, 16)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 52)
        Me.Button5.TabIndex = 442
        Me.Button5.Text = "Preview"
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.Location = New System.Drawing.Point(14, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "To : "
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Label9)
        Me.GroupBox10.Controls.Add(Me.Label10)
        Me.GroupBox10.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox10.Controls.Add(Me.DateTimePicker4)
        Me.GroupBox10.Location = New System.Drawing.Point(-1, 3)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(268, 73)
        Me.GroupBox10.TabIndex = 438
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Period Coverd"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(6, 18)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(210, 21)
        Me.ComboBox2.TabIndex = 0
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label7)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox8.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox8.Location = New System.Drawing.Point(-1, 3)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(268, 73)
        Me.GroupBox8.TabIndex = 439
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Period Coverd"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(14, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "To : "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Location = New System.Drawing.Point(4, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "From : "
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(56, 45)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(56, 19)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 0
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.CheckBox1.Location = New System.Drawing.Point(6, 45)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(40, 17)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(501, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 443
        Me.Button2.Text = "Preview"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckBox1)
        Me.GroupBox7.Controls.Add(Me.ComboBox1)
        Me.GroupBox7.Location = New System.Drawing.Point(273, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(222, 73)
        Me.GroupBox7.TabIndex = 440
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Charge Invoice"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 18)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(210, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.CheckBox2)
        Me.GroupBox9.Controls.Add(Me.ComboBox2)
        Me.GroupBox9.Location = New System.Drawing.Point(273, 3)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(222, 73)
        Me.GroupBox9.TabIndex = 441
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Charge Invoice"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(501, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 444
        Me.Button4.Text = "Preview"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(501, 44)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 447
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(6, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 436
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(915, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 434
        Me.PictureBox1.TabStop = False
        '
        'frmBillingSummaryReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 527)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.lblFormTitle)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Name = "frmBillingSummaryReports"
        Me.Text = "frmBillingSummaryReports"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dtgBillingMonitoring, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.gpLegend.ResumeLayout(False)
        Me.gpLegend.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.tbpBillingSummary.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.tbpShipper.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbpAcctHolder.ResumeLayout(False)
        Me.PanelAcctHolder.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tbpCI.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.tbpSOA.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdPrevCI As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dtgBillingMonitoring As DataGridView
    Friend WithEvents colBookNo As DataGridViewTextBoxColumn
    Friend WithEvents colRefNo As DataGridViewTextBoxColumn
    Friend WithEvents colCINo As DataGridViewTextBoxColumn
    Friend WithEvents colSOA As DataGridViewTextBoxColumn
    Friend WithEvents colPrepDate As DataGridViewTextBoxColumn
    Friend WithEvents colBilledTo As DataGridViewTextBoxColumn
    Friend WithEvents colHBL As DataGridViewTextBoxColumn
    Friend WithEvents colDestination As DataGridViewTextBoxColumn
    Friend WithEvents colTerms As DataGridViewTextBoxColumn
    Friend WithEvents colCIAmt As DataGridViewTextBoxColumn
    Friend WithEvents colSOAAmt As DataGridViewTextBoxColumn
    Friend WithEvents colVATAmt As DataGridViewTextBoxColumn
    Friend WithEvents colTotal As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents gpLegend As GroupBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents GroupBox16 As GroupBox
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents chkCancelled As CheckBox
    Friend WithEvents chkOpen As CheckBox
    Friend WithEvents chkPosted As CheckBox
    Friend WithEvents GroupBox15 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents dtToMon As DateTimePicker
    Friend WithEvents dtFromMon As DateTimePicker
    Friend WithEvents tbpBillingSummary As TabPage
    Friend WithEvents crSummary As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel5 As Panel
    Friend WithEvents cmdPrevSummary As Button
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents dtToSummary As DateTimePicker
    Friend WithEvents dtFromSummary As DateTimePicker
    Friend WithEvents tbpShipper As TabPage
    Friend WithEvents crShipper As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdPrevShipper As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkShipperNameAll As CheckBox
    Friend WithEvents cboShipperName As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtToShipper As DateTimePicker
    Friend WithEvents dtFromShipper As DateTimePicker
    Friend WithEvents tbpAcctHolder As TabPage
    Friend WithEvents crAcctHolder As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents PanelAcctHolder As Panel
    Friend WithEvents cmdPrevAcctHolder As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents chkAcctHolderNameAll As CheckBox
    Friend WithEvents cboAcctHolderName As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtToAcctHolder As DateTimePicker
    Friend WithEvents dtFromAcctHolder As DateTimePicker
    Friend WithEvents tbpCI As TabPage
    Friend WithEvents crCI As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents chkCINoAll As CheckBox
    Friend WithEvents cboCINo As ComboBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtToCI As DateTimePicker
    Friend WithEvents dtFromCI As DateTimePicker
    Friend WithEvents tbpSOA As TabPage
    Friend WithEvents crSOA As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmdPrevSOA As Button
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents chkSOANoAll As CheckBox
    Friend WithEvents cboSOANo As ComboBox
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents dtToSOA As DateTimePicker
    Friend WithEvents dtFromSOA As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents lblFormTitle As Label
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents DateTimePicker4 As DateTimePicker
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents DateTimePicker5 As DateTimePicker
    Friend WithEvents DateTimePicker6 As DateTimePicker
    Friend WithEvents Button5 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
End Class
