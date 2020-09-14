Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class EcrSelecterForRemake

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            If CheckPermission2("2EEB43EEA6774E92A6B3758C0A9692C4") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If txtEcr.Text.Trim.Length <> 12 Then Throw New Exception("ՀԴՄ-ն սխալ է գրված")

            If iDB.IsEcrExists(txtEcr.Text.Trim, iUser.DB) = False Then Throw New Exception("ՀԴՄ-ն բացակայում է")
            If iDB.IsHvhhChanged(txtEcr.Text.Trim) = True Then Throw New Exception("ՀԴՄ-ն ենթակա է վերագրանցման")

            If iDB.IsEcrBloked(txtEcr.Text.Trim) = True Then Throw New Exception("ՀԴՄ-ն արգելափակված է")

            Call CloseWindow("nRemakeWindow")
            Dim f As New RemakeWindow With {.Ecr = txtEcr.Text.Trim}
            AddChildForm("nRemakeWindow", f)
            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub txtEcr_TextChanged(sender As Object, e As EventArgs) Handles txtEcr.TextChanged
        If txtEcr.Text.Trim.Length = 1 Then
            If txtEcr.Text.StartsWith("V") Then
                txtEcr.Text = txtEcr.Text.Replace("V", "V90413") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("v") Then
                txtEcr.Text = txtEcr.Text.Replace("v", "V90413") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("Q") Then
                txtEcr.Text = txtEcr.Text.Replace("Q", "Q80414") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("q") Then
                txtEcr.Text = txtEcr.Text.Replace("q", "Q80414") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("S") Then
                txtEcr.Text = txtEcr.Text.Replace("S", "S90055") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("s") Then
                txtEcr.Text = txtEcr.Text.Replace("s", "S90055") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("A") Then
                txtEcr.Text = txtEcr.Text.Replace("A", "A90022") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("a") Then
                txtEcr.Text = txtEcr.Text.Replace("a", "A90022") : txtEcr.SelectionStart = txtEcr.Text.Length
            End If
        End If
    End Sub

End Class