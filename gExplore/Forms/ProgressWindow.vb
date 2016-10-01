Public Class ProgressWindow

    Private p_Maximum As Long
    Private p_Value As Integer

    Public Sub New(Description As String, Maximum As Integer)

        InitializeComponent()

        p_Maximum = Maximum

        StatusProgressBar.Minimum = 0
        StatusProgressBar.Maximum = Maximum
        StatusProgressBar.Value = 0

        StatusLabel.Text = Description

    End Sub

    ''' <summary>
    ''' Update the value to a fixed number.
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Sub UpdateProgess(Value As Integer)

        StatusProgressBar.Value = Value
        p_Value = Value

        PercentageCompleteLabel.Text = Math.Round((p_Value / p_Maximum) * 100, 0).ToString & "% complete"

    End Sub

    ''' <summary>
    ''' Increment the current value by a fixed number.
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Sub IncreaseProgress(Value As Integer)

        StatusProgressBar.Value = StatusProgressBar.Value + Value
        p_Value = p_Value + Value

        PercentageCompleteLabel.Text = Math.Round((p_Value / p_Maximum) * 100, 0).ToString & "% complete"

    End Sub

    Private Sub ProgressWindow_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class