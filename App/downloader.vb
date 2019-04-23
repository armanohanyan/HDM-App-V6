Imports System.Net

Public Class downloader

    Friend Property isOK As Boolean = True

#Region "Disable Close Button"

    Private Const CP_NOCLOSE_BUTTON As Integer = &H200

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property

#End Region

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        isOK = False
        Me.Close()
    End Sub
    Private Sub downloader_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Threading.Thread.Sleep(1000)
            My.Application.DoEvents()

            Dim sFileName As String = My.Application.Info.DirectoryPath & "\UpdateSoft2.exe"
            Dim strFileName As String = "UpdateSoft2.exe"

            Dim client As New WebClient()
            Dim b() As Byte = client.DownloadData("http://192.168.11.8/updatesoft/ecrv6.dat")
            My.Application.DoEvents()

            My.Computer.FileSystem.WriteAllBytes("UpdateSoft2.exe", b, False)

            If IO.File.Exists(sFileName) Then
                IO.File.Delete(sFileName)
            End If

            My.Application.DoEvents()

            Threading.Thread.Sleep(1000)
            My.Computer.FileSystem.WriteAllBytes(sFileName, b, False)
            Threading.Thread.Sleep(1000)

            My.Application.DoEvents()
            Dim psi As New ProcessStartInfo
            psi.WorkingDirectory = My.Application.Info.DirectoryPath
            psi.Arguments = "-Update"
            psi.FileName = strFileName
            psi.WindowStyle = ProcessWindowStyle.Normal
            Process.Start(psi)

            End

        Catch ex As ExceptionClass
            btnCancel.PerformClick()
        End Try
    End Sub

End Class