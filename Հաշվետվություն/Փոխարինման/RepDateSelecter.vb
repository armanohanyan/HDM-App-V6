Public Class RepDateSelecter

    Private Sub RepDateSelecter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With sDate
            .DateTime = DateSerial(Now.Year, Now.Month, 1)
            .Properties.DisplayFormat.FormatString = "dd.MM.yy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
        With eDate
            .DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
            .Properties.DisplayFormat.FormatString = "dd.MM.yy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Try

            Dim sD As Date = sDate.DateTime
            Dim eD As Date = eDate.DateTime

            Call CloseWindow("nGetAllReplacedEcr")
            Dim f As New RepEcrForReplace With {.sDate = sD, .eDate = eD}
            AddChildForm("nGetAllReplacedEcr", f)

            Me.Close()

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

End Class