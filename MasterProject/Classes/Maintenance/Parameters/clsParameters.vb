Public Class clsParameters

    Private intPK As Integer
    Property _PK As Integer
        Get
            Return intPK
        End Get
        Set(value As Integer)
            intPK = value
        End Set
    End Property

    Private clsParamameterType As New clsParamsType
    Property _ParameterType As clsParamsType
        Get
            Return clsParamameterType
        End Get
        Set(value As clsParamsType)
            clsParamameterType = value
        End Set
    End Property

    Private strParam_Code As String
    Property _Param_Code As String
        Get
            Return strParam_Code
        End Get
        Set(value As String)
            strParam_Code = value
        End Set
    End Property

    Private strParam_Desc As String
    Property _Param_Desc As String
        Get
            Return strParam_Desc
        End Get
        Set(value As String)
            strParam_Desc = value
        End Set
    End Property

    Private strParam_Value As String
    Property _Param_Value As String
        Get
            Return strParam_Value
        End Get
        Set(value As String)
            strParam_Value = value
        End Set
    End Property
End Class

Public Class clsParamsType

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
End Class
