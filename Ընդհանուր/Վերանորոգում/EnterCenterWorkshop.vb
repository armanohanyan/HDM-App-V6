Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class EnterCenterWorkshop

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub AddEnterClick()
        iDB.AddEnterCenterWorkshop(txtEcr.Text.Trim, iUser.LoginName)
    End Sub
    Private Sub txtEcr_TextChanged(sender As Object, e As EventArgs) Handles txtEcr.TextChanged

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
                txtEcr.Text = txtEcr.Text.Replace("S", "S900552") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("s") Then
                txtEcr.Text = txtEcr.Text.Replace("s", "S900552") : txtEcr.SelectionStart = txtEcr.Text.Length
            End If
        End If

        If txtEcr.Text.Trim.Length <> 12 Then Exit Sub

        If Not (Microsoft.VisualBasic.Left(txtEcr.Text.Trim, 1).ToString.ToLower = "v" OrElse Microsoft.VisualBasic.Left(txtEcr.Text.Trim, 1).ToString.ToLower = "q" OrElse Microsoft.VisualBasic.Left(txtEcr.Text.Trim, 1).ToString.ToLower = "s") Then Exit Sub
        Try
            If iUser.DB <> 5 Then Throw New Exception("Գործողությունը արգելվում է")
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
    Private Sub EnterCenterWorkshop_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (iUser.DB = 1 OrElse iUser.DB = 3) Then txtEcr.Enabled = False
    End Sub
    Private Sub EnterCenterWorkshop_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckPermission2("53671AC392014AD09D4253D51667800B") = False Then txtEcr.Enabled = False
    End Sub

End Class