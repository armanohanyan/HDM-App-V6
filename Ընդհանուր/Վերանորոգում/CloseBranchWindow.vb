Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Imports JamaaTech
Imports JamaaTech.Smpp
Imports JamaaTech.Smpp.Net
Imports JamaaTech.Smpp.Net.Client
Imports JamaaTech.Smpp.Net.Lib

Public Class CloseBranchWindow

#Region "SMS"

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
    Private Sub SendSMSToCenterForRemake(ByVal message As String, ByVal ToTel As String, ByVal ecr As String)
        Try
            'check if object is null
            If IsNothing(client) Then client = New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

            'connection String
            Dim iConnection = New With {.SystemID = "hdmserve2", .Password = "hdmsrv22", .Port = 2775, .Host = "31.47.195.66", .Tel = "HDM Serve"}

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

            msg.Text = message

            'message
            msg.DestinationAddress = "+374" & ToTel

            'send sms
            client.SendMessage(msg)

            'save to db
            iDB.SMSToBranch(ecr)

            Call KillClient(client)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Call KillClient(client)
        End Try
    End Sub

#End Region

    Private Function GetTelNumber() As String
        Try

            Return iDB.RetTelNumber()

        Catch ex As Exception
            'Return "43263301" 'Qrist
            Return "98882680" 'Hegh
        End Try
    End Function
    Private Sub SendSmsToCenter(ByVal ecr As String)
        On Error Resume Next

        Dim s As String = ecr & " HDM veranorogumn avartvac e, hastatel hayty"
        Dim ToTel As String = GetTelNumber()

        ''Send SMS
        'SendSMSToCenterForRemake(s, ToTel, ecr)

        ''Save To DB
        'iDB.InsertSMSForREmake(ecr, iUser.LoginName)

    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub AddEnterClick()
        iDB.CloseBranch(txtEcr.Text.Trim, iUser.LoginName)
    End Sub
    Private Sub txtEcr_TextChanged(sender As Object, e As EventArgs) Handles txtEcr.TextChanged

        If txtEcr.Text.Trim.Length = 1 Then
            If txtEcr.Text.StartsWith("V") Then
                txtEcr.Text = txtEcr.Text.Replace("V", "V90413") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("v") Then
                txtEcr.Text = txtEcr.Text.Replace("v", "V90413") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("Q") Then
                txtEcr.Text = txtEcr.Text.Replace("Q", "Q80414") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("q") Then
                txtEcr.Text = txtEcr.Text.Replace("q", "Q80414") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("S") Then
                txtEcr.Text = txtEcr.Text.Replace("S", "S900552") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("s") Then
                txtEcr.Text = txtEcr.Text.Replace("s", "S900552") : txtEcr.SelectionStart = txtEcr.Text.Length
            End If
        End If

        If txtEcr.Text.Trim.Length <> 12 Then Exit Sub

        If Not (Microsoft.VisualBasic.Left(txtEcr.Text.Trim, 1).ToString.ToLower = "v" OrElse Microsoft.VisualBasic.Left(txtEcr.Text.Trim, 1).ToString.ToLower = "q" OrElse Microsoft.VisualBasic.Left(txtEcr.Text.Trim, 1).ToString.ToLower = "s") Then Exit Sub
        Try
            Call AddEnterClick()
            If cWorkIsDone.Checked = True Then Call SendSmsToCenter(txtEcr.Text.Trim)
            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            txtEcr.Text = String.Empty
            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub CloseBranchWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckPermission2("530A530EECC8487A94F1E939238CFCC5") = False Then txtEcr.Enabled = False
    End Sub

End Class