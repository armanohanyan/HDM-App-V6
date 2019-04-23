Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports JamaaTech
Imports JamaaTech.Smpp
Imports JamaaTech.Smpp.Net
Imports JamaaTech.Smpp.Net.Client
Imports JamaaTech.Smpp.Net.Lib

Public Class AktRefuse

    Dim formResult As Boolean = False
    Friend ԱկտՀԴՄ As String = ""
    Dim dt As System.Data.DataTable
    Dim strRandom As String = ""
    Friend RemakeID As Integer = 0

    Friend Function Result() As Boolean
        Return formResult
    End Function
    Private Sub _getInfo()
        Try
            dt = iDB.GetClientInfoForRefuseAkt(ԱկտՀԴՄ)
            If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չեն ստացվել")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Me.Close()
        End Try
    End Sub
    Private Sub AktRefuse_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtPrinterName.Text = strPrinter
        _getInfo()
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectPrinter.Click
        Dim f As New SelectPrinter
        f.ShowDialog()
        f = Nothing
        txtPrinterName.Text = strPrinter
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles txtPrintAkt.Click
        Try
            If String.IsNullOrEmpty(strPrinter) Then MsgBox("Տպիչը նշված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
            If txtReason.Text.Trim = String.Empty Then Throw New Exception("Մերժման պատճառը գրված չէ")

            'Save To DB

            iDB.MakeRefuse(RemakeID, iUser.UserID, txtReason.Text.Trim)

            'Export To Excel
            Dim r As New Random
            strRandom = r.Next(1000000000, Integer.MaxValue)

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\HDM AKT"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\Temp"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            My.Computer.FileSystem.WriteAllBytes(strPath & "\" & strRandom & ".xls", My.Resources.aktmerjel, False)

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(strPath & "\" & strRandom & ".xls")
            xlApp.DisplayAlerts = False
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

            With sheet.PageSetup
                .PrintTitleRows = ""
                .PrintTitleColumns = ""

                .PrintArea = ""
                'Set Paper Size To A4
                .PaperSize = XlPaperSize.xlPaperA4

                .Zoom = 95
            End With

            With sheet
                .Range("G2").Value = Date.Now.ToString("dd.MM.yyyy")
                .Range("G24").Value = Date.Now.ToString("dd.MM.yyyy")

                .Range("A4").Value = Chr(34) & dt.Rows(0)("Անվանում") & Chr(34) & "-ը ի դեմս " & dt.Rows(0)("Տնօրեն2") & "-ի, այսուհետ՝ Պատվիրատու և " & dt.Rows(0)("Կազմակերպություն") & "-ը ի դեմս տնօրեն " & dt.Rows(0)("Տնօրեն") & "-ի, այսուհետ՝ Կատարող, կազմեցին սույն արձանագրությունը հետևյալի մասին."
                .Range("A26").Value = Chr(34) & dt.Rows(0)("Անվանում") & Chr(34) & "-ը ի դեմս " & dt.Rows(0)("Տնօրեն2") & "-ի, այսուհետ՝ Պատվիրատու և " & dt.Rows(0)("Կազմակերպություն") & "-ը ի դեմս տնօրեն " & dt.Rows(0)("Տնօրեն") & "-ի, այսուհետ՝ Կատարող, կազմեցին սույն արձանագրությունը հետևյալի մասին."

                .Range("A8").Value = "1. Կատարողը Պատվիրատուի կամքին ընդառաջ Պատվիրատուին պատկանող MF2351 մոդելի " & ԱկտՀԴՄ & " գործարանային համարով հսկիչ դրամարկղային մեքենայի վերանորգման աշխատանքներ չի իրականացրել:" & vbCrLf & "2. Սույն արձանագրության ստորագրման պահից հավաստիացվում է, որ  Կատարողը Պատվիրատուին է հանձնել Պատվիրատուին պատկանող MF2351 մոդելի " & ԱկտՀԴՄ & " գործարանային համարով հսկիչ դրամարկղային մեքենան:"
                .Range("A30").Value = "1. Կատարողը Պատվիրատուի կամքին ընդառաջ Պատվիրատուին պատկանող MF2351 մոդելի " & ԱկտՀԴՄ & " գործարանային համարով հսկիչ դրամարկղային մեքենայի վերանորգման աշխատանքներ չի իրականացրել:" & vbCrLf & "2. Սույն արձանագրության ստորագրման պահից հավաստիացվում է, որ  Կատարողը Պատվիրատուին է հանձնել Պատվիրատուին պատկանող MF2351 մոդելի " & ԱկտՀԴՄ & " գործարանային համարով հսկիչ դրամարկղային մեքենան:"

                .Range("E13").Value = Chr(34) & dt.Rows(0)("Անվանում") & Chr(34)
                .Range("E36").Value = Chr(34) & dt.Rows(0)("Անվանում") & Chr(34)
                .Range("E17").Value = "ՀՎՀՀ՝ " & dt.Rows(0)("ՀՎՀՀ")
                .Range("E40").Value = "ՀՎՀՀ՝ " & dt.Rows(0)("ՀՎՀՀ")

                .Range("A13").Value = dt.Rows(0)("Կազմակերպություն")
                .Range("A36").Value = dt.Rows(0)("Կազմակերպություն")
                .Range("A17").Value = "ՀՎՀՀ՝ " & dt.Rows(0)("ՊՀՎՀՀ")
                .Range("A40").Value = "ՀՎՀՀ՝ " & dt.Rows(0)("ՊՀՎՀՀ")
            End With

            sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            txtPrintAkt.Enabled = False
            formResult = True

            If SMSSendToTesuchP = True Then
                Call CreatePropTesuch(RemakeID)

                Call SentSMS2(RemakeID)
            End If

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

    Private Sub CreatePropTesuch(iRemakeID As Integer)
        Try
            If isHDMExists(ԱկտՀԴՄ) = True Then Exit Sub
            Dim TesuchName As String = iDB.GetTesuchNameRemakeDetails(iRemakeID)
            If String.IsNullOrEmpty(TesuchName) Then Exit Sub
            iDB.AddGeneralPropAfterClose(ԱկտՀԴՄ, TesuchName, iUser.LoginName, ԱկտՀԴՄ & " hamari HDM-n veranorogvac e.")
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
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
            iCompany = Company_XXX.HDM_Shtrikh

            Dim SMSMessage As String = ԱկտՀԴՄ & " hamari HDM-n veranorogvac e."

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

    Dim WithEvents client As New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}
    Private isConnected As Boolean

    Enum Company_XXX
        HDM_Shtrikh = 1
        Tama_Electron = 2
        Mery_Krist = 3
        Touch_Master = 4
        Undefined = 5
    End Enum

    Private Sub KillClient(ByRef c As SmppClient)
        On Error Resume Next
        If IsNothing(c) Then Exit Sub
        If c.Started = True Then c.Shutdown()
        c = Nothing
    End Sub

End Class