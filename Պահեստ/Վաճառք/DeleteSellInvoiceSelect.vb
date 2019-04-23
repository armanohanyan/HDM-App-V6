Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class DeleteSellInvoiceSelect

    Dim isInner As Boolean

    Private Sub loadSupporter()
        Try
            Dim dt1 As DataTable = iDB.GetWarehouseList2
            With cSeller
                .DataSource = dt1
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
            End With
            If cSeller.Items.Count > 0 Then If iUser.DB <> 5 Then cSeller.SelectedValue = iUser.DB : cSeller.Enabled = False
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub DeleteSellInvoiceSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadSupporter()
    End Sub
    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            If txtHVHH.Text.Trim = String.Empty Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()
            GridControl1.EndUpdate()

            If cInner.Checked = False Then
                isInner = False

                Dim dt As DataTable = iDB.GetSoldInvoiceForDelete(cSeller.SelectedValue, txtHVHH.Text.Trim)
                If dt.Rows.Count = 0 Then Throw New Exception("Հաշիվ ապրանքագիրը չի հայտնաբերվել")

                GridControl1.BeginUpdate()
                GridView1.Columns.Clear()
                GridControl1.DataSource = dt
                GridControl1.EndUpdate()

                With GridView1
                    .Columns("InvoiceID").Visible = False
                    .Columns("ClientID").Visible = False
                    .Columns("SupporterID").Visible = False
                    .Columns("SellID").Visible = False
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
            Else
                isInner = True

                Dim dt As DataTable = iDB.GetSoldInvoiceForDeleteInner(cSeller.SelectedValue, txtHVHH.Text.Trim)
                If dt.Rows.Count = 0 Then Throw New Exception("Հաշիվ ապրանքագիրը չի հայտնաբերվել")

                GridControl1.BeginUpdate()
                GridView1.Columns.Clear()
                GridControl1.DataSource = dt
                GridControl1.EndUpdate()

                With GridView1
                    .Columns("InvoiceID").Visible = False
                    .Columns("SupporterID").Visible = False
                    .Columns("SellID").Visible = False
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
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub

            If MsgBox("Ցանկանու՞մ եք չեղարկել կայացած գործարքը", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) <> MsgBoxResult.Yes Then Exit Sub

            Dim InvoiceID As Integer = GridView1.GetFocusedDataRow.Item("InvoiceID").ToString
            Dim SupporterID As Byte = GridView1.GetFocusedDataRow.Item("SupporterID").ToString
            Dim SellID As Integer = GridView1.GetFocusedDataRow.Item("SellID").ToString

            If isInner = True Then
                Dim hvvhh As String = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString


            Else
                Dim ClientID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString
                iDB.DropCustomSell(InvoiceID, ClientID, SupporterID, SellID)
            End If

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            btnCheck.PerformClick()

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