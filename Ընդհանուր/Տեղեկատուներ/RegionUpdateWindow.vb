Public Class RegionUpdateWindow

    Friend iRegion As String = String.Empty
    Friend iRegionID As Short = 0

    'Load Default values
    Private Sub LoadDefaultValues()
        txtRegion.Text = iRegion
    End Sub

    'Form Load
    Private Sub RegionUpdateWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadDefaultValues()
        txtRegion.Focus()
    End Sub

    'Update
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrEmpty(txtRegion.Text) Then Throw New Exception("Տվյալները գրված չեն")

            iDB.UpdateRegionInfo(txtRegion.Text.Trim, iRegionID)

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