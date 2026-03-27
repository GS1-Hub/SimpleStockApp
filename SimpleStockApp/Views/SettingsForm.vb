Public Class SettingsForm
    Private _userId As Integer
    Public Sub New(userId As Integer)
        InitializeComponent()
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbDepartament.DataSource = [Enum].GetValues(GetType(Departament))
        Dim db As New AppDbContext()
        DataGridView1.DataSource = db.Employers.ToList()
        db.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtName.Text) OrElse String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Nome e Email são obrigatórios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim emp As New Employers()
            emp.Name = txtName.Text.Trim()
            emp.Email = txtEmail.Text.Trim()
            emp.DepartmentId = CType(cbDepartament.SelectedItem, Departament)
            emp.Username = username.Text.Trim()
            emp.Password = password.Text.Trim()

            Dim result = AuthService.RegisterEmployer(emp)
            If result Then
                MessageBox.Show("Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim db As New AppDbContext()
                DataGridView1.DataSource = db.Employers.ToList()
                db.Dispose()
            Else
                MessageBox.Show("Username já existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            Dim msg = ex.Message
            If ex.InnerException IsNot Nothing Then msg &= vbNewLine & ex.InnerException.Message
            If ex.InnerException?.InnerException IsNot Nothing Then msg &= vbNewLine & ex.InnerException.InnerException.Message
            MessageBox.Show("Erro: " & msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class