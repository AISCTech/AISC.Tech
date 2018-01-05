Imports System.Net.Mail
Imports System.Net

Public Class clsEmailSending

    Private strMailFromEmail As String
    Property _MailFromEmail As String
        Get
            Return strMailFromEmail
        End Get
        Set(value As String)
            strMailFromEmail = value
        End Set
    End Property

    Private strMailFromName As String
    Property _MailFromName As String
        Get
            Return strMailFromName
        End Get
        Set(value As String)
            strMailFromName = value
        End Set
    End Property

    Private strMailTo As String
    Property _MailTo As String
        Get
            Return strMailTo
        End Get
        Set(value As String)
            strMailTo = value
        End Set
    End Property

    Private strMailCc As String
    Property _MailCc As String
        Get
            Return strMailCc
        End Get
        Set(value As String)
            strMailCc = value
        End Set
    End Property

    Private strMailBcc As String
    Property _MailBcc As String
        Get
            Return strMailBcc
        End Get
        Set(value As String)
            strMailBcc = value
        End Set
    End Property

    Private strMailSenderEmail As String
    Property _MailSenderEmail As String
        Get
            Return strMailSenderEmail
        End Get
        Set(value As String)
            strMailSenderEmail = value
        End Set
    End Property

    Private strMailSenderName As String
    Property _MailSenderName As String
        Get
            Return strMailSenderName
        End Get
        Set(value As String)
            strMailSenderName = value
        End Set
    End Property

    Private strMailReplyToList As String
    Property _MailReplyToList As String
        Get
            Return strMailReplyToList
        End Get
        Set(value As String)
            strMailReplyToList = value
        End Set
    End Property

    Private strMailSubject As String
    Property _MailSubject As String
        Get
            Return strMailSubject
        End Get
        Set(value As String)
            strMailSubject = value
        End Set
    End Property

    Private strMailBody As String
    Property _MailBody As String
        Get
            Return strMailBody
        End Get
        Set(value As String)
            strMailBody = value
        End Set
    End Property

    Private strMailAttachment As String
    Property _MailAttachmentLocation As String
        Get
            Return strMailAttachment
        End Get
        Set(value As String)
            strMailAttachment = value
        End Set
    End Property

    Private strSMTPHost As String
    Property _SMTPHost As String
        Get
            Return strSMTPHost
        End Get
        Set(value As String)
            strSMTPHost = value
        End Set
    End Property

    Private strSMTPPort As String
    Property _SMTPPort As String
        Get
            Return strSMTPPort
        End Get
        Set(value As String)
            strSMTPPort = value
        End Set
    End Property

    Private strSMTPUsername As String
    Property _SMTPUsername As String
        Get
            Return strSMTPUsername
        End Get
        Set(value As String)
            strSMTPUsername = value
        End Set
    End Property

    Private strSMTPPassword As String
    Property _SMTPPassword As String
        Get
            Return strSMTPPassword
        End Get
        Set(value As String)
            strSMTPPassword = value
        End Set
    End Property

    Private blSMTPEnableSSL As Boolean
    Property _SMTPEnableSSL As Boolean
        Get
            Return blSMTPEnableSSL
        End Get
        Set(value As Boolean)
            blSMTPEnableSSL = value
        End Set
    End Property

    Public Sub _SendMail()
        Try
            Dim mail As New MailMessage()
            Dim smtp As New SmtpClient()

            mail.To.Add(Replace(strMailTo, ";", ","))
            If Len(strMailCc) > 0 Then mail.CC.Add(Replace(strMailCc, ";", ","))
            If Len(strMailBcc) > 0 Then mail.Bcc.Add(Replace(strMailBcc, ";", ","))
            mail.From = New MailAddress(strMailFromEmail, UpperFirstLetter(strMailFromName))
            If Len(strMailSenderEmail) > 0 Then mail.Sender = New MailAddress(strMailSenderEmail, UpperFirstLetter(strMailSenderName))
            mail.ReplyToList.Add(strMailReplyToList)
            mail.Subject = strMailSubject
            mail.Body = strMailBody
            mail.Attachments.Add(New Attachment(strMailAttachment))

            smtp.Host = strSMTPHost
            smtp.Port = strSMTPPort
            smtp.Credentials = New NetworkCredential(strSMTPUsername, strSMTPPassword)
            smtp.EnableSsl = blSMTPEnableSSL

            smtp.Send(mail)
            mail.Dispose()
            smtp.Dispose()
            MsgBox("Mail Sent Successfully.", MsgBoxStyle.Information, "Mail Sender")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mail Sender")
        End Try
    End Sub
End Class
