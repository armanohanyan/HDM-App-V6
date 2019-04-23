Public Class UpdateBank

    Friend iBankID As Short = 0
    Friend iBank As String = ""

    'Form Load
    Private Sub ThtUpWin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBank.Text = iBank
        txtBank.Focus()
    End Sub

    'Update
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrEmpty(txtBank.Text) Then Throw New Exception("Տվյալները գրված չեն")
            iDB.ChangeBank(txtBank.Text.Trim, iBankID)
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