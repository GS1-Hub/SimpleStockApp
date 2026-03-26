Public Class Dashboard
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim menu As New SimpleStockMenu()
        menu.TopLevel = False
        menu.FormBorderStyle = FormBorderStyle.None
        menu.Dock = DockStyle.Top
        Me.Controls.Add(menu)
        menu.Show()
    End Sub
End Class