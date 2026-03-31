Imports System.Data.Entity

Public Class AppDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=SimpleStock")
    End Sub

    Public Property Users As DbSet(Of User)
    Public Property Companies As DbSet(Of Company)
    Public Property Employers As DbSet(Of Employers)
    Public Property Produtcs As DbSet(Of Produtcs)
End Class