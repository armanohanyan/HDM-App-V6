Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class BlockedGPRS

    Private iDuration As String = "00:00"
    Friend iClientID As Integer = 0

    Private Sub LoadData()
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            sTime = Now
            If iClientID = 0 Then dt = iDB.BlockedGPRSListReport(iUser.DB) Else dt = iDB.BlockedGPRSListReport2(iClientID, iUser.DB)
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
    Private Sub BlockedGPRS_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub BlockedGPRS_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
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
    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next

        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then

            Dim NotServed As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("NotServed"))
            If NotServed = "Checked" Then
                e.Appearance.BackColor = Color.Red        ' Color.Salmon
                e.Appearance.BackColor2 = Color.Orange            ' Color.SeaShell
            End If

            Dim Colored As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Colored"))
            If Colored = "Checked" Then
                e.Appearance.BackColor = Color.GreenYellow       ' Color.Salmon
                e.Appearance.BackColor2 = Color.LightBlue            ' Color.SeaShell
            End If
        End If

    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        On Error Resume Next

        Dim View As GridView = sender
        If e.Column.FieldName = "ՀուսալիությանՏոկոս" Then
            Dim ColPercent = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀուսալիությանՏոկոս"))

            Dim r1 As Integer = 2.55 * (100 - ColPercent)
            If r1 > 255 Then r1 = 255

            Dim r2 As Integer = (0.64 * (100 - ColPercent)) + 191
            If r2 > 255 Then r2 = 255

            e.Appearance.BackColor = Color.FromArgb(r1, r2, 255)
            e.Appearance.BackColor2 = Color.White
        End If

    End Sub
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

            Dim ClientHvhh As String = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString
            Dim ClientID As Integer = iDB.ClientHVHHToClientID(ClientHvhh)
            If ClientID = 0 Then Exit Sub

            Dim f As New PaymentHistoryWin With {.IClientID = ClientID}
            With f
                .ShowDialog()
                .Dispose()
            End With

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

End Class