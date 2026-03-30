Public Class AdminDashboard
    Private Sub AdminDashboard_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            Dim db As New AppDbContext()
            Dim users = db.Users.ToList()
            db.Dispose()
            MessageBox.Show("Total users: " & users.Count.ToString())
            dtAdmin.DataSource = users
        Catch ex As Exception
            MessageBox.Show("Erro: " & ex.Message)
        End Try
    End Sub
End Class