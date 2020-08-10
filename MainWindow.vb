Imports DevExpress.XtraBars.Docking
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class MainWindow

#Region "Remake Message Timer"
    Dim WithEvents _tremake As Timer

    Private Sub GridView6_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles GridView6.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        DoRowDoubleClick6(view, pt)
    End Sub
    Private Sub DoRowDoubleClick6(ByVal view As GridView, ByVal pt As Point)
        Try
            Dim info As GridHitInfo = view.CalcHitInfo(pt)
            If info.InRow OrElse info.InRowCell Then
                If info.Column Is Nothing Then
                    'N/A
                Else
                    If IsDBNull(view.GetRowCellValue(info.RowHandle, "ID")) OrElse view.GetRowCellValue(info.RowHandle, "ID") <= 0 Then Exit Sub

                    If view.GetRowCellValue(info.RowHandle, "UserID") = iUser.UserID Then
                        Dim f As New CloseRemakeMessage With {.ID = view.GetRowCellValue(info.RowHandle, "ID"),
                                                              .UserID = view.GetRowCellValue(info.RowHandle, "UserID"),
                                                              .SendUSer = view.GetRowCellValue(info.RowHandle, "SendUser"),
                                                              .Ecr = view.GetRowCellValue(info.RowHandle, "Ecr"),
                                                              .Message = view.GetRowCellValue(info.RowHandle, "Problem")}
                        f.ShowDialog()
                        f.Dispose()

                        Call MessageOpened()
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

    Private Sub GridView7_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles GridView7.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        DoRowDoubleClick7(view, pt)
    End Sub
    Private Sub DoRowDoubleClick7(ByVal view As GridView, ByVal pt As Point)
        Try
            Dim info As GridHitInfo = view.CalcHitInfo(pt)
            If info.InRow OrElse info.InRowCell Then
                If info.Column Is Nothing Then
                    'N/A
                Else
                    If IsDBNull(view.GetRowCellValue(info.RowHandle, "ID")) OrElse view.GetRowCellValue(info.RowHandle, "ID") <= 0 Then Exit Sub

                    Dim f As New RemakeClosedMessageViewer With {.ID = view.GetRowCellValue(info.RowHandle, "ID")}
                    f.ShowDialog()
                    f.Dispose()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

    Private Sub MessageClosed()
        Try
            Dim dt As DataTable = iDB.RemakeMessageClosedByUser(iUser.UserID)
            GridControl7.DataSource = dt
            With GridView7
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False

                .Columns("ID").Visible = False

                .Columns("Ecr").Caption = "ՀԴՄ"
                .Columns("SendTime").Caption = "Ուղարկման Ամսաթիվ"
                .Columns("CloseTime").Caption = "Փակման Ամսաթիվ"

                .Columns("CloseTime").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MessageOpened()
        Try
            Dim dt As DataTable = iDB.RemakeMessageOpened(iUser.UserID)
            GridControl6.DataSource = dt
            With GridView6
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False

                .Columns("ID").Visible = False
                .Columns("ProblemID").Visible = False
                .Columns("SendUserID").Visible = False
                .Columns("UserID").Visible = False

                .Columns("Ecr").Caption = "ՀԴՄ"
                .Columns("Problem").Caption = "Խնդիր"
                .Columns("SendUser").Caption = "Ուղարկող"
                .Columns("GetUser").Caption = "Ստացող"
                .Columns("SendTime").Caption = "Ուղարկման Ամսաթիվ"

                .Columns("SendTime").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetRemakeMessageClosed() Handles _tremake.Tick
        On Error Resume Next

        Call MessageClosed()
        Call MessageOpened()

        If IsWWOpened = False Then
            If GridView6.RowCount > 0 Then
                For i As Integer = 0 To GridView6.RowCount - 1
                    If GridView6.GetRowCellValue(i, "UserID") = iUser.UserID Then
                        Dim f As New WorkShopMessages With {.M = GridView6.GetRowCellValue(i, "Ecr") & vbCrLf & GridView6.GetRowCellValue(i, "Problem")}
                        f.Show()

                        Exit For
                    End If
                Next
            End If
        End If

        If IsWWOpened2 = False Then
            Dim iDT As DataTable = iDB.GetRemakeMessageAnswere(iUser.UserID)
            If Not IsNothing(iDT) AndAlso iDT.Rows.Count = 1 Then
                Dim f As New WorkShopMessagesAnswer With {.M = iDT.Rows(0)("Ecr") & vbCrLf & iDT.Rows(0)("Problem") & vbCrLf & iDT.Rows(0)("CloseMessage"), .ID = iDT.Rows(0)("ID")}
                f.Show()
            End If
        End If

    End Sub

#End Region

#Region "Inner Messages"

    Dim WithEvents _t As Timer
    Dim iMessageLastID As Integer = 0

    Private Sub GetUserMessages() Handles _t.Tick
        Try
            Dim dt As DataTable = iDB.GetUserMessages(iUser.UserID)
            GridControl1.DataSource = dt
            With GridView1
                .Columns("messageID").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False

                .OptionsView.ColumnAutoWidth = False

                .Columns("Տեսակ").Width = 20
                .Columns("Ժամանակ").Width = 70
                .Columns("Ժամանակ").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("Ժամանակ").DisplayFormat.FormatString = "HH:mm dd.MM"
                .Columns("Օգտվող").Width = 50
                .Columns("Հաղորդագրություն").Width = 100

            End With
            If GridView1.RowCount > 0 Then
                If GridView1.Columns("Հաղորդագրություն").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Հաղորդագրություն", "Քանակ {0}")
                    GridView1.Columns("Հաղորդագրություն").Summary.Add(item)
                End If
                If dt.Rows(0)(0) > iMessageLastID Then
                    iMessageLastID = dt.Rows(0)(0)
                    If InfoPanel.Visibility = DockVisibility.Hidden Then InfoPanel.Visibility = DockVisibility.Visible
                End If
            End If
        Catch ex As Exception
            GridControl1.DataSource = Nothing
        End Try
    End Sub
    Private Sub btnMessageArchive_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMessageArchive.ItemClick
        Call CloseWindow("nMessArchive")
        Dim f As New MessageArchive
        AddChildForm("nMessArchive", f)
    End Sub
    Private Sub btnSendMessage_Click(sender As Object, e As EventArgs) Handles btnSendMessage.Click
        Try
            If txtMessage.Text.Trim = "" Then Throw New Exception("Հաղորդագրությունը գրված չէ")

            Dim b As Image
            If cbMessageType.SelectedIndex = 0 Then
                b = My.Resources.InfoMessage.ToBitmap
            Else
                b = My.Resources.infoWarning.ToBitmap
            End If

            iDB.AddPublicMessage(b, iUser.UserID, txtMessage.Text.Trim, True, Nothing)

            MsgBox("Հաղորդագրությունը ուղարկվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            txtMessage.Text = String.Empty

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnPersonalMessage_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPersonalMessage.ItemClick
        Dim f As New AddPersonalMessage
        f.ShowDialog()
        f.Dispose()
    End Sub
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            Dim ID As Integer = GridView1.GetFocusedDataRow.Item("messageID").ToString

            Dim dt As DataTable = iDB.GetUserMessages2(ID)

            If dt.Rows.Count = 1 Then
                Dim f As New CustomMseeageShow
                With f
                    .txtUser.Text = dt.Rows(0)("Օգտվող")
                    .txtMessage.Text = dt.Rows(0)("Հաղորդագրություն")
                    .ShowDialog()
                End With
                f.Dispose()
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#Region "Custom Subs"

    Dim iTotal As Integer = 1
    Dim iTotal2 As Integer = 1
    Dim iTotal3 As Integer = 1

    Dim isResetedLayout As Boolean = False

    Private Sub LoadTimerData()
        On Error Resume Next

        Dim dt As DataTable = iDB.GetWorkshopTime()

        GridControl3.BeginUpdate()
        GridView3.Columns.Clear()

        GridControl3.DataSource = dt

        GridView3.ClearSelection()
        GridControl3.EndUpdate()

        With GridView3
            .Columns("InTimer").Visible = False
            .Columns("Կենտրոն").Visible = False
            .Columns("Մասնաճյուղ").Visible = False
            .Columns("Ելք").Visible = False

            .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
            .OptionsBehavior.Editable = False
            .OptionsBehavior.ReadOnly = True
            .OptionsCustomization.AllowColumnMoving = False
            .OptionsCustomization.AllowGroup = False

            .OptionsView.AllowCellMerge = False
            .OptionsSelection.MultiSelect = False
            .OptionsSelection.EnableAppearanceFocusedCell = False

            .OptionsView.ColumnAutoWidth = True

            .Columns("Կենտրոն").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            '.Columns("Մասնաճյուղ").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            .Columns("InTimer").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        End With

        GridView3.ClearSelection()
        GridControl3.EndUpdate()

    End Sub

    Private Sub LoadTimerData2()
        On Error Resume Next

        Dim dt As DataTable = iDB.GetRepTime1()

        GridControl4.BeginUpdate()
        GridView4.Columns.Clear()

        GridControl4.DataSource = dt

        GridView4.ClearSelection()
        GridControl4.EndUpdate()

        With GridView4
            .Columns("ExpireDate").Visible = False

            .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
            .OptionsBehavior.Editable = False
            .OptionsBehavior.ReadOnly = True
            .OptionsCustomization.AllowColumnMoving = False
            .OptionsCustomization.AllowGroup = False
            .OptionsView.AllowCellMerge = False
            .OptionsSelection.MultiSelect = False
            .OptionsSelection.EnableAppearanceFocusedCell = False
            .OptionsView.ColumnAutoWidth = True
        End With

        GridView4.ClearSelection()
        GridControl4.EndUpdate()

    End Sub

    Private Sub LoadTimerData3()
        On Error Resume Next

        Dim dt As DataTable = iDB.ClosedRepEcrTimer()

        GridControl5.BeginUpdate()
        GridView5.Columns.Clear()

        GridControl5.DataSource = dt

        GridView5.ClearSelection()
        GridControl5.EndUpdate()

        With GridView5
            .Columns("CreateDate").Visible = False

            .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
            .OptionsBehavior.Editable = False
            .OptionsBehavior.ReadOnly = True
            .OptionsCustomization.AllowColumnMoving = False
            .OptionsCustomization.AllowGroup = False
            .OptionsView.AllowCellMerge = False
            .OptionsSelection.MultiSelect = False
            .OptionsSelection.EnableAppearanceFocusedCell = False
            .OptionsView.ColumnAutoWidth = True
        End With

        GridView5.ClearSelection()
        GridControl5.EndUpdate()

    End Sub

    Private Sub ArchiveOrangeData()
        Try
            If MsgBox("Ցանկանում եք արխիվացնել տվյալները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            iDB.ArchiveGprsStatus()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'Print Data
    Private Sub PrintData(ByVal frm As Form, ByVal PType As PrintTypes)
        For Each frmCont As Control In frm.Controls
            If Not TypeOf (frmCont) Is DevExpress.XtraGrid.GridControl Then Continue For
            Dim gridCont As DevExpress.XtraGrid.GridControl = frmCont
            Select Case PType
                Case PrintTypes.Print
                    gridCont.Print()
                Case PrintTypes.PrintPreview
                    gridCont.ShowPrintPreview()
                Case PrintTypes.ShowSetup
                    gridCont.PrintDialog()
            End Select
        Next
    End Sub

    Private Sub DisableAll()
        'Ուղղորդիչ
        NavBarGroup1.Visible = False
        NavBarGroup2.Visible = False
        NavBarGroup3.Visible = False
        NavBarGroup5.Visible = False
        NavBarGroup6.Visible = False

        ''Հաղորդագրության պանել
        'PanelControl1.Visible = False

        ''Top Panel
        'RibbonPage5.Visible = False
        'RibbonPage4.Visible = False
        'RibbonPage3.Visible = False
        'RibbonPage2.Visible = False
        'RibbonPage1.Visible = False
        btnExcelToDB.Enabled = False
        btnCorrectDB.Enabled = False

        ''Top Menu
        'btnTitleAddRecord.Enabled = False
        'btnTitleUpdateRecord.Enabled = False
        'btnTitleExportToExcel.Enabled = False
        'btnTitleDeleteRecord.Enabled = False
        'btnTitlePrint.Enabled = False

        'File Menu
        tbUserPermissions.Enabled = False
        tbDeleteUser.Enabled = False
        tbChangeUser.Enabled = False
        tbNewUser.Enabled = False
        tbUserGroup.Enabled = False

    End Sub

    'Check Permissions
    Private Sub DisableComponents()
        Try
            Call DisableAll()

            'Բեռնել Ուղղորդիչի Իրավասությունները
            dtPermission_U = iDB.GetUsersPermissionsByGroupU(iUser.UserGroup)
            If dtPermission_U.Rows.Count > 0 Then
                For i As Integer = 0 To dtPermission_U.Rows.Count - 1
                    'Ուղղորդիչ root
                    If dtPermission_U.Rows(i)("GUID") = "BD4E48DEAFC54D59A196FCF02FBFF0B5" AndAlso dtPermission_U.Rows(i)("Allowed") = True Then NavBarGroup1.Visible = True
                    If dtPermission_U.Rows(i)("GUID") = "C772C0B9B67048C0A9D9D3EDE851181D" AndAlso dtPermission_U.Rows(i)("Allowed") = True Then NavBarGroup2.Visible = True
                    If dtPermission_U.Rows(i)("GUID") = "586F4B25D5D4452CA41DAE2D245F6A32" AndAlso dtPermission_U.Rows(i)("Allowed") = True Then NavBarGroup6.Visible = True
                    If dtPermission_U.Rows(i)("GUID") = "76826402301E48F195BE60646FBA404F" AndAlso dtPermission_U.Rows(i)("Allowed") = True Then NavBarGroup3.Visible = True
                    If dtPermission_U.Rows(i)("GUID") = "6A9FC4A7D6F6468F808ADF41D4D303C7" AndAlso dtPermission_U.Rows(i)("Allowed") = True Then NavBarGroup5.Visible = True

                    If dtPermission_U.Rows(i)("GUID") = "6A9FC4A7D6F6468F808ADF41D4D303C7" AndAlso dtPermission_U.Rows(i)("Allowed") = True Then CallPanel.Visibility = DockVisibility.Visible

                    ActionTreeList.FilterNodes()
                    WareHouseTreeList.FilterNodes()
                    RepTreeList.FilterNodes()
                    AcountTreeList.FilterNodes()
                    CallCenterTreeList.FilterNodes()

                Next
            End If

            'Բեռնել Պատուհանները
            dtPermission_W = iDB.GetUsersPermissionsByGroupW(iUser.UserGroup)
            If dtPermission_W.Rows.Count > 0 Then
                For i As Integer = 0 To dtPermission_W.Rows.Count - 1
                    If dtPermission_W.Rows(i)("GUID") = "3E1644EFE38E4B2DAD5483FAE287D6C0" AndAlso dtPermission_W.Rows(i)("Allowed") = True Then tbUserGroup.Enabled = True
                    If dtPermission_W.Rows(i)("GUID") = "C37691DD1DA641FC810B8CAD0ED83CBC" AndAlso dtPermission_W.Rows(i)("Allowed") = True Then tbNewUser.Enabled = True
                    If dtPermission_W.Rows(i)("GUID") = "1B7D266F80D34DE29B30CBCFAA6AE0AB" AndAlso dtPermission_W.Rows(i)("Allowed") = True Then tbChangeUser.Enabled = True
                    If dtPermission_W.Rows(i)("GUID") = "BD6E285E45ED4A628FD167778E4AD894" AndAlso dtPermission_W.Rows(i)("Allowed") = True Then tbDeleteUser.Enabled = True
                    If dtPermission_W.Rows(i)("GUID") = "DBDEB8BEF09040F499DE80676E27465C" AndAlso dtPermission_W.Rows(i)("Allowed") = True Then tbUserPermissions.Enabled = True
                    If dtPermission_W.Rows(i)("GUID") = "2F4789C139FB448F89CA13B9738B06E1" AndAlso dtPermission_W.Rows(i)("Allowed") = True Then btnExcelToDB.Enabled = True
                    If dtPermission_W.Rows(i)("GUID") = "E2E8DBFB0A584BE7A9CF990F681A6FE6" AndAlso dtPermission_W.Rows(i)("Allowed") = True Then btnCorrectDB.Enabled = True
                Next
            End If

        Catch ex As Exception
            Call DisableAll()
        End Try
    End Sub

    ' Permissions
    Private Sub btnLoadPerm_Click(sender As Object, e As EventArgs) Handles btnLoadPerm.Click
        Try
            If CheckPermission2("DBDEB8BEF09040F499DE80676E27465C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            permGroup.Enabled = False
            typePermissions.Enabled = False
            btnLoadPerm.Enabled = False
            btnChangePermissions.Enabled = True

            'Load Permission
            Dim dt2 As DataTable

            Dim UList As New List(Of UPermissions)

            If typePermissions.SelectedIndex = 0 Then
                dt2 = iDB.GetUsersPermissionsByGroupU(permGroup.SelectedValue)

                With UList
                    'Ընդհանուր
                    .Add(New UPermissions("BD4E48DEAFC54D59A196FCF02FBFF0B5", "Ընդհանուր", False))

                    .Add(New UPermissions("A194D6BC9F564D1BAA3ECEBF56EAAD5D", "     Տեղեկատուներ", False))
                    .Add(New UPermissions("8149E1D04AFE4C43A1A81B2B27E965DF", "             Տեսուչներ", False))
                    .Add(New UPermissions("ABDAE1F9E6884908B840BA2C4B0F3817", "             Տեսուչ Շրջան", False))
                    .Add(New UPermissions("BD9204E949E24ACB9BB691F070953385", "             Տեսուչի ՀԴՄ-ներ", False))
                    .Add(New UPermissions("0387762D7054418BB2C7212DBFC53648", "             Տարածաշրջան", False))
                    .Add(New UPermissions("529F861E78684EBE9EE09DC4E5B89F6A", "             Պայմանագիր", False))
                    .Add(New UPermissions("9D95E8A0A5EF4BF7ABD3D271CC34566D", "             Հասցե", False))
                    .Add(New UPermissions("6E7F85D395994B5789C1651A76E1F287", "             Օբյեկտի տեսակ", False))
                    .Add(New UPermissions("1C859E9CBE9F4406A01CE38A2EEF3DF4", "             ՏՀՏ", False))
                    .Add(New UPermissions("77B200BBD84F4DADB4FFFDA4377B035C", "             Տարիֆներ", False))

                    .Add(New UPermissions("D27CC6444B21482C81A87AB79ACD3CDF", "     ՀԴՄ Առաքում", False))
                    .Add(New UPermissions("874DF27A12054E17A5B6DB8D8AC750FE", "             ՀԴՄ Առաքում", False))
                    .Add(New UPermissions("2B6B1113D956414796E53F2A1647A56A", "             ՀԴՄ Ճանապարհին", False))
                    .Add(New UPermissions("45BBCE23E1E446C69CE00AEDF5BC4B44", "             ՀԴՄ Վերանորոգման Մեջ", False))
                    .Add(New UPermissions("DCBD85BE9F6A43159F68B64B72222F33", "             ՀԴՄ Ուղարկման Ենթակա", False))
                    .Add(New UPermissions("0FE2E3E794CE438681BE8267F0B7F410", "             ՀԴՄ Ուղարկված", False))

                    .Add(New UPermissions("05FB334E5AF84A908C864F2CA9413B29", "     Պայմանագիր", False))
                    .Add(New UPermissions("99E1C38807234D36A30F7148BA074DB2", "             ՊՈԱԿ բազա (ավելացման ենթակա)", False))
                    .Add(New UPermissions("9360823FDE4746A294FBF349759BFEC0", "             ՊՈԱԿ բազա (վերագրանցման ենթակա)", False))
                    .Add(New UPermissions("9132657EF0A045FF80433E6E0DC3E9ED", "             ՊՈԱԿ բազա (ՄԳՀ տարբերություն)", False))
                    .Add(New UPermissions("70326A9271804018A5F894A7117817F3", "             Բազա-ՊՈԱԿ Համեմատում", False))
                    .Add(New UPermissions("282DB48D53424BF4AF73481CE093B3C9", "             Պայմ քանակի համեմատում", False))
                    .Add(New UPermissions("22171AEB3646406691BC382AB49AC145", "             Տպված պայմ հավելված", False))
                    .Add(New UPermissions("B2F89BF559744C1D95F8A47996A3D350", "             Չտպված Հավելվածներ", False))
                    .Add(New UPermissions("B2F89BF559744C1D95F8A47996A3D359", "             Գործընկերոջ Կարգավիճակի Փոփոխություն", False))

                    .Add(New UPermissions("B3BD5DB582574469A049C9C2B57F33B0", "     Արգելափակել ՀԴՄ-GPRS", False))
                    .Add(New UPermissions("34BF90D3C1D84BB69586FFDA1FE389A4", "             GPRS Կասեցումից Ազատված", False))
                    .Add(New UPermissions("835C5DAD85F14F9192BE753F9F9D3134", "             Արգելափակել ՀԴՄ-GPRS", False))
                    .Add(New UPermissions("2BE4D16252A241E9BEBBC5BE6B46E37C", "             Արգելափակված ՀԴՄ-GPRS", False))
                    .Add(New UPermissions("B620D1EE214F4768AF96286F5CB3E281", "             Ուղարկել Նամակներ", False))
                    .Add(New UPermissions("4BF939352BB44D7A853D9CD7C4EA72AE", "             Ուղարկել SMS Հաճախորդներին", False))
                    .Add(New UPermissions("FFCB6B904E8E41939D2CCA5187B43AD9", "             Ուղարկել SMS Տեսուչներին", False))
                    .Add(New UPermissions("A982D7FBED2A45F2AE9CD2B57F6F8F44", "             Ուղարկել Անհատական SMS", False))
                    .Add(New UPermissions("2B6BAE83388B4C8AAC3FA07C0ABC5416", "             ՀՎՀՀ-ով SIM Արգելքի Հանում", False))

                    .Add(New UPermissions("7D1FC7CFFCF44A50BB3543F6021FCB4D", "     Գործընկերներ", False))
                    .Add(New UPermissions("AA7ABFF5766B46DFB03432178C0A22FB", "             Գործընկեր Փնտրում", False))
                    .Add(New UPermissions("A68E621DA9604C9A8F68EFAC7531774D", "             Գործընկերոջ Հուսալիություն", False))

                    .Add(New UPermissions("5BD10D090F7C454CB6E80A15474E81CE", "     ՀԴՄ-ներ", False))
                    .Add(New UPermissions("7C7D395B41B647E398D265A5B5E1AC20", "             ՀԴՄ Փնտրում", False))
                    .Add(New UPermissions("026606C89C9449DBBBB864007DF90C57", "             GPRS Քարտի Փոփոխում", False))
                    .Add(New UPermissions("79ED7339409148A49324712C84ED707E", "             Արգելափակված ՀԴՄ-GPRS", False))
                    .Add(New UPermissions("AB2A040842F441BB8A578C0F3C33A7EE", "             ՀԴՄ Կարգավիճակ ՊՈԱԿ-ում", False))
                    .Add(New UPermissions("858A3BDA099344B2812384918418B619", "             Երաշխիքային ՀԴՄ-ներ", False))
                    .Add(New UPermissions("032886C945DB4C958FF3EE3043E24840", "             Ոչ Երաշխիքային ՀԴՄ-ներ", False))

                    .Add(New UPermissions("5DCB4504BC0640EBBC37996DA9FAC4DE", "     Տեսուչի Այց", False))
                    .Add(New UPermissions("B3F5707273664E5CBEE4E710AD867D70", "             Տեսուչի Այց", False))

                    .Add(New UPermissions("0DA27756076844F79EB565F4C4D520B6", "     Վերանորոգում", False))
                    .Add(New UPermissions("13AF25BD34BA470688C5378C64D356E9", "             Վերանորոգման Հայտ", False))
                    .Add(New UPermissions("EE5A3A3242B24DD6915882185C604C79", "             Մուտք Սրահ *", False))
                    .Add(New UPermissions("815F5E89D1434871AB287276F07CB0C5", "             Մուտք Սրահ", False))
                    .Add(New UPermissions("BFC3B50AE7F84FDABEA6C2B3943F8844", "             Մուտք Արհեստանոց", False))
                    .Add(New UPermissions("54580B6EEC224AD3BA318F54720CF0E9", "             Մուտք Արհեստանոց *", False))
                    .Add(New UPermissions("3771982E439449E29027A84714962052", "             Ելք Արհեստանոցից *", False))
                    .Add(New UPermissions("CB67607887E84912A6D6751E71D73064", "             Ելք Արհեստանոցից", False))
                    .Add(New UPermissions("938E9275863E4AFFB634DFDA81EAD3E4", "             Ելք Սրահից", False))
                    .Add(New UPermissions("83C069B500D243A1837D67A6AF35AE66", "             Ելք Սրահից *", False))

                    .Add(New UPermissions("FA00CA307CB04DAB8FF935026D0D5266", "     Արհեստանոց", False))
                    .Add(New UPermissions("B2924575445C43D7A15E3FD546FBF214", "             Արհեստանոցի Հայտ", False))

                    .Add(New UPermissions("78F8ED206D1044EEA1F461D7F231E345", "     GPRS", False))
                    .Add(New UPermissions("01F5295314404972B73AB8905D2DF7AE", "             Նոր Քարտ", False))
                    .Add(New UPermissions("3AA18BBFB06244C893F4F637E9B03B27", "             Ներբեռնել Excel-ից", False))
                    .Add(New UPermissions("9D5A719035B341A083696B17E61D5627", "             Ջնջել GPRS-ը", False))
                    .Add(New UPermissions("6680F94061EE45969FD2A361A73A3469", "             Արխիվացնել Orange GPRS Հարցումները", False))

                    .Add(New UPermissions("B5D0A3F215A54CD6B54441149E5DBA54", "     Տարիֆ", False))
                    .Add(New UPermissions("39C84C2EB6C14990B74164C1A7D3A8AF", "             Փոխել Գործընկերոջ Տարիֆը", False))
                    .Add(New UPermissions("CDD8026AB52D4D80AC4331393DEF3A73", "             Գործընկերների Ընթացիկ Տարիֆ", False))
                    .Add(New UPermissions("AB0E3EB722B948D8AB84F1F32E42C960", "             Տարիֆի Պատմություն", False))
                    .Add(New UPermissions("DB24BF62FA9E4589BBCD8DD9AE3F358C", "             Փոփոխման Ենթակա Տարիֆներ", False))
                    .Add(New UPermissions("3164C25231034131AAAB2AE858FEBE61", "             Տարիֆ Ըստ ՊՈԱԿ-ի", False))
                    .Add(New UPermissions("B9AB14A979A54C5D8A5EE9679135C130", "             ՊՈԱԿ Տարիֆի Տարբերություն", False))
                    .Add(New UPermissions("3F3048CF83C0421D9FB08174FE163B03", "             Համեմատել ՊՈԱԿ Տարիֆը", False))

                    .Add(New UPermissions("9B9E041073E84DD5A3CCBAAF244CE10C", "     POS", False))
                    .Add(New UPermissions("57E6BB4B20B341EDA77D847BC5A0E824", "             Լիցենզիա", False))
                    .Add(New UPermissions("D47955C2018E4E6F837779CE26403838", "             Բանկեր", False))

                    .Add(New UPermissions("E28EDB75F4EF43C7885A3D5171A0563E", "     ՊՈԱԿ-ից Ստացված ՀԴՄ", False))
                    .Add(New UPermissions("2384E622118D4FF4AA680ADA98813BED", "             Ստացված ՀԴՄ-ներ", False))


                    'Պահեստ
                    .Add(New UPermissions("C772C0B9B67048C0A9D9D3EDE851181D", "Պահեստ", False))

                    .Add(New UPermissions("828F4D985AFF424CA5AA1ED340E86890", "     Տեղեկատուներ", False))
                    .Add(New UPermissions("7C876240F6444808BA08ADFBE4792549", "             Սարքավորումներ", False))
                    .Add(New UPermissions("2449D7F3E0BA478D8850ACFAF35AB8A9", "             Սարքավորման Արժեք Ըստ Տարիֆի", False))
                    .Add(New UPermissions("0D46642D5ACF49879D4534E0720DE7F1", "             Սարքավորման Հավելավճար", False))
                    .Add(New UPermissions("4546D4E245A04D3C9AD4C8BD42388E1A", "             Պահեստի Մուտք", False))

                    .Add(New UPermissions("5FC877D4E3C448F585EA96E4A17D776E", "     Հաշվետվություն", False))
                    .Add(New UPermissions("1AF301E3425B45AFBE386D84CFB322D6", "             Պահեստների Մնացորդ", False))
                    .Add(New UPermissions("D1A87BBEB2D64E278772A110027B2888", "             Մնացորդ", False))
                    .Add(New UPermissions("0E630C35D9E44090BB1276BF1FD98E57", "             Վաճառված Սարքավորումներ", False))
                    .Add(New UPermissions("CAA1473418BD4619B8CDE369582D10E4", "             ՊՈԱԿ Պահեստ", False))
                    .Add(New UPermissions("F7F641C78DC8438789F300134C6CCA3E", "             Խոտան Պահեստ", False))
                    .Add(New UPermissions("5985506B73B044B99B2636769D5C3B9E", "             Երկրորդային Պահեստի Մնացորդ", False))
                    .Add(New UPermissions("C746D1566F85420791E7DE8DBCC3A298", "             Երկրորդային Պահեստի Վաճառք", False))

                    .Add(New UPermissions("55136453C9EB486A88AA0ABEB3385B29", "     Վաճառք", False))
                    .Add(New UPermissions("D76E9B41BE4A4668B3BAEBBA56F4D1A8", "             Վաճառել Սարքավորում", False))
                    .Add(New UPermissions("B73E316484BA4E85BC42B80470444C0F", "             Վաճառքի Փոփոխում", False))
                    .Add(New UPermissions("D0E24A6DE55742BAB4C4558BEFEF6125", "             Վաճառքի Մերժում", False))

                    .Add(New UPermissions("7AE7A0F92D894D86A575D2F9D3388EF2", "     Պահեստի Շարժ", False))
                    .Add(New UPermissions("5556B31DA7F347D096612A365C4BDED6", "             Ներքին Տեղափոխում", False))
                    .Add(New UPermissions("3B5BEF3DC60A4B97A0704F3654BE1A24", "             Պահեստի Մուտքի Օրդեր", False))
                    .Add(New UPermissions("03025FE5C2124DB68CEF3EE2A85AF4CD", "             Նոր Շտրիխ Կոդ", False))
                    .Add(New UPermissions("E28CC06DE63D4F51974C43E844FB0116", "             Տեղափոխել Խոտան Պահեստ", False))
                    .Add(New UPermissions("F7233259C8D346769F6591B3C4236E55", "             Տեղափոխել ՊՈԱԿ Պահեստ", False))


                    'Հաշվետվություն
                    .Add(New UPermissions("586F4B25D5D4452CA41DAE2D245F6A32", "Հաշվետվություն", False))

                    .Add(New UPermissions("7D9271F2B3A847D99240727CEDF8B0AE", "     Սպասարկող", False))
                    .Add(New UPermissions("2AA5C17FC0B34B99AE14D5E24074D8E2", "             Կազմ-Տարած-ՀԴՄ Քանակ", False))

                    .Add(New UPermissions("703CF692319B42C5A51DC7B5F85C1897", "     Վճարներ", False))
                    .Add(New UPermissions("08358DB47FF7408E961CD5A355B307A4", "             Վճար", False))
                    .Add(New UPermissions("2B41752CCF84452883849C2081966F33", "             Բանկային Մուտքեր", False))
                    .Add(New UPermissions("9063A58CE5D746188F0BD79FEF0D6BDA", "             Պարտք - Հավելավճար", False))
                    .Add(New UPermissions("1F4806DC194945D79D94A9B4A539E974", "             Դեբետ - Կրեդետ", False))
                    .Add(New UPermissions("C7C0165590524194AB8D08728EB78277", "             Ամփոփ Հաշվետվություն", False))
                    .Add(New UPermissions("50B26A3947B840FABBE07887C513D0BC", "             Ամփոփ Հաշվետվություն 2", False))
                    .Add(New UPermissions("B3B2845E0C7E41289429E0DED01A7115", "             Պարտք Ըստ Պատկանելության", False))

                    .Add(New UPermissions("3EFA9FCAC2A34967A98FF11912F3D3FD", "     Վերանորոգում", False))
                    .Add(New UPermissions("A27B048D72CD4C1390644548AF1A590B", "             Քանակային Հաշվետվություն", False))
                    .Add(New UPermissions("836A24E21D744856BB5DB6FC99D24EF6", "             Տևողության Հաշվետվություն", False))
                    .Add(New UPermissions("369C21A89967410098B02A3888A2E902", "             Վերանորոգում", False))
                    .Add(New UPermissions("7138332DD73D4EAA9174AF2686AF1DDB", "             Կրկնվող Վերանորոգումներ", False))
                    .Add(New UPermissions("1D5C6256212441B7987CD23A4188ED05", "             Անվճար Վերանորոգումներ", False))
                    .Add(New UPermissions("45804AAD066F41EDA11596F174CFB645", "             ՀԴՄ-ի Տեղաշարժ", False))
                    .Add(New UPermissions("425E9D6AB3EA4D53851C201476E9D0D4", "             Ուղարկված SMS", False))
                    .Add(New UPermissions("0ECD563464CD4B888C41D763A4946F1B", "             Տեսուչի Վերանորոգումներ", False))

                    .Add(New UPermissions("8FB6C436B9C04FE0A2EFCD1B19FC4AE9", "     ՀԾ", False))
                    .Add(New UPermissions("7E8913E5FD8E44AE98BDD985E1C09108", "             ՀԾ Կոդի Փոփոխում", False))

                    .Add(New UPermissions("0DBA41D66709429CB8A3F92BD575A8A5", "     Փոխարինման ՀԴՄ-ներ", False))
                    .Add(New UPermissions("1B66DF9072E24788BFF9EF9E958375F4", "             Փոխարինման ՀԴՄ-ներ", False))
                    .Add(New UPermissions("533EB9CF2A4245308B39970D1F7DFF45", "             Պատկան ՀԴՄ-ներ Սրահում", False))
                    .Add(New UPermissions("4B2C0338E1344F169226903BA35066F0", "             ՀԴՄ Փոխարինման Պատմություն", False))
                    .Add(New UPermissions("2CA29F587BE640C0A20DC88744434FB5", "             Առանց Հայտի Փոխարինող ՀԴՄ", False))
                    .Add(New UPermissions("3AF665F049BF4DDFBA8ADEF761A09AE9", "             Փոխարինող ՀԴՄ Տարբերություն", False))

                    .Add(New UPermissions("665E46AFADB243498B2FF7FF91C0C0D4", "     Հաշիվ Ապրանքագիր", False))
                    .Add(New UPermissions("6AA8A0652A1344879939250A7BEBC6DA", "             Չվերադարձված", False))
                    .Add(New UPermissions("FC47803AE0564BEE85ACCBC357B529A0", "             Սպասարկման", False))
                    .Add(New UPermissions("005AACC528CD4F9283197F32353598C3", "             Վերանորոգման", False))
                    .Add(New UPermissions("3F26A0773F704D759A5598290A117AAC", "             Վաճառքի", False))
                    .Add(New UPermissions("95408598AF9D4A61B4A27676A4D89B7B", "             Շրջիկ", False))
                    .Add(New UPermissions("B95650760F5448CAB08A9826758AF2A9", "             Բոլորը", False))

                    .Add(New UPermissions("83D37C49FBF44785AB03B5F66D511A9B", "     Տեսուչ", False))
                    .Add(New UPermissions("FC62466D41E4489FB7C82F4B0E02C94E", "             Տեսուչի Այցելություն", False))
                    .Add(New UPermissions("F9C28B294BF1441791B97C900F6D87DA", "             Տեսուչի ՀԴՄ", False))

                    .Add(New UPermissions("2180B782C37D420FAE8AA615452CF04B", "     Վերագրանցում", False))
                    .Add(New UPermissions("EDE760A952904A9AB172EDD453156D9E", "             Վերագրանցում", False))

                    .Add(New UPermissions("43551208FDEA49CBA03C44092DD0E4EB", "     Արգելափակ GPRS", False))
                    .Add(New UPermissions("D34DA4157C9740AA9B6704A04FF70089", "             Արգելափակված GPRS", False))
                    .Add(New UPermissions("8E290AA416B845199ED0AF5C688DA85B", "             Արգելափակման Ենթակա", False))

                    .Add(New UPermissions("C62D34DA49B2443786CBF9247882D088", "     Նամակներ և SMS", False))
                    .Add(New UPermissions("46BA851D87504C828B3B4EDDF8D8A7FD", "             Ուղարկված Նամակներ", False))
                    .Add(New UPermissions("69E2706305F04A22A49C6493EB2D7BDC", "             Ուղարկված SMS-ներ", False))

                    .Add(New UPermissions("460C7D18289C47E583DD616D9ED84DCE", "     GPRS", False))
                    .Add(New UPermissions("9A6184827F5F4E71B7EFE6402EEC69B7", "             GPRS-ի Փոփոխություն", False))
                    .Add(New UPermissions("EDE07C814F47407EB047A801FDD0281A", "             Առկա GPRS Քարտեր", False))
                    .Add(New UPermissions("50EE720F5E6D4AD7814C4B248FAF9258", "             Ավելացված Բայց Չհաստատված Քարտ", False))
                    .Add(New UPermissions("AF226D727A014AFDB0A989A6D4221FE9", "             Orange Ընթացիկ Կարգավիճակներ", False))
                    .Add(New UPermissions("47C4D84727584F5FA56B98628B51E8D9", "             GPRS Իրական Կարգավիճակ", False))

                    .Add(New UPermissions("4A3FEE2B11744F3DB5F880306134097E", "     ՀԴՄ Վիճակագրություն", False))
                    .Add(New UPermissions("404DD8C088524055A1D05773C54FD392", "             ՀԴՄ Վիճակագրություն", False))

                    .Add(New UPermissions("E68691CC6D4E468298E068ADD19493C2", "     Հեռախոս", False))
                    .Add(New UPermissions("8EF42EBB58354287A7F64754DA2E63C9", "             Հաճախորդի Հեռախոս", False))

                    .Add(New UPermissions("847FF70170C34BD78695A3C061309C9B", "     Լոգ", False))
                    .Add(New UPermissions("531A3E214F804CCCA0928A6FB5F5234C", "             TelCell Events", False))
                    .Add(New UPermissions("D5622632FACA4149B9ED825B0D96FB81", "             TelCell Payments", False))
                    .Add(New UPermissions("F2E1BB0353E9449EB2CA2DA219EFC9C4", "             Orange Events", False))

                    .Add(New UPermissions("8B776FB0E9774AFA8F5198A075DF99A3", "     Կոորդինատներ", False))
                    .Add(New UPermissions("86039A7E2D6F4E4F9E5B379523219E4D", "             Հայտեր", False))

                    .Add(New UPermissions("E5A6DFF201964911B2F755C3EBA12364", "     Տեսուչ ՀԴՄ Վիճակագրություն", False))
                    .Add(New UPermissions("7094CBEF500943A5926699F1725D4A70", "             Տեսուչ ՀԴՄ Հաշվետվություն", False))

                    'Հաշվապահություն
                    .Add(New UPermissions("76826402301E48F195BE60646FBA404F", "Հաշվապահություն", False))

                    .Add(New UPermissions("A6199B2FEAC74FB99FE7220EE41AA889", "     Վճարներ", False))
                    .Add(New UPermissions("F1FD2572CEF74F86A4A3F93C84BDD69C", "             Վճարների մուտքագրում", False))
                    .Add(New UPermissions("FB41CB18707F4A63BC498DCB036B3BF0", "             Բանկային տվյալների ստուգում", False))
                    .Add(New UPermissions("80C5DB191AEB4C52929E92832780E348", "             TelCell Վճարների Հաստատում", False))

                    .Add(New UPermissions("6A216A4399DE415298145FC5919CC370", "     Հաշիվ Ապրանքագիր", False))
                    .Add(New UPermissions("3E8324A0307B4B73A50C8F0A4C40CDFD", "             Սպասարկման Հ/Ա", False))
                    .Add(New UPermissions("DC565D749ADF4CEF93382AE8FA73AAC1", "                     Ընթացիկ Հ/Ա", False))
                    .Add(New UPermissions("BCAEB19836BB47C18D05F6294BC11E22", "                     Սպասարկման Հ/Ա", False))
                    .Add(New UPermissions("27D4F96EF7CD46D8BDFE1196E51F526B", "                     Սպասարկման Հ/Ա Շրջիկ", False))
                    .Add(New UPermissions("598734DB5B89437C87E9E495CACBE251", "                     Փոխել Հ/Ա Տվյալները", False))
                    .Add(New UPermissions("BC4A475917A74FC3802FF4F98A267C23", "                     Ջնջել Սպասարկման Հ/Ա", False))
                    .Add(New UPermissions("EC3C09F1DF1E4F7D83F85E2F7D05C907", "                     Չտպված Սպասարկման Հ/Ա", False))
                    .Add(New UPermissions("C7AAB12B501E497EB1AC79C358FE2660", "                     Չտպված Հավելվածներ", False))
                    .Add(New UPermissions("6A6270584F664A9AB901D02807DE63CB", "                     Տպված Սպասարկման Հ/Ա", False))
                    .Add(New UPermissions("6A6270584F664A9AB901D02807DE9999", "                     Հ/Ա Վերադարձ", False))
                    .Add(New UPermissions("7420E10B18DC45BB907D9DB8D7181CE5", "             Սարքավորման Վաճառքի Հ/Ա", False))
                    .Add(New UPermissions("F43C45EA9D1C4C88A3DCD6655DC2F117", "                     Գեներացնել Ներքին Ինվոյս (XML)", False))
                    .Add(New UPermissions("611231905EAE40A583B7057B4181B442", "                     Գեներացնել Սարքավորման Ինվոյս (XML)", False))
                    .Add(New UPermissions("6FA14DC18E2E425CA8DE7F34AC72EA9B", "                     Գեներացնել Վաճառքի Ինվոյս (XML)", False))

                    .Add(New UPermissions("E0441A10036D48088995B1F9F83F5E79", "     Տեղեկատուներ", False))
                    .Add(New UPermissions("60FE011E74B54CCF93982D0EEEC5CAE7", "             ԱԱՀ-ից Ազատված Գործընկեր", False))
                    .Add(New UPermissions("4381A79A288A43C3B008C8C4A71E8A8B", "             Չսպասարկվող Գործընկեր", False))
                    .Add(New UPermissions("E66BC93651694F07B50CA9E5B2608050", "             PDF-ով Չտպվող", False))
                    .Add(New UPermissions("2C720AFD51BA4578B8E7D0AD28689485", "             Հ/Ա PDF-ի Կարգաբերում", False))
                    .Add(New UPermissions("C565D69E31B9484F8B5BE430E97FD95E", "             PDF-Ի Էջերի Ստացում", False))
                    .Add(New UPermissions("6F2C3728C7344E15ACCD2AFD7167A065", "             Պահեստի Մնացորդ", False))
                    .Add(New UPermissions("FD2DDCCE0ECB4F63B209085070F2A32B", "             XML - ՀՎՀՀ Ստուգում", False))
                    .Add(New UPermissions("209045D6E2444F50A4D2F01226F5B625", "             Պահանջագրեր", False))

                    'Զանգերի Կենտրոն
                    .Add(New UPermissions("6A9FC4A7D6F6468F808ADF41D4D303C7", "Զանգերի Կենտրոն", False))

                    .Add(New UPermissions("7B7AEEB35F4F4BF7A4D069A8BCD865B0", "     Հայտեր", False))
                    .Add(New UPermissions("868D1C12CC42465BA7DCAE2B279CD58F", "             Ակտիվացման Հայտ", False))
                    .Add(New UPermissions("3B90FF27CB3F484493120D340DC196C7", "             Ընդհանուր Հայտ", False))
                    .Add(New UPermissions("E4060F573FE342B496EC629A3E7FCD33", "             Խմբագրել Ակտիվացման Հայտերը", False))
                    .Add(New UPermissions("7D0D71A6422748108546B1AEB559B2F7", "             Խմբագրել Ընդհանուր Հայտերը", False))
                    .Add(New UPermissions("A2ADDECDE9034B91A442C5707C428D20", "             Դիտել Ակտիվացման Հայտերը", False))
                    .Add(New UPermissions("77AECB3F04294AD499F19BE5CA500ECB", "             Դիտել Ընդհանուր Հայտերը", False))
                    .Add(New UPermissions("DFF9FC21F14049A6BAF6EF28CD3D407C", "             Ուղրկել Անհատական SMS", False))
                    .Add(New UPermissions("8F4410403E1840749FF38A9432E52718", "             Փակ Հայտեր", False))
                    .Add(New UPermissions("A944BA07C90846CF89FE2CB08C2AF7AC", "             Բաց Հայտեր", False))
                    .Add(New UPermissions("6E2805538310451AB4DEBE862115E6A5", "             Հայտի Վերլուծություն", False))

                End With


            ElseIf typePermissions.SelectedIndex = 1 Then

                dt2 = iDB.GetUsersPermissionsByGroupW(permGroup.SelectedValue)

                With UList

                    'Գլխավոր Պատուհան
                    .Add(New UPermissions("3E1644EFE38E4B2DAD5483FAE287D6C0", "Գլխավոր Պատուհան     |       Խմբեր", False))
                    .Add(New UPermissions("C37691DD1DA641FC810B8CAD0ED83CBC", "Գլխավոր Պատուհան     |       Նոր Օգտվող", False))
                    .Add(New UPermissions("1B7D266F80D34DE29B30CBCFAA6AE0AB", "Գլխավոր Պատուհան     |       Փոխել Օգտվողի Տվյալները", False))
                    .Add(New UPermissions("BD6E285E45ED4A628FD167778E4AD894", "Գլխավոր Պատուհան     |       Ջնջել Օգտվողին", False))
                    .Add(New UPermissions("DBDEB8BEF09040F499DE80676E27465C", "Գլխավոր Պատուհան     |       Օգտվողի Իրավասություններ", False))
                    .Add(New UPermissions("2F4789C139FB448F89CA13B9738B06E1", "Գլխավոր Պատուհան     |       Excel To DB", False))
                    .Add(New UPermissions("E2E8DBFB0A584BE7A9CF990F681A6FE6", "Գլխավոր Պատուհան     |       Correct DB", False))


                    'Ընդհանուր
                    .Add(New UPermissions("BD568238374E4D8A97D9A14D324617FB", "Ընդհանուր	|	Տեղեկատու	|	Տեսուչ	|		Ավելացնել Գրանցում", False))
                    .Add(New UPermissions("E919DC592EEB4510945EB8DEB17AD02B", "Ընդհանուր	|	Տեղեկատու	|	Տեսուչ	|		Փոխել Գրանցումը", False))
                    .Add(New UPermissions("E86069B4B73148D28D20018112A5DB06", "Ընդհանուր	|	Տեղեկատու	|	Տեսուչ	|		Տարածաշրջանի Փոխում", False))
                    .Add(New UPermissions("77803C0C9ABE4AC4A34F74F6193E9C05", "Ընդհանուր	|	Տեղեկատու	|	Տեսուչ	|		Ջնջել", False))

                    .Add(New UPermissions("4151D69E28B44B2EBBEEBAED5E5019BC", "Ընդհանուր	|	Տեղեկատու	|	Տեսուչ-Ինֆո	|		Ավելացնել Գրանցում", False))
                    .Add(New UPermissions("609D86A8A7714DC2959C1581AD7C6E70", "Ընդհանուր	|	Տեղեկատու	|	Տեսուչ-Ինֆո	|		Ջնջել", False))

                    .Add(New UPermissions("67EA526006FA4A9D90D7C66E579B193F", "Ընդհանուր	|	Տեղեկատու	|	Տարածաշրջան	|		Ավելացնել Գրանցում", False))
                    .Add(New UPermissions("95CBC22E2E184603B7E5B35E060F704C", "Ընդհանուր	|	Տեղեկատու	|	Տարածաշրջան	|		Փոխել Գրանցումը", False))
                    .Add(New UPermissions("4C74AA84EFCD4F4F83325A71D2F7DE3A", "Ընդհանուր	|	Տեղեկատու	|	Տարածաշրջան	|		Ջնջել Գրանցումը", False))

                    .Add(New UPermissions("678D4EFE0BC14E86AEA85A4F91CC9873", "Ընդհանուր	|	Տեղեկատու	|	Պայմանագիր	|		Ավելացնել Գրանցում", False))
                    .Add(New UPermissions("B3FCE0E5A3DD441E9FAF16F9380F1C70", "Ընդհանուր	|	Տեղեկատու	|	Պայմանագիր	|		Փոխել Գրանցումը", False))
                    .Add(New UPermissions("CFD82C464032408EBDD7E18ACD3CF40A", "Ընդհանուր	|	Տեղեկատու	|	Պայմանագիր	|		Ջնջել Գրանցումը", False))

                    .Add(New UPermissions("B8D325527E5D4622A52645B43E828DCF", "Ընդհանուր	|	Տեղեկատու	|	Հասցե	|		Ավելացնել Գրանցում", False))
                    .Add(New UPermissions("B53CDA91E1D14CCFB18C776CA83DB4AE", "Ընդհանուր	|	Տեղեկատու	|	Հասցե	|		Փոխել Գրանցումը", False))
                    .Add(New UPermissions("49A3BF48B6034F32B667D67D3F598C53", "Ընդհանուր	|	Տեղեկատու	|	Հասցե	|		Ջնջել Գրանցումը", False))

                    .Add(New UPermissions("2580D19B7939458B8DC2FF6CFD03793D", "Ընդհանուր	|	Տեղեկատու	|	Օբյետկտի Տեսակ	|		Ավելացնել Գրանցում", False))
                    .Add(New UPermissions("6718209F95A24F7CB435022C55171DCA", "Ընդհանուր	|	Տեղեկատու	|	Օբյետկտի Տեսակ	|		Փոխել Գրանցումը", False))
                    .Add(New UPermissions("D26EAF5A50D44CB4A8FE36BE0A87538C", "Ընդհանուր	|	Տեղեկատու	|	Օբյետկտի Տեսակ	|		Ջնջել Գրանցումը", False))

                    .Add(New UPermissions("9592D180CB6745D19EFA0A902E0AA2C7", "Ընդհանուր	|	Տեղեկատու	|	ՏՀՏ	|		Ավելացնել Գրանցում", False))
                    .Add(New UPermissions("B8768B11FFB74F118EF8933B09B6B5AE", "Ընդհանուր	|	Տեղեկատու	|	ՏՀՏ	|		Փոխել Գրանցումը", False))
                    .Add(New UPermissions("8265EC1DD233463B80BC078807854C6F", "Ընդհանուր	|	Տեղեկատու	|	ՏՀՏ	|		Ջնջել Գրանցումը", False))

                    .Add(New UPermissions("2F5A0D5661F24141BEE15CCF65EA1609", "Ընդհանուր	|	Տեղեկատու	|	Տարիֆ	|		Ավելացնել Գրանցում", False))
                    .Add(New UPermissions("B5F45B13B1D7465E933A4C58C2D9E782", "Ընդհանուր	|	Տեղեկատու	|	Տարիֆ	|		Փոխել Գրանցումը", False))
                    .Add(New UPermissions("29A2756F38F0445DAA597C39304B9311", "Ընդհանուր	|	Տեղեկատու	|	Տարիֆ	|		Սարքավորման Արժեք Ըստ Տարիֆի", False))
                    .Add(New UPermissions("92553042666C4450ADD631180948842E", "Ընդհանուր	|	Տեղեկատու	|	Տարիֆ	|		Ջնջել Գրանցումը", False))

                    .Add(New UPermissions("C5F1E5A8856B44F5A706CE1C3E9A16E7", "Ընդհանուր	|	ՀԴՄ Առաքում	|	ՀԴՄ Առաքում	|		Ավելացնել Գրանցում", False))
                    .Add(New UPermissions("C6A262119E474BC99055030EBDF0A937", "Ընդհանուր	|	ՀԴՄ Առաքում	|	ՀԴՄ Առաքում	|		Ջնջել Գրանցումը", False))

                    .Add(New UPermissions("7B4C723DAAFE4323ACF5E4255E5AFF22", "Ընդհանուր	|	ՀԴՄ Առաքում	|	ՀԴՄ Ճանապարհին	|		Ջնջել Գրանցումը", False))

                    .Add(New UPermissions("10CCEA8E6A2E423B9C83837B3303AB47", "Ընդհանուր	|	ՀԴՄ Առաքում	|	ՀԴՄ Ուղարկման Ենթակա	|		Փակել", False))

                    .Add(New UPermissions("E1FBBF9C210F4D879A0AB84A34B2938A", "Ընդհանուր	|	Պայմանագիր	|	Պայմանագրի Քանակի Համեմատում		|		Ցուցադրել", False))
                    .Add(New UPermissions("7A8CFFB6836B426293C5FB2644BC97CF", "Ընդհանուր	|	Պայմանագիր	|	Պայմանագրի Քանակի Համեմատում		|		Պայմանագրի Փոփոխություն", False))
                    .Add(New UPermissions("640095A73885452F8CFE18845E185C2A", "Ընդհանուր	|	Պայմանագիր	|	Պայմանագրի Քանակի Համեմատում		|		Պայմանագրի Լուծարում", False))

                    .Add(New UPermissions("54A93E86937D431783BAD4BE504FB08D", "Ընդհանուր	|	Պայմանագիր	|	Տպված Պայմանագրի Հավելվածներ		|		Ցուցադրել Հավելվածները", False))
                    .Add(New UPermissions("E38A3540CC264D5D8ED54497C7EF9D80", "Ընդհանուր	|	Պայմանագիր	|	Պայմանագրի Քանակի Համեմատում		|		Լուծարումներ", False))
                    .Add(New UPermissions("25C3CE752BFD46918CB544BB09F86607", "Ընդհանուր	|	Պայմանագիր	|	Պայմանագրի Քանակի Համեմատում		|		Հաստատել Վերադարձված", False))

                    .Add(New UPermissions("7E29171B27024512B598205F7E02E967", "Ընդհանուր	|	Պայմանագիր	|	Տպված Լուծարումներ		|		Ցուցադրել", False))
                    .Add(New UPermissions("50F3956FEEAA4126B90AD74620D7E7C7", "Ընդհանուր	|	Պայմանագիր	|	Տպված Լուծարումներ		|		Հաստատել Վերադարձված", False))

                    .Add(New UPermissions("697990D05D50418FAC9F1ACE37E53861", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	GPRS Կասեցումից Ազատված		|		Ավելացնել", False))
                    .Add(New UPermissions("807CDBD2B1144B24B184A68DCEEC1C6E", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	GPRS Կասեցումից Ազատված		|		Ջնջել", False))

                    .Add(New UPermissions("5FEBB5B724724CCB9C3A0008F767FF92", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակել ՀԴՄ		|		Բեռնել", False))
                    .Add(New UPermissions("03FB4C1D0C38455888BA3C9EB855DAFE", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակել ՀԴՄ		|		Հետնշել ՀՎՀՀ-ները", False))
                    .Add(New UPermissions("EF20FA750D294E2DBB3A9A34F78130A9", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակել ՀԴՄ		|		Հետնշել Premium-ները", False))
                    .Add(New UPermissions("47DBC27B53144432869AD6466C8996E0", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակել ՀԴՄ		|		Orange Ընթացիկ", False))
                    .Add(New UPermissions("A8AE74BB409F4309898DF07BEB084BF5", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակել ՀԴՄ		|		Նախապատրաստել Նամակ", False))
                    .Add(New UPermissions("EE4F139B2D444A3A8F03BAE87CA7C600", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակել ՀԴՄ		|		Արգելափակել Նշվածները", False))

                    .Add(New UPermissions("034EDB8971C9429999F952861E76D79F", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակված ՀԴՄ		|		Բեռնել", False))
                    .Add(New UPermissions("7BCBDF99371C4FBAAA2AC3AF5AC2C5AB", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակված ՀԴՄ		|		Հետնշել ՀՎՀՀ-ները", False))
                    .Add(New UPermissions("175F430B0B9C41BF924FD6CE15BDC3F1", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակված ՀԴՄ		|		Նշել Ակտիվացման SIM-երը", False))
                    .Add(New UPermissions("C1255ADFDDA941219202C5B46553DDD4", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակված ՀԴՄ		|		Ջնջել Ակտիվացման SIM-երը", False))
                    .Add(New UPermissions("A4B2F098385E4F7EAF2DA5C7D8A168AC", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակված ՀԴՄ		|		Orange Ընթացիկ", False))
                    .Add(New UPermissions("2C46B9F1398F440D9FA377DE8F5C1239", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակված ՀԴՄ		|		Նախապատրաստել Նամակ", False))
                    .Add(New UPermissions("35AD99B4836744A1B4E15A14A57AC2CA", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակված ՀԴՄ		|		Հանել Նշվածների Արգելքը", False))
                    .Add(New UPermissions("AD9777798F7749C09B35549E885BFF7D", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Արգելափակված ՀԴՄ		|		Հանել Բոլորի Արգելքը", False))

                    .Add(New UPermissions("93FC9F4A05794DF8B85B1E3BB89978B1", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Ուղարկել Նամակ		|		Ուղարկել Նամակ", False))
                    .Add(New UPermissions("F4E37079D2D144B9BE8EFB8FA15AFCCF", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Ուղարկել Նամակ		|		Ջնջել", False))

                    .Add(New UPermissions("55D16461C7BB41FCB969D1A0D7879374", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Ուղարկել SMS Հաճախորդներին		|		Բեռնել", False))
                    .Add(New UPermissions("272792D12BD14C8B8FFD879DD9BC0FEC", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Ուղարկել SMS Հաճախորդներին		|		Ուղարկել SMS", False))

                    .Add(New UPermissions("7C32C68E59564117A87AE9D7CF3CDA79", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Ուղարկել SMS Տեսուչներին		|		Բեռնել", False))
                    .Add(New UPermissions("8863423DCD814401BA96F2C1F96A4D84", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Ուղարկել SMS Տեսուչներին		|		Ուղարկել SMS", False))

                    .Add(New UPermissions("853052F65B214C0F8F8B43B079046616", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Ուղարկել Անհատական SMS		|		Բեռնել", False))
                    .Add(New UPermissions("56783F618D244AF793667F3FB6EE2BE0", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Ուղարկել Անհատական SMS		|		ՀՎՀՀ Ֆիլտր Excel-ից", False))
                    .Add(New UPermissions("99FBC12EFABC47A38442BFB53241FA1D", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	Ուղարկել Անհատական SMS		|		Ուղարկել SMS", False))

                    .Add(New UPermissions("11CF2865B05F46BB962B1DD5B5C50C00", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	SIM Արգելքի Հանում ՀՎՀՀ-ով		|		Ավելացնել", False))
                    .Add(New UPermissions("E6F6B2A703534EFF8D06B67725FE6427", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	SIM Արգելքի Հանում ՀՎՀՀ-ով		|		Բեռնել", False))
                    .Add(New UPermissions("F28456D4C8854FC0939B0BD671A31440", "Ընդհանուր	|	Արգելափակել ՀԴՄ-GPRS	|	SIM Արգելքի Հանում ՀՎՀՀ-ով		|		Ջնջել", False))

                    .Add(New UPermissions("C00331E232734333BD1F2CE650B08998", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		Վերանորոգման ՀԴՄ", False))
                    .Add(New UPermissions("6EF3A5A4654C434996F553FDFC5DD993", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		ՀԾ Կոդի Փոփոխություն", False))
                    .Add(New UPermissions("A6DAD61B2BB24175BE74FF6D7D5697B4", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		Արգելափակված ՀԴՄ-ներ", False))
                    .Add(New UPermissions("BF69F42B4E464AACB129203B4EF59B9F", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		Փոխարինող ՀԴՄ-ներ", False))
                    .Add(New UPermissions("6F0FFD8B46824D4D86E4DF9077A5C815", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		Բոլոր ՀԴՄ-ները", False))
                    .Add(New UPermissions("1028600DD2514347BA35F4D7BCA174E4", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		Վճարումներ", False))
                    .Add(New UPermissions("A0D98DB3084A4FF9AEDAEBFD5E70FF93", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		ՀԴՄ Քանակ Ըստ Պայմանագրի", False))
                    .Add(New UPermissions("E693D414793945C6968068E1E2DF48A0", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		Ավելացնել Գործընկեր", False))
                    .Add(New UPermissions("5B9BFC20A0DB4BA0806322433BCFE5BE", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		Խմբագրել Տվյալները", False))
                    .Add(New UPermissions("21400CA4C27840C1BB7597E1DA35FFE1", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		Ավելացնել Վճար", False))
                    .Add(New UPermissions("8F79ED4715F14572A323B12F21AF3C25", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		Բեռնել Բոլոր Տվյալները", False))
                    .Add(New UPermissions("F61FFC81DA7D4EBA8ABCC93D480B3337", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		GPRS Կասեցում/Ակտիվացում", False))
                    .Add(New UPermissions("B52293885D4340349183DB2004B04F1E", "Ընդհանուր	|	Գործընկեր	|	Գործընկեր Փնտրում		|		Տեղադրել ՀԴՄ-ի GPS Կոորդինատները", False))

                    .Add(New UPermissions("44A3B1E03A414AEF91DFA84DCDEB350B", "Ընդհանուր	|	Գործընկեր	|	ՀԴՆ Քանակ Ըստ Պայմանագրի		|		Ավելացնել", False))
                    .Add(New UPermissions("3EDFD0242A1149FB92066739FAB9CC6F", "Ընդհանուր	|	Գործընկեր	|	ՀԴՆ Քանակ Ըստ Պայմանագրի		|		Փոխել Տվյալները", False))
                    .Add(New UPermissions("06B7FDDD731849B9905F0056697C4EC5", "Ընդհանուր	|	Գործընկեր	|	ՀԴՆ Քանակ Ըստ Պայմանագրի		|		Ջնջել", False))

                    .Add(New UPermissions("07BFB69B94724801A8683E2D2242653C", "Ընդհանուր	|	ՀԴՄ-ներ	|	Փնտրել ՀԴՄ		|		Ավելացնել ՀԴՄ", False))
                    .Add(New UPermissions("A35BF5CDACCA4201A59A8BE00D15B46E", "Ընդհանուր	|	ՀԴՄ-ներ	|	Փնտրել ՀԴՄ		|		Խմբագրել Տվյալները", False))
                    .Add(New UPermissions("9C0DCBD1BEF74F8FB900D574862DCFD8", "Ընդհանուր	|	ՀԴՄ-ներ	|	Փնտրել ՀԴՄ		|		Վերագրանցել", False))
                    .Add(New UPermissions("2EEB43EEA6774E92A6B3758C0A9692C4", "Ընդհանուր	|	ՀԴՄ-ներ	|	Փնտրել ՀԴՄ		|		Վերանորոգել", False))
                    .Add(New UPermissions("CAF8D5F996474865992650991B949851", "Ընդհանուր	|	ՀԴՄ-ներ	|	Փնտրել ՀԴՄ		|		Վերանորոգման Պատմություն", False))
                    .Add(New UPermissions("74AE3ECF7CC244BA825E9CCBF538E8FB", "Ընդհանուր	|	ՀԴՄ-ներ	|	Փնտրել ՀԴՄ		|		Ցուցադրել Ամբողջը", False))

                    .Add(New UPermissions("0662FC6C35F5455081F286DB04101486", "Ընդհանուր	|	ՀԴՄ-ներ	|	GPRS Քարտի Փոխքւմ		|		Փոխել Քարտը", False))

                    .Add(New UPermissions("87DFB5C9C26F486E85523663C8BF707F", "Ընդհանուր	|	ՀԴՄ-ներ	|	Տեսուչի Այց		|		Ավելացնել", False))
                    .Add(New UPermissions("1DA4F7B31A6444D2819F21A263952B04", "Ընդհանուր	|	ՀԴՄ-ներ	|	Տեսուչի Այց		|		Ջնջել", False))

                    .Add(New UPermissions("462F98F7420D4CF299D0ED20216D680F", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Նոր Խնդիր", False))
                    .Add(New UPermissions("2E74D56001D7411E926B464E2F512615", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Բացել Հայտ", False))
                    .Add(New UPermissions("69D234B39D8041BBB1F60D14122C7CA6", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Հայտի Փոփոխում", False))
                    .Add(New UPermissions("F8F540A6BF2049C9A8C0D09527F739C8", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Ավելացնել Ֆունկցիոնալ", False))
                    .Add(New UPermissions("20A2E83747F7445AB6DE91E877FAF6A1", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Հաստատել Հայտը", False))
                    .Add(New UPermissions("6D938FDA0F5341FEB7EF6F20B20E1B13", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Տպել Ինվոյս", False))
                    .Add(New UPermissions("36BC0147F3E14DC6AB290778E74D1F61", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Մերժել Հայտը", False))
                    .Add(New UPermissions("6F111911AC0441279112A9B93AF44D16", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Փակել Հայտը", False))
                    .Add(New UPermissions("E4A8F130B416419EAB5B86FB59774C00", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Տրամադրել Փոխարինող", False))
                    .Add(New UPermissions("524B70D63F224FEDA96C19F4F758B4B3", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Վերադարձնել Փոխարինողը", False))
                    .Add(New UPermissions("87A8428A67B246979C9CB315F18111A1", "Ընդհանուր	|	Վերանորոգում	|	Վերանորոգում		|		Փոխել Գումարը", False))

                    .Add(New UPermissions("C49E1477406147248FC8D38FC1D8E94A", "Ընդհանուր	|	Վերանորոգում	|	Մուտք Սրահ *		|		Կատարել", False))
                    .Add(New UPermissions("D7BBDA4BA12F4D118BA80119401E2F7D", "Ընդհանուր	|	Վերանորոգում	|	Մուտք Սրահ		|		Կատարել", False))
                    .Add(New UPermissions("53671AC392014AD09D4253D51667800B", "Ընդհանուր	|	Վերանորոգում	|	Մուտք Արհեստանոց		|		Կատարել", False))
                    .Add(New UPermissions("79D616F151A04E5BA84D9FE052D6C2FB", "Ընդհանուր	|	Վերանորոգում	|	Մուտք Արհեստանոց	 *	|		Կատարել", False))
                    .Add(New UPermissions("12D76A3EA38A43B89DCC39BCCFF62B1C", "Ընդհանուր	|	Վերանորոգում	|	Ելք Արհեստանոցից	 *	|		Կատարել", False))
                    .Add(New UPermissions("C2555CCD9877439D826EA99D4362EFF8", "Ընդհանուր	|	Վերանորոգում	|	Ելք Արհեստանոցից	|		Կատարել", False))
                    .Add(New UPermissions("BF3E404B7E4947A29A55F41F754F924F", "Ընդհանուր	|	Վերանորոգում	|	Ելք Սրահից	|		Կատարել", False))
                    .Add(New UPermissions("530A530EECC8487A94F1E939238CFCC5", "Ընդհանուր	|	Վերանորոգում	|	Ելք Սրահից	*	|		Կատարել", False))

                    .Add(New UPermissions("E2CBE6EA5D1949F5825C7BB7D493B32E", "Ընդհանուր	|	Արհեստանոց	|	Արհեստանոցի Հայտ		|		Մուտք/Վերադարձ", False))

                    .Add(New UPermissions("B6B00A5BACC348E58FA197E5F299BF1C", "Ընդհանուր	|	Արհեստանոց	|	Արհեստանոցի Սարքավորումներ		|		Ավելացնել Սարքավոչում", False))
                    .Add(New UPermissions("E0499EBBC5C64B0FBD877CBC9E2902EC", "Ընդհանուր	|	Արհեստանոց	|	Արհեստանոցի Սարքավորումներ		|		Ջնջել", False))

                    .Add(New UPermissions("8EEDC9FC04C345D1996DE693FF23456F", "Ընդհանուր	|	GPRS	|	Նոր GPRS Քարտ		|		Ավելացնել", False))

                    .Add(New UPermissions("F0FCA748F0F64DF4A09448369850625A", "Ընդհանուր	|	GPRS	|	Ներբեռնել Excel-ից		|		Ավելացնել", False))

                    .Add(New UPermissions("FDD545685E424BA4B91D004C3B195E53", "Ընդհանուր	|	Տարիֆ	|	Փոխել Գործընկերոջ Տարիֆը		|		Փոխել", False))

                    .Add(New UPermissions("4156367E0F084458B9EEF33FE6301A99", "Ընդհանուր	|	Տարիֆ	|	Փոփոխման Ենթակա Տարիֆ		|		Ջնջել", False))


                    'Պահեստ

                    .Add(New UPermissions("FE9AC83E29464A6BAEE5A9EDC3F74618", "Պահեստ	|	Տեղեկատու	|	Սարքավորում		|		Ավելացնել", False))
                    .Add(New UPermissions("A2C1C44668A447FD9C2F5147216B011C", "Պահեստ	|	Տեղեկատու	|	Սարքավորում		|		Փոխել", False))
                    .Add(New UPermissions("09041261D4144A90B2353A610A7D3C80", "Պահեստ	|	Տեղեկատու	|	Սարքավորում		|		Ջնջել", False))

                    .Add(New UPermissions("C62496D9278C463C99E4BB078BB26D60", "Պահեստ	|	Տեղեկատու	|	Սարքավորման Արժեք Ըստ Տարիֆի		|		Ավելացնել", False))
                    .Add(New UPermissions("CD59C82B41AC4F5FAC4944898BE2D21F", "Պահեստ	|	Տեղեկատու	|	Սարքավորման Արժեք Ըստ Տարիֆի		|		Փոխել", False))
                    .Add(New UPermissions("02307F65F21C42B589E23723F8B15608", "Պահեստ	|	Տեղեկատու	|	Սարքավորման Արժեք Ըստ Տարիֆի		|		Ջնջել", False))


                    'Հաշվապահություն

                    .Add(New UPermissions("E3C6493985154010B9B22664C5DDCC60", "Հաշվապահություն	|	Վճարներ	|	Վճարի Մուտքագրում		|		Ավելացնել", False))
                    .Add(New UPermissions("DAB774F5E329481F981A4169F89900D9", "Հաշվապահություն	|	Վճարներ	|	Վճարի Մուտքագրում		|		Փոխել Գումարի Չափը", False))
                    .Add(New UPermissions("33AED93AB8D943858BEAB6EAC502E683", "Հաշվապահություն	|	Վճարներ	|	Վճարի Մուտքագրում		|		Հաստատել Վճարը", False))
                    .Add(New UPermissions("8285899D39754AB7AA134D4DB0A6FDEA", "Հաշվապահություն	|	Վճարներ	|	Վճարի Մուտքագրում		|		Ջնջել Մուծումը", False))

                    .Add(New UPermissions("02411AAA388049729E3E800E45D511BB", "Հաշվապահություն	|	Վճարներ	|	Բանկային Տվյալներ		|		Կատարել Վճարումը", False))

                    .Add(New UPermissions("A5DD48DBAC7242E987EBE45B30B7773E", "Հաշվապահություն	|	Հ/Ա	|	Ընթացիկ Հ/Ա		|		Ստուգել", False))
                    .Add(New UPermissions("9AD2642800824AFC89E5223A949FF4AB", "Հաշվապահություն	|	Հ/Ա	|	Ընթացիկ Հ/Ա		|		Ստեղծել", False))
                    .Add(New UPermissions("6491C1B93C3942A6A0F40B4F5CB107A9", "Հաշվապահություն	|	Հ/Ա	|	Ընթացիկ Հ/Ա		|		Հաստատել Որպես Տպված", False))

                    .Add(New UPermissions("36D95A68E092478CB17520D04BBB61D0", "Հաշվապահություն	|	Հ/Ա	|	Սպասարկման Հ/Ա		|		Ստեղծել Հ/Ա", False))
                    .Add(New UPermissions("DA631988F5E442ACB03E08B3CBF653B5", "Հաշվապահություն	|	Հ/Ա	|	Սպասարկման Հ/Ա		|		Բեռնել ԱԱՀ-ով", False))
                    .Add(New UPermissions("1455B846CACC45FBB0B3FD95A798C086", "Հաշվապահություն	|	Հ/Ա	|	Սպասարկման Հ/Ա		|		Բեռնել Առանց ԱԱՀ-ի", False))
                    .Add(New UPermissions("79809465E5B84A0C82714D80FEB3FADF", "Հաշվապահություն	|	Հ/Ա	|	Սպասարկման Հ/Ա		|		Գեներացնել XML ԱԱՀ-ով", False))
                    .Add(New UPermissions("622E4189661C406D8E30FBF863270D52", "Հաշվապահություն	|	Հ/Ա	|	Սպասարկման Հ/Ա		|		Գեներացնել XML Առանց ԱԱՀ-ի", False))

                    .Add(New UPermissions("EEDDD9F2F8A444199874D09770864A5C", "Հաշվապահություն	|	Հ/Ա	|	Տպված Սպասարկման Հ/Ա		|		Հաստատել Վերադարձված", False))

                    .Add(New UPermissions("6CC34A50604446E6A06DCC54D08A6F30", "Հաշվապահություն	|	Տեղեկատու	|	PDF-ով Չտպվող		|		Ավելացնել", False))
                    .Add(New UPermissions("6DD0B8B9D3B14AB0ACD852516A656D90", "Հաշվապահություն	|	Տեղեկատու	|	PDF-ով Չտպվող		|		Ջնջել Բոլոր Գրանցումները", False))
                    .Add(New UPermissions("269CD9CCB99845A19343EF597858A819", "Հաշվապահություն	|	Տեղեկատու	|	PDF-ով Չտպվող		|		Բեռնել Excel-ից", False))
                    .Add(New UPermissions("EA4CD1939E804A7684B40CB4E850C8C7", "Հաշվապահություն	|	Տեղեկատու	|	PDF-ով Չտպվող		|		Ջնջել", False))

                    .Add(New UPermissions("D631EC61178843079D25E675B5111AD3", "Հաշվապահություն	|	Տեղեկատու	|	Չսպասարկվող		|		Չսպասարկվողների Պատմություն", False))


                    'Զանգերի Կենտրոն
                    .Add(New UPermissions("D8F4361986A6453C85074829802A5F02", "Զանգերի Կենտրոն	|	Հայտեր	|	Խմբագրել Հայտը		|		Փակել", False))


                    'Panel
                    .Add(New UPermissions("7F5417DAACF64C83BA207E61C4EC6F4C", "Շրջան	|	Փոխարինող ՀԴՄ	|	Սպասվող	|		Փոխել Ժամկետը", False))
                    .Add(New UPermissions("FE220BEC07B64ADCB6F57409E473BF5F", "Շրջան	|	Փոխարինող ՀԴՄ	|	Սպասվող	|		Ջնջել", False))
                    .Add(New UPermissions("F33A4EAF3B7244D3AC0F20BF991DA0CA", "Շրջան	|	Փոխարինող ՀԴՄ	|	Ուղարկված	|		Փոխել Ժամկետը", False))

                End With

            Else


            End If

            If dt2.Rows.Count > 0 Then
                For i As Integer = 0 To dt2.Rows.Count - 1
                    For j As Integer = 0 To UList.Count - 1
                        If dt2.Rows(i)("GUID") = UList.Item(j).GUID AndAlso dt2.Rows(i)("Allowed") = True Then UList.Item(j).Ակտիվ = True
                    Next
                Next
            End If

            GridControl2.BeginUpdate()
            GridControl2.DataSource = Nothing
            GridView2.Columns.Clear()

            GridControl2.DataSource = ToDataTable(UList)

            GridView2.ClearSelection()
            GridControl2.EndUpdate()

            With GridView2
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = True
                .OptionsBehavior.ReadOnly = False
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsView.ColumnAutoWidth = False
                .Columns(1).OptionsColumn.ReadOnly = True
                .Columns(0).Visible = False
                .BestFitColumns(True)
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'CRUD
    Private Sub CrudAction(ByVal CrudType As Crud)
        Try
            Dim activeChild As Form = Me.ActiveMdiChild
            Dim currentForm As Form = Form.ActiveForm

            If currentForm.Name <> Me.Name Then
                If currentForm.Name = "nTesuch" Then
                    Dim frm As TesuchWindow = DirectCast(currentForm, TesuchWindow)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("BD568238374E4D8A97D9A14D324617FB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("E919DC592EEB4510945EB8DEB17AD02B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("77803C0C9ABE4AC4A34F74F6193E9C05") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If
                ElseIf currentForm.Name = "nTesuchRegion" Then
                    Dim frm As TesuchInfoWindow = DirectCast(currentForm, TesuchInfoWindow)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("4151D69E28B44B2EBBEEBAED5E5019BC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("609D86A8A7714DC2959C1581AD7C6E70") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If
                ElseIf currentForm.Name = "nRegion" Then
                    Dim frm As RegionWindow = DirectCast(currentForm, RegionWindow)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("67EA526006FA4A9D90D7C66E579B193F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("95CBC22E2E184603B7E5B35E060F704C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("4C74AA84EFCD4F4F83325A71D2F7DE3A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If
                ElseIf currentForm.Name = "nContract" Then
                    Dim frm As ContractWindow = DirectCast(currentForm, ContractWindow)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("678D4EFE0BC14E86AEA85A4F91CC9873") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("B3FCE0E5A3DD441E9FAF16F9380F1C70") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("CFD82C464032408EBDD7E18ACD3CF40A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If
                ElseIf currentForm.Name = "nAddress" Then
                    Dim frm As AddressWindow = DirectCast(currentForm, AddressWindow)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("B8D325527E5D4622A52645B43E828DCF") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("B53CDA91E1D14CCFB18C776CA83DB4AE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("49A3BF48B6034F32B667D67D3F598C53") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If
                ElseIf currentForm.Name = "nObjType" Then
                    Dim frm As ObjTypeWin = DirectCast(currentForm, ObjTypeWin)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("2580D19B7939458B8DC2FF6CFD03793D") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("6718209F95A24F7CB435022C55171DCA") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("D26EAF5A50D44CB4A8FE36BE0A87538C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If
                ElseIf currentForm.Name = "nTHT" Then
                    Dim frm As ThtWin = DirectCast(currentForm, ThtWin)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("9592D180CB6745D19EFA0A902E0AA2C7") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("B8768B11FFB74F118EF8933B09B6B5AE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("8265EC1DD233463B80BC078807854C6F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If
                ElseIf currentForm.Name = "nSearchClient" Then
                    Dim frm As SearchHVHH = DirectCast(currentForm, SearchHVHH)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("E693D414793945C6968068E1E2DF48A0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("5B9BFC20A0DB4BA0806322433BCFE5BE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    End If
                ElseIf currentForm.Name = "nHDMSearch" Then
                    Dim frm As SearchHDMOnly = DirectCast(currentForm, SearchHDMOnly)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("07BFB69B94724801A8683E2D2242653C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("A35BF5CDACCA4201A59A8BE00D15B46E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    End If
                ElseIf currentForm.Name = "nEquipment" Then
                    Dim frm As EquipmentWin = DirectCast(currentForm, EquipmentWin)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("FE9AC83E29464A6BAEE5A9EDC3F74618") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("A2C1C44668A447FD9C2F5147216B011C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("09041261D4144A90B2353A610A7D3C80") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If
                ElseIf currentForm.Name = "nTesuchVisitWin" Then
                    Dim frm As TesuchVisitWin = DirectCast(currentForm, TesuchVisitWin)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("87DFB5C9C26F486E85523663C8BF707F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("1DA4F7B31A6444D2819F21A263952B04") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If
                ElseIf currentForm.Name = "nTarif" Then
                    Dim frm As TarifWin = DirectCast(currentForm, TarifWin)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("2F5A0D5661F24141BEE15CCF65EA1609") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("B5F45B13B1D7465E933A4C58C2D9E782") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("92553042666C4450ADD631180948842E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If
                ElseIf currentForm.Name = "nSetEquipmentPrice" Then
                    Dim frm As SetEquipmentPrice = DirectCast(currentForm, SetEquipmentPrice)
                    If CrudType = Crud.Insert Then
                        If CheckPermission2("C62496D9278C463C99E4BB078BB26D60") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.AddRecord()
                    ElseIf CrudType = Crud.Update Then
                        If CheckPermission2("CD59C82B41AC4F5FAC4944898BE2D21F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.UpdateRecords()
                    ElseIf CrudType = Crud.Delete Then
                        If CheckPermission2("02307F65F21C42B589E23723F8B15608") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        frm.DeleteRecord()
                    End If

                End If



            Else
                If (Not activeChild Is Nothing) Then
                    If activeChild.Name = "nTesuch" Then
                        Dim frm As TesuchWindow = DirectCast(activeChild, TesuchWindow)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("BD568238374E4D8A97D9A14D324617FB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("E919DC592EEB4510945EB8DEB17AD02B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("77803C0C9ABE4AC4A34F74F6193E9C05") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If
                    ElseIf activeChild.Name = "nTesuchRegion" Then
                        Dim frm As TesuchInfoWindow = DirectCast(activeChild, TesuchInfoWindow)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("4151D69E28B44B2EBBEEBAED5E5019BC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("609D86A8A7714DC2959C1581AD7C6E70") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If
                    ElseIf activeChild.Name = "nRegion" Then
                        Dim frm As RegionWindow = DirectCast(activeChild, RegionWindow)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("67EA526006FA4A9D90D7C66E579B193F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("95CBC22E2E184603B7E5B35E060F704C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("4C74AA84EFCD4F4F83325A71D2F7DE3A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If
                    ElseIf activeChild.Name = "nContract" Then
                        Dim frm As ContractWindow = DirectCast(activeChild, ContractWindow)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("678D4EFE0BC14E86AEA85A4F91CC9873") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("B3FCE0E5A3DD441E9FAF16F9380F1C70") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("CFD82C464032408EBDD7E18ACD3CF40A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If
                    ElseIf activeChild.Name = "nAddress" Then
                        Dim frm As AddressWindow = DirectCast(activeChild, AddressWindow)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("B8D325527E5D4622A52645B43E828DCF") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("B53CDA91E1D14CCFB18C776CA83DB4AE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("49A3BF48B6034F32B667D67D3F598C53") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If
                    ElseIf activeChild.Name = "nObjType" Then
                        Dim frm As ObjTypeWin = DirectCast(activeChild, ObjTypeWin)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("2580D19B7939458B8DC2FF6CFD03793D") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("6718209F95A24F7CB435022C55171DCA") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("D26EAF5A50D44CB4A8FE36BE0A87538C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If
                    ElseIf activeChild.Name = "nTHT" Then
                        Dim frm As ThtWin = DirectCast(activeChild, ThtWin)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("9592D180CB6745D19EFA0A902E0AA2C7") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("B8768B11FFB74F118EF8933B09B6B5AE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("8265EC1DD233463B80BC078807854C6F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If
                    ElseIf activeChild.Name = "nSearchClient" Then
                        Dim frm As SearchHVHH = DirectCast(activeChild, SearchHVHH)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("E693D414793945C6968068E1E2DF48A0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("5B9BFC20A0DB4BA0806322433BCFE5BE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        End If
                    ElseIf activeChild.Name = "nHDMSearch" Then
                        Dim frm As SearchHDMOnly = DirectCast(activeChild, SearchHDMOnly)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("07BFB69B94724801A8683E2D2242653C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("A35BF5CDACCA4201A59A8BE00D15B46E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        End If
                    ElseIf activeChild.Name = "nEquipment" Then
                        Dim frm As EquipmentWin = DirectCast(activeChild, EquipmentWin)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("FE9AC83E29464A6BAEE5A9EDC3F74618") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("A2C1C44668A447FD9C2F5147216B011C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("09041261D4144A90B2353A610A7D3C80") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If
                    ElseIf activeChild.Name = "nTesuchVisitWin" Then
                        Dim frm As TesuchVisitWin = DirectCast(activeChild, TesuchVisitWin)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("87DFB5C9C26F486E85523663C8BF707F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("1DA4F7B31A6444D2819F21A263952B04") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If
                    ElseIf activeChild.Name = "nTarif" Then
                        Dim frm As TarifWin = DirectCast(activeChild, TarifWin)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("2F5A0D5661F24141BEE15CCF65EA1609") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("B5F45B13B1D7465E933A4C58C2D9E782") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("92553042666C4450ADD631180948842E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If
                    ElseIf activeChild.Name = "nSetEquipmentPrice" Then
                        Dim frm As SetEquipmentPrice = DirectCast(activeChild, SetEquipmentPrice)
                        If CrudType = Crud.Insert Then
                            If CheckPermission2("C62496D9278C463C99E4BB078BB26D60") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.AddRecord()
                        ElseIf CrudType = Crud.Update Then
                            If CheckPermission2("CD59C82B41AC4F5FAC4944898BE2D21F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.UpdateRecords()
                        ElseIf CrudType = Crud.Delete Then
                            If CheckPermission2("02307F65F21C42B589E23723F8B15608") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                            frm.DeleteRecord()
                        End If

                    End If
                End If
            End If

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'For SMS
    Private Function GetTelNumber() As String
        Try

            Return iDB.RetTelNumber()

        Catch ex As Exception
            'Return "43263301" 'Qrist
            Return "98882680" 'Hegh
        End Try
    End Function

    Private Sub LoadSMSToTesuchPermission()
        Try
            SMSSendToTesuchP = iDB.GetTesuchSMSPermission()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub LoadBarRemake()
        Try
            bBarRemake = iDB.GBarRemake()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub LoadBarRemakeClient()
        Try
            bBarRemakeClient = iDB.GBarRemakeProp()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#Region "From Events"

    Private Sub MainWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next

        If isResetedLayout = False Then
            DockManager1.SaveLayoutToRegistry("Software\\Ecr\\Layouts\\MainLayout")
        End If

        If Not IsNothing(_t) Then
            _t.Stop()
            _t = Nothing
        End If

        If Not IsNothing(_tremake) Then
            _tremake.Stop()
            _tremake = Nothing
        End If

        LoginWindow.Close()

    End Sub
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error Resume Next

        Me.WindowState = FormWindowState.Maximized
        cbMessageType.SelectedIndex = 0

        infoDate.Caption = String.Format("{0} / {1}", Date.Now().ToString("dd.MM.yyyy"), Date.Now.DayOfWeek.ToString())
        infoLogin.Caption = String.Format("{0} ({1} {2})", iUser.LoginName, iUser.FirstName, iUser.LastName)

        _t = New Timer
        With _t
            .Interval = 60000
            .Start()
        End With

        _tremake = New Timer
        With _tremake
            .Interval = 240000
            .Start()
        End With

        strPrinter = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ՀԴՄ APP", "Printer", "")

        RepTreeList.OptionsBehavior.ReadOnly = True
        RepTreeList.OptionsBehavior.Editable = False

        WareHouseTreeList.OptionsBehavior.ReadOnly = True
        WareHouseTreeList.OptionsBehavior.Editable = False

        ActionTreeList.OptionsBehavior.ReadOnly = True
        ActionTreeList.OptionsBehavior.Editable = False

        AcountTreeList.OptionsBehavior.ReadOnly = True
        AcountTreeList.OptionsBehavior.Editable = False

        CallCenterTreeList.OptionsBehavior.ReadOnly = True
        CallCenterTreeList.OptionsBehavior.Editable = False

        RemakePanel.Visibility = DockVisibility.Hidden
        CallPanel.Visibility = DockVisibility.Hidden
        PartqPanel.Visibility = DockVisibility.Hidden

        RibbonPageGroup16.Visible = False

    End Sub
    Private Sub MainWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        On Error Resume Next

        Call DisableComponents()

        If (iUser.DB = 1 OrElse iUser.DB = 3) Then txtEnterCenterWorkShop.Enabled = False

        If iUser.DB = 1 OrElse iUser.DB = 3 Then
            PartqPanel.Visibility = DockVisibility.Visible
        Else
            PartqPanel.Visibility = DockVisibility.Hidden
        End If

        If CheckPermission("BFC3B50AE7F84FDABEA6C2B3943F8844") = True Then RemakePanel.Visibility = DockVisibility.Visible

        If iUser.UserID = 11 OrElse iUser.UserID = 108 Then
            RemakePanel.Visibility = DockVisibility.Visible
            txtEnterCenterWorkShop.Enabled = False
        End If

        If iUser.UserID = 11 Then RibbonPageGroup16.Visible = True
        'If GetTelNumber() = "43263301" Then btnOnline.Checked = True Else btnOnline.Checked = False 'Qrist
        If GetTelNumber() = "98882680" Then btnOnline.Checked = True Else btnOnline.Checked = False 'Hegh

        Call LoadTimerData()
        Call LoadTimerData2()
        Call LoadTimerData3()

        If GridView3.RowCount > 0 Then
            WTimer.Enabled = True
            WTimer.Start()
        End If

        DockManager1.RestoreLayoutFromRegistry("Software\\Ecr\\Layouts\\MainLayout")

        beGPRS.EditWidth = 100
        beGPRS.AutoFillWidth = 100

        If iUser.UserID = 20 OrElse iUser.UserID = 17 OrElse iUser.UserID = 16 OrElse iUser.UserID = 15 OrElse
            iUser.UserID = 11 OrElse iUser.UserID = 103 OrElse iUser.UserID = 7 OrElse iUser.UserID = 19 OrElse
            iUser.UserID = 5 OrElse iUser.UserID = 116 OrElse iUser.UserID = 119 OrElse iUser.UserID = 3 Then

            RibbonGPRS.Visible = True
        Else
            RibbonGPRS.Visible = False
        End If

        If iUser.UserGroup = 1 Then
            RibbonSMSTesuch.Visible = True
        Else
            RibbonSMSTesuch.Visible = False
        End If

        Call LoadSMSToTesuchPermission()
        Call LoadBarRemake()
        Call LoadBarRemakeClient()

        If SMSSendToTesuchP = True Then
            CKSMSToTesuchX.Checked = True
        End If

        If bBarRemake = True Then
            BarRemake.Checked = True
        End If

        If bBarRemakeClient = True Then
            BarRemakeClient.Checked = True
        End If

    End Sub

#End Region

#Region "Ուղղորդիչ"

#Region "Ընդհանուր"

    Private Sub ActionTreeList_DoubleClick(sender As Object, e As EventArgs) Handles ActionTreeList.DoubleClick
        Try
            Dim tree As TreeList = TryCast(sender, TreeList)
            Dim hi As TreeListHitInfo = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition))

            If hi.Node IsNot Nothing Then
                Select Case hi.Node.Id
                    Case 0
                        'Տեղեկատուներ
                        '////////////////////////////////////////////////////////////////////////

                        'Տեսուչներ
                    Case 1
                        If CheckPermission("8149E1D04AFE4C43A1A81B2B27E965DF") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTesuch")
                        Dim f As New TesuchWindow
                        AddChildForm("nTesuch", f)
                        'Տեսուչ Շրջան
                    Case 2
                        If CheckPermission("ABDAE1F9E6884908B840BA2C4B0F3817") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTesuchRegion")
                        Dim f As New TesuchInfoWindow
                        AddChildForm("nTesuchRegion", f)
                        'Տեսուչի ՀԴՄ-ներ
                    Case 3
                        If CheckPermission("BD9204E949E24ACB9BB691F070953385") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nReplaceEcrTesuch")
                        Dim f As New ReplaceEcrTesuch
                        AddChildForm("nReplaceEcrTesuch", f)
                        'Տարածաշրջան
                    Case 4
                        If CheckPermission("0387762D7054418BB2C7212DBFC53648") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRegion")
                        Dim f As New RegionWindow
                        AddChildForm("nRegion", f)
                        'Պայմանագիր
                    Case 5
                        If CheckPermission("529F861E78684EBE9EE09DC4E5B89F6A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nContract")
                        Dim f As New ContractWindow
                        AddChildForm("nContract", f)
                        'Հասցե
                    Case 6
                        If CheckPermission("9D95E8A0A5EF4BF7ABD3D271CC34566D") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nAddress")
                        Dim f As New AddressWindow
                        AddChildForm("nAddress", f)
                        'Օբյեկտի Տեսակ
                    Case 7
                        If CheckPermission("6E7F85D395994B5789C1651A76E1F287") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nObjType")
                        Dim f As New ObjTypeWin
                        AddChildForm("nObjType", f)
                        'ՏՀՏ
                    Case 8
                        If CheckPermission("1C859E9CBE9F4406A01CE38A2EEF3DF4") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTHT")
                        Dim f As New ThtWin
                        AddChildForm("nTHT", f)
                        'Տարիֆ
                    Case 9
                        If CheckPermission("77B200BBD84F4DADB4FFFDA4377B035C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTarif")
                        Dim f As New TarifWin
                        AddChildForm("nTarif", f)
                    Case 10
                        'ՀԴՄ Առաքում
                        '////////////////////////////////////////////////////////////////////////

                        'ՀԴՄ Առաքում
                    Case 11
                        If CheckPermission("874DF27A12054E17A5B6DB8D8AC750FE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nHDMAraqum")
                        Dim f As New hdmAraqumWindow
                        AddChildForm("nHDMAraqum", f)
                        'ՀԴՄ Ճանապարհին
                    Case 12
                        If CheckPermission("2B6B1113D956414796E53F2A1647A56A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nHDMInRoad")
                        Dim f As New hdmOnRoadWindow
                        AddChildForm("nHDMInRoad", f)
                        'ՀԴՄ Վերանորոգման Մեջ
                    Case 13
                        If CheckPermission("45BBCE23E1E446C69CE00AEDF5BC4B44") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nDHMRemReady")
                        Dim f As New hdmAraqumOnRemontWindow
                        AddChildForm("nDHMRemReady", f)
                        'ՀԴՄ Ուղարկման Ենթակա
                    Case 14
                        If CheckPermission("DCBD85BE9F6A43159F68B64B72222F33") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nHDMToBeSend")
                        Dim f As New hdmAraqumReadyWindow
                        AddChildForm("nHDMToBeSend", f)
                        'ՀԴՄ Ուղարկված
                    Case 15
                        If CheckPermission("0FE2E3E794CE438681BE8267F0B7F410") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nHDMSentToRoad")
                        Dim f As New hdmAraqumSentWindow
                        AddChildForm("nHDMSentToRoad", f)
                    Case 16
                        'Պայմանագիր
                        '////////////////////////////////////////////////////////////////////////

                        'ՊՈԱԿ Ավելացման Ենթակա
                    Case 17
                        If CheckPermission("99E1C38807234D36A30F7148BA074DB2") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New PoakToDBSelector
                        f.ShowDialog()
                        'ՊՈԱԿ Վերագրանցման Ենթակա
                    Case 18
                        If CheckPermission("9360823FDE4746A294FBF349759BFEC0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nPoakForReRegister")
                        Dim f As New PoakToRegister
                        AddChildForm("nPoakForReRegister", f)
                        'ՊՈԱԿ ՄԳՀ Տարբերություն
                    Case 19
                        If CheckPermission("9132657EF0A045FF80433E6E0DC3E9ED") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nPoakMGH")
                        Dim f As New PoakToMGH
                        AddChildForm("nPoakMGH", f)
                        'ԲԱԶԱ ՊՈԱԿ Համեմատում
                    Case 20
                        If CheckPermission("70326A9271804018A5F894A7117817F3") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nBaseToPoak")
                        Dim f As New BazaPoak
                        AddChildForm("nBaseToPoak", f)
                        'Պայմանագրի Քանակի Համեմատում
                    Case 21
                        If CheckPermission("282DB48D53424BF4AF73481CE093B3C9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nCountractCounteChecker")
                        Dim f As New ContractCounterWindow
                        AddChildForm("nCountractCounteChecker", f)
                        'Տպված Պայմանագրի Հավելված
                    Case 22
                        If CheckPermission("22171AEB3646406691BC382AB49AC145") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nPrintedApplContract")
                        Dim f As New PrintedContractApplicationsWin
                        AddChildForm("nPrintedApplContract", f)
                        'Չտպված Հավելվածներ
                    Case 23
                        If CheckPermission("B2F89BF559744C1D95F8A47996A3D350") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateSelect
                        fm.ShowDialog()
                        fm.Dispose()
                        'Գործընկերոջ Կարգավիճակի Փոփոխություն
                    Case 24
                        If CheckPermission("B2F89BF559744C1D95F8A47996A3D359") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nChangeEcrStatus")
                        Dim f As New ChangeEcrStatus
                        AddChildForm("nChangeEcrStatus", f)
                    Case 25
                        'Արգելափակել ՀԴՄ-GPRS
                        '////////////////////////////////////////////////////////////////////////

                        'GPRS Կասեցումից Ազատված
                    Case 26
                        If CheckPermission("34BF90D3C1D84BB69586FFDA1FE389A4") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nEditPremiumClients")
                        Dim f As New EditPremiumClients
                        AddChildForm("nEditPremiumClients", f)
                        'Արգելափակել GPRS
                    Case 27
                        If CheckPermission("835C5DAD85F14F9192BE753F9F9D3134") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nMustBeDisables")
                        Dim f As New mustBeDisabledEcrWindow
                        AddChildForm("nMustBeDisables", f)
                        'Արգելափակված GPRS
                    Case 28
                        If CheckPermission("2BE4D16252A241E9BEBBC5BE6B46E37C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nDisabledECRs")
                        Dim f As New disabledEcrWindow
                        AddChildForm("nDisabledECRs", f)
                        'Ուղարկել Նամակ
                    Case 29
                        If CheckPermission("B620D1EE214F4768AF96286F5CB3E281") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nSendEmailToTesuch")
                        Dim f As New SendEmailWindow
                        AddChildForm("nSendEmailToTesuch", f)
                        'Ուղարկել SMS Հաճախորդներին
                    Case 30
                        If CheckPermission("4BF939352BB44D7A853D9CD7C4EA72AE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nSMSToClient")
                        Dim f As New SendSMSWindow
                        AddChildForm("nSMSToClient", f)
                        'Ուղարկել SMS Տեսուչներին
                    Case 31
                        If CheckPermission("FFCB6B904E8E41939D2CCA5187B43AD9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nSMSToTesuch")
                        Dim f As New SendTesuchSMSWindow
                        AddChildForm("nSMSToTesuch", f)
                        'Ուղարկել Անհատական SMS
                    Case 32
                        If CheckPermission("A982D7FBED2A45F2AE9CD2B57F6F8F44") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nCustomSMSByClient")
                        Dim f As New SendHVHHSMSWindow
                        AddChildForm("nCustomSMSByClient", f)
                        'ՀՎՀՀ-ով SIM Արգելքի Հանում
                    Case 33
                        If CheckPermission("2B6BAE83388B4C8AAC3FA07C0ABC5416") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nEnableSIMByHVHH")
                        Dim f As New enagleSIMByHvhhWindow
                        AddChildForm("nEnableSIMByHVHH", f)
                    Case 34
                        'Գործընկերներ
                        '////////////////////////////////////////////////////////////////////////

                        'Գործընկեր
                    Case 35
                        If CheckPermission("AA7ABFF5766B46DFB03432178C0A22FB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nSearchClient")
                        Dim f As New SearchHVHH
                        AddChildForm("nSearchClient", f)
                        'Գործընկերոջ Հուսալիություն
                    Case 36
                        If CheckPermission("A68E621DA9604C9A8F68EFAC7531774D") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRepPartnerPercent")
                        Dim f As New RepPartnerPercent
                        AddChildForm("nRepPartnerPercent", f)
                    Case 37
                        'ՀԴՄ-ներ
                        '////////////////////////////////////////////////////////////////////////

                        'ՀԴՄ
                    Case 38
                        If CheckPermission("7C7D395B41B647E398D265A5B5E1AC20") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nHDMSearch")
                        Dim f As New SearchHDMOnly
                        AddChildForm("nHDMSearch", f)
                        'GPRS Քարտի Փոփոխում
                    Case 39
                        If CheckPermission("026606C89C9449DBBBB864007DF90C57") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New changeGPRSCode
                        f.ShowDialog()
                        f.Dispose()
                        'Արգելափակված ՀԴՄ
                    Case 40
                        If CheckPermission("79ED7339409148A49324712C84ED707E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nBlockedHDMGprs")
                        Dim f As New BlockedGPRS
                        AddChildForm("nBlockedHDMGprs", f)
                        'ՀԴՄ Կարգավիճակ ՊՈԱԿ-ում
                    Case 41
                        If CheckPermission("AB2A040842F441BB8A578C0F3C33A7EE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nPoakHDMStatus")
                        Dim f As New PoakHdmStatus
                        AddChildForm("nPoakHDMStatus", f)
                        'Երաշխիքային ՀԴՄ
                    Case 42
                        If CheckPermission("858A3BDA099344B2812384918418B619") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nInGarant")
                        Dim f As New garantHDM
                        AddChildForm("nInGarant", f)
                        'Ոչ Երաշխիքային ՀԴՄ
                    Case 43
                        If CheckPermission("032886C945DB4C958FF3EE3043E24840") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nNotInGarant")
                        Dim f As New NotgarantHDM
                        AddChildForm("nNotInGarant", f)
                    Case 44
                        'Տեսուչի Այց
                        '////////////////////////////////////////////////////////////////////////

                        'Տեսուչի Այց
                    Case 45
                        If CheckPermission("B3F5707273664E5CBEE4E710AD867D70") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTesuchVisitWin")
                        Dim f As New TesuchVisitWin
                        AddChildForm("nTesuchVisitWin", f)
                    Case 46
                        'Վերանորոգում
                        '////////////////////////////////////////////////////////////////////////

                        'Վերանորոգման Հայտ
                    Case 47
                        If CheckPermission("13AF25BD34BA470688C5378C64D356E9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New EcrSelecterForRemake
                        fm.ShowDialog()
                        fm.Dispose()
                        'Մուտք Սրահ *
                    Case 48
                        If CheckPermission("EE5A3A3242B24DD6915882185C604C79") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New EnterBranchClicker
                        fm.ShowDialog()
                        fm.Dispose()
                        'Մուտք Սրահ
                    Case 49
                        If CheckPermission("815F5E89D1434871AB287276F07CB0C5") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New EnterCenterClicker
                        fm.ShowDialog()
                        fm.Dispose()
                        'Մուտք Արհեստանոց
                    Case 50
                        If CheckPermission("BFC3B50AE7F84FDABEA6C2B3943F8844") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New EnterCenterWorkshop
                        fm.ShowDialog()
                        fm.Dispose()
                        'Մուտք Արհեստանոց *
                    Case 51
                        If CheckPermission("54580B6EEC224AD3BA318F54720CF0E9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New EnterBranchWorkshop
                        fm.ShowDialog()
                        fm.Dispose()
                        'Ելք Արհեստանոցից *
                    Case 52
                        If CheckPermission("3771982E439449E29027A84714962052") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New CloseBranchWorkshopWindow
                        fm.ShowDialog()
                        fm.Dispose()
                        'Ելք Արհեստանոցից
                    Case 53
                        If CheckPermission("CB67607887E84912A6D6751E71D73064") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New CloseCenterWorkshopWindow
                        fm.ShowDialog()
                        fm.Dispose()
                        'Ելք Սրահից
                    Case 54
                        If CheckPermission("938E9275863E4AFFB634DFDA81EAD3E4") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New CloseCenterWindow
                        fm.ShowDialog()
                        fm.Dispose()
                        'Ելք Սրահից *
                    Case 55
                        If CheckPermission("83C069B500D243A1837D67A6AF35AE66") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New CloseBranchWindow
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 56
                        'Արհեստանոց
                        '////////////////////////////////////////////////////////////////////////

                        'Արհեստանոցի Հայտ
                    Case 57
                        If CheckPermission("B2924575445C43D7A15E3FD546FBF214") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New WorkShopProposalWindow
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 58
                        'GPRS
                        '////////////////////////////////////////////////////////////////////////

                        'GPRS Նոր Քարտ
                    Case 59
                        If CheckPermission("01F5295314404972B73AB8905D2DF7AE") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nNewGprs")
                        Dim f As New NewGprs
                        AddChildForm("nNewGprs", f)
                        'GPRS Քարտ Ներբեռնել EXCEL-ից
                    Case 60
                        If CheckPermission("3AA18BBFB06244C893F4F637E9B03B27") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New GprsFileSelecter
                        fm.ShowDialog()
                        fm.Dispose()
                        'Ջնջել GPRS-ը
                    Case 61
                        If CheckPermission("9D5A719035B341A083696B17E61D5627") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nDeleteGPRSWindow")
                        Dim f As New DeleteGPRSWindow
                        AddChildForm("nDeleteGPRSWindow", f)
                        'Արխիվացնել Orange GPRS Հարցումները
                    Case 62
                        If CheckPermission("6680F94061EE45969FD2A361A73A3469") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call ArchiveOrangeData()
                    Case 63
                        'Տարիֆ
                        '////////////////////////////////////////////////////////////////////////

                        'Փոխել Գործընկերոջ Տարիֆը
                    Case 64
                        If CheckPermission("39C84C2EB6C14990B74164C1A7D3A8AF") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New changeTarifWindow
                        fm.ShowDialog()
                        fm.Dispose()
                        'Գործընկերոջ Ընթացիկ Տարիֆ
                    Case 65
                        If CheckPermission("CDD8026AB52D4D80AC4331393DEF3A73") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nListOfCurrentTarifWindow")
                        Dim f As New ListOfCurrentTarifWindow
                        AddChildForm("nListOfCurrentTarifWindow", f)
                        'Տարիֆի Պատմություն
                    Case 66
                        If CheckPermission("AB0E3EB722B948D8AB84F1F32E42C960") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTarifHistoryWindow")
                        Dim f As New TarifHistoryWindow
                        AddChildForm("nTarifHistoryWindow", f)
                        'Փոփոխման Ենթակա Տարիֆ
                    Case 67
                        If CheckPermission("DB24BF62FA9E4589BBCD8DD9AE3F358C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nUpcomingTarifWindow")
                        Dim f As New UpcomingTarifWindow
                        AddChildForm("nUpcomingTarifWindow", f)
                        'Տարիֆ Ըստ ՊՈԱԿ-ի
                    Case 68
                        If CheckPermission("3164C25231034131AAAB2AE858FEBE61") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nPoakTariff")
                        Dim f As New PoakTariff
                        AddChildForm("nPoakTariff", f)
                    Case 69
                        If CheckPermission("B9AB14A979A54C5D8A5EE9679135C130") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nMissedTariff")
                        Dim f As New MissedTariff
                        AddChildForm("nMissedTariff", f)
                    Case 70
                        If CheckPermission("3F3048CF83C0421D9FB08174FE163B03") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nCheckPoakTariff")
                        Dim f As New CheckPoakTariff
                        AddChildForm("nCheckPoakTariff", f)
                    Case 71
                        'POS
                        '////////////////////////////////////////////////////////////////////////

                        'Լիցենզիա
                    Case 72
                        If CheckPermission("57E6BB4B20B341EDA77D847BC5A0E824") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nLicWin")
                        Dim f As New LicWin
                        AddChildForm("nLicWin", f)
                        'Բանկ
                    Case 73
                        If CheckPermission("D47955C2018E4E6F837779CE26403838") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nBankWin")
                        Dim f As New BankWin
                        AddChildForm("nBankWin", f)

                    Case 74
                        'ՊՈԱԿ-ից Ստացված ՀԴՄ
                        '////////////////////////////////////////////////////////////////////////

                    Case 75
                        If CheckPermission("2384E622118D4FF4AA680ADA98813BED") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nPoakToOffice")
                        Dim f As New PoakToOffice
                        AddChildForm("nPoakToOffice", f)

                End Select
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#Region "Պահեստ"

    Private Sub WareHouseTreeList_DoubleClick(sender As Object, e As EventArgs) Handles WareHouseTreeList.DoubleClick
        Try
            Dim tree As TreeList = TryCast(sender, TreeList)
            Dim hi As TreeListHitInfo = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition))

            If hi.Node IsNot Nothing Then
                Select Case hi.Node.Id
                    Case 0
                        'Տեղեկատուներ
                        '////////////////////////////////////////////////////////////////////////

                        'Սարքավորումներ
                    Case 1
                        If CheckPermission("7C876240F6444808BA08ADFBE4792549") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nEquipment")
                        Dim f As New EquipmentWin
                        AddChildForm("nEquipment", f)
                        'Սարքավորման արժեք ըստ տարիֆի
                    Case 2
                        If CheckPermission("2449D7F3E0BA478D8850ACFAF35AB8A9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New TarifSelecter
                        fm.ShowDialog()
                        fm.Dispose()
                        'Սարքավորման Հավելավճար
                    Case 3
                        If CheckPermission("0D46642D5ACF49879D4534E0720DE7F1") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New AddPaySelect
                        fm.ShowDialog()
                        fm.Dispose()
                        'Պահեստի Մուտք
                    Case 4
                        If CheckPermission("4546D4E245A04D3C9AD4C8BD42388E1A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nPurchaseWarehouse")
                        Dim f As New PurchaseWarehouseWin
                        AddChildForm("nPurchaseWarehouse", f)
                    Case 5
                        'Հաշվետվություն
                        '////////////////////////////////////////////////////////////////////////

                        'Պահեստի Մնացորդ
                    Case 6
                        If CheckPermission("1AF301E3425B45AFBE386D84CFB322D6") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New WarHouseExistSelector
                        fm.ShowDialog()
                        fm.Dispose()
                        'Մնացորդ
                    Case 7
                        If CheckPermission("D1A87BBEB2D64E278772A110027B2888") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New MnacordSelector
                        fm.ShowDialog()
                        fm.Dispose()
                        'Վաճառված Սարքավորում
                    Case 8
                        If CheckPermission("0E630C35D9E44090BB1276BF1FD98E57") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateSelecterForSoldEquipment
                        fm.ShowDialog()
                        fm.Dispose()
                        'ՊՈԱԿ Պահեստ
                    Case 9
                        If CheckPermission("CAA1473418BD4619B8CDE369582D10E4") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nPOAKWarehouse")
                        Dim f As New POAKWarehouseWin
                        AddChildForm("nPOAKWarehouse", f)
                        'Խոտան Պահեստ
                    Case 10
                        If CheckPermission("F7F641C78DC8438789F300134C6CCA3E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRejectWarehouse")
                        Dim f As New RejectWarehouseWin
                        AddChildForm("nRejectWarehouse", f)
                        'Երկրորդային Պահեստի Մնացորդ
                    Case 11
                        If CheckPermission("5985506B73B044B99B2636769D5C3B9E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nInnerWarhowseExists")
                        Dim f As New InnerWarhowseExists
                        AddChildForm("nInnerWarhowseExists", f)
                    Case 12
                        If CheckPermission("C746D1566F85420791E7DE8DBCC3A298") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nInnerWarehouseSold")
                        Dim f As New InnerWarehouseSold
                        AddChildForm("nInnerWarehouseSold", f)
                    Case 13
                        'Վաճառք
                        '////////////////////////////////////////////////////////////////////////

                        'Վաճառել Սարքավորում
                    Case 14
                        If CheckPermission("D76E9B41BE4A4668B3BAEBBA56F4D1A8") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New SelectEquipmentSellType
                        fm.ShowDialog()
                        fm.Dispose()
                        'Վաճառքի Փոփոխում
                    Case 15
                        If CheckPermission("B73E316484BA4E85BC42B80470444C0F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New ChangeSellInvoiceSelect
                        fm.ShowDialog()
                        fm.Dispose()
                        'Վաճառքի Մերժում
                    Case 16
                        If CheckPermission("D0E24A6DE55742BAB4C4558BEFEF6125") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DeleteSellInvoiceSelect
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 17
                        If CheckPermission("D76E9B41BE4A4668B3BAEBBA56F4D1A8") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New SelectEcrSellType
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 18
                        'Պահեստի Շարժ
                        '////////////////////////////////////////////////////////////////////////

                        'Ներքին Տեղափոխում
                    Case 19
                        If CheckPermission("5556B31DA7F347D096612A365C4BDED6") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New InnerTransfer
                        fm.ShowDialog()
                        fm.Dispose()
                        'Պահեստի Մուտքի Օրդեր
                    Case 20
                        If CheckPermission("3B5BEF3DC60A4B97A0704F3654BE1A24") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New PurchaseWarehouseAddWin
                        fm.ShowDialog()
                        fm.Dispose()
                        'Նոր Շտրիխ Կոդ
                    Case 21
                        If CheckPermission("03025FE5C2124DB68CEF3EE2A85AF4CD") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New ShtrikhCodeGenerator
                        fm.ShowDialog()
                        fm.Dispose()
                        'Խոտան Պահեստ
                    Case 22
                        If CheckPermission("E28CC06DE63D4F51974C43E844FB0116") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New TransferToRejectedWin
                        fm.ShowDialog()
                        fm.Dispose()
                        'ՊՈԱԿ Պահեստ
                    Case 23
                        If CheckPermission("F7233259C8D346769F6591B3C4236E55") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New TransferToPoakWin
                        fm.ShowDialog()
                        fm.Dispose()
                End Select
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#Region "Հաշվետվություն"

    Private Sub RepTreeList_DoubleClick(sender As Object, e As EventArgs) Handles RepTreeList.DoubleClick
        Try
            Dim tree As TreeList = TryCast(sender, TreeList)
            Dim hi As TreeListHitInfo = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition))

            If hi.Node IsNot Nothing Then
                Select Case hi.Node.Id
                    Case 0
                        'Սպասարկող
                        '////////////////////////////////////////////////////////////////////////
                    Case 1 'Կազմ-Տարած-ՀԴՄ Քանակ
                        If CheckPermission("2AA5C17FC0B34B99AE14D5E24074D8E2") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New QerySelectToolRegEcrCount
                        f.ShowDialog()
                        f.Dispose()
                    Case 2
                        'Վճարներ
                        '////////////////////////////////////////////////////////////////////////

                    Case 3  'Վճար
                        If CheckPermission("08358DB47FF7408E961CD5A355B307A4") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateSelecterPayment
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 4  'Բանկային Մուտքեր
                        If CheckPermission("2B41752CCF84452883849C2081966F33") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New SelectBankEnter
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 5  'Պարտք Հավելավճար
                        If CheckPermission("9063A58CE5D746188F0BD79FEF0D6BDA") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DatePartqHavelavchar
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 6  'Դեբետ-Կրեդետ
                        If CheckPermission("1F4806DC194945D79D94A9B4A539E974") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateDebetKredet
                        fm.ShowDialog()
                        fm.Dispose()
                        'Ամփոփ Հաշվետվություն
                    Case 7
                        If CheckPermission("C7C0165590524194AB8D08728EB78277") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New QerySelectToolPaymentAmpop
                        f.ShowDialog()
                        f.Dispose()
                        'Ամփոփ Հաշվետվություն 2
                    Case 8
                        If CheckPermission("50B26A3947B840FABBE07887C513D0BC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New FiveMonthsReport
                        f.ShowDialog()
                        f.Dispose()
                        'Պարտք Ըստ Պատկանելության
                    Case 9
                        If CheckPermission("B3B2845E0C7E41289429E0DED01A7115") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New PartqSelSupporter
                        f.ShowDialog()
                        f.Dispose()

                    Case 10
                        'Վերանորոգում
                        '////////////////////////////////////////////////////////////////////////

                    Case 11  'Քանակային Հաշվետվություն
                        If CheckPermission("A27B048D72CD4C1390644548AF1A590B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New RepSelRemakeDayCounter
                        f.ShowDialog()
                        f.Dispose()
                    Case 12  'Տևողության Հաշվետվություն
                        If CheckPermission("836A24E21D744856BB5DB6FC99D24EF6") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New RepRemakeTimeCounter
                        f.ShowDialog()
                        f.Dispose()
                    Case 13  'Վերանորոգում
                        If CheckPermission("369C21A89967410098B02A3888A2E902") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New QerySelectToolRemakeRep
                        f.ShowDialog()
                        f.Dispose()
                    Case 14  'Կրկնվող Վերանորոգումներ
                        If CheckPermission("7138332DD73D4EAA9174AF2686AF1DDB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New MultiRemakeSelect
                        f.ShowDialog()
                        f.Dispose()
                        'Անվճար Վերանորոգումներ
                    Case 15
                        If CheckPermission("1D5C6256212441B7987CD23A4188ED05") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New NonPayedRemakeSelTool
                        f.ShowDialog()
                        f.Dispose()
                        'ՀԴՄ-ի Տեղաշարժ
                    Case 16
                        If CheckPermission("45804AAD066F41EDA11596F174CFB645") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New QerySelectToolEcrLocation
                        f.ShowDialog()
                        f.Dispose()
                        'Ուղարկված SMS
                    Case 17
                        If CheckPermission("425E9D6AB3EA4D53851C201476E9D0D4") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRemakeSendSMS")
                        Dim f As New RemakeSendSMS
                        AddChildForm("nRemakeSendSMS", f)
                        'Տեսուչի Վերանորոգումներ
                    Case 18
                        If CheckPermission("0ECD563464CD4B888C41D763A4946F1B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New TesuchRemSelect
                        f.ShowDialog()
                        f.Dispose()
                    Case 19
                        'ՀԾ
                        '////////////////////////////////////////////////////////////////////////

                    Case 20  'ՀԾ Կոդի Փոփոխում
                        If CheckPermission("7E8913E5FD8E44AE98BDD985E1C09108") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New htsCodeSelector
                        f.ShowDialog()
                        f.Dispose()
                    Case 21
                        'Փոխարինման ՀԴՄ-ներ
                        '////////////////////////////////////////////////////////////////////////

                    Case 22  'Ազատ փոխարինող ՀԴՄ-ներ
                        If CheckPermission("2CA29F587BE640C0A20DC88744434FB5") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTesuchFreeEcrRep")
                        Dim f As New TesuchFreeEcrRep
                        AddChildForm("nTesuchFreeEcrRep", f)
                    Case 23  'Փոխարինման ՀԴՄ-ներ
                        If CheckPermission("1B66DF9072E24788BFF9EF9E958375F4") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New RepDateSelecter
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 24 'Պատկան ՀԴՄ Սրահում
                        If CheckPermission("533EB9CF2A4245308B39970D1F7DFF45") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateSelecterForPatkanEcr
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 25 'ՀԴՄ Փոխարինման Պատմություն
                        If CheckPermission("4B2C0338E1344F169226903BA35066F0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateSelecterPoxarinumHistory
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 26 'Առանց Հայտի Փոխարինող ՀԴՄ
                        If CheckPermission("2CA29F587BE640C0A20DC88744434FB5") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTesuchEcrRep")
                        Dim f As New TesuchEcrRep
                        AddChildForm("nTesuchEcrRep", f)
                    Case 27 '  Փոխարինող ՀԴՄ տարբերություն
                        If CheckPermission("3AF665F049BF4DDFBA8ADEF761A09AE9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New EcrRepChanges
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 28
                        'Հաշիվ Ապրանքագիր
                        '////////////////////////////////////////////////////////////////////////

                        'Չվերադարձված Հ/Ա
                    Case 29
                        If CheckPermission("6AA8A0652A1344879939250A7BEBC6DA") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateNotRetInvoice
                        fm.ShowDialog()
                        fm.Dispose()
                        'Սպասարկման Հ/Ա
                    Case 30
                        If CheckPermission("FC47803AE0564BEE85ACCBC357B529A0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateServiceInvoice
                        fm.ShowDialog()
                        fm.Dispose()
                        'Վերանորոգման Հ/Ա
                    Case 31
                        If CheckPermission("005AACC528CD4F9283197F32353598C3") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateRemakeInvoice
                        fm.ShowDialog()
                        fm.Dispose()
                        'Վաճառքի Հ/Ա
                    Case 32
                        If CheckPermission("3F26A0773F704D759A5598290A117AAC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateSoldInvoice
                        fm.ShowDialog()
                        fm.Dispose()
                        'Շրջիկ Հ/Ա
                    Case 33
                        If CheckPermission("95408598AF9D4A61B4A27676A4D89B7B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateShrjikInvoice
                        fm.ShowDialog()
                        fm.Dispose()
                        'Բոլորը Հ/Ա
                    Case 34
                        If CheckPermission("B95650760F5448CAB08A9826758AF2A9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New SelDateRepAllInv
                        f.ShowDialog()
                        f.Dispose()
                    Case 35
                        'Տեսուչի Այց
                        '////////////////////////////////////////////////////////////////////////

                        'Տեսուչի Այց
                    Case 36
                        If CheckPermission("FC62466D41E4489FB7C82F4B0E02C94E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateTesuch
                        fm.ShowDialog()
                        fm.Dispose()
                        'Տեսուչի ՀԴՄ
                    Case 37
                        If CheckPermission("F9C28B294BF1441791B97C900F6D87DA") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRepTesuchEcr")
                        Dim f As New RepTesuchEcr
                        AddChildForm("nRepTesuchEcr", f)
                    Case 38
                        'Վերագրանցում
                        '////////////////////////////////////////////////////////////////////////

                        'Վերագրանցում
                    Case 39
                        If CheckPermission("EDE760A952904A9AB172EDD453156D9E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRepReRegisterList")
                        Dim f As New RepReRegisterList
                        AddChildForm("nRepReRegisterList", f)
                    Case 40
                        'Արգելափակ GPRS
                        '////////////////////////////////////////////////////////////////////////

                        'Արգելափակված GPRS
                    Case 41
                        If CheckPermission("D34DA4157C9740AA9B6704A04FF70089") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nBlockedHDMGprs")
                        Dim f As New BlockedGPRS
                        AddChildForm("nBlockedHDMGprs", f)
                    Case 42
                        If CheckPermission("8E290AA416B845199ED0AF5C688DA85B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRepmustBeDisabled")
                        Dim f As New RepmustBeDisabled
                        AddChildForm("nRepmustBeDisabled", f)
                    Case 43
                        'Նամակներ և SMS
                        '////////////////////////////////////////////////////////////////////////

                        'Ուղարկված Նամակ
                    Case 44
                        If CheckPermission("46BA851D87504C828B3B4EDDF8D8A7FD") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nEmailViewer")
                        Dim f As New EmailViewerWindow
                        AddChildForm("nEmailViewer", f)
                        'Ուղարկված SMS
                    Case 45
                        If CheckPermission("69E2706305F04A22A49C6493EB2D7BDC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nSMSViewSentItems")
                        Dim f As New smsViewerWindow
                        AddChildForm("nSMSViewSentItems", f)
                    Case 46
                        'GPRS
                        '////////////////////////////////////////////////////////////////////////

                        'GPRS-ի Փոփոխություն
                    Case 47
                        If CheckPermission("9A6184827F5F4E71B7EFE6402EEC69B7") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRepGprsChanges")
                        Dim f As New RepGprsChanges
                        AddChildForm("nRepGprsChanges", f)
                        'Առկա GPRS Քարտ
                    Case 48
                        If CheckPermission("EDE07C814F47407EB047A801FDD0281A") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRepGprsAll")
                        Dim f As New RepGprsAll
                        AddChildForm("nRepGprsAll", f)
                        'Ավելացված Բայց Չհաստատված Քարտ
                    Case 49
                        If CheckPermission("50EE720F5E6D4AD7814C4B248FAF9258") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nrepNotApprovedGPRS")
                        Dim f As New repNotApprovedGPRS
                        AddChildForm("nrepNotApprovedGPRS", f)
                        'Orange Ընթացիկ Կարգավիճակներ
                    Case 50
                        If CheckPermission("AF226D727A014AFDB0A989A6D4221FE9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nGprsIntermediate")
                        Dim f As New GprsIntermediate With {.isAll = True}
                        AddChildForm("nGprsIntermediate", f)
                        'GPRS Իրական Կարգավիճակ
                    Case 51
                        If CheckPermission("47C4D84727584F5FA56B98628B51E8D9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New GprsRealStatus
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 52
                        'ՀԴՄ Վիճակագրություն
                        '////////////////////////////////////////////////////////////////////////

                        'ՀԴՄ Վիճակագրություն
                    Case 53
                        If CheckPermission("404DD8C088524055A1D05773C54FD392") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nEcrStatistics")
                        Dim f As New EcrStatistics
                        AddChildForm("nEcrStatistics", f)
                    Case 54
                        'Հեռախոս
                        '////////////////////////////////////////////////////////////////////////
                        'Գործընկերոջ Հեռախոս
                    Case 55
                        If CheckPermission("8EF42EBB58354287A7F64754DA2E63C9") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New RepHvhhForTel
                        f.ShowDialog()
                        f.Dispose()
                    Case 56
                        'Լոգ
                        '////////////////////////////////////////////////////////////////////////

                        'TelCell Events
                    Case 57
                        If CheckPermission("531A3E214F804CCCA0928A6FB5F5234C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTelCellLogEventsWindow")
                        Dim f As New LogEventsAll With {.LE = LogEventsAll.T.TelCellLogEvent}
                        AddChildForm("nTelCellLogEventsWindow", f)
                        'TelCell Payments
                    Case 58
                        If CheckPermission("D5622632FACA4149B9ED825B0D96FB81") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTelCellPayment")
                        Dim f As New LogEventsAll With {.LE = LogEventsAll.T.TelCellPayment}
                        AddChildForm("nTelCellPayment", f)
                        'Orange Events
                    Case 59
                        If CheckPermission("F2E1BB0353E9449EB2CA2DA219EFC9C4") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nOrangeEventLog")
                        Dim f As New LogEventsAll With {.LE = LogEventsAll.T.OrangeLogEvent}
                        AddChildForm("nOrangeEventLog", f)

                    Case 60
                        'Կոորդինատներ
                        '////////////////////////////////////////////////////////////////////////
                    Case 61
                        If CheckPermission("86039A7E2D6F4E4F9E5B379523219E4D") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nMapProp")
                        Dim f As New MapProp
                        AddChildForm("nMapProp", f)

                    Case 62
                        'Տեսուչ ՀԴՄ Վիճակագրություն
                        '////////////////////////////////////////////////////////////////////////

                        'Տեսուչ ՀԴՄ Հաշվետվություն
                    Case 63
                        If CheckPermission("7094CBEF500943A5926699F1725D4A70") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nEcrTesuchRep")
                        Dim f As New EcrTesuchRep
                        AddChildForm("nEcrTesuchRep", f)
                End Select
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#Region "Հաշվապահություն"

    Private Sub AcountTreeList_DoubleClick(sender As Object, e As EventArgs) Handles AcountTreeList.DoubleClick
        Try
            Dim tree As TreeList = TryCast(sender, TreeList)
            Dim hi As TreeListHitInfo = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition))

            If hi.Node IsNot Nothing Then
                Select Case hi.Node.Id
                    Case 0
                        'Վճարներ
                        '////////////////////////////////////////////////////////////////////////

                        'Վճարների Մուտքագրում
                    Case 1
                        If CheckPermission("F1FD2572CEF74F86A4A3F93C84BDD69C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nAddPaymentWin")
                        Dim f As New payWindow
                        AddChildForm("nAddPaymentWin", f)
                        'Բանկային Տվյալների Ստուգում
                    Case 2
                        If CheckPermission("FB41CB18707F4A63BC498DCB036B3BF0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New SelectBankFile
                        fm.ShowDialog()
                        fm.Dispose()
                        'TelCell Վճարների Հաստատում
                    Case 3
                        If CheckPermission("80C5DB191AEB4C52929E92832780E348") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nTelCellFileSelecter")
                        Dim f As New TelCellFileSelecter
                        AddChildForm("nTelCellFileSelecter", f)
                    Case 4
                        'Հաշիվ Ապրանքագիր
                        '////////////////////////////////////////////////////////////////////////
                    Case 5
                        'Սպասարկման
                        '////////////////////////////////////////////////////////////////////////

                        'Ընթացիկ Հ/Ա
                    Case 6
                        If CheckPermission("DC565D749ADF4CEF93382AE8FA73AAC1") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nReRegInvoice")
                        Dim f As New ReRegInvoice
                        AddChildForm("nReRegInvoice", f)
                        'Սպասարկման Հ/Ա
                    Case 7
                        If CheckPermission("BCAEB19836BB47C18D05F6294BC11E22") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nSupportInvoice")
                        Dim f As New SupportInvoice
                        AddChildForm("nSupportInvoice", f)
                        'Հ/Ա Շրջիկ
                    Case 8
                        If CheckPermission("27D4F96EF7CD46D8BDFE1196E51F526B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

                        ''''''''''''''''''''''''''''''''''''''''''''''''''   Կոդը չկա

                        'Փոխել Հ/Ա Տվյալները
                    Case 9
                        If CheckPermission("598734DB5B89437C87E9E495CACBE251") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New UpdateInvoiceWindow
                        fm.ShowDialog()
                        fm.Dispose()
                        'Ջնջել Սպասարկման Հ/Ա
                    Case 10
                        If CheckPermission("BC4A475917A74FC3802FF4F98A267C23") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DeleteInvoiceWindow
                        fm.ShowDialog()
                        fm.Dispose()
                        'Չտպված Սպասարկման Հ/Ա
                    Case 11
                        If CheckPermission("EC3C09F1DF1E4F7D83F85E2F7D05C907") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New printNoPrintInvoiceSelect
                        fm.cNoPrinted.Checked = True
                        fm.btnSelect.Location = New Point(96, 101)
                        fm.Size = New Size(293, 185)
                        fm.GroupBox1.Visible = False
                        fm.ShowDialog()
                        fm.Dispose()
                        'Չտպված Հավելվածներ
                    Case 12
                        If CheckPermission("C7AAB12B501E497EB1AC79C358FE2660") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New DateSelect
                        fm.ShowDialog()
                        fm.Dispose()

                        'Տպված Ինվոյս
                    Case 13
                        If CheckPermission("6A6270584F664A9AB901D02807DE63CB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New printNoPrintInvoiceSelect
                        fm.ShowDialog()
                        fm.Dispose()
                        'Հ/Ա Վերադարձ
                    Case 14
                        If CheckPermission("6A6270584F664A9AB901D02807DE9999") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New ReturnNotRetInvoice
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 15
                        'Սարքավորման Վաճառքի Հ/Ա
                        '////////////////////////////////////////////////////////////////////////

                        'Գեներացնել Ներքին Ինվոյս
                    Case 16
                        If CheckPermission("F43C45EA9D1C4C88A3DCD6655DC2F117") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New InnerInvoiceXMLSelector
                        fm.ShowDialog()
                        fm.Dispose()
                        'Գեներացնել Սարքավորման Ինվոյս
                    Case 17
                        If CheckPermission("611231905EAE40A583B7057B4181B442") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New RemakeInvoiceXMLSelector
                        fm.ShowDialog()
                        fm.Dispose()
                        'Գեներացնել Վաճառքի Ինվոյս
                    Case 18
                        If CheckPermission("6FA14DC18E2E425CA8DE7F34AC72EA9B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New SellInvoiceXMLSelector
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 19
                        'Տեղեկատուներ
                        '////////////////////////////////////////////////////////////////////////

                        'ԱԱՀ-ից ազատված գործընկեր
                    Case 20
                        If CheckPermission("60FE011E74B54CCF93982D0EEEC5CAE7") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRepNoNDS")
                        Dim f As New RepNoNDS
                        AddChildForm("nRepNoNDS", f)
                        'Չսպասարկվող Գործընկեր
                    Case 21
                        If CheckPermission("4381A79A288A43C3B008C8C4A71E8A8B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nRepNoSupport")
                        Dim f As New RepNoSupport
                        AddChildForm("nRepNoSupport", f)
                        'PDF-ով Չտպվող
                    Case 22
                        If CheckPermission("E66BC93651694F07B50CA9E5B2608050") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nExcludedHvhhForInvoice")
                        Dim f As New ExcludedHvhhForInvoice
                        AddChildForm("nExcludedHvhhForInvoice", f)
                        'Հ/Ա PDF-ի Կարգաբերում
                    Case 23
                        If CheckPermission("2C720AFD51BA4578B8E7D0AD28689485") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New PDF_Searcher
                        fm.ShowDialog()
                        fm.Dispose()
                        'PDF-Ի Էջերի Ստացում
                    Case 24
                        If CheckPermission("C565D69E31B9484F8B5BE430E97FD95E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call PdfFileSelecter()
                    Case 25
                        If CheckPermission("6F2C3728C7344E15ACCD2AFD7167A065") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New AcountWarhExSel
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 26
                        If CheckPermission("FD2DDCCE0ECB4F63B209085070F2A32B") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim fm As New XML_Dublicate_Checker
                        fm.ShowDialog()
                        fm.Dispose()
                    Case 27
                        If CheckPermission("209045D6E2444F50A4D2F01226F5B625") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("npahanj")
                        Dim f As New pahanj
                        AddChildForm("npahanj", f)
                End Select
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#Region "Զանգերի Կենտրոն"

    Private Sub CallCenterTreeList_DoubleClick(sender As Object, e As EventArgs) Handles CallCenterTreeList.DoubleClick
        Try
            Dim tree As TreeList = TryCast(sender, TreeList)
            Dim hi As TreeListHitInfo = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition))

            If hi.Node IsNot Nothing Then
                Select Case hi.Node.Id
                    Case 0  'Հայտեր
                        '////////////////////////////////////////////////////////////////////////
                    Case 1  'Ակտիվացման Հայտ
                        If CheckPermission("868D1C12CC42465BA7DCAE2B279CD58F") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nCallHaytActivate")
                        Dim f As New CallHaytActivate
                        AddChildForm("nCallHaytActivate", f)
                    Case 2  'Ընդհանուր Հայտ
                        If CheckPermission("3B90FF27CB3F484493120D340DC196C7") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Call CloseWindow("nCallHaytGeneral")
                        Dim f As New CallHaytGeneral
                        AddChildForm("nCallHaytGeneral", f)
                    Case 3  'Խմբագրել Ակտիվացման Հայտերը
                        If CheckPermission("E4060F573FE342B496EC629A3E7FCD33") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        'Call CloseWindow("nActiveHaytWin")
                        'Dim f As New ActiveHaytWin
                        'AddChildForm("nActiveHaytWin", f)
                        Dim f As New EditActivateHayt
                        f.ShowDialog()
                        f.Dispose()
                    Case 4  'Խմբագրել Ընդհանուր Հայտերը
                        If CheckPermission("7D0D71A6422748108546B1AEB559B2F7") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        MessageBox.Show("Խնդրում եմ օգտվել ՛Խմբագրել Ակտիվացման Հայտերը՛ մենյուից", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Dim f As New EditGeneralHayt
                        'f.ShowDialog()
                        'f.Dispose()
                    Case 5  'Դիտել Ակտիվացման Հայտերը
                        If CheckPermission("A2ADDECDE9034B91A442C5707C428D20") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New ViewActivateHaytSelector
                        f.ShowDialog()
                        f.Dispose()
                    Case 6  'Դիտել Ընդհանուր Հայտերը
                        If CheckPermission("77AECB3F04294AD499F19BE5CA500ECB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New ViewGeneralHaytSelector
                        f.ShowDialog()
                        f.Dispose()
                    Case 7  'Ուղրկել Անհատական SMS
                        If CheckPermission("DFF9FC21F14049A6BAF6EF28CD3D407C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New CustomSMS
                        f.ShowDialog()
                        f.Dispose()
                    Case 8  'Փակ Հայտեր
                        If CheckPermission("8F4410403E1840749FF38A9432E52718") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New ClosedPropSelect
                        f.ShowDialog()
                        f.Dispose()
                    Case 9  'Բաց Հայտեր
                        If CheckPermission("A944BA07C90846CF89FE2CB08C2AF7AC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New OpenPropSelector
                        f.ShowDialog()
                        f.Dispose()
                    Case 10 'Հայտի Վերլուծություն
                        If CheckPermission("6E2805538310451AB4DEBE862115E6A5") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
                        Dim f As New SelectPropAnalitics
                        f.ShowDialog()
                        f.Dispose()

                End Select
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#End Region

#Region "Header"

#Region "Ինտեգրացիա"

    Private Sub btnExportToExcel2013_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportToExcel2013.ItemClick
        Try
            Dim activeChild As Form = Me.ActiveMdiChild
            Dim currentForm As Form = Form.ActiveForm

            If currentForm.Name <> Me.Name Then
                ExportTo(ExportType.Excel2013, currentForm)
            Else
                If (Not activeChild Is Nothing) Then
                    ExportTo(ExportType.Excel2013, activeChild)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnExportToExcel2003_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportToExcel2003.ItemClick
        Try
            Dim activeChild As Form = Me.ActiveMdiChild
            Dim currentForm As Form = Form.ActiveForm

            If currentForm.Name <> Me.Name Then
                ExportTo(ExportType.Excel2003, currentForm)
            Else
                If (Not activeChild Is Nothing) Then
                    ExportTo(ExportType.Excel2003, activeChild)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnExportToPDF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportToPDF.ItemClick
        Try
            Dim activeChild As Form = Me.ActiveMdiChild
            Dim currentForm As Form = Form.ActiveForm

            If currentForm.Name <> Me.Name Then
                ExportTo(ExportType.Pdf, currentForm)
            Else
                If (Not activeChild Is Nothing) Then
                    ExportTo(ExportType.Pdf, activeChild)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnExportToText_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportToText.ItemClick
        Try
            Dim activeChild As Form = Me.ActiveMdiChild
            Dim currentForm As Form = Form.ActiveForm

            If currentForm.Name <> Me.Name Then
                ExportTo(ExportType.TEXT, currentForm)
            Else
                If (Not activeChild Is Nothing) Then
                    ExportTo(ExportType.TEXT, activeChild)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnExportToWord_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportToWord.ItemClick
        Try
            Dim activeChild As Form = Me.ActiveMdiChild
            Dim currentForm As Form = Form.ActiveForm

            If currentForm.Name <> Me.Name Then
                ExportTo(ExportType.RTF, currentForm)
            Else
                If (Not activeChild Is Nothing) Then
                    ExportTo(ExportType.RTF, activeChild)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnExcelToDB_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExcelToDB.ItemClick
        If CheckPermission2("2F4789C139FB448F89CA13B9738B06E1") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        Dim f As New ExcelToSQLWindow
        f.ShowDialog()
        f.Dispose()
    End Sub
    Private Sub btnCorrectDB_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCorrectDB.ItemClick
        If CheckPermission2("E2E8DBFB0A584BE7A9CF990F681A6FE6") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
        Dim f As New CorrectMiddleDB
        f.ShowDialog()
        f.Dispose()
    End Sub

#End Region

#Region "Տեսք"

    Private Sub btnShowPanel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowPanel.ItemClick
        If MenuPanel.Visibility = DockVisibility.Hidden Then
            MenuPanel.Visibility = DockVisibility.Visible
        Else
            MenuPanel.Visibility = DockVisibility.Hidden
        End If
    End Sub
    Private Sub btnShowInformer_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowInformer.ItemClick
        If InfoPanel.Visibility = DockVisibility.Hidden Then
            InfoPanel.Visibility = DockVisibility.Visible
        Else
            InfoPanel.Visibility = DockVisibility.Hidden
        End If
    End Sub
    Private Sub btnLayoutReset_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnLayoutReset.ItemClick
        On Error Resume Next
        If MsgBox("Գործողությունը կատարելուց հետո ծրագիրը վերաբեռնվելու է, ցանկանու՞մ եք կատարել գործողությունը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then
            isResetedLayout = True
            My.Computer.Registry.CurrentUser.DeleteSubKeyTree(("Software\Ecr"))
            Application.Restart()
        End If
    End Sub

#Region "Skin"

    Private Sub PMOffice2010_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2010.ItemClick
        SetTheme("Office 2010 Blue")
    End Sub
    Private Sub PMOffice2010Black_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2010Black.ItemClick
        SetTheme("Office 2010 Black")
    End Sub
    Private Sub PMOffice2010Silver_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2010Silver.ItemClick
        SetTheme("Office 2010 Silver")
    End Sub

    Private Sub PMOffice2013_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2013.ItemClick
        SetTheme("Office 2013")
    End Sub
    Private Sub PMOffice2013DarkGray_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2013DarkGray.ItemClick
        SetTheme("Office 2013 Dark Gray")
    End Sub
    Private Sub PMOffice2013LightGray_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2013LightGray.ItemClick
        SetTheme("Office 2013 Light Gray")
    End Sub

    Private Sub PMOffice2007Blue_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2007Blue.ItemClick
        SetTheme("Office 2007 Blue")
    End Sub
    Private Sub PMOffice2007Black_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2007Black.ItemClick
        SetTheme("Office 2007 Black")
    End Sub
    Private Sub PMOffice2007Silver_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2007Silver.ItemClick
        SetTheme("Office 2007 Silver")
    End Sub
    Private Sub PMOffice2007Green_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2007Green.ItemClick
        SetTheme("Office 2007 Green")
    End Sub
    Private Sub PMOffice2007Pink_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMOffice2007Pink.ItemClick
        SetTheme("Office 2007 Pink")
    End Sub

    Private Sub PMDevExpress_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMDevExpress.ItemClick
        SetTheme("DevExpress Style")
    End Sub
    Private Sub PMiMaginary_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMiMaginary.ItemClick
        SetTheme("iMaginary")
    End Sub
    Private Sub PMLilian_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMLilian.ItemClick
        SetTheme("Lilian")
    End Sub
    Private Sub PMMoneyTwins_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMMoneyTwins.ItemClick
        SetTheme("Money Twins")
    End Sub
    Private Sub PMCaramel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMCaramel.ItemClick
        SetTheme("Caramel")
    End Sub
    Private Sub PMTheAsphalt_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMTheAsphalt.ItemClick
        SetTheme("The Asphalt")
    End Sub
    Private Sub PMFoggy_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMFoggy.ItemClick
        SetTheme("Foggy")
    End Sub
    Private Sub PMDarkSide_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMDarkSide.ItemClick
        SetTheme("Dark Side")
    End Sub
    Private Sub PMCoffee_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMCoffee.ItemClick
        SetTheme("Coffee")
    End Sub

    Private Sub PMBlue_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMBlue.ItemClick
        SetTheme("Blue")
    End Sub
    Private Sub PMBlack_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMBlack.ItemClick
        SetTheme("Black")
    End Sub
    Private Sub PMSharp_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMSharp.ItemClick
        SetTheme("Sharp")
    End Sub
    Private Sub PMSeven_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMSeven.ItemClick
        SetTheme("Seven")
    End Sub
    Private Sub PMSevenClassic_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMSevenClassic.ItemClick
        SetTheme("Seven Classic")
    End Sub
    Private Sub PMMetropolis_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMMetropolis.ItemClick
        SetTheme("Metropolis")
    End Sub
    Private Sub PMMetropolisDark_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMMetropolisDark.ItemClick
        SetTheme("Metropolis Dark")
    End Sub

    Private Sub PMVS2010_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMVS2010.ItemClick
        SetTheme("VS2010")
    End Sub
    Private Sub PMVisualStudio2013Blue_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMVisualStudio2013Blue.ItemClick
        SetTheme("Visual Studio 2013 Blue")
    End Sub
    Private Sub PMVisualStudio2013Dark_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMVisualStudio2013Dark.ItemClick
        SetTheme("Visual Studio 2013 Dark")
    End Sub
    Private Sub PMVisualStudio2013Light_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PMVisualStudio2013Light.ItemClick
        SetTheme("Visual Studio 2013 Light")
    End Sub

#End Region

#End Region

#Region "Գլխավոր"

    'Print
    Private Sub btnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        Try
            Dim activeChild As Form = Me.ActiveMdiChild
            Dim currentForm As Form = Form.ActiveForm

            If currentForm.Name <> Me.Name Then
                PrintData(currentForm, PrintTypes.Print)
            Else
                If (Not activeChild Is Nothing) Then
                    PrintData(activeChild, PrintTypes.Print)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    'Print Preview
    Private Sub btnPrintPreview_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrintPreview.ItemClick
        Try
            Dim activeChild As Form = Me.ActiveMdiChild
            Dim currentForm As Form = Form.ActiveForm

            If currentForm.Name <> Me.Name Then
                PrintData(currentForm, PrintTypes.PrintPreview)
            Else
                If (Not activeChild Is Nothing) Then
                    PrintData(activeChild, PrintTypes.PrintPreview)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    'Print Setup
    Private Sub btnPrintSetup_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrintSetup.ItemClick
        Try
            Dim activeChild As Form = Me.ActiveMdiChild
            Dim currentForm As Form = Form.ActiveForm

            If currentForm.Name <> Me.Name Then
                PrintData(currentForm, PrintTypes.ShowSetup)
            Else
                If (Not activeChild Is Nothing) Then
                    PrintData(activeChild, PrintTypes.ShowSetup)
                End If
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    'Close All Forms
    Private Sub btnCloseAllWindows_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCloseAllWindows.ItemClick
        On Error Resume Next

        If MsgBox("Ցանկանու՞մ եք փակել բոլոր պատուհանները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub
        For Each mf As Form In Me.MdiChildren
            mf.Close()
        Next

        Dim frm As New List(Of Form)

        For Each mf As Form In My.Application.OpenForms
            If mf.Name <> "LoginWindow" AndAlso mf.Name <> "MainWindow" Then
                frm.Add(mf)
            End If
        Next

        For i As Integer = 0 To frm.Count - 1
            frm.Item(i).Close()
        Next
    End Sub

#End Region

#Region "Գործողություն"

    Private Sub btnAddRecord_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddRecord.ItemClick
        Call CrudAction(Crud.Insert)
    End Sub
    Private Sub btnDeleteRecord_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDeleteRecord.ItemClick
        Call CrudAction(Crud.Delete)
    End Sub
    Private Sub btnChangeRecord_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnChangeRecord.ItemClick
        Call CrudAction(Crud.Update)
    End Sub
    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFind.ItemClick
        SendKeys.Send("^(f)")
    End Sub

#End Region

#Region "About"

    Private Sub btnAboutProgram_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAboutProgram.ItemClick
        Dim f As New AboutApp
        f.ShowDialog()
        f.Dispose()
    End Sub
    Private Sub btnCheckForUpdate_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCheckForUpdate.ItemClick
        Try
            Dim ver As String = iDB.GetAppVersion()
            Dim mainVer As Version = New Version(ver)

            If My.Application.Info.Version.CompareTo(mainVer) = -1 Then
                MsgBox("Առկա է ծրագրի նոր տարբերակ", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Else
                MsgBox("Ձեր ծրագիրը թարմեցված է", MsgBoxStyle.Information, My.Application.Info.Title)
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnUpdateSoft_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUpdateSoft.ItemClick
        Try
            Dim ver As String = iDB.GetAppVersion()
            Dim mainVer As Version = New Version(ver)

            If My.Application.Info.Version.CompareTo(mainVer) = -1 Then
                Dim f As New downloader
                f.ShowDialog()
                Dim b As Boolean = f.isOK
                f.Dispose()
                If b = False Then MsgBox("Ծրագրի թարմեցման ժամանակ տեղի է ունեցել սխալ")
            Else
                MsgBox("Ձեր ծրագիրը թարմեցված է", MsgBoxStyle.Information, My.Application.Info.Title)
                Exit Sub
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#End Region

#Region "Title Buttons"

    Private Sub btnTitleAddRecord_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnTitleAddRecord.ItemClick
        Call btnAddRecord_ItemClick(btnAddRecord, Nothing)
    End Sub
    Private Sub btnTitleUpdateRecord_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnTitleUpdateRecord.ItemClick
        Call btnChangeRecord_ItemClick(btnChangeRecord, Nothing)
    End Sub
    Private Sub btnTitleDeleteRecord_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnTitleDeleteRecord.ItemClick
        Call btnDeleteRecord_ItemClick(btnDeleteRecord, Nothing)
    End Sub
    Private Sub btnTitleExportToExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnTitleExportToExcel.ItemClick
        Call btnExportToExcel2013_ItemClick(btnExportToExcel2013, Nothing)
    End Sub
    Private Sub btnTitlePrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnTitlePrint.ItemClick
        Call btnPrint_ItemClick(btnPrint, Nothing)
    End Sub

#End Region

#Region "Office Menu"

    Private Sub cmdSelectPrinter_ItemClick(sender As Object, e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles cmdSelectPrinter.ItemClick
        Dim f As New SelectPrinter
        f.ShowDialog()
        f.Dispose()
    End Sub
    Private Sub cmdExitApp_ItemClick(sender As Object, e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles cmdExitApp.ItemClick
        LoginWindow.Close()
    End Sub
    Private Sub cmdChangePassword_ItemClick(sender As Object, e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles cmdChangePassword.ItemClick
        Dim f As New Change_Password
        f.ShowDialog()
        f.Dispose()
    End Sub

#End Region

#Region "User Group"

    ' Load Group
    Private Sub tbUserGroup_ItemPressed(sender As Object, e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles tbUserGroup.ItemPressed
        Try
            Dim dt As DataTable = iDB.GetUserGroupList()

            With cbSelectGroup
                .DataSource = dt
                .DisplayMember = "GroupName"
                .ValueMember = "GroupID"
                '.SelectedIndex = 0
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'Add Group
    Private Sub btnCreateGroup_Click(sender As Object, e As EventArgs) Handles btnCreateGroup.Click
        Try
            If CheckPermission2("3E1644EFE38E4B2DAD5483FAE287D6C0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
            If txtNewGroup.Text.Trim = String.Empty Then Throw New Exception("Խմբի անունը գրված չէ")

            iDB.InsertUserGroup(txtNewGroup.Text.Trim)

            tbUserGroup_ItemPressed(tbUserGroup, Nothing)

            txtNewGroup.Text = String.Empty
            txtNewGroup.Focus()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'Delete Group
    Private Sub btnDeleteGroup_Click(sender As Object, e As EventArgs) Handles btnDeleteGroup.Click
        Try
            If CheckPermission2("3E1644EFE38E4B2DAD5483FAE287D6C0") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")
            If cbSelectGroup.Items.Count = 0 Then Exit Sub

            If MsgBox("Ցանկանու՞մ եք ջնջել խումբը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            Dim id As Short = cbSelectGroup.SelectedValue

            iDB.DeleteUserGroup(id)

            tbUserGroup_ItemPressed(tbUserGroup, Nothing)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub


    'Load User Info: Group
    Private Sub tbNewUser_SelectedChanged(sender As Object, e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles tbNewUser.SelectedChanged
        Try
            Dim dt As DataTable = iDB.GetUserGroupList()

            With cbGroupSelect
                .DataSource = dt
                .DisplayMember = "GroupName"
                .ValueMember = "GroupID"
                '.SelectedIndex = 0
            End With

            With cbSelectDB
                .Items.Clear()

                .Items.Add("HS")
                .Items.Add("TE")
                .Items.Add("MK")
                .Items.Add("TM")
                .Items.Add("NA")
                .Items.Add("SS")
                .Items.Add("TP")

                .SelectedIndex = 4
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    'Add User
    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Try
            If CheckPermission2("C37691DD1DA641FC810B8CAD0ED83CBC") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If txtLogin.Text.Trim = String.Empty Then Throw New Exception("Օգտանունը գրված չէ")
            If txtUserPassword.Text.Trim = String.Empty Then Throw New Exception("Գաղտնաբառը գրված չէ")
            If txtName.Text.Trim = String.Empty Then Throw New Exception("Անունը գրված չէ")
            If txtLastName.Text.Trim = String.Empty Then Throw New Exception("Ազգանունը գրված չէ")

            Dim dbID As Integer = 5
            Select Case cbSelectDB.SelectedIndex
                Case 0
                    dbID = 1
                Case 1
                    dbID = 2
                Case 2
                    dbID = 3
                Case 3
                    dbID = 4
                Case 4
                    dbID = 5
                Case 5
                    dbID = 8
                Case 6
                    dbID = 10
            End Select

            iDB.InsertUsers(txtLogin.Text.Trim, getMd5Hash(txtUserPassword.Text.Trim), txtName.Text.Trim, txtLastName.Text.Trim,
                            cbGroupSelect.SelectedValue, ckIsActiveUser.Checked, dbID, chPassChange.Checked, txtComment.Text.Trim)

            txtLogin.Text = String.Empty
            txtUserPassword.Text = String.Empty
            txtName.Text = String.Empty
            txtLastName.Text = String.Empty
            ckIsActiveUser.Checked = False
            chPassChange.Checked = True
            txtComment.Text = String.Empty

            tbNewUser_SelectedChanged(tbNewUser, Nothing)

            txtLogin.Focus()

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    'Change User Info
    Private Sub tbChangeUser_SelectedChanged(sender As Object, e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles tbChangeUser.SelectedChanged
        Try
            Dim dt As DataTable = iDB.GetUsersList()
            With cbUserName
                .DataSource = dt
                .DisplayMember = "LoginName"
                .ValueMember = "UserID"
            End With

            Dim dt3 As DataTable = iDB.GetUserGroupList()
            With cbUserOldGroup
                .DataSource = dt3
                .DisplayMember = "GroupName"
                .ValueMember = "GroupID"
                .SelectedValue = iUser.UserID
            End With

            Dim dt2 As DataTable = iDB.GetUserGroupList()
            With cbNewUserGroup
                .DataSource = dt2
                .DisplayMember = "GroupName"
                .ValueMember = "GroupID"
            End With

            With cbUserDB
                .Items.Clear()
                .Items.Add("NA")
                .Items.Add("HS")
                .Items.Add("TE")
                .Items.Add("MK")
                .Items.Add("TM")
                .Items.Add("SS")
                .Items.Add("TP")
                .SelectedIndex = 0
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub cbUserName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUserName.SelectedIndexChanged
        On Error Resume Next

        Dim id As Short = cbUserName.SelectedValue

        Dim dt As DataTable = iDB.GetUserInfo(id)

        cbUserOldGroup.SelectedValue = dt.Rows(0)("GroupID")
        ckIsUserActive.Checked = dt.Rows(0)("ActiveStatus")

        Select Case dt.Rows(0)("dbSupporterID")
            Case 1
                cbUserDB.SelectedItem = "HS"
            Case 2
                cbUserDB.SelectedItem = "TE"
            Case 3
                cbUserDB.SelectedItem = "MK"
            Case 4
                cbUserDB.SelectedItem = "TM"
            Case 5
                cbUserDB.SelectedItem = "NA"
            Case 8
                cbUserDB.SelectedItem = "SS"
            Case 10
                cbUserDB.SelectedItem = "TP"
        End Select
    End Sub
    'Change User Info
    Private Sub btnChangeUserInfo_Click(sender As Object, e As EventArgs) Handles btnChangeUserInfo.Click
        Try
            If CheckPermission2("1B7D266F80D34DE29B30CBCFAA6AE0AB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            'If cbNewUserGroup.SelectedValue = cbUserOldGroup.SelectedValue Then Throw New Exception("Խումբը տարբեր պետք է լինի")

            Dim dbID As Integer = 5
            Select Case cbUserDB.Text
                Case "HS"
                    dbID = 1
                Case "TE"
                    dbID = 2
                Case "MK"
                    dbID = 3
                Case "TM"
                    dbID = 4
                Case "NA"
                    dbID = 5
                Case "SS"
                    dbID = 8
                Case "TP"
                    dbID = 10
            End Select

            iDB.ChangeUserInfo(cbNewUserGroup.SelectedValue, ckIsUserActive.Checked, dbID, cbUserName.SelectedValue)

            tbChangeUser_SelectedChanged(tbChangeUser, Nothing)
            cbUserName_SelectedIndexChanged(cbUserName, Nothing)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'Load User List
    Private Sub tbDeleteUser_SelectedChanged(sender As Object, e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles tbDeleteUser.SelectedChanged
        Try
            Dim dt As DataTable = iDB.GetUsersList()
            With cbUserList
                .DataSource = dt
                .DisplayMember = "LoginName"
                .ValueMember = "UserID"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    'Delete User
    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        Try
            If CheckPermission2("BD6E285E45ED4A628FD167778E4AD894") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If MsgBox("Ցանկանու՞մ եք ջնջել օգտվողին", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            Dim id As Short = cbUserList.SelectedValue

            If cbUserList.Text = iUser.LoginName Then Throw New Exception("Դուք չեք կարող ջնջել ջեր օգտանունը")

            iDB.DeleteUser(id)

            tbDeleteUser_SelectedChanged(tbDeleteUser, Nothing)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnChangePermissions_Click(sender As Object, e As EventArgs) Handles btnChangePermissions.Click
        Try
            If CheckPermission2("DBDEB8BEF09040F499DE80676E27465C") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If MsgBox("Ցանկանու՞մ եք փոխել իրավասությունները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            If typePermissions.SelectedIndex = 0 Then
                'Delete Old Permissions
                iDB.DropPermissionsU(permGroup.SelectedValue)
                'Insert New Permisiisions
                For i As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(i, "Ակտիվ") = True Then
                        iDB.InsertPermissionsU(permGroup.SelectedValue, True, GridView2.GetRowCellValue(i, "GUID"))
                    End If
                Next
            ElseIf typePermissions.SelectedIndex = 1 Then
                'Delete Old Permissions
                iDB.DropPermissionsW(permGroup.SelectedValue)
                'Insert New Permisiisions
                For i As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(i, "Ակտիվ") = True Then
                        iDB.InsertPermissionsW(permGroup.SelectedValue, True, GridView2.GetRowCellValue(i, "GUID"))
                    End If
                Next
            Else


            End If

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            btnCancelLoad.PerformClick()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnCancelLoad_Click(sender As Object, e As EventArgs) Handles btnCancelLoad.Click
        On Error Resume Next
        permGroup.Enabled = True
        typePermissions.Enabled = True
        btnLoadPerm.Enabled = True
        btnChangePermissions.Enabled = False

        GridControl2.BeginUpdate()
        GridControl2.DataSource = Nothing
        GridView2.Columns.Clear()

        GridControl2.DataSource = Nothing

        GridView2.ClearSelection()
        GridControl2.EndUpdate()
    End Sub
    Private Sub BackstageViewTabItem1_ItemPressed(sender As Object, e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles tbUserPermissions.ItemPressed
        Try

            Dim dt As DataTable = iDB.GetUserGroupList()
            With permGroup
                .DataSource = dt
                .DisplayMember = "GroupName"
                .ValueMember = "GroupID"
                '.SelectedIndex = 0
            End With
            typePermissions.SelectedIndex = 0
            GroupControl11.Enabled = True

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnFgroupTgroup_Click(sender As Object, e As EventArgs) Handles btnFgroupTgroup.Click
        If CheckPermission2("DBDEB8BEF09040F499DE80676E27465C") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Critical, My.Application.Info.Title) : Exit Sub
        Dim f As New PermFromTo
        f.ShowDialog()
        f.Dispose()
    End Sub

#End Region

#Region "Coloring Nodes"

    Private Sub ActionTreeList_CustomDrawNodeCell(sender As Object, e As CustomDrawNodeCellEventArgs) Handles ActionTreeList.CustomDrawNodeCell
        On Error Resume Next
        If e.Node.GetValue(0).ToString.EndsWith("*") Then
            e.Appearance.BackColor = Color.FromArgb(117, 209, 255)
            e.Appearance.ForeColor = Color.Black
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        End If
        'If e.Node.Id = 46 OrElse e.Node.Id = 49 OrElse e.Node.Id = 50 OrElse e.Node.Id = 53 Then
        '    e.Appearance.BackColor = Color.FromArgb(117, 209, 255)
        '    e.Appearance.ForeColor = Color.Black
        '    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        'End If
    End Sub

#End Region

#Region "Filter Nodes And Permissions"

    Private Sub ActionTreeList_FilterNode(sender As Object, e As FilterNodeEventArgs) Handles ActionTreeList.FilterNode
        If e.Node.Id = 0 Then
            If CheckPermission("A194D6BC9F564D1BAA3ECEBF56EAAD5D") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 1 Then
            If CheckPermission("8149E1D04AFE4C43A1A81B2B27E965DF") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 2 Then
            If CheckPermission("ABDAE1F9E6884908B840BA2C4B0F3817") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 3 Then
            If CheckPermission("BD9204E949E24ACB9BB691F070953385") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 4 Then
            If CheckPermission("0387762D7054418BB2C7212DBFC53648") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 5 Then
            If CheckPermission("529F861E78684EBE9EE09DC4E5B89F6A") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 6 Then
            If CheckPermission("9D95E8A0A5EF4BF7ABD3D271CC34566D") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 7 Then
            If CheckPermission("6E7F85D395994B5789C1651A76E1F287") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 8 Then
            If CheckPermission("1C859E9CBE9F4406A01CE38A2EEF3DF4") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 9 Then
            If CheckPermission("77B200BBD84F4DADB4FFFDA4377B035C") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 10 Then
            If CheckPermission("D27CC6444B21482C81A87AB79ACD3CDF") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 11 Then
            If CheckPermission("874DF27A12054E17A5B6DB8D8AC750FE") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 12 Then
            If CheckPermission("2B6B1113D956414796E53F2A1647A56A") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 13 Then
            If CheckPermission("45BBCE23E1E446C69CE00AEDF5BC4B44") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 14 Then
            If CheckPermission("DCBD85BE9F6A43159F68B64B72222F33") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 15 Then
            If CheckPermission("0FE2E3E794CE438681BE8267F0B7F410") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 16 Then
            If CheckPermission("05FB334E5AF84A908C864F2CA9413B29") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 17 Then
            If CheckPermission("99E1C38807234D36A30F7148BA074DB2") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 18 Then
            If CheckPermission("9360823FDE4746A294FBF349759BFEC0") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 19 Then
            If CheckPermission("9132657EF0A045FF80433E6E0DC3E9ED") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 20 Then
            If CheckPermission("70326A9271804018A5F894A7117817F3") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 21 Then
            If CheckPermission("282DB48D53424BF4AF73481CE093B3C9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 22 Then
            If CheckPermission("22171AEB3646406691BC382AB49AC145") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 23 Then
            If CheckPermission("B2F89BF559744C1D95F8A47996A3D350") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 24 Then
            If CheckPermission("B2F89BF559744C1D95F8A47996A3D359") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 25 Then
            If CheckPermission("B3BD5DB582574469A049C9C2B57F33B0") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 26 Then
            If CheckPermission("34BF90D3C1D84BB69586FFDA1FE389A4") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 27 Then
            If CheckPermission("835C5DAD85F14F9192BE753F9F9D3134") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 28 Then
            If CheckPermission("2BE4D16252A241E9BEBBC5BE6B46E37C") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 29 Then
            If CheckPermission("B620D1EE214F4768AF96286F5CB3E281") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 30 Then
            If CheckPermission("4BF939352BB44D7A853D9CD7C4EA72AE") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 31 Then
            If CheckPermission("FFCB6B904E8E41939D2CCA5187B43AD9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 32 Then
            If CheckPermission("A982D7FBED2A45F2AE9CD2B57F6F8F44") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 33 Then
            If CheckPermission("2B6BAE83388B4C8AAC3FA07C0ABC5416") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 34 Then
            If CheckPermission("7D1FC7CFFCF44A50BB3543F6021FCB4D") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 35 Then
            If CheckPermission("AA7ABFF5766B46DFB03432178C0A22FB") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 36 Then
            If CheckPermission("A68E621DA9604C9A8F68EFAC7531774D") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 37 Then
            If CheckPermission("5BD10D090F7C454CB6E80A15474E81CE") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 38 Then
            If CheckPermission("7C7D395B41B647E398D265A5B5E1AC20") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 39 Then
            If CheckPermission("026606C89C9449DBBBB864007DF90C57") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 40 Then
            If CheckPermission("79ED7339409148A49324712C84ED707E") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 41 Then
            If CheckPermission("AB2A040842F441BB8A578C0F3C33A7EE") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 42 Then
            If CheckPermission("858A3BDA099344B2812384918418B619") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 43 Then
            If CheckPermission("032886C945DB4C958FF3EE3043E24840") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 44 Then
            If CheckPermission("5DCB4504BC0640EBBC37996DA9FAC4DE") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 45 Then
            If CheckPermission("B3F5707273664E5CBEE4E710AD867D70") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 46 Then
            If CheckPermission("0DA27756076844F79EB565F4C4D520B6") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 47 Then
            If CheckPermission("13AF25BD34BA470688C5378C64D356E9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 48 Then
            If CheckPermission("EE5A3A3242B24DD6915882185C604C79") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 49 Then
            If CheckPermission("815F5E89D1434871AB287276F07CB0C5") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 50 Then
            If CheckPermission("BFC3B50AE7F84FDABEA6C2B3943F8844") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 51 Then
            If CheckPermission("54580B6EEC224AD3BA318F54720CF0E9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 52 Then
            If CheckPermission("3771982E439449E29027A84714962052") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 53 Then
            If CheckPermission("CB67607887E84912A6D6751E71D73064") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 54 Then
            If CheckPermission("938E9275863E4AFFB634DFDA81EAD3E4") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 55 Then
            If CheckPermission("83C069B500D243A1837D67A6AF35AE66") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 56 Then
            If CheckPermission("FA00CA307CB04DAB8FF935026D0D5266") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 57 Then
            If CheckPermission("B2924575445C43D7A15E3FD546FBF214") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 58 Then
            If CheckPermission("78F8ED206D1044EEA1F461D7F231E345") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 59 Then
            If CheckPermission("01F5295314404972B73AB8905D2DF7AE") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 60 Then
            If CheckPermission("3AA18BBFB06244C893F4F637E9B03B27") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 61 Then
            If CheckPermission("9D5A719035B341A083696B17E61D5627") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 62 Then
            If CheckPermission("6680F94061EE45969FD2A361A73A3469") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 63 Then
            If CheckPermission("B5D0A3F215A54CD6B54441149E5DBA54") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 64 Then
            If CheckPermission("39C84C2EB6C14990B74164C1A7D3A8AF") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 65 Then
            If CheckPermission("CDD8026AB52D4D80AC4331393DEF3A73") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 66 Then
            If CheckPermission("AB0E3EB722B948D8AB84F1F32E42C960") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 67 Then
            If CheckPermission("DB24BF62FA9E4589BBCD8DD9AE3F358C") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 68 Then
            If CheckPermission("3164C25231034131AAAB2AE858FEBE61") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 69 Then
            If CheckPermission("B9AB14A979A54C5D8A5EE9679135C130") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 70 Then
            If CheckPermission("3F3048CF83C0421D9FB08174FE163B03") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 71 Then
            If CheckPermission("9B9E041073E84DD5A3CCBAAF244CE10C") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 72 Then
            If CheckPermission("57E6BB4B20B341EDA77D847BC5A0E824") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 73 Then
            If CheckPermission("D47955C2018E4E6F837779CE26403838") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 74 Then
            If CheckPermission("E28EDB75F4EF43C7885A3D5171A0563E") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 75 Then
            If CheckPermission("2384E622118D4FF4AA680ADA98813BED") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If

        End If
    End Sub
    Private Sub WareHouseTreeList_FilterNode(sender As Object, e As FilterNodeEventArgs) Handles WareHouseTreeList.FilterNode
        If e.Node.Id = 0 Then
            If CheckPermission("828F4D985AFF424CA5AA1ED340E86890") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 1 Then
            If CheckPermission("7C876240F6444808BA08ADFBE4792549") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 2 Then
            If CheckPermission("2449D7F3E0BA478D8850ACFAF35AB8A9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 3 Then
            If CheckPermission("0D46642D5ACF49879D4534E0720DE7F1") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 4 Then
            If CheckPermission("4546D4E245A04D3C9AD4C8BD42388E1A") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 5 Then
            If CheckPermission("5FC877D4E3C448F585EA96E4A17D776E") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 6 Then
            If CheckPermission("1AF301E3425B45AFBE386D84CFB322D6") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 7 Then
            If CheckPermission("D1A87BBEB2D64E278772A110027B2888") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 8 Then
            If CheckPermission("0E630C35D9E44090BB1276BF1FD98E57") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 9 Then
            If CheckPermission("CAA1473418BD4619B8CDE369582D10E4") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 10 Then
            If CheckPermission("F7F641C78DC8438789F300134C6CCA3E") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 11 Then
            If CheckPermission("5985506B73B044B99B2636769D5C3B9E") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 12 Then
            If CheckPermission("C746D1566F85420791E7DE8DBCC3A298") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 13 Then
            If CheckPermission("55136453C9EB486A88AA0ABEB3385B29") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 14 Then
            If CheckPermission("D76E9B41BE4A4668B3BAEBBA56F4D1A8") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 15 Then
            If CheckPermission("B73E316484BA4E85BC42B80470444C0F") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 16 Then
            If CheckPermission("D0E24A6DE55742BAB4C4558BEFEF6125") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 17 Then
            If CheckPermission("7AE7A0F92D894D86A575D2F9D3388EF2") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 18 Then
            If CheckPermission("5556B31DA7F347D096612A365C4BDED6") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 19 Then
            If CheckPermission("3B5BEF3DC60A4B97A0704F3654BE1A24") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 20 Then
            If CheckPermission("03025FE5C2124DB68CEF3EE2A85AF4CD") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 21 Then
            If CheckPermission("E28CC06DE63D4F51974C43E844FB0116") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 22 Then
            If CheckPermission("F7233259C8D346769F6591B3C4236E55") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        End If

    End Sub
    Private Sub RepTreeList_FilterNode(sender As Object, e As FilterNodeEventArgs) Handles RepTreeList.FilterNode
        If e.Node.Id = 0 Then
            If CheckPermission("7D9271F2B3A847D99240727CEDF8B0AE") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 1 Then
            If CheckPermission("2AA5C17FC0B34B99AE14D5E24074D8E2") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 2 Then
            If CheckPermission("703CF692319B42C5A51DC7B5F85C1897") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 3 Then
            If CheckPermission("08358DB47FF7408E961CD5A355B307A4") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 4 Then
            If CheckPermission("2B41752CCF84452883849C2081966F33") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 5 Then
            If CheckPermission("9063A58CE5D746188F0BD79FEF0D6BDA") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 6 Then
            If CheckPermission("1F4806DC194945D79D94A9B4A539E974") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 7 Then
            If CheckPermission("C7C0165590524194AB8D08728EB78277") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 8 Then
            If CheckPermission("50B26A3947B840FABBE07887C513D0BC") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 9 Then
            If CheckPermission("B3B2845E0C7E41289429E0DED01A7115") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 10 Then
            If CheckPermission("3EFA9FCAC2A34967A98FF11912F3D3FD") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 11 Then
            If CheckPermission("A27B048D72CD4C1390644548AF1A590B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 12 Then
            If CheckPermission("836A24E21D744856BB5DB6FC99D24EF6") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 13 Then
            If CheckPermission("369C21A89967410098B02A3888A2E902") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 14 Then
            If CheckPermission("7138332DD73D4EAA9174AF2686AF1DDB") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 15 Then
            If CheckPermission("1D5C6256212441B7987CD23A4188ED05") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 16 Then
            If CheckPermission("45804AAD066F41EDA11596F174CFB645") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 17 Then
            If CheckPermission("425E9D6AB3EA4D53851C201476E9D0D4") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 18 Then
            If CheckPermission("0ECD563464CD4B888C41D763A4946F1B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 19 Then
            If CheckPermission("8FB6C436B9C04FE0A2EFCD1B19FC4AE9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 20 Then
            If CheckPermission("7E8913E5FD8E44AE98BDD985E1C09108") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 21 Then
            If CheckPermission("0DBA41D66709429CB8A3F92BD575A8A5") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 22 Then
            If CheckPermission("2CA29F587BE640C0A20DC88744434FB5") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 23 Then
            If CheckPermission("1B66DF9072E24788BFF9EF9E958375F4") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 24 Then
            If CheckPermission("533EB9CF2A4245308B39970D1F7DFF45") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 25 Then
            If CheckPermission("4B2C0338E1344F169226903BA35066F0") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 26 Then
            If CheckPermission("2CA29F587BE640C0A20DC88744434FB5") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 27 Then
            If CheckPermission("3AF665F049BF4DDFBA8ADEF761A09AE9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 28 Then
            If CheckPermission("665E46AFADB243498B2FF7FF91C0C0D4") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 29 Then
            If CheckPermission("6AA8A0652A1344879939250A7BEBC6DA") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 30 Then
            If CheckPermission("FC47803AE0564BEE85ACCBC357B529A0") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 31 Then
            If CheckPermission("005AACC528CD4F9283197F32353598C3") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 32 Then
            If CheckPermission("3F26A0773F704D759A5598290A117AAC") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 33 Then
            If CheckPermission("95408598AF9D4A61B4A27676A4D89B7B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 34 Then
            If CheckPermission("B95650760F5448CAB08A9826758AF2A9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 35 Then
            If CheckPermission("83D37C49FBF44785AB03B5F66D511A9B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 36 Then
            If CheckPermission("FC62466D41E4489FB7C82F4B0E02C94E") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 37 Then
            If CheckPermission("F9C28B294BF1441791B97C900F6D87DA") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 38 Then
            If CheckPermission("2180B782C37D420FAE8AA615452CF04B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 39 Then
            If CheckPermission("EDE760A952904A9AB172EDD453156D9E") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 40 Then
            If CheckPermission("43551208FDEA49CBA03C44092DD0E4EB") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 41 Then
            If CheckPermission("D34DA4157C9740AA9B6704A04FF70089") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 42 Then
            If CheckPermission("8E290AA416B845199ED0AF5C688DA85B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 43 Then
            If CheckPermission("C62D34DA49B2443786CBF9247882D088") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 44 Then
            If CheckPermission("46BA851D87504C828B3B4EDDF8D8A7FD") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 45 Then
            If CheckPermission("69E2706305F04A22A49C6493EB2D7BDC") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 46 Then
            If CheckPermission("460C7D18289C47E583DD616D9ED84DCE") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 47 Then
            If CheckPermission("9A6184827F5F4E71B7EFE6402EEC69B7") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 48 Then
            If CheckPermission("EDE07C814F47407EB047A801FDD0281A") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 49 Then
            If CheckPermission("50EE720F5E6D4AD7814C4B248FAF9258") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 50 Then
            If CheckPermission("AF226D727A014AFDB0A989A6D4221FE9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 51 Then
            If CheckPermission("47C4D84727584F5FA56B98628B51E8D9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 52 Then
            If CheckPermission("4A3FEE2B11744F3DB5F880306134097E") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 53 Then
            If CheckPermission("404DD8C088524055A1D05773C54FD392") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 54 Then
            If CheckPermission("E68691CC6D4E468298E068ADD19493C2") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 55 Then
            If CheckPermission("8EF42EBB58354287A7F64754DA2E63C9") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 56 Then
            If CheckPermission("847FF70170C34BD78695A3C061309C9B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 57 Then
            If CheckPermission("531A3E214F804CCCA0928A6FB5F5234C") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 58 Then
            If CheckPermission("D5622632FACA4149B9ED825B0D96FB81") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 59 Then
            If CheckPermission("F2E1BB0353E9449EB2CA2DA219EFC9C4") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 60 Then
            If CheckPermission("8B776FB0E9774AFA8F5198A075DF99A3") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 61 Then
            If CheckPermission("86039A7E2D6F4E4F9E5B379523219E4D") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 62 Then
            If CheckPermission("E5A6DFF201964911B2F755C3EBA12364") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 63 Then
            If CheckPermission("7094CBEF500943A5926699F1725D4A70") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        End If

    End Sub
    Private Sub AcountTreeList_FilterNode(sender As Object, e As FilterNodeEventArgs) Handles AcountTreeList.FilterNode
        If e.Node.Id = 0 Then
            If CheckPermission("A6199B2FEAC74FB99FE7220EE41AA889") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 1 Then
            If CheckPermission("F1FD2572CEF74F86A4A3F93C84BDD69C") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 2 Then
            If CheckPermission("FB41CB18707F4A63BC498DCB036B3BF0") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 3 Then
            If CheckPermission("80C5DB191AEB4C52929E92832780E348") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 4 Then
            If CheckPermission("6A216A4399DE415298145FC5919CC370") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 5 Then
            If CheckPermission("3E8324A0307B4B73A50C8F0A4C40CDFD") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 6 Then
            If CheckPermission("DC565D749ADF4CEF93382AE8FA73AAC1") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 7 Then
            If CheckPermission("BCAEB19836BB47C18D05F6294BC11E22") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 8 Then
            If CheckPermission("27D4F96EF7CD46D8BDFE1196E51F526B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 9 Then
            If CheckPermission("598734DB5B89437C87E9E495CACBE251") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 10 Then
            If CheckPermission("BC4A475917A74FC3802FF4F98A267C23") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 11 Then
            If CheckPermission("EC3C09F1DF1E4F7D83F85E2F7D05C907") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 12 Then
            If CheckPermission("C7AAB12B501E497EB1AC79C358FE2660") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 13 Then
            If CheckPermission("6A6270584F664A9AB901D02807DE63CB") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 14 Then
            If CheckPermission("6A6270584F664A9AB901D02807DE9999") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 15 Then
            If CheckPermission("7420E10B18DC45BB907D9DB8D7181CE5") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 16 Then
            If CheckPermission("F43C45EA9D1C4C88A3DCD6655DC2F117") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 17 Then
            If CheckPermission("611231905EAE40A583B7057B4181B442") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 18 Then
            If CheckPermission("6FA14DC18E2E425CA8DE7F34AC72EA9B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 19 Then
            If CheckPermission("E0441A10036D48088995B1F9F83F5E79") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 20 Then
            If CheckPermission("60FE011E74B54CCF93982D0EEEC5CAE7") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 21 Then
            If CheckPermission("4381A79A288A43C3B008C8C4A71E8A8B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 22 Then
            If CheckPermission("E66BC93651694F07B50CA9E5B2608050") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 23 Then
            If CheckPermission("2C720AFD51BA4578B8E7D0AD28689485") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 24 Then
            If CheckPermission("C565D69E31B9484F8B5BE430E97FD95E") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 25 Then
            If CheckPermission("6F2C3728C7344E15ACCD2AFD7167A065") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 26 Then
            If CheckPermission("FD2DDCCE0ECB4F63B209085070F2A32B") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 27 Then
            If CheckPermission("209045D6E2444F50A4D2F01226F5B625") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub CallCenterTreeList_FilterNode(sender As Object, e As FilterNodeEventArgs) Handles CallCenterTreeList.FilterNode
        If e.Node.Id = 0 Then
            If CheckPermission("7B7AEEB35F4F4BF7A4D069A8BCD865B0") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If


            'Hide
        ElseIf e.Node.Id = 1 Then
            If CheckPermission("868D1C12CC42465BA7DCAE2B279CD58F") = False Then
                e.Node.Visible = False
                e.Handled = True
            Else
                e.Node.Visible = False
                e.Handled = True
            End If

            'Hide
        ElseIf e.Node.Id = 2 Then
            If CheckPermission("3B90FF27CB3F484493120D340DC196C7") = False Then
                e.Node.Visible = False
                e.Handled = True
            Else
                e.Node.Visible = False
                e.Handled = True
            End If


        ElseIf e.Node.Id = 3 Then
            If CheckPermission("E4060F573FE342B496EC629A3E7FCD33") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 4 Then
            If CheckPermission("7D0D71A6422748108546B1AEB559B2F7") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 5 Then
            If CheckPermission("A2ADDECDE9034B91A442C5707C428D20") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 6 Then
            If CheckPermission("77AECB3F04294AD499F19BE5CA500ECB") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 7 Then
            If CheckPermission("DFF9FC21F14049A6BAF6EF28CD3D407C") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 8 Then
            If CheckPermission("8F4410403E1840749FF38A9432E52718") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 9 Then
            If CheckPermission("A944BA07C90846CF89FE2CB08C2AF7AC") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        ElseIf e.Node.Id = 10 Then
            If CheckPermission("6E2805538310451AB4DEBE862115E6A5") = False Then
                e.Node.Visible = False
                e.Handled = True
            End If
        End If

    End Sub

#End Region

#Region "Context Menu Permissions"

    Private Sub mnuPermSelectAll_Click(sender As Object, e As EventArgs) Handles mnuPermSelectAll.Click
        On Error Resume Next
        If GridView2.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView2.RowCount - 1
            GridView2.GetRow(i).Item("Ակտիվ") = True
        Next
    End Sub
    Private Sub mnuPermSelect_Click(sender As Object, e As EventArgs) Handles mnuPermSelect.Click
        On Error Resume Next
        If GridView2.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView2.SelectedRowsCount - 1
            GridView2.GetDataRow(GridView2.GetSelectedRows()(i)).Item("Ակտիվ") = True
        Next
    End Sub
    Private Sub mnuPermDeselect_Click(sender As Object, e As EventArgs) Handles mnuPermDeselect.Click
        On Error Resume Next
        GridView2.ClearColumnsFilter()
        If GridView2.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView2.RowCount - 1
            GridView2.GetRow(i).Item("Ակտիվ") = False
        Next
    End Sub

#End Region

#Region "Panel Right"

    Private Sub txtEnterCenterWorkShop_TextChanged(sender As Object, e As EventArgs) Handles txtEnterCenterWorkShop.TextChanged
        'If CheckPermission2("53671AC392014AD09D4253D51667800B") = False Then txtEnterCenterWorkShop.Enabled = False

        If txtEnterCenterWorkShop.Text.Trim.Length <> 12 Then Exit Sub

        If Not (Microsoft.VisualBasic.Left(txtEnterCenterWorkShop.Text.Trim, 1).ToString.ToLower = "v" OrElse Microsoft.VisualBasic.Left(txtEnterCenterWorkShop.Text.Trim, 1).ToString.ToLower = "q") Then Exit Sub

        Try
            If iUser.DB <> 5 Then Throw New Exception("Գործողությունը արգելվում է")

            iDB.AddEnterCenterWorkshop(txtEnterCenterWorkShop.Text.Trim, iUser.LoginName)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            txtEnterCenterWorkShop.Text = String.Empty
        End Try
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try

            If String.IsNullOrEmpty(txtPraseSearch.Text) Then Throw New Exception("Արտահայտությունը-ն գրված չէ")
            If txtPraseSearch.Text.Trim.Length <> 8 AndAlso txtPraseSearch.Text.Trim.Length <> 9 AndAlso txtPraseSearch.Text.Trim.Length <> 12 Then Throw New Exception("Արտահայտությունը պետք է ունենա 8, 9 կամ 12 սիմվոլ երկարություն")

            Dim b As Boolean
            If txtPraseSearch.Text.Trim.Length = 8 OrElse txtPraseSearch.Text.Trim.Length = 9 Then b = True Else b = False

            Call CloseWindow("nUniCallCenterPanel")
            Dim f As New UniCallCenterPanel With {.Phrase = txtPraseSearch.Text.Trim, .isHvhh = b}
            AddChildForm("nUniCallCenterPanel", f)

            Dim dt As DataTable = iDB.UniCallCenterPaxHVHH(txtPraseSearch.Text)
            If dt.Rows.Count > 0 Then
                lblHVHHP.Visible = True
                lblHVHHP.ForeColor = Color.Red
                lblHVHHP.Text = dt.Rows(0)("PaxHVHH") '+ dt.Rows(0)("SupporterID")
            Else
                lblHVHHP.Visible = False
                lblHVHHP.Text = ""
            End If


        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub lblHVHHP_Click(sender As Object, e As EventArgs) Handles lblHVHHP.Click
        Try

            If String.IsNullOrEmpty(lblHVHHP.Text) Then Exit Sub
            'If txtPraseSearch.Text.Trim.Length <> 8 AndAlso txtPraseSearch.Text.Trim.Length <> 9 AndAlso txtPraseSearch.Text.Trim.Length <> 12 Then Throw New Exception("Արտահայտությունը պետք է ունենա 8, 9 կամ 12 սիմվոլ երկարություն")

            Dim b As Boolean
            If lblHVHHP.Text.Trim.Length = 8 OrElse lblHVHHP.Text.Trim.Length = 9 Then b = True Else b = False

            Call CloseWindow("nUniCallCenterPanel")
            Dim f As New UniCallCenterPanel With {.Phrase = lblHVHHP.Text.Trim, .isHvhh = b}
            AddChildForm("nUniCallCenterPanel", f)

            'Dim dt As DataTable = iDB.UniCallCenterPaxHVHH(txtPraseSearch.Text)
            'If dt.Rows.Count > 0 Then
            '    lblHVHHP.ForeColor = Color.Red
            '    lblHVHHP.Text = dt.Rows(0)("PaxHVHH")
            'Else
            '    lblHVHHP.Text = ""
            'End If


        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub txtPraseSearch_TextChanged(sender As Object, e As EventArgs) Handles txtPraseSearch.TextChanged
        On Error Resume Next
        If txtPraseSearch.Text.Trim.Length = 1 Then
            If Microsoft.VisualBasic.Left(txtPraseSearch.Text, 1).ToLower = "v" Then txtPraseSearch.Text = "V90413" : txtPraseSearch.SelectionStart = Len(txtPraseSearch.Text)
            If Microsoft.VisualBasic.Left(txtPraseSearch.Text, 1).ToLower = "q" Then txtPraseSearch.Text = "Q80414" : txtPraseSearch.SelectionStart = Len(txtPraseSearch.Text)
            If Microsoft.VisualBasic.Left(txtPraseSearch.Text, 1).ToLower = "s" Then txtPraseSearch.Text = "S900552" : txtPraseSearch.SelectionStart = Len(txtPraseSearch.Text)
        End If
    End Sub
    Private Sub btnQueryPayments_Click(sender As Object, e As EventArgs) Handles btnQueryPayments.Click
        Try
            If String.IsNullOrEmpty(txtEcrPartq.Text) Then Throw New Exception("ՀԴՄ-ն գրված չէ")
            If txtEcrPartq.Text.Trim.Length < 12 Then Throw New Exception("ՀԴՄ-ն պետք է ունենա 12 սիմվոլ երկարություն")

            Dim RVal As String = iDB.GetFilteredPayment(txtEcrPartq.Text.Trim)

            txtPayRes.Text = RVal

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub txtEcrPartq_TextChanged(sender As Object, e As EventArgs) Handles txtEcrPartq.TextChanged
        On Error Resume Next
        If txtEcrPartq.Text.Trim.Length = 1 Then
            If Microsoft.VisualBasic.Left(txtEcrPartq.Text, 1).ToLower = "v" Then txtEcrPartq.Text = "V90413" : txtEcrPartq.SelectionStart = Len(txtEcrPartq.Text)
            If Microsoft.VisualBasic.Left(txtEcrPartq.Text, 1).ToLower = "q" Then txtEcrPartq.Text = "Q80414" : txtEcrPartq.SelectionStart = Len(txtEcrPartq.Text)
            If Microsoft.VisualBasic.Left(txtEcrPartq.Text, 1).ToLower = "s" Then txtEcrPartq.Text = "S900552" : txtEcrPartq.SelectionStart = Len(txtEcrPartq.Text)
        End If
        txtPayRes.Text = String.Empty
    End Sub

#End Region

#Region "Other Events"

    Private Sub WTimer_Tick(sender As Object, e As EventArgs) Handles WTimer.Tick
        On Error Resume Next

        'Remake
        If GridView3.RowCount > 0 Then
            For j As Integer = 0 To GridView3.RowCount - 1
                Dim timePeriod As TimeSpan
                Dim d As Date = GridView3.GetRowCellValue(j, "InTimer")
                timePeriod = Now - d

                GridControl3.BeginUpdate()

                If timePeriod.Days > 0 Then
                    GridView3.SetRowCellValue(j, "Ժամանակ", timePeriod.Days & " Օր " & timePeriod.Hours.ToString("00") & ":" & timePeriod.Minutes.ToString("00") & ":" & timePeriod.Seconds.ToString("00"))
                Else
                    GridView3.SetRowCellValue(j, "Ժամանակ", timePeriod.Hours.ToString("00") & ":" & timePeriod.Minutes.ToString("00") & ":" & timePeriod.Seconds.ToString("00"))
                End If

                GridControl3.EndUpdate()

            Next
        End If

        iTotal += 1

        If iTotal Mod 600 = 0 Then
            Call LoadTimerData()
            iTotal = 1
        End If
        '///////////////////////////////////////

        'Must Replace Ecr
        If GridView4.RowCount > 0 Then
            For j As Integer = 0 To GridView4.RowCount - 1
                Dim timePeriod As TimeSpan
                'Dim n As Date = GridView4.GetRowCellValue(j, "CurrentDate")
                Dim d As Date = GridView4.GetRowCellValue(j, "ExpireDate")

                timePeriod = d - Now

                GridControl4.BeginUpdate()

                If timePeriod.Days > 0 Then
                    GridView4.SetRowCellValue(j, "Ժամանակ", timePeriod.Days & " օր " & timePeriod.Hours.ToString("00") & ":" & timePeriod.Minutes.ToString("00") & ":" & timePeriod.Seconds.ToString("00"))
                ElseIf timePeriod.Days < 1 AndAlso timePeriod.TotalSeconds > 0 Then
                    GridView4.SetRowCellValue(j, "Ժամանակ", timePeriod.Hours.ToString("00") & ":" & timePeriod.Minutes.ToString("00") & ":" & timePeriod.Seconds.ToString("00"))
                Else
                    GridView4.SetRowCellValue(j, "Ժամանակ", "Ժամկետը լրացել է")
                End If

                GridControl4.EndUpdate()

            Next
        End If

        iTotal2 += 1

        If iTotal2 Mod 600 = 0 Then
            Call LoadTimerData2()
            iTotal2 = 1
        End If
        '///////////////////////////////////////

        'Must Replace Ecr Closed
        If GridView5.RowCount > 0 Then
            For j As Integer = 0 To GridView5.RowCount - 1
                Dim timePeriod As TimeSpan
                Dim d As Date = GridView5.GetRowCellValue(j, "CreateDate")

                timePeriod = d - Now

                GridControl5.BeginUpdate()

                If timePeriod.Days > 0 Then
                    GridView5.SetRowCellValue(j, "Ժամանակ", timePeriod.Days & " օր " & timePeriod.Hours.ToString("00") & ":" & timePeriod.Minutes.ToString("00") & ":" & timePeriod.Seconds.ToString("00"))
                ElseIf timePeriod.Days < 1 AndAlso timePeriod.TotalSeconds > 0 Then
                    GridView5.SetRowCellValue(j, "Ժամանակ", timePeriod.Hours.ToString("00") & ":" & timePeriod.Minutes.ToString("00") & ":" & timePeriod.Seconds.ToString("00"))
                Else
                    GridView5.SetRowCellValue(j, "Ժամանակ", "Ժամկետը լրացել է")
                End If

                GridControl5.EndUpdate()

            Next
        End If

        iTotal3 += 1

        If iTotal3 Mod 600 = 0 Then
            Call LoadTimerData3()
            iTotal3 = 1
        End If
        '///////////////////////////////////////


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
    Private Sub GridControl2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl2.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl2.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub
    Private Sub GridView3_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView3.RowStyle
        On Error Resume Next

        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then

            Dim NotServed As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Կենտրոն"))
            If NotServed = "Checked" Then
                e.Appearance.BackColor = Color.Salmon        ' Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell            ' Color.SeaShell
            Else
                Dim Colored As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Մասնաճյուղ"))
                If Colored = "Checked" Then
                    e.Appearance.BackColor = Color.GreenYellow       ' Color.Salmon
                    e.Appearance.BackColor2 = Color.LightBlue            ' Color.SeaShell
                End If
            End If

        End If

    End Sub
    Private Sub GridControl3_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl3.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl3.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub
    Private Sub GridView3_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView3.RowCellStyle
        On Error Resume Next

        Dim View As GridView = sender
        If e.Column.FieldName = "Ժամանակ" Then
            Dim Col As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Ելք"))
            If Col = "Checked" Then
                e.Appearance.BackColor = Color.FromArgb(255, 229, 229)
                e.Appearance.BackColor2 = Color.FromArgb(242, 242, 242)
            End If
        End If

    End Sub
    Private Sub txtPraseSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPraseSearch.KeyDown
        On Error Resume Next
        If e.KeyCode = Keys.Enter Then
            btnQuery.PerformClick()
        End If
    End Sub
    Private Sub mnuRefresh_Click(sender As Object, e As EventArgs) Handles mnuRefresh.Click
        Call LoadTimerData()
    End Sub
    Private Sub GridControl4_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl4.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl4.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub
    Private Sub GridControl5_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl5.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl5.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

    Private Sub GridView4_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles GridView4.RowCellStyle
        On Error Resume Next
        Dim View As GridView = sender
        If e.Column.FieldName = "Ժամանակ" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Ժամանակ"))
            If category = "Ժամկետը լրացել է" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub
    Private Sub GridView5_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles GridView5.RowCellStyle
        On Error Resume Next
        Dim View As GridView = sender
        If e.Column.FieldName = "Ժամանակ" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Ժամանակ"))
            If category = "Ժամկետը լրացել է" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub

    Private Sub mnuChangeExpireDate1_Click(sender As Object, e As EventArgs) Handles mnuChangeExpireDate1.Click
        If CheckPermission2("7F5417DAACF64C83BA207E61C4EC6F4C") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        If GridView4.SelectedRowsCount = 0 Then Exit Sub
        Dim ecr As String = GridView4.GetFocusedDataRow.Item("ՀԴՄ")
        Dim TM As Date = GridView4.GetFocusedDataRow.Item("ExpireDate")
        Dim f As New DExt1 With {.Ecr = ecr, .ExpTime = TM}
        f.ShowDialog()
        f.Dispose()

        Call LoadTimerData2()
    End Sub
    Private Sub mnuChangeTime2_Click(sender As Object, e As EventArgs) Handles mnuChangeTime2.Click
        If CheckPermission2("F33A4EAF3B7244D3AC0F20BF991DA0CA") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        If GridView5.SelectedRowsCount = 0 Then Exit Sub
        Dim ecr As String = GridView5.GetFocusedDataRow.Item("ՀԴՄ")
        Dim TM As Date = GridView5.GetFocusedDataRow.Item("CreateDate")
        Dim f As New DExt2 With {.Ecr = ecr, .ExpTime = TM}
        f.ShowDialog()
        f.Dispose()

        Call LoadTimerData3()
    End Sub

    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        If CheckPermission2("FE220BEC07B64ADCB6F57409E473BF5F") = False Then MsgBox("Գործողությունը կատարելու համար դուք իրավասություն չունեք", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        If MsgBox("Ցանկանու՞մ եք ջնջել գրանցումը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

        If GridView4.SelectedRowsCount = 0 Then Exit Sub
        Dim ecr As String = GridView4.GetFocusedDataRow.Item("ՀԴՄ")

        Try

            iDB.DeleteFromQueue(ecr)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Call LoadTimerData2()
        End Try
    End Sub

    Private Sub mnuRef1_Click(sender As Object, e As EventArgs) Handles mnuRef1.Click
        Call LoadTimerData2()
    End Sub
    Private Sub mnuRef2_Click(sender As Object, e As EventArgs) Handles mnuRef2.Click
        Call LoadTimerData3()
    End Sub

    Private Sub btnOnline_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOnline.CheckedChanged
        Try
            iDB.UpdateIsOnline(btnOnline.Checked)
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub CKSMSToTesuchX_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CKSMSToTesuchX.CheckedChanged
        Try
            iDB.NewTesuchSMSPermission(CKSMSToTesuchX.Checked)
            SMSSendToTesuchP = CKSMSToTesuchX.Checked
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnCheck_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCheck.ItemClick
        Try
            If beGPRS.EditValue.Trim = String.Empty Then Throw New Exception("GPRS-ը գրված չէ")

            Dim g As String = beGPRS.EditValue.Trim

            btnCheck.Enabled = False

            Dim client As New OrangeServiceReference.ClientServerConnecterClient
            client.Open()

            Dim r As String = String.Empty

            r = client.CheckGprsStatus(g)

            MsgBox("GPRS -> " & g & vbCrLf & vbCrLf & "Կարգավիճակ՝ " & r, MsgBoxStyle.Information, My.Application.Info.Title)

            client.Close()

            client = Nothing

            beGPRS.EditValue = String.Empty

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            btnCheck.Enabled = True
        End Try
    End Sub

    Private Sub BarRemake_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarRemake.CheckedChanged
        Try
            iDB.NewbBarRemake(BarRemake.Checked)
            bBarRemake = BarRemake.Checked
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub BarRemakeClient_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarRemakeClient.CheckedChanged
        Try
            iDB.NewbBarRemakeClientProp(BarRemakeClient.Checked)
            bBarRemakeClient = BarRemakeClient.Checked
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

End Class