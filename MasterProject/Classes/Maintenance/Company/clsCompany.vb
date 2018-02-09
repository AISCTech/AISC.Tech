Public Class clsCompanyHeader

    Private strCompany_Code As String
    Property _Company_Code As String
        Get
            Return strCompany_Code
        End Get
        Set(value As String)
            strCompany_Code = value
        End Set
    End Property

    Private blCompany_Main As Boolean
    Property _Company_Main As Boolean
        Get
            Return blCompany_Main
        End Get
        Set(value As Boolean)
            blCompany_Main = value
        End Set
    End Property

    Private strCompany_Name As String
    Property _Company_Name As String
        Get
            Return strCompany_Name
        End Get
        Set(value As String)
            strCompany_Name = value
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

    Private blActive As Boolean
    Property _Active As Boolean
        Get
            Return blActive
        End Get
        Set(value As Boolean)
            blActive = value
        End Set
    End Property

    Private strAddress As Boolean
    Property _Address As Boolean
        Get
            Return strAddress
        End Get
        Set(value As Boolean)
            strAddress = value
        End Set
    End Property

    Private strContactNo As String
    Property _ContactNo As String
        Get
            Return strContactNo
        End Get
        Set(value As String)
            strContactNo = value
        End Set
    End Property

    Private strTin As String
    Property _Tin As String
        Get
            Return strTin
        End Get
        Set(value As String)
            strTin = value
        End Set
    End Property

    Private clsAsClient As New clsClientHeader
    Property _AsClient As clsClientHeader
        Get
            Return clsAsClient
        End Get
        Set(value As clsClientHeader)
            clsAsClient = value
        End Set
    End Property
End Class

Public Class clsCompanyServiceOffered

    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private clsCompany As New clsCompanyHeader
    Property _Company As clsCompanyHeader
        Get
            Return clsCompany
        End Get
        Set(value As clsCompanyHeader)
            clsCompany = value
        End Set
    End Property

    Private clsServiceOffered As New clsParameters
    Property _ServiceOffered As clsParameters
        Get
            Return clsServiceOffered
        End Get
        Set(value As clsParameters)
            clsServiceOffered = value
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