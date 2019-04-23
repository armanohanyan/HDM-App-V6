Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class hdmAraqumReadyWindow

    Private iDuration As String = "00:00"

    Private Sub LoadData()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            Dim dt As DataTable

            sTime = Now

            If iUser.DB = 5 Then
                dt = iDB.GetReadyRemontEcrShipping
            Else
                dt = iDB.GetReadyRemontEcrShipping2(iUser.DB)
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
                .Columns("ՎերանորոգմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՎերանորոգմանԱմսաթիվ").DisplayFormat.FormatString = "HH:mm:ss dd.MM.yyyy"
                .Columns("ՊատրաստմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՊատրաստմանԱմսաթիվ").DisplayFormat.FormatString = "HH:mm:ss dd.MM.yyyy"
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
    Private Sub hdmAraqumReadyWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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

    'Close Hayt
    Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
        Try
            If CheckPermission2("10CCEA8E6A2E423B9C83837B3303AB47") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
            Dim recID As Integer = GridView1.GetFocusedDataRow.Item("ShippingID").ToString

            iDB.CloseEcrShipping(recID)
            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Call LoadData()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub hdmAraqumReadyWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
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