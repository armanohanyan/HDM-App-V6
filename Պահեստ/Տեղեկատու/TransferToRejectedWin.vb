Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class TransferToRejectedWin

    Private Sub LoadReject()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            Dim dt As DataTable

            sTime = Now
            dt = iDB.RejList()
            eTime = Now

            Call CloseWindow("nxotan")
            Dim f As New xotanpoakmarka With {.Text = "Խոտանի Պահեստ"}
            AddChildForm("nxotan", f)

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = Nothing
            f.GridView1.Columns.Clear()

            f.GridControl1.DataSource = dt


            With f.GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With
            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Սարքավորում").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Սարքավորում", "Քանակ {0}")
                    f.GridView1.Columns("Սարքավորում").Summary.Add(item)
                End If
            End If

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
        End Try
    End Sub

    Private Sub txtShtrikh_TextChanged(sender As Object, e As EventArgs) Handles txtShtrikh.TextChanged
        Try
            If txtShtrikh.Text.Trim.Length <> 7 Then Exit Sub

            iDB.MoveToRejected(txtShtrikh.Text.Trim, txtComment.Text.Trim)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            txtComment.Text = String.Empty
            txtShtrikh.Text = String.Empty
            txtComment.Focus()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub TransferToRejectedWin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call LoadReject()
    End Sub

End Class