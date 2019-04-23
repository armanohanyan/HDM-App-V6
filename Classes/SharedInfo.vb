Imports System
Imports System.Net
Imports System.Text
Imports System.Security.Cryptography
Imports System.Diagnostics
Imports System.IO
Imports System.ComponentModel
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security
Imports System.Net.Mail

Module SharedInfo

#Region "Ignore Certificate"

    Friend Function customCertValidation(ByVal sender As Object, ByVal cert As X509Certificate, ByVal chain As X509Chain, ByVal errors As SslPolicyErrors) As Boolean
        Return True
    End Function

#End Region

#Region "Send Mail"

    Friend Function SendMail(ByVal UserName As String, ByVal Password As String, ByVal port As Int32, ByVal UseSSL As Boolean, ByVal SMTPServer As String,
                        ByVal message As String, ByVal mailTo As String, ByVal mailFrom As String, ByVal Subject As String, ByVal IsHDML As Boolean) As Boolean

        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential(UserName, Password)
        Smtp_Server.Port = port
        Smtp_Server.EnableSsl = UseSSL
        Smtp_Server.Host = SMTPServer

        e_mail = New MailMessage()
        e_mail.From = New MailAddress(mailFrom)
        e_mail.To.Add(mailTo)
        e_mail.Subject = Subject
        e_mail.IsBodyHtml = IsHDML
        e_mail.Body = message
        Smtp_Server.Send(e_mail)

        Return True
    End Function

#End Region

#Region "Variables"

    Friend iUser As New CurrentUser
    Friend iDB As New DB
    Friend iSkin As String = "Office 2013"
    Friend strPrinter As String = String.Empty
    Friend dtPermission_U As New DataTable
    Friend dtPermission_W As New DataTable

    Friend IsWWOpened As Boolean = False
    Friend IsWWOpened2 As Boolean = False

    Friend SMSSendToTesuchP As Boolean = False
    Friend bBarRemake As Boolean = False
    Friend bBarRemakeClient As Boolean = False

#End Region

#Region "Enum"

    Friend Enum ExportType
        Excel2013 = 1
        Excel2003 = 2
        Pdf = 3
        RTF = 4
        CSV = 5
        TEXT = 6
    End Enum
    Friend Enum PrintTypes
        Print = 1
        PrintPreview = 2
        ShowSetup = 3
    End Enum
    Friend Enum Crud
        Insert = 1
        Update = 2
        Delete = 3
    End Enum

#End Region

#Region "Image To Binary"

    Friend Function ConvertImage(ByVal myImage As Image) As Byte()
        Dim mstream As New MemoryStream
        myImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim myBytes(mstream.Length - 1) As Byte
        mstream.Position = 0
        mstream.Read(myBytes, 0, mstream.Length)
        Return myBytes
    End Function

#End Region

#Region "Event Log"

    Structure [EventLogX]
        Dim [Source] As String
        Dim [Log] As String
        Dim [Event] As String
        Dim [Machine] As String
    End Structure

    Private Sub EV(ByVal msg As String, ByVal CatID As Short, ByVal EvID As Integer)
        Dim Evt As New [EventLogX] With {.Machine = ".", .Log = "Application", .Source = "HDM App", .Event = msg}
        Dim ELog As New EventLog(Evt.Log, Evt.Machine, Evt.Source)
        ELog.WriteEntry(Evt.Event, EventLogEntryType.Error, EvID, CType(CatID, Short))
    End Sub

#End Region

#Region "Encoding"

    'Make MD5 of string
    Friend Function getMd5Hash(ByVal input As String) As String
        Dim md5Hasher As MD5 = MD5.Create()
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))
        Dim sBuilder As New StringBuilder()
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i
        Return sBuilder.ToString()
    End Function

#End Region

#Region "Export Data"

    'Data Export
    Friend Sub ExportTo(expType As ExportType, ByVal frm As Form)

        For Each frmCont As Control In frm.Controls
            If Not TypeOf (frmCont) Is DevExpress.XtraGrid.GridControl Then Continue For

            Dim gridCont As DevExpress.XtraGrid.GridControl = frmCont

            Dim r As New Random
            Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\HDM Exports"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\" & frm.Text
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

            Select Case expType
                Case ExportType.Excel2013
                    f &= "\REP" & r.Next(0, Integer.MaxValue) & ".xlsx"
                    gridCont.ExportToXlsx(f)
                Case ExportType.Excel2003
                    f &= "\REP" & r.Next(0, Integer.MaxValue) & ".xls"
                    gridCont.ExportToXls(f)
                Case ExportType.Pdf
                    f &= "\REP" & r.Next(0, Integer.MaxValue) & ".PDF"
                    gridCont.ExportToPdf(f)
                Case ExportType.RTF
                    f &= "\REP" & r.Next(0, Integer.MaxValue) & ".DOC"
                    gridCont.ExportToRtf(f)
                Case ExportType.CSV
                    f &= "\REP" & r.Next(0, Integer.MaxValue) & ".CSV"
                    gridCont.ExportToCsv(f)
                Case ExportType.TEXT
                    f &= "\REP" & r.Next(0, Integer.MaxValue) & ".TXT"
                    Dim tOpt As New DevExpress.XtraPrinting.TextExportOptions
                    tOpt.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text
                    tOpt.Encoding = System.Text.Encoding.UTF8
                    gridCont.ExportToText(f, tOpt)
            End Select

            Process.Start("EXPLORER.EXE", Chr(34) & f & Chr(34))

            'Dim sfd As New SaveFileDialog
            'Dim q As MsgBoxResult

            'With sfd
            '    .Title = "Արտահանել"
            '    Select Case expType
            '        Case ExportType.Excel2013
            '            .Filter = "Excel 2010-2013 (*.xlsx)|*.xlsx"
            '        Case ExportType.Excel2003
            '            .Filter = "Excel 2003 (*.xls)|*.xls"
            '        Case ExportType.Pdf
            '            .Filter = "PDF (*.pdf)|*.pdf"
            '        Case ExportType.RTF
            '            .Filter = "RTF (*.doc)|*.doc"
            '        Case ExportType.CSV
            '            .Filter = "CSV (*.csv)|*.csv"
            '        Case ExportType.TEXT
            '            .Filter = "TEXT (*.txt)|*.txt"
            '    End Select
            '    q = .ShowDialog()
            'End With

            'If q = MsgBoxResult.Ok Then
            '    Select Case expType
            '        Case ExportType.Excel2013
            '            gridCont.ExportToXlsx(sfd.FileName)
            '        Case ExportType.Excel2003
            '            gridCont.ExportToXls(sfd.FileName)
            '        Case ExportType.Pdf
            '            gridCont.ExportToPdf(sfd.FileName)
            '        Case ExportType.RTF
            '            gridCont.ExportToRtf(sfd.FileName)
            '        Case ExportType.CSV
            '            gridCont.ExportToCsv(sfd.FileName)
            '        Case ExportType.TEXT
            '            Dim tOpt As New DevExpress.XtraPrinting.TextExportOptions
            '            tOpt.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text
            '            tOpt.Encoding = System.Text.Encoding.UTF8
            '            gridCont.ExportToText(sfd.FileName, tOpt)
            '    End Select
            'End If

        Next

    End Sub

    Friend Sub ExportTo2(expType As ExportType, ByVal dc As DevExpress.XtraGrid.GridControl)

        Dim r As New Random
        Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\HDM Exports"
        If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
        f &= "\Export"
        If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

        Select Case expType
            Case ExportType.Excel2013
                f &= "\REP" & r.Next(0, Integer.MaxValue) & ".xlsx"
                dc.ExportToXlsx(f)
            Case ExportType.Excel2003
                f &= "\REP" & r.Next(0, Integer.MaxValue) & ".xls"
                dc.ExportToXls(f)
            Case ExportType.Pdf
                f &= "\REP" & r.Next(0, Integer.MaxValue) & ".PDF"
                dc.ExportToPdf(f)
            Case ExportType.RTF
                f &= "\REP" & r.Next(0, Integer.MaxValue) & ".DOC"
                dc.ExportToRtf(f)
            Case ExportType.CSV
                f &= "\REP" & r.Next(0, Integer.MaxValue) & ".CSV"
                dc.ExportToCsv(f)
            Case ExportType.TEXT
                f &= "\REP" & r.Next(0, Integer.MaxValue) & ".TXT"
                Dim tOpt As New DevExpress.XtraPrinting.TextExportOptions
                tOpt.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text
                tOpt.Encoding = System.Text.Encoding.UTF8
                dc.ExportToText(f, tOpt)
        End Select

        Process.Start("EXPLORER.EXE", Chr(34) & f & Chr(34))

    End Sub

#End Region

#Region "Exception Handling"

    Friend Const ERR_SQL_VALUE_CANT_BE_DUBLICATED As String = "Բազայում գրանցումը կրկնվում է"
    Friend Const ERR_SQL_REF_ERROR As String = "Գրանցումը կապված է այլ գրանցումների հետ և չի կարող ջնջվել"
    Friend Const ERR_SQL_UNIVERSAL_ERROR As String = "Տվյալների բազային դիմման սխալ"
    Friend Const ERR_SQL_SERVER_NOT_FOUND As String = "Տվյալների բազան անհասանելի է կամ տեղի է ունեցել սերվերին դիմման սխալ"
    Friend Const ERR_SQL_SERVER_IS_LOADING = "Տվյալների բազայի սերվերը հասանելի է, սակայն բազան դեռևս չի բեռնվել: Հարկավոր է փակել ծրագիրը և նորից գործարկել"
    Friend Const ERR_SQL_NO_FUNCTION_FOUND = "SQL Server-ում ֆունկցիան չի հայտնաբերվել"
    Friend Const ERR_SQL_INVALID_OBJECT = "Օբյեկտի սխալ անուն"
    Friend Const ERR_SQL_SYNTAX_ERROR = "Բազային հարցման սինտաքսիսային սխալ"
    Friend Const ERR_SQL_TIME_OUT = "Հարցումը նախատեսվածից երկար է տևել"
    Friend Const ERR_SQL_INSTANCE_NOT_FOUND = "SQL Server—ի ինսթանսը չի հայտնաբերվել, հարկավոր է նշել սերվերի պորտը"
    Friend Const ERR_SQL_NULL_NOT_ALLOWED = "Փորձ է արվում բազայում ավելացնել NULL արժեք, սակայն աղյուսակի դաշտը չի թույլատրում NULL-ի մուտքագրում"

    Friend Sub SoftException(ex As Exception)

        'Call EV(ex.Message, 1, 1)

        Dim ER As New ExceptionClass()
        ER.ShowError(0, ex.Message, MsgBoxStyle.Critical)
    End Sub

    Friend Sub SQLException(ex As System.Data.SqlClient.SqlException)

        'Call EV(ex.Message, 2, 2)

        Dim strMessage As String = String.Empty
        If ex.Number = 2 Then
            strMessage = ERR_SQL_SERVER_NOT_FOUND
        ElseIf ex.Number = -1 Then
            strMessage = ERR_SQL_INSTANCE_NOT_FOUND
        ElseIf ex.Number = -2 Then
            strMessage = ERR_SQL_TIME_OUT
        ElseIf ex.Number = 102 Then
            strMessage = ERR_SQL_SYNTAX_ERROR
        ElseIf ex.Number = 208 Then
            strMessage = ERR_SQL_INVALID_OBJECT
        ElseIf ex.Number = 547 Then
            strMessage = ERR_SQL_REF_ERROR
        ElseIf ex.Number = 515 Then
            strMessage = ERR_SQL_NULL_NOT_ALLOWED
        ElseIf ex.Number = 2627 Then
            strMessage = ERR_SQL_VALUE_CANT_BE_DUBLICATED
        ElseIf ex.Number = 2601 Then
            strMessage = ERR_SQL_VALUE_CANT_BE_DUBLICATED
        ElseIf ex.Number = 2812 Then
            strMessage = ERR_SQL_NO_FUNCTION_FOUND
        ElseIf ex.Number = 4060 Then
            strMessage = ERR_SQL_SERVER_IS_LOADING
        ElseIf ex.Number >= 50000 Then
            strMessage = ex.Message
        Else
            strMessage = ERR_SQL_UNIVERSAL_ERROR & vbCrLf & "Սխալի կոդ՝ " & ex.Number & vbCrLf & ex.Message
        End If
        Dim ER As New ExceptionClass()
        ER.ShowCustomError(-1, strMessage, MsgBoxStyle.Critical)
    End Sub

#End Region

#Region "sub"

    'New Tab
    Friend Sub AddChildForm(ByVal strName As String, ByVal childForm As Form)
        childForm.Name = strName
        childForm.MdiParent = MainWindow
        childForm.Show()
    End Sub

#End Region

#Region "Class To Datatable"

    <System.Runtime.CompilerServices.Extension> _
    Friend Function ToDataTable(Of T)(data As IList(Of T)) As DataTable
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
        Dim dt As New DataTable()
        For i As Integer = 0 To properties.Count - 1
            Dim [property] As PropertyDescriptor = properties(i)
            dt.Columns.Add([property].Name, [property].PropertyType)
        Next
        Dim values As Object() = New Object(properties.Count - 1) {}
        For Each item As T In data
            For i As Integer = 0 To values.Length - 1
                values(i) = properties(i).GetValue(item)
            Next
            dt.Rows.Add(values)
        Next
        Return dt
    End Function

#End Region

#Region "Set Theme"

    Friend Sub SetTheme(ByVal theme As String)
        Try
            SaveSetting("HDM App", "Properties", "Theme", theme)
            iSkin = theme
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = theme
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#Region "Get IP"

    Friend Function GetIpAddress() As String
        On Error Resume Next

        Dim ipAddress As IPAddress
        Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
        ipAddress = ipHostInfo.AddressList(0)

        Return ipAddress.ToString

    End Function

#End Region

#Region "Close Window"

    Friend Sub CloseWindow(ByVal name As String)
        On Error Resume Next

        For Each mf As Form In My.Application.OpenForms
            If mf.Name = name Then
                mf.Close()
            End If
        Next

    End Sub

#End Region

#Region "Permissions"

    Friend Function CheckPermission(ByVal GUID As String) As Boolean
        If dtPermission_U.Rows.Count = 0 Then Return False
        For i As Integer = 0 To dtPermission_U.Rows.Count - 1
            If dtPermission_U.Rows(i)("GUID") = GUID AndAlso dtPermission_U.Rows(i)("Allowed") = True Then Return True : Exit Function
        Next
        Return False
    End Function
    Friend Function CheckPermission2(ByVal GUID As String) As Boolean
        If dtPermission_W.Rows.Count = 0 Then Return False
        For i As Integer = 0 To dtPermission_W.Rows.Count - 1
            If dtPermission_W.Rows(i)("GUID") = GUID AndAlso dtPermission_W.Rows(i)("Allowed") = True Then Return True : Exit Function
        Next
        Return False
    End Function

#End Region

End Module

Public Class CurrentUser

    Friend Property UserID As Integer
    Friend Property LoginName As String
    Friend Property FirstName As String
    Friend Property LastName As String
    Friend Property Password As String
    Friend Property EncodedPassword As String
    Friend Property DB As Byte
    Friend Property IsLogedIn As Boolean
    Friend Property UserGroup As Byte
    Friend Property UserComments As String
    Friend Property PasswordDate As Date
    Friend Property MustChangePass As Boolean

End Class