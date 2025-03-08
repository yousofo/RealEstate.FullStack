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

namespace API.ServiceExtensions;

public static class ServiceExtensions
{

    public static IServiceCollection AddCustomDependencies(this IServiceCollection services)
    {

        services.AddCustomServices();
        services.AddCustomRepos();
        services.AddAuthConfig();
        services.AddCustomFluentValidation();

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
    public static IServiceCollection AddAuthConfig(this IServiceCollection services)
    {

        services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}

