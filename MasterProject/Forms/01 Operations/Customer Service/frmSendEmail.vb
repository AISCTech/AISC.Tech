
Imports System.ComponentModel

Public Class frmSendEmail

    Public strAttnTo As String
    Dim strAttachLoc As String
    Dim clsEmailCredentials As New clsEmailPerModule


    Private Sub CreateImportBAC(ByVal lngBookingID As Long, ByVal strCompanyName As String, ByVal strBookingNo As String)
        Try
            Dim rptTemp As New rptImportBAC
            Dim clsDB As New clsDBTrans
            Dim lstOfReportParameters As List(Of clsReportParameters) = clsDB.PopulateListOfReportParameter(CurrentUser._Company_Code, "rptImportBAC")

            Me.Text = "Import Booking Acknowledgement"
            strAttachLoc = LocalFiles._PDFFiles._PDFBAC._FileLocation & "\" & strCompanyName & " BAC - " & strBookingNo & ".pdf"
            txtSubject.Text = strCompanyName & " BOOKING ACKNOWLEDGEMENT (" & strBookingNo & ")"

            rptTemp.RecordSelectionFormula = "{v_importbookingheader1.ID}= " & lngBookingID

            rptTemp.SetParameterValue("p_AttnTo", strAttnTo)
            rptTemp.SetParameterValue("p_Greeting", GetGreeting)
            rptTemp.SetParameterValue("p_NoOfContainers", frmImportBookingMenu.tslblContainerSizes.Text)
            rptTemp.SetParameterValue("p_Email", clsEmailCredentials._EmailReplyTo._EmailAddress)
            rptTemp.SetParameterValue("p_SenderName", UpperFirstLetter(CurrentUser._First_Name & " " & CurrentUser._Last_Name))
            rptTemp.SetParameterValue("p_SenderDesignation", CurrentUser._Position_Name & " | " & CurrentUser._Dept_Name)

            For Each clsRptParam As clsReportParameters In lstOfReportParameters
                rptTemp.SetParameterValue(clsRptParam._Parameter_Name, clsRptParam._Parameter_Value)
            Next

            CrystalReportViewer1.ReportSource = rptTemp

            rptTemp.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strAttachLoc)
            rptTemp.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "System Message")
        End Try
    End Sub

    Private Sub GetEmailCredentials(ByVal strCompany_Code As String, ByVal lngModule_ID As Long)
        Dim clsDBTemp As New clsDBTrans
        clsEmailCredentials = clsDBTemp.SearchEmailPerModule(strCompany_Code, lngModule_ID)
    End Sub

    Private Sub frmSendEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case Me.Tag
            Case "ImpBAC"
                With frmImportBookingMenu
                    GetEmailCredentials(CurrentUser._Company_Code, ._ModuleID)
                    CreateImportBAC(.clsImportBooking._ID, .clsImportBooking._CompanyName,
                                    .txtBookingPrefix.Text & "-" & .txtBookingNo.Text)
                End With
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
            ._MailFromEmail = clsEmailCredentials._EmailFrom._EmailAddress
            ._MailFromName = CurrentUser._First_Name & " " & CurrentUser._Last_Name
            ._MailReplyToList = clsEmailCredentials._EmailReplyTo._EmailAddress
            ._MailSubject = txtSubject.Text
            ._MailBody = txtMessage.Text
            ._MailAttachmentLocation = strAttachLoc
            ._SMTPHost = clsEmailCredentials._EmailFrom._SMTP_Host
            ._SMTPPort = clsEmailCredentials._EmailFrom._SMTP_Port
            ._SMTPUsername = clsEmailCredentials._EmailFrom._SMTP_Username
            ._SMTPPassword = clsEmailCredentials._EmailFrom._SMTP_Password
            ._SendMail()
        End With
    End Sub

    Private Sub frmSendEmail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class