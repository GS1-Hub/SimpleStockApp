Imports System.Data.Entity
Public Class AppDbContext
    Inherits DbContext
    Public Sub New()
        MyBase.New("name=SimpleStock")
    End Sub
    Public Property Users As DbSet(Of User)
End Class
