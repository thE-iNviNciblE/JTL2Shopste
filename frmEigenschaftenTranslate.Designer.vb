<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMerkmaleübersetzen
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lstSpracheigenschaften = New System.Windows.Forms.ListView()
        Me.colJTLSpracheigenschaft = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAnzahl = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(163, 31)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(171, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Repair"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(12, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Einlesen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstSpracheigenschaften
        '
        Me.lstSpracheigenschaften.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSpracheigenschaften.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSpracheigenschaften.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colJTLSpracheigenschaft, Me.colAnzahl})
        Me.lstSpracheigenschaften.FullRowSelect = True
        Me.lstSpracheigenschaften.Location = New System.Drawing.Point(12, 60)
        Me.lstSpracheigenschaften.Name = "lstSpracheigenschaften"
        Me.lstSpracheigenschaften.Size = New System.Drawing.Size(839, 532)
        Me.lstSpracheigenschaften.TabIndex = 3
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
        'frmMerkmaleübersetzen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 604)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstSpracheigenschaften)
        Me.Name = "frmMerkmaleübersetzen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JTL Wawi Artikel Merkmale übersetzen"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lstSpracheigenschaften As System.Windows.Forms.ListView
    Friend WithEvents colJTLSpracheigenschaft As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAnzahl As System.Windows.Forms.ColumnHeader
End Class
