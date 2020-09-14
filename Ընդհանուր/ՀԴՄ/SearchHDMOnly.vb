Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class SearchHDMOnly

    Private iDuration As String = "00:00"

#Region "Records"

    Friend Sub UpdateRecords()
        If CheckPermission2("A35BF5CDACCA4201A59A8BE00D15B46E") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

        Dim iHDM = New With {.hdm = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString,
                             .ContDate = GridView1.GetFocusedDataRow.Item("ՊայմանագրիԱմսաթիվ").ToString,
                             .hvhh = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString,
                             .regionN = GridView1.GetFocusedDataRow.Item("Տարածաշրջան").ToString,
                             .Addr = GridView1.GetFocusedDataRow.Item("ԳործունեությանՀասցե").ToString,
                             .mgh = GridView1.GetFocusedDataRow.Item("ՄԳՀ").ToString,
                             .gprs = GridView1.GetFocusedDataRow.Item("gprs").ToString,
                             .status = GridView1.GetFocusedDataRow.Item("Կարգավիճակ").ToString,
                             .tel = GridView1.GetFocusedDataRow.Item("Հեռախոս").ToString,
                             .oType = GridView1.GetFocusedDataRow.Item("ՕբյեկտիՏեսակ").ToString,
                             .nds = GridView1.GetFocusedDataRow.Item("ԱԱՀ").ToString,
                             .pos = GridView1.GetFocusedDataRow.Item("POSՏերմինալ").ToString,
                             .inv = GridView1.GetFocusedDataRow.Item("TaxFree").ToString,
                             .tesuch = GridView1.GetFocusedDataRow.Item("Տեսուչ").ToString}
        Dim f As New UpdateHDMWindow
        With f
            .txtEcr.Text = iHDM.hdm
            .dContractDate.DateTime = iHDM.ContDate
            .txtHvhh.Text = iHDM.hvhh
            '.cbRegion.Text = iHDM.regionN
            .txtGorcAddress.Text = iHDM.Addr
            .txtMgh.Text = iHDM.mgh
            .txtGprs.Text = iHDM.gprs
            '.cbStatus.Text = iHDM.status
            .txtTel.Text = iHDM.tel
            .txtObjType.Text = iHDM.oType
            .ckNds.Checked = iHDM.nds
            .ckPosTerm.Checked = iHDM.pos
            .ckInvoice.Checked = iHDM.inv
            '.cbTesuch.Text = iHDM.tesuch

            .iRegion = iHDM.regionN
            .iStatus = iHDM.status
            .iTesuch = iHDM.tesuch

            .ShowDialog()
            .Dispose()
        End With

        If txtPhrase.Text.Length > 0 Then Call btnQuery_Click(btnQuery, Nothing)

        On Error Resume Next
        If GridView1.RowCount > 0 Then
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "ՀԴՄ") = iHDM.hdm Then GridView1.FocusedRowHandle = i : GridView1.TopRowIndex = i : Exit For
            Next
        End If

    End Sub
    Friend Sub AddRecord()
        If CheckPermission2("07BFB69B94724801A8683E2D2242653C") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Dim cEcr As String = String.Empty
        Dim f As New AddHDMWindow
        With f
            .ShowDialog()
            cEcr = .NewEcr
            .Dispose()
        End With

        If Not String.IsNullOrEmpty(cEcr) Then
            txtPhrase.Text = cEcr
            rbHDM.Checked = True
            btnQuery.PerformClick()
        End If

    End Sub

#End Region

    Private Sub resetValues()
        rtxtHDM.Text = String.Empty
        rtxtContract.Text = String.Empty
        rtxtCompany.Text = String.Empty
        rtxtHVHH.Text = String.Empty
        rtxtDirector.Text = String.Empty
        rtxtIravAddress.Text = String.Empty
        rtxtAraqAddress.Text = String.Empty
        rtxtRegion.Text = String.Empty
        rtxtGorcAddress.Text = String.Empty
        rtxtMGH.Text = String.Empty
        rtxtTHT.Text = String.Empty
        rtxtGPRS.Text = String.Empty
        rtxtIP.Text = String.Empty
        rtxtStatus.Text = String.Empty
        rtxtTel.Text = String.Empty
        rtxtSupporter.Text = String.Empty
        rtxtObjType.Text = String.Empty
        rtxtTesuch.Text = String.Empty
        rckNDS.Checked = False
        rckPosTer.Checked = False
        rchInv.Checked = False
    End Sub
    Private Sub SearchHDMOnly_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub

#Region "Menu"

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
    Private Sub mnuAddHDM_Click(sender As Object, e As EventArgs) Handles mnuAddHDM.Click
        Call AddRecord()
    End Sub
    Private Sub mnuEditHDM_Click(sender As Object, e As EventArgs) Handles mnuEditHDM.Click
        Call UpdateRecords()
    End Sub
    Private Sub mnuReRegister_Click(sender As Object, e As EventArgs) Handles mnuReRegister.Click
        If CheckPermission2("9C0DCBD1BEF74F8FB900D574862DCFD8") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

        Dim iHDM = New With {.hdm = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString,
                             .ContDate = GridView1.GetFocusedDataRow.Item("ՊայմանագրիԱմսաթիվ").ToString,
                             .hvhh = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString,
                             .regionN = GridView1.GetFocusedDataRow.Item("Տարածաշրջան").ToString,
                             .Addr = GridView1.GetFocusedDataRow.Item("ԳործունեությանՀասցե").ToString,
                             .mgh = GridView1.GetFocusedDataRow.Item("ՄԳՀ").ToString,
                             .gprs = GridView1.GetFocusedDataRow.Item("gprs").ToString,
                             .status = GridView1.GetFocusedDataRow.Item("Կարգավիճակ").ToString,
                             .tel = GridView1.GetFocusedDataRow.Item("Հեռախոս").ToString,
                             .oType = GridView1.GetFocusedDataRow.Item("ՕբյեկտիՏեսակ").ToString,
                             .nds = GridView1.GetFocusedDataRow.Item("ԱԱՀ").ToString,
                             .pos = GridView1.GetFocusedDataRow.Item("POSՏերմինալ").ToString,
                             .inv = GridView1.GetFocusedDataRow.Item("TaxFree").ToString,
                             .tesuch = GridView1.GetFocusedDataRow.Item("Տեսուչ").ToString}
        Dim f As New ReRegisterHDMWindow
        With f
            .txtEcr.Text = iHDM.hdm
            .dContractDate.DateTime = iHDM.ContDate
            .txtHvhh.Text = iHDM.hvhh
            '.cbRegion.Text = iHDM.regionN
            .txtGorcAddress.Text = iHDM.Addr
            .txtMgh.Text = iHDM.mgh
            .txtGprs.Text = iHDM.gprs
            '.cbStatus.Text = iHDM.status
            .txtTel.Text = iHDM.tel
            .txtObjType.Text = iHDM.oType
            .ckNds.Checked = iHDM.nds
            .ckPosTerm.Checked = iHDM.pos
            .ckInvoice.Checked = iHDM.inv
            '.cbTesuch.Text = iHDM.tesuch

            .iRegion = iHDM.regionN
            .iStatus = iHDM.status
            .iTesuch = iHDM.tesuch
            .iOldHvhh = iHDM.hvhh

            .ShowDialog()
            .Dispose()
        End With

        If txtPhrase.Text.Length > 0 Then Call btnQuery_Click(btnQuery, Nothing)

        On Error Resume Next
        If GridView1.RowCount > 0 Then
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "ՀԴՄ") = iHDM.hdm Then GridView1.FocusedRowHandle = i : GridView1.TopRowIndex = i : Exit For
            Next
        End If

    End Sub
    Private Sub mnuRemarkeHistory_Click(sender As Object, e As EventArgs) Handles mnuRemarkeHistory.Click
        If CheckPermission2("CAF8D5F996474865992650991B949851") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

        Dim iEcr As Integer = GridView1.GetFocusedDataRow.Item("ecrID").ToString
        Dim Ecr As String = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString

        Dim f As New RemakeHistoryByHDMWin With {.iEcr = iEcr, .Ecr = Ecr}
        With f
            .ShowDialog()
            .Dispose()
        End With
    End Sub
    Private Sub ՖունկցիոնալToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ՖունկցիոնալToolStripMenuItem.Click
        Try
            If CheckPermission2("F8F540A6BF2049C9A8C0D09527F739C8") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

            Dim Ecr As String = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString

            Dim f As New EcrFunctional With {.Ecr = Ecr}
            f.ShowDialog()
            f.Dispose()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            If String.IsNullOrEmpty(txtPhrase.Text) Then Exit Sub
            Dim s As String = txtPhrase.Text.Trim
            If s = "" Then Exit Sub

            formX.Show() : My.Application.DoEvents()

            If rbHDM.Checked Then If txtPhrase.Text.Trim.Length <> 12 Then Throw New Exception("ՀԴՄ-ն պետք է բաղկացած լինի 12 սիմվոլից")
            If rbHVHH.Checked Then If txtPhrase.Text.Trim.Length < 8 Then Throw New Exception("ՀՎՀՀ-ն սխալ է գրված")

            Call resetValues()

            Dim dt As DataTable

            sTime = Now

            If rbHDM.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.ՀԴՄ)
            ElseIf rbHVHH.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.ՀՎՀՀ)
            ElseIf rbMGH.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.ՄԳՀ)
            ElseIf rbContract.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.Պայմանագիր)
            ElseIf rbGPRS.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.GPRS)
            ElseIf rbIP.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.IP)
            ElseIf rbWorkAddress.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.ԳործունեությանՀասցե)
            ElseIf rbCompany.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.Կազմակերպություն)
            ElseIf rbLocation.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.Տարածաշրջան)
            ElseIf rbDelAddress.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.ԱռաքմանՀասցե)
            ElseIf rbTesuch.Checked = True Then
                dt = iDB.GetHdmSearch(s, DB.HdmSearchType.Տեսուչ)
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
                .Columns("ecrID").Visible = False
                .Columns("ՀԴՄ").Width = 90
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsFind.AllowFindPanel = True
                .OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
                .OptionsFind.ShowClearButton = False
                .OptionsFind.ShowFindButton = False
                .Columns("Կազմակերպություն").Width = 250
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "Քանակ {0}")
                    GridView1.Columns("ՀԴՄ").Summary.Add(item)
                End If
            End If

            If rbHDM.Checked = True Then
                If GridView1.RowCount = 1 Then
                    Call GridControl1_DoubleClick(GridView1, Nothing)
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
    Private Sub txtPhrase_TextChanged(sender As Object, e As EventArgs) Handles txtPhrase.TextChanged
        On Error Resume Next
        If rbHDM.Checked Then
            If txtPhrase.Text.Length = 1 Then
                If txtPhrase.Text.StartsWith("V") Then
                    txtPhrase.Text = txtPhrase.Text.Replace("V", "V90413") : txtPhrase.SelectionStart = txtPhrase.Text.Length
                ElseIf txtPhrase.Text.StartsWith("v") Then
                    txtPhrase.Text = txtPhrase.Text.Replace("v", "V90413") : txtPhrase.SelectionStart = txtPhrase.Text.Length
                ElseIf txtPhrase.Text.StartsWith("Q") Then
                    txtPhrase.Text = txtPhrase.Text.Replace("Q", "Q80414") : txtPhrase.SelectionStart = txtPhrase.Text.Length
                ElseIf txtPhrase.Text.StartsWith("q") Then
                    txtPhrase.Text = txtPhrase.Text.Replace("q", "Q80414") : txtPhrase.SelectionStart = txtPhrase.Text.Length
                ElseIf txtPhrase.Text.StartsWith("S") Then
                    txtPhrase.Text = txtPhrase.Text.Replace("S", "S90055") : txtPhrase.SelectionStart = txtPhrase.Text.Length
                ElseIf txtPhrase.Text.StartsWith("s") Then
                    txtPhrase.Text = txtPhrase.Text.Replace("s", "S90055") : txtPhrase.SelectionStart = txtPhrase.Text.Length
                ElseIf txtPhrase.Text.StartsWith("A") Then
                    txtPhrase.Text = txtPhrase.Text.Replace("A", "A90022") : txtPhrase.SelectionStart = txtPhrase.Text.Length
                ElseIf txtPhrase.Text.StartsWith("a") Then
                    txtPhrase.Text = txtPhrase.Text.Replace("a", "A90022") : txtPhrase.SelectionStart = txtPhrase.Text.Length
                End If
            End If
        End If
    End Sub
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            If IsNothing(GridView1.GetFocusedDataRow.Item("ՀԴՄ")) Then Exit Sub
            If IsDBNull(GridView1.GetFocusedDataRow.Item("ՀԴՄ")) Then Exit Sub

            rtxtHDM.Text = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString
            rtxtContract.Text = GridView1.GetFocusedDataRow.Item("Պայմանագիր").ToString
            rdateComp.Value = GridView1.GetFocusedDataRow.Item("ՊայմանագրիԱմսաթիվ").ToString
            rtxtCompany.Text = GridView1.GetFocusedDataRow.Item("Կազմակերպություն").ToString
            rtxtHVHH.Text = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString
            rtxtDirector.Text = GridView1.GetFocusedDataRow.Item("Տնօրեն").ToString
            rtxtIravAddress.Text = GridView1.GetFocusedDataRow.Item("ԻրավաբանականՀասցե").ToString
            rtxtAraqAddress.Text = GridView1.GetFocusedDataRow.Item("ԱռաքմանՀասցե").ToString
            rtxtRegion.Text = GridView1.GetFocusedDataRow.Item("Տարածաշրջան").ToString
            rtxtGorcAddress.Text = GridView1.GetFocusedDataRow.Item("ԳործունեությանՀասցե").ToString
            rtxtMGH.Text = GridView1.GetFocusedDataRow.Item("ՄԳՀ").ToString
            rtxtTHT.Text = GridView1.GetFocusedDataRow.Item("ՏՀՏ").ToString
            rtxtGPRS.Text = GridView1.GetFocusedDataRow.Item("gprs").ToString
            rtxtIP.Text = GridView1.GetFocusedDataRow.Item("IP").ToString
            rtxtStatus.Text = GridView1.GetFocusedDataRow.Item("Կարգավիճակ").ToString
            rtxtTel.Text = GridView1.GetFocusedDataRow.Item("Հեռախոս").ToString
            rtxtSupporter.Text = GridView1.GetFocusedDataRow.Item("Սպասարկող").ToString
            rtxtObjType.Text = GridView1.GetFocusedDataRow.Item("ՕբյեկտիՏեսակ").ToString
            rtxtTesuch.Text = GridView1.GetFocusedDataRow.Item("Տեսուչ").ToString
            rckNDS.Checked = GridView1.GetFocusedDataRow.Item("ԱԱՀ")
            rckPosTer.Checked = GridView1.GetFocusedDataRow.Item("POSՏերմինալ")
            rchInv.Checked = GridView1.GetFocusedDataRow.Item("TaxFree")
            rtxtBank.Text = GridView1.GetFocusedDataRow.Item("Բանկ")

            Dim b As Boolean = iDB.ISvTOq(GridView1.GetFocusedDataRow.Item("EcrID"))
            If b = True Then rckVQ.Checked = True Else rckVQ.Checked = False

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuRemake_Click(sender As Object, e As EventArgs) Handles mnuRemake.Click
        If CheckPermission2("2EEB43EEA6774E92A6B3758C0A9692C4") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim ecr As String = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString

        If iDB.IsEcrBloked(ecr) = True Then MsgBox("ՀԴՄ-ն արգելափակված է", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        If iDB.IsHvhhChanged(ecr) = True Then MsgBox("ՀԴՄ-ն ենթակա է վերագրանցման", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Call CloseWindow("nRemakeWindow")
        Dim f As New RemakeWindow With {.Ecr = ecr}
        AddChildForm("nRemakeWindow", f)

    End Sub

    'Send To IUNetworks
    'Private Sub ԲազանՈւղարկելIUNetworksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ԲազանՈւղարկելIUNetworksToolStripMenuItem.Click
    '    If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

    '    Dim ecrID As Integer = GridView1.GetFocusedDataRow.Item("EcrID").ToString
    '    If iDB.IsEcrInRemake(ecrID) = False Then MsgBox("ՀԴՄ-ի համար բաց հայտ չկա", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

    '    Dim ecr As String = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString
    '    Dim f As New SendToIUNetworks With {.iEcr = ecr}
    '    f.ShowDialog()
    '    f.Dispose()

    'End Sub

    'Show IUNetworks
    'Private Sub IUNetworksՈւղարկվածներիՑանկToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IUNetworksՈւղարկվածներիՑանկToolStripMenuItem.Click
    '    Dim f As New IUNetList
    '    f.ShowDialog()
    '    f.Dispose()
    'End Sub

    Private Sub mnuShowAll_Click(sender As Object, e As EventArgs) Handles mnuShowAll.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            If CheckPermission2("74AE3ECF7CC244BA825E9CCBF538E8FB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            formX.Show() : My.Application.DoEvents()

            Call resetValues()

            Dim dt As DataTable

            dt = iDB.GetAllEcrInfo(iUser.DB)

            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ecrID").Visible = False
                .Columns("ՀԴՄ").Width = 90
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsFind.AllowFindPanel = True
                .OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
                .OptionsFind.ShowClearButton = False
                .OptionsFind.ShowFindButton = False
                .Columns("Կազմակերպություն").Width = 250
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "Քանակ {0}")
                    GridView1.Columns("ՀԴՄ").Summary.Add(item)
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

    Private Sub mnuGPHistory_Click(sender As Object, e As EventArgs) Handles mnuGPHistory.Click
        If CheckPermission2("F61FFC81DA7D4EBA8ABCC93D480B3337") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Exclamation, My.Application.Info.Title)

        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub

        Dim ecr As String = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString

        Call CloseWindow("nGPRS_History")
        Dim f As New GPRS_History With {.Ecr = ecr}
        AddChildForm("nGPRS_History", f)
    End Sub

    Private Sub mnuSetGpsEcr_Click(sender As Object, e As EventArgs) Handles mnuSetGpsEcr.Click
        If CheckPermission2("B52293885D4340349183DB2004B04F1E") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        Call CloseWindow("nBulk_GPS")
        Dim f As New Bulk_GPS
        AddChildForm("nBulk_GPS", f)

    End Sub

End Class