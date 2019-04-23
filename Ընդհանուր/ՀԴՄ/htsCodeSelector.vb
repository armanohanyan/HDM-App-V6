Public Class htsCodeSelector

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Try
            If rAll.Checked = True Then

                Call CloseWindow("nhtsByInterval")
                Dim f As New htsByInterval With {.startValue = 0, .endValue = 100000000, .isNew = False}
                AddChildForm("nhtsByInterval", f)

                Me.Close()

            Else

                If String.IsNullOrEmpty(txtStart.Text) Then Throw New Exception("Սկիզբը նշված չէ")
                If String.IsNullOrEmpty(txtEnd.Text) Then Throw New Exception("Ավարտը նշված չէ")

                Call CloseWindow("nhtsByInterval2")
                Dim f As New htsByInterval With {.startValue = txtStart.Text, .endValue = txtEnd.Text, .isNew = True}
                AddChildForm("nhtsByInterval2", f)

                Me.Close()

            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub rInterval_CheckedChanged(sender As Object, e As EventArgs) Handles rInterval.CheckedChanged
        If rInterval.Checked = True Then
            txtStart.Enabled = True
            txtEnd.Enabled = True
        End If
    End Sub
    Private Sub rAll_CheckedChanged(sender As Object, e As EventArgs) Handles rAll.CheckedChanged
        If rAll.Checked = True Then
            txtStart.Enabled = False
            txtEnd.Enabled = False
        End If
    End Sub

End Class