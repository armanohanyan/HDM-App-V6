Public Class AddPaySelect

    Private Sub loadSupporter()
        Try
            Dim dt As DataTable

            If iUser.DB = 5 Then
                dt = iDB.GetSupporter()
            End If

            With cbSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub AddPaySelect_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call loadSupporter()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Call CloseWindow("nAddPayWin")
        Dim f As New AddPayWin With {.SupID = cbSupporter.SelectedValue}
        AddChildForm("nAddPayWin", f)

        Me.Close()
    End Sub

End Class