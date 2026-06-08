Public Class ClassTemplate
    Public Shared ReadOnly Template As String =
"Imports System.Data.SqlClient
Imports System.Configuration

Public Class O_{EntityName}

{Properties}

    Private ReadOnly _connectionString As String = ConfigurationManager.ConnectionStrings(""MiConexion"").ConnectionString

    Public Sub New()
    End Sub

    Public Sub New(id As Integer)
        Load(id)
    End Sub

    Public Sub Load(id As Integer)
        Using cn As New SqlConnection(_connectionString)
            cn.Open()

            Dim sql As String = ""SELECT * FROM {TableName} WHERE {PrimaryKey} = @{PrimaryKey}""

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue(""@{PrimaryKey}"", id)

                Using da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    If dt.Rows.Count = 0 Then
                        Throw New Exception(""Registro no encontrado en {TableName}"")
                    End If

                    LoadFromRow(dt.Rows(0))
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadFromRow(row As DataRow)
{LoadAssignments}
    End Sub

    Private Function Prepare_Objeto() As Dictionary(Of String, Object)
        Dim d As New Dictionary(Of String, Object)
{PrepareAssignments}
        Return d
    End Function

    Public Sub Save()
        Using cn As New SqlConnection(_connectionString)
            cn.Open()

            Dim sql As String

            If {PrimaryKey} = 0 Then
                sql = ""INSERT INTO {TableName} ({InsertColumns}) VALUES ({InsertParams}); SELECT SCOPE_IDENTITY();""
            Else
                sql = ""UPDATE {TableName} SET {UpdateAssignments} WHERE {PrimaryKey} = @{PrimaryKey}""
            End If

            Using cmd As New SqlCommand(sql, cn)
                For Each p In Prepare_Objeto()
                    cmd.Parameters.AddWithValue(p.Key, p.Value)
                Next

                If {PrimaryKey} = 0 Then
                    {PrimaryKey} = Convert.ToInt32(cmd.ExecuteScalar())
                Else
                    cmd.ExecuteNonQuery()
                End If
            End Using
        End Using
    End Sub

    Public Sub Delete()
        If {PrimaryKey} = 0 Then Exit Sub

        Using cn As New SqlConnection(_connectionString)
            cn.Open()

            Dim sql As String = ""DELETE FROM {TableName} WHERE {PrimaryKey} = @{PrimaryKey}""

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue(""@{PrimaryKey}"", {PrimaryKey})
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class"
End Class
