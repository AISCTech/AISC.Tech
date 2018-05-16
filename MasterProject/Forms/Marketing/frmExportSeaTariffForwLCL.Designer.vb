<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportSeaTariffForwLCL
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtChargeCode = New System.Windows.Forms.TextBox()
        Me.cboChargeName = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboDirectPort = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.optTranshipment = New System.Windows.Forms.RadioButton()
        Me.cboTranshipmentPort = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.optDirect = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboUOM = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboCurrency = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dgTariff = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstripEncodedBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstripEncodedDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstripModifiedBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstripModifiedDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtPK = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboCurrencyS = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboUOMS = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPriceS = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.cboTranshipmentFinalDest = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgTariff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Charge Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Charge Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(92, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = ":"
        '
        'txtChargeCode
        '
        Me.txtChargeCode.Location = New System.Drawing.Point(104, 13)
        Me.txtChargeCode.Name = "txtChargeCode"
        Me.txtChargeCode.ReadOnly = True
        Me.txtChargeCode.Size = New System.Drawing.Size(241, 20)
        Me.txtChargeCode.TabIndex = 3
        '
        'cboChargeName
        '
        Me.cboChargeName.FormattingEnabled = True
        Me.cboChargeName.Location = New System.Drawing.Point(104, 32)
        Me.cboChargeName.Name = "cboChargeName"
        Me.cboChargeName.Size = New System.Drawing.Size(241, 21)
        Me.cboChargeName.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label41)
        Me.GroupBox1.Controls.Add(Me.cboTranshipmentFinalDest)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboDirectPort)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.optTranshipment)
        Me.GroupBox1.Controls.Add(Me.cboTranshipmentPort)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.optDirect)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(332, 123)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(112, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = ":"
        '
        'cboDirectPort
        '
        Me.cboDirectPort.FormattingEnabled = True
        Me.cboDirectPort.Location = New System.Drawing.Point(125, 18)
        Me.cboDirectPort.Name = "cboDirectPort"
        Me.cboDirectPort.Size = New System.Drawing.Size(201, 21)
        Me.cboDirectPort.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(80, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Port"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(112, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = ":"
        '
        'optTranshipment
        '
        Me.optTranshipment.AutoSize = True
        Me.optTranshipment.Location = New System.Drawing.Point(14, 43)
        Me.optTranshipment.Name = "optTranshipment"
        Me.optTranshipment.Size = New System.Drawing.Size(89, 17)
        Me.optTranshipment.TabIndex = 1
        Me.optTranshipment.TabStop = True
        Me.optTranshipment.Text = "Transhipment"
        Me.optTranshipment.UseVisualStyleBackColor = True
        '
        'cboTranshipmentPort
        '
        Me.cboTranshipmentPort.FormattingEnabled = True
        Me.cboTranshipmentPort.Location = New System.Drawing.Point(125, 65)
        Me.cboTranshipmentPort.Name = "cboTranshipmentPort"
        Me.cboTranshipmentPort.Size = New System.Drawing.Size(201, 21)
        Me.cboTranshipmentPort.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Transhipment Port"
        '
        'optDirect
        '
        Me.optDirect.AutoSize = True
        Me.optDirect.Checked = True
        Me.optDirect.Location = New System.Drawing.Point(15, 19)
        Me.optDirect.Name = "optDirect"
        Me.optDirect.Size = New System.Drawing.Size(53, 17)
        Me.optDirect.TabIndex = 0
        Me.optDirect.TabStop = True
        Me.optDirect.Text = "Direct"
        Me.optDirect.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(92, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = ":"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(451, 58)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(108, 20)
        Me.txtPrice.TabIndex = 9
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(439, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(373, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Buying Price"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(439, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = ":"
        '
        'cboUOM
        '
        Me.cboUOM.FormattingEnabled = True
        Me.cboUOM.Location = New System.Drawing.Point(451, 77)
        Me.cboUOM.Name = "cboUOM"
        Me.cboUOM.Size = New System.Drawing.Size(108, 21)
        Me.cboUOM.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(368, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Buying UOM"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(439, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = ":"
        '
        'cboCurrency
        '
        Me.cboCurrency.FormattingEnabled = True
        Me.cboCurrency.Location = New System.Drawing.Point(451, 97)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(108, 21)
        Me.cboCurrency.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(355, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Buying Currency"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(451, 117)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(320, 65)
        Me.txtRemarks.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(439, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(390, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Remarks"
        '
        'dgTariff
        '
        Me.dgTariff.AllowUserToAddRows = False
        Me.dgTariff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTariff.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column9, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column10, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        Me.dgTariff.Location = New System.Drawing.Point(13, 198)
        Me.dgTariff.Name = "dgTariff"
        Me.dgTariff.Size = New System.Drawing.Size(758, 187)
        Me.dgTariff.TabIndex = 19
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tstripEncodedBy, Me.ToolStripStatusLabel3, Me.tstripEncodedDate, Me.ToolStripStatusLabel2, Me.tstripModifiedBy, Me.ToolStripStatusLabel4, Me.tstripModifiedDate})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 409)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(786, 22)
        Me.StatusStrip1.TabIndex = 20
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(75, 17)
        Me.ToolStripStatusLabel1.Text = "Encoded By :"
        '
        'tstripEncodedBy
        '
        Me.tstripEncodedBy.ForeColor = System.Drawing.Color.Red
        Me.tstripEncodedBy.Name = "tstripEncodedBy"
        Me.tstripEncodedBy.Size = New System.Drawing.Size(16, 17)
        Me.tstripEncodedBy.Text = "..."
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(86, 17)
        Me.ToolStripStatusLabel3.Text = "Date Encoded :"
        '
        'tstripEncodedDate
        '
        Me.tstripEncodedDate.ForeColor = System.Drawing.Color.Red
        Me.tstripEncodedDate.Name = "tstripEncodedDate"
        Me.tstripEncodedDate.Size = New System.Drawing.Size(16, 17)
        Me.tstripEncodedDate.Text = "..."
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(77, 17)
        Me.ToolStripStatusLabel2.Text = "Modified By :"
        '
        'tstripModifiedBy
        '
        Me.tstripModifiedBy.ForeColor = System.Drawing.Color.Red
        Me.tstripModifiedBy.Name = "tstripModifiedBy"
        Me.tstripModifiedBy.Size = New System.Drawing.Size(16, 17)
        Me.tstripModifiedBy.Text = "..."
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(88, 17)
        Me.ToolStripStatusLabel4.Text = "Date Modified :"
        '
        'tstripModifiedDate
        '
        Me.tstripModifiedDate.ForeColor = System.Drawing.Color.Red
        Me.tstripModifiedDate.Name = "tstripModifiedDate"
        Me.tstripModifiedDate.Size = New System.Drawing.Size(16, 17)
        Me.tstripModifiedDate.Text = "..."
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtPK
        '
        Me.txtPK.Location = New System.Drawing.Point(533, 13)
        Me.txtPK.Name = "txtPK"
        Me.txtPK.ReadOnly = True
        Me.txtPK.Size = New System.Drawing.Size(241, 20)
        Me.txtPK.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(521, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 13)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = ":"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(442, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(21, 13)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "PK"
        '
        'cboType
        '
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(533, 32)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(241, 21)
        Me.cboType.TabIndex = 58
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(484, 36)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(31, 13)
        Me.Label27.TabIndex = 57
        Me.Label27.Text = "Type"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(521, 36)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(10, 13)
        Me.Label28.TabIndex = 59
        Me.Label28.Text = ":"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(651, 101)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 13)
        Me.Label19.TabIndex = 68
        Me.Label19.Text = ":"
        '
        'cboCurrencyS
        '
        Me.cboCurrencyS.FormattingEnabled = True
        Me.cboCurrencyS.Location = New System.Drawing.Point(663, 97)
        Me.cboCurrencyS.Name = "cboCurrencyS"
        Me.cboCurrencyS.Size = New System.Drawing.Size(108, 21)
        Me.cboCurrencyS.TabIndex = 67
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(567, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 13)
        Me.Label20.TabIndex = 66
        Me.Label20.Text = "Selling Currency"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(651, 81)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(10, 13)
        Me.Label21.TabIndex = 65
        Me.Label21.Text = ":"
        '
        'cboUOMS
        '
        Me.cboUOMS.FormattingEnabled = True
        Me.cboUOMS.Location = New System.Drawing.Point(663, 77)
        Me.cboUOMS.Name = "cboUOMS"
        Me.cboUOMS.Size = New System.Drawing.Size(108, 21)
        Me.cboUOMS.TabIndex = 64
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(580, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 13)
        Me.Label22.TabIndex = 63
        Me.Label22.Text = "Selling UOM"
        '
        'txtPriceS
        '
        Me.txtPriceS.Location = New System.Drawing.Point(663, 58)
        Me.txtPriceS.Name = "txtPriceS"
        Me.txtPriceS.Size = New System.Drawing.Size(108, 20)
        Me.txtPriceS.TabIndex = 62
        Me.txtPriceS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(651, 61)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 13)
        Me.Label23.TabIndex = 61
        Me.Label23.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(585, 61)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 13)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "Selling Price"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(112, 89)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(10, 13)
        Me.Label41.TabIndex = 18
        Me.Label41.Text = ":"
        '
        'cboTranshipmentFinalDest
        '
        Me.cboTranshipmentFinalDest.FormattingEnabled = True
        Me.cboTranshipmentFinalDest.Location = New System.Drawing.Point(125, 85)
        Me.cboTranshipmentFinalDest.Name = "cboTranshipmentFinalDest"
        Me.cboTranshipmentFinalDest.Size = New System.Drawing.Size(201, 21)
        Me.cboTranshipmentFinalDest.TabIndex = 17
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(13, 90)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(85, 13)
        Me.Label42.TabIndex = 16
        Me.Label42.Text = "Final Destination"
        '
        'Column9
        '
        Me.Column9.HeaderText = "PK"
        Me.Column9.Name = "Column9"
        '
        'Column1
        '
        Me.Column1.HeaderText = "Charge Code"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Charge Name"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Direct / Transhipment"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Transhipment Port"
        Me.Column4.Name = "Column4"
        '
        'Column10
        '
        Me.Column10.HeaderText = "Transhipment Final Dest"
        Me.Column10.Name = "Column10"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Direct Port"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Price"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Currency"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "Remarks"
        Me.Column8.Name = "Column8"
        '
        'frmExportSeaTariffForwLCL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 431)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboCurrencyS)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cboUOMS)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtPriceS)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtPK)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgTariff)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboCurrency)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboUOM)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboChargeName)
        Me.Controls.Add(Me.txtChargeCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmExportSeaTariffForwLCL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Sea Tariff Forwarding LCL"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgTariff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtChargeCode As TextBox
    Friend WithEvents cboChargeName As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboDirectPort As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents optTranshipment As RadioButton
    Friend WithEvents cboTranshipmentPort As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents optDirect As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cboUOM As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cboCurrency As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents dgTariff As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tstripEncodedBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents tstripEncodedDate As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tstripModifiedBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents tstripModifiedDate As ToolStripStatusLabel
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents txtPK As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents cboType As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents cboCurrencyS As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents cboUOMS As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtPriceS As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents cboTranshipmentFinalDest As ComboBox
    Friend WithEvents Label42 As Label
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
End Class
