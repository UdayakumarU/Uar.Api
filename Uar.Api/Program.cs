using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Uar.Api.Data;
using Uar.Api.Services.Campaigns;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Enable Cors 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Localhost",
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});


//Configure Postgres DB
var conn = builder.Configuration.GetConnectionString("DockerContainerDBConnectionString");
builder.Services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(conn));

builder.Services.AddScoped<ICampaignService, CampaignService>();

var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<ApiDbContext>();
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Log or handle the error as necessary
        Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
