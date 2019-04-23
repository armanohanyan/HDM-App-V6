Public Class OpenPropSelector

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        Dim b As Boolean = rTotal.Checked

        Call CloseWindow("nOpenPropList")
        Dim f As New OpenPropList With {.IsTotal = b}
        AddChildForm("nOpenPropList", f)

        Me.Close()

    End Sub

End Class