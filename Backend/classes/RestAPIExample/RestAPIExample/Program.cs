using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using RestAPIExample;
using RestAPIExample.SwaggerDoc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
    });

builder.Services.Configure<WeatherConfig>(builder.Configuration.GetSection("Weather"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped(typeof(IGeniricServiceOne<>), typeof(GenericServiceOne<>));
builder.Services.AddScoped(typeof(IGenericServiceTwo<,>), typeof(GenericServiceTwo<,>));


builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "WeatherForecast API", 
        Version = "v1",
        Description = "A simple example ASP.NET Core Web API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "John Doe",
            Email = string.Empty,
            Url = new Uri("https://twitter.com/johndoe"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under MIT",
            Url = new Uri("https://example.com/license"),
        }
    });
   
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "RestAPIExample.xml");
    c.IncludeXmlComments(filePath);
    
     c.OperationFilter<SwaggerCustomOperation>();
     c.OperationFilter<AuthSwaggerFilter>();
});

var app = builder.Build();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherForecast API");
        c.InjectStylesheet("/swagger-ui/custom.css");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

public interface IGeniricServiceOne<T> where T: class { public string GetCode(); }
public class GenericServiceOne<T> : IGeniricServiceOne<T> where T : class
{
    public string GetCode() => "200";
}

public interface IGenericServiceTwo<T, U> where T : class
{
    public string GetCode();
}

public class GenericServiceTwo<T, U> : IGenericServiceTwo<T, U> where T : class
{
    public string GetCode() => "200";
}


