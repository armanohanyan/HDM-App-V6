Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class RepLocationListViewer

    Friend dt As DataTable

    Private Sub LoadData()
        Try
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

                .Columns("ՄուտքՄասնաճյուղ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՄուտքՄասնաճյուղ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՄուտքՄասնաճյուղիԱրհեստանոց").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՄուտքՄասնաճյուղիԱրհեստանոց").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ԵլքՄասնաճյուղիԱրհեստանոցից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԵլքՄասնաճյուղիԱրհեստանոցից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՄուտքԿենտրոն").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՄուտքԿենտրոն").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ՄուտքԿենտրոնիԱրհեստանոց").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՄուտքԿենտրոնիԱրհեստանոց").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ԵլքԿենտրոնիԱրհեստանոցից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԵլքԿենտրոնիԱրհեստանոցից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ԵլքԿենտրոնից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԵլքԿենտրոնից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                .Columns("ԵլքՄասնաճյուղից").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԵլքՄասնաճյուղից").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

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
        End Try
    End Sub
    Private Sub RepLocationListViewer_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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