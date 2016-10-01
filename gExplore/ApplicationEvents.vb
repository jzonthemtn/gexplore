Imports NConsoler
Imports System.Runtime.InteropServices

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            Dim args() As String = Environment.GetCommandLineArgs()

            If args.Length > 1 Then

                ' Run in console mode.

                ConsoleAttach.AttachConsoleToGUI()

                'Trace.Listeners.Add(New ConsoleTraceListener())

                ' Handle the command line.
                Consolery.Run(GetType(gExplore.CommandLineActions), My.Application.CommandLineArgs.ToArray)

                ' Disconnect the console from the GUI.
                ConsoleAttach.FreeConsoleFromGUI()

                ' Exit.
                Environment.Exit(0)

            End If

        End Sub

    End Class


End Namespace

