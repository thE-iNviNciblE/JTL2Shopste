<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÜbersetzungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlleJTLWawiArtikelLadenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeereÜbersetzungenAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.FehlendeSpracheigenschaftenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttributeÜbersetzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ÜbersetzerEinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatenbankverbindungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgrammupdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShopsteLoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CubssnetWebseiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CubssnetKontaktToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbJTLShops = New System.Windows.Forms.ComboBox()
        Me.chkKategorieArtikel = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbZielSpache = New System.Windows.Forms.ComboBox()
        Me.lvwArtikel_kategorien = New System.Windows.Forms.ListView()
        Me.colCatID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCatName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCatNameEN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCatBeschreibung = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCatBeschreibungEN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colShopsteID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.conMKategorie = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlleKategorienÜbersetzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.JTLKategorienShopsteImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShopsteKategorieZuordnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbMandant = New System.Windows.Forms.ComboBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.msgMaster = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Zeichenzähler = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnÜbertrage = New System.Windows.Forms.Button()
        Me.lvwMainData = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Name_de = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Name_eng = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Kurzbeschreibung_de = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Beschreibung_de = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Kurzbeschreibung_eng = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Beschreibung_eng = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ID_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHasKombination = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPreis = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMenge = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHauptBild = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMenüID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArtikelnummer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMwSt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colGewicht = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colShopsteCAT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAufpreis = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.con2Shopste = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AllesMarkierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ÜbersetzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BezeichnungKopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KurzbeschreibungKopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeschreibungKopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArtikelnummerKopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.conMKategorie.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.con2Shopste.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.EinstellungenToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1056, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'BeeendenToolStripMenuItem
        '
        Me.BeeendenToolStripMenuItem.Name = "BeeendenToolStripMenuItem"
        Me.BeeendenToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.BeeendenToolStripMenuItem.Text = "&Beeenden"
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÜbersetzungToolStripMenuItem, Me.ToolStripSeparator4, Me.AlleJTLWawiArtikelLadenToolStripMenuItem, Me.ToolStripMenuItem3, Me.LeereÜbersetzungenAnzeigenToolStripMenuItem, Me.ToolStripSeparator5, Me.FehlendeSpracheigenschaftenToolStripMenuItem, Me.AttributeÜbersetzenToolStripMenuItem, Me.ToolStripSeparator6, Me.ÜbersetzerEinstellungenToolStripMenuItem, Me.DatenbankverbindungToolStripMenuItem, Me.ProgrammupdateToolStripMenuItem, Me.ShopsteLoginToolStripMenuItem})
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.EinstellungenToolStripMenuItem.Text = "Einstellungen"
        '
        'ÜbersetzungToolStripMenuItem
        '
        Me.ÜbersetzungToolStripMenuItem.Name = "ÜbersetzungToolStripMenuItem"
        Me.ÜbersetzungToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ÜbersetzungToolStripMenuItem.Text = "Übersetzung"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(299, 6)
        '
        'AlleJTLWawiArtikelLadenToolStripMenuItem
        '
        Me.AlleJTLWawiArtikelLadenToolStripMenuItem.Checked = True
        Me.AlleJTLWawiArtikelLadenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AlleJTLWawiArtikelLadenToolStripMenuItem.Name = "AlleJTLWawiArtikelLadenToolStripMenuItem"
        Me.AlleJTLWawiArtikelLadenToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.AlleJTLWawiArtikelLadenToolStripMenuItem.Text = "Alle JTL Wawi Artikel laden"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Enabled = False
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(302, 22)
        Me.ToolStripMenuItem3.Text = "Reparatur leere Übersetzungen"
        '
        'LeereÜbersetzungenAnzeigenToolStripMenuItem
        '
        Me.LeereÜbersetzungenAnzeigenToolStripMenuItem.Name = "LeereÜbersetzungenAnzeigenToolStripMenuItem"
        Me.LeereÜbersetzungenAnzeigenToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.LeereÜbersetzungenAnzeigenToolStripMenuItem.Text = "Leere Übersetzungen anzeigen"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(299, 6)
        '
        'FehlendeSpracheigenschaftenToolStripMenuItem
        '
        Me.FehlendeSpracheigenschaftenToolStripMenuItem.Name = "FehlendeSpracheigenschaftenToolStripMenuItem"
        Me.FehlendeSpracheigenschaftenToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.FehlendeSpracheigenschaftenToolStripMenuItem.Text = "Fehlende Artikeleigenschaften übersetzen..."
        Me.FehlendeSpracheigenschaftenToolStripMenuItem.Visible = False
        '
        'AttributeÜbersetzenToolStripMenuItem
        '
        Me.AttributeÜbersetzenToolStripMenuItem.Name = "AttributeÜbersetzenToolStripMenuItem"
        Me.AttributeÜbersetzenToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.AttributeÜbersetzenToolStripMenuItem.Text = "Fehlende Merkmale übersetzen..."
        Me.AttributeÜbersetzenToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(299, 6)
        Me.ToolStripSeparator6.Visible = False
        '
        'ÜbersetzerEinstellungenToolStripMenuItem
        '
        Me.ÜbersetzerEinstellungenToolStripMenuItem.Name = "ÜbersetzerEinstellungenToolStripMenuItem"
        Me.ÜbersetzerEinstellungenToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ÜbersetzerEinstellungenToolStripMenuItem.Text = "Übersetzer Einstellungen..."
        '
        'DatenbankverbindungToolStripMenuItem
        '
        Me.DatenbankverbindungToolStripMenuItem.Name = "DatenbankverbindungToolStripMenuItem"
        Me.DatenbankverbindungToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.DatenbankverbindungToolStripMenuItem.Text = "&Datenbankverbindung..."
        '
        'ProgrammupdateToolStripMenuItem
        '
        Me.ProgrammupdateToolStripMenuItem.Name = "ProgrammupdateToolStripMenuItem"
        Me.ProgrammupdateToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ProgrammupdateToolStripMenuItem.Text = "Programmupdate..."
        '
        'ShopsteLoginToolStripMenuItem
        '
        Me.ShopsteLoginToolStripMenuItem.Name = "ShopsteLoginToolStripMenuItem"
        Me.ShopsteLoginToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ShopsteLoginToolStripMenuItem.Text = "Shopste Login..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CubssnetWebseiteToolStripMenuItem, Me.CubssnetKontaktToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(24, 20)
        Me.ToolStripMenuItem1.Text = "?"
        '
        'CubssnetWebseiteToolStripMenuItem
        '
        Me.CubssnetWebseiteToolStripMenuItem.Name = "CubssnetWebseiteToolStripMenuItem"
        Me.CubssnetWebseiteToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.CubssnetWebseiteToolStripMenuItem.Text = "Cubss.net Webseite..."
        '
        'CubssnetKontaktToolStripMenuItem
        '
        Me.CubssnetKontaktToolStripMenuItem.Name = "CubssnetKontaktToolStripMenuItem"
        Me.CubssnetKontaktToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.CubssnetKontaktToolStripMenuItem.Text = "Cubss.net Kontakt..."
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1056, 533)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmbJTLShops)
        Me.TabPage1.Controls.Add(Me.chkKategorieArtikel)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cmbZielSpache)
        Me.TabPage1.Controls.Add(Me.lvwArtikel_kategorien)
        Me.TabPage1.Controls.Add(Me.cmbMandant)
        Me.TabPage1.Controls.Add(Me.lblHeader)
        Me.TabPage1.Controls.Add(Me.StatusStrip1)
        Me.TabPage1.Controls.Add(Me.btnÜbertrage)
        Me.TabPage1.Controls.Add(Me.lvwMainData)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1048, 507)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Manueller Modus"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(484, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "JTL Shops"
        '
        'cmbJTLShops
        '
        Me.cmbJTLShops.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJTLShops.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbJTLShops.FormattingEnabled = True
        Me.cmbJTLShops.Location = New System.Drawing.Point(487, 34)
        Me.cmbJTLShops.Name = "cmbJTLShops"
        Me.cmbJTLShops.Size = New System.Drawing.Size(196, 21)
        Me.cmbJTLShops.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.cmbJTLShops, "Sprache in die der Artikel / Kategorie übersetzt werden soll.")
        '
        'chkKategorieArtikel
        '
        Me.chkKategorieArtikel.AutoSize = True
        Me.chkKategorieArtikel.Location = New System.Drawing.Point(559, 69)
        Me.chkKategorieArtikel.Name = "chkKategorieArtikel"
        Me.chkKategorieArtikel.Size = New System.Drawing.Size(82, 17)
        Me.chkKategorieArtikel.TabIndex = 19
        Me.chkKategorieArtikel.Text = "Lade Artikel"
        Me.chkKategorieArtikel.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(276, 65)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(264, 23)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "Kategorie zuordnen"
        Me.ToolTip1.SetToolTip(Me.Button3, "Zeigt alle fehlenden Übersetzungen der Zielsprache an.")
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(3, 34)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(267, 23)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Menü laden"
        Me.ToolTip1.SetToolTip(Me.Button2, "Zeigt alle fehlenden Übersetzungen der Zielsprache an.")
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(6, 63)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(264, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Menü Übertragen"
        Me.ToolTip1.SetToolTip(Me.Button1, "Zeigt alle fehlenden Übersetzungen der Zielsprache an.")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(689, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Mandant auswählen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(270, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Zielsprache auswählen"
        '
        'cmbZielSpache
        '
        Me.cmbZielSpache.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZielSpache.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbZielSpache.FormattingEnabled = True
        Me.cmbZielSpache.Location = New System.Drawing.Point(273, 39)
        Me.cmbZielSpache.Name = "cmbZielSpache"
        Me.cmbZielSpache.Size = New System.Drawing.Size(196, 21)
        Me.cmbZielSpache.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmbZielSpache, "Sprache in die der Artikel / Kategorie übersetzt werden soll.")
        '
        'lvwArtikel_kategorien
        '
        Me.lvwArtikel_kategorien.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwArtikel_kategorien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwArtikel_kategorien.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCatID, Me.colCatName, Me.colCatNameEN, Me.colCatBeschreibung, Me.colCatBeschreibungEN, Me.colShopsteID})
        Me.lvwArtikel_kategorien.ContextMenuStrip = Me.conMKategorie
        Me.lvwArtikel_kategorien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lvwArtikel_kategorien.FullRowSelect = True
        Me.lvwArtikel_kategorien.GridLines = True
        Me.lvwArtikel_kategorien.HideSelection = False
        Me.lvwArtikel_kategorien.Location = New System.Drawing.Point(3, 94)
        Me.lvwArtikel_kategorien.Name = "lvwArtikel_kategorien"
        Me.lvwArtikel_kategorien.Size = New System.Drawing.Size(264, 384)
        Me.lvwArtikel_kategorien.TabIndex = 7
        Me.lvwArtikel_kategorien.UseCompatibleStateImageBehavior = False
        Me.lvwArtikel_kategorien.View = System.Windows.Forms.View.Details
        '
        'colCatID
        '
        Me.colCatID.Text = "ID"
        Me.colCatID.Width = 0
        '
        'colCatName
        '
        Me.colCatName.Text = "Kategoriename"
        Me.colCatName.Width = 460
        '
        'colCatNameEN
        '
        Me.colCatNameEN.Text = "Kategoriename (eng)"
        '
        'colCatBeschreibung
        '
        Me.colCatBeschreibung.Text = "Beschreibung"
        '
        'colCatBeschreibungEN
        '
        Me.colCatBeschreibungEN.Text = "Beschreibung EN"
        '
        'colShopsteID
        '
        Me.colShopsteID.Text = "ShopsteID"
        '
        'conMKategorie
        '
        Me.conMKategorie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.AlleKategorienÜbersetzenToolStripMenuItem, Me.ToolStripSeparator7, Me.JTLKategorienShopsteImportToolStripMenuItem, Me.ToolStripSeparator2, Me.ShopsteKategorieZuordnenToolStripMenuItem})
        Me.conMKategorie.Name = "conMKategorie"
        Me.conMKategorie.Size = New System.Drawing.Size(252, 104)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(251, 22)
        Me.ToolStripMenuItem2.Text = "Kategorie selektierte übersetzen"
        '
        'AlleKategorienÜbersetzenToolStripMenuItem
        '
        Me.AlleKategorienÜbersetzenToolStripMenuItem.Name = "AlleKategorienÜbersetzenToolStripMenuItem"
        Me.AlleKategorienÜbersetzenToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.AlleKategorienÜbersetzenToolStripMenuItem.Text = "Alle Kategorien übersetzen"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(248, 6)
        '
        'JTLKategorienShopsteImportToolStripMenuItem
        '
        Me.JTLKategorienShopsteImportToolStripMenuItem.Name = "JTLKategorienShopsteImportToolStripMenuItem"
        Me.JTLKategorienShopsteImportToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.JTLKategorienShopsteImportToolStripMenuItem.Text = "JTL Kategorien -> Shopste Import"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(248, 6)
        '
        'ShopsteKategorieZuordnenToolStripMenuItem
        '
        Me.ShopsteKategorieZuordnenToolStripMenuItem.Name = "ShopsteKategorieZuordnenToolStripMenuItem"
        Me.ShopsteKategorieZuordnenToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.ShopsteKategorieZuordnenToolStripMenuItem.Text = "Shopste Kategorie zuordnen"
        '
        'cmbMandant
        '
        Me.cmbMandant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMandant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMandant.FormattingEnabled = True
        Me.cmbMandant.Location = New System.Drawing.Point(692, 38)
        Me.cmbMandant.Name = "cmbMandant"
        Me.cmbMandant.Size = New System.Drawing.Size(194, 21)
        Me.cmbMandant.TabIndex = 6
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(8, 8)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(188, 23)
        Me.lblHeader.TabIndex = 5
        Me.lblHeader.Text = "JTL2Shopste 1.x"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.msgMaster, Me.ToolStripStatusLabel1, Me.Zeichenzähler})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 482)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1042, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(500, 16)
        Me.ToolStripProgressBar1.Visible = False
        '
        'msgMaster
        '
        Me.msgMaster.Name = "msgMaster"
        Me.msgMaster.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Zeichenzähler
        '
        Me.Zeichenzähler.Name = "Zeichenzähler"
        Me.Zeichenzähler.Size = New System.Drawing.Size(0, 17)
        '
        'btnÜbertrage
        '
        Me.btnÜbertrage.BackColor = System.Drawing.Color.PeachPuff
        Me.btnÜbertrage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnÜbertrage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnÜbertrage.Location = New System.Drawing.Point(877, 50)
        Me.btnÜbertrage.Name = "btnÜbertrage"
        Me.btnÜbertrage.Size = New System.Drawing.Size(168, 23)
        Me.btnÜbertrage.TabIndex = 1
        Me.btnÜbertrage.Text = "Quick-Sync"
        Me.ToolTip1.SetToolTip(Me.btnÜbertrage, "Zeigt alle fehlenden Übersetzungen der Zielsprache an.")
        Me.btnÜbertrage.UseVisualStyleBackColor = False
        '
        'lvwMainData
        '
        Me.lvwMainData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwMainData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwMainData.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.Name_de, Me.Name_eng, Me.Kurzbeschreibung_de, Me.Beschreibung_de, Me.Kurzbeschreibung_eng, Me.Beschreibung_eng, Me.ID_ID, Me.colHasKombination, Me.colPreis, Me.colMenge, Me.colHauptBild, Me.colMenüID, Me.colArtikelnummer, Me.colMwSt, Me.colGewicht, Me.colShopsteCAT, Me.colAufpreis})
        Me.lvwMainData.ContextMenuStrip = Me.con2Shopste
        Me.lvwMainData.FullRowSelect = True
        Me.lvwMainData.GridLines = True
        Me.lvwMainData.HideSelection = False
        Me.lvwMainData.Location = New System.Drawing.Point(273, 94)
        Me.lvwMainData.Name = "lvwMainData"
        Me.lvwMainData.Size = New System.Drawing.Size(767, 385)
        Me.lvwMainData.TabIndex = 0
        Me.lvwMainData.UseCompatibleStateImageBehavior = False
        Me.lvwMainData.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = "ID"
        '
        'Name_de
        '
        Me.Name_de.Text = "Quellsprache Titel deutsch"
        Me.Name_de.Width = 203
        '
        'Name_eng
        '
        Me.Name_eng.DisplayIndex = 3
        Me.Name_eng.Text = "Zielsprache Titel"
        Me.Name_eng.Width = 224
        '
        'Kurzbeschreibung_de
        '
        Me.Kurzbeschreibung_de.DisplayIndex = 4
        Me.Kurzbeschreibung_de.Text = "Kurzbeschreibung"
        Me.Kurzbeschreibung_de.Width = 200
        '
        'Beschreibung_de
        '
        Me.Beschreibung_de.DisplayIndex = 6
        Me.Beschreibung_de.Text = "Beschreibung DE"
        Me.Beschreibung_de.Width = 189
        '
        'Kurzbeschreibung_eng
        '
        Me.Kurzbeschreibung_eng.Text = "Kurzbeschreibung Zielsprache"
        Me.Kurzbeschreibung_eng.Width = 127
        '
        'Beschreibung_eng
        '
        Me.Beschreibung_eng.DisplayIndex = 7
        Me.Beschreibung_eng.Text = "Beschreibung Zielsprache"
        '
        'ID_ID
        '
        Me.ID_ID.DisplayIndex = 8
        Me.ID_ID.Text = "ID"
        '
        'colHasKombination
        '
        Me.colHasKombination.DisplayIndex = 2
        Me.colHasKombination.Text = "Kombination"
        Me.colHasKombination.Width = 105
        '
        'colPreis
        '
        Me.colPreis.Text = "Preis"
        '
        'colMenge
        '
        Me.colMenge.Text = "Menge"
        '
        'colHauptBild
        '
        Me.colHauptBild.Text = "Bild"
        '
        'colMenüID
        '
        Me.colMenüID.Text = "Menüs"
        '
        'colArtikelnummer
        '
        Me.colArtikelnummer.Text = "Artikelnummer"
        '
        'colMwSt
        '
        Me.colMwSt.Text = "MwSt"
        '
        'colGewicht
        '
        Me.colGewicht.Text = "Gewicht"
        '
        'colShopsteCAT
        '
        Me.colShopsteCAT.Text = "Shopste Marktplatz"
        '
        'colAufpreis
        '
        Me.colAufpreis.Text = "Aufpreis"
        '
        'con2Shopste
        '
        Me.con2Shopste.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllesMarkierenToolStripMenuItem, Me.ToolStripSeparator1, Me.ÜbersetzenToolStripMenuItem, Me.ToolStripSeparator3, Me.BezeichnungKopierenToolStripMenuItem, Me.KurzbeschreibungKopierenToolStripMenuItem, Me.BeschreibungKopierenToolStripMenuItem, Me.ArtikelnummerKopierenToolStripMenuItem, Me.ToolStripMenuItem4})
        Me.con2Shopste.Name = "ContextMenuStrip1"
        Me.con2Shopste.Size = New System.Drawing.Size(219, 170)
        '
        'AllesMarkierenToolStripMenuItem
        '
        Me.AllesMarkierenToolStripMenuItem.Name = "AllesMarkierenToolStripMenuItem"
        Me.AllesMarkierenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AllesMarkierenToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.AllesMarkierenToolStripMenuItem.Text = "Alles markieren"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(215, 6)
        '
        'ÜbersetzenToolStripMenuItem
        '
        Me.ÜbersetzenToolStripMenuItem.Name = "ÜbersetzenToolStripMenuItem"
        Me.ÜbersetzenToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ÜbersetzenToolStripMenuItem.Text = "Artikel übertragen"
        Me.ÜbersetzenToolStripMenuItem.ToolTipText = "Sie können einen oder mehrere Artikel durch Auswahl übersetzen"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(215, 6)
        '
        'BezeichnungKopierenToolStripMenuItem
        '
        Me.BezeichnungKopierenToolStripMenuItem.Name = "BezeichnungKopierenToolStripMenuItem"
        Me.BezeichnungKopierenToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.BezeichnungKopierenToolStripMenuItem.Text = "Bezeichnung kopieren"
        '
        'KurzbeschreibungKopierenToolStripMenuItem
        '
        Me.KurzbeschreibungKopierenToolStripMenuItem.Name = "KurzbeschreibungKopierenToolStripMenuItem"
        Me.KurzbeschreibungKopierenToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.KurzbeschreibungKopierenToolStripMenuItem.Text = "Kurzbeschreibung kopieren"
        '
        'BeschreibungKopierenToolStripMenuItem
        '
        Me.BeschreibungKopierenToolStripMenuItem.Name = "BeschreibungKopierenToolStripMenuItem"
        Me.BeschreibungKopierenToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.BeschreibungKopierenToolStripMenuItem.Text = "Beschreibung kopieren"
        '
        'ArtikelnummerKopierenToolStripMenuItem
        '
        Me.ArtikelnummerKopierenToolStripMenuItem.Name = "ArtikelnummerKopierenToolStripMenuItem"
        Me.ArtikelnummerKopierenToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ArtikelnummerKopierenToolStripMenuItem.Text = "Artikelnummer kopieren"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(218, 22)
        Me.ToolStripMenuItem4.Text = "Kategorie zuordnen"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 250
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 557)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "JTL2Shopste v.1.x"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.conMKategorie.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.con2Shopste.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EinstellungenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatenbankverbindungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lvwMainData As System.Windows.Forms.ListView
    Friend WithEvents ID As System.Windows.Forms.ColumnHeader
    Friend WithEvents Name_de As System.Windows.Forms.ColumnHeader
    Friend WithEvents Name_eng As System.Windows.Forms.ColumnHeader
    Friend WithEvents Kurzbeschreibung_de As System.Windows.Forms.ColumnHeader
    Friend WithEvents Beschreibung_de As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnÜbertrage As System.Windows.Forms.Button
    Friend WithEvents Kurzbeschreibung_eng As System.Windows.Forms.ColumnHeader
    Friend WithEvents Beschreibung_eng As System.Windows.Forms.ColumnHeader
    Friend WithEvents con2Shopste As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AllesMarkierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ÜbersetzenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ID_ID As System.Windows.Forms.ColumnHeader
    Friend WithEvents ÜbersetzungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents msgMaster As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbMandant As System.Windows.Forms.ComboBox
    Friend WithEvents lvwArtikel_kategorien As System.Windows.Forms.ListView
    Friend WithEvents colCatID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCatName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ProgrammupdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BezeichnungKopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KurzbeschreibungKopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeschreibungKopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CubssnetWebseiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CubssnetKontaktToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colCatNameEN As System.Windows.Forms.ColumnHeader
    Friend WithEvents ArtikelnummerKopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents conMKategorie As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colCatBeschreibung As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCatBeschreibungEN As System.Windows.Forms.ColumnHeader
    Friend WithEvents AlleKategorienÜbersetzenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbZielSpache As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FehlendeSpracheigenschaftenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AttributeÜbersetzenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents AlleJTLWawiArtikelLadenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents colHasKombination As ColumnHeader
    Friend WithEvents LeereÜbersetzungenAnzeigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ÜbersetzerEinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Zeichenzähler As ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents JTLKategorienShopsteImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShopsteLoginToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents colPreis As ColumnHeader
    Friend WithEvents colMenge As ColumnHeader
    Friend WithEvents colHauptBild As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents colMenüID As ColumnHeader
    Friend WithEvents colArtikelnummer As ColumnHeader
    Friend WithEvents colMwSt As ColumnHeader
    Friend WithEvents colGewicht As ColumnHeader
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ShopsteKategorieZuordnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button3 As Button
    Friend WithEvents chkKategorieArtikel As CheckBox
    Friend WithEvents colShopsteID As ColumnHeader
    Friend WithEvents colShopsteCAT As ColumnHeader
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbJTLShops As ComboBox
    Friend WithEvents colAufpreis As ColumnHeader
End Class
