Public Class ChangePaymentWin

    Friend PaymentID As Integer = 0

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            If txtAmount.Text < 0 Then Throw New Exception("Գումարը պետք է բացասական չլինի")

            iDB.UpdatePayment(txtAmount.Text, iUser.LoginName, PaymentID, dePayDay.DateTime)

            MsgBox("Գումարը փոփոխվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class