Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class ExcludedHvhhForInvoice

    Private iDuration As String = "00:00"

    Private Sub LoadData()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            Dim dt As DataTable

            sTime = Now

            dt = iDB.GetExcludedHVHH()

            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ՀՀ").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .BestFitColumns(True)
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "{0}")
                    GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
            Dim duration As TimeSpan = eTime - sTime
            iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
        End Try
    End Sub
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            If CheckPermission2("6CC34A50604446E6A06DCC54D08A6F30") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If String.IsNullOrEmpty(txtHVHH.Text) Then Exit Sub

            Dim hvhh As String = txtHVHH.Text.Trim

            iDB.InsertExcludedHvhh(hvhh)

            txtHVHH.Text = String.Empty
            txtHVHH.Focus()

            Call LoadData()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ExcludedHvhhForInvoice_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub ExcludedHvhhForInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
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
    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Try
            If CheckPermission2("EA4CD1939E804A7684B40CB4E850C8C7") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
            Dim recID As Short = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
            Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
            If q = MsgBoxResult.Yes Then
                iDB.DeleteExcludedHVHH(recID)
                MsgBox("Գրանցումը հաջողությամբ ջնջվեց", MsgBoxStyle.Information, My.Application.Info.Title)
                Call LoadData()
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            If CheckPermission2("6DD0B8B9D3B14AB0ACD852516A656D90") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If MsgBox("Ցանկանու՞մ եք ջնջել բոլոր գրանցումները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub
            iDB.TruncateExcludeHVHH()
            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            LoadData()
        End Try
    End Sub
    Private Sub btnLoadExcel_Click(sender As Object, e As EventArgs) Handles btnLoadExcel.Click
        Dim lForm As New Working
        Try
            If CheckPermission2("269CD9CCB99845A19343EF597858A819") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim s As String = String.Empty
            Dim fl As OpenFileDialog = New OpenFileDialog

            With fl
                .Filter = ""
                .Multiselect = False
                .Title = "Նշեք Excel-ի Ֆայլ"
                If .ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
                If String.IsNullOrEmpty(.FileName) Then Exit Sub
                s = .FileName
            End With

            lForm.Show() : My.Application.DoEvents()

            lForm.Width = 500
            lForm.Text = "Excel-ի ֆայլից Տվյալների ստացում"
            lForm.Refresh()

            'Get Data From Excel File
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim ExcelDataSet As System.Data.DataSet
            Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & s & ";Extended Properties=Excel 12.0;")

            ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [Sheet1$]", MyConnection)
            ExcelAdapter.TableMappings.Add("Table", "Excel Data")
            ExcelDataSet = New System.Data.DataSet
            ExcelAdapter.Fill(ExcelDataSet)
            MyConnection.Close()

            iDB.BulkExcludeHVHH(ExcelDataSet.Tables(0))

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            lForm.Close()
            lForm.Dispose()

            LoadData()
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

End Class