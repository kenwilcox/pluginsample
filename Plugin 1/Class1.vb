Public Class Class1
    Implements PluginSample.Interfaces.IPlugin

    Private objHost As PluginSample.Interfaces.IHost

    Public Sub Initialize(ByVal Host As PluginSample.Interfaces.IHost) Implements PluginSample.Interfaces.IPlugin.Initialize
        objHost = Host
    End Sub

    Public ReadOnly Property Name() As String Implements PluginSample.Interfaces.IPlugin.Name
        Get
            Return "Addition (VB.NET)"
        End Get
    End Property

    Public Function Calculate(ByVal int1 As Integer, ByVal int2 As Integer) As Double Implements PluginSample.Interfaces.IPlugin.Calculate
        Return int1 + int2
    End Function
End Class
