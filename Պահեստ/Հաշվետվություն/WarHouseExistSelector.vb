Public Class WarHouseExistSelector

    Private Sub loadSupporter()
        Try
            Dim dt As DataTable

            If iUser.DB = 5 Then
                dt = iDB.GetWarehouseList()
            Else
                dt = iDB.GetSupporter2(iUser.DB)
            End If
            With cbSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub loadEquipments()
        Try
            Dim dt As DataTable
            If cNoNyut.Checked = True Then
                dt = iDB.GetEquipmentForFilter()
            Else
                dt = iDB.GetEquipmentForFilterNyut()
            End If
            With cEquipment
                .DataSource = dt
                .DisplayMember = "Սարքավորում"
                .ValueMember = "ՀՀ"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub WarHouseExistSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sDate.DateTime = New Date(Now.Year, Now.Month, 1)
        eDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
        Call loadSupporter()
        Call loadEquipments()
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Call CloseWindow("nTesuch")
        Dim f As New RepWarehouseExisting With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .WarehouseID = cbSupporter.SelectedValue, .EquipmentID = cEquipment.SelectedValue, .IsEquipment = cNoNyut.Checked}
        AddChildForm("nTesuch", f)
        Me.Close()
    End Sub
    Private Sub cNoNyut_CheckedChanged(sender As Object, e As EventArgs) Handles cNoNyut.CheckedChanged
        Call loadEquipments()
    End Sub
    Private Sub cNyut_CheckedChanged(sender As Object, e As EventArgs) Handles cNyut.CheckedChanged
        Call loadEquipments()
    End Sub

End Class