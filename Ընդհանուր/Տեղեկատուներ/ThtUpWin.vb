Public Class ThtUpWin

    Friend iTHTID As Short = 0
    Friend iTHT As String = ""

    'Form Load
    Private Sub ThtUpWin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTHT.Text = iTHT
        txtTHT.Focus()
    End Sub

    'Update
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrEmpty(txtTHT.Text) Then Throw New Exception("Տվյալները գրված չեն")
            iDB.UpdateTHT(txtTHT.Text.Trim, iTHTID)
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