Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class PoakHdmStatus

    Private iDuration As String = "00:00"

    Private Sub PoakHdmStatus_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub PoakHdmStatus_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error Resume Next
        With cbYear
            .Items.Clear()
            .Items.Add("Բոլոր Տարիները")
            For i As Integer = 2013 To 2030
                .Items.Add(i)
            Next
            .SelectedItem = Now.Year
        End With

        With cbMonth
            .Items.Clear()
            .Items.Add("Բոլոր Ամիսները")
            For i As Integer = 1 To 12
                .Items.Add(i)
            Next
            .SelectedItem = Now.Month
        End With
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbYear.SelectedIndexChanged
        On Error Resume Next
        If cbMonth.Items.Count = 0 Then Exit Sub
        If cbYear.SelectedIndex = 0 Then
            cbMonth.SelectedIndex = 0
            cbMonth.Enabled = False
        Else
            cbMonth.Enabled = True
            cbMonth.SelectedItem = Now.Month
        End If
    End Sub

#Region "Menu"

    'Export Records
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

#End Region

    Private Sub btnGetStatus_Click(sender As Object, e As EventArgs) Handles btnGetStatus.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            If String.IsNullOrEmpty(txtHdm.Text) Then Throw New Exception("ՀԴՄ-ն գրված չէ")
            Dim dt As DataTable

            sTime = Now
            If cbYear.SelectedIndex = 0 AndAlso cbMonth.SelectedIndex = 0 Then
                dt = iDB.HDMStatusByPoak(txtHdm.Text.Trim, 0, 0)
            ElseIf cbYear.SelectedIndex <> 0 AndAlso cbMonth.SelectedIndex = 0 Then
                dt = iDB.HDMStatusByPoak(txtHdm.Text.Trim, cbYear.SelectedItem, 0)
            Else
                dt = iDB.HDMStatusByPoak(txtHdm.Text.Trim, cbYear.SelectedItem, cbMonth.SelectedItem)
            End If

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
                .BestFitColumns(True)
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
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            Dim dt As DataTable

            sTime = Now
            If cbYear.SelectedIndex = 0 Then
                'Բոլոր Տարիները
                dt = iDB.GetWorkingDaysCountByCompany
            Else
                If cbMonth.SelectedIndex = 0 Then
                    'Տարվա Բոկոր Ամիսները
                    dt = iDB.GetWorkingDaysCountByMonth(cbYear.SelectedItem)
                Else
                    'Կոնկրետ Ամիս
                    Dim sYear As Date = New Date(cbYear.SelectedItem, cbMonth.SelectedItem, 1)
                    dt = iDB.GetWorkingDaysCountByYearAndMonth(sYear)
                End If
            End If
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
                .BestFitColumns(True)
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "Քանակ {0}")
                    GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
                End If
                If GridView1.Columns("ՀԴՄՔանակ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ՀԴՄՔանակ", "ՀԴՄ Քանակ {0}")
                    GridView1.Columns("ՀԴՄՔանակ").Summary.Add(item)
                End If
                If GridView1.Columns("Oր").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Oր", "Oր {0}")
                    GridView1.Columns("Oր").Summary.Add(item)
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