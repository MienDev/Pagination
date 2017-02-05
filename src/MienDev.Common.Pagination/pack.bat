rem build

rem pack
move ..\..\nupkg\*.* ..\..\nupkg\archive\ -Force
nuget pack -OutputDirectory ..\..\nupkg

rem push
cd ..\..\nupkg
nuget.exe push *.nupkg -Source https://www.nuget.org/api/v2/package
