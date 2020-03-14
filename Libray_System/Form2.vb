Imports System.Data.SqlClient
Public Class Form2
    Dim ConStr As String = "Server=localhost\SQLEXPRESS;Database=v;Trusted_Connection=True;"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text.Trim = "" Or TextBox3.Text.Trim = "" Then
            MessageBox.Show("กรุณากรอกชื่อและนามสกุลเป็นอย่างน้อย")
        End If
        Dim Con As New SqlConnection(ConStr)
        Con.Open()
        Dim sql As String
        If ID.Text.Trim = "" Then
            sql = "Insert Into dbo.Member (Name,Surname,RgsDate,Tel) VALUES("
        Else
            sql = "SET IDENTITY_INSERT dbo.Member ON;Insert Into dbo.Member (ID,Name,Surname,RgsDate,Tel) VALUES("
            sql += "'" & ID.Text & "',"
        End If
        sql += "'" & TextBox2.Text & "',"
        sql += "'" & TextBox3.Text & "',"
        sql += "'" & TextBox4.Text & "',"
        sql += "'" & TextBox5.Text & "');SET IDENTITY_INSERT dbo.Member OFF"
        Dim cmd As New SqlCommand(sql, Con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("บันทึกเรียบร้อย", "ยืนยัน")
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBox4.Text = DateTime.Now.ToShortDateString
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox6.Text.Trim = "" Or TextBox7.Text.Trim = "" Then
            MessageBox.Show("กรุณากรอกชื่อและนามสกุลให้ครบถ้วน")
        End If
        Dim Con As New SqlConnection(ConStr)
        'Dim objCmd As New SqlCommand
        Dim dtAdapter As SqlDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        Con.Open()

        sql = "SELECT * FROM dbo.Member WHERE Name = '" & TextBox6.Text & "' AND Surname = '" & TextBox7.Text & "'"

        dtAdapter = New SqlDataAdapter(sql, Con)
        dtAdapter.Fill(dt)

        If dt.Rows.Count > 0 Then
            Label13.Text = dt.Rows(0)("ID")
            Label7.Text = "ชื่อสมาชิก :" & dt.Rows(0)("Name")
            Label8.Text = "นามสกุล :" & dt.Rows(0)("Surname")
            Label9.Text = "วันที่สมัคร :" & dt.Rows(0)("RgsDate")
            Label10.Text = "เบอรฺโทรศัพท์ :" & dt.Rows(0)("Tel")
        Else
            MessageBox.Show("ไม่มีสมาชิกชือนี้")
            Label13.Text = ""
            Label7.Text = "ชื่อสมาชิก :"
            Label8.Text = "นามสกุล :"
            Label9.Text = "วันที่สมัคร :"
            Label10.Text = "เบอรฺโทรศัพท์ :"
        End If

        Con.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String
        Dim ID As String = InputBox("ป้อนรหัสสมาชิกที่ต้องการจะลบ")
        Dim result As MsgBoxResult
        result = MessageBox.Show("ต้องการลบสมาชิกนี้ใช่หรือไม่", "เตือน", MessageBoxButtons.YesNo)

        If result = MsgBoxResult.Yes Then
            sql = "Delete from Member WHERE ID ='" & ID & "'"
            Dim Con As New SqlConnection(ConStr)
            Con.Open()
            Dim cmd As New SqlCommand(sql, Con)
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("การลบเสร็จเรียบร้อย", "ยืนยัน")
            Catch ex As Exception
                MessageBox.Show("ไม่สามารถลบได้เนี่องจากไม่มีสมาชิกนี้หรือมีการยืมและคืนของสมาชิกนี้อยู่ในฐานข้อมูล", "ปัญหา")
            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button1.Enabled = False
        Dim ic As String
        Dim MID As String = InputBox("ป้อนรหัสสมาชิกที่ต้องการจะลบ")
        Dim Con As New SqlConnection(ConStr)
        Dim dr As SqlDataReader
        Con.Open()
        ic = "SELECT * FROM Member WHERE ID ='" & MID & "'"
        Dim cmd As New SqlCommand(ic, Con)
        dr = cmd.ExecuteReader()
        If dr.Read() Then
        Else
            MessageBox.Show("ไม่มีรหัสสมาชิกนี้")
            ID.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            Exit Sub
        End If
        ID.Text = dr(0)
        ID.Enabled = False
        TextBox2.Text = dr(1)
        TextBox3.Text = dr(2)
        TextBox4.Text = dr(3)
        TextBox5.Text = dr(4)
        Button3.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ic As String
        Dim Con As New SqlConnection(ConStr)
        Con.Open()
        ic = "UPDATE dbo.Member SET Name='" & TextBox2.Text & "',Surname='" & TextBox3.Text & "',Tel='" & TextBox5.Text & "' WHERE ID = '" & ID.Text & "'"
        Dim cmd As New SqlCommand(ic, Con)
        If cmd.ExecuteNonQuery Then
            MessageBox.Show("อัพเดตข้อมูลเรียบร้อยแล้ว")
        End If
        Button3.Enabled = False
        Button1.Enabled = True
    End Sub
End Class