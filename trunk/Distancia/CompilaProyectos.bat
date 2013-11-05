
@echo off
@echo *****************************************************************
@echo * Compila el proyecto Distancia y Test *
@echo *****************************************************************
set msbuild=C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\MSBuild

%msbuild% "Distancia\Distancia.csproj"                  /t:rebuild
%msbuild% "Test\Test.csproj"               /t:rebuild

rem @pause