using LogicaAccesoDatos.EF;
using LogicaAplicacion.CasoUso.Usuarios;
using LogicaAplicacion.CasoUso.Cabanias;
using LogicaAplicacion.CasoUso.Tipos;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.Entidades;
using LogicaAplicacion.CasoUso.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(500);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Repositorios
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioCabania, RepositorioCabania>();
builder.Services.AddScoped<IRepositorioTipo, RepositorioTipo>();
builder.Services.AddScoped<IRepositorioMantenimiento, RepositorioMantenimiento>();

// Casos de uso - Usuarios
builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
builder.Services.AddScoped<IBaja, BajaUsuario>();
builder.Services.AddScoped<IBuscarUsuario, BuscarUsuario>();
builder.Services.AddScoped<IValidarUsuario, ValidarUsuario>();

// Casos de uso - Cabania
builder.Services.AddScoped<IAltaCabania, AltaCabania>();
builder.Services.AddScoped<IBaja, BajaCabania>();
builder.Services.AddScoped<IListarCabania, ListarCabania>();

// Casos de uso - Tipo
builder.Services.AddScoped<IAltaTipo, AltaTipo>();
builder.Services.AddScoped<IListarTipo, ListarTipo>();
builder.Services.AddScoped<IEditar<Tipo>, EditarTipo>();
builder.Services.AddScoped<IBaja, BajaTipo>();


//context
builder.Services.AddDbContext<HotelContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexionHotel"))
);

// leer archivo json
var config = new ConfigurationBuilder()
    .AddJsonFile("parametros.json", optional: true, reloadOnChange: true)
    .Build();
Parametros.min = config.GetValue<int>("min"); ;
Parametros.max = config.GetValue<int>("max");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

//app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cabania}/{action=Index}/{id?}");
app.Run();
