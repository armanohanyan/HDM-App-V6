Public Class NonPayedRemakeSelTool

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Call CloseWindow("nNotPayedRemakeWindow")
        Dim f As New NotPayedRemakeWindow With {.isAmpop = rbAll.Checked, .startDate = sDate.DateTime, .endDate = eDate.DateTime}
        AddChildForm("nNotPayedRemakeWindow", f)
        Me.Close()
    End Sub
    Private Sub NonPayedRemakeSelTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        sDate.DateTime = DateSerial(Now.Year, Now.Month, 1)
        eDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
    End Sub

End Class