using LogicaAccesoDatos.EF;
using LogicaAplicacion.CasoUso.Usuarios;
using LogicaAplicacion.CasoUso.Cabanias;
using LogicaAplicacion.CasoUso.Tipos;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.Entidades;
using LogicaAplicacion.CasoUso.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using WebApi.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(aut =>
{
    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(aut =>
{
    aut.RequireHttpsMetadata = false;
    aut.SaveToken = true;
    aut.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Parametros.PrivateKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Proyecto obligatorio",
            Description = "An ASP .NET Core Web API for Cabin Management",
        });
        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    }
);

//repo
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioCabania, RepositorioCabania>();
builder.Services.AddScoped<IRepositorioTipo, RepositorioTipo>();
builder.Services.AddScoped<IRepositorioMantenimiento, RepositorioMantenimiento>();



//casos de uso

//Usuarios
builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
builder.Services.AddScoped<IBaja, BajaUsuario>();
builder.Services.AddScoped<IBuscarUsuario, BuscarUsuario>();
builder.Services.AddScoped<IValidarUsuario, ValidarUsuario>();


//Cabania
builder.Services.AddScoped<IAltaCabania, AltaCabania>();
builder.Services.AddScoped<IBaja, BajaCabania>();
builder.Services.AddScoped<IListarCabania, ListarCabania>();

//Tipo
builder.Services.AddScoped<IAltaTipo, AltaTipo>();
builder.Services.AddScoped<IListarTipo, ListarTipo>();
builder.Services.AddScoped<IEditar<Tipo>, EditarTipo>();
builder.Services.AddScoped<IBaja, BajaTipo>();



// leer archivo json
var config = new ConfigurationBuilder()
    .AddJsonFile("parametros.json", optional: true, reloadOnChange: true)
    .Build();
Parametros.min = config.GetValue<int>("min");
Parametros.max = config.GetValue<int>("max");
Parametros.PrivateKey = config.GetValue<string>("privateKey");

var mapper = new MapperConfiguration(option => option.AddProfile(new MapperProfile()));
builder.Services.AddSingleton(mapper.CreateMapper());

//context
builder.Services.AddDbContext<HotelContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexionHotel"))
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cabania}/{action=Index}/{id?}");
app.Run();

