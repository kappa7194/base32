@ECHO OFF
NuGet.exe Update -Self
NuGet.exe Pack ..\Albireo.Base32\Albireo.Base32.csproj -Prop Configuration=Release
