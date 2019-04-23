Imports System.Data.SqlClient

Partial Public Class DB

#Region "Select Only"

    'GetOpenActivateHayt
    Friend Function GetOpenActivateHayt(sDate As DateTime, eDate As DateTime) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If sDate <> DateTime.MinValue Then
                    cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                    cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                Else
                    cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = DBNull.Value
                    cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = DBNull.Value
                End If
                cmd.CommandText = "EXEC Client.GetOpenActivateHayt @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetOpenGeneralHayt
    Friend Function GetOpenGeneralHayt(sDate As DateTime, eDate As DateTime) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                If sDate <> DateTime.MinValue Then
                    cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                    cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                Else
                    cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = DBNull.Value
                    cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = DBNull.Value
                End If
                cmd.CommandText = "EXEC Client.GetOpenGeneralHayt @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporterWareHouse
    Friend Function GetSupporterWareHouse() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 0 ՀՀ,N'Բոլորը' Կազմակերպություն UNION ALL SELECT ՀՀ,Կազմակերպություն FROM Supporter.GetSupporter() WHERE ՀՀ<>5 UNION ALL SELECT 5 ՀՀ,N'Շուկա' Կազմակերպություն"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporterForSelect
    Friend Function GetSupporterForSelect() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 0 ՀՀ,N'Բոլորը' Կազմակերպություն UNION ALL SELECT ՀՀ,Կազմակերպություն FROM Supporter.GetSupporter()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporterForSelect2
    Friend Function GetSupporterForSelect2() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Կազմակերպություն FROM Supporter.GetSupporter()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSupporterForSelect3
    Friend Function GetSupporterForSelect3() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT ՀՀ,Կազմակերպություն FROM Supporter.GetSupporter() UNION SELECT 0,N'Բոլորը'"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEquipmentForFilter
    Friend Function GetEquipmentForFilter() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 0 ՀՀ,N'Բոլորը' Սարքավորում UNION ALL SELECT EquipmentID ՀՀ,EquipmentName Սարքավորում FROM warehouse.GetEquipmentList() WHERE EquipmentCode IS NOT NULL"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEquipmentForFilterNyut
    Friend Function GetEquipmentForFilterNyut() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 0 ՀՀ,N'Բոլորը' Սարքավորում UNION ALL SELECT EquipmentID ՀՀ,EquipmentName Սարքավորում FROM warehouse.GetEquipmentList() WHERE EquipmentCode IS NULL"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetECrCountStatistics
    Friend Function GetECrCountStatistics() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetECrCountStatistics()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepGetNoNDSAndZero
    Friend Function RepGetNoNDSAndZero() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepGetNoNDSAndZero()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepNotSuppClient
    Friend Function RepNotSuppClient() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepNotSuppClient()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepNotSuppClient2
    Friend Function RepNotSuppClient2() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepNotSuppClient2()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepNostSupClientHistory
    Friend Function RepNostSupClientHistory() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepNostSupClientHistory()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepPayInvoiceTotalStats
    Friend Function RepPayInvoiceTotalStats() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.RepPayInvoiceTotalStats()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepPayInvoiceTotalStatsBySupporter
    Friend Function RepPayInvoiceTotalStatsBySupporter(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.RepPayInvoiceTotalStatsBySupporter(@SupporterID)"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetWarehouseList
    Friend Function GetWarehouseList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 0 ՀՀ, N'Բոլորը' Կազմակերպություն UNION ALL SELECT * FROM Supporter.GetWarehouseList() WHERE ՀՀ<>5"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetWarehouseList2
    Friend Function GetWarehouseList2() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Supporter.GetWarehouseList() WHERE ՀՀ<>5"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSoldInvoiceForDelete
    Friend Function GetSoldInvoiceForDelete(ByVal SupporterID As Byte, ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@HVHH", SqlDbType.VarChar).Value = hvhh
                cmd.CommandText = "EXEC Payment.GetSoldInvoiceForDelete @SupporterID,@HVHH"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSoldInvoiceForDeleteInner
    Friend Function GetSoldInvoiceForDeleteInner(ByVal SupporterID As Byte, ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@HVHH", SqlDbType.VarChar).Value = hvhh
                cmd.CommandText = "EXEC Payment.GetSoldInvoiceForDeleteInner @SupporterID,@HVHH"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetDetailsForChangeCustomSell
    Friend Function GetDetailsForChangeCustomSell(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT * FROM Payment.GetDetailsForChangeCustomSell(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetDetailsForChangeCustomSellSupporter
    Friend Function GetDetailsForChangeCustomSellSupporter(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT * FROM Payment.GetDetailsForChangeCustomSellSupporter(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ListOfDays
    Friend Function ListOfDays() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM poak.ListOfDays() ORDER BY Ամսաթիվ DESC"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetUpcomingTarifInfo
    Friend Function GetUpcomingTarifInfo(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                cmd.CommandText = "EXEC Payment.GetUpcomingTarifInfo @hvhh"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ListOfCurrentTarif
    Friend Function ListOfCurrentTarif() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.ListOfCurrentTarif"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'TarifHistory
    Friend Function TarifHistory() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.TarifHistory()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetPoskLastTarifList
    Friend Function GetPoskLastTarifList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM poak.GetPoskLastTarifList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAllDiffTariff
    Friend Function GetAllDiffTariff() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM poak.GetAllDiffTariff()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetMissedTariff
    Friend Function GetMissedTariff() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM poak.GetMissedTariff()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'TarifHistory2
    Friend Function TarifHistory2(ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.TarifHistory2(@ClientID)"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'TarifUpcoming
    Friend Function TarifUpcoming() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.TarifUpcoming()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetNotPrintedInvoice
    Friend Function GetNotPrintedInvoice(Y As Short, M As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = m
                cmd.CommandText = "EXEC Payment.GetNotPrintedInvoice @Y,@M"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetReturnedInvoice
    Friend Function GetReturnedInvoice(Y As Short, M As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.CommandText = "SELECT * FROM Payment.GetReturnedInvoice(@Y,@M)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetReturnedInvoice2
    Friend Function GetReturnedInvoice2() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.GetReturnedInvoice2()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetNotReturnedInvoice
    Friend Function GetNotReturnedInvoice(Y As Short, M As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.CommandText = "SELECT * FROM Payment.GetNotReturnedInvoice(@Y,@M)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetNotReturnedInvoiceALL
    Friend Function GetNotReturnedInvoiceALL() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.GetNotReturnedInvoiceALL()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'InvInnerInvoices
    Friend Function InvInnerInvoices(SupporterID As Byte, sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Payment.InvInnerInvoices(@SupporterID,@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'InvRemakeInvoices
    Friend Function InvRemakeInvoices(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT * FROM Payment.InvRemakeInvoices(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'InvSellInvoices
    Friend Function InvSellInvoices(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT * FROM Payment.InvSellInvoices(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInnerInvInfo
    Friend Function GetInnerInvInfo(ByVal InvoiceID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
                cmd.CommandText = "SELECT * FROM Payment.GetInnerInvInfo(@InvoiceID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeInvInfo
    Friend Function GetRemakeInvInfo(ByVal InvoiceID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
                cmd.CommandText = "SELECT * FROM Payment.GetRemakeInvInfo(@InvoiceID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSellInvInfo
    Friend Function GetSellInvInfo(ByVal InvoiceID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
                cmd.CommandText = "SELECT * FROM Payment.GetSellInvInfo(@InvoiceID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInnerInvDetails
    Friend Function GetInnerInvDetails(ByVal InvoiceID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
                cmd.CommandText = "SELECT * FROM Payment.GetInnerInvDetails(@InvoiceID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInnerInvDetailsNoNDS
    Friend Function GetInnerInvDetailsNoNDS(ByVal InvoiceID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
                cmd.CommandText = "SELECT * FROM Payment.GetInnerInvDetailsNoNDS(@InvoiceID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeInvDetails
    Friend Function GetRemakeInvDetails(ByVal InvoiceID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
                cmd.CommandText = "SELECT * FROM Payment.GetRemakeInvDetails(@InvoiceID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeInvDetailsNoNDS
    Friend Function GetRemakeInvDetailsNoNDS(ByVal InvoiceID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
                cmd.CommandText = "SELECT * FROM Payment.GetRemakeInvDetailsNoNDS(@InvoiceID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSellInvDetails
    Friend Function GetSellInvDetails(ByVal InvoiceID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
                cmd.CommandText = "SELECT * FROM Payment.GetSellInvDetails(@InvoiceID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSellInvDetailsNoNDS
    Friend Function GetSellInvDetailsNoNDS(ByVal InvoiceID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
                cmd.CommandText = "SELECT * FROM Payment.GetSellInvDetailsNoNDS(@InvoiceID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInvoiceForDelete
    Friend Function GetInvoiceForDelete(Y As Short, M As Byte, SupporterID As Byte, hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                cmd.CommandText = "EXEC Payment.GetInvoiceForDelete @Y,@M,@SupporterID,@hvhh"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInvoiceForUpdate
    Friend Function GetInvoiceForUpdate(Y As Short, M As Byte, SupporterID As Byte, hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                cmd.CommandText = "EXEC Payment.GetInvoiceForUpdate @Y,@M,@SupporterID,@hvhh"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTarifForInvoiceByID
    Friend Function GetTarifForInvoiceByID(ByVal TarifID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@TarifID", SqlDbType.SmallInt).Value = TarifID
                cmd.CommandText = "SELECT * FROM Payment.GetTarifForInvoiceByID(@TarifID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetLastDayForCustomInvoice
    Friend Function GetLastDayForCustomInvoice(hvhh As String, ForYear As Short, ForMonth As Byte, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                cmd.Parameters.Add("@ForYear", SqlDbType.SmallInt).Value = ForYear
                cmd.Parameters.Add("@ForMonth", SqlDbType.TinyInt).Value = ForMonth
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "EXEC Payment.GetLastDayForCustomInvoice @hvhh,@ForYear,@ForMonth,@SupporterID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Select Only 2"

    'InvoiceBacvacqForECR
    Friend Function InvoiceBacvacqForECR(Y As Short, M As Byte, HVHH As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.InvoiceBacvacqForECR(@Y,@M,@HVHH)"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@HVHH", SqlDbType.VarChar).Value = HVHH
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'SupportInvoiceHvhhList
    Friend Function SupportInvoiceHvhhList(Y As Short, M As Byte, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Payment.SupportInvoiceHvhhList @Y,@M,@SupporterID"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'InvoiceXMLReadyListNDS
    Friend Function InvoiceXMLReadyListNDS(Y As Short, M As Byte, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.InvoiceXMLReadyListNDS(@Y,@M,@SupporterID)"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'InvoiceXMLReadyListNDS2
    Friend Function InvoiceXMLReadyListNDS2(Y As Short, M As Byte, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.InvoiceXMLReadyListNDS2(@Y,@M,@SupporterID)"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'InvoiceXMLReadyListNDS3
    Friend Function InvoiceXMLReadyListNDS3(Y As Short, M As Byte, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.InvoiceXMLReadyListNDS3(@Y,@M,@SupporterID)"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'InvoiceXMLReadyListNDS4
    Friend Function InvoiceXMLReadyListNDS4(Y As Short, M As Byte, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.InvoiceXMLReadyListNDS4(@Y,@M,@SupporterID)"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'LateInvoice
    Friend Function LateInvoice(Y As Short, M As Byte, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Payment.LateInvoice(@Y,@M,@SupporterID)"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetUserGroupList
    Friend Function GetUserGroupList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Users.GetUserGroupList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetUsersList
    Friend Function GetUsersList() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Users.GetUsersList()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetUserInfo
    Friend Function GetUserInfo(ByVal UserID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Users.GetUserInfo(@UserID)"
                cmd.Parameters.Add("@UserID", SqlDbType.SmallInt).Value = UserID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeSMS
    Friend Function GetRemakeSMS() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetRemakeSMS()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RemakeEquipmentDetails
    Friend Function RemakeEquipmentDetails(ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RemakeEquipmentDetails(@ECR)"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepMnacordWarAllEquipAll
    Friend Function RepMnacordWarAllEquipAll(ByVal sDate As Date, ByVal eDate As Date, ByVal IsEquipment As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.RepMnacordWarAllEquipAll @sDate,@eDate,@IsEquipment"
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.Parameters.Add("@IsEquipment", SqlDbType.Bit).Value = IsEquipment
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepMnacordWarAllEquipUniq
    Friend Function RepMnacordWarAllEquipUniq(ByVal sDate As Date, ByVal eDate As Date, ByVal EquipmentID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.RepMnacordWarAllEquipUniq @sDate,@eDate,@EquipmentID"
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepMnacordWarUniqueEquipAll
    Friend Function RepMnacordWarUniqueEquipAll(ByVal sDate As Date, ByVal eDate As Date, ByVal SupporterID As Byte, ByVal IsEquipment As Boolean) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.RepMnacordWarUniqueEquipAll @sDate,@eDate,@SupporterID,@IsEquipment"
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@IsEquipment", SqlDbType.Bit).Value = IsEquipment
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepMnacordWarUniqueEquipUnique
    Friend Function RepMnacordWarUniqueEquipUnique(ByVal sDate As Date, ByVal eDate As Date, ByVal SupporterID As Byte, ByVal EquipmentID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.RepMnacordWarUniqueEquipUnique @sDate,@eDate,@SupporterID,@EquipmentID"
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GPRSStatusDisabled
    Friend Function GPRSStatusDisabled() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Operator.GPRSStatusDisabled()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GPRSStatusEnabled
    Friend Function GPRSStatusEnabled() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Operator.GPRSStatusEnabled()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GPRSStatusAll
    Friend Function GPRSStatusAll() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Operator.GPRSStatusAll()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrFunctional
    Friend Function GetEcrFunctional(ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetEcrFunctional(@ecr)"
                cmd.Parameters.Add("@ecr", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeProblem
    Friend Function GetRemakeProblem() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetRemakeProblem()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'UsersForRemakeMessage
    Friend Function UsersForRemakeMessage(ExUserID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Users.UsersForRemakeMessage() WHERE UserID <> @ExUserID ORDER BY LoginName"
                cmd.Parameters.Add("@ExUserID", SqlDbType.SmallInt).Value = ExUserID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Select Only 3"

    'GetTelCellLogEvents
    Friend Function GetTelCellLogEvents() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Supporter.GetTelCellLogEvents()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetEcrTesuchResult
    Friend Function GetEcrTesuchResult() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetEcrTesuchResult()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTelCellPayment
    Friend Function GetTelCellPayment() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Supporter.GetTelCellPayment()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetOrangeServiceEventLog
    Friend Function GetOrangeServiceEventLog() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Supporter.GetOrangeServiceEventLog()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'HaytSubInfo
    Friend Function HaytSubInfo(ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.HaytSubInfo @ECR"
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RemakeNotPayed1
    Friend Function RemakeNotPayed1(startDate As Date, endDate As Date, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 500
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.RemakeNotPayed1 @startDate,@endDate,@SupporterID"
                cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate
                cmd.Parameters.Add("@endDate", SqlDbType.Date).Value = endDate
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RemakeNotPayed3
    Friend Function RemakeNotPayed3(startDate As Date, endDate As Date, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 500
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.RemakeNotPayed3 @startDate,@endDate,@SupporterID"
                cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate
                cmd.Parameters.Add("@endDate", SqlDbType.Date).Value = endDate
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'HTSClientInfoForPayment
    Friend Function HTSClientInfoForPayment(htsCode As Integer, SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM hts.HTSClientInfoForPayment(@htsCode,@SupporterID)"
                cmd.Parameters.Add("@htsCode", SqlDbType.Int).Value = htsCode
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ShtrikhMnacordBySarq
    Friend Function ShtrikhMnacordBySarq(SupporterID As Byte, EquipmentID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.ShtrikhMnacordBySarq @SupporterID,@EquipmentID"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ShtrikhMnacordBySarq2
    Friend Function ShtrikhMnacordBySarq2(SupporterID As Byte, EquipmentID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC warehouse.ShtrikhMnacordBySarq2 @SupporterID,@EquipmentID"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetUsersPermissionsByGroupU
    Friend Function GetUsersPermissionsByGroupU(ByVal GroupID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@GroupID", SqlDbType.SmallInt).Value = GroupID
                cmd.CommandText = "SELECT * FROM Users.GetUsersPermissionsByGroupU(@GroupID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetUsersPermissionsByGroupW
    Friend Function GetUsersPermissionsByGroupW(ByVal GroupID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@GroupID", SqlDbType.SmallInt).Value = GroupID
                cmd.CommandText = "SELECT * FROM Users.GetUsersPermissionsByGroupW(@GroupID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetNotServedClients
    Friend Function GetNotServedClients() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetNotServedClients()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTelNumbersByHvhh
    Friend Function GetTelNumbersByHvhh(ByVal hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.GetTelNumbersByHvhh @hvhh"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CallCenterSMSRep
    Friend Function CallCenterSMSRep(ByVal ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.CallCenterSMSRep(@ClientID)"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetBankEnter
    Friend Function GetBankEnter(SupporterID As Byte, sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                'cmd.CommandText = "SELECT * FROM Payment.GetBankEnter(@SupporterID,@sDate,@eDate)"
                cmd.CommandText = "EXEC Payment.GetBankEnterX @SupporterID,@sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'LoadTelCellData
    Friend Function LoadTelCellData(d1 As Date, d2 As Date, c As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@D1", SqlDbType.Date).Value = d1
                cmd.Parameters.Add("@D2", SqlDbType.Date).Value = d2
                cmd.Parameters.Add("@C", SqlDbType.TinyInt).Value = c
                cmd.CommandText = "SELECT * FROM Client.LoadTelCellData(@D1,@D2,@C)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetHDMShtrikhMnacord
    Friend Function GetHDMShtrikhMnacord() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GetHDMShtrikhMnacord()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetHDMShtrikhSold
    Friend Function GetHDMShtrikhSold() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GetHDMShtrikhSold()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRegionForPDF
    Friend Function GetRegionForPDF() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetRegionForPDF()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetInference
    Friend Function GetInference(RemakeID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                cmd.CommandText = "SELECT * FROM Client.GetInference(@RemakeID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSetInnerAkt
    Friend Function GetSetInnerAkt(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "EXEC Client.GetSetInnerAkt @SupporterID"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetExcludeHvhhForPdf
    Friend Function GetExcludeHvhhForPdf(SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                cmd.CommandText = "SELECT * FROM Client.GetExcludeHvhhForPdf(@SupporterID)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'SrahOK
    Friend Function SrahOK(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "EXEC Client.SrahOK @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepSrahOK1
    Friend Function RepSrahOK1() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepSrahOK1()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepSrahOK2
    Friend Function RepSrahOK2() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepSrahOK2()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepSrahOK3
    Friend Function RepSrahOK3() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepSrahOK3()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'SrahNotOK
    Friend Function SrahNotOK(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "EXEC Client.SrahNotOK @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepSrahNotOK1
    Friend Function RepSrahNotOK1() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepSrahNotOK1()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepSrahNotOK2
    Friend Function RepSrahNotOK2() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepSrahNotOK2()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepSrahNotOK3
    Friend Function RepSrahNotOK3() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepSrahNotOK3()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'WarhowseOK
    Friend Function WarhowseOK(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "EXEC Client.WarhowseOK @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepWarhowseOK1
    Friend Function RepWarhowseOK1(sDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.CommandText = "SELECT * FROM Client.RepWarhowseOK1(@sDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepWarhowseOK2
    Friend Function RepWarhowseOK2(sDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.CommandText = "SELECT * FROM Client.RepWarhowseOK2(@sDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepWarhowseOK3
    Friend Function RepWarhowseOK3(sDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.CommandText = "SELECT * FROM Client.RepWarhowseOK3(@sDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'WarhowseExists
    Friend Function WarhowseExists(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "EXEC Client.WarhowseExists @sDate,@eDate"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepWarhowseExists1
    Friend Function RepWarhowseExists1() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepWarhowseExists1()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepWarhowseExists2
    Friend Function RepWarhowseExists2() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepWarhowseExists2()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepWarhowseExists3
    Friend Function RepWarhowseExists3() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RepWarhowseExists3()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Select Only 4"

    'RepTimeBrWorkToCenter
    Friend Function RepTimeBrWorkToCenter(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Client.RepTimeBrWorkToCenter(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepTimeCenterToBranch
    Friend Function RepTimeCenterToBranch(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Client.RepTimeCenterToBranch(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepTimeWorkShopToCenter
    Friend Function RepTimeWorkShopToCenter(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Client.RepTimeWorkShopToCenter(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepTimeCenterToWorkshop
    Friend Function RepTimeCenterToWorkshop(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Client.RepTimeCenterToWorkshop(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepTimeApproved
    Friend Function RepTimeApproved(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Client.RepTimeApproved(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepTimeRemakeDuration
    Friend Function RepTimeRemakeDuration(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Client.RepTimeRemakeDuration(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepTimeRemakeWorkShopDuration
    Friend Function RepTimeRemakeWorkShopDuration(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM Client.RepTimeRemakeWorkShopDuration(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GprsAkt
    Friend Function GprsAkt(ByVal Serial As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Serial", SqlDbType.VarChar).Value = Serial
                cmd.CommandText = "SELECT * FROM Client.GprsAkt(@Serial)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'ViewJob
    Friend Function ViewJob() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Users.ViewJob"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'PartqBySupporter
    Friend Function PartqBySupporter(ByVal d As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@BaseDateX", SqlDbType.Date).Value = d
                cmd.CommandText = "Payment.PartqBySupporter"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'PartqBySupporter3
    Friend Function PartqBySupporter3(ByVal d As Date, ByVal DB As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@BaseDateX", SqlDbType.Date).Value = d
                cmd.Parameters.Add("@DB", SqlDbType.TinyInt).Value = DB
                cmd.CommandText = "Payment.PartqBySupporter3"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GerBankInfo
    Friend Function GerBankInfo(ByVal SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Supporter.GerBankInfo(@SupporterID)"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetWorkshopTime
    Friend Function GetWorkshopTime() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetWorkshopTime()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'UniCallCenterByEcr
    Friend Function UniCallCenterByEcr(OperatorID As Byte, Ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.UniCallCenterByEcr @OperatorID,@Ecr"
                cmd.Parameters.Add("@OperatorID", SqlDbType.TinyInt).Value = OperatorID
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'UniCallCenterByHvhh
    Friend Function UniCallCenterByHvhh(OperatorID As Byte, hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.UniCallCenterByHvhh @OperatorID,@hvhh"
                cmd.Parameters.Add("@OperatorID", SqlDbType.TinyInt).Value = OperatorID
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'UniCallCenterPaxHVHH Existence
    Friend Function UniCallCenterPaxHVHH(hvhh As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.UniCallCenterPaxHVHH @hvhh"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'CallCenterPayDetails
    Friend Function CallCenterPayDetails(ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.CallCenterPayDetails(@ClientID)"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RepCallCenterVisits
    Friend Function RepCallCenterVisits(ClientID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC tesuch.RepCallCenterVisits @ClientID"
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'IssueEcrToTesuch
    Friend Function IssueEcrToTesuch(ByVal EcrID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.IssueEcrToTesuch (@EcrID)"
                cmd.Parameters.Add("@EcrID", SqlDbType.Int).Value = EcrID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'IssueEcrToTesuch2
    Friend Function IssueEcrToTesuch2(ByVal Ecr As String) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.IssueEcrToTesuch2 (@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'AllClientPercent
    Friend Function AllClientPercent(ByVal SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC Client.AllClientPercent @SupporterID"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RemakeMessageClosedByUser
    Friend Function RemakeMessageClosedByUser(ByVal UserID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RemakeMessageClosedByUser(@UserID)"
                cmd.Parameters.Add("@UserID", SqlDbType.SmallInt).Value = UserID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RemakeMessageOpened
    Friend Function RemakeMessageOpened(ByVal UserID As Short) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RemakeMessageOpened(@UserID)"
                cmd.Parameters.Add("@UserID", SqlDbType.SmallInt).Value = UserID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'RemakeMessageByID
    Friend Function RemakeMessageByID(ByVal ID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.RemakeMessageByID(@ID)"
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'QueueProposalSMSAll
    Friend Function QueueProposalSMSAll() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM mobile.QueueProposalSMSAll()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'QueueProposalSMSByDate
    Friend Function QueueProposalSMSByDate(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM mobile.QueueProposalSMSByDate(@sDate,@eDate)"
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

    'GetFilteredStatus
    Friend Function GetFilteredStatus() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetFilteredStatus()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetFilteredStatus2
    Friend Function GetFilteredStatus2() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetFilteredStatus2()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetOtherStatusEcr
    Friend Function GetOtherStatusEcr() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetOtherStatusEcr()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'StatusHistory
    Friend Function StatusHistory() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.StatusHistory()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetRemakeMessageAnswere
    Friend Function GetRemakeMessageAnswere(ByVal SendUserID As Integer) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Client.GetRemakeMessageAnswere(@SendUserID)"
                cmd.Parameters.Add("@SendUserID", SqlDbType.Int).Value = SendUserID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetTesuchRemakeDetailsRep
    Friend Function GetTesuchRemakeDetailsRep(sDate As Date, eDate As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
                cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
                cmd.CommandText = "SELECT * FROM tesuch.GetTesuchRemakeDetailsRep(@sDate,@eDate)"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetAdditionalPrice
    Friend Function GetAdditionalPrice(ByVal SupporterID As Byte) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GetAdditionalPrice(@SupporterID)"
                cmd.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetSellEquipment
    Friend Function GetSellEquipment() As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM warehouse.GetSellEquipment()"
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Select Only Scalar"

    'GetInvoiceDayByInterval
    Friend Function GetInvoiceDayByInterval(ByVal Y As Short, ByVal M As Byte) As Byte
        Dim bt As Byte
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Payment.GetInvoiceDayByInterval(@Y,@M)"
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                bt = cmd.ExecuteScalar()
            End Using
        End Using
        Return bt
    End Function

    'GetAppVersion
    Friend Function GetAppVersion() As String
        Dim s As Object
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Users.GetAppVersion()"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GetCustomPriceForRemake
    Friend Function GetCustomPriceForRemake(SoldEquipmentID As Integer, TarifID As Short) As Decimal
        Dim s As Object
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Payment.GetCustomPriceForRemake(@SoldEquipmentID,@TarifID)"
                cmd.Parameters.Add("@SoldEquipmentID", SqlDbType.Int).Value = SoldEquipmentID
                cmd.Parameters.Add("@TarifID", SqlDbType.SmallInt).Value = TarifID
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'CheckHvhhForManualInvoice
    Friend Function CheckHvhhForManualInvoice(hvhh As String, Y As Short, M As Byte) As Boolean
        Dim s As Object
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Payment.CheckHvhhForManualInvoice(@hvhh,@Y,@M)"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                cmd.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
                cmd.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'EquipmentSellChange
    Friend Function EquipmentSellChange(EquipmentID As Short) As Boolean
        Dim bt As Boolean
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT warehouse.EquipmentSellChange(@EquipmentID)"
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                bt = cmd.ExecuteScalar()
            End Using
        End Using
        Return bt
    End Function

    'GetRemakeTarifID
    Friend Function GetRemakeTarifID(RemakeID As Integer) As Short
        Dim s As Short
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Payment.GetRemakeTarifID(@RemakeID)"
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'RemakeIdByEcr
    Friend Function RemakeIdByEcr(ecr As String) As Integer
        Dim s As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ECR", SqlDbType.VarChar).Value = ecr
                cmd.CommandText = "SELECT Client.RemakeIdByEcr(@ECR)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GetCustomTesuchByRegin
    Friend Function GetCustomTesuchByRegin(region As Short) As String
        Dim s As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@RegionID", SqlDbType.SmallInt).Value = region
                cmd.CommandText = "SELECT tesuch.GetCustomTesuchByRegin(@RegionID)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'HdmShtrikhIsLocalTransferDone
    Friend Function HdmShtrikhIsLocalTransferDone(ShtrikhCode As String) As Integer
        Dim s As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.CommandText = "SELECT warehouse.HdmShtrikhIsLocalTransferDone(@ShtrikhCode)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GetEquipmentSellAllow
    Friend Function GetEquipmentSellAllow(EquipmentID As Short) As Boolean
        Dim bt As Boolean
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT warehouse.GetEquipmentSellAllow(@EquipmentID)"
                cmd.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
                bt = cmd.ExecuteScalar()
            End Using
        End Using
        Return bt
    End Function

    'GetEquipNameFromShtrikhCode
    Friend Function GetEquipNameFromShtrikhCode(ShtrikhCode As String) As String
        Dim s As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
                cmd.CommandText = "SELECT warehouse.GetEquipNameFromShtrikhCode(@ShtrikhCode)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'TesuchTel
    Friend Function TesuchTel(Tesuch As String) As String
        Dim s As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Tesuch", SqlDbType.NVarChar).Value = Tesuch
                cmd.CommandText = "SELECT tesuch.TesuchTel(@Tesuch)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'RemakeSrahEcrCur
    Friend Function RemakeSrahEcrCur() As Integer
        Dim s As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.RemakeSrahEcrCur()"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'RemakeSrahEcrOld
    Friend Function RemakeSrahEcrOld() As Integer
        Dim s As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.RemakeSrahEcrOld()"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'RemakeSrahEcrCurBranch
    Friend Function RemakeSrahEcrCurBranch() As Integer
        Dim s As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.RemakeSrahEcrCurBranch()"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'RemakeSrahEcrOldBranch
    Friend Function RemakeSrahEcrOldBranch() As Integer
        Dim s As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.RemakeSrahEcrOldBranch()"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GetClientID
    Friend Function GetClientID(ByVal hvhh As String) As Integer
        Dim s As Integer
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.GetClientID(@hvhh)"
                cmd.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GetFilteredPayment
    Friend Function GetFilteredPayment(ByVal Phrase As String) As String
        Dim s As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Phrase", SqlDbType.VarChar).Value = Phrase
                cmd.CommandText = "SELECT Payment.GetFilteredPayment(@Phrase)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GetRemakeStartTimeByOperator
    Friend Function GetRemakeStartTimeByOperator(ByVal RemakeID As Integer, ByVal OperatorID As Byte) As DateTime
        Dim s As DateTime
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                cmd.Parameters.Add("@OperatorID", SqlDbType.TinyInt).Value = OperatorID
                cmd.CommandText = "SELECT Client.GetRemakeStartTimeByOperator(@RemakeID,@OperatorID)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'CallCenterRepPayment
    Friend Function CallCenterRepPayment(Ecr As String) As Decimal
        Dim s As Decimal
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 5
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.CallCenterRepPayment(@Ecr)"
                cmd.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GetQueueReplaceEcrD
    Friend Function GetQueueReplaceEcrD(ECR As String) As String
        Dim s As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@ECR", SqlDbType.NVarChar).Value = ECR
                cmd.CommandText = "SELECT tesuch.GetQueueReplaceEcrD(@ECR)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GetTesuchSMSPermission
    Friend Function GetTesuchSMSPermission() As Boolean
        Dim b As Boolean = False
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT tesuch.GetTesuchSMSPermission()"
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'GetTesuchRemakeDetails
    Friend Function GetTesuchRemakeDetails(RemakeID As Integer) As String
        Dim s As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                cmd.CommandText = "SELECT tesuch.GetTesuchRemakeDetails(@RemakeID)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GetTesuchNameRemakeDetails
    Friend Function GetTesuchNameRemakeDetails(RemakeID As Integer) As String
        Dim s As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
                cmd.CommandText = "SELECT tesuch.GetTesuchNameRemakeDetails(@RemakeID)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'GBarRemake
    Friend Function GBarRemake() As Boolean
        Dim b As Boolean = False
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.GBarRemake()"
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'GBarRemakeProp
    Friend Function GBarRemakeProp() As Boolean
        Dim b As Boolean = False
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Client.GBarRemakeProp()"
                b = cmd.ExecuteScalar()
            End Using
        End Using
        Return b
    End Function

    'IsEcrPOS
    Friend Function IsEcrPOS(Ecr As String) As String
        Dim s As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@Ecr", SqlDbType.NVarChar).Value = ECR
                cmd.CommandText = "SELECT Client.IsEcrPOS(@Ecr)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'CheckShtrikhBeforeTransferTransfered
    Friend Function CheckShtrikhBeforeTransferTransfered(shtrikhcode As String) As String
        Dim s As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@shtrikhcode", SqlDbType.NVarChar).Value = shtrikhcode
                cmd.CommandText = "SELECT warehouse.CheckShtrikhBeforeTransferTransfered(@shtrikhcode)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

    'CheckShtrikhBeforeTransferForSell
    Friend Function CheckShtrikhBeforeTransferForSell(shtrikhcode As String) As String
        Dim s As String
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 20
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@shtrikhcode", SqlDbType.NVarChar).Value = shtrikhcode
                cmd.CommandText = "SELECT warehouse.CheckShtrikhBeforeTransferForSell(@shtrikhcode)"
                s = cmd.ExecuteScalar()
            End Using
        End Using
        Return s
    End Function

#End Region

#Region "Select Generic"

    'UpdateActivateHaytStatus
    Friend Sub UpdateActivateHaytStatus(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.UpdateActivateHaytStatus", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateGeneralHaytStatus
    Friend Sub UpdateGeneralHaytStatus(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.UpdateGeneralHaytStatus", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseActivateHaytStatus
    Friend Sub CloseActivateHaytStatus(ByVal T As DataTable, ByVal u As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.CloseActivateHaytStatus", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = u
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseActivateHaytStatusAndRefuse
    Friend Sub CloseActivateHaytStatusAndRefuse(ByVal T As DataTable, ByVal u As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.CloseActivateHaytStatusAndRefuse", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = u
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseGeneralHaytStatus
    Friend Sub CloseGeneralHaytStatus(ByVal T As DataTable, ByVal u As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.CloseGeneralHaytStatus", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = u
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseGeneralHaytStatusAndRefuse
    Friend Sub CloseGeneralHaytStatusAndRefuse(ByVal T As DataTable, ByVal u As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.CloseGeneralHaytStatusAndRefuse", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = u
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'PrintedActivateHaytStatus
    Friend Sub PrintedActivateHaytStatus(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.PrintedActivateHaytStatus", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'PrintedGeneralHaytStatus
    Friend Sub PrintedGeneralHaytStatus(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.PrintedGeneralHaytStatus", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ExcelFileToSQLDB
    Friend Function ExcelFileToSQLDB(ByVal T As DataTable, ByVal d As Date) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandTimeout = 500
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "poak.ExcelFileToSQLDB"
                cmd.Parameters.Add("@T", SqlDbType.Structured).Value = T
                cmd.Parameters.Add("@D", SqlDbType.Date).Value = d
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'SetRetInvoiceDate
    Friend Sub SetRetInvoiceDate(ByVal T As DataTable, ByVal D As Date)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Payment.SetRetInvoiceDate", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@T", SqlDbType.Structured).Value = T
            cmdSQLcom.Parameters.Add("@D", SqlDbType.Date).Value = D
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SetRetInvoiceDateCustom
    Friend Sub SetRetInvoiceDateCustom(ByVal D As Date, Y As Short, M As Byte, hvhh As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Payment.SetRetInvoiceDateCustom", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@D", SqlDbType.Date).Value = D
            cmdSQLcom.Parameters.Add("@Y", SqlDbType.SmallInt).Value = Y
            cmdSQLcom.Parameters.Add("@M", SqlDbType.TinyInt).Value = M
            cmdSQLcom.Parameters.Add("@hvhh", SqlDbType.NVarChar).Value = hvhh
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'BulkExcludeHVHH
    Friend Sub BulkExcludeHVHH(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.BulkExcludeHVHH", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@hvhh", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'GetXMLInvoiceList
    Friend Function GetXMLInvoiceList(ByVal invoice_list As DataTable) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Payment.GetXMLInvoiceList"
                cmd.Parameters.Add("@invoice_list", SqlDbType.Structured).Value = invoice_list
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'GetExcelInvoiceList
    Friend Function GetExcelInvoiceList(ByVal invoice_list As DataTable) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Payment.GetExcelInvoiceList"
                cmd.Parameters.Add("@invoice_list", SqlDbType.Structured).Value = invoice_list
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    'DelGprsList
    Friend Sub DelGprsList(ByVal T As DataTable)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Client.DelGprsList", connection)
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@G", SqlDbType.Structured).Value = T
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'GetListOfHvhhForTarif
    Friend Function GetListOfHvhhForTarif(ByVal hvhh As DataTable) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Client.GetListOfHvhhForTarif"
                cmd.Parameters.Add("@T", SqlDbType.Structured).Value = hvhh
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

#End Region

#Region "Update"

    'UpdateProposalActivate
    Friend Sub UpdateProposalActivate(ecr As String, hvhh As String, Client As String, Tesuch As String, Tel As String, addr As String,
                                      Supporter As Byte, ID As Integer, ByVal Appr As String, ByVal haytDate As DateTime, ByVal reg As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateProposalActivate @ecr,@hvhh,@Client,@Tesuch,@Tel,@addr,@Supporter,@ID,@Appr,@haytDate,@Reg", connection)
            cmdSQLcom.Parameters.Add("@ecr", Data.SqlDbType.VarChar).Value = ecr
            cmdSQLcom.Parameters.Add("@hvhh", Data.SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@Client", Data.SqlDbType.NVarChar).Value = Client
            cmdSQLcom.Parameters.Add("@Tesuch", Data.SqlDbType.NVarChar).Value = Tesuch
            cmdSQLcom.Parameters.Add("@Tel", Data.SqlDbType.VarChar).Value = Tel
            cmdSQLcom.Parameters.Add("@addr", Data.SqlDbType.NVarChar).Value = addr
            cmdSQLcom.Parameters.Add("@Supporter", Data.SqlDbType.TinyInt).Value = Supporter
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            cmdSQLcom.Parameters.Add("@Appr", Data.SqlDbType.NVarChar).Value = Appr
            cmdSQLcom.Parameters.Add("@haytDate", Data.SqlDbType.DateTime).Value = haytDate
            cmdSQLcom.Parameters.Add("@Reg", Data.SqlDbType.NVarChar).Value = reg
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateProposalGeneral
    Friend Sub UpdateProposalGeneral(ecr As String, hvhh As String, Client As String, Tesuch As String, Tel As String, addr As String, Supporter As Byte, ID As Integer, ByVal Xndir As String, ByVal haytDate As DateTime, ByVal reg As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateProposalGeneral @ecr,@hvhh,@Client,@Tesuch,@Tel,@addr,@Supporter,@ID,@Xndir,@haytDate,@Reg", connection)
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
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DropCustomSell
    Friend Sub DropCustomSell(InvoiceID As Integer, ClientID As Integer, SupporterID As Byte, SellID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.DropCustomSell @InvoiceID,@ClientID,@SupporterID,@SellID", connection)
            cmdSQLcom.Parameters.Add("@InvoiceID", Data.SqlDbType.Int).Value = InvoiceID
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            cmdSQLcom.Parameters.Add("@SupporterID", Data.SqlDbType.TinyInt).Value = SupporterID
            cmdSQLcom.Parameters.Add("@SellID", Data.SqlDbType.Int).Value = SellID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CreateUpcomingTarif
    Friend Sub CreateUpcomingTarif(ClientID As Integer, TarifID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.CreateUpcomingTarif @ClientID,@TarifID", connection)
            cmdSQLcom.Parameters.Add("@ClientID", Data.SqlDbType.Int).Value = ClientID
            cmdSQLcom.Parameters.Add("@TarifID", Data.SqlDbType.SmallInt).Value = TarifID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SetInvoicePrinted
    Friend Sub SetInvoicePrinted(InvoiceID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.SetInvoicePrinted @InvoiceID", connection)
            cmdSQLcom.Parameters.Add("@InvoiceID", Data.SqlDbType.Int).Value = InvoiceID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteTarifUpcoming
    Friend Sub DeleteTarifUpcoming(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.DeleteTarifUpcoming @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'TruncateExcludeHVHH
    Friend Sub TruncateExcludeHVHH()
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.TruncateExcludeHVHH", connection)
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteSupportInvoice
    Friend Sub DeleteSupportInvoice(User As String, InvoiceID As Integer, ByVal Reason As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.DeleteSupportInvoice @User,@InvoiceID,@Reason", connection)
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = User
            cmdSQLcom.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
            cmdSQLcom.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = Reason
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateSupportInvoiceData
    Friend Sub UpdateSupportInvoiceData(ecrCount As Short, WorkingDays As Short, Price As Decimal, NDS As Decimal, TotalPrice As Decimal, InvoiceID As Integer, User As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.UpdateSupportInvoiceData @ecrCount,@WorkingDays,@Price,@NDS,@TotalPrice,@InvoiceID,@User", connection)
            cmdSQLcom.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
            cmdSQLcom.Parameters.Add("@ecrCount", SqlDbType.SmallInt).Value = ecrCount
            cmdSQLcom.Parameters.Add("@WorkingDays", SqlDbType.SmallInt).Value = WorkingDays
            cmdSQLcom.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price
            cmdSQLcom.Parameters.Add("@NDS", SqlDbType.Decimal).Value = NDS
            cmdSQLcom.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = TotalPrice
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = User
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CreateCustomInvoiceByDay
    Friend Sub CreateCustomInvoiceByDay(hvhh As String, sDate As Date, eDate As Date, SupporterID As Byte, Matakararum As Date, Dursgrum As Date, User As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.CreateCustomInvoiceByDay @hvhh,@sDate,@eDate,@SupporterID,@Matakararum,@Dursgrum,@User", connection)
            cmdSQLcom.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@sDate", SqlDbType.Date).Value = sDate
            cmdSQLcom.Parameters.Add("@eDate", SqlDbType.Date).Value = eDate
            cmdSQLcom.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
            cmdSQLcom.Parameters.Add("@Matakararum", SqlDbType.Date).Value = Matakararum
            cmdSQLcom.Parameters.Add("@Dursgrum", SqlDbType.Date).Value = Dursgrum
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = User
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CreateCustomInvoice
    Friend Sub CreateCustomInvoice(hvhh As String, Y As Short, M As Byte, SupporterID As Byte, Matakararum As Date, Dursgrum As Date, User As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("Payment.CreateCustomInvoice", connection)
            cmdSQLcom.CommandTimeout = 50
            cmdSQLcom.CommandType = CommandType.StoredProcedure
            cmdSQLcom.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@YR", SqlDbType.SmallInt).Value = Y
            cmdSQLcom.Parameters.Add("@MT", SqlDbType.TinyInt).Value = M
            cmdSQLcom.Parameters.Add("@SupporterID", SqlDbType.TinyInt).Value = SupporterID
            cmdSQLcom.Parameters.Add("@Matakararum", SqlDbType.Date).Value = Matakararum
            cmdSQLcom.Parameters.Add("@Dursgrum", SqlDbType.Date).Value = Dursgrum
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = User
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertUserGroup
    Friend Sub InsertUserGroup(Group As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.InsertUserGroup @Group", connection)
            cmdSQLcom.Parameters.Add("@Group", Data.SqlDbType.NVarChar).Value = Group
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteUserGroup
    Friend Sub DeleteUserGroup(id As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.DeleteUserGroup @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.SmallInt).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertUsers
    Friend Sub InsertUsers(LoginName As String, PASS As String, FirstName As String, LastName As String, GroupID As Short, ActiveStatus As Boolean,
                          dbSupporterID As Byte, MustChangePass As Boolean, Comments As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.InsertUsers @LoginName,@PASS,@FirstName,@LastName,@GroupID,@ActiveStatus,@dbSupporterID,@MustChangePass,@Comments", connection)
            cmdSQLcom.Parameters.Add("@LoginName", Data.SqlDbType.NVarChar).Value = LoginName
            cmdSQLcom.Parameters.Add("@PASS", Data.SqlDbType.NVarChar).Value = PASS
            cmdSQLcom.Parameters.Add("@FirstName", Data.SqlDbType.NVarChar).Value = FirstName
            cmdSQLcom.Parameters.Add("@LastName", Data.SqlDbType.NVarChar).Value = LastName
            cmdSQLcom.Parameters.Add("@GroupID", Data.SqlDbType.SmallInt).Value = GroupID
            cmdSQLcom.Parameters.Add("@ActiveStatus", Data.SqlDbType.Bit).Value = ActiveStatus
            cmdSQLcom.Parameters.Add("@dbSupporterID", Data.SqlDbType.TinyInt).Value = dbSupporterID
            cmdSQLcom.Parameters.Add("@MustChangePass", Data.SqlDbType.Bit).Value = MustChangePass
            If Comments = String.Empty Then
                cmdSQLcom.Parameters.Add("@Comments", Data.SqlDbType.NVarChar).Value = DBNull.Value
            Else
                cmdSQLcom.Parameters.Add("@Comments", Data.SqlDbType.NVarChar).Value = Comments
            End If
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ChangeUserInfo
    Friend Sub ChangeUserInfo(GroupID As Short, ActiveStatus As Boolean, dbSupporterID As Byte, UserID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.ChangeUserInfo @GroupID,@ActiveStatus,@dbSupporterID,@UserID", connection)
            cmdSQLcom.Parameters.Add("@GroupID", Data.SqlDbType.SmallInt).Value = GroupID
            cmdSQLcom.Parameters.Add("@ActiveStatus", Data.SqlDbType.Bit).Value = ActiveStatus
            cmdSQLcom.Parameters.Add("@dbSupporterID", Data.SqlDbType.TinyInt).Value = dbSupporterID
            cmdSQLcom.Parameters.Add("@UserID", Data.SqlDbType.SmallInt).Value = UserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteUser
    Friend Sub DeleteUser(id As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.DeleteUser @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.SmallInt).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteTarifSel
    Friend Sub DeleteTarifSel(id As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.DeleteTarifSel @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.SmallInt).Value = id
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateSoldEquipmentPrice
    Friend Sub UpdateSoldEquipmentPrice(SoldEquipmentID As Integer, SalePrice As Decimal)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.UpdateSoldEquipmentPrice @SoldEquipmentID,@SalePrice", connection)
            cmdSQLcom.Parameters.Add("@SoldEquipmentID", Data.SqlDbType.Int).Value = SoldEquipmentID
            cmdSQLcom.Parameters.Add("@SalePrice", Data.SqlDbType.Decimal).Value = SalePrice
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SetEcrFunctional
    Friend Sub SetEcrFunctional(Pos As Boolean, Inv As Boolean, VTQ As Boolean, shrjik As Boolean, ECR As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.SetEcrFunctional @Pos,@Inv,@VTQ,@shrjik,@ECR", connection)
            cmdSQLcom.Parameters.Add("@Pos", Data.SqlDbType.Bit).Value = Pos
            cmdSQLcom.Parameters.Add("@Inv", Data.SqlDbType.Bit).Value = Inv
            cmdSQLcom.Parameters.Add("@VTQ", Data.SqlDbType.Bit).Value = VTQ
            cmdSQLcom.Parameters.Add("@shrjik", Data.SqlDbType.Bit).Value = shrjik
            cmdSQLcom.Parameters.Add("@ECR", Data.SqlDbType.VarChar).Value = ECR
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DropPermissionsU
    Friend Sub DropPermissionsU(ByVal GroupID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.DropPermissionsU @GroupID", connection)
            cmdSQLcom.Parameters.Add("@GroupID", Data.SqlDbType.SmallInt).Value = GroupID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DropPermissionsW
    Friend Sub DropPermissionsW(ByVal GroupID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.DropPermissionsW @GroupID", connection)
            cmdSQLcom.Parameters.Add("@GroupID", Data.SqlDbType.SmallInt).Value = GroupID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertPermissionsU
    Friend Sub InsertPermissionsU(ByVal GroupID As Short, ByVal Allowed As Boolean, ByVal GUID As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.InsertPermissionsU @GroupID,@Allowed,@GUID", connection)
            cmdSQLcom.Parameters.Add("@GroupID", Data.SqlDbType.SmallInt).Value = GroupID
            cmdSQLcom.Parameters.Add("@Allowed", Data.SqlDbType.Bit).Value = Allowed
            cmdSQLcom.Parameters.Add("@GUID", Data.SqlDbType.VarChar).Value = GUID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertPermissionsW
    Friend Sub InsertPermissionsW(ByVal GroupID As Short, ByVal Allowed As Boolean, ByVal GUID As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.InsertPermissionsW @GroupID,@Allowed,@GUID", connection)
            cmdSQLcom.Parameters.Add("@GroupID", Data.SqlDbType.SmallInt).Value = GroupID
            cmdSQLcom.Parameters.Add("@Allowed", Data.SqlDbType.Bit).Value = Allowed
            cmdSQLcom.Parameters.Add("@GUID", Data.SqlDbType.VarChar).Value = GUID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'InsertSMSForREmake
    Friend Sub InsertSMSForREmake(ByVal Ecr As String, ByVal U As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.InsertSMSForREmake @Ecr,@ActionUser", connection)
            cmdSQLcom.Parameters.Add("@Ecr", Data.SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@ActionUser", Data.SqlDbType.NVarChar).Value = U
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'TransferPermisiions
    Friend Sub TransferPermisiions(ByVal tTo As Short, ByVal tFrom As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Users.TransferPermisiions @To,@From", connection)
            cmdSQLcom.Parameters.Add("@To", Data.SqlDbType.SmallInt).Value = tTo
            cmdSQLcom.Parameters.Add("@From", Data.SqlDbType.SmallInt).Value = tFrom
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ChangeStatus
    Friend Sub ChangeStatus(ECR As String, T As String, UserID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ChangeStatus @ECR,@T,@UserID", connection)
            cmdSQLcom.Parameters.Add("@ECR", Data.SqlDbType.NVarChar).Value = ECR
            cmdSQLcom.Parameters.Add("@T", Data.SqlDbType.NChar).Value = T
            cmdSQLcom.Parameters.Add("@UserID", Data.SqlDbType.SmallInt).Value = UserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DropStatus
    Friend Sub DropStatus(ID As Integer, T As String, StatusID As Byte, UserID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.DropStatus @ID,@T,@StatusID,@UserID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            cmdSQLcom.Parameters.Add("@T", Data.SqlDbType.NChar).Value = T
            cmdSQLcom.Parameters.Add("@StatusID", Data.SqlDbType.TinyInt).Value = StatusID
            cmdSQLcom.Parameters.Add("@UserID", Data.SqlDbType.SmallInt).Value = UserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'NewTesuchSMSPermission
    Friend Sub NewTesuchSMSPermission(A As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC tesuch.NewTesuchSMSPermission @A", connection)
            cmdSQLcom.Parameters.Add("@A", Data.SqlDbType.Bit).Value = A
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddGeneralPropAfterClose
    Friend Sub AddGeneralPropAfterClose(ecr As String, Tesuch As String, User As String, Message As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddGeneralPropAfterClose @ecr,@Tesuch,@User,@Message", connection)
            cmdSQLcom.Parameters.Add("@ecr", Data.SqlDbType.VarChar).Value = ecr
            cmdSQLcom.Parameters.Add("@Tesuch", Data.SqlDbType.NVarChar).Value = Tesuch
            cmdSQLcom.Parameters.Add("@User", Data.SqlDbType.NVarChar).Value = User
            cmdSQLcom.Parameters.Add("@Message", Data.SqlDbType.NVarChar).Value = Message
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'NewbBarRemake
    Friend Sub NewbBarRemake(A As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.NewbBarRemake @A", connection)
            cmdSQLcom.Parameters.Add("@A", Data.SqlDbType.Bit).Value = A
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'NewbBarRemakeClientProp
    Friend Sub NewbBarRemakeClientProp(A As Boolean)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.NewbBarRemakeClientProp @A", connection)
            cmdSQLcom.Parameters.Add("@A", Data.SqlDbType.Bit).Value = A
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateRemakeMessage
    Friend Sub UpdateRemakeMessage(ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateRemakeMessage @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", Data.SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'NewAdditionalPrice
    Friend Sub NewAdditionalPrice(SupID As Byte, EquipmentID As Short, TarifID As Short, AddPrice As Decimal)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.NewAdditionalPrice @SupID,@EquipmentID,@TarifID,@AddPrice", connection)
            cmdSQLcom.Parameters.Add("@SupID", Data.SqlDbType.TinyInt).Value = SupID
            cmdSQLcom.Parameters.Add("@EquipmentID", Data.SqlDbType.SmallInt).Value = EquipmentID
            cmdSQLcom.Parameters.Add("@TarifID", Data.SqlDbType.SmallInt).Value = TarifID
            cmdSQLcom.Parameters.Add("@AddPrice", Data.SqlDbType.Decimal).Value = AddPrice
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

#End Region

#Region "Update 2"

    'UpdateTelCellPaymentSetter
    Friend Sub UpdateTelCellPaymentSetter(receipt As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UpdateTelCellPaymentSetter @receipt", connection)
            cmdSQLcom.Parameters.Add("@receipt", SqlDbType.Int).Value = receipt
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'SMSToBranch
    Friend Sub SMSToBranch(Ecr As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.SMSToBranch @Ecr,@User_Name", connection)
            cmdSQLcom.Parameters.Add("@Ecr", SqlDbType.VarChar).Value = Ecr
            cmdSQLcom.Parameters.Add("@User_Name", SqlDbType.NVarChar).Value = iUser.LoginName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UPDATEInference
    Friend Sub UPDATEInference(Inference As String, RemakeID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.UPDATEInference @Inference,@RemakeID", connection)
            cmdSQLcom.Parameters.Add("@Inference", SqlDbType.NVarChar).Value = Inference
            cmdSQLcom.Parameters.Add("@RemakeID", SqlDbType.Int).Value = RemakeID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CheckSellInvoice
    Friend Sub CheckSellInvoice(SellID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.CheckSellInvoice @SellID", connection)
            cmdSQLcom.Parameters.Add("@SellID", SqlDbType.Int).Value = SellID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CheckHSMShtrikhWarehouseItem
    Friend Sub CheckHSMShtrikhWarehouseItem(ShtrikhCode As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.CheckHSMShtrikhWarehouseItem @ShtrikhCode", connection)
            cmdSQLcom.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CheckShtrikhWarehouseItem
    Friend Sub CheckShtrikhWarehouseItem(ShtrikhCode As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.CheckShtrikhWarehouseItem @ShtrikhCode", connection)
            cmdSQLcom.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CheckHSMShtrikhWarehouseItem2
    Friend Sub CheckHSMShtrikhWarehouseItem2(ShtrikhCode As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.CheckHSMShtrikhWarehouseItem2 @ShtrikhCode", connection)
            cmdSQLcom.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CheckShtrikhWarehouseItem2
    Friend Sub CheckShtrikhWarehouseItem2(ShtrikhCode As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.CheckShtrikhWarehouseItem2 @ShtrikhCode", connection)
            cmdSQLcom.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddEquipmentSellAllow
    Friend Sub AddEquipmentSellAllow(EquipmentID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.AddEquipmentSellAllow @EquipmentID", connection)
            cmdSQLcom.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteEquipmentSellAllow
    Friend Sub DeleteEquipmentSellAllow(EquipmentID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.DeleteEquipmentSellAllow @EquipmentID", connection)
            cmdSQLcom.Parameters.Add("@EquipmentID", SqlDbType.SmallInt).Value = EquipmentID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CanSellEquipmentByShtrikhCode
    Friend Sub CanSellEquipmentByShtrikhCode(ShtrikhCode As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.CanSellEquipmentByShtrikhCode @ShtrikhCode", connection)
            cmdSQLcom.Parameters.Add("@ShtrikhCode", SqlDbType.Char).Value = ShtrikhCode
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'AddNewBlockedClient
    Friend Sub AddNewBlockedClient(ByVal hvhh As String, ByVal UserName As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.AddNewBlockedClient @hvhh,@User", connection)
            cmdSQLcom.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = UserName
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ActivateClient
    Friend Sub ActivateClient(ByVal hvhh As String, ByVal User As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.ActivateClient @hvhh,@User", connection)
            cmdSQLcom.Parameters.Add("@hvhh", SqlDbType.VarChar).Value = hvhh
            cmdSQLcom.Parameters.Add("@User", SqlDbType.NVarChar).Value = User
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteGprs
    Friend Sub DeleteGprs(ByVal gprs As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Operator.DeleteGprs @gprs", connection)
            cmdSQLcom.Parameters.Add("@gprs", SqlDbType.VarChar).Value = gprs
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ArchiveGprsStatus
    Friend Sub ArchiveGprsStatus()
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Operator.ArchiveGprsStatus", connection)
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'UpdateInvoiceMDate
    Friend Sub UpdateInvoiceMDate(ByVal InvoiceID As Integer, ByVal MatakararDate As DateTime)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Payment.UpdateInvoiceMDate @InvoiceID,@MatakararDate", connection)
            cmdSQLcom.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID
            cmdSQLcom.Parameters.Add("@MatakararDate", SqlDbType.DateTime).Value = MatakararDate
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ProcpoakToDBForAdding
    Friend Sub ProcpoakToDBForAdding()
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC SubInfo.ProcpoakToDBForAdding", connection)
            cmdSQLcom.CommandTimeout = 2000
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ProcpoakToDBGetReRegistering
    Friend Sub ProcpoakToDBGetReRegistering()
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC SubInfo.ProcpoakToDBGetReRegistering", connection)
            cmdSQLcom.CommandTimeout = 2000
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'btnChangePoakHVHH
    Friend Sub ChangePoakHVHH()
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC SubInfo.ChangePoakHVHH", connection)
            cmdSQLcom.CommandTimeout = 2000
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'ProcpoakToDBMGHChanges
    Friend Sub ProcpoakToDBMGHChanges()
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC SubInfo.ProcpoakToDBMGHChanges", connection)
            cmdSQLcom.CommandTimeout = 2000
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'NewRemakeProblem
    Friend Sub NewRemakeProblem(ByVal Problem As String)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.NewRemakeProblem @Problem", connection)
            cmdSQLcom.Parameters.Add("@Problem", SqlDbType.NVarChar).Value = Problem
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'CloseRemakeMessage
    Friend Sub CloseRemakeMessage(ID As Integer, CloseMessage As String, CloseUserID As Short)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC Client.CloseRemakeMessage @ID,@CloseMessage,@CloseUserID", connection)
            cmdSQLcom.Parameters.Add("@ID", SqlDbType.Int).Value = ID
            cmdSQLcom.Parameters.Add("@CloseMessage", SqlDbType.NVarChar).Value = CloseMessage
            cmdSQLcom.Parameters.Add("@CloseUserID", SqlDbType.SmallInt).Value = CloseUserID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    'DeleteAdditionalPrice
    Friend Sub DeleteAdditionalPrice(ByVal ID As Integer)
        Using connection As New SqlConnection(SQLString)
            Dim cmdSQLcom As New SqlCommand("EXEC warehouse.DeleteAdditionalPrice @ID", connection)
            cmdSQLcom.Parameters.Add("@ID", SqlDbType.Int).Value = ID
            connection.Open()
            cmdSQLcom.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

#End Region

End Class