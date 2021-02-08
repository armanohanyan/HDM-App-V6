Imports DevExpress.XtraGrid

Public Class GPRS_History

    Friend ClientID As Integer = 0
    Friend Ecr As String = String.Empty

    Dim iDuration As String = "00:00"

    Private Sub LoadData()
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable

            sTime = Now

            If ClientID <> 0 Then
                dt = iDB.GprsHistoryByClientID(ClientID)
            Else
                dt = iDB.GprsHistoryByEcr(Ecr)
            End If

            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            With GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .Columns("ԱրգելափակմանԱմսաթիվ").DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss"
                .Columns("ԱկտիվացմանԱմսաթիվ").DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss"

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False

            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "{0}")
                    GridView1.Columns("ՀԴՄ").Summary.Add(item)
                End If
            End If

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

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
    Private Sub GPRS_History_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub

End Class