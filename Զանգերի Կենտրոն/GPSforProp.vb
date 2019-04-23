Public Class GPSforProp

    Friend Property Loc As String = "0,0"

    Private Const CP_NOCLOSE_BUTTON As Integer = &H200

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtLatitude.Text.Trim = String.Empty OrElse txtLongitude.Text.Trim = String.Empty Then Throw New Exception("Կոորդինատները գրված չեն")

            Loc = txtLatitude.Text.Trim & "," & txtLongitude.Text.Trim

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class