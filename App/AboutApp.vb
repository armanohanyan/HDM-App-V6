Public NotInheritable Class AboutApp

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
    Private Sub AboutApp_Load(sender As Object, e As EventArgs) Handles Me.Load
        LabelVersion.Text = "Տարբերակ   " & My.Application.Info.Version.ToString
        LabelCopyright.Text = My.Application.Info.Copyright.ToString
    End Sub

End Class