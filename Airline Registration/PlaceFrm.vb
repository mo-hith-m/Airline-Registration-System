Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class PlaceFrm



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

        If ComboBox1.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If



        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select * from PlaceTable where Place='" & UCase(TextBox1.Text) & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("This record is already present in the database")
            If conn.State = ConnectionState.Open Then conn.Close()
            Exit Sub
        End If

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        q1Var = "insert into PlaceTable("
        q2Var = " values("
        q1Var = q1Var & "Place" & ","
        q2Var = q2Var & "'" & UCase(TextBox1.Text) & "',"
        q1Var = q1Var & "Details" & ","
        q2Var = q2Var & "'" & TextBox2.Text & "',"
        q1Var = q1Var & "Type" & ")"
        q2Var = q2Var & "'" & ComboBox1.Text & "')"

        'MsgBox(q1Var & q2Var)
        Dim cmd1 As New SqlCommand(q1Var & q2Var, conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()

        MsgBox("Data Saved")
        disRecords()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        EntriesMDI.Show()
        Me.Hide()
    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        pkvar = DataGridView1.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select Place, Details, Type from PlaceTable where Place='" & pkvar & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
            TextBox1.Text = D1(0).ToString
            TextBox2.Text = D1(1).ToString
            ComboBox1.Text = D1(2).ToString


        Else
            TextBox1.Text = ""
            TextBox2.Text = ""
            ComboBox1.Text = ""
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        disRecords()
    End Sub
    Sub disRecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("Select * From PlaceTable order by Place", conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub PlaceFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disRecords()

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        If vbNo = MsgBox("Are you sure you want delete this record", MsgBoxStyle.YesNo, "Delete") Then Exit Sub
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd1 As New SqlCommand("Delete from PlaceTable where Place='" & pkvar & "'", conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()
        disRecords()
    End Sub

    Private Sub TextBox1_lostfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If Not Regex.Match(TextBox1.Text, "^[a-z. ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("Please enter alpha text only.")
            TextBox1.Text = ""
            TextBox1.Focus()
        End If
    End Sub


End Class