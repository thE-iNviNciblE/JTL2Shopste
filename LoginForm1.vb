Imports System.Net
Imports System.Text
Imports System.IO

Public Class LoginForm1

    ' TODO: Code zum Durchführen der benutzerdefinierten Authentifizierung mithilfe des angegebenen Benutzernamens und des Kennworts hinzufügen 
    ' (Siehe http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' Der benutzerdefinierte Prinzipal kann anschließend wie folgt an den Prinzipal des aktuellen Threads angefügt werden: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' wobei CustomPrincipal die IPrincipal-Implementierung ist, die für die Durchführung der Authentifizierung verwendet wird. 
    ' Anschließend gibt My.User Identitätsinformationen zurück, die in das CustomPrincipal-Objekt gekapselt sind,
    ' z.B. den Benutzernamen, den Anzeigenamen usw.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim result As String = ""
        Using client As New WebClient

            'Dim reqparm As New Specialized.NameValueCollection
            'reqparm.Add("modus", "api_login_user")
            'reqparm.Add("txtUsername", UsernameTextBox.Text)
            'reqparm.Add("txtPasswort", PasswordTextBox.Text)

            'Dim responsebytes = client.UploadValues("http://shopste.com/api.php", "POST", reqparm)

            '  result = client.UploadString("http://shopste.com/api.php", "modus=api_login_user&txtUsername=" + UsernameTextBox.Text & "&txtPasswort=" + PasswordTextBox.Text)
            ' MessageBox.Show(result)
        End Using

        Dim Request As HttpWebRequest = CType(WebRequest.Create(My.Settings.SHOPSTE_API_URL), HttpWebRequest)
        Request.Method = "POST"
        Request.ContentType = "application/x-www-form-urlencoded"
        Dim Post As String = "modus=api_login_user&txtUsername=" & UsernameTextBox.Text & "&txtPasswort=" & PasswordTextBox.Text
        Dim byteArray() As Byte = Encoding.UTF8.GetBytes(Post)
        Request.ContentLength = byteArray.Length
        Dim DataStream As Stream = Request.GetRequestStream()
        DataStream.Write(byteArray, 0, byteArray.Length)
        DataStream.Close()
        Dim Response As HttpWebResponse = Request.GetResponse()
        DataStream = Response.GetResponseStream()
        Dim reader As New StreamReader(DataStream)
        Dim ServerResponse As String = reader.ReadToEnd()
        reader.Close()
        DataStream.Close()
        Response.Close()

        If InStr(ServerResponse, "LOGIN_OK") Then
            Dim str() As String = ServerResponse.Split("~")
            My.Settings.SHOPSTE_domain_id = str(1)
            My.Settings.SHOPSTE_domainname = str(2)
            My.Settings.SHOPSTE_USERNAME = UsernameTextBox.Text
            My.Settings.SHOPSTE_PASSWORD = PasswordTextBox.Text
            My.Settings.SHOPSTE_main_category = str(3)
            My.Settings.Save()
            reader.Close()
            DataStream.Close()
            Response.Close()

            Me.Close()
        Else
            MessageBox.Show("Login nicht OK")
        End If

    End Sub



    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        UsernameTextBox.Text = My.Settings.SHOPSTE_USERNAME
        PasswordTextBox.Text = My.Settings.SHOPSTE_PASSWORD
    End Sub

    Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UsernameTextBox.TextChanged

    End Sub
End Class
