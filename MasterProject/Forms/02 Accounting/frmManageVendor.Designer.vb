<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageVendor
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
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtCreditLimitCurrency = New System.Windows.Forms.TextBox()
        Me.dgVendorParams = New System.Windows.Forms.DataGridView()
        Me.colSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colPK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboCreditLimitCurrency = New System.Windows.Forms.ComboBox()
        Me.txtCreditLimitAmount = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTerms = New System.Windows.Forms.TextBox()
        Me.txtSalesTax = New System.Windows.Forms.TextBox()
        Me.cboTerms = New System.Windows.Forms.ComboBox()
        Me.cboSalesTax = New System.Windows.Forms.ComboBox()
        Me.txtContactLandline = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtContactFaxNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCountryCode = New System.Windows.Forms.TextBox()
        Me.txtCityCode = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtZipCode = New System.Windows.Forms.TextBox()
        Me.cboCountry = New System.Windows.Forms.ComboBox()
        Me.cboCity = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVendorCode = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtVendorName = New System.Windows.Forms.TextBox()
        Me.txtTin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAddr1 = New System.Windows.Forms.TextBox()
        Me.txtBusStyle = New System.Windows.Forms.TextBox()
        Me.txtContactMobileNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtContactPerson = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dgVendorList = New System.Windows.Forms.DataGridView()
        Me.colClientCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientAddr1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientAddrCity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientAddrCityDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientAddrCountry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientAddrCountryDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientAddrZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientBusStyle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientContactMobileNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientContactFax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientContactLandline = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientContactPerson = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientTin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientSalesTax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientSalesTaxDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientTerms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientTermsDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientCreditLimitAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientCreditLimitCurrency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientCreditLimitCurrencyDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientModifiedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientModifiedByName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClientModifiedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrefix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        CType(Me.dgVendorParams, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgVendorList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPrefix
        '
        Me.txtPrefix.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrefix.Location = New System.Drawing.Point(279, 13)
        Me.txtPrefix.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(81, 20)
        Me.txtPrefix.TabIndex = 157
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(236, 14)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(37, 13)
        Me.Label32.TabIndex = 212
        Me.Label32.Text = "*Prefix"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(272, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(10, 13)
        Me.Label33.TabIndex = 213
        Me.Label33.Text = ":"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(12, 96)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(47, 13)
        Me.Label28.TabIndex = 210
        Me.Label28.Text = "*Country"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(90, 95)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(10, 13)
        Me.Label30.TabIndex = 211
        Me.Label30.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(13, 76)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 13)
        Me.Label24.TabIndex = 208
        Me.Label24.Text = "*City"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(91, 75)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(10, 13)
        Me.Label26.TabIndex = 209
        Me.Label26.Text = ":"
        '
        'txtCreditLimitCurrency
        '
        Me.txtCreditLimitCurrency.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreditLimitCurrency.Location = New System.Drawing.Point(17, 368)
        Me.txtCreditLimitCurrency.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCreditLimitCurrency.Multiline = True
        Me.txtCreditLimitCurrency.Name = "txtCreditLimitCurrency"
        Me.txtCreditLimitCurrency.ReadOnly = True
        Me.txtCreditLimitCurrency.Size = New System.Drawing.Size(20, 23)
        Me.txtCreditLimitCurrency.TabIndex = 206
        '
        'dgVendorParams
        '
        Me.dgVendorParams.AllowUserToAddRows = False
        Me.dgVendorParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVendorParams.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelected, Me.colPK, Me.colDescription})
        Me.dgVendorParams.Location = New System.Drawing.Point(159, 209)
        Me.dgVendorParams.Name = "dgVendorParams"
        Me.dgVendorParams.Size = New System.Drawing.Size(201, 198)
        Me.dgVendorParams.TabIndex = 188
        '
        'colSelected
        '
        Me.colSelected.HeaderText = "..."
        Me.colSelected.Name = "colSelected"
        Me.colSelected.Width = 25
        '
        'colPK
        '
        Me.colPK.HeaderText = "PK"
        Me.colPK.Name = "colPK"
        Me.colPK.Visible = False
        Me.colPK.Width = 50
        '
        'colDescription
        '
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.Width = 125
        '
        'cboCreditLimitCurrency
        '
        Me.cboCreditLimitCurrency.FormattingEnabled = True
        Me.cboCreditLimitCurrency.Location = New System.Drawing.Point(36, 368)
        Me.cboCreditLimitCurrency.Name = "cboCreditLimitCurrency"
        Me.cboCreditLimitCurrency.Size = New System.Drawing.Size(101, 21)
        Me.cboCreditLimitCurrency.TabIndex = 173
        '
        'txtCreditLimitAmount
        '
        Me.txtCreditLimitAmount.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreditLimitAmount.Location = New System.Drawing.Point(17, 330)
        Me.txtCreditLimitAmount.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCreditLimitAmount.Multiline = True
        Me.txtCreditLimitAmount.Name = "txtCreditLimitAmount"
        Me.txtCreditLimitAmount.Size = New System.Drawing.Size(120, 23)
        Me.txtCreditLimitAmount.TabIndex = 172
        Me.txtCreditLimitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(16, 350)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(97, 13)
        Me.Label29.TabIndex = 205
        Me.Label29.Text = "Credit Limit Amount"
        '
        'txtTerms
        '
        Me.txtTerms.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.Location = New System.Drawing.Point(18, 227)
        Me.txtTerms.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtTerms.Multiline = True
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.ReadOnly = True
        Me.txtTerms.Size = New System.Drawing.Size(29, 23)
        Me.txtTerms.TabIndex = 202
        '
        'txtSalesTax
        '
        Me.txtSalesTax.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesTax.Location = New System.Drawing.Point(18, 270)
        Me.txtSalesTax.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtSalesTax.Multiline = True
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.ReadOnly = True
        Me.txtSalesTax.Size = New System.Drawing.Size(29, 23)
        Me.txtSalesTax.TabIndex = 201
        '
        'cboTerms
        '
        Me.cboTerms.FormattingEnabled = True
        Me.cboTerms.Location = New System.Drawing.Point(46, 227)
        Me.cboTerms.Name = "cboTerms"
        Me.cboTerms.Size = New System.Drawing.Size(91, 21)
        Me.cboTerms.TabIndex = 170
        '
        'cboSalesTax
        '
        Me.cboSalesTax.FormattingEnabled = True
        Me.cboSalesTax.Location = New System.Drawing.Point(46, 270)
        Me.cboSalesTax.Name = "cboSalesTax"
        Me.cboSalesTax.Size = New System.Drawing.Size(91, 21)
        Me.cboSalesTax.TabIndex = 171
        '
        'txtContactLandline
        '
        Me.txtContactLandline.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactLandline.Location = New System.Drawing.Point(288, 152)
        Me.txtContactLandline.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtContactLandline.Name = "txtContactLandline"
        Me.txtContactLandline.Size = New System.Drawing.Size(72, 20)
        Me.txtContactLandline.TabIndex = 167
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(279, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 13)
        Me.Label11.TabIndex = 200
        Me.Label11.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(150, 154)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 13)
        Me.Label10.TabIndex = 198
        Me.Label10.Text = ":"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(101, 153)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 13)
        Me.Label22.TabIndex = 197
        Me.Label22.Text = "*Mobile No."
        '
        'txtContactFaxNo
        '
        Me.txtContactFaxNo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactFaxNo.Location = New System.Drawing.Point(288, 133)
        Me.txtContactFaxNo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtContactFaxNo.Name = "txtContactFaxNo"
        Me.txtContactFaxNo.Size = New System.Drawing.Size(72, 20)
        Me.txtContactFaxNo.TabIndex = 166
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(279, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 196
        Me.Label8.Text = ":"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(150, 136)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 13)
        Me.Label19.TabIndex = 194
        Me.Label19.Text = ":"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(101, 135)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 193
        Me.Label20.Text = "*Person"
        '
        'txtCountryCode
        '
        Me.txtCountryCode.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountryCode.Location = New System.Drawing.Point(102, 92)
        Me.txtCountryCode.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCountryCode.Multiline = True
        Me.txtCountryCode.Name = "txtCountryCode"
        Me.txtCountryCode.ReadOnly = True
        Me.txtCountryCode.Size = New System.Drawing.Size(29, 23)
        Me.txtCountryCode.TabIndex = 192
        '
        'txtCityCode
        '
        Me.txtCityCode.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCityCode.Location = New System.Drawing.Point(102, 70)
        Me.txtCityCode.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCityCode.Multiline = True
        Me.txtCityCode.Name = "txtCityCode"
        Me.txtCityCode.ReadOnly = True
        Me.txtCityCode.Size = New System.Drawing.Size(29, 23)
        Me.txtCityCode.TabIndex = 191
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(294, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(10, 13)
        Me.Label18.TabIndex = 190
        Me.Label18.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(252, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 13)
        Me.Label16.TabIndex = 189
        Me.Label16.Text = "Zip Code"
        '
        'txtZipCode
        '
        Me.txtZipCode.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipCode.Location = New System.Drawing.Point(305, 70)
        Me.txtZipCode.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtZipCode.Multiline = True
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(55, 23)
        Me.txtZipCode.TabIndex = 162
        '
        'cboCountry
        '
        Me.cboCountry.FormattingEnabled = True
        Me.cboCountry.Location = New System.Drawing.Point(130, 92)
        Me.cboCountry.Name = "cboCountry"
        Me.cboCountry.Size = New System.Drawing.Size(121, 21)
        Me.cboCountry.TabIndex = 160
        '
        'cboCity
        '
        Me.cboCity.FormattingEnabled = True
        Me.cboCity.Location = New System.Drawing.Point(130, 70)
        Me.cboCity.Name = "cboCity"
        Me.cboCity.Size = New System.Drawing.Size(121, 21)
        Me.cboCity.TabIndex = 161
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "Code"
        '
        'txtVendorCode
        '
        Me.txtVendorCode.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorCode.Location = New System.Drawing.Point(102, 13)
        Me.txtVendorCode.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtVendorCode.Name = "txtVendorCode"
        Me.txtVendorCode.ReadOnly = True
        Me.txtVendorCode.Size = New System.Drawing.Size(86, 20)
        Me.txtVendorCode.TabIndex = 174
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(90, 192)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 13)
        Me.Label14.TabIndex = 187
        Me.Label14.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(90, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 13)
        Me.Label17.TabIndex = 176
        Me.Label17.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 195)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(26, 13)
        Me.Label15.TabIndex = 186
        Me.Label15.Text = "*Tin"
        '
        'txtVendorName
        '
        Me.txtVendorName.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorName.Location = New System.Drawing.Point(102, 32)
        Me.txtVendorName.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(258, 20)
        Me.txtVendorName.TabIndex = 158
        '
        'txtTin
        '
        Me.txtTin.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTin.Location = New System.Drawing.Point(102, 190)
        Me.txtTin.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtTin.Name = "txtTin"
        Me.txtTin.Size = New System.Drawing.Size(258, 20)
        Me.txtTin.TabIndex = 169
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "*Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(90, 173)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(10, 13)
        Me.Label12.TabIndex = 185
        Me.Label12.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(90, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 178
        Me.Label2.Text = ":"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 176)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 184
        Me.Label13.Text = "*Email"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 179
        Me.Label5.Text = "*Primary Address"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(102, 171)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(258, 20)
        Me.txtEmail.TabIndex = 168
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(90, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = ":"
        '
        'txtAddr1
        '
        Me.txtAddr1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddr1.Location = New System.Drawing.Point(102, 51)
        Me.txtAddr1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtAddr1.Name = "txtAddr1"
        Me.txtAddr1.Size = New System.Drawing.Size(258, 20)
        Me.txtAddr1.TabIndex = 159
        '
        'txtBusStyle
        '
        Me.txtBusStyle.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusStyle.Location = New System.Drawing.Point(102, 114)
        Me.txtBusStyle.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtBusStyle.Name = "txtBusStyle"
        Me.txtBusStyle.Size = New System.Drawing.Size(258, 20)
        Me.txtBusStyle.TabIndex = 163
        '
        'txtContactMobileNo
        '
        Me.txtContactMobileNo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactMobileNo.Location = New System.Drawing.Point(161, 152)
        Me.txtContactMobileNo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtContactMobileNo.Name = "txtContactMobileNo"
        Me.txtContactMobileNo.Size = New System.Drawing.Size(77, 20)
        Me.txtContactMobileNo.TabIndex = 165
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 181
        Me.Label7.Text = "Business Style"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(90, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 13)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 183
        Me.Label9.Text = "Contact"
        '
        'txtContactPerson
        '
        Me.txtContactPerson.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactPerson.Location = New System.Drawing.Point(161, 133)
        Me.txtContactPerson.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.Size = New System.Drawing.Size(77, 20)
        Me.txtContactPerson.TabIndex = 164
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(16, 247)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(36, 13)
        Me.Label25.TabIndex = 203
        Me.Label25.Text = "Terms"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(15, 291)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(54, 13)
        Me.Label27.TabIndex = 204
        Me.Label27.Text = "Sales Tax"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(16, 389)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(49, 13)
        Me.Label31.TabIndex = 207
        Me.Label31.Text = "Currency"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(237, 135)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(44, 13)
        Me.Label21.TabIndex = 195
        Me.Label21.Text = "Fax No."
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(237, 154)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 13)
        Me.Label23.TabIndex = 199
        Me.Label23.Text = "*Landline"
        '
        'dgVendorList
        '
        Me.dgVendorList.AllowUserToAddRows = False
        Me.dgVendorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVendorList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colClientCode, Me.colClientName, Me.colClientAddr1, Me.colClientAddrCity, Me.colClientAddrCityDesc, Me.colClientAddrCountry, Me.colClientAddrCountryDesc, Me.colClientAddrZipCode, Me.colClientBusStyle, Me.colClientContactMobileNo, Me.colClientContactFax, Me.colClientContactLandline, Me.colClientContactPerson, Me.colClientEmail, Me.colClientTin, Me.colClientSalesTax, Me.colClientSalesTaxDesc, Me.colClientTerms, Me.colClientTermsDesc, Me.colClientCreditLimitAmt, Me.colClientCreditLimitCurrency, Me.colClientCreditLimitCurrencyDesc, Me.colClientModifiedBy, Me.colClientModifiedByName, Me.colClientModifiedDate, Me.colPrefix})
        Me.dgVendorList.Location = New System.Drawing.Point(375, 53)
        Me.dgVendorList.Name = "dgVendorList"
        Me.dgVendorList.Size = New System.Drawing.Size(473, 358)
        Me.dgVendorList.TabIndex = 214
        '
        'colClientCode
        '
        Me.colClientCode.HeaderText = "Code"
        Me.colClientCode.Name = "colClientCode"
        '
        'colClientName
        '
        Me.colClientName.HeaderText = "Name"
        Me.colClientName.Name = "colClientName"
        '
        'colClientAddr1
        '
        Me.colClientAddr1.HeaderText = "Address"
        Me.colClientAddr1.Name = "colClientAddr1"
        '
        'colClientAddrCity
        '
        Me.colClientAddrCity.HeaderText = "City Code"
        Me.colClientAddrCity.Name = "colClientAddrCity"
        '
        'colClientAddrCityDesc
        '
        Me.colClientAddrCityDesc.HeaderText = "City Desc"
        Me.colClientAddrCityDesc.Name = "colClientAddrCityDesc"
        '
        'colClientAddrCountry
        '
        Me.colClientAddrCountry.HeaderText = "Country Code"
        Me.colClientAddrCountry.Name = "colClientAddrCountry"
        '
        'colClientAddrCountryDesc
        '
        Me.colClientAddrCountryDesc.HeaderText = "Country Desc"
        Me.colClientAddrCountryDesc.Name = "colClientAddrCountryDesc"
        '
        'colClientAddrZipCode
        '
        Me.colClientAddrZipCode.HeaderText = "Zip Code"
        Me.colClientAddrZipCode.Name = "colClientAddrZipCode"
        '
        'colClientBusStyle
        '
        Me.colClientBusStyle.HeaderText = "Business Style"
        Me.colClientBusStyle.Name = "colClientBusStyle"
        '
        'colClientContactMobileNo
        '
        Me.colClientContactMobileNo.HeaderText = "Contact Moblie No"
        Me.colClientContactMobileNo.Name = "colClientContactMobileNo"
        '
        'colClientContactFax
        '
        Me.colClientContactFax.HeaderText = "Contact Fax No."
        Me.colClientContactFax.Name = "colClientContactFax"
        '
        'colClientContactLandline
        '
        Me.colClientContactLandline.HeaderText = "Contact Landline"
        Me.colClientContactLandline.Name = "colClientContactLandline"
        '
        'colClientContactPerson
        '
        Me.colClientContactPerson.HeaderText = "Contact Person"
        Me.colClientContactPerson.Name = "colClientContactPerson"
        '
        'colClientEmail
        '
        Me.colClientEmail.HeaderText = "Email"
        Me.colClientEmail.Name = "colClientEmail"
        '
        'colClientTin
        '
        Me.colClientTin.HeaderText = "Tin"
        Me.colClientTin.Name = "colClientTin"
        '
        'colClientSalesTax
        '
        Me.colClientSalesTax.HeaderText = "Sales Tax"
        Me.colClientSalesTax.Name = "colClientSalesTax"
        '
        'colClientSalesTaxDesc
        '
        Me.colClientSalesTaxDesc.HeaderText = "Sales Tax Desc"
        Me.colClientSalesTaxDesc.Name = "colClientSalesTaxDesc"
        '
        'colClientTerms
        '
        Me.colClientTerms.HeaderText = "Terms"
        Me.colClientTerms.Name = "colClientTerms"
        '
        'colClientTermsDesc
        '
        Me.colClientTermsDesc.HeaderText = "Terms Desc"
        Me.colClientTermsDesc.Name = "colClientTermsDesc"
        '
        'colClientCreditLimitAmt
        '
        Me.colClientCreditLimitAmt.HeaderText = "Credit Limit Amount"
        Me.colClientCreditLimitAmt.Name = "colClientCreditLimitAmt"
        '
        'colClientCreditLimitCurrency
        '
        Me.colClientCreditLimitCurrency.HeaderText = "Credit Limit Currency"
        Me.colClientCreditLimitCurrency.Name = "colClientCreditLimitCurrency"
        '
        'colClientCreditLimitCurrencyDesc
        '
        Me.colClientCreditLimitCurrencyDesc.HeaderText = "Credit Limit Currency Desc"
        Me.colClientCreditLimitCurrencyDesc.Name = "colClientCreditLimitCurrencyDesc"
        '
        'colClientModifiedBy
        '
        Me.colClientModifiedBy.HeaderText = "Modified By"
        Me.colClientModifiedBy.Name = "colClientModifiedBy"
        '
        'colClientModifiedByName
        '
        Me.colClientModifiedByName.HeaderText = "Modified By Name"
        Me.colClientModifiedByName.Name = "colClientModifiedByName"
        '
        'colClientModifiedDate
        '
        Me.colClientModifiedDate.HeaderText = "Modified Date"
        Me.colClientModifiedDate.Name = "colClientModifiedDate"
        '
        'colPrefix
        '
        Me.colPrefix.HeaderText = "Prefix"
        Me.colPrefix.Name = "colPrefix"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(373, 12)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(189, 13)
        Me.Label38.TabIndex = 509
        Me.Label38.Text = "Type any characters to filter below grid"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(375, 30)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(401, 20)
        Me.txtSearch.TabIndex = 510
        '
        'frmManageVendor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 421)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.dgVendorList)
        Me.Controls.Add(Me.txtContactMobileNo)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtCreditLimitCurrency)
        Me.Controls.Add(Me.dgVendorParams)
        Me.Controls.Add(Me.cboCreditLimitCurrency)
        Me.Controls.Add(Me.txtCreditLimitAmount)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtTerms)
        Me.Controls.Add(Me.txtSalesTax)
        Me.Controls.Add(Me.cboTerms)
        Me.Controls.Add(Me.cboSalesTax)
        Me.Controls.Add(Me.txtContactLandline)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtContactFaxNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtCountryCode)
        Me.Controls.Add(Me.txtCityCode)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtZipCode)
        Me.Controls.Add(Me.cboCountry)
        Me.Controls.Add(Me.cboCity)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtVendorCode)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtVendorName)
        Me.Controls.Add(Me.txtTin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAddr1)
        Me.Controls.Add(Me.txtBusStyle)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtContactPerson)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label23)
        Me.Name = "frmManageVendor"
        Me.Text = "Manage Vendor/Supplier"
        CType(Me.dgVendorParams, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgVendorList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPrefix As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtCreditLimitCurrency As TextBox
    Friend WithEvents dgVendorParams As DataGridView
    Friend WithEvents colSelected As DataGridViewCheckBoxColumn
    Friend WithEvents colPK As DataGridViewTextBoxColumn
    Friend WithEvents colDescription As DataGridViewTextBoxColumn
    Friend WithEvents cboCreditLimitCurrency As ComboBox
    Friend WithEvents txtCreditLimitAmount As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtTerms As TextBox
    Friend WithEvents txtSalesTax As TextBox
    Friend WithEvents cboTerms As ComboBox
    Friend WithEvents cboSalesTax As ComboBox
    Friend WithEvents txtContactLandline As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtContactFaxNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtCountryCode As TextBox
    Friend WithEvents txtCityCode As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtZipCode As TextBox
    Friend WithEvents cboCountry As ComboBox
    Friend WithEvents cboCity As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtVendorCode As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtVendorName As TextBox
    Friend WithEvents txtTin As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAddr1 As TextBox
    Friend WithEvents txtBusStyle As TextBox
    Friend WithEvents txtContactMobileNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtContactPerson As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents dgVendorList As DataGridView
    Friend WithEvents colClientCode As DataGridViewTextBoxColumn
    Friend WithEvents colClientName As DataGridViewTextBoxColumn
    Friend WithEvents colClientAddr1 As DataGridViewTextBoxColumn
    Friend WithEvents colClientAddrCity As DataGridViewTextBoxColumn
    Friend WithEvents colClientAddrCityDesc As DataGridViewTextBoxColumn
    Friend WithEvents colClientAddrCountry As DataGridViewTextBoxColumn
    Friend WithEvents colClientAddrCountryDesc As DataGridViewTextBoxColumn
    Friend WithEvents colClientAddrZipCode As DataGridViewTextBoxColumn
    Friend WithEvents colClientBusStyle As DataGridViewTextBoxColumn
    Friend WithEvents colClientContactMobileNo As DataGridViewTextBoxColumn
    Friend WithEvents colClientContactFax As DataGridViewTextBoxColumn
    Friend WithEvents colClientContactLandline As DataGridViewTextBoxColumn
    Friend WithEvents colClientContactPerson As DataGridViewTextBoxColumn
    Friend WithEvents colClientEmail As DataGridViewTextBoxColumn
    Friend WithEvents colClientTin As DataGridViewTextBoxColumn
    Friend WithEvents colClientSalesTax As DataGridViewTextBoxColumn
    Friend WithEvents colClientSalesTaxDesc As DataGridViewTextBoxColumn
    Friend WithEvents colClientTerms As DataGridViewTextBoxColumn
    Friend WithEvents colClientTermsDesc As DataGridViewTextBoxColumn
    Friend WithEvents colClientCreditLimitAmt As DataGridViewTextBoxColumn
    Friend WithEvents colClientCreditLimitCurrency As DataGridViewTextBoxColumn
    Friend WithEvents colClientCreditLimitCurrencyDesc As DataGridViewTextBoxColumn
    Friend WithEvents colClientModifiedBy As DataGridViewTextBoxColumn
    Friend WithEvents colClientModifiedByName As DataGridViewTextBoxColumn
    Friend WithEvents colClientModifiedDate As DataGridViewTextBoxColumn
    Friend WithEvents colPrefix As DataGridViewTextBoxColumn
    Friend WithEvents Label38 As Label
    Friend WithEvents txtSearch As TextBox
End Class
