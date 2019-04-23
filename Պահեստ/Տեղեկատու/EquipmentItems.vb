Public Class EquipmentItems

    Private EquipmentID As Short
    Private Equipment As String
    Private EquipmentCount As Short
    Private Price As Decimal
    Private PurchaseDate As Date
    Private Comment As String
    Private ShtrikhCode As String

    Public Sub New(_Equipment As String, _EquipmentID As Short, _ShtrikhCode As String, _EquipmentCount As Short, _Price As Decimal, _PurchaseDate As Date, _Comment As String)
        Equipment = _Equipment
        EquipmentID = _EquipmentID
        ShtrikhCode = _ShtrikhCode
        EquipmentCount = _EquipmentCount
        Price = _Price
        PurchaseDate = _PurchaseDate
        Comment = _Comment
    End Sub

    Public Property Սարքավորում As String
        Get
            Return Equipment
        End Get
        Set(value As String)
            Equipment = value
        End Set
    End Property

    Public Property ՍարքավորումՀՀ As Short
        Get
            Return EquipmentID
        End Get
        Set(value As Short)
            EquipmentID = value
        End Set
    End Property

    Public Property Շտրիխ As String
        Get
            Return ShtrikhCode
        End Get
        Set(value As String)
            ShtrikhCode = value
        End Set
    End Property

    Public Property Քանակ As Short
        Get
            Return EquipmentCount
        End Get
        Set(value As Short)
            EquipmentCount = value
        End Set
    End Property

    Public Property Արժեք As Decimal
        Get
            Return Price
        End Get
        Set(value As Decimal)
            Price = value
        End Set
    End Property

    Public Property Ամսաթիվ As Date
        Get
            Return PurchaseDate
        End Get
        Set(value As Date)
            PurchaseDate = value
        End Set
    End Property

    Public Property Մեկնաբանություն As String
        Get
            Return Comment
        End Get
        Set(value As String)
            Comment = value
        End Set
    End Property

End Class