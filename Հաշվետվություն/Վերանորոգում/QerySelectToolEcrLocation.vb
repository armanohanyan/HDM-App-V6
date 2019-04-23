Public Class QerySelectToolEcrLocation

    Private Sub QerySelectToolRegEcrCount_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Dim dt As DataTable = iDB.GetSupporterForSelect()
            With cSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                If iUser.DB <> 5 Then .SelectedValue = iUser.DB : cSupporter.Enabled = False
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Call CloseWindow("nRepEcrLocation")
        Dim f As New RepEcrLocation With {.supporterID = cSupporter.SelectedValue, .OnlyOpen = cOpen.Checked}
        AddChildForm("nRepEcrLocation", f)
        Me.Close()
    End Sub

End Class