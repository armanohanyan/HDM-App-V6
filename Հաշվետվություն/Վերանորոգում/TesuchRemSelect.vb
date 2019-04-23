Public Class TesuchRemSelect

    Private Sub TesuchRemSelect_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        sDate.DateTime = DateSerial(Now.Year, Now.Month, 1)
        eDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Call CloseWindow("nTesuchRemRep")
        Dim f As New TesuchRemRep With {.sDate = sDate.DateTime, .eDate = DateAdd(DateInterval.Day, 1, eDate.DateTime)}
        AddChildForm("nTesuchRemRep", f)

        Me.Close()
    End Sub

End Class