@cls
set EnableNuGetPackageRestore=True
mkdir .\Artefacts\Coverage

.\.nuget\Nuget.exe install .\.nuget\packages.config -outputdirectory packages
.\.nuget\Nuget.exe restore MYOB.API.SDK.sln

powershell -file sdk.project.check.ps1
@IF ERRORLEVEL 1 exit /b

@IF NOT EXIST .\MYOB.API.SDK\SDK\MYOB.API.SDK.snk "%ProgramFiles(x86)%\Microsoft SDKs\Windows\v7.0A\Bin\sn.exe" -k .\MYOB.API.SDK\SDK\MYOB.API.SDK.snk
@IF ERRORLEVEL 1 exit /b

%systemroot%\microsoft.net\framework\v4.0.30319\MSBuild.exe MYOB.API.SDK.sln /p:Configuration=Release
@IF ERRORLEVEL 1 exit /b

.\packages\OpenCover.4.5.3207\OpenCover.Console.exe -register:user -filter:"+[MYOB.*]*" -skipautoprops -output:".\Artefacts\Coverage\output.xml" -target:".\packages\NUnit.Runners.2.6.3\tools\nunit-console.exe" -targetargs:".\Artefacts\SDK\Test\Release\SDK.Tests.dll /noshadow "
.\packages\ReportGenerator.1.9.1.0\ReportGenerator.exe -reports:.\Artefacts\Coverage\output.xml -targetdir:.\Artefacts\Coverage

IF "%appveyor_build_version%" == "" set appveyor_build_version = 1.0.0
.\.nuget\Nuget.exe pack MYOB.API.SDK\SDK.Package\Package.nuspec -Version %appveyor_build_version% -OutputDirectory .\Artefacts\Nuget\Release
.\.nuget\Nuget.exe pack MYOB.API.SDK\SDK.Package\Package.nuspec -Version %appveyor_build_version%-rc1 -OutputDirectory .\Artefacts\Nuget\Candidate

