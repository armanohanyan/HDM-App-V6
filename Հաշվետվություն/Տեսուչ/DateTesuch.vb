Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class DateTesuch

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now

            Dim dt As DataTable

            Call CloseWindow("nRepTesuch")
            Dim f As New RepTesuch

            Dim iYear As Short = cYear.SelectedItem
            Dim iMonth As Byte = cMonth.SelectedItem
            Dim iRegion As Byte = cRegion.SelectedIndex

            If iRegion = 0 Then
                dt = iDB.TesuchVisitsInYerevan(iYear, iMonth)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    Dim dTotal1 As Object = dt.Compute("SUM([Ընդհանուր ՀԴՄ Քանակ])", "")
                    Dim dTotal2 As Object = dt.Compute("SUM([ՀԴՄ Առանց Կրկնության])", "")
                    Dim dTotal3 As Object = dt.Compute("SUM([Սպասարկած ՀԴՄ])", "")
                    Dim R As DataRow = dt.NewRow
                    R("Տեսուչ") = DBNull.Value
                    R("Ընդհանուր ՀԴՄ Քանակ") = dTotal1
                    R("Սպասարկած ՀԴՄ") = dTotal3
                    R("ՀԴՄ Առանց Կրկնության") = dTotal2

                    If Not IsDBNull(dTotal1) Then
                        If dTotal1 > 0 Then
                            R("Արդյունքը %-ով") = CStr(Math.Round(100 * dTotal2 / dTotal1, 2) & " %")
                        Else
                            R("Արդյունքը %-ով") = DBNull.Value
                        End If
                    Else
                        R("Արդյունքը %-ով") = DBNull.Value
                    End If

                    dt.Rows.Add(R)
                End If
            Else
                dt = iDB.TesuchVisitsInRegions(iYear, iMonth)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    Dim dTotal1 As Object = dt.Compute("SUM([Ընդհանուր ՀԴՄ Քանակ])", "")
                    Dim dTotal2 As Object = dt.Compute("SUM([ՀԴՄ Առանց Կրկնության])", "")
                    Dim dTotal3 As Object = dt.Compute("SUM([Սպասարկած ՀԴՄ])", "")
                    Dim R As DataRow = dt.NewRow
                    R("Տեսուչ") = DBNull.Value
                    R("Ընդհանուր ՀԴՄ Քանակ") = dTotal1
                    R("Սպասարկած ՀԴՄ") = dTotal3
                    R("ՀԴՄ Առանց Կրկնության") = dTotal2

                    If Not IsDBNull(dTotal1) Then
                        If dTotal1 > 0 Then
                            R("Արդյունքը %-ով") = CStr(Math.Round(100 * dTotal2 / dTotal1, 2) & " %")
                        Else
                            R("Արդյունքը %-ով") = DBNull.Value
                        End If
                    Else
                        R("Արդյունքը %-ով") = DBNull.Value
                    End If

                    dt.Rows.Add(R)
                End If
            End If

            AddChildForm("nRepTesuch", f)

            f.GridControl1.BeginUpdate()
            f.GridView1.Columns.Clear()

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = Nothing
            f.GridView1.Columns.Clear()

            f.GridControl1.DataSource = dt

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

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

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
            Me.Close()
        End Try
    End Sub
    Private Sub DateTesuch_Load(sender As Object, e As EventArgs) Handles Me.Load
        cYear.Items.Clear()
        For i As Integer = 2013 To 2030
            cYear.Items.Add(i)
        Next
        cYear.SelectedItem = Now.Year

        cMonth.Items.Clear()
        For i As Integer = 1 To 12
            cMonth.Items.Add(i)
        Next
        cMonth.SelectedItem = Now.Month

        cRegion.SelectedIndex = 0
    End Sub
    Private Sub btnDoubleVisit_Click(sender As Object, e As EventArgs) Handles btnDoubleVisit.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            Call CloseWindow("nRepTesuch")
            Dim f As New RepTesuch

            Dim iYear As Short = cYear.SelectedItem
            Dim iMonth As Byte = cMonth.SelectedItem

            dt = iDB.DoubleVisit(iYear, iMonth)

            AddChildForm("nRepTesuch", f)

            f.GridControl1.BeginUpdate()
            f.GridView1.Columns.Clear()

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = Nothing
            f.GridView1.Columns.Clear()

            f.GridControl1.DataSource = dt

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

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

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Տեսուչ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Տեսուչ", "{0}")
                    f.GridView1.Columns("Տեսուչ").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
            Me.Close()
        End Try
    End Sub
    Private Sub btnAllDB_Click(sender As Object, e As EventArgs) Handles btnAllDB.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            Call CloseWindow("nRepTesuch")
            Dim f As New RepTesuch

            dt = iDB.GetAllTesuchVisits()

            AddChildForm("nRepTesuch", f)

            f.GridControl1.BeginUpdate()
            f.GridView1.Columns.Clear()

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = Nothing
            f.GridView1.Columns.Clear()

            f.GridControl1.DataSource = dt

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

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

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Տեսուչ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Տեսուչ", "{0}")
                    f.GridView1.Columns("Տեսուչ").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
            Me.Close()
        End Try
    End Sub
    Private Sub btnNotServed_Click(sender As Object, e As EventArgs) Handles btnNotServed.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            Call CloseWindow("nRepTesuch")
            Dim f As New RepTesuch

            Dim iYear As Short = cYear.SelectedItem
            Dim iMonth As Byte = cMonth.SelectedItem

            dt = iDB.NotServedEcrList(iYear, iMonth)

            AddChildForm("nRepTesuch", f)

            f.GridControl1.BeginUpdate()
            f.GridView1.Columns.Clear()

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = Nothing
            f.GridView1.Columns.Clear()

            f.GridControl1.DataSource = dt

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

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

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Տեսուչ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Տեսուչ", "{0}")
                    f.GridView1.Columns("Տեսուչ").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
            Me.Close()
        End Try
    End Sub

End Class