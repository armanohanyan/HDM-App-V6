Public Class RepRemakeTimeCounter

    Private Sub RepSelRemakeDayCounter_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        On Error Resume Next

        sDate.Properties.MaxValue = Now
        eDate.Properties.MaxValue = Now

        sDate.DateTime = Now
        eDate.DateTime = Now
    End Sub
    Private Sub btnBranchWorkShowToCenter_Click(sender As Object, e As EventArgs) Handles btnBranchWorkShowToCenter.Click
        Call CloseWindow("nRemTimeWindow")
        Dim f As New RemTimeWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 1, .Text = "Մասնաճյուղի Արհեստանոց - Կենտրոնի Սրահ"}
        AddChildForm("nRemTimeWindow", f)
        Me.Close()
    End Sub
    Private Sub btnCenterToBranch_Click(sender As Object, e As EventArgs) Handles btnCenterToBranch.Click
        Call CloseWindow("nRemTimeWindow")
        Dim f As New RemTimeWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 2, .Text = "Կենտրոնի Սրահից - Մասնաճյուղի Սրահ"}
        AddChildForm("nRemTimeWindow", f)
        Me.Close()
    End Sub
    Private Sub btnWorkToCenter_Click(sender As Object, e As EventArgs) Handles btnWorkToCenter.Click
        Call CloseWindow("nRemTimeWindow")
        Dim f As New RemTimeWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 3, .Text = "Արհեստանոցից - Սրահ"}
        AddChildForm("nRemTimeWindow", f)
        Me.Close()
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Call CloseWindow("nRemTimeWindow")
        Dim f As New RemTimeWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 4, .Text = "Սրահից - Արհեստանոց"}
        AddChildForm("nRemTimeWindow", f)
        Me.Close()
    End Sub
    Private Sub btnApprovedNotSend_Click(sender As Object, e As EventArgs) Handles btnApprovedNotSend.Click
        Call CloseWindow("nRemTimeWindow")
        Dim f As New RemTimeWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 5, .Text = "Հաստատված - Չտրամադրված"}
        AddChildForm("nRemTimeWindow", f)
        Me.Close()
    End Sub
    Private Sub btnRemakeDuration_Click(sender As Object, e As EventArgs) Handles btnRemakeDuration.Click
        Call CloseWindow("nRemTimeWindow")
        Dim f As New RemTimeWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 6, .Text = "Վերանորոգման Տևողություն"}
        AddChildForm("nRemTimeWindow", f)
        Me.Close()
    End Sub
    Private Sub btnRemakeWorkshop_Click(sender As Object, e As EventArgs) Handles btnRemakeWorkshop.Click
        Call CloseWindow("nRemTimeWindow")
        Dim f As New RemTimeWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 7, .Text = "Վերանորոգման Տևողություն (Արհեստանոց)"}
        AddChildForm("nRemTimeWindow", f)
        Me.Close()
    End Sub

End Class