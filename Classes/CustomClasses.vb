Public Class tempHDM

    Private strhdm As String

    Public Sub New(shdm As String)
        strhdm = shdm
    End Sub
    Public Property հդմ As String
        Get
            Return strhdm
        End Get
        Set(value As String)
            strhdm = value
        End Set
    End Property

End Class

Public Class gprsDelHvhhEcr

    Public Sub New(ByVal _ecr As String, ByVal _hvhh As String, ByVal _id As Integer)
        ID = _id
        Ecr = _ecr
        Hvhh = _hvhh
    End Sub

    Public Property Ecr As String
    Public Property Hvhh As String
    Public Property ID As Integer

End Class

Public Class BlockGprsByHdm

    Public Property Ecr As String
    Public Property DisableDate As Date

    Public Sub New(ByVal _ecr As String, ByVal _disableDate As Date)
        Ecr = _ecr
        DisableDate = _disableDate
    End Sub

End Class

Public Class RecordID

    Public Property ID As Integer

    Public Sub New(ByVal _id As Integer)
        ID = _id
    End Sub

End Class

Public Class ForSmS

    Public Property hvhh As String
    Public Property tel As String
    Public Property id As Integer

    Public Sub New(ByVal _hvhh As String, ByVal _tel As String, ByVal _id As Integer)
        hvhh = _hvhh
        tel = _tel
        id = _id
    End Sub

End Class

Public Class ForSmS2

    Public Property ՀՎՀՀ As String
    Public Property Հեռախոս As String
    Public Property Պարտք As Decimal
    Public Property Սպասարկող As String
    Public Property id As Integer

    Public Sub New(ByVal _hvhh As String, ByVal _tel As String, _partq As Decimal, _supporter As String, _id As Integer)
        ՀՎՀՀ = _hvhh
        Հեռախոս = _tel
        Պարտք = _partq
        Սպասարկող = _supporter
        id = _id
    End Sub

End Class

Public Class ForSmSToTesuch

    Public Property tesuch As String
    Public Property tel As String

    Public Sub New(ByVal _tesuch As String, ByVal _tel As String)
        tesuch = _tesuch
        tel = _tel
    End Sub

End Class

Public Class UPermissions

    Private _Level As String
    Private _Caption As String
    Private _Allow As Boolean

    Public Sub New(ByVal Level As String, ByVal Text As String, ByVal Allow As Boolean)
        _Level = Level
        _Caption = Text
        _Allow = Allow
    End Sub
    Public Property GUID As String
        Get
            Return _Level
        End Get
        Set(value As String)
            _Level = value
        End Set
    End Property
    Public Property Տեքստ As String
        Get
            Return _Caption
        End Get
        Set(value As String)
            _Caption = value
        End Set
    End Property
    Public Property Ակտիվ As Boolean
        Get
            Return _Allow
        End Get
        Set(value As Boolean)
            _Allow = value
        End Set
    End Property

End Class

Public Class RegionPage

    Private _region As String
    Private _page As Integer

    Public Sub New(ByVal r As String, ByVal p As Integer)
        _region = r
        _page = p
    End Sub

    Public Property Region As String
        Get
            Return _region
        End Get
        Set(value As String)
            _region = value
        End Set
    End Property
    Public Property Page As Integer
        Get
            Return _page
        End Get
        Set(value As Integer)
            _page = value
        End Set
    End Property

End Class

Public Class PDF_Pages

    Private _region As String
    Private _startPage As Integer
    Private _finishPage As Integer
    Private _pageCount As Integer

    Public Sub New(sRegion As String, sStart As Integer, sFinish As Integer, sPages As Integer)
        _region = sRegion
        _startPage = sStart
        _finishPage = sFinish
        _pageCount = sPages
    End Sub

    Public Property Region As String
        Get
            Return _region
        End Get
        Set(value As String)
            _region = value
        End Set
    End Property
    Public Property StartPage As Integer
        Get
            Return _startPage
        End Get
        Set(value As Integer)
            _startPage = value
        End Set
    End Property
    Public Property FinishPage As Integer
        Get
            Return _finishPage
        End Get
        Set(value As Integer)
            _finishPage = value
        End Set
    End Property
    Public Property PageCount As Integer
        Get
            Return _pageCount
        End Get
        Set(value As Integer)
            _pageCount = value
        End Set
    End Property

End Class

Public Class DelGprs

    Public Sub New(ByVal gprs_number As String)
        _DGprs = gprs_number
    End Sub

    Private _DGprs As String
    Public Property GPRS As String
        Get
            Return _DGprs
        End Get
        Set(value As String)
            _DGprs = value
        End Set
    End Property

End Class

Public Class GPS

    Public Property Latitude As String
    Public Property Longitude As String

End Class