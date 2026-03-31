Public Class StockForm
    Dim companyId As Integer?
    Public Sub New(companyId As Integer)
        InitializeComponent()
        Me.companyId = companyId
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If String.IsNullOrWhiteSpace(txtName.Text) OrElse String.IsNullOrWhiteSpace(txtPrice.Text) OrElse String.IsNullOrWhiteSpace(txtDescont.Text) Then
            MessageBox.Show("Put Name, Price and Descont!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim dc As New AppDbContext()
            Dim existing = dc.Produtcs.FirstOrDefault(Function(p) p.Name = txtName.Text.Trim())
            If existing IsNot Nothing Then
                MessageBox.Show("This product already exits")
                Return
            End If

            Dim price As Integer
            Dim discount As Integer
            Dim product As New Produtcs()
            product.Name = txtName.Text.Trim()
            product.Price = Integer.Parse(txtPrice.Text, price)
            product.Descont = Integer.Parse(txtDescont.Text, discount)
            product.Company_Id = companyId

            dc.Produtcs.Add(product)
            dc.SaveChanges()
            dc.Dispose()
            MessageBox.Show("Product saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.InnerException?.Message & If(ex.InnerException Is Nothing, ex.Message, ""), "Erro")
        End Try

    End Sub

    Private Sub StockForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim db As New AppDbContext()
            Dim produtcs = db.Produtcs.ToList()
            db.Dispose()
            dgProducts.DataSource = produtcs
            dgProducts.Columns("Id").Visible = False
        Catch ex As Exception
            MessageBox.Show("Erro: " & ex.Message)
        End Try
    End Sub
End Class