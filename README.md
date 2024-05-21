| | |
| --- | --- |
| **Build** | [![Build status](https://img.shields.io/appveyor/ci/myob-developers/accountright-live-api-net-sdk.svg)](https://ci.appveyor.com/project/myob-developers/accountright-live-api-net-sdk) |
| **Coverage** | <sup>Coveralls</sup> [![Coverage](https://img.shields.io/coveralls/MYOB-Technology/AccountRight_Live_API_.Net_SDK/master.svg)](https://coveralls.io/r/MYOB-Technology/AccountRight_Live_API_.Net_SDK) |
| **Nuget Downloads** | [![Nuget](https://buildstats.info/nuget/MYOB.AccountRight.API.SDK)](http://nuget.org/packages/MYOB.AccountRight.API.SDK) |
| **Nuget Release** | [![Nuget](https://img.shields.io/nuget/v/MYOB.AccountRight.API.SDK.svg)](http://nuget.org/packages/MYOB.AccountRight.API.SDK) |
| **Nuget Latest** | [![Nuget](https://img.shields.io/nuget/vpre/MYOB.AccountRight.API.SDK.svg)](http://nuget.org/packages/MYOB.AccountRight.API.SDK) |

#AccountRight Live API .Net SDK#

This is the source repository for the MYOB AccountRight Live .Net SDK.

The official release of the SDK can be found on [NUGET](http://www.nuget.org/packages/MYOB.AccountRight.API.SDK/) and can be installed from Visual Studio using the Package Manager console.
    
    Install-Package MYOB.AccountRight.API.SDK

##Building##

The supplied batch file file `build.bat` can be used from a command prompt to build and test the SDK and will do the following:

1. Pull all required Nuget packages,
2. Generate a snk for personal use if one does not exist
2. Compile the SDK and test suite,
3. Execute all tests and generate coverage report.

##Usage##

C# Example:
		
    using MYOB.AccountRight.SDK;
    using MYOB.AccountRight.SDK.Services;
    using MYOB.AccountRight.SDK.Contracts;

    var configuration = new ApiConfiguration("http://localhost:8080/accountright");
    var cfService = new CompanyFileService(configuration);
    var companyFiles = cfService.GetRange();

##Publishing##

Publishing to [Nuget](http://nuget.org/packages/MYOB.AccountRight.API.SDK) is done via the [AppVeyor](https://ci.appveyor.com/project/myob-developers/accountright-live-api-net-sdk) build system.

To publish release-candidate create and merge from `master` to `candidate` branches.

To publish release create and merge from `master` to `release` branches.

##Contributions##

The code has been supplied to help developers who may not be able to use the NUGET package.

Community Contributions accepted.

##3rd Party Dependencies##

The MYOB SDK uses the following 3rd party (via NUGET) packages

1. [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json)
2. [Microsoft.Bcl.Async](https://www.nuget.org/packages/Microsoft.Bcl.Async)
2. [Microsoft.Bcl.Compression](https://www.nuget.org/packages/Microsoft.Bcl.Compression)
