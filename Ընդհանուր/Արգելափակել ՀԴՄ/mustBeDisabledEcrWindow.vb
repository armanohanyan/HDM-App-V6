Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class mustBeDisabledEcrWindow

    Private iDuration As String = "00:00"

    Dim MOperator As String = "O"

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
            If CheckPermission2("5FEBB5B724724CCB9C3A0008F767FF92") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim dt As DataTable

            formX.Show() : My.Application.DoEvents()

            sTime = Now
            dt = iDB.GetMustDisableGprs(MOperator)
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
        Dim columnN As Integer = 0
        For Each column As DevExpress.XtraGrid.Columns.GridColumn In GridView1.Columns
            GridView1.Columns(columnN).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
            columnN = columnN + 1
        Next
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
    Private Sub mnuPrepareEmail_Click(sender As Object, e As EventArgs) Handles mnuPrepareEmail.Click
        On Error Resume Next

        If CheckPermission2("A8AE74BB409F4309898DF07BEB084BF5") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        GridView1.ClearColumnsFilter()
        GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)

        If GridView1.RowCount = 0 Then Exit Sub

        Dim th As New List(Of tempHDM)

        For i As Integer = 0 To GridView1.RowCount - 1
            th.Add(New tempHDM(GridView1.GetRowCellValue(i, "ՀԴՄ")))
        Next

        If IsNothing(th) OrElse th.Count = 0 Then MsgBox("Տվյալներ չկան", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Dim f As New PrepareMailSendWindow
        With f
            .iMailDirection = "Կասեցման Ենթակա"
            .iTempHdm = th
            .ShowDialog()
        End With
        f = Nothing
        GridView1.ClearColumnsFilter()

    End Sub
    Private Sub btnLoadHVHH_Click(sender As Object, e As EventArgs) Handles btnLoadHVHH.Click
        Try
            If CheckPermission2("03FB4C1D0C38455888BA3C9EB855DAFE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim fDialog As New OpenFileDialog
            With fDialog
                .Filter = "Microsoft Excel|*.xlsx"
                .Multiselect = False
                .Title = "Նշեք Excel-ի Ֆայլ"
                Dim result As DialogResult = .ShowDialog
                If result <> Windows.Forms.DialogResult.OK Then Exit Sub
                Dim s As String = .FileName
                If String.IsNullOrEmpty(s) Then Exit Sub

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim ExcelDataSet As System.Data.DataSet
                Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & s & ";Extended Properties=Excel 12.0;")

                ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT hvhh FROM [Sheet1$]", MyConnection)
                ExcelAdapter.TableMappings.Add("Table", "Excel Data")
                ExcelDataSet = New System.Data.DataSet
                ExcelAdapter.Fill(ExcelDataSet)
                Dim dt As DataTable = ExcelDataSet.Tables(0)
                MyConnection.Close()

                If dt.Rows.Count = 0 Then Exit Sub

                For i As Int32 = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Նշիչ") = True Then
                        For j As Integer = 0 To dt.Rows.Count - 1
                            If GridView1.GetRowCellValue(i, "ՀՎՀՀ") = dt.Rows(j)(0) Then GridView1.SetRowCellValue(i, "Նշիչ", False)
                        Next
                    End If
                Next

            End With

            MsgBox("Գործողությունը ավարտվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuDisableGprs_Click(sender As Object, e As EventArgs) Handles mnuDisableGprs.Click
        Dim formX As New Working
        Try
            If CheckPermission2("EE4F139B2D444A3A8F03BAE87CA7C600") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If Not MsgBox("Ցանկանու՞մ եք արգելափակել ՀԴՄ-ն", MsgBoxStyle.Question + MsgBoxStyle.YesNo).Equals(MsgBoxResult.Yes) Then Exit Sub

            GridView1.ClearColumnsFilter()
            GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)

            If GridView1.RowCount = 0 Then Throw New Exception("Նշված ՀԴՄ չկա")

            formX.Show() : My.Application.DoEvents()

            Dim cBlockGprsByHdm As New List(Of BlockGprsByHdm)

            For i As Integer = 0 To GridView1.RowCount - 1
                cBlockGprsByHdm.Add(New BlockGprsByHdm(GridView1.GetRowCellValue(i, "ՀԴՄ"), GridView1.GetRowCellValue(i, "Ամսաթիվ")))
            Next

            Dim dt2 As DataTable = ToDataTable(cBlockGprsByHdm)

            If MOperator = "O" Then
                iDB.BlockGprsByEcr2(dt2)
            Else
                iDB.BlockGprsByEcr(dt2)
            End If

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
            GridView1.ClearColumnsFilter()
            btnQuery.PerformClick()
        End Try
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
    Private Sub btnPremiums_Click(sender As Object, e As EventArgs) Handles btnPremiums.Click
        Dim formX As New Working
        Try
            If CheckPermission2("EF20FA750D294E2DBB3A9A34F78130A9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.RowCount = 0 Then Exit Sub
            formX.Show() : My.Application.DoEvents()

            Dim dt As DataTable
            dt = iDB.GetPremiumClientsHvhh()

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    For j As Integer = 0 To GridView1.RowCount - 1
                        If dt.Rows(i)("HVHH") = GridView1.GetRowCellValue(j, "ՀՎՀՀ") Then
                            GridView1.SetRowCellValue(j, "Նշիչ", False)
                        End If
                    Next
                Next

            End If

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

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
    Private Sub btnVarvac_Click(sender As Object, e As EventArgs) Handles btnVarvac.Click
        Dim formX As New Working
        Try
            If CheckPermission2("EF20FA750D294E2DBB3A9A34F78130A9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.RowCount = 0 Then Exit Sub
            formX.Show() : My.Application.DoEvents()

            Dim dt As DataTable
            dt = iDB.GetVarvacGPRS()

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    For j As Integer = 0 To GridView1.RowCount - 1
                        If dt.Rows(i)("gp") = GridView1.GetRowCellValue(j, "GPRS") Then
                            GridView1.SetRowCellValue(j, "Նշիչ", False)
                        End If
                    Next
                Next

            End If

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

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
    Private Sub cOrange_CheckedChanged(sender As Object, e As EventArgs) Handles cOrange.CheckedChanged
        Call ResetGrid()
        MOperator = "O"
    End Sub
    Private Sub cViva_CheckedChanged(sender As Object, e As EventArgs) Handles cViva.CheckedChanged
        Call ResetGrid()
        MOperator = "V"
    End Sub
    Private Sub cBeeline_CheckedChanged(sender As Object, e As EventArgs) Handles cBeeline.CheckedChanged
        Call ResetGrid()
        MOperator = "B"
    End Sub
    Private Sub cAllEcr_CheckedChanged(sender As Object, e As EventArgs) Handles cAllEcr.CheckedChanged
        Call ResetGrid()
        MOperator = "A"
    End Sub
    Private Sub btnInAction_Click(sender As Object, e As EventArgs) Handles btnInAction.Click
        If CheckPermission2("47DBC27B53144432869AD6466C8996E0") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Call CloseWindow("nGprsIntermediate1")
        Dim f As New GprsIntermediate With {.MustDisable = True}
        AddChildForm("nGprsIntermediate1", f)
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