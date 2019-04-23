Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class TarifChangeContract

    Dim iDuration As String = String.Empty

    Private Sub TarifChangeContract_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With dtStartDate
            .DateTime = DateSerial(Now.Year, Now.Month, 1)
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With
        With dtEndDate
            .DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With
        With DDate
            .DateTime = Now.Date
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            Dim dt As DataTable

            Dim sdate As Date = dtStartDate.DateTime
            Dim edate As Date = DateAdd(DateInterval.Day, 1, dtEndDate.DateTime)

            sTime = Now

            dt = iDB.GetContractTarifChanged(sdate, edate)

            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("id").Visible = False
                .Columns("ClientID").Visible = False
                .Columns("SupportedID").Visible = False
                .Columns("TesuchID").Visible = False
                .Columns("PrintUserID").Visible = False
                .Columns("AcceptUser").Visible = False

                .Columns("HVHH").Caption = "ՀՎՀՀ"
                .Columns("CompanyName").Caption = "Գործընկեր"
                .Columns("Company").Caption = "Սպասարկող"
                .Columns("tesuchName").Caption = "Տեսուչ"
                .Columns("Tarif").Caption = "Սակագին"
                .Columns("PrintDate").Caption = "Տպման Ամսաթիվ"
                .Columns("PrintUserName").Caption = "Տպող"
                .Columns("ReturnDate").Caption = "Վերադարձի Ամսաթիվ"
                .Columns("AcceptUserName").Caption = "Վերադարձնող"

                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False

                For i As Integer = 0 To .Columns.Count - 1
                    .Columns(i).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                Next

            End With

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("HVHH").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "HVHH", "{0}")
                    GridView1.Columns("HVHH").Summary.Add(item)
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

    Private Sub mnuRet_Click(sender As Object, e As EventArgs) Handles mnuRet.Click
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            If Not MsgBox("Ցանկանու՞մ եք հաստատել որպես վերադարձված", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Application.Info.Title).Equals(MsgBoxResult.Yes) Then Exit Sub

            Dim d As Date
            Dim f As New ApprContractDateSelect
            With f
                .ShowDialog()
                d = .CurDate
                .Dispose()
            End With

            For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
                If Not IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ReturnDate")) Then Continue For

                Dim id As Integer = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("id")
                iDB.ReturnContractTarif(id, d)

                My.Application.DoEvents()
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            btnQuery.PerformClick()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim formX As New Working
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

            formX.Show() : My.Application.DoEvents()

            'Load From Excel
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim ExcelDataSet As System.Data.DataSet
            Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & FileName & ";Extended Properties=Excel 12.0;")

            ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT hvhh FROM [Sheet1$]", MyConnection)

            ExcelAdapter.TableMappings.Add("Table", "Excel Data")
            ExcelDataSet = New System.Data.DataSet
            ExcelAdapter.Fill(ExcelDataSet)
            MyConnection.Close()

            'GridControl1.DataSource = ExcelDataSet.Tables(0)
            If ExcelDataSet.Tables(0).Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            'Create List Of Hvhh
            Dim L As New List(Of ListOFHVHH)
            For i As Integer = 0 To ExcelDataSet.Tables(0).Rows.Count - 1
                L.Add(New ListOFHVHH With {.HVHH = ExcelDataSet.Tables(0).Rows(i)("hvhh")})
            Next

            'Convert List To DataTable
            Dim dt2 As DataTable = ToDataTable(L)

            'Get Data From DataBase
            Dim dt As DataTable = iDB.GetListOfHvhhForTarif(dt2)

            formX.Close()
            formX = Nothing

            'Show Window For Make Contract
            Dim f As New TarifContractMaker With {.Tarif = txtPrice.Text, .ContractDate = DDate.DateTime, .DT = dt}
            f.ShowDialog()
            f.Dispose()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            If Not IsNothing(formX) Then
                formX.Close()
                formX = Nothing
            End If
        End Try
    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New Views.Grid.GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

    Private Sub mnuExcel_Click(sender As Object, e As EventArgs) Handles mnuExcel.Click
        Try
            ExportTo2(ExportType.Excel2013, GridControl1)
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class

Public Class ListOFHVHH

    Public Property HVHH As String = String.Empty

End Class