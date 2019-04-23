Imports DevExpress.XtraGrid

Public Class ClosedPropSelect

    Private Sub ClosedPropSelect_Load(sender As Object, e As EventArgs) Handles Me.Load
        sDate.DateTime = New Date(Now.Year, Now.Month, 1)
        eDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim frmX As New Working
        frmX.Show()
        My.Application.DoEvents()

        Try
            Dim dt As DataTable

            Dim sd As Date = sDate.DateTime
            Dim ed As Date = DateAdd(DateInterval.Day, 1, eDate.DateTime)

            If iUser.DB = 5 Then
                dt = iDB.ClosedPropAllByDate(sd, ed)
            Else
                dt = iDB.ClosedPropSupporterByDate(sd, ed, iUser.DB)
            End If

            Call CloseWindow("nClosedPropView")
            Dim f As New ClosedPropView
            AddChildForm("nClosedPropView", f)

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = dt

            With f.GridView1
                If .RowCount > 0 Then

                    .Columns("ՀայտիԸնդունմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ՀայտիԸնդունմանԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                    .Columns("ՀայտիՓակմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ՀայտիՓակմանԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                    .Columns("ԿոորդինատիԺամ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ԿոորդինատիԺամ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                    For i As Integer = 0 To .Columns.Count - 1
                        .Columns(i).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                    Next

                    If .Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                        Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "{0}")
                        .Columns("ՀԴՄ").Summary.Add(item)
                    End If
                End If
                For i As Integer = 0 To .Columns.Count - 1
                    .Columns(i).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                Next
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

End Class