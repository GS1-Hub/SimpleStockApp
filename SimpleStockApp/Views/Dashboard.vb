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
    End Sub

    Private Sub Stock_Click(sender As Object, e As EventArgs) Handles Stock.Click

    End Sub

    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles Settings.Click
        Dim settings As New SettingsForm(_userId)
        settings.Show()
        Me.Hide()
    End Sub
End Class