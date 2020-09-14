Public Class LicAdd

    Dim dtClient As DataTable

    Private Sub LoadBank()
        Try
            Dim dt As DataTable = iDB.GetBankList()
            With cBank
                .DataSource = dt
                .DisplayMember = "Բանկ"
                .ValueMember = "ՀՀ"
                If .Items.Count = 0 Then btnAdd.Enabled = False
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadAutocomplet()
        Try
            dtClient = iDB.AutoCompleteEcr()

            txtEcr.AutoCompleteCustomSource.Clear()
            txtEcr.AutoCompleteCustomSource.AddRange((From row In dtClient.Rows.Cast(Of DataRow)() Select CStr(row("ՀԴՄ"))).ToArray())

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub txtEcr_TextChanged(sender As Object, e As EventArgs) Handles txtEcr.TextChanged
        On Error Resume Next
        If txtEcr.Text.Length = 1 Then
            If txtEcr.Text.StartsWith("V") Then
                txtEcr.Text = txtEcr.Text.Replace("V", "V90413") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("v") Then
                txtEcr.Text = txtEcr.Text.Replace("v", "V90413") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("Q") Then
                txtEcr.Text = txtEcr.Text.Replace("Q", "Q80414") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("q") Then
                txtEcr.Text = txtEcr.Text.Replace("q", "Q80414") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("S") Then
                txtEcr.Text = txtEcr.Text.Replace("S", "S90055") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("s") Then
                txtEcr.Text = txtEcr.Text.Replace("s", "S90055") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("A") Then
                txtEcr.Text = txtEcr.Text.Replace("A", "A90022") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("a") Then
                txtEcr.Text = txtEcr.Text.Replace("a", "A90022") : txtEcr.SelectionStart = txtEcr.Text.Length
            End If
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtLic.Text) Then Throw New Exception("Տվյալները գրված չեն")
            If String.IsNullOrEmpty(txtEcr.Text) Then Throw New Exception("Տվյալները գրված չեն")

            iDB.AddLicense(txtEcr.Text.Trim, txtLic.Text.Trim, cBank.SelectedValue)

            MsgBox("Տվյալը հաջողությամբ ավելացվեց բազա", MsgBoxStyle.Information, My.Application.Info.Title)

            txtEcr.Text = String.Empty
            txtLic.Text = String.Empty
            txtEcr.Focus()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LicAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadBank()
        Call LoadAutocomplet()
    End Sub

End Class