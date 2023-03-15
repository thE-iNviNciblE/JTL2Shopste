

Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Net
Imports System.Web

Public Class frmMain
    Public clsDB As New clsDatenbank
    Dim bIsLoading As Boolean = True
    Public lvwStartupKategorie As ListView
    Dim bIsKomplettÜbersetzung As Boolean = False

    '#################################################
    '# >> setSettingsDelete
    '# My.Settings.xxx String Collection alle löschen
    '#################################################
    Public Function setSettingsDelete() As Boolean
        Dim i As Integer
        For i = 0 To My.Settings.db_server.Count - 1
            Try
                My.Settings.db_server.RemoveAt(0)
            Catch ex As Exception

            End Try
            Try
                My.Settings.db_datenbankname.RemoveAt(0)
            Catch ex As Exception

            End Try
            Try
                My.Settings.db_username.RemoveAt(0)
            Catch ex As Exception

            End Try

            msgMaster.Text = "Es existieren noch " & My.Settings.db_server.Count & " Einstellungen"
        Next
        Return True
    End Function

    '##################################################################################
    '# >> geteazybusinessSettings()
    '# Findet die Position an der Sich die Hauptdatenbank befindet 
    '##################################################################################
    Public Function getMySettingsPositionByDatabase(strDatabaseName As String) As Integer
        Try
            Dim i As Byte
            Dim iGefunden As Integer = -1
            Dim bGefunden As Boolean = False

            '# Keine Einstellung gefunden 
            If My.Settings.db_datenbankname.Count = 0 Then
                Return -1
                Exit Function
            End If

            For i = 0 To My.Settings.db_datenbankname.Count - 1
                If My.Settings.db_datenbankname(i) = strDatabaseName Then
                    bGefunden = True
                    iGefunden = i
                    Exit For
                End If
            Next
            '# Nicht gefunden Position 0 
            If bGefunden = False Then
                iGefunden = -1
            End If

            My.Settings.Save()
            Return iGefunden
        Catch ex As Exception
            MessageBox.Show("Fehler: " & ex.Message, "geteMySettingsbyDatabase()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function
    '#################################################
    '# >> setSettingsInit
    '# My.Settings.xxx String Collection initalisieren
    '#################################################
    Public Function setSettingsInit(ByVal iSize As Integer) As Integer
        Try
            Dim txtShopURL_test As String = ""
            Dim iCount_insert As Integer = 0

            If My.Settings.db_server.Count - 1 < iSize Then
                For iCount As Integer = My.Settings.db_server.Count To iSize

                    My.Settings.db_server.Insert(iCount, "")
                    My.Settings.db_datenbankname.Insert(iCount, "")
                    My.Settings.db_username.Insert(iCount, "")
                    My.Settings.db_passwort.Insert(iCount, "")
                    My.Settings.SpracheSelected.Insert(iCount, "")
                    My.Settings.Webproxy.Insert(iCount, "")
                    My.Settings.JTLSHOP.Insert(iCount, "")
                    My.Settings.JTLSHOP_HTTP.Insert(iCount, "")

                    iCount_insert += 1

                Next

            End If
            Return iCount_insert
        Catch ex As Exception
            MessageBox.Show("Fehler bei setInitSettings: " & ex.Message, "setInitSettings()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strFilename As String = Application.StartupPath & "\SQL\Update.sql"
        bIsLoading = True

        Call setMainWindowTitle("", Me)

        gbl_KeyCode = getWMI_KeyCode()
        Dim strServerInfo() As String = getHTTPResponseMessage("https://api.bludau-media.de//SafeSandy/IsRegistered.php?key=" & gbl_KeyCode & "&versionsnummer=" & strVersionsNummer, mgetUpdaterMessage.getIstBuyed, True)
        If Not strServerInfo(0) = "GEKAUFT" Then
            Dim frmRegisterJTLBridge As New frmDemoVersion
            frmRegisterJTLBridge.ShowDialog()
        End If

        '# Keine Datenbankverbindungsmöglichkeiten vorhanden erster Start 
        If My.Settings.mandant_position = -1 Then
            Dim frmDBSetting As New frmDatenbankEinstellungen
            frmDBSetting.ShowDialog()
        End If



        ''# Prüfung ob my.settings.mandant_position außerhalb des Index
        Try
            If My.Settings.db_server(My.Settings.mandant_position) = "" Then

            End If
        Catch ex As Exception
            '# Außerhalb des Index default Datenbank laden, falls vorhanden 
            MainMenuStrip.Text = "Fehler: aktuelle Position innerhalb der Einstellungen '" & My.Settings.mandant_position & "' - lade Standard Werte"
            Dim frmDBSetting As New frmDatenbankEinstellungen
            frmDBSetting.ShowDialog()
            'My.Settings.mandant_position = getMySettingsPositionByDatabase("eazybusiness")
        End Try

        '##################################################
        '# >> Standarddatenbank easzybusiness Connection 
        '##################################################
        If clsDB.strConnectionString_eazybusiness = "" Then
            Dim iDefaultDB As Integer = getMySettingsPositionByDatabase("eazybusiness")

            '# Es konnte keine Standarddatenbank gefunden werden 
            If iDefaultDB = -1 Then
                iDefaultDB = 0
            End If

            Dim strCon2 As String = "server=" & My.Settings.db_server.Item(iDefaultDB) & ";uid=" & My.Settings.db_username.Item(iDefaultDB) & ";pwd=" & My.Settings.db_passwort.Item(iDefaultDB) & ";database=" & My.Settings.db_datenbankname.Item(iDefaultDB) & ";"
            If clsDB.getDBConnect(strCon2, True) = False Then
                Dim frmDBSetting As New frmDatenbankEinstellungen
                frmDBSetting.ShowDialog()
            End If
        End If

        '######################################################
        '# >> Mandantendatenbank auswählen 
        '######################################################
        If My.Settings.db_server(My.Settings.mandant_position) = "" Or My.Settings.db_datenbankname(My.Settings.mandant_position) = "" Or My.Settings.db_passwort(My.Settings.mandant_position) = "" Or My.Settings.db_username(My.Settings.mandant_position) = "" Then
            Dim frmDBSetting As New frmDatenbankEinstellungen
            frmDBSetting.ShowDialog()
        End If
        Dim strCon As String = "server=" & My.Settings.db_server.Item(My.Settings.mandant_position) & ";uid=" & My.Settings.db_username.Item(My.Settings.mandant_position) & ";pwd=" & My.Settings.db_passwort.Item(My.Settings.mandant_position) & ";database=" & My.Settings.db_datenbankname.Item(My.Settings.mandant_position) & ";"
        If clsDB.getDBConnect(strCon) = False Then
            Dim frmDBSetting As New frmDatenbankEinstellungen
            frmDBSetting.ShowDialog()
        End If

        '# Datenbank Verbindung initialisieren
        'Call setDBSettings(True)

        '#################################################################
        '# >> Standardmandanten laden - eazybusiness Standarddatenbank
        '#################################################################
        Call clsDB.setMandantbyCombobox(cmbMandant, False)

        'JTL Shops auslesen
        Call clsDB.getJTLShops(cmbJTLShops)
        ToolStripStatusLabel1.Text = "JTL SHOP: " + clsDB.getJTLShop(cmbJTLShops.Text)

        Dim strServerInfo1() As String = getHTTPResponseMessage("https://api.bludau-media.de//SafeSandy/Update.php?key=" & gbl_KeyCode & "&programID=11&versionsnummer=" & strVersionsNummer & "&KeinUpdate=1", mgetUpdaterMessage.getProgramUpdateCheck, True)

        If Not strServerInfo1(0) = "VERSION_AKTUELL" Then
            Dim frmUpdater As New frmUpdater
            frmUpdater.ShowDialog()
        End If

        Dim strOutput(1) As String
        ' strOutput = clsDB.getKategorieOberKategorie(0, 1)



        '# Gibt es SpracheSelected???
        Try
            My.Settings.SpracheSelected(My.Settings.mandant_position) = 0
        Catch ex As Exception
            My.Settings.SpracheSelected.Insert(0, "")
            My.Settings.Webproxy.Insert(My.Settings.mandant_position, "")
            My.Settings.SpracheSelected.Insert(My.Settings.mandant_position, "")
            My.Settings.JTLSHOP.Insert(My.Settings.mandant_position, "")
            My.Settings.JTLSHOP_HTTP.Insert(My.Settings.mandant_position, "")

        End Try



        '# Alle aktiven verfügbaren Sprachen aus JTL auslesen
        Call clsDB.getPossibleLanguages2Checkbox(cmbZielSpache)

        If My.Settings.bSQLUpdate_immer = True Then
            Dim strFilename2 As String = Application.StartupPath & "\SQL\Update.sql"
            If IO.File.Exists(strFilename) = True Then
                Call clsDB.setInstallUpdateAllMandant(strFilename2, cmbMandant)
            End If
        End If

        If cmbZielSpache.Items.Count > 0 Then
            If cmbZielSpache.Items.Count > 1 Then
                cmbZielSpache.SelectedIndex = 1
            Else
                cmbZielSpache.SelectedIndex = 0
            End If

        End If

        '# Privoxy und Tor starten...
        If My.Settings.chkUseTorPrivoy = True Then
            setStartupTorPrivoxy(True)
        End If

        Call setGUIModus()

        '# Aktuell setzten
        'DateTimePicker1.Value = Date.Now.AddMonths(-1)

        'chkUseDateTimePicker.Checked = My.Settings.chkTranslate_normal_benutzeDatum

        '# Kategorien abrufen in Listview 
        lvwArtikel_kategorien.Items.Clear() ' Listview löschen

        bIsLoading = False


        If My.Settings.SHOPSTE_domain_id.Length = 0 Then
            Dim frmShopsteLogin As New LoginForm1
            frmShopsteLogin.Show()
        End If

        '# Nur Login wenn kein Benutzername gesetzt ist
        If My.Settings.SHOPSTE_USERNAME.Length > 0 Then
            btnÜbertrage.Enabled = True

        Else
            btnÜbertrage.Enabled = False

        End If

    End Sub

    Private Sub BeeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DatenbankverbindungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatenbankverbindungToolStripMenuItem.Click
        Dim frmDBCon As New frmDatenbankEinstellungen
        frmDBCon.ShowDialog()
    End Sub
    Function setArtikel2Shopste()
        Try
            Dim strLokalFile As String
            Dim strLast As String
            Dim strImportError As String = ""
            Dim iCount As Integer = 0
            Dim strBeschreibung As String = ""


            For iCount = 0 To lvwMainData.SelectedItems.Count - 1

                Dim str2() As String = getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=get_shopste_kategorie_by_eisocatid&eiso_cat_id=" & lvwMainData.SelectedItems(iCount).SubItems(11).Text & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD, mgetUpdaterMessage.getEiSo2ShopsteKat, False)

                If Not IsNumeric(str2(0)) = True Then
                    MessageBox.Show("Es wurde keine gültige Shopste.com Kategorie gefunden.", "ungültige Kategorie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Continue For
                End If

                ' lvwMainData.Items(iCount).Selected = True
                ' Application.DoEvents()

                Dim Request As HttpWebRequest = CType(WebRequest.Create(My.Settings.SHOPSTE_API_URL), HttpWebRequest)
                Request.Method = "POST"
                Request.ContentType = "application/x-www-form-urlencoded"
                msgMaster.Text = iCount & " | " & lvwMainData.SelectedItems.Count - 1 & " - Bereite einfügen vor..."
                Application.DoEvents()
                'MessageBox.Show(System.Net.WebUtility.HtmlEncode(ListView1.SelectedItems(0).SubItems(0).Text))
                'System.Net.WebUtility.HtmlEncode
                ' Dim strBeschreibung As String
                ' If chkImportKeineHTMLBeschreibung.Checked = False Then
                'strBeschreibung = HttpUtility.UrlEncode(HttpUtility.HtmlEncode(lvwMainData.SelectedItems(iCount).SubItems(1).Text))
                strBeschreibung = System.Uri.EscapeDataString(lvwMainData.SelectedItems(iCount).SubItems(1).Text)

                ' Else
                ' strBeschreibung = HttpUtility.UrlEncode(lvwMainData.SelectedItems(0).SubItems(0).Text)
                ' End If

                '# Letztes zu importierendes Produkt?
                If iCount = lvwMainData.SelectedItems.Count - 1 Then
                    strLast = "true"
                Else
                    strLast = "false"
                End If


                Dim Post As String = "modus=system_shop_item_add&domain_id=" & My.Settings.SHOPSTE_domain_id & "&shop_item_beschreibung=" & strBeschreibung & "&shop_item_menge=" & lvwMainData.SelectedItems(iCount).SubItems(9).Text & "&shop_item_price=" & lvwMainData.SelectedItems(iCount).SubItems(2).Text.Replace(",", ".") & "&shop_item_name=" & System.Uri.EscapeDataString(lvwMainData.SelectedItems(iCount).SubItems(1).Text) & "&shop_item_duration=15&shop_item_mwst=19&shop_item_artikelnummer=" & lvwMainData.SelectedItems(iCount).SubItems(0).Text & "&bLastItem=" & strLast & "&user=" & My.Settings.SHOPSTE_USERNAME & "&subshop_cat=" & strHTTPDataStore & "&shopste_cat=" & lvwMainData.SelectedItems(iCount).SubItems(12).Text & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD

                ' Clipboard.SetText(WebUtility.HtmlEncode(ListView1.SelectedItems(0).SubItems(5).Text))

                'Dim postQuery As Byte() = System.Text.Encoding.ASCII.GetBytes("Post 

                Dim byteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(Post)
                Request.ContentLength = byteArray.Length
                Dim DataStream As System.IO.Stream = Request.GetRequestStream()
                DataStream.Write(byteArray, 0, byteArray.Length)
                DataStream.Close()
                Dim Response As HttpWebResponse = Request.GetResponse()
                DataStream = Response.GetResponseStream()
                Dim reader As New System.IO.StreamReader(DataStream)
                Dim ServerResponse As String = reader.ReadToEnd()
                reader.Close()
                DataStream.Close()
                Response.Close()

                If InStr(ServerResponse, "shopid") Then
                    Dim str() As String = ServerResponse.Split(":")
                    Dim shopid_picture As String = str(1)

                    msgMaster.Text = iCount & " | " & lvwMainData.SelectedItems.Count - 1 & " - Shop ID:" & shopid_picture

                    Dim strFileName() As String = lvwMainData.SelectedItems(iCount).SubItems(3).Text.Split("/")

                    Dim nvc As New Specialized.NameValueCollection
                    nvc.Add("modus", "system_upload_file")
                    nvc.Add("domain_id", My.Settings.SHOPSTE_domain_id)
                    nvc.Add("benutzername", My.Settings.SHOPSTE_USERNAME)
                    nvc.Add("domain_pfad", My.Settings.SHOPSTE_domainname)
                    nvc.Add("shop_id", shopid_picture)
                    ' nvc.Add("picture_name", lvwMainData.Items(iCount).SubItems(3).Text.Replace(" ", "_").Replace(">", "-").Replace("/", "").Replace("\", "").Replace("!", ""))
                    Dim strBildName As String = lvwMainData.SelectedItems(iCount).SubItems(1).Text.Replace(" ", "_").Replace(">", "-").Replace("/", "").Replace("\", "").Replace("!", "").Replace("*", "").Replace("<", "-") & ".jpg"
                    nvc.Add("picture_name", strBildName)

                    '# Externe Bilder - HTTP Link
                    If Not lvwMainData.SelectedItems(iCount).SubItems(3).Text.LastIndexOf("http://") = -1 Then

                        Dim client As New WebClient()

                        Dim strBild As String
                        Dim strBild_ary() As String
                        Dim strBildFixed As String = strFileName(strFileName.Length - 1).Replace("\", "-").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("""", "").Replace("<", "").Replace(">", "").Replace("|", "")
                        'MessageBox.Show(Application.StartupPath)
                        ' Dim strPath As String = IO.Path.GetDirectoryName(Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
                        ' MessageBox.Show(Application.StartupPath)
                        If My.Settings.SHOPSTE_domain_id = 43 Then
                            strBild_ary = strBildName.Split("/")
                            If strBild_ary.Length = 1 Then
                                strBild = "https://philafriend.de/eBay/TN_" & strBildFixed
                            Else
                                strBild = strBild.Replace(strBild_ary(strBild_ary.Length - 1), "TN_" + strBild_ary(strBild_ary.Length - 1))
                                strBild = "https://philafriend.de/eBay/TN_" & strBild_ary(strBild_ary.Length - 1)
                                strBild = lvwMainData.SelectedItems(iCount).SubItems(3).Text.Replace("http://", "https://")
                                strBild_ary = strBild.Split("/")
                                strBild = strBild.Replace(strBild_ary(strBild_ary.Length - 1), "TN_" + strBild_ary(strBild_ary.Length - 1))

                            End If

                        Else
                            strBild = lvwMainData.SelectedItems(iCount).SubItems(3).Text
                        End If

                        Try

                            If strBildFixed.Length > 240 Then
                                strBildFixed = strBildFixed.Substring(0, 240)
                            End If
                            client.DownloadFile(strBild, Application.StartupPath & "\bilderexport\" & strBildFixed)
                            strLokalFile = Application.StartupPath & "\bilderexport\" & strBildFixed
                        Catch ex As Exception
                            strLokalFile = "error"
                            strImportError &= lvwMainData.SelectedItems(iCount).SubItems(3).Text & vbCrLf
                        End Try


                    Else
                        strLokalFile = ""
                    End If

                    'HttpUploadFile("http://shopste.com/api.php", "C:\Users\jbludau\Desktop\gelb_katze.jpg", "system_upload", "image/jpeg", nvc)
                    'MessageBox.Show(ListView1.Items(icount).SubItems(3).Text)
                    'lvwMainData.Items(iCount).Selected = True
                    msgMaster.Text = iCount & " | " & lvwMainData.SelectedItems.Count - 1 & " - Lade Bild hoch..."

                    If strLokalFile = "" Then
                        strLokalFile = lvwMainData.SelectedItems(iCount).SubItems(3).Text
                    End If

                    '# Kein Fehler beim Verarbeiten
                    If Not strLokalFile = "error" Then
                        HttpUploadFile(My.Settings.SHOPSTE_API_URL, strLokalFile, "system_upload", "image/jpeg", nvc)
                    End If

                    My.Settings.Save()


                Else
                    If MessageBox.Show("Artikel '" & lvwMainData.SelectedItems(0).SubItems(0).Text & "' nicht korrekt eingestellt." + vbCrLf + "Wird Artikel wird fehlen, führe fort...?", "API Import", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.No Then
                        Exit For
                    End If
                End If
                lvwMainData.EnsureVisible(iCount)
                Application.DoEvents()


            Next

            msgMaster.Text = "Alle Aufgaben abgeschlossen"

            If (strImportError.Length > 0) Then
                MessageBox.Show("Es sind Fehler aufgetreten bei:" & vbCrLf & vbCrLf & strImportError)
            Else
                MessageBox.Show("Alle Produkte wurden importiert", "Import fertig", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Sub HttpUploadFile(
     ByVal uri As String,
     ByVal filePath As String,
     ByVal fileParameterName As String,
     ByVal contentType As String,
     ByVal otherParameters As Specialized.NameValueCollection)

        Dim boundary As String = "---------------------------" & DateTime.Now.Ticks.ToString("x")
        Dim newLine As String = System.Environment.NewLine
        Dim boundaryBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(newLine & "--" & boundary & newLine)
        Dim request As HttpWebRequest = WebRequest.Create(uri)

        request.ContentType = "multipart/form-data; boundary=" & boundary
        request.Method = "POST"
        request.KeepAlive = True
        request.Credentials = CredentialCache.DefaultCredentials

        Using requestStream As IO.Stream = request.GetRequestStream()

            Dim formDataTemplate As String = "Content-Disposition: form-data; name=""{0}""{1}{1}{2}"

            For Each key As String In otherParameters.Keys

                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length)
                Dim formItem As String = String.Format(formDataTemplate, key, newLine, otherParameters(key))
                Dim formItemBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(formItem)
                requestStream.Write(formItemBytes, 0, formItemBytes.Length)

            Next key

            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length)

            Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""{2}Content-Type: {3}{2}{2}"
            Dim header As String = String.Format(headerTemplate, fileParameterName, filePath, newLine, contentType)
            Dim headerBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(header)
            requestStream.Write(headerBytes, 0, headerBytes.Length)

            Using fileStream As New IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.Read)

                Dim buffer(4096) As Byte
                Dim bytesRead As Int32 = fileStream.Read(buffer, 0, buffer.Length)

                Do While (bytesRead > 0)

                    requestStream.Write(buffer, 0, bytesRead)
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length)

                Loop

            End Using

            Dim trailer As Byte() = System.Text.Encoding.ASCII.GetBytes(newLine & "--" + boundary + "--" & newLine)
            requestStream.Write(trailer, 0, trailer.Length)

        End Using

        Dim response As WebResponse = Nothing

        Try

            response = request.GetResponse()

            Using responseStream As IO.Stream = response.GetResponseStream()

                Using responseReader As New IO.StreamReader(responseStream)

                    Dim responseText = responseReader.ReadToEnd()
                    Diagnostics.Debug.Write(responseText)

                End Using

            End Using

        Catch exception As WebException

            response = exception.Response

            If (response IsNot Nothing) Then

                Using reader As New IO.StreamReader(response.GetResponseStream())

                    Dim responseText = reader.ReadToEnd()
                    MessageBox.Show(responseText)
                    Diagnostics.Debug.Write(responseText)

                End Using

                response.Close()

            End If

        Finally

            request = Nothing

        End Try

    End Sub
    Private Sub btnLoadArtikel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnÜbertrage.Click
        lvwMainData.Items.Clear()
        getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=getSyncStatus&domain_id=" & My.Settings.SHOPSTE_domain_id, mgetUpdaterMessage.getShopsteArtikel, True)

        Dim strData As String = My.Computer.FileSystem.ReadAllText("shopste-itemlist.dat")
        Dim strData_split() As String
        strData_split = strData.Split(vbLf)
        Dim iCount As Integer = 0

        For iCount = 0 To strData_split.Length - 2
            Dim strFields() As String = strData_split(iCount).Split(";")
            '0 = ID
            '1 = Menge
            '2 = Name
            '3 = Artikelnummer
            clsDB.getSYNC_status(strFields)
        Next
        MessageBox.Show("Alle Artikel verarbeitet von Domain" & My.Settings.SHOPSTE_domainname)
    End Sub

    '################################################################
    '# >> setTranslateJTLWaWiArtikel
    '# - Artikel Übersetzen 
    '################################################################
    Private Function setTranslateJTLWaWiArtikel() As Boolean
        Dim i As Integer = 0
        Dim strName As String = ""
        Dim strKurzbeschreibung As String = ""
        Dim strBeschreibung As String = ""
        Dim iLengthNext As Integer = 1200
        Dim iLengthNext_tmp As Integer = 0
        Dim dblTranslationCount As Double = 0
        Dim strZielSpracheISO As String = ""
        '# Alle selektierten 
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = lvwMainData.SelectedItems.Count - 1
        ToolStripProgressBar1.Visible = True
        btnÜbertrage.Enabled = False
        lvwMainData.Enabled = False

        strZielSpracheISO = clsDB.getGoogle2TranslationCode(cmbZielSpache.Text)
        Try
            Dim strSprachenUsed As String

            '# Alle Sprachen ausgeben
            Dim sqlConn3 As New SqlConnection(clsDB.strConnectionString)
            sqlConn3.Open()

            strSprachenUsed = "SELECT * FROM tSpracheUsed Where cNameDeu='" & cmbZielSpache.Text & "'"
            Dim sqlComm3 As New SqlCommand(strSprachenUsed, sqlConn3)
            Dim r2 As SqlDataReader = sqlComm3.ExecuteReader()
            Dim strJTLSprachen(0) As String
            Dim strJTLSprachen_id(0) As String
            Dim iCount As Integer = 0
            ReDim Preserve strJTLSprachen(strJTLSprachen.Length)
            ReDim Preserve strJTLSprachen_id(strJTLSprachen.Length)
            While r2.Read()
                strJTLSprachen(iCount) = r2("cNameDeu").ToString
                strJTLSprachen_id(iCount) = r2("kSprache").ToString

                ReDim Preserve strJTLSprachen(iCount + 1)
                ReDim Preserve strJTLSprachen_id(iCount + 1)
                iCount += 1
            End While

            '# Alle Sprachen in einem Durchlauf übersetzen
            Dim iSprachenCount As Integer = 0
            If My.Settings.chkTranslate_normal_alleSprachen = True Then
                iSprachenCount = cmbZielSpache.Items.Count - 1

            Else
                iSprachenCount = 1
            End If

            For i = 0 To lvwMainData.SelectedItems.Count - 1

                If bAbbruch = True Then
                    Exit For
                End If

                For iSprachen = 1 To iSprachenCount
                    If Not iSprachen = 1 Then
                        cmbZielSpache.SelectedIndex = iSprachen
                        Application.DoEvents()
                        strZielSpracheISO = clsDB.getGoogle2TranslationCode(cmbZielSpache.Text)

                    End If


                    msgMaster.Text = i + 1 & " - " & lvwMainData.SelectedItems.Count - 1 & " -> " & lvwMainData.SelectedItems(i).SubItems(1).Text & "übersetze Eigenschaften"

                    If Not lvwMainData.SelectedItems(i).SubItems(8).Text = "0" Then
                        'clsDB.setSpracheigenschaften_translate(lvwMainData.SelectedItems(i), cmbZielSpache.Text, strJTLSprachen_id(0))
                        clsDB.setSprachEigenSchaftWert_translate(lvwMainData.SelectedItems(i), cmbZielSpache.Text, strJTLSprachen_id(0))
                    End If

                    Application.DoEvents()

                    If lvwMainData.SelectedItems(i).SubItems(1).Text.Length > 0 Then
                        strName = getTranslateText(lvwMainData.SelectedItems(i).SubItems(1).Text, "de", strZielSpracheISO).Replace("&quot;", """")
                    End If

                    ToolStripProgressBar1.Value = i

                    lvwMainData.EnsureVisible(i)

                    msgMaster.Text = strName
                    Application.DoEvents()

                    strKurzbeschreibung = lvwMainData.SelectedItems(i).SubItems(3).Text
                    strKurzbeschreibung = strKurzbeschreibung.Replace("&nbsp;", " ").Replace("<P>", "").Replace("</P>", "").Replace("<BR>", "").Replace("&uuml;", "ü").Replace("&auml;", "ä").Replace("&ouml;", "ö").Replace("&Auml;", "Ä").Replace("&Ouml;", "Ö").Replace("&Uuml;", "Ü")

                    If strKurzbeschreibung.Length > 0 Then

                        strKurzbeschreibung = getTranslateText(strKurzbeschreibung, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("</ p>", "</p>").Replace("</ span>", "</span>").Replace("<  / div>", "</div>").Replace("</ div>", "</div>").Replace("<  br />", "<br/>").Replace("</ font>", "</font>").Replace("</ strong>", "</strong>").Replace("</ div  >", "</div>").Replace("</  div>", "</div>").Replace("P>", "").Replace("u>", "").Replace("&#39;", "'")
                    End If

                    If strKurzbeschreibung = "<div>" Then
                        strKurzbeschreibung = ""
                    End If

                    strBeschreibung = lvwMainData.SelectedItems(i).SubItems(4).Text
                    '##################################################################################
                    '# >> Größere Übersetzung
                    '##################################################################################
                    If strBeschreibung.Length > 1200 Then
                        Dim bStop As Boolean = False
                        Dim strBeschreibung_tmp As String = ""
                        iLengthNext_tmp = 0
                        While bStop = False
                            strBeschreibung = lvwMainData.SelectedItems(i).SubItems(4).Text
                            'dblTranslationCount = Math.Round(strBeschreibung.Length / 1200)
                            ' 1203
                            If iLengthNext > strBeschreibung.Length Then
                                bStop = True
                                iLengthNext = strBeschreibung.Length
                            End If

                            iLengthNext = strBeschreibung.IndexOf(" ", iLengthNext)
                            If iLengthNext = -1 Then
                                iLengthNext = strBeschreibung.Length
                            End If

                            If iLengthNext_tmp > iLengthNext Then
                                Exit While
                            Else
                                strBeschreibung = strBeschreibung.Substring(iLengthNext_tmp, iLengthNext - iLengthNext_tmp)
                            End If


                            strBeschreibung = strBeschreibung.Replace("&nbsp;", " ").Replace("<P>", "").Replace("</P>", "").Replace("<BR>", "").Replace("&uuml;", "ü").Replace("&auml;", "ä").Replace("&ouml;", "ö").Replace("&Auml;", "Ä").Replace("&Ouml;", "Ö").Replace("&Uuml;", "Ü").Replace("&szlig;", "ß")
                            If strBeschreibung.Length > 0 Then
                                strBeschreibung = getTranslateText(strBeschreibung, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("</ p>", "</p>").Replace("</ span>", "</span>").Replace("<  / div>", "</div>").Replace("</ div>", "</div>").Replace("<  br />", "<br/>").Replace("</ font>", "</font>").Replace("</ strong>", "</strong>").Replace("</ div  >", "</div>").Replace("</  div>", "</div>").Replace("P>", "").Replace("u>", "").Replace("&#39;", "'")
                            End If

                            iLengthNext_tmp += iLengthNext
                            iLengthNext += 1200
                            strBeschreibung_tmp &= strBeschreibung
                        End While
                        'MessageBox.Show(strBeschreibung_tmp)
                        strBeschreibung = strBeschreibung_tmp
                    Else
                        '##############################################################################
                        '# >> Einzel Übersetzung 
                        '##############################################################################
                        strBeschreibung = strBeschreibung.Replace("&nbsp;", " ").Replace("<P>", "").Replace("</P>", "").Replace("<BR>", "").Replace("&uuml;", "ü").Replace("&auml;", "ä").Replace("&ouml;", "ö").Replace("&Auml;", "Ä").Replace("&Ouml;", "Ö").Replace("&Uuml;", "Ü").Replace("&szlig;", "ß")
                        If strBeschreibung.Length > 0 Then
                            strBeschreibung = getTranslateText(strBeschreibung, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("</ p>", "</p>").Replace("</ span>", "</span>").Replace("<  / div>", "</div>").Replace("</ div>", "</div>").Replace("<  br />", "<br/>").Replace("</ font>", "</font>").Replace("</ strong>", "</strong>").Replace("</ div  >", "</div>").Replace("</  div>", "</div>").Replace("P>", "").Replace("u>", "").Replace("&#39;", "'")
                        End If

                    End If


                    'MessageBox.Show(strBeschreibung)
                    strBeschreibung = strBeschreibung.Replace("'", "''")
                    strKurzbeschreibung = strKurzbeschreibung.Replace("'", "''")

                    '# UPDATE oder INSERT
                    If clsDB.chkIsTranslated(lvwMainData.SelectedItems(i).SubItems(7).Text) = True Then
                        '# UPDATE 
                        If clsDB.setUPDATE_TextData(lvwMainData.SelectedItems(i).SubItems(7).Text, strName, strKurzbeschreibung, strBeschreibung, lvwMainData, i) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & lvwMainData.SelectedItems(i).SubItems(1).Text)
                            Exit For
                        End If

                    Else
                        '# INSERT
                        If clsDB.setINSERT_TextData(lvwMainData.SelectedItems(i).SubItems(7).Text, strName, strKurzbeschreibung, strBeschreibung, lvwMainData, i) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & lvwMainData.SelectedItems(i).SubItems(1).Text)
                            Exit For
                        End If
                    End If

                    '####################################
                    '# >> Funktionsattribute übersetzen
                    '####################################
                    If My.Settings.chkTranslate_normal_funktionsattribute_aktiv = True Then
                        clsDB.getFunktionsattribut(lvwMainData.SelectedItems(i).SubItems(7).Text)
                    End If

                    '#######################################
                    '# >> Artikel Merkmale übersetzen
                    '#######################################
                    If My.Settings.chkTranslate_normale_merkmale_aktiv = True Then
                        clsDB.setMerkmale(lvwMainData.SelectedItems(i).SubItems(7).Text)
                    End If

                Next

            Next

            MessageBox.Show(lvwMainData.SelectedItems.Count & "x Übersetzungen in JTL eingefügt mit (" & clsDB.dblQuellspracheZeichen & " Zeichen)", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim strServerInfo2() As String = getHTTPResponseMessage("https://api.bludau-media.de//SafeSandy/jtl-translator.php?auth_key=" & gbl_KeyCode & "&zeichen=" & clsDB.dblQuellspracheZeichen & "&modus=update_anzahl", mgetUpdaterMessage.getÜbersetzungGesammtSumme, True)
            Zeichenzähler.Text = clsDB.dblQuellspracheZeichen
            clsDB.dblQuellspracheZeichen = 0

            ToolStripProgressBar1.Visible = False
            btnÜbertrage.Enabled = True
            lvwMainData.Enabled = True

            If bIsKomplettÜbersetzung = False Then
                lvwMainData.Items.Clear()
            End If


            If lvwArtikel_kategorien.SelectedItems.Count > 0 Then
                Call clsDB.getKategorie2Artikel(lvwArtikel_kategorien.SelectedItems(0).Text, lvwMainData, lvwArtikel_kategorien)
            End If

            'clsDB.getArtikelListe(lvwMainData, chkTranslateMissing.Checked)
        Catch ex As Exception
            btnÜbertrage.Enabled = True
            lvwMainData.Enabled = True
            ToolStripProgressBar1.Visible = False
            Return False
        End Try

        Return True
    End Function

    Private Sub ÜbersetzenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÜbersetzenToolStripMenuItem.Click
        Call submit2shopste()
    End Sub
    '#################################################################
    '# >> Sortieren 
    '#################################################################
    Public Function setSort(ByRef listview1 As ListView, ByVal e As _
      System.Windows.Forms.ColumnClickEventArgs) As Boolean
        Try
            If bIsLoading = False Then

                If col = e.Column Then
                    If listview1.Sorting = SortOrder.Descending Then
                        listview1.Sorting = SortOrder.Ascending
                    Else
                        listview1.Sorting = SortOrder.Descending
                    End If
                Else
                    listview1.Sorting = SortOrder.Ascending
                End If

                col = e.Column

                '###########################
                '# >> Listviewnamen ermitteln 
                '###########################
                Select Case listview1.Name
                    Case "lvwMainData"
                        Select Case col
                            Case 0
                                listview1.ListViewItemSorter = New lvsorter(Of Integer)(e.Column)
                            Case 9
                                listview1.ListViewItemSorter = New lvsorter(Of Double)(e.Column)
                            Case 10
                                listview1.ListViewItemSorter = New lvsorter(Of Double)(e.Column)
                            Case 15
                                listview1.ListViewItemSorter = New lvsorter(Of Double)(e.Column)
                            Case Else
                                listview1.ListViewItemSorter = New lvsorter(Of String)(e.Column)
                        End Select




                End Select
            End If



            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function

    Public Function setPOST(Post As String, strURL As String) As String

        Dim Request As HttpWebRequest = CType(WebRequest.Create(strURL), HttpWebRequest)
        Request.Method = "POST"
        Request.ContentType = "application/x-www-form-urlencoded"

        Dim byteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(Post)
        Request.ContentLength = byteArray.Length
        Dim DataStream As System.IO.Stream = Request.GetRequestStream()
        DataStream.Write(byteArray, 0, byteArray.Length)
        DataStream.Close()
        Dim Response As HttpWebResponse = Request.GetResponse()
        DataStream = Response.GetResponseStream()
        Dim reader As New System.IO.StreamReader(DataStream)
        Dim ServerResponse As String = reader.ReadToEnd()
        reader.Close()
        DataStream.Close()
        Response.Close()

    End Function
    Private Sub submit2shopste()
        Dim strLokalFile As String
        Dim strLast As String
        Dim strImportError As String = ""
        Dim iCount As Integer = 0
        Dim strBeschreibung As String = ""
        Dim strInfo() As String
        'If lvwMenue.SelectedItems(0).Text.Length = 0 Then
        '    MessageBox.Show("Bitte EiSo Shop Menü auswählen", "Artikelauswahl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If

        If lvwMainData.SelectedItems.Count = 0 Then
            MessageBox.Show("Bitte Artikel auswählen um diese nach Shopste.com zu übertragen STRG + Artikelklick oder STRG + A", "Artikelauswahl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If




        For iCount = 0 To lvwMainData.SelectedItems.Count - 1
            Dim strMenue() As String = lvwMainData.SelectedItems(iCount).SubItems(12).Text.Split(",")
            getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=get_shopste_kategorie_by_jtlcatid&jtl_cat_id=" & strMenue(0) & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD, mgetUpdaterMessage.getEiSo2ShopsteKat, False)


            If Not IsNumeric(strHTTPDataStore) = True Then
                MessageBox.Show("Es wurde keine gültige Shopste.com Kategorie gefunden.", "ungültige Kategorie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Continue For
            End If

            ' lvwMainData.Items(iCount).Selected = True
            ' Application.DoEvents()

            Dim Request As HttpWebRequest = CType(WebRequest.Create(My.Settings.SHOPSTE_API_URL), HttpWebRequest)
            Request.Method = "POST"
            Request.ContentType = "application/x-www-form-urlencoded"
            ' frmMain.master_Message_label.Text = iCount & " | " & lvwMainData.SelectedItems.Count - 1 & " - Bereite einfügen vor..."
            Application.DoEvents()
            'MessageBox.Show(System.Net.WebUtility.HtmlEncode(ListView1.SelectedItems(0).SubItems(0).Text))
            'System.Net.WebUtility.HtmlEncode
            ' Dim strBeschreibung As String
            ' If chkImportKeineHTMLBeschreibung.Checked = False Then
            strBeschreibung = HttpUtility.UrlEncode(HttpUtility.HtmlEncode(lvwMainData.SelectedItems(iCount).SubItems(4).Text))
            ' Else
            ' strBeschreibung = HttpUtility.UrlEncode(lvwMainData.SelectedItems(0).SubItems(0).Text)
            ' End If

            '# Letztes zu importierendes Produkt?
            If iCount = lvwMainData.SelectedItems.Count - 1 Then
                strLast = "true"
            Else
                strLast = "false"
            End If

            Dim Post As String = "modus=system_shop_item_add&submodus=jtl2shopste&domain_id=" & My.Settings.SHOPSTE_domain_id & "&shop_item_beschreibung=" & strBeschreibung & "&shop_item_menge=" & lvwMainData.SelectedItems(iCount).SubItems(10).Text & "&shop_item_price=" & lvwMainData.SelectedItems(iCount).SubItems(9).Text.Replace(",", ".") & "&shop_item_name=" & HttpUtility.UrlEncode(lvwMainData.SelectedItems(iCount).SubItems(1).Text) & "&shop_item_duration=15&shop_item_mwst=" & lvwMainData.SelectedItems(iCount).SubItems(14).Text & "&shop_item_artikelnummer=" & lvwMainData.SelectedItems(iCount).SubItems(13).Text & "&gewicht=" & lvwMainData.SelectedItems(iCount).SubItems(15).Text.Replace(",", ".") & "&bLastItem=" & strLast & "&user=" & My.Settings.SHOPSTE_USERNAME & "&subshop_cat=" & strHTTPDataStore & "&shopste_cat=" & lvwMainData.SelectedItems(iCount).SubItems(16).Text & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD
            '1 Eigenschaftname (1x)
            '2 Eigenschaftswert (unbestimmt x)

            ' Clipboard.SetText(WebUtility.HtmlEncode(ListView1.SelectedItems(0).SubItems(5).Text))

            'Dim postQuery As Byte() = System.Text.Encoding.ASCII.GetBytes("Post 

            Dim byteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(Post)
            Request.ContentLength = byteArray.Length
            Dim DataStream As System.IO.Stream = Request.GetRequestStream()
            DataStream.Write(byteArray, 0, byteArray.Length)
            DataStream.Close()
            Dim Response As HttpWebResponse = Request.GetResponse()
            DataStream = Response.GetResponseStream()
            Dim reader As New System.IO.StreamReader(DataStream)
            Dim ServerResponse As String = reader.ReadToEnd()
            reader.Close()
            DataStream.Close()
            Response.Close()



            If InStr(ServerResponse, "shopid") Then
                Dim str() As String = ServerResponse.Split(":")
                Dim strShopID As String = str(1)

                '# Hat Artikel Eigenschaft
                If Not lvwMainData.SelectedItems(iCount).SubItems(8).Text = 0 Then
                    Dim strEigenschaftAry() As String = lvwMainData.SelectedItems(iCount).SubItems(8).Text.Split(",")
                    Dim iLoop As Integer = 0
                    Dim bIN As Boolean = False
                    For iLoop = 0 To strEigenschaftAry.Length - 1
                        Dim strEigenschaftName As String = clsDB.getEigenschaft(strEigenschaftAry(iLoop))
                        Dim strEigenschaftWerte() As String = clsDB.getEigenschaft_wert(strEigenschaftAry(iLoop))
                        bIN = True
                        Dim iCount_loop As Integer = 0

                        If iLoop = 0 Then
                            '# Shopste Attributset anlegen
                            strInfo = getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=setShopItem_eigenschaft_artibuteset&eigenschaftname=" & strEigenschaftName & "&domain_id=" & My.Settings.SHOPSTE_domain_id & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD, mgetUpdaterMessage.setShopItem_eigenschaft_artibuteset, False)

                        End If

                        '# Shopste Attributset mit Attribut verknüpfen
                        Dim strInfo1() As String = getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=setShopItem_eigenschaft_name&attribute_set_id=" & strInfo(0) & "&eigenschaftname=" & strEigenschaftName & "&domain_id=" & My.Settings.SHOPSTE_domain_id & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD, mgetUpdaterMessage.setShopItem_eigenschaft_name, False)


                        '# Shopste Attribut dem Eigenschaftswert zuordnen
                        Dim strInfo2() As String = getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=shop_item_eigenschaft&shop_attribute_id=" & strInfo1(0) & "&eigenschaft_name_de=" & strEigenschaftName & "&id_shop_item=" & strShopID & "&domain_id=" & My.Settings.SHOPSTE_domain_id & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD, mgetUpdaterMessage.shop_item_eigenschaft, False)

                        For iCount_loop = 0 To strEigenschaftWerte.Length - 1
                            If Not strEigenschaftWerte(iCount_loop) = Nothing Then
                                ' MessageBox.Show(strEigenschaftWerte(iCount_loop))


                                '# Shopste Attribute mit Werten füllen
                                Dim strInfo4() As String = getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=setShopItem_eigenschaft_value&shop_attribute_id=" & strInfo1(0) & "&value_de=" & strEigenschaftWerte(iCount_loop) & "&domain_id=" & My.Settings.SHOPSTE_domain_id & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD, mgetUpdaterMessage.setShopItem_eigenschaft_value, False)


                                '# Shopste Attribut dem Eigenschaftswert zuordnen
                                Dim strInfo3() As String = getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=setShopItem_eigenschaftwert&shop_attribute_id=" & strInfo2(0) & "&eigenschaft_name_de=" & strEigenschaftWerte(iCount_loop) & "&id_shop_item=" & strShopID & "&shop_attribut_value_id=" & strInfo4(0) & "&domain_id=" & My.Settings.SHOPSTE_domain_id & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD, mgetUpdaterMessage.setShopItem_eigenschaftwert, False)

                                '# Shopste Variationsartikel anlegen


                            End If

                        Next

                    Next
                    If bIN = True Then
                        Dim Post1 As String = "modus=api_attribute_combinations&attributset_id=" & strInfo(0) & "&shop_item_id=" & strShopID & "domain_id=" & My.Settings.SHOPSTE_domain_id & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD

                        '# Kindartikel an Shopste übergeben
                        Call setPOST(Post1, "https://shopste.com/ACP/acp_shop_attribute_kombination.php")

                    End If

                End If

                'clsDatenbank_modul.setEiSoArtikelverwaltung_shopste_summary(lvwMainData.SelectedItems(0).Text, str(1), lvwMainData.SelectedItems(iCount).SubItems(9).Text)

                ' frmMain.master_Message_label.Text = iCount & " | " & lvwMainData.SelectedItems.Count - 1 & " - Shop ID:" & ServerResponse

                If Not lvwMainData.SelectedItems(iCount).SubItems(11).Text.Length = 0 Then


                    Dim strFileName() As String = lvwMainData.SelectedItems(iCount).SubItems(11).Text.Split("/")

                    Dim nvc As New Specialized.NameValueCollection
                    nvc.Add("modus", "system_upload_file")
                    nvc.Add("domain_id", My.Settings.SHOPSTE_domain_id)
                    nvc.Add("benutzername", My.Settings.SHOPSTE_USERNAME)
                    nvc.Add("domain_pfad", My.Settings.SHOPSTE_domainname)
                    nvc.Add("shop_id", strShopID)
                    ' nvc.Add("picture_name", lvwMainData.Items(iCount).SubItems(3).Text.Replace(" ", "_").Replace(">", "-").Replace("/", "").Replace("\", "").Replace("!", ""))

                    Dim strBildNameAry() As String = lvwMainData.SelectedItems(iCount).SubItems(1).Text.Split("/")

                    Dim strBildName As String = strBildNameAry(strBildNameAry.Length - 1).Replace(" ", "_").Replace(">", "-").Replace("/", "").Replace("\", "").Replace("!", "").Replace("*", "").Replace("<", "-") & ".jpg"

                    nvc.Add("picture_name", strBildName.Replace("\", "-").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("""", "").Replace("<", "").Replace(">", "").Replace("|", ""))

                    '# Externe Bilder - HTTP Link
                    If Not lvwMainData.SelectedItems(iCount).SubItems(11).Text.LastIndexOf("http://") = -1 Or Not lvwMainData.SelectedItems(iCount).SubItems(11).Text.LastIndexOf("https://") = -1 Then

                        Dim client As New WebClient()

                        'Dim strBild As String
                        'Dim strBild_ary() As String
                        'Dim strBildFixed As String = strFileName(strFileName.Length - 1).Replace("\", "-").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("""", "").Replace("<", "").Replace(">", "").Replace("|", "")
                        'MessageBox.Show(Application.StartupPath)
                        ' Dim strPath As String = IO.Path.GetDirectoryName(Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
                        ' MessageBox.Show(Application.StartupPath)

                        'strBild = lvwMainData.SelectedItems(iCount).SubItems(3).Text

                        Try
                            strBildName = strBildName.Replace("\", "-").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("""", "").Replace("<", "").Replace(">", "").Replace("|", "")

                            If strBildName.Length > 240 Then
                                strBildName = strBildName.Substring(0, 240)
                            End If
                            client.DownloadFile(lvwMainData.SelectedItems(iCount).SubItems(11).Text, Application.StartupPath & "\bilderexport\" & strBildName)
                            strLokalFile = Application.StartupPath & "\bilderexport\" & strBildName
                        Catch ex As Exception
                            strLokalFile = "error"
                            strImportError &= lvwMainData.SelectedItems(iCount).SubItems(3).Text & vbCrLf
                        End Try


                    Else
                        strLokalFile = ""
                    End If

                    'HttpUploadFile("http://shopste.com/api.php", "C:\Users\jbludau\Desktop\gelb_katze.jpg", "system_upload", "image/jpeg", nvc)
                    'MessageBox.Show(ListView1.Items(icount).SubItems(3).Text)
                    'lvwMainData.Items(iCount).Selected = True
                    'frmMain.master_Message_label.Text = iCount & " | " & lvwMainData.SelectedItems.Count - 1 & " - Lade Bild hoch..."

                    If strLokalFile = "" Then
                        strLokalFile = lvwMainData.SelectedItems(iCount).SubItems(11).Text
                    End If

                    '# Kein Fehler beim Verarbeiten
                    If Not strLokalFile = "error" Then
                        HttpUploadFile(My.Settings.SHOPSTE_API_URL, strLokalFile, "system_upload", "image/jpeg", nvc)
                    End If
                End If

                My.Settings.Save()


                Else
                    If MessageBox.Show("Artikel '" & lvwMainData.SelectedItems(0).SubItems(0).Text & "' nicht korrekt eingestellt." + vbCrLf + "Wird Artikel wird fehlen, führe fort...?", "API Import", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.No Then
                    Exit For
                End If
            End If
            lvwMainData.EnsureVisible(iCount)
            Application.DoEvents()


        Next

        '  frmMain.master_Message_label.Text = "Alle Aufgaben abgeschlossen"

        If (strImportError.Length > 0) Then
            MessageBox.Show("Es sind Fehler aufgetreten bei:" & vbCrLf & vbCrLf & strImportError)
        Else
            MessageBox.Show("Alle Produkte wurden importiert", "Import fertig", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub AllesMarkierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllesMarkierenToolStripMenuItem.Click
        Dim i As Integer = 0
        For i = 0 To lvwMainData.Items.Count - 1
            lvwMainData.Items(i).Selected = True
        Next
    End Sub
    '########################################################################
    '# >> Text übersetzen 
    '########################################################################
    Public Function getTranslateText(ByVal TextToTranslate As String, ByVal lngInput As String, ByVal lngOutput As String) As String
        Dim result As String
        Try

            Dim url As String = [String].Format("http://www.google.de/translate_t?hl=de&ie=UTF8&text={0}&langpair={1}|{2}", System.Uri.EscapeDataString(TextToTranslate), lngInput, lngOutput)
            Dim webClient As New Net.WebClient()

            Dim iLänge As Integer = 0
            '  webClient.Encoding = System.Text.Encoding.ASCII
            'webClient.Encoding = System.Text.Encoding.Unicode
            ' webClient.Encoding = System.Text.Encoding.GetEncoding(1251)
            If My.Settings.Webproxy(My.Settings.mandant_position).Length > 0 Then
                Dim str2() As String = My.Settings.Webproxy(My.Settings.mandant_position).Split(":")
                Dim pr As New System.Net.WebProxy(str2(0), Convert.ToInt16(str2(1)))
                webClient.Proxy = pr
            End If

            ' msgMaster.Text = url
            Application.DoEvents()
            result = webClient.DownloadString(url)

            Dim match As String = "id=result_box"
            Dim i As Integer = result.IndexOf(match) + 1
            Dim f As Integer = result.IndexOf(match) + 1
            Dim iStart As Integer = 0
            Dim iEnde As Integer = 0
            Dim iLängeLen As Integer = 0
            Dim bExit As Boolean = False
            Dim str() As String

            '##################################
            '# ANFANG und ENDE bestimmen
            '##################################
            result = Mid(result, i, f)
            result = Mid(result, result.IndexOf(">") + 2, Len(result))

            'iStart = result.IndexOf("</div><div id=""translit")

            iStart = result.IndexOf("</div></div><div id=gt-res-tools")
            result = Strings.Left(result, iStart)

            bExit = False
            Dim iCount As Integer = 0
            ReDim str(0)
            iStart = 0
            iEnde = 0

            '########################################
            '# Google Translate 
            '# - Maus Hover Parser 
            '########################################
            While bExit = False

                ' iLängeGes = result.IndexOf("<span title", iLänge + 1)                
                iStart = result.IndexOf("'#fff'"">", iStart + 1) ' iStart = result.IndexOf("'#fff'"">", iStart + 1)
                iEnde = result.IndexOf("</span>", iEnde + 2)

                If iStart >= 0 Then
                    str(iCount) = Mid(result, iStart, iEnde - (iStart - 1)).Replace("='#fff'"">", "").Replace("</span", "")
                    ReDim Preserve str(UBound(str) + 1)
                    iCount += 1
                Else
                    bExit = True
                End If

            End While

            '# String wieder zusammenbauen 
            result = ""
            For iCount = 0 To str.Length - 1
                result &= str(iCount) & " "
            Next
            'result = Mid(result, 1, iLänge)

            ' result = Mid(result, result.IndexOf("<span title"), result.IndexOf("'#fff'"">"))
            'result = clsDatenbank_modul.getTranslateSearch_replace(result.Trim, lngOutput)

        Catch ex As Exception
            bAbbruch = True
            result = String.Empty
            MessageBox.Show(ex.Message)
        End Try
        Return result

    End Function




    Private Sub NameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer = 0
        Dim strName As String = ""
        Dim strZielSpracheISO As String
        strZielSpracheISO = clsDB.getGoogle2TranslationCode(cmbZielSpache.Text)
        '# Alle selektierten 
        For i = 0 To lvwMainData.SelectedItems.Count - 1

            strName = getTranslateText(lvwMainData.SelectedItems(i).SubItems(1).Text, "de", strZielSpracheISO)
            lvwMainData.SelectedItems(i).SubItems(2).Text = strName

            MessageBox.Show(strName)
        Next

    End Sub

    Private Sub KurzbeschreibungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer = 0
        Dim strName As String = ""
        Dim strKurzbeschreibung As String = ""
        Dim strBeschreibung As String = ""
        Dim strZielSpracheISO As String
        strZielSpracheISO = clsDB.getGoogle2TranslationCode(cmbZielSpache.Text)
        '# Alle selektierten 
        For i = 0 To lvwMainData.SelectedItems.Count - 1

            strKurzbeschreibung = lvwMainData.SelectedItems(i).SubItems(3).Text
            strKurzbeschreibung = strKurzbeschreibung.Replace("&nbsp;", " ").Replace("<P>", "").Replace("</P>", "").Replace("<BR>", "")
            strKurzbeschreibung = getTranslateText(strKurzbeschreibung, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">")
            lvwMainData.SelectedItems(i).SubItems(5).Text = strKurzbeschreibung
            MessageBox.Show(strKurzbeschreibung)
        Next

    End Sub

    Private Sub BeschreibungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer = 0
        Dim strBeschreibung As String = ""
        Dim strZielSpracheISO As String
        strZielSpracheISO = clsDB.getGoogle2TranslationCode(cmbZielSpache.Text)
        '# Alle selektierten 
        For i = 0 To lvwMainData.SelectedItems.Count - 1
            strBeschreibung = lvwMainData.SelectedItems(i).SubItems(4).Text
            strBeschreibung = strBeschreibung.Replace("&nbsp;", " ").Replace("<P>", "").Replace("</P>", "")
            strBeschreibung = getTranslateText(strBeschreibung, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">")
            lvwMainData.SelectedItems(i).SubItems(6).Text = strBeschreibung
            MessageBox.Show(strBeschreibung)
        Next

    End Sub

    Private Sub ÜbersetzungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÜbersetzungToolStripMenuItem.Click
        Dim frmTransOption As New frmTranslateEinstellungen
        frmTransOption.ShowDialog()
    End Sub

    Private Sub lvwMainData_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwMainData.DoubleClick
        Dim frmTranslateVorschau As New frmTranslateVorschau
        frmTranslateVorschau.strDeutschBeschreibung = lvwMainData.SelectedItems(0).SubItems(4).Text
        frmTranslateVorschau.strEnglischBeschreibung = lvwMainData.SelectedItems(0).SubItems(6).Text
        frmTranslateVorschau.strProduktname = lvwMainData.SelectedItems(0).SubItems(1).Text
        frmTranslateVorschau.strProduktNameEnglisch = lvwMainData.SelectedItems(0).SubItems(2).Text
        frmTranslateVorschau.strDeutschKurzbeschreibung = lvwMainData.SelectedItems(0).SubItems(3).Text
        frmTranslateVorschau.strEnglischKurzbeschreibung = lvwMainData.SelectedItems(0).SubItems(5).Text
        frmTranslateVorschau.iProduktID = lvwMainData.SelectedItems(0).SubItems(7).Text ' ProduktID

        frmTranslateVorschau.ShowDialog()

    End Sub

    Private Sub lvwMainData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwMainData.SelectedIndexChanged

    End Sub

    Private Sub btnArtikelTranslate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If bIsKomplettÜbersetzung = False Then
            If lvwMainData.Items.Count = 0 Then
                MessageBox.Show("Bitte erst Artikel einlesen, werden in der unteren Liste angezeigt.")
                Exit Sub
            End If

            If cmbZielSpache.Text.Contains("Deutsch") = True Then
                MessageBox.Show("Sie können keine Übersetzung ins Deutsche durchführen, weil Deutsch die Quellsprache ist")
                Exit Sub
            End If
        End If

        '   btnArtikelTranslate.Enabled = False
        btnÜbertrage.Enabled = False
        cmbMandant.Enabled = False
        cmbZielSpache.Enabled = False
        lvwArtikel_kategorien.Enabled = False

        If btnÜbertrage.Text = "Abbrechen" Then
            bAbbruch = True
            Exit Sub
        End If


        If cmbZielSpache.Text = "Deutsch" Then
            MessageBox.Show("Es macht keinen Sinn den Artikelstamm ins deutsche zu übersetzten, bitte wählen Sie eine andere Sprache (fügen Sie eine neue Sprache zuerst in JTL WaWi hinzu)")
            Exit Sub
        Else
            If lvwMainData.Items.Count = 0 Then
                If lvwMainData.Items.Count > 0 Then
                    lvwMainData.Items(0).Selected = True
                End If
            End If
            Call setTranslate_init()
        End If

        bAbbruch = False
        '  btnArtikelTranslate.Enabled = True
        btnÜbertrage.Enabled = True
        cmbMandant.Enabled = True
        cmbZielSpache.Enabled = True
        lvwArtikel_kategorien.Enabled = True
    End Sub

    '#########################################################
    '# >> Vorbereiten der Übersetzung
    '#########################################################
    Public Sub setTranslate_init()
        Dim iCount As Integer = 0

        If cmbZielSpache.Text.ToString.Contains("Deutsch").ToString = True Then
            MessageBox.Show("Die Quellsprache ist Deutsch, Sie können den Artikel nicht ins Deutsche übersetzen, bitte wählen Sie eine andere Zielsprache aus. Gegenfalls muss eine weitere Sprache wie z.B. Englisch erst in der JTL Wawi angelegt / aktiviert werden.")
            Exit Sub
        End If

        If bIsKomplettÜbersetzung = False Then
            If lvwMainData.SelectedItems.Count = 0 Then
                If MessageBox.Show("Möchten Sie alle Artikel übersetzen?", "JTL Translate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    For iCount = 0 To lvwMainData.Items.Count - 1
                        Try
                            lvwMainData.SelectedItems(iCount).Selected = True
                        Catch ex As Exception
                            lvwMainData.SelectedItems(1).Selected = True
                        End Try

                    Next
                End If
            ElseIf lvwMainData.SelectedItems.Count = 1 Then
                If MessageBox.Show("Möchten diesen 1 Artikel alleine übersetzen?", "JTL Translate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If
        End If

        If lvwMainData.SelectedItems.Count > 0 Then

            lvwArtikel_kategorien.Enabled = False
            If Not setTranslateJTLWaWiArtikel() = True Then
                MessageBox.Show("Es gab Fehler bei der Übersetzung" & vbCrLf & vbCrLf & "Artikel wurden teilweise / NICHT übersetzt!", "JTL Translate Übersetzung", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            lvwArtikel_kategorien.Enabled = False
        Else
            MessageBox.Show("Bitte mindestens 1 Artikel für die Übersetzung auswählen", "JTL Translate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    '#############################################################
    '# >> setComboFrmMainMandantWechsel
    '# Combobox Wechsel laden 
    '#############################################################
    Public Function setComboFrmMainMandantWechsel() As Boolean
        Try
            If bIsLoading = False Then
                My.Settings.mandant_letzter_name = cmbMandant.Text
                My.Settings.mandant_position = clsDB.chkMandantPosition(clsDB.getMandantDatabaseByMandantName(My.Settings.mandant_letzter_name))

                '# Settings initalisieren 
                Call setSettingsInit(My.Settings.mandant_position)

                '# Fehlerfall Profil wird angezeigt, es wurden aber keine Benutzerdaten hinterlegt 
                If My.Settings.db_username(My.Settings.mandant_position) = "" And Not My.Settings.db_datenbankname(My.Settings.mandant_position) = "" Then
                    msgMaster.Text = "Es muss das Datenbankprofil für ' " & My.Settings.mandant_letzter_name & "' vervollständigt werden!"
                    Dim frmDatenbankEinstellungen As New frmDatenbankEinstellungen
                    frmDatenbankEinstellungen.Show()
                End If

                My.Settings.Save()
                ' Call getLoadSettingsMandantWechsel(True)
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler bei setComboFrmMainMandantWechsel: " & ex.Message, "setComboFrmMainMandantWechsel()", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
    End Function
    '##################################################################################
    '# >> chkDBSettings
    '# - Prüfen ob Datenbank verfügbar ist 
    '##################################################################################
    Private Sub setDBSettings(ByVal bLoadMandantenCombo As Boolean)
        '# Mandanten Datenbank 
        ' If Not cmbMandant.Text = "" Then

        '##################################################
        '# easzybusiness Connection 
        '##################################################
        If clsDB.strConnectionString_eazybusiness = "" Then
            My.Settings.mandant_position = getMySettingsPositionByDatabase("eazybusiness")
            Dim strCon As String = "server=" & My.Settings.db_server.Item(My.Settings.mandant_position) & ";uid=" & My.Settings.db_username.Item(My.Settings.mandant_position) & ";pwd=" & My.Settings.db_passwort.Item(My.Settings.mandant_position) & ";database=" & My.Settings.db_datenbankname.Item(My.Settings.mandant_position) & ";"
            If clsDB.getDBConnect(strCon, True) = False Then
                Dim frmDBSetting As New frmDatenbankEinstellungen
                frmDBSetting.ShowDialog()
            End If
        End If

        '# Mandanten abrufen und in die combobox kopieren
        If bLoadMandantenCombo = True Then
            Call clsDB.setMandantbyCombobox(cmbMandant, False)
        End If

        '###################################################
        '# >> Normale Datenbankverbindung 
        '###################################################
        If Not cmbMandant.Text = "" Then
            My.Settings.db_datenbankname.Item(My.Settings.mandant_position) = clsDB.getMandantDatabaseByMandantName(cmbMandant.Text)
            My.Settings.Save()

            If My.Settings.db_datenbankname.Item(My.Settings.mandant_position) = "" Then
                My.Settings.db_datenbankname.Item(My.Settings.mandant_position) = "eazybusiness"
                Call setSettingsInit(My.Settings.mandant_position)
                My.Settings.mandant_position = clsDB.chkMandantPosition(My.Settings.db_datenbankname.Item(My.Settings.mandant_position))
            End If

            'End If        
            Dim strConDB As String = "server=" & My.Settings.db_server.Item(My.Settings.mandant_position) & ";uid=" & My.Settings.db_username.Item(My.Settings.mandant_position) & ";pwd=" & My.Settings.db_passwort.Item(My.Settings.mandant_position) & ";database=" & My.Settings.db_datenbankname.Item(My.Settings.mandant_position) & ";"
            If clsDB.getDBConnect(strConDB) = False Then
                Dim frmDBSetting As New frmDatenbankEinstellungen
                frmDBSetting.ShowDialog()
            End If
        Else
            MessageBox.Show("Es wurde kein Mandant gefunden!", "Combobox Mandant nicht geladen werden", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub
    Private Sub cmbMandant_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbMandant.SelectedIndexChanged

        If bIsLoading = False Then
            Call setComboFrmMainMandantWechsel()
            Call setDBSettings(False)

            Dim strOutput(1) As String
            strOutput = clsDB.getKategorieOberKategorie(0, 1)

            'TabControl1.SelectedIndex = 1

            '# Kategorien abrufen in Listview 
            lvwArtikel_kategorien.Items.Clear() ' Listview löschen
            Call clsDB.getKategorie(0, lvwArtikel_kategorien, 0)

            msgMaster.Text = "Artikel in der Kategorie " & lvwMainData.Items.Count - 1
        End If
    End Sub

    Private Sub TabPage1_Click(sender As System.Object, e As System.EventArgs) Handles TabPage1.Click

    End Sub

    '#############################################################################
    '# >> Privoxy und Tor Starten und beenden
    ''#############################################################################
    Public Function setStartupTorPrivoxy(bStartup As Boolean) As Boolean
        Dim bKillTor As Boolean = False
        Dim bKillPrivoxy As Boolean = False
        Dim strMessage As String = ""
        My.Settings.Save()

        If bStartup = True Then

            If TorStarup() = True Then
                If PrivoxyStarup() = True Then
                    'txtWebproxy.Text = "localhost:8118"
                    My.Settings.Webproxy(My.Settings.mandant_position) = "localhost:8118"
                    msgMaster.Text = "Tor ( " & gbl_tor_pid & " ) und Privoxy (" & gbl_privoxy_pid & ") wurden gestartet, die Proxy URL wurde automatisch geändert"
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
            msgMaster.Text = strMessage
        End If

    End Function
    Private Sub lvwArtikel_kategorien_Click(sender As Object, e As System.EventArgs) Handles lvwArtikel_kategorien.Click
        If lvwArtikel_kategorien.SelectedItems.Count > 0 And chkKategorieArtikel.Checked = True Then
            TabControl1.SelectedIndex = 0
            lvwArtikel_kategorien.Enabled = False

            btnÜbertrage.Enabled = False

            lvwMainData.Enabled = False
            cmbMandant.Enabled = False
            cmbZielSpache.Enabled = False
            Application.DoEvents()
            Call clsDB.getKategorie2Artikel(lvwArtikel_kategorien.SelectedItems(0).Text, lvwMainData, lvwArtikel_kategorien)

            msgMaster.Text = "Geladene Artikel: " & lvwMainData.Items.Count - 1
            Application.DoEvents()
            lvwArtikel_kategorien.Enabled = True
            btnÜbertrage.Enabled = True

            lvwMainData.Enabled = True
            cmbMandant.Enabled = True
            cmbZielSpache.Enabled = True
        End If
    End Sub

    Private Sub lvwArtikel_kategorien_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwArtikel_kategorien.SelectedIndexChanged

    End Sub

    Private Sub ProgrammupdateToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProgrammupdateToolStripMenuItem.Click
        Dim frmUpdater As New frmUpdater
        frmUpdater.ShowDialog()
    End Sub

    Private Sub BezeichnungKopierenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BezeichnungKopierenToolStripMenuItem.Click
        If lvwMainData.SelectedItems.Count > 0 Then
            Clipboard.SetText(lvwMainData.SelectedItems(0).SubItems(1).Text)
        End If
    End Sub

    Private Sub KurzbeschreibungKopierenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles KurzbeschreibungKopierenToolStripMenuItem.Click
        If lvwMainData.SelectedItems.Count > 0 Then
            Clipboard.SetText(lvwMainData.SelectedItems(0).SubItems(3).Text)
        End If
    End Sub

    Private Sub BeschreibungKopierenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BeschreibungKopierenToolStripMenuItem.Click
        If lvwMainData.SelectedItems.Count > 0 Then
            Clipboard.SetText(lvwMainData.SelectedItems(0).SubItems(4).Text)
        End If
    End Sub

    Private Sub CubssnetWebseiteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CubssnetWebseiteToolStripMenuItem.Click
        Dim ExterneAnwendung As New System.Diagnostics.Process()
        Dim strFile As String = "http://cubss.net"
        ExterneAnwendung.StartInfo.FileName = strFile
        ExterneAnwendung.Start()
        Application.Exit()
    End Sub

    Private Sub CubssnetKontaktToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CubssnetKontaktToolStripMenuItem.Click
        Dim ExterneAnwendung As New System.Diagnostics.Process()
        Dim strFile As String = "http://cubss.net/contacts/"
        ExterneAnwendung.StartInfo.FileName = strFile
        ExterneAnwendung.Start()
        Application.Exit()
    End Sub

    Private Sub ArtikelnummerKopierenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ArtikelnummerKopierenToolStripMenuItem.Click
        If lvwMainData.SelectedItems.Count > 0 Then
            Clipboard.SetText(lvwMainData.SelectedItems(0).Text)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Call setTranslateKategorie()
    End Sub
    '###################################################
    '# Kategorien übersetzen 
    '###################################################
    Public Function setTranslateKategorie() As Boolean
        Try
            Dim i As Integer = 0
            Dim strName As String = ""
            Dim strKurzbeschreibung As String = ""
            Dim strBeschreibung As String = ""
            Dim iLengthNext As Integer = 1200
            Dim iLengthNext_tmp As Integer = 0
            Dim dblTranslationCount As Double = 0
            '# Alle selektierten 
            ToolStripProgressBar1.Value = 0
            ToolStripProgressBar1.Maximum = lvwArtikel_kategorien.SelectedItems.Count - 1
            ToolStripProgressBar1.Visible = True
            btnÜbertrage.Enabled = False
            lvwMainData.Enabled = False
            lvwArtikel_kategorien.Enabled = False
            Dim strZielSpracheISO As String
            Dim strKatText As String = ""
            Dim strKat2Text() As String
            strZielSpracheISO = clsDB.getGoogle2TranslationCode(cmbZielSpache.Text)
            For i = 0 To lvwArtikel_kategorien.SelectedItems.Count - 1


                'strName = getTranslateText(lvwArtikel_kategorien.Items(i).SubItems(1).Text, "de", strZielSpracheISO).Replace("&quot;", """").Trim   
                If lvwArtikel_kategorien.SelectedItems(i).SubItems(1).Text.Length > 0 Then
                    StatusStrip1.Text = i & " | " & (lvwArtikel_kategorien.SelectedItems.Count - 1) & " - " + lvwArtikel_kategorien.SelectedItems(i).SubItems(1).Text
                    strName = getTranslateText(lvwArtikel_kategorien.SelectedItems(i).SubItems(1).Text, "de", strZielSpracheISO).Replace("&quot;", """").Trim

                    StatusStrip1.Text = i & " | " & (lvwArtikel_kategorien.SelectedItems.Count - 1) & " - " + strName

                Else
                    StatusStrip1.Text = i & " | " & (lvwArtikel_kategorien.SelectedItems.Count - 1) & " / Übersprungen!"
                End If

                ToolStripProgressBar1.Value = i
                msgMaster.Text = strName
                Application.DoEvents()

                strBeschreibung = lvwArtikel_kategorien.SelectedItems(i).SubItems(3).Text.Trim


                '##################################################################################
                '# >> Größere Übersetzung
                '##################################################################################
                If strBeschreibung.Length > 1200 Then
                    Dim bStop As Boolean = False
                    Dim strBeschreibung_tmp As String = ""
                    iLengthNext_tmp = 0
                    While bStop = False
                        strBeschreibung = lvwArtikel_kategorien.SelectedItems(i).SubItems(3).Text
                        'dblTranslationCount = Math.Round(strBeschreibung.Length / 1200)
                        ' 1203
                        If iLengthNext > strBeschreibung.Length Then
                            bStop = True
                            iLengthNext = strBeschreibung.Length
                        End If

                        iLengthNext = strBeschreibung.IndexOf(" ", iLengthNext)
                        If iLengthNext = -1 Then
                            iLengthNext = strBeschreibung.Length
                        End If

                        If iLengthNext_tmp > iLengthNext Then
                            Exit While
                        Else
                            strBeschreibung = strBeschreibung.Substring(iLengthNext_tmp, iLengthNext - iLengthNext_tmp)
                        End If


                        strBeschreibung = strBeschreibung.Replace("&nbsp;", " ").Replace("<P>", "").Replace("</P>", "").Replace("<BR>", "").Replace("&uuml;", "ü").Replace("&auml;", "ä").Replace("&ouml;", "ö").Replace("&Auml;", "Ä").Replace("&Ouml;", "Ö").Replace("&Uuml;", "Ü").Replace("&szlig;", "ß")
                        If My.Settings.cat_description_text = True Then
                            strKatText = strBeschreibung
                            strKat2Text = getHTTPResponseMessage("https://api.bludau-media.de//html2text.php?content=" & System.Uri.EscapeDataString(strKatText), mgetUpdaterMessage.getHTML2Text, True)

                            strBeschreibung = strKat2Text(0).Trim
                            'getTranslateText(strKat2Text(0).Trim, "de", strZielSpracheISO).Replace("&quot;", """").Trim()
                        End If

                        strBeschreibung = getTranslateText(strBeschreibung, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("</ p>", "</p>").Replace("</ span>", "</span>").Replace("<  / div>", "</div>").Replace("</ div>", "</div>").Replace("<  br />", "<br/>").Replace("</ font>", "</font>").Replace("</ strong>", "</strong>").Replace("</ div  >", "</div>").Replace("</  div>", "</div>")



                        iLengthNext_tmp += iLengthNext
                        iLengthNext += 1200
                        strBeschreibung_tmp &= strBeschreibung
                    End While
                    MessageBox.Show(strBeschreibung_tmp)
                    strBeschreibung = strBeschreibung_tmp
                Else
                    '##############################################################################
                    '# >> Einzel Übersetzung 
                    '##############################################################################
                    If strBeschreibung.Length > 0 Then


                        strBeschreibung = strBeschreibung.Replace("&nbsp;", " ").Replace("<P>", "").Replace("</P>", "").Replace("<BR>", "").Replace("&uuml;", "ü").Replace("&auml;", "ä").Replace("&ouml;", "ö").Replace("&Auml;", "Ä").Replace("&Ouml;", "Ö").Replace("&Uuml;", "Ü").Replace("&szlig;", "ß")

                        If My.Settings.cat_description_text = True Then
                            strKatText = strBeschreibung
                            strKat2Text = getHTTPResponseMessage("https://api.bludau-media.de//html2text.php?content=" & System.Uri.EscapeDataString(strKatText), mgetUpdaterMessage.getHTML2Text, True)

                            strBeschreibung = strKat2Text(0).Trim
                            'getTranslateText(strKat2Text(0).Trim, "de", strZielSpracheISO).Replace("&quot;", """").Trim()
                        End If
                        strBeschreibung = getTranslateText(strBeschreibung, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("</ p>", "</p>").Replace("</ span>", "</span>").Replace("<  / div>", "</div>").Replace("</ div>", "</div>").Replace("<  br />", "<br/>").Replace("</ font>", "</font>").Replace("</ strong>", "</strong>").Replace("</ div  >", "</div>").Replace("</  div>", "</div>")
                    End If

                End If

                If strBeschreibung.Length > 0 Or strName.Length > 0 Then
                    '# UPDATE oder INSERT
                    If clsDB.chkIsTranslatedKategorie(lvwArtikel_kategorien.SelectedItems(i).SubItems(0).Text) = True Then
                        '# UPDATE 
                        If clsDB.setUPDATE_Kategorie(lvwArtikel_kategorien.SelectedItems(i).SubItems(0).Text, strName.Trim, strBeschreibung.Replace("| - |", "|-|").Replace("&#39;", "''"), lvwArtikel_kategorien, i) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & lvwArtikel_kategorien.SelectedItems(i).SubItems(1).Text)
                            Exit For
                        End If

                    Else
                        '# INSERT
                        If clsDB.setINSERT_Kategorie(lvwArtikel_kategorien.SelectedItems(i).SubItems(0).Text, strName.Trim, strBeschreibung.Replace("| - |", "|-|").Replace("&#39;", "''"), lvwArtikel_kategorien, i) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & lvwArtikel_kategorien.SelectedItems(i).SubItems(1).Text)
                            Exit For
                        End If
                    End If
                Else
                    MessageBox.Show("Leere Übersetzung - Abbruch.")
                    Exit For
                End If


            Next
            btnÜbertrage.Enabled = True
            lvwMainData.Enabled = True
            lvwArtikel_kategorien.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim verarbeiten", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnÜbertrage.Enabled = True
            lvwMainData.Enabled = True
            lvwArtikel_kategorien.Enabled = True
            Return False
        End Try
    End Function

    '###################################################
    '# Kategorien übersetzen 
    '###################################################
    Public Function setTranslateKategorieALL() As Boolean
        Try
            Dim i As Integer = 0
            Dim strName As String = ""
            Dim strKurzbeschreibung As String = ""
            Dim strBeschreibung As String = ""
            Dim iLengthNext As Integer = 1200
            Dim iLengthNext_tmp As Integer = 0
            Dim dblTranslationCount As Double = 0
            Dim strZielSpracheISO As String = ""
            '# Alle selektierten 
            ToolStripProgressBar1.Value = 0
            ToolStripProgressBar1.Maximum = lvwArtikel_kategorien.Items.Count - 1
            ToolStripProgressBar1.Visible = True
            btnÜbertrage.Enabled = False
            lvwMainData.Enabled = False
            lvwArtikel_kategorien.Enabled = False
            Dim strKatText As String = ""
            Dim strKat2Text() As String
            strZielSpracheISO = clsDB.getGoogle2TranslationCode(cmbZielSpache.Text)
            For i = 0 To lvwArtikel_kategorien.Items.Count - 1

                iLengthNext = 0

                ' strName = getTranslateText(lvwArtikel_kategorien.Items(i).SubItems(1).Text, "de", strZielSpracheISO).Replace("&quot;", """").Trim

                If lvwArtikel_kategorien.Items(i).SubItems(1).Text.Trim.Length > 0 Then
                    StatusStrip1.Text = i & " | " & (lvwArtikel_kategorien.Items.Count - 1) & " - " + lvwArtikel_kategorien.Items(i).SubItems(1).Text
                    strName = getTranslateText(lvwArtikel_kategorien.Items(i).SubItems(1).Text.Trim, "de", strZielSpracheISO).Replace("&quot;", """").Trim

                    StatusStrip1.Text = i & " | " & (lvwArtikel_kategorien.Items.Count - 1) & " - " + strName

                Else
                    StatusStrip1.Text = i & " | " & (lvwArtikel_kategorien.Items.Count - 1) & " / Übersprungen!"
                End If

                ToolStripProgressBar1.Value = i
                msgMaster.Text = strName
                Application.DoEvents()

                strBeschreibung = lvwArtikel_kategorien.Items(i).SubItems(3).Text.Trim


                '##################################################################################
                '# >> Größere Übersetzung
                '##################################################################################
                If strBeschreibung.Length > 1200 Then
                    Dim bStop As Boolean = False
                    Dim strBeschreibung_tmp As String = ""
                    iLengthNext_tmp = 0
                    While bStop = False
                        strBeschreibung = lvwArtikel_kategorien.Items(i).SubItems(3).Text
                        'dblTranslationCount = Math.Round(strBeschreibung.Length / 1200)
                        ' 1203
                        If iLengthNext > strBeschreibung.Length Then
                            bStop = True
                            iLengthNext = strBeschreibung.Length
                        End If

                        iLengthNext = strBeschreibung.IndexOf(" ", iLengthNext)
                        If iLengthNext = -1 Then
                            iLengthNext = strBeschreibung.Length
                        End If

                        If iLengthNext_tmp > iLengthNext Then
                            Exit While
                        Else
                            strBeschreibung = strBeschreibung.Substring(iLengthNext_tmp, iLengthNext - iLengthNext_tmp)
                        End If


                        strBeschreibung = strBeschreibung.Replace("&nbsp;", " ").Replace("<P>", "").Replace("</P>", "").Replace("<BR>", "").Replace("&uuml;", "ü").Replace("&auml;", "ä").Replace("&ouml;", "ö").Replace("&Auml;", "Ä").Replace("&Ouml;", "Ö").Replace("&Uuml;", "Ü").Replace("&szlig;", "ß")
                        If My.Settings.cat_description_text = True Then
                            strKatText = strBeschreibung
                            strKat2Text = getHTTPResponseMessage("https://api.bludau-media.de//html2text.php?content=" & strKatText, mgetUpdaterMessage.getHTML2Text, True)
                            strBeschreibung = strKat2Text(0).Trim

                            ' strBeschreibung = getTranslateText(strKat2Text(0).Trim, "de", strZielSpracheISO).Replace("&quot;", """").Trim
                        End If
                        strBeschreibung = getTranslateText(strBeschreibung, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("</ p>", "</p>").Replace("</ span>", "</span>").Replace("<  / div>", "</div>").Replace("</ div>", "</div>").Replace("<  br />", "<br/>").Replace("</ font>", "</font>").Replace("</ strong>", "</strong>").Replace("</ div  >", "</div>").Replace("</  div>", "</div>")

                        msgMaster.Text = strBeschreibung


                        iLengthNext_tmp += iLengthNext
                        iLengthNext += 1200
                        strBeschreibung_tmp &= strBeschreibung
                    End While
                    'MessageBox.Show(strBeschreibung_tmp)
                    strBeschreibung = strBeschreibung_tmp
                Else
                    '##############################################################################
                    '# >> Einzel Übersetzung 
                    '##############################################################################
                    If strBeschreibung.Length > 0 Then


                        strBeschreibung = strBeschreibung.Replace("&nbsp;", " ").Replace("<P>", "").Replace("</P>", "").Replace("<BR>", "").Replace("&uuml;", "ü").Replace("&auml;", "ä").Replace("&ouml;", "ö").Replace("&Auml;", "Ä").Replace("&Ouml;", "Ö").Replace("&Uuml;", "Ü").Replace("&szlig;", "ß")
                        If My.Settings.cat_description_text = True Then
                            strKatText = strBeschreibung
                            strKat2Text = getHTTPResponseMessage("https://api.bludau-media.de//html2text.php?content=" & strKatText, mgetUpdaterMessage.getHTML2Text, True)
                            strBeschreibung = strKat2Text(0).Trim

                            ' strBeschreibung = getTranslateText(strKat2Text(0).Trim, "de", strZielSpracheISO).Replace("&quot;", """").Trim
                        End If
                        strBeschreibung = getTranslateText(strBeschreibung, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("</ p>", "</p>").Replace("</ span>", "</span>").Replace("<  / div>", "</div>").Replace("</ div>", "</div>").Replace("<  br />", "<br/>").Replace("</ font>", "</font>").Replace("</ strong>", "</strong>").Replace("</ div  >", "</div>").Replace("</  div>", "</div>")
                    End If

                End If

                If strBeschreibung.Length > 0 Or strName.Trim.Length > 0 Then
                    '# UPDATE oder INSERT
                    If clsDB.chkIsTranslatedKategorie(lvwArtikel_kategorien.Items(i).SubItems(0).Text) = True Then
                        '# UPDATE 
                        If clsDB.setUPDATE_Kategorie(lvwArtikel_kategorien.Items(i).SubItems(0).Text, strName, strBeschreibung.Replace("| - |", "|-|").Replace("&#39;", "''"), lvwArtikel_kategorien, i) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & lvwArtikel_kategorien.Items(i).SubItems(1).Text)
                            Exit For
                        End If

                    Else
                        '# INSERT
                        If clsDB.setINSERT_Kategorie(lvwArtikel_kategorien.Items(i).SubItems(0).Text, strName, strBeschreibung.Replace("| - |", "|-|").Replace("&#39;", "''"), lvwArtikel_kategorien, i) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & lvwArtikel_kategorien.Items(i).SubItems(1).Text)
                            Exit For
                        End If
                    End If
                Else
                    If MessageBox.Show("Es wurde eine leere Übersetzung empfangen" + vbCrLf + "Ja: Weitermachen" + vbCr + "Nein: Abbruch" + vbCrLf, "", MessageBoxButtons.YesNo) = DialogResult.No Then
                        Exit For
                    End If

                End If


            Next
            btnÜbertrage.Enabled = True
            lvwMainData.Enabled = True
            lvwArtikel_kategorien.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim verarbeiten", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub AlleKategorienÜbersetzenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AlleKategorienÜbersetzenToolStripMenuItem.Click
        Call setTranslateKategorieALL()
    End Sub

    Private Sub cmbZielSpache_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbZielSpache.SelectedIndexChanged


        Call clsDB.getGoogle2TranslationCode(cmbZielSpache.Text)
        Call clsDB.getLanguage2JTLSprachID(cmbZielSpache.Text)


        ToolStripStatusLabel1.Text = "JTL Sprachid: " + My.Settings.SpracheSelected(My.Settings.mandant_position)
    End Sub

    Private Sub chkTranslateMissing_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FehlendeSpracheigenschaftenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FehlendeSpracheigenschaftenToolStripMenuItem.Click
        Dim frmJTLSpracheReapir As New frmJTLSpracheigenschaften
        frmJTLSpracheReapir.Show()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()



        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub AttributeÜbersetzenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttributeÜbersetzenToolStripMenuItem.Click
        Dim frmEigenschaft As New frmMerkmaleübersetzen
        frmEigenschaft.Show(Me)
    End Sub

    Private Sub AlleJTLWawiArtikelLadenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlleJTLWawiArtikelLadenToolStripMenuItem.Click
        If AlleJTLWawiArtikelLadenToolStripMenuItem.Checked = True Then
            AlleJTLWawiArtikelLadenToolStripMenuItem.CheckState = CheckState.Unchecked
        Else
            AlleJTLWawiArtikelLadenToolStripMenuItem.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub chkAlleArtikelderJTLWaWi_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If ToolStripMenuItem3.Checked = True Then
            ToolStripMenuItem3.CheckState = CheckState.Unchecked
        Else
            ToolStripMenuItem3.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub LeereÜbersetzungenAnzeigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeereÜbersetzungenAnzeigenToolStripMenuItem.Click
        If LeereÜbersetzungenAnzeigenToolStripMenuItem.Checked = True Then
            LeereÜbersetzungenAnzeigenToolStripMenuItem.CheckState = CheckState.Unchecked
        Else
            LeereÜbersetzungenAnzeigenToolStripMenuItem.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        ' lvwArtikel_kategorien.BeginUpdate()

        'Call clsDB.getKategorie2(0, lvwArtikel_kategorien, 0, Me)
        Call clsDB.getKategorie2JTLShopOnly(0, lvwArtikel_kategorien, 0, Me)

        '  lvwArtikel_kategorien.EndUpdate()
    End Sub

    Private Sub ÜbersetzerEinstellungenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÜbersetzerEinstellungenToolStripMenuItem.Click
        Dim frmEinstellungen As New frmTranslateEinstellungen
        frmEinstellungen.Show(Me)
    End Sub



    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '# Privoxy und Tor beenden...
        If My.Settings.chkUseTorPrivoy = True Then
            Dim tor_pid As Integer = getProzessIDbySearch("tor")
            If Not tor_pid = -1 Then
                setKillbyPID(tor_pid)
            End If

            Dim privoxy_pid As Integer = getProzessIDbySearch("privoxy")
            If Not privoxy_pid = -1 Then
                setKillbyPID(privoxy_pid)
            End If

        End If
    End Sub

    Private Sub chkUseDateTimePicker_CheckedChanged(sender As Object, e As EventArgs)
        '   My.Settings.chkTranslate_normal_benutzeDatum = chkUseDateTimePicker.Checked
        My.Settings.Save()
    End Sub

    Private Sub JTLKategorienShopsteImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JTLKategorienShopsteImportToolStripMenuItem.Click
        clsDB.getJTL_Menue_tree_import_shopste(0, lvwArtikel_kategorien, 0, My.Settings.SHOPSTE_main_category)
    End Sub

    Private Sub ShopsteLoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopsteLoginToolStripMenuItem.Click
        Dim frmLogin As New LoginForm1
        frmLogin.ShowDialog()
    End Sub

    Public Function setTransferITems() As Boolean


        Dim strLokalFile As String
        Dim strLast As String
        Dim strImportError As String = ""
        Dim iCount As Integer = 0
        Dim strBeschreibung As String = ""

        If lvwArtikel_kategorien.SelectedItems(0).Text.Length = 0 Then
            MessageBox.Show("Bitte Kategorie im Menü auswählen")
        End If

        If lvwArtikel_kategorien.SelectedItems.Count = 0 Then
            MessageBox.Show("Bitte Artikel auswählen um diese nach Shopste.com zu übertragen STRG + Artikelklick oder STRG + A", "Artikelauswahl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If




        For iCount = 0 To lvwArtikel_kategorien.SelectedItems.Count - 1

            getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=get_shopste_kategorie_by_jtlcatid&jtl_cat_id=" & lvwArtikel_kategorien.SelectedItems(0).SubItems(0).Text & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD, mgetUpdaterMessage.getEiSo2ShopsteKat, False)

            Dim strTeiler() As String = strHTTPDataStore.Split("~")

            If Not IsNumeric(strTeiler(0)) = True Then
                MessageBox.Show("Es wurde keine gültige Shopste.com Kategorie gefunden.", "ungültige Kategorie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Continue For
            End If

            ' lvwMainData.Items(iCount).Selected = True
            ' Application.DoEvents()

            Dim Request As HttpWebRequest = CType(WebRequest.Create(My.Settings.SHOPSTE_API_URL), HttpWebRequest)
            Request.Method = "POST"
            Request.ContentType = "application/x-www-form-urlencoded"

            msgMaster.Text = iCount & " | " & lvwMainData.SelectedItems.Count - 1 & " - Bereite einfügen vor..."

            Application.DoEvents()
            'MessageBox.Show(System.Net.WebUtility.HtmlEncode(ListView1.SelectedItems(0).SubItems(0).Text))
            'System.Net.WebUtility.HtmlEncode
            ' Dim strBeschreibung As String
            ' If chkImportKeineHTMLBeschreibung.Checked = False Then
            strBeschreibung = System.Uri.EscapeDataString(lvwMainData.SelectedItems(iCount).SubItems(1).Text)
            ' Else
            ' strBeschreibung = HttpUtility.UrlEncode(lvwMainData.SelectedItems(0).SubItems(0).Text)
            ' End If

            '# Letztes zu importierendes Produkt?
            If iCount = lvwMainData.SelectedItems.Count - 1 Then
                strLast = "true"
            Else
                strLast = "false"
            End If


            Dim Post As String = "modus=system_shop_item_add&domain_id=" & My.Settings.SHOPSTE_domain_id & "&shop_item_beschreibung=" & strBeschreibung & "&shop_item_menge=" & lvwMainData.SelectedItems(iCount).SubItems(10).Text & "&shop_item_price=" & lvwMainData.SelectedItems(iCount).SubItems(9).Text.Replace(",", ".") & "&shop_item_name=" & System.Uri.EscapeDataString(lvwMainData.SelectedItems(iCount).SubItems(1).Text) & "&shop_item_duration=15&shop_item_mwst=19&shop_item_artikelnummer=" & lvwMainData.SelectedItems(iCount).SubItems(0).Text & "&bLastItem=" & strLast & "&user=" & My.Settings.SHOPSTE_USERNAME & "&subshop_cat=" & strTeiler(0) & "&shopste_cat=" & strTeiler(1) & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD

            ' Clipboard.SetText(WebUtility.HtmlEncode(ListView1.SelectedItems(0).SubItems(5).Text))

            'Dim postQuery As Byte() = System.Text.Encoding.ASCII.GetBytes("Post 

            Dim byteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(Post)
            Request.ContentLength = byteArray.Length
            Dim DataStream As System.IO.Stream = Request.GetRequestStream()
            DataStream.Write(byteArray, 0, byteArray.Length)
            DataStream.Close()
            Dim Response As HttpWebResponse = Request.GetResponse()
            DataStream = Response.GetResponseStream()
            Dim reader As New System.IO.StreamReader(DataStream)
            Dim ServerResponse As String = reader.ReadToEnd()
            reader.Close()
            DataStream.Close()
            Response.Close()

            If InStr(ServerResponse, "shopid") Then
                Dim str() As String = ServerResponse.Split(":")
                Dim shopid_picture As String = str(1)

                msgMaster.Text = iCount & " | " & lvwMainData.SelectedItems.Count - 1 & " - Shop ID:" & shopid_picture

                Dim strFileName() As String = lvwMainData.SelectedItems(iCount).SubItems(3).Text.Split("/")

                Dim nvc As New Specialized.NameValueCollection
                nvc.Add("modus", "system_upload_file")
                nvc.Add("domain_id", My.Settings.SHOPSTE_domain_id)
                nvc.Add("benutzername", My.Settings.SHOPSTE_USERNAME)
                nvc.Add("passwort", My.Settings.SHOPSTE_PASSWORD)
                nvc.Add("domain_pfad", My.Settings.SHOPSTE_domainname)
                nvc.Add("shop_id", shopid_picture)
                ' nvc.Add("picture_name", lvwMainData.Items(iCount).SubItems(3).Text.Replace(" ", "_").Replace(">", "-").Replace("/", "").Replace("\", "").Replace("!", ""))
                Dim strBildName As String = lvwMainData.SelectedItems(iCount).SubItems(1).Text.Replace(" ", "_").Replace(">", "-").Replace("/", "").Replace("\", "").Replace("!", "").Replace("*", "").Replace("<", "-") & ".jpg"
                nvc.Add("picture_name", strBildName)

                '# Externe Bilder - HTTP Link
                If Not lvwMainData.SelectedItems(iCount).SubItems(3).Text.LastIndexOf("http://") = -1 Then

                    Dim client As New WebClient()

                    Dim strBild As String
                    Dim strBild_ary() As String
                    Dim strBildFixed As String = strFileName(strFileName.Length - 1).Replace("\", "-").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("""", "").Replace("<", "").Replace(">", "").Replace("|", "")
                    'MessageBox.Show(Application.StartupPath)
                    ' Dim strPath As String = IO.Path.GetDirectoryName(Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
                    ' MessageBox.Show(Application.StartupPath)
                    If My.Settings.SHOPSTE_domain_id = 43 Then
                        strBild_ary = strBildName.Split("/")
                        If strBild_ary.Length = 1 Then
                            strBild = "https://philafriend.de/eBay/TN_" & strBildFixed
                        Else
                            strBild = strBild.Replace(strBild_ary(strBild_ary.Length - 1), "TN_" + strBild_ary(strBild_ary.Length - 1))
                            strBild = "https://philafriend.de/eBay/TN_" & strBild_ary(strBild_ary.Length - 1)
                            strBild = lvwMainData.SelectedItems(iCount).SubItems(3).Text.Replace("http://", "https://")
                            strBild_ary = strBild.Split("/")
                            strBild = strBild.Replace(strBild_ary(strBild_ary.Length - 1), "TN_" + strBild_ary(strBild_ary.Length - 1))

                        End If

                    Else
                        strBild = lvwMainData.SelectedItems(iCount).SubItems(3).Text
                    End If

                    Try

                        If strBildFixed.Length > 240 Then
                            strBildFixed = strBildFixed.Substring(0, 240)
                        End If
                        client.DownloadFile(strBild, Application.StartupPath & "\bilderexport\" & strBildFixed)
                        strLokalFile = Application.StartupPath & "\bilderexport\" & strBildFixed
                    Catch ex As Exception
                        strLokalFile = "error"
                        strImportError &= lvwMainData.SelectedItems(iCount).SubItems(3).Text & vbCrLf
                    End Try


                Else
                    strLokalFile = ""
                End If

                'HttpUploadFile("http://shopste.com/api.php", "C:\Users\jbludau\Desktop\gelb_katze.jpg", "system_upload", "image/jpeg", nvc)
                'MessageBox.Show(ListView1.Items(icount).SubItems(3).Text)
                'lvwMainData.Items(iCount).Selected = True
                msgMaster.Text = iCount & " | " & lvwMainData.SelectedItems.Count - 1 & " - Lade Bild hoch..."

                If strLokalFile = "" Then
                    strLokalFile = lvwMainData.SelectedItems(iCount).SubItems(3).Text
                End If

                '# Kein Fehler beim Verarbeiten
                If Not strLokalFile = "error" Then
                    HttpUploadFile(My.Settings.SHOPSTE_API_URL, strLokalFile, "system_upload", "image/jpeg", nvc)
                End If

                My.Settings.Save()


            Else
                If MessageBox.Show("Artikel '" & lvwMainData.SelectedItems(0).SubItems(0).Text & "' nicht korrekt eingestellt." + vbCrLf + "Wird Artikel wird fehlen, führe fort...?", "API Import", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.No Then
                    Exit For
                End If
            End If
            lvwMainData.EnsureVisible(iCount)
            Application.DoEvents()


        Next

        msgMaster.Text = "Alle Aufgaben abgeschlossen"

        If (strImportError.Length > 0) Then
            MessageBox.Show("Es sind Fehler aufgetreten bei:" & vbCrLf & vbCrLf & strImportError)
        Else
            MessageBox.Show("Alle Produkte wurden importiert", "Import fertig", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        clsDB.getJTL_Menue_tree_import_shopste(0, lvwArtikel_kategorien, 0, My.Settings.SHOPSTE_main_category)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        lvwArtikel_kategorien.Items.Clear()
        Timer1.Start()
    End Sub

    Private Sub ShopsteKategorieZuordnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopsteKategorieZuordnenToolStripMenuItem.Click
        Dim frmShopsteCategorien As New frmShopsteCategory
        frmShopsteCategorien.strKategorieJTLShop = lvwArtikel_kategorien.SelectedItems(0).SubItems(0).Text
        frmShopsteCategorien.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frmShopsteCategorien As New frmShopsteCategory
        frmShopsteCategorien.Show()
    End Sub

    Private Sub cmbJTLShops_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJTLShops.SelectedIndexChanged
        My.Settings.JTLSHOP(My.Settings.mandant_position) = clsDB.getJTLShop(cmbJTLShops.Text)
        ToolStripStatusLabel1.Text = "JTL SHOP: " + My.Settings.JTLSHOP(My.Settings.mandant_position)

    End Sub

    Private Sub lvwMainData_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvwMainData.ColumnClick

        Try
            Call setSort(lvwMainData, e)
            'Call setStatusMessage(lvweBayLiveList)
        Catch ex As Exception

        End Try
    End Sub
End Class
