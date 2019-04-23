Public Class SellInvoiceXMLSelector

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
        Call LoadSupporter()
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Call CloseWindow("nMakeSellInvoiceXML")
        Dim f As New MakeSellInvoiceXML With {.SupporterID = cSupporter.SelectedValue}
        AddChildForm("nMakeSellInvoiceXML", f)
        Me.Close()
    End Sub

End Class