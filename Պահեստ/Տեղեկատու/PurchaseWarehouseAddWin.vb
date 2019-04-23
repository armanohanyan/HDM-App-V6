Imports DevExpress.Utils

Public Class PurchaseWarehouseAddWin

    Private Sub loadList()
        Try
            Dim dt2 As DataTable = iDB.GetCompanyWarehouse
            With cbSupporter
                .DataSource = dt2
                .DisplayMember = "Պահեստ"
                .ValueMember = "ՀՀ"
                If iUser.DB = 5 Then .SelectedIndex = 0 Else .SelectedValue = iUser.DB : .Enabled = False
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub PurchaseWarehouseAddWin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With sDate
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With

        Call loadList()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim r As String = DirectCast(cbSupporter.SelectedItem, DataRowView).Item("Պահեստ")
        Dim f As New PurchaseInsert With {.sDate = sDate.DateTime, .sWareHouse = r, .iWareHouseID = cbSupporter.SelectedValue}
        f.ShowDialog()
        f.Dispose()
    End Sub
    Private Sub btnAddEquip_Click(sender As Object, e As EventArgs) Handles btnAddEquip.Click
        Dim r As String = DirectCast(cbSupporter.SelectedItem, DataRowView).Item("Պահեստ")
        Dim f As New PurchaseInsert2 With {.sDate = sDate.DateTime, .sWareHouse = r, .iWareHouseID = cbSupporter.SelectedValue}
        f.ShowDialog()
        f.Dispose()
    End Sub

End Class