using Application.Dtos;
using Infrastructure.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repos;
using FluentValidation.AspNetCore;
using FluentValidation;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Auth.Repos;
using Domain.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Auth.Interfaces;
using Infrastructure.Auth.Providers;
using Application.Options;
using Application.Services.EntityServices;
using Infrastructure.Repos;
using Application.Interfaces.Repos.Auth;
using Application.Interfaces.Services.EntityServices;
using Application.Interfaces.Services.Auth;
using Application.Services.Auth;
using Application.Interfaces.Services;
using Application.Services;

namespace API.ServiceExtensions;

public static class ServiceExtensions
{

    public static IServiceCollection AddCustomDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        //services.AddCustomServices();
        services.AddScoped<IServicesManager, ServicesManager>();

        //services.AddCustomRepos();
        services.AddScoped<IReposManager, ReposManager>();

        services.AddCustomFluentValidation();
        services.AddAuthConfig(configuration);

        services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperConfig)));

        services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer("Server=.\\sqlExpress;Database=RealEstateFull;Trusted_Connection=True;Trust Server Certificate=True;"));


        return services;
    }
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {

        //services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
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
        var settings = configuration.GetSection("Jwt").Get<JwtOptions>();//meh... maybe bind in more complex apps

        services.AddAuthentication(opts =>
        {
            //so when using [auth] attr with actions or controllers, dont need to keep specifying the token type is bearer
            opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opts =>
        {
            opts.SaveToken = true;
            opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = settings.Issuer,//configuration["Jwt:Issuer"],
                ValidateIssuer = true,
                ValidAudience =settings.Audience,// configuration["Jwt:Audience"],
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            };
        });

        return services;
    }
}

