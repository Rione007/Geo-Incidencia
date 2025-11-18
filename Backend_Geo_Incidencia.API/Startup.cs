using Backend_Geo_Incidencia.Application.Models;
using Microsoft.OpenApi.Models;
using Backend_Geo_Incidencia.Infrastructure.Extensions;
using Backend_Geo_Incidencia.Application.Extensions;

namespace Backend_Geo_Incidencia.API
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddInfrastructureServices(_configuration);
            services.AddApplicationServices();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RT Backend Geo API",
                    Version = "v1"
                });
                c.OperationFilter<ApiResponseOperationFilter>();
            });
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RT Backend Geo API v1");
            });

            app.MapControllers();

            app.MapGet("/", context =>
            {
                context.Response.Redirect("/swagger", permanent: false);
                return Task.CompletedTask;
            });

        }




    }
}
