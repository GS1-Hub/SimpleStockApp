Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices

Public Class CompanyForm
    Private _userId As Integer

    Public Sub New(userId As Integer)
        InitializeComponent()
        _userId = userId
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(txtName.Text) OrElse String.IsNullOrWhiteSpace(txtNIF.Text) Then
            MessageBox.Show("Put Name and NIF!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim db As New AppDbContext()
            Dim existing = db.Companies.FirstOrDefault(Function(c) c.ClientId = _userId)
            If existing IsNot Nothing Then
                MessageBox.Show("Já tens uma empresa criada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                db.Dispose()
                Return
            End If

            Dim user = db.Users.FirstOrDefault(Function(u) u.Id = _userId)
            Dim company As New Company()
            company.ClientId = _userId
            company.Name = txtName.Text.Trim()
            company.NIF = txtNIF.Text.Trim()
            company.Email = txtEmail.Text.Trim()
            company.Phone = txtPhone.Text.Trim()
            company.BusinessType = CType(CbTypeB.SelectedItem, BusinessType)

            db.Companies.Add(company)
            db.SaveChanges()

            If user IsNot Nothing Then
                user.CompanyId = company.Id
                user.IsOwner = True
                db.SaveChanges()
            End If

            db.Dispose()
            MessageBox.Show("Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("ERRO:" + ex.Message)
        End Try
    End Sub

    Private Sub CompanyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CbTypeB.DataSource = [Enum].GetValues(GetType(BusinessType))
    End Sub
End Class