Public Class EcrMessageWindow

    Friend Ecr As String = String.Empty

    Private Sub LoadProblems()
        Try
            Dim dt As DataTable = iDB.GetRemakeProblem()
            With cbProblem
                .DataSource = dt
                .DisplayMember = "Problem"
                .ValueMember = "ID"
            End With
        Catch ex As Exception
            btnOK.Enabled = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub LoadUsers()
        Try
            Dim dt2 As DataTable = iDB.UsersForRemakeMessage(iUser.UserID)

            For i As Integer = 0 To dt2.Rows.Count - 1
                cbEmployee.Properties.Items.Add(dt2.Rows(i)("UserID"), dt2.Rows(i)("LoginName").ToString)
            Next
        Catch ex As Exception
            btnOK.Enabled = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

    Private Sub EcrMessageWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadProblems()
        Call LoadUsers()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            Dim iItems = From item In cbEmployee.Properties.Items Where item.CheckState = CheckState.Checked
                         Select CInt(item.Value)

            Dim DTX As New DataTable With {.TableName = "iItems"}
            DTX.Columns.Add(New DataColumn("Item", GetType(Integer)))

            If iItems.Count > 0 Then
                For i As Integer = 0 To iItems.Count - 1
                    Dim R As DataRow = DTX.NewRow
                    R("Item") = iItems(i)
                    DTX.Rows.Add(R)
                Next
            End If

            If IsNothing(DTX) OrElse DTX.Rows.Count = 0 Then Throw New Exception("Որևէ աշխատակից նշված չէ")

            If IsNothing(cbProblem.SelectedValue) Then Throw New Exception("Խնդիրը նշված չէ")

            iDB.NewRemakeMessage(Ecr, cbProblem.SelectedValue, iUser.UserID, DTX)

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

    Private Sub btnAddNewProblem_Click(sender As Object, e As EventArgs) Handles btnAddNewProblem.Click
        Dim ff As New RemNewProblem
        ff.ShowDialog()
        ff.Dispose()

        Call LoadProblems()
    End Sub

End Class