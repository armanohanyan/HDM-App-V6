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

            sTime = Now
            If rbBlocked.Checked = True Then
                iType = True
                dt = iDB.SmsToBlockedCompanies(o)
            Else
                iType = False
                If ckByPeriod.Checked = True Then
                    dt = iDB.SmsForBlockingByYearAndMonth(o, cbYear.SelectedItem, cbMonth.SelectedItem)
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
        With TimeX
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
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

End Class