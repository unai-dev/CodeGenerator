Public Class TOOLS_FINALS
    'Ruta de guardado
    Public Shared _ROUTE As String = "C:\Temp"
    'Cadena de conexion
    Public Shared _CONNECTION_STRING As String = "MainDb"

    ''' <summary>
    ''' Conversion de tipos recibidos de la BD
    ''' </summary>
    ''' <param name="aSqlType">representa el tipo recibido en la bd</param>
    ''' <returns></returns>
    Public Shared Function ConvertType(aSqlType As String) As String

        Select Case aSqlType.ToLower()
            Case "int"
                Return "Integer"

            Case "nvarchar", "char", "varchar", "text", "ntext", "char"
                Return "String"

            Case "decimal", "numeric", "money"
                Return "Decimal"

            Case "float"
                Return "Double"

            Case "bigint"
                Return "Long"

            Case "smallint"
                Return "Short"

            Case "real"
                Return "Single"

            Case "datetime", "datetime2", "smalldatetime", "date"
                Return "DateTime"

            Case "uniqueidentifier"
                Return "Guid"

            Case "varbinary", "binary", "image"
                Return "Byte()"

            Case "bit"
                Return "Boolean"

            Case Else
                Return "Object"

        End Select

    End Function
End Class
