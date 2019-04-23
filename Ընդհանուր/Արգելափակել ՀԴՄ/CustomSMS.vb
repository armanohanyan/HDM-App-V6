Imports JamaaTech
Imports JamaaTech.Smpp
Imports JamaaTech.Smpp.Net
Imports JamaaTech.Smpp.Net.Client
Imports JamaaTech.Smpp.Net.Lib

Public Class CustomSMS

    Dim dtClient As DataTable

#Region "SMS"

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
    Private Sub SendSMSCustomClient(ByVal User_Tel As String, ByVal User_Message As String, companyX As Byte, ByVal ClientID As Integer)
        Try
            If companyX = 5 Then Throw New Exception("Կազմակերպությունը սխալ է նշված")

            'check if object is null
            If IsNothing(client) Then client = New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

            'connection String
            Dim iConnection = New With {.SystemID = "", .Password = "", .Port = 2775, .Host = "31.47.195.66", .Tel = ""}

            Dim NikitaAccount As DataTable = iDB.RetNikitaAccount(companyX)
            With iConnection
                .SystemID = NikitaAccount.Rows(0)("SystemID")
                .Password = NikitaAccount.Rows(0)("Password")
                .Tel = NikitaAccount.Rows(0)("Tel")
            End With

            'Select Case companyX
            '    Case 1
            '        With iConnection
            '            .SystemID = "hdmserve"
            '            .Password = "hU2qiEJ"
            '            .Tel = "HDM Serve"
            '        End With
            '    Case 2  'Arman 27.12.2017
            '        MessageBox.Show("Տամա Էլեկտրոնով SMS չի կարելի ուղարկել", "Սխալ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        'With iConnection
            '        '    .SystemID = "hdmtechnic"
            '        '    .Password = "Bj0v4h0"
            '        '    .Tel = "HDM Technic"
            '        'End With
            '    Case 3
            '        With iConnection
            '            .SystemID = "hdmtech"
            '            .Password = "zwYBstt"
            '            .Tel = "HDM Tech"
            '        End With
            '    Case 4
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

            msg.Text = User_Message

            'Message
            msg.DestinationAddress = "+374" & User_Tel

            client.SendMessage(msg)

            'Save to DB
            iDB.InsertSMSToClientByHVHH(companyX, ClientID, User_Message, User_Tel)

            Call KillClient(client)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Call KillClient(client)
        End Try
    End Sub

#End Region

    Dim ClientID As Integer = 0
    Dim SupporterID As Byte = 5

    Private Sub LoadAutocomplet()
        Try
            dtClient = iDB.AutoCompleteClientList()

            txtHVHH.AutoCompleteCustomSource.Clear()
            txtHVHH.AutoCompleteCustomSource.AddRange((From row In dtClient.Rows.Cast(Of DataRow)() Select CStr(row("ՀՎՀՀ"))).ToArray())

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            If txtHVHH.Text.Trim.Length <> 8 Then Throw New Exception("ՀՎՀՀ-ն սխալ է գրված")

            Dim hvhh As String = txtHVHH.Text.Trim

            ClientID = iDB.GetClientID(hvhh)
            If ClientID = 0 Then Throw New Exception("ՀՎՀՀ-ն չի հայտնաբերվոլ")
            SupporterID = iDB.GetClientSupporter(hvhh)
            If SupporterID = 5 Then Throw New Exception("Սպասարկողը անորոշ է")

            txtHVHH.Enabled = False
            btnCheck.Enabled = False

            lTel.Enabled = True
            txtMessage.Enabled = True
            btnSend.Enabled = True
            txtTel.Enabled = True

            lTel.Focus()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Try
            If txtTel.Text.Trim.Length <> 8 Then Throw New Exception("Հեռախոսահամարը լրիվ գրված չէ")
            If txtMessage.Text.Trim = String.Empty Then Throw New Exception("Հաղորդագրությունը գրված չէ")

            SendSMSCustomClient(txtTel.Text.Trim, txtMessage.Text.Trim, SupporterID, ClientID)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub CustomSMS_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadAutocomplet()
    End Sub

End Class