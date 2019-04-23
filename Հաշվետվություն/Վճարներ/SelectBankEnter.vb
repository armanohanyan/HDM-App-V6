Public Class SelectBankEnter

    Private Sub SelectBankEnter_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Dim dt As DataTable = iDB.GetSupporterForSelect3()
            With cSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                If iUser.DB <> 5 Then .SelectedValue = iUser.DB : cSupporter.Enabled = False
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Call CloseWindow("nRepBankEnter")
        Dim f As New RepBankEnter With {.SupporterID = cSupporter.SelectedValue, .sDate = sDate.DateTime, .eDate = eDate.DateTime}
        AddChildForm("nRepBankEnter", f)
        Me.Close()
    End Sub
    Private Sub SelectBankEnter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With sDate
            .DateTime = DateSerial(Now.Year, Now.Month, 1)
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
        With eDate
            .DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
    End Sub

End Class