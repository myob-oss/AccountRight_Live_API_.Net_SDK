set EnableNuGetPackageRestore=True
mkdir .\Artefacts\Coverage

.\.nuget\Nuget.exe install .\.nuget\packages.config -outputdirectory packages
%systemroot%\microsoft.net\framework\v4.0.30319\MSBuild.exe MYOB.API.SDK.sln

.\packages\OpenCover.4.5.1604\OpenCover.Console.exe -register:user -filter:"+[MYOB.*]*" -output:".\Artefacts\Coverage\output.xml" -target:".\packages\NUnit.Runners.2.6.2\tools\nunit-console.exe" -targetargs:".\Artefacts\SDK\Test\Debug\SDK.Tests.dll /noshadow "
.\packages\ReportGenerator.1.9.0.0\ReportGenerator.exe -reports:.\Artefacts\Coverage\output.xml -targetdir:.\Artefacts\Coverage

