Imports DevExpress.Utils

Public Class AddEcr

    Friend RefForm As New PoakToOffice

    Private Sub LoadTesuch()
        Try
            Dim dtT As System.Data.DataTable = iDB.GetWorkingTesuch2()
            With cTesuch
                .DataSource = dtT
                .DisplayMember = "Name"
                .ValueMember = "ID"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub AddEcr_Load(sender As Object, e As EventArgs) Handles Me.Load
        With dDate
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With

        Call LoadTesuch()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtEcr.Text.Trim = String.Empty Then Throw New Exception("ՀԴՄ-ն գրված չէ")
            If txtEcr.Text.Trim.Length <> 12 Then Throw New Exception("Սխալ ՀԴՄ")

            iDB.InsertEcrFromPoak(txtEcr.Text.Trim, cTesuch.SelectedValue, dDate.DateTime)

            RefForm.Load1()
            RefForm.Load2()

            txtEcr.Text = String.Empty
            txtEcr.Focus()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class