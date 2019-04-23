Public Class EcrFunctional

    Friend Ecr As String

    Private Sub LoadData()
        Try
            Dim dt As DataTable = iDB.GetEcrFunctional(Ecr)
            If dt.Rows.Count = 1 Then

                cInvoice.Checked = dt.Rows(0)("Invoiceing")
                'If cInvoice.Checked = True Then cInvoice.Enabled = False

                cPos.Checked = dt.Rows(0)("PosTerminal")
                'If cPos.Checked = True Then cPos.Enabled = False

                cVTQ.Checked = dt.Rows(0)("VTQ")
                'If cVTQ.Checked = True Then cVTQ.Enabled = False

                cShrjik.Checked = dt.Rows(0)("Shrjik")
                If cShrjik.Checked = True Then cShrjik.Enabled = False

                If cInvoice.Enabled = False AndAlso cPos.Enabled = False AndAlso cVTQ.Enabled = False AndAlso cShrjik.Enabled = False Then
                    btnChange.Enabled = False
                End If
            Else
                btnChange.Enabled = False
                Throw New Exception("Տվյալներ չեն ստացվել")
            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub EcrFunctional_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadData()
        If Not Ecr.StartsWith("V") Then cVTQ.Enabled = False
    End Sub
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            If MsgBox("Ցանկանու՞մ եք փոխել տվյալները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            iDB.SetEcrFunctional(cPos.Checked, cInvoice.Checked, cVTQ.Checked, cShrjik.Checked, Ecr)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class