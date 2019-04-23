Imports DevExpress.Utils

Public Class DExt1

    Friend ExpTime As Date
    Friend Ecr As String

    Private Sub DExt1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cDateEdit
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .Properties.MinValue = ExpTime
        End With
    End Sub
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            If ckAdd.Checked = True Then
                If MsgBox("Ցանկանու՞մ եք փոխել վերջնաժամկետը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then
                    iDB.ExtendExpireDate(Ecr, cDateEdit.DateTime)

                    MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
                    Me.Close()
                Else
                    Me.Close()
                End If
            Else
                If MsgBox("Ցանկանու՞մ եք փոխել վերջնաժամկետը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then
                    iDB.ExtendExpireDateActive(Ecr, cDateEdit.DateTime)

                    MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
                    Me.Close()
                Else
                    Me.Close()
                End If
            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class