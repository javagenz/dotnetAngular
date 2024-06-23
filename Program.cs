using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyAngularApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.AddConsole(); // This adds console logging

// Add services to the container.
// builder.Services.AddControllersWithViews();
builder.Services.AddControllers();


// Tambahkan Swagger
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>

// {

//     c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });

// });
//end 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Add Swagger annotations (tags and operation descriptions) to controller actions
    c.EnableAnnotations();
});

// Konfigurasi DbContext untuk PostgreSQL
// builder.Services.AddDbContext<MyDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "adminlte-3-angular/dist";
});

// Add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddScoped<IAuthService, AuthService>();








// BUILD
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Aktifkan Swagger hanya di development
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
    //end
    // app.UseSpa(spa =>
    // {
    //     spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
    // });
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
// if (!app.Environment.IsDevelopment())
// {
//     app.UseSpaStaticFiles();
// }

app.UseRouting();

// app.UseAuthorization();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
// });


app.UseAuthentication();

app.MapControllers();

// app.MapDefaultControllerRoute();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

// app.UseSpa(spa =>
// {
//     spa.Options.SourcePath = "adminlte-3-angular";

//     if (app.Environment.IsDevelopment())
//     {
//         spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
//     }
//     // app.UseStaticFiles();
// });


app.Run();
