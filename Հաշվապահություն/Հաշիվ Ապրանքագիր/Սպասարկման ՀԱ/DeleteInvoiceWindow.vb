Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class DeleteInvoiceWindow

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
    Private Sub InnerInvoiceXMLSelector_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With cYear
            .Items.Clear()
            For i As Integer = 2013 To 2025
                .Items.Add(i)
            Next
            .Text = Now.Year
        End With
        With cMonth
            .Items.Clear()
            For i As Integer = 1 To 12
                .Items.Add(i)
            Next
            .Text = Now.Month
        End With
        Call LoadSupporter()

        cReason.SelectedIndex = 0
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            If txtHVHH.Text.Trim = String.Empty Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")

            Dim dt As DataTable = iDB.GetInvoiceForDelete(cYear.Text, cMonth.Text, cSupporter.SelectedValue, txtHVHH.Text.Trim)

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()
            GridControl1.DataSource = dt
            GridControl1.EndUpdate()

            With GridView1
                .Columns("InvoiceID").Visible = False
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

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuDeleteInvoice_Click(sender As Object, e As EventArgs) Handles mnuDeleteInvoice.Click
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            If MsgBox("Ցանկանու՞մ եք ջնջել ինվոյսը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            Dim InvID As Integer = GridView1.GetFocusedDataRow.Item("InvoiceID")

            iDB.DeleteSupportInvoice(iUser.LoginName, InvID, cReason.Text)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            btnSelect.PerformClick()

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