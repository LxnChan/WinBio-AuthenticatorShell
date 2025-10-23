Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmMain
    ' FingerPrint A
    Private fpA As String = ""
    ' FingerPrint B
    Private fpB As String = ""
    ' StartPorcess
    Private sppath As String = ""

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadConfig()
        Timer1.Interval = 1000 ' Check every second
        Timer1.Start()
    End Sub

    Private Sub LoadConfig()
        Try
            Dim configPath As String = Path.Combine(Application.StartupPath, "config.json")
            If File.Exists(configPath) Then
                Dim jsonText As String = File.ReadAllText(configPath)
                Dim config As JObject = JObject.Parse(jsonText)

                fpA = config("fpA")?.ToString()
                fpB = config("fpB")?.ToString()
                sppath = config("sppath")?.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to load config: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAAuth_Click(sender As Object, e As EventArgs) Handles btnAAuth.Click
        AuthenticateFingerprint(fpA, staLabelA)
        staLabelCurrentID.Text = "Ready"
    End Sub

    Private Sub btnBAuth_Click(sender As Object, e As EventArgs) Handles btnBAuth.Click
        AuthenticateFingerprint(fpB, staLabelB)
        staLabelCurrentID.Text = "Ready"
    End Sub

    Private Sub AuthenticateFingerprint(expectedFpId As String, statusLabel As Label)
        Dim subFactor As Byte = 0
        Dim unitId As UInteger = 0UI
        Dim hr As Integer = 0
        Dim ok As Boolean = IdentifyCurrentFingerprint(subFactor, unitId, hr)

        If ok Then
            Dim capturedFpId As String = subFactor.ToString()
            If capturedFpId = expectedFpId Then
                statusLabel.Text = "Pass"
                statusLabel.ForeColor = Color.Green
            Else
                statusLabel.Text = "Not Pass"
                statusLabel.ForeColor = Color.Red
            End If
        Else
            statusLabel.Text = "Error"
            statusLabel.ForeColor = Color.Red
        End If

        ' Check authentication status after each authentication attempt
        CheckAuthenticationStatus()
    End Sub

    Private Sub lblTips1_Click(sender As Object, e As EventArgs) Handles lblTips1.Click

        Dim subFactor As Byte = 0
        Dim unitId As UInteger = 0UI
        Dim hr As Integer = 0
        Dim ok As Boolean = IdentifyCurrentFingerprint(subFactor, unitId, hr)
        If ok Then
            staLabelCurrentID.Text = "Ready"
            Dim name As String = FingerSubFactorToName(subFactor)
            staLabelCurrentID.Text = $"{name} (Unit {unitId})"
        Else
            staLabelCurrentID.Text = $"Error: 0x{hr:X8}"
        End If
    End Sub

    Private Sub btnLaunch_Click(sender As Object, e As EventArgs) Handles btnLaunch.Click
        Try
            Process.Start(sppath)
        Catch ex As Exception
            MessageBox.Show($"Failed to launch application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CheckAuthenticationStatus()
    End Sub

    Private Sub CheckAuthenticationStatus()
        Dim bothPass As Boolean = (staLabelA.Text = "Pass" AndAlso staLabelB.Text = "Pass")
        btnLaunch.Enabled = bothPass
    End Sub

    Private Sub staLabelCurrentID_Click(sender As Object, e As EventArgs) Handles staLabelCurrentID.Click
        If staLabelCurrentID.Text = "Error: 0x80098003" Then
            MsgBox("WINBIO_E_BAD_CAPTURE" & vbCrLf & "指纹样本捕获失败", vbCritical, "Failed")
        ElseIf staLabelCurrentID.Text = "Error: 0x80098008" Then
            MsgBox("WINBIO_E_NO_MATCH" & vbCrLf & "指纹读取成功，但与已注册的任何指纹模板都不匹配", vbCritical, "Failed")
        End If
    End Sub
End Class
