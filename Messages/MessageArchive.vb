Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class MessageArchive

    Private iDuration As String = "00:00"

    Private Sub LoadData()
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable

            sTime = Now
            dt = iDB.GetUserArchiveMessages(iUser.UserID)
            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("messageID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsView.ColumnAutoWidth = False
                .Columns("Ժամանակ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("Ժամանակ").DisplayFormat.FormatString = "HH:mm:ss dd.MM.yyyy"
                .Columns("Տեսակ").Width = 50
                .Columns("Ժամանակ").Width = 150
                .Columns("Օգտվող").Width = 100
                .Columns("Հաղորդագրություն").Width = 500
            End With

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Ժամանակ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Ժամանակ", "Քանակ {0}")
                    GridView1.Columns("Ժամանակ").Summary.Add(item)
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
        End Try
    End Sub
    Private Sub MessageArchive_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
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
    Private Sub MessageArchive_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            Dim ID As Integer = GridView1.GetFocusedDataRow.Item("messageID").ToString

            Dim dt As DataTable = iDB.GetUserMessages2(ID)

            If dt.Rows.Count = 1 Then
                Dim f As New CustomMseeageShow
                With f
                    .txtUser.Text = dt.Rows(0)("Օգտվող")
                    .txtMessage.Text = dt.Rows(0)("Հաղորդագրություն")
                    .ShowDialog()
                End With
                f.Dispose()
            End If

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