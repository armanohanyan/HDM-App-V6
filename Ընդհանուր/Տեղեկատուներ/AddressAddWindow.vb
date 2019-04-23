Public Class AddressAddWindow

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtAddress.Text) Then Throw New Exception("Տվյալները գրված չեն")
            iDB.InsertAddress(txtAddress.Text.Trim)
            MsgBox("Տվյալը հաջողությամբ ավելացվեց բազա", MsgBoxStyle.Information, My.Application.Info.Title)
            txtAddress.Text = String.Empty
            txtAddress.Focus()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class