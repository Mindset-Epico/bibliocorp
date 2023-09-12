using BibliotecaCorporativa.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//ADDED: SERVICO CORS
builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//ADDED: FIX para essa Injeção de Dependencia da Base de Dados. Override no Contexto.
var connectionString = builder.Configuration.GetConnectionString("Default");

//ADDED: Referencia do Contexto
builder.Services.AddDbContext<DataContext>(
    contexto => contexto.UseSqlite(("Default"))
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

//ADDED: USE CORS
app.UseCors(acesso => acesso.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());

app.MapControllers();

app.Run();
