Imports System.ComponentModel.DataAnnotations.Schema

<Table("Sales")>
Public Class Sale
    Public Property Id As Integer
    Public Property ProductId As Integer
    Public Property Quantity As Integer
    Public Property TotalPrice As Decimal
    Public Property SaleDate As DateTime
End Class
