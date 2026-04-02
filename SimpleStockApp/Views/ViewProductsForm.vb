Imports System.IO
Imports iFont = iTextSharp.text.Font
Imports iImage = iTextSharp.text.Image
Imports iDocument = iTextSharp.text.Document
Imports iParagraph = iTextSharp.text.Paragraph
Imports iChunk = iTextSharp.text.Chunk
Imports iPhrase = iTextSharp.text.Phrase
Imports iPdfPTable = iTextSharp.text.pdf.PdfPTable
Imports iPdfPCell = iTextSharp.text.pdf.PdfPCell
Imports iPageSize = iTextSharp.text.PageSize
Imports iBaseColor = iTextSharp.text.BaseColor
Imports iElement = iTextSharp.text.Element
Imports iLineSeparator = iTextSharp.text.pdf.draw.LineSeparator
Imports iTextSharp.text.pdf
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

    Private Sub dgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If dgvProducts.SelectedRows.Count = 0 Then Return
        Dim row = dgvProducts.SelectedRows(0)
        Label3.Text = row.Cells("Stock").Value.ToString()
        Label5.Text = row.Cells("Price").Value.ToString()
        Label8.Text = row.Cells("Descont").Value.ToString()
        Label9.Text = row.Cells("Stock").Value.ToString()
    End Sub

    Private Sub nudQuantity_ValueChanged(sender As Object, e As EventArgs) Handles nudQuantity.ValueChanged
        If dgvProducts.SelectedRows.Count = 0 Then Return
        Dim price As Decimal = Convert.ToDecimal(dgvProducts.SelectedRows(0).Cells("Price").Value)
        Dim discount As Decimal = Convert.ToDecimal(dgvProducts.SelectedRows(0).Cells("Descont").Value)
        Dim quantity As Integer = CInt(nudQuantity.Value)
        Dim finalPrice As Decimal = price - (price * discount / 100)
        lblFinalPrice.Text = $"{finalPrice * quantity:C}"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a product!")
            Return
        End If

        Dim productId As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Id").Value)
        Dim stock As Integer = Convert.ToInt32(dgvProducts.SelectedRows(0).Cells("Stock").Value)
        Dim price As Decimal = Convert.ToDecimal(dgvProducts.SelectedRows(0).Cells("Price").Value)
        Dim discount As Decimal = Convert.ToDecimal(dgvProducts.SelectedRows(0).Cells("Descont").Value)
        Dim productName As String = dgvProducts.SelectedRows(0).Cells("Name").Value.ToString()
        Dim quantity As Integer = CInt(nudQuantity.Value)

        If quantity > stock Then
            MessageBox.Show("Not enough stock!")
            Return
        End If

        Dim finalPrice As Decimal = price - (price * discount / 100)
        Dim total As Decimal = finalPrice * quantity

        Using dc As New AppDbContext
            Dim product = dc.Produtcs.Find(productId)
            product.Stock -= quantity

            Dim sale As New Sale With {
                .productId = productId,
                .quantity = quantity,
                .TotalPrice = total,
                .SaleDate = DateTime.Now
            }
            dc.Sales.Add(sale)
            dc.SaveChanges()
        End Using

        GerarFaturaPDF(productName, price, discount, finalPrice, quantity, total)
        LoadGrid()
    End Sub

    Private Sub GerarFaturaPDF(productName As String, price As Decimal, discount As Decimal, finalPrice As Decimal, quantity As Integer, total As Decimal)

        Dim saveDialog As New SaveFileDialog()
        saveDialog.Title = "Save Recibe"
        saveDialog.Filter = "PDF (*.pdf)|*.pdf"
        saveDialog.FileName = $"Recibe_{DateTime.Now:yyyyMMdd_HHmmss}"
        If saveDialog.ShowDialog(Me) <> DialogResult.OK Then Return

        Dim doc As New iDocument(iPageSize.A4, 40, 40, 40, 40)
        PdfWriter.GetInstance(doc, New FileStream(saveDialog.FileName, FileMode.Create))
        doc.Open()

        Dim fontTitulo As New iFont(iFont.FontFamily.HELVETICA, 20, iFont.BOLD)
        Dim fontNormal As New iFont(iFont.FontFamily.HELVETICA, 10)
        Dim fontBold As New iFont(iFont.FontFamily.HELVETICA, 10, iFont.BOLD)
        Dim fontBranco As New iFont(iFont.FontFamily.HELVETICA, 10, iFont.BOLD, iBaseColor.WHITE)

        ' Logo
        Dim logoPath As String = Application.StartupPath & "\wallpaper.ico"
        If File.Exists(logoPath) Then
            Dim logo As iImage = iImage.GetInstance(logoPath)
            logo.ScaleToFit(80, 80)
            logo.Alignment = iElement.ALIGN_LEFT
            doc.Add(logo)
        End If

        Using db As New AppDbContext
            Dim company = db.Companies.Find(_companyId)
            Dim tabelaHeader As New PdfPTable(1)
            tabelaHeader.WidthPercentage = 100

            Dim cellNome As New PdfPCell(New iPhrase(company.Name, fontTitulo))
            cellNome.Border = 0
            cellNome.PaddingBottom = 4
            tabelaHeader.AddCell(cellNome)

            Dim cellInfo As New PdfPCell(New iPhrase(
                $"NIF: {company.NIF}   |   Email: {company.Email}   |   Phone: {company.Phone}", fontNormal))
            cellInfo.Border = 0
            cellInfo.PaddingBottom = 10
            tabelaHeader.AddCell(cellInfo)
            doc.Add(tabelaHeader)
        End Using

        doc.Add(New iChunk(New iLineSeparator()))
        doc.Add(New iParagraph(" "))

        Dim titulo As New iParagraph("RECIBE", fontTitulo)
        titulo.Alignment = iElement.ALIGN_CENTER
        doc.Add(titulo)

        Dim dataP As New iParagraph($"Date: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal)
        dataP.Alignment = iElement.ALIGN_RIGHT
        doc.Add(dataP)
        doc.Add(New iParagraph(" "))

        Dim tabela As New PdfPTable(5)
        tabela.WidthPercentage = 100
        tabela.SetWidths(New Single() {3, 1.5, 1.5, 1, 1.5})

        For Each header As String In {"Product", "Price", "Descont", "Qty", "Total"}
            Dim cell As New PdfPCell(New iPhrase(header, fontBranco))
            cell.BackgroundColor = New iBaseColor(30, 30, 30)
            cell.Padding = 6
            cell.HorizontalAlignment = iElement.ALIGN_CENTER
            tabela.AddCell(cell)
        Next

        For Each val As String In {productName, $"{price:C}", $"{discount}%", quantity.ToString(), $"{total:C}"}
            Dim cell As New PdfPCell(New iPhrase(val, fontNormal))
            cell.Padding = 6
            cell.HorizontalAlignment = iElement.ALIGN_CENTER
            tabela.AddCell(cell)
        Next

        doc.Add(tabela)
        doc.Add(New iParagraph(" "))

        Dim tabelaTotal As New PdfPTable(2)
        tabelaTotal.WidthPercentage = 40
        tabelaTotal.HorizontalAlignment = iElement.ALIGN_RIGHT

        Dim cellTotalLabel As New PdfPCell(New iPhrase("TOTAL", fontBold))
        cellTotalLabel.Padding = 6
        tabelaTotal.AddCell(cellTotalLabel)

        Dim cellTotalValor As New PdfPCell(New iPhrase($"{total:C}", fontBold))
        cellTotalValor.Padding = 6
        cellTotalValor.HorizontalAlignment = iElement.ALIGN_RIGHT
        tabelaTotal.AddCell(cellTotalValor)

        doc.Add(tabelaTotal)
        doc.Close()

        MessageBox.Show("Recibe save succefuly!")
    End Sub

End Class