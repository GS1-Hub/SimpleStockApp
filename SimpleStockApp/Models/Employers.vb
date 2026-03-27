Imports System.ComponentModel.DataAnnotations.Schema

<Table("Employers")>
Public Class Employers
    Public Property Id As Integer
    Public Property Name As String
    Public Property Email As String
    Public Property DepartmentId As Departament
    Public Property Username As String
    Public Property Password As String
End Class
