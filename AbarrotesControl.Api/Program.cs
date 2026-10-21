using Microsoft.EntityFrameworkCore;
using FluentValidation;
using AbarrotesControl.Core.Interfaces;
using AbarrotesControl.Infrastructure.Data;
using AbarrotesControl.Infrastructure.Repositories;
using AbarrotesControl.Infrastructure.Mappings;
using AbarrotesControl.Services.Validators;

var builder = WebApplication.CreateBuilder(args);

// Configuración de MySQL Context
var connectionString = builder.Configuration.GetConnectionString("ConnectionMySql");
builder.Services.AddDbContext<AbarrotesContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Repositorios
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IEntradaRepository, EntradaRepository>();

// AutoMapper
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ProductoProfile>());

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<ProductoDtoValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();