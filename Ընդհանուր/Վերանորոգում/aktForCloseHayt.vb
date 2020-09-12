Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel

Public Class aktForCloseHayt

    Friend remontID As Integer = 0
    Friend ԱկտՀԴՄ As String = ""
    Dim formResult As Boolean = False
    Dim dt As System.Data.DataTable
    Dim strRandom As String = ""

    Private Sub LoadRemakeDetails()
        Try
            Dim dt As System.Data.DataTable = iDB.GetRemakeDetails(remontID)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("IsBattary") = True Then
                    OnlyBattary.Checked = True

                    OnlyBattary.Enabled = False

                    NoCase.Enabled = False
                    NoStick.Enabled = False
                    NoCharger.Enabled = False
                    NoBattary.Enabled = False
                    cDamaged.Enabled = False
                Else
                    OnlyBattary.Checked = False
                    OnlyBattary.Enabled = False

                    cDamaged.Checked = dt.Rows(0)("IsDamaged")
                    txtDamage.Text = dt.Rows(0)("DamageText")

                    NoCase.Checked = dt.Rows(0)("Tup")
                    NoStick.Checked = dt.Rows(0)("Matit")
                    NoCharger.Checked = dt.Rows(0)("Licqavorich")
                    NoBattary.Checked = dt.Rows(0)("Martkoc")

                End If
            Else
                OnlyBattary.Enabled = False
                cDamaged.Enabled = False

                txtDamage.Text = "Հայտի տվյալները բացակայում են"
            End If

        Catch ex As Exception
            btnPrintAkt.Enabled = False
            btnCheck.Enabled = False
        End Try
    End Sub
    Friend Function Result() As Boolean
        Return formResult
    End Function
    Private Sub _getInfo()
        Try
            dt = iDB.AktInfoForRemakeClose(ԱկտՀԴՄ)
            If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չեն ստացվել")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Me.Close()
        End Try
    End Sub
    Private Sub aktForCloseHayt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(strPrinter) Then txtPrinterName.Text = strPrinter
        _getInfo()
        LoadRemakeDetails()
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnChangePrinter.Click
        Dim f As New SelectPrinter
        f.ShowDialog()
        f = Nothing
        txtPrinterName.Text = strPrinter
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintAkt.Click
        Try
            'Շտրիխ կոդի ստուգում
            If iDB.CheckForOpenAktForRemake(remontID) = False Then
                Throw New Exception("Վերանորոգման հայտի ակտը չի հայտնաբերվել")
                formResult = False
                Me.Close()
            End If

            If String.IsNullOrEmpty(strPrinter) Then MsgBox("Տպիչը նշված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

            Dim rr As New Random
            strRandom = rr.Next(1000000000, Integer.MaxValue)

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\HDM AKT"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\Temp"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            My.Computer.FileSystem.WriteAllBytes(strPath & "\" & strRandom & ".xls", My.Resources.pakmanakt, False)

            Dim iClient = New With {.Կազմակերպություն = dt.Rows(0)("Անվանում"),
                  .Տնօրեն = dt.Rows(0)("Տնօրեն2"),
                  .ՀՎՀՀ = dt.Rows(0)("ՀՎՀՀ"),
                  .ՀԴՄ = iDB.GetSerialNumberByEcr(dt.Rows(0)("ՀԴՄ")),
                  .ՀդմՄոդել = dt.Rows(0)("ՀդմՄոդել")}

            'Dim hdm As String = dt.Rows(0)("ՀԴՄ").ToString
            'Dim model As String = "MF 2351"
            'If iClient.ՀԴՄ.StartsWith("S") Then
            '    'model = "PAX S900"
            '    'iClient.ՀԴՄ = iClient.ՀԴՄ.Substring(4, 8)
            'End If
            Dim hvhh As String = dt.Rows(0)("ՀՎՀՀ").ToString
            If iClient.ՀՎՀՀ.EndsWith("S") Then iClient.ՀՎՀՀ = iClient.ՀՎՀՀ.Substring(0, 8)

            Dim iPatkan = New With {.Կազմակերպություն = dt.Rows(0)("Կազմակերպություն"),
                  .ՀՎՀՀ = dt.Rows(0)("ՊՀՎՀՀ"),
                  .Տնօրեն = dt.Rows(0)("Տնօրեն"),
                  .ԱԱՀ = dt.Rows(0)("ԱԱՀ")}

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(strPath & "\" & strRandom & ".xls")
            xlApp.DisplayAlerts = False
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

            With sheet.PageSetup
                .PrintTitleRows = ""
                .PrintTitleColumns = ""

                .PrintArea = ""
                .PaperSize = XlPaperSize.xlPaperA4

                .Zoom = 95

            End With

            Dim strState As String = String.Empty
            If NoCase.Checked = True Then
                strState &= "առանց տուփի"
            Else
                strState &= "տուփով"
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

            With sheet
                .Range("G3").Value = Date.Now.ToString("dd.MM.yyyy")
                .Range("G27").Value = Date.Now.ToString("dd.MM.yyyy")

                .Range("A6").Value = "Մի կողմից «" & iClient.Կազմակերպություն & "»-ն, որպես Կողմ-1, ի դեմս " & iClient.Տնօրեն & " -ի և մյուս կողմից " & iPatkan.Կազմակերպություն & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & iPatkan.Տնօրեն & ", ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."
                .Range("A30").Value = "Մի կողմից «" & iClient.Կազմակերպություն & "»-ն, որպես Կողմ-1, ի դեմս " & iClient.Տնօրեն & " -ի և մյուս կողմից " & iPatkan.Կազմակերպություն & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & iPatkan.Տնօրեն & ", ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."

                If OnlyBattary.Checked = True Then
                    .Range("A11").Value = "1. Սույն ակտով Կողմ-2-ը Կողմ-1-ին է հանձնում Կողմ-1-ին պատկանող վերանորոգված " & iClient.ՀդմՄոդել & " մոդելի " & iClient.ՀԴՄ & " համարի ՀԴՄ-ի լիցքավորիչը:"
                    .Range("A35").Value = "1. Սույն ակտով Կողմ-2-ը Կողմ-1-ին է հանձնում Կողմ-1-ին պատկանող վերանորոգված " & iClient.ՀդմՄոդել & " մոդելի " & iClient.ՀԴՄ & " համարի ՀԴՄ-ի լիցքավորիչը:"
                Else
                    .Range("A11").Value = "1. Սույն ակտով Կողմ-2-ը Կողմ-1-ին է հանձնում Կողմ-1-ին պատկանող վերանորոգված " & iClient.ՀդմՄոդել & " մոդելի " & iClient.ՀԴՄ & " համարի թվով մեկ հատ Հսկիչ դրամարկղային մեքենան` " & strState & ":"
                    .Range("A35").Value = "1. Սույն ակտով Կողմ-2-ը Կողմ-1-ին է հանձնում Կողմ-1-ին պատկանող վերանորոգված " & iClient.ՀդմՄոդել & " մոդելի " & iClient.ՀԴՄ & " համարի թվով մեկ հատ Հսկիչ դրամարկղային մեքենան` " & strState & ":"
                End If

                .Range("B18").Value = iClient.Կազմակերպություն
                .Range("B42").Value = iClient.Կազմակերպություն

                .Range("G18").Value = iPatkan.Կազմակերպություն
                .Range("G42").Value = iPatkan.Կազմակերպություն

                .Range("B19").Value = iClient.ՀՎՀՀ
                .Range("B43").Value = iClient.ՀՎՀՀ

                .Range("G19").Value = iPatkan.ՀՎՀՀ
                .Range("G43").Value = iPatkan.ՀՎՀՀ

                .Range("A5").Value = "Գեներացման կոդ` " & strRandom
                .Range("A29").Value = "Գեներացման կոդ` " & strRandom

                If OnlyBattary.Checked = True Then
                    .Range("C2").Value = "(ԼԻՑՔԱՎՈՐԻՉԻ ՀԱՆՁՆՈՒՄ)"
                    .Range("C26").Value = "(ԼԻՑՔԱՎՈՐԻՉԻ ՀԱՆՁՆՈՒՄ)"
                Else
                    .Range("C2").Value = "(ՀԴՄ-Ի ՀԱՆՁՆՈՒՄ)"
                    .Range("C26").Value = "(ՀԴՄ-Ի ՀԱՆՁՆՈՒՄ)"
                End If

            End With

            sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            If dt.Rows(0)("Տարիֆ") = 4 OrElse dt.Rows(0)("Տարիֆ") = 5 OrElse dt.Rows(0)("Տարիֆ") = 15 Then
                If cbPrintHamadzaynagir.Checked = True OrElse iDB.IsHamadzaynagirPrinted(hvhh) = False Then
                    Call PrintHamadzaynagir()
                End If
            End If



            btnPrintAkt.Enabled = False
            btnCheck.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles btnCheck.Click
        If txtCode.Text.Trim <> strRandom Then MsgBox("Գեներացման կոդը չի համնընկնում", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        formResult = True
        Me.Close()
    End Sub
    Private Sub PrintHamadzaynagir()

        Dim contract As String = dt.Rows(0)("Պայմանագիր")
        'Dim contractDate As String = dt.Rows(0)("ՊայմանագրիԱմսաթիվ")
        Dim printDate As String = Date.Now.ToString("dd.MM.yyyy")
        Dim sCompany As String = dt.Rows(0)("Կազմակերպություն")
        Dim sDirector As String = dt.Rows(0)("Տնօրեն")
        Dim sAddress As String = dt.Rows(0)("Հասցե")
        Dim sHVHH As String = dt.Rows(0)("ՊՀՎՀՀ")
        Dim sHH As String = dt.Rows(0)("BankAccount")
        Dim sBankName As String = dt.Rows(0)("Bank")
        Dim cCompany As String = dt.Rows(0)("Անվանում")
        Dim cDirector As String = dt.Rows(0)("Տնօրեն2")
        Dim cIravAddress As String = dt.Rows(0)("ԻրավաբանականՀասցե")
        Dim cAraqAddress As String = dt.Rows(0)("ԱռաքմանՀասցե")
        Dim cHVHH As String = dt.Rows(0)("ՀՎՀՀ")
        Dim cTel As String = dt.Rows(0)("Հեռախոս")

        If String.IsNullOrEmpty(strPrinter) Then MsgBox("Տպիչը նշված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        Try
            Dim r As New Random
            Dim strRandom2 As String = ""
            strRandom2 = r.Next(1000000000, Integer.MaxValue)

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\HDM AKT\Hamadzaynagir"  ' Edited
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\Temp"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            My.Computer.FileSystem.WriteAllBytes(strPath & "\" & strRandom2 & ".xls", My.Resources.HamdzaynagirPahestamasi, False) ' Edited

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(strPath & "\" & strRandom2 & ".xls")
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''Edited
            With sheet
                .Range("A2").Value = "ՀՍԿԻՉ-ԴՐԱՄԱՐԿՂԱՅԻՆ ՄԵՔԵՆԱՆԵՐԻ ՍՊԱՍԱՐԿՄԱՆ ԹԻՎ " & contract & " ՊԱՅՄԱՆԱԳՐԻ"
                .Range("I5").Value = printDate
                .Range("A7").Value = sCompany & " (այսուհետ՝ Կատարող), ի դեմս տնօրեն " & sDirector & "ի, ով գործում է ընկերության կանոնադրության հիման վրա, մի կողմից, և " &
                    cCompany & "-ը (այսուհետ՝ Պատվիրատու), ի դեմս տնօրեն՝ " & cDirector &
                    "Ի, մյուս կողմից, ղեկավարվելով ՀՀ գործող օրենսդրությամբ և հիմք ընդունելով կողմերի միջև կնքված թիվ " & contract &
                    " Հսկիչ-Դրամարկղային մեքենաների սպասարկման պայմանագիրը (այսուհետ՝ Պայմանագիր), կնքեցին սույն համաձայնագիրը հետևյալի մասին․ "
                .Range("A16").Value = sCompany
                .Range("A17").Value = "Հասցե` " & sAddress
                .Range("A21").Value = "ՀՎՀՀ` " & sHVHH
                .Range("A23").Value = "Հ/Հ՝ " & sHH
                .Range("A24").Value = "Բանկ` " & sBankName
                .Range("A28").Value = sDirector
                .Range("F16").Value = cCompany
                .Range("F17").Value = "Իր. Հասցե` " & cIravAddress
                .Range("F19").Value = "Առաք. Հասցե` " & cAraqAddress
                .Range("F21").Value = "ՀՎՀՀ` " & cHVHH
                .Range("F22").Value = "Հեռ` " & cTel
                .Range("F28").Value = cDirector
                If sHVHH = "01562313" Then
                    .Range("A9").Value = "1. Պայմանագրի 3.3 կետը շարադրել հետևյալ խմբագրությամբ՝ " & vbCrLf &
                        "<<3.3 ՀԴՄ-ի վերանորոգման համար անհրաժեշտ պարագաների (պահեստամասերի և այլն)  արժեքը ներառված է 3.1 կետում սահմանված ընթացիկ սպասարկման արժեքի" &
                        " մեջ, բացառությամբ՝ մարտկոցի, ցանցային ադապտորի, լիցքավորիչի, թերմոտպիչի, էկրանի և ֆիսկալի, որոնց համար Կատարողին վճարվում է Կատարողի մոտ գործող" &
                        " գնացուցակի համաձայն>>: PAX մոդելի ՀԴՄ-ի վերանորոգման համար անհրաժեշտ պարագաների (պահեստամասերի և այլն) արժեքը ներառված չէ 3.1 կետում սահմանված" &
                        " ընթացիկ սպասարկման արժեքի մեջ, որոնց համար Կատարողին վճարվում է Կատարողի կողմից սահմանված գնացուցակի համաձայն:" & vbCrLf &
                        "2.Սույն համաձայնագիրը հանդիսանում է Պայմանագրի անբաժանելի մասը և ուժի մեջ է մտնում ստորագրման պահից"
                End If

            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            sheet.PrintOutEx(1, 1, 2, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            iDB.AddHamadzaynagir(dt.Rows(0)("ՀՎՀՀ"), strRandom, iUser.UserID, cbPrintHamadzaynagir.Checked)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class