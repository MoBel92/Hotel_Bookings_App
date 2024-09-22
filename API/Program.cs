using Microsoft.EntityFrameworkCore;
using StartMyNewApp.Domain.Interface;
using StartMyNewApp.Infra.Repositories;
using DATA.Context;
using Microsoft.OpenApi.Models;
using StartMyNewApp.Domain.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the DbContext and specify the migrations assembly
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("DATA")
    ));

// Register the GenericRepository in the DI container
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Register handlers for all entities
builder.Services.AddScoped(typeof(AddGenericHandler<>));
builder.Services.AddScoped(typeof(UpdateGenericHandler<>));
builder.Services.AddScoped(typeof(DeleteGenericHandler<>));
builder.Services.AddScoped(typeof(GetGenericHandler<>));
builder.Services.AddScoped(typeof(GetListGenericHandler<>));

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel_Bookings_App", Version = "v1" });
});

// Enable CORS (if needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Configure Kestrel to listen on port 8080 (Render's default port)
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    // Only bind Kestrel to port 8080 in production to avoid conflicts
    serverOptions.ListenAnyIP(8080);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Use Swagger in development environments for API testing
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StartMyNewApp API V1");
        c.RoutePrefix = string.Empty;
    });
    // Enable detailed error pages in development
    app.UseDeveloperExceptionPage();
}

// Configure HTTPS Redirection
// It's disabled for production because Render typically handles SSL termination
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

// Use CORS policy
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

// Map the controllers to the routes
app.MapControllers();

app.Run();


