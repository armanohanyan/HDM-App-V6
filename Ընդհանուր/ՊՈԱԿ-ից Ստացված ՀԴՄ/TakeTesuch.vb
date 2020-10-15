Imports DevExpress.XtraGrid

Public Class TakeTesuch

    Private Sub LoadTesuch()
        Try
            Dim dtT As System.Data.DataTable = iDB.GetWorkingTesuch2()
            With cTesuch
                .DataSource = dtT
                .DisplayMember = "Name"
                .ValueMember = "ID"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub TakeTesuch_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadTesuch()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            Dim dt As DataTable = iDB.GetEcrPoakToOffice2(cTesuch.SelectedValue)

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            With GridView1
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsSelection.EnableAppearanceFocusedRow = False

                .Columns("ID").Visible = False
                .Columns("TesuchID").Visible = False

                .Columns("Ecr").Caption = "ՀԴՄ"
                .Columns("tesuchName").Caption = "Տեսուչ"
                .Columns("BringDate").Caption = "Ձեռք Բերման Ամսաթիվ"
                .Columns("SendDate").Caption = "Տեսուչին Տրման Ամսաթիվ"
                .Columns("ReceiveDate").Caption = "Ակտի Վերադարձման Ամսաթիվ"

                For i As Integer = 0 To GridView1.Columns.Count - 1
                    .Columns(i).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                Next

            End With

            If GridView1.Columns("Ecr").Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Ecr", "{0}")
                GridView1.Columns("Ecr").Summary.Add(item)
            End If

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If GridView1.RowCount > 0 Then
                cTesuch.Enabled = False

                btnPrint.Enabled = True
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
            If GridView1.SelectedRowsCount = 0 Then Throw New Exception("Նշված տողեր չկան")

            Dim L As New List(Of ecrData)

            For i As Integer = 0 To GridView1.SelectedRowsCount - 1
                If IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("SendDate")) AndAlso IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ReceiveDate")) Then
                    L.Add(New ecrData With {.ID = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("ID"), .Ecr = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Ecr")})
                End If
            Next

            If L.Count = 0 Then Throw New Exception("Նշված տողերը չեն համապատասխանում անհրաժեշտ պայմաններին")
            If L.Count > 10 Then Throw New Exception("Տողերի մաքսիմալ քանակը պետք է 10 լինի")

            Dim tDT As System.Data.DataTable = iDB.EcrTesuchData(cTesuch.SelectedValue)
            If IsNothing(tDT) OrElse tDT.Rows.Count = 0 Then Throw New Exception("Տեսուչի տվյալները չեն ստացվել")

            btnLoad.Enabled = False
            btnPrint.Enabled = False

            'Print Data
            Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ՀԴՄ APP"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\POAKEcrAkt"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\" & Now.Year & "." & Now.Month & "." & Now.Day & "." & Now.Hour & "." & Now.Minute & "." & Now.Second
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

            Dim r As New Random

            Dim sfile As String = f & "\" & cTesuch.Text & "_" & r.Next(0, Integer.MaxValue) & ".xlsx"

            If IO.File.Exists(sfile) Then IO.File.Delete(sfile)

            My.Computer.FileSystem.WriteAllBytes(sfile, My.Resources.PoakEcrAkt, False)

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(sfile)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

            xlApp.DisplayAlerts = False

            sheet.Range("F2").Value = Now.ToString("dd.MM.yyyy")
            sheet.Range("F28").Value = Now.ToString("dd.MM.yyyy")

            sheet.Range("A6").Value = Replace(sheet.Range("A6").Value, "$T", tDT.Rows(0)("Name"))
            sheet.Range("A32").Value = Replace(sheet.Range("A32").Value, "$T", tDT.Rows(0)("Name"))

            sheet.Range("A6").Value = Replace(sheet.Range("A6").Value, "$P", tDT.Rows(0)("S"))
            sheet.Range("A32").Value = Replace(sheet.Range("A32").Value, "$P", tDT.Rows(0)("S"))

            sheet.Range("A6").Value = Replace(sheet.Range("A6").Value, "$F", tDT.Rows(0)("F"))
            sheet.Range("A32").Value = Replace(sheet.Range("A32").Value, "$F", tDT.Rows(0)("F"))

            sheet.Range("A6").Value = Replace(sheet.Range("A6").Value, "$Q", tDT.Rows(0)("W"))
            sheet.Range("A32").Value = Replace(sheet.Range("A32").Value, "$Q", tDT.Rows(0)("W"))

            sheet.Range("F24").Value = tDT.Rows(0)("Name")
            sheet.Range("F50").Value = tDT.Rows(0)("Name")

            For i As Integer = 0 To L.Count - 1
                sheet.Range("B" & 9 + i).Value = "MF2351 մոդելի " & L.Item(i).Ecr & " հսկիչ դրամարկղային մեքենա"
                sheet.Range("B" & 35 + i).Value = "MF2351 մոդելի " & L.Item(i).Ecr & " հսկիչ դրամարկղային մեքենա"
            Next

            sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            'SaveToDB
            For i As Integer = 0 To L.Count - 1
                iDB.UpdateEcrPoakToOffice(L.Item(i).Ecr)
            Next

            'OK
            cTesuch.Enabled = True
            btnLoad.Enabled = True

            'btnLoad.PerformClick()

            Dim fi As New IO.DirectoryInfo(f)
            Process.Start("EXPLORER.EXE", "/SELECT," & Chr(34) & fi.FullName & Chr(34))

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class

Public Class ecrData

    Public Property ID As Short
    Public Property Ecr As String

End Class