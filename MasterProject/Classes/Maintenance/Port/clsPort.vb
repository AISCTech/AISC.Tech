Public Class clsPort
    Private intPK As Integer
    Property _PK As Integer
        Get
            Return intPK
        End Get
        Set(value As Integer)
            intPK = value
        End Set
    End Property

    Private clsCountryDetails As New clsCountry
    Property _CountryDetails As clsCountry
        Get
            Return clsCountryDetails
        End Get
        Set(value As clsCountry)
            clsCountryDetails = value
        End Set
    End Property

    Private strDescription As String
    Property _Description As String
        Get
            Return strDescription
        End Get
        Set(value As String)
            strDescription = value
        End Set
    End Property
End Class

Public Class clsCountry
    Private intPK As Integer
    Property _PK As Integer
        Get
            Return intPK
        End Get
        Set(value As Integer)
            intPK = value
        End Set
    End Property

    Private strDescription As String
    Property _Description As String
        Get
            Return strDescription
        End Get
        Set(value As String)
            strDescription = value
        End Set
    End Property

    Private strAcronym As String
    Property _Acronym As String
        Get
            Return strAcronym
        End Get
        Set(value As String)
            strAcronym = value
        End Set
    End Property
End Class
