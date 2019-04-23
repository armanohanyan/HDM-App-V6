Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class hdmAraqumWindow

    Dim iDuration As String = "00:00"
    Dim uniqueID As String

    Friend Sub DeleteRecord()
        If IsNothing(GridView1.GetFocusedDataRow) Then Exit Sub
        Dim recID As Integer = GridView1.GetFocusedDataRow.Item("ShippingID").ToString

        Dim q As MsgBoxResult = MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title)
        If q = MsgBoxResult.Yes Then
            iDB.DeleteEcrShipping(recID)
            MsgBox("Գրանցումը հաջողությամբ ջնջվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Call LoadData(uniqueID)
        End If
    End Sub
    Private Sub getRegion()
        Try
            Dim dt As DataTable = iDB.GetRegionNotYerevan
            With cbRegions
                .DataSource = dt
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub hdmAraqumWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        dTime.DateTime = Now
        uniqueID = Guid.NewGuid.ToString
        Call getRegion()
    End Sub
    Private Sub LoadData(ByVal EcrGUID As String)
        Dim sTime As DateTime
        Dim eTime As DateTime
        Dim dt As DataTable

        sTime = Now
        dt = iDB.GetEcrShipping(EcrGUID)
        eTime = Now

        GridControl1.BeginUpdate()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        GridControl1.DataSource = dt

        GridView1.ClearSelection()
        GridControl1.EndUpdate()

        With GridView1
            .Columns("ShippingID").Visible = False
            .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
            .OptionsBehavior.Editable = False
            .OptionsBehavior.ReadOnly = True
            .OptionsView.AllowCellMerge = False
            .OptionsSelection.MultiSelect = False
            .OptionsSelection.EnableAppearanceFocusedCell = False
        End With
        If GridView1.RowCount > 0 Then
            If GridView1.Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "Քանակ {0}")
                GridView1.Columns("ՀԴՄ").Summary.Add(item)
            End If
        End If
    End Sub
    Private Sub hdmAraqumWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        MainWindow.InfoTime.Caption = iDuration
    End Sub

#Region "Menu"

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
    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Try
            If CheckPermission2("C6A262119E474BC99055030EBDF0A937") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
            Call DeleteRecord()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

    Private Sub txtHDM_TextChanged(sender As Object, e As EventArgs) Handles txtHDM.TextChanged
        On Error Resume Next
        If txtHDM.Text.Length = 1 Then
            If txtHDM.Text.StartsWith("V") Then
                txtHDM.Text = txtHDM.Text.Replace("V", "V90413") : txtHDM.SelectionStart = txtHDM.Text.Length
            ElseIf txtHDM.Text.StartsWith("v") Then
                txtHDM.Text = txtHDM.Text.Replace("v", "V90413") : txtHDM.SelectionStart = txtHDM.Text.Length
            ElseIf txtHDM.Text.StartsWith("Q") Then
                txtHDM.Text = txtHDM.Text.Replace("Q", "Q80414") : txtHDM.SelectionStart = txtHDM.Text.Length
            ElseIf txtHDM.Text.StartsWith("q") Then
                txtHDM.Text = txtHDM.Text.Replace("q", "Q80414") : txtHDM.SelectionStart = txtHDM.Text.Length
            ElseIf txtHDM.Text.StartsWith("S") Then
                txtHDM.Text = txtHDM.Text.Replace("S", "S900552") : txtHDM.SelectionStart = txtHDM.Text.Length
            ElseIf txtHDM.Text.StartsWith("s") Then
                txtHDM.Text = txtHDM.Text.Replace("s", "S900552") : txtHDM.SelectionStart = txtHDM.Text.Length
            End If
        End If
    End Sub
    Private Sub btnClearData_Click(sender As Object, e As EventArgs) Handles btnClearData.Click
        uniqueID = Guid.NewGuid.ToString
        cbPlace.Text = String.Empty
        txtHDM.Text = String.Empty
        txtNumber.Text = String.Empty
        txtTel.Text = String.Empty
        cbRegions.Enabled = True
        cbPlace.Enabled = True
        dTime.Enabled = True
        txtTel.Enabled = True
        txtNumber.Enabled = True
        txtHDM.Focus()
    End Sub
    Private Sub btnAddRecord_Click(sender As Object, e As EventArgs) Handles btnAddRecord.Click
        Try
            If CheckPermission2("C5F1E5A8856B44F5A706CE1C3E9A16E7") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If String.IsNullOrEmpty(txtHDM.Text) Then Throw New Exception("ՀԴՄ-ն գրված չէ")
            If String.IsNullOrEmpty(cbPlace.Text) Then Throw New Exception("Ժամանելու վայրը գրված չէ")
            If String.IsNullOrEmpty(txtTel.Text) Then Throw New Exception("Վարորդի հեռախոսը գրված չէ")
            If String.IsNullOrEmpty(txtNumber.Text) Then Throw New Exception("Մեքենայի համարը գրված չէ")

            Dim iBid = New With {.EcrID = txtHDM.Text.Trim,
                                  .RegionID = cbRegions.SelectedValue,
                                  .ShippingPlace = cbPlace.Text.Trim,
                                  .ShippingTime = dTime.DateTime,
                                  .DriverTelephone = txtTel.Text.Trim,
                                  .CarNumber = txtNumber.Text.Trim,
                                 .GUID = uniqueID}

            iDB.AddEcrShipping(iBid.EcrID, iBid.RegionID, iBid.ShippingPlace, iBid.ShippingTime, iBid.DriverTelephone, iBid.CarNumber, iBid.GUID, iUser.DB)

            cbRegions.Enabled = False
            cbPlace.Enabled = False
            dTime.Enabled = False
            txtTel.Enabled = False
            txtNumber.Enabled = False

            Call LoadData(iBid.GUID)

            MsgBox("Տվյալները ավելացվեցին", MsgBoxStyle.Information, My.Application.Info.Title)

            txtHDM.Text = String.Empty
            txtHDM.Focus()
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