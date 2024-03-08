using ApiPeliculas.Data;
using ApiPeliculas.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ApiPeliculas.Modelos;

var builder = WebApplication.CreateBuilder(args);


var isRunningInDocker = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") == "true";
var connectionStringKey="ServerDB_Docker";
connectionStringKey = isRunningInDocker ? "ServerDB_Docker" : "ServerDB_Local";
var connectionString = builder.Configuration.GetConnectionString(connectionStringKey);


builder.Services.AddControllers();
//Permite las solicitudes desde la url que pongas
 builder.Services.AddCors(options =>
        {
            options.AddPolicy("CineVue",
                builder => builder
                    .WithOrigins("http://localhost:5173") 
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Documentation", Version = "v1" });
});


builder.Services.AddDbContext<PeliculaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IButacaData, ButacaData>();
builder.Services.AddScoped<IButacaService, ButacaService>();

builder.Services.AddScoped<IPeliculaData, PeliculaData>();
builder.Services.AddScoped<IPeliculaService, PeliculaService>();



var app = builder.Build();


app.UseCors("CineVue");
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();