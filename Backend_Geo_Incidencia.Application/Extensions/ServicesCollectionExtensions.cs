using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Application.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Aquí puedes agregar servicios específicos de la capa de aplicación si es necesario
            var applicationAssembly = typeof(ServicesCollectionExtensions).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
            services.AddAutoMapper(applicationAssembly);
            services.AddValidatorsFromAssembly(applicationAssembly);
            Console.WriteLine("Servicios de la capa de aplicación registrados correctamente.");
            return services;
        }
    }
}
