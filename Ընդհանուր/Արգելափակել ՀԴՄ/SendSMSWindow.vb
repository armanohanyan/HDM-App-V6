Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils

Imports JamaaTech
Imports JamaaTech.Smpp
Imports JamaaTech.Smpp.Net
Imports JamaaTech.Smpp.Net.Client
Imports JamaaTech.Smpp.Net.Lib

Public Class SendSMSWindow

    Private iDuration As String = "00:00"

    Dim o As Byte = 0
    Dim iType As Boolean

#Region "SMS"

    Enum Company_XXX
        HDM_Shtrikh = 1
        Tama_Electron = 2
        Mery_Krist = 3
        Touch_Master = 4
        Smart_Solutions = 8
        Torpays = 10
        Undefined = 5
    End Enum

    Dim WithEvents client As New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}
    Private isConnected As Boolean

    Private Sub client_ConnectionStateChanged(sender As System.Object, e As ConnectionStateChangedEventArgs) Handles client.ConnectionStateChanged
        Select Case e.CurrentState
            Case SmppConnectionState.Closed
                'Connection Lost
                isConnected = False
            Case SmppConnectionState.Connected
                'A successful connection has been established
                isConnected = True
            Case SmppConnectionState.Connecting
                'A connection attemp is still on progress
                isConnected = False
            Case Else
                'No Status
                isConnected = False
        End Select
    End Sub
    Private Sub KillClient(ByRef c As SmppClient)
        On Error Resume Next
        If IsNothing(c) Then Exit Sub
        If c.Started = True Then c.Shutdown()
        c = Nothing
    End Sub
    Private Sub SendSMS(ByVal dt As DataTable, ByRef f As Form, companyX As Company_XXX, SMSType As Boolean, stopDate As String)
        Try
            If companyX = Company_XXX.Undefined Then Throw New Exception("Կազմակերպությունը սխալ է նշված")

            'check if object is null
            If IsNothing(client) Then client = New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

            'connection String
            Dim iConnection = New With {.SystemID = "", .Password = "", .Port = 2775, .Host = "31.47.195.66", .Tel = ""}
            Dim strTel As String = String.Empty

            Dim NikitaAccount As DataTable = iDB.RetNikitaAccount(o)
            With iConnection
                .SystemID = NikitaAccount.Rows(0)("SystemID")
                .Password = NikitaAccount.Rows(0)("Password")
                .Tel = NikitaAccount.Rows(0)("Tel")
            End With
            strTel = NikitaAccount.Rows(0)("strTel")

            'Select Case companyX
            '    Case Company_XXX.HDM_Shtrikh
            '        With iConnection
            '            .SystemID = "hdmserve3"
            '            .Password = "hdmsrv33"
            '            .Tel = "HDM Serve"
            '        End With

            '        strTel = "060525276"
            '    Case Company_XXX.Tama_Electron 'Arman 27.12.2017
            '        MessageBox.Show("Տամա Էլեկտրոնով SMS չի կարելի ուղարկել", "Սխալ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        'With iConnection
            '        '    .SystemID = "hdmtechnic"
            '        '    .Password = "Bj0v4h0"
            '        '    .Tel = "HDM Technic"
            '        'End With

            '        strTel = "060545424"
            '    Case Company_XXX.Mery_Krist
            '        With iConnection
            '            .SystemID = "hdmtech"
            '            .Password = "zwYBstt"
            '            .Tel = "HDM Tech"
            '        End With

            '        strTel = "060535378"
            '    Case Company_XXX.Touch_Master
            '        With iConnection
            '            .SystemID = "hdmmaster"
            '            .Password = "dBASS12"
            '            .Tel = "HDM Master"
            '        End With

            '        strTel = "060506027"
            'End Select

            'set properties
            Dim properties As SmppConnectionProperties = client.Properties
            With properties
                .SystemID = iConnection.SystemID
                .Password = iConnection.Password
                .Port = iConnection.Port
                .Host = iConnection.Host
                .SystemType = ""
                .DefaultServiceType = "0"
            End With

            'start client
            If client.Started = False Then client.Start()

            'check if connected
            Dim j As Integer = 0
            Do While isConnected = False
                j += 1
                Threading.Thread.Sleep(200)
                If j = 40 Then Exit Do
            Loop

            'text message object
            Dim msg As New TextMessage()
            With msg
                .RegisterDeliveryNotification = False
                .SourceAddress = iConnection.Tel
            End With

            For i As Integer = 0 To dt.Rows.Count - 1
                If isConnected = False Then Throw New Exception("Կապը բացակայում է")
                If dt.Rows(i)("tel") = "-" Then Continue For

                'Message
                If SMSType = True Then
                    msg.Text = "Hargeli gorcynker HVHH " & dt.Rows(i)("hvhh") & " Dzez matucvox tsarayutyunnery masnaki dadarecvats en. Xndrum enq katarel vjarum versksman hamar.Her " & strTel
                Else
                    msg.Text = "Hargeli gorcynker HVHH " & dt.Rows(i)("hvhh") & " Dzer kazmakerputyuny uni chkatarvac vjarum. Xndrum enq katarel ayn. Carayutyunneri dadarecman amsativ " & stopDate & " Her." & strTel
                End If

                msg.DestinationAddress = "+374" & Microsoft.VisualBasic.Right(dt.Rows(i)("tel"), 8)

                client.SendMessage(msg)

                f.Text = dt.Rows.Count & " / " & i + 1
                f.Refresh()

                'Save to DB
                iDB.InsertSMS(companyX, dt.Rows(i)("ID"), SMSType, Microsoft.VisualBasic.Right(dt.Rows(i)("tel"), 8))

                Threading.Thread.Sleep(300)
                My.Application.DoEvents()
            Next

            '////////////////////////////////////////////////
            'Custom Send SMS
            msg.DestinationAddress = "+37495999997"
            If SMSType = True Then
                msg.Text = "CompanyID` " & companyX.ToString & " , Type` Kasecum"
            Else
                msg.Text = "CompanyID` " & companyX.ToString & " , Type` Kasecman Entaka"
            End If

            client.SendMessage(msg)
            '////////////////////////////////////////////////

            Call KillClient(client)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Call KillClient(client)
        End Try
    End Sub

#End Region

    Private Sub SendSMSWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            If CheckPermission2("55D16461C7BB41FCB969D1A0D7879374") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim dt As DataTable = Nothing

            formX.Show() : My.Application.DoEvents()

            If rbShtrikh.Checked Then o = 1
            If rbTama.Checked Then o = 2
            If rbMK.Checked Then o = 3
            If rbTouch.Checked Then o = 4
            If rbSmart.Checked Then o = 8
            If rbTorp.Checked Then o = 10

            sTime = Now
            If rbBlocked.Checked = True Then
                iType = True
                dt = iDB.SmsToBlockedCompanies(o)
            Else
                iType = False
                If ckByPeriod.Checked = True Then
                    dt = iDB.SmsForBlockingByYearAndMonth(o, cbYear.SelectedItem, cbMonth.SelectedItem, cbSYear.SelectedItem, cbSMonth.SelectedItem)
                Else
                    dt = iDB.SmsForBlockingByInterval(o)
                End If
            End If
            eTime = Now

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()
            GridControl1.DataSource = Nothing

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ClientID").Visible = False
                .Columns("Պատկան").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("Պարտք").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
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
            Dim duration As TimeSpan = eTime - sTime
            iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
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
    Private Sub SendSMSWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Control.CheckForIllegalCrossThreadCalls = False
        With cbYear
            For i As Integer = 2014 To 2030
                .Items.Add(i)
            Next
            .SelectedItem = Now.Year
        End With
        With cbMonth
            For i As Integer = 1 To 12
                .Items.Add(i)
            Next
            .SelectedItem = Now.Month
        End With
        With cbSYear
            For i As Integer = 2014 To 2030
                .Items.Add(i)
            Next
            .SelectedItem = Now.Year
        End With
        With cbSMonth
            For i As Integer = 1 To 12
                .Items.Add(i)
            Next
            .SelectedItem = Now.Month
        End With
        With TimeX
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With
        With Timex2
            '.DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .Enabled = False
        End With
        If iUser.DB <> 5 Then
            If iUser.DB = 1 Then rbShtrikh.Checked = True
            If iUser.DB = 2 Then rbTama.Checked = True
            If iUser.DB = 3 Then rbMK.Checked = True
            If iUser.DB = 4 Then rbTouch.Checked = True

            rbShtrikh.Enabled = False
            rbTama.Enabled = False
            rbMK.Enabled = False
            rbTouch.Enabled = False
        End If

        btnLoadFromExcell.Enabled = False
        btnSendFromExcell.Enabled = False
    End Sub
    Private Sub rbBlocked_CheckedChanged(sender As Object, e As EventArgs) Handles rbBlocked.CheckedChanged
        If rbBlocked.Checked Then ckByPeriod.Enabled = False Else ckByPeriod.Enabled = True
    End Sub
    Private Sub btnSent_Click(sender As Object, e As EventArgs) Handles btnSent.Click
        Dim formX As New Working
        Try
            If CheckPermission2("272792D12BD14C8B8FFD879DD9BC0FEC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            GridView1.ClearColumnsFilter()
            GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)

            If GridView1.RowCount = 0 Then MsgBox("Նշված գրանցումներ չկան", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

            formX.Show() : My.Application.DoEvents()

            btnLoad.Enabled = False
            btnSent.Enabled = False

            Dim stopDate As String = Microsoft.VisualBasic.Right("00" & TimeX.DateTime.Day, 2) & "." & Microsoft.VisualBasic.Right("00" & TimeX.DateTime.Month, 2) & "." & TimeX.DateTime.Year

            Dim iCompany As New Company_XXX
            Select Case o
                Case 1
                    iCompany = Company_XXX.HDM_Shtrikh
                Case 2
                    iCompany = Company_XXX.Tama_Electron
                Case 3
                    iCompany = Company_XXX.Mery_Krist
                Case 4
                    iCompany = Company_XXX.Touch_Master
                Case 8
                    iCompany = Company_XXX.Smart_Solutions
                Case 10
                    iCompany = Company_XXX.Torpays
            End Select

            Dim l As New List(Of ForSmS)

            'List of Normal Clients
            For i As Integer = 0 To GridView1.RowCount - 1
                l.Add(New ForSmS(GridView1.GetRowCellValue(i, "ՀՎՀՀ"), GridView1.GetRowCellValue(i, "Հեռախոս"), GridView1.GetRowCellValue(i, "ClientID")))
            Next

            If cAllClients.Checked = True Then
                'List of Disabled Clients
                Dim DTNotSupportedClients As DataTable = iDB.SmsForBlockinNotSupportedClients(o)
                If DTNotSupportedClients.Rows.Count > 0 Then
                    For i As Integer = 0 To DTNotSupportedClients.Rows.Count - 1
                        l.Add(New ForSmS(DTNotSupportedClients.Rows(i)("ՀՎՀՀ"), DTNotSupportedClients.Rows(i)("Հեռախոս"), DTNotSupportedClients.Rows(i)("ClientID")))
                    Next
                End If
            End If

            Dim dt As DataTable = ToDataTable(l)

            SendSMS(dt, formX, iCompany, iType, stopDate)

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
            btnLoad.Enabled = True
            btnSent.Enabled = True
        End Try
    End Sub
    Private Sub rbShtrikh_CheckedChanged(sender As Object, e As EventArgs) Handles rbShtrikh.CheckedChanged

        GridControl1.BeginUpdate()
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        GridView1.ClearSelection()
        GridControl1.EndUpdate()

    End Sub
    Private Sub rbTama_CheckedChanged(sender As Object, e As EventArgs) Handles rbTama.CheckedChanged

        GridControl1.BeginUpdate()
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        GridView1.ClearSelection()
        GridControl1.EndUpdate()

    End Sub
    Private Sub rbMK_CheckedChanged(sender As Object, e As EventArgs) Handles rbMK.CheckedChanged

        GridControl1.BeginUpdate()
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        GridView1.ClearSelection()
        GridControl1.EndUpdate()

    End Sub
    Private Sub rbTouch_CheckedChanged(sender As Object, e As EventArgs) Handles rbTouch.CheckedChanged

        GridControl1.BeginUpdate()
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        GridView1.ClearSelection()
        GridControl1.EndUpdate()

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

    
    Private Sub cbLoadFromExcell_CheckedChanged(sender As Object, e As EventArgs) Handles cbLoadFromExcell.CheckedChanged
        If cbLoadFromExcell.Checked = True Then
            btnLoadFromExcell.Enabled = True
            btnSendFromExcell.Enabled = True
            btnLoad.Enabled = False
            btnSent.Enabled = False

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()
            GridControl1.DataSource = Nothing
            GridView1.ClearSelection()
            GridControl1.EndUpdate()
        ElseIf cbLoadFromExcell.Checked = False Then
            btnLoadFromExcell.Enabled = False
            btnSendFromExcell.Enabled = False
            btnLoad.Enabled = True
            btnSent.Enabled = True

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()
            GridControl1.DataSource = Nothing
            GridView1.ClearSelection()
            GridControl1.EndUpdate()
        End If
    End Sub
    Private Sub btnLoadFromExcell_Click(sender As Object, e As EventArgs) Handles btnLoadFromExcell.Click
        If CheckPermission2("56783F618D244AF793667F3FB6EE2BE0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

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

            ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT hvhh FROM [Sheet1$] WHERE hvhh IS NOT NULL", MyConnection)
            ExcelAdapter.TableMappings.Add("Table", "Excel Data")
            ExcelDataSet = New System.Data.DataSet
            ExcelAdapter.Fill(ExcelDataSet)
            Dim dt As DataTable = ExcelDataSet.Tables(0)
            MyConnection.Close()

            If dt.Rows.Count = 0 Then Exit Sub

            Dim l As New List(Of ForSmS2)

            For i = 0 To dt.Rows.Count - 1
                Dim dt2 As DataTable
                dt2 = iDB.PartqBySupporter2ForSMS(dt.Rows(i).Item(0))
                If dt2.Rows.Count > 0 Then
                    l.Add(New ForSmS2(dt2.Rows(0).Item(0), dt2.Rows(0).Item(5), dt2.Rows(0).Item(2), dt2.Rows(0).Item(3), dt2.Rows(0).Item(6)))
                End If
            Next
            Dim dt3 As DataTable = ToDataTable(l)


            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()
            GridControl1.DataSource = Nothing
            GridControl1.DataSource = dt3
            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("id").Visible = False
                '.Columns("Պատկան").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("Պարտք").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "Քանակ {0}")
                    GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
                End If
            End If
        End With
    End Sub
    Private Sub btnSendFromExcell_Click(sender As Object, e As EventArgs) Handles btnSendFromExcell.Click
        Dim formX As New Working
        Try
            If CheckPermission2("272792D12BD14C8B8FFD879DD9BC0FEC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            'GridView1.ClearColumnsFilter()
            'GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)

            If GridView1.RowCount = 0 Then MsgBox("Նշված գրանցումներ չկան", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

            formX.Show() : My.Application.DoEvents()

            btnLoadFromExcell.Enabled = False
            btnSendFromExcell.Enabled = False

            'Dim stopDate As String = Microsoft.VisualBasic.Right("00" & TimeX.DateTime.Day, 2) & "." & Microsoft.VisualBasic.Right("00" & TimeX.DateTime.Month, 2) & "." & TimeX.DateTime.Year

           

            Dim l As New List(Of ForSmS2)

            'List Clients
            For i As Integer = 0 To GridView1.RowCount - 1
                l.Add(New ForSmS2(GridView1.GetRowCellValue(i, "ՀՎՀՀ"), GridView1.GetRowCellValue(i, "Հեռախոս"), GridView1.GetRowCellValue(i, "Պարտք"), GridView1.GetRowCellValue(i, "Սպասարկող"), GridView1.GetRowCellValue(i, "id")))
            Next

            'If cAllClients.Checked = True Then
            '    'List of Disabled Clients
            '    Dim DTNotSupportedClients As DataTable = iDB.SmsForBlockinNotSupportedClients(o)
            '    If DTNotSupportedClients.Rows.Count > 0 Then
            '        For i As Integer = 0 To DTNotSupportedClients.Rows.Count - 1
            '            'l.Add(New ForSmS(DTNotSupportedClients.Rows(i)("ՀՎՀՀ"), DTNotSupportedClients.Rows(i)("Հեռախոս"), DTNotSupportedClients.Rows(i)("ClientID")))
            '        Next
            '    End If
            'End If

            Dim dt As DataTable = ToDataTable(l)

            SendSMS2(dt, formX)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            cbLoadFromExcell.Checked = False

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
            GridView1.ClearColumnsFilter()
            btnLoad.Enabled = True
            btnSent.Enabled = True
        End Try
    End Sub
    Private Sub SendSMS2(ByVal dt As DataTable, ByRef f As Form)
        Try
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim iCompany As New Company_XXX

                Dim supporter As String = dt.Rows(i)("Սպասարկող")
                Dim op As Integer
                Select Case supporter
                    Case """ՀԴՄ Շտրիխ"" ՍՊԸ"
                        iCompany = Company_XXX.HDM_Shtrikh
                        op = 1
                    Case """Տամա Էլեկտրոն"" ՍՊԸ"
                        iCompany = Company_XXX.Tama_Electron
                        op = 2
                    Case """ՄԵՐԻ-ՔՐԻՍՏ"" ՍՊԸ"
                        iCompany = Company_XXX.Mery_Krist
                        op = 3
                    Case """Տոչ-մաստեր"" ՍՊԸ"
                        iCompany = Company_XXX.Touch_Master
                        op = 4
                    Case """Սմարթ Սոլուշնս"" ՍՊԸ"
                        iCompany = Company_XXX.Touch_Master
                        op = 8
                    Case """Թորփայս"" ՍՊԸ"
                        iCompany = Company_XXX.Touch_Master
                        op = 10
                End Select

                'If companyX = Company_XXX.Undefined Then Throw New Exception("Կազմակերպությունը սխալ է նշված")

                'check if object is null
                If IsNothing(client) Then client = New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

                'connection String
                Dim iConnection = New With {.SystemID = "", .Password = "", .Port = 2775, .Host = "31.47.195.66", .Tel = ""}
                Dim strTel As String = String.Empty

                Dim NikitaAccount As DataTable = iDB.RetNikitaAccount(op)
                With iConnection
                    .SystemID = NikitaAccount.Rows(0)("SystemID")
                    .Password = NikitaAccount.Rows(0)("Password")
                    .Tel = NikitaAccount.Rows(0)("Tel")
                End With
                strTel = NikitaAccount.Rows(0)("strTel")

                'set properties
                Dim properties As SmppConnectionProperties = client.Properties
                With properties
                    .SystemID = iConnection.SystemID
                    .Password = iConnection.Password
                    .Port = iConnection.Port
                    .Host = iConnection.Host
                    .SystemType = ""
                    .DefaultServiceType = "0"
                End With

                'start client
                If client.Started = False Then client.Start()

                'check if connected
                Dim j As Integer = 0
                Do While isConnected = False
                    j += 1
                    Threading.Thread.Sleep(200)
                    If j = 40 Then Exit Do
                Loop

                'text message object
                Dim msg As New TextMessage()
                With msg
                    .RegisterDeliveryNotification = False
                    .SourceAddress = iConnection.Tel
                End With


                If isConnected = False Then Throw New Exception("Կապը բացակայում է")
                If dt.Rows(i)("Հեռախոս") = "-" Then Continue For

                'Message

                Dim blockDate As String = ""
                If Timex2.DateTime.Date > DateTime.Now Then
                    blockDate = ".Kasecman amsativ` " & Timex2.DateTime.Date
                End If

                If rbBlockedExcel.Checked Then
                    If op = 8 Then
                        msg.Text = dt.Rows(i)("ՀՎՀՀ") & " Dzer hashvekshiry kazmum e " & dt.Rows(i)("Պարտք") & " dr. Xndrum enq katarel vcharum ashxatanqy sharunakelu hamar. Smarts.am 060 400005․ Hashvehamar 220563330442000"
                    Else
                        msg.Text = "Hargeli gorcynker HVHH " & dt.Rows(i)("ՀՎՀՀ") & " Dzez matucvox tsarayutyunnery masnaki dadarecvats en. Xndrum enq katarel " & dt.Rows(i)("Պարտք") & " dram vjarum versksman hamar.Her " & strTel
                    End If
                ElseIf rbForBlockExcel.Checked = True Then
                    If op = 8 Then
                        msg.Text = dt.Rows(i)("ՀՎՀՀ") & "  Dzer hashvekshirn e " & dt.Rows(i)("Պարտք") & " dr. Xndrum enq katarel vcharum HDM-i anxapan ashxatanqi hamar. Smart Solutions 060 400005. Hashvehamar 220563330442000"
                    ElseIf op = 4 Then
                        'msg.Text = "Hargeli gorcynker HVHH " & dt.Rows(i)("ՀՎՀՀ") & " Dzer kazmakerputyunn uni partq " & dt.Rows(i)("Պարտք") & " dram.Xndrum enq katarel vjarum." 'Hashvehamar 217005026273001.Her " & strTel
                        'msg.Text = "Hargeli gorcynker HVHH " & dt.Rows(i)("ՀՎՀՀ") & " Dzer kazmakerputyunn uni partq " & dt.Rows(i)("Պարտք") & " dram.Xndrum enq katarel vjarum.Kasecman amsativ` " & TimeX2.DateTime.Date & ".Her " & strTel
                        msg.Text = "Hargeli gorcynker HVHH " & dt.Rows(i)("ՀՎՀՀ") & " Dzer kazmakerputyunn uni partq " & dt.Rows(i)("Պարտք") & "dr.Xndrum enq vjarel,H/H 217005026273001" & blockDate & ".Her " & strTel
                        'msg.Text = "test2"
                    Else
                        msg.Text = "Hargeli gorcynker HVHH " & dt.Rows(i)("ՀՎՀՀ") & " Dzer kazmakerputyunn uni partq " & dt.Rows(i)("Պարտք") & " dram.Xndrum enq katarel vjarum.Her " & strTel
                    End If
                End If

                'msg.Text = "Hargeli gorcynker HVHH " & dt.Rows(i)("ՀՎՀՀ") & " Dzer kazmakerputyunn uni partq " & dt.Rows(i)("Պարտք") & " dram.Xndrum enq katarel vjarum.Kasecman amsativ` 08.06.2020.Her " & strTel
                'msg.Text = "Hargeli gorcynker HVHH " & dt.Rows(i)("ՀՎՀՀ") & " Dzez matucvox tsarayutyunnery masnaki dadarecvats en. Xndrum enq katarel " & dt.Rows(i)("Պարտք") & " dram vjarum versksman hamar.Her " & strTel


                msg.DestinationAddress = "+374" & Microsoft.VisualBasic.Right(dt.Rows(i)("Հեռախոս"), 8)

                client.SendMessage(msg)

                f.Text = dt.Rows.Count & " / " & i + 1
                f.Refresh()

                'Save to DB
                iDB.InsertSMS(op, dt.Rows(i)("id"), 0, Microsoft.VisualBasic.Right(dt.Rows(i)("Հեռախոս"), 8))

                Threading.Thread.Sleep(300)
                My.Application.DoEvents()
                client.SendMessage(msg)
                If i = dt.Rows.Count - 1 Then
                    msg.DestinationAddress = "+37495999997"
                    msg.Text = "Partqi chapov SMS"
                    client.SendMessage(msg)
                End If

                Call KillClient(client)
            Next

            '////////////////////////////////////////////////
            'Custom Send SMS
            'msg.DestinationAddress = "+37495999997"
            'If SMSType = True Then
            '    msg.Text = "CompanyID` " & companyX.ToString & " , Type` Kasecum"
            'Else
            '    msg.Text = "CompanyID` " & companyX.ToString & " , Type` Kasecman Entaka"
            'End If


            '////////////////////////////////////////////////


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Call KillClient(client)
        End Try
    End Sub
    Private Sub rbBlockedExcel_CheckedChanged(sender As Object, e As EventArgs) Handles rbBlockedExcel.CheckedChanged
        Timex2.Enabled = False
    End Sub
    Private Sub rbForBlockExcel_CheckedChanged(sender As Object, e As EventArgs) Handles rbForBlockExcel.CheckedChanged
        Timex2.Enabled = True
    End Sub
End Class