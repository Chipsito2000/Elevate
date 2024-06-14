using ElevateERP.Data;
using ElevateERP.Filtro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new VerificacionSession());
});

//cadena de conexion a la bdd
var connectionString = builder.Configuration.GetConnectionString("ElevateERPConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDistributedMemoryCache();
/// Creamos el servicio de sesión
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true; // Asegura que la cookie no sea accesible desde el cliente
    options.Cookie.IsEssential = true; // Asegura que la cookie se mantenga aunque el usuario no acepte las cookies
});

//Si no esta autenticado te mapea a el login
builder.Services.AddAuthentication("MyCookieAuthenticationScheme")
    .AddCookie("MyCookieAuthenticationScheme", options =>
    {
        options.LoginPath = "/Login/Login";
    });

//agregamos la Session
builder.Services.AddScoped<VerificacionSession>();

//// Configurar filtros de acción globalmente
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new VerificacionSession());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Agrega el middleware de sesión aquí
app.UseSession(); 

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
