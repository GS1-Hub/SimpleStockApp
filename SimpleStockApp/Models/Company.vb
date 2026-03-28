Imports System.ComponentModel.DataAnnotations.Schema

<Table("Companies")>
Public Class Company
    Public Property Id As Integer
    Public Property ClientId As Integer
    Public Property Name As String
    Public Property NIF As String
    Public Property Email As String
    Public Property Phone As String
    Public Property BusinessType As BusinessType

End Class