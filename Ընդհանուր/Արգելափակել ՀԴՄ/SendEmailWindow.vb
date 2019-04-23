Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils

Public Class SendEmailWindow

    Private iDuration As String = "00:00"

    Private Sub SendEmailWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub mnuExportToExcel_Click(sender As Object, e As EventArgs) Handles mnuExportToExcel.Click
        Try
            ExportTo(ExportType.Excel2013, Me)
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadData()
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable

            formX.Show() : My.Application.DoEvents()

            sTime = Now
            dt = iDB.ForSendMailList
            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Տեսուչ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Տեսուչ", "Քանակ {0}")
                    GridView1.Columns("Տեսուչ").Summary.Add(item)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Dim duration As TimeSpan = eTime - sTime
            iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub btnSent_Click(sender As Object, e As EventArgs) Handles btnSent.Click
        Dim formX As New Working
        Try
            If CheckPermission2("93FC9F4A05794DF8B85B1E3BB89978B1") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            GridView1.ClearColumnsFilter()
            GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)

            formX.Show() : My.Application.DoEvents()

            btnSent.Enabled = False

            Dim MySqlDbClient As New MySQLDB
            Dim SM As New MailSending

            For i As Integer = GridView1.RowCount - 1 To 0 Step -1
                Dim lItem = New With {.ՀՀ = GridView1.GetRowCellValue(i, "ID"),
                                      .Տեսուչ = GridView1.GetRowCellValue(i, "Տեսուչ"),
                                      .Փոստ = GridView1.GetRowCellValue(i, "Փոստ"),
                                      .Հաղորդագրություն = GridView1.GetRowCellValue(i, "Հաղորդագրություն"),
                                      .Կոդ = GridView1.GetRowCellValue(i, "GU_ID")}

                If MySqlDbClient.insertIntoMySql(lItem.Տեսուչ, lItem.Փոստ, lItem.Հաղորդագրություն, lItem.Կոդ) Then    'Insert Into MySql Database
                    If SM.sendMail(lItem.Կոդ) Then  'Send Mail
                        iDB.SendEmail(lItem.ՀՀ) 'insert Sent
                    End If
                End If
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            btnSent.Enabled = True
            formX.Close()
            formX = Nothing
            Call LoadData()
        End Try
    End Sub
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = Not GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ")
        Next
    End Sub
    Private Sub mnuSelect_Click(sender As Object, e As EventArgs) Handles mnuSelect.Click
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuSelectAll_Click(sender As Object, e As EventArgs) Handles mnuSelectAll.Click
        On Error Resume Next
        If GridView1.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.GetRow(i).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuDeselect_Click(sender As Object, e As EventArgs) Handles mnuDeselect.Click
        On Error Resume Next
        GridView1.ClearColumnsFilter()
        If GridView1.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.GetRow(i).Item("Նշիչ") = False
        Next
    End Sub
    Private Sub SendEmailWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
    End Sub
    Private Sub ՋնջելToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ՋնջելToolStripMenuItem.Click
        Dim formX As New Working
        Try
            If CheckPermission2("F4E37079D2D144B9BE8EFB8FA15AFCCF") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If Not MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then Exit Sub
            formX.Show() : My.Application.DoEvents()
            btnSent.Enabled = False

            Dim id As Integer
            Dim checked As Boolean

            For i As Integer = 0 To GridView1.RowCount - 1
                checked = GridView1.GetRowCellValue(i, "Նշիչ")

                If checked = True Then
                    id = GridView1.GetRowCellValue(i, "ID")

                    iDB.DeletePrepareMail(id)
                    My.Application.DoEvents()
                End If
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            btnSent.Enabled = True
            If Not IsNothing(formX) Then
                formX.Close()
                formX = Nothing
            End If
            Call LoadData()
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

End Class