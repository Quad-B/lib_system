Imports System.Data.SqlClient
Imports System.Globalization
Public Class Form4
    'Dim Current As Integer
    Dim MemTel As String
    Dim ConStr As String = "Server=localhost\SQLEXPRESS;Database=v;Trusted_Connection=True;"
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox4.Text = LoginForm.LoginUserID 'Textbox รหัสบรรณารักษ์
        TextBox5.Text = LoginForm.LoginNameUser 'Textbox ชื่อบรรณารักษ์
        DataGridView1.ColumnCount = 2
        ' เวอร์ชั่นเก่า
        'DataGridView1.ColumnCount = 3
        DataGridView1.Columns(0).Name = "รหัสหนังสือ" 'ตั้งค่า DataGridView ของการยืมไว้
        DataGridView1.Columns(1).Name = "ชื่อหนังสือ"
        ' เวอร์ชั่นเก่า
        'DataGridView1.Columns(2).Name = "จำนวนวันที่ยืมได้"
        'Label12.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'เมื่อคลิก ยืม ให้ปิด โซนการคืน แล้วเปิดโซนการยืม
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        GroupBox3.Enabled = False
        GroupBox4.Enabled = False
        Button7.Enabled = True
        Button3.Enabled = True
        Button6.Enabled = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'เมื่อคลิก ยกเลิกการยืม ให้เปิด โซนการคืน แล้วปิดโซนการยืม
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True
        GroupBox4.Enabled = True
        Button7.Enabled = False
        Button3.Enabled = False
        Button6.Enabled = True
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'เมื่อค้นหาสมาชิก
        Dim Con As New SqlConnection(ConStr)
        Dim objCmd As New SqlCommand
        Dim dtAdapter As SqlDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        Con.Open()

        sql = "SELECT * FROM dbo.Member WHERE ID = '" & TextBox2.Text & "'"

        dtAdapter = New SqlDataAdapter(sql, Con)
        dtAdapter.Fill(dt)

        If dt.Rows.Count > 0 Then
            TextBox3.Text = dt.Rows(0)("Name")
            MemTel = dt.Rows(0)("Tel")
        Else
            TextBox3.Text = ""
            MessageBox.Show("ไม่มีสมาชิกรหัสนี้")
        End If

        Con.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'เมื่อเพิ่มรายการยืม
        Dim Con As New SqlConnection(ConStr)
        'Dim objCmd As New SqlCommand
        Dim dtAdapter As SqlDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        Con.Open()

        If TextBox6.Text = "" Then
            Exit Sub
        Else
            sql = "SELECT * FROM dbo.Book WHERE ID = '" & TextBox6.Text & "'"
            dtAdapter = New SqlDataAdapter(sql, Con)
            dtAdapter.Fill(dt)
        End If

        If dt.Rows.Count > 0 Then
            DataGridView1.Rows.Add(New String() {dt.Rows(0)("ID"), dt.Rows(0)("Namebook")})
            'เวอร์ชั่นเก่า
            'DataGridView1.Rows.Add(New String() {dt.Rows(0)("ID"), dt.Rows(0)("Namebook"), dt.Rows(0)("Days")})
            'Label7.Text = "ชื่อสมาชิก :" & dt.Rows(0)("Name")
            'Label8.Text = "นามสกุล :" & dt.Rows(0)("Surname")
            'Label9.Text = "วันที่สมัคร :" & dt.Rows(0)("RgsDate")
            'Label10.Text = "เบอรฺโทรศัพท์ :" & dt.Rows(0)("Tel")
        Else
            MessageBox.Show("ไม่เจอหนังสือเล่มนี้")
        End If
        TextBox6.Text = ""

        Con.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'เมื่อยืนยันการยืม
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("ไม่มีหนังสือที่จะยืม โปรดกดยกเลิก หรือ เพิ่มหนังสือในการยืม")
            Exit Sub
        End If

        If TextBox3.Text = "" Then
            MessageBox.Show("กดค้นหารหัสสมาชิก ก่อนที่จะยืนยันการยืม")
            Exit Sub
        End If

        Dim Con As New SqlConnection(ConStr)
        Con.Open()
        Dim sql As String
        Dim sql2 As String

        If MessageBox.Show("ข้อมูลถูกต้องและพร้อมที่จะยืนยันในการยืม", "ยืนยันการยืม", MessageBoxButtons.YesNo) = DialogResult.Yes Then

            Dim i As Integer = 0
            While i < DataGridView1.Rows.Count
                'MessageBox.Show(DataGridView1.Rows(i).Cells(0).Value)
                'MessageBox.Show(DataGridView1.Rows(i).Cells(1).Value)
                'MessageBox.Show(DateTimePicker1.Value.Day)
                'MessageBox.Show(DateTimePicker2.Value.Day)

                If CInt(DateTimePicker2.Value.Day) - CInt(DateTimePicker1.Value.Day) = 0 Then
                    MessageBox.Show("ไม่สามารถยืมและคืนในวันเดียวกันได้ กรุณายืมอย่างน้อยหนึ่งวัน")
                    Exit Sub
                End If

                'เวอร์ชั่นเก่า มีการเช็ควันที่ยืม
                'If CInt(DateTimePicker2.Value.Day) - CInt(DateTimePicker1.Value.Day) > CInt(DataGridView1.Rows(i).Cells(2).Value) Or CInt(DateTimePicker2.Value.Day) - CInt(DateTimePicker1.Value.Day) < 0 Then
                'MessageBox.Show("เวลายืม มากกว่า " & DataGridView1.Rows(i).Cells(2).Value & "วัน กรุณากำหนดวันยืมใหม่")
                'Exit Sub
                'End If

                sql = "Insert Into dbo.Borrow (BookID,MemID,LibID,BorrowDate,ReturnDate,Tel) VALUES(" & DataGridView1.Rows(i).Cells(0).Value & "," & Val(TextBox2.Text) & "," & LoginForm.LoginUserID & ",'" & FormatDateTime(DateTimePicker1.Value.ToString) & "','" & FormatDateTime(DateTimePicker2.Value.ToString) & "','" & MemTel & "')"
                'เวอร์ชั่นเก่า
                'sql = "Insert Into dbo.Borrow (BookID,MemID,LibID,BorrowDate,ReturnDate,Tel) VALUES(" & DataGridView1.Rows(i).Cells(0).Value & "," & Val(TextBox2.Text) & "," & LoginForm.LoginUserID & ",'" & FormatDateTime(DateTimePicker1.Value.ToString) & "','" & FormatDateTime(DateTimePicker2.Value.ToString) & "','" & MemTel & "')"
                sql2 = "UPDATE dbo.Book SET Status=0 WHERE ID = '" & DataGridView1.Rows(i).Cells(0).Value & "'"
                Dim cmd As New SqlCommand(sql, Con)
                Dim cmd2 As New SqlCommand(sql2, Con)

                'MessageBox.Show(sql)

                If cmd.ExecuteNonQuery() And cmd2.ExecuteNonQuery() Then
                    MessageBox.Show("บันทึกการยืนเรียบร้อย")
                    Call Button7_Click(sender, e)
                End If

                i += 1
            End While

        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        'เมื่อเปลี่ยนรหัสสมาชิก
        TextBox3.Text = ""
        MemTel = ""
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'เมื่อค้นหาสมาชิก เพื่อจะทำการคืน
        Dim Con As New SqlConnection(ConStr)
        Dim objCmd As New SqlCommand
        Dim dtAdapter As SqlDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        Con.Open()

        sql = "SELECT * FROM dbo.Member WHERE ID = '" & TextBox7.Text & "'"
        dtAdapter = New SqlDataAdapter(sql, Con)
        dtAdapter.Fill(dt)

        If dt.Rows.Count = 0 Then
            MessageBox.Show("ไม่มีสมาชิกนี้")
            DataGridView3.DataSource = Nothing
            DataGridView3.Columns.Clear()
            Exit Sub
        End If

        dt.Columns.Clear()
        dt.Rows.Clear()

        sql = "SELECT Borrow.* FROM Borrow LEFT JOIN Borrowtem ON Borrow.ID = Borrowtem.BorrowID WHERE MemId ='" & TextBox7.Text & "' AND Borrowtem.BorrowID IS NULL"
        dtAdapter = New SqlDataAdapter(sql, Con)
        dtAdapter.Fill(dt)

        If dt.Rows.Count = 0 Then
            MessageBox.Show("สมาชิกนี้ ทำการคืนหนังสือ เรียบร้อยหมดแล้ว")
            Exit Sub
        End If

        Dim dgvcb As New DataGridViewCheckBoxColumn
        dgvcb.Name = "คืน"

        DataGridView3.Columns.Add(dgvcb)

        DataGridView3.DataSource = dt

        DataGridView3.Columns(1).HeaderText = "ไอดีการยืม"
        DataGridView3.Columns(2).HeaderText = "ไอดีหนังสือ"
        DataGridView3.Columns(1).Visible = False
        Con.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'เมื่อสืบค้นข้อมูล
        DataGridView2.Rows.Clear()
        Dim Con As New SqlConnection(ConStr)
        Dim objCmd As New SqlCommand
        Dim dtAdapter As SqlDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        Con.Open()

        If TextBox8.Text.Trim IsNot "" And TextBox9.Text.Trim = "" Then 'เมื่อ ค้นหาหนังสือ
            sql = "SELECT *,DATEADD(year, -543, BorrowDate) AS BYearNor,DATEADD(year, -543, ReturnDate) AS RYearNor FROM dbo.Borrow WHERE BookID = '" & TextBox8.Text & "'"
            dtAdapter = New SqlDataAdapter(sql, Con)
            dtAdapter.Fill(dt)
        ElseIf TextBox8.Text.Trim IsNot "" And TextBox9.Text.Trim IsNot "" Then 'เมื่อ ค้นหาหนังสือ และ สมาชิก
            sql = "SELECT *,DATEADD(year, -543, BorrowDate) AS BYearNor,DATEADD(year, -543, ReturnDate) AS RYearNor FROM dbo.Borrow WHERE BookID = '" & TextBox8.Text & "' AND MemID = '" & TextBox9.Text & "'"
            dtAdapter = New SqlDataAdapter(sql, Con)
            dtAdapter.Fill(dt)
        ElseIf TextBox9.Text.Trim IsNot "" And TextBox8.Text.Trim = "" Then 'เมื่อ ค้นหาสมาชิก
            sql = "SELECT *,DATEADD(year, -543, BorrowDate) AS BYearNor,DATEADD(year, -543, ReturnDate) AS RYearNor FROM dbo.Borrow WHERE MemID = '" & TextBox9.Text & "'"
            dtAdapter = New SqlDataAdapter(sql, Con)
            dtAdapter.Fill(dt)
        Else
            Exit Sub
        End If

        Dim i As Integer = 0
        If dt.Rows.Count > 0 Then
            'DataGridView2.DataSource = dt
            'DataGridView2.Columns(0).HeaderText = "ไอดีการยืม"
            'DataGridView2.Columns(1).HeaderText = "รหัสหนังสือ"
            'DataGridView2.Columns(2).HeaderText = "รหัสสมาชิก"
            'DataGridView2.Columns(3).HeaderText = "รหัสผู้ให้ยืม/รหัสบรรนารัณ"
            'DataGridView2.Columns(4).HeaderText = "วันยืม"
            'DataGridView2.Columns(4).DefaultCellStyle.Format = Format("MM/dd/yyyy")
            'DataGridView2.Columns(5).HeaderText = "วันคืน"
            'DataGridView2.Columns(5).DefaultCellStyle.Format = Format("MM/dd/yyyy")
            'DataGridView2.Columns(6).HeaderText = "เบอร์โทรสมาชิก"
            DataGridView2.ColumnCount = 7
            DataGridView2.Columns(0).Name = "ไอดีการยืม"
            DataGridView2.Columns(1).Name = "รหัสหนังสือ"
            DataGridView2.Columns(2).Name = "รหัสสมาชิก"
            DataGridView2.Columns(3).Name = "รหัสผู้ให้ยืม/รหัสบรรนารัณ"
            DataGridView2.Columns(4).Name = "วันยืม"
            DataGridView2.Columns(5).Name = "วันคืน"
            DataGridView2.Columns(6).Name = "เบอร์โทรสมาชิก"
            While i < dt.Rows.Count
                DataGridView2.Rows.Add(New String() {dt.Rows(i)("ID"), dt.Rows(i)("BookID"), dt.Rows(i)("MemID"), dt.Rows(i)("LibID"), Format(dt.Rows(i)("BYearNor"), "MM/dd/yyyy"), Format(dt.Rows(i)("RYearNor"), "MM/dd/yyyy"), dt.Rows(i)("Tel")})
                i += 1
            End While

            'Label7.Text = "ชื่อสมาชิก :" & dt.Rows(0)("Name")
            'Label8.Text = "นามสกุล :" & dt.Rows(0)("Surname")
            'Label9.Text = "วันที่สมัคร :" & dt.Rows(0)("RgsDate")
            'Label10.Text = "เบอรฺโทรศัพท์ :" & dt.Rows(0)("Tel")
        Else
            If TextBox9.Text.Trim IsNot "" Then
                MessageBox.Show("ไม่เจอการยืมของสมาชิกนี้")
            Else
                MessageBox.Show("ไม่เจอการยืมของหนังสือเล่มนี้")
            End If

        End If

        Con.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'เมื่อลบหนังสือที่จะยืม
        DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        'Label12.Text = ""
        'Current = 70
        'Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Current = Current - 1
        'Label12.Text = "จะทำการยืนยันในอีก : " & CInt(Current / 10)

        'If Current = "0" Then
        'TextBox6.Text = TextBox12.Text
        'Timer1.Stop()
        'Panel2.Visible = False
        'End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'เมื่อกดปุ่ม สแกนหนังสือ
        Panel2.Visible = True
        TextBox12.Focus()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'เมื่อกดดู Report
        rp.Show()
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        'MessageBox.Show(DataGridView3.Item(1, DataGridView3.CurrentCell.RowIndex).Value)
        If DataGridView3.CurrentCell.ColumnIndex = 0 Then 'เมื่อติ๊กจะคืน
            If MessageBox.Show("ต้องการคืนหนังสือเล่มนี้ใช่หรือไม่", "คำเตือน", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim Con As New SqlConnection(ConStr)
                Con.Open()
                Dim sql As String
                Dim sql2 As String

                Dim objCmd As New SqlCommand
                Dim dt As New DataTable

                sql = "Insert Into dbo.Borrowtem (BorrowID,BookID,ReturnDate) VALUES(" & DataGridView3.Item(1, DataGridView3.CurrentCell.RowIndex).Value & "," & DataGridView3.Item(2, DataGridView3.CurrentCell.RowIndex).Value & ",'" & DateTime.Now & "')"
                sql2 = "UPDATE dbo.Book SET Status=1 WHERE ID = '" & DataGridView3.Item(2, DataGridView3.CurrentCell.RowIndex).Value & "'"
                Dim cmd As New SqlCommand(sql, Con)
                Dim cmd2 As New SqlCommand(sql2, Con)

                If cmd.ExecuteNonQuery() And cmd2.ExecuteNonQuery() Then
                    MessageBox.Show("บันทึกการยืนเรียบร้อย")
                    DataGridView3.Rows.RemoveAt(DataGridView3.CurrentCell.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub TextBox12_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox12.KeyDown
        'เมื่อสแกนแล้ว
        If e.KeyCode = Keys.Enter Then
            TextBox6.Text = TextBox12.Text
            TextBox12.Text = ""
            'Timer1.Stop()
            Panel2.Visible = False
            Call Button2_Click(sender, e)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        'เมื่อกดยกเลิก สแกน
        Panel2.Visible = False
    End Sub
End Class