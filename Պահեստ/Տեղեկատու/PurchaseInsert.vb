Imports System.Linq
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class PurchaseInsert

    Friend sDate As Date
    Friend sWareHouse As String

    Friend iWareHouseID As Short

    Dim eItem As New List(Of EquipmentItems)
    Dim dt As DataTable

    Private Sub GetEquipmentCode()
        Try
            dt = iDB.GetEquipmentCode
            If dt.Rows.Count = 0 Then
                MsgBox("Շտրիխ կոդերը չեն բեռնվել", MsgBoxStyle.Critical, My.Application.Info.Title)
                btnAdd.Enabled = False
                txtCode.Enabled = False
                Exit Sub
            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub PurchaseInsert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized
        txtDate.Text = sDate
        txtWarehouse.Text = sWareHouse
        Call GetEquipmentCode()
    End Sub
    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        Try
            If txtCode.Text.Trim.Length <> 7 Then Exit Sub

            Dim c As Char
            c = Microsoft.VisualBasic.Mid(txtCode.Text.Trim, 1, 1)
            If Asc(c) < 65 OrElse Asc(c) > 90 Then Exit Sub

            c = Microsoft.VisualBasic.Mid(txtCode.Text.Trim, 2, 1)
            If Asc(c) < 65 OrElse Asc(c) > 90 Then Exit Sub

            For i = 3 To 7
                c = Microsoft.VisualBasic.Mid(txtCode.Text.Trim, i, 1)
                If Not IsNumeric(c) Then Exit Sub
            Next

            Dim s As String = Microsoft.VisualBasic.Mid(txtCode.Text.Trim, 1, 2)
            Dim equipID As Short = -1
            Dim equip As String = String.Empty

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("EquipmentCode") = s Then
                    equipID = dt.Rows(i)("EquipmentID")
                    equip = dt.Rows(i)("EquipmentName")
                    Exit For
                End If
            Next

            If txtPrice.Text < 0 Then Throw New Exception("Արժեքը զրոյից փոքր չի կարող լինել")

            For i As Integer = 0 To GridView1.RowCount - 1
                If txtCode.Text.Trim = GridView1.GetRowCellValue(i, "Շտրիխ") Then
                    Throw New Exception("Շտրիխ կոդի չի կարող կրկնվել")
                End If
            Next

            If equipID = -1 Then Throw New Exception("Սարքավորումը չի իդենտիֆիկացվել շտրիխ կոդի հետ")

            eItem.Add(New EquipmentItems(equip, equipID, txtCode.Text.Trim, 1, txtPrice.Text, sDate, txtComment.Text.Trim))

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()

            Dim dtx As DataTable = ToDataTable(eItem)
            GridControl1.DataSource = dtx

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ՍարքավորումՀՀ").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
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

            txtComment.Text = String.Empty
            txtCode.Text = String.Empty

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If GridView1.RowCount = 0 Then Throw New Exception("Ավելացնելու ոչինչ չկա")

            Dim isMarket As Boolean
            If iWareHouseID = 5 Then isMarket = True Else isMarket = False

            For i As Integer = 0 To GridView1.RowCount - 1
                iDB.InsertPurchaseWarehouse(GridView1.GetRowCellValue(i, "ՍարքավորումՀՀ"),
                                            1,
                                            GridView1.GetRowCellValue(i, "Արժեք"),
                                             GridView1.GetRowCellValue(i, "Ամսաթիվ"),
                                             GridView1.GetRowCellValue(i, "Մեկնաբանություն"),
                                             iWareHouseID,
                                             isMarket,
                                             GridView1.GetRowCellValue(i, "Շտրիխ"))
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ՋնջելToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ՋնջելToolStripMenuItem.Click
        Try
            If GridView1.RowCount = 0 Then Exit Sub

            If Not MsgBox("Ցանկանու՞մ եք ջնջել", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then Exit Sub

            Dim s As String = GridView1.GetFocusedDataRow.Item("Շտրիխ").ToString

            For i As Integer = 0 To eItem.Count - 1
                If eItem.Item(i).Շտրիխ = s Then
                    eItem.RemoveAt(i)
                    Exit For
                End If
            Next

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()

            Dim dtx As DataTable = ToDataTable(eItem)
            GridControl1.DataSource = dtx

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ՍարքավորումՀՀ").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
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