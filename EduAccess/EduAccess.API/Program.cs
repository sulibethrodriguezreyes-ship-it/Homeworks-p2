using Microsoft.EntityFrameworkCore;
using EduAccess.Infrastructure.Context;
using EduAccess.Application.Interfaces;
using EduAccess.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE SERVICIOS ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- CONFIGURACIÓN DE CORS ---
// Permite que Blazor lea los datos sin bloqueos de seguridad
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// --- CONFIGURACIÓN DE SQL SERVER (Con Reintentos) ---
builder.Services.AddDbContext<EduContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null)
    ));

// Registrar el Repositorio
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// --- 2. CONFIGURACIÓN DEL PIPELINE (Middleware) ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- ACTIVACIÓN DE CORS ---
// ¡Importante! Debe ir antes de Authorization y MapControllers
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();