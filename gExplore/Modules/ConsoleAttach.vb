Imports NConsoler
Imports System.Runtime.InteropServices

Module ConsoleAttach

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Function AllocConsole() As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("kernel32.dll")> _
    Private Function AttachConsole(dwProcessId As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, ExactSpelling:=True)> _
    Private Function FreeConsole() As Boolean
    End Function

    Private Const ATTACH_PARENT_PROCESS As Integer = -1

    Public Sub AttachConsoleToGUI()
        AttachConsole(ATTACH_PARENT_PROCESS)
    End Sub

    Public Sub FreeConsoleFromGUI()
        FreeConsole()
    End Sub

End Module
