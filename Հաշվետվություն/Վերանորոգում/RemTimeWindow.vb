Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Public Class RemTimeWindow

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
                    dt = iDB.RepTimeBrWorkToCenter(sDate, eDate)
                Case 2
                    dt = iDB.RepTimeCenterToBranch(sDate, eDate)
                Case 3
                    dt = iDB.RepTimeWorkShopToCenter(sDate, eDate)
                Case 4
                    dt = iDB.RepTimeCenterToWorkshop(sDate, eDate)
                Case 5
                    dt = iDB.RepTimeApproved(sDate, eDate)
                Case 6
                    dt = iDB.RepTimeRemakeDuration(sDate, eDate)
                Case 7
                    dt = iDB.RepTimeRemakeWorkShopDuration(sDate, eDate)
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

                If Direction = 1 Then
                    .Columns("ԵլքՄասնաճյուղիԱրհեստանոցից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ԵլքՄասնաճյուղիԱրհեստանոցից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                    .Columns("ՄուտքԿենտրոնիՍրահ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ՄուտքԿենտրոնիՍրահ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                ElseIf Direction = 2 Then
                    .Columns("ԵլքԿենտրոնիՍրահ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ԵլքԿենտրոնիՍրահ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                    .Columns("ՄուտքՄասնաճյուղիՍրահ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ՄուտքՄասնաճյուղիՍրահ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                ElseIf Direction = 3 Then
                    .Columns("ԵլքԱրհեստանոցից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ԵլքԱրհեստանոցից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                    .Columns("ՄուտքՍրահ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ՄուտքՍրահ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                ElseIf Direction = 4 Then
                    .Columns("ԵլքՍրահ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ԵլքՍրահ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                    .Columns("ՄուտքԱրհեստանոց").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ՄուտքԱրհեստանոց").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                ElseIf Direction = 5 Then
                    .Columns("ՀաստատմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ՀաստատմանԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                ElseIf Direction = 6 Then
                    .Columns("ՀայտիԲացում").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ՀայտիԲացում").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                    .Columns("ՀայտիՀաստատում").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ՀայտիՀաստատում").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                ElseIf Direction = 7 Then
                    .Columns("ՄուտքԱրհեստանոց").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ՄուտքԱրհեստանոց").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                    .Columns("ԵլքԱրհեստանոցից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ԵլքԱրհեստանոցից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                End If

                .BestFitColumns(True)
            End With

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "{0}")
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
    Private Sub RemakeDayCounterWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
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