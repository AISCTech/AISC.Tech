Public Class clsEmailPerModule

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
End Class
