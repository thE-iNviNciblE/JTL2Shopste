Imports System.Net
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

Public Class frmShopsteCategory
    Public strKategorieJTLShop As String = ""

    Private Sub frmShopsteCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dtSubShopCat As DataTable = FillTestTableSubShopCat()
        CreateTree(0, dtSubShopCat)
        TreeView1.CollapseAll()
        Dim dtshopsteCat As DataTable = FillTestTableShopsteCat()
        CreateTreeShopste(0, dtshopsteCat)
        TreeView2.CollapseAll()
        'Call getHTTPResponseMessage("http://shopste.com/api.php?modus=get_shopste_category&domain_id=" & My.Settings.domain_id, mgetUpdaterMessage.getShopsteShopCategory, True)

        'TreeView1.Nodes.Clear()
        '' TreeView1 = tvShopste
        'Dim treenode As TreeNode
        'Dim strContent As String = My.Computer.FileSystem.ReadAllText("shopste-subshop.dat")
        'Dim i As Integer = 0

        'If strContent.Length > 0 Then



        '    'Dim strLine() As String = strContent.Split("<br>")

        '    ''Creating the root node
        '    ''Dim root = New TreeNode("Shopste Kategorien")

        '    ''  frmShopsteKategorieMapping.tvShopste()
        '    '' TreeView1.Nodes.Add(root)
        '    'Dim itmp As Integer = 0
        '    'For i = 0 To strLine.Length - 2
        '    '    Dim strData() As String = strLine(i).Split("|")
        '    '    ' If i = 93 Then
        '    '    '      Stop
        '    '    'End If
        '    '    treenode = New TreeNode(strData(3))
        '    '    treenode.Tag = strData(0).Replace("br>", "")

        '    '    Select Case strData(2)
        '    '        Case "0"
        '    '            'Creating the root node
        '    '            'Dim root = treenode

        '    '            '  frmShopsteKategorieMapping.tvShopste()
        '    '            TreeView1.Nodes.Add(treenode)
        '    '        Case "1"

        '    '            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes.Add(treenode)
        '    '        Case "2"
        '    '            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(treenode)
        '    '    End Select


        '    '    'Creating child nodes under the first child
        '    '    'For loopindex As Integer = 1 To 4
        '    '    'TreeView1.Nodes(0).Nodes(0).Nodes.Add(New  _
        '    '    '    TreeNode("Sub Project" & Str(loopindex)))
        '    '    'Next loopindex
        '    '    ' creating child nodes under the root
        '    '    'TreeView1.Nodes(0).Nodes.Add(New TreeNode("Project 6"))
        '    '    'creating child nodes under the created child node
        '    '    'For loopindex As Integer = 1 To 3
        '    '    'TreeView1.Nodes(0).Nodes(1).Nodes.Add(New  _
        '    '    '   TreeNode("Project File" & Str(loopindex)))
        '    '    'Next loopindex

        '    'Next

        'End If

        'Call getHTTPResponseMessage("http://shopste.com/api.php?modus=get_shopste_category&domain_id=1", mgetUpdaterMessage.getShopsteCategory, True)
        ''Dim treenode As TreeNode
        'strContent = My.Computer.FileSystem.ReadAllText("shopste-category.dat")
        'i = 0

        'If strContent.Length > 0 Then

        '    Dim strLine() As String = strContent.Split("<br>")

        '    'Creating the root node
        '    'Dim root = New TreeNode("Shopste Kategorien")

        '    '  frmShopsteKategorieMapping.tvShopste()
        '    ' TreeView1.Nodes.Add(root)
        '    Dim itmp As Integer = 0
        '    For i = 0 To strLine.Length - 2
        '        Dim strData() As String = strLine(i).Split("|")
        '        ' If i = 93 Then
        '        '      Stop
        '        'End If
        '        TreeNode = New TreeNode(strData(3))
        '        TreeNode.Tag = strData(0).Replace("br>", "")

        '        Select Case strData(2)
        '            Case "0"
        '                'Creating the root node
        '                'Dim root = treenode

        '                '  frmShopsteKategorieMapping.tvShopste()
        '                TreeView2.Nodes.Add(TreeNode)
        '            Case "1"

        '                TreeView2.Nodes(TreeView2.Nodes.Count - 1).Nodes.Add(TreeNode)
        '            Case "2"
        '                TreeView2.Nodes(TreeView2.Nodes.Count - 1).Nodes(TreeView2.Nodes(TreeView1.Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(TreeNode)
        '        End Select


        '        'Creating child nodes under the first child
        '        'For loopindex As Integer = 1 To 4
        '        'TreeView1.Nodes(0).Nodes(0).Nodes.Add(New  _
        '        '    TreeNode("Sub Project" & Str(loopindex)))
        '        'Next loopindex
        '        ' creating child nodes under the root
        '        'TreeView1.Nodes(0).Nodes.Add(New TreeNode("Project 6"))
        '        'creating child nodes under the created child node
        '        'For loopindex As Integer = 1 To 3
        '        'TreeView1.Nodes(0).Nodes(1).Nodes.Add(New  _
        '        '   TreeNode("Project File" & Str(loopindex)))
        '        'Next loopindex

        '    Next

        'End If
    End Sub

    Private Sub CreateTree(parent As Integer, dt As DataTable)

        '        Dim MaxLevel1 As Integer = CInt(DataTable1.Compute("MAX(LEVEL)", ""))

        Dim j As Integer

        Try

            Dim Rows1() As DataRow = dt.Select("PARENT2 = '" & parent & "'")

            Dim treen As New TreeNode
            For j = 0 To Rows1.Length - 1
                Dim ID1 As String = Rows1(j).Item("ID").ToString
                Dim Name1 As String = Rows1(j).Item("NAME").ToString
                Dim Parent1 As String = Rows1(j).Item("PARENT2").ToString
                Dim level As Integer = Rows1(j).Item("Level").ToString

                If level = 1 Then
                    'TreeView1.Nodes.Add(ID1, Name1)
                    'treen.Tag = ID1
                    'treen.Text = Name1

                    TreeView1.Nodes.Add(ID1, Name1)

                    CreateTree(Rows1(j).Item("ID").ToString, dt)
                Else

                    Dim TreeNodes1() As TreeNode = TreeView1.Nodes.Find(Parent1, True)

                    If TreeNodes1.Length > 0 Then
                        TreeNodes1(0).Nodes.Add(ID1, Name1)
                        '  Node1.ChildNodes.Add(New TreeNode(Name1, ID1))

                    End If
                    CreateTree(Rows1(j).Item("ID").ToString, dt)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '   
    End Sub

    Private Sub CreateTreeShopste(parent As Integer, dt As DataTable)

        '        Dim MaxLevel1 As Integer = CInt(DataTable1.Compute("MAX(LEVEL)", ""))

        Dim j As Integer

        Try

            Dim Rows1() As DataRow = dt.Select("PARENT2 = '" & parent & "'")

            Dim treen As New TreeNode
            For j = 0 To Rows1.Length - 1
                Dim ID1 As String = Rows1(j).Item("ID").ToString
                Dim Name1 As String = Rows1(j).Item("NAME").ToString
                Dim Parent1 As String = Rows1(j).Item("PARENT2").ToString
                Dim level As Integer = Rows1(j).Item("Level").ToString

                If level = 1 Then
                    'TreeView1.Nodes.Add(ID1, Name1)
                    'treen.Tag = ID1
                    'treen.Text = Name1

                    TreeView2.Nodes.Add(ID1, Name1)

                    CreateTreeShopste(Rows1(j).Item("ID").ToString, dt)
                Else

                    Dim TreeNodes1() As TreeNode = TreeView2.Nodes.Find(Parent1, True)

                    If TreeNodes1.Length > 0 Then
                        TreeNodes1(0).Nodes.Add(ID1, Name1)
                        '  Node1.ChildNodes.Add(New TreeNode(Name1, ID1))

                    End If
                    CreateTreeShopste(Rows1(j).Item("ID").ToString, dt)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '   
    End Sub
    Private Function FillTestTableShopsteCat() As DataTable

        Dim DataTable1 As New DataTable

        DataTable1.Columns.Add("ID", GetType(Integer))
        DataTable1.Columns.Add("NAME", GetType(String))
        DataTable1.Columns.Add("PARENT2", GetType(Integer))
        DataTable1.Columns.Add("LEVEL", GetType(Integer))

        Call getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=get_shopste_category&domain_id=1" & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD, mgetUpdaterMessage.getShopsteCategory, True)

        TreeView2.Nodes.Clear()
        ' TreeView1 = tvShopste
        Dim treenode As New TreeNode
        Dim strContent As String = My.Computer.FileSystem.ReadAllText("shopste-category.dat")
        Dim i As Integer = 0
        Try


            If strContent.Length > 0 Then

                Dim strLine() As String = strContent.Split("<br>")


                For i = 0 To strLine.Length - 2
                    Dim strData() As String = strLine(i).Split("|")

                    '  If strData(4) = 0 Then
                    '      strData(4) = ""
                    '  End If

                    DataTable1.Rows.Add(strData(0).Replace("br>", ""), strData(3), strData(4), strData(2))
                Next i
            End If
            'DataTable1.Rows.Add(1, "Patrick")


            'Dim i As Integer

            'For i = 0 To DataTable1.Rows.Count - 1
            '    Dim ID1 As String = DataTable1.Rows(i).Item("ID").ToString
            '    DataTable1.Rows(i).Item("LEVEL") = FindLevel(ID1, 0)
            'Next
            Return DataTable1
        Catch ex As Exception
            MessageBox.Show("Fehler:" + ex.Message)

        End Try
    End Function

    Private Function FillTestTableSubShopCat() As DataTable

        Dim DataTable1 As New DataTable

        DataTable1.Columns.Add("ID", GetType(Integer))
        DataTable1.Columns.Add("NAME", GetType(String))
        DataTable1.Columns.Add("PARENT2", GetType(Integer))
        DataTable1.Columns.Add("LEVEL", GetType(Integer))



        Call getHTTPResponseMessage(My.Settings.SHOPSTE_API_URL & "?modus=get_shopste_category&domain_id=" & My.Settings.SHOPSTE_domain_id & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD, mgetUpdaterMessage.getShopsteCategory, True)

        TreeView1.Nodes.Clear()
        ' TreeView1 = tvShopste
        Dim treenode As New TreeNode
        Dim strContent As String = My.Computer.FileSystem.ReadAllText("shopste-category.dat")
        Dim i As Integer = 0
        Try


            If strContent.Length > 0 Then

                Dim strLine() As String = strContent.Split("<br>")


                For i = 0 To strLine.Length - 2
                    Dim strData() As String = strLine(i).Split("|")

                    '  If strData(4) = 0 Then
                    '      strData(4) = ""
                    '  End If

                    DataTable1.Rows.Add(strData(0).Replace("br>", ""), strData(3), strData(4), strData(2))
                Next i
            End If
            'DataTable1.Rows.Add(1, "Patrick")


            'Dim i As Integer

            'For i = 0 To DataTable1.Rows.Count - 1
            '    Dim ID1 As String = DataTable1.Rows(i).Item("ID").ToString
            '    DataTable1.Rows(i).Item("LEVEL") = FindLevel(ID1, 0)
            'Next
            Return DataTable1
        Catch ex As Exception
            MessageBox.Show("Fehler:" + ex.Message)
        End Try
    End Function
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Label1.Text = e.Node.Name
        ' strShopSubCat = e.Node.Name
    End Sub

    Private Sub TreeView2_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView2.AfterSelect

    End Sub

    Private Sub TreeView2_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView2.NodeMouseClick
        Label2.Text = e.Node.Name
        ' frmShopsteImporter.strShopsteCat = e.Node.Name
    End Sub

    Private Sub btnKategorieZuordnen_Click(sender As Object, e As EventArgs) Handles btnKategorieZuordnen.Click
        'frmShopsteImporter.bZuordnen = True
        'strKategorieJTLShop
        If frmMain.clsDB.chkJTLShopCat2Shopste(strKategorieJTLShop) = 0 Then
            frmMain.clsDB.setINSERT_KategorieJTL2Shopste(strKategorieJTLShop, Label2.Text)
        Else
            frmMain.clsDB.setUPDATE_KategorieJTL2Shopste(strKategorieJTLShop, Label2.Text)
        End If
        Me.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' frmShopsteImporter.bZuordnen = False
        Me.Close()
    End Sub
    Public Shared Function customCertValidation(ByVal sender As Object,
                                            ByVal cert As X509Certificate,
                                            ByVal chain As X509Chain,
                                            ByVal errors As SslPolicyErrors) As Boolean
        Return True
    End Function
    Private Sub NeueKategorieAnlegenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeueKategorieAnlegenToolStripMenuItem.Click
        Dim strInput As String = InputBox("Bitte Unterkategorie-Namen eingeben", "Sub-Shop Unterkategorie anlegen.")
        If strInput.Length > 0 Then
            'MessageBox.Show(strInput & " " & Label1.Text)


            ServicePointManager.ServerCertificateValidationCallback =
                New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)


            Dim Request As HttpWebRequest = CType(WebRequest.Create(My.Settings.SHOPSTE_API_URL & "api.php"), HttpWebRequest)
            Request.Method = "POST"
            Request.ContentType = "application/x-www-form-urlencoded"
            'msgMessage.Text = icount & " | " & ListView1.Items.Count - 1 & " - Bereite einfügen vor..."


            Application.DoEvents()

            Dim Post As String = "modus=system_category_add&domain_id=" & My.Settings.SHOPSTE_domain_id & "&shop_cat_title=" & strInput & "&shop_cat_position=0&shop_cat_id=" & Label1.Text & "&page_layout=col2-left-layout&subtyp=new" & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD

            ' Clipboard.SetText(WebUtility.HtmlEncode(ListView1.SelectedItems(0).SubItems(5).Text))

            'Dim postQuery As Byte() = System.Text.Encoding.ASCII.GetBytes("Post 

            Dim byteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(Post)
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
            ' msgMessage.Text = ServerResponse
            If InStr(ServerResponse, "shopid") Then

            End If

            Dim dtSubShopCat As DataTable = FillTestTableSubShopCat()
            CreateTree(0, dtSubShopCat)
            TreeView1.ExpandAll()
        End If
    End Sub

    Private Sub KategorieUmbennenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KategorieUmbennenToolStripMenuItem.Click
        Dim strInput As String = InputBox("Bitte Unterkategorie-Namen eingeben", "Sub-Shop Unterkategorie anlegen.")
        If strInput.Length > 0 Then
            'MessageBox.Show(strInput & " " & Label1.Text)


            ServicePointManager.ServerCertificateValidationCallback =
                New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)


            Dim Request As HttpWebRequest = CType(WebRequest.Create(My.Settings.SHOPSTE_API_URL & "api.php"), HttpWebRequest)
            Request.Method = "POST"
            Request.ContentType = "application/x-www-form-urlencoded"
            'msgMessage.Text = icount & " | " & ListView1.Items.Count - 1 & " - Bereite einfügen vor..."


            Application.DoEvents()

            Dim Post As String = "modus=system_category_add&domain_id=" & My.Settings.SHOPSTE_domain_id & "&shop_cat_title=" & strInput & "&shop_cat_position=0&shop_cat_id=" & Label1.Text & "&page_layout=col2-left-layout&subtyp=rename" & "&txtUsername=" & My.Settings.SHOPSTE_USERNAME & "&txtPasswort=" & My.Settings.SHOPSTE_PASSWORD

            ' Clipboard.SetText(WebUtility.HtmlEncode(ListView1.SelectedItems(0).SubItems(5).Text))

            'Dim postQuery As Byte() = System.Text.Encoding.ASCII.GetBytes("Post 

            Dim byteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(Post)
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
            ' msgMessage.Text = ServerResponse
            If InStr(ServerResponse, "shopid") Then

            End If

            Dim dtSubShopCat As DataTable = FillTestTableSubShopCat()
            CreateTree(0, dtSubShopCat)
            TreeView1.ExpandAll()
        End If
    End Sub

    Private Sub TreeView2_Click(sender As Object, e As EventArgs) Handles TreeView2.Click

    End Sub
End Class