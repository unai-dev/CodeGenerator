Imports System.Data.SqlClient
Imports System.Configuration

#Region "  O_DireccionesClientes-------------------------------------------------------------------------------"
Public Class O_DireccionesClientes

#Region "  Properties-------------------------------------------------------------------------------"
 Public Property IdDireccion As Integer
 Public Property IdCliente As Integer
 Public Property Direccion As String
 Public Property Ciudad As String
 Public Property CodigoPostal As String
 Public Property Pais As String

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

            Dim sql As String = "SELECT * FROM DireccionesClientes WHERE IdDireccion = @IdDireccion"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@IdDireccion", id)

                Using da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    If dt.Rows.Count = 0 Then
                        Throw New Exception("Registro no encontrado en DireccionesClientes")
                    End If

                    LoadFromRow(dt.Rows(0))
                End Using
            End Using
        End Using
    End Sub
#End Region

#Region "  LoadFromRow-------------------------------------------------------------------------------"
    Private Sub LoadFromRow(row As DataRow)
    IdDireccion = row("IdDireccion")
    IdCliente = row("IdCliente")
    Direccion = row("Direccion")
    Ciudad = row("Ciudad")
    CodigoPostal = row("CodigoPostal")
    Pais = row("Pais")

    End Sub
#End Region

#Region "  Prepare_Objeto-------------------------------------------------------------------------------"
    Private Function Prepare_Objeto() As Dictionary(Of String, Object)
        Dim d As New Dictionary(Of String, Object)
    d("@IdDireccion") = IdDireccion
    d("@IdCliente") = IdCliente
    d("@Direccion") = Direccion
    d("@Ciudad") = Ciudad
    d("@CodigoPostal") = CodigoPostal
    d("@Pais") = Pais

        Return d
    End Function
#End Region

#Region "  Save-------------------------------------------------------------------------------"
    Public Sub Save()
        Using cn As New SqlConnection(_connectionString)
            cn.Open()

            Dim sql As String

            If IdDireccion = 0 Then
                sql = "INSERT INTO DireccionesClientes (Direccion, Ciudad, CodigoPostal, Pais) VALUES (@Direccion, @Ciudad, @CodigoPostal, @Pais); SELECT SCOPE_IDENTITY();"
            Else
                sql = "UPDATE DireccionesClientes SET Direccion = @Direccion, Ciudad = @Ciudad, CodigoPostal = @CodigoPostal, Pais = @Pais WHERE IdDireccion = @IdDireccion"
            End If

            Using cmd As New SqlCommand(sql, cn)
                For Each p In Prepare_Objeto()
                    cmd.Parameters.AddWithValue(p.Key, p.Value)
                Next

                If IdDireccion = 0 Then
                    IdDireccion = Convert.ToInt32(cmd.ExecuteScalar())
                Else
                    cmd.ExecuteNonQuery()
                End If
            End Using
        End Using
    End Sub
#End Region

#Region "  Delete-------------------------------------------------------------------------------"
    Public Sub Delete()
        If IdDireccion = 0 Then Exit Sub

        Using cn As New SqlConnection(_connectionString)
            cn.Open()

            Dim sql As String = "DELETE FROM DireccionesClientes WHERE IdDireccion = @IdDireccion"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@IdDireccion", IdDireccion)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
#End Region

End Class
#End Region
