Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class TarifSelecter

    Private Sub loadTarif()
        Try
            Dim dt As DataTable

            dt = iDB.GetTarif()

            With cbTarif
                .DataSource = dt
                .DisplayMember = "Տարիֆ"
                .ValueMember = "ՀՀ"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub TarifSelecter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadTarif()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Dim tarifID As Byte = cbTarif.SelectedValue

            Call CloseWindow("nSetEquipmentPrice")
            Dim f As New SetEquipmentPrice
            f.TarifID = tarifID
            AddChildForm("nSetEquipmentPrice", f)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Me.Close()
        End Try
    End Sub

End Class