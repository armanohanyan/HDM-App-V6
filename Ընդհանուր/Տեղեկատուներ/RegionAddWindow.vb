Public Class RegionAddWindow

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtRegion.Text) Then Throw New Exception("Տվյալները գրված չեն")

            iDB.InsertRegionInfo(txtRegion.Text.Trim)

            txtRegion.Text = String.Empty

            MsgBox("Տվյալը հաջողությամբ ավելացվեց բազա", MsgBoxStyle.Information, My.Application.Info.Title)
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub RegionAddWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRegion.Focus()
    End Sub

End Class