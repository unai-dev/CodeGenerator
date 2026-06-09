Imports CodeGenerator.Tools

Public Class CLASS_GENERATOR
#Region "   GenerateEntityClass-----------------------------------------------------------------------------"
    Public Shared Function GenerateEntityClass(aTable As O_TableInfo) As String
        Dim template = CLASS_TEMPLATE.Template

        Dim pk = aTable.Columns.First(Function(t) t.IsPrimaryKey).Name

        template = template.Replace("{EntityName}", aTable.Name)
        template = template.Replace("{TableName}", aTable.Name)
        template = template.Replace("{PrimaryKey}", pk)

        template = template.Replace("{Properties}", GenerateProperties(aTable))
        template = template.Replace("{LoadAssignments}", GenerateLoadAssignments(aTable))
        template = template.Replace("{PrepareAssignments}", GeneratePrepareAssignments(aTable))
        template = template.Replace("{InsertColumns}", GenerateInsertColumns(aTable))
        template = template.Replace("{InsertParams}", GenerateInsertParams(aTable))
        template = template.Replace("{UpdateAssignments}", GenerateUpdateAssignments(aTable))


        Return template
    End Function
#End Region

#Region "   GenerateProperties-----------------------------------------------------------------------------"
    Private Shared Function GenerateProperties(aTable As O_TableInfo) As String
        Dim sb As New Text.StringBuilder()

        For Each col In aTable.Columns
            If col.Name.Equals("DATE") Or col.Name.Equals("Date") Or col.Name.Equals("date") Then
                sb.AppendLine(" Public Property " & "ORDER_DATE" & " As " & TOOLS_FINALS.ConvertType(col.DataType))
            Else
                sb.AppendLine(" Public Property " & col.Name & " As " & TOOLS_FINALS.ConvertType(col.DataType))
            End If
        Next

        Return sb.ToString()
    End Function
#End Region

#Region "   GenerateLoadAssignments-----------------------------------------------------------------------------"
    Private Shared Function GenerateLoadAssignments(aTable As O_TableInfo) As String
        Dim sb As New Text.StringBuilder()

        For Each col In aTable.Columns
            sb.AppendLine($"    {col.Name} = row(""{col.Name}"")")
        Next

        Return sb.ToString()
    End Function
#End Region

#Region "   GeneratePrepareAssignments-----------------------------------------------------------------------------"
    Private Shared Function GeneratePrepareAssignments(aTable As O_TableInfo) As String
        Dim sb As New Text.StringBuilder()

        For Each col In aTable.Columns
            sb.AppendLine($"    d(""@{col.Name}"") = {col.Name}")
        Next

        Return sb.ToString()
    End Function
#End Region

#Region "   GenerateInsertColumns-----------------------------------------------------------------------------"
    Private Shared Function GenerateInsertColumns(aTable As O_TableInfo) As String
        Return String.Join(", ", aTable.Columns.Where(Function(c) Not c.IsPrimaryKey).Select(Function(c) c.Name))
    End Function
#End Region

#Region "   GenerateInsertParams-----------------------------------------------------------------------------"
    Private Shared Function GenerateInsertParams(aTable As O_TableInfo) As String
        Return String.Join(", ", aTable.Columns.Where(Function(c) Not c.IsPrimaryKey).Select(Function(c) "@" & c.Name))
    End Function
#End Region

#Region "   GenerateUpdateAssignments-----------------------------------------------------------------------------"
    Private Shared Function GenerateUpdateAssignments(aTable As O_TableInfo) As String
        Return String.Join(", ", aTable.Columns.Where(Function(c) Not c.IsPrimaryKey).Select(Function(c) c.Name & " = @" & c.Name))
    End Function
#End Region
End Class
