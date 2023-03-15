Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Net
Imports System.Net.NetworkInformation

Module modKopierschutz
    Public Enum mgetUpdaterMessage
        getNewVersion = 0
        sendAuthCode = 1
        getAuthCode = 2
        getIstBuyed = 3
        getProgramUpdateCheck = 4
        getHTML2Text = 5
        getÜbersetzungGesammtSumme = 6
        getEiSo2ShopsteKat = 7
        setShopsteCategories = 8
        getShopsteCategory = 9
        getShopsteShopCategory = 10
        getShopsteArtikel = 11
        getShopsteArtikel_save = 12
        setShopItem_eigenschaft_artibuteset = 13
        setShopItem_eigenschaft_name = 14
        setShopItem_eigenschaft_value = 15
        setShopItem_eigenschaftwert = 16
        shop_item_eigenschaft = 17
    End Enum
    Public WithEvents clsUpdateDownloader As WebFileDownloader
    Public gbl_KeyCode As String
    Public strServerInfo() As String
    Public bExitProgramm As Boolean = False
    Public bRegistered As Boolean = False
    Public strVersionsNummer As String = "1.0.0 BETA"
    Public pgrUpdater_global As ProgressBar

    '# WMI MAC 
    Public Function getWMI_CPU() As String
        Dim strCPU As String = ""
        Dim objWMIService As Object
        Dim colItems As Object
        Dim objItem As Object
        Dim strComputer As String = "."

        Try

            objWMIService = GetObject("winmgmts:\\" & strComputer & "\root\cimv2")
            colItems = objWMIService.ExecQuery("SELECT * FROM Win32_Processor")

            For Each objItem In colItems
                Application.DoEvents()
                'lstServerMessage.Items.Add("-- HDD INFO --")
                'lstServerMessage.Items.Add("Prozessor ID:" & objItem.ProcessorId)
                strCPU = objItem.ProcessorId
                'lstServerMessage.Items.Add("Geschwindigkeit:" & objItem.MaxClockSpeed & " Mhz")
                'lstServerMessage.Items.Add("BUS-System:" & objItem.DataWidth & " Bit")
                'lstServerMessage.Items.Add("Datum:" & objItem.InstallDate)
                'lstServerMessage.Items.Add("-- ENDE --")
                'lstServerMessage.Items.Add("")
            Next

            Return strCPU
        Catch ex As Exception
            Return "-1"
        End Try
    End Function

    '#  WMI HDD Serial 
    Public Function getWMI_HDD_Serial() As String
        Dim strHDD As String = ""
        Dim colDisks As Object
        Dim objDisk As Object

        Try
            colDisks = GetObject(
               "Winmgmts:").ExecQuery("SELECT * FROM Win32_LogicalDisk")

            For Each objDisk In colDisks
                Application.DoEvents()
                Select Case objDisk.DriveType

                    Case 3
                        'lstServerMessage.Items.Add("-- HDD INFO --")
                        'lstServerMessage.Items.Add("Bezeichnung: " & objDisk.Caption & " - " & objDisk.VolumeName & " - Typ: Festplatte")
                        'lstServerMessage.Items.Add("Seriennummer: " & objDisk.VolumeSerialNumber)
                        'lstServerMessage.Items.Add("Dateisystem: " & objDisk.FileSystem)
                        'lstServerMessage.Items.Add("-- ENDE --")
                        'lstServerMessage.Items.Add("")
                        strHDD = objDisk.VolumeSerialNumber
                        Exit For
                End Select
            Next

            Return strHDD
        Catch ex As Exception

            Return "-1"
        End Try
    End Function
    Public Function getMacAddress() As String
        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim adapter As NetworkInterface
            Dim myMac As String = String.Empty

            For Each adapter In adapters
                Select Case adapter.NetworkInterfaceType
                    'Exclude Tunnels, Loopbacks and PPP
                    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            myMac = adapter.GetPhysicalAddress.ToString
                            Exit For ' Got a mac so exit for
                        End If

                End Select
            Next adapter

            Return myMac
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    '######################################################
    '# >> Schlüssel berechnen 
    '######################################################
    Public Function getWMI_KeyCode() As String
        Dim strHDD As String = ""
        Dim strCPU As String = ""
        Dim strKeyCode As String = ""
        Try

            strHDD = getWMI_HDD_Serial()
            If strHDD = "-1" Or strHDD = "" Then
                MsgBox("Fehler beim Empfangen der HDD Serial", MsgBoxStyle.Critical)
                Exit Function
            End If

            Dim strMAC As String = getMacAddress() & "AAAA"

            strKeyCode = Encrypt(strHDD & strMAC)

            strKeyCode = strKeyCode.Replace("+", "")
            strKeyCode = strKeyCode.Replace("=", "")
            'strKeyCode = strKeyCode.Substring(0, 7)

            Return strKeyCode
        Catch ex As Exception
            MessageBox.Show("Kann WMI Daten für Schlüsselgenerierung nicht erzeugen!", "getWMI_KeyCode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function


    '#################################################################################################
    '# >> UPDATER: Nachricht abgreifen 
    '#################################################################################################
    Public Function getHTTPResponseMessage(ByVal strURL As String, ByVal mModus As mgetUpdaterMessage, ByVal bMessage As Boolean) As String()
        Dim strData As String = ""
        Try


            '# Request erzeugen 
            'MsgBox(strURL)

            Dim request As WebRequest = WebRequest.Create(strURL)

            '# Server - Login 
            request.Credentials = CredentialCache.DefaultCredentials

            '# Server - Antwort 
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            '# Status anzeigen 
            Console.WriteLine(response.StatusDescription)

            '# Hole den Stream 
            Dim dataStream As Stream = response.GetResponseStream()

            '# Benutzerstream Reader zum einlesen 
            Dim reader As New StreamReader(dataStream)

            '# Alles einlesen 
            Dim responseFromServer As String = reader.ReadToEnd()


            strServerInfo = responseFromServer.Split("<br/>")




            '# Welcher Modus 
            Select Case mModus
                Case mgetUpdaterMessage.getShopsteShopCategory

                    My.Computer.FileSystem.WriteAllText("shopste-subshop.dat", responseFromServer, False)

                Case mgetUpdaterMessage.getShopsteCategory
                    My.Computer.FileSystem.WriteAllText("shopste-category.dat", responseFromServer, False)


                Case mgetUpdaterMessage.getShopsteArtikel
                    My.Computer.FileSystem.WriteAllText("shopste-itemlist.dat", responseFromServer, False)
                Case mgetUpdaterMessage.getShopsteArtikel_save
                    Return strServerInfo
                Case mgetUpdaterMessage.setShopItem_eigenschaft_artibuteset
                    Return strServerInfo
                Case mgetUpdaterMessage.setShopItem_eigenschaft_name
                    Return strServerInfo
                Case mgetUpdaterMessage.setShopItem_eigenschaft_value
                    Return strServerInfo

                Case mgetUpdaterMessage.getNewVersion

                    If strServerInfo.Length >= 2 Then
                        strServerInfo(1) = strServerInfo(1).Replace("br>", "")
                        strServerInfo(1) = strServerInfo(1).Replace("URL:", "")
                    End If

                    If strServerInfo.Length >= 3 Then
                        strServerInfo(2) = strServerInfo(2).Replace("br>", "")
                        strServerInfo(2) = strServerInfo(2).Replace("ZEITPUNKT:", "")
                    End If

                    If strServerInfo.Length >= 4 Then
                        strServerInfo(3) = strServerInfo(3).Replace("br>", "")
                        strServerInfo(3) = strServerInfo(3).Replace("VERSION:", "")
                    End If

                    If strServerInfo.Length >= 5 Then
                        strServerInfo(4) = strServerInfo(4).Replace("br>", "")
                        strServerInfo(4) = strServerInfo(4).Replace("COMMENT:", "")
                    End If

                    If strServerInfo.Length > 0 Then

                        Select Case strServerInfo(0)
                            Case "NEUSTE_VERSION_VORHANDEN"
                                'clsUpdateDownloader.chkUpdateModus = WebFileDownloader.chkModus.ok
                                frmMain.msgMaster.Text = "Neuste Version vorhanden: " & Date.Now

                                Exit Function
                            Case "FEHLER:Kein_Versionsstring"
                                'clsUpdateDownloader.chkUpdateModus = WebFileDownloader.chkModus.fehler
                                frmMain.msgMaster.Text = "Fehler kein Versionsstring gefunden, bitte manuell von http://www.cubss.net herunterladen.."

                                Exit Function
                            Case "DOWNLOAD_NOW"
                                'clsUpdateDownloader.chkUpdateModus = WebFileDownloader.chkModus.update
                                frmMain.msgMaster.Text = "Neues Update vom " & strServerInfo(2) & " | Version: " & strServerInfo(3) & " : " & Date.Now

                        End Select

                    End If
                Case mgetUpdaterMessage.getEiSo2ShopsteKat
                    strHTTPDataStore = strServerInfo(0).ToString
                Case mgetUpdaterMessage.sendAuthCode
                    Return strServerInfo
                '############################################################
                '# ABRUFEN DES AUTHCODES + DEMOENDE DATUM 
                '############################################################
                Case mgetUpdaterMessage.getAuthCode

                    Return strServerInfo


                Case mgetUpdaterMessage.getIstBuyed
                    Return strServerInfo
                Case mgetUpdaterMessage.getProgramUpdateCheck
                    Return strServerInfo
                Case mgetUpdaterMessage.getHTML2Text
                    Return strServerInfo
                Case mgetUpdaterMessage.getÜbersetzungGesammtSumme
                    Return strServerInfo
                Case mgetUpdaterMessage.getEiSo2ShopsteKat
                    Return strServerInfo
                Case mgetUpdaterMessage.setShopsteCategories

                    strHTTPDataStore = strServerInfo(0).ToString
                    If strServerInfo.Length - 1 > 0 Then
                        MessageBox.Show(strServerInfo(0).ToString)
                    End If

            End Select


            '# Alle Resourcen schließen 
            reader.Close()
            dataStream.Close()
            response.Close()
            Return strServerInfo
        Catch ex As Exception
            MessageBox.Show("Fehler bei " & ex.Message, "getHTTPResponseMessage", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Function

    Public Function getDateTimeVar(strmySQLDatum As String) As DateTime
        Try
            Dim strDatumSplit() As String = strmySQLDatum.Split(" ")
            Dim strDatumReal() As String = strDatumSplit(0).Split("-")

            Return strDatumReal(2) & "." & strDatumReal(1) & "." & strDatumReal(0) & " " & strDatumSplit(1)
        Catch ex As Exception

        End Try
    End Function

    '#######################################################################################################################################################
    '# UPDATER 
    '#######################################################################################################################################################

    '#################################################################################################
    '# >> UPDATER: Programm Updates durch Server Verteilen 
    '#################################################################################################
    Public Function setUpdateCheck(ByVal pgrUpdate As ProgressBar, ByVal lblUpdater As Label) As Boolean

        Dim strMessage As String
        Dim iAPPID As Integer = 2  ' YABE UPDATE ID 

        'PRÜFEN ob Datei existiert
        If Not IO.Directory.Exists(Application.StartupPath & "\Updater\") Then
            ' MessageBox.Show("Kein gültiges Verzeichnis", "Fehler beim Aktualisieren", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Return
        End If

        pgrUpdater_global = pgrUpdate
        strMessage = "https://api.bludau-media.de//SafeSandy/Download.php?version=" & strVersionsNummer & "&name=JTL%20Translator&key=" & gbl_KeyCode & "&programID=11&versionsnummer=" & strVersionsNummer
        'strMessage = "https://api.bludau-media.de//software-download.php?programID=3&name=JTL%20Newsletter"

        Dim strServerInfo() As String = getHTTPResponseMessage(strMessage, mgetUpdaterMessage.getNewVersion, True)

        'Download starten 
        Try
            pgrUpdate.Visible = True
            lblUpdater.Visible = True

            clsUpdateDownloader = New WebFileDownloader
            'txtDownloadTo.Text.TrimEnd("\"c) 
            Application.DoEvents()
            clsUpdateDownloader.DownloadFileWithProgress(strServerInfo(1).ToString.Replace("br/>URL=", ""), Application.StartupPath & "\Updater\" & GetFileNameFromURL(strServerInfo(1).ToString.Replace("br/>URL=", "")))
            pgrUpdate.Visible = False
            lblUpdater.Visible = False

            Return True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            Return False
        End Try



    End Function
    '#################################################################################################
    '# >> UPDATER: Dateigröße 
    '#################################################################################################
    Public Sub _Downloader_FileDownloadSizeObtained(ByVal iFileSize As Long) Handles clsUpdateDownloader.FileDownloadSizeObtained
        pgrUpdater_global.Value = 0
        pgrUpdater_global.Maximum = Convert.ToInt32(iFileSize)
    End Sub
    Public Function setBR(ByVal strData As String) As String
        Try

            strData = vbCrLf & strData.Replace("|br|", vbCrLf)
        Catch ex As Exception
            'Call debug_message(ex, strQuery & vbCrLf & "setBR")
            Return "-1"
        End Try

        Return strData
    End Function
    '#################################################################################################
    '# >> UPDATER: Wieviel wurder heruntergeladen 
    '#################################################################################################
    Private Sub _Downloader_AmountDownloadedChanged(ByVal iNewProgress As Long) Handles clsUpdateDownloader.AmountDownloadedChanged
        pgrUpdater_global.Value = Convert.ToInt32(iNewProgress)
        'lblUpdater.Text = WebFileDownloader.FormatFileSize(iNewProgress) & " von " & WebFileDownloader.FormatFileSize(pgrUpdater_global.Maximum) & " downloaded"
        Application.DoEvents()
    End Sub

    '#################################################################################################
    '# >> UPDATER: Download beendet 
    '#################################################################################################
    Public Sub _Downloader_FileDownloadComplete() Handles clsUpdateDownloader.FileDownloadComplete
        Dim strMessage As String

        Try
            pgrUpdater_global.Value = pgrUpdater_global.Maximum
            Application.DoEvents()
            strMessage = setBR(strServerInfo(4))
        Catch ex As Exception

        End Try


        Dim ExterneAnwendung As New System.Diagnostics.Process()
        Dim strFile As String = Application.StartupPath & "\Updater" & GetFileNameFromURL(strServerInfo(1))
        ExterneAnwendung.StartInfo.FileName = strFile
        ExterneAnwendung.Start()
        Application.Exit()



    End Sub

    '#####################################################################
    '# Ausgeben des Namens von einer URL 
    '#####################################################################
    Public Function GetFileNameFromURL(ByVal URL As String) As String
        If URL.IndexOf("/"c) = -1 Then Return String.Empty

        Return "\" & URL.Substring(URL.LastIndexOf("/"c) + 1)
    End Function

    '##############################################################
    '# >> Encrypt
    '# Verschlüsseln von DATEN 
    '##############################################################
    Public Function Encrypt(ByVal plainText As String) As String
        ' Declare a UTF8Encoding object so we may use the GetByte
        ' method to transform the plainText into a Byte array.
        Dim utf8encoder As UTF8Encoding = New UTF8Encoding()
        Dim bytValue() As Byte
        Dim gstrHash As String
        Dim inputInBytes() As Byte = utf8encoder.GetBytes(plainText & "JTL2Shopste")

        ' Create a new TripleDES service provider
        Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

        ' The ICryptTransform interface uses the TripleDES
        ' crypt provider along with encryption key and init vector
        ' information
        bytValue = System.Text.Encoding.UTF8.GetBytes(plainText)
        Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateEncryptor(bytValue, bytValue)

        ' All cryptographic functions need a stream to output the
        ' encrypted information. Here we declare a memory stream
        ' for this purpose.
        Dim encryptedStream As MemoryStream = New MemoryStream()
        Dim cryptStream As CryptoStream = New CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write)

        ' Write the encrypted information to the stream. Flush the information
        ' when done to ensure everything is out of the buffer.
        cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
        cryptStream.FlushFinalBlock()
        encryptedStream.Position = 0

        ' Read the stream back into a Byte array and return it to the calling
        ' method.
        Dim result(encryptedStream.Length - 1) As Byte
        encryptedStream.Read(result, 0, encryptedStream.Length)
        cryptStream.Close()

        gstrHash = Convert.ToBase64String(result)
        Return gstrHash
    End Function
End Module
