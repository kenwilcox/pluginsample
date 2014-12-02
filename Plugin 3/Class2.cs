using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginSample.Interfaces;

namespace Plugin_3
{
  public class Class2 : IPlugin2
  {
    private IHost _host;

    public void Initialize(IHost host)
    {
      _host = host;
    }

    public string Name
    {
      get { return "Square Root (C#)"; }
    }

    public Double Calculate(double x)
    {
      _host.ShowFeedback("Hello from C#!");
      return Math.Sqrt(x);// -y;
    }
  }
}
