Imports System.Data.SqlClient

Partial Public Class DB

#Region "Procedure"

    'CheckClientEcr
    Friend Sub CheckClientEcr(ByVal ECR As String, ByVal user As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.CheckClientEcr @Ecr, @User", connection)
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = ECR
            cmdSQLcom.Parameters.Add("@User", Data.SqlDbType.VarChar).Value = user
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'QueueEcr
    Friend Sub QueueEcr(ByVal ClientEcr As String, ByVal SupporterEcrID As Integer, ByVal sUser As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.QueueEcr @ClientEcr,@SupporterEcrID,@sUser", connection)
            cmdSQLcom.Parameters.Add("@ClientEcr", Data.SqlDbType.VarChar).Value = ClientEcr
            cmdSQLcom.Parameters.Add("@SupporterEcrID", Data.SqlDbType.Int).Value = SupporterEcrID
            cmdSQLcom.Parameters.Add("@sUser", Data.SqlDbType.VarChar).Value = sUser
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ExtendExpireDate
    Friend Sub ExtendExpireDate(ByVal ECR As String, ByVal ExtDate As DateTime)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.ExtendExpireDate @Ecr,@ExtDate", connection)
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = ECR
            cmdSQLcom.Parameters.Add("@ExtDate", Data.SqlDbType.DateTime).Value = ExtDate
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ExtendExpireDate2
    Friend Sub ExtendExpireDate2(ByVal ECR As String, ByVal ExtDate As DateTime)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.ExtendExpireDate2 @Ecr,@ExtDate", connection)
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = ECR
            cmdSQLcom.Parameters.Add("@ExtDate", Data.SqlDbType.DateTime).Value = ExtDate
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ExtendExpireDateActive
    Friend Sub ExtendExpireDateActive(ByVal ECR As String, ByVal ExtDate As DateTime)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.ExtendExpireDateActive @Ecr,@ExtDate", connection)
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = ECR
            cmdSQLcom.Parameters.Add("@ExtDate", Data.SqlDbType.DateTime).Value = ExtDate
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteFromQueue
    Friend Sub DeleteFromQueue(ByVal ECR As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.DeleteFromQueue @Ecr", connection)
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = ECR
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddBank
    Friend Sub AddBank(ByVal Bank As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddBank @Bank", connection)
            cmdSQLcom.Parameters.Add("@Bank", Data.SqlDbType.NVarChar).Value = Bank
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ChangeBank
    Friend Sub ChangeBank(ByVal Bank As String, ByVal ID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ChangeBank @Bank,@ID", connection)
            cmdSQLcom.Parameters.Add("@Bank", Data.SqlDbType.NVarChar).Value = Bank
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.SmallInt).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteBank
    Friend Sub DeleteBank(ByVal ID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteBank @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.SmallInt).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddLicense
    Friend Sub AddLicense(ByVal Ecr As String, ByVal Lic As String, ByVal BankID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddLicense @Ecr,@Liecnse,@BankID", connection)
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@Liecnse", Data.SqlDbType.NVarChar).Value = Lic
            cmdSQLcom.Parameters.Add("@BankID", Data.SqlDbType.SmallInt).Value = BankID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ChangeLic
    Friend Sub ChangeLic(ByVal ID As Integer, ByVal Ecr As String, ByVal Lic As String, ByVal BankID As Short, ByVal IsActive As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ChangeLic @ID,@Ecr,@Bank,@Lic,@IsActive", connection)
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@Lic", Data.SqlDbType.NVarChar).Value = Lic
            cmdSQLcom.Parameters.Add("@Bank", Data.SqlDbType.SmallInt).Value = BankID
            cmdSQLcom.Parameters.Add("@IsActive", Data.SqlDbType.Bit).Value = IsActive
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteLic
    Friend Sub DeleteLic(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteLic @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddGPSForEcr
    Friend Sub AddGPSForEcr(ByVal Ecr As String, ByVal Latitude As String, ByVal Longitude As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddGPSForEcr @Ecr,@Latitude,@Longitude", connection)
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@Latitude", Data.SqlDbType.VarChar).Value = Latitude
            cmdSQLcom.Parameters.Add("@Longitude", Data.SqlDbType.VarChar).Value = Longitude
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'RemakeEcrClientOKChecker
    Friend Sub RemakeEcrClientOKChecker(ByVal RemakeID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.RemakeEcrClientOKChecker @RemakeID", connection)
            cmdSQLcom.Parameters.Add("@RemakeID", Data.SqlDbType.Int).Value = RemakeID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateIsOnline
    Friend Sub UpdateIsOnline(ByVal IsOnline As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Operator.UpdateIsOnline @IsOnline", connection)
            cmdSQLcom.Parameters.Add("@IsOnline", Data.SqlDbType.Bit).Value = IsOnline
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CheckForUpdate
    Friend Sub CheckForUpdate(ByVal ClientID As Integer, ByVal OldSupporter As Byte)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.CheckForUpdate @ClientID,@OldSupporter", connection)
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            cmdSQLcom.Parameters.Add("@OldSupporter", Data.SqlDbType.TinyInt).Value = OldSupporter
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddContractTarifChanged
    Friend Sub AddContractTarifChanged(ByVal ClientID As Integer, SupportedID As Byte, TesuchID As Short, Tarif As Decimal, PrintDate As DateTime, PrintUserID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddContractTarifChanged @ClientID,@SupportedID,@TesuchID,@Tarif,@PrintDate,@PrintUserID", connection)
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            cmdSQLcom.Parameters.Add("@SupportedID", Data.SqlDbType.TinyInt).Value = SupportedID
            cmdSQLcom.Parameters.Add("@TesuchID", Data.SqlDbType.SmallInt).Value = TesuchID
            cmdSQLcom.Parameters.Add("@Tarif", Data.SqlDbType.Decimal).Value = Tarif
            cmdSQLcom.Parameters.Add("@PrintDate", Data.SqlDbType.DateTime).Value = PrintDate
            cmdSQLcom.Parameters.Add("@PrintUserID", Data.SqlDbType.SmallInt).Value = PrintUserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ImportTarif
    Friend Sub ImportTarif(dt As DataTable, UserID As Short)

        Dim Parameters As New List(Of SqlParameter)
        With Parameters
            .Add(New SqlParameter("@UserID", UserID))
            Dim P As New SqlParameter("@T", dt) With {.TypeName = "poak.ImportTarif"}
            .Add(P)

        End With

        Using connection As New SqlConnection(SQLString)
            Dim Exec As New SqlCommand
            Exec.Connection = connection
            Exec.CommandText = "poak.ImportTarif"
            Exec.CommandType = CommandType.StoredProcedure
            Exec.Parameters.AddRange(Parameters.ToArray)
            connection.Open()
            Exec.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertEcrFromPoak
    Friend Sub InsertEcrFromPoak(Ecr As String, TesuchID As Short, BringDate As Date)
        Dim Parameters As New List(Of SqlParameter)
        With Parameters
            .Add(New SqlParameter("@Ecr", Ecr))
            .Add(New SqlParameter("@TesuchID", TesuchID))
            .Add(New SqlParameter("@BringDate", BringDate))
        End With
        Using connection As New SqlConnection(SQLString)
            Dim Exec As New SqlCommand
            Exec.Connection = connection
            Exec.CommandText = "Client.InsertEcrFromPoak"
            Exec.CommandType = CommandType.StoredProcedure
            Exec.Parameters.AddRange(Parameters.ToArray)
            connection.Open()
            Exec.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeletePoakOfficeEcr
    Friend Sub DeletePoakOfficeEcr(ID As Integer)
        Dim Parameters As New List(Of SqlParameter)
        With Parameters
            .Add(New SqlParameter("@ID", ID))
        End With
        Using connection As New SqlConnection(SQLString)
            Dim Exec As New SqlCommand
            Exec.Connection = connection
            Exec.CommandText = "Client.DeletePoakOfficeEcr"
            Exec.CommandType = CommandType.StoredProcedure
            Exec.Parameters.AddRange(Parameters.ToArray)
            connection.Open()
            Exec.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ReturnPoakOfficeEcr
    Friend Sub ReturnPoakOfficeEcr(ID As Integer)
        Dim Parameters As New List(Of SqlParameter)
        With Parameters
            .Add(New SqlParameter("@ID", ID))
        End With
        Using connection As New SqlConnection(SQLString)
            Dim Exec As New SqlCommand
            Exec.Connection = connection
            Exec.CommandText = "Client.ReturnPoakOfficeEcr"
            Exec.CommandType = CommandType.StoredProcedure
            Exec.Parameters.AddRange(Parameters.ToArray)
            connection.Open()
            Exec.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateEcrPoakToOffice
    Friend Sub UpdateEcrPoakToOffice(Ecr As String)
        Dim Parameters As New List(Of SqlParameter)
        With Parameters
            .Add(New SqlParameter("@Ecr", Ecr))
        End With
        Using connection As New SqlConnection(SQLString)
            Dim Exec As New SqlCommand
            Exec.Connection = connection
            Exec.CommandText = "Client.UpdateEcrPoakToOffice"
            Exec.CommandType = CommandType.StoredProcedure
            Exec.Parameters.AddRange(Parameters.ToArray)
            connection.Open()
            Exec.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateNDSToNoNDS
    Friend Sub UpdateNDSToNoNDS(ID As Integer)

        Dim Parameters As New List(Of SqlParameter)
        With Parameters
            .Add(New SqlParameter("@ID", ID))
        End With

        Using connection As New SqlConnection(SQLString)
            Dim Exec As New SqlCommand
            Exec.Connection = connection
            Exec.CommandText = "Client.UpdateNDSToNoNDS"
            Exec.CommandType = CommandType.StoredProcedure
            Exec.Parameters.AddRange(Parameters.ToArray)
            connection.Open()
            Exec.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'NewRemakeMessage
    Friend Sub NewRemakeMessage(Ecr As String, ProblemID As Integer, SendUserID As Short, U As DataTable)

        Dim Parameters As New List(Of SqlParameter)
        With Parameters
            .Add(New SqlParameter("@Ecr", Ecr))
            .Add(New SqlParameter("@ProblemID", ProblemID))
            .Add(New SqlParameter("@SendUserID", SendUserID))
            Dim P As New SqlParameter("@U", U) With {.TypeName = "Client.RecordID"}
            .Add(P)

        End With

        Using connection As New SqlConnection(SQLString)
            Dim Exec As New SqlCommand
            Exec.Connection = connection
            Exec.CommandText = "Client.NewRemakeMessage"
            Exec.CommandType = CommandType.StoredProcedure
            Exec.Parameters.AddRange(Parameters.ToArray)
            connection.Open()
            Exec.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

#End Region

#Region "Select"

    'GetReadyEcrForReplace
    Friend Function GetReadyEcrForReplace(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC tesuch.GetReadyEcrForReplace @Ecr"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ListOfWrongNumbers
    Friend Function ListOfWrongNumbers() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Operator.ListOfWrongNumbers()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetHvhhBySupporter
    Friend Function GetHvhhBySupporter() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetHvhhBySupporter()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRepTime1
    Friend Function GetRepTime1() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM tesuch.GetRepTime1()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ClosedRepEcrTimer
    Friend Function ClosedRepEcrTimer() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM tesuch.ClosedRepEcrTimer()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetBankList
    Friend Function GetBankList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetBankList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetLicenseList
    Friend Function GetLicenseList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetLicenseList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GprsHistoryByClientID
    Friend Function GprsHistoryByClientID(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GprsHistoryByClientID @ClientID"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GprsHistoryByEcr
    Friend Function GprsHistoryByEcr(ByVal Ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GprsHistoryByEcr @Ecr"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'NoGPSEcrClientsByDB
    Friend Function NoGPSEcrClientsByDB(ByVal db As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.NoGPSEcrClientsByDB @dbID"
                cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = db
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetClientForGps
    Friend Function GetClientForGps(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetClientForGps @ClientID"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RetExtGPSCo
    Friend Function RetExtGPSCo(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.RetExtGPSCo @ecr"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPartqInfoForLaw
    Friend Function GetPartqInfoForLaw(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetPartqInfoForLaw(@hvhh)"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetGpsRegAddrEcrList
    Friend Function GetGpsRegAddrEcrList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetGpsRegAddrEcrList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetGpsRegAddrEcrListCB
    Friend Function GetGpsRegAddrEcrListCB() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetGpsRegAddrEcrListCB()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'FiveMonthsRep
    Friend Function FiveMonthsRep(ByVal d As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.FiveMonthsRep @IntervalDate"
                cmd.Parameters.Add("@IntervalDate", SqlDbType.Date).Value = d
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RejList
    Friend Function RejList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.RejList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'PoakList
    Friend Function PoakList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.PoakList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetCurEcrByTesuch
    Friend Function GetCurEcrByTesuch() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetCurEcrByTesuch()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetCurFreeEcrByTesuch
    Friend Function GetCurFreeEcrByTesuch() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetCurFreeEcrByTesuch() Order by Տեսուչ, ՊատկանՀԴՄ"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepReplEcrFull
    Friend Function RepReplEcrFull(ByVal sDate As Date, ByVal eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.RepReplEcrFull @SDate,@EDate"
                cmd.Parameters.Add("@SDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@EDate", SqlDbType.Date).Value = eDate
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GorcAddrByRegion
    Friend Function GorcAddrByRegion(ByVal R As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GorcAddrByRegion(@R)"
                cmd.Parameters.Add("@R", SqlDbType.SmallInt).Value = R
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetOpenPropDetails
    Friend Function GetOpenPropDetails(ByVal IsTotal As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetOpenPropDetails @IsTotal"
                cmd.Parameters.Add("@IsTotal", SqlDbType.Bit).Value = IsTotal
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetDisolvedWorking
    Friend Function GetDisolvedWorking() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetDisolvedWorking()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'TesuchLoginRep
    Friend Function TesuchLoginRep() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM mobile.TesuchLoginRep() ORDER BY [Login]"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'getMarkers
    Friend Function getMarkers(TesuchID As Integer, sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC mobile.getMarkers @TesuchID,@sDate,@eDate"
                cmd.Parameters.Add("@TesuchID", SqlDbType.Int).Value = TesuchID
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GpsLocationGet
    Friend Function GpsLocationGet(TesuchID As Integer, sDate As Date, IntervalX As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC mobile.GpsLocationGet @TesuchID,@sDate,@IntervalX"
                cmd.Parameters.Add("@TesuchID", SqlDbType.Int).Value = TesuchID
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@IntervalX", SqlDbType.TinyInt).Value = IntervalX
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeDetails
    Friend Function GetRemakeDetails(ByVal RemakeID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetRemakeDetails(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTesuchLastMarkers
    Friend Function GetTesuchLastMarkers(ByVal TesuchID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC mobile.GetTesuchLastMarkers @TesuchID"
                cmd.Parameters.Add("@TesuchID", SqlDbType.Int).Value = TesuchID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'SmsForBlockinNotSupportedClients
    Friend Function SmsForBlockinNotSupportedClients(ByVal SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.SmsForBlockinNotSupportedClients @SupporterID"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'HaytAnalitics
    Friend Function HaytAnalitics(ByVal sd As Date, ByVal ed As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.HaytAnalitics @sDate,@eDate"
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = ed
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrPoakToOffice
    Friend Function GetEcrPoakToOffice() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetEcrPoakToOffice()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrPoakToOffice2
    Friend Function GetEcrPoakToOffice2(TesuchID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetEcrPoakToOffice() WHERE TesuchID = @TesuchID AND SendDate IS NULL"
                cmd.Parameters.Add("@TesuchID", SqlDbType.SmallInt).Value = TesuchID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrPoakToOfficeTotals
    Friend Function GetEcrPoakToOfficeTotals() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetEcrPoakToOfficeTotals()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'EcrTesuchData
    Friend Function EcrTesuchData(TesuchID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.EcrTesuchData(@TID)"
                cmd.Parameters.Add("@TID", SqlDbType.SmallInt).Value = TesuchID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Scalar"

    'NotSuppPhoneNumberCount
    Friend Function NotSuppPhoneNumberCount() As Integer
        Dim It As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Operator.NotSuppPhoneNumberCount()"
                It = cmd.ExecuteScalar()
            End Using
        End Using
        Return It
    End Function

    'GetEcrID
    Friend Function GetEcrID(ByVal Ecr As String) As Integer
        Dim It As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.GetEcrID(@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
                It = cmd.ExecuteScalar()
            End Using
        End Using
        Return It
    End Function

    'RetGPSByEcr
    Friend Function RetGPSByEcr(ByVal Ecr As String) As String
        Dim It As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.RetGPSByEcr(@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
                It = cmd.ExecuteScalar()
            End Using
        End Using
        Return It
    End Function

    'RetGPSByTesuch
    Friend Function RetGPSByTesuch(ByVal Tesuch As String) As String
        Dim It As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.RetGPSByTesuch(@Tesuch)"
                cmd.Parameters.Add("@Tesuch", SqlDbType.NVarChar).Value = Tesuch
                It = cmd.ExecuteScalar()
            End Using
        End Using
        Return It
    End Function

    'GetTesuchID
    Friend Function GetTesuchID(ByVal Ecr As String) As Integer
        Dim It As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT tesuch.GetTesuchID(@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
                It = cmd.ExecuteScalar()
            End Using
        End Using
        Return It
    End Function

    'RetTelNumber
    Friend Function RetTelNumber() As String
        Dim It As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Operator.RetTelNumber()"
                It = cmd.ExecuteScalar()
            End Using
        End Using
        Return It
    End Function

    'LocationForProp
    Friend Function LocationForProp(ecr As String, AddressCur As String) As String
        Dim It As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.LocationForProp(@Ecr,@AddressCur)"
                cmd.Parameters.Add("Ecr", SqlDbType.VarChar).Value = ecr
                cmd.Parameters.Add("AddressCur", SqlDbType.NVarChar).Value = AddressCur
                It = cmd.ExecuteScalar()
            End Using
        End Using
        Return It
    End Function

    'GetPropCount
    Friend Function GetPropCount(ByVal Tesuch As String) As Integer
        Dim It As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT tesuch.GetPropCount(@Tesuch)"
                cmd.Parameters.Add("@Tesuch", SqlDbType.NVarChar).Value = Tesuch
                It = cmd.ExecuteScalar()
            End Using
        End Using
        Return It
    End Function

    'IsBattary
    Friend Function IsBattary(ByVal RemakeID As Integer) As Boolean
        Dim It As Boolean
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsBattary(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                It = cmd.ExecuteScalar()
            End Using
        End Using
        Return It
    End Function

    'GetPoakTariff
    Friend Function GetPoakTariff(ByVal hvhh As String) As Short
        Dim It As Short
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT poak.GetPoakTariff(@HVHH)"
                cmd.Parameters.Add("@HVHH", SqlDbType.NVarChar).Value = hvhh
                It = cmd.ExecuteScalar()
            End Using
        End Using
        Return It
    End Function

#End Region

End Class