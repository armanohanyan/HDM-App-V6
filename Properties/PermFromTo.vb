Public Class PermFromTo

    Private Sub LoadData()
        Try
            Dim dt As DataTable = iDB.GetUserGroupList()

            With cbG1
                .DataSource = dt
                .DisplayMember = "GroupName"
                .ValueMember = "GroupID"
            End With

            Dim dt2 As DataTable = iDB.GetUserGroupList()

            With cbG2
                .DataSource = dt2
                .DisplayMember = "GroupName"
                .ValueMember = "GroupID"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub PermFromTo_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadData()
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            If cbG1.SelectedValue = cbG2.SelectedValue Then Throw New Exception("Խմբերը կրկնվում են")

            If MsgBox("Ցանկանու՞մ եք փոխանցել իրավասությունները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            iDB.TransferPermisiions(cbG2.SelectedValue, cbG1.SelectedValue)

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