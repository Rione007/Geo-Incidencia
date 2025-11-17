

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Backend_Geo_Incidencia.Application.Models
{
    public class ApiResponseOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Responses["200"] = new OpenApiResponse
            {
                Description = "Respuesta exitosa",
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    ["application/json"] = new OpenApiMediaType
                    {
                        Schema = context.SchemaGenerator.GenerateSchema(
                            typeof(ApiResponse<object>), context.SchemaRepository
                        )
                    }
                }
            };

            operation.Responses["400"] = new OpenApiResponse
            {
                Description = "Error de validación o de negocio"
            };
        }
    }
}
