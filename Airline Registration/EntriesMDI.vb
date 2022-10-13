Imports System.Windows.Forms

Public Class EntriesMDI


    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer


    Private Sub FileMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileMenu.Click
        PlaceFrm.Show()
        Me.Hide()
    End Sub

    Private Sub ToolsMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsMenu.Click
        FlightDetails.Show()
        Me.Hide()
    End Sub

    Private Sub ViewMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewMenu.Click
        CustomerFrm.show()
        Me.Hide()
    End Sub

    Private Sub CANCELTICKETSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANCELTICKETSToolStripMenuItem.Click
        CancelFrm.Show()
        Me.Hide()
    End Sub

    Private Sub HelpMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpMenu.Click
        BookingFrm.Show()
        Me.Hide()
    End Sub

    Private Sub BOOKEDTICKETSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOOKEDTICKETSToolStripMenuItem.Click
        BookedFrm.Show()
        Me.Hide()
    End Sub

    Private Sub CANCELLEDTICKETSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANCELLEDTICKETSToolStripMenuItem.Click
        CancelledFrm.Show()
        Me.Hide()
    End Sub

    Private Sub REPORTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REPORTToolStripMenuItem.Click

    End Sub


    Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub EntriesMDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub StaffRegistrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RegFrm.Show()
        Me.Hide()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        MsgBox("You sure want to logout ?")
        Me.Hide()
        StaffLogin.Show()
    End Sub
End Class
