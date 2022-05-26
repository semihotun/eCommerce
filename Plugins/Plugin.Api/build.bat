dotnet build --force
xcopy /y bin\Debug\net5.0\Plugin.Api.dll  ..\..\..\eCommerce\eCommerce\bin\Debug\net5.0\
xcopy /y bin\Debug\net5.0\Plugin.Api.pdb  ..\..\..\eCommerce\eCommerce\bin\Debug\net5.0\
cmd /k