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

Public Class SendHVHHSMSWindow

    Private iDuration As String = "00:00"

    Dim o As Byte

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

    Private Sub client_ConnectionStateChanged(sender As System.Object, e As ConnectionStateChangedEventArgs) Handles Client.ConnectionStateChanged
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
    Private Sub SendSMSCustomClient(ByVal dt As DataTable, ByRef f As Form, ByVal s As String, companyX As Company_XXX)
        Try
            If companyX = Company_XXX.Undefined Then Throw New Exception("Կազմակերպությունը սխալ է նշված")

            'check if object is null
            If IsNothing(client) Then client = New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

            'connection String
            Dim iConnection = New With {.SystemID = "", .Password = "", .Port = 2775, .Host = "31.47.195.66", .Tel = ""}

            Dim NikitaAccount As DataTable = iDB.RetNikitaAccount(o)
            With iConnection
                .SystemID = NikitaAccount.Rows(0)("SystemID")
                .Password = NikitaAccount.Rows(0)("Password")
                .Tel = NikitaAccount.Rows(0)("Tel")
            End With

            'Select Case companyX
            '    Case Company_XXX.HDM_Shtrikh
            '        With iConnection
            '            .SystemID = "hdmserve"
            '            .Password = "hU2qiEJ"
            '            .Tel = "HDM Serve"
            '        End With
            '    Case Company_XXX.Tama_Electron 'Arman 27.12.2017
            '        MessageBox.Show("Տամա Էլեկտրոնով SMS չի կարելի ուղարկել", "Սխալ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        'With iConnection
            '        '    .SystemID = "hdmtechnic"
            '        '    .Password = "Bj0v4h0"
            '        '    .Tel = "HDM Technic"
            '        'End With
            '    Case Company_XXX.Mery_Krist
            '        With iConnection
            '            .SystemID = "hdmtech"
            '            .Password = "zwYBstt"
            '            .Tel = "HDM Tech"
            '        End With
            '    Case Company_XXX.Touch_Master
            '        With iConnection
            '            .SystemID = "hdmmaster"
            '            .Password = "dBASS12"
            '            .Tel = "HDM Master"
            '        End With
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

                msg.Text = s

                'Message
                msg.DestinationAddress = "+374" & Microsoft.VisualBasic.Right(dt.Rows(i)("tel"), 8)

                client.SendMessage(msg)

                f.Text = dt.Rows.Count & " / " & i + 1
                f.Refresh()

                'Save to DB
                iDB.InsertSMSToClientByHVHH(companyX, dt.Rows(i)("id"), s, dt.Rows(i)("tel"))

                Threading.Thread.Sleep(300)
                My.Application.DoEvents()
            Next

            Call KillClient(client)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Call KillClient(client)
        End Try
    End Sub

#End Region

    Private Sub SendHVHHSMSWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
            If CheckPermission2("853052F65B214C0F8F8B43B079046616") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim dt As DataTable = Nothing

            formX.Show() : My.Application.DoEvents()

            If rbShtrikh.Checked Then o = 1
            If rbTama.Checked Then o = 2
            If rbMK.Checked Then o = 3
            If rbTouch.Checked Then o = 4
            If rbSmart.Checked Then o = 8
            If rbTorp.Checked Then o = 10

            sTime = Now
            dt = iDB.GetCustomClientForSMS(o)
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
    Private Sub btnSent_Click(sender As Object, e As EventArgs) Handles btnSent.Click
        Dim formX As New Working
        Try
            If CheckPermission2("99FBC12EFABC47A38442BFB53241FA1D") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If String.IsNullOrEmpty(txtMessage.Text) Then Throw New Exception("Հաղորդագրությունը գրված չէ")

            Dim s As String = txtMessage.Text.Trim

            GridView1.ClearColumnsFilter()
            GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)

            If GridView1.RowCount = 0 Then MsgBox("Նշված գրանցումներ չկան", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

            formX.Show() : My.Application.DoEvents()

            btnLoad.Enabled = False
            btnSent.Enabled = False

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
                    iCompany = Company_XXX.Touch_Master
                Case 4
                    iCompany = Company_XXX.Touch_Master
            End Select

            Dim l As New List(Of ForSmS)

            For i As Integer = 0 To GridView1.RowCount - 1
                l.Add(New ForSmS(GridView1.GetRowCellValue(i, "ՀՎՀՀ"), GridView1.GetRowCellValue(i, "Հեռախոս"), GridView1.GetRowCellValue(i, "ClientID")))
            Next

            Dim dt As DataTable = ToDataTable(l)

            SendSMSCustomClient(dt, formX, s, iCompany)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            txtMessage.Text = String.Empty
            txtMessage.Focus()
            formX.Close()
            formX = Nothing
            GridView1.ClearColumnsFilter()
            btnLoad.Enabled = True
            btnSent.Enabled = True
        End Try
    End Sub
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Try
            If CheckPermission2("56783F618D244AF793667F3FB6EE2BE0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.RowCount = 0 Then Throw New Exception("Ցանկը դատարկ է")

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

                GridView1.ClearColumnsFilter()

                For i As Int32 = 0 To GridView1.RowCount - 1
                    GridView1.SetRowCellValue(i, "Նշիչ", False)
                Next

                For i As Int32 = 0 To GridView1.RowCount - 1
                    For j As Integer = 0 To dt.Rows.Count - 1
                        If GridView1.GetRowCellValue(i, "ՀՎՀՀ") = dt.Rows(j)(0) Then GridView1.SetRowCellValue(i, "Նշիչ", True)
                    Next
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
    Private Sub SendHVHHSMSWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
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