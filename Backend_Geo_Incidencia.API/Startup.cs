using Backend_Geo_Incidencia.Application.Models;
using Microsoft.OpenApi.Models;
using Backend_Geo_Incidencia.Infrastructure.Extensions;
using Backend_Geo_Incidencia.Application.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autenticación JWT usando el esquema Bearer.\n\nEjemplo: 'Bearer {tu_token_aquí}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new string[] {}
        }
    });
                c.OperationFilter<ApiResponseOperationFilter>();
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    var jwtSettings = _configuration.GetSection("JwtSettings");

                    var secretKey = jwtSettings["SecretKey"];
                    var issuer = jwtSettings["Issuer"];
                    var audience = jwtSettings["Audience"];

                    var key = Encoding.UTF8.GetBytes(secretKey);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),

                        ValidateIssuer = true,
                        ValidIssuer = issuer,

                        ValidateAudience = true,
                        ValidAudience = audience,

                        ValidateLifetime = true
                    };
                });

            services.AddAuthorization();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsDev", builder =>
            //    {
            //        builder.WithOrigins(
            //                 "http://localhost:8080"      // para desarrollo 
            //                )
            //               .AllowAnyHeader()
            //               .AllowAnyMethod()
            //               .AllowCredentials();
            //    });
            //});
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors("AllowAll");

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
