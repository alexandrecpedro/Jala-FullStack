using Autofac;
using DDDWebAPI.Infrastructure.CrossCutting.IOC;
using DDDWebAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiDDD.Presentation;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        var connection = Configuration["SqlConnection:SqlConnectionString"];
        services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));
        services.AddMemoryCache();
        services.AddMvc();
    }

    public void ConfigureContainer(ContainerBuilder Builder)
    {
        #region Modulo IOC
        Builder.RegisterModule(new ModuleIOC());
        #endregion
    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}