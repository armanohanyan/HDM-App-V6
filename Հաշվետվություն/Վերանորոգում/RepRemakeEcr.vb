Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class RepRemakeEcr

    Private iDuration As String = "00:00"

    Friend supporterID As Byte
    Friend sDate As Date
    Friend eDate As Date

    Private Sub RepRemakeEcr_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
    Private Sub RepRemakeEcr_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            sTime = Now

            If supporterID = 0 Then
                dt = iDB.GetRemakeAll(sDate, eDate)
            Else
                dt = iDB.GetRemakeAllBySupporter(supporterID, sDate, eDate)
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

                .Columns("ԸնդունմանԱմսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .Columns("ԸնդունմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԸնդունմանԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"


                .Columns("ՀաստատմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՀաստատմանԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՓակմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՓակմանԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՓոխարինմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՓոխարինմանԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՎերադարձիԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՎերադարձիԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՄուտքՄասնաճյուղ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՄուտքՄասնաճյուղ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՄուտքՄասնաճյուղիԱրհեստանոց").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՄուտքՄասնաճյուղիԱրհեստանոց").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ԵլքՄասնաճյուղիԱրհեստանոցից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԵլքՄասնաճյուղիԱրհեստանոցից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ԵլքՄասնաճյուղից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԵլքՄասնաճյուղից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՄուտքԿենտրոն").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՄուտքԿենտրոն").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՄուտքԿենտրոնիԱրհեստանոց").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՄուտքԿենտրոնիԱրհեստանոց").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ԵլքԿենտրոնիԱրհեստանոցից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԵլքԿենտրոնիԱրհեստանոցից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ԵլքԿենտրոնից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԵլքԿենտրոնից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՀԴՄ").BestFit()
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

End Class