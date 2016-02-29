@echo off

.\packages\coveralls.io.1.3.4\tools\coveralls.net.exe --opencover .\Artefacts\Coverage\output.xml

IF "%SONARQUBE_USER%" == "" goto TheEnd
IF "%SONARQUBE_PASSWORD%" == "" goto TheEnd

IF "%appveyor_build_version%" == "" set appveyor_build_version=1.0.0

.\tools\sonarqube\runner\MSBuild.SonarQube.Runner.exe begin /d:sonar.login=%SONARQUBE_USER% /d:sonar.password=%SONARQUBE_PASSWORD% /d:sonar.host.url=http://sonar.many-monkeys.com:9000  /d:sonar.cs.opencover.reportsPaths=".\Artefacts\Coverage\output.xml" /n:"myob-sdk" /k:"myob-sdk" /v:"%appveyor_build_version%"
@IF ERRORLEVEL 1 exit /b

"%programfiles(x86)%\MSBuild\12.0\Bin\MSBuild.exe" MYOB.API.SDK.sln /p:Configuration=release /t:rebuild
@IF ERRORLEVEL 1 exit /b

.\tools\sonarqube\runner\MSBuild.SonarQube.Runner.exe end
@IF ERRORLEVEL 1 exit /b

:TheEnd