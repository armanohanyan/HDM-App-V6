Imports DevExpress.XtraGrid

Public Class PoakToOffice

    Friend Sub Load1()
        Try
            Dim dt As DataTable = iDB.GetEcrPoakToOffice()

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            With GridView1
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsSelection.EnableAppearanceFocusedRow = False

                .Columns("ID").Visible = False
                .Columns("TesuchID").Visible = False

                .Columns("Ecr").Caption = "ՀԴՄ"
                .Columns("tesuchName").Caption = "Տեսուչ"
                .Columns("BringDate").Caption = "Ձեռք Բերման Ամսաթիվ"
                .Columns("SendDate").Caption = "Տեսուչին Տրման Ամսաթիվ"
                .Columns("ReceiveDate").Caption = "Ակտի Վերադարձման Ամսաթիվ"

                For i As Integer = 0 To GridView1.Columns.Count - 1
                    .Columns(i).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                Next

            End With

            If GridView1.Columns("Ecr").Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Ecr", "{0}")
                GridView1.Columns("Ecr").Summary.Add(item)
            End If

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Friend Sub Load2()
        Try
            Dim dt As DataTable = iDB.GetEcrPoakToOfficeTotals()

            GridControl2.BeginUpdate()
            GridControl2.DataSource = Nothing
            GridView2.Columns.Clear()

            GridControl2.DataSource = dt

            With GridView2
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsSelection.EnableAppearanceFocusedRow = False

                .Columns("tesuchName").Caption = "Տեսուչ"
                .Columns("Total").Caption = "Ընդամենը"
                .Columns("InOffice").Caption = "Գրասենյակում"
                .Columns("InTesuch").Caption = "Տեսուչի Մոտ"
                .Columns("Returned").Caption = "Վերադարձված"

                For i As Integer = 0 To GridView2.Columns.Count - 1
                    .Columns(i).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                Next

            End With

            If GridView2.Columns("tesuchName").Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "tesuchName", "{0}")
                GridView2.Columns("tesuchName").Summary.Add(item)
            End If

            GridView2.ClearSelection()
            GridControl2.EndUpdate()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub PoakToOffice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call Load1()
        Call Load2()
    End Sub

    Sub NewItem()
        Dim f As New AddEcr With {.RefForm = DirectCast(Me, PoakToOffice)}
        f.ShowDialog()
        f.Dispose()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call NewItem()
    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As DevExpress.XtraGrid.GridControl = sender
            Dim view As New DevExpress.XtraGrid.Views.Grid.GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub
    Private Sub GridControl2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl2.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As DevExpress.XtraGrid.GridControl = sender
            Dim view As New DevExpress.XtraGrid.Views.Grid.GridView()
            view = GridControl2.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Try
            If GridView1.SelectedRowsCount = 0 Then Throw New Exception("Նշված տողեր չկան")

            For i As Integer = 0 To GridView1.SelectedRowsCount - 1
                If IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("SendDate")) AndAlso IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ReceiveDate")) Then
                    iDB.DeletePoakOfficeEcr(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ID"))
                End If
            Next

            Call Load1()
            Call Load2()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub mnuReturn_Click(sender As Object, e As EventArgs) Handles mnuReturn.Click
        Try
            If GridView1.SelectedRowsCount = 0 Then Throw New Exception("Նշված տողեր չկան")

            For i As Integer = 0 To GridView1.SelectedRowsCount - 1
                If Not IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("SendDate")) AndAlso IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ReceiveDate")) Then
                    iDB.ReturnPoakOfficeEcr(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ID"))
                End If
            Next

            Call Load1()
            Call Load2()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub mnuToTesuch_Click(sender As Object, e As EventArgs) Handles mnuToTesuch.Click
        Try

            Dim f As New TakeTesuch
            f.ShowDialog()
            f.Dispose()

            Call Load1()
            Call Load2()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub mnuToExcel_Click(sender As Object, e As EventArgs) Handles mnuToExcel.Click
        ExportTo2(ExportType.Excel2013, GridControl1)
    End Sub
    Private Sub mnuExcelX_Click(sender As Object, e As EventArgs) Handles mnuExcelX.Click
        ExportTo2(ExportType.Excel2013, GridControl2)
    End Sub

End Class