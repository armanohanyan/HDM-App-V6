Imports DevExpress.XtraGrid

Public Class TarifContractMaker

    Friend Tarif As Decimal
    Friend ContractDate As Date
    Friend DT As DataTable

    Sub LoadData()
        Try
            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = DT

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ClientHVHH").Caption = "Գործընկերոջ ՀՎՀՀ"
                .Columns("ClientCompany").Caption = "Գործընկեր"
                .Columns("ClientDirector").Caption = "Գործընկերոջ Տնօրեն"
                .Columns("ClientAddress").Caption = "Հաճախորդի Իրավաբանական Հասցե"
                .Columns("SupporterHVHH").Caption = "Սպասարկողի ՀՎՀՀ"
                .Columns("SupporterBank").Caption = "Բանկ"
                .Columns("BankAccount").Caption = "Հաշվեհամար"
                .Columns("SupporterCompany").Caption = "Սպասարկող"
                .Columns("SupporterDirector").Caption = "Տնօրեն"
                .Columns("SupporterAddress").Caption = "Հասցե"
                .Columns("Contract").Caption = "Պայմանագիր"
                .Columns("ContractDate").Caption = "Պայմանագրի Ամսաթիվ"

                .Columns("ClientID").Visible = False
                .Columns("SupporterID").Visible = False
                .Columns("TID").Visible = False

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
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ClientHVHH").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ClientHVHH", "{0}")
                    GridView1.Columns("ClientHVHH").Summary.Add(item)
                End If
            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub TarifContractMaker_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        Call LoadData()
    End Sub

    Private Sub ExportForPrint(sPath As String, ClientHVHH As String, ClientCompany As String, ClientDirector As String,
                               ClientAddress As String, SupporterHVHH As String, SupporterBank As String, BankAccount As String, SupporterCompany As String,
                               SupporterDirector As String, SupporterAddress As String, ClientID As Integer, SupporterID As Byte, TID As Integer,
                               Contract As String, DBContractDate As String, Region As String, RegionName As String)
        Try
            Dim r As New Random
            sPath &= "\" & SupporterID
            If IO.Directory.Exists(sPath) = False Then IO.Directory.CreateDirectory(sPath)

            sPath &= "\" & RegionName
            If IO.Directory.Exists(sPath) = False Then IO.Directory.CreateDirectory(sPath)

            Dim sfile As String = sPath & "\" & ClientHVHH & "_" & r.Next(0, Integer.MaxValue) & ".xls"

            If IO.File.Exists(sfile) Then IO.File.Delete(sfile)

            'Save in Info DB
            iDB.AddContractTarifChanged(ClientID, SupporterID, TID, Tarif, ContractDate, iUser.UserID)

            'extract and print
            If Tarif = 0 Then
                My.Computer.FileSystem.WriteAllBytes(sfile, My.Resources.TarifHavelvacZero, False)
            Else
                My.Computer.FileSystem.WriteAllBytes(sfile, My.Resources.TarifHavelvac, False)
            End If

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(sfile)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

            xlApp.DisplayAlerts = False

            If Tarif = 0 Then
                sheet.Range("A2").Value = Replace(sheet.Range("A2").Value, "@@@", Contract)
                sheet.Range("I5").Value = Replace(sheet.Range("I5").Value, "!!!", ContractDate.ToString("dd.MM.yyyy") & ".թ")
                sheet.Range("A7").Value = Replace(sheet.Range("A7").Value, "###", SupporterCompany)
                sheet.Range("A7").Value = Replace(sheet.Range("A7").Value, "$$$", SupporterDirector)
                sheet.Range("A7").Value = Replace(sheet.Range("A7").Value, "%%%", ClientCompany)
                sheet.Range("A7").Value = Replace(sheet.Range("A7").Value, "^^^", ClientDirector)
                sheet.Range("A7").Value = Replace(sheet.Range("A7").Value, "&&&", DBContractDate & "թ․")
                sheet.Range("A7").Value = Replace(sheet.Range("A7").Value, "@@@", Contract)

                sheet.Range("A32").Value = SupporterCompany
                sheet.Range("A33").Value = "Իրավաբանական հասցե` " & SupporterAddress
                sheet.Range("A36").Value = "ՀՎՀՀ՝ " & SupporterHVHH
                sheet.Range("A37").Value = "Հ/Հ՝ " & BankAccount
                sheet.Range("A38").Value = SupporterBank
                sheet.Range("A42").Value = SupporterDirector

                sheet.Range("F32").Value = ClientCompany
                sheet.Range("F33").Value = "Իրավաբանական հասցե` " & ClientAddress
                sheet.Range("F36").Value = "ՀՎՀՀ՝ " & ClientHVHH
                sheet.Range("F42").Value = ClientDirector

                sheet.Range("F35").Value = "Տարածաշրջան՝ " & Region
            Else
                sheet.Range("A2").Value = Replace(sheet.Range("A2").Value, "@@@", Contract)
                sheet.Range("I5").Value = Replace(sheet.Range("I5").Value, "!!!", ContractDate.ToString("dd.MM.yyyy") & ".թ")
                sheet.Range("A9").Value = Replace(sheet.Range("A9").Value, "###", SupporterCompany)
                sheet.Range("A9").Value = Replace(sheet.Range("A9").Value, "$$$", SupporterDirector)
                sheet.Range("A9").Value = Replace(sheet.Range("A9").Value, "%%%", ClientCompany)
                sheet.Range("A9").Value = Replace(sheet.Range("A9").Value, "^^^", ClientDirector)
                sheet.Range("A9").Value = Replace(sheet.Range("A9").Value, "&&&", DBContractDate & "թ․")
                sheet.Range("A9").Value = Replace(sheet.Range("A9").Value, "@@@", Contract)
                sheet.Range("A14").Value = Replace(sheet.Range("A14").Value, "!@#", Tarif)
                sheet.Range("A14").Value = Replace(sheet.Range("A14").Value, "$%^", Tver(CLng(Tarif), False))

                sheet.Range("A23").Value = SupporterCompany
                sheet.Range("A24").Value = "Իրավաբանական հասցե` " & SupporterAddress
                sheet.Range("A27").Value = "ՀՎՀՀ՝ " & SupporterHVHH
                sheet.Range("A28").Value = "Հ/Հ՝ " & BankAccount
                sheet.Range("A29").Value = SupporterBank
                sheet.Range("A34").Value = SupporterDirector

                sheet.Range("F23").Value = ClientCompany
                sheet.Range("F24").Value = "Իրավաբանական հասցե` " & ClientAddress
                sheet.Range("F27").Value = "ՀՎՀՀ՝ " & ClientHVHH
                sheet.Range("F34").Value = ClientDirector

                sheet.Range("F26").Value = "Տարածաշրջան՝ " & Region
            End If

            If cPrint.Checked = True Then
                sheet.PrintOutEx(1, 1, 2, False, strPrinter, False, True, "", False)
            End If

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

        Catch ex As Exception
            GC.Collect()
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim formX As New Working
        cPrint.Enabled = False
        btnExport.Enabled = False
        GridControl1.Enabled = False

        Me.Refresh()

        Try
            If GridView1.SelectedRowsCount = 0 Then Throw New Exception("Նշված գրանցում չկա")

            formX.Show() : Dim selCount As Integer = GridView1.SelectedRowsCount
            My.Application.DoEvents()

            Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ՀԴՄ APP"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\ՏարիֆիՀավելված"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\" & ContractDate.Year & "." & ContractDate.Month & "." & ContractDate.Day & "." & Now.Hour & "." & Now.Minute & "." & Now.Second
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

            For i As Integer = 0 To selCount - 1

                Dim ClientHVHH As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ClientHVHH")
                Dim ClientCompany As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ClientCompany")
                Dim ClientDirector As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ClientDirector")
                Dim ClientAddress As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ClientAddress")
                Dim SupporterHVHH As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("SupporterHVHH")
                Dim SupporterBank As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("SupporterBank")
                Dim BankAccount As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("BankAccount")
                Dim SupporterCompany As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("SupporterCompany")
                Dim SupporterDirector As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("SupporterDirector")
                Dim SupporterAddress As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("SupporterAddress")
                Dim Contract As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Contract")
                Dim DBContractDate As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ContractDate")

                Dim ClientID As Integer = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ClientID")
                Dim SupporterID As Byte = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("SupporterID")
                Dim TID As Integer = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("TID")
                Dim Region As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Region")
                Dim RegionName As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("RegionName")

                Call ExportForPrint(f, ClientHVHH, ClientCompany, ClientDirector, ClientAddress, SupporterHVHH, SupporterBank, BankAccount, SupporterCompany, SupporterDirector,
                                    SupporterAddress, ClientID, SupporterID, TID, Contract, DBContractDate, Region, RegionName)

                formX.Text = selCount & "  ( " & i + 1 & " )"
                My.Application.DoEvents()
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            
            'open folder
            Dim fi As New IO.DirectoryInfo(f)
            Process.Start("EXPLORER.EXE", "/SELECT," & Chr(34) & fi.FullName & Chr(34))

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing

            GridControl1.Enabled = True
            cPrint.Enabled = True
            btnExport.Enabled = True
        End Try
    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New Views.Grid.GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

End Class