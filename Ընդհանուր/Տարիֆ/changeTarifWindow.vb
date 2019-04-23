Public Class changeTarifWindow

    Dim ClientID As Integer = -1

    Private Sub loadTarif()
        Try
            Dim dt As DataTable = iDB.GetTarif()
            With cbTarif
                .DataSource = dt
                .DisplayMember = "Տարիֆ"
                .ValueMember = "ՀՀ"
                .SelectedIndex = 0
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try

            If CheckPermission2("FDD545685E424BA4B91D004C3B195E53") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If txtHVHH.Text.Trim = String.Empty Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")

            Dim dt As DataTable = iDB.GetUpcomingTarifInfo(txtHVHH.Text.Trim)

            If dt.Rows.Count = 1 Then
                txtHVHH.ReadOnly = True

                txtClient.Text = dt.Rows(0)("CompanyName")
                txtTarif.Text = dt.Rows(0)("TarifType")
                ClientID = dt.Rows(0)("ClientID")

                btnChange.Enabled = True
                btnCheck.Enabled = False
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            If CheckPermission2("FDD545685E424BA4B91D004C3B195E53") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If ClientID = -1 Then Throw New Exception("Հաճախորդի տվյալները չեն ստացվել")
            If cbTarif.Text = txtTarif.Text Then Throw New Exception("Տարիֆը պետք է տարբեր լինի")

            iDB.CreateUpcomingTarif(ClientID, cbTarif.SelectedValue)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            txtClient.Text = String.Empty
            txtTarif.Text = String.Empty

            btnChange.Enabled = False
            btnCheck.Enabled = True

            txtHVHH.ReadOnly = False

            txtHVHH.Text = String.Empty
            txtHVHH.Focus()

            ClientID = -1
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub changeTarifWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadTarif()
    End Sub

End Class