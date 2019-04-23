Public Class CStatus

    Public Property StatusID As Integer = -1

    Private Sub LoadStatus()
        Try
            Dim dt As DataTable = iDB.GetFilteredStatus()

            With cbStatus
                .DataSource = dt
                .DisplayMember = "Status"
                .ValueMember = "statusID"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        StatusID = cbStatus.SelectedValue
        Me.Close()
    End Sub

    Private Sub CStatus_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadStatus()
    End Sub

End Class