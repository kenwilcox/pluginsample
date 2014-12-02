[b]Introduction[/b]

Making your application plugin-aware is an excellent way of ensuring easy upgradability should you want to change part, but not all of it. While not every application is suitable, a good deal are. This tutorial is intended to follow up on one I did on how to write plugin-based apps in VB6, using COM.

Doing this in .NET is actually slightly easier than in COM, in my opinion, and far more powerful. For instance, getting your COM plugins to show an interface within a dialog shown by the host application was a bit of a nightmare, and required calls to SetParent and inventive use of window styles to get working properly. This is trivial in .NET because of the Windows Forms architecture. The process of opening and inspecting DLLs in .NET is much the same.

[b]Plugin Architecture[/b]

The best way to implement plugins in your application is with Interfaces. It is beyond the scope of this tutorial to explain interfaces, but they are in essence a contract. Any class implementing an interface must implement every member on the interface, so any application that knows about the interface knows exactly what to expect.

You start off by building a class library with the interface(s) in. Usually you would use at least two. The minimum you could have is one, which every plugin class would implement. However, in practice you generally need another interface, which the host implements so the plugins have some way of communicating back to the host application. When the interface class library has been built, you write the host application which references this library, and can inspect any number of DLLs to see if they contain classes that implement these interfaces. At this point you can develop the plugins themselves, again referencing the class library to implement those interfaces.

[b]Writing the Interfaces[/b]

First we create a new project of type Class Library, and define the two interfaces. For the purposes of this tutorial they will be very simple. Each plugin will offer a property with the name of the plugin, and a function which accepts two integers and returns a double. The host interface will expose a method so that the plugin can cause the host to show a message box.

When you create a project of type Class Library, there will be one class there by default. We want to clear this and define an interface rather than a class:

[vb]
Public Interface IPlugin

    Sub Initialize(ByVal Host As IHost)

    ReadOnly Property Name() As String

    Function Calculate(ByVal int1 As Integer, ByVal int2 As Integer) As Double

End Interface
[/vb]

[vb]
Public Interface IHost

    Sub ShowFeedback(ByVal strFeedback As String)

End Interface
[/vb]

Lastly we set the build output directory to a common directory, where we'll also put the host application and the plugins.

[b]Writing the first plugin[/b]

Since we'll need at least one to test the host application with, now we can write a simple plugin. Again, we create a new project of type Class Library, set the build output directory, and make sure we reference the interface class library we just created. Next, we modify the class provided thus:

[vb]
Public Class Class1
    Implements PluginSample.Interfaces.IPlugin

    Private objHost As PluginSample.Interfaces.IHost

    Public Sub Initialize(ByVal Host As PluginSample.Interfaces.IHost) Implements PluginSample.Interfaces.IPlugin.Initialize
        objHost = Host
    End Sub

    Public ReadOnly Property Name() As String Implements PluginSample.Interfaces.IPlugin.Name
        Get
            Return "Example Plugin 1 - Adds two numbers"
        End Get
    End Property

    Public Function Calculate(ByVal int1 As Integer, ByVal int2 As Integer) As Double Implements PluginSample.Interfaces.IPlugin.Calculate
        Return int1 + int2
    End Function
End Class
[/vb]

We've just created a simple plugin, which adds the two numbers provided together. Although we are accepting and storing a reference to the host interface, we don't actually use it. We'll do that in the next plugin we write.

[b]Writing the Host Application[/b]

We create a new project, of type Windows Application. The first thing to do is reference the class library we just created, and set the build output to the same directory.

The main content of this article is the process of examining DLLs to see if they contain plugins, storing the information about what plugins are available, and instantiating and using them. To do this, I will provide a class, PluginServices.vb, which will encapsulate all these things.

To get our list of plugins, we use the function FindPlugins which accepts a string containing the directory to search in, and a string with the full name of the interface we're looking for classes that implement. This function enumerates over all files with the extension .dll in the directory supplied, loads them using Assembly.LoadFrom() and passes execution to another function to examine the assembly.

[vb]
    Public Shared Function FindPlugins(ByVal strPath As String, ByVal strInterface As String) As AvailablePlugin()
        Dim Plugins As ArrayList = New ArrayList()
        Dim strDLLs() As String, intIndex As Integer
        Dim objDLL As [Assembly]

        'Go through all DLLs in the directory, attempting to load them
        strDLLs = Directory.GetFileSystemEntries(strPath, "*.dll")
        For intIndex = 0 To strDLLs.Length - 1
            Try
                objDLL = [Assembly].LoadFrom(strDLLs(intIndex))
                ExamineAssembly(objDLL, strInterface, Plugins)
            Catch e As Exception
                'Error loading DLL, we don't need to do anything special
            End Try
        Next

        'Return all plugins found
        Dim Results(Plugins.Count - 1) As AvailablePlugin

        If Plugins.Count <> 0 Then
            Plugins.CopyTo(Results)
            Return Results
        Else
            Return Nothing
        End If
    End Function
[/vb]

Once all files have been examined, the function returns an array of type AvailablePlugin if some were found, or Nothing if none were found. As you can see, this function calls ExamineAssembly to inspect a loaded assembly.

The ExamineAssembly enumerates all types exported by the loaded assembly, and uses the GetInterface() method of each type to see if it implements our interface. Conveniently, this method takes a string containing the fully qualified name of the interface. In this case, it's "PluginSample.Interfaces.IPlugin" we're looking for. If a type is found that implements the interface, an entry is added to the ArrayList with the full path of the DLL and the full name of the class.

[vb]
    Private Shared Sub ExamineAssembly(ByVal objDLL As [Assembly], ByVal strInterface As String, ByVal Plugins As ArrayList)
        Dim objType As Type
        Dim objInterface As Type
        Dim Plugin As AvailablePlugin

        'Loop through each type in the DLL
        For Each objType In objDLL.GetTypes
            'Only look at public types
            If objType.IsPublic = True Then
                'Ignore abstract classes
                If Not ((objType.Attributes And TypeAttributes.Abstract) = TypeAttributes.Abstract) Then

                    'See if this type implements our interface
                    objInterface = objType.GetInterface(strInterface, True)

                    If Not (objInterface Is Nothing) Then
                        'It does
                        Plugin = New AvailablePlugin()
                        Plugin.AssemblyPath = objDLL.Location
                        Plugin.ClassName = objType.FullName
                        Plugins.Add(Plugin)
                    End If

                End If
            End If
        Next
    End Sub
[/vb]

Lastly, we write the function that will be used to create an instance of a plugin where needed. It accepts an AvailablePlugin structure and returns an Object, to be casted to the appropriate type by the calling procedure.

[vb]
    Public Shared Function CreateInstance(ByVal Plugin As AvailablePlugin) As Object
        Dim objDLL As [Assembly]
        Dim objPlugin As Object

        Try
            'Load dll
            objDLL = [Assembly].LoadFrom(Plugin.AssemblyPath)

            'Create and return class instance
            objPlugin = objDLL.CreateInstance(Plugin.ClassName)
        Catch e As Exception
            Return Nothing
        End Try

        Return objPlugin
    End Function
[/vb]

That's about it for the PluginServices.vb file. The rest of the application is pretty simple. In the Sub Main, we call the FindPlugins method and populate a list on the form. The user can select a plugin from this list, and has the opportunity to enter two numbers and run the plugin to see what it returns.

One more thing is needed however, and that is to create the class in the host application which implements the IHost interface, and provides the plugins with a way of calling methods in the host application. For the purposes of this sample, the method will simply display a message box.

I won't go in to everything else in the host application, hopefully the code will explain itself. It's worth noting, however, that while in this sample we create an instance of a plugin each time we want to perform a calculation, usually the lifetime of a plugin object would be much longer.

[b]One more plugin[/b]

We will just write one more plugin, this time to multiply the two numbers. This one will also use the host interface to show a message box during calculation:

[vb]
Public Class Class1
    Implements PluginSample.Interfaces.IPlugin

    Private objHost As PluginSample.Interfaces.IHost

    Public Sub Initialize(ByVal Host As PluginSample.Interfaces.IHost) Implements PluginSample.Interfaces.IPlugin.Initialize
        objHost = Host
    End Sub

    Public ReadOnly Property Name() As String Implements PluginSample.Interfaces.IPlugin.Name
        Get
            Return "Example Plugin 2 - Multiplication"
        End Get
    End Property

    Public Function Calculate(ByVal int1 As Integer, ByVal int2 As Integer) As Double Implements PluginSample.Interfaces.IPlugin.Calculate
        objHost.ShowFeedback("Hello from Plugin 2!")
        Return int1 * int2
    End Function
End Class
[/vb]

That's about it. I've attached all the code that goes with this tutorial, feel free to use the PluginServices.vb file in your own applications. It shouldn't require any modification.