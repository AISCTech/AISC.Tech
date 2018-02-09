Public Class clsDateValue
    Private dtValue As Date
    Property _DateValue As Date
        Get
            Return dtValue
        End Get
        Set(value As Date)
            dtValue = value
            SetStringValue()
        End Set
    End Property

    Private strValue As String
    Property _StringValue As String
        Get
            Return strValue
        End Get
        Set(value As String)
            strValue = value
            SetDateValue()
        End Set
    End Property

    Private Sub SetDateValue()
        If IsDate(strValue) Then
            dtValue = strValue
        Else
            dtValue = Nothing
        End If
    End Sub

    Private Sub SetStringValue()
        If dtValue = Nothing Then
            strValue = ""
        Else
            strValue = dtValue
        End If
    End Sub
End Class
