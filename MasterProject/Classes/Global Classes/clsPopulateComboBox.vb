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

Public Class clsPopListView
    Private _lvObject As ListView
    Property _ListView As ListView
        Get
            Return _lvObject
        End Get
        Set(value As ListView)
            _lvObject = value
        End Set
    End Property

    Private _strSQL As String
    WriteOnly Property _SQLQuery As String
        Set(value As String)
            _strSQL = value
        End Set
    End Property

    Private _lvColumnHeaders As New List(Of String)
    Property _ColumnHeaders As List(Of String)
        Get
            Return _lvColumnHeaders
        End Get
        Set(value As List(Of String))
            _lvColumnHeaders = value
        End Set
    End Property

    Public Sub New(ByVal lvObject As ListView, ByVal strSQL As String)
        _lvObject = lvObject
        _strSQL = strSQL
    End Sub

    Public Sub PopulateListview(ByVal strTooltipField As String)
        Try
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            'Populate Header
            For Each lvHeader As String In _lvColumnHeaders
                _lvObject.Columns.Add(lvHeader)
            Next

            'Populate Items and Sub Items
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = _strSQL

            Dim lvItem As New ListViewItem
            Dim lstlvItems As New List(Of ListViewItem)
            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            _lvObject.Items.Clear()

            While reader.Read
                With reader
                    lvItem = New ListViewItem
                    lvItem.Text = UpperFirstLetter(.Item(0))
                    lvItem.ToolTipText = .Item(strTooltipField)

                    For intctr As Integer = 1 To .FieldCount - 1
                        lvItem.SubItems.Add(.Item(intctr))
                    Next

                    'Populate Temporary Listview
                    lstlvItems.Add(lvItem)
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()

            'transfer temporary listview items to actual listview
            lvItem = New ListViewItem
            For Each lvItem In lstlvItems
                _lvObject.Items.Add(lvItem)
                lvItem = New ListViewItem
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class