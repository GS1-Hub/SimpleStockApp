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
        If AuthService.Login(username.Text, password.Text) Then
            Dim dashborad As New Dashboard()
            dashborad.Show()
            Me.Hide()
        Else
            MessageBox.Show("Username or Password incorret")
        End If
    End Sub
End Class