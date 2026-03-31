Imports System.ComponentModel.DataAnnotations.Schema

<Table("Users")>
Public Class User
    Public Property Id As Integer
    Public Property Username As String
    Public Property Password As String
    Public Property Email As String
    Public Property IsClient As Boolean
    Public Property IsOwner As Boolean
    Public Property IsAdmin As Boolean
    Public Property CompanyId As Integer?
End Class