Imports DevExpress.XtraGrid

Public Class ListOfWorkShopItems

    Friend ecr As String

    Friend isCenter As Boolean = False

    Dim RemakeID As Integer = -1
    Dim RTime As DateTime = DateTime.MinValue

    Private Sub Garant()
        Try
            Dim dt As DataTable = iDB.EcrStatusForRemake(ecr)

            If dt.Rows.Count > 0 Then
                txtGarant.Text = dt.Rows(0)("Երաշխիքային")

                If txtGarant.Text = "Երաշխիքային" Then
                    txtGarant.ForeColor = Color.Green
                Else
                    txtGarant.ForeColor = Color.Red
                End If
            Else
                Throw New Exception("Տվյալներ չեն ստացվել")
            End If

            Dim s As String = iDB.GetGarantForRemakeEcr(ecr)
            If s = "-" Then Exit Sub
            txtGarant.Text = s
            If txtGarant.Text = "Երաշխիքային" Then
                txtGarant.ForeColor = Color.Green
            Else
                txtGarant.ForeColor = Color.Red
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            txtGarant.Text = "ERROR"
            txtGarant.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub getRemake()
        Try

            RemakeID = iDB.RemakeIdByEcr(ecr)
            If RemakeID = -1 Then Throw New Exception("Վերանորոգումը չի ստացվել")

        Catch ex As Exception
            txtShtrikh.Enabled = False
            btnAdd.Enabled = False
            mnuDelete.Enabled = False
            mnuDeleteShtrikhCode.Enabled = False
        End Try
    End Sub
    Private Sub getRemakeTime()
        Try
            RTime = iDB.GetRemakeStartTimeByOperator(RemakeID, iUser.DB)
            TmTimer.Enabled = True
            TmTimer.Start()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadFunctional()
        Try
            Dim dt As DataTable = iDB.GetEcrFunctional(Ecr)
            If dt.Rows.Count = 1 Then
                cInvoice.Checked = dt.Rows(0)("Invoiceing")
                cPos.Checked = dt.Rows(0)("PosTerminal")
                cVTQ.Checked = dt.Rows(0)("VTQ")
                cShrjik.Checked = dt.Rows(0)("Shrjik")
            Else
                Throw New Exception("Ֆունկցիոնալ տվյալները չեն ստացվել")
            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub loadEquipment()
        Try
            Dim dt2 As DataTable = iDB.GetEquipmentListFiltered()
            With cbEquipment
                .DataSource = dt2
                .DisplayMember = "Սարքավորում"
                .ValueMember = "ՀՀ"
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
            Dim dt As DataTable

            dt = iDB.GetEquipmentRemakeWorkshop(ecr)

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ՀՀ").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadData2()
        Try
            Dim dt As DataTable

            dt = iDB.RemakeEquipmentDetails(ecr)

            GridControl3.BeginUpdate()
            GridControl3.DataSource = Nothing
            GridView3.Columns.Clear()

            GridControl3.DataSource = dt

            GridView3.ClearSelection()
            GridControl3.EndUpdate()

            With GridView3
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .Columns("Ամսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ListOfWorkShopItems_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtEcr.Text = ecr
        Call loadEquipment()
        Call LoadData()
        Call LoadData2()
        Call LoadFunctional()

        Call getRemake()
        Call getRemakeTime()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If CheckPermission2("B6B00A5BACC348E58FA197E5F299BF1C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            iDB.InsertWorkshopEquipment(ecr, cbEquipment.SelectedValue, isCenter)

            Call LoadData()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Try
            If CheckPermission2("E0499EBBC5C64B0FBD877CBC9E2902EC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            If MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            Dim id As Integer = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
            If Not IsDBNull(GridView1.GetFocusedDataRow.Item("ՇտրիխԿոդ")) Then

            Else
                iDB.DeleteWorkshopEquipment(id, RemakeID, isCenter)
            End If

            Call LoadData()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub txtShtrikh_TextChanged(sender As Object, e As EventArgs) Handles txtShtrikh.TextChanged
        Try
            If txtShtrikh.Text.Trim.Length <> 7 Then Exit Sub

            If iDB.IsEcrPaidForRemake(ecr, txtShtrikh.Text.Trim) = "True" Then
                If MsgBox("Տվյալ ՀԴՄ-ի վրա սահմանված ժամկետում այս սարքավորումը փոխարնիվում է երկրորդ անգամ,հետևաբար ծառայությունը կլինի ՎՃԱՐՈՎԻ: Կատարե՞լ գործարքը", MsgBoxStyle.Information + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub
            End If

            Dim isRemote As Boolean

            If GetIpAddress.StartsWith("192.168.22.") Then
                isRemote = True
            Else
                isRemote = False
            End If

            iDB.WorkshopEquipmentSell(txtShtrikh.Text.Trim, ecr, isRemote, isCenter)

            txtShtrikh.Text = String.Empty
            txtShtrikh.Focus()

        Catch ex As ExceptionClass
            txtShtrikh.Text = String.Empty
            txtShtrikh.Focus()
        Catch ex As System.Data.SqlClient.SqlException
            txtShtrikh.Text = String.Empty
            txtShtrikh.Focus()
            Call SQLException(ex)
        Catch ex As Exception
            txtShtrikh.Text = String.Empty
            txtShtrikh.Focus()
            Call SoftException(ex)
        Finally
            LoadData()
        End Try
    End Sub
    Private Sub mnuDeleteShtrikhCode_Click(sender As Object, e As EventArgs) Handles mnuDeleteShtrikhCode.Click
        Try
            If CheckPermission2("E0499EBBC5C64B0FBD877CBC9E2902EC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.RowCount = 0 Then Exit Sub

            If MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            Dim f As New RemoveEquipmentFromWorkshop With {.RemakeID = RemakeID, .isCenter = isCenter}
            f.ShowDialog()
            f.Dispose()

            Call LoadData()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ListOfWorkShopItems_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckPermission2("B6B00A5BACC348E58FA197E5F299BF1C") = False Then txtShtrikh.Enabled = False
        Call Garant()
        btnRefresh.PerformClick()
    End Sub
    Private Sub btnAddEzrakac_Click(sender As Object, e As EventArgs) Handles btnAddEzrakac.Click
        Try
            If txtEzrakac.Text.Trim = String.Empty Then Throw New Exception("Եզրակացությունը գրված չէ")

            iDB.UPDATEInference(txtEzrakac.Text.Trim, RemakeID)

            txtEzrakac.Text = String.Empty

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            Dim curCount As Integer = 0
            Dim oldCount As Integer = 0

            If iUser.DB = 1 OrElse iUser.DB = 3 Then
                curCount = iDB.RemakeSrahEcrCurBranch()
                oldCount = iDB.RemakeSrahEcrOldBranch()
            Else
                curCount = iDB.RemakeSrahEcrCur()
                oldCount = iDB.RemakeSrahEcrOld()
            End If

            txtEcrCurCount.Text = curCount
            txtEcrOldCount.Text = oldCount

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub TmTimer_Tick(sender As Object, e As EventArgs) Handles TmTimer.Tick
        On Error Resume Next
        Dim timePeriod As TimeSpan
        timePeriod = Now - RTime

        If timePeriod.Days > 0 Then
            txtTimer.Text = timePeriod.Days & " Օր " & timePeriod.Hours.ToString("00") & ":" & timePeriod.Minutes.ToString("00") & ":" & timePeriod.Seconds.ToString("00")
        Else
            txtTimer.Text = timePeriod.Hours.ToString("00") & ":" & timePeriod.Minutes.ToString("00") & ":" & timePeriod.Seconds.ToString("00")
        End If
    End Sub

    Private Sub mnuMessage_Click(sender As Object, e As EventArgs) Handles mnuMessage.Click
        Dim f As New EcrMessageWindow With {.Ecr = txtEcr.Text.Trim}
        f.ShowDialog()
        f.Dispose()
    End Sub

End Class