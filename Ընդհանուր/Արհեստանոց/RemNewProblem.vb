Public Class RemNewProblem

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If txtProblem.Text.Trim = String.Empty Then Throw New Exception("Խնդիրը գրված չէ")

            iDB.NewRemakeProblem(txtProblem.Text.Trim)

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

End Class