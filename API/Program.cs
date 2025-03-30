
using API.ServiceExtensions;
using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
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
        app.UseStaticFiles();
        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseCors(e =>
        {
            e.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //e.WithOrigins("http://localhost:54376", "http://localhost:54376", "http://localhost:54376");
        });

        //< SpaRoot > ..\Client </ SpaRoot >
        //   < SpaProxyLaunchCommand > npm start </ SpaProxyLaunchCommand >
        //   < SpaProxyServerUrl > https://localhost:54376</SpaProxyServerUrl>
        app.MapControllers();

        //app.MapFallbackToFile("/index.html");

        app.Run();
    }
}

