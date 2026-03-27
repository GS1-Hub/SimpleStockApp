Public Class Dashboard
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Stock_Click(sender As Object, e As EventArgs) Handles Stock.Click

    End Sub

    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles Settings.Click
        Dim settings As New SettingsForm()
        settings.Show()
        Me.Hide()
    End Sub
End Class