Imports System.Net.NetworkInformation

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    End Sub 'DisplayDnsConfiguration

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
            'TextBox1.Text = cadenaSalida
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
            'TextBox1.Text = cadenaSalida
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
End Class
