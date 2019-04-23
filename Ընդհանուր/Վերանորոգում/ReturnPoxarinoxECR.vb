Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel

Public Class ReturnPoxarinoxECR

    Friend ԱկտՀԴՄ As String = ""
    Dim formResult As Boolean = False
    Dim strRandom As String = ""
    Dim dt As System.Data.DataTable
    Friend RemontID As Integer

    Dim lHDM As String = ""

    Private Sub _getInfo()
        Try
            dt = iDB.GetReplaceEcrInfo(ԱկտՀԴՄ)
            If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չեն ստացվել")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Me.Close()
        End Try
    End Sub
    Friend Function Result() As Boolean
        Return formResult
    End Function
    Private Sub ReturnPoxarinoxECR_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Call _getInfo()
        txtPrinter.Text = strPrinter

        Try
            Dim dt2 As System.Data.DataTable = iDB.ReplEcrByID(ԱկտՀԴՄ)

            If dt2.Rows.Count > 0 Then
                lHDM = dt2.Rows(0)("ՀԴՄ")
                txtComment.Text = dt2.Rows(0)("Մեկնաբանություն")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub btnPrintAkt_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintAkt.Click
        Try
            If String.IsNullOrEmpty(strPrinter) Then MsgBox("Տպիչը նշված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
            If txtComment.Text.Trim = String.Empty Then MsgBox("Մեկնաբանությունը բացակայում է", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

            Dim r As New Random
            strRandom = r.Next(1000000000, Integer.MaxValue)

            txtCode.Text = strRandom

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\HDM AKT"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\Temp"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            My.Computer.FileSystem.WriteAllBytes(strPath & "\" & strRandom & ".xls", My.Resources.aktpox3, False)

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
                .Range("G3").Value = Date.Now.ToString("dd.MM.yyyy")
                .Range("G27").Value = Date.Now.ToString("dd.MM.yyyy")

                .Range("A5").Value = "Գեներացման կոդ` " & strRandom
                .Range("A29").Value = "Գեներացման կոդ` " & strRandom

                .Range("A6").Value = "Մի կողմից " & Chr(34) & dt.Rows(0)("Անվանում") & Chr(34) & "-ն, որպես Կողմ-1, ի դեմս " & dt.Rows(0)("Տնօրեն2") & "-ի և մյուս կողմից " & dt.Rows(0)("Կազմակերպություն") & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & dt.Rows(0)("Տնօրեն") & "-ի, ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."
                .Range("A30").Value = "Մի կողմից " & Chr(34) & dt.Rows(0)("Անվանում") & Chr(34) & "-ն, որպես Կողմ-1, ի դեմս " & dt.Rows(0)("Տնօրեն2") & "-ի և մյուս կողմից " & dt.Rows(0)("Կազմակերպություն") & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & dt.Rows(0)("Տնօրեն") & "-ի, ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."

                .Range("A11").Value = "1. Սույն ակտով Կողմ-1-ը Կողմ-2 -ին է վերադարձնում փոխարինման նպատակով ժամանակավոր տրամադրված MF 2351 մոդելի " & lHDM & " համարի թվով մեկ հատ Հսկիչ դրամարկղային մեքենան" & txtComment.Text.Trim
                .Range("A35").Value = "1. Սույն ակտով Կողմ-1-ը Կողմ-2 -ին է վերադարձնում փոխարինման նպատակով ժամանակավոր տրամադրված MF 2351 մոդելի " & lHDM & " համարի թվով մեկ հատ Հսկիչ դրամարկղային մեքենան" & txtComment.Text.Trim

                .Range("B16").Value = Chr(34) & dt.Rows(0)("Անվանում") & Chr(34)
                .Range("B40").Value = Chr(34) & dt.Rows(0)("Անվանում") & Chr(34)
                .Range("B20").Value = dt.Rows(0)("ՀՎՀՀ")
                .Range("B44").Value = dt.Rows(0)("ՀՎՀՀ")

                .Range("G16").Value = dt.Rows(0)("Կազմակերպություն")
                .Range("G40").Value = dt.Rows(0)("Կազմակերպություն")
                .Range("G20").Value = dt.Rows(0)("ՊՀՎՀՀ")
                .Range("G44").Value = dt.Rows(0)("ՊՀՎՀՀ")
            End With

            sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            btnPrintAkt.Enabled = False
            btnCheck.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub btnSelectPrinter_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectPrinter.Click
        Dim f As New SelectPrinter
        f.ShowDialog()
        f = Nothing
        txtPrinter.Text = strPrinter
    End Sub
    Private Sub btnCheck_Click(sender As System.Object, e As System.EventArgs) Handles btnCheck.Click
        If txtCode.Text.Trim <> strRandom Then MsgBox("Գեներացման կոդը չի համնընկնում", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        Try
            iDB.ReturnEcr(iUser.LoginName, RemontID)
            formResult = True
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

End Class