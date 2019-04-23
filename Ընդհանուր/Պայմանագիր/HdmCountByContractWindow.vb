Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class HdmCountByContractWindow

    Friend hvhh As String
    Friend hvhhID As Integer
    Friend compName As String
    Friend Contract As String

    Private iDuration As String = "00:00"

    Private Sub LoadData()
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable

            sTime = Now
            dt = iDB.ClientHdmCount(hvhhID)
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
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .ClearSorting()
                .OptionsCustomization.AllowSort = True
                .OptionsCustomization.AllowFilter = False
                .Columns("Տարի").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .Columns("Ամիս").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .OptionsCustomization.AllowSort = False
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀավելվածՔանակ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀավելվածՔանակ", "Քանակ {0}")
                    GridView1.Columns("ՀավելվածՔանակ").Summary.Add(item)
                End If

                txtHDMCount.Text = dt.Rows(0)("ՀդմՔանակ") + dt.Rows(0)("ՀավելվածՔանակ")
                txtHDMCount.Enabled = False
            End If

            Dim lDate As Date = DateAdd(DateInterval.Month, -1, Now.Date)

            cbYear.Items.Clear()
            If lDate.Year <> Now.Year Then cbYear.Items.Add(lDate.Year)
            cbYear.Items.Add(Now.Year)
            cbYear.SelectedItem = Now.Year
            cbMonth.Items.Clear()
            cbMonth.Items.Add(lDate.Month)
            cbMonth.Items.Add(Now.Month)
            cbMonth.SelectedItem = Now.Month

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Dim duration As TimeSpan = eTime - sTime
            iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
        End Try
    End Sub
    Private Sub HdmCountByContractWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub HdmCountByContractWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtHVHH.Text = hvhh
        txtCompany.Text = compName
        Call LoadData()
    End Sub
    Private Sub TextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHDMCount.KeyPress, txtHavelvac.KeyPress
        On Error Resume Next
        If Not (e.KeyChar = "-") AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If CheckPermission2("44A3B1E03A414AEF91DFA84DCDEB350B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.RowCount > 0 Then
                If GridView1.GetRowCellValue(0, "Տարի").ToString = cbYear.SelectedItem AndAlso GridView1.GetRowCellValue(0, "Ամիս").ToString = cbMonth.SelectedItem Then
                    Throw New Exception("Տվյալ ամսվա համար տվյալ կա, դուք կարող եք միայն փոփոխել տվյալները")
                End If

                Dim date1 As Date = New Date(cbYear.SelectedItem, cbMonth.SelectedItem, 1)
                Dim date2 As Date = New Date(GridView1.GetRowCellValue(0, "Տարի").ToString, GridView1.GetRowCellValue(0, "Ամիս").ToString, 1)
                If date1 < date2 Then Throw New Exception("Հետին թվով ինֆորմացիա չի կարող մուտքագրվել")
            End If

            If hvhhID = 0 Then Throw New Exception("ՀՎՀՀ-ն բացակայում է")

            If String.IsNullOrEmpty(txtHVHH.Text) OrElse String.IsNullOrEmpty(txtHavelvac.Text) Then Throw New Exception("Տվյալները ամբողջությամբ լրացված չեն")
            If GridView1.RowCount = 0 Then If txtContract.Text.Trim <> Contract Then Throw New Exception("Պայմանագիրը չի համընկնում")

            If txtHavelvac.Text < 0 Then
                If Math.Abs(CInt(txtHavelvac.Text)) > CInt(txtHDMCount.Text) Then Throw New Exception("հանվող ապարատների քանակը ավելի է քան ներկայումս առկա է")
            End If

            iDB.InsertContractCount(hvhhID, cbYear.SelectedItem, cbMonth.SelectedItem, txtHDMCount.Text.Trim, txtHavelvac.Text.Trim, txtContract.Text.Trim)

            MsgBox("Տվյալները ավելացվեցին", MsgBoxStyle.Information, My.Application.Info.Title)

            txtContract.Text = String.Empty
            txtHavelvac.Text = String.Empty

            HdmCountByContractWindow_Load(Me, Nothing)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Try
            If CheckPermission2("06B7FDDD731849B9905F0056697C4EC5") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.RowCount = 0 Then Exit Sub
            If Not MsgBox("Ցանկանու՞մ եք ջնջել բոլոր տվյալները", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, My.Application.Info.Title).Equals(MsgBoxResult.Yes) Then Exit Sub

            iDB.DeleteContractCount(hvhhID)

            MsgBox("Տվյալները ջնջվեցին", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuChange_Click(sender As Object, e As EventArgs) Handles mnuChange.Click
        If CheckPermission2("3EDFD0242A1149FB92066739FAB9CC6F") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        Dim Inf = New With {.ID = GridView1.GetFocusedDataRow.Item("ID").ToString, .Count = GridView1.GetFocusedDataRow.Item("ՀավելվածՔանակ").ToString, .year = cbYear.SelectedItem, .month = cbMonth.SelectedItem}
        Dim f As New AppNewCountWindow
        With f
            .RecID = Inf.ID
            .CCount = Inf.Count
            .ClientID = hvhhID
            .ShowDialog()
            .Dispose()
        End With
        HdmCountByContractWindow_Load(Me, Nothing)
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