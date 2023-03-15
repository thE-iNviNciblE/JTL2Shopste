Public Class frmDemoVersionRegistrieren
    Dim bIsLoading As Boolean = True
    Private Sub frmDemoVersionRegistrieren_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        setMainWindowTitle("Demoversion Registrieren", Me)
        txtFirma.Text = My.Settings.anmeldung_firma
        txtVorname.Text = My.Settings.anmeldung_vorname
        txtNachname.Text = My.Settings.anmeldung_nachname
        txtStraße.Text = My.Settings.anmeldung_strasse
        txtPLZ.Text = My.Settings.anmeldung_postleitzahl
        txtStadt.Text = My.Settings.anmeldung_stadt
        txtEmail.Text = My.Settings.anmeldung_email
        txtHandy.Text = My.Settings.anmeldung_handy
        txtTelefon.Text = My.Settings.anmeldung_telefon
        txtLand.Text = My.Settings.anmeldung_land
        bIsLoading = False
    End Sub

    Private Sub btnRegisterJTLBridge_Click(sender As System.Object, e As System.EventArgs) Handles btnRegisterJTLBridge.Click
        If txtEmail.Text.Length = 0 Then
            MessageBox.Show("Bitte geben Sie eine Emailadresse ein!", "Fehler bei der Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmail.Focus()
            Exit Sub
        End If
        If txtFirma.Text.Length = 0 Then
            MessageBox.Show("Bitte geben Sie eine Firma ein!", "Fehler bei der Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirma.Focus()
            Exit Sub
        End If
        If txtVorname.Text.Length = 0 Then
            MessageBox.Show("Bitte geben Sie einen Vornamen ein!", "Fehler bei der Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtVorname.Focus()
            Exit Sub
        End If
        If txtNachname.Text.Length = 0 Then
            MessageBox.Show("Bitte geben Sie einen Nachnamen ein!", "Fehler bei der Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNachname.Focus()
            Exit Sub
        End If
        If txtLand.Text.Length = 0 Then
            MessageBox.Show("Bitte geben Sie ein Land ein!", "Fehler bei der Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLand.Focus()
            Exit Sub
        End If
        If txtStraße.Text.Length = 0 Then
            MessageBox.Show("Bitte geben Sie eine Straße ein!", "Fehler bei der Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtStraße.Focus()
            Exit Sub
        End If
        If txtPLZ.Text.Length = 0 Then
            MessageBox.Show("Bitte geben Sie eine Postleitzahl ein!", "Fehler bei der Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPLZ.Focus()
            Exit Sub
        End If
        If txtStadt.Text.Length = 0 Then
            MessageBox.Show("Bitte geben Sie eine Stadt ein!", "Fehler bei der Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtStadt.Focus()
            Exit Sub
        End If
        If txtTelefon.Text.Length = 0 Then
            MessageBox.Show("Bitte geben Sie eine Telefonnummer ein!", "Fehler bei der Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTelefon.Focus()
            Exit Sub
        End If

        Dim strServerInfo() As String = getHTTPResponseMessage("https://api.bludau-media.de//SafeSandy/SendRegister.php?key=" & gbl_KeyCode & "&firma=" & txtFirma.Text & "&vorname=" & txtVorname.Text & "&nachname=" & txtNachname.Text & "&strasse=" & txtStraße.Text & "&plz=" & txtPLZ.Text & "&stadt=" & txtStadt.Text & "&land=" & txtLand.Text & "&email=" & txtEmail.Text & "&telefon=" & txtTelefon.Text & "&handy=" & txtHandy.Text & "&versionsnummer=" & strVersionsNummer, mgetUpdaterMessage.sendAuthCode, True)

        MessageBox.Show("JTL2Shopste wurde erfolgreich registriert!" & vbCrLf & vbCrLf & "Sie können das Programm jetzt weiter benutzen!", "JTL2Shopste Registration", MessageBoxButtons.OK, MessageBoxIcon.Information)
        bRegistered = True
        Me.Close()
    End Sub

    Private Sub txtFirma_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFirma.TextChanged
        If bIsLoading = False Then
            My.Settings.anmeldung_firma = txtFirma.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub txtVorname_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVorname.TextChanged
        If bIsLoading = False Then
            My.Settings.anmeldung_vorname = txtVorname.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub txtNachname_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNachname.TextChanged
        If bIsLoading = False Then
            My.Settings.anmeldung_nachname = txtNachname.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub txtStraße_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtStraße.TextChanged
        If bIsLoading = False Then
            My.Settings.anmeldung_strasse = txtStraße.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub txtPLZ_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPLZ.TextChanged
        If bIsLoading = False Then
            My.Settings.anmeldung_postleitzahl = txtPLZ.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub txtStadt_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtStadt.TextChanged
        If bIsLoading = False Then
            My.Settings.anmeldung_stadt = txtStadt.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub txtEmail_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEmail.TextChanged
        If bIsLoading = False Then
            My.Settings.anmeldung_email = txtEmail.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTelefon.TextChanged
        If bIsLoading = False Then
            My.Settings.anmeldung_telefon = txtTelefon.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub txtHandy_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHandy.TextChanged
        If bIsLoading = False Then
            My.Settings.anmeldung_handy = txtHandy.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub txtLand_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLand.TextChanged
        If bIsLoading = False Then
            My.Settings.anmeldung_land = txtLand.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub btnAbbrechen_Click(sender As System.Object, e As System.EventArgs) Handles btnAbbrechen.Click
        Me.Close()
    End Sub
End Class