Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class RepEcrForReplace

    Private iDuration As String = "00:00"

    Friend sDate As Date
    Friend eDate As Date

    Private Sub RepEcrForReplace_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
    Private Sub RepEcrForReplace_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime

        Try
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            eDate = DateAdd(DateInterval.Day, 1, eDate)

            sTime = Now
            dt = iDB.GetAllReplacedEcr(sDate, eDate, iUser.DB)
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
                .Columns("ՏրմանԱմսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .BestFitColumns(True)
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀաճախորդիՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀաճախորդիՀԴՄ", "Քանակ {0}")
                    GridView1.Columns("ՀաճախորդիՀԴՄ").Summary.Add(item)
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