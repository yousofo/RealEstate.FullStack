
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

namespace RealEstateFullStackApp.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddCustomDependencies(builder.Configuration);

        builder.Services.AddControllers();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddLogging();

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
            app.MapOpenApi();

            app.UseSwaggerUI(opts =>
            {
                opts.SwaggerEndpoint("/openapi/v1.json", "v1");
                //opts.
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
        app.UseOutputCache();

        //< SpaRoot > ..\Client </ SpaRoot >
        //   < SpaProxyLaunchCommand > npm start </ SpaProxyLaunchCommand >
        //   < SpaProxyServerUrl > https://localhost:54376</SpaProxyServerUrl>
        app.MapControllers();

        //app.MapFallbackToFile("/index.html");

        app.Run();
    }
}

