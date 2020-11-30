Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports JamaaTech.Smpp.Net.Client

Public Class changeGeneralHaytInfo

    Friend haytTesuch As String = ""
    Friend haytHDM As String = ""
    Friend haytHVHH As String = ""
    Friend HaytCompany As String = ""
    Friend haytTel As String = ""
    Friend haytAddress As String = ""
    Friend haytID As Integer = -1
    Friend haytSpasarkox As String = ""
    Friend haytXndir As String = ""
    Friend haytDate As DateTime
    Friend haytRegion As String = ""
    Friend haytCreator As String = ""
    Friend problem As Integer = 0

    Friend haytEditTime As DateTime
    Friend clientTel As String = ""
    Friend message As String = ""
    Friend supporterID As Short = 0
    Friend clientID As Integer = 0

    Dim WithEvents client As New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}
    Private isConnected As Boolean

    Private Sub LoadTesuch()
        Try
            Dim dt As DataTable = iDB.GetWorkingTesuchList()
            With cbTesuch
                .DataSource = dt
                .DisplayMember = "Տեսուչ"
                .ValueMember = "ՀՀ"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadRegion()
        Try
            Dim dt As DataTable = iDB.GetRegion
            With cbRegion
                .DataSource = dt
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "Տարածաշրջան"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadSupporter()
        Try
            Try
                Dim dt As DataTable = iDB.GetSupporter()
                With cbSupporter
                    .DataSource = dt
                    .DisplayMember = "Կազմակերպություն"
                    .ValueMember = "ՀՀ"
                End With
            Catch ex As ExceptionClass
            Catch ex As System.Data.SqlClient.SqlException
                Call SQLException(ex)
            Catch ex As Exception
                Call SoftException(ex)
            End Try
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub haytchangetesuch_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Call LoadTesuch()
        Call LoadSupporter()
        Call LoadRegion()

        cbTesuch.Text = haytTesuch
        cbSupporter.Text = haytSpasarkox
        cbRegion.Text = haytRegion
        cProb.SelectedIndex = problem

        txtEcr.Text = haytHDM
        txtHvhh.Text = haytHVHH
        txtClient.Text = HaytCompany
        txtTel.Text = haytTel
        txtAddress.Text = haytAddress
        txtProblem.Text = haytXndir

        With ApprDate
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .DateTime = haytDate
        End With
        haytEditTime = haytDate

        iDB.AddProposalGeneralEdited(txtEcr.Text.Trim, txtHvhh.Text.Trim, txtClient.Text.Trim, cbTesuch.Text, txtTel.Text.Trim, txtAddress.Text.Trim, cbSupporter.SelectedValue, haytID, txtProblem.Text.Trim, ApprDate.DateTime, cbRegion.SelectedValue, haytCreator.ToString)
    End Sub
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            If haytHDM <> txtEcr.Text.Trim OrElse haytHVHH <> txtHvhh.Text.Trim OrElse HaytCompany <> txtClient.Text.Trim _
                OrElse haytTel <> txtTel.Text.Trim OrElse haytAddress <> txtAddress.Text.Trim OrElse haytSpasarkox <> cbSupporter.Text.Trim OrElse _
                haytXndir <> txtProblem.Text.Trim OrElse haytRegion <> cbRegion.Text.Trim OrElse problem <> cProb.SelectedIndex Then
                If iDB.IsProposalEquipmentSold(haytID) = True Then Throw New Exception("Հայտը խմբագրման ենթակա չէ, քանի որ վաճառքն արդեն իսկ իրականացված է։")
            End If


            iDB.UpdateProposalGeneral(txtEcr.Text.Trim, txtHvhh.Text.Trim, txtClient.Text.Trim, cbTesuch.Text, txtTel.Text.Trim, txtAddress.Text.Trim, cbSupporter.SelectedValue, haytID, txtProblem.Text.Trim, ApprDate.DateTime, cbRegion.SelectedValue, cProb.SelectedIndex)

            'If haytEditTime <> ApprDate.DateTime Then
            '    clientTel = haytTel
            '    'clientTel = "041704740" 'haytTel
            '    message = "Hargeli hajaxord tesuch@ Dzez kmotena " & ApprDate.Text.ToString & " -in"
            '    supporterID = cbSupporter.SelectedValue
            '    clientID = iDB.GetClientID(haytHVHH)

            '    'SendSMSCustomClient(clientTel, message, supporterID, clientID)
            '    'MsgBox(clientTel.ToString & vbCrLf & message.ToString & vbCrLf & supporterID & vbCrLf & clientID)

            'End If
            'MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub


    Private Sub SendSMS()
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

            msg.Text = "" ' txtMessage.Text.Trim

            'Message
            msg.DestinationAddress = "+374" ' & I_Tel

            client.SendMessage(msg)

            'Save to DB
            'iDB.InsertSMSToTesuchActiv(I_Tesuch, txtMessage.Text.Trim, I_Tel, I_PropID)

            Call KillClient(client)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Call KillClient(client)
        End Try
    End Sub

    Private Sub KillClient(ByRef c As SmppClient)
        On Error Resume Next
        If IsNothing(c) Then Exit Sub
        If c.Started = True Then c.Shutdown()
        c = Nothing
    End Sub

    '#Region "SMS"

    '    Dim WithEvents client As New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}
    '    Private isConnected As Boolean


    '    Private Sub client_ConnectionStateChanged(sender As System.Object, e As ConnectionStateChangedEventArgs) Handles client.ConnectionStateChanged
    '        Select Case e.CurrentState
    '            Case SmppConnectionState.Closed
    '                'Connection Lost
    '                isConnected = False
    '            Case SmppConnectionState.Connected
    '                'A successful connection has been established
    '                isConnected = True
    '            Case SmppConnectionState.Connecting
    '                'A connection attemp is still on progress
    '                isConnected = False
    '            Case Else
    '                'No Status
    '                isConnected = False
    '        End Select
    '    End Sub
    '    Private Sub KillClient(ByRef c As SmppClient)
    '        On Error Resume Next
    '        If IsNothing(c) Then Exit Sub
    '        If c.Started = True Then c.Shutdown()
    '        c = Nothing
    '    End Sub
    '    Private Sub SendSMSCustomClient(ByVal User_Tel As String, ByVal User_Message As String, companyX As Byte, ByVal ClientID As Integer)
    '        Try
    '            If companyX = 5 Then Throw New Exception("Կազմակերպությունը սխալ է նշված")

    '            'check if object is null
    '            If IsNothing(client) Then client = New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

    '            'connection String
    '            Dim iConnection = New With {.SystemID = "", .Password = "", .Port = 2775, .Host = "31.47.195.66", .Tel = ""}

    '            Dim NikitaAccount As DataTable = iDB.RetNikitaAccount(companyX)
    '            With iConnection
    '                .SystemID = NikitaAccount.Rows(0)("SystemID")
    '                .Password = NikitaAccount.Rows(0)("Password")
    '                .Tel = NikitaAccount.Rows(0)("Tel")
    '            End With

    '            'Select Case companyX
    '            '    Case 1
    '            '        With iConnection
    '            '            .SystemID = "hdmserve"
    '            '            .Password = "hU2qiEJ"
    '            '            .Tel = "HDM Serve"
    '            '        End With
    '            '    Case 2  'Arman 27.12.2017
    '            '        MessageBox.Show("Տամա Էլեկտրոնով SMS չի կարելի ուղարկել", "Սխալ", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            '        'With iConnection
    '            '        '    .SystemID = "hdmtechnic"
    '            '        '    .Password = "Bj0v4h0"
    '            '        '    .Tel = "HDM Technic"
    '            '        'End With
    '            '    Case 3
    '            '        With iConnection
    '            '            .SystemID = "hdmtech"
    '            '            .Password = "zwYBstt"
    '            '            .Tel = "HDM Tech"
    '            '        End With
    '            '    Case 4
    '            '        With iConnection
    '            '            .SystemID = "hdmmaster"
    '            '            .Password = "dBASS12"
    '            '            .Tel = "HDM Master"
    '            '        End With
    '            'End Select

    '            'set properties
    '            Dim properties As SmppConnectionProperties = client.Properties
    '            With properties
    '                .SystemID = iConnection.SystemID
    '                .Password = iConnection.Password
    '                .Port = iConnection.Port
    '                .Host = iConnection.Host
    '                .SystemType = ""
    '                .DefaultServiceType = "0"
    '            End With

    '            'start client
    '            If client.Started = False Then client.Start()

    '            'check if connected
    '            Dim j As Integer = 0
    '            Do While isConnected = False
    '                j += 1
    '                Threading.Thread.Sleep(200)
    '                If j = 40 Then Exit Do
    '            Loop

    '            'text message object
    '            Dim msg As New TextMessage()
    '            With msg
    '                .RegisterDeliveryNotification = False
    '                .SourceAddress = iConnection.Tel
    '            End With

    '            msg.Text = User_Message

    '            'Message
    '            msg.DestinationAddress = "+374" & User_Tel

    '            client.SendMessage(msg)

    '            'Save to DB
    '            iDB.InsertSMSToClientByHVHH(companyX, ClientID, User_Message, User_Tel)

    '            Call KillClient(client)
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
    '            Call KillClient(client)
    '        End Try
    '    End Sub

    '    '#End Region
End Class