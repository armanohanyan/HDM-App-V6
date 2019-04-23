Public Class TesuchAddWindow

    'Add Tesuch
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtTesuchName.Text) Then Throw New Exception("Տվյալները գրված չեն")

            iDB.InsertTesuchInfo(txtTesuchName.Text.Trim, ckActive.Checked, txtEmail.Text.Trim, txtTel.Text.Trim)

            txtTesuchName.Text = String.Empty
            txtEmail.Text = String.Empty
            txtTel.Text = String.Empty
            ckActive.Checked = False

            MsgBox("Տվյալը հաջողությամբ ավելացվեց բազա", MsgBoxStyle.Information, My.Application.Info.Title)
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub TesuchAddWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTesuchName.Focus()
    End Sub

End Class