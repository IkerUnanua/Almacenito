Public Class AdministracionUsuarios
    Private Usuarios As List(Of Usuario)

    Public Sub New() 'Se refiere al constructor para que empieze ya con unos valores
        Dim usu As New Usuario
        usu.NombreUsuario = "Administradores"
        usu.Contraseña = "Administrador"
        Usuarios = New List(Of Usuario)
        Usuarios.Add(usu)
    End Sub
    Private Function ComprobarAdministrador(ByVal comprobarAdmin As Usuario) As String 'Funcion que comprueba que el primer usuario sea administrador y esté bien introducido

        If comprobarAdmin.NombreUsuario = "" AndAlso comprobarAdmin.Contraseña = "" Then
            Return "Algun campo vacío"
        End If
        If comprobarAdmin.Equals(Usuarios(0)) Then
            Return ""
        Else
            Return "No es el administrador."
        End If
    End Function
    Public Function AñadirUsuario(ByVal Administrador As Usuario, ByVal NuevoUsuario As Usuario) As String
        Dim respuesta As String
        respuesta = ComprobarAdministrador(Administrador)
        If respuesta = "" Then
            If Not Usuarios.Contains(NuevoUsuario) AndAlso NuevoUsuario.NombreUsuario <> "" AndAlso NuevoUsuario.Contraseña <> "" Then
                Usuarios.Add(NuevoUsuario)
                Return ""
            End If
        End If
        Return "Error al añadir usuario"
    End Function

    Public Function BorrarUsuario(ByVal administrador As Usuario, ByVal nombreUsuarioBorrar As String) As String
        Dim resp As String
        resp = ComprobarAdministrador(administrador)
        If resp = "" Then
            For i = 0 To Usuarios.Count - 1
                If nombreUsuarioBorrar = Usuarios(i).NombreUsuario Then
                    Usuarios.RemoveAt(i)
                    Return ""
                End If
            Next
        End If
        Return "Error al eliminar usuario =)"
    End Function
    Public Function ModificarUsuario(ByVal administrador As Usuario, ByVal nombreUsuarioModificar As String, ByVal usuarioModificado As Usuario) As String
        Dim resp As String
        resp = ComprobarAdministrador(administrador)
        If resp = "" Then
            For i = 0 To Usuarios.Count - 1
                If nombreUsuarioModificar = Usuarios(i).NombreUsuario Then
                    Usuarios(i).NombreUsuario = usuarioModificado.NombreUsuario
                    Usuarios(i).Contraseña = usuarioModificado.Contraseña
                    Return ""
                End If
            Next
        End If
        Return "Error, no se puede modifcar"
    End Function


    Public Function ValidarUsuario(ByVal usuario As Usuario) As String

        Dim intentos As Integer = 0

        For i = 0 To Usuarios.Count - 1
            If usuario.NombreUsuario = Usuarios(i).NombreUsuario AndAlso usuario.Contraseña = Usuarios(i).Contraseña Then
                Return ""
            Else
                If usuario.NombreUsuario = Usuarios(i).NombreUsuario Then
                    intentos = intentos + 1
                End If
            End If
        Next




        Return "Error"
    End Function



    Public Function RestablecerUsuario(ByVal administrador As Usuario, ByVal usuario As Usuario) As String
        Dim resp As String
        resp = ComprobarAdministrador(administrador)
        If resp = "" Then

            For i = 0 To Usuarios.Count - 1
                If Usuarios(i).NombreUsuario.ToUpper <> administrador.NombreUsuario.ToUpper Then
                    Return "Administrador erroneo"
                End If
                If administrador.Contraseña <> Usuarios(i).Contraseña Then
                    Return "contraseña de administrador errónea"
                End If
                If usuario.NombreUsuario <> Usuarios(i).NombreUsuario Then
                    Return "usuario inexistente"
                    If usuario.NombreUsuario = Usuarios(i).NombreUsuario Then
                        Return "usuario existente"
                    End If
                End If
            Next
            Return ""


        Else
            Return "No es el administrador"
        End If

    End Function
End Class