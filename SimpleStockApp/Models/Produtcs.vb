Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Windows.Documents
<Table("Products")>
Public Class Produtcs

    Public Property Id As Integer
    Public Property Name As String
    Public Property Price As Decimal
    Public Property Descont As Decimal
    Public Property Stock As Integer
    Public Property Company_Id As Integer

End Class
