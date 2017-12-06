<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPettyCashPost
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPettyCashPost))
        Me.dgDetails = New System.Windows.Forms.DataGridView()
        Me.btClear = New System.Windows.Forms.Button()
        Me.btCredit = New System.Windows.Forms.Button()
        Me.dgPost = New System.Windows.Forms.DataGridView()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.btRemove = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtReceipt = New System.Windows.Forms.DateTimePicker()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtDateLiquidation = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btClose = New System.Windows.Forms.Button()
        Me.btPost = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lblDebit = New System.Windows.Forms.Label()
        Me.lblCredit = New System.Windows.Forms.Label()
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgDetails
        '
        Me.dgDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetails.Location = New System.Drawing.Point(12, 12)
        Me.dgDetails.Name = "dgDetails"
        Me.dgDetails.Size = New System.Drawing.Size(874, 184)
        Me.dgDetails.TabIndex = 3
        '
        'btClear
        '
        Me.btClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btClear.Image = CType(resources.GetObject("btClear.Image"), System.Drawing.Image)
        Me.btClear.Location = New System.Drawing.Point(74, 223)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(32, 24)
        Me.btClear.TabIndex = 432
        Me.btClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btClear.UseVisualStyleBackColor = True
        '
        'btCredit
        '
        Me.btCredit.AccessibleDescription = ""
        Me.btCredit.AccessibleName = ""
        Me.btCredit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btCredit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCredit.Location = New System.Drawing.Point(105, 223)
        Me.btCredit.Name = "btCredit"
        Me.btCredit.Size = New System.Drawing.Size(96, 24)
        Me.btCredit.TabIndex = 431
        Me.btCredit.Text = "Credit"
        Me.btCredit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btCredit.UseVisualStyleBackColor = True
        '
        'dgPost
        '
        Me.dgPost.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPost.Location = New System.Drawing.Point(12, 246)
        Me.dgPost.Name = "dgPost"
        Me.dgPost.Size = New System.Drawing.Size(874, 182)
        Me.dgPost.TabIndex = 430
        '
        'btAdd
        '
        Me.btAdd.AccessibleDescription = ""
        Me.btAdd.AccessibleName = ""
        Me.btAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btAdd.Image = CType(resources.GetObject("btAdd.Image"), System.Drawing.Image)
        Me.btAdd.Location = New System.Drawing.Point(12, 223)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(32, 24)
        Me.btAdd.TabIndex = 428
        Me.btAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'btRemove
        '
        Me.btRemove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btRemove.Image = CType(resources.GetObject("btRemove.Image"), System.Drawing.Image)
        Me.btRemove.Location = New System.Drawing.Point(43, 223)
        Me.btRemove.Name = "btRemove"
        Me.btRemove.Size = New System.Drawing.Size(32, 24)
        Me.btRemove.TabIndex = 429
        Me.btRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btRemove.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(16, 207)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(68, 13)
        Me.Label24.TabIndex = 427
        Me.Label24.Text = "Acount Title:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(538, 220)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 16)
        Me.Label4.TabIndex = 461
        Me.Label4.Text = "Liquidation Date:"
        '
        'dtReceipt
        '
        Me.dtReceipt.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.dtReceipt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtReceipt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dtReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtReceipt.Location = New System.Drawing.Point(862, 219)
        Me.dtReceipt.Name = "dtReceipt"
        Me.dtReceipt.Size = New System.Drawing.Size(24, 21)
        Me.dtReceipt.TabIndex = 459
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotal.Location = New System.Drawing.Point(662, 200)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(224, 20)
        Me.txtTotal.TabIndex = 457
        '
        'txtDateLiquidation
        '
        Me.txtDateLiquidation.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtDateLiquidation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateLiquidation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtDateLiquidation.Location = New System.Drawing.Point(662, 219)
        Me.txtDateLiquidation.Name = "txtDateLiquidation"
        Me.txtDateLiquidation.ReadOnly = True
        Me.txtDateLiquidation.Size = New System.Drawing.Size(207, 21)
        Me.txtDateLiquidation.TabIndex = 460
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(485, 200)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 16)
        Me.Label2.TabIndex = 458
        Me.Label2.Text = "Total Liquidated Amount:"
        '
        'btClose
        '
        Me.btClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClose.ForeColor = System.Drawing.Color.DarkBlue
        Me.btClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btClose.Location = New System.Drawing.Point(806, 469)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(80, 24)
        Me.btClose.TabIndex = 476
        Me.btClose.Text = "Close"
        Me.btClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btClose.UseVisualStyleBackColor = True
        '
        'btPost
        '
        Me.btPost.Enabled = False
        Me.btPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPost.ForeColor = System.Drawing.Color.DarkBlue
        Me.btPost.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btPost.Location = New System.Drawing.Point(720, 469)
        Me.btPost.Name = "btPost"
        Me.btPost.Size = New System.Drawing.Size(80, 24)
        Me.btPost.TabIndex = 475
        Me.btPost.Text = "Post"
        Me.btPost.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btPost.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(424, 431)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(72, 13)
        Me.Label38.TabIndex = 501
        Me.Label38.Text = "Total Debit:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(704, 431)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(76, 13)
        Me.Label39.TabIndex = 502
        Me.Label39.Text = "Total Credit:"
        '
        'lblDebit
        '
        Me.lblDebit.AutoSize = True
        Me.lblDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebit.Location = New System.Drawing.Point(568, 431)
        Me.lblDebit.Name = "lblDebit"
        Me.lblDebit.Size = New System.Drawing.Size(36, 16)
        Me.lblDebit.TabIndex = 499
        Me.lblDebit.Text = "0.00"
        '
        'lblCredit
        '
        Me.lblCredit.AutoSize = True
        Me.lblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredit.Location = New System.Drawing.Point(848, 431)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Size = New System.Drawing.Size(36, 16)
        Me.lblCredit.TabIndex = 500
        Me.lblCredit.Text = "0.00"
        '
        'frmPettyCashPost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 500)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.lblDebit)
        Me.Controls.Add(Me.lblCredit)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btPost)
        Me.Controls.Add(Me.txtDateLiquidation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtReceipt)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btClear)
        Me.Controls.Add(Me.btCredit)
        Me.Controls.Add(Me.dgPost)
        Me.Controls.Add(Me.btAdd)
        Me.Controls.Add(Me.btRemove)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.dgDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPettyCashPost"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Petty Cash Post"
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgDetails As DataGridView
    Friend WithEvents btClear As Button
    Friend WithEvents btCredit As Button
    Friend WithEvents dgPost As DataGridView
    Friend WithEvents btAdd As Button
    Friend WithEvents btRemove As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtReceipt As DateTimePicker
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtDateLiquidation As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btClose As Button
    Friend WithEvents btPost As Button
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents lblDebit As Label
    Friend WithEvents lblCredit As Label
End Class
