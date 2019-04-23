Public Class printNoPrintInvoiceSelect

    Private Sub printNoPrintInvoiceSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cMonth
            .Items.Clear()
            For i As Integer = 1 To 12
                .Items.Add(i)
            Next
            .SelectedItem = Now.Month
        End With

        With cYear
            .Items.Clear()
            For i As Integer = 2013 To 2025
                .Items.Add(i)
            Next
            .SelectedItem = Now.Year
        End With
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            Dim y As Short = cYear.Text
            Dim m As Byte = cMonth.Text

            If cPrinted.Checked = True Then
                If cRet.Checked = True Then
                    Call CloseWindow("nReturnedInv")
                    Dim f As New ReturnedInv With {.Y = y, .M = m, .isAll = ckAll.Checked}
                    AddChildForm("nReturnedInv", f)
                Else
                    Call CloseWindow("nNotRetInvocie")
                    Dim f As New notRetInvocie With {.Y = y, .M = m, .isAll = ckAll.Checked}
                    AddChildForm("nNotRetInvocie", f)
                End If
            Else
                Call CloseWindow("nNotPrintedSupportInvoiceWindow")
                Dim f As New NotPrintedSupportInvoiceWindow With {.Y = y, .M = m}
                AddChildForm("nNotPrintedSupportInvoiceWindow", f)
            End If

            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class