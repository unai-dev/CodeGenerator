Imports System.Data.SqlClient

Public Module MetadataReader

#Region "   GET TABLES-----------------------------------------------------------------------------"
    ''' <summary>
    ''' Funcion que obtiene la lista de tablas y sus columas y las retorna
    ''' </summary>
    ''' <param name="connectionString">conexion a la base de datos</param>
    ''' <returns>devuleve una lista de tablas</returns>
    Public Function GetTables(connectionString As String) As List(Of O_TableInfo)
        Dim tables As New List(Of O_TableInfo)

        Using cn As New SqlConnection(connectionString)

            'Abrimos conexion
            cn.Open()

            'Guardamos las tablas obtenidas
            Dim cmdTables As New SqlCommand(
                "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME", cn)

            'Por cada linea obtenida de la consulta, creamos un nuevo objeto O_TableInfo y lo agregamos a la lista de tablas
            Using rd = cmdTables.ExecuteReader()
                While rd.Read()
                    tables.Add(New O_TableInfo With {
                    .Name = rd("TABLE_NAME").ToString()
                    })
                End While
            End Using

            'Por cada tabla de la lista tables obtenemos sus columnas y se las asignamos a la propiedad Columns de cada tabla
            For Each tbl In tables
                tbl.Columns = GetColumns(cn, tbl.Name)
            Next

        End Using
        Return tables
    End Function
#End Region

#Region "   GET COLUMNS----------------------------------------------------------------------------"
    ''' <summary>
    ''' Funcion que obtiene una lista de columnas de la tabla especificada , incluyendo su tipo de dato, si es nula o no y si es clave primaria o no
    ''' </summary>
    ''' <param name="cn">conexion a la base de datos</param>
    ''' <param name="tableName">nombre de la tabla</param>
    ''' <returns>devuelve una lista de columnas</returns>
    Public Function GetColumns(cn As SqlConnection, tableName As String) As List(Of O_ColumnInfo)
        Dim cols As New List(Of O_ColumnInfo)

        'Creamos la consulta SQL para obtener las columnas de la tabla especificada, incluyendo su tipo de dato, si es nula o no y si es clave primaria o no
        Dim sql As String = "
            SELECT 
                c.COLUMN_NAME,
                c.DATA_TYPE,
                c.IS_NULLABLE,
                CASE WHEN k.COLUMN_NAME IS NOT NULL THEN 1 ELSE 0 END AS IsPK
            FROM INFORMATION_SCHEMA.COLUMNS c
            LEFT JOIN (
                SELECT COLUMN_NAME 
                FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
                WHERE TABLE_NAME = @table
            ) k ON c.COLUMN_NAME = k.COLUMN_NAME
            WHERE c.TABLE_NAME = @table
            ORDER BY c.ORDINAL_POSITION
        "

        'Ejecutamos la consulta sql y por cada linea obtenida, creamos un nuevo objeto O_ColumnInfo y lo agregamos a la lista de columnas
        Using cmd As New SqlCommand(sql, cn)

            'Agregamos el parametro de la tabla a la consulta
            cmd.Parameters.AddWithValue("@table", tableName)

            Using rd = cmd.ExecuteReader()
                While rd.Read()
                    cols.Add(New O_ColumnInfo With {
                    .Name = rd("COLUMN_NAME").ToString(),
                    .DataType = rd("DATA_TYPE").ToString(),
                    .IsNullable = (rd("IS_NULLABLE").ToString() = "YES"),
                    .IsPrimaryKey = (CInt(rd("IsPK")) = 1)
                    })
                End While
            End Using

        End Using
        Return cols

    End Function

#End Region
End Module
