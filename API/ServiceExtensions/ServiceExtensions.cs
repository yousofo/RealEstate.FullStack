using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repos;
using FluentValidation.AspNetCore;
using FluentValidation;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Auth.Repos;
using Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Auth.Interfaces;
using Infrastructure.Auth.Providers;

namespace API.ServiceExtensions;

public static class ServiceExtensions
{

    public static IServiceCollection AddCustomDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddCustomServices();
        services.AddCustomRepos();
        services.AddCustomFluentValidation();
        services.AddAuthConfig(configuration);

        services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperConfig)));

        services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer("Server=.\\sqlExpress;Database=RealEstateFull;Trusted_Connection=True;Trust Server Certificate=True;"));


        return services;
    }
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {

        services.AddScoped<IPropertiesService, PropertiesService>();
        services.AddScoped<ILocationsService, LocationsService>();
        services.AddScoped<IKeywordsService, KeywordsService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthRepo, AuthRepo>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
    public static IServiceCollection AddCustomRepos(this IServiceCollection services)
    {

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthRepo, AuthRepo>();

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
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidateIssuer = true,
                ValidAudience = configuration["Jwt:Audience"],
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            };
        });

        return services;
    }
}

