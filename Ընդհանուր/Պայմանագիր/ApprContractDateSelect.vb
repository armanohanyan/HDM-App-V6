Public Class ApprContractDateSelect

    Friend Property CurDate As Date

    Private Sub ApprContractDateSelect_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CurDate = sDate.DateTime
    End Sub

    Private Sub ApprContractDateSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sDate.DateTime = Now
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

End Class