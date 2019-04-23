Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class ExcelToSQLWindow

    Dim iDT As New DataTable

    Private Sub LoadListOfDays()
        Dim formX As New Working
        formX.Show() : My.Application.DoEvents()
        Try
            Dim dt As DataTable = iDB.ListOfDays

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()
            GridControl1.DataSource = dt
            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("Ամսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            End With
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
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim lForm As New Working
        Try
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

            'Get Data From Excel File
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim ExcelDataSet As System.Data.DataSet
            Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & s & ";Extended Properties=Excel 12.0;")

            ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [Sheet0$]", MyConnection)
            ExcelAdapter.TableMappings.Add("Table", "Excel Data")
            ExcelDataSet = New System.Data.DataSet
            ExcelAdapter.Fill(ExcelDataSet)
            MyConnection.Close()

            GridControl2.BeginUpdate()
            GridView2.Columns.Clear()

            GridControl2.DataSource = ExcelDataSet.Tables(0)
            iDT = ExcelDataSet.Tables(0)

            GridView2.ClearSelection()
            GridControl2.EndUpdate()

            With GridView2
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

            If GridView2.RowCount > 0 Then
                If GridView2.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "{0}")
                    GridView2.Columns("ՀՎՀՀ").Summary.Add(item)
                End If
            End If

            GridView2.ClearSelection()
            GridControl2.EndUpdate()

            btnSave.Enabled = True
            btnLoad.Enabled = False

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            lForm.Close()
            lForm.Dispose()
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lForm As New Working
        btnSave.Enabled = False
        lForm.Show() : My.Application.DoEvents()
        Try
            If GridView2.RowCount = 0 Then Throw New Exception("Ֆայլը նշված չէ կամ գրանցումներ չկան")
            If IsNothing(iDT) Then Throw New Exception("Սկզբնական տվյալները անորոշ են")

            iDB.ExcelFileToSQLDB(iDT, sDate.DateTime)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            lForm.Close()
            lForm.Dispose()
            Me.Close()
        End Try
    End Sub
    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Call LoadListOfDays()
    End Sub
    Private Sub ExcelToSQLWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        sDate.DateTime = Now
    End Sub
    Private Sub ExcelToSQLWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadListOfDays()
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
    Private Sub GridControl2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl2.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl2.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

End Class