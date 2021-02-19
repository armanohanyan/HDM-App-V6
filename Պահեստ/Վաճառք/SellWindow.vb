Imports DevExpress.XtraGrid
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid

Public Class SellWindow

    Friend ClientID As Integer
    Friend ClientHVHH As String
    Friend SupporterID As Byte

    Friend IsLocalSell As Boolean
    Dim EquipmentID As Short = -1
    Friend sellID As Int32 = 0
    Dim oldPrice As Decimal = 0
    Dim iCount, iPrice, iTotal
    Dim ShtrikhArray As New List(Of String)

    Dim IsDocumentPrinted As Boolean = False

    Dim BankName As String = String.Empty
    Dim BankAcount As String = String.Empty

    Friend SellPropID As Integer

    Private Sub SendInvoiceMessage()
        On Error Resume Next
        Dim b As Image
        b = My.Resources.infoWarning.ToBitmap

        iDB.AddPublicMessage(b, iUser.UserID, txtSupporterCompany.Text & " կազմակերպությունը գեներացրել է ներքին ինվոյս " & txtClientCompany.Text & " համար", False, 10)
        iDB.AddPublicMessage(b, iUser.UserID, txtSupporterCompany.Text & " կազմակերպությունը գեներացրել է ներքին ինվոյս " & txtClientCompany.Text & " համար", False, 12)

    End Sub
    Private Sub SendInvoiceMessage2()
        On Error Resume Next
        Dim b As Image
        b = My.Resources.infoWarning.ToBitmap

        iDB.AddPublicMessage(b, iUser.UserID, txtSupporterCompany.Text & " կազմակերպությունը գեներացրել է ինվոյս " & txtClientCompany.Text & " համար, ՀՎՀՀ՝ " & txtClientHVHH.Text, False, 10)
        iDB.AddPublicMessage(b, iUser.UserID, txtSupporterCompany.Text & " կազմակերպությունը գեներացրել է ինվոյս " & txtClientCompany.Text & " համար, ՀՎՀՀ՝ " & txtClientHVHH.Text, False, 12)

    End Sub
    Private Function GetLocalCompany(ByVal sID As Byte) As DataTable
        Dim dt As DataTable = Nothing
        Try
            dt = iDB.GetLocalCompany(sID)
            Return dt
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Function
    Private Function GetClientInfo(ByVal hvhh As String) As DataTable
        Dim dt As DataTable = Nothing
        Try
            dt = iDB.GetClientInfoForSell(hvhh)
            Return dt
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Function
    Private Sub LoadBank()
        On Error Resume Next
        Dim dt As DataTable = iDB.GerBankInfo(SupporterID)

        If dt.Rows.Count > 0 Then
            BankName = dt.Rows(0)("Bank")
            BankAcount = dt.Rows(0)("BankAccount")
        End If
    End Sub

    Friend Sub LoadDataByClient()
        Try
            Dim dt As DataTable
            If ClientID > 2000000 Then
                dt = iDB.GetCustomSellByClientFiz(sellID)
            Else
                dt = iDB.GetCustomSellByClient(sellID)
            End If

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()
            GridControl1.DataSource = dt
            GridControl1.EndUpdate()

            With GridView1
                .Columns("CustomSellDetailsID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

            iCount = 0
            iPrice = 0
            iTotal = 0

            If GridView1.RowCount > 0 Then

                For i As Integer = 0 To GridView1.RowCount - 1
                    iCount = GridView1.GetRowCellValue(i, "Քանակ")
                    iPrice = GridView1.GetRowCellValue(i, "Գումար")
                    iTotal += iCount * iPrice
                Next

                If GridView1.Columns("Ամսաթիվ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Ամսաթիվ", "Գումար՝ " & iTotal & " ԱԱՀ՝ " & iTotal * 0.2 & " Ընդհանուր՝ " & iTotal * 1.2)
                    GridView1.Columns("Ամսաթիվ").Summary.Add(item)
                End If
            End If

            ShtrikhArray.Clear()
            ShtrikhArray.AddRange((From row In dt.Rows.Cast(Of DataRow)() Select CStr(row("ՇտրիխԿոդ"))).ToArray())

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub SellWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next

        If GridView1.RowCount > 0 Then
            If IsDocumentPrinted = False Then
                e.Cancel = True
                MsgBox("Փաստաթուղթը չի տպվել", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            End If
        End If

    End Sub
    Private Sub SellWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error Resume Next
        'Me.WindowState = FormWindowState.Maximized

        If IsLocalSell = True Then
            'load Supporter
            Dim dt1 As DataTable = GetLocalCompany(SupporterID)
            If dt1.Rows.Count Then
                txtSupporterCompany.Text = dt1.Rows(0)("Company")
                txtSupporterHVHH.Text = dt1.Rows(0)("HVHH")
                txtSupporterDirector.Text = dt1.Rows(0)("Director")
                txtSupporterAddress.Text = dt1.Rows(0)("Address")
            End If

            'Load Client
            Dim dt2 As DataTable = GetLocalCompany(ClientID)
            If dt2.Rows.Count Then
                txtClientCompany.Text = dt2.Rows(0)("Company")
                txtClientHVHH.Text = dt2.Rows(0)("HVHH")
                txtClientDirector.Text = dt2.Rows(0)("Director")
                txtClientAddress.Text = dt2.Rows(0)("Address")
            End If

            txtPrice.ReadOnly = False

        Else
            'load Supporter
            Dim dt1 As DataTable = GetLocalCompany(SupporterID)
            If dt1.Rows.Count Then
                txtSupporterCompany.Text = dt1.Rows(0)("Company")
                txtSupporterHVHH.Text = dt1.Rows(0)("HVHH")
                txtSupporterDirector.Text = dt1.Rows(0)("Director")
                txtSupporterAddress.Text = dt1.Rows(0)("Address")
            End If

            'ClientHVHH
            Dim dt2 As DataTable = GetClientInfo(ClientHVHH)
            If dt2.Rows.Count Then
                txtClientCompany.Text = dt2.Rows(0)("CompanyName")
                txtClientHVHH.Text = dt2.Rows(0)("HVHH")
                txtClientDirector.Text = dt2.Rows(0)("CompanyDirectorName")
                txtClientAddress.Text = dt2.Rows(0)("AddressName")
                ClientID = dt2.Rows(0)("ClientID")
                txtAraqmanAddress.Text = dt2.Rows(0)("AraqmanAddress")
                txtProblem.Text = dt2.Rows(0)("Problem")
            End If

            txtPrice.ReadOnly = True
        End If

        Call LoadBank()

        txtEquipment.ReadOnly = True
        txtShtrikhCode.Focus()

    End Sub
    Private Sub txtShtrikhCode_TextChanged(sender As Object, e As EventArgs) Handles txtShtrikhCode.TextChanged
        Try
            If GridView1.RowCount >= 10 Then Throw New Exception("Մեկ գործարքի ընթացքում կարող է լինել մաքսիմում 10 գրանցում")

            btnAdd.Enabled = False
            txtEquipment.Text = String.Empty
            txtPrice.Text = 0
            EquipmentID = -1

            If txtShtrikhCode.Text.Trim.Length <> 7 Then Exit Sub

            'Check if equipment can be sold
            iDB.CanSellEquipmentByShtrikhCode(txtShtrikhCode.Text.Trim)

            'Remote Warehouse Check
            If iUser.DB = 1 Then
                iDB.CheckHSMShtrikhWarehouseItem(txtShtrikhCode.Text.Trim)
            Else
                iDB.CheckShtrikhWarehouseItem(txtShtrikhCode.Text.Trim)
            End If

            Dim dt As DataTable

            If IsLocalSell = True Then
                'Ներքին Վաճառք
                dt = iDB.GetSupporterToSupporterInfo(txtShtrikhCode.Text.Trim, SupporterID)

                If dt.Rows.Count = 0 Then Throw New Exception("Պահեստում սարքավորումը չի հայտնաբերվել")
                If dt.Rows.Count > 1 Then Throw New Exception("Պահեստից սխալ քանակի ապրանք է ստացվել")

                txtEquipment.Text = dt.Rows(0)("EquipmentName")
                oldPrice = dt.Rows(0)("Price")
                txtPrice.Text = oldPrice
                EquipmentID = dt.Rows(0)("EquipmentID")

                If EquipmentID = -1 Then Throw New Exception("Սարքավորումը չի ստացվել")

                'OK
                btnAdd.Enabled = True
            Else

                Dim isRemote As Boolean

                If GetIpAddress.StartsWith("192.168.22.") Then
                    isRemote = True
                Else
                    isRemote = False
                End If

                dt = iDB.GetSupporterToClientInfo(txtShtrikhCode.Text.Trim, SupporterID, isRemote, ClientID)

                If dt.Rows.Count = 0 Then Throw New Exception("Պահեստում սարքավորումը չի հայտնաբերվել")
                If dt.Rows.Count > 1 Then Throw New Exception("Պահեստից սխալ քանակի ապրանք է ստացվել")

                txtEquipment.Text = dt.Rows(0)("EquipmentName")
                txtPrice.Text = dt.Rows(0)("Price")
                oldPrice = dt.Rows(0)("Price")
                EquipmentID = dt.Rows(0)("EquipmentID")

                If EquipmentID = -1 Then Throw New Exception("Սարքավորումը չի ստացվել")

                'OK
                btnAdd.Enabled = True
            End If
            'MsgBox(sellID)
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If EquipmentID = -1 Then Throw New Exception("Սարքավորումը որոշված չէ")
            If txtAraqmanAddress.Text.Trim = String.Empty Then Throw New Exception("Առաքման հասցեն գրված չէ")

            Dim dt As DataTable

            'Ինվոյսի Առկայության Ստուգում
            iDB.CheckSellInvoice(sellID)

            If IsLocalSell = True Then
                If txtPrice.Text <= 0 Then Throw New Exception("Գումարը չպետք է 0 կամ բացասական լինի")

                Dim z As Double = 100 * txtPrice.Text / oldPrice
                If z < 80 Then Throw New Exception("Գրված գումարը շեղվել է 20%-ից")

                If txtPrice.Text > oldPrice Then Throw New Exception("Սարքավորումը վաճառվում է ստանդարտ տարիֆից թանկ")

                If SupporterID = 2 Then
                    dt = iDB.CustomSellForSupporterNoNDS(txtShtrikhCode.Text.Trim, SupporterID, sellID, ClientID, EquipmentID, txtPrice.Text)
                Else
                    dt = iDB.CustomSellForSupporter(txtShtrikhCode.Text.Trim, SupporterID, sellID, ClientID, EquipmentID, txtPrice.Text)
                End If

                If sellID = 0 Then sellID = dt.Rows(0)(0)

            Else
                'If txtPrice.Text <= 0 Then Throw New Exception("Գումարը չպետք է 0 կամ բացասական լինի")

                If SupporterID = 2 Then
                    dt = iDB.CustomSellForClientNoNDS(txtShtrikhCode.Text.Trim, SupporterID, sellID, ClientID, EquipmentID, txtPrice.Text)
                Else
                    dt = iDB.CustomSellForClient(txtShtrikhCode.Text.Trim, SupporterID, sellID, ClientID, EquipmentID, txtPrice.Text, txtAraqmanAddress.Text, SellPropID)
                End If

                If sellID = 0 Then sellID = dt.Rows(0)(0)

            End If

            txtShtrikhCode.Text = String.Empty
            txtShtrikhCode.Focus()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Call LoadDataByClient()
        End Try
    End Sub
    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        If GridView1.RowCount = 0 Then Exit Sub
        Try
            'Ինվոյսի Առկայության Ստուգում
            If ClientID > 2000000 Then
                iDB.CheckSellInvoiceFiz(sellID)
            Else
                iDB.CheckSellInvoice(sellID)
            End If


            'If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns(1)) = "PAX S900" OrElse GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns(1)) = "Pax S900" Then
            If iDB.isEquipmentECR(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns(6))) Then
                Dim r As Integer = -1
                Dim f As New ReturnSoldEcr With {.IsLocalSell = IsLocalSell, .SupporterID = SupporterID}

                f.ShtrikhArray.Clear()
                For i As Integer = 0 To ShtrikhArray.Count - 1
                    f.ShtrikhArray.Add(ShtrikhArray.Item(i))
                Next

                If IsLocalSell = True Then
                    f.SuppClient = ClientID
                Else
                    f.ClientID = ClientID
                End If

                f.ShowDialog()
                r = f.SID
                f.Dispose()

                sellID = r

                Call LoadDataByClient()

                If r = -1 Then Me.Close()

            Else

                Dim r As Integer = -1
                Dim f As New ReturnSoldItem With {.IsLocalSell = IsLocalSell, .SupporterID = SupporterID}

                f.ShtrikhArray.Clear()
                For i As Integer = 0 To ShtrikhArray.Count - 1
                    f.ShtrikhArray.Add(ShtrikhArray.Item(i))
                Next

                If IsLocalSell = True Then
                    f.SuppClient = ClientID
                Else
                    f.ClientID = ClientID
                End If

                f.ShowDialog()
                r = f.SID
                f.Dispose()

                sellID = r

                Call LoadDataByClient()

                If r = -1 Then Me.Close()
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If GridView1.RowCount = 0 Then Throw New Exception("Ցանկը դատարկ է")

            iDB.CheckRemakePropIsSold(ClientHVHH)

            Dim rr As New Random
            Dim strRandom = rr.Next(1000000000, Integer.MaxValue)

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\HDM AKT"
            If System.IO.Directory.Exists(strPath) = False Then System.IO.Directory.CreateDirectory(strPath)
            strPath &= "\Temp"
            If System.IO.Directory.Exists(strPath) = False Then System.IO.Directory.CreateDirectory(strPath)
            My.Computer.FileSystem.WriteAllBytes(strPath & "\" & strRandom & ".xlsx", My.Resources.AktInvoiceItemsLast, False)

            Dim iClient = New With {.Կազմակերպություն = txtClientCompany.Text,
                    .Տնօրեն = txtClientDirector.Text,
                    .ՀՎՀՀ = txtClientHVHH.Text}

            Dim iPatkan = New With {.Կազմակերպություն = txtSupporterCompany.Text,
                    .ՀՎՀՀ = txtSupporterHVHH.Text,
                    .Տնօրեն = txtSupporterDirector.Text}

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

                If SupporterID = 2 Then
                    .Range("F16").Value = "Միավորի գին"
                    .Range("F51").Value = "Միավորի գին"
                    .Range("H16").Value = "Գումար"
                    .Range("H51").Value = "Գումար"
                End If

                .Range("A4").Value = "Մի կողմից «" & iClient.Կազմակերպություն & "»-ն, որպես Կողմ-1, ի դեմս " & iClient.Տնօրեն & "-ի և մյուս կողմից " & iPatkan.Կազմակերպություն & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & iPatkan.Տնօրեն & ", ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."
                .Range("A41").Value = "Մի կողմից «" & iClient.Կազմակերպություն & "»-ն, որպես Կողմ-1, ի դեմս " & iClient.Տնօրեն & "-ի և մյուս կողմից " & iPatkan.Կազմակերպություն & "-ն, որպես Կողմ-2, ի դեմս տնօրեն " & iPatkan.Տնօրեն & ", ով գործում է ընկերության կանոնադրության հիման վրա, կազմեցին սույն հանձնման-ընդունման ակտը հետևյալի մասին."

                Dim total As Decimal = 0
                Dim b17 As Integer = 0
                Dim b52 As Integer = 0

                Dim r As Microsoft.Office.Interop.Excel.Range

                For i As Integer = 0 To GridView1.RowCount - 1

                    Dim q_ As Integer = GridView1.GetRowCellValue(i, "Քանակ")
                    Dim s_ As Decimal = If(SupporterID = 2, GridView1.GetRowCellValue(i, "Գումար"), GridView1.GetRowCellValue(i, "Գումար") * 1.2)
                    Dim T_ As Decimal = q_ * s_

                    b17 = i + 17
                    b52 = i + 52

                    r = .Range("B" & b17)
                    r.Value = GridView1.GetRowCellValue(i, "Սարքավորում")

                    r = .Range("B" & b52)
                    r.Value = GridView1.GetRowCellValue(i, "Սարքավորում")

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
                r.Value = BankName

                r = .Range("I66")
                r.Value = BankName

                r = .Range("G32")
                r.Value = "Հ/Հ՝ "

                r = .Range("G67")
                r.Value = "Հ/Հ՝ "

                r = .Range("I32")
                r.Value = BankAcount

                r = .Range("I67")
                r.Value = BankAcount

                r = .Range("C33")
                r.Value = iClient.ՀՎՀՀ

                r = .Range("C68")
                r.Value = iClient.ՀՎՀՀ

                r = .Range("I33")
                r.Value = iPatkan.ՀՎՀՀ

                r = .Range("I68")
                r.Value = iPatkan.ՀՎՀՀ

                r = .Range("A15")
                r.Value = "Լրացում՝ պահեստամասերը և աքսեսուարները նախատեսված են ՀԴՄ-ի համար"
                r = .Range("A50")
                r.Value = "Լրացում՝ պահեստամասերը և աքսեսուարները նախատեսված են ՀԴՄ-ի համար"

            End With

            sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            If IsLocalSell = True Then
                If GridView1.RowCount > 0 Then
                    Call SendInvoiceMessage()
                End If
            End If

            If IsLocalSell = False Then
                If GridView1.RowCount > 0 Then
                    Call SendInvoiceMessage2()
                End If
            End If

            IsDocumentPrinted = True

            If IsLocalSell = False Then
                iDB.SetRemakePropSoldByPropID(SellPropID)
                'iDB.SetRemakePropSold(ClientHVHH)
            End If


            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancelSale_Click(sender As Object, e As EventArgs) Handles btnCancelSale.Click
        iDB.CheckRemakePropIsSold(ClientHVHH)
        iDB.SetRemakePropNotSold(ClientHVHH)
        Me.Close()
    End Sub
End Class