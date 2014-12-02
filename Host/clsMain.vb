Imports System.IO

Friend Class clsMain

    Public Shared Sub Main()
        Dim Plugins() As PluginServices.AvailablePlugin
        Dim Plugins2() As PluginServices.AvailablePlugin
        Dim objForm As frmMain

        'Get list of plugins
        Plugins = PluginServices.FindPlugins(Path.GetDirectoryName(Application.ExecutablePath), "PluginSample.Interfaces.IPlugin")
        If Plugins Is Nothing Then
            MessageBox.Show("No plugins found!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Plugins2 = PluginServices.FindPlugins(Path.GetDirectoryName(Application.ExecutablePath), "PluginSample.Interfaces.IPlugin2")

        'Load and show form
        objForm = New frmMain(Plugins, Plugins2)
        Application.Run(objForm)
    End Sub

End Class
