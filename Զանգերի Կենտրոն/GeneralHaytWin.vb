Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class GeneralHaytWin

    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next

        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim stat As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Կարգավիճակ"))
            If stat <> "Checked" Then
                e.Appearance.BackColor = Color.Green ' Color.Salmon
                e.Appearance.BackColor2 = Color.Yellow ' Color.SeaShell
            End If

            Dim d As Date = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀայտիԱմսաթիվ"))
            If Now.Date > DateAdd(DateInterval.Day, 3, d) AndAlso stat <> "Checked" Then
                e.Appearance.BackColor = Color.Red ' Color.Salmon
                e.Appearance.BackColor2 = Color.Orange ' Color.SeaShell
            End If

        End If

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

End Class