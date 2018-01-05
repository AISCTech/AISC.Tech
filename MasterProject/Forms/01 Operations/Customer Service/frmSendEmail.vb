
Public Class frmSendEmail

    Public strAttnTo As String
    Dim strAttachLoc As String

    Private Sub CreateImportBAC(ByVal lngBookingID As Long, ByVal strCompanyName As String, ByVal strBookingNo As String)
        Dim rptTemp As New rptImportBAC

        Me.Text = "Import Booking Acknowledgement"
        strAttachLoc = LocalFiles._PDFFiles._PDFBAC._FileLocation & "\" & strCompanyName & " BAC - " & strBookingNo & ".pdf"
        txtSubject.Text = strCompanyName & " BOOKING ACKNOWLEDGEMENT (" & strBookingNo & ")"

        rptTemp.RecordSelectionFormula = "{v_importbookingheader1.ID}= " & lngBookingID

        rptTemp.SetParameterValue("p_AttnTo", strAttnTo)
        rptTemp.SetParameterValue("p_Greeting", GetGreeting)
        rptTemp.SetParameterValue("p_NoOfContainers", "")
        rptTemp.SetParameterValue("p_Telephone", "")
        rptTemp.SetParameterValue("p_Mobile", "")
        rptTemp.SetParameterValue("p_Email", "")
        rptTemp.SetParameterValue("p_Remarks", "")
        rptTemp.SetParameterValue("p_SenderName", UpperFirstLetter(CurrentUser._First_Name & " " & CurrentUser._Last_Name))
        rptTemp.SetParameterValue("p_SenderDesignation", CurrentUser._Position_Name & " | " & CurrentUser._Dept_Name & " Department")

        CrystalReportViewer1.ReportSource = rptTemp

        rptTemp.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strAttachLoc)
        rptTemp.Dispose()
    End Sub

    Private Sub frmSendEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case Me.Tag
            Case "ImpBAC"
                CreateImportBAC(frmImportBookingMenu.clsImportBooking._ID, frmImportBookingMenu.clsImportBooking._CompanyName,
                                frmImportBookingMenu.txtBookingPrefix.Text & "-" & frmImportBookingMenu.txtBookingNo.Text)
        End Select
    End Sub

    Private Sub txtAttnTo_TextChanged(sender As Object, e As EventArgs)
        CrystalReportViewer1.ReportSource = Nothing
        cmdSend.Enabled = False
    End Sub

    Private Sub frmSendEmail_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        txtTo.Width = Panel1.Width - 139
        txtCc.Width = Panel1.Width - 139
        txtBcc.Width = Panel1.Width - 139
        txtSubject.Width = Panel1.Width - 139
    End Sub

    Private Sub cmdSend_Click(sender As Object, e As EventArgs) Handles cmdSend.Click
        Dim clsMail As New clsEmailSending

        With clsMail
            ._MailTo = txtTo.Text
            ._MailCc = txtCc.Text
            ._MailBcc = txtBcc.Text
            ._MailFromEmail = "customerservice@acestar.com.ph"
            ._MailFromName = CurrentUser._First_Name & " " & CurrentUser._Last_Name
            ._MailReplyToList = "customerservice@acestar.com.ph"
            ._MailSubject = txtSubject.Text
            ._MailBody = txtMessage.Text
            ._MailAttachmentLocation = strAttachLoc
            ._SMTPHost = "mail.acestar.com.ph"
            ._SMTPPort = 587
            ._SMTPUsername = "notifier@acestar.com.ph"
            ._SMTPPassword = "aisc888"
            ._SendMail()
        End With
    End Sub

    Private Sub frmSendEmail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class