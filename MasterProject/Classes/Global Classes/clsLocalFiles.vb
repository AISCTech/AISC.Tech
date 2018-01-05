Public Class clsLocalFiles

    Private strFileLocation As String
    Property _FileLocation As String
        Get
            Return strFileLocation
        End Get
        Set(value As String)
            strFileLocation = value
        End Set
    End Property

    Private clsImg As New clsImages
    Property _Images As clsImages
        Get
            Return clsImg
        End Get
        Set(value As clsImages)
            clsImg = value
        End Set
    End Property

    Private clsPDF As New clsPDFFiles
    Property _PDFFiles As clsPDFFiles
        Get
            Return clsPDF
        End Get
        Set(value As clsPDFFiles)
            clsPDF = value
        End Set
    End Property

    Public Sub New()
        strFileLocation = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & strSystemName

        If (Not System.IO.Directory.Exists(strFileLocation)) Then
            System.IO.Directory.CreateDirectory(strFileLocation)
        End If
    End Sub
End Class

Public Class clsImages

    Private strFileLocation As String
    Property _FileLocation As String
        Get
            Return strFileLocation
        End Get
        Set(value As String)
            strFileLocation = value
        End Set
    End Property

    Private clsCompLogo As New clsCompanyLogo
    Property _CompanyLogo As clsCompanyLogo
        Get
            Return clsCompLogo
        End Get
        Set(value As clsCompanyLogo)
            clsCompLogo = value
        End Set
    End Property

    Public Sub New()
        strFileLocation = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & strSystemName & "\Images"

        If (Not System.IO.Directory.Exists(strFileLocation)) Then
            System.IO.Directory.CreateDirectory(strFileLocation)
        End If
    End Sub
End Class

Public Class clsCompanyLogo

    Private strFileLocation As String
    Property _FileLocation As String
        Get
            Return strFileLocation
        End Get
        Set(value As String)
            strFileLocation = value
        End Set
    End Property

    Public Sub New()
        strFileLocation = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & strSystemName & "\Images\Company Logo"

        If (Not System.IO.Directory.Exists(strFileLocation)) Then
            System.IO.Directory.CreateDirectory(strFileLocation)
        End If
    End Sub
End Class

Public Class clsPDFFiles

    Private strFileLocation As String
    Property _FileLocation As String
        Get
            Return strFileLocation
        End Get
        Set(value As String)
            strFileLocation = value
        End Set
    End Property

    Private clsPDF As New clsPDFBAC
    Property _PDFBAC As clsPDFBAC
        Get
            Return clsPDF
        End Get
        Set(value As clsPDFBAC)
            clsPDF = value
        End Set
    End Property

    Public Sub New()
        strFileLocation = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & strSystemName & "\PDF Files"

        If (Not System.IO.Directory.Exists(strFileLocation)) Then
            System.IO.Directory.CreateDirectory(strFileLocation)
        End If
    End Sub
End Class

Public Class clsPDFBAC

    Private strFileLocation As String
    Property _FileLocation As String
        Get
            Return strFileLocation
        End Get
        Set(value As String)
            strFileLocation = value
        End Set
    End Property

    Public Sub New()
        strFileLocation = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & strSystemName & "\PDF Files\BAC"

        If (Not System.IO.Directory.Exists(strFileLocation)) Then
            System.IO.Directory.CreateDirectory(strFileLocation)
        End If
    End Sub
End Class
