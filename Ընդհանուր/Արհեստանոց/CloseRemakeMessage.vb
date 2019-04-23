Public Class CloseRemakeMessage

    Friend ID As Integer = -1
    Friend UserID As Integer = -1
    Friend SendUSer As String = String.Empty
    Friend Ecr As String = String.Empty
    Friend Message As String = String.Empty

    Private Sub CloseRemakeMessage_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtSender.Text = SendUSer
        txtEcr.Text = Ecr
        txtM.Text = Message
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If txtSM.Text.Trim = String.Empty Then Throw New Exception("Պատասխանը գրված չէ")

            iDB.CloseRemakeMessage(ID, txtSM.Text.Trim, iUser.UserID)

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

End Class