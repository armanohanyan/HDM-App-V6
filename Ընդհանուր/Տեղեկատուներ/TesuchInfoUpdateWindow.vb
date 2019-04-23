Public Class TesuchInfoUpdateWindow

    Friend iTesuch As String = 0
    Friend iRegion As String = 0
    Friend iTesuchRegionID As Short

    Private Sub LoadTesuch()
        Try
            Dim dt As DataTable = iDB.GetWorkingTesuchList()
            With cbTesuch
                .DataSource = dt
                .DisplayMember = "Տեսուչ"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .Text = iTesuch
            End With
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadRegion()
        Try
            Dim dt As DataTable = iDB.GetRegion
            With cbRegion
                .DataSource = dt
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .Text = iRegion
            End With
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'Form Load
    Private Sub TesuchInfoUpdateWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadTesuch()
        Call LoadRegion()
        cbTesuch.Enabled = False
    End Sub

    'Update
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            iDB.UpdateTesuchRegionInfo(cbTesuch.SelectedValue, cbRegion.SelectedValue, iTesuchRegionID)
            MsgBox("Տվյալը հաջողությամբ փոփոխվեցին", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class