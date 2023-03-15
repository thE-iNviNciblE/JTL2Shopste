<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJTLSpracheigenschaften
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstSpracheigenschaften = New System.Windows.Forms.ListView()
        Me.colJTLSpracheigenschaft = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAnzahl = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstSpracheigenschaften
        '
        Me.lstSpracheigenschaften.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSpracheigenschaften.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSpracheigenschaften.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colJTLSpracheigenschaft, Me.colAnzahl})
        Me.lstSpracheigenschaften.FullRowSelect = True
        Me.lstSpracheigenschaften.Location = New System.Drawing.Point(12, 79)
        Me.lstSpracheigenschaften.Name = "lstSpracheigenschaften"
        Me.lstSpracheigenschaften.Size = New System.Drawing.Size(948, 478)
        Me.lstSpracheigenschaften.TabIndex = 0
        Me.lstSpracheigenschaften.UseCompatibleStateImageBehavior = False
        Me.lstSpracheigenschaften.View = System.Windows.Forms.View.Details
        '
        'colJTLSpracheigenschaft
        '
        Me.colJTLSpracheigenschaft.Text = "Eigenschaft"
        Me.colJTLSpracheigenschaft.Width = 135
        '
        'colAnzahl
        '
        Me.colAnzahl.Text = "Anzahl"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 50)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Einlesen"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(163, 50)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(217, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Übersetze Eigenschaften Teil 1"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(386, 50)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(217, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Übersetze Eigenschaften Teil 2"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(609, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 4
        '
        'frmJTLSpracheigenschaften
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 569)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstSpracheigenschaften)
        Me.Name = "frmJTLSpracheigenschaften"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JTL WaWi Eigenschaften -> fehlende Sprache"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstSpracheigenschaften As System.Windows.Forms.ListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents colJTLSpracheigenschaft As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAnzahl As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
