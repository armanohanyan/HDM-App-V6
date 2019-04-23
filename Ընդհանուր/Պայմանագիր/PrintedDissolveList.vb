Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class PrintedDissolveList

    Private iDuration As String = "00:00"

    Private Sub PrintedContractApplicationsWin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
    Private Sub PrintedContractApplicationsWin_Load(sender As Object, e As EventArgs) Handles Me.Load
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
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            If CheckPermission2("7E29171B27024512B598205F7E02E967") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            formX.Show() : My.Application.DoEvents()
            Dim dt As DataTable

            Dim sdate As Date = dtStartDate.DateTime
            Dim edate As Date = DateAdd(DateInterval.Day, 1, dtEndDate.DateTime)

            sTime = Now
            If ckByDate.Checked Then
                dt = iDB.GetContractDissolve(sdate, edate, False)
            Else
                dt = iDB.GetContractDissolve(sdate, edate, True)
            End If
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
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "Քանակ {0}")
                    GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
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
    Private Sub mnuReturned_Click(sender As Object, e As EventArgs) Handles mnuReturned.Click
        Try
            If CheckPermission2("50F3956FEEAA4126B90AD74620D7E7C7") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

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
                If Not IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ՎերադարձմանԱմսաթիվ")) Then Continue For

                Dim id As Integer = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ՀՀ")
                iDB.ReturnContractDissolve(id, d)
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
    Private Sub btnLoadWorking_Click(sender As Object, e As EventArgs) Handles btnLoadWorking.Click
        Call CloseWindow("nWorkingClientsDisolved")
        Dim f As New WorkingClientsDisolved
        AddChildForm("nWorkingClientsDisolved", f)
    End Sub

End Class