// Learn more about F# at http://fsharp.net
#light  // I have no idea what this does
namespace Module1
open PluginSample.Interfaces // using...

type Plugin4() = // like class
  let mutable _host:IHost = null // member variable
  
  // Implement interface
  interface IPlugin with
    member this.Calculate(x, y) = 
      if(_host <> null) then
        _host.ShowFeedback("Hello from F#!")
      float(x/y)
    member this.Name = "Division (F#)"
    member this.Initialize(host) = this.Host <- host
  
  // Implement Accessor
  member this.Host
    with get() = _host
    and set(v) = _host <- v
    
  // TODO: Figure out how to call the host.ShowFeedback method