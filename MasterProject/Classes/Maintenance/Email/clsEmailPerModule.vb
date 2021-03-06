﻿Public Class clsEmailPerModule

    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strCompany_Code As String
    Property _Company_Code As String
        Get
            Return strCompany_Code
        End Get
        Set(value As String)
            strCompany_Code = value
        End Set
    End Property

    Private strCompany_FullName As String
    Property _Company_FullName As String
        Get
            Return strCompany_FullName
        End Get
        Set(value As String)
            strCompany_FullName = value
        End Set
    End Property

    Private lngModule_ID As Long
    Property _Module_ID As Long
        Get
            Return lngModule_ID
        End Get
        Set(value As Long)
            lngModule_ID = value
        End Set
    End Property

    Private strModule_Name As String
    Property _Module_Name As String
        Get
            Return strModule_Name
        End Get
        Set(value As String)
            strModule_Name = value
        End Set
    End Property

    Private clsEmailFrom As New clsEmailAddress
    Property _EmailFrom As clsEmailAddress
        Get
            Return clsEmailFrom
        End Get
        Set(value As clsEmailAddress)
            clsEmailFrom = value
        End Set
    End Property

    Private clsEmailReplyTo As New clsEmailAddress
    Property _EmailReplyTo As clsEmailAddress
        Get
            Return clsEmailReplyTo
        End Get
        Set(value As clsEmailAddress)
            clsEmailReplyTo = value
        End Set
    End Property

    Private clsPrepBy As New clsUserAccount
    Property _PrepBy As clsUserAccount
        Get
            Return clsPrepBy
        End Get
        Set(value As clsUserAccount)
            clsPrepBy = value
        End Set
    End Property

    Private dtPrepDate As Date
    Property _PrepDate As Date
        Get
            Return dtPrepDate
        End Get
        Set(value As Date)
            dtPrepDate = value
        End Set
    End Property

    Private clsModBy As New clsUserAccount
    Property _ModBy As clsUserAccount
        Get
            Return clsModBy
        End Get
        Set(value As clsUserAccount)
            clsModBy = value
        End Set
    End Property

    Private dtModDate As Date
    Property _ModDate As Date
        Get
            Return dtModDate
        End Get
        Set(value As Date)
            dtModDate = value
        End Set
    End Property
End Class
