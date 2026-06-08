Imports CodeGenerator.Tools

Public Class CLASS_GENERATOR
#Region "   GenerateEntityClass-----------------------------------------------------------------------------"
    Public Shared Function GenerateEntityClass(atable As O_TableInfo) As String
        Dim template = CLASS_TEMPLATE.Template

        Dim pk = atable.Columns.First(Function(t) t.IsPrimaryKey).Name

        template = template.Replace("{EntityName}", atable.Name)
        template = template.Replace("{TableName}", atable.Name)
        template = template.Replace("{PrimaryKey}", pk)

        template = template.Replace("{Properties}", GenerateProperties(atable))
        template = template.Replace("{LoadAssignments}", GenerateLoadAssignments(atable))
        template = template.Replace("{PrepareAssignments}", GeneratePrepareAssignments(atable))
        template = template.Replace("{InsertColumns}", GenerateInsertColumns(atable))
        template = template.Replace("{InsertParams}", GenerateInsertParams(atable))
        template = template.Replace("{UpdateAssignments}", GenerateUpdateAssignments(atable))


        Return template
    End Function
#End Region

#Region "   GenerateProperties-----------------------------------------------------------------------------"
    Private Shared Function GenerateProperties(atable As O_TableInfo) As String
        Dim sb As New Text.StringBuilder()

        For Each col In atable.Columns
            sb.AppendLine(" Public Property " & col.Name & " As " & TOOLS_FINALS.ConvertType(col.DataType))
        Next

        Return sb.ToString()
    End Function
#End Region

#Region "   GenerateLoadAssignments-----------------------------------------------------------------------------"
    Private Shared Function GenerateLoadAssignments(atable As O_TableInfo) As String
        Dim sb As New Text.StringBuilder()

        For Each col In atable.Columns
            sb.AppendLine($"    {col.Name} = row(""{col.Name}"")")
        Next

        Return sb.ToString()
    End Function
#End Region

#Region "   GeneratePrepareAssignments-----------------------------------------------------------------------------"
    Private Shared Function GeneratePrepareAssignments(atable As O_TableInfo) As String
        Dim sb As New Text.StringBuilder()

        For Each col In atable.Columns
            sb.AppendLine($"    d(""@{col.Name}"") = {col.Name}")
        Next

        Return sb.ToString()
    End Function
#End Region

#Region "   GenerateInsertColumns-----------------------------------------------------------------------------"
    Private Shared Function GenerateInsertColumns(atable As O_TableInfo) As String
        Return String.Join(", ", atable.Columns.Where(Function(c) Not c.IsPrimaryKey).Select(Function(c) c.Name))
    End Function
#End Region

#Region "   GenerateInsertParams-----------------------------------------------------------------------------"
    Private Shared Function GenerateInsertParams(atable As O_TableInfo) As String
        Return String.Join(", ", atable.Columns.Where(Function(c) Not c.IsPrimaryKey).Select(Function(c) "@" & c.Name))
    End Function
#End Region

#Region "   GenerateUpdateAssignments-----------------------------------------------------------------------------"
    Private Shared Function GenerateUpdateAssignments(atable As O_TableInfo) As String
        Return String.Join(", ", atable.Columns.Where(Function(c) Not c.IsPrimaryKey).Select(Function(c) c.Name & " = @" & c.Name))
    End Function
#End Region
End Class
