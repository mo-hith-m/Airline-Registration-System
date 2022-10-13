Imports System.Data.SqlClient

Public Class Forgot

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
         If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim Cmd0 As New SqlCommand("select  Password from StaffRegTable where Name='" & TextBox1.Text & "'", conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()

            TextBox2.Text = D1(0).ToString
            Label2.Show()
            TextBox2.Show()

           

        Else
            MsgBox("Username not found")

       
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Label2.Hide()
        TextBox2.Hide()
        TextBox1.Text = ""
        TextBox2.Text = ""
        StaffLogin.Show()
    End Sub
End Class