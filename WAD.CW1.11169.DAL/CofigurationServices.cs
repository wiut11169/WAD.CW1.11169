using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD.CW1._11169.DAL.Data;
using WAD.CW1._11169.DAL.Interfaces;
using WAD.CW1._11169.DAL.Repositories;

namespace WAD.CW1._11169.DAL
{
    public static class ConfigurationServices
    {
        public static IServiceCollection ConfigureDataAccessLayer(
            this IServiceCollection services, 
            IConfiguration configuration
        )
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            return services;
        }
    }
}
