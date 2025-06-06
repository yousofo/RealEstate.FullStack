﻿using Application.Dtos;
using Infrastructure.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repos;
using FluentValidation.AspNetCore;
using FluentValidation;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Domain.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Options;
using Application.Services.EntityServices;
using Infrastructure.Repos;
using Application.Interfaces.Services.EntityServices;
using Application.Interfaces.Services;
using Application.Services;

namespace API.Extensions;

public static class ServiceExtensions
{

    public static IServiceCollection AddCustomDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddHttpClient();
        services.AddScoped<IServicesManager, ServicesManager>();

        //services.AddCustomRepos();
        services.AddScoped<IReposManager, ReposManager>();

        services.AddCustomFluentValidation();
        services.AddAuthConfig(configuration);
        services.AddCustomOutputCache();

        services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperConfig)));

        var environment = configuration["ASPNETCORE_ENVIRONMENT"] ?? "Development";

        if (environment == "Production")
        {
            //NOTE: should be default connection but source is public so... using secrets file for password
            //services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            var connectionString = configuration["DbLocalConnection"] ?? throw new Exception("DbLocalConnection not found");
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(connectionString));
        }
        else
        {
            var connectionString = configuration["DbPublicConnection"] ?? throw new Exception("DbPublicConnection not found");
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(connectionString));
            //services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DevConnection")));
        }



        return services; 
    }
    public static void AddCustomOutputCache(this IServiceCollection services)
    {

        services.AddOutputCache(
            opt => opt.AddPolicy("Duration", x => x.Cache()
            .Expire(TimeSpan.FromDays(1))
            .Tag("DurationTag")
            )
        );

        //return services;
    }
    public static IServiceCollection AddCustomRepos(this IServiceCollection services)
    {

        //services.AddScoped<IAuthRepo, AuthRepo>();

        return services;
    }
    public static IServiceCollection AddCustomFluentValidation(this IServiceCollection services)
    {

        services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
    public static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

        //services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.AddOptions<JwtOptions>()
            .BindConfiguration("Jwt")
            .ValidateDataAnnotations()
            .ValidateOnStart();//throw error if validations failed FROM BEGINING AND NOT DURING RUNTIME
        var settings = configuration.GetSection("Jwt").Get<JwtOptions>();//... maybe bind in more complex apps

        services.AddAuthentication(opts =>
        {
            //so when using [auth] attr with actions or controllers, dont need to keep specifying the token type is bearer
            opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opts =>
        {
            //read from cookie => XXS attacks
            //opts.Events = new JwtBearerEvents
            //{
            //    OnMessageReceived = context =>
            //    {
            //        var token = context.Request.Cookies["Jwt"]; // or whatever cookie name
            //        for(int i = 0; i < context.Request.Cookies.Count; i++)
            //        {
            //            var cookie = context.Request.Cookies.ElementAt(i);
            //            Console.WriteLine($"{cookie.Key} : {cookie.Value}");
            //        }
            //        Console.WriteLine($"token from cookie: {token}");

            //        if (!string.IsNullOrEmpty(token))
            //        {
            //            context.Token = token;
            //        }
            //        return Task.CompletedTask;
            //    }
            //};
            opts.SaveToken = true;
            opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = settings.Issuer,//configuration["Jwt:Issuer"],
                ValidateIssuer = true,
                ValidAudience = settings.Audience,// configuration["Jwt:Audience"],
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            };
        });

        return services;
    }
}

