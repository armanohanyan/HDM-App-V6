Public Class AddNyutPrice

    Friend TarifID As Short

    Private Sub LoadEquipment()
        Try
            Dim dt As DataTable = iDB.GetEquipmentListWithoutShtrikhCode()
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
    Private Sub AddSetEquipmentPrice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadEquipment()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim Parameters As New List(Of SqlClient.SqlParameter)
            With Parameters
                .Add(New SqlClient.SqlParameter("@EquipmentID", cEquipment.SelectedValue))
                .Add(New SqlClient.SqlParameter("@TarifID", TarifID))
                .Add(New SqlClient.SqlParameter("@Price", CDec(0)))
            End With

            Call iDB.ExecToSql("Payment.InsertTarifSel", CommandType.StoredProcedure, Parameters.ToArray)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class