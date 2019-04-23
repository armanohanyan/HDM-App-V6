Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class CallHaytActivate

    Private Sub LoadSupporter()
        Try
            Dim dt As DataTable = iDB.GetSupporter
            With cbSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                .SelectedValue = 5
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadRegion()
        Try
            Dim dt As DataTable = iDB.GetRegion
            With cbRegion
                .DataSource = dt
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "ՀՀ"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub PetPos()
        Try
            If txtEcr.Text.Trim = String.Empty Then txtPos.Text = "" : Exit Sub
            Dim b As Boolean = iDB.IsEcrPOS(txtEcr.Text.Trim)

            If b = True Then txtPos.Text = "POS" Else txtPos.Text = ""
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Function TesuchForGPS(ByVal ecr As String) As Integer
        On Error Resume Next
        Dim iTesuch As Integer = 0
        iTesuch = iDB.GetTesuchID(ecr)
        Return iTesuch
    End Function
    Private Sub googlemaps()
        Dim iEcr As String = txtEcr.Text.Trim

        Dim EcrLocation As String = iDB.RetGPSByEcr(iEcr)
        Dim TesuchLocation As String = iDB.RetGPSByTesuch(TesuchForGPS(iEcr))

        If EcrLocation.Length > 1 AndAlso TesuchLocation.Length > 1 Then
            Dim url As String = "https://www.google.com/maps/dir/'" & TesuchLocation & "'/'" & EcrLocation & "'"
            WebBrowser1.Navigate(url)
        End If

    End Sub

    Private Function isHDMExists(hdm As String) As Boolean
        Try
            Dim icount As Object = iDB.ProposalActivateEcrCount(hdm)
            If IsDBNull(icount) OrElse icount = 0 Then Return False
            Return True
        Catch ex As ExceptionClass
            Return True
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            Return True
        Catch ex As Exception
            Call SoftException(ex)
            Return True
        End Try
    End Function
    Private Function GetPayment() As String
        Try
            Return iDB.CallCenterRepPayment(txtEcr.Text.Trim)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub CallHaytActivate_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error Resume Next

        'Dim d1 As Date
        'If Now.Date.DayOfWeek = DayOfWeek.Saturday Then
        '    d1 = DateAdd(DateInterval.Day, 2, Now.Date)
        'Else
        '    d1 = DateAdd(DateInterval.Day, 1, Now.Date)
        'End If
        sDate.DateTime = DateAdd(DateInterval.Hour, 1, Now)

        Call LoadSupporter()
        Call LoadRegion()

    End Sub
    Private Sub txtEcr_TextChanged(sender As Object, e As EventArgs) Handles txtEcr.TextChanged
        On Error Resume Next
        If txtEcr.Text.Trim.Length = 1 Then
            If txtEcr.Text.StartsWith("V") Then
                txtEcr.Text = txtEcr.Text.Replace("V", "V90413") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("v") Then
                txtEcr.Text = txtEcr.Text.Replace("v", "V90413") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("Q") Then
                txtEcr.Text = txtEcr.Text.Replace("Q", "Q80414") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("q") Then
                txtEcr.Text = txtEcr.Text.Replace("q", "Q80414") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("S") Then
                txtEcr.Text = txtEcr.Text.Replace("S", "S900552") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("s") Then
                txtEcr.Text = txtEcr.Text.Replace("s", "S900552") : txtEcr.SelectionStart = txtEcr.Text.Length
            End If
        End If

        If txtEcr.Text.Trim.Length = 12 Then
            If isHDMExists(txtEcr.Text.Trim) = True Then Label10.Text = "Առկա Հայտ" Else Label10.Text = ""
            txtPay.Text = GetPayment()
            If txtPay.Text.Length > 0 Then
                If IsNumeric(txtPay.Text) = True Then
                    If txtPay.Text < 0 Then
                        txtPay.ForeColor = Color.Red
                    Else
                        txtPay.ForeColor = Color.Black
                    End If
                End If
            End If

            Call PetPos()

            'google maps
            'Call googlemaps()
        Else
            Label10.Text = ""
            txtPay.Text = ""
        End If
    End Sub
    Private Sub Do_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtEcr.KeyDown, txtHVHH.KeyDown, txtAddress.KeyDown, txtClient.KeyDown
        On Error Resume Next
        If sender Is txtEcr Then If e.KeyCode = Keys.Enter Then bEcr.PerformClick()
        If sender Is txtHVHH Then If e.KeyCode = Keys.Enter Then bhvhh.PerformClick()
        If sender Is txtAddress Then If e.KeyCode = Keys.Enter Then bAddr.PerformClick()
        If sender Is txtClient Then If e.KeyCode = Keys.Enter Then bClient.PerformClick()
    End Sub
    Private Sub bEcr_Click(sender As Object, e As EventArgs) Handles bEcr.Click
        Try
            If txtEcr.Text.Trim = String.Empty Then Throw New Exception("ՀԴՄ-ն գրված չէ")
            Dim strHDM As String = txtEcr.Text.Trim
            If Len(strHDM) <> 12 Then Throw New Exception("ՀԴՄ-ն պետք է ունենա 12 սիմվոլ երկարություն")
            Dim dt As System.Data.DataTable = iDB.ActivatePropGetClient(strHDM)
            If dt.Rows.Count = 0 Then
                txtHVHH.Focus()
            Else
                txtHVHH.Text = dt.Rows(0)("ՀՎՀՀ")
                txtAddress.Text = dt.Rows(0)("Հասցե")
                txtClient.Text = dt.Rows(0)("Գործընկեր")

                txtTel.Focus()
            End If

            If txtHVHH.Text <> String.Empty Then
                Dim dt2 As DataTable = iDB.ActivatePropGetSupporter(txtHVHH.Text.Trim)
                If dt2.Rows.Count = 1 Then
                    cbSupporter.SelectedValue = dt2.Rows(0)(0)
                Else
                    cbSupporter.SelectedValue = 5
                End If
            Else
                cbSupporter.SelectedValue = 5
            End If

            Call PetPos()

            Dim dt3 As System.Data.DataTable = iDB.GlobalPropGetEcrGPRSStatus(txtEcr.Text.Trim)

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()
            GridControl1.DataSource = dt3
            GridView1.ClearSelection()

            With GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
            End With

            GridControl1.EndUpdate()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub bhvhh_Click(sender As Object, e As EventArgs) Handles bhvhh.Click
        Try
            If txtHVHH.Text.Trim = String.Empty Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")
            Dim strHVHH As String = txtHVHH.Text.Trim
            If Len(strHVHH) = 8 OrElse Len(strHVHH) = 9 Then
                'OK
            Else
                Throw New Exception("ՀՎՀՀ-ն պետք է ուենա 8 սիմվոլ երկարություն")
            End If

            Call PetPos()

            Dim dt As System.Data.DataTable = iDB.ActivatePropGetByHVHH(strHVHH)

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

            If txtHVHH.Text <> String.Empty Then
                Dim dt2 As DataTable = iDB.ActivatePropGetSupporter(txtHVHH.Text.Trim)
                If dt2.Rows.Count = 1 Then
                    cbSupporter.SelectedValue = dt2.Rows(0)(0)
                Else
                    cbSupporter.SelectedValue = 5
                End If
            Else
                cbSupporter.SelectedValue = 5
            End If

            txtAddress.Focus()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub bAddr_Click(sender As Object, e As EventArgs) Handles bAddr.Click
        Try
            If txtAddress.Text.Trim = String.Empty Then Throw New Exception("Հասցեն գրված չէ")
            Dim strAddress As String = txtAddress.Text.Trim

            Dim dt As System.Data.DataTable = iDB.ActivatePropGetByAddress(strAddress)

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

            If txtHVHH.Text <> String.Empty Then
                Dim dt2 As DataTable = iDB.ActivatePropGetSupporter(txtHVHH.Text.Trim)
                If dt2.Rows.Count = 1 Then
                    cbSupporter.SelectedValue = dt2.Rows(0)(0)
                Else
                    cbSupporter.SelectedValue = 5
                End If
            Else
                cbSupporter.SelectedValue = 5
            End If

            txtClient.Focus()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub bClient_Click(sender As Object, e As EventArgs) Handles bClient.Click
        Try
            If txtClient.Text.Trim = String.Empty Then Throw New Exception("Կազմակերպության անվանումը գրված չէ")
            Dim strCompany As String = txtClient.Text.Trim
            Dim dt As System.Data.DataTable = iDB.ActivatePropGetByClient(strCompany)

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

            If txtHVHH.Text <> String.Empty Then
                Dim dt2 As DataTable = iDB.ActivatePropGetSupporter(txtHVHH.Text.Trim)
                If dt2.Rows.Count = 1 Then
                    cbSupporter.SelectedValue = dt2.Rows(0)(0)
                Else
                    cbSupporter.SelectedValue = 5
                End If
            Else
                cbSupporter.SelectedValue = 5
            End If

            txtTel.Focus()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        On Error Resume Next
        txtEcr.Text = ""
        txtHVHH.Text = ""
        txtAddress.Text = ""
        txtClient.Text = ""
        txtTel.Text = ""
        txtTesuch.Text = ""
        txtApproveCode.Text = ""

        GridControl1.BeginUpdate()
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        GridControl1.EndUpdate()

        cbRegion.SelectedIndex = 0
        cbSupporter.SelectedValue = 5

        'Dim d1 As Date
        'If Now.Date.DayOfWeek = DayOfWeek.Saturday Then
        '    d1 = DateAdd(DateInterval.Day, 2, Now.Date)
        'Else
        '    d1 = DateAdd(DateInterval.Day, 1, Now.Date)
        'End If
        sDate.DateTime = Now

        txtEcr.Focus()
    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            txtEcr.Text = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString
            txtHVHH.Text = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString
            txtClient.Text = GridView1.GetFocusedDataRow.Item("Գործընկեր").ToString
            txtAddress.Text = GridView1.GetFocusedDataRow.Item("Հասցե").ToString

            If txtHVHH.Text <> String.Empty Then
                Dim dt2 As DataTable = iDB.ActivatePropGetSupporter(txtHVHH.Text.Trim)
                If dt2.Rows.Count = 1 Then
                    cbSupporter.SelectedValue = dt2.Rows(0)(0)
                Else
                    cbSupporter.SelectedValue = 5
                End If
            Else
                cbSupporter.SelectedValue = 5
            End If

            Call PetPos()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try

            If MsgBox("Ցանկանու՞մ եք ավելացնել հայտ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            If String.IsNullOrEmpty(txtEcr.Text) AndAlso
               String.IsNullOrEmpty(txtHVHH.Text) AndAlso
               String.IsNullOrEmpty(txtAddress.Text) AndAlso
               String.IsNullOrEmpty(txtClient.Text) AndAlso
               String.IsNullOrEmpty(txtTel.Text) Then
                Throw New Exception("Հայտի համար հարկավոր է լրացնել որևէ ինֆորմացիա")
            End If

            If txtTel.Text.Trim = String.Empty Then Throw New Exception("Հեռախոսը պարտադիր է")

            If txtEcr.Text.Trim.Length = 12 Then If isHDMExists(txtEcr.Text.Trim) = True Then Throw New Exception("Սույն ՀԴՄ-ի համար հայտը ակտիվ է")

            Dim Loc As String = "0,0"

            'Get Location
            If txtEcr.Text.Trim.Length = 12 Then
                Loc = iDB.LocationForProp(txtEcr.Text.Trim, txtAddress.Text.Trim)
            End If

            If Loc = "0,0" Then
                Dim gF As New GPSforProp
                gF.ShowDialog()
                Loc = gF.Loc
                gF.Dispose()
            End If

            Dim propDate As DateTime
            propDate = sDate.DateTime
            If DateAdd(DateInterval.Hour, 1, Now) > propDate Then
                propDate = DateAdd(DateInterval.Hour, 1, Now)
            End If

            Dim dt As DataTable = iDB.AddActivateProp(txtEcr.Text.Trim, txtHVHH.Text.Trim, txtAddress.Text.Trim, txtClient.Text.Trim,
                                 txtTel.Text.Trim, cbRegion.Text, txtTesuch.Text, False, iUser.LoginName, False, propDate, cbSupporter.SelectedValue, False, txtApproveCode.Text.Trim,
                                 Loc)

            If dt.Rows.Count > 0 Then
                Dim ID As Integer = dt.Rows(0)("ID")

                Dim tTel As String = iDB.TesuchTel(txtTesuch.Text.Trim)

                If Not String.IsNullOrEmpty(tTel) AndAlso tTel <> "-" Then
                    Dim f As New CallSmsActivate With {.I_PropID = ID, .I_Tesuch = txtTesuch.Text.Trim, .I_Tel = tTel}
                    f.ShowDialog()
                    f.Dispose()
                End If
            End If

            MsgBox("Տվյալները ավելացվեցին", MsgBoxStyle.Information, My.Application.Info.Title)

            'Dim d1 As Date
            'If Now.Date.DayOfWeek = DayOfWeek.Saturday Then
            '    d1 = DateAdd(DateInterval.Day, 2, Now.Date)
            'Else
            '    d1 = DateAdd(DateInterval.Day, 1, Now.Date)
            'End If

            sDate.DateTime = DateAdd(DateInterval.Hour, 1, Now)

            btnClean.PerformClick()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub cbRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRegion.SelectedIndexChanged
        On Error Resume Next
        If IsNothing(cbRegion.SelectedValue) Then Exit Sub

        'GetTesuch
        Dim s As String = iDB.GetCustomTesuchByRegin(cbRegion.SelectedValue)
        txtTesuch.Text = s

        'GetPropCount
        Dim iCount As Integer = iDB.GetPropCount(s)
        txtProps.Text = iCount

    End Sub
    Private Sub CallHaytGeneral_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call cbRegion_SelectedIndexChanged(cbRegion, Nothing)
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
    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        On Error Resume Next

        Dim View As GridView = sender
        If e.Column.FieldName = "ՋնջվածGprs" Then
            Dim ColPercent = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՋնջվածGprs"))

            If ColPercent = "Checked" Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.White
            End If

        End If

    End Sub

End Class