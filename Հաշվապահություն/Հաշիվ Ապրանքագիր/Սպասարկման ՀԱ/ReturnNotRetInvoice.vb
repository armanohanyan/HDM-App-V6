Public Class ReturnNotRetInvoice

    Private Sub ReturnNotRetInvoice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With cMonth
            .Items.Clear()
            For i As Integer = 1 To 12
                .Items.Add(i)
            Next
            .SelectedItem = Now.Month
        End With

        With cYear
            .Items.Clear()
            For i As Integer = 2013 To 2025
                .Items.Add(i)
            Next
            .SelectedItem = Now.Year
        End With

        sDate.DateTime = Now
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtHVHH.Text.Trim = String.Empty Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")
            If iDB.CheckHvhh(txtHVHH.Text.Trim) = False Then Throw New Exception("ՀՎՀՀ-ն բազայում բացակայում է")

            iDB.SetRetInvoiceDateCustom(sDate.DateTime, cYear.SelectedItem, cMonth.SelectedItem, txtHVHH.Text.Trim)

            txtHVHH.Text = String.Empty
            txtHVHH.Focus()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class