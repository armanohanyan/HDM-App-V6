Public Class GPSForEcrRep

    Friend Ecr As String

    Friend Property IsOK As Boolean = False

    Friend GPSX As New GPS With {.Latitude = String.Empty, .Longitude = String.Empty}

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtLatitude.Text.Trim = String.Empty Then Throw New Exception("Latitude-ը նշված չէ")
            If txtLongitude.Text.Trim = String.Empty Then Throw New Exception("Longitude-ը նշված չէ")

            iDB.AddGPSForEcr(Ecr, txtLatitude.Text.Trim, txtLongitude.Text.Trim)

            IsOK = True
            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub GPSForEcrRep_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Not String.IsNullOrEmpty(GPSX.Latitude) AndAlso Not String.IsNullOrEmpty(GPSX.Longitude) Then
            txtLatitude.Text = GPSX.Latitude
            txtLongitude.Text = GPSX.Longitude
        End If
    End Sub

End Class