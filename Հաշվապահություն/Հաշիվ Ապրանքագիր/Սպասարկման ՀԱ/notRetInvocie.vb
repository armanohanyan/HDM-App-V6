Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class notRetInvocie

    Friend Y As Short
    Friend M As Byte
    Friend isAll As Boolean

    Dim iDuration As String = "00:00"

    Private Sub loadData()
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            sTime = Now

            If isAll = True Then
                dt = iDB.GetNotReturnedInvoiceALL()
            Else
                dt = iDB.GetNotReturnedInvoice(Y, M)
            End If

            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("InvoiceID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("Կազմակերպություն").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "{0}")
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
    Private Sub NotPrintedSupportInvoiceWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call loadData()
    End Sub
    Private Sub mnuSET_Click(sender As Object, e As EventArgs) Handles mnuSET.Click
        Try
            If CheckPermission2("EEDDD9F2F8A444199874D09770864A5C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If MsgBox("Հաստատել Հ/Ա Վերադարձը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            Dim f As New SetInvoiceReturnDate

            For i As Integer = 0 To GridView1.SelectedRowsCount - 1
                f.RID.Add(New RecordID(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("InvoiceID")))
            Next

            f.ShowDialog()
            f.Dispose()

            Call loadData()

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