<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTranslateVorschau
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTranslateVorschau))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chkKurzbeschreibungDE = New System.Windows.Forms.CheckBox()
        Me.AxDHTMLEdit1 = New AxDHTMLEDLib.AxDHTMLEdit()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NeuToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ÖffnenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SpeichernToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.DruckenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.AusschneidenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.KopierenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.EinfügenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Bold = New System.Windows.Forms.ToolStripButton()
        Me.Hyperlink = New System.Windows.Forms.ToolStripButton()
        Me.Suchen = New System.Windows.Forms.ToolStripButton()
        Me.Bild = New System.Windows.Forms.ToolStripButton()
        Me.Redo = New System.Windows.Forms.ToolStripButton()
        Me.Undo = New System.Windows.Forms.ToolStripButton()
        Me.tabelle = New System.Windows.Forms.ToolStripButton()
        Me.lblProduktbezeichnung = New System.Windows.Forms.Label()
        Me.txtDeutsch = New System.Windows.Forms.TextBox()
        Me.DHTMLControll1 = New AxDHTMLEDLib.AxDHTMLEdit()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton15 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton16 = New System.Windows.Forms.ToolStripButton()
        Me.lblProduktbezeichnungEnglisch = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.txtEnglisch = New System.Windows.Forms.TextBox()
        Me.btnOKSpeichern = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.chkKurzbeschreibungENG = New System.Windows.Forms.CheckBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnVorherriger = New System.Windows.Forms.Button()
        Me.btnHintergrundfarbeEng = New System.Windows.Forms.Button()
        Me.MyColorPicker = New System.Windows.Forms.ColorDialog()
        Me.btnVordergrundfarbeEng = New System.Windows.Forms.Button()
        Me.btnSchriftartEng = New System.Windows.Forms.Button()
        Me.cmbFontSizeEng = New System.Windows.Forms.ComboBox()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.cmbSchriftgröße = New System.Windows.Forms.ComboBox()
        Me.btnSchriftart = New System.Windows.Forms.Button()
        Me.btnVordergrundfarbe = New System.Windows.Forms.Button()
        Me.btnHintergrundFarbe = New System.Windows.Forms.Button()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.AxDHTMLEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DHTMLControll1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnHintergrundFarbe)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnVordergrundfarbe)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSchriftart)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbSchriftgröße)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkKurzbeschreibungDE)
        Me.SplitContainer1.Panel1.Controls.Add(Me.AxDHTMLEdit1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LinkLabel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblProduktbezeichnung)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDeutsch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSchriftartEng)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbFontSizeEng)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnVordergrundfarbeEng)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkKurzbeschreibungENG)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnHintergrundfarbeEng)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DHTMLControll1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblProduktbezeichnungEnglisch)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtEnglisch)
        Me.SplitContainer1.Size = New System.Drawing.Size(887, 543)
        Me.SplitContainer1.SplitterDistance = 270
        Me.SplitContainer1.TabIndex = 0
        '
        'chkKurzbeschreibungDE
        '
        Me.chkKurzbeschreibungDE.AutoSize = True
        Me.chkKurzbeschreibungDE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkKurzbeschreibungDE.Location = New System.Drawing.Point(643, 35)
        Me.chkKurzbeschreibungDE.Name = "chkKurzbeschreibungDE"
        Me.chkKurzbeschreibungDE.Size = New System.Drawing.Size(108, 17)
        Me.chkKurzbeschreibungDE.TabIndex = 83
        Me.chkKurzbeschreibungDE.Text = "Kurzbeschreibung"
        Me.chkKurzbeschreibungDE.UseVisualStyleBackColor = True
        '
        'AxDHTMLEdit1
        '
        Me.AxDHTMLEdit1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxDHTMLEdit1.Enabled = True
        Me.AxDHTMLEdit1.Location = New System.Drawing.Point(12, 57)
        Me.AxDHTMLEdit1.Name = "AxDHTMLEdit1"
        Me.AxDHTMLEdit1.OcxState = CType(resources.GetObject("AxDHTMLEdit1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxDHTMLEdit1.Size = New System.Drawing.Size(863, 197)
        Me.AxDHTMLEdit1.TabIndex = 82
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LinkLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LinkLabel1.Location = New System.Drawing.Point(756, 39)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(119, 13)
        Me.LinkLabel1.TabIndex = 76
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Deutsche HTML Ansicht"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripButton, Me.ÖffnenToolStripButton, Me.SpeichernToolStripButton, Me.ToolStripButton1, Me.DruckenToolStripButton, Me.toolStripSeparator, Me.AusschneidenToolStripButton, Me.KopierenToolStripButton, Me.EinfügenToolStripButton, Me.toolStripSeparator2, Me.Bold, Me.Hyperlink, Me.Suchen, Me.Bild, Me.Redo, Me.Undo, Me.tabelle})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(887, 39)
        Me.ToolStrip1.TabIndex = 79
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NeuToolStripButton
        '
        Me.NeuToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NeuToolStripButton.Image = CType(resources.GetObject("NeuToolStripButton.Image"), System.Drawing.Image)
        Me.NeuToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NeuToolStripButton.Name = "NeuToolStripButton"
        Me.NeuToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.NeuToolStripButton.Text = "&Neu"
        '
        'ÖffnenToolStripButton
        '
        Me.ÖffnenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ÖffnenToolStripButton.Image = CType(resources.GetObject("ÖffnenToolStripButton.Image"), System.Drawing.Image)
        Me.ÖffnenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ÖffnenToolStripButton.Name = "ÖffnenToolStripButton"
        Me.ÖffnenToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.ÖffnenToolStripButton.Text = "Ö&ffnen"
        '
        'SpeichernToolStripButton
        '
        Me.SpeichernToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SpeichernToolStripButton.Image = CType(resources.GetObject("SpeichernToolStripButton.Image"), System.Drawing.Image)
        Me.SpeichernToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SpeichernToolStripButton.Name = "SpeichernToolStripButton"
        Me.SpeichernToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.SpeichernToolStripButton.Text = "&Speichern"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton1.Text = "Tabelle einfügen"
        '
        'DruckenToolStripButton
        '
        Me.DruckenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DruckenToolStripButton.Image = CType(resources.GetObject("DruckenToolStripButton.Image"), System.Drawing.Image)
        Me.DruckenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DruckenToolStripButton.Name = "DruckenToolStripButton"
        Me.DruckenToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.DruckenToolStripButton.Text = "&Drucken"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 39)
        '
        'AusschneidenToolStripButton
        '
        Me.AusschneidenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AusschneidenToolStripButton.Image = CType(resources.GetObject("AusschneidenToolStripButton.Image"), System.Drawing.Image)
        Me.AusschneidenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AusschneidenToolStripButton.Name = "AusschneidenToolStripButton"
        Me.AusschneidenToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.AusschneidenToolStripButton.Text = "&Ausschneiden"
        '
        'KopierenToolStripButton
        '
        Me.KopierenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.KopierenToolStripButton.Image = CType(resources.GetObject("KopierenToolStripButton.Image"), System.Drawing.Image)
        Me.KopierenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.KopierenToolStripButton.Name = "KopierenToolStripButton"
        Me.KopierenToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.KopierenToolStripButton.Text = "&Kopieren"
        '
        'EinfügenToolStripButton
        '
        Me.EinfügenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EinfügenToolStripButton.Image = CType(resources.GetObject("EinfügenToolStripButton.Image"), System.Drawing.Image)
        Me.EinfügenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EinfügenToolStripButton.Name = "EinfügenToolStripButton"
        Me.EinfügenToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.EinfügenToolStripButton.Text = "&Einfügen"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'Bold
        '
        Me.Bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Bold.Image = CType(resources.GetObject("Bold.Image"), System.Drawing.Image)
        Me.Bold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Bold.Name = "Bold"
        Me.Bold.Size = New System.Drawing.Size(36, 36)
        Me.Bold.Text = "Fett schreiben"
        '
        'Hyperlink
        '
        Me.Hyperlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Hyperlink.Image = CType(resources.GetObject("Hyperlink.Image"), System.Drawing.Image)
        Me.Hyperlink.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Hyperlink.Name = "Hyperlink"
        Me.Hyperlink.Size = New System.Drawing.Size(36, 36)
        Me.Hyperlink.Text = "Hyperlink"
        '
        'Suchen
        '
        Me.Suchen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Suchen.Image = CType(resources.GetObject("Suchen.Image"), System.Drawing.Image)
        Me.Suchen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Suchen.Name = "Suchen"
        Me.Suchen.Size = New System.Drawing.Size(36, 36)
        Me.Suchen.Text = "Suchen"
        '
        'Bild
        '
        Me.Bild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Bild.Image = CType(resources.GetObject("Bild.Image"), System.Drawing.Image)
        Me.Bild.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Bild.Name = "Bild"
        Me.Bild.Size = New System.Drawing.Size(36, 36)
        Me.Bild.Text = "Bild einfügen"
        '
        'Redo
        '
        Me.Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Redo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Redo.Name = "Redo"
        Me.Redo.Size = New System.Drawing.Size(23, 36)
        Me.Redo.Text = "Vorwärts"
        '
        'Undo
        '
        Me.Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Undo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Undo.Name = "Undo"
        Me.Undo.Size = New System.Drawing.Size(23, 36)
        Me.Undo.Text = "Zurück"
        '
        'tabelle
        '
        Me.tabelle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tabelle.Image = CType(resources.GetObject("tabelle.Image"), System.Drawing.Image)
        Me.tabelle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tabelle.Name = "tabelle"
        Me.tabelle.Size = New System.Drawing.Size(36, 36)
        Me.tabelle.Text = "Tabelle einfügen"
        '
        'lblProduktbezeichnung
        '
        Me.lblProduktbezeichnung.AutoSize = True
        Me.lblProduktbezeichnung.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduktbezeichnung.Location = New System.Drawing.Point(15, 36)
        Me.lblProduktbezeichnung.Name = "lblProduktbezeichnung"
        Me.lblProduktbezeichnung.Size = New System.Drawing.Size(0, 18)
        Me.lblProduktbezeichnung.TabIndex = 78
        '
        'txtDeutsch
        '
        Me.txtDeutsch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDeutsch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeutsch.Location = New System.Drawing.Point(12, 57)
        Me.txtDeutsch.Multiline = True
        Me.txtDeutsch.Name = "txtDeutsch"
        Me.txtDeutsch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDeutsch.Size = New System.Drawing.Size(863, 197)
        Me.txtDeutsch.TabIndex = 0
        '
        'DHTMLControll1
        '
        Me.DHTMLControll1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DHTMLControll1.Enabled = True
        Me.DHTMLControll1.Location = New System.Drawing.Point(12, 63)
        Me.DHTMLControll1.Name = "DHTMLControll1"
        Me.DHTMLControll1.OcxState = CType(resources.GetObject("DHTMLControll1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DHTMLControll1.Size = New System.Drawing.Size(863, 193)
        Me.DHTMLControll1.TabIndex = 82
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator1, Me.ToolStripButton7, Me.ToolStripButton8, Me.ToolStripButton9, Me.ToolStripSeparator3, Me.ToolStripButton10, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripButton13, Me.ToolStripButton14, Me.ToolStripButton15, Me.ToolStripButton16})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(887, 39)
        Me.ToolStrip2.TabIndex = 80
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton2.Text = "&Neu"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton3.Text = "Ö&ffnen"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton4.Text = "&Speichern"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton5.Text = "Tabelle einfügen"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton6.Text = "&Drucken"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton7.Text = "&Ausschneiden"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton8.Text = "&Kopieren"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton9.Text = "&Einfügen"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton10.Text = "Fett schreiben"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton11.Text = "Hyperlink"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton12.Text = "Suchen"
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton13.Text = "Bild einfügen"
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.Size = New System.Drawing.Size(23, 36)
        Me.ToolStripButton14.Text = "Vorwärts"
        '
        'ToolStripButton15
        '
        Me.ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton15.Name = "ToolStripButton15"
        Me.ToolStripButton15.Size = New System.Drawing.Size(23, 36)
        Me.ToolStripButton15.Text = "Zurück"
        '
        'ToolStripButton16
        '
        Me.ToolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton16.Image = CType(resources.GetObject("ToolStripButton16.Image"), System.Drawing.Image)
        Me.ToolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton16.Name = "ToolStripButton16"
        Me.ToolStripButton16.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton16.Text = "Tabelle einfügen"
        '
        'lblProduktbezeichnungEnglisch
        '
        Me.lblProduktbezeichnungEnglisch.AutoSize = True
        Me.lblProduktbezeichnungEnglisch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduktbezeichnungEnglisch.Location = New System.Drawing.Point(16, 39)
        Me.lblProduktbezeichnungEnglisch.Name = "lblProduktbezeichnungEnglisch"
        Me.lblProduktbezeichnungEnglisch.Size = New System.Drawing.Size(0, 18)
        Me.lblProduktbezeichnungEnglisch.TabIndex = 79
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LinkLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LinkLabel2.Location = New System.Drawing.Point(757, 43)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(118, 13)
        Me.LinkLabel2.TabIndex = 78
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Englische HTML Ansicht"
        '
        'txtEnglisch
        '
        Me.txtEnglisch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEnglisch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEnglisch.Location = New System.Drawing.Point(12, 63)
        Me.txtEnglisch.Multiline = True
        Me.txtEnglisch.Name = "txtEnglisch"
        Me.txtEnglisch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEnglisch.Size = New System.Drawing.Size(863, 193)
        Me.txtEnglisch.TabIndex = 1
        '
        'btnOKSpeichern
        '
        Me.btnOKSpeichern.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOKSpeichern.BackColor = System.Drawing.Color.Bisque
        Me.btnOKSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOKSpeichern.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnOKSpeichern.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOKSpeichern.ImageKey = "accept.png"
        Me.btnOKSpeichern.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOKSpeichern.Location = New System.Drawing.Point(361, 561)
        Me.btnOKSpeichern.Name = "btnOKSpeichern"
        Me.btnOKSpeichern.Size = New System.Drawing.Size(200, 36)
        Me.btnOKSpeichern.TabIndex = 25
        Me.btnOKSpeichern.Text = "&Übersetzungen  speichern"
        Me.btnOKSpeichern.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Timer2
        '
        '
        'chkKurzbeschreibungENG
        '
        Me.chkKurzbeschreibungENG.AutoSize = True
        Me.chkKurzbeschreibungENG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkKurzbeschreibungENG.Location = New System.Drawing.Point(643, 39)
        Me.chkKurzbeschreibungENG.Name = "chkKurzbeschreibungENG"
        Me.chkKurzbeschreibungENG.Size = New System.Drawing.Size(108, 17)
        Me.chkKurzbeschreibungENG.TabIndex = 84
        Me.chkKurzbeschreibungENG.Text = "Kurzbeschreibung"
        Me.chkKurzbeschreibungENG.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.BackColor = System.Drawing.Color.Bisque
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNext.ImageKey = "accept.png"
        Me.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNext.Location = New System.Drawing.Point(732, 561)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(143, 36)
        Me.btnNext.TabIndex = 26
        Me.btnNext.Text = "&Nächster"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'btnVorherriger
        '
        Me.btnVorherriger.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnVorherriger.BackColor = System.Drawing.Color.Bisque
        Me.btnVorherriger.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVorherriger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnVorherriger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVorherriger.ImageKey = "accept.png"
        Me.btnVorherriger.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVorherriger.Location = New System.Drawing.Point(583, 561)
        Me.btnVorherriger.Name = "btnVorherriger"
        Me.btnVorherriger.Size = New System.Drawing.Size(143, 36)
        Me.btnVorherriger.TabIndex = 27
        Me.btnVorherriger.Text = "&Zurück"
        Me.btnVorherriger.UseVisualStyleBackColor = False
        '
        'btnHintergrundfarbeEng
        '
        Me.btnHintergrundfarbeEng.BackColor = System.Drawing.Color.Bisque
        Me.btnHintergrundfarbeEng.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHintergrundfarbeEng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHintergrundfarbeEng.Location = New System.Drawing.Point(764, 0)
        Me.btnHintergrundfarbeEng.Name = "btnHintergrundfarbeEng"
        Me.btnHintergrundfarbeEng.Size = New System.Drawing.Size(111, 23)
        Me.btnHintergrundfarbeEng.TabIndex = 28
        Me.btnHintergrundfarbeEng.Text = "Hintergrundfarbe"
        Me.btnHintergrundfarbeEng.UseVisualStyleBackColor = False
        '
        'MyColorPicker
        '
        Me.MyColorPicker.AnyColor = True
        Me.MyColorPicker.FullOpen = True
        Me.MyColorPicker.SolidColorOnly = True
        '
        'btnVordergrundfarbeEng
        '
        Me.btnVordergrundfarbeEng.BackColor = System.Drawing.Color.Bisque
        Me.btnVordergrundfarbeEng.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVordergrundfarbeEng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVordergrundfarbeEng.Location = New System.Drawing.Point(647, 0)
        Me.btnVordergrundfarbeEng.Name = "btnVordergrundfarbeEng"
        Me.btnVordergrundfarbeEng.Size = New System.Drawing.Size(111, 23)
        Me.btnVordergrundfarbeEng.TabIndex = 29
        Me.btnVordergrundfarbeEng.Text = "Vordergrundfarbe"
        Me.btnVordergrundfarbeEng.UseVisualStyleBackColor = False
        '
        'btnSchriftartEng
        '
        Me.btnSchriftartEng.BackColor = System.Drawing.Color.Bisque
        Me.btnSchriftartEng.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSchriftartEng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSchriftartEng.Location = New System.Drawing.Point(544, 27)
        Me.btnSchriftartEng.Name = "btnSchriftartEng"
        Me.btnSchriftartEng.Size = New System.Drawing.Size(79, 23)
        Me.btnSchriftartEng.TabIndex = 30
        Me.btnSchriftartEng.Text = "&Schriftart"
        Me.btnSchriftartEng.UseVisualStyleBackColor = False
        '
        'cmbFontSizeEng
        '
        Me.cmbFontSizeEng.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFontSizeEng.FormattingEnabled = True
        Me.cmbFontSizeEng.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7"})
        Me.cmbFontSizeEng.Location = New System.Drawing.Point(544, 0)
        Me.cmbFontSizeEng.Name = "cmbFontSizeEng"
        Me.cmbFontSizeEng.Size = New System.Drawing.Size(79, 21)
        Me.cmbFontSizeEng.TabIndex = 85
        '
        'cmbSchriftgröße
        '
        Me.cmbSchriftgröße.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSchriftgröße.FormattingEnabled = True
        Me.cmbSchriftgröße.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7"})
        Me.cmbSchriftgröße.Location = New System.Drawing.Point(544, 3)
        Me.cmbSchriftgröße.Name = "cmbSchriftgröße"
        Me.cmbSchriftgröße.Size = New System.Drawing.Size(79, 21)
        Me.cmbSchriftgröße.TabIndex = 86
        '
        'btnSchriftart
        '
        Me.btnSchriftart.BackColor = System.Drawing.Color.Bisque
        Me.btnSchriftart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSchriftart.Location = New System.Drawing.Point(544, 30)
        Me.btnSchriftart.Name = "btnSchriftart"
        Me.btnSchriftart.Size = New System.Drawing.Size(79, 23)
        Me.btnSchriftart.TabIndex = 87
        Me.btnSchriftart.Text = "&Schriftart"
        Me.btnSchriftart.UseVisualStyleBackColor = False
        '
        'btnVordergrundfarbe
        '
        Me.btnVordergrundfarbe.BackColor = System.Drawing.Color.Bisque
        Me.btnVordergrundfarbe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVordergrundfarbe.Location = New System.Drawing.Point(647, 1)
        Me.btnVordergrundfarbe.Name = "btnVordergrundfarbe"
        Me.btnVordergrundfarbe.Size = New System.Drawing.Size(111, 23)
        Me.btnVordergrundfarbe.TabIndex = 88
        Me.btnVordergrundfarbe.Text = "Vordergrundfarbe"
        Me.btnVordergrundfarbe.UseVisualStyleBackColor = False
        '
        'btnHintergrundFarbe
        '
        Me.btnHintergrundFarbe.BackColor = System.Drawing.Color.Bisque
        Me.btnHintergrundFarbe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHintergrundFarbe.Location = New System.Drawing.Point(764, 1)
        Me.btnHintergrundFarbe.Name = "btnHintergrundFarbe"
        Me.btnHintergrundFarbe.Size = New System.Drawing.Size(111, 23)
        Me.btnHintergrundFarbe.TabIndex = 89
        Me.btnHintergrundFarbe.Text = "Hintergrundfarbe"
        Me.btnHintergrundFarbe.UseVisualStyleBackColor = False
        '
        'frmTranslateVorschau
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 607)
        Me.Controls.Add(Me.btnVorherriger)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnOKSpeichern)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmTranslateVorschau"
        Me.Text = "JTL Translator - translate Vorschau"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.AxDHTMLEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DHTMLControll1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtDeutsch As System.Windows.Forms.TextBox
    Friend WithEvents txtEnglisch As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblProduktbezeichnung As System.Windows.Forms.Label
    Friend WithEvents lblProduktbezeichnungEnglisch As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NeuToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ÖffnenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SpeichernToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DruckenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AusschneidenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents KopierenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EinfügenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Bold As System.Windows.Forms.ToolStripButton
    Friend WithEvents Hyperlink As System.Windows.Forms.ToolStripButton
    Friend WithEvents Suchen As System.Windows.Forms.ToolStripButton
    Friend WithEvents Bild As System.Windows.Forms.ToolStripButton
    Friend WithEvents Redo As System.Windows.Forms.ToolStripButton
    Friend WithEvents Undo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabelle As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton14 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton16 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnOKSpeichern As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    ' Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents AxDHTMLEdit1 As AxDHTMLEDLib.AxDHTMLEdit
    Friend WithEvents DHTMLControll1 As AxDHTMLEDLib.AxDHTMLEdit
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents chkKurzbeschreibungDE As System.Windows.Forms.CheckBox
    Friend WithEvents chkKurzbeschreibungENG As System.Windows.Forms.CheckBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnVorherriger As System.Windows.Forms.Button
    Friend WithEvents btnHintergrundfarbeEng As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents MyColorPicker As System.Windows.Forms.ColorDialog
    Friend WithEvents btnVordergrundfarbeEng As System.Windows.Forms.Button
    Friend WithEvents btnSchriftartEng As System.Windows.Forms.Button
    Friend WithEvents cmbFontSizeEng As System.Windows.Forms.ComboBox
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents cmbSchriftgröße As System.Windows.Forms.ComboBox
    Friend WithEvents btnSchriftart As System.Windows.Forms.Button
    Friend WithEvents btnVordergrundfarbe As System.Windows.Forms.Button
    Friend WithEvents btnHintergrundFarbe As System.Windows.Forms.Button
    'Friend WithEvents AxDHTMLEdit1 As AxDHTMLEDLib.AxDHTMLEdit
    'Friend WithEvents DHTMLControll1 As AxDHTMLEDLib.AxDHTMLEdit
   
End Class
