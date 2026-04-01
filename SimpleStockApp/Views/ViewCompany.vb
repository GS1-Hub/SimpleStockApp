Public Class ViewCompany
    Private Sub ViewCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadCompanys()
        Using dc As New AppDbContext
            Dim companies = dc.Companies.
            Select(Function(c) New With {
                c.Id,
                c.Name,
                c.Email,
                c.Phone
            }).ToList()
            dgvCompanies.DataSource = companies

            dgvCompanies.Columns("Id").Visible = False
            dgvCompanies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End Using
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        If dgvCompanies.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a Company to see Products")
            Return
        End If

        Dim companyId As Integer = Convert.ToInt32(dgvCompanies.SelectedRows(0).Cells("Id").Value())
        Dim companyName As String = dgvCompanies.SelectedRows(0).Cells("Name").Value.ToString()

        Dim f As New ViewProductsForm(companyId, companyName)
        f.Show()
    End Sub
End Class