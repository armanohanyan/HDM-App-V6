Imports JamaaTech
Imports JamaaTech.Smpp
Imports JamaaTech.Smpp.Net
Imports JamaaTech.Smpp.Net.Client
Imports JamaaTech.Smpp.Net.Lib

Public Class ApproveProposal

    Friend isReplacedExists As Boolean = False

    Friend RemakeID As Integer
    Friend EcrID As Integer
    Friend ClientID As Integer
    Friend hvhh As String
    Friend SupporterID As Byte
    Friend ECR As String
    Friend SupporterEcr As String

#Region "SMS"

    Dim WithEvents client As New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}
    Private isConnected As Boolean

    Enum Company_XXX
        HDM_Shtrikh = 1
        Tama_Electron = 2
        Mery_Krist = 3
        Touch_Master = 4
        Undefined = 5
    End Enum
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
    Private Sub SendSMSForEcrToClient(ByVal RemakeID As Integer, ByVal hvhh As String, ByVal ClientID As Integer, ByVal ecr As String, ByVal EcrID As Integer, ByVal Tel As String, ByVal sMessage As String, ByVal user As String, companyX As Company_XXX)
        Try
            If companyX = Company_XXX.Undefined Then Throw New Exception("Սպասարկող կազմակերպությունը անհայտ է")

            'check if object is null
            If IsNothing(client) Then client = New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

            'connection String
            Dim iConnection = New With {.SystemID = "", .Password = "", .Port = 2775, .Host = "31.47.195.66", .Tel = ""}

            Select Case companyX
                Case Company_XXX.HDM_Shtrikh
                    With iConnection
                        .SystemID = "hdmserve"
                        .Password = "hU2qiEJ"
                        .Tel = "HDM Serve"
                    End With
                Case Company_XXX.Tama_Electron 'Arman 27.12.2017
                    MessageBox.Show("Տամա Էլեկտրոնով SMS չի կարելի ուղարկել", "Սխալ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'With iConnection
                    '    .SystemID = "hdmtechnic"
                    '    .Password = "Bj0v4h0"
                    '    .Tel = "HDM Technic"
                    'End With
                Case Company_XXX.Mery_Krist
                    With iConnection
                        .SystemID = "hdmtech"
                        .Password = "zwYBstt"
                        .Tel = "HDM Tech"
                    End With
                Case Company_XXX.Touch_Master
                    With iConnection
                        .SystemID = "hdmmaster"
                        .Password = "dBASS12"
                        .Tel = "HDM Master"
                    End With
            End Select

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

            msg.Text = sMessage

            'Message
            msg.DestinationAddress = "+374" & Tel

            client.SendMessage(msg)

            'Save to DB
            iDB.InsertHaytSMS(RemakeID, hvhh, ClientID, ecr, EcrID, companyX, sMessage, Tel, user)

            Call KillClient(client)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Call KillClient(client)
        End Try
    End Sub

#End Region

    Private Function isHDMExists(hdm As String) As Boolean
        Try
            Dim icount As Object = iDB.ProposalGeneralEcrCount(hdm)
            If IsDBNull(icount) OrElse icount = 0 Then Return False
            Return True
        Catch ex As ExceptionClass
            Return True
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            Return True
        Catch ex As Exception
            Call SoftException(ex)
            Return True
        End Try
    End Function
    Private Sub SentSMS2(iRemakeID As Integer)
        Try
            Dim strTel As String = iDB.GetTesuchRemakeDetails(iRemakeID)
            If strTel = String.Empty Then Exit Sub

            Dim iCompany As New Company_XXX
            Select Case SupporterID
                Case 1
                    iCompany = Company_XXX.HDM_Shtrikh
                Case 2
                    iCompany = Company_XXX.Tama_Electron
                Case 3
                    iCompany = Company_XXX.Mery_Krist
                Case 4
                    iCompany = Company_XXX.Touch_Master
                Case Else
                    iCompany = Company_XXX.Undefined
            End Select

            Dim SMSMessage As String = ECR & " hamari HDM-n veranorogvac e."

            'check if object is null
            If IsNothing(client) Then client = New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

            'connection String
            Dim iConnection = New With {.SystemID = "", .Password = "", .Port = 2775, .Host = "31.47.195.66", .Tel = ""}

            Select Case iCompany
                Case Company_XXX.HDM_Shtrikh
                    With iConnection
                        .SystemID = "hdmserve"
                        .Password = "hU2qiEJ"
                        .Tel = "HDM Serve"
                    End With
                Case Company_XXX.Tama_Electron 'Arman 27.12.2017
                    MessageBox.Show("Տամա Էլեկտրոնով SMS չի կարելի ուղարկել", "Սխալ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'With iConnection
                    '    .SystemID = "hdmtechnic"
                    '    .Password = "Bj0v4h0"
                    '    .Tel = "HDM Technic"
                    'End With
                Case Company_XXX.Mery_Krist
                    With iConnection
                        .SystemID = "hdmtech"
                        .Password = "zwYBstt"
                        .Tel = "HDM Tech"
                    End With
                Case Company_XXX.Touch_Master
                    With iConnection
                        .SystemID = "hdmmaster"
                        .Password = "dBASS12"
                        .Tel = "HDM Master"
                    End With
            End Select

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

            msg.Text = SMSMessage

            'Message
            msg.DestinationAddress = "+374" & strTel

            client.SendMessage(msg)

            Dim TesuchName As String = iDB.GetTesuchNameRemakeDetails(iRemakeID)
            If Not String.IsNullOrEmpty(TesuchName) Then
                'Save to DB
                iDB.InsertSMSToTesuch(TesuchName, SMSMessage, strTel)
            End If

            Call KillClient(client)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub CreatePropTesuch(iRemakeID As Integer)
        Try
            If isHDMExists(ECR) = True Then Exit Sub
            Dim TesuchName As String = iDB.GetTesuchNameRemakeDetails(iRemakeID)
            If String.IsNullOrEmpty(TesuchName) Then Exit Sub
            iDB.AddGeneralPropAfterClose(ECR, TesuchName, iUser.LoginName, ECR & " hamari HDM-n veranorogvac e.")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GetTesuch(iRemakeID As Integer)
        Try
            lTesuch.Text = "Տեսուչ՝ " & iDB.GetTesuchNameRemakeDetails(iRemakeID)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Try
            'Հայտի հաստատում
            iDB.SetRemakeProposale(RemakeID, txtComment.Text.Trim)

            If SMSSendToTesuchP = True Then
                Call CreatePropTesuch(RemakeID)
            End If

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            'Me.Close()
            btnApprove.Enabled = False
            btnSMS.Enabled = True

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnSMS_Click(sender As Object, e As EventArgs) Handles btnSMS.Click
        Try
            'Get Info
            Dim dt As DataTable = iDB.GetTelNumberForHaytSMS(RemakeID, ClientID)
            If dt.Rows.Count = 0 Then Throw New Exception("Հեռախոսահամար չի ստացվել")

            Dim tel As String = String.Empty

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)(0) = "-" Then Continue For
                If dt.Rows(i)(0).ToString.Length < 8 Then Continue For
                If dt.Rows(i)(0).ToString.Length = 8 Then tel = dt.Rows(i)(0) : Exit For
                If dt.Rows(i)(0).ToString.Length >= 9 Then
                    tel = Microsoft.VisualBasic.Mid(dt.Rows(i)(0), 2, 8)
                    Exit For
                End If
            Next

            If tel = String.Empty Then Throw New Exception("Հեռախոսահամար չի ստացվել")

            Dim iCompany As New Company_XXX
            Select Case SupporterID
                Case 1
                    iCompany = Company_XXX.HDM_Shtrikh
                Case 2
                    iCompany = Company_XXX.Tama_Electron
                Case 3
                    iCompany = Company_XXX.Mery_Krist
                Case 4
                    iCompany = Company_XXX.Touch_Master
                Case Else
                    iCompany = Company_XXX.Undefined
            End Select

            Dim SupporterTel As String = String.Empty
            Select Case SupporterID
                Case 1
                    SupporterTel = "060525276"
                Case 2
                    SupporterTel = "060545424"
                Case 3
                    SupporterTel = "060535378"
                Case 4
                    SupporterTel = "060506027"
            End Select

            'Message To Client
            Dim SMSMessage As String = String.Empty
            If isReplacedExists = True Then
                SMSMessage = "Hargeli gorcynker Dzer " & ECR & " hamari HDM-n veranorogvac e. Her " & SupporterTel  'Arman 
            Else
                SMSMessage = "Hargeli gorcynker Dzer " & ECR & " hamari HDM-n veranorogvac e. Her " & SupporterTel  'Arman 
            End If

            'Send SMS
            If bBarRemake = True Then SendSMSForEcrToClient(RemakeID, hvhh, ClientID, ECR, EcrID, tel, SMSMessage, iUser.LoginName, iCompany)

            If SMSSendToTesuchP = True Then
                Call SentSMS2(RemakeID)
            End If

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            btnSMS.Enabled = False
            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ApproveProposal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Get Info
            Dim dt As DataTable = iDB.GetTelNumberForHaytSMS(RemakeID, ClientID)
            If dt.Rows.Count = 0 Then Throw New Exception("Հեռախոսահամար չի ստացվել")

            Dim tel As String = String.Empty

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)(0) = "-" Then Continue For
                If dt.Rows(i)(0).ToString.Length < 8 Then Continue For
                If dt.Rows(i)(0).ToString.Length = 8 Then tel = dt.Rows(i)(0) : Exit For
                If dt.Rows(i)(0).ToString.Length >= 9 Then
                    tel = Microsoft.VisualBasic.Mid(dt.Rows(i)(0), 2, 8)
                    Exit For
                End If
            Next

            If tel <> String.Empty Then
                txtTel.Text = tel
            Else
                txtTel.Text = "Հեռախոս չկա"
                txtTel.BackColor = Color.Red
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ApproveProposal_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Dim dt As DataTable = iDB.GetInference(RemakeID)
            If dt.Rows.Count > 0 Then
                txtEzrakac.Text = dt.Rows(0)("Inference")
            End If

            Call GetTesuch(RemakeID)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class