using Microsoft.EntityFrameworkCore;
using StartMyNewApp.Domain.Interface;
using StartMyNewApp.Infra.Repositories;
using DATA.Context;
using Microsoft.OpenApi.Models;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Register DbContext with connection string from configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("DATA")
    ));

// Register the generic repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Configure AutoMapper and register mapping profiles
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register handlers with DTO support
builder.Services.AddScoped(typeof(AddGenericHandler<,>));
builder.Services.AddScoped(typeof(UpdateGenericHandler<,>));
builder.Services.AddScoped(typeof(DeleteGenericHandler<>));
builder.Services.AddScoped(typeof(GetGenericHandler<,>));
builder.Services.AddScoped(typeof(GetListGenericHandler<,>));

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel_Bookings_App", Version = "v1" });
});

// Add CORS policy for development access from localhost
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Allow only local frontend during development
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable static file serving (for wwwroot)
app.UseStaticFiles(); // To serve images and other static files from wwwroot

// Enable Swagger for API documentation
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel_Bookings_App API V1");
    c.RoutePrefix = string.Empty; // Swagger is available at the root URL
});

// Use HTTPS redirection
app.UseHttpsRedirection();

// Apply the CORS policy before any other middleware
app.UseCors("AllowLocalhost");

app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
