Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class HaytActivateEdit

    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        'On Error Resume Next

        'Dim View As GridView = sender
        'If (e.RowHandle >= 0) Then
        '    Dim d As Date = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀայտիԱմսաթիվ"))
        '    If Now.Date > DateAdd(DateInterval.Day, 3, d) Then
        '        e.Appearance.BackColor = Color.Red ' Color.Salmon
        '        e.Appearance.BackColor2 = Color.Orange ' Color.SeaShell
        '    End If

        'End If

    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = Not GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ")
        Next
    End Sub
    Private Sub mnuViewed_Click(sender As Object, e As EventArgs) Handles mnuViewed.Click
        Try
            Dim r_id As New List(Of RecordID)
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True Then
                    r_id.Add(New RecordID(GridView1.GetRowCellValue(i, "ՀՀ")))
                End If
            Next

            Dim dt As DataTable = ToDataTable(r_id)

            iDB.UpdateActivateHaytStatus(dt)

            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True Then
                    GridView1.SetRowCellValue(i, "Դիտված", True)
                    GridView1.SetRowCellValue(i, "Նշիչ", False)
                End If
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuSelect_Click(sender As Object, e As EventArgs) Handles mnuSelect.Click
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuSelectAll_Click(sender As Object, e As EventArgs) Handles mnuSelectAll.Click
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(i, "Նշիչ", True)
        Next
    End Sub
    Private Sub mnuRevert_Click(sender As Object, e As EventArgs) Handles mnuRevert.Click
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(i, "Նշիչ", False)
        Next
    End Sub
    Private Sub mnuChangeInfo_Click(sender As Object, e As EventArgs) Handles mnuChangeInfo.Click
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            If GridView1.GetFocusedDataRow.Item("ՀայտիՏեսակ").ToString = "Ակտիվացման" Then
                Dim f As New changeActivHaytInfo
                With f
                    .haytID = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
                    .haytHDM = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString
                    .haytHVHH = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString
                    .HaytCompany = GridView1.GetFocusedDataRow.Item("Կազմակերպություն").ToString
                    .haytAddress = GridView1.GetFocusedDataRow.Item("Հասցե").ToString
                    .haytTel = GridView1.GetFocusedDataRow.Item("Հեռախոս").ToString
                    .haytTesuch = GridView1.GetFocusedDataRow.Item("Տեսուչ").ToString
                    .haytSpasarkox = GridView1.GetFocusedDataRow.Item("Սպասարկող").ToString
                    .haytDate = GridView1.GetFocusedDataRow.Item("ՀայտիԱմսաթիվ").ToString
                    .haytRegion = GridView1.GetFocusedDataRow.Item("Տարածաշրջան").ToString
                    .haytCreator = GridView1.GetFocusedDataRow.Item("Օպերատոր").ToString

                    If IsDBNull(GridView1.GetFocusedDataRow.Item("Խնդիր/ՀաստատմանԿոդ")) Then
                        .haytAppr = ""
                    Else
                        .haytAppr = GridView1.GetFocusedDataRow.Item("Խնդիր/ՀաստատմանԿոդ").ToString
                    End If

                    .ShowDialog()
                End With
            ElseIf GridView1.GetFocusedDataRow.Item("ՀայտիՏեսակ").ToString = "Ընդհանուր" Then
                Dim haytId As Integer = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
                If iDB.IsProposalEquipmentSold(haytId) = True Then Throw New Exception("Հայտը խմբագրման ենթակա չէ, քանի որ վաճառքն արդեն իսկ իրականացված է։")

                Dim f As New changeGeneralHaytInfo
                With f
                    .haytID = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
                    .haytHDM = GridView1.GetFocusedDataRow.Item("ՀԴՄ").ToString
                    .haytHVHH = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString
                    .HaytCompany = GridView1.GetFocusedDataRow.Item("Կազմակերպություն").ToString
                    .haytAddress = GridView1.GetFocusedDataRow.Item("Հասցե").ToString
                    .haytTel = GridView1.GetFocusedDataRow.Item("Հեռախոս").ToString
                    .haytTesuch = GridView1.GetFocusedDataRow.Item("Տեսուչ").ToString
                    .haytSpasarkox = GridView1.GetFocusedDataRow.Item("Սպասարկող").ToString
                    .haytXndir = GridView1.GetFocusedDataRow.Item("Խնդիր/ՀաստատմանԿոդ").ToString
                    .haytDate = GridView1.GetFocusedDataRow.Item("ՀայտիԱմսաթիվ").ToString
                    .haytRegion = GridView1.GetFocusedDataRow.Item("Տարածաշրջան").ToString
                    .haytCreator = GridView1.GetFocusedDataRow.Item("Օպերատոր").ToString
                    .problem = GridView1.GetFocusedDataRow.Item("Խնդիր")
                    .ShowDialog()
                End With
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
        Try
            If CheckPermission2("D8F4361986A6453C85074829802A5F02") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If Not MsgBox("Ցանկանու՞մ եք փակել հայտը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then Exit Sub

            Dim r_id As New List(Of RecordID)
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True Then
                    r_id.Add(New RecordID(GridView1.GetRowCellValue(i, "ՀՀ")))
                End If
            Next

            Dim dt As DataTable = ToDataTable(r_id)

            If GridView1.GetFocusedDataRow.Item("ՀայտիՏեսակ").ToString = "Ակտիվացման" Then
                iDB.CloseActivateHaytStatus(dt, iUser.LoginName)
            ElseIf GridView1.GetFocusedDataRow.Item("ՀայտիՏեսակ").ToString = "Ընդհանուր" Then
                iDB.CloseGeneralHaytStatus(dt, iUser.LoginName)
            End If


            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuPrint_Click(sender As Object, e As EventArgs) Handles mnuPrint.Click
        Try
            Dim r_id As New List(Of RecordID)
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True Then
                    r_id.Add(New RecordID(GridView1.GetRowCellValue(i, "ՀՀ")))
                End If
            Next

            GridView1.ClearColumnsFilter()
            GridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, "Նշիչ", True)

            GridView1.Columns("Նշիչ").Visible = False
            GridView1.Columns("ԸնդունմանԱմսաթիվ").Visible = False
            GridView1.Columns("Դիտված").Visible = False

            GridView1.Print()

            Dim dt As DataTable = ToDataTable(r_id)

            iDB.PrintedActivateHaytStatus(dt)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            GridView1.ClearColumnsFilter()
            GridView1.Columns("Նշիչ").Visible = True
            GridView1.Columns("ԸնդունմանԱմսաթիվ").Visible = True
            GridView1.Columns("Դիտված").Visible = True
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
    Private Sub mnuSMS_Click(sender As Object, e As EventArgs) Handles mnuSMS.Click
        Try
            If GridView1.SelectedRowsCount <> 1 Then Throw New Exception("Հարկավոր է նշել միայն մեկ տող")

            Dim ID As Integer = GridView1.GetFocusedDataRow.Item("ՀՀ").ToString
            Dim Tesuch As String = GridView1.GetFocusedDataRow.Item("Տեսուչ").ToString
            Dim Problem As String = GridView1.GetFocusedDataRow.Item("Խնդիր/ՀաստատմանԿոդ").ToString

            Dim tTel As String = iDB.TesuchTel(Tesuch)

            If Not String.IsNullOrEmpty(tTel) AndAlso tTel <> "-" Then
                If GridView1.GetFocusedDataRow.Item("ՀայտիՏեսակ").ToString = "Ակտիվացման" Then
                    Dim f As New CallSmsActivate With {.I_PropID = ID, .I_Tesuch = Tesuch, .I_Tel = tTel}
                    f.ShowDialog()
                    f.Dispose()
                ElseIf GridView1.GetFocusedDataRow.Item("ՀայտիՏեսակ").ToString = "Ընդհանուր" Then

                    Dim f As New CallSmsGeneral With {.I_PropID = ID, .I_Tesuch = Tesuch, .I_Tel = tTel, .I_Problem = Problem}
                    f.ShowDialog()
                    f.Dispose()
                End If

                'MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)
            Else
                Throw New Exception("Տեսուչի հեռախոսը չի ստացվել")
            End If



        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub mnuCancel_Click(sender As Object, e As EventArgs) Handles mnuCancel.Click
        Try
            If CheckPermission2("D8F4361986A6453C85074829802A5F02") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If Not MsgBox("Ցանկանու՞մ եք մերժել հայտը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then Exit Sub

            Dim r_id As New List(Of RecordID)
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True Then
                    r_id.Add(New RecordID(GridView1.GetRowCellValue(i, "ՀՀ")))
                End If
            Next

            Dim dt As DataTable = ToDataTable(r_id)

            If GridView1.GetFocusedDataRow.Item("ՀայտիՏեսակ").ToString = "Ակտիվացման" Then
                iDB.CloseActivateHaytStatusAndRefuse(dt, iUser.LoginName)
            ElseIf GridView1.GetFocusedDataRow.Item("ՀայտիՏեսակ").ToString = "Ընդհանուր" Then
                iDB.CloseGeneralHaytStatusAndRefuse(dt, iUser.LoginName)
            End If



            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class