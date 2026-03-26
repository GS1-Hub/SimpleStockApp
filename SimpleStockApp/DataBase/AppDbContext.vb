Imports System.Data.Entity
Public Class AppDbContext
    Inherits DbContext
    Public Sub New()
        MyBase.New("name=SimpleStock")
    End Sub
    Public Property Users As DbSet(Of User)
    Public Property Companies As DbSet(Of Company)
End Class
