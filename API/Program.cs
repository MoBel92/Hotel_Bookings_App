using Microsoft.EntityFrameworkCore;
using StartMyNewApp.Domain.Interface;
using StartMyNewApp.Infra.Repositories;
using DATA.Context;  // Ensure the namespace of your DbContext is correct
using Microsoft.OpenApi.Models; // Add this for Swagger configuration
using StartMyNewApp.Domain.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the DbContext and specify the migrations assembly to be the DATA project
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("DATA")  // Specify the DATA project for migrations
    ));

// Register the GenericRepository in the DI container
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Register handlers for all entities (User, HotelArticle, Booking, Comment, Location)
builder.Services.AddScoped(typeof(AddGenericHandler<>));
builder.Services.AddScoped(typeof(UpdateGenericHandler<>));
builder.Services.AddScoped(typeof(DeleteGenericHandler<>));
builder.Services.AddScoped(typeof(GetGenericHandler<>));
builder.Services.AddScoped(typeof(GetListGenericHandler<>));

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "StartMyNewApp API", Version = "v1" });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StartMyNewApp API V1");
        c.RoutePrefix = string.Empty;  // Makes Swagger available at the root URL (http://localhost:<port>/)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

