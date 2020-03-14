Public Class rp
    Private Sub rp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'LibraryDataSet.Borrow' table. You can move, or remove it, as needed.
        Me.BorrowTableAdapter.Fill(Me.LibraryDataSet.Borrow)

        Me.ReportViewer1.RefreshReport()

        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class