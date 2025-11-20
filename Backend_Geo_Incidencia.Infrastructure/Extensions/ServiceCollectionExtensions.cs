using Backend_Geo_Incidencia.Domain.Interfaces;
using Backend_Geo_Incidencia.Infrastructure.Jwt;
using Backend_Geo_Incidencia.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            services.AddScoped<IFactoryConnection, Data.FactoryConnection>();
            services.AddScoped<IUsuarioRepository,UsuarioRepository>();
            services.AddScoped<IIncidenciaRepository, IncidenciaRepository>();
            services.AddScoped<ITipoRepository, TipoRepository>();
            services.AddScoped<ISubtipoRepository, SubtipoRepository>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            services.AddScoped<IJwtService, JwtService>();
            Console.WriteLine("Infrastructure services registered.");
        }
    }
}
