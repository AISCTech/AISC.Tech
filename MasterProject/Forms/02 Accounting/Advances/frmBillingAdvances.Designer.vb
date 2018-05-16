<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillingAdvances
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNotAllowed = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblAllowed = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbServiceType = New System.Windows.Forms.GroupBox()
        Me.optImpF = New System.Windows.Forms.RadioButton()
        Me.optImpB = New System.Windows.Forms.RadioButton()
        Me.optExp = New System.Windows.Forms.RadioButton()
        Me.txtAdvUsed = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSOATotal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbAdvances = New System.Windows.Forms.GroupBox()
        Me.dgAdvances = New System.Windows.Forms.DataGridView()
        Me.colAllow = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colCompany = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemaining = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBookingAdv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colARNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbBilling = New System.Windows.Forms.GroupBox()
        Me.dgBilling = New System.Windows.Forms.DataGridView()
        Me.colChk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSOA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdvances = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBooking = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboClient = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblRefNo = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.gbServiceType.SuspendLayout()
        Me.gbAdvances.SuspendLayout()
        CType(Me.dgAdvances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBilling.SuspendLayout()
        CType(Me.dgBilling, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(141, 500)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 1192
        Me.Label5.Text = "NOT ALLOWED"
        '
        'lblNotAllowed
        '
        Me.lblNotAllowed.BackColor = System.Drawing.Color.Aquamarine
        Me.lblNotAllowed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNotAllowed.Location = New System.Drawing.Point(114, 496)
        Me.lblNotAllowed.Name = "lblNotAllowed"
        Me.lblNotAllowed.Size = New System.Drawing.Size(20, 18)
        Me.lblNotAllowed.TabIndex = 1191
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 500)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 1190
        Me.Label4.Text = "ALLOWED"
        '
        'lblAllowed
        '
        Me.lblAllowed.BackColor = System.Drawing.Color.Aquamarine
        Me.lblAllowed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAllowed.Location = New System.Drawing.Point(18, 496)
        Me.lblAllowed.Name = "lblAllowed"
        Me.lblAllowed.Size = New System.Drawing.Size(20, 18)
        Me.lblAllowed.TabIndex = 1189
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tslblPrepBy, Me.ToolStripStatusLabel2, Me.tslblPrepDate, Me.ToolStripStatusLabel3, Me.tslblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 548)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(646, 22)
        Me.StatusStrip1.TabIndex = 1188
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(76, 17)
        Me.ToolStripStatusLabel1.Text = "Prepared By :"
        '
        'tslblPrepBy
        '
        Me.tslblPrepBy.Name = "tslblPrepBy"
        Me.tslblPrepBy.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(84, 17)
        Me.ToolStripStatusLabel2.Text = "Prepared Date:"
        '
        'tslblPrepDate
        '
        Me.tslblPrepDate.Name = "tslblPrepDate"
        Me.tslblPrepDate.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel3.Text = "Status:"
        '
        'tslblStatus
        '
        Me.tslblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslblStatus.Name = "tslblStatus"
        Me.tslblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'gbServiceType
        '
        Me.gbServiceType.Controls.Add(Me.optImpF)
        Me.gbServiceType.Controls.Add(Me.optImpB)
        Me.gbServiceType.Controls.Add(Me.optExp)
        Me.gbServiceType.Enabled = False
        Me.gbServiceType.Location = New System.Drawing.Point(15, 55)
        Me.gbServiceType.Name = "gbServiceType"
        Me.gbServiceType.Size = New System.Drawing.Size(617, 53)
        Me.gbServiceType.TabIndex = 1187
        Me.gbServiceType.TabStop = False
        Me.gbServiceType.Text = "Service Type"
        '
        'optImpF
        '
        Me.optImpF.AutoSize = True
        Me.optImpF.Location = New System.Drawing.Point(473, 24)
        Me.optImpF.Name = "optImpF"
        Me.optImpF.Size = New System.Drawing.Size(109, 17)
        Me.optImpF.TabIndex = 2
        Me.optImpF.Text = "Import Forwarding"
        Me.optImpF.UseVisualStyleBackColor = True
        '
        'optImpB
        '
        Me.optImpB.AutoSize = True
        Me.optImpB.Location = New System.Drawing.Point(244, 24)
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
        Me.optExp.Location = New System.Drawing.Point(44, 24)
        Me.optExp.Name = "optExp"
        Me.optExp.Size = New System.Drawing.Size(55, 17)
        Me.optExp.TabIndex = 0
        Me.optExp.TabStop = True
        Me.optExp.Text = "Export"
        Me.optExp.UseVisualStyleBackColor = True
        '
        'txtAdvUsed
        '
        Me.txtAdvUsed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAdvUsed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdvUsed.ForeColor = System.Drawing.Color.DarkRed
        Me.txtAdvUsed.Location = New System.Drawing.Point(466, 497)
        Me.txtAdvUsed.Name = "txtAdvUsed"
        Me.txtAdvUsed.ReadOnly = True
        Me.txtAdvUsed.Size = New System.Drawing.Size(159, 22)
        Me.txtAdvUsed.TabIndex = 1186
        Me.txtAdvUsed.Text = "0.00"
        Me.txtAdvUsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(327, 501)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 13)
        Me.Label2.TabIndex = 1185
        Me.Label2.Text = "Total Advances Used :"
        '
        'txtSOATotal
        '
        Me.txtSOATotal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSOATotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSOATotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSOATotal.Location = New System.Drawing.Point(466, 312)
        Me.txtSOATotal.Name = "txtSOATotal"
        Me.txtSOATotal.ReadOnly = True
        Me.txtSOATotal.Size = New System.Drawing.Size(159, 22)
        Me.txtSOATotal.TabIndex = 1184
        Me.txtSOATotal.Text = "0.00"
        Me.txtSOATotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(360, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 1183
        Me.Label3.Text = "Total Advances :"
        '
        'gbAdvances
        '
        Me.gbAdvances.Controls.Add(Me.dgAdvances)
        Me.gbAdvances.Location = New System.Drawing.Point(12, 335)
        Me.gbAdvances.Name = "gbAdvances"
        Me.gbAdvances.Size = New System.Drawing.Size(619, 156)
        Me.gbAdvances.TabIndex = 1182
        Me.gbAdvances.TabStop = False
        Me.gbAdvances.Text = "ADVANCES"
        '
        'dgAdvances
        '
        Me.dgAdvances.AllowUserToAddRows = False
        Me.dgAdvances.AllowUserToDeleteRows = False
        Me.dgAdvances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAdvances.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAllow, Me.colCompany, Me.colRemaining, Me.colUse, Me.colBookingAdv, Me.colARNo})
        Me.dgAdvances.Location = New System.Drawing.Point(6, 19)
        Me.dgAdvances.Name = "dgAdvances"
        Me.dgAdvances.RowHeadersVisible = False
        Me.dgAdvances.Size = New System.Drawing.Size(607, 131)
        Me.dgAdvances.TabIndex = 0
        '
        'colAllow
        '
        Me.colAllow.HeaderText = ""
        Me.colAllow.Name = "colAllow"
        Me.colAllow.Width = 30
        '
        'colCompany
        '
        Me.colCompany.HeaderText = "Company"
        Me.colCompany.Name = "colCompany"
        Me.colCompany.ReadOnly = True
        Me.colCompany.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCompany.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colCompany.Width = 155
        '
        'colRemaining
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colRemaining.DefaultCellStyle = DataGridViewCellStyle1
        Me.colRemaining.HeaderText = "Remaining"
        Me.colRemaining.Name = "colRemaining"
        Me.colRemaining.ReadOnly = True
        Me.colRemaining.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRemaining.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colUse
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colUse.DefaultCellStyle = DataGridViewCellStyle2
        Me.colUse.HeaderText = "Amount Applied"
        Me.colUse.Name = "colUse"
        Me.colUse.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colBookingAdv
        '
        Me.colBookingAdv.HeaderText = "Booking No."
        Me.colBookingAdv.Name = "colBookingAdv"
        Me.colBookingAdv.ReadOnly = True
        '
        'colARNo
        '
        Me.colARNo.HeaderText = "AR No."
        Me.colARNo.Name = "colARNo"
        Me.colARNo.ReadOnly = True
        Me.colARNo.Width = 70
        '
        'gbBilling
        '
        Me.gbBilling.Controls.Add(Me.dgBilling)
        Me.gbBilling.Location = New System.Drawing.Point(12, 150)
        Me.gbBilling.Name = "gbBilling"
        Me.gbBilling.Size = New System.Drawing.Size(619, 156)
        Me.gbBilling.TabIndex = 1181
        Me.gbBilling.TabStop = False
        Me.gbBilling.Text = "BILLING"
        '
        'dgBilling
        '
        Me.dgBilling.AllowUserToAddRows = False
        Me.dgBilling.AllowUserToDeleteRows = False
        Me.dgBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBilling.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colChk, Me.colRefNo, Me.colSOA, Me.colBalance, Me.colAdvances, Me.colBooking})
        Me.dgBilling.Location = New System.Drawing.Point(6, 19)
        Me.dgBilling.Name = "dgBilling"
        Me.dgBilling.RowHeadersVisible = False
        Me.dgBilling.Size = New System.Drawing.Size(607, 131)
        Me.dgBilling.TabIndex = 0
        '
        'colChk
        '
        Me.colChk.HeaderText = ""
        Me.colChk.Name = "colChk"
        Me.colChk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colChk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colChk.Width = 30
        '
        'colRefNo
        '
        Me.colRefNo.HeaderText = "Reference No."
        Me.colRefNo.Name = "colRefNo"
        Me.colRefNo.ReadOnly = True
        Me.colRefNo.Width = 108
        '
        'colSOA
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colSOA.DefaultCellStyle = DataGridViewCellStyle3
        Me.colSOA.HeaderText = "SOA Amount"
        Me.colSOA.Name = "colSOA"
        Me.colSOA.ReadOnly = True
        '
        'colBalance
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colBalance.DefaultCellStyle = DataGridViewCellStyle4
        Me.colBalance.HeaderText = "Balance"
        Me.colBalance.Name = "colBalance"
        Me.colBalance.ReadOnly = True
        '
        'colAdvances
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAdvances.DefaultCellStyle = DataGridViewCellStyle5
        Me.colAdvances.HeaderText = "Advances"
        Me.colAdvances.Name = "colAdvances"
        Me.colAdvances.ReadOnly = True
        '
        'colBooking
        '
        Me.colBooking.HeaderText = "Booking No."
        Me.colBooking.Name = "colBooking"
        Me.colBooking.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(12, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 1180
        Me.Label1.Text = "Client Name:"
        '
        'cboClient
        '
        Me.cboClient.Enabled = False
        Me.cboClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboClient.FormattingEnabled = True
        Me.cboClient.Location = New System.Drawing.Point(97, 123)
        Me.cboClient.Name = "cboClient"
        Me.cboClient.Size = New System.Drawing.Size(535, 21)
        Me.cboClient.TabIndex = 1179
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Info
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(359, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 18)
        Me.Label18.TabIndex = 1194
        Me.Label18.Text = "Ref No. :"
        '
        'lblRefNo
        '
        Me.lblRefNo.BackColor = System.Drawing.SystemColors.Info
        Me.lblRefNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRefNo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefNo.ForeColor = System.Drawing.Color.Black
        Me.lblRefNo.Location = New System.Drawing.Point(430, 18)
        Me.lblRefNo.Name = "lblRefNo"
        Me.lblRefNo.Size = New System.Drawing.Size(202, 21)
        Me.lblRefNo.TabIndex = 1193
        '
        'frmBillingAdvances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 570)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblRefNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblNotAllowed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblAllowed)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbServiceType)
        Me.Controls.Add(Me.txtAdvUsed)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSOATotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbAdvances)
        Me.Controls.Add(Me.gbBilling)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboClient)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmBillingAdvances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Billing vs Advances"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gbServiceType.ResumeLayout(False)
        Me.gbServiceType.PerformLayout()
        Me.gbAdvances.ResumeLayout(False)
        CType(Me.dgAdvances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBilling.ResumeLayout(False)
        CType(Me.dgBilling, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents lblNotAllowed As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblAllowed As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tslblPrepBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tslblPrepDate As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents tslblStatus As ToolStripStatusLabel
    Friend WithEvents gbServiceType As GroupBox
    Friend WithEvents optImpF As RadioButton
    Friend WithEvents optImpB As RadioButton
    Friend WithEvents optExp As RadioButton
    Friend WithEvents txtAdvUsed As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSOATotal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents gbAdvances As GroupBox
    Friend WithEvents dgAdvances As DataGridView
    Friend WithEvents colAllow As DataGridViewButtonColumn
    Friend WithEvents colCompany As DataGridViewTextBoxColumn
    Friend WithEvents colRemaining As DataGridViewTextBoxColumn
    Friend WithEvents colUse As DataGridViewTextBoxColumn
    Friend WithEvents colBookingAdv As DataGridViewTextBoxColumn
    Friend WithEvents colARNo As DataGridViewTextBoxColumn
    Friend WithEvents gbBilling As GroupBox
    Friend WithEvents dgBilling As DataGridView
    Friend WithEvents colChk As DataGridViewCheckBoxColumn
    Friend WithEvents colRefNo As DataGridViewTextBoxColumn
    Friend WithEvents colSOA As DataGridViewTextBoxColumn
    Friend WithEvents colBalance As DataGridViewTextBoxColumn
    Friend WithEvents colAdvances As DataGridViewTextBoxColumn
    Friend WithEvents colBooking As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents cboClient As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents lblRefNo As Label
End Class
