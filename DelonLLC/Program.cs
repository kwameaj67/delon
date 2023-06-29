using DelonLLC.Data;
using DelonLLC.Functions;
using DelonLLC.Interfaces;
using DelonLLC.Repositories;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//swagger
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DelonLLC",
        Version = "v1",
        Description = "API for DelonLLC"
    });
    // c.EnableAnnotations();
});

//db context
string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// add singletons
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddSingleton<IHelperFunctions, HelperFunctions>();

//add cache to response
builder.Services.AddResponseCaching();

// cors
builder.Services.AddCors(c => c.AddPolicy("Policy", options =>
    options.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()
));

// configure logging
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;

});

builder.Logging.AddDebug();
builder.Logging.AddEventSourceLogger();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}



// use cors
app.UseCors("Policy");

//use caching
app.UseResponseCaching();
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue { MaxAge = TimeSpan.FromSeconds(10), Public = true };
    await next();
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
