Module Module1
    Public Structure Posisi
        Dim X As Short
        Dim Y As Short
    End Structure
    Public B As Bitmap
    Public G, M As Graphics
    Public Segment(500), Gamepoint As Posisi
    Public Center As New StringFormat
    Public Bak, length, fram, playerkey, score, lastkey, keybuffer(4) As Short
    Public GameOver, berhenti As Boolean
    Public TextCol As Color = Color.FromArgb(50, 71, 45)
    Public Const SPEL_WIDTH = 396
    Public Const SPEL_HEIGHT = 324
    Public Sub Gambar()
        M.DrawImage(B, New Point(0, 0))
    End Sub
    Public Sub Ular()
        G.Clear(Color.Blue)

        For I As Integer = 0 To length
            If I = Bak Then
                GoTo Print
            ElseIf Not (Segment(Bak).X = Segment(I).X And Segment(Bak).Y = Segment(I).Y) Then
                GoTo Print
            End If
            GoTo Selanjutnya
Print:
            G.FillRectangle(New SolidBrush(Color.Black), New Rectangle(Segment(I).X, Segment(I).Y, 12.5, 12.5))
Selanjutnya:

        Next

        Form2.PictureBox1.Left = Gamepoint.X
        Form2.PictureBox1.Top = Gamepoint.Y
    End Sub
    Public Sub Mulai()
        Gamepoint.X = 12 * Int(Rnd() * 33)
        Gamepoint.Y = 12 * Int(Rnd() * 27)

        Randomize()
        length = 2
        fram = 0
        Bak = 0
        GameOver = False
        playerkey = 0
        lastkey = -1
        Dim I As Integer
        For I = 0 To length
            Segment(I).X = 192
            Segment(I).Y = 156
        Next
        For I = length + 1 To Segment.Length - 1
            Segment(I).X = -12
        Next
        Ular()
    End Sub
    Public Sub Makan()
Kembali:
        Gamepoint.X = 12 * Int(Rnd() * 33)
        Gamepoint.Y = 12 * Int(Rnd() * 27)
        For I As Integer = 0 To length
            If Segment(I).X = Gamepoint.X And Gamepoint.Y = Segment(I).Y Then GoTo Kembali
        Next
        On Error GoTo lanjut

lanjut:
    End Sub
End Module
