Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class GprsIntermediate

    Friend MustDisable As Boolean = False
    Friend isAll As Boolean = False
    Dim iDuration As String = "00:00"

    Private Sub GprsIntermediate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable

            formX.Show() : My.Application.DoEvents()

            sTime = Now

            If isAll = False Then
                If MustDisable = True Then
                    dt = iDB.GPRSStatusDisabled
                Else
                    dt = iDB.GPRSStatusEnabled
                End If
            Else
                dt = iDB.GPRSStatusAll
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
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("Ամսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                .Columns("Ամսաթիվ").DisplayFormat.FormatType = FormatType.DateTime
                .Columns("Ամսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH.mm"
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
    Private Sub mnuDel_Click(sender As Object, e As EventArgs) Handles mnuDel.Click
        Try
            If MsgBox("Ցանկանու՞մ եք ջնջել գրանցումները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            Dim gp As String = String.Empty

            For i As Integer = 0 To GridView1.SelectedRowsCount - 1
                gp = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("GPRS")

                iDB.DeleteGprs(gp)

                gp = String.Empty
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            GprsIntermediate_Shown(Me, Nothing)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class