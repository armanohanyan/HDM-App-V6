Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class DeleteGPRSWindow

    Private Sub LoadData()
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

            lForm.Width = 500
            lForm.Text = "Excel-ի ֆայլից Տվյալների ստացում"
            lForm.Refresh()

            'Get Data From Excel File
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim ExcelDataSet As System.Data.DataSet
            Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & s & ";Extended Properties=Excel 12.0;")

            ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT gprs FROM [Sheet1$]", MyConnection)
            ExcelAdapter.TableMappings.Add("Table", "Excel Data")
            ExcelDataSet = New System.Data.DataSet
            ExcelAdapter.Fill(ExcelDataSet)
            MyConnection.Close()

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = ExcelDataSet.Tables(0)

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
                .OptionsCustomization.AllowSort = False
                .BestFitColumns(True)
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("gprs").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "gprs", "{0}")
                    GridView1.Columns("gprs").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            lForm.Close()
        End Try
    End Sub
    Private Sub DeleteGPRSWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub
    Private Sub mnuDelGPRS_Click(sender As Object, e As EventArgs) Handles mnuDelGPRS.Click
        Try
            If MsgBox("Ցանկանու՞մ եք ջնջել բոլոր գրանցումները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            If GridView1.RowCount = 0 Then Throw New Exception("Ջնջելու ենթակա GPRS չկա")

            Dim DG As New List(Of DelGprs)

            For i As Integer = 0 To GridView1.RowCount - 1
                DG.Add(New DelGprs(GridView1.GetRowCellValue(i, "gprs")))
            Next

            Dim dt As DataTable = ToDataTable(DG)

            iDB.DelGprsList(dt)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

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

End Class