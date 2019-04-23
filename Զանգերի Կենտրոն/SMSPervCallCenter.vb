Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Data.Filtering

Public Class SMSPervCallCenter

    Friend ClientID As Integer
    Friend IsFiltered As Boolean = False

    Private Sub LoadData()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            dt = iDB.CallCenterSMSRep(ClientID)

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
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If IsFiltered = True Then
                Dim xDate As Date = DateAdd(DateInterval.Day, -30, Now)

                Dim BinaryFilter As CriteriaOperator
                Dim FilterString, FilterDisplayText As String
                Dim DateFilter As ColumnFilterInfo
                BinaryFilter = New GroupOperator(GroupOperatorType.And, New BinaryOperator("Ամսաթիվ", xDate.Date, BinaryOperatorType.GreaterOrEqual), New BinaryOperator("Ամսաթիվ", Now.Date, BinaryOperatorType.Less))
                FilterString = BinaryFilter.ToString()
                FilterDisplayText = String.Format("Ամսաթիվ Between {0:d} and {1:d}", xDate.Date, Now.Date)
                DateFilter = New ColumnFilterInfo(FilterString, FilterDisplayText)

                Dim view As GridView = TryCast(GridView1, GridView)
                view.ActiveFilter.Add(view.Columns("Ամսաթիվ"), DateFilter)
                'view.ActiveFilter.Add(view.Columns("Ամսաթիվ"), New ColumnFilterInfo("[Ամսաթիվ]>='" & xDate.Date & "' And [Ամսաթիվ]<'" & Now.Date & "'", ""))
            End If

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "{0}")
                    GridView1.Columns("Կազմակերպություն").Summary.Add(item)
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
        End Try
    End Sub
    Private Sub SMSPervCallCenter_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub

End Class