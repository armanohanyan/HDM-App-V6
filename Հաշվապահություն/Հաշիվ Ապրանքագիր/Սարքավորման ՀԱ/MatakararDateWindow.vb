Public Class MatakararDateWindow

    Private Const CP_NOCLOSE_BUTTON As Integer = &H200

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property

    Public Property MDate As Date = Date.MinValue

    Private Sub MatakararDateWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sDate.DateTime = Now
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        MDate = sDate.DateTime
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        MDate = Date.MinValue
        Me.Close()
    End Sub

End Class