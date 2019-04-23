Public Class TesuchUpdateWindow

    Friend iTesuchID As Short = -1
    Friend TesuchName As String = String.Empty
    Friend TesuchStatus As Boolean = False
    Friend TesuchMail As Object
    Friend TesuchTel As Object

    'Load Default values
    Private Sub LoadDefaultValues()
        txtTesuchName.Text = TesuchName
        If Not IsDBNull(TesuchMail) Then txtEmail.Text = TesuchMail
        If Not IsDBNull(TesuchTel) Then txtTel.Text = TesuchTel
        ckActive.Checked = TesuchStatus
    End Sub

    'Form Load
    Private Sub TesuchUpdateWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Call LoadDefaultValues()
            txtTesuchName.Focus()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'Update tesuch
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrEmpty(txtTesuchName.Text) Then Throw New Exception("Տվյալները գրված չեն")

            iDB.UpdateTesuchInfo(txtTesuchName.Text.Trim, ckActive.Checked, txtEmail.Text.Trim, txtTel.Text.Trim, iTesuchID)

            MsgBox("Տվյալը հաջողությամբ փոփոխվեցին", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class