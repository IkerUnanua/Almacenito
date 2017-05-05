Public Class Juego
    Inherits Form
    Private coordenadasControlIniciales As Point
    Dim coordenadasMouseIniciales As Point
    Private btnDown As Boolean
    Private offsetX As Integer
    Private offsetY As Integer
    Private X, Y As Integer

    Private Sub Juego_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim picture As New PictureBox
        picture.Location = New Point(23, 45)
        picture.BackColor = Color.BlueViolet
        AddHandler picture.MouseDown, AddressOf imagenClickadaa
        AddHandler picture.MouseMove, AddressOf imagenMovida
        AddHandler picture.MouseUp, AddressOf imagenSoltada
        Me.Controls.Add(picture)



    End Sub

    Public Sub imagenClickadaa(sender As Object, e As MouseEventArgs)
        Dim picture As PictureBox = TryCast(sender, PictureBox)
        coordenadasMouseIniciales = New Point(e.X, e.Y)
        picture.BringToFront()
    End Sub
    Public Sub imagenClickada(sender As Object, e As MouseEventArgs)
        Dim picture As PictureBox = TryCast(sender, PictureBox)
        coordenadasMouseIniciales = New Point(e.X, e.Y)
        picture.BringToFront()
        coordenadasControlIniciales = picture.Location

    End Sub
    Public Sub imagenMovida(sender As Object, e As MouseEventArgs)
        Dim picture As PictureBox = TryCast(sender, PictureBox)
        If e.Button = MouseButtons.Left Then
            picture.Location = New Point(picture.Left + e.X - coordenadasMouseIniciales.X, picture.Top + e.Y - coordenadasMouseIniciales.Y)
            picture.BackColor = Color.Aqua
        End If
    End Sub
    Public Sub imagenSoltada(sender As Object, e As MouseEventArgs)
        Dim picture As PictureBox = TryCast(sender, PictureBox)

        picture.Location = coordenadasControlIniciales


        picture.BackColor = Color.BlueViolet
    End Sub

End Class
