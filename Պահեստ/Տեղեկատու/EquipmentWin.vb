Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class EquipmentWin

    Private iDuration As String = "00:00"

#Region "Records"

    Friend Sub UpdateRecords()
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ID As Short = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
        Dim strVal As String = GridView1.GetFocusedDataRow.Item("Սարքավորում").ToString
        Dim canSel As Boolean = GridView1.GetFocusedDataRow.Item("Սարք/Նյութ").ToString
        Dim Code As String = String.Empty
        If Not IsDBNull(GridView1.GetFocusedDataRow.Item("Կոդ")) Then Code = GridView1.GetFocusedDataRow.Item("Կոդ")

        Dim f As New EquipmentUpWin With {.iRecord = strVal, .iID = ID, .canSel = canSel, .code = Code}
        With f
            .ShowDialog()
            .Dispose()
        End With
        Call LoadData()
    End Sub
    Friend Sub AddRecord()
        Dim f As New EquipmentAddWin
        With f
            .ShowDialog()
            .Dispose()
        End With
        Call LoadData()
    End Sub
    Friend Sub DeleteRecord()
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim recID As Short = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString

        Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
        If q = MsgBoxResult.Yes Then
            iDB.DeleteEquipment(recID)
            MsgBox("Գրանցումը հաջողությամբ ջնջվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Call LoadData()
        End If
    End Sub

#End Region

    Private Sub LoadData()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            Dim dt As DataTable

            sTime = Now
            'dt = iDB.GetEquipmentList
            dt = iDB.GetEquipmentList2
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
                If GridView1.Columns("Սարքավորում").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Սարքավորում", "Քանակ {0}")
                    GridView1.Columns("Սարքավորում").Summary.Add(item)
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
    Private Sub EquipmentWin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub EquipmentWin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
    End Sub

    'Add new Record
    Private Sub mnuAddRegord_Click(sender As Object, e As EventArgs) Handles mnuAddRegord.Click
        Try
            If CheckPermission2("FE9AC83E29464A6BAEE5A9EDC3F74618") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

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
            If CheckPermission2("A2C1C44668A447FD9C2F5147216B011C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

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
            If CheckPermission2("09041261D4144A90B2353A610A7D3C80") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

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