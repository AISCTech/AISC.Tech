<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchCV
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.colCheckDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCVPrepDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAPNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReqNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgSearchCV = New System.Windows.Forms.DataGridView()
        Me.colCVNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgSearchCV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtFrom)
        Me.GroupBox1.Controls.Add(Me.dtTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 77)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter By Prepared Date"
        '
        'dtFrom
        '
        Me.dtFrom.Location = New System.Drawing.Point(58, 20)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtFrom.TabIndex = 0
        '
        'dtTo
        '
        Me.dtTo.Location = New System.Drawing.Point(58, 46)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(200, 20)
        Me.dtTo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(18, 50)
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
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From : "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSearch)
        Me.GroupBox2.Controls.Add(Me.txtRefNo)
        Me.GroupBox2.Controls.Add(Me.lblPrefix)
        Me.GroupBox2.Location = New System.Drawing.Point(290, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(461, 77)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search by CV No."
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(366, 29)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 427
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtRefNo
        '
        Me.txtRefNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNo.Location = New System.Drawing.Point(129, 30)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(231, 22)
        Me.txtRefNo.TabIndex = 426
        '
        'lblPrefix
        '
        Me.lblPrefix.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPrefix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrefix.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrefix.ForeColor = System.Drawing.Color.Black
        Me.lblPrefix.Location = New System.Drawing.Point(24, 30)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(105, 22)
        Me.lblPrefix.TabIndex = 425
        Me.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'colCheckDate
        '
        Me.colCheckDate.HeaderText = "Check Date"
        Me.colCheckDate.Name = "colCheckDate"
        Me.colCheckDate.ReadOnly = True
        Me.colCheckDate.Visible = False
        Me.colCheckDate.Width = 150
        '
        'colCVPrepDate
        '
        Me.colCVPrepDate.HeaderText = "CV Prep Date"
        Me.colCVPrepDate.Name = "colCVPrepDate"
        Me.colCVPrepDate.ReadOnly = True
        Me.colCVPrepDate.Width = 150
        '
        'colAPNo
        '
        Me.colAPNo.HeaderText = "APV No."
        Me.colAPNo.Name = "colAPNo"
        Me.colAPNo.ReadOnly = True
        Me.colAPNo.Width = 125
        '
        'colReqNo
        '
        Me.colReqNo.HeaderText = "Request No."
        Me.colReqNo.Name = "colReqNo"
        Me.colReqNo.ReadOnly = True
        Me.colReqNo.Width = 125
        '
        'dtgSearchCV
        '
        Me.dtgSearchCV.AllowUserToAddRows = False
        Me.dtgSearchCV.AllowUserToDeleteRows = False
        Me.dtgSearchCV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgSearchCV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCVNo, Me.colReqNo, Me.colAPNo, Me.colCVPrepDate, Me.colCheckDate})
        Me.dtgSearchCV.Location = New System.Drawing.Point(12, 99)
        Me.dtgSearchCV.Name = "dtgSearchCV"
        Me.dtgSearchCV.ReadOnly = True
        Me.dtgSearchCV.Size = New System.Drawing.Size(738, 289)
        Me.dtgSearchCV.TabIndex = 7
        '
        'colCVNo
        '
        Me.colCVNo.HeaderText = "CV No."
        Me.colCVNo.Name = "colCVNo"
        Me.colCVNo.ReadOnly = True
        Me.colCVNo.Width = 125
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmSearchCV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 399)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtgSearchCV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSearchCV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search CV"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgSearchCV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdSearch As Button
    Friend WithEvents txtRefNo As TextBox
    Friend WithEvents lblPrefix As Label
    Friend WithEvents colCheckDate As DataGridViewTextBoxColumn
    Friend WithEvents colCVPrepDate As DataGridViewTextBoxColumn
    Friend WithEvents colAPNo As DataGridViewTextBoxColumn
    Friend WithEvents colReqNo As DataGridViewTextBoxColumn
    Friend WithEvents dtgSearchCV As DataGridView
    Friend WithEvents colCVNo As DataGridViewTextBoxColumn
    Friend WithEvents ImageList1 As ImageList
End Class
