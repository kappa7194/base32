git clean -d -f -x
dotnet build -c release
dotnet test -c release
dotnet pack -c release