Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports JamaaTech.Smpp.Net.Client

Public Class CallHaytGeneral

    Dim RepEcr As String = String.Empty


    Private Sub getInf()
        On Error Resume Next
        If txtEcr.Text.Trim = String.Empty Then Exit Sub

        Dim dt As DataTable = iDB.HaytSubInfo(txtEcr.Text.Trim)

        If dt.Rows.Count = 1 Then
            If dt.Rows(0)("L") = True Then
                txtStatus.Text = "POS / " & dt.Rows(0)("S")
            Else
                txtStatus.Text = dt.Rows(0)("S")
            End If
            txtPartq.Text = dt.Rows(0)("G")
            txtGPRS.Text = dt.Rows(0)("P")
        End If

    End Sub

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

            Dim dtR As DataTable = iDB.GetRegion

            With cbRegion
                .DataSource = dtR
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
    Private Function isHDMExists(hdm As String) As Boolean
        Try
            Dim icount As Object = iDB.ProposalGeneralEcrCount(hdm)
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

    Private Sub loadHayt()
        Try
            Dim dt As DataTable = iDB.LoadProblemList()
            With cbRemProblem
                .DataSource = dt
                .DisplayMember = "Problem"
                .ValueMember = "IsSoftware"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadReplData()
        Try
            Dim dt As DataTable = iDB.GetReadyEcrForReplace(txtEcr.Text.Trim)
            If dt.Rows.Count = 0 Then
                btnOK.Enabled = False
                Return
            End If

            With cbEcr
                .DataSource = dt
                .DisplayMember = "ECR"
                .ValueMember = "ecrID"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub LoadRepEcr()
        Try
            RepEcr = iDB.GetQueueReplaceEcrD(txtEcr.Text.Trim)
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub CallHaytGeneral_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        cProb.SelectedIndex = 0

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

            'google maps
            'Call googlemaps()

        Else
            Label10.Text = ""
        End If

    End Sub
    Private Sub Do_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtEcr.KeyDown, txtHVHH.KeyDown, txtAddress.KeyDown, txtClient.KeyDown
        On Error Resume Next
        If sender Is txtEcr Then If e.KeyCode = Keys.Enter Then bEcr.PerformClick()
        If sender Is txtHVHH Then If e.KeyCode = Keys.Enter Then bhvhh.PerformClick()
        If sender Is txtClient Then If e.KeyCode = Keys.Enter Then bClient.PerformClick()
    End Sub
    Private Sub bEcr_Click(sender As Object, e As EventArgs) Handles bEcr.Click
        Try
            If txtEcr.Text.Trim = String.Empty Then Throw New Exception("ՀԴՄ-ն գրված չէ")
            Dim strHDM As String = txtEcr.Text.Trim
            If Len(strHDM) <> 12 Then Throw New Exception("ՀԴՄ-ն պետք է ունենա 12 սիմվոլ երկարություն")
            Dim dt As System.Data.DataTable = iDB.GlobalPropGetClient(strHDM)
            If dt.Rows.Count = 0 Then
                txtHVHH.Focus()
            Else
                txtHVHH.Text = dt.Rows(0)("ՀՎՀՀ")
                txtAddress.Text = dt.Rows(0)("Հասցե")
                txtClient.Text = dt.Rows(0)("Գործընկեր")
                'txtTel.Text = dt.Rows(0)("Հեռ")
                If dt.Rows(0)("Տարածաշրջան") <> "-" Then cbRegion.Text = dt.Rows(0)("Տարածաշրջան")

                txtProblem.Focus()
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

            Call getInf()

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

            Dim dt As System.Data.DataTable = iDB.GlobalPropGetByHVHH(strHVHH)

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()
            GridControl1.DataSource = dt
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
    Private Sub bClient_Click(sender As Object, e As EventArgs) Handles bClient.Click
        Try
            If txtClient.Text.Trim = String.Empty Then Throw New Exception("Կազմակերպության անվանումը գրված չէ")
            Dim strCompany As String = txtClient.Text.Trim
            Dim dt As System.Data.DataTable = iDB.GeneralPropGetByClient(strCompany)

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
        txtProblem.Text = ""

        txtStatus.Text = ""
        txtPartq.Text = ""
        txtGPRS.Text = ""

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
            'txtTel.Text = GridView1.GetFocusedDataRow.Item("Հեռ").ToString
            If GridView1.GetFocusedDataRow.Item("Տարածաշրջան").ToString <> "-" Then cbRegion.Text = GridView1.GetFocusedDataRow.Item("Տարածաշրջան").ToString

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

            Call getInf()

            txtProblem.Focus()

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
               String.IsNullOrEmpty(txtProblem.Text) AndAlso
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

            If cProb.SelectedIndex = 7 Then 'Arman
                txtProblem.Text = "Վերանորոգման հայտ" + vbCrLf + txtProblem.Text
            End If

            Dim propDate As DateTime
            propDate = sDate.DateTime
            If DateAdd(DateInterval.Hour, 1, Now) > propDate Then
                propDate = DateAdd(DateInterval.Hour, 1, Now)
            End If

            Dim dt As DataTable = iDB.AddGeneralProp(txtEcr.Text.Trim, txtHVHH.Text.Trim, txtAddress.Text.Trim, txtClient.Text.Trim,
                                 txtTel.Text.Trim, cbRegion.Text, txtTesuch.Text, False, iUser.LoginName, False, propDate, cbSupporter.SelectedValue, False, txtProblem.Text.Trim,
                                 Loc, cProb.SelectedIndex)

            If dt.Rows.Count > 0 Then
                Dim ID As Integer = dt.Rows(0)("ID")

                Dim tTel As String = iDB.TesuchTel(txtTesuch.Text.Trim)

                If Not String.IsNullOrEmpty(tTel) AndAlso tTel <> "-" Then
                    Dim f As New CallSmsGeneral With {.I_PropID = ID, .I_Tesuch = txtTesuch.Text.Trim, .I_Tel = tTel, .I_Problem = txtProblem.Text.Trim}
                    f.ShowDialog()
                    f.Dispose()
                End If
            End If

            'Ուղարկել Վաճառքի SMS
            If cProb.SelectedIndex = 8 Then 'Arman
                SendSmsForSell(txtHVHH.Text)
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
    Private Sub cbRegion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbRegion.SelectedValueChanged
        On Error Resume Next

        If IsNothing(cbRegion.SelectedValue) Then txtTesuch.Text = String.Empty : Exit Sub
        Dim s As String = iDB.GetCustomTesuchByRegin(cbRegion.SelectedValue)
        txtTesuch.Text = s

    End Sub
    Private Sub CallHaytGeneral_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call cbRegion_SelectedValueChanged(cbRegion, Nothing)

        Call loadHayt()
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
    Private Sub cProb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cProb.SelectedIndexChanged
        On Error Resume Next
        btnMessageToAccount.Enabled = False
        Select Case cProb.SelectedIndex
            Case 0
                txtProblem.Text = String.Empty

                cbRemProblem.Enabled = False
            Case 1
                btnMessageToAccount.Enabled = True
                txtProblem.Text = "Վերագրանցում, ձեռք են բերել  ____________ ՍՊԸ/ԱՁ-ից, ՀՎՀՀ ________   լուծարել պայմանագիրը(անհրաժեշտության դեպքում)։"

                cbRemProblem.Enabled = False
            Case 2
                btnMessageToAccount.Enabled = True
                txtProblem.Text = "Ապաակտիվացում, լուծարել պայմանագիրը(անհրաժեշտության դեպքում)։"

                cbRemProblem.Enabled = False
            Case 3
                txtProblem.Text = "_________ հարկ․ անցնում են _________ ,տանել համաձայնագիր։"

                cbRemProblem.Enabled = False
            Case 4
                txtProblem.Text = "Բաժին ավելացնել  հին հարկատեսակով՝ _______ / նոր հարկատեսակ՝ _______ , տանել համաձայնագիր։"

                cbRemProblem.Enabled = False
            Case 5
                txtProblem.Text = "Տանել համաձայնագիր "

                cbRemProblem.Enabled = False
            Case 6
                txtProblem.Text = "Տանել պայմանագիր "

                cbRemProblem.Enabled = False
            Case 7
                txtProblem.Text = "Վերանորոգման հայտ "  'Arman

                cbRemProblem.Enabled = True

                Call LoadReplData()
                Call LoadRepEcr()
            Case 8
                txtProblem.Text = String.Empty

                cbRemProblem.Enabled = False

                Label3.ForeColor = Color.Red

        End Select
    End Sub
    Private Sub txtTesuch_EditValueChanged(sender As Object, e As EventArgs) Handles txtTesuch.EditValueChanged
        On Error Resume Next

        If txtTesuch.Text = String.Empty Then
            txtProps.Text = 0
            Exit Sub
        End If

        'GetPropCount
        Dim iCount As Integer = iDB.GetPropCount(txtTesuch.Text)
        txtProps.Text = iCount
    End Sub
    Private Sub btnMessageToAccount_Click(sender As Object, e As EventArgs) Handles btnMessageToAccount.Click
        Try
            If GridView1.RowCount > 1 Then
                If MsgBox("ՀԴՄ-ների քանակը մեկից մեծ է, ցանկանու՞մ եք շարունակել գործողությունը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub
            End If

            Dim b As Image = My.Resources.infoWarning.ToBitmap

            iDB.AddPublicMessage(b, iUser.UserID, "Խնդրում ենք դուրս գրել Հ/Ա, ՀՎՀՀ` " & txtHVHH.Text.Trim, False, 10)
            iDB.AddPublicMessage(b, iUser.UserID, "Խնդրում ենք դուրս գրել Հ/Ա, ՀՎՀՀ` " & txtHVHH.Text.Trim, False, 12)

            MsgBox("Հաղորդագրությունը ուղարկվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            btnMessageToAccount.Enabled = False

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
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
    Private Sub btnSetAddress_Click(sender As Object, e As EventArgs) Handles btnSetAddress.Click
        txtAddress.Text = "Գրասենյակ"
    End Sub
    Private Sub cbRemProblem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRemProblem.SelectedIndexChanged
        On Error Resume Next
        If cbRemProblem.Enabled = True AndAlso cbRemProblem.Items.Count > 0 Then
            txtProblem.Text = cbRemProblem.Text
            If RepEcr <> String.Empty Then
                txtProblem.Text &= vbCrLf & "Փոխարինող ՀԴՄ` " & RepEcr
            End If
        End If
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            iDB.QueueEcr(txtEcr.Text.Trim, cbEcr.SelectedValue, iUser.LoginName)

            RepEcr = cbEcr.Text

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Call cbRemProblem_SelectedIndexChanged(cbRemProblem, Nothing)
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#Region "SMS"

    Dim WithEvents client As New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

    Private isConnected As Boolean

    Private Sub client_ConnectionStateChanged(sender As System.Object, e As ConnectionStateChangedEventArgs) Handles client.ConnectionStateChanged
        Select Case e.CurrentState
            Case SmppConnectionState.Closed
                'Connection Lost
                isConnected = False
            Case SmppConnectionState.Connected
                'A successful connection has been established
                isConnected = True
            Case SmppConnectionState.Connecting
                'A connection attemp is still on progress
                isConnected = False
            Case Else
                'No Status
                isConnected = False
        End Select
    End Sub
    Private Sub KillClient(ByRef c As SmppClient)
        On Error Resume Next
        If IsNothing(c) Then Exit Sub
        If c.Started = True Then c.Shutdown()
        c = Nothing
    End Sub
    Private Sub SMSToOperatorForSell(ByVal message As String, ByVal ToTel As String, ByVal ecr As String)
        Try
            'check if object is null
            If IsNothing(client) Then client = New SmppClient With {.AutoReconnectDelay = 10000, .ConnectionTimeout = 15000, .KeepAliveInterval = 60000}

            'connection String
            Dim iConnection = New With {.SystemID = "hdmserve2", .Password = "hdmsrv22", .Port = 2775, .Host = "31.47.195.66", .Tel = "HDM Serve"}

            'set properties
            Dim properties As SmppConnectionProperties = client.Properties
            With properties
                .SystemID = iConnection.SystemID
                .Password = iConnection.Password
                .Port = iConnection.Port
                .Host = iConnection.Host
                .SystemType = ""
                .DefaultServiceType = "0"
            End With

            'start client
            If client.Started = False Then client.Start()

            'check if connected
            Dim j As Integer = 0
            Do While isConnected = False
                j += 1
                Threading.Thread.Sleep(200)
                If j = 40 Then Exit Do
            Loop

            'text message object
            Dim msg As New TextMessage()
            With msg
                .RegisterDeliveryNotification = False
                .SourceAddress = iConnection.Tel
            End With

            If isConnected = False Then Throw New Exception("Կապը բացակայում է")

            msg.Text = message

            'message
            msg.DestinationAddress = "+374" & ToTel

            'send sms
            client.SendMessage(msg)

            'save to db
            'iDB.SMSToBranch(ecr)

            Call KillClient(client)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Call KillClient(client)
        End Try
    End Sub
    Private Sub SendSmsForSell(ByVal HVHH As String)
        On Error Resume Next

        Dim s As String = HVHH & "HVHH-i hamar katarel vajarq"
        Dim ToTel As String = GetTelNumber()

        'Send SMS
        SMSToOperatorForSell(s, ToTel, HVHH)

        'Save To DB
        'iDB.InsertSMSForREmake(HVHH, iUser.LoginName)

    End Sub
    Private Function GetTelNumber() As String
        Try

            Return iDB.RetTelNumber()

        Catch ex As Exception
            'Return "43263301" 'Qrist
            Return "98882680" 'Hegh
        End Try
    End Function
#End Region

End Class