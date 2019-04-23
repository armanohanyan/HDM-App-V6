Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid

Public Class Bulk_GPS

    Private Sub LoadData()
        Try
            Dim dtX As DataTable = iDB.GetGpsRegAddrEcrList()
            If dtX.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dtX

            With GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
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
    Private Sub LoadData2()
        Try
            Dim dtY As DataTable = iDB.GetGpsRegAddrEcrListCB()
            If dtY.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            With CRegAddress
                .DataSource = dtY
                .DisplayMember = "Հասցե"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadData3()
        Try

            Dim dtY As DataTable = iDB.GetRegion()
            If dtY.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            With cReg
                .DataSource = dtY
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "ՀՀ"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub Bulk_GPS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\ՀԴՄ APP", "LastGpsAddress", CRegAddress.Text)
    End Sub
    Private Sub Bulk_GPS_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
        Call LoadData2()
        Call LoadData3()

        On Error Resume Next
        If CRegAddress.Items.Count > 0 Then
            Dim s As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ՀԴՄ APP", "LastGpsAddress", "")

            If Not String.IsNullOrEmpty(s) Then
                CRegAddress.Text = s
            End If

        End If
    End Sub
    Private Sub CRegAddress_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CRegAddress.SelectedIndexChanged
        If Not String.IsNullOrEmpty(CRegAddress.Text) Then
            GridView1.ClearColumnsFilter()
            GridView1.Columns("Հասցե").FilterInfo = New ColumnFilterInfo("[Հասցե] = '" & CRegAddress.Text & "'")
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtLatitude.Text.Trim = String.Empty Then Throw New Exception("Latitude-ը նշված չէ")
            If txtLongitude.Text.Trim = String.Empty Then Throw New Exception("Longitude-ը նշված չէ")

            If GridView1.RowCount = 0 Then Throw New Exception("ՀԴՄ չկա")

            For i As Integer = 0 To GridView1.RowCount - 1
                iDB.AddGPSForEcr(GridView1.GetRowCellValue(i, "ՀԴՄ"), txtLatitude.Text.Trim, txtLongitude.Text.Trim)
            Next

            Call LoadData()

            CRegAddress_SelectedIndexChanged(CRegAddress, Nothing)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            txtLatitude.Text = String.Empty
            txtLongitude.Text = String.Empty

            btnNext.Focus()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            If CRegAddress.Items.Count > 0 Then
                If CRegAddress.SelectedIndex < CRegAddress.Items.Count Then
                    CRegAddress.SelectedIndex += 1
                    txtLatitude.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        If txtLatitude.Text.Trim.Length > 0 AndAlso txtLongitude.Text.Trim.Length > 0 Then
            Dim url As String = "https://www.google.com/maps/place/" & txtLatitude.Text.Trim & "," & txtLongitude.Text.Trim
            WebBrowser1.Navigate(url)
        End If
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim s As String = "[ " & cReg.Text & " ] " & cAdr.Text
            CRegAddress.SelectedIndex = CRegAddress.FindStringExact(s)
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub cReg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cReg.SelectedIndexChanged
        On Error Resume Next
        If TypeOf (cReg.SelectedValue) Is DataRowView Then Exit Sub

        Dim j As Integer = cReg.SelectedValue

        Dim dtx As DataTable = iDB.GorcAddrByRegion(j)
        If dtx.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

        With cAdr
            .DataSource = dtx
            .DisplayMember = "Հասցե"
            .AutoCompleteCustomSource.Clear()
            .AutoCompleteCustomSource.AddRange((From row In dtx.Rows.Cast(Of DataRow)() Select CStr(row("Հասցե"))).ToArray())
        End With

    End Sub

End Class