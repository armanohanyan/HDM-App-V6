Public Class ObjTypeUpWin

    Friend iObjectID As Short = 0
    Friend iObject As String = ""

    'Form Load
    Private Sub ObjTypeUpWin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtObjectType.Text = iObject
        txtObjectType.Focus()
    End Sub

    'Update
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrEmpty(txtObjectType.Text) Then Throw New Exception("Տվյալները գրված չեն")
            iDB.UpdateObjectType(txtObjectType.Text.Trim, iObjectID)
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