Imports System.Data.SqlClient
Public Class Pubic
    Dim Current As Integer
    Dim ConStr As String = "Server=localhost\SQLEXPRESS;Database=v;Trusted_Connection=True;"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Con As New SqlConnection(ConStr)
        Con.Open()
        Dim MySQL As String
        'MySQL = "Insert Into Book (name,Writer,Pubic,Year,Days,Status)"
        'MySQL += "Values(@na, @write, @Pub, @Year, @day, @st)"
        'MySQL = "UPDATE Book Set Namebook=@na , Writer=@write , Pubic=@Pub , Year=@Year , Days=@day , Status=@st WHERE ID=@id"
        MySQL = "UPDATE Book Set Namebook=@na , Writer=@write , Pubic=@Pub , Year=@Year , Status=@st WHERE ID=@id"

        Dim cmd As New SqlCommand(MySQL, Con)
        cmd.Parameters.Add("id", SqlDbType.Int).Value = ID.Text
        cmd.Parameters.Add("na", SqlDbType.VarChar, 50).Value = Namebook.Text
        cmd.Parameters.Add("write", SqlDbType.VarChar).Value = Writer.Text
        cmd.Parameters.Add("Pub", SqlDbType.VarChar).Value = adbook.Text
        cmd.Parameters.Add("Year", SqlDbType.Int).Value = Year.Text
        'cmd.Parameters.Add("day", SqlDbType.Int).Value = Days.Text
        If RadioButton1.Checked = True Then
            cmd.Parameters.Add("st", SqlDbType.Bit).Value = 1
        End If
        If RadioButton2.Checked = True Then
            cmd.Parameters.Add("st", SqlDbType.Bit).Value = 0
        End If

        If cmd.ExecuteNonQuery() Then
            MessageBox.Show("บันทึกเรียบร้อยแล้ว")
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetBookList()
    End Sub

    Private Function GetBookList() As DataTable
        Dim dtbook As New DataTable

        Dim Con As New SqlConnection(ConStr)

        Dim cmd As New SqlCommand("SELECT * FROM dbo.Book", Con)

        Con.Open()

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        dtbook.Load(reader)

        Return dtbook
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Con As New SqlConnection(ConStr)
        Con.Open()
        Dim sql As String
        If ID.Text = "" Then
            sql = "Insert Into dbo.Book (Namebook,Writer,Pubic,year,Status) VALUES("
            ' เวอร์ชั่นเก่า
            'sql = "Insert Into dbo.Book (Namebook,Writer,Pubic,year,Days,Status) VALUES("
            sql += "'" & Namebook.Text & "',"
            sql += "'" & Writer.Text & "',"
            sql += "'" & adbook.Text & "',"
            sql += "'" & Year.Text & "',1)"
            ' เวอร์ชั่นเก่า
            'sql += "'" & Year.Text & "',"
            'sql += "'" & Days.Text & "',1)"
        Else
            sql = "SET IDENTITY_INSERT Book ON;Insert INto dbo.book(ID,Namebook,Writer,Pubic,year,Status) VALUES("
            ' เวอร์ชั่นเก่า
            'sql = "Insert Into dbo.Book (ID,Namebook,Writer,Pubic,year,Days,Status) VALUES("
            sql += "" & ID.Text & ","
            sql += "'" & Namebook.Text & "',"
            sql += "'" & Writer.Text & "',"
            sql += "'" & adbook.Text & "',"
            sql += "'" & Year.Text & "',1);SET IDENTITY_INSERT book OFF;"
            ' เวอร์ชั่นเก่า
            'sql += "'" & Year.Text & "',"
            'sql += "'" & Days.Text & "',1)"
        End If
        Dim cmd As New SqlCommand(sql, Con)
        Try
            If cmd.ExecuteNonQuery() Then
                MessageBox.Show("บันทึกเรียบร้อย", "ยืนยัน")
                Call Form1_Load(sender, e)
            Else
                MessageBox.Show("มีหนังสือเล่มนี้แล้ว")
            End If
        Catch ex As Exception
            MessageBox.Show("มีหนังสือเล่มนี้แล้ว")
            Exit Sub
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'ลบหนังสือ
        Dim sql As String
        Dim ID As String = InputBox("ป้อนรหัสหนังสือที่ต้องการจะลบ")
        Dim result As MsgBoxResult
        result = MessageBox.Show("ต้องการลบข้อมูลนี้ใช่หรือไม่", "เตือน", MessageBoxButtons.YesNo)

        If result = MsgBoxResult.Yes Then
            sql = "Delete from Book WHERE ID ='" & ID & "'"
            Dim Con As New SqlConnection(ConStr)
            Con.Open()
            Dim cmd As New SqlCommand(sql, Con)
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("การลบเสร็จเรียบร้อย", "ยืนยัน")
            Catch ex As Exception
                MessageBox.Show("ไม่สามารถลบได้เนี่องจากไม่มีข้อมูลนี้หรือมีการยืมและคืนของหนังสือนี้", "ปัญหา")
            End Try
            Call Form1_Load(sender, e)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button1.Enabled = False
        Button2.Enabled = True
        Dim selectRow As DataGridViewRow
        selectRow = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex)
        MessageBox.Show(DataGridView1.CurrentCell.RowIndex)
        ID.Text = selectRow.Cells(0).Value.ToString()
        Namebook.Text = selectRow.Cells(1).Value.ToString()
        Writer.Text = selectRow.Cells(2).Value.ToString()
        adbook.Text = selectRow.Cells(3).Value.ToString()
        Year.Text = selectRow.Cells(4).Value.ToString()
        'เวอร์ชั่นเก่า
        'Days.Text = selectRow.Cells(5).Value.ToString()
        If selectRow.Cells(5).Value.ToString() = True Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
        Else
            RadioButton1.Checked = False
            RadioButton2.Checked = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ID.Text = ""
        Namebook.Text = ""
        Writer.Text = ""
        adbook.Text = ""
        Year.Text = ""
        ' เวอร์ชั่นเก่า
        'Days.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Panel1.Visible = True
        TextBox1.Focus()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel2.Visible = True
        TextBox2.Focus()
    End Sub

    Private Sub Pubic_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Panel1.Location = New Point((Me.Size.Width / 2) - 188.5, (Me.Size.Height / 2) - 100)
        Panel2.Location = New Point((Me.Size.Width / 2) - 188.5, (Me.Size.Height / 2) - 100)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Current = 70
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Current = Current - 1
        Label10.Text = "จะทำการยืนยันในอีก : " & CInt(Current / 10)

        If Current = "0" Then
            Timer1.Stop()
            Panel1.Visible = False
            ID.Text = TextBox1.Text
            MessageBox.Show("ใส่รหัสเรียบร้อย")
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Current = 70
        Timer2.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Current = Current - 1
        Label11.Text = "จะทำการยืนยันในอีก : " & CInt(Current / 10)

        If Current = "0" Then
            Timer2.Stop()
            Panel2.Visible = False
            Dim i As Integer = 0
            Dim superi As Integer = 0
            While i < DataGridView1.Rows.Count
                If DataGridView1.Rows(i).Cells(0).Value = TextBox2.Text Then
                    DataGridView1.Rows(i).Selected = True
                    superi += 1
                End If
                i += 1
            End While
            If superi = 0 Then
                MessageBox.Show("ไม่มีหนังสือที่กำลังจะค้นหา")
            End If
        End If
    End Sub
End Class