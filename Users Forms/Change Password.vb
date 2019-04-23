Public Class Change_Password

    'Retrieve Logins
    Private Sub RetrieveLogins()
        Try
            Dim dt As DataTable = iDB.GetLoginNames()   'Load users list
            If dt.Rows.Count = 0 Then Throw New Exception("Օգտվողների ցանկը չի ստացվել")

            With cbLogins
                .DataSource = dt
                .DisplayMember = "LoginName"
                .ValueMember = "UserID"
            End With
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'Load Form
    Private Sub Change_Password_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call RetrieveLogins()

        If cbLogins.Items.Count = 0 Then Me.Close() 'If there is no logins then close the window
        cbLogins.Text = iUser.LoginName     'Set combobox text equal to login name
        If iUser.UserGroup = 1 Then
            btnResetPass.Visible = True : btnResetPass.Enabled = True             'Show and enable reset button
        Else
            cbLogins.Enabled = False    'Disable login section
            btnResetPass.Enabled = False : btnResetPass.Visible = False  'Hide and disable reset button
        End If
    End Sub

    'Select Text
    Private Sub txtNewPass_Click(sender As Object, e As EventArgs) Handles txtNewPass.Click
        txtNewPass.SelectionStart = 0
        txtNewPass.SelectionLength = txtNewPass.Text.Length
    End Sub
    Private Sub txtNewPass_GotFocus(sender As Object, e As EventArgs) Handles txtNewPass.GotFocus
        txtNewPass.SelectionStart = 0
        txtNewPass.SelectionLength = txtNewPass.Text.Length
    End Sub
    Private Sub txtOldPass_Click(sender As Object, e As EventArgs) Handles txtOldPass.Click
        txtOldPass.SelectionStart = 0
        txtOldPass.SelectionLength = txtOldPass.Text.Length
    End Sub
    Private Sub txtOldPass_GotFocus(sender As Object, e As EventArgs) Handles txtOldPass.GotFocus
        txtOldPass.SelectionStart = 0
        txtOldPass.SelectionLength = txtOldPass.Text.Length
    End Sub

    'Change Password
    Private Sub btnChangePass_Click(sender As Object, e As EventArgs) Handles btnChangePass.Click
        Try
            If cbLogins.Items.Count = 0 Then Throw New Exception("Օգտանունը բացակայում է")
            If String.IsNullOrEmpty(txtOldPass.Text) Then Throw New Exception("Հին գաղտնաբառը բացակայում է")
            If String.IsNullOrEmpty(txtNewPass.Text) Then Throw New Exception("Նոր գաղտնաբառը բացակայում է")

            If txtOldPass.Text.Trim = txtNewPass.Text.Trim Then Throw New Exception("Հին և նոր գաղտնաբառերը կրկնվում են")

            Call iDB.ChangeUserPassword(getMd5Hash(txtNewPass.Text.Trim), getMd5Hash(txtOldPass.Text.Trim), cbLogins.SelectedValue)

            MsgBox("Գաղտնաբառը հաջողությամբ փոխվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            iUser.Password = getMd5Hash(txtNewPass.Text)
            iUser.EncodedPassword = String.Empty

            If iUser.UserGroup <> 1 Then Application.Restart()
            Me.Close()

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'Reset Password
    Private Sub btnResetPass_Click(sender As Object, e As EventArgs) Handles btnResetPass.Click
        Try
            Call iDB.ResetUserPassword(getMd5Hash("pass"), cbLogins.SelectedValue)  'Reset user password

            MsgBox("Գաղտնաբառը հաջողությամբ փոխարինվեց pass-ի", MsgBoxStyle.Information, My.Application.Info.Title)
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class