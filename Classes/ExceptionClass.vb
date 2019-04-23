Public Class ExceptionClass
    Inherits Exception

    Public Sub New(ByVal errNumber As Integer, ByVal errMessage As String, ByVal IconStyle As MsgBoxStyle)
        Dim showText As String = String.Empty
        Select Case errNumber
            Case -1
                showText = errMessage
        End Select

        MsgBox(showText, IconStyle, My.Application.Info.Title)
    End Sub
    Friend Sub ShowCustomError(ByVal errNumber As Integer, ByVal errMessage As String, ByVal IconStyle As MsgBoxStyle)
        Dim showText As String = String.Empty
        Select Case errNumber
            Case -1
                showText = errMessage
        End Select

        MsgBox(showText, IconStyle, My.Application.Info.Title)
    End Sub

    Public Sub New()

    End Sub

    Friend Sub ShowError(ByVal errNumber As Integer, ByVal errMessage As String, ByVal IconStyle As MsgBoxStyle)
        Dim showText As String = String.Empty
        Select Case errNumber
            Case 0
                showText = errMessage
        End Select

        MsgBox(showText, IconStyle, My.Application.Info.Title)
    End Sub

End Class