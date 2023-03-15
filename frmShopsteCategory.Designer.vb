<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShopsteCategory
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
        Me.components = New System.ComponentModel.Container()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeueKategorieAnlegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KategorieUmbennenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnKategorieZuordnen = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeView1.HideSelection = False
        Me.TreeView1.Location = New System.Drawing.Point(481, 72)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(422, 453)
        Me.TreeView1.TabIndex = 1
        Me.TreeView1.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeueKategorieAnlegenToolStripMenuItem, Me.KategorieUmbennenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(210, 48)
        '
        'NeueKategorieAnlegenToolStripMenuItem
        '
        Me.NeueKategorieAnlegenToolStripMenuItem.Name = "NeueKategorieAnlegenToolStripMenuItem"
        Me.NeueKategorieAnlegenToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.NeueKategorieAnlegenToolStripMenuItem.Text = "Neue Kategorie anlegen..."
        '
        'KategorieUmbennenToolStripMenuItem
        '
        Me.KategorieUmbennenToolStripMenuItem.Name = "KategorieUmbennenToolStripMenuItem"
        Me.KategorieUmbennenToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.KategorieUmbennenToolStripMenuItem.Text = "Kategorie umbennen..."
        '
        'TreeView2
        '
        Me.TreeView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView2.HideSelection = False
        Me.TreeView2.Location = New System.Drawing.Point(15, 72)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(434, 453)
        Me.TreeView2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 554)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(478, 554)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(480, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(203, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "SubShop Kategorien"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(305, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Shopste Marktplatz - Kategorien"
        '
        'btnKategorieZuordnen
        '
        Me.btnKategorieZuordnen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnKategorieZuordnen.BackColor = System.Drawing.Color.PapayaWhip
        Me.btnKategorieZuordnen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKategorieZuordnen.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKategorieZuordnen.Location = New System.Drawing.Point(481, 588)
        Me.btnKategorieZuordnen.Margin = New System.Windows.Forms.Padding(2)
        Me.btnKategorieZuordnen.Name = "btnKategorieZuordnen"
        Me.btnKategorieZuordnen.Size = New System.Drawing.Size(269, 26)
        Me.btnKategorieZuordnen.TabIndex = 7
        Me.btnKategorieZuordnen.Text = "Kategorie zuordnen"
        Me.btnKategorieZuordnen.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.PapayaWhip
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(754, 588)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(162, 26)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Abbrechen"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(481, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(422, 34)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Mit rechter Maustaste auf einen Knotenpunkt können Sie z.B. direkt in Ihren Subsh" &
    "op Unterkategorien anlegen"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(13, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(422, 34)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Wenn Sie hier eine Kategorie auswählen wird Ihr Artikel im Shopste Marktplatz ein" &
    "gestellt."
        '
        'frmShopsteCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 625)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnKategorieZuordnen)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TreeView2)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "frmShopsteCategory"
        Me.Text = "Kategorie Zuordnung"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnKategorieZuordnen As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NeueKategorieAnlegenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KategorieUmbennenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
