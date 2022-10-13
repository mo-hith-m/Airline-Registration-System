Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class RegFrm

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveRecord()

    End Sub
    Sub SaveRecord()
        If TextBox1.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select * from StaffRegTable where Name='" & UCase(TextBox1.Text) & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("This record is already present in the database")
            If conn.State = ConnectionState.Open Then conn.Close()
            Exit Sub
        End If

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        q1Var = "insert into StaffRegTable("
        q2Var = " values("

        q1Var = q1Var & "Name" & ","
        q2Var = q2Var & "'" & UCase(TextBox1.Text) & "',"

        q1Var = q1Var & "Password" & ","
        q2Var = q2Var & "'" & TextBox2.Text & "',"

        q1Var = q1Var & "Address" & ","
        q2Var = q2Var & "'" & TextBox3.Text & "',"

        q1Var = q1Var & "Phone" & ","
        q2Var = q2Var & "'" & TextBox4.Text & "',"

        q1Var = q1Var & "email" & ","
        q2Var = q2Var & "'" & TextBox5.Text & "',"

        q1Var = q1Var & "Qualification" & ","
        q2Var = q2Var & "'" & TextBox6.Text & "',"

        q1Var = q1Var & "Designation" & ")"
        q2Var = q2Var & "'" & TextBox7.Text & "')"

        'MsgBox(q1Var & q2Var)
        Dim cmd1 As New SqlCommand(q1Var & q2Var, conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()

        MsgBox("record saved")
        disRecords()
    End Sub


    Sub disRecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("Select Name, Password, Address, Phone, email, Qualification, Designation From StaffRegTable order by Name", conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If vbNo = MsgBox("Are you sure you want modify this record", MsgBoxStyle.YesNo, "Modify") Then Exit Sub
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd1 As New SqlCommand("Delete from StaffRegTable where Name='" & pkvar & "'", conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()
        SaveRecord()
 
        Button5.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        pkvar = DataGridView1.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select * from StaffRegTable where Name='" & pkvar & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
            TextBox1.Text = D1(0).ToString
            TextBox2.Text = D1(1).ToString
            TextBox3.Text = D1(2).ToString
            TextBox4.Text = D1(3).ToString
            TextBox5.Text = D1(4).ToString
            TextBox6.Text = D1(5).ToString
            TextBox7.Text = D1(6).ToString

        Else
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""

        End If
        Button5.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True

        If conn.State = ConnectionState.Open Then conn.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If vbNo = MsgBox("Are you sure you want delete this record", MsgBoxStyle.YesNo, "Delete") Then Exit Sub
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd1 As New SqlCommand("Delete from StaffRegTable where Name='" & pkvar & "'", conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()
        disRecords()
        Button5.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Admin.Show()
        Me.Hide()
    End Sub

    Private Sub RegFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ClearTxtControls(Me, 1)
        TextBox1.Focus()
        Button5.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        disRecords()
    End Sub
End Class
