Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns

Public Class EcrRepChanges

    Private Sub EcrRepChanges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With sDate
            .DateTime = DateSerial(Now.Year, Now.Month, 1)
            .Properties.DisplayFormat.FormatString = "dd.MM.yy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
        With eDate
            .DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
            .Properties.DisplayFormat.FormatString = "dd.MM.yy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Try

            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            dt = iDB.RepReplEcrFull(sDate.DateTime, eDate.DateTime)

            Call CloseWindow("nEcrRepChangesReport")
            Dim f As New EcrRepChangesReport
            AddChildForm("nEcrRepChangesReport", f)

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = Nothing
            f.GridView1.Columns.Clear()

            f.GridControl1.DataSource = dt

            With f.GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .BestFitColumns(True)
            End With

            If f.GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "{0}")
                f.GridView1.Columns("ՀԴՄ").Summary.Add(item)
            End If

            f.GridView1.ClearColumnsFilter()
            f.GridView1.Columns("ՏարբերությունՕր").FilterInfo = New ColumnFilterInfo("[ՏարբերությունՕր] <> 0")

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
        End Try
    End Sub

End Class