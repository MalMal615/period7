Public Class Line
    Public Property xspeed As Integer
    Public Property yspeed As Integer
    Public Property Pen As Pen
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point
    Dim xoffset As Integer
    Dim yoffset As Integer
    Public Sub New(i As Image, a As Point, b As Point)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b
    End Sub
    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            xoffset += xspeed
            yoffset += yspeed
            g.DrawLine(Pen, m_a.X + xoffset, m_a.Y + yoffset, m_b.X + xoffset, m_b.Y + yoffset)
        End Using

    End Sub

End Class
