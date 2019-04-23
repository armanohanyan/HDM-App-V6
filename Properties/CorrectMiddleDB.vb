Public Class CorrectMiddleDB

    Private Sub btnPoakBazaForAdd_Click(sender As Object, e As EventArgs) Handles btnPoakBazaForAdd.Click
        Try
            btnPoakBazaForAdd.Enabled = False

            iDB.ProcpoakToDBForAdding()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
            btnPoakBazaForAdd.Enabled = True
        Catch ex As System.Data.SqlClient.SqlException
            btnPoakBazaForAdd.Enabled = True
            Call SQLException(ex)
        Catch ex As Exception
            btnPoakBazaForAdd.Enabled = True
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnpoakToDBGetReRegistering_Click(sender As Object, e As EventArgs) Handles btnpoakToDBGetReRegistering.Click
        Try
            btnpoakToDBGetReRegistering.Enabled = False

            iDB.ProcpoakToDBGetReRegistering()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
            btnpoakToDBGetReRegistering.Enabled = True
        Catch ex As System.Data.SqlClient.SqlException
            btnpoakToDBGetReRegistering.Enabled = True
            Call SQLException(ex)
        Catch ex As Exception
            btnpoakToDBGetReRegistering.Enabled = True
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnpoakToDBMGHChanges_Click(sender As Object, e As EventArgs) Handles btnpoakToDBMGHChanges.Click
        Try
            btnpoakToDBMGHChanges.Enabled = False

            iDB.ProcpoakToDBMGHChanges()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
            btnpoakToDBMGHChanges.Enabled = True
        Catch ex As System.Data.SqlClient.SqlException
            btnpoakToDBMGHChanges.Enabled = True
            Call SQLException(ex)
        Catch ex As Exception
            btnpoakToDBMGHChanges.Enabled = True
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnChangePoakHVHH_Click(sender As Object, e As EventArgs) Handles btnChangePoakHVHH.Click
        Try
            btnChangePoakHVHH.Enabled = False

            iDB.ChangePoakHVHH()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
            btnChangePoakHVHH.Enabled = True
        Catch ex As System.Data.SqlClient.SqlException
            btnChangePoakHVHH.Enabled = True
            Call SQLException(ex)
        Catch ex As Exception
            btnChangePoakHVHH.Enabled = True
            Call SoftException(ex)
        End Try
    End Sub
End Class