// Mengimpor pustaka yang diperlukan
using Microsoft.EntityFrameworkCore;  // Menggunakan Entity Framework Core untuk ORM
using Microsoft.OpenApi.Models;  // Menggunakan OpenAPI untuk dokumentasi API
using MyAngularApp.Data;  // Mengimpor namespace untuk akses data
using MyAngularApp.Services;  // Mengimpor namespace untuk layanan
using MyAngularApp.Query;  // Mengimpor namespace untuk query

// Membuat builder aplikasi web
var builder = WebApplication.CreateBuilder(args);

// Menambahkan layanan kontroler dengan tampilan ke dalam container layanan
builder.Services.AddControllersWithViews();

// Menambahkan layanan DbContext untuk database PostgreSQL
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Menambahkan layanan scoped untuk injeksi ketergantungan
builder.Services.AddScoped<IProfilService, ProfilService>();  // Layanan profil
builder.Services.AddScoped<ProfilQuery>();  // Query profil
builder.Services.AddScoped<IServiceDua, ServiceDua>();  // Layanan kedua

// Menambahkan layanan untuk dokumentasi API
builder.Services.AddEndpointsApiExplorer();

// Mengonfigurasi Swagger untuk dokumentasi API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });  // Membuat dokumentasi API versi 1
    c.EnableAnnotations();  // Mengaktifkan anotasi Swagger
});

// Membangun aplikasi web
var app = builder.Build();

// Mengonfigurasi pipeline permintaan HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Menggunakan halaman pengecualian pengembang
    app.UseSwagger();  // Mengaktifkan Swagger hanya di environment development
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");  // Menambahkan endpoint untuk Swagger UI
    });

    app.UseSpa(spa =>
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");  // Mengarahkan ke server pengembangan SPA
    });
}
else
{
    app.UseExceptionHandler("/Error");  // Menangani pengecualian dengan halaman kesalahan
    app.UseHsts();  // Menggunakan HTTP Strict Transport Security (HSTS)
}

// Mengalihkan permintaan HTTP ke HTTPS
app.UseHttpsRedirection();

// Menggunakan middleware routing
app.UseRouting();

// Mengonfigurasi endpoint untuk kontroler
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();  // Memetakan kontroler ke endpoint
});

// Menggunakan middleware otorisasi
app.UseAuthorization();

// Mengonfigurasi rute default untuk kontroler
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

// Mengonfigurasi fallback untuk file index.html
app.MapFallbackToFile("index.html");

// Mengonfigurasi penggunaan aplikasi satu halaman (SPA)
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";  // Menentukan path sumber untuk aplikasi klien

    if (app.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");  // Mengarahkan ke server pengembangan SPA
    }
});

// Menjalankan aplikasi
app.Run();
