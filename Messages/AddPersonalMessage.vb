Public Class AddPersonalMessage

    Private Sub AddPersonalMessage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dt As DataTable = iDB.GetLoginNames
            With cbUser
                .DataSource = dt
                .DisplayMember = "LoginName"
                .ValueMember = "UserID"
            End With
            If cbUser.Items.Count > 0 Then cbUser.SelectedIndex = 0
            cbMessageType.SelectedIndex = 0
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnSendMessage_Click(sender As Object, e As EventArgs) Handles btnSendMessage.Click
        Try

            If cbUser.SelectedValue = 115 Then Throw New Exception("Այս օգտվողին չեք կարող հաղորդագրություն ուղարկել")

            If txtMessage.Text.Trim = "" Then Throw New Exception("Հաղորդագրությունը գրված չէ")

            Dim b As Image
            If cbMessageType.SelectedIndex = 0 Then
                b = My.Resources.InfoMessage.ToBitmap
            Else
                b = My.Resources.infoWarning.ToBitmap
            End If

            iDB.AddPublicMessage(b, iUser.UserID, txtMessage.Text.Trim, False, cbUser.SelectedValue)

            MsgBox("Հաղորդագրությունը ուղարկվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class