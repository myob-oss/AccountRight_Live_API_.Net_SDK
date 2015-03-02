[![Build status](https://img.shields.io/appveyor/ci/sawilde/accountright-live-api-net-sdk.svg)](https://ci.appveyor.com/project/sawilde/accountright-live-api-net-sdk)
[![Coverage](https://img.shields.io/coveralls/MYOB-Technology/AccountRight_Live_API_.Net_SDK/master.svg)](https://coveralls.io/r/MYOB-Technology/AccountRight_Live_API_.Net_SDK)

Nuget Downloads: [![Nuget](https://img.shields.io/nuget/dt/MYOB.AccountRight.API.SDK.svg)](http://nuget.org/packages/MYOB.AccountRight.API.SDK)

Nuget Release:   [![Nuget](https://img.shields.io/nuget/v/MYOB.AccountRight.API.SDK.svg)](http://nuget.org/packages/MYOB.AccountRight.API.SDK)

Nuget Latest:    [![Nuget](https://img.shields.io/nuget/vpre/MYOB.AccountRight.API.SDK.svg)](http://nuget.org/packages/MYOB.AccountRight.API.SDK)

#AccountRight Live API .Net SDK#

[![Join the chat at https://gitter.im/MYOB-Technology/AccountRight_Live_API_.Net_SDK](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/MYOB-Technology/AccountRight_Live_API_.Net_SDK?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

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


##Contributions##

The code has been supplied to help developers who may not be able to use the NUGET package.

Community Contributions requested.

##3rd Party Dependancies##

The MYOB SDK uses the following 3rd party (via NUGET) packages

1. [SharpCompress](https://github.com/adamhathcock/sharpcompress)
2. [JSON.NET](http://james.newtonking.com/projects/json-net.aspx)
3. [Bcl.Async](https://www.nuget.org/packages/Microsoft.Bcl.Async)
