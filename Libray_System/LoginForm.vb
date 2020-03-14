Imports System.Data
Imports System.Data.SqlClient
Public Class LoginForm
    Public LoginUserID, LoginNameUser As String
    Public conn As New SqlConnection
    ' สร้างตัวแปร conn เป็ นชนิดคลาส sqlConnection เพื่อใช้ติดต่อฐานข้อมูลSQL Server
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim dr As SqlDataReader
        Dim ss, f, l As String
        'กําหนดให้ตัวแปร ss เก็บค่าคําสั่ง SQL โดยให้ค้นหาข้อมูลทุกฟิ ลด์ในตาราง users โดยให้ฟิ ล์ด username มีค่าตรงกับ
        ss = "select * from users where username='" & UsernameTextBox.Text & "' and password ='" & PasswordTextBox.Text & "'"
        dr = executereader(ss)
        dr.Read()
        If dr.HasRows Then 'ตรวจสอบว่าในตัวแปร dr มีแถวขอ้ มูลตรงกบัคําสั่ง SQL หรือไม่
            f = dr.Item("name").ToString 'ถ้ามีจริ งให้ตัวแปร f เก็บค่าข้อมูลใน ฟิ ลด์name ของแถว
            l = dr.Item("position").ToString 'ตัวแปร l เก็บค่าข้อมูลในฟิ ลด์position ของแถว
            MsgBox("ยินดีต้อนร้บคุณ " & f & "ตําแหน่ง : " & l, MsgBoxStyle.Information +
            MsgBoxStyle.OkOnly)
            frmMain.Show() 'แสดงฟอร์มหลัก
            'frmMain.MenuStrip.Enabled = True
            LoginUserID = dr.Item("ID").ToString
            LoginNameUser = dr.Item("name").ToString


            Me.Hide() 'ซ่อนฟอร์ม Login
        Else
            MsgBox("ไม่พบข้อมูลผู้ใช้คุณไม่มีสิทธิ์ เข้าใช้ระบบ", MsgBoxStyle.Information +
            MsgBoxStyle.OkOnly, "ผลการทํางาน ") 'หากตรวจสอบตัวแปร dr แลว้ไม่มีขอ้ มูลตามคําสั่ง SQL จะแสดงกล่องข้อความว่า
            UsernameTextBox.Clear() 'แล้วเคลียร์ข้อมูลใน UsernameTextBox
            PasswordTextBox.Clear() 'แล้วเคลียร์ข้อมูลใน passwordTextBox
            UsernameTextBox.Focus() 'ให้เคอร์เซอร์ไปรอรับข้อมูลที่(UsernameTextBox)
        End If
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Public Sub connectdata() Handles MyBase.Load 'ประกาศฟังก์ชั่น ชื่อ connectdata()
        Dim s As String 'สร้างตัวแปร s เป็นชนิด String
        Try
            With conn
                If .State = ConnectionState.Open Then conn.Close() 'ตรวจสอบสถานะของตัวแปร conn
                s = "Server=localhost\SQLEXPRESS;Database=v;Trusted_Connection=True;"
                's = "Data Source = DESKTOP-KIC1UC6\SQLEXPRESS;"
                's = s + "Initial Catalog=Library;" 'ระบุชื่อฐานข้อมูลของเราที่สร้างไว้
                's += "User ID=sa; password=123456789;" 'ระบุusername และ
                .ConnectionString = s 'ให้ตัวแปร conn ซึ่ งเป็ นชนิด SqlConnection ติดต่อฐานข้อมูลตาม
                .Open() ' เปิ ดการติดต่อผ่านทางตัวแปร conn ที่ได้เชื่อมต่อเข้ากับฐานข้อมูล
            End With
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูลได้... " & ex.Message, "ผลการเชื่อมต่อ
ฐานข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Public Function executereader(ByVal prmSQL As String) As SqlDataReader
        'กาํ หนดชื่อฟังก์ชนั่ executereader เพื่อใช้อ่านข้อมูลทีละ reccord แบบ forward
        Dim dr As SqlDataReader 'กําหนดตัวแปร dr เป็ นชนิด sqlDataReader เพื่อใช้อ่านข้อมูลทีละ
        Dim comm As New SqlCommand 'กําหนดตัวแปร comm เป็ นชนิด sqlCommand เพื่อใช้ในการค้นหาข้อมูล
        connectdata() 'เรียกใชฟ้ ังก์ชนั่ connectdata() เพื่อติดต่อฐานข้อมูล
        With comm
            .CommandType = CommandType.Text 'กาํ หนดประเภทคาํสั่ง
            .CommandText = prmSQL 'ส่งค่าคําสั่ง prmSQL ให้ object


            .Connection = conn 'บอกเส้นทางเชื่อมต่อตามตัวแปร conn ที่ เก็บเส้นของฐานข้อมูลทางเอาไว
            dr = .ExecuteReader() 'ประมวลผลคาํสั่ง SQL และส่งผลลัพธ์มาที่ตัวแปร dr
            Return dr 'ส่งค่า dr กลับ
        End With
    End Function

    Private Sub LogoPictureBox_Click(sender As Object, e As EventArgs) Handles LogoPictureBox.Click

    End Sub
End Class