Imports System.ComponentModel.DataAnnotations.Schema

<Table("Company")>
Public Class Company
    Public Property Id As Integer
    Public Property ClientId As Integer
    Public Property Name As String
    Public Property NIF As String
    Public Property Email As String
    Public Property Phone As String
    Public Property Employers As String
    Public Property Settings As Settings
End Class