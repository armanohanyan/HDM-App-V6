Imports System.Drawing.Printing
Imports iTextSharp
Imports System.IO
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Public Class PDF_Searcher

#Region "Local Variables"

    Dim WithEvents _t As New Timer
    Dim sTime As Long
    Dim isWorking As Boolean = False
    Dim iFileCountString As String
    Dim strInfo As String = String.Empty
    Dim bf As New List(Of BusyFiles)
    Dim ehf As New List(Of ExcludeHvhhFiles)

#End Region

#Region "Methods"

    Sub ResetArray()
        bf.Clear()
        ehf.Clear()
    End Sub

    Sub LoadPdfRegions(cb As ComboBox)
        Try
            Dim dt As System.Data.DataTable = iDB.GetRegionForPDF()
            If Not IsNothing(dt) Then
                With cb
                    .DataSource = dt
                    .DisplayMember = "Տարածաշրջան"
                    .ValueMember = "ՀՀ"
                End With
            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub a(sender As System.Object, e As System.EventArgs) Handles _t.Tick
        Dim ltick2 As Long = System.Environment.TickCount
        Dim interval As New TimeSpan((ltick2 - sTime) * 10000)

        txtInfo.Text = "Տևողություն՝ " & interval.ToString("hh\:mm\:ss")
        txtInfo.Refresh()

    End Sub
    Private Sub canceled()
        isWorking = False
        btnCancel.Enabled = False
        btnExecute.Enabled = True
        _t.Enabled = False
    End Sub
    Sub getFilesList(ByVal folder As String, ByVal dg As DataGridView)
        Try
            dg.DataSource = Nothing
            dg.Rows.Clear()
            dg.Columns.Clear()

            Dim iCount As Integer = 0

            Dim d As IO.DirectoryInfo = New IO.DirectoryInfo(folder)

            dg.ColumnCount = 1
            dg.Columns(0).Name = "Ֆայլ"

            Dim fileCount As Int32 = 0

            For Each f In d.GetFiles()
                If isWorking = False Then Exit Sub
                If Not f.FullName.ToString.EndsWith(".pdf") Then Exit For

                Dim row As String() = New String() {f.FullName}
                dg.Rows.Add(row)

                fileCount += 1
                iFileCountString = "Ֆայլերի Քանակ " & fileCount

                My.Application.DoEvents()
            Next

            txtDetails.Text = iFileCountString

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Sub SplitPdf(ByVal dg As DataGridView, ByVal strDestination As String)
        Dim iCount As Integer = dg.RowCount - 1
        For i As Integer = 0 To iCount
            If isWorking = False Then Exit Sub
            'Split
            Using reader As New PdfReader(dg.Rows(i).Cells(0).Value.ToString)
                For j As Integer = 1 To reader.NumberOfPages
                    Dim document As New iTextSharp.text.Document()
                    Dim pdfCopy As New PdfCopy(document, New FileStream(strDestination & "\" & i & "_" & j & ".pdf", FileMode.Create))
                    document.Open()
                    pdfCopy.AddPage(pdfCopy.GetImportedPage(reader, j))
                    document.Close()
                    txtDetails.Text = "Ֆայլերի էջերի մասնատում " & iCount & " | " & i & " / " & j
                    My.Application.DoEvents()
                Next
            End Using
        Next
    End Sub
    Private Function loadExcludeDT(ByVal owner As Byte) As DataTable
        Try
            Dim dt As System.Data.DataTable = iDB.GetExcludeHvhhForPdf(owner)
            Return dt
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Function
    Friend Sub searchRegion(ByVal region As String, FilePath As String, ByVal owner As Byte, ByRef ExcludeDT As DataTable)
        If bf.Exists(Function(X) X.FileName = FilePath) Then Exit Sub
        If ehf.Exists(Function(X) X.FileName = FilePath) Then Exit Sub

        Dim oReader As New iTextSharp.text.pdf.PdfReader(FilePath)
        Dim its As New iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy

        My.Application.DoEvents()

        If iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, 1, its).Contains(region & ",") Then
            If ExcludeDT.Rows.Count > 0 Then
                For x As Int32 = ExcludeDT.Rows.Count - 1 To 0 Step -1
                    If iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, 1, its).Contains(ExcludeDT.Rows(x)("RetExcludeHVHH")) Then
                        ExcludeDT.Rows.RemoveAt(x)
                        ehf.Add(New ExcludeHvhhFiles(FilePath))
                        Exit Sub
                    End If
                Next

                'No Exclude HVHH Found
                bf.Add(New BusyFiles(FilePath, region))
            Else
                bf.Add(New BusyFiles(FilePath, region))
            End If
        End If
    End Sub
    Private Function DublicateMargeByRegion(ByVal region As String, ByVal owner As Byte) As String
        If bf.Count = 0 Then Throw New Exception("Ֆիլտրված ֆայլերի ցանկը դատարկ է")
        Dim RPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & owner & "_" & region & ".pdf"

        Dim fileMarge As New PdfMerge()

        For i As Integer = 0 To bf.Count - 1
            If isWorking = False Then Exit Function

            My.Application.DoEvents()

            If bf.Item(i).Region = region Then
                'Dublicate
                'IO.File.Copy(bf.Item(i).FileName, bf.Item(i).FileName & "_Copy.pdf")

                'Add
                fileMarge.AddDocument(bf.Item(i).FileName)
                fileMarge.AddDocument(bf.Item(i).FileName)
                'fileMarge.AddDocument(bf.Item(i).FileName & "_Copy.pdf")
            End If
        Next

        fileMarge.Merge(RPath)

        Return RPath

    End Function
    Private Function DublicateMargeAll(ByVal owner As Byte) As String
        If bf.Count = 0 Then Throw New Exception("Ֆիլտրված ֆայլերի ցանկը դատարկ է")

        Dim RPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & owner & "_RegionAll.pdf"

        Dim fileMarge As New PdfMerge()

        For j As Integer = 0 To CRegion.Items.Count - 1
            Dim iRegion As String = DirectCast(CRegion.Items(j), DataRowView).Item("Տարածաշրջան")

            For i As Integer = 0 To bf.Count - 1
                If isWorking = False Then Exit Function

                My.Application.DoEvents()

                If bf.Item(i).Region = iRegion Then
                    'Dublicate
                    'IO.File.Copy(bf.Item(i).FileName, bf.Item(i).FileName & "_Copy.pdf")

                    'Add
                    fileMarge.AddDocument(bf.Item(i).FileName)
                    fileMarge.AddDocument(bf.Item(i).FileName)
                    'fileMarge.AddDocument(bf.Item(i).FileName & "_Copy.pdf")
                End If
            Next
        Next

        fileMarge.Merge(RPath)

        Return RPath
    End Function

#End Region

#Region "Enum"

    Enum iCompany
        hdmShtrikh = 1
        tamaElektron = 2
        meriQrist = 3
        toushMaster = 4
    End Enum

#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click
        sTime = System.Environment.TickCount
        _t.Enabled = True
        _t.Start()

        Try
            btnExecute.Enabled = False
            btnCancel.Enabled = True

            RShtrikh.Enabled = False
            RTama.Enabled = False
            RMeryK.Enabled = False
            RToch.Enabled = False
            CRegion.Enabled = False
            CKBXRegion.Enabled = False

            isWorking = True

            Dim company As Byte = 0
            If RShtrikh.Checked Then
                company = iCompany.hdmShtrikh
            ElseIf RTama.Checked Then
                company = iCompany.tamaElektron
            ElseIf RMeryK.Checked Then
                company = iCompany.meriQrist
            ElseIf RToch.Checked Then
                company = iCompany.toushMaster
            End If

            'Folder Open Dialog Box
            Dim strPath As String = String.Empty

            Dim bfd As New FolderBrowserDialog
            With bfd
                .Description = "Նշեք թղթապանակը"
                .ShowNewFolderButton = False
                .ShowDialog()
                strPath = .SelectedPath
            End With

            'Directory not selected
            If String.IsNullOrEmpty(strPath) Then Throw New Exception("Թղթապանակը նշված չէ")

            Dim TMPFolder As String = String.Empty
            Dim rund As New Random

            TMPFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\INVPDF"
            If IO.Directory.Exists(TMPFolder) = False Then IO.Directory.CreateDirectory(TMPFolder)
            TMPFolder &= "\" & company & "_" & Now.Year & Now.Month & Now.Day & "_" & rund.Next(0, Integer.MaxValue)
            If IO.Directory.Exists(TMPFolder) = False Then IO.Directory.CreateDirectory(TMPFolder)

            If isWorking = False Then Exit Sub

            'Get Files
            Call getFilesList(strPath, DataGridView1)

            If DataGridView1.RowCount = 0 Then Throw New Exception("Ֆայլերը չեն բեռնվել")

            If isWorking = False Then Exit Sub

            'Split PDF
            Call SplitPdf(DataGridView1, TMPFolder)

            If isWorking = False Then Exit Sub

            'Load Exclude HVHH
            Dim ExcludeDT As DataTable = loadExcludeDT(company)

            If isWorking = False Then Exit Sub

            'Reset Arrays
            Call ResetArray()

            'Get Temp Files List
            Dim tFiles() As String = IO.Directory.GetFiles(TMPFolder, "*.pdf")

            Dim RPath As String

            'Check regoin
            If CKBXRegion.Checked = True Then
                'All Regions
                For i As Integer = 0 To CRegion.Items.Count - 1
                    Dim iRegion As String = DirectCast(CRegion.Items(i), DataRowView).Item("Տարածաշրջան")
                    For j As Integer = 0 To tFiles.Count - 1
                        If isWorking = False Then Exit Sub

                        Call searchRegion(iRegion, tFiles(j), company, ExcludeDT)

                        strInfo = iFileCountString & vbCrLf & "Տարածաշրջան` " & iRegion & " / " & i & " / " & CRegion.Items.Count - 1 & " | " & j & " / " & tFiles.Count - 1
                        strInfo &= vbCrLf & vbCrLf & "Ֆայլ " & j

                        txtDetails.Text = strInfo
                        txtDetails.Refresh()
                    Next

                    My.Application.DoEvents()
                Next

                'Dublicate AND Marge
                RPath = DublicateMargeAll(company)
            Else
                'Exact Region
                Dim iRegion As String = CRegion.Text

                For j As Integer = 0 To tFiles.Count - 1
                    If isWorking = False Then Exit Sub

                    strInfo = iFileCountString & vbCrLf & "Տարածաշրջան` " & iRegion & " / " & j & " / " & tFiles.Count - 1
                    strInfo &= vbCrLf & vbCrLf & "Ֆայլ " & j

                    txtDetails.Text = strInfo
                    txtDetails.Refresh()

                    Call searchRegion(iRegion, tFiles(j), company, ExcludeDT)
                    My.Application.DoEvents()
                Next

                'Dublicate AND Marge
                RPath = DublicateMargeByRegion(iRegion, company)
            End If

            If Not String.IsNullOrEmpty(RPath) Then Process.Start("explorer.exe", "/select, " & Chr(34) & RPath & Chr(34))

            _t.Enabled = False

            'Delete temp folder
            'If IO.Directory.Exists(TMPFolder) = True Then IO.Directory.Delete(TMPFolder, True)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        Finally

            isWorking = False
            btnCancel.Enabled = False
            btnExecute.Enabled = True

            _t.Enabled = False

            'Dim ltick2 As Long = System.Environment.TickCount
            'Dim interval As New TimeSpan((ltick2 - sTime) * 10000)
            'txtInfo.Text = "Տևողություն՝ " & interval.ToString("hh\:mm\:ss")

            RShtrikh.Enabled = True
            RTama.Enabled = True
            RMeryK.Enabled = True
            RToch.Enabled = True
            CRegion.Enabled = True
            CKBXRegion.Enabled = True

            GC.Collect()
        End Try
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Call canceled()
    End Sub
    Private Sub PDF_Searcher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If isWorking = True Then e.Cancel = True : MsgBox("Ծրագիրը աշխատում է և չի կարող փակվել: Դադարեցրեք աշխատանքը, ապա նոր փակեք այն:", MsgBoxStyle.Exclamation, My.Application.Info.Title)
    End Sub
    Private Sub PDF_Searcher_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        Call LoadPdfRegions(CRegion)
    End Sub

End Class

Public Class BusyFiles

    Public Sub New(f As String, r As String)
        _f = f
        _r = r
    End Sub

    Private _f As String
    Public Property FileName As String
        Get
            Return _f
        End Get
        Set(value As String)
            _f = value
        End Set
    End Property
    Private _r As String
    Public Property Region As String
        Get
            Return _r
        End Get
        Set(value As String)
            _r = value
        End Set
    End Property

End Class

Public Class ExcludeHvhhFiles

    Public Sub New(f As String)
        _f = f
    End Sub

    Private _f As String
    Public Property FileName As String
        Get
            Return _f
        End Get
        Set(value As String)
            _f = value
        End Set
    End Property

End Class