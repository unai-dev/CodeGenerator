Public Class TOOLS_FINALS

    Public Shared _ROUTE As String = "C:\Users\unaid\source\repos\CodeGenerator\CodeGenerator.Test\Generated\Objects"
    Public Shared _CONNECTION_STRING As String = "MainDb"

    Public Shared Function ConvertType(sqlType As String) As String

        Select Case sqlType.ToLower()
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
