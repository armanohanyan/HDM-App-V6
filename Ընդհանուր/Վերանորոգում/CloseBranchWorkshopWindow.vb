Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class CloseBranchWorkshopWindow

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub AddEnterClick()
        iDB.CloseBranchWorkshop(txtEcr.Text.Trim, iUser.LoginName)
    End Sub
    Private Sub txtClicker_TextChanged(sender As Object, e As EventArgs) Handles txtEcr.TextChanged

        If txtEcr.Text.Trim.Length = 1 Then
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

        If txtEcr.Text.Trim.Length <> 12 Then Exit Sub

        If Not (Microsoft.VisualBasic.Left(txtEcr.Text.Trim, 1).ToString.ToLower = "v" OrElse Microsoft.VisualBasic.Left(txtEcr.Text.Trim, 1).ToString.ToLower = "q" OrElse Microsoft.VisualBasic.Left(txtEcr.Text.Trim, 1).ToString.ToLower = "s") Then Exit Sub
        Try
            Call AddEnterClick()
            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            txtEcr.Text = String.Empty
            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub CloseBranchWorkshopWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckPermission2("12D76A3EA38A43B89DCC39BCCFF62B1C") = False Then txtEcr.Enabled = False
    End Sub

End Class