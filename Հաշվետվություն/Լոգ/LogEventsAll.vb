Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data
Imports DevExpress.Utils

Public Class LogEventsAll

    Private iDuration As String = "00:00"

    Friend Enum T
        TelCellLogEvent = 1
        TelCellPayment = 2
        OrangeLogEvent = 3
    End Enum

    Friend LE As Integer

    Private Sub TelCellLogEventsWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            sTime = Now

            If LE = T.TelCellLogEvent Then dt = iDB.GetTelCellLogEvents()
            If LE = T.TelCellPayment Then dt = iDB.GetTelCellPayment()
            If LE = T.OrangeLogEvent Then dt = iDB.GetOrangeServiceEventLog()

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
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

            If LE = T.OrangeLogEvent Then

                GridView1.Columns("CreateDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GridView1.Columns("CreateDate").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                GridView1.Columns("LastSendDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GridView1.Columns("LastSendDate").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                GridView1.Columns("StatusChangedDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GridView1.Columns("StatusChangedDate").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                If GridView1.Columns("GPRS").Summary.ActiveCount = 0 Then
                    GridView1.Columns("GPRS").Summary.Add(New GridColumnSummaryItem(SummaryItemType.Count, "GPRS", "{0}"))
                End If
            ElseIf LE = T.TelCellLogEvent Then
                GridView1.Columns("localDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GridView1.Columns("localDate").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                If GridView1.Columns("number").Summary.ActiveCount = 0 Then
                    GridView1.Columns("number").Summary.Add(New GridColumnSummaryItem(SummaryItemType.Count, "number", "{0}"))
                End If
            ElseIf LE = T.TelCellPayment Then
                GridView1.Columns("localDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GridView1.Columns("localDate").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                GridView1.Columns("PayDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GridView1.Columns("PayDate").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                GridView1.Columns("receiptDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GridView1.Columns("receiptDate").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"

                GridView1.Columns("amount").DisplayFormat.FormatType = FormatType.Numeric
                GridView1.Columns("amount").DisplayFormat.FormatString = "n2"

                If GridView1.Columns("number").Summary.ActiveCount = 0 Then
                    GridView1.Columns("number").Summary.Add(New GridColumnSummaryItem(SummaryItemType.Count, "number", "{0}"))
                End If

                If GridView1.Columns("amount").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:n2}")
                    GridView1.Columns("amount").Summary.Add(item)
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