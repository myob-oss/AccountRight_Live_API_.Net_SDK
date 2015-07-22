#this checks that the target project has the same set of compile includes as the master file used for testing
function Check-Same-Compile-Includes {
  param([string] $srcfile, [string] $targetfile)

  Write-Host "Comparing the compile includes of $srcfile against $targetfile"
  $srcxml = [xml](gc $srcfile)
  $targetxml = [xml](gc $targetfile)
  
  $ns = @{'e'="http://schemas.microsoft.com/developer/msbuild/2003" }
  
  @(Select-Xml '//e:Compile' $srcxml -Namespace $ns) | 
		select -ExpandProperty Node | 
		? { $_.Include} | 
		select -ExpandProperty Include | where { $_ -ne 'Properties\AssemblyInfoEx.cs' } |
    % {
      $compile = $_
      @(Select-Xml "//e:Compile[@Include = '..\SDK\$_']" $targetxml -Namespace $ns) | Measure-Object |
      % { 
         if ($_.Count -ne 1) {
           Write-Host "The file '$compile' is missing from the project $targetfile. Please include and try again..."
           throw [System.InvalidOperationException] "The file '$compile' is missing from the project $targetfile. Please include and try again..."
         }
      }
    }
}

function Check-Same-Compile-Includes-Back {
  param([string] $srcfile, [string] $targetfile)

  Write-Host "Comparing the compile includes of $srcfile against $targetfile"
  $srcxml = [xml](gc $srcfile)
  $targetxml = [xml](gc $targetfile)
  
  $ns = @{'e'="http://schemas.microsoft.com/developer/msbuild/2003" }
  
  @(Select-Xml '//e:Link' $srcxml -Namespace $ns) | 
		select -ExpandProperty Node | 
		? { $_.Include} | 
		select -ExpandProperty Include | where { $_ -ne 'Properties\AssemblyInfoEx.cs' } |
    % {
      $compile = $_
      @(Select-Xml "//e:Compile[@Include = '$_']" $targetxml -Namespace $ns) | Measure-Object |
      % { 
         if ($_.Count -ne 1) {
           Write-Host "The file '$compile' is missing from the project $targetfile. Please include and try again..."
           throw [System.InvalidOperationException] "The file '$compile' is missing from the project $targetfile. Please include and try again..."
         }
      }
    }
}

try
{
  #check each of the project files against SDK.proj (i.e. all A in B and all B in A)
  Check-Same-Compile-Includes -srcfile '.\MYOB.API.SDK\SDK\SDK.csproj' -targetfile '.\MYOB.API.SDK\SDK.NET35\SDK.NET35.csproj'
  Check-Same-Compile-Includes-Back -srcfile '.\MYOB.API.SDK\SDK.NET35\SDK.NET35.csproj' -targetfile '.\MYOB.API.SDK\SDK\SDK.csproj'
  Check-Same-Compile-Includes -srcfile '.\MYOB.API.SDK\SDK\SDK.csproj' -targetfile '.\MYOB.API.SDK\SDK.NET40\SDK.NET40.csproj'
  Check-Same-Compile-Includes-Back -srcfile '.\MYOB.API.SDK\SDK.NET40\SDK.NET40.csproj' -targetfile '.\MYOB.API.SDK\SDK\SDK.csproj'
  Check-Same-Compile-Includes -srcfile '.\MYOB.API.SDK\SDK\SDK.csproj' -targetfile '.\MYOB.API.SDK\SDK.NET45\SDK.NET45.csproj'
  Check-Same-Compile-Includes-Back -srcfile '.\MYOB.API.SDK\SDK.NET45\SDK.NET45.csproj' -targetfile '.\MYOB.API.SDK\SDK\SDK.csproj'
}
catch [System.Exception]
{
  Write-Error $_.Message
  Exit 1
}
