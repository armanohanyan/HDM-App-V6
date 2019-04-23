Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid

Public Class SetEquipmentPrice

    Friend TarifID As Short

    Friend Sub UpdateRecords()
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

        Dim b As Boolean = GridView1.GetFocusedDataRow.Item("Սարք").ToString
        If b = False Then Exit Sub

        Dim ID As Integer = GridView1.GetFocusedDataRow.Item("id").ToString

        Dim Equipment As String = GridView1.GetFocusedDataRow.Item("Սարքավորում").ToString
        Dim Price As Decimal = GridView1.GetFocusedDataRow.Item("Գումար").ToString

        Dim f As New ChangeSetEquipmentPrice With {.ID = ID, .Equipment = Equipment, .Price = Price}
        With f
            .ShowDialog()
            .Dispose()
        End With

        Call Query()
    End Sub
    Friend Sub AddRecord()
        Dim f As New AddSetEquipmentPrice
        With f
            .TarifID = TarifID
            .ShowDialog()
            .Dispose()
        End With
        Call Query()
    End Sub
    Friend Sub DeleteRecord()
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ID As Integer = GridView1.GetFocusedDataRow.Item("id").ToString

        Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
        If q = MsgBoxResult.Yes Then
            iDB.DeleteTarifSel(ID)
            MsgBox("Գրանցումը հաջողությամբ ջնջվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Call Query()
        End If
    End Sub

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
    Private Sub Query()
        Try
            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            Dim dt As DataTable = iDB.GetTarifSelList(TarifID)
            GridControl1.DataSource = dt

            With GridView1
                .Columns("id").Visible = False
                .Columns("Սարք").Visible = False
                .Columns("Գումար").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Գումար").DisplayFormat.FormatString = "n2"
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                '.AddNewRow()
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub SetEquipmentPrice_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Query()
    End Sub
    Private Sub mnuAdd_Click(sender As Object, e As EventArgs) Handles mnuAdd.Click
        If CheckPermission2("C62496D9278C463C99E4BB078BB26D60") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        Call AddRecord()
    End Sub
    Private Sub mnuEdit_Click(sender As Object, e As EventArgs) Handles mnuEdit.Click
        If CheckPermission2("CD59C82B41AC4F5FAC4944898BE2D21F") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Call UpdateRecords()
    End Sub
    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        If CheckPermission2("02307F65F21C42B589E23723F8B15608") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        Call DeleteRecord()
    End Sub
    Private Sub mnuAddNyut_Click(sender As Object, e As EventArgs) Handles mnuAddNyut.Click
        If CheckPermission2("C62496D9278C463C99E4BB078BB26D60") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Dim f As New AddNyutPrice
        f.TarifID = TarifID
        f.ShowDialog()
        f.Dispose()
        Call Query()
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