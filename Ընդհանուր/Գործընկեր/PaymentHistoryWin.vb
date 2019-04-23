Imports DevExpress.XtraGrid
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid

Public Class PaymentHistoryWin

    Private iDuration As String = "00:00"
    Friend IClientID As Integer = 0

    Dim sum1 As Decimal = 0
    Dim sum2 As Decimal = 0

    Private Sub LoadData1()
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable

            sTime = Now
            dt = iDB.GetPaymentByClient(IClientID)
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
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("Ամսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Descending

                .OptionsView.GroupFooterShowMode = Views.Grid.GroupFooterShowMode.VisibleAlways

            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՊարտքիՏեսակ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՊարտքիՏեսակ", "Քանակ {0}")
                    GridView1.Columns("ՊարտքիՏեսակ").Summary.Add(item)
                End If

                If GridView1.Columns("Վճար").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Վճար", "Վճար {0:n2}")
                    GridView1.Columns("Վճար").Summary.Add(item)
                End If

                If GridView1.Columns("Պարտք").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Պարտք", "Ինվոյս {0:n2}")
                    GridView1.Columns("Պարտք").Summary.Add(item)
                End If

                If GridView1.Columns("Ամսաթիվ").Summary.ActiveCount = 0 Then
                    GridView1.Columns("Ամսաթիվ").Summary.Add(New GridColumnSummaryItem(SummaryItemType.Custom, "Ամսաթիվ", "Ամփոփ {0:n2}"))
                End If

                Dim iSum = GridView1.Columns("Ամսաթիվ").SummaryItem.SummaryValue
                If iSum < 0 Then
                    GridView1.Appearance.FooterPanel.Font = New Font(Me.Font.Name, Me.Font.Size, FontStyle.Bold)
                    GridView1.Appearance.FooterPanel.ForeColor = Color.Red
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
        End Try
    End Sub
    Private Sub LoadData2()
        Try
            'Dim dt As DataTable = iDB.GetPaymentByClientSubTotal(IClientID)
            Dim dt As DataTable = iDB.PartqBySupporter2(IClientID)

            GridControl2.BeginUpdate()
            GridControl2.DataSource = Nothing
            GridView2.Columns.Clear()

            GridControl2.DataSource = dt

            GridView2.ClearSelection()
            GridControl2.EndUpdate()

            With GridView2
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("ԸնթացիկՍպասարկող").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            End With

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub PaymentHistoryWin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub PaymentHistoryWin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Call LoadData1()
        Call LoadData2()
    End Sub
    Private Sub GridView1_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        If (e.SummaryProcess = CustomSummaryProcess.Finalize AndAlso e.Item.FieldName = "Ամսաթիվ") Then

            sum1 = GridView1.Columns("Վճար").SummaryItem.SummaryValue
            sum2 = GridView1.Columns("Պարտք").SummaryItem.SummaryValue

            e.TotalValue = sum1 + sum2
        End If
    End Sub

End Class