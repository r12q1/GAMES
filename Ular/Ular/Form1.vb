Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("EASY")
        ComboBox1.Items.Add("MEDIUM")
        ComboBox1.Items.Add("HARD")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then ComboBox1.Focus() : Exit Sub
        If ComboBox1.Text = "EASY" Then Form2.Timer3.Interval = 150
        If ComboBox1.Text = "MEDIUM" Then Form2.Timer3.Interval = 100
        If ComboBox1.Text = "HARD" Then Form2.Timer3.Interval = 20
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.KeyChar = Chr(0)
    End Sub
End Class
