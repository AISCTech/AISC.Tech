Public Class clsSite
    Private intPK As Integer
    Property _PK As Integer
        Get
            Return intPK
        End Get
        Set(value As Integer)
            intPK = value
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

    Private strBookingPrefix As String
    Property _BookingPrefix As String
        Get
            Return strBookingPrefix
        End Get
        Set(value As String)
            strBookingPrefix = value
        End Set
    End Property
End Class
