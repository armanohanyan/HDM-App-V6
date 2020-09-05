Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class DatePartqHavelavchar

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQueryReRegister_Click(sender As Object, e As EventArgs) Handles btnQueryReRegister.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            sTime = Now
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            Call CloseWindow("nPartqHavelavcharWindow")
            Dim f As New PartqHavelavcharWindow

            dt = iDB.PartqVeragrancumov()

            f.Text = "Պարտք Վերագրանցումով"
            AddChildForm("nPartqHavelavcharWindow", f)

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
                .Columns("Պարտք").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Պարտք").DisplayFormat.FormatString = "n2"
                .BestFitColumns(True)
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("ՎաճառողիՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՎաճառողիՀՎՀՀ", "{0}")
                    f.GridView1.Columns("ՎաճառողիՀՎՀՀ").Summary.Add(item)
                End If
                If f.GridView1.Columns("Պարտք").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Պարտք", "{0:n2}")
                    f.GridView1.Columns("Պարտք").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Me.Close()
            eTime = Now

            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub btnPartq_Click(sender As Object, e As EventArgs) Handles btnPartq.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            sTime = Now
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            Call CloseWindow("nPartqHavelavcharWindow")
            Dim f As New PartqHavelavcharWindow

            dt = iDB.GetPartqList(iUser.DB)

            f.Text = "Պարտքով Հաճախորդներ"
            AddChildForm("nPartqHavelavcharWindow", f)

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
                .Columns("Պարտք").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Պարտք").DisplayFormat.FormatString = "n2"
                .BestFitColumns(True)
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "Գրանցումներ {0}")
                    f.GridView1.Columns("Կազմակերպություն").Summary.Add(item)
                End If
                If f.GridView1.Columns("Պարտք").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Պարտք", "Պարտք {0:n2}")
                    f.GridView1.Columns("Պարտք").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Me.Close()
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub btnPartqFiz_Click(sender As Object, e As EventArgs) Handles btnPartqFiz.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            sTime = Now
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            Call CloseWindow("nPartqHavelavcharWindow")
            Dim f As New PartqHavelavcharWindow

            dt = iDB.GetPartqListFiz()

            f.Text = "Պարտքով Հաճախորդներ"
            AddChildForm("nPartqHavelavcharWindow", f)

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
                .Columns("Պարտք").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Պարտք").DisplayFormat.FormatString = "n2"
                .Columns("Վճար").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Վճար").DisplayFormat.FormatString = "n2"
                .BestFitColumns(True)
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("ՖիզԱնձ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՖիզԱնձ", "Գրանցումներ {0}")
                    f.GridView1.Columns("ՖիզԱնձ").Summary.Add(item)
                End If
                If f.GridView1.Columns("Պարտք").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Պարտք", "Պարտք {0:n2}")
                    f.GridView1.Columns("Պարտք").Summary.Add(item)
                End If
                If f.GridView1.Columns("Վճար").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Վճար", "Վճար {0:n2}")
                    f.GridView1.Columns("Վճար").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Me.Close()
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub btnZroyakan_Click(sender As Object, e As EventArgs) Handles btnZroyakan.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            sTime = Now
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            Call CloseWindow("nPartqHavelavcharWindow")
            Dim f As New PartqHavelavcharWindow

            dt = iDB.GetZroList(iUser.DB)

            f.Text = "Զրոյականով Հաճախորդներ"
            AddChildForm("nPartqHavelavcharWindow", f)

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
                .Columns("Պարտք").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Պարտք").DisplayFormat.FormatString = "n2"
                .BestFitColumns(True)
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "Գրանցումներ {0}")
                    f.GridView1.Columns("Կազմակերպություն").Summary.Add(item)
                End If
                If f.GridView1.Columns("Պարտք").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Պարտք", "Պարտք {0:n2}")
                    f.GridView1.Columns("Պարտք").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Me.Close()
            eTime = Now

            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub btnHavelavchar_Click(sender As Object, e As EventArgs) Handles btnHavelavchar.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            sTime = Now
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            Call CloseWindow("nPartqHavelavcharWindow")
            Dim f As New PartqHavelavcharWindow

            dt = iDB.GetMetsZroList(iUser.DB)

            f.Text = "Հավելավճարով Հաճախորդներ"
            AddChildForm("nPartqHavelavcharWindow", f)

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
                .Columns("Վճար").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Վճար").DisplayFormat.FormatString = "n2"
                .BestFitColumns(True)
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "Գրանցումներ {0}")
                    f.GridView1.Columns("Կազմակերպություն").Summary.Add(item)
                End If
                If f.GridView1.Columns("Վճար").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Վճար", "Վճար {0:n2}")
                    f.GridView1.Columns("Վճար").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Me.Close()
            eTime = Now

            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            sTime = Now
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            Call CloseWindow("nPartqHavelavcharWindow")
            Dim f As New PartqHavelavcharWindow

            dt = iDB.GetPartHavelavcharAll(iUser.DB)

            f.Text = "Բոլոր Հաճախորդները"
            AddChildForm("nPartqHavelavcharWindow", f)

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
                .Columns("Վճար").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Վճար").DisplayFormat.FormatString = "n2"
                .BestFitColumns(True)
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "Գրանցումներ {0}")
                    f.GridView1.Columns("Կազմակերպություն").Summary.Add(item)
                End If
                If f.GridView1.Columns("Վճար").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Վճար", "Վճար {0:n2}")
                    f.GridView1.Columns("Վճար").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Me.Close()
            eTime = Now

            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub

End Class