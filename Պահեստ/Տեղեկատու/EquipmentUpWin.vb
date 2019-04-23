Public Class EquipmentUpWin

    Friend iID As Short = 0
    Friend iRecord As String = ""
    Friend canSel As Boolean
    Friend code As String

    Dim isLoading As Boolean = True

    Private Sub LoadAllowSell()
        Try
            Dim b As Boolean = iDB.GetEquipmentSellAllow(iID)
            ckAllowSell.Checked = b
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'Form Load
    Private Sub EquipmentUpWin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEquipment.Text = iRecord
        txtEquipment.Focus()
        ckCanSell.Checked = canSel
        If Not String.IsNullOrEmpty(code) Then txtCode.Text = code
        If canSel = True Then ckCanSell.Enabled = False

        LoadAllowSell()

        isLoading = False
    End Sub

    'Update
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrEmpty(txtEquipment.Text) Then Throw New Exception("Տվյալները գրված չեն")

            If ckCanSell.Checked = True Then
                'check if tarif has en equipment
                If iDB.EquipmentSellChange(iID) = True Then Throw New Exception("Փոփոխելուց առաջ հարկավոր է հեռացնել տարիֆներում առկա նյութի գրանցումները")
            End If

            If ckCanSell.Checked = True Then
                If canSel = False Then
                    iDB.UpdateEquipment2(txtEquipment.Text.Trim, iID, ckCanSell.Checked)
                Else
                    iDB.UpdateEquipment(txtEquipment.Text.Trim, iID, ckCanSell.Checked)
                End If
            Else
                iDB.UpdateEquipment(txtEquipment.Text.Trim, iID, ckCanSell.Checked)
            End If

            MsgBox("Տվյալը հաջողությամբ փոփոխվեցին", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ckAllowSell_CheckedChanged(sender As Object, e As EventArgs) Handles ckAllowSell.CheckedChanged
        If isLoading = True Then Exit Sub
        Try
            'Update Allow Sell
            If ckAllowSell.Checked = True Then
                iDB.AddEquipmentSellAllow(iID)
            Else
                iDB.DeleteEquipmentSellAllow(iID)
            End If

            MsgBox("Տվյալը հաջողությամբ փոփոխվեցին", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class