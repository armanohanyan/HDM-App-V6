Public Class AddSetEquipmentPrice

    Friend TarifID As Short

    Private Sub LoadEquipment()
        Try
            'Dim dt As DataTable = iDB.GetEquipmentList()
            Dim dt As DataTable = iDB.GetEquipmentListWithShtrikhCode()
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
            If txtAmount.Text < 0 Then Throw New Exception("Գորմարը չի կարող 0-ից փոքր լինել")

            Dim Parameters As New List(Of SqlClient.SqlParameter)
            With Parameters
                .Add(New SqlClient.SqlParameter("@EquipmentID", cEquipment.SelectedValue))
                .Add(New SqlClient.SqlParameter("@TarifID", TarifID))
                .Add(New SqlClient.SqlParameter("@Price", CDec(txtAmount.Text)))
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