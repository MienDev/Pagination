rem build

rem pack
move ..\..\nupkg\*.* ..\..\nupkg\archieve\
nuget pack -OutputDirectory ..\..\nupkg

rem push
cd ..\..\nupkg
nuget.exe push *.nupkg -Source https://www.nuget.org/api/v2/package
