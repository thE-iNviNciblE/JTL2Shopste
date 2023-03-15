Public Class frmTranslateEinstellungen
    Dim bisloading As Boolean = True

    Private Sub frmTranslateEinstellungen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkMitDeutsch.Checked = My.Settings.trans_MitDeutsch
        chkKategorieTEXTonly.Checked = My.Settings.cat_description_text
        txtWebproxy.Text = My.Settings.Webproxy(My.Settings.mandant_position)
        chkJTLWawiFunktionsattribute_translate.Checked = My.Settings.chkTranslate_funktionsattribute_only
        chkTranslateFunktionsattribute_alleSprachen.Checked = My.Settings.chkTranslate_funktionsattribute_alleSprachen
        chkPrivoxyTor.Checked = My.Settings.chkUseTorPrivoy
        chkTranslateNormal_alleSprachen.Checked = My.Settings.chkTranslate_normal_alleSprachen
        chkTranslate_normal_mod_created.Checked = My.Settings.chkTranslate_normal_mod_erstellt
        chkTranslateMerkmale.Checked = My.Settings.chkTranslate_normale_merkmale_aktiv
        chkTranslate_funktionsattribute_aktiv.Checked = My.Settings.chkTranslate_normal_funktionsattribute_aktiv

        bisloading = False
    End Sub

    Private Sub chkMitDeutsch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMitDeutsch.CheckedChanged
        My.Settings.trans_MitDeutsch = chkMitDeutsch.Checked
        My.Settings.Save()
    End Sub

    Private Sub txtWebproxy_TextChanged(sender As Object, e As EventArgs) Handles txtWebproxy.TextChanged
        My.Settings.Webproxy(My.Settings.mandant_position) = txtWebproxy.Text
        My.Settings.Save()
    End Sub

    Private Sub btnTestProxy_Click(sender As Object, e As EventArgs) Handles btnTestProxy.Click

        Try
            Dim url1 As String = [String].Format("http://www.freie-welt.eu/")

            Dim webClient1 As New Net.WebClient()

            Dim iLänge1 As Integer = 0
            webClient1.Encoding = System.Text.Encoding.Default

            If My.Settings.Webproxy(My.Settings.mandant_position).Length > 0 Then
                Dim str2() As String = My.Settings.Webproxy(My.Settings.mandant_position).Split(":")
                Dim pr As New System.Net.WebProxy(str2(0), Convert.ToInt16(str2(1)))
                webClient1.Proxy = pr
            End If

            Try
                Dim result1 As String = webClient1.DownloadString(url1)
            Catch ex As Exception
                If chkPrivoxyTor.Checked = True Then
                    MessageBox.Show("Bitte einen augenblick warten bis max. 10 Sekunden bis die Verbindung zum Tor Netzwerk besteht.")
                End If
            End Try




            Dim url As String = [String].Format("http://www.google.de/translate_t?hl=de&ie=UTF8&text={0}&langpair={1}|{2}", "Hallo Welt", "de", "en")

            Dim webClient As New Net.WebClient()

            Dim iLänge As Integer = 0
            webClient.Encoding = System.Text.Encoding.Default

            If My.Settings.Webproxy(My.Settings.mandant_position).Length > 0 Then
                Dim str2() As String = My.Settings.Webproxy(My.Settings.mandant_position).Split(":")
                Dim pr As New System.Net.WebProxy(str2(0), Convert.ToInt16(str2(1)))
                webClient.Proxy = pr
            End If
            Dim result As String = webClient.DownloadString(url)

            Application.DoEvents()
            MessageBox.Show("Emfpang vom Proxy " & txtWebproxy.Text & " ist möglich.", "Webproxy OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("FEHLER: " + ex.Message & vbCrLf, "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkKategorieTEXTonly_CheckedChanged(sender As Object, e As EventArgs) Handles chkKategorieTEXTonly.CheckedChanged
        My.Settings.cat_description_text = chkKategorieTEXTonly.Checked
        My.Settings.Save()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.proxy-listen.de/Proxy/Proxyliste.html")
    End Sub

    Private Sub chkPrivoxyTor_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrivoxyTor.CheckedChanged
        Dim bKillTor As Boolean = False
        Dim bKillPrivoxy As Boolean = False
        Dim strMessage As String = ""

        If bisloading = True Then
            Exit Sub
        End If

        My.Settings.chkUseTorPrivoy = chkPrivoxyTor.Checked
        My.Settings.Save()
        chkPrivoxyTor.Enabled = False
        If chkPrivoxyTor.Checked = True Then

            If TorStarup() = True Then
                If PrivoxyStarup() = True Then
                    txtWebproxy.Text = "localhost:8118"
                    MessageBox.Show("Tor ( " & gbl_tor_pid & " ) und Privoxy (" & gbl_privoxy_pid & ") wurden gestartet, die Proxy URL wurde automatisch geändert", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Else
            If Not gbl_privoxy_pid = 0 Then
                bKillPrivoxy = setKillbyPID(gbl_privoxy_pid)
            End If
            If Not gbl_tor_pid = 0 Then
                bKillTor = setKillbyPID(gbl_tor_pid)
            End If

            If Not gbl_privoxy_pid = 0 And Not gbl_tor_pid = 0 Then
                If bKillPrivoxy = True Then
                    strMessage = "Privoxy (" & gbl_privoxy_pid & ") wurde beendet."
                End If
                If bKillTor = True Then
                    If strMessage.Length > 0 Then
                        strMessage &= vbCrLf & "TOR (" & gbl_privoxy_pid & ") wurde beendet."
                    Else
                        strMessage = "TOR (" & gbl_privoxy_pid & ") wurde beendet."
                    End If

                End If
            End If
            MessageBox.Show(strMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        chkPrivoxyTor.Enabled = True

    End Sub

    Private Sub chkJTLWawiFunktionsattribute_translate_CheckedChanged(sender As Object, e As EventArgs) Handles chkJTLWawiFunktionsattribute_translate.CheckedChanged
        My.Settings.chkTranslate_funktionsattribute_only = chkJTLWawiFunktionsattribute_translate.Checked
        My.Settings.Save()
        Call setGUIModus()
    End Sub

    Private Sub chkTranslateFunktionsattribute_alleSprachen_CheckedChanged(sender As Object, e As EventArgs) Handles chkTranslateFunktionsattribute_alleSprachen.CheckedChanged
        My.Settings.chkTranslate_funktionsattribute_alleSprachen = chkTranslateFunktionsattribute_alleSprachen.Checked
        My.Settings.Save()
        Call setGUIModus()
    End Sub

    Private Sub chkTranslateNormal_alleSprachen_CheckedChanged(sender As Object, e As EventArgs) Handles chkTranslateNormal_alleSprachen.CheckedChanged
        My.Settings.chkTranslate_normal_alleSprachen = chkTranslateNormal_alleSprachen.Checked
        My.Settings.Save()
        Call setGUIModus()
    End Sub

    Private Sub chkTranslate_normal_mod_created_CheckedChanged(sender As Object, e As EventArgs) Handles chkTranslate_normal_mod_created.CheckedChanged
        My.Settings.chkTranslate_normal_mod_erstellt = chkTranslate_normal_mod_created.Checked
        My.Settings.Save()
    End Sub

    Private Sub chkTranslateMerkmale_CheckedChanged(sender As Object, e As EventArgs) Handles chkTranslateMerkmale.CheckedChanged
        My.Settings.chkTranslate_normale_merkmale_aktiv = chkTranslateMerkmale.Checked
        My.Settings.Save()
    End Sub

    Private Sub chkTranslate_funktionsattribute_aktiv_CheckedChanged(sender As Object, e As EventArgs) Handles chkTranslate_funktionsattribute_aktiv.CheckedChanged
        My.Settings.chkTranslate_normal_funktionsattribute_aktiv = chkTranslate_funktionsattribute_aktiv.Checked
        My.Settings.Save()
    End Sub
End Class