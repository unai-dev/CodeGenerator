Imports System.Configuration
Imports System.Text
Imports CodeGenerator.Core
Imports CodeGenerator.Tools
Imports DevExpress.XtraEditors
Public Class F_GenerateObject
    Private tables As New List(Of O_TableInfo)

#Region "   Load--------------------------------------------------------------------------"
    ''' <summary>
    ''' Metodo que se cargara nada mas arranque la app
    ''' Cargamos tablas y iniciamos una conexion con la base de datos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub F_GenerateObject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim cn As String = ConfigurationManager.ConnectionStrings(TOOLS_FINALS._CONNECTION_STRING).ConnectionString
            tables = MDATAREADER.GetTables(cn)

            cboTables.Properties.Items.Clear()

            For Each t In tables
                cboTables.Properties.Items.Add(t.Name)
            Next

        Catch ex As Exception
            XtraMessageBox.Show("Error al cargar tablas" & ex.Message)
        End Try
    End Sub
#End Region

#Region "   Controls--------------------------------------------------------------------------"
    ''' <summary>
    ''' Metodo que se ejecuta cuando el indice del combo cambia
    ''' Cargara las columnas de la tabla selecionada
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cboTables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTables.SelectedIndexChanged
        Dim selectedTable As String = cboTables.SelectedItem.ToString()
        Dim table = tables.First(Function(t) t.Name = selectedTable)
        Dim code As String = CLASS_GENERATOR.GenerateEntityClass(table)
        txtCodePreview.Text = code

        For Each c In table.Columns
            liColumns.Items.Add(c.Name)
        Next
    End Sub

    ''' <summary>
    ''' Metodo que se ejecuta cuando el usuario hace clic para generar una clase
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnGenerateClass_Click(sender As Object, e As EventArgs) Handles btnGenerateClass.Click
        If cboTables.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona una tabla porfavor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim tableName As String = cboTables.SelectedItem.ToString()
        Dim table = tables.First(Function(t) t.Name = tableName)

        Dim code = CLASS_GENERATOR.GenerateEntityClass(table)
        Dim route = IO.Path.Combine(TOOLS_FINALS._ROUTE, $"O_{tableName}.vb")

        IO.File.WriteAllText(route, code, Encoding.UTF8)

        MessageBox.Show($"Objeto generado correctamente. {TOOLS_FINALS._ROUTE} ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.None)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region
End Class
