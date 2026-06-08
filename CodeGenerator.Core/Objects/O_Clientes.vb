Imports System.Data.SqlClient

Public Class O_Clientes

 Public Property IdCliente As Integer
 Public Property Nombre As String
 Public Property Email As String
 Public Property FechaRegistro As DateTime
 Public Property Saldo As Decimal
 Public Property Activo As Object


    Private ReadOnly _connectionString As String =
        Configuration.ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString

    Public Sub New()
    End Sub

    Public Sub New(id As Integer)
        Load(id)
    End Sub

    Public Sub Load(id As Integer)
        Using cn As New SqlConnection(_connectionString)
            cn.Open()

            Dim sql As String = "SELECT * FROM Clientes WHERE IdCliente = @IdCliente"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@IdCliente", id)

                Using da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    If dt.Rows.Count = 0 Then
                        Throw New Exception("Registro no encontrado en Clientes")
                    End If

                    LoadFromRow(dt.Rows(0))
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadFromRow(row As DataRow)
    IdCliente = row("IdCliente")
    Nombre = row("Nombre")
    Email = row("Email")
    FechaRegistro = row("FechaRegistro")
    Saldo = row("Saldo")
    Activo = row("Activo")

    End Sub

    Private Function Prepare_Objeto() As Dictionary(Of String, Object)
        Dim d As New Dictionary(Of String, Object)
    d("@IdCliente" = IdCliente
    d("@Nombre" = Nombre
    d("@Email" = Email
    d("@FechaRegistro" = FechaRegistro
    d("@Saldo" = Saldo
    d("@Activo" = Activo

        Return d
    End Function

    Public Sub Save()
        Using cn As New SqlConnection(_connectionString)
            cn.Open()

            Dim sql As String

            If IdCliente = 0 Then
                sql = "INSERT INTO Clientes (Nombre, Email, FechaRegistro, Saldo, Activo) VALUES (@Nombre, @Email, @FechaRegistro, @Saldo, @Activo); SELECT SCOPE_IDENTITY();"
            Else
                sql = "UPDATE Clientes SET Nombre = @Nombre, Email = @Email, FechaRegistro = @FechaRegistro, Saldo = @Saldo, Activo = @Activo WHERE IdCliente = @IdCliente"
            End If

            Using cmd As New SqlCommand(sql, cn)
                For Each p In Prepare_Objeto()
                    cmd.Parameters.AddWithValue(p.Key, p.Value)
                Next

                If IdCliente = 0 Then
                    IdCliente = Convert.ToInt32(cmd.ExecuteScalar())
                Else
                    cmd.ExecuteNonQuery()
                End If
            End Using
        End Using
    End Sub

    Public Sub Delete()
        If IdCliente = 0 Then Exit Sub

        Using cn As New SqlConnection(_connectionString)
            cn.Open()

            Dim sql As String = "DELETE FROM Clientes WHERE IdCliente = @IdCliente"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class