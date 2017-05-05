Public Class Usuario : Implements IEquatable(Of Usuario)



    Private _NombreUsuario As String
    Public Property NombreUsuario As String
        Get
            Return _NombreUsuario
        End Get
        Set(value As String)
            If value.Length <= 20 AndAlso value <> "" Then
                _NombreUsuario = value
            Else
                _NombreUsuario = "No es un nombre válido =("
            End If
        End Set
    End Property

    Private _Contraseña As String
    Public Property Contraseña As String
        Get
            Return _Contraseña
        End Get
        Set(value As String)
            If value <> "" AndAlso value.Length <= 9 Then
                _Contraseña = value
            Else
                _Contraseña = "Repite contraseña"
            End If
        End Set
    End Property


    Public Overloads Function Equals(other As Usuario) As Boolean Implements IEquatable(Of Usuario).Equals
        Return Me.NombreUsuario.ToLower = other.NombreUsuario.ToLower
    End Function
End Class
