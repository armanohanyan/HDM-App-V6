Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class DateSelect

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            dt = iDB.NotPrintedApplications(cYear.SelectedItem, cMonth.SelectedItem)

            Call CloseWindow("nNotPrintedApplicationsForm")
            Dim f As New NotPrintedApplicationsForm
            AddChildForm("nNotPrintedApplicationsForm", f)

            f.GridControl1.BeginUpdate()
            f.GridView1.Columns.Clear()

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = Nothing
            f.GridView1.Columns.Clear()

            f.GridControl1.DataSource = dt

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            With f.GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False

                .Columns("ClientHVHH").Caption = "ՀՎՀՀ"
                .Columns("CompanyName").Caption = "Կազմակերպություն"
                .Columns("Invoice").Caption = "Ինվոյս"
                .Columns("Havelvac").Caption = "Հավելված"
                .Columns("Tarberutyun").Caption = "Տարբերություն"
                .Columns("InvoiceSupporter").Caption = "Ինվ-ի Սպասարկող"
                .Columns("CompanyByClient").Caption = "Կազմ-ան Սպասարկող"
                .Columns("Region").Caption = "Տարածաշրջան"

                .BestFitColumns(True)
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("ClientHVHH").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ClientHVHH", "{0}")
                    f.GridView1.Columns("ClientHVHH").Summary.Add(item)
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
            Me.Close()
        End Try
    End Sub
    Private Sub DateDebetKredet_Load(sender As Object, e As EventArgs) Handles Me.Load
        cYear.Items.Clear()
        For i As Integer = 2013 To 2030
            cYear.Items.Add(i)
        Next
        cYear.SelectedItem = Now.Year

        cMonth.Items.Clear()
        For i As Integer = 1 To 12
            cMonth.Items.Add(i)
        Next
        cMonth.SelectedItem = Now.Month
    End Sub

End Class