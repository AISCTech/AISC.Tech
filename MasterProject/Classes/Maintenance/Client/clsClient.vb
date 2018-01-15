Public Class clsClientHeader

    Private strCode As String
    Property _Code As String
        Get
            Return strCode
        End Get
        Set(value As String)
            strCode = value
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

    Private strPrefix As String
    Property _Prefix As String
        Get
            Return strPrefix
        End Get
        Set(value As String)
            strPrefix = value
        End Set
    End Property

    Private strAddr1 As String
    Property _Addr1 As String
        Get
            Return strAddr1
        End Get
        Set(value As String)
            strAddr1 = value
        End Set
    End Property

    Private intAddrCity As Integer
    Property _AddrCity As Integer
        Get
            Return intAddrCity
        End Get
        Set(value As Integer)
            intAddrCity = value
        End Set
    End Property

    Private strCityDesc As String
    Property _CityDesc As String
        Get
            Return strCityDesc
        End Get
        Set(value As String)
            strCityDesc = value
        End Set
    End Property

    Private intAddrCountry As Integer
    Property _AddrCountry As Integer
        Get
            Return intAddrCountry
        End Get
        Set(value As Integer)
            intAddrCountry = value
        End Set
    End Property

    Private strCountryDesc As String
    Property _CountryDesc As String
        Get
            Return strCountryDesc
        End Get
        Set(value As String)
            strCountryDesc = value
        End Set
    End Property

    Private strAddrZipCode As String
    Property _AddrZipCode As String
        Get
            Return strAddrZipCode
        End Get
        Set(value As String)
            strAddrZipCode = value
        End Set
    End Property

    Private strBusStyle As String
    Property _BusStyle As String
        Get
            Return strBusStyle
        End Get
        Set(value As String)
            strBusStyle = value
        End Set
    End Property

    Private strContactMobileNo As String
    Property _ContactMobileNo As String
        Get
            Return strContactMobileNo
        End Get
        Set(value As String)
            strContactMobileNo = value
        End Set
    End Property

    Private strContactFax As String
    Property _ContactFax As String
        Get
            Return strContactFax
        End Get
        Set(value As String)
            strContactFax = value
        End Set
    End Property

    Private strContactLandline As String
    Property _ContactLandline As String
        Get
            Return strContactLandline
        End Get
        Set(value As String)
            strContactLandline = value
        End Set
    End Property

    Private strContactPerson As String
    Property _ContactPerson As String
        Get
            Return strContactPerson
        End Get
        Set(value As String)
            strContactPerson = value
        End Set
    End Property

    Private strEmail As String
    Property _Email As String
        Get
            Return strEmail
        End Get
        Set(value As String)
            strEmail = value
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

    Private intSalesTax As Integer
    Property _SalesTax As Integer
        Get
            Return intSalesTax
        End Get
        Set(value As Integer)
            intSalesTax = value
        End Set
    End Property

    Private strSalesTaxDesc As String
    Property _SalesTaxDesc As String
        Get
            Return strSalesTaxDesc
        End Get
        Set(value As String)
            strSalesTaxDesc = value
        End Set
    End Property

    Private intTerms As Integer
    Property _Terms As Integer
        Get
            Return intTerms
        End Get
        Set(value As Integer)
            intTerms = value
        End Set
    End Property

    Private strTermsDesc As String
    Property _TermsDesc As String
        Get
            Return strTermsDesc
        End Get
        Set(value As String)
            strTermsDesc = value
        End Set
    End Property

    Private dblCreditLimitAmt As Double
    Property _CreditLimitAmt As Double
        Get
            Return dblCreditLimitAmt
        End Get
        Set(value As Double)
            dblCreditLimitAmt = value
        End Set
    End Property

    Private intCreditLimitCurrency As Integer
    Property _CreditLimitCurrency As Integer
        Get
            Return intCreditLimitCurrency
        End Get
        Set(value As Integer)
            intCreditLimitCurrency = value
        End Set
    End Property

    Private strCurrencyDesc As String
    Property _CurrencyDesc As String
        Get
            Return strCurrencyDesc
        End Get
        Set(value As String)
            strCurrencyDesc = value
        End Set
    End Property

    Private intSitePK As Integer
    Property _SitePK As Integer
        Get
            Return intSitePK
        End Get
        Set(value As Integer)
            intSitePK = value
        End Set
    End Property

    Private strSite_Name As String
    Property _Site_Name As String
        Get
            Return strSite_Name
        End Get
        Set(value As String)
            strSite_Name = value
        End Set
    End Property

    Private intAccount_TypeID As Integer
    Property _Account_TypeID As Integer
        Get
            Return intAccount_TypeID
        End Get
        Set(value As Integer)
            intAccount_TypeID = value
        End Set
    End Property

    Private strAccount_TypePrefix As String
    Property _Account_TypePrefix As String
        Get
            Return strAccount_TypePrefix
        End Get
        Set(value As String)
            strAccount_TypePrefix = value
        End Set
    End Property

    Private strAccount_TypeDesc As String
    Property _Account_TypeDesc As String
        Get
            Return strAccount_TypeDesc
        End Get
        Set(value As String)
            strAccount_TypeDesc = value
        End Set
    End Property

    Private strAccount_HandlerID As String
    Property _Account_HandlerID As String
        Get
            Return strAccount_HandlerID
        End Get
        Set(value As String)
            strAccount_HandlerID = value
        End Set
    End Property

    Private strAccount_HandlerName As String
    Property _Account_HandlerName As String
        Get
            Return strAccount_HandlerName
        End Get
        Set(value As String)
            strAccount_HandlerName = value
        End Set
    End Property

    Private strModifiedBy As String
    Property _ModifiedBy As String
        Get
            Return strModifiedBy
        End Get
        Set(value As String)
            strModifiedBy = value
        End Set
    End Property

    Private strModifiedByName As String
    Property _ModifiedByName As String
        Get
            Return strModifiedByName
        End Get
        Set(value As String)
            strModifiedByName = value
        End Set
    End Property

    Private dtModifiedDate As Date
    Property _ModifiedDate As Date
        Get
            Return dtModifiedDate
        End Get
        Set(value As Date)
            dtModifiedDate = value
        End Set
    End Property
End Class
