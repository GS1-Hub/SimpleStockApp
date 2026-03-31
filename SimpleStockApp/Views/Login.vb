Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        username.Left = (Me.ClientSize.Width - username.Width) / 2
        Label2.Left = (Me.ClientSize.Width - Label2.Width) / 2
        password.Left = (Me.ClientSize.Width - password.Width) / 2
        btnLogin.Left = (Me.ClientSize.Width - (btnLogin.Width + btnReg.Width + 10)) / 2
        btnReg.Left = btnLogin.Left + btnLogin.Width + 10
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim user = AuthService.Login(username.Text, password.Text)

        If user Is Nothing Then
            MessageBox.Show("Username or password is wrong")
        End If

        If user.IsClient OrElse user.IsAdmin Then
            Dim db As New AppDbContext()
            Dim company = db.Companies.FirstOrDefault(Function(c) c.ClientId = user.Id)
            db.Dispose()
            If company Is Nothing AndAlso user.IsClient Then
                Dim companyForm As New CompanyForm(user.Id)
                companyForm.ShowDialog()
            End If
            Dim dashboard As New Dashboard(user.Id, user.IsOwner, user.IsAdmin, user.CompanyId)
            dashboard.Show()
            Me.Close()
        Else
            MessageBox.Show("This account dont have permitions to acess!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnReg_Click(sender As Object, e As EventArgs) Handles btnReg.Click
        Dim register As New Register()
        register.Show()
        Me.Hide()
    End Sub
End Class