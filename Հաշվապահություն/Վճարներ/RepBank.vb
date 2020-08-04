Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class RepBank

    Private iDuration As String = "00:00"

    Friend SupporterID As Byte

    Private Sub Pay(hvhh As String, Payment As Decimal, PayDate As Date, PayType As String)
        On Error Resume Next
        iDB.InsertPayment(hvhh, Payment, PayDate, PayType, SupporterID)
    End Sub
    Private Sub GetHTSClientInfoForPayment(ByVal RowID As Int64, ByVal HTSCode As Integer)
        Try
            Dim dt As DataTable = iDB.HTSClientInfoForPayment(HTSCode, SupporterID)
            If dt.Rows.Count = 1 Then
                GridView1.SetRowCellValue(RowID, "ՀՎՀՀ", dt.Rows(0)("HVHH"))
                GridView1.SetRowCellValue(RowID, "Գործընկեր", dt.Rows(0)("CompanyName"))
            Else
                GridView1.SetRowCellValue(RowID, "ՀՎՀՀ", DBNull.Value)
                GridView1.SetRowCellValue(RowID, "Գործընկեր", DBNull.Value)
            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub RepBank_Activated(sender As Object, e As EventArgs) Handles Me.Activated
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
    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim hvhh As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ՀՎՀՀ"))
            Dim payType As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ԲանկայինՀղում"))
            If hvhh = String.Empty OrElse Trim(payType) = String.Empty OrElse Not (Trim(payType) = "b" OrElse Trim(payType) = "e" OrElse Trim(payType) = "t" OrElse Trim(payType) = "i") Then
                e.Appearance.BackColor = Color.FromArgb(255, 153, 153)       ' Color.Salmon
                e.Appearance.BackColor2 = Color.White            ' Color.SeaShell
            End If
            'If Trim(payType) = String.Empty Then
            '    e.Appearance.BackColor = Color.FromArgb(255, 153, 153)       ' Color.Salmon
            '    e.Appearance.BackColor2 = Color.White            ' Color.SeaShell
            'End If

            Dim R As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("R"))
            If R = 2 AndAlso hvhh <> String.Empty Then
                e.Appearance.BackColor = Color.FromArgb(173, 214, 255)
                e.Appearance.BackColor2 = Color.FromArgb(255, 255, 255)
            End If
        End If
    End Sub
    Private Sub mnuSelectAll_Click(sender As Object, e As EventArgs) Handles mnuSelectAll.Click
        On Error Resume Next
        If GridView1.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.GetRow(i).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuSelect_Click(sender As Object, e As EventArgs) Handles mnuSelect.Click
        On Error Resume Next
        If GridView1.SelectedRowsCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("Նշիչ") = True
        Next
    End Sub
    Private Sub mnuDeselect_Click(sender As Object, e As EventArgs) Handles mnuDeselect.Click
        On Error Resume Next
        GridView1.ClearColumnsFilter()
        If GridView1.RowCount = 0 Then Exit Sub
        For i As Int32 = 0 To GridView1.RowCount - 1
            GridView1.GetRow(i).Item("Նշիչ") = False
        Next
    End Sub
    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            If GridView1.RowCount = 0 Then Exit Sub

            Dim ID As Integer
            Dim HTSCode As Integer = -1

            If e.Column.GetTextCaption = "Հծ Կոդ" Then
                'Row ID
                Dim RowID As Integer = e.RowHandle

                'Record ID
                ID = GridView1.GetRowCellValue(e.RowHandle, "ID")

                'New HTS Code

                If Not IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "ՀծԿոդ")) Then HTSCode = GridView1.GetRowCellValue(e.RowHandle, "ՀծԿոդ")

                If HTSCode <> -1 Then
                    Select Case SupporterID
                        Case 1
                            If HTSCode <= 10000 OrElse HTSCode >= 25000 Then GridView1.SetRowCellValue(RowID, "ՀՎՀՀ", DBNull.Value) : GridView1.SetRowCellValue(RowID, "Գործընկեր", DBNull.Value) : Throw New Exception("ՀԾ կոդը պետք է լինի 10001 - 24999 միջակայքում")
                        Case 2
                            If HTSCode <= 26000 OrElse HTSCode >= 41000 Then GridView1.SetRowCellValue(RowID, "ՀՎՀՀ", DBNull.Value) : GridView1.SetRowCellValue(RowID, "Գործընկեր", DBNull.Value) : Throw New Exception("ՀԾ կոդը պետք է լինի 26001 - 40999 միջակայքում")
                        Case 3
                            If HTSCode <= 58000 OrElse HTSCode >= 73000 Then GridView1.SetRowCellValue(RowID, "ՀՎՀՀ", DBNull.Value) : GridView1.SetRowCellValue(RowID, "Գործընկեր", DBNull.Value) : Throw New Exception("ՀԾ կոդը պետք է լինի 58001 - 72999 միջակայքում")
                        Case 4
                            If Not ((HTSCode >= 42000 AndAlso HTSCode < 57800) OrElse (HTSCode > 150000 AndAlso HTSCode < 200000)) Then GridView1.SetRowCellValue(RowID, "ՀՎՀՀ", DBNull.Value) : GridView1.SetRowCellValue(RowID, "Գործընկեր", DBNull.Value) : Throw New Exception("ՀԾ կոդը պետք է լինի 42001 - 57799 կամ 150000 - 200000 միջակայքում")
                            'If HTSCode <= 42000 OrElse HTSCode >= 57800 Then GridView1.SetRowCellValue(RowID, "ՀՎՀՀ", DBNull.Value) : GridView1.SetRowCellValue(RowID, "Գործընկեր", DBNull.Value) : Throw New Exception("ՀԾ կոդը պետք է լինի 42001 - 57800 միջակայքում")
                        Case 8
                            If HTSCode <= 210000 OrElse HTSCode >= 300000 Then GridView1.SetRowCellValue(RowID, "ՀՎՀՀ", DBNull.Value) : GridView1.SetRowCellValue(RowID, "Գործընկեր", DBNull.Value) : Throw New Exception("ՀԾ կոդը պետք է լինի 210001 - 299999 միջակայքում")
                        Case 10
                            If HTSCode <= 320000 OrElse HTSCode >= 400000 Then GridView1.SetRowCellValue(RowID, "ՀՎՀՀ", DBNull.Value) : GridView1.SetRowCellValue(RowID, "Գործընկեր", DBNull.Value) : Throw New Exception("ՀԾ կոդը պետք է լինի 320001 - 399999 միջակայքում")

                    End Select
                    Call GetHTSClientInfoForPayment(RowID, HTSCode)
                Else
                    GridView1.SetRowCellValue(RowID, "ՀՎՀՀ", DBNull.Value)
                    GridView1.SetRowCellValue(RowID, "Գործընկեր", DBNull.Value)
                End If
            End If

            'ՀԾ կոդի կրկնության ստուգում
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(e.RowHandle, "ID") <> ID Then
                    If Not IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "ՀծԿոդ")) Then
                        If GridView1.GetRowCellValue(e.RowHandle, "ՀծԿոդ") = HTSCode Then
                            MsgBox("ՀԾ կոդը կրկնվում է", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            Exit For
                        End If
                    End If
                End If
            Next

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuPay_Click(sender As Object, e As EventArgs) Handles mnuPay.Click
        Dim formX As New Working
        Try
            If CheckPermission2("02411AAA388049729E3E800E45D511BB") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If MsgBox("Ցանկանում եք կատարել վճարումները", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub
            formX.Show() : My.Application.DoEvents()

            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Նշիչ") = True Then
                    If Not IsDBNull(GridView1.GetRowCellValue(i, "ՀծԿոդ")) AndAlso Not IsDBNull(GridView1.GetRowCellValue(i, "ՀՎՀՀ")) AndAlso Not IsDBNull(GridView1.GetRowCellValue(i, "ԲանկայինՀղում")) Then
                        Call Pay(GridView1.GetRowCellValue(i, "ՀՎՀՀ"), GridView1.GetRowCellValue(i, "Կրեդիտ"), GridView1.GetRowCellValue(i, "Ամսաթիվ"), GridView1.GetRowCellValue(i, "ԲանկայինՀղում"))
                    End If
                End If
            Next

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            formX.Close()
            formX = Nothing
        End Try
    End Sub
    Private Sub RepBank_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        On Error Resume Next
        If GridView1.RowCount = 0 Then Exit Sub
        For i As Integer = 0 To GridView1.RowCount - 1
            If IsDBNull(GridView1.GetRowCellValue(i, "ՀՎՀՀ")) Then Continue For

            If GridView1.GetRowCellValue(i, "ՀՎՀՀ") = "02562304" Then
                GridView1.SetRowCellValue(i, "ՀծԿոդ", DBNull.Value)
            End If
        Next

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