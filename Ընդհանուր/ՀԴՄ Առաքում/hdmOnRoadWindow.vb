Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class hdmOnRoadWindow

    Private iDuration As String = "00:00"

    Friend Sub DeleteRecord()
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim recID As Integer = GridView1.GetFocusedDataRow.Item("ShippingID").ToString

        Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
        If q = MsgBoxResult.Yes Then
            iDB.DeleteInRoadEcrShipping(recID)
            MsgBox("Գրանցումը հաջողությամբ ջնջվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Call LoadData()
        End If
    End Sub
    Private Sub LoadData()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            sTime = Now

            If iUser.DB = 5 Then
                dt = iDB.GetInRoadEcrShipping
            Else
                dt = iDB.GetInRoadEcrShipping2(iUser.DB)
            End If

            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ShippingID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("ԺամանմանԺամ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԺամանմանԺամ").DisplayFormat.FormatString = "HH:mm:ss dd.MM.yyyy"
                .Columns("ԳրանցմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԳրանցմանԱմսաթիվ").DisplayFormat.FormatString = "HH:mm:ss dd.MM.yyyy"
                .BestFitColumns(True)
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "Քանակ {0}")
                    GridView1.Columns("ՀԴՄ").Summary.Add(item)
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
    Private Sub hdmOnRoadWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub

    'Export Records
    Private Sub mnuExportToExcel_Click(sender As Object, e As EventArgs) Handles mnuExportToExcel.Click
        Try
            ExportTo(ExportType.Excel2013, Me)
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    'Delete
    Private Sub mnuDeleteRec_Click(sender As Object, e As EventArgs) Handles mnuDeleteRec.Click
        Try
            If CheckPermission2("7B4C723DAAFE4323ACF5E4255E5AFF22") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
            Call DeleteRecord()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub hdmOnRoadWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
    End Sub
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

End Class