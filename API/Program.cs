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

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped(typeof(AddGenericHandler<,>));
builder.Services.AddScoped(typeof(UpdateGenericHandler<,>));
builder.Services.AddScoped(typeof(DeleteGenericHandler<>));
builder.Services.AddScoped(typeof(GetGenericHandler<,>));
builder.Services.AddScoped(typeof(GetListGenericHandler<,>));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel_Bookings_App", Version = "v1" });
});

// Add CORS policy for debugging
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostAndProduction", policy =>
    {
        Console.WriteLine("CORS policy applied with allowed origins:");
        Console.WriteLine("http://localhost:3000, https://localhost:3000");
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    options.AddPolicy("AllowAll", policy =>
    {
        Console.WriteLine("CORS policy applied for all origins (debugging)");
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Debugging: Log incoming requests and responses
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    Console.WriteLine($"Headers: {string.Join(", ", context.Request.Headers.Select(h => $"{h.Key}: {h.Value}"))}");
    await next();
    Console.WriteLine($"Response: {context.Response.StatusCode}");
});

// Enable Developer Exception Page for debugging
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Enable static file serving
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel_Bookings_App API V1");
    c.RoutePrefix = string.Empty;
});

// Apply permissive CORS policy for debugging
app.UseCors("AllowAll");

// Apply middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
