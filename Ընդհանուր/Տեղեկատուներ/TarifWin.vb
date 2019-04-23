Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class TarifWin

    Private iDuration As String = "00:00"

#Region "Records"

    Friend Sub UpdateRecords()
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ID As Short = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
        Dim strVal As String = GridView1.GetFocusedDataRow.Item("Տարիֆ").ToString

        Dim day28 As Decimal = GridView1.GetFocusedDataRow.Item("28Օր").ToString
        Dim day29 As Decimal = GridView1.GetFocusedDataRow.Item("29Օր").ToString
        Dim day30 As Decimal = GridView1.GetFocusedDataRow.Item("30Օր").ToString
        Dim day31 As Decimal = GridView1.GetFocusedDataRow.Item("31Օր").ToString

        Dim f As New TarifUpWin With {.tarif = strVal, .tarifID = ID, .day28 = day28, .day29 = day29, .day30 = day30, .day31 = day31}
        With f
            .ShowDialog()
            .Dispose()
        End With
        Call LoadData()
    End Sub
    Friend Sub AddRecord()
        Dim f As New TarifAddWin
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
            iDB.DeleteTarif(recID)
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
            dt = iDB.GetTarifList
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
    Private Sub TarifWin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub TarifWin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
    End Sub

    'Add new Record
    Private Sub mnuAddRegord_Click(sender As Object, e As EventArgs) Handles mnuAddRegord.Click
        Try
            If CheckPermission2("2F5A0D5661F24141BEE15CCF65EA1609") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
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
            If CheckPermission2("B5F45B13B1D7465E933A4C58C2D9E782") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
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
            If CheckPermission2("92553042666C4450ADD631180948842E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
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
    Private Sub mnuEquipTarif_Click(sender As Object, e As EventArgs) Handles mnuEquipTarif.Click
        If CheckPermission2("29A2756F38F0445DAA597C39304B9311") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

        Dim ID As Short = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
        Dim f As New SetEquipmentPrice
        f.TarifID = ID
        AddChildForm("nSetEquipmentPrice", f)

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