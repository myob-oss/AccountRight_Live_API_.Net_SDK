# using the SDK to talk to a local instance API i.e. http://localhost:8080/accountright

1. First fetch a list of company files e.g.

	C# Example:
		using MYOB.AccountRight.SDK;
		using MYOB.AccountRight.SDK.Services;
		using MYOB.AccountRight.SDK.Contracts;


		var configuration = new ApiConfiguration("http://localhost:8080/accountright");
		var cfService = new CompanyFileService(configuration);
		var companyFiles = cfService.GetRange();

	VB.Net Example:

		Imports MYOB.AccountRight.SDK
		Imports MYOB.AccountRight.SDK.Services
		Imports MYOB.AccountRight.SDK.Contracts

		Dim configuration = New ApiConfiguration("http://localhost:8080/accountright")
		Dim cfService = New CompanyFileService(configuration)
		Dim companyFiles = cfService.GetRange()


2. Select a Company File that supports version 2 of the AccountRight API e.g.

	C# Example:

		var companyFile = companyFiles.FirstOrDefault(x => new Version(x.ProductVersion) >= new Version("2013.3"));

	VB.Net Example:

		Dim companyFile = companyFiles.FirstOrDefault(Function(x) New Version(x.ProductVersion) >= New Version("2013.3"))

3. Use this company file to access resources i.e. fetch a list of accounts e.g.

	C# Example:

		var credentials = new CompanyFileCredentials("Administrator", "");
		var accountService = new AccountService(configuration);
		var accounts = accountService.GetRange(companyFile, null, credentials);

	VB.Net Example:

		Dim credentials = New CompanyFileCredentials("Administrator", "")
		Dim accountService = New AccountService(configuration)
		Dim accounts = accountService.GetRange(companyFile, Nothing, credentials)
			
 
# using the SDK to talk to a cloud instance API i.e. https://api.myob.com/accountright

1. Register an application

2. Get an code via the browser to allow your application to access your customer's Company File(s)

	var code = ....; // from browser bode (http://desktop) or request string during redirect

3. Using the code to get a set of OAuth tokens and store them away. Depending on your application you may need to implement you own IOAuthKeyService
to store your data in a location other than memory i.e. SessionState, IsolatedStorage.

	C# Example:
		using MYOB.AccountRight.SDK;
		using MYOB.AccountRight.SDK.Services;
		using MYOB.AccountRight.SDK.Contracts;

		var configuration = new ApiConfiguration("<<appid>>","<<appsecret>>","<<appredireturl>>");
		var oauthService = new OAuthService(configuration);
		var tokens = oauthService.GetTokens(code); 
		var keystore = new SimpleOAuthKeyService(); // SimpleOAuthKeyService must implement IOAuthKeyService
		keystore.OAuthResponse = tokens;

	VB.Net Example:

		Imports MYOB.AccountRight.SDK
		Imports MYOB.AccountRight.SDK.Services
		Imports MYOB.AccountRight.SDK.Contracts

		Dim configuration = New ApiConfiguration("<<appid>>","<<appsecret>>","<<appredireturl>>")
		Dim oauthService = New OAuthService(configuration)
		Dim tokens = oauthService.GetTokens(code)
		Dim keystore = new SimpleOAuthKeyService() ' SimpleOAuthKeyService must implement IOAuthKeyService
		keystore.OAuthResponse = tokens


4. Use the OAuthToken to access the customer's data

 
	C# Example:

		// get companyfiles
		var cfService = new CompanyFileService(configuration, null, keystore);
		var companyFiles = cfService.GetRange();
   
        	// select
		var companyFile = companyFiles.FirstOrDefault(x => new Version(x.ProductVersion) >= new Version("2013.3"));

		// fetch accounts
		var credentials = new CompanyFileCredentials("Administrator", "");
		var accountService = new GeneralLedger.AccountService(configuration, null, keystore);
		var accounts = accountService.GetRange(companyFile, null, credentials);


	VB.Net Example:

		' get companyfiles
		Dim cfService = new CompanyFileService(configuration, Nothing, keystore)
		Dim companyFiles = cfService.GetRange()
   
        	' select
		Dim companyFile = companyFiles.FirstOrDefault(Function(x) New Version(x.ProductVersion) >= New Version("2013.3"))

		' fetch accounts
		Dim credentials = New CompanyFileCredentials("Administrator", "")
		Dim accountService = New GeneralLedger.AccountService(configuration, Nothing, keystore)
		Dim accounts = accountService.GetRange(companyFile, Nothing, credentials)
