Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class RepmustBeDisabled

    Private iDuration As String = "00:00"

    Private Sub ResetGrid()
        On Error Resume Next
        GridControl1.BeginUpdate()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
        GridControl1.EndUpdate()
    End Sub
    Private Sub mustBeDisabledEcrWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable

            formX.Show() : My.Application.DoEvents()
            sTime = Now
            dt = iDB.GetMustDisableGprsAll()
            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("Colored").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("Ամսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                .Columns("Կազմակերպություն").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "Քանակ {0}")
                    GridView1.Columns("ՀԴՄ").Summary.Add(item)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Dim duration As TimeSpan = eTime - sTime
            iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = Not GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ")
        Next
    End Sub
    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim Colored As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Colored"))
            If Colored = "Checked" Then
                e.Appearance.BackColor = Color.FromArgb(255, 153, 153)       ' Color.Salmon
                e.Appearance.BackColor2 = Color.White            ' Color.SeaShell
            End If
        End If
    End Sub
    Private Sub mnuSelectRow_Click(sender As Object, e As EventArgs) Handles mnuSelectRow.Click
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuSelectAll_Click(sender As Object, e As EventArgs) Handles mnuSelectAll.Click
        On Error Resume Next
        If GridView1.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.GetRow(i).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuDeselect_Click(sender As Object, e As EventArgs) Handles mnuDeselect.Click
        On Error Resume Next
        GridView1.ClearColumnsFilter()
        If GridView1.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.GetRow(i).Item("Նշիչ") = False
        Next
    End Sub
    Private Sub mnuExportSelected_Click(sender As Object, e As EventArgs) Handles mnuExportSelected.Click
        On Error Resume Next
        GridView1.ClearColumnsFilter()
        GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)
        mnuExportToExcel.PerformClick()
    End Sub
    Private Sub mnuSelectColored_Click(sender As Object, e As EventArgs) Handles mnuSelectColored.Click
        On Error Resume Next
        GridView1.ClearColumnsFilter()
        GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Colored", True)
        If GridView1.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            'GridView1.GetRow(i).Item("Նշիչ") = True
            GridView1.SetRowCellValue(i, "Նշիչ", True)
        Next
    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        On Error Resume Next

        Dim View As GridView = sender
        If e.Column.FieldName = "ՀուսալիությանՏոկոս" Then
            Dim ColPercent = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀուսալիությանՏոկոս"))

            Dim r1 As Integer = 2.55 * (100 - ColPercent)
            If r1 > 255 Then r1 = 255

            Dim r2 As Integer = (0.64 * (100 - ColPercent)) + 191
            If r2 > 255 Then r2 = 255

            e.Appearance.BackColor = Color.FromArgb(r1, r2, 255)
            e.Appearance.BackColor2 = Color.White
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