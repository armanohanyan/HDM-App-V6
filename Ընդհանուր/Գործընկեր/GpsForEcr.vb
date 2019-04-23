Public Class GPSForEcr

    Friend ClientID As Integer

    Private Sub LoadData()
        Try
            Dim dt As DataTable

            dt = iDB.GetClientForGps(ClientID)

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            With GridView1
                .Columns("ID").Visible = False
                .Columns("ecrID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = True
                .OptionsBehavior.ReadOnly = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False

                .Columns("ID").OptionsColumn.ReadOnly = True
                .Columns("ecrID").OptionsColumn.ReadOnly = True
                .Columns("ՀՎՀՀ").OptionsColumn.ReadOnly = True
                .Columns("Կազմակերպություն").OptionsColumn.ReadOnly = True
                .Columns("ՀԴՄ").OptionsColumn.ReadOnly = True
                .Columns("ԳործունեությանՀասցե").OptionsColumn.ReadOnly = True
                .Columns("Տարածաշրջան").OptionsColumn.ReadOnly = True

                .BestFitColumns(True)

            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub GpsForEcr_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub
    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            'Insert
            If String.IsNullOrEmpty(GridView1.GetRowCellValue(e.RowHandle, "ID").ToString) Then
                If IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "Latitude")) Then Exit Sub
                If IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "Longitude")) Then Exit Sub

                Dim Parameters As New List(Of SqlClient.SqlParameter)
                With Parameters
                    .Add(New SqlClient.SqlParameter("@ecrID", GridView1.GetRowCellValue(e.RowHandle, "ecrID")))
                    .Add(New SqlClient.SqlParameter("@Latitude", GridView1.GetRowCellValue(e.RowHandle, "Latitude")))
                    .Add(New SqlClient.SqlParameter("@Longitude", GridView1.GetRowCellValue(e.RowHandle, "Longitude")))
                End With

                Call iDB.ExecToSql("Client.InsertEcrGPS", CommandType.StoredProcedure, Parameters.ToArray)

                Call LoadData()

            Else 'Update
                If IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "Latitude")) Then Exit Sub
                If IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "Longitude")) Then Exit Sub

                Dim Parameters As New List(Of SqlClient.SqlParameter)
                With Parameters
                    .Add(New SqlClient.SqlParameter("@ID", GridView1.GetRowCellValue(e.RowHandle, "ID")))
                    .Add(New SqlClient.SqlParameter("@Latitude", GridView1.GetRowCellValue(e.RowHandle, "Latitude")))
                    .Add(New SqlClient.SqlParameter("@Longitude", GridView1.GetRowCellValue(e.RowHandle, "Longitude")))
                End With

                Call iDB.ExecToSql("Client.UpdateEcrGPS", CommandType.StoredProcedure, Parameters.ToArray)

                'Call LoadData()

            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class