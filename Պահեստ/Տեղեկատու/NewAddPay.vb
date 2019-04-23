Public Class NewAddPay

    Friend SupID As Byte = 0

    Private Sub LoadTarif()
        Try
            Dim dt As DataTable

            If iUser.DB = 5 Then
                dt = iDB.GetTarif()
            End If

            With cTarif
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

    Private Sub LoadEquipment()
        Try
            Dim dt As DataTable

            If iUser.DB = 5 Then
                dt = iDB.GetSellEquipment()
            End If

            With cEquip
                .DataSource = dt
                .DisplayMember = "EquipmentName"
                .ValueMember = "EquipmentID"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub NewAddPay_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadTarif()
        Call LoadEquipment()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If txtPrice.Text.Trim = String.Empty Then Throw New Exception("Գումարը գրված չէ")

            iDB.NewAdditionalPrice(SupID, cEquip.SelectedValue, cTarif.SelectedValue, txtPrice.Text)

            MsgBox("Տվյալները ավելացվեցին", MsgBoxStyle.Information, My.Application.Info.Title)

            txtPrice.Text = String.Empty
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

End Class