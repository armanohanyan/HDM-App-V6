Public Class WorkShopMessagesAnswer

    Friend M As String = String.Empty
    Friend ID As Integer = -1

    Private Sub WorkShopMessagesAnswer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        IsWWOpened2 = False
    End Sub

    Private Sub WorkShopMessages_Load(sender As Object, e As EventArgs) Handles Me.Load
        IsWWOpened2 = True

        Dim working_area As Rectangle = SystemInformation.WorkingArea
        Dim x As Integer = working_area.Left + working_area.Width - Me.Width
        Dim y As Integer = working_area.Top + working_area.Height - Me.Height

        Me.Location = New Point(x, y)

        Label1.Text = M

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            iDB.UpdateRemakeMessage(ID)
            IsWWOpened2 = False

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

End Class