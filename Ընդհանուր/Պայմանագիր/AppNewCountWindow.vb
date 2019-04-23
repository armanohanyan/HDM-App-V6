Public Class AppNewCountWindow

    Friend RecID As Integer
    Friend CCount As Short
    Friend ClientID As Integer

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            If String.IsNullOrEmpty(txtNewCount.Text) Then MsgBox("Քանակը գրված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

            iDB.ChangeContractCount(RecID, txtNewCount.Text.Trim, ClientID)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub TextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewCount.KeyPress
        On Error Resume Next
        If Not (e.KeyChar = "-") AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub
    Private Sub AppNewCountWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNewCount.Text = CCount
    End Sub

End Class