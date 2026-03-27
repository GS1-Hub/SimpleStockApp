Public Class Dashboard
    Private _userId As Integer
    Private _isOwner As Boolean

    Public Sub New(userId As Integer, isOwner As Boolean)
        InitializeComponent()
        _userId = userId
        _isOwner = isOwner
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings.Visible = _isOwner
        LoadForm(New StockForm())
    End Sub

    Private Sub LoadForm(frm As Form)
        pnlContent.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        pnlContent.Controls.Add(frm)
        frm.Show()
    End Sub

    Private Sub Stock_Click(sender As Object, e As EventArgs) Handles Stock.Click
        LoadForm(New StockForm())
    End Sub

    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles Settings.Click
        LoadForm(New SettingsForm(_userId))
    End Sub
End Class