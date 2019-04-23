Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class changeProposal

    Friend Ecr As String
    Friend isDamaged As Boolean
    Friend strState As String

    Private Sub loadHayt()
        Dim dt As DataTable = iDB.LoadProblemList()
        With cbHayt
            .DataSource = dt
            .DisplayMember = "Problem"
            .ValueMember = "IsSoftware"
        End With
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim hayt As String
        If isDamaged Then
            hayt = cbHayt.Text & " (Արտաքին Վնասվածքով) " & strState
        Else
            hayt = cbHayt.Text & " " & strState
        End If
        iDB.ChangeRemakeProposal(Ecr, hayt, cbHayt.SelectedValue, iUser.UserID)
        MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
        Me.Close()
    End Sub
    Private Sub changeProposal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadHayt()
    End Sub

End Class