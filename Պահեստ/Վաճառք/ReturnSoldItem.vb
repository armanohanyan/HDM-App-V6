Public Class ReturnSoldItem

    Friend IsLocalSell As Boolean = False
    Friend SupporterID As Byte
    Friend SuppClient As Byte
    Friend ClientID As Integer

    Friend Property SID As Integer

    Friend ShtrikhArray As New List(Of String)

    Private Sub txtShtrikhCode_TextChanged(sender As Object, e As EventArgs) Handles txtShtrikhCode.TextChanged
        Try
            If txtShtrikhCode.Text.Trim.Length <> 7 Then Exit Sub

            Dim sCode As String = txtShtrikhCode.Text.Trim

            Dim b As Boolean = False
            For i As Integer = 0 To ShtrikhArray.Count - 1
                If sCode = ShtrikhArray.Item(i) Then
                    b = True
                    Exit For
                End If
            Next

            If b = False Then Throw New Exception("Շտրիխ կոդը սխալ է")

            'Remote Warehouse Check
            If iUser.DB = 1 Then
                iDB.CheckHSMShtrikhWarehouseItem2(txtShtrikhCode.Text.Trim)
            Else
                iDB.CheckShtrikhWarehouseItem2(txtShtrikhCode.Text.Trim)
            End If

            Dim dt As DataTable
            If IsLocalSell = True Then
                If SuppClient = 1 Then If iDB.HdmShtrikhIsLocalTransferDone(sCode) > 0 Then Throw New Exception("Սարքավորման համար կատարվել է ներքին տեղափոխություն")

                If SupporterID = 2 Then
                    dt = iDB.RollbackCustomSellForSupporterNoNDS(sCode, SupporterID, SuppClient, True)
                Else
                    dt = iDB.RollbackCustomSellForSupporter(sCode, SupporterID, SuppClient, True)
                End If

                SID = dt.Rows(0)(0)
            Else

                If SupporterID = 2 Then
                    dt = iDB.RollbackCustomSellForSupporterNoNDS(sCode, SupporterID, ClientID, False)
                Else
                    dt = iDB.RollbackCustomSellForSupporter(sCode, SupporterID, ClientID, False)
                End If

                SID = dt.Rows(0)(0)
            End If

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            Me.Close()

        Catch ex As ExceptionClass
            SID = -1
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            SID = -1
        Catch ex As Exception
            Call SoftException(ex)
            SID = -1
        Finally
            If SID = -1 Then Me.Close()
        End Try
    End Sub

End Class