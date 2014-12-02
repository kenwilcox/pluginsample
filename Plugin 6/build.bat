@echo off
REM This mess was hacked out by Ken
REM Compile
REM %WINDIR%\Microsoft.NET\Framework\v2.0.50727\jsc.exe /nologo /t:library /r:..\Interfaces\obj\Release\Interfaces.dll Plugin6.js
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\jsc.exe /nologo /t:library /r:..\Interfaces\obj\Release\Interfaces.dll Plugin6.js
REM move to our bin directory
IF NOT EXIST Plugin6.dll GOTO NOFILE
move Plugin6.dll ../bin
:NOFILE
REM Nothing