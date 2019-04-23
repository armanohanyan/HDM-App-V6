Imports Microsoft.Office.Interop.Excel

Public Class CreateRemakeInvoiceInfo

    Friend ECR As String
    Friend ECR_ID As Integer
    Friend ClientID As Integer
    Friend HVHH As String
    Friend RemakeID As Integer
    Friend ClientName As String
    Friend TotalSum As Decimal

    Friend strSupporter As String

    Dim isWorking As Boolean = False

    Private Sub SendInvoiceMessage()
        On Error Resume Next
        Dim b As Image
        b = My.Resources.infoWarning.ToBitmap

        iDB.AddPublicMessage(b, iUser.UserID, ECR & " ՀԴՄ-ի համար ստեղծվել է վերանորոգման Հ/Ա", False, 10)
        iDB.AddPublicMessage(b, iUser.UserID, ECR & " ՀԴՄ-ի համար ստեղծվել է վերանորոգման Հ/Ա", False, 12)

    End Sub
    Private Sub GenerateExcelInvoice(ByVal RemakeID As Integer)
        Try
            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Rem Invoise"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\" & Now.Year & Now.Month & Now.Day
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            Dim rund As New Random
            Dim f As String = strPath & "\Rem_" & HVHH & "_" & rund.Next(0, Integer.MaxValue) & ".xlsx"
            If IO.File.Exists(f) Then Throw New Exception("Նույն անունով ֆայլ է հայտնաբերվել")
            My.Computer.FileSystem.WriteAllBytes(f, My.Resources.Rem_Invoise, False)

            'Ստանալ Ինվոյսի ID
            Dim invoiseID As String = iDB.GetInvoiceNumberForRemake(RemakeID)

            'Փոփոխականների Հայտարարում
            Dim _Մատակարար = New With {.ՀՎՀՀ = "", .Կազմակերպություն = "", .Հասցե = "", .Տնօրեն = "",
               .Հաշվապահ = "", .Բանկ = "", .Հաշվեհամար = "", .Հապավում = "",
               .ԻնվոյսՀապավում = "", .ԱԱՀ = False}
            Dim _Գործընկեր = New With {.ՀՀ = -1, .ՀՎՀՀ = "", .Անվանում = "", .Տնօրեն = "", .ԻրավաբանականՀասցե = "", .ԱռաքմանՀասցե = "", .Տարածաշրջան = ""}

            Dim TotalPrice As Decimal = 0

            Dim _Սարքավորում As New List(Of Սարքավորումներ)

            Dim rCount As Integer = 0
            For i As Integer = 0 To GridView3.RowCount - 1

                Dim cCount As Integer = GridView3.GetRowCellValue(i, "Քանակ")
                Dim PricePerModel As Decimal = GridView3.GetRowCellValue(i, "Գումար")
                Dim SubTotalPrice As Decimal = cCount * PricePerModel

                If PricePerModel <= 0 Then Continue For
                rCount += 1
                _Սարքավորում.Add(New Սարքավորումներ(GridView3.GetRowCellValue(i, "Սարքավորում"), cCount, PricePerModel, SubTotalPrice))
                TotalPrice += SubTotalPrice
            Next
            If _Սարքավորում.Count = 0 Then Throw New Exception("Սարքավորումները բացակայում են")

            'Մատակարարի Տվյալների Ստացում
            Dim matDT As System.Data.DataTable = iDB.GetSupporterForRemakeInvoice(ClientID)
            If matDT Is Nothing OrElse matDT.Rows.Count = 0 Then Throw New Exception("Մատակարարի տվյալները չեն ստացվել")


            With _Մատակարար
                .ՀՎՀՀ = matDT.Rows(0)("HVHH")
                .Կազմակերպություն = matDT.Rows(0)("Company")
                .Հասցե = matDT.Rows(0)("Address")
                .Տնօրեն = matDT.Rows(0)("Director")
                .Հաշվապահ = matDT.Rows(0)("Accountant")
                .Բանկ = matDT.Rows(0)("Bank")
                .Հաշվեհամար = matDT.Rows(0)("BankAccount")
            End With


            'Գործընկերոջ տվյալների ստացում
            Dim gorcDT As System.Data.DataTable = iDB.GetClientForRemakeInvoice(ClientID)
            If gorcDT Is Nothing OrElse gorcDT.Rows.Count = 0 Then Throw New Exception("Գործընկերոջ տվյալները չեն ստացվել")

            With _Գործընկեր
                .ՀՀ = gorcDT.Rows(0)("ClientID")
                .ՀՎՀՀ = gorcDT.Rows(0)("HVHH")
                .Անվանում = gorcDT.Rows(0)("CompanyName")
                .Տնօրեն = gorcDT.Rows(0)("CompanyDirectorName")
                .ԻրավաբանականՀասցե = gorcDT.Rows(0)("IravabanakanAddress")
                .ԱռաքմանՀասցե = gorcDT.Rows(0)("AraqmanAddress")
                .Տարածաշրջան = gorcDT.Rows(0)("Region")
            End With

            'Export To Excel
            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(f)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)
            'Dont Show Error Messages
            xlApp.DisplayAlerts = False
            With sheet.PageSetup
                .PrintTitleRows = ""
                .PrintTitleColumns = ""

                .PrintArea = ""
                'Set Paper Size To A4
                .PaperSize = XlPaperSize.xlPaperA4

                'Set Zoom To 81%
                .Zoom = 81

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

            Dim r As Range

            'Set Ranges
            r = sheet.Range("A1", "B5")
            r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)

            r = sheet.Range("C1", "C5")
            r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)

            r = sheet.Range("D1", "G2") : r.Merge()
            r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            r = sheet.Range("D3", "G3") : r.Merge()
            r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            r = sheet.Range("D4", "G4") : r.Merge()
            r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)

            'Set Sizes

            'Set Size Width
            r = sheet.Range("A1") : r.ColumnWidth = 3.71
            r = sheet.Range("B1") : r.ColumnWidth = 28.71
            r = sheet.Range("C1") : r.ColumnWidth = 35.86
            r = sheet.Range("D1") : r.ColumnWidth = 10.14
            r = sheet.Range("E1") : r.ColumnWidth = 8.86
            r = sheet.Range("F1") : r.ColumnWidth = 13.29
            r = sheet.Range("G1") : r.ColumnWidth = 12.0

            ''Merge AND Size Height
            r = sheet.Range("A1", "B1") : r.Merge() : r.RowHeight = 18.0
            r = sheet.Range("A2", "B2") : r.Merge() : r.RowHeight = 21.0
            r = sheet.Range("A3", "B3") : r.Merge() : r.RowHeight = 26.25
            r = sheet.Range("A4", "B4") : r.Merge() : r.RowHeight = 24.0
            r = sheet.Range("A5", "B5") : r.Merge() : r.RowHeight = 19.5

            r = sheet.Range("A6") : r.RowHeight = 12.75

            'Set Values
            r = sheet.Range("A1") : r.Value = "Մատակարար"
            r = sheet.Range("A2") : r.Value = "Հասցե"
            r = sheet.Range("A3") : r.Value = "Բանկ"
            r = sheet.Range("A4") : r.Value = "Հ/Հ"
            r = sheet.Range("A5") : r.Value = "ՀՎՀՀ"
            sheet.Range("C1").Value = _Մատակարար.Կազմակերպություն
            sheet.Range("C2").Value = _Մատակարար.Հասցե
            sheet.Range("C3").Value = _Մատակարար.Բանկ
            sheet.Range("C4").Value = _Մատակարար.Հաշվեհամար
            sheet.Range("C5").Value = _Մատակարար.ՀՎՀՀ

            sheet.Range("D1").Value = "Հաշիվ ապրանքագիր N " & _Մատակարար.ԻնվոյսՀապավում & invoiseID
            sheet.Range("D3").Value = "Մատակարարման ամսաթիվ  " & DTPDate.DateTime.ToString("dd.MM.yyyy") & " թ."
            sheet.Range("D4").Value = "Դուրս գրման ամսաթիվ " & Chr(34) & "____" & Chr(34) & "______" & DTPDate.DateTime.Year & " թ."

            r = sheet.Range("A6") : r.RowHeight = 12.75
            r = sheet.Range("A12") : r.RowHeight = 12.75

            'Set Ranges
            r = sheet.Range("A7", "B11")
            r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)

            r = sheet.Range("C7", "C11")
            r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)

            ''Merge AND Size Height
            r = sheet.Range("A7", "B7") : r.Merge() : r.RowHeight = 21.75
            r = sheet.Range("A8", "B8") : r.Merge() : r.RowHeight = 21.0
            r = sheet.Range("A9", "B9") : r.Merge() : r.RowHeight = 20.25
            r = sheet.Range("A10", "B10") : r.Merge() : r.RowHeight = 20.25
            r = sheet.Range("A11", "B11") : r.Merge() : r.RowHeight = 21.0

            'Set Values
            r = sheet.Range("A7") : r.Value = "Վճարող"
            r = sheet.Range("A8") : r.Value = "Հասցե"
            r = sheet.Range("A9") : r.Value = "Բանկ"
            r = sheet.Range("A10") : r.Value = "Հ/Հ"
            r = sheet.Range("A11") : r.Value = "ՀՎՀՀ"
            sheet.Range("C7").Value = _Գործընկեր.Անվանում
            sheet.Range("C8").Value = _Գործընկեր.ԻրավաբանականՀասցե
            sheet.Range("C11").Value = _Գործընկեր.ՀՎՀՀ

            With sheet.Range("A13")
                .RowHeight = 24.0
                .Value = "N"
                .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            End With
            r = sheet.Range("B13", "C13") : r.Merge()
            With r
                .Value = "Մատուցված ծառայության անվանում"
                .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            End With
            With sheet.Range("D13")
                .Value = "Հատ"
                .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            End With
            With sheet.Range("E13")
                .Value = "արժեք"
                .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            End With
            With sheet.Range("F13")
                .Value = "գումար"
                .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            End With

            Dim excelRowID As Integer = 0

            For i As Integer = 1 To rCount
                With sheet.Range("A" & 13 + i)
                    .RowHeight = 21.75
                    .Value = i
                    .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
                End With
                r = sheet.Range("B" & 13 + i, "C" & 13 + i) : r.Merge()
                With r
                    .RowHeight = 21.75
                    .Value = _Սարքավորում(i - 1).Սարք & "-ի վաճառք"
                    .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
                End With
                With sheet.Range("D" & 13 + i)
                    .RowHeight = 21.75
                    .Value = _Սարքավորում(i - 1).Քանակ
                    .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
                End With
                With sheet.Range("E" & 13 + i)
                    .RowHeight = 21.75
                    .Value = _Սարքավորում(i - 1).ՄիավորիԱրժեք
                    .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
                End With
                With sheet.Range("F" & 13 + i)
                    .RowHeight = 21.75
                    .Value = _Սարքավորում(i - 1).ԸնդհանուրԱրժեք
                    .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
                End With
                excelRowID = 13 + i
            Next

            excelRowID += 1

            With sheet.Range("A" & excelRowID)
                .RowHeight = 21.75
                .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            End With
            r = sheet.Range("B" & excelRowID, "C" & excelRowID) : r.Merge()
            With r
                .RowHeight = 21.75
                .Value = "Ընդամենը"
                .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            End With
            With sheet.Range("D" & excelRowID)
                .RowHeight = 21.75
                .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            End With
            With sheet.Range("E" & excelRowID)
                .RowHeight = 21.75
                .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            End With
            With sheet.Range("F" & excelRowID)
                .RowHeight = 21.75
                .Value = TotalPrice
                .BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin)
            End With

            excelRowID += 2
            r = sheet.Range("B" & excelRowID) : r.RowHeight = 12.75 : r.Value = "Գումարը բառերով՝"
            r = sheet.Range("C" & excelRowID, "E" & excelRowID) : r.Merge() : r.Value = Tver(CLng(TotalPrice), True)

            excelRowID += 2
            r = sheet.Range("B" & excelRowID) : r.RowHeight = 12.75 : r.Value = "Վճարում կատարելիս նշել կազմ. անվանումը և ՀՎՀՀ-ն,հակառակ դեպքում բանկը չի ընդունի"

            excelRowID += 2
            r = sheet.Range("B" & excelRowID) : r.RowHeight = 21.0
            sheet.Range("B" & excelRowID).Value = "Տնօրեն՝"
            sheet.Range("C" & excelRowID).Value = _Մատակարար.Տնօրեն
            excelRowID += 2
            r = sheet.Range("B" & excelRowID) : r.RowHeight = 21.0
            excelRowID += 2
            r = sheet.Range("B" & excelRowID) : r.RowHeight = 21.0
            sheet.Range("B" & excelRowID).Value = "Հանձնեց__________________________"
            r = sheet.Range("D" & excelRowID) : r.RowHeight = 21.0
            sheet.Range("D" & excelRowID).Value = "Ընդունեց__________________________"
            excelRowID += 1
            r = sheet.Range("B" & excelRowID) : r.RowHeight = 21.0
            sheet.Range("B" & excelRowID).Value = "ԿՏ"
            r = sheet.Range("D" & excelRowID) : r.RowHeight = 21.0
            sheet.Range("D" & excelRowID).Value = "ԿՏ"


            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            Process.Start("Excel.exe", Chr(34) & f & Chr(34))

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub loadSubItems()
        Try
            Dim dt As System.Data.DataTable = iDB.EquipmentListForRemake(RemakeID)
            GridControl3.BeginUpdate()
            GridControl3.DataSource = dt
            GridView3.ClearSelection()
            GridControl3.EndUpdate()
            GridView3.Columns("SoldEquipmentID").Visible = False
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub CreateRemakeInvoiceInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtClient.Text = ClientName
        txtEcr.Text = ECR
        txtHVHH.Text = HVHH
        txtTotalPrice.Text = TotalSum
        DTPDate.DateTime = Now

        Call loadSubItems()
    End Sub
    Private Sub btnCreateInvoice_Click(sender As Object, e As EventArgs) Handles btnCreateInvoice.Click
        Try
            If isWorking = True Then Exit Sub
            isWorking = True

            'Check Invoice Price
            Dim mustPrintInvoice As Boolean
            mustPrintInvoice = iDB.MustPrintInvoice(RemakeID)

            If mustPrintInvoice = False Then
                MsgBox("Ինվոյս տպելու անհրաժեշտություն չկա", MsgBoxStyle.Information, My.Application.Info.Title)
                Me.Close()
                Exit Sub
            End If

            If strSupporter.Contains("Տամա") = True Then
                'Tama Invoice
                Call iDB.CreateRemakeInvoiceTama(ClientID, ECR_ID, RemakeID, ClientName, HVHH, DTPDate.DateTime)
            Else
                'Make Invoice
                If iDB.IsClientWithNDS(ClientID) = True Then
                    If iDB.IsClientWithZeroNDS(ClientID) = True Then
                        'No NDS WITH 0
                        Call iDB.CreateRemakeInvoiceWithNoNDS(ClientID, ECR_ID, RemakeID, ClientName, HVHH, DTPDate.DateTime)

                        'Print Excel
                        Call GenerateExcelInvoice(RemakeID)
                    Else
                        'NDS
                        Call iDB.CreateRemakeInvoiceWithNDS(ClientID, ECR_ID, RemakeID, ClientName, HVHH, DTPDate.DateTime)
                    End If
                Else
                    'No NDS
                    Call iDB.CreateRemakeInvoiceWithNoNDS(ClientID, ECR_ID, RemakeID, ClientName, HVHH, DTPDate.DateTime)

                    'Print Excel
                    Call GenerateExcelInvoice(RemakeID)
                End If
            End If

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Call SendInvoiceMessage()

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            isWorking = False
        End Try
    End Sub

End Class

Public Class Սարքավորումներ

    Private _Սարքավուրում1 As String
    Private _Քանակ1 As Integer
    Private _ՄիավորիԱրժեք1 As Decimal
    Private _ԸնդհանուրԱրժեք1 As Decimal

    Protected Friend Sub New(ByVal _model As String, ByVal _count As Integer, ByVal _pricePerModel As Decimal, ByVal _Total As Decimal)
        _Սարքավուրում1 = _model
        _Քանակ1 = _count
        _ՄիավորիԱրժեք1 = _pricePerModel
        _ԸնդհանուրԱրժեք1 = _Total
    End Sub

    Public Property Սարք As String
        Get
            Return _Սարքավուրում1
        End Get
        Set(value As String)
            _Սարքավուրում1 = value
        End Set
    End Property
    Public Property Քանակ As Integer
        Get
            Return _Քանակ1
        End Get
        Set(value As Integer)
            _Քանակ1 = value
        End Set
    End Property
    Public Property ՄիավորիԱրժեք As Decimal
        Get
            Return _ՄիավորիԱրժեք1
        End Get
        Set(value As Decimal)
            _ՄիավորիԱրժեք1 = value
        End Set
    End Property
    Public Property ԸնդհանուրԱրժեք As Decimal
        Get
            Return _ԸնդհանուրԱրժեք1
        End Get
        Set(value As Decimal)
            _ԸնդհանուրԱրժեք1 = value
        End Set
    End Property

End Class