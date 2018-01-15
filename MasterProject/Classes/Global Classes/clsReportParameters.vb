Public Class clsReportParameters

    Private lngID As Long
    Property _ID As Integer
        Get
            Return lngID
        End Get
        Set(value As Integer)
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

    Private strReport_Name As String
    Property _Report_Name As String
        Get
            Return strReport_Name
        End Get
        Set(value As String)
            strReport_Name = value
        End Set
    End Property

    Private strParameter_Name As String
    Property _Parameter_Name As String
        Get
            Return strParameter_Name
        End Get
        Set(value As String)
            strParameter_Name = value
        End Set
    End Property

    Private strParameter_Value As String
    Property _Parameter_Value As String
        Get
            Return strParameter_Value
        End Get
        Set(value As String)
            strParameter_Value = value
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
