Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class RepWarehouseExisting

    Friend sDate As Date
    Friend eDate As Date
    Friend WarehouseID As Byte
    Friend EquipmentID As Short
    Friend IsEquipment As Boolean

    Private iDuration As String = "00:00"

    Private Sub LoadData()
        Try
            Dim dt As DataTable

            If WarehouseID = 0 AndAlso EquipmentID = 0 Then
                dt = iDB.RepMnacordWarAllEquipAll(sDate, eDate, IsEquipment)
            ElseIf WarehouseID = 0 AndAlso EquipmentID > 0 Then
                dt = iDB.RepMnacordWarAllEquipUniq(sDate, eDate, EquipmentID)
            ElseIf WarehouseID > 0 AndAlso EquipmentID = 0 Then
                dt = iDB.RepMnacordWarUniqueEquipAll(sDate, eDate, WarehouseID, IsEquipment)
            ElseIf WarehouseID > 0 AndAlso EquipmentID > 0 Then
                dt = iDB.RepMnacordWarUniqueEquipUnique(sDate, eDate, WarehouseID, EquipmentID)
            End If

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Սարքավորում").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Սարքավորում", "{0}")
                    GridView1.Columns("Սարքավորում").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub RepWarehouseExisting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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