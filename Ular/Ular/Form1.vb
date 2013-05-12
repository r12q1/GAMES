Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form2.Label3.Text = 0
        score = 0
        If RadioButton1.Checked Then
            Form2.Timer3.Interval = 150
            level = "Easy"
            Me.Hide()
            Form2.Show()
        ElseIf RadioButton2.Checked Then
            Form2.Timer3.Interval = 100
            level = "Medium"
            Me.Hide()
            Form2.Show()
        ElseIf RadioButton3.Checked Then
            Form2.Timer3.Interval = 50
            level = "Hard"
            Me.Hide()
            Form2.Show()
        ElseIf RadioButton4.Checked Then
            Form2.Timer3.Interval = 25
            level = "Crazy"
            Me.Hide()
            Form2.Show()
        Else
            MessageBox.Show("silahkan pilih level dulu!", "ERROR!!!")
        End If
        Form2.Label4.Text = level

    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = Chr(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        form4.show()
    End Sub

End Class
