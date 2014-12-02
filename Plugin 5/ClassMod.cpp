#include "StdAfx.h"
#include <math.h>
#include "ClassMod.h"

namespace Plugin5 {
  
  double ClassMod::Calculate(int x, int y)
  {
    _host->ShowFeedback("Hello from Managed C++!");
    return fmod((double)x, (double)y);
  }
    
  void ClassMod::Initialize(IHost^ host)
  {
    _host = host;
  }
}