Public Class EquipmentRemakeChangePrice

    Friend ID As Integer
    Friend Equipment As String
    Friend Price As Decimal
    Friend tarifID As Short

    Private Sub EquipmentRemakeChangePrice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtEquipment.Text = Equipment
        txtAmount.Text = Price
    End Sub
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            If txtAmount.Text < 0 Then Throw New Exception("Գումարը չպետք է բացասական լինի")

            Dim r As Decimal = iDB.GetCustomPriceForRemake(ID, tarifID)

            'If txtAmount.Text <> 0 Then
            '    Dim z As Double = 100 * txtAmount.Text / r
            '    If z < 80 OrElse z > 120 Then Throw New Exception("Գրված գումարը շեղվել է 20 %-ից: Սարքավորման արժեքը " & r & " դրամ է")
            'End If

            iDB.UpdateSoldEquipmentPrice(ID, txtAmount.Text)

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