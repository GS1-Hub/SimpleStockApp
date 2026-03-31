
Public Class Register
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Register_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Show()
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If txtUsername.Text = "" OrElse txtPasword.Text = "" OrElse txtEmail.Text = "" Then
            MessageBox.Show("Insert all camps")
            Return
        End If

        Dim user As New User() With {
            .Username = txtUsername.Text,
            .Password = txtPasword.Text,
            .Email = txtEmail.Text,
            .IsClient = True
        }


        If AuthService.Register(user) Then
            MessageBox.Show("Success!")
            Me.Close()
        Else
            MessageBox.Show("Something is wrong!")
        End If
    End Sub
End Class