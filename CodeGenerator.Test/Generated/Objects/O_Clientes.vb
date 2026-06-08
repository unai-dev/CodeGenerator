Imports System.Data.SqlClient
Imports System.Configuration

#Region "  O_Clientes-------------------------------------------------------------------------------"
Public Class O_Clientes

#Region "  Properties-------------------------------------------------------------------------------"
 Public Property IdCliente As Integer
 Public Property Nombre As String
 Public Property Email As String
 Public Property FechaRegistro As DateTime
 Public Property Saldo As Decimal
 Public Property Activo As Boolean

#End Region

    Private ReadOnly _connectionString As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString

#Region "  New-------------------------------------------------------------------------------"
    Public Sub New()
    End Sub

    Public Sub New(id As Integer)
        Load(id)
    End Sub
#End Region

#Region "  Load-------------------------------------------------------------------------------"
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
#End Region

#Region "  LoadFromRow-------------------------------------------------------------------------------"
    Private Sub LoadFromRow(row As DataRow)
    IdCliente = row("IdCliente")
    Nombre = row("Nombre")
    Email = row("Email")
    FechaRegistro = row("FechaRegistro")
    Saldo = row("Saldo")
    Activo = row("Activo")

    End Sub
#End Region

#Region "  Prepare_Objeto-------------------------------------------------------------------------------"
    Private Function Prepare_Objeto() As Dictionary(Of String, Object)
        Dim d As New Dictionary(Of String, Object)
    d("@IdCliente") = IdCliente
    d("@Nombre") = Nombre
    d("@Email") = Email
    d("@FechaRegistro") = FechaRegistro
    d("@Saldo") = Saldo
    d("@Activo") = Activo

        Return d
    End Function
#End Region

#Region "  Save-------------------------------------------------------------------------------"
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
#End Region

#Region "  Delete-------------------------------------------------------------------------------"
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
#End Region

End Class
#End Region
