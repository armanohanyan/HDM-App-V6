Public Class InnerInvoiceXMLSelector

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
        sDate.DateTime = DateSerial(Now.Year, Now.Month, 1)
        eDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)

        Call LoadSupporter()
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            Call CloseWindow("nMakeInnerInvoiceXML")
            Dim f As New MakeInnerInvoiceXML With {.SupporterID = cSupporter.SelectedValue, .StartDate = sDate.DateTime, .EndDate = eDate.DateTime}
            AddChildForm("nMakeInnerInvoiceXML", f)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class