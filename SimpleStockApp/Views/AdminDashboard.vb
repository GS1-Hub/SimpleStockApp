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

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If dtAdmin.CurrentRow Is Nothing Then
            MessageBox.Show("Plesea select a user!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim user = TryCast(dtAdmin.CurrentRow.DataBoundItem, User)
        If user IsNot Nothing Then
            Dim confirm = MessageBox.Show("You want to delete this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirm = DialogResult.Yes Then
                Dim db As New AppDbContext()
                Dim company = db.Companies.FirstOrDefault(Function(c) c.ClientId = user.Id)
                If company IsNot Nothing Then
                    db.Companies.Remove(company)
                End If
                Dim dbUser = db.Users.FirstOrDefault(Function(u) u.Id = user.Id)
                db.Users.Remove(dbUser)
                db.SaveChanges()
                db.Dispose()
                MessageBox.Show("~User deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtAdmin.DataSource = Nothing
                Dim db2 As New AppDbContext()
                dtAdmin.DataSource = db2.Users.ToList()
                db2.Dispose()
                dtAdmin.Columns("Id").Visible = False
                dtAdmin.Columns("Password").Visible = False
            End If
        End If
    End Sub
End Class