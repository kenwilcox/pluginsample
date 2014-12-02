Friend Class frmMain
    Inherits System.Windows.Forms.Form

    Private Plugins() As PluginServices.AvailablePlugin
    Private objHost As PluginSample.Interfaces.IHost

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Plugins() As PluginServices.AvailablePlugin)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Plugins = Plugins
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
        Me.lstPlugins = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumber1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumber2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.cmdCalculate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstPlugins
        '
        Me.lstPlugins.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
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
        Me.txtNumber1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtNumber1.Location = New System.Drawing.Point(244, 76)
        Me.txtNumber1.Name = "txtNumber1"
        Me.txtNumber1.Size = New System.Drawing.Size(88, 21)
        Me.txtNumber1.TabIndex = 2
        Me.txtNumber1.Text = "10"
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.Location = New System.Drawing.Point(244, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Number 1:"
        '
        'txtNumber2
        '
        Me.txtNumber2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtNumber2.Location = New System.Drawing.Point(404, 76)
        Me.txtNumber2.Name = "txtNumber2"
        Me.txtNumber2.Size = New System.Drawing.Size(88, 21)
        Me.txtNumber2.TabIndex = 2
        Me.txtNumber2.Text = "5"
        '
        'Label3
        '
        Me.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label3.Location = New System.Drawing.Point(404, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Number 2:"
        '
        'Label4
        '
        Me.Label4.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label4.Location = New System.Drawing.Point(244, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Result:"
        '
        'lblResult
        '
        Me.lblResult.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblResult.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.Location = New System.Drawing.Point(244, 204)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(244, 40)
        Me.lblResult.TabIndex = 1
        '
        'cmdCalculate
        '
        Me.cmdCalculate.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.cmdCalculate.Location = New System.Drawing.Point(308, 116)
        Me.cmdCalculate.Name = "cmdCalculate"
        Me.cmdCalculate.Size = New System.Drawing.Size(120, 28)
        Me.cmdCalculate.TabIndex = 3
        Me.cmdCalculate.Text = "Calculate"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(512, 299)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCalculate, Me.txtNumber1, Me.Label1, Me.lstPlugins, Me.Label2, Me.txtNumber2, Me.Label3, Me.Label4, Me.lblResult})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMain"
        Me.Text = "Plugin Sample"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PopulatePluginList()
        Dim objPlugin As PluginSample.Interfaces.IPlugin
        Dim intIndex As Integer

        'Loop through available plugins, creating instances and adding them to listbox
        For intIndex = 0 To Plugins.Length - 1
            objPlugin = DirectCast(PluginServices.CreateInstance(Plugins(intIndex)), PluginSample.Interfaces.IPlugin)
            lstPlugins.Items.Add(objPlugin.Name)
        Next

        lstPlugins.SelectedIndex = 0
    End Sub

    Private Sub cmdCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculate.Click
        Dim objPlugin As PluginSample.Interfaces.IPlugin
        Dim dblResult As Double

        'Create and initialize plugin
        objPlugin = DirectCast(PluginServices.CreateInstance(Plugins(lstPlugins.SelectedIndex)), PluginSample.Interfaces.IPlugin)
        objPlugin.Initialize(objHost)

        'Run calculation and return result
        Try
            dblResult = objPlugin.Calculate(Integer.Parse(txtNumber1.Text), Integer.Parse(txtNumber2.Text))
        Catch
            MessageBox.Show("Error performing calculation. Please ensure you have entered two integers in to the textboxes.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        lblResult.Text = dblResult.ToString()
    End Sub
End Class
