Imports DevExpress.XtraGrid
Imports System.Xml
Imports DevExpress.XtraGrid.Views.Grid

Public Class MakeSellInvoiceXML

    Friend SupporterID As Byte

    Private Sub LoadData()
        Try
            Dim dt As DataTable = iDB.InvSellInvoices(SupporterID)
            GridControl1.BeginUpdate()
            GridControl1.DataSource = dt
            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("InvoiceID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("Պարտք").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .Columns("Ամսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            End With
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
        End Try
    End Sub
    Private Sub createXMLFiles(dirName As String, rID As Integer, dealDate As Date)
        Try
            Dim r As New Random

            Dim dt2 As System.Data.DataTable = iDB.GetSellInvInfo(rID)
            If dt2.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            Dim dt As System.Data.DataTable = iDB.GetSellInvDetails(rID)
            If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            'If dt.Rows.Count = 0 Then Exit While
            Dim xws As XmlWriterSettings = New XmlWriterSettings()

            'Settings
            xws.Indent = True
            xws.NewLineOnAttributes = False
            xws.ConformanceLevel = ConformanceLevel.Auto

            Dim k As String = "Inv_" & dt2.Rows(0)("ՀՎՀՀ") & "_" & Now.Day & "_" & Now.Month & "_" & Now.Year & "_" & r.Next(0, Integer.MaxValue) & ".xml"
            Dim xw As XmlWriter = XmlWriter.Create(dirName & "\" & k, xws)
            xw.WriteStartDocument(False)

            xw.WriteStartElement("ExportedData", "http://www.taxservice.am/tp3/invoice/definitions")
            xw.WriteStartElement("Invoice")
            xw.WriteAttributeString("Version", "1.0")

            xw.WriteElementString("Type", 1)

            'Start GeneralInfo
            xw.WriteStartElement("GeneralInfo")
            xw.WriteElementString("SupplyDate", dealDate.Year & "-" & Microsoft.VisualBasic.Right("00" & dealDate.Month, 2) & "-" & Microsoft.VisualBasic.Right("00" & dealDate.Day, 2))
            xw.WriteElementString("Procedure", 2)
            'Start DealInfo
            xw.WriteStartElement("DealInfo")
            xw.WriteEndElement()
            'End DealInfo
            xw.WriteElementString("AdditionalData", "Փոխանցումով")
            xw.WriteEndElement()
            'End GeneralInfo



            'Start SupplierInfo
            xw.WriteStartElement("SupplierInfo")
            'Start Taxpayer
            xw.WriteElementString("VATNumber", dt2.Rows(0)("ՊատկանՀՎՀՀ") & "/1")
            xw.WriteStartElement("Taxpayer")
            xw.WriteElementString("TIN", dt2.Rows(0)("ՊատկանՀՎՀՀ"))
            xw.WriteElementString("Name", dt2.Rows(0)("ՊատկանԿազմակերպություն"))
            xw.WriteElementString("Address", dt2.Rows(0)("Հասցե"))
            'Start BankAccount
            xw.WriteStartElement("BankAccount")
            xw.WriteElementString("BankName", dt2.Rows(0)("Բանկ"))
            xw.WriteElementString("BankAccountNumber", dt2.Rows(0)("Հաշվեհամար"))
            xw.WriteEndElement()
            'End BankAccount
            xw.WriteElementString("AdditionalData", "Վճարում կատարելիս վճարման հանձնարարագրի նպատակ դաշտում նշել ՀՎՀՀ և կազմակերպության անվանում:")
            xw.WriteEndElement()
            'End Taxpayer
            xw.WriteElementString("SupplyLocation", dt2.Rows(0)("ՊատկանԳործՀասցե"))
            xw.WriteEndElement()
            'End SupplierInfo




            'Start BuyerInfo
            xw.WriteStartElement("BuyerInfo")
            'Start Taxpayer
            xw.WriteStartElement("Taxpayer")
            Dim buyerHVHH As String = dt2.Rows(0)("ՀՎՀՀ")
            If buyerHVHH.Length = 9 AndAlso buyerHVHH.EndsWith("S") Then
                buyerHVHH = buyerHVHH.Substring(0, 8)
            End If
            xw.WriteElementString("TIN", buyerHVHH)
            xw.WriteElementString("Name", dt2.Rows(0)("Կազմակերպություն"))
            xw.WriteElementString("Address", dt2.Rows(0)("ԻրավաբանականՀասցե"))
            'Start BankAccount
            xw.WriteStartElement("BankAccount")
            xw.WriteElementString("BankName", "")
            xw.WriteElementString("BankAccountNumber", "")
            xw.WriteEndElement()
            'End BankAccount
            xw.WriteEndElement()
            'End Taxpayer
            xw.WriteElementString("DeliveryMethod", "")
            Dim araqmanHasce As String = If(IsDBNull(dt2.Rows(0)("ԱռաքմանՀասցե")), "Ինքնատեղափոխում", dt2.Rows(0)("ԱռաքմանՀասցե").ToString)
            'araqmanHasce = IsDBNull((dt2.Rows(0)("ԱռաքմանՀասցե")) ? String.Empty:dt2.Rows(0)("ԱռաքմանՀասցե")))
            xw.WriteElementString("DeliveryLocation", araqmanHasce)
            xw.WriteEndElement()
            'End BuyerInfo




            'Start GoodsInfo
            xw.WriteStartElement("GoodsInfo")

            For i As Integer = 0 To dt.Rows.Count - 1
                'Start Good
                xw.WriteStartElement("Good")
                xw.WriteElementString("Description", dt.Rows(i)("Սարքավորում"))
                xw.WriteElementString("Unit", "Հատ")
                xw.WriteElementString("Amount", dt.Rows(i)("Քանակ"))
                xw.WriteElementString("PricePerUnit", dt.Rows(i)("Միավորի Գին"))
                xw.WriteElementString("Price", dt.Rows(i)("Գին"))
                xw.WriteElementString("VATRate", 20)
                xw.WriteElementString("VAT", dt.Rows(i)("ԱԱՀ"))
                xw.WriteElementString("TotalPrice", dt.Rows(i)("Գումար"))
                xw.WriteEndElement()
                'End Good
            Next

            'Start Total
            xw.WriteStartElement("Total")
            xw.WriteElementString("Price", dt.Compute("SUM(Գին)", ""))
            xw.WriteElementString("VAT", dt.Compute("SUM(ԱԱՀ)", ""))
            xw.WriteElementString("TotalPrice", dt.Compute("SUM(Գումար)", ""))
            xw.WriteEndElement()
            'End Total
            xw.WriteEndElement()
            'End GoodsInfo

            xw.WriteEndElement()    'Close Invoice



            xw.WriteEndElement()    'Close ExportedData

            xw.WriteEndDocument()
            xw.Flush()
            xw.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub createXMLFiles2(dirName As String, rID As Integer, dealDate As Date)
        Try
            Dim r As New Random

            Dim dt2 As System.Data.DataTable = iDB.GetSellInvInfo(rID)
            If dt2.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            Dim dt As System.Data.DataTable = iDB.GetSellInvDetailsNoNDS(rID)
            If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            'If dt.Rows.Count = 0 Then Exit While
            Dim xws As XmlWriterSettings = New XmlWriterSettings()

            'Settings
            xws.Indent = True
            xws.NewLineOnAttributes = False
            xws.ConformanceLevel = ConformanceLevel.Auto

            Dim k As String = "Inv_" & dt2.Rows(0)("ՀՎՀՀ") & "_" & Now.Day & "_" & Now.Month & "_" & Now.Year & "_" & r.Next(0, Integer.MaxValue) & ".xml"
            Dim xw As XmlWriter = XmlWriter.Create(dirName & "\" & k, xws)
            xw.WriteStartDocument(False)

            xw.WriteStartElement("ExportedAccDocData", "http://www.taxservice.am/tp3/invoice/definitions")
            xw.WriteStartElement("AccountingDocument")
            xw.WriteAttributeString("Version", "1.0")

            xw.WriteElementString("Type", 1)

            'Start GeneralInfo
            xw.WriteStartElement("GeneralInfo")
            xw.WriteElementString("DeliveryDate", dealDate.Year & "-" & Microsoft.VisualBasic.Right("00" & dealDate.Month, 2) & "-" & Microsoft.VisualBasic.Right("00" & dealDate.Day, 2))
            'xw.WriteElementString("Procedure", 2)
            'Start DealInfo
            xw.WriteStartElement("DealInfo")
            xw.WriteEndElement()
            'End DealInfo
            xw.WriteElementString("AdditionalData", "Փոխանցումով")
            xw.WriteEndElement()
            'End GeneralInfo



            'Start SupplierInfo
            xw.WriteStartElement("SupplierInfo")
            'Start Taxpayer
            'xw.WriteElementString("VATNumber", dt2.Rows(0)("ՊատկանՀՎՀՀ") & "/1")
            xw.WriteStartElement("Taxpayer")
            xw.WriteElementString("TIN", dt2.Rows(0)("ՊատկանՀՎՀՀ"))
            xw.WriteElementString("Name", dt2.Rows(0)("ՊատկանԿազմակերպություն"))
            xw.WriteElementString("Address", dt2.Rows(0)("Հասցե"))
            'Start BankAccount
            xw.WriteStartElement("BankAccount")
            xw.WriteElementString("BankName", dt2.Rows(0)("Բանկ"))
            xw.WriteElementString("BankAccountNumber", dt2.Rows(0)("Հաշվեհամար"))
            xw.WriteEndElement()
            'End BankAccount
            xw.WriteElementString("AdditionalData", "Վճարում կատարելիս վճարման հանձնարարագրի նպատակ դաշտում նշել ՀՎՀՀ և կազմակերպության անվանում:")
            xw.WriteEndElement()
            'End Taxpayer
            xw.WriteElementString("SupplyLocation", dt2.Rows(0)("ՊատկանԳործՀասցե"))
            xw.WriteEndElement()
            'End SupplierInfo




            'Start BuyerInfo
            xw.WriteStartElement("BuyerInfo")
            'Start Taxpayer
            xw.WriteStartElement("Taxpayer")
            xw.WriteElementString("TIN", dt2.Rows(0)("ՀՎՀՀ"))
            xw.WriteElementString("Name", dt2.Rows(0)("Կազմակերպություն"))
            xw.WriteElementString("Address", dt2.Rows(0)("ԻրավաբանականՀասցե"))
            'Start BankAccount
            xw.WriteStartElement("BankAccount")
            xw.WriteElementString("BankName", "")
            xw.WriteElementString("BankAccountNumber", "")
            xw.WriteEndElement()
            'End BankAccount
            xw.WriteEndElement()
            'End Taxpayer
            xw.WriteElementString("DeliveryMethod", "Ինքնատեղափոխում")
            xw.WriteElementString("DeliveryLocation", "Ինքնատեղափոխում")
            xw.WriteEndElement()
            'End BuyerInfo




            'Start GoodsInfo
            xw.WriteStartElement("GoodsInfo")

            For i As Integer = 0 To dt.Rows.Count - 1
                'Start Good
                xw.WriteStartElement("Good")
                xw.WriteElementString("Description", dt.Rows(i)("Սարքավորում"))
                xw.WriteElementString("Unit", "Հատ")
                xw.WriteElementString("Amount", dt.Rows(i)("Քանակ"))
                xw.WriteElementString("PricePerUnit", dt.Rows(i)("Միավորի Գին"))
                xw.WriteElementString("Price", dt.Rows(i)("Գին"))
                'xw.WriteElementString("VATRate", 20)
                'xw.WriteElementString("VAT", dt.Rows(i)("ԱԱՀ"))
                xw.WriteElementString("TotalPrice", dt.Rows(i)("Գումար"))
                xw.WriteEndElement()
                'End Good
            Next

            'Start Total
            xw.WriteStartElement("Total")
            'xw.WriteElementString("Price", dt.Compute("SUM(Գին)", ""))
            'xw.WriteElementString("VAT", dt.Compute("SUM(ԱԱՀ)", ""))
            xw.WriteElementString("TotalPrice", dt.Compute("SUM(Գումար)", ""))
            xw.WriteEndElement()
            'End Total
            xw.WriteEndElement()
            'End GoodsInfo

            xw.WriteEndElement()    'Close AccountingDocument



            xw.WriteEndElement()    'Close ExportedAccDocData

            xw.WriteEndDocument()
            xw.Flush()
            xw.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub createXMLFilesBulk(ByVal dirName As String, ByVal SellInvoice_list As List(Of SellInvInfo))  'Arman
        Try
            Dim r As New Random
            Dim xws As XmlWriterSettings = New XmlWriterSettings()

            'Settings
            xws.Indent = True
            xws.NewLineOnAttributes = False
            xws.ConformanceLevel = ConformanceLevel.Auto

            Dim k As String = "Inv_" & "Sell_" & Now.Day & "_" & Now.Month & "_" & Now.Year & "_" & r.Next(0, Integer.MaxValue) & ".xml"
            Dim xw As XmlWriter = XmlWriter.Create(dirName & "\" & k, xws)
            xw.WriteStartDocument(False)

            xw.WriteStartElement("ExportedData", "http://www.taxservice.am/tp3/invoice/definitions")



            Dim dt7 As DataTable = ToDataTable(SellInvoice_list)
            Dim rID As Integer
            Dim dealDAte As Date
            For ii As Integer = 0 To dt7.Rows.Count - 1
                rID = dt7.Rows(ii)("ID")
                dealDAte = dt7.Rows(ii)("Dildate")


                Dim dt2 As System.Data.DataTable = iDB.GetSellInvInfo(rID)
                If dt2.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

                Dim dt As System.Data.DataTable = iDB.GetSellInvDetails(rID)
                If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

                xw.WriteStartElement("Invoice")
                xw.WriteAttributeString("Version", "1.0")

                xw.WriteElementString("Type", 1)

                'Start GeneralInfo
                xw.WriteStartElement("GeneralInfo")
                xw.WriteElementString("SupplyDate", dealDAte.Year & "-" & Microsoft.VisualBasic.Right("00" & dealDAte.Month, 2) & "-" & Microsoft.VisualBasic.Right("00" & dealDAte.Day, 2))
                xw.WriteElementString("Procedure", 2)
                'Start DealInfo
                xw.WriteStartElement("DealInfo")
                xw.WriteEndElement()
                'End DealInfo
                xw.WriteElementString("AdditionalData", "Փոխանցումով")
                xw.WriteEndElement()
                'End GeneralInfo



                'Start SupplierInfo
                xw.WriteStartElement("SupplierInfo")
                'Start Taxpayer
                xw.WriteElementString("VATNumber", dt2.Rows(0)("ՊատկանՀՎՀՀ") & "/1")
                xw.WriteStartElement("Taxpayer")
                xw.WriteElementString("TIN", dt2.Rows(0)("ՊատկանՀՎՀՀ"))
                xw.WriteElementString("Name", dt2.Rows(0)("ՊատկանԿազմակերպություն"))
                xw.WriteElementString("Address", dt2.Rows(0)("Հասցե"))
                'Start BankAccount
                xw.WriteStartElement("BankAccount")
                xw.WriteElementString("BankName", dt2.Rows(0)("Բանկ"))
                xw.WriteElementString("BankAccountNumber", dt2.Rows(0)("Հաշվեհամար"))
                xw.WriteEndElement()
                'End BankAccount
                xw.WriteElementString("AdditionalData", "Վճարում կատարելիս վճարման հանձնարարագրի նպատակ դաշտում նշել ՀՎՀՀ և կազմակերպության անվանում:")
                xw.WriteEndElement()
                'End Taxpayer
                xw.WriteElementString("SupplyLocation", dt2.Rows(0)("ՊատկանԳործՀասցե"))
                xw.WriteEndElement()
                'End SupplierInfo




                'Start BuyerInfo
                xw.WriteStartElement("BuyerInfo")
                'Start Taxpayer
                xw.WriteStartElement("Taxpayer")
                Dim buyerHVHH As String = dt2.Rows(0)("ՀՎՀՀ")
                If buyerHVHH.Length = 9 AndAlso buyerHVHH.EndsWith("S") Then
                    buyerHVHH = buyerHVHH.Substring(0, 8)
                End If
                xw.WriteElementString("TIN", buyerHVHH)
                xw.WriteElementString("Name", dt2.Rows(0)("Կազմակերպություն"))
                xw.WriteElementString("Address", dt2.Rows(0)("ԻրավաբանականՀասցե"))
                'Start BankAccount
                xw.WriteStartElement("BankAccount")
                xw.WriteElementString("BankName", "")
                xw.WriteElementString("BankAccountNumber", "")
                xw.WriteEndElement()
                'End BankAccount
                xw.WriteEndElement()
                'End Taxpayer
                xw.WriteElementString("DeliveryMethod", "")
                Dim araqmanHasce As String = If(IsDBNull(dt2.Rows(0)("ԱռաքմանՀասցե")), "Ինքնատեղափոխում", dt2.Rows(0)("ԱռաքմանՀասցե").ToString)
                'araqmanHasce = IsDBNull((dt2.Rows(0)("ԱռաքմանՀասցե")) ? String.Empty:dt2.Rows(0)("ԱռաքմանՀասցե")))
                xw.WriteElementString("DeliveryLocation", araqmanHasce)
                xw.WriteEndElement()
                'End BuyerInfo




                'Start GoodsInfo
                xw.WriteStartElement("GoodsInfo")

                For i As Integer = 0 To dt.Rows.Count - 1
                    'Start Good
                    xw.WriteStartElement("Good")
                    xw.WriteElementString("Description", dt.Rows(i)("Սարքավորում"))
                    xw.WriteElementString("Unit", "Հատ")
                    xw.WriteElementString("Amount", dt.Rows(i)("Քանակ"))
                    xw.WriteElementString("PricePerUnit", dt.Rows(i)("Միավորի Գին"))
                    xw.WriteElementString("Price", dt.Rows(i)("Գին"))
                    xw.WriteElementString("VATRate", 20)
                    xw.WriteElementString("VAT", dt.Rows(i)("ԱԱՀ"))
                    xw.WriteElementString("TotalPrice", dt.Rows(i)("Գումար"))
                    xw.WriteEndElement()
                    'End Good
                Next

                'Start Total
                xw.WriteStartElement("Total")
                xw.WriteElementString("Price", dt.Compute("SUM(Գին)", ""))
                xw.WriteElementString("VAT", dt.Compute("SUM(ԱԱՀ)", ""))
                xw.WriteElementString("TotalPrice", dt.Compute("SUM(Գումար)", ""))
                xw.WriteEndElement()
                'End Total
                xw.WriteEndElement()
                'End GoodsInfo

                xw.WriteEndElement()    'Close Invoice

                iDB.SetInvoicePrinted(rID)

            Next

            xw.WriteEndElement()    'Close ExportedData

            xw.WriteEndDocument()
            xw.Flush()
            xw.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub MakeInnerInvoiceXML_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = Not GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ")
        Next
    End Sub
    Private Sub mnuXML_Click(sender As Object, e As EventArgs) Handles mnuXML.Click
        Try
            If GridView1.RowCount = 0 Then Exit Sub

            Dim sDate As String = Now.Month & "_" & Now.Year

            Dim iPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            iPath &= "\NDS Remont Invoice"
            If IO.Directory.Exists(iPath) = False Then IO.Directory.CreateDirectory(iPath)
            iPath &= "\" & sDate
            If IO.Directory.Exists(iPath) = False Then IO.Directory.CreateDirectory(iPath)

            Dim sellInvoice_list As New List(Of SellInvInfo)    'Arman


            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = False Then Continue For
                'If GridView1.GetRowCellValue(i, "Գումար") = 0 Then Continue For

                Dim rID As Integer = GridView1.GetRowCellValue(i, "InvoiceID")
                Dim dealDate As Date = GridView1.GetRowCellValue(i, "Ամսաթիվ")

                'Create XML File
                If GridView1.GetRowCellValue(i, "Գումար") > 0 Then
                    If SupporterID = 2 Then
                        createXMLFiles2(iPath, rID, dealDate)
                        iDB.SetInvoicePrinted(rID)
                    Else
                        sellInvoice_list.Add(New SellInvInfo(GridView1.GetRowCellValue(i, "InvoiceID"), GridView1.GetRowCellValue(i, "Ամսաթիվ")))   'Arman
                        'createXMLFiles(iPath, rID, dealDate)
                    End If
                End If


                'Update Invoice Set Printed
                'iDB.SetInvoicePrinted(rID)

            Next

            createXMLFilesBulk(iPath, sellInvoice_list) ' Arman

            Call Shell("explorer /select," & iPath, AppWinStyle.NormalFocus)

            MsgBox("Գործողությունը Կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Call LoadData()
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
    Private Sub mnuChangeDate_Click(sender As Object, e As EventArgs) Handles mnuChangeDate.Click
        Try
            If GridView1.RowCount = 0 Then Exit Sub

            If MsgBox("Ցանկանու՞մ եք փոխել մատակարարման ամսաթիվը նշված Հ/Ա-ի համար", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            Dim d As Date
            Dim f As New MatakararDateWindow
            f.ShowDialog()
            d = f.MDate
            f.Dispose()

            If d = Date.MinValue Then
                'Closed
            Else
                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Նշիչ") = True Then
                        Dim rID As Integer = GridView1.GetRowCellValue(i, "InvoiceID")

                        iDB.UpdateInvoiceMDate(rID, d)

                    End If
                Next

                Call LoadData()

                MsgBox("Գործողությունը Կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Call LoadData()
        End Try
    End Sub

    Private Sub mnuSelectAll_Click(sender As Object, e As EventArgs) Handles mnuSelectAll.Click
        On Error Resume Next
        If GridView1.GetDataRow(GridView1.GetSelectedRows()(0)).Item("Նշիչ") = False Then
            For i As Int32 = 0 To GridView1.RowCount - 1
                GridView1.SetRowCellValue(i, "Նշիչ", True)
            Next
        Else
            For i As Int32 = 0 To GridView1.RowCount - 1
                GridView1.SetRowCellValue(i, "Նշիչ", False)
            Next
        End If
    End Sub
End Class

Public Class SellInvInfo

    Private _id As Integer
    Private _dildate As Date

    Public Sub New(id As Integer, dildate As Date)
        _id = id
        _dildate = dildate
    End Sub

    Public Property ID As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Dildate As Date
        Get
            Return _dildate
        End Get
        Set(value As Date)
            _dildate = value
        End Set
    End Property

End Class