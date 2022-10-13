Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class FlightDetails

    Dim pkVar As String
    Private Sub ItemForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        disRecords()

        Me.WindowState = FormWindowState.Maximized

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd1 As New SqlCommand("select place from PlaceTable order by Place", conn)
        Dim D1 As SqlDataReader = Cmd1.ExecuteReader()
        While D1.Read
            ComboBox4.Items.Add(D1(0).ToString)
            ComboBox3.Items.Add(D1(0).ToString)
        End While
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If vbNo = MsgBox("Are you sure you want modify this record", MsgBoxStyle.YesNo, "Modify") Then Exit Sub
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd1 As New SqlCommand("Delete from FlightDetailsTable where FlightNo='" & pkVar & "'", conn)
        cmd1.ExecuteNonQuery()

        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EntriesMDI.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SaveRecord()
    End Sub
    Sub SaveRecord()
        If TextBox1.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select FlightNo from FlightDetailsTable where FlightNo='" & UCase(TextBox1.Text) & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("This record is already present in the database")
            If conn.State = ConnectionState.Open Then conn.Close()
            Exit Sub
        End If

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        q1Var = "insert into FlightDetailsTable "
        q2Var = " values("
        q2Var = q2Var & "'" & TextBox1.Text & "',"
        q2Var = q2Var & "'" & ComboBox1.Text & "',"
        q2Var = q2Var & "'" & ComboBox2.Text & "',"
        q2Var = q2Var & "'" & ComboBox3.Text & "',"
        q2Var = q2Var & "'" & ComboBox4.Text & "',"
        q2Var = q2Var & "'" & TextBox3.Text & "',"
        q2Var = q2Var & "'" & TextBox4.Text & "',"
        q2Var = q2Var & "" & Val(TextBox5.Text) & ","
        q2Var = q2Var & "" & Val(TextBox6.Text) & ","
        q2Var = q2Var & "" & Val(TextBox7.Text) & ","
        q2Var = q2Var & "" & Val(TextBox8.Text) & ")"


        'MsgBox(q1Var & q2Var)
        Dim cmd1 As New SqlCommand(q1Var & q2Var, conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()
        MsgBox("Flight Detail Saved")
        disRecords()

    End Sub
    Sub disRecords()

        If TextBox1.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If ComboBox1.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If ComboBox2.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If ComboBox3.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If ComboBox4.Text = "" Then
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

        If TextBox7.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If TextBox8.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("Select * From FlightDetailsTable order by FlightNo", conn)
        adp.Fill(DS1)
        DG1.DataSource = DS1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox8.Text = ""
    End Sub



    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick
        pkVar = DG1.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select * from FlightDetailsTable where FlightNo='" & pkVar & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
            TextBox1.Text = D1(0).ToString
            ComboBox1.Text = D1(1).ToString
            ComboBox2.Text = D1(2).ToString
            ComboBox3.Text = D1(3).ToString
            ComboBox4.Text = D1(4).ToString
            TextBox3.Text = D1(5).ToString
            TextBox4.Text = D1(6).ToString
            TextBox5.Text = D1(7).ToString
            TextBox6.Text = D1(8).ToString
            TextBox7.Text = D1(9).ToString
            TextBox8.Text = D1(10).ToString

            butNew.Enabled = True
            butSave.Enabled = False
            butModify.Enabled = True
            ButDelete.Enabled = True
        Else
            TextBox1.Text = ""

            butNew.Enabled = True
            butSave.Enabled = False
            butModify.Enabled = False
            ButDelete.Enabled = False

        End If
        If conn.State = ConnectionState.Open Then conn.Close()

    End Sub

    Private Sub FlightDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd1 As New SqlCommand("select Place from PlaceTable order by Place", conn)
        Dim D1 As SqlDataReader = Cmd1.ExecuteReader()
        While D1.Read
            ComboBox3.Items.Add(D1(0).ToString)
            ComboBox4.Items.Add(D1(0).ToString)
        End While
    End Sub

    Private Sub butList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butList.Click
        disRecords()
    End Sub

    Private Sub butSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        SaveRecord()
        butNew.Enabled = True
        butSave.Enabled = False
        butModify.Enabled = False
        ButDelete.Enabled = False
    End Sub


    Private Sub butNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butNew.Click
        ClearTxtControls(Me, 1)
        TextBox1.Focus()
        butNew.Enabled = False
        butSave.Enabled = True
        butModify.Enabled = False
        ButDelete.Enabled = False
    End Sub

    Private Sub butModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butModify.Click
        If vbNo = MsgBox("Are you sure you want modify this record", MsgBoxStyle.YesNo, "Delete") Then Exit Sub
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd1 As New SqlCommand("Delete from FlightDetailsTable where FlightNo='" & pkVar & "'", conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()
        SaveRecord()
        butNew.Enabled = True
        butSave.Enabled = False
        butModify.Enabled = False
        ButDelete.Enabled = False
    End Sub

    Private Sub ButDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDelete.Click
        If vbNo = MsgBox("Are you sure you want delete this record", MsgBoxStyle.YesNo, "Delete") Then Exit Sub
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd1 As New SqlCommand("Delete from FlightDetailsTable where FlightNo='" & pkVar & "'", conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()
        disRecords()
        butNew.Enabled = True
        butSave.Enabled = False
        butModify.Enabled = False
        ButDelete.Enabled = False
    End Sub

    Private Sub butClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClose.Click
        Me.Close()
        EntriesMDI.Show()
    End Sub



    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = "F-"
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        TextBox5.MaxLength = 3
        If Not Regex.Match(TextBox5.Text, "^[0-9. ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("please enter number only!")
            TextBox5.Text = ""
            TextBox5.Focus()
        End If
    End Sub
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        TextBox6.MaxLength = 5
        If Not Regex.Match(TextBox6.Text, "^[0-9. ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("please enter number only!")
            TextBox6.Text = ""
            TextBox6.Focus()
        End If
    End Sub
    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        TextBox7.MaxLength = 3
        If Not Regex.Match(TextBox7.Text, "^[0-9. ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("please enter number only!")
            TextBox7.Text = ""
            TextBox7.Focus()
        End If
    End Sub
    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        TextBox8.MaxLength = 5
        If Not Regex.Match(TextBox8.Text, "^[0-9. ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("please enter number only!")
            TextBox8.Text = ""
            TextBox8.Focus()
        End If
    End Sub
End Class