Public Class frmMain
    Private Sub จดการขอมลสมาชกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดการขอมลสมาชกToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub บนทกการยมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles บนทกการยมToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub จดการขอมลผใชToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดการขอมลผใชToolStripMenuItem.Click
        Users.Show()
    End Sub

    Private Sub จดการขอมลหนงสอToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดการขอมลหนงสอToolStripMenuItem.Click
        Pubic.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub



    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LoginForm.Close()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ReportสมาชกทยงไมคนหนงสอToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportสมาชกทยงไมคนหนงสอToolStripMenuItem.Click
        rp.Show()
    End Sub
End Class