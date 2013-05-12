Public Class Form4

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Text = "Easy : " & highscore1
        Label4.Text = "Medium : " & highscore2
        Label5.Text = "Hard : " & highscore3
        Label6.Text = "Crazy : " & highscore4
    End Sub
End Class