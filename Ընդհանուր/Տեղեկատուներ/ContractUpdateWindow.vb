Public Class ContractUpdateWindow

    Friend iContract As String = ""
    Friend iContractID As Integer = 0

    'Form Load
    Private Sub ContractUpdateWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtContract.Text = iContract
        txtContract.Focus()
    End Sub

    'Update
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrEmpty(txtContract.Text) Then Throw New Exception("Տվյալները գրված չեն")
            iDB.UpdateContract(txtContract.Text.Trim, iContractID)
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