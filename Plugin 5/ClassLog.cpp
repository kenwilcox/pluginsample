#include "StdAfx.h"
#include <math.h>
#include "ClassLog.h"

namespace Plugin5 {
  
  double ClassLog::Calculate(double x)
  {
    _host->ShowFeedback("Hello from Managed C++!");
    return log(x);
  }
    
  void ClassLog::Initialize(IHost^ host)
  {
    _host = host;
  }
}