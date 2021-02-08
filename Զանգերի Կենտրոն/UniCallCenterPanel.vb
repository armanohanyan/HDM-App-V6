Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Data

Public Class UniCallCenterPanel

    Friend Phrase As String
    Friend isHvhh As Boolean

    Dim sHvhh As String = String.Empty
    Dim sClientID As Integer = 0

    Dim f1_win As New CallHaytActivate
    Dim f2_win As New CallHaytGeneral

    Private Function Garant() As String
        Try
            Dim dt As DataTable = iDB.EcrStatusForRemake(Phrase)
            Dim val As String

            If dt.Rows.Count > 0 Then
                val = dt.Rows(0)("Երաշխիքային")
            Else
                val = "Տվյալներ չեն ստացվել"
            End If

            Dim s As String = iDB.GetGarantForRemakeEcr(Phrase)
            If s = "-" Then Return val
            Return val & " (" & s & ")"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Return "ERROR"
        End Try
    End Function
    Private Function loadReplaced() As String
        Dim s As String = String.Empty
        Try
            s = iDB.GetReplacedECRByRemake(Phrase)
            If String.IsNullOrEmpty(s) Then
                s = "Փոխարինված չկա"
            End If

            Return s
        Catch ex As ExceptionClass
            Return s
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            Return s
        Catch ex As Exception
            Call SoftException(ex)
            Return s
        End Try
    End Function
    Private Sub LoadPayment()
        On Error Resume Next

        Dim dt As DataTable = iDB.CallCenterPayDetails(sClientID)

        GridControl3.BeginUpdate()
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

            .OptionsView.AllowCellMerge = False
            .OptionsSelection.MultiSelect = False
            .OptionsSelection.EnableAppearanceFocusedCell = False

            .OptionsView.ColumnAutoWidth = True

            '.Columns("Սպասարկող").SortOrder = DevExpress.Data.ColumnSortOrder.Descending

        End With

        GridView3.ClearSelection()
        GridControl3.EndUpdate()
    End Sub
    Private Sub SetHaytWindow()
        On Error Resume Next

        f1_win.TopLevel = False
        XtraTabPage2.Controls.Add(f1_win)
        f1_win.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f1_win.Dock = DockStyle.Fill
        f1_win.Show()

        f2_win.TopLevel = False
        XtraTabPage1.Controls.Add(f2_win)
        f2_win.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f2_win.Dock = DockStyle.Fill
        f2_win.Show()

    End Sub
    Private Sub LoadData()
        Try
            Dim dt As DataTable
            Dim inf As New List(Of infX)

            If isHvhh = True Then
                dt = iDB.UniCallCenterByHvhh(iUser.DB, Phrase)
                If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չեն ստացվել")

                With inf
                    .Add(New infX("Հուսալիություն", dt.Rows(0)("Per") & "  %"))
                End With

                lcompany.Text = dt.Rows(0)("Client")
                If lcompany.Text.StartsWith("(Չսպասարկվող)") Then lcompany.ForeColor = Color.Red
                If lcompany.Text.StartsWith("(Չսպ/Լուծարվ.") Then lcompany.ForeColor = Color.Red
                If lcompany.Text.StartsWith("(Լուծարված)") Then lcompany.ForeColor = Color.Red
                If lcompany.Text.StartsWith("(Այլ սպասարկող)") Then lcompany.ForeColor = Color.Red
                lhvhh.Text = "ՀՎՀՀ " & dt.Rows(0)("hvhh")
                sHvhh = dt.Rows(0)("hvhh")
                sClientID = dt.Rows(0)("ClientID")
                lEcr.Text = ""
                tec.Text = dt.Rows(0)("LocalEcrCount") & " (Պոակ " & dt.Rows(0)("PoakEcrCount") & ")"
                tdc.Text = dt.Rows(0)("disableEcrCount")
                trc.Text = dt.Rows(0)("RemakeEcrCount")
                lPart.Visible = Not dt.Rows(0)("IsClientExists")
                trepco.Text = dt.Rows(0)("RepEcr")
                ttar.Text = dt.Rows(0)("Tarif")
                tsms.Text = dt.Rows(0)("sms_qty")
                tTes.Text = dt.Rows(0)("tVisit")

            Else
                dt = iDB.UniCallCenterByEcr(iUser.DB, Phrase)
                If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չեն ստացվել")

                With inf
                    .Add(New infX("Հուսալիություն", dt.Rows(0)("Per") & "  %"))
                    .Add(New infX("GPRS Կարգավիճակ", dt.Rows(0)("ST")))
                    .Add(New infX("GPRS/IP", dt.Rows(0)("GPRS") & " / " & dt.Rows(0)("IP")))
                    .Add(New infX("ՊՈԱԿ Կարգավիճակ", dt.Rows(0)("PS")))
                    .Add(New infX("Երաշխ Կարգավիճակ", Garant()))
                    .Add(New infX("Փոխարինող", loadReplaced))
                    .Add(New infX("POS", dt.Rows(0)("POS")))
                    .Add(New infX("Վերագրանցված", dt.Rows(0)("reRegisteredCount")))
                End With

                lcompany.Text = dt.Rows(0)("Client")
                If lcompany.Text.StartsWith("(Չսպասարկվող)") Then lcompany.ForeColor = Color.Red
                If lcompany.Text.StartsWith("(Չսպ/Լուծարվ.") Then lcompany.ForeColor = Color.Red
                If lcompany.Text.StartsWith("(Լուծարված)") Then lcompany.ForeColor = Color.Red
                If lcompany.Text.StartsWith("(Այլ սպասարկող)") Then lcompany.ForeColor = Color.Red
                lhvhh.Text = "ՀՎՀՀ " & dt.Rows(0)("hvhh")
                sHvhh = dt.Rows(0)("hvhh")
                sClientID = dt.Rows(0)("ClientID")
                'If dt.Rows(0)("isEcrReplaced") = "Փոխ. " Then lEcr.ForeColor = Color.Red
                lEcr.Text = dt.Rows(0)("isEcrReplaced") & "ՀԴՄ " & Phrase
                'If lEcr.Text.StartsWith("Փոխ") Then lEcr.ForeColor = Color.Red
                tec.Text = dt.Rows(0)("LocalEcrCount") & " (Պոակ " & dt.Rows(0)("PoakEcrCount") & ")"
                tdc.Text = dt.Rows(0)("disableEcrCount")
                trc.Text = dt.Rows(0)("RemakeEcrCount")
                lPart.Visible = Not dt.Rows(0)("IsClientExists")
                trepco.Text = dt.Rows(0)("RepEcr")
                ttar.Text = dt.Rows(0)("Tarif")
                tsms.Text = dt.Rows(0)("sms_qty")
                tTes.Text = dt.Rows(0)("tVisit")

            End If

            Call LoadPayment()

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()
            GridControl1.DataSource = ToDataTable(inf)
            GridView1.ClearSelection()
            GridControl1.EndUpdate()
            With GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsView.ColumnAutoWidth = True
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
    Private Sub GridView3_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView3.RowCellStyle
        On Error Resume Next

        Dim View As GridView = sender
        If e.Column.FieldName = "Վճար" Then
            Dim val As Decimal = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Վճար"))
            If val < 0 Then
                e.Appearance.BackColor = Color.FromArgb(255, 229, 229)
                e.Appearance.BackColor2 = Color.FromArgb(242, 242, 242)
            End If
        End If

    End Sub
    Private Sub UniCallCenterPanel_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
        Call SetHaytWindow()
        If isHvhh = True Then
            lhvhh.Font = New Font(lhvhh.Font, FontStyle.Bold)
            lhvhh.ForeColor = Color.Blue
        Else
            If lEcr.Text.StartsWith("Փոխ") Then
                lEcr.Font = New Font(lEcr.Font, FontStyle.Bold)
                lEcr.ForeColor = Color.Red
            Else
                lEcr.Font = New Font(lEcr.Font, FontStyle.Bold)
                lEcr.ForeColor = Color.Blue
            End If
        End If
        If isHvhh = False Then RepEcr.Enabled = True
    End Sub
    Private Sub btnEcrCount_Click(sender As Object, e As EventArgs) Handles btnEcrCount.Click
        If CheckPermission2("6F0FFD8B46824D4D86E4DF9077A5C815") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If String.IsNullOrEmpty(sHvhh) Then MsgBox("ՀՎՀՀ-ն հայտնի չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Call CloseWindow("nHDMSearch")
        Dim f As New SearchHDMOnly
        f.txtPhrase.Text = sHvhh
        f.rbHVHH.Checked = True
        AddChildForm("nHDMSearch", f)
        f.btnQuery.PerformClick()

    End Sub
    Private Sub btnDisCount_Click(sender As Object, e As EventArgs) Handles btnDisCount.Click
        If CheckPermission2("A6DAD61B2BB24175BE74FF6D7D5697B4") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If sClientID <= 0 Then MsgBox("Գործընկերը բազայում բացակայում է", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Call CloseWindow("nBlockedHDMGprs")
        Dim f As New BlockedGPRS
        f.iClientID = sClientID
        AddChildForm("nBlockedHDMGprs", f)

    End Sub
    Private Sub btnRemake_Click(sender As Object, e As EventArgs) Handles btnRemake.Click
        If CheckPermission2("C00331E232734333BD1F2CE650B08998") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If sClientID <= 0 Then MsgBox("Գործընկերը բազայում բացակայում է", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Call CloseWindow("nGetRemakeHDMByCompany")
        Dim f As New RemakeHDMByCompanyWin With {.FromCallCenter = True}
        f.iClientID = sClientID
        AddChildForm("nGetRemakeHDMByCompany", f)

    End Sub
    Private Sub btnRepEcr_Click(sender As Object, e As EventArgs) Handles btnRepEcr.Click
        If CheckPermission2("BF69F42B4E464AACB129203B4EF59B9F") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If sClientID <= 0 Then MsgBox("Գործընկերը բազայում բացակայում է", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Call CloseWindow("nReplacedHDMByCompany")
        Dim f As New ReplacedHdmWin
        f.iClientID = sClientID
        AddChildForm("nReplacedHDMByCompany", f)

        Dim view As GridView = TryCast(f.GridView1, GridView)
        view.ActiveFilter.Add(view.Columns("Ընդունող"), New ColumnFilterInfo("IsNullOrEmpty([Ընդունող])", ""))

    End Sub
    Private Sub btnTarif_Click(sender As Object, e As EventArgs) Handles btnTarif.Click
        If CheckPermission("AB0E3EB722B948D8AB84F1F32E42C960") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

        If sClientID <= 0 Then MsgBox("Գործընկերը բազայում բացակայում է", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Call CloseWindow("nTarifHistoryWindow")
        Dim f As New TarifHistoryWindow With {.FromCallCenter = True, .ClientID = sClientID}
        AddChildForm("nTarifHistoryWindow", f)

    End Sub
    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        On Error Resume Next
        If GridView3.RowCount = 0 Then Exit Sub

        If CheckPermission2("1028600DD2514347BA35F4D7BCA174E4") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If sClientID <= 0 Then MsgBox("Գործընկերը բազայում բացակայում է", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Dim f As New PaymentHistoryWin With {.IClientID = sClientID}
        With f
            .Text = "ՀՎՀՀ՝ " & sHvhh
            .ShowDialog()
            .Dispose()
        End With

    End Sub
    Private Sub btnEnSim_Click(sender As Object, e As EventArgs) Handles btnEnSim.Click

        If CheckPermission("2B6BAE83388B4C8AAC3FA07C0ABC5416") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

        Dim hvhh As String = lhvhh.Text.Substring(lhvhh.Text.Length - 9).Trim

        If iDB.IsClientNotSuported(hvhh) = True Then
            iDB.ActivateClient(hvhh, iUser.LoginName)
        End If

        Call CloseWindow("nEnableSIMByHVHH")
        Dim f As New enagleSIMByHvhhWindow With {.simHVHH = hvhh}
        AddChildForm("nEnableSIMByHVHH", f)

    End Sub
    Private Sub btnSMS_Click(sender As Object, e As EventArgs) Handles btnSMS.Click
        If sClientID <= 0 Then MsgBox("Գործընկերը բազայում բացակայում է", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Call CloseWindow("nSMSPervCallCenter")
        Dim f As New SMSPervCallCenter With {.ClientID = sClientID, .IsFiltered = True}
        AddChildForm("nSMSPervCallCenter", f)

    End Sub
    Private Sub btnAct_Click(sender As Object, e As EventArgs) Handles btnAct.Click

        XtraTabPage1.PageEnabled = True
        XtraTabPage2.PageEnabled = True

        'XtraTabPage1.PageEnabled = False

        If isHvhh = True Then

            XtraTabControl1.SelectedTabPage = XtraTabPage2

            f1_win.txtHVHH.Text = Phrase
            f1_win.bhvhh.PerformClick()
        Else

            XtraTabControl1.SelectedTabPage = XtraTabPage2

            f1_win.txtEcr.Text = Phrase
            f1_win.bEcr.PerformClick()
        End If
    End Sub
    Private Sub btnGen_Click(sender As Object, e As EventArgs) Handles btnGen.Click

        XtraTabPage2.PageEnabled = True

        'XtraTabPage2.PageEnabled = False
        XtraTabPage1.PageEnabled = True

        If isHvhh = True Then

            XtraTabControl1.SelectedTabPage = XtraTabPage1

            f2_win.txtHVHH.Text = Phrase
            f2_win.bhvhh.PerformClick()
        Else

            XtraTabControl1.SelectedTabPage = XtraTabPage1

            f2_win.txtEcr.Text = Phrase
            f2_win.bEcr.PerformClick()
        End If

    End Sub
    Private Sub btnTesuch_Click(sender As Object, e As EventArgs) Handles btnTesuch.Click
        If sClientID <= 0 Then MsgBox("Գործընկերը բազայում բացակայում է", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        Try

            Dim dt As DataTable = iDB.RepCallCenterVisits(sClientID)

            Call CloseWindow("nRepTesuch")
            Dim f As New RepTesuch

            f.GridControl1.BeginUpdate()
            f.GridView1.Columns.Clear()
            f.GridControl1.DataSource = dt
            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()
            With f.GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsView.ColumnAutoWidth = True
            End With
            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            AddChildForm("nRepTesuch", f)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub lEcr_Click(sender As Object, e As EventArgs) Handles lEcr.Click
        If isHvhh = True Then

        Else
            'Call CloseWindow("nHDMSearch")
            'Dim f As New SearchHDMOnly
            'f.txtPhrase.Text = Phrase
            'AddChildForm("nHDMSearch", f)
            'f.btnQuery.PerformClick()

            Dim Ecr As String = Phrase
            Dim EcrID As Integer = iDB.GetEcrID(Ecr)

            Dim f As New RemakeHistoryByHDMWin With {.iEcr = EcrID, .Ecr = Ecr}
            With f
                .ShowDialog()
                .Dispose()
            End With

        End If

    End Sub
    Private Sub lhvhh_Click(sender As Object, e As EventArgs) Handles lhvhh.Click
        If isHvhh = True Then
            Call CloseWindow("nSearchClient")
            Dim f As New SearchHVHH
            f.txtPhrase.Text = Phrase
            AddChildForm("nSearchClient", f)
            f.btnQuery.PerformClick()
        Else
            Call CloseWindow("nSearchClient")
            Dim f As New SearchHVHH
            f.txtPhrase.Text = sHvhh
            AddChildForm("nSearchClient", f)
            f.btnQuery.PerformClick()
        End If
    End Sub
    Private Sub RepEcr_Click(sender As Object, e As EventArgs) Handles RepEcr.Click
        Try
            iDB.CheckClientEcr(Phrase, iUser.LoginName)

            Dim f As New CallEcrForReplace With {.ClientEcr = Phrase}
            f.ShowDialog()
            f.Dispose()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try

    End Sub
    Private Sub btnSupPay_Click(sender As Object, e As EventArgs) Handles btnSupPay.Click
        Try
            If iUser.DB = 5 Then Throw New Exception("Դուք Չեք կարող կատարել գործողությունը")

            Call CloseWindow("nCCPayWin")
            Dim f As New CCPayWin

            Dim dt As DataTable

            If isHvhh = True Then
                dt = iDB.PartqBySupporter4(Phrase, iUser.DB)
            Else
                dt = iDB.PartqBySupporter4(sHvhh, iUser.DB)
            End If

            With f
                .GridControl1.BeginUpdate()
                .GridControl1.DataSource = Nothing
                .GridView1.Columns.Clear()

                .GridControl1.DataSource = dt

                .GridView1.ClearSelection()
                .GridControl1.EndUpdate()

                With f.GridView1
                    .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    .OptionsBehavior.Editable = False
                    .OptionsBehavior.ReadOnly = True
                    .OptionsCustomization.AllowColumnMoving = False
                    .OptionsCustomization.AllowGroup = False

                    .OptionsView.AllowCellMerge = False
                    .OptionsSelection.MultiSelect = False
                    .OptionsSelection.EnableAppearanceFocusedCell = False

                    .Columns("Գումար").Summary.Add(New GridColumnSummaryItem(SummaryItemType.Sum, "Գումար", "{0}"))
                End With

            End With

            AddChildForm("nCCPayWin", f)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class

Public Class infX

    Public Property _prop As String
    Public Property _val As String

    Public Sub New(_p As String, _v As String)
        _prop = _p
        _val = _v
    End Sub

End Class