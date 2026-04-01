Public Class ViewProductsForm
    Dim _companyId As Integer
    Dim _companyName As String
    Public Sub New(companyId As Integer, companyName As String)
        InitializeComponent()
        _companyId = companyId
        _companyName = companyName
    End Sub

    Private Sub ViewProductsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Text = _companyName
        LoadGrid()
    End Sub
    Private Sub LoadGrid()
        Using dc As New AppDbContext
            Dim products = dc.Produtcs.Where(Function(c) c.Company_Id = _companyId).
            Select(Function(p) New With {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.Descont,
                    p.Stock
            }).ToList()

            dgvProducts.DataSource = products
        End Using
    End Sub
End Class