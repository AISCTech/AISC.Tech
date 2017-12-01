Public Class clsPopulateComboBox

    Private _cboBox As ComboBox
    WriteOnly Property _ComboBox As ComboBox
        Set(value As ComboBox)
            _cboBox = value
        End Set
    End Property

    Private _strSQL As String
    WriteOnly Property _SQLQuery As String
        Set(value As String)
            _strSQL = value
        End Set
    End Property

    Private _strDisplayMember As String
    WriteOnly Property _DisplayMember As String
        Set(value As String)
            _strDisplayMember = value
        End Set
    End Property

    Private _strValueMember As String
    WriteOnly Property _ValueMember As String
        Set(value As String)
            _strValueMember = value
        End Set
    End Property

    Public Sub New(ByVal cboBox As ComboBox, ByVal strSQL As String, ByVal strDisplayMember As String, ByVal strValueMember As String)
        _cboBox = cboBox
        _strSQL = strSQL
        _strDisplayMember = strDisplayMember
        _strValueMember = strValueMember
    End Sub

    Public Sub PopComboBox()
        Try
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim daChargeTo As MySql.Data.MySqlClient.MySqlDataAdapter

            Dim dtChargeTo As New DataSet
            daChargeTo = New MySql.Data.MySqlClient.MySqlDataAdapter(_strSQL, cnnDBMaster)

            daChargeTo.Fill(dtChargeTo)
            With _cboBox
                .DataSource = dtChargeTo.Tables(0).DefaultView
                .DisplayMember = _strDisplayMember
                .ValueMember = _strValueMember
                .Text = ""
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
