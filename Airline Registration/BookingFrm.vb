Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class BookingFrm
    Dim b1var As Integer


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Sub SaveRecord()

        If ComboBox2.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If ComboBox4.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

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
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select max(bNo)+1 from BookingTable", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.Read Then
            b1var = IIf(IsDBNull(D1(0)), 1000, D1(0))
        End If

        If ComboBox5.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If TextBox5.Text = "" Then
            MsgBox("Please enter the necessary details")
            Exit Sub
        End If

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        q1Var = "insert into BookingTable("
        q2Var = " values("
        q1Var = q1Var & "bNo" & ","
        q2Var = q2Var & "'" & b1var & "',"
        q1Var = q1Var & "Source" & ","
        q2Var = q2Var & "'" & ComboBox3.Text & "',"
        q1Var = q1Var & "Destination" & ","
        q2Var = q2Var & "'" & ComboBox4.Text & "',"
        q1Var = q1Var & "FlightNo" & ","
        q2Var = q2Var & "'" & TextBox3.Text & "',"
        q1Var = q1Var & "Date" & ","
        q2Var = q2Var & "'" & Format(Today.Date, "dd/mm/yyyy") & "',"
        q1Var = q1Var & "SeatType" & ","
        q2Var = q2Var & "'" & ComboBox5.Text & "',"
        q1Var = q1Var & "Price" & ","
        q2Var = q2Var & "'" & TextBox4.Text & "',"
        q1Var = q1Var & "CustomerCode" & ","
        q2Var = q2Var & "'" & ComboBox2.Text & "',"
        q1Var = q1Var & "CustomerName" & ","
        q2Var = q2Var & "'" & TextBox1.Text & "',"
        q1Var = q1Var & "PassportNo" & ","
        q2Var = q2Var & "'" & TextBox2.Text & "',"
        q1Var = q1Var & "email" & ","
        q2Var = q2Var & "'" & TextBox5.Text & "',"
        q1Var = q1Var & "tstatus" & ")"
        q2Var = q2Var & "'N')"

        'MsgBox(q1Var & q2Var)
        Dim cmd1 As New SqlCommand(q1Var & q2Var, conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()
        'MsgBox("Booked Sucessfully")
        disRecords()


        TextBox7.AppendText("AirLine Reservation System" + vbNewLine)
        TextBox7.AppendText("----------------------------------------------------------" + vbNewLine)
        TextBox7.AppendText("Booking Successfull..!" + vbNewLine)
        TextBox7.AppendText(" Name : " + TextBox1.Text + vbNewLine)
        TextBox7.AppendText("Date : " + fDate.Value + vbNewLine)
        TextBox7.AppendText("Flight No : " + TextBox3.Text + vbNewLine)
        TextBox7.AppendText("Source : " + ComboBox3.Text + vbNewLine)
        TextBox7.AppendText("Destination : " + ComboBox4.Text + vbNewLine)
        TextBox7.AppendText("Seat Type: " + ComboBox5.Text + vbNewLine)
        TextBox7.AppendText("price: " + TextBox4.Text + vbNewLine)
        TextBox7.AppendText("----------------------------------------------------------" + vbNewLine)
        TextBox7.AppendText("Thank You ...HAVE A HAPPY JOURNEY✈✈" + vbNewLine)
        TextBox7.AppendText("----------------------------------------------------------" + vbNewLine)



        Dim Mail As New MailMessage
        Mail.Subject = "Booking succesfull!!!"
        If TextBox5.Text = "" Then
            MsgBox("Please Enter The E-Mail Address", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Error!")
        End If
        Mail.To.Add(TextBox5.Text)
        Mail.From = New MailAddress("otpjava7@gmail.com")
        Mail.Body = TextBox7.Text


        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("otpjava7@gmail.com", "lucky2020Glo")
        SMTP.Port = "587"
        SMTP.Send(Mail)
        MsgBox(" Mail Sent")





        MsgBox("Your ticket booked successfully Ticket no is " & b1var)
        ' TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
        'ComboBox5.Text = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EntriesMDI.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        pkvar = DG1.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select * from BookingTable where bNo='" & pkvar & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
            ComboBox3.Text = D1(0).ToString
            ComboBox4.Text = D1(1).ToString


        Else
            ComboBox4.Text = ""
            ComboBox3.Text = ""


        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        disRecords()

    End Sub

    Sub disRecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("Select * From BookingTable order by bNo", conn)
        adp.Fill(DS1)
        DG1.DataSource = DS1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub BookingFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd1 As New SqlCommand("select Place from PlaceTable order by Place", conn)
        Dim D1 As SqlDataReader = Cmd1.ExecuteReader()
        While D1.Read
            ComboBox3.Items.Add(D1(0).ToString)
            ComboBox4.Items.Add(D1(0).ToString)
        End While


        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd2 As New SqlCommand("select code from customertable order by code", conn)
        Dim D2 As SqlDataReader = Cmd2.ExecuteReader()
        While D2.Read
            ComboBox2.Items.Add(D2(0).ToString)

        End While
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd1 As New SqlCommand("select FlightType from FlightTable order by FlightType", conn)
        Dim D1 As SqlDataReader = Cmd1.ExecuteReader()
        While D1.Read
            ComboBox3.Items.Add(D1(0).ToString)
        End While
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("Select * From FlightDetailsTable where Source='" & ComboBox3.Text & "' and Destination='" & ComboBox4.Text & "' order by Flightno", conn)
        adp.Fill(DS1)
        DG1.DataSource = DS1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub

    Private Sub DG1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.SelectionChanged
        TextBox3.Text = DG1.CurrentRow.Cells(0).Value
    End Sub

    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select name,passport,email from CustomerTable where Code='" & ComboBox2.Text & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
            TextBox1.Text = D1(0).ToString
            TextBox2.Text = D1(1).ToString
            TextBox5.Text = D1(2).ToString


        Else
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox5.Text = ""

        End If
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
       
        SaveRecord()
       
    End Sub




    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        If ComboBox5.Text = "" Then Exit Sub


        If ComboBox5.Text = "Economy" Then
            SqlStr = "select EconomyPrice,EconomySeats from FlightDetailsTable where flightno='" & TextBox3.Text & "'"
        ElseIf ComboBox5.Text = "Business" Then
            SqlStr = "select BusinessPrice,BusinessSeats from FlightDetailsTable where flightno='" & TextBox3.Text & "'"
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd1 As New SqlCommand(SqlStr, conn)
        Dim D1 As SqlDataReader = Cmd1.ExecuteReader()
        If D1.Read Then
            TextBox4.Text = D1(0)
        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        EntriesMDI.Show()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Function Mail() As Object
        Throw New NotImplementedException
    End Function

End Class