﻿Imports DevExpress.XtraGrid

Public Class EditActivateHayt

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim frmX As New Working
        frmX.Show()
        Try
            Dim dt As DataTable

            Dim sd As Date = sDate.DateTime
            Dim ed As Date = DateAdd(DateInterval.Day, 1, eDate.DateTime)

            If ckInterval.Checked Then
                dt = iDB.GetOpenActivateHayt(sd, ed)
            Else
                dt = iDB.GetOpenActivateHayt(DateTime.MinValue, DateTime.MinValue)
            End If

            Call CloseWindow("nHaytActivateEdit")

            Dim f As New HaytActivateEdit
            AddChildForm("nHaytActivateEdit", f)

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = dt

            f.GridView1.Columns("ՀՀ").Visible = False
            'f.GridView1.Columns("Հեռախոս").Visible = False
            f.GridView1.Columns("Տարածաշրջան").Visible = False
            f.GridView1.Columns("Սպասարկող").Visible = False
            f.GridView1.Columns("Դիտված").Visible = False
            f.GridView1.Columns("ՀայտիՏեսակ").Visible = False
            f.GridView1.Columns("Խնդիր").Visible = False
            f.GridView1.OptionsSelection.MultiSelect = True

            Dim columnN As Integer = 0
            For Each column As DevExpress.XtraGrid.Columns.GridColumn In f.GridView1.Columns
                f.GridView1.Columns(columnN).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                columnN = columnN + 1
            Next

            With f.GridView1
                .Columns("ՀայտիԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՀայտիԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                .Columns("ԸնդունմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ԸնդունմանԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                .Columns("Տևողություն").DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
                '.Columns("Տևողություն").DisplayFormat.FormatString = "HH:mm"
                If .RowCount > 0 Then
                    If .Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                        Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "{0}")
                        .Columns("ՀԴՄ").Summary.Add(item)
                    End If
                End If
            End With
            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            frmX.Dispose()
        End Try
    End Sub
    Private Sub EditActivateHayt_Load(sender As Object, e As EventArgs) Handles Me.Load
        sDate.DateTime = New Date(Now.Year, Now.Month, 1)
        eDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
    End Sub

End Class