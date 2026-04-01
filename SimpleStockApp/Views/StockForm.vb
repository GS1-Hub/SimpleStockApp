Imports System.Data.Entity
Imports System.Windows

Public Class StockForm
    Dim companyId As Integer?
    Dim selectedId As Integer = -1
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
        LoadGrid()
    End Sub

    Private Sub StockForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
    End Sub

    Private Sub btnStock_Click(sender As Object, e As EventArgs) Handles btnStock.Click
        Try
            If dgProducts.SelectedRows.Count = 0 Then
                MessageBox.Show("Select a product to add a Stock")
                Return
            End If

            Dim dc As New AppDbContext()
            Dim selectedRow = dgProducts.SelectedRows(0)
            Dim productId = CInt(selectedRow.Cells("Id").Value)
            Dim stockNr = CInt(nUpDown.Value)

            Dim product = dc.Produtcs.FirstOrDefault(Function(p) p.Id = productId)
            If product IsNot Nothing Then
                product.Stock += stockNr
                dc.SaveChanges()
                MessageBox.Show("Stock updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            LoadGrid()
            dc.Dispose()
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        End Try
    End Sub
    Private Sub LoadGrid()
        Dim dc As New AppDbContext()
        Dim produtcs = dc.Produtcs.ToList()
        dc.Dispose()
        dgProducts.DataSource = produtcs
        dgProducts.Columns("Id").Visible = False
        dgProducts.Columns("Company_Id").Visible = False
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If String.IsNullOrWhiteSpace(editName.Text) OrElse String.IsNullOrWhiteSpace(editPrice.Text) OrElse String.IsNullOrWhiteSpace(editDesc.Text) Then
            MessageBox.Show("Select one Product to edit")
        End If

        Using db As New AppDbContext()
            Dim product = db.Produtcs.Find(selectedId)

            If product IsNot Nothing Then
                product.Name = editName.Text
                product.Price = CInt(Decimal.Parse(editPrice.Text))
                product.Descont = CInt(Decimal.Parse(editDesc.Text))
                product.Stock = CInt(editUpDown.Value)
                db.SaveChanges()
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadGrid()
            Else
                MessageBox.Show("Product not found!")
            End If
        End Using

    End Sub
    Private Sub dgProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgProducts.SelectionChanged
        If dgProducts.SelectedRows.Count > 0 Then
            Dim selectRow As DataGridViewRow = dgProducts.SelectedRows(0)

            selectedId = Convert.ToInt32(selectRow.Cells("Id").Value)
            editName.Text = selectRow.Cells("Name").Value?.ToString()
            editPrice.Text = selectRow.Cells("Price").Value?.ToString()
            editDesc.Text = selectRow.Cells("Descont").Value?.ToString()
            editUpDown.Value = selectRow.Cells("Stock").Value?.ToString()
        End If
    End Sub
End Class