Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class htsByInterval

    Friend startValue As Integer
    Friend endValue As Integer
    Friend isNew As Boolean = False

    Private iDuration As String = "00:00"

    Private Sub LoadData()
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            Dim dt As DataTable
            formX.Show() : My.Application.DoEvents()

            sTime = Now
            If isNew = False Then
                dt = iDB.GetHTSByInterval(startValue, endValue)
            Else
                dt = iDB.GetHTSByInterval2(startValue, endValue)
            End If

            eTime = Now

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                If isNew = False Then .Columns("Գույն").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                '.Columns("ՓոփոխմանԱմսաթիվ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                '.Columns("ՓոփոխմանԱմսաթիվ").DisplayFormat.FormatString = "dd.MM.yyyy"
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
    Private Sub htsByInterval_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
    End Sub
    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next
        If isNew = True Then Exit Sub
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim Colored As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Գույն"))
            If Colored = "Checked" Then
                e.Appearance.BackColor = Color.GreenYellow        ' Color.Salmon
                e.Appearance.BackColor2 = Color.Yellow            ' Color.SeaShell
            End If
        End If
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