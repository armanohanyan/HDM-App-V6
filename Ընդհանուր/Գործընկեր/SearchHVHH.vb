Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class SearchHVHH

    Private iDuration As String = "00:00"

#Region "Records"

    Friend Sub UpdateRecords()
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ID As Int32 = GridView1.GetFocusedDataRow.Item("ClientID").ToString

        Dim f As New UpdateHVHHWindow With {.ClientID = ID}
        With f
            .ShowDialog()
            .Dispose()
        End With
        If txtPhrase.Text.Length > 0 Then Call btnQuery_Click(btnQuery, Nothing)

        On Error Resume Next
        If GridView1.RowCount > 0 Then
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "ClientID") = ID Then GridView1.FocusedRowHandle = i : GridView1.TopRowIndex = i : Exit For
            Next
        End If
    End Sub
    Friend Sub AddRecord()
        Dim sHVHH As String = String.Empty
        Dim f As New AddHVHHWindow
        With f
            .ShowDialog()
            sHVHH = .NewHvhh
            .Dispose()
        End With

        If Not String.IsNullOrEmpty(sHVHH) Then
            txtPhrase.Text = sHVHH
            rbHVHH.Checked = True
            btnQuery.PerformClick()
        End If

    End Sub

#End Region

    Private Sub resetValues()
        rtxtContract.Text = String.Empty
        rtxtCompany.Text = String.Empty
        rtxtHVHH.Text = String.Empty
        rtxtDirector.Text = String.Empty
        rtxtIravAddress.Text = String.Empty
        rtxtAraqAddress.Text = String.Empty
        rtxtRegion.Text = String.Empty
        rtxtTHT.Text = String.Empty
        rtxtTel.Text = String.Empty
        rtxtSupporter.Text = String.Empty
        txtComment.Text = String.Empty
        txtHTS.Text = String.Empty
        txtTarif.Text = String.Empty
        rcHrajarvats.Checked = False
        rcNDS.Checked = False
        rcNotSuported.Checked = False
        ckZeroNds.Checked = False
    End Sub
    Private Sub SearchHVHH_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
    Private Sub mnuAddClient_Click(sender As Object, e As EventArgs) Handles mnuAddClient.Click
        If CheckPermission2("E693D414793945C6968068E1E2DF48A0") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Call AddRecord()
    End Sub
    Private Sub mnuEditClient_Click(sender As Object, e As EventArgs) Handles mnuEditClient.Click
        If CheckPermission2("5B9BFC20A0DB4BA0806322433BCFE5BE") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Call UpdateRecords()
    End Sub
    Private Sub mnuBlockedGP_Click(sender As Object, e As EventArgs) Handles mnuBlockedGP.Click
        If CheckPermission2("A6DAD61B2BB24175BE74FF6D7D5697B4") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString

        Call CloseWindow("nBlockedHDMGprs")
        Dim f As New BlockedGPRS
        f.iClientID = ID
        AddChildForm("nBlockedHDMGprs", f)

    End Sub
    Private Sub mnuHDMInRemont_Click(sender As Object, e As EventArgs) Handles mnuHDMInRemont.Click
        If CheckPermission2("C00331E232734333BD1F2CE650B08998") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString

        Call CloseWindow("nGetRemakeHDMByCompany")
        Dim f As New RemakeHDMByCompanyWin
        f.iClientID = ID
        AddChildForm("nGetRemakeHDMByCompany", f)

    End Sub
    Private Sub mnuHtsCHanges_Click(sender As Object, e As EventArgs) Handles mnuHtsCHanges.Click
        If CheckPermission2("6EF3A5A4654C434996F553FDFC5DD993") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString

        Call CloseWindow("nHTSChange")
        Dim f As New htsCodeChangeWin
        f.iClientID = ID
        AddChildForm("nHTSChange", f)

    End Sub
    Private Sub mnuReplacedHDMs_Click(sender As Object, e As EventArgs) Handles mnuReplacedHDMs.Click
        If CheckPermission2("BF69F42B4E464AACB129203B4EF59B9F") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString

        Call CloseWindow("nReplacedHDMByCompany")
        Dim f As New ReplacedHdmWin
        f.iClientID = ID
        AddChildForm("nReplacedHDMByCompany", f)

    End Sub
    Private Sub mnuAllHDMs_Click(sender As Object, e As EventArgs) Handles mnuAllHDMs.Click
        If CheckPermission2("6F0FFD8B46824D4D86E4DF9077A5C815") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim hvhh As String = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString

        Call CloseWindow("nHDMSearch")
        Dim f As New SearchHDMOnly
        f.txtPhrase.Text = hvhh
        f.rbHVHH.Checked = True
        AddChildForm("nHDMSearch", f)
        f.btnQuery.PerformClick()

    End Sub
    Private Sub mnuRepPay_Click(sender As Object, e As EventArgs) Handles mnuRepPay.Click
        If CheckPermission2("1028600DD2514347BA35F4D7BCA174E4") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ClientID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString
        Dim f As New PaymentHistoryWin With {.IClientID = ClientID}
        With f
            .Text = "ՀՎՀՀ՝ " & GridView1.GetFocusedDataRow.Item("ՀՎՀՀ") & "  |  " & GridView1.GetFocusedDataRow.Item("Կազմակերպություն")
            .ShowDialog()
            .Dispose()
        End With
    End Sub
    Private Sub mnuHdmCountByContract_Click(sender As Object, e As EventArgs) Handles mnuHdmCountByContract.Click
        If CheckPermission2("A0D98DB3084A4FF9AEDAEBFD5E70FF93") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

        Dim hvhh As String = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString
        Dim hvhhID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString
        Dim CompName As String = GridView1.GetFocusedDataRow.Item("Կազմակերպություն").ToString
        Dim contract As String = GridView1.GetFocusedDataRow.Item("Պայմանագիր").ToString

        Call CloseWindow("mHdmCountByContract")
        Dim f As New HdmCountByContractWindow
        f.hvhh = hvhh
        f.hvhhID = hvhhID
        f.compName = CompName
        f.Contract = contract
        AddChildForm("mHdmCountByContract", f)

    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            If String.IsNullOrEmpty(txtPhrase.Text) Then Exit Sub
            Dim s As String = txtPhrase.Text.Trim
            If s = "" Then Exit Sub

            If rbHVHH.Checked Then If txtPhrase.Text.Trim.Length < 8 Then Throw New Exception("ՀՎՀՀ-ն սխալ է գրված")

            formX.Show() : My.Application.DoEvents()

            Call resetValues()

            Dim dt As DataTable

            sTime = Now
            If rbHVHH.Checked = True Then
                dt = iDB.GetHVHHSearch(s, DB.HdmSearchType.ՀՎՀՀ)
            ElseIf rbContract.Checked = True Then
                dt = iDB.GetHVHHSearch(s, DB.HdmSearchType.Պայմանագիր)
            ElseIf rbCompany.Checked = True Then
                dt = iDB.GetHVHHSearch(s, DB.HdmSearchType.Կազմակերպություն)
            ElseIf rbHTS.Checked = True Then
                dt = iDB.GetHVHHSearch(s, DB.HdmSearchType.ՀԾ)
            Else
                Throw New Exception("Անհայտ փնտրման պարամետր")
            End If
            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ClientID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("ՀՎՀՀ").Width = 100
                .Columns("ՀծԿոդ").BestFit()
                .Columns("Պայմանագիր").BestFit()
                .Columns("Կազմակերպություն").Width = 250
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "Քանակ {0}")
                    GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
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
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            If IsNothing(GridView1.GetFocusedDataRow.Item("ՀՎՀՀ")) Then Exit Sub
            txtTarif.Text = GridView1.GetFocusedDataRow.Item("Տարիֆ").ToString
            rtxtContract.Text = GridView1.GetFocusedDataRow.Item("Պայմանագիր").ToString
            rtxtCompany.Text = GridView1.GetFocusedDataRow.Item("Կազմակերպություն").ToString
            rtxtHVHH.Text = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString
            rtxtDirector.Text = GridView1.GetFocusedDataRow.Item("Տնօրեն").ToString
            rtxtIravAddress.Text = GridView1.GetFocusedDataRow.Item("ԻրավաբանականՀասցե").ToString
            rtxtAraqAddress.Text = GridView1.GetFocusedDataRow.Item("ԱռաքմանՀասցե").ToString
            rtxtRegion.Text = GridView1.GetFocusedDataRow.Item("Տարածաշրջան").ToString
            rtxtTHT.Text = GridView1.GetFocusedDataRow.Item("ՏՀՏ").ToString
            rtxtTel.Text = GridView1.GetFocusedDataRow.Item("Հեռախոս").ToString
            rtxtSupporter.Text = GridView1.GetFocusedDataRow.Item("Սպասարկող").ToString
            If IsDBNull(GridView1.GetFocusedDataRow.Item("Մեկնաբանություն")) Then txtComment.Text = "" Else txtComment.Text = GridView1.GetFocusedDataRow.Item("Մեկնաբանություն")
            txtHTS.Text = GridView1.GetFocusedDataRow.Item("ՀծԿոդ").ToString
            rcHrajarvats.Checked = GridView1.GetFocusedDataRow.Item("Հրաժարված")
            rcNDS.Checked = GridView1.GetFocusedDataRow.Item("ԱԱՀ")
            rcNotSuported.Checked = GridView1.GetFocusedDataRow.Item("Չսպասարկվող")
            ckZeroNds.Checked = GridView1.GetFocusedDataRow.Item("ԶրոյականԱահ")
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ԱվելացնելՎճարToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ԱվելացնելՎճարToolStripMenuItem.Click
        If CheckPermission2("21400CA4C27840C1BB7597E1DA35FFE1") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim hvhh As String = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString

        Call CloseWindow("nAddPaymentWin")
        Dim f As New payWindow
        f.txtHvhh.Text = hvhh
        AddChildForm("nAddPaymentWin", f)
        f.Query()

    End Sub
    Private Sub mnuLoadAllClients_Click(sender As Object, e As EventArgs) Handles mnuLoadAllClients.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            If CheckPermission2("8F79ED4715F14572A323B12F21AF3C25") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            formX.Show() : My.Application.DoEvents()

            Call resetValues()

            Dim dt As DataTable

            sTime = Now
            dt = iDB.GetAllClientInfo(iUser.DB)

            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ClientID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("ՀՎՀՀ").Width = 100
                .Columns("ՀծԿոդ").BestFit()
                .Columns("Պայմանագիր").BestFit()
                .Columns("Կազմակերպություն").Width = 250
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "Քանակ {0}")
                    GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
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
    Private Sub mnuGPAktKas_Click(sender As Object, e As EventArgs) Handles mnuGPAktKas.Click
        If CheckPermission2("F61FFC81DA7D4EBA8ABCC93D480B3337") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Exclamation, My.Application.Info.Title)

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

        Dim ClientID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString

        Call CloseWindow("nGPRS_History")
        Dim f As New GPRS_History With {.ClientID = ClientID}
        AddChildForm("nGPRS_History", f)

    End Sub
    Private Sub mnuNoGpsEcr_Click(sender As Object, e As EventArgs) Handles mnuNoGpsEcr.Click
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime

        If CheckPermission2("B52293885D4340349183DB2004B04F1E") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        Try
            formX.Show() : My.Application.DoEvents()

            Call resetValues()

            Dim dt As DataTable

            sTime = Now

            dt = iDB.NoGPSEcrClientsByDB(iUser.DB)

            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ClientID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("ՀՎՀՀ").Width = 100
                .Columns("ՀծԿոդ").BestFit()
                .Columns("Պայմանագիր").BestFit()
                .Columns("Կազմակերպություն").Width = 250
            End With

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "Քանակ {0}")
                    GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
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
    Private Sub mnuSetGpsEcr_Click(sender As Object, e As EventArgs) Handles mnuSetGpsEcr.Click
        If CheckPermission2("B52293885D4340349183DB2004B04F1E") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ClientID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString

        Dim f As New GPSForEcr With {.ClientID = ClientID}
        f.ShowDialog()
        f.Dispose()

    End Sub
    Private Sub SearchHVHH_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.Q Then
            mnuSetGpsEcr.PerformClick()
            e.Handled = True
        End If
    End Sub

    ''''''''''''''''''''''''''''Arman
    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        On Error Resume Next

        Dim View As GridView = sender
        If e.Column.FieldName = "Հրաժարված" Then
            Dim ColPercent = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Հրաժարված"))

            If ColPercent = "Checked" Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.White
            End If

        End If

    End Sub
    ''''''''''''''''''''''''''''
End Class