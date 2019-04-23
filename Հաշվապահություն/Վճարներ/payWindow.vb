Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class payWindow

    Private iDuration As String = "00:00"

    Dim dtHvhh As DataTable

    Private Sub LoadDT()
        On Error Resume Next
        dtHvhh = iDB.AutoCompleteHvhh()
        txtHvhh.AutoCompleteCustomSource.Clear()
        txtHvhh.AutoCompleteCustomSource.AddRange((From row In dtHvhh.Rows.Cast(Of DataRow)() Select CStr(row("ՀՎՀՀ"))).ToArray())
    End Sub

    Friend Sub UpdateRecords()
        Try
            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
            Dim PayType As String = GridView1.GetFocusedDataRow.Item("PayType")
            If PayType <> "c" AndAlso PayType <> "b" Then Throw New Exception("Ընթացիկ վճարը չի կարող փոփոխվել")

            Dim ID As Integer = GridView1.GetFocusedDataRow.Item("PaymentID")
            Dim payAmount As Decimal = GridView1.GetFocusedDataRow.Item("Վճար")
            Dim payDate As Date = GridView1.GetFocusedDataRow.Item("ՎճարմանԱմսաթիվ")
            Dim f As New ChangePaymentWin
            With f
                .PaymentID = ID
                .txtAmount.Text = payAmount
                .dePayDay.DateTime = payDate
                .ShowDialog()
                .Dispose()
            End With
            Call Query()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Friend Sub DeleteRecord()
        Try
            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

            Dim PayType As String = GridView1.GetFocusedDataRow.Item("PayType")
            If PayType <> "c" AndAlso PayType <> "b" Then Throw New Exception("Ընթացիկ վճարը չի կարող ջնջվել")

            Dim ID As Integer = GridView1.GetFocusedDataRow.Item("PaymentID").ToString
            Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
            If q = MsgBoxResult.Yes Then
                iDB.DeletePayment(ID, iUser.LoginName)
                MsgBox("Գրանցումը հաջողությամբ ջնջվեց", MsgBoxStyle.Information, My.Application.Info.Title)
                Call Query()
            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Friend Sub Query()
        Dim sTime As DateTime
        Dim eTime As DateTime

        Try
            If txtHvhh.Text.Trim = String.Empty Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")

            GridView1.ActiveFilter.Clear()
            GridControl1.DataSource = Nothing

            Dim dt As DataTable

            sTime = Now
            dt = iDB.GetPaymentsByHvhh(txtHvhh.Text.Trim)

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("PaymentID").Visible = False
                .Columns("PayType").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("ՎճարմանԱմսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .Columns("Վճար").DisplayFormat.FormatType = FormatType.Numeric
                .Columns("Վճար").DisplayFormat.FormatString = "n2"
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՎճարմանԱմսաթիվ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՎճարմանԱմսաթիվ", "Քանակ {0}")
                    GridView1.Columns("ՎճարմանԱմսաթիվ").Summary.Add(item)
                End If
                If GridView1.Columns("Վճար").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Վճար", "Գումար {0:n2}")
                    GridView1.Columns("Վճար").Summary.Add(item)
                End If
            End If

            Dim dt2 As DataTable = iDB.GetPaymentInfoByHvhh(txtHvhh.Text.Trim)
            eTime = Now

            If dt2.Rows.Count = 1 Then
                txtSupporter.Text = dt2.Rows(0)("Սպասարկող")
                txtClient.Text = dt2.Rows(0)("Կազմակերպություն")
                txtHts.Text = dt2.Rows(0)("ՀծԿող")
            Else
                txtSupporter.Text = String.Empty
                txtClient.Text = String.Empty
                txtHts.Text = String.Empty
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
        End Try
    End Sub
    Private Sub ClearInfo()
        txtSupporter.Text = String.Empty
        txtClient.Text = String.Empty
        txtHts.Text = String.Empty
        GridView1.ActiveFilter.Clear()
        GridControl1.DataSource = Nothing
    End Sub

    Private Sub loadSupporter()
        Try
            Dim dt As DataTable = iDB.GetSupporter()
            With cbSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                .Text = "Անորոշ"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub payWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub

    'Export Records
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

    Private Sub payWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        cbPayType.SelectedIndex = 0
        With dePayDay
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With
        Call loadSupporter()
        dePayDay.Properties.MaxValue = Now
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If CheckPermission2("E3C6493985154010B9B22664C5DDCC60") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If txtAmount.Text < 0 Then Throw New Exception("Գումարը պետք է բացասական չլինի")

            Dim pType As Char
            If cbPayType.SelectedIndex = 0 Then
                pType = "b"
            Else
                pType = "c"
            End If

            Dim iPay = New With {.hvhh = txtHvhh.Text.Trim, .Payment = txtAmount.Text, .PayDate = dePayDay.DateTime, .PayType = pType, .SupporterID = cbSupporter.SelectedValue}

            iDB.InsertPayment(iPay.hvhh, iPay.Payment, iPay.PayDate, iPay.PayType, iPay.SupporterID)

            Call Query()

            txtAmount.Text = 0.0

            txtHvhh.Focus()
            txtHvhh.SelectionStart = 0
            txtHvhh.SelectionLength = txtHvhh.Text.Length

            Clipboard.SetText(txtHts.Text)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuChangeAmount_Click(sender As Object, e As EventArgs) Handles mnuChangeAmount.Click
        If CheckPermission2("DAB774F5E329481F981A4169F89900D9") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Call UpdateRecords()
    End Sub
    Private Sub mnuDeleteAmount_Click(sender As Object, e As EventArgs) Handles mnuDeleteAmount.Click
        If CheckPermission2("8285899D39754AB7AA134D4DB0A6FDEA") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Call DeleteRecord()
    End Sub
    Private Sub txtAmount_GotFocus(sender As Object, e As EventArgs) Handles txtAmount.GotFocus
        txtAmount.SelectionStart = 0
        txtAmount.SelectionLength = txtAmount.Text.Length
    End Sub
    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim PayType As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՎճարմանՁև"))
            If PayType <> "Կանխիկ" AndAlso PayType <> "Բանկ" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub
    Private Sub mnuAccseptPayment_Click(sender As Object, e As EventArgs) Handles mnuAccseptPayment.Click
        Try
            If CheckPermission2("33AED93AB8D943858BEAB6EAC502E683") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

            Dim PayType As String = GridView1.GetFocusedDataRow.Item("PayType")
            If PayType = "c" OrElse PayType = "b" Then Throw New Exception("Ընթացիկ վճարը չի կարող հաստատվել")

            Dim ID As Integer = GridView1.GetFocusedDataRow.Item("PaymentID")
            iDB.UpdateAccseptPayment(ID)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Call Query()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub cbSupporter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSupporter.SelectedIndexChanged
        On Error Resume Next
        If txtSupporter.Text <> cbSupporter.Text Then
            txtSupporter.ForeColor = Color.Red
        Else
            txtSupporter.ForeColor = Color.Green
        End If
    End Sub
    Private Sub payWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadDT()
    End Sub

    Private Sub txtHvhh_TextChanged(sender As Object, e As EventArgs) Handles txtHvhh.TextChanged
        On Error Resume Next
        If txtHvhh.Text.Trim.Length = 8 Then Call Query() : cbSupporter_SelectedIndexChanged(cbSupporter, Nothing) Else ClearInfo()
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