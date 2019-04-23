Imports JamaaTech
Imports JamaaTech.Smpp
Imports JamaaTech.Smpp.Net
Imports JamaaTech.Smpp.Net.Client
Imports JamaaTech.Smpp.Net.Lib

Public Class CallSmsActivate

    Friend I_Tesuch As String
    Friend I_Tel As String
    Friend I_PropID As Integer

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
    Private Sub SendSMSToTEsuch()
        Try
            'check if object is null
            If IsNothing(client) Then client = New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

            'connection String
            Dim iConnection = New With {.SystemID = "", .Password = "", .Port = 2775, .Host = "31.47.195.66", .Tel = ""}
            Dim NikitaAccount As DataTable = iDB.RetNikitaAccount()
            With iConnection
                .SystemID = NikitaAccount.Rows(0)("SystemID")
                .Password = NikitaAccount.Rows(0)("Password")
                .Tel = NikitaAccount.Rows(0)("Tel")
            End With

            'Select Case iUser.DB
            '    Case 1
            '        iConnection.SystemID = "hdmserve1"
            '        iConnection.Password = "hdmsrv11"
            '    Case 2
            '        iConnection.SystemID = "hdmserve2"
            '        iConnection.Password = "hdmsrv22"
            '    Case 3
            '        iConnection.SystemID = "hdmserve3"
            '        iConnection.Password = "hdmsrv33"
            '    Case 4
            '        iConnection.SystemID = "hdmserve4"
            '        iConnection.Password = "hdmsrv44"
            '    Case 5
            '        iConnection.SystemID = "hdmserve4"
            '        iConnection.Password = "hdmsrv44"
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

            If isConnected = False Then Throw New Exception("Կապը բացակայում է")

            msg.Text = txtMessage.Text.Trim

            'Message
            msg.DestinationAddress = "+374" & I_Tel

            client.SendMessage(msg)

            'Save to DB
            iDB.InsertSMSToTesuchActiv(I_Tesuch, txtMessage.Text.Trim, I_Tel, I_PropID)

            Call KillClient(client)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Call KillClient(client)
        End Try
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If txtMessage.Text.Trim = String.Empty Then MsgBox("Հաղորդագրությունը բացակայում է", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        btnSend.Enabled = False

        Call SendSMSToTEsuch()

        Me.Close()

    End Sub
    Private Sub CallSmsActivate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtTesuch.Text = I_Tesuch
        txtTel.Text = I_Tel
    End Sub

End Class