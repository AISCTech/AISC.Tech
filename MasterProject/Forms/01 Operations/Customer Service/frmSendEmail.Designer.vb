<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendEmail
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBcc = New System.Windows.Forms.TextBox()
        Me.cmdBcc = New System.Windows.Forms.Button()
        Me.txtCc = New System.Windows.Forms.TextBox()
        Me.cmdCc = New System.Windows.Forms.Button()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.cmdTo = New System.Windows.Forms.Button()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdSend)
        Me.Panel1.Controls.Add(Me.txtSubject)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtBcc)
        Me.Panel1.Controls.Add(Me.cmdBcc)
        Me.Panel1.Controls.Add(Me.txtCc)
        Me.Panel1.Controls.Add(Me.cmdCc)
        Me.Panel1.Controls.Add(Me.txtTo)
        Me.Panel1.Controls.Add(Me.cmdTo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(978, 123)
        Me.Panel1.TabIndex = 0
        '
        'cmdSend
        '
        Me.cmdSend.Location = New System.Drawing.Point(12, 12)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(55, 96)
        Me.cmdSend.TabIndex = 11
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(127, 92)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(839, 20)
        Me.txtSubject.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Subject:"
        '
        'txtBcc
        '
        Me.txtBcc.Location = New System.Drawing.Point(127, 66)
        Me.txtBcc.Name = "txtBcc"
        Me.txtBcc.Size = New System.Drawing.Size(839, 20)
        Me.txtBcc.TabIndex = 5
        '
        'cmdBcc
        '
        Me.cmdBcc.Location = New System.Drawing.Point(73, 64)
        Me.cmdBcc.Name = "cmdBcc"
        Me.cmdBcc.Size = New System.Drawing.Size(48, 23)
        Me.cmdBcc.TabIndex = 4
        Me.cmdBcc.Text = "Bcc..."
        Me.cmdBcc.UseVisualStyleBackColor = True
        '
        'txtCc
        '
        Me.txtCc.Location = New System.Drawing.Point(127, 40)
        Me.txtCc.Name = "txtCc"
        Me.txtCc.Size = New System.Drawing.Size(839, 20)
        Me.txtCc.TabIndex = 3
        '
        'cmdCc
        '
        Me.cmdCc.Location = New System.Drawing.Point(73, 38)
        Me.cmdCc.Name = "cmdCc"
        Me.cmdCc.Size = New System.Drawing.Size(48, 23)
        Me.cmdCc.TabIndex = 2
        Me.cmdCc.Text = "Cc..."
        Me.cmdCc.UseVisualStyleBackColor = True
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(127, 14)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(839, 20)
        Me.txtTo.TabIndex = 1
        '
        'cmdTo
        '
        Me.cmdTo.Location = New System.Drawing.Point(73, 12)
        Me.cmdTo.Name = "cmdTo"
        Me.cmdTo.Size = New System.Drawing.Size(48, 23)
        Me.cmdTo.TabIndex = 0
        Me.cmdTo.Text = "To..."
        Me.cmdTo.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 3)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReuseParameterValuesOnRefresh = True
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(964, 341)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 123)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(978, 373)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CrystalReportViewer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(970, 347)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Attachment"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtMessage)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(970, 326)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Message"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMessage.Location = New System.Drawing.Point(3, 3)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(964, 320)
        Me.txtMessage.TabIndex = 0
        '
        'frmSendEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 496)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmSendEmail"
        Me.Text = "frmSendEmail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBcc As TextBox
    Friend WithEvents cmdBcc As Button
    Friend WithEvents txtCc As TextBox
    Friend WithEvents cmdCc As Button
    Friend WithEvents txtTo As TextBox
    Friend WithEvents cmdTo As Button
    Friend WithEvents cmdSend As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtMessage As TextBox
End Class
