Public Class RemoveEquipmentFromWorkshop

    Friend RemakeID As Integer
    Friend isCenter As Boolean

    Private Sub txtShtrikh_EditValueChanged(sender As Object, e As EventArgs) Handles txtShtrikh.EditValueChanged
        Try
            If txtShtrikh.Text.Trim.Length <> 7 Then Exit Sub

            Dim isRemote As Boolean

            If GetIpAddress.StartsWith("192.168.22.") Then
                isRemote = True
            Else
                isRemote = False
            End If

            iDB.DeleteWorkshopEquipment2(txtShtrikh.Text.Trim, isRemote, RemakeID, isCenter)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub RemoveEquipmentFromWorkshop_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckPermission2("E0499EBBC5C64B0FBD877CBC9E2902EC") = False Then txtShtrikh.Enabled = False
    End Sub

End Class