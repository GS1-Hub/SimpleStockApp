Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class SettingsForm
    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbDepartament.DataSource = [Enum].GetValues(GetType(Departament))
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtName.Text) OrElse String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Nome e Email são obrigatórios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim db As New AppDbContext()

            Dim emp As New Employers()
            emp.Name = txtName.Text.Trim()
            emp.Email = txtEmail.Text.Trim()
            emp.Departmant = CType(cbDepartament.SelectedItem, Departament)

            db.Employers.Add(emp)
            db.SaveChanges()
            db.Dispose()

            MessageBox.Show("Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SettingsForm_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Dim dashboard = New Dashboard()
        dashboard.Show()
    End Sub
End Class