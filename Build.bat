PUSHD otp
git reset --hard
git clean -d -f -x
NuGet.exe Restore Albireo.Base32.sln
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe Albireo.Base32.sln /property:Configuration=Debug /maxcpucount /nodeReuse:false
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe Albireo.Base32.sln /property:Configuration=Release /maxcpucount /nodeReuse:false
NuGet.exe Pack Albireo.Base32\Albireo.Base32.csproj -Prop Configuration=Release -Symbols
POPD
PAUSE
