Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports Microsoft.Office.Interop
Imports DevExpress.XtraGrid.Views.Grid

Public Class pahanj

    Friend ErrCount As Integer = 0

    Private Sub ExportFiles(SupporterID As Byte, FolderName As String, DaTeX As String, hvhh As String, Company As String, Director As String, ContDate As String, Contract As String, Amount As String)
        Try
            Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Ecr Pahanjagir"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\" & FolderName
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

            f &= "\" & SupporterID
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

            Dim FileName As String = f & "\" & SupporterID & "_" & hvhh & ".docx"

            Select Case SupporterID
                Case 1
                    My.Computer.FileSystem.WriteAllBytes(FileName, My.Resources._1, False)
                Case 2
                    My.Computer.FileSystem.WriteAllBytes(FileName, My.Resources._2, False)
                Case 3
                    My.Computer.FileSystem.WriteAllBytes(FileName, My.Resources._3, False)
                Case 4
                    My.Computer.FileSystem.WriteAllBytes(FileName, My.Resources._4, False)
            End Select

            Dim Worddoc As New Microsoft.Office.Interop.Word.Application
            Dim WDoc As New Microsoft.Office.Interop.Word.Document
            Worddoc.Documents.Open(FileName)
            WDoc = Worddoc.ActiveDocument

            'For protecting error
            Worddoc.ActiveWindow.View.ReadingLayout = False

            Dim rng As Microsoft.Office.Interop.Word.Range = WDoc.Range(Start:=0, End:=0)

            rng.Find.Execute2007(FindText:="$$1", ReplaceWith:=" " & DaTeX & " ", Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)
            rng.Find.Execute2007(FindText:="$$2", ReplaceWith:=" " & Company & " ", Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)
            rng.Find.Execute2007(FindText:="$$3", ReplaceWith:=" " & Director & " ", Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)
            rng.Find.Execute2007(FindText:="$$4", ReplaceWith:=" " & Company & " ", Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)
            rng.Find.Execute2007(FindText:="$$5", ReplaceWith:=" " & ContDate & " ", Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)
            rng.Find.Execute2007(FindText:="$$6", ReplaceWith:=" " & Contract & " ", Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)
            rng.Find.Execute2007(FindText:="$$7", ReplaceWith:=" " & Company & " ", Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)
            rng.Find.Execute2007(FindText:="$$8", ReplaceWith:=" " & Amount & " ", Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)
            rng.Find.Execute2007(FindText:="$$9", ReplaceWith:=" " & Company & " ", Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)
            rng.Find.Execute2007(FindText:="$$10", ReplaceWith:=" " & Amount & " ", Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)
            rng.Find.Execute2007(FindText:="$$11", ReplaceWith:=" " & Company, Replace:=Word.WdReplace.wdReplaceOne, Wrap:=Word.WdFindWrap.wdFindContinue)

            Worddoc.ActiveDocument.Save()
            Worddoc.Quit()
            WDoc = Nothing
            Worddoc = Nothing

        Catch ex As Exception
            ErrCount += 1
        End Try
    End Sub

    Private Function GetData(ByVal hvhh As String) As ExcelResHvhh
        Try
            Dim dt As DataTable = iDB.GetPartqInfoForLaw(hvhh)
            If dt.Rows.Count <> 1 Then Return Nothing

            Dim R As New ExcelResHvhh With {.Կազմակերպություն = dt.Rows(0)("Կազմակերպություն"), .ՊայմԱմս = dt.Rows(0)("ՊայմԱմս"), .Պայմանագիր = dt.Rows(0)("Պայմանագիր"), .Տնօրեն = dt.Rows(0)("Տնօրեն") _
                                           , .Պարտք1 = dt.Rows(0)("Պարտք1"), .Պարտք2 = dt.Rows(0)("Պարտք2"), .Պարտք3 = dt.Rows(0)("Պարտք3"), .Պարտք4 = dt.Rows(0)("Պարտք4")}

            Return R
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub pahanj_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With dePayDay
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With
    End Sub
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim lForm As New Working
        Try
            Dim s As String = String.Empty
            Dim fl As OpenFileDialog = New OpenFileDialog
            With fl
                .Filter = ""
                .Multiselect = False
                .Title = "Նշեք Excel-ի Ֆայլ"
                If .ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
                If String.IsNullOrEmpty(.FileName) Then Exit Sub
                s = .FileName
            End With

            lForm.Show() : My.Application.DoEvents()
            lForm.Width = 500
            lForm.Text = "Excel-ի ֆայլից Տվյալների ստացում"
            lForm.Refresh()

            'Get Data From Excel File
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim ExcelDataSet As System.Data.DataSet
            Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & s & ";Extended Properties=Excel 12.0;")

            ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("SELECT '' AS Ամսաթիվ,hvhh AS ՀՎՀՀ,'' AS Կազմակերպություն,'' AS Տնօրեն,'' AS ՊայմԱմս,'' AS Պայմանագիր,'0' AS Պարտք1,'0' AS Պարտք2,'0' AS Պարտք3,'0' AS Պարտք4 FROM [Sheet1$]", MyConnection)
            ExcelAdapter.TableMappings.Add("Table", "Excel Data")
            ExcelDataSet = New System.Data.DataSet
            ExcelAdapter.Fill(ExcelDataSet)
            MyConnection.Close()

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()
            GridControl1.DataSource = Nothing

            GridControl1.DataSource = ExcelDataSet.Tables(0)

            With GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsCustomization.AllowSort = False

                '.BestFitColumns(True)
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "{0}")
                    GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
                End If
            End If

            btnLoad.Enabled = False
            btnGet.Enabled = True

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            lForm.Close()
        End Try
    End Sub
    Private Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnGet.Click
        Dim lForm As New Working
        Try
            If GridView1.RowCount > 0 Then

                Dim d As Date = dePayDay.DateTime
                dePayDay.Enabled = False

                Dim m As String = String.Empty
                Select Case d.Month
                    Case 1
                        m = "հունվար"
                    Case 2
                        m = "փետրվար"
                    Case 3
                        m = "մարտ"
                    Case 4
                        m = "ապրիլ"
                    Case 5
                        m = "մայիս"
                    Case 6
                        m = "հունիս"
                    Case 7
                        m = "հուլիս"
                    Case 8
                        m = "օգոստոս"
                    Case 9
                        m = "սեպտեմբեր"
                    Case 10
                        m = "հոկտեմբեր"
                    Case 11
                        m = "նոյեմբեր"
                    Case 12
                        m = "դեկտեմբեր"
                End Select

                Dim sDate As String = "«" & d.Day & "» " & m & " " & d.Year & "թ."

                lForm.Show() : My.Application.DoEvents()
                lForm.Width = 500
                lForm.Text = "Բազայից տվյալների ստացում"
                lForm.Refresh()

                Dim iCount As Integer = GridView1.RowCount

                For i As Integer = 0 To GridView1.RowCount - 1

                    GridView1.SetRowCellValue(i, "Ամսաթիվ", sDate)
                    Dim R As ExcelResHvhh = GetData(GridView1.GetRowCellValue(i, "ՀՎՀՀ"))

                    If Not IsNothing(R) Then
                        GridView1.SetRowCellValue(i, "Կազմակերպություն", R.Կազմակերպություն)
                        GridView1.SetRowCellValue(i, "Տնօրեն", R.Տնօրեն)
                        GridView1.SetRowCellValue(i, "ՊայմԱմս", R.ՊայմԱմս)
                        GridView1.SetRowCellValue(i, "Պայմանագիր", R.Պայմանագիր)
                        GridView1.SetRowCellValue(i, "Պարտք1", R.Պարտք1)
                        GridView1.SetRowCellValue(i, "Պարտք2", R.Պարտք2)
                        GridView1.SetRowCellValue(i, "Պարտք3", R.Պարտք3)
                        GridView1.SetRowCellValue(i, "Պարտք4", R.Պարտք4)
                    End If

                    lForm.Text = "Տվյալների ստացում       " & iCount & "  [ " & i & " ]"

                    GridView1.MakeRowVisible(i)
                    My.Application.DoEvents()
                Next

                btnGet.Enabled = False
                btnExport.Enabled = True
            Else
                Throw New Exception("Ցանկը դատարկ է")
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            lForm.Close()
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim lForm As New Working
        Try
            btnExport.Enabled = False

            Dim r As New Random
            Dim val As String = r.Next(0, Integer.MaxValue)

            If GridView1.RowCount > 0 Then

                lForm.Show() : My.Application.DoEvents()
                lForm.Width = 500
                lForm.Text = "Բազայից տվյալների ստացում"
                lForm.Refresh()

                Dim iCount As Integer = GridView1.RowCount

                For i As Integer = 0 To GridView1.RowCount - 1

                    Dim iSum1 As Decimal = GridView1.GetRowCellValue(i, "Պարտք1")
                    Dim iSum2 As Decimal = GridView1.GetRowCellValue(i, "Պարտք2")
                    Dim iSum3 As Decimal = GridView1.GetRowCellValue(i, "Պարտք3")
                    Dim iSum4 As Decimal = GridView1.GetRowCellValue(i, "Պարտք4")

                    If iSum1 > 0 Then
                        ExportFiles(1, val, GridView1.GetRowCellValue(i, "Ամսաթիվ"), GridView1.GetRowCellValue(i, "ՀՎՀՀ"), GridView1.GetRowCellValue(i, "Կազմակերպություն"), GridView1.GetRowCellValue(i, "Տնօրեն"), GridView1.GetRowCellValue(i, "ՊայմԱմս"), GridView1.GetRowCellValue(i, "Պայմանագիր"), iSum1)
                    End If

                    If iSum2 > 0 Then
                        ExportFiles(2, val, GridView1.GetRowCellValue(i, "Ամսաթիվ"), GridView1.GetRowCellValue(i, "ՀՎՀՀ"), GridView1.GetRowCellValue(i, "Կազմակերպություն"), GridView1.GetRowCellValue(i, "Տնօրեն"), GridView1.GetRowCellValue(i, "ՊայմԱմս"), GridView1.GetRowCellValue(i, "Պայմանագիր"), iSum2)
                    End If

                    If iSum3 > 0 Then
                        ExportFiles(3, val, GridView1.GetRowCellValue(i, "Ամսաթիվ"), GridView1.GetRowCellValue(i, "ՀՎՀՀ"), GridView1.GetRowCellValue(i, "Կազմակերպություն"), GridView1.GetRowCellValue(i, "Տնօրեն"), GridView1.GetRowCellValue(i, "ՊայմԱմս"), GridView1.GetRowCellValue(i, "Պայմանագիր"), iSum3)
                    End If

                    If iSum4 > 0 Then
                        ExportFiles(4, val, GridView1.GetRowCellValue(i, "Ամսաթիվ"), GridView1.GetRowCellValue(i, "ՀՎՀՀ"), GridView1.GetRowCellValue(i, "Կազմակերպություն"), GridView1.GetRowCellValue(i, "Տնօրեն"), GridView1.GetRowCellValue(i, "ՊայմԱմս"), GridView1.GetRowCellValue(i, "Պայմանագիր"), iSum4)
                    End If

                    lForm.Text = "Արտահանում       " & iCount & "  [ " & i & " ]      Սխալներ   " & ErrCount

                    My.Application.DoEvents()

                Next

                Dim MpathX As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Ecr Pahanjagir\" & val

                Process.Start("EXPLORER.EXE", "/SELECT," & Chr(34) & MpathX & Chr(34))

                MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Else
                Throw New Exception("Տվյալներ չկան")
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            lForm.Close()
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

Public Class ExcelResHvhh

    Public Property Կազմակերպություն As String
    Public Property Տնօրեն As String
    Public Property ՊայմԱմս As String
    Public Property Պայմանագիր As String
    Public Property Պարտք1 As String
    Public Property Պարտք2 As String
    Public Property Պարտք3 As String
    Public Property Պարտք4 As String

End Class