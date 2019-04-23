Public Class LoginWindow

    'Set Skin
    Private Sub setSkin()
        Try
            Dim AppSkin As String = GetSetting("HDM App", "Properties", "Theme", "Office 2013")
            iSkin = AppSkin
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = iSkin
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    'Close App
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    'Check Version
    Private Function CheckVersion() As Boolean
        Try
            Dim ver As String = iDB.GetAppVersion()
            Dim mainVer As Version = New Version(ver)
            If My.Application.Info.Version.CompareTo(mainVer) = -1 Then
                Dim f As New downloader
                f.ShowDialog()
                Dim b As Boolean = f.isOK
                f.Dispose()
                If b = False Then Return False Else Return True
            Else
                Return True
                Exit Function
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Check App Name
    Private Function CheckAppName() As String
        Dim AppName As String = IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
        Return AppName
    End Function

    'Login
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        btnLogin.Enabled = False
        Try
            'Get Login and Password
            Dim strLogin As String = txtUserName.Text.Trim
            Dim strPassword As String = txtPassword.Text.Trim

            'Check If Info Correct
            If String.IsNullOrEmpty(strLogin) Then Throw New Exception("Օգտանունը գրված չէ")
            If String.IsNullOrEmpty(strPassword) Then Throw New Exception("Գաղտնաբառը գրված չէ")

            'Create New User Class
            If IsNothing(iUser) Then iUser = New CurrentUser
            'Create New DB Class
            If IsNothing(iDB) Then iDB = New DB

            'Encript Password With MD5
            iUser.EncodedPassword = getMd5Hash(strPassword)

            Dim dt As DataTable

            dt = iDB.ConnectToDB(strLogin, iUser.EncodedPassword)

            With iUser
                .FirstName = dt.Rows(0)("FirstName")
                .LastName = dt.Rows(0)("LastName")
                .IsLogedIn = True
                .LoginName = dt.Rows(0)("LoginName")
                .Password = strPassword
                .UserComments = dt.Rows(0)("Comments")
                .UserGroup = dt.Rows(0)("GroupID")
                .UserID = dt.Rows(0)("UserID")
                .MustChangePass = dt.Rows(0)("MustChangePass")
                .PasswordDate = dt.Rows(0)("PasswordDate")
                .DB = dt.Rows(0)("dbSupporterID")
            End With

            'Check App Version
            If CheckVersion() = False Then Throw New Exception("Ծրագրի թարմեցման ժամանակ տեղի է ունեցել սխալ")

            'Chech password Expaire
            Dim passDate As Date = dt.Rows(0)("PasswordDate")
            Dim mustChange As Boolean = dt.Rows(0)("MustChangePass")

            If mustChange = True Then
                Dim dayscount As Integer = DateDiff(DateInterval.Day, passDate, Date.Now)
                If dayscount > 45 Then
                    Dim f As New Change_Password
                    f.ShowDialog()
                    f.Dispose()
                    'Application.Restart()
                    Exit Sub
                ElseIf dayscount > 43 AndAlso dayscount <= 45 Then
                    MsgBox("Ձեր գաղտնաբառի ժամկետը շուտով կավարտվի, հարկավոր է փոխել գաղտնաբառը", MsgBoxStyle.Information, My.Application.Info.Title)
                End If
            End If

            Me.Hide()

            MainWindow.DefaultLookAndFeel1.LookAndFeel.SkinName = iSkin

            MainWindow.Show()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            btnLogin.Enabled = True
        End Try
    End Sub

    'Select Text
    Private Sub txtUserName_Click(sender As Object, e As EventArgs) Handles txtUserName.Click
        txtUserName.SelectionStart = 0
        txtUserName.SelectionLength = txtUserName.Text.Length
    End Sub
    Private Sub txtUserName_GotFocus(sender As Object, e As EventArgs) Handles txtUserName.GotFocus
        txtUserName.SelectionStart = 0
        txtUserName.SelectionLength = txtUserName.Text.Length
    End Sub
    Private Sub txtPassword_Click(sender As Object, e As EventArgs) Handles txtPassword.Click
        txtPassword.SelectionStart = 0
        txtPassword.SelectionLength = txtPassword.Text.Length
    End Sub
    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        txtPassword.SelectionStart = 0
        txtPassword.SelectionLength = txtPassword.Text.Length
    End Sub

    'Load Form
    Private Sub LoginWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error Resume Next

        Call setSkin()

        'Me.Text = CheckAppName()

        'Update
        If My.Application.CommandLineArgs.Count > 0 Then

            For Each argument As String In My.Application.CommandLineArgs

                If argument = "-Update" Then
                    Dim vMatchingProcesses As Process() = Process.GetProcessesByName("ՀԴՄ App")
                    For Each vProc As Process In vMatchingProcesses
                        vProc.Kill()
                    Next
                    System.Threading.Thread.Sleep(500)

                    If IO.File.Exists("ՀԴՄ App.exe") Then IO.File.Delete("ՀԴՄ App.exe")
                    System.Threading.Thread.Sleep(2000)
                    IO.File.Copy("UpdateSoft2.exe", "ՀԴՄ App.exe")

                    System.Threading.Thread.Sleep(500)

                    Dim psi As New ProcessStartInfo
                    psi.WorkingDirectory = My.Application.Info.DirectoryPath
                    psi.Arguments = "-Delete"
                    psi.FileName = "ՀԴՄ App.exe"
                    psi.WindowStyle = ProcessWindowStyle.Normal
                    Process.Start(psi)
                    End
                End If

                If argument = "-Delete" Then
                    If argument = "-Delete" Then
                        Dim vMatchingProcesses As Process() = Process.GetProcessesByName("UpdateSoft2")
                        For Each vProc As Process In vMatchingProcesses
                            vProc.Kill()
                        Next
                        System.Threading.Thread.Sleep(1500)
                        If IO.File.Exists("UpdateSoft2.exe") Then IO.File.Delete("UpdateSoft2.exe")
                    End If
                End If

            Next

        End If

    End Sub

End Class