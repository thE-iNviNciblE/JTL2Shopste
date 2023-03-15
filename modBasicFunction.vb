Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net

Module modBasicFunction
    Private iAnzahlMandantenSettings As Integer = 10
    Public bAbbruch As Boolean = False
    Public txtShopURL As String = "" 'My.Settings.shop_abmelden_url(My.Settings.mandant_position)
    Public gbl_tor_pid As Integer = 0
    Public gbl_privoxy_pid As Integer = 0
    Public strHTTPDataStore As String = ""
    Public col As Integer = 0
    '###################################################################
    '# >> Fenstertitel anzeigen 
    '###################################################################
    Public Function setMainWindowTitle(ByVal strFormularName As String, ByVal frmForm As Form) As Boolean
        Try
            If strFormularName.Length > 0 Then
                frmForm.Text = "JTL2Shopste - " & strFormularName & " - Mandant: " & My.Settings.mandant_letzter_name & " v." & strVersionsNummer
            Else
                frmForm.Text = "JTL2Shopste - Mandant: " & My.Settings.mandant_letzter_name & " v." & strVersionsNummer
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show("Fehler: " & ex.Message, "setMainWindowTitle", MessageBoxButtons.OK)
            Return False
        End Try
    End Function
    Function TorStarup() As Boolean
        Dim p = New Process()
        Dim bStarted As Boolean = False
        p.StartInfo.FileName = Application.StartupPath & "\Tor\tor.exe"
        p.StartInfo.Arguments = " -f .\torrc-defaults -controlport 9051 -hashedcontrolpassword 16:6C5A0892C58419E160285695991BEDD067449F845E14735A6FBAB0829B"
        p.StartInfo.WorkingDirectory = Application.StartupPath & "\Tor\"
        bStarted = p.Start()
        Try
            gbl_tor_pid = p.Id
            bStarted = True
        Catch ex As Exception
            bStarted = False
        End Try
        Return bStarted
    End Function

    Function PrivoxyStarup() As Boolean
        Dim p = New Process()
        Dim bStarted As Boolean = False
        p.StartInfo.FileName = Application.StartupPath & "\Privoxy\privoxyStart.bat"
        p.StartInfo.WorkingDirectory = Application.StartupPath & "\Privoxy\"
        ' p.StartInfo.Arguments = " config.txt"
        bStarted = p.Start()
        Try
            gbl_privoxy_pid = p.Id
            bStarted = True
        Catch ex As Exception
            bStarted = False
        End Try
        Return bStarted
    End Function
    Function setKillbyPID(pid As Integer) As Boolean
        Try
            Dim aProcess As System.Diagnostics.Process
            aProcess = System.Diagnostics.Process.GetProcessById(pid)
            aProcess.Kill()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function
    '#######################################################
    '# Prozess suchen
    '#######################################################
    Function getProzessIDbySearch(strProzessName As String) As Integer

        Dim arrProcList() As Process
        Dim STATUS As Integer
        STATUS = 0
        arrProcList = Process.GetProcesses
        Dim PID As Integer = 0
        For i As Integer = 0 To arrProcList.Length - 1
            If STATUS = 0 Then
                If arrProcList(i).ProcessName = strProzessName Then
                    STATUS = 1
                    PID = arrProcList(i).Id
                End If
            Else
                'lblRunning.Text = "Running!"
                'lblRunning.ForeColor = Color.Red
            End If
        Next

        If STATUS = 1 Then
            Return PID
        Else
            If STATUS = 0 Then
                Return -1
            End If
        End If

    End Function
    Public Function setGUIModus() As Boolean

        If My.Settings.chkTranslate_funktionsattribute_only = True Then

            'frmMain.btnArtikelTranslate.Visible = False
            If My.Settings.chkTranslate_funktionsattribute_alleSprachen = True Then
                frmMain.btnÜbertrage.Text = "Alle Funktionsattribute übersetzen"
            Else
                frmMain.btnÜbertrage.Text = "Funktionsattribute übersetzen"
            End If

            Dim sSize As New Size
            sSize.Width = 300
            sSize.Height = 25
            frmMain.btnÜbertrage.Size = sSize
        Else

            If My.Settings.chkTranslate_normal_alleSprachen = True Then
                'frmMain.btnArtikelTranslate.Text = "In alle Sprachen übersetzen"
                Dim sSize2 As New Size
                sSize2.Width = 300
                sSize2.Height = 25
                'frmMain.btnArtikelTranslate.Size = sSize2
            Else
                'frmMain.btnArtikelTranslate.Text = "Artikel übersetzen"
                Dim sSize2 As New Size
                sSize2.Width = 193
                sSize2.Height = 25
                '  frmMain.btnArtikelTranslate.Size = sSize2
            End If

            ' frmMain.btnArtikelTranslate.Visible = True
            'frmMain.btnÜbertrage.Text = "Fehlende Übersetzungen"
            Dim sSize As New Size
            sSize.Width = 193
            sSize.Height = 25
            frmMain.btnÜbertrage.Size = sSize
        End If

    End Function
End Module
