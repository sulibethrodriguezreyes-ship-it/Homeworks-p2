using Audiologia.Application.Interfaces;
using Audiologia.Application.Services;
using Audiologia.Application.Services.Interfaces;
using Audiologia.Infrastructure.Data;
using Audiologia.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<AudiologiaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ISpecialistRepository, SpecialistRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IHearingTestRepository, HearingTestRepository>();

// Services
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ISpecialistService, SpecialistService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IHearingTestService, HearingTestService>();

// Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Audiology Center API",
        Version = "v1",
        Description = "API for Patient Management System - Audiology Center"
    });
});

// CORS for BlazorClient
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Audiology API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("AllowBlazor");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Auto migrate on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AudiologiaDbContext>();
    db.Database.Migrate();
}

app.Run();