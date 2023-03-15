Public Class frmJTLSpracheigenschaften

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmMain.clsDB.getSpracheigenschaften(lstSpracheigenschaften)
        Label1.Text = "Anzahl: " & lstSpracheigenschaften.Items.Count - 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        If lstSpracheigenschaften.Items.Count > 0 Then
            frmMain.clsDB.getSpracheigenschaften_repair(lstSpracheigenschaften)
        Else
            MessageBox.Show("Bitte erst den Button einlesen anklicken")
        End If

    End Sub

    Private Sub lstSpracheigenschaften_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSpracheigenschaften.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If lstSpracheigenschaften.Items.Count > 0 Then
            frmMain.clsDB.setSprachEigenSchaftWert_repair(lstSpracheigenschaften)
        Else
            MessageBox.Show("Bitte erst den Button einlesen anklicken")
        End If

    End Sub
End Class