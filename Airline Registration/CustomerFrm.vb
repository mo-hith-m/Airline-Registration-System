Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class CustomerFrm

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        pkvar = DataGridView1.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select * from CustomerTable where Code='" & pkvar & "'", conn)
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



    End Sub


    Sub disRecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("Select * From CustomerTable order by Code", conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveRecord()
    End Sub
    Sub SaveRecord()
        If TextBox1.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If TextBox2.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If TextBox3.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If TextBox4.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If TextBox5.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If TextBox6.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If




        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select * from CustomerTable where Code='" & TextBox1.Text & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("This record is already present in the database")
            If conn.State = ConnectionState.Open Then conn.Close()
            Exit Sub
        End If

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        q1Var = "insert into CustomerTable("
        q2Var = " values("
        q1Var = q1Var & "Code" & ","
        q2Var = q2Var & "'" & TextBox1.Text & "',"
        q1Var = q1Var & "Name" & ","
        q2Var = q2Var & "'" & TextBox2.Text & "',"
        q1Var = q1Var & "Address" & ","
        q2Var = q2Var & "'" & (TextBox3.Text) & "',"
        q1Var = q1Var & "PinCode" & ","
        q2Var = q2Var & "'" & (TextBox4.Text) & "',"
        q1Var = q1Var & "Mobile" & ","
        q2Var = q2Var & "'" & (TextBox5.Text) & "',"
        q1Var = q1Var & "Passport" & ","
        q2Var = q2Var & "'" & (TextBox6.Text) & "',"
        q1Var = q1Var & "email" & ")"
        q2Var = q2Var & "'" & (TextBox7.Text) & "')"

        'MsgBox(q1Var & q2Var)
        Dim cmd1 As New SqlCommand(q1Var & q2Var, conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()

        MsgBox("Details saved")

        disRecords()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If vbNo = MsgBox("Are you sure you want modify this record", MsgBoxStyle.YesNo, "Modify") Then Exit Sub
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd1 As New SqlCommand("Delete  from CustomerTable where Code='" & pkvar & "'", conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()
        SaveRecord()
        Button5.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If vbNo = MsgBox("Are you sure you want delete this record", MsgBoxStyle.YesNo, "Delete") Then Exit Sub
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd1 As New SqlCommand("Delete from CustomerTable where Code='" & pkvar & "'", conn)
        cmd1.ExecuteNonQuery()

        disRecords()
        Button5.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

        If conn.State = ConnectionState.Open Then conn.Close()


    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        EntriesMDI.Show()
        Me.Hide()
    End Sub

    Private Sub CustomerFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disRecords()

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


    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If Not Regex.Match(TextBox2.Text, "^[a-z. ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("please enter alphabets only!")
            TextBox2.Focus()
            TextBox2.Clear()

        End If
    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        TextBox4.MaxLength = 6
        If Not Regex.Match(TextBox4.Text, "^[0-9. ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("please enter number only!")
            TextBox4.Clear()
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        TextBox5.MaxLength = 10
    End Sub

    Private Sub TextBox5_lostfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus

        ' Dim phoneNumber As New Regex("\d{3}\d{3}\d{4}")
        Dim phoneNumber As New Regex("^([6-9]{1})([0-9]{9})")


        If phoneNumber.IsMatch(TextBox5.Text) Then
            TextBox6.Focus()

        Else

            MsgBox("Not Valid Phone Number")
            TextBox5.Text = ""
            TextBox5.Focus()

        End If

    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        TextBox6.MaxLength = 8
    End Sub
    Private Sub TextBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus

        If Not Regex.Match(TextBox6.Text, "^[0-9. ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("please enter number only!")
            TextBox6.Clear()
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox7_keypress(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.KeyPress
        If Not Regex.Match(TextBox7.Text, "^[a-z.@.0-9 ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("please enter alpha numeric text only!")
            TextBox7.Focus()
            TextBox7.Clear()
        End If
    End Sub

End Class