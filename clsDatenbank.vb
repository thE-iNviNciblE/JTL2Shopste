Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net

Public Class clsDatenbank
    Public strConnectionString As String
    Public strConnectionString_eazybusiness As String = ""
    Public dblQuellspracheZeichen As Double = 0

    '##########################################################
    '# >> Existiert der Mandant welcher eingelesen wird
    '##########################################################
    Public Function chkMandantExists(strMandant_db As String) As Boolean
        Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
        Try
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("USE " & strMandant_db, sqlConn)
            sqlComm.ExecuteNonQuery()
            sqlConn.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function getAufpreis(ArtikelID As String) As Boolean
        Application.DoEvents()
        Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
        sqlConn.Open()
        Dim strQuery3 As String = "SELECT * FROM teigenschaft   LEFT JOIN teigenschaftwert ON teigenschaftwert.kEigenschaft = teigenschaft.kArtikel WHERE teigenschaft.kArtikel='" & ArtikelID & "'"
        '" & 
        Dim sqlComm2 As New SqlCommand(strQuery3, sqlConn)
        Dim r2 As SqlDataReader = sqlComm2.ExecuteReader()
        Dim bIn As Boolean = False
        While r2.Read()

            If r2("fAufpreisNetto") > 0.00000000000000 Then
                bIn = True
            End If
        End While
        Return bIn

    End Function
    '##########################################################
    '# >> Artikel aus Kategorie laden
    '##########################################################
    Public Function getKategorie2Artikel(ByVal iCatID As Integer, ByRef lvwArtikel As ListView, ByRef lvwKategorie As ListView) As Boolean
        Try

            SqlConnection.ClearAllPools()
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            lvwArtikel.Items.Clear()
            lvwArtikel.BeginUpdate()

            '####################################
            '# Anzahl der Kategorie bestimmen
            '####################################


            Dim strQuery2 As String = "SELECT tArtikelBeschreibung.kArtikel as sArtikelID,tArtikelBeschreibung.*, tartikel.kArtikel as bkArtikel, tartikel.fVKNetto, tartikel.cArtNr as bArtNr ,tlagerbestand.fVerfuegbar,tartikel.cArtNr,tSteuersatz.fSteuersatz,tArtikel.fGewicht FROM tArtikelShop LEFT JOIN tartikel ON tartikel.kArtikel = tArtikelShop.kArtikel LEFT JOIN tArtikelBeschreibung ON tArtikelBeschreibung.kArtikel = tartikel.kArtikel  JOIN tlagerbestand ON tlagerbestand.kArtikel = tartikel.kArtikel  JOIN tkategorieartikel ON tkategorieartikel.kArtikel = tartikel.kArtikel JOIN tSteuerklasse  ON tArtikel.kSteuerklasse = tSteuerklasse.kSteuerklasse JOIN tSteuersatz on tSteuersatz.kSteuerklasse =  tSteuerklasse.kSteuerklasse  WHERE tkategorieartikel.kKategorie='" & iCatID & "' AND tArtikelBeschreibung.kSprache=1 AND tSteuersatz.kSteuerzone = 1 AND tArtikelShop.kShop='" & My.Settings.JTLSHOP(My.Settings.mandant_position) & "' AND tartikel.kEigenschaftKombi=0"
            '" & My.Settings.SpracheSelected(My.Settings.mandant_position)
            Dim sqlComm As New SqlCommand(strQuery2, sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()

                Dim lvwItem As New ListViewItem

                SqlConnection.ClearAllPools()
                Dim sqlConn2 As New SqlConnection(strConnectionString)
                sqlConn2.Open()

                '####################################
                '# Anzahl der Kategorie bestimmen
                '####################################

                Application.DoEvents()

                Dim strQuery3 As String = "SELECT tArtikelBeschreibung.kArtikel as sArtikelID,tArtikelBeschreibung.*, tartikel.kArtikel as bkArtikel, tartikel.fVKNetto, tartikel.cArtNr as bArtNr ,tlagerbestand.fVerfuegbar,tartikel.cArtNr,tSteuersatz.fSteuersatz,tArtikel.fGewicht FROM tartikel LEFT JOIN tArtikelBeschreibung ON tArtikelBeschreibung.kArtikel = tartikel.kArtikel  JOIN tlagerbestand ON tlagerbestand.kArtikel = tartikel.kArtikel  JOIN tkategorieartikel ON tkategorieartikel.kArtikel = tartikel.kArtikel JOIN tSteuerklasse  ON tArtikel.kSteuerklasse = tSteuerklasse.kSteuerklasse JOIN tSteuersatz on tSteuersatz.kSteuerklasse =  tSteuerklasse.kSteuerklasse  WHERE tartikel.kArtikel='" & r("bkArtikel").ToString & "' AND tArtikelBeschreibung.kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)
                '" & 
                Dim sqlComm2 As New SqlCommand(strQuery3, sqlConn2)
                Dim r2 As SqlDataReader = sqlComm2.ExecuteReader()
                r2.Read()

                'lvwItem.Text = "---"  ' Bild
                lvwItem.UseItemStyleForSubItems = False

                lvwItem.Text = r("bArtNr").ToString  ' Artikelnummer
                lvwItem.SubItems.Add(r("cName").ToString) ' DE Name

                Try
                    lvwItem.SubItems.Add(r2("cName").ToString)  ' Name           
                    frmMain.msgMaster.Text = r2("cName").ToString
                    Application.DoEvents()

                Catch ex As Exception
                    lvwItem.SubItems.Add("")  ' Name           
                End Try


                lvwItem.SubItems.Add(r("cKurzBeschreibung").ToString) ' Kurzbeschreibung
                lvwItem.SubItems.Add(r("cBeschreibung").ToString) ' Beschreibung

                Try
                    lvwItem.SubItems.Add(r2("cKurzBeschreibung").ToString) ' Beschreibung 
                Catch ex As Exception
                    lvwItem.SubItems.Add("")  ' Beschreibung
                End Try

                Try
                    lvwItem.SubItems.Add(r2("cBeschreibung").ToString) ' Kurzbeschreibung
                Catch ex As Exception
                    lvwItem.SubItems.Add("")  ' Kurzbeschreibung
                End Try

                lvwItem.SubItems.Add(r("bkArtikel").ToString) ' Artikel ID
                lvwItem.SubItems.Add(jtlwawi_artikel_hasEigenschaft(r("bkArtikel").ToString)) ' Hat Eigenschaften
                lvwItem.SubItems.Add(Convert.ToDecimal(r("fVKNetto").ToString) * ((Convert.ToDouble(r("fSteuersatz").ToString) / 100) + 1)) ' Preis fVKNetto
                lvwItem.SubItems.Add(r("fVerfuegbar").ToString) ' Menge
                lvwItem.SubItems.Add(getBigPicturefromJTLShop(r("bkArtikel").ToString)) ' Bild
                lvwItem.SubItems.Add(getArtikel2Kategorie(r("bkArtikel").ToString)) ' Kategorien

                lvwItem.SubItems.Add(r("cArtNr").ToString) ' Artikelnummer
                lvwItem.SubItems.Add((Convert.ToDouble(r("fSteuersatz").ToString) / 100) + 1) ' Artikel - MwSt
                lvwItem.SubItems.Add(r("fGewicht").ToString) ' Artikel-Gewicht
                lvwItem.SubItems.Add(lvwKategorie.SelectedItems(0).SubItems(5).Text) ' Shopste Marktplatz ID
                lvwItem.SubItems.Add(getAufpreis(r("bkArtikel").ToString)) ' Aufpreis
                lvwArtikel.Items.Add(lvwItem)
                sqlConn2.Close()
            End While

            sqlConn.Close()
            lvwArtikel.EndUpdate()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen getKategorie2Artikel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function getBigPicturefromJTLShop(kArtikel As String) As String
        Dim strData As String = ""


        ' Create a request for the URL.   
        Dim request As WebRequest =
              WebRequest.Create(My.Settings.JTLSHOP_HTTP(My.Settings.mandant_position) & "/JTLShopConnector?modus=PathByKArtikelJTL2Shopste&kArtikel=" + kArtikel)
        ' If required by the server, set the credentials.  
        request.Credentials = CredentialCache.DefaultCredentials
        ' Get the response.  
        Dim response As WebResponse = Request.GetResponse()
        ' Display the status.  
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.  
        Dim dataStream As Stream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.  
        Dim reader As New StreamReader(dataStream)
        ' Read the content.  
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.  
        Console.WriteLine(responseFromServer)
        ' Clean up the streams and the response.  
        reader.Close()
        response.Close()



        'https://www.maiwell.com/JTLShopConnector?modus=PathByKArtikelJTL2Shopste&kArtikel=999
        Return responseFromServer
    End Function
    Public Function getArtikel2Kategorie(kArtikel As Integer) As String
        Dim sqlConn As New SqlConnection(strConnectionString)
        sqlConn.Open()

        Dim sqlComm As New SqlCommand("SELECT * FROM tkategorieartikel  WHERE kArtikel='" & kArtikel & "'", sqlConn)
        Dim r As SqlDataReader = sqlComm.ExecuteReader()

        Dim strMenue As String
        While r.Read()
            strMenue &= r("kKategorie").ToString & ","
        End While
        Return strMenue
    End Function
    '####################################################################
    '# >> setInstallUpdateAllMandant
    '# Installieren des Updates für alle Mandanten
    '####################################################################
    Public Function setInstallUpdateAllMandant(strFileName As String, cmbMandanten As ComboBox) As Boolean
        Dim strMandant_db As String = ""
        Try
            If IO.File.Exists(strFileName) = True Then
                For i As Integer = 0 To cmbMandanten.Items.Count - 1
                    strMandant_db = getMandantDatabaseByMandantName(cmbMandanten.Items(i))
                    If setInstallUpdateByDatabase(strFileName, strMandant_db) = True Then
                        My.Settings.first_start = False
                        My.Settings.Save()
                    Else
                        MessageBox.Show("Datenbanktabelle cubss_translator konnte nicht angelegt werden", "Datenbank: Installation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next

                Dim strFileNameNew() As String = strFileName.Split("\")
                Dim strFileNameNew_complete As String = Application.StartupPath & "\SQL\" & strFileNameNew(strFileNameNew.Length - 1).Replace(".", " " & Date.Now.Year & "-" & Date.Now.Month & "-" & Date.Now.Day & " " & Date.Now.Hour & "-" & Date.Now.Minute & "-" & Date.Now.Second & ".")
                IO.File.Move(strFileName, strFileNameNew_complete)
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler bei setInstallUpdateAllMandant: " & ex.Message, "setInstallUpdateAllMandant()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    '####################################################################
    '# >> setInstallUpdateByDatabase
    '# Neue Tabellen installieren, z.B. wenn neuer Mandant angelegt 
    '# wird in den Datenbankeinstellungen
    '####################################################################
    Public Function setInstallUpdateByDatabase(strFileName As String, strMandant_db As String) As Boolean

        Dim strContent As String = My.Computer.FileSystem.ReadAllText(strFileName)
        Dim strContent_split() As String = strContent.Split(vbCrLf)
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            For i As Integer = 0 To strContent_split.Length - 1
                Try
                    Dim strQuery As String = ""
                    strQuery = "USE " & strMandant_db & vbCrLf & strContent_split(i)
                    Dim sqlComm As New SqlCommand(strQuery, sqlConn)
                    sqlComm.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox.Show("Zeile: " & i & " " & ex.Message, "SQL Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Next

            sqlConn.Close()
            Return True
        Catch ex As Exception
            '# 0: In der Datenbank ist bereits ein Objekt mit dem Namen 'illixi_newsletter' vorhanden.

            MessageBox.Show(ex.Message, "Fehler beim Hinzufügen der neuen Datenbank Tabelle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    Public Function getJTLShop(strShopName As String) As String
        SqlConnection.ClearAllPools()
        Dim sqlConn As New SqlConnection(strConnectionString)
        sqlConn.Open()

        Dim sqlComm As New SqlCommand("SELECT * FROM tShop WHERE cName='" & strShopName & "'", sqlConn)
        Dim r As SqlDataReader = sqlComm.ExecuteReader()

        While r.Read()
            My.Settings.JTLSHOP_HTTP(My.Settings.mandant_position) = r("cServerWeb").ToString
            My.Settings.Save()
            Return r("kShop").ToString
        End While


    End Function
    '##########################################################
    '# >> Kategorie abrufen
    '##########################################################
    Public Function getKategorie2(ByVal iCatID As Integer, ByVal lvwKategorie As ListView, Optional ByVal iSubLevel As Integer = -1, ByRef Optional frm As frmMain = Nothing) As Boolean
        Try
            Dim strAbstand As String = ""
            SqlConnection.ClearAllPools()
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim sqlComm As New SqlCommand("SELECT * FROM tkategorie LEFT JOIN tKategorieSprache ON tKategorieSprache.kKategorie = tkategorie.kKategorie LEFT JOIN jbm_jtlcat2shopstemarketcat ON jbm_jtlcat2shopstemarketcat.jtl_shopcat = tkategorie.kKategorie WHERE kOberKategorie='" & iCatID & "' AND kSprache='1'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            '# Abstand berechnen 
            If iSubLevel > 0 Then
                For iCount As Integer = 0 To iSubLevel
                    strAbstand &= "  "
                Next
            End If

            While r.Read()

                SqlConnection.ClearAllPools()
                'Dim sqlConn_sprache As New SqlConnection(strConnectionString)
                'sqlConn_sprache.Open()

                'Dim sqlComm_sprache As New SqlCommand("SELECT * FROM tKategorieSprache WHERE kKategorie='" & r("kKategorie").ToString & "' AND kSprache='1' ORDER BY cName ASC", sqlConn_sprache)
                'Dim r_sprache As SqlDataReader = sqlComm_sprache.ExecuteReader()

                'While r_sprache.Read()

                Dim lvwItem As New ListViewItem
                lvwItem.Text = r("kKategorie").ToString
                lvwItem.SubItems.Add(strAbstand & r("cName").ToString)

                If frm IsNot Nothing Then
                    frm.msgMaster.Text = r("cName").ToString
                End If


                Application.DoEvents()

                lvwItem.SubItems.Add("")
                lvwItem.SubItems.Add(strAbstand & r("cBeschreibung").ToString)
                lvwItem.SubItems.Add("")
                lvwItem.SubItems.Add(r("jtl_shopste_cat").ToString)

                lvwKategorie.Items.Add(lvwItem)

                '# Alle Unterkategorien anzeigen 
                If iSubLevel >= 0 Then
                    Call getKategorie2(r("kKategorie").ToString, lvwKategorie, iSubLevel + 1, frm) ' Rekursion starten 
                End If

                'End While


            End While
            sqlConn.Close()


            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function getJTLShops(ByRef cmbShops As ComboBox) As Integer
        SqlConnection.ClearAllPools()
        Dim sqlConn As New SqlConnection(strConnectionString)
        sqlConn.Open()

        Dim sqlComm As New SqlCommand("SELECT * FROM tShop", sqlConn)
        Dim r As SqlDataReader = sqlComm.ExecuteReader()

        While r.Read()
            cmbShops.Items.Add(r("cName").ToString)
        End While

        If Not cmbShops.Items.Count = 0 Then
            cmbShops.SelectedIndex = 0
        End If

    End Function
    '##########################################################
    '# >> Kategorie abrufen
    '##########################################################
    Public Function getKategorie2JTLShopOnly(ByVal iCatID As Integer, ByVal lvwKategorie As ListView, Optional ByVal iSubLevel As Integer = -1, ByRef Optional frm As frmMain = Nothing) As Boolean
        Try
            Dim strAbstand As String = ""
            SqlConnection.ClearAllPools()
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim sqlComm As New SqlCommand("SELECT * FROM tKategorieShop LEFT JOIN tkategorie ON tKategorieShop.kKategorie = tkategorie.kKategorie LEFT JOIN tKategorieSprache ON tKategorieSprache.kKategorie = tkategorie.kKategorie LEFT JOIN jbm_jtlcat2shopstemarketcat ON jbm_jtlcat2shopstemarketcat.jtl_shopcat = tkategorie.kKategorie WHERE kOberKategorie='" & iCatID & "' AND kSprache='1' AND tKategorieShop.kShop='" & My.Settings.JTLSHOP(My.Settings.mandant_position) & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            '# Abstand berechnen 
            If iSubLevel > 0 Then
                For iCount As Integer = 0 To iSubLevel
                    strAbstand &= "  "
                Next
            End If

            While r.Read()

                SqlConnection.ClearAllPools()
                'Dim sqlConn_sprache As New SqlConnection(strConnectionString)
                'sqlConn_sprache.Open()

                'Dim sqlComm_sprache As New SqlCommand("SELECT * FROM tKategorieSprache WHERE kKategorie='" & r("kKategorie").ToString & "' AND kSprache='1' ORDER BY cName ASC", sqlConn_sprache)
                'Dim r_sprache As SqlDataReader = sqlComm_sprache.ExecuteReader()

                'While r_sprache.Read()

                Dim lvwItem As New ListViewItem
                lvwItem.Text = r("kKategorie").ToString
                lvwItem.SubItems.Add(strAbstand & r("cName").ToString)

                If frm IsNot Nothing Then
                    frm.msgMaster.Text = r("cName").ToString
                End If


                Application.DoEvents()

                lvwItem.SubItems.Add("")
                lvwItem.SubItems.Add(strAbstand & r("cBeschreibung").ToString)
                lvwItem.SubItems.Add("")
                lvwItem.SubItems.Add(r("jtl_shopste_cat").ToString)

                lvwKategorie.Items.Add(lvwItem)

                '# Alle Unterkategorien anzeigen 
                If iSubLevel >= 0 Then
                    Call getKategorie2JTLShopOnly(r("kKategorie").ToString, lvwKategorie, iSubLevel + 1, frm) ' Rekursion starten 
                End If

                'End While


            End While
            sqlConn.Close()


            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '##########################################################
    '# >> Kategorie abrufen
    '##########################################################
    Public Function getKategorie(ByVal iCatID As Integer, ByVal lvwKategorie As ListView, Optional ByVal iSubLevel As Integer = -1, ByRef Optional frm As frmMain = Nothing) As Boolean
        Try
            Dim strAbstand As String = ""
            SqlConnection.ClearAllPools()
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            Dim sqlComm As New SqlCommand("SELECT * FROM tkategorie WHERE kOberKategorie='" & iCatID & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            '# Abstand berechnen 
            If iSubLevel > 0 Then
                For iCount As Integer = 0 To iSubLevel
                    strAbstand &= "  "
                Next
            End If

            While r.Read()

                SqlConnection.ClearAllPools()
                Dim sqlConn_sprache As New SqlConnection(strConnectionString)
                sqlConn_sprache.Open()

                Dim sqlComm_sprache As New SqlCommand("SELECT * FROM tKategorieSprache WHERE kKategorie='" & r("kKategorie").ToString & "' AND kSprache='1' ORDER BY cName ASC", sqlConn_sprache)
                Dim r_sprache As SqlDataReader = sqlComm_sprache.ExecuteReader()

                While r_sprache.Read()

                    Dim lvwItem As New ListViewItem
                    lvwItem.Text = r_sprache("kKategorie").ToString
                    lvwItem.SubItems.Add(strAbstand & r_sprache("cName").ToString)

                    If frm IsNot Nothing Then
                        frm.msgMaster.Text = r_sprache("cName").ToString
                    End If


                    Application.DoEvents()

                    lvwItem.SubItems.Add("")
                    lvwItem.SubItems.Add(strAbstand & r_sprache("cBeschreibung").ToString)
                    lvwKategorie.Items.Add(lvwItem)

                    '# Alle Unterkategorien anzeigen 
                    If iSubLevel >= 0 Then
                        Call getKategorie(r_sprache("kKategorie").ToString, lvwKategorie, iSubLevel + 1, frm) ' Rekursion starten 
                    End If

                End While


            End While
            sqlConn.Close()


            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '##########################################################
    '# >> Kategorie Oberkategorie abrufen
    '##########################################################
    Public Function getKategorieOberKategorie(ByVal iCatID As Integer, ByVal iPos As Integer, Optional ByVal bSubCategoriy As Boolean = False) As String()
        Try
            Dim iInternPos As Integer = 0
            Dim strOutput(1) As String
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT * FROM tkategorie WHERE kOberKategorie='" & iCatID & "' ORDER BY nSort ASC, cName ASC ", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()

                If iPos = iInternPos Then
                    strOutput(0) = r("cName").ToString
                    strOutput(1) = r("kKategorie").ToString
                    sqlConn.Close()
                    Return strOutput
                    Exit Function
                End If
                iInternPos += 1
            End While

            sqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    '##########################################################
    '# >> setMandantbyCombobox
    '# Mandanten in Combobox einlesen
    '##########################################################
    Public Function setMandantbyCombobox(ByVal cmbMandant As ComboBox, ByVal bAllDBs As Boolean) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
            sqlConn.Open()

            '# Combobox löschen 
            cmbMandant.Items.Clear()
            Dim sqlComm As New SqlCommand("SELECT * FROM tMandant ORDER BY cNAME ASC", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                '# Prüfen ob Datenbank überhaupt angelegt ist 
                If chkMandantExists(r("cDB").ToString) = True Then
                    Dim lvwItem As New ListViewItem

                    '# Nur Verfügbare Datenbanken eintragen, wenn Setting gefunden wurde und bAllDbs nicht True ist 
                    If bAllDBs = True Then
                        cmbMandant.Items.Add(r("cName").ToString)
                    Else
                        If frmMain.getMySettingsPositionByDatabase(r("cDB").ToString) >= 0 Then
                            cmbMandant.Items.Add(r("cName").ToString)
                        End If
                    End If

                End If
            End While

            If cmbMandant.Items.Count > 0 Then
                If cmbMandant.Items.Count - 1 > 0 Then
                    For i As Byte = 0 To cmbMandant.Items.Count - 1
                        If My.Settings.mandant_letzter_name = cmbMandant.Items(i) Then
                            cmbMandant.SelectedIndex = i
                            My.Settings.mandant_letzter_name = cmbMandant.Text
                            Exit For
                        End If
                    Next
                Else
                    cmbMandant.SelectedIndex = 0
                    My.Settings.mandant_letzter_name = cmbMandant.Text
                End If

            End If
            My.Settings.Save()
            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim JTL Mandant abrufen getMandant()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '##########################################################
    '# >> getMandantbyName
    '# Mandant DB Name einlesen
    '# Returns DB-Name
    '##########################################################
    Public Function getMandantDatabaseByMandantName(strMandantName As String) As String
        Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
        Try

            Dim strDBName As String = ""

            sqlConn.Open()
            '# Datenbank einlesen 
            Dim sqlComm As New SqlCommand("SELECT * FROM tMandant WHERE cName='" & strMandantName & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                Dim lvwItem As New ListViewItem
                strDBName = r("cDB").ToString
            End While

            sqlConn.Close()
            Return strDBName
        Catch ex As Exception
            MessageBox.Show(ex.Message, "getMandantbyName()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '0 = ID
    '1 = Menge
    '2 = Name
    '3 = Artikelnummer
    Public Function getSYNC_status(strData() As String) As String

        Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
        sqlConn.Open()
        Dim strQuery = "SELECT count(*) as anzahl FROM tArtikel LEFT JOIN tlagerbestand ON tlagerbestand.kArtikel = tArtikel.kArtikel WHERE cArtNr='" & strData(3) & "' AND tlagerbestand.fVerfuegbar = '" & strData(1) & ".00000000000000'"
        '# Datenbank einlesen 
        Dim sqlComm As New SqlCommand(strQuery, sqlConn)
        Dim r As SqlDataReader = sqlComm.ExecuteReader()

        While r.Read()
            If r("anzahl").ToString = "0" Then
                Dim sqlConn2 As New SqlConnection(strConnectionString_eazybusiness)
                sqlConn2.Open()

                '# Datenbank einlesen 
                Dim sqlComm2 As New SqlCommand("SELECT * FROM tArtikel LEFT JOIN tlagerbestand ON tlagerbestand.kArtikel = tArtikel.kArtikel JOIN tSteuerklasse  ON tArtikel.kSteuerklasse = tSteuerklasse.kSteuerklasse JOIN tSteuersatz on tSteuersatz.kSteuerklasse =  tSteuerklasse.kSteuerklasse   WHERE cArtNr='" & strData(3) & "' AND tlagerbestand.fVerfuegbar = '" & strData(1) & "'", sqlConn2)
                Dim r2 As SqlDataReader = sqlComm2.ExecuteReader()
                r2.Read()

                Dim preis As Double = (Convert.ToDouble(r2("fVKNetto").ToString) * ((Convert.ToDouble(r2("fSteuersatz").ToString) / 100) + 1))
                ' MessageBox.Show(r2("cArtNr").ToString)
                Dim msg() As String = getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=getSyncStatus_save&menge=" & r2("fVerfuegbar").ToString & "&price=" & preis & "&item_number=" & r2("cArtNr").ToString & "&domain_id=" & My.Settings.SHOPSTE_domain_id, mgetUpdaterMessage.getShopsteArtikel_save, True)

                Console.WriteLine(msg(0))

            Else

            End If
        End While

        sqlConn.Close()
    End Function

    '##########################################################
    '# >> getMandantbyDBName
    '# Mandant DB Name einlesen
    '# Returns Profil-Name
    '##########################################################
    Public Function getMandantbyDBName(strMandantDB As String) As String
        Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
        Try

            Dim strMandantName As String = ""

            sqlConn.Open()
            '# Datenbank einlesen 
            Dim sqlComm As New SqlCommand("SELECT * FROM  tMandant WHERE cDB='" & strMandantDB & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                Dim lvwItem As New ListViewItem
                strMandantName = r("cName").ToString
            End While

            sqlConn.Close()
            Return strMandantName
        Catch ex As Exception
            MessageBox.Show(ex.Message, "getMandantbyDBName()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '##########################################################
    '# >> setConnectionString
    '# Datenbankverbindungsstring setzen 
    '##########################################################
    Public Function setConnectionString(strConnection As String, bMainDB As Boolean) As String
        Try
            If bMainDB = True Then
                strConnectionString_eazybusiness = strConnection
            Else
                strConnectionString = strConnection
            End If
            Return "1"
        Catch ex As Exception
            MessageBox.Show("Fehler bei setConnectionString: " & ex.Message, "setConnectionString()", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return "0"
        End Try
    End Function
    '##########################################################
    '# >> chkMandantPosition
    '# Mandanten Position innerhalb der tMandant bestimmen
    '##########################################################
    Public Function chkMandantPosition(strMandantDBName As String) As Integer
        Try
            Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
            Dim iCount As Byte = 0
            sqlConn.Open()

            Dim sqlComm As New SqlCommand("SELECT * FROM tMandant WHERE cDB='" & strMandantDBName & "' ORDER BY cNAME ASC", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                If chkMandantExists(r("cdb").ToString) = True Then
                    If strMandantDBName = r("cDB").ToString Then
                        My.Settings.mandant_position = r("kMandant").ToString
                        My.Settings.Save()
                        Exit While
                    End If
                End If
                iCount += 1
            End While

            Return My.Settings.mandant_position
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei chkMandantPosition abrufen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    '########################################################################
    '# >>
    '########################################################################
    Public Function getJTL_Menue_tree_import_shopste(ByVal parrent_id As Integer, ByRef lvw As ListView, ByVal ilevel As Integer, iShopKat As Integer) As Boolean


        Dim strQuery As String = " SELECT * FROM tkategorie LEFT JOIN tKategorieSprache ON tKategorieSprache.kKategorie = tkategorie.kKategorie WHERE kOberKategorie='" & parrent_id & "' AND kSprache='1'"
        Dim sqlConn As New SqlConnection(strConnectionString_eazybusiness)
        Dim iCount As Byte = 0
        sqlConn.Open()

        Dim sqlComm As New SqlCommand(strQuery, sqlConn)
        Dim dbReader_menue As SqlDataReader = sqlComm.ExecuteReader()
        Dim strData() As String
        '# Gibt es einen Treffer
        If dbReader_menue.HasRows = True Then
            While Not dbReader_menue.Read() = False

                Dim strSpace As String = ""
                '# Hauptkategorie anlegen  
                Dim i As Integer = 0
                If ilevel > 0 Then

                    For i = 0 To ilevel * 5
                        strSpace &= " "
                    Next
                End If

                Application.DoEvents()

                getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=chk_shopste_jtl_category&jtl_shop_catid=" & dbReader_menue("kKategorie").ToString & "&domain_id=" & My.Settings.SHOPSTE_domain_id, mgetUpdaterMessage.setShopsteCategories, True)
                Dim strHTTDATA() As String = strHTTPDataStore.Split("~")
                If strHTTDATA(0) = "0" Then
                    getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=set_shopste_category_jtl&shop_cat_title=" & dbReader_menue("cName").ToString & "&domain_id=" & My.Settings.SHOPSTE_domain_id & "&shop_cat_id=" & iShopKat & "&jtl_shop_catid=" & dbReader_menue("kKategorie").ToString, mgetUpdaterMessage.setShopsteCategories, True)
                    strData = strHTTPDataStore.Split("~")
                    strHTTDATA(1) = strData(0)
                End If

                frmMain.msgMaster.Text = dbReader_menue("cName")

                Call getJTL_Menue_tree_import_shopste(dbReader_menue("kKategorie").ToString, lvw, ilevel + 1, strHTTDATA(1))


            End While
            sqlConn.Close()
        End If
        sqlConn.Close()
    End Function
    '##########################################################
    '# >> Verbindung aufbauen + Connection String 
    '##########################################################
    Public Function getDBConnect(ByVal strConnection As String, Optional bEazybusiness As Boolean = False) As Boolean
        Dim sqlConn As New SqlConnection(strConnection)

        Try

            If strConnection.IndexOf("eazybusiness") > 0 Then
                bEazybusiness = True
                strConnectionString = strConnection
            End If


            sqlConn.Open()
            'If bEazybusiness = False And strConnection.IndexOf("eazybusiness") < 0 Then
            If bEazybusiness = False Then
                strConnectionString = strConnection
            Else
                strConnectionString_eazybusiness = strConnection
                'strConnectionString = strConnection
            End If

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei Verbindung getDBConnect()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '##########################################################
    '# >> Artikelliste holen 
    '##########################################################
    Public Function getArtikelListe_fehlende(ByVal lvwData As ListView, ByVal chkTranslateMissing As Boolean, Optional bAlleArtikel As Boolean = False, Optional bCorrectur As Boolean = False) As Boolean
        Dim sqlConn As New SqlConnection(strConnectionString)
        Dim strQuery As String
        Try

            SqlConnection.ClearAllPools()
            sqlConn.Open()
            dblQuellspracheZeichen = 0
            lvwData.BeginUpdate()

            If bAlleArtikel = True Then
                strQuery = "SELECT tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr FROM tartikel WHERE 1=1"

                Dim con3 As New SqlConnection(strConnectionString)
                con3.Open()
                Dim strQuery2 As String = "SELECT count(*) as anzahl FROM tartikel"
                Dim sqlComm3 As New SqlCommand(strQuery2, con3)
                Dim r3 As SqlDataReader = sqlComm3.ExecuteReader()
                '  lvwData.BeginUpdate()

                While r3.Read()
                    frmMain.ToolStripProgressBar1.Maximum = r3("anzahl").ToString
                End While
                con3.Close()

                frmMain.ToolStripProgressBar1.Value = 0

                frmMain.ToolStripProgressBar1.Visible = True

                Dim con26 As New SqlConnection(strConnectionString)
                con26.Open()
                Dim sqlComm As New SqlCommand(strQuery, con26)
                Dim r As SqlDataReader = sqlComm.ExecuteReader()
                Dim iCount As Integer = 0
                'lvwData.BeginUpdate()
                While r.Read()

                    '# Abbruch Button
                    If bAbbruch = True Then
                        Exit While
                    End If

                    iCount += 1
                    frmMain.ToolStripProgressBar1.Value = iCount

                    strQuery = "SELECT count(*) as anzahl FROM tArtikelBeschreibung WHERE kArtikel=" & r("bkArtikel").ToString & " AND tArtikelBeschreibung.kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)

                    Dim con2 As New SqlConnection(strConnectionString)
                    con2.Open()
                    Dim sqlComm2 As New SqlCommand(strQuery, con2)
                    Dim r2 As SqlDataReader = sqlComm2.ExecuteReader()
                    '  lvwData.BeginUpdate()
                    Dim lvwItem As New ListViewItem
                    frmMain.msgMaster.Text = r("bkArtikel").ToString

                    If r("bkArtikel").ToString = "29768" Then
                        Stop
                    End If

                    Application.DoEvents()
                    While r2.Read()
                        If r2("anzahl").ToString = 0 Then

                            strQuery = "SELECT * FROM tArtikelBeschreibung WHERE kArtikel=" & r("bkArtikel").ToString & " AND tArtikelBeschreibung.kSprache=1"

                            Dim con23 As New SqlConnection(strConnectionString)
                            con23.Open()
                            Dim sqlComm23 As New SqlCommand(strQuery, con23)
                            Dim r23 As SqlDataReader = sqlComm23.ExecuteReader()
                            '  lvwData.BeginUpdate()

                            While r23.Read()
                                dblQuellspracheZeichen += r23("cName").ToString.Length + r23("cKurzBeschreibung").ToString.Length + r23("cBeschreibung").ToString.Length
                                lvwItem.Text = r("bArtNr").ToString  ' Artikelnummer
                                lvwItem.SubItems.Add(r23("cName").ToString)  ' Name 
                                lvwItem.SubItems.Add("") ' Eng Name
                                lvwItem.SubItems.Add(r23("cKurzBeschreibung").ToString) ' Beschreibung 
                                lvwItem.SubItems.Add(r23("cBeschreibung").ToString) ' Kurzbeschreibung
                                lvwItem.SubItems.Add("") ' Kurzbeschreibung
                                lvwItem.SubItems.Add("") ' Kurzbeschreibung
                                lvwItem.SubItems.Add(r23("kArtikel").ToString) ' Kurzbeschreibung
                                lvwItem.SubItems.Add(jtlwawi_artikel_hasEigenschaft(r23("kArtikel").ToString)) ' Hat Eigenschaften
                                lvwData.Items.Add(lvwItem)
                                Exit While 'bug (?)
                            End While

                            con23.Close()

                        End If
                    End While

                    con2.Close()
                End While

                con26.Close()
                'lvwData.EndUpdate()
            Else

                If chkTranslateMissing = True Then
                    strQuery = "SELECT tArtikelBeschreibung.kArtikel as sArtikelID,tArtikelBeschreibung.*, tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr FROM tartikel LEFT JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel WHERE tArtikelBeschreibung.kSprache = " & My.Settings.SpracheSelected(My.Settings.mandant_position) & "  AND tArtikelBeschreibung.cName is NULL"
                    ' strQuery = "SELECT tArtikelSprache.kArtikel as sArtikelID,tArtikelSprache.*, tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr,tartikel.cName as bName,tartikel.cBeschreibung as bBeschreibung,tartikel.cKurzBeschreibung as bKurzBeschreibung FROM tartikel LEFT JOIN tArtikelSprache ON tartikel.cName = tArtikelSprache.cName WHERE tArtikelSprache.kSprache = " & My.Settings.SpracheSelected(My.Settings.mandant_position)

                Else
                    If bCorrectur = True Then
                        strQuery = "SELECT tArtikelBeschreibung.kArtikel as sArtikelID,tArtikelBeschreibung.*, tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr FROM tartikel LEFT JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel WHERE tArtikelBeschreibung.kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)
                        '& " AND tArtikelSprache.kArtikel='15156'"
                        'strQuery = "SELECT * FROM tArtikelSprache WHERE cName=''"

                    Else
                        strQuery = "SELECT tArtikelBeschreibung.kArtikel as sArtikelID,tArtikelBeschreibung.*, tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr FROM tartikel LEFT JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel WHERE tArtikelBeschreibung.kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)
                    End If
                End If


                Dim con25 As New SqlConnection(strConnectionString)
                con25.Open()
                Dim sqlComm As New SqlCommand(strQuery, con25)
                Dim r As SqlDataReader = sqlComm.ExecuteReader()
                '  lvwData.BeginUpdate()
                While r.Read()
                    Application.DoEvents()


                    If bAlleArtikel = False Then

                        dblQuellspracheZeichen += r("bName").ToString.Length + r("bKurzBeschreibung").ToString.Length + r("cBeschreibung").ToString.Length

                        If r("cName").ToString = " " Or r("cName").ToString = "" And bCorrectur = True Then
                            Dim lvwItem As New ListViewItem
                            lvwItem.Text = r("bArtNr").ToString  ' Artikelnummer
                            lvwItem.SubItems.Add(r("bName").ToString)  ' Name 
                            lvwItem.SubItems.Add(r("cName").ToString) ' Eng Name
                            lvwItem.SubItems.Add(r("bKurzBeschreibung").ToString) ' Beschreibung 
                            lvwItem.SubItems.Add(r("bBeschreibung").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(r("cKurzBeschreibung").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(r("cBeschreibung").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(r("bkArtikel").ToString) ' Kurzbeschreibung

                            lvwItem.SubItems.Add(jtlwawi_artikel_hasEigenschaft(r("sArtikelID").ToString)) ' Hat Eigenschaften


                            lvwData.Items.Add(lvwItem)
                        End If

                        If bCorrectur = False Then

                            Dim lvwItem As New ListViewItem
                            lvwItem.Text = r("bArtNr").ToString  ' Artikelnummer
                            lvwItem.SubItems.Add(r("bName").ToString)  ' Name 
                            lvwItem.SubItems.Add(r("cName").ToString) ' Eng Name
                            lvwItem.SubItems.Add(r("bKurzBeschreibung").ToString) ' Beschreibung 
                            lvwItem.SubItems.Add(r("bBeschreibung").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(r("cKurzBeschreibung").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(r("cBeschreibung").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(r("bkArtikel").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(jtlwawi_artikel_hasEigenschaft(r("sArtikelID").ToString)) ' Hat Eigenschaften
                            lvwData.Items.Add(lvwItem)
                        End If
                    End If
                End While

                con25.Close()

                '    lvwData.EndUpdate()
            End If

            sqlConn.Close()
            lvwData.EndUpdate()
        Catch ex As Exception
            lvwData.EndUpdate()
            MessageBox.Show(ex.Message)
            Return False
        End Try

        Return True
    End Function

    '########################################################
    '# >> Funktionsattribute
    ''########################################################
    Public Function setMerkmale(strArtikelID As String)
        Try
            Dim con3 As New SqlConnection(strConnectionString)
            con3.Open()
            Dim strQuery2 As String = "SELECT * FROM tArtikelMerkmal LEFT JOIN tMerkmal ON tArtikelMerkmal.kMerkmal = tMerkmal.kMerkmal  LEFT JOIN tMerkmalSprache ON tMerkmal.kMerkmal = tMerkmalSprache.kMerkmal LEFT JOIN tMerkmalWert ON  tMerkmalWert.kMerkmalWert = tArtikelMerkmal.kMerkmalWert LEFT JOIN tMerkmalWertSprache ON tArtikelMerkmal.kMerkmalWert = tMerkmalWertSprache.kMerkmalWert WHERE tMerkmalSprache.kSprache = 1 AND tArtikelMerkmal.kArtikel = '" & strArtikelID & "'"
            Dim sqlComm3 As New SqlCommand(strQuery2, con3)
            Dim r3 As SqlDataReader = sqlComm3.ExecuteReader()
            '  lvwData.BeginUpdate()
            Dim strAttributQuelle As String = ""
            Dim strAttributZiel As String = ""
            Dim strAttributZielWert As String = ""
            Dim strZielSpracheISO As String = ""
            strZielSpracheISO = getGoogle2TranslationCode(frmMain.cmbZielSpache.Text)

            While r3.Read()
                strAttributQuelle = r3("cName").ToString
                strAttributZielWert = r3("cWert").ToString
                '# Zeichen berücksichtigen Abrechnung
                dblQuellspracheZeichen += strAttributQuelle.Length
                If Not strAttributQuelle = "" Then
                    strAttributZiel = frmMain.getTranslateText(strAttributQuelle, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("</ p>", "</p>").Replace("</ span>", "</span>").Replace("<  / div>", "</div>").Replace("</ div>", "</div>").Replace("<  br />", "<br/>").Replace("</ font>", "</font>").Replace("</ strong>", "</strong>").Replace("</ div  >", "</div>").Replace("</  div>", "</div>").Replace("P>", "").Replace("u>", "").Replace("&#39;", "'")


                    '# UPDATE oder INSERT
                    If chkIsTranslated_merkmale(r3("kMerkmal").ToString) = True Then
                        '# UPDATE 
                        If setUPDATE_merkmale(r3("kMerkmal").ToString, strAttributZiel) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & strAttributZiel)
                            '  Exit For
                        End If

                    Else
                        '# INSERT
                        If setINSERT_merkmale(r3("kMerkmal").ToString, strAttributZiel) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & strAttributZiel)
                            '  Exit For
                        End If
                    End If

                    '##########################################
                    '# >> MerkmalWertSprache
                    '# 
                    '##########################################
                    If strAttributZielWert.Length > 0 Then
                        strAttributZielWert = frmMain.getTranslateText(strAttributZielWert, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("</ p>", "</p>").Replace("</ span>", "</span>").Replace("<  / div>", "</div>").Replace("</ div>", "</div>").Replace("<  br />", "<br/>").Replace("</ font>", "</font>").Replace("</ strong>", "</strong>").Replace("</ div  >", "</div>").Replace("</  div>", "</div>").Replace("P>", "").Replace("u>", "").Replace("&#39;", "'")
                    End If
                    dblQuellspracheZeichen += strAttributZielWert.Length
                    '# UPDATE oder INSERT
                    If chkIsTranslated_merkmalwert(r3("kMerkmalWert").ToString) = True Then
                        '# UPDATE 
                        If setUPDATE_merkmalewert(r3("kMerkmalWert").ToString, strAttributZielWert) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & strAttributZielWert)
                            '  Exit For
                        End If

                    Else
                        '# INSERT
                        If setINSERT_merkmalewert(r3("kMerkmalWert").ToString, strAttributZielWert) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & strAttributZielWert)
                            '  Exit For
                        End If
                    End If

                End If


            End While
            con3.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    '########################################################
    '# >> Funktionsattribute
    ''########################################################
    Public Function getFunktionsattribut(ArtikelID As String)
        Try
            Dim con3 As New SqlConnection(strConnectionString)
            con3.Open()
            Dim strQuery2 As String = "SELECT *,tArtikelAttribut.kArtikel as kArtikel FROM tAttribut LEFT JOIN tArtikelAttribut ON tAttribut.kAttribut = tArtikelAttribut.kAttribut LEFT JOIN tArtikelAttributSprache ON tArtikelAttribut.kArtikelAttribut = tArtikelAttributSprache.kArtikelAttribut WHERE tArtikelAttribut.kArtikel= '" & ArtikelID & "' AND tArtikelAttributSprache.kSprache=1 AND tAttribut.cGruppeName = 'JTL-Shop'"
            Dim sqlComm3 As New SqlCommand(strQuery2, con3)
            Dim r3 As SqlDataReader = sqlComm3.ExecuteReader()
            '  lvwData.BeginUpdate()
            Dim strAttributQuelle As String = ""
            Dim strAttributZiel As String = ""
            Dim strZielSpracheISO As String = ""
            strZielSpracheISO = getGoogle2TranslationCode(frmMain.cmbZielSpache.Text)

            While r3.Read()
                strAttributQuelle = r3("cWertVarchar").ToString
                '# Zeichen berücksichtigen Abrechnung
                dblQuellspracheZeichen += strAttributQuelle.Length
                If Not strAttributQuelle = "" Then
                    strAttributZiel = frmMain.getTranslateText(strAttributQuelle, "de", strZielSpracheISO).Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("</ p>", "</p>").Replace("</ span>", "</span>").Replace("<  / div>", "</div>").Replace("</ div>", "</div>").Replace("<  br />", "<br/>").Replace("</ font>", "</font>").Replace("</ strong>", "</strong>").Replace("</ div  >", "</div>").Replace("</  div>", "</div>").Replace("P>", "").Replace("u>", "").Replace("&#39;", "'")


                    '# UPDATE oder INSERT
                    If chkIsTranslated_funktionsattribut(r3("kArtikelAttribut").ToString) = True Then
                        '# UPDATE 
                        If setUPDATE_funktionsattribut(r3("kArtikelAttribut").ToString, strAttributZiel) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & strAttributZiel)
                            '  Exit For
                        End If

                    Else
                        '# INSERT
                        If setINSERT_funktionsattribut(r3("kArtikelAttribut").ToString, strAttributZiel) = False Then
                            MessageBox.Show("FEHLER:" & vbCrLf & "Angehalten bei " & vbCrLf & "NAME:" & strAttributZiel)
                            '  Exit For
                        End If
                    End If

                End If


            End While
            con3.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function getArtikelFunktionsAttribute2Translate(lvwMain As ListView)
        Try
            Dim strQuery As String = ""

            strQuery = "SELECT tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr FROM tartikel WHERE 1=1"

            Dim con3 As New SqlConnection(strConnectionString)
            con3.Open()
            Dim strQuery2 As String = "SELECT count(*) as anzahl FROM tartikel"
            Dim sqlComm3 As New SqlCommand(strQuery2, con3)
            Dim r3 As SqlDataReader = sqlComm3.ExecuteReader()
            '  lvwData.BeginUpdate()

            While r3.Read()
                frmMain.ToolStripProgressBar1.Maximum = r3("anzahl").ToString
            End While
            con3.Close()

            frmMain.ToolStripProgressBar1.Value = 0

            frmMain.ToolStripProgressBar1.Visible = True

            Dim con26 As New SqlConnection(strConnectionString)
            con26.Open()
            Dim sqlComm As New SqlCommand(strQuery, con26)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()
            Dim iCount As Integer = 0
            'lvwData.BeginUpdate()
            While r.Read()

                '# Abbruch Button
                If bAbbruch = True Then
                    Exit While
                End If

                iCount += 1
                frmMain.ToolStripProgressBar1.Value = iCount
                Dim lvwItem As New ListViewItem


                lvwItem.Text = r("bArtNr").ToString  ' Artikelnummer
                lvwItem.SubItems.Add("")  ' Name 
                lvwItem.SubItems.Add("") ' Eng Name
                lvwItem.SubItems.Add("") ' Beschreibung 
                lvwItem.SubItems.Add("") ' Kurzbeschreibung
                lvwItem.SubItems.Add("") ' Kurzbeschreibung
                lvwItem.SubItems.Add("") ' Kurzbeschreibung
                lvwItem.SubItems.Add("") ' Kurzbeschreibung
                lvwItem.SubItems.Add("") ' Hat Eigenschaften

                lvwMain.Items.Add(lvwItem)

                Application.DoEvents()

                '# Funktionsattribut übersetzen 
                If My.Settings.chkTranslate_funktionsattribute_alleSprachen = True Then
                    '# Ohne Deutsch
                    Dim i As Integer = 0
                    For i = 1 To frmMain.cmbZielSpache.Items.Count - 1
                        frmMain.cmbZielSpache.SelectedIndex = i
                        frmMain.msgMaster.Text = "Funktionsattribute übersetzen: " & frmMain.cmbZielSpache.Text
                        Application.DoEvents()
                        getFunktionsattribut(r("bkArtikel").ToString)

                    Next

                Else
                    getFunktionsattribut(r("bkArtikel").ToString)
                End If


            End While

            con26.Close()
            'lvwData.EndUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function getArtikelListe() As String

    End Function
    '##########################################################
    '# >> Artikelliste holen 
    '##########################################################
    Public Function getArtikelListe(ByVal lvwData As ListView, ByVal chkTranslateMissing As Boolean, Optional bAlleArtikel As Boolean = False, Optional bCorrectur As Boolean = False) As Boolean
        Dim sqlConn As New SqlConnection(strConnectionString)
        Dim strQuery As String
        Try

            SqlConnection.ClearAllPools()
            sqlConn.Open()
            dblQuellspracheZeichen = 0
            lvwData.BeginUpdate()

            If bAlleArtikel = True Then

                Dim strSubQuery As String = ""
                Dim strSubQueryWithWhere As String = ""
                If My.Settings.chkTranslate_normal_benutzeDatum = True Then
                    'If My.Settings.chkTranslate_normal_mod_erstellt = True Then
                    '    strSubQuery = " And dMod > '" & frmMain.DateTimePicker1.Value.Date & "'"
                    '    strSubQueryWithWhere = " WHERE dMod > '" & frmMain.DateTimePicker1.Value.Date & "'"
                    'Else
                    '    strSubQuery = " And dErstelldatum > '" & frmMain.DateTimePicker1.Value.Date & "'"
                    '    strSubQueryWithWhere = " WHERE dMod > '" & frmMain.DateTimePicker1.Value.Date & "'"
                    'End If
                End If

                strQuery = "SELECT tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr FROM tartikel WHERE 1=1 " & strSubQuery

                Dim con3 As New SqlConnection(strConnectionString)
                con3.Open()
                Dim strQuery2 As String = "SELECT count(*) as anzahl FROM tartikel" & strSubQueryWithWhere
                Dim sqlComm3 As New SqlCommand(strQuery2, con3)
                Dim r3 As SqlDataReader = sqlComm3.ExecuteReader()
                '  lvwData.BeginUpdate()

                While r3.Read()
                    frmMain.ToolStripProgressBar1.Maximum = r3("anzahl").ToString
                End While
                con3.Close()

                frmMain.ToolStripProgressBar1.Value = 0

                frmMain.ToolStripProgressBar1.Visible = True

                Dim con26 As New SqlConnection(strConnectionString)
                con26.Open()
                Dim sqlComm As New SqlCommand(strQuery, con26)
                Dim r As SqlDataReader = sqlComm.ExecuteReader()
                Dim iCount As Integer = 0
                'lvwData.BeginUpdate()
                While r.Read()

                    '# Abbruch Button
                    If bAbbruch = True Then
                        Exit While
                    End If

                    iCount += 1
                    frmMain.ToolStripProgressBar1.Value = iCount

                    strQuery = "SELECT count(*) as anzahl FROM tArtikelBeschreibung WHERE kArtikel=" & r("bkArtikel").ToString & " AND tArtikelBeschreibung.kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)

                    Dim con2 As New SqlConnection(strConnectionString)
                    con2.Open()
                    Dim sqlComm2 As New SqlCommand(strQuery, con2)
                    Dim r2 As SqlDataReader = sqlComm2.ExecuteReader()
                    '  lvwData.BeginUpdate()
                    Dim lvwItem As New ListViewItem
                    frmMain.msgMaster.Text = r("bkArtikel").ToString


                    Application.DoEvents()
                    While r2.Read()
                        If r2("anzahl").ToString = 0 Then

                            strQuery = "SELECT * FROM tArtikelBeschreibung WHERE kArtikel=" & r("bkArtikel").ToString & " AND tArtikelBeschreibung.kSprache=1"

                            Dim con23 As New SqlConnection(strConnectionString)
                            con23.Open()
                            Dim sqlComm23 As New SqlCommand(strQuery, con23)
                            Dim r23 As SqlDataReader = sqlComm23.ExecuteReader()
                            '  lvwData.BeginUpdate()

                            While r23.Read()
                                dblQuellspracheZeichen += r23("cName").ToString.Length + r23("cKurzBeschreibung").ToString.Length + r23("cBeschreibung").ToString.Length
                                lvwItem.Text = r("bArtNr").ToString  ' Artikelnummer
                                lvwItem.SubItems.Add(r23("cName").ToString)  ' Name 
                                lvwItem.SubItems.Add("") ' Eng Name
                                lvwItem.SubItems.Add(r23("cKurzBeschreibung").ToString) ' Beschreibung 
                                lvwItem.SubItems.Add(r23("cBeschreibung").ToString) ' Kurzbeschreibung
                                lvwItem.SubItems.Add("") ' Kurzbeschreibung
                                lvwItem.SubItems.Add("") ' Kurzbeschreibung
                                lvwItem.SubItems.Add(r23("kArtikel").ToString) ' Kurzbeschreibung
                                lvwItem.SubItems.Add(jtlwawi_artikel_hasEigenschaft(r23("kArtikel").ToString)) ' Hat Eigenschaften
                                lvwData.Items.Add(lvwItem)
                                Exit While 'bug (?)
                            End While

                            con23.Close()

                        End If
                    End While

                    con2.Close()
                End While

                con26.Close()
                'lvwData.EndUpdate()
            Else

                Dim strSubQuery As String = ""
                'If My.Settings.chkTranslate_normal_benutzeDatum = True Then
                '    If My.Settings.chkTranslate_normal_mod_erstellt = True Then
                '        strSubQuery = " And dMod > '" & frmMain.DateTimePicker1.Value.Date & "'"
                '    Else
                '        strSubQuery = " And dErstelldatum > '" & frmMain.DateTimePicker1.Value.Date & "'"
                '    End If
                'End If

                If chkTranslateMissing = True Then
                    strQuery = "SELECT tArtikelBeschreibung.kArtikel as sArtikelID,tArtikelBeschreibung.*, tartikel.kArtikel as bkArtikel, tartikel.cArtNr as cArtNr FROM tartikel LEFT JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel WHERE tArtikelBeschreibung.kSprache = " & My.Settings.SpracheSelected(My.Settings.mandant_position) & "  AND (tArtikelBeschreibung.cName is Null or tArtikelBeschreibung.cName ='')" & strSubQuery

                    ' strQuery = "SELECT tArtikelSprache.kArtikel as sArtikelID,tArtikelSprache.*, tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr,tartikel.cName as bName,tartikel.cBeschreibung as bBeschreibung,tartikel.cKurzBeschreibung as bKurzBeschreibung FROM tartikel LEFT JOIN tArtikelSprache ON tartikel.cName = tArtikelSprache.cName WHERE tArtikelSprache.kSprache = " & My.Settings.SpracheSelected(My.Settings.mandant_position)

                Else
                    If bCorrectur = True Then
                        'strQuery = "SELECT tArtikelBeschreibung.kArtikel as sArtikelID,tArtikelBeschreibung.*, tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr FROM tartikel JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel WHERE tArtikelBeschreibung.kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position) & " AND tArtikelBeschreibung.cName is NULL"
                        '& " AND tArtikelSprache.kArtikel='15156'"
                        'strQuery = "SELECT * FROM tArtikelSprache WHERE cName=''"
                        strQuery = "SELECT * FROM tArtikelBeschreibung  LEFT JOIN tArtikel ON tArtikelBeschreibung.kArtikel = tArtikel.kArtikel  WHERE tArtikelBeschreibung.kSprache Not IN 
 (select kSprache
  From tSpracheUsed
  Where kSprache = " & My.Settings.SpracheSelected(My.Settings.mandant_position) & "
 ) And kSprache=1" & strSubQuery

                    Else
                        strQuery = "SELECT tArtikelBeschreibung.kArtikel as sArtikelID,tArtikelBeschreibung.*, tartikel.kArtikel as bkArtikel, tartikel.cArtNr as bArtNr FROM tartikel LEFT JOIN tArtikelBeschreibung ON tartikel.kArtikel = tArtikelBeschreibung.kArtikel WHERE tArtikelBeschreibung.kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position) & "And tArtikelBeschreibung.cName Is NULL" & strSubQuery
                    End If
                End If


                Dim con25 As New SqlConnection(strConnectionString)
                con25.Open()
                Dim sqlComm As New SqlCommand(strQuery, con25)
                Dim r As SqlDataReader = sqlComm.ExecuteReader()
                '  lvwData.BeginUpdate()
                While r.Read()





                    If bAlleArtikel = False Then


                        strQuery = "SELECT * FROM tArtikelBeschreibung WHERE kArtikel=" & r("bkArtikel").ToString & " AND tArtikelBeschreibung.kSprache=1"

                        Dim con23 As New SqlConnection(strConnectionString)
                        con23.Open()
                        Dim sqlComm23 As New SqlCommand(strQuery, con23)
                        Dim r23 As SqlDataReader = sqlComm23.ExecuteReader()
                        '  lvwData.BeginUpdate()

                        While r23.Read()
                            dblQuellspracheZeichen += r23("cName").ToString.Length + r("cKurzBeschreibung").ToString.Length + r23("cBeschreibung").ToString.Length
                            frmMain.msgMaster.Text = r23("cName").ToString
                            Application.DoEvents()
                            Dim lvwItem As New ListViewItem
                            lvwItem.Text = r("cArtNr").ToString  ' Artikelnummer
                            lvwItem.SubItems.Add(r23("cName").ToString)  ' Name 
                            lvwItem.SubItems.Add(r("cName").ToString) ' Eng Name
                            lvwItem.SubItems.Add(r23("cKurzBeschreibung").ToString) ' Beschreibung 
                            lvwItem.SubItems.Add(r23("cBeschreibung").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(r("cKurzBeschreibung").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(r("cBeschreibung").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(r("kArtikel").ToString) ' Kurzbeschreibung
                            lvwItem.SubItems.Add(jtlwawi_artikel_hasEigenschaft(r("kArtikel").ToString)) ' Hat Eigenschaften
                            lvwData.Items.Add(lvwItem)

                            Exit While 'doppelte artikel nummer

                        End While

                        con23.Close()


                        '   If r("cName").ToString = " " Or r("cName").ToString = "" And bCorrectur = True Then

                        '  End If

                        'If bCorrectur = False Then
                        '    Dim lvwItem As New ListViewItem
                        '    lvwItem.Text = r("cArtNr").ToString  ' Artikelnummer
                        '    lvwItem.SubItems.Add(r("cName").ToString)  ' Name 
                        '    lvwItem.SubItems.Add("") ' Eng Name
                        '    lvwItem.SubItems.Add(r("cKurzBeschreibung").ToString) ' Beschreibung 
                        '    lvwItem.SubItems.Add(r("cBeschreibung").ToString) ' Kurzbeschreibung
                        '    lvwItem.SubItems.Add("") ' Kurzbeschreibung
                        '    lvwItem.SubItems.Add("") ' Kurzbeschreibung
                        '    lvwItem.SubItems.Add(r("kArtikel").ToString) ' Kurzbeschreibung
                        '    lvwItem.SubItems.Add(jtlwawi_artikel_hasEigenschaft(r("kArtikel").ToString)) ' Hat Eigenschaften
                        '    lvwData.Items.Add(lvwItem)
                        'End If
                    End If
                End While

                con25.Close()

                '    lvwData.EndUpdate()
            End If

            sqlConn.Close()
            lvwData.EndUpdate()
        Catch ex As Exception
            lvwData.EndUpdate()
            MessageBox.Show(ex.Message)
            Return False
        End Try

        Return True
    End Function

    '#######################################################################
    '# >> Update oder Insert durchführen 
    '#######################################################################
    Public Function chkIsTranslatedKategorie(ByVal strKategorieID As String) As Boolean
        Dim sqlConn As New SqlConnection(strConnectionString)
        sqlConn.Open()
        Dim sqlComm As New SqlCommand("SELECT count(*) as Anzahl FROM tKategorieSprache WHERE kKategorie='" & strKategorieID & "' AND kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position), sqlConn)
        Dim r As SqlDataReader = sqlComm.ExecuteReader()

        While r.Read()
            If r("Anzahl") > 0 Then
                Return True
            Else
                Return False
            End If
        End While

        sqlConn.Close()
    End Function

    Public Function getLanguage2JTLSprachID(strSprache As String) As String
        Try

            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT * FROM tSpracheUsed WHERE cNameDeu='" & strSprache & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                My.Settings.SpracheSelected(My.Settings.mandant_position) = r("kSprache").ToString
            End While

            sqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function getPossibleLanguages2Checkbox(cmb As ComboBox) As Boolean
        Try
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT * FROM tSpracheUsed", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                cmb.Items.Add(r("cNameDeu").ToString())
            End While

            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    '#######################################################################
    '# >> Update oder Insert durchführen 
    '#######################################################################
    Public Function chkIsTranslated(ByVal strArtikelID As String) As Boolean
        Try


            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT count(*) as Anzahl FROM tArtikelBeschreibung WHERE kArtikel='" & strArtikelID & "' AND kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position), sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                If r("Anzahl") > 0 Then
                    Return True
                Else
                    Return False
                End If
            End While
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    '#######################################################################
    '# >> Update oder Insert durchführen 
    '#######################################################################
    Public Function chkIsTranslated_merkmalwert(ByVal strMerkmalWertID As String) As Boolean
        Try


            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT count(*) as Anzahl FROM tMerkmalWertSprache WHERE kMerkmalWert='" & strMerkmalWertID & "' AND kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position), sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                If r("Anzahl") > 0 Then
                    Return True
                Else
                    Return False
                End If
            End While
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    '#######################################################################
    '# >> Update oder Insert durchführen 
    '#######################################################################
    Public Function chkIsTranslated_merkmale(ByVal strMerkmalID As String) As Boolean
        Try


            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT count(*) as Anzahl FROM tMerkmalSprache WHERE kMerkmal='" & strMerkmalID & "' AND kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position), sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                If r("Anzahl") > 0 Then
                    Return True
                Else
                    Return False
                End If
            End While
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    '#######################################################################
    '# >> Update oder Insert durchführen 
    '#######################################################################
    Public Function chkIsTranslated_funktionsattribut(ByVal strArtikelID As String) As Boolean
        Try


            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT count(*) as Anzahl FROM tArtikelAttributSprache WHERE kArtikelAttribut='" & strArtikelID & "' AND kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position), sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()
                If r("Anzahl") > 0 Then
                    Return True
                Else
                    Return False
                End If
            End While
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function
    '##########################################################################
    '# >> Artikel Funktionsattribut UPDATE 
    '##########################################################################
    Public Function setUPDATE_merkmalewert(ByVal strMerkmalWertID As String, ByVal strName As String) As Boolean
        Try
            Dim strUpdate As String = ""
            Dim strBreak As String = "<br/><br/><br/><br/>"
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            strUpdate = "UPDATE tMerkmalWertSprache SET cWert=N'" & strName & "' WHERE kMerkmalWert=" & strMerkmalWertID & " AND  kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)


            Dim sqlComm As New SqlCommand(strUpdate, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE vom Funktionsattribut " & strMerkmalWertID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    '##########################################################################
    '# >> Artikel Funktionsattribut UPDATE 
    '##########################################################################
    Public Function setUPDATE_merkmale(ByVal strMerkmalID As String, ByVal strName As String) As Boolean
        Try
            Dim strUpdate As String = ""
            Dim strBreak As String = "<br/><br/><br/><br/>"
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            strUpdate = "UPDATE tMerkmalSprache SET cName=N'" & strName & "' WHERE kMerkmal=" & strMerkmalID & " AND  kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)


            Dim sqlComm As New SqlCommand(strUpdate, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE vom Funktionsattribut " & strMerkmalID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    '##########################################################################
    '# >> Artikel Funktionsattribut UPDATE 
    '##########################################################################
    Public Function setUPDATE_funktionsattribut(ByVal strArtikelAttributID As String, ByVal strName As String) As Boolean
        Try
            Dim strUpdate As String = ""
            Dim strBreak As String = "<br/><br/><br/><br/>"
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            strUpdate = "UPDATE tArtikelAttributSprache SET cWertVarchar=N'" & strName & "' WHERE kArtikelAttribut=" & strArtikelAttributID & " AND  kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)


            Dim sqlComm As New SqlCommand(strUpdate, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE vom Funktionsattribut " & strArtikelAttributID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    '##########################################################################
    '# >> Artikel Translate UPDATE 
    '##########################################################################
    Public Function setUPDATE_TextData(ByVal strArtikelID As String, ByVal strName As String, ByVal strKurzbeschreibung As String, ByVal strBeschreibung As String, ByVal lvwMainData As ListView, ByVal iIndex As Integer) As Boolean
        Try
            Dim strUpdate As String = ""
            Dim strBreak As String = "<br/><br/><br/><br/>"
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            '# Mit Deutscher Übersetzung
            If My.Settings.trans_MitDeutsch = True Then
                strBeschreibung = lvwMainData.SelectedItems(iIndex).SubItems(4).Text & strBreak & strBeschreibung
                strKurzbeschreibung = lvwMainData.SelectedItems(iIndex).SubItems(3).Text & strBreak & strKurzbeschreibung
            End If


            strUpdate = "UPDATE tArtikelBeschreibung SET cName=N'" & strName & "',cBeschreibung=N'" & strBeschreibung & "',cKurzBeschreibung=N'" & strKurzbeschreibung & "' WHERE kArtikel=" & strArtikelID & " AND  kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)


            Dim sqlComm As New SqlCommand(strUpdate, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE von " & strArtikelID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    '##########################################################################
    '# >> Artikel Translate UPDATE 
    '##########################################################################
    Public Function setUPDATE_TextData_englisch(ByVal strArtikelID As String, ByVal strName As String, ByVal strKurzbeschreibung As String, ByVal strBeschreibung As String) As Boolean
        Try
            Dim strUpdate As String = ""
            Dim strBreak As String = "<br/><br/><br/><br/>"
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            strUpdate = "UPDATE tArtikelBeschreibung SET cName='" & strName & "',cBeschreibung='" & strBeschreibung & "',cKurzBeschreibung='" & strKurzbeschreibung & "' WHERE kArtikel=" & strArtikelID & " AND  kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)


            Dim sqlComm As New SqlCommand(strUpdate, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE von " & strArtikelID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    '##########################################################################
    '# >> Artikel Translate UPDATE 
    '##########################################################################
    Public Function setUPDATE_Kategorie(ByVal strKategorieID As String, ByVal strCatName As String, ByVal strCatBeschreibung As String, ByVal lvwMainData As ListView, ByVal iIndex As Integer) As Boolean
        Try
            Dim strUpdate As String = ""
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            strUpdate = "UPDATE tKategorieSprache SET cName='" & strCatName & "',cBeschreibung='" & strCatBeschreibung & "'  WHERE kKategorie=" & strKategorieID & " AND  kSprache=" & My.Settings.SpracheSelected(My.Settings.mandant_position)


            Dim sqlComm As New SqlCommand(strUpdate, sqlConn)

            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE von " & strCatName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    Public Function setINSERT_KategorieJTL2Shopste(jtl_shopcat As String, jtl_shopste_cat As String) As String
        Dim sqlConn As New SqlConnection(strConnectionString)
        Dim strINSERT As String

        sqlConn.Open()

        strINSERT = "INSERT INTO jbm_jtlcat2shopstemarketcat(jtl_shopcat,jtl_shopste_cat)VALUES("
        strINSERT &= "'" & jtl_shopcat & "',"
        strINSERT &= "'" & jtl_shopste_cat & "')"

        Dim sqlComm As New SqlCommand(strINSERT, sqlConn)
        sqlComm.ExecuteNonQuery()

        sqlConn.Close()

    End Function

    Public Function setUPDATE_KategorieJTL2Shopste(jtl_shopcat As String, jtl_shopste_cat As String) As String
        Dim sqlConn As New SqlConnection(strConnectionString)
        Dim strINSERT As String

        sqlConn.Open()

        strINSERT = "UPDATE jbm_jtlcat2shopstemarketcat SET jtl_shopste_cat = "
        strINSERT &= "'" & jtl_shopste_cat & "' "
        strINSERT &= "WHERE jtl_shopcat='" & jtl_shopcat & "'"

        Dim sqlComm As New SqlCommand(strINSERT, sqlConn)
        sqlComm.ExecuteNonQuery()

        sqlConn.Close()

    End Function

    '################################################################################
    '# >> Artikel Translate INSERT 
    '################################################################################
    Public Function setINSERT_Kategorie(strKategorieID As String, strCatName As String, strCatBeschreibung As String, ByVal lvwMainData As ListView, ByVal iIndex As Integer) As Boolean
        Try
            Dim strINSERT As String = ""
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            strINSERT = "INSERT INTO tKategorieSprache(cName,cBeschreibung,kSprache,kKategorie)VALUES("
            strINSERT &= "'" & strCatName & "',"
            strINSERT &= "'" & strCatBeschreibung & "',"
            strINSERT &= "'" & My.Settings.SpracheSelected(My.Settings.mandant_position) & "',"
            strINSERT &= "'" & strKategorieID & "')"


            Dim sqlComm As New SqlCommand(strINSERT, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim hinzufügen von " & strCatName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '################################################################################
    '# >> Artikel Translate INSERT 
    '################################################################################
    Public Function setINSERT_funktionsattribut(ByVal strArtikelAttributID As String, ByVal strName As String) As Boolean

        Try
            Dim strINSERT As String = ""
            Dim strBreak As String = "<br/><br/><br/><br/>"
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()


            strINSERT = "INSERT INTO tArtikelAttributSprache(kArtikelAttribut,kSprache,cWertVarchar,nWertInt,fWertDecimal,dWertDateTime)VALUES("
            strINSERT &= "'" & strArtikelAttributID & "',"
            strINSERT &= "'" & My.Settings.SpracheSelected(My.Settings.mandant_position) & "',"
            strINSERT &= "'" & strName.Replace("'", "''") & "',"
            strINSERT &= "'0',"
            strINSERT &= "'0',"
            strINSERT &= " ''"
            strINSERT &= ")"

            Dim sqlComm As New SqlCommand(strINSERT, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE von " & strArtikelAttributID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '################################################################################
    '# >> Artikel Translate INSERT 
    '################################################################################
    Public Function setINSERT_merkmalewert(ByVal strMerkmaleWertID As String, ByVal strName As String) As Boolean

        Try
            Dim strINSERT As String = ""
            Dim strBreak As String = "<br/><br/><br/><br/>"
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()


            strINSERT = "INSERT INTO tMerkmalWertSprache(kMerkmalWert,kSprache,cWert)VALUES("
            strINSERT &= "'" & strMerkmaleWertID & "',"
            strINSERT &= "'" & My.Settings.SpracheSelected(My.Settings.mandant_position) & "',"
            strINSERT &= "'" & strName.Replace("'", "''") & "'"
            strINSERT &= ")"

            Dim sqlComm As New SqlCommand(strINSERT, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE von " & strMerkmaleWertID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    '################################################################################
    '# >> Artikel Translate INSERT 
    '################################################################################
    Public Function setINSERT_merkmale(ByVal strMerkmaleID As String, ByVal strName As String) As Boolean

        Try
            Dim strINSERT As String = ""
            Dim strBreak As String = "<br/><br/><br/><br/>"
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()


            strINSERT = "INSERT INTO tMerkmalSprache(kMerkmal,kSprache,cName)VALUES("
            strINSERT &= "'" & strMerkmaleID & "',"
            strINSERT &= "'" & My.Settings.SpracheSelected(My.Settings.mandant_position) & "',"
            strINSERT &= "'" & strName.Replace("'", "''")
            strINSERT &= ")"

            Dim sqlComm As New SqlCommand(strINSERT, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE von " & strMerkmaleID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '################################################################################
    '# >> Artikel Translate INSERT 
    '################################################################################
    Public Function setINSERT_TextData(ByVal strArtikelID As String, ByVal strName As String, ByVal strKurzbeschreibung As String, ByVal strBeschreibung As String, ByVal lvwMainData As ListView, ByVal iIndex As Integer)

        Try
            Dim strINSERT As String = ""
            Dim strBreak As String = "<br/><br/><br/><br/>"
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            '# Mit Deutscher Übersetzung
            If My.Settings.trans_MitDeutsch = True Then
                strBeschreibung = lvwMainData.SelectedItems(iIndex).SubItems(4).Text & strBreak & strBeschreibung
                strKurzbeschreibung = lvwMainData.SelectedItems(iIndex).SubItems(3).Text & strBreak & strKurzbeschreibung
            End If

            strINSERT = "INSERT INTO tArtikelBeschreibung(cName,cBeschreibung,cKurzBeschreibung,kSprache,kArtikel,kShop,KPlattform)VALUES("
            strINSERT &= "'" & strName & "',"
            strINSERT &= "'" & strBeschreibung & "',"
            strINSERT &= "'" & strKurzbeschreibung & "',"
            strINSERT &= "'" & My.Settings.SpracheSelected(My.Settings.mandant_position) & "',"
            strINSERT &= "'" & strArtikelID & "',"
            strINSERT &= " '0',"
            strINSERT &= "'1'"
            strINSERT &= ")"

            Dim sqlComm As New SqlCommand(strINSERT, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE von " & strArtikelID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function getGoogle2TranslationCode(strSprache As String) As String
        Dim strZielISOCode As String = ""
        Try
            Select Case strSprache
                Case "Deutsch"
                    strZielISOCode = "de"
                Case "Englisch"
                    strZielISOCode = "en"
                Case "Französisch"
                    strZielISOCode = "fr"
                Case "Spanisch"
                    strZielISOCode = "es"
                Case "Italienisch"
                    strZielISOCode = "it"
                Case "Russisch"
                    strZielISOCode = "ru"
            End Select

            Return strZielISOCode
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    '################################################################################
    '# >> Artikel Translate INSERT 
    '################################################################################
    Public Function setINSERT_TextData_englisch(ByVal strArtikelID As String, ByVal strName As String, ByVal strKurzbeschreibung As String, ByVal strBeschreibung As String)

        Try
            Dim strINSERT As String = ""
            Dim strBreak As String = "<br/><br/><br/><br/>"
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()

            strINSERT = "INSERT INTO tArtikelBeschreibung(cName,cBeschreibung,cKurzBeschreibung,kSprache,kArtikel)VALUES("
            strINSERT &= "'" & strName & "',"
            strINSERT &= "'" & strBeschreibung & "',"
            strINSERT &= "'" & strKurzbeschreibung & "',"
            strINSERT &= "'" & My.Settings.SpracheSelected(My.Settings.mandant_position) & "',"
            strINSERT &= "'" & strArtikelID & "')"

            Dim sqlComm As New SqlCommand(strINSERT, sqlConn)
            sqlComm.ExecuteNonQuery()

            sqlConn.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim UPDATE von " & strArtikelID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function getSpracheigenschaften(lvw As ListView) As Boolean
        Try
            lvw.Items.Clear()

            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT kEigenschaft,count(*) as anzahl FROM tEigenschaftSprache group by tEigenschaftSprache.kEigenschaft", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()

            While r.Read()

                Dim lvwitem As New ListViewItem
                lvwitem.Text = r("kEigenschaft").ToString
                lvwitem.SubItems.Add(r("anzahl").ToString)
                lvw.Items.Add(lvwitem)
            End While

            sqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim ABRUFEN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function chkJTLShopCat2Shopste(jtl_shopcat As String) As Integer
        '# Alle Sprachen ausgeben
        Dim strINSERT As String = ""
        Dim sqlConn As New SqlConnection(strConnectionString)
        sqlConn.Open()

        strINSERT = "SELECT count(*) as anzahl FROM jbm_jtlcat2shopstemarketcat WHERE jtl_shopcat=" & jtl_shopcat
        Dim sqlComm3 As New SqlCommand(strINSERT, sqlConn)
        Dim r2 As SqlDataReader = sqlComm3.ExecuteReader()

        While r2.Read()
            Return Convert.ToInt16(r2("anzahl").ToString)

        End While

    End Function

    Public Function setSprachEigenSchaftWert_repair(lvw As ListView) As Boolean
        Try
            Dim strINSERT As String = ""

            'tSpracheUsed
            Dim sqlConn3 As New SqlConnection(strConnectionString)
            sqlConn3.Open()

            '# Alle Sprachen ausgeben
            strINSERT = "SELECT * FROM tSpracheUsed"
            Dim sqlComm3 As New SqlCommand(strINSERT, sqlConn3)
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

            sqlConn3.Close()

            frmMain.ToolStripProgressBar1.Maximum = (strJTLSprachen.Length - 1) * lvw.Items.Count - 1
            frmMain.ToolStripProgressBar1.Value = 0
            frmMain.ToolStripProgressBar1.Minimum = 0
            frmMain.ToolStripProgressBar1.Visible = True
            Dim iGesCount = 0

            For i = 0 To lvw.Items.Count - 1

                '# Alle Sprachen durchgehen

                ' Alle Spracheigenschaften abrufen
                Dim sqlConn As New SqlConnection(strConnectionString)
                sqlConn.Open()
                Dim sqlComm As New SqlCommand("SELECT * FROM teigenschaftwert WHERE kEigenschaft ='" & lvw.Items(i).Text & "'", sqlConn)
                Dim r As SqlDataReader = sqlComm.ExecuteReader()
                '   Dim strSprachen As String = ""
                Dim bFound As Boolean = False
                Dim kEigenschaft As String = ""
                Dim strZielSpracheISO As String = ""
                Dim strName As String = ""




                While r.Read()
                    ' 2 -5 Sprachen durchgehen
                    For z = 1 To strJTLSprachen.Length - 2

                        strZielSpracheISO = getGoogle2TranslationCode(strJTLSprachen(z))

                        frmMain.msgMaster.Text = iGesCount & " von " & frmMain.ToolStripProgressBar1.Maximum & " -- " & r("cName").ToString
                        Application.DoEvents()
                        'msgMaster.Text = i + 1 & " - " & lvwMainData.SelectedItems.Count - 1 & " -> " & lvwMainData.SelectedItems(i).SubItems(1).Text
                        'Application.DoEvents()

                        '# Übersetzen in die Zielsprache 

                        frmMain.ToolStripProgressBar1.Value = iGesCount
                        iGesCount += 1

                        Dim strQuery As String = "SELECT * FROM tEigenschaftWertSprache WHERE kEigenschaftWert='" & r("kEigenschaftWert").ToString & "' AND kSprache='" & strJTLSprachen_id(z) & "'"
                        Dim sqlConn4 As New SqlConnection(strConnectionString)
                        sqlConn4.Open()

                        Dim sqlComm4 As New SqlCommand(strQuery, sqlConn4)
                        Dim r4 As SqlDataReader = sqlComm4.ExecuteReader()
                        bFound = False
                        Dim strSprachWert As String = ""
                        Dim strKEigenschaftWert As String = ""
                        While r4.Read()
                            bFound = True
                            strSprachWert = r4("cName").ToString
                            strKEigenschaftWert = r4("kEigenschaftWert").ToString
                        End While

                        '# Spracheintrag gefunden -> aber kein Wert -> dann UPDATE 
                        If strSprachWert.Length = 0 And bFound = True Then

                            strName = frmMain.getTranslateText(r("cName").ToString, "de", strZielSpracheISO).Replace("&quot;", """")

                            If strName.Length > 0 Then

                                Dim sqlConn2 As New SqlConnection(strConnectionString)
                                sqlConn2.Open()

                                strINSERT = "UPDATE tEigenschaftWertSprache SET cName='" & strName.Trim & "' WHERE kEigenschaftWert='" & strKEigenschaftWert & "' AND kSprache='" & strJTLSprachen_id(z) & "'"
                                Dim sqlComm2 As New SqlCommand(strINSERT, sqlConn2)
                                sqlComm2.ExecuteNonQuery()
                                sqlConn2.Close()

                            End If

                        ElseIf bFound = False Then
                            strName = frmMain.getTranslateText(r("cName").ToString, "de", strZielSpracheISO).Replace("&quot;", """")

                            If strName.Length > 0 Then

                                Dim sqlConn2 As New SqlConnection(strConnectionString)
                                sqlConn2.Open()

                                strINSERT = "INSERT INTO tEigenschaftWertSprache (kEigenschaftWert,kSprache,cName) VALUES('" & r("kEigenschaftWert").ToString & "','" & strJTLSprachen_id(z) & "','" & strName.Trim & "')"

                                Dim sqlComm2 As New SqlCommand(strINSERT, sqlConn2)
                                sqlComm2.ExecuteNonQuery()
                                sqlConn2.Close()

                            End If

                        End If


                        sqlConn4.Close()


                    Next

                    bFound = True

                End While

                sqlConn.Close()


                '# Welche Sprachen sind vorhanden 
                'Dim strSpracheSplit() As String = strSprachen.Split(",")


            Next
            frmMain.ToolStripProgressBar1.Visible = False

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Reparieren setSprachEigenSchaftWert_repair", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function getEigenschaft_wert(kEigenschaft As String) As String()
        Dim sqlConn4 As New SqlConnection(strConnectionString)
        sqlConn4.Open()
        Dim strEigenschaft(250) As String
        Dim iCount As Integer = 0
        '# Wert von Eigenschaft auslesen
        Dim strSELECT As String = "SELECT * FROM teigenschaftwert JOIN tEigenschaftWertSprache ON tEigenschaftWertSprache.kEigenschaftWert =  teigenschaftwert.kEigenschaftWert WHERE kEigenschaft='" & kEigenschaft & "' AND kSprache=1"
        Dim sqlComm4 As New SqlCommand(strSELECT, sqlConn4)
        Dim r4 As SqlDataReader = sqlComm4.ExecuteReader()

        While r4.Read()
            strEigenschaft(iCount) = r4("cName").ToString
            iCount = iCount + 1
        End While
        Return strEigenschaft
    End Function

    Public Function getEigenschaft(strID As String) As String
        Dim strEigenschaftName As String = ""
        Dim sqlConn4 As New SqlConnection(strConnectionString)
        sqlConn4.Open()

        '# Wert von Eigenschaft auslesen
        Dim strSELECT As String = "SELECT * FROM teigenschaft LEFT JOIN tEigenschaftSprache ON tEigenschaftSprache.kEigenschaft =  teigenschaft.kEigenschaft WHERE teigenschaft.kEigenschaft='" & strID & "'"
        Dim sqlComm4 As New SqlCommand(strSELECT, sqlConn4)
        Dim r4 As SqlDataReader = sqlComm4.ExecuteReader()

        While r4.Read()
            strEigenschaftName = r4("cName").ToString()
        End While
        Return strEigenschaftName
    End Function

    Public Function setSprachEigenSchaftWert_translate(lvwitem As ListViewItem, strZielsprache As String, strJTLSprachen_id As String) As Boolean
        Try
            Dim strINSERT As String = ""


            Dim sqlConn4 As New SqlConnection(strConnectionString)
            sqlConn4.Open()

            '# Wert von Eigenschaft auslesen
            strINSERT = "SELECT * FROM teigenschaft WHERE kArtikel='" & lvwitem.SubItems(7).Text & "'"
            Dim sqlComm4 As New SqlCommand(strINSERT, sqlConn4)
            Dim r4 As SqlDataReader = sqlComm4.ExecuteReader()

            Dim strCName As String = ""
            'Dim strINSERT As String = ""
            Dim bfound2 As Boolean = False
            Dim strZielSpracheISO As String = ""

            strZielSpracheISO = getGoogle2TranslationCode(strZielsprache)
            While r4.Read()


                ' Alle Spracheigenschaften abrufen
                Dim sqlConn As New SqlConnection(strConnectionString)
                sqlConn.Open()
                Dim sqlCommSprachEigenschaft As New SqlCommand("Select * FROM tEigenschaftSprache WHERE kEigenschaft ='" & r4("kEigenschaft") & "' AND kSprache='1'", sqlConn)
                Dim rSpracheEigenschaft As SqlDataReader = sqlCommSprachEigenschaft.ExecuteReader()
                '   Dim strSprachen As String = ""
                Dim bFound As Boolean = False
                Dim kEigenschaft As String = ""

                Dim strName As String = ""




                While rSpracheEigenschaft.Read()



                    'msgMaster.Text = i + 1 & " - " & lvwMainData.SelectedItems.Count - 1 & " -> " & lvwMainData.SelectedItems(i).SubItems(1).Text
                    'Application.DoEvents()


                    Dim sqlConn24 As New SqlConnection(strConnectionString)
                    sqlConn24.Open()

                    '# Wert von Eigenschaft auslesen
                    Dim strINSERT24 As String = "SELECT * FROM tEigenschaftSprache WHERE kEigenschaft='" & r4("kEigenschaft") & "' AND kSprache='" & strJTLSprachen_id & "'"
                    Dim sqlComm24 As New SqlCommand(strINSERT24, sqlConn24)
                    Dim r24 As SqlDataReader = sqlComm24.ExecuteReader()

                    'Dim strCName As String = ""

                    bfound2 = False
                    While r24.Read()
                        bfound2 = True
                        '# Übersetzen in die Zielsprache 
                        dblQuellspracheZeichen += rSpracheEigenschaft("cName").ToString.Length

                        strName = frmMain.getTranslateText(rSpracheEigenschaft("cName").ToString, "de", strZielSpracheISO).Replace("&quot;", """")


                        If strName.Length > 0 Then
                            Dim sqlConn2 As New SqlConnection(strConnectionString)
                            sqlConn2.Open()

                            Dim strINSERT24_1 As String = "UPDATE tEigenschaftSprache SET cName='" & strName.Trim & "' WHERE kEigenschaft='" & r4("kEigenschaft") & "' AND kSprache='" & strJTLSprachen_id & "'"
                            Dim sqlComm2 As New SqlCommand(strINSERT24_1, sqlConn2)
                            sqlComm2.ExecuteNonQuery()
                            sqlConn2.Close()
                        End If

                        strCName = r24("cName").ToString

                    End While
                    sqlConn24.Close()

                    If bfound2 = False Then


                        dblQuellspracheZeichen += rSpracheEigenschaft("cName").ToString.Length
                        strName = frmMain.getTranslateText(rSpracheEigenschaft("cName").ToString, "de", strZielSpracheISO).Replace("&quot;", """")

                        Dim sqlConn2 As New SqlConnection(strConnectionString)
                        sqlConn2.Open()
                        ' dblQuellspracheZeichen += rSpracheEigenschaft("cName").ToString.Length
                        strINSERT = "INSERT INTO tEigenschaftSprache(kEigenschaft,kSprache,cName)VALUES("
                        strINSERT &= "'" & r4("kEigenschaft") & "',"
                        strINSERT &= "'" & strJTLSprachen_id & "',"
                        strINSERT &= "'" & strName & "'"
                        strINSERT &= ")"

                        Dim sqlComm2 As New SqlCommand(strINSERT, sqlConn2)
                        sqlComm2.ExecuteNonQuery()
                        sqlConn2.Close()

                    End If
                    'sqlConn.Close()




                    bFound = True

                End While


                sqlConn.Close()




                Dim strQuery As String = "SELECT * FROM teigenschaftwert LEFT JOIN tEigenschaftWertSprache ON  tEigenschaftWertSprache.kEigenschaftWert = teigenschaftwert.kEigenschaftWert WHERE kEigenschaft='" & r4("kEigenschaft") & "' AND tEigenschaftWertSprache.kSprache=1"
                Dim sqlConn25 As New SqlConnection(strConnectionString)
                sqlConn25.Open()

                Dim sqlComm25 As New SqlCommand(strQuery, sqlConn25)
                Dim r25 As SqlDataReader = sqlComm25.ExecuteReader()
                Dim strSprachWert As String = ""
                Dim strKEigenschaftWert As String = ""
                While r25.Read()
                    bFound = True
                    strSprachWert = r25("cName").ToString
                    strKEigenschaftWert = r25("kEigenschaftWert").ToString

                    '# Eintrag vorhanden?
                    Dim strQuery23 As String = "SELECT count(*) as anzahl FROM tEigenschaftWertSprache WHERE kEigenschaftWert='" & strKEigenschaftWert & "' AND kSprache='" & strJTLSprachen_id & "'"
                    Dim sqlConn23 As New SqlConnection(strConnectionString)
                    sqlConn23.Open()

                    Dim sqlComm23 As New SqlCommand(strQuery23, sqlConn23)
                    Dim r23 As SqlDataReader = sqlComm23.ExecuteReader()
                    r23.Read()

                    '# Spracheintrag gefunden -> aber kein Wert -> dann UPDATE 
                    If r23("anzahl") = "0" Then


                        strName = frmMain.getTranslateText(strSprachWert, "de", strZielSpracheISO).Replace("&quot;", """")
                        dblQuellspracheZeichen += strSprachWert.Length

                        If strName.Length > 0 Then

                            Dim sqlConn2 As New SqlConnection(strConnectionString)
                            sqlConn2.Open()

                            strINSERT = "INSERT INTO tEigenschaftWertSprache (kEigenschaftWert,kSprache,cName) VALUES('" & strKEigenschaftWert & "','" & strJTLSprachen_id & "','" & strName.Trim & "')"

                            Dim sqlComm2 As New SqlCommand(strINSERT, sqlConn2)
                            sqlComm2.ExecuteNonQuery()
                            sqlConn2.Close()

                        End If

                    Else


                        dblQuellspracheZeichen += strSprachWert.Length

                        strName = frmMain.getTranslateText(strSprachWert, "de", strZielSpracheISO).Replace("&quot;", """")

                        If strName.Length > 0 Then

                            Dim sqlConn2 As New SqlConnection(strConnectionString)
                            sqlConn2.Open()

                            strINSERT = "UPDATE tEigenschaftWertSprache SET cName='" & strName.Trim & "' WHERE kEigenschaftWert='" & strKEigenschaftWert & "' AND kSprache='" & strJTLSprachen_id & "'"
                            Dim sqlComm2 As New SqlCommand(strINSERT, sqlConn2)
                            sqlComm2.ExecuteNonQuery()
                            sqlConn2.Close()

                        End If


                    End If
                End While

                sqlConn25.Close()

            End While




            sqlConn4.Close()



            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim setSprachEigenSchaftWert_translate", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function getSpracheigenschaften_repair(lvw As ListView) As Boolean
        Try
            Dim strINSERT As String = ""

            'tSpracheUsed
            Dim sqlConn3 As New SqlConnection(strConnectionString)
            sqlConn3.Open()

            '# Alle Sprachen ausgeben
            strINSERT = "SELECT * FROM tSpracheUsed"
            Dim sqlComm3 As New SqlCommand(strINSERT, sqlConn3)
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

            sqlConn3.Close()

            frmMain.ToolStripProgressBar1.Maximum = strJTLSprachen.Length - 1
            frmMain.ToolStripProgressBar1.Value = 0
            frmMain.ToolStripProgressBar1.Minimum = 0
            frmMain.ToolStripProgressBar1.Visible = True

            '  lvw.Items.Clear()
            Dim iGesCount As Integer = 0
            For i = 0 To lvw.Items.Count - 1

                If Not lvw.Items(i).SubItems(1).Text = strJTLSprachen_id.Length - 1 Then

                    '# Alle Sprachen durchgehen
                    For z = 1 To strJTLSprachen.Length - 1
                        ' Alle Spracheigenschaften abrufen
                        Dim sqlConn As New SqlConnection(strConnectionString)
                        sqlConn.Open()
                        Dim sqlComm As New SqlCommand("SELECT * FROM tEigenschaftSprache WHERE kEigenschaft ='" & lvw.Items(i).Text & "' AND kSprache='" & strJTLSprachen_id(z) & "'", sqlConn)
                        Dim r As SqlDataReader = sqlComm.ExecuteReader()
                        '   Dim strSprachen As String = ""
                        Dim bFound As Boolean = False
                        Dim kEigenschaft As String = ""
                        While r.Read()
                            bFound = True

                        End While
                        frmMain.ToolStripProgressBar1.Value = z
                        frmMain.msgMaster.Text = iGesCount & " von " & lvw.Items.Count - 1 * (strJTLSprachen.Length - 2) & " - NEU"
                        Application.DoEvents()

                        If bFound = False Then
                            Dim sqlConn2 As New SqlConnection(strConnectionString)
                            sqlConn2.Open()

                            strINSERT = "INSERT INTO tEigenschaftSprache(kEigenschaft,kSprache)VALUES("
                            strINSERT &= "'" & lvw.Items(i).Text & "',"
                            strINSERT &= "'" & z & "'"
                            strINSERT &= ")"

                            Dim sqlComm2 As New SqlCommand(strINSERT, sqlConn2)
                            sqlComm2.ExecuteNonQuery()
                            sqlConn2.Close()

                        End If
                        sqlConn.Close()
                    Next
                Else
                    '# Alle Sprachen durchgehen

                    ' Alle Spracheigenschaften abrufen
                    Dim sqlConn As New SqlConnection(strConnectionString)
                    sqlConn.Open()
                    Dim sqlComm As New SqlCommand("SELECT * FROM tEigenschaftSprache WHERE kEigenschaft ='" & lvw.Items(i).Text & "' AND kSprache='1'", sqlConn)
                    Dim r As SqlDataReader = sqlComm.ExecuteReader()
                    '   Dim strSprachen As String = ""
                    Dim bFound As Boolean = False
                    Dim kEigenschaft As String = ""
                    Dim strZielSpracheISO As String = ""
                    Dim strName As String = ""




                    While r.Read()
                        ' 2 -5 Sprachen durchgehen
                        For z = 1 To strJTLSprachen.Length - 2

                            strZielSpracheISO = getGoogle2TranslationCode(strJTLSprachen(z))

                            '   frmMain.ToolStripProgressBar1.Value = strJTLSprachen.Length
                            frmMain.msgMaster.Text = iGesCount & " von " & lvw.Items.Count - 1 * (strJTLSprachen.Length - 2) & " - UPDATE"
                            frmMain.ToolStripProgressBar1.Value = z
                            Application.DoEvents()
                            'msgMaster.Text = i + 1 & " - " & lvwMainData.SelectedItems.Count - 1 & " -> " & lvwMainData.SelectedItems(i).SubItems(1).Text
                            'Application.DoEvents()

                            Dim sqlConn4 As New SqlConnection(strConnectionString)
                            sqlConn4.Open()

                            '# Wert von Eigenschaft auslesen
                            strINSERT = "SELECT * FROM tEigenschaftSprache WHERE kEigenschaft='" & lvw.Items(i).Text & "' AND kSprache='" & strJTLSprachen_id(z) & "'"
                            Dim sqlComm4 As New SqlCommand(strINSERT, sqlConn4)
                            Dim r4 As SqlDataReader = sqlComm4.ExecuteReader()

                            Dim strCName As String = ""

                            Dim bfound2 As Boolean = False
                            While r4.Read()
                                bfound2 = True
                                strCName = r4("cName").ToString
                            End While
                            sqlConn4.Close()

                            If bfound2 = False And strCName.Length = 0 Then

                                '# Übersetzen in die Zielsprache 
                                strName = frmMain.getTranslateText(r("cName").ToString, "de", strZielSpracheISO).Replace("&quot;", """")


                                If strName.Length > 0 Then
                                    Dim sqlConn2 As New SqlConnection(strConnectionString)
                                    sqlConn2.Open()

                                    strINSERT = "UPDATE tEigenschaftSprache SET cName='" & strName.Trim & "' WHERE kEigenschaft='" & lvw.Items(i).Text & "' AND kSprache='" & strJTLSprachen_id(z) & "'"
                                    Dim sqlComm2 As New SqlCommand(strINSERT, sqlConn2)
                                    sqlComm2.ExecuteNonQuery()
                                    sqlConn2.Close()
                                End If

                            End If


                        Next

                        bFound = True

                    End While
                    iGesCount += 1

                    sqlConn.Close()


                End If

                '# Welche Sprachen sind vorhanden 
                'Dim strSpracheSplit() As String = strSprachen.Split(",")

            Next

            frmMain.ToolStripProgressBar1.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim ABRUFEN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    Public Function setSpracheigenschaften_translate(lvwItem As ListViewItem, strZielsprache As String, strJTLSprachen_id As String) As Boolean
        Try
            Dim strINSERT As String = ""


            ' Alle Spracheigenschaften abrufen
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlCommSprachEigenschaft As New SqlCommand("SELECT * FROM tEigenschaftSprache WHERE kEigenschaft ='" & lvwItem.SubItems(8).Text & "' AND kSprache='1'", sqlConn)
            Dim rSpracheEigenschaft As SqlDataReader = sqlCommSprachEigenschaft.ExecuteReader()
            '   Dim strSprachen As String = ""
            Dim bFound As Boolean = False
            Dim kEigenschaft As String = ""
            Dim strZielSpracheISO As String = ""
            Dim strName As String = ""




            While rSpracheEigenschaft.Read()
                strZielSpracheISO = getGoogle2TranslationCode(strZielsprache)


                'msgMaster.Text = i + 1 & " - " & lvwMainData.SelectedItems.Count - 1 & " -> " & lvwMainData.SelectedItems(i).SubItems(1).Text
                'Application.DoEvents()


                Dim sqlConn4 As New SqlConnection(strConnectionString)
                sqlConn4.Open()

                '# Wert von Eigenschaft auslesen
                strINSERT = "SELECT * FROM tEigenschaftSprache WHERE kEigenschaft='" & lvwItem.SubItems(8).Text & "' AND kSprache='" & strJTLSprachen_id & "'"
                Dim sqlComm4 As New SqlCommand(strINSERT, sqlConn4)
                Dim r4 As SqlDataReader = sqlComm4.ExecuteReader()

                Dim strCName As String = ""

                Dim bfound2 As Boolean = False
                While r4.Read()
                    bfound2 = True
                    '# Übersetzen in die Zielsprache 
                    dblQuellspracheZeichen += rSpracheEigenschaft("cName").ToString.Length

                    strName = frmMain.getTranslateText(rSpracheEigenschaft("cName").ToString, "de", strZielSpracheISO).Replace("&quot;", """")


                    If strName.Length > 0 Then
                        Dim sqlConn2 As New SqlConnection(strConnectionString)
                        sqlConn2.Open()

                        strINSERT = "UPDATE tEigenschaftSprache SET cName='" & strName.Trim & "' WHERE kEigenschaft='" & lvwItem.SubItems(8).Text & "' AND kSprache='" & strJTLSprachen_id & "'"
                        Dim sqlComm2 As New SqlCommand(strINSERT, sqlConn2)
                        sqlComm2.ExecuteNonQuery()
                        sqlConn2.Close()
                    End If

                    strCName = r4("cName").ToString

                End While
                sqlConn4.Close()

                If bfound2 = False Then
                    Dim sqlConn2 As New SqlConnection(strConnectionString)
                    sqlConn2.Open()
                    ' dblQuellspracheZeichen += rSpracheEigenschaft("cName").ToString.Length
                    strINSERT = "INSERT INTO tEigenschaftSprache(kEigenschaft,kSprache)VALUES("
                    strINSERT &= "'" & lvwItem.SubItems(8).Text & "',"
                    strINSERT &= "'" & strJTLSprachen_id & "'"
                    strINSERT &= ")"

                    Dim sqlComm2 As New SqlCommand(strINSERT, sqlConn2)
                    sqlComm2.ExecuteNonQuery()
                    sqlConn2.Close()

                End If
                'sqlConn.Close()




                bFound = True

            End While


            sqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim ABRUFEN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    Function jtlwawi_artikel_hasEigenschaft(strArtikelID As String) As String
        Try
            Dim strEigenSchaftIDs As String = ""
            ' Alle Spracheigenschaften abrufen
            Dim sqlConn As New SqlConnection(strConnectionString)
            sqlConn.Open()
            Dim sqlComm As New SqlCommand("SELECT * FROM teigenschaft  WHERE kArtikel ='" & strArtikelID & "'", sqlConn)
            Dim r As SqlDataReader = sqlComm.ExecuteReader()


            While r.Read()
                strEigenSchaftIDs = strEigenSchaftIDs & r("kEigenschaft").ToString & ","

            End While
            If strEigenSchaftIDs.Length > 0 Then
                strEigenSchaftIDs = strEigenSchaftIDs.Substring(0, strEigenSchaftIDs.Length - 1)
            End If

            sqlConn.Close()
            Return strEigenSchaftIDs

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim ABRUFEN jtlwawi_artikel_hasEigenschaft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function
End Class
