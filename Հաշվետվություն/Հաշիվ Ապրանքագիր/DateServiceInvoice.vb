Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class DateServiceInvoice

    Private Sub loadSupporter()
        Try
            Dim dt As DataTable = iDB.GetSupporter()
            With cSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                .SelectedValue = iUser.DB
            End With
            If iUser.DB <> 5 Then cSupporter.Enabled = False
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub loadRegion()
        Try
            Dim dt As DataTable = iDB.GetRegion
            With cRegion
                .DataSource = dt
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
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

            Call CloseWindow("nServiceInvoice")
            Dim f As New RepNotRetInvoice
            f.Text = "Սպասարկման Հաշիվ Ապրանքագիր"

            Dim sID As Byte = cSupporter.SelectedValue
            Dim rID As Short = cRegion.SelectedValue

            If ckRegions.Checked = True Then
                dt = iDB.GetServiceInvoiceAll(sID, cYear.SelectedItem, cMonth.SelectedItem)
            Else
                dt = iDB.GetServiceInvoiceByRegion(sID, cYear.SelectedItem, cMonth.SelectedItem, cRegion.SelectedValue)
            End If

            AddChildForm("nServiceInvoice", f)

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
                .Columns("ՄիավորիԱրժեք").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("ՄիավորիԱրժեք").DisplayFormat.FormatString = "n2"
                .Columns("Գումար").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Գումար").DisplayFormat.FormatString = "n2"
                .Columns("ԱԱՀ").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("ԱԱՀ").DisplayFormat.FormatString = "n2"
                .Columns("ԱմբողջԳումար").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("ԱմբողջԳումար").DisplayFormat.FormatString = "n2"
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "{0}")
                    f.GridView1.Columns("Կազմակերպություն").Summary.Add(item)
                End If
                If f.GridView1.Columns("Գումար").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Գումար", "{0:n2}")
                    f.GridView1.Columns("Գումար").Summary.Add(item)
                End If
                If f.GridView1.Columns("ԱԱՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ԱԱՀ", "{0:n2}")
                    f.GridView1.Columns("ԱԱՀ").Summary.Add(item)
                End If
                If f.GridView1.Columns("ԱմբողջԳումար").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ԱմբողջԳումար", "{0:n2}")
                    f.GridView1.Columns("ԱմբողջԳումար").Summary.Add(item)
                End If

                If f.GridView1.Columns("ԱշխատածՕրեր").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ԱշխատածՕրեր", "{0}")
                    f.GridView1.Columns("ԱշխատածՕրեր").Summary.Add(item)
                End If
                If f.GridView1.Columns("ՀդմՔանակ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ՀդմՔանակ", "{0}")
                    f.GridView1.Columns("ՀդմՔանակ").Summary.Add(item)
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
    Private Sub DateServiceInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Call loadSupporter()
        Call loadRegion()
    End Sub
    Private Sub ckRegions_CheckedChanged(sender As Object, e As EventArgs) Handles ckRegions.CheckedChanged
        If ckRegions.Checked = True Then
            cRegion.Enabled = False
        Else
            cRegion.Enabled = True
        End If
    End Sub

End Class