
    ##installasi <br>
dotnet new webapi -o MyAngularApp <br>
 #masuk kedalam folder yang sudah di create <br>
cd MyAngularApp <br>
 ##lalu create project angular di dalammnya <br>
ng new ClientApp <br>
    ##tambahkan library <br>
    dotnet add package Microsoft.AspNetCore.SpaServices.Extensions <br>
    dotnet add package Swashbuckle.AspNetCore <br>
    dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL<br>
    dotnet tool install --global dotnet-ef <br>
    dotnet tool update --global dotnet-ef <br>
    dotnet add package Microsoft.EntityFrameworkCore <br>
    dotnet add package Microsoft.EntityFrameworkCore.Design <br>
    dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL <br>
    dotnet ef migrations add InitialCreate <br>
    dotnet ef database update<br>
    dotnet ef migrations add InitialCreate --context MyDbContext
dotnet ef database update --context MyDbContext
dotnet add package Swashbuckle.AspNetCore.Annotations


    
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
    netstat -ano | findstr :4200