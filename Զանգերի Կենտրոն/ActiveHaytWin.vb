Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class ActiveHaytWin

    Private Sub LoadOpenHayts()
        Dim frmX As New Working
        frmX.Show()
        Try
            Dim dt As DataTable
            dt = iDB.GetOpenActivateHayt(DateTime.MinValue, DateTime.MinValue)


            Call CloseWindow("nHaytActivateEdit")

            Dim f As New HaytActivateEdit
            AddChildForm("nHaytActivateEdit", f)

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = dt

            f.GridView1.Columns("ՀՀ").Visible = False
            f.GridView1.OptionsSelection.MultiSelect = True
            f.GridView1.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = True

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

    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next

        Dim View As GridView = sender
        'If (e.RowHandle >= 0) Then
        '    Dim stat As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Կարգավիճակ"))
        '    If stat <> "Checked" Then
        '        e.Appearance.BackColor = Color.Green ' Color.Salmon
        '        e.Appearance.BackColor2 = Color.Yellow ' Color.SeaShell
        '    End If

        '    Dim d As Date = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀայտիԱմսաթիվ"))
        '    If Now.Date > DateAdd(DateInterval.Day, 3, d) AndAlso stat <> "Checked" Then
        '        e.Appearance.BackColor = Color.Red ' Color.Salmon
        '        e.Appearance.BackColor2 = Color.Orange ' Color.SeaShell
        '    End If

        'End If

    End Sub
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub
    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        'Call LoadOpenHayts()
    End Sub

End Class