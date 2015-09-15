<Query Kind="Statements">
  <NuGetReference>MYOB.AccountRight.API.SDK</NuGetReference>
  <Namespace>MYOB.AccountRight.SDK</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Communication</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.Banking</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.Company</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.Contact</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.Inventory</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.Payroll</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.Purchase</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.Report.Payroll</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.Sale</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.Security</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Contracts.Version2.TimeBilling</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Extensions</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.Banking</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.Company</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.Contact</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.GeneralLedger</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.Inventory</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.Payroll</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.PayrollCategory</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.Purchase</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.Report.Payroll</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.Sale</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.Security</Namespace>
  <Namespace>MYOB.AccountRight.SDK.Services.TimeBilling</Namespace>
</Query>

// set up the configuration for working against a local CF
var configuration = new ApiConfiguration("http://localhost:8080/accountright");

// get all company files 
var cfService = new CompanyFileService(configuration);
var companyFiles = cfService.GetRange();

// get the target company file (this is a sample CF)
var cwtr = companyFiles.First(c => c.ProductVersion == "2015.3" && c.LibraryPath.Contains("Clearwater_Plus_AU"));
cwtr.Dump();

// list the accounts (now we need some credentials)
var credentials = new CompanyFileCredentials("Administrator","");
var accounts = new AccountService(configuration).GetRange(cwtr, null, credentials);
accounts.Dump();
