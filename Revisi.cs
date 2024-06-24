// // using Microsoft.AspNetCore.Builder;
// // using Microsoft.EntityFrameworkCore;
// // using Microsoft.Extensions.DependencyInjection;
// // using Microsoft.OpenApi.Models;
// // using MyAngularApp.Data;
// // using MyAngularApp.Services;

// // var builder = WebApplication.CreateBuilder(args);

// // // Konfigurasi DbContext untuk PostgreSQL
// // builder.Services.AddDbContext<MyDbContext>(options =>
// //     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// // // Registrasi layanan IProfilService dan ProfilService
// // builder.Services.AddScoped<IProfilService, ProfilService>();

// // // Tambahkan Swagger
// // builder.Services.AddSwaggerGen(c =>
// // {
// //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
// //     c.EnableAnnotations();
// // });

// // var app = builder.Build();

// // // Konfigurasi HTTP request pipeline
// // if (app.Environment.IsDevelopment())
// // {
// //     // Developer exception page
// //     app.UseDeveloperExceptionPage();

// //     // Swagger UI
// //     app.UseSwagger();
// //     app.UseSwaggerUI(c =>
// //     {
// //         c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
// //     });
// // }
// // else
// // {
// //     // Exception handler and HSTS for production
// //     app.UseExceptionHandler("/Error");
// //     app.UseHsts();
// // }

// // // Redirect HTTP to HTTPS
// // app.UseHttpsRedirection();

// // // Routing configuration
// // app.UseRouting();

// // // Authorization
// // app.UseAuthorization();

// // // Endpoint mapping for controllers
// // app.MapControllers();

// // // Default route and SPA fallback
// // app.MapFallbackToFile("index.html");

// // // Configuration for SPA
// // app.UseSpa(spa =>
// // {
// //     spa.Options.SourcePath = "ClientApp";
// //     if (app.Environment.IsDevelopment())
// //     {
// //         spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
// //     }
// // });

// // // Run the application
// // app.Run();

// using Microsoft.EntityFrameworkCore;
// using Microsoft.OpenApi.Models;
// using MyAngularApp.Data;
// using MyAngularApp.Services;

// var builder = WebApplication.CreateBuilder(args);

// // Konfigurasi DbContext untuk PostgreSQL
// builder.Services.AddDbContext<MyDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// // Registrasi layanan IProfilService dan ProfilService
// builder.Services.AddScoped<IProfilService, ProfilService>();

// // Tambahkan Swagger
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
// });

// var app = builder.Build();

// // Konfigurasi HTTP request pipeline
// if (app.Environment.IsDevelopment())
// {
//     // Developer exception page
//     app.UseDeveloperExceptionPage();

//     // Swagger UI
//     app.UseSwagger();
//     app.UseSwaggerUI(c =>
//     {
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//     });
// }
// else
// {
//     // Exception handler and HSTS for production
//     app.UseExceptionHandler("/Error");
//     app.UseHsts();
// }

// // Redirect HTTP to HTTPS
// app.UseHttpsRedirection();

// // Routing configuration
// app.UseRouting();

// // Authorization
// app.UseAuthorization();

// // Endpoint mapping for controllers
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
// });

// // Default route and SPA fallback
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller}/{action=Index}/{id?}");
// app.MapFallbackToFile("index.html");

// // Configuration for SPA
// app.UseSpa(spa =>
// {
//     spa.Options.SourcePath = "ClientApp";
//     if (app.Environment.IsDevelopment())
//     {
//         spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
//     }
// });

// // Run the application
// app.Run();
