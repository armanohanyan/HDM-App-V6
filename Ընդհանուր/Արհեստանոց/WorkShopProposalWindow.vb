Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class WorkShopProposalWindow

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            If CheckPermission2("E2CBE6EA5D1949F5825C7BB7D493B32E") = False Then Throw New Exception("Գործողությունը կատարելու համար դուք իրավասություն չունեք")

            If txtEcr.Text.Trim.Length <> 12 Then Throw New Exception("ՀԴՄ-ն պետք է ունենա 12 նիշ երկարություն")

            Dim dt As DataTable

            Dim IsReturned As Boolean

            Dim isCenter As Boolean

            If rReturned.Checked = True Then IsReturned = True Else IsReturned = False

            If IsReturned = False Then
                'Enter Workshop
                If iUser.DB <> 5 Then
                    'Dim IP As String = GetIpAddress()
                    isCenter = False
                    dt = iDB.GetWorkshopEcrByBranch(txtEcr.Text.Trim, iUser.DB)
                Else
                    isCenter = True
                    dt = iDB.GetWorkshopEcrByCenter(txtEcr.Text.Trim)
                End If
            Else
                'Return Workshop
                If iUser.DB <> 5 Then
                    isCenter = False
                    dt = iDB.ReturnWorkshopEcrByBranch(txtEcr.Text.Trim, iUser.DB)
                Else
                    isCenter = True
                    dt = iDB.ReturnWorkshopEcrByCenter(txtEcr.Text.Trim)
                End If
            End If

            Dim f As New ListOfWorkShopItems With {.isCenter = isCenter}
            f.ecr = txtEcr.Text.Trim

            Call CloseWindow("nListOfWorkShopItemsX")
            AddChildForm("nListOfWorkShopItemsX", f)

            f.GridControl2.BeginUpdate()
            f.GridControl2.DataSource = dt

            With f.GridView2
                .Columns("RemakeID").Visible = False
                .Columns("EcrID").Visible = False
                .Columns("ClientID").Visible = False
                .Columns("tarifID").Visible = False
                .Columns("Տարիֆ").Visible = False
                .Columns("Սպասարկող").Visible = False
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsCustomization.AllowColumnMoving = False
                .OptionsCustomization.AllowGroup = False

                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .Columns("RemakeID").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .Columns("ՀայտիԱմսաթիվ").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            End With

            f.GridView2.ClearSelection()
            f.GridControl2.EndUpdate()

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub txtEcr_TextChanged(sender As Object, e As EventArgs) Handles txtEcr.TextChanged
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
    End Sub

End Class