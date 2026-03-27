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
        If user IsNot Nothing Then
            If user.IsClient Then
                Dim db As New AppDbContext()
                Dim company = db.Companies.FirstOrDefault(Function(c) c.ClientId = user.Id)
                db.Dispose()
                If company Is Nothing Then
                    Dim companyForm As New CompanyForm(user.Id)
                    companyForm.ShowDialog()
                End If
                Dim dashboard As New Dashboard(user.Id, True)
                dashboard.Show()
            Else
                MessageBox.Show("Conta sem permissões!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Me.Hide()
        Else
            Dim db As New AppDbContext()
            Dim empResult = db.Employers.FirstOrDefault(Function(x) x.Username = username.Text)
            db.Dispose()

            If empResult IsNot Nothing AndAlso AuthService.VerifyPassword(password.Text, empResult.Password) Then
                Dim dashboard As New Dashboard(empResult.Id, False)
                dashboard.Show()
                Me.Hide()
            Else
                MessageBox.Show("Username ou Password incorretos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub btnReg_Click(sender As Object, e As EventArgs) Handles btnReg.Click
        Dim register As New Register()
        register.Show()
        Me.Hide()
    End Sub
End Class