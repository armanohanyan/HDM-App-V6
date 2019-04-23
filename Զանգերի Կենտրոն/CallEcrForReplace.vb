Public Class CallEcrForReplace

    Friend ClientEcr As String

    Private Sub LoadData()
        Try
            txtClientEcr.Text = ClientEcr

            Dim dt As DataTable = iDB.GetReadyEcrForReplace(ClientEcr)
            If dt.Rows.Count = 0 Then
                btnOK.Enabled = False
                Throw New Exception("Տվյալ չկա")
                Return
            End If

            txtRegion.Text = dt.Rows(0)("Region")
            txtTesuch.Text = dt.Rows(0)("tesuchName")

            With cbEcr
                .DataSource = dt
                .DisplayMember = "ECR"
                .ValueMember = "ecrID"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub CallEcrForReplace_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            iDB.QueueEcr(ClientEcr, cbEcr.SelectedValue, iUser.LoginName)
            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class