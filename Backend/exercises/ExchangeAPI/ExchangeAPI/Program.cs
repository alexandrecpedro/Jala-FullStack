using ExchangeAPI.Context;
using ExchangeAPI.Modules.Wallet.Entities;
using ExchangeAPI.Modules.Wallet.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Exchange API",
        Version = "v1",
        Description = "Exchange API for currencies management and manipulation",
        TermsOfService = new Uri("http://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            Url = new Uri("https://twitter.com/johndoe"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under MIT",
            Url = new Uri("https://example.com/license"),
        }
    });
});

builder.Configuration.AddJsonFile("appsettings.json", false, true);

var dollarSettings = builder.Configuration.GetSection("Currencies:Dollar").Get<CurrencySettings>();
var euroSettings = builder.Configuration.GetSection("Currencies:Euro").Get<CurrencySettings>();

// var dollar = new Dollar(dollarSettings);
// var euro = new Euro(euroSettings);

builder.Services.AddSingleton<Dollar>(new Dollar(dollarSettings));
builder.Services.AddSingleton<Euro>(new Euro(euroSettings));
builder.Services.AddScoped<WalletService<Dollar>>();
builder.Services.AddScoped<WalletService<Euro>>();
builder.Services.AddDbContext<DatabaseContext>(opt => 
    opt.UseInMemoryDatabase("test"));

var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exchange API");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();