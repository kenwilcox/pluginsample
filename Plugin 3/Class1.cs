using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginSample.Interfaces;

namespace Plugin_3
{
  public class Class1 : IPlugin
  {
    private IHost _host;

    public void Initialize(IHost host)
    {
      _host = host;
    }

    public string Name
    {
      get { return "Subtraction (C#)"; }
    }

    public Double Calculate(int x, int y)
    {
      return x - y;
    }
  }
}
