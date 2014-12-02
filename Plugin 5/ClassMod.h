// ClassMod.h

#pragma once

using namespace System;
using namespace PluginSample::Interfaces;

namespace Plugin5 {

	public ref class ClassMod: PluginSample::Interfaces::IPlugin
	{
	private:
		IHost^ _host;
	public:
		virtual double Calculate(int x, int y);
		virtual property System::String^ Name
		{
			String^ get() {return "Mod (C++)";}
		}
		virtual void Initialize(IHost^ host);		
	};
}
