Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class ContractCounterWindow

    Private iDuration As String = "00:00"
    Dim ErrorCount As Integer = 0

    Private Sub ExportForPrint(userHVHH As String, userCompany As String, userContract As String, hdmCount As Integer, OwnerCompany As String, strFolder As String, userChangedCount As Integer, userTesuch As String, ByVal tel As String)
        Try
            Dim r As New Random
            Dim sfile As String = strFolder & userHVHH & "_" & r.Next(0, Integer.MaxValue) & ".xls"

            If IO.File.Exists(sfile) Then IO.File.Delete(sfile)

            'GetAddressDirectorForContractExport
            Dim dt2 As System.Data.DataTable = iDB.GetAddressDirectorForContractExport(userHVHH)
            If IsNothing(dt2) OrElse dt2.Rows.Count = 0 Then Throw New Exception("Error")

            'get owner info
            Dim dt1 As System.Data.DataTable = iDB.GetSupporterContractExport(OwnerCompany)
            If IsNothing(dt1) OrElse dt1.Rows.Count = 0 Then Throw New Exception("Error")

            'Printer
            If String.IsNullOrEmpty(strPrinter) Then
                Dim f As New SelectPrinter
                f.ShowDialog()
                f = Nothing
                If String.IsNullOrEmpty(strPrinter) Then Throw New Exception("Տպիչը նշված չէ")
            End If

            'Save in Info DB
            iDB.ChangeHavelvacCountAfterPrint(userHVHH, userCompany, OwnerCompany, userTesuch, cbYear.SelectedItem, cbMonth.SelectedItem, hdmCount, userChangedCount, iUser.LoginName)

            'extract and print
            My.Computer.FileSystem.WriteAllBytes(sfile, My.Resources.havelvac, False)

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(sfile)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

            xlApp.DisplayAlerts = False

            sheet.Range("A2").Value = Replace(sheet.Range("A2").Value, "@@@", userContract)
            sheet.Range("A9").Value = Replace(sheet.Range("A9").Value, "$$$", userContract)
            sheet.Range("B13").Value = Replace(sheet.Range("B13").Value, "###", hdmCount)
            sheet.Range("I5").Value = dtDate.DateTime & " թ."

            'Owner Info
            sheet.Range("A24").Value = dt1.Rows(0)("Կազմակերպություն")
            sheet.Range("A25").Value = dt1.Rows(0)("Հասցե")
            sheet.Range("A28").Value = "ՀՎՀՀ` " & dt1.Rows(0)("ՀՎՀՀ")
            sheet.Range("A29").Value = "Հ/Հ` " & dt1.Rows(0)("Հաշվեհամար")
            sheet.Range("A30").Value = "Բանկ` " & dt1.Rows(0)("Բանկ")
            sheet.Range("A35").Value = dt1.Rows(0)("Տնօրեն")

            'User Info
            sheet.Range("F24").Value = userCompany
            sheet.Range("F25").Value = dt2.Rows(0)("Հասցե")
            sheet.Range("F28").Value = "ՀՎՀՀ` " & userHVHH
            sheet.Range("F31").Value = "Հեռ՝ " & tel
            sheet.Range("F35").Value = dt2.Rows(0)("Տնօրեն")

            sheet.PrintOutEx(1, 1, 2, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

        Catch ex As Exception
            ErrorCount += 1
        End Try
    End Sub
    Private Sub ContractCounterWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub ContractCounterWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error Resume Next
        With cbYear
            .Items.Clear()
            For i As Integer = 2013 To 2030
                .Items.Add(i)
            Next
            .SelectedItem = Now.Year
        End With

        With cbMonth
            For i As Integer = 1 To 12
                .Items.Add(i)
            Next
            .SelectedItem = Now.Month
        End With

        Dim d As DateTime = DateSerial(cbYear.SelectedItem, cbMonth.SelectedItem + 1, 1 - 1)

        With dtDate
            .DateTime = d
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With

    End Sub
    Private Sub mnuExportToExcel_Click(sender As Object, e As EventArgs) Handles mnuExportToExcel.Click
        Try
            Dim r As New Random
            Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\HDM Exports"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\Export"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

            f &= "\REP" & r.Next(0, Integer.MaxValue) & ".xlsx"
            GridControl1.ExportToXlsx(f)

            Process.Start("EXPLORER.EXE", Chr(34) & f & Chr(34))

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            If CheckPermission2("E1FBBF9C210F4D879A0AB84A34B2938A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            formX.Show() : My.Application.DoEvents()
            Dim dt As DataTable

            sTime = Now
            If ckChanges.Checked Then
                dt = iDB.OnlyContractsChanges(cbYear.SelectedItem, cbMonth.SelectedItem, iUser.DB)
            Else
                dt = iDB.GETContractsX(cbYear.SelectedItem, cbMonth.SelectedItem, iUser.DB)
            End If
            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
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
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "Քանակ {0}")
                    GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
                End If
            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Dim duration As TimeSpan = eTime - sTime
            iDuration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iDuration
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub cbYear_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbYear.SelectedIndexChanged
        If cbYear.Items.Count > 0 AndAlso cbMonth.Items.Count > 0 Then
            Dim d As DateTime = DateSerial(cbYear.SelectedItem, cbMonth.SelectedItem + 1, 1 - 1)
            dtDate.DateTime = d
        End If
    End Sub
    Private Sub cbMonth_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbMonth.SelectedIndexChanged
        If cbYear.Items.Count > 0 AndAlso cbMonth.Items.Count > 0 Then
            Dim d As DateTime = DateSerial(cbYear.SelectedItem, cbMonth.SelectedItem + 1, 1 - 1)
            dtDate.DateTime = d
        End If
    End Sub
    Private Sub btnPrinter_Click(sender As Object, e As EventArgs) Handles btnPrinter.Click
        Dim f As New SelectPrinter
        f.ShowDialog()
        f = Nothing
    End Sub
    Private Sub mnuChangeContract_Click(sender As Object, e As EventArgs) Handles mnuChangeContract.Click
        Dim formX As New Working
        Try
            If CheckPermission2("7A8CFFB6836B426293C5FB2644BC97CF") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.SelectedRowsCount = 0 Then Throw New Exception("Նշված գրանցում չկա")

            ErrorCount = 0

            formX.Show() : Dim selCount As Integer = GridView1.SelectedRowsCount
            My.Application.DoEvents()

            Dim shvhh As String
            Dim scompany As String
            Dim scontract As String
            Dim icount As Integer
            Dim sowner As String
            Dim changecount As Integer
            Dim stesuch As String
            Dim tel As String

            Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ՀԴՄ APP"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\Հավելված"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\" & Now.Day & "." & cbYear.SelectedItem & "." & cbMonth.SelectedItem
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

            For i As Integer = 0 To selCount - 1
                If IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Կազմակերպություն")) Then ErrorCount += 1 : Continue For
                If GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Պատկան").ToString = "" Then ErrorCount += 1 : Continue For

                shvhh = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ՀՎՀՀ")
                scompany = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Կազմակերպություն")
                scontract = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Պայմանագիր")
                icount = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Անհրաժ Պայման")
                sowner = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Պատկան")
                changecount = icount - GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Առկա Պայման")
                tel = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Հեռ")

                If IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Տեսուչ")) Then
                    stesuch = ""
                Else
                    stesuch = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Տեսուչ")
                End If

                If changecount <> 0 Then Call ExportForPrint(shvhh, scompany, scontract, icount, sowner, f & "\", changecount, stesuch, tel)

                formX.Text = selCount & "  ( " & i + 1 & " )"
            Next

            If ErrorCount = 0 Then
                MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Else
                MsgBox("Գործողությունը կատարվել է սխալներով" & vbCrLf & _
                    selCount & " գրանցումներից " & ErrorCount & " -ի համար սխալ է տեղի ունեցել", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            End If

            'open folder
            Dim fi As New IO.DirectoryInfo(f)
            Process.Start("EXPLORER.EXE", "/SELECT," & Chr(34) & fi.FullName & Chr(34))

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub mnuExpireContract_Click(sender As Object, e As EventArgs) Handles mnuExpireContract.Click
        Dim formX As New Working
        Try
            If CheckPermission2("640095A73885452F8CFE18845E185C2A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If GridView1.SelectedRowsCount = 0 Then Throw New Exception("Նշված գրանցում չկա")
            ErrorCount = 0
            formX.Show()

            Dim selCount As Integer = GridView1.SelectedRowsCount
            My.Application.DoEvents()

            Dim shvhh As String = ""
            Dim sowner As String = ""

            Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ՀԴՄ APP"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\ԼուծմանՀավելված"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\" & Now.Day & "." & cbYear.SelectedItem & "." & cbMonth.SelectedItem
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

            For i As Integer = 0 To selCount - 1

                If IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Կազմակերպություն")) Then ErrorCount += 1 : Continue For
                If GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Պատկան") = "" Then ErrorCount += 1 : Continue For

                shvhh = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ՀՎՀՀ")
                sowner = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Պատկան")

                Call _DisableContract(shvhh, sowner, f & "\")

                formX.Text = selCount & "  ( " & i + 1 & " )"
            Next

            If ErrorCount = 0 Then
                MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Else
                MsgBox("Գործողությունը կատարվել է սխալներով" & vbCrLf & _
                selCount & " գրանցումներից " & ErrorCount & " -ի համար սխալ է տեղի ունեցել", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            End If

            'open folder
            Dim fi As New IO.DirectoryInfo(f)
            Process.Start("EXPLORER.EXE", "/SELECT," & Chr(34) & fi.FullName & Chr(34))
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub _DisableContract(userHVHH As String, OwnerCompany As String, strFolder As String)
        Try
            Dim r As New Random
            Dim sfile As String = strFolder & userHVHH & "_" & r.Next(0, Integer.MaxValue) & ".xls"

            If IO.File.Exists(sfile) Then IO.File.Delete(sfile)

            'GetUserInfoForContractExpireing
            Dim dt2 As System.Data.DataTable = iDB.GetUserInfoForContractExpireing(userHVHH)
            If IsNothing(dt2) OrElse dt2.Rows.Count = 0 Then Throw New Exception("Error")

            'GetSupporterInfoForContractExpireing
            Dim dt1 As System.Data.DataTable = iDB.GetSupporterContractExport(OwnerCompany)
            If IsNothing(dt1) OrElse dt1.Rows.Count = 0 Then Throw New Exception("Error")

            'Printer
            If String.IsNullOrEmpty(strPrinter) Then
                Dim f As New SelectPrinter
                f.ShowDialog()
                f = Nothing
                If String.IsNullOrEmpty(strPrinter) Then Throw New Exception("Տպիչը նշված չէ")
            End If

            'Save To DB

            iDB.InsertContractDissolve(userHVHH, OwnerCompany, dtDate.DateTime)

            'extract and print
            My.Computer.FileSystem.WriteAllBytes(sfile, My.Resources.lucum, False)

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(sfile)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

            xlApp.DisplayAlerts = False

            sheet.Range("A2").Value = Replace(sheet.Range("A2").Value, "@@@", dt2.Rows(0)("Պայմանագիր"))
            sheet.Range("A9").Value = Replace(sheet.Range("A9").Value, "@@@", dt2.Rows(0)("Պայմանագիր"))

            'Owner Info
            sheet.Range("A20").Value = dt1.Rows(0)("Կազմակերպություն")
            sheet.Range("A21").Value = "Հասցե` " & dt1.Rows(0)("Հասցե")
            sheet.Range("A25").Value = "ՀՎՀՀ` " & dt1.Rows(0)("ՀՎՀՀ")
            sheet.Range("A27").Value = "Հ/Հ՝ " & dt1.Rows(0)("Հաշվեհամար")
            sheet.Range("A28").Value = "Բանկ` " & dt1.Rows(0)("Բանկ")
            sheet.Range("A32").Value = dt1.Rows(0)("Տնօրեն")

            'User Info
            sheet.Range("F20").Value = dt2.Rows(0)("Անվանում")
            sheet.Range("F21").Value = "Իր. Հասցե` " & dt2.Rows(0)("Իրավաբանական Հասցե")
            sheet.Range("F23").Value = "Առաք. Հասցե`" & dt2.Rows(0)("Առաքման Հասցե")
            sheet.Range("F25").Value = "ՀՎՀՀ` " & userHVHH
            sheet.Range("F26").Value = "Հեռ` " & dt2.Rows(0)("Հեռ")
            sheet.Range("F27").Value = "Հ/Հ՝ "
            sheet.Range("F28").Value = "Բանկ` "
            sheet.Range("F32").Value = dt2.Rows(0)("Տնօրեն")

            sheet.PrintOutEx(1, 1, 2, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing
        Catch ex As Exception
            ErrorCount += 1
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

End Class