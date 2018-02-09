Module modGlobalDeclaration

    Public strSystemName As String = "Sample System"
    Public strSystemVersion As String = "1.0"

    Public strAppPath As String = AppDomain.CurrentDomain.BaseDirectory()
    Public LocalFiles As New clsLocalFiles
    Public CurrentUser As New clsUserAccount
    Public ListOfStatus As New List(Of clsStatus)
End Module
