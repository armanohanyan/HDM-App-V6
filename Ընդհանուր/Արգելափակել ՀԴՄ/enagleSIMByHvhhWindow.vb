Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class enagleSIMByHvhhWindow

    Private iDuration As String = "00:00"

    Dim NotSupportedClients As New DataTable

    Private Sub loadNotSupportedClients()
        On Error Resume Next
        NotSupportedClients = iDB.GetNotServedClients()
    End Sub
    Private Sub LoadData()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            Dim dt As DataTable

            sTime = Now
            dt = iDB.GetListOfEnablingSIMByHVHH
            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("ՀՎՀՀ").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                .Columns("ՀԴՄ").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                .BestFitColumns(True)
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
    Private Sub enagleSIMByHvhhWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
        If CheckPermission2("E6F6B2A703534EFF8D06B67725FE6427") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Call LoadData()
    End Sub
    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Try
            If CheckPermission2("F28456D4C8854FC0939B0BD671A31440") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            If Not (MsgBox("Ցանկանում ե՞ք ջնջել գրանցումները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title).Equals(MsgBoxResult.Yes)) Then Exit Sub

            Dim ID As New List(Of RecordID)

            For i As Integer = 0 To GridView1.SelectedRowsCount - 1
                ID.Add(New RecordID(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ID")))
            Next

            Dim dt As DataTable = ToDataTable(ID)

            iDB.UpdateSIMByHvhhWindow(dt)

            MsgBox("Գրանցումները ջնջվեցին", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            btnQuery.PerformClick()
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If CheckPermission2("11CF2865B05F46BB962B1DD5B5C50C00") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If String.IsNullOrEmpty(txtHVHH.Text) Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")

            Dim hvhh As String = txtHVHH.Text.Trim

            'UnCheck Not Supported
            If NotSupportedClients.Rows.Count > 0 Then
                For j As Integer = 0 To NotSupportedClients.Rows.Count - 1
                    If hvhh = NotSupportedClients.Rows(j)("HVHH") Then
                        Throw New Exception("Գործընկերը արգելափակված է")
                    End If
                Next
            End If

            If iUser.DB = 5 Then
                iDB.InsertSIMEnableByHVHH(hvhh)
            Else
                iDB.InsertSIMEnableByHVHH2(hvhh, iUser.DB)
            End If

            txtHVHH.Text = String.Empty
            txtHVHH.Focus()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            btnQuery.PerformClick()
        End Try
    End Sub
    Private Sub enagleSIMByHvhhWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call loadNotSupportedClients()
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
    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        On Error Resume Next

        Dim View As GridView = sender
        If e.Column.FieldName = "Հուսալիություն" Then
            Dim ColPercent = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Հուսալիություն"))

            Dim r1 As Integer = 2.55 * (100 - ColPercent)
            If r1 > 255 Then r1 = 255

            Dim r2 As Integer = (0.64 * (100 - ColPercent)) + 191
            If r2 > 255 Then r2 = 255

            e.Appearance.BackColor = Color.FromArgb(r1, r2, 255)
            e.Appearance.BackColor2 = Color.White
        End If

    End Sub

End Class