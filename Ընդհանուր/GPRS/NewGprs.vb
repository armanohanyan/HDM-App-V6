Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class NewGprs

    Dim gSerial As New List(Of GprsSerial)

    Private Sub NewGprs_Load(sender As Object, e As EventArgs) Handles Me.Load
        With sDate
            .DateTime = DateSerial(Now.Year, Now.Month, 1)
            .Properties.DisplayFormat.FormatString = "dd.MM.yy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
            .Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        Try
            If cOrange.Checked AndAlso txtCode.Text.Trim.Length <> 13 Then
                Exit Sub
            ElseIf cViva.Checked AndAlso ((txtCode.Text.Trim.Length <> 19 AndAlso cF1.Checked = False) _
                                           OrElse (txtCode.Text.Trim.Length <> 20 AndAlso cF1.Checked = True)) Then
                Exit Sub
            ElseIf cBeeline.Checked AndAlso ((txtCode.Text.Trim.Length <> 19 AndAlso cC1.Checked = False) _
                                           OrElse (txtCode.Text.Trim.Length <> 18 AndAlso cC1.Checked = True)) Then
                Exit Sub
            End If

            Dim GP As String = String.Empty

            If cOrange.Checked Then
                If txtCode.Text.Trim.Length <> 13 Then Throw New Exception("GPRS-ի կոդը լրիվ գրված չէ")
                GP = "8937410" & txtCode.Text.Trim
            ElseIf cViva.Checked Then
                GP = Microsoft.VisualBasic.Left(txtCode.Text.Trim, 18)
            Else
                GP = Microsoft.VisualBasic.Left(txtCode.Text.Trim, 18)
            End If

            If gSerial.Exists(Function(x) x.Serial = GP) Then
                txtCode.Text = String.Empty
                txtCode.Focus()
                Throw New Exception("Գրանցումը կրկնվում է")
            End If

            'Insert
            iDB.AddNewGprsSerial(GP, sDate.DateTime)

            'Show
            gSerial.Add(New GprsSerial(GP))

            Dim dt As DataTable = ToDataTable(gSerial)

            GridControl1.BeginUpdate()
            GridControl1.DataSource = Nothing
            GridView1.Columns.Clear()
            GridControl1.DataSource = dt
            GridControl1.EndUpdate()

            With GridView1
                .ClearSorting()
                .OptionsCustomization.AllowFilter = False
                .OptionsCustomization.AllowSort = False
                .FocusedRowHandle = 0
            End With

            txtCode.Text = String.Empty
            txtCode.Focus()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub NewGprs_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckPermission2("8EEDC9FC04C345D1996DE693FF23456F") = False Then txtCode.Enabled = False
    End Sub
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

End Class

Public Class GprsSerial

    Public Sub New(ByVal sSerial As String)
        _serial = sSerial
    End Sub

    Private _serial As String
    Public Property Serial As String
        Get
            Return _serial
        End Get
        Set(value As String)
            _serial = value
        End Set
    End Property

End Class