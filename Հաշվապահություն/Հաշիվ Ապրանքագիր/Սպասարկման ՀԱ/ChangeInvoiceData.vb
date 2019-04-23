Public Class ChangeInvoiceData

    Friend InvoiceID As Integer = -1
    Friend TarifID As Short
    Friend EcrCount As Short
    Friend WorkingDays As Short
    Friend Y As Short
    Friend M As Byte

    Friend Price As Decimal
    Friend nds As Decimal
    Friend TotalPrice As Decimal

    Dim maxWorkDays As Short

    Private Sub ChangeInvoiceData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEcrCount.Text = EcrCount
        txtWorkDay.Text = WorkingDays
        txtPrice.Text = Price
        txtNDS.Text = nds
        txtTotal.Text = TotalPrice

        maxWorkDays = System.DateTime.DaysInMonth(Y, M)
        txtMaxWorkDay.Text = maxWorkDays
    End Sub
    Private Sub btnChangeData_Click(sender As Object, e As EventArgs) Handles btnChangeData.Click
        Try

            If txtEcrCount.Text < 0 Then Throw New Exception("ՀԴՄ քանակը 0-ից փոքր չի կարող լինել")
            If txtEcrCount.Text = 0 AndAlso txtWorkDay.Text > 0 Then Throw New Exception("Աշխատած օրերի քանակը 0-ից մեծ չի կարող լինել, երբ ՀԴՄ քանակը 0 է")
            If txtWorkDay.Text < 0 Then Throw New Exception("Աշխատած օրերի քանակը 0-ից փոքր չի կարող լինել")

            Dim max2 As Integer = txtEcrCount.Text * maxWorkDays
            If txtWorkDay.Text > max2 Then Throw New Exception("ՀԴՄ քանակի և ամսվա օրերի քանակի արտադրյալը ավելի փոքր է, քան նշվել է որպես աշխատած օրերի քանակ")

            'Get Tarif Info
            Dim dt As DataTable = iDB.GetTarifForInvoiceByID(TarifID)

            Dim TarifPrice As Decimal = 0
            Select Case maxWorkDays
                Case 28
                    TarifPrice = dt.Rows(0)("day_28")
                Case 29
                    TarifPrice = dt.Rows(0)("day_29")
                Case 30
                    TarifPrice = dt.Rows(0)("day_30")
                Case 31
                    TarifPrice = dt.Rows(0)("day_31")
            End Select

            txtPrice.Text = txtWorkDay.Text * TarifPrice
            txtNDS.Text = txtPrice.Text * 0.2
            txtTotal.Text = txtPrice.Text * 1.2

            'Update Invoice Data
            iDB.UpdateSupportInvoiceData(txtEcrCount.Text, txtWorkDay.Text, txtPrice.Text, txtNDS.Text, txtTotal.Text, InvoiceID, iUser.LoginName)

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