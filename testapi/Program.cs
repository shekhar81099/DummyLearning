global using testapi.Models;
global using static System.Console;
using Microsoft.EntityFrameworkCore;
using testapi.Data;
using Serilog;
using testapi.Middleware;
using testapi.Extensions;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using testapi.Filters;
using testapi.Helper;
using Microsoft.AspNetCore.Mvc;
using testapi.Services;
var builder = WebApplication.CreateBuilder(args);

"this code is to print ".Print();

// builder.Logging.ClearProviders(); // Clears the default logging providers
// builder.Logging.AddConsole(); // Adds a console logging provider

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog(); // Use Serilog for logging
// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]); // Get the key from the configuration
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
// builder.Services.AddSingleton<QueueService>();

// builder.Services.AddHostedService<BackgroundSer>();



builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("Admin", policy => { policy.RequireRole("Admin"); });
    x.AddPolicy("CanEditReports", policy => { policy.RequireClaim("CanEditReports", "true"); });
    x.AddPolicy("MustBeHR", policy => policy.RequireClaim("Department", "HR"));
});

builder.Services.AddControllers(option =>
{
    option.Filters.Add<CustomActionFilter>(); // Adds the CustomActionFilter to the controllers
});  // Adds controllers for handling requests

builder.Services.AddEndpointsApiExplorer(); // Adds services for generating API documentation

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new() { Title = "SuperHero API", Version = "v1" });
    config.AddSecurityDefinition("Bearer", new() { In = ParameterLocation.Header, Description = "Please enter into field the word 'Bearer' following by space and JWT", Name = "Authorization", Type = SecuritySchemeType.ApiKey });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
                In = ParameterLocation.Header,
                // Scheme = "oauth2",
                Name = "Bearer",

            },
            new string[] {}
        }
    });
}); // Adds services for generating Swagger/OpenAPI documentation

builder.Services.AddServices();  // Adds services for the Superheroeservice
builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching();
builder.Services.AddApiVersioning(
    option =>
    {
        option.ReportApiVersions = true;
        option.AssumeDefaultVersionWhenUnspecified = true;
        option.DefaultApiVersion = new ApiVersion(1, 0);
    }
);

var app = builder.Build(); // Create the app
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // Enable Cross-Origin Resource Sharing
app.UseMiddleware<ExceptionMiddleware>(); // Use the ExceptionMiddleware
app.Use(async (context, next) =>
{
    // inline middleware 
    Console.WriteLine("custom inline middleware");
    await next(context);
});
app.UseMiddleware<SerilogMiddleware>(); // Use the SerilogMiddleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // If the environment is development
{


    app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwaggerUI(); // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
}


app.Use(async (context, next) => // Middleware that logs the request and response
{
    WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next(); // Passes the request to the next middleware
    WriteLine($"Response: {context.Response.StatusCode}");
});
app.UseResponseCaching();
app.UseRouting(); // Enable route matching

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS

app.UseAuthentication();



app.MapControllers();
// var queueService = app.Services.GetRequiredService<QueueService>();

// Task.Run(async () =>
// {
//     int counter = 1;
//     while (true)
//     {
//         queueService.AddMessage($"Message {counter++}");
//         await Task.Delay(3000); // Add a message every 3 seconds
//     }
// });

app.Run();

public partial class Program { }