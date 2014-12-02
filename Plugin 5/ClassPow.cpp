#include "StdAfx.h"
#include <math.h>
#include "ClassPow.h"

namespace Plugin5 {

	double ClassPow::Calculate(int x, int y)
	{
		_host->ShowFeedback("Hello from Managed C++!");
		return pow((double)x, (double)y);
	}

	void ClassPow::Initialize(IHost^ host)
	{
		_host = host;
	}
}