Public Class TelCellSetter

    Dim MIN_DATE As String
    Dim MAX_DATE As String

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        If DataGridView1.RowCount > 0 Then

            Dim d(DataGridView1.RowCount - 1) As Date

            For i As Integer = 0 To DataGridView1.RowCount - 1
                d(i) = CDate(DataGridView1.Rows(i).Cells("DATE").Value)
            Next

            MIN_DATE = d.Min.ToString("dd.MM.yyyy")
            MAX_DATE = d.Max.ToString("dd.MM.yyyy")

            TextBox1.Text = "Միջակայք " & MIN_DATE & " - " & MAX_DATE

        End If
    End Sub
    Private Sub ՀաստատելՎճարներըToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ՀաստատելՎճարներըToolStripMenuItem.Click
        Try
            If DataGridView1.SelectedRows.Count = 0 Then Throw New Exception("Նշված գանցում չկա")
            If MsgBox("Ցանկանու՞մ եք հաստատել վճարները", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            For i As Integer = 0 To DataGridView1.SelectedRows.Count - 1
                Call iDB.UpdateTelCellPaymentSetter(DataGridView1.SelectedRows(i).Cells("TELCELL_REF").Value)
                'Threading.Thread.Sleep(100)
                My.Application.DoEvents()
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

End Class