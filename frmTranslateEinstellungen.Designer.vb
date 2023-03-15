<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTranslateEinstellungen
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.chkMitDeutsch = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtWebproxy = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnTestProxy = New System.Windows.Forms.Button()
        Me.chkKategorieTEXTonly = New System.Windows.Forms.CheckBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.chkPrivoxyTor = New System.Windows.Forms.CheckBox()
        Me.chkJTLWawiFunktionsattribute_translate = New System.Windows.Forms.CheckBox()
        Me.chkTranslateFunktionsattribute_alleSprachen = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkTranslateNormal_alleSprachen = New System.Windows.Forms.CheckBox()
        Me.chkTranslate_normal_mod_created = New System.Windows.Forms.CheckBox()
        Me.chkTranslateMerkmale = New System.Windows.Forms.CheckBox()
        Me.chkTranslate_funktionsattribute_aktiv = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'chkMitDeutsch
        '
        Me.chkMitDeutsch.AutoSize = True
        Me.chkMitDeutsch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMitDeutsch.Location = New System.Drawing.Point(36, 22)
        Me.chkMitDeutsch.Name = "chkMitDeutsch"
        Me.chkMitDeutsch.Size = New System.Drawing.Size(207, 17)
        Me.chkMitDeutsch.TabIndex = 0
        Me.chkMitDeutsch.Text = "Deutsche Übersetzungen vorranstellen"
        Me.chkMitDeutsch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 284)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Proxy Unterstützung"
        '
        'txtWebproxy
        '
        Me.txtWebproxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWebproxy.Location = New System.Drawing.Point(27, 330)
        Me.txtWebproxy.Name = "txtWebproxy"
        Me.txtWebproxy.Size = New System.Drawing.Size(294, 20)
        Me.txtWebproxy.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 353)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "127.0.0.1:Port"
        '
        'btnTestProxy
        '
        Me.btnTestProxy.BackColor = System.Drawing.Color.Bisque
        Me.btnTestProxy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestProxy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestProxy.Location = New System.Drawing.Point(327, 327)
        Me.btnTestProxy.Name = "btnTestProxy"
        Me.btnTestProxy.Size = New System.Drawing.Size(162, 23)
        Me.btnTestProxy.TabIndex = 4
        Me.btnTestProxy.Text = "Proxy testen"
        Me.btnTestProxy.UseVisualStyleBackColor = False
        '
        'chkKategorieTEXTonly
        '
        Me.chkKategorieTEXTonly.AutoSize = True
        Me.chkKategorieTEXTonly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkKategorieTEXTonly.Location = New System.Drawing.Point(36, 45)
        Me.chkKategorieTEXTonly.Name = "chkKategorieTEXTonly"
        Me.chkKategorieTEXTonly.Size = New System.Drawing.Size(301, 17)
        Me.chkKategorieTEXTonly.TabIndex = 5
        Me.chkKategorieTEXTonly.Text = "Kategoriebeschreibung als TEXT übernehmen ohne HTML"
        Me.chkKategorieTEXTonly.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(152, 284)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(97, 13)
        Me.LinkLabel1.TabIndex = 6
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Proxyliste anzeigen"
        '
        'chkPrivoxyTor
        '
        Me.chkPrivoxyTor.AutoSize = True
        Me.chkPrivoxyTor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPrivoxyTor.Location = New System.Drawing.Point(28, 305)
        Me.chkPrivoxyTor.Name = "chkPrivoxyTor"
        Me.chkPrivoxyTor.Size = New System.Drawing.Size(191, 17)
        Me.chkPrivoxyTor.TabIndex = 7
        Me.chkPrivoxyTor.Text = "TOR mit Privoxy als Proxy benutzen"
        Me.chkPrivoxyTor.UseVisualStyleBackColor = True
        '
        'chkJTLWawiFunktionsattribute_translate
        '
        Me.chkJTLWawiFunktionsattribute_translate.AutoSize = True
        Me.chkJTLWawiFunktionsattribute_translate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkJTLWawiFunktionsattribute_translate.Location = New System.Drawing.Point(28, 213)
        Me.chkJTLWawiFunktionsattribute_translate.Name = "chkJTLWawiFunktionsattribute_translate"
        Me.chkJTLWawiFunktionsattribute_translate.Size = New System.Drawing.Size(233, 17)
        Me.chkJTLWawiFunktionsattribute_translate.TabIndex = 8
        Me.chkJTLWawiFunktionsattribute_translate.Text = "Nur JTL Wawi Funktionsattribute übersetzen"
        Me.chkJTLWawiFunktionsattribute_translate.UseVisualStyleBackColor = True
        '
        'chkTranslateFunktionsattribute_alleSprachen
        '
        Me.chkTranslateFunktionsattribute_alleSprachen.AutoSize = True
        Me.chkTranslateFunktionsattribute_alleSprachen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTranslateFunktionsattribute_alleSprachen.Location = New System.Drawing.Point(62, 236)
        Me.chkTranslateFunktionsattribute_alleSprachen.Name = "chkTranslateFunktionsattribute_alleSprachen"
        Me.chkTranslateFunktionsattribute_alleSprachen.Size = New System.Drawing.Size(436, 17)
        Me.chkTranslateFunktionsattribute_alleSprachen.TabIndex = 9
        Me.chkTranslateFunktionsattribute_alleSprachen.Text = "JTL Wawi Funktionsattribute finden und in ALLE verfügbaren JTL Sprachen übersetze" &
    "n"
        Me.chkTranslateFunktionsattribute_alleSprachen.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Funktionsattribute"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Normale Artikelübersetzung "
        '
        'chkTranslateNormal_alleSprachen
        '
        Me.chkTranslateNormal_alleSprachen.AutoSize = True
        Me.chkTranslateNormal_alleSprachen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTranslateNormal_alleSprachen.Location = New System.Drawing.Point(28, 93)
        Me.chkTranslateNormal_alleSprachen.Name = "chkTranslateNormal_alleSprachen"
        Me.chkTranslateNormal_alleSprachen.Size = New System.Drawing.Size(451, 17)
        Me.chkTranslateNormal_alleSprachen.TabIndex = 12
        Me.chkTranslateNormal_alleSprachen.Text = "Deutsch -> Englisch fehlende Artikel finden und in ALLE verfügbaren Sprachen über" &
    "setzen"
        Me.chkTranslateNormal_alleSprachen.UseVisualStyleBackColor = True
        '
        'chkTranslate_normal_mod_created
        '
        Me.chkTranslate_normal_mod_created.AutoSize = True
        Me.chkTranslate_normal_mod_created.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTranslate_normal_mod_created.Location = New System.Drawing.Point(27, 116)
        Me.chkTranslate_normal_mod_created.Name = "chkTranslate_normal_mod_created"
        Me.chkTranslate_normal_mod_created.Size = New System.Drawing.Size(375, 17)
        Me.chkTranslate_normal_mod_created.TabIndex = 13
        Me.chkTranslate_normal_mod_created.Text = "Ja: Benutze zuletzt modifiziert_am Datum, Nein: Benutze erstellt_am Datum"
        Me.chkTranslate_normal_mod_created.UseVisualStyleBackColor = True
        '
        'chkTranslateMerkmale
        '
        Me.chkTranslateMerkmale.AutoSize = True
        Me.chkTranslateMerkmale.Location = New System.Drawing.Point(27, 139)
        Me.chkTranslateMerkmale.Name = "chkTranslateMerkmale"
        Me.chkTranslateMerkmale.Size = New System.Drawing.Size(159, 17)
        Me.chkTranslateMerkmale.TabIndex = 14
        Me.chkTranslateMerkmale.Text = "Artikel Merkmale übersetzen"
        Me.chkTranslateMerkmale.UseVisualStyleBackColor = True
        '
        'chkTranslate_funktionsattribute_aktiv
        '
        Me.chkTranslate_funktionsattribute_aktiv.AutoSize = True
        Me.chkTranslate_funktionsattribute_aktiv.Location = New System.Drawing.Point(27, 162)
        Me.chkTranslate_funktionsattribute_aktiv.Name = "chkTranslate_funktionsattribute_aktiv"
        Me.chkTranslate_funktionsattribute_aktiv.Size = New System.Drawing.Size(191, 17)
        Me.chkTranslate_funktionsattribute_aktiv.TabIndex = 15
        Me.chkTranslate_funktionsattribute_aktiv.Text = "Artikel Funktionsattribute bersetzen"
        Me.chkTranslate_funktionsattribute_aktiv.UseVisualStyleBackColor = True
        '
        'frmTranslateEinstellungen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 375)
        Me.Controls.Add(Me.chkTranslate_funktionsattribute_aktiv)
        Me.Controls.Add(Me.chkTranslateMerkmale)
        Me.Controls.Add(Me.chkTranslate_normal_mod_created)
        Me.Controls.Add(Me.chkTranslateNormal_alleSprachen)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkTranslateFunktionsattribute_alleSprachen)
        Me.Controls.Add(Me.chkJTLWawiFunktionsattribute_translate)
        Me.Controls.Add(Me.chkPrivoxyTor)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.chkKategorieTEXTonly)
        Me.Controls.Add(Me.btnTestProxy)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtWebproxy)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkMitDeutsch)
        Me.Name = "frmTranslateEinstellungen"
        Me.Text = "Übersetzungs Optionen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkMitDeutsch As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtWebproxy As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnTestProxy As System.Windows.Forms.Button
    Friend WithEvents chkKategorieTEXTonly As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents chkPrivoxyTor As CheckBox
    Friend WithEvents chkJTLWawiFunktionsattribute_translate As CheckBox
    Friend WithEvents chkTranslateFunktionsattribute_alleSprachen As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkTranslateNormal_alleSprachen As CheckBox
    Friend WithEvents chkTranslate_normal_mod_created As CheckBox
    Friend WithEvents chkTranslateMerkmale As CheckBox
    Friend WithEvents chkTranslate_funktionsattribute_aktiv As CheckBox
End Class
