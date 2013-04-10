Public Class Form2
    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        B = New Bitmap(SPEL_WIDTH, SPEL_HEIGHT)
        G = Graphics.FromImage(B)
        M = Me.CreateGraphics

        G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Center.Alignment = StringAlignment.Center
        Mulai()
        Gambar()
    End Sub
    Private Sub Form2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Not GameOver And e.KeyCode = 13 And playerkey Then
            berhenti = Not berhenti
            If berhenti Then
                Timer3.Enabled = False
                G.DrawString("Pause, Silakan Anda Minum Kopi !", Me.Font, New SolidBrush(TextCol), SPEL_WIDTH / 2, SPEL_HEIGHT / 2 + 100, Center)
                PictureBox2.Visible = True
                Timer1.Enabled = True
            Else
                Timer3.Enabled = True
                Timer1.Enabled = False
                PictureBox2.Visible = False
                Ular()
            End If
            Gambar()
        End If
        If Not berhenti And Not GameOver And e.KeyCode > 36 And e.KeyCode < 41 And lastkey Mod 2 <> (e.KeyCode - 36) Mod 2 Then
            For i As Integer = 0 To keybuffer.Length - 1
                If keybuffer(i) = 0 Then
                    keybuffer(i) = e.KeyCode - 36
                    lastkey = keybuffer(i)
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub Form2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Gambar()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If PictureBox2.Visible = True Then
            PictureBox2.Visible = False
        Else
            PictureBox2.Visible = True
        End If
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If PictureBox5.Visible = True Then
            PictureBox5.Visible = False
        Else
            PictureBox5.Visible = True
        End If
    End Sub
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If GameOver Then Mulai() : Gambar() : Exit Sub

        If keybuffer(0) Then
            If playerkey <> keybuffer(0) Then
                playerkey = keybuffer(0)
                For i As Integer = 1 To keybuffer.Length - 1
                    keybuffer(i - 1) = keybuffer(i)
                    keybuffer(i) = 0
                Next
            End If
        End If

        Select Case playerkey
            Case 1
                Segment(Bak).X = Segment(fram).X - 12
                If Segment(fram).X = 0 Then Segment(Bak).X = SPEL_WIDTH - 12
                Segment(Bak).Y = Segment(fram).Y
            Case 2
                Segment(Bak).Y = Segment(fram).Y - 12
                If Segment(fram).Y = 0 Then Segment(Bak).Y = SPEL_HEIGHT - 12
                Segment(Bak).X = Segment(fram).X
            Case 3
                Segment(Bak).X = Segment(fram).X + 12
                If Segment(fram).X = SPEL_WIDTH - 12 Then Segment(Bak).X = 0
                Segment(Bak).Y = Segment(fram).Y
            Case 4
                Segment(Bak).Y = Segment(fram).Y + 12
                If Segment(fram).Y = SPEL_HEIGHT - 12 Then Segment(Bak).Y = 0
                Segment(Bak).X = Segment(fram).X
            Case 0
                Exit Sub
        End Select

        fram = Bak
        If Bak = length Then Bak = 0 Else Bak = Bak + 1

        For I As Integer = 0 To Segment.Length - 1
            If I <> fram And Segment(fram).X = Segment(I).X And Segment(fram).Y = Segment(I).Y Then
                GameOver = True
                Dim pesan As String
                pesan = MessageBox.Show("Permainan Selesai ! Main Lagi ?", "Ular", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If pesan = vbYes Then
                    Gambar()
                Else
                    Form1.Show()
                    Me.Hide()
                End If
                Exit Sub
            End If
        Next

        If Gamepoint.X = Segment(fram).X And Gamepoint.Y = Segment(fram).Y Then Makan() : score = score + 1 : length = length + 1
        Label1.Text = "= " & score & ""
        Ular()
        Gambar()
    End Sub
End Class