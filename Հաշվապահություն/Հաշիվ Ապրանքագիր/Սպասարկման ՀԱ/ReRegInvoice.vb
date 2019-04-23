Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class ReRegInvoice

    Private iDuration As String = "00:00"

    Private Function loadLastDay(hvhh As String) As Date
        Dim d As Date = New DateTime(Now.Year, Now.Month, 1)
        Try
            Dim Y As Short = Now.Year
            Dim M As Byte = Now.Month

            Dim dt As DataTable = iDB.GetLastDayForCustomInvoice(hvhh, Y, M, cSupporter.SelectedValue)
            If dt.Rows.Count = 0 Then Throw New Exception("Օրերը չեն ստացվել")

            d = dt.Rows(0)(0)

            'Min Date
            sDate.DateTime = d

            'Max Date
            Dim d2 As Date = DateAdd(DateInterval.Day, 1, sDate.DateTime)

            If d > DateSerial(Y, M + 1, 0) Then Throw New Exception("Ամսվա համար ինվոյս տպված է")

            If d2 > DateSerial(Y, M + 1, 0) Then d2 = DateSerial(Y, M + 1, 0)

            With eDate
                .Properties.MinValue = d2
                .Properties.MaxValue = DateSerial(Y, M + 1, 0)
                .DateTime = d2
            End With

            btnCheck.Enabled = False
            btnMakeInvoice.Enabled = True
            eDate.ReadOnly = False
            txtHVHH.ReadOnly = True
            cSupporter.Enabled = False

            Return d
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Function
    Private Sub LoadSupporter()
        Try
            Dim dt As DataTable = iDB.GetWarehouseList2()
            With cSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                .SelectedIndex = 0
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadData()
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime
        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now
            Dim dt As DataTable

            dt = iDB.GetReRegInvoice()

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()

            GridControl1.DataSource = dt

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            With GridView1
                .Columns("ՀՀ").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

            GridView1.ClearSelection()
            GridControl1.EndUpdate()

            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Կազմակերպություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Կազմակերպություն", "Գրանցումներ {0}")
                    GridView1.Columns("Կազմակերպություն").Summary.Add(item)
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
        End Try
    End Sub
    Private Sub ReRegInvoice_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub
    Private Sub mnuExportToExcel_Click(sender As Object, e As EventArgs) Handles mnuExportToExcel.Click
        Try
            ExportTo(ExportType.Excel2013, Me)
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ReRegInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load

        Call LoadData()
        Call LoadSupporter()

        mDate.DateTime = Now
        dDate.DateTime = Now

    End Sub
    Private Sub mnuConfirme_Click(sender As Object, e As EventArgs) Handles mnuConfirme.Click
        Try
            If CheckPermission2("6491C1B93C3942A6A0F40B4F5CB107A9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
            Dim recID As Short = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString

            Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք գրանցումը հաստատել որպես տպված", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
            If q = MsgBoxResult.Yes Then
                iDB.UpdateReRegInvoice(recID)
                MsgBox("Գրանցումը հաջողությամբ հաստատվեց", MsgBoxStyle.Information, My.Application.Info.Title)
                Call LoadData()
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If CheckPermission2("A5DD48DBAC7242E987EBE45B30B7773E") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub

        If txtHVHH.Text.Trim = String.Empty Then MsgBox("ՀՎՀՀ-ն գրված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        If txtHVHH.Text.Trim = "00251624" OrElse txtHVHH.Text.Trim = "00841267" OrElse txtHVHH.Text.Trim = "00845894" OrElse txtHVHH.Text.Trim = "01562313" Then MsgBox("ՀՎՀՀ-ն սխալ է գրված", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        Call loadLastDay(txtHVHH.Text.Trim)
    End Sub
    Private Sub btnMakeInvoice_Click(sender As Object, e As EventArgs) Handles btnMakeInvoice.Click
        Try
            If CheckPermission2("9AD2642800824AFC89E5223A949FF4AB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            iDB.CreateCustomInvoiceByDay(txtHVHH.Text.Trim, sDate.DateTime, eDate.DateTime, cSupporter.SelectedValue, mDate.DateTime, dDate.DateTime, iUser.LoginName)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            btnCheck.Enabled = True
            btnMakeInvoice.Enabled = False
            eDate.ReadOnly = True
            txtHVHH.ReadOnly = False
            cSupporter.Enabled = True
            txtHVHH.Text = String.Empty
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub eDate_EditValueChanged(sender As Object, e As EventArgs) Handles eDate.EditValueChanged
        mDate.DateTime = eDate.DateTime
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