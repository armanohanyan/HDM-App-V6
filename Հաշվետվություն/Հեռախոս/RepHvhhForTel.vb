Public Class RepHvhhForTel

    Dim dtClient As DataTable

    Private Sub LoadAutocomplet()
        Try
            dtClient = iDB.AutoCompleteClientList()

            txtHVHH.AutoCompleteCustomSource.Clear()
            txtHVHH.AutoCompleteCustomSource.AddRange((From row In dtClient.Rows.Cast(Of DataRow)() Select CStr(row("ՀՎՀՀ"))).ToArray())

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub RepHvhhForTel_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadAutocomplet()
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            If txtHVHH.Text.Trim = String.Empty Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")

            Call CloseWindow("nShowTell")
            Dim f As New ShowTell With {.hvhh = txtHVHH.Text.Trim}
            AddChildForm("nShowTell", f)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class