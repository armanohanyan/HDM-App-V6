Public Class QerySelectToolRemakeRep

    Private Sub QerySelectToolRegEcrCount_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        sDate.Properties.MaxValue = Now
        eDate.Properties.MaxValue = Now

        sDate.DateTime = Now ' DateSerial(Now.Year, Now.Month, 1)
        eDate.DateTime = Now 'DateSerial(Now.Year, Now.Month + 1, 1 - 1)

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
        Call CloseWindow("tRepRemakeEcr")
        Dim f As New RepRemakeEcr With {.supporterID = cSupporter.SelectedValue, .sDate = sDate.DateTime, .eDate = eDate.DateTime}
        AddChildForm("tRepRemakeEcr", f)
        Me.Close()
    End Sub

End Class