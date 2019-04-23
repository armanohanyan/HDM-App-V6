Imports System.Data.SqlClient
Imports DevExpress.Utils

Public Class changeGeneralHaytInfo

    Friend haytTesuch As String = ""
    Friend haytHDM As String = ""
    Friend haytHVHH As String = ""
    Friend HaytCompany As String = ""
    Friend haytTel As String = ""
    Friend haytAddress As String = ""
    Friend haytID As Integer = -1
    Friend haytSpasarkox As String = ""
    Friend haytXndir As String = ""
    Friend haytDate As DateTime
    Friend haytRegion As String = ""

    Private Sub LoadTesuch()
        Try
            Dim dt As DataTable = iDB.GetWorkingTesuchList()
            With cbTesuch
                .DataSource = dt
                .DisplayMember = "Տեսուչ"
                .ValueMember = "ՀՀ"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadRegion()
        Try
            Dim dt As DataTable = iDB.GetRegion
            With cbRegion
                .DataSource = dt
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "Տարածաշրջան"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadSupporter()
        Try
            Try
                Dim dt As DataTable = iDB.GetSupporter()
                With cbSupporter
                    .DataSource = dt
                    .DisplayMember = "Կազմակերպություն"
                    .ValueMember = "ՀՀ"
                End With
            Catch ex As ExceptionClass
            Catch ex As System.Data.SqlClient.SqlException
                Call SQLException(ex)
            Catch ex As Exception
                Call SoftException(ex)
            End Try
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub haytchangetesuch_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Call LoadTesuch()
        Call LoadSupporter()
        Call LoadRegion()

        cbTesuch.Text = haytTesuch
        cbSupporter.Text = haytSpasarkox
        cbRegion.Text = haytRegion

        txtEcr.Text = haytHDM
        txtHvhh.Text = haytHVHH
        txtClient.Text = HaytCompany
        txtTel.Text = haytTel
        txtAddress.Text = haytAddress
        txtProblem.Text = haytXndir

        With ApprDate
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .DateTime = haytDate
        End With

    End Sub
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try

            iDB.UpdateProposalGeneral(txtEcr.Text.Trim, txtHvhh.Text.Trim, txtClient.Text.Trim, cbTesuch.Text, txtTel.Text.Trim, txtAddress.Text.Trim, cbSupporter.SelectedValue, haytID, txtProblem.Text.Trim, ApprDate.DateTime, cbRegion.SelectedValue)

            'MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class