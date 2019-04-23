Public Class TesuchRegion

    Friend iTesuch As String
    Friend iTesuchID As Short

    Private Sub LoadTesuchRegion()
        Try
            Dim dt As DataTable = iDB.GetTesuchRegion(iTesuchID)

            With cbRegion
                .DataSource = dt
                .DisplayMember = "Region"
                .ValueMember = "RegionID"
                If cbRegion.Items.Count = 0 Then btnUpdate.Enabled = False
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadTesuch()
        Try
            Dim dt As DataTable = iDB.GetWorkingTesuchList()

            With cbNewTesuch
                .DataSource = dt
                .DisplayMember = "Տեսուչ"
                .ValueMember = "ՀՀ"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub TesuchRegion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtOldTesuch.Text = iTesuch
        Call LoadTesuchRegion()
        Call LoadTesuch()
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If iTesuchID = cbNewTesuch.SelectedValue Then Throw New Exception("Ընտրեք այլ տեսուչի")

            iDB.ChangeRegionByTesuch(iTesuchID, cbNewTesuch.SelectedValue, cbRegion.SelectedValue)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Call LoadTesuchRegion()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class