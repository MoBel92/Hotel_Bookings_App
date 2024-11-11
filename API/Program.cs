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

// Add Swagger services for API documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel_Bookings_App", Version = "v1" });
});

// Add CORS policy for localhost and production
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostAndRender", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://hotel-bookings-app.onrender.com") // Allow local dev and deployed frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable debugging middleware to log requests and responses
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    Console.WriteLine($"Headers: {string.Join(", ", context.Request.Headers.Select(h => $"{h.Key}: {h.Value}"))}");
    await next();
    Console.WriteLine($"Response: {context.Response.StatusCode}");
});

// Enable Developer Exception Page for debugging in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Enable static file serving (for hosting frontend assets if needed)
app.UseStaticFiles();

// Enable Swagger for API documentation
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel_Bookings_App API V1");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at root
});

// Apply CORS policy
app.UseCors("AllowLocalhostAndRender");

// Use HTTPS redirection (comment out if Render handles HTTPS)
app.UseHttpsRedirection();

// Apply authorization middleware
app.UseAuthorization();

// Map API controllers
app.MapControllers();

app.Run();
