Public Class SetInvoiceReturnDate

    Friend RID As New List(Of RecordID)

    Private Sub SetInvoiceReturnDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sDate.DateTime = Now
    End Sub
    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        Try
            Dim dt As DataTable = ToDataTable(RID)
            iDB.SetRetInvoiceDate(dt, sDate.DateTime)

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