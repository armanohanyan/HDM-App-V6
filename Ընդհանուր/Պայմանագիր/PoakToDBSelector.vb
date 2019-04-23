Public Class PoakToDBSelector

    Private Sub loadStatus()
        Try
            Dim dt As DataTable = iDB.GetStatus()
            With cbList
                .DataSource = dt
                .DisplayMember = "Կարգավիճակ"
                .ValueMember = "Կարգավիճակ"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub PoakToDBSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadStatus()
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

        btnSelect.Enabled = False

        Call CloseWindow("nPoakAdding")
        Dim f As New PoakToDB
        AddChildForm("nPoakAdding", f)
        f.LoadData(cbList.SelectedValue)

        Me.Close()

    End Sub

End Class