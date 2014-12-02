// ClassLog.h

#pragma once

using namespace System;
using namespace PluginSample::Interfaces;

namespace Plugin5 {

	public ref class ClassLog: PluginSample::Interfaces::IPlugin2
	{
	private:
		IHost^ _host;
	public:
		virtual double Calculate(double x);
		virtual property System::String^ Name
		{
			String^ get() {return "Log (C++)";}
		}
		virtual void Initialize(IHost^ host);		
	};
}
