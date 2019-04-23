Public Class CustomMseeageShow

    Private Sub btnReply_Click(sender As Object, e As EventArgs) Handles btnReply.Click
        Dim f As New AddPersonalMessage
        With f
            .Show(Me)
            .cbUser.Text = txtUser.Text
        End With
        btnReply.Enabled = False
    End Sub

End Class