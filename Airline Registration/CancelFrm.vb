Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Text.RegularExpressions

Public Class CancelFrm
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select * from BookingTable where tStatus='N' and  bNo=" & Val(TextBox1.Text) & "", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.Read() Then
            SqlStr = "Flight No " & D1(3).ToString & vbCrLf & vbCrLf
            SqlStr = SqlStr & "Date " & D1(4).ToString & vbCrLf & vbCrLf
            SqlStr = SqlStr & "Seat Type " & D1(5).ToString & vbCrLf & vbCrLf
            SqlStr = SqlStr & "Ticket Price " & D1(6).ToString & vbCrLf & vbCrLf
            SqlStr = SqlStr & "email " & D1(10).ToString & vbCrLf & vbCrLf
            TextBox2.Text = SqlStr

        Else
            MsgBox("This ticket no not found")
            TextBox1.Text = ""

            If conn.State = ConnectionState.Open Then conn.Close()
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd1 As New SqlCommand("select email from BookingTable where tStatus='N' and  bNo=" & Val(TextBox1.Text) & "", conn)
        Dim D2 As SqlDataReader = Cmd1.ExecuteReader()
        If D2.Read() Then
            TextBox3.Text = D2(0).ToString
        End If

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        SqlStr = "update Bookingtable set tStatus='C' where bNo=" & Val(TextBox1.Text) & ""
        Dim cmd1 As New SqlCommand(SqlStr, conn)
        cmd1.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()


        TextBox7.AppendText("AirLine Reservation System" + vbNewLine)
        TextBox7.AppendText("----------------------------------------------------------" + vbNewLine)
        TextBox7.AppendText("Booking Cancelled..!" + vbNewLine)

        TextBox7.AppendText("ticket No: " + TextBox1.Text + vbNewLine)
        TextBox7.AppendText("----------------------------------------------------------" + vbNewLine)
        TextBox7.AppendText("Sorry...Ticekt Has Been Cancelled !" + vbNewLine)
        TextBox7.AppendText("----------------------------------------------------------" + vbNewLine)



        Dim Mail As New MailMessage
        Mail.Subject = "Booking Cancelled!!!"
        If TextBox3.Text = "" Then
            MsgBox("Please Enter The E-Mail Address", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Error!")
        End If
        Mail.To.Add(TextBox3.Text)
        Mail.From = New MailAddress("otpjava7@gmail.com")
        Mail.Body = TextBox7.Text


        Dim SMTP As New SmtpClient("smtp.gmail.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("otpjava7@gmail.com", "lucky2020Glo")
        SMTP.Port = "587"
        SMTP.Send(Mail)
        MsgBox(" Mail Sent")


        MsgBox("Ticket is cancelled")

    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        EntriesMDI.Show()
        Me.Hide()
    End Sub

    Private Sub CancelFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub



    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        If Not Regex.Match(TextBox1.Text, "^[0-9]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("Please enter Numbers only.")
            TextBox1.Text = ""
            TextBox1.Focus()
        End If
    End Sub



  
End Class