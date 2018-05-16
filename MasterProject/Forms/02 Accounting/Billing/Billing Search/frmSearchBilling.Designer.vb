<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchBilling
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
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdvanceSearch = New System.Windows.Forms.Button()
        Me.dtgMBL = New System.Windows.Forms.DataGridView()
        Me.colMBL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMBLBook = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optHBL = New System.Windows.Forms.RadioButton()
        Me.optMBL = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.optRefNo = New System.Windows.Forms.RadioButton()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgHBL = New System.Windows.Forms.DataGridView()
        Me.colHBL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSOA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBooking = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrepDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrepBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgMBL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgHBL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "HBL"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'btnAdvanceSearch
        '
        Me.btnAdvanceSearch.Location = New System.Drawing.Point(389, 13)
        Me.btnAdvanceSearch.Name = "btnAdvanceSearch"
        Me.btnAdvanceSearch.Size = New System.Drawing.Size(123, 23)
        Me.btnAdvanceSearch.TabIndex = 6
        Me.btnAdvanceSearch.Text = "Advance Search"
        Me.btnAdvanceSearch.UseVisualStyleBackColor = True
        '
        'dtgMBL
        '
        Me.dtgMBL.AllowUserToAddRows = False
        Me.dtgMBL.AllowUserToDeleteRows = False
        Me.dtgMBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgMBL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMBL, Me.colMBLBook})
        Me.dtgMBL.Location = New System.Drawing.Point(6, 75)
        Me.dtgMBL.MultiSelect = False
        Me.dtgMBL.Name = "dtgMBL"
        Me.dtgMBL.ReadOnly = True
        Me.dtgMBL.Size = New System.Drawing.Size(506, 146)
        Me.dtgMBL.TabIndex = 9
        '
        'colMBL
        '
        Me.colMBL.HeaderText = "Master BL"
        Me.colMBL.Name = "colMBL"
        Me.colMBL.ReadOnly = True
        Me.colMBL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.colMBL.Width = 335
        '
        'colMBLBook
        '
        Me.colMBLBook.HeaderText = "Booking No."
        Me.colMBLBook.Name = "colMBLBook"
        Me.colMBLBook.ReadOnly = True
        Me.colMBLBook.Visible = False
        '
        'optHBL
        '
        Me.optHBL.AutoSize = True
        Me.optHBL.Location = New System.Drawing.Point(263, 19)
        Me.optHBL.Name = "optHBL"
        Me.optHBL.Size = New System.Drawing.Size(72, 17)
        Me.optHBL.TabIndex = 5
        Me.optHBL.Text = "House BL"
        Me.optHBL.UseVisualStyleBackColor = True
        '
        'optMBL
        '
        Me.optMBL.AutoSize = True
        Me.optMBL.Location = New System.Drawing.Point(144, 19)
        Me.optMBL.Name = "optMBL"
        Me.optMBL.Size = New System.Drawing.Size(73, 17)
        Me.optMBL.TabIndex = 4
        Me.optMBL.Text = "Master BL"
        Me.optMBL.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(138, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "To : "
        '
        'optRefNo
        '
        Me.optRefNo.AutoSize = True
        Me.optRefNo.Checked = True
        Me.optRefNo.Location = New System.Drawing.Point(13, 19)
        Me.optRefNo.Name = "optRefNo"
        Me.optRefNo.Size = New System.Drawing.Size(95, 17)
        Me.optRefNo.TabIndex = 3
        Me.optRefNo.TabStop = True
        Me.optRefNo.Text = "Billing Ref. No."
        Me.optRefNo.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Ref. No."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 125
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(100, 42)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(412, 26)
        Me.txtSearch.TabIndex = 0
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Prep. By"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "C.I. No."
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'dtgHBL
        '
        Me.dtgHBL.AllowUserToAddRows = False
        Me.dtgHBL.AllowUserToDeleteRows = False
        Me.dtgHBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgHBL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colHBL, Me.colRefNo, Me.colCI, Me.colSOA, Me.colBooking, Me.colClient, Me.colPrepDate, Me.colPrepBy})
        Me.dtgHBL.Location = New System.Drawing.Point(6, 227)
        Me.dtgHBL.MultiSelect = False
        Me.dtgHBL.Name = "dtgHBL"
        Me.dtgHBL.ReadOnly = True
        Me.dtgHBL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgHBL.Size = New System.Drawing.Size(506, 146)
        Me.dtgHBL.TabIndex = 10
        '
        'colHBL
        '
        Me.colHBL.Frozen = True
        Me.colHBL.HeaderText = "HBL"
        Me.colHBL.Name = "colHBL"
        Me.colHBL.ReadOnly = True
        Me.colHBL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.colHBL.Width = 150
        '
        'colRefNo
        '
        Me.colRefNo.HeaderText = "Ref. No."
        Me.colRefNo.Name = "colRefNo"
        Me.colRefNo.ReadOnly = True
        Me.colRefNo.Width = 125
        '
        'colCI
        '
        Me.colCI.HeaderText = "C.I. No."
        Me.colCI.Name = "colCI"
        Me.colCI.ReadOnly = True
        '
        'colSOA
        '
        Me.colSOA.HeaderText = "S.O.A. No."
        Me.colSOA.Name = "colSOA"
        Me.colSOA.ReadOnly = True
        '
        'colBooking
        '
        Me.colBooking.HeaderText = "Booking No."
        Me.colBooking.Name = "colBooking"
        Me.colBooking.ReadOnly = True
        Me.colBooking.Width = 125
        '
        'colClient
        '
        Me.colClient.HeaderText = "Client Name"
        Me.colClient.Name = "colClient"
        Me.colClient.ReadOnly = True
        Me.colClient.Width = 275
        '
        'colPrepDate
        '
        Me.colPrepDate.HeaderText = "Prep. Date "
        Me.colPrepDate.Name = "colPrepDate"
        Me.colPrepDate.ReadOnly = True
        Me.colPrepDate.Width = 150
        '
        'colPrepBy
        '
        Me.colPrepBy.HeaderText = "Prep. By"
        Me.colPrepBy.Name = "colPrepBy"
        Me.colPrepBy.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Master BL"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn9.Width = 335
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Prep. Date "
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "S.O.A. No."
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Client Name"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 275
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAdvanceSearch)
        Me.GroupBox2.Controls.Add(Me.optHBL)
        Me.GroupBox2.Controls.Add(Me.optMBL)
        Me.GroupBox2.Controls.Add(Me.optRefNo)
        Me.GroupBox2.Controls.Add(Me.lblPrefix)
        Me.GroupBox2.Controls.Add(Me.txtSearch)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(518, 74)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Quick Search"
        '
        'lblPrefix
        '
        Me.lblPrefix.BackColor = System.Drawing.Color.LightSkyBlue
        Me.lblPrefix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrefix.Location = New System.Drawing.Point(13, 42)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(87, 26)
        Me.lblPrefix.TabIndex = 1
        Me.lblPrefix.Text = "BIFMNL"
        Me.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Booking No."
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 125
        '
        'dtFrom
        '
        Me.dtFrom.Location = New System.Drawing.Point(173, 19)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtFrom.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtgHBL)
        Me.GroupBox1.Controls.Add(Me.dtgMBL)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtTo)
        Me.GroupBox1.Controls.Add(Me.dtFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(518, 385)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Advance Search"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(128, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "From : "
        '
        'dtTo
        '
        Me.dtTo.Location = New System.Drawing.Point(173, 45)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(200, 20)
        Me.dtTo.TabIndex = 6
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Booking No."
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'frmSearchBilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 508)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSearchBilling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Billing"
        CType(Me.dtgMBL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgHBL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents btnAdvanceSearch As Button
    Friend WithEvents dtgMBL As DataGridView
    Friend WithEvents colMBL As DataGridViewTextBoxColumn
    Friend WithEvents colMBLBook As DataGridViewTextBoxColumn
    Friend WithEvents optHBL As RadioButton
    Friend WithEvents optMBL As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents optRefNo As RadioButton
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents dtgHBL As DataGridView
    Friend WithEvents colHBL As DataGridViewTextBoxColumn
    Friend WithEvents colRefNo As DataGridViewTextBoxColumn
    Friend WithEvents colCI As DataGridViewTextBoxColumn
    Friend WithEvents colSOA As DataGridViewTextBoxColumn
    Friend WithEvents colBooking As DataGridViewTextBoxColumn
    Friend WithEvents colClient As DataGridViewTextBoxColumn
    Friend WithEvents colPrepDate As DataGridViewTextBoxColumn
    Friend WithEvents colPrepBy As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblPrefix As Label
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
End Class
