Imports System.Net.NetworkInformation

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "AutoIPChanger v" + Application.ProductVersion
        DisplayDnsConfiguration()
        ComboBox1.SelectedIndex = 0
    End Sub

    Public Sub DisplayDnsConfiguration()
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            ComboBox1.Items.Add(adapter.Name)
        Next adapter
    End Sub

    Private Sub RunCommandStatic(ipaddress As String, subred As String)
        Dim strArgumentos As String = "interface ip set address " & Chr(34) & ComboBox1.Text & Chr(34) & " static " & ipaddress & " " & subred
        Dim strExe As String = "netsh"
        Dim startInfo As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo(strExe, strArgumentos)
        startInfo.UseShellExecute = False
        startInfo.ErrorDialog = False
        startInfo.CreateNoWindow = True
        startInfo.RedirectStandardOutput = True
        Try
            Dim p As Diagnostics.Process = System.Diagnostics.Process.Start(startInfo)
            Dim sr As System.IO.StreamReader = p.StandardOutput
            Dim cadenaSalida As String = sr.ReadToEnd()
            sr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RunCommandDinamic()
        Dim strArgumentos As String = "interface ip set address " & Chr(34) & ComboBox1.Text & Chr(34) & " dhcp"
        Dim strExe As String = "netsh"
        Dim startInfo As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo(strExe, strArgumentos)
        startInfo.UseShellExecute = False
        startInfo.ErrorDialog = False
        startInfo.CreateNoWindow = True
        startInfo.RedirectStandardOutput = True
        Try
            Dim p As Diagnostics.Process = System.Diagnostics.Process.Start(startInfo)
            Dim sr As System.IO.StreamReader = p.StandardOutput
            Dim cadenaSalida As String = sr.ReadToEnd()
            sr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RunCommandDNS1(dns1 As String)
        Dim strArgumentos As String = "interface ip add dns name=" & Chr(34) & ComboBox1.Text & Chr(34) & " static " & dns1
        Dim strExe As String = "netsh"
        Dim startInfo As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo(strExe, strArgumentos)
        startInfo.UseShellExecute = False
        startInfo.ErrorDialog = False
        startInfo.CreateNoWindow = True
        startInfo.RedirectStandardOutput = True
        Try
            Dim p As Diagnostics.Process = System.Diagnostics.Process.Start(startInfo)
            Dim sr As System.IO.StreamReader = p.StandardOutput
            Dim cadenaSalida As String = sr.ReadToEnd()
            sr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RunCommandDNS2(dns2 As String)
        Dim strArgumentos As String = "interface ip add dns name=" & Chr(34) & ComboBox1.Text & Chr(34) & " static " & dns2 & " index=1"
        Dim strExe As String = "netsh"
        Dim startInfo As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo(strExe, strArgumentos)
        startInfo.UseShellExecute = False
        startInfo.ErrorDialog = False
        startInfo.CreateNoWindow = True
        startInfo.RedirectStandardOutput = True
        Try
            Dim p As Diagnostics.Process = System.Diagnostics.Process.Start(startInfo)
            Dim sr As System.IO.StreamReader = p.StandardOutput
            Dim cadenaSalida As String = sr.ReadToEnd()
            sr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RunCommandStatic("192.168.1.200", "255.255.255.0")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RunCommandDinamic()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RunCommandStatic(txtIP.Text, txtSubNet.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RunCommandStatic("192.168.0.200", "255.255.255.0")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        RunCommandStatic("192.168.2.200", "255.255.255.0")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RunCommandStatic("192.168.88.200", "255.255.255.0")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RunCommandDNS1("8.8.8.8")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        RunCommandDNS2("8.8.4.4")
    End Sub
End Class
