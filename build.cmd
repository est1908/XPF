@ECHO OFF
SET config=%1
IF "%config%" == "" (
   SET config=Debug
)

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild build.proj /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

PAUSE