using ApiCine.Data;
using ApiCine.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ApiCine.Modelos;
using ApiCine.Api.LogErrores;

var builder = WebApplication.CreateBuilder(args);


var isRunningInDocker = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") == "true";
var connectionStringKey="ServerDB_Docker";
connectionStringKey = isRunningInDocker ? "ServerDB_Docker" : "ServerDB_Local";
var connectionString = builder.Configuration.GetConnectionString(connectionStringKey);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true; // Para que se muestren los json mas legibles sin valores como $ o valores que no ineteresan
});



//Permite las solicitudes desde la url que pongas
 builder.Services.AddCors(options =>
        {
            options.AddPolicy("CineVue",
                builder => builder
                    .WithOrigins("http://localhost:5173", "http://localhost:8000") 
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Documentation", Version = "v1" });
});




builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddScoped<ISesionData, SesionData>();
builder.Services.AddScoped<ISesionService, SesionService>();

builder.Services.AddScoped<ISalaData, SalaData>();
builder.Services.AddScoped<ISalaService, SalaService>();

builder.Services.AddScoped<IUsuarioData, UsuarioData>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IReservaData, ReservaData>();
builder.Services.AddScoped<IReservaService, ReservaService>();


//builder.Services.AddScoped<IButacaData, ButacaData>();
//builder.Services.AddScoped<IButacaService, ButacaService>();

builder.Services.AddScoped<IPeliculaData, PeliculaData>();
builder.Services.AddScoped<IPeliculaService, PeliculaService>();

builder.Services.AddScoped<ILogErrores, LogErrores>();




var app = builder.Build();


app.UseCors("CineVue");
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();