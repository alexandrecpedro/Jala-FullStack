using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RestAPIExample.Attributes;
using RestAPIExample.Controllers;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RestAPIExample.SwaggerDoc;

public class SwaggerCustomOperation : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.SupportedResponseTypes.FirstOrDefault()?.ModelMetadata?.ModelType?.Name == nameof(WeatherForecast))
        {
            operation.Responses.Clear();
            operation.Responses.Add("200", new OpenApiResponse
            {
                Description = "Success",
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    ["application/json"] = new OpenApiMediaType
                    {
                        Example = new OpenApiObject
                        {
                            ["date"] = new OpenApiString("2021-08-01"),
                            ["temperatureC"] = new OpenApiInteger(25),
                            ["temperatureF"] = new OpenApiInteger(77),
                            ["summary"] = new OpenApiString("Hot")
                        }
                    }
                }
            });
        }

        if(context.MethodInfo.CustomAttributes.Any(x => x.AttributeType == typeof(ResponseCacheAttribute)))
        {
            operation.Parameters.Add(  new OpenApiParameter()
            {
                Name = "Cache-Control",
                In = ParameterLocation.Header,
                Description = "Default cache value",
                Required = false,
                Schema = new OpenApiSchema()
                {
                    Type = "string",
                    Default = new OpenApiString("public, max-age=20")
                }
            });
        }
        
        if (!operation.Responses.ContainsKey("400"))
            operation.Responses.Add("400", CreateBadRequestResponse());
    }

    private OpenApiResponse CreateBadRequestResponse()
    {
        return new OpenApiResponse
        {
            Description = "Bad Request",
            Content = new Dictionary<string, OpenApiMediaType>
            {
                ["application/json"] = new OpenApiMediaType
                {
                    Example = new OpenApiObject
                    {
                        ["error"] = new OpenApiString("Invalid input")
                    }
                }
            }
        };
    }
}

public class AuthSwaggerFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var attribute = context.ApiDescription.CustomAttributes()
            .FirstOrDefault(x => x.GetType() == typeof(NeedAutorizationAttribute));
        if(attribute == null)
            return;

        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();
        
        
        operation.Parameters.Add(
            new OpenApiParameter()
            {
                Name = "Auth",
                In = ParameterLocation.Header,
                Description = "Default auth value",
                Required = true,
                Schema = new OpenApiSchema()
                {
                    Type = "string",
                    Default = new OpenApiString("Beartoke")
                }
            });
    }
}