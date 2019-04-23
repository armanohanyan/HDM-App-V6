Imports MySql.Data.MySqlClient
Imports MySql.Data.Types

Public Class MySQLDB

    'MySQL Connection
    Private mySqlConnectionString As String = "server=192.168.11.8;user id=softuser;password=s0$tP@ssW0rD;persistsecurityinfo=False;database=softdb;Character Set=utf8;"

    'Inser MySql
    Friend Function insertIntoMySql(Տեսուչ As String, Փոստ As String, Հաղորդագրություն As String, Կոդ As String) As Boolean
        Try
            Dim mc As New MySqlConnection
            mc.ConnectionString = mySqlConnectionString
            Dim da As MySqlDataAdapter = New MySqlDataAdapter()
            Dim cmd As MySqlCommand

            cmd = New MySqlCommand("INSERT INTO tesuch_mailing (id,mail,message,tesuch) VALUES(@id,@mail,@message,@tesuch)", mc)

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = Կոդ
            cmd.Parameters.Add("@mail", MySqlDbType.VarChar).Value = Փոստ
            cmd.Parameters.Add("@message", MySqlDbType.Text).Value = Հաղորդագրություն
            cmd.Parameters.Add("@tesuch", MySqlDbType.VarChar).Value = Տեսուչ

            mc.Open()
            cmd.ExecuteNonQuery()
            mc.Close()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Return False
        End Try
    End Function


End Class