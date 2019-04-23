﻿Public Class ObjTypeAddWin

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtObjectType.Text) Then Throw New Exception("Տվյալները գրված չեն")
            iDB.InsertObjectType(txtObjectType.Text.Trim)
            MsgBox("Տվյալը հաջողությամբ ավելացվեց բազա", MsgBoxStyle.Information, My.Application.Info.Title)
            txtObjectType.Text = String.Empty
            txtObjectType.Focus()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class