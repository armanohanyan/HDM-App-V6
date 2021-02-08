Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class ChangeSellInvoiceSelect

    Dim isLocal As Boolean = False

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
            Dim dt As DataTable
            If cInner.Checked = False Then
                dt = iDB.GetDetailsForChangeCustomSell(cSeller.SelectedValue)
                GridControl1.BeginUpdate()
                GridView1.Columns.Clear()
                GridControl1.DataSource = dt
                GridControl1.EndUpdate()

                With GridView1
                    .Columns("CustomSellHeaderID").Visible = False
                    .Columns("ClientID").Visible = False
                    .Columns("SupporterID").Visible = False
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

                isLocal = False
            Else
                dt = iDB.GetDetailsForChangeCustomSellSupporter(cSeller.SelectedValue)
                GridControl1.BeginUpdate()
                GridView1.Columns.Clear()
                GridControl1.DataSource = dt
                GridControl1.EndUpdate()

                With GridView1
                    .Columns("CustomSellHeaderID").Visible = False
                    .Columns("ClientID").Visible = False
                    .Columns("SupporterID").Visible = False
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

                isLocal = True
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuChange_Click(sender As Object, e As EventArgs) Handles mnuChange.Click
        'Try
        If GridView1.SelectedRowsCount = 0 Then Exit Sub

        If isLocal = False Then
            Dim SellID As Integer = GridView1.GetFocusedDataRow.Item("CustomSellHeaderID").ToString
            Dim ClientID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString
            Dim SupporterID As Byte = GridView1.GetFocusedDataRow.Item("SupporterID").ToString
            Dim hvhh As String = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString

            Dim f As New SellWindow With {.IsLocalSell = False, .ClientHVHH = hvhh,
                                          .SupporterID = SupporterID, .ClientID = ClientID, .sellID = SellID}
            f.LoadDataByClient()
            f.ShowDialog()
            f.Dispose()
        Else
            Dim SellID As Integer = GridView1.GetFocusedDataRow.Item("CustomSellHeaderID").ToString
            Dim ClientID As Integer = GridView1.GetFocusedDataRow.Item("ClientID").ToString
            Dim SupporterID As Byte = GridView1.GetFocusedDataRow.Item("SupporterID").ToString
            Dim hvhh As String = GridView1.GetFocusedDataRow.Item("ՀՎՀՀ").ToString

            Dim f As New SellWindow With {.IsLocalSell = True, .ClientHVHH = hvhh,
                                          .SupporterID = SupporterID, .ClientID = ClientID, .sellID = SellID}

            f.LoadDataByClient()
            f.ShowDialog()
            f.Dispose()

        End If

        Me.Close()

        'Catch ex As ExceptionClass
        'Catch ex As System.Data.SqlClient.SqlException
        '    Call SQLException(ex)
        'Catch ex As Exception
        '    Call SoftException(ex)
        'End Try
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