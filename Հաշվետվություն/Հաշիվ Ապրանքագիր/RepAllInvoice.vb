Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class RepAllInvoice

    Private iDuration As String = "00:00"

    Friend sDate As Date
    Friend eDate As Date

    Private Sub LoadData()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            sTime = Now
            Dim dt As DataTable

            formX.Show() : My.Application.DoEvents()

            dt = iDB.GetAllInvoice(iUser.DB, sDate, eDate)

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()

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
                .Columns("Գումար").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Գումար").DisplayFormat.FormatString = "n2"
                .Columns("ՄիավորիԱրժեք").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("ՄիավորիԱրժեք").DisplayFormat.FormatString = "n2"
                .Columns("ԱԱՀ").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("ԱԱՀ").DisplayFormat.FormatString = "n2"
                .Columns("ԱմբողջԳումար").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("ԱմբողջԳումար").DisplayFormat.FormatString = "n2"
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "{0}")
                    GridView1.Columns("Կազմակերպություն").Summary.Add(item)
                End If
                If GridView1.Columns("Գումար").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Գումար", "{0:n2}")
                    GridView1.Columns("Գումար").Summary.Add(item)
                End If
                If GridView1.Columns("ԱԱՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ԱԱՀ", "{0:n2}")
                    GridView1.Columns("ԱԱՀ").Summary.Add(item)
                End If
                If GridView1.Columns("ԱմբողջԳումար").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ԱմբողջԳումար", "{0:n2}")
                    GridView1.Columns("ԱմբողջԳումար").Summary.Add(item)
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
            iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub

    Private Sub RepAllInvoice_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
    Private Sub RepAllInvoice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub

End Class