Public Class LicUpd

    Friend ID As Integer
    Friend Ecr As String
    Friend Bank As String
    Friend Lic As String
    Friend IsActive As Boolean

    Private Sub LoadBank()
        Try
            Dim dt As DataTable = iDB.GetBankList()
            With cBank
                .DataSource = dt
                .DisplayMember = "Բանկ"
                .ValueMember = "ՀՀ"
                If .Items.Count = 0 Then btnAdd.Enabled = False
                .Text = Bank
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtLic.Text) Then Throw New Exception("Տվյալները գրված չեն")
            If String.IsNullOrEmpty(txtEcr.Text) Then Throw New Exception("Տվյալները գրված չեն")

            iDB.ChangeLic(ID, Ecr, txtLic.Text.Trim, cBank.SelectedValue, cActive.Checked)

            MsgBox("Տվյալները հաջողությամբ փոփոխվեցին", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LicAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadBank()
        txtEcr.Text = Ecr
        txtLic.Text = Lic
        cActive.Checked = IsActive
    End Sub

End Class