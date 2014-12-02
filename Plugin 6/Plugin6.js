// Yep, this is javascript baby!

// helps from
// http://archive.devx.com/dotnet/resources/JScriptNET/quickstart_external.html
// http://www.phpied.com/make-your-javascript-a-windows-exe/

import System;                  // needed for var types
import PluginSample.Interfaces; // needed for interfaces

package Plugin6 {
  
  class ClassDouble implements IPlugin2
  {
    var _host: IHost;
    
    function Initialize(host: IHost)
    {
      _host = host;
    }
    
    function get Name(): String
    {
      return "Double (JS)";
    }
    
    function Calculate(number: Double): Double
    {
      _host.ShowFeedback("Hello from JavaScript!");
      return number * number;
    }
  }

  class ClassPow implements IPlugin
  {
    var _host: IHost;
    
    function Initialize(host: IHost)
    {
      _host = host;
    }
    
    function get Name(): String
    {
      return "Power (JS)";
    }
    
    function Calculate(n1: Int32, n2: Int32): Double
    {
      _host.ShowFeedback("Hello from JavaScript!");
      return Math.pow(n1, n2);
    }
  }
  
  class ClassCeil implements IPlugin2
  {
    var _host: IHost;
    
    function Initialize(host: IHost)
    {
      _host = host;
    }
    
    function get Name(): String
    {
      return "Ceiling (JS)";
    }
    
    function Calculate(number: Double): Double
    {
      _host.ShowFeedback("Hello from JavaScript!");
      return Math.ceil(number);
    }
  }

  
  class ClassFloor implements IPlugin2
  {
    var _host: IHost;
    
    function Initialize(host: IHost)
    {
      _host = host;
    }
    
    function get Name(): String
    {
      return "Floor (JS)";
    }
    
    function Calculate(number: Double): Double
    {
      _host.ShowFeedback("Hello from JavaScript!");
      return Math.floor(number);
    }
  }

  class ClassCos implements IPlugin2
  {
    var _host: IHost;
    
    function Initialize(host: IHost)
    {
      _host = host;
    }
    
    function get Name(): String
    {
      return "Cosine (JS)";
    }
    
    function Calculate(number: Double): Double
    {
      _host.ShowFeedback("Hello from JavaScript!");
      return Math.cos(number);
    }
  }

  class ClassSin implements IPlugin2
  {
    var _host: IHost;
    
    function Initialize(host: IHost)
    {
      _host = host;
    }
    
    function get Name(): String
    {
      return "Sine (JS)";
    }
    
    function Calculate(number: Double): Double
    {
      _host.ShowFeedback("Hello from JavaScript!");
      return Math.sin(number);
    }
  }
  
  class ClassAtan2 implements IPlugin
  {
    var _host: IHost;
    
    function Initialize(host: IHost)
    {
      _host = host;
    }
    
    function get Name(): String
    {
      return "Arctangent Quotient (JS)";
    }
    
    function Calculate(n1: Int32, n2: Int32): Double
    {
      _host.ShowFeedback("Hello from JavaScript!");
      return Math.atan2(n1, n2);
    }
  }

  class ClassAtan implements IPlugin2
  {
    var _host: IHost;
    
    function Initialize(host: IHost)
    {
      _host = host;
    }
    
    function get Name(): String
    {
      return "Arctangent (JS)";
    }
    
    function Calculate(number: Double): Double
    {
      _host.ShowFeedback("Hello from JavaScript!");
      return Math.atan(number);
    }
  }

  class ClassTan implements IPlugin2
  {
    var _host: IHost;
    
    function Initialize(host: IHost)
    {
      _host = host;
    }
    
    function get Name(): String
    {
      return "Tangent (JS)";
    }
    
    function Calculate(number: Double): Double
    {
      _host.ShowFeedback("Hello from JavaScript!");
      return Math.tan(number);
    }
  }
  
}