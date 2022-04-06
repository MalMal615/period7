Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim w As Integer
    Dim c As Color
    Dim type As String

    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub
    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove


        If m_Previous IsNot Nothing Then
            Dim D As Object
            D = New Line(PictureBox1.Image, m_Previous, e.Location)
            D.pen = New Pen(c, w)

            If type = "Line" Then
                D = New Line(PictureBox1.Image, m_Previous, e.Location)
                D.pen = New Pen(c, w)
                D.xspeed = speedtrackbar.Value
            End If
            If type = "Rectangle" Then
                D = New rect(PictureBox1.Image, m_Previous, e.Location)
                D.pen = New Pen(c, w)
                D.h = TrackBar2.Value
                D.w = TrackBar3.Value
            End If
            If type = "Circle" Then
                D = New circle(PictureBox1.Image, m_Previous, e.Location)
                D.pen = New Pen(c, w)
                D.h = TrackBar2.Value
                D.w = TrackBar3.Value
            End If
            If type = "Arc" Then
                D = New arc(PictureBox1.Image, m_Previous, e.Location)
                D.pen = New Pen(c, w)
                D.h = TrackBar2.Value
                D.w = TrackBar3.Value
            End If
            If type = "Pie" Then
                D = New pie(PictureBox1.Image, m_Previous, e.Location)
                D.pen = New Pen(c, w)
                D.h = TrackBar2.Value
                D.w = TrackBar3.Value
            End If
            If type = "Polygon" Then
                D = New polygon(PictureBox1.Image, m_Previous, e.Location)
                D.pen = New Pen(c, w)
                D.h = TrackBar2.Value
                D.w = TrackBar3.Value
            End If
            If type = "n-gon" Then
                D = New n_gon(PictureBox1.Image, m_Previous, e.Location)
                D.pen = New Pen(c, w)
                D.radius = TrackBar5.Value
                D.sides = TrackBar4.Value
            End If
            If type = "picture" Then
                D = New PBbox(PictureBox1.Image, m_Previous, e.Location)
                D.picture = PictureBox2.Image
                D.h = TrackBar2.Value
                D.w = TrackBar3.Value
            End If
            m_shapes.Add(D)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        End If
    End Sub

    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub
    Sub clear()
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If
    End Sub
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw()
        Next
        If (autorefresh.Checked) Then
            Refresh()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        Button1.BackColor = c

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        c = sender.backcolor
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        c = sender.backcolor
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        c = sender.backcolor
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        c = sender.backcolor
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        c = sender.backcolor
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        c = sender.backcolor
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        c = sender.backcolor
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        c = sender.backcolor
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        w = TrackBar1.Value
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles clearbutton.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
        End Using
        PictureBox1.Image = bmp
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles savebutton.Click
        SaveFileDialog1.ShowDialog()
        PictureBox1.Image.Save(SaveFileDialog1.FileName)
    End Sub

    Private Sub LineButton_Click(sender As Object, e As EventArgs) Handles Button13.Click
        type = "Line"
    End Sub

    Private Sub CircleButton_Click(sender As Object, e As EventArgs) Handles Button10.Click
        type = "Circle"
    End Sub

    Private Sub SquareButton_Click(sender As Object, e As EventArgs) Handles Button11.Click
        type = "Rectangle"
    End Sub

    Private Sub ArcButton_Click(sender As Object, e As EventArgs) Handles Button12.Click
        type = "Arc"
    End Sub

    Private Sub PieButton_Click(sender As Object, e As EventArgs) Handles Button14.Click
        type = "Pie"
    End Sub
    Private Sub PolygonButton_Click(sender As Object, e As EventArgs) Handles Button15.Click
        type = "Polygon"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        type = "n-gon"
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        type = "picture"
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox2.Load(OpenFileDialog1.FileName)
    End Sub
End Class