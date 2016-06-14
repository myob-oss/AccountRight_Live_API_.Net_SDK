@echo off

.\packages\coveralls.io.1.3.4\tools\coveralls.net.exe --opencover .\Artefacts\Coverage\output.xml

IF "%SONARQUBE_NEMO_TOKEN%" == "" goto TheEnd

rmdir /s /q .sonarqube

IF "%appveyor_build_version%" == "" set appveyor_build_version=1.0.0

rem /d:sonar.verbose=true
.\tools\sonarqube\runner\MSBuild.SonarQube.Runner.exe begin /d:sonar.verbose=true /d:sonar.login=%SONARQUBE_NEMO_TOKEN% /d:sonar.host.url=https://sonarqube.com/ /d:sonar.cs.opencover.reportsPaths=".\Artefacts\Coverage\output.xml" /n:"myob-sdk" /k:"myob-sdk" /v:"%appveyor_build_version%"
@IF ERRORLEVEL 1 exit /b

"%programfiles(x86)%\MSBuild\12.0\Bin\MSBuild.exe" MYOB.API.SDK.sln /p:Configuration=release /t:rebuild
@IF ERRORLEVEL 1 exit /b

.\tools\sonarqube\runner\MSBuild.SonarQube.Runner.exe end /d:sonar.login=%SONARQUBE_NEMO_TOKEN%
@IF ERRORLEVEL 1 exit /b

:TheEnd
