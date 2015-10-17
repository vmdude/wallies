Public Class frm_IntervalTimer

    Private Sub IntervalTimer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = modMain.mobTimer.Interval / 60000
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        modMain.SetUpTimer(NumericUpDown1.Value * 60000)
        Me.Dispose()
    End Sub
End Class