Imports System.Data.SqlClient

Partial Public Class DB

    Public Enum HdmSearchType
        ՀԴՄ = 0
        ՀՎՀՀ = 1
        ՄԳՀ = 2
        Պայմանագիր = 3
        GPRS = 4
        IP = 5
        ԳործունեությանՀասցե = 6
        Կազմակերպություն = 7
        Տարածաշրջան = 8
        ԱռաքմանՀասցե = 9
        Տեսուչ = 10
        ՀԾ = 11
    End Enum

#Region "Connection"

    'Connect To DB
    Friend Function ConnectToDB(ByVal strLogin As String, ByVal strPassword As String) As DataTable

        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC users.TryLogin @strLogin,@strPassword"
                cmd.Parameters.Add("@strLogin", Data.SqlDbType.NVarChar).Value = strLogin
                cmd.Parameters.Add("@strPassword", Data.SqlDbType.NVarChar).Value = strPassword
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
            cnn.Close()
        End Using

        If dt Is Nothing Then Throw New Exception("Բազայում նման գրանցում չի հայտնաբերվել, կամ բազայի հետ կապն ընդհատվել է")
        If dt.Rows.Count = 0 Then Throw New Exception("Բազայում նման գրանցում չի հայտնաբերվել")
        If dt.Rows.Count > 1 Then Throw New Exception("Հայտնաբերվել են մեկից ավելի գրանցումներ")
        If dt.Rows(0)("ActiveStatus") <> True Then Throw New Exception("Ձեր օգտանունը արգելափակված է")

        Return dt

    End Function

#End Region

#Region "Users"

    'Get Login Names
    Friend Function GetLoginNames() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT UserID,LoginName FROM Users.GetLoginNames()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'Reset User Password
    Friend Sub ResetUserPassword(ByVal strPass As String, ByVal UserID As Short)

        Using connection As New SqlConnection With {.ConnectionString = SQLString}
            Using command As New SqlCommand("EXEC Users.ResetUserPassword @strPass,@UserID", connection)
                With command
                    .Parameters.Add("@strPass", SqlDbType.NVarChar).Value = strPass
                    .Parameters.Add("@UserID", SqlDbType.SmallInt).Value = UserID
                    .Connection.Open()
                    .ExecuteNonQuery()
                    .Connection.Close()
                End With
            End Using
        End Using

    End Sub

    'Change User Password
    Friend Sub ChangeUserPassword(ByVal strNewPass As String, ByVal strOldPass As String, ByVal UserID As Short)

        Using connection As New SqlConnection With {.ConnectionString = SQLString}
            Using command As New SqlCommand("EXEC Users.ChangeUserPassword @UserID,@strOldPass,@strPass", connection)
                With command
                    .Parameters.Add("@strPass", SqlDbType.NVarChar).Value = strNewPass
                    .Parameters.Add("@strOldPass", SqlDbType.NVarChar).Value = strOldPass
                    .Parameters.Add("@UserID", SqlDbType.SmallInt).Value = UserID
                    .Connection.Open()
                    .ExecuteNonQuery()
                    .Connection.Close()
                End With
            End Using
        End Using

    End Sub

#End Region

#Region "UniQuery"

    Friend Function QueryToSqlServer(ByVal CommandText As String, ByVal SqlCommandType As CommandType, ByVal p() As SqlClient.SqlParameter) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = SqlCommandType
                cmd.CommandText = CommandText
                cmd.Parameters.AddRange(p)
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
            cnn.Close()
        End Using
        Return dt
    End Function
    Friend Function QueryToSqlServer2(ByVal CommandText As String, ByVal SqlCommandType As CommandType) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = SqlCommandType
                cmd.CommandText = CommandText
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
            cnn.Close()
        End Using
        Return dt
    End Function

    Friend Sub ExecToSql(ByVal CommandText As String, ByVal SqlCommandType As CommandType, ByVal p() As SqlClient.SqlParameter)
        Using connection As New SqlConnection(SQLString)
            Dim Exec As New SqlCommand
            Exec.Connection = connection
            Exec.CommandText = CommandText
            Exec.CommandType = SqlCommandType
            Exec.Parameters.AddRange(p)
            connection.Open()
            Exec.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

#End Region

#Region "Select Data"

    'GetTesuchList
    Friend Function GetTesuchList() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Tesuch.GetTesuchList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetWorkingTesuchList
    Friend Function GetWorkingTesuchList() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Տեսուչ,Կարգավիճակ,ԷլՓոստ,Հեռախոս FROM Tesuch.GetTesuchList() WHERE Կարգավիճակ=1 ORDER BY Ռեգիոն, Տեսուչ"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetAdditionalsList
    Friend Function GetAdditionalsList() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetAdditionalsList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetWorkingTesuchListForRemake
    Friend Function GetWorkingTesuchListForRemake() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT -1 ՀՀ,N' - ' Տեսուչ UNION SELECT ՀՀ,Տեսուչ FROM Tesuch.GetTesuchList() WHERE Կարգավիճակ = 1"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetWorkingTesuch
    Friend Function GetWorkingTesuch() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Տեսուչ FROM Tesuch.GetTesuchList() WHERE Կարգավիճակ = 1"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetWorkingTesuch2
    Friend Function GetWorkingTesuch2() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ID, Name FROM Client.GetEcrTesuch()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetTesuchRegionInfo
    Friend Function GetTesuchRegionInfoList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Տեսուչ,Տարածաշրջան FROM tesuch.GetTesuchRegionInfoList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ExtRepEcr
    Friend Function ExtRepEcr() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM tesuch.ExtRepEcr()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetTarajamket
    Friend Function GetTarajamket(Optional ByVal equipmentId As Int16 = 0) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetTarajamket(@equipmentId)"
                cmd.Parameters.Add("@equipmentId", SqlDbType.SmallInt).Value = equipmentId
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTarajamketByTarajamketId
    Friend Function GetTarajamketByTarajamketId(ByVal tarajamketId As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetTarajamketByTarajamketId(@tarajamketId)"
                cmd.Parameters.Add("@tarajamketId", SqlDbType.SmallInt).Value = tarajamketId
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTarajamketGraphiks
    Friend Function GetTarajamketGraphiks(Optional ByVal tarajamketId As Integer = 0) As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetTarajamketGraphiks(@tarajamketId)"
                cmd.Parameters.Add("@tarajamketId", SqlDbType.Int).Value = tarajamketId
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetRegion
    Friend Function GetRegion() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Տարածաշրջան FROM Client.GetRegion()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetRegion2
    Friend Function GetRegion2() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Տարածաշրջան,Տեսուչ FROM Client.GetRegion2()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetRegionNotYerevan
    Friend Function GetRegionNotYerevan() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Տարածաշրջան FROM Client.GetRegion() WHERE LEFT(Տարածաշրջան,5)<>N'Երևան'"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetContract
    Friend Function GetContract() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Պայմանագիր FROM Client.GetContract()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetAddress
    Friend Function GetAddress() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Հասցե FROM Client.GetAddress()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetObjectType
    Friend Function GetObjectType() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,ՕբյեկտիՏեսակ FROM Client.GetObjectType()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTHT
    Friend Function GetTHT() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,ՏՀՏ FROM Client.GetTHT()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTesuchEcr
    Friend Function GetTesuchEcr() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM tesuch.GetTesuchEcr()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetDataFor_PoakToDB
    Friend Function PoakToDBForAdd(ByVal status As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 120
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC poak.poakToDBForAdding @status"
                cmd.Parameters.Add("status", SqlDbType.NVarChar).Value = status
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetDataFor_PoakToDBReRegister
    Friend Function PoakToDBReRegister() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 120
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC poak.poakToDBGetReRegistering"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetDataFor_PoakToDBMGH
    Friend Function PoakToDBMGH() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 120
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC poak.poakToDBMGHChanges"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetNotRecievedContracts
    Friend Function GetNotRecievedContracts() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 120
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC poak.GetNotRecievedContracts"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetDataFor_BazaPoak
    Friend Function BazaPoak() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC poak.BazaPoak"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetGarantHDM
    Friend Function GetGarantHDM() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 600
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "EXEC poak.GetGarantHDM"
                Else
                    cmd.CommandText = "EXEC poak.GetGarantHDM_DB @dbID"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetNotGarantHDM
    Friend Function GetNotGarantHDM() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 120
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "EXEC poak.GetNotGarantHDM"
                Else
                    cmd.CommandText = "EXEC poak.GetNotGarantHDM_DB @dbID"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'HDMStatusByPoak
    Friend Function HDMStatusByPoak(ByVal hdm As String, sYear As Short, sMonth As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@HDM", SqlDbType.VarChar).Value = hdm
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = sYear
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = sMonth
                cmd.CommandText = "EXEC poak.HDMStatusByPoak @HDM,@Y,@M"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'BlockedGPRSList
    Friend Function BlockedGPRSList(o As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 150    'Arman
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "EXEC Client.BlockedGPRSList @O"
                    cmd.Parameters.Add("@O", SqlDbType.Char).Value = o
                Else
                    cmd.CommandText = "EXEC Client.BlockedGPRSList @O,@dbID"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.Parameters.Add("@O", SqlDbType.Char).Value = o
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetBlockedEcrDetails
    Friend Function GetBlockedEcrDetails(ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 150    'Arman
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetBlockedEcrDetails @ecr"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'BlockedGPRSListReport
    Friend Function BlockedGPRSListReport(Optional ByVal dbID As Byte = 5) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.BlockedGPRSListReport @dbID"
                cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = dbID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'BlockedGPRSListReport2
    Friend Function BlockedGPRSListReport2(ByVal ClientID As Integer, Optional ByVal dbID As Byte = 5) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.BlockedGPRSListReport2 @ClientID,@dbID"
                cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = dbID
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetWorkingDaysCountByCompany
    Friend Function GetWorkingDaysCountByCompany() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC poak.GetWorkingDaysCountByCompany"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetWorkingDaysCountByMonth
    Friend Function GetWorkingDaysCountByMonth(ByVal sYear As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sYear", SqlDbType.SmallInt).Value = sYear
                cmd.CommandText = "EXEC poak.GetWorkingDaysCountByMonth @sYear"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetWorkingDaysCountByYearAndMonth
    Friend Function GetWorkingDaysCountByYearAndMonth(ByVal sDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.CommandText = "EXEC poak.GetWorkingDaysCountByYearAndMonth @sDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetBlockedGPRS
    Friend Function GetBlockedGPRS() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "EXEC Client.GetBlockedGPRS"
                Else
                    cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = DBNull.Value
                    cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.CommandText = "EXEC Client.GetBlockedGPRS @ClientID,@SupporterID"
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetBlockedGPRS2
    Friend Function GetBlockedGPRS2(ByVal ID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ID
                    cmd.CommandText = "EXEC Client.GetBlockedGPRS @ClientID"
                Else
                    cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ID
                    cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.CommandText = "EXEC Client.GetBlockedGPRS @ClientID,@SupporterID"
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetHdmSearch
    Friend Function GetHdmSearch(ByVal Phrase As String, ByVal searchType As HdmSearchType) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Phrase", SqlDbType.NVarChar).Value = Phrase
                cmd.Parameters.Add("@searchType", SqlDbType.TinyInt).Value = searchType
                If iUser.DB = 5 Then
                    cmd.CommandText = "EXEC Client.GetHdmSearch @Phrase,@searchType"
                Else
                    cmd.CommandText = "EXEC Client.GetHdmSearchDB @Phrase,@searchType,@dbID"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAllClientInfo
    Friend Function GetAllClientInfo(ByVal db As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetAllClientInfo @Supporter"
                cmd.Parameters.Add("@Supporter", SqlDbType.TinyInt).Value = db
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAllEcrInfo
    Friend Function GetAllEcrInfo(ByVal db As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetAllEcrInfo @Supporter"
                cmd.Parameters.Add("@Supporter", SqlDbType.TinyInt).Value = db
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetUserMessages
    Friend Function GetUserMessages(ByVal reciverID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@reciverID", SqlDbType.SmallInt).Value = reciverID
                cmd.CommandText = "EXEC Users.GetUserMessages @reciverID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetUserMessages2
    Friend Function GetUserMessages2(ByVal ID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID
                cmd.CommandText = "EXEC Users.GetUserMessages2 @ID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetUserArchiveMessages
    Friend Function GetUserArchiveMessages(ByVal reciverID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@reciverID", SqlDbType.SmallInt).Value = reciverID
                cmd.CommandText = "EXEC Users.GetUserArchiveMessages @reciverID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrShipping
    Friend Function GetEcrShipping(ByVal EcrGUID As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@EcrGUID", SqlDbType.VarChar).Value = EcrGUID
                cmd.CommandText = "EXEC Client.GetEcrShipping @EcrGUID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInRoadEcrShipping
    Friend Function GetInRoadEcrShipping() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ShippingID,ՀԴՄ,Տարածաշրջան,ԺամանմանՎայր,ԺամանմանԺամ,ՎարորդիՀեռախոս,ՄեքենայիՀամար,ԳրանցմանԱմսաթիվ FROM Client.GetInRoadEcrShipping()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInRoadEcrShipping2
    Friend Function GetInRoadEcrShipping2(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT ShippingID,ՀԴՄ,Տարածաշրջան,ԺամանմանՎայր,ԺամանմանԺամ,ՎարորդիՀեռախոս,ՄեքենայիՀամար,ԳրանցմանԱմսաթիվ FROM Client.GetInRoadEcrShipping2(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInRoadRemontEcrShipping
    Friend Function GetInRoadRemontEcrShipping() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀԴՄ,Տարածաշրջան,ԺամանմանՎայր,ԺամանմանԺամ,ՎարորդիՀեռախոս,ՄեքենայիՀամար,ԳրանցմանԱմսաթիվ,ՎերանորոգմանԱմսաթիվ FROM Client.GetInRoadRemontEcrShipping()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInRoadRemontEcrShipping2
    Friend Function GetInRoadRemontEcrShipping2(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT ՀԴՄ,Տարածաշրջան,ԺամանմանՎայր,ԺամանմանԺամ,ՎարորդիՀեռախոս,ՄեքենայիՀամար,ԳրանցմանԱմսաթիվ,ՎերանորոգմանԱմսաթիվ FROM Client.GetInRoadRemontEcrShipping2(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetReadyRemontEcrShipping
    Friend Function GetReadyRemontEcrShipping() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ShippingID,ՀԴՄ,Տարածաշրջան,ԺամանմանՎայր,ԺամանմանԺամ,ՎարորդիՀեռախոս,ՄեքենայիՀամար,ԳրանցմանԱմսաթիվ,ՎերանորոգմանԱմսաթիվ,ՊատրաստմանԱմսաթիվ FROM Client.GetReadyRemontEcrShipping()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetReadyRemontEcrShipping2
    Friend Function GetReadyRemontEcrShipping2(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT ShippingID,ՀԴՄ,Տարածաշրջան,ԺամանմանՎայր,ԺամանմանԺամ,ՎարորդիՀեռախոս,ՄեքենայիՀամար,ԳրանցմանԱմսաթիվ,ՎերանորոգմանԱմսաթիվ,ՊատրաստմանԱմսաթիվ FROM Client.GetReadyRemontEcrShipping2(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAllEcrShipping
    Friend Function GetAllEcrShipping() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀԴՄ,Տարածաշրջան,ԺամանմանՎայր,ԺամանմանԺամ,ՎարորդիՀեռախոս,ՄեքենայիՀամար,ԳրանցմանԱմսաթիվ,ՎերանորոգմանԱմսաթիվ,ՊատրաստմանԱմսաթիվ,ՓակմանԱմսաթիվ FROM Client.GetAllEcrShipping()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAllEcrShipping2
    Friend Function GetAllEcrShipping2(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT ՀԴՄ,Տարածաշրջան,ԺամանմանՎայր,ԺամանմանԺամ,ՎարորդիՀեռախոս,ՄեքենայիՀամար,ԳրանցմանԱմսաթիվ,ՎերանորոգմանԱմսաթիվ,ՊատրաստմանԱմսաթիվ,ՓակմանԱմսաթիվ FROM Client.GetAllEcrShipping2(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetHVHHSearch
    Friend Function GetHVHHSearch(ByVal Phrase As String, ByVal searchType As HdmSearchType) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Phrase", SqlDbType.NVarChar).Value = Phrase
                cmd.Parameters.Add("@searchType", SqlDbType.TinyInt).Value = searchType
                If iUser.DB = 5 Then
                    cmd.CommandText = "EXEC Client.GetHVHHSearch @Phrase,@searchType"
                Else
                    cmd.CommandText = "EXEC Client.GetHVHHSearchDB @Phrase,@searchType,@dbID"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTarif
    Friend Function GetTarif() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Տարիֆ FROM Payment.GetTarif() order by Տարիֆ"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporter
    Friend Function GetSupporter() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,ՀՎՀՀ,Կազմակերպություն,Հասցե,Տնօրեն,Հաշվապահ,Բանկ,ԲանկայինՀաշիվ,Հապավում,ԻնվՀապ,ԱԱՀ FROM Supporter.GetSupporter()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPayTypes
    Friend Function GetPayTypes() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM payment.GetPayTypes()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEquipments
    Friend Function GetEquipments() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetEquipments()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ''GetEquipments
    'Friend Function GetTarajamket() As DataTable
    '    Dim dt As DataTable
    '    Using cnn As New SqlConnection(SQLString)
    '        cnn.Open()
    '        Using cmd As New SqlCommand
    '            cmd.Connection = cnn
    '            cmd.CommandType = CommandType.Text
    '            cmd.CommandText = "SELECT * FROM Client.GetEquipments()"
    '            Using da As New SqlDataAdapter(cmd)
    '                dt = New System.Data.DataTable
    '                da.Fill(dt)
    '            End Using
    '        End Using
    '    End Using
    '    Return dt
    'End Function

    'GetSMSTitles
    Friend Function GetSMSTitles(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT * FROM Client.GetSMSTitles(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSMSText
    Friend Function GetSMSText(ID As Integer) As String
        Dim t As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = ID
                cmd.CommandText = "SELECT * FROM Client.GetSMSText(@ID)"
                t = cmd.ExecuteScalar
            End Using
        End Using
        Return t
    End Function

    'GetRekvizitsForSMS
    Friend Function GetRekvizitsForSMS(SuporterID As Integer) As String
        Dim t As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SuporterID", SqlDbType.TinyInt).Value = SuporterID
                cmd.CommandText = "SELECT * FROM Client.GetRekvizitsForSMS(@SuporterID)"
                t = cmd.ExecuteScalar
            End Using
        End Using
        Return t
    End Function

    'GetHVHHsForSell
    Friend Function GetHVHHsForSell() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetHVHHsForSell()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetHVHHsForSellEcr
    Friend Function GetHVHHsForSellEcr() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetHVHHsForSellEcr()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetHVHHsForSellEcrFiz
    Friend Function GetHVHHsForSellEcrFiz() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetHVHHsForSellEcrFiz()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetProposalDatales
    Friend Function GetProposalDatales(ByVal PropId As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetProposalDatales(@PropId)"
                cmd.Parameters.Add("@PropId", SqlDbType.Int).Value = PropId
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetCompanyWarehouse
    Friend Function GetCompanyWarehouse() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GetCompanyWarehouse()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetHVHHInfo
    Friend Function GetHVHHInfo(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetHVHHInfo(@ClientID)"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeHDMByCompany
    Friend Function GetRemakeHDMByCompany(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT * FROM Client.GetRemakeHDMByCompany(@ClientID)"
                Else
                    cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.CommandText = "SELECT * FROM Client.GetRemakeHDMByCompany2(@ClientID,@SupporterID)"
                End If
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CallCenterRemakeInfo
    Friend Function CallCenterRemakeInfo(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.CallCenterRemakeInfo @ClientID"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'HTSChangeByClient
    Friend Function HTSChangeByClient(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC hts.HTSChangeByClient @ClientID"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetReplacedEcr
    Friend Function GetReplacedEcr(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "EXEC Client.GetReplacedEcr @ClientID"
                Else
                    cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.CommandText = "EXEC Client.GetReplacedEcr @ClientID,@SupporterID"
                End If
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPaymentsByHvhh
    Friend Function GetPaymentsByHvhh(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT PaymentID,Վճար,ՎճարմանԱմսաթիվ,ՎճարմանՁև,Հաստատված,PayType,Մուտք FROM Payment.GetPaymentsByHvhh(@hvhh)"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPaymentsByPassport
    Friend Function GetPaymentsByPassport(ByVal passport As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT PaymentID,Վճար,ՎճարմանԱմսաթիվ,ՎճարմանՁև,Հաստատված,PayType,Մուտք FROM Payment.GetPaymentsByPassport(@passport)"
                cmd.Parameters.Add("@passport", SqlDbType.VarChar).Value = passport
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPaymentInfoBy
    Friend Function GetPaymentInfoByHvhh(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Սպասարկող,Կազմակերպություն,ՀծԿող FROM Payment.GetPaymentInfoByHvhh(@hvhh)"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPaymentInfoByPassport
    Friend Function GetPaymentInfoByPassport(ByVal passport As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Սպասարկող,Կազմակերպություն,ՀծԿող FROM Payment.GetPaymentInfoByPassport(@passport)"
                cmd.Parameters.Add("@passport", SqlDbType.VarChar).Value = passport
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetStatus
    Friend Function GetStatus() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT statusID,Կարգավիճակ FROM Client.GetStatus()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'ClientHdmCount
    Friend Function ClientHdmCount(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ID,Տարի,Ամիս,ՀդմՔանակ,ՀավելվածՔանակ FROM Client.ClientHdmCount(@ClientID)"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'OnlyContractsChanges
    Friend Function OnlyContractsChanges(ByVal Y As Short, ByVal M As Byte, ByVal dbID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 50
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.OnlyContractsChanges @Y,@M,@dbID"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = dbID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GETContractsX
    Friend Function GETContractsX(ByVal Y As Short, ByVal M As Byte, ByVal dbID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 500
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GETContracts @Y,@M,@dbID"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = dbID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAddressDirectorForContractExport
    Friend Function GetAddressDirectorForContractExport(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Հասցե,Տնօրեն FROM Client.GetAddressDirectorForContractExport(@hvhh)"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporterContractExport
    Friend Function GetSupporterContractExport(ByVal Supporter As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetSupporterContractExport(@Supporter)"
                cmd.Parameters.Add("@Supporter", SqlDbType.NVarChar).Value = Supporter
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ChangeHavelvacCountAfterPrint
    Friend Function ChangeHavelvacCountAfterPrint(ByVal userHVHH As String, ByVal userCompany As String, ByVal OwnerCompany As String, ByVal userTesuch As String, ByVal cYear As Short,
                      ByVal cMonth As Byte, ByVal hdmCount As Short, ByVal userChangedCount As Short, ByVal userName As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.ChangeHavelvacCountAfterPrint @HVHH,@Comp,@Owner,@Tesuch,@Y,@M,@HCount,@HavCount,@UserName"
                cmd.Parameters.Add("@HVHH", Data.SqlDbType.VarChar).Value = userHVHH
                cmd.Parameters.Add("@Comp", Data.SqlDbType.NVarChar).Value = userCompany
                cmd.Parameters.Add("@Owner", Data.SqlDbType.NVarChar).Value = OwnerCompany
                cmd.Parameters.Add("@Tesuch", Data.SqlDbType.NVarChar).Value = userTesuch
                cmd.Parameters.Add("@Y", Data.SqlDbType.SmallInt).Value = cYear
                cmd.Parameters.Add("@M", Data.SqlDbType.TinyInt).Value = cMonth
                cmd.Parameters.Add("@HCount", Data.SqlDbType.SmallInt).Value = hdmCount
                cmd.Parameters.Add("@HavCount", Data.SqlDbType.SmallInt).Value = userChangedCount
                cmd.Parameters.Add("@UserName", Data.SqlDbType.NVarChar).Value = userName
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetUserInfoForContractExpireing
    Friend Function GetUserInfoForContractExpireing(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetUserInfoForContractExpireing(@hvhh)"
                cmd.Parameters.Add("@hvhh", SqlDbType.NVarChar).Value = hvhh
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'PrintedContractApplicationList
    Friend Function PrintedContractApplicationList(ByVal d1 As Date, ByVal d2 As Date, ByVal dbID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If dbID = 5 Then
                    cmd.CommandText = "SELECT * FROM Client.PrintedContractApplicationList(@D1,@D2)"
                Else
                    cmd.CommandText = "SELECT * FROM Client.PrintedContractApplicationListDB(@D1,@D2,@dbID)"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = dbID
                End If
                cmd.Parameters.Add("@D1", SqlDbType.Date).Value = d1
                cmd.Parameters.Add("@D2", SqlDbType.Date).Value = d2
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'PrintedContractApplicationAllList
    Friend Function PrintedContractApplicationAllList(ByVal dbID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If dbID = 5 Then
                    cmd.CommandText = "SELECT * FROM Client.PrintedContractApplicationAllList()"
                Else
                    cmd.CommandText = "SELECT * FROM Client.PrintedContractApplicationAllListDB(@dbID)"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = dbID
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeHistoryByHDM
    Friend Function GetRemakeHistoryByHDM(ByVal EcrID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT * FROM Client.GetRemakeHistoryByHDM(@EcrID)"
                Else
                    cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.CommandText = "SELECT * FROM Client.GetRemakeHistoryByHDM2(@EcrID,@SupporterID)"
                End If
                cmd.Parameters.Add("@EcrID", SqlDbType.Int).Value = EcrID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPaymentByClient
    Friend Function GetPaymentByClient(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.GetPaymentByClient(@ClientID)"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPaymentByClientSubTotal
    Friend Function GetPaymentByClientSubTotal(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.GetPaymentByClientSubTotal(@ClientID)"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'PartqBySupporter2
    Friend Function PartqBySupporter2(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.PartqBySupporter2 @ClientID"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'PartqBySupporter2ForSMS
    Friend Function PartqBySupporter2ForSMS(ByVal ClientHVHH As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.PartqBySupporter2ForSMS @ClientHVHH"
                cmd.Parameters.Add("@ClientHVHH", SqlDbType.NVarChar).Value = ClientHVHH
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'PartqBySupporter4
    Friend Function PartqBySupporter4(ByVal hvhh As String, ByVal SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.PartqBySupporter4 @hvhh,@SupporterID"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetDisabledMailingInfo
    Friend Function GetDisabledMailingInfo(ByVal TempEcr As DataTable) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Mailing.GetDisabledMailingInfo"
                cmd.Parameters.Add("@TempEcr", SqlDbType.Structured).Value = TempEcr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetDisabledMailingInfo2
    Friend Function GetDisabledMailingInfo2(ByVal TempEcr As DataTable) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Mailing.GetDisabledMailingInfo2"
                cmd.Parameters.Add("@TempEcr", SqlDbType.Structured).Value = TempEcr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetMailingInfo
    Friend Function GetMailingInfo(ByVal TempEcr As DataTable) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Mailing.GetMailingInfo"
                cmd.Parameters.Add("@TempEcr", SqlDbType.Structured).Value = TempEcr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetMailingInfo2
    Friend Function GetMailingInfo2(ByVal TempEcr As DataTable) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Mailing.GetMailingInfo2"
                cmd.Parameters.Add("@TempEcr", SqlDbType.Structured).Value = TempEcr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetBlockedGprsForEnable
    Friend Function GetBlockedGprsForEnable() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 500
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ECR,HVHH FROM Client.GetBlockedGprsForEnable()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetMustDisableGprs
    Friend Function GetMustDisableGprs(ByVal mOperator As String) As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 500
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "EXEC Client.GetMustDisableGprs @Operator"
                    cmd.Parameters.Add("@Operator", SqlDbType.Char).Value = mOperator
                Else
                    cmd.CommandText = "EXEC Client.GetMustDisableGprsDB,@Operator @dbID"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.Parameters.Add("@Operator", SqlDbType.Char).Value = mOperator
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetMustBeDisabledEcrDetails
    Friend Function GetMustBeDisabledEcrDetails(ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 150    'Arman
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetMustBeDisabledEcrDetails @ecr"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetMustDisableGprsAll
    Friend Function GetMustDisableGprsAll() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 500
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "EXEC Client.GetMustDisableGprsALL"
                Else
                    cmd.CommandText = "EXEC Client.GetMustDisableGprsDBALL @dbID"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetListOfEnablingSIMByHVHH
    Friend Function GetListOfEnablingSIMByHVHH() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 500
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT * FROM Client.GetListOfEnablingSIMByHVHH()"
                Else
                    cmd.CommandText = "SELECT * FROM Client.GetListOfEnablingSIMByHVHH_DB(@dbID)"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPlanedMailList
    Friend Function GetPlanedMailList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Տեսուչ,Փոստ,Հաղորդագրություն,Կասեցված,Ամսաթիվ FROM Mailing.GetPlanedMailList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPlanedMailListByDate
    Friend Function GetPlanedMailListByDate(ByVal d1 As Date, ByVal d2 As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Տեսուչ,Փոստ,Հաղորդագրություն,Կասեցված,Ամսաթիվ FROM Mailing.GetPlanedMailListByDate(@D1,@D2)"
                cmd.Parameters.Add("@D1", SqlDbType.Date).Value = d1
                cmd.Parameters.Add("@D2", SqlDbType.Date).Value = d2
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSentMailList
    Friend Function GetSentMailList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Տեսուչ,Փոստ,Հաղորդագրություն,Կասեցված,Ամսաթիվ FROM Mailing.GetSentMailList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSentMailListByDate
    Friend Function GetSentMailListByDate(ByVal d1 As Date, ByVal d2 As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Տեսուչ,Փոստ,Հաղորդագրություն,Կասեցված,Ամսաթիվ FROM Mailing.GetSentMailListByDate(@D1,@D2)"
                cmd.Parameters.Add("@D1", SqlDbType.Date).Value = d1
                cmd.Parameters.Add("@D2", SqlDbType.Date).Value = d2
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ForSendMailList
    Friend Function ForSendMailList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Mailing.ForSendMailList"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RetNikitaAccount
    Friend Function RetNikitaAccount(ByVal owner As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Operator.RetNikitaAccount @O"
                cmd.Parameters.Add("@O", SqlDbType.TinyInt).Value = owner
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RetNikitaAccount without supporter
    Friend Function RetNikitaAccount() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Operator.RetNikitaAccount"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function


    'SmsToBlockedCompanies
    Friend Function SmsToBlockedCompanies(ByVal owner As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.SmsToBlockedCompanies @O"
                cmd.Parameters.Add("@O", SqlDbType.TinyInt).Value = owner
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'SmsForBlockingByInterval
    Friend Function SmsForBlockingByInterval(ByVal owner As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.SmsForBlockingByInterval @O"
                cmd.Parameters.Add("@O", SqlDbType.TinyInt).Value = owner
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'SmsForBlockingByYearAndMonth
    Friend Function SmsForBlockingByYearAndMonth(ByVal owner As Byte, ByVal Y As Short, ByVal M As Byte, ByVal SY As Short, ByVal SM As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.SmsForBlockingByYearAndMonth @O,@Y,@M,@SY,@SM"
                cmd.Parameters.Add("@O", SqlDbType.TinyInt).Value = owner
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@SY", SqlDbType.SmallInt).Value = SY
                cmd.Parameters.Add("@SM", SqlDbType.TinyInt).Value = SM
                cmd.CommandTimeout = 120
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTesuchListForSMS
    Friend Function GetTesuchListForSMS() As DataTable
        Dim dt As DataTable

        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Նշիչ,Տեսուչ,Հեռախոս FROM tesuch.GetTesuchListForSMS()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    'GetSMSClientList
    Friend Function GetSMSClientList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT ՀՎՀՀ,Կազմակերպություն,Ամսաթիվ,Պատկան FROM Client.GetSMSClientList()"
                Else
                    cmd.CommandText = "SELECT ՀՎՀՀ,Կազմակերպություն,Ամսաթիվ,Պատկան FROM Client.GetSMSClientListDB(@dbID)"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSMSClientListByDate
    Friend Function GetSMSClientListByDate(ByVal sd As Date, ByVal ed As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT ՀՎՀՀ,Կազմակերպություն,Ամսաթիվ,Պատկան FROM Client.GetSMSClientListByDate(@SD,@ED)"
                Else
                    cmd.CommandText = "SELECT ՀՎՀՀ,Կազմակերպություն,Ամսաթիվ,Պատկան FROM Client.GetSMSClientListByDateDB(@SD,@ED,@dbID)"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                End If
                cmd.Parameters.Add("@SD", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@ED", SqlDbType.Date).Value = ed
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSMSTesuch
    Friend Function GetSMSTesuch() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Տեսուչ,SMS,Ամսաթիվ,Հեռախոս FROM tesuch.GetSMSTesuch()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSMSTesuchByDate
    Friend Function GetSMSTesuchByDate(ByVal sd As Date, ByVal ed As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Տեսուչ,SMS,Ամսաթիվ,Հեռախոս FROM tesuch.GetSMSTesuchByDate(@SD,@ED)"
                cmd.Parameters.Add("@SD", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@ED", SqlDbType.Date).Value = ed
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetCustomClientForSMS
    Friend Function GetCustomClientForSMS(ByVal O As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetCustomClientForSMS @O"
                cmd.Parameters.Add("@O", SqlDbType.TinyInt).Value = O
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetCstomSMSByClient
    Friend Function GetCstomSMSByClient() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT ՀՎՀՀ,Կազմակերպություն,Ամսաթիվ,SMS,Հեռախոս FROM Client.GetCstomSMSByClient()"
                Else
                    cmd.CommandText = "SELECT ՀՎՀՀ,Կազմակերպություն,Ամսաթիվ,SMS,Հեռախոս FROM Client.GetCstomSMSByClientDB(@dbID)"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetCstomSMSByDateHVHH
    Friend Function GetCstomSMSByDateHVHH(ByVal S As Date, ByVal E As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT ՀՎՀՀ,Կազմակերպություն,Ամսաթիվ,SMS,Հեռախոս FROM Client.GetCstomSMSByDateHVHH(@S,@E)"
                Else
                    cmd.CommandText = "SELECT ՀՎՀՀ,Կազմակերպություն,Ամսաթիվ,SMS,Հեռախոս FROM Client.GetCstomSMSByDateHVHHDB(@S,@E,@dbID)"
                    cmd.Parameters.Add("@dbID", SqlDbType.TinyInt).Value = iUser.DB
                End If

                cmd.Parameters.Add("@S", SqlDbType.Date).Value = S
                cmd.Parameters.Add("@E", SqlDbType.Date).Value = E
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Select Data 2"

    'GetEquipmentList
    Friend Function GetEquipmentList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT EquipmentID ՀՀ,EquipmentName Սարքավորում, CanBeSold [Սարք/Նյութ],EquipmentCode Կոդ FROM warehouse.GetEquipmentList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEquipmentList2
    Friend Function GetEquipmentList2() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.GetEquipmentList2"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEquipmentListWithShtrikhCode
    Friend Function GetEquipmentListWithShtrikhCode() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT E.EquipmentID ՀՀ,E.EquipmentName Սարքավորում,CAST(0 AS SMALLINT) Քանակ,E.EquipmentCode Կոդ,S.Code-1 ՎերջինԿոդ FROM warehouse.GetEquipmentList() E LEFT JOIN Client.ShtrikhCode S ON S.EquipmentID=E.EquipmentID WHERE E.EquipmentCode IS NOT NULL"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEquipmentListWithoutShtrikhCode
    Friend Function GetEquipmentListWithoutShtrikhCode() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT E.EquipmentID ՀՀ,E.EquipmentName Սարքավորում FROM warehouse.GetEquipmentList() E WHERE E.EquipmentCode IS NULL"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEquipmentListFiltered
    Friend Function GetEquipmentListFiltered() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT EquipmentID ՀՀ,EquipmentName Սարքավորում, CanBeSold Վաճառվող,EquipmentCode Կոդ FROM warehouse.GetEquipmentListFiltered()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPurchaseWarehouseList
    Friend Function GetPurchaseWarehouseList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT WarehouseID,Սարքավորում,Քանակ,Գումար,Ամսաթիվ,Մեկնաբանություն,Սպասարկող,Շուկայից,ՇտրիխԿոդ FROM warehouse.GetPurchaseWarehouseList()"
                Else
                    cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.CommandText = "SELECT WarehouseID,Սարքավորում,Քանակ,Գումար,Ամսաթիվ,Մեկնաբանություն,Սպասարկող,Շուկայից,ՇտրիխԿոդ FROM warehouse.GetPurchaseWarehouseList2(@SupporterID)"
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPurchaseWarehouseListByDate
    Friend Function GetPurchaseWarehouseListByDate(ByVal s As Date, ByVal e As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT WarehouseID,Սարքավորում,Քանակ,Գումար,Ամսաթիվ,Մեկնաբանություն,Սպասարկող,Շուկայից,ՇտրիխԿոդ FROM warehouse.GetPurchaseWarehouseListByDate(@S,@E)"
                Else
                    cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.CommandText = "SELECT WarehouseID,Սարքավորում,Քանակ,Գումար,Ամսաթիվ,Մեկնաբանություն,Սպասարկող,Շուկայից,ՇտրիխԿոդ FROM warehouse.GetPurchaseWarehouseListByDate2(@S,@E,@SupporterID)"
                End If
                cmd.Parameters.Add("@S", SqlDbType.Date).Value = s
                cmd.Parameters.Add("@E", SqlDbType.Date).Value = e
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetIntermediateWarehouseList
    Friend Function GetIntermediateWarehouseList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT * FROM warehouse.GetIntermediateWarehouseList()"
                Else
                    cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.CommandText = "SELECT * FROM warehouse.GetIntermediateWarehouseList2(@SupporterID)"
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPoakWarehouse
    Friend Function GetPoakWarehouse() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT Սարքավորում,Քանակ,Ամսաթիվ,Մեկնաբանություն,Սպասարկող,Շուկա FROM warehouse.GetPoakWarehouse()"
                Else
                    cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.CommandText = "SELECT Սարքավորում,Քանակ,Ամսաթիվ,Մեկնաբանություն,Սպասարկող,Շուկա FROM warehouse.GetPoakWarehouse2(@SupporterID)"
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRejectsWarehouse
    Friend Function GetRejectsWarehouse() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If iUser.DB = 5 Then
                    cmd.CommandText = "SELECT Սարքավորում,Քանակ,Ամսաթիվ,Մեկնաբանություն,Սպասարկող,Շուկա FROM warehouse.GetRejectsWarehouse()"
                Else
                    cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = iUser.DB
                    cmd.CommandText = "SELECT Սարքավորում,Քանակ,Ամսաթիվ,Մեկնաբանություն,Սպասարկող,Շուկա FROM warehouse.GetRejectsWarehouse2(@SupporterID)"
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporter2
    Friend Function GetSupporter2(ByVal id As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.CommandText = "SELECT ՀՀ,Կազմակերպություն FROM Supporter.GetSupporter() WHERE ՀՀ=@ID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetCustomSoldEquipment
    Friend Function GetCustomSoldEquipment(ByVal sDate As Date, ByVal eDate As Date, ByVal SupporterID As Byte, ByVal EquipmentID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "EXEC warehouse.GetCustomSoldEquipment @sDate,@eDate,@SupporterID,@EquipmentID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetCustomSoldEquipment2
    Friend Function GetCustomSoldEquipment2(ByVal sDate As Date, ByVal eDate As Date, ByVal SupporterID As Byte, ByVal EquipmentID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "EXEC warehouse.GetCustomSoldEquipment2 @sDate,@eDate,@SupporterID,@EquipmentID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrInOfficeBySupporter
    Friend Function GetEcrInOfficeBySupporter(ByVal id As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.CommandText = "SELECT * FROM Supporter.GetEcrInOfficeBySupporter(@ID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrReplaceHistoryALL
    Friend Function GetEcrReplaceHistoryALL(ByVal d1 As Date, ByVal d2 As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@d1", SqlDbType.Date).Value = d1
                cmd.Parameters.Add("@d2", SqlDbType.Date).Value = d2
                cmd.CommandText = "SELECT * FROM Supporter.GetEcrReplaceHistoryALL(@d1,@d2)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrReplaceHistoryBySupporter
    Friend Function GetEcrReplaceHistoryBySupporter(ByVal d1 As Date, ByVal d2 As Date, ByVal o As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@d1", SqlDbType.Date).Value = d1
                cmd.Parameters.Add("@d2", SqlDbType.Date).Value = d2
                cmd.Parameters.Add("@o", SqlDbType.TinyInt).Value = o
                cmd.CommandText = "SELECT * FROM Supporter.GetEcrReplaceHistoryBySupporter(@d1,@d2,@o)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrReplaceHistoryALLBacvacq
    Friend Function GetEcrReplaceHistoryALLBacvacq(ByVal d1 As Date, ByVal d2 As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@d1", SqlDbType.Date).Value = d1
                cmd.Parameters.Add("@d2", SqlDbType.Date).Value = d2
                cmd.CommandText = "SELECT * FROM Supporter.GetEcrReplaceHistoryALLBacvacq(@d1,@d2)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrReplaceHistoryBySupporterBacvacq
    Friend Function GetEcrReplaceHistoryBySupporterBacvacq(ByVal d1 As Date, ByVal d2 As Date, ByVal o As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@d1", SqlDbType.Date).Value = d1
                cmd.Parameters.Add("@d2", SqlDbType.Date).Value = d2
                cmd.Parameters.Add("@o", SqlDbType.TinyInt).Value = o
                cmd.CommandText = "SELECT * FROM Supporter.GetEcrReplaceHistoryBySupporterBacvacq(@d1,@d2,@o)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporterRegionEcrCountBySupp
    Friend Function GetSupporterRegionEcrCountBySupp(ByVal id As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.CommandText = "SELECT * FROM Supporter.GetSupporterRegionEcrCountBySupp(@ID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepGetAllPayments
    Friend Function RepGetAllPayments(ByVal id As Byte, ByVal paytype As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.Parameters.Add("@paytype", SqlDbType.TinyInt).Value = paytype
                cmd.CommandText = "EXEC Payment.RepGetAllPayments @ID,@paytype"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepGetAllPaymentsByInterval
    Friend Function RepGetAllPaymentsByInterval(ByVal id As Byte, ByVal d1 As Date, ByVal d2 As Date, ByVal paytype As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.Parameters.Add("@d1", SqlDbType.Date).Value = d1
                cmd.Parameters.Add("@d2", SqlDbType.Date).Value = d2
                cmd.Parameters.Add("@paytype", SqlDbType.TinyInt).Value = paytype
                cmd.CommandText = "EXEC Payment.RepGetAllPaymentsByInterval @ID,@d1,@d2,@paytype"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepGetAllPaymentsGrouped
    Friend Function RepGetAllPaymentsGrouped(ByVal id As Byte, ByVal paytype As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.Parameters.Add("@paytype", SqlDbType.TinyInt).Value = paytype
                cmd.CommandText = "EXEC Payment.RepGetAllPaymentsGrouped @ID,@paytype"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepGetAllPaymentsByIntervalGrouped
    Friend Function RepGetAllPaymentsByIntervalGrouped(ByVal id As Byte, ByVal d1 As Date, ByVal d2 As Date, ByVal paytype As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.Parameters.Add("@d1", SqlDbType.Date).Value = d1
                cmd.Parameters.Add("@d2", SqlDbType.Date).Value = d2
                cmd.Parameters.Add("@paytype", SqlDbType.TinyInt).Value = paytype
                cmd.CommandText = "EXEC Payment.RepGetAllPaymentsByIntervalGrouped @ID,@d1,@d2,@paytype"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPartqList
    Friend Function GetPartqList(ByVal id As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.CommandText = "EXEC Client.GetPartqList @ID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPartqListFiz
    Friend Function GetPartqListFiz() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetPartqListFiz"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetZroList
    Friend Function GetZroList(ByVal id As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.CommandText = "EXEC Client.GetZroList @ID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetMetsZroList
    Friend Function GetMetsZroList(ByVal id As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.CommandText = "EXEC Client.GetMetsZroList @ID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPartHavelavcharAll
    Friend Function GetPartHavelavcharAll(ByVal id As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id
                cmd.CommandText = "EXEC Client.GetPartHavelavcharAll @ID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeAll
    Friend Function GetRemakeAll(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "EXEC Client.GetRemakeAll @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRepMoreRemake
    Friend Function GetRepMoreRemake(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Client.GetRepMoreRemake(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeAllBySupporter
    Friend Function GetRemakeAllBySupporter(ByVal Supporter As Byte, sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "EXEC Client.GetRemakeAllBySupporter @Supporter,@sDate,@eDate"
                cmd.Parameters.Add("@Supporter", SqlDbType.TinyInt).Value = Supporter
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAllReplacedEcr
    Friend Function GetAllReplacedEcr(ByVal sd As Date, ByVal ed As Date, ByVal Supporter As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetAllReplacedEcr @sd,@ed,@Supporter"
                cmd.Parameters.Add("@Supporter", SqlDbType.TinyInt).Value = Supporter
                cmd.Parameters.Add("@sd", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@ed", SqlDbType.Date).Value = ed
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Select Data 3"

    'GetDebetCreted
    Friend Function GetDebetCreted(ByVal y As Short, ByVal m As Byte, ByVal Supporter As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.GetDebetCreted @Y,@M,@SupporterID"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = Supporter
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'NotPrintedApplications
    Friend Function NotPrintedApplications(ByVal y As Short, ByVal m As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.NotPrintedApplications(@Y,@M)"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'NotReturnedInvoice
    Friend Function NotReturnedInvoice(ByVal y As Short, ByVal m As Byte, ByVal Supporter As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.NotReturnedInvoice @Y,@M,@SupporterID"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = Supporter
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'NotReturnedInvoiceAll
    Friend Function NotReturnedInvoiceAll(ByVal Supporter As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.NotReturnedInvoiceAll @SupporterID"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = Supporter
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetServiceInvoiceAll
    Friend Function GetServiceInvoiceAll(ByVal s As Byte, ByVal y As Short, ByVal m As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.GetServiceInvoiceAll @s,@y,@m"
                cmd.Parameters.Add("@s", SqlDbType.TinyInt).Value = s
                cmd.Parameters.Add("@y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@m", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetServiceInvoiceByRegion
    Friend Function GetServiceInvoiceByRegion(ByVal s As Byte, ByVal y As Short, ByVal m As Byte, ByVal r As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.GetServiceInvoiceByRegion @s,@y,@m,@r"
                cmd.Parameters.Add("@s", SqlDbType.TinyInt).Value = s
                cmd.Parameters.Add("@y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@m", SqlDbType.TinyInt).Value = m
                cmd.Parameters.Add("@r", SqlDbType.SmallInt).Value = r
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeInvoice
    Friend Function GetRemakeInvoice(ByVal s As Byte, ByVal y As Short, ByVal m As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.GetRemakeInvoice @s,@y,@m"
                cmd.Parameters.Add("@s", SqlDbType.TinyInt).Value = s
                cmd.Parameters.Add("@y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@m", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSoldInvoice
    Friend Function GetSoldInvoice(ByVal s As Byte, ByVal y As Short, ByVal m As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.GetSoldInvoice @s,@y,@m"
                cmd.Parameters.Add("@s", SqlDbType.TinyInt).Value = s
                cmd.Parameters.Add("@y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@m", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetShrjikInvoice
    Friend Function GetShrjikInvoice(ByVal s As Byte, ByVal y As Short, ByVal m As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.GetShrjikInvoice @s,@y,@m"
                cmd.Parameters.Add("@s", SqlDbType.TinyInt).Value = s
                cmd.Parameters.Add("@y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@m", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAllInvoice
    Friend Function GetAllInvoice(ByVal s As Byte, ByVal sDate As Date, ByVal eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.GetAllInvoice @s,@sDate,@eDate"
                cmd.Parameters.Add("@s", SqlDbType.TinyInt).Value = s
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

    'BankInfoWorker
    Friend Function BankInfoWorker(ByVal T As DataTable, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 300
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Client.BankInfoWorker"
                cmd.Parameters.Add("@T", SqlDbType.Structured).Value = T
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'LoadTesuchVisitList
    Friend Function LoadTesuchVisitList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Tesuch.LoadTesuchVisitList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ShuldPrintReRegInvoice
    Friend Function ShuldPrintReRegInvoice(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.ShuldPrintReRegInvoice @hvhh"
                cmd.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetReRegInvoice
    Friend Function GetReRegInvoice() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.GetReRegInvoice()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetReRegisteredEcr
    Friend Function GetReRegisteredEcr() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetReRegisteredEcr()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'TesuchVisitsInYerevan
    Friend Function TesuchVisitsInYerevan(ByVal y As Short, ByVal m As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Tesuch.TesuchVisitsInYerevan @Y,@M"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'TesuchVisitsInRegions
    Friend Function TesuchVisitsInRegions(ByVal y As Short, ByVal m As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Tesuch.TesuchVisitsInRegions @Y,@M"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'DoubleVisit
    Friend Function DoubleVisit(ByVal y As Short, ByVal m As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Tesuch.DoubleVisit @Y,@M"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAllTesuchVisits
    Friend Function GetAllTesuchVisits() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Tesuch.GetAllTesuchVisits()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'NotServedEcrList
    Friend Function NotServedEcrList(ByVal y As Short, ByVal m As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Tesuch.NotServedEcrList(@Y,@M)"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = m
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'PartqVeragrancumov
    Friend Function PartqVeragrancumov() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 120
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.PartqVeragrancumov"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetVtoQ
    Friend Function GetVtoQ(ByVal ID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Client.GetVtoQ"
                cmd.Parameters.Add("@DB_ID", SqlDbType.TinyInt).Value = ID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPremiumClientsHvhh
    Friend Function GetPremiumClientsHvhh() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT HVHH FROM Client.GetPremiumClientsHvhh()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetVarvacGPRS
    Friend Function GetVarvacGPRS() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT gp FROM Client.GetVarvacGPRS()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ListOfPremiums
    Friend Function ListOfPremiums() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.ListOfPremiums() ORDER BY Տարիֆ, ՀդմՔանակ, Հուսալիություն"
                cmd.CommandTimeout = 0
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ListOfPremiums2
    Friend Function ListOfPremiums2(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT * FROM Client.ListOfPremiums2(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetExcludedHVHH
    Friend Function GetExcludedHVHH() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetExcludedHVHH()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'IsEcrExists
    Friend Function IsEcrExists(ByVal ecr As String, ByVal db_id As Byte) As Boolean
        Dim isExists As Boolean
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsEcrExists(@ecr,@db_id)"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                cmd.Parameters.Add("@db_id", SqlDbType.TinyInt).Value = db_id
                isExists = cmd.ExecuteScalar()
            End Using
        End Using
        Return isExists
    End Function

    'EcrStatusForRemake
    Friend Function EcrStatusForRemake(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Client.EcrStatusForRemake"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'IsHvhhChanged
    Friend Function IsHvhhChanged(ByVal ecr As String) As Boolean
        Dim isExists As Boolean
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsHvhhChanged(@ecr)"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                isExists = cmd.ExecuteScalar()
            End Using
        End Using
        Return isExists
    End Function

    'LoadProblemList
    Friend Function LoadProblemList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.LoadProblemList() ORDER BY Problem"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeListByEcr
    Friend Function GetRemakeListByEcr(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetRemakeListByEcr(@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'EquipmentListForRemake
    Friend Function EquipmentListForRemake(ByVal r As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.EquipmentListForRemake @R"
                cmd.Parameters.Add("@R", SqlDbType.Int).Value = r
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetReplacedECRByRemake
    Friend Function GetReplacedECRByRemake(ByVal ECR As String) As String
        Dim s As Object
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.GetReplacedECRByRemake(@ECR) R"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ECR
                s = cmd.ExecuteScalar()
            End Using
        End Using
        If IsDBNull(s) Then s = ""
        Return s
    End Function

    'CheckClicker
    Friend Function CheckClicker(ByVal RemakeID As Integer) As Boolean
        Dim s As Object
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.CheckClicker(@RemakeID) R"
                cmd.Parameters.Add("@RemakeID", SqlDbType.VarChar).Value = RemakeID
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'CheckHvhh
    Friend Function CheckHvhh(ByVal HVHH As String) As Boolean
        Dim s As Object
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.CheckHvhh(@HVHH)"
                cmd.Parameters.Add("@HVHH", SqlDbType.VarChar).Value = HVHH
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GetIUNetList
    Friend Function GetIUNetList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetIUNetList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetGarantForRemakeEcr
    Friend Function GetGarantForRemakeEcr(ByVal ECR As String) As String
        Dim s As Object
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.GetGarantForRemakeEcr(@ECR) R"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ECR
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'DetectOpenRemake
    Friend Function DetectOpenRemake(ByVal ecr As String) As Boolean
        Dim isExists As Boolean
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.DetectOpenRemake(@ecr)"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                isExists = cmd.ExecuteScalar()
            End Using
        End Using
        Return isExists
    End Function

    'DetectOpenRemake2
    Friend Function DetectOpenRemake2(ByVal RemakeID As Integer) As Boolean
        Dim isExists As Boolean
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.DetectOpenRemake2(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                isExists = cmd.ExecuteScalar()
            End Using
        End Using
        Return isExists
    End Function

    'DetectOpenRemake3
    Friend Function DetectOpenRemake3(ByVal ecr As String) As Boolean
        Dim isExists As Boolean
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.DetectOpenRemake3(@ecr)"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                isExists = cmd.ExecuteScalar()
            End Using
        End Using
        Return isExists
    End Function

    'CheckReRegisterStatusForRemake
    Friend Function CheckReRegisterStatusForRemake(ByVal ecr As String) As Boolean
        Dim isExists As Boolean
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.CheckReRegisterStatusForRemake(@ecr)"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                isExists = cmd.ExecuteScalar()
            End Using
        End Using
        Return isExists
    End Function

    'GetOpenAktInfo
    Friend Function GetOpenAktInfo(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetOpenAktInfo(@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RemakeNotServed
    Friend Function RemakeNotServed(ByVal ECR As String) As String
        Dim s As Object
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.RemakeNotServed(@ECR) R"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ECR
                s = cmd.ExecuteScalar()
            End Using
        End Using
        If IsDBNull(s) Then s = ""
        Return s
    End Function

    'IsRemakeOpenByEcr
    Friend Function IsRemakeOpenByEcr(ByVal ecr As String) As Boolean
        Dim isExists As Boolean
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsRemakeOpenByEcr(@ecr)"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                isExists = cmd.ExecuteScalar()
            End Using
        End Using
        Return isExists
    End Function

    'GETWorkshopEquipment
    Friend Function GETWorkshopEquipment(ByVal RemakeID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GETWorkshopEquipment(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepTesuchEcr
    Friend Function RepTesuchEcr() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM tesuch.RepTesuchEcr()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Select Data 4"

    'GetWorkshopEcrByBranch
    Friend Function GetWorkshopEcrByBranch(ByVal ecr As String, ByVal Supporter As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.GetWorkshopEcrByBranch @ECR,@DB_ID"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ecr
                cmd.Parameters.Add("DB_ID", SqlDbType.TinyInt).Value = Supporter
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetWorkshopEcrByCenter
    Friend Function GetWorkshopEcrByCenter(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.GetWorkshopEcrByCenter @ECR"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ReturnWorkshopEcrByBranch
    Friend Function ReturnWorkshopEcrByBranch(ByVal ecr As String, ByVal Supporter As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.ReturnWorkshopEcrByBranch @ECR,@DB_ID"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ecr
                cmd.Parameters.Add("DB_ID", SqlDbType.TinyInt).Value = Supporter
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ReturnWorkshopEcrByCenter
    Friend Function ReturnWorkshopEcrByCenter(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.ReturnWorkshopEcrByCenter @ECR"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEquipmentRemakeWorkshop
    Friend Function GetEquipmentRemakeWorkshop(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.GetEquipmentRemakeWorkshop @ECR"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetReplaceEcrInfo
    Friend Function GetReplaceEcrInfo(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetReplaceEcrInfo(@ECR)"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrExistingForReplace2
    Friend Function GetEcrExistingForReplace2(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetEcrExistingForReplace2(@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ReplEcrByID
    Friend Function ReplEcrByID(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.ReplEcrByID @rHDM"
                cmd.Parameters.Add("@rHDM", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEquipmentForRemakeAdd
    Friend Function GetEquipmentForRemakeAdd(ByVal TarifID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.GetEquipmentForRemakeAdd @TarifID"
                cmd.Parameters.Add("@TarifID", SqlDbType.SmallInt).Value = TarifID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporterID
    Friend Function GetSupporterID(ByVal RemakeID As Integer) As Byte
        Dim bt As Byte
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.GetSupporterID(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                bt = cmd.ExecuteScalar()
            End Using
        End Using
        Return bt
    End Function

    'GetPriseAndCount
    Friend Function GetPriseAndCount(ByVal EquipmentID As Short, ByVal SupporterID As Byte, ByVal TarifID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.GetPriseAndCount @EquipmentID,@SupporterID,@TarifID"
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@TarifID", SqlDbType.SmallInt).Value = TarifID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSoldEquipmentByRemake
    Friend Function GetSoldEquipmentByRemake(ByVal RemakeID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GetSoldEquipmentByRemake(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTarifList
    Friend Function GetTarifList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.GetTarifList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTarifSelList
    Friend Function GetTarifSelList(ByVal tarifID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GetTarifSelList(@tarifID)"
                cmd.Parameters.Add("@tarifID", SqlDbType.SmallInt).Value = tarifID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTarifID
    Friend Function GetTarifID(ByVal ECR As String) As Short
        Dim tID As Short
        Using connection As New SqlConnection(SQLString)
            Using cmd As New SqlCommand("SELECT Client.GetTarifID(@ECR)", connection)
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ECR
                connection.Open()
                tID = cmd.ExecuteScalar()
                connection.Close()
            End Using
        End Using
        Return tID
    End Function

    'ISvTOq
    Friend Function ISvTOq(ByVal EcrID As Integer) As Boolean
        Dim R As Boolean
        Using connection As New SqlConnection(SQLString)
            Using cmd As New SqlCommand("SELECT Client.ISvTOq(@EcrID)", connection)
                cmd.Parameters.Add("@EcrID", SqlDbType.Int).Value = EcrID
                connection.Open()
                R = cmd.ExecuteScalar()
                connection.Close()
            End Using
        End Using
        Return R
    End Function

    'CheckRemakeToMakeInvoice
    Friend Function CheckRemakeToMakeInvoice(ByVal RemakeID As Integer) As Boolean
        Dim R As Boolean
        Using connection As New SqlConnection(SQLString)
            Using cmd As New SqlCommand("EXEC Payment.CheckRemakeToMakeInvoice @RemakeID", connection)
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
            End Using
        End Using
        Return R
    End Function

    'MustPrintInvoice
    Friend Function MustPrintInvoice(ByVal RemakeID As Integer) As Boolean
        Dim R As Boolean
        Using connection As New SqlConnection(SQLString)
            Using cmd As New SqlCommand("SELECT warehouse.MustPrintInvoice(@RemakeID)", connection)
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                connection.Open()
                R = cmd.ExecuteScalar()
                connection.Close()
            End Using
        End Using
        Return R
    End Function

    'IsClientWithNDS
    Friend Function IsClientWithNDS(ByVal ClientID As Integer) As Boolean
        Dim R As Boolean
        Using connection As New SqlConnection(SQLString)
            Using cmd As New SqlCommand("SELECT Client.IsClientWithNDS(@ClientID)", connection)
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                connection.Open()
                R = cmd.ExecuteScalar()
                connection.Close()
            End Using
        End Using
        Return R
    End Function

    'IsClientWithZeroNDS
    Friend Function IsClientWithZeroNDS(ByVal ClientID As Integer) As Boolean
        Dim R As Boolean
        Using connection As New SqlConnection(SQLString)
            Using cmd As New SqlCommand("SELECT Client.IsClientWithZeroNDS(@ClientID)", connection)
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                connection.Open()
                R = cmd.ExecuteScalar()
                connection.Close()
            End Using
        End Using
        Return R
    End Function

    'GetSupporterForRemakeInvoice
    Friend Function GetSupporterForRemakeInvoice(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Supporter.GetSupporterForRemakeInvoice(@ClientID)"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetClientForRemakeInvoice
    Friend Function GetClientForRemakeInvoice(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetClientForRemakeInvoice(@ClientID)"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInvoiceNumberForRemake
    Friend Function GetInvoiceNumberForRemake(ByVal RemakeID As Integer) As String
        Dim R As String
        Using connection As New SqlConnection(SQLString)
            Using cmd As New SqlCommand("SELECT Payment.GetInvoiceNumberForRemake(@RemakeID)", connection)
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                connection.Open()
                R = cmd.ExecuteScalar()
                connection.Close()
            End Using
        End Using
        Return R
    End Function

    'AktInfoForRemakeClose
    Friend Function AktInfoForRemakeClose(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.AktInfoForRemakeClose(@ecr)"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CheckForOpenAktForRemake
    Friend Function CheckForOpenAktForRemake(ByVal RemakeID As Integer) As Boolean
        Dim R As Boolean
        Using connection As New SqlConnection(SQLString)
            Using cmd As New SqlCommand("SELECT Client.CheckForOpenAktForRemake(@RemakeID)", connection)
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                connection.Open()
                R = cmd.ExecuteScalar()
                connection.Close()
            End Using
        End Using
        Return R
    End Function

    'GetEquipmentForZeroAkt
    Friend Function GetEquipmentForZeroAkt(ByVal RemakeID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GetEquipmentForZeroAkt(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'Arman | Hovo 06.08.2017
    'GetEquipmentForAnvjarAkt
    Friend Function GetEquipmentForAnvjarAkt(ByVal RemakeID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GetEquipmentForAnvjarAkt(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Select Data 5"

    'GetSupporterForZeroAkt
    Friend Function GetSupporterForZeroAkt(ByVal RemakeID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Supporter.GetSupporterForZeroAkt(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetClientForZeroAkt
    Friend Function GetClientForZeroAkt(ByVal RemakeID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetClientForZeroAkt(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAktRemakeZeroCloseNumber
    Friend Function GetAktRemakeZeroCloseNumber(ByVal SupporterID As Byte, ByVal RemakeID As Integer) As Integer
        Dim bt As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetAktRemakeZeroCloseNumber @SupporterID,@RemakeID"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                bt = cmd.ExecuteScalar()
            End Using
        End Using
        Return bt
    End Function

    'GetClientInfoForRefuseAkt
    Friend Function GetClientInfoForRefuseAkt(ByVal ECR As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetClientInfoForRefuseAkt(@ECR)"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ECR
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetOpenRemakeInfoForRefuse
    Friend Sub GetOpenRemakeInfoForRefuse(ByVal RemakeID As Integer)
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetOpenRemakeInfoForRefuse @RemakeID"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'AktForInvoiceItems
    Friend Function AktForInvoiceItems(ByVal RemakeID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.AktForInvoiceItems @RemakeID"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'IsClientHvhhExists
    Friend Function IsClientHvhhExists(ByVal hvhh As String) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsClientHvhhExists(@hvhh)"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'IsEcrSent
    Friend Function IsEcrSent(ByVal hvhh As String) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsEcrSent(@hvhh)"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function


    'IsClientFizExists
    Friend Function IsClientFizExists(ByVal seria As String) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsClientFizExists(@seria)"
                cmd.Parameters.Add("@seria", SqlDbType.VarChar).Value = seria
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'GetContractDissolve
    Friend Function GetContractDissolve(ByVal sDate As Date, ByVal eDate As Date, ByVal IsAll As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If IsAll = True Then
                    cmd.CommandText = "EXEC Client.GetContractDissolve NULL,NULL"
                Else
                    cmd.CommandText = "EXEC Client.GetContractDissolve @sDate,@eDate"
                    cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                    cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                End If
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetContractTarifChanged
    Friend Function GetContractTarifChanged(ByVal sDate As Date, ByVal eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Client.GetContractTarifChanged(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTesuchRegion
    Friend Function GetTesuchRegion(ByVal tesuchID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM tesuch.GetTesuchRegion(@tesuchID)"
                cmd.Parameters.Add("@tesuchID", SqlDbType.SmallInt).Value = tesuchID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetHTSByInterval
    Friend Function GetHTSByInterval(ByVal s As Integer, ByVal e As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@start", SqlDbType.Int).Value = s
                cmd.Parameters.Add("@end", SqlDbType.Int).Value = e
                cmd.CommandText = "EXEC hts.GetHTSByInterval @start,@end"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetHTSByInterval2
    Friend Function GetHTSByInterval2(ByVal s As Integer, ByVal e As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@start", SqlDbType.Int).Value = s
                cmd.Parameters.Add("@end", SqlDbType.Int).Value = e
                cmd.CommandText = "EXEC hts.GetHTSByInterval2 @start,@end"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'IsClientSuported
    Friend Function IsClientSuported(ByVal hvhh As String) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsClientSuported(@HVHH)"
                cmd.Parameters.Add("@HVHH", SqlDbType.VarChar).Value = hvhh
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'IsClientNotSuported
    Friend Function IsClientNotSuported(ByVal hvhh As String) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsClientNotSuported(@HVHH)"
                cmd.Parameters.Add("@HVHH", SqlDbType.VarChar).Value = hvhh
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'IsHamadzaynagirPrinted
    Friend Function IsHamadzaynagirPrinted(ByVal hvhh As String) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsHamadzaynagirPrinted(@HVHH)"
                cmd.Parameters.Add("@HVHH", SqlDbType.VarChar).Value = hvhh
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'GetClientSupporter
    Friend Function GetClientSupporter(ByVal hvhh As String) As Byte
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.GetClientSupporter(@HVHH)"
                cmd.Parameters.Add("@HVHH", SqlDbType.VarChar).Value = hvhh
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'GetSupporterByEcr
    Friend Function GetSupporterByEcr(ByVal ecr As String) As Byte
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.GetSupporterByEcr(@ecr)"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'GetLocalCompany
    Friend Function GetLocalCompany(ByVal supporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = supporterID
                cmd.CommandText = "SELECT * FROM Supporter.GetLocalCompany(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetClientInfoForSell
    Friend Function GetClientInfoForSell(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@HVHH", SqlDbType.VarChar).Value = hvhh
                cmd.CommandText = "SELECT * FROM Supporter.GetClientInfoForSell(@HVHH)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetClientInfoForSellFiz
    Friend Function GetClientInfoForSellFiz(ByVal Passport As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Passport", SqlDbType.VarChar).Value = Passport
                cmd.CommandText = "SELECT * FROM Supporter.GetClientInfoForSellFiz(@Passport)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEquipmentForCustomSell
    Friend Function GetEquipmentForCustomSell() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GetEquipmentForCustomSell()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetCustomSellByClient
    Friend Function GetCustomSellByClient(ByVal sellID As Int32) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@CustomSellHeaderID", SqlDbType.Int).Value = sellID
                cmd.CommandText = "SELECT * FROM warehouse.GetCustomSellByClient(@CustomSellHeaderID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetCustomSellByClientFiz
    Friend Function GetCustomSellByClientFiz(ByVal sellID As Int32) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@CustomSellHeaderID", SqlDbType.Int).Value = sellID
                cmd.CommandText = "SELECT * FROM warehouse.GetCustomSellByClientFiz(@CustomSellHeaderID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ClientHVHHToClientID
    Friend Function ClientHVHHToClientID(ByVal hvhh As String) As Integer
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.ClientHVHHToClientID(@hvhh)"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'GetEquipmentCode
    Friend Function GetEquipmentCode() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Warehouse.GetEquipmentCode()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporterToSupporterInfo
    Friend Function GetSupporterToSupporterInfo(ByVal ShtrikhCode As String, ByVal SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT * FROM warehouse.GetSupporterToSupporterInfo(@ShtrikhCode,@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporterToClientInfo
    Friend Function GetSupporterToClientInfo(ByVal ShtrikhCode As String, ByVal SupporterID As Byte, isRemote As Boolean, ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@isRemote", SqlDbType.Bit).Value = isRemote
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                cmd.CommandText = "EXEC warehouse.GetSupporterToClientInfo @ShtrikhCode,@SupporterID,@isRemote,@ClientID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CustomSellForSupporter
    Friend Function CustomSellForSupporter(ByVal ShtrikhCode As String, ByVal SupporterID As Byte, ByVal SELLID As Integer, ByVal ClientID As Byte, ByVal EquipmentID As Short, ByVal Price As Decimal) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@SELLID", SqlDbType.Int).Value = SELLID
                cmd.Parameters.Add("@ClientID", SqlDbType.TinyInt).Value = ClientID
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price
                cmd.CommandText = "EXEC warehouse.CustomSellForSupporter @ShtrikhCode,@SupporterID,@SELLID,@ClientID,@EquipmentID,@Price"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CustomSellForSupporterNoNDS
    Friend Function CustomSellForSupporterNoNDS(ByVal ShtrikhCode As String, ByVal SupporterID As Byte, ByVal SELLID As Integer, ByVal ClientID As Byte, ByVal EquipmentID As Short, ByVal Price As Decimal) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@SELLID", SqlDbType.Int).Value = SELLID
                cmd.Parameters.Add("@ClientID", SqlDbType.TinyInt).Value = ClientID
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price
                cmd.CommandText = "EXEC warehouse.CustomSellForSupporterNoNDS @ShtrikhCode,@SupporterID,@SELLID,@ClientID,@EquipmentID,@Price"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RollbackCustomSellForSupporter
    Friend Function RollbackCustomSellForSupporter(ByVal ShtrikhCode As String, ByVal SupporterID As Integer, ByVal ClientID As Integer, ByVal isLocal As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID

                If isLocal = True Then
                    cmd.Parameters.Add("@ClientID", SqlDbType.TinyInt).Value = ClientID
                Else
                    cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                End If

                If isLocal = True Then
                    cmd.CommandText = "EXEC warehouse.RollbackCustomSellForSupporter @ShtrikhCode,@SupporterID,@ClientID"
                Else
                    cmd.CommandText = "EXEC warehouse.RollbackCustomSellForClient @ShtrikhCode,@SupporterID,@ClientID"
                End If

                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RollbackCustomSellForSupporterFiz
    Friend Function RollbackCustomSellForSupporterFiz(ByVal ShtrikhCode As String, ByVal SupporterID As Integer, ByVal ClientID As Integer, ByVal isLocal As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID

                If isLocal = True Then
                    cmd.Parameters.Add("@ClientID", SqlDbType.TinyInt).Value = ClientID
                Else
                    cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                End If

                If isLocal = True Then
                    cmd.CommandText = "EXEC warehouse.RollbackCustomSellForSupporter @ShtrikhCode,@SupporterID,@ClientID"
                Else
                    cmd.CommandText = "EXEC warehouse.RollbackCustomSellForClientFiz @ShtrikhCode,@SupporterID,@ClientID"
                End If

                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RollbackCustomSellForSupporterNoNDS
    Friend Function RollbackCustomSellForSupporterNoNDS(ByVal ShtrikhCode As String, ByVal SupporterID As Integer, ByVal ClientID As Integer, ByVal isLocal As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID

                If isLocal = True Then
                    cmd.Parameters.Add("@ClientID", SqlDbType.TinyInt).Value = ClientID
                Else
                    cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                End If

                If isLocal = True Then
                    cmd.CommandText = "EXEC warehouse.RollbackCustomSellForSupporterNoNDS @ShtrikhCode,@SupporterID,@ClientID"
                Else
                    cmd.CommandText = "EXEC warehouse.RollbackCustomSellForClientNoNDS @ShtrikhCode,@SupporterID,@ClientID"
                End If

                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CustomSellForClient
    Friend Function CustomSellForClient(ByVal ShtrikhCode As String, ByVal SupporterID As Byte, ByVal SELLID As Integer, ByVal ClientID As Integer, ByVal EquipmentID As Short, ByVal Price As Decimal, ByVal AraqmanAddress As String, ByVal SellEcrPropID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@SELLID", SqlDbType.Int).Value = SELLID
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price
                cmd.Parameters.Add("@AraqmanAddress", SqlDbType.NVarChar).Value = AraqmanAddress
                cmd.Parameters.Add("@SellEcrPropID", SqlDbType.Int).Value = SellEcrPropID
                cmd.CommandText = "EXEC warehouse.CustomSellForClient @ShtrikhCode,@SupporterID,@SELLID,@ClientID,@EquipmentID,@Price,@AraqmanAddress,@SellEcrPropID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CustomSellForClientFiz
    Friend Function CustomSellForClientFiz(ByVal ShtrikhCode As String, ByVal SupporterID As Byte, ByVal SELLID As Integer, ByVal ClientID As Integer, ByVal EquipmentID As Short, ByVal Price As Decimal, ByVal AraqmanAddress As String, ByVal SellEcrPropID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@SELLID", SqlDbType.Int).Value = SELLID
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price
                cmd.Parameters.Add("@AraqmanAddress", SqlDbType.NVarChar).Value = AraqmanAddress
                cmd.Parameters.Add("@SellEcrPropID", SqlDbType.Int).Value = SellEcrPropID
                cmd.CommandText = "EXEC warehouse.CustomSellForClientFiz @ShtrikhCode,@SupporterID,@SELLID,@ClientID,@EquipmentID,@Price,@AraqmanAddress,@SellEcrPropID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CustomSellForClientNoNDS
    Friend Function CustomSellForClientNoNDS(ByVal ShtrikhCode As String, ByVal SupporterID As Byte, ByVal SELLID As Integer, ByVal ClientID As Integer, ByVal EquipmentID As Short, ByVal Price As Decimal) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@SELLID", SqlDbType.Int).Value = SELLID
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price
                cmd.CommandText = "EXEC warehouse.CustomSellForClientNoNDS @ShtrikhCode,@SupporterID,@SELLID,@ClientID,@EquipmentID,@Price"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CheckForRemakeEquipment
    Friend Function CheckForRemakeEquipment(ByVal RemakeID As Integer) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.CheckForRemakeEquipment(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'IsEcrInRemake
    Friend Function IsEcrInRemake(ByVal ecrID As Integer) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsEcrInRemake(@ecrID)"
                cmd.Parameters.Add("@ecrID", SqlDbType.Int).Value = ecrID
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'CanBeRemakeApproved
    Friend Function CanBeRemakeApproved(ByVal RemakeID As Integer) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.CanBeRemakeApproved(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'IsEcrBloked
    Friend Function IsEcrBloked(ByVal Ecr As String) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsEcrBloked(@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'IsProposalEquipmentSold
    Friend Function IsProposalEquipmentSold(ByVal haytId As Integer) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsProposalEquipmentSold(@haytId)"
                cmd.Parameters.Add("@haytId", SqlDbType.Int).Value = haytId
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'IsProposalOpenExist
    Friend Function IsProposalOpenExist(ByVal hvhh As String) As Boolean
        Dim b
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.IsProposalOpenExist(@hvhh)"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'GetGprsClientInfoBySerial
    Friend Function GetGprsClientInfoBySerial(ByVal Serial As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Serial", SqlDbType.VarChar).Value = Serial
                cmd.CommandText = "SELECT * FROM Client.GetGprsClientInfoBySerial(@Serial)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetGprsChanges
    Friend Function GetGprsChanges() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetGprsChanges()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetGprsALL
    Friend Function GetGprsALL() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetGprsALL()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeEcrLocationReport
    Friend Function GetRemakeEcrLocationReport(OnlyOpen As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@OnlyOpen", SqlDbType.Bit).Value = OnlyOpen
                cmd.CommandText = "SELECT * FROM Client.GetRemakeEcrLocationReport(@OnlyOpen)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeEcrLocationReportBySupporter
    Friend Function GetRemakeEcrLocationReportBySupporter(SupporterID As Byte, OnlyOpen As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@OnlyOpen", SqlDbType.Bit).Value = OnlyOpen
                cmd.CommandText = "SELECT * FROM Client.GetRemakeEcrLocationReportBySupporter(@SupporterID,@OnlyOpen)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'AddBulkGprs
    Friend Function AddBulkGprs(ByVal G As DataTable, ByVal o As Char) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Client.AddBulkGprs"
                cmd.Parameters.Add("@O", SqlDbType.Char).Value = o
                cmd.Parameters.Add("@G", SqlDbType.Structured).Value = G
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetNotApprovedGprs
    Friend Function GetNotApprovedGprs() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetNotApprovedGprs()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTelNumberForHaytSMS
    Friend Function GetTelNumberForHaytSMS(ByVal RemakeID As Integer, ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                cmd.CommandText = "SELECT * FROM Client.GetTelNumberForHaytSMS(@RemakeID,@ClientID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Select Data 6"

    'GetHaytSms
    Friend Function GetHaytSms(ByVal SupporterID As Byte, Optional ByVal sDate As Object = Nothing, Optional ByVal eDate As Object = Nothing) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@O", SqlDbType.TinyInt).Value = SupporterID
                If sDate = Nothing Then cmd.Parameters.Add("@SDate", SqlDbType.Date).Value = DBNull.Value Else cmd.Parameters.Add("@SDate", SqlDbType.Date).Value = sDate
                If eDate = Nothing Then cmd.Parameters.Add("@EDate", SqlDbType.Date).Value = DBNull.Value Else cmd.Parameters.Add("@EDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "EXEC Client.GetHaytSms @O,@SDate,@EDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'SMSToCenterAll
    Friend Function SMSToCenterAll() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.SMSToCenterAll()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'SMSToCenter
    Friend Function SMSToCenter(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Client.SMSToCenter(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CreateShtrikCode
    Friend Function CreateShtrikCode(ByVal T As DataTable) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand("Client.CreateShtrikCode", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@ShtrikhGen", SqlDbType.Structured).Value = T
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ProposalActivateEcrCount
    Friend Function ProposalActivateEcrCount(ByVal ecr As String) As Integer
        Dim bt As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.ProposalActivateEcrCount(@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = ecr
                bt = cmd.ExecuteScalar()
            End Using
        End Using
        Return bt
    End Function

    'ProposalGeneralEcrCount
    Friend Function ProposalGeneralEcrCount(ByVal ecr As String) As Integer
        Dim bt As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.ProposalGeneralEcrCount(@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = ecr
                bt = cmd.ExecuteScalar()
            End Using
        End Using
        Return bt
    End Function

    'ActivatePropGetClient
    Friend Function ActivatePropGetClient(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                cmd.CommandText = "SELECT * FROM Client.ActivatePropGetClient(@Ecr)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GlobalPropGetClient
    Friend Function GlobalPropGetClient(ByVal ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                cmd.CommandText = "EXEC Client.GlobalPropGetClient @Ecr"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ActivatePropGetSupporter
    Friend Function ActivatePropGetSupporter(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                cmd.CommandText = "SELECT * FROM Client.ActivatePropGetSupporter(@hvhh)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ActivatePropGetByHVHH
    Friend Function ActivatePropGetByHVHH(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                cmd.CommandText = "SELECT * FROM Client.ActivatePropGetByHVHH(@hvhh)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GlobalPropGetByHVHH
    Friend Function GlobalPropGetByHVHH(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                cmd.CommandText = "EXEC Client.GlobalPropGetByHVHH @hvhh"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GlobalPropGetEcrGPRSStatus
    Friend Function GlobalPropGetEcrGPRSStatus(ByVal Ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
                cmd.CommandText = "EXEC Client.GlobalPropGetEcrGPRSStatus @Ecr"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'Artyom | Arman
    Friend Function HasGlobalPropGetEcrGPRSStatus(ByVal Ecr As String) As Boolean
        Dim dt As DataTable = GlobalPropGetEcrGPRSStatus(Ecr)
        If dt.Rows.Count > 0 And dt.Columns.Contains("ՋնջվածGprs") Then
            Return dt.Rows(0)("ՋնջվածGprs")
        End If
        Return False
    End Function

    'ActivatePropGetByAddress
    Friend Function ActivatePropGetByAddress(ByVal addr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@addr", SqlDbType.NVarChar).Value = addr
                cmd.CommandText = "SELECT * FROM Client.ActivatePropGetByAddress(@addr)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ActivatePropGetByClient
    Friend Function ActivatePropGetByClient(ByVal Client As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Client", SqlDbType.NVarChar).Value = Client
                cmd.CommandText = "SELECT * FROM Client.ActivatePropGetByClient(@Client)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GeneralPropGetByClient
    Friend Function GeneralPropGetByClient(ByVal Client As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Client", SqlDbType.NVarChar).Value = Client
                cmd.CommandText = "EXEC Client.GeneralPropGetByClient @Client"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ActivateHaytByDateByOpen
    Friend Function ActivateHaytByDateByOpen(sd As Date, ed As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = ed
                cmd.CommandText = "EXEC Client.ActivateHaytByDateByOpen @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GeneralHaytByDateByOpen
    Friend Function GeneralHaytByDateByOpen(sd As Date, ed As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = ed
                cmd.CommandText = "EXEC Client.GeneralHaytByDateByOpen @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ActivateHaytByDate
    Friend Function ActivateHaytByDate(sd As Date, ed As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = ed
                cmd.CommandText = "EXEC Client.ActivateHaytByDate @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GeneralHaytByDate
    Friend Function GeneralHaytByDate(sd As Date, ed As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = ed
                cmd.CommandText = "EXEC Client.GeneralHaytByDate @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'PropAnalysis
    Friend Function PropAnalysis(isRegion As Boolean, sd As Date, ed As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@isRegion", SqlDbType.Bit).Value = isRegion
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = ed
                cmd.CommandText = "EXEC Client.PropAnalysis @isRegion, @sDate, @eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ActivateHaytByOpen
    Friend Function ActivateHaytByOpen(isOpen As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Open", SqlDbType.Bit).Value = isOpen
                cmd.CommandText = "EXEC Client.ActivateHaytByOpen @Open"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GeneralHaytByOpen
    Friend Function GeneralHaytByOpen(isOpen As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Open", SqlDbType.Bit).Value = isOpen
                cmd.CommandText = "EXEC Client.GeneralHaytByOpen @Open"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'AddActivateProp
    Friend Function AddActivateProp(ecr As String, hvhh As String, addr As String, Client As String, Tel As String, Regoin As String, Tesuch As String,
                                PropStatus As Boolean, PropAddUser As String,
                                Watched As Boolean, DateOfPropDone As DateTime, Supporter As Byte, IsPrinted As Boolean, ApproveCode As String,
                                loc As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ecr", Data.SqlDbType.VarChar).Value = ecr
                cmd.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
                cmd.Parameters.Add("@addr", Data.SqlDbType.NVarChar).Value = addr
                cmd.Parameters.Add("@Client", Data.SqlDbType.NVarChar).Value = Client
                cmd.Parameters.Add("@Tel", Data.SqlDbType.VarChar).Value = Tel
                cmd.Parameters.Add("@Regoin", Data.SqlDbType.NVarChar).Value = Regoin
                cmd.Parameters.Add("@Tesuch", Data.SqlDbType.NVarChar).Value = Tesuch
                cmd.Parameters.Add("@PropStatus", Data.SqlDbType.Bit).Value = PropStatus
                cmd.Parameters.Add("@PropAddUser", Data.SqlDbType.NVarChar).Value = PropAddUser
                cmd.Parameters.Add("@Watched", Data.SqlDbType.Bit).Value = Watched
                cmd.Parameters.Add("@DateOfPropDone", Data.SqlDbType.DateTime).Value = DateOfPropDone
                cmd.Parameters.Add("@Supporter", Data.SqlDbType.TinyInt).Value = Supporter
                cmd.Parameters.Add("@IsPrinted", Data.SqlDbType.Bit).Value = IsPrinted
                cmd.Parameters.Add("@ApproveCode", Data.SqlDbType.NVarChar).Value = ApproveCode
                cmd.Parameters.Add("@loc", Data.SqlDbType.VarChar).Value = loc
                cmd.CommandText = "EXEC Client.AddActivateProp @ecr,@hvhh,@addr,@Client,@Tel,@Regoin,@Tesuch,@PropStatus,@PropAddUser,@Watched,@DateOfPropDone,@Supporter,@IsPrinted,@ApproveCode,@loc"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'AddGeneralProp
    Friend Function AddGeneralProp(ecr As String, hvhh As String, addr As String, Client As String, Tel As String, Regoin As String, Tesuch As String,
                                PropStatus As Boolean, PropAddUser As String,
                                Watched As Boolean, DateOfPropDone As DateTime, Supporter As Byte, IsPrinted As Boolean, Problem As String,
                                loc As String, ProblemType As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ecr", Data.SqlDbType.VarChar).Value = ecr
                cmd.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
                cmd.Parameters.Add("@addr", Data.SqlDbType.NVarChar).Value = addr
                cmd.Parameters.Add("@Client", Data.SqlDbType.NVarChar).Value = Client
                cmd.Parameters.Add("@Tel", Data.SqlDbType.VarChar).Value = Tel
                cmd.Parameters.Add("@Regoin", Data.SqlDbType.NVarChar).Value = Regoin
                cmd.Parameters.Add("@Tesuch", Data.SqlDbType.NVarChar).Value = Tesuch
                cmd.Parameters.Add("@PropStatus", Data.SqlDbType.Bit).Value = PropStatus
                cmd.Parameters.Add("@PropAddUser", Data.SqlDbType.NVarChar).Value = PropAddUser
                cmd.Parameters.Add("@Watched", Data.SqlDbType.Bit).Value = Watched
                cmd.Parameters.Add("@DateOfPropDone", Data.SqlDbType.DateTime).Value = DateOfPropDone
                cmd.Parameters.Add("@Supporter", Data.SqlDbType.TinyInt).Value = Supporter
                cmd.Parameters.Add("@IsPrinted", Data.SqlDbType.Bit).Value = IsPrinted
                cmd.Parameters.Add("@Problem", Data.SqlDbType.NVarChar).Value = Problem
                cmd.Parameters.Add("@loc", Data.SqlDbType.VarChar).Value = loc
                cmd.Parameters.Add("@ProblemType", Data.SqlDbType.Int).Value = ProblemType
                cmd.CommandText = "EXEC Client.AddGeneralProp @ecr,@hvhh,@addr,@Client,@Tel,@Regoin,@Tesuch,@PropStatus,@PropAddUser,@Watched,@DateOfPropDone,@Supporter,@IsPrinted,@Problem,@loc,@ProblemType"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ClosedPropAllByDate
    Friend Function ClosedPropAllByDate(sd As Date, ed As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = ed
                cmd.CommandText = "EXEC Client.ClosedPropAllByDate @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ClosedPropSupporterByDate
    Friend Function ClosedPropSupporterByDate(sd As Date, ed As Date, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sd
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = ed
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "EXEC Client.ClosedPropSupporterByDate @sDate,@eDate,@SupporterID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Insert Data"

    'InsertTesuchInfo
    Friend Sub InsertTesuchInfo(ByVal TesuchName As String, ByVal tesuchStatus As Boolean, ByVal tesuchMail As String, ByVal tesuchTel As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.InsertTesuch @TesuchName,@tesuchStatus,@tesuchMail,@tesuchTel", connection)
            cmdSQLcom.Parameters.Add("@TesuchName", Data.SqlDbType.NVarChar).Value = TesuchName
            cmdSQLcom.Parameters.Add("@tesuchStatus", Data.SqlDbType.Bit).Value = tesuchStatus
            If String.IsNullOrEmpty(tesuchMail) Then
                cmdSQLcom.Parameters.Add("@tesuchMail", Data.SqlDbType.NVarChar).Value = DBNull.Value
            Else
                cmdSQLcom.Parameters.Add("@tesuchMail", Data.SqlDbType.NVarChar).Value = tesuchMail
            End If
            If String.IsNullOrEmpty(tesuchTel) Then
                cmdSQLcom.Parameters.Add("@tesuchTel", Data.SqlDbType.VarChar).Value = DBNull.Value
            Else
                cmdSQLcom.Parameters.Add("@tesuchTel", Data.SqlDbType.VarChar).Value = tesuchTel
            End If
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Insert Tesuch Info
    Friend Sub InsertTesuchInfo(ByVal TesuchID As Short, ByVal RegionID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.InsertTesuchInfo @TesuchID,@RegionID", connection)
            cmdSQLcom.Parameters.Add("@TesuchID", Data.SqlDbType.SmallInt).Value = TesuchID
            cmdSQLcom.Parameters.Add("@RegionID", Data.SqlDbType.SmallInt).Value = RegionID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Insert Tarajamket
    Friend Sub InsertTarajamket(ByVal equipmentId As Integer, price As Decimal, months As Byte, isActive As Boolean, name As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.InsertTarajamket @equipmentId, @price, @months, @isActive, @name", connection)
            cmdSQLcom.Parameters.Add("@equipmentId", Data.SqlDbType.Int).Value = equipmentId
            cmdSQLcom.Parameters.Add("@price", Data.SqlDbType.Decimal).Value = price
            cmdSQLcom.Parameters.Add("@months", Data.SqlDbType.TinyInt).Value = months
            cmdSQLcom.Parameters.Add("@isActive", Data.SqlDbType.Bit).Value = isActive
            cmdSQLcom.Parameters.Add("@name", Data.SqlDbType.NVarChar).Value = name

            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Insert TarajamketGraphik
    Friend Sub InsertTarajamketGraphik(ByVal tarajamketId As Integer, Optional price1 As Decimal = 0, Optional price2 As Decimal = 0, Optional price3 As Decimal = 0 _
        , Optional price4 As Decimal = 0, Optional price5 As Decimal = 0, Optional price6 As Decimal = 0, Optional price7 As Decimal = 0, Optional price8 As Decimal = 0 _
        , Optional price9 As Decimal = 0, Optional price10 As Decimal = 0, Optional price11 As Decimal = 0, Optional price12 As Decimal = 0)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.TarajamketGraphik @tarajamketId, @price1, @price2, @price3, @price4, @price5, @price6 , @price7, @price8, @price9, @price10, @price11, @price12", connection)
            cmdSQLcom.Parameters.Add("@tarajamketId", Data.SqlDbType.Int).Value = tarajamketId
            cmdSQLcom.Parameters.Add("@price1", Data.SqlDbType.Decimal).Value = price1
            cmdSQLcom.Parameters.Add("@price2", Data.SqlDbType.Decimal).Value = price2
            cmdSQLcom.Parameters.Add("@price3", Data.SqlDbType.Decimal).Value = price3
            cmdSQLcom.Parameters.Add("@price4", Data.SqlDbType.Decimal).Value = price4
            cmdSQLcom.Parameters.Add("@price5", Data.SqlDbType.Decimal).Value = price5
            cmdSQLcom.Parameters.Add("@price6", Data.SqlDbType.Decimal).Value = price6
            cmdSQLcom.Parameters.Add("@price7", Data.SqlDbType.Decimal).Value = price7
            cmdSQLcom.Parameters.Add("@price8", Data.SqlDbType.Decimal).Value = price8
            cmdSQLcom.Parameters.Add("@price9", Data.SqlDbType.Decimal).Value = price9
            cmdSQLcom.Parameters.Add("@price10", Data.SqlDbType.Decimal).Value = price10
            cmdSQLcom.Parameters.Add("@price11", Data.SqlDbType.Decimal).Value = price11
            cmdSQLcom.Parameters.Add("@price12", Data.SqlDbType.Decimal).Value = price12
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Insert Region
    Friend Sub InsertRegionInfo(ByVal regionName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertRegion @regionName", connection)
            cmdSQLcom.Parameters.Add("@regionName", Data.SqlDbType.NVarChar).Value = regionName

            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Insert Contract
    Friend Sub InsertContract(ByVal strContract As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertContract @strContract", connection)
            cmdSQLcom.Parameters.Add("@strContract", Data.SqlDbType.NVarChar).Value = strContract
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Insert Address
    Friend Sub InsertAddress(ByVal strAddress As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertAddress @strAddress", connection)
            cmdSQLcom.Parameters.Add("@strAddress", Data.SqlDbType.NVarChar).Value = strAddress
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Insert Object Type
    Friend Sub InsertObjectType(ByVal strObject As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertObjectType @strObject", connection)
            cmdSQLcom.Parameters.Add("@strObject", Data.SqlDbType.NVarChar).Value = strObject
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Insert THT
    Friend Sub InsertTht(ByVal tht As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertTht @tht", connection)
            cmdSQLcom.Parameters.Add("@tht", Data.SqlDbType.NVarChar).Value = tht
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Insert Public Message
    Friend Sub AddPublicMessage(ByVal messageType As Image, ByVal senderID As Short, ByVal Message As String, ByVal isPublic As Boolean, ByVal reciverID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.AddPublicMessage @messageType,@senderID,@message,@isPublic,@reciverID", connection)
            cmdSQLcom.Parameters.Add("@messageType", Data.SqlDbType.VarBinary).Value = ConvertImage(messageType)
            cmdSQLcom.Parameters.Add("@senderID", Data.SqlDbType.SmallInt).Value = senderID
            cmdSQLcom.Parameters.Add("@message", Data.SqlDbType.NVarChar).Value = Message
            cmdSQLcom.Parameters.Add("@isPublic", Data.SqlDbType.Bit).Value = isPublic
            cmdSQLcom.Parameters.Add("@reciverID", Data.SqlDbType.SmallInt).Value = reciverID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Insert EcrShipping
    Friend Sub AddEcrShipping(ByVal EcrID As String, ByVal RegionID As Short, ByVal ShippingPlace As String,
                              ByVal ShippingTime As DateTime, ByVal DriverTelephone As String, ByVal CarNumber As String, ByVal EcrGUID As String, ByVal SupporterID As Byte)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddEcrShipping @EcrID,@RegionID,@ShippingPlace,@ShippingTime,@DriverTelephone,@CarNumber,@EcrGUID,@SupporterID", connection)
            cmdSQLcom.Parameters.Add("@EcrID", Data.SqlDbType.VarChar).Value = EcrID
            cmdSQLcom.Parameters.Add("@RegionID", Data.SqlDbType.SmallInt).Value = RegionID
            cmdSQLcom.Parameters.Add("@ShippingPlace", Data.SqlDbType.NVarChar).Value = ShippingPlace
            cmdSQLcom.Parameters.Add("@ShippingTime", Data.SqlDbType.DateTime2).Value = ShippingTime
            cmdSQLcom.Parameters.Add("@DriverTelephone", Data.SqlDbType.VarChar).Value = DriverTelephone
            cmdSQLcom.Parameters.Add("@CarNumber", Data.SqlDbType.NVarChar).Value = CarNumber
            cmdSQLcom.Parameters.Add("@EcrGUID", Data.SqlDbType.VarChar).Value = EcrGUID
            cmdSQLcom.Parameters.Add("@SupporterID", Data.SqlDbType.TinyInt).Value = SupporterID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertClient
    Friend Sub InsertClient(ByVal hvhh As String, ByVal contract As String, ByVal company As String, ByVal director As String, ByVal irAddress As String, ByVal araqAddress As String,
                            ByVal tht As Short, ByVal tarif As Short, ByVal region As Short, ByVal supporter As Byte, ByVal tel As String, ByVal comment As String, ByVal hraj As Boolean,
                            ByVal notSupp As Boolean, ByVal nds As Boolean, ByVal zeronds As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertClient @hvhh,@contract,@company,@director,@irAddress,@araqAddress,@tht,@tarif,@region,@supporter,@tel,@comment,@hraj,@notSupp,@nds,@zeronds", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@contract", Data.SqlDbType.NVarChar).Value = contract
            cmdSQLcom.Parameters.Add("@company", Data.SqlDbType.NVarChar).Value = company
            cmdSQLcom.Parameters.Add("@director", Data.SqlDbType.NVarChar).Value = director
            cmdSQLcom.Parameters.Add("@irAddress", Data.SqlDbType.NVarChar).Value = irAddress
            cmdSQLcom.Parameters.Add("@araqAddress", Data.SqlDbType.NVarChar).Value = araqAddress
            cmdSQLcom.Parameters.Add("@tht", Data.SqlDbType.SmallInt).Value = tht
            cmdSQLcom.Parameters.Add("@tarif", Data.SqlDbType.SmallInt).Value = tarif
            cmdSQLcom.Parameters.Add("@region", Data.SqlDbType.SmallInt).Value = region
            cmdSQLcom.Parameters.Add("@supporter", Data.SqlDbType.TinyInt).Value = supporter
            cmdSQLcom.Parameters.Add("@tel", Data.SqlDbType.VarChar).Value = tel
            If String.IsNullOrEmpty(comment) Then cmdSQLcom.Parameters.Add("@comment", Data.SqlDbType.NVarChar).Value = DBNull.Value Else cmdSQLcom.Parameters.Add("@comment", Data.SqlDbType.NVarChar).Value = comment
            cmdSQLcom.Parameters.Add("@hraj", Data.SqlDbType.Bit).Value = hraj
            cmdSQLcom.Parameters.Add("@notSupp", Data.SqlDbType.Bit).Value = notSupp
            cmdSQLcom.Parameters.Add("@nds", Data.SqlDbType.Bit).Value = nds
            cmdSQLcom.Parameters.Add("@zeronds", Data.SqlDbType.Bit).Value = zeronds
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertClientFiz
    Friend Sub InsertClientFiz(ByVal fullName As String, ByVal passport As String, ByVal tel As String, ByVal address As String, ByVal socCard As String, ByVal email As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertClientFiz @fullName,@passport,@tel,@address,@socCard,@email", connection)
            cmdSQLcom.Parameters.Add("@fullName", Data.SqlDbType.NVarChar).Value = fullName
            cmdSQLcom.Parameters.Add("@passport", Data.SqlDbType.NVarChar).Value = passport
            cmdSQLcom.Parameters.Add("@tel", Data.SqlDbType.NVarChar).Value = tel
            cmdSQLcom.Parameters.Add("@address", Data.SqlDbType.NVarChar).Value = address
            If String.IsNullOrEmpty(socCard) Then cmdSQLcom.Parameters.Add("@socCard", Data.SqlDbType.NVarChar).Value = DBNull.Value Else cmdSQLcom.Parameters.Add("@socCard", Data.SqlDbType.NVarChar).Value = socCard
            If String.IsNullOrEmpty(email) Then cmdSQLcom.Parameters.Add("@email", Data.SqlDbType.NVarChar).Value = DBNull.Value Else cmdSQLcom.Parameters.Add("@email", Data.SqlDbType.NVarChar).Value = email
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertPayment
    Friend Sub InsertPayment(ByVal hvhh As String, ByVal Payment As Decimal, ByVal PayDate As DateTime, ByVal PayType As Char, ByVal SupporterID As Byte)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.InsertPayment @hvhh,@Payment,@PayDate,@PayType,@SupporterID", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@Payment", Data.SqlDbType.Decimal).Value = Payment
            cmdSQLcom.Parameters.Add("@PayDate", Data.SqlDbType.DateTime).Value = PayDate
            cmdSQLcom.Parameters.Add("@PayType", Data.SqlDbType.Char).Value = PayType
            cmdSQLcom.Parameters.Add("@SupporterID", Data.SqlDbType.TinyInt).Value = SupporterID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertPaymentFiz
    Friend Sub InsertPaymentFiz(ByVal hvhh As String, ByVal Payment As Decimal, ByVal PayDate As DateTime, ByVal PayType As Char, ByVal SupporterID As Byte)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.InsertPaymentFiz @passport,@Payment,@PayDate,@PayType,@SupporterID", connection)
            cmdSQLcom.Parameters.Add("@passport", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@Payment", Data.SqlDbType.Decimal).Value = Payment
            cmdSQLcom.Parameters.Add("@PayDate", Data.SqlDbType.DateTime).Value = PayDate
            cmdSQLcom.Parameters.Add("@PayType", Data.SqlDbType.Char).Value = PayType
            cmdSQLcom.Parameters.Add("@SupporterID", Data.SqlDbType.TinyInt).Value = SupporterID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertEcr
    Friend Sub InsertEcr(ByVal ecr As String, ByVal hvhh As String, ByVal mgh As String, ByVal contDate As Date, ByVal gAddress As String, ByVal gprs As String,
                         ByVal sStatus As Byte, ByVal sRegion As Short, ByVal oType As String, ByVal Tel As String, ByVal tesuch As Short, ByVal isNds As Boolean,
                         ByVal isPosTerminal As Boolean, ByVal isInvoice As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertEcr @ecr,@hvhh,@mgh,@contDate,@gAddress,@gprs,@sStatus,@sRegion,@oType,@Tel,@tesuch,@isNds,@isPosTerminal,@isInvoice", connection)
            cmdSQLcom.Parameters.Add("@ecr", Data.SqlDbType.VarChar).Value = ecr
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@mgh", Data.SqlDbType.VarChar).Value = mgh
            cmdSQLcom.Parameters.Add("@contDate", Data.SqlDbType.Date).Value = contDate
            cmdSQLcom.Parameters.Add("@gAddress", Data.SqlDbType.NVarChar).Value = gAddress
            cmdSQLcom.Parameters.Add("@gprs", Data.SqlDbType.VarChar).Value = gprs
            cmdSQLcom.Parameters.Add("@sStatus", Data.SqlDbType.TinyInt).Value = sStatus
            cmdSQLcom.Parameters.Add("@sRegion", Data.SqlDbType.SmallInt).Value = sRegion
            cmdSQLcom.Parameters.Add("@oType", Data.SqlDbType.NVarChar).Value = oType
            cmdSQLcom.Parameters.Add("@Tel", Data.SqlDbType.VarChar).Value = Tel
            cmdSQLcom.Parameters.Add("@tesuch", Data.SqlDbType.SmallInt).Value = tesuch
            cmdSQLcom.Parameters.Add("@isNds", Data.SqlDbType.Bit).Value = isNds
            cmdSQLcom.Parameters.Add("@isPosTerminal", Data.SqlDbType.Bit).Value = isPosTerminal
            cmdSQLcom.Parameters.Add("@isInvoice", Data.SqlDbType.Bit).Value = isInvoice
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertContractCount
    Friend Sub InsertContractCount(ByVal ClientID As Integer, ByVal cYear As Short, ByVal cMonth As Byte, ByVal EcrCount As Short, ByVal ApplicationCount As Short, ByVal ContractName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertContractCount @ClientID,@cYear,@cMonth,@EcrCount,@ApplicationCount,@ContractName", connection)
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            cmdSQLcom.Parameters.Add("@cYear", Data.SqlDbType.SmallInt).Value = cYear
            cmdSQLcom.Parameters.Add("@cMonth", Data.SqlDbType.TinyInt).Value = cMonth
            cmdSQLcom.Parameters.Add("@EcrCount", Data.SqlDbType.SmallInt).Value = EcrCount
            cmdSQLcom.Parameters.Add("@ApplicationCount", Data.SqlDbType.SmallInt).Value = ApplicationCount
            cmdSQLcom.Parameters.Add("@ContractName", Data.SqlDbType.NVarChar).Value = ContractName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertSIMEnableByHVHH
    Friend Sub InsertSIMEnableByHVHH(ByVal hvhh As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertSIMEnableByHVHH @hvhh", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertSIMEnableByHVHH2
    Friend Sub InsertSIMEnableByHVHH2(ByVal hvhh As String, ByVal SupporterID As Byte)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertSIMEnableByHVHH2 @hvhh,@SupporterID", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@SupporterID", Data.SqlDbType.TinyInt).Value = SupporterID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertSMS
    Friend Sub InsertSMS(ByVal O As Byte, ByVal C As Integer, ByVal D As Boolean, ByVal T As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertSMS @O,@C,@D,@T", connection)
            cmdSQLcom.Parameters.Add("@O", Data.SqlDbType.TinyInt).Value = O
            cmdSQLcom.Parameters.Add("@C", Data.SqlDbType.Int).Value = C
            cmdSQLcom.Parameters.Add("@D", Data.SqlDbType.Bit).Value = D
            cmdSQLcom.Parameters.Add("@T", Data.SqlDbType.VarChar).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertSMSToTesuch
    Friend Sub InsertSMSToTesuch(ByVal T As String, ByVal M As String, ByVal Tel As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.InsertSMSToTesuch @T,@M,@Tel", connection)
            cmdSQLcom.Parameters.Add("@T", Data.SqlDbType.NVarChar).Value = T
            cmdSQLcom.Parameters.Add("@M", Data.SqlDbType.NVarChar).Value = M
            cmdSQLcom.Parameters.Add("@Tel", Data.SqlDbType.VarChar).Value = Tel
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertSMSToTesuchActiv
    Friend Sub InsertSMSToTesuchActiv(ByVal T As String, ByVal M As String, ByVal Tel As String, ByVal ID_Prop As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.InsertSMSToTesuchActiv @T,@M,@Tel,@ID_Prop", connection)
            cmdSQLcom.Parameters.Add("@T", Data.SqlDbType.NVarChar).Value = T
            cmdSQLcom.Parameters.Add("@M", Data.SqlDbType.NVarChar).Value = M
            cmdSQLcom.Parameters.Add("@Tel", Data.SqlDbType.VarChar).Value = Tel
            cmdSQLcom.Parameters.Add("@ID_Prop", Data.SqlDbType.Int).Value = ID_Prop
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertSMSToTesuchGeneral
    Friend Sub InsertSMSToTesuchGeneral(ByVal T As String, ByVal M As String, ByVal Tel As String, ByVal ID_Prop As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.InsertSMSToTesuchGeneral @T,@M,@Tel,@ID_Prop", connection)
            cmdSQLcom.Parameters.Add("@T", Data.SqlDbType.NVarChar).Value = T
            cmdSQLcom.Parameters.Add("@M", Data.SqlDbType.NVarChar).Value = M
            cmdSQLcom.Parameters.Add("@Tel", Data.SqlDbType.VarChar).Value = Tel
            cmdSQLcom.Parameters.Add("@ID_Prop", Data.SqlDbType.Int).Value = ID_Prop
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertSMSToClientByHVHH
    Friend Sub InsertSMSToClientByHVHH(ByVal O As Byte, ByVal C As Integer, ByVal M As String, ByVal T As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertSMSToClientByHVHH @O,@C,@M,@T", connection)
            cmdSQLcom.Parameters.Add("@O", Data.SqlDbType.TinyInt).Value = O
            cmdSQLcom.Parameters.Add("@C", Data.SqlDbType.Int).Value = C
            cmdSQLcom.Parameters.Add("@M", Data.SqlDbType.NVarChar).Value = M
            cmdSQLcom.Parameters.Add("@T", Data.SqlDbType.VarChar).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertEquipment
    Friend Sub InsertEquipment(ByVal Equipment As String, ByVal canSel As Boolean, ByVal isEcr As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.InsertEquipment @Equipment,@canSel,@isEcr", connection)
            cmdSQLcom.Parameters.Add("@Equipment", Data.SqlDbType.NVarChar).Value = Equipment
            cmdSQLcom.Parameters.Add("@canSel", Data.SqlDbType.Bit).Value = canSel
            cmdSQLcom.Parameters.Add("@isEcr", Data.SqlDbType.Bit).Value = isEcr
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertPurchaseWarehouse
    Friend Sub InsertPurchaseWarehouse(ByVal EquipmentID As Short, ByVal Quantity As Short, ByVal PurchaseAmount As Decimal, ByVal PurchaseDate As Date, ByVal Comment As String, ByVal SupporterID As Byte, ByVal Market As Boolean, ByVal shtrikh As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.InsertPurchaseWarehouse @EquipmentID,@Quantity,@PurchaseAmount,@PurchaseDate,@Comment,@SupporterID,@Market,@ShtrikhCode", connection)
            cmdSQLcom.Parameters.Add("@EquipmentID", Data.SqlDbType.SmallInt).Value = EquipmentID
            cmdSQLcom.Parameters.Add("@Quantity", Data.SqlDbType.SmallInt).Value = Quantity
            cmdSQLcom.Parameters.Add("@PurchaseAmount", Data.SqlDbType.Decimal).Value = PurchaseAmount
            cmdSQLcom.Parameters.Add("@PurchaseDate", Data.SqlDbType.Date).Value = PurchaseDate
            If Comment = String.Empty Then cmdSQLcom.Parameters.Add("@Comment", Data.SqlDbType.NVarChar).Value = DBNull.Value Else cmdSQLcom.Parameters.Add("@Comment", Data.SqlDbType.NVarChar).Value = Comment
            cmdSQLcom.Parameters.Add("@SupporterID", Data.SqlDbType.TinyInt).Value = SupporterID
            cmdSQLcom.Parameters.Add("@Market", Data.SqlDbType.Bit).Value = Market
            cmdSQLcom.Parameters.Add("@ShtrikhCode", Data.SqlDbType.Char).Value = shtrikh
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertPurchaseWarehouse2
    Friend Sub InsertPurchaseWarehouse2(ByVal EquipmentID As Short, ByVal Quantity As Short, ByVal PurchaseAmount As Decimal, ByVal PurchaseDate As Date, ByVal Comment As String, ByVal SupporterID As Byte, ByVal Market As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.InsertPurchaseWarehouse2 @EquipmentID,@Quantity,@PurchaseAmount,@PurchaseDate,@Comment,@SupporterID,@Market", connection)
            cmdSQLcom.Parameters.Add("@EquipmentID", Data.SqlDbType.SmallInt).Value = EquipmentID
            cmdSQLcom.Parameters.Add("@Quantity", Data.SqlDbType.SmallInt).Value = Quantity
            cmdSQLcom.Parameters.Add("@PurchaseAmount", Data.SqlDbType.Decimal).Value = PurchaseAmount
            cmdSQLcom.Parameters.Add("@PurchaseDate", Data.SqlDbType.Date).Value = PurchaseDate
            If Comment = String.Empty Then cmdSQLcom.Parameters.Add("@Comment", Data.SqlDbType.NVarChar).Value = DBNull.Value Else cmdSQLcom.Parameters.Add("@Comment", Data.SqlDbType.NVarChar).Value = Comment
            cmdSQLcom.Parameters.Add("@SupporterID", Data.SqlDbType.TinyInt).Value = SupporterID
            cmdSQLcom.Parameters.Add("@Market", Data.SqlDbType.Bit).Value = Market
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'MoveToRejected
    Friend Sub MoveToRejected(ByVal ShtrikhCode As String, ByVal Comment As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.MoveToRejected @ShtrikhCode,@Comment", connection)
            cmdSQLcom.Parameters.Add("@ShtrikhCode", Data.SqlDbType.Char).Value = ShtrikhCode
            If String.IsNullOrEmpty(Comment) Then cmdSQLcom.Parameters.Add("@Comment", Data.SqlDbType.NVarChar).Value = DBNull.Value Else cmdSQLcom.Parameters.Add("@Comment", Data.SqlDbType.NVarChar).Value = Comment
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'MoveToPoak
    Friend Sub MoveToPoak(ByVal ShtrikhCode As String, ByVal Comment As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.MoveToPoak @ShtrikhCode,@Comment", connection)
            cmdSQLcom.Parameters.Add("@ShtrikhCode", Data.SqlDbType.Char).Value = ShtrikhCode
            If String.IsNullOrEmpty(Comment) Then cmdSQLcom.Parameters.Add("@Comment", Data.SqlDbType.NVarChar).Value = DBNull.Value Else cmdSQLcom.Parameters.Add("@Comment", Data.SqlDbType.NVarChar).Value = Comment
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertTesuchVisit
    Friend Sub InsertTesuchVisit(ByVal mgh As String, ByVal tesuch As Short, ByVal tesaction As String, ByVal vDate As DateTime)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Tesuch.InsertTesuchVisit @Mgh,@Tesuch,@TesuchAction,@VisitDate", connection)
            cmdSQLcom.Parameters.Add("@Mgh", Data.SqlDbType.VarChar).Value = mgh
            cmdSQLcom.Parameters.Add("@Tesuch", Data.SqlDbType.SmallInt).Value = tesuch
            cmdSQLcom.Parameters.Add("@TesuchAction", Data.SqlDbType.NVarChar).Value = tesaction
            cmdSQLcom.Parameters.Add("@VisitDate", Data.SqlDbType.DateTime2).Value = vDate
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ChangeVtoQ
    Friend Sub ChangeVtoQ(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ChangeVtoQ @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertPremiumClient
    Friend Sub InsertPremiumClient(ByVal hvhh As String, ByVal UserID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertPremiumClient @hvhh,@UserID", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@UserID", Data.SqlDbType.SmallInt).Value = UserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertPremiumClient2
    Friend Sub InsertPremiumClient2(ByVal hvhh As String, ByVal UserID As Short, ByVal SupporterID As Byte)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertPremiumClient2 @hvhh,@UserID,@SupporterID", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@UserID", Data.SqlDbType.SmallInt).Value = UserID
            cmdSQLcom.Parameters.Add("@SupporterID", Data.SqlDbType.TinyInt).Value = SupporterID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeletePremiumClientBulk
    Friend Sub DeletePremiumClientBulk(ByVal UserID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeletePremiumBulk @UserID", connection)
            'cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@UserID", Data.SqlDbType.SmallInt).Value = UserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'BulkInsertPremiumClient
    Friend Sub BulkInsertPremiumClient(ByVal vip1200hdm2 As Boolean, ByVal vip1200hdm3 As Boolean, ByVal vip3000 As Boolean, ByVal vip3000Paid As Boolean, ByVal vip3600 As Boolean, ByVal UserID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.BulkInsertPremiumClient @vip1200hdm2, @vip1200hdm3, @vip3000, @vip3000Paid, @vip3600, @UserID", connection)
            cmdSQLcom.Parameters.Add("@vip1200hdm2", Data.SqlDbType.VarChar).Value = vip1200hdm2
            cmdSQLcom.Parameters.Add("@vip1200hdm3", Data.SqlDbType.VarChar).Value = vip1200hdm3
            cmdSQLcom.Parameters.Add("@vip3000", Data.SqlDbType.VarChar).Value = vip3000
            cmdSQLcom.Parameters.Add("@vip3000Paid", Data.SqlDbType.VarChar).Value = vip3000Paid
            cmdSQLcom.Parameters.Add("@vip3600", Data.SqlDbType.VarChar).Value = vip3600
            cmdSQLcom.Parameters.Add("@UserID", Data.SqlDbType.SmallInt).Value = UserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertExcludedHvhh
    Friend Sub InsertExcludedHvhh(ByVal hvhh As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertExcludedHvhh @hvhh", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertProblem
    Friend Sub InsertProblem(ByVal problem As String, ByVal isSoft As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertProblem @Problem,@IsSoft", connection)
            cmdSQLcom.Parameters.Add("@Problem", Data.SqlDbType.NVarChar).Value = problem
            cmdSQLcom.Parameters.Add("@IsSoft", Data.SqlDbType.Bit).Value = isSoft
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SentToIUNet
    Friend Sub SentToIUNet(ByVal Ecr As String, ByVal comment As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.SentToIUNet @Ecr,@comment", connection)
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = Ecr
            If String.IsNullOrEmpty(comment) Then cmdSQLcom.Parameters.Add("@comment", Data.SqlDbType.NVarChar).Value = DBNull.Value Else cmdSQLcom.Parameters.Add("@comment", Data.SqlDbType.NVarChar).Value = comment
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddRemakeWithAkt
    Friend Sub AddRemakeWithAkt(ByVal Ecr As String, ByVal hvhh As String, ByVal UserName As String, ByVal clientName As String, ByVal clientLastName As String, ByVal RandomCode As String, ByVal tel As String, ByVal Hayt As String, ByVal isSoft As Boolean, _
                                isDamaged As Boolean, DamageText As String, OnlyBattary As Boolean, Tup As Boolean, Matit As Boolean, Licqavorich As Boolean, Martkoc As Boolean,
                                TesuchID As Short, Price As Decimal)
        Using connection As New SqlConnection(SQLString)

            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddRemakeWithAkt @Ecr,@hvhh,@UserName,@clientName,@clientLastName,@RandomCode,@tel,@Hayt,@IsSoft,@isDamaged,@DamageText,@OnlyBattary,@Tup,@Matit,@Licqavorich,@Martkoc,@TesuchID,@Price", connection)

            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@UserName", Data.SqlDbType.NVarChar).Value = UserName
            cmdSQLcom.Parameters.Add("@clientName", Data.SqlDbType.NVarChar).Value = clientName
            cmdSQLcom.Parameters.Add("@clientLastName", Data.SqlDbType.NVarChar).Value = clientLastName
            cmdSQLcom.Parameters.Add("@RandomCode", Data.SqlDbType.VarChar).Value = RandomCode
            cmdSQLcom.Parameters.Add("@tel", Data.SqlDbType.NVarChar).Value = tel
            cmdSQLcom.Parameters.Add("@Hayt", Data.SqlDbType.NVarChar).Value = Hayt
            cmdSQLcom.Parameters.Add("@IsSoft", Data.SqlDbType.Bit).Value = isSoft
            cmdSQLcom.Parameters.Add("@isDamaged", Data.SqlDbType.Bit).Value = isDamaged
            If String.IsNullOrEmpty(DamageText) Then
                cmdSQLcom.Parameters.Add("@DamageText", Data.SqlDbType.NVarChar).Value = DBNull.Value
            Else
                cmdSQLcom.Parameters.Add("@DamageText", Data.SqlDbType.NVarChar).Value = DamageText
            End If

            cmdSQLcom.Parameters.Add("@OnlyBattary", Data.SqlDbType.Bit).Value = OnlyBattary
            cmdSQLcom.Parameters.Add("@Tup", Data.SqlDbType.Bit).Value = Tup
            cmdSQLcom.Parameters.Add("@Matit", Data.SqlDbType.Bit).Value = Matit
            cmdSQLcom.Parameters.Add("@Licqavorich", Data.SqlDbType.Bit).Value = Licqavorich
            cmdSQLcom.Parameters.Add("@Martkoc", Data.SqlDbType.Bit).Value = Martkoc

            If TesuchID <= 0 Then
                cmdSQLcom.Parameters.Add("@TesuchID", Data.SqlDbType.SmallInt).Value = DBNull.Value
                cmdSQLcom.Parameters.Add("@Price", Data.SqlDbType.Decimal).Value = DBNull.Value
            Else
                cmdSQLcom.Parameters.Add("@TesuchID", Data.SqlDbType.SmallInt).Value = TesuchID
                cmdSQLcom.Parameters.Add("@Price", Data.SqlDbType.Decimal).Value = Price
            End If

            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddHamadzaynagir
    Friend Sub AddHamadzaynagir(ByVal HVHH As String, ByVal generatedCode As Integer, ByVal addUser As Int16, printHamadzaynagir As Byte)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddHamadzaynagir @ClientHVHH,@GeneratedCode,@AddUser,@PrintHamadzaynagir", connection)
            cmdSQLcom.Parameters.Add("@ClientHVHH", SqlDbType.VarChar).Value = HVHH
            cmdSQLcom.Parameters.Add("@GeneratedCode", SqlDbType.Int).Value = generatedCode
            cmdSQLcom.Parameters.Add("@AddUser", SqlDbType.TinyInt).Value = addUser
            cmdSQLcom.Parameters.Add("@PrintHamadzaynagir", SqlDbType.Bit).Value = printHamadzaynagir
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddProposalGeneralEdited
    Friend Sub AddProposalGeneralEdited(ecr As String, hvhh As String, Client As String, Tesuch As String, Tel As String, addr As String, Supporter As Byte, ID As Integer, ByVal Xndir As String, ByVal haytDate As DateTime, ByVal reg As String, ByVal haytCreator As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddProposalGeneralEdited @ecr,@hvhh,@Client,@Tesuch,@Tel,@addr,@Supporter,@ID,@Xndir,@haytDate,@Reg,@haytCreator", connection)
            cmdSQLcom.Parameters.Add("@ecr", Data.SqlDbType.VarChar).Value = ecr
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@Client", Data.SqlDbType.NVarChar).Value = Client
            cmdSQLcom.Parameters.Add("@Tesuch", Data.SqlDbType.NVarChar).Value = Tesuch
            cmdSQLcom.Parameters.Add("@Tel", Data.SqlDbType.VarChar).Value = Tel
            cmdSQLcom.Parameters.Add("@addr", Data.SqlDbType.NVarChar).Value = addr
            cmdSQLcom.Parameters.Add("@Supporter", Data.SqlDbType.TinyInt).Value = Supporter
            cmdSQLcom.Parameters.Add("@Xndir", Data.SqlDbType.NVarChar).Value = Xndir
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            cmdSQLcom.Parameters.Add("@haytDate", Data.SqlDbType.DateTime).Value = haytDate
            cmdSQLcom.Parameters.Add("@Reg", Data.SqlDbType.NVarChar).Value = reg
            cmdSQLcom.Parameters.Add("@haytCreator", Data.SqlDbType.NVarChar).Value = haytCreator
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddEnterClickForBranch
    Friend Sub AddEnterClickForBranch(ByVal Ecr As String, ByVal userName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Supporter.AddEnterClickForBranch @Ecr,@User", connection)
            cmdSQLcom.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = userName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddEnterClickForCenter
    Friend Sub AddEnterClickForCenter(ByVal Ecr As String, ByVal userName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Supporter.AddEnterClickForCenter @Ecr,@User", connection)
            cmdSQLcom.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = userName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddEnterBranchWorkshop
    Friend Sub AddEnterBranchWorkshop(ByVal Ecr As String, ByVal userName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Supporter.AddEnterBranchWorkshop @Ecr,@User", connection)
            cmdSQLcom.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = userName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddEnterCenterWorkshop
    Friend Sub AddEnterCenterWorkshop(ByVal Ecr As String, ByVal userName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Supporter.AddEnterCenterWorkshop @Ecr,@User", connection)
            cmdSQLcom.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = userName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseBranchWorkshop
    Friend Sub CloseBranchWorkshop(ByVal Ecr As String, ByVal userName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Supporter.CloseBranchWorkshop @Ecr,@User", connection)
            cmdSQLcom.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = userName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseCenterWorkshop
    Friend Sub CloseCenterWorkshop(ByVal Ecr As String, ByVal userName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Supporter.CloseCenterWorkshop @Ecr,@User", connection)
            cmdSQLcom.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = userName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseCenter
    Friend Sub CloseCenter(ByVal Ecr As String, ByVal userName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Supporter.CloseCenter @Ecr,@User", connection)
            cmdSQLcom.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = userName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseBranch
    Friend Sub CloseBranch(ByVal Ecr As String, ByVal userName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Supporter.CloseBranch @Ecr,@User", connection)
            cmdSQLcom.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = userName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertWorkshopEquipment
    Friend Sub InsertWorkshopEquipment(ByVal Ecr As String, ByVal EquipmentID As Short, isCenter As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.InsertWorkshopEquipment @Ecr,@EquipmentID,@isCenter", connection)
            cmdSQLcom.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
            cmdSQLcom.Parameters.Add("@isCenter", SqlDbType.Bit).Value = isCenter
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddNewEcrReplacement
    Friend Sub AddNewEcrReplacement(ByVal hdm1 As Integer, ByVal hdm2 As Integer, ByVal userName As String, ByVal remakeID As Integer, ByVal comment As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddNewEcrReplacement @hdm1,@hdm2,@user,@rid,@comment", connection)
            cmdSQLcom.Parameters.Add("@hdm1", SqlDbType.Int).Value = hdm1
            cmdSQLcom.Parameters.Add("@hdm2", SqlDbType.Int).Value = hdm2
            cmdSQLcom.Parameters.Add("@user", SqlDbType.NVarChar).Value = userName
            cmdSQLcom.Parameters.Add("@rid", SqlDbType.Int).Value = remakeID
            cmdSQLcom.Parameters.Add("@comment", SqlDbType.NVarChar).Value = comment
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertTarif
    Friend Sub InsertTarif(ByVal tarif As String, ByVal d28 As Decimal, ByVal d29 As Decimal, ByVal d30 As Decimal, ByVal d31 As Decimal)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.InsertTarif @tarif,@d28,@d29,@d30,@d31", connection)
            cmdSQLcom.Parameters.Add("@tarif", SqlDbType.NVarChar).Value = tarif
            cmdSQLcom.Parameters.Add("@d28", SqlDbType.Decimal).Value = d28
            cmdSQLcom.Parameters.Add("@d29", SqlDbType.Decimal).Value = d29
            cmdSQLcom.Parameters.Add("@d30", SqlDbType.Decimal).Value = d30
            cmdSQLcom.Parameters.Add("@d31", SqlDbType.Decimal).Value = d31
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'MakeRefuse
    Friend Sub MakeRefuse(ByVal RemakeID As Integer, ByVal UserID As Short, ByVal Reason As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.MakeRefuse @RemakeID,@UserID,@Reason", connection)
            cmdSQLcom.Parameters.Add("@RemakeID", Data.SqlDbType.Int).Value = RemakeID
            cmdSQLcom.Parameters.Add("@UserID", Data.SqlDbType.SmallInt).Value = UserID
            cmdSQLcom.Parameters.Add("@Reason", Data.SqlDbType.NVarChar).Value = Reason
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'MakeCustomInvoiceByClient
    Friend Sub MakeCustomInvoiceByClient(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.MakeCustomInvoiceByClient @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'MakeCustomInvoiceBySuporter
    Friend Sub MakeCustomInvoiceBySuporter(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.MakeCustomInvoiceBySuporter @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddMissedTarif
    Friend Sub AddMissedTarif(ByVal hvhh As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC poak.AddMissedTarif @hvhh", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.NVarChar).Value = hvhh
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

#End Region

#Region "Insert Data 2"

    'CreateRemakeInvoiceWithNDS
    Friend Sub CreateRemakeInvoiceWithNDS(ByVal ClientID As Integer, ByVal ecrID As Integer, ByVal RemakeID As Integer, ByVal ClientCompanyName As String, ByVal ClientHVHH As String, ByVal MatakararDate As Date)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.CreateRemakeInvoiceWithNDS @ClientID,@ecrID,@RemakeID,@ClientCompanyName,@ClientHVHH,@MatakararDate", connection)
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            cmdSQLcom.Parameters.Add("@ecrID", Data.SqlDbType.Int).Value = ecrID
            cmdSQLcom.Parameters.Add("@RemakeID", Data.SqlDbType.Int).Value = RemakeID
            cmdSQLcom.Parameters.Add("@ClientCompanyName", Data.SqlDbType.NVarChar).Value = ClientCompanyName
            cmdSQLcom.Parameters.Add("@ClientHVHH", Data.SqlDbType.VarChar).Value = ClientHVHH
            cmdSQLcom.Parameters.Add("@MatakararDate", Data.SqlDbType.Date).Value = MatakararDate
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CreateRemakeInvoiceTama
    Friend Sub CreateRemakeInvoiceTama(ByVal ClientID As Integer, ByVal ecrID As Integer, ByVal RemakeID As Integer, ByVal ClientCompanyName As String, ByVal ClientHVHH As String, ByVal MatakararDate As Date)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.CreateRemakeInvoiceTama @ClientID,@ecrID,@RemakeID,@ClientCompanyName,@ClientHVHH,@MatakararDate", connection)
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            cmdSQLcom.Parameters.Add("@ecrID", Data.SqlDbType.Int).Value = ecrID
            cmdSQLcom.Parameters.Add("@RemakeID", Data.SqlDbType.Int).Value = RemakeID
            cmdSQLcom.Parameters.Add("@ClientCompanyName", Data.SqlDbType.NVarChar).Value = ClientCompanyName
            cmdSQLcom.Parameters.Add("@ClientHVHH", Data.SqlDbType.VarChar).Value = ClientHVHH
            cmdSQLcom.Parameters.Add("@MatakararDate", Data.SqlDbType.Date).Value = MatakararDate
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CreateRemakeInvoiceWithNoNDS
    Friend Sub CreateRemakeInvoiceWithNoNDS(ByVal ClientID As Integer, ByVal ecrID As Integer, ByVal RemakeID As Integer, ByVal ClientCompanyName As String, ByVal ClientHVHH As String, ByVal MatakararDate As Date)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.CreateRemakeInvoiceWithNoNDS @ClientID,@ecrID,@RemakeID,@ClientCompanyName,@ClientHVHH,@MatakararDate", connection)
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            cmdSQLcom.Parameters.Add("@ecrID", Data.SqlDbType.Int).Value = ecrID
            cmdSQLcom.Parameters.Add("@RemakeID", Data.SqlDbType.Int).Value = RemakeID
            cmdSQLcom.Parameters.Add("@ClientCompanyName", Data.SqlDbType.NVarChar).Value = ClientCompanyName
            cmdSQLcom.Parameters.Add("@ClientHVHH", Data.SqlDbType.VarChar).Value = ClientHVHH
            cmdSQLcom.Parameters.Add("@MatakararDate", Data.SqlDbType.Date).Value = MatakararDate
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertContractDissolve
    Friend Sub InsertContractDissolve(ByVal hvhh As String, ByVal supporter As String, D As Date)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertContractDissolve @hvhh,@supporter,@UserID", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@supporter", Data.SqlDbType.NVarChar).Value = supporter
            cmdSQLcom.Parameters.Add("@UserID", Data.SqlDbType.SmallInt).Value = iUser.UserID
            cmdSQLcom.Parameters.Add("@D", Data.SqlDbType.Date).Value = D
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'TransferEquipmentToLocal
    Friend Sub TransferEquipmentToLocal(ByVal shtrikhcode As String, ByVal supporterID As Byte)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.TransferEquipmentToLocal @shtrikhcode, @supporterID", connection)
            cmdSQLcom.Parameters.Add("@shtrikhcode", Data.SqlDbType.Char).Value = shtrikhcode
            cmdSQLcom.Parameters.Add("@supporterID", Data.SqlDbType.TinyInt).Value = supporterID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'WorkshopEquipmentSell
    Friend Sub WorkshopEquipmentSell(ByVal shtrikhcode As String, ByVal ecr As String, isRemote As Boolean, isCenter As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.WorkshopEquipmentSell @ShtrikhCode,@ECR,@isRemote,@isCenter", connection)
            cmdSQLcom.Parameters.Add("@ShtrikhCode", Data.SqlDbType.Char).Value = shtrikhcode
            cmdSQLcom.Parameters.Add("@ECR", Data.SqlDbType.VarChar).Value = ecr
            cmdSQLcom.Parameters.Add("@isRemote", Data.SqlDbType.Bit).Value = isRemote
            cmdSQLcom.Parameters.Add("@isCenter", Data.SqlDbType.Bit).Value = isCenter
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddNewGprsSerial
    Friend Sub AddNewGprsSerial(ByVal Serial As String, ByVal d As Date)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddNewGprsSerial @Serial,@D", connection)
            cmdSQLcom.Parameters.Add("@Serial", Data.SqlDbType.VarChar).Value = Serial
            cmdSQLcom.Parameters.Add("@D", Data.SqlDbType.Date).Value = d
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertHaytSMS
    Friend Sub InsertHaytSMS(ByVal RemakeID As Integer, ByVal hvhh As String, ByVal ClientID As Integer, ByVal ecr As String, ByVal EcrID As Integer,
                             ByVal SupporterID As Byte, ByVal message As String, ByVal tel As String, ByVal ActionUser As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertHaytSMS @RemakeID,@hvhh,@ClientID,@ecr,@EcrID,@SupporterID,@message,@tel,@ActionUser", connection)
            cmdSQLcom.Parameters.Add("@RemakeID", Data.SqlDbType.Int).Value = RemakeID
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            cmdSQLcom.Parameters.Add("@ecr", Data.SqlDbType.VarChar).Value = ecr
            cmdSQLcom.Parameters.Add("@EcrID", Data.SqlDbType.Int).Value = EcrID
            cmdSQLcom.Parameters.Add("@SupporterID", Data.SqlDbType.TinyInt).Value = SupporterID
            cmdSQLcom.Parameters.Add("@message", Data.SqlDbType.NVarChar).Value = message
            cmdSQLcom.Parameters.Add("@tel", Data.SqlDbType.VarChar).Value = tel
            cmdSQLcom.Parameters.Add("@ActionUser", Data.SqlDbType.NVarChar).Value = ActionUser
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddTesuchEcr
    Friend Sub AddTesuchEcr(ByVal TesuchID As Short, ByVal Ecr As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.AddTesuchEcr @TesuchID,@Ecr", connection)
            cmdSQLcom.Parameters.Add("@TesuchID", Data.SqlDbType.SmallInt).Value = TesuchID
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = Ecr
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ReturnTesuchEcr
    Friend Sub ReturnTesuchEcr(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.ReturnTesuchEcr @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

#End Region

#Region "Delete Data"

    'Delete Tesuch Info
    Friend Sub DeleteTesuch(ByVal recID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Tesuch.DeleteTesuch @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = recID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Delete Tesuch Region Info
    Friend Sub DeleteTesuchRegionInfo(ByVal recID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Tesuch.DeleteTesuchRegionInfo @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = recID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Delete Region
    Friend Sub DeleteRegion(ByVal recID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteRegion @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = recID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Delete Contract
    Friend Sub DeleteContract(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteContract @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Delete Address
    Friend Sub DeleteAddress(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteAddress @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Delete Object Type
    Friend Sub DeleteObjectType(ByVal ID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteObjectType @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Delete THT
    Friend Sub DeleteTHT(ByVal ID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteTHT @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Delete DeleteEcrShipping
    Friend Sub DeleteEcrShipping(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteEcrShipping @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Delete DeleteInRoadEcrShipping
    Friend Sub DeleteInRoadEcrShipping(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteInRoadEcrShipping @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeletePayment
    Friend Sub DeletePayment(ByVal ID As Integer, ByVal UserName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.DeletePayment @id,@name", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = ID
            cmdSQLcom.Parameters.Add("@name", Data.SqlDbType.NVarChar).Value = UserName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteContractCount
    Friend Sub DeleteContractCount(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteContractCount @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteEquipment
    Friend Sub DeleteEquipment(ByVal id As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.DeleteEquipment @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteTesuchInfo
    Friend Sub DeleteTesuchInfo(ByVal id As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Tesuch.DeleteTesuchInfo @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeletePremium
    Friend Sub DeletePremium(ByVal id As Integer, ByVal UserID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeletePremium @id,@UserID", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            cmdSQLcom.Parameters.Add("@UserID", Data.SqlDbType.SmallInt).Value = UserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteExcludedHVHH
    Friend Sub DeleteExcludedHVHH(ByVal id As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DeleteExcludedHVHH @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteWorkshopEquipment2
    Friend Sub DeleteWorkshopEquipment2(ByVal ShtrikhCode As String, isRemote As Boolean, Remake2 As Integer, IsCenter As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.DeleteWorkshopEquipment2 @ShtrikhCode,@isRemote,@Remake2,@IsCenter", connection)
            cmdSQLcom.Parameters.Add("@ShtrikhCode", Data.SqlDbType.Char).Value = ShtrikhCode
            cmdSQLcom.Parameters.Add("@isRemote", Data.SqlDbType.Bit).Value = isRemote
            cmdSQLcom.Parameters.Add("@Remake2", Data.SqlDbType.Int).Value = Remake2
            cmdSQLcom.Parameters.Add("@IsCenter", Data.SqlDbType.Bit).Value = IsCenter
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteWorkshopEquipment
    Friend Sub DeleteWorkshopEquipment(ByVal id As Integer, Remake2 As Integer, IsCenter As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.DeleteWorkshopEquipment @id,@Remake2,@IsCenter", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            cmdSQLcom.Parameters.Add("@Remake2", Data.SqlDbType.Int).Value = Remake2
            cmdSQLcom.Parameters.Add("@IsCenter", Data.SqlDbType.Bit).Value = IsCenter
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteTarif
    Friend Sub DeleteTarif(ByVal id As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.DeleteTarif @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CancelCustomSellByClient
    Friend Sub CancelCustomSellByClient(ByVal id As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.CancelCustomSellByClient @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeletePrepareMail
    Friend Sub DeletePrepareMail(ByVal id As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC mailing.DeletePrepareMail @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteDifTarif
    Friend Sub DeleteDifTarif(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC poak.DeleteDifTarif @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

#End Region

#Region "Update Data"

    'Update Tesuch
    Friend Sub UpdateTesuchInfo(ByVal TesuchName As String, ByVal tesuchStatus As Boolean, ByVal tesuchMail As String, ByVal tesuchTel As String, ByVal id As Short)

        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.UpdateTesuch @TesuchName,@tesuchStatus,@tesuchMail,@tesuchTel,@id", connection)
            cmdSQLcom.Parameters.Add("@TesuchName", Data.SqlDbType.NVarChar).Value = TesuchName
            cmdSQLcom.Parameters.Add("@tesuchStatus", Data.SqlDbType.Bit).Value = tesuchStatus
            If String.IsNullOrEmpty(tesuchMail) Then
                cmdSQLcom.Parameters.Add("@tesuchMail", Data.SqlDbType.NVarChar).Value = DBNull.Value
            Else
                cmdSQLcom.Parameters.Add("@tesuchMail", Data.SqlDbType.NVarChar).Value = tesuchMail
            End If
            If String.IsNullOrEmpty(tesuchTel) Then
                cmdSQLcom.Parameters.Add("@tesuchTel", Data.SqlDbType.VarChar).Value = DBNull.Value
            Else
                cmdSQLcom.Parameters.Add("@tesuchTel", Data.SqlDbType.VarChar).Value = tesuchTel
            End If
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Update Tesuch Info
    Friend Sub UpdateTesuchRegionInfo(ByVal TesuchID As Short, ByVal RegionID As Short, ByVal TesuchInfoID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.UpdateTesuchRegionInfo @TesuchID,@RegionID,@TesuchInfoID", connection)
            cmdSQLcom.Parameters.Add("@TesuchID", Data.SqlDbType.SmallInt).Value = TesuchID
            cmdSQLcom.Parameters.Add("@RegionID", Data.SqlDbType.SmallInt).Value = RegionID
            cmdSQLcom.Parameters.Add("@TesuchInfoID", Data.SqlDbType.SmallInt).Value = TesuchInfoID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Update Region
    Friend Sub UpdateRegionInfo(ByVal regionName As String, ByVal id As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateRegion @regionName,@id", connection)
            cmdSQLcom.Parameters.Add("@regionName", Data.SqlDbType.NVarChar).Value = regionName
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Update Tarajamket
    Friend Sub UpdateTarajamket(ByVal id As Short, tarajamket As String, equipmentId As Integer, months As Byte, price As Decimal, isActive As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.UpdateTarajamket @id, @equipmentId, @price, @months, @isActive, @name", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = id
            cmdSQLcom.Parameters.Add("@name", Data.SqlDbType.NVarChar).Value = tarajamket
            cmdSQLcom.Parameters.Add("@equipmentId", Data.SqlDbType.Int).Value = equipmentId
            cmdSQLcom.Parameters.Add("@months", Data.SqlDbType.TinyInt).Value = months
            cmdSQLcom.Parameters.Add("@price", Data.SqlDbType.Decimal).Value = price
            cmdSQLcom.Parameters.Add("@isActive", Data.SqlDbType.Bit).Value = isActive
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Update Contract
    Friend Sub UpdateContract(ByVal strContract As String, ByVal ContractID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateContract @strContract,@ContractID", connection)
            cmdSQLcom.Parameters.Add("@strContract", Data.SqlDbType.NVarChar).Value = strContract
            cmdSQLcom.Parameters.Add("@ContractID", Data.SqlDbType.Int).Value = ContractID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Update Address
    Friend Sub UpdateAddress(ByVal strAddress As String, ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateAddress @strAddress,@ID", connection)
            cmdSQLcom.Parameters.Add("@strAddress", Data.SqlDbType.NVarChar).Value = strAddress
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Update Object Type
    Friend Sub UpdateObjectType(ByVal strVal As String, ByVal ID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateObjectType @strVal,@ID", connection)
            cmdSQLcom.Parameters.Add("@strVal", Data.SqlDbType.NVarChar).Value = strVal
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.SmallInt).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Update THT
    Friend Sub UpdateTHT(ByVal tht As String, ByVal ID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateTHT @tht,@id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = ID
            cmdSQLcom.Parameters.Add("@tht", Data.SqlDbType.NVarChar).Value = tht
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Update CloseEcrShipping
    Friend Sub CloseEcrShipping(ByVal id As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.CloseEcrShipping @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateClient
    Friend Sub UpdateClient(ByVal ClientID As Integer, ByVal hvhh As String, ByVal contract As String, ByVal company As String, ByVal director As String, ByVal irAddress As String, ByVal araqAddress As String,
                            ByVal tht As Short, ByVal tarif As Short, ByVal region As Short, ByVal supporter As Byte, ByVal tel As String, ByVal comment As String, ByVal hraj As Boolean,
                            ByVal notSupp As Boolean, ByVal nds As Boolean, ByVal zeronds As Boolean, checked As Boolean?)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateClient @ClientID,@hvhh,@contract,@company,@director,@irAddress,@araqAddress,@tht,@tarif,@region,@supporter,@tel,@comment,@hraj,@notSupp,@nds,@zeronds,@checked", connection)
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@contract", Data.SqlDbType.NVarChar).Value = contract
            cmdSQLcom.Parameters.Add("@company", Data.SqlDbType.NVarChar).Value = company
            cmdSQLcom.Parameters.Add("@director", Data.SqlDbType.NVarChar).Value = director
            cmdSQLcom.Parameters.Add("@irAddress", Data.SqlDbType.NVarChar).Value = irAddress
            cmdSQLcom.Parameters.Add("@araqAddress", Data.SqlDbType.NVarChar).Value = araqAddress
            cmdSQLcom.Parameters.Add("@tht", Data.SqlDbType.SmallInt).Value = tht
            cmdSQLcom.Parameters.Add("@tarif", Data.SqlDbType.SmallInt).Value = tarif
            cmdSQLcom.Parameters.Add("@region", Data.SqlDbType.SmallInt).Value = region
            cmdSQLcom.Parameters.Add("@supporter", Data.SqlDbType.TinyInt).Value = supporter
            cmdSQLcom.Parameters.Add("@tel", Data.SqlDbType.VarChar).Value = tel
            If String.IsNullOrEmpty(comment) Then cmdSQLcom.Parameters.Add("@comment", Data.SqlDbType.NVarChar).Value = DBNull.Value Else cmdSQLcom.Parameters.Add("@comment", Data.SqlDbType.NVarChar).Value = comment
            cmdSQLcom.Parameters.Add("@hraj", Data.SqlDbType.Bit).Value = hraj
            cmdSQLcom.Parameters.Add("@notSupp", Data.SqlDbType.Bit).Value = notSupp
            cmdSQLcom.Parameters.Add("@nds", Data.SqlDbType.Bit).Value = nds
            cmdSQLcom.Parameters.Add("@zeronds", Data.SqlDbType.Bit).Value = zeronds
            If IsNothing(checked) Then
                cmdSQLcom.Parameters.Add("@checked", DBNull.Value)
            Else
                cmdSQLcom.Parameters.Add("@checked", Data.SqlDbType.Bit).Value = checked.Value
            End If
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Update UpdatePayment
    Friend Sub UpdatePayment(ByVal Payment As Decimal, ByVal UserName As String, ByVal PaymentID As Integer, ByVal PayDate As DateTime)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.UpdatePayment @Payment,@UserName,@PaymentID,@PayDate", connection)
            cmdSQLcom.Parameters.Add("@Payment", Data.SqlDbType.Decimal).Value = Payment
            cmdSQLcom.Parameters.Add("@UserName", Data.SqlDbType.NVarChar).Value = UserName
            cmdSQLcom.Parameters.Add("@PaymentID", Data.SqlDbType.Int).Value = PaymentID
            cmdSQLcom.Parameters.Add("@PayDate", Data.SqlDbType.DateTime).Value = PayDate
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateEcr
    Friend Sub UpdateEcr(ByVal ecr As String, ByVal hvhh As String, ByVal mgh As String, ByVal contDate As Date, ByVal gAddress As String, ByVal gprs As String,
                         ByVal sStatus As Byte, ByVal sRegion As Short, ByVal oType As String, ByVal Tel As String, ByVal tesuch As Short, ByVal isNds As Boolean,
                         ByVal isPosTerminal As Boolean, ByVal isInvoice As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateEcr @ecr,@hvhh,@mgh,@contDate,@gAddress,@gprs,@sStatus,@sRegion,@oType,@Tel,@tesuch,@isNds,@isPosTerminal,@isInvoice", connection)
            cmdSQLcom.Parameters.Add("@ecr", Data.SqlDbType.VarChar).Value = ecr
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@mgh", Data.SqlDbType.VarChar).Value = mgh
            cmdSQLcom.Parameters.Add("@contDate", Data.SqlDbType.Date).Value = contDate
            cmdSQLcom.Parameters.Add("@gAddress", Data.SqlDbType.NVarChar).Value = gAddress
            cmdSQLcom.Parameters.Add("@gprs", Data.SqlDbType.VarChar).Value = gprs
            cmdSQLcom.Parameters.Add("@sStatus", Data.SqlDbType.TinyInt).Value = sStatus
            cmdSQLcom.Parameters.Add("@sRegion", Data.SqlDbType.SmallInt).Value = sRegion
            cmdSQLcom.Parameters.Add("@oType", Data.SqlDbType.NVarChar).Value = oType
            cmdSQLcom.Parameters.Add("@Tel", Data.SqlDbType.VarChar).Value = Tel
            cmdSQLcom.Parameters.Add("@tesuch", Data.SqlDbType.SmallInt).Value = tesuch
            cmdSQLcom.Parameters.Add("@isNds", Data.SqlDbType.Bit).Value = isNds
            cmdSQLcom.Parameters.Add("@isPosTerminal", Data.SqlDbType.Bit).Value = isPosTerminal
            cmdSQLcom.Parameters.Add("@isInvoice", Data.SqlDbType.Bit).Value = isInvoice
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ReRegisterEcr
    Friend Sub ReRegisterEcr(ByVal ecr As String, ByVal hvhh As String, ByVal mgh As String, ByVal contDate As Date, ByVal gAddress As String, ByVal gprs As String,
                         ByVal sStatus As Byte, ByVal sRegion As Short, ByVal oType As String, ByVal Tel As String, ByVal tesuch As Short, ByVal isNds As Boolean,
                         ByVal isPosTerminal As Boolean, ByVal isInvoice As Boolean, Optional ByVal checked As Boolean? = Nothing)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ReRegisterEcr @ecr,@hvhh,@mgh,@contDate,@gAddress,@gprs,@sStatus,@sRegion,@oType,@Tel,@tesuch,@isNds,@isPosTerminal,@isInvoice,@checked", connection)
            cmdSQLcom.Parameters.Add("@ecr", Data.SqlDbType.VarChar).Value = ecr
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@mgh", Data.SqlDbType.VarChar).Value = mgh
            cmdSQLcom.Parameters.Add("@contDate", Data.SqlDbType.Date).Value = contDate
            cmdSQLcom.Parameters.Add("@gAddress", Data.SqlDbType.NVarChar).Value = gAddress
            cmdSQLcom.Parameters.Add("@gprs", Data.SqlDbType.VarChar).Value = gprs
            cmdSQLcom.Parameters.Add("@sStatus", Data.SqlDbType.TinyInt).Value = sStatus
            cmdSQLcom.Parameters.Add("@sRegion", Data.SqlDbType.SmallInt).Value = sRegion
            cmdSQLcom.Parameters.Add("@oType", Data.SqlDbType.NVarChar).Value = oType
            cmdSQLcom.Parameters.Add("@Tel", Data.SqlDbType.VarChar).Value = Tel
            cmdSQLcom.Parameters.Add("@tesuch", Data.SqlDbType.SmallInt).Value = tesuch
            cmdSQLcom.Parameters.Add("@isNds", Data.SqlDbType.Bit).Value = isNds
            cmdSQLcom.Parameters.Add("@isPosTerminal", Data.SqlDbType.Bit).Value = isPosTerminal
            cmdSQLcom.Parameters.Add("@isInvoice", Data.SqlDbType.Bit).Value = isInvoice
            If IsNothing(checked) Then
                cmdSQLcom.Parameters.Add("@checked", DBNull.Value)
            Else
                cmdSQLcom.Parameters.Add("@checked", Data.SqlDbType.Bit).Value = checked.Value
            End If
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'Update ChangeContractCount
    Friend Sub ChangeContractCount(ByVal id As Integer, ByVal iCount As Short, ByVal ClientID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ChangeContractCount @id,@iCount,@ClientID", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            cmdSQLcom.Parameters.Add("@iCount", Data.SqlDbType.SmallInt).Value = iCount
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SetContractCountPrintReturneDate
    Friend Sub SetContractCountPrintReturneDate(ByVal id As Integer, ByVal UserName As String, ByVal D As Date)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.SetContractCountPrintReturneDate @id,@U,@D", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            cmdSQLcom.Parameters.Add("@U", Data.SqlDbType.NVarChar).Value = UserName
            cmdSQLcom.Parameters.Add("@D", Data.SqlDbType.Date).Value = D
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateBlockGprsHVHHEcr
    Friend Sub UpdateBlockGprsHVHHEcr(ByVal DTgphvhhecr As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.UpdateBlockGprsHVHHEcr", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@DTgphvhhecr", SqlDbType.Structured).Value = DTgphvhhecr
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'EnableBlockedGPRS
    Friend Sub EnableBlockedGPRS(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.EnableBlockedGPRS", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'EnableBlockedGPRS2
    Friend Sub EnableBlockedGPRS2(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.EnableBlockedGPRS2", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub
    'EnableBlockedGPRS3
    Friend Sub EnableBlockedGPRS3(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.EnableBlockedGPRS3", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub


    'BlockGprsByEcr
    Friend Sub BlockGprsByEcr(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.BlockGprsByEcr", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'BlockGprsByEcr2
    Friend Sub BlockGprsByEcr2(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.BlockGprsByEcr2", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'BlockGprsByEcr3
    Friend Sub BlockGprsByEcr3(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.BlockGprsByEcr3", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateSIMByHvhhWindow
    Friend Sub UpdateSIMByHvhhWindow(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.UpdateSIMByHvhhWindow", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateAccseptPayment
    Friend Sub UpdateAccseptPayment(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.UpdateAccseptPayment @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SendEmail
    Friend Sub SendEmail(ByVal id As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Mailing.SendEmail @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateEquipment
    Friend Sub UpdateEquipment(ByVal Equipment As String, ByVal id As Short, ByVal cansel As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.UpdateEquipment @Equipment,@ID,@cansel", connection)
            cmdSQLcom.Parameters.Add("@Equipment", Data.SqlDbType.NVarChar).Value = Equipment
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.SmallInt).Value = id
            cmdSQLcom.Parameters.Add("@cansel", Data.SqlDbType.Bit).Value = cansel
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateEquipment2
    Friend Sub UpdateEquipment2(ByVal Equipment As String, ByVal id As Short, ByVal cansel As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.UpdateEquipment2 @Equipment,@ID,@cansel", connection)
            cmdSQLcom.Parameters.Add("@Equipment", Data.SqlDbType.NVarChar).Value = Equipment
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.SmallInt).Value = id
            cmdSQLcom.Parameters.Add("@cansel", Data.SqlDbType.Bit).Value = cansel
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateReRegInvoice
    Friend Sub UpdateReRegInvoice(ByVal id As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.UpdateReRegInvoice @id", connection)
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.SmallInt).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ChangeRemakeProposal
    Friend Sub ChangeRemakeProposal(ByVal ecr As String, ByVal Proposal As String, ByVal isSoftware As Boolean, ByVal userID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ChangeRemakeProposal @ecr,@Proposal,@isSoftware,@userID", connection)
            cmdSQLcom.Parameters.Add("@ecr", Data.SqlDbType.VarChar).Value = ecr
            cmdSQLcom.Parameters.Add("@Proposal", Data.SqlDbType.NVarChar).Value = Proposal
            cmdSQLcom.Parameters.Add("@isSoftware", Data.SqlDbType.Bit).Value = isSoftware
            cmdSQLcom.Parameters.Add("@userID", Data.SqlDbType.SmallInt).Value = userID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ReturnEcr
    Friend Sub ReturnEcr(ByVal u As String, ByVal id As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ReturnEcr @u,@id", connection)
            cmdSQLcom.Parameters.Add("@u", Data.SqlDbType.NVarChar).Value = u
            cmdSQLcom.Parameters.Add("@id", Data.SqlDbType.Int).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ExistsTesuchRemake
    Friend Function ExistsTesuchRemake(ByVal remontId As Integer) As Boolean
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT TesuchID FROM  tesuch.TesuchRemakeDetails WHERE RemakeID = " + remontId.ToString
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt.Rows.Count > 0
    End Function

    'UpdateTarif
    Friend Sub UpdateTarif(ByVal tarif As String, ByVal d28 As Decimal, ByVal d29 As Decimal, ByVal d30 As Decimal, ByVal d31 As Decimal, ByVal tarifID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.UpdateTarif @tarif,@d28,@d29,@d30,@d31,@tarifID", connection)
            cmdSQLcom.Parameters.Add("@tarif", SqlDbType.NVarChar).Value = tarif
            cmdSQLcom.Parameters.Add("@d28", SqlDbType.Decimal).Value = d28
            cmdSQLcom.Parameters.Add("@d29", SqlDbType.Decimal).Value = d29
            cmdSQLcom.Parameters.Add("@d30", SqlDbType.Decimal).Value = d30
            cmdSQLcom.Parameters.Add("@d31", SqlDbType.Decimal).Value = d31
            cmdSQLcom.Parameters.Add("@tarifID", SqlDbType.SmallInt).Value = tarifID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SetRemakeProposale
    Friend Sub SetRemakeProposale(ByVal RemakeID As Integer, ByVal comm As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.SetRemakeProposale @RemakeID,@comm", connection)
            cmdSQLcom.Parameters.Add("@RemakeID", Data.SqlDbType.Int).Value = RemakeID
            If String.IsNullOrEmpty(comm) Then
                cmdSQLcom.Parameters.Add("@comm", Data.SqlDbType.NVarChar).Value = DBNull.Value
            Else
                cmdSQLcom.Parameters.Add("@comm", Data.SqlDbType.NVarChar).Value = comm
            End If
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseRemakeHayt
    Friend Sub CloseRemakeHayt(ByVal RemakeID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.CloseRemakeHayt @RemakeID", connection)
            cmdSQLcom.Parameters.Add("@RemakeID", Data.SqlDbType.Int).Value = RemakeID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseRemakeHayt2
    Friend Sub CloseRemakeHayt2(ByVal RemakeID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.CloseRemakeHayt2 @RemakeID", connection)
            cmdSQLcom.Parameters.Add("@RemakeID", Data.SqlDbType.Int).Value = RemakeID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ReturnContractDissolve
    Friend Sub ReturnContractDissolve(ByVal ID As Integer, ByVal D As Date)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ReturnContractDissolve @ID,@D,@ReturnUserID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            cmdSQLcom.Parameters.Add("@D", Data.SqlDbType.Date).Value = D
            cmdSQLcom.Parameters.Add("@ReturnUserID", Data.SqlDbType.SmallInt).Value = iUser.UserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ReturnContractTarif
    Friend Sub ReturnContractTarif(ByVal ID As Integer, ByVal D As Date)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ReturnContractTarif @ID,@D,@ReturnUserID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            cmdSQLcom.Parameters.Add("@D", Data.SqlDbType.Date).Value = D
            cmdSQLcom.Parameters.Add("@ReturnUserID", Data.SqlDbType.SmallInt).Value = iUser.UserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ChangeRegionByTesuch
    Friend Sub ChangeRegionByTesuch(ByVal old_tesuchID As Short, ByVal tesuchID As Short, ByVal regionID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.ChangeRegionByTesuch @old_tesuchID,@tesuchID,@regionID", connection)
            cmdSQLcom.Parameters.Add("@old_tesuchID", Data.SqlDbType.SmallInt).Value = old_tesuchID
            cmdSQLcom.Parameters.Add("@tesuchID", Data.SqlDbType.SmallInt).Value = tesuchID
            cmdSQLcom.Parameters.Add("@regionID", Data.SqlDbType.SmallInt).Value = regionID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ChangeEcrGprs
    Friend Sub ChangeEcrGprs(ByVal OldGPRSSerial As String, ByVal NewGPRSSerial As String, ByVal UserName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ChangeEcrGprs @OldGPRSSerial,@NewGPRSSerial,@UserName", connection)
            cmdSQLcom.Parameters.Add("@OldGPRSSerial", Data.SqlDbType.VarChar).Value = OldGPRSSerial
            cmdSQLcom.Parameters.Add("@NewGPRSSerial", Data.SqlDbType.VarChar).Value = NewGPRSSerial
            cmdSQLcom.Parameters.Add("@UserName", Data.SqlDbType.NVarChar).Value = UserName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CheckRemakePropIsSold
    Friend Sub CheckRemakePropIsSold(ByVal hvhh As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.CheckRemakePropIsSold @hvhh", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.NVarChar).Value = hvhh
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SetRemakePropSold
    Friend Sub SetRemakePropSold(ByVal hvhh As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.SetRemakePropSold @hvhh", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.NVarChar).Value = hvhh
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SetRemakePropSoldByPropID
    Friend Sub SetRemakePropSoldByPropID(ByVal ID As Integer, Optional serials As String = "", Optional payType As String = "")
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.SetRemakePropSoldByPropID @ID,@serials,@payType", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            cmdSQLcom.Parameters.Add("@serials", Data.SqlDbType.NVarChar).Value = serials
            cmdSQLcom.Parameters.Add("@payType", Data.SqlDbType.NVarChar).Value = payType
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SetRemakePropNotSold
    Friend Sub SetRemakePropNotSold(ByVal hvhh As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.SetRemakePropNotSold @hvhh", connection)
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.NVarChar).Value = hvhh
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub
#End Region

#Region "Auto Complete"

    'hvhh
    Friend Function AutoCompleteClientList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.AutoCompleteClientList"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'Contract
    Friend Function AutoCompleteContract() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.AutoCompleteContract"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    'Irav Address
    Friend Function AutoCompleteIravAddress() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.AutoCompleteIravAddress"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    'hvhh
    Friend Function AutoCompleteHvhh() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.AutoCompleteHvhh"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    'Passport/ID card
    Friend Function AutoCompleteHvhhFiz() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.AutoCompleteHvhhFiz"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    'gprs
    Friend Function AutoCompleteGPRS() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.AutoCompleteGPRS"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    'ObjectType
    Friend Function AutoCompleteObjectType() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.AutoCompleteObjectType"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'AutoCompleteEcr
    Friend Function AutoCompleteEcr() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.AutoCompleteEcr"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Bulk Insert"

    'BulkInsert
    Friend Sub BulkInsert(ByVal dt As DataTable, ByVal TableName As String)
        Using destinationConnection As SqlConnection = New SqlConnection(SQLString)
            destinationConnection.Open()
            Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(destinationConnection)
                bulkCopy.DestinationTableName = TableName
                Try
                    bulkCopy.WriteToServer(dt)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
                End Try
            End Using
        End Using
    End Sub

#End Region

End Class