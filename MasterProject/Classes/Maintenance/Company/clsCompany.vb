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

    Private strCompany_FullName As String
    Property _Company_FullName As String
        Get
            Return strCompany_FullName
        End Get
        Set(value As String)
            strCompany_FullName = value
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