Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class SelectBankFile

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim lForm As New Working
        Try

            Dim SupporterID As Byte
            Dim SupporterText As String = String.Empty

            If hs.Checked = True Then SupporterID = 1 : SupporterText = "HDM SHTRIKH LLC"
            If te.Checked = True Then SupporterID = 2 : SupporterText = "TAMA ELECTRONIC LLC"
            If mk.Checked = True Then SupporterID = 3 : SupporterText = "MERI KRIST LLC"
            If tm.Checked = True Then SupporterID = 4 : SupporterText = "TOUCH-MASTER LLC"

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

            Me.Visible = False

            lForm.Show() : My.Application.DoEvents()

            Call CloseWindow("nBankFile")
            Dim f As New RepBank With {.SupporterID = SupporterID}
            AddChildForm("nBankFile", f)

            lForm.Width = 500
            lForm.Text = "Excel-ի ֆայլից Տվյալների ստացում"
            lForm.Refresh()

            'Get Data From Excel File
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim ExcelDataSet As System.Data.DataSet
            Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & s & ";Extended Properties=Excel 12.0;")

            ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT [Acc name] AS SupporterEnName,[Bank reference] AS BankReference,[Additional narrative] AS Info,[Value date (dd/mm/yyyy)] AS vDate,[Credit amount] AS Credit,[Debit amount] AS Debit FROM [Sheet1$]", MyConnection)
            ExcelAdapter.TableMappings.Add("Table", "Excel Data")
            ExcelDataSet = New System.Data.DataSet
            ExcelAdapter.Fill(ExcelDataSet)
            MyConnection.Close()

            'Տվյալների ճշտության ստուգում
            lForm.Text = "Տվյալների ճշտության ստուգում"
            lForm.Refresh()

            For i As Integer = 0 To ExcelDataSet.Tables(0).Rows.Count - 1
                If ExcelDataSet.Tables(0).Rows(i)(0) <> SupporterText Then
                    Throw New Exception("Ֆայլում առկա են գրանցում(ներ), որոնք չեն համապատասխանում սպասարկող կազմակերպությանը")
                    Exit Sub
                End If
            Next

            lForm.Text = "Բազայում տվյալների կարգաբերում և ստացում"
            lForm.Refresh()

            'Change [BankReference] Column Type

            Dim dt2 As DataTable = New System.Data.DataTable()
            dt2.Columns.Add("SupporterEnName", GetType(String))
            dt2.Columns.Add("BankReference", GetType(String))
            dt2.Columns.Add("Info", GetType(String))
            dt2.Columns.Add("vDate", GetType(Date))
            dt2.Columns.Add("Credit", GetType(Decimal))
            dt2.Columns.Add("Debit", GetType(Decimal))

            dt2.Load(ExcelDataSet.Tables(0).CreateDataReader(), System.Data.LoadOption.OverwriteChanges)

            Dim dt As DataTable
            dt = iDB.BankInfoWorker(dt2, SupporterID)

            f.GridControl1.BeginUpdate()
            f.GridView1.Columns.Clear()

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = Nothing
            f.GridView1.Columns.Clear()

            f.GridControl1.DataSource = dt

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            With f.GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = True
                .OptionsBehavior.ReadOnly = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsCustomization.AllowSort = False

                .Columns("R").Visible = False
                .Columns("ID").Visible = False

                .Columns("R").OptionsColumn.ReadOnly = True
                .Columns("ID").OptionsColumn.ReadOnly = True

                .Columns("Սպասարկող").OptionsColumn.ReadOnly = True
                .Columns("ԲանկայինՀղում").OptionsColumn.ReadOnly = True
                .Columns("ՏվյալներՕրիգինալ").OptionsColumn.ReadOnly = True
                .Columns("Ամսաթիվ").OptionsColumn.ReadOnly = True
                .Columns("Կրեդիտ").OptionsColumn.ReadOnly = True
                .Columns("Դեբետ").OptionsColumn.ReadOnly = True
                .Columns("ՀՎՀՀ").OptionsColumn.ReadOnly = True
                .Columns("Գործընկեր").OptionsColumn.ReadOnly = True

                .BestFitColumns(True)
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Սպասարկող").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Սպասարկող", "{0}")
                    f.GridView1.Columns("Սպասարկող").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            lForm.Close()
            Me.Close()
        End Try
    End Sub

End Class