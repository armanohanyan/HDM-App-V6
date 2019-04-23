Public Class GprsRealStatus

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            If txtGprs.Text.Trim = String.Empty Then Throw New Exception("GPRS-ը գրված չէ")

            Dim g As String = txtGprs.Text.Trim

            txtGprs.Enabled = False
            btnCheck.Enabled = False

            Dim client As New OrangeServiceReference.ClientServerConnecterClient
            client.Open()

            Dim r As String = String.Empty

            r = client.CheckGprsStatus(g)

            txtResult.Text = "GPRS -> " & txtGprs.Text.Trim & vbCrLf & vbCrLf & "Կարգավիճակ՝ " & r
            client.Close()

            client = Nothing

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            txtGprs.Enabled = True
            txtGprs.Text = String.Empty
            btnCheck.Enabled = True
        End Try
    End Sub

End Class