Public Class MultiRemakeSelect

    Private Sub MultiRemakeSelect_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        sDate.DateTime = DateSerial(Now.Year, Now.Month, 1)
        eDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Call CloseWindow("nMultiRepRemakeEcr")
        Dim f As New MultiRepRemakeEcr With {.sDate = sDate.DateTime, .eDate = DateAdd(DateInterval.Day, 1, eDate.DateTime)}
        AddChildForm("nMultiRepRemakeEcr", f)

        Me.Close()
    End Sub

End Class