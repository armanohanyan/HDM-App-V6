Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class RepNoSupport

    Private iDuration As String = "00:00"

    Private Sub DisableClient(ByVal hvhh As String)
        On Error Resume Next
        iDB.AddNewBlockedClient(hvhh, iUser.LoginName)
    End Sub
    Private Sub LoadData()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            dt = iDB.RepNotSuppClient()

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = True
                .OptionsBehavior.ReadOnly = False
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("ՀՎՀՀ").OptionsColumn.ReadOnly = True
                .Columns("Կազմակերպություն").OptionsColumn.ReadOnly = True
                .Columns("Վճար").OptionsColumn.ReadOnly = True
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "{0}")
                    GridView1.Columns("Կազմակերպություն").Summary.Add(item)
                End If

            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub ReRegInvoice_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub mnuExportToExcel_Click(sender As Object, e As EventArgs) Handles mnuExportToExcel.Click
        Try
            ExportTo2(ExportType.Excel2013, GridControl1)
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ReRegInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
    End Sub
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs)
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtHVHH.Text.Trim = String.Empty Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")

            If MsgBox("Ցանկանու՞մ եք դադարեցնել գործընկերոջ սպասարկումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            iDB.AddNewBlockedClient(txtHVHH.Text.Trim, iUser.LoginName)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            txtHVHH.Text = String.Empty
            txtHVHH.Focus()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            LoadData()
        End Try
    End Sub
    Private Sub mnuSelectAll_Click(sender As Object, e As EventArgs) Handles mnuSelectAll.Click
        On Error Resume Next

        If GridView1.RowCount = 0 Then Exit Sub

        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.GetRow(i).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuSelectRows_Click(sender As Object, e As EventArgs) Handles mnuSelectRows.Click
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = True
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
    Private Sub mnuEnable_Click(sender As Object, e As EventArgs) Handles mnuEnable.Click
        Try
            If GridView1.RowCount = 0 Then Exit Sub

            If MsgBox("Ցանկանու՞մ եք ակտիվացնել գործընկերոջ սպասարկումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True Then
                    iDB.ActivateClient(GridView1.GetRowCellValue(i, "ՀՎՀՀ"), iUser.LoginName)
                End If
            Next

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
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim formX As New Working
        Try
            If MsgBox("Ցանկանու՞մ եք դադարեցնել գործընկերոջ սպասարկումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

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

                formX.Show() : My.Application.DoEvents()

                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        DisableClient(dt.Rows(i)("hvhh"))
                    Next
                Else
                    Throw New Exception("Գրանցումներ չեն հայտնաբերվել")
                End If
            End With

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Dispose()
            LoadData()
        End Try
    End Sub
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        On Error Resume Next
        GridControl1.EndUpdate()
    End Sub
    Private Sub btnRepDetails_Click(sender As Object, e As EventArgs) Handles btnRepDetails.Click
        Call CloseWindow("nNotSupportedClientsDetails")
        Dim f As New NotSupportedClientsDetails
        AddChildForm("nNotSupportedClientsDetails", f)
    End Sub
    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        If CheckPermission2("D631EC61178843079D25E675B5111AD3") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        Call CloseWindow("nNotSuppClientHistory")
        Dim f As New NotSuppClientHistory
        AddChildForm("nNotSuppClientHistory", f)
    End Sub

End Class