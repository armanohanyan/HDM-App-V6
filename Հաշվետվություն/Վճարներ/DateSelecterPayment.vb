Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class DateSelecterPayment

    Private Sub loadSupporter()
        Try
            Dim dt As DataTable

            If iUser.DB = 5 Then
                dt = iDB.QueryToSqlServer2("SELECT ՀՀ,Կազմակերպություն FROM Supporter.GetSupporter() UNION SELECT 0 ,N'Բոլորը'", CommandType.Text)
            Else
                dt = iDB.GetSupporter2(iUser.DB)
            End If
            With cbSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                If iUser.DB <> 5 Then cbSupporter.SelectedValue = iUser.DB : cbSupporter.Enabled = False
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub DateSelecterPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Call loadSupporter()
        cbPayType.SelectedIndex = 0
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
            Dim dbID As Byte = cbSupporter.SelectedValue
            Dim isAmpop As Boolean = chIsTotal.Checked

            Dim PayType As Byte = cbPayType.SelectedIndex

            Dim dt As DataTable

            Call CloseWindow("nRepPayWindow")
            Dim f As New RepPayWindow

            If ckAllTime.Checked = True Then
                If isAmpop = True Then
                    dt = iDB.RepGetAllPaymentsGrouped(dbID, PayType)
                    f.Text = "Վճարներ (Ամփոփ Ընդհանուր)"
                Else
                    dt = iDB.RepGetAllPayments(dbID, PayType)
                    f.Text = "Վճարներ (Ընդհանուր)"
                End If
            Else
                Dim sD As Date = sDate.DateTime
                Dim eD As Date = DateAdd(DateInterval.Day, 1, eDate.DateTime)

                If isAmpop = True Then
                    dt = iDB.RepGetAllPaymentsByIntervalGrouped(dbID, sD, eD, PayType)
                    f.Text = "Վճարներ (Ամփոփ Ժամանակահատվածով)"
                Else
                    dt = iDB.RepGetAllPaymentsByInterval(dbID, sD, eD, PayType)
                    f.Text = "Վճարներ (Ժամանակահատվածով)"
                End If
            End If

            AddChildForm("nRepPayWindow", f)

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
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Վճար", "Գումար {0:n2}")
                    f.GridView1.Columns("Վճար").Summary.Add(item)
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