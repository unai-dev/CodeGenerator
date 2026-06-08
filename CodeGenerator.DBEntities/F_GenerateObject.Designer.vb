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
        Me.pcBottom = New DevExpress.XtraEditors.PanelControl()
        Me.btnGenerateClass = New DevExpress.XtraEditors.SimpleButton()
        Me.gcMain = New DevExpress.XtraEditors.GroupControl()
        Me.liColumns = New DevExpress.XtraEditors.ListBoxControl()
        Me.lblSelectTable = New DevExpress.XtraEditors.LabelControl()
        Me.cboTables = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.pcTop = New DevExpress.XtraEditors.PanelControl()
        Me.txtCodePreview = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.pcBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcBottom.SuspendLayout()
        CType(Me.gcMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcMain.SuspendLayout()
        CType(Me.liColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTables.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcTop.SuspendLayout()
        CType(Me.txtCodePreview.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pcBottom
        '
        Me.pcBottom.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pcBottom.Appearance.Options.UseFont = True
        Me.pcBottom.Appearance.Options.UseTextOptions = True
        Me.pcBottom.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.pcBottom.Controls.Add(Me.btnGenerateClass)
        Me.pcBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pcBottom.Location = New System.Drawing.Point(0, 400)
        Me.pcBottom.Name = "pcBottom"
        Me.pcBottom.Size = New System.Drawing.Size(800, 50)
        Me.pcBottom.TabIndex = 1
        '
        'btnGenerateClass
        '
        Me.btnGenerateClass.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateClass.Appearance.Options.UseFont = True
        Me.btnGenerateClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnGenerateClass.ImageOptions.SvgImage = CType(resources.GetObject("btnGenerateClass.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnGenerateClass.Location = New System.Drawing.Point(2, 2)
        Me.btnGenerateClass.Name = "btnGenerateClass"
        Me.btnGenerateClass.Size = New System.Drawing.Size(796, 46)
        Me.btnGenerateClass.TabIndex = 0
        Me.btnGenerateClass.Text = "Generar clase"
        '
        'gcMain
        '
        Me.gcMain.Controls.Add(Me.txtCodePreview)
        Me.gcMain.Controls.Add(Me.liColumns)
        Me.gcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcMain.Location = New System.Drawing.Point(0, 70)
        Me.gcMain.Name = "gcMain"
        Me.gcMain.Size = New System.Drawing.Size(800, 330)
        Me.gcMain.TabIndex = 2
        Me.gcMain.Text = "Vista previa del codigo generado"
        '
        'liColumns
        '
        Me.liColumns.Dock = System.Windows.Forms.DockStyle.Right
        Me.liColumns.Location = New System.Drawing.Point(678, 23)
        Me.liColumns.Name = "liColumns"
        Me.liColumns.Size = New System.Drawing.Size(120, 305)
        Me.liColumns.TabIndex = 0
        '
        'lblSelectTable
        '
        Me.lblSelectTable.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectTable.Appearance.Options.UseFont = True
        Me.lblSelectTable.Location = New System.Drawing.Point(12, 12)
        Me.lblSelectTable.Name = "lblSelectTable"
        Me.lblSelectTable.Size = New System.Drawing.Size(42, 21)
        Me.lblSelectTable.TabIndex = 0
        Me.lblSelectTable.Text = "Tabla"
        '
        'cboTables
        '
        Me.cboTables.Location = New System.Drawing.Point(60, 12)
        Me.cboTables.MinimumSize = New System.Drawing.Size(300, 0)
        Me.cboTables.Name = "cboTables"
        Me.cboTables.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboTables.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTables.Properties.Appearance.Options.UseFont = True
        Me.cboTables.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTables.Size = New System.Drawing.Size(300, 24)
        Me.cboTables.TabIndex = 1
        '
        'pcTop
        '
        Me.pcTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.pcTop.Controls.Add(Me.cboTables)
        Me.pcTop.Controls.Add(Me.lblSelectTable)
        Me.pcTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pcTop.Location = New System.Drawing.Point(0, 0)
        Me.pcTop.Name = "pcTop"
        Me.pcTop.Size = New System.Drawing.Size(800, 70)
        Me.pcTop.TabIndex = 0
        '
        'txtCodePreview
        '
        Me.txtCodePreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodePreview.Location = New System.Drawing.Point(2, 23)
        Me.txtCodePreview.Name = "txtCodePreview"
        Me.txtCodePreview.Size = New System.Drawing.Size(676, 305)
        Me.txtCodePreview.TabIndex = 1
        '
        'F_GenerateObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.gcMain)
        Me.Controls.Add(Me.pcBottom)
        Me.Controls.Add(Me.pcTop)
        Me.Name = "F_GenerateObject"
        Me.Text = "Generar Objeto"
        CType(Me.pcBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcBottom.ResumeLayout(False)
        CType(Me.gcMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcMain.ResumeLayout(False)
        CType(Me.liColumns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTables.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcTop.ResumeLayout(False)
        Me.pcTop.PerformLayout()
        CType(Me.txtCodePreview.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pcBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gcMain As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnGenerateClass As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents liColumns As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents lblSelectTable As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboTables As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents pcTop As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtCodePreview As DevExpress.XtraEditors.MemoEdit
End Class
