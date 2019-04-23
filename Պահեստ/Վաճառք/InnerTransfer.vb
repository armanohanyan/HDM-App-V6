Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class InnerTransfer

    Dim iShtrikhCode As New List(Of SCode)

    Private Function ExecWork(Shtrikh As String) As Boolean
        Try
            iDB.TransferEquipmentToLocal(Shtrikh, 1)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub LoadData()
        Try
            Dim dt As DataTable = iDB.GetSupporter
            Dim dt2 As DataTable = iDB.GetSupporter

            With cmbWarehousePrimary
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                .SelectedValue = 1
                .Enabled = False
            End With

            With cmbWarehouseSecondary
                .DataSource = dt2
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                .SelectedValue = 1
                .Enabled = False
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub txtShtrikh_TextChanged(sender As Object, e As EventArgs) Handles txtShtrikh.TextChanged
        Try
            If txtShtrikh.Text.Trim.Length <> 7 Then Exit Sub

            If iShtrikhCode.Count = 88 Then MsgBox("Մեկ անգամյա գործարքում չի կարող լինեն 88-ից ավելի սարքավորում", MsgBoxStyle.Information, My.Application.Info.Title) : Exit Sub

            'Check if exists
            If iShtrikhCode.Exists(Function(x) x.Կոդ = txtShtrikh.Text.Trim) Then Throw New Exception("Շտրիխ կոդը կրկնվում է")

            If iDB.CheckShtrikhBeforeTransferTransfered(txtShtrikh.Text.Trim) = True Then Throw New Exception("Սարքավորումն արդեն իսկ տեղափոխվել է")
            If iDB.CheckShtrikhBeforeTransferForSell(txtShtrikh.Text.Trim) = True Then Throw New Exception("Պահեստում նման սարքավորում չկա")

            Dim strEquipment As String = String.Empty
            strEquipment = iDB.GetEquipNameFromShtrikhCode(txtShtrikh.Text.Trim)
            iShtrikhCode.Add(New SCode(txtShtrikh.Text.Trim, strEquipment))

            txtShtrikh.Text = String.Empty
            txtShtrikh.Focus()

            Dim dt As DataTable = ToDataTable(iShtrikhCode)
            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()
            GridControl1.DataSource = dt
            GridControl1.EndUpdate()

            With GridView1
                .ClearSorting()
                .OptionsCustomization.AllowFilter = False
                .OptionsCustomization.AllowSort = False
                .FocusedRowHandle = 0
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub InnerTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadData()
    End Sub
    Private Sub btnPrintDoc_Click(sender As Object, e As EventArgs) Handles btnPrintDoc.Click
        Try
            btnPrintDoc.Enabled = False

            GridView1.ClearColumnsFilter()
            GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Կատարված", True)

            If GridView1.RowCount = 0 Then Throw New Exception("Տպելու համար տվյալ չկա")

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ECR_Inner_Transfer"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\" & Now.Year & Now.Month & Now.Day
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            'Ստանալ ակտի ID
            Dim dtAkt As DataTable = iDB.GetSetInnerAkt(1)
            Dim AktId As String = dtAkt.Rows(0)("Akt")

            Dim rund As New Random
            Dim f As String = strPath & "\InnerTransfer_" & AktId & "_" & rund.Next(0, Integer.MaxValue) & ".xlsx"
            If IO.File.Exists(f) Then Throw New Exception("Նույն անունով ֆայլ է հայտնաբերվել")
            My.Computer.FileSystem.WriteAllBytes(f, My.Resources.InnerTransferDoc, False)

            'Export To Excel
            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(f)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet2"), Microsoft.Office.Interop.Excel.Worksheet)
            'Dont Show Error Messages
            xlApp.DisplayAlerts = False
            With sheet.PageSetup
                .PrintTitleRows = ""
                .PrintTitleColumns = ""

                .PrintArea = ""
                'Set Paper Size To A4
                .PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4

                '.Zoom = 80

                'Change Options
                .CenterHorizontally = True
                .CenterVertically = False
                .ScaleWithDocHeaderFooter = True
                .AlignMarginsHeaderFooter = False

                'Set Margins
                .LeftMargin = xlApp.InchesToPoints(0.28)
                .TopMargin = xlApp.InchesToPoints(0.16)
                .BottomMargin = xlApp.InchesToPoints(0.16)
                .HeaderMargin = xlApp.InchesToPoints(0.16)
                .RightMargin = xlApp.InchesToPoints(0.24)
                .FooterMargin = xlApp.InchesToPoints(0.16)
            End With

            For i As Integer = 0 To GridView1.RowCount - 1
                sheet.Range("B" & i + 13).Value = GridView1.GetRowCellValue(i, "Սարքավորում")
                sheet.Range("F" & i + 13).Value = GridView1.GetRowCellValue(i, "Կոդ")
                sheet.Range("H" & i + 13).Value = 1
            Next

            sheet.Range("F2").Value = AktId
            sheet.Range("H101").Value = GridView1.RowCount

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            Process.Start("Excel.exe", Chr(34) & f & Chr(34))

            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            GridView1.ClearColumnsFilter()
            btnPrintDoc.Enabled = True
            GC.Collect()
        End Try
    End Sub
    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        If GridView1.RowCount = 0 Then MsgBox("Գրանցումներ չկան", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        txtShtrikh.Text = String.Empty
        txtShtrikh.Enabled = False

        btnTransfer.Enabled = False

        Dim b As Boolean
        For i As Integer = 0 To iShtrikhCode.Count - 1
            b = ExecWork(iShtrikhCode.Item(i).Կոդ)
            If b = True Then iShtrikhCode.Item(i).Կատարված = True
        Next

        Dim dt As DataTable = ToDataTable(iShtrikhCode)
        GridControl1.BeginUpdate()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()
        GridControl1.DataSource = dt
        GridControl1.EndUpdate()

        With GridView1
            .ClearSorting()
            .OptionsCustomization.AllowFilter = False
            .OptionsCustomization.AllowSort = False
            .FocusedRowHandle = 0
        End With

        MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        btnPrintDoc.Enabled = True
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

    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
            Dim Code As String = GridView1.GetFocusedDataRow.Item("Կոդ")

            iShtrikhCode.Remove(iShtrikhCode.Where(Function(x) x.Կոդ = Code).FirstOrDefault)

            Dim dt As DataTable = ToDataTable(iShtrikhCode)
            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()
            GridControl1.DataSource = dt
            GridControl1.EndUpdate()

            With GridView1
                .ClearSorting()
                .OptionsCustomization.AllowFilter = False
                .OptionsCustomization.AllowSort = False
                .FocusedRowHandle = 0
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class

Public Class SCode

    Public Sub New(SC, Name)
        _shtrikh = SC
        _isDone = False
        _name = Name
    End Sub
    Private _name As String
    Public Property Սարքավորում As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property
    Private _shtrikh As String
    Public Property Կոդ As String
        Get
            Return _shtrikh
        End Get
        Set(value As String)
            _shtrikh = value
        End Set
    End Property
    Private _isDone As Boolean
    Public Property Կատարված As Boolean
        Get
            Return _isDone
        End Get
        Set(value As Boolean)
            _isDone = value
        End Set
    End Property

End Class