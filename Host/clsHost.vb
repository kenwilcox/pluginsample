Friend Class clsHost
    Implements PluginSample.Interfaces.IHost
    Private _silent As Boolean

    Public WriteOnly Property Silent() As Boolean
        Set(ByVal value As Boolean)
            _silent = value
        End Set
    End Property

    Public Sub ShowFeedback(ByVal strFeedback As String) Implements PluginSample.Interfaces.IHost.ShowFeedback
        If Not _silent Then
            MessageBox.Show(strFeedback, Application.ProductName)
        End If
    End Sub
End Class
