Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class OpenPropList

    Friend IsTotal As Boolean = True

    Private Sub LoadData()
        Dim formX As New Working

        Dim sTime As DateTime
        Dim eTime As DateTime

        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            dt = iDB.GetOpenPropDetails(IsTotal)

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
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .BestFitColumns(True)

                If IsTotal = False Then
                    .Columns("ԸնդԱմս").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ԸնդԱմս").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                    .Columns("ԿատԱմս").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("ԿատԱմս").DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
                End If

                For i As Integer = 0 To .Columns.Count - 1
                    .Columns(i).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                Next

            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

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
        End Try
    End Sub
    Private Sub OpenPropList_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadData()
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