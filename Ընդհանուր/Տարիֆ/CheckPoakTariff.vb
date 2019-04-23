Public Class CheckPoakTariff

    Private iDuration As String = "00:00"

    Private Sub LoadData()
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            sTime = Now
            dt = iDB.GetAllDiffTariff()
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

                .Columns("hvhh").Caption = "ՀՎՀՀ"
                .Columns("CompanyName").Caption = "Կազմակերպություն"
                .Columns("Company").Caption = "Սպասարկող"
                .Columns("TarifType").Caption = "Ընթացիկ Տարիֆ"
                .Columns("PoakTariff").Caption = "ՊՈԱԿ Տարիֆ"

                .Columns("hvhh").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("hvhh").Summary.ActiveCount = 0 Then
                    Dim item As DevExpress.XtraGrid.GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "hvhh", "{0}")
                    GridView1.Columns("hvhh").Summary.Add(item)
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

    Private Sub CheckPoakTariff_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub

End Class