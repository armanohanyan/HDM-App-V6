Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class SendToIUNetworks

    Friend iEcr As String

#Region "Disable Close Button"

    Private Const CP_NOCLOSE_BUTTON As Integer = &H200

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property

#End Region

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            If txtEcr.Text.Trim.Length <> 12 Then Throw New Exception("ՀԴՄ-ն սխալ է գրված")
            iDB.SentToIUNet(txtEcr.Text.Trim, txtComment.Text.Trim)
            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub SendToIUNetworks_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(iEcr) Then txtEcr.Text = iEcr
    End Sub

End Class