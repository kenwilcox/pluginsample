Friend Class clsHost
    Implements PluginSample.Interfaces.IHost

    Public Sub ShowFeedback(ByVal strFeedback As String) Implements PluginSample.Interfaces.IHost.ShowFeedback
        MessageBox.Show(strFeedback, Application.ProductName)
    End Sub
End Class
