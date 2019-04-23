Public Class TarifUpWin

    Friend tarifID As Short
    Friend tarif As String

    Friend day28 As Decimal
    Friend day29 As Decimal
    Friend day30 As Decimal
    Friend day31 As Decimal

    'Form Load
    Private Sub TarifUpWin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTarif.Text = tarif
        d28.Text = day28
        d29.Text = day29
        d30.Text = day30
        d31.Text = day31
    End Sub

    'Update
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrEmpty(txtTarif.Text) Then Throw New Exception("Տվյալները գրված չեն")
            iDB.UpdateTarif(txtTarif.Text.Trim, d28.Text, d29.Text, d30.Text, d31.Text, tarifID)
            MsgBox("Տվյալը հաջողությամբ փոփոխվեցին", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class