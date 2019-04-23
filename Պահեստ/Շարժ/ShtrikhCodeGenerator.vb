Imports DevExpress.BarCodes
Imports System.Drawing.Imaging
Imports Microsoft.Office
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class ShtrikhCodeGenerator

    Private Sub GenShtrikhCode(ByVal dt As DataTable, ByRef frm As Form)

        Dim r As New Random
        Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\HDM Shtrikh Code"
        If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
        f &= "\" & r.Next(111111, 999999)
        If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

        Dim Qt As Integer = 0
        Dim sName As String

        For i As Integer = 0 To dt.Rows.Count - 1
            For j As Integer = dt.Rows(i)("StartCode") To dt.Rows(i)("Quantity") + dt.Rows(i)("StartCode") - 1

                Dim barCode As New BarCode()
                barCode.BarHeight = 15
                barCode.DpiX = 1000
                barCode.DpiY = 1000
                barCode.BackColor = Color.White
                barCode.ForeColor = Color.Black
                Dim fnt As New Font("Arial", 25)
                barCode.CodeTextFont = fnt
                barCode.Symbology = Symbology.Code128
                barCode.AutoSize = True

                sName = dt.Rows(i)("EquipmentCode") & Microsoft.VisualBasic.Right("00000" & j, 5)
                barCode.CodeText = sName

                barCode.Save(f & "\" & sName & ".png", System.Drawing.Imaging.ImageFormat.Png)
                frm.Text = "Կոդի ստեղծում` " & Qt + 1
                Qt += 1

                'barCode.Dispose()
                barCode = Nothing

                Threading.Thread.Sleep(100)
                My.Application.DoEvents()
                GC.Collect()
            Next
        Next

        'CreateWordFile(Qt, f, frm)
        CreateWordFile2Excel(Qt, f, frm)

    End Sub
    Private Sub CreateWordFile(ByVal QT As Integer, ByVal FolderPath As String, ByRef frm As Form)
        Dim objWord As Microsoft.Office.Interop.Word.Application
        Dim objDoc As Microsoft.Office.Interop.Word.Document
        Dim objTable As Microsoft.Office.Interop.Word.Table
        objWord = CreateObject("Word.Application")

        objDoc = objWord.Documents.Add

        'Set Margins
        objDoc.PageSetup.LeftMargin = 54
        objDoc.PageSetup.TopMargin = 35
        objDoc.PageSetup.RightMargin = 51
        objDoc.PageSetup.BottomMargin = 25

        Dim row_Number As Integer
        If QT Mod 11 = 0 Then
            row_Number = QT \ 7
        Else
            row_Number = QT \ 7 + 1
        End If
        Dim col_Number As Integer = 7

        Dim fList() As String = IO.Directory.GetFiles(FolderPath)

        Dim i As Integer = 0

        objTable = objDoc.Tables.Add(objDoc.Bookmarks.Item("\endofdoc").Range, row_Number, col_Number)
        'objTable.Range.ParagraphFormat.SpaceAfter = 1

        Dim r As Integer, c As Integer
        For r = 1 To row_Number
            objTable.Rows(r).Height = 35
            For c = 1 To col_Number
                objTable.Columns(c).Width = 60

                If i < fList.Length Then
                    objTable.Cell(r, c).Range.InlineShapes.AddPicture(fList(i), LinkToFile:=False, SaveWithDocument:=True)
                    objTable.Cell(r, c).Range.InlineShapes.Item(1).ScaleHeight = 16
                    objTable.Cell(r, c).Range.InlineShapes.Item(1).ScaleWidth = 20
                    frm.Text = "Նկարի տեղադրում` " & i
                End If

                i += 1
            Next
        Next

        objWord.Visible = True

        Dim r_n As New Random
        Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\HDM Ready Shtrikh Code"
        If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
        f &= "\" & r_n.Next(111111, 999999) & ".docx"
        If IO.File.Exists(f) = True Then IO.File.Delete(f)

        'Save Word File
        objDoc.SaveAs2(f) ', FileFormat:=Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument)
    End Sub
    Private Sub CreateWordFile2Excel(ByVal QT As Integer, ByVal FolderPath As String, ByRef frm As Form)
        Dim r_n As New Random
        Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\HDM Ready Shtrikh Code"
        If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
        f &= "\" & r_n.Next(111111, 999999) & ".xlsx"
        If IO.File.Exists(f) = True Then IO.File.Delete(f)

        My.Computer.FileSystem.WriteAllBytes(f, My.Resources.Shtrikh_Code_Prit_form, False)

        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(f)
        xlApp.DisplayAlerts = False
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

        Dim row_Number As Integer
        If QT Mod 7 = 0 Then
            row_Number = QT \ 7
        Else
            row_Number = QT \ 7 + 1
        End If
        Dim col_Number As Integer = 7

        Dim fList() As String = IO.Directory.GetFiles(FolderPath)

        Dim i As Integer = 0
        Dim r As Integer, c As Integer

        Dim L As String = String.Empty
        Dim cLeft As Integer = 0
        Dim cTop As Integer = 27

        For r = 1 To row_Number
            For c = 1 To col_Number
                If i < fList.Length Then

                    Select Case c
                        Case 1
                            L = "B"
                            cLeft = 15
                        Case 2
                            L = "D"
                            cLeft = 88
                        Case 3
                            L = "F"
                            cLeft = 161
                        Case 4
                            L = "H"
                            cLeft = 236
                        Case 5
                            L = "J"
                            cLeft = 309
                        Case 6
                            L = "L"
                            cLeft = 382
                        Case 7
                            L = "N"
                            cLeft = 455
                    End Select

                    sheet.Shapes.AddPicture(fList(i), Core.MsoTriState.msoCTrue, Core.MsoTriState.msoCTrue, cLeft, cTop, 55, 22)
                    'sheet.Shapes.AddPicture(fList(i), Core.MsoTriState.msoTrue, Core.MsoTriState.msoCTrue, cLeft, cTop, 20, 16)

                    frm.Text = "Նկարի տեղադրում` " & i + 1
                End If

                i += 1
                My.Application.DoEvents()
            Next

            If r > 3 AndAlso r < 10 Then cTop += 30 Else cTop += 29

            System.Threading.Thread.Sleep(100)
        Next

        'sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

        wbk.Close(SaveChanges:=True)
        xlApp.Quit()
        xlApp = Nothing

        'Process.Start("EXPLORER.EXE", "/SELECT," & Chr(34) & f & Chr(34))
        Process.Start(Chr(34) & f & Chr(34))
    End Sub

    Private Sub LoadData()
        Try

            Dim dt As DataTable

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()

            dt = iDB.GetEquipmentListWithShtrikhCode
            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ՀՀ").Visible = False
                .Columns("ՀՀ").OptionsColumn.ReadOnly = True
                .Columns("Սարքավորում").OptionsColumn.ReadOnly = True
                .Columns("Կոդ").OptionsColumn.ReadOnly = True
                .Columns("ՎերջինԿոդ").OptionsColumn.ReadOnly = True
                .OptionsCustomization.AllowFilter = False
                .OptionsCustomization.AllowSort = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .Columns("Սարքավորում").BestFit()
            End With

            GridControl1.EndUpdate()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ShtrikhCodeGenerator_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
    End Sub
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim formX As New Working
        formX.Show() : My.Application.DoEvents()
        Try
            If GridView1.RowCount = 0 Then Exit Sub

            GridView1.Columns("Քանակ").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            Dim QTY As Integer = GridView1.Columns("Քանակ").SummaryItem.SummaryValue

            'No Quantity Defined
            If QTY = 0 Then Exit Sub

            Dim SG As New List(Of ShtrikhGen)

            Dim totalCount As Integer = 0

            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Քանակ") <= 0 Then Continue For
                totalCount += GridView1.GetRowCellValue(i, "Քանակ")
                SG.Add(New ShtrikhGen(GridView1.GetRowCellValue(i, "ՀՀ"), GridView1.GetRowCellValue(i, "Քանակ")))
            Next

            If totalCount > 189 Then Throw New Exception("Ընդհանուր քանակը չպետք է մեծ լինի 189-ից")

            If SG.Count > 0 Then
                Dim dt2 As DataTable = ToDataTable(SG)
                Dim dt As DataTable = iDB.CreateShtrikCode(dt2)

                If dt.Rows.Count = 0 Then Throw New Exception("Կոդերը չեն ստացվել")

                GenShtrikhCode(dt, formX)

            Else
                MsgBox("Որևէ գործողություն չի կատարվել", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
            Call LoadData()
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If Not MsgBox("Ցանկանու՞մ եք ջնջել ժամանակավոր ֆայլերը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then Exit Sub
            IO.Directory.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\HDM Shtrikh Code", True)
            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Try
            Process.Start("EXPLORER.EXE", "/SELECT," & Chr(34) & My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\HDM Ready Shtrikh Code" & Chr(34))
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

End Class

Public Class ShtrikhGen

    Public Sub New(EquipmentID As Short, Quantity As Integer)
        _EquipmentID = EquipmentID
        _Quantity = Quantity
    End Sub

    Dim _EquipmentID As Short
    Dim _Quantity As Integer

    Public Property Սարքավորում As Short
        Get
            Return _EquipmentID
        End Get
        Set(value As Short)
            _EquipmentID = value
        End Set
    End Property
    Public Property Քանակ As Integer
        Get
            Return _Quantity
        End Get
        Set(value As Integer)
            _Quantity = value
        End Set
    End Property

End Class