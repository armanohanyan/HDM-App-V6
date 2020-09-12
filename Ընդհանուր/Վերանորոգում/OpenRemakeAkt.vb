Imports Microsoft.Office.Interop.Excel

Public Class OpenRemakeAkt

    Friend ecr As String
    Friend hvhh As String
    Friend hayt As String
    Friend isSoft As Boolean

    Dim formResult As Boolean = False
    Dim strRandom As String = ""

    Friend isDamaged As Boolean = False
    Friend DamageText As String = String.Empty
    Friend OnlyBattary As Boolean = False

    Friend Tup As Boolean
    Friend Matit As Boolean
    Friend Licqavorich As Boolean
    Friend Martkoc As Boolean

    Friend strHDMState As String = String.Empty

    Dim dt As System.Data.DataTable

    Dim iClientName As String
    Dim iClientLastName As String
    Dim iClientTel As String

    Dim TesuchID As Integer = -1
    Dim Price As Decimal = 0

    Private Sub LoadTesuch()
        Try
            Dim dtT As System.Data.DataTable = iDB.GetWorkingTesuchListForRemake()
            With cTesuch
                .DataSource = dtT
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
    Friend Function Result() As Boolean
        Return formResult
    End Function
    Private Sub _getInfo()
        Try
            dt = iDB.GetOpenAktInfo(ecr)
            If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չեն ստացվել")
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            Me.Close()
        Catch ex As Exception
            Call SoftException(ex)
            Me.Close()
        End Try
    End Sub
    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            If String.IsNullOrEmpty(txtClientName.Text) Then Throw New Exception("Անունը գրված չէ")
            If String.IsNullOrEmpty(txtClientLastName.Text) Then Throw New Exception("Ազգանունը գրված չէ")
            If String.IsNullOrEmpty(txtClientHvhh.Text) Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")
            If String.IsNullOrEmpty(txtClientTel.Text) Then Throw New Exception("Հեռախոսահամարը գրված չէ")
            If txtClientTel.Text.Trim.Length <> 6 Then Throw New Exception("Հեռախոսահամարը ամբողջությամբ գրված չէ")

            If cTesuch.SelectedValue > 0 Then
                If txtPrice.Text.Trim = String.Empty OrElse txtPrice.Text.Trim < 0 Then Throw New Exception("Գումարը նշված չէ")
                Price = txtPrice.Text.Trim
            Else
                Price = 0
            End If

            TesuchID = cTesuch.SelectedValue

            iClientName = txtClientName.Text.Trim
            iClientLastName = txtClientLastName.Text.Trim
            iClientTel = txtClientTel.Text.Trim

            If txtClientHvhh.Text.Trim <> hvhh Then Throw New Exception("ՀՎՀՀ-ն սխալ է գրված")
            btnCheck.Enabled = False
            btnPrintAkt.Enabled = True

            txtClientName.Enabled = False
            txtClientLastName.Enabled = False
            txtClientHvhh.Enabled = False
            cbCode.Enabled = False
            txtClientTel.Enabled = False
            'cTesuch.Enabled = False
            txtPrice.Enabled = False

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnSelectPrinter_Click(sender As Object, e As EventArgs) Handles btnSelectPrinter.Click
        Dim f As New SelectPrinter
        f.ShowDialog()
        f = Nothing
        txtPrinterName.Text = strPrinter
    End Sub
    Private Sub btnPrintAkt_Click(sender As Object, e As EventArgs) Handles btnPrintAkt.Click
        If String.IsNullOrEmpty(strPrinter) Then MsgBox("Տպիչը նշված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        Try
            Dim r As New Random
            strRandom = r.Next(1000000000, Integer.MaxValue)

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\HDM AKT"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\Temp"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            My.Computer.FileSystem.WriteAllBytes(strPath & "\" & strRandom & ".xls", My.Resources.akt1, False)

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

                .Zoom = 93
            End With

            With sheet
                .Range("G3").Value = Date.Now.ToString("dd.MM.yyyy")
                .Range("G32").Value = Date.Now.ToString("dd.MM.yyyy")

                .Range("A5").Value = "Գեներացման կոդ` " & strRandom
                .Range("A34").Value = "Գեներացման կոդ` " & strRandom

                Select Case dt.Rows(0)("ՊՀՎՀՀ")
                    Case "00251624"
                        .Range("A5").Value = "Գեներացման կոդ` " & strRandom & " ,  Հեռ՝ (060) 52-52-76"
                        .Range("A34").Value = "Գեներացման կոդ` " & strRandom & " ,  Հեռ՝ (060) 52-52-76"
                    Case "00841267"
                        .Range("A5").Value = "Գեներացման կոդ` " & strRandom & " ,  Հեռ՝ (060) 54-54-24"
                        .Range("A34").Value = "Գեներացման կոդ` " & strRandom & " ,  Հեռ՝ (060) 54-54-24"
                    Case "00845894"
                        .Range("A5").Value = "Գեներացման կոդ` " & strRandom & " ,  Հեռ՝ (060) 53-53-78"
                        .Range("A34").Value = "Գեներացման կոդ` " & strRandom & " ,  Հեռ՝ (060) 53-53-78"
                    Case "01562313"
                        .Range("A5").Value = "Գեներացման կոդ` " & strRandom & " ,  Հեռ՝ (060) 50-60-27"
                        .Range("A34").Value = "Գեներացման կոդ` " & strRandom & " ,  Հեռ՝ (060) 50-60-27"
                End Select

                Dim hdm As String = iDB.GetSerialNumberByEcr(dt.Rows(0)("ՀԴՄ")).ToString
                Dim model As String = dt.Rows(0)("ՀդմՄոդել")
                'If hdm.StartsWith("S") Then
                '    model = "PAX S900"
                '    hdm = hdm.Substring(4, 8)
                'End If
                Dim hvhh As String = dt.Rows(0)("ՀՎՀՀ").ToString
                If hvhh.EndsWith("S") Then hvhh = hvhh.Substring(0, 8)



                .Range("A7").Value = "Մի կողմից " & Chr(34) & dt.Rows(0)("Անվանում") & Chr(34) & "-ն, որպես Կողմ-1, ի դեմս " & dt.Rows(0)("Տնօրեն2") & "-ի և մյուս կողմից " & dt.Rows(0)("Կազմակերպություն") & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & dt.Rows(0)("Տնօրեն") & "-ի, ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."
                .Range("A36").Value = "Մի կողմից " & Chr(34) & dt.Rows(0)("Անվանում") & Chr(34) & "-ն, որպես Կողմ-1, ի դեմս " & dt.Rows(0)("Տնօրեն2") & "-ի և մյուս կողմից " & dt.Rows(0)("Կազմակերպություն") & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & dt.Rows(0)("Տնօրեն") & "-ի, ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."

                If OnlyBattary = True Then
                    .Range("A12").Value = "1. Սույն ակտով Կողմ-1-ը վերանորոգման նպատակով Կողմ-2-ին է հանձնում Կողմ-1-ին պատկանող " & model & " մոդելի " & hdm & " համարի ՀԴՄ-ի (գործ. հասցե՝ " & dt.Rows(0)("AddressName") & ") լիցքավորիչը:"
                    .Range("A41").Value = "1. Սույն ակտով Կողմ-1-ը վերանորոգման նպատակով Կողմ-2-ին է հանձնում Կողմ-1-ին պատկանող " & model & " մոդելի " & hdm & " համարի ՀԴՄ-ի (գործ. հասցե՝ " & dt.Rows(0)("AddressName") & ") լիցքավորիչը:"
                Else
                    If String.IsNullOrEmpty(strHDMState) Then
                        If isDamaged = False Then .Range("A12").Value = "1. Սույն ակտով Կողմ-1-ը վերանորոգման նպատակով Կողմ-2-ին է հանձնում Կողմ-1-ին պատկանող " & model & " մոդելի " & hdm & " համարի (գործ. հասցե՝ " & dt.Rows(0)("AddressName") & ") թվով մեկ հատ Հսկիչ դրամարկղային մեքենան:"
                        If isDamaged = False Then .Range("A41").Value = "1. Սույն ակտով Կողմ-1-ը վերանորոգման նպատակով Կողմ-2-ին է հանձնում Կողմ-1-ին պատկանող " & model & " մոդելի " & hdm & " համարի (գործ. հասցե՝ " & dt.Rows(0)("AddressName") & ") թվով մեկ հատ Հսկիչ դրամարկղային մեքենան:"

                        If isDamaged = True Then .Range("A12").Value = "1. Սույն ակտով Կողմ-1-ը վերանորոգման նպատակով Կողմ-2-ին է հանձնում Կողմ-1-ին պատկանող " & model & " մոդելի " & hdm & " համարի (գործ. հասցե՝ " & dt.Rows(0)("AddressName") & ") թվով մեկ հատ Հսկիչ դրամարկղային մեքենա` արտաքին վնասվածքով" & DamageText & ":"
                        If isDamaged = True Then .Range("A41").Value = "1. Սույն ակտով Կողմ-1-ը վերանորոգման նպատակով Կողմ-2-ին է հանձնում Կողմ-1-ին պատկանող " & model & " մոդելի " & hdm & " համարի (գործ. հասցե՝ " & dt.Rows(0)("AddressName") & ") թվով մեկ հատ Հսկիչ դրամարկղային մեքենա` արտաքին վնասվածքով" & DamageText & ":"
                    Else
                        If isDamaged = False Then .Range("A12").Value = "1. Սույն ակտով Կողմ-1-ը վերանորոգման նպատակով Կողմ-2-ին է հանձնում Կողմ-1-ին պատկանող " & model & " մոդելի " & hdm & " համարի (գործ. հասցե՝ " & dt.Rows(0)("AddressName") & ") թվով մեկ հատ Հսկիչ դրամարկղային մեքենան`" & strHDMState & ":"
                        If isDamaged = False Then .Range("A41").Value = "1. Սույն ակտով Կողմ-1-ը վերանորոգման նպատակով Կողմ-2-ին է հանձնում Կողմ-1-ին պատկանող " & model & " մոդելի " & hdm & " համարի (գործ. հասցե՝ " & dt.Rows(0)("AddressName") & ") թվով մեկ հատ Հսկիչ դրամարկղային մեքենան`" & strHDMState & ":"

                        If isDamaged = True Then .Range("A12").Value = "1. Սույն ակտով Կողմ-1-ը վերանորոգման նպատակով Կողմ-2-ին է հանձնում Կողմ-1-ին պատկանող " & model & " մոդելի " & hdm & " համարի (գործ. հասցե՝ " & dt.Rows(0)("AddressName") & ") թվով մեկ հատ Հսկիչ դրամարկղային մեքենա` արտաքին վնասվածքով" & DamageText & "," & strHDMState & ":"
                        If isDamaged = True Then .Range("A41").Value = "1. Սույն ակտով Կողմ-1-ը վերանորոգման նպատակով Կողմ-2-ին է հանձնում Կողմ-1-ին պատկանող " & model & " մոդելի " & hdm & " համարի (գործ. հասցե՝ " & dt.Rows(0)("AddressName") & ") թվով մեկ հատ Հսկիչ դրամարկղային մեքենա` արտաքին վնասվածքով" & DamageText & "," & strHDMState & ":"
                    End If
                End If

                .Range("B17").Value = Chr(34) & dt.Rows(0)("Անվանում") & Chr(34)
                .Range("B46").Value = Chr(34) & dt.Rows(0)("Անվանում") & Chr(34)
                .Range("B22").Value = hvhh
                .Range("B51").Value = hvhh

                .Range("G17").Value = dt.Rows(0)("Կազմակերպություն")
                .Range("G46").Value = dt.Rows(0)("Կազմակերպություն")
                .Range("G22").Value = dt.Rows(0)("ՊՀՎՀՀ")
                .Range("G51").Value = dt.Rows(0)("ՊՀՎՀՀ")

                'Tel
                .Range("A27").Value = "Հեռ. " & cbCode.Text & txtClientTel.Text.Trim
                .Range("A55").Value = "Հեռ. " & cbCode.Text & txtClientTel.Text.Trim

                'Name
                .Range("C23").Value = txtClientName.Text.Trim & "  " & txtClientLastName.Text.Trim
                .Range("C52").Value = txtClientName.Text.Trim & "  " & txtClientLastName.Text.Trim

                If OnlyBattary = True Then
                    .Range("C3").Value = "(ԼԻՑՔԱՎՈՐԻՉԻ ԸՆԴՈՒՆՈՒՄ)"
                    .Range("C32").Value = "(ԼԻՑՔԱՎՈՐԻՉԻ ԸՆԴՈՒՆՈՒՄ)"
                Else
                    .Range("C3").Value = "(ՀԴՄ-Ի ԸՆԴՈՒՆՈՒՄ)"
                    .Range("C32").Value = "(ՀԴՄ-Ի ԸՆԴՈՒՆՈՒՄ)"
                End If

            End With

            sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            btnPrintAkt.Enabled = False
            btnInsert.Enabled = True

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub OpenRemakeAkt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(strPrinter) Then txtPrinterName.Text = strPrinter
        _getInfo()
        cbCode.SelectedIndex = 0
        txtClientTel.Properties.Mask.EditMask = "\d[0-9A-Z]{2}[0-9A-Z]{3}"
        txtClientTel.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx

        Call LoadTesuch()
    End Sub
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        If txtCode.Text.Trim <> strRandom Then MsgBox("Գեներացման կոդը չի համնընկնում", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        Try
            iDB.AddRemakeWithAkt(ecr, hvhh, iUser.LoginName, iClientName, iClientLastName, strRandom, cbCode.Text & iClientTel, hayt, isSoft, isDamaged, DamageText, OnlyBattary, Tup, Matit, Licqavorich, Martkoc, TesuchID, Price)

            formResult = True
            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub txtClientHvhh_GotFocus(sender As Object, e As EventArgs) Handles txtClientHvhh.GotFocus
        On Error Resume Next
        'Clipboard.Clear()
    End Sub

End Class