Module PdfRegionPageFounder

    'Pdf File Page Selecter
    Friend Sub PdfFileSelecter()
        Dim formX As New Working
        Try
            If CheckPermission("C565D69E31B9484F8B5BE430E97FD95E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            Dim f As New OpenFileDialog With {.Filter = "PDF Files|*.pdf", .Multiselect = False, .ShowReadOnly = False, .Title = "Նշեք Ֆայլը"}
            f.ShowDialog()
            Dim fPath As String = f.FileName
            If String.IsNullOrEmpty(fPath) Then Exit Sub
            If IO.File.Exists(fPath) = False Then Exit Sub
            f.Dispose()

            formX.Show() : My.Application.DoEvents()

            Dim dt As System.Data.DataTable = iDB.GetRegionForPDF()
            Dim RP As New List(Of RegionPage)
            Dim oReader As New iTextSharp.text.pdf.PdfReader(fPath)

            If dt.Rows.Count = 0 Then Throw New Exception("Տարածաշրջանը չի ստացվել")
            If oReader.NumberOfPages = 0 Then Throw New Exception("PDF ֆայլի էջերի քանակը 0 է ստացվել")

            Dim pCount As Integer = oReader.NumberOfPages

            For i As Integer = 1 To pCount

                Dim its As New iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy

                For j As Integer = 0 To dt.Rows.Count - 1

                    formX.Text = i & " | " & pCount

                    If iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its).Contains(dt.Rows(j)("Տարածաշրջան") & ",") = True Then
                        RP.Add(New RegionPage(dt.Rows(j)("Տարածաշրջան"), i))
                        Exit For
                    End If

                Next
                My.Application.DoEvents()
            Next

            formX.Close()

            Dim CurrentRegion As String = String.Empty
            Dim cStart As Integer = 0
            Dim cFinish As Integer = 0

            Dim lPDF_Pages As New List(Of PDF_Pages)

            For Z As Integer = 0 To RP.Count - 1
                If Z = 0 Then
                    CurrentRegion = RP.Item(Z).Region
                    cStart = RP.Item(Z).Page
                ElseIf Z = RP.Count - 1 Then
                    cFinish = RP.Item(Z).Page
                    lPDF_Pages.Add(New PDF_Pages(CurrentRegion, cStart, cFinish, (cFinish - cStart + 1) / 2))
                Else
                    If CurrentRegion <> RP.Item(Z).Region Then
                        cFinish = RP.Item(Z - 1).Page

                        lPDF_Pages.Add(New PDF_Pages(CurrentRegion, cStart, cFinish, (cFinish - cStart + 1) / 2))

                        CurrentRegion = RP.Item(Z).Region
                        cStart = RP.Item(Z).Page
                    End If
                End If
            Next

            Dim f_P As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\EcrPdf"
            If IO.Directory.Exists(f_P) = False Then IO.Directory.CreateDirectory(f_P)



            Dim r As New Random
            f_P &= "\" & Now.Year & Now.Month & Now.Day & "_" & r.Next(0, Integer.MaxValue) & ".xlsx"
            If IO.File.Exists(f_P) Then IO.File.Delete(f_P)

            My.Computer.FileSystem.WriteAllBytes(f_P, My.Resources.pdfPages, False)

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(f_P)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

            xlApp.DisplayAlerts = False

            For i As Integer = 0 To lPDF_Pages.Count - 1
                sheet.Range("A" & i + 2).Value = lPDF_Pages.Item(i).Region
                sheet.Range("B" & i + 2).Value = lPDF_Pages.Item(i).StartPage
                sheet.Range("C" & i + 2).Value = lPDF_Pages.Item(i).FinishPage
                sheet.Range("D" & i + 2).Value = lPDF_Pages.Item(i).PageCount
            Next

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            Process.Start("Excel.exe", Chr(34) & f_P & Chr(34))

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Dispose()
            GC.Collect()
        End Try
    End Sub

End Module