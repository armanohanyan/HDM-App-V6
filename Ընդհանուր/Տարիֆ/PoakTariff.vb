Imports DevExpress.XtraGrid

Public Class PoakTariff

    Private iDuration As String = "00:00"

    Private Sub LoadData()
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            sTime = Now
            dt = iDB.GetPoskLastTarifList()
            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
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

                .Columns("hvhh").Caption = "ՀՎՀՀ"
                .Columns("Price").Caption = "Տարիֆ"
                .Columns("TarifDate").Caption = "Ավելացման Ամսաթիվ"
                .Columns("LoginName").Caption = "Օգտվող"

                .Columns("hvhh").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("hvhh").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "hvhh", "{0}")
                    GridView1.Columns("hvhh").Summary.Add(item)
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

    Private Sub PoakTariff_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim FileName As String = String.Empty

            Dim o As New OpenFileDialog
            With o
                .Filter = "Excel-ի ֆայլ|*.xlsx"
                .Multiselect = False
                .Title = "Նշեք Excel-ի ֆայլը"

                If .ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

                FileName = .FileName
            End With

            If String.IsNullOrEmpty(FileName) Then Throw New Exception("Excel-ի ֆայլը նշված չէ")

            'Load From Excel
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim ExcelDataSet As System.Data.DataSet
            Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & FileName & ";Extended Properties=Excel 12.0;")
            ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT [hvhh],[tariff] FROM [Sheet$] WHERE [hvhh] IS NOT NULL AND [tariff] IS NOT NULL", MyConnection)

            ExcelAdapter.TableMappings.Add("Table", "Excel Data")
            ExcelDataSet = New System.Data.DataSet
            ExcelAdapter.Fill(ExcelDataSet)
            MyConnection.Close()

            Dim dt As DataTable = ExcelDataSet.Tables(0)
            dt.TableName = "ImportTarif"

            iDB.ImportTarif(dt, iUser.UserID)

            Call LoadData()

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
            Dim grid As DevExpress.XtraGrid.GridControl = sender
            Dim view As New DevExpress.XtraGrid.Views.Grid.GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

End Class