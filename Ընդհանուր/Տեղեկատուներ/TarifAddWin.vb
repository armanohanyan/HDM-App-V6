Public Class TarifAddWin

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtTarif.Text) Then Throw New Exception("Տվյալները գրված չեն")

            iDB.InsertTarif(txtTarif.Text.Trim, d28.Text, d29.Text, d30.Text, d31.Text)

            MsgBox("Տվյալը հաջողությամբ ավելացվեց բազա", MsgBoxStyle.Information, My.Application.Info.Title)

            d28.Text = 0
            d29.Text = 0
            d30.Text = 0
            d31.Text = 0

            txtTarif.Text = String.Empty
            txtTarif.Focus()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class