Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Public Class RemakeDayCounterWindow

    Friend sDate As Date
    Friend eDate As Date

    Friend Direction As Byte

    Dim iDuration As String = String.Empty

    Private Sub LoadData()
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try

            formX.Show() : My.Application.DoEvents()
            sTime = Now

            Dim dt As DataTable

            Select Case Direction
                Case 1
                    dt = iDB.SrahOK(sDate, eDate)
                Case 2
                    dt = iDB.SrahNotOK(sDate, eDate)
                Case 3
                    dt = iDB.WarhowseOK(sDate, eDate)
                Case 4
                    dt = iDB.WarhowseExists(sDate, eDate)
                Case Else
                    Throw New Exception("Սխալ պարամետր")
            End Select

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
                If GridView1.Columns("ՔանակԿենտրոն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՔանակԿենտրոն", "{0}")
                    GridView1.Columns("ՔանակԿենտրոն").Summary.Add(item)
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
    Private Sub RemakeDayCounterWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            Dim RepDate As Date = GridView1.GetFocusedDataRow.Item("Ամսաթիվ")

            Dim view As GridView = TryCast(GridControl1.FocusedView, GridView)
            Dim column As GridColumn = view.FocusedColumn

            Dim dt As DataTable

            Call CloseWindow("nRepLocationListViewer")
            Dim f As New RepLocationListViewer

            If RepDate.Date = Now.Date Then
                Select Case Direction
                    Case 1
                        If column.AbsoluteIndex = 1 Then
                            dt = iDB.RepSrahOK1()
                        ElseIf column.AbsoluteIndex = 2 Then
                            dt = iDB.RepSrahOK2()
                        ElseIf column.AbsoluteIndex = 3 Then
                            dt = iDB.RepSrahOK3()
                        End If
                        f.Text = "Սրահում Առկա Նորոգված"
                    Case 2
                        If column.AbsoluteIndex = 1 Then
                            dt = iDB.RepSrahNotOK1()
                        ElseIf column.AbsoluteIndex = 2 Then
                            dt = iDB.RepSrahNotOK2()
                        ElseIf column.AbsoluteIndex = 3 Then
                            dt = iDB.RepSrahNotOK3()
                        End If
                        f.Text = "Սրահում Պատրաստ Չհաստատված"
                    Case 3
                        If column.AbsoluteIndex = 1 Then
                            dt = iDB.RepWarhowseOK1(RepDate)
                        ElseIf column.AbsoluteIndex = 2 Then
                            dt = iDB.RepWarhowseOK2(RepDate)
                        ElseIf column.AbsoluteIndex = 3 Then
                            dt = iDB.RepWarhowseOK3(RepDate)
                        End If
                        f.Text = "Արհեստանոցում Վերանորոգված"
                    Case 4
                        If column.AbsoluteIndex = 1 Then
                            dt = iDB.RepWarhowseExists1()
                        ElseIf column.AbsoluteIndex = 2 Then
                            dt = iDB.RepWarhowseExists2()
                        ElseIf column.AbsoluteIndex = 3 Then
                            dt = iDB.RepWarhowseExists3()
                        End If
                        f.Text = "Արհեստանոցում Առկա"
                End Select
            Else
                Throw New Exception("Տվյալները հասանելի են միայն ընթացիկ օրվա համար")
            End If

            f.dt = dt
            AddChildForm("nRepLocationListViewer", f)

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