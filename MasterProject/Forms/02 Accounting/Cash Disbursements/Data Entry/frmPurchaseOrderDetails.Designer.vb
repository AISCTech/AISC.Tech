<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseOrderDetails
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
        Me.btPrintPreview = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtSupplierAdd = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.cboTerms = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDeliverTo = New System.Windows.Forms.TextBox()
        Me.dtDeliver = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRequestedBy = New System.Windows.Forms.TextBox()
        Me.txtDeliverOn = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btPrintPreview
        '
        Me.btPrintPreview.Location = New System.Drawing.Point(267, 387)
        Me.btPrintPreview.Name = "btPrintPreview"
        Me.btPrintPreview.Size = New System.Drawing.Size(97, 40)
        Me.btPrintPreview.TabIndex = 496
        Me.btPrintPreview.Text = "Print Preview"
        Me.btPrintPreview.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(12, 6)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(93, 15)
        Me.Label33.TabIndex = 492
        Me.Label33.Text = "Supplier Address:"
        '
        'txtSupplierAdd
        '
        Me.txtSupplierAdd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSupplierAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierAdd.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtSupplierAdd.Location = New System.Drawing.Point(12, 24)
        Me.txtSupplierAdd.Multiline = True
        Me.txtSupplierAdd.Name = "txtSupplierAdd"
        Me.txtSupplierAdd.Size = New System.Drawing.Size(353, 104)
        Me.txtSupplierAdd.TabIndex = 493
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(11, 299)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(54, 15)
        Me.Label34.TabIndex = 494
        Me.Label34.Text = "Remarks:"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRemarks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtRemarks.Location = New System.Drawing.Point(11, 317)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(353, 64)
        Me.txtRemarks.TabIndex = 495
        '
        'cboTerms
        '
        Me.cboTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerms.FormattingEnabled = True
        Me.cboTerms.Location = New System.Drawing.Point(11, 269)
        Me.cboTerms.Name = "cboTerms"
        Me.cboTerms.Size = New System.Drawing.Size(149, 21)
        Me.cboTerms.TabIndex = 491
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(11, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 486
        Me.Label4.Text = "Deliver To:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(11, 251)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 15)
        Me.Label14.TabIndex = 490
        Me.Label14.Text = "Terms:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(11, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 15)
        Me.Label5.TabIndex = 488
        Me.Label5.Text = "Deliver On:"
        '
        'txtDeliverTo
        '
        Me.txtDeliverTo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDeliverTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliverTo.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtDeliverTo.Location = New System.Drawing.Point(11, 149)
        Me.txtDeliverTo.Multiline = True
        Me.txtDeliverTo.Name = "txtDeliverTo"
        Me.txtDeliverTo.Size = New System.Drawing.Size(353, 47)
        Me.txtDeliverTo.TabIndex = 487
        '
        'dtDeliver
        '
        Me.dtDeliver.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDeliver.Location = New System.Drawing.Point(121, 224)
        Me.dtDeliver.Name = "dtDeliver"
        Me.dtDeliver.Size = New System.Drawing.Size(23, 20)
        Me.dtDeliver.TabIndex = 489
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(170, 206)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 15)
        Me.Label1.TabIndex = 497
        Me.Label1.Text = "Requested By"
        '
        'txtRequestedBy
        '
        Me.txtRequestedBy.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRequestedBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestedBy.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtRequestedBy.Location = New System.Drawing.Point(170, 224)
        Me.txtRequestedBy.Multiline = True
        Me.txtRequestedBy.Name = "txtRequestedBy"
        Me.txtRequestedBy.Size = New System.Drawing.Size(195, 20)
        Me.txtRequestedBy.TabIndex = 498
        '
        'txtDeliverOn
        '
        Me.txtDeliverOn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDeliverOn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliverOn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtDeliverOn.Location = New System.Drawing.Point(12, 224)
        Me.txtDeliverOn.Multiline = True
        Me.txtDeliverOn.Name = "txtDeliverOn"
        Me.txtDeliverOn.Size = New System.Drawing.Size(116, 20)
        Me.txtDeliverOn.TabIndex = 499
        '
        'frmPurchaseOrderDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 439)
        Me.Controls.Add(Me.txtDeliverOn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRequestedBy)
        Me.Controls.Add(Me.btPrintPreview)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.txtSupplierAdd)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.cboTerms)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDeliverTo)
        Me.Controls.Add(Me.dtDeliver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPurchaseOrderDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "P.O Details"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btPrintPreview As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents txtSupplierAdd As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents cboTerms As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDeliverTo As TextBox
    Friend WithEvents dtDeliver As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRequestedBy As TextBox
    Friend WithEvents txtDeliverOn As TextBox
End Class
