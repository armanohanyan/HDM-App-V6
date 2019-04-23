Public Class TesuchInfoAddWindow

    Private Sub LoadTesuch()
        Try
            Dim dt As DataTable = iDB.GetWorkingTesuchList()
            With cbTesuch
                .DataSource = dt
                .DisplayMember = "Տեսուչ"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .SelectedIndex = 0
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
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            iDB.InsertTesuchInfo(cbTesuch.SelectedValue, cbRegion.SelectedValue)
            MsgBox("Տվյալը հաջողությամբ ավելացվեց բազա", MsgBoxStyle.Information, My.Application.Info.Title)
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub TesuchInfoAddWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadTesuch()
        Call LoadRegion()
    End Sub

End Class