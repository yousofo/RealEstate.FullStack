
using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RealEstateFullStackApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(opts=>opts.UseSqlServer("Server=.\\sqlExpress;Database=RealEstateFull;Trusted_Connection=True;Trust Server Certificate=True;"));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperConfig)));

            builder.Services.AddScoped<IPropertiesService, PropertiesService>();
            builder.Services.AddScoped<ILocationsService, LocationsService>();
            builder.Services.AddScoped<IKeywordsService, KeywordsService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.MapStaticAssets();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(opts =>
                {
                    opts.SwaggerEndpoint("/openapi/v1.json", "name1");
                    //opts.
                });
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
