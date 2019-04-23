Imports DevExpress.XtraGrid
Imports System.Xml
Imports DevExpress.XtraGrid.Views.Grid

Public Class SupportInvoice

    Private iDuration As String = "00:00"

    Private Sub createXMLFilesByRegion(dirName As String, ByVal invoice_list As List(Of InvInfo))
        Try
            Dim r As New Random

            Dim dt_2 As DataTable = ToDataTable(invoice_list)

            Dim dt As System.Data.DataTable = iDB.GetXMLInvoiceList(dt_2)

            If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            Dim j As Integer = 1
            While dt.Rows.Count > 0

                Dim xws As XmlWriterSettings = New XmlWriterSettings()

                'Settings
                xws.Indent = True
                xws.NewLineOnAttributes = False
                xws.ConformanceLevel = ConformanceLevel.Auto

                Dim k As String = j & "______" & "Inv_" & Now.Day & "_" & Now.Month & "_" & Now.Year & "_" & r.Next(0, Integer.MaxValue) & "______" & j & ".xml"
                Dim xw As XmlWriter = XmlWriter.Create(dirName & "\" & k, xws)
                xw.WriteStartDocument(False)

                xw.WriteStartElement("ExportedData", "http://www.taxservice.am/tp3/invoice/definitions")

                For i As Integer = dt.Rows.Count - 1 To dt.Rows.Count - 100 Step -1
                    If dt.Rows.Count = 0 Then Exit For

                    xw.WriteStartElement("Invoice")
                    xw.WriteAttributeString("Version", "1.0")

                    xw.WriteElementString("Type", dt.Rows(i)("Type"))

                    'Start GeneralInfo
                    xw.WriteStartElement("GeneralInfo")
                    xw.WriteElementString("SupplyDate", dt.Rows(i)("GeneralInfoSupplyDate"))
                    xw.WriteElementString("Procedure", 2)
                    'Start DealInfo
                    xw.WriteStartElement("DealInfo")
                    xw.WriteEndElement()
                    'End DealInfo
                    xw.WriteElementString("AdditionalData", dt.Rows(i)("BuyerInfoDeliveryLocation"))
                    xw.WriteEndElement()
                    'End GeneralInfo



                    'Start SupplierInfo
                    xw.WriteStartElement("SupplierInfo")
                    'Start Taxpayer
                    xw.WriteElementString("VATNumber", dt.Rows(i)("SupplierInfoTaxpayerTIN") & "/1")
                    xw.WriteStartElement("Taxpayer")
                    xw.WriteElementString("TIN", dt.Rows(i)("SupplierInfoTaxpayerTIN"))
                    xw.WriteElementString("Name", dt.Rows(i)("SupplierInfoTaxpayerName"))
                    xw.WriteElementString("Address", dt.Rows(i)("SupplierInfoTaxpayerAddress"))
                    'Start BankAccount
                    xw.WriteStartElement("BankAccount")
                    xw.WriteElementString("BankName", dt.Rows(i)("SupplierInfoTaxpayerBankAccountBankName"))
                    xw.WriteElementString("BankAccountNumber", dt.Rows(i)("SupplierInfoTaxpayerBankAccountBankAccountNumber"))
                    xw.WriteEndElement()
                    'End BankAccount
                    xw.WriteElementString("AdditionalData", "Վճարում կատարելիս վճարման հանձնարարագրի նպատակ դաշտում նշել ՀՎՀՀ և կազմակերպության անվանում: Վճարումը կատարել հարկային հաշիվը ստանալուց հետո 5 օրվա ընթացքում։")
                    xw.WriteEndElement()
                    'End Taxpayer
                    xw.WriteEndElement()
                    'End SupplierInfo




                    'Start BuyerInfo
                    xw.WriteStartElement("BuyerInfo")
                    'Start Taxpayer
                    xw.WriteStartElement("Taxpayer")
                    xw.WriteElementString("TIN", dt.Rows(i)("BuyerInfoTaxpayerTIN"))
                    xw.WriteElementString("Name", dt.Rows(i)("BuyerInfoTaxpayerName"))
                    xw.WriteElementString("Address", dt.Rows(i)("BuyerInfoTaxpayerAddress"))
                    'Start BankAccount
                    xw.WriteStartElement("BankAccount")
                    xw.WriteElementString("BankName", dt.Rows(i)("BuyerInfoBankName"))
                    xw.WriteElementString("BankAccountNumber", dt.Rows(i)("BuyerInfoBankAccountNumber"))
                    xw.WriteEndElement()
                    'End BankAccount
                    xw.WriteEndElement()
                    'End Taxpayer
                    'xw.WriteElementString("DeliveryLocation", dt.Rows(i)("BuyerInfoDeliveryLocation"))
                    xw.WriteEndElement()
                    'End BuyerInfo




                    'Start GoodsInfo
                    xw.WriteStartElement("GoodsInfo")

                    'Start Good
                    xw.WriteStartElement("Good")
                    xw.WriteElementString("Description", dt.Rows(i)("GoodsInfoGoodDescription"))
                    xw.WriteElementString("Unit", "Օր")
                    xw.WriteElementString("Amount", dt.Rows(i)("GoodsInfoGoodAmount"))
                    xw.WriteElementString("PricePerUnit", dt.Rows(i)("GoodsInfoGoodPricePerUnit"))
                    xw.WriteElementString("Price", dt.Rows(i)("GoodsInfoGoodPrice"))
                    xw.WriteElementString("VATRate", 20)
                    xw.WriteElementString("VAT", dt.Rows(i)("GoodsInfoGoodVAT"))
                    xw.WriteElementString("TotalPrice", dt.Rows(i)("GoodsInfoGoodTotalPrice"))
                    xw.WriteEndElement()
                    'End Good

                    'Start Total
                    xw.WriteStartElement("Total")
                    xw.WriteElementString("Price", dt.Rows(i)("GoodsInfoTotalPrice"))
                    xw.WriteElementString("VAT", dt.Rows(i)("GoodsInfoTotalVAT"))
                    xw.WriteElementString("TotalPrice", dt.Rows(i)("GoodsInfoTotalTotalPrice"))
                    xw.WriteEndElement()
                    'End Total
                    xw.WriteEndElement()
                    'End GoodsInfo

                    xw.WriteEndElement()    'Close Invoice

                    dt.Rows.RemoveAt(i)

                    My.Application.DoEvents()

                Next

                xw.WriteEndElement()    'Close ExportedData

                xw.WriteEndDocument()
                xw.Flush()
                xw.Close()

                j += 1

                My.Application.DoEvents()
            End While

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub createXMLFilesByRegionNoNDS(dirName As String, ByVal invoice_list As List(Of InvInfo))
        Try
            Dim r As New Random
            Dim dt_2 As DataTable = ToDataTable(invoice_list)
            Dim dt As System.Data.DataTable = iDB.GetXMLInvoiceList(dt_2)

            If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            Dim j As Integer = 1
            While dt.Rows.Count > 0

                Dim xws As XmlWriterSettings = New XmlWriterSettings()

                'Settings
                xws.Indent = True
                xws.NewLineOnAttributes = False
                xws.ConformanceLevel = ConformanceLevel.Auto

                Dim k As String = j & "______" & "Inv_" & Now.Day & "_" & Now.Month & "_" & Now.Year & "_" & r.Next(0, Integer.MaxValue) & "______" & j & ".xml"
                Dim xw As XmlWriter = XmlWriter.Create(dirName & "\" & k, xws)
                xw.WriteStartDocument(False)

                xw.WriteStartElement("ExportedAccDocData", "http://www.taxservice.am/tp3/invoice/definitions")

                For i As Integer = dt.Rows.Count - 1 To dt.Rows.Count - 100 Step -1
                    If dt.Rows.Count = 0 Then Exit For

                    xw.WriteStartElement("AccountingDocument")
                    xw.WriteAttributeString("Version", "1.0")

                    xw.WriteElementString("Type", dt.Rows(i)("Type"))

                    'Start GeneralInfo
                    xw.WriteStartElement("GeneralInfo")
                    xw.WriteElementString("DeliveryDate", dt.Rows(i)("GeneralInfoSupplyDate"))
                    'xw.WriteElementString("Procedure", 2)
                    'Start DealInfo
                    xw.WriteStartElement("DealInfo")
                    xw.WriteEndElement()
                    'End DealInfo
                    xw.WriteElementString("AdditionalData", dt.Rows(i)("BuyerInfoDeliveryLocation"))
                    xw.WriteEndElement()
                    'End GeneralInfo



                    'Start SupplierInfo
                    xw.WriteStartElement("SupplierInfo")
                    'Start Taxpayer
                    xw.WriteStartElement("Taxpayer")
                    xw.WriteElementString("TIN", dt.Rows(i)("SupplierInfoTaxpayerTIN"))
                    xw.WriteElementString("Name", dt.Rows(i)("SupplierInfoTaxpayerName"))
                    xw.WriteElementString("Address", dt.Rows(i)("SupplierInfoTaxpayerAddress"))
                    'Start BankAccount
                    xw.WriteStartElement("BankAccount")
                    xw.WriteElementString("BankName", dt.Rows(i)("SupplierInfoTaxpayerBankAccountBankName"))
                    xw.WriteElementString("BankAccountNumber", dt.Rows(i)("SupplierInfoTaxpayerBankAccountBankAccountNumber"))
                    xw.WriteEndElement()
                    'End BankAccount
                    xw.WriteElementString("AdditionalData", "Վճարում կատարելիս վճարման հանձնարարագրի նպատակ դաշտում նշել ՀՎՀՀ և կազմակերպության անվանում: Վճարումը կատարել հարկային հաշիվը ստանալուց հետո 5 օրվա ընթացքում։")
                    xw.WriteEndElement()
                    'End Taxpayer
                    xw.WriteEndElement()
                    'End SupplierInfo




                    'Start BuyerInfo
                    xw.WriteStartElement("BuyerInfo")
                    'Start Taxpayer
                    xw.WriteStartElement("Taxpayer")
                    xw.WriteElementString("TIN", dt.Rows(i)("BuyerInfoTaxpayerTIN"))
                    xw.WriteElementString("Name", dt.Rows(i)("BuyerInfoTaxpayerName"))
                    xw.WriteElementString("Address", dt.Rows(i)("BuyerInfoTaxpayerAddress"))
                    'Start BankAccount
                    xw.WriteStartElement("BankAccount")
                    xw.WriteElementString("BankName", "")
                    xw.WriteElementString("BankAccountNumber", "")
                    xw.WriteEndElement()
                    'End BankAccount
                    xw.WriteEndElement()
                    'End Taxpayer
                    'xw.WriteElementString("DeliveryLocation", dt.Rows(i)("BuyerInfoDeliveryLocation"))
                    xw.WriteEndElement()
                    'End BuyerInfo




                    'Start GoodsInfo
                    xw.WriteStartElement("GoodsInfo")

                    'Start Good
                    xw.WriteStartElement("Good")
                    xw.WriteElementString("Description", dt.Rows(i)("GoodsInfoGoodDescription"))
                    xw.WriteElementString("Unit", "Օր")
                    xw.WriteElementString("Amount", dt.Rows(i)("GoodsInfoGoodAmount"))
                    xw.WriteElementString("PricePerUnit", dt.Rows(i)("GoodsInfoGoodPricePerUnit"))
                    xw.WriteElementString("Price", dt.Rows(i)("GoodsInfoGoodPrice"))
                    'xw.WriteElementString("VATRate", 20)
                    'xw.WriteElementString("VAT", dt.Rows(i)("GoodsInfoGoodVAT"))
                    xw.WriteElementString("TotalPrice", dt.Rows(i)("GoodsInfoGoodTotalPrice"))
                    xw.WriteEndElement()
                    'End Good

                    'Start Total
                    xw.WriteStartElement("Total")
                    'xw.WriteElementString("Price", dt.Rows(i)("GoodsInfoTotalPrice"))
                    'xw.WriteElementString("VAT", dt.Rows(i)("GoodsInfoTotalVAT"))
                    xw.WriteElementString("TotalPrice", dt.Rows(i)("GoodsInfoTotalTotalPrice"))
                    xw.WriteEndElement()
                    'End Total
                    xw.WriteEndElement()
                    'End GoodsInfo

                    xw.WriteEndElement()    'Close AccountingDocument

                    dt.Rows.RemoveAt(i)

                    My.Application.DoEvents()

                Next

                xw.WriteEndElement()    'Close ExportedAccDocData

                xw.WriteEndDocument()
                xw.Flush()
                xw.Close()

                j += 1

                My.Application.DoEvents()
            End While

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Function MakeSupportInvoice(ByVal hvhh As String) As Boolean
        Try
            iDB.CreateCustomInvoice(hvhh, cYear.SelectedItem, cMonth.SelectedItem, cSupporter.SelectedValue, mDate.DateTime, dDate.DateTime, iUser.LoginName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub LoadSupporter()
        Try
            Dim dt As DataTable = iDB.GetWarehouseList2()
            With cSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                .SelectedIndex = 0
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub SupportInvoice_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub SupportInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadSupporter()
        mDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
        dDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)

        cYear.Items.Clear()
        cMonth.Items.Clear()

        For i As Integer = 2014 To 2030
            cYear.Items.Add(i)
        Next
        cYear.SelectedItem = Now.Year

        For i As Integer = 1 To 12
            cMonth.Items.Add(i)
        Next
        cMonth.SelectedItem = Now.Month
    End Sub
    Private Sub btnCheckDays_Click(sender As Object, e As EventArgs) Handles btnCheckDays.Click
        Try
            Dim c As Byte = iDB.GetInvoiceDayByInterval(cYear.SelectedItem, cMonth.SelectedItem)

            If c <> CByte(DateSerial(cYear.SelectedItem, cMonth.SelectedItem + 1, 1 - 1).Day) Then Throw New Exception("ՊՈԱԿ բազան ամբողջական չէ")

            MsgBox("Բազան ամբողջական է", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuExportToExcel_Click(sender As Object, e As EventArgs) Handles mnuExportToExcel.Click
        Try
            ExportTo(ExportType.Excel2013, Me)
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnMakeInvoice_Click(sender As Object, e As EventArgs) Handles btnMakeInvoice.Click
        btnMakeInvoice.Enabled = False
        cSupporter.Enabled = False
        cYear.Enabled = False
        cMonth.Enabled = False
        mDate.Enabled = False
        dDate.Enabled = False

        Dim formX As New Working
        With formX
            .Width = 500
            .Show()
            .Text = "ՀՎՀՀ-ների ցանկի բեռնում"
            .Refresh()
        End With
        My.Application.DoEvents()

        Try
            If CheckPermission2("36D95A68E092478CB17520D04BBB61D0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If CAutomat.Checked = True Then
                Dim dt As DataTable = iDB.SupportInvoiceHvhhList(cYear.SelectedItem, cMonth.SelectedItem, cSupporter.SelectedValue)
                If dt.Rows.Count = 0 Then Throw New Exception("ՀՎՀՀ-ների ցանկը չի ստացվել")

                Dim b As Boolean

                Dim iTotal As Integer = dt.Rows.Count
                Dim iOK As Integer = 0
                Dim iError As Integer = 0

                Dim t1 As Long = System.Environment.TickCount
                For i As Integer = 0 To iTotal - 1
                    b = MakeSupportInvoice(dt.Rows(i)("hvhh"))

                    If b = True Then iOK += 1 Else iError += 1

                    Dim t2 As Long = System.Environment.TickCount
                    Dim sp As TimeSpan = TimeSpan.FromMilliseconds(t2 - t1)
                    With formX
                        .Text = "Ինվոյս՝ c: " & i + 1 & " / t: " & iTotal & " { ok: " & iOK & " / error: " & iError & " }" & " | time: " & Microsoft.VisualBasic.Right("00" & sp.Hours.ToString, 2) & ":" & Microsoft.VisualBasic.Right("00" & sp.Minutes.ToString, 2) & ":" & Microsoft.VisualBasic.Right("00" & sp.Seconds.ToString, 2)
                        .Refresh()
                    End With

                    My.Application.DoEvents()
                Next
            Else
                If txtHVHH.Text.Trim = String.Empty Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")

                If iDB.CheckHvhhForManualInvoice(txtHVHH.Text.Trim, cYear.SelectedItem, cMonth.SelectedItem) = True Then Throw New Exception("ՀՎՀՀ-ն սխալ է ընտրված")

                Dim b As Boolean = MakeSupportInvoice(txtHVHH.Text.Trim)
                If b = False Then Throw New Exception("Գործողության ժամանակ տեղի է ունեցել սխալ, կամ Հ/Ա արդեն իսկ տպված է")
            End If

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX.Dispose()
            btnMakeInvoice.Enabled = True
            cSupporter.Enabled = True
            cYear.Enabled = True
            cMonth.Enabled = True
            mDate.Enabled = True
            dDate.Enabled = True
        End Try
    End Sub
    Private Sub cManual_CheckedChanged(sender As Object, e As EventArgs) Handles cManual.CheckedChanged
        If cManual.Checked = True Then txtHVHH.ReadOnly = False
    End Sub
    Private Sub CAutomat_CheckedChanged(sender As Object, e As EventArgs) Handles CAutomat.CheckedChanged
        If CAutomat.Checked = True Then txtHVHH.ReadOnly = True
    End Sub
    Private Sub btnShowWithNDS_Click(sender As Object, e As EventArgs) Handles btnShowWithNDS.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            If CheckPermission2("DA631988F5E442ACB03E08B3CBF653B5") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            If cNoPrint.Checked = True Then
                dt = iDB.InvoiceXMLReadyListNDS(cYear.SelectedItem, cMonth.SelectedItem, cSupporter.SelectedValue)
            Else
                dt = iDB.InvoiceXMLReadyListNDS2(cYear.SelectedItem, cMonth.SelectedItem, cSupporter.SelectedValue)
            End If

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ՀՀ").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "{0}")
                    GridView1.Columns("Կազմակերպություն").Summary.Add(item)
                End If

            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub btnShowNoNDS_Click(sender As Object, e As EventArgs) Handles btnShowNoNDS.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            If CheckPermission2("1455B846CACC45FBB0B3FD95A798C086") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            If cNoPrint.Checked = True Then
                dt = iDB.InvoiceXMLReadyListNDS3(cYear.SelectedItem, cMonth.SelectedItem, cSupporter.SelectedValue)
            Else
                dt = iDB.InvoiceXMLReadyListNDS4(cYear.SelectedItem, cMonth.SelectedItem, cSupporter.SelectedValue)
            End If

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ՀՀ").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "{0}")
                    GridView1.Columns("Կազմակերպություն").Summary.Add(item)
                End If

            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = Not GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ")
        Next
    End Sub
    Private Sub mnuSelect_Click(sender As Object, e As EventArgs) Handles mnuSelect.Click
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuDeselect_Click(sender As Object, e As EventArgs) Handles mnuDeselect.Click
        On Error Resume Next
        GridView1.ClearColumnsFilter()
        If GridView1.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.GetRow(i).Item("Նշիչ") = False
        Next
    End Sub
    Private Sub mnuXML_Click(sender As Object, e As EventArgs) Handles mnuXML.Click
        Try
            If CheckPermission2("79809465E5B84A0C82714D80FEB3FADF") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If cSupporter.SelectedValue = 2 Then Throw New Exception("Գործողությունը չի կարող կատարվել 'Տամայի' համար")

            Dim invoice_list As New List(Of InvInfo)
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True AndAlso GridView1.GetRowCellValue(i, "NDS") = True Then
                    invoice_list.Add(New InvInfo(GridView1.GetRowCellValue(i, "ՀՀ"), GridView1.GetRowCellValue(i, "Տարի"), GridView1.GetRowCellValue(i, "Ամիս")))
                End If
            Next

            If invoice_list.Count = 0 Then Throw New Exception("Նշված գրանցում չկա")

            Dim sDate As String = cMonth.SelectedItem & "_" & cYear.SelectedItem

            Dim fName As String = String.Empty
            Select Case cSupporter.SelectedValue
                Case 1
                    fName = "ՀԴՄ Շտրիխ"
                Case 2
                    fName = "Տամա Էլեկտրոն"
                Case 3
                    fName = "Մերի Քրիստ"
                Case 4
                    fName = "Տոչ Մաստեր"
            End Select

            Dim iPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            iPath &= "\NDS Invoice"
            If IO.Directory.Exists(iPath) = False Then IO.Directory.CreateDirectory(iPath)
            iPath &= "\" & sDate
            If IO.Directory.Exists(iPath) = False Then IO.Directory.CreateDirectory(iPath)
            iPath &= "\" & fName
            If IO.Directory.Exists(iPath) = False Then IO.Directory.CreateDirectory(iPath)

            createXMLFilesByRegion(iPath, invoice_list)

            btnShowWithNDS.PerformClick()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Call Shell("explorer /select," & iPath, AppWinStyle.NormalFocus)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuSelectAll_Click(sender As Object, e As EventArgs) Handles mnuSelectAll.Click
        On Error Resume Next
        GridView1.ClearColumnsFilter()
        If GridView1.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.GetRow(i).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuExcel_Click(sender As Object, e As EventArgs) Handles mnuExcel.Click
        Try
            If CheckPermission2("622E4189661C406D8E30FBF863270D52") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim invoice_list As New List(Of InvInfo)
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True AndAlso GridView1.GetRowCellValue(i, "NDS") = False Then
                    invoice_list.Add(New InvInfo(GridView1.GetRowCellValue(i, "ՀՀ"), GridView1.GetRowCellValue(i, "Տարի"), GridView1.GetRowCellValue(i, "Ամիս")))
                End If
            Next

            If invoice_list.Count = 0 Then Throw New Exception("Նշված գրանցում չկա")

            Dim Y As Integer = cYear.SelectedItem
            Dim M As Integer = cMonth.SelectedItem

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Invoise"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\" & M & "." & Y & "\No NDS"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            'Dim d1 As DateTime = DateSerial(Y, M, 1)
            'Dim d2 As DateTime = DateSerial(Y, M + 1, 1 - 1)
            'Dim dateLimit As Date = DateSerial(Y, M + 1, 1 - 1)

            Dim hdmtype As String = "MF2351"

            'Get Info
            Dim dt_2 As DataTable = ToDataTable(invoice_list)
            Dim globDatatable As DataTable = iDB.GetExcelInvoiceList(dt_2)

            If globDatatable Is Nothing OrElse globDatatable.Rows.Count = 0 Then Throw New Exception("Տվյալները չեն ստացվել կամ տվյալ չկա")

            'Loop
            For i As Integer = 0 To globDatatable.Rows.Count - 1
                Dim c = New With {.վճարող = globDatatable.Rows(i)("ՀաճախորդԿազմակերպություն"), .հասցե = globDatatable.Rows(i)("ԻրավաբանականՀասցե"), .հվհհ = globDatatable.Rows(i)("ՀաճախորդիՀՎՀՀ")}

                'Առաքման Հասցե
                Dim Araqman_Hasce As String = "Լրացում՝  վճարումը կատարել 5 բանկային օրվա ընթացքում, "
                If IsDBNull(globDatatable.Rows(i)("ԱռաքմանՀասցե")) Then
                    Araqman_Hasce &= " -"
                Else
                    If globDatatable.Rows(i)("ԱռաքմանՀասցե") = "" OrElse String.IsNullOrEmpty(globDatatable.Rows(i)("ԱռաքմանՀասցե")) Then
                        Araqman_Hasce &= " -"
                    Else
                        Araqman_Hasce &= ", " & globDatatable.Rows(i)("ԱռաքմանՀասցե")
                    End If
                End If

                Dim sTel As String = " h՝ " & globDatatable.Rows(i)("Հեռ")
                Araqman_Hasce &= sTel

                'Պատկանելություն
                Dim umne As String = globDatatable.Rows(i)("Հապավում")

                'Ստանալ Invoise ID
                Dim invoiseID As Object = globDatatable.Rows(i)("InvoiceNumber")

                Dim d1 As Date = globDatatable.Rows(i)("sDate")
                Dim d2 As Date = globDatatable.Rows(i)("eDate")

                'Make file
                Dim f As String = strPath
                f = f & "\Rep" & Replace(globDatatable.Rows(i)("ՀաճախորդիՀՎՀՀ"), "/", "") & ".xls"
                IO.File.Delete(f)

                My.Computer.FileSystem.WriteAllBytes(f, My.Resources.report, False)

                ''id-paymanagir
                'Dim _tar As String = String.Empty

                '_tar = globDatatable.Rows(i)("Ինվոյս Հապավում")

                'load Info
                Dim comp = New With {.մատակարար = globDatatable.Rows(i)("ՊատկանԿազմակերպություն"),
                      .հասցե = globDatatable.Rows(i)("Հասցե"),
                      .բանկ = globDatatable.Rows(i)("Բանկ"),
                      .հհ = globDatatable.Rows(i)("Հաշվեհամար"),
                      .հվհհ = globDatatable.Rows(i)("ՊատկանՀՎՀՀ"),
                      .տնօրեն = globDatatable.Rows(i)("Տնօրեն")}

                'Export
                Dim xlApp As New Microsoft.Office.Interop.Excel.Application
                Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(f)
                Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

                sheet.Range("C1").Value = comp.մատակարար
                sheet.Range("C2").Value = comp.հասցե
                sheet.Range("C3").Value = comp.բանկ
                sheet.Range("C4").Value = comp.հհ
                sheet.Range("C5").Value = comp.հվհհ
                sheet.Range("C37").Value = comp.մատակարար
                sheet.Range("C38").Value = comp.հասցե
                sheet.Range("C39").Value = comp.բանկ
                sheet.Range("C40").Value = comp.հհ
                sheet.Range("C41").Value = comp.հվհհ

                sheet.Range("C27").Value = comp.տնօրեն
                sheet.Range("C63").Value = comp.տնօրեն


                sheet.Range("D15").Value = "1 օրվա արժեքը"
                sheet.Range("D51").Value = "1 օրվա արժեքը"
                sheet.Range("E15").Value = "Գործած օրեր"
                sheet.Range("E51").Value = "Գործած օրեր"
                sheet.Range("F15").Value = "ՀԴՄ քանակ"
                sheet.Range("F51").Value = "ՀԴՄ քանակ"

                Dim forDate As Date = globDatatable.Rows(i)("ՄատակարարմանԱմսաթիվ")

                sheet.Range("D1").Value = "Հաշիվ Ապրանքագիր N " & invoiseID
                sheet.Range("D3").Value = "Մատակարարման ամսաթիվ      " & Microsoft.VisualBasic.Right("00" & forDate.Day, 2) & "." & Microsoft.VisualBasic.Right("00" & forDate.Month, 2) & "." & forDate.Year & "թ."
                sheet.Range("D4").Value = "Դուրս գրման ամսաթիվ " & Chr(34) & "____" & Chr(34) & "_____" & Y & "թ."
                sheet.Range("D37").Value = "Հաշիվ Ապրանքագիր N " & invoiseID
                sheet.Range("D39").Value = "Մատակարարման ամսաթիվ      " & Microsoft.VisualBasic.Right("00" & forDate.Day, 2) & "." & Microsoft.VisualBasic.Right("00" & forDate.Month, 2) & "." & forDate.Year & "թ."
                sheet.Range("D40").Value = "Դուրս գրման ամսաթիվ " & Chr(34) & "____" & Chr(34) & "_____" & Y & "թ."

                sheet.Range("B18").Value = "Ընդամենը"
                sheet.Range("B54").Value = "Ընդամենը"

                sheet.Range("D16").Value = globDatatable.Rows(i)("ՄիավորիԳումար")
                sheet.Range("D52").Value = globDatatable.Rows(i)("ՄիավորիԳումար")
                sheet.Range("E16").Value = globDatatable.Rows(i)("Աշխատած Օրերի Քանակ")
                sheet.Range("E52").Value = globDatatable.Rows(i)("Աշխատած Օրերի Քանակ")
                sheet.Range("F16").Value = globDatatable.Rows(i)("ՀԴՄ Քանակ")
                sheet.Range("F52").Value = globDatatable.Rows(i)("ՀԴՄ Քանակ")

                sheet.Range("G16").Value = globDatatable.Rows(i)("Գումար")
                sheet.Range("G52").Value = globDatatable.Rows(i)("Գումար")
                sheet.Range("G18").Value = globDatatable.Rows(i)("Գումար")
                sheet.Range("G54").Value = globDatatable.Rows(i)("Գումար")

                sheet.Range("B16").Value = Format(d1.Day, "00") & "." & Format(d1.Month, "00") & "." & d1.Year & " - " & Format(d2.Day, "00") & "." & Format(d2.Month, "00") & "." & d2.Year & " ամսվա " & Chr(34) & hdmtype & Chr(34) & " ՀԴՄ-ների սպասարկման գումար"
                sheet.Range("B52").Value = Format(d1.Day, "00") & "." & Format(d1.Month, "00") & "." & d1.Year & " - " & Format(d2.Day, "00") & "." & Format(d2.Month, "00") & "." & d2.Year & " ամսվա " & Chr(34) & hdmtype & Chr(34) & " ՀԴՄ-ների սպասարկման գումար"

                sheet.Range("C7").Value = c.վճարող
                sheet.Range("C8").Value = c.հասցե
                sheet.Range("C11").Value = c.հվհհ
                sheet.Range("C43").Value = c.վճարող
                sheet.Range("C44").Value = c.հասցե
                sheet.Range("C47").Value = c.հվհհ

                sheet.Range("C21").Value = Tver(globDatatable.Rows(i)("Գումար"), True)
                sheet.Range("C57").Value = Tver(globDatatable.Rows(i)("Գումար"), True)

                sheet.Range("B13").Value = Araqman_Hasce
                sheet.Range("B49").Value = Araqman_Hasce

                sheet.Range("A14").Value = "Վճարում կատարելիս " & Chr(34) & "Նպատակ" & Chr(34) & "դաշտում նշել կազմ. անվանումը և ՀՎՀՀ-ն,հակառակ դեպքում բանկը վճարը չի ընդունի"
                sheet.Range("A50").Value = "Վճարում կատարելիս " & Chr(34) & "Նպատակ" & Chr(34) & "դաշտում նշել կազմ. անվանումը և ՀՎՀՀ-ն,հակառակ դեպքում բանկը վճարը չի ընդունի"

                If cPrint.Checked = True Then sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

                wbk.Close(SaveChanges:=True)
                xlApp.Quit()
                xlApp = Nothing
            Next

            btnShowNoNDS.PerformClick()

            Call Shell("explorer /select," & strPath, AppWinStyle.NormalFocus)

            MsgBox("Գործողությունը Կատարվեց" & vbCrLf & "Գրանցումների քանակ՝ " & globDatatable.Rows.Count, MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
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
    Private Sub btnChangeNDS_Click(sender As Object, e As EventArgs) Handles btnChangeNDS.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If cSupporter.SelectedValue <> 2 Then Throw New Exception("Գործողությունը կարող է կատարվել միայն 'Տամայի' համար")

            If GridView1.RowCount = 0 Then Throw New Exception("Տվյալներ չկան")

            Dim invoice_list As New List(Of InvInfo)
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True AndAlso GridView1.GetRowCellValue(i, "NDS") = True Then
                    invoice_list.Add(New InvInfo(GridView1.GetRowCellValue(i, "ՀՀ"), GridView1.GetRowCellValue(i, "Տարի"), GridView1.GetRowCellValue(i, "Ամիս")))
                End If
            Next

            If invoice_list.Count = 0 Then Throw New Exception("Նշված գրանցում չկա")

            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True AndAlso GridView1.GetRowCellValue(i, "NDS") = True Then
                    'Update
                    iDB.UpdateNDSToNoNDS(GridView1.GetRowCellValue(i, "ՀՀ"))
                End If
            Next

            btnShowWithNDS.PerformClick()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub cSupporter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cSupporter.SelectedIndexChanged
        On Error Resume Next

        GridControl1.BeginUpdate()
        GridView1.Columns.Clear()

        GridControl1.DataSource = Nothing

        GridView1.ClearSelection()
        GridControl1.EndUpdate()
    End Sub
    Private Sub ԳեներացնելXMLԱռանցԱԱՀովToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ԳեներացնելXMLԱռանցԱԱՀովToolStripMenuItem.Click
        Try
            If CheckPermission2("79809465E5B84A0C82714D80FEB3FADF") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If cSupporter.SelectedValue <> 2 Then Throw New Exception("Գործողությունը կարող է կատարվել միայն 'Տամայի' համար")

            Dim invoice_list As New List(Of InvInfo)
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True AndAlso GridView1.GetRowCellValue(i, "NDS") = False Then
                    invoice_list.Add(New InvInfo(GridView1.GetRowCellValue(i, "ՀՀ"), GridView1.GetRowCellValue(i, "Տարի"), GridView1.GetRowCellValue(i, "Ամիս")))
                End If
            Next

            If invoice_list.Count = 0 Then Throw New Exception("Նշված գրանցում չկա")

            Dim sDate As String = cMonth.SelectedItem & "_" & cYear.SelectedItem

            Dim fName As String = String.Empty
            Select Case cSupporter.SelectedValue
                Case 1
                    fName = "ՀԴՄ Շտրիխ"
                Case 2
                    fName = "Տամա Էլեկտրոն"
                Case 3
                    fName = "Մերի Քրիստ"
                Case 4
                    fName = "Տոչ Մաստեր"
            End Select

            Dim iPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            iPath &= "\No NDS Invoice"
            If IO.Directory.Exists(iPath) = False Then IO.Directory.CreateDirectory(iPath)
            iPath &= "\" & sDate
            If IO.Directory.Exists(iPath) = False Then IO.Directory.CreateDirectory(iPath)
            iPath &= "\" & fName
            If IO.Directory.Exists(iPath) = False Then IO.Directory.CreateDirectory(iPath)

            createXMLFilesByRegionNoNDS(iPath, invoice_list)

            btnShowWithNDS.PerformClick()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Call Shell("explorer /select," & iPath, AppWinStyle.NormalFocus)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnBacvacq_Click(sender As Object, e As EventArgs) Handles btnBacvacq.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        'Dim ssTime As DateTime = "2018-11-01"
        'Dim eeTime As DateTime = "2018-11-30"

        Try
            If CheckPermission2("DA631988F5E442ACB03E08B3CBF653B5") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable
            dt = iDB.InvoiceBacvacqForECR(cYear.SelectedItem, cMonth.SelectedItem, txtHVHH.Text)

            'If cNoPrint.Checked = True Then
            '    dt = iDB.InvoiceXMLReadyListNDS(cYear.SelectedItem, cMonth.SelectedItem, cSupporter.SelectedValue)
            'Else
            '    dt = iDB.InvoiceXMLReadyListNDS2(cYear.SelectedItem, cMonth.SelectedItem, cSupporter.SelectedValue)
            'End If

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                '.Columns("ՀՀ").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "{0}")
                    GridView1.Columns("ՀԴՄ").Summary.Add(item)
                End If
                If GridView1.Columns("Գործած օրեր").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Գործած օրեր", "{0}")
                    GridView1.Columns("Գործած օրեր").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
End Class

Public Class InvInfo

    Private _id As Integer
    Private _y As Short
    Private _m As Byte

    Public Sub New(id As Integer, y As Short, m As Byte)
        _id = id
        _y = y
        _m = m
    End Sub

    Public Property ID As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property
    Public Property Y As Short
        Get
            Return _y
        End Get
        Set(value As Short)
            _y = value
        End Set
    End Property
    Public Property M As Byte
        Get
            Return _m
        End Get
        Set(value As Byte)
            _m = value
        End Set
    End Property

End Class