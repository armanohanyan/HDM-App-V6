Imports DevExpress.XtraGrid

Public Class ChangeEcrStatus

    Private Sub LoadStatus2()
        Try
            Dim dt As DataTable = iDB.GetFilteredStatus2()

            With cbStatus
                .DataSource = dt
                .DisplayMember = "Status"
                .ValueMember = "statusID"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            Dim dt As DataTable = iDB.GetOtherStatusEcr()

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            With GridView1
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsSelection.EnableAppearanceFocusedRow = False

                .Columns("id").Visible = False
                .Columns("T").Visible = False

                '.Columns("Code").Caption = "Կոդ"

                For i As Integer = 0 To GridView1.Columns.Count - 1
                    .Columns(i).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                Next

            End With

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "{0}")
                    GridView1.Columns("ՀԴՄ").Summary.Add(item)
                End If
            End If

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub ChangeEcrStatus_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadStatus2()
        Call LoadData()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If txtEcr.Text.Trim = String.Empty Then Throw New Exception("ՀԴՄ-ն նշված չէ")

            Dim t As String
            If cbStatus.SelectedValue = 13 Then
                t = "S"
            Else
                t = "T"
            End If

            iDB.ChangeStatus(txtEcr.Text.Trim, t, iUser.UserID)

            Call LoadData()

            txtEcr.Text = String.Empty

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub mnuChange_Click(sender As Object, e As EventArgs) Handles mnuChange.Click
        Try
            If GridView1.SelectedRowsCount = 0 Then Throw New Exception("Նշված տողեր չկան")

            Dim StatusID As Integer = -1

            Dim f As New CStatus
            f.ShowDialog()
            StatusID = f.StatusID
            f.Dispose()

            If StatusID = -1 Then Exit Sub

            For i As Integer = 0 To GridView1.SelectedRowsCount - 1
                Dim ID As Integer = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("id")
                Dim T As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("T")

                iDB.DropStatus(ID, T, StatusID, iUser.UserID)

            Next

            Call LoadData()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Try
            Call CloseWindow("nStatusHistory")
            Dim f As New StatusHistory
            AddChildForm("nStatusHistory", f)

            Dim dt As DataTable = iDB.StatusHistory()

            With f
                .GridControl1.BeginUpdate()
                .GridControl1.DataSource = Nothing
                .GridView1.Columns.Clear()

                .GridControl1.DataSource = dt

                With .GridView1
                    .OptionsCustomization.AllowColumnMoving = False
                    .OptionsCustomization.AllowGroup = False
                    .OptionsSelection.EnableAppearanceFocusedCell = False
                    .OptionsSelection.EnableAppearanceFocusedRow = False

                    For i As Integer = 0 To GridView1.Columns.Count - 1
                        .Columns(i).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                    Next

                End With

                If .GridView1.RowCount > 0 Then
                    If GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                        Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "{0}")
                        .GridView1.Columns("ՀԴՄ").Summary.Add(item)
                    End If
                End If

                .GridView1.ClearSelection()
                .GridControl1.EndUpdate()
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class