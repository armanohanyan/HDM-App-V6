Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class RepPayWindow

    Private iDuration As String = "00:00"
    Friend PartqBySupporter As Boolean = False

    Private Sub RepPayWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub mnuExportToExcel_Click(sender As Object, e As EventArgs) Handles mnuExportToExcel.Click
        Try
            ExportTo(ExportType.Excel2013, Me)
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
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
    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next

        If PartqBySupporter = True Then
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                Dim Colored As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀնիցԱռկա"))
                If Colored = "Checked" Then
                    e.Appearance.BackColor = Color.FromArgb(255, 153, 153)       ' Color.Salmon
                    e.Appearance.BackColor2 = Color.White            ' Color.SeaShell
                End If
            End If
        End If

    End Sub

End Class