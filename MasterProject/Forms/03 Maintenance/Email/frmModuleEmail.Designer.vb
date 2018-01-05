<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModuleEmail
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
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboCompany = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboModule = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.colSSL = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colPort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEmailAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModuleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModuleID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompanyCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgModuleEmail = New System.Windows.Forms.DataGridView()
        Me.cboEmailAddress = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgModuleEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(21, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Company"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(115, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = ":"
        '
        'cboCompany
        '
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.IntegralHeight = False
        Me.cboCompany.Location = New System.Drawing.Point(131, 12)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(297, 21)
        Me.cboCompany.TabIndex = 26
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(21, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Module"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(115, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = ":"
        '
        'cboModule
        '
        Me.cboModule.FormattingEnabled = True
        Me.cboModule.IntegralHeight = False
        Me.cboModule.Location = New System.Drawing.Point(131, 32)
        Me.cboModule.Name = "cboModule"
        Me.cboModule.Size = New System.Drawing.Size(297, 21)
        Me.cboModule.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Email Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(115, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = ":"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.cboEmailAddress)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cboModule)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.cboCompany)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(866, 87)
        Me.Panel1.TabIndex = 0
        '
        'colSSL
        '
        Me.colSSL.HeaderText = "Enable SSL"
        Me.colSSL.Name = "colSSL"
        Me.colSSL.ReadOnly = True
        '
        'colPort
        '
        Me.colPort.HeaderText = "SMTP Port"
        Me.colPort.Name = "colPort"
        Me.colPort.ReadOnly = True
        '
        'colHost
        '
        Me.colHost.HeaderText = "SMTP Host"
        Me.colHost.Name = "colHost"
        Me.colHost.ReadOnly = True
        Me.colHost.Width = 200
        '
        'colEmailAddress
        '
        Me.colEmailAddress.HeaderText = "Email"
        Me.colEmailAddress.Name = "colEmailAddress"
        Me.colEmailAddress.ReadOnly = True
        Me.colEmailAddress.Width = 200
        '
        'colModuleName
        '
        Me.colModuleName.HeaderText = "Module"
        Me.colModuleName.Name = "colModuleName"
        Me.colModuleName.ReadOnly = True
        Me.colModuleName.Width = 300
        '
        'colModuleID
        '
        Me.colModuleID.HeaderText = "Module ID"
        Me.colModuleID.Name = "colModuleID"
        Me.colModuleID.ReadOnly = True
        Me.colModuleID.Visible = False
        '
        'colCompanyName
        '
        Me.colCompanyName.HeaderText = "Company"
        Me.colCompanyName.Name = "colCompanyName"
        Me.colCompanyName.ReadOnly = True
        Me.colCompanyName.Width = 400
        '
        'colCompanyCode
        '
        Me.colCompanyCode.HeaderText = "Company Code"
        Me.colCompanyCode.Name = "colCompanyCode"
        Me.colCompanyCode.ReadOnly = True
        Me.colCompanyCode.Visible = False
        '
        'colID
        '
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        Me.colID.Width = 75
        '
        'dtgModuleEmail
        '
        Me.dtgModuleEmail.AllowUserToAddRows = False
        Me.dtgModuleEmail.AllowUserToDeleteRows = False
        Me.dtgModuleEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgModuleEmail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colCompanyCode, Me.colCompanyName, Me.colModuleID, Me.colModuleName, Me.colEmailAddress, Me.colHost, Me.colPort, Me.colSSL})
        Me.dtgModuleEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgModuleEmail.Location = New System.Drawing.Point(0, 87)
        Me.dtgModuleEmail.Name = "dtgModuleEmail"
        Me.dtgModuleEmail.ReadOnly = True
        Me.dtgModuleEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgModuleEmail.Size = New System.Drawing.Size(866, 387)
        Me.dtgModuleEmail.TabIndex = 1
        '
        'cboEmailAddress
        '
        Me.cboEmailAddress.FormattingEnabled = True
        Me.cboEmailAddress.IntegralHeight = False
        Me.cboEmailAddress.Location = New System.Drawing.Point(131, 52)
        Me.cboEmailAddress.Name = "cboEmailAddress"
        Me.cboEmailAddress.Size = New System.Drawing.Size(297, 21)
        Me.cboEmailAddress.TabIndex = 49
        '
        'frmModuleEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(866, 474)
        Me.Controls.Add(Me.dtgModuleEmail)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmModuleEmail"
        Me.Text = "Assign Email per Module"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgModuleEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cboCompany As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cboModule As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents colSSL As DataGridViewCheckBoxColumn
    Friend WithEvents colPort As DataGridViewTextBoxColumn
    Friend WithEvents colHost As DataGridViewTextBoxColumn
    Friend WithEvents colEmailAddress As DataGridViewTextBoxColumn
    Friend WithEvents colModuleName As DataGridViewTextBoxColumn
    Friend WithEvents colModuleID As DataGridViewTextBoxColumn
    Friend WithEvents colCompanyName As DataGridViewTextBoxColumn
    Friend WithEvents colCompanyCode As DataGridViewTextBoxColumn
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents dtgModuleEmail As DataGridView
    Friend WithEvents cboEmailAddress As ComboBox
End Class
