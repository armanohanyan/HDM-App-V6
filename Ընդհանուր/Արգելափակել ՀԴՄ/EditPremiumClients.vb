Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class EditPremiumClients

    Private iDuration As String = "00:00"

    Dim NotSupportedClients As New DataTable

    Private Sub loadNotSupportedClients()
        On Error Resume Next
        NotSupportedClients = iDB.GetNotServedClients()
    End Sub
    Private Sub LoadData()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            Dim dt As DataTable

            sTime = Now

            If iUser.DB = 5 Then
                dt = iDB.ListOfPremiums()
            Else
                dt = iDB.ListOfPremiums2(iUser.DB)
            End If

            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            'GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ՀՀ").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .BestFitColumns(True)

            End With

            Dim columnN As Integer = 0
            For Each column As DevExpress.XtraGrid.Columns.GridColumn In GridView1.Columns
                GridView1.Columns(columnN).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                columnN = columnN + 1
            Next

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "Քանակ {0}")
                    GridView1.Columns("Կազմակերպություն").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
            Dim duration As TimeSpan = eTime - sTime
            iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
        End Try
    End Sub
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            If CheckPermission2("697990D05D50418FAC9F1ACE37E53861") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If String.IsNullOrEmpty(txtHVHH.Text) Then Exit Sub

            Dim client As String = txtHVHH.Text.Trim

            'UnCheck Not Supported
            If NotSupportedClients.Rows.Count > 0 Then
                For j As Integer = 0 To NotSupportedClients.Rows.Count - 1
                    If client = NotSupportedClients.Rows(j)("HVHH") Then
                        Throw New Exception("Գործընկերը արգելափակված է")
                    End If
                Next
            End If

            If iUser.DB = 5 Then
                iDB.InsertPremiumClient(client, iUser.UserID)
            Else
                iDB.InsertPremiumClient2(client, iUser.UserID, iUser.DB)
            End If

            txtHVHH.Text = String.Empty
            txtHVHH.Focus()

            Call LoadData()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnBulkInsert_Click(sender As Object, e As EventArgs) Handles btnBulkInsert.Click
        Try
            If CheckPermission2("697990D05D50418FAC9F1ACE37E53861") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim client As String = String.Empty

            Dim vip1200hdm2 As Boolean = cb12002.Checked
            Dim vop1200hdmShat As Boolean = cb12003.Checked
            Dim vip3000 As Boolean = cb3000.Checked
            Dim vip3000Paid As Boolean = cb3000Paid.Checked
            Dim vip3600 As Boolean = cb3600.Checked

            'If cb12002.Checked Then client += "1200"
            'If cb3000.Checked Then client += "3000"
            'If cb3000Paid.Checked Then client += "3000Paid"
            'If cb3600.Checked Then client += "3600"

            'If String.IsNullOrEmpty(client) Then Exit Sub

            If iUser.DB = 5 Then
                'MsgBox(client)
                iDB.BulkInsertPremiumClient(vip1200hdm2, vop1200hdmShat, vip3000, vip3000Paid, vip3600, iUser.UserID)
            Else
                iDB.InsertPremiumClient2(client, iUser.UserID, iUser.DB)
            End If

            'txtHVHH.Text = String.Empty
            'txtHVHH.Focus()

            Call LoadData()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnBulkDelete_Click(sender As Object, e As EventArgs) Handles btnBulkDelete.Click
        Try
            If CheckPermission2("807CDBD2B1144B24B184A68DCEEC1C6E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")


            Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
            If q = MsgBoxResult.Yes Then
                iDB.DeletePremiumClientBulk(iUser.UserID)
                MsgBox("Գրանցումը հաջողությամբ ջնջվեց", MsgBoxStyle.Information, My.Application.Info.Title)
                Call LoadData()
            End If


        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub EditPremiumClients_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub EditPremiumClients_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
    End Sub
    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Try
            If CheckPermission2("807CDBD2B1144B24B184A68DCEEC1C6E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
            Dim recID As Short = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
            Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
            If q = MsgBoxResult.Yes Then
                iDB.DeletePremium(recID, iUser.UserID)
                MsgBox("Գրանցումը հաջողությամբ ջնջվեց", MsgBoxStyle.Information, My.Application.Info.Title)
                Call LoadData()
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuDeleteBulk_Click(sender As Object, e As EventArgs) Handles mnuDeleteBulk.Click
        Try
            If CheckPermission2("807CDBD2B1144B24B184A68DCEEC1C6E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
            Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք ջնջել նշված տողերը։", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
            If q = MsgBoxResult.Yes Then

                For Each rowHandle As Integer In GridView1.GetSelectedRows
                    Dim recID As Integer = GridView1.GetRowCellValue(rowHandle, "ՀՀ").ToString
                    iDB.DeletePremium(recID, iUser.UserID)
                Next

                MsgBox("Նշված գրանցումները հաջողությամբ ջնջվեցին։", MsgBoxStyle.Information, My.Application.Info.Title)
                Call LoadData()
            End If

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
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
    Private Sub EditPremiumClients_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call loadNotSupportedClients()
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


    Private Sub cb1200_CheckedChanged(sender As Object, e As EventArgs) Handles cb12002.CheckedChanged

    End Sub
End Class