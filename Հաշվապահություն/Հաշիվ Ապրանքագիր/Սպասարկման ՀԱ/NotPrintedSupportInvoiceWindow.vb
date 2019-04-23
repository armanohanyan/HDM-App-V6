Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class NotPrintedSupportInvoiceWindow

    Friend Y As Short
    Friend M As Byte

    Dim iDuration As String = "00:00"

    Private Sub loadData()
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            sTime = Now
            dt = iDB.GetNotPrintedInvoice(Y, M)

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
                .Columns("Կազմակերպություն").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "{0}")
                    GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
                End If

                If GridView1.Columns("Գումար").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Գումար", "{0:n2}")
                    GridView1.Columns("Գումար").Summary.Add(item)
                End If
            End If


            GridView1.ClearColumnsFilter()
            GridView1.Columns("Գումար").FilterInfo = New ColumnFilterInfo("[Գումար] IS Null")
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
    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next

        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then

            Dim NotServed As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ԸնթացիկՉսպասարկվող"))
            If NotServed = "Checked" Then
                e.Appearance.BackColor = Color.Red        ' Color.Salmon
                e.Appearance.BackColor2 = Color.Orange            ' Color.SeaShell
            End If

            Dim NotServed2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՄիջակայքումՉսպասարկվող"))
            If NotServed2 = "Checked" Then
                e.Appearance.BackColor = Color.Red        ' Color.Salmon
                e.Appearance.BackColor2 = Color.Orange            ' Color.SeaShell
            End If

        End If

    End Sub

End Class