Public Class Dashboard
    Private _userId As Integer
    Private _isOwner As Boolean
    Private _isAdmin As Boolean
    Private _companyId As Integer?
    Public Sub New(userId As Integer, isOwner As Boolean, isAdmin As Boolean, companyId As Integer?)
        InitializeComponent()
        _userId = userId
        _isOwner = isOwner
        _isAdmin = isAdmin
        _companyId = companyId
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _isAdmin = True Then
            AdminSettings.Visible = _isAdmin
            LoadForm(New AdminDashboard())
        ElseIf _isOwner = True Then
            Settings.Visible = _isOwner
            LoadForm(New StockForm())
        Else
            LoadForm(New Register())
        End If
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
    Private Sub Dashboard_Closed(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub AdminSettings_Click(sender As Object, e As EventArgs) Handles AdminSettings.Click
        LoadForm(New AdminDashboard())
    End Sub
End Class