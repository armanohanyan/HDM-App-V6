Imports DevExpress.XtraGrid
Imports DevExpress.XtraBars.Docking

Public Class RemakeWindow

    Private iDuration As String = "00:00"
    Friend Ecr As String = String.Empty
    Dim isError As Boolean = False
    Dim remakeID As Integer
    Dim tarifID As Short = 0

    Private Sub PrintAktForInvoiceItems(ByVal remID As Integer)
        Try
            Dim dt As DataTable = iDB.AktInfoForRemakeClose(Ecr)
            Dim dt_I As DataTable = iDB.AktForInvoiceItems(remID)
            If dt_I.Rows(0)("EquipmentName") <> "0" Then

                Dim rr As New Random
                Dim strRandom = rr.Next(1000000000, Integer.MaxValue)

                Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\HDM AKT"
                If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
                strPath &= "\Temp"
                If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
                My.Computer.FileSystem.WriteAllBytes(strPath & "\" & strRandom & ".xlsx", My.Resources.AktInvoiceItemsLast, False)


                Dim iClient = New With {.Կազմակերպություն = dt.Rows(0)("Անվանում"),
                        .Տնօրեն = dt.Rows(0)("Տնօրեն2"),
                        .ՀՎՀՀ = dt.Rows(0)("ՀՎՀՀ"),
                        .ՀԴՄ = dt.Rows(0)("ՀԴՄ")}

                Dim iPatkan = New With {.Կազմակերպություն = dt.Rows(0)("Կազմակերպություն"),
                        .ՀՎՀՀ = dt.Rows(0)("ՊՀՎՀՀ"),
                        .Տնօրեն = dt.Rows(0)("Տնօրեն"),
                        .ԱԱՀ = dt.Rows(0)("ԱԱՀ"),
                        .Bank = dt.Rows(0)("Bank"),
                        .BankAccount = dt.Rows(0)("BankAccount")}

                Dim xlApp As New Microsoft.Office.Interop.Excel.Application
                Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(strPath & "\" & strRandom & ".xlsx")
                xlApp.DisplayAlerts = False
                Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

                With sheet.PageSetup
                    .PrintTitleRows = ""
                    .PrintTitleColumns = ""

                    '.PrintArea =""
                    .PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4

                    .Zoom = 83

                End With

                With sheet
                    .Range("H2").Value = Date.Now.ToString("dd.MM.yyyy")
                    .Range("H39").Value = Date.Now.ToString("dd.MM.yyyy")

                    .Range("A4").Value = "Մի կողմից «" & iClient.Կազմակերպություն & "»-ն, որպես Կողմ-1, ի դեմս " & iClient.Տնօրեն & "-ի և մյուս կողմից " & iPatkan.Կազմակերպություն & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & iPatkan.Տնօրեն & ", ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."
                    .Range("A41").Value = "Մի կողմից «" & iClient.Կազմակերպություն & "»-ն, որպես Կողմ-1, ի դեմս " & iClient.Տնօրեն & "-ի և մյուս կողմից " & iPatkan.Կազմակերպություն & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & iPatkan.Տնօրեն & ", ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."

                    Dim total As Decimal = 0
                    Dim b17 As Integer = 0
                    Dim b52 As Integer = 0

                    Dim r As Microsoft.Office.Interop.Excel.Range

                    For i As Integer = 0 To dt_I.Rows.Count - 1

                        Dim q_ As Integer = dt_I.Rows(i)("Quantity")
                        Dim s_ As Decimal = 0
                        If iPatkan.Կազմակերպություն.Contains("Տամա") = True Then
                            s_ = dt_I.Rows(i)("SalePrice")
                        Else
                            s_ = dt_I.Rows(i)("SalePrice") * 1.2
                        End If

                        Dim T_ As Decimal = q_ * s_

                        b17 = i + 17
                        b52 = i + 52

                        r = .Range("B" & b17)
                        r.Value = dt_I.Rows(i)("EquipmentName")

                        r = .Range("B" & b52)
                        r.Value = dt_I.Rows(i)("EquipmentName")

                        r = .Range("E" & b17)
                        r.Value = q_

                        r = .Range("E" & b52)
                        r.Value = q_

                        r = .Range("F" & b17)
                        r.Value = s_

                        r = .Range("F" & b52)
                        r.Value = s_

                        r = .Range("H" & b17)
                        r.Value = T_

                        r = .Range("H" & b52)
                        r.Value = T_

                        total += T_

                    Next

                    'Set Total
                    r = .Range("H27")
                    r.Value = total

                    r = .Range("H62")
                    r.Value = total

                    'Set Company Info
                    r = .Range("C30")
                    r.Value = iClient.Կազմակերպություն

                    r = .Range("C65")
                    r.Value = iClient.Կազմակերպություն

                    r = .Range("I30")
                    r.Value = iPatkan.Կազմակերպություն

                    r = .Range("I65")
                    r.Value = iPatkan.Կազմակերպություն

                    r = .Range("G31")
                    r.Value = "Բանկ՝ "

                    r = .Range("G66")
                    r.Value = "Բանկ՝ "

                    r = .Range("I31")
                    r.Value = iPatkan.Bank

                    r = .Range("I66")
                    r.Value = iPatkan.Bank

                    r = .Range("G32")
                    r.Value = "Հ/Հ՝ "

                    r = .Range("G67")
                    r.Value = "Հ/Հ՝ "

                    r = .Range("I32")
                    r.Value = iPatkan.BankAccount

                    r = .Range("I67")
                    r.Value = iPatkan.BankAccount

                    r = .Range("C33")
                    r.Value = iClient.ՀՎՀՀ

                    r = .Range("C68")
                    r.Value = iClient.ՀՎՀՀ

                    r = .Range("I33")
                    r.Value = iPatkan.ՀՎՀՀ

                    r = .Range("I68")
                    r.Value = iPatkan.ՀՎՀՀ

                    r = .Range("A15")
                    r.Value = "Լրացում՝ պահեստամասերը և աքսեսուարները նախատեսված են " & Ecr & " ՀԴՄ-ի համար"
                    r = .Range("A50")
                    r.Value = "Լրացում՝ պահեստամասերը և աքսեսուարները նախատեսված են " & Ecr & " ՀԴՄ-ի համար"

                End With

                sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

                wbk.Close(SaveChanges:=True)
                xlApp.Quit()
                xlApp = Nothing

            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub PrintZeroAkt(ByVal RemakeID3 As Integer)

        Dim dt As DataTable = iDB.GetEquipmentForZeroAkt(RemakeID3)
        Dim dtSupporter As DataTable = iDB.GetSupporterForZeroAkt(RemakeID3)
        Dim dtClient As DataTable = iDB.GetClientForZeroAkt(RemakeID3)

        If dtSupporter.Rows.Count = 0 Then Throw New Exception("Սպասարկողի տվյալները չեն ստացվել")
        If dtClient.Rows.Count = 0 Then Throw New Exception("Գործընկերոջ տվյալները չեն ստացվել")

        Dim supporter_ID As Byte = dtSupporter.Rows(0)("SupporterID")

        If dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("MaxPrice") <= 0 Then Throw New Exception("Հայտնաբերվել է զրոյական գումարով սարքավորում")
            Next

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\RemZeroAkt"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\" & Now.Year & Now.Month & Now.Day
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            Dim rund As New Random
            Dim f As String = strPath & "\AKT_" & txtHvhh.Text & "_" & rund.Next(0, Integer.MaxValue) & ".xlsx"
            If IO.File.Exists(f) Then Throw New Exception("Նույն անունով ֆայլ է հայտնաբերվել")
            My.Computer.FileSystem.WriteAllBytes(f, My.Resources.aktZeroLast, False)

            Dim info As New List(Of aktEquipment)

            For i As Integer = 0 To dt.Rows.Count - 1
                info.Add(New aktEquipment(dt.Rows(i)("EquipmentName"), dt.Rows(i)("Quantity"), dt.Rows(i)("MaxPrice")))
            Next

            'Export To Excel
            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(f)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)


            xlApp.DisplayAlerts = False
            With sheet.PageSetup
                .PrintTitleRows = ""
                .PrintTitleColumns = ""

                .PrintArea = ""
                .PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4

                .Zoom = 90

                'Change Options
                .CenterHorizontally = True
                .CenterVertically = False
                .ScaleWithDocHeaderFooter = True
                .AlignMarginsHeaderFooter = False

                'Set Margins
                .LeftMargin = xlApp.InchesToPoints(0.28)
                .TopMargin = xlApp.InchesToPoints(0.16)
                .BottomMargin = xlApp.InchesToPoints(0.16)
                .HeaderMargin = xlApp.InchesToPoints(0.16)
                .RightMargin = xlApp.InchesToPoints(0.24)
                .FooterMargin = xlApp.InchesToPoints(0.16)
            End With

            Dim r As Microsoft.Office.Interop.Excel.Range

            '-------------------------------------------------

            'Supporter
            r = sheet.Range("C1") : r.Value = dtSupporter.Rows(0)("Company")
            r = sheet.Range("C2") : r.Value = dtSupporter.Rows(0)("Address")
            r = sheet.Range("C3") : r.Value = dtSupporter.Rows(0)("HVHH")

            'Client
            r = sheet.Range("C5") : r.Value = dtClient.Rows(0)("CompanyName")
            r = sheet.Range("C6") : r.Value = dtClient.Rows(0)("AddressName")
            r = sheet.Range("C7") : r.Value = dtClient.Rows(0)("HVHH")

            r = sheet.Range("E5") : r.Value = dtClient.Rows(0)("Contract")
            r = sheet.Range("E6") : r.Value = txtEcr.Text

            For i As Integer = 0 To info.Count - 1
                r = sheet.Range("B" & i + 11)
                r.Value = info.Item(i).Equipment

                r = sheet.Range("D" & i + 11)
                r.Value = info.Item(i).Count
                r.HorizontalAlignment = -4108       'HorizontalAlignment.Center

                r = sheet.Range("E" & i + 11)
                r.Value = info.Item(i).Price
                r.HorizontalAlignment = -4108

                r = sheet.Range("F" & i + 11)
                r.Value = info.Item(i).Price * info.Item(i).Count
                r.HorizontalAlignment = -4108

            Next

            'Date
            With sheet.Range("D3")
                .Value = "Հանձնման-ընդունման ամսաթիվ " & Now.ToString("dd.MM.yyyy") & " թ."
                .HorizontalAlignment = -4108
            End With

            'AKT N
            Dim Akt_Number As Integer = iDB.GetAktRemakeZeroCloseNumber(supporter_ID, RemakeID3)
            With sheet.Range("D1")
                .Value = "Հանձնման-ընդունման ակտ N " & Akt_Number
                .HorizontalAlignment = -4108
            End With

            '-------------------------------------------------


            'Supporter
            r = sheet.Range("C29") : r.Value = dtSupporter.Rows(0)("Company")
            r = sheet.Range("C30") : r.Value = dtSupporter.Rows(0)("Address")
            r = sheet.Range("C31") : r.Value = dtSupporter.Rows(0)("HVHH")

            'Client
            r = sheet.Range("C33") : r.Value = dtClient.Rows(0)("CompanyName")
            r = sheet.Range("C34") : r.Value = dtClient.Rows(0)("AddressName")
            r = sheet.Range("C35") : r.Value = dtClient.Rows(0)("HVHH")

            r = sheet.Range("E33") : r.Value = dtClient.Rows(0)("Contract")
            r = sheet.Range("E34") : r.Value = txtEcr.Text

            For i As Integer = 0 To info.Count - 1
                r = sheet.Range("B" & i + 39)
                r.Value = info.Item(i).Equipment

                r = sheet.Range("D" & i + 39)
                r.Value = info.Item(i).Count
                r.HorizontalAlignment = -4108       'HorizontalAlignment.Center

                r = sheet.Range("E" & i + 39)
                r.Value = info.Item(i).Price
                r.HorizontalAlignment = -4108

                r = sheet.Range("F" & i + 39)
                r.Value = info.Item(i).Price * info.Item(i).Count
                r.HorizontalAlignment = -4108

            Next

            'Date
            With sheet.Range("D31")
                .Value = "Հանձնման-ընդունման ամսաթիվ " & Now.ToString("dd.MM.yyyy") & " թ."
                .HorizontalAlignment = -4108
            End With

            'AKT N
            With sheet.Range("D29")
                .Value = "Հանձնման-ընդունման ակտ N " & Akt_Number
                .HorizontalAlignment = -4108
            End With

            '-------------------------------------------------

            'Print Excel
            sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            'Open Excel
            'Process.Start("Excel.exe", Chr(34) & f & Chr(34))

        End If

    End Sub
    'Arman | Hovo 06.08.2017
    Private Sub PrintAnvjarAkt(ByVal RemakeID3 As Integer)

        Dim dt As DataTable = iDB.GetEquipmentForAnvjarAkt(RemakeID3)
        Dim dtSupporter As DataTable = iDB.GetSupporterForZeroAkt(RemakeID3)
        Dim dtClient As DataTable = iDB.GetClientForZeroAkt(RemakeID3)

        If dtSupporter.Rows.Count = 0 Then Throw New Exception("Սպասարկողի տվյալները չեն ստացվել")
        If dtClient.Rows.Count = 0 Then Throw New Exception("Գործընկերոջ տվյալները չեն ստացվել")

        Dim supporter_ID As Byte = dtSupporter.Rows(0)("SupporterID")

        If dt.Rows.Count > 0 Then

            'For i As Integer = 0 To dt.Rows.Count - 1
            '    If dt.Rows(i)("MaxPrice") <= 0 Then Throw New Exception("Հայտնաբերվել է զրոյական գումարով սարքավորում")
            'Next

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\RemZeroAkt"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\" & Now.Year & Now.Month & Now.Day
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            Dim rund As New Random
            Dim f As String = strPath & "\AKT_" & txtHvhh.Text & "_" & rund.Next(0, Integer.MaxValue) & ".xlsx"
            If IO.File.Exists(f) Then Throw New Exception("Նույն անունով ֆայլ է հայտնաբերվել")
            My.Computer.FileSystem.WriteAllBytes(f, My.Resources.aktAnvjarLast, False)

            Dim info As New List(Of aktEquipment)

            For i As Integer = 0 To dt.Rows.Count - 1
                info.Add(New aktEquipment(dt.Rows(i)("EquipmentName"), dt.Rows(i)("Quantity"), dt.Rows(i)("MaxPrice")))
            Next

            'Export To Excel
            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(f)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)


            xlApp.DisplayAlerts = False
            With sheet.PageSetup
                .PrintTitleRows = ""
                .PrintTitleColumns = ""

                .PrintArea = ""
                .PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4

                .Zoom = 90

                'Change Options
                .CenterHorizontally = True
                .CenterVertically = False
                .ScaleWithDocHeaderFooter = True
                .AlignMarginsHeaderFooter = False

                'Set Margins
                .LeftMargin = xlApp.InchesToPoints(0.28)
                .TopMargin = xlApp.InchesToPoints(0.16)
                .BottomMargin = xlApp.InchesToPoints(0.16)
                .HeaderMargin = xlApp.InchesToPoints(0.16)
                .RightMargin = xlApp.InchesToPoints(0.24)
                .FooterMargin = xlApp.InchesToPoints(0.16)
            End With

            Dim r As Microsoft.Office.Interop.Excel.Range

            '-------------------------------------------------

            'Supporter
            r = sheet.Range("C1") : r.Value = dtSupporter.Rows(0)("Company")
            r = sheet.Range("C2") : r.Value = dtSupporter.Rows(0)("Address")
            r = sheet.Range("C3") : r.Value = dtSupporter.Rows(0)("HVHH")

            'Client
            r = sheet.Range("C5") : r.Value = dtClient.Rows(0)("CompanyName")
            r = sheet.Range("C6") : r.Value = dtClient.Rows(0)("AddressName")
            r = sheet.Range("C7") : r.Value = dtClient.Rows(0)("HVHH")

            r = sheet.Range("E5") : r.Value = dtClient.Rows(0)("Contract")
            r = sheet.Range("E6") : r.Value = txtEcr.Text

            For i As Integer = 0 To info.Count - 1
                r = sheet.Range("B" & i + 11)
                r.Value = info.Item(i).Equipment

                r = sheet.Range("D" & i + 11)
                r.Value = info.Item(i).Count
                r.HorizontalAlignment = -4108       'HorizontalAlignment.Center

                'r = sheet.Range("E" & i + 11)
                'r.Value = info.Item(i).Price
                'r.HorizontalAlignment = -4108

                'r = sheet.Range("F" & i + 11)
                'r.Value = info.Item(i).Price * info.Item(i).Count
                'r.HorizontalAlignment = -4108

            Next

            'Date
            With sheet.Range("D3")
                .Value = "Վերանորոգման ամսաթիվ " & Now.ToString("dd.MM.yyyy") & " թ."
                .HorizontalAlignment = -4108
            End With

            'AKT N
            Dim Akt_Number As Integer = iDB.GetAktRemakeZeroCloseNumber(supporter_ID, RemakeID3)
            With sheet.Range("D1")
                .Value = "Վերանորոգման ակտ N " & Akt_Number
                .HorizontalAlignment = -4108
            End With

            '-------------------------------------------------


            'Supporter
            r = sheet.Range("C29") : r.Value = dtSupporter.Rows(0)("Company")
            r = sheet.Range("C30") : r.Value = dtSupporter.Rows(0)("Address")
            r = sheet.Range("C31") : r.Value = dtSupporter.Rows(0)("HVHH")

            'Client
            r = sheet.Range("C33") : r.Value = dtClient.Rows(0)("CompanyName")
            r = sheet.Range("C34") : r.Value = dtClient.Rows(0)("AddressName")
            r = sheet.Range("C35") : r.Value = dtClient.Rows(0)("HVHH")

            r = sheet.Range("E33") : r.Value = dtClient.Rows(0)("Contract")
            r = sheet.Range("E34") : r.Value = txtEcr.Text

            For i As Integer = 0 To info.Count - 1
                r = sheet.Range("B" & i + 39)
                r.Value = info.Item(i).Equipment

                r = sheet.Range("D" & i + 39)
                r.Value = info.Item(i).Count
                r.HorizontalAlignment = -4108       'HorizontalAlignment.Center

                'r = sheet.Range("E" & i + 39)
                'r.Value = info.Item(i).Price
                'r.HorizontalAlignment = -4108

                'r = sheet.Range("F" & i + 39)
                'r.Value = info.Item(i).Price * info.Item(i).Count
                'r.HorizontalAlignment = -4108

            Next

            'Date
            With sheet.Range("D31")
                .Value = "Վերանորոգման ամսաթիվ " & Now.ToString("dd.MM.yyyy") & " թ."
                .HorizontalAlignment = -4108
            End With

            'AKT N
            With sheet.Range("D29")
                .Value = "Վերանորոգման ակտ N " & Akt_Number
                .HorizontalAlignment = -4108
            End With

            '-------------------------------------------------

            'Print Excel
            sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            'Open Excel
            'Process.Start("Excel.exe", Chr(34) & f & Chr(34))

        End If

    End Sub
    Private Sub loadSubItems()
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            Dim remakeID As Integer = GridView1.GetFocusedDataRow.Item("RemakeID").ToString

            Dim dt As DataTable = iDB.EquipmentListForRemake(remakeID)
            GridControl2.BeginUpdate()
            GridControl2.DataSource = dt
            GridView2.ClearSelection()
            GridControl2.EndUpdate()
            GridView2.Columns("SoldEquipmentID").Visible = False

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub loadData()
        Try
            Dim dt As DataTable = iDB.GetRemakeListByEcr(Ecr)

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()
            GridControl1.DataSource = dt
            GridControl1.EndUpdate()

            With GridView1
                .Columns("RemakeID").Visible = False
                .Columns("tarifID").Visible = False
                .Columns("EcrID").Visible = False
                .Columns("ClientID").Visible = False
                .Columns("Սպասարկող").Visible = False
                .ClearSorting()
                .OptionsCustomization.AllowFilter = False
                .Columns("RemakeID").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .Columns("ՀայտիԱմսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .Columns("ՀայտիԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("ՀայտիԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                .OptionsCustomization.AllowSort = False

                .FocusedRowHandle = 0

            End With

            If GridView1.RowCount > 0 Then
                tarifID = GridView1.GetRowCellValue(0, "tarifID")
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            isError = True
        Catch ex As Exception
            Call SoftException(ex)
            isError = True
        End Try
    End Sub
    Private Sub loadStatus()
        Try
            Dim dt As DataTable = iDB.EcrStatusForRemake(Ecr)

            If dt.Rows.Count > 0 Then
                txtHvhh.Text = dt.Rows(0)("ՀՎՀՀ")
                txtCompany.Text = dt.Rows(0)("Կազմակերպություն")
                txtGprs.Text = dt.Rows(0)("Արգելափակված")
                txtGarant.Text = dt.Rows(0)("Երաշխիքային")
                txtPayment.Text = dt.Rows(0)("Պարտք")

                If dt.Rows(0)("Պարտք") >= 0 Then
                    txtPayment.ForeColor = Color.Green
                Else
                    txtPayment.ForeColor = Color.Red
                End If

                If dt.Rows(0)("Արգելափակված") = "GPRS` Նորմալ" Then
                    txtGprs.ForeColor = Color.Green
                Else
                    txtGprs.ForeColor = Color.Red
                End If

                If txtGarant.Text = "Երաշխիքային" Then
                    txtGarant.ForeColor = Color.Green
                Else
                    txtGarant.ForeColor = Color.Red
                End If
            Else
                Throw New Exception("Տվյալներ չեն ստացվել")
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            isError = True
        Catch ex As Exception
            Call SoftException(ex)
            isError = True
        End Try
    End Sub
    Private Sub loadHayt()
        Try
            Dim dt As DataTable = iDB.LoadProblemList()
            With cbHayt
                .DataSource = dt
                .DisplayMember = "Problem"
                .ValueMember = "IsSoftware"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            isError = True
        Catch ex As Exception
            Call SoftException(ex)
            isError = True
        End Try
    End Sub
    Private Sub loadReplaced()
        Try
            Dim s As String = iDB.GetReplacedECRByRemake(Ecr)
            If String.IsNullOrEmpty(s) Then
                s = "Փոխարինված չկա"
            End If
            txtReplaced.Text = s
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            isError = True
        Catch ex As Exception
            Call SoftException(ex)
            isError = True
        End Try
    End Sub
    Private Sub SetGarantIfRemakeExists()
        Try
            Dim s As String = iDB.GetGarantForRemakeEcr(Ecr)

            If s = "-" Then Exit Sub

            txtGarant.Text = s

            If txtGarant.Text = "Երաշխիքային" Then
                txtGarant.ForeColor = Color.Green
            Else
                txtGarant.ForeColor = Color.Red
            End If
            txtGarant.Refresh()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            isError = True
        Catch ex As Exception
            Call SoftException(ex)
            isError = True
        End Try
    End Sub
    Private Sub RemakeWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub RemakeWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Ecr <> String.Empty Then
            txtEcr.Text = Ecr
        End If
        Call loadHayt()
        Call loadStatus()
        Call loadData()
        Call loadReplaced()
        'Call setTarif()
        If GridView1.RowCount > 0 Then Call SetGarantIfRemakeExists()
        If isError = True Then btnAdd.Enabled = False

        On Error Resume Next
        If GridView1.RowCount > 0 Then
            remakeID = GridView1.GetRowCellValue(0, "RemakeID")
        End If

        Dim hasGprs As Boolean = iDB.HasGlobalPropGetEcrGPRSStatus(Ecr) 'Artyom | Arman
        If hasGprs = True Then
            txtGprs.BackColor = Color.Red
        End If

    End Sub
    Private Sub btnNewHayt_Click(sender As Object, e As EventArgs) Handles btnNewHayt.Click
        If CheckPermission2("462F98F7420D4CF299D0ED20216D680F") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Dim f As New NewProblem
        f.ShowDialog()
        f.Dispose()

        loadHayt()
    End Sub
    Private Sub GridView1_FocusedRowChanged(sender As Object, e As Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Call loadSubItems()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If CheckPermission2("2E74D56001D7411E926B464E2F512615") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            'txtHvhh.Visible = False
            MainWindow.InfoPanel.Visibility = DockVisibility.Hidden

            'Բաց հայտի ստուգում
            If iDB.DetectOpenRemake3(Ecr) = True Then Throw New Exception("Այս ՀԴՄ-ի համար առկա է բաց հայտ")

            'Վերագրանցման ստուգում
            'If iDB.CheckReRegisterStatusForRemake(Ecr) = True Then Throw New Exception("Այս ՀԴՄ-ի համար հարկավոր է կատարել վերագրանցում")

            'Չսպասարկման առկայության ստուգում
            Dim retQ As String = iDB.RemakeNotServed(Ecr)
            If Not String.IsNullOrEmpty(retQ) Then
                Throw New Exception(retQ)
            End If

            If GridView1.RowCount > 0 Then
                GridView1.Columns("ՀՎՀՀ").Visible = False
            End If

            'Ակտի տրամադրում և Հայտի Բացում
            '///////////////////////////////////////////////////////////////////////////////////////////////////////

            'Clipboard.Clear()

            Dim f As New OpenRemakeAkt

            Dim strState As String = String.Empty

            If NoCase.Checked = True Then
                strState = " առանց տուփի"
            Else
                strState = " տուփով"
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

            Dim hayt As String
            If OutDamaged.Checked Then
                hayt = cbHayt.Text & " (Արտաքին Վնասվածքով " & "[ " & txtDamageText.Text.Trim & " ] ) " & strState
            Else
                hayt = cbHayt.Text & " (Առանց արտաքին վնասվածքի) " & strState
            End If

            With f

                If OutDamaged.Checked = True Then
                    If txtDamageText.Text.Trim <> String.Empty Then
                        .DamageText = " (" & txtDamageText.Text.Trim & ") "
                    End If
                End If

                .hvhh = txtHvhh.Text.Trim
                .ecr = Ecr
                .hayt = hayt
                .isSoft = cbHayt.SelectedValue
                .isDamaged = OutDamaged.Checked
                .strHDMState = strState

                .OnlyBattary = OnlyBattary.Checked

                .Tup = NoCase.Checked
                .Matit = NoStick.Checked
                .Licqavorich = NoCharger.Checked
                .Martkoc = NoBattary.Checked

                .ShowDialog()
            End With

            Dim b As Boolean = f.Result
            f.Dispose()

            If b = False Then Exit Sub

            '///////////////////////////////////////////////////////////////////////////////////////////////////////

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            txtHvhh.Visible = True
            MainWindow.InfoPanel.Visibility = DockVisibility.Visible
            Call loadHayt()
            Call loadStatus()
            Call loadData()
            Call loadReplaced()
            Call SetGarantIfRemakeExists()
            If GridView1.RowCount > 0 Then
                GridView1.Columns("ՀՎՀՀ").Visible = True
            End If
        End Try
    End Sub
    Private Sub mnuChangeProposal_Click(sender As Object, e As EventArgs) Handles mnuChangeProposal.Click
        Try
            If CheckPermission2("69D234B39D8041BBB1F60D14122C7CA6") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.FocusedRowHandle <> 0 Then Throw New Exception("Նախկին հայտերի հետ չեք կարող գործողություն կատարել")

            Dim b As Boolean = iDB.IsRemakeOpenByEcr(Ecr)
            If b = False Then Throw New Exception("Ակտիվ հայտ չկա")

            If GridView1.FocusedRowHandle <> 0 Then Throw New Exception("Նախկին հայտերի հետ չեք կարող գործողություն կատարել")

            MsgBox("Եթե ընթացիկ հայտը ունի այլ պարամետրեր պետք է նախօրոք նշել այն: Օրինակ՝ Արտաքին Վնասվածք", MsgBoxStyle.Information, My.Application.Info.Title)

            Dim strState As String = String.Empty
            If NoCase.Checked OrElse NoCharger.Checked OrElse NoStick.Checked OrElse NoBattary.Checked Then
                If OutDamaged.Checked = True Then strState = ",առանց " Else strState = " առանց "

                If NoCase.Checked AndAlso strState.EndsWith("առանց ") Then strState &= "տուփի"

                If NoCharger.Checked AndAlso strState.EndsWith("առանց ") Then
                    strState &= " լիցքավորիչի"
                ElseIf NoCharger.Checked AndAlso (Not strState.EndsWith("առանց ")) Then
                    strState &= ", լիցքավորիչի"
                End If

                If NoStick.Checked AndAlso strState.EndsWith("առանց ") Then
                    strState &= " մատիտի"
                ElseIf NoStick.Checked AndAlso (Not strState.EndsWith("առանց ")) Then
                    strState &= ", մատիտի"
                End If

                If NoBattary.Checked AndAlso strState.EndsWith("առանց ") Then
                    strState &= " մարտկոցի"
                ElseIf NoBattary.Checked AndAlso (Not strState.EndsWith("առանց ")) Then
                    strState &= ", մարտկոցի"
                End If

            End If

            'Հայտի Փոփոխում
            Dim f As New changeProposal
            With f
                .Ecr = Ecr
                .isDamaged = OutDamaged.Checked
                .strState = strState
                .ShowDialog()
                .Dispose()
            End With

            RemakeWindow_Load(Me, Nothing)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub mnuTakeEcr_Click(sender As Object, e As EventArgs) Handles mnuTakeEcr.Click
        Try
            If CheckPermission2("E4A8F130B416419EAB5B86FB59774C00") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            If GridView1.FocusedRowHandle <> 0 Then Throw New Exception("Նախկին հայտերի հետ չեք կարող գործողություն կատարել")

            Dim s As String = iDB.GetReplacedECRByRemake(Ecr)

            If Not String.IsNullOrEmpty(s) Then Throw New Exception("ՀԴՄ-ի համար փոխարինվող տրված է")

            'Բաց հայտի ստուգում
            If iDB.DetectOpenRemake(Ecr) = False Then Throw New Exception("Այս ՀԴՄ-ի համար բաց հայտ չկա")

            Dim RemakeID_2 As Integer = GridView1.GetFocusedDataRow.Item("RemakeID").ToString

            'լիցքավորիչի ստուգում
            If iDB.IsBattary(RemakeID_2) = True Then
                Throw New Exception("Լիցքավորիչին փոխարինվող չի կարող տրամադրվել")
            End If

            '////////////////////////////////////////////////////////////////////////////////
            'Ակտի տրամադրում

            Dim f As New PoxarinoxEcr
            f.ԱկտՀԴՄ = Ecr
            f.remontID = RemakeID_2
            f.ShowDialog()
            Dim b As Boolean = f.Result
            f.Dispose()
            If b = False Then Exit Sub
            '////////////////////////////////////////////////////////////////////////////////

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Call loadReplaced()
        End Try
    End Sub
    Private Sub mnuGetEcr_Click(sender As Object, e As EventArgs) Handles mnuGetEcr.Click
        Try
            If CheckPermission2("524B70D63F224FEDA96C19F4F758B4B3") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            If GridView1.FocusedRowHandle <> 0 Then Throw New Exception("Նախկին հայտերի հետ չեք կարող գործողություն կատարել")

            Dim s As String = iDB.GetReplacedECRByRemake(Ecr)

            If String.IsNullOrEmpty(s) Then Throw New Exception("ՀԴՄ-ի համար փոխարինվող տրված չէ")

            Dim RemakeID_2 As Integer = GridView1.GetFocusedDataRow.Item("RemakeID").ToString

            '////////////////////////////////////////////////////////////////////////////////
            'Ակտի տրամադրում

            Dim f As New ReturnPoxarinoxECR
            f.ԱկտՀԴՄ = Ecr
            f.RemontID = RemakeID_2
            f.ShowDialog()
            Dim b As Boolean = f.Result
            f.Dispose()
            If b = False Then Exit Sub
            '////////////////////////////////////////////////////////////////////////////////

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Call loadReplaced()
        End Try
    End Sub
    Private Sub mnuSubmitProposal_Click(sender As Object, e As EventArgs) Handles mnuSubmitProposal.Click
        Try
            If CheckPermission2("20A2E83747F7445AB6DE91E877FAF6A1") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.FocusedRowHandle <> 0 Then Throw New Exception("Նախկին հայտերի հետ չեք կարող գործողություն կատարել")
            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            Dim RemakeID_2 As Integer = GridView1.GetFocusedDataRow.Item("RemakeID").ToString

            If iDB.CanBeRemakeApproved(RemakeID_2) = False Then Throw New Exception("ՀԴՄ-ի վրա որևէ գործողություն նշված չէ")

            'Բաց հայտի ստուգում
            If iDB.DetectOpenRemake2(RemakeID_2) = False Then Throw New Exception("Այս ՀԴՄ-ի համար առկա բաց հայտ չկա")

            'Ճտիկի ստուգում
            If iDB.CheckClicker(RemakeID_2) = False Then Throw New Exception("ՀԴՄ-ի արհեստանոցի հայտը փակ չէ կամ ՀԴՄ-ն արհեստանոցից չի ընդունվել և հաստատվել")

            Dim SupporterEcr As String = String.Empty
            Dim isReplacedExists As Boolean = False
            'Փոխարինման ստուգում
            Dim s As String = iDB.GetReplacedECRByRemake(Ecr)
            If String.IsNullOrEmpty(s) Then
                isReplacedExists = False
            Else
                isReplacedExists = True
                SupporterEcr = s
            End If

            'Կասեցման ստուգում
            iDB.RemakeEcrClientOKChecker(RemakeID_2)

            Dim f As New ApproveProposal
            With f
                .RemakeID = RemakeID_2
                .isReplacedExists = isReplacedExists
                .SupporterEcr = SupporterEcr
                .EcrID = GridView1.GetFocusedDataRow.Item("EcrID")
                .ClientID = GridView1.GetFocusedDataRow.Item("ClientID")
                .hvhh = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ")
                If IsDBNull(GridView1.GetFocusedDataRow.Item("Սպասարկող")) Then .SupporterID = 5 Else .SupporterID = GridView1.GetFocusedDataRow.Item("Սպասարկող")
                .ECR = txtEcr.Text
                .ShowDialog()
                .Dispose()
            End With

            RemakeWindow_Load(Me, Nothing)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuPrintInvoice_Click(sender As Object, e As EventArgs) Handles mnuPrintInvoice.Click
        Try
            If CheckPermission2("6D938FDA0F5341FEB7EF6F20B20E1B13") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.FocusedRowHandle <> 0 Then Throw New Exception("Նախկին հայտերի հետ չեք կարող գործողություն կատարել")
            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            Dim RemakeID_2 As Integer = GridView1.GetFocusedDataRow.Item("RemakeID").ToString
            Dim strSupporter As String = GridView1.GetFocusedDataRow.Item("ՍպասարկողԿազմ").ToString

            'Կասեցման ստուգում
            iDB.RemakeEcrClientOKChecker(RemakeID_2)

            iDB.CheckRemakeToMakeInvoice(RemakeID_2)

            Dim total As Decimal = 0
            Dim t1 As Decimal
            Dim t2 As Decimal
            Dim t3 As Decimal

            For i As Integer = 0 To GridView2.RowCount - 1
                t1 = GridView2.GetRowCellValue(i, "Գումար")
                t2 = GridView2.GetRowCellValue(i, "Քանակ")
                t3 = t1 * t2
                total += t3
            Next

            Dim f As New CreateRemakeInvoiceInfo
            With f
                .RemakeID = RemakeID_2
                .ECR = Ecr
                .ClientName = txtCompany.Text
                .HVHH = txtHvhh.Text
                .ECR_ID = GridView1.GetFocusedDataRow.Item("EcrID").ToString
                .ClientID = GridView1.GetFocusedDataRow.Item("ClientID").ToString
                .TotalSum = total
                .strSupporter = strSupporter

                .ShowDialog()
                .Dispose()
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            RemakeWindow_Load(Me, Nothing)
        End Try
    End Sub
    Private Sub mnuRefuse_Click(sender As Object, e As EventArgs) Handles mnuRefuse.Click
        Try
            If CheckPermission2("36BC0147F3E14DC6AB290778E74D1F61") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            If GridView1.FocusedRowHandle <> 0 Then Throw New Exception("Նախկին հայտերի հետ չեք կարող գործողություն կատարել")

            If MsgBox("Ցանկանու՞մ եք մերժել հայտը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            Dim RemakeID_2 As Integer = GridView1.GetFocusedDataRow.Item("RemakeID").ToString

            'Փոխարինման ստուգում
            Dim s As String = iDB.GetReplacedECRByRemake(Ecr)
            If String.IsNullOrEmpty(s) Then
                'OK
            Else
                Throw New Exception("ՀԴՄ-ին փոխարինվող է տրված")
            End If

            'Ճտիկի ստուգում
            If iDB.CheckClicker(RemakeID_2) = False Then Throw New Exception("ՀԴՄ-ի արհեստանոցի հայտը փակ չէ կամ ՀԴՄ-ն արհեստանոցից չի ընդունվել և հաստատվել")

            'Ստուգել փակ, ինվոյս, մերժված
            iDB.GetOpenRemakeInfoForRefuse(RemakeID_2)

            'Սարքավորման առկայության ստուգում
            If iDB.CheckForRemakeEquipment(RemakeID_2) = True Then Throw New Exception("Հայտին ավելացված են սարքավորումներ, հարկավոր է վերադարձնել արհեստանոց")

            'Ակտի տպում
            Dim f As New AktRefuse
            f.ԱկտՀԴՄ = Ecr
            f.RemakeID = RemakeID_2
            f.ShowDialog()
            Dim b As Boolean = f.Result
            f.Dispose()
            If b = False Then Exit Sub

            MsgBox("Հայտը մերժվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            RemakeWindow_Load(Me, Nothing)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuCloseProposal_Click(sender As Object, e As EventArgs) Handles mnuCloseProposal.Click
        Try
            If CheckPermission2("6F111911AC0441279112A9B93AF44D16") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            If GridView1.FocusedRowHandle <> 0 Then Throw New Exception("Նախկին հայտերի հետ չեք կարող գործողություն կատարել")

            If MsgBox("Ցանկանու՞մ եք փակել հայտը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            Dim RemakeID_2 As Integer = GridView1.GetFocusedDataRow.Item("RemakeID").ToString

            'Փոխարինման ստուգում
            Dim s As String = iDB.GetReplacedECRByRemake(Ecr)
            If String.IsNullOrEmpty(s) Then
                'OK
            Else
                Throw New Exception("ՀԴՄ-ին փոխարինվող է տրված")
            End If

            'Ճտիկի ստուգում
            If iDB.CheckClicker(RemakeID_2) = False Then Throw New Exception("ՀԴՄ-ի արհեստանոցի հայտը փակ չէ կամ ՀԴՄ-ն արհեստանոցից չի ընդունվել և հաստատվել")

            'Բաց հայտի ստուգում
            iDB.CloseRemakeHayt2(RemakeID_2)

            'Կասեցման ստուգում
            iDB.RemakeEcrClientOKChecker(RemakeID_2)

            'Տպել 0-յական ակտ
            PrintZeroAkt(RemakeID_2)

            'Arman | Hovo 06.08.2017
            'Տպել Անվճար ակտ
            PrintAnvjarAkt(RemakeID_2)

            'Տպել Ինվոյսի սարքավորումնեի ակտը
            PrintAktForInvoiceItems(RemakeID_2)

            'Ակտի տրամադրում
            Dim f As New aktForCloseHayt
            f.remontID = RemakeID_2
            f.ԱկտՀԴՄ = Ecr
            f.ShowDialog()
            Dim b As Boolean = f.Result
            f.Dispose()
            If b = False Then Exit Sub

            'Հայտի Փակում
            iDB.CloseRemakeHayt(RemakeID_2)

            MsgBox("Հայտը փակվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            RemakeWindow_Load(Me, Nothing)
        End Try
    End Sub
    Private Sub mnuChangePrice_Click(sender As Object, e As EventArgs) Handles mnuChangePrice.Click
        Try
            If CheckPermission2("87A8428A67B246979C9CB315F18111A1") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.FocusedRowHandle <> 0 Then Throw New Exception("Նախկին հայտերի հետ չեք կարող գործողություն կատարել")
            If GridView2.SelectedRowsCount = 0 Then Exit Sub

            Dim RemakeID_2 As Integer = GridView1.GetFocusedDataRow.Item("RemakeID").ToString

            'Բաց հայտի ստուգում
            If iDB.DetectOpenRemake2(RemakeID_2) = False Then Throw New Exception("Այս ՀԴՄ-ի համար առկա բաց հայտ չկա")

            If IsDBNull(GridView2.GetFocusedDataRow.Item("Գումար")) Then Throw New Exception("Նյութի համար գումարը չի կարող փոխվել")

            Dim tarif_ID As Short = iDB.GetRemakeTarifID(RemakeID_2)

            Dim RecID As Integer = GridView2.GetFocusedDataRow.Item("SoldEquipmentID").ToString
            Dim Price As Decimal = GridView2.GetFocusedDataRow.Item("Գումար").ToString
            Dim Equipment As String = GridView2.GetFocusedDataRow.Item("Սարքավորում").ToString

            Dim f As New EquipmentRemakeChangePrice With {.ID = RecID, .Price = Price, .Equipment = Equipment, .tarifID = tarif_ID}
            f.ShowDialog()
            f.Dispose()

            Call loadSubItems()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuAddFunction_Click(sender As Object, e As EventArgs) Handles mnuAddFunction.Click
        Try
            If CheckPermission2("F8F540A6BF2049C9A8C0D09527F739C8") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.FocusedRowHandle <> 0 Then Throw New Exception("Նախկին հայտերի հետ չեք կարող գործողություն կատարել")
            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            Dim RemakeID_2 As Integer = GridView1.GetFocusedDataRow.Item("RemakeID").ToString

            'Բաց հայտի ստուգում
            If iDB.DetectOpenRemake2(RemakeID_2) = False Then Throw New Exception("Այս ՀԴՄ-ի համար առկա բաց հայտ չկա")

            Dim f As New EcrFunctional With {.Ecr = Ecr}
            f.ShowDialog()
            f.Dispose()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub OnlyBattary_CheckedChanged(sender As Object, e As EventArgs) Handles OnlyBattary.CheckedChanged
        On Error Resume Next
        If OnlyBattary.Checked = True Then
            OutDamaged.Checked = False
            NoCase.Checked = False
            NoStick.Checked = False
            NoCharger.Checked = False
            NoBattary.Checked = False

            OutDamaged.Enabled = False
            NoCase.Enabled = False
            NoStick.Enabled = False
            NoCharger.Enabled = False
            NoBattary.Enabled = False

            txtDamageText.Text = String.Empty
            txtDamageText.Enabled = False

            cbHayt.Text = "Լիցքավորիչ"
            cbHayt.Enabled = False
            btnNewHayt.Enabled = False
        Else
            OutDamaged.Enabled = True
            NoCase.Enabled = True
            NoStick.Enabled = True
            NoCharger.Enabled = True
            NoBattary.Enabled = True
            txtDamageText.Enabled = True
            cbHayt.Enabled = True
            btnNewHayt.Enabled = True
        End If
    End Sub
    Private Sub OutDamaged_CheckedChanged(sender As Object, e As EventArgs) Handles OutDamaged.CheckedChanged
        If OutDamaged.Checked = True Then
            txtDamageText.Enabled = True
        Else
            txtDamageText.Text = String.Empty
            txtDamageText.Enabled = False
        End If
    End Sub

End Class

Public Class aktEquipment

    Public Sub New(ByVal սարքավորում As String, ByVal քանակ As Integer, ByVal գումար As Decimal)
        _equipment = սարքավորում
        _count = քանակ
        _price = գումար
    End Sub

    Private _equipment As String
    Private _count As Integer
    Private _price As Decimal

    Public Property Equipment As String
        Get
            Return _equipment
        End Get
        Set(value As String)
            _equipment = value
        End Set
    End Property
    Public Property Count As Integer
        Get
            Return _count
        End Get
        Set(value As Integer)
            _count = value
        End Set
    End Property
    Public Property Price As Decimal
        Get
            Return _price
        End Get
        Set(value As Decimal)
            _price = value
        End Set
    End Property

End Class