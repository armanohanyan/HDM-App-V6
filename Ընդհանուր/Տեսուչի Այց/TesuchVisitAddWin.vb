Imports DevExpress.Utils

Public Class TesuchVisitAddWin

    Private Sub LoadTesuchLList()
        Try
            Dim dt As DataTable = iDB.GetWorkingTesuchList

            With cTesuch
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
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtMGH.Text) Then Throw New Exception("Տվյալները գրված չեն")

            iDB.InsertTesuchVisit(txtMGH.Text.Trim, cTesuch.SelectedValue, cComment.SelectedItem, cDateEdit.DateTime)
            MsgBox("Տվյալը հաջողությամբ ավելացվեց բազա", MsgBoxStyle.Information, My.Application.Info.Title)

            txtMGH.Text = String.Empty
            txtMGH.Focus()

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub TesuchVisitAddWin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cDateEdit
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With
        cComment.SelectedIndex = 0
        Call LoadTesuchLList()
    End Sub

End Class