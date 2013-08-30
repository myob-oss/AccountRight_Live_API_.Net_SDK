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


##Contributions##

The code has been supplied to help developers who may not be able to use the NUGET package.

Community Contributions requested.

##3rd Party Dependancies##

The MYOB SDK uses the following 3rd party (via NUGET) packages

1. [SharpCompress](https://github.com/adamhathcock/sharpcompress)
2. [JSON.NET](http://james.newtonking.com/projects/json-net.aspx)
3. [Bcl.Async](https://www.nuget.org/packages/Microsoft.Bcl.Async)
