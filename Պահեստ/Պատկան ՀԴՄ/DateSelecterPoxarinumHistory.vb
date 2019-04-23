Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class DateSelecterPoxarinumHistory

    Private Sub loadSupporter()
        Try
            Dim dt As DataTable

            If iUser.DB = 5 Then
                dt = iDB.QueryToSqlServer2("SELECT 0 ՀՀ,N'Բոլորը' Կազմակերպություն UNION SELECT ՀՀ,Կազմակերպություն FROM Supporter.GetSupporter() WHERE Կազմակերպություն<>N'Անորոշ'", CommandType.Text)
            Else
                dt = iDB.GetSupporter2(iUser.DB)
            End If
            With cbSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                If iUser.DB <> 5 Then .SelectedValue = iUser.DB : .Enabled = False
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub DateSelecterPoxarinumHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With sDate
            .DateTime = DateSerial(Now.Year, Now.Month, 1)
            .Properties.DisplayFormat.FormatString = "dd.MM.yy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With
        With eDate
            .DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
            .Properties.DisplayFormat.FormatString = "dd.MM.yy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With
        Call loadSupporter()
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

            If iUser.DB = 5 Then
                If cbSupporter.SelectedValue = 0 Then
                    dt = iDB.GetEcrReplaceHistoryALL(sDate.DateTime, eDate.DateTime)
                Else
                    dt = iDB.GetEcrReplaceHistoryBySupporter(sDate.DateTime, eDate.DateTime, cbSupporter.SelectedValue)
                End If
            Else
                dt = iDB.GetEcrReplaceHistoryBySupporter(sDate.DateTime, eDate.DateTime, cbSupporter.SelectedValue)
            End If

            Call CloseWindow("nEcrReplaceHistory")
            Dim f As New PoxarinumHistory
            AddChildForm("nEcrReplaceHistory", f)

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
                If f.GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "Գրանցումներ {0}")
                    f.GridView1.Columns("ՀԴՄ").Summary.Add(item)
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
    Private Sub btnQuery2_Click(sender As Object, e As EventArgs) Handles btnQuery2.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            If iUser.DB = 5 Then
                If cbSupporter.SelectedValue = 0 Then
                    dt = iDB.GetEcrReplaceHistoryALLBacvacq(sDate.DateTime, eDate.DateTime)
                Else
                    dt = iDB.GetEcrReplaceHistoryBySupporterBacvacq(sDate.DateTime, eDate.DateTime, cbSupporter.SelectedValue)
                End If
            Else
                dt = iDB.GetEcrReplaceHistoryBySupporterBacvacq(sDate.DateTime, eDate.DateTime, cbSupporter.SelectedValue)
            End If

            Call CloseWindow("nEcrReplaceHistory")
            Dim f As New PoxarinumHistory
            AddChildForm("nEcrReplaceHistory", f)

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
                If f.GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "Գրանցումներ {0}")
                    f.GridView1.Columns("ՀԴՄ").Summary.Add(item)
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