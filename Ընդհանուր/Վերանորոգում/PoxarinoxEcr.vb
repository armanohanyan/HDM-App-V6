Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel

Public Class PoxarinoxEcr

    Dim formResult As Boolean = False
    Dim strRandom As String = ""
    Dim dt As System.Data.DataTable
    Friend ԱկտՀԴՄ As String = ""
    Friend remontID As Integer = 0
    Dim dtlist As System.Data.DataTable

    Dim strState As String = String.Empty
    Dim hayt As String = String.Empty

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
    Private Sub _LoadExistingHDMs()
        Try
            dtlist = iDB.GetEcrExistingForReplace2(ԱկտՀԴՄ)

            With cbEcrList
                .DataSource = dtlist
                .DisplayMember = "ՀԴՄ"
                .ValueMember = "ՀԴՄՀՀ"
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub PoxarinoxEcr_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Call _getInfo()
        Call _LoadExistingHDMs()
        txtPrinterName.Text = strPrinter
    End Sub
    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        If cbEcrList.Items.Count = 0 Then MsgBox("Փոխարինման համար ՀԴՄ-ներ չկան", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        If OutDamaged.Checked = True AndAlso txtComment.Text.Trim = String.Empty Then
            MsgBox("Մեկնաբանությունը գրված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Exit Sub
        End If

        Dim b As Boolean = False
        For i As Integer = 0 To dtlist.Rows.Count - 1
            If dtlist.Rows(i)("ՀԴՄ") = cbEcrList.Text Then b = True : Exit For
        Next
        If b = False Then Throw New Exception("Փոխարինող ՀԴՄ-ն սխալ է ընտրված")

        btnSelect.Enabled = False
        btnPrintAkt.Enabled = True
        cbEcrList.Enabled = False

        txtComment.Enabled = False
        OutDamaged.Enabled = False
        NoCase.Enabled = False
        NoCharger.Enabled = False
        NoStick.Enabled = False
        NoBattary.Enabled = False
    End Sub
    Private Sub btnSelectPrinter_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectPrinter.Click
        Dim f As New SelectPrinter
        f.ShowDialog()
        f = Nothing
        txtPrinterName.Text = strPrinter
    End Sub
    Private Sub btnPrintAkt_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintAkt.Click
        Try
            If String.IsNullOrEmpty(strPrinter) Then MsgBox("Տպիչը նշված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

            If OutDamaged.Checked = True Then
                strState &= "արտաքին վնասվածքով"
                If txtComment.Text.Trim <> String.Empty Then
                    strState &= " (" & txtComment.Text.Trim & ")"
                End If
            Else
                strState &= "առանց արտաքին վնասվածքի"
            End If
            If NoCase.Checked = True Then
                strState &= ", առանց տուփի"
            Else
                strState &= ", տուփով"
            End If
            If NoCharger.Checked = True Then
                strState &= ", առանց լիցքավորիչի"
            Else
                strState &= ", լիցքավորիչով"
            End If
            If NoStick.Checked = True Then
                strState &= ", առանց մատիտի"
            Else
                strState &= ", մատիտով"
            End If
            If NoBattary.Checked = True Then
                strState &= ", առանց մարտկոցի"
            Else
                strState &= ", մարտկոցով"
            End If

            'If NoCase.Checked OrElse NoCharger.Checked OrElse NoStick.Checked OrElse NoBattary.Checked Then
            '    If OutDamaged.Checked = True Then strState = ",առանց " Else strState = " առանց "

            '    If NoCase.Checked AndAlso strState.EndsWith("առանց ") Then strState &= "տուփի"

            '    If NoCharger.Checked AndAlso strState.EndsWith("առանց ") Then
            '        strState &= " լիցքավորիչի"
            '    ElseIf NoCharger.Checked AndAlso (Not strState.EndsWith("առանց ")) Then
            '        strState &= ", լիցքավորիչի"
            '    End If

            '    If NoStick.Checked AndAlso strState.EndsWith("առանց ") Then
            '        strState &= " մատիտի"
            '    ElseIf NoStick.Checked AndAlso (Not strState.EndsWith("առանց ")) Then
            '        strState &= ", մատիտի"
            '    End If

            '    If NoBattary.Checked AndAlso strState.EndsWith("առանց ") Then
            '        strState &= " մարտկոցի"
            '    ElseIf NoBattary.Checked AndAlso (Not strState.EndsWith("առանց ")) Then
            '        strState &= ", մարտկոցի"
            '    End If

            'End If

            If OutDamaged.Checked Then
                hayt = "` " & strState & ":"
            Else
                If strState.Trim = String.Empty Then
                    hayt = ":"
                Else
                    hayt = "` " & strState & ":"
                End If
            End If

            Dim r As New Random
            strRandom = r.Next(1000000000, Integer.MaxValue)

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\HDM AKT"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\Temp"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            My.Computer.FileSystem.WriteAllBytes(strPath & "\" & strRandom & ".xls", My.Resources.aktpox2, False)

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

                .Zoom = 90
            End With

            With sheet
                .Range("G3").Value = Date.Now.ToString("dd.MM.yyyy")
                .Range("G28").Value = Date.Now.ToString("dd.MM.yyyy")

                .Range("A5").Value = "Գեներացման կոդ` " & strRandom
                .Range("A30").Value = "Գեներացման կոդ` " & strRandom

                .Range("A6").Value = "Մի կողմից " & Chr(34) & dt.Rows(0)("Անվանում") & Chr(34) & "-ն, որպես Կողմ-1, ի դեմս " & dt.Rows(0)("Տնօրեն2") & "-ի և մյուս կողմից " & dt.Rows(0)("Կազմակերպություն") & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & dt.Rows(0)("Տնօրեն") & "-ի, ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."
                .Range("A31").Value = "Մի կողմից " & Chr(34) & dt.Rows(0)("Անվանում") & Chr(34) & "-ն, որպես Կողմ-1, ի դեմս " & dt.Rows(0)("Տնօրեն2") & "-ի և մյուս կողմից " & dt.Rows(0)("Կազմակերպություն") & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & dt.Rows(0)("Տնօրեն") & "-ի, ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."

                .Range("A11").Value = "1. Սույն ակտով Կողմերի միջև կնքված համար " & dt.Rows(0)("Պայմանագիր") & " Ծառայությունների մատուցման պայմանագրի շրջանակներում Կողմ-2-ը Կողմ-1 -ին ժամանակավոր օգտագործման է հանձնում MF 2351 մոդելի " & cbEcrList.Text & " համարի թվով մեկ հատ Հսկիչ դրամարկղային մեքենան (որպես փոխարինող " & ԱկտՀԴՄ & " ՀԴՄ-ին) " & hayt
                .Range("A36").Value = "1. Սույն ակտով Կողմերի միջև կնքված համար " & dt.Rows(0)("Պայմանագիր") & " Ծառայությունների մատուցման պայմանագրի շրջանակներում Կողմ-2-ը Կողմ-1 -ին ժամանակավոր օգտագործման է հանձնում MF 2351 մոդելի " & cbEcrList.Text & " համարի թվով մեկ հատ Հսկիչ դրամարկղային մեքենան (որպես փոխարինող " & ԱկտՀԴՄ & " ՀԴՄ-ին) " & hayt

                .Range("B16").Value = Chr(34) & dt.Rows(0)("Անվանում") & Chr(34)
                .Range("B41").Value = Chr(34) & dt.Rows(0)("Անվանում") & Chr(34)
                .Range("B20").Value = dt.Rows(0)("ՀՎՀՀ")
                .Range("B45").Value = dt.Rows(0)("ՀՎՀՀ")

                .Range("G16").Value = dt.Rows(0)("Կազմակերպություն")
                .Range("G41").Value = dt.Rows(0)("Կազմակերպություն")
                .Range("G20").Value = dt.Rows(0)("ՊՀՎՀՀ")
                .Range("G45").Value = dt.Rows(0)("ՊՀՎՀՀ")
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
    Private Sub btnCheck_Click(sender As System.Object, e As System.EventArgs) Handles btnCheck.Click
        If txtCode.Text.Trim <> strRandom Then MsgBox("Գեներացման կոդը չի համնընկնում", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        Try
            If hayt = ":" Then hayt = String.Empty

            iDB.AddNewEcrReplacement(dt.Rows(0)("ՀՀ"), cbEcrList.SelectedValue, iUser.LoginName, remontID, hayt)
            formResult = True

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub OutDamaged_CheckedChanged(sender As Object, e As EventArgs) Handles OutDamaged.CheckedChanged
        On Error Resume Next
        If OutDamaged.Checked = False Then
            txtComment.Text = String.Empty
            txtComment.ReadOnly = True
        Else
            txtComment.ReadOnly = False
            txtComment.Focus()
        End If
    End Sub

End Class