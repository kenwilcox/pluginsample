// ClassPow.h

#pragma once

using namespace System;
using namespace PluginSample::Interfaces;

namespace Plugin5 {

	public ref class ClassPow: PluginSample::Interfaces::IPlugin
	{
	private:
		IHost^ _host;
	public:
		virtual double Calculate(int x, int y);
		virtual property System::String^ Name
		{
			String^ get() {return "Power (C++)";}
		}
		virtual void Initialize(IHost^ host);		
	};
}
