Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class AddressWindow

    Private iDuration As String = "00:00"

#Region "Records"

    Friend Sub UpdateRecords()
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ID As Integer = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
        Dim strAddress As String = GridView1.GetFocusedDataRow.Item("Հասցե").ToString

        Dim f As New AddressUpdateWindow With {.iAddressID = ID, .iAddress = strAddress}
        With f
            .ShowDialog()
            .Dispose()
        End With
        'Call LoadData()
    End Sub
    Friend Sub AddRecord()
        Dim f As New AddressAddWindow
        With f
            .ShowDialog()
            .Dispose()
        End With
        Call LoadData()
    End Sub
    Friend Sub DeleteRecord()
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim recID As Integer = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString

        Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
        If q = MsgBoxResult.Yes Then
            iDB.DeleteAddress(recID)
            MsgBox("Գրանցումը հաջողությամբ ջնջվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Call LoadData()
        End If
    End Sub

#End Region

    Private Sub LoadData()
        Dim sTime As DateTime
        Dim eTime As DateTime

        Try
            Dim dt As DataTable

            sTime = Now
            dt = iDB.GetAddress
            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ՀՀ").Visible = False
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
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Հասցե").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Հասցե", "Քանակ {0}")
                    GridView1.Columns("Հասցե").Summary.Add(item)
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
    Private Sub AddressWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub AddressWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
    End Sub

    'Add new Record
    Private Sub mnuAddRegord_Click(sender As Object, e As EventArgs) Handles mnuAddRegord.Click
        Try
            If CheckPermission2("B8D325527E5D4622A52645B43E828DCF") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
            Call AddRecord()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    'Update Record
    Private Sub mnuChangeRecord_Click(sender As Object, e As EventArgs) Handles mnuChangeRecord.Click
        Try
            If CheckPermission2("B53CDA91E1D14CCFB18C776CA83DB4AE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
            Call UpdateRecords()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    'Delete Record
    Private Sub mnuDeleteRecord_Click(sender As Object, e As EventArgs) Handles mnuDeleteRecord.Click
        Try
            If CheckPermission2("49A3BF48B6034F32B667D67D3F598C53") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
            Call DeleteRecord()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
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