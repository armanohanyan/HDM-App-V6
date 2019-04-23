Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class ClosedPropView

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub

        Dim url As String

        If (Not IsDBNull(GridView1.GetFocusedDataRow.Item("ՓակմանԿոորդինատ")) AndAlso Not GridView1.GetFocusedDataRow.Item("ՓակմանԿոորդինատ").ToString.StartsWith("0")) AndAlso (Not IsDBNull(GridView1.GetFocusedDataRow.Item("ՀայտիԿոորդինատ")) AndAlso Not GridView1.GetFocusedDataRow.Item("ՀայտիԿոորդինատ").ToString.StartsWith(0)) Then
            url = "https://www.google.com/maps/dir/'" & GridView1.GetFocusedDataRow.Item("ՀայտիԿոորդինատ") & "'/'" & GridView1.GetFocusedDataRow.Item("ՓակմանԿոորդինատ") & "'"
            WebBrowser1.Navigate(url)
        ElseIf Not IsDBNull(GridView1.GetFocusedDataRow.Item("ՓակմանԿոորդինատ")) AndAlso Not GridView1.GetFocusedDataRow.Item("ՓակմանԿոորդինատ").ToString.StartsWith("0") Then
            url = "https://www.google.com/maps/place/'" & GridView1.GetFocusedDataRow.Item("ՓակմանԿոորդինատ") & "'"
            WebBrowser1.Navigate(url)
        ElseIf Not IsDBNull(GridView1.GetFocusedDataRow.Item("ՀայտիԿոորդինատ")) Then
            url = "https://www.google.com/maps/place/'" & GridView1.GetFocusedDataRow.Item("ՀայտիԿոորդինատ") & "'"
            WebBrowser1.Navigate(url)
        Else

        End If
    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        On Error Resume Next

        Dim View As GridView = sender
        If e.Column.FieldName = "ՀայտիԿատարմանԱմսաթիվ" Then
            If Not IsDBNull(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀայտիԿատարմանԱմսաթիվ"))) Then
                If Not IsDBNull(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀայտիՓակմանԱմսաթիվ"))) Then
                    Dim val1 As Date = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀայտիԿատարմանԱմսաթիվ"))
                    Dim val2 As Date = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀայտիՓակմանԱմսաթիվ"))

                    If val1.Date < val2.Date Then
                        e.Appearance.BackColor = Color.FromArgb(233, 73, 87)
                        e.Appearance.BackColor2 = Color.FromArgb(242, 242, 242)
                    End If

                End If
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