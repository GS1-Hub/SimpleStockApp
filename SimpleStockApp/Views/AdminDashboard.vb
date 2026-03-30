Public Class AdminDashboard
    Private Sub AdminDashboard_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            Dim db As New AppDbContext()
            Dim users = db.Users.ToList()
            db.Dispose()
            dtAdmin.DataSource = users
            dtAdmin.Columns("Id").Visible = False
            dtAdmin.Columns("Password").Visible = False
        Catch ex As Exception
            MessageBox.Show("Erro: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If dtAdmin.CurrentRow Is Nothing Then
            MessageBox.Show("Plesea select a user!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim user = TryCast(dtAdmin.CurrentRow.DataBoundItem, User)
        If user IsNot Nothing Then
            Dim db As New AppDbContext()
            Dim dbUser = db.Users.FirstOrDefault(Function(u) u.Id = user.Id)
            dbUser.IsAdmin = ForeverToggle1.Checked
            dbUser.IsClient = False
            dbUser.IsOwner = False
            db.SaveChanges()
            db.Dispose()
            MessageBox.Show("User saved!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub dtAdmin_SelectionChanged(sender As Object, e As EventArgs) Handles dtAdmin.SelectionChanged
        If dtAdmin.CurrentRow Is Nothing Then Return
        Dim user = TryCast(dtAdmin.CurrentRow.DataBoundItem, User)
        If user IsNot Nothing Then
            ForeverToggle1.Checked = user.IsAdmin
        End If
    End Sub
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class