@cls
set EnableNuGetPackageRestore=True
mkdir .\Artefacts\Coverage

.\.nuget\Nuget.exe install .\.nuget\packages.config -outputdirectory packages
.\.nuget\Nuget.exe restore MYOB.API.SDK.sln

@IF NOT EXIST .\MYOB.API.SDK\SDK\MYOB.API.SDK.snk "%ProgramFiles(x86)%\Microsoft SDKs\Windows\v7.0A\Bin\sn.exe" -k .\MYOB.API.SDK\SDK\MYOB.API.SDK.snk
@if ERRORLEVEL 1 exit

%systemroot%\microsoft.net\framework\v4.0.30319\MSBuild.exe MYOB.API.SDK.sln
@if ERRORLEVEL 1 exit

.\packages\OpenCover.4.5.1923\OpenCover.Console.exe -register:user -filter:"+[MYOB.*]*" -skipautoprops -output:".\Artefacts\Coverage\output.xml" -target:".\packages\NUnit.Runners.2.6.2\tools\nunit-console.exe" -targetargs:".\Artefacts\SDK\Test\Debug\SDK.Tests.dll /noshadow "
.\packages\ReportGenerator.1.9.0.0\ReportGenerator.exe -reports:.\Artefacts\Coverage\output.xml -targetdir:.\Artefacts\Coverage

.\.nuget\Nuget.exe pack MYOB.API.SDK\SDK.Package\Package.nuspec
