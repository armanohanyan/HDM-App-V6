Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data
Imports DevExpress.Utils

Public Class EcrTesuchRep

    Private iDuration As String = "00:00"

    Private Sub EcrTesuchRep_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()

            sTime = Now
            Dim DT As DataTable = iDB.GetEcrTesuchResult()
            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = DT

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

            If GridView1.Columns(1).Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Տարիֆ 0", "{0}")
                GridView1.Columns(1).Summary.Add(item)
            End If

            If GridView1.Columns(2).Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Տարիֆ 900", "{0}")
                GridView1.Columns(2).Summary.Add(item)
            End If

            If GridView1.Columns(3).Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Տարիֆ 1200", "{0}")
                GridView1.Columns(3).Summary.Add(item)
            End If

            If GridView1.Columns(4).Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Տարիֆ 3000", "{0}")
                GridView1.Columns(4).Summary.Add(item)
            End If

            If GridView1.Columns(5).Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Տարիֆ 3600", "{0}")
                GridView1.Columns(5).Summary.Add(item)
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