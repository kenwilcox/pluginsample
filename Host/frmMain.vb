Friend Class frmMain
    Inherits System.Windows.Forms.Form

    Private Plugins() As PluginServices.AvailablePlugin
    Private Plugins2() As PluginServices.AvailablePlugin

    Friend WithEvents cbSilent As System.Windows.Forms.CheckBox
    Private objHost As clsHost 'PluginSample.Interfaces.IHost

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Plugins() As PluginServices.AvailablePlugin, ByVal Plugins2() As PluginServices.AvailablePlugin)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Plugins = Plugins
        Me.Plugins2 = Plugins2

        PopulatePluginList()

        objHost = New clsHost()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lstPlugins As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumber1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumber2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents cmdCalculate As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lstPlugins = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNumber1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNumber2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblResult = New System.Windows.Forms.Label
        Me.cmdCalculate = New System.Windows.Forms.Button
        Me.cbSilent = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'lstPlugins
        '
        Me.lstPlugins.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstPlugins.IntegralHeight = False
        Me.lstPlugins.Location = New System.Drawing.Point(12, 36)
        Me.lstPlugins.Name = "lstPlugins"
        Me.lstPlugins.Size = New System.Drawing.Size(196, 252)
        Me.lstPlugins.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Plugins:"
        '
        'txtNumber1
        '
        Me.txtNumber1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumber1.Location = New System.Drawing.Point(244, 76)
        Me.txtNumber1.Name = "txtNumber1"
        Me.txtNumber1.Size = New System.Drawing.Size(88, 21)
        Me.txtNumber1.TabIndex = 2
        Me.txtNumber1.Text = "10"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(244, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Number 1:"
        '
        'txtNumber2
        '
        Me.txtNumber2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumber2.Location = New System.Drawing.Point(404, 76)
        Me.txtNumber2.Name = "txtNumber2"
        Me.txtNumber2.Size = New System.Drawing.Size(88, 21)
        Me.txtNumber2.TabIndex = 2
        Me.txtNumber2.Text = "5"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(404, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Number 2:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(244, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Result:"
        '
        'lblResult
        '
        Me.lblResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResult.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.Location = New System.Drawing.Point(244, 204)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(244, 40)
        Me.lblResult.TabIndex = 1
        '
        'cmdCalculate
        '
        Me.cmdCalculate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCalculate.Location = New System.Drawing.Point(308, 116)
        Me.cmdCalculate.Name = "cmdCalculate"
        Me.cmdCalculate.Size = New System.Drawing.Size(120, 28)
        Me.cmdCalculate.TabIndex = 3
        Me.cmdCalculate.Text = "Calculate"
        '
        'cbSilent
        '
        Me.cbSilent.AutoSize = True
        Me.cbSilent.Location = New System.Drawing.Point(244, 258)
        Me.cbSilent.Name = "cbSilent"
        Me.cbSilent.Size = New System.Drawing.Size(103, 17)
        Me.cbSilent.TabIndex = 4
        Me.cbSilent.Text = "Silent Operation"
        Me.cbSilent.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(512, 299)
        Me.Controls.Add(Me.cbSilent)
        Me.Controls.Add(Me.cmdCalculate)
        Me.Controls.Add(Me.txtNumber1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstPlugins)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumber2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblResult)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Plugin Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub PopulatePluginList()
        Dim objPlugin As PluginSample.Interfaces.IPlugin
        Dim objPlugin2 As PluginSample.Interfaces.IPlugin2

        Dim intIndex As Integer

        'Loop through available plugins, creating instances and adding them to listbox
        For intIndex = 0 To Plugins.Length - 1
            objPlugin = DirectCast(PluginServices.CreateInstance(Plugins(intIndex)), PluginSample.Interfaces.IPlugin)
            lstPlugins.Items.Add(New InterfaceType(objPlugin.Name, 1))
        Next

        For intIndex = 0 To Plugins2.Length - 1
            objPlugin2 = DirectCast(PluginServices.CreateInstance(Plugins2(intIndex)), PluginSample.Interfaces.IPlugin2)
            lstPlugins.Items.Add(New InterfaceType(objPlugin2.Name, 2))
        Next

        lstPlugins.SelectedIndex = 0
    End Sub

    Private Sub cmdCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculate.Click
        Dim objPlugin As PluginSample.Interfaces.IPlugin
        Dim objPlugin2 As PluginSample.Interfaces.IPlugin2

        Dim dblResult As Double = 0
        Dim Msg As String = "I really don't like VB"
        'Create and initialize plugin depending on type
        Try
            Dim item As InterfaceType = DirectCast(lstPlugins.SelectedItem, InterfaceType)

            If item.IType = 1 Then
                Msg = "Error performing calculation. Please ensure you have entered two integers in to the textboxes."
                objPlugin = DirectCast(PluginServices.CreateInstance(Plugins(lstPlugins.SelectedIndex)), PluginSample.Interfaces.IPlugin)
                objPlugin.Initialize(objHost)
                dblResult = objPlugin.Calculate(Integer.Parse(txtNumber1.Text), Integer.Parse(txtNumber2.Text))
            Else
                Msg = "Error performing calculation. Please ensure you have entered a number into the textbox."
                objPlugin2 = DirectCast(PluginServices.CreateInstance(Plugins2(lstPlugins.SelectedIndex - Plugins.Length)), PluginSample.Interfaces.IPlugin2)
                objPlugin2.Initialize(objHost)
                dblResult = objPlugin2.Calculate(Double.Parse(txtNumber1.Text))
            End If
        Catch
            MessageBox.Show(Msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

        lblResult.Text = dblResult.ToString()
    End Sub

    Private Sub cbSilent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSilent.CheckedChanged
        objHost.Silent = cbSilent.Checked
    End Sub

    Private Sub lstPlugins_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPlugins.SelectedIndexChanged
        'Get the InterfaceType for the selected Item
        Dim item As InterfaceType = DirectCast(lstPlugins.SelectedItem, InterfaceType)
        txtNumber2.Enabled = item.IType <> 2
    End Sub
End Class

Friend Class InterfaceType
    Public Name As String
    Public IType As Integer

    Public Sub New(ByVal Name As String, ByVal IType As Integer)
        Me.Name = Name
        Me.IType = IType
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Name
    End Function
End Class