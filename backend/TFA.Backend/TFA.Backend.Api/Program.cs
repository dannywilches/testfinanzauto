using Microsoft.EntityFrameworkCore;
using TFA.Backend.Application;
using TFA.Backend.Infrastructure;
using TFA.Backend.Infrastructure.Persistence.Context;
using TFA.Backend.Infrastructure.Persistence.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Infrastructure and Application services
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins ?? new string[] { "*" })
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();


// Apply pending migrations at startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<CatalogDbContext>();

    await context.Database.MigrateAsync();

    var migrations = await context.Database.GetAppliedMigrationsAsync();

    foreach (var migration in migrations)
    {
        Console.WriteLine(migration);
    }

    await CatalogSeeder.SeedAsync(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
