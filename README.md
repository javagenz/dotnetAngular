# Panduan Instalasi MyAngularApp

## Prasyarat
- .NET SDK 8
- Node.js 20 atau lebih tinggi

## Langkah-Langkah untuk Mengatur Proyek

1. **Buat proyek ASP.NET Core Web API baru**
    ```sh
    dotnet new webapi -o MyAngularApp
    ```

2. **Masuk ke folder yang telah dibuat**
    ```sh
    cd MyAngularApp
    ```

3. **Buat proyek Angular di dalam proyek ASP.NET Core**
    ```sh
    ng new ClientApp
    ```

4. **Tambahkan library yang diperlukan**
    ```sh
    dotnet add package Microsoft.AspNetCore.SpaServices.Extensions
    dotnet add package Swashbuckle.AspNetCore
    dotnet add package Swashbuckle.AspNetCore.Annotations
    dotnet tool install --global dotnet-ef
    dotnet tool update --global dotnet-ef

    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

    dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
    dotnet add package Microsoft.IdentityModel.Tokens
    ```

5. **Buat migrasi database awal**
    ```sh
    dotnet ef migrations add InitialCreate
    ```

6. **Terapkan migrasi ke database**
    ```sh
    dotnet ef database update
    ```

7. **Abaikan perintah berikut untuk sekarang**
    ```sh
    dotnet ef migrations add InitialCreate --context MyDbContext
    dotnet ef database update --context MyDbContext
    ```

## Menjalankan Proyek

1. **Jalankan aplikasi .NET**
    ```sh
    dotnet run
    ```

2. **Build Project Angular**
    ```sh
    ng build --configuration production
    ```

3. **Jalankan proyek Angular**
    ```sh
    ng serve
    ```

## Pemecahan Masalah

### Kesalahan Localhost untuk Angular

#### Pada MacBook
```sh
netstat -ano | findstr :4200
