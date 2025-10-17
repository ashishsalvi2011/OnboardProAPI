using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;


namespace OnboardPro.Swagger
{
    public class AddTenantHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-Tenant-ID",
                In = ParameterLocation.Header,
                Required = true,
                Description = "Tenant identifier (e.g. App1)",
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("App1")
                }
            });
        }
    }
}
