# dotnetAngular

 ##installasi <br>
dotnet new webapi -o MyAngularApp <br>
 #masuk kedalam folder yang sudah di create <br>
cd MyAngularApp <br>
 ##lalu create project angular di dalammnya <br>
ng new ClientApp <br>
 ##tambahkan library <br>
dotnet add package Microsoft.AspNetCore.SpaServices.Extensions <br>
dotnet add package Swashbuckle.AspNetCore <br>

 ##Ujicoba <br>
dotnet run <br>
ng build --configuration production <br>
ng serve <br>

 ##pastikan sudah terinstall .net sdk 8 dan node js 20 keatas <br>

 ##custom di Program.cs <br>


 ##Localhost untuk angular error solusi untuk <br>
  #Macbook <br>
netstat -ano | findstr :4200<br>
#Windows <br>
