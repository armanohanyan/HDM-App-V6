Public Class EquipmentAddWin

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtEquipment.Text) Then Throw New Exception("Տվյալները գրված չեն")

            iDB.InsertEquipment(txtEquipment.Text.Trim, ckCanSell.Checked, cbIsEcr.Checked)

            MsgBox("Տվյալը հաջողությամբ ավելացվեց բազա", MsgBoxStyle.Information, My.Application.Info.Title)

            txtEquipment.Text = String.Empty
            txtEquipment.Focus()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub EquipmentAddWin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbIsEcr.Enabled = False
    End Sub

    Private Sub ckCanSell_CheckedChanged(sender As Object, e As EventArgs) Handles ckCanSell.CheckedChanged
        If ckCanSell.Checked = True Then
            cbIsEcr.Enabled = True
        Else
            cbIsEcr.Enabled = False
        End If
    End Sub
End Class