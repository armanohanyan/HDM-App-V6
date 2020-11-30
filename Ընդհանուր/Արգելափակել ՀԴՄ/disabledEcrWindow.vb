Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports HdmRouter
Imports HdmRouter.Enum

Public Class disabledEcrWindow

    Dim MOperator As String = "O"
    Private iDuration As String = "00:00"

    Dim NotSupportedClients As New DataTable

    Private Sub loadNotSupportedClients()
        On Error Resume Next
        NotSupportedClients = iDB.GetNotServedClients()
    End Sub

    Private Sub NoGprsSupport()
        On Error Resume Next
        Dim iCounter As Integer = iDB.NotSuppPhoneNumberCount()
        If iCounter > 0 Then
            btnNotSupGprs.Text &= " ( " & iCounter & " )"
            btnNotSupGprs.ForeColor = Color.Red
        End If
    End Sub
    Private Sub ResetGrid()
        On Error Resume Next
        GridControl1.BeginUpdate()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
        GridControl1.EndUpdate()
    End Sub
    Private Sub disabledEcrWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            If CheckPermission2("034EDB8971C9429999F952861E76D79F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim dt As DataTable

            formX.Show() : My.Application.DoEvents()

            sTime = Now
            dt = iDB.BlockedGPRSList(MOperator)
            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("RecID").Visible = False
                .Columns("NotServed").Visible = False
                .Columns("Colored").Visible = False
                .Columns("ԿասեցմանՊահիՊարտքիԱմսաթիվ").Visible = False
                .Columns("Օպ").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("Գործընկեր").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .BestFitColumns(True)
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
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = Not GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ")
        Next
    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        On Error Resume Next

        'Dim View As GridView = sender
        'If e.Column.FieldName = "ՀուսալիությանՏոկոս" Then
        '    Dim ColPercent = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀուսալիությանՏոկոս"))

        '    Dim r1 As Integer = 2.55 * (100 - ColPercent)
        '    If r1 > 255 Then r1 = 255

        '    Dim r2 As Integer = (0.64 * (100 - ColPercent)) + 191
        '    If r2 > 255 Then r2 = 255

        '    e.Appearance.BackColor = Color.FromArgb(r1, r2, 255)
        '    e.Appearance.BackColor2 = Color.White
        'End If

    End Sub
    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next

        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then

            Dim NotServed As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("NotServed"))
            If NotServed = "Checked" Then
                e.Appearance.BackColor = Color.Red        ' Color.Salmon
                e.Appearance.BackColor2 = Color.Orange            ' Color.SeaShell
            End If

            Dim Colored As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Colored"))
            If Colored = "Checked" Then
                e.Appearance.BackColor = Color.GreenYellow       ' Color.Salmon
                e.Appearance.BackColor2 = Color.LightBlue            ' Color.SeaShell
            End If
        End If

    End Sub
    Private Sub mnuSelectRow_Click(sender As Object, e As EventArgs) Handles mnuSelectRow.Click
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            If GridView1.GetRow(i).Item("NotServed") = True Then Continue For
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuSelectAll_Click(sender As Object, e As EventArgs) Handles mnuSelectAll.Click
        On Error Resume Next

        If GridView1.RowCount = 0 Then Exit Sub

        For i As Int32 = 0 To GridView1.RowCount - 1
            If GridView1.GetRow(i).Item("NotServed") = True Then Continue For
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
    Private Sub mnuExportSelected_Click(sender As Object, e As EventArgs) Handles mnuExportSelected.Click
        On Error Resume Next
        GridView1.ClearColumnsFilter()
        GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)
        mnuExportToExcel.PerformClick()
    End Sub
    Private Sub mnuPrepareEmail_Click(sender As Object, e As EventArgs) Handles mnuPrepareEmail.Click
        On Error Resume Next
        If CheckPermission2("2C46B9F1398F440D9FA377DE8F5C1239") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        GridView1.ClearColumnsFilter()
        GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)

        If GridView1.RowCount = 0 Then Exit Sub

        Dim th As New List(Of tempHDM)

        For i As Integer = 0 To GridView1.RowCount - 1
            th.Add(New tempHDM(GridView1.GetRowCellValue(i, "ՀԴՄ")))
        Next

        If IsNothing(th) OrElse th.Count = 0 Then MsgBox("Տվյալներ չկան", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Dim f As New PrepareMailSendWindow
        With f
            .iMailDirection = "Կասեցված"
            .iTempHdm = th
            .ShowDialog()
        End With
        f = Nothing
        GridView1.ClearColumnsFilter()

    End Sub
    Private Sub mnuAllItems_Click(sender As Object, e As EventArgs) Handles mnuAllItems.Click
        Dim formX As New Working
        'Try
        '    If CheckPermission2("AD9777798F7749C09B35549E885BFF7D") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

        '    If Not MsgBox("Ցանկանու՞մ եք հանել ՀԴՄ-ի արգելքը", MsgBoxStyle.Question + MsgBoxStyle.YesNo).Equals(MsgBoxResult.Yes) Then Exit Sub

        '    formX.Show() : My.Application.DoEvents()

        '    Dim gphvhhecr As New List(Of gprsDelHvhhEcr)

        '    Dim b As Boolean = False

        '    For i As Integer = 0 To GridView1.RowCount - 1
        '        For j As Integer = 0 To NotSupportedClients.Rows.Count - 1
        '            If GridView1.GetRowCellValue(i, "ՀՎՀՀ") = NotSupportedClients.Rows(j)("HVHH") Then b = True : Continue For
        '        Next

        '        If b = True Then b = False : Continue For

        '        gphvhhecr.Add(New gprsDelHvhhEcr(
        '                                    GridView1.GetRowCellValue(i, "ՀԴՄ"),
        '                                    GridView1.GetRowCellValue(i, "ՀՎՀՀ"),
        '                                    GridView1.GetRowCellValue(i, "RecID"),
        '                                    GridView1.GetRowCellValue(i, "ՀԴՄ տեսակ"),
        '                                    GridView1.GetRowCellValue(i, "Օպ")
        '                                    ))
        '    Next

        '    Dim dataTable As DataTable = ToDataTable(gphvhhecr)

        '    Dim dict = RoutingManager.GroupHdmsByType(dataTable)

        '    For Each pair In dict

        '        Select Case pair.Key
        '            Case HdmType.Ucom
        '                iDB.EnableBlockedGPRS2(pair.Value)
        '            Case HdmType.Vivacell
        '                iDB.EnableBlockedGPRS(pair.Value)
        '            Case HdmType.Beeline
        '                iDB.EnableBlockedGPRS(pair.Value)
        '            Case HdmType.Android
        '                iDB.EnableBlockedGPRS3(pair.Value)
        '            Case HdmType.Pax
        '                iDB.EnableBlockedGPRS3(pair.Value)
        '            Case Else
        '        End Select
        '    Next

        '    MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        'Catch ex As ExceptionClass
        'Catch ex As System.Data.SqlClient.SqlException
        '    Call SQLException(ex)
        'Catch ex As Exception
        '    Call SoftException(ex)
        'Finally
        '    formX.Close()
        '    formX = Nothing
        '    btnQuery.PerformClick()
        'End Try
    End Sub
    Private Sub ՀանելԱրգելքըToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ՀանելԱրգելքըToolStripMenuItem.Click
        mnuOnlySelected.PerformClick()
    End Sub
    Private Sub mnuOnlySelected_Click(sender As Object, e As EventArgs) Handles mnuOnlySelected.Click
        Dim formX As New Working
        Try
            If CheckPermission2("35AD99B4836744A1B4E15A14A57AC2CA") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If Not MsgBox("Ցանկանու՞մ եք հանել ՀԴՄ-ի արգելքը", MsgBoxStyle.Question + MsgBoxStyle.YesNo).Equals(MsgBoxResult.Yes) Then Exit Sub

            'UnCheck Not Supported
            If NotSupportedClients.Rows.Count > 0 Then
                For j As Integer = 0 To NotSupportedClients.Rows.Count - 1
                    For i As Integer = 0 To GridView1.RowCount - 1
                        If GridView1.GetRowCellValue(i, "ՀՎՀՀ") = NotSupportedClients.Rows(j)("HVHH") Then
                            GridView1.SetRowCellValue(i, "Նշիչ", False)
                        End If
                    Next
                Next
            End If

            GridView1.ClearColumnsFilter()
            GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)

            If GridView1.RowCount = 0 Then Throw New Exception("Նշված ՀԴՄ չկա")

            formX.Show() : My.Application.DoEvents()

            Dim gphvhhecr As New List(Of gprsDelHvhhEcr)

            For i As Integer = 0 To GridView1.RowCount - 1
                gphvhhecr.Add(New gprsDelHvhhEcr(
                                            GridView1.GetRowCellValue(i, "ՀԴՄ"),
                                            GridView1.GetRowCellValue(i, "ՀՎՀՀ"),
                                            GridView1.GetRowCellValue(i, "RecID"),
                                            GridView1.GetRowCellValue(i, "ՀԴՄ տեսակ"),
                                            GridView1.GetRowCellValue(i, "Օպ")
                                            ))
            Next

            Dim dataTable As DataTable = ToDataTable(gphvhhecr)

            Dim dict = RoutingManager.GroupHdmsByType(dataTable)

            For Each pair In dict

                Select Case pair.Key
                    Case HdmType.Ucom
                        iDB.EnableBlockedGPRS2(pair.Value)
                    Case HdmType.Vivacell
                        iDB.EnableBlockedGPRS(pair.Value)
                    Case HdmType.Beeline
                        iDB.EnableBlockedGPRS(pair.Value)
                    Case HdmType.Android
                        iDB.EnableBlockedGPRS3(pair.Value)
                    Case HdmType.Pax
                        iDB.EnableBlockedGPRS3(pair.Value)
                    Case Else
                End Select
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
            GridView1.ClearColumnsFilter()
            'btnQuery.PerformClick()
        End Try
    End Sub
    Private Sub btnLoadHVHH_Click(sender As Object, e As EventArgs) Handles btnLoadHVHH.Click
        Try
            If CheckPermission2("7BCBDF99371C4FBAAA2AC3AF5AC2C5AB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim fDialog As New OpenFileDialog
            With fDialog
                .Filter = "Microsoft Excel|*.xlsx"
                .Multiselect = False
                .Title = "Նշեք Excel-ի Ֆայլ"
                Dim result As DialogResult = .ShowDialog
                If result <> Windows.Forms.DialogResult.OK Then Exit Sub
                Dim s As String = .FileName
                If String.IsNullOrEmpty(s) Then Exit Sub

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim ExcelDataSet As System.Data.DataSet
                Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & s & ";Extended Properties=Excel 12.0;")

                ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT hvhh FROM [Sheet1$]", MyConnection)
                ExcelAdapter.TableMappings.Add("Table", "Excel Data")
                ExcelDataSet = New System.Data.DataSet
                ExcelAdapter.Fill(ExcelDataSet)
                Dim dt As DataTable = ExcelDataSet.Tables(0)
                MyConnection.Close()

                If dt.Rows.Count = 0 Then Exit Sub

                For i As Int32 = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Նշիչ") = True Then
                        For j As Integer = 0 To dt.Rows.Count - 1
                            If GridView1.GetRowCellValue(i, "ՀՎՀՀ") = dt.Rows(j)(0) Then GridView1.SetRowCellValue(i, "Նշիչ", False)
                        Next
                    End If
                Next

            End With

            MsgBox("Գործողությունը ավարտվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnSelectSim_Click(sender As Object, e As EventArgs) Handles btnSelectSim.Click
        Dim formX As New Working
        Try
            If CheckPermission2("175F430B0B9C41BF924FD6CE15BDC3F1") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            mnuSelectColored.PerformClick() 'Նշել երանգավորները
            GridView1.ClearColumnsFilter()

            Dim dt As DataTable = iDB.GetBlockedGprsForEnable()
            'If dt.Rows.Count = 0 Then Exit Sub

            formX.Show() : My.Application.DoEvents()

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim rHDM As String = dt.Rows(i)("ECR")
                Dim rHVHH As String = dt.Rows(i)("HVHH")
                For j As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(j, "ՀԴՄ") = rHDM AndAlso GridView1.GetRowCellValue(j, "ՀՎՀՀ") = rHVHH Then
                        GridView1.SetRowCellValue(j, "Նշիչ", True)
                        Continue For
                    End If
                Next
                My.Application.DoEvents()
            Next
            GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
            'MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub btnDeleteSim_Click(sender As Object, e As EventArgs) Handles btnDeleteSim.Click
        Try
            If CheckPermission2("C1255ADFDDA941219202C5B46553DDD4") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.RowCount = 0 Then Exit Sub

            If MsgBox("Ցանկանու՞մ եք ջնջել տվյալները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            Dim dt As DataTable = iDB.GetBlockedGprsForEnable()
            If dt.Rows.Count = 0 Then Exit Sub

            Dim gphvhhecr As New List(Of gprsDelHvhhEcr)
            Dim isExists As Boolean = False

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim rHDM As String = dt.Rows(i)("ECR")
                Dim rHVHH As String = dt.Rows(i)("HVHH")

                For j As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(j, "ՀԴՄ") = rHDM AndAlso GridView1.GetRowCellValue(j, "ՀՎՀՀ") = rHVHH Then
                        isExists = True
                        Exit For
                    End If
                Next
                If isExists = False Then
                    gphvhhecr.Add(New gprsDelHvhhEcr(rHDM, rHVHH, 0, Nothing, Nothing))
                End If
            Next

            If IsNothing(gphvhhecr) OrElse gphvhhecr.Count = 0 Then MsgBox("Տվյալներ չկան", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

            Dim dt2 As DataTable = ToDataTable(gphvhhecr)

            iDB.UpdateBlockGprsHVHHEcr(dt2)
            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuSelectColored_Click(sender As Object, e As EventArgs) Handles mnuSelectColored.Click
        On Error Resume Next

        GridView1.ClearColumnsFilter()
        GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Colored", True)

        If GridView1.RowCount = 0 Then Exit Sub

        For i As Int32 = 0 To GridView1.RowCount - 1
            'GridView1.GetRow(i).Item("Նշիչ") = True
            GridView1.SetRowCellValue(i, "Նշիչ", True)
        Next
    End Sub
    Private Sub btnInAction_Click(sender As Object, e As EventArgs) Handles btnInAction.Click
        If CheckPermission2("A4B2F098385E4F7EAF2DA5C7D8A168AC") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Call CloseWindow("nGprsIntermediate2")
        Dim f As New GprsIntermediate With {.MustDisable = False}
        AddChildForm("nGprsIntermediate2", f)
    End Sub
    Private Sub cOrange_CheckedChanged(sender As Object, e As EventArgs) Handles cOrange.CheckedChanged
        Call ResetGrid()
        MOperator = "O"
    End Sub
    Private Sub cViva_CheckedChanged(sender As Object, e As EventArgs) Handles cViva.CheckedChanged
        Call ResetGrid()
        MOperator = "V"
    End Sub
    Private Sub cBeeline_CheckedChanged(sender As Object, e As EventArgs) Handles cBeeline.CheckedChanged
        Call ResetGrid()
        MOperator = "B"
    End Sub
    Private Sub cAllEcr_CheckedChanged(sender As Object, e As EventArgs) Handles cAllEcr.CheckedChanged
        Call ResetGrid()
        MOperator = "A"
    End Sub
    Private Sub disabledEcrWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call loadNotSupportedClients()
        Call NoGprsSupport()
        txtEcr.Enabled = False
        btnEnableEcr.Enabled = False
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
    Private Sub btnNotSupGprs_Click(sender As Object, e As EventArgs) Handles btnNotSupGprs.Click
        If CheckPermission2("A4B2F098385E4F7EAF2DA5C7D8A168AC") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Call CloseWindow("nErrorPhoneNumber")
        Dim f As New ErrorPhoneNumber
        AddChildForm("nErrorPhoneNumber", f)
    End Sub
    Private Sub cbEcr_CheckedChanged(sender As Object, e As EventArgs) Handles cbEcr.CheckedChanged
        If cbEcr.Checked Then
            txtEcr.Enabled = True
            btnEnableEcr.Enabled = True
        Else
            txtEcr.Enabled = False
            btnEnableEcr.Enabled = False
        End If
    End Sub
    Private Sub btnEnableEcr_Click(sender As Object, e As EventArgs) Handles btnEnableEcr.Click
        Try


            Dim ecr As String = txtEcr.Text.Trim
            Dim dt As DataTable = iDB.GetBlockedEcrDetails(ecr)
            If dt.Rows.Count < 1 Then
                Throw New Exception("Նշված ՀԴՄ-ն ակտիվ է")
            End If
            Dim hvhh = dt.Rows(0)("HVHH")
            Dim recID = dt.Rows(0)("RecID")
            Dim ecrType = dt.Rows(0)("Model")
            Dim op = dt.Rows(0)("Operator")

            Dim EcrToActivate = New gprsDelHvhhEcr(ecr, hvhh, recID, ecrType, op)

            Dim gphvhhecr As New List(Of gprsDelHvhhEcr)
            gphvhhecr.Add(EcrToActivate)

            Dim dataTable As DataTable = ToDataTable(gphvhhecr)

            Dim dict = RoutingManager.GroupHdmsByType(dataTable)

            For Each pair In dict
                Select Case pair.Key
                    Case HdmType.Ucom
                        iDB.EnableBlockedGPRS2(pair.Value)
                    Case HdmType.Vivacell
                        iDB.EnableBlockedGPRS(pair.Value)
                    Case HdmType.Beeline
                        iDB.EnableBlockedGPRS(pair.Value)
                    Case HdmType.Android
                        iDB.EnableBlockedGPRS3(pair.Value)
                    Case HdmType.Pax
                        iDB.EnableBlockedGPRS3(pair.Value)
                    Case Else
                End Select
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtEcr_TextChanged(sender As Object, e As EventArgs) Handles txtEcr.TextChanged
        If txtEcr.Text.Trim.Length = 1 Then
            If Microsoft.VisualBasic.Left(txtEcr.Text, 1).ToLower = "v" Then txtEcr.Text = "V90413" : txtEcr.SelectionStart = Len(txtEcr.Text)
            If Microsoft.VisualBasic.Left(txtEcr.Text, 1).ToLower = "q" Then txtEcr.Text = "Q80414" : txtEcr.SelectionStart = Len(txtEcr.Text)
            If Microsoft.VisualBasic.Left(txtEcr.Text, 1).ToLower = "s" Then txtEcr.Text = "S90055" : txtEcr.SelectionStart = Len(txtEcr.Text)
            If Microsoft.VisualBasic.Left(txtEcr.Text, 1).ToLower = "a" Then txtEcr.Text = "A90022" : txtEcr.SelectionStart = Len(txtEcr.Text)
        End If
    End Sub
End Class