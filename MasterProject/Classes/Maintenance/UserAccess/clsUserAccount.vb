Public Class clsUserAccount

    Private strUser_ID As String
    Property _User_ID As String
        Get
            Return strUser_ID
        End Get
        Set(value As String)
            strUser_ID = value
        End Set
    End Property

    Private strUsername As String
    Property _Username As String
        Get
            Return strUsername
        End Get
        Set(value As String)
            strUsername = value
        End Set
    End Property

    Private strPassword As String
    Property _Password As String
        Get
            Return strPassword
        End Get
        Set(value As String)
            strPassword = value
        End Set
    End Property

    Private strLast_Name As String
    Property _Last_Name As String
        Get
            Return strLast_Name
        End Get
        Set(value As String)
            strLast_Name = value
        End Set
    End Property

    Private strFirst_Name As String
    Property _First_Name As String
        Get
            Return strFirst_Name
        End Get
        Set(value As String)
            strFirst_Name = value
        End Set
    End Property

    Private strMiddle_Name As String
    Property _Middle_Name As String
        Get
            Return strMiddle_Name
        End Get
        Set(value As String)
            strMiddle_Name = value
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

    Private strCompany_Name As String
    Property _Company_Name As String
        Get
            Return strCompany_Name
        End Get
        Set(value As String)
            strCompany_Name = value
        End Set
    End Property

    Private strSite_Code As String
    Property _Site_Code As String
        Get
            Return strSite_Code
        End Get
        Set(value As String)
            strSite_Code = value
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
End Class
