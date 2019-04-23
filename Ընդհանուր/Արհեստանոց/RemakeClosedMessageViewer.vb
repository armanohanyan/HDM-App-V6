Public Class RemakeClosedMessageViewer

    Friend ID As Integer = -1

    Private Sub LoadData()
        Try
            Dim dt As DataTable = iDB.RemakeMessageByID(ID)

            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                txtSUser.Text = dt.Rows(0)("SendUser")
                txtEcr.Text = dt.Rows(0)("Ecr")
                txtProblem.Text = dt.Rows(0)("Problem")
                txtSDate.Text = dt.Rows(0)("SendTime")
                txtAUser.Text = dt.Rows(0)("CloseUSer")
                txtRep.Text = dt.Rows(0)("CloseMessage")
                txtRepDate.Text = dt.Rows(0)("CloseTime")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub RemakeClosedMessageViewer_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub

End Class