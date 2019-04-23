Imports DevExpress.XtraGrid

Public Class ViewActivateHaytSelector

    Private Sub ViewActivateHaytSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        sDate.DateTime = New Date(Now.Year, Now.Month, 1)
        eDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim frmX As New Working
        frmX.Show()
        Try
            Dim dt As DataTable

            Dim sd As Date = sDate.DateTime
            Dim ed As Date = DateAdd(DateInterval.Day, 1, eDate.DateTime)

            If ckInterval.Checked AndAlso ckOpen.Checked Then
                dt = iDB.ActivateHaytByDateByOpen(sd, ed)
            ElseIf ckInterval.Checked AndAlso ckOpen.Checked = False Then
                dt = iDB.ActivateHaytByDate(sd, ed)
            ElseIf ckInterval.Checked = False AndAlso ckOpen.Checked Then
                dt = iDB.ActivateHaytByOpen(False)
            ElseIf ckInterval.Checked = False AndAlso ckOpen.Checked = False Then
                dt = iDB.ActivateHaytByOpen(True)
            End If

            Call CloseWindow("nActiveHaytWin")

            Dim f As New ActiveHaytWin
            AddChildForm("nActiveHaytWin", f)

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = dt
            With f.GridView1
                If .RowCount > 0 Then
                    If .Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                        Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "{0}")
                        .Columns("ՀԴՄ").Summary.Add(item)
                    End If
                End If
            End With
            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            frmX.Dispose()
        End Try
    End Sub

End Class