Public Class ChangeSetEquipmentPrice

    Friend ID As Short
    Friend Equipment As String
    Friend Price As Decimal

    Private Sub LoadEquipment()
        Try
            Dim dt As DataTable = iDB.GetEquipmentList()
            With cEquipment
                .DataSource = dt
                .DisplayMember = "Սարքավորում"
                .ValueMember = "ՀՀ"
                .Text = Equipment
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
        txtAmount.Text = Price
        txtAmount.Focus()
    End Sub
    Private Sub btnChangeClick(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            If txtAmount.Text < 0 Then Throw New Exception("Գորմարը չի կարող 0-ից փոքր լինել")

            Dim Parameters As New List(Of SqlClient.SqlParameter)
            With Parameters
                .Add(New SqlClient.SqlParameter("@ID", ID))
                .Add(New SqlClient.SqlParameter("@Price", CDec(txtAmount.Text)))
            End With

            Call iDB.ExecToSql("Payment.UpdateTarifSel", CommandType.StoredProcedure, Parameters.ToArray)

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