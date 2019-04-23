Public Class RepSelRemakeDayCounter

    Private Sub RepSelRemakeDayCounter_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        On Error Resume Next

        sDate.Properties.MinValue = New Date(2015, 11, 3)
        eDate.Properties.MinValue = New Date(2015, 11, 3)

        sDate.Properties.MaxValue = Now
        eDate.Properties.MaxValue = Now

        sDate.DateTime = Now ' DateSerial(Now.Year, Now.Month, 1)
        eDate.DateTime = Now 'DateSerial(Now.Year, Now.Month + 1, 1 - 1)
    End Sub
    Private Sub btnSrahNorog_Click(sender As Object, e As EventArgs) Handles btnSrahNorog.Click
        Call CloseWindow("nRemakeDayCounterWindow")
        Dim f As New RemakeDayCounterWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 1, .Text = "Սրահում Առկա Նորոգված"}
        AddChildForm("nRemakeDayCounterWindow", f)
        Me.Close()
    End Sub
    Private Sub btnSrahNorNorog_Click(sender As Object, e As EventArgs) Handles btnSrahNorNorog.Click
        Call CloseWindow("nRemakeDayCounterWindow")
        Dim f As New RemakeDayCounterWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 2, .Text = "Սրահում Պատրաստ Չհաստատված"}
        AddChildForm("nRemakeDayCounterWindow", f)
        Me.Close()
    End Sub
    Private Sub btnWorkshopNorog_Click(sender As Object, e As EventArgs) Handles btnWorkshopNorog.Click
        Call CloseWindow("nRemakeDayCounterWindow")
        Dim f As New RemakeDayCounterWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 3, .Text = "Արհեստանոցում Վերանորոգված"}
        AddChildForm("nRemakeDayCounterWindow", f)
        Me.Close()
    End Sub
    Private Sub btnWorkshopExists_Click(sender As Object, e As EventArgs) Handles btnWorkshopExists.Click
        Call CloseWindow("nRemakeDayCounterWindow")
        Dim f As New RemakeDayCounterWindow With {.sDate = sDate.DateTime, .eDate = eDate.DateTime, .Direction = 4, .Text = "Արհեստանոցում Առկա"}
        AddChildForm("nRemakeDayCounterWindow", f)
        Me.Close()
    End Sub

End Class