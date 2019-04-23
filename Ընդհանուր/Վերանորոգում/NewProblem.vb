Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class NewProblem

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            If txtProblem.Text.Trim = String.Empty Then Throw New Exception("Խնդիրը գրված չէ")

            iDB.InsertProblem(txtProblem.Text.Trim, rbSoft.Checked)

            MsgBox("Խնդիրը ավելացվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            txtProblem.Text = String.Empty
            txtProblem.Focus()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class