Public Interface IPlugin2

    Sub Initialize(ByVal Host As IHost)

    ReadOnly Property Name() As String

    Function Calculate(ByVal int1 As Double) As Double

End Interface
