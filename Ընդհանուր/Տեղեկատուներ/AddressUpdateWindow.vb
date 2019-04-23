Public Class AddressUpdateWindow

    Friend iAddressID As Integer = 0
    Friend iAddress As String = ""

    'Form Load
    Private Sub AddressUpdateWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAddress.Text = iAddress
        txtAddress.Focus()
    End Sub

    'Update
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrEmpty(txtAddress.Text) Then Throw New Exception("Տվյալները գրված չեն")
            iDB.UpdateAddress(txtAddress.Text.Trim, iAddressID)
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