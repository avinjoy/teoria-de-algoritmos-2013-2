@echo off
set msbuild=C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\MSBuild
"%msbuild%" NUnit.build >> .\Log\Log.txt
@pause

