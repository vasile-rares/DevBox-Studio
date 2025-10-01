using Microsoft.EntityFrameworkCore;
using DevBox.Infrastructure.Context;
using DevBox.Domain.Entities;
using DevBox.Infrastructure.Seeding;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DevBoxDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevBoxDb")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddControllers();

// Swagger
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DevBoxDbContext>();

    RolesSeeder.Seed(dbContext);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();