﻿Public Class Juego
    Dim precio As Integer = 0
    Dim cantidadTotal As Integer = 0
    Private Sub Juego_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("articulos.txt")
        Dim stringReader As String
        Dim lines As String()

        Dim cont As Integer = 0

        'Bucle recorre fichero
        Do

            'Analizar cada una de las líneas
            stringReader = fileReader.ReadLine()
            lines = stringReader.Split(":")
            Select Case cont
                Case 0
                    Button1.Text = lines(1)
                    tienda.Añadir(lines(1), 50)
                Case 1
                    Button2.Text = lines(1)
                    tienda.Añadir(lines(1), 50)
                Case 2
                    Button3.Text = lines(1)
                    tienda.Añadir(lines(1), 50)
                Case 3
                    Button4.Text = lines(1)
                    tienda.Añadir(lines(1), 50)
                Case 4
                    Button5.Text = lines(1)
                    tienda.Añadir(lines(1), 50)
                Case 5
                    Button6.Text = lines(1)
                    tienda.Añadir(lines(1), 50)
                Case 6
                    Button7.Text = lines(1)
                    tienda.Añadir(lines(1), 50)
                Case 7
                    Button8.Text = lines(1)
                    tienda.Añadir(lines(1), 50)
                Case 8
                    Button9.Text = lines(1)
                    tienda.Añadir(lines(1), 50)
                Case 9
                    Button10.Text = lines(1)
                    tienda.Añadir(lines(1), 50)
            End Select

            cont = cont + 1
            If cont = 10 Then
                fileReader.Close()
            End If
        Loop Until cont = 10






    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click
        Dim cantidadStr As String
        Dim booleano As Boolean = True
        Dim booleano2 As Boolean = True
        Dim cantidad As Integer
        Dim respuestaStr As String
        Dim respuesta As Integer
        Dim stockStr As String
        Dim boton As Button = TryCast(sender, Button)
        pCarrito.Visible = True
        'No se meten espacios en blanco o nada. Disculpen las molestias, estamos trabajando arduamente para solucionar el problema. Arkaitz esta hablando con sus contactos para solucionar el problema.
        Do
            cantidadStr = InputBox("Cuanta cantidad de " + boton.Text + " desea?")
            If Not Integer.TryParse(cantidadStr, cantidad) OrElse String.IsNullOrWhiteSpace(cantidadStr) Then
                booleano = False
                MsgBox("Error, número no válido")
            End If
        Loop Until booleano = True AndAlso cantidad <= 50
        For i = 0 To tienda.Articulos.Count - 1
            Dim stock As Integer = 0
            If tienda.Articulos(i).Nombre = boton.Text Then
                lstPedidos.Items.Add(cantidadStr + "-" + boton.Text)

                stock = tienda.Articulos(i).Stock
                stock = stock - cantidad
                tienda.Articulos(i).Stock = stock
                cantidadTotal = cantidadTotal + cantidad

                Do
                    respuestaStr = InputBox("¿Cuantos paquetes quedan en el articulo " + tienda.Articulos(i).Nombre + "?")
                    If Not Integer.TryParse(respuestaStr, respuesta) Then
                        booleano2 = False
                        MsgBox("Error, número no válido")
                    End If
                Loop Until booleano2 = True
                If respuesta = stock Then
                    MsgBox("Enhorabuena crack! Has acertado, era justo esa cantidad la que queda en stock")
                Else
                    stockStr = stock
                    MsgBox("Lo sentimos pero la cantidad que queda en stock de ese articulo es " + stockStr + ". Más suerte la próxima vez ;) ")
                End If
            End If
        Next



        boton.Enabled = False
    End Sub

    Private Sub btnComprar_Click(sender As Object, e As EventArgs) Handles btnComprar.Click
        Dim comprarStr As String
        Dim comprar As Integer
        Dim booleano As Boolean = True
        Dim cantidadTotalStr As String
        Do
            comprarStr = InputBox("Cuanta cantidad de articulos has comprado amable señor")
            If Not Integer.TryParse(comprarStr, comprar) Then
                booleano = False
                MsgBox("Error, número no válido")
            End If

        Loop Until booleano = True
        If comprar = cantidadTotal Then
            MsgBox("Muy bien, el número introducido es correcto")
        Else
            cantidadTotalStr = cantidadTotal
            MsgBox("Lo sentimos, la cantidad pedida es de " + cantidadTotalStr + " .Esperamos que tenga más suerte la próxima vez =)")
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        lstPedidos.Items.Clear()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        For i = 0 To tienda.Articulos.Count - 1
            tienda.Articulos(i).Stock = 50
        Next
    End Sub
End Class
