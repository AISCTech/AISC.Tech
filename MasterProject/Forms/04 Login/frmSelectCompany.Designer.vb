<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectCompany
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
        Me.dtgCompany = New System.Windows.Forms.DataGridView()
        Me.colCompanyCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompanyLogoFilename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSiteCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSiteName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgCompany
        '
        Me.dtgCompany.AllowUserToAddRows = False
        Me.dtgCompany.AllowUserToDeleteRows = False
        Me.dtgCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCompany.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCompanyCode, Me.colCompanyName, Me.colCompanyLogoFilename, Me.colSiteCode, Me.colSiteName})
        Me.dtgCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgCompany.Location = New System.Drawing.Point(0, 0)
        Me.dtgCompany.MultiSelect = False
        Me.dtgCompany.Name = "dtgCompany"
        Me.dtgCompany.ReadOnly = True
        Me.dtgCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgCompany.Size = New System.Drawing.Size(636, 290)
        Me.dtgCompany.TabIndex = 0
        '
        'colCompanyCode
        '
        Me.colCompanyCode.HeaderText = "Code"
        Me.colCompanyCode.Name = "colCompanyCode"
        Me.colCompanyCode.ReadOnly = True
        Me.colCompanyCode.Width = 75
        '
        'colCompanyName
        '
        Me.colCompanyName.HeaderText = "Company"
        Me.colCompanyName.Name = "colCompanyName"
        Me.colCompanyName.ReadOnly = True
        Me.colCompanyName.Width = 350
        '
        'colCompanyLogoFilename
        '
        Me.colCompanyLogoFilename.HeaderText = "Logo File Name"
        Me.colCompanyLogoFilename.Name = "colCompanyLogoFilename"
        Me.colCompanyLogoFilename.ReadOnly = True
        Me.colCompanyLogoFilename.Visible = False
        '
        'colSiteCode
        '
        Me.colSiteCode.HeaderText = "Site Code"
        Me.colSiteCode.Name = "colSiteCode"
        Me.colSiteCode.ReadOnly = True
        Me.colSiteCode.Visible = False
        '
        'colSiteName
        '
        Me.colSiteName.HeaderText = "Site"
        Me.colSiteName.Name = "colSiteName"
        Me.colSiteName.ReadOnly = True
        Me.colSiteName.Width = 125
        '
        'frmSelectCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 290)
        Me.Controls.Add(Me.dtgCompany)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSelectCompany"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Company"
        CType(Me.dtgCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtgCompany As DataGridView
    Friend WithEvents colCompanyCode As DataGridViewTextBoxColumn
    Friend WithEvents colCompanyName As DataGridViewTextBoxColumn
    Friend WithEvents colCompanyLogoFilename As DataGridViewTextBoxColumn
    Friend WithEvents colSiteCode As DataGridViewTextBoxColumn
    Friend WithEvents colSiteName As DataGridViewTextBoxColumn
End Class
