Public Class frmTranslateVorschau
    Public strEnglischBeschreibung As String = ""
    Public strDeutschBeschreibung As String = ""
    Public strProduktname As String = ""
    Public strProduktNameEnglisch As String = ""
    Public strDeutschKurzbeschreibung As String = ""
    Public strEnglischKurzbeschreibung As String = ""
    Public iProduktID As String = ""
    ' Public lvwMainData As ListView

    Private Sub txtDeutsch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDeutsch.TextChanged

    End Sub

    Private Sub frmTranslateVorschau_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtDeutsch.Text = strDeutschBeschreibung
        txtEnglisch.Text = strEnglischBeschreibung
        lblProduktbezeichnung.Text = strProduktname
        lblProduktbezeichnungEnglisch.Text = strProduktNameEnglisch

        'Dim strText As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\vorlagen\master_vorlage.htm")
        'txtEnglisch.Text = strText
        'My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\vorlagen\tmp_rechnung.html", strText, False)
        Timer2.Enabled = True


    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Call setLinkLabel1_action(False)
    End Sub
    Private Function setLinkLabel1_action(bEditModeSwitch As Boolean) As Boolean
        If LinkLabel1.Text = "Deutsche HTML Ansicht" And bEditModeSwitch = False Then
            LinkLabel1.Text = "Deutsche Design Ansicht"
            txtDeutsch.Visible = True
            txtDeutsch.Text = AxDHTMLEdit1.DOM.body.innerHTML
            AxDHTMLEdit1.Visible = False
        Else
            LinkLabel1.Text = "Deutsche HTML Ansicht"
            AxDHTMLEdit1.DOM.body.innerHTML = txtDeutsch.Text
            txtDeutsch.Visible = False
            AxDHTMLEdit1.Visible = True
        End If
    End Function

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Call setLinkLabel2_action(False)
    End Sub
    Private Function setLinkLabel2_action(bEditModeSwitch As Boolean) As Boolean
        If LinkLabel2.Text = "Englische HTML Ansicht" And bEditModeSwitch = False Then
            LinkLabel2.Text = "Englische Design Ansicht"
            txtDeutsch.Visible = True
            txtEnglisch.Text = DHTMLControll1.DOM.body.innerHTML        
                DHTMLControll1.Visible = False
            Else
                LinkLabel2.Text = "Englische HTML Ansicht"
            DHTMLControll1.DOM.body.innerHTML = txtEnglisch.Text

            If chkKurzbeschreibungENG.Checked = False Then
                strEnglischBeschreibung = txtEnglisch.Text
            Else
                strEnglischKurzbeschreibung = txtEnglisch.Text
            End If

            txtDeutsch.Visible = False
            DHTMLControll1.Visible = True
        End If

    End Function

    Private Sub ÖffnenToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ÖffnenToolStripButton.Click
        Dim strPathVorlage As String

        OpenFileDialog1.Title = "Geschriebenen Text laden..."
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            strPathVorlage = OpenFileDialog1.FileName

            AxDHTMLEdit1.DOM.body.innerHTML = ""
            txtEnglisch.Text = ""

            If LinkLabel1.Text = "HTML" Then
                AxDHTMLEdit1.DOM.body.innerHTML = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            Else
                txtEnglisch.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            End If

        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click

    End Sub

    'Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
    '    Dim strHTMLExport As String = ""

    '    SaveFileDialog1.Title = "JTL Translator -> HTML Export"
    '    If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        strHTMLExport = SaveFileDialog1.FileName
    '    Else
    '        MsgBox("Es ist ein Fehler beim Speichern aufgetretten", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "JTL Translator -> Fehler beim Speichern")
    '    End If


    '    If LinkLabel1.Text = "Englische HTML Ansicht" Then
    '        ' My.Computer.FileSystem.WriteAllText(strHTMLExport, DHTMLControll.DOM.body.innerHTML, False)
    '    Else
    '        My.Computer.FileSystem.WriteAllText(strHTMLExport, txtEnglisch.Text, False)
    '    End If

    '    MsgBox("Datei wurde unter '" & strHTMLExport & "' gespeichert", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "JTL Translator - Datei gespeichert")
    'End Sub


    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        AxDHTMLEdit1.PrintDocument()
    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_CUT)
    End Sub

    Private Sub ToolStripButton10_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton10.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_BOLD)
    End Sub

    Private Sub btnOKSpeichern_Click(sender As System.Object, e As System.EventArgs) Handles btnOKSpeichern.Click
        '# Speichern der Einstellungen

        btnOKSpeichern.Enabled = False

        '# UPDATE oder INSERT
        If frmMain.clsDB.chkIsTranslated(iProduktID) = True Then

            '# Keine Kurzbeschreibung
            If chkKurzbeschreibungENG.Checked = False Then

                '# UPDATE
                strEnglischBeschreibung = DHTMLControll1.DOM.body.innerHTML
                txtEnglisch.Text = strEnglischBeschreibung
                frmMain.lvwMainData.SelectedItems(0).SubItems(6).Text = strEnglischBeschreibung
                If frmMain.clsDB.setUPDATE_TextData_englisch(iProduktID, strProduktNameEnglisch, strEnglischKurzbeschreibung, strEnglischBeschreibung) = False Then
                    MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & strProduktNameEnglisch)
                End If

            Else
                '# UPDATE
                strEnglischKurzbeschreibung = DHTMLControll1.DOM.body.innerHTML
                txtDeutsch.Text = strEnglischKurzbeschreibung
                frmMain.lvwMainData.SelectedItems(0).SubItems(5).Text = strEnglischKurzbeschreibung
                If frmMain.clsDB.setUPDATE_TextData_englisch(iProduktID, strProduktNameEnglisch, strEnglischKurzbeschreibung, strEnglischBeschreibung) = False Then
                    MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & strProduktNameEnglisch)
                End If
            End If


        Else
            '# INSERT
            If frmMain.clsDB.setINSERT_TextData_englisch(iProduktID, strProduktNameEnglisch, strEnglischKurzbeschreibung, strEnglischBeschreibung) = False Then
                MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & strProduktNameEnglisch)
            End If
        End If

        btnOKSpeichern.Enabled = True
    End Sub

    Private Sub ToolStripButton11_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton11.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_HYPERLINK)
    End Sub

    Private Sub ToolStripButton12_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton12.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_FINDTEXT)
    End Sub

    Private Sub ToolStripButton13_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton13.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_IMAGE)
    End Sub

    Private Sub ToolStripButton14_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton14.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_REDO)
    End Sub

    Private Sub ToolStripButton15_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton15.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_UNDO)
    End Sub

    Private Sub ToolStripButton16_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton16.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_INSERTTABLE)
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        DHTMLControll1.DOM.body.innerHTML = txtEnglisch.Text
        AxDHTMLEdit1.DOM.body.innerHTML = txtDeutsch.Text
        Timer2.Enabled = False
    End Sub

    Private Sub chkKurzbeschreibungDE_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkKurzbeschreibungDE.CheckedChanged

        If chkKurzbeschreibungDE.Checked = True Then
            chkKurzbeschreibungDE.Text = "Beschreibung"
            txtDeutsch.Text = strDeutschBeschreibung
            txtEnglisch.Text = strEnglischBeschreibung
            DHTMLControll1.DOM.body.innerHTML = txtEnglisch.Text
            DHTMLControll1.Refresh()
            AxDHTMLEdit1.DOM.body.innerHTML = txtDeutsch.Text
            AxDHTMLEdit1.Refresh()
        Else
            chkKurzbeschreibungDE.Text = "Kurzbeschreibung"
            txtDeutsch.Text = strDeutschKurzbeschreibung
            txtEnglisch.Text = strEnglischKurzbeschreibung
            DHTMLControll1.DOM.body.innerHTML = txtEnglisch.Text
            DHTMLControll1.Refresh()
            AxDHTMLEdit1.DOM.body.innerHTML = txtDeutsch.Text
            AxDHTMLEdit1.Refresh()
        End If

    End Sub

    Private Sub Bold_Click(sender As System.Object, e As System.EventArgs) Handles Bold.Click
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_BOLD)
    End Sub

    Private Sub NeuToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NeuToolStripButton.Click

    End Sub

    Private Sub SpeichernToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles SpeichernToolStripButton.Click

    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub AusschneidenToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AusschneidenToolStripButton.Click
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_CUT)
    End Sub

    Private Sub KopierenToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles KopierenToolStripButton.Click
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_COPY)
    End Sub

    Private Sub EinfügenToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles EinfügenToolStripButton.Click
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_PASTE)
    End Sub

    Private Sub Hyperlink_Click(sender As System.Object, e As System.EventArgs) Handles Hyperlink.Click
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_HYPERLINK)
    End Sub

    Private Sub Suchen_Click(sender As System.Object, e As System.EventArgs) Handles Suchen.Click
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_FINDTEXT)
    End Sub

    Private Sub Bild_Click(sender As System.Object, e As System.EventArgs) Handles Bild.Click
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_IMAGE)
    End Sub

    Private Sub Redo_Click(sender As System.Object, e As System.EventArgs) Handles Redo.Click
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_REDO)
    End Sub

    Private Sub Undo_Click(sender As System.Object, e As System.EventArgs) Handles Undo.Click
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_UNDO)
    End Sub

    Private Sub tabelle_Click(sender As System.Object, e As System.EventArgs) Handles tabelle.Click
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_INSERTTABLE)
    End Sub

    Private Sub ToolStripButton8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton8.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_COPY)
    End Sub

    Private Sub ToolStripButton9_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton9.Click
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_PASTE)
    End Sub

    Private Sub chkKurzbeschreibungENG_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkKurzbeschreibungENG.CheckedChanged

        If chkKurzbeschreibungENG.Checked = True Then
            chkKurzbeschreibungENG.Text = "Beschreibung"
            '# Kurzbeschreibungen zuweisen
            txtDeutsch.Text = strDeutschKurzbeschreibung
            txtEnglisch.Text = strEnglischKurzbeschreibung

            DHTMLControll1.DOM.body.innerHTML = txtEnglisch.Text
            DHTMLControll1.Refresh()
            AxDHTMLEdit1.DOM.body.innerHTML = txtDeutsch.Text
            AxDHTMLEdit1.Refresh()
        Else
            chkKurzbeschreibungENG.Text = "Kurzbeschreibung"
            '# Beschreibung zuweisen
            txtDeutsch.Text = strDeutschBeschreibung
            txtEnglisch.Text = strEnglischBeschreibung
            DHTMLControll1.DOM.body.innerHTML = txtEnglisch.Text
            DHTMLControll1.Refresh()
            AxDHTMLEdit1.DOM.body.innerHTML = txtDeutsch.Text
            AxDHTMLEdit1.Refresh()
        End If

    End Sub

    Private Sub DHTMLControll1_DocumentComplete(sender As System.Object, e As System.EventArgs) Handles DHTMLControll1.DocumentComplete
        'MessageBox.Show("Abgeschlossen")
    End Sub

    Private Sub txtEnglisch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEnglisch.TextChanged
        'MessageBox.Show("Englisch wurde geändert")
        If chkKurzbeschreibungENG.Checked = False Then
            strEnglischBeschreibung = txtEnglisch.Text
        Else
            strEnglischKurzbeschreibung = txtEnglisch.Text
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click
        Dim iIndex As Integer = frmMain.lvwMainData.SelectedItems(0).Index

        btnNext.Enabled = False
        '# Speichern Meldung anzeigen
        If chkKurzbeschreibungENG.Checked = False Then

            If Not strEnglischBeschreibung = DHTMLControll1.DOM.body.innerHTML Then
                If MessageBox.Show("Möchten Sie die Artikeländerungen '" & strProduktname & "' noch speichern?", "Speichern", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    btnNext.Enabled = True
                    Exit Sub
                End If
            End If
        Else
            If Not strEnglischKurzbeschreibung = DHTMLControll1.DOM.body.innerHTML Then
                If MessageBox.Show("Möchten Sie die Artikeländerungen '" & strProduktname & "' noch speichern?", "Speichern", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    btnNext.Enabled = True
                    Exit Sub
                End If
            End If
        End If

        Try
            chkKurzbeschreibungENG.Checked = False
            frmMain.lvwMainData.Items(iIndex + 1).Selected = True
            btnVorherriger.Enabled = True
        Catch ex As Exception
            btnNext.Enabled = False
            MessageBox.Show("Letzter Artikel erreicht", "Letzter Artikel erreicht", MessageBoxButtons.OK)
        End Try

        Call setNächstenArtikel()

        btnNext.Enabled = True
    End Sub

    Private Sub btnVorherriger_Click(sender As System.Object, e As System.EventArgs) Handles btnVorherriger.Click
        Dim iIndex As Integer = frmMain.lvwMainData.SelectedItems(0).Index

        Try
            btnVorherriger.Enabled = False

            '# Speichern Meldung anzeigen
            If chkKurzbeschreibungENG.Checked = False Then

                If Not strEnglischBeschreibung = DHTMLControll1.DOM.body.innerHTML Then
                    If MessageBox.Show("Möchten Sie die Artikeländerungen '" & strProduktname & "' noch speichern?", "Speichern", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        btnVorherriger.Enabled = True
                        Exit Sub
                    End If
                End If
            Else
                If Not strEnglischKurzbeschreibung = DHTMLControll1.DOM.body.innerHTML Then
                    If MessageBox.Show("Möchten Sie die Artikeländerungen '" & strProduktname & "' noch speichern?", "Speichern", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        btnVorherriger.Enabled = True
                        Exit Sub
                    End If
                End If
            End If

            chkKurzbeschreibungENG.Checked = False
            frmMain.lvwMainData.Items(iIndex - 1).Selected = True
            btnNext.Enabled = True
        Catch ex As Exception
            btnVorherriger.Enabled = False
            MessageBox.Show("Erster Artikel erreicht", "Erster Artikel errreicht", MessageBoxButtons.OK)
        End Try

        Call setNächstenArtikel()
        btnVorherriger.Enabled = True
    End Sub

    '##################################################################################
    '# >> Nächsten Artikel auswählen oder vorherrigen
    '##################################################################################
    Private Function setNächstenArtikel() As Boolean
        Try
            iProduktID = frmMain.lvwMainData.SelectedItems(0).SubItems(7).Text
            strEnglischBeschreibung = frmMain.lvwMainData.SelectedItems(0).SubItems(6).Text
            strDeutschBeschreibung = frmMain.lvwMainData.SelectedItems(0).SubItems(4).Text
            txtDeutsch.Text = strDeutschBeschreibung
            txtEnglisch.Text = strEnglischBeschreibung

            DHTMLControll1.DOM.body.innerHTML = txtEnglisch.Text
            DHTMLControll1.Refresh()
            AxDHTMLEdit1.DOM.body.innerHTML = txtDeutsch.Text
            AxDHTMLEdit1.Refresh()

            strProduktname = frmMain.lvwMainData.SelectedItems(0).SubItems(1).Text
            strProduktNameEnglisch = frmMain.lvwMainData.SelectedItems(0).SubItems(2).Text
            lblProduktbezeichnung.Text = strProduktname
            lblProduktbezeichnungEnglisch.Text = strProduktNameEnglisch

            strDeutschKurzbeschreibung = frmMain.lvwMainData.SelectedItems(0).SubItems(3).Text
            strEnglischKurzbeschreibung = frmMain.lvwMainData.SelectedItems(0).SubItems(5).Text
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Blättern der Artikel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnHintergrundfarbeEng.Click
        MyColorPicker.ShowDialog()


        Dim MyCol As Long
        Dim MyColor As String
        MyCol = MyColorPicker.Color.ToArgb + 16777216
        MyColor = "#" & MyCol.ToString("X6")
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_SETBACKCOLOR, _
          DHTMLEDLib.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, MyColor)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnVordergrundfarbeEng.Click
        MyColorPicker.ShowDialog()


        Dim MyCol As Long
        Dim MyColor As String
        MyCol = MyColorPicker.Color.ToArgb + 16777216
        MyColor = "#" & MyCol.ToString("X6")
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_SETFORECOLOR, _
          DHTMLEDLib.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, MyColor)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btnSchriftartEng.Click
        FontDialog1.ShowDialog()
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_SETFONTNAME, _
  DHTMLEDLib.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, FontDialog1.Font.FontFamily.Name)
    End Sub

    Private Sub cmbFontSize_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbFontSizeEng.SelectedIndexChanged
        DHTMLControll1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_SETFONTSIZE, _
  DHTMLEDLib.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, cmbFontSizeEng.Text)
    End Sub

    Private Sub cmbSchriftgröße_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSchriftgröße.SelectedIndexChanged
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_SETFONTSIZE, _
  DHTMLEDLib.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, cmbSchriftgröße.Text)
    End Sub

    Private Sub btnSchriftart_Click(sender As System.Object, e As System.EventArgs) Handles btnSchriftart.Click
        FontDialog1.ShowDialog()
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_SETFONTNAME, _
  DHTMLEDLib.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, FontDialog1.Font.FontFamily.Name)
    End Sub

    Private Sub Button1_Click_2(sender As System.Object, e As System.EventArgs) Handles btnVordergrundfarbe.Click
        MyColorPicker.ShowDialog()

        Dim MyCol As Long
        Dim MyColor As String
        MyCol = MyColorPicker.Color.ToArgb + 16777216
        MyColor = "#" & MyCol.ToString("X6")
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_SETFORECOLOR, _
          DHTMLEDLib.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, MyColor)
    End Sub

    Private Sub btnHintergrundFarbe_Click(sender As System.Object, e As System.EventArgs) Handles btnHintergrundFarbe.Click
        MyColorPicker.ShowDialog()


        Dim MyCol As Long
        Dim MyColor As String
        MyCol = MyColorPicker.Color.ToArgb + 16777216
        MyColor = "#" & MyCol.ToString("X6")
        AxDHTMLEdit1.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_SETBACKCOLOR, _
          DHTMLEDLib.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, MyColor)
    End Sub
End Class