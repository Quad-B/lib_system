Imports System.Data
Imports System.Data.SqlClient
Public Class LoginForm
    Public LoginUserID, LoginNameUser As String
    Public conn As New SqlConnection
    ' ���ҧ����� conn �� ���Դ���� sqlConnection ������Դ��Ͱҹ������SQL Server
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim dr As SqlDataReader
        Dim ss, f, l As String
        '���˹�������� ss �纤�Ҥ����� SQL �������Ң����ŷء�� Ŵ�㹵��ҧ users ������ �� username �դ�ҵç�Ѻ
        ss = "select * from users where username='" & UsernameTextBox.Text & "' and password ='" & PasswordTextBox.Text & "'"
        dr = executereader(ss)
        dr.Read()
        If dr.HasRows Then '��Ǩ�ͺ���㹵���� dr ���Ǣ�� ��ŵç��Ѥ����� SQL �������
            f = dr.Item("name").ToString '����ը�� �������� f �纤�Ң������ �� Ŵ�name �ͧ��
            l = dr.Item("position").ToString '����� l �纤�Ң�����㹿� Ŵ�position �ͧ��
            MsgBox("�Թ�յ�͹�麤س " & f & "����˹� : " & l, MsgBoxStyle.Information +
            MsgBoxStyle.OkOnly)
            frmMain.Show() '�ʴ��������ѡ
            'frmMain.MenuStrip.Enabled = True
            LoginUserID = dr.Item("ID").ToString
            LoginNameUser = dr.Item("name").ToString


            Me.Hide() '��͹����� Login
        Else
            MsgBox("��辺�����ż����س������Է��� ������к�", MsgBoxStyle.Information +
            MsgBoxStyle.OkOnly, "�š�÷�ҧҹ ") '�ҡ��Ǩ�ͺ����� dr ��������բ�� ��ŵ�������� SQL ���ʴ����ͧ��ͤ������
            UsernameTextBox.Clear() '���������������� UsernameTextBox
            PasswordTextBox.Clear() '���������������� passwordTextBox
            UsernameTextBox.Focus() '���������������Ѻ�����ŷ��(UsernameTextBox)
        End If
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Public Sub connectdata() Handles MyBase.Load '��С�ȿѧ���� ���� connectdata()
        Dim s As String '���ҧ����� s �繪�Դ String
        Try
            With conn
                If .State = ConnectionState.Open Then conn.Close() '��Ǩ�ͺʶҹТͧ����� conn
                s = "Server=localhost\SQLEXPRESS;Database=v;Trusted_Connection=True;"
                's = "Data Source = DESKTOP-KIC1UC6\SQLEXPRESS;"
                's = s + "Initial Catalog=Library;" '�кت��Ͱҹ�����Ţͧ��ҷ�����ҧ���
                's += "User ID=sa; password=123456789;" '�к�username ���
                .ConnectionString = s '������� conn ��� ��� ���Դ SqlConnection �Դ��Ͱҹ�����ŵ��
                .Open() ' �� ���õԴ��ͼ�ҹ�ҧ����� conn ���������������ҡѺ�ҹ������
            End With
        Catch ex As Exception
            MessageBox.Show("�������ö�������Ͱҹ��������... " & ex.Message, "�š����������
�ҹ������", MessageBoxButtons.OK, MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Public Function executereader(ByVal prmSQL As String) As SqlDataReader
        '��� ˹����Ϳѧ�쪹�� executereader ��������ҹ�����ŷ��� reccord Ẻ forward
        Dim dr As SqlDataReader '���˹������ dr �� ���Դ sqlDataReader ��������ҹ�����ŷ���
        Dim comm As New SqlCommand '���˹������ comm �� ���Դ sqlCommand ������㹡�ä��Ң�����
        connectdata() '���¡㪿� ѧ�쪹�� connectdata() ���͵Դ��Ͱҹ������
        With comm
            .CommandType = CommandType.Text '��� ˹�������������
            .CommandText = prmSQL '�觤�Ҥ����� prmSQL ��� object


            .Connection = conn '�͡��鹷ҧ�������͵������� conn ��� ����鹢ͧ�ҹ�����ŷҧ�����
            dr = .ExecuteReader() '�����żŤ����� SQL ����觼��Ѿ���ҷ������ dr
            Return dr '�觤�� dr ��Ѻ
        End With
    End Function

    Private Sub LogoPictureBox_Click(sender As Object, e As EventArgs) Handles LogoPictureBox.Click

    End Sub
End Class