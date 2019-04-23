Public Class GprsFileSelecter

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim lForm As New Working
        Try
            If CheckPermission2("F0FCA748F0F64DF4A09448369850625A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim o As Char
            If rOrange.Checked Then o = "o"
            If rViva.Checked Then o = "v"
            If rBeeline.Checked Then o = "b"

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

            lForm.Text = "Բազայում տվյալների կարգաբերում և ստացում"
            lForm.Refresh()

            'Add Select Data
            Dim dt As DataTable

            dt = iDB.AddBulkGprs(ExcelDataSet.Tables(0), o)

            Call CloseWindow("nAddShowGprs")
            Dim f As New AddShowGprs
            AddChildForm("nAddShowGprs", f)

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
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .BestFitColumns(True)
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

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