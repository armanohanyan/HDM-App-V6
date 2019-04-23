Public Class WorkShopMessages

    Friend M As String = String.Empty

    Private Sub WorkShopMessages_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        IsWWOpened = False
    End Sub

    Private Sub WorkShopMessages_Load(sender As Object, e As EventArgs) Handles Me.Load
        IsWWOpened = True

        Dim working_area As Rectangle = SystemInformation.WorkingArea
        Dim x As Integer = working_area.Left + working_area.Width - Me.Width
        Dim y As Integer = working_area.Top + working_area.Height - Me.Height

        Me.Location = New Point(x, y)

        Label1.Text = M

    End Sub

End Class