'I (see "about"), the copyright holder of this work, hereby publish it under the following licenses:
'Permission is granted to copy, distribute and/or modify this document under the terms of 
'the GNU Free Documentation License, Version 3.0 or any later version published by 
'the Free Software Foundation; with no Invariant Sections, no Front-Cover Texts, and no Back-Cover Texts. 
'A copy of the license is included in the section entitled GNU Free Documentation License. 

'About author: 
'Email: ilham92_sakura@yahoo.com 
'Webpage: http://www.animeclan.org/
'Facebook: https://www.facebook.com/anime4000

'Compiler optimization, and remove int overflow check.

Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set program icon from resources, save exe file space
        Me.Icon = My.Resources.RAM_Drive

        'Set program name with version in it
        Me.Text = My.Application.Info.Title & " " & System.String.Format("{0}.{1}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        Timer1.Start()
        Timer1.Interval = ComboBox1.Text

        'Adjust Progress animation
        ProgressBar1.MarqueeAnimationSpeed = ComboBox1.Text
        ProgressBar2.MarqueeAnimationSpeed = ComboBox1.Text

        'Show PC info at About tab
        Label16.Text = My.Computer.Info.OSFullName & My.Computer.Info.OSVersion & Environment.NewLine & My.Computer.Info.OSPlatform
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Progress Bar Section
        ProgressBar1.Maximum = Math.Round(My.Computer.Info.TotalPhysicalMemory / 1048576)
        ProgressBar1.Value = Math.Round(My.Computer.Info.AvailablePhysicalMemory / 1048576)
        ProgressBar2.Maximum = Math.Round(My.Computer.Info.TotalVirtualMemory / 1048576)
        ProgressBar2.Value = Math.Round(My.Computer.Info.AvailableVirtualMemory / 1048576)

        'RAM Section
        Label1.Text = "Installed: " & Math.Round(My.Computer.Info.TotalPhysicalMemory / 1048576, 2) & " MB"
        Label2.Text = "Used: " & Math.Round(My.Computer.Info.TotalPhysicalMemory / 1048576, 2) - Math.Round(My.Computer.Info.AvailablePhysicalMemory / 1048576, 2) & " MB"
        Label3.Text = "Free: " & Math.Round(My.Computer.Info.AvailablePhysicalMemory / 1048576, 2) & " MB"

        'Virtual Section
        Label4.Text = "Total: " & Math.Round(My.Computer.Info.TotalVirtualMemory / 1048576, 2) & " MB"
        Label5.Text = "Used: " & Math.Round(My.Computer.Info.TotalVirtualMemory / 1048576, 2) - Math.Round(My.Computer.Info.AvailableVirtualMemory / 1048576, 2) & " MB"
        Label6.Text = "Free: " & Math.Round(My.Computer.Info.AvailableVirtualMemory / 1048576, 2) & " MB"

        'Overall Section, display used and free percentage
        Label10.Text = "RAM: " & Math.Round((My.Computer.Info.AvailablePhysicalMemory / My.Computer.Info.TotalPhysicalMemory) * 100) & "% Free. " & Math.Round(((My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory) / My.Computer.Info.TotalPhysicalMemory) * 100) & "% Used."
        Label11.Text = "Virtual: " & Math.Round((My.Computer.Info.AvailableVirtualMemory / My.Computer.Info.TotalVirtualMemory) * 100) & "% Free. " & Math.Round(((My.Computer.Info.TotalVirtualMemory - My.Computer.Info.AvailableVirtualMemory) / My.Computer.Info.TotalVirtualMemory) * 100) & "% Used."
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Once button clicked, interval change
        Timer1.Interval = ComboBox1.Text

        'Adjust Progress animation
        ProgressBar1.MarqueeAnimationSpeed = ComboBox1.Text
        ProgressBar2.MarqueeAnimationSpeed = ComboBox1.Text
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://www.facebook.com/anime4000")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start("http://kyo-tux.deviantart.com/art/GiNUX-126818033")
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        System.Diagnostics.Process.Start("http://www.gnu.org/copyleft/gpl.html")
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = 1 Then
            Me.TopMost = True
        ElseIf CheckBox1.CheckState = 0 Then
            Me.TopMost = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = 1 Then
            ComboBox1.Enabled = False
            Button1.Enabled = False
            Timer1.Interval = 1
        ElseIf CheckBox2.CheckState = 0 Then
            ComboBox1.Enabled = True
            Button1.Enabled = True
            Timer1.Interval = ComboBox1.Text
        End If
    End Sub
End Class