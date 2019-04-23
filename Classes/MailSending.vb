Imports System.Net
Imports System.IO

Public Class MailSending

    'Send Mail
    Friend Function sendMail(id As String) As Boolean
        Try
            Dim strURL As String = String.Format("http://datatech.am/sm.php?id=" & id)

            Dim request As WebRequest = WebRequest.Create(strURL)
            Dim response As WebResponse = request.GetResponse()
            Dim reader As StreamReader = New StreamReader(response.GetResponseStream())
            Dim str As String = reader.ReadToEnd

            If InStr(str, "Executed") > 0 Then Return True Else Return False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
            Return False
        End Try
    End Function

End Class