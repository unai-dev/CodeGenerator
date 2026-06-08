<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_GenerateObject
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_GenerateObject))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnGenerateClass = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.liColumns = New DevExpress.XtraEditors.ListBoxControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboTables = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.liColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTables.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelControl2.Appearance.Options.UseFont = True
        Me.PanelControl2.Appearance.Options.UseTextOptions = True
        Me.PanelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.PanelControl2.Controls.Add(Me.btnGenerateClass)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 350)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(800, 100)
        Me.PanelControl2.TabIndex = 1
        '
        'btnGenerateClass
        '
        Me.btnGenerateClass.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateClass.Appearance.Options.UseFont = True
        Me.btnGenerateClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnGenerateClass.ImageOptions.SvgImage = CType(resources.GetObject("btnGenerateClass.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnGenerateClass.Location = New System.Drawing.Point(2, 2)
        Me.btnGenerateClass.Name = "btnGenerateClass"
        Me.btnGenerateClass.Size = New System.Drawing.Size(796, 96)
        Me.btnGenerateClass.TabIndex = 0
        Me.btnGenerateClass.Text = "Generar clase"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.liColumns)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 70)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(800, 280)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Vista previa del codigo generado"
        '
        'liColumns
        '
        Me.liColumns.Dock = System.Windows.Forms.DockStyle.Right
        Me.liColumns.Location = New System.Drawing.Point(678, 23)
        Me.liColumns.Name = "liColumns"
        Me.liColumns.Size = New System.Drawing.Size(120, 255)
        Me.liColumns.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(42, 21)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Tabla"
        '
        'cboTables
        '
        Me.cboTables.Location = New System.Drawing.Point(60, 12)
        Me.cboTables.Name = "cboTables"
        Me.cboTables.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboTables.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTables.Properties.Appearance.Options.UseFont = True
        Me.cboTables.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTables.Size = New System.Drawing.Size(178, 24)
        Me.cboTables.TabIndex = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.cboTables)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(800, 70)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 42)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(94, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Tabla seleccionada:"
        '
        'F_GenerateObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "F_GenerateObject"
        Me.Text = "Generar Objeto"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.liColumns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTables.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnGenerateClass As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents liColumns As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboTables As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
