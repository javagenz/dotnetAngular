using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyAngularApp.Data;
using MyAngularApp.Services;
using MyAngularApp.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Konfigurasi DbContext untuk PostgreSQL
// builder.Services.AddDbContext<MyDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProfilService, ProfilService>();
builder.Services.AddScoped<ProfilQuery>();
builder.Services.AddScoped<IServiceDua, ServiceDua>();


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

// builder.Services.AddSpaStaticFiles(configuration =>
// {
//     configuration.RootPath = "ClientApp/dist";
// });

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
// app.UseStaticFiles();
// if (!app.Environment.IsDevelopment())
// {
//     app.UseSpaStaticFiles();
// }

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
    }
});


app.Run();
