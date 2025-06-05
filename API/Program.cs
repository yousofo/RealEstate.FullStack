
using API.Extensions;
using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using static System.Net.WebRequestMethods;
using API.Extensions.Middlewares;
using Microsoft.OpenApi.Models;
//namespace RealEstateFullStackApp.Server;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCustomDependencies(builder.Configuration);


builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIyIiwiZW1haWwiOiJhZG1pbkB0ZXN0LmNvbSIsImdpdmVuX25hbWUiOiJZb3Vzc2VmIiwiZmFtaWx5X25hbWUiOiJFbG1vdXNzYW91aSIsImp0aSI6IjFhZWViNjNmLWI4ZWQtNGI2Zi1hZjVhLTNkZjcxZGYxY2VhNSIsImV4cCI6MTc0OTA1MDY1NywiaXNzIjoiUmVhbEVzdGF0ZUFwcCIsImF1ZCI6IlJlYWxFc3RhdGVBcHAgdXNlcnMifQ.2yGZNpnenRPXLba0_8emY8842BCswXl6sJUfw3vH4P0

if (builder.Environment.IsDevelopment())
{
    //builder.Services.AddOpenApi();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {


        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "My API",
            Version = "v1"
        });


        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter your JWT token."
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    });
}
builder.Services.AddLogging();


//builder.Services.AddSwagger();
var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();
//app.Run((context) =>
//{
//    return context.Response.WriteAsync(
//        $"Environment: {app.Environment.EnvironmentName} - {app.Environment.IsDevelopment()}");
//});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
   {
       opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
 
   });
}
app.UseCors(e =>
{
    if (app.Environment.IsDevelopment())
    {
        e.WithOrigins(
            "http://localhost:3000",
            "http://localhost:5094",
            "http://localhost:54376",
            "https://real-estate-full-stack-yn.vercel.app"
            )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    }
    else
    {
        e.WithOrigins("https://real-estate-full-stack-yn.vercel.app")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    }
});


app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomExceptionMiddleware();
app.UseOutputCache();

//< SpaRoot > ..\Client </ SpaRoot >
//   < SpaProxyLaunchCommand > npm start </ SpaProxyLaunchCommand >
//   < SpaProxyServerUrl > https://localhost:54376</SpaProxyServerUrl>
app.MapControllers();

//app.MapFallbackToFile("/index.html");

app.Run();

