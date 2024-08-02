using ElevateERP.Data;
using ElevateERP.Filtro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

var builder = WebApplication.CreateBuilder(args);

#region Alta de filtro

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<VerificacionSession>();

});


#endregion

#region cadena de conexion

var connectionString = builder.Configuration.GetConnectionString("ElevateERPConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

#endregion


// Memoria en cache
builder.Services.AddDistributedMemoryCache();

#region Creacion de vida de la sesi�n

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Tiempo de expiraci�n de la sesi�n
    options.Cookie.HttpOnly = true; // Asegura que la cookie no sea accesible desde el cliente
    options.Cookie.IsEssential = true; // Asegura que la cookie se mantenga aunque el usuario no acepte las cookies
});

#endregion

#region esquema de region

builder.Services.AddAuthentication("MyCookieAuthenticationScheme")
    .AddCookie("MyCookieAuthenticationScheme", options =>
    {
        options.LoginPath = "/Login/Login";
    });

#endregion

//Vida de la sesion
builder.Services.AddScoped<VerificacionSession>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Agrega el middleware de sesi�n aqu�
app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
